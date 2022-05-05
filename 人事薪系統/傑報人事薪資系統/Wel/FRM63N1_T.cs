using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal.Core;

namespace JBHR.Wel
{
    public partial class FRM63N1_T : JBControls.JBForm
    {
        public FRM63N1_T()
        {
            InitializeComponent();
        }
        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        public int TW_TAX_Auto = -1;
        void SetControls()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string YYMM_B, YYMM_E;
            YYMM_B = textBoxYYMM_B.Text;
            YYMM_E = textBoxYYMM_E.Text;
            DateTime DateBegin, DateEnd;
            DateBegin = Convert.ToDateTime(txtPayDateB.Text);
            DateEnd = Convert.ToDateTime(txtPayDateE.Text);
            //Todo:未做權限判斷
            var EmpData = GetEmpDataByWage(YYMM_B, YYMM_E, DateBegin, DateEnd, MainForm.ReadSalaryGroups);
            mdEmp.SetControl(buttonEmp, EmpData, "員工編號");
        }
        DataTable GetEmpDataByWage(string YYMM_B, string YYMM_E, DateTime DateBegin, DateTime DateEnd, List<string> DataGroupList)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.WAGE
                      join b in db.BASE on a.NOBR equals b.NOBR
                      join c in db.BASETTS on a.NOBR equals c.NOBR
                      join d in db.DEPT on c.DEPT equals d.D_NO
                      join e in db.EMPCD on c.EMPCD equals e.EMPCD1
                      where a.YYMM.CompareTo(YYMM_B) >= 0 && a.YYMM.CompareTo(YYMM_E) <= 0
                      && a.ADATE >= DateBegin && a.ADATE <= DateEnd
                      && DateEnd >= c.ADATE && DateEnd <= c.DDATE.Value
                      && MainForm.ReadSalaryGroups.Contains(a.SALADR)
                      select new { 員工編號 = a.NOBR, 員工姓名 = b.NAME_C, 編制部門 = d.D_NAME, 員別 = e.EMPDESCR, 資料群組 = a.SALADR };
            return sql.Distinct().CopyToDataTable();
        }


        private void textBoxYYMM_B_Validated(object sender, EventArgs e)
        {
            SetControls();
        }

        private void textBoxYYMM_E_Validated(object sender, EventArgs e)
        {
            SetControls();
        }

        private void txtPayDateB_Validated(object sender, EventArgs e)
        {
            SetControls();
        }

        private void txtPayDateE_Validated(object sender, EventArgs e)
        {
            SetControls();
        }

        private void FRM63N1_T_Load(object sender, EventArgs e)
        {
            textBoxYYMM_B.Text = DateTime.Today.Year.ToString() + "01";
            textBoxYYMM_E.Text = DateTime.Today.Year.ToString() + "12";
            txtPayDateB.Text = new DateTime(DateTime.Today.Year, 1, 1).ToString("yyyy/MM/dd");
            txtPayDateE.Text = new DateTime(DateTime.Today.Year, 12, 31).ToString("yyyy/MM/dd");

            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var FormatData = db.YRFORMAT.Where(p => new string[] { "91", "92" }.Contains(p.M_FORMAT)).Select(p => new { p.M_FORMAT, p.M_FMT_NAME }).ToList();
            radCheckedDropDownList1.DataSource = FormatData;
            radCheckedDropDownList1.ValueMember = "M_FORMAT";
            radCheckedDropDownList1.DisplayMember = "M_FMT_NAME";
            radCheckedDropDownList1.ShowCheckAllItems = true;

            var CompData = (from a in MainForm.UserCompList
                            join b in db.COMP.ToList() on a.COMPANY equals b.COMP1
                            where a.USER_ID == MainForm.USER_ID
                            select new { a.COMPANY, b.COMPNAME }).ToList();
            radCheckedDropDownList2.DataSource = CompData;
            radCheckedDropDownList2.ValueMember = "COMPANY";
            radCheckedDropDownList2.DisplayMember = "COMPNAME";
            radCheckedDropDownList2.ShowCheckAllItems = true;
        }

        private void buttonTrans_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("FRM63N1", MainForm.COMPANY);

            bool Note1Enable = acg.GetConfig("Note1Enable").Value.ToUpper() == "TRUE" ? true : false;
            bool Note2Enable = acg.GetConfig("Note2Enable").Value.ToUpper() == "TRUE" ? true : false;
            string Note1DefaultBinding = acg.GetConfig("Note1DefaultBinding").GetString(string.Empty);
            string Note2DefaultBinding = acg.GetConfig("Note2DefaultBinding").GetString(string.Empty);

            var ExistData = db.TW_TAX_ITEM.Where(p => p.PID == TW_TAX_Auto);
            if (ExistData.Any())
            {
                if (MessageBox.Show("有已存在的所得資料，是否要清空?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                    db.ExecuteCommand("DELETE TW_TAX_ITEM WHERE PID={0}", TW_TAX_Auto);
            }
            var WelSalcode = MainForm.SalaryConfig != null ? MainForm.SalaryConfig.WELSALCODE : "";
            var WelfDataWelfareSQL = (from a in db.WELF
                                      join b in db.U_SYS1 on a.COMP equals b.Comp
                                      join c in db.COMP on b.COMPID1 equals c.COMPID
                                      join x in db.BASETTS on a.NOBR equals x.NOBR
                                      join d in db.BASETTS on a.NOBR equals d.NOBR
                                      join f in db.EMPCD on d.EMPCD equals f.EMPCD1
                                      where mdEmp.SelectedValues.Contains(a.NOBR)
                                      //&& radCheckedDropDownList1.CheckedItems.Select(p => p.Value.ToString().Trim()).ToList().Contains("92")
                                      && radCheckedDropDownList2.CheckedItems.Select(p => p.Value.ToString().Trim()).ToList().Contains(c.COMP1.Trim())
                                      && a.YYMM.CompareTo(textBoxYYMM_B.Text) >= 0 && a.YYMM.CompareTo(textBoxYYMM_E.Text) <= 0
                                      //&& a.ADATE >= Convert.ToDateTime(txtPayDateB.Text) && a.ADATE <= Convert.ToDateTime(txtPayDateE.Text)
                                      && Convert.ToDateTime(txtPayDateE.Text) >= x.ADATE && Convert.ToDateTime(txtPayDateE.Text) <= x.DDATE.Value
                                      && c.COMPID.Trim().Length > 0
                                      && a.DATE_E >= d.ADATE && a.DATE_E <= d.DDATE.Value
                                      && f.FORMAL
                                      && MainForm.ReadSalaryGroups.Contains(a.SALADR)
                                      select new { a.NOBR, a.YYMM, a.SEQ, c.COMPID, a.SALADR, a.AMT, a.D_AMT, d.ADATE, d.DDATE });
            var WelfDataWelfare = WelfDataWelfareSQL.ToList().Select(p => new
                                  {
                                      p.NOBR,
                                      p.YYMM,
                                      p.SEQ,
                                      p.COMPID,
                                      p.SALADR,
                                      AMT = JBModule.Data.CDecryp.Number(p.AMT),
                                      D_AMT = JBModule.Data.CDecryp.Number(p.D_AMT),
                                      p.ADATE,
                                      p.DDATE
                                  });
            var WageDataWelfare = (from a in db.WAGE
                                   join b in db.U_SYS1 on a.COMP equals b.Comp
                                   join c in db.COMP on b.COMPID1 equals c.COMPID
                                   join x in db.BASETTS on a.NOBR equals x.NOBR
                                   join d in db.BASETTS on a.NOBR equals d.NOBR
                                   join f in db.EMPCD on d.EMPCD equals f.EMPCD1
                                   where mdEmp.SelectedValues.Contains(a.NOBR)
                                   && radCheckedDropDownList1.CheckedItems.Select(p => p.Value.ToString().Trim()).ToList().Contains("92")
                                   && radCheckedDropDownList2.CheckedItems.Select(p => p.Value.ToString().Trim()).ToList().Contains(c.COMP1.Trim())
                                   && a.YYMM.CompareTo(textBoxYYMM_B.Text) >= 0 && a.YYMM.CompareTo(textBoxYYMM_E.Text) <= 0
                                   && a.ADATE >= Convert.ToDateTime(txtPayDateB.Text) && a.ADATE <= Convert.ToDateTime(txtPayDateE.Text)
                                   && Convert.ToDateTime(txtPayDateE.Text) >= x.ADATE && Convert.ToDateTime(txtPayDateE.Text) <= x.DDATE.Value
                                   && c.COMPID.Trim().Length > 0
                                   && a.DATE_E >= d.ADATE && a.DATE_E <= d.DDATE.Value
                                   && f.FORMAL//20180118台光只抓正式員工
                                   && MainForm.ReadSalaryGroups.Contains(a.SALADR)
                                   select new { a.NOBR, a.YYMM, a.SEQ, c.COMPID, a.ADATE, a.NOTE, a.SALADR }).ToList();
            var WagedDataWelfare = (from a in db.WAGE
                                    join b in db.WAGED on new { a.NOBR, a.YYMM, a.SEQ } equals new { b.NOBR, b.YYMM, b.SEQ }
                                    join c in db.SALCODE on b.SAL_CODE equals c.SAL_CODE
                                    join d in db.SALATTR on c.SAL_ATTR equals d.SALATTR1
                                    join b1 in db.U_SYS1 on a.COMP equals b1.Comp
                                    join c1 in db.COMP on b1.COMPID1 equals c1.COMPID
                                    join x in db.BASETTS on a.NOBR equals x.NOBR
                                    where mdEmp.SelectedValues.Contains(a.NOBR)
                                    && radCheckedDropDownList1.CheckedItems.Select(p => p.Value.ToString().Trim()).ToList().Contains("92")
                                    && radCheckedDropDownList2.CheckedItems.Select(p => p.Value.ToString().Trim()).ToList().Contains(c1.COMP1.Trim())
                                    && a.YYMM.CompareTo(textBoxYYMM_B.Text) >= 0 && a.YYMM.CompareTo(textBoxYYMM_E.Text) <= 0
                                    && a.ADATE >= Convert.ToDateTime(txtPayDateB.Text) && a.ADATE <= Convert.ToDateTime(txtPayDateE.Text)
                                    && Convert.ToDateTime(txtPayDateE.Text) >= x.ADATE && Convert.ToDateTime(txtPayDateE.Text) <= x.DDATE.Value
                                    && MainForm.ReadSalaryGroups.Contains(a.SALADR)
                                    && (b.SAL_CODE == WelSalcode)
                                    select new { a.NOBR, a.YYMM, a.SEQ, b.SAL_CODE, d.TAX, FullAmt = b.AMT, AMT = d.FLAG != "-" ? b.AMT : b.AMT * -1 }).ToList();
            var WagedDataWelfare1 = (from a in WagedDataWelfare
                                     select new { a.NOBR, a.YYMM, a.SEQ, a.SAL_CODE, a.TAX, FullAmt = JBModule.Data.CDecryp.Number(a.FullAmt), AMT = JBModule.Data.CDecryp.Number(a.AMT) }).ToList();
            var forsubData = db.TW_TAX_SUBCODE.Where(p => p.M_FORMAT == "92").ToList();
            var forsub = forsubData.SingleOrDefault(p => p.M_FORSUB.Trim() == "8A");
            var WelComp = db.COMP.SingleOrDefault(p => p.COMPID == MainForm.CompanyConfig.COMPID1);
            if (WelComp != null)
            {
                foreach (var it in WelfDataWelfare.GroupBy(p => new { p.NOBR, p.YYMM, p.SEQ }))
                {
                    //var WelfDataOfYYMMSEQ = WelfDataWelfare.Where(p => p.NOBR == it.NOBR && p.YYMM == it.YYMM && p.SEQ == it.SEQ);
                    //if (!WelfDataOfYYMMSEQ.Any()) continue;
                    var TotalTaxableAmt = it.Sum(p => p.AMT);
                    var TaxAmt = it.Sum(p => p.D_AMT);
                    var RetAmt = 0;
                    JBModule.Data.Linq.TW_TAX_ITEM item = new JBModule.Data.Linq.TW_TAX_ITEM
                    {
                        AMT = JBModule.Data.CEncrypt.Number(TotalTaxableAmt),
                        COMP = WelComp.COMP1,
                        D_AMT = JBModule.Data.CEncrypt.Number(TaxAmt),
                        FORMAT = "92",
                        FORSUB = "",
                        IMPORT = true,
                        INA_ID = "",
                        IS_FILE = false,
                        KEY_DATE = DateTime.Now,
                        KEY_MAN = MainForm.USER_NAME,
                        MEMO = string.Empty,//it.NOTE,
                        Note1 = FRM63N1.GetDefaultBinding(db, Note1DefaultBinding, it.Key.NOBR),//string.Empty,
                        Note2 = FRM63N1.GetDefaultBinding(db, Note2DefaultBinding, it.Key.NOBR),//string.Empty,
                        NOBR = it.Key.NOBR,
                        PID = TW_TAX_Auto,
                        SAL_CODE = "福利金資料轉入",
                        SEQ = it.Key.SEQ,
                        SUBCODE = 0,
                        SUP_AMT = 10,
                        TAXNO = "",
                        TR_TYPE = "",
                        YYMM = it.Key.YYMM,
                        RET_AMT = JBModule.Data.CEncrypt.Number(RetAmt),
                    };
                    if (forsub != null) item.SUBCODE = forsub.AUTO;
                    db.TW_TAX_ITEM.InsertOnSubmit(item);
                }

                foreach (var it in WageDataWelfare)
                {
                    var WagedOfYYMMSEQ = WagedDataWelfare1.Where(p => p.NOBR == it.NOBR && p.YYMM == it.YYMM && p.SEQ == it.SEQ);
                    if (!WagedOfYYMMSEQ.Any()) continue;
                    var TotalTaxableAmt = WagedOfYYMMSEQ.Sum(p => p.AMT);
                    var TaxAmt = 0;
                    var RetAmt = 0;
                    JBModule.Data.Linq.TW_TAX_ITEM item = new JBModule.Data.Linq.TW_TAX_ITEM
                    {
                        AMT = JBModule.Data.CEncrypt.Number(TotalTaxableAmt),
                        COMP = WelComp.COMP1,
                        D_AMT = JBModule.Data.CEncrypt.Number(TaxAmt),
                        FORMAT = "92",
                        FORSUB = "",
                        IMPORT = true,
                        INA_ID = "",
                        IS_FILE = false,
                        KEY_DATE = DateTime.Now,
                        KEY_MAN = MainForm.USER_NAME,
                        MEMO = it.NOTE,
                        Note1 = FRM63N1.GetDefaultBinding(db, Note1DefaultBinding, it.NOBR),//string.Empty,
                        Note2 = FRM63N1.GetDefaultBinding(db, Note2DefaultBinding, it.NOBR),//string.Empty,
                        NOBR = it.NOBR,
                        PID = TW_TAX_Auto,
                        SAL_CODE = "薪資福利金轉入",
                        SEQ = it.SEQ,
                        SUBCODE = 0,
                        SUP_AMT = 10,
                        TAXNO = "",
                        TR_TYPE = "",
                        YYMM = it.YYMM,
                        RET_AMT = JBModule.Data.CEncrypt.Number(RetAmt),
                    };
                    if (forsub != null) item.SUBCODE = forsub.AUTO;
                    db.TW_TAX_ITEM.InsertOnSubmit(item);
                }
            }
            db.SubmitChanges();
            sw.Stop();
            MessageBox.Show(string.Format("轉入完成，共耗費{0}秒", sw.Elapsed.TotalSeconds));
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
//namespace System.Runtime.CompilerServices
//{
//    public class ExtensionAttribute : Attribute { }
//}
