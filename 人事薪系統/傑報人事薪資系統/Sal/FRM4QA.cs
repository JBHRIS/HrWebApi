using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class FRM4QA : JBControls.JBForm
    {
        public FRM4QA()
        {
            InitializeComponent();
        }

        private void FRM4QA_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbxSalcode, CodeFunction.GetSalCode(), false);
            var deptData = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(ptxDeptB, deptData, false);
            SystemFunction.SetComboBoxItems(ptxDeptE, deptData, false);
            var compData = CodeFunction.GetComp();
            SystemFunction.SetComboBoxItems(cbxCompB, compData, false);
            SystemFunction.SetComboBoxItems(cbxCompE, compData, false);
            var empData = CodeFunction.GetEmpcd();
            SystemFunction.SetComboBoxItems(cbxEmpB, empData, false);
            SystemFunction.SetComboBoxItems(cbxEmpE, empData, false);
            this.fRM4P_PRINTTYPETableAdapter.Fill(this.viewDS.FRM4P_PRINTTYPE);
            //this.eMPCDTableAdapter.Fill(this.baseDS.EMPCD);
            //this.cOMPTableAdapter.Fill(this.baseDS.COMP);
            //this.dEPTTableAdapter.Fill(this.baseDS.DEPT);
            this.bASETableAdapter.Fill(this.salaryDS.BASE);
            //this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);


            txtYear.Text = Function.GetYear();
            txtMonth.Text = Function.GetMonth();
            txtSeq.Text = "2";
            ptxNobrB.Text = this.salaryDS.BASE.FirstOrDefault().NOBR;
            ptxNobrE.Text = this.salaryDS.BASE.LastOrDefault().NOBR;
            ptxDeptB.SelectedValue = deptData.First().Key;
            ptxDeptE.SelectedValue = deptData.Last().Key;
            cbxCompB.SelectedValue = compData.First().Key;
            cbxCompE.SelectedValue = compData.Last().Key;
            cbxEmpB.SelectedValue = empData.First().Key;
            cbxEmpE.SelectedValue = empData.Last().Key;
            txtRate.Text = "1";
            SetDate(txtYear.Text);
            txtDivDays.Text = "365";
        }
        void SetDate(string year)
        {
            int iYear = int.Parse(year);
            DateTime firstDate = new DateTime(iYear, 1, 1);
            DateTime lastDate = new DateTime(iYear, 12, 31);

            string sDate = Function.GetDate(lastDate);
            txtServDateB.Text = Function.GetDate(firstDate); ;
            txtServDateE.Text = sDate;
            txtInDate.Text = sDate;
            txtDDate.Text = sDate;
            txtSalaryDDate.Text = Function.GetDate(DateTime.Now.Date);
            //CalcTotalDays();
        }
        void CalcTotalDays()
        {
            try
            {
                int days = Function.GetTotalDays(Convert.ToDateTime(txtServDateB.Text), Convert.ToDateTime(txtServDateE.Text));
                txtDivDays.Text = days.ToString();
            }
            catch
            {
                txtDivDays.Text = "0";
            }
        }
        private void txtYear_Validated(object sender, EventArgs e)
        {
            SetDate(txtYear.Text);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (rdbDataType2.Checked)
                if (MessageBox.Show(Resources.Sal.ActionConfirm + btnRun.Text + "?", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != DialogResult.OK) return;

            if (cbxSalcode.SelectedValue.ToString() == "") return;

            string nobr_b, nobr_e, dept_b, dept_e, comp_b, comp_e, empcd_b, empcd_e, seq, year, month, yymm;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.SelectedValue.ToString();
            dept_e = ptxDeptE.SelectedValue.ToString();
            comp_b = cbxCompB.SelectedValue.ToString();
            comp_e = cbxCompE.SelectedValue.ToString();
            empcd_b = cbxEmpB.SelectedValue.ToString();
            empcd_e = cbxEmpE.SelectedValue.ToString();
            seq = txtSeq.Text;
            year = txtYear.Text;
            month = txtMonth.Text;
            yymm = year + month;


            DateTime ServDateB, ServDateE, InDate, DDate, SalaryDDate;
            ServDateB = Convert.ToDateTime(txtServDateB.Text);
            ServDateE = Convert.ToDateTime(txtServDateE.Text);
            InDate = Convert.ToDateTime(txtInDate.Text);
            DDate = Convert.ToDateTime(txtDDate.Text);
            SalaryDDate = Convert.ToDateTime(txtSalaryDDate.Text);

            decimal DivDay = Convert.ToDecimal(txtDivDays.Text);
            decimal ServeDay = Function.GetTotalDays(ServDateB, ServDateE);
            decimal amtRate = 0;
            bool isOK = decimal.TryParse(txtRate.Text, out amtRate);

            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");

            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            //在職資料
            var sql = from bs in db.BASE
                      join bt in db.BASETTS on bs.NOBR equals bt.NOBR
                      join c in db.BASETTS on bs.NOBR equals c.NOBR into BASETTSs
                      join d in db.DEPTS on bt.DEPTS equals d.D_NO
                      join f in db.DEPT on bt.DEPT equals f.D_NO
                      where DDate >= bt.ADATE && DDate <= bt.DDATE//異動資料參考[@異動日期]的時間
                      && bs.NOBR.CompareTo(nobr_b) >= 0 && bs.NOBR.CompareTo(nobr_e) <= 0//工號範圍
                      && f.D_NO_DISP.CompareTo(dept_b) >= 0 && f.D_NO_DISP.CompareTo(dept_e) <= 0//部門範圍
                      && bt.COMP.CompareTo(comp_b) >= 0 && bt.COMP.CompareTo(comp_e) <= 0//公司別範圍
                      && bt.EMPCD.CompareTo(empcd_b) >= 0 && bt.EMPCD.CompareTo(empcd_e) <= 0//員別範圍
                      && bt.INDT <= InDate//到職日必須小於等於[@到職日]
                      && ttscodeList.Contains(bt.TTSCODE)//在職
                      && !bs.COUNT_MA && !bt.NOSPAMT//非外勞&異動資料沒有勾選不計三節獎金
                      //&& db.GetFilterByNobr(bs.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bt.SALADR)
                      //&& ttscodeList.Contains(basetts.TTSCODE)
                      select new
                      {
                          bs.NOBR,
                          bs.NAME_C,
                          bs.COUNT_MA,
                          bt.TTSCODE,
                          bt.ADATE,
                          INDT = bt.CINDT,
                          DEPT=f.D_NO_DISP,
                          DEPT_NAME = f.D_NAME,
                          bt.DI,
                          bt.ROTET,
                          DEPTS_CODE = d.D_NO_DISP,
                          DEPTS_NAME = d.D_NAME,
                          DeptsName = d.D_NAME,
                          //r,
                          //TotalDays = 0,//BASETTSs.Sum(p => Function.GetTotalDays((ServDateB > p.ADATE ? ServDateB : p.ADATE), ServDateE < p.DDATE.Value ? ServDateE : p.DDATE.Value)),
                          BASETTSs = BASETTSs.Select(p => new { p.ADATE, p.DDATE, p.TTSCODE })
                      };
            //薪資資料
            var salbasdSQL = (from a in db.SALBASD
                              join c in db.SALCODE on a.SAL_CODE equals c.SAL_CODE
                              join d in db.BASE on a.NOBR equals d.NOBR
                              join b in db.BASETTS on a.NOBR equals b.NOBR
                              where SalaryDDate >= a.ADATE && SalaryDDate <= a.DDATE
                              && DDate >= b.ADATE && DDate <= b.DDATE.Value
                              && c.YEARPAY
                              && !b.NOSPAMT
                              && !d.COUNT_MA
                              && ttscodeList.Contains(b.TTSCODE)
                              select new { a.NOBR, a.ADATE, a.DDATE, a.AMT }).ToList();
            var salcodeData = from a in db.SALCODE where a.SAL_CODE == cbxSalcode.SelectedValue.ToString() select a;
            var salcodeRow = salcodeData.First();
           
            string TaxSalcode = MainForm.TaxConfig.TAXSALCODE;
            decimal TaxRate = 0.00M;
            var salcodeSQL = from a in db.SALCODE where a.SAL_CODE == cbxSalcode.SelectedValue.ToString() && a.TAXRATE > 0 select a;
            if (salcodeSQL.Any())
                TaxRate = salcodeSQL.First().TAXRATE;
            //decimal maxTaxAmt = 0;
            var taxlvlSQL = from a in db.TAXLVL where a.YEAR == db.TAXLVL.Max(p => p.YEAR) && a.PER0 > 0 orderby a.AMT_L select a.AMT_L;
            var taxFreeMax = taxlvlSQL.First();

            List<JBModule.Data.Linq.ENRICH> enrichList = new List<JBModule.Data.Linq.ENRICH>();
            viewDS.YEAR_AWARD.Clear();
            foreach (var itm in sql)
            {
                ViewDS.YEAR_AWARDRow r = viewDS.YEAR_AWARD.NewYEAR_AWARDRow();
                r.NOBR = itm.NOBR;
                r.NAME_C = itm.NAME_C;
                r.SAL_CODE = salcodeRow.SAL_CODE_DISP;
                r.SAL_NAME = salcodeRow.SAL_NAME;

                decimal discountAmt = 0;
                //今年度在職天數
                decimal TotalDays = itm.BASETTSs.Where(p => ttscodeList.Contains(p.TTSCODE)).Sum(p => Function.GetTotalDays((ServDateB > p.ADATE ? ServDateB : p.ADATE), ServDateE < p.DDATE.Value ? ServDateE : p.DDATE.Value));
                ////今年度留停天數
                //decimal LeaveDays = itm.BASETTSs.Where(p => p.TTSCODE=="3").Sum(p => Function.GetTotalDays((ServDateB > p.ADATE ? ServDateB : p.ADATE), ServDateE < p.DDATE.Value ? ServDateE : p.DDATE.Value));
                //if (cbxSalcode.SelectedValue.ToString() == "B14")//遠東先進：扣回已發三節
                //{
                //    var wagedYearOfNobr = wagedYear.Where(p => p.NOBR == itm.NOBR);
                //    var enrichOfNobr = enrichSQL.Where(p => p.NOBR == itm.NOBR).ToList();
                //    discountAmt = wagedYearOfNobr.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                //    discountAmt += enrichOfNobr.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                //}
                //int TotalCount = 0, ErrCount = 0;
                var salbasdOfNobr = salbasdSQL.Where(p => p.NOBR == itm.NOBR);
                decimal salbasdAMT = salbasdOfNobr.Any() ? salbasdOfNobr.Sum(p => JBModule.Data.CDecryp.Number(p.AMT)) : 0;

                r.SALARY = salbasdAMT;
                decimal days = TotalDays;//< stopDays ? 0 : itm.TotalDays - stopDays;
                r.WORK_DAYS = days;
                r.TOTAL_DAYS = DivDay;
                r.RATE = amtRate;
                r.YYMM = yymm;
                if (days == 0) continue;//略過0
                decimal rate = days / DivDay;
                if (TotalDays == ServeDay) rate = 1;//如果這段區間相等，代表這是第二年度，且未留停，也非新進，所以給全部，
                if (rate > 1) rate = 1;//不可大於1
                decimal amt = Math.Round(salbasdAMT * rate * amtRate, MidpointRounding.AwayFromZero);
                if (amt == 0) continue;
                r.PAMT = amt;
                r.DISCOUNT = discountAmt;
                amt = amt - discountAmt;
                r.AMT = amt;
                r.TAX_AMT = 0;
                r.DEPTS = itm.DEPTS_CODE;
                r.DEPTS_NAME = itm.DeptsName;
                viewDS.YEAR_AWARD.AddYEAR_AWARDRow(r);



                JBModule.Data.Linq.ENRICH exp = new JBModule.Data.Linq.ENRICH();
                exp.FA_IDNO = "";
                exp.IMPORT = true;
                exp.KEY_DATE = DateTime.Now;
                exp.KEY_MAN = MainForm.USER_NAME;
                exp.MEMO = "";
                exp.NOBR = itm.NOBR;
                exp.SAL_CODE = cbxSalcode.SelectedValue.ToString();
                exp.SEQ = txtSeq.Text;
                exp.YYMM = txtYear.Text + txtMonth.Text;

                if (rdbDataType1.Checked)//如果是選擇轉報表，就顯示未加密資料
                {
                    if (cbxTaxCalc.Checked && taxFreeMax < amt)
                        r.TAX_AMT = Math.Round(amt * TaxRate, MidpointRounding.AwayFromZero);
                    exp.AMT = amt;
                    enrichList.Add(exp);
                }
                else
                {
                    var deleteSQL = from a in db.ENRICH
                                    where a.NOBR == exp.NOBR && a.IMPORT == exp.IMPORT
                                    && a.SAL_CODE == exp.SAL_CODE && a.YYMM == exp.YYMM
                                    && a.SEQ == exp.SEQ
                                    && db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                    select a;
                    db.ENRICH.DeleteAllOnSubmit(deleteSQL);//先刪除舊資料
                    exp.AMT = JBModule.Data.CEncrypt.Number(amt);//在寫入新資料
                    db.ENRICH.InsertOnSubmit(exp);

                    if (cbxTaxCalc.Checked)
                    {
                        exp = new JBModule.Data.Linq.ENRICH();
                        exp.FA_IDNO = "";
                        exp.IMPORT = true;
                        exp.KEY_DATE = DateTime.Now;
                        exp.KEY_MAN = MainForm.USER_NAME;
                        exp.MEMO = "";
                        exp.NOBR = itm.NOBR;
                        exp.SAL_CODE = TaxSalcode;
                        exp.SEQ = txtSeq.Text;
                        exp.YYMM = txtYear.Text + txtMonth.Text;
                        if (taxFreeMax < amt)
                            exp.AMT = JBModule.Data.CEncrypt.Number(Math.Round(amt * TaxRate, MidpointRounding.AwayFromZero));
                        else r.TAX_AMT = 10;
                        deleteSQL = from a in db.ENRICH where a.NOBR == exp.NOBR && a.IMPORT == exp.IMPORT && a.SAL_CODE == exp.SAL_CODE && a.YYMM == exp.YYMM && a.SEQ == exp.SEQ select a;
                        db.ENRICH.DeleteAllOnSubmit(deleteSQL);//先刪除舊資料

                        db.ENRICH.InsertOnSubmit(exp);//在寫入新資料
                    }

                    //try
                    //{
                    //    db.SubmitChanges();
                    //    TotalCount++;
                    //}
                    //catch
                    //{
                    //    ErrCount++;
                    //    exp.AMT = amt;
                    //    enrichList.Add(exp);//錯誤就將資料記錄下來
                    //}                   
                }
            }

            if (rdbDataType1.Checked)
            {
                PreviewForm vw = new PreviewForm();
                DataTable dt = null;
                dt = viewDS.YEAR_AWARD;
                foreach (DataColumn dc in viewDS.YEAR_AWARD.Columns)
                {
                    if (dt.Columns.Contains(dc.ColumnName))
                        dt.Columns[dc.ColumnName].ColumnName = dc.Caption;
                }
                if (dt.Rows.Count > 0)
                {
                    vw.DataTable = dt;
                    vw.Width += 500;
                    vw.Height += 200;
                    vw.ShowDialog();
                }
                else
                {
                    MessageBox.Show(Resources.Sal.NoDataCreated, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                db.SubmitChanges();
                MessageBox.Show(Resources.Sal.StatusFinish, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }



        }

        private void txtServDateB_Validated(object sender, EventArgs e)
        {
            //CalcTotalDays();
        }
    }
}
