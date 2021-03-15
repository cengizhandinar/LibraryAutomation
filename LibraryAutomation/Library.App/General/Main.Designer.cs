
namespace Library.App.General
{
    partial class Main
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.topPanel = new DevExpress.Utils.Layout.StackPanel();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnUserInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnBookInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnCategoryInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnWriterInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnPublisherInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnCommentInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnContactInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnUserBookInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnUserRoleInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnBookCategoryInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnControlCenter = new DevExpress.XtraEditors.SimpleButton();
            this.adminPanel = new DevExpress.Utils.Layout.StackPanel();
            this.btnAdminClose = new DevExpress.XtraEditors.SimpleButton();
            this.footerPanel = new DevExpress.Utils.Layout.StackPanel();
            this.lblCompanyName = new DevExpress.XtraEditors.LabelControl();
            this.btnArchive = new DevExpress.XtraEditors.SimpleButton();
            this.btnMyFavorites = new DevExpress.XtraEditors.SimpleButton();
            this.btnHaveRead = new DevExpress.XtraEditors.SimpleButton();
            this.btnMyComments = new DevExpress.XtraEditors.SimpleButton();
            this.btnWriters = new DevExpress.XtraEditors.SimpleButton();
            this.btnMyProfile = new DevExpress.XtraEditors.SimpleButton();
            this.btnMyContacts = new DevExpress.XtraEditors.SimpleButton();
            this.userPanel = new DevExpress.Utils.Layout.StackPanel();
            this.btnWillRead = new DevExpress.XtraEditors.SimpleButton();
            this.btnMyEscrowList = new DevExpress.XtraEditors.SimpleButton();
            this.btnUserClose = new DevExpress.XtraEditors.SimpleButton();
            this.centerPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.topPanel)).BeginInit();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminPanel)).BeginInit();
            this.adminPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).BeginInit();
            this.footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPanel)).BeginInit();
            this.userPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Appearance.BackColor = System.Drawing.Color.MistyRose;
            this.topPanel.Appearance.BackColor2 = System.Drawing.Color.LightBlue;
            this.topPanel.Appearance.Options.UseBackColor = true;
            this.topPanel.Controls.Add(this.btnLogin);
            this.topPanel.Controls.Add(this.btnExit);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 124);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1456, 70);
            this.topPanel.TabIndex = 11;
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.AutoSize = true;
            this.btnLogin.AutoWidthInLayoutControl = true;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLogin.ImageOptions.SvgImage")));
            this.btnLogin.Location = new System.Drawing.Point(3, 17);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnLogin.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnLogin.Size = new System.Drawing.Size(140, 36);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Kullanıcı Girişi";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.AutoSize = true;
            this.btnExit.AutoWidthInLayoutControl = true;
            this.btnExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExit.ImageOptions.SvgImage")));
            this.btnExit.Location = new System.Drawing.Point(149, 17);
            this.btnExit.Name = "btnExit";
            this.btnExit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnExit.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnExit.Size = new System.Drawing.Size(77, 36);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Çıkış";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUserInfo
            // 
            this.btnUserInfo.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUserInfo.Appearance.Options.UseFont = true;
            this.btnUserInfo.AutoSize = true;
            this.btnUserInfo.AutoWidthInLayoutControl = true;
            this.btnUserInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUserInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUserInfo.ImageOptions.Image")));
            this.btnUserInfo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnUserInfo.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnUserInfo.Location = new System.Drawing.Point(3, 3);
            this.btnUserInfo.Name = "btnUserInfo";
            this.btnUserInfo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnUserInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnUserInfo.Size = new System.Drawing.Size(111, 55);
            this.btnUserInfo.TabIndex = 6;
            this.btnUserInfo.Text = "Kullanıcı İşlemleri";
            this.btnUserInfo.Click += new System.EventHandler(this.btnUserInfo_Click);
            // 
            // btnBookInfo
            // 
            this.btnBookInfo.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBookInfo.Appearance.Options.UseFont = true;
            this.btnBookInfo.AutoSize = true;
            this.btnBookInfo.AutoWidthInLayoutControl = true;
            this.btnBookInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBookInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBookInfo.ImageOptions.Image")));
            this.btnBookInfo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnBookInfo.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnBookInfo.Location = new System.Drawing.Point(120, 3);
            this.btnBookInfo.Name = "btnBookInfo";
            this.btnBookInfo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnBookInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnBookInfo.Size = new System.Drawing.Size(89, 55);
            this.btnBookInfo.TabIndex = 7;
            this.btnBookInfo.Text = "Kitap İşlemleri";
            this.btnBookInfo.Click += new System.EventHandler(this.btnBookInfo_Click);
            // 
            // btnCategoryInfo
            // 
            this.btnCategoryInfo.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCategoryInfo.Appearance.Options.UseFont = true;
            this.btnCategoryInfo.AutoSize = true;
            this.btnCategoryInfo.AutoWidthInLayoutControl = true;
            this.btnCategoryInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCategoryInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoryInfo.ImageOptions.Image")));
            this.btnCategoryInfo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCategoryInfo.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnCategoryInfo.Location = new System.Drawing.Point(215, 3);
            this.btnCategoryInfo.Name = "btnCategoryInfo";
            this.btnCategoryInfo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnCategoryInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnCategoryInfo.Size = new System.Drawing.Size(108, 55);
            this.btnCategoryInfo.TabIndex = 4;
            this.btnCategoryInfo.Text = "Kategori İşlemleri";
            this.btnCategoryInfo.Click += new System.EventHandler(this.btnCategoryInfo_Click);
            // 
            // btnWriterInfo
            // 
            this.btnWriterInfo.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnWriterInfo.Appearance.Options.UseFont = true;
            this.btnWriterInfo.AutoSize = true;
            this.btnWriterInfo.AutoWidthInLayoutControl = true;
            this.btnWriterInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnWriterInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWriterInfo.ImageOptions.Image")));
            this.btnWriterInfo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnWriterInfo.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnWriterInfo.Location = new System.Drawing.Point(329, 3);
            this.btnWriterInfo.Name = "btnWriterInfo";
            this.btnWriterInfo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnWriterInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnWriterInfo.Size = new System.Drawing.Size(92, 55);
            this.btnWriterInfo.TabIndex = 10;
            this.btnWriterInfo.Text = "Yazar İşlemleri";
            this.btnWriterInfo.Click += new System.EventHandler(this.btnWriterInfo_Click);
            // 
            // btnPublisherInfo
            // 
            this.btnPublisherInfo.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPublisherInfo.Appearance.Options.UseFont = true;
            this.btnPublisherInfo.AutoSize = true;
            this.btnPublisherInfo.AutoWidthInLayoutControl = true;
            this.btnPublisherInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPublisherInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPublisherInfo.ImageOptions.Image")));
            this.btnPublisherInfo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnPublisherInfo.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnPublisherInfo.Location = new System.Drawing.Point(427, 3);
            this.btnPublisherInfo.Name = "btnPublisherInfo";
            this.btnPublisherInfo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnPublisherInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnPublisherInfo.Size = new System.Drawing.Size(106, 55);
            this.btnPublisherInfo.TabIndex = 14;
            this.btnPublisherInfo.Text = "Yayınevi İşlemleri";
            this.btnPublisherInfo.Click += new System.EventHandler(this.btnPublisherInfo_Click);
            // 
            // btnCommentInfo
            // 
            this.btnCommentInfo.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCommentInfo.Appearance.Options.UseFont = true;
            this.btnCommentInfo.AutoSize = true;
            this.btnCommentInfo.AutoWidthInLayoutControl = true;
            this.btnCommentInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCommentInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCommentInfo.ImageOptions.Image")));
            this.btnCommentInfo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCommentInfo.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnCommentInfo.Location = new System.Drawing.Point(539, 3);
            this.btnCommentInfo.Name = "btnCommentInfo";
            this.btnCommentInfo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnCommentInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnCommentInfo.Size = new System.Drawing.Size(97, 55);
            this.btnCommentInfo.TabIndex = 3;
            this.btnCommentInfo.Text = "Yorum İşlemleri";
            this.btnCommentInfo.Click += new System.EventHandler(this.btnCommentInfo_Click);
            // 
            // btnContactInfo
            // 
            this.btnContactInfo.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnContactInfo.Appearance.Options.UseFont = true;
            this.btnContactInfo.AutoSize = true;
            this.btnContactInfo.AutoWidthInLayoutControl = true;
            this.btnContactInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnContactInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnContactInfo.ImageOptions.Image")));
            this.btnContactInfo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnContactInfo.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnContactInfo.Location = new System.Drawing.Point(642, 3);
            this.btnContactInfo.Name = "btnContactInfo";
            this.btnContactInfo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnContactInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnContactInfo.Size = new System.Drawing.Size(93, 55);
            this.btnContactInfo.TabIndex = 2;
            this.btnContactInfo.Text = "Mesaj İşlemleri";
            this.btnContactInfo.Click += new System.EventHandler(this.btnContactInfo_Click);
            // 
            // btnUserBookInfo
            // 
            this.btnUserBookInfo.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUserBookInfo.Appearance.Options.UseFont = true;
            this.btnUserBookInfo.AutoSize = true;
            this.btnUserBookInfo.AutoWidthInLayoutControl = true;
            this.btnUserBookInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUserBookInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUserBookInfo.ImageOptions.Image")));
            this.btnUserBookInfo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnUserBookInfo.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnUserBookInfo.Location = new System.Drawing.Point(741, 3);
            this.btnUserBookInfo.Name = "btnUserBookInfo";
            this.btnUserBookInfo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnUserBookInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnUserBookInfo.Size = new System.Drawing.Size(144, 55);
            this.btnUserBookInfo.TabIndex = 9;
            this.btnUserBookInfo.Text = "Kullanıcı-Kitap İşlemleri";
            this.btnUserBookInfo.Click += new System.EventHandler(this.btnUserBookInfo_Click);
            // 
            // btnUserRoleInfo
            // 
            this.btnUserRoleInfo.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUserRoleInfo.Appearance.Options.UseFont = true;
            this.btnUserRoleInfo.AutoSize = true;
            this.btnUserRoleInfo.AutoWidthInLayoutControl = true;
            this.btnUserRoleInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUserRoleInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUserRoleInfo.ImageOptions.Image")));
            this.btnUserRoleInfo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnUserRoleInfo.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnUserRoleInfo.Location = new System.Drawing.Point(891, 3);
            this.btnUserRoleInfo.Name = "btnUserRoleInfo";
            this.btnUserRoleInfo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnUserRoleInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnUserRoleInfo.Size = new System.Drawing.Size(134, 55);
            this.btnUserRoleInfo.TabIndex = 8;
            this.btnUserRoleInfo.Text = "Kullanıcı-Rol İşlemleri";
            this.btnUserRoleInfo.Click += new System.EventHandler(this.btnUserRoleInfo_Click);
            // 
            // btnBookCategoryInfo
            // 
            this.btnBookCategoryInfo.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBookCategoryInfo.Appearance.Options.UseFont = true;
            this.btnBookCategoryInfo.AutoSize = true;
            this.btnBookCategoryInfo.AutoWidthInLayoutControl = true;
            this.btnBookCategoryInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBookCategoryInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBookCategoryInfo.ImageOptions.Image")));
            this.btnBookCategoryInfo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnBookCategoryInfo.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnBookCategoryInfo.Location = new System.Drawing.Point(1031, 3);
            this.btnBookCategoryInfo.Name = "btnBookCategoryInfo";
            this.btnBookCategoryInfo.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnBookCategoryInfo.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnBookCategoryInfo.Size = new System.Drawing.Size(141, 55);
            this.btnBookCategoryInfo.TabIndex = 5;
            this.btnBookCategoryInfo.Text = "Kitap-Kategori İşlemleri";
            this.btnBookCategoryInfo.Click += new System.EventHandler(this.btnBookCategoryInfo_Click);
            // 
            // btnControlCenter
            // 
            this.btnControlCenter.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnControlCenter.Appearance.Options.UseFont = true;
            this.btnControlCenter.AutoSize = true;
            this.btnControlCenter.AutoWidthInLayoutControl = true;
            this.btnControlCenter.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnControlCenter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnControlCenter.ImageOptions.Image")));
            this.btnControlCenter.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnControlCenter.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnControlCenter.Location = new System.Drawing.Point(1178, 3);
            this.btnControlCenter.Name = "btnControlCenter";
            this.btnControlCenter.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnControlCenter.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnControlCenter.Size = new System.Drawing.Size(99, 55);
            this.btnControlCenter.TabIndex = 15;
            this.btnControlCenter.Text = "Kontrol Merkezi";
            this.btnControlCenter.Click += new System.EventHandler(this.btnControlCenter_Click);
            // 
            // adminPanel
            // 
            this.adminPanel.Appearance.BackColor = System.Drawing.Color.MistyRose;
            this.adminPanel.Appearance.BackColor2 = System.Drawing.Color.LightBlue;
            this.adminPanel.Appearance.Options.UseBackColor = true;
            this.adminPanel.AutoSize = true;
            this.adminPanel.Controls.Add(this.btnUserInfo);
            this.adminPanel.Controls.Add(this.btnBookInfo);
            this.adminPanel.Controls.Add(this.btnCategoryInfo);
            this.adminPanel.Controls.Add(this.btnWriterInfo);
            this.adminPanel.Controls.Add(this.btnPublisherInfo);
            this.adminPanel.Controls.Add(this.btnCommentInfo);
            this.adminPanel.Controls.Add(this.btnContactInfo);
            this.adminPanel.Controls.Add(this.btnUserBookInfo);
            this.adminPanel.Controls.Add(this.btnUserRoleInfo);
            this.adminPanel.Controls.Add(this.btnBookCategoryInfo);
            this.adminPanel.Controls.Add(this.btnControlCenter);
            this.adminPanel.Controls.Add(this.btnAdminClose);
            this.adminPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.adminPanel.Location = new System.Drawing.Point(0, 63);
            this.adminPanel.Name = "adminPanel";
            this.adminPanel.Size = new System.Drawing.Size(1456, 61);
            this.adminPanel.TabIndex = 13;
            this.adminPanel.Visible = false;
            // 
            // btnAdminClose
            // 
            this.btnAdminClose.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdminClose.Appearance.Options.UseFont = true;
            this.btnAdminClose.AutoSize = true;
            this.btnAdminClose.AutoWidthInLayoutControl = true;
            this.btnAdminClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdminClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdminClose.ImageOptions.Image")));
            this.btnAdminClose.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnAdminClose.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnAdminClose.Location = new System.Drawing.Point(1283, 3);
            this.btnAdminClose.Name = "btnAdminClose";
            this.btnAdminClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAdminClose.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnAdminClose.Size = new System.Drawing.Size(38, 55);
            this.btnAdminClose.TabIndex = 11;
            this.btnAdminClose.Text = "Çıkış";
            this.btnAdminClose.Click += new System.EventHandler(this.btnAdminClose_Click);
            // 
            // footerPanel
            // 
            this.footerPanel.Appearance.BackColor = System.Drawing.Color.LightBlue;
            this.footerPanel.Appearance.BackColor2 = System.Drawing.Color.MistyRose;
            this.footerPanel.Appearance.Options.UseBackColor = true;
            this.footerPanel.Controls.Add(this.lblCompanyName);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.RightToLeft;
            this.footerPanel.Location = new System.Drawing.Point(0, 616);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new System.Drawing.Size(1456, 50);
            this.footerPanel.TabIndex = 12;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCompanyName.Appearance.Options.UseFont = true;
            this.lblCompanyName.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCompanyName.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("lblCompanyName.ImageOptions.SvgImage")));
            this.lblCompanyName.Location = new System.Drawing.Point(1223, 9);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(230, 32);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "            ACAY Bilgi Yönetim Sistemi  ";
            // 
            // btnArchive
            // 
            this.btnArchive.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnArchive.Appearance.Options.UseFont = true;
            this.btnArchive.AutoSize = true;
            this.btnArchive.AutoWidthInLayoutControl = true;
            this.btnArchive.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnArchive.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnArchive.ImageOptions.Image")));
            this.btnArchive.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnArchive.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.btnArchive.Location = new System.Drawing.Point(3, 3);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnArchive.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnArchive.Size = new System.Drawing.Size(43, 57);
            this.btnArchive.TabIndex = 2;
            this.btnArchive.Text = "Arşiv";
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // btnMyFavorites
            // 
            this.btnMyFavorites.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMyFavorites.Appearance.Options.UseFont = true;
            this.btnMyFavorites.AutoSize = true;
            this.btnMyFavorites.AutoWidthInLayoutControl = true;
            this.btnMyFavorites.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMyFavorites.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMyFavorites.ImageOptions.Image")));
            this.btnMyFavorites.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnMyFavorites.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.btnMyFavorites.Location = new System.Drawing.Point(52, 3);
            this.btnMyFavorites.Name = "btnMyFavorites";
            this.btnMyFavorites.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnMyFavorites.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnMyFavorites.Size = new System.Drawing.Size(83, 57);
            this.btnMyFavorites.TabIndex = 6;
            this.btnMyFavorites.Text = "Favorilerim";
            this.btnMyFavorites.Click += new System.EventHandler(this.btnMyFavorites_Click);
            // 
            // btnHaveRead
            // 
            this.btnHaveRead.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHaveRead.Appearance.Options.UseFont = true;
            this.btnHaveRead.AutoSize = true;
            this.btnHaveRead.AutoWidthInLayoutControl = true;
            this.btnHaveRead.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnHaveRead.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHaveRead.ImageOptions.Image")));
            this.btnHaveRead.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnHaveRead.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.btnHaveRead.Location = new System.Drawing.Point(141, 3);
            this.btnHaveRead.Name = "btnHaveRead";
            this.btnHaveRead.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnHaveRead.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnHaveRead.Size = new System.Drawing.Size(94, 57);
            this.btnHaveRead.TabIndex = 12;
            this.btnHaveRead.Text = "Okuduklarım";
            this.btnHaveRead.Click += new System.EventHandler(this.btnHaveRead_Click);
            // 
            // btnMyComments
            // 
            this.btnMyComments.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMyComments.Appearance.Options.UseFont = true;
            this.btnMyComments.AutoSize = true;
            this.btnMyComments.AutoWidthInLayoutControl = true;
            this.btnMyComments.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMyComments.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMyComments.ImageOptions.Image")));
            this.btnMyComments.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnMyComments.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.btnMyComments.Location = new System.Drawing.Point(466, 3);
            this.btnMyComments.Name = "btnMyComments";
            this.btnMyComments.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnMyComments.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnMyComments.Size = new System.Drawing.Size(84, 57);
            this.btnMyComments.TabIndex = 4;
            this.btnMyComments.Text = "Yorumlarım";
            this.btnMyComments.Click += new System.EventHandler(this.btnMyComments_Click);
            // 
            // btnWriters
            // 
            this.btnWriters.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnWriters.Appearance.Options.UseFont = true;
            this.btnWriters.AutoSize = true;
            this.btnWriters.AutoWidthInLayoutControl = true;
            this.btnWriters.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnWriters.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWriters.ImageOptions.Image")));
            this.btnWriters.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnWriters.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.btnWriters.Location = new System.Drawing.Point(556, 3);
            this.btnWriters.Name = "btnWriters";
            this.btnWriters.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnWriters.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnWriters.Size = new System.Drawing.Size(60, 57);
            this.btnWriters.TabIndex = 3;
            this.btnWriters.Text = "Yazarlar";
            this.btnWriters.Click += new System.EventHandler(this.btnWriters_Click);
            // 
            // btnMyProfile
            // 
            this.btnMyProfile.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMyProfile.Appearance.Options.UseFont = true;
            this.btnMyProfile.AutoSize = true;
            this.btnMyProfile.AutoWidthInLayoutControl = true;
            this.btnMyProfile.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMyProfile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMyProfile.ImageOptions.Image")));
            this.btnMyProfile.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnMyProfile.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.btnMyProfile.Location = new System.Drawing.Point(622, 3);
            this.btnMyProfile.Name = "btnMyProfile";
            this.btnMyProfile.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnMyProfile.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnMyProfile.Size = new System.Drawing.Size(105, 57);
            this.btnMyProfile.TabIndex = 13;
            this.btnMyProfile.Text = "Profil İşlemleri";
            this.btnMyProfile.Click += new System.EventHandler(this.btnMyProfile_Click);
            // 
            // btnMyContacts
            // 
            this.btnMyContacts.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMyContacts.Appearance.Options.UseFont = true;
            this.btnMyContacts.AutoSize = true;
            this.btnMyContacts.AutoWidthInLayoutControl = true;
            this.btnMyContacts.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMyContacts.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMyContacts.ImageOptions.Image")));
            this.btnMyContacts.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnMyContacts.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.btnMyContacts.Location = new System.Drawing.Point(733, 3);
            this.btnMyContacts.Name = "btnMyContacts";
            this.btnMyContacts.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnMyContacts.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnMyContacts.Size = new System.Drawing.Size(81, 57);
            this.btnMyContacts.TabIndex = 5;
            this.btnMyContacts.Text = "Mesajlarım";
            this.btnMyContacts.Click += new System.EventHandler(this.btnMyContacts_Click);
            // 
            // userPanel
            // 
            this.userPanel.Appearance.BackColor = System.Drawing.Color.MistyRose;
            this.userPanel.Appearance.BackColor2 = System.Drawing.Color.LightBlue;
            this.userPanel.Appearance.Options.UseBackColor = true;
            this.userPanel.AutoSize = true;
            this.userPanel.Controls.Add(this.btnArchive);
            this.userPanel.Controls.Add(this.btnMyFavorites);
            this.userPanel.Controls.Add(this.btnHaveRead);
            this.userPanel.Controls.Add(this.btnWillRead);
            this.userPanel.Controls.Add(this.btnMyEscrowList);
            this.userPanel.Controls.Add(this.btnMyComments);
            this.userPanel.Controls.Add(this.btnWriters);
            this.userPanel.Controls.Add(this.btnMyProfile);
            this.userPanel.Controls.Add(this.btnMyContacts);
            this.userPanel.Controls.Add(this.btnUserClose);
            this.userPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.userPanel.Location = new System.Drawing.Point(0, 0);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(1456, 63);
            this.userPanel.TabIndex = 14;
            this.userPanel.Visible = false;
            // 
            // btnWillRead
            // 
            this.btnWillRead.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnWillRead.Appearance.Options.UseFont = true;
            this.btnWillRead.AutoSize = true;
            this.btnWillRead.AutoWidthInLayoutControl = true;
            this.btnWillRead.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnWillRead.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWillRead.ImageOptions.Image")));
            this.btnWillRead.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnWillRead.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.btnWillRead.Location = new System.Drawing.Point(241, 3);
            this.btnWillRead.Name = "btnWillRead";
            this.btnWillRead.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnWillRead.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnWillRead.Size = new System.Drawing.Size(106, 57);
            this.btnWillRead.TabIndex = 14;
            this.btnWillRead.Text = "Okuyacaklarım";
            this.btnWillRead.Click += new System.EventHandler(this.btnWillRead_Click);
            // 
            // btnMyEscrowList
            // 
            this.btnMyEscrowList.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMyEscrowList.Appearance.Options.UseFont = true;
            this.btnMyEscrowList.AutoSize = true;
            this.btnMyEscrowList.AutoWidthInLayoutControl = true;
            this.btnMyEscrowList.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMyEscrowList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMyEscrowList.ImageOptions.Image")));
            this.btnMyEscrowList.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnMyEscrowList.ImageOptions.SvgImageSize = new System.Drawing.Size(48, 48);
            this.btnMyEscrowList.Location = new System.Drawing.Point(353, 3);
            this.btnMyEscrowList.Name = "btnMyEscrowList";
            this.btnMyEscrowList.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnMyEscrowList.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnMyEscrowList.Size = new System.Drawing.Size(107, 57);
            this.btnMyEscrowList.TabIndex = 15;
            this.btnMyEscrowList.Text = "Emanet Listem";
            this.btnMyEscrowList.Click += new System.EventHandler(this.btnMyEscrowList_Click);
            // 
            // btnUserClose
            // 
            this.btnUserClose.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUserClose.Appearance.Options.UseFont = true;
            this.btnUserClose.AutoSize = true;
            this.btnUserClose.AutoWidthInLayoutControl = true;
            this.btnUserClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnUserClose.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnUserClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUserClose.ImageOptions.SvgImage")));
            this.btnUserClose.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btnUserClose.Location = new System.Drawing.Point(820, 3);
            this.btnUserClose.Name = "btnUserClose";
            this.btnUserClose.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnUserClose.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnUserClose.Size = new System.Drawing.Size(42, 57);
            this.btnUserClose.TabIndex = 11;
            this.btnUserClose.Text = "Çıkış";
            this.btnUserClose.Click += new System.EventHandler(this.btnUserClose_Click);
            // 
            // centerPanel
            // 
            this.centerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.centerPanel.Location = new System.Drawing.Point(0, 63);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(1456, 556);
            this.centerPanel.TabIndex = 15;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 666);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.adminPanel);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.centerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Main";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.topPanel)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminPanel)).EndInit();
            this.adminPanel.ResumeLayout(false);
            this.adminPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.footerPanel)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPanel)).EndInit();
            this.userPanel.ResumeLayout(false);
            this.userPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.Layout.StackPanel topPanel;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnUserInfo;
        private DevExpress.XtraEditors.SimpleButton btnBookInfo;
        private DevExpress.XtraEditors.SimpleButton btnCategoryInfo;
        private DevExpress.XtraEditors.SimpleButton btnWriterInfo;
        private DevExpress.XtraEditors.SimpleButton btnPublisherInfo;
        private DevExpress.XtraEditors.SimpleButton btnCommentInfo;
        private DevExpress.XtraEditors.SimpleButton btnContactInfo;
        private DevExpress.XtraEditors.SimpleButton btnUserBookInfo;
        private DevExpress.XtraEditors.SimpleButton btnUserRoleInfo;
        private DevExpress.XtraEditors.SimpleButton btnBookCategoryInfo;
        private DevExpress.XtraEditors.SimpleButton btnControlCenter;
        private DevExpress.Utils.Layout.StackPanel adminPanel;
        private DevExpress.XtraEditors.SimpleButton btnAdminClose;
        private DevExpress.Utils.Layout.StackPanel footerPanel;
        private DevExpress.XtraEditors.LabelControl lblCompanyName;
        private DevExpress.XtraEditors.SimpleButton btnArchive;
        private DevExpress.XtraEditors.SimpleButton btnMyFavorites;
        private DevExpress.XtraEditors.SimpleButton btnHaveRead;
        private DevExpress.XtraEditors.SimpleButton btnMyComments;
        private DevExpress.XtraEditors.SimpleButton btnWriters;
        private DevExpress.XtraEditors.SimpleButton btnMyProfile;
        private DevExpress.XtraEditors.SimpleButton btnMyContacts;
        private DevExpress.Utils.Layout.StackPanel userPanel;
        private DevExpress.XtraEditors.SimpleButton btnUserClose;
        private System.Windows.Forms.Panel centerPanel;
        private DevExpress.XtraEditors.SimpleButton btnWillRead;
        private DevExpress.XtraEditors.SimpleButton btnMyEscrowList;
    }
}

