
namespace Library.App.UserPanel
{
    partial class SeeComment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeeComment));
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.gcComments = new DevExpress.XtraGrid.GridControl();
            this.gvComments = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComments)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBack.Appearance.Options.UseFont = true;
            this.btnBack.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.ImageOptions.Image")));
            this.btnBack.Location = new System.Drawing.Point(41, 557);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnBack.Size = new System.Drawing.Size(165, 45);
            this.btnBack.TabIndex = 115;
            this.btnBack.Text = "Geri Dön";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // gcComments
            // 
            this.gcComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gcComments.Location = new System.Drawing.Point(41, 33);
            this.gcComments.MainView = this.gvComments;
            this.gcComments.Name = "gcComments";
            this.gcComments.Size = new System.Drawing.Size(1282, 509);
            this.gcComments.TabIndex = 116;
            this.gcComments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvComments});
            // 
            // gvComments
            // 
            this.gvComments.Appearance.Empty.BackColor = System.Drawing.SystemColors.ControlLight;
            this.gvComments.Appearance.Empty.Options.UseBackColor = true;
            this.gvComments.Appearance.EvenRow.BackColor = System.Drawing.Color.MediumAquamarine;
            this.gvComments.Appearance.EvenRow.BackColor2 = System.Drawing.Color.Moccasin;
            this.gvComments.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvComments.Appearance.FocusedRow.BackColor = System.Drawing.Color.Linen;
            this.gvComments.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.SeaShell;
            this.gvComments.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gvComments.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvComments.Appearance.FocusedRow.Options.UseFont = true;
            this.gvComments.Appearance.OddRow.BackColor = System.Drawing.Color.Plum;
            this.gvComments.Appearance.OddRow.BackColor2 = System.Drawing.Color.Moccasin;
            this.gvComments.Appearance.OddRow.Options.UseBackColor = true;
            this.gvComments.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gvComments.Appearance.Row.Options.UseFont = true;
            this.gvComments.Appearance.Row.Options.UseTextOptions = true;
            this.gvComments.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gvComments.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.gvComments.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.RosyBrown;
            formatConditionRuleExpression1.Appearance.BackColor2 = System.Drawing.Color.LavenderBlush;
            formatConditionRuleExpression1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression1.Appearance.Options.UseFont = true;
            formatConditionRuleExpression1.Expression = "[GeneralStatus] = 0";
            gridFormatRule1.Rule = formatConditionRuleExpression1;
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Name = "Format1";
            formatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.IndianRed;
            formatConditionRuleExpression2.Appearance.BackColor2 = System.Drawing.Color.LavenderBlush;
            formatConditionRuleExpression2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            formatConditionRuleExpression2.Appearance.Options.UseBackColor = true;
            formatConditionRuleExpression2.Appearance.Options.UseFont = true;
            formatConditionRuleExpression2.Expression = "[Stock] == 0";
            gridFormatRule2.Rule = formatConditionRuleExpression2;
            this.gvComments.FormatRules.Add(gridFormatRule1);
            this.gvComments.FormatRules.Add(gridFormatRule2);
            this.gvComments.GridControl = this.gcComments;
            this.gvComments.Name = "gvComments";
            this.gvComments.OptionsBehavior.Editable = false;
            this.gvComments.OptionsBehavior.ReadOnly = true;
            this.gvComments.OptionsCustomization.AllowFilter = false;
            this.gvComments.OptionsFind.AllowFindPanel = false;
            this.gvComments.OptionsMenu.EnableColumnMenu = false;
            this.gvComments.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvComments.OptionsView.EnableAppearanceEvenRow = true;
            this.gvComments.OptionsView.EnableAppearanceOddRow = true;
            this.gvComments.OptionsView.RowAutoHeight = true;
            this.gvComments.OptionsView.ShowGroupPanel = false;
            this.gvComments.OptionsView.ShowIndicator = false;
            this.gvComments.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // SeeComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 614);
            this.Controls.Add(this.gcComments);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SeeComment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeeComment";
            this.Load += new System.EventHandler(this.SeeComment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvComments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraGrid.GridControl gcComments;
        private DevExpress.XtraGrid.Views.Grid.GridView gvComments;
    }
}