using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal;
using JBHR.Sal.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JBHR.Sal
{
    public partial class FRM4I : JBControls.JBForm
    {
        public FRM4I()
        {
            InitializeComponent();
        }

        JBModule.Data.ApplicationConfigSettings acg = null;
        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog mdOT = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog mdABS = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.SALARYCALC sclc = new JBModule.Data.Linq.SALARYCALC();
        dynamic dyna = new JObject();
        private void FRM4I_Load(object sender, EventArgs e)
        {
            var deptData = CodeFunction.GetDeptDisp();

            SystemFunction.SetComboBoxItems(ptxDeptB, deptData, false);
            SystemFunction.SetComboBoxItems(ptxDeptE, deptData, false);
            var salData = CodeFunction.GetSalCode();
            SystemFunction.SetComboBoxItems(cbxFormat, CodeFunction.GetMtCode("YRFOMAT"), false);
            SystemFunction.SetComboBoxItems(cbxSalcodeB, salData, false);
            SystemFunction.SetComboBoxItems(cbxSalcodeE, salData, false);
            SystemFunction.CheckAppConfigRule(btnConfig);
            SystemFunction.CheckRule(btnReExpsup);
            acg = new JBModule.Data.ApplicationConfigSettings(this.Name, MainForm.COMPANY);
            acg.CheckParameterAndSetDefault("MinWageCode", "最低保障薪代碼", "", "指定最低保障薪的薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            acg.CheckParameterAndSetDefault("NoPayDeductionCode", "無薪假扣款代碼", "", "指定無薪假扣款的薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            acg.CheckParameterAndSetDefault("MinAmt", "基本工資金額", "21009", "設定基本工資金額", "TextBox", "", "Int");
            acg.CheckParameterAndSetDefault("TaxableFoodCode", "應稅伙食代碼", "", "指定應稅伙食的薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            acg.CheckParameterAndSetDefault("ForeignFoodAmt", "外籍伙食費", "2500", "指定外籍伙食費金額", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("ForeignFoodNuTaxMaxAmt", "外籍伙食費免稅額上限", "2400", "指定外籍伙食費免稅額上限", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("ForeignFoodNuAddAmt", "外籍伙食費回扣額", "100", "指定外籍伙食費回扣額", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("ForeignFoodRotet", "外籍伙食費之輪班別", "F3a,F3b,F3c,F5a,F5b,F5c", "指定外籍伙食費之輪班別，以「,」做分隔。", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("ForeignFoodSalcode", "外籍伙食費之免稅薪資代碼", "G01", "指定籍伙食費之免稅薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            acg.CheckParameterAndSetDefault("ForeignFoodSalcodeTax", "外籍伙食費之應稅薪資代碼", "G02", "指定外籍伙食費之應稅薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            acg.CheckParameterAndSetDefault("AwardDiscount", "績效獎金代碼", "", "指定績效獎金代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            acg.CheckParameterAndSetDefault("SaldivOT", "節金薪資代碼", "", "指定節金薪資代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            acg.CheckParameterAndSetDefault("SaldivOTSEQ", "指定節金薪資期別", "3", "指定節金薪資期別", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("AwardDiscount", "績效獎金代碼", "", "指定績效獎金代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            acg.CheckParameterAndSetDefault("PTWkHrsIncludeOt", "時薪總工時是否含加班", "False", "True:含加班(加班比率需設0) False:不含加班(加班另外算)", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
            acg.CheckParameterAndSetDefault("TransDate", "轉帳日", "5", "轉帳日設定", "TextBox", "", "Int");
            acg.CheckParameterAndSetDefault("InEndDate", "到職截止日", "28", "到職截止日設定", "TextBox", "", "Int");
            acg.CheckParameterAndSetDefault("TransDateNextMonth", "次月轉帳", "Y", "轉帳日設定", "TextBox", "", "Int");
            acg.CheckParameterAndSetDefault("InEndDateNextMonth", "次月到職截止日", "N", "次月到職截止日設定", "TextBox", "", "Int");
            acg.CheckParameterAndSetDefault("DeductWage", "已發扣回代碼", "", "指定已發扣回代碼來回沖借支", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            acg.CheckParameterAndSetDefault("PersonMaxOT_hrs", "加班工時以節金時數計", "False", "False:加班工時以法定工時(46)小時數計 True:加班工時節金時數計", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");

            //    acg.CheckParameterAndSetDefault("SalNonFrqSEQ", "非經常性薪資期別", "", "指定非經常性薪資期別", "TextBox", "", "String");
            //acg.CheckParameterAndSetDefault("AbsCode", "曠職代碼", "", "指定曠職代碼來判斷曠職不給全勤", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1", "String");
            //this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.dEPTTableAdapter.Fill(this.baseDS.DEPT);
            Function.SetAvaliableBase(this.salaryDS.BASE);
            this.fRM4ITYPETableAdapter.Fill(this.viewDS.FRM4ITYPE);
            SalaryDate sd = new SalaryDate(DateTime.Now.Date, true);
            txtBdate.Text = Sal.Core.SalaryDate.DateString(sd.FirstDayOfSalary);
            txtEdate.Text = Sal.Core.SalaryDate.DateString(sd.LastDayOfSalary);
            DateTime date = DateTime.Now.Date;// sd.LastDayOfSalary;
            SetYYMM(date);
            //txtEdate.Text = Function.GetDate(date.AddMonths(1).AddDays(-1));
            txtSeq.Text = "2";
            txtSeq1.Text = "2";
            textBoxSEQ2.Text = "B";
            //DateTime dBank = new DateTime(sd.GetNextSalaryDate().FirstDayOfMonth.Year, sd.GetNextSalaryDate().FirstDayOfMonth.Month, 5);

            txtLeaveDateB.Text = txtBdate.Text;
            txtLeaveDateE.Text = txtEdate.Text;

            //txtBank.Text = Sal.Core.SalaryDate.DateString(dBank);

            ptxNobrB.Text = BaseValue.MinNobr;
            ptxNobrE.Text = BaseValue.MaxNobr;
            ptxDeptB.SelectedValue = deptData.First().Key;
            ptxDeptE.SelectedValue = deptData.Last().Key;
            cbxFormat.SelectedValue = "50";
            cbxSalcodeB.SelectedValue = salData.First().Key;
            cbxSalcodeE.SelectedValue = salData.Last().Key;
            //DateTime dIndt = new DateTime(sd.FirstDayOfMonth.Year, sd.FirstDayOfMonth.Month, 28);
            //txtInEndDate.Text = Function.GetDate(dIndt);
            SetLeaveEmp();
        }

        void SetYYMM(DateTime date)
        {
            SalaryDate sd = new SalaryDate(date, true);
            txtYymm.Text = sd.YYMM;//SalaryYYMM;
            txtYymm1.Text = sd.YYMM;//SalaryYYMM;
            txtChgYymm.Text = sd.YYMM;//SalaryYYMM;
            txtRpYYMM.Text = sd.YYMM;//SalaryYYMM;
            //txtBdate.Text = Sal.Core.SalaryDate.DateString(sd.FirstDayOfSalary);
            //txtEdate.Text = Sal.Core.SalaryDate.DateString(sd.LastDayOfSalary);
            txtAttDateB.Text = Sal.Core.SalaryDate.DateString(sd.FirstDayOfAttend);
            txtAttDateE.Text = Sal.Core.SalaryDate.DateString(sd.LastDayOfAttend);

            txtRpYYMMB.Text = Sal.Core.SalaryDate.DateString(sd.FirstDayOfAttend);
            txtRpYYMME.Text = Sal.Core.SalaryDate.DateString(sd.LastDayOfAttend);

            txtChgSeq.Text = "2";
            date = sd.LastDayOfSalary;
            int TransDay = acg.GetConfig("TransDate").GetInter(5);
            bool IsNextMonth = acg.GetConfig("TransDateNextMonth").GetString("Y") == "Y";
            DateTime NextMonth = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
            if (IsNextMonth)
                NextMonth = new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(-1);
            DateTime dBank = NextMonth.Day < TransDay ? NextMonth : new DateTime(NextMonth.Year, NextMonth.Month, TransDay);
            //if (dBank.DayOfWeek == DayOfWeek.Sunday) dBank = dBank.AddDays(-1);
            txtBank.Text = Sal.Core.SalaryDate.DateString(dBank);
            int InEndDate = acg.GetConfig("InEndDate").GetInter(28);
            bool IsNextMonthInEnd = acg.GetConfig("InEndDateNextMonth").GetString("Y") == "Y";
            DateTime NextMonthInEnd = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
            if (IsNextMonthInEnd)
                NextMonthInEnd = new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(-1);
            DateTime dIndt = NextMonthInEnd.Day < InEndDate ? NextMonthInEnd : new DateTime(NextMonthInEnd.Year, NextMonthInEnd.Month, InEndDate);
            //DateTime dIndt = new DateTime(sd.FirstDayOfMonth.Year, sd.FirstDayOfMonth.Month, InEndDate);
            txtInEndDate.Text = Function.GetDate(dIndt);
        }

        void SetLeaveEmp()
        {
            if (checkBox1.Checked)
            {
                DateTime Bdate = Convert.ToDateTime(txtBdate.Text);
                DateTime Edate = Convert.ToDateTime(txtEdate.Text);
                DateTime AttDateB = Convert.ToDateTime(txtAttDateB.Text);
                DateTime AttDateE = Convert.ToDateTime(txtAttDateE.Text);

                if (checkBox2.Checked)
                {
                    Bdate = Convert.ToDateTime(txtLeaveDateB.Text);
                    Edate = Convert.ToDateTime(txtLeaveDateE.Text);
                }

                var dtEmp = Repo.EmpRepo.GetLeaveEmp1WithDept(Bdate, Edate, AttDateB, AttDateE);
                mdEmp.SetControl(buttonLeaveEmp, dtEmp, "員工編號");
                mdEmp.FormClosed -= MdEmp_FormClosed;
                mdEmp.FormClosed += MdEmp_FormClosed;
                buttonLeaveEmp.Text = "選取 " + mdEmp.SelectedValues.Count.ToString() + " 名離職員工";
                setOTandABS(); 
            }
        }

        private void MdEmp_FormClosed(object sender, FormClosedEventArgs e)
        {
            setOTandABS();
        }

        void setOTandABS()
        {
            if (checkBox3.Checked)
            {
                DateTime Bdate = Convert.ToDateTime(txtRpYYMMB.Text);
                DateTime Edate = Convert.ToDateTime(txtRpYYMME.Text);
                string yymm = txtRpYYMM.Text;
                var dtOT = Repo.EmpRepo.GetOTwithDateYYMM(mdEmp.SelectedValues, Bdate, Edate, yymm);
                mdOT.SetControl(btnOTData, dtOT, "備註");
                btnOTData.Text = "影響 " + mdOT.SelectedValues.Count.ToString() + " 筆加班資料";

                var dtABS = Repo.EmpRepo.GetABSwithDateYYMM(mdEmp.SelectedValues, Bdate, Edate, yymm);
                mdABS.SetControl(btnABSData, dtABS, "備註");
                btnABSData.Text = "影響 " + mdABS.SelectedValues.Count.ToString() + " 筆請假資料"; 
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行薪資計算作業?", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel) return;
            acg = new JBModule.Data.ApplicationConfigSettings(this.Name, MainForm.COMPANY);
            string nobr_b = ptxNobrB.Text;
            string nobr_e = ptxNobrE.Text;
            string dept_b = ptxDeptB.SelectedValue.ToString();
            string dept_e = ptxDeptE.SelectedValue.ToString();
            string seq = txtSeq.Text;
            string yymm = txtYymm.Text;
            string type = cbxFormat.SelectedValue.ToString();
            DateTime d1 = Convert.ToDateTime(txtBdate.Text);
            DateTime d2 = Convert.ToDateTime(txtEdate.Text);
            DateTime a1 = Convert.ToDateTime(txtAttDateB.Text);
            DateTime a2 = Convert.ToDateTime(txtAttDateE.Text);
            DateTime transDate = Convert.ToDateTime(txtBank.Text);
            DateTime inEdate = Convert.ToDateTime(txtInEndDate.Text);
            bool Prev = chkPrev.Checked;
            //SalaryDate sd = new SalaryDate((DateTime.Now.Date));

            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.WAGE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.LOCK_WAGE on new { a.YYMM, a.SEQ, a.SALADR } equals new { c.YYMM, c.SEQ, c.SALADR }
                      join d in db.DEPT on b.DEPT equals d.D_NO
                      where a.YYMM == yymm && a.SEQ == seq
                      && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                       && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                      && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select a;
            if (sql.Any())//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            db.Log = new DebuggerWriter();
            DateTime DT = DateTime.Now;
            sclc = new JBModule.Data.Linq.SALARYCALC();
            sclc.GUID = Guid.NewGuid();
            sclc.USERID = MainForm.USER_ID;
            sclc.TIMEB = DT;
            sclc.SOURCE = this.Name;
            db.SALARYCALC.InsertOnSubmit(sclc);
            db.SubmitChanges();

            dyna.prgname = this.Name;
            dyna.userid = MainForm.USER_ID;
            dyna.key_date = DT;
            dyna.guid = sclc.GUID;

            GenerateEmpRuleList(db, sclc.GUID);

            SalaryCalculation sc = new SalaryCalculation
                    (yymm, seq, nobr_b, nobr_e, dept_b, dept_e, d1, d2, a1, a2, transDate, "MainForm.WORKADR", false, false, type, Prev, inEdate);
            sc.guid = sclc.GUID;
            sc.dyna = dyna;
            //if (checkBoxSEQ2.Checked)
            //{
            sc.SEQ2 = textBoxSEQ2.Text;
            sc.IsCalcB = checkBoxSEQ2.Checked;
            //}

            if (checkBox1.Checked)//計算離職人員薪資
            {
                DateTime t1 = Convert.ToDateTime(txtRpYYMMB.Text);
                DateTime t2 = Convert.ToDateTime(txtRpYYMME.Text);
                t1 = DateTime.Now;
                this.panel1.Enabled = false;
                if (checkBox3.Checked)
                {
                    toolStripProgressBar1.Value = 0;
                    trpState.Text = "開始置換計薪年月...";

                    var ABSsql = (from abs in db.ABS
                                 join att in db.ATTEND on new { abs.NOBR, ADATE = abs.BDATE } equals new { att.NOBR, att.ADATE }
                                 where mdABS.SelectedValues.Contains(abs.NOBR + "," + abs.BDATE + "," + abs.BTIME + "," + abs.H_CODE)
                                 //where ab.NOBR == it && ab.BDATE >= t1 && ab.BDATE <= t2 && ab.YYMM.CompareTo(yymm) > 0
                                 select abs).ToList();
                    var OTSql = (from ot in db.OT
                                join att in db.ATTEND on new { ot.NOBR, ADATE = ot.BDATE } equals new { att.NOBR, att.ADATE }
                                where mdOT.SelectedValues.Contains(ot.NOBR + "," + ot.BDATE + "," + ot.BTIME)
                                //where ot.NOBR == it && ot.BDATE >= t1 && ot.BDATE <= t2 && ot.YYMM.CompareTo(yymm) > 0
                                select ot).ToList();

                    foreach (var abs in ABSsql)
                    {
                        abs.YYMM = txtRpYYMM.Text.ToString();
                        abs.KEY_MAN = MainForm.USER_NAME;
                        abs.KEY_DATE = DateTime.Now;
                    }

                    foreach (var ot in OTSql)
                    {
                        ot.YYMM = txtRpYYMM.Text.ToString();
                        ot.KEY_MAN = MainForm.USER_NAME;
                        ot.KEY_DATE = DateTime.Now;
                    }

                    db.SubmitChanges();
                }

                LeaveEmpParams LEP = new LeaveEmpParams();
                LEP.seq = seq;
                LEP.yymm = yymm;
                LEP.type = type;
                LEP.d1 = d1;
                LEP.d2 = d2;
                LEP.a1 = a1;
                LEP.a2 = a2;
                LEP.transDate = transDate;
                LEP.inEdate = inEdate;
                LEP.Prev = Prev;
                LEP.EMP = mdEmp.SelectedValues;

                BW_Out.RunWorkerAsync(LEP);
            }
            else
            {
                if (!chkPrev.Checked)
                {
                    var noWageList = sc.PreviousMonthNoWage();
                    if (noWageList.Any())
                    {
                        if (MessageBox.Show("檢查到有" + noWageList.Count().ToString() + "位員工有上期未計算之薪資，是否繼續?選[是]繼續，選[否]取消並顯示人員名單", Resources.All.DialogTitle,
                             MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
                        {
                            PreviewForm frm = new PreviewForm();
                            frm.DataTable = noWageList.Select(p => new { 員工編號 = p.Key, 員工姓名 = p.Value }).CopyToDataTable();
                            frm.Form_Title = "上期未計薪人員";
                            frm.ShowDialog();
                            return;
                        }
                    }
                }

                JBModule.Data.Repo.SalCalcBeforeInspectionRuleCondition cond = new JBModule.Data.Repo.SalCalcBeforeInspectionRuleCondition();
                cond.Parameters = new Dictionary<string, object>();
                cond.Parameters.Add("Nobr_B", nobr_b);
                cond.Parameters.Add("Nobr_E", nobr_e);
                cond.Parameters.Add("Dept_B", dept_b);
                cond.Parameters.Add("Dept_E", dept_e);
                cond.Parameters.Add("SEQ", seq);
                cond.Parameters.Add("YYMM", yymm);
                cond.Parameters.Add("Type", type);
                cond.Parameters.Add("Bdate", d1);
                cond.Parameters.Add("Edate", d2);
                cond.Parameters.Add("AttDateB", a1);
                cond.Parameters.Add("AttDateE", a2);
                cond.Parameters.Add("TransDate", transDate);
                cond.Parameters.Add("InEdate", inEdate);
                cond.Parameters.Add("User_ID", MainForm.USER_ID);
                cond.Parameters.Add("Company", MainForm.COMPANY);
                cond.Parameters.Add("Admin", MainForm.ADMIN);
                var ParamsList = db.AppConfig.Where(p => p.Category == "CheckSalCalcBeforeParams").Select(p => new { p.Code, p.Value }).ToList();
                foreach (var Parameter in ParamsList)
                    cond.Parameters.Add(Parameter.Code, Parameter.Value);

                var moduleList = db.AppConfig.Where(p => p.Category == "CheckSalCalcBeforeRule").OrderBy(p => p.Sort);
                List<JBModule.Data.Repo.ISalCalcBeforeCheckRule> CheckRuleList = new List<JBModule.Data.Repo.ISalCalcBeforeCheckRule>();
                foreach (var module in moduleList)
                {
                    var sourceDir = string.IsNullOrWhiteSpace(module.DataSource) ? AppDomain.CurrentDomain.BaseDirectory : module.DataSource;
                    var asmConcrete = Assembly.LoadFrom(sourceDir + module.DataType);
                    var typeClass = asmConcrete.GetType(module.Value);
                    var instance = asmConcrete.CreateInstance(module.Value) as JBModule.Data.Repo.ISalCalcBeforeCheckRule;
                    if (module.ControlType == "SqlFuction")
                    {
                        instance.Parameters = cond.Parameters.Clone();
                        instance.Parameters.Add("SqlFuction", module.Note);
                        instance.Parameters.Add("TableName", module.NameP);
                    }
                    CheckRuleList.Add(instance);
                }
                cond.CheckRuleList.AddRange(CheckRuleList);
                JBModule.Data.Repo.SalCalcBeforeInspectionRuleRepo SalCalcBeforeRepo = new JBModule.Data.Repo.SalCalcBeforeInspectionRuleRepo(cond);
                List<DataTable> dataTables = new List<DataTable>();
                dataTables = SalCalcBeforeRepo.CheckSalCalcBeforeInspectionRule();
                if (dataTables.Count > 0)
                {
                    foreach (var dataTable in dataTables)
                    {
                        if (dataTable.Rows.Count > 0 && MessageBox.Show("檢查到有" + dataTable.TableName + "的檢核有異常，是否繼續?選[是]繼續，選[否]取消並顯示名單", Resources.All.DialogTitle,
                              MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
                        {
                            PreviewForm frm = new PreviewForm();
                            frm.DataTable = dataTable;
                            frm.Form_Title = dataTable.TableName;
                            frm.ShowDialog();
                            return;
                        } 
                    }
                }

                this.panel1.Enabled = false;
                BW.RunWorkerAsync(sc);
            }
        }
        private void txtBdate_Validated(object sender, EventArgs e)
        {
            DateTime bdate = DateTime.Parse(txtBdate.Text);
            txtEdate.Text = Function.GetDate(bdate.AddMonths(1).AddDays(-1));
            //DateTime splitDate = new DateTime(bdate.Year, bdate.Month, MainForm.SalaryConfig.SALMONTH.Value);
            //bdate = bdate.Date > splitDate ? bdate.AddMonths(1).AddDays(-1) : bdate;
            //SalaryDate sd = new SalaryDate(bdate);
            SetYYMM(bdate);
            txtLeaveDateB.Text = txtBdate.Text;
            txtLeaveDateE.Text = txtEdate.Text;
            SetLeaveEmp();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要刪除指定的發薪資料?", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel) return;
            DateTime t1, t2;
            t1 = DateTime.Now;

            string nobr_b = ptxNobrB.Text;
            string nobr_e = ptxNobrE.Text;
            string dept_b = ptxDeptB.SelectedValue.ToString();
            string dept_e = ptxDeptE.SelectedValue.ToString();
            string seq = txtSeq.Text;
            string yymm = txtYymm.Text;
            string type = cbxFormat.SelectedValue.ToString();
            DateTime d1 = Convert.ToDateTime(txtBdate.Text);
            DateTime d2 = Convert.ToDateTime(txtEdate.Text);
            DateTime a1 = Convert.ToDateTime(txtAttDateB.Text);
            DateTime a2 = Convert.ToDateTime(txtAttDateE.Text);
            DateTime transDate = Convert.ToDateTime(txtBank.Text);
            DateTime inEdate = Convert.ToDateTime(txtInEndDate.Text);
            bool Prev = chkPrev.Checked;
            //SalaryDate sd = new SalaryDate((DateTime.Now.Date));

            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.WAGE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.LOCK_WAGE on new { a.YYMM, a.SEQ, a.SALADR } equals new { c.YYMM, c.SEQ, c.SALADR }
                      join d in db.DEPT on b.DEPT equals d.D_NO
                      where a.YYMM == yymm && a.SEQ == seq
                      && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                       && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                      && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select a;
            if (sql.Any())//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            sclc = new JBModule.Data.Linq.SALARYCALC();
            sclc.GUID = Guid.NewGuid();
            sclc.USERID = MainForm.USER_ID;
            sclc.TIMEB = DateTime.Now;
            sclc.SOURCE = this.Name;
            db.SALARYCALC.InsertOnSubmit(sclc);
            db.SubmitChanges();

            //var sqlNobrTable = db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).ToList();
            //if (sqlNobrTable.Count > 0)
            //{
            //    foreach (var item in sqlNobrTable)
            //    {
            //        JBModule.Data.Linq.WriteRuleNobrTable WriteRuleTable = new JBModule.Data.Linq.WriteRuleNobrTable();
            //        WriteRuleTable.GUID = sclc.GUID;
            //        WriteRuleTable.EMPID = item.NOBR;
            //        WriteRuleTable.KEY_DATE = DateTime.Now;
            //        db.WriteRuleNobrTable.InsertOnSubmit(WriteRuleTable);
            //    }
            //    db.SubmitChanges();
            //}

            SalaryCalculation sc = new SalaryCalculation
                    (yymm, seq, nobr_b, nobr_e, dept_b, dept_e, d1, d2, a1, a2, transDate, "MainForm.WORKADR", false, false, type, Prev, inEdate);
            sc.guid = sclc.GUID;
            sc.DeleteAll();

            sclc = db.SALARYCALC.Where(p => p.GUID == sclc.GUID).FirstOrDefault();
            sclc.TIMEE = DateTime.Now;
            db.SubmitChanges();

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行薪資計算作業(由補扣發轉入)?", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel) return;
            DateTime t1, t2;
            t1 = DateTime.Now;

            string nobr_b = ptxNobrB.Text;
            string nobr_e = ptxNobrE.Text;
            string dept_b = ptxDeptB.SelectedValue.ToString();
            string dept_e = ptxDeptE.SelectedValue.ToString();
            string seq = txtSeq.Text;
            string yymm = txtYymm.Text;
            string type = cbxFormat.SelectedValue.ToString();
            DateTime d1 = Convert.ToDateTime(txtBdate.Text);
            DateTime d2 = Convert.ToDateTime(txtEdate.Text);
            DateTime a1 = Convert.ToDateTime(txtAttDateB.Text);
            DateTime a2 = Convert.ToDateTime(txtAttDateE.Text);
            DateTime transDate = Convert.ToDateTime(txtBank.Text);
            DateTime inEdate = Convert.ToDateTime(txtInEndDate.Text);
            bool Prev = chkPrev.Checked;
            //SalaryDate sd = new SalaryDate((DateTime.Now.Date));

            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.WAGE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.LOCK_WAGE on new { a.YYMM, a.SEQ, a.SALADR } equals new { c.YYMM, c.SEQ, c.SALADR }
                      join d in db.DEPT on b.DEPT equals d.D_NO
                      where a.YYMM == yymm && a.SEQ == seq
                      && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                       && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                      && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select a;
            if (sql.Any())//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            sclc = new JBModule.Data.Linq.SALARYCALC();
            sclc.GUID = Guid.NewGuid();
            sclc.USERID = MainForm.USER_ID;
            sclc.TIMEB = DateTime.Now;
            sclc.SOURCE = this.Name;
            db.SALARYCALC.InsertOnSubmit(sclc);
            db.SubmitChanges();

            GenerateEmpRuleList(db, sclc.GUID);

            SalaryCalculation sc = new SalaryCalculation
                    (yymm, seq, nobr_b, nobr_e, dept_b, dept_e, d1, d2, a1, a2, transDate, "MainForm.WORKADR", false, false, type, Prev, inEdate);
            sc.guid = sclc.GUID;
            sc.DeleteWaged();
            sc.DeleteWage();
            sc.ImportEnrich();
            sc.ImportSalEnrich();
            sc.CreateWage();
            sc.CreateExpSup();
            if (chkTax.Checked)
                sc.TaxCalc(false, yymm, seq); //薪資

            //            sc.TaxCalc(false,); //薪資
            if (chkTeco.Checked)
            {
                sc.TecoCalc();
                sc.ImportWagedd();
            }
            sc.WriteToDB();

            sclc = db.SALARYCALC.Where(p => p.GUID == sclc.GUID).FirstOrDefault();
            sclc.TIMEE = DateTime.Now;
            db.SubmitChanges();

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static void GenerateEmpRuleList(JBModule.Data.Linq.HrDBDataContext db,Guid guid)
        {
            //var sqlNobrTable = db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).ToList();
            //if (sqlNobrTable.Count > 0)
            //{
            //    foreach (var item in sqlNobrTable)
            //    {
            //        JBModule.Data.Linq.WriteRuleNobrTable WriteRuleTable = new JBModule.Data.Linq.WriteRuleNobrTable();
            //        WriteRuleTable.GUID = guid;
            //        WriteRuleTable.EMPID = item.NOBR;
            //        WriteRuleTable.KEY_DATE = DateTime.Now;
            //        db.WriteRuleNobrTable.InsertOnSubmit(WriteRuleTable);
            //    }
            //    db.SubmitChanges();
            //}
            db.ExecuteCommand("delete WriteRuleNobrTable where KEY_DATE <= DATEADD(DAY, -30,GETDATE())");
        }

        private void txtAttDateB_Validated(object sender, EventArgs e)
        {
            DateTime d1, d2;
            d1 = Convert.ToDateTime(txtAttDateB.Text);
            d2 = d1.AddMonths(1).AddDays(-1);
            txtAttDateE.Text = Sal.Core.SalaryDate.DateString(d2);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;

            string nobr_b = ptxNobrB.Text;
            string nobr_e = ptxNobrE.Text;
            string dept_b = ptxDeptB.Text;
            string dept_e = ptxDeptE.Text;
            string seq = txtSeq.Text;
            string yymm = txtYymm.Text;
            string type = cbxFormat.SelectedValue.ToString();
            DateTime d1 = Convert.ToDateTime(txtBdate.Text);
            DateTime d2 = Convert.ToDateTime(txtEdate.Text);
            DateTime a1 = Convert.ToDateTime(txtAttDateB.Text);
            DateTime a2 = Convert.ToDateTime(txtAttDateE.Text);
            DateTime transDate = Convert.ToDateTime(txtBank.Text);

            SalaryMDDataContext db = new SalaryMDDataContext();
            var sql = from a in db.WAGE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.DEPT on b.DEPT equals c.D_NO
                      //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == sclc.GUID) on a.NOBR equals wrnt.EMPID
                      where a.ADATE >= b.ADATE && a.ADATE <= b.DDATE.Value
                      && b.NOBR.CompareTo(nobr_b) >= 0 && b.NOBR.CompareTo(nobr_e) <= 0
                      && c.D_NO_DISP.CompareTo(dept_b) >= 0 && c.D_NO_DISP.CompareTo(dept_e) <= 0
                      && a.YYMM == yymm && a.SEQ == seq
                      //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      select a;

            foreach (var itm in sql)
            {
                itm.FORMAT = type;
            }
            db.SubmitChanges();

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;
            SalaryCalculation sc = (SalaryCalculation)e.Argument;
            sc.BW = BW;
            sc.Calc(chkTeco.Checked, true, chkAbs.Checked, chkOT.Checked, checkBoxIns.Checked, checkBoxNonfreq.Checked, chkExpSup.Checked);
            //if (chkReCalc.Checked)
            //    sc.Calc(chkTeco.Checked, false, chkAbs.Checked, chkOT.Checked);
            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            e.Result = msg;
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            trpState.Text = e.UserState.ToString();
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            panel1.Enabled = true;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            JBModule.Data.Linq.SALARYCALC sc = db.SALARYCALC.Where(p => p.GUID == sclc.GUID).FirstOrDefault();
            sc.TIMEE = DateTime.Now;
            db.SubmitChanges();
        }

        private void BW_Out_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;
            LeaveEmpParams LEP= (LeaveEmpParams)e.Argument;
            foreach (var it in LEP.EMP)
            {
                SalaryCalculation sc = new SalaryCalculation
                  (LEP.yymm, LEP.seq, it, it, "0", "ZZZZZZ", LEP.d1, LEP.d2, LEP.a1, LEP.a2, LEP.transDate, "MainForm.WORKADR", false, false, LEP.type, LEP.Prev, LEP.inEdate);
                sc.BW = BW_Out;
                sc.guid = sclc.GUID;
                sc.Calc(chkTeco.Checked, true, chkAbs.Checked, chkOT.Checked, checkBoxIns.Checked, checkBoxNonfreq.Checked ,chkExpSup.Checked);
            }

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            e.Result = msg;
        }

        private void BW_Out_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            trpState.Text = e.UserState.ToString();
        }

        private void BW_Out_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            panel1.Enabled = true;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            JBModule.Data.Linq.SALARYCALC sc = db.SALARYCALC.Where(p => p.GUID == sclc.GUID).FirstOrDefault();
            sc.TIMEE = DateTime.Now;
            db.SubmitChanges();
            setOTandABS();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nobr_b = ptxNobrB.Text;
            string nobr_e = ptxNobrE.Text;
            string dept_b = ptxDeptB.SelectedValue.ToString();
            string dept_e = ptxDeptE.SelectedValue.ToString();
            string seq = txtSeq.Text;
            string seq1 = txtSeq1.Text;
            string yymm = txtYymm.Text;
            string yymm1 = txtYymm1.Text;
            string type = cbxFormat.SelectedValue.ToString();
            string salcodeB = cbxSalcodeB.SelectedValue.ToString();
            string salcodeE = cbxSalcodeE.SelectedValue.ToString();
            DateTime d1 = Convert.ToDateTime(txtBdate.Text);
            DateTime d2 = Convert.ToDateTime(txtEdate.Text);
            DateTime a1 = Convert.ToDateTime(txtAttDateB.Text);
            DateTime a2 = Convert.ToDateTime(txtAttDateE.Text);
            DateTime transDate = Convert.ToDateTime(txtBank.Text);

            SalaryMDDataContext db = new SalaryMDDataContext();
            var sql = (from a in db.WAGE
                       join b in db.BASETTS on a.NOBR equals b.NOBR
                       join c in db.BASE on a.NOBR equals c.NOBR
                       join d in db.DEPT on b.DEPT equals d.D_NO
                       join j in db.JOB on b.JOB equals j.JOB1
                       join jl in db.JOBL on b.JOBL equals jl.JOBL1
                       //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == sclc.GUID) on a.NOBR equals wrnt.EMPID
                       where a.YYMM == yymm && a.SEQ == seq
                       && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                       && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                       //&& (b.SALADR == MainForm.WORKADR || MainForm.MANGSUPER)
                       //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                       && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                       && a.DATE_E >= b.ADATE && a.DATE_E <= b.DDATE.Value
                       select new
                       {
                           a.NOBR,
                           c.NAME_C,
                           部門 = d.D_NO_DISP + "-" + d.D_NAME,
                           職等 = jl.JOBL_DISP + "-" + jl.JOB_NAME,
                           職稱 = j.JOB_DISP + "-" + j.JOB_NAME
                       }).ToList();

            var sql1 = (from a in db.WAGE
                        join b in db.BASETTS on a.NOBR equals b.NOBR
                        join c in db.BASE on a.NOBR equals c.NOBR
                        join d in db.DEPT on b.DEPT equals d.D_NO
                        join j in db.JOB on b.JOB equals j.JOB1
                        join jl in db.JOBL on b.JOBL equals jl.JOBL1
                        //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == sclc.GUID) on a.NOBR equals wrnt.EMPID
                        where a.YYMM == yymm1 && a.SEQ == seq1
                        && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                        && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                        //&& (b.SALADR == MainForm.WORKADR || MainForm.MANGSUPER)
                        //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                        && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                        && a.DATE_E >= b.ADATE && a.DATE_E <= b.DDATE.Value
                        select new
                        {
                            a.NOBR,
                            c.NAME_C,
                            部門 = d.D_NO_DISP + "-" + d.D_NAME,
                            職等 = jl.JOBL_DISP + "-" + jl.JOB_NAME,
                            職稱 = j.JOB_DISP + "-" + j.JOB_NAME
                        }).ToList();

            var waged = (from a in db.WAGED
                         join b in db.WAGE on new { a.NOBR, a.YYMM, a.SEQ } equals new { b.NOBR, b.YYMM, b.SEQ }
                         join c in db.BASETTS on a.NOBR equals c.NOBR
                         join d in db.DEPT on c.DEPT equals d.D_NO
                         join f in db.SALCODE on a.SAL_CODE equals f.SAL_CODE
                         where b.DATE_E >= c.ADATE && b.DATE_E <= c.DDATE.Value
                         && c.NOBR.CompareTo(nobr_b) >= 0 && c.NOBR.CompareTo(nobr_e) <= 0
                         && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                         //&& (c.SALADR == MainForm.WORKADR || MainForm.MANGSUPER)//權限由前端的名單控制
                         && f.SAL_CODE_DISP.CompareTo(salcodeB) >= 0 && f.SAL_CODE_DISP.CompareTo(salcodeE) <= 0
                         //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                         && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(c.SALADR)
                         && a.YYMM == yymm && a.SEQ == seq
                         select a).ToList();
            var waged1 = (from a in db.WAGED
                          join b in db.WAGE on new { a.NOBR, a.YYMM, a.SEQ } equals new { b.NOBR, b.YYMM, b.SEQ }
                          join c in db.BASETTS on a.NOBR equals c.NOBR
                          join d in db.DEPT on c.DEPT equals d.D_NO
                          join f in db.SALCODE on a.SAL_CODE equals f.SAL_CODE
                          where b.DATE_E >= c.ADATE && b.DATE_E <= c.DDATE.Value
                          && c.NOBR.CompareTo(nobr_b) >= 0 && c.NOBR.CompareTo(nobr_e) <= 0
                           && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                          //&& (c.SALADR == MainForm.WORKADR || MainForm.MANGSUPER)
                          && f.SAL_CODE_DISP.CompareTo(salcodeB) >= 0 && f.SAL_CODE_DISP.CompareTo(salcodeE) <= 0
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(c.SALADR)
                          && a.YYMM == yymm1 && a.SEQ == seq1
                          select a).ToList();

            var unionSQL = sql.Union(sql1);//只取人員名單
            viewDS.WAGE_COMPARE.Clear();

            var salcodeSQL = (from a in db.SALCODE
                              where a.SAL_CODE_DISP.CompareTo(salcodeB) >= 0 && a.SAL_CODE_DISP.CompareTo(salcodeE) <= 0
                              select a).ToList();
            var joinSQL = from a in unionSQL
                          from b in salcodeSQL
                          select new
                          {
                              a.NOBR,
                              a.NAME_C,
                              a.部門,
                              a.職等,
                              a.職稱,
                              b.SAL_CODE,
                              b.SAL_NAME
                          };
            var diffSQL = from a in joinSQL
                          join c in waged on new { a.NOBR, a.SAL_CODE } equals new { c.NOBR, c.SAL_CODE } into cc
                          from w in cc.DefaultIfEmpty()
                          join d in waged1 on new { a.NOBR, a.SAL_CODE } equals new { d.NOBR, d.SAL_CODE } into dd
                          from w1 in dd.DefaultIfEmpty()
                          let amt = JBModule.Data.CDecryp.Number(w == null ? 0 : w.AMT)
                          let amt1 = JBModule.Data.CDecryp.Number(w1 == null ? 0 : w1.AMT)
                          where w != null || w1 != null
                          select new
                          {
                              a.NOBR,
                              a.NAME_C,
                              a.部門,
                              a.職等,
                              a.職稱,
                              a.SAL_CODE,
                              a.SAL_NAME,
                              YYMM = yymm,
                              SEQ = seq,
                              AMT = amt,
                              YYMM1 = yymm1,
                              SEQ1 = seq1,
                              AMT1 = amt1,
                              DIFF = amt - amt1,
                          };

            //foreach (var itm in diffSQL)
            //{
            //    ViewDS.WAGE_COMPARERow r = viewDS.WAGE_COMPARE.NewWAGE_COMPARERow();
            //    r.
            //}

            DataTable DT = new DataTable();
            DT = diffSQL.CopyToDataTable();

            DT.Columns["nobr"].ColumnName = Resources.Sal.colNobr;
            DT.Columns["name_c"].ColumnName = Resources.Sal.colName;
            DT.Columns["amt"].ColumnName = Resources.Sal.colAmt;
            DT.Columns["amt1"].ColumnName = Resources.Sal.colAmt + "1";
            DT.Columns["sal_name"].ColumnName = Resources.Sal.colSalName;
            DT.Columns["sal_code"].ColumnName = Resources.Sal.colSalcode;
            DT.Columns["seq"].ColumnName = Resources.Sal.colSeq;
            DT.Columns["seq1"].ColumnName = Resources.Sal.colSeq + "1";
            DT.Columns["yymm"].ColumnName = Resources.Sal.colYymm;
            DT.Columns["yymm1"].ColumnName = Resources.Sal.colYymm + "1";
            DT.Columns["DIFF"].ColumnName = "差異";

            Function.ShowView("薪資比較", DT, 800, 600);
        }

        private void txtChgYymm_Validated(object sender, EventArgs e)
        {
            SalaryMDDataContext db = new SalaryMDDataContext();
            var sql = from a in db.WAGE where a.YYMM == txtChgYymm.Text group a by a.SEQ into gp select gp.Key;
            comboBox1.Items.Clear();
            if (sql.Any())
            {
                comboBox1.Items.AddRange(sql.ToArray());
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                SalaryMDDataContext db = new SalaryMDDataContext();

                object[] objs = new object[] { txtChgYymm.Text, comboBox1.Text, txtChgSeq.Text };

                db.ExecuteCommand("UPDATE WAGE SET SEQ={2} WHERE YYMM={0} AND SEQ={1} ", objs);
                db.ExecuteCommand("UPDATE WAGED SET SEQ={2} WHERE YYMM={0} AND SEQ={1} ", objs);

                MessageBox.Show(Resources.Sal.StatusFinish, Resources.All.DialogTitle,
                           MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show("發生錯誤，" + ex.Message, Resources.All.DialogTitle,
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReExpsup_Click(object sender, EventArgs e)
        {
            FRM4IA frm = new FRM4IA();
            frm.NOBR_B = ptxNobrB.Text;
            frm.NOBR_E = ptxNobrE.Text;
            frm.DEPT_B = ptxDeptB.SelectedValue.ToString();
            frm.DEPT_E = ptxDeptE.SelectedValue.ToString();
            frm.ShowDialog();
        }

        private void txtSeq_Validated(object sender, EventArgs e)
        {
            try
            {
                int acsii = Convert.ToInt32("A"[0]);
                int seq = Convert.ToInt32(txtSeq.Text);
                string cc = Convert.ToChar(acsii + seq - 1).ToString();
                textBoxSEQ2.Text = cc.ToString();
            }
            catch
            {

            }
        }

        private void TxtEdate_Validated(object sender, EventArgs e)
        {
            SetLeaveEmp();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            tableLayoutPanel6.Enabled = checkBox1.Checked;
            buttonLeaveEmp.Enabled = checkBox1.Checked;
            ptxNobrB.Enabled = !checkBox1.Checked;
            ptxNobrE.Enabled = !checkBox1.Checked;
            ptxDeptB.Enabled = !checkBox1.Checked;
            ptxDeptE.Enabled = !checkBox1.Checked;
            SetLeaveEmp();
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            txtLeaveDateB.Enabled = checkBox2.Checked;
            txtLeaveDateE.Enabled = checkBox2.Checked;
            SetLeaveEmp();
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            txtRpYYMMB.Enabled = checkBox3.Checked;
            txtRpYYMME.Enabled = checkBox3.Checked;
            txtRpYYMM.Enabled = checkBox3.Checked;
            btnOTData.Enabled = checkBox3.Checked;
            btnABSData.Enabled = checkBox3.Checked;
            setOTandABS();
        }

        private void TxtLeaveDateB_Validated(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(txtLeaveDateB.Text);
            txtLeaveDateE.Text = Function.GetDate(date.AddMonths(1).AddDays(-1));
            SetLeaveEmp();
        }

        private void TxtLeaveDateE_Validated(object sender, EventArgs e)
        {
            SetLeaveEmp();
        }

        private void TxtRpYYMMB_Validated(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(txtRpYYMMB.Text);
            txtRpYYMME.Text = Function.GetDate(date.AddMonths(1).AddDays(-1));
            setOTandABS();
        }

        private void TxtRpYYMME_Validated(object sender, EventArgs e)
        {
            setOTandABS();
        }

        private void TxtYymm_Validated(object sender, EventArgs e)
        {
            txtRpYYMM.Text = txtYymm.Text;
            setOTandABS();
        }

        private void TxtRpYYMM_Validated(object sender, EventArgs e)
        {
            setOTandABS();
        }

        class LeaveEmpParams
        {
            public string seq = string.Empty;
            public string yymm = string.Empty;
            public string type = string.Empty;
            public DateTime d1 = DateTime.Now;
            public DateTime d2 = DateTime.Now;
            public DateTime a1 = DateTime.Now;
            public DateTime a2 = DateTime.Now;
            public DateTime transDate = DateTime.Now;
            public DateTime inEdate = DateTime.Now;
            public bool Prev = false;
            public List<string> EMP = new List<string>();
        }

        private void buttonPreWage_Click(object sender, EventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;
            acg = new JBModule.Data.ApplicationConfigSettings(this.Name, MainForm.COMPANY);

            string nobr_b = ptxNobrB.Text;
            string nobr_e = ptxNobrE.Text;
            string dept_b = ptxDeptB.SelectedValue.ToString();
            string dept_e = ptxDeptE.SelectedValue.ToString();
            string seq = txtSeq.Text;
            string seq2 = textBoxSEQ2.Text;
            string yymm = txtYymm.Text;
            string type = cbxFormat.SelectedValue.ToString();
            DateTime d1 = Convert.ToDateTime(txtBdate.Text);
            DateTime d2 = Convert.ToDateTime(txtEdate.Text);
            DateTime a1 = Convert.ToDateTime(txtAttDateB.Text);
            DateTime a2 = Convert.ToDateTime(txtAttDateE.Text);
            DateTime transDate = Convert.ToDateTime(txtBank.Text);
            DateTime inEdate = Convert.ToDateTime(txtInEndDate.Text);
            bool Prev = chkPrev.Checked;
            SalaryDate sd = new SalaryDate((DateTime.Now.Date));

            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.WAGE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.LOCK_WAGE on new { a.YYMM, a.SEQ, a.SALADR } equals new { c.YYMM, c.SEQ, c.SALADR }
                      join d in db.DEPT on b.DEPT equals d.D_NO
                      where a.YYMM == yymm && a.SEQ == seq
                      && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                       && d.D_NO_DISP.CompareTo(dept_b) >= 0 && d.D_NO_DISP.CompareTo(dept_e) <= 0
                      && MainForm.WriteSalaryRules.Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select a;
            if (sql.Any())//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            db.Log = new DebuggerWriter();
            DateTime DT = DateTime.Now;
            sclc = new JBModule.Data.Linq.SALARYCALC();
            sclc.GUID = Guid.NewGuid();
            sclc.USERID = MainForm.USER_ID;
            sclc.TIMEB = DT;
            sclc.SOURCE = this.Name;
            db.SALARYCALC.InsertOnSubmit(sclc);
            db.SubmitChanges();

            GenerateEmpRuleList(db, sclc.GUID);

            SalaryCalculation sc = new SalaryCalculation
                    (yymm, seq, nobr_b, nobr_e, dept_b, dept_e, d1, d2, a1, a2, transDate, "MainForm.WORKADR", false, false, "", Prev, inEdate);
            sc.guid = sclc.GUID;
            sc.AppConfig = acg;

            sc.DeleteWaged();
            sc.DeleteWage();
            //sc.PreSalaryCalc();
            sc.ImportEnrich();
            sc.CreateWage();
            //sc.CreateExpSup();
            //if (chkTax.Checked)
            //    sc.TaxCalc(false);
            //if (chkTeco.Checked)
            //{
            //    sc.TecoCalc();
            //    sc.ImportWagedd();
            //}
            sc.ChangeSeq();
            sc.WriteToDB();
            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

    }
}
