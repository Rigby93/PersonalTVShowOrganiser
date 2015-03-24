namespace PersonalTVShowOrganiser
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblTVTracker = new System.Windows.Forms.Label();
            this.btnFavourites = new System.Windows.Forms.Button();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.dgvMissedEpisodes = new System.Windows.Forms.DataGridView();
            this.lblMissedEpisodes = new System.Windows.Forms.Label();
            this.lblUpcomingEpisodes = new System.Windows.Forms.Label();
            this.dgvUpcomingEpisodes = new System.Windows.Forms.DataGridView();
            this.tabScreens = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.btnViewUpcoming = new System.Windows.Forms.Button();
            this.btnViewMissed = new System.Windows.Forms.Button();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.dgvSearchResults = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.prgMain = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.bgwUpdate = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissedEpisodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcomingEpisodes)).BeginInit();
            this.tabScreens.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.cmsNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1336, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFile
            // 
            this.btnFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFile.Image = ((System.Drawing.Image)(resources.GetObject("btnFile.Image")));
            this.btnFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(38, 22);
            this.btnFile.Text = "File";
            // 
            // lblTVTracker
            // 
            this.lblTVTracker.AutoSize = true;
            this.lblTVTracker.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTVTracker.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblTVTracker.Location = new System.Drawing.Point(32, 22);
            this.lblTVTracker.Name = "lblTVTracker";
            this.lblTVTracker.Size = new System.Drawing.Size(356, 86);
            this.lblTVTracker.TabIndex = 1;
            this.lblTVTracker.Text = "TV Tracker";
            // 
            // btnFavourites
            // 
            this.btnFavourites.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnFavourites.FlatAppearance.BorderSize = 0;
            this.btnFavourites.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnFavourites.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnFavourites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavourites.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFavourites.Location = new System.Drawing.Point(45, 128);
            this.btnFavourites.Name = "btnFavourites";
            this.btnFavourites.Size = new System.Drawing.Size(170, 41);
            this.btnFavourites.TabIndex = 2;
            this.btnFavourites.Text = "FAVOURITES";
            this.btnFavourites.UseVisualStyleBackColor = true;
            this.btnFavourites.Click += new System.EventHandler(this.btnFavourites_Click);
            this.btnFavourites.MouseEnter += new System.EventHandler(this.btnFavourites_MouseEnter);
            this.btnFavourites.MouseLeave += new System.EventHandler(this.btnFavourites_MouseLeave);
            // 
            // btnCalendar
            // 
            this.btnCalendar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCalendar.FlatAppearance.BorderSize = 0;
            this.btnCalendar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCalendar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnCalendar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalendar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalendar.Location = new System.Drawing.Point(45, 175);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(170, 41);
            this.btnCalendar.TabIndex = 3;
            this.btnCalendar.Text = "CALENDAR";
            this.btnCalendar.UseVisualStyleBackColor = true;
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            this.btnCalendar.MouseEnter += new System.EventHandler(this.btnCalendar_MouseEnter);
            this.btnCalendar.MouseLeave += new System.EventHandler(this.btnCalendar_MouseLeave);
            // 
            // dgvMissedEpisodes
            // 
            this.dgvMissedEpisodes.AllowUserToAddRows = false;
            this.dgvMissedEpisodes.AllowUserToDeleteRows = false;
            this.dgvMissedEpisodes.AllowUserToResizeColumns = false;
            this.dgvMissedEpisodes.AllowUserToResizeRows = false;
            this.dgvMissedEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMissedEpisodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMissedEpisodes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvMissedEpisodes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvMissedEpisodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMissedEpisodes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMissedEpisodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMissedEpisodes.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMissedEpisodes.Location = new System.Drawing.Point(712, 53);
            this.dgvMissedEpisodes.MultiSelect = false;
            this.dgvMissedEpisodes.Name = "dgvMissedEpisodes";
            this.dgvMissedEpisodes.ReadOnly = true;
            this.dgvMissedEpisodes.RowHeadersVisible = false;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvMissedEpisodes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMissedEpisodes.RowTemplate.Height = 28;
            this.dgvMissedEpisodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMissedEpisodes.Size = new System.Drawing.Size(592, 349);
            this.dgvMissedEpisodes.TabIndex = 4;
            // 
            // lblMissedEpisodes
            // 
            this.lblMissedEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMissedEpisodes.AutoSize = true;
            this.lblMissedEpisodes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMissedEpisodes.ForeColor = System.Drawing.Color.White;
            this.lblMissedEpisodes.Location = new System.Drawing.Point(708, 22);
            this.lblMissedEpisodes.Name = "lblMissedEpisodes";
            this.lblMissedEpisodes.Size = new System.Drawing.Size(124, 21);
            this.lblMissedEpisodes.TabIndex = 5;
            this.lblMissedEpisodes.Text = "Missed Episodes";
            // 
            // lblUpcomingEpisodes
            // 
            this.lblUpcomingEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpcomingEpisodes.AutoSize = true;
            this.lblUpcomingEpisodes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingEpisodes.ForeColor = System.Drawing.Color.White;
            this.lblUpcomingEpisodes.Location = new System.Drawing.Point(708, 450);
            this.lblUpcomingEpisodes.Name = "lblUpcomingEpisodes";
            this.lblUpcomingEpisodes.Size = new System.Drawing.Size(147, 21);
            this.lblUpcomingEpisodes.TabIndex = 7;
            this.lblUpcomingEpisodes.Text = "Upcoming Episodes";
            // 
            // dgvUpcomingEpisodes
            // 
            this.dgvUpcomingEpisodes.AllowUserToAddRows = false;
            this.dgvUpcomingEpisodes.AllowUserToDeleteRows = false;
            this.dgvUpcomingEpisodes.AllowUserToResizeColumns = false;
            this.dgvUpcomingEpisodes.AllowUserToResizeRows = false;
            this.dgvUpcomingEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUpcomingEpisodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpcomingEpisodes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvUpcomingEpisodes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvUpcomingEpisodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUpcomingEpisodes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUpcomingEpisodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUpcomingEpisodes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUpcomingEpisodes.Location = new System.Drawing.Point(712, 481);
            this.dgvUpcomingEpisodes.MultiSelect = false;
            this.dgvUpcomingEpisodes.Name = "dgvUpcomingEpisodes";
            this.dgvUpcomingEpisodes.ReadOnly = true;
            this.dgvUpcomingEpisodes.RowHeadersVisible = false;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvUpcomingEpisodes.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUpcomingEpisodes.RowTemplate.Height = 28;
            this.dgvUpcomingEpisodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUpcomingEpisodes.Size = new System.Drawing.Size(592, 349);
            this.dgvUpcomingEpisodes.TabIndex = 6;
            // 
            // tabScreens
            // 
            this.tabScreens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabScreens.Controls.Add(this.tabHome);
            this.tabScreens.Controls.Add(this.tabResults);
            this.tabScreens.Location = new System.Drawing.Point(0, 35);
            this.tabScreens.Name = "tabScreens";
            this.tabScreens.SelectedIndex = 0;
            this.tabScreens.Size = new System.Drawing.Size(2014, 907);
            this.tabScreens.TabIndex = 8;
            // 
            // tabHome
            // 
            this.tabHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabHome.Controls.Add(this.btnViewUpcoming);
            this.tabHome.Controls.Add(this.btnViewMissed);
            this.tabHome.Controls.Add(this.lblTVTracker);
            this.tabHome.Controls.Add(this.lblUpcomingEpisodes);
            this.tabHome.Controls.Add(this.btnFavourites);
            this.tabHome.Controls.Add(this.dgvUpcomingEpisodes);
            this.tabHome.Controls.Add(this.btnCalendar);
            this.tabHome.Controls.Add(this.lblMissedEpisodes);
            this.tabHome.Controls.Add(this.dgvMissedEpisodes);
            this.tabHome.Location = new System.Drawing.Point(4, 24);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(2006, 879);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            // 
            // btnViewUpcoming
            // 
            this.btnViewUpcoming.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewUpcoming.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnViewUpcoming.FlatAppearance.BorderSize = 0;
            this.btnViewUpcoming.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnViewUpcoming.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnViewUpcoming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewUpcoming.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewUpcoming.Location = new System.Drawing.Point(861, 450);
            this.btnViewUpcoming.Name = "btnViewUpcoming";
            this.btnViewUpcoming.Size = new System.Drawing.Size(57, 23);
            this.btnViewUpcoming.TabIndex = 9;
            this.btnViewUpcoming.Text = "View All";
            this.btnViewUpcoming.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewUpcoming.UseVisualStyleBackColor = true;
            this.btnViewUpcoming.Click += new System.EventHandler(this.btnViewUpcoming_Click);
            this.btnViewUpcoming.MouseEnter += new System.EventHandler(this.btnViewUpcoming_MouseEnter);
            this.btnViewUpcoming.MouseLeave += new System.EventHandler(this.btnViewUpcoming_MouseLeave);
            // 
            // btnViewMissed
            // 
            this.btnViewMissed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewMissed.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnViewMissed.FlatAppearance.BorderSize = 0;
            this.btnViewMissed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnViewMissed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnViewMissed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewMissed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewMissed.Location = new System.Drawing.Point(838, 22);
            this.btnViewMissed.Name = "btnViewMissed";
            this.btnViewMissed.Size = new System.Drawing.Size(57, 23);
            this.btnViewMissed.TabIndex = 8;
            this.btnViewMissed.Text = "View All";
            this.btnViewMissed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewMissed.UseVisualStyleBackColor = true;
            this.btnViewMissed.MouseEnter += new System.EventHandler(this.btnViewMissed_MouseEnter);
            this.btnViewMissed.MouseLeave += new System.EventHandler(this.btnViewMissed_MouseLeave);
            // 
            // tabResults
            // 
            this.tabResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabResults.Controls.Add(this.dgvSearchResults);
            this.tabResults.Location = new System.Drawing.Point(4, 24);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabResults.Size = new System.Drawing.Size(2006, 879);
            this.tabResults.TabIndex = 1;
            this.tabResults.Text = "Search Results";
            // 
            // dgvSearchResults
            // 
            this.dgvSearchResults.AllowUserToAddRows = false;
            this.dgvSearchResults.AllowUserToDeleteRows = false;
            this.dgvSearchResults.AllowUserToResizeColumns = false;
            this.dgvSearchResults.AllowUserToResizeRows = false;
            this.dgvSearchResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSearchResults.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvSearchResults.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvSearchResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSearchResults.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSearchResults.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSearchResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSearchResults.Location = new System.Drawing.Point(3, 3);
            this.dgvSearchResults.MultiSelect = false;
            this.dgvSearchResults.Name = "dgvSearchResults";
            this.dgvSearchResults.ReadOnly = true;
            this.dgvSearchResults.RowHeadersVisible = false;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvSearchResults.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSearchResults.RowTemplate.Height = 28;
            this.dgvSearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchResults.Size = new System.Drawing.Size(2000, 873);
            this.dgvSearchResults.TabIndex = 0;
            this.dgvSearchResults.Visible = false;
            this.dgvSearchResults.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSearchResults_CellMouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prgMain,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 932);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1336, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // prgMain
            // 
            this.prgMain.Name = "prgMain";
            this.prgMain.Size = new System.Drawing.Size(175, 16);
            this.prgMain.Step = 1;
            this.prgMain.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.Location = new System.Drawing.Point(1250, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(1088, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(157, 23);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // bgwUpdate
            // 
            this.bgwUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUpdate_DoWork);
            this.bgwUpdate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwUpdate_ProgressChanged);
            this.bgwUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwUpdate_RunWorkerCompleted);
            // 
            // timer
            // 
            this.timer.Interval = 900000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "TV Tracker is still running";
            this.notifyIcon.BalloonTipTitle = "TV Tracker";
            this.notifyIcon.ContextMenuStrip = this.cmsNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "TV Tracker";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // cmsNotifyIcon
            // 
            this.cmsNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUpdate,
            this.toolStripSeparator1,
            this.mnuExit});
            this.cmsNotifyIcon.Name = "cmsNotifyIcon";
            this.cmsNotifyIcon.Size = new System.Drawing.Size(168, 54);
            // 
            // mnuUpdate
            // 
            this.mnuUpdate.Name = "mnuUpdate";
            this.mnuUpdate.Size = new System.Drawing.Size(167, 22);
            this.mnuUpdate.Text = "Update favourites";
            this.mnuUpdate.Click += new System.EventHandler(this.mnuUpdate_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(167, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1336, 954);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabScreens);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "TV Tracker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissedEpisodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpcomingEpisodes)).EndInit();
            this.tabScreens.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.tabHome.PerformLayout();
            this.tabResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cmsNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnFile;
        private System.Windows.Forms.Label lblTVTracker;
        private System.Windows.Forms.Button btnFavourites;
        private System.Windows.Forms.Button btnCalendar;
        private System.Windows.Forms.DataGridView dgvMissedEpisodes;
        private System.Windows.Forms.Label lblMissedEpisodes;
        private System.Windows.Forms.Label lblUpcomingEpisodes;
        private System.Windows.Forms.DataGridView dgvUpcomingEpisodes;
        private System.Windows.Forms.TabControl tabScreens;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar prgMain;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnViewUpcoming;
        private System.Windows.Forms.Button btnViewMissed;
        private System.Windows.Forms.DataGridView dgvSearchResults;
        private System.ComponentModel.BackgroundWorker bgwUpdate;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cmsNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem mnuUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
    }
}

