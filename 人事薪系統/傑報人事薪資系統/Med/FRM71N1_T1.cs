﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Med
{
    public partial class FRM71N1_T1 : JBControls.JBForm
    {
        public FRM71N1_T1()
        {
            InitializeComponent();
        }
        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        public int TW_TAX_Auto = -1;
        void SetControls()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string YYMM_B, YYMM_E;
            YYMM_B = textBoxYYMM.Text;
            //Todo:未做權限判斷
            var EmpData = GetEmpDataByWage(YYMM_B, MainForm.WriteDataGroups);
            mdEmp.SetControl(buttonEmp, EmpData, "員工編號");
        }
        DataTable GetEmpDataByWage(string YYMM_B, List<string> DataGroupList)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(YYMM_B);

            var sql = from a in db.WAGE
                      join b in db.BASE on a.NOBR equals b.NOBR
                      join c in db.BASETTS on a.NOBR equals c.NOBR
                      join d in db.DEPT on c.DEPT equals d.D_NO
                      join e in db.EMPCD on c.EMPCD equals e.EMPCD1
                      where a.FILE_YYMM == YYMM_B
                      && DataGroupList.Contains(a.SALADR)
                      && sd.LastDayOfSalary >= c.ADATE && sd.LastDayOfSalary <= c.DDATE.Value
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

        private void FRM71N1_T_Load(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var twTax = db.TW_TAX.SingleOrDefault(p => p.AUTO == this.TW_TAX_Auto);
            if (twTax == null)
            {
                MessageBox.Show("取得主檔設定時發生錯誤");
                this.Close();
            }
            string YYMM = twTax.YearMonth;
            if (YYMM.Length == 4)
                YYMM += "01";
            textBoxYYMM.Text = YYMM;
            var formatData = db.YRFORMAT.Select(p => new { p.M_FORMAT, p.M_FMT_NAME }).ToList();
            radCheckedDropDownList1.DataSource = formatData;
            radCheckedDropDownList1.ValueMember = "M_FORMAT";
            radCheckedDropDownList1.DisplayMember = "M_FMT_NAME";
            radCheckedDropDownList1.ShowCheckAllItems = true;

            var CompData = (from a in db.COMP
                            select new { a.COMP1, a.COMPNAME }).ToList();
            radCheckedDropDownList2.DataSource = CompData;
            radCheckedDropDownList2.ValueMember = "COMP1";
            radCheckedDropDownList2.DisplayMember = "COMPNAME";
            radCheckedDropDownList2.ShowCheckAllItems = true;

        }

        private void buttonTrans_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var ExistData = db.TW_TAX_ITEM.Where(p => p.PID == TW_TAX_Auto);
            if (ExistData.Any())
            {
                if (MessageBox.Show("有已存在的所得資料，是否要清空?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                    db.ExecuteCommand("DELETE TW_TAX_ITEM WHERE PID={0}", TW_TAX_Auto);
            }
            var TaxSalcode = Sal.Core.SysVar.TaxVar.TAXSALCODE;
            var RetSalcode = Sal.Core.SysVar.LabVar.RETSALCODE;
            var WelSalcode = Sal.Core.SysVar.SalaryVar.WELSALCODE;
            //todo:未卡資料群組
            var WageData = (from a in db.WAGE
                            join b in db.BASE on a.NOBR equals b.NOBR
                            //join c in db.BASETTS on a.NOBR equals c.NOBR
                            join d in db.BASETTS on a.NOBR equals d.NOBR
                            join f in db.EMPCD on d.EMPCD equals f.EMPCD1
                            where mdEmp.SelectedValues.Contains(a.NOBR)
                            && radCheckedDropDownList1.CheckedItems.Select(p => p.Value).ToList().Contains(a.FORMAT)
                            && radCheckedDropDownList2.CheckedItems.Select(p => p.Value).ToList().Contains(a.COMP)
                            && a.DATE_E >= d.ADATE && a.DATE_E <= d.DDATE.Value
                            && a.FILE_YYMM == textBoxYYMM.Text
                            && a.SEQ == textBoxSEQ.Text
                            && f.FORMAL//20180118台光只抓正式員工
                            && MainForm.WriteDataGroups.Contains(a.SALADR)
                            select new { a.NOBR, d.TTSCODE, a.ADATE, a.YYMM, a.SEQ, a.COMP, a.FORMAT, a.NOTE, b.COUNT_MA, a.SALADR }).ToList();
            var WagedData = (from a in db.WAGE
                             join b in db.WAGED on new { a.NOBR, a.YYMM, a.SEQ } equals new { b.NOBR, b.YYMM, b.SEQ }
                             join c in db.SALCODE on b.SAL_CODE equals c.SAL_CODE
                             join d in db.SALATTR on c.SAL_ATTR equals d.SALATTR1
                             //join f in db.BASETTS on a.NOBR equals f.NOBR
                             where mdEmp.SelectedValues.Contains(a.NOBR)
                             && radCheckedDropDownList1.CheckedItems.Select(p => p.Value).ToList().Contains(a.FORMAT)
                             && radCheckedDropDownList2.CheckedItems.Select(p => p.Value).ToList().Contains(a.COMP)
                             && a.FILE_YYMM == textBoxYYMM.Text
                             && a.SEQ == textBoxSEQ.Text
                             && MainForm.WriteDataGroups.Contains(a.SALADR)
                             && (d.TAX || b.SAL_CODE == TaxSalcode || b.SAL_CODE == RetSalcode)
                             select new { a.NOBR, a.YYMM, a.SEQ, b.SAL_CODE, d.TAX, FullAmt = b.AMT, AMT = d.FLAG != "-" ? b.AMT : b.AMT * -1 }).ToList();
            var WagedData1 = (from a in WagedData
                              select new { a.NOBR, a.YYMM, a.SEQ, a.SAL_CODE, a.TAX, FullAmt = JBModule.Data.CDecryp.Number(a.FullAmt), AMT = JBModule.Data.CDecryp.Number(a.AMT) }).ToList();
            //var EmpDataTax = (from a in db.BASETTS
            //                  where mdEmp.SelectedValues.Contains(a.NOBR)
            //select new { a.NOBR, a.STDT, a.OUDT, a.TAX_DATE, a.TAX_EDATE }).ToList();
            foreach (var it in WageData)
            {
                var WagedOfYYMMSEQ = WagedData1.Where(p => p.NOBR.Trim() == it.NOBR.Trim() && p.YYMM.Trim() == it.YYMM.Trim() && p.SEQ.Trim() == it.SEQ.Trim());
                var TotalTaxableAmt = WagedOfYYMMSEQ.Where(p => p.TAX).Sum(p => p.AMT);
                var TaxAmt = WagedOfYYMMSEQ.Where(p => p.SAL_CODE.Trim() == TaxSalcode.Trim()).Sum(p => p.FullAmt);
                var RetAmt = WagedOfYYMMSEQ.Where(p => p.SAL_CODE.Trim() == RetSalcode.Trim()).Sum(p => p.FullAmt);
                JBModule.Data.Linq.TW_TAX_ITEM item = new JBModule.Data.Linq.TW_TAX_ITEM
                {
                    AMT = JBModule.Data.CEncrypt.Number(TotalTaxableAmt),
                    COMP = it.COMP,
                    D_AMT = JBModule.Data.CEncrypt.Number(TaxAmt),
                    FORMAT = it.FORMAT,
                    FORSUB = "",
                    IMPORT = true,
                    INA_ID = "",
                    IS_FILE = false,
                    KEY_DATE = DateTime.Now,
                    KEY_MAN = MainForm.USER_NAME,
                    MEMO = it.NOTE,
                    NOBR = it.NOBR,
                    PID = TW_TAX_Auto,
                    SAL_CODE = "薪資轉入",
                    SEQ = it.SEQ,
                    SUBCODE = 0,
                    SUP_AMT = 0,
                    TAXNO = "",
                    TR_TYPE = it.SALADR,
                    YYMM = it.YYMM,
                    RET_AMT = JBModule.Data.CEncrypt.Number(RetAmt),
                };

                db.TW_TAX_ITEM.InsertOnSubmit(item);
            }
            db.SubmitChanges();
            var WageDataWelfare = (from a in db.WAGE
                                   join b in db.U_SYS1 on 1 equals 1
                                   join c in db.COMP on b.COMPID1 equals c.COMPID
                                   join x in db.BASETTS on a.NOBR equals x.NOBR
                                   join d in db.BASETTS on a.NOBR equals d.NOBR
                                   join f in db.EMPCD on d.EMPCD equals f.EMPCD1
                                   where mdEmp.SelectedValues.Contains(a.NOBR)
                                   && radCheckedDropDownList1.CheckedItems.Select(p => p.Value.ToString().Trim()).ToList().Contains("92")
                                   && radCheckedDropDownList2.CheckedItems.Select(p => p.Value.ToString().Trim()).ToList().Contains(c.COMP1.Trim())
                                   && a.FILE_YYMM == textBoxYYMM.Text
                                   && a.SEQ == textBoxSEQ.Text
                                   && c.COMPID.Trim().Length > 0
                                   && a.DATE_E >= d.ADATE && a.DATE_E <= d.DDATE.Value
                                   && f.FORMAL//20180118台光只抓正式員工
                                   && MainForm.WriteDataGroups.Contains(a.SALADR)
                                   select new { a.NOBR, a.YYMM, a.SEQ, c.COMPID, a.ADATE, a.NOTE, a.SALADR }).ToList();
            var WagedDataWelfare = (from a in db.WAGE
                                    join b in db.WAGED on new { a.NOBR, a.YYMM, a.SEQ } equals new { b.NOBR, b.YYMM, b.SEQ }
                                    join c in db.SALCODE on b.SAL_CODE equals c.SAL_CODE
                                    join d in db.SALATTR on c.SAL_ATTR equals d.SALATTR1
                                    join b1 in db.U_SYS1 on 1 equals 1
                                    join c1 in db.COMP on b1.COMPID1 equals c1.COMPID
                                    //join x in db.BASETTS on a.NOBR equals x.NOBR
                                    where mdEmp.SelectedValues.Contains(a.NOBR)
                                    && radCheckedDropDownList1.CheckedItems.Select(p => p.Value.ToString().Trim()).ToList().Contains("92")
                                    && radCheckedDropDownList2.CheckedItems.Select(p => p.Value.ToString().Trim()).ToList().Contains(c1.COMP1.Trim())
                                    && a.YYMM == textBoxYYMM.Text
                                    && a.SEQ == textBoxSEQ.Text
                                    && MainForm.WriteDataGroups.Contains(a.SALADR)
                                    && (b.SAL_CODE == WelSalcode)
                                    select new { a.NOBR, a.YYMM, a.SEQ, b.SAL_CODE, d.TAX, FullAmt = b.AMT, AMT = d.FLAG != "-" ? b.AMT : b.AMT * -1 }).ToList();
            var WagedDataWelfare1 = (from a in WagedDataWelfare
                                     select new { a.NOBR, a.YYMM, a.SEQ, a.SAL_CODE, a.TAX, FullAmt = JBModule.Data.CDecryp.Number(a.FullAmt), AMT = JBModule.Data.CDecryp.Number(a.AMT) }).ToList();
            var forsubData = db.TW_TAX_SUBCODE.Where(p => p.M_FORMAT == "92").ToList();
            var forsub = forsubData.SingleOrDefault(p => p.M_FORSUB.Trim() == "8A");
            var WelComp = db.COMP.SingleOrDefault(p => p.COMPID == Sal.Core.SysVar.CompanyVar.COMPID1);
            if (WelComp != null)
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
                        NOBR = it.NOBR,
                        PID = TW_TAX_Auto,
                        SAL_CODE = "薪資福利金轉入",
                        SEQ = it.SEQ,
                        SUBCODE = 0,
                        SUP_AMT = 0,
                        TAXNO = "",
                        TR_TYPE = "",
                        YYMM = it.YYMM,
                        RET_AMT = JBModule.Data.CEncrypt.Number(RetAmt),
                    };
                    if (forsub != null) item.SUBCODE = forsub.AUTO;
                    db.TW_TAX_ITEM.InsertOnSubmit(item);
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
