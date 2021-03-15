
namespace Library.App.UserPanel
{
    partial class SeeCommentPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeeCommentPersonal));
            this.gcCommentsPersonal = new DevExpress.XtraGrid.GridControl();
            this.gvCommentsPersonal = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnUpdateComment = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteComment = new DevExpress.XtraEditors.SimpleButton();
            this.lblClock = new System.Windows.Forms.Label();
            this.lnkExcel = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcCommentsPersonal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCommentsPersonal)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcCommentsPersonal
            // 
            this.gcCommentsPersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcCommentsPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gcCommentsPersonal.Location = new System.Drawing.Point(41, 71);
            this.gcCommentsPersonal.MainView = this.gvCommentsPersonal;
            this.gcCommentsPersonal.Name = "gcCommentsPersonal";
            this.gcCommentsPersonal.Size = new System.Drawing.Size(1282, 471);
            this.gcCommentsPersonal.TabIndex = 116;
            this.gcCommentsPersonal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCommentsPersonal});
            // 
            // gvCommentsPersonal
            // 
            this.gvCommentsPersonal.Appearance.Empty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gvCommentsPersonal.Appearance.Empty.Options.UseBackColor = true;
            this.gvCommentsPersonal.Appearance.EvenRow.BackColor = System.Drawing.Color.LightSkyBlue;
            this.gvCommentsPersonal.Appearance.EvenRow.BackColor2 = System.Drawing.Color.Moccasin;
            this.gvCommentsPersonal.Appearance.EvenRow.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvCommentsPersonal.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvCommentsPersonal.Appearance.EvenRow.Options.UseFont = true;
            this.gvCommentsPersonal.Appearance.FocusedRow.BackColor = System.Drawing.Color.Linen;
            this.gvCommentsPersonal.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.SeaShell;
            this.gvCommentsPersonal.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvCommentsPersonal.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvCommentsPersonal.Appearance.FocusedRow.Options.UseFont = true;
            this.gvCommentsPersonal.Appearance.OddRow.BackColor = System.Drawing.Color.DarkKhaki;
            this.gvCommentsPersonal.Appearance.OddRow.BackColor2 = System.Drawing.Color.Moccasin;
            this.gvCommentsPersonal.Appearance.OddRow.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvCommentsPersonal.Appearance.OddRow.Options.UseBackColor = true;
            this.gvCommentsPersonal.Appearance.OddRow.Options.UseFont = true;
            this.gvCommentsPersonal.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gvCommentsPersonal.Appearance.Row.Options.UseFont = true;
            this.gvCommentsPersonal.Appearance.Row.Options.UseTextOptions = true;
            this.gvCommentsPersonal.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gvCommentsPersonal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvCommentsPersonal.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.IndianRed;
            formatConditionRuleExpression1.Appearance.BackColor2 = System.Drawing.Color.LavenderBlush;
            formatConditionRuleExpression1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseFont = true;
            formatConditionRuleExpression1.Expression = "[GeneralStatus] = 1";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            this.gvCommentsPersonal.FormatRules.Add(gridFormatRule1);
            this.gvCommentsPersonal.GridControl = this.gcCommentsPersonal;
            this.gvCommentsPersonal.Name = "gvCommentsPersonal";
            this.gvCommentsPersonal.OptionsBehavior.Editable = false;
            this.gvCommentsPersonal.OptionsBehavior.ReadOnly = true;
            this.gvCommentsPersonal.OptionsCustomization.AllowFilter = false;
            this.gvCommentsPersonal.OptionsFind.AllowFindPanel = false;
            this.gvCommentsPersonal.OptionsMenu.EnableColumnMenu = false;
            this.gvCommentsPersonal.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvCommentsPersonal.OptionsView.EnableAppearanceEvenRow = true;
            this.gvCommentsPersonal.OptionsView.EnableAppearanceOddRow = true;
            this.gvCommentsPersonal.OptionsView.RowAutoHeight = true;
            this.gvCommentsPersonal.OptionsView.ShowGroupPanel = false;
            this.gvCommentsPersonal.OptionsView.ShowIndicator = false;
            this.gvCommentsPersonal.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvCommentsPersonal.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gvCommentsPersonal_RowCellClick);
            // 
            // btnUpdateComment
            // 
            this.btnUpdateComment.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdateComment.Appearance.Options.UseFont = true;
            this.btnUpdateComment.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUpdateComment.ImageOptions.SvgImage")));
            this.btnUpdateComment.Location = new System.Drawing.Point(41, 18);
            this.btnUpdateComment.Name = "btnUpdateComment";
            this.btnUpdateComment.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnUpdateComment.Size = new System.Drawing.Size(165, 45);
            this.btnUpdateComment.TabIndex = 117;
            this.btnUpdateComment.Text = "Yorumu Düzenle";
            this.btnUpdateComment.Click += new System.EventHandler(this.btnUpdateComment_Click);
            // 
            // btnDeleteComment
            // 
            this.btnDeleteComment.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDeleteComment.Appearance.Options.UseFont = true;
            this.btnDeleteComment.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteComment.ImageOptions.Image")));
            this.btnDeleteComment.Location = new System.Drawing.Point(223, 18);
            this.btnDeleteComment.Name = "btnDeleteComment";
            this.btnDeleteComment.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnDeleteComment.Size = new System.Drawing.Size(165, 45);
            this.btnDeleteComment.TabIndex = 118;
            this.btnDeleteComment.Text = "Yorumu Kaldır";
            this.btnDeleteComment.Click += new System.EventHandler(this.btnDeleteComment_Click);
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblClock.Location = new System.Drawing.Point(313, 13);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(183, 18);
            this.lblClock.TabIndex = 119;
            this.lblClock.Text = "29 Aralık 2020 24:24:24";
            // 
            // lnkExcel
            // 
            this.lnkExcel.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.lnkExcel.Appearance.Options.UseFont = true;
            this.lnkExcel.Location = new System.Drawing.Point(255, 13);
            this.lnkExcel.Name = "lnkExcel";
            this.lnkExcel.Size = new System.Drawing.Size(38, 17);
            this.lnkExcel.TabIndex = 120;
            this.lnkExcel.Text = "Excel";
            this.lnkExcel.Click += new System.EventHandler(this.lnkExcel_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.Controls.Add(this.lblMessage);
            this.panelBottom.Location = new System.Drawing.Point(919, 557);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(404, 45);
            this.panelBottom.TabIndex = 121;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMessage.Location = new System.Drawing.Point(404, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 18);
            this.lblMessage.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblClock);
            this.panel1.Controls.Add(this.lnkExcel);
            this.panel1.Location = new System.Drawing.Point(821, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 45);
            this.panel1.TabIndex = 122;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(25, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 16);
            this.label3.TabIndex = 124;
            this.label3.Text = "Onaylanma Aşamasında";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.LightCoral;
            this.label5.Location = new System.Drawing.Point(9, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 25);
            this.label5.TabIndex = 122;
            this.label5.Text = "•";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // SeeCommentPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 614);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.btnDeleteComment);
            this.Controls.Add(this.btnUpdateComment);
            this.Controls.Add(this.gcCommentsPersonal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeeCommentPersonal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S";
            this.Load += new System.EventHandler(this.SeeCommentPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcCommentsPersonal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCommentsPersonal)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gcCommentsPersonal;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCommentsPersonal;
        private DevExpress.XtraEditors.SimpleButton btnUpdateComment;
        private DevExpress.XtraEditors.SimpleButton btnDeleteComment;
        private System.Windows.Forms.Label lblClock;
        private DevExpress.XtraEditors.HyperlinkLabelControl lnkExcel;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}