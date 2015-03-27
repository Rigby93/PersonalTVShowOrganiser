using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TVShowObjects;
using TheTVDBAPI;
using DatabaseManager;

namespace PersonalTVShowOrganiser
{
    public partial class frmTVShow : Form
    {
        private static int _showID = 0;
        private static string _seriesSource;
        private TheTVDBAPI.TheTVDBAPI _tvdbAPI = new TheTVDBAPI.TheTVDBAPI("CF16009B834D65E7", "en", "http://thetvdb.com");
        private DatabaseManager.DatabaseManager _dbManager = new DatabaseManager.DatabaseManager();
        private Series _series = new Series();
        private bool _favouriteFlag = false;

        public static int ShowID
        {
            set
            {
                frmTVShow._showID = value;
            }
        }

        public static string SeriesSource
        {
            set
            {
                frmTVShow._seriesSource = value;
            }
        }

        public frmTVShow()
        {
            InitializeComponent();
        }

        private void InitializeEpisodesGrid(Series series)
        {
            DataTable dataTable = new DataTable();
            int previousSeasonNumber = -1;
            dataTable.Columns.Add("EpisodeID", typeof(int));
            dataTable.Columns.Add("Episode Number", typeof(string));
            dataTable.Columns.Add("Episode Name", typeof(string));
            dataTable.Columns.Add("Overview", typeof(string));
            dataTable.Columns.Add("Originally Aired", typeof(string));
            dataTable.Columns.Add("Watched", typeof(bool));
            cmbSeasons.Items.Add("All");
            foreach (Episode episode in series.Episodes.Values)
            {
                object[] row = new object[6]
                      {
                        episode.EpisodeID,
                        episode.Season + "-" + episode.EpisodeNumber,
                        episode.Name,
                        episode.Overview,
                        !(episode.FirstAired > Convert.ToDateTime("01 Jan 1900")) ? "" : episode.FirstAired.ToString("yyyy-MM-dd"),
                        episode.Watched
                      };
                dataTable.Rows.Add(row);
                PopulateSeasons(episode.Season, ref previousSeasonNumber);
            }
            cmbSeasons.SelectedItem = "All";
            dgvEpisodes.DataSource = dataTable;
            dgvEpisodes.Columns["EpisodeID"].Visible = false;
            dgvEpisodes.Columns["Episode Number"].ReadOnly = true;
            dgvEpisodes.Columns["Episode Number"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvEpisodes.Columns["Episode Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEpisodes.Columns["Episode Name"].ReadOnly = true;
            dgvEpisodes.Columns["Episode Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvEpisodes.Columns["Episode Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEpisodes.Columns["Overview"].ReadOnly = true;
            dgvEpisodes.Columns["Overview"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvEpisodes.Columns["Overview"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvEpisodes.Columns["Originally Aired"].ReadOnly = true;
            dgvEpisodes.Columns["Originally Aired"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvEpisodes.Columns["Originally Aired"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvEpisodes.Columns["Watched"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            if (frmTVShow._seriesSource == "XML")
            {
                dgvEpisodes.Columns["Watched"].Visible = false;
                btnSelectAll.Enabled = false;
                btnDeselectAll.Enabled = false;
                btnConfirm.Enabled = false;
            }
            dgvEpisodes.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dgvEpisodes, true, null);
        }

        private void PopulateSeasons(int seasonNumber, ref int previousSeasonNumber)
        {
            if (previousSeasonNumber == seasonNumber)
                return;
            if (seasonNumber == 0)
                cmbSeasons.Items.Add("Specials");
            else
                cmbSeasons.Items.Add(seasonNumber);
            previousSeasonNumber = seasonNumber;
        }

        private void PopulateSeriesInfo(Series series)
        {
            string localAppFolder = string.Concat(new object[4] { Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "\\Personal TV Organiser\\", frmTVShow._showID, "\\" });
            this.Text = series.SeriesName;
            lblName.Text = series.SeriesName;
            lblOverview.Text = series.Overview;
            lblFirstAiredText.Text = series.FirstAired.ToString("yyyy-MM-dd");
            if (series.FirstAired > Convert.ToDateTime("01 Jan 1900"))
                lblFirstAiredText.Text = series.FirstAired.ToString("yyyy-MM-dd");
            else
                lblFirstAiredText.Text = "";
            lblAirDayText.Text = series.DayOfWeekAirs;
            lblAirTimeText.Text = series.TimeAirs.ToString("HH:mm");
            lblRuntimeText.Text = series.Runtime.ToString() + " minutes";
            lblNetworkText.Text = series.Network;
            lblGenreText.Text = "";
            foreach (string genre in series.Genre)
            {
                lblGenreText.Text += genre;
                lblGenreText.Text += Environment.NewLine;
            }
            if (!(series.Poster != ""))
                return;
            _tvdbAPI.SaveSeriesPoster(series.SeriesID, series.Poster);
            pbPoster.Image = new Bitmap(localAppFolder + series.Poster.Replace("/", "\\"));
        }

        private Series GetSeriesInfo(string source)
        {
            Series series = new Series();
            Series seriesInfo;
            if (source == "XML")
            {
                seriesInfo = _tvdbAPI.GetSeriesInfo(_showID);
                btnFavourite.ImageIndex = 1;
                toolTip1.SetToolTip(btnFavourite, "Favourite");
            }
            else
            {
                _dbManager.OpenConnection();
                seriesInfo = _dbManager.GetSeriesInfo(_showID);
                _dbManager.CloseConnection();
                btnFavourite.ImageIndex = 0;
                toolTip1.SetToolTip(btnFavourite, "Unfavourite");
            }
            return seriesInfo;
        }

        private void ChangeSelection(bool selectAll)
        {
            for (int i = 0; i < dgvEpisodes.RowCount; ++i)
                dgvEpisodes.Rows[i].Cells[5].Value = selectAll;
        }

        private void frmTVShow_Load(object sender, EventArgs e)
        {
            _dbManager.DataSource = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Personal TV Organiser" + "\\db.sqlite";
            _dbManager.InitializeConnection();
            _series = GetSeriesInfo(_seriesSource);
            lblOverview.MaximumSize = new Size(Width - 280, Height - 380);
            PopulateSeriesInfo(_series);
            InitializeEpisodesGrid(_series);
            cmbSeasons.SelectedIndexChanged += new EventHandler(cmbSeasons_SelectedIndexChanged);
        }

        private void frmTVShow_Resize(object sender, EventArgs e)
        {
            lblOverview.MaximumSize = new Size(this.Width - 280, this.Height - 380);
        }

        private void cmbSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            int season = -1;
            int num = 0;
            if (cmbSeasons.SelectedItem.ToString() == "All")
                season = -1;
            else if (cmbSeasons.SelectedItem.ToString() == "Specials")
                season = 0;
            else if (int.TryParse(cmbSeasons.SelectedItem.ToString(), out num))
                season = num;
            if (season > -1)
                (dgvEpisodes.DataSource as DataTable).DefaultView.RowFilter = "[Episode Number] like '" + season + "-%'";
            else
                (dgvEpisodes.DataSource as DataTable).DefaultView.RowFilter = null;
        }

        private void dgvEpisodes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(dgvEpisodes.Rows[e.RowIndex].Cells[5].Value))
                    dgvEpisodes.Rows[e.RowIndex].Cells[5].Value = false;
                else
                    dgvEpisodes.Rows[e.RowIndex].Cells[5].Value = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnFavourite_MouseLeave(object sender, EventArgs e)
        {
            if (!_favouriteFlag)
            {
                if (btnFavourite.ImageIndex == 0)
                    btnFavourite.ImageIndex = 1;
                else
                    btnFavourite.ImageIndex = 0;
            }
            _favouriteFlag = false;
        }

        private void btnFavourite_MouseEnter(object sender, EventArgs e)
        {
            if (btnFavourite.ImageIndex == 0)
                btnFavourite.ImageIndex = 1;
            else
                btnFavourite.ImageIndex = 0;
        }

        private void btnFavourite_Click(object sender, EventArgs e)
        {
            if (btnFavourite.ImageIndex == 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    _dbManager.OpenConnection();
                    _dbManager.BeginTransaction();
                    _dbManager.InsertSeries(_series);
                    _dbManager.Commit();
                    dgvEpisodes.Columns["Watched"].Visible = true;
                    MessageBox.Show("Added to Favourites");
                    toolTip1.SetToolTip(btnFavourite, "Unfavourite");
                    btnSelectAll.Enabled = true;
                    btnDeselectAll.Enabled = true;
                    btnConfirm.Enabled = true;
                    _favouriteFlag = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't add series to favourites. Please try again later");
                }
                finally
                {
                    if (_dbManager.TheTransaction != null)
                        _dbManager.Rollback();
                    _dbManager.CloseConnection();
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    _dbManager.OpenConnection();
                    _dbManager.BeginTransaction();
                    _dbManager.DeleteSeries(_series.SeriesID);
                    _dbManager.Commit();
                    dgvEpisodes.Columns["Watched"].Visible = false;
                    MessageBox.Show("Removed from Favourites");
                    toolTip1.SetToolTip(btnFavourite, "Favourite");
                    btnSelectAll.Enabled = false;
                    btnDeselectAll.Enabled = false;
                    btnConfirm.Enabled = false;
                    _favouriteFlag = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't remove series from favourites. Please try again later");
                }
                finally
                {
                    if (_dbManager.TheTransaction != null)
                        _dbManager.Rollback();
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ChangeSelection(true);
            Cursor.Current = Cursors.Default;
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ChangeSelection(false);
            Cursor.Current = Cursors.Default;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<Episode> watchedEpisodes = new List<Episode>();
            Cursor.Current = Cursors.WaitCursor;
            for (int i = 0; i < dgvEpisodes.RowCount; ++i)
            {
                Episode episode = new Episode();
                int num;
                if (int.TryParse(dgvEpisodes.Rows[i].Cells[0].Value.ToString(), out num))
                    episode.EpisodeID = num;
                bool boolean;
                if (bool.TryParse(dgvEpisodes.Rows[i].Cells[5].Value.ToString(), out boolean))
                    episode.Watched = boolean;
                watchedEpisodes.Add(episode);
            }
            _dbManager.OpenConnection();
            _dbManager.BeginTransaction();
            _dbManager.UpdateWatchedEpisodes(watchedEpisodes);
            _dbManager.Commit();
            _dbManager.CloseConnection();
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Saved!");
        }
    }
}
