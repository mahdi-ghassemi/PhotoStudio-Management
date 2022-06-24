using System;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Management;
using System.IO;







namespace PhotoStudio
{
    /// <summary>
    /// This class contains all methods for program lagics
    /// </summary>

    public class LogicLayer
    {
        private string fingerPrint = string.Empty;

        public int EqualMachineIds()
        {
            int result = -1;
            string ThisMachineId = GetMachineId();
            string SavedMachineId = SQLiteAceess.ExecuteQuery("SystemId");
            if (ThisMachineId == SavedMachineId)
                result = 1;
            if (SavedMachineId == "")
                result = 0;
            return result;
        }
        public string GetMachineId()
        {
            if (string.IsNullOrEmpty(fingerPrint))
            {
                fingerPrint = GetHash("CPU >> " + cpuId() + "\nBIOS >> " + biosId() + "\nBASE >> " + baseId()  +"\nDISK >> "+ diskId() + "\nVIDEO >> " + videoId());
            }
            return fingerPrint;
        }
        private string GetHash(string s)
        {
            MD5 sec = new MD5CryptoServiceProvider();
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] bt = enc.GetBytes(s);
            return GetHexString(sec.ComputeHash(bt));
        }
        private string GetHexString(byte[] bt)
        {
            string s = string.Empty;
            for (int i = 0; i < bt.Length; i++)
            {
                byte b = bt[i];
                int n, n1, n2;
                n = (int)b;
                n1 = n & 15;
                n2 = (n >> 4) & 15;
                if (n2 > 9)
                    s += ((char)(n2 - 10 + (int)'A')).ToString();
                else
                    s += n2.ToString();
                if (n1 > 9)
                    s += ((char)(n1 - 10 + (int)'A')).ToString();
                else
                    s += n1.ToString();
                if ((i + 1) != bt.Length && (i + 1) % 2 == 0) s += "-";
            }
            return s;
        }
        #region Original Device ID Getting Code
        //Return a hardware identifier
        private string identifier
        (string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string result = "";
            ManagementClass mc = new ManagementClass(wmiClass);
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo[wmiMustBeTrue].ToString() == "True")
                {
                    //Only get the first one
                    if (result == "")
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return result;
        }
        //Return a hardware identifier
        private static string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            ManagementClass mc =
        new ManagementClass(wmiClass);
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        private static string cpuId()
        {
            //Uses first CPU identifier available in order of preference
            //Don't get all identifiers, as it is very time consuming
            string retVal = identifier("Win32_Processor", "UniqueId");
            if (retVal == "") //If no UniqueID, use ProcessorID
            {
                retVal = identifier("Win32_Processor", "ProcessorId");
                if (retVal == "") //If no ProcessorId, use Name
                {
                    retVal = identifier("Win32_Processor", "Name");
                    if (retVal == "") //If no Name, use Manufacturer
                    {
                        retVal = identifier("Win32_Processor", "Manufacturer");
                    }
                    //Add clock speed for extra security
                    retVal += identifier("Win32_Processor", "MaxClockSpeed");
                }
            }
            return retVal;
        }
        //BIOS Identifier
        private static string biosId()
        {
            return identifier("Win32_BIOS", "Manufacturer")
            + identifier("Win32_BIOS", "SMBIOSBIOSVersion")
            + identifier("Win32_BIOS", "IdentificationCode")
            + identifier("Win32_BIOS", "SerialNumber")
            + identifier("Win32_BIOS", "ReleaseDate")
            + identifier("Win32_BIOS", "Version");
        }
        //Main physical hard drive ID
        private static string diskId()
        {
            return identifier("Win32_DiskDrive", "Model")
            + identifier("Win32_DiskDrive", "Manufacturer")
            + identifier("Win32_DiskDrive", "Signature")
            + identifier("Win32_DiskDrive", "TotalHeads");
        }
        //Motherboard ID
        private static string baseId()
        {
            return identifier("Win32_BaseBoard", "Model")
            + identifier("Win32_BaseBoard", "Manufacturer")
            + identifier("Win32_BaseBoard", "Name")
            + identifier("Win32_BaseBoard", "SerialNumber");
        }
        //Primary video controller ID
        private static string videoId()
        {
            return identifier("Win32_VideoController", "DriverVersion")
            + identifier("Win32_VideoController", "Name");
        }
        //First enabled network card ID
        private string macId()
        {
            return identifier("Win32_NetworkAdapterConfiguration",
                "MACAddress", "IPEnabled");
        }
        #endregion


        /******************************************************/
        public string GetSQLCS()
        {            
            string cs = "";
            DataTable dt = new DataTable();
            dt = SQLiteAceess.ExecuteQuery();
            if (dt.Rows.Count > 0)
            {
                string SqlServer = dt.Rows[0]["DbServer"].ToString();
                string SqlDatabase = dt.Rows[0]["DbName"].ToString();
                string SqlUsername = dt.Rows[0]["DbUsername"].ToString();
                string SqlPassword = dt.Rows[0]["DbPassword"].ToString();
                cs = "Server=" + SqlServer + ";Database=" + SqlDatabase + ";User Id=" + SqlUsername + ";Password=" + SqlPassword + ";";
                Program.SqlServer = SqlServer;
                Program.SqlUsername = SqlUsername;
            }
            return cs;
        }

        public int UpdateSqlite(string Column,string Value)
        {
            string Query = "UPDATE Setting SET " + Column + " = '" + Value + "' WHERE Id = 1";
            return SQLiteAceess.Execute(Query); 
        }

        public void SetSqLConectionString()
        {
            string cs = "";
            string DbServer = SQLiteAceess.ExecuteQuery("DbServer");
            string DbName = SQLiteAceess.ExecuteQuery("DbName");
            string DbUsername = SQLiteAceess.ExecuteQuery("DbUsername");
            string DbPassword = SQLiteAceess.ExecuteQuery("DbPassword");
            cs = "Server="+ DbServer +"; Database="+ DbName+"; User Id="+ DbUsername+";Password = "+ DbPassword+"; ";
            Program.SqlConnectionString = cs;
        }

        public string CheckDateLimitation()
        {
            string res = "";
            string date_limitation = SQLiteAceess.ExecuteQuery("LimitDay");
            if (date_limitation == "Unlimited")
            {
                string first_run_dt = SQLiteAceess.ExecuteQuery("FirstRunDate");
                if(first_run_dt == "")                
                    UpdateSqlite("FirstRunDate", DateTime.Now.ToString("yyyy/MM/dd"));                
                return "Unlimited"; // Unlimited date
            }                
            string date_remaind = SQLiteAceess.ExecuteQuery("TotalDateRemainde");
            if (date_remaind == "")
            {
                UpdateSqlite("FirstRunDate", DateTime.Now.ToString("yyyy/MM/dd"));
                date_remaind = date_limitation;
            }
            int limit = Convert.ToInt32(date_remaind);
            if (limit < 0)
                return "-1";
            else if( limit >= 0)
            {
                DateTime today = DateTime.Now;
                string insatll_date = SQLiteAceess.ExecuteQuery("FirstRunDate");

                double day = (today - Convert.ToDateTime(insatll_date)).TotalDays;
                day = Math.Round(day);
                int defrent = Convert.ToInt32(date_limitation) - (int) day;
                UpdateSqlite("TotalDateRemainde", defrent.ToString());
                res = defrent.ToString();
            }
            return res;
        }

        public string CheckInsertDataLimitation()
        {
            string res = "";
            string insert_limitation = SQLiteAceess.ExecuteQuery("LimitInsertDataCount");
            if (insert_limitation == "Unlimited")
            {                
                return "Unlimited"; // Unlimited date
            }
            string insert_remaind = SQLiteAceess.ExecuteQuery("TotalInsertDataRemainde");
            int limit = Convert.ToInt32(insert_remaind);
            if (limit < 0)
                return "-1";
            else if (limit >= 0)
            {
                string totalid = "0";
                string Query = "SELECT COUNT(Id) FROM tblGharardad WHERE Deleted = '0'";
                SQLAccess sql = new SQLAccess();
                DataTable dt = new DataTable();
                dt = sql.ExcecuteSelectQueryToDataTable(Query);
                if(dt.Rows.Count > 0)
                {
                    totalid = dt.Rows[0][0].ToString();
                }
                int difrent =  Convert.ToInt32(insert_limitation) - Convert.ToInt32(totalid);
                UpdateSqlite("TotalInsertDataRemainde", difrent.ToString());
                res = difrent.ToString();
            }
            return res;
        }

        public bool IsSoftwareLock()
        {
            bool result = true;
            string Applock = "1";
            DataTable dt = new DataTable();
            dt = SQLiteAceess.ExecuteQuery();
            if (dt.Rows.Count > 0)
                Applock = dt.Rows[0]["AppLock"].ToString();
            else
                return true;
            if (Applock == "0")
                result = false;            
            return result;
        }       

        public int CheckLoginDetails(string Username, string Password)
        {
            int _result = 0;

            if (Username.Trim() == "" && Password.Trim() == "")
            {
                _result = -2;
                return _result;
            }
            if (Username.Trim() == "")
            {
                _result = -3;
                return _result;
            }
            if (Password.Trim() == "")
            {
                _result = -4;
                return _result;
            }

            if (Username.Trim() != "" && Password.Trim() != "")
            {
                SQLAccess sql1 = new SQLAccess();
                string userEncr, passEncr;
                userEncr = Encrypt(Username.Trim(), true, PAPC.Info.Key);
                passEncr = Encrypt(Password.Trim(), true, PAPC.Info.Key);

                sql1.StoredProcedureName = SQLAccess.StoredProcedure.prcCheckLogin.ToString();
                _result = sql1.CheckLogin(userEncr, passEncr);                    
                return _result;
            }


            return _result;
        }

        public void UpdatePersonnelInfo(string[] Param, byte[] ImageData)
        {
            SQLAccess sql115 = new SQLAccess();
            if (ImageData != null)
                sql115.StoredProcedureName = "prcUpdatePersonnel";
            else
                sql115.StoredProcedureName = "prcUpdatePersonnelNoImage";

            string[,] newparams = new string[11, 2];

            newparams[0, 0] = "@AgentID";
            newparams[1, 0] = "@FirstName";
            newparams[2, 0] = "@LastName";
            newparams[3, 0] = "@Gender";
            newparams[4, 0] = "@PersonnelCode";
            newparams[5, 0] = "@UserTitle";
            newparams[6, 0] = "@UserEmail";
            newparams[7, 0] = "@UserInterNum";
            newparams[8, 0] = "@UserTell";
            newparams[9, 0] = "@UserMob";
            newparams[10, 0] = "@UserAddress";

            newparams[0, 1] = Param[10];
            newparams[1, 1] = Param[2];
            newparams[2, 1] = Param[4];
            newparams[3, 1] = Param[9];
            newparams[4, 1] = Param[6];
            newparams[5, 1] = Param[8];
            newparams[6, 1] = Param[5];
            newparams[7, 1] = Param[3];
            newparams[8, 1] = Param[7];
            newparams[9, 1] = Param[1];
            newparams[10, 1] = Param[0];

            sql115.UpdatePersonnelInfo(newparams, ImageData);
        }

        public void SetUserImage(string Username, string Password)
        {
            SQLAccess sql2 = new SQLAccess();
            DataTable dt = new DataTable();
            sql2.StoredProcedureName = "prcCheckLogin2";
            string userEncr, passEncr;

            userEncr = Encrypt(Username.Trim(), true, PAPC.Info.Key);
            passEncr = Encrypt(Password.Trim(), true, PAPC.Info.Key);

            string[,] newparams = new string[2, 2];

            newparams[0, 0] = "@Username";
            newparams[1, 0] = "@Password";

            newparams[0, 1] = userEncr;
            newparams[1, 1] = passEncr;

            dt = sql2.ExcecuteQueryToDataTable(newparams);


            if (dt.Rows[0]["KarbarImage"] != DBNull.Value)
            {
                User.UserImageData = (byte[]) dt.Rows[0]["KarbarImage"];
            }
            else
            {
                User.UserImage = Properties.Resources.unknown;
                User.UserImageData = imageToByteArray(User.UserImage);
            }
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public void SetTodayDate()
        {           
           Persia.SunDate shamsi = Persia.Calendar.ConvertToPersian(DateTime.Now);
           Program.LocalToday = shamsi.Weekday;            
        }

        public string ShamsiDate(string MiladiDate)
        {
            try {
                Persia.SunDate shamsi = Persia.Calendar.ConvertToPersian(Convert.ToDateTime(MiladiDate));
                return shamsi.Simple;
            }
            catch(FormatException)
            {
                return "";
            }
        }       

        public string Encrypt(string toEncrypt, bool useHashing, string key)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);



            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public string Decrypt(string cipherString, bool useHashing, string key)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);


            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            try
            {
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception)
            {
                tdes.Clear();
                return "";

            }
            //Release resources held by TripleDes Encryptor                
            //tdes.Clear();
            //return the Clear decrypted TEXT
            // return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public DataTable GetGharardadList()
        {
            SQLAccess sql7 = new SQLAccess();
            sql7.StoredProcedureName = "prcGetGharardadList";
            DataTable dt = new DataTable();
            dt = sql7.ExcecuteQueryToDataTable();
            return dt;
        }

        public bool IsGharardadExists(string ShomareGharardad)
        {
            bool result = false;
            SQLAccess sql = new SQLAccess();
            sql.StoredProcedureName = "prcGetGharardadByShomare";
            string[,] SpParams = new string[1, 2];
            SpParams[0, 0] = "@GharardadNumber";
            SpParams[0, 1] = ShomareGharardad;
            DataTable dt = new DataTable();
            dt = sql.ExcecuteQueryToDataTable(SpParams);
            if (dt.Rows.Count > 0)
                result = true;
            return result;
        }

        public int CountGharardad()
        {
            SQLAccess sql7 = new SQLAccess();
            sql7.StoredProcedureName = "prcGetGharardadList";
            DataTable dt = new DataTable();
            dt = sql7.ExcecuteQueryToDataTable();
            return dt.Rows.Count;
        }

        public int DeleteGharardad(string Id,string GharardadNumber)
        {
            int result = 0;
            SQLAccess sql = new SQLAccess();
            sql.StoredProcedureName = "prcDeleteGharardad";
            string[,] SpParams = new string[2, 2];
            SpParams[0, 0] = "@Id";
            SpParams[0, 1] = Id;
            SpParams[1, 0] = "@GharardadNumber";
            SpParams[1, 1] = "D_" + GharardadNumber;
            result = sql.IntExcuteSP(SpParams);
            return result;
        }

        public DataTable GetPardakhtInfo(string Id)
        {
            DataTable result = new DataTable();
            SQLAccess sql = new SQLAccess();
            sql.StoredProcedureName = "prcGetPardakhtById";
            string[,] SpParams = new string[1, 2];
            SpParams[0, 0] = "@Id";
            SpParams[0, 1] = Id;
            result = sql.ExcecuteQueryToDataTable(SpParams);
            return result;
        }

        public string GetBackupFileName()
        {
            string _filename = "";
            string year, month, day, hour, minute, second;
            string[] date = Persia.Calendar.ConvertToPersian(DateTime.Now).Simple.Split('/');
            year = date[0];
            month = date[1];
            day = date[2];
            hour = DateTime.Now.Hour.ToString();
            minute = DateTime.Now.Minute.ToString();
            second = DateTime.Now.Second.ToString();
            _filename = year + month + day + hour + minute + second + ".bak";
            return _filename;

        }
    }
}
