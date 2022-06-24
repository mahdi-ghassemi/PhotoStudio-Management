namespace PhotoStudio
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.pageOptionsMain = new Telerik.WinControls.UI.RadPageView();
            this.pageBackup = new Telerik.WinControls.UI.RadPageViewPage();
            this.prbBackup = new Telerik.WinControls.UI.RadProgressBar();
            this.btnBrowse = new Telerik.WinControls.UI.RadButton();
            this.txbPath = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.btnBackup = new Telerik.WinControls.UI.RadButton();
            this.pageRestore = new Telerik.WinControls.UI.RadPageViewPage();
            this.prbRestore = new Telerik.WinControls.UI.RadProgressBar();
            this.btnBrowse2 = new Telerik.WinControls.UI.RadButton();
            this.txbPath2 = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnCancel2 = new Telerik.WinControls.UI.RadButton();
            this.btnRestore = new Telerik.WinControls.UI.RadButton();
            this.pageUsers = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnBrowseImage = new Telerik.WinControls.UI.RadButton();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.txbKarbarName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel8 = new Telerik.WinControls.UI.RadLabel();
            this.btnCancel3 = new Telerik.WinControls.UI.RadButton();
            this.btnSaveUser = new Telerik.WinControls.UI.RadButton();
            this.txbNewPasswordRep = new Telerik.WinControls.UI.RadTextBox();
            this.txbNewPassword = new Telerik.WinControls.UI.RadTextBox();
            this.txbOldPassword = new Telerik.WinControls.UI.RadTextBox();
            this.txbNewUsername = new Telerik.WinControls.UI.RadTextBox();
            this.cmbUsername = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pageOptionsMain)).BeginInit();
            this.pageOptionsMain.SuspendLayout();
            this.pageBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbBackup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackup)).BeginInit();
            this.pageRestore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPath2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).BeginInit();
            this.pageUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbKarbarName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbNewPasswordRep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbNewPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbOldPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbNewUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pageOptionsMain
            // 
            this.pageOptionsMain.Controls.Add(this.pageBackup);
            this.pageOptionsMain.Controls.Add(this.pageRestore);
            this.pageOptionsMain.Controls.Add(this.pageUsers);
            this.pageOptionsMain.DefaultPage = this.pageBackup;
            this.pageOptionsMain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageOptionsMain.Location = new System.Drawing.Point(12, 12);
            this.pageOptionsMain.Name = "pageOptionsMain";
            this.pageOptionsMain.SelectedPage = this.pageBackup;
            this.pageOptionsMain.Size = new System.Drawing.Size(654, 243);
            this.pageOptionsMain.TabIndex = 0;
            this.pageOptionsMain.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.pageOptionsMain.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // pageBackup
            // 
            this.pageBackup.Controls.Add(this.prbBackup);
            this.pageBackup.Controls.Add(this.btnBrowse);
            this.pageBackup.Controls.Add(this.txbPath);
            this.pageBackup.Controls.Add(this.radLabel1);
            this.pageBackup.Controls.Add(this.btnCancel);
            this.pageBackup.Controls.Add(this.btnBackup);
            this.pageBackup.ItemSize = new System.Drawing.SizeF(82F, 27F);
            this.pageBackup.Location = new System.Drawing.Point(10, 36);
            this.pageBackup.Name = "pageBackup";
            this.pageBackup.Size = new System.Drawing.Size(633, 196);
            this.pageBackup.Text = "پشتیبان گیری";
            // 
            // prbBackup
            // 
            this.prbBackup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prbBackup.ForeColor = System.Drawing.Color.Maroon;
            this.prbBackup.Location = new System.Drawing.Point(129, 85);
            this.prbBackup.Name = "prbBackup";
            this.prbBackup.Size = new System.Drawing.Size(379, 24);
            this.prbBackup.TabIndex = 5;
            this.prbBackup.Text = "در حال پشتیبان گیری....";
            this.prbBackup.Visible = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(3, 44);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(110, 24);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "انتخاب مسیر";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txbPath
            // 
            this.txbPath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPath.Location = new System.Drawing.Point(129, 46);
            this.txbPath.Name = "txbPath";
            this.txbPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbPath.Size = new System.Drawing.Size(379, 19);
            this.txbPath.TabIndex = 3;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(514, 48);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(101, 17);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "مسیر فایل پشتیبان:";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(3, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Location = new System.Drawing.Point(119, 140);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(110, 24);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "گرفتن پشتیبان";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // pageRestore
            // 
            this.pageRestore.Controls.Add(this.prbRestore);
            this.pageRestore.Controls.Add(this.btnBrowse2);
            this.pageRestore.Controls.Add(this.txbPath2);
            this.pageRestore.Controls.Add(this.radLabel2);
            this.pageRestore.Controls.Add(this.btnCancel2);
            this.pageRestore.Controls.Add(this.btnRestore);
            this.pageRestore.ItemSize = new System.Drawing.SizeF(101F, 27F);
            this.pageRestore.Location = new System.Drawing.Point(10, 36);
            this.pageRestore.Name = "pageRestore";
            this.pageRestore.Size = new System.Drawing.Size(633, 196);
            this.pageRestore.Text = "برگرداندن پشتیبان";
            // 
            // prbRestore
            // 
            this.prbRestore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prbRestore.ForeColor = System.Drawing.Color.Maroon;
            this.prbRestore.Location = new System.Drawing.Point(136, 79);
            this.prbRestore.Name = "prbRestore";
            this.prbRestore.Size = new System.Drawing.Size(379, 24);
            this.prbRestore.TabIndex = 11;
            this.prbRestore.Text = "در حال بازیابی اطلاعات...";
            this.prbRestore.Visible = false;
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse2.Location = new System.Drawing.Point(10, 38);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(110, 24);
            this.btnBrowse2.TabIndex = 10;
            this.btnBrowse2.Text = "انتخاب مسیر";
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // txbPath2
            // 
            this.txbPath2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPath2.Location = new System.Drawing.Point(136, 40);
            this.txbPath2.Name = "txbPath2";
            this.txbPath2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbPath2.Size = new System.Drawing.Size(379, 19);
            this.txbPath2.TabIndex = 9;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(521, 42);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(101, 17);
            this.radLabel2.TabIndex = 8;
            this.radLabel2.Text = "مسیر فایل پشتیبان:";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancel2
            // 
            this.btnCancel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel2.Location = new System.Drawing.Point(10, 134);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(110, 24);
            this.btnCancel2.TabIndex = 7;
            this.btnCancel2.Text = "انصراف";
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.Location = new System.Drawing.Point(126, 134);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(110, 24);
            this.btnRestore.TabIndex = 6;
            this.btnRestore.Text = "بازیابی اطلاعات";
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // pageUsers
            // 
            this.pageUsers.Controls.Add(this.btnBrowseImage);
            this.pageUsers.Controls.Add(this.picUser);
            this.pageUsers.Controls.Add(this.txbKarbarName);
            this.pageUsers.Controls.Add(this.radLabel8);
            this.pageUsers.Controls.Add(this.btnCancel3);
            this.pageUsers.Controls.Add(this.btnSaveUser);
            this.pageUsers.Controls.Add(this.txbNewPasswordRep);
            this.pageUsers.Controls.Add(this.txbNewPassword);
            this.pageUsers.Controls.Add(this.txbOldPassword);
            this.pageUsers.Controls.Add(this.txbNewUsername);
            this.pageUsers.Controls.Add(this.cmbUsername);
            this.pageUsers.Controls.Add(this.radLabel7);
            this.pageUsers.Controls.Add(this.radLabel6);
            this.pageUsers.Controls.Add(this.radLabel5);
            this.pageUsers.Controls.Add(this.radLabel4);
            this.pageUsers.Controls.Add(this.radLabel3);
            this.pageUsers.ItemSize = new System.Drawing.SizeF(74F, 27F);
            this.pageUsers.Location = new System.Drawing.Point(10, 36);
            this.pageUsers.Name = "pageUsers";
            this.pageUsers.Size = new System.Drawing.Size(633, 196);
            this.pageUsers.Text = "ویرایش کاربر";
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseImage.Location = new System.Drawing.Point(3, 92);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(85, 24);
            this.btnBrowseImage.TabIndex = 23;
            this.btnBrowseImage.Text = "انتخاب عکس";
            this.btnBrowseImage.Click += new System.EventHandler(this.btnBrowseImage_Click);
            // 
            // picUser
            // 
            this.picUser.Location = new System.Drawing.Point(3, 5);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(85, 84);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 22;
            this.picUser.TabStop = false;
            // 
            // txbKarbarName
            // 
            this.txbKarbarName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbKarbarName.Location = new System.Drawing.Point(328, 64);
            this.txbKarbarName.MaxLength = 50;
            this.txbKarbarName.Name = "txbKarbarName";
            this.txbKarbarName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txbKarbarName.Size = new System.Drawing.Size(184, 19);
            this.txbKarbarName.TabIndex = 21;
            // 
            // radLabel8
            // 
            this.radLabel8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel8.Location = new System.Drawing.Point(518, 65);
            this.radLabel8.Name = "radLabel8";
            this.radLabel8.Size = new System.Drawing.Size(74, 17);
            this.radLabel8.TabIndex = 20;
            this.radLabel8.Text = "نام کاربر جدید:";
            this.radLabel8.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancel3
            // 
            this.btnCancel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel3.Location = new System.Drawing.Point(3, 169);
            this.btnCancel3.Name = "btnCancel3";
            this.btnCancel3.Size = new System.Drawing.Size(110, 24);
            this.btnCancel3.TabIndex = 19;
            this.btnCancel3.Text = "انصراف";
            this.btnCancel3.Click += new System.EventHandler(this.btnCancel3_Click);
            // 
            // btnSaveUser
            // 
            this.btnSaveUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUser.Location = new System.Drawing.Point(119, 169);
            this.btnSaveUser.Name = "btnSaveUser";
            this.btnSaveUser.Size = new System.Drawing.Size(110, 24);
            this.btnSaveUser.TabIndex = 18;
            this.btnSaveUser.Text = "ذخیره";
            this.btnSaveUser.Click += new System.EventHandler(this.btnSaveUser_Click);
            // 
            // txbNewPasswordRep
            // 
            this.txbNewPasswordRep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewPasswordRep.Location = new System.Drawing.Point(25, 119);
            this.txbNewPasswordRep.MaxLength = 50;
            this.txbNewPasswordRep.Name = "txbNewPasswordRep";
            this.txbNewPasswordRep.PasswordChar = '*';
            this.txbNewPasswordRep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbNewPasswordRep.Size = new System.Drawing.Size(184, 19);
            this.txbNewPasswordRep.TabIndex = 17;
            // 
            // txbNewPassword
            // 
            this.txbNewPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewPassword.Location = new System.Drawing.Point(328, 120);
            this.txbNewPassword.MaxLength = 50;
            this.txbNewPassword.Name = "txbNewPassword";
            this.txbNewPassword.PasswordChar = '*';
            this.txbNewPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbNewPassword.Size = new System.Drawing.Size(184, 19);
            this.txbNewPassword.TabIndex = 16;
            // 
            // txbOldPassword
            // 
            this.txbOldPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbOldPassword.Location = new System.Drawing.Point(328, 92);
            this.txbOldPassword.MaxLength = 50;
            this.txbOldPassword.Name = "txbOldPassword";
            this.txbOldPassword.PasswordChar = '*';
            this.txbOldPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbOldPassword.Size = new System.Drawing.Size(184, 19);
            this.txbOldPassword.TabIndex = 15;
            // 
            // txbNewUsername
            // 
            this.txbNewUsername.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewUsername.Location = new System.Drawing.Point(328, 36);
            this.txbNewUsername.MaxLength = 50;
            this.txbNewUsername.Name = "txbNewUsername";
            this.txbNewUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbNewUsername.Size = new System.Drawing.Size(184, 19);
            this.txbNewUsername.TabIndex = 14;
            // 
            // cmbUsername
            // 
            this.cmbUsername.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.cmbUsername.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUsername.Location = new System.Drawing.Point(328, 8);
            this.cmbUsername.Name = "cmbUsername";
            this.cmbUsername.Size = new System.Drawing.Size(184, 19);
            this.cmbUsername.TabIndex = 13;
            this.cmbUsername.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.cmbUsername_SelectedIndexChanged);
            // 
            // radLabel7
            // 
            this.radLabel7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel7.Location = new System.Drawing.Point(215, 121);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(107, 17);
            this.radLabel7.TabIndex = 12;
            this.radLabel7.Text = "تکرار کلمه عبور جدید:";
            this.radLabel7.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(518, 121);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(83, 17);
            this.radLabel6.TabIndex = 12;
            this.radLabel6.Text = "کلمه عبور جدید:";
            this.radLabel6.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel5
            // 
            this.radLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.Location = new System.Drawing.Point(518, 93);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(85, 17);
            this.radLabel5.TabIndex = 11;
            this.radLabel5.Text = "کلمه عبور فعلی:";
            this.radLabel5.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(518, 37);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(84, 17);
            this.radLabel4.TabIndex = 10;
            this.radLabel4.Text = "نام کاربری جدید:";
            this.radLabel4.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(518, 9);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(58, 17);
            this.radLabel3.TabIndex = 9;
            this.radLabel3.Text = "نام کاربری:";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 259);
            this.Controls.Add(this.pageOptionsMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOptions";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "امکانات";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pageOptionsMain)).EndInit();
            this.pageOptionsMain.ResumeLayout(false);
            this.pageBackup.ResumeLayout(false);
            this.pageBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbBackup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackup)).EndInit();
            this.pageRestore.ResumeLayout(false);
            this.pageRestore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prbRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPath2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore)).EndInit();
            this.pageUsers.ResumeLayout(false);
            this.pageUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowseImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbKarbarName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbNewPasswordRep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbNewPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbOldPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbNewUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageOptionsMain;
        private Telerik.WinControls.UI.RadPageViewPage pageBackup;
        private Telerik.WinControls.UI.RadPageViewPage pageRestore;
        private Telerik.WinControls.UI.RadPageViewPage pageUsers;
        private Telerik.WinControls.UI.RadButton btnBrowse;
        private Telerik.WinControls.UI.RadTextBox txbPath;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadButton btnBackup;
        private Telerik.WinControls.UI.RadProgressBar prbBackup;
        private Telerik.WinControls.UI.RadProgressBar prbRestore;
        private Telerik.WinControls.UI.RadButton btnBrowse2;
        private Telerik.WinControls.UI.RadTextBox txbPath2;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnCancel2;
        private Telerik.WinControls.UI.RadButton btnRestore;
        private Telerik.WinControls.UI.RadTextBox txbNewPasswordRep;
        private Telerik.WinControls.UI.RadTextBox txbNewPassword;
        private Telerik.WinControls.UI.RadTextBox txbOldPassword;
        private Telerik.WinControls.UI.RadTextBox txbNewUsername;
        private Telerik.WinControls.UI.RadDropDownList cmbUsername;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btnCancel3;
        private Telerik.WinControls.UI.RadButton btnSaveUser;
        private Telerik.WinControls.UI.RadTextBox txbKarbarName;
        private Telerik.WinControls.UI.RadLabel radLabel8;
        private Telerik.WinControls.UI.RadButton btnBrowseImage;
        private System.Windows.Forms.PictureBox picUser;
    }
}
