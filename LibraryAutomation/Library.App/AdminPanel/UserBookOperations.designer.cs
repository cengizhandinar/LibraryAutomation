
namespace Library.App.AdminPanel
{
    partial class UserBookOperations
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression3 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression4 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule5 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression5 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserBookOperations));
            this.gcUserBook = new DevExpress.XtraGrid.GridControl();
            this.gvUserBook = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchByUser = new System.Windows.Forms.TextBox();
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcBook = new DevExpress.XtraGrid.GridControl();
            this.gvBook = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnReceive = new DevExpress.XtraEditors.SimpleButton();
            this.btnLend = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearchByBook = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblBookMessage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblUserMessage = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcUserBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBook)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcUserBook
            // 
            this.gcUserBook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcUserBook.Location = new System.Drawing.Point(19, 59);
            this.gcUserBook.MainView = this.gvUserBook;
            this.gcUserBook.Name = "gcUserBook";
            this.gcUserBook.Size = new System.Drawing.Size(355, 547);
            this.gcUserBook.TabIndex = 111;
            this.gcUserBook.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUserBook});
            // 
            // gvUserBook
            // 
            this.gvUserBook.Appearance.Empty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gvUserBook.Appearance.Empty.Options.UseBackColor = true;
            this.gvUserBook.Appearance.FocusedRow.BackColor = System.Drawing.Color.Linen;
            this.gvUserBook.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.SeaShell;
            this.gvUserBook.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvUserBook.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvUserBook.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.Tan;
            formatConditionRuleExpression1.Appearance.BackColor2 = System.Drawing.Color.Khaki;
            formatConditionRuleExpression1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseFont = true;
            formatConditionRuleExpression1.Expression = "[Teslim_Tarihi] = null";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.Plum;
            formatConditionRuleExpression2.Appearance.BackColor2 = System.Drawing.Color.LavenderBlush;
            formatConditionRuleExpression2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression2.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression2.Appearance.Options.UseFont = true;
            formatConditionRuleExpression2.Expression = "[Teslim_Tarihi] <> null";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gvUserBook.FormatRules.Add(gridFormatRule1);
            this.gvUserBook.FormatRules.Add(gridFormatRule2);
            this.gvUserBook.GridControl = this.gcUserBook;
            this.gvUserBook.Name = "gvUserBook";
            this.gvUserBook.OptionsBehavior.Editable = false;
            this.gvUserBook.OptionsBehavior.ReadOnly = true;
            this.gvUserBook.OptionsCustomization.AllowFilter = false;
            this.gvUserBook.OptionsFind.AllowFindPanel = false;
            this.gvUserBook.OptionsMenu.EnableColumnMenu = false;
            this.gvUserBook.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvUserBook.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gvUserBook.OptionsView.ShowGroupPanel = false;
            this.gvUserBook.OptionsView.ShowIndicator = false;
            this.gvUserBook.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvUserBook.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvUserBook_RowCellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(17, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 112;
            this.label2.Text = "Kullanıcı Ara:";
            // 
            // txtSearchByUser
            // 
            this.txtSearchByUser.Location = new System.Drawing.Point(130, 15);
            this.txtSearchByUser.Name = "txtSearchByUser";
            this.txtSearchByUser.Size = new System.Drawing.Size(162, 20);
            this.txtSearchByUser.TabIndex = 113;
            this.txtSearchByUser.TextChanged += new System.EventHandler(this.txtSearchByUser_TextChanged);
            // 
            // gcUser
            // 
            this.gcUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcUser.Location = new System.Drawing.Point(20, 59);
            this.gcUser.MainView = this.gvUser;
            this.gcUser.Name = "gcUser";
            this.gcUser.Size = new System.Drawing.Size(486, 547);
            this.gcUser.TabIndex = 115;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser});
            // 
            // gvUser
            // 
            this.gvUser.Appearance.Empty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gvUser.Appearance.Empty.Options.UseBackColor = true;
            this.gvUser.Appearance.FocusedRow.BackColor = System.Drawing.Color.Linen;
            this.gvUser.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.SeaShell;
            this.gvUser.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule3.ApplyToRow = true;
            gridFormatRule3.Name = "Format0";
            formatConditionRuleExpression3.Appearance.BackColor = System.Drawing.Color.IndianRed;
            formatConditionRuleExpression3.Appearance.BackColor2 = System.Drawing.Color.Moccasin;
            formatConditionRuleExpression3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression3.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression3.Appearance.Options.UseFont = true;
            formatConditionRuleExpression3.Expression = "[DefinedNumberOfBooks] = 3";
            gridFormatRule3.Rule = formatConditionRuleExpression3;
            gridFormatRule4.ApplyToRow = true;
            gridFormatRule4.Name = "Format1";
            formatConditionRuleExpression4.Appearance.BackColor = System.Drawing.Color.NavajoWhite;
            formatConditionRuleExpression4.Appearance.BackColor2 = System.Drawing.Color.Moccasin;
            formatConditionRuleExpression4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression4.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression4.Appearance.Options.UseFont = true;
            formatConditionRuleExpression4.Expression = "[DefinedNumberOfBooks] > 0 And [DefinedNumberOfBooks] < 3";
            gridFormatRule4.Rule = formatConditionRuleExpression4;
            gridFormatRule5.ApplyToRow = true;
            gridFormatRule5.Name = "Format2";
            formatConditionRuleExpression5.Appearance.BackColor = System.Drawing.Color.MediumTurquoise;
            formatConditionRuleExpression5.Appearance.BackColor2 = System.Drawing.Color.Moccasin;
            formatConditionRuleExpression5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression5.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression5.Appearance.Options.UseFont = true;
            formatConditionRuleExpression5.Expression = "[DefinedNumberOfBooks] = 0";
            gridFormatRule5.Rule = formatConditionRuleExpression5;
            this.gvUser.FormatRules.Add(gridFormatRule3);
            this.gvUser.FormatRules.Add(gridFormatRule4);
            this.gvUser.FormatRules.Add(gridFormatRule5);
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsBehavior.Editable = false;
            this.gvUser.OptionsBehavior.ReadOnly = true;
            this.gvUser.OptionsCustomization.AllowFilter = false;
            this.gvUser.OptionsFind.AllowFindPanel = false;
            this.gvUser.OptionsMenu.EnableColumnMenu = false;
            this.gvUser.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvUser.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gvUser.OptionsView.ShowGroupPanel = false;
            this.gvUser.OptionsView.ShowIndicator = false;
            this.gvUser.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvUser.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvUser_RowCellClick);
            // 
            // gcBook
            // 
            this.gcBook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcBook.Location = new System.Drawing.Point(23, 59);
            this.gcBook.MainView = this.gvBook;
            this.gcBook.Name = "gcBook";
            this.gcBook.Size = new System.Drawing.Size(490, 547);
            this.gcBook.TabIndex = 117;
            this.gcBook.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBook});
            // 
            // gvBook
            // 
            this.gvBook.Appearance.Empty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gvBook.Appearance.Empty.Options.UseBackColor = true;
            this.gvBook.Appearance.FocusedRow.BackColor = System.Drawing.Color.Linen;
            this.gvBook.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.SeaShell;
            this.gvBook.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvBook.Appearance.Row.BackColor = System.Drawing.Color.LightGreen;
            this.gvBook.Appearance.Row.BackColor2 = System.Drawing.Color.Moccasin;
            this.gvBook.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gvBook.Appearance.Row.Options.UseBackColor = true;
            this.gvBook.Appearance.Row.Options.UseFont = true;
            this.gvBook.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvBook.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvBook.GridControl = this.gcBook;
            this.gvBook.Name = "gvBook";
            this.gvBook.OptionsBehavior.Editable = false;
            this.gvBook.OptionsBehavior.ReadOnly = true;
            this.gvBook.OptionsCustomization.AllowFilter = false;
            this.gvBook.OptionsFind.AllowFindPanel = false;
            this.gvBook.OptionsMenu.EnableColumnMenu = false;
            this.gvBook.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvBook.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gvBook.OptionsView.ShowGroupPanel = false;
            this.gvBook.OptionsView.ShowIndicator = false;
            this.gvBook.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvBook.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvBook_RowCellClick);
            // 
            // btnReceive
            // 
            this.btnReceive.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReceive.Appearance.Options.UseFont = true;
            this.btnReceive.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReceive.ImageOptions.Image")));
            this.btnReceive.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnReceive.Location = new System.Drawing.Point(145, 5);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnReceive.Size = new System.Drawing.Size(131, 38);
            this.btnReceive.TabIndex = 124;
            this.btnReceive.Text = "Teslim Alındı";
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // btnLend
            // 
            this.btnLend.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLend.Appearance.Options.UseFont = true;
            this.btnLend.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLend.ImageOptions.Image")));
            this.btnLend.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnLend.Location = new System.Drawing.Point(19, 5);
            this.btnLend.Name = "btnLend";
            this.btnLend.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnLend.Size = new System.Drawing.Size(120, 38);
            this.btnLend.TabIndex = 130;
            this.btnLend.Text = "Ödünç Ver";
            this.btnLend.Click += new System.EventHandler(this.btnLend_Click);
            // 
            // txtSearchByBook
            // 
            this.txtSearchByBook.Location = new System.Drawing.Point(109, 14);
            this.txtSearchByBook.Name = "txtSearchByBook";
            this.txtSearchByBook.Size = new System.Drawing.Size(162, 20);
            this.txtSearchByBook.TabIndex = 127;
            this.txtSearchByBook.TextChanged += new System.EventHandler(this.txtSearchByBook_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(23, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 129;
            this.label3.Text = "Kitap Ara:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelBottom);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.gcBook);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 653);
            this.panel1.TabIndex = 131;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblBookMessage);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 612);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(535, 41);
            this.panelBottom.TabIndex = 105;
            // 
            // lblBookMessage
            // 
            this.lblBookMessage.AutoSize = true;
            this.lblBookMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBookMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBookMessage.Location = new System.Drawing.Point(535, 0);
            this.lblBookMessage.Name = "lblBookMessage";
            this.lblBookMessage.Size = new System.Drawing.Size(0, 18);
            this.lblBookMessage.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSearchByBook);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 45);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.gcUser);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(535, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(526, 653);
            this.panel3.TabIndex = 132;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblUserMessage);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 612);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(526, 41);
            this.panel5.TabIndex = 106;
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.AutoSize = true;
            this.lblUserMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUserMessage.Location = new System.Drawing.Point(526, 0);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(0, 18);
            this.lblUserMessage.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel8);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtSearchByUser);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(526, 45);
            this.panel4.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.label5);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Location = new System.Drawing.Point(309, 12);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(197, 30);
            this.panel8.TabIndex = 114;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(111, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "Limit ( 1-2 )";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.SandyBrown;
            this.label6.Location = new System.Drawing.Point(96, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 25);
            this.label6.TabIndex = 22;
            this.label6.Text = "•";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(21, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Limit ( 3 )";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.IndianRed;
            this.label7.Location = new System.Drawing.Point(6, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "•";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.gcUserBook);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(1061, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(397, 653);
            this.panel6.TabIndex = 133;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnDelete);
            this.panel7.Controls.Add(this.btnLend);
            this.panel7.Controls.Add(this.btnReceive);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(397, 45);
            this.panel7.TabIndex = 112;
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnDelete.Location = new System.Drawing.Point(282, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnDelete.Size = new System.Drawing.Size(103, 38);
            this.btnDelete.TabIndex = 131;
            this.btnDelete.Text = "İptal Et";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // UserBookOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 653);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserBookOperations";
            this.Text = "UserBookOperations";
            this.Load += new System.EventHandler(this.UserBookOperations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcUserBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBook)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcUserBook;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUserBook;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchByUser;
        private DevExpress.XtraGrid.GridControl gcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraGrid.GridControl gcBook;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBook;
        private DevExpress.XtraEditors.SimpleButton btnReceive;
        private DevExpress.XtraEditors.SimpleButton btnLend;
        private System.Windows.Forms.TextBox txtSearchByBook;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblBookMessage;
        private System.Windows.Forms.Label lblUserMessage;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}