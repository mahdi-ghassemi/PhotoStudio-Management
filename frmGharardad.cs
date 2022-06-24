using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Telerik.WinControls.UI;
using System.Diagnostics;
using Stimulsoft.Report;


namespace PhotoStudio
{
    public partial class frmGharardad : Telerik.WinControls.UI.RadForm
    {
        private bool NewRecord;
        private DataTable dt;
        private bool EditRecord;
        private int _position;
        private string CurrentShomareGharardad = "";
        private bool exit;
        private int KolePardakhti = 0;
        private string PardakhtId;
        private string SelectGharardadNumber = ""; 
        public frmGharardad()
        {
            InitializeComponent();
        }

        public frmGharardad(string GharardadNumber)
        {
            SelectGharardadNumber = GharardadNumber;
            InitializeComponent();
        }

        
        private void frmGharardad_Load(object sender, EventArgs e)
        {
            txbTarikhGharardad.GeoDate = DateTime.Now;
            txbTarikhMarasem.GeoDate = DateTime.Now;
            txbTarikhPardakht.GeoDate = DateTime.Now;
            txbSarresid.GeoDate = DateTime.Now;    

            pageMainGharardad.SelectedPage = pageGharadad;
           
            FillDataTable();
            SetControls();
            GharardadControlReadOnly(true);
            GharardadControlEn(false);
            FillPardakhtTable();
            CalculateMandeh();
            if(SelectGharardadNumber != "")
            {
                _position = bindingSource1.Find("GharardadNumber", SelectGharardadNumber);
                bindGharadad.BindingSource.Position = _position;
                CheckBoxesSet();
                CalculateMandeh();
                FillPardakhtTable();
            }
        }

        private void ClearControls()
        {
            txbId.DataBindings.Clear();
            rdbAksNashod.DataBindings.Clear();
            rdbAksShod.DataBindings.Clear();
            chbTaeedAks.DataBindings.Clear();
            chbDemo.DataBindings.Clear();
            chbOriginal.DataBindings.Clear();
            chbChapAks.DataBindings.Clear();
            chbTaeedTarahi.DataBindings.Clear();
            chbTahvilAks.DataBindings.Clear();
            chbTahvilFilmKhaam.DataBindings.Clear();
            chbEntekhaabAksKhaam.DataBindings.Clear();

            txbShomareGharardad.DataBindings.Clear();
            txbNameDamad.DataBindings.Clear();
            txbNameAroos.DataBindings.Clear();
            txbTarahName.DataBindings.Clear();
            txbTadvingarName.DataBindings.Clear();
            txbTozihat.DataBindings.Clear();
            txbTarikhGharardad.DataBindings.Clear();
            txbTamasDamad.DataBindings.Clear();
            txbTalar.DataBindings.Clear();
            txbMablaghKol.DataBindings.Clear();
            txbTakhfif.DataBindings.Clear();
            txbTamasAroos.DataBindings.Clear();
            txbTarikhMarasem.DataBindings.Clear();
            txbSaatMarasem.DataBindings.Clear();
            txbTozihatMarasem.DataBindings.Clear();
            chbAks16x21.DataBindings.Clear();
            chbAks20x25.DataBindings.Clear();
            chbAks20x30.DataBindings.Clear();
            chbAks30x40.DataBindings.Clear();
            chbZhoornal30x40.DataBindings.Clear();
            chbZhoornal30x50.DataBindings.Clear();
            chbZhoornal30x60.DataBindings.Clear();
            chbZhoornal40x60.DataBindings.Clear();
            chbZhoornal40x80.DataBindings.Clear();
            txbKolMabkaghAks.DataBindings.Clear();
            txbTozihatAks.DataBindings.Clear();
            txbFilm.DataBindings.Clear();
            chbNoorpardazi.DataBindings.Clear();
            chbCamear2.DataBindings.Clear();
            chbCamera3.DataBindings.Clear();
            chbClipSport.DataBindings.Clear();
            chbKreen.DataBindings.Clear();
            txbSaierKhadematFilm.DataBindings.Clear();
            txbKolMablaghFilm.DataBindings.Clear();
            txbTozihatFilm.DataBindings.Clear();
            txbTedadAks16x21.DataBindings.Clear();
            txbTedadAks20x25.DataBindings.Clear();
            txbTedadAks30x40.DataBindings.Clear();
            txbTedadAks20x30.DataBindings.Clear();

            txbTedadJurnal30x40.DataBindings.Clear();
            txbTedadJurnal30x50.DataBindings.Clear();
            txbTedadJurnal30x60.DataBindings.Clear();
            txbTedadJurnal40x60.DataBindings.Clear();
            txbTedadJurnal40x80.DataBindings.Clear();
            txbPath.DataBindings.Clear();


            rdbAksNashod.CheckState = System.Windows.Forms.CheckState.Unchecked;
            rdbAksShod.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbTaeedAks.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbDemo.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbOriginal.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbChapAks.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbEntekhaabAksKhaam.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbTaeedAks.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbTaeedTarahi.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbTahvilFilmKhaam.CheckState = System.Windows.Forms.CheckState.Unchecked;


            txbId.Text = "";
            txbShomareGharardad.Text = "";
            txbNameDamad.Text = "";
            txbNameAroos.Text = "";
            txbTarahName.Text = "";
            txbTadvingarName.Text = "";
            txbTozihat.Text = "";
            txbTarikhGharardad.GeoDate = DateTime.Now;
            txbTamasDamad.Text = "";
            txbTalar.Text = "";
            txbMablaghKol.Text = "";
            txbTakhfif.Text = "";
            txbTamasAroos.Text = "";
            txbTarikhMarasem.GeoDate = DateTime.Now;
            txbSaatMarasem.Text = "";
            txbTozihatMarasem.Text = "";
            txbPath.Text = "";
            chbAks16x21.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbAks20x25.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbAks20x30.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbAks30x40.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbZhoornal30x40.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbZhoornal30x50.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbZhoornal30x60.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbZhoornal40x60.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbZhoornal40x80.CheckState = System.Windows.Forms.CheckState.Unchecked;
            txbKolMabkaghAks.Text = "";
            txbTozihatAks.Text = "";
            txbFilm.Text = "";
            chbNoorpardazi.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbCamear2.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbCamera3.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbClipSport.CheckState = System.Windows.Forms.CheckState.Unchecked;
            chbKreen.CheckState = System.Windows.Forms.CheckState.Unchecked;
            txbSaierKhadematFilm.Text = "";
            txbKolMablaghFilm.Text = "";
            txbTozihatFilm.Text = "";
            txbTedadAks16x21.Text = "";
            txbTedadAks20x25.Text = "";
            txbTedadAks30x40.Text = "";
            txbTedadAks20x30.Text = "";

            txbTedadJurnal30x40.Text = "";
            txbTedadJurnal30x50.Text = "";
            txbTedadJurnal30x60.Text = "";
            txbTedadJurnal40x60.Text = "";
            txbTedadJurnal40x80.Text = "";
        }

        private void FillDataTable()
        {
            LogicLayer lg = new LogicLayer();
            dt = new DataTable();
            dt.Clear();
            ClearControls();
            dt = lg.GetGharardadList();
            bindingSource1.DataSource = dt;
            bindGharadad.BindingSource = this.bindingSource1;
            this.bindingSource1.MoveLast();
            CheckBoxesSet();          

            txbId.DataBindings.Add(new Binding("Text", bindingSource1, "Id", true));
            txbShomareGharardad.DataBindings.Add(new Binding("Text", bindingSource1, "GharardadNumber", true));
            txbNameDamad.DataBindings.Add(new Binding("Text", bindingSource1, "DamadName", true));
            txbNameAroos.DataBindings.Add(new Binding("Text", bindingSource1, "AroosName", true));
            txbTarahName.DataBindings.Add(new Binding("Text", bindingSource1, "TarahName", true));
            txbTadvingarName.DataBindings.Add(new Binding("Text", bindingSource1, "TadvingarName", true));
            txbTozihat.DataBindings.Add(new Binding("Text", bindingSource1, "TozihatGharardad", true));
            txbTamasDamad.DataBindings.Add(new Binding("Text", bindingSource1, "ShomareTamasDamad", true));
            txbTalar.DataBindings.Add(new Binding("Text", bindingSource1, "TalarAddress", true));
            txbMablaghKol.DataBindings.Add(new Binding("Text", bindingSource1, "MablaghGharardad", true));
            txbTakhfif.DataBindings.Add(new Binding("Text", bindingSource1, "Takhfif", true));
            txbTamasAroos.DataBindings.Add(new Binding("Text", bindingSource1, "ShomareTamasAroos", true));
            txbSaatMarasem.DataBindings.Add(new Binding("Text", bindingSource1, "SaatMarasem", true));
            txbTozihatMarasem.DataBindings.Add(new Binding("Text", bindingSource1, "TozihatMarasem", true));
            txbKolMabkaghAks.DataBindings.Add(new Binding("Text", bindingSource1, "KolMablaghAks", true));
            txbTozihatAks.DataBindings.Add(new Binding("Text", bindingSource1, "TozihatAks", true));
            txbFilm.DataBindings.Add(new Binding("Text", bindingSource1, "Filmbardari", true));
            txbSaierKhadematFilm.DataBindings.Add(new Binding("Text", bindingSource1, "SaaierKhadamatFilm", true));
            txbKolMablaghFilm.DataBindings.Add(new Binding("Text", bindingSource1, "KolMablaghFilm", true));
            txbTozihatFilm.DataBindings.Add(new Binding("Text", bindingSource1, "TozihatFilm", true));
            txbPath.DataBindings.Add(new Binding("Text", bindingSource1, "FolderPath", true));

            txbTedadAks16x21.DataBindings.Add(new Binding("Text", bindingSource1, "TedadAks16x21", true));
            txbTedadAks20x25.DataBindings.Add(new Binding("Text", bindingSource1, "TedadAks20x25", true));
            txbTedadAks30x40.DataBindings.Add(new Binding("Text", bindingSource1, "TedadAks30x40", true));
            txbTedadAks20x30.DataBindings.Add(new Binding("Text", bindingSource1, "TedadAks20x30", true));

            txbTedadJurnal30x40.DataBindings.Add(new Binding("Text", bindingSource1, "TedadJurnal30x40", true));
            txbTedadJurnal30x50.DataBindings.Add(new Binding("Text", bindingSource1, "TedadJurnal30x50", true));
            txbTedadJurnal30x60.DataBindings.Add(new Binding("Text", bindingSource1, "TedadJurnal30x60", true));
            txbTedadJurnal40x60.DataBindings.Add(new Binding("Text", bindingSource1, "TedadJurnal40x60", true));
            txbTedadJurnal40x80.DataBindings.Add(new Binding("Text", bindingSource1, "TedadJurnal40x80", true));
        }

        private void frmGharardad_Shown(object sender, EventArgs e)
        {
            this.dgvPardakhtha.GridViewElement.GroupPanelElement.Text = "برای گروه بندی یک ستون را به اینجا بکشید و رها کنید";
            int count = bindingSource1.Count;
            bindingNavigatorCountItem.Text = "از" + " " + string.Format("{0}", count);           
        }

        private void addNewToolStripButton_Click(object sender, EventArgs e)
        {
            GharardadControlEn(true);
            addNewToolStripButton.Enabled = false;
            openToolStripButton.Enabled = false;
            GharardadControlReadOnly(false);
            deleteToolStripButton.Enabled = true;
            NewRecord = true;
            ClearControls();
            cmbNoePardakht.SelectedIndex = 0;
            dgvPardakhtha.Rows.Clear();
            KolePardakhti = 0;
            CalculateMandeh();
        }

        private void GharardadControlReadOnly(bool Status)
        {
            txbShomareGharardad.ReadOnly = Status;
            txbTadvingarName.ReadOnly = Status;
            txbTakhfif.ReadOnly = Status;
            txbTozihat.ReadOnly = Status;
            txbNameDamad.ReadOnly = Status;
            txbNameAroos.ReadOnly = Status;
            txbTamasDamad.ReadOnly = Status;
            txbTamasAroos.ReadOnly = Status;
            txbTarahName.ReadOnly = Status;
            txbSaatMarasem.ReadOnly = Status;
            txbTozihatMarasem.ReadOnly = Status;
            txbTalar.ReadOnly = Status;
            txbTozihatAks.ReadOnly = Status;
            txbTozihatFilm.ReadOnly = Status;
            txbKolMabkaghAks.ReadOnly = Status;
            txbFilm.ReadOnly = Status;
            txbSaierKhadematFilm.ReadOnly = Status;
            txbKolMablaghFilm.ReadOnly = Status;
            txbPath.ReadOnly = Status;

            rdbAksNashod.ReadOnly = Status;
            rdbAksShod.ReadOnly = Status;
            chbAks16x21.ReadOnly = Status;
            chbAks20x25.ReadOnly = Status;
            chbAks20x30.ReadOnly = Status;
            chbAks30x40.ReadOnly = Status;
            chbCamear2.ReadOnly = Status;
            chbCamera3.ReadOnly = Status;
            chbChapAks.ReadOnly = Status;
            chbClipSport.ReadOnly = Status;
            chbDemo.ReadOnly = Status;
            chbKreen.ReadOnly = Status;
            chbNoorpardazi.ReadOnly = Status;
            chbOriginal.ReadOnly = Status;
            chbTaeedAks.ReadOnly = Status;
            chbZhoornal30x40.ReadOnly = Status;
            chbZhoornal30x50.ReadOnly = Status;
            chbZhoornal30x60.ReadOnly = Status;
            chbZhoornal40x60.ReadOnly = Status;
            chbZhoornal40x80.ReadOnly = Status;
            chbEntekhaabAksKhaam.ReadOnly = Status;
            chbTahvilAks.ReadOnly = Status;
            chbTaeedTarahi.ReadOnly = Status;
            chbTahvilFilmKhaam.ReadOnly = Status;
        }

        private void GharardadControlEn(bool Status)
        {           
            txbTarikhGharardad.Enabled = Status;           
            txbTarikhMarasem.Enabled = Status;          
            btnControlTarikh.Enabled = Status;            
            saveToolStripButton.Enabled = Status;
            btnBrowse.Enabled = Status;           
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if(dgvPardakhtha.RowCount > 0)
            {
                string message3 = "این قرارداد دارای پرداخت می باشد. برای حذف آن ابتدا پرداخت های آن را حذف نمایید";
                frmShowInfoSmall showinfo3 = new frmShowInfoSmall(message3, 2, "خطا");
                showinfo3.ShowDialog();
                GharardadControlEn(false);
                FillDataTable();
                FillPardakhtTable();
                CalculateMandeh();
                SetControls();
                return;
            }
            if (NewRecord == false && EditRecord == false)
            {
                string message = "آیا برای حذف قرارداد مطمئن هستید؟";
                frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 3, "هشدار");
                DialogResult dr = showinfo.ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    LogicLayer lg = new LogicLayer();
                    int error = lg.DeleteGharardad(txbId.Text.Trim(),txbShomareGharardad.Text.Trim());
                    if (error == 1)
                    {
                        string message2 = "قرارداد با موفقیت حذف شد";
                        frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 2, "");
                        showinfo2.ShowDialog();
                        GharardadControlEn(false);
                        FillDataTable();
                        FillPardakhtTable();
                        CalculateMandeh();
                        SetControls();
                        return;
                    }
                    else
                    {
                        string message2 = "حذف قرار داد با شکست مواجه گردید";
                        frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 2, "خطا");
                        showinfo2.ShowDialog();
                        GharardadControlEn(false);
                        FillDataTable();
                        FillPardakhtTable();
                        CalculateMandeh();
                        SetControls();
                        return;
                    }
                }
                else
                    return;
                
            }
            else
            {
                addNewToolStripButton.Enabled = true;
                FillDataTable();
                SetControls();
                GharardadControlReadOnly(true);
                GharardadControlEn(false);
                pageMainGharardad.SelectedPage = pageGharadad;
                if (NewRecord == true)
                    NewRecord = false;
                if (EditRecord == true)
                    EditRecord = false;
            }        
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (txbShomareGharardad.Text == "")
            {
                string message = "لطفا شماره قرارداد را وارد نمایید";
                frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 2, "خطا");
                showinfo.ShowDialog();
                txbShomareGharardad.Focus();
                return;
            }
            LogicLayer lg = new LogicLayer();
            if (CurrentShomareGharardad != txbShomareGharardad.Text.Trim())
            {
                if (lg.IsGharardadExists(txbShomareGharardad.Text.Trim()))
                {
                    string message = "شماره قرارداد تکراری میباشد";
                    frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 2, "خطا");
                    showinfo.ShowDialog();
                    txbShomareGharardad.Focus();
                    return;
                }
            }

            string EntekhabAks = "0";
            string TaeedAks = "0";
            string Demo = "0";
            string Orginal = "0";
            string ChapAks = "0";

            string EntekhabAksKhaam = "0";
            string TahvilAks = "0";
            string TaeedTarahi = "0";
            string TahvilFilmKhaam = "0";

            string Id = txbId.Text.Trim();
            string GharardadNumber = txbShomareGharardad.Text.Trim();
            string DamadName = txbNameDamad.Text.Trim();
            string AroosName = txbNameAroos.Text.Trim();
            string TarahName = txbTarahName.Text.Trim();
            string TadvingarName = txbTadvingarName.Text.Trim();
            string TozihatGharardad = txbTozihat.Text.Trim();
            DateTime tkh = txbTarikhGharardad.GeoDate.Value;
            string TarikhGharardad = tkh.ToString("yyyy/MM/dd");
            string ShomareTamasDamad = txbTamasDamad.Text.Trim();
            string TalarAddress = txbTalar.Text.Trim();
            string MablaghGharardad = txbMablaghKol.Text.Trim();
            string Takhfif = txbTakhfif.Text.Trim();
            string FolderPath = txbPath.Text.Trim();
            string Deleted = "0";
            string ShomareTamasAroos = txbTamasAroos.Text.Trim();
            DateTime tmar = txbTarikhMarasem.GeoDate.Value;
            string TarikhMarasem = tmar.ToString("yyyy/MM/dd");
            string SaatMarasem = txbSaatMarasem.Text.Trim();
            string TozihatMarasem = txbTozihatMarasem.Text.Trim();
            string Aks16x21 = "0";
            string Aks20x25 = "0";
            string Aks20x30 = "0";
            string Aks30x40 = "0";
            string Zhoornal30x40 = "0";
            string Zhoornal30x50 = "0";
            string Zhoornal30x60 = "0";
            string Zhoornal40x60 = "0";
            string Zhoornal40x80 = "0";
            string KolMablaghAks = txbKolMabkaghAks.Text.Trim();
            string TozihatAks = txbTozihatAks.Text.Trim();
            string Filmbardari = txbFilm.Text.Trim();
            string Noorpardazi = "0";
            string Camera2 = "0";
            string Camera3 = "0";
            string ClipSport = "0";
            string Kreen = "0";
            string SaaierKhadamatFilm = txbSaierKhadematFilm.Text.Trim();
            string KolMablaghFilm = txbKolMablaghFilm.Text.Trim();
            string TozihatFilm = txbTozihatFilm.Text.Trim();

            string TedadAks16x21 = txbTedadAks16x21.Text.Trim();
            string TedadAks20x25 = txbTedadAks20x25.Text.Trim();
            string TedadAks30x40 = txbTedadAks30x40.Text.Trim();
            string TedadAks20x30 = txbTedadAks20x30.Text.Trim();

            string TedadJurnal30x40 = txbTedadJurnal30x40.Text.Trim();
            string TedadJurnal30x50 = txbTedadJurnal30x50.Text.Trim();
            string TedadJurnal30x60 = txbTedadJurnal30x60.Text.Trim();
            string TedadJurnal40x60 = txbTedadJurnal40x60.Text.Trim();
            string TedadJurnal40x80 = txbTedadJurnal40x80.Text.Trim();


            if (rdbAksShod.CheckState == System.Windows.Forms.CheckState.Checked)
                EntekhabAks = "1";
            if (rdbAksNashod.CheckState == System.Windows.Forms.CheckState.Checked)
                EntekhabAks = "0";

            if (chbTaeedAks.CheckState == CheckState.Checked)
                TaeedAks = "1";
            else
                TaeedAks = "0";

            if (chbChapAks.CheckState == System.Windows.Forms.CheckState.Checked)
                ChapAks = "1";
            else
                ChapAks = "0";
            if (chbDemo.CheckState == System.Windows.Forms.CheckState.Checked)
                Demo = "1";
            else
                Demo = "0";
            if (chbOriginal.CheckState == System.Windows.Forms.CheckState.Checked)
                Orginal = "1";
            else
                Orginal = "0";
            if (chbTaeedAks.CheckState == System.Windows.Forms.CheckState.Checked)
                ChapAks = "1";
            else
                ChapAks = "0";
            if (chbAks16x21.CheckState == System.Windows.Forms.CheckState.Checked)
                Aks16x21 = "1";
            else
                Aks16x21 = "0";
            if (chbAks20x25.CheckState == System.Windows.Forms.CheckState.Checked)
                Aks20x25 = "1";
            else
                Aks20x25 = "0";
            if (chbAks20x30.CheckState == System.Windows.Forms.CheckState.Checked)
                Aks20x30 = "1";
            else
                Aks20x30 = "0";
            if (chbAks30x40.CheckState == System.Windows.Forms.CheckState.Checked)
                Aks30x40 = "1";
            else
                Aks30x40 = "0";
            if (chbCamear2.CheckState == System.Windows.Forms.CheckState.Checked)
                Camera2 = "1";
            else
                Camera2 = "0";
            if (chbCamera3.CheckState == System.Windows.Forms.CheckState.Checked)
                Camera3 = "1";
            else
                Camera3 = "0";
            if (chbClipSport.CheckState == System.Windows.Forms.CheckState.Checked)
                ClipSport = "1";
            else
                ClipSport = "0";
            if (chbKreen.CheckState == System.Windows.Forms.CheckState.Checked)
                Kreen = "1";
            else
                Kreen = "0";
            if (chbNoorpardazi.CheckState == System.Windows.Forms.CheckState.Checked)
                Noorpardazi = "1";
            else
                Noorpardazi = "0";
            if (chbZhoornal30x40.CheckState == System.Windows.Forms.CheckState.Checked)
                Zhoornal30x40 = "1";
            else
                Zhoornal30x40 = "0";
            if (chbZhoornal30x50.CheckState == System.Windows.Forms.CheckState.Checked)
                Zhoornal30x50 = "1";
            else
                Zhoornal30x50 = "0";
            if (chbZhoornal30x60.CheckState == System.Windows.Forms.CheckState.Checked)
                Zhoornal30x60 = "1";
            else
                Zhoornal30x60 = "0";
            if (chbZhoornal40x60.CheckState == System.Windows.Forms.CheckState.Checked)
                Zhoornal40x60 = "1";
            else
                Zhoornal40x60 = "0";
            if (chbZhoornal40x80.CheckState == System.Windows.Forms.CheckState.Checked)
                Zhoornal40x80 = "1";
            else
                Zhoornal40x80 = "0";

            if (chbEntekhaabAksKhaam.CheckState == CheckState.Checked)
                EntekhabAksKhaam = "1";
            else
                EntekhabAksKhaam = "0";

            if (chbTahvilAks.CheckState == CheckState.Checked)
                TahvilAks = "1";
            else
                TahvilAks = "0";

            if (chbTaeedTarahi.CheckState == CheckState.Checked)
                TaeedTarahi = "1";
            else
                TaeedTarahi = "0";

            if (chbTahvilFilmKhaam.CheckState == CheckState.Checked)
                TahvilFilmKhaam = "1";
            else
                TahvilFilmKhaam = "0";           

            SQLAccess sql = new SQLAccess();
            string[,] SpParams = null;
            if (EditRecord == true)
            {
                sql.StoredProcedureName = "prcUpdateGharardad";
                EditRecord = false;
                SpParams = new string[56, 2];
                SpParams[55, 0] = "@Id";
                SpParams[55, 1] = Id;
            }
            if (NewRecord == true)
            {
                LogicLayer lg2 = new LogicLayer();
                sql.StoredProcedureName = "prcInsertGharardad";
                NewRecord = false;
                SpParams = new string[55, 2];
                int LimitionGharardad = PAPC.Info.InsertLimition;
                if(LimitionGharardad != 0)
                {
                    int CountGharardad = lg2.CountGharardad();
                    if(CountGharardad > LimitionGharardad)
                    {
                        string message = "امکان ثبت قرارداد جدید وجود ندارد.لطفا با پشتیبانی تماس بگیرید";
                        frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 2, "خطا");
                        showinfo.ShowDialog();
                        GharardadControlEn(false);
                        FillDataTable();
                        SetControls();
                        return;
                    }
                } 
            }            
            
            SpParams[0, 0] = "@EntekhabAks";
            SpParams[0, 1] = EntekhabAks;

            SpParams[1, 0] = "@TaeedAks";
            SpParams[1, 1] = TaeedAks;

            SpParams[2, 0] = "@Demo";
            SpParams[2, 1] = Demo;

            SpParams[3, 0] = "@Orginal";
            SpParams[3, 1] = Orginal;

            SpParams[4, 0] = "@ChapAks";
            SpParams[4, 1] = ChapAks;

            SpParams[5, 0] = "@GharardadNumber";
            SpParams[5, 1] = GharardadNumber;

            SpParams[6, 0] = "@DamadName";
            SpParams[6, 1] = DamadName;

            SpParams[7, 0] = "@AroosName";
            SpParams[7, 1] = AroosName;

            SpParams[8, 0] = "@TarahName";
            SpParams[8, 1] = TarahName;

            SpParams[9, 0] = "@TadvingarName";
            SpParams[9, 1] = TadvingarName;

            SpParams[10, 0] = "@TozihatGharardad";
            SpParams[10, 1] = TozihatGharardad;

            SpParams[11, 0] = "@TarikhGharardad";
            SpParams[11, 1] = TarikhGharardad;

            SpParams[12, 0] = "@ShomareTamasDamad";
            SpParams[12, 1] = ShomareTamasDamad;

            SpParams[13, 0] = "@TalarAddress";
            SpParams[13, 1] = TalarAddress;

            SpParams[14, 0] = "@MablaghGharardad";
            SpParams[14, 1] = MablaghGharardad;

            SpParams[15, 0] = "@Takhfif";
            SpParams[15, 1] = Takhfif;

            SpParams[16, 0] = "@Deleted";
            SpParams[16, 1] = Deleted;

            SpParams[17, 0] = "@ShomareTamasAroos";
            SpParams[17, 1] = ShomareTamasAroos;

            SpParams[18, 0] = "@TarikhMarasem";
            SpParams[18, 1] = TarikhMarasem;

            SpParams[19, 0] = "@SaatMarasem";
            SpParams[19, 1] = SaatMarasem;

            SpParams[20, 0] = "@TozihatMarasem";
            SpParams[20, 1] = TozihatMarasem;

            SpParams[21, 0] = "@Aks16x21";
            SpParams[21, 1] = Aks16x21;

            SpParams[22, 0] = "@Aks20x25";
            SpParams[22, 1] = Aks20x25;

            SpParams[23, 0] = "@Aks20x30";
            SpParams[23, 1] = Aks20x30;

            SpParams[24, 0] = "@Aks30x40";
            SpParams[24, 1] = Aks30x40;

            SpParams[25, 0] = "@Zhoornal30x40";
            SpParams[25, 1] = Zhoornal30x40;

            SpParams[26, 0] = "@Zhoornal30x50";
            SpParams[26, 1] = Zhoornal30x50;

            SpParams[27, 0] = "@Zhoornal30x60";
            SpParams[27, 1] = Zhoornal30x60;

            SpParams[28, 0] = "@Zhoornal40x60";
            SpParams[28, 1] = Zhoornal40x60;

            SpParams[29, 0] = "@Zhoornal40x80";
            SpParams[29, 1] = Zhoornal40x80;

            SpParams[30, 0] = "@KolMablaghAks";
            SpParams[30, 1] = KolMablaghAks;

            SpParams[31, 0] = "@TozihatAks";
            SpParams[31, 1] = TozihatAks;

            SpParams[32, 0] = "@Filmbardari";
            SpParams[32, 1] = Filmbardari;

            SpParams[33, 0] = "@Noorpardazi";
            SpParams[33, 1] = Noorpardazi;

            SpParams[34, 0] = "@Camera2";
            SpParams[34, 1] = Camera2;

            SpParams[35, 0] = "@Camera3";
            SpParams[35, 1] = Camera3;

            SpParams[36, 0] = "@ClipSport";
            SpParams[36, 1] = ClipSport;

            SpParams[37, 0] = "@Kreen";
            SpParams[37, 1] = Kreen;

            SpParams[38, 0] = "@SaaierKhadamatFilm";
            SpParams[38, 1] = SaaierKhadamatFilm;

            SpParams[39, 0] = "@KolMablaghFilm";
            SpParams[39, 1] = KolMablaghFilm;

            SpParams[40, 0] = "@TozihatFilm";
            SpParams[40, 1] = TozihatFilm;

            SpParams[41, 0] = "@TedadAks16x21";
            SpParams[41, 1] = TedadAks16x21;

            SpParams[42, 0] = "@TedadAks20x25";
            SpParams[42, 1] = TedadAks20x25;

            SpParams[43, 0] = "@TedadAks30x40";
            SpParams[43, 1] = TedadAks30x40;

            SpParams[44, 0] = "@TedadAks20x30";
            SpParams[44, 1] = TedadAks20x30;

            SpParams[45, 0] = "@TedadJurnal30x40";
            SpParams[45, 1] = TedadJurnal30x40;

            SpParams[46, 0] = "@TedadJurnal30x50";
            SpParams[46, 1] = TedadJurnal30x50;

            SpParams[47, 0] = "@TedadJurnal30x60";
            SpParams[47, 1] = TedadJurnal30x60;

            SpParams[48, 0] = "@TedadJurnal40x60";
            SpParams[48, 1] = TedadJurnal40x60;

            SpParams[49, 0] = "@TedadJurnal40x80";
            SpParams[49, 1] = TedadJurnal40x80;


            SpParams[50, 0] = "@FolderPath";
            SpParams[50, 1] = FolderPath;

            SpParams[51, 0] = "@EntekhabAksKhaam";
            SpParams[51, 1] = EntekhabAksKhaam;

            SpParams[52, 0] = "@TahvilAks";
            SpParams[52, 1] = TahvilAks;

            SpParams[53, 0] = "@TaeedTarahi";
            SpParams[53, 1] = TaeedTarahi;

            SpParams[54, 0] = "@TahvilFilmKhaam";
            SpParams[54, 1] = TahvilFilmKhaam;

            int error = sql.IntExcuteSP(SpParams);

            if (error == 1)
            {
                string Message = "قرارداد با موفقیت ثبت شد";
                frmShowInfoSmall info = new frmShowInfoSmall(Message, 2, "");
                info.ShowDialog();
                GharardadControlEn(false);
                FillDataTable();
                SetControls();
                return;
            }
            else
            {
                string Message = "ثبت قرارداد با شکست مواجه شد";
                frmShowInfoSmall info = new frmShowInfoSmall(Message, 2, "خطا");
                info.ShowDialog();
                GharardadControlEn(false);
                FillDataTable();
                SetControls();
                return;
            }
        }

        private void SetControls()
        {
            if (bindingSource1.Count != 0)
            {
                bindGharadad.BindingSource.MoveLast();                
                addNewToolStripButton.Enabled = true;
                deleteToolStripButton.Enabled = true;
                saveToolStripButton.Enabled = false;
                openToolStripButton.Enabled = true;
                printToolStripButton.Enabled = true;
                grbMoshkhasatMali.Enabled = true;
                FillPardakhtTable();                             
            }
            if (bindingSource1.Count == 0)
            {
                addNewToolStripButton.Enabled = true;
                deleteToolStripButton.Enabled = false;
                saveToolStripButton.Enabled = false;
                openToolStripButton.Enabled = false;
                printToolStripButton.Enabled = false;
                grbMoshkhasatMali.Enabled = false;                
            }

        }

        private void txbMablaghKol_Leave(object sender, EventArgs e)
        {
            CalculateMandeh();
        }

        private void txbTakhfif_Leave(object sender, EventArgs e)
        {
            CalculateMandeh();
        }

        private void CalculateMandeh()
        {
            txbKolPardakhti.Text = (KolePardakhti).ToString();
            int mablaghKol = Int32.Parse(txbMablaghKol.Text, System.Globalization.NumberStyles.AllowThousands);
            int takhfif = Int32.Parse(txbTakhfif.Text, System.Globalization.NumberStyles.AllowThousands);
            int pardakhti = Int32.Parse(txbKolPardakhti.Text, System.Globalization.NumberStyles.AllowThousands);

            txbMandeh.Text = (mablaghKol - (takhfif + pardakhti)).ToString();
            txbMandeh2.Text = txbMandeh.Text;
            txbMablaghKol2.Text = txbMablaghKol.Text;
            txbTakhfif2.Text = txbTakhfif.Text;
            txbKolPardakhti2.Text = txbKolPardakhti.Text;
        }

        private void txbKolMabkaghAks_Leave(object sender, EventArgs e)
        {
            int mablaghAks = Int32.Parse(txbKolMabkaghAks.Text, System.Globalization.NumberStyles.AllowThousands);
            int mablaghFilm = Int32.Parse(txbKolMablaghFilm.Text, System.Globalization.NumberStyles.AllowThousands);
            txbMablaghKol.Text = (mablaghAks + mablaghFilm).ToString();
            CalculateMandeh();
        }

        private void txbKolMablaghFilm_Leave(object sender, EventArgs e)
        {
            int mablaghAks = Int32.Parse(txbKolMabkaghAks.Text, System.Globalization.NumberStyles.AllowThousands);
            int mablaghFilm = Int32.Parse(txbKolMablaghFilm.Text, System.Globalization.NumberStyles.AllowThousands);
            txbMablaghKol.Text = (mablaghAks + mablaghFilm).ToString();
            CalculateMandeh();
        }

        private void pageMainGharardad_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageMainGharardad.SelectedPage == pagePardakht)
            {
                txbMablaghKol2.Text = txbMablaghKol.Text;
                txbTakhfif2.Text = txbTakhfif.Text;
                txbMandeh2.Text = txbMandeh.Text;
                txbKolPardakhti2.Text = txbKolPardakhti.Text;
                cmbNoePardakht.SelectedIndex = 0;
            }
        }

        private void txbShomareGharardad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bindingNavigatorCountItem_TextChanged(object sender, EventArgs e)
        {
            int count = bindingSource1.Count;
            bindingNavigatorCountItem.Text = "از" + " " + string.Format("{0}", count);
        }

        private void bindingNavigatorPositionItem_TextChanged(object sender, EventArgs e)
        {
            int count = bindingSource1.Count;
            bindingNavigatorCountItem.Text = "از" + " " + string.Format("{0}", count);
        }

        private void CheckBoxesSet()
        {
            DataRowView current = (DataRowView)bindingSource1.Current;

            if (current != null)
            {
                string TarikhGharardad = current["TarikhGharardad"].ToString();
                txbTarikhGharardad.GeoDate = Convert.ToDateTime(TarikhGharardad);

                string TarikhMarasem = current["TarikhMarasem"].ToString();
                txbTarikhMarasem.GeoDate = Convert.ToDateTime(TarikhMarasem);


                string EntekhabAks = current["EntekhabAks"].ToString();
                if (EntekhabAks == "1")
                    rdbAksShod.CheckState = CheckState.Checked;
                else
                    rdbAksNashod.CheckState = CheckState.Checked;

                string TaeedAks = current["TaeedAks"].ToString();
                if (TaeedAks == "1")
                    chbTaeedAks.Checked = true;
                else
                    chbTaeedAks.Checked = false;

                string Demo = current["Demo"].ToString();
                if (Demo == "1")
                    chbDemo.Checked = true;
                else
                    chbDemo.Checked = false;

                string Orginal = current["Orginal"].ToString();
                if (Orginal == "1")
                    chbOriginal.Checked = true;
                else
                    chbOriginal.Checked = false;

                string ChapAks = current["ChapAks"].ToString();
                if (ChapAks == "1")
                    chbChapAks.Checked = true;
                else
                    chbChapAks.Checked = false;

                string Aks16x21 = current["Aks16x21"].ToString();
                if (Aks16x21 == "1")
                    chbAks16x21.Checked = true;
                else
                    chbAks16x21.Checked = false;

                string Aks20x25 = current["Aks20x25"].ToString();
                if (Aks20x25 == "1")
                    chbAks20x25.Checked = true;
                else
                    chbAks20x25.Checked = false;

                string Aks20x30 = current["Aks20x30"].ToString();
                if (Aks20x30 == "1")
                    chbAks20x30.Checked = true;
                else
                    chbAks20x30.Checked = false;

                string Aks30x40 = current["Aks30x40"].ToString();
                if (Aks30x40 == "1")
                    chbAks30x40.Checked = true;
                else
                    chbAks30x40.Checked = false;

                string Zhoornal30x40 = current["Zhoornal30x40"].ToString();
                if (Zhoornal30x40 == "1")
                    chbZhoornal30x40.Checked = true;
                else
                    chbZhoornal30x40.Checked = false;

                string Zhoornal30x50 = current["Zhoornal30x50"].ToString();
                if (Zhoornal30x50 == "1")
                    chbZhoornal30x50.Checked = true;
                else
                    chbZhoornal30x50.Checked = false;

                string Zhoornal30x60 = current["Zhoornal30x60"].ToString();
                if (Zhoornal30x60 == "1")
                    chbZhoornal30x60.Checked = true;
                else
                    chbZhoornal30x60.Checked = false;


                string Zhoornal40x60 = current["Zhoornal40x60"].ToString();
                if (Zhoornal40x60 == "1")
                    chbZhoornal40x60.Checked = true;
                else
                    chbZhoornal40x60.Checked = false;

                string Zhoornal40x80 = current["Zhoornal40x80"].ToString();
                if (Zhoornal40x80 == "1")
                    chbZhoornal40x80.Checked = true;
                else
                    chbZhoornal40x80.Checked = false;

                string Noorpardazi = current["Noorpardazi"].ToString();
                if (Noorpardazi == "1")
                    chbNoorpardazi.Checked = true;
                else
                    chbNoorpardazi.Checked = false;

                string Camera2 = current["Camera2"].ToString();
                if (Camera2 == "1")
                    chbCamear2.Checked = true;
                else
                    chbCamear2.Checked = false;

                string Camera3 = current["Camera3"].ToString();
                if (Camera3 == "1")
                    chbCamera3.Checked = true;
                else
                    chbCamera3.Checked = false;

                string ClipSport = current["ClipSport"].ToString();
                if (ClipSport == "1")
                    chbClipSport.Checked = true;
                else
                    chbClipSport.Checked = false;

                string Kreen = current["Kreen"].ToString();
                if (Kreen == "1")
                    chbKreen.Checked = true;
                else
                    chbKreen.Checked = false;

                string TahvilAks = current["TahvilAks"].ToString();
                if (TahvilAks == "1")
                    chbTahvilAks.Checked = true;
                else
                    chbTahvilAks.Checked = false;

                string EntekhabAksKhaam = current["EntekhabAksKhaam"].ToString();
                if (EntekhabAksKhaam == "1")
                    chbEntekhaabAksKhaam.Checked = true;
                else
                    chbEntekhaabAksKhaam.Checked = false;


                string TaeedTarahi = current["TaeedTarahi"].ToString();
                if (TaeedTarahi == "1")
                    chbTaeedTarahi.Checked = true;
                else
                    chbTaeedTarahi.Checked = false;


                string TahvilFilmKhaam = current["TahvilFilmKhaam"].ToString();
                if (TahvilFilmKhaam == "1")
                    chbTahvilFilmKhaam.Checked = true;
                else
                    chbTahvilFilmKhaam.Checked = false;
            }
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            _position = bindGharadad.BindingSource.Position;
            CheckBoxesSet();
            FillPardakhtTable();
            CalculateMandeh();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            _position = bindGharadad.BindingSource.Position;
            CheckBoxesSet();
            FillPardakhtTable();
            CalculateMandeh();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            _position = bindGharadad.BindingSource.Position;
            CheckBoxesSet();            
            FillPardakhtTable();
            CalculateMandeh();
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            _position = bindGharadad.BindingSource.Position;
            CheckBoxesSet();
            FillPardakhtTable();
            CalculateMandeh();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            GharardadControlEn(true);
            addNewToolStripButton.Enabled = false;
            openToolStripButton.Enabled = false;
            GharardadControlReadOnly(false);            
            EditRecord = true;
            CurrentShomareGharardad = txbShomareGharardad.Text.Trim();
        }

        private void txbShomareGharardadSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13)
            {
                _position = bindingSource1.Find("GharardadNumber", txbShomareGharardadSearch.Text.Trim());
                if(_position == -1)
                {
                    string message = "قراردادی با این شماره وجود ندارد";
                    frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 2, "خطا");
                    showinfo.ShowDialog();
                    return;
                }
                else
                {
                    bindGharadad.BindingSource.Position = _position;
                    CheckBoxesSet();
                    CalculateMandeh();
                    FillPardakhtTable();
                }
                
            }
        }

        private void frmGharardad_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cmbNoePardakht_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if(cmbNoePardakht.SelectedIndex == 2)
            {
                grbCheck.Enabled = true;
                txbCodeRahgiri.Enabled = false;
            }
            if(cmbNoePardakht.SelectedIndex == 1)
            {
                grbCheck.Enabled = false;
                txbCodeRahgiri.Enabled = true;
            }
            if(cmbNoePardakht.SelectedIndex == 0)
            {
                grbCheck.Enabled = false;
                txbCodeRahgiri.Enabled = false;
            }
        }

        private void txbMablagh_TextChanged(object sender, EventArgs e)
        {
            if (txbMablagh.Text == "")
                btnSavePardakht.Enabled = false;
            else
                btnSavePardakht.Enabled = true;
        }

        private void btnSavePardakht_Click(object sender, EventArgs e)
        {
            if(NewRecord || EditRecord)
            {
                string message2 = "لطفا قبل از ثبت پرداخت، قرارداد جاری را ذخیره نمایید";
                frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 2, "خطا");
                showinfo2.ShowDialog();
                return;
            }
            string GharardadId = txbId.Text.Trim();
            DateTime tp = txbTarikhPardakht.GeoDate.Value;
            string TarikhPardakht = tp.ToString("yyyy/MM/dd");
            string Mablagh = txbMablagh.Text.Trim();
            string Vosul = "0";
            string Deleted = "0";
            string NoePardakht = cmbNoePardakht.SelectedIndex.ToString();
            
            string ShomareCheck = "";
            string SarresidCheck = "";
            string BankName = "";
            string BankShobe = "";
            string SahebeCheck = "";
            string CodePeygiri = "";

            if (NoePardakht == "1")
                CodePeygiri = txbCodeRahgiri.Text.Trim();
            if(NoePardakht == "2")
            {
                ShomareCheck = txbShomareCheck.Text.Trim();
                SarresidCheck = txbSarresid.GeoDate.ToString();
                BankName = txbBank.Text.Trim();
                SahebeCheck = txbSahebeHesab.Text.Trim();
            }

            SQLAccess sql = new SQLAccess();
            string[,] SpParams = new string[12,2];
            sql.StoredProcedureName = "prcInsertPardakht";
            SpParams[0, 0] = "@GharardadId";
            SpParams[0, 1] = GharardadId;
            SpParams[1, 0] = "@TarikhPardakht";
            SpParams[1, 1] = TarikhPardakht;
            SpParams[2, 0] = "@Mablagh";
            SpParams[2, 1] = Mablagh;
            SpParams[3, 0] = "@NoePardakht";
            SpParams[3, 1] = NoePardakht;
            SpParams[4, 0] = "@ShomareCheck";
            SpParams[4, 1] = ShomareCheck;
            SpParams[5, 0] = "@SarresidCheck";
            SpParams[5, 1] = SarresidCheck;
            SpParams[6, 0] = "@BankName";
            SpParams[6, 1] = BankName;
            SpParams[7, 0] = "@BankShobe";
            SpParams[7, 1] = BankShobe;
            SpParams[8, 0] = "@SahebeCheck";
            SpParams[8, 1] = SahebeCheck;
            SpParams[9, 0] = "@Vosul";
            SpParams[9, 1] = Vosul;
            SpParams[10, 0] = "@CodePeygiri";
            SpParams[10, 1] = CodePeygiri;
            SpParams[11, 0] = "@Deleted";
            SpParams[11, 1] = Deleted;

            int error = sql.IntExcuteSP(SpParams);
            if(error == 1)
            {
                DataTable dt = new DataTable();
                SQLAccess sql1 = new SQLAccess();
                sql1.StoredProcedureName = "prcGetPardakhtByGharardadId";
                string[,] SpParams1 = new string[1, 2];
                SpParams1[0, 0] = "@GharardadId";
                SpParams1[0, 1] = GharardadId;
                dt = sql1.ExcecuteQueryToDataTable(SpParams1);
                if (dt.Rows.Count > 0)
                {
                    dgvPardakhtha.Rows.Clear();
                    KolePardakhti = 0;
                    LogicLayer lg3 = new LogicLayer();
                    dgvPardakhtha.BeginUpdate();
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        string Id = dt.Rows[i]["Id"].ToString();
                        string radif = (i + 1).ToString();
                        string tarikh = lg3.ShamsiDate(dt.Rows[i]["TarikhPardakht"].ToString());
                        string mablagh = dt.Rows[i]["Mablagh"].ToString();
                        int pardakhti = Int32.Parse(mablagh, System.Globalization.NumberStyles.AllowThousands);
                        KolePardakhti = KolePardakhti + pardakhti;
                        string nahve = dt.Rows[i]["NoePardakht"].ToString();
                        string noepardakht = "";
                        string shomarecheck = "";
                        string tarikhsarresid = "";
                        string bank = "";
                        string saaheb = "";
                        string codepeygiri = "";

                        if (nahve == "0")
                            noepardakht = "نقد";
                        if (nahve == "1")
                        {
                            noepardakht = "کارت بانکی";
                            codepeygiri = dt.Rows[i]["CodePeygiri"].ToString();
                        }                            
                        if (nahve == "2")
                        {
                            noepardakht = "چک";
                            shomarecheck = dt.Rows[i]["ShomareCheck"].ToString();
                            tarikhsarresid = lg3.ShamsiDate(dt.Rows[i]["SarresidCheck"].ToString());
                            bank = dt.Rows[i]["BankName"].ToString();
                            saaheb = dt.Rows[i]["SahebeCheck"].ToString();
                        }
                        dgvPardakhtha.Rows.Add(radif, tarikh, mablagh, noepardakht, shomarecheck, tarikhsarresid, bank, saaheb,Id);
                    }
                    dgvPardakhtha.EndUpdate();
                    dgvPardakhtha.Refresh();
                    CalculateMandeh();
                    txbTarikhPardakht.GeoDate = DateTime.Now;
                    cmbNoePardakht.SelectedIndex = 0;
                    txbMablagh.Text = "";
                    txbCodeRahgiri.Text = "";
                    txbShomareCheck.Text = "";
                    txbSarresid.GeoDate = DateTime.Now;
                    txbBank.Text = "";
                    txbSahebeHesab.Text = "";
                }
            }
        }

        private void FillPardakhtTable()
        {
            dgvPardakhtha.Rows.Clear();
            KolePardakhti = 0;
            txbKolPardakhti.Text = "";
            string GharardadId = txbId.Text;
            DataTable dt = new DataTable();
            SQLAccess sql1 = new SQLAccess();
            sql1.StoredProcedureName = "prcGetPardakhtByGharardadId";
            string[,] SpParams1 = new string[1, 2];
            SpParams1[0, 0] = "@GharardadId";
            SpParams1[0, 1] = GharardadId;
            dt = sql1.ExcecuteQueryToDataTable(SpParams1);
            if (dt.Rows.Count > 0)
            {              
                LogicLayer lg3 = new LogicLayer();
                dgvPardakhtha.BeginUpdate();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string Id = dt.Rows[i]["Id"].ToString();
                    string radif = (i + 1).ToString();
                    string tarikh = lg3.ShamsiDate(dt.Rows[i]["TarikhPardakht"].ToString());
                    string mablagh = dt.Rows[i]["Mablagh"].ToString();
                    int pardakhti = Int32.Parse(mablagh, System.Globalization.NumberStyles.AllowThousands);
                    KolePardakhti = KolePardakhti + pardakhti;
                    string nahve = dt.Rows[i]["NoePardakht"].ToString();
                    string noepardakht = "";
                    string shomarecheck = "";
                    string tarikhsarresid = "";
                    string bank = "";
                    string saaheb = "";
                    string codepeygiri = "";

                    if (nahve == "0")
                        noepardakht = "نقد";
                    if (nahve == "1")
                    {
                        noepardakht = "کارت بانکی";
                        codepeygiri = dt.Rows[i]["CodePeygiri"].ToString();
                    }
                    if (nahve == "2")
                    {
                        noepardakht = "چک";
                        shomarecheck = dt.Rows[i]["ShomareCheck"].ToString();
                        tarikhsarresid = lg3.ShamsiDate(dt.Rows[i]["SarresidCheck"].ToString());
                        bank = dt.Rows[i]["BankName"].ToString();
                        saaheb = dt.Rows[i]["SahebeCheck"].ToString();
                    }
                    dgvPardakhtha.Rows.Add(radif, tarikh, mablagh, noepardakht, shomarecheck, tarikhsarresid, bank, saaheb,Id);
                }
                dgvPardakhtha.EndUpdate();
                dgvPardakhtha.Refresh();
                CalculateMandeh();
            }
        }

        private void frmGharardad_Paint(object sender, PaintEventArgs e)
        {
            this.dgvPardakhtha.GridViewElement.GroupPanelElement.Text = "برای گروه بندی یک ستون را به اینجا بکشید و رها کنید";
        }

        private void dgvPardakhtha_Paint(object sender, PaintEventArgs e)
        {
            this.dgvPardakhtha.GridViewElement.GroupPanelElement.Text = "برای گروه بندی یک ستون را به اینجا بکشید و رها کنید";
        }

        private void dgvPardakhtha_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {            
            int SelectedRowIndex = e.RowIndex;
            string Id = dgvPardakhtha.Rows[SelectedRowIndex].Cells["Id"].Value.ToString();
            PardakhtId = Id;
            DataTable dt3 = new DataTable();
            LogicLayer lg = new LogicLayer();
            dt3 = lg.GetPardakhtInfo(Id);
            if (dt3.Rows.Count > 0)
            {
                txbTarikhPardakht.GeoDate = Convert.ToDateTime(dt3.Rows[0]["TarikhPardakht"].ToString());
                txbMablagh.Text = dt3.Rows[0]["Mablagh"].ToString();
                string nahve = dt3.Rows[0]["NoePardakht"].ToString();
                if (nahve == "0")
                {
                    cmbNoePardakht.SelectedIndex = 0;
                    txbCodeRahgiri.Text = "";
                    txbShomareCheck.Text = "";
                    txbSarresid.GeoDate = DateTime.Now;
                    txbBank.Text = "";
                    txbSahebeHesab.Text = "";
                }
                if (nahve == "1")
                {
                    cmbNoePardakht.SelectedIndex = 1;
                    txbCodeRahgiri.Text = dt3.Rows[0]["CodePeygiri"].ToString();
                    txbShomareCheck.Text = "";
                    txbSarresid.GeoDate = DateTime.Now;
                    txbBank.Text = "";
                    txbSahebeHesab.Text = "";
                }
                if (nahve == "2")
                {
                    cmbNoePardakht.SelectedIndex = 2;
                    txbShomareCheck.Text = dt3.Rows[0]["ShomareCheck"].ToString();
                    txbSarresid.GeoDate = Convert.ToDateTime(dt3.Rows[0]["SarresidCheck"].ToString());
                    txbBank.Text = dt3.Rows[0]["BankName"].ToString();
                    txbSahebeHesab.Text = dt3.Rows[0]["SahebeCheck"].ToString();
                    txbCodeRahgiri.Text = "";
                }
                btnEditPardakht.Enabled = true;
                btnDeletePardakht.Enabled = true;
            }
        }

        private void btnEditPardakht_Click(object sender, EventArgs e)
        {
            if (NewRecord || EditRecord)
            {
                string message2 = "لطفا قبل از ثبت پرداخت، قرارداد جاری را ذخیره نمایید";
                frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 2, "خطا");
                showinfo2.ShowDialog();
                return;
            }
            DateTime tp = txbTarikhPardakht.GeoDate.Value;
            string TarikhPardakht = tp.ToString("yyyy/MM/dd");            
            string Mablagh = txbMablagh.Text.Trim();
            string Vosul = "0";            
            string NoePardakht = cmbNoePardakht.SelectedIndex.ToString();

            string ShomareCheck = "";
            string SarresidCheck = "";
            string BankName = "";
            string BankShobe = "";
            string SahebeCheck = "";
            string CodePeygiri = "";

            if (NoePardakht == "1")
                CodePeygiri = txbCodeRahgiri.Text.Trim();
            if (NoePardakht == "2")
            {
                ShomareCheck = txbShomareCheck.Text.Trim();
                SarresidCheck = txbSarresid.GeoDate.ToString();
                BankName = txbBank.Text.Trim();
                SahebeCheck = txbSahebeHesab.Text.Trim();
            }

            SQLAccess sql = new SQLAccess();
            string[,] SpParams = new string[11, 2];
            sql.StoredProcedureName = "prcUpdatePardakht";
            SpParams[0, 0] = "@Id";
            SpParams[0, 1] = PardakhtId;
            SpParams[1, 0] = "@TarikhPardakht";
            SpParams[1, 1] = TarikhPardakht;
            SpParams[2, 0] = "@Mablagh";
            SpParams[2, 1] = Mablagh;
            SpParams[3, 0] = "@NoePardakht";
            SpParams[3, 1] = NoePardakht;
            SpParams[4, 0] = "@ShomareCheck";
            SpParams[4, 1] = ShomareCheck;
            SpParams[5, 0] = "@SarresidCheck";
            SpParams[5, 1] = SarresidCheck;
            SpParams[6, 0] = "@BankName";
            SpParams[6, 1] = BankName;
            SpParams[7, 0] = "@BankShobe";
            SpParams[7, 1] = BankShobe;
            SpParams[8, 0] = "@SahebeCheck";
            SpParams[8, 1] = SahebeCheck;
            SpParams[9, 0] = "@Vosul";
            SpParams[9, 1] = Vosul;
            SpParams[10, 0] = "@CodePeygiri";
            SpParams[10, 1] = CodePeygiri;           

            int error = sql.IntExcuteSP(SpParams);
            if (error == 1)
            {
                DataTable dt = new DataTable();
                SQLAccess sql1 = new SQLAccess();
                sql1.StoredProcedureName = "prcGetPardakhtByGharardadId";
                string[,] SpParams1 = new string[1, 2];
                SpParams1[0, 0] = "@GharardadId";
                SpParams1[0, 1] = txbId.Text.Trim();
                dt = sql1.ExcecuteQueryToDataTable(SpParams1);
                if (dt.Rows.Count > 0)
                {
                    dgvPardakhtha.Rows.Clear();
                    KolePardakhti = 0;
                    LogicLayer lg3 = new LogicLayer();
                    dgvPardakhtha.BeginUpdate();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string Id = dt.Rows[i]["Id"].ToString();
                        string radif = (i + 1).ToString();
                        string tarikh = lg3.ShamsiDate(dt.Rows[i]["TarikhPardakht"].ToString());
                        string mablagh = dt.Rows[i]["Mablagh"].ToString();
                        int pardakhti = Int32.Parse(mablagh, System.Globalization.NumberStyles.AllowThousands);
                        KolePardakhti = KolePardakhti + pardakhti;
                        string nahve = dt.Rows[i]["NoePardakht"].ToString();
                        string noepardakht = "";
                        string shomarecheck = "";
                        string tarikhsarresid = "";
                        string bank = "";
                        string saaheb = "";
                        string codepeygiri = "";

                        if (nahve == "0")
                            noepardakht = "نقد";
                        if (nahve == "1")
                        {
                            noepardakht = "کارت بانکی";
                            codepeygiri = dt.Rows[i]["CodePeygiri"].ToString();
                        }
                        if (nahve == "2")
                        {
                            noepardakht = "چک";
                            shomarecheck = dt.Rows[i]["ShomareCheck"].ToString();
                            tarikhsarresid = lg3.ShamsiDate(dt.Rows[i]["SarresidCheck"].ToString());
                            bank = dt.Rows[i]["BankName"].ToString();
                            saaheb = dt.Rows[i]["SahebeCheck"].ToString();
                        }
                        dgvPardakhtha.Rows.Add(radif, tarikh, mablagh, noepardakht, shomarecheck, tarikhsarresid, bank, saaheb, Id);
                    }
                    dgvPardakhtha.EndUpdate();
                    dgvPardakhtha.Refresh();
                    CalculateMandeh();
                    txbTarikhPardakht.GeoDate = DateTime.Now;
                    cmbNoePardakht.SelectedIndex = 0;
                    txbMablagh.Text = "";
                    txbCodeRahgiri.Text = "";
                    txbShomareCheck.Text = "";
                    txbSarresid.GeoDate = DateTime.Now;
                    txbBank.Text = "";
                    txbSahebeHesab.Text = "";
                }
            }
        }

        private void btnDeletePardakht_Click(object sender, EventArgs e)
        {
            if (NewRecord || EditRecord)
            {
                string message2 = "لطفا قبل از حذف پرداخت، قرارداد جاری را ذخیره نمایید";
                frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 2, "خطا");
                showinfo2.ShowDialog();
                return;
            }
            string message = "آیا برای حذف پرداخت مطمئن هستید؟";
            frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 3, "هشدار");
            DialogResult dr = showinfo.ShowDialog();
            if (dr == DialogResult.Yes)
            {

                SQLAccess sql = new SQLAccess();
                string[,] SpParams = new string[1, 2];
                sql.StoredProcedureName = "prcDeletePardakht";
                SpParams[0, 0] = "@Id";
                SpParams[0, 1] = PardakhtId;

                int error = sql.IntExcuteSP(SpParams);
                if (error == 1)
                {
                    DataTable dt = new DataTable();
                    SQLAccess sql1 = new SQLAccess();
                    sql1.StoredProcedureName = "prcGetPardakhtByGharardadId";
                    string[,] SpParams1 = new string[1, 2];
                    SpParams1[0, 0] = "@GharardadId";
                    SpParams1[0, 1] = txbId.Text.Trim();
                    dt = sql1.ExcecuteQueryToDataTable(SpParams1);

                    dgvPardakhtha.Rows.Clear();
                    KolePardakhti = 0;
                    LogicLayer lg3 = new LogicLayer();
                    dgvPardakhtha.BeginUpdate();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string Id = dt.Rows[i]["Id"].ToString();
                        string radif = (i + 1).ToString();
                        string tarikh = lg3.ShamsiDate(dt.Rows[i]["TarikhPardakht"].ToString());
                        string mablagh = dt.Rows[i]["Mablagh"].ToString();
                        int pardakhti = Int32.Parse(mablagh, System.Globalization.NumberStyles.AllowThousands);
                        KolePardakhti = KolePardakhti + pardakhti;
                        string nahve = dt.Rows[i]["NoePardakht"].ToString();
                        string noepardakht = "";
                        string shomarecheck = "";
                        string tarikhsarresid = "";
                        string bank = "";
                        string saaheb = "";
                        string codepeygiri = "";

                        if (nahve == "0")
                            noepardakht = "نقد";
                        if (nahve == "1")
                        {
                            noepardakht = "کارت بانکی";
                            codepeygiri = dt.Rows[i]["CodePeygiri"].ToString();
                        }
                        if (nahve == "2")
                        {
                            noepardakht = "چک";
                            shomarecheck = dt.Rows[i]["ShomareCheck"].ToString();
                            tarikhsarresid = lg3.ShamsiDate(dt.Rows[i]["SarresidCheck"].ToString());
                            bank = dt.Rows[i]["BankName"].ToString();
                            saaheb = dt.Rows[i]["SahebeCheck"].ToString();
                        }
                        dgvPardakhtha.Rows.Add(radif, tarikh, mablagh, noepardakht, shomarecheck, tarikhsarresid, bank, saaheb, Id);
                    }
                    dgvPardakhtha.EndUpdate();
                    dgvPardakhtha.Refresh();

                    CalculateMandeh();
                    txbTarikhPardakht.GeoDate = DateTime.Now;
                    cmbNoePardakht.SelectedIndex = 0;
                    txbMablagh.Text = "";
                    txbCodeRahgiri.Text = "";
                    txbShomareCheck.Text = "";
                    txbSarresid.GeoDate = DateTime.Now;
                    txbBank.Text = "";
                    txbSahebeHesab.Text = "";

                }
            }
        }

        private void chbAks16x21_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chbAks16x21.CheckState == CheckState.Checked)
                txbTedadAks16x21.ReadOnly = false;
            else
                txbTedadAks16x21.ReadOnly = true;
        }

        private void chbAks20x25_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chbAks20x25.CheckState == CheckState.Checked)
                txbTedadAks20x25.ReadOnly = false;
            else
                txbTedadAks20x25.ReadOnly = true;
        }

        private void chbAks20x30_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chbAks20x30.CheckState == CheckState.Checked)
                txbTedadAks20x30.ReadOnly = false;
            else
                txbTedadAks20x30.ReadOnly = true;
        }

        private void chbAks30x40_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chbAks30x40.CheckState == CheckState.Checked)
                txbTedadAks30x40.ReadOnly = false;
            else
                txbTedadAks30x40.ReadOnly = true;
        }

        private void chbZhoornal30x40_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chbZhoornal30x40.CheckState == CheckState.Checked)
                txbTedadJurnal30x40.ReadOnly = false;
            else
                txbTedadJurnal30x40.ReadOnly = true;
        }

        private void chbZhoornal30x50_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chbZhoornal30x50.CheckState == CheckState.Checked)
                txbTedadJurnal30x50.ReadOnly = false;
            else
                txbTedadJurnal30x50.ReadOnly = true;
        }

        private void chbZhoornal30x60_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chbZhoornal30x60.CheckState == CheckState.Checked)
                txbTedadJurnal30x60.ReadOnly = false;
            else
                txbTedadJurnal30x60.ReadOnly = true;
        }

        private void chbZhoornal40x60_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chbZhoornal40x60.CheckState == CheckState.Checked)
                txbTedadJurnal40x60.ReadOnly = false;
            else
                txbTedadJurnal40x60.ReadOnly = true;
        }

        private void chbZhoornal40x80_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chbZhoornal40x80.CheckState == CheckState.Checked)
                txbTedadJurnal40x80.ReadOnly = false;
            else
                txbTedadJurnal40x80.ReadOnly = true;
        }

        private void btnControlTarikh_Click(object sender, EventArgs e)
        {
            DateTime datefrom = txbTarikhMarasem.GeoDate.Value;
            DateTime dateto = txbTarikhMarasem.GeoDate.Value;
           
            DataTable dt = new DataTable();
            SQLAccess sql = new SQLAccess();
            sql.StoredProcedureName = "prcGetGharardadListByMarasemDateFromTo";
            string[,] SpParams = new string[2, 2];
            SpParams[0, 0] = "@TarikhMarasemFrom";
            SpParams[0, 1] = datefrom.ToString("yyyy/MM/dd");
            SpParams[1, 0] = "@TarikhMarasemTo";
            SpParams[1, 1] = dateto.ToString("yyyy/MM/dd");
            dt = sql.ExcecuteQueryToDataTable(SpParams);
            if (dt.Rows.Count > 0)
            {
                frmReport report = new frmReport(0,dt, " گزارش قرارداد از تاریخ مراسم " + Persia.Calendar.ConvertToPersian(datefrom).Simple + " تا " + Persia.Calendar.ConvertToPersian(dateto).Simple);
                report.Show();
            }
            else
            {
                string message = "در تاریخ " + Persia.Calendar.ConvertToPersian(datefrom).Simple + " مراسمی ثبت نشده است";
                frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 2, "خطا");
                showinfo.ShowDialog();
                return;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {                
                txbPath.Text = fbd.SelectedPath;                
            }           
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(txbPath.Text);
            }
            catch (Exception)
            {
                string message2 = "مسیر انتحاب شده یافت نشد";
                frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 2, "خطا");
                showinfo2.ShowDialog();
                return;
            }
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            int _errorCode = 0;

            _errorCode = CheckReportFileExist("MaxGharardad.mrt");
            if (_errorCode == 0)
            {
                CreateReport();
            }
            else
            {
                string message2 = "فایل چاپ گزارش یافت نشد";
                frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 2, "خطا");
                showinfo2.ShowDialog();
                return;
            }
        }

        private int CheckReportFileExist(string FileName)
        {
            int _result = 0;
            string path = Application.StartupPath + "\\Reports\\" + FileName;

            if (!File.Exists(path))
            {
                _result = 1;
            }
            return _result;
        }

        private void CreateReport()
        {
            try
            {
                pageMainGharardad.SelectedPage = pageDamad;
                pageMainGharardad.SelectedPage = pageAks;
                pageMainGharardad.SelectedPage = pageFilm;
                pageMainGharardad.SelectedPage = pagePardakht;
                pageMainGharardad.SelectedPage = pageGharadad;
                StiReport stiReport1 = new StiReport();
                stiReport1.Load(Application.StartupPath + "\\Reports\\MaxGharardad.mrt");
                
                stiReport1.Compile();

                stiReport1["Date"] = Persia.Calendar.ConvertToPersian(txbTarikhGharardad.GeoDate.Value).Simple;
                stiReport1["DamadName"] = txbNameDamad.Text.Trim();
                stiReport1["DamadTamas"] = txbTamasDamad.Text.Trim();
                stiReport1["AroosName"] = txbNameAroos.Text.Trim();
                stiReport1["AroosTamas"] = txbTamasAroos.Text.Trim();
                stiReport1["TarikhMarasem"] = Persia.Calendar.ConvertToPersian(txbTarikhMarasem.GeoDate.Value).Simple;
                stiReport1["SaatMarasem"] = txbSaatMarasem.Text.Trim();
                stiReport1["Talar"] = txbTalar.Text.Trim();

                if(chbAks16x21.CheckState == CheckState.Checked)
                {
                    stiReport1["Aks16x21"] = "عکس 21 * 16";
                    stiReport1["TedadAks16x21"] = txbTedadAks16x21.Text.Trim();
                    stiReport1["VahedAks16x21"] = "عدد";
                }
                else
                {
                    stiReport1["Aks16x21"] = "";
                    stiReport1["TedadAks16x21"] = "";
                    stiReport1["VahedAks16x21"] = "";
                }

                if (chbAks20x25.CheckState == CheckState.Checked)
                {
                    stiReport1["Aks20x25"] = "عکس 25 * 20";
                    stiReport1["TedadAks20x25"] = txbTedadAks20x25.Text.Trim();
                    stiReport1["VahedAks20x25"] = "عدد";
                }
                else
                {
                    stiReport1["Aks20x25"] = "";
                    stiReport1["TedadAks20x25"] = "";
                    stiReport1["VahedAks20x25"] = "";
                }

                if (chbAks30x40.CheckState == CheckState.Checked)
                {
                    stiReport1["Aks30x40"] = "عکس 40 * 30";
                    stiReport1["TedadAks30x40"] = txbTedadAks30x40.Text.Trim();
                    stiReport1["VahedAks30x40"] = "عدد";
                }
                else
                {
                    stiReport1["Aks30x40"] = "";
                    stiReport1["TedadAks30x40"] = "";
                    stiReport1["VahedAks30x40"] = "";
                }

                if (chbAks20x30.CheckState == CheckState.Checked)
                {
                    stiReport1["Aks20x30"] = "عکس 30 * 20";
                    stiReport1["TedadAks20x30"] = txbTedadAks20x30.Text.Trim();
                    stiReport1["VahedAks20x30"] = "عدد";
                }
                else
                {
                    stiReport1["Aks20x30"] = "";
                    stiReport1["TedadAks20x30"] = "";
                    stiReport1["VahedAks20x30"] = "";
                }
                
                if(chbZhoornal30x40.CheckState == CheckState.Checked)
                {
                    stiReport1["Zhoornal30x40"] = "ژورنال 40 * 30";
                    stiReport1["TedadZhoornal30x40"] = txbTedadJurnal30x40.Text.Trim();
                    stiReport1["VahedZhoornal30x40"] = "برگ";
                }
                else
                {
                    stiReport1["Zhoornal30x40"] = "";
                    stiReport1["TedadZhoornal30x40"] = "";
                    stiReport1["VahedZhoornal30x40"] = "";
                }

                if (chbZhoornal30x50.CheckState == CheckState.Checked)
                {
                    stiReport1["Zhoornal30x50"] = "ژورنال 50 * 30";
                    stiReport1["TedadZhoornal30x50"] = txbTedadJurnal30x50.Text.Trim();
                    stiReport1["VahedZhoornal30x50"] = "برگ";
                }
                else
                {
                    stiReport1["Zhoornal30x50"] = "";
                    stiReport1["TedadZhoornal30x50"] = "";
                    stiReport1["VahedZhoornal30x50"] = "";
                }


                if (chbZhoornal30x60.CheckState == CheckState.Checked)
                {
                    stiReport1["Zhoornal30x60"] = "ژورنال 60 * 30";
                    stiReport1["TedadZhoornal30x60"] = txbTedadJurnal30x60.Text.Trim();
                    stiReport1["VahedZhoornal30x60"] = "برگ";
                }
                else
                {
                    stiReport1["Zhoornal30x60"] = "";
                    stiReport1["TedadZhoornal30x60"] = "";
                    stiReport1["VahedZhoornal30x60"] = "";
                }

                if (chbZhoornal40x60.CheckState == CheckState.Checked)
                {
                    stiReport1["Zhoornal40x60"] = "ژورنال 60 * 40";
                    stiReport1["TedadZhoornal40x60"] = txbTedadJurnal40x60.Text.Trim();
                    stiReport1["VahedZhoornal40x60"] = "برگ";
                }
                else
                {
                    stiReport1["Zhoornal40x60"] = "";
                    stiReport1["TedadZhoornal40x60"] = "";
                    stiReport1["VahedZhoornal40x60"] = "";
                }

                if (chbZhoornal40x80.CheckState == CheckState.Checked)
                {
                    stiReport1["Zhoornal40x80"] = "ژورنال 80 * 40";
                    stiReport1["TedadZhoornal40x80"] = txbTedadJurnal40x80.Text.Trim();
                    stiReport1["VahedZhoornal40x80"] = "برگ";
                }
                else
                {
                    stiReport1["Zhoornal40x80"] = "";
                    stiReport1["TedadZhoornal40x80"] = "";
                    stiReport1["VahedZhoornal40x80"] = "";
                }             


                stiReport1["MablaghKol"] = txbMablaghKol.Text.Trim() + " ریال ";
                stiReport1["Takhfif"] = txbTakhfif.Text.Trim() + " ریال "; ;
                stiReport1["MablaghKolAks"] = txbKolMabkaghAks.Text.Trim() + " ریال "; 
                stiReport1["MablaghKolFilm"] = txbKolMablaghFilm.Text.Trim() + " ریال "; 
                stiReport1["Pardakht"] = txbKolPardakhti.Text.Trim() + " ریال "; 
                stiReport1["Mandeh"] =  txbMandeh.Text.Trim() + " ریال "; 
                stiReport1["TozihatAks"] = txbTozihatAks.Text.Trim();
                stiReport1["Filmbardari"] = txbFilm.Text.Trim();

                if(chbNoorpardazi.CheckState == CheckState.Checked)
                    stiReport1["Noorpardazi"] = true;
                else
                    stiReport1["Noorpardazi"] = false;

                if (chbCamear2.CheckState == CheckState.Checked)
                    stiReport1["Camera2"] = true;
                else
                    stiReport1["Camera2"] = false;

                if (chbCamera3.CheckState == CheckState.Checked)
                    stiReport1["Camera3"] = true;
                else
                    stiReport1["Camera3"] = false;

                if (chbClipSport.CheckState == CheckState.Checked)
                    stiReport1["Sportclip"] = true;
                else
                    stiReport1["Sportclip"] = false;

                if (chbKreen.CheckState == CheckState.Checked)
                    stiReport1["Creen"] = true;
                else
                    stiReport1["Creen"] = false;
               

                stiReport1["SayerKhadamtFilm"] = txbSaierKhadematFilm.Text.Trim();
                stiReport1["TozihatGharardad"] = txbTozihat.Text.Trim();
                stiReport1["TozihatFilm"] = txbTozihatFilm.Text.Trim();
                stiReport1.Dictionary.Synchronize();

                stiReport1.Render();
                StiOptions.Viewer.AllowUseDragDrop = false;
                
                stiReport1.Show();
            }
            catch (Exception e)
            {
                string ms = e.Message;
                string message2 = "ساخت گزارش با مشکل مواجه گردید";
                frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 2, "خطا");
                showinfo2.ShowDialog();
                return;
            }
        }
    }
    
}
