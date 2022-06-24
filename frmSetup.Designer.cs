namespace PhotoStudio
{
    partial class frmSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetup));
            this.pageSetup = new Telerik.WinControls.UI.RadPageView();
            this.pageDbSetup = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnTest = new Telerik.WinControls.UI.RadButton();
            this.txbPassword = new Telerik.WinControls.UI.RadTextBox();
            this.txbUsername = new Telerik.WinControls.UI.RadTextBox();
            this.txbDb = new Telerik.WinControls.UI.RadTextBox();
            this.txbServer = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.pageSetup)).BeginInit();
            this.pageSetup.SuspendLayout();
            this.pageDbSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbDb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // pageSetup
            // 
            this.pageSetup.Controls.Add(this.pageDbSetup);
            this.pageSetup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageSetup.Location = new System.Drawing.Point(12, 12);
            this.pageSetup.Name = "pageSetup";
            this.pageSetup.SelectedPage = this.pageDbSetup;
            this.pageSetup.Size = new System.Drawing.Size(539, 302);
            this.pageSetup.TabIndex = 0;
            this.pageSetup.Text = "radPageView1";
            // 
            // pageDbSetup
            // 
            this.pageDbSetup.Controls.Add(this.btnTest);
            this.pageDbSetup.Controls.Add(this.txbPassword);
            this.pageDbSetup.Controls.Add(this.txbUsername);
            this.pageDbSetup.Controls.Add(this.txbDb);
            this.pageDbSetup.Controls.Add(this.txbServer);
            this.pageDbSetup.Controls.Add(this.label4);
            this.pageDbSetup.Controls.Add(this.label3);
            this.pageDbSetup.Controls.Add(this.label2);
            this.pageDbSetup.Controls.Add(this.label1);
            this.pageDbSetup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageDbSetup.Image = ((System.Drawing.Image)(resources.GetObject("pageDbSetup.Image")));
            this.pageDbSetup.ItemSize = new System.Drawing.SizeF(149F, 36F);
            this.pageDbSetup.Location = new System.Drawing.Point(10, 45);
            this.pageDbSetup.Name = "pageDbSetup";
            this.pageDbSetup.Size = new System.Drawing.Size(518, 246);
            this.pageDbSetup.Text = "تنظیمات بانک اطلاعاتی";
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(210, 204);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(110, 24);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "تست ارتباط با بانک";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(145, 159);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbPassword.Size = new System.Drawing.Size(221, 19);
            this.txbPassword.TabIndex = 3;
            // 
            // txbUsername
            // 
            this.txbUsername.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsername.Location = new System.Drawing.Point(145, 121);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbUsername.Size = new System.Drawing.Size(221, 19);
            this.txbUsername.TabIndex = 3;
            this.txbUsername.Text = "sa";
            // 
            // txbDb
            // 
            this.txbDb.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDb.Location = new System.Drawing.Point(145, 83);
            this.txbDb.Name = "txbDb";
            this.txbDb.ReadOnly = true;
            this.txbDb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbDb.Size = new System.Drawing.Size(221, 19);
            this.txbDb.TabIndex = 1;
            this.txbDb.Text = "PhotoStudio";
            // 
            // txbServer
            // 
            this.txbServer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbServer.Location = new System.Drawing.Point(145, 45);
            this.txbServer.Name = "txbServer";
            this.txbServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbServer.Size = new System.Drawing.Size(221, 19);
            this.txbServer.TabIndex = 0;
            this.txbServer.Text = "localhost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(387, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "کلمه عبور:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(387, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "نام کاربری:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(387, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "نام بانک:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(387, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "آدرس سرور:";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(93, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 24);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "ذخیره";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(22, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 24);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 357);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pageSetup);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظیمات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetup_FormClosing);
            this.Load += new System.EventHandler(this.frmSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pageSetup)).EndInit();
            this.pageSetup.ResumeLayout(false);
            this.pageDbSetup.ResumeLayout(false);
            this.pageDbSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbDb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView pageSetup;
        private Telerik.WinControls.UI.RadPageViewPage pageDbSetup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadButton btnTest;
        private Telerik.WinControls.UI.RadTextBox txbPassword;
        private Telerik.WinControls.UI.RadTextBox txbUsername;
        private Telerik.WinControls.UI.RadTextBox txbDb;
        private Telerik.WinControls.UI.RadTextBox txbServer;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnCancel;
    }
}
