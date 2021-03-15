
namespace Library.App.AdminPanel
{
    partial class PublisherOperations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublisherOperations));
            this.gbPublisher = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.cbStatus = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gcPublisher = new DevExpress.XtraGrid.GridControl();
            this.gvPublisher = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lnkExcel = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.gbPublisher.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPublisher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPublisher)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPublisher
            // 
            this.gbPublisher.Controls.Add(this.label1);
            this.gbPublisher.Controls.Add(this.txtName);
            this.gbPublisher.Controls.Add(this.cbStatus);
            this.gbPublisher.Controls.Add(this.label10);
            this.gbPublisher.Controls.Add(this.label12);
            this.gbPublisher.Controls.Add(this.txtDescription);
            this.gbPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbPublisher.Location = new System.Drawing.Point(34, 12);
            this.gbPublisher.Name = "gbPublisher";
            this.gbPublisher.Size = new System.Drawing.Size(882, 150);
            this.gbPublisher.TabIndex = 108;
            this.gbPublisher.TabStop = false;
            this.gbPublisher.Text = "Yayıncı Bilgileri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(376, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 17);
            this.label1.TabIndex = 107;
            this.label1.Text = "Yayınevi Açıklama:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(161, 42);
            this.txtName.Name = "txtName";
            this.txtName.Properties.AllowFocused = false;
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtName.Properties.NullValuePrompt = "Ad";
            this.txtName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtName.Size = new System.Drawing.Size(186, 22);
            this.txtName.TabIndex = 4;
            // 
            // cbStatus
            // 
            this.cbStatus.Location = new System.Drawing.Point(161, 111);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(9, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 17);
            this.label10.TabIndex = 93;
            this.label10.Text = "Yayınevi Adı:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(9, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 106;
            this.label12.Text = "Durum:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(543, 41);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.AllowFocused = false;
            this.txtDescription.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDescription.Properties.Appearance.Options.UseFont = true;
            this.txtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtDescription.Properties.NullValuePrompt = "Ad";
            this.txtDescription.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtDescription.Size = new System.Drawing.Size(321, 90);
            this.txtDescription.TabIndex = 108;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(43, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 107;
            this.label2.Text = "İsme Göre Ara:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(195, 213);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(186, 20);
            this.txtSearch.TabIndex = 109;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // gcPublisher
            // 
            this.gcPublisher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcPublisher.Location = new System.Drawing.Point(34, 245);
            this.gcPublisher.MainView = this.gvPublisher;
            this.gcPublisher.Name = "gcPublisher";
            this.gcPublisher.Size = new System.Drawing.Size(1105, 266);
            this.gcPublisher.TabIndex = 110;
            this.gcPublisher.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPublisher});
            this.gcPublisher.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gcPublisher_MouseClick);
            // 
            // gvPublisher
            // 
            this.gvPublisher.Appearance.Empty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gvPublisher.Appearance.Empty.Options.UseBackColor = true;
            this.gvPublisher.Appearance.FocusedRow.BackColor = System.Drawing.Color.Linen;
            this.gvPublisher.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.SeaShell;
            this.gvPublisher.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvPublisher.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvPublisher.Appearance.FocusedRow.Options.UseFont = true;
            this.gvPublisher.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gvPublisher.Appearance.Row.Options.UseFont = true;
            this.gvPublisher.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvPublisher.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.RosyBrown;
            formatConditionRuleExpression1.Appearance.BackColor2 = System.Drawing.Color.Moccasin;
            formatConditionRuleExpression1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseFont = true;
            formatConditionRuleExpression1.Expression = "[GeneralStatus] = 0";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            this.gvPublisher.FormatRules.Add(gridFormatRule1);
            this.gvPublisher.GridControl = this.gcPublisher;
            this.gvPublisher.Name = "gvPublisher";
            this.gvPublisher.OptionsBehavior.Editable = false;
            this.gvPublisher.OptionsBehavior.ReadOnly = true;
            this.gvPublisher.OptionsCustomization.AllowFilter = false;
            this.gvPublisher.OptionsFind.AllowFindPanel = false;
            this.gvPublisher.OptionsMenu.EnableColumnMenu = false;
            this.gvPublisher.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvPublisher.OptionsView.ShowGroupPanel = false;
            this.gvPublisher.OptionsView.ShowIndicator = false;
            this.gvPublisher.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvPublisher.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvPublisher_RowCellClick);
            // 
            // btnClear
            // 
            this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
            this.btnClear.Location = new System.Drawing.Point(1018, 117);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnClear.Size = new System.Drawing.Size(121, 36);
            this.btnClear.TabIndex = 113;
            this.btnClear.Text = "Temizle";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnDelete.Location = new System.Drawing.Point(1018, 73);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnDelete.Size = new System.Drawing.Size(121, 36);
            this.btnDelete.TabIndex = 111;
            this.btnDelete.Text = "Arşivle";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnSave.Location = new System.Drawing.Point(1018, 31);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSave.Size = new System.Drawing.Size(121, 36);
            this.btnSave.TabIndex = 112;
            this.btnSave.Text = "Kaydet";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBack
            // 
            this.btnBack.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.ImageOptions.Image")));
            this.btnBack.Location = new System.Drawing.Point(34, 524);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnBack.Size = new System.Drawing.Size(121, 36);
            this.btnBack.TabIndex = 114;
            this.btnBack.Text = "Geri Dön";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lnkExcel);
            this.panel2.Location = new System.Drawing.Point(905, 206);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 33);
            this.panel2.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(105, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 102;
            this.label3.Text = "Aktif Yayınevleri";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.RosyBrown;
            this.label5.Location = new System.Drawing.Point(92, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 25);
            this.label5.TabIndex = 101;
            this.label5.Text = "•";
            // 
            // lnkExcel
            // 
            this.lnkExcel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lnkExcel.Appearance.Options.UseFont = true;
            this.lnkExcel.Location = new System.Drawing.Point(13, 10);
            this.lnkExcel.Name = "lnkExcel";
            this.lnkExcel.Size = new System.Drawing.Size(38, 17);
            this.lnkExcel.TabIndex = 103;
            this.lnkExcel.Text = "Excel";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Location = new System.Drawing.Point(811, 524);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 36);
            this.panel1.TabIndex = 116;
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
            // PublisherOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 572);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gcPublisher);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbPublisher);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PublisherOperations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PublisherOperations";
            this.Load += new System.EventHandler(this.PublisherOperations_Load);
            this.gbPublisher.ResumeLayout(false);
            this.gbPublisher.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPublisher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPublisher)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPublisher;
        private DevExpress.XtraEditors.TextEdit txtName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.ComboBoxEdit cbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private DevExpress.XtraGrid.GridControl gcPublisher;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPublisher;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.HyperlinkLabelControl lnkExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMessage;
    }
}