using System;
using System.Data;
using System.Drawing;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using System.IO;
using Stimulsoft.Report;


namespace PhotoStudio
{
    public partial class frmReport : Telerik.WinControls.UI.RadForm
    {
        private DataTable InputDataTable = new DataTable();
        private DataTable PardakhtiTable = new DataTable();
        private DataTable StimTable1 = new DataTable();
        private int SearchType;
        private string ReportTitle;
        public frmReport(int Searchtype,DataTable DT,string Title)
        {
            InputDataTable = DT;
            ReportTitle = Title;
            SearchType = Searchtype;
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            
            this.Text = ReportTitle;
            SetChildTable();
            if (SearchType == 0)
            {
                dgvReport.Visible = true;
                SetMasterList();
            }
            if (SearchType == 1)
            {
                dgvReport2.Visible = true;
                SetFullMasterList();
            }
            SetPardakhtiTable();
            // SetMasterGrid();
            // SetChildGrid();
        }

        private void SetChildTable()
        {
            PardakhtiTable.Columns.Add("radif");
            PardakhtiTable.Columns.Add("tarikh");
            PardakhtiTable.Columns.Add("mablagh");
            PardakhtiTable.Columns.Add("noepardakht");
            PardakhtiTable.Columns.Add("codepeygiri");
            PardakhtiTable.Columns.Add("shomarecheck");
            PardakhtiTable.Columns.Add("tarikhsarresid");
            PardakhtiTable.Columns.Add("bank");
            PardakhtiTable.Columns.Add("saaheb");
            PardakhtiTable.Columns.Add("Id");
            PardakhtiTable.Columns.Add("GharardadId");
        }

        private void SetFullMasterList()
        {
            StimTable1.Columns.Add("GharardadNumber");
            StimTable1.Columns.Add("TarikhGharardad");
            StimTable1.Columns.Add("EntekhabAks");
            StimTable1.Columns.Add("EntekhabAksKhaam");
            StimTable1.Columns.Add("TaeedTarahi");
            StimTable1.Columns.Add("TaeedAks");
            StimTable1.Columns.Add("TahvilAks");
            StimTable1.Columns.Add("TahvilFilmKhaam");
            StimTable1.Columns.Add("ChapAks");
            StimTable1.Columns.Add("Demo");
            StimTable1.Columns.Add("Orginal");
            StimTable1.Columns.Add("DamadName");
            StimTable1.Columns.Add("ShomareTamasDamad");
            StimTable1.Columns.Add("MablaghGharardad");
            StimTable1.Columns.Add("Pardakhti");
            StimTable1.Columns.Add("Mandeh");
            LogicLayer lg = new LogicLayer();
            this.dgvReport2.TableElement.BeginUpdate();
            for (int i = 0; i < InputDataTable.Rows.Count; i++)
            {
                int mablaghKol2 = 0;
                int takhfif2 = 0;
                int pardakhti2 = 0;

                string id = InputDataTable.Rows[i]["Id"].ToString();
                string radif = (i + 1).ToString();
                string shomare = InputDataTable.Rows[i]["GharardadNumber"].ToString();
                string tarikh = lg.ShamsiDate(InputDataTable.Rows[i]["TarikhGharardad"].ToString());
                string damaad = InputDataTable.Rows[i]["DamadName"].ToString();
                string aroos = InputDataTable.Rows[i]["AroosName"].ToString();

                string tarikhmarasem = lg.ShamsiDate(InputDataTable.Rows[i]["TarikhMarasem"].ToString());
                string mablaghkol = InputDataTable.Rows[i]["MablaghGharardad"].ToString();
                string pardakhti = GetKolPardakhti(id);
                string mablaghaks = InputDataTable.Rows[i]["KolMablaghAks"].ToString();
                string mablaghfilm = InputDataTable.Rows[i]["KolMablaghFilm"].ToString();
                string takhfif = InputDataTable.Rows[i]["Takhfif"].ToString();
                if (mablaghkol == "")
                    mablaghKol2 = 0;
                else
                    mablaghKol2 = Int32.Parse(mablaghkol, System.Globalization.NumberStyles.AllowThousands);
                if (takhfif == "")
                    takhfif2 = 0;
                else
                    takhfif2 = Int32.Parse(takhfif, System.Globalization.NumberStyles.AllowThousands);
                if (pardakhti == "")
                    pardakhti2 = 0;
                else
                    pardakhti2 = Int32.Parse(pardakhti, System.Globalization.NumberStyles.AllowThousands);
                string mandeh = (mablaghKol2 - (takhfif2 + pardakhti2)).ToString("###,###,###");

                string EntekhabAks = InputDataTable.Rows[i]["EntekhabAks"].ToString();
                if (EntekhabAks == "0")
                    EntekhabAks = "انجام نشد";
                else
                    EntekhabAks = "انجام شد";
                string EntekhabAksKhaam = InputDataTable.Rows[i]["EntekhabAksKhaam"].ToString();
                if (EntekhabAksKhaam == "0")
                    EntekhabAksKhaam = "انجام نشد";
                else
                    EntekhabAksKhaam = "انجام شد";

                string TaeedTarahi = InputDataTable.Rows[i]["TaeedTarahi"].ToString();
                if (TaeedTarahi == "0")
                    TaeedTarahi = "انجام نشد";
                else
                    TaeedTarahi = "انجام شد";

                string TaeedAks = InputDataTable.Rows[i]["TaeedAks"].ToString();
                if (TaeedAks == "0")
                    TaeedAks = "انجام نشد";
                else
                    TaeedAks = "انجام شد";

                string TahvilAks = InputDataTable.Rows[i]["TahvilAks"].ToString();
                if (TahvilAks == "0")
                    TahvilAks = "انجام نشد";
                else
                    TahvilAks = "انجام شد";

                string TahvilFilmKhaam = InputDataTable.Rows[i]["TahvilFilmKhaam"].ToString();
                if (TahvilFilmKhaam == "0")
                    TahvilFilmKhaam = "انجام نشد";
                else
                    TahvilFilmKhaam = "انجام شد";

                string ChapAks = InputDataTable.Rows[i]["ChapAks"].ToString();
                if (ChapAks == "0")
                    ChapAks = "انجام نشد";
                else
                    ChapAks = "انجام شد";

                string Demo1 = InputDataTable.Rows[i]["Demo"].ToString();
                bool Demo;
                if (Demo1 == "0")
                    Demo = false;
                else
                    Demo = true;

                string Orginal1 = InputDataTable.Rows[i]["Orginal"].ToString();
                bool Orginal;
                if (Orginal1 == "0")
                    Orginal = false;
                else
                    Orginal = true;

                string TarahName = InputDataTable.Rows[i]["TarahName"].ToString();
                string TadvingarName = InputDataTable.Rows[i]["TadvingarName"].ToString();
                string ShomareTamasDamad = InputDataTable.Rows[i]["ShomareTamasDamad"].ToString();
                string ShomareTamasAroos = InputDataTable.Rows[i]["ShomareTamasAroos"].ToString();
                string TalarAddress = InputDataTable.Rows[i]["TalarAddress"].ToString();
                string SaatMarasem = InputDataTable.Rows[i]["SaatMarasem"].ToString();
                string SaaierKhadamatFilm = InputDataTable.Rows[i]["SaaierKhadamatFilm"].ToString();
                string Aks16x21_ = InputDataTable.Rows[i]["Aks16x21"].ToString();
                bool Aks16x21;
                if (Aks16x21_ == "0")
                    Aks16x21 = false;
                else
                    Aks16x21 = true;
                string TedadAks16x21 = InputDataTable.Rows[i]["TedadAks16x21"].ToString();

                string Aks20x25_ = InputDataTable.Rows[i]["Aks20x25"].ToString();
                bool Aks20x25;
                if (Aks20x25_ == "0")
                    Aks20x25 = false;
                else
                    Aks20x25 = true;
                string TedadAks20x25 = InputDataTable.Rows[i]["TedadAks20x25"].ToString();

                string Aks30x40_ = InputDataTable.Rows[i]["Aks30x40"].ToString();
                bool Aks30x40;
                if (Aks30x40_ == "0")
                    Aks30x40 = false;
                else
                    Aks30x40 = true;
                string TedadAks30x40 = InputDataTable.Rows[i]["TedadAks30x40"].ToString();

                string Aks20x30_ = InputDataTable.Rows[i]["Aks20x30"].ToString();
                bool Aks20x30;
                if (Aks20x30_ == "0")
                    Aks20x30 = false;
                else
                    Aks20x30 = true;

                string TedadAks20x30 = InputDataTable.Rows[i]["TedadAks20x30"].ToString();
                string Jurnal30x40_ = InputDataTable.Rows[i]["Zhoornal30x40"].ToString();
                bool Jurnal30x40;
                if (Jurnal30x40_ == "0")
                    Jurnal30x40 = false;
                else
                    Jurnal30x40 = true;
                string TedadJurnal30x40 = InputDataTable.Rows[i]["TedadJurnal30x40"].ToString();

                string Jurnal30x50_ = InputDataTable.Rows[i]["Zhoornal30x50"].ToString();
                bool Jurnal30x50;
                if (Jurnal30x50_ == "0")
                    Jurnal30x50 = false;
                else
                    Jurnal30x50 = true;
                string TedadJurnal30x50 = InputDataTable.Rows[i]["TedadJurnal30x50"].ToString();

                string Jurnal30x60_ = InputDataTable.Rows[i]["Zhoornal30x60"].ToString();
                bool Jurnal30x60;
                if (Jurnal30x60_ == "0")
                    Jurnal30x60 = false;
                else
                    Jurnal30x60 = true;
                string TedadJurnal30x60 = InputDataTable.Rows[i]["TedadJurnal30x60"].ToString();

                string Jurnal40x60_ = InputDataTable.Rows[i]["Zhoornal40x60"].ToString();
                bool Jurnal40x60;
                if (Jurnal40x60_ == "0")
                    Jurnal40x60 = false;
                else
                    Jurnal40x60 = true;
                string TedadJurnal40x60 = InputDataTable.Rows[i]["TedadJurnal40x60"].ToString();

                string Jurnal40x80_ = InputDataTable.Rows[i]["Zhoornal40x80"].ToString();
                bool Jurnal40x80;
                if (Jurnal40x80_ == "0")
                    Jurnal40x80 = false;
                else
                    Jurnal40x80 = true;
                string TedadJurnal40x80 = InputDataTable.Rows[i]["TedadJurnal40x80"].ToString();
                string Noorpardazi_ = InputDataTable.Rows[i]["Noorpardazi"].ToString();
                bool Noorpardazi;
                if (Noorpardazi_ == "0")
                    Noorpardazi = false;
                else
                    Noorpardazi = true;
                string Camera2_ = InputDataTable.Rows[i]["Camera2"].ToString();
                bool Camera2;
                if (Camera2_ == "0")
                    Camera2 = false;
                else
                    Camera2 = true;
                string Camera3_ = InputDataTable.Rows[i]["Camera3"].ToString();
                bool Camera3;
                if (Camera3_ == "0")
                    Camera3 = false;
                else
                    Camera3 = true;
                string ClipSport_ = InputDataTable.Rows[i]["ClipSport"].ToString();
                bool ClipSport;
                if (ClipSport_ == "0")
                    ClipSport = false;
                else
                    ClipSport = true;

                string Kreen_ = InputDataTable.Rows[i]["Kreen"].ToString();
                bool Kreen;
                if (Kreen_ == "0")
                    Kreen = false;
                else
                    Kreen = true;

                string FolderPath = InputDataTable.Rows[i]["FolderPath"].ToString();
                string TozihatGharardad = InputDataTable.Rows[i]["TozihatGharardad"].ToString();
                string TozihatMarasem = InputDataTable.Rows[i]["TozihatMarasem"].ToString();
                string TozihatAks = InputDataTable.Rows[i]["TozihatAks"].ToString();
                    
                dgvReport2.Rows.Add(radif, shomare, tarikh, damaad, aroos, tarikhmarasem, mablaghkol, pardakhti, mablaghaks, mablaghfilm, takhfif, mandeh, id,
                                    EntekhabAks, EntekhabAksKhaam, TaeedTarahi, TaeedAks, TahvilAks, TahvilFilmKhaam,
                                    ChapAks, Demo, Orginal, TarahName, TadvingarName, ShomareTamasDamad,
                                    ShomareTamasAroos, TalarAddress, SaatMarasem, SaaierKhadamatFilm,
                                    Aks16x21, TedadAks16x21, Aks20x25, TedadAks20x25, Aks30x40, TedadAks30x40 ,
                                    Aks20x30, TedadAks20x30, Jurnal30x40, TedadJurnal30x40, Jurnal30x50,
                                    TedadJurnal30x50, Jurnal30x60, TedadJurnal30x60, Jurnal40x60,
                                    TedadJurnal40x60, Jurnal40x80, TedadJurnal40x80, Noorpardazi, Camera2,
                                    Camera3, ClipSport, Kreen, FolderPath, TozihatGharardad, TozihatMarasem,
                                    TozihatAks);
                StimTable1.Rows.Add(shomare, tarikh, EntekhabAks, EntekhabAksKhaam, TaeedTarahi, TaeedAks, TahvilAks,
                                    TahvilFilmKhaam, ChapAks, Demo, Orginal, damaad, ShomareTamasDamad,
                                    mablaghkol, pardakhti, mandeh);
            }
            this.dgvReport2.TableElement.EndUpdate(true);
        }

        private void SetMasterList()
        {
            StimTable1.Columns.Add("shomare");
            StimTable1.Columns.Add("tarikh");
            StimTable1.Columns.Add("damaad");
            StimTable1.Columns.Add("aroos");
            StimTable1.Columns.Add("tarikhmarasem");
            StimTable1.Columns.Add("mablaghkol");
            StimTable1.Columns.Add("pardakhti");
            StimTable1.Columns.Add("mablaghaks");
            StimTable1.Columns.Add("mablaghfilm");
            StimTable1.Columns.Add("takhfif");
            StimTable1.Columns.Add("mandeh");
            LogicLayer lg = new LogicLayer();
            this.dgvReport.TableElement.BeginUpdate();
            for (int i = 0; i < InputDataTable.Rows.Count; i++)
            {
                int mablaghKol2 = 0;
                int takhfif2 = 0;
                int pardakhti2 = 0;

                string id = InputDataTable.Rows[i]["Id"].ToString();
                string radif = (i + 1).ToString();
                string shomare = InputDataTable.Rows[i]["GharardadNumber"].ToString();
                string tarikh = lg.ShamsiDate(InputDataTable.Rows[i]["TarikhGharardad"].ToString());
                string damaad = InputDataTable.Rows[i]["DamadName"].ToString();
                string aroos = InputDataTable.Rows[i]["AroosName"].ToString();

                string tarikhmarasem = lg.ShamsiDate(InputDataTable.Rows[i]["TarikhMarasem"].ToString());
                string mablaghkol = InputDataTable.Rows[i]["MablaghGharardad"].ToString();
                string pardakhti = GetKolPardakhti(id);
                string mablaghaks = InputDataTable.Rows[i]["KolMablaghAks"].ToString();
                string mablaghfilm = InputDataTable.Rows[i]["KolMablaghFilm"].ToString();
                string takhfif = InputDataTable.Rows[i]["Takhfif"].ToString();
                if (mablaghkol == "")
                    mablaghKol2 = 0;
                else
                    mablaghKol2 = Int32.Parse(mablaghkol, System.Globalization.NumberStyles.AllowThousands);
                if (takhfif == "")
                    takhfif2 = 0;
                else
                    takhfif2 = Int32.Parse(takhfif, System.Globalization.NumberStyles.AllowThousands);
                if (pardakhti == "")
                    pardakhti2 = 0;
                else
                    pardakhti2 = Int32.Parse(pardakhti, System.Globalization.NumberStyles.AllowThousands);
                string mandeh = (mablaghKol2 - (takhfif2 + pardakhti2)).ToString("###,###,###");
                dgvReport.Rows.Add(radif, shomare, tarikh, damaad, aroos, tarikhmarasem, mablaghkol, pardakhti, mablaghaks, mablaghfilm, takhfif, mandeh, id);
                StimTable1.Rows.Add(shomare, tarikh, damaad, aroos, tarikhmarasem, mablaghkol, pardakhti, mablaghaks, mablaghfilm, takhfif, mandeh);
            }
            this.dgvReport.TableElement.EndUpdate(true);
        }

        private string GetKolPardakhti(string GharardadId)
        {
            int KolePardakhti = 0;            
            
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
                    PardakhtiTable.Rows.Add(radif, tarikh, mablagh, noepardakht, codepeygiri, shomarecheck, tarikhsarresid, bank, saaheb, Id, GharardadId);
                }

            }
            return KolePardakhti.ToString("###,###,###");
        }

        private void SetPardakhtiTable()
        {
            GridViewTemplate template = new GridViewTemplate();
            template.DataSource = PardakhtiTable;
            //radif, tarikh, mablagh, noepardakht, shomarecheck, tarikhsarresid, bank, saaheb, Id, GharardadId
            template.Columns["Id"].IsVisible = false;
            template.Columns["GharardadId"].IsVisible = false;


            template.Columns["radif"].HeaderText = "ردیف";
            template.Columns["tarikh"].HeaderText = "تاریخ پرداخت";
            template.Columns["mablagh"].HeaderText = "مبلغ";
            template.Columns["noepardakht"].HeaderText = "نحوه پرداخت";
            template.Columns["codepeygiri"].HeaderText = "کد رهگیری";
            template.Columns["shomarecheck"].HeaderText = "شماره چک";
            template.Columns["tarikhsarresid"].HeaderText = "تاریخ سر رسید";
            template.Columns["bank"].HeaderText = "نام بانک ";
            template.Columns["saaheb"].HeaderText = "صاحب حساب";
            



            template.Columns["radif"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["tarikh"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["mablagh"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["noepardakht"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["codepeygiri"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["shomarecheck"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["tarikhsarresid"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["bank"].HeaderTextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["saaheb"].HeaderTextAlignment = ContentAlignment.MiddleCenter;


            template.Columns["radif"].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["tarikh"].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["mablagh"].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["noepardakht"].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["codepeygiri"].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["shomarecheck"].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["tarikhsarresid"].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["bank"].TextAlignment = ContentAlignment.MiddleCenter;
            template.Columns["saaheb"].TextAlignment = ContentAlignment.MiddleCenter;          

            template.ReadOnly = true;
            template.AllowAddNewRow = false;
            template.AllowDeleteRow = false;
            template.AllowEditRow = false;

            template.Columns["radif"].Width = 50;
            template.Columns["tarikh"].Width = 100;
            template.Columns["mablagh"].Width = 100;
            template.Columns["noepardakht"].Width = 100;
            template.Columns["codepeygiri"].Width = 100;
            template.Columns["shomarecheck"].Width = 100;
            template.Columns["tarikhsarresid"].Width = 100;
            template.Columns["bank"].Width = 150;
            template.Columns["saaheb"].Width = 150;

            template.AllowDragToGroup = true;
            if(SearchType == 0)
                dgvReport.MasterTemplate.Templates.Add(template);
            if (SearchType == 1)
                dgvReport2.MasterTemplate.Templates.Add(template);
            GridViewRelation relation = new GridViewRelation(dgvReport.MasterTemplate);
            relation.ChildTemplate = template;
            relation.RelationName = "InReport";
            relation.ParentColumnNames.Add("Id");
            relation.ChildColumnNames.Add("GharardadId");
            if (SearchType == 0)
                dgvReport.Relations.Add(relation);
            if (SearchType == 1)
                dgvReport2.Relations.Add(relation);
        }

        private void frmReport_Shown(object sender, EventArgs e)
        {
            this.dgvReport.GridViewElement.GroupPanelElement.Text = "برای گروه بندی یک ستون را به اینجا بکشید و رها کنید";
            this.dgvReport2.GridViewElement.GroupPanelElement.Text = "برای گروه بندی یک ستون را به اینجا بکشید و رها کنید";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {            
            int _errorCode = 0;
            if (SearchType == 0)
            {
                _errorCode = CheckReportFileExist("SearchAll.mrt");
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
            if (SearchType == 1)
            {
                _errorCode = CheckReportFileExist("SearchAllAdv.mrt");
                if (_errorCode == 0)
                {
                    CreateReportAdv();
                }
                else
                {
                    string message2 = "فایل چاپ گزارش یافت نشد";
                    frmShowInfoSmall showinfo2 = new frmShowInfoSmall(message2, 2, "خطا");
                    showinfo2.ShowDialog();
                    return;
                }
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
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\SearchAll.mrt");
                DataSet ds = new DataSet();
                DataTable StimTable = new DataTable();
                ds.Tables.Clear();
                StimTable = StimTable1.Copy();         
                ds.Tables.Add(StimTable);
                stiReport1.RegData(ds);
                stiReport1.Compile();

                stiReport1["CompanyName"] = PAPC.Info.CompanyName;
                stiReport1["ReportTitle"] = this.Text;
                stiReport1["Date"] = "تاریخ" + " : " + Persia.Calendar.ConvertToPersian(DateTime.Now).Simple;
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

        private void CreateReportAdv()
        {
            try
            {
                StiReport stiReport1 = new StiReport();

                stiReport1.Load(Application.StartupPath + "\\Reports\\SearchAllAdv.mrt");
                DataSet ds = new DataSet();
                DataTable StimTable = new DataTable();
                ds.Tables.Clear();
                StimTable = StimTable1.Copy();
                ds.Tables.Add(StimTable);
                stiReport1.RegData(ds);
                stiReport1.Compile();

                stiReport1["CompanyName"] = PAPC.Info.CompanyName;
                stiReport1["ReportTitle"] = this.Text;
                stiReport1["Date"] = "تاریخ" + " : " + Persia.Calendar.ConvertToPersian(DateTime.Now).Simple;
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

        private void dgvReport_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string id = dgvReport.Rows[e.RowIndex].Cells["GharardadNumber"].Value.ToString();
                frmGharardad gharardad = new frmGharardad(id);
                gharardad.Show();
            }
        }

        private void dgvReport_Paint(object sender, PaintEventArgs e)
        {
            this.dgvReport.GridViewElement.GroupPanelElement.Text = "برای گروه بندی یک ستون را به اینجا بکشید و رها کنید";
        }

        private void dgvReport2_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string id = dgvReport2.Rows[e.RowIndex].Cells["GharardadNumber"].Value.ToString();
                frmGharardad gharardad = new frmGharardad(id);
                gharardad.Show();
            }
        }

        private void dgvReport2_Paint(object sender, PaintEventArgs e)
        {
            this.dgvReport2.GridViewElement.GroupPanelElement.Text = "برای گروه بندی یک ستون را به اینجا بکشید و رها کنید";
        }
    }
}
