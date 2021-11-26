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

namespace JBHR.Dividend.HunyaCustom
{
    public partial class Hunya_DIVDPersonalBonus_Calculator : JBControls.JBForm
    {
        public Hunya_DIVDPersonalBonus_Calculator()
        {
            InitializeComponent();
        }
        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.ApplicationConfigSettings acg = null;
        string topic = "";
        CheckYYMMFormatControl CYYMMFC = new CheckYYMMFormatControl();
        private void Hunya_DIVDPersonalBonus_Calculator_Load(object sender, EventArgs e)
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
            acg = null; acg = new JBModule.Data.ApplicationConfigSettings(this.Name, MainForm.COMPANY);
            acg.CheckParameterAndSetDefault("DIVDSALCODE", "績效獎金代碼", "", "指定轉入補扣發的績效獎金代碼", "ComboBox", "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            SystemFunction.SetComboBoxItems(cbxDIVDSALCODE, CodeFunction.GetSalCode(), true, true, true);
            cbxDIVDSALCODE.SelectedValue = acg.GetConfig("DIVDSALCODE").GetString();

            int YYYY = DateTime.Now.AddYears(-1).Year;
            nudDIVDYYYY.Value = YYYY;
            txtBasicBonus.Text = "0.00";
            SetEmpList();
            nudDIVDYYYY.Focus();
        }
        void SetEmpList()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            int YYYY = (int)nudDIVDYYYY.Value;
            DateTime bdate = new DateTime(YYYY, 1, 1);
            DateTime edate = new DateTime(YYYY, 12, 31);
            var AttendByNobr = db.ATTEND.Where(p => p.ADATE >= bdate && p.ADATE <= edate).GroupBy(p => p.NOBR).Select(p => p.Key).ToList();
            DataTable dt = new DataTable();
            var TTSCODE = new string[] { "1", "4", "6" };
            foreach (var item in AttendByNobr.Split(1000))
            {
                var sql = from b in db.BASE
                          join bts in db.BASETTS on b.NOBR equals bts.NOBR
                          join jl in db.JOBL on bts.JOBL equals jl.JOBL1
                          join mt in db.MTCODE on bts.TTSCODE equals mt.CODE
                          join mt1 in db.MTCODE on b.SEX equals mt1.CODE
                          join result in (
                               from a in db.Hunya_DIVDPersonalAppraisal
                               join b in db.Hunya_DIVDAppraisalCode on a.DIVDAppraisalCode equals b.DIVDAppraisalCode
                               where item.Contains(a.EmployeeID)
                               && a.YYYY == YYYY
                               select new
                               {
                                   員工編號 = a.EmployeeID,
                                   考績年度 = a.YYYY,
                                   考績等第 = b.DIVDAppraisalCode_Name
                               }
                          ) on b.NOBR equals result.員工編號 //into g
                          //from result in g.DefaultIfEmpty()
                          where item.Contains(b.NOBR)
                          && edate >= bts.ADATE && edate <= bts.DDATE.Value
                          && mt.CATEGORY == "TTSCODE"
                          && mt1.CATEGORY == "SEX"
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(bts.SALADR)
                          select new
                          {
                              員工編號 = b.NOBR,
                              員工姓名 = b.NAME_C,
                              考績年度 = result.考績年度.ToString(),
                              考績等第 = result.考績等第,
                              異動狀態 = TTSCODE.Contains(mt.CODE) ? "在職" : mt.NAME,
                              異動日期 = TTSCODE.Contains(mt.CODE) ? null : bts.OUDT != null ? bts.OUDT : bts.STDT != null ? bts.STDT : null,
                              性別 = mt1.NAME,
                              職稱 = bts.JOB1.JOB_DISP + "-" + bts.JOB1.JOB_NAME,
                              職等 = jl.JOBL_DISP + "-" + jl.JOB_NAME,
                              編制部門 = bts.DEPT1.D_NO_DISP + "-" + bts.DEPT1.D_NAME,
                          };
                dt.Merge(sql.ToList().CopyToDataTable());
            }
            mdEmp.SetControl(btnEmp, dt, "員工編號");
            //mdEmp.SelectedValues.Clear();
            //btnEmp.Text = "請選擇需設定的人員";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            int YYYY = (int)nudDIVDYYYY.Value;
            decimal BasicBonus = decimal.Parse(txtBasicBonus.Text);
            DateTime BDate = new DateTime(YYYY,1,1);
            DateTime EDate = new DateTime(YYYY, 12, 31);
            DateTime BDate_Att = new DateTime(YYYY, 1, 1);
            DateTime EDate_Att = new DateTime(YYYY, 12, 31);
            string DIVDSALCODE = cbxDIVDSALCODE.SelectedValue.ToString();
            CodeFunction.UpdateAppconfig(this.Name, MainForm.COMPANY, "DIVDSALCODE", DIVDSALCODE);
            string EnrichYYMM = txtEnrichYYMM.Text;
            string SEQ = txtSeq.Text;
            string Memo = txtMemo.Text;
            List<string> EmployeeList = mdEmp.SelectedValues.ToList();
            if (EmployeeList.Count == 0) return;
            DataTable dt = new DataTable();
            object[] PARMS = new object[] { EmployeeList, YYYY, BasicBonus, BDate, EDate, BDate_Att, EDate_Att, DIVDSALCODE, EnrichYYMM, SEQ, Memo };
            BW.RunWorkerAsync(PARMS);
            this.tableLayoutPanel1.Enabled = false;
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext dbBW = new JBModule.Data.Linq.HrDBDataContext();
            object[] parameters = e.Argument as object[];
            List<string> EmployeeListAll = parameters[0] as List<string>;
            int YYYY = (parameters[1] as int?).Value;
            decimal BasicBonus = (parameters[2] as decimal?).Value;
            int DayOfYear = (new DateTime(YYYY, 12, 31)).DayOfYear;
            DateTime BDate = (parameters[3] as DateTime?).GetValueOrDefault(DateTime.Today);
            DateTime EDate = (parameters[4] as DateTime?).GetValueOrDefault(DateTime.Today);
            DateTime BDate_Att = (parameters[5] as DateTime?).GetValueOrDefault(DateTime.Today);
            DateTime EDate_Att = (parameters[6] as DateTime?).GetValueOrDefault(DateTime.Today);
            string DIVDSALCODE = parameters[7] as string;
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
                    cond.Parameters.Add("YYYY", YYYY);
                    cond.Parameters.Add("BasicBonus", BasicBonus);
                    cond.Parameters.Add("DayOfYear", DayOfYear);
                    cond.Parameters.Add("BDate", BDate);
                    cond.Parameters.Add("EDate", EDate);
                    cond.Parameters.Add("AttDateB", BDate_Att);
                    cond.Parameters.Add("AttDateE", EDate_Att);
                    cond.Parameters.Add("userid", MainForm.USER_ID);
                    cond.Parameters.Add("comp", MainForm.COMPANY);
                    cond.Parameters.Add("admin", MainForm.ADMIN);
                    var ParamsList = dbBW.AppConfig.Where(p => p.Category == "Hunya_DIVDPersonalBonusParams").Select(p => new { p.Code, p.Value }).ToList();
                    foreach (var Parameter in ParamsList)
                        cond.Parameters.Add(Parameter.Code, Parameter.Value);
                    var moduleList = dbBW.AppConfig.Where(p => p.Category == "Hunya_DIVDPersonalBonusParamsBySQLFunction").OrderBy(p => p.Sort);
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

                    //var deleteSql = from a in dbBW.Hunya_DIVDPersonalBonus
                    //                where EmployeeList.Contains(a.EmployeeID)
                    //                && a.YYMM == PAYYMM
                    //                select a;
                    //dbBW.Hunya_DIVDPersonalBonus.DeleteAllOnSubmit(deleteSql);
                    //dbBW.SubmitChanges();

                    List<JBModule.Data.Linq.Hunya_DIVDPersonalBonus> bppb = new List<JBModule.Data.Linq.Hunya_DIVDPersonalBonus>();
                    var DIVDFunctionList = dbBW.SALFUNCTION.Where(p => p.CALCTYPE == "DIVD").OrderBy(q => q.SORT).ToList();
                    total = EmployeeList.Count * DIVDFunctionList.Count();
                    count = 0;
                    foreach (var DIVDFunction in DIVDFunctionList)
                    {
                        string Script = DIVDFunction.SCRIPT;
                        Dictionary<string, string> ScriptParams = new Dictionary<string, string>();
                        ScriptParams.Add("%取得紅利獎金係數.個人分配權數%", string.Empty);
                        ScriptParams.Add("%取得紅利獎金係數.職務權數%", string.Empty);
                        ScriptParams.Add("%取得紅利獎金係數.考績係數%", string.Empty);
                        ScriptParams.Add("%取得紅利獎金係數.在職天數%", string.Empty);
                        ScriptParams.Add("%取得紅利獎金係數.紅利總額%", string.Empty);
                        ScriptParams.Add("%取得紅利獎金係數.總分配權數%", string.Empty);
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
                            Script = DIVDFunction.SCRIPT;
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
                                JBModule.Data.Linq.Hunya_DIVDPersonalBonus personalBonus = new JBModule.Data.Linq.Hunya_DIVDPersonalBonus()
                                {
                                    EmployeeID = Employee,
                                    YYYY = YYYY,
                                    //DIVDFunction = DIVDFunction.AUTO.ToString(),
                                    PersonalWeighting = decimal.TryParse(ScriptParams["%取得紅利獎金係數.個人分配權數%"], out defDecimal) ? defDecimal : 0M,
                                    Amount = JBModule.Data.CEncrypt.Number(Math.Round(result == null ? 0 : Decimal.TryParse(result.ToString(), out defDecimal) ? Math.Ceiling(defDecimal) : 0M)),
                                    JobWeighting = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得紅利獎金係數.職務權數%"], out defDecimal) ? defDecimal : 0M),
                                    DIVDAppraisal = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得紅利獎金係數.考績係數%"], out defDecimal) ? defDecimal : 0M),
                                    OnJobDays = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得紅利獎金係數.在職天數%"], out defDecimal) ? defDecimal : 0M),
                                    BasicBouns = JBModule.Data.CEncrypt.Number(decimal.TryParse(ScriptParams["%取得紅利獎金係數.紅利總額%"], out defDecimal) ? defDecimal : 0M),
                                    TotalPersonalWeighting = decimal.TryParse(ScriptParams["%取得紅利獎金係數.總分配權數%"], out defDecimal) ? defDecimal : 0M,
                                    Memo = Memo,
                                    KeyMan = MainForm.USER_NAME,
                                    KeyDate = DateTime.Now,
                                    GID = Guid.NewGuid(),
                                };
                                //dbBW.Hunya_DIVDPersonalBonus.InsertOnSubmit(personalBonus);
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

                    string deleteSql = "DELETE Hunya_DIVDPersonalBonus WHERE EmployeeID in @EmployeeList and YYYY = @YYYY";
                    object param = new { EmployeeList, YYYY };
                    string errMsg = "寫入紅利獎金異常.";
                    dbBW.BulkInsertWithDelete(dbBW, bppb, deleteSql, param, errMsg);
                    //var enrichDelSql = db.ENRICH.Where(p => p.YYMM == EnrichYYMM && p.SAL_CODE == PASALCODE && p.SEQ == SEQ && EmployeeList.Contains(p.NOBR) && p.IMPORT);
                    //db.ENRICH.DeleteAllOnSubmit(enrichDelSql);
                    //db.SubmitChanges();

                    List<JBModule.Data.Linq.ENRICH> enrich = new List<JBModule.Data.Linq.ENRICH>();
                    total = EmployeeList.Count;
                    count = 0;
                    var bonusLinq = db.Hunya_DIVDPersonalBonus.Where(p => EmployeeList.Contains(p.EmployeeID) && p.YYYY == YYYY).ToList();
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
                                SAL_CODE = DIVDSALCODE,
                                YYMM = EnrichYYMM,
                                SEQ = SEQ,
                                AMT = JBModule.Data.CEncrypt.Number(amt),
                                FA_IDNO = string.Empty,
                                IMPORT = true,
                                KEY_DATE = DateTime.Now,
                                KEY_MAN = MainForm.USER_NAME,
                                MEMO = "由計算員工紅利獎金轉入" + (string.IsNullOrEmpty(bonusLinqbyEmp.First().Memo) ? string.Empty : "-" + bonusLinqbyEmp.First().Memo),
                            };
                            //db.ENRICH.InsertOnSubmit(enrichByEmployee);
                            enrich.Add(enrichByEmployee);
                        }
                        count++;
                    }
                    //db.SubmitChanges();
                    deleteSql = "DELETE enrich WHERE nobr in @EmployeeList and YYMM = @YYMM and SAL_CODE = @SAL_CODE and SEQ = @SEQ and IMPORT = 1 ";
                    param = new { EmployeeList, YYMM = EnrichYYMM, SAL_CODE = DIVDSALCODE, SEQ };
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

        private void nudDIVDYYYY_Leave(object sender, EventArgs e)
        {
            SetEmpList();
        }
    }
}
