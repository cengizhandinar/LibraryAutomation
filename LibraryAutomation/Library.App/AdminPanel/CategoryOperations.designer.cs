
namespace Library.App.AdminPanel
{
    partial class CategoryOperations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryOperations));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.txtCategoryName = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAllParent = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ceIsParent = new DevExpress.XtraEditors.CheckEdit();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.gcCategory = new DevExpress.XtraGrid.GridControl();
            this.gvCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.gbCategory = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbGetParent = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAllParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus.Properties)).BeginInit();
            this.gbCategory.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbGetParent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(25, 71);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Properties.AllowFocused = false;
            this.txtCategoryName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtCategoryName.Properties.MaxLength = 50;
            this.txtCategoryName.Properties.NullValuePrompt = "Ad";
            this.txtCategoryName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtCategoryName.Size = new System.Drawing.Size(186, 22);
            this.txtCategoryName.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(66, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 17);
            this.label10.TabIndex = 93;
            this.label10.Text = "Kategori Adı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(296, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 93;
            this.label1.Text = "Üst Kategori Adı:";
            // 
            // cbAllParent
            // 
            this.cbAllParent.Location = new System.Drawing.Point(263, 72);
            this.cbAllParent.Name = "cbAllParent";
            this.cbAllParent.Properties.AllowFocused = false;
            this.cbAllParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAllParent.Properties.Items.AddRange(new object[] {
            "Stabil",
            "Giremez",
            "Borclu"});
            this.cbAllParent.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbAllParent.Size = new System.Drawing.Size(186, 20);
            this.cbAllParent.TabIndex = 94;
            // 
            // ceIsParent
            // 
            this.ceIsParent.EditValue = true;
            this.ceIsParent.Location = new System.Drawing.Point(49, 99);
            this.ceIsParent.Name = "ceIsParent";
            this.ceIsParent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ceIsParent.Properties.Appearance.Options.UseFont = true;
            this.ceIsParent.Properties.Caption = "Alt Kategori Mi?";
            this.ceIsParent.Size = new System.Drawing.Size(138, 20);
            this.ceIsParent.TabIndex = 95;
            this.ceIsParent.CheckedChanged += new System.EventHandler(this.ceIsParent_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnDelete.Location = new System.Drawing.Point(932, 86);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnDelete.Size = new System.Drawing.Size(121, 36);
            this.btnDelete.TabIndex = 96;
            this.btnDelete.Text = "Arşivle";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnSave.Location = new System.Drawing.Point(932, 44);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSave.Size = new System.Drawing.Size(121, 36);
            this.btnSave.TabIndex = 97;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gcCategory
            // 
            this.gcCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcCategory.Location = new System.Drawing.Point(30, 245);
            this.gcCategory.MainView = this.gvCategory;
            this.gcCategory.Name = "gcCategory";
            this.gcCategory.Size = new System.Drawing.Size(1029, 280);
            this.gcCategory.TabIndex = 98;
            this.gcCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCategory});
            this.gcCategory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gcCategory_MouseClick);
            // 
            // gvCategory
            // 
            this.gvCategory.Appearance.Empty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gvCategory.Appearance.Empty.Options.UseBackColor = true;
            this.gvCategory.Appearance.FocusedRow.BackColor = System.Drawing.Color.Linen;
            this.gvCategory.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.SeaShell;
            this.gvCategory.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvCategory.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvCategory.Appearance.FocusedRow.Options.UseFont = true;
            this.gvCategory.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gvCategory.Appearance.Row.Options.UseFont = true;
            this.gvCategory.Appearance.Row.Options.UseTextOptions = true;
            this.gvCategory.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gvCategory.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvCategory.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            formatConditionRuleExpression1.Appearance.BackColor2 = System.Drawing.Color.Moccasin;
            formatConditionRuleExpression1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseFont = true;
            formatConditionRuleExpression1.Expression = "[ParentId] = 0";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.LightSalmon;
            formatConditionRuleExpression2.Appearance.BackColor2 = System.Drawing.Color.Moccasin;
            formatConditionRuleExpression2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression2.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression2.Appearance.Options.UseFont = true;
            formatConditionRuleExpression2.Expression = "[ParentId] != 0";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gvCategory.FormatRules.Add(gridFormatRule1);
            this.gvCategory.FormatRules.Add(gridFormatRule2);
            this.gvCategory.GridControl = this.gcCategory;
            this.gvCategory.Name = "gvCategory";
            this.gvCategory.OptionsBehavior.Editable = false;
            this.gvCategory.OptionsBehavior.ReadOnly = true;
            this.gvCategory.OptionsCustomization.AllowFilter = false;
            this.gvCategory.OptionsFind.AllowFindPanel = false;
            this.gvCategory.OptionsMenu.EnableColumnMenu = false;
            this.gvCategory.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvCategory.OptionsView.ShowGroupPanel = false;
            this.gvCategory.OptionsView.ShowIndicator = false;
            this.gvCategory.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvCategory.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvCategory_RowCellClick);
            // 
            // btnClear
            // 
            this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
            this.btnClear.Location = new System.Drawing.Point(932, 130);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnClear.Size = new System.Drawing.Size(121, 36);
            this.btnClear.TabIndex = 99;
            this.btnClear.Text = "Temizle";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMessage.Location = new System.Drawing.Point(328, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 18);
            this.lblMessage.TabIndex = 100;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(195, 211);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(186, 20);
            this.txtSearch.TabIndex = 102;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(41, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 104;
            this.label2.Text = "İsme Göre Ara:";
            // 
            // cbStatus
            // 
            this.cbStatus.Location = new System.Drawing.Point(506, 73);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Properties.AllowFocused = false;
            this.cbStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbStatus.Properties.Items.AddRange(new object[] {
            "Stabil",
            "Giremez",
            "Borclu"});
            this.cbStatus.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbStatus.Size = new System.Drawing.Size(186, 20);
            this.cbStatus.TabIndex = 105;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(574, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 106;
            this.label12.Text = "Durum:";
            // 
            // gbCategory
            // 
            this.gbCategory.Controls.Add(this.cbAllParent);
            this.gbCategory.Controls.Add(this.cbStatus);
            this.gbCategory.Controls.Add(this.txtCategoryName);
            this.gbCategory.Controls.Add(this.label12);
            this.gbCategory.Controls.Add(this.label10);
            this.gbCategory.Controls.Add(this.label1);
            this.gbCategory.Controls.Add(this.ceIsParent);
            this.gbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbCategory.Location = new System.Drawing.Point(30, 30);
            this.gbCategory.Name = "gbCategory";
            this.gbCategory.Size = new System.Drawing.Size(780, 140);
            this.gbCategory.TabIndex = 107;
            this.gbCategory.TabStop = false;
            this.gbCategory.Text = "Kategori Bilgileri";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Location = new System.Drawing.Point(731, 543);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 36);
            this.panel1.TabIndex = 108;
            // 
            // btnBack
            // 
            this.btnBack.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.ImageOptions.Image")));
            this.btnBack.Location = new System.Drawing.Point(30, 543);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnBack.Size = new System.Drawing.Size(121, 36);
            this.btnBack.TabIndex = 109;
            this.btnBack.Text = "Geri Dön";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Location = new System.Drawing.Point(10, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "•";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.LightCoral;
            this.label7.Location = new System.Drawing.Point(130, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "•";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Ana Kategori";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(145, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Parent Kategori";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(793, 201);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(266, 33);
            this.panel2.TabIndex = 103;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(400, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 17);
            this.label4.TabIndex = 111;
            this.label4.Text = "Alt Kategorileri Getir:";
            // 
            // cbGetParent
            // 
            this.cbGetParent.Location = new System.Drawing.Point(580, 211);
            this.cbGetParent.Name = "cbGetParent";
            this.cbGetParent.Properties.AllowFocused = false;
            this.cbGetParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGetParent.Properties.Items.AddRange(new object[] {
            "Stabil",
            "Giremez",
            "Borclu"});
            this.cbGetParent.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbGetParent.Size = new System.Drawing.Size(186, 20);
            this.cbGetParent.TabIndex = 112;
            this.cbGetParent.SelectedIndexChanged += new System.EventHandler(this.cbGetParent_SelectedIndexChanged);
            // 
            // CategoryOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 591);
            this.Controls.Add(this.cbGetParent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbCategory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.gcCategory);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CategoryOperations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoryOperatios";
            this.Load += new System.EventHandler(this.CategoryOperations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbAllParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus.Properties)).EndInit();
            this.gbCategory.ResumeLayout(false);
            this.gbCategory.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbGetParent.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.ComboBoxEdit cbAllParent;
        private DevExpress.XtraEditors.ComboBoxEdit cbGetParent;
        private DevExpress.XtraEditors.ComboBoxEdit cbStatus;
        private DevExpress.XtraEditors.CheckEdit ceIsParent;
        private System.Windows.Forms.GroupBox gbCategory;
        private DevExpress.XtraGrid.GridControl gcCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.TextEdit txtCategoryName;
        private System.Windows.Forms.TextBox txtSearch;

        #endregion
    }
}