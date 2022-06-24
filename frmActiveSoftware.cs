using System;

namespace PhotoStudio
{
    public partial class frmActiveSoftware : Telerik.WinControls.UI.RadForm
    {
        public frmActiveSoftware()
        {
            InitializeComponent();
        }

        private void frmActiveSoftware_Load(object sender, EventArgs e)
        {
            txbCustomerName.Text = SQLiteAceess.ExecuteQuery("CustomerName");
            txbBuyDate.Text = Persia.Calendar.ConvertToPersian(Convert.ToDateTime(SQLiteAceess.ExecuteQuery("BuyDate"))).Simple;
            txbSerial.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void txbSerial_TextChanged(object sender, EventArgs e)
        {
            if (txbActiveCode.Text != "" && txbSerial.Text != "")
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;
        }

        private void txbActiveCode_TextChanged(object sender, EventArgs e)
        {
            if (txbActiveCode.Text != "" && txbSerial.Text != "")
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txbSerial.Text.Trim() == SQLiteAceess.ExecuteQuery("SoftwareSerialNumber") && txbActiveCode.Text.Trim() == SQLiteAceess.ExecuteQuery("ActivationCode"))
            {
                LogicLayer lg = new LogicLayer();
                string machinId = lg.GetMachineId();
                int err = lg.UpdateSqlite("SystemId", machinId);
                if(err == 1)
                {
                    string mes = "فعال سازی نرم افزار با موفقیت انچام گرفت.لطفا مجددا برنامه را اجرا نمایید.";
                    frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, "خطا");
                    fm.ShowDialog();
                    this.Close();
                }

            }
            else
            {
                string mes = "شماره سریال یا کد فعال سازی اشتباه می باشد";
                frmShowInfoSmall fm = new frmShowInfoSmall(mes, 2, "خطا");
                fm.ShowDialog();
            }
        }
    }
}
