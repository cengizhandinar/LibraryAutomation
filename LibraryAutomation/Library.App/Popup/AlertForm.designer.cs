
namespace Library.App.Popup
{
    partial class AlertForm
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnError = new DevExpress.XtraEditors.SimpleButton();
            this.btnWarning = new DevExpress.XtraEditors.SimpleButton();
            this.btnSuccess = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(84, 32);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(70, 16);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Message ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnInfo
            // 
            this.btnInfo.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnInfo.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnInfo.Appearance.Options.UseBorderColor = true;
            this.btnInfo.Appearance.Options.UseForeColor = true;
            this.btnInfo.ImageOptions.Image = global::Library.App.Properties.Resources.info_alt;
            this.btnInfo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnInfo.Location = new System.Drawing.Point(21, 12);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnInfo.Size = new System.Drawing.Size(57, 54);
            this.btnInfo.TabIndex = 1;
            this.btnInfo.Visible = false;
            // 
            // btnError
            // 
            this.btnError.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnError.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnError.Appearance.Options.UseBorderColor = true;
            this.btnError.Appearance.Options.UseForeColor = true;
            this.btnError.ImageOptions.Image = global::Library.App.Properties.Resources.error;
            this.btnError.Location = new System.Drawing.Point(21, 12);
            this.btnError.Name = "btnError";
            this.btnError.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnError.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnError.Size = new System.Drawing.Size(57, 54);
            this.btnError.TabIndex = 1;
            this.btnError.Visible = false;
            // 
            // btnWarning
            // 
            this.btnWarning.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnWarning.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnWarning.Appearance.Options.UseBorderColor = true;
            this.btnWarning.Appearance.Options.UseForeColor = true;
            this.btnWarning.ImageOptions.Image = global::Library.App.Properties.Resources.warning;
            this.btnWarning.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.btnWarning.Location = new System.Drawing.Point(21, 12);
            this.btnWarning.Name = "btnWarning";
            this.btnWarning.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnWarning.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnWarning.Size = new System.Drawing.Size(57, 54);
            this.btnWarning.TabIndex = 1;
            this.btnWarning.Visible = false;
            // 
            // btnSuccess
            // 
            this.btnSuccess.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.btnSuccess.Appearance.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnSuccess.Appearance.Options.UseBorderColor = true;
            this.btnSuccess.Appearance.Options.UseForeColor = true;
            this.btnSuccess.ImageOptions.Image = global::Library.App.Properties.Resources.success;
            this.btnSuccess.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.btnSuccess.Location = new System.Drawing.Point(21, 12);
            this.btnSuccess.Name = "btnSuccess";
            this.btnSuccess.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSuccess.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSuccess.Size = new System.Drawing.Size(57, 54);
            this.btnSuccess.TabIndex = 1;
            // 
            // AlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Brown;
            this.ClientSize = new System.Drawing.Size(755, 81);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnError);
            this.Controls.Add(this.btnWarning);
            this.Controls.Add(this.btnSuccess);
            this.Controls.Add(this.lblMessage);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AlertForm";
            this.Text = "AlertForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private DevExpress.XtraEditors.SimpleButton btnSuccess;
        private DevExpress.XtraEditors.SimpleButton btnWarning;
        private DevExpress.XtraEditors.SimpleButton btnError;
        private DevExpress.XtraEditors.SimpleButton btnInfo;
        internal System.Windows.Forms.Timer timer1;
    }
}