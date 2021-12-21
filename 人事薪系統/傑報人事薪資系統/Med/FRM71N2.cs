using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using JBTools;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Med
{
    public partial class FRM71N2 : JBControls.JBForm
    {
        public FRM71N2()
        {
            InitializeComponent();
        }
        public int TW_TAX_Auto = -1;
        private void buttonImportFromPayRoll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("轉換將會清空現有設定中的申報資料，是否確定要執行?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                string StartChar = maskedTextBox1.Text.Substring(0, 1);
                string StartIndex = maskedTextBox1.Text.Substring(1, 7);
                int iStartIndex = 0;
                if (!int.TryParse(StartIndex, out iStartIndex))
                {
                    MessageBox.Show("起始序號除第一個字元可以是英文字以外，其餘只能是數字", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.ExecuteCommand(string.Format("DELETE TW_TAX_SUMMARY WHERE PID={0}", TW_TAX_Auto))
                    ;
                var TaxData = (from a in db.TW_TAX_ITEM
                               where a.PID == TW_TAX_Auto
                               select a).ToList();
                var EmpData = db.TBASE.ToList();
                var CompData = db.COMP.ToList();
                var TaxDataGroup = TaxData.GroupBy(p => new { COMP = p.COMP.Trim(), NOBR = p.NOBR.Trim(), FORMAT = p.FORMAT.Trim(), p.SUBCODE, p.IS_FILE });
                int i = 0;
                foreach (var gp in TaxDataGroup)
                {
                    try
                    {
                        db = new JBModule.Data.Linq.HrDBDataContext();
                       
                        JBModule.Data.Linq.TW_TAX_SUMMARY instance = new JBModule.Data.Linq.TW_TAX_SUMMARY();
                        instance.PID = TW_TAX_Auto;
                        instance.ERROR = "";
                        instance.NOBR = gp.Key.NOBR;
                        instance.KEY_DATE = DateTime.Now;
                        instance.KEY_MAN = MainForm.USER_NAME;
                        instance.MEMO = "";
                        instance.AMT = JBModule.Data.CEncrypt.Number(gp.Sum(p => JBModule.Data.CDecryp.Number(p.AMT)));
                        instance.COMP = gp.Key.COMP;
                        instance.D_AMT = JBModule.Data.CEncrypt.Number(gp.Sum(p => JBModule.Data.CDecryp.Number(p.D_AMT)));
                        instance.RET_AMT = JBModule.Data.CEncrypt.Number(gp.Sum(p => JBModule.Data.CDecryp.Number(p.RET_AMT)));
                        instance.FORMAT = gp.Key.FORMAT;
                        instance.FORSUB = "";
                        instance.SUBCODE = gp.Key.SUBCODE;
                        instance.SUP_AMT = 10;
                        instance.IS_FILE = gp.Key.IS_FILE;
                        var Emp = EmpData.SingleOrDefault(p => p.NOBR == gp.Key.NOBR);
                        if (Emp != null)
                        {
                            instance.TAXNO = "";
                            instance.NAME_C = Emp.NAME_C;
                            instance.POST2 = Emp.POSTCODE2;
                            instance.SERIES = StartChar + (i + iStartIndex).ToString("0000000");
                            instance.IDCODE = Emp.IDCODE;
                            instance.ID = Emp.IDNO;
                            if (instance.ID.Trim().Length == 0)
                                instance.ERROR += "身分證號/統一編號未提供;";
                            instance.ADDR2 = Emp.ADDR;
                            if (instance.ADDR2.Trim().Length > 30)
                                instance.ERROR += "地址超過三十個字;";
                            instance.TAXNO = Emp.TAXNO;
                        }
                        else
                        {
                            instance.ERROR += "找不到所得人資料;";
                        }
                        var Comp = CompData.SingleOrDefault(p => p.COMP1 == gp.Key.COMP);
                        if (Comp != null)
                        {
                            instance.F0103 = Comp.F0103;
                            instance.F0407 = Comp.F0407;
                            instance.ID1 = Comp.COMPID;
                        }
                        else
                        {
                            instance.ERROR += "找不到公司資料;";
                        }
                        db.TW_TAX_SUMMARY.InsertOnSubmit(instance);
                        db.SubmitChanges();
                        i++;
                    }
                    catch (Exception ex)
                    {
                        JBModule.Message.TextLog.WriteLog(ex);
                    }
                }
                sw.Stop();
                sw.ShowMessage();
            }
        }
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        private void jbQuery1_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            var instance = db.TW_TAX_SUMMARY.SingleOrDefault(p => p.AUTO == Convert.ToInt32(e.PrimaryKey));
            JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AUTO);
            db.ExecuteCommand("DELETE TW_TAX_SUMMARY WHERE AUTO={0}", e.PrimaryKey);
        }

        private void buttonImportFromFile_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            //frm.Allow_Repeat_Delete = true;
            //frm.Allow_Repeat_Ignore = true;
            //frm.Allow_Repeat_Override = true;
            frm.ColumnStyle = JBTools.IO.LoadExcelColumnNameStyle.DefinedColumn;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            frm.Text = "各類所得批次匯入";
            frm.Allow_MatchField = false;

            frm.AutoMatchMode = true;

            frm.FieldForm = new JBControls.U_FIELD();
            frm.DataTransfer = new TwYearTaxImport();
            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();


            frm.DataTransfer.CheckData.Add("員工編號", db.TBASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("所得格式", db.YRFORMAT.Select(p => new JBControls.CheckImportData { DisplayCode = p.M_FORMAT, RealCode = p.M_FORMAT, DisplayName = p.M_FMT_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("公司", db.COMP.Select(p => new JBControls.CheckImportData { DisplayCode = p.COMP1, RealCode = p.COMP1, DisplayName = p.COMPNAME }).ToList());
            frm.DataTransfer.CheckData.Add("所得註記FULL", db.TW_TAX_SUBCODE.Select(p => new JBControls.CheckImportData { DisplayCode = p.M_FORSUB, RealCode = p.AUTO.ToString(), DisplayName = p.M_SUB_NAME, CheckValue1 = p.M_FORMAT }).ToList());
            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("公司", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            //frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("所得年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("期別", typeof(string));
            frm.DataTransfer.ColumnList.Add("所得格式", typeof(string));
            frm.DataTransfer.ColumnList.Add("所得註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("給付總額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("扣繳稅額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("自提退休金", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("已申報", typeof(string));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("警告", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("所得註記");
            frm.DataTransfer.UnMustColumnList.Add("備註");


            frm.ShowDialog();
        }

        private void buttonIsFile_Click(object sender, EventArgs e)
        {
            foreach (var it in jbQuery1.SelectKeys)
            {
                try
                {
                    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                    var instance = db.TW_TAX_ITEM.Where(p => p.AUTO == Convert.ToInt32(it)).FirstOrDefault();
                    if (instance != null)
                        instance.IS_FILE = true;
                    db.SubmitChanges();
                }
                catch { }
            }
        }

        private void buttonIsNotFile_Click(object sender, EventArgs e)
        {
            foreach (var it in jbQuery1.SelectKeys)
            {
                try
                {
                    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                    var instance = db.TW_TAX_ITEM.SingleOrDefault(p => p.AUTO == Convert.ToInt32(it));
                    if (instance != null)
                        instance.IS_FILE = false;
                    db.SubmitChanges();
                }
                catch { }
            }
        }

        private void FRM71N2_Load(object sender, EventArgs e)
        {
            jbQuery1.Parameters.Add("TW_TAX_AUTO", TW_TAX_Auto.ToString());
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            List<JBModule.Data.Linq.YRTAX> yrtaxList = new List<JBModule.Data.Linq.YRTAX>();
            if (db.Connection.State != ConnectionState.Open)
                db.Connection.Open();
            var trans = db.Connection.BeginTransaction();
            db.Transaction = trans;
            using (trans)
            {
                var instance = db.TW_TAX.SingleOrDefault(p => p.AUTO == TW_TAX_Auto);

                var data = (from _tw_tax_summary in db.TW_TAX_SUMMARY
                            join _basetts in db.BASETTS on _tw_tax_summary.NOBR equals _basetts.NOBR
                            where _tw_tax_summary.PID == TW_TAX_Auto
                            && instance.DateEnd >= _basetts.ADATE && instance.DateEnd <= _basetts.DDATE.Value
                            select new { _tw_tax_summary, _basetts.SALADR }).ToList();
                var compList = data.Select(p => p._tw_tax_summary.COMP).Distinct().ToList();
                var formatList = data.Select(p => p._tw_tax_summary.FORMAT).Distinct().ToList();

                foreach (var it in data)
                {
                    JBModule.Data.Linq.YRTAX rr = new JBModule.Data.Linq.YRTAX
                    {
                        ACC_NO = it._tw_tax_summary.NOBR,
                        ADDR_2 = it._tw_tax_summary.ADDR2,
                        BLANK_1 = "",
                        SALADR = it.SALADR,
                        YEAR = instance.YearMonth,
                        COMP = it._tw_tax_summary.COMP,
                        DATE = "",
                        ERR_MARK = "",
                        F0103 = it._tw_tax_summary.F0103,
                        F0407 = it._tw_tax_summary.F0407,
                        FORMAT = it._tw_tax_summary.FORMAT,
                        ID = it._tw_tax_summary.ID,
                        ID1 = it._tw_tax_summary.ID1,
                        IDCODE = it._tw_tax_summary.IDCODE,
                        KEY_DATE = DateTime.Now,
                        KEY_MAN = MainForm.USER_NAME,
                        MARK = "",
                        NAME_C = it._tw_tax_summary.NAME_C,
                        NOBR = it._tw_tax_summary.NOBR,
                        POSTCODE2 = it._tw_tax_summary.POST2,
                        TOT_AMT = it._tw_tax_summary.AMT,//JBModule.Data.CEncrypt.Number(it._tw_tax_summary.AMT),
                        REL_AMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(it._tw_tax_summary.AMT) - JBModule.Data.CDecryp.Number(it._tw_tax_summary.D_AMT)),
                        RET_AMT = it._tw_tax_summary.RET_AMT,//JBModule.Data.CEncrypt.Number(it._tw_tax_summary.RET_AMT),
                        SERIES = it._tw_tax_summary.SERIES,
                        T_OK = it._tw_tax_summary.IS_FILE,
                        TAX_AMT = it._tw_tax_summary.D_AMT,//JBModule.Data.CEncrypt.Number(it._tw_tax_summary.D_AMT),
                        YEAR_B = instance.DateBegin.ToString("yyyy/MM/dd"),
                        YEAR_E = instance.DateEnd.ToString("yyyy/MM/dd"),
                    };
                    yrtaxList.Add(rr);
                }
            }

            Reports.SalForm.ZZ51B frm = new Reports.SalForm.ZZ51B();
            frm.yrtaxList = yrtaxList;
            frm.yrparameters = new Dictionary<string, object>();
            frm.ShowDialog();
        }
    }
    public class TwYearTaxSummaryImport : JBControls.ImportTransfer
    {

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            foreach (DataColumn dc in TargetRow.Table.Columns)
            {
                if (SourceRow.Table.Columns.Contains(dc.ColumnName))
                    TargetRow[dc.ColumnName] = SourceRow[dc.ColumnName];
            }
            var CheckFormatSub = CheckData["所得註記FULL"].Where(p => p.CheckValue1.Trim() == TargetRow["所得格式"].ToString().Trim());
            if (CheckFormatSub.Any())//完全沒有就不檢查
            {
                var CheckError = CheckFormatSub.Where(p => p.DisplayCode.Trim() == TargetRow["所得註記"].ToString().Trim());
                if (!CheckError.Any())
                {
                    CheckError = CheckFormatSub.Where(p => p.DisplayName.Trim() == TargetRow["所得註記"].ToString().Trim());
                    if (!CheckError.Any())
                        SetError(TargetRow, "錯誤的所得註記(" + TargetRow["所得註記"].ToString() + ")");
                }
            }
            return true;
        }

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            return InsertTwYearTax(TransferRow, RepeatSelectionString, out ErrorMsg);
        }

        private bool InsertTwYearTax(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            ErrorMsg = "";
            try
            {
                JBModule.Data.Linq.TW_TAX_ITEM item = new JBModule.Data.Linq.TW_TAX_ITEM();
                item.NOBR = TransferRow["員工編號"].ToString();
                item.YYMM = TransferRow["所得年月"].ToString();
                item.SEQ = TransferRow["期別"].ToString();
                item.FORMAT = TransferRow["所得格式"].ToString();
                item.AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(TransferRow["給付總額"]));
                item.D_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(TransferRow["扣繳稅額"]));
                item.RET_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(TransferRow["自提退休金"]));
                item.SAL_CODE = "檔案匯入";
                var CheckFormatSub = CheckData["所得註記FULL"].Where(p => p.CheckValue1.Trim() == TransferRow["所得格式"].ToString().Trim());
                if (CheckFormatSub.Any())//完全沒有就不檢查
                {
                    var CheckError = CheckFormatSub.Where(p => p.DisplayCode.Trim() == TransferRow["所得註記"].ToString().Trim());
                    if (!CheckError.Any())
                    {
                        CheckError = CheckFormatSub.Where(p => p.DisplayName.Trim() == TransferRow["所得註記"].ToString().Trim());
                        if (!CheckError.Any())
                        {
                            SetError(TransferRow, "錯誤的所得註記(" + TransferRow["所得註記"].ToString() + ")");
                            return false;
                        }
                        else item.SUBCODE = Convert.ToInt32(CheckError.First().RealCode);
                    }
                    else item.SUBCODE = Convert.ToInt32(CheckError.First().RealCode);
                }
                else
                    item.SUBCODE = 0;
                item.SUP_AMT = 10;
                item.TAXNO = "";
                item.TR_TYPE = "";
                item.COMP = TransferRow["公司"].ToString();
                item.INA_ID = "";
                item.FORSUB = "";
                item.IMPORT = true;
                item.IS_FILE = TransferRow["已申報"].ToString().Trim() == "Y";
                item.KEY_DATE = DateTime.Now;
                item.KEY_MAN = MainForm.USER_NAME;
                item.MEMO = TransferRow["備註"].ToString();
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                db.TW_TAX_ITEM.InsertOnSubmit(item);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
        }
    }
}
