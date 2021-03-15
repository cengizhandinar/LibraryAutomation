
namespace Library.App.UserPanel
{
    partial class Contact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contact));
            this.gbComment = new System.Windows.Forms.GroupBox();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMessage = new DevExpress.XtraEditors.MemoEdit();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.gbComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbComment
            // 
            this.gbComment.Controls.Add(this.btnSave);
            this.gbComment.Controls.Add(this.label3);
            this.gbComment.Controls.Add(this.txtMessage);
            this.gbComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbComment.Location = new System.Drawing.Point(12, 12);
            this.gbComment.Name = "gbComment";
            this.gbComment.Size = new System.Drawing.Size(699, 317);
            this.gbComment.TabIndex = 109;
            this.gbComment.TabStop = false;
            this.gbComment.Text = "Mesaj Bilgileri";
            // 
            // btnSave
            // 
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnSave.Location = new System.Drawing.Point(514, 257);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSave.Size = new System.Drawing.Size(121, 36);
            this.btnSave.TabIndex = 113;
            this.btnSave.Text = "Mesajı Gönder";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 107;
            this.label3.Text = "Mesajınız:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(126, 36);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Properties.AllowFocused = false;
            this.txtMessage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMessage.Properties.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.txtMessage.Properties.Appearance.Options.UseFont = true;
            this.txtMessage.Properties.Appearance.Options.UseForeColor = true;
            this.txtMessage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtMessage.Properties.MaxLength = 300;
            this.txtMessage.Properties.NullValuePrompt = "Açıklama";
            this.txtMessage.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtMessage.Size = new System.Drawing.Size(509, 215);
            this.txtMessage.TabIndex = 108;
            // 
            // btnBack
            // 
            this.btnBack.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.ImageOptions.Image")));
            this.btnBack.Location = new System.Drawing.Point(21, 344);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnBack.Size = new System.Drawing.Size(121, 36);
            this.btnBack.TabIndex = 115;
            this.btnBack.Text = "Geri Dön";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Contact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 396);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gbComment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Contact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact";
            this.gbComment.ResumeLayout(false);
            this.gbComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbComment;
        private DevExpress.XtraEditors.MemoEdit txtMessage;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnBack;
    }
}