using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVShowObjects
{
    public class Update
    {
        private string time = "";
        private List<int> seriesUpdates;
        private List<int> episodeUpdates;

        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }

        public List<int> SeriesUpdates
        {
            get
            {
                return this.seriesUpdates;
            }
            set
            {
                this.seriesUpdates = value;
            }
        }

        public List<int> EpisodeUpdates
        {
            get
            {
                return this.episodeUpdates;
            }
            set
            {
                this.episodeUpdates = value;
            }
        }
    }
}
