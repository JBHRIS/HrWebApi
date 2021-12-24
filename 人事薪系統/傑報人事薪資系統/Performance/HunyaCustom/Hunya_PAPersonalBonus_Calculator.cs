using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JBTools.Extend;
using System.Reflection;
using JBHR.Sal;
using Dapper;

namespace JBHR.Performance.HunyaCustom
{
    public partial class Hunya_PAPersonalBonus_Calculator : JBControls.JBForm
    {
        public Hunya_PAPersonalBonus_Calculator()
        {
            InitializeComponent();
        }
        JBControls.MultiSelectionDialog mdPADept = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog mdPAHCODE = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.ApplicationConfigSettings acg = null;
        string topic = "";
        CheckYYMMFormatControl CYYMMFC = new CheckYYMMFormatControl();
        private void Hunya_PAPersonalBonus_Calculator_Load(object sender, EventArgs e)
        {
            topic = this.Text;
            EmpInitial();
        }
        private void EmpInitial()
        {
            Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(DateTime.Now.Date);
            txtPAYYMM.Text = sd.YYMM;
            txtEnrichYYMM.Text = sd.YYMM;
            txtSeq.Text = "2";
            CYYMMFC.AddControl(txtPAYYMM, true);
            CYYMMFC.AddControl(txtEnrichYYMM, true);
            acg = null; acg = new JBModule.Data.ApplicationConfigSettings(this.Name, MainForm.COMPANY);
            acg.CheckParameterAndSetDefault("PAHCODEList", "指定扣假代碼", "", "指定計算實勤天數的扣假代碼", "TextBox", "", "String");
            acg.CheckParameterAndSetDefault("PASALCODE", "績效獎金代碼", "", "指定轉入補扣發的績效獎金代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            SetPADeptList();
            SetPAHCODEList();
            List<string> PAHCODEList = acg.GetConfig("PAHCODEList").GetString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            mdPAHCODE.SelectedValues = PAHCODEList;
            SystemFunction.SetComboBoxItems(cbxPASALCODE, CodeFunction.GetSalCode(), true, true, true);
            cbxPASALCODE.SelectedValue = acg.GetConfig("PASALCODE").GetString();
        }

        void SetPADeptList()
        {
            string PAYYMM = txtPAYYMM.Text;
            Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(PAYYMM);
            var dept = (from a in db.View_Hunya_PADeptBonus
                        where a.考核年月起.CompareTo(PAYYMM) <= 0 && a.考核年月迄.CompareTo(PAYYMM) >= 0
                        orderby a.部門代碼
                        select new
                        {
                            _PADept = a.部門實際代碼,
                            編制部門 = a.部門代碼 + "-" + a.部門名稱,
                            基本獎金 = JBModule.Data.CDecryp.Number(a.基本獎金.Value),
                            考核年月起 = a.考核年月起,
                            考核年月迄 = a.考核年月迄,
                            成立日期 = a.成立日期,
                            撤銷日期 = a.撤銷日期,
                            部門群組 = a.部門群組,
                        }).ToList();

            mdPADept.SetControl(btnPADept, dept.CopyToDataTable(), "_PADept");
            mdPADept.SelectedValues.Clear();
            btnPADept.Text = "請選擇需計算的部門";
        }
        void SetPAHCODEList()
        {
            List<string> FlagList = new List<string>() { "-" };
            mdPAHCODE.SetControl(btnPAHocdeList, CodeFunction.GetHcode(FlagList, false).Select(p => new { _hcode = p.Key, 假別代碼 = p.Value }).CopyToDataTable(), "_hcode");
            mdPAHCODE.SelectedValues.Clear();
            btnPAHocdeList.Text = "請選擇計算實勤天數的扣假代碼";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string PAYYMM = txtPAYYMM.Text;
            Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(txtPAYYMM.Text);
            DateTime BDate = sd.FirstDayOfSalary;
            DateTime EDate = sd.LastDayOfSalary;
            DateTime BDate_Att = sd.FirstDayOfAttend;
            DateTime EDate_Att = sd.LastDayOfAttend;
            List<string> PAHCODEList = mdPAHCODE.SelectedValues.ToList();
            CodeFunction.UpdateAppconfig(this.Name, MainForm.COMPANY, "PAHCODEList", string.Join(",", PAHCODEList.Select(p => string.Format("{0}", p))));
            string PASALCODE = cbxPASALCODE.SelectedValue.ToString();
            CodeFunction.UpdateAppconfig(this.Name, MainForm.COMPANY, "PASALCODE", PASALCODE);
            string EnrichYYMM = txtEnrichYYMM.Text;
            string SEQ = txtSeq.Text;
            string Memo = txtMemo.Text;
            List<string> DeptList = mdPADept.SelectedValues.ToList();
            if (DeptList.Count == 0) return;
            var TTSCODE = new string[] { "1", "4", "6" };
            var AttendByNobr = db.ATTEND.Where(p => p.ADATE >= BDate_Att && p.ADATE <= EDate_Att).GroupBy(p => p.NOBR).Select(p => p.Key).ToList();
            DataTable dt = new DataTable();
            List<string> EmployeeList = new List<string>();
            foreach (var item in AttendByNobr.Split(1000))
            {
                var hpbg = (from a in db.Hunya_PABonusGroup
                            join b in db.Hunya_PAGroupCode on a.PAGroupCode equals b.PAGroupCode
                            join c in db.Hunya_PAPersonalAssessment on a.EmployeeID equals c.EmployeeID
                            where item.Contains(a.EmployeeID)
                            && a.YYMM_B.CompareTo(PAYYMM) <= 0 && a.YYMM_E.CompareTo(PAYYMM) >= 0
                            && a.YYMM_B.CompareTo(c.YYMM) <= 0 && a.YYMM_E.CompareTo(c.YYMM) >= 0
                            && c.YYMM == PAYYMM
                            select a.EmployeeID).Distinct().ToList();

                List<string> ttscodeList = new List<string>();
                ttscodeList.Add("1");
                ttscodeList.Add("4");
                ttscodeList.Add("6");

                var sql = from b in db.BASE
                          join bts in db.BASETTS on b.NOBR equals bts.NOBR
                          where hpbg.Contains(b.NOBR)
                          && DeptList.Contains(bts.DEPT)
                          && ttscodeList.Contains(bts.TTSCODE)
                          //&& BDate >= bts.ADATE && BDate <= bts.DDATE.Value
                          && BDate_Att <= bts.DDATE.Value && EDate_Att >= bts.ADATE
                          && !bts.NOWAGE//須計算薪資
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                          select b.NOBR;
                EmployeeList.AddRange(sql.Distinct().ToList());
            }
            object[] PARMS = new object[] { EmployeeList, PAYYMM, BDate, EDate, BDate_Att, EDate_Att, PAHCODEList, PASALCODE, EnrichYYMM, SEQ, Memo };
            BW.RunWorkerAsync(PARMS);
            this.tableLayoutPanel1.Enabled = false;
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext dbBW = new JBModule.Data.Linq.HrDBDataContext();
            object[] parameters = e.Argument as object[];
            List<string> EmployeeListAll = parameters[0] as List<string>;
            string PAYYMM = parameters[1] as string;
            DateTime BDate = (parameters[2] as DateTime?).GetValueOrDefault(DateTime.Today);
            DateTime EDate = (parameters[3] as DateTime?).GetValueOrDefault(DateTime.Today);
            DateTime BDate_Att = (parameters[4] as DateTime?).GetValueOrDefault(DateTime.Today);
            DateTime EDate_Att = (parameters[5] as DateTime?).GetValueOrDefault(DateTime.Today);
            List<string> PAHCODEList = parameters[6] as List<string>;
            string PASALCODE = parameters[7] as string;
            string EnrichYYMM = parameters[8] as string;
            string SEQ = parameters[9] as string;
            string Memo = parameters[10] as string;
            string msg = "";
            try
            {
                foreach (var EmployeeList in EmployeeListAll.Split(1000))
                {
                    JBModule.Data.Factory.Formula.FormulaFunctionCondition cond = new JBModule.Data.Factory.Formula.FormulaFunctionCondition();
                    cond.Parameters = new Dictionary<string, object>();
                    cond.Parameters.Add("EmployeeList", string.Join(",", EmployeeList.Select(p => string.Format("{0}", p))));
                    cond.Parameters.Add("PAHCODEList", string.Join(",", PAHCODEList.Select(p => string.Format("{0}", p))));
                    cond.Parameters.Add("YYMM", PAYYMM);
                    cond.Parameters.Add("BDate", BDate);
                    cond.Parameters.Add("EDate", EDate);
                    cond.Parameters.Add("AttDateB", BDate_Att);
                    cond.Parameters.Add("AttDateE", EDate_Att);
                    cond.Parameters.Add("userid", MainForm.USER_ID);
                    cond.Parameters.Add("comp", MainForm.COMPANY);
                    cond.Parameters.Add("admin", MainForm.ADMIN);
                    var ParamsList = dbBW.AppConfig.Where(p => p.Category == "Hunya_PersonalBonusParams").Select(p => new { p.Code, p.Value }).ToList();
                    foreach (var Parameter in ParamsList)
                        cond.Parameters.Add(Parameter.Code, Parameter.Value);
                    var moduleList = dbBW.AppConfig.Where(p => p.Category == "Hunya_PersonalBonusParamsBySQLFunction").OrderBy(p => p.Sort);
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

                    //var deleteSql = from a in dbBW.Hunya_PAPersonalBonus
                    //                where EmployeeList.Contains(a.EmployeeID)
                    //                && a.YYMM == PAYYMM
                    //                select a;
                    //dbBW.Hunya_PAPersonalBonus.DeleteAllOnSubmit(deleteSql);
                    //dbBW.SubmitChanges();

                    List<JBModule.Data.Linq.Hunya_PAPersonalBonus> bppb = new List<JBModule.Data.Linq.Hunya_PAPersonalBonus>();
                    var PAFunctionList = dbBW.SALFUNCTION.Where(p => p.CALCTYPE == "PA").OrderBy(q => q.SORT).ToList();
                    total = EmployeeList.Count * PAFunctionList.Count();
                    count = 0;
                    foreach (var PAFunction in PAFunctionList)
                    {
                        string Script = PAFunction.SCRIPT;
                        Dictionary<string, string> ScriptParams = new Dictionary<string, string>();
                        ScriptParams.Add("%取得獎金分配權數.應出勤數%", string.Empty);
                        ScriptParams.Add("%取得獎金分配權數.實勤天數%", string.Empty);
                        ScriptParams.Add("%取得獎金分配權數.加班天數%", string.Empty);
                        ScriptParams.Add("%取得獎金分配權數.個人貢獻率數%", string.Empty);
                        ScriptParams.Add("%取得獎金分配權數.個人基數%", string.Empty);
                        ScriptParams.Add("%取得獎金分配權數.個人基數合計%", string.Empty);
                        ScriptParams.Add("%取得獎金分配權數.個人權數%", string.Empty);
                        ScriptParams.Add("%取得獎金分配權數.個人獎金分配權數%", string.Empty);
                        ScriptParams.Add("%取得獎金分配權數.個人獎金分配權數合計%", string.Empty);
                        ScriptParams.Add("%取得獎金分配權數.部門%", string.Empty);
                        ScriptParams.Add("%取得第二段獎金.基本獎金%", string.Empty);
                        ScriptParams.Add("%取得第二段獎金.個人基數合計%", string.Empty);
                        ScriptParams.Add("%取得第二段獎金.個人獎金分配權數合計%", string.Empty);
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
                            DataRow dataRow = (FormulaParams["取得獎金群組"] as DataTable).AsEnumerable().FirstOrDefault(p => p.Field<string>("員工編號") == Employee);
                            BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 100), "正在計算" + Employee + "績效獎金");
                            if (dataRow != null)
                            {
                                string FunctionStr = dataRow.Field<string>("績效獎金公式");
                                List<string> PAFunctionsByEmployee = FunctionStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                                if (PAFunctionsByEmployee.Contains(PAFunction.AUTO.ToString()))
                                {
                                    Script = PAFunction.SCRIPT;
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
                                        JBModule.Data.Linq.Hunya_PAPersonalBonus personalBonus = new JBModule.Data.Linq.Hunya_PAPersonalBonus()
                                        {
                                            EmployeeID = Employee,
                                            YYMM = PAYYMM,
                                            PAFunction = PAFunction.AUTO.ToString(),
                                            Contribute = decimal.TryParse(ScriptParams["%取得獎金分配權數.個人貢獻率數%"], out defDecimal) ? defDecimal : 0M,
                                            AssignWeighting = decimal.TryParse(ScriptParams["%取得獎金分配權數.個人獎金分配權數%"], out defDecimal) ? defDecimal : 0M,
                                            Amount = JBModule.Data.CEncrypt.Number(Math.Round(result == null ? 0 : Decimal.TryParse(result.ToString(), out defDecimal) ? Math.Ceiling(defDecimal) : 0M)),
                                            BasicValue = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得獎金分配權數.個人基數%"], out defDecimal) ? defDecimal : 0M),
                                            PersonalWeighting = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得獎金分配權數.個人權數%"], out defDecimal) ? defDecimal : 0M),
                                            AttendDays = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得獎金分配權數.應出勤數%"], out defDecimal) ? defDecimal : 0M),
                                            RealDays = decimal.TryParse(ScriptParams["%取得獎金分配權數.實勤天數%"], out defDecimal) ? defDecimal : 0M,
                                            OTDays = decimal.TryParse(ScriptParams["%取得獎金分配權數.加班天數%"], out defDecimal) ? defDecimal : 0M,
                                            PADept = ScriptParams["%取得獎金分配權數.部門%"],
                                            BasicBouns = 0M,
                                            TotalBasicValue = 0M,
                                            TotalPersonalWeighting = 0M,
                                            Memo = Memo,
                                            KeyMan = MainForm.USER_NAME,
                                            KeyDate = DateTime.Now,
                                            GID = Guid.NewGuid(),
                                        };
                                        if (PAFunction.SCRIPT.Contains("取得第二段獎金"))
                                        {
                                            personalBonus.BasicBouns = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得第二段獎金.基本獎金%"], out defDecimal) ? defDecimal : 0M);
                                            personalBonus.TotalBasicValue = decimal.TryParse(ScriptParams["%取得第二段獎金.個人基數合計%"], out defDecimal) ? defDecimal : 0M;
                                            personalBonus.TotalPersonalWeighting = decimal.TryParse(ScriptParams["%取得第二段獎金.個人獎金分配權數合計%"], out defDecimal) ? defDecimal : 0M;
                                        }
                                        else
                                        {
                                            personalBonus.BasicBouns = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得獎金群組.基本獎金%"], out defDecimal) ? defDecimal : 0M);
                                            personalBonus.TotalBasicValue = decimal.TryParse(ScriptParams["%取得獎金分配權數.個人基數合計%"], out defDecimal) ? defDecimal : 0M;
                                            personalBonus.TotalPersonalWeighting = decimal.TryParse(ScriptParams["%取得獎金分配權數.個人獎金分配權數合計%"], out defDecimal) ? defDecimal : 0M;
                                        }
                                        //dbBW.Hunya_PAPersonalBonus.InsertOnSubmit(personalBonus);
                                        bppb.Add(personalBonus);
                                    }
                                    catch (Exception evalex)
                                    {
                                        JBModule.Message.DbLog.WriteLog(Employee, Script, this.Name, -1);
                                    }
                                }
                            }
                            count++;
                        }
                        //dbBW.SubmitChanges();
                    }
                    string deleteSql = "DELETE Hunya_PAPersonalBonus WHERE EmployeeID in @EmployeeList and YYMM = @YYMM";
                    object param = new { EmployeeList, YYMM = PAYYMM };
                    string errMsg = "寫入績效獎金異常.";
                    dbBW.BulkInsertWithDelete(dbBW, bppb, deleteSql, param, errMsg);


                    //var enrichDelSql = db.ENRICH.Where(p => p.YYMM == EnrichYYMM && p.SAL_CODE == PASALCODE && p.SEQ == SEQ && EmployeeList.Contains(p.NOBR) && p.IMPORT);
                    //db.ENRICH.DeleteAllOnSubmit(enrichDelSql);
                    //db.SubmitChanges();

                    List<JBModule.Data.Linq.ENRICH> enrich = new List<JBModule.Data.Linq.ENRICH>();
                    total = EmployeeList.Count;
                    count = 0;
                    var bonusLinq = db.Hunya_PAPersonalBonus.Where(p => EmployeeList.Contains(p.EmployeeID) && p.YYMM == PAYYMM).ToList();
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
                                SAL_CODE = PASALCODE,
                                YYMM = EnrichYYMM,
                                SEQ = SEQ,
                                AMT = JBModule.Data.CEncrypt.Number(amt),
                                FA_IDNO = string.Empty,
                                IMPORT = true,
                                KEY_DATE = DateTime.Now,
                                KEY_MAN = MainForm.USER_NAME,
                                MEMO = "由計算績效考核獎金轉入" + (string.IsNullOrEmpty(bonusLinqbyEmp.First().Memo) ? string.Empty : "-" + bonusLinqbyEmp.First().Memo),
                            };
                            //db.ENRICH.InsertOnSubmit(enrichByEmployee);
                            enrich.Add(enrichByEmployee);
                        }
                        count++;
                    }
                    //db.SubmitChanges();
                    deleteSql = "DELETE enrich WHERE nobr in @EmployeeList and YYMM = @YYMM and SAL_CODE = @SAL_CODE and SEQ = @SEQ and IMPORT = 1 ";
                    param = new { EmployeeList, YYMM = EnrichYYMM, SAL_CODE = PASALCODE, SEQ };
                    errMsg = "紅利轉補扣發異常.";
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

        private void txtPAYYMM_Leave(object sender, EventArgs e)
        {
            SetPADeptList();
            txtEnrichYYMM.Text = txtPAYYMM.Text;
        }
    }
}
