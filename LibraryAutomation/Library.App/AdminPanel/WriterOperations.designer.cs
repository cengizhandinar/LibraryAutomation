
namespace Library.App.AdminPanel
{
    partial class WriterOperations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriterOperations));
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblNumberOfBooks = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkExcel = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblControl = new System.Windows.Forms.Label();
            this.gbWriter = new System.Windows.Forms.GroupBox();
            this.btnImage = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateBirth = new DevExpress.XtraEditors.DateEdit();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBiography = new DevExpress.XtraEditors.MemoEdit();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelGrid = new System.Windows.Forms.Panel();
            this.gcWriter = new DevExpress.XtraGrid.GridControl();
            this.gvWriter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbWriter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBiography.Properties)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWriter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWriter)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.lblNumberOfBooks);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.label10);
            this.panelTop.Controls.Add(this.panel2);
            this.panelTop.Controls.Add(this.lblControl);
            this.panelTop.Controls.Add(this.gbWriter);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1389, 311);
            this.panelTop.TabIndex = 98;
            // 
            // lblNumberOfBooks
            // 
            this.lblNumberOfBooks.AutoSize = true;
            this.lblNumberOfBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNumberOfBooks.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblNumberOfBooks.Location = new System.Drawing.Point(635, 279);
            this.lblNumberOfBooks.Name = "lblNumberOfBooks";
            this.lblNumberOfBooks.Size = new System.Drawing.Size(0, 18);
            this.lblNumberOfBooks.TabIndex = 93;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(152, 279);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(215, 20);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(29, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 17);
            this.label10.TabIndex = 92;
            this.label10.Text = "İsme Göre Ara:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lnkExcel);
            this.panel2.Controls.Add(this.lblClock);
            this.panel2.Location = new System.Drawing.Point(1072, 274);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 30);
            this.panel2.TabIndex = 91;
            // 
            // lnkExcel
            // 
            this.lnkExcel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lnkExcel.Appearance.Options.UseFont = true;
            this.lnkExcel.Location = new System.Drawing.Point(3, 7);
            this.lnkExcel.Name = "lnkExcel";
            this.lnkExcel.Size = new System.Drawing.Size(38, 17);
            this.lnkExcel.TabIndex = 11;
            this.lnkExcel.Text = "Excel";
            this.lnkExcel.Click += new System.EventHandler(this.lnkExcel_Click);
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblClock.Location = new System.Drawing.Point(88, 7);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(0, 18);
            this.lblClock.TabIndex = 18;
            // 
            // lblControl
            // 
            this.lblControl.AutoSize = true;
            this.lblControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.lblControl.ForeColor = System.Drawing.Color.DarkRed;
            this.lblControl.Location = new System.Drawing.Point(403, 280);
            this.lblControl.Name = "lblControl";
            this.lblControl.Size = new System.Drawing.Size(233, 17);
            this.lblControl.TabIndex = 92;
            this.lblControl.Text = "Sistemde bulunan kitap sayısı: ";
            this.lblControl.Visible = false;
            // 
            // gbWriter
            // 
            this.gbWriter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWriter.Controls.Add(this.btnImage);
            this.gbWriter.Controls.Add(this.pictureBox1);
            this.gbWriter.Controls.Add(this.label15);
            this.gbWriter.Controls.Add(this.cbStatus);
            this.gbWriter.Controls.Add(this.dateBirth);
            this.gbWriter.Controls.Add(this.btnClear);
            this.gbWriter.Controls.Add(this.btnDelete);
            this.gbWriter.Controls.Add(this.btnSave);
            this.gbWriter.Controls.Add(this.txtName);
            this.gbWriter.Controls.Add(this.label8);
            this.gbWriter.Controls.Add(this.label14);
            this.gbWriter.Controls.Add(this.label12);
            this.gbWriter.Controls.Add(this.txtBiography);
            this.gbWriter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gbWriter.Location = new System.Drawing.Point(12, 17);
            this.gbWriter.Name = "gbWriter";
            this.gbWriter.Size = new System.Drawing.Size(1338, 251);
            this.gbWriter.TabIndex = 1;
            this.gbWriter.TabStop = false;
            this.gbWriter.Text = "Yazar Bilgileri";
            // 
            // btnImage
            // 
            this.btnImage.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnImage.Appearance.Options.UseFont = true;
            this.btnImage.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnImage.Location = new System.Drawing.Point(163, 220);
            this.btnImage.Name = "btnImage";
            this.btnImage.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnImage.Size = new System.Drawing.Size(58, 23);
            this.btnImage.TabIndex = 10;
            this.btnImage.Text = "Seç";
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(20, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(623, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 17);
            this.label15.TabIndex = 85;
            this.label15.Text = "Biyografi:";
            // 
            // cbStatus
            // 
            this.cbStatus.Location = new System.Drawing.Point(378, 165);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Properties.AllowFocused = false;
            this.cbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbStatus.Properties.Items.AddRange(new object[] {
            "Stabil",
            "Giremez",
            "Borclu"});
            this.cbStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbStatus.Size = new System.Drawing.Size(218, 20);
            this.cbStatus.TabIndex = 4;
            // 
            // dateBirth
            // 
            this.dateBirth.EditValue = null;
            this.dateBirth.Location = new System.Drawing.Point(378, 100);
            this.dateBirth.Name = "dateBirth";
            this.dateBirth.Properties.AllowFocused = false;
            this.dateBirth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBirth.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBirth.Properties.CalendarTimeProperties.Mask.EditMask = "";
            this.dateBirth.Properties.CalendarTimeProperties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dateBirth.Properties.Mask.EditMask = "";
            this.dateBirth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dateBirth.Size = new System.Drawing.Size(218, 20);
            this.dateBirth.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
            this.btnClear.Location = new System.Drawing.Point(1213, 137);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnClear.Size = new System.Drawing.Size(121, 36);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Temizle";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnDelete.Location = new System.Drawing.Point(1213, 86);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnDelete.Size = new System.Drawing.Size(121, 36);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Arşivle";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnSave.Location = new System.Drawing.Point(1213, 35);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSave.Size = new System.Drawing.Size(121, 36);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(378, 33);
            this.txtName.Name = "txtName";
            this.txtName.Properties.AllowFocused = false;
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtName.Properties.MaxLength = 50;
            this.txtName.Properties.NullValuePrompt = "Yazar Adı-Soyadı";
            this.txtName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtName.Size = new System.Drawing.Size(218, 22);
            this.txtName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(245, 101);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Doğum Tarihi:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(245, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 17);
            this.label14.TabIndex = 80;
            this.label14.Text = "Adı:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(245, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 79;
            this.label12.Text = "Durum:";
            // 
            // txtBiography
            // 
            this.txtBiography.Location = new System.Drawing.Point(713, 35);
            this.txtBiography.Name = "txtBiography";
            this.txtBiography.Properties.AllowFocused = false;
            this.txtBiography.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtBiography.Properties.MaxLength = 1500;
            this.txtBiography.Properties.NullValuePrompt = "Biyografi";
            this.txtBiography.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtBiography.Size = new System.Drawing.Size(460, 148);
            this.txtBiography.TabIndex = 3;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gcWriter);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1389, 487);
            this.panelGrid.TabIndex = 99;
            // 
            // gcWriter
            // 
            this.gcWriter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcWriter.Location = new System.Drawing.Point(32, 317);
            this.gcWriter.MainView = this.gvWriter;
            this.gcWriter.Name = "gcWriter";
            this.gcWriter.Size = new System.Drawing.Size(1318, 164);
            this.gcWriter.TabIndex = 85;
            this.gcWriter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWriter});
            this.gcWriter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gcWriter_MouseClick);
            // 
            // gvWriter
            // 
            this.gvWriter.Appearance.Empty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gvWriter.Appearance.Empty.Options.UseBackColor = true;
            this.gvWriter.Appearance.FocusedRow.BackColor = System.Drawing.Color.Linen;
            this.gvWriter.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.SeaShell;
            this.gvWriter.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvWriter.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvWriter.Appearance.FocusedRow.Options.UseFont = true;
            this.gvWriter.Appearance.Row.BackColor = System.Drawing.Color.Thistle;
            this.gvWriter.Appearance.Row.BackColor2 = System.Drawing.Color.LavenderBlush;
            this.gvWriter.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvWriter.Appearance.Row.Options.UseBackColor = true;
            this.gvWriter.Appearance.Row.Options.UseFont = true;
            this.gvWriter.Appearance.Row.Options.UseTextOptions = true;
            this.gvWriter.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gvWriter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvWriter.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvWriter.GridControl = this.gcWriter;
            this.gvWriter.Name = "gvWriter";
            this.gvWriter.OptionsBehavior.Editable = false;
            this.gvWriter.OptionsBehavior.ReadOnly = true;
            this.gvWriter.OptionsCustomization.AllowFilter = false;
            this.gvWriter.OptionsFind.AllowFindPanel = false;
            this.gvWriter.OptionsMenu.EnableColumnMenu = false;
            this.gvWriter.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvWriter.OptionsView.ShowGroupPanel = false;
            this.gvWriter.OptionsView.ShowIndicator = false;
            this.gvWriter.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvWriter.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvWriter_RowCellClick);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMessage.Location = new System.Drawing.Point(1389, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 18);
            this.lblMessage.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblMessage);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 487);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1389, 40);
            this.panelBottom.TabIndex = 100;
            // 
            // WriterOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 527);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WriterOperations";
            this.Text = "WriterOperations";
            this.Load += new System.EventHandler(this.WriterOperations_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbWriter.ResumeLayout(false);
            this.gbWriter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBiography.Properties)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcWriter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWriter)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.HyperlinkLabelControl lnkExcel;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.GroupBox gbWriter;
        private System.Windows.Forms.Label lblNumberOfBooks;
        private DevExpress.XtraEditors.SimpleButton btnImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblControl;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.ComboBoxEdit cbStatus;
        private DevExpress.XtraEditors.DateEdit dateBirth;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.MemoEdit txtBiography;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panelGrid;
        private DevExpress.XtraGrid.GridControl gcWriter;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWriter;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panelBottom;
    }
}