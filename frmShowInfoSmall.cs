using System;

namespace PhotoStudio
{
    public partial class frmShowInfoSmall : Telerik.WinControls.UI.RadForm
    {       
        private string _message1;
        private int _bottum;
        private string _caption;

        public frmShowInfoSmall(string Message1, int Bottum,string Caption)
        {           
            _message1 = Message1;
            _bottum = Bottum;
            _caption = Caption;
            InitializeComponent();
        }

        private void frmShowInfoSmall_Load(object sender, EventArgs e)
        {         
            this.Text = _caption;
            lblInfo1.Text = _message1;
            ShowBottums();
        }

        private void ShowBottums()
        {           
            switch (_bottum)
            {
                case 1:
                    {
                        btn1.Visible = true;
                        btn1.Text = "بلی";
                        break;
                    }
                case 2:
                    {
                        btn2.Visible = true;
                        btn2.Text = "تایید";
                        break;
                    }
                case 3:
                    {
                        btn1.Visible = true;
                        btn2.Visible = true;
                        btn1.Text = "بلی";
                        btn2.Text = "خیر";
                        break;
                    }
                case 6:
                    {
                        btn1.Visible = true;
                        btn2.Visible = true;
                        btn3.Visible = true;
                        btn1.Text = "بلی";
                        btn2.Text = "خیر";
                        btn3.Text = "انصراف";
                        break;
                    }
            }

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;            
            this.Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;            
            this.Close();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;           
            this.Close();
        }
    }
}
