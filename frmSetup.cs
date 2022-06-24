using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhotoStudio
{
    public partial class frmSetup : Telerik.WinControls.UI.RadForm
    {
        private string page;
        private bool exit;
        public frmSetup(string Page)
        {
            page = Page;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            string message2 = "آیا خارج می شوید؟";
            frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 3, "");
            DialogResult dr = showinfo2.ShowDialog();
            if (dr == DialogResult.Yes)
            {
                exit = true;
                this.Close();                
            }                
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string cs = "Server=" + txbServer.Text.Trim() + ";Database=" + txbDb.Text.Trim() + ";User Id=" + txbUsername.Text.Trim() + ";Password=" + txbPassword.Text.Trim() + ";";
            SqlConnection _sqlConnection = new SqlConnection(cs);
            try
            {
                _sqlConnection.Open();
                string message2 = "ارتباط با بانک اطلاعاتی با موفقیت برقرار شد";
                frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 2, "");
                showinfo2.ShowDialog();
            }
            catch (SqlException)
            {
                string message2 = "ارتباط با بانک اطلاعاتی با شکست مواجه شد";
                frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 2, "خطا");
                showinfo2.ShowDialog();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Query = "UPDATE Setting SET DbServer = '" + txbServer.Text.Trim() +
                           "',DbName = '" + txbDb.Text.Trim() + "',DbUsername = '" + txbUsername.Text.Trim() +
                           "',DbPassword = '" + txbPassword.Text.Trim() +
                           "' WHERE Id = 1";
            int result = SQLiteAceess.Execute(Query);
            if (result > 0)
            {
                string message = "تنظیمات با موفقیت ذخیره شد ";
                frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message, 2, "");
                showinfo2.ShowDialog();
            }
            else
            {
                string message = "ذخیره تنظیمات با شکست روبرو شد ";
                frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message, 2, "خطا");
                showinfo2.ShowDialog();
            }
        }

        private void frmSetup_Load(object sender, EventArgs e)
        {            
            switch (page)
            {
                case "DB":
                    pageSetup.SelectedPage = pageDbSetup;
                    break;
                default:
                    break;
            }
        }

        private void frmSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exit)
            {
                string message2 = "آیا خارج می شوید؟";
                frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 3, "");
                DialogResult dr = showinfo2.ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    exit = true;
                    this.Close();
                }
                    
            }
        }
    }
}
