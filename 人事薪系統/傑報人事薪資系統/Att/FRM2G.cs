using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal.Core;
using JBHR.BLL.Att;
using JBTools.Extend;
using Dapper;

namespace JBHR.Att
{
    public partial class FRM2G : JBControls.JBForm
    {
        public FRM2G()
        {
            InitializeComponent();
        }
        IEnumerable<JBModule.Data.Linq.OT> otList;
        IEnumerable<JBModule.Data.Linq.ROTE> roteList;
        public FixOtMode FixOtModeType = FixOtMode.CalcByAttCard;
        bool DbLog = false;
        public List<string> ErrorQueue = new List<string>();
        List<JBModule.Data.Linq.OT> FixOTs;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        public bool isContinue = true;
        public int errorCount = 0;
        public bool isFixYymm = false;
        public string FixYymm = "";
        string NOBR_B = "";
        string NOBR_E = "";
        string DEPT_B = "";
        string DEPT_E = "";
        DateTime D1;
        DateTime D2;
        string USER_NAME = "";
        string WORKADR = "";
        bool PROCSUPER = false;
        string ym1 = "", ym2 = "";
        bool CreateAttend = false, CheckTime = false, CheckError = false, CheckFixOt = false, CheckDeleteAttend = false, CheckCreateAbs = false;
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        private void FRM2G_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM2G", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("LateCode", "遲到代碼", ""
               , "指定遲到代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("LateMin", "遲到分鐘", ""
               , "指定遲到分鐘數限制，達到該分鐘數才會產生請假", "TextBox", "0", "String");
            AppConfig.CheckParameterAndSetDefault("EarilyCode", "早退代碼", ""
                , "指定早退代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("EarilyMin", "早退分鐘", ""
               , "指定早退分鐘數限制，達到該分鐘數才會產生請假", "TextBox", "0", "String");
            AppConfig.CheckParameterAndSetDefault("AbsenceCode", "曠職代碼", ""
               , "指定曠職代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("OtBonusException", "加班津貼例外人員", ""
            , "加班津貼例外人員名單，可用逗號分隔", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("GetDateValue", "假日往前檢查天數", "1"
             , "設定假日往前檢查非假日班班別的天數", "TextBox", "", "String");
            var deptData = CodeFunction.GetDeptDisp();
            this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            ptxNobrB.Text = Sal.BaseValue.MinNobr;
            ptxNobrE.Text = Sal.BaseValue.MaxNobr;
            //ptxDeptB.Text = Sal.BaseValue.MinDept;
            //ptxDeptE.Text = Sal.BaseValue.MaxDept;
            SystemFunction.SetComboBoxItems(ptxDeptB, deptData, false);
            SystemFunction.SetComboBoxItems(ptxDeptE, deptData, false);
            //Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(DateTime.Now.Date.ToString("yyyyMM"));
            Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(DateTime.Now.Date);
            txtDateB.Text = Sal.Core.SalaryDate.DateString(sd.FirstDayOfAttend);
            txtDateE.Text = Sal.Core.SalaryDate.DateString(sd.LastDayOfAttend);
            this.ptxDeptB.SelectedValue = deptData.First().Key;
            this.ptxDeptE.SelectedValue = deptData.Last().Key;
            textBoxYYMM.Text = sd.YYMM;
            roteList = db.ROTE.ToList();
        }
        public bool OneDayTrans(object[] parameters)
        {
            DateTime d1, d2;
            d1 = (parameters[0] as DateTime?).Value;
            d2 = (parameters[1] as DateTime?).Value;
            string nobr_b, nobr_e;
            nobr_b = parameters[2].ToString();
            nobr_e = parameters[3].ToString();
            string dept_b, dept_e;
            dept_b = parameters[4].ToString();
            dept_e = parameters[5].ToString();

            NOBR_B = nobr_b;
            NOBR_E = nobr_e;
            DEPT_B = dept_b;
            DEPT_E = dept_e;
            D1 = d1;
            D2 = d2;

            USER_NAME = MainForm.USER_NAME;
            ym1 = D1.ToString("yyyyMM");
            ym2 = D2.ToString("yyyyMM");
            CreateAttend = (parameters[6] as bool?).Value;
            CheckTime = (parameters[7] as bool?).Value;
            CheckError = (parameters[8] as bool?).Value;
            CheckFixOt = (parameters[9] as bool?).Value;
            CheckDeleteAttend = (parameters[10] as bool?).Value;
            //CheckCalBonus = (parameters[11] as bool?).Value;
            string msg = TransFuction(false);
            return true;
        }

        private void btnTran_Click(object sender, EventArgs e)
        {
            DateTime d1, d2;
            d1 = Convert.ToDateTime(txtDateB.Text);
            d2 = Convert.ToDateTime(txtDateE.Text);
            string nobr_b, nobr_e;
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            string dept_b, dept_e;
            dept_b = ptxDeptB.SelectedValue.ToString();
            dept_e = ptxDeptE.SelectedValue.ToString();
            object[] PARMS = new object[] { nobr_b, nobr_e, dept_b, dept_e, d1, d2 };
            NOBR_B = nobr_b;
            NOBR_E = nobr_e;
            DEPT_B = dept_b;
            DEPT_E = dept_e;
            D1 = d1;
            D2 = d2;
            USER_NAME = MainForm.USER_NAME;
            //WORKADR = MainForm.WORKADR;
            //PROCSUPER = MainForm.PROCSUPER;
            ym1 = D1.ToString("yyyyMM");
            ym2 = D2.ToString("yyyyMM");
            CreateAttend = chkRote.Checked;
            CheckTime = chkTime.Checked;
            CheckError = chkError.Checked;
            CheckFixOt = chkFixOt.Checked;
            CheckDeleteAttend = chkDel.Checked;
            CheckCreateAbs = chkCreateAbs.Checked;

            #region 如有鎖檔資料時，提示將不產生固定加班
            if (CheckFixOt)
            {
                var sql = (from a in db.LOCK_WAGE
                           where a.YYMM == textBoxYYMM.Text && a.SEQ == "2" && MainForm.WriteSalaryRules.Where(pp => pp.COMPANY == MainForm.COMPANY).Select(p => p.DATAGROUP).Contains(a.SALADR)
                           select new
                           {
                               計薪年月 = a.YYMM,
                               期別 = a.SEQ,
                               資料群組 = a.SALADR,
                               備註 = a.MENO,
                               登錄者 = a.KEY_MAN,
                               登錄日期 = a.KEY_DATE
                           }).ToList();
                var OtData = (from a in db.ATTEND
                              join b in db.OT on new { a.NOBR, a.ADATE.Date } equals new { b.NOBR, b.BDATE.Date } into OTs
                              from rOt in OTs.DefaultIfEmpty()
                              join c in db.BASETTS on a.NOBR equals c.NOBR
                              join c1 in db.ATTCARD on new { a.NOBR, a.ADATE.Date } equals new { c1.NOBR, c1.ADATE.Date } into ATTCARDs
                              from rAttcard in ATTCARDs
                              join d in db.ROTE on a.ROTE equals d.ROTE1
                              join f in db.BASETTS on a.NOBR equals f.NOBR
                              join g in db.DEPT on f.DEPT equals g.D_NO
                              where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                              && g.D_NO_DISP.CompareTo(DEPT_B) >= 0 && g.D_NO_DISP.CompareTo(DEPT_E) <= 0
                              && a.ADATE >= D1 && a.ADATE <= D2
                              && d.MO_HRS > 0
                              && a.ADATE >= f.ADATE && a.ADATE <= f.DDATE.Value
                              && a.ADATE >= c.ADATE && a.ADATE <= c.DDATE.Value
                              && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(c.SALADR)
                              orderby a.NOBR, a.ADATE
                              select new
                              {
                                  a.NOBR,
                                  c.SALADR,
                              });
                var total = OtData.Where(p => (sql.Count > 0 ? sql.Select(a => a.資料群組).Contains(p.SALADR) : false)).GroupBy(p => p.NOBR).Count();
                if (total > 0 && MessageBox.Show("檢查到有薪資鎖檔，已鎖檔薪資群組將不產生固定加班，是否繼續?" + Environment.NewLine + "選[是]繼續，選[否]取消並顯示已鎖檔資料群組", Resources.All.DialogTitle,
                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                {

                    JBHR.Sal.PreviewForm frm = new JBHR.Sal.PreviewForm();
                    frm.Size = new Size(640, 480);
                    frm.DataTable = sql.CopyToDataTable();
                    frm.Form_Title = "已鎖檔的薪資群組(以2期為主)";
                    frm.ShowDialog();
                    return;
                }
            }
            #endregion

            BW.RunWorkerAsync(PARMS);
            this.panel1.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            string msg = TransFuction(true);
            if (msg == "CancelBW")
            {
                e.Cancel = true;
                return;
            }
            e.Result = msg;
        }

        private string TransFuction(bool backgroudSW)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;
            db = new JBModule.Data.Linq.HrDBDataContext();
            string msg = "";
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM2G", MainForm.COMPANY);
            string[] ExceptionList = AppConfig.GetConfig("OtBonusException").GetString().Split(',');
            int GetDateValue = 0;
            try
            {
                GetDateValue = Convert.ToInt32(AppConfig.GetConfig("GetDateValue").GetString().Trim());
            }
            catch
            {
                msg = "假日往前檢查天數輸入的格式錯誤";
                //MessageBox.Show("假日往前檢查天數輸入的格式錯誤", "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return msg;
            }
            JBModule.Message.TextLog.WriteLog("BLL開始");
            if (DbLog)
                JBModule.Message.DbLog.WriteLog("BLL開始", MainForm.USER_NAME, "FRM2G", 0);
            string[] TTSCODE = new string[] { "1", "4", "6" };
            JBModule.Message.TextLog.WriteLog("撈資料");
            if (DbLog)
                JBModule.Message.DbLog.WriteLog("撈資料", MainForm.USER_NAME, "FRM2G", 0);
            var basettsList = (from b in db.BASETTS
                                   //join b in db.BASETTS on bts.NOBR equals b.NOBR
                               join c in db.DEPT on b.DEPT equals c.D_NO
                               join j in db.JOB on b.JOB equals j.JOB1
                               where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                               //&& DateTime.Today >= bts.ADATE && DateTime.Today <= bts.DDATE.Value
                               && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                               && b.ADATE <= D2 && b.DDATE.Value >= D1
                               && TTSCODE.Contains(b.TTSCODE)
                               //&& db.GetFilterByNobr(b.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                               select new
                               {
                                   b.NOBR,
                                   adate = b.ADATE > D1 ? b.ADATE : D1,
                                   ddate = b.DDATE.Value <= D2 ? b.DDATE.Value : D2,
                                   b.DEPTS,
                                   b.CALOT,
                                   j.JOB_DISP
                               }).ToList();//符合條件的員工
            var empList = basettsList.Select(p => p.NOBR).Distinct().ToList();
            //調班資料
            var roteChgList = (from a in db.ROTECHG
                               where a.ADATE >= D1 && a.ADATE <= D2
                               && db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               select a).ToList();
            var roteList = (from rr in db.ROTE select rr).ToList();//班別代碼
            int count = basettsList.Count();
            var attendList = (from a in db.ATTEND where a.ADATE >= D1 && a.ADATE <= D2 select a).ToList();//出勤資料
            JBModule.Message.TextLog.WriteLog("開始計算");
            if (DbLog)
                JBModule.Message.DbLog.WriteLog("開始計算", USER_NAME, "BLL.CardTransAttend", 0);
            if (CreateAttend || CheckTime || CheckError || CheckFixOt || CheckDeleteAttend)
            {
                int i = 0;
                if (CreateAttend)
                {
                    string SessionId = MainForm.USER_ID + DateTime.Now.ToString("yyyyMMddHHmmss");
                    JBModule.Message.TextLog.WriteLog("產生出勤資料：" + SessionId);
                    if (backgroudSW)
                        BW.ReportProgress(0, "產生出勤資料.");
                    var AttTotalCount = Math.Ceiling((decimal)empList.Count() / (decimal)300);
                    int AttNowCount = 0;
                    foreach (var item in empList.Split(300))
                    {
                        AttNowCount++;
                        if (backgroudSW)
                            BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(AttNowCount) / Convert.ToDecimal(AttTotalCount) * 100), "正在產生出勤資料");
                        if (backgroudSW && this.BW.CancellationPending) return "CancelBW"; // BackGroudWorker return Cancel

                        AttendanceGenerator generator = new AttendanceGenerator(item, D1, D2);
                        generator.KeyMan = MainForm.USER_NAME;
                        generator.Generate();
                    }
                    JBModule.Message.TextLog.WriteLog("產生出勤資料完成：" + SessionId);
                    if (backgroudSW)
                        BW.ReportProgress(100, "產生出勤資料完成.");
                }
                if (CheckTime || CheckError)
                {
                    Delete(NOBR_B, NOBR_E, DEPT_B, DEPT_E, D1, D2);
                    //this.Report("正在執行刷卡轉出勤", 100);
                    //Dll.Att.TransCard(NOBR_B, NOBR_E, DEPT_B, DEPT_E, D1, D2, USER_NAME, CheckTime, CheckError, true);
                    Dal.Dao.Att.TransCardDao tc = new Dal.Dao.Att.TransCardDao(db.Connection);
                    if (backgroudSW)
                        tc.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(tc_StatusChanged);
                    tc.TransCard(NOBR_B, NOBR_E, DEPT_B, DEPT_E, D1, D2, USER_NAME, CheckTime, CheckError, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);

                    if (backgroudSW && this.BW.CancellationPending) return "CancelBW"; // BackGroudWorker return Cancel

                    JBModule.Data.Service.LaborEventLawAbnormalDetectorService laborEventLawAbnormalDetectorService = new JBModule.Data.Service.LaborEventLawAbnormalDetectorService(db);
                    laborEventLawAbnormalDetectorService.UserName = MainForm.USER_NAME;
                    laborEventLawAbnormalDetectorService.Run(empList, D1, D2);

                    if (backgroudSW && this.BW.CancellationPending) return "CancelBW"; // BackGroudWorker return Cancel
                }
                db = new JBModule.Data.Linq.HrDBDataContext();

                if (CheckFixOt)
                {
                    db = new JBModule.Data.Linq.HrDBDataContext();
                    db.CommandTimeout = 240;
                    if (backgroudSW)
                        BW.ReportProgress(100, "正在執行固定加班計算");
                    JBModule.Message.TextLog.WriteLog("固定加班");

                    var sql = (from a in db.LOCK_WAGE
                               where a.YYMM == textBoxYYMM.Text && a.SEQ == "2" && MainForm.WriteSalaryRules.Where(pp => pp.COMPANY == MainForm.COMPANY).Select(p => p.DATAGROUP).Contains(a.SALADR)
                               select a.SALADR).ToList();

                    string delete_cmd = "delete ot where bdate between {0} and {1} and syscreat=1 and "
                                        + " exists(select * from basetts b join dept c on b.dept=c.d_no where b.nobr=ot.nobr "
                                        + " and ot.bdate between b.adate and b.ddate and b.nobr between {3} and {4}"
                                        + " and c.d_no_disp between {5} and {6})"
                                        + " and " + Sal.Function.GetFilterCmdByNobrOfWrite("ot.nobr");
                    if (sql.Count > 0)
                        delete_cmd += "and exists (select * from basetts BTS where BTS.NOBR=ot.nobr AND CONVERT(DATETIME,CONVERT(NVARCHAR(50), GETDATE(),101)) BETWEEN BTS.ADATE AND BTS.DDATE　and BTS.SALADR not in (" + string.Join(",", sql.Select(p => string.Format("'{0}'", p))) + "))";
                    object[] parms = new object[] { D1, D2, FixYymm, NOBR_B, NOBR_E, DEPT_B, DEPT_E };
                    db.ExecuteCommand(delete_cmd, parms);//不管如何先刪除，如果有改掉rote的固定加班時數，才會正確
                    var OtData = (from a in db.ATTEND
                                  join b in db.OT on new { a.NOBR, a.ADATE.Date } equals new { b.NOBR, b.BDATE.Date } into OTs
                                  from rOt in OTs.DefaultIfEmpty()
                                  join c in db.BASETTS on a.NOBR equals c.NOBR
                                  join c1 in db.ATTCARD on new { a.NOBR, a.ADATE.Date } equals new { c1.NOBR, c1.ADATE.Date } into ATTCARDs
                                  from rAttcard in ATTCARDs
                                  join d in db.ROTE on a.ROTE equals d.ROTE1
                                  join f in db.BASETTS on a.NOBR equals f.NOBR
                                  join g in db.DEPT on f.DEPT equals g.D_NO
                                  //join x in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals x.NOBR
                                  where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                                  && g.D_NO_DISP.CompareTo(DEPT_B) >= 0 && g.D_NO_DISP.CompareTo(DEPT_E) <= 0
                                  && a.ADATE >= D1 && a.ADATE <= D2
                                  && d.MO_HRS > 0
                                  && a.ADATE >= f.ADATE && a.ADATE <= f.DDATE.Value
                                  && a.ADATE >= c.ADATE && a.ADATE <= c.DDATE.Value
                                  //&& db.GetFilterByNobr(f.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                  && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(c.SALADR)
                                  orderby a.NOBR, a.ADATE
                                  select new
                                  {
                                      a.NOBR,
                                      a.ADATE,
                                      a.ROTE,
                                      OTs = OTs.Where(p => !p.SYSCREAT),
                                      FixOTs = OTs.Where(p => p.SYSCREAT),
                                      ATTCARDs,
                                      f.DEPTS,
                                      f.CALOT,
                                      //BASETTS = f
                                      c.SALADR,
                                  }).ToList();
                    i = 0;
                    var total = OtData.Where(p => (sql.Count <= 0 || !sql.Contains(p.SALADR))).GroupBy(p => p.NOBR).Count();
                    FixOTs = new List<JBModule.Data.Linq.OT>();
                    if (db.Connection.State != System.Data.ConnectionState.Open) db.Connection.Open();

                    //string tmp_nobr = "";
                    foreach (var row in OtData.Where(p => (sql.Count <= 0 || !sql.Contains(p.SALADR))).GroupBy(p => p.NOBR))
                    {
                        i++;
                        if (backgroudSW)
                            BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(i) / Convert.ToDecimal(total) * 100), "正在產生" + row.Key + "固定加班");
                        if (backgroudSW && this.BW.CancellationPending) return "CancelBW"; // BackGroudWorker return Cancel
                        foreach (var r in row)
                        {
                            try
                            {
                                FixOT(r.NOBR, r.ADATE, r.ROTE, r.OTs, r.FixOTs.FirstOrDefault(), r.ATTCARDs, r.DEPTS, r.CALOT);
                                db.SubmitChanges();
                            }
                            catch (Exception ex)
                            {
                                JBModule.Message.TextLog.WriteLog(ex);
                            }
                        }
                    }
                }

                if (CheckCreateAbs)
                {
                    if (backgroudSW)
                        BW.ReportProgress(100, "正在執行產生請假");
                    JBModule.Message.TextLog.WriteLog("刪除產生請假");
                    Delete(NOBR_B, NOBR_E, DEPT_B, DEPT_E, D1, D2);
                    param p = new param();
                    p.DateB = D1;
                    p.DateE = D2;
                    p.DEPTB = DEPT_B;
                    p.DEPTE = DEPT_E;
                    p.NOBRB = NOBR_B;
                    p.NOBRE = NOBR_E;
                    p.YYMM = "";
                    CreateABS(p);
                    if (backgroudSW && this.BW.CancellationPending) return "CancelBW"; // BackGroudWorker return Cancel
                }
                var sqlATTCARD = (from a in db.ATTCARD
                                  join b in db.BASETTS on a.NOBR equals b.NOBR
                                  join c in db.DEPT on b.DEPT equals c.D_NO
                                  where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                                  && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                                  && a.ADATE >= D1 && a.ADATE <= D2
                                  //&& db.GetFilterByNobr(b.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                  && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                                  select new { a.NOBR, a.ADATE, a.T1, a.T2 }).ToList();
                List<string> yearestList = new List<string>();
                yearestList.Add("1");
                yearestList.Add("3");
                yearestList.Add("5");
                yearestList.Add("7");
                var sqlABS = (from a in db.ABS
                              join b in db.BASETTS on a.NOBR equals b.NOBR
                              join c in db.DEPT on b.DEPT equals c.D_NO
                              join d in db.HCODE on a.H_CODE equals d.H_CODE
                              where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                              && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                              && a.BDATE >= b.ADATE && a.BDATE <= b.DDATE.Value
                              && a.BDATE >= D1 && a.BDATE <= D2
                              && d.FLAG == "-"
                              //&& !yearestList.Contains(d.YEAR_REST)
                              && d.SORT != 0//排除失效代碼
                              //&& db.GetFilterByNobr(b.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                              && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                              select new { a.NOBR, a.BDATE, a.BTIME, a.ETIME, a.TOL_HOURS, d.UNIT, d.EF_NIGHT, d.EFF_FOOD }).ToList();
                var sqlOT = (from a in db.OT
                             join b in db.BASETTS on a.NOBR equals b.NOBR
                             join c in db.DEPT on b.DEPT equals c.D_NO
                             where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                             && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                             && a.BDATE >= b.ADATE && a.BDATE <= b.DDATE.Value
                             && a.BDATE >= D1 && a.BDATE <= D2
                             //&& db.GetFilterByNobr(b.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                             && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                             select new { a.NOBR, a.BDATE, a.BTIME, a.ETIME, a.TOT_HOURS, a.OT_ROTE, a.YYMM }).ToList();
                var sqlABS1 = (from a in db.ABS1
                               join b in db.BASETTS on a.NOBR equals b.NOBR
                               join c in db.DEPT on b.DEPT equals c.D_NO
                               join d in db.HCODE on a.H_CODE equals d.H_CODE
                               where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                               && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                               && a.BDATE >= b.ADATE && a.BDATE <= b.DDATE.Value
                               && a.BDATE >= D1 && a.BDATE <= D2
                               && d.FLAG == "-"
                               //&& !yearestList.Contains(d.YEAR_REST)
                               //&& d.SORT != 0//排除失效代碼
                               //&& db.GetFilterByNobr(b.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                               select new { a.NOBR, a.BDATE, a.BTIME, a.ETIME, a.TOL_HOURS, d.UNIT }).ToList();
                var sqlATTEND = (from a in db.ATTEND
                                 join b in db.BASETTS on a.NOBR equals b.NOBR
                                 join c in db.DEPT on b.DEPT equals c.D_NO
                                 join d in db.BASE on a.NOBR equals d.NOBR
                                 join f in db.ROTE on a.ROTE equals f.ROTE1
                                 join g in db.EMPCD on b.EMPCD equals g.EMPCD1
                                 where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                                 && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                                  && a.ADATE >= b.ADATE && a.ADATE <= b.DDATE.Value
                                 && a.ADATE >= D1 && a.ADATE <= D2
                                 //&& db.GetFilterByNobr(b.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                 && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                                 select new { ATTEND = a, d.COUNT_MA, b.DI, ROTE = f, g.FORMAL, b.DEPTS, b.CALOT }).ToList();
                JBModule.Message.TextLog.WriteLog("計算出勤時數");
                //BW.ReportProgress(100, "正在計算出勤時數");
                var totalcount = sqlATTEND.Count();
                int nowcount = 0;
                foreach (var it in sqlATTEND)
                {
                    nowcount++;
                    if (backgroudSW)
                        BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(nowcount) / Convert.ToDecimal(totalcount) * 100), "正在計算" + it.ATTEND.NOBR + "出勤時數");
                    if (backgroudSW && this.BW.CancellationPending) return "CancelBW"; // BackGroudWorker return Cancel
                    it.ATTEND.NIGAMT = 0;
                    it.ATTEND.FOODAMT = 0;
                    it.ATTEND.SPECAMT = 0;
                    it.ATTEND.ATT_HRS = 0;
                    it.ATTEND.REL_HRS = 0;
                    var attcardOfNobr = from a in sqlATTCARD where a.NOBR == it.ATTEND.NOBR && a.ADATE == it.ATTEND.ADATE select a;
                    var absOfNobrDateNight = from a in sqlABS where a.NOBR == it.ATTEND.NOBR && a.BDATE == it.ATTEND.ADATE && !a.EF_NIGHT select a;
                    var absOfNobrDateFood = from a in sqlABS where a.NOBR == it.ATTEND.NOBR && a.BDATE == it.ATTEND.ADATE && !a.EFF_FOOD select a;
                    var abs1OfNobrDate = from a in sqlABS1 where a.NOBR == it.ATTEND.NOBR && a.BDATE == it.ATTEND.ADATE select a;

                    Dictionary<string, string> RestDic = new Dictionary<string, string>();
                    if (it.ROTE.RES_B_TIME.Trim().Length > 0 && it.ROTE.RES_E_TIME.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.RES_B_TIME))
                        RestDic.Add(it.ROTE.RES_B_TIME, it.ROTE.RES_E_TIME);
                    if (it.ROTE.RES_B1_TIME.Trim().Length > 0 && it.ROTE.RES_E1_TIME.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.RES_B1_TIME))
                        RestDic.Add(it.ROTE.RES_B1_TIME, it.ROTE.RES_E1_TIME);
                    if (it.ROTE.RES_B2_TIME.Trim().Length > 0 && it.ROTE.RES_E2_TIME.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.RES_B2_TIME))
                        RestDic.Add(it.ROTE.RES_B2_TIME, it.ROTE.RES_E2_TIME);
                    if (it.ROTE.RES_B3_TIME.Trim().Length > 0 && it.ROTE.RES_E3_TIME.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.RES_B3_TIME))
                        RestDic.Add(it.ROTE.RES_B3_TIME, it.ROTE.RES_E3_TIME);
                    if (it.ROTE.RES_B4_TIME.Trim().Length > 0 && it.ROTE.RES_E4_TIME.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.RES_B4_TIME))
                        RestDic.Add(it.ROTE.RES_B4_TIME, it.ROTE.RES_E4_TIME);

                    if (attcardOfNobr.Any() || absOfNobrDateNight.Any())//有刷卡或是有請有津貼的假
                    {
                        var rAttCard = attcardOfNobr.FirstOrDefault();

                        if (rAttCard != null && rAttCard.T1.Trim().Length > 0 && rAttCard.T2.Trim().Length > 0)
                        {
                            JBTools.Intersection itsReal = new JBTools.Intersection();
                            itsReal.Inert(rAttCard.T1, rAttCard.T2);
                            decimal RealHours = itsReal.GetHours();
                            decimal RestHrs = 0;
                            foreach (var res in RestDic)
                            {
                                JBTools.Intersection itsRest = new JBTools.Intersection();
                                itsRest.Inert(rAttCard.T1, rAttCard.T2);
                                itsRest.Inert(res.Key, res.Value);
                                RestHrs += itsRest.GetHours();
                            }
                            RealHours -= RestHrs;
                            if (abs1OfNobrDate.Any())//如果有公出，需判斷有無交集
                            {
                                JBTools.Intersection itsAbs1 = new JBTools.Intersection();
                                itsAbs1.Inert(abs1OfNobrDate.First().BTIME, abs1OfNobrDate.First().ETIME);//重算，避免入的時數不對
                                decimal RestHrs1 = 0;
                                foreach (var res in RestDic)
                                {
                                    JBTools.Intersection itsRest1 = new JBTools.Intersection();
                                    itsRest1.Inert(abs1OfNobrDate.First().BTIME, abs1OfNobrDate.First().ETIME);
                                    itsRest1.Inert(res.Key, res.Value);
                                    RestHrs1 += itsRest1.GetHours();
                                }

                                JBTools.Intersection its = new JBTools.Intersection();//兩筆時段的交集
                                its.Inert(abs1OfNobrDate.First().BTIME, abs1OfNobrDate.First().ETIME);
                                its.Inert(rAttCard.T1, rAttCard.T2);
                                decimal RestHrs2 = 0;
                                foreach (var res in RestDic)//扣掉交集時段內的休息時間
                                {
                                    JBTools.Intersection itsRest2 = new JBTools.Intersection();
                                    itsRest2.Inert(abs1OfNobrDate.First().BTIME, abs1OfNobrDate.First().ETIME);
                                    itsRest2.Inert(rAttCard.T1, rAttCard.T2);
                                    itsRest2.Inert(res.Key, res.Value);
                                    RestHrs2 += itsRest2.GetHours();
                                }

                                RealHours = RealHours + (itsAbs1.GetHours() - RestHrs) - (its.GetHours() - RestHrs2);//聯集=時段A+時段B-AB交集
                            }
                            it.ATTEND.REL_HRS = JBTools.NumbericConvert.RangeInterval(RealHours, 0.25M, JBTools.NumbericConvert.DigitalMode.Floor);
                        }
                        else if (abs1OfNobrDate.Any())//刷卡不完整
                        {
                            decimal RealHours = 0;

                            JBTools.Intersection itsAbs1 = new JBTools.Intersection();
                            itsAbs1.Inert(abs1OfNobrDate.First().BTIME, abs1OfNobrDate.First().ETIME);//重算，避免入的時數不對
                            decimal RestHrs1 = 0;
                            foreach (var res in RestDic)
                            {
                                JBTools.Intersection itsRest1 = new JBTools.Intersection();
                                itsRest1.Inert(abs1OfNobrDate.First().BTIME, abs1OfNobrDate.First().ETIME);
                                itsRest1.Inert(res.Key, res.Value);
                                RestHrs1 += itsRest1.GetHours();
                            }
                            RealHours = itsAbs1.GetHours() - RestHrs1;
                            it.ATTEND.REL_HRS = JBTools.NumbericConvert.RangeInterval(RealHours, 0.25M, JBTools.NumbericConvert.DigitalMode.Floor);
                        }
                        if (rAttCard != null && rAttCard.T1.Trim().Length > 0 && rAttCard.T2.Trim().Length > 0 && !CodeFunction.GetHolidayRoteList().Contains(it.ATTEND.ROTE))
                        {
                            it.ATTEND.ATT_HRS = it.ROTE.DK_HRS;
                            it.ATTEND.ATT_HRS -= (it.ATTEND.LATE_MINS / 60M);
                            it.ATTEND.ATT_HRS -= (it.ATTEND.E_MINS / 60M);
                            if (it.ATTEND.ABS) it.ATTEND.ATT_HRS = 0;
                            var absOfNobrDate = sqlABS.Where(pp => pp.NOBR == it.ATTEND.NOBR && pp.BDATE == it.ATTEND.ADATE);
                            if (absOfNobrDate.Any())
                            {
                                foreach (var rr in absOfNobrDate)
                                {
                                    if (rr.UNIT == "天")
                                        it.ATTEND.ATT_HRS -= rr.TOL_HOURS * it.ROTE.WK_HRS;
                                    else
                                        it.ATTEND.ATT_HRS -= rr.TOL_HOURS;
                                }
                            }
                            if (it.ATTEND.ATT_HRS < 0) it.ATTEND.ATT_HRS = 0;
                            it.ATTEND.ATT_HRS = JBTools.NumbericConvert.RangeInterval(it.ATTEND.ATT_HRS, 0.25M, JBTools.NumbericConvert.DigitalMode.Floor);
                            if (it.ATTEND.ATT_HRS > it.ROTE.WK_HRS) it.ATTEND.ATT_HRS = it.ROTE.WK_HRS;//不可超過
                        }
                    }
                    else if (abs1OfNobrDate.Any())//沒有刷卡紀錄
                    {
                        decimal RealHours = 0;

                        JBTools.Intersection itsAbs1 = new JBTools.Intersection();
                        itsAbs1.Inert(abs1OfNobrDate.First().BTIME, abs1OfNobrDate.First().ETIME);//重算，避免入的時數不對
                        decimal RestHrs1 = 0;
                        foreach (var res in RestDic)
                        {
                            JBTools.Intersection itsRest1 = new JBTools.Intersection();
                            itsRest1.Inert(abs1OfNobrDate.First().BTIME, abs1OfNobrDate.First().ETIME);
                            itsRest1.Inert(res.Key, res.Value);
                            RestHrs1 += itsRest1.GetHours();
                        }
                        RealHours = itsAbs1.GetHours() - RestHrs1;
                        it.ATTEND.REL_HRS = JBTools.NumbericConvert.RangeInterval(RealHours, 0.25M, JBTools.NumbericConvert.DigitalMode.Floor);
                    }
                    decimal otHrs = 0;
                    Dictionary<string, string> restList = new Dictionary<string, string>();
                    if (it.ROTE.RES_B_TIME.Trim().Length > 0 && it.ROTE.RES_E_TIME.Trim().Length > 0)
                        restList.Add(it.ROTE.RES_B_TIME, it.ROTE.RES_E_TIME);
                    else if (it.ROTE.RES_B1_TIME.Trim().Length > 0 && it.ROTE.RES_E1_TIME.Trim().Length > 0)
                        restList.Add(it.ROTE.RES_B1_TIME, it.ROTE.RES_E1_TIME);
                    else if (it.ROTE.RES_B2_TIME.Trim().Length > 0 && it.ROTE.RES_E2_TIME.Trim().Length > 0)
                        restList.Add(it.ROTE.RES_B2_TIME, it.ROTE.RES_E2_TIME);
                    else if (it.ROTE.RES_B3_TIME.Trim().Length > 0 && it.ROTE.RES_E3_TIME.Trim().Length > 0)
                        restList.Add(it.ROTE.RES_B3_TIME, it.ROTE.RES_E3_TIME);
                    else if (it.ROTE.RES_B4_TIME.Trim().Length > 0 && it.ROTE.RES_E4_TIME.Trim().Length > 0)
                        restList.Add(it.ROTE.RES_B4_TIME, it.ROTE.RES_E4_TIME);
                    var otOfData = sqlOT.Where(p => p.NOBR == it.ATTEND.NOBR && p.BDATE == it.ATTEND.ADATE);
                    if (otOfData.Any())
                        it.ATTEND.ATT_HRS += otOfData.Sum(p => p.TOT_HOURS);
                }
                db.SubmitChanges();
                JBModule.Message.TextLog.WriteLog("計算出勤時數完成.");
                if (backgroudSW)
                    BW.ReportProgress(100, "計算出勤時數完成.");
                List<JBModule.Data.Linq.SALATT> salattList = new List<JBModule.Data.Linq.SALATT>();
                RoteCalculation rc = new RoteCalculation();
                var RefDic = GetRefValue("ATT");
                Dictionary<string, Dictionary<string, string>> SalFuncParams = new Dictionary<string, Dictionary<string, string>>();
                Dictionary<string, object> SalFuncValue = new Dictionary<string, object>();
                nowcount = 0;
                var bc = rc.CreateAttendBonusCalc();
                var ob = rc.CreateOtBonusCalc();//取得加班須判別的津貼

                var sqlAttendOfNobr = sqlATTEND.GroupBy(p => p.ATTEND.NOBR).ToList();
                foreach (var item in sqlAttendOfNobr)
                {
                    var sqlATTCARDOfNobr = sqlATTCARD.Where(p => p.NOBR == item.Key);
                    var sqlOTOfNobr = sqlOT.Where(p => p.NOBR == item.Key);
                    foreach (var it in item)
                    {
                        nowcount++;
                        if (backgroudSW)
                            BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(nowcount) / Convert.ToDecimal(totalcount) * 100), "正在計算" + it.ATTEND.NOBR + "班別及加班津貼");
                        if (backgroudSW && this.BW.CancellationPending) return "CancelBW"; // BackGroudWorker return Cancel
                        //var attcardOfNobr = from a in sqlATTCARD where a.NOBR == it.ATTEND.NOBR && a.ADATE == it.ATTEND.ADATE select a;
                        var attcardOfNobr = sqlATTCARDOfNobr.Where(p => p.ADATE == it.ATTEND.ADATE).FirstOrDefault();
                        var absOfNobrDateNight = from a in sqlABS where a.NOBR == it.ATTEND.NOBR && a.BDATE == it.ATTEND.ADATE && !a.EF_NIGHT select a;
                        var bts = basettsList.Where(p => p.NOBR == item.Key && p.adate <= it.ATTEND.ADATE && p.ddate >= it.ATTEND.ADATE).FirstOrDefault();
                        var job = bts != null ? bts.JOB_DISP : string.Empty;
                        if (attcardOfNobr != null || absOfNobrDateNight.Any())
                        {
                            var attcard = attcardOfNobr;

                            string T1 = "4800", T2 = "0000";
                            if (attcard != null)
                            {
                                if (attcard.T1.Trim().Length > 0)
                                    T1 = attcard.T1;
                                if (attcard.T2.Trim().Length > 0)
                                    T2 = attcard.T2;
                            }
                            var abs = absOfNobrDateNight.FirstOrDefault();
                            if (abs != null)
                            {
                                if (abs.BTIME.CompareTo(T1) < 0)
                                    T1 = abs.BTIME;
                                if (abs.ETIME.CompareTo(T2) > 0)
                                    T2 = abs.ETIME;
                            }
                            bc.ConditionList.Clear();
                            bc.ConditionList.Add(Sal.Core.OtBonusCalc.COUNT_MA, it.COUNT_MA ? "1" : "0");
                            bc.ConditionList.Add(Sal.Core.OtBonusCalc.ORINGINAL_ROTE, it.ROTE.ROTE_DISP);
                            bc.ConditionList.Add(Sal.Core.OtBonusCalc.ATT_ROTE, it.ROTE.ROTE_DISP);
                            bc.ConditionList.Add(Sal.Core.OtBonusCalc.DI, it.DI);
                            bc.ConditionList.Add(Sal.Core.OtBonusCalc.BTIME, it.ROTE.ON_TIME);
                            bc.ConditionList.Add(Sal.Core.OtBonusCalc.ETIME, it.ROTE.OFF_TIME);
                            bc.ConditionList.Add(Sal.Core.OtBonusCalc.JOB, job);

                            var rote = it.ROTE;

                            if (CodeFunction.GetHolidayRoteList().Contains(rote.ROTE1))
                            {
                                var otOfNobrDate = sqlOT.Where(p => p.NOBR == it.ATTEND.NOBR && p.BDATE == it.ATTEND.ADATE);
                                if (otOfNobrDate.Any())
                                {
                                    rote = roteList.Single(p => p.ROTE1 == otOfNobrDate.First().OT_ROTE);
                                }
                            }

                            List<JBModule.Data.Linq.SALATT> BonusList = new List<JBModule.Data.Linq.SALATT>();

                            BonusList = bc.Calc(T1, T2, rote, false, it.ATTEND.NOBR, it.ATTEND.ADATE, "FRM2G", "RoteByATT", RefDic, ref SalFuncParams, ref SalFuncValue);
                            salattList.AddRange(BonusList);

                            it.ATTEND.NIGAMT = (from N in BonusList where N.SAL_CODE == rote.NIGHTSALCD select N).Sum(p => p.AMT);
                            it.ATTEND.FOODAMT = (from N in BonusList where N.SAL_CODE == rote.FOODSALCD select N).Sum(p => p.AMT);
                            it.ATTEND.SPECAMT = (from N in BonusList where N.SAL_CODE == rote.SPECSALCD select N).Sum(p => p.AMT);

                            var otOfWork = from a in sqlOT where a.NOBR == it.ATTEND.NOBR && a.BDATE == it.ATTEND.ADATE select a;
                            foreach (var rr in otOfWork)
                            {
                                var rote1 = roteList.Where(pp => pp.ROTE1 == rr.OT_ROTE).FirstOrDefault();
                                if (rote1 != null)
                                {
                                    //var ob = rc.CreateOtBonusCalc();//取得加班須判別的津貼
                                    ob.ConditionList.Clear();
                                    ob.ConditionList.Add(Sal.Core.OtBonusCalc.COUNT_MA, it.COUNT_MA ? "1" : "0");
                                    ob.ConditionList.Add(Sal.Core.OtBonusCalc.ORINGINAL_ROTE, it.ROTE.ROTE_DISP);
                                    ob.ConditionList.Add(Sal.Core.OtBonusCalc.ATT_ROTE, rote1.ROTE_DISP);
                                    ob.ConditionList.Add(Sal.Core.OtBonusCalc.DI, it.DI);
                                    ob.ConditionList.Add(Sal.Core.OtBonusCalc.BTIME, rr.BTIME);
                                    ob.ConditionList.Add(Sal.Core.OtBonusCalc.ETIME, rr.ETIME);
                                    ob.ConditionList.Add(Sal.Core.OtBonusCalc.JOB, job);
                                    BonusList = ob.Calc(rr.BTIME, rr.ETIME, rote, false, it.ATTEND.NOBR, it.ATTEND.ADATE, "FRM2G", "RoteByOT", RefDic, ref SalFuncParams, ref SalFuncValue);
                                    salattList.AddRange(BonusList);
                                }
                            }
                        }
                    }
                }
                JBModule.Message.TextLog.WriteLog("計算津貼資料完成.");
                JBModule.Message.TextLog.WriteLog("寫入津貼資料.");
                if (backgroudSW)
                {
                    BW.ReportProgress(100, "計算津貼資料完成.");
                    BW.ReportProgress(0, "寫入津貼資料.");
                }

                List<string> CalcTypeList = new List<string>();
                CalcTypeList.Add("RoteByATT");
                CalcTypeList.Add("RoteByOt");
                string deleteSql = "DELETE SALATT WHERE ADATE BETWEEN @BeginDate and @EndDate and CALC_TYPE in @CalcTypeList and NOBR IN @item";
                string errMsg = "寫入津貼資料異常.";
                foreach (var item in empList.Split(1000))
                {
                    object param = new { BeginDate = D1, EndDate = D2, CalcTypeList, item };
                    db.BulkInsertWithDelete(db, salattList.Where(p => item.Contains(p.NOBR)), deleteSql, param, errMsg);
                }

                JBModule.Message.TextLog.WriteLog("刪除離職出勤");
                if (backgroudSW)
                    BW.ReportProgress(100, "正在執行刪除離職出勤");
                if (DbLog)
                    JBModule.Message.DbLog.WriteLog("刪除離職出勤", USER_NAME, "BLL.CardTransAttend", 0);
                if (CheckDeleteAttend)
                {
                    List<string> ttscodeList = new List<string>();
                    ttscodeList.Add("2");
                    ttscodeList.Add("3");
                    ttscodeList.Add("5");
                    object[] parms = new object[] { };
                    db.ExecuteCommand("DELETE ATTEND WHERE EXISTS(SELECT * FROM BASETTS where ATTEND.ADATE BETWEEN BASETTS.ADATE AND BASETTS.DDATE AND TTSCODE IN (2,3,5) AND ATTEND.NOBR=BASETTS.NOBR) AND " + Sal.Function.GetFilterCmdByNobrOfWrite("attend.nobr"), parms);
                    if (backgroudSW && this.BW.CancellationPending) return "CancelBW"; // BackGroudWorker return Cancel
                }
            }
            if (backgroudSW)
                BW.ReportProgress(100, "完成");
            JBModule.Message.TextLog.WriteLog("完成");
            if (DbLog)
                JBModule.Message.DbLog.WriteLog("完成", USER_NAME, "BLL.CardTransAttend", 0);
            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            //e.Result = msg;
            return msg;
        }


        void tc_StatusChanged(object sender, JBModule.Message.StatusEventArgs e)
        {
            BW.ReportProgress(e.Percent, e.Result);
        }
        void FixOT(string Nobr, DateTime Adate, string AttRote, IEnumerable<JBModule.Data.Linq.OT> OTs, JBModule.Data.Linq.OT FixOT, IEnumerable<JBModule.Data.Linq.ATTCARD> ATTCARDs, string ot_dept, string otrate_code)
        {
            //string delete_cmd = "delete ot where nobr={0} and bdate={1} and syscreat=1";
            //object[] parms = new object[] { att.NOBR, att.ADATE };

            //db.ExecuteCommand(delete_cmd, parms);//不管如何先刪除，如果有改掉rote的固定加班時數，才會正確
            if (FixOT != null)
                db.OT.DeleteOnSubmit(FixOT);
            var roteSQL = from a in roteList where a.ROTE1 == AttRote select a;
            var roteRow = roteSQL.FirstOrDefault();
            if (roteRow != null && roteSQL.First().MO_HRS > 0)
            {
                Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(Adate);
                string YYMM = sd.YYMM;

                if (FixOtModeType == FixOtMode.CalcByAttCard)
                {
                    if (ATTCARDs.Any())//有資料
                    {
                        int hh, mm;//下班時間，拿來往前推固定加班開始時間
                        hh = int.Parse(roteRow.OFF_TIME.Substring(0, 2));
                        mm = int.Parse(roteRow.OFF_TIME.Substring(2, 2));
                        int h1, m1;//固定加班時間
                        h1 = (int)roteRow.MO_HRS;//取整數
                        m1 = Convert.ToInt32((roteRow.MO_HRS - h1) * 60);

                        if (m1 > mm)//不足
                        {
                            hh--;
                            mm += 60;//補一個小時
                        }
                        int HH, MM;//固定加班開始時間，下班時間往前推，往前時間長度為該班別的固定加班時數的長度
                        HH = hh - h1;
                        MM = mm - m1;
                        string fixot_time_b = HH.ToString("00") + MM.ToString("00");//得到固定加班開始時間

                        var attcardRow = ATTCARDs.First();
                        if (attcardRow.T1.Trim().Length == 0 || attcardRow.T2.Trim().Length == 0) return;
                        string ot_start = Adate.AddTime(roteRow.OFF_TIME).AddHours(Convert.ToDouble(-1 * roteRow.MO_HRS)).TimeStringBy48HR(Adate);
                        string ot_end = roteRow.OFF_TIME;
                        JBTools.Intersection its = new JBTools.Intersection();
                        its.Inert(ot_start, ot_end);
                        its.Inert(attcardRow.T1, attcardRow.T2);
                        decimal TotalHrs = its.GetHours();

                        var roteRest = new List<Tuple<string, string>>();
                        if (roteRow.RES_B_TIME.Trim().Length > 0 && roteRow.RES_E_TIME.Trim().Length > 0)
                            roteRest.Add(new Tuple<string, string>(roteRow.RES_B_TIME, roteRow.RES_E_TIME));
                        if (roteRow.RES_B1_TIME.Trim().Length > 0 && roteRow.RES_E1_TIME.Trim().Length > 0)
                            roteRest.Add(new Tuple<string, string>(roteRow.RES_B1_TIME, roteRow.RES_E1_TIME));
                        if (roteRow.RES_B2_TIME.Trim().Length > 0 && roteRow.RES_E2_TIME.Trim().Length > 0)
                            roteRest.Add(new Tuple<string, string>(roteRow.RES_B2_TIME, roteRow.RES_E2_TIME));
                        if (roteRow.RES_B3_TIME.Trim().Length > 0 && roteRow.RES_E3_TIME.Trim().Length > 0)
                            roteRest.Add(new Tuple<string, string>(roteRow.RES_B3_TIME, roteRow.RES_E3_TIME));
                        if (roteRow.RES_B4_TIME.Trim().Length > 0 && roteRow.RES_E4_TIME.Trim().Length > 0)
                            roteRest.Add(new Tuple<string, string>(roteRow.RES_B4_TIME, roteRow.RES_E4_TIME));
                        decimal TotalRest = 0;
                        foreach (var it in roteRest)
                        {
                            JBTools.Intersection itsRest = new JBTools.Intersection();
                            itsRest.Inert(ot_start, ot_end);
                            itsRest.Inert(attcardRow.T1, attcardRow.T2);
                            itsRest.Inert(it.Item1, it.Item2);
                            TotalRest += itsRest.GetHours();
                            //TotalHrs -= itsRest.GetHours();
                        }
                        TotalHrs -= TotalRest;
                        TotalHrs += 0.000001M;//調節尾差

                        decimal fixot_hrs = JBTools.NumbericConvert.RangeInterval(TotalHrs, 0.5M, JBTools.NumbericConvert.DigitalMode.Floor);
                        if (fixot_hrs > roteRow.MO_HRS) fixot_hrs = roteRow.MO_HRS;


                        if (FixOT != null && FixOT.YYMM.CompareTo(YYMM) < 0)//如果這一天的日期所關聯的計薪年月大於已存在固定加班的計薪年月，就忽略不動作，代表預先輸入
                            return;

                        if (fixot_hrs > 0 && !OTs.Where(p => p.BTIME == its.TimeBegin.TimeStringBy48HR(DateTime.MinValue)).Any())//已有手動申請的加班
                        {
                            //bool isExist = false;
                            JBModule.Data.Linq.OT ot = new JBModule.Data.Linq.OT();
                            ot.BDATE = Adate;
                            ot.BTIME = its.TimeBegin.TimeStringBy48HR(DateTime.MinValue);
                            //if (FixOT != null)
                            //{
                            //    ot = FixOT;
                            //    isExist = true;
                            //}
                            ot.CANT_ADJ = false;
                            ot.DIFF = 0;
                            ot.EAT = false;
                            ot.ETIME = its.TimeEnd.TimeStringBy48HR(DateTime.MinValue);
                            ot.FIX_AMT = false;
                            ot.FOOD_CNT = 0;
                            ot.FOOD_PRI = 0;
                            ot.FST_HOURS = 0;
                            ot.HOT_133 = 0;
                            ot.HOT_166 = 0;
                            ot.HOT_200 = 0;
                            ot.KEY_DATE = DateTime.Now;
                            ot.KEY_MAN = USER_NAME;
                            ot.NOBR = Nobr;
                            ot.NOFOOD = true;
                            ot.NOFOOD1 = false;
                            ot.NOP_H_100 = 0;
                            ot.NOP_H_133 = 0;
                            ot.NOP_H_167 = 0;
                            ot.NOP_H_200 = 0;
                            ot.NOP_W_100 = 0;
                            ot.NOP_W_133 = 0;
                            ot.NOP_W_167 = 0;
                            ot.NOP_W_200 = 0;
                            ot.NOT_EXP = 0;
                            ot.NOT_H_133 = 0;
                            ot.NOT_H_167 = 0;
                            ot.NOT_H_200 = 0;
                            ot.NOT_W_100 = 0;
                            ot.NOT_W_133 = 0;
                            ot.NOT_W_167 = 0;
                            ot.NOT_W_200 = 0;
                            ot.NOTE = "";
                            ot.NOTMODI = false;
                            ot.OT_CAR = 0;
                            ot.OT_DEPT = ot_dept;
                            ot.OT_EDATE = Adate;
                            ot.OT_FOOD = 0;
                            ot.OT_FOOD1 = 0;
                            ot.OT_FOODH = 0;
                            ot.OT_FOODH1 = 0;
                            ot.OT_HRS = fixot_hrs;
                            ot.OT_ROTE = AttRote;
                            ot.OTNO = "";
                            ot.OTRATE_CODE = "";
                            ot.OTRCD = "09";
                            ot.REC = 0;
                            ot.RES = false;
                            ot.REST_EXP = 0;
                            ot.REST_HRS = 0;
                            ot.SALARY = 0;
                            ot.SER = "";
                            ot.SERNO = "";
                            ot.SUM = false;
                            ot.SYS_OT = false;
                            ot.SYSCREAT = true;//設定true代表是固定加班自動產生
                            ot.SYSCREAT1 = false;
                            ot.TOP_H_200 = 0;
                            ot.TOP_W_100 = 0;
                            ot.TOP_W_133 = 0;
                            ot.TOP_W_167 = 0;
                            ot.TOP_W_200 = 0;
                            ot.TOT_EXP = 0;
                            ot.TOT_H_200 = 0;
                            ot.TOT_HOURS = fixot_hrs;
                            ot.TOT_W_100 = 0;
                            ot.TOT_W_133 = 0;
                            ot.TOT_W_167 = 0;
                            ot.TOT_W_200 = 0;
                            ot.WOT_133 = 0;
                            ot.WOT_166 = 0;
                            ot.WOT_200 = 0;
                            ot.YYMM = sd.YYMM;
                            if (isFixYymm) ot.YYMM = FixYymm;
                            //if (!isExist)
                            db.OT.InsertOnSubmit(ot);
                            //db.SubmitChanges();
                            //FixOTs.Add(ot);
                        }
                        else if (FixOT != null)
                            db.OT.DeleteOnSubmit(FixOT);
                    }
                    else if (FixOT != null)
                        db.OT.DeleteOnSubmit(FixOT);
                }
                else if (this.FixOtModeType == FixOtMode.TotalHours)
                {
                    bool isExist = false;
                    JBModule.Data.Linq.OT ot = new JBModule.Data.Linq.OT();
                    ot.BDATE = Adate;
                    ot.BTIME = AddHour(roteRow.OFF_TIME, roteRow.MO_HRS * -1);
                    if (FixOT != null)
                    {
                        ot = FixOT;
                        isExist = true;
                    }
                    ot.CANT_ADJ = false;
                    ot.DIFF = 0;
                    ot.EAT = false;
                    ot.ETIME = roteRow.OFF_TIME;
                    ot.FIX_AMT = false;
                    ot.FOOD_CNT = 0;
                    ot.FOOD_PRI = 0;
                    ot.FST_HOURS = 0;
                    ot.HOT_133 = 0;
                    ot.HOT_166 = 0;
                    ot.HOT_200 = 0;
                    ot.KEY_DATE = DateTime.Now;
                    ot.KEY_MAN = USER_NAME;
                    ot.NOBR = Nobr;
                    ot.NOFOOD = true;
                    ot.NOFOOD1 = false;
                    ot.NOP_H_100 = 0;
                    ot.NOP_H_133 = 0;
                    ot.NOP_H_167 = 0;
                    ot.NOP_H_200 = 0;
                    ot.NOP_W_100 = 0;
                    ot.NOP_W_133 = 0;
                    ot.NOP_W_167 = 0;
                    ot.NOP_W_200 = 0;
                    ot.NOT_EXP = 0;
                    ot.NOT_H_133 = 0;
                    ot.NOT_H_167 = 0;
                    ot.NOT_H_200 = 0;
                    ot.NOT_W_100 = 0;
                    ot.NOT_W_133 = 0;
                    ot.NOT_W_167 = 0;
                    ot.NOT_W_200 = 0;
                    ot.NOTE = "";
                    ot.NOTMODI = false;
                    ot.OT_CAR = 0;
                    ot.OT_DEPT = ot_dept;
                    ot.OT_EDATE = Adate;
                    ot.OT_FOOD = 0;
                    ot.OT_FOOD1 = 0;
                    ot.OT_FOODH = 0;
                    ot.OT_FOODH1 = 0;
                    ot.OT_HRS = roteRow.MO_HRS;
                    ot.OT_ROTE = AttRote;
                    ot.OTNO = "";
                    ot.OTRATE_CODE = "";
                    ot.OTRCD = "09";
                    ot.REC = 0;
                    ot.RES = false;
                    ot.REST_EXP = 0;
                    ot.REST_HRS = 0;
                    ot.SALARY = 0;
                    ot.SER = "";
                    ot.SERNO = "";
                    ot.SUM = false;
                    ot.SYS_OT = false;
                    ot.SYSCREAT = true;//設定true代表是固定加班自動產生
                    ot.SYSCREAT1 = false;
                    ot.TOP_H_200 = 0;
                    ot.TOP_W_100 = 0;
                    ot.TOP_W_133 = 0;
                    ot.TOP_W_167 = 0;
                    ot.TOP_W_200 = 0;
                    ot.TOT_EXP = 0;
                    ot.TOT_H_200 = 0;
                    ot.TOT_HOURS = roteRow.MO_HRS;
                    ot.TOT_W_100 = 0;
                    ot.TOT_W_133 = 0;
                    ot.TOT_W_167 = 0;
                    ot.TOT_W_200 = 0;
                    ot.WOT_133 = 0;
                    ot.WOT_166 = 0;
                    ot.WOT_200 = 0;
                    ot.YYMM = sd.YYMM;
                    if (isFixYymm) ot.YYMM = FixYymm;
                    if (!isExist)
                        db.OT.InsertOnSubmit(ot);
                    //db.SubmitChanges();
                    //FixOTs.Add(ot);
                }
                else if (FixOT != null)
                    db.OT.DeleteOnSubmit(FixOT);

            }
            else if (FixOT != null)
                db.OT.DeleteOnSubmit(FixOT);

        }
        void ctor_StatusChanged(object sender, JBModule.Message.StatusEventArgs e)
        {
            BW.ReportProgress(e.Percent, e.Result);
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!this.BW.CancellationPending)
            {
                toolStripProgressBar1.Value = e.ProgressPercentage;
                trpState.Text = e.UserState.ToString();
            }
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Result != null && e.Result.ToString().Trim().Length > 0)
                MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.panel1.Enabled = true;
        }

        void CreateFixOT(string nobr, DateTime adate, string ot_dept, string otrate_code)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var attSQL = from a in db.ATTEND
                         join b in db.BASETTS on a.NOBR equals b.NOBR
                         join c in db.HOL_DAY on new { b.HOLI_CODE, a.ROTE, a.ADATE.Date } equals new { c.HOLI_CODE, c.ROTE, c.ADATE.Date } into ac
                         from hol_day in ac.DefaultIfEmpty()
                         where a.NOBR == nobr && a.ADATE == adate
                         && a.ADATE >= b.ADATE && a.ADATE <= b.DDATE
                         //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                         && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                         select new { ATTEND = a, isHoli = hol_day != null && hol_day.ATYPE == "E" };
            if (attSQL.Any())
            {
                FixOT(attSQL.First().ATTEND, ot_dept, otrate_code, attSQL.First().isHoli);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="att"></param>
        /// <param name="ot_dept"></param>
        /// <param name="otrate_code"></param>
        /// <param name="isHoli">颱風天</param>
        void FixOT(JBModule.Data.Linq.ATTEND att, string ot_dept, string otrate_code, bool isHoli)
        {
            string delete_cmd = "delete ot where nobr={0} and bdate={1} and syscreat=1 and btime<>'0000' and etime<>'0000'" + " and " + Sal.Function.GetFilterCmdByNobrOfWrite("ot.nobr");
            object[] parms = new object[] { att.NOBR, att.ADATE };
            dcAttDataContext db = new dcAttDataContext();
            db.ExecuteCommand(delete_cmd, parms);//不管如何先刪除，如果有改掉rote的固定加班時數，才會正確
            var roteSQL = from a in db.ROTE where a.ROTE1 == att.ROTE select a;
            var roteRow = roteSQL.FirstOrDefault();
            if (roteRow != null && roteSQL.First().MO_HRS > 0)
            {
                var attcardSQL = from a in db.ATTCARD
                                 where a.NOBR == att.NOBR && a.ADATE == att.ADATE
                                 select a;
                if (attcardSQL.Any())//有資料
                {
                    int hh, mm;//下班時間，拿來往前推固定加班開始時間
                    if (!isHoli)//非颱風天，以下班時間為交界
                    {
                        hh = int.Parse(roteRow.OFF_TIME.Substring(0, 2));
                        mm = int.Parse(roteRow.OFF_TIME.Substring(2, 2));
                    }
                    else//颱風天，固定加班作滿的話算12小時，所以以班別上班時間作交界
                    {
                        hh = int.Parse(roteRow.ON_TIME.Substring(0, 2));
                        mm = int.Parse(roteRow.ON_TIME.Substring(2, 2));
                    }
                    int h1, m1;//固定加班時間
                    h1 = (int)roteRow.MO_HRS;//取整數
                    m1 = Convert.ToInt32((roteRow.MO_HRS - h1) * 60);

                    if (m1 > mm)//不足
                    {
                        hh--;
                        mm += 60;//補一個小時
                    }
                    int HH, MM;//固定加班開始時間，下班時間往前推，往前時間長度為該班別的固定加班時數的長度
                    if (!isHoli)//如果不是颱風天，固定加班開始時間就是班別下班時間往前推固定加班時間
                    {
                        HH = hh - h1;
                        MM = mm - m1;
                    }
                    else//如果是颱風天，就不往後推固定加班開始時間，而是以上班時間為計算起始時間
                    {
                        HH = hh;
                        MM = mm;
                    }
                    string fixot_time_b = HH.ToString("00") + MM.ToString("00");//得到固定加班開始時間


                    var attcardRow = attcardSQL.First();
                    string on_time = fixot_time_b.CompareTo(attcardRow.T1) >= 0 ? fixot_time_b : attcardRow.T1;
                    string off_time = roteRow.OFF_TIME.CompareTo(attcardRow.T2) <= 0 ? roteRow.OFF_TIME : attcardRow.T2;
                    var ot_calc = Dll.Att.OtCal.CalculationOt(att.NOBR, att.ROTE, att.ADATE, on_time, off_time);
                    decimal fixot_hrs = ot_calc.iTotalHour;
                    if (fixot_hrs % 1 >= 0.75M)
                        fixot_hrs = decimal.Floor(fixot_hrs) + 1M;
                    else if (fixot_hrs % 1 >= 0.5M)
                        fixot_hrs = decimal.Floor(fixot_hrs) + 0.5M;
                    else if (fixot_hrs % 1 >= 0.25M)
                        fixot_hrs = decimal.Floor(fixot_hrs) + 0.5M;
                    else if (fixot_hrs % 1 >= 0M)
                        fixot_hrs = decimal.Floor(fixot_hrs);
                    if (fixot_hrs > 0)
                    {
                        OT ot = new OT();
                        ot.BDATE = att.ADATE;
                        ot.BTIME = on_time;
                        ot.CANT_ADJ = false;
                        ot.DIFF = 0;
                        ot.EAT = false;
                        ot.ETIME = off_time;
                        ot.FIX_AMT = false;
                        ot.FOOD_CNT = 0;
                        ot.FOOD_PRI = 0;
                        ot.FST_HOURS = 0;
                        ot.HOT_133 = 0;
                        ot.HOT_166 = 0;
                        ot.HOT_200 = 0;
                        ot.KEY_DATE = DateTime.Now;
                        ot.KEY_MAN = MainForm.USER_NAME;
                        ot.NOBR = att.NOBR;
                        ot.NOFOOD = true;
                        ot.NOFOOD1 = false;
                        ot.NOP_H_100 = 0;
                        ot.NOP_H_133 = 0;
                        ot.NOP_H_167 = 0;
                        ot.NOP_H_200 = 0;
                        ot.NOP_W_100 = 0;
                        ot.NOP_W_133 = 0;
                        ot.NOP_W_167 = 0;
                        ot.NOP_W_200 = 0;
                        ot.NOT_EXP = 0;
                        ot.NOT_H_133 = 0;
                        ot.NOT_H_167 = 0;
                        ot.NOT_H_200 = 0;
                        ot.NOT_W_100 = 0;
                        ot.NOT_W_133 = 0;
                        ot.NOT_W_167 = 0;
                        ot.NOT_W_200 = 0;
                        ot.NOTE = "";
                        ot.NOTMODI = false;
                        ot.OT_CAR = 0;
                        ot.OT_DEPT = ot_dept;
                        ot.OT_EDATE = att.ADATE;
                        ot.OT_FOOD = 0;
                        ot.OT_FOOD1 = 0;
                        ot.OT_FOODH = 0;
                        ot.OT_FOODH1 = 0;
                        ot.OT_HRS = fixot_hrs;
                        ot.OT_ROTE = att.ROTE;
                        ot.OTNO = "";
                        ot.OTRATE_CODE = "";
                        ot.OTRCD = "09";
                        ot.REC = 0;
                        ot.RES = false;
                        ot.REST_EXP = 0;
                        ot.REST_HRS = 0;
                        ot.SALARY = 0;
                        ot.SER = "";
                        ot.SERNO = "";
                        ot.SUM = false;
                        ot.SYS_OT = false;
                        ot.SYSCREAT = true;//設定true代表是固定加班自動產生
                        ot.SYSCREAT1 = false;
                        ot.TOP_H_200 = 0;
                        ot.TOP_W_100 = 0;
                        ot.TOP_W_133 = 0;
                        ot.TOP_W_167 = 0;
                        ot.TOP_W_200 = 0;
                        ot.TOT_EXP = 0;
                        ot.TOT_H_200 = 0;
                        ot.TOT_HOURS = fixot_hrs;
                        ot.TOT_W_100 = 0;
                        ot.TOT_W_133 = 0;
                        ot.TOT_W_167 = 0;
                        ot.TOT_W_200 = 0;
                        ot.WOT_133 = 0;
                        ot.WOT_166 = 0;
                        ot.WOT_200 = 0;
                        Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(att.ADATE);
                        ot.YYMM = sd.YYMM;
                        db.OT.InsertOnSubmit(ot);
                        db.SubmitChanges();
                    }

                }

            }
        }
        int GetHour(string HHmm)
        {
            return Convert.ToInt32(HHmm.Substring(0, 2));
        }
        int GetMinute(string HHmm)
        {
            return Convert.ToInt32(HHmm.Substring(2, 2));
        }
        string AddHour(string HHmm, decimal hour)
        {
            var HH = GetHour(HHmm) + Math.Ceiling(hour);
            var mm = GetMinute(HHmm) + (hour % 1M) * 60M;
            if (mm >= 60)
            {
                HH++;
                mm -= 60;
            }
            return HH.ToString("00") + mm.ToString("00");
        }

        private void FRM2G_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BW.IsBusy)
                BW.CancelAsync();
            BW.Dispose();
        }

        TimeSpan TimeSpan(string btime, string etime)
        {
            DateTime dd = new DateTime(1900, 1, 1);
            DateTime d1 = dd.AddHours(GetHour(btime)).AddMinutes(GetMinute(btime));
            DateTime d2 = dd.AddHours(GetHour(etime)).AddMinutes(GetMinute(etime));

            return d2 - d1;
        }
        private void txtDateB_Validated(object sender, EventArgs e)
        {
            try
            {
                DateTime d1 = Convert.ToDateTime(txtDateB.Text);
                DateTime d2 = d1.AddMonths(1).AddDays(-1);
                txtDateE.Text = Sal.Function.GetDate(d2);
                Sal.Core.SalaryDate sd = new SalaryDate(d1);
                textBoxYYMM.Text = sd.YYMM;
            }
            catch
            {

            }
        }
        public enum FixOtMode
        {
            CalcByAttCard = 0,//依照刷卡資料
            TotalHours = 1//總工時
        }
        public void CreateABS(param p)
        {
            var dbCreateAbs = new JBModule.Data.Linq.HrDBDataContext();
            var sql2 = from a in dbCreateAbs.ATTEND
                       join b in dbCreateAbs.BASETTS on a.NOBR equals b.NOBR
                       join c in dbCreateAbs.DEPT on b.DEPT equals c.D_NO
                       join f in dbCreateAbs.ROTE on a.ROTE equals f.ROTE1
                       where p.DateE >= b.ADATE && p.DateE <= b.DDATE.Value
                      && a.NOBR.CompareTo(p.NOBRB) >= 0 && a.NOBR.CompareTo(p.NOBRE) <= 0
                      && c.D_NO_DISP.CompareTo(p.DEPTB) >= 0 && c.D_NO_DISP.CompareTo(p.DEPTE) <= 0
                      && a.ADATE >= p.DateB && a.ADATE <= p.DateE
                      && (a.LATE_MINS > 0 || a.E_MINS > 0 || a.ABS)//有異常的部分
                      //&& dbCreateAbs.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && dbCreateAbs.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(q => q.DATAGROUP).Contains(b.SALADR)
                       select new { ATTEND = a, ROTE = f };
            int total = sql2.Count();
            int cc = 0;
            var hcodeList = dbCreateAbs.HCODE.ToList();
            var LateCode = AppConfig.GetConfig("LateCode").GetString();
            var LateMin = AppConfig.GetConfig("LateMin").GetInter(0);
            var LateCodeSet = hcodeList.Where(pp => pp.H_CODE == LateCode).FirstOrDefault();
            var EarilyCode = AppConfig.GetConfig("EarilyCode").GetString();
            var EarilyMin = AppConfig.GetConfig("EarilyMin").GetInter(0);
            var EarilyCodeSet = hcodeList.Where(pp => pp.H_CODE == EarilyCode).FirstOrDefault();
            var AbsenceCode = AppConfig.GetConfig("AbsenceCode").GetString();
            var AbsenceCodeSet = hcodeList.Where(pp => pp.H_CODE == AbsenceCode).FirstOrDefault();
            foreach (var it in sql2)
            {
                cc++;
                //this.Report(cc * 100 / total, "正在執行..產生" + gp.Key + "的請假資料");
                BW.ReportProgress(cc * 100 / total, "正在執行..產生" + it.ATTEND.NOBR + "的請假資料");
                //foreach (var it in gp)
                //{
                if (LateCodeSet != null && it.ATTEND.LATE_MINS >= LateMin && it.ATTEND.LATE_MINS > 0)//遲到
                {
                    string time_b = it.ROTE.ON_TIME;
                    var tb = it.ATTEND.ADATE.AddTime(time_b);
                    var miniMinute = LateCodeSet.MIN_NUM * 60;
                    var minnteRate1 = decimal.Ceiling(it.ATTEND.LATE_MINS / miniMinute);
                    var te = tb.AddMinutes(Convert.ToInt32(minnteRate1 * miniMinute));
                    JBTools.Intersection its = new JBTools.Intersection();
                    its.Inert(tb, te);

                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                    abs.NOBR = it.ATTEND.NOBR;
                    abs.A_NAME = "";
                    abs.BDATE = it.ATTEND.ADATE;
                    abs.BTIME = time_b;
                    abs.EDATE = it.ATTEND.ADATE;
                    abs.ETIME = it.ATTEND.ADATE.Date < te.Date ? (te.Hour + 24).ToString() + te.Minute.ToString("00") : te.ToString("HHmm");
                    abs.H_CODE = LateCode;
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    abs.NOTE = "(系統產生)遲到未請假扣曠職" + p.DateB.ToShortDateString() + "~" + p.DateE.ToShortDateString();
                    abs.NOTEDIT = false;
                    abs.SERNO = "";
                    abs.SYSCREATE = false;
                    abs.SYSCREATE1 = true;
                    abs.TOL_DAY = 0;
                    abs.TOL_HOURS = its.GetHours();
                    abs.YYMM = new Sal.Core.SalaryDate(abs.BDATE).YYMM;
                    dbCreateAbs.ABS.InsertOnSubmit(abs);
                    it.ATTEND.LATE_MINS = 0;//請假後清空
                }
                if (EarilyCodeSet != null && it.ATTEND.E_MINS >= EarilyMin && it.ATTEND.E_MINS > 0)//早退
                {
                    string time_e = it.ROTE.OFF_TIME;
                    var te = it.ATTEND.ADATE.AddTime(time_e);
                    var miniMinute = EarilyCodeSet.MIN_NUM * 60;
                    var minnteRate1 = decimal.Ceiling(it.ATTEND.E_MINS / miniMinute);
                    var tb = te.AddMinutes(Convert.ToInt32(minnteRate1 * miniMinute) * -1);
                    JBTools.Intersection its = new JBTools.Intersection();
                    its.Inert(tb, te);
                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                    abs.NOBR = it.ATTEND.NOBR;
                    abs.A_NAME = "";
                    abs.BDATE = it.ATTEND.ADATE;
                    abs.BTIME = it.ATTEND.ADATE.Date < tb.Date ? (tb.Hour + 24).ToString() + tb.Minute.ToString("00") : tb.ToString("HHmm");
                    abs.EDATE = it.ATTEND.ADATE;
                    abs.ETIME = time_e;
                    abs.H_CODE = EarilyCode;
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    abs.NOTE = "(系統產生)忘刷早退扣事假" + p.DateB.ToShortDateString() + "~" + p.DateE.ToShortDateString();
                    abs.NOTEDIT = false;
                    abs.SERNO = "";
                    abs.SYSCREATE = false;
                    abs.SYSCREATE1 = true;
                    abs.TOL_DAY = 0;
                    abs.TOL_HOURS = its.GetHours();
                    abs.YYMM = new Sal.Core.SalaryDate(abs.BDATE).YYMM;
                    dbCreateAbs.ABS.InsertOnSubmit(abs);
                    it.ATTEND.E_MINS = 0;//請假後清空
                }
                if (AbsenceCodeSet != null && it.ATTEND.ABS)//曠職
                {
                    string time_b = it.ROTE.ON_TIME;
                    string time_e = it.ROTE.OFF_TIME;
                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                    abs.NOBR = it.ATTEND.NOBR;
                    abs.A_NAME = "";
                    abs.BDATE = it.ATTEND.ADATE;
                    abs.BTIME = time_b;
                    abs.EDATE = it.ATTEND.ADATE;
                    abs.ETIME = time_e;
                    abs.H_CODE = AbsenceCode;
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    abs.NOTE = "(系統產生)忘刷早退扣事假" + p.DateB.ToShortDateString() + "~" + p.DateE.ToShortDateString();
                    abs.NOTEDIT = false;
                    abs.SERNO = "";
                    abs.SYSCREATE = false;
                    abs.SYSCREATE1 = true;
                    abs.TOL_DAY = 0;
                    abs.TOL_HOURS = it.ROTE.WK_HRS;
                    abs.YYMM = new Sal.Core.SalaryDate(abs.BDATE).YYMM;
                    dbCreateAbs.ABS.InsertOnSubmit(abs);
                    it.ATTEND.ABS = false;//請假後清空
                }
                //}
            }
            dbCreateAbs.SubmitChanges();
        }
        void Delete(string nobr_b, string nobr_e, string dept_b, string dept_e, DateTime date_b, DateTime date_e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //SalaryDate sd = new SalaryDate(yymm);
            string DeleteSystemCreateCmd = "DELETE ABS WHERE ABS.NOBR BETWEEN {0} AND {1} AND EXISTS(SELECT 1 FROM BASETTS A WHERE A.NOBR=ABS.NOBR AND {5} BETWEEN A.ADATE AND A.DDATE AND A.DEPT BETWEEN {2} AND {3}) AND SYSCREATE1=1 AND ABS.BDATE BETWEEN {4} AND {5}"
                //+ " AND dbo.GetFilterByNobr(SALABS.NOBR,{6},{7},{8})=1";
                + "AND exists(select 1 from BASETTS x where x.NOBR = SALABS.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({6},{7},{8})))";

            DeleteSystemCreateCmd = Sal.Function.DeleteCommand("ABS", nobr_b, nobr_e, dept_b, dept_e) + " AND SYSCREATE1=1 AND ABS.BDATE BETWEEN {4} AND {5} ";
            BW.ReportProgress(100, "正在執行..刪除自動產生的請假資料");
            int i = db.ExecuteCommand(DeleteSystemCreateCmd, new object[] { nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN });

        }

        public Dictionary<string, string> GetRefValue(string CalcType)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sqlBaseByCalcType = db.SALBASE.Where(p => p.CALCTYPE == CalcType);
            var sqlFunction = from a in db.SALFUNCTION
                              where a.CALCTYPE == CalcType
                              select a;

            //參數值
            Dictionary<string, string> Ref = new Dictionary<string, string>();
            Dictionary<string, string> RefBase = new Dictionary<string, string>();
            //參數轉換為值
            Dictionary<string, string> RefValue = new Dictionary<string, string>();
            foreach (var item in sqlBaseByCalcType)
            {//處理參數方法
                string newStr = item.REFFUNCTION;
                Ref.Add(string.Format("%{0}%", item.SALNAME), newStr);
            }
            foreach (var item in Ref)
            {
                string value = "";
                value = item.Value.ToString();
                while (value.Contains('%'))
                {
                    int v1 = value.IndexOf('%');//取第一個'%'位子
                    int lgh2 = value.IndexOf('%', v1 + 1) - v1 + 1;//取第二個'%'位子
                    value = value.Replace(value.Substring(v1, lgh2), string.Format("({0})", Ref[value.Substring(v1, lgh2)]));
                }
                RefValue.Add(item.Key, value);
            }
            foreach (var item in sqlFunction.Where(p => p.REF))
            {
                string value = item.SCRIPT;
                while (value.Contains('%'))
                {
                    int v1 = value.IndexOf('%');//取第一個'%'位子
                    int lgh2 = value.IndexOf('%', v1 + 1) - v1 + 1;//取第二個'%'位子
                    value = value.Replace(value.Substring(v1, lgh2), string.Format("({0})", Ref[value.Substring(v1, lgh2)]));
                }
                RefValue.Add("%" + item.ITEM + "%", value);
            }

            return RefValue;
        }
    }
    public class param
    {
        public string YYMM;
        public string NOBRB, NOBRE;
        public string DEPTB, DEPTE;
        public DateTime DateB, DateE;
    }
}
