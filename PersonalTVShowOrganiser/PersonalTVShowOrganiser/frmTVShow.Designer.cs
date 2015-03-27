namespace PersonalTVShowOrganiser
{
    partial class frmTVShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTVShow));
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblOverview = new System.Windows.Forms.Label();
            this.dgvEpisodes = new System.Windows.Forms.DataGridView();
            this.lblFirstAired = new System.Windows.Forms.Label();
            this.lblAirDay = new System.Windows.Forms.Label();
            this.lblAirTime = new System.Windows.Forms.Label();
            this.lblRuntime = new System.Windows.Forms.Label();
            this.lblNetwork = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblFirstAiredText = new System.Windows.Forms.Label();
            this.lblAirDayText = new System.Windows.Forms.Label();
            this.lblAirTimeText = new System.Windows.Forms.Label();
            this.lblRuntimeText = new System.Windows.Forms.Label();
            this.lblNetworkText = new System.Windows.Forms.Label();
            this.lblGenreText = new System.Windows.Forms.Label();
            this.lblSeasons = new System.Windows.Forms.Label();
            this.cmbSeasons = new System.Windows.Forms.ComboBox();
            this.btnFavourite = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpisodes)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPoster
            // 
            this.pbPoster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPoster.Location = new System.Drawing.Point(639, 27);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(227, 325);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPoster.TabIndex = 0;
            this.pbPoster.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblName.Location = new System.Drawing.Point(12, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 30);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblOverview
            // 
            this.lblOverview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOverview.AutoSize = true;
            this.lblOverview.Location = new System.Drawing.Point(14, 61);
            this.lblOverview.MaximumSize = new System.Drawing.Size(600, 0);
            this.lblOverview.Name = "lblOverview";
            this.lblOverview.Size = new System.Drawing.Size(56, 15);
            this.lblOverview.TabIndex = 2;
            this.lblOverview.Text = "Overview";
            // 
            // dgvEpisodes
            // 
            this.dgvEpisodes.AllowUserToAddRows = false;
            this.dgvEpisodes.AllowUserToDeleteRows = false;
            this.dgvEpisodes.AllowUserToResizeColumns = false;
            this.dgvEpisodes.AllowUserToResizeRows = false;
            this.dgvEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEpisodes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvEpisodes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvEpisodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEpisodes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEpisodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEpisodes.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEpisodes.Location = new System.Drawing.Point(17, 229);
            this.dgvEpisodes.Name = "dgvEpisodes";
            this.dgvEpisodes.RowHeadersVisible = false;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvEpisodes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEpisodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEpisodes.Size = new System.Drawing.Size(601, 375);
            this.dgvEpisodes.TabIndex = 3;
            this.dgvEpisodes.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEpisodes_CellMouseDoubleClick);
            // 
            // lblFirstAired
            // 
            this.lblFirstAired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstAired.AutoSize = true;
            this.lblFirstAired.Location = new System.Drawing.Point(636, 359);
            this.lblFirstAired.Name = "lblFirstAired";
            this.lblFirstAired.Size = new System.Drawing.Size(63, 15);
            this.lblFirstAired.TabIndex = 4;
            this.lblFirstAired.Text = "First Aired:";
            // 
            // lblAirDay
            // 
            this.lblAirDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAirDay.AutoSize = true;
            this.lblAirDay.Location = new System.Drawing.Point(636, 376);
            this.lblAirDay.Name = "lblAirDay";
            this.lblAirDay.Size = new System.Drawing.Size(48, 15);
            this.lblAirDay.TabIndex = 5;
            this.lblAirDay.Text = "Air Day:";
            // 
            // lblAirTime
            // 
            this.lblAirTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAirTime.AutoSize = true;
            this.lblAirTime.Location = new System.Drawing.Point(636, 394);
            this.lblAirTime.Name = "lblAirTime";
            this.lblAirTime.Size = new System.Drawing.Size(55, 15);
            this.lblAirTime.TabIndex = 6;
            this.lblAirTime.Text = "Air Time:";
            // 
            // lblRuntime
            // 
            this.lblRuntime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRuntime.AutoSize = true;
            this.lblRuntime.Location = new System.Drawing.Point(636, 412);
            this.lblRuntime.Name = "lblRuntime";
            this.lblRuntime.Size = new System.Drawing.Size(55, 15);
            this.lblRuntime.TabIndex = 7;
            this.lblRuntime.Text = "Runtime:";
            // 
            // lblNetwork
            // 
            this.lblNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetwork.AutoSize = true;
            this.lblNetwork.Location = new System.Drawing.Point(636, 430);
            this.lblNetwork.Name = "lblNetwork";
            this.lblNetwork.Size = new System.Drawing.Size(55, 15);
            this.lblNetwork.TabIndex = 8;
            this.lblNetwork.Text = "Network:";
            // 
            // lblGenre
            // 
            this.lblGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(636, 448);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(41, 15);
            this.lblGenre.TabIndex = 9;
            this.lblGenre.Text = "Genre:";
            // 
            // lblFirstAiredText
            // 
            this.lblFirstAiredText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFirstAiredText.AutoSize = true;
            this.lblFirstAiredText.Location = new System.Drawing.Point(758, 359);
            this.lblFirstAiredText.Name = "lblFirstAiredText";
            this.lblFirstAiredText.Size = new System.Drawing.Size(31, 15);
            this.lblFirstAiredText.TabIndex = 10;
            this.lblFirstAiredText.Text = "Date";
            // 
            // lblAirDayText
            // 
            this.lblAirDayText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAirDayText.AutoSize = true;
            this.lblAirDayText.Location = new System.Drawing.Point(758, 376);
            this.lblAirDayText.Name = "lblAirDayText";
            this.lblAirDayText.Size = new System.Drawing.Size(27, 15);
            this.lblAirDayText.TabIndex = 11;
            this.lblAirDayText.Text = "Day";
            // 
            // lblAirTimeText
            // 
            this.lblAirTimeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAirTimeText.AutoSize = true;
            this.lblAirTimeText.Location = new System.Drawing.Point(758, 394);
            this.lblAirTimeText.Name = "lblAirTimeText";
            this.lblAirTimeText.Size = new System.Drawing.Size(34, 15);
            this.lblAirTimeText.TabIndex = 12;
            this.lblAirTimeText.Text = "Time";
            // 
            // lblRuntimeText
            // 
            this.lblRuntimeText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRuntimeText.AutoSize = true;
            this.lblRuntimeText.Location = new System.Drawing.Point(758, 412);
            this.lblRuntimeText.Name = "lblRuntimeText";
            this.lblRuntimeText.Size = new System.Drawing.Size(34, 15);
            this.lblRuntimeText.TabIndex = 13;
            this.lblRuntimeText.Text = "Time";
            // 
            // lblNetworkText
            // 
            this.lblNetworkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetworkText.AutoSize = true;
            this.lblNetworkText.Location = new System.Drawing.Point(758, 430);
            this.lblNetworkText.Name = "lblNetworkText";
            this.lblNetworkText.Size = new System.Drawing.Size(52, 15);
            this.lblNetworkText.TabIndex = 14;
            this.lblNetworkText.Text = "Network";
            // 
            // lblGenreText
            // 
            this.lblGenreText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGenreText.AutoSize = true;
            this.lblGenreText.Location = new System.Drawing.Point(758, 448);
            this.lblGenreText.Name = "lblGenreText";
            this.lblGenreText.Size = new System.Drawing.Size(38, 15);
            this.lblGenreText.TabIndex = 15;
            this.lblGenreText.Text = "Genre";
            // 
            // lblSeasons
            // 
            this.lblSeasons.AutoSize = true;
            this.lblSeasons.Location = new System.Drawing.Point(15, 206);
            this.lblSeasons.Name = "lblSeasons";
            this.lblSeasons.Size = new System.Drawing.Size(49, 15);
            this.lblSeasons.TabIndex = 16;
            this.lblSeasons.Text = "Seasons";
            // 
            // cmbSeasons
            // 
            this.cmbSeasons.FormattingEnabled = true;
            this.cmbSeasons.Location = new System.Drawing.Point(72, 204);
            this.cmbSeasons.Name = "cmbSeasons";
            this.cmbSeasons.Size = new System.Drawing.Size(92, 23);
            this.cmbSeasons.TabIndex = 17;
            // 
            // btnFavourite
            // 
            this.btnFavourite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFavourite.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnFavourite.FlatAppearance.BorderSize = 0;
            this.btnFavourite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnFavourite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnFavourite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavourite.ImageIndex = 1;
            this.btnFavourite.ImageList = this.imageList1;
            this.btnFavourite.Location = new System.Drawing.Point(560, 27);
            this.btnFavourite.Name = "btnFavourite";
            this.btnFavourite.Size = new System.Drawing.Size(37, 36);
            this.btnFavourite.TabIndex = 18;
            this.btnFavourite.UseVisualStyleBackColor = true;
            this.btnFavourite.Click += new System.EventHandler(this.btnFavourite_Click);
            this.btnFavourite.MouseEnter += new System.EventHandler(this.btnFavourite_MouseEnter);
            this.btnFavourite.MouseLeave += new System.EventHandler(this.btnFavourite_MouseLeave);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "favourite_star.ico");
            this.imageList1.Images.SetKeyName(1, "unfavourite_star.ico");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(870, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFile
            // 
            this.btnFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave});
            this.btnFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFile.Image = ((System.Drawing.Image)(resources.GetObject("btnFile.Image")));
            this.btnFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(38, 22);
            this.btnFile.Text = "File";
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 22);
            this.btnSave.Text = "Save";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelectAll.Location = new System.Drawing.Point(387, 201);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 20;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConfirm.Location = new System.Drawing.Point(544, 201);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 21;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeselectAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeselectAll.Location = new System.Drawing.Point(463, 201);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(80, 23);
            this.btnDeselectAll.TabIndex = 22;
            this.btnDeselectAll.Text = "Deselect All";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // frmTVShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(870, 616);
            this.Controls.Add(this.btnDeselectAll);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnFavourite);
            this.Controls.Add(this.cmbSeasons);
            this.Controls.Add(this.lblSeasons);
            this.Controls.Add(this.lblGenreText);
            this.Controls.Add(this.lblNetworkText);
            this.Controls.Add(this.lblRuntimeText);
            this.Controls.Add(this.lblAirTimeText);
            this.Controls.Add(this.lblAirDayText);
            this.Controls.Add(this.lblFirstAiredText);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblNetwork);
            this.Controls.Add(this.lblRuntime);
            this.Controls.Add(this.lblAirTime);
            this.Controls.Add(this.lblAirDay);
            this.Controls.Add(this.lblFirstAired);
            this.Controls.Add(this.dgvEpisodes);
            this.Controls.Add(this.lblOverview);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbPoster);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTVShow";
            this.Text = "frmTVShow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTVShow_Load);
            this.Resize += new System.EventHandler(this.frmTVShow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEpisodes)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPoster;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblOverview;
        private System.Windows.Forms.DataGridView dgvEpisodes;
        private System.Windows.Forms.Label lblFirstAired;
        private System.Windows.Forms.Label lblAirDay;
        private System.Windows.Forms.Label lblAirTime;
        private System.Windows.Forms.Label lblRuntime;
        private System.Windows.Forms.Label lblNetwork;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblFirstAiredText;
        private System.Windows.Forms.Label lblAirDayText;
        private System.Windows.Forms.Label lblAirTimeText;
        private System.Windows.Forms.Label lblRuntimeText;
        private System.Windows.Forms.Label lblNetworkText;
        private System.Windows.Forms.Label lblGenreText;
        private System.Windows.Forms.Label lblSeasons;
        private System.Windows.Forms.ComboBox cmbSeasons;
        private System.Windows.Forms.Button btnFavourite;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnFile;
        private System.Windows.Forms.ToolStripMenuItem btnSave;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}