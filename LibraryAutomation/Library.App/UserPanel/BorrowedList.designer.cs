
namespace Library.App.UserPanel
{
    partial class BorrowedList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorrowedList));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.lblClock = new System.Windows.Forms.Label();
            this.gcBorrowedList = new DevExpress.XtraGrid.GridControl();
            this.gvBorrowedList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbBorrowedList = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ratingControl = new DevExpress.XtraEditors.RatingControl();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSeeComment = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddComment = new DevExpress.XtraEditors.SimpleButton();
            this.lblNumberOfFavorites = new System.Windows.Forms.Label();
            this.txtPublisher = new DevExpress.XtraEditors.TextEdit();
            this.txtWriter = new DevExpress.XtraEditors.TextEdit();
            this.lblNumberOfComment = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblFavorite = new System.Windows.Forms.Label();
            this.lblNumberOfReads = new System.Windows.Forms.Label();
            this.lblRead = new System.Windows.Forms.Label();
            this.txtShelfNumber = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReleaseDate = new DevExpress.XtraEditors.DateEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPageNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.writerlbl = new System.Windows.Forms.Label();
            this.txtAbout = new DevExpress.XtraEditors.MemoEdit();
            this.panelBottom.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBorrowedList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBorrowedList)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbBorrowedList.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPublisher.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWriter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShelfNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReleaseDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReleaseDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbout.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMessage.Location = new System.Drawing.Point(752, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 18);
            this.lblMessage.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblMessage);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 582);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(752, 52);
            this.panelBottom.TabIndex = 100;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.lblClock);
            this.panelGrid.Controls.Add(this.panelBottom);
            this.panelGrid.Controls.Add(this.gcBorrowedList);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelGrid.Location = new System.Drawing.Point(0, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(752, 634);
            this.panelGrid.TabIndex = 99;
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblClock.Location = new System.Drawing.Point(537, 15);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(183, 18);
            this.lblClock.TabIndex = 18;
            this.lblClock.Text = "29 Aralık 2020 24:24:24";
            // 
            // gcBorrowedList
            // 
            this.gcBorrowedList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcBorrowedList.Location = new System.Drawing.Point(30, 52);
            this.gcBorrowedList.MainView = this.gvBorrowedList;
            this.gcBorrowedList.Name = "gcBorrowedList";
            this.gcBorrowedList.Size = new System.Drawing.Size(690, 518);
            this.gcBorrowedList.TabIndex = 86;
            this.gcBorrowedList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBorrowedList});
            // 
            // gvBorrowedList
            // 
            this.gvBorrowedList.Appearance.Empty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gvBorrowedList.Appearance.Empty.Options.UseBackColor = true;
            this.gvBorrowedList.Appearance.EvenRow.BackColor = System.Drawing.Color.PaleTurquoise;
            this.gvBorrowedList.Appearance.EvenRow.BackColor2 = System.Drawing.Color.Thistle;
            this.gvBorrowedList.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvBorrowedList.Appearance.FocusedRow.BackColor = System.Drawing.Color.Linen;
            this.gvBorrowedList.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.SeaShell;
            this.gvBorrowedList.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvBorrowedList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvBorrowedList.Appearance.FocusedRow.Options.UseFont = true;
            this.gvBorrowedList.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gvBorrowedList.Appearance.OddRow.BackColor2 = System.Drawing.Color.Thistle;
            this.gvBorrowedList.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvBorrowedList.Appearance.OddRow.Options.UseBackColor = true;
            this.gvBorrowedList.Appearance.OddRow.Options.UseFont = true;
            this.gvBorrowedList.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvBorrowedList.Appearance.Row.Options.UseFont = true;
            this.gvBorrowedList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvBorrowedList.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvBorrowedList.GridControl = this.gcBorrowedList;
            this.gvBorrowedList.Name = "gvBorrowedList";
            this.gvBorrowedList.OptionsBehavior.Editable = false;
            this.gvBorrowedList.OptionsBehavior.ReadOnly = true;
            this.gvBorrowedList.OptionsCustomization.AllowFilter = false;
            this.gvBorrowedList.OptionsFind.AllowFindPanel = false;
            this.gvBorrowedList.OptionsMenu.EnableColumnMenu = false;
            this.gvBorrowedList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvBorrowedList.OptionsView.EnableAppearanceEvenRow = true;
            this.gvBorrowedList.OptionsView.EnableAppearanceOddRow = true;
            this.gvBorrowedList.OptionsView.ShowGroupPanel = false;
            this.gvBorrowedList.OptionsView.ShowIndicator = false;
            this.gvBorrowedList.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvBorrowedList.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvBorrowedList_RowCellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbBorrowedList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(752, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 634);
            this.panel1.TabIndex = 100;
            // 
            // gbBorrowedList
            // 
            this.gbBorrowedList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBorrowedList.Controls.Add(this.panel3);
            this.gbBorrowedList.Controls.Add(this.lblNumberOfFavorites);
            this.gbBorrowedList.Controls.Add(this.txtPublisher);
            this.gbBorrowedList.Controls.Add(this.txtWriter);
            this.gbBorrowedList.Controls.Add(this.lblNumberOfComment);
            this.gbBorrowedList.Controls.Add(this.lblComment);
            this.gbBorrowedList.Controls.Add(this.lblFavorite);
            this.gbBorrowedList.Controls.Add(this.lblNumberOfReads);
            this.gbBorrowedList.Controls.Add(this.lblRead);
            this.gbBorrowedList.Controls.Add(this.txtShelfNumber);
            this.gbBorrowedList.Controls.Add(this.label3);
            this.gbBorrowedList.Controls.Add(this.txtReleaseDate);
            this.gbBorrowedList.Controls.Add(this.label15);
            this.gbBorrowedList.Controls.Add(this.txtPageNumber);
            this.gbBorrowedList.Controls.Add(this.txtName);
            this.gbBorrowedList.Controls.Add(this.label5);
            this.gbBorrowedList.Controls.Add(this.label16);
            this.gbBorrowedList.Controls.Add(this.label6);
            this.gbBorrowedList.Controls.Add(this.label14);
            this.gbBorrowedList.Controls.Add(this.writerlbl);
            this.gbBorrowedList.Controls.Add(this.txtAbout);
            this.gbBorrowedList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gbBorrowedList.Location = new System.Drawing.Point(6, 15);
            this.gbBorrowedList.Name = "gbBorrowedList";
            this.gbBorrowedList.Size = new System.Drawing.Size(688, 568);
            this.gbBorrowedList.TabIndex = 140;
            this.gbBorrowedList.TabStop = false;
            this.gbBorrowedList.Text = "Ödünç Alınan Kitap Bilgisi";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.ratingControl);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnSeeComment);
            this.panel3.Controls.Add(this.btnAddComment);
            this.panel3.Location = new System.Drawing.Point(423, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 354);
            this.panel3.TabIndex = 135;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 213);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // ratingControl
            // 
            this.ratingControl.Enabled = false;
            this.ratingControl.Location = new System.Drawing.Point(118, 228);
            this.ratingControl.Name = "ratingControl";
            this.ratingControl.Rating = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ratingControl.Size = new System.Drawing.Size(92, 16);
            this.ratingControl.TabIndex = 133;
            this.ratingControl.Text = "ratingControl1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(33, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 111;
            this.label2.Text = "Puan:";
            // 
            // btnSeeComment
            // 
            this.btnSeeComment.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSeeComment.Appearance.Options.UseFont = true;
            this.btnSeeComment.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSeeComment.ImageOptions.Image")));
            this.btnSeeComment.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnSeeComment.Location = new System.Drawing.Point(12, 307);
            this.btnSeeComment.Name = "btnSeeComment";
            this.btnSeeComment.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSeeComment.Size = new System.Drawing.Size(221, 33);
            this.btnSeeComment.TabIndex = 132;
            this.btnSeeComment.Text = "Yorumları Gör";
            this.btnSeeComment.Click += new System.EventHandler(this.btnSeeComment_Click);
            // 
            // btnAddComment
            // 
            this.btnAddComment.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAddComment.Appearance.Options.UseFont = true;
            this.btnAddComment.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddComment.ImageOptions.Image")));
            this.btnAddComment.Location = new System.Drawing.Point(12, 268);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnAddComment.Size = new System.Drawing.Size(221, 33);
            this.btnAddComment.TabIndex = 119;
            this.btnAddComment.Text = "Yorum Ekle";
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // lblNumberOfFavorites
            // 
            this.lblNumberOfFavorites.AutoSize = true;
            this.lblNumberOfFavorites.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblNumberOfFavorites.Location = new System.Drawing.Point(244, 373);
            this.lblNumberOfFavorites.Name = "lblNumberOfFavorites";
            this.lblNumberOfFavorites.Size = new System.Drawing.Size(0, 17);
            this.lblNumberOfFavorites.TabIndex = 134;
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(166, 119);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Properties.AllowFocused = false;
            this.txtPublisher.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPublisher.Properties.NullValuePrompt = "Adı";
            this.txtPublisher.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtPublisher.Size = new System.Drawing.Size(204, 22);
            this.txtPublisher.TabIndex = 121;
            // 
            // txtWriter
            // 
            this.txtWriter.Location = new System.Drawing.Point(167, 76);
            this.txtWriter.Name = "txtWriter";
            this.txtWriter.Properties.AllowFocused = false;
            this.txtWriter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtWriter.Properties.NullValuePrompt = "Adı";
            this.txtWriter.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtWriter.Size = new System.Drawing.Size(204, 22);
            this.txtWriter.TabIndex = 120;
            // 
            // lblNumberOfComment
            // 
            this.lblNumberOfComment.AutoSize = true;
            this.lblNumberOfComment.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblNumberOfComment.Location = new System.Drawing.Point(145, 291);
            this.lblNumberOfComment.Name = "lblNumberOfComment";
            this.lblNumberOfComment.Size = new System.Drawing.Size(0, 17);
            this.lblNumberOfComment.TabIndex = 118;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.lblComment.ForeColor = System.Drawing.Color.DarkRed;
            this.lblComment.Location = new System.Drawing.Point(33, 291);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(112, 17);
            this.lblComment.TabIndex = 117;
            this.lblComment.Text = "Yorum Sayısı: ";
            // 
            // lblFavorite
            // 
            this.lblFavorite.AutoSize = true;
            this.lblFavorite.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.lblFavorite.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFavorite.Location = new System.Drawing.Point(33, 372);
            this.lblFavorite.Name = "lblFavorite";
            this.lblFavorite.Size = new System.Drawing.Size(205, 17);
            this.lblFavorite.TabIndex = 115;
            this.lblFavorite.Text = "Favorilere Eklenme Sayısı: ";
            // 
            // lblNumberOfReads
            // 
            this.lblNumberOfReads.AutoSize = true;
            this.lblNumberOfReads.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblNumberOfReads.Location = new System.Drawing.Point(164, 330);
            this.lblNumberOfReads.Name = "lblNumberOfReads";
            this.lblNumberOfReads.Size = new System.Drawing.Size(0, 17);
            this.lblNumberOfReads.TabIndex = 114;
            // 
            // lblRead
            // 
            this.lblRead.AutoSize = true;
            this.lblRead.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.lblRead.ForeColor = System.Drawing.Color.DarkRed;
            this.lblRead.Location = new System.Drawing.Point(33, 330);
            this.lblRead.Name = "lblRead";
            this.lblRead.Size = new System.Drawing.Size(125, 17);
            this.lblRead.TabIndex = 113;
            this.lblRead.Text = "Okunma Sayısı: ";
            // 
            // txtShelfNumber
            // 
            this.txtShelfNumber.Location = new System.Drawing.Point(166, 205);
            this.txtShelfNumber.Name = "txtShelfNumber";
            this.txtShelfNumber.Properties.AllowFocused = false;
            this.txtShelfNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtShelfNumber.Properties.NullValuePrompt = "Raf Numarası";
            this.txtShelfNumber.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtShelfNumber.Size = new System.Drawing.Size(204, 22);
            this.txtShelfNumber.TabIndex = 98;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(33, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 111;
            this.label3.Text = "Yayın Tarihi:";
            // 
            // txtReleaseDate
            // 
            this.txtReleaseDate.EditValue = null;
            this.txtReleaseDate.Location = new System.Drawing.Point(166, 248);
            this.txtReleaseDate.Name = "txtReleaseDate";
            this.txtReleaseDate.Properties.AllowFocused = false;
            this.txtReleaseDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtReleaseDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtReleaseDate.Properties.CalendarTimeProperties.Mask.EditMask = "";
            this.txtReleaseDate.Properties.CalendarTimeProperties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtReleaseDate.Properties.Mask.EditMask = "";
            this.txtReleaseDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtReleaseDate.Properties.NullValuePrompt = "Yayın Tarihi";
            this.txtReleaseDate.Size = new System.Drawing.Size(204, 20);
            this.txtReleaseDate.TabIndex = 100;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(33, 417);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 17);
            this.label15.TabIndex = 110;
            this.label15.Text = "Açıklama:";
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Location = new System.Drawing.Point(167, 162);
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.Properties.AllowFocused = false;
            this.txtPageNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPageNumber.Properties.MaxLength = 8;
            this.txtPageNumber.Properties.NullValuePrompt = "Sayfa Sayısı";
            this.txtPageNumber.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtPageNumber.Size = new System.Drawing.Size(203, 22);
            this.txtPageNumber.TabIndex = 97;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(166, 33);
            this.txtName.Name = "txtName";
            this.txtName.Properties.AllowFocused = false;
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtName.Properties.NullValuePrompt = "Adı";
            this.txtName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtName.Size = new System.Drawing.Size(204, 22);
            this.txtName.TabIndex = 94;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(33, 164);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 105;
            this.label5.Text = "Sayfa Sayısı:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(33, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 17);
            this.label16.TabIndex = 109;
            this.label16.Text = "Yayınevi:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(33, 207);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 17);
            this.label6.TabIndex = 103;
            this.label6.Text = "Raf Numarası:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(33, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 17);
            this.label14.TabIndex = 108;
            this.label14.Text = "Adı:";
            // 
            // writerlbl
            // 
            this.writerlbl.AutoSize = true;
            this.writerlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.writerlbl.Location = new System.Drawing.Point(33, 78);
            this.writerlbl.Name = "writerlbl";
            this.writerlbl.Size = new System.Drawing.Size(59, 17);
            this.writerlbl.TabIndex = 107;
            this.writerlbl.Text = "Yazarı:";
            // 
            // txtAbout
            // 
            this.txtAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAbout.Location = new System.Drawing.Point(166, 415);
            this.txtAbout.Name = "txtAbout";
            this.txtAbout.Properties.AllowFocused = false;
            this.txtAbout.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAbout.Properties.Appearance.Options.UseFont = true;
            this.txtAbout.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtAbout.Properties.NullValuePrompt = "Açıklama";
            this.txtAbout.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtAbout.Size = new System.Drawing.Size(224, 140);
            this.txtAbout.TabIndex = 102;
            // 
            // BorrowedList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 634);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BorrowedList";
            this.Text = "Reads";
            this.Load += new System.EventHandler(this.Favorites_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcBorrowedList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBorrowedList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbBorrowedList.ResumeLayout(false);
            this.gbBorrowedList.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPublisher.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWriter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShelfNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReleaseDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReleaseDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbout.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelGrid;
        private DevExpress.XtraGrid.GridControl gcBorrowedList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBorrowedList;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbBorrowedList;
        private DevExpress.XtraEditors.RatingControl ratingControl;
        private DevExpress.XtraEditors.SimpleButton btnSeeComment;
        private DevExpress.XtraEditors.TextEdit txtPublisher;
        private DevExpress.XtraEditors.TextEdit txtWriter;
        private DevExpress.XtraEditors.SimpleButton btnAddComment;
        private System.Windows.Forms.Label lblNumberOfComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblFavorite;
        private System.Windows.Forms.Label lblNumberOfReads;
        private System.Windows.Forms.Label lblRead;
        private DevExpress.XtraEditors.TextEdit txtShelfNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DateEdit txtReleaseDate;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.TextEdit txtPageNumber;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label writerlbl;
        private DevExpress.XtraEditors.MemoEdit txtAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNumberOfFavorites;
        private System.Windows.Forms.Panel panel3;
    }
}