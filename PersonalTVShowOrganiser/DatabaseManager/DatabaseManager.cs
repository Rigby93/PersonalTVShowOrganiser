using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data.SQLite;
using TVShowObjects;

namespace DatabaseManager
{
    public class DatabaseManager
    {
        private SQLiteConnection _dbConnection;
        private SQLiteTransaction _transaction;
        private string _dataSource;

        public string DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
            }
        }

        public SQLiteTransaction TheTransaction
        {
            get
            {
                return _transaction;
            }
        }

        public DatabaseManager()
        {
        }

        public DatabaseManager(string dataSource)
        {
            _dataSource = dataSource;
        }

        private Dictionary<int, Series> ReadFavourites(string sqlCommand)
        {
            Dictionary<int, Series> favourites = new Dictionary<int, Series>();
            string[] formats = new string[4] { "hh:mm tt", "h:mm tt", "HH:mm", "H:mm" };
            SQLiteDataReader reader = new SQLiteCommand(sqlCommand, _dbConnection).ExecuteReader();
            while (reader.Read())
            {
                Series series = new Series();
                int num;
                if (int.TryParse(reader["seriesID"].ToString(), out num))
                    series.SeriesID = num;
                List<string> actors = new List<string>((IEnumerable<string>)reader["actors"].ToString().Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries));
                series.Actors = actors;
                series.DayOfWeekAirs = reader["dayOfWeekAirs"].ToString();
                DateTime date;
                if (DateTime.TryParseExact(reader["timeAirs"].ToString(), formats, (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    series.TimeAirs = date;
                series.ContentRating = reader["contentRating"].ToString();
                double dub;
                if (double.TryParse(reader["firstAired"].ToString(), out dub))
                    series.FirstAired = ToDate(dub);
                List<string> genres = new List<string>((IEnumerable<string>)reader["genre"].ToString().Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries));
                series.Genre = genres;
                series.IMDB_ID = reader["imdbID"].ToString();
                series.Language = reader["language"].ToString();
                series.Network = reader["network"].ToString();
                series.Overview = reader["overview"].ToString();
                if (double.TryParse(reader["rating"].ToString(), out dub))
                    series.Rating = dub;
                if (int.TryParse(reader["ratingCount"].ToString(), out num))
                    series.RatingCount = num;
                if (int.TryParse(reader["runtime"].ToString(), out num))
                    series.Runtime = num;
                series.SeriesName = reader["seriesName"].ToString();
                series.Status = reader["status"].ToString();
                series.Banner = reader["banner"].ToString();
                series.Fanart = reader["fanart"].ToString();
                series.Poster = reader["poster"].ToString();
                favourites.Add(series.SeriesID, series);
            }
            return favourites;
        }

        private Dictionary<int, Episode> ReadEpisodeDetails(string sqlCommand, bool timeAirs = false)
        {
            Dictionary<int, Episode> episodes = new Dictionary<int, Episode>();
            string[] formats = new string[4] { "hh:mm tt", "h:mm tt", "HH:mm", "H:mm" };
            SQLiteDataReader reader = new SQLiteCommand(sqlCommand, _dbConnection).ExecuteReader();
            while (reader.Read())
            {
                Episode episode = new Episode();
                int num;
                if (int.TryParse(reader["episodeID"].ToString(), out num))
                    episode.EpisodeID = num;
                episode.SeriesName = reader["seriesName"].ToString();
                episode.Director = reader["director"].ToString();
                episode.Name = reader["episodeName"].ToString();
                if (int.TryParse(reader["episodeNumber"].ToString(), out num))
                    episode.EpisodeNumber = num;
                double dub;
                if (double.TryParse(reader["firstAired"].ToString(), out dub))
                    episode.FirstAired = ToDate(dub);
                List<string> guestStars = new List<string>((IEnumerable<string>)reader["guestStars"].ToString().Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries));
                episode.GuestStars = guestStars;
                episode.Language = reader["language"].ToString();
                episode.Overview = reader["overview"].ToString();
                if (double.TryParse(reader["rating"].ToString(), out dub))
                    episode.Rating = dub;
                if (int.TryParse(reader["ratingCount"].ToString(), out num))
                    episode.RatingCount = num;
                if (int.TryParse(reader["season"].ToString(), out num))
                    episode.Season = num;
                if (timeAirs)
                {
                    DateTime date;
                    if (DateTime.TryParseExact(reader["timeAirs"].ToString(), formats, (IFormatProvider)CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                        episode.TimeAirs = date;
                    if (int.TryParse(reader["runtime"].ToString(), out num))
                        episode.Runtime = num;
                }
                List<string> writers = new List<string>((IEnumerable<string>)reader["writer"].ToString().Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries));
                episode.Writer = writers;
                if (int.TryParse(reader["absoluteNumber"].ToString(), out num))
                    episode.AbsoluteNumber = num;
                if (int.TryParse(reader["watched"].ToString(), out num))
                {
                    if (num == 0)
                        episode.Watched = false;
                    else
                        episode.Watched = true;
                }
                episodes.Add(episode.EpisodeID, episode);
            }
            return episodes;
        }

        private void InitializeSettings()
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            string sqlInsert = "INSERT INTO settings (settingName, setting) VALUES(";
            settings.Add("previousServerTime", "");
            foreach (string settingName in settings.Keys)
            {
                string sqlValues = "'" + settingName + "', " + "'" + settings[settingName] + "')";
                (new SQLiteCommand(sqlInsert + sqlValues, _dbConnection, _transaction)).ExecuteNonQuery();
            }
        }

        private double ToJulianDate(DateTime date)
        {
            return date.ToOADate() + 2415018.5;
        }

        private DateTime ToDate(double date)
        {
            return DateTime.FromOADate(date - 2415018.5);
        }

        public void CreateDatabase()
        {
            SQLiteConnection.CreateFile(_dataSource);
        }

        public void InitializeConnection()
        {
            _dbConnection = new SQLiteConnection("DataSource=" + _dataSource + ";Version=3;");
        }

        public void OpenConnection()
        {
            if (_dbConnection == null)
                return;
            (_dbConnection).Open();
        }

        public void BeginTransaction()
        {
            if (_dbConnection == null)
                return;
            _transaction = _dbConnection.BeginTransaction();
        }

        public void Rollback()
        {
            if (_dbConnection == null || _transaction == null)
                return;
            _transaction.Rollback();
            _transaction = null;
        }

        public void Commit()
        {
            if (_dbConnection == null || _transaction == null)
                return;
            _transaction.Commit();
            _transaction = null;
        }

        public void CloseConnection()
        {
            if (_dbConnection == null)
                return;
            _dbConnection.Close();
        }

        public void CreateTables()
        {
            string sqlFavourites = "CREATE TABLE favourites (seriesID INT NOT NULL PRIMARY KEY, actors TEXT, dayOfWeekAirs TEXT, timeAirs TEXT, contentRating TEXT, firstAired REAL, genre TEXT, imdbID TEXT, language TEXT, network TEXT, overview TEXT, rating REAL, ratingCount INT, runtime INT, seriesName TEXT, status TEXT, banner TEXT, fanart TEXT, poster TEXT)";
            string sqlEpisodes = "CREATE TABLE episodeDetails (seriesID INT NOT NULL, episodeID INT NOT NULL, seriesName TEXT, director TEXT, episodeName TEXT, episodeNumber INT, firstAired REAL, guestStars TEXT, language TEXT, overview TEXT, rating REAL, ratingCount INT, season INT, writer TEXT, absoluteNumber INT, watched INT, PRIMARY KEY (episodeID, seriesID))";
            string sqlSettings = "CREATE TABLE settings (settingName TEXT, setting TEXT)";
            (new SQLiteCommand(sqlFavourites, _dbConnection, _transaction)).ExecuteNonQuery();
            (new SQLiteCommand(sqlEpisodes, _dbConnection, _transaction)).ExecuteNonQuery();
            (new SQLiteCommand(sqlSettings, _dbConnection, _transaction)).ExecuteNonQuery();
            InitializeSettings();
        }

        public Series GetSeriesInfo(int seriesID)
        {
            string sqlFavourites = "SELECT * FROM favourites WHERE seriesID=" + seriesID;
            string sqlEpisodes = "SELECT * FROM episodeDetails WHERE seriesID=" + seriesID + " ORDER BY season, episodeNumber ASC";
            Dictionary<int, Series> favourites = ReadFavourites(sqlFavourites);
            Dictionary<int, Episode> episodes = ReadEpisodeDetails(sqlEpisodes, false);
            Series series = favourites.Values.First();
            series.Episodes = episodes;
            return series;
        }

        public void InsertSeries(Series series)
        {
            string actors = "|";
            string genres = "|";
            string guestStars = "|";
            string writers = "|";
            string sqlFavouritesInsert = "INSERT INTO favourites (seriesID, actors, dayOfWeekAirs, timeAirs, contentRating, firstAired, genre, imdbID, language, network, overview, rating, ratingCount, runtime, seriesName, status, banner, fanart, poster) VALUES(";
            string sqlEpisodeInsert = "INSERT INTO episodeDetails (seriesID, episodeID, seriesName, director, episodeName, episodeNumber, firstAired, guestStars, language, overview, rating, ratingCount, season, writer, absoluteNumber, watched) VALUES";
            StringBuilder stbFavouritesValues = new StringBuilder();
            StringBuilder stbEpisodeValues = new StringBuilder();
            List<StringBuilder> episodeList = new List<StringBuilder>();
            int num = 0;
            stbFavouritesValues.Append(series.SeriesID + ", ");
            foreach (string actor in series.Actors)
                actors = actors + actor + "|";
            stbFavouritesValues.Append("'" + actors.Replace("'", "''") + "', ");
            stbFavouritesValues.Append("'" + series.DayOfWeekAirs + "', ");
            stbFavouritesValues.Append("'" + series.TimeAirs.ToString("HH:mm") + "', ");
            stbFavouritesValues.Append("'" + series.ContentRating + "', ");
            stbFavouritesValues.Append(ToJulianDate(series.FirstAired) + ", ");
            foreach (string genre in series.Genre)
                genres = genres + genre + "|";
            stbFavouritesValues.Append("'" + genres + "', ");
            stbFavouritesValues.Append("'" + series.IMDB_ID + "', ");
            stbFavouritesValues.Append("'" + series.Language + "', ");
            stbFavouritesValues.Append("'" + series.Network + "', ");
            stbFavouritesValues.Append("'" + series.Overview.Replace("'", "''") + "', ");
            stbFavouritesValues.Append(series.Rating + ", ");
            stbFavouritesValues.Append(series.RatingCount + ", ");
            stbFavouritesValues.Append(series.Runtime + ", ");
            stbFavouritesValues.Append("'" + series.SeriesName.Replace("'", "''") + "', ");
            stbFavouritesValues.Append("'" + series.Status + "', ");
            stbFavouritesValues.Append("'" + series.Banner + "', ");
            stbFavouritesValues.Append("'" + series.Fanart + "', ");
            stbFavouritesValues.Append("'" + series.Poster + "')");
            (new SQLiteCommand(sqlFavouritesInsert + stbFavouritesValues.ToString(), _dbConnection, _transaction)).ExecuteNonQuery();
            foreach (Episode episode in series.Episodes.Values)
            {
                stbEpisodeValues.Append("(");
                stbEpisodeValues.Append(series.SeriesID + ", ");
                stbEpisodeValues.Append(episode.EpisodeID + ", ");
                stbEpisodeValues.Append("'" + series.SeriesName.Replace("'", "''") + "', ");
                stbEpisodeValues.Append("'" + episode.Director.Replace("'", "''") + "', ");
                stbEpisodeValues.Append("'" + episode.Name.Replace("'", "''") + "', ");
                stbEpisodeValues.Append(episode.EpisodeNumber + ", ");
                stbEpisodeValues.Append(ToJulianDate(episode.FirstAired) + ", ");
                foreach (string guestStar in episode.GuestStars)
                    guestStars = guestStars + guestStar + "|";
                stbEpisodeValues.Append("'" + guestStars.Replace("'", "''") + "', ");
                stbEpisodeValues.Append("'" + episode.Language + "', ");
                stbEpisodeValues.Append("'" + episode.Overview.Replace("'", "''") + "', ");
                stbEpisodeValues.Append(episode.Rating + ", ");
                stbEpisodeValues.Append(episode.RatingCount + ", ");
                stbEpisodeValues.Append(episode.Season + ", ");
                foreach (string writer in episode.Writer)
                    writers = writers + writer + "|";
                stbEpisodeValues.Append("'" + writers.Replace("'", "''") + "', ");
                stbEpisodeValues.Append(episode.AbsoluteNumber + ", ");
                if (episode.Watched)
                    stbEpisodeValues.Append("1), ");
                else
                    stbEpisodeValues.Append("0), ");
                ++num;
                if (num == 495)
                {
                    episodeList.Add(stbEpisodeValues);
                    stbEpisodeValues = new StringBuilder();
                    num = 0;
                }
            }
            episodeList.Add(stbEpisodeValues);
            foreach (StringBuilder stb in episodeList)
            {
                string sqlEpisodeValues = stb.ToString();
                if (sqlEpisodeValues != null && sqlEpisodeValues.Length > 0)
                    sqlEpisodeValues = sqlEpisodeValues.Substring(0, sqlEpisodeValues.Length - 2);
                (new SQLiteCommand(sqlEpisodeInsert + sqlEpisodeValues, _dbConnection, _transaction)).ExecuteNonQuery();
            }
        }

        public Dictionary<int, Series> GetFavourites()
        {
            return ReadFavourites("SELECT * FROM favourites ORDER BY seriesID ASC");
        }

        public void UpdateWatchedEpisodes(List<Episode> watchedList)
        {
            foreach (Episode episode in watchedList)
            {
                string sqlUpdate = string.Concat(new object[4] { "UPDATE episodeDetails SET watched = ", (!episode.Watched ? 0 : 1), " WHERE episodeID = ", episode.EpisodeID });
                (new SQLiteCommand(sqlUpdate, _dbConnection, _transaction)).ExecuteNonQuery();
            }
        }

        public Dictionary<int, Episode> GetUpcomingEpisodes(bool includeSpecials, int limit = 0)
        {
            int season = 0;
            if (includeSpecials)
                season = -1;
            string sqlCommand = "SELECT * FROM episodeDetails WHERE DATE(firstAired)>=CURRENT_TIMESTAMP AND season>" + season + " ORDER BY firstAired ASC";
            if (limit > 0)
                sqlCommand = sqlCommand + " LIMIT " + limit;
            return ReadEpisodeDetails(sqlCommand, false);
        }

        public Dictionary<int, Episode> GetMissedEpisodes(bool includeSpecials, int limit = 0)
        {
            int season = 0;
            if (includeSpecials)
                season = -1;
            string sqlCommand = "SELECT * FROM episodeDetails WHERE watched=0 AND DATE(firstAired)<CURRENT_TIMESTAMP AND DATE(firstAired)>DATE(2415021) AND season>" + season + " ORDER BY firstAired DESC";
            if (limit > 0)
                sqlCommand = sqlCommand + " LIMIT " + limit;
            return ReadEpisodeDetails(sqlCommand, false);
        }

        public Episode GetNextEpisode(int seriesID)
        {
            Episode episode = null;
            Dictionary<int, Episode> episodes = ReadEpisodeDetails("SELECT * FROM episodeDetails WHERE seriesID = " + seriesID + " AND watched = 0 AND season > 0 ORDER BY season, episodeNumber ASC LIMIT 1", false);
            if (episodes.Count > 0)
                episode = episodes.Values.First();
            return episode;
        }

        public Dictionary<int, Episode> GetEpisodesWithDates(bool includeSpecials)
        {
            int season = 0;
            if (includeSpecials)
                season = -1;
            return ReadEpisodeDetails("SELECT e.seriesID, e.episodeID, e.seriesName, e.director, e.episodeName, e.episodeNumber, e.firstAired, e.guestStars, e.language, e.overview, e.rating, e.ratingCount, e.season, e.writer, e.absoluteNumber, e.watched, f.timeAirs, f.runtime FROM episodeDetails e INNER JOIN favourites f on e.seriesID = f.seriesID WHERE DATE(e.firstAired)>DATE(2415021) AND e.season>" + season + " ORDER BY e.firstAired ASC, f.timeAirs DESC", true);
        }

        public Dictionary<string, string> GetSettings(string settingName = "")
        {
            Dictionary<string, string> settings = new Dictionary<string, string>();
            string sqlSettings = "SELECT * FROM settings";
            string sqlSettingsWhere = " WHERE settingName = '" + settingName + "'";
            if (settingName.Length > 0)
                sqlSettings += sqlSettingsWhere;
            SQLiteDataReader reader = new SQLiteCommand(sqlSettings, _dbConnection).ExecuteReader();
            while (reader.Read())
                settings.Add(reader["settingName"].ToString(), reader["setting"].ToString());
            return settings;
        }

        public void UpdateSetting(string settingName, string setting)
        {
            (new SQLiteCommand("UPDATE settings SET setting = '" + setting + "' WHERE settingName = '" + settingName + "'", _dbConnection, _transaction)).ExecuteNonQuery();
        }

        public void UpdateSeries(Series series)
        {
            string sqlUpdateFavourites = "UPDATE favourites SET ";
            string actors = "";
            string genres = "";
            StringBuilder stbFavourites = new StringBuilder();
            foreach (string actor in series.Actors)
                actors = actors + actor + "|";
            stbFavourites.Append("actors = '" + actors.Replace("'", "''") + "', ");
            stbFavourites.Append("dayOfWeekAirs = '" + series.DayOfWeekAirs + "', ");
            stbFavourites.Append("timeAirs = '" + series.TimeAirs.ToString("HH:mm") + "', ");
            stbFavourites.Append("contentRating = '" + series.ContentRating + "', ");
            stbFavourites.Append("firstAired = " + ToJulianDate(series.FirstAired) + ", ");
            foreach (string actor in series.Genre)
                genres = genres + actor + "|";
            stbFavourites.Append("genre = '" + genres + "', ");
            stbFavourites.Append("imdbID = '" + series.IMDB_ID + "', ");
            stbFavourites.Append("language = '" + series.Language + "', ");
            stbFavourites.Append("network = '" + series.Network + "', ");
            stbFavourites.Append("overview = '" + series.Overview.Replace("'", "''") + "', ");
            stbFavourites.Append("rating = " + series.Rating + ", ");
            stbFavourites.Append("ratingCount = " + series.RatingCount + ", ");
            stbFavourites.Append("runtime = " + series.Runtime + ", ");
            stbFavourites.Append("seriesName = '" + series.SeriesName.Replace("'", "''") + "', ");
            stbFavourites.Append("status = '" + series.Status + "', ");
            stbFavourites.Append("banner = '" + series.Banner + "', ");
            stbFavourites.Append("fanart = '" + series.Fanart + "', ");
            stbFavourites.Append("poster = '" + series.Poster + "' ");
            stbFavourites.Append("WHERE seriesID = " + series.SeriesID);
            (new SQLiteCommand(sqlUpdateFavourites + stbFavourites.ToString(), _dbConnection, _transaction)).ExecuteNonQuery();
        }

        public void UpdateEpisode(Episode episode, string seriesName)
        {
            string sqlUpdateEpisodes = "UPDATE episodeDetails SET ";
            string guestStars = "";
            string writers = "";
            StringBuilder stbEpisodes = new StringBuilder();
            stbEpisodes.Append("seriesName = '" + seriesName.Replace("'", "''") + "', ");
            stbEpisodes.Append("director = '" + episode.Director.Replace("'", "''") + "', ");
            stbEpisodes.Append("episodeName = '" + episode.Name.Replace("'", "''") + "', ");
            stbEpisodes.Append("episodeNumber = " + episode.EpisodeNumber + ", ");
            stbEpisodes.Append("firstAired = " + ToJulianDate(episode.FirstAired) + ", ");
            foreach (string guestStar in episode.GuestStars)
                guestStars = guestStars + guestStar + "|";
            stbEpisodes.Append("guestStars = '" + guestStars.Replace("'", "''") + "', ");
            stbEpisodes.Append("language = '" + episode.Language + "', ");
            stbEpisodes.Append("overview = '" + episode.Overview.Replace("'", "''") + "', ");
            stbEpisodes.Append("rating = " + episode.Rating + ", ");
            stbEpisodes.Append("ratingCount = " + episode.RatingCount + ", ");
            stbEpisodes.Append("season = " + episode.Season + ", ");
            foreach (string writer in episode.Writer)
                writers = writers + writer + "|";
            stbEpisodes.Append("writer = '" + writers.Replace("'", "''") + "', ");
            stbEpisodes.Append("absoluteNumber = " + episode.AbsoluteNumber + " ");
            stbEpisodes.Append("WHERE episodeID = " + episode.EpisodeID);
            if ((new SQLiteCommand(sqlUpdateEpisodes + stbEpisodes.ToString(), _dbConnection, _transaction)).ExecuteNonQuery() != 0)
                return;
            string sqlEpisodeInsert = "INSERT INTO episodeDetails (seriesID, episodeID, seriesName, director, episodeName, episodeNumber, firstAired, guestStars, language, overview, rating, ratingCount, season, writer, absoluteNumber, watched) VALUES(";
            StringBuilder stbEpisodeValues = new StringBuilder();
            stbEpisodeValues.Append(episode.SeriesID + ", ");
            stbEpisodeValues.Append(episode.EpisodeID + ", ");
            stbEpisodeValues.Append("'" + seriesName.Replace("'", "''") + "', ");
            stbEpisodeValues.Append("'" + episode.Director.Replace("'", "''") + "', ");
            stbEpisodeValues.Append("'" + episode.Name.Replace("'", "''") + "', ");
            stbEpisodeValues.Append(episode.EpisodeNumber + ", ");
            stbEpisodeValues.Append(ToJulianDate(episode.FirstAired) + ", ");
            stbEpisodeValues.Append("'" + guestStars.Replace("'", "''") + "', ");
            stbEpisodeValues.Append("'" + episode.Language + "', ");
            stbEpisodeValues.Append("'" + episode.Overview.Replace("'", "''") + "', ");
            stbEpisodeValues.Append(episode.Rating + ", ");
            stbEpisodeValues.Append(episode.RatingCount + ", ");
            stbEpisodeValues.Append(episode.Season + ", ");
            stbEpisodeValues.Append("'" + writers.Replace("'", "''") + "', ");
            stbEpisodeValues.Append(episode.AbsoluteNumber + ", ");
            if (episode.Watched)
                stbEpisodeValues.Append("1)");
            else
                stbEpisodeValues.Append("0)");
            (new SQLiteCommand(sqlEpisodeInsert + stbEpisodeValues.ToString(), _dbConnection, _transaction)).ExecuteNonQuery();
        }

        public void DeleteSeries(int seriesID)
        {
            string sqlFavourites = "DELETE FROM favourites WHERE seriesID = " + seriesID;
            string sqlEpisodes = "DELETE FROM episodeDetails WHERE seriesID = " + seriesID;
            (new SQLiteCommand(sqlFavourites, _dbConnection, _transaction)).ExecuteNonQuery();
            (new SQLiteCommand(sqlEpisodes, _dbConnection, _transaction)).ExecuteNonQuery();
        }
    }
}
