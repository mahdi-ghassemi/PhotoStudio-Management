using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


namespace PhotoStudio
{
    public partial class frmMain : Telerik.WinControls.UI.RadForm
    {

        private bool exit;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblCompanyName.Text = PAPC.Info.CompanyName;
            this.Text = PAPC.Info.CompanyName;
            lblVersion.Text = PAPC.Info.Version;
            lblLocalDate.Text = "امروز: " + Program.LocalToday;
            lblUsernameName.Text = "کاربر جاری: " + Program.UserFullName;
            DesktopAlertSetup("ورود به سیستم", "",User.UserImageData);
            lblUsernameName.Image = imageList2.Images[0];
        }

        private void DesktopAlertSetup(string Caption, string Content, byte[] ImageData)
        {
                       
            Image perImage;
            //Read image data into a memory stream
            
            using (MemoryStream ms = new MemoryStream(ImageData, 0, ImageData.Length))
            {
                ms.Write(ImageData, 0, ImageData.Length);

                //Set image variable value using memory stream.
                perImage = Image.FromStream(ms, true);
            }
            imgUserList.Images.Add(perImage);
            imageList2.Images.Add(perImage);
            this.alertMain.Popup.AlertElement.CaptionElement.TextAndButtonsElement.Font = new Font("Tahoma", 9, FontStyle.Regular);
            this.alertMain.Popup.AlertElement.CaptionElement.TextAndButtonsElement.TextAlignment = ContentAlignment.MiddleCenter;
            this.alertMain.Popup.AlertElement.CaptionElement.TextAndButtonsElement.ForeColor = Color.Red;
            alertMain.AutoClose = true;
            alertMain.CaptionText = Caption;
            string ctext = "<html><size=9><font=tahoma>" + Content;
            alertMain.ContentText = ctext;
            alertMain.ContentImage = imgUserList.Images[0];
            this.Invoke((MethodInvoker)delegate { alertMain.Show(); });
            //DesktopAlert1.Show();
        }

        private void btnGharardad_Click(object sender, EventArgs e)
        {
            frmGharardad gharardad = new frmGharardad();
            gharardad.Show();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            frmSetup setup = new frmSetup("");
            setup.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
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
                else
                    e.Cancel = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearch search = new frmSearch();
            search.Show();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            frmOptions opt = new frmOptions();
            opt.Show();
        }
    }
}
