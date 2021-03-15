
namespace Library.App.UserPanel
{
    partial class Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Profile));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gbUser = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnFreezeAccount = new DevExpress.XtraEditors.SimpleButton();
            this.lblFavoriteCount = new System.Windows.Forms.Label();
            this.lblLendedCount = new System.Windows.Forms.Label();
            this.lblReadedCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImgReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnImage = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbGender = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dateBirth = new DevExpress.XtraEditors.DateEdit();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtMail = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtSurname = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTelephone = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAbout = new DevExpress.XtraEditors.MemoEdit();
            this.gbUser.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGender.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbout.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            // 
            // gbUser
            // 
            this.gbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUser.Controls.Add(this.panel1);
            this.gbUser.Controls.Add(this.lblFavoriteCount);
            this.gbUser.Controls.Add(this.lblLendedCount);
            this.gbUser.Controls.Add(this.lblReadedCount);
            this.gbUser.Controls.Add(this.label7);
            this.gbUser.Controls.Add(this.label5);
            this.gbUser.Controls.Add(this.label1);
            this.gbUser.Controls.Add(this.btnImgReset);
            this.gbUser.Controls.Add(this.btnImage);
            this.gbUser.Controls.Add(this.pictureBox1);
            this.gbUser.Controls.Add(this.label15);
            this.gbUser.Controls.Add(this.cbGender);
            this.gbUser.Controls.Add(this.dateBirth);
            this.gbUser.Controls.Add(this.txtUsername);
            this.gbUser.Controls.Add(this.txtPassword);
            this.gbUser.Controls.Add(this.txtMail);
            this.gbUser.Controls.Add(this.txtName);
            this.gbUser.Controls.Add(this.txtSurname);
            this.gbUser.Controls.Add(this.label3);
            this.gbUser.Controls.Add(this.label16);
            this.gbUser.Controls.Add(this.label6);
            this.gbUser.Controls.Add(this.label4);
            this.gbUser.Controls.Add(this.label8);
            this.gbUser.Controls.Add(this.label14);
            this.gbUser.Controls.Add(this.txtTelephone);
            this.gbUser.Controls.Add(this.label2);
            this.gbUser.Controls.Add(this.label13);
            this.gbUser.Controls.Add(this.txtAbout);
            this.gbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.gbUser.Location = new System.Drawing.Point(22, 12);
            this.gbUser.Name = "gbUser";
            this.gbUser.Size = new System.Drawing.Size(1263, 687);
            this.gbUser.TabIndex = 2;
            this.gbUser.TabStop = false;
            this.gbUser.Text = "Profil Bilgilerim";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnFreezeAccount);
            this.panel1.Location = new System.Drawing.Point(892, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 245);
            this.panel1.TabIndex = 98;
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnDelete.Location = new System.Drawing.Point(0, 188);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnDelete.Size = new System.Drawing.Size(199, 54);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Hesabı Sil";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnSave.Location = new System.Drawing.Point(0, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSave.Size = new System.Drawing.Size(199, 54);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Güncelle";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
            this.btnClear.Location = new System.Drawing.Point(0, 66);
            this.btnClear.Name = "btnClear";
            this.btnClear.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnClear.Size = new System.Drawing.Size(199, 54);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Temizle";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFreezeAccount
            // 
            this.btnFreezeAccount.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFreezeAccount.Appearance.Options.UseFont = true;
            this.btnFreezeAccount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFreezeAccount.ImageOptions.Image")));
            this.btnFreezeAccount.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnFreezeAccount.Location = new System.Drawing.Point(0, 126);
            this.btnFreezeAccount.Name = "btnFreezeAccount";
            this.btnFreezeAccount.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnFreezeAccount.Size = new System.Drawing.Size(199, 54);
            this.btnFreezeAccount.TabIndex = 90;
            this.btnFreezeAccount.Text = "Hesabı Dondur";
            this.btnFreezeAccount.Click += new System.EventHandler(this.btnFreezeAccount_Click);
            // 
            // lblFavoriteCount
            // 
            this.lblFavoriteCount.AutoSize = true;
            this.lblFavoriteCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFavoriteCount.Location = new System.Drawing.Point(279, 491);
            this.lblFavoriteCount.Name = "lblFavoriteCount";
            this.lblFavoriteCount.Size = new System.Drawing.Size(17, 18);
            this.lblFavoriteCount.TabIndex = 97;
            this.lblFavoriteCount.Text = "0";
            // 
            // lblLendedCount
            // 
            this.lblLendedCount.AutoSize = true;
            this.lblLendedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblLendedCount.Location = new System.Drawing.Point(279, 447);
            this.lblLendedCount.Name = "lblLendedCount";
            this.lblLendedCount.Size = new System.Drawing.Size(17, 18);
            this.lblLendedCount.TabIndex = 96;
            this.lblLendedCount.Text = "0";
            // 
            // lblReadedCount
            // 
            this.lblReadedCount.AutoSize = true;
            this.lblReadedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblReadedCount.Location = new System.Drawing.Point(279, 406);
            this.lblReadedCount.Name = "lblReadedCount";
            this.lblReadedCount.Size = new System.Drawing.Size(17, 18);
            this.lblReadedCount.TabIndex = 95;
            this.lblReadedCount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.BlueViolet;
            this.label7.Location = new System.Drawing.Point(44, 491);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 17);
            this.label7.TabIndex = 94;
            this.label7.Text = "Favorilerimdeki Kitap Sayısı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(44, 447);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 17);
            this.label5.TabIndex = 93;
            this.label5.Text = "Emanet Aldığım Kitap Sayısı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(44, 406);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 17);
            this.label1.TabIndex = 92;
            this.label1.Text = "Okuduğum Kitap Sayısı:";
            // 
            // btnImgReset
            // 
            this.btnImgReset.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnImgReset.Appearance.Options.UseFont = true;
            this.btnImgReset.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnImgReset.Location = new System.Drawing.Point(181, 350);
            this.btnImgReset.Name = "btnImgReset";
            this.btnImgReset.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnImgReset.Size = new System.Drawing.Size(58, 23);
            this.btnImgReset.TabIndex = 91;
            this.btnImgReset.Text = "Sıfırla";
            this.btnImgReset.Click += new System.EventHandler(this.btnImgReset_Click);
            // 
            // btnImage
            // 
            this.btnImage.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnImage.Appearance.Options.UseFont = true;
            this.btnImage.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.btnImage.Location = new System.Drawing.Point(245, 350);
            this.btnImage.Name = "btnImage";
            this.btnImage.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnImage.Size = new System.Drawing.Size(58, 23);
            this.btnImage.TabIndex = 89;
            this.btnImage.Text = "Seç";
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(47, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 306);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 88;
            this.pictureBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(373, 406);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 17);
            this.label15.TabIndex = 85;
            this.label15.Text = "Hakkında:";
            // 
            // cbGender
            // 
            this.cbGender.Location = new System.Drawing.Point(504, 308);
            this.cbGender.Name = "cbGender";
            this.cbGender.Properties.AllowFocused = false;
            this.cbGender.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbGender.Properties.Items.AddRange(new object[] {
            "Erkek",
            "Kadın",
            "Belirtmek İstemiyorum"});
            this.cbGender.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbGender.Size = new System.Drawing.Size(238, 20);
            this.cbGender.TabIndex = 7;
            // 
            // dateBirth
            // 
            this.dateBirth.EditValue = null;
            this.dateBirth.Location = new System.Drawing.Point(504, 355);
            this.dateBirth.Name = "dateBirth";
            this.dateBirth.Properties.AllowFocused = false;
            this.dateBirth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBirth.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateBirth.Properties.CalendarTimeProperties.Mask.EditMask = "";
            this.dateBirth.Properties.CalendarTimeProperties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dateBirth.Properties.Mask.EditMask = "";
            this.dateBirth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dateBirth.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateBirth.Size = new System.Drawing.Size(238, 20);
            this.dateBirth.TabIndex = 6;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(504, 125);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.AllowFocused = false;
            this.txtUsername.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtUsername.Properties.Mask.EditMask = "\\S*";
            this.txtUsername.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtUsername.Properties.Mask.ShowPlaceHolders = false;
            this.txtUsername.Properties.MaxLength = 50;
            this.txtUsername.Properties.NullValuePrompt = "Kullanıcı Adı";
            this.txtUsername.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtUsername.Size = new System.Drawing.Size(238, 22);
            this.txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(504, 172);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.AllowFocused = false;
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPassword.Properties.MaxLength = 8;
            this.txtPassword.Properties.NullValuePrompt = "Şifre";
            this.txtPassword.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtPassword.Size = new System.Drawing.Size(238, 22);
            this.txtPassword.TabIndex = 5;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(504, 216);
            this.txtMail.Name = "txtMail";
            this.txtMail.Properties.AllowFocused = false;
            this.txtMail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtMail.Properties.Mask.EditMask = "(\\w|[\\.\\-])+@(\\w|[\\-]+\\.)*(\\w|[\\-]){2,63}\\.[a-zA-Z]{2,4}";
            this.txtMail.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtMail.Properties.Mask.ShowPlaceHolders = false;
            this.txtMail.Properties.MaxLength = 75;
            this.txtMail.Properties.NullValuePrompt = "Mail Adresi";
            this.txtMail.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtMail.Size = new System.Drawing.Size(238, 22);
            this.txtMail.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(504, 34);
            this.txtName.Name = "txtName";
            this.txtName.Properties.AllowFocused = false;
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtName.Properties.MaxLength = 30;
            this.txtName.Properties.NullValuePrompt = "Ad";
            this.txtName.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtName.Size = new System.Drawing.Size(238, 22);
            this.txtName.TabIndex = 2;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(504, 77);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Properties.AllowFocused = false;
            this.txtSurname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSurname.Properties.MaxLength = 30;
            this.txtSurname.Properties.NullValuePrompt = "Soyad";
            this.txtSurname.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtSurname.Size = new System.Drawing.Size(238, 22);
            this.txtSurname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(371, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Şifre:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(371, 127);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(102, 17);
            this.label16.TabIndex = 83;
            this.label16.Text = "Kullanıcı Adı:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(373, 218);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Mail Adresi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(373, 261);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Telefon:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(373, 356);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Doğum Tarihi:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(371, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 17);
            this.label14.TabIndex = 80;
            this.label14.Text = "Adı:";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(504, 259);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Properties.AllowFocused = false;
            this.txtTelephone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTelephone.Properties.Mask.EditMask = "(999) 000-0000";
            this.txtTelephone.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.txtTelephone.Properties.Mask.SaveLiteral = false;
            this.txtTelephone.Properties.Mask.ShowPlaceHolders = false;
            this.txtTelephone.Properties.MaxLength = 13;
            this.txtTelephone.Properties.NullValuePrompt = "Telefon";
            this.txtTelephone.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtTelephone.Size = new System.Drawing.Size(238, 22);
            this.txtTelephone.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(371, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 79;
            this.label2.Text = "Soyadı:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(373, 309);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 17);
            this.label13.TabIndex = 79;
            this.label13.Text = "Cinsiyet:";
            // 
            // txtAbout
            // 
            this.txtAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAbout.Location = new System.Drawing.Point(504, 404);
            this.txtAbout.Name = "txtAbout";
            this.txtAbout.Properties.AllowFocused = false;
            this.txtAbout.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAbout.Properties.Appearance.Options.UseFont = true;
            this.txtAbout.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtAbout.Properties.MaxLength = 1000;
            this.txtAbout.Properties.NullValuePrompt = "Hakkında";
            this.txtAbout.Properties.ShowNullValuePrompt = ((DevExpress.XtraEditors.ShowNullValuePromptOptions)((DevExpress.XtraEditors.ShowNullValuePromptOptions.EmptyValue | DevExpress.XtraEditors.ShowNullValuePromptOptions.EditorReadOnly)));
            this.txtAbout.Size = new System.Drawing.Size(587, 187);
            this.txtAbout.TabIndex = 87;
            // 
            // Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 711);
            this.Controls.Add(this.gbUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Profile";
            this.Text = "Profile";
            this.Load += new System.EventHandler(this.Profile_Load);
            this.gbUser.ResumeLayout(false);
            this.gbUser.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbGender.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateBirth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelephone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbout.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox gbUser;
        private DevExpress.XtraEditors.SimpleButton btnImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.ComboBoxEdit cbGender;
        private DevExpress.XtraEditors.DateEdit dateBirth;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtMail;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtSurname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.TextEdit txtTelephone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.MemoEdit txtAbout;
        private DevExpress.XtraEditors.SimpleButton btnImgReset;
        private DevExpress.XtraEditors.SimpleButton btnFreezeAccount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFavoriteCount;
        private System.Windows.Forms.Label lblLendedCount;
        private System.Windows.Forms.Label lblReadedCount;
        private System.Windows.Forms.Panel panel1;
    }
}