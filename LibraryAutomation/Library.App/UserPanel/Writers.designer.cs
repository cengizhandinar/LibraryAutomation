
namespace Library.App.UserPanel
{
    partial class Writers
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.gcWriter = new DevExpress.XtraGrid.GridControl();
            this.gvWriter = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblNumberOfBooks = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblControl = new System.Windows.Forms.Label();
            this.gbWriter = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dateBirth = new DevExpress.XtraEditors.DateEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBiography = new DevExpress.XtraEditors.MemoEdit();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkExcel = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.lblClock = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcWriter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWriter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbWriter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBiography.Properties)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblMessage);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 542);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1425, 44);
            this.panelBottom.TabIndex = 103;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMessage.Location = new System.Drawing.Point(1425, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 18);
            this.lblMessage.TabIndex = 1;
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gcWriter);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 358);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1425, 228);
            this.panelGrid.TabIndex = 102;
            // 
            // gcWriter
            // 
            this.gcWriter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcWriter.Location = new System.Drawing.Point(32, 6);
            this.gcWriter.MainView = this.gvWriter;
            this.gcWriter.Name = "gcWriter";
            this.gcWriter.Size = new System.Drawing.Size(1354, 172);
            this.gcWriter.TabIndex = 104;
            this.gcWriter.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWriter});
            // 
            // gvWriter
            // 
            this.gvWriter.Appearance.Empty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gvWriter.Appearance.Empty.Options.UseBackColor = true;
            this.gvWriter.Appearance.FocusedRow.BackColor = System.Drawing.Color.Linen;
            this.gvWriter.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.SeaShell;
            this.gvWriter.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvWriter.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvWriter.Appearance.FocusedRow.Options.UseFont = true;
            this.gvWriter.Appearance.Row.BackColor = System.Drawing.Color.PowderBlue;
            this.gvWriter.Appearance.Row.BackColor2 = System.Drawing.Color.LavenderBlush;
            this.gvWriter.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gvWriter.Appearance.Row.Options.UseBackColor = true;
            this.gvWriter.Appearance.Row.Options.UseFont = true;
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
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblNumberOfBooks
            // 
            this.lblNumberOfBooks.AutoSize = true;
            this.lblNumberOfBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNumberOfBooks.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblNumberOfBooks.Location = new System.Drawing.Point(490, 194);
            this.lblNumberOfBooks.Name = "lblNumberOfBooks";
            this.lblNumberOfBooks.Size = new System.Drawing.Size(0, 18);
            this.lblNumberOfBooks.TabIndex = 93;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(10, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 234);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // lblControl
            // 
            this.lblControl.AutoSize = true;
            this.lblControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.lblControl.ForeColor = System.Drawing.Color.DarkRed;
            this.lblControl.Location = new System.Drawing.Point(251, 194);
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
            this.gbWriter.Controls.Add(this.lblNumberOfBooks);
            this.gbWriter.Controls.Add(this.pictureBox1);
            this.gbWriter.Controls.Add(this.label15);
            this.gbWriter.Controls.Add(this.dateBirth);
            this.gbWriter.Controls.Add(this.lblControl);
            this.gbWriter.Controls.Add(this.txtName);
            this.gbWriter.Controls.Add(this.label8);
            this.gbWriter.Controls.Add(this.label14);
            this.gbWriter.Controls.Add(this.txtBiography);
            this.gbWriter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gbWriter.Location = new System.Drawing.Point(22, 12);
            this.gbWriter.Name = "gbWriter";
            this.gbWriter.Size = new System.Drawing.Size(1364, 288);
            this.gbWriter.TabIndex = 1;
            this.gbWriter.TabStop = false;
            this.gbWriter.Text = "Yazar Bilgileri";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(636, 53);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 17);
            this.label15.TabIndex = 85;
            this.label15.Text = "Biyografi:";
            // 
            // dateBirth
            // 
            this.dateBirth.EditValue = null;
            this.dateBirth.Location = new System.Drawing.Point(384, 124);
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
            this.dateBirth.Size = new System.Drawing.Size(214, 20);
            this.dateBirth.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(384, 51);
            this.txtName.Name = "txtName";
            this.txtName.Properties.AllowFocused = false;
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtName.Properties.NullValuePrompt = "Yazar Adı-Soyadı";
            this.txtName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtName.Size = new System.Drawing.Size(214, 22);
            this.txtName.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(251, 125);
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
            this.label14.Location = new System.Drawing.Point(251, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 17);
            this.label14.TabIndex = 80;
            this.label14.Text = "Adı:";
            // 
            // txtBiography
            // 
            this.txtBiography.Location = new System.Drawing.Point(730, 51);
            this.txtBiography.Name = "txtBiography";
            this.txtBiography.Properties.AllowFocused = false;
            this.txtBiography.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtBiography.Properties.NullValuePrompt = "Biyografi";
            this.txtBiography.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtBiography.Size = new System.Drawing.Size(634, 220);
            this.txtBiography.TabIndex = 87;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panel2);
            this.panelTop.Controls.Add(this.gbWriter);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Controls.Add(this.label10);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1425, 358);
            this.panelTop.TabIndex = 101;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lnkExcel);
            this.panel2.Controls.Add(this.lblClock);
            this.panel2.Location = new System.Drawing.Point(1131, 319);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(255, 33);
            this.panel2.TabIndex = 91;
            // 
            // lnkExcel
            // 
            this.lnkExcel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lnkExcel.Appearance.Options.UseFont = true;
            this.lnkExcel.Location = new System.Drawing.Point(3, 8);
            this.lnkExcel.Name = "lnkExcel";
            this.lnkExcel.Size = new System.Drawing.Size(38, 17);
            this.lnkExcel.TabIndex = 90;
            this.lnkExcel.Text = "Excel";
            this.lnkExcel.Click += new System.EventHandler(this.lnkExcel_Click);
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblClock.Location = new System.Drawing.Point(63, 7);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(0, 18);
            this.lblClock.TabIndex = 18;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(161, 326);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(259, 20);
            this.txtSearch.TabIndex = 90;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(38, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 17);
            this.label10.TabIndex = 92;
            this.label10.Text = "İsme Göre Ara:";
            // 
            // Writers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 586);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Writers";
            this.Text = "Writers";
            this.Load += new System.EventHandler(this.Writers_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcWriter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWriter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbWriter.ResumeLayout(false);
            this.gbWriter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBiography.Properties)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panelGrid;
        private DevExpress.XtraGrid.GridControl gcWriter;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWriter;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblNumberOfBooks;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblControl;
        private System.Windows.Forms.GroupBox gbWriter;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.DateEdit dateBirth;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.MemoEdit txtBiography;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.HyperlinkLabelControl lnkExcel;
        private System.Windows.Forms.Label lblClock;
    }
}