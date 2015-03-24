using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVShowObjects
{
    public class Episode
    {
        private string seriesName = "";
        private string director = "";
        private string episodeName = "";
        private string language = "";
        private string overview = "";
        private int seriesID;
        private int episodeID;
        private int episodeNumber;
        private DateTime firstAired;
        private List<string> guestStars;
        private double rating;
        private int ratingCount;
        private int runtime;
        private int season;
        private DateTime timeAirs;
        private List<string> writer;
        private int absoluteNumber;
        private bool watched;

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

        public int EpisodeID
        {
            get
            {
                return this.episodeID;
            }
            set
            {
                this.episodeID = value;
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

        public string Director
        {
            get
            {
                return this.director;
            }
            set
            {
                this.director = value;
            }
        }

        public string Name
        {
            get
            {
                return this.episodeName;
            }
            set
            {
                this.episodeName = value;
            }
        }

        public int EpisodeNumber
        {
            get
            {
                return this.episodeNumber;
            }
            set
            {
                this.episodeNumber = value;
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

        public List<string> GuestStars
        {
            get
            {
                return this.guestStars;
            }
            set
            {
                this.guestStars = value;
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

        public int Season
        {
            get
            {
                return this.season;
            }
            set
            {
                this.season = value;
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

        public List<string> Writer
        {
            get
            {
                return this.writer;
            }
            set
            {
                this.writer = value;
            }
        }

        public int AbsoluteNumber
        {
            get
            {
                return this.absoluteNumber;
            }
            set
            {
                this.absoluteNumber = value;
            }
        }

        public bool Watched
        {
            get
            {
                return this.watched;
            }
            set
            {
                this.watched = value;
            }
        }

        public override string ToString()
        {
            return this.seriesName + " - S" + this.season.ToString() + "E" + this.episodeNumber.ToString() + " - " + this.episodeName;
        }
    }
}
