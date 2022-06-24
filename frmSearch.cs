using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PhotoStudio
{
    public partial class frmSearch : Telerik.WinControls.UI.RadForm
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            txbDateFrom.GeoDate = DateTime.Now;
            txbDateTo.GeoDate = DateTime.Now;
            txbTarikhFrom.GeoDate = DateTime.Now;            
            txbTarikhMarasemFrom.GeoDate = DateTime.Now;
            txbTarikhMarasemTo.GeoDate = DateTime.Now;
            txbTarikhTo.GeoDate = DateTime.Now;
            cmbArossExt.SelectedIndex = 1;
            cmbDamadExt.SelectedIndex = 1;
            cmbShomareAroosExt.SelectedIndex = 1;
            cmbShomareDamadExt.SelectedIndex = 1;
        }

        private void btnSearchSimple_Click(object sender, EventArgs e)
        {
            if (rdbShomareGharardad.CheckState == CheckState.Checked)
                SearchGharardadShomare();
            if (rdbDateFrom.CheckState == CheckState.Checked)
                SearchGharardadFromDateToDate();
            if (rdbDamaadName.CheckState == CheckState.Checked)
                SearchGharardadDammadName();
            if (rdbAroosName.CheckState == CheckState.Checked)
                SearchGharardadAroosName();
            if (rdbTarikhMarasem.CheckState == CheckState.Checked)
                SearchMarasemFromDateToDate();
        }

        private void SearchGharardadShomare()
        {
            DataTable dt = new DataTable();
            SQLAccess sql = new SQLAccess();
            sql.StoredProcedureName = "prcGetGharardadByShomare";
            string[,] SpParams = new string[1, 2];
            SpParams[0, 0] = "@GharardadNumber";
            SpParams[0, 1] = txbShomareGharardad.Text.Trim();
            dt = sql.ExcecuteQueryToDataTable(SpParams);
            if(dt.Rows.Count > 0)
            {
                frmReport report = new frmReport(0,dt, "گزارش قرارداد شماره " + txbShomareGharardad.Text.Trim());
                report.Show();
            }
            else
            {
                string message = "قراردادی با این شماره وجود ندارد";
                frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 2, "خطا");
                showinfo.ShowDialog();
                return;
            }
        }

        private void SearchGharardadFromDateToDate()
        {
            DateTime datefrom = txbDateFrom.GeoDate.Value;
            DateTime dateto = txbDateTo.GeoDate.Value;
            

            DataTable dt = new DataTable();
            SQLAccess sql = new SQLAccess();
            sql.StoredProcedureName = "prcGetGharardadListByDateFromTo";
            string[,] SpParams = new string[2, 2];
            SpParams[0, 0] = "@TarikhGharardadFrom";
            SpParams[0, 1] = datefrom.ToString("yyyy/MM/dd");
            SpParams[1, 0] = "@TarikhGharardadTo";
            SpParams[1, 1] = dateto.ToString("yyyy/MM/dd");
            dt = sql.ExcecuteQueryToDataTable(SpParams);
            if (dt.Rows.Count > 0)
            {
                frmReport report = new frmReport(0,dt, "گزارش قرارداد از تاریخ " + Persia.Calendar.ConvertToPersian(datefrom).Simple + " تا " + Persia.Calendar.ConvertToPersian(dateto).Simple);
                report.Show();
            }
            else
            {
                string message = "قراردادی با این شرایط پیدا نشد";
                frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 2, "خطا");
                showinfo.ShowDialog();
                return;
            }
        }

        private void SearchMarasemFromDateToDate()
        {
            DateTime datefrom = txbTarikhMarasemFrom.GeoDate.Value;
            DateTime dateto = txbTarikhMarasemTo.GeoDate.Value;


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
                string message = "قراردادی با این شرایط پیدا نشد";
                frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 2, "خطا");
                showinfo.ShowDialog();
                return;
            }
        }

        private void SearchGharardadDammadName()
        {
            DataTable dt = new DataTable();
            SQLAccess sql = new SQLAccess();
            sql.StoredProcedureName = "prcGetGharardadByDamadName";
            string[,] SpParams = new string[1, 2];
            SpParams[0, 0] = "@DamadName";
            SpParams[0, 1] = txbNaameDamad.Text.Trim();
            dt = sql.ExcecuteQueryToDataTable(SpParams);
            if (dt.Rows.Count > 0)
            {
                frmReport report = new frmReport(0,dt, "گزارش قرارداد با نام داماد  " + txbNaameDamad.Text.Trim());
                report.Show();
            }
            else
            {
                string message = "قراردادی با این شرط وجود ندارد";
                frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 2, "خطا");
                showinfo.ShowDialog();
                return;
            }
        }

        private void SearchGharardadAroosName()
        {
            DataTable dt = new DataTable();
            SQLAccess sql = new SQLAccess();
            sql.StoredProcedureName = "prcGetGharardadByAroosName";
            string[,] SpParams = new string[1, 2];
            SpParams[0, 0] = "@AroosName";
            SpParams[0, 1] = txbNaameAroos.Text.Trim();
            dt = sql.ExcecuteQueryToDataTable(SpParams);
            if (dt.Rows.Count > 0)
            {
                frmReport report = new frmReport(0,dt, "گزارش قرارداد با نام عروس  " + txbNaameAroos.Text.Trim());
                report.Show();
            }
            else
            {
                string message = "قراردادی با این شرط وجود ندارد";
                frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 2, "خطا");
                showinfo.ShowDialog();
                return;
            }
        }

        private void rdbShomareGharardad_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdbShomareGharardad.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                txbShomareGharardad.Enabled = true;
            else
                txbShomareGharardad.Enabled = false;
        }

        private void rdbDateFrom_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdbDateFrom.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                txbDateFrom.Enabled = true;
                txbDateTo.Enabled = true;
            }                
            else
            {
                txbDateFrom.Enabled = false;
                txbDateTo.Enabled = false;
            }
        }

        private void rdbDamaadName_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdbDamaadName.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                txbNaameDamad.Enabled = true;
            else
                txbNaameDamad.Enabled = false;
        }

        private void rdbAroosName_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdbAroosName.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                txbNaameAroos.Enabled = true;
            else
                txbNaameAroos.Enabled = false;
        }

        private void txbShomareGharardad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rdbTarikhMarasem_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rdbTarikhMarasem.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                txbTarikhMarasemFrom.Enabled = true;
                txbTarikhMarasemTo.Enabled = true;
            }
            else
            {
                txbTarikhMarasemFrom.Enabled = false;
                txbTarikhMarasemTo.Enabled = false;
            }
        }

        private void btnCancelAdv_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnSearchAdv_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tblGharardad WHERE Deleted = '0'";
            query = SetFinalQuery(query);
            DataTable dt = new DataTable();
            SQLAccess sql = new SQLAccess();           
            dt = sql.ExcecuteSelectQueryToDataTable(query);
            if (dt.Rows.Count > 0)
            {
                frmReport report = new frmReport(1,dt, "گزارش قرارداد");
                report.Show();
            }
            else
            {
                string message = "قراردادی با این شرایط یافت نشد";
                frmShowInfoSmall showinfo = new frmShowInfoSmall(message, 2, "خطا");
                showinfo.ShowDialog();
                return;
            }

        }

        private string SetFinalQuery(string Query)
        {
            string query = Query;            
            if(chbGharardad2.CheckState == CheckState.Checked)            
                query = query + " AND (GharardadNumber BETWEEN '" + txbGharardadFrom.Text.Trim() + "' AND '" + txbGharardadTo.Text.Trim() + "')";
            if(chbTarikhGharardad2.CheckState == CheckState.Checked)
            {
                DateTime datefrom1 = txbTarikhFrom.GeoDate.Value;
                DateTime dateto1 = txbTarikhTo.GeoDate.Value;
                //datefrom.ToString("yyyy/MM/dd");
                //dateto.ToString("yyyy/MM/dd");
                query = query + " AND (TarikhGharardad BETWEEN '" + datefrom1.ToString("yyyy/MM/dd") + "' AND '" + dateto1.ToString("yyyy/MM/dd") + "')";
            }
            if(chbTarikhMarasem2.CheckState == CheckState.Checked)
            {
                DateTime datefrom2 = txbMarasemFrom.GeoDate.Value;
                DateTime dateto2 = txbMarasemTo.GeoDate.Value;
                //datefrom.ToString("yyyy/MM/dd");
                //dateto.ToString("yyyy/MM/dd");
                query = query + " AND (TarikhMarasem BETWEEN '" + datefrom2.ToString("yyyy/MM/dd") + "' AND '" + dateto2.ToString("yyyy/MM/dd") + "')";
            }
            if(txbDamadName.Text != "")
            {
                if (cmbDamadExt.SelectedIndex == 0)
                    query = query + " AND (DamadName LIKE N'" + txbDamadName.Text.Trim() + "%')";
                if (cmbDamadExt.SelectedIndex == 1)
                    query = query + " AND (DamadName LIKE N'%" + txbDamadName.Text.Trim() + "%')";
            }
            if (txbAroosName.Text != "")
            {
                if (cmbArossExt.SelectedIndex == 0)
                    query = query + " AND (AroosName LIKE N'" + txbAroosName.Text.Trim() + "%')";
                if (cmbArossExt.SelectedIndex == 1)
                    query = query + " AND (AroosName LIKE N'%" + txbAroosName.Text.Trim() + "%')";
            }
            if (chbTaeedAks.CheckState == CheckState.Checked)
                query = query + " AND (TaeedAks = '1')";

            if (chbChapAks.CheckState == CheckState.Checked)
                query = query + " AND (ChapAks = '1')";

            if (chbEntekhaabAksKhaam.CheckState == CheckState.Checked)
                query = query + " AND (EntekhabAksKhaam = '1')";

            if (chbTahvilAks.CheckState == CheckState.Checked)
                query = query + " AND (TahvilAks = '1')";

            if (chbTaeedTarahi.CheckState == CheckState.Checked)
                query = query + " AND (TaeedTarahi = '1')";

            if (chbTahvilFilmKhaam.CheckState == CheckState.Checked)
                query = query + " AND (TahvilFilmKhaam = '1')";

            if (chbDemo.CheckState == CheckState.Checked)
                query = query + " AND (Demo = '1')";

            if (chbOriginal.CheckState == CheckState.Checked)
                query = query + " AND (Orginal = '1')";

            if (rdbAksShod.CheckState == CheckState.Checked)
                query = query + " AND (EntekhabAks = '1')";

            if (rdbAksNashod.CheckState == CheckState.Checked)
                query = query + " AND (EntekhabAks = '0')";

            if (txbTarahName.Text != "")            
                query = query + " AND TarahName LIKE N'%" + txbTarahName.Text.Trim() + "%'";

            if (txbTadvingarName.Text != "")
                query = query + " AND (TadvingarName LIKE N'%" + txbTadvingarName.Text.Trim() + "%')";

            if(txbMablaghKolFrom.Text.Trim() != "0" || txbMablaghKolTo.Text.Trim() != "0")            
                query = query + " AND (MablaghGharardad BETWEEN '" + txbMablaghKolFrom.Text.Trim() + "' AND '" + txbMablaghKolTo.Text.Trim() + "')";

            if (txbMablaghKolAksFrom.Text.Trim() != "0" || txbMablaghKolAksTo.Text.Trim() != "0")
                query = query + " AND (KolMablaghAks BETWEEN '" + txbMablaghKolAksFrom.Text.Trim() + "' AND '" + txbMablaghKolAksTo.Text.Trim() + "')";

            if (txbMablaghKolFilm.Text.Trim() != "0" || txbMablaghKolFilmTo.Text.Trim() != "0")
                query = query + " AND (KolMablaghFilm BETWEEN '" + txbMablaghKolFilm.Text.Trim() + "' AND '" + txbMablaghKolFilmTo.Text.Trim() + "')";

            if (txbDamadShomare.Text != "")
            {
                if (cmbShomareDamadExt.SelectedIndex == 0)
                    query = query + " AND (ShomareTamasDamad LIKE N'" + txbDamadShomare.Text.Trim() + "%')";
                if (cmbShomareDamadExt.SelectedIndex == 1)
                    query = query + " AND (ShomareTamasDamad LIKE N'%" + txbDamadShomare.Text.Trim() + "%')";
            }

            if (txbAroosShomare.Text != "")
            {
                if (cmbShomareAroosExt.SelectedIndex == 0)
                    query = query + " AND (ShomareTamasAroos LIKE N'" + txbAroosShomare.Text.Trim() + "%')";
                if (cmbShomareAroosExt.SelectedIndex == 1)
                    query = query + " AND (ShomareTamasAroos LIKE N'%" + txbAroosShomare.Text.Trim() + "%')";
            }

            if (txbTalar.Text != "")
                query = query + " AND (TalarAddress LIKE N'%" + txbTalar.Text.Trim() + "%')";

            if (txbTozihat.Text != "")
                query = query + " AND (TozihatGharardad LIKE N'%" + txbTozihat.Text.Trim() + "%' OR TozihatMarasem LIKE N'%" + txbTozihat.Text.Trim() + "%' OR TozihatAks LIKE N'%" + txbTozihat.Text.Trim() + "%' OR TozihatFilm LIKE N'%" + txbTozihat.Text.Trim() + "%')";

            if (txbFilm.Text != "")
                query = query + " AND (Filmbardari LIKE N'%" + txbFilm.Text.Trim() + "%')";

            if (chbNoorpardazi.CheckState == CheckState.Checked)
                query = query + " AND (Noorpardazi = '1')";

            if (chbCamera2.CheckState == CheckState.Checked)
                query = query + " AND (Camera2 = '1')";

            if (chbCamera3.CheckState == CheckState.Checked)
                query = query + " AND (Camera3 = '1')";

            if (chbKreen.CheckState == CheckState.Checked)
                query = query + " AND (Kreen = '1')";

            if (chbClipSport.CheckState == CheckState.Checked)
                query = query + " AND (ClipSport = '1')";

            if (txbSaierKhadematFilm.Text != "")
                query = query + " AND (SaaierKhadamatFilm LIKE N'%" + txbSaierKhadematFilm.Text.Trim() + "%')";

            if (chbZhoornal30x40.CheckState == CheckState.Checked)
                query = query + " AND (Zhoornal30x40 = '1')";

            if (chbZhoornal30x50.CheckState == CheckState.Checked)
                query = query + " AND (Zhoornal30x50 = '1')";

            if (chbZhoornal30x60.CheckState == CheckState.Checked)
                query = query + " AND (Zhoornal30x60 = '1')";

            if (chbZhoornal40x60.CheckState == CheckState.Checked)
                query = query + " AND (Zhoornal40x60 = '1')";

            if (chbZhoornal40x80.CheckState == CheckState.Checked)
                query = query + " AND (Zhoornal40x80 = '1')";

            if (chbAks16x21.CheckState == CheckState.Checked)
                query = query + " AND (Aks16x21 = '1')";

            if (chbAks20x25.CheckState == CheckState.Checked)
                query = query + " AND (Aks20x25 = '1')";

            if (chbAks20x30.CheckState == CheckState.Checked)
                query = query + " AND (Aks20x30 = '1')";

            if (chbAks30x40.CheckState == CheckState.Checked)
                query = query + " AND (Aks30x40 = '1')";

            return query;
                
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txbAroosName.Text = "";
            txbAroosShomare.Text = "";
            txbDamadName.Text = "";
            txbDamadShomare.Text = "";
            txbDateFrom.GeoDate = DateTime.Now;
            txbDateTo.GeoDate = DateTime.Now;
            txbFilm.Text = "";
            txbGharardadFrom.Text = "";
            txbGharardadTo.Text = "";
            txbMablaghKolAksFrom.Text = "";
            txbMablaghKolAksTo.Text = "";
            txbMablaghKolFilm.Text = "";
            txbMablaghKolFilmTo.Text = "";
            txbMablaghKolFrom.Text = "";
            txbMablaghKolTo.Text = "";
         //   txbMandehFrom.Text = "";
         //   txbMandehTo.Text = "";
            txbMarasemFrom.GeoDate = DateTime.Now;
            txbMarasemTo.GeoDate = DateTime.Now;
            txbNaameAroos.Text = "";
            txbNaameDamad.Text = "";
            txbSaierKhadematFilm.Text = "";
            txbShomareGharardad.Text = "";
            txbTadvingarName.Text = "";
            txbTalar.Text = "";
            txbTarahName.Text = "";
            txbTarikhFrom.GeoDate = DateTime.Now;
            txbTarikhMarasemFrom.GeoDate = DateTime.Now;
            txbTarikhMarasemTo.GeoDate = DateTime.Now;
            txbTarikhTo.GeoDate = DateTime.Now;
            txbTozihat.Text = "";

            chbAks16x21.Checked = false;
            chbAks20x25.Checked = false;
            chbAks20x30.Checked = false;
            chbAks30x40.Checked = false;
            chbCamera2.Checked = false;
            chbCamera3.Checked = false;
            chbChapAks.Checked = false;
            chbClipSport.Checked = false;
            chbDemo.Checked = false;
            chbEntekhaabAksKhaam.Checked = false;
            chbKreen.Checked = false;
            chbNoorpardazi.Checked = false;
            chbOriginal.Checked = false;
            chbTaeedAks.Checked = false;
            chbTaeedTarahi.Checked = false;
            chbTahvilAks.Checked = false;
            chbTahvilFilmKhaam.Checked = false;
            chbZhoornal30x40.Checked = false;
            chbZhoornal30x50.Checked = false;
            chbZhoornal30x60.Checked = false;
            chbZhoornal40x60.Checked = false;
            chbZhoornal40x80.Checked = false;
            chbGharardad2.Checked = false;
            chbTarikhGharardad2.Checked = false;
            chbTarikhMarasem2.Checked = false;
            rdbAksNashod.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
            rdbAksShod.ToggleState = Telerik.WinControls.Enumerations.ToggleState.Off;
        }
    }
}
