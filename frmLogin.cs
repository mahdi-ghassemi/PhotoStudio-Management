using System;
using System.Windows.Forms;


namespace PhotoStudio
{
    public partial class frmLogin : Telerik.WinControls.UI.RadForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            LogicLayer lagic = new LogicLayer();
            int _errorCode = lagic.CheckLoginDetails(txbUsername.Text, txbPassword.Text);
            switch (_errorCode)
            {
                case 0:
                    {
                        // the username or password is not correct.
                        string mes = "نام کاربری یا کلمه عبور اشتباه است";
                        frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2,"خطا");
                        fm.ShowDialog();

                        txbUsername.Text = "";
                        txbPassword.Text = "";
                        txbUsername.Focus();
                        break;
                    }
                case -2:
                    {
                        // plese enter username and password 
                        string mes = "لطفا نام کاربری یا کلمه عبور را وارد نمایید";
                        frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, "خطا");
                        fm.ShowDialog();

                        txbUsername.Focus();
                        break;
                    }
                case -3:
                    {
                        // please enter username
                        string mes = "لطفا نام کاربری را وارد نمایید";
                        frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, "خطا");
                        fm.ShowDialog();

                        txbUsername.Text = "";
                        txbUsername.Focus();
                        break;
                    }
                case -4:
                    {
                        // please enter password
                        string mes = "لطفا کلمه عبور را وارد نمایید";
                        frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, "خطا");
                        fm.ShowDialog();

                        txbPassword.Text = "";
                        txbPassword.Focus();
                        break;
                    }
                default:
                    {                        
                        lagic.SetTodayDate();
                        lagic.SetUserImage(txbUsername.Text, txbPassword.Text);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    }
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LogicLayer lg = new LogicLayer();         
            txbUsername.Focus();
            Program.SqlConnectionString = lg.GetSQLCS();
        }

        private void txbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        private void txbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        private void txbDbSetup_Click(object sender, EventArgs e)
        {
            frmSetup setup = new frmSetup("DB");
            setup.ShowDialog();
        }
    }
}

