using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using TVShowObjects;
using TheTVDBAPI;
using DatabaseManager;

namespace PersonalTVShowOrganiser
{
    public partial class frmFavourites : Form
    {
        private TheTVDBAPI.TheTVDBAPI _tvdbAPI = new TheTVDBAPI.TheTVDBAPI("CF16009B834D65E7", "en", "http://thetvdb.com");
        private DatabaseManager.DatabaseManager _dbManager = new DatabaseManager.DatabaseManager();
        private Dictionary<int, Series> _favourites = new Dictionary<int, Series>();
        private int _seriesID = 0;

        public frmFavourites()
        {
            InitializeComponent();
        }

        private void PopulateFavoutitesPanel()
        {
            pnlFavourites.Controls.Clear();
            string localAppFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Personal TV Organiser\\";
            int x = 3;
            foreach (Series series in _favourites.Values)
            {
                PosterButton.PosterButton posterButton = new PosterButton.PosterButton();
                posterButton.SeriesID = series.SeriesID;
                if (series.Poster != "")
                {
                    if (!File.Exists(string.Concat(new object[4] { localAppFolder, series.SeriesID, "\\", series.Poster.Replace("/", "\\") })))
                        _tvdbAPI.SaveSeriesPoster(series.SeriesID, series.Poster);
                    posterButton.Poster = string.Concat(new object[4] { localAppFolder, series.SeriesID, "\\", series.Poster.Replace("/", "\\") });
                }
                posterButton.SeriesName = series.SeriesName;
                posterButton.Size = new Size(195, 303);
                posterButton.Location = new Point(x, 3);
                posterButton.Anchor = AnchorStyles.Left;
                posterButton.BackColor = Color.Black;
                posterButton.ButtonClick += new EventHandler(pb_Click);
                pnlFavourites.Controls.Add(posterButton);
                x += 211;
            }
        }

        private void frmFavourites_Load(object sender, EventArgs e)
        {
            _dbManager.DataSource = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Personal TV Organiser\\" + "db.sqlite";
            try
            {
                _dbManager.InitializeConnection();
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
            if (_favourites.Count > 0)
                PopulateFavoutitesPanel();
            else
                lblAddFavourites.Visible = true;
            
        }

        private void pb_Click(object sender, EventArgs e)
        {
            try
            {
                string localAppFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Personal TV Organiser\\";
                _seriesID = ((PosterButton.PosterButton)sender).SeriesID;
                Series series = _favourites[_seriesID];
                if (series != null)
                {
                    _dbManager.OpenConnection();
                    Series seriesInfo = _dbManager.GetSeriesInfo(series.SeriesID);
                    Episode nextEpisode = _dbManager.GetNextEpisode(series.SeriesID);
                    _dbManager.CloseConnection();
                    if (series.Fanart != "")
                    {
                        if (!File.Exists(string.Concat(new object[4] { localAppFolder, series.SeriesID, "\\", series.Fanart.Replace("/original", "").Replace("/", "\\") })))
                            _tvdbAPI.SaveFanartVignette(series.SeriesID, series.Fanart);
                        pbBackground.BackgroundImage = new Bitmap(string.Concat(new object[4] { localAppFolder, series.SeriesID, "\\", series.Fanart.Replace("/original", "").Replace("/", "\\") }));
                    }
                    else
                        pbBackground.BackgroundImage = null;
                    lblName.Text = series.SeriesName;
                    lblYear.Text = series.FirstAired.ToString("yyyy");
                    lblRating.Text = series.Rating.ToString() + "/10";
                    lblNoOfEpisodes.Text = seriesInfo.Episodes.Count.ToString() + " episodes";
                    lblOverview.Text = series.Overview;
                    if (series.Actors.Count >= 3)
                        lblActors.Text = series.Actors[0] + ", " + series.Actors[1] + ", " + series.Actors[2];
                    lblContentRating.Text = series.ContentRating;
                    if (nextEpisode != null)
                        lblNextEpisode.Text = "Next Episode to watch: " + nextEpisode.ToString();
                    else
                        lblNextEpisode.Text = "No more episodes to watch";
                    lblName.Visible = true;
                    lblYear.Visible = true;
                    lblRating.Visible = true;
                    lblNoOfEpisodes.Visible = true;
                    lblOverview.Visible = true;
                    lblActors.Visible = true;
                    lblContentRating.Visible = true;
                    lblNextEpisode.Visible = true;
                    btnShowMore.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowMore_MouseEnter(object sender, EventArgs e)
        {
            btnShowMore.ForeColor = Color.LightSkyBlue;
        }

        private void btnShowMore_MouseLeave(object sender, EventArgs e)
        {
            btnShowMore.ForeColor = Color.White;
        }

        private void btnShowMore_Click(object sender, EventArgs e)
        {
            string source = "DB";
            frmTVShow frmTvShow = new frmTVShow();
            frmTVShow.ShowID = _seriesID;
            frmTVShow.SeriesSource = source;
            frmTvShow.ShowDialog();
            _dbManager.OpenConnection();
            _favourites = _dbManager.GetFavourites();
            _dbManager.CloseConnection();
            PopulateFavoutitesPanel();
        }
    }
}
