using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PosterButton
{
    public partial class PosterButton: UserControl
    {
        private string _poster = "";
        private string _seriesName = "";
        private int _seriesID;

        public int SeriesID
        {
            get
            {
                return this._seriesID;
            }
            set
            {
                this._seriesID = value;
            }
        }

        public string Poster
        {
            get
            {
                return this._poster;
            }
            set
            {
                this._poster = value;
                if (this._poster.Length <= 0)
                    return;
                this.pbPoster.Image = new Bitmap(this._poster);
            }
        }

        public string SeriesName
        {
            get
            {
                return this._seriesName;
            }
            set
            {
                this._seriesName = value;
                this.lblSeriesName.Text = this._seriesName;
            }
        }

        public event EventHandler ButtonClick;

        public PosterButton()
        {
            InitializeComponent();
        }

        private void pbPoster_Click(object sender, EventArgs e)
        {
            if (ButtonClick == null)
                return;
            ButtonClick(this, e);
        }

        private void lblSeriesName_Click(object sender, EventArgs e)
        {
            if (ButtonClick == null)
                return;
            ButtonClick(this, e);
        }
    }
}
