using System;
using System.IO;
using System.Windows.Forms;

namespace PhotoStudio
{
    static class Program
    {
        public static string SqlConnectionString;
        public static string SqlUsername;
        public static string SqlServer;        
        public static int UserId;
        public static string UserFullName;
        public static string LocalToday;
        public static string StartupPath = Application.StartupPath;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if(!File.Exists(StartupPath + @"\RHS.dll"))
            {
                string mes = "فایل RHS.dll یافت نشد. لطفا با پشتیبانی تماس بگیرید";
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, "خطا");
                fm.ShowDialog();
                Environment.Exit(0);
            }
            if (!File.Exists(StartupPath + @"\PAPC.dll"))
            {
                string mes = "فایل PAPC.dll یافت نشد. لطفا با پشتیبانی تماس بگیرید";
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, "خطا");
                fm.ShowDialog();
                Environment.Exit(0);
            }
            LogicLayer lg = new LogicLayer();
            if (lg.IsSoftwareLock())
                Environment.Exit(0);

            //MachineId Check
            int error = lg.EqualMachineIds();
            if (error == 0)
            {
                frmActiveSoftware formActive = new frmActiveSoftware();
                formActive.ShowDialog();
                Environment.Exit(0);               
            }
            if (error == -1)
            {
                lg.UpdateSqlite("AppLock", "1");
                Environment.Exit(0);
            }

            //Date Limitation Check
            string error2 = lg.CheckDateLimitation();
            if (error2 != "Unlimited")
            {
                if (Convert.ToInt32(error2) < 0)
                {
                    lg.UpdateSqlite("AppLock", "1");
                    Environment.Exit(0);
                }
            }
            //Set Connection String
            lg.SetSqLConectionString();
            //Insert Data Limitation Check
            error2 = lg.CheckInsertDataLimitation();
            if (error2 != "Unlimited")
            {
                if (Convert.ToInt32(error2) < 0)
                {
                    lg.UpdateSqlite("AppLock", "1");
                    Environment.Exit(0);
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin login = new frmLogin();
            DialogResult dr = login.ShowDialog();
            if (dr == DialogResult.OK)
            {
                frmMain formMain = new frmMain();
                formMain.ShowDialog();
            }
            if (dr == DialogResult.Cancel)
            {
                Application.Exit();
            }
            
        }      
    }
}