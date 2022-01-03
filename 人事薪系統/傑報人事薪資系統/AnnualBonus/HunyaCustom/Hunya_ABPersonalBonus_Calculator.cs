using Dapper;
using JBTools.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace JBHR.AnnualBonus.HunyaCustom
{
    public partial class Hunya_ABPersonalBonus_Calculator : JBControls.JBForm
    {
        public Hunya_ABPersonalBonus_Calculator()
        {
            InitializeComponent();
        }

        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog mdOUTCD = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog mdMaternityCode = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog mdRateHCode = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog mdSalBasd = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog mdExEmp = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.ApplicationConfigSettings acg = null;
        JBModule.Data.ApplicationConfigSettings appcofig = null;
        string topic = "";
        CheckYYMMFormatControl CYYMMFC = new CheckYYMMFormatControl();
        private void Hunya_ABPersonalBonus_Calculator_Load(object sender, EventArgs e)
        {
            topic = this.Text;
            EmpInitial();
        }

        private void EmpInitial()
        {
            Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(DateTime.Now.Date);
            txtEnrichYYMM.Text = sd.YYMM;
            txtSeq.Text = "2";
            CYYMMFC.AddControl(txtEnrichYYMM, true);
            appcofig = new JBModule.Data.ApplicationConfigSettings("Hunya_ABPersonalBonus", MainForm.COMPANY);
            acg = new JBModule.Data.ApplicationConfigSettings(this.Name, MainForm.COMPANY);
            acg.CheckParameterAndSetDefault("ABOUTCDList", "指定離職原因代碼", "", "指定離職照發年終的離職原因代碼", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("ABSalBasdList", "指定基本薪資代碼", "", "指定一日薪資所含的基本薪資代碼", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("ABMaternityCode", "指定分娩假代碼", "", "指定套用分娩假規則的假別代碼", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("ABRateHCode", "指定改發比例假別代碼", "", "指定當請此假別時會影響在職天數", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("ABDivisor", "指定日薪基底除數", "30", "指定一日薪資所含的基本薪資代碼", "TextBox", "", "decimal");
            acg.CheckParameterAndSetDefault("ABSALCODE", "年終獎金代碼", "", "指定轉入補扣發的年終獎金代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            int YYYY = DateTime.Now.AddYears(-1).Year;
            nudABYYYY.Value = YYYY;
            //txtBasicBonus.Text = "0.00";
            SetEmpList();
            SetOUTCDList();
            SetMaternityCode();
            SetRateHCode();
            SetSalBasdList();
            SetExEmpList();
            SystemFunction.SetComboBoxItems(cbxABSALCODE, CodeFunction.GetSalCode(), true, true, true);
            cbxABSALCODE.SelectedValue = acg.GetConfig("ABSALCODE").GetString();
            nudABYYYY.Focus();
        }
        void SetOUTCDList()
        {
            List<string> FlagList = new List<string>() { "-" };
            var OUTCDList = from b in db.OUTCD
                          orderby b.OUTCD1
                          select new
                          {
                              原因代碼 = b.OUTCD1,
                              原因名稱 = b.OUTNAME,
                          };
            mdOUTCD.SetControl(btnOUTCD, OUTCDList.ToList().CopyToDataTable(), "原因代碼");
            mdOUTCD.SelectedValues.Clear();
            //btnOUTCD.Text = "指定照發離職原因代碼";
            List<string> ABOUTCDList = acg.GetConfig("ABOUTCDList").GetString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            mdOUTCD.SelectedValues = ABOUTCDList;
            if (ABOUTCDList.Count == 0)
                btnOUTCD.Text = "指定離職原因代碼";
        }
        void SetMaternityCode()
        {
            List<string> FlagList = new List<string>() { "-" };
            var MaternityCode = from b in db.HCODE
                                  where b.FLAG == "-"
                                  orderby b.H_CODE_DISP
                                  select new
                                  {
                                      _hcode = b.H_CODE,
                                      假別代碼 = b.H_CODE_DISP,
                                      假別名稱 = b.H_NAME,
                                  };
            mdMaternityCode.SetControl(btnMaternityCode, MaternityCode.ToList().CopyToDataTable(), "_hcode");
            mdMaternityCode.SelectedValues.Clear();
            //btnMaternityCode.Text = "指定分娩假代碼";
            List<string> ABMaternityCode = acg.GetConfig("ABMaternityCode").GetString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            mdMaternityCode.SelectedValues = ABMaternityCode;
            if (ABMaternityCode.Count == 0)
                btnOUTCD.Text = "指定分娩假別代碼";
        }
        void SetRateHCode()
        {
            List<string> FlagList = new List<string>() { "-" };
            var RateHCode = from b in db.HCODE
                             where b.FLAG == "-"
                             orderby b.H_CODE_DISP
                             select new
                             {
                                 _hcode = b.H_CODE,
                                 假別代碼 = b.H_CODE_DISP,
                                 假別名稱 = b.H_NAME,
                             };
            mdRateHCode.SetControl(btnRateHCode, RateHCode.ToList().CopyToDataTable(), "_hcode");
            mdRateHCode.SelectedValues.Clear();
            //btnMaternityCode.Text = "指定分娩假代碼";
            List<string> ABRateHCode = acg.GetConfig("ABRateHCode").GetString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            mdRateHCode.SelectedValues = ABRateHCode;
            if (ABRateHCode.Count == 0)
                btnOUTCD.Text = "指定改發比例假別";
        }
        void SetEmpList()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            List<string> ABEMPCDList = appcofig.GetConfig("ABEMPCD").GetString("01").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int YYYY = (int)nudABYYYY.Value;
            DateTime bdate = new DateTime(YYYY, 1, 1);
            DateTime edate = new DateTime(YYYY, 12, 31);
            var AttendByNobr = db.ATTEND.Where(p => p.ADATE >= bdate && p.ADATE <= edate).GroupBy(p => p.NOBR).Select(p => p.Key).ToList();
            DataTable dt = new DataTable();
            var TTSCODE = new string[] { "1", "4", "6" };
            List<string> ABOUTCDList = mdOUTCD.SelectedValues;
            foreach (var item in AttendByNobr.Split(1000))
            {
                var sql = from b in db.BASE
                          join bts in db.BASETTS on b.NOBR equals bts.NOBR
                          join jl in db.JOBL on bts.JOBL equals jl.JOBL1
                          join mt in db.MTCODE on bts.TTSCODE equals mt.CODE
                          join mt1 in db.MTCODE on b.SEX equals mt1.CODE
                          join emp in db.EMPCD on bts.EMPCD equals emp.EMPCD1
                          join result in (
                               from a in db.Hunya_ABYearEndAppraisal
                               join b in db.Hunya_ABLevelCode on a.RealLevelCode equals b.ABLevelCode
                               where item.Contains(a.EmployeeID)
                               && a.YYYY == YYYY
                               select new
                               {
                                   員工編號 = a.EmployeeID,
                                   考績年度 = a.YYYY,
                                   實際評等 = b.ABLevelCode_Name,
                               }
                          ) on b.NOBR equals result.員工編號 //into g
                          //from result in g.DefaultIfEmpty()
                          where true
                          //&& item.Contains(b.NOBR)
                          && edate >= bts.ADATE && edate <= bts.DDATE.Value
                          && mt.CATEGORY == "TTSCODE"
                          && mt1.CATEGORY == "SEX"
                          && ABEMPCDList.Contains(emp.EMPCD1)
                          && (bts.OUDT == null || ABOUTCDList.Contains(bts.OUTCD))
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                          select new
                          {
                              員工編號 = b.NOBR,
                              員工姓名 = b.NAME_C,
                              考績年度 = result.考績年度.ToString(),
                              實際評等 = result.實際評等,
                              異動狀態 = TTSCODE.Contains(mt.CODE) ? "在職" : mt.NAME,
                              異動日期 = TTSCODE.Contains(mt.CODE) ? null : bts.OUDT != null ? bts.OUDT : bts.STDT != null ? bts.STDT : null,
                              性別 = mt1.NAME,
                              職稱 = bts.JOB1.JOB_DISP + "-" + bts.JOB1.JOB_NAME,
                              職等 = jl.JOBL_DISP + "-" + jl.JOB_NAME,
                              編制部門 = bts.DEPT1.D_NO_DISP + "-" + bts.DEPT1.D_NAME,
                          };
                dt.Merge(sql.ToList().CopyToDataTable());
            }
            dt.DefaultView.Sort = "員工編號 ASC";
            mdEmp.SetControl(btnEmp, dt, "員工編號");
            //mdEmp.SelectedValues.Clear();
            //btnEmp.Text = "請選擇需設定的人員";
        }
        void SetSalBasdList()
        {
            List<string> FlagList = new List<string>() { "-" };
            var salbasd = from b in db.SALCODE
                           join c in db.SALATTR on b.SAL_ATTR equals c.SALATTR1
                           where c.BASIC && db.GetCodeFilter("SALCODE", b.SAL_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                           orderby b.SAL_CODE_DISP
                           select new
                           {
                               _salbasd = b.SAL_CODE,
                               薪資代碼 = b.SAL_CODE_DISP,
                               薪資名稱 = b.SAL_NAME,
                           };
            mdSalBasd.SetControl(btnSalBasd, salbasd.ToList().CopyToDataTable(), "_salbasd");
            mdSalBasd.SelectedValues.Clear();
            //btnSalBasd.Text = "指定一日薪資所含的基本薪資代碼";
            List<string> ABSalBasdList = acg.GetConfig("ABSalBasdList").GetString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            mdSalBasd.SelectedValues = ABSalBasdList;
            if (ABSalBasdList.Count == 0)
                btnSalBasd.Text = "選取基本薪資代碼";
        }
        void SetExEmpList()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            int YYYY = (int)nudABYYYY.Value;
            acg.CheckParameterAndSetDefault(String.Format("{0}_ABExEmpList",YYYY.ToString()), String.Format("指定{0}年比例例外人員", YYYY.ToString()), "", "按比例配發例外人員", "TextBox", "", "String");
            List<string> ABEMPCDList = appcofig.GetConfig("ABEMPCD").GetString("01").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            DateTime bdate = new DateTime(YYYY, 1, 1);
            DateTime edate = new DateTime(YYYY, 12, 31);
            var AttendByNobr = db.ATTEND.Where(p => p.ADATE >= bdate && p.ADATE <= edate).GroupBy(p => p.NOBR).Select(p => p.Key).ToList();
            DataTable dt = new DataTable();
            var TTSCODE = new string[] { "1", "4", "6" };
            List<string> ABOUTCDList = mdOUTCD.SelectedValues;
            List<string> ABRateHCodeList = mdRateHCode.SelectedValues;
            int DayOfYear = (new DateTime(YYYY, 12, 31)).DayOfYear;
            foreach (var item in AttendByNobr.Split(500))
            {
                string EmpString = string.Join(",", item.Select(p => string.Format("{0}", p)));
                var sql1 = from b in db.BASE
                          join bts in db.BASETTS on b.NOBR equals bts.NOBR
                          join jl in db.JOBL on bts.JOBL equals jl.JOBL1
                          join oc in db.OUTCD on bts.OUTCD equals oc.OUTCD1 into oc1
                          from oc in oc1.DefaultIfEmpty()
                          join mt in db.MTCODE on bts.TTSCODE equals mt.CODE
                          join mt1 in db.MTCODE on b.SEX equals mt1.CODE
                          join emp in db.EMPCD on bts.EMPCD equals emp.EMPCD1
                          join result in (
                               from a in db.Hunya_ABYearEndAppraisal
                               join b in db.Hunya_ABLevelCode on a.RealLevelCode equals b.ABLevelCode
                               where item.Contains(a.EmployeeID)
                               && a.YYYY == YYYY
                               select new
                               {
                                   員工編號 = a.EmployeeID,
                                   考績年度 = a.YYYY,
                                   實際評等 = b.ABLevelCode_Name,
                               }
                          ) on b.NOBR equals result.員工編號 //into g
                          //from result in g.DefaultIfEmpty()
                          //join OJD in db.Hunya_GetPAOnJobDays(EmpString, bdate, edate, YYYY.ToString()) on bts.NOBR equals OJD.員工編號
                          where true
                          && item.Contains(b.NOBR)
                          && edate >= bts.ADATE && edate <= bts.DDATE.Value
                          && mt.CATEGORY == "TTSCODE"
                          && mt1.CATEGORY == "SEX"
                          && ABEMPCDList.Contains(emp.EMPCD1)
                          //&& (OJD.每月天數 / DayOfYear != 1)
                          && (bts.OUDT == null || ABOUTCDList.Contains(bts.OUTCD))
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                          select new
                          {
                              員工編號 = b.NOBR,
                              員工姓名 = b.NAME_C,
                              考績年度 = result.考績年度.ToString(),
                              實際評等 = result.實際評等,
                              //在職天數 = OJD.每月天數,
                              異動狀態 = TTSCODE.Contains(mt.CODE) ? "在職" : mt.NAME,
                              異動日期 = TTSCODE.Contains(mt.CODE) ? bts.INDT : bts.OUDT != null ? bts.OUDT : bts.STDT != null ? bts.STDT : null,
                              離職原因 = oc.OUTNAME,
                              性別 = mt1.NAME,
                              職稱 = bts.JOB1.JOB_DISP + "-" + bts.JOB1.JOB_NAME,
                              職等 = jl.JOBL_DISP + "-" + jl.JOB_NAME,
                              編制部門 = bts.DEPT1.D_NO_DISP + "-" + bts.DEPT1.D_NAME,
                          };
                var sql2 = db.Hunya_GetPAOnJobDays(EmpString, bdate, edate, YYYY.ToString()).ToList();
                var sql3 = db.ABS.Where(p => ABRateHCodeList.Contains(p.H_CODE) && p.BDATE >= bdate && p.BDATE <= edate).GroupBy(q => q.NOBR).Select(r => new { 員工編號 = r.Key, 公傷假 = r.Count() });

                var sql = from a in sql1.ToList()
                          join OJD in sql2.ToList() on a.員工編號 equals OJD.員工編號
                          join c in sql3.ToList() on a.員工編號 equals c.員工編號 into c1
                          from c in c1.DefaultIfEmpty()
                          where true
                          && ((OJD.每月天數 - (c != null ? c.公傷假 : 0)) / DayOfYear != 1)
                          select new
                          {
                              a.員工編號,
                              a.員工姓名,
                              a.考績年度,
                              a.實際評等,
                              在職天數 = OJD.每月天數 - (c != null ? c.公傷假 : 0),
                              a.異動狀態,
                              a.異動日期,
                              a.離職原因,
                              a.性別,
                              a.職稱,
                              a.職等,
                              a.編制部門,
                          };
                dt.Merge(sql.ToList().CopyToDataTable());
            }
            dt.DefaultView.Sort = "員工編號 ASC";
            mdExEmp.SetControl(btnExEmp, dt, "員工編號");
            //mdEmp.SelectedValues.Clear();
            //btnEmp.Text = "請選擇需設定的人員";
            List<string> ABExEmpList = acg.GetConfig(String.Format("{0}_ABExEmpList", YYYY.ToString())).GetString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            mdExEmp.SelectedValues = ABExEmpList;
            if (ABExEmpList.Count == 0)
                btnExEmp.Text = "比例配發例外人員";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            int YYYY = (int)nudABYYYY.Value;
            DateTime BDate = new DateTime(YYYY, 1, 1);
            DateTime EDate = new DateTime(YYYY, 12, 31);
            DateTime BDate_Att = new DateTime(YYYY, 1, 1);
            DateTime EDate_Att = new DateTime(YYYY, 12, 31);
            List<string> EmployeeList = mdEmp.SelectedValues.ToList();
            if (EmployeeList.Count == 0) return;
            decimal BonusDays = nudBonusDays.Value;
            List<string> ABOUTCDList = mdOUTCD.SelectedValues.ToList();
            CodeFunction.UpdateAppconfig(this.Name, MainForm.COMPANY, "ABOUTCDList", string.Join(",", ABOUTCDList.Select(p => string.Format("{0}", p))));
            List<string> ABMaternityCode = mdMaternityCode.SelectedValues.ToList();
            CodeFunction.UpdateAppconfig(this.Name, MainForm.COMPANY, "ABMaternityCode", string.Join(",", ABMaternityCode.Select(p => string.Format("{0}", p))));
            List<string> ABRateHCode = mdRateHCode.SelectedValues.ToList();
            CodeFunction.UpdateAppconfig(this.Name, MainForm.COMPANY, "ABRateHCode", string.Join(",", ABRateHCode.Select(p => string.Format("{0}", p))));
            List<string> ABSalBasdList = mdSalBasd.SelectedValues.ToList();
            CodeFunction.UpdateAppconfig(this.Name, MainForm.COMPANY, "ABSalBasdList", string.Join(",", ABSalBasdList.Select(p => string.Format("{0}", p))));
            List<string> ABExEmpList = mdExEmp.SelectedValues.ToList();
            CodeFunction.UpdateAppconfig(this.Name, MainForm.COMPANY, String.Format("{0}_ABExEmpList", YYYY.ToString()), string.Join(",", ABExEmpList.Select(p => string.Format("{0}", p))));
            string ABSALCODE = cbxABSALCODE.SelectedValue.ToString();
            CodeFunction.UpdateAppconfig(this.Name, MainForm.COMPANY, "ABSALCODE", ABSALCODE);
            decimal ABDivisor = acg.GetConfig("ABDivisor").GetDecimal(30.0M);
            string EnrichYYMM = txtEnrichYYMM.Text;
            string SEQ = txtSeq.Text;
            string Memo = txtMemo.Text;

            //acg = new JBModule.Data.ApplicationConfigSettings("Hunya_ABPersonalBonus", MainForm.COMPANY);
            decimal ABAward1 = appcofig.GetConfig("ABAward1").GetDecimal(10);
            decimal ABAward2 = appcofig.GetConfig("ABAward2").GetDecimal(3);
            decimal ABAward3 = appcofig.GetConfig("ABAward3").GetDecimal(1);
            decimal ABFault1 = appcofig.GetConfig("ABFault1").GetDecimal(10);
            decimal ABFault2 = appcofig.GetConfig("ABFault2").GetDecimal(3);
            decimal ABFault3 = appcofig.GetConfig("ABFault3").GetDecimal(1);

            object[] PARMS = new object[] {
                EmployeeList, YYYY, BonusDays, ABSalBasdList, ABDivisor, ABExEmpList, ABOUTCDList,  BDate, EDate, BDate_Att, EDate_Att, ABSALCODE, EnrichYYMM, SEQ, Memo,
                ABAward1, ABAward2, ABAward3, ABFault1, ABFault2, ABFault3, ABMaternityCode, ABRateHCode
            };
            BW.RunWorkerAsync(PARMS);
            this.tableLayoutPanel1.Enabled = false;
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext dbBW = new JBModule.Data.Linq.HrDBDataContext();
            object[] parameters = e.Argument as object[];
            List<string> EmployeeListAll = parameters[0] as List<string>;
            int YYYY = (parameters[1] as int?).Value;
            decimal BonusDays = decimal.Parse(parameters[2].ToString());
            List<string> SalBasdList = parameters[3] as List<string>;
            decimal Divisor = decimal.Parse(parameters[4].ToString());
            List<string> ExEmployeeList = parameters[5] as List<string>;
            List<string> OUTCDList = parameters[6] as List<string>;
            int DayOfYear = (new DateTime(YYYY, 12, 31)).DayOfYear;
            DateTime BDate = (parameters[7] as DateTime?).GetValueOrDefault(DateTime.Today);
            DateTime EDate = (parameters[8] as DateTime?).GetValueOrDefault(DateTime.Today);
            DateTime BDate_Att = (parameters[9] as DateTime?).GetValueOrDefault(DateTime.Today);
            DateTime EDate_Att = (parameters[10] as DateTime?).GetValueOrDefault(DateTime.Today);
            string ABSALCODE = parameters[11] as string;
            string EnrichYYMM = parameters[12] as string;
            string SEQ = parameters[13] as string;
            string Memo = parameters[14] as string;

            decimal ABAward1 = decimal.Parse(parameters[15].ToString());
            decimal ABAward2 = decimal.Parse(parameters[16].ToString());
            decimal ABAward3 = decimal.Parse(parameters[17].ToString());
            decimal ABFault1 = decimal.Parse(parameters[18].ToString());
            decimal ABFault2 = decimal.Parse(parameters[19].ToString());
            decimal ABFault3 = decimal.Parse(parameters[20].ToString());
            List<string> MaternityCode = parameters[21] as List<string>;
            List<string> RateHCode = parameters[22] as List<string>;

            string msg = "";
            DateTime PayDate = new DateTime(int.Parse(EnrichYYMM.Substring(0, 4)), int.Parse(EnrichYYMM.Substring(4, 2)), 1).AddMonths(1).AddDays(-1);
            try
            {
                foreach (var EmployeeList in EmployeeListAll.Split(1000))
                {
                    JBModule.Data.Factory.Formula.FormulaFunctionCondition cond = new JBModule.Data.Factory.Formula.FormulaFunctionCondition();
                    cond.Parameters = new Dictionary<string, object>();
                    cond.Parameters.Add("EmployeeList", string.Join(",", EmployeeList.Select(p => string.Format("{0}", p))));
                    cond.Parameters.Add("YYYY", YYYY);
                    cond.Parameters.Add("SalBasdList", string.Join(",", SalBasdList.Select(p => string.Format("{0}", p))));
                    cond.Parameters.Add("BonusDays", BonusDays);
                    cond.Parameters.Add("Divisor", Divisor);
                    cond.Parameters.Add("ExEmployeeList", string.Join(",", ExEmployeeList.Select(p => string.Format("{0}", p))));
                    cond.Parameters.Add("OUTCDList", string.Join(",", OUTCDList.Select(p => string.Format("{0}", p))));
                    cond.Parameters.Add("DayOfYear", DayOfYear);
                    cond.Parameters.Add("BDate", BDate);
                    cond.Parameters.Add("EDate", EDate);
                    cond.Parameters.Add("AttDateB", BDate_Att);
                    cond.Parameters.Add("AttDateE", EDate_Att);
                    cond.Parameters.Add("PayDate", PayDate);
                    cond.Parameters.Add("userid", MainForm.USER_ID);
                    cond.Parameters.Add("comp", MainForm.COMPANY);
                    cond.Parameters.Add("admin", MainForm.ADMIN);

                    cond.Parameters.Add("ABAward1", ABAward1);
                    cond.Parameters.Add("ABAward2", ABAward2);
                    cond.Parameters.Add("ABAward3", ABAward3);
                    cond.Parameters.Add("ABFault1", ABFault1);
                    cond.Parameters.Add("ABFault2", ABFault2);
                    cond.Parameters.Add("ABFault3", ABFault3);
                    cond.Parameters.Add("MaternityCode", string.Join(",", MaternityCode.Select(p => string.Format("{0}", p))));
                    cond.Parameters.Add("RateHCode", string.Join(",", RateHCode.Select(p => string.Format("{0}", p))));

                    var ParamsList = dbBW.AppConfig.Where(p => p.Category == "Hunya_ABPersonalBonusParams").Select(p => new { p.Code, p.Value }).ToList();
                    foreach (var Parameter in ParamsList)
                        cond.Parameters.Add(Parameter.Code, Parameter.Value);
                    var moduleList = dbBW.AppConfig.Where(p => p.Category == "Hunya_ABPersonalBonusParamsBySQLFunction").OrderBy(p => p.Sort);
                    List<JBModule.Data.Factory.Formula.IFormulaFunction> GetDataList = new List<JBModule.Data.Factory.Formula.IFormulaFunction>();
                    int total = moduleList.Count();
                    int count = 0;
                    foreach (var module in moduleList)
                    {
                        BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 100), "正在取得系統參數.");
                        var sourceDir = string.IsNullOrWhiteSpace(module.DataSource) ? AppDomain.CurrentDomain.BaseDirectory : module.DataSource;
                        var asmConcrete = Assembly.LoadFrom(sourceDir + module.DataType);
                        var typeClass = asmConcrete.GetType(module.Value);
                        var instance = asmConcrete.CreateInstance(module.Value) as JBModule.Data.Factory.Formula.IFormulaFunction;
                        if (module.ControlType == "SqlFuction")
                        {
                            instance.Parameters = cond.Parameters.Clone();
                            instance.Parameters.Add("SqlFuction", module.Note);
                            instance.Parameters.Add("TableName", module.NameP);
                        }
                        GetDataList.Add(instance);
                        count++;
                    }
                    cond.GetDataList.AddRange(GetDataList);
                    BW.ReportProgress(100, "正在取得系統參數.");

                    JBModule.Data.Factory.Formula.FormulaFunctionRepo FormulaFunctionRepo = new JBModule.Data.Factory.Formula.FormulaFunctionRepo(cond);
                    Dictionary<string, object> FormulaParams = new Dictionary<string, object>();
                    FormulaParams = FormulaFunctionRepo.CheckFormulaFunction(cond.Parameters);

                    //var deleteSql = from a in dbBW.Hunya_ABPersonalBonus
                    //                where EmployeeList.Contains(a.EmployeeID)
                    //                && a.YYMM == PAYYMM
                    //                select a;
                    //dbBW.Hunya_ABPersonalBonus.DeleteAllOnSubmit(deleteSql);
                    //dbBW.SubmitChanges();

                    List<JBModule.Data.Linq.Hunya_ABPersonalBonus> bppb = new List<JBModule.Data.Linq.Hunya_ABPersonalBonus>();
                    var ABFunctionList = dbBW.SALFUNCTION.Where(p => p.CALCTYPE == "AB").OrderBy(q => q.SORT).ToList();
                    total = EmployeeList.Count * ABFunctionList.Count();
                    count = 0;
                    foreach (var ABFunction in ABFunctionList)
                    {
                        string Script = ABFunction.SCRIPT;
                        Dictionary<string, string> ScriptParams = new Dictionary<string, string>();
                        ScriptParams.Add("%取得年終獎金係數.一日份薪資%", string.Empty);
                        ScriptParams.Add("%取得年終獎金係數.獎勵標準日數%", string.Empty);
                        ScriptParams.Add("%取得年終獎金係數.獎勵比率%", string.Empty);
                        //ScriptParams.Add("%取得年終獎金係數.在職天數%", string.Empty);
                        //ScriptParams.Add("%取得年終獎金係數.在職係數%", string.Empty);
                        ScriptParams.Add("%取得年終獎金比率.獎懲天數%", string.Empty);
                        ScriptParams.Add("%取得年終獎金比率.產假扣發天數%", string.Empty);
                        ScriptParams.Add("%取得年終獎金比率.在職天數%", string.Empty);
                        ScriptParams.Add("%取得年終獎金比率.在職係數%", string.Empty);
                        while (Script.Contains('%'))
                        {
                            int v1 = Script.IndexOf('%');//取第一個'%'位子
                            int lgh2 = Script.IndexOf('%', v1 + 1) - v1 + 1;//取第二個'%'位子
                            string newStr = Script.Substring(v1, lgh2);
                            if (!ScriptParams.ContainsKey(newStr))
                                ScriptParams.Add(newStr, string.Empty);
                            Script = Script.Replace(newStr, ScriptParams[newStr]);
                        }
                        foreach (var Employee in EmployeeList)
                        {
                            Script = ABFunction.SCRIPT;
                            var tempParams = ScriptParams.Clone();
                            foreach (var ScriptParam in tempParams)
                            {
                                var tempStr = ScriptParam.Key.Split(new char[] { '.', '%' }, StringSplitOptions.RemoveEmptyEntries);
                                string tbName, colName;
                                tbName = tempStr[0];
                                colName = tempStr[1];
                                var erc = (FormulaParams[tempStr[0]] as DataTable).AsEnumerable();
                                if (erc.FirstOrDefault(p => p.Field<string>("員工編號") == Employee) != null)
                                {
                                    var tempobj = erc.FirstOrDefault(p => p.Field<string>("員工編號") == Employee).Field<object>(tempStr[1]);
                                    ScriptParams[ScriptParam.Key] = tempobj != null ? tempobj.ToString() : string.Empty;
                                }
                                else
                                    ScriptParams[ScriptParam.Key] = string.Empty;
                                Script = Script.Replace(ScriptParam.Key, ScriptParams[ScriptParam.Key]);
                            }

                            Microsoft.JScript.Vsa.VsaEngine Engine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
                            try
                            {
                                var result = Microsoft.JScript.Eval.JScriptEvaluate(Script, Engine);
                                decimal defDecimal = 0;

                                JBModule.Data.Linq.Hunya_ABPersonalBonus personalBonus = new JBModule.Data.Linq.Hunya_ABPersonalBonus()
                                {
                                    EmployeeID = Employee,
                                    YYYY = YYYY,
                                    BonusDays = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得年終獎金係數.獎勵標準日數%"], out defDecimal) ? defDecimal : 0M),
                                    DailySalary = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得年終獎金係數.一日份薪資%"], out defDecimal) ? defDecimal : 0M),
                                    MeritDays = decimal.TryParse(ScriptParams["%取得年終獎金比率.獎懲天數%"], out defDecimal) ? defDecimal : 0M,
                                    BonusRate = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得年終獎金係數.獎勵比率%"], out defDecimal) ? defDecimal : 0M),
                                    //Amount = JBModule.Data.CEncrypt.Number(Math.Round(result == null ? 0 : Decimal.TryParse(result.ToString(), out defDecimal) ? Math.Ceiling(defDecimal) : 0M)),
                                    Amount = JBModule.Data.CEncrypt.Number(Math.Round(Decimal.TryParse(result.ToString(), out defDecimal) ? defDecimal < 0 ? 0M : defDecimal : 0M)),
                                    OnJobDays = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得年終獎金比率.在職天數%"], out defDecimal) ? defDecimal : 0M),
                                    Memo = Memo,
                                    KeyMan = MainForm.USER_NAME,
                                    KeyDate = DateTime.Now,
                                    GID = Guid.NewGuid(),
                                };
                                //dbBW.Hunya_ABPersonalBonus.InsertOnSubmit(personalBonus);
                                bppb.Add(personalBonus);
                            }
                            catch (Exception evalex)
                            {
                                JBModule.Message.DbLog.WriteLog(Employee, Script, this.Name, -1);
                            }
                            count++;
                        }
                        //dbBW.SubmitChanges();
                    }

                    string deleteSql = "DELETE Hunya_ABPersonalBonus WHERE EmployeeID in @EmployeeList and YYYY = @YYYY";
                    object param = new { EmployeeList, YYYY };
                    string errMsg = "寫入年終獎金異常.";
                    dbBW.BulkInsertWithDelete(dbBW, bppb, deleteSql, param, errMsg);
                    //var enrichDelSql = db.ENRICH.Where(p => p.YYMM == EnrichYYMM && p.SAL_CODE == PASALCODE && p.SEQ == SEQ && EmployeeList.Contains(p.NOBR) && p.IMPORT);
                    //db.ENRICH.DeleteAllOnSubmit(enrichDelSql);
                    //db.SubmitChanges();

                    List<JBModule.Data.Linq.ENRICH> enrich = new List<JBModule.Data.Linq.ENRICH>();
                    total = EmployeeList.Count;
                    count = 0;
                    var bonusLinq = db.Hunya_ABPersonalBonus.Where(p => EmployeeList.Contains(p.EmployeeID) && p.YYYY == YYYY).ToList();
                    foreach (var Employee in EmployeeList)
                    {
                        BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 100), "正在轉入" + Employee + "補扣發");
                        var bonusLinqbyEmp = bonusLinq.Where(p => p.EmployeeID == Employee);
                        if (bonusLinqbyEmp.Any())
                        {
                            var amt = bonusLinqbyEmp.Sum(q => JBModule.Data.CDecryp.Number(q.Amount));
                            var enrichByEmployee = new JBModule.Data.Linq.ENRICH()
                            {
                                NOBR = Employee,
                                SAL_CODE = ABSALCODE,
                                YYMM = EnrichYYMM,
                                SEQ = SEQ,
                                AMT = JBModule.Data.CEncrypt.Number(amt),
                                FA_IDNO = string.Empty,
                                IMPORT = true,
                                KEY_DATE = DateTime.Now,
                                KEY_MAN = MainForm.USER_NAME,
                                MEMO = "由計算員工年終獎金轉入" + (string.IsNullOrEmpty(bonusLinqbyEmp.First().Memo) ? string.Empty : "-" + bonusLinqbyEmp.First().Memo),
                            };
                            //db.ENRICH.InsertOnSubmit(enrichByEmployee);
                            enrich.Add(enrichByEmployee);
                        }
                        count++;
                    }
                    //db.SubmitChanges();
                    deleteSql = "DELETE enrich WHERE nobr in @EmployeeList and YYMM = @YYMM and SAL_CODE = @SAL_CODE and SEQ = @SEQ and IMPORT = 1 ";
                    param = new { EmployeeList, YYMM = EnrichYYMM, SAL_CODE = ABSALCODE, SEQ };
                    errMsg = "年終轉補扣發異常.";
                    dbBW.BulkInsertWithDelete(dbBW, enrich, deleteSql, param, errMsg);
                }

                BW.ReportProgress(100, Resources.Sal.StatusFinish);
                msg = "完成.";
                e.Result = msg;
            }
            catch (Exception ex)
            {
                BW.ReportProgress(100, "錯誤.");
                msg = ex.Message;
                e.Result = msg;
                JBModule.Message.DbLog.WriteLog(msg, ex.StackTrace, this.Name, -1);
            }
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
            tSSLabelProcess.Text = e.UserState.ToString();
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result.ToString().Trim().Length > 0)
                MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.tableLayoutPanel1.Enabled = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudABYYYY_Leave(object sender, EventArgs e)
        {
            //SetEmpList();
            mdEmp.SelectedValues.Clear();
            btnEmp.Text = "請選擇需設定的人員";
            //SetSalBasdList();
            //SetExEmpList();
            mdExEmp.SelectedValues.Clear();
            btnExEmp.Text = "比例配發例外人員";
            //SetOUTCDList();
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            SetEmpList();
        }

        private void btnExEmp_Click(object sender, EventArgs e)
        {
            SetExEmpList();
        }

        private void btnOUTCD_Leave(object sender, EventArgs e)
        {
            mdEmp.SelectedValues.Clear();
            btnEmp.Text = "請選擇需設定的人員";
            mdExEmp.SelectedValues.Clear();
            btnExEmp.Text = "比例配發例外人員";
        }
    }
}
