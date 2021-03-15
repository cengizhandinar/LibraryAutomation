
namespace Library.App.AdminPanel
{
    partial class ContactOperations
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactOperations));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchByUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkExcel = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.gcContact = new DevExpress.XtraGrid.GridControl();
            this.gvContact = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblClock = new System.Windows.Forms.Label();
            this.gbContact = new System.Windows.Forms.GroupBox();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.dateContactDate = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLastName = new DevExpress.XtraEditors.TextEdit();
            this.txtFirstName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtContent = new DevExpress.XtraEditors.MemoEdit();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContact)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.gbContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateContactDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateContactDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.gcContact);
            this.panel1.Controls.Add(this.panelBottom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 709);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtSearchByUser);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lnkExcel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(634, 50);
            this.panel3.TabIndex = 106;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(461, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Arşivde Olmayanlar";
            // 
            // txtSearchByUser
            // 
            this.txtSearchByUser.Location = new System.Drawing.Point(156, 20);
            this.txtSearchByUser.Name = "txtSearchByUser";
            this.txtSearchByUser.Size = new System.Drawing.Size(215, 20);
            this.txtSearchByUser.TabIndex = 97;
            this.txtSearchByUser.TextChanged += new System.EventHandler(this.txtSearchByUser_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.LightGreen;
            this.label5.Location = new System.Drawing.Point(448, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "•";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(33, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 17);
            this.label10.TabIndex = 98;
            this.label10.Text = "İsme Göre Ara:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(634, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 1;
            // 
            // lnkExcel
            // 
            this.lnkExcel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lnkExcel.Appearance.Options.UseFont = true;
            this.lnkExcel.Location = new System.Drawing.Point(399, 21);
            this.lnkExcel.Name = "lnkExcel";
            this.lnkExcel.Size = new System.Drawing.Size(38, 17);
            this.lnkExcel.TabIndex = 100;
            this.lnkExcel.Text = "Excel";
            this.lnkExcel.Click += new System.EventHandler(this.lnkExcel_Click);
            // 
            // gcContact
            // 
            this.gcContact.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gcContact.Location = new System.Drawing.Point(27, 67);
            this.gcContact.MainView = this.gvContact;
            this.gcContact.Name = "gcContact";
            this.gcContact.Size = new System.Drawing.Size(577, 577);
            this.gcContact.TabIndex = 105;
            this.gcContact.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvContact});
            this.gcContact.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gcContact_MouseClick);
            // 
            // gvContact
            // 
            this.gvContact.Appearance.Empty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gvContact.Appearance.Empty.Options.UseBackColor = true;
            this.gvContact.Appearance.FocusedRow.BackColor = System.Drawing.Color.Linen;
            this.gvContact.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.SeaShell;
            this.gvContact.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvContact.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvContact.Appearance.FocusedRow.Options.UseFont = true;
            this.gvContact.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gvContact.Appearance.Row.Options.UseFont = true;
            this.gvContact.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvContact.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format0";
            formatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.LightGreen;
            formatConditionRuleExpression2.Appearance.BackColor2 = System.Drawing.Color.Moccasin;
            formatConditionRuleExpression2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression2.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression2.Appearance.Options.UseFont = true;
            formatConditionRuleExpression2.Expression = "[GeneralStatus] = 0";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gvContact.FormatRules.Add(gridFormatRule2);
            this.gvContact.GridControl = this.gcContact;
            this.gvContact.Name = "gvContact";
            this.gvContact.OptionsBehavior.Editable = false;
            this.gvContact.OptionsBehavior.ReadOnly = true;
            this.gvContact.OptionsCustomization.AllowFilter = false;
            this.gvContact.OptionsFind.AllowFindPanel = false;
            this.gvContact.OptionsMenu.EnableColumnMenu = false;
            this.gvContact.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvContact.OptionsView.ShowGroupPanel = false;
            this.gvContact.OptionsView.ShowIndicator = false;
            this.gvContact.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvContact.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvContact_RowCellClick);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblMessage);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 668);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(634, 41);
            this.panelBottom.TabIndex = 104;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMessage.Location = new System.Drawing.Point(634, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 18);
            this.lblMessage.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.gbContact);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(634, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 709);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(673, 50);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.lblClock);
            this.panel5.Location = new System.Drawing.Point(450, 7);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(191, 35);
            this.panel5.TabIndex = 97;
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblClock.Location = new System.Drawing.Point(3, 12);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(0, 18);
            this.lblClock.TabIndex = 100;
            // 
            // gbContact
            // 
            this.gbContact.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbContact.Controls.Add(this.btnDelete);
            this.gbContact.Controls.Add(this.dateContactDate);
            this.gbContact.Controls.Add(this.label6);
            this.gbContact.Controls.Add(this.txtLastName);
            this.gbContact.Controls.Add(this.txtFirstName);
            this.gbContact.Controls.Add(this.label2);
            this.gbContact.Controls.Add(this.label14);
            this.gbContact.Controls.Add(this.label15);
            this.gbContact.Controls.Add(this.txtContent);
            this.gbContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gbContact.Location = new System.Drawing.Point(21, 67);
            this.gbContact.Name = "gbContact";
            this.gbContact.Size = new System.Drawing.Size(629, 577);
            this.gbContact.TabIndex = 1;
            this.gbContact.TabStop = false;
            this.gbContact.Text = "Kullanıcı-Mesaj Bilgileri";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnDelete.Location = new System.Drawing.Point(449, 113);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnDelete.Size = new System.Drawing.Size(140, 58);
            this.btnDelete.TabIndex = 96;
            this.btnDelete.Text = "Arşive Gönder";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dateContactDate
            // 
            this.dateContactDate.EditValue = null;
            this.dateContactDate.Location = new System.Drawing.Point(216, 176);
            this.dateContactDate.Name = "dateContactDate";
            this.dateContactDate.Properties.AllowFocused = false;
            this.dateContactDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateContactDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateContactDate.Properties.CalendarTimeProperties.Mask.EditMask = "";
            this.dateContactDate.Properties.CalendarTimeProperties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dateContactDate.Properties.Mask.EditMask = "";
            this.dateContactDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dateContactDate.Size = new System.Drawing.Size(214, 20);
            this.dateContactDate.TabIndex = 95;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(19, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 94;
            this.label6.Text = "Mesaj Tarihi:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(216, 133);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Properties.AllowFocused = false;
            this.txtLastName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtLastName.Properties.NullValuePrompt = "Kullanıcı Soyadı";
            this.txtLastName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtLastName.Size = new System.Drawing.Size(213, 22);
            this.txtLastName.TabIndex = 90;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(216, 95);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Properties.AllowFocused = false;
            this.txtFirstName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtFirstName.Properties.NullValuePrompt = "Kullanıcı Adı";
            this.txtFirstName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtFirstName.Size = new System.Drawing.Size(213, 22);
            this.txtFirstName.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(19, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 17);
            this.label2.TabIndex = 92;
            this.label2.Text = "Mesaj Sahibi Soyadı:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(19, 97);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 17);
            this.label14.TabIndex = 93;
            this.label14.Text = "Mesaj Sahibi Adı:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(19, 250);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 17);
            this.label15.TabIndex = 88;
            this.label15.Text = "Mesaj İçeriği:";
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(216, 250);
            this.txtContent.Name = "txtContent";
            this.txtContent.Properties.AllowFocused = false;
            this.txtContent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtContent.Properties.Appearance.Options.UseFont = true;
            this.txtContent.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtContent.Properties.MaxLength = 750;
            this.txtContent.Properties.NullValuePrompt = "Yorum İçeriği";
            this.txtContent.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtContent.Size = new System.Drawing.Size(373, 327);
            this.txtContent.TabIndex = 89;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ContactOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 709);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContactOperations";
            this.Text = "ContactOperations";
            this.Load += new System.EventHandler(this.ContactOperations_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvContact)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.gbContact.ResumeLayout(false);
            this.gbContact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateContactDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateContactDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContent.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtSearchByUser;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.HyperlinkLabelControl lnkExcel;
        private System.Windows.Forms.GroupBox gbContact;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.MemoEdit txtContent;
        private DevExpress.XtraEditors.TextEdit txtLastName;
        private DevExpress.XtraEditors.TextEdit txtFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.DateEdit dateContactDate;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.GridControl gcContact;
        private DevExpress.XtraGrid.Views.Grid.GridView gvContact;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Panel panel5;
    }
}