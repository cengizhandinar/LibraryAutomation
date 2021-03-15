
namespace Library.App.AdminPanel
{
    partial class CommentOperations
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentOperations));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.gvComment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcComment = new DevExpress.XtraGrid.GridControl();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gbWriter = new System.Windows.Forms.GroupBox();
            this.dateCommentDate = new DevExpress.XtraEditors.DateEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtBookName = new DevExpress.XtraEditors.TextEdit();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtContent = new DevExpress.XtraEditors.MemoEdit();
            this.panelTop = new System.Windows.Forms.Panel();
            this.ceAllComment = new DevExpress.XtraEditors.CheckEdit();
            this.txtSearchByBook = new System.Windows.Forms.TextBox();
            this.txtSearchByUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lnkExcel = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcComment)).BeginInit();
            this.panelGrid.SuspendLayout();
            this.gbWriter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateCommentDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCommentDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceAllComment.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblMessage);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 466);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1460, 38);
            this.panelBottom.TabIndex = 103;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMessage.Location = new System.Drawing.Point(1460, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 18);
            this.lblMessage.TabIndex = 1;
            // 
            // gvComment
            // 
            this.gvComment.Appearance.Empty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gvComment.Appearance.Empty.Options.UseBackColor = true;
            this.gvComment.Appearance.FocusedRow.BackColor = System.Drawing.Color.Linen;
            this.gvComment.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.SeaShell;
            this.gvComment.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvComment.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvComment.Appearance.FocusedRow.Options.UseFont = true;
            this.gvComment.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gvComment.Appearance.Row.Options.UseFont = true;
            this.gvComment.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvComment.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.LightGreen;
            formatConditionRuleExpression1.Appearance.BackColor2 = System.Drawing.Color.Moccasin;
            formatConditionRuleExpression1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseFont = true;
            formatConditionRuleExpression1.Expression = "[GeneralStatus] = 0";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.Salmon;
            formatConditionRuleExpression2.Appearance.BackColor2 = System.Drawing.Color.Moccasin;
            formatConditionRuleExpression2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression2.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression2.Appearance.Options.UseFont = true;
            formatConditionRuleExpression2.Expression = "[GeneralStatus] != 0";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gvComment.FormatRules.Add(gridFormatRule1);
            this.gvComment.FormatRules.Add(gridFormatRule2);
            this.gvComment.GridControl = this.gcComment;
            this.gvComment.Name = "gvComment";
            this.gvComment.OptionsBehavior.Editable = false;
            this.gvComment.OptionsBehavior.ReadOnly = true;
            this.gvComment.OptionsCustomization.AllowFilter = false;
            this.gvComment.OptionsFind.AllowFindPanel = false;
            this.gvComment.OptionsMenu.EnableColumnMenu = false;
            this.gvComment.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvComment.OptionsView.ShowGroupPanel = false;
            this.gvComment.OptionsView.ShowIndicator = false;
            this.gvComment.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvComment.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvComment_RowCellClick);
            // 
            // gcComment
            // 
            this.gcComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcComment.Location = new System.Drawing.Point(30, 6);
            this.gcComment.MainView = this.gvComment;
            this.gcComment.Name = "gcComment";
            this.gcComment.Size = new System.Drawing.Size(1393, 143);
            this.gcComment.TabIndex = 85;
            this.gcComment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvComment});
            this.gcComment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gcComment_MouseClick);
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.gcComment);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 311);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1460, 193);
            this.panelGrid.TabIndex = 102;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // gbWriter
            // 
            this.gbWriter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWriter.Controls.Add(this.dateCommentDate);
            this.gbWriter.Controls.Add(this.label15);
            this.gbWriter.Controls.Add(this.btnClear);
            this.gbWriter.Controls.Add(this.btnDelete);
            this.gbWriter.Controls.Add(this.btnSave);
            this.gbWriter.Controls.Add(this.txtBookName);
            this.gbWriter.Controls.Add(this.txtLastName);
            this.gbWriter.Controls.Add(this.label6);
            this.gbWriter.Controls.Add(this.txtFirstName);
            this.gbWriter.Controls.Add(this.label4);
            this.gbWriter.Controls.Add(this.label2);
            this.gbWriter.Controls.Add(this.label14);
            this.gbWriter.Controls.Add(this.txtContent);
            this.gbWriter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gbWriter.Location = new System.Drawing.Point(27, 17);
            this.gbWriter.Name = "gbWriter";
            this.gbWriter.Size = new System.Drawing.Size(1396, 200);
            this.gbWriter.TabIndex = 1;
            this.gbWriter.TabStop = false;
            this.gbWriter.Text = "Kullanıcı Yorum Bilgileri";
            // 
            // dateCommentDate
            // 
            this.dateCommentDate.EditValue = null;
            this.dateCommentDate.Location = new System.Drawing.Point(208, 162);
            this.dateCommentDate.Name = "dateCommentDate";
            this.dateCommentDate.Properties.AllowFocused = false;
            this.dateCommentDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateCommentDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateCommentDate.Properties.CalendarTimeProperties.Mask.EditMask = "";
            this.dateCommentDate.Properties.CalendarTimeProperties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dateCommentDate.Properties.Mask.EditMask = "";
            this.dateCommentDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dateCommentDate.Size = new System.Drawing.Size(214, 20);
            this.dateCommentDate.TabIndex = 88;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(484, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 17);
            this.label15.TabIndex = 85;
            this.label15.Text = "İçerik:";
            // 
            // btnClear
            // 
            this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
            this.btnClear.Location = new System.Drawing.Point(1269, 135);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnClear.Size = new System.Drawing.Size(121, 36);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Temizle";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnDelete.Location = new System.Drawing.Point(1269, 84);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnDelete.Size = new System.Drawing.Size(121, 36);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Arşivle";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnSave.Location = new System.Drawing.Point(1269, 33);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSave.Size = new System.Drawing.Size(121, 36);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Onayla";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(209, 119);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Properties.AllowFocused = false;
            this.txtBookName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtBookName.Properties.NullValuePrompt = "Kitap Adı";
            this.txtBookName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtBookName.Size = new System.Drawing.Size(213, 22);
            this.txtBookName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(209, 76);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Properties.AllowFocused = false;
            this.txtLastName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtLastName.Properties.NullValuePrompt = "Kullanıcı Soyadı";
            this.txtLastName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtLastName.Size = new System.Drawing.Size(213, 22);
            this.txtLastName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(12, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 17);
            this.label6.TabIndex = 80;
            this.label6.Text = "Yorum Tarihi:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(209, 33);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Properties.AllowFocused = false;
            this.txtFirstName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtFirstName.Properties.NullValuePrompt = "Kullanıcı Adı";
            this.txtFirstName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtFirstName.Size = new System.Drawing.Size(213, 22);
            this.txtFirstName.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 17);
            this.label4.TabIndex = 80;
            this.label4.Text = "Yorum Yapılan Kitap:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 17);
            this.label2.TabIndex = 80;
            this.label2.Text = "Yorum Sahibi Soyadı:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(12, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(137, 17);
            this.label14.TabIndex = 80;
            this.label14.Text = "Yorum Sahibi Adı:";
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(558, 31);
            this.txtContent.Name = "txtContent";
            this.txtContent.Properties.AllowFocused = false;
            this.txtContent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtContent.Properties.Appearance.Options.UseFont = true;
            this.txtContent.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtContent.Properties.MaxLength = 300;
            this.txtContent.Properties.NullValuePrompt = "Yorum İçeriği";
            this.txtContent.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtContent.Size = new System.Drawing.Size(643, 151);
            this.txtContent.TabIndex = 87;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.ceAllComment);
            this.panelTop.Controls.Add(this.txtSearchByBook);
            this.panelTop.Controls.Add(this.txtSearchByUser);
            this.panelTop.Controls.Add(this.label3);
            this.panelTop.Controls.Add(this.label10);
            this.panelTop.Controls.Add(this.panel2);
            this.panelTop.Controls.Add(this.gbWriter);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1460, 311);
            this.panelTop.TabIndex = 101;
            // 
            // ceAllComment
            // 
            this.ceAllComment.Location = new System.Drawing.Point(585, 283);
            this.ceAllComment.Name = "ceAllComment";
            this.ceAllComment.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ceAllComment.Properties.Appearance.ForeColor = System.Drawing.Color.IndianRed;
            this.ceAllComment.Properties.Appearance.Options.UseFont = true;
            this.ceAllComment.Properties.Appearance.Options.UseForeColor = true;
            this.ceAllComment.Properties.Caption = "Onay Bekleyenleri Göster";
            this.ceAllComment.Size = new System.Drawing.Size(221, 22);
            this.ceAllComment.TabIndex = 102;
            this.ceAllComment.CheckedChanged += new System.EventHandler(this.ceAllComment_CheckedChanged);
            // 
            // txtSearchByBook
            // 
            this.txtSearchByBook.Location = new System.Drawing.Point(235, 284);
            this.txtSearchByBook.Name = "txtSearchByBook";
            this.txtSearchByBook.Size = new System.Drawing.Size(214, 20);
            this.txtSearchByBook.TabIndex = 98;
            this.txtSearchByBook.TextChanged += new System.EventHandler(this.txtSearchByBook_TextChanged);
            // 
            // txtSearchByUser
            // 
            this.txtSearchByUser.Location = new System.Drawing.Point(235, 246);
            this.txtSearchByUser.Name = "txtSearchByUser";
            this.txtSearchByUser.Size = new System.Drawing.Size(214, 20);
            this.txtSearchByUser.TabIndex = 99;
            this.txtSearchByUser.TextChanged += new System.EventHandler(this.txtSearchByUser_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(35, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 17);
            this.label3.TabIndex = 100;
            this.label3.Text = "Kitap Adına Göre Ara:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(35, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 17);
            this.label10.TabIndex = 101;
            this.label10.Text = "Kullanıcıya Göre Ara:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lnkExcel);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblClock);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(886, 269);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 36);
            this.panel2.TabIndex = 95;
            // 
            // lnkExcel
            // 
            this.lnkExcel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lnkExcel.Appearance.Options.UseFont = true;
            this.lnkExcel.Location = new System.Drawing.Point(3, 9);
            this.lnkExcel.Name = "lnkExcel";
            this.lnkExcel.Size = new System.Drawing.Size(38, 17);
            this.lnkExcel.TabIndex = 90;
            this.lnkExcel.Text = "Excel";
            this.lnkExcel.Click += new System.EventHandler(this.lnkExcel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(202, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Onay Bekleyenler";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(68, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Onaylı Yorumlar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.Salmon;
            this.label7.Location = new System.Drawing.Point(187, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "•";
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblClock.Location = new System.Drawing.Point(351, 9);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(0, 18);
            this.lblClock.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.LightGreen;
            this.label5.Location = new System.Drawing.Point(52, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "•";
            // 
            // CommentOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 504);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CommentOperations";
            this.Text = "CommentOperations";
            this.Load += new System.EventHandler(this.CommentOperations_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcComment)).EndInit();
            this.panelGrid.ResumeLayout(false);
            this.gbWriter.ResumeLayout(false);
            this.gbWriter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateCommentDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateCommentDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceAllComment.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblMessage;
        private DevExpress.XtraGrid.Views.Grid.GridView gvComment;
        private DevExpress.XtraGrid.GridControl gcComment;
        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox gbWriter;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.MemoEdit txtContent;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.HyperlinkLabelControl lnkExcel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblClock;
        private DevExpress.XtraEditors.TextEdit txtLastName;
        private DevExpress.XtraEditors.TextEdit txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.TextEdit txtBookName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.DateEdit dateCommentDate;
        private System.Windows.Forms.TextBox txtSearchByBook;
        private System.Windows.Forms.TextBox txtSearchByUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.CheckEdit ceAllComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}