using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVShowObjects
{
    public class Series
    {
        private string dayOfWeekAirs = "";
        private string contentRating = "";
        private string imdbID = "";
        private string language = "";
        private string network = "";
        private string overview = "";
        private string seriesName = "";
        private string status = "";
        private string banner = "";
        private string fanart = "";
        private string poster = "";
        private int seriesID;
        private List<string> actors;
        private DateTime timeAirs;
        private DateTime firstAired;
        private List<string> genre;
        private double rating;
        private int ratingCount;
        private int runtime;
        private Dictionary<int, Episode> episodes;

        public int SeriesID
        {
            get
            {
                return this.seriesID;
            }
            set
            {
                this.seriesID = value;
            }
        }

        public List<string> Actors
        {
            get
            {
                return this.actors;
            }
            set
            {
                this.actors = value;
            }
        }

        public string DayOfWeekAirs
        {
            get
            {
                return this.dayOfWeekAirs;
            }
            set
            {
                this.dayOfWeekAirs = value;
            }
        }

        public DateTime TimeAirs
        {
            get
            {
                return this.timeAirs;
            }
            set
            {
                this.timeAirs = value;
            }
        }

        public string ContentRating
        {
            get
            {
                return this.contentRating;
            }
            set
            {
                this.contentRating = value;
            }
        }

        public DateTime FirstAired
        {
            get
            {
                return this.firstAired;
            }
            set
            {
                this.firstAired = value;
            }
        }

        public List<string> Genre
        {
            get
            {
                return this.genre;
            }
            set
            {
                this.genre = value;
            }
        }

        public string IMDB_ID
        {
            get
            {
                return this.imdbID;
            }
            set
            {
                this.imdbID = value;
            }
        }

        public string Language
        {
            get
            {
                return this.language;
            }
            set
            {
                this.language = value;
            }
        }

        public string Network
        {
            get
            {
                return this.network;
            }
            set
            {
                this.network = value;
            }
        }

        public string Overview
        {
            get
            {
                return this.overview;
            }
            set
            {
                this.overview = value;
            }
        }

        public double Rating
        {
            get
            {
                return this.rating;
            }
            set
            {
                this.rating = value;
            }
        }

        public int RatingCount
        {
            get
            {
                return this.ratingCount;
            }
            set
            {
                this.ratingCount = value;
            }
        }

        public int Runtime
        {
            get
            {
                return this.runtime;
            }
            set
            {
                this.runtime = value;
            }
        }

        public string SeriesName
        {
            get
            {
                return this.seriesName;
            }
            set
            {
                this.seriesName = value;
            }
        }

        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
            }
        }

        public string Banner
        {
            get
            {
                return this.banner;
            }
            set
            {
                this.banner = value;
            }
        }

        public string Fanart
        {
            get
            {
                return this.fanart;
            }
            set
            {
                this.fanart = value;
            }
        }

        public string Poster
        {
            get
            {
                return this.poster;
            }
            set
            {
                this.poster = value;
            }
        }

        public Dictionary<int, Episode> Episodes
        {
            get
            {
                return this.episodes;
            }
            set
            {
                this.episodes = value;
            }
        }
    }
}
