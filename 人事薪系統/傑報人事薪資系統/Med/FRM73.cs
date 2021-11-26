using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JBHR.Med
{
    public partial class FRM73 : JBControls.JBForm
    {
        public FRM73()
        {
            InitializeComponent();
        }
        //MedDS.YRFORSUBDataTable dtYRFORSUB = new MedDS.YRFORSUBDataTable();
        private void FRM51_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'medDS.V_BASE' 資料表。您可以視需要進行移動或移除。
            this.v_BASETableAdapter.Fill(this.medDS.V_BASE);
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetYrid(), false, false, true);
            SystemFunction.SetComboBoxItems(comboBox2, MainForm.WriteRules.Where(p => p.COMPANY == MainForm.COMPANY).ToDictionary(p => p.DATAGROUP, p => p.DATAGROUP1.GROUPNAME), true, false, true);
            this.tBASETableAdapter.FillByInit(this.medDS.TBASE);
            this.yRIDTableAdapter.Fill(this.medDS.YRID);
            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            //fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByDataGroupOfWrite1("TBASE.SALADR");
            fullDataCtrl1.DataAdapter = tBASETableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            //if (MainForm.WriteDataGroups.Contains(comboBox1.SelectedValue))
            //{
            //    e.Cancel = true;
            //    MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            if (!e.Cancel)
            {
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            comboBox2.SelectedValue = MainForm.ReadSalaryGroups.First();
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
        }

        private void comboBoxFormat_SelectedIndexChange(object sender, EventArgs e)
        {
        }
        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
        }

        private void textBox4_Validated(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            JBTools.Stopwatch sw = new JBTools.Stopwatch();
            sw.Start();
            UpdateTBase();
            sw.Stop();
            sw.ShowMessage();
        }
        public static void UpdateTBase()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            JBHRIS.BLL.Bas.BasettsFixDdateDao basettsDao = new JBHRIS.BLL.Bas.BasettsFixDdateDao(db.Connection);
            foreach (var tts in basettsDao.GetErrorData())
            {
                basettsDao.FixData(tts);
            }
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      select new { a.NOBR, a.COUNT_MA, a.IDNO, a.NAME_C, a.TAXNO, a.ADDR2, a.EMAIL, a.GSM, a.MATNO, a.TEL2, a.POSTCODE1, a.POSTCODE2, b.SALADR };
            var TBaseData = (from a in db.TBASE where a.INCOMP select a).ToList();

            foreach (var it in sql)
            {
                var instance = TBaseData.SingleOrDefault(p => p.NOBR.Trim() == it.NOBR.Trim());
                if (instance == null)
                {
                    instance = new JBModule.Data.Linq.TBASE();
                    instance.TAXNO = "";
                    instance.NOBR = it.NOBR;
                    db.TBASE.InsertOnSubmit(instance);
                }
                instance.ADDR = it.ADDR2;
                instance.EMAIL = it.EMAIL;
                instance.GSM = it.GSM;
                instance.IDNO = it.IDNO;
                if (it.IDNO.Trim().Length == 0)
                {
                    instance.IDNO = it.MATNO;
                }
                instance.INCOMP = true;
                instance.NAME_C = it.NAME_C;
                instance.POSTCODE1 = it.POSTCODE1;
                instance.POSTCODE2 = it.POSTCODE2;
                instance.TEL = it.TEL2;
                instance.IDCODE = "";
                instance.KEY_DATE = DateTime.Now;
                instance.KEY_MAN = MainForm.USER_NAME;
                instance.SALADR = it.SALADR;
                if (!it.COUNT_MA)
                {
                    instance.IDCODE = "0";
                    int result = 0;
                    if (instance.IDNO.Trim().Length > 2 && !int.TryParse(instance.IDNO.Substring(1, 1), out result))//第二碼不是數字
                    {
                        instance.IDCODE = "3";
                    }
                }
                else
                {
                    //if (tb.ADDR.Trim().Length > 0) tb.IDCODE = "4";//選擇4驗證會錯誤
                    //else 
                    instance.IDCODE = "3";
                    instance.IDNO = it.MATNO;
                }
                //db.TBASE.InsertOnSubmit(instance);
            }
            db.SubmitChanges();
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;

            frm.ColumnStyle = JBTools.IO.LoadExcelColumnNameStyle.DefinedColumn;

            frm.Text = "所得人資料匯入";
            frm.FieldForm = new FRM73_IMPORT();
            frm.DataTransfer = new ImportFRM73Data();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.medDS.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("證號別", db.YRID.Select(p => new JBControls.CheckImportData { DisplayCode = p.ID_CODE, RealCode = p.ID_CODE, DisplayName = p.DESCR }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("所得人編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("所得人姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("統一編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("稅籍編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("電話", typeof(string));
            frm.DataTransfer.ColumnList.Add("行動電話", typeof(string));
            frm.DataTransfer.ColumnList.Add("E-Mail", typeof(string));
            frm.DataTransfer.ColumnList.Add("證號別", typeof(string));
            frm.DataTransfer.ColumnList.Add("郵遞區號", typeof(string));
            frm.DataTransfer.ColumnList.Add("地址", typeof(string));
            frm.DataTransfer.ColumnList.Add("是否為內部員工", typeof(Boolean));
            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("稅籍編號");
            frm.DataTransfer.UnMustColumnList.Add("電話");
            frm.DataTransfer.UnMustColumnList.Add("行動電話");
            frm.DataTransfer.UnMustColumnList.Add("E-Mail");
            frm.DataTransfer.UnMustColumnList.Add("郵遞區號");
            frm.DataTransfer.UnMustColumnList.Add("地址");

            frm.ShowDialog();
        }
    }

    static class Ext
    {
        public static string GetFullLenStr(this string str, int len)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(str.Trim());
            var TotalLen = bytes.Length;
            if (TotalLen > len) TotalLen = len;
            string emptyStr = "".PadRight(len - TotalLen, ' ');
            string ss = str.Trim() + emptyStr;
            if (ss.Length > len) ss = ss.Substring(0, TotalLen);
            return ss;
        }
    }
}
