using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Drawing;
using System.IO;


namespace PhotoStudio
{
    public partial class frmOptions : Telerik.WinControls.UI.RadForm
    {
        
        private string _fileName;
        private bool sqlError;
        public frmOptions()
        {
            InitializeComponent();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            LogicLayer lg1 = new LogicLayer();
            _fileName = lg1.GetBackupFileName();
            txbPath.Text = Application.StartupPath + @"\Backup\" + _fileName;
            FillUserName();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.AutoUpgradeEnabled = false;
            sav.DefaultExt = "BAK";
            sav.FileName = _fileName;
            sav.Filter = @"SQL Backup files (*.BAK) |*.BAK|All files (*.*) |*.*";
            sav.OverwritePrompt = true;
            sav.Title = this.Text;
            if (sav.ShowDialog() == DialogResult.OK)
            {
                txbPath.Text = sav.FileName;
            }
        }

        private void FillUserName()
        {
            LogicLayer lg = new LogicLayer();
            string key = PAPC.Info.Key;
            SQLAccess sql = new SQLAccess();
            sql.StoredProcedureName = "prcGetUserList";
            DataTable dt = new DataTable();
            dt = sql.ExcecuteQueryToDataTable();
            if(dt.Rows.Count > 0)
            {
                cmbUsername.Items.Clear();
                for(int i = 0;i < dt.Rows.Count; i++)
                {
                    string userId = dt.Rows[i]["Id"].ToString();
                    string username = dt.Rows[i]["Username"].ToString();
                    Telerik.WinControls.UI.RadListDataItem item = new Telerik.WinControls.UI.RadListDataItem();
                    item.Value = userId;                    
                    item.Text = lg.Decrypt(username,true, key);
                    cmbUsername.Items.Add(item);
                }
                cmbUsername.SelectedIndex = 0;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            this.prbBackup.Visible = true;
            prbBackup.Value1 = 0;
            prbBackup.Maximum = 100;
            prbBackup.Value1 = 25;
            prbBackup.Text = prbBackup.Value1.ToString() + "%";
            prbBackup.Update();
            SQLAccess sql = new SQLAccess();
            SqlConnection conn = new SqlConnection(Program.SqlConnectionString);
            BackupDatabase(conn, txbPath.Text.Trim());
        }

        public void BackupDatabase(SqlConnection con, string backupFilename)
        {
            con.FireInfoMessageEventOnUserErrors = true;
            con.InfoMessage += OnInfoMessage;
            string command = @"BACKUP DATABASE PhotoStudio TO DISK='" + backupFilename + "'";
            if (con.State != ConnectionState.Open)
                con.Open();
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.ExecuteNonQuery();
            con.Close();
            con.InfoMessage -= OnInfoMessage;
            con.FireInfoMessageEventOnUserErrors = false;
            sqlError = false;
        }

        private void OnInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            if (!sqlError)
            {
                foreach (SqlError info in e.Errors)
                {
                    if (info.Class > 10)
                    {
                        
                        string mes3 = "پشتیبان گیری با شکست مواجه گردید";
                        frmShowInfoSmall frmshs = new frmShowInfoSmall(mes3, 2,"خطا");
                        frmshs.ShowDialog();
                        prbBackup.Visible = false;
                        sqlError = true;
                        break;
                    }
                    else
                    {
                        prbBackup.Value1 += 25;
                        prbBackup.Text = prbBackup.Value1.ToString() + "%";
                        prbBackup.Update();
                        if (prbBackup.Value1 == 100)
                        {                            
                            string mes2 = "پشتیبان گیری با موفقیت انجام گردید";
                            frmShowInfoSmall frmshs = new frmShowInfoSmall(mes2, 2,"");
                            frmshs.ShowDialog();
                            prbBackup.Visible = false;
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog sav = new OpenFileDialog();
            sav.AutoUpgradeEnabled = false;
            sav.DefaultExt = "BAK";
            sav.InitialDirectory = Application.StartupPath + @"\Backup\";
            sav.Filter = @"SQL Backup files (*.BAK) |*.BAK|All files (*.*) |*.*";

            sav.Title = this.Text;
            if (sav.ShowDialog() == DialogResult.OK)
            {
                txbPath2.Text = sav.FileName;
                btnRestore.Enabled = true;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (txbPath2.Text != "")
            {
                Restore res = new Restore();
                try
                {
                    string fileName = this.txbPath.Text.Trim();
                    string databaseName = "PhotoStudio";

                    res.Database = databaseName;
                    res.Action = RestoreActionType.Database;
                    res.Devices.AddDevice(fileName, DeviceType.File);
                    res.ReplaceDatabase = true;

                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = GetMasterConectionString();

                    ServerConnection con = new ServerConnection(conn);
                    Server srv = new Server(con);
                    srv.KillAllProcesses("PhotoStudio");
                    srv.KillDatabase("PhotoStudio");

                    this.prbRestore.Visible = true;
                    this.prbRestore.Value1 = 0;
                    this.prbRestore.Maximum = 100;
                    this.prbRestore.Value1 = 10;
                    this.prbRestore.Text = prbRestore.Value1.ToString() + "%";
                    this.prbRestore.Update();

                    res.PercentCompleteNotification = 10;
                    res.ReplaceDatabase = true;
                    res.NoRecovery = false;
                    res.PercentComplete += new PercentCompleteEventHandler(ProgressEventHandler);
                    res.SqlRestore(srv);

                }
                catch (Exception)
                {
                    
                    string mes3 = "بازیابی اطلاعات با شکست مواجه گردید";
                    frmShowInfoSmall frmshs = new frmShowInfoSmall(mes3, 2,"خطا");
                    frmshs.ShowDialog();
                    prbRestore.Visible = false;
                }
                finally
                {
                    this.prbRestore.Value1 = 0;
                    this.prbRestore.Text = prbRestore.Value1.ToString() + "%";
                    this.prbRestore.Update();
                }
            }
            else
            {
                string mes4 = "لطفا ابتدا فایل پشتیبان را مشخص نمایید ";
                frmShowInfoSmall frmshs = new frmShowInfoSmall(mes4, 2, "خطا");
                frmshs.ShowDialog();
                return;
            }
        }
        private string GetMasterConectionString()
        {
            string _conString = "";
            string _username = Program.SqlUsername;
            string _password = SQLiteAceess.ExecuteQuery("DbPassword");
            string _server = Program.SqlServer;
            _conString = "user id = " + _username + ";password = " + _password + ";server = " + _server + ";database = master";
            return _conString;
        }

        public void ProgressEventHandler(object sender, PercentCompleteEventArgs e)
        {
            this.prbRestore.Value1 = e.Percent;
            this.prbRestore.Text = prbRestore.Value1.ToString() + "%";
            this.prbRestore.Update();
            if (prbRestore.Value1 == 100)
            {
                string mes2 = "بازیابی اطلاعات با موفقیت انجام گردید.برنامه را مجدد اجرا نمایید";
                frmShowInfoSmall frmshs = new frmShowInfoSmall(mes2, 2,"");
                frmshs.ShowDialog();
                prbRestore.Visible = false;
                Environment.Exit(0);
            }
        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbUsername_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            LogicLayer lg = new LogicLayer();
            string id = cmbUsername.SelectedItem.Value.ToString();
            SQLAccess sql = new SQLAccess();
            sql.StoredProcedureName = "prcGetUserListByUserId";
            DataTable dt = new DataTable();
            string[,] SpParams = new string[1, 2];
            SpParams[0, 0] = "@Id";
            SpParams[0, 1] = id;
            dt = sql.ExcecuteQueryToDataTable(SpParams);
            if(dt.Rows.Count > 0)
            {
                txbKarbarName.Text = dt.Rows[0]["KarbarName"].ToString();
            }
            if (dt.Rows[0]["KarbarImage"] != DBNull.Value)
            {
                User.UserImageData = (byte[])dt.Rows[0]["KarbarImage"];
            }
            else
            {
                User.UserImage = Properties.Resources.unknown;
                User.UserImageData = lg.imageToByteArray(User.UserImage);
            }
            Image perImage;
            //Read image data into a memory stream
            using (MemoryStream ms = new MemoryStream(User.UserImageData, 0, User.UserImageData.Length))
            {
                ms.Write(User.UserImageData, 0, User.UserImageData.Length);

                //Set image variable value using memory stream.
                perImage = Image.FromStream(ms, true);
            }
            picUser.Image = perImage;
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            string key = PAPC.Info.Key;
            if (txbOldPassword.Text.Trim() == "")
            {
                string mes3 = "لطفا کلمه عبور فعلی خود را وارد نمایید";
                frmShowInfoSmall frmshs = new frmShowInfoSmall(mes3, 2, "خطا");
                frmshs.ShowDialog();
                return;
            }
            if(txbNewPassword.Text.Trim() != txbNewPasswordRep.Text.Trim())
            {
                string mes3 = "کلمه عبور جدید و تکرار آن با هم یکسان نمی باشند";
                frmShowInfoSmall frmshs = new frmShowInfoSmall(mes3, 2, "خطا");
                frmshs.ShowDialog();
                return;
            }
            LogicLayer lg = new LogicLayer();
            int _errorCode = lg.CheckLoginDetails(cmbUsername.SelectedItem.Text, txbOldPassword.Text.Trim());
            if(_errorCode == 0)
            {
                // password is not correct.
                string mes = "کلمه عبور فعلی اشتباه است";
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, "خطا");
                fm.ShowDialog();          
                return;
            }

            string usenname = "";
            if (txbNewUsername.Text.Trim() != "")
                usenname = lg.Encrypt(txbNewUsername.Text.Trim(), true, key);
            else
                usenname = lg.Encrypt(cmbUsername.SelectedItem.Text, true, key);

            string karbar = txbKarbarName.Text.Trim();
            string password = "";
            if (txbNewPassword.Text.Trim() != "")
                password = lg.Encrypt(txbNewPassword.Text.Trim(), true, key);
            else
                password = lg.Encrypt(txbOldPassword.Text.Trim(), true, key);

            byte[] imageData = null;

            if (picUser.ImageLocation != null)
            {
                imageData = ReadFile(picUser.ImageLocation);
            }
           

            SQLAccess sql = new SQLAccess();
            sql.StoredProcedureName = "prcUpdateUserPassword";
            string[,] SpParams = new string[4, 2];
            SpParams[0, 0] = "@Id";
            SpParams[0, 1] = cmbUsername.SelectedItem.Value.ToString();

            SpParams[1, 0] = "@Username";
            SpParams[1, 1] = usenname;

            SpParams[2, 0] = "@Password";
            SpParams[2, 1] = password;

            SpParams[3, 0] = "@KarbarName";
            SpParams[3, 1] = karbar;

            int result = sql.UpdatePersonnelInfo(SpParams, imageData);

            if(result == 1)
            {
                string mes = "اطلاعات با موفقیت ذخیره شد";
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, "");
                fm.ShowDialog();
                return;
            }
            else
            {
                string mes = "ذخیره اطلاعات با شکست مواجه گردید";
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, "خطا");
                fm.ShowDialog();
                return;
            }
        }

        //Open file in to a filestream and read data in a byte array.
        private byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            //Ask user to select file.
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.AutoUpgradeEnabled = false;
            dlg.Title = "Select a picture";
            dlg.Filter = "Image File|*.jpg";
            DialogResult dlgRes = new System.Windows.Forms.DialogResult();
            dlgRes = dlg.ShowDialog();
            if (dlgRes != DialogResult.Cancel)
            {
                //Set image in picture box
                picUser.ImageLocation = dlg.FileName;

                FileInfo fi = new FileInfo(dlg.FileName);
                dlg.Dispose();
                GC.Collect();
                if (fi.Length > 50000)
                {
                    string error = "حجم فایل عکس باید کمتر از 50 کیلو بایت باشد";
                    LogicLayer lg = new LogicLayer();
                    frmShowInfoSmall fm = new frmShowInfoSmall(error, 2,"خطا");
                    fm.ShowDialog();
                    picUser.ImageLocation = null;
                }
            }
            else
                picUser.ImageLocation = null;
        }
    }
}
