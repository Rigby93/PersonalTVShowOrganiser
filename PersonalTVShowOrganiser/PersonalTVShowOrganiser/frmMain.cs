using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TVShowObjects;
using TheTVDBAPI;
using DatabaseManager;

namespace PersonalTVShowOrganiser
{
    public partial class frmMain : Form
    {
        private TheTVDBAPI.TheTVDBAPI _tvdbAPI = new TheTVDBAPI.TheTVDBAPI("CF16009B834D65E7", "en", "http://thetvdb.com");
        private DatabaseManager.DatabaseManager _dbManager = new DatabaseManager.DatabaseManager();
        private Dictionary<int, Series> _favourites = new Dictionary<int, Series>();
        private bool _iconClose = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string localAppFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Personal TV Organiser";
            _dbManager.DataSource = localAppFolder + "\\db.sqlite";
            if (!File.Exists(localAppFolder + "\\db.sqlite"))
            {
                if (!Directory.Exists(localAppFolder))
                    Directory.CreateDirectory(localAppFolder);
                try
                {
                    _dbManager.CreateDatabase();
                    _dbManager.InitializeConnection();
                    _dbManager.OpenConnection();
                    _dbManager.BeginTransaction();
                    InitializeDatabase();
                    _dbManager.Commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was a problem creating the database");
                }
                finally
                {
                    if (_dbManager.TheTransaction != null)
                        _dbManager.Rollback();
                    _dbManager.CloseConnection();
                }
            }
            else
            {
                prgMain.Value = 0;
                prgMain.Visible = true;
                lblStatus.Visible = true;
                lblStatus.Text = "Getting Updates...";
                _dbManager.InitializeConnection();
                bgwUpdate.RunWorkerAsync();
                StartTimer();
            }
            try
            {
                _dbManager.OpenConnection();
                _favourites = _dbManager.GetFavourites();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldn't read favoutites");
            }
            finally
            {
                _dbManager.CloseConnection();
            }
            PopulateUpcomingEpisodes();
            PopulateMissedEpisodes();
        }

        private void PopulateUpcomingEpisodes()
        {
            dgvUpcomingEpisodes.DataSource = null;
            dgvUpcomingEpisodes.Rows.Clear();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Series Name");
            dataTable.Columns.Add("Episode Number");
            dataTable.Columns.Add("Episode Name");
            dataTable.Columns.Add("Air Date");
            _dbManager.OpenConnection();
            Dictionary<int, Episode> upcomingEpisodes = _dbManager.GetUpcomingEpisodes(false, 10);
            _dbManager.CloseConnection();
            foreach (Episode episode in upcomingEpisodes.Values)
            {
                object[] row = new object[4]
                      {
                        episode.SeriesName,
                        episode.Season + "-" + episode.EpisodeNumber,
                        episode.Name,
                        episode.FirstAired.ToString("ddd dd-MMM")
                      };
                dataTable.Rows.Add(row);
            }
            dgvUpcomingEpisodes.DataSource = dataTable;
            dgvUpcomingEpisodes.Columns["Series Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvUpcomingEpisodes.Columns["Series Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvUpcomingEpisodes.Columns["Episode Number"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvUpcomingEpisodes.Columns["Episode Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvUpcomingEpisodes.Columns["Episode Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvUpcomingEpisodes.Columns["Episode Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvUpcomingEpisodes.Columns["Air Date"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvUpcomingEpisodes.Columns["Air Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void PopulateMissedEpisodes()
        {
            dgvMissedEpisodes.DataSource = null;
            dgvMissedEpisodes.Rows.Clear();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Series Name");
            dataTable.Columns.Add("Episode Number");
            dataTable.Columns.Add("Episode Name");
            dataTable.Columns.Add("Air Date");
            _dbManager.OpenConnection();
            Dictionary<int, Episode> missedEpisodes = _dbManager.GetMissedEpisodes(false, 10);
            _dbManager.CloseConnection();
            foreach (Episode episode in missedEpisodes.Values)
            {
                object[] row = new object[4]
                      {
                        episode.SeriesName,
                        episode.Season + "-" + episode.EpisodeNumber,
                        episode.Name,
                        episode.FirstAired.ToString("dd-MMM-yyyy")
                      };
                dataTable.Rows.Add(row);
            }
            dgvMissedEpisodes.DataSource = dataTable;
            dgvMissedEpisodes.Columns["Series Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvMissedEpisodes.Columns["Series Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMissedEpisodes.Columns["Episode Number"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvMissedEpisodes.Columns["Episode Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMissedEpisodes.Columns["Episode Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvMissedEpisodes.Columns["Episode Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMissedEpisodes.Columns["Air Date"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvMissedEpisodes.Columns["Air Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void InitializeDatabase()
        {
            _dbManager.CreateTables();
            _dbManager.UpdateSetting("previousServerTime", _tvdbAPI.GetCurrentServerTime());
        }

        private void StartTimer()
        {
            if (timer.Enabled)
                timer.Stop();
            timer.Start();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvSearchResults.DataSource = null;
            dgvSearchResults.Rows.Clear();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("SeriesID");
            dataTable.Columns.Add("Series Name");
            dataTable.Columns.Add("Network");
            dataTable.Columns.Add("First Aired");
            foreach (Series series in _tvdbAPI.GetSeries(txtSearch.Text).Values)
            {
                object[] row = new object[4]
                      {
                        series.SeriesID,
                        series.SeriesName,
                        series.Network,
                        !(series.FirstAired > Convert.ToDateTime("01 Jan 1900")) ? "" : series.FirstAired.ToString("yyyy-MM-dd")
                      };
                dataTable.Rows.Add(row);
            }
            dgvSearchResults.DataSource = dataTable;
            dgvSearchResults.Columns["SeriesID"].Visible = false;
            dgvSearchResults.Columns["Series Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvSearchResults.Columns["Network"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvSearchResults.Columns["First Aired"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvSearchResults.Visible = true;
            tabScreens.SelectedTab = tabResults;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            btnSearch.PerformClick();
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void dgvSearchResults_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int seriesID = Convert.ToInt32(dgvSearchResults.Rows[e.RowIndex].Cells[0].Value);
                string dataSource = "XML";
                frmTVShow frmTvShow = new frmTVShow();
                frmTVShow.ShowID = seriesID;
                if (_favourites.Keys.Contains(seriesID))
                {
                    dataSource = "DB";
                }
                frmTVShow.SeriesSource = dataSource;
                frmTvShow.ShowDialog();
                _dbManager.OpenConnection();
                _favourites = _dbManager.GetFavourites();
                _dbManager.CloseConnection();
                PopulateUpcomingEpisodes();
                PopulateMissedEpisodes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewUpcoming_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click");
        }

        private void btnViewUpcoming_MouseEnter(object sender, EventArgs e)
        {
            btnViewUpcoming.ForeColor = Color.LightSkyBlue;
        }

        private void btnViewUpcoming_MouseLeave(object sender, EventArgs e)
        {
            btnViewUpcoming.ForeColor = Color.White;
        }

        private void btnViewMissed_MouseEnter(object sender, EventArgs e)
        {
            btnViewMissed.ForeColor = Color.LightSkyBlue;
        }

        private void btnViewMissed_MouseLeave(object sender, EventArgs e)
        {
            btnViewMissed.ForeColor = Color.White;
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            frmCalendar frmCal = new frmCalendar();
            frmCal.ShowDialog();
            PopulateUpcomingEpisodes();
            PopulateMissedEpisodes();
        }

        private void btnCalendar_MouseEnter(object sender, EventArgs e)
        {
            btnCalendar.ForeColor = Color.LightSkyBlue;
        }

        private void btnCalendar_MouseLeave(object sender, EventArgs e)
        {
            btnCalendar.ForeColor = Color.White;
        }

        private void btnFavourites_Click(object sender, EventArgs e)
        {
            frmFavourites frmFav = new frmFavourites();
            frmFav.ShowDialog();
            _dbManager.OpenConnection();
            _favourites = _dbManager.GetFavourites();
            _dbManager.CloseConnection();
            PopulateUpcomingEpisodes();
            PopulateMissedEpisodes();
        }

        private void btnFavourites_MouseEnter(object sender, EventArgs e)
        {
            btnFavourites.ForeColor = Color.LightSkyBlue;
        }

        private void btnFavourites_MouseLeave(object sender, EventArgs e)
        {
            btnFavourites.ForeColor = Color.White;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_iconClose)
                return;
            e.Cancel = true;
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(500);
            this.Hide();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            _iconClose = true;
            notifyIcon.Visible = false;
            this.Close();
        }

        private void mnuUpdate_Click(object sender, EventArgs e)
        {
            if (bgwUpdate.IsBusy)
                return;
            prgMain.Value = 0;
            prgMain.Visible = true;
            lblStatus.Text = "Getting Updates...";
            bgwUpdate.RunWorkerAsync();
            StartTimer();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(this.timer_Tick), sender, e);
            }
            else
            {
                lock (timer)
                {
                    if (timer.Enabled)
                    {
                        if (!bgwUpdate.IsBusy)
                        {
                            prgMain.Value = 0;
                            prgMain.Visible = true;
                            lblStatus.Text = "Getting Updates...";
                            bgwUpdate.RunWorkerAsync();
                        }
                        StartTimer();
                    }
                }
            }
        }

        private void bgwUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
            DatabaseManager.DatabaseManager databaseManager = new DatabaseManager.DatabaseManager();
            string localAppFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Personal TV Organiser";
            databaseManager.DataSource = localAppFolder + "\\db.sqlite";
            databaseManager.InitializeConnection();
            Update update = new Update();
            List<Series> seriesToUpdate = new List<Series>();
            List<Episode> episodesToUpdate = new List<Episode>();
            try
            {
                databaseManager.OpenConnection();
                Dictionary<string, string> settings = databaseManager.GetSettings("previousServerTime");
                databaseManager.CloseConnection();
                Update updates = this._tvdbAPI.GetUpdates(settings["previousServerTime"]);
                int totalUpdates = _favourites.Count + updates.EpisodeUpdates.Count;
                int percentProgress = 0;
                double progress = 0;
                bgwUpdate.ReportProgress(percentProgress);
                foreach (int seriesID in _favourites.Keys)
                {
                    if (updates.SeriesUpdates.Contains(seriesID))
                    {
                        Series seriesUpdates = _tvdbAPI.GetSeriesUpdates(seriesID);
                        if (seriesUpdates != null)
                            seriesToUpdate.Add(seriesUpdates);
                    }
                    ++progress;
                    bgwUpdate.ReportProgress((int)Math.Round(progress / totalUpdates * 100.0));
                }
                foreach (int episodeID in updates.EpisodeUpdates)
                {
                    Episode episodeUpdates = _tvdbAPI.GetEpisodeUpdates(episodeID);
                    if (episodeUpdates != null)
                    {
                        if (_favourites.Keys.Contains(episodeUpdates.SeriesID))
                        {
                            episodesToUpdate.Add(episodeUpdates);
                        }
                    }
                    ++progress;
                    bgwUpdate.ReportProgress((int)Math.Round(progress / totalUpdates * 100.0));
                }
                databaseManager.OpenConnection();
                databaseManager.BeginTransaction();
                foreach (Series series in seriesToUpdate)
                {
                    databaseManager.UpdateSeries(series);
                }
                string seriesName = "";
                foreach (Episode episode in episodesToUpdate)
                {
                    seriesName = _favourites[episode.SeriesID].SeriesName;
                    databaseManager.UpdateEpisode(episode, seriesName);
                }
                databaseManager.UpdateSetting("previousServerTime", updates.Time);
                databaseManager.Commit();
                bgwUpdate.ReportProgress(100);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (databaseManager.TheTransaction != null)
                    databaseManager.Rollback();
                databaseManager.CloseConnection();
            }
        }

        private void bgwUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                prgMain.Value = e.ProgressPercentage;
                lblStatus.Text = "Updating..." + prgMain.Value.ToString() + "%";
            }
            catch (Exception ex)
            {
            }
        }

        private void bgwUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblStatus.Text = "Update failed";
            }
            else
            {
                prgMain.Visible = false;
                lblStatus.Text = "Done.";
            }
        }

    }

}
