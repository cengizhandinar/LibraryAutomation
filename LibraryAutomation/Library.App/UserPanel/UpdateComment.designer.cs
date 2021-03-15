
namespace Library.App.UserPanel
{
    partial class UpdateComment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateComment));
            this.gbComment = new System.Windows.Forms.GroupBox();
            this.ratingControl1 = new DevExpress.XtraEditors.RatingControl();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.txtBookName = new DevExpress.XtraEditors.TextEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComment = new DevExpress.XtraEditors.MemoEdit();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.gbComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratingControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gbComment
            // 
            this.gbComment.Controls.Add(this.ratingControl1);
            this.gbComment.Controls.Add(this.btnUpdate);
            this.gbComment.Controls.Add(this.txtBookName);
            this.gbComment.Controls.Add(this.label10);
            this.gbComment.Controls.Add(this.label4);
            this.gbComment.Controls.Add(this.label3);
            this.gbComment.Controls.Add(this.txtComment);
            this.gbComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbComment.Location = new System.Drawing.Point(12, 12);
            this.gbComment.Name = "gbComment";
            this.gbComment.Size = new System.Drawing.Size(699, 317);
            this.gbComment.TabIndex = 109;
            this.gbComment.TabStop = false;
            this.gbComment.Text = "Yorum Bilgileri";
            // 
            // ratingControl1
            // 
            this.ratingControl1.Location = new System.Drawing.Point(161, 252);
            this.ratingControl1.Name = "ratingControl1";
            this.ratingControl1.Rating = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ratingControl1.Size = new System.Drawing.Size(92, 16);
            this.ratingControl1.TabIndex = 116;
            this.ratingControl1.Text = "ratingControl1";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.Image")));
            this.btnUpdate.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnUpdate.Location = new System.Drawing.Point(480, 234);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnUpdate.Size = new System.Drawing.Size(155, 49);
            this.btnUpdate.TabIndex = 113;
            this.btnUpdate.Text = "Yorumu Güncelle";
            this.btnUpdate.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBookName
            // 
            this.txtBookName.Enabled = false;
            this.txtBookName.Location = new System.Drawing.Point(161, 32);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Properties.AllowFocused = false;
            this.txtBookName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtBookName.Properties.NullValuePrompt = "Ad";
            this.txtBookName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtBookName.Size = new System.Drawing.Size(260, 22);
            this.txtBookName.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(8, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 17);
            this.label10.TabIndex = 93;
            this.label10.Text = "Kitap Adı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(8, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 106;
            this.label4.Text = "Puanınız:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 107;
            this.label3.Text = "Yorumunuz:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(161, 79);
            this.txtComment.Name = "txtComment";
            this.txtComment.Properties.AllowFocused = false;
            this.txtComment.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtComment.Properties.Appearance.Options.UseFont = true;
            this.txtComment.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtComment.Properties.MaxLength = 300;
            this.txtComment.Properties.NullValuePrompt = "Açıklama";
            this.txtComment.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtComment.Size = new System.Drawing.Size(474, 141);
            this.txtComment.TabIndex = 108;
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
            // UpdateComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 396);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.gbComment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateComment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateComment";
            this.Load += new System.EventHandler(this.UpdateComment_Load);
            this.gbComment.ResumeLayout(false);
            this.gbComment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ratingControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBookName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbComment;
        private DevExpress.XtraEditors.TextEdit txtBookName;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.MemoEdit txtComment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.RatingControl ratingControl1;
    }
}