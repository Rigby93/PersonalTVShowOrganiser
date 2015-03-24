using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;
using TVShowObjects;
using DatabaseManager;

namespace PersonalTVShowOrganiser
{
    public partial class frmCalendar : Form
    {
        private DatabaseManager.DatabaseManager _dbManager = new DatabaseManager.DatabaseManager();
        private Dictionary<int, CalendarItem> _items = new Dictionary<int, CalendarItem>();
        private Dictionary<int, Episode> _episodes = new Dictionary<int, Episode>();
        private CalendarItem contextItem = null;
        private Episode lastSelectedEpisode = null;

        public frmCalendar()
        {
            InitializeComponent();
        }

        private void PlaceItems()
        {
            foreach (CalendarItem item in _items.Values)
            {
                if (calendar1.ViewIntersects(item))
                    calendar1.Items.Add(item);
            }
        }

        private void SetCalendarView()
        {
            bool isSunday = false;
            DateTime startDate = Convert.ToDateTime("01 " + dateTimePicker1.Value.ToString("MMM yyyy"));
            DateTime endDate = Convert.ToDateTime("01 " + dateTimePicker1.Value.ToString("MMM yyyy"));
            endDate = endDate.AddMonths(1);
            DateTime newEndDate = endDate.AddSeconds(-1);
            if (startDate.DayOfWeek == DayOfWeek.Sunday)
                startDate = startDate.AddDays(-6);
            while (!isSunday)
            {
                if (newEndDate.DayOfWeek == DayOfWeek.Sunday)
                    isSunday = true;
                else
                    newEndDate = newEndDate.AddDays(1);
            }
            calendar1.SetViewRange(startDate, newEndDate);
        }

        private void frmCalendar_Load(object sender, EventArgs e)
        {
            _dbManager.DataSource = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Personal TV Organiser" + "\\db.sqlite";
            _dbManager.InitializeConnection();
            _dbManager.OpenConnection();
            _episodes = _dbManager.GetEpisodesWithDates(false);
            _dbManager.CloseConnection();
            foreach (Episode episode in _episodes.Values)
            {
                DateTime startDate = episode.FirstAired;
                if (episode.TimeAirs > Convert.ToDateTime("01/01/0001"))
                {
                    string airDate = episode.FirstAired.ToString("dd MMM yyyy");
                    string airTime = episode.TimeAirs.ToString("HH:mm");
                    startDate = Convert.ToDateTime(airDate + " " + airTime);
                }
                DateTime endDate = episode.Runtime <= 0 ? startDate.AddHours(1) : startDate.AddMinutes(episode.Runtime);
                CalendarItem calendarItem = new CalendarItem(calendar1, startDate, endDate, episode.ToString());
                calendarItem.Tag = episode.EpisodeID;
                if (episode.Watched)
                    calendarItem.ApplyColor(Color.FromArgb(0, 192, 192, 192));
                else if (episode.FirstAired <= DateTime.Now)
                    calendarItem.ApplyColor(Color.FromArgb(0, 255, 0, 0));
                _items.Add(episode.EpisodeID, calendarItem);
            }
            calendar1.MaximumFullDays = 7;
            SetCalendarView();
            lblMonth.Text = DateTime.Today.ToString("MMMM");
            lineShape1.X2 = Width - calendar1.Width - 35;
        }

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            PlaceItems();
            lblMonth.Text = calendar1.ViewStart.AddDays(15).ToString("MMMM");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SetCalendarView();
            lblMonth.Text = dateTimePicker1.Value.ToString("MMMM");
        }

        private void calendar1_ItemClick(object sender, CalendarItemEventArgs e)
        {
            Episode episode = _episodes[(int)e.Item.Tag];
            if (episode != null)
            {
                lblSeriesName.Text = episode.SeriesName;
                lblSeason.Text = "Season: " + episode.Season;
                lblEpisodeNumber.Text = "Episode: " + episode.EpisodeNumber;
                lblEpisodeName.Text = episode.Name;
                txtOverview.Text = episode.Overview;
                chkWatched.Checked = episode.Watched;
                lblSeriesName.Visible = true;
                lblSeason.Visible = true;
                lblEpisodeNumber.Visible = true;
                lblEpisodeName.Visible = true;
                txtOverview.Visible = true;
                chkWatched.Visible = true;
                lastSelectedEpisode = episode;
            }
        }

        private void calendar1_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            contextItem = calendar1.ItemAt(contextMenuStrip1.Bounds.Location);
            if (contextItem != null)
                return;
            e.Cancel = true;
        }

        private void calendar1_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
            calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
        }

        private void frmCalendar_Resize(object sender, EventArgs e)
        {
            lineShape1.X2 = Width - calendar1.Width - 35;
            txtOverview.MinimumSize = new Size(Width - calendar1.Width - 35, 188);
            txtOverview.MaximumSize = new Size(Width - calendar1.Width - 35, 188);
        }

        private void chkWatched_Click(object sender, EventArgs e)
        {
            if (chkWatched.Checked)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to mark this episode as watched?", "Mark as Watched", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        lastSelectedEpisode.Watched = true;
                        _dbManager.OpenConnection();
                        _dbManager.BeginTransaction();
                        _dbManager.UpdateWatchedEpisodes(new List<Episode> { lastSelectedEpisode });
                        _dbManager.Commit();
                        _dbManager.CloseConnection();
                        _items[lastSelectedEpisode.EpisodeID].ApplyColor(Color.FromArgb(0, 192, 192, 192));
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        chkWatched.Checked = false;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to mark this episode as unwatched?", "Mark as Unwatched", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        lastSelectedEpisode.Watched = false;
                        _dbManager.OpenConnection();
                        _dbManager.BeginTransaction();
                        _dbManager.UpdateWatchedEpisodes(new List<Episode> { lastSelectedEpisode });
                        _dbManager.Commit();
                        _dbManager.CloseConnection();
                        if (lastSelectedEpisode.FirstAired <= DateTime.Now)
                            _items[lastSelectedEpisode.EpisodeID].ApplyColor(Color.FromArgb(0, 255, 0, 0));
                        else
                            _items[lastSelectedEpisode.EpisodeID].RemoveColors();
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        chkWatched.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            calendar1.Items.Clear();
            PlaceItems();
        }
    }
}
