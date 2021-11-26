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
            var deptData = CodeFunction.GetDeptDisp();
            this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            ptxNobrB.Text = Sal.BaseValue.MinNobr;
            ptxNobrE.Text = Sal.BaseValue.MaxNobr;
            //ptxDeptB.Text = Sal.BaseValue.MinDept;
            //ptxDeptE.Text = Sal.BaseValue.MaxDept;
            SystemFunction.SetComboBoxItems(ptxDeptB, deptData, false);
            SystemFunction.SetComboBoxItems(ptxDeptE, deptData, false);
            Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(DateTime.Now.Date.ToString("yyyyMM"));
            txtDateB.Text = Sal.Core.SalaryDate.DateString(sd.FirstDayOfAttend);
            txtDateE.Text = Sal.Core.SalaryDate.DateString(sd.LastDayOfAttend);
            this.ptxDeptB.SelectedValue = deptData.First().Key;
            this.ptxDeptE.SelectedValue = deptData.Last().Key;

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
            BW.RunWorkerAsync(PARMS);
            this.panel1.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {

            DateTime t1, t2;
            t1 = DateTime.Now;
            db = new JBModule.Data.Linq.HrDBDataContext();
            string msg = "";
            JBModule.Message.TextLog.WriteLog("BLL開始");
            if (DbLog)
                JBModule.Message.DbLog.WriteLog("BLL開始", MainForm.USER_NAME, "FRM2G", 0);
            string[] TTSCODE = new string[] { "1", "4", "6" };
            JBModule.Message.TextLog.WriteLog("撈資料");
            if (DbLog)
                JBModule.Message.DbLog.WriteLog("撈資料", MainForm.USER_NAME, "FRM2G", 0);
            var tmtableList = (from tmt in db.TMTABLE
                               join b in db.BASETTS on tmt.NOBR equals b.NOBR
                               join c in db.DEPT on b.DEPT equals c.D_NO
                               where tmt.YYMM.CompareTo(D1.ToString("yyyyMM")) >= 0 && tmt.YYMM.CompareTo(D2.ToString("yyyyMM")) <= 0
                               && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                               && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                               && tmt.NOBR.CompareTo(NOBR_B) >= 0 && tmt.NOBR.CompareTo(NOBR_E) <= 0
                               && db.GetFilterByNobr(tmt.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               select tmt).ToList();
            var basettsList = from bts in db.BASETTS
                              join b in db.BASETTS on bts.NOBR equals b.NOBR
                              join c in db.DEPT on b.DEPT equals c.D_NO
                              where bts.NOBR.CompareTo(NOBR_B) >= 0 && bts.NOBR.CompareTo(NOBR_E) <= 0
                               && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                               && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                              && bts.ADATE <= D2 && bts.DDATE.Value >= D1
                              && TTSCODE.Contains(bts.TTSCODE)
                              && db.GetFilterByNobr(bts.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                              select new
                              {
                                  bts.NOBR,
                                  adate = bts.ADATE > D1 ? bts.ADATE : D1,
                                  ddate = bts.DDATE.Value <= D2 ? bts.DDATE.Value : D2,
                                  bts.DEPTS,
                                  bts.CALOT
                              };

            var roteChgList = (from a in db.ROTECHG where a.ADATE >= D1 && a.ADATE <= D2 && db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value select a).ToList();
            var roteList = (from rr in db.ROTE select rr).ToList();
            int count = basettsList.Count();
            var attendList = (from a in db.ATTEND where a.ADATE >= D1 && a.ADATE <= D2 select a).ToList();
            JBModule.Message.TextLog.WriteLog("開始計算");
            if (DbLog)
                JBModule.Message.DbLog.WriteLog("開始計算", USER_NAME, "BLL.CardTransAttend", 0);
            if (CreateAttend || CheckTime || CheckError || CheckFixOt || CheckDeleteAttend)
            {
                int i = 0;
                if (CreateAttend)
                {
                    int total = basettsList.Count();
                    foreach (var r in basettsList)
                    {
                        i++;
                        BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(i) / Convert.ToDecimal(total) * 100), "正在產生" + r.NOBR + "出勤資料");
                        var attendListOfNobr = from a in attendList where a.NOBR == r.NOBR select a;
                        BW.ReportProgress(i * 100 / count, Resources.Sal.StatusComputing + r.NOBR);
                        IEnumerable<JBModule.Data.Linq.TMTABLE> tmt = null;
                        for (DateTime dd = r.adate; dd <= r.ddate; dd = dd.AddDays(1))
                        {
                            int day = dd.Day;
                            if (tmt == null)//如果是第一次抓tmtable
                                tmt = from t in tmtableList where t.YYMM == dd.ToString("yyyyMM") && t.NOBR == r.NOBR select t;
                            if (tmt != null && tmt.Any() && tmt.First().YYMM != dd.ToString("yyyyMM"))//如果與上一次的不一樣，就重抓
                                tmt = from t in tmtableList where t.YYMM == dd.ToString("yyyyMM") && t.NOBR == r.NOBR select t;
                            if (!tmt.Any()) continue;//如果還是沒有就代表沒有班表，就跳過

                            var dt = tmt.CopyToDataTable();
                            var row = dt.Rows[0];
                            string rote = row["D" + day].ToString();
                            var roteChgOfNobrAdate = from a in roteChgList where a.NOBR.Trim().ToUpper() == r.NOBR.Trim().ToUpper() && a.ADATE == dd select a;
                            if (roteChgOfNobrAdate.Any()) rote = roteChgOfNobrAdate.First().ROTE;//如果有調班資料的話就改變班別
                            var RoteData = from rr in roteList where rr.ROTE1.Trim() == rote.Trim() select rr;
                            msg = "找不到工號：" + r.NOBR + "於" + dd.ToString("yyyy/MM/dd") + "指定的班別(" + rote.Trim() + ")";
                            if (!RoteData.Any())
                                if (!isContinue) throw new Exception(msg);
                                else
                                {
                                    JBModule.Message.TextLog.WriteLog(msg);
                                    ErrorQueue.Add(msg);
                                    errorCount++;
                                    continue;
                                }

                            var rowRote = RoteData.First();

                            var attendListOfNobrAtDate = from a in attendListOfNobr where a.ADATE == dd select a;
                            if (attendListOfNobrAtDate.Any())
                            {//修改
                                var att = attendListOfNobrAtDate.First();
                                if (att.ROTE != rote)//班別有改變，才做資料變更
                                {
                                    att.ABS = false;
                                    att.ADJ_CODE = "";
                                    att.ATT_HRS = 0;
                                    att.CANT_ADJ = false;
                                    att.E_MINS = 0;
                                    att.FOODAMT = 0;
                                    att.ROTE = rote;
                                    att.FOODSALCD = rowRote.FOODSALCD;
                                    att.SER = 0;
                                    att.FORGET = 0;
                                    att.KEY_DATE = DateTime.Now;
                                    att.KEY_MAN = USER_NAME;
                                    att.LATE_MINS = 0;
                                    att.NIGAMT = rowRote.FOODAMT;
                                    att.NIGHT_HRS = rowRote.NIGHT ? rowRote.WK_HRS : 0;
                                }
                            }
                            else
                            {//新增
                                var att = new JBModule.Data.Linq.ATTEND();
                                att.ABS = false;
                                att.ADATE = dd;
                                att.ADJ_CODE = "";
                                att.ATT_HRS = 0;
                                att.CANT_ADJ = false;
                                att.E_MINS = 0;
                                att.FOODAMT = 0;
                                att.ROTE = rote;
                                att.FOODSALCD = rowRote.FOODSALCD;
                                att.SER = 0;
                                att.FORGET = 0;
                                att.KEY_DATE = DateTime.Now;
                                att.KEY_MAN = USER_NAME;
                                att.LATE_MINS = 0;
                                att.NIGAMT = rowRote.FOODAMT;
                                att.NIGHT_HRS = rowRote.NIGHT ? rowRote.WK_HRS : 0;
                                att.NOBR = r.NOBR;
                                db.ATTEND.InsertOnSubmit(att);
                            }
                        }
                    }
                }
                try
                {
                    BW.ReportProgress(100, "正在寫入出勤資料");
                    db.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                }
                catch (System.Data.Linq.ChangeConflictException ex)
                {
                    foreach (System.Data.Linq.ObjectChangeConflict occ in db.ChangeConflicts)
                    {
                        occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);
                    }
                    db.SubmitChanges();
                }
                BW.ReportProgress(100, "正在執行刷卡轉出勤");
                JBModule.Message.TextLog.WriteLog("刷卡轉出勤開始");
                if (DbLog)
                    JBModule.Message.DbLog.WriteLog("刷卡轉出勤開始", USER_NAME, "BLL.CardTransAttend", 0);
                //db.ATTEND.InsertAllOnSubmit(attendList);
                //db.SubmitChanges();
                if (CheckTime || CheckError)
                {
                    Delete(NOBR_B, NOBR_E, DEPT_B, DEPT_E, D1, D2);
                    //this.Report("正在執行刷卡轉出勤", 100);
                    //Dll.Att.TransCard(NOBR_B, NOBR_E, DEPT_B, DEPT_E, D1, D2, USER_NAME, CheckTime, CheckError, true);
                    Dal.Dao.Att.TransCardDao tc = new Dal.Dao.Att.TransCardDao(db.Connection);
                    tc.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(tc_StatusChanged);
                    tc.TransCard(NOBR_B, NOBR_E, DEPT_B, DEPT_E, D1, D2, USER_NAME, CheckTime, CheckError, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
                }

                if (CheckFixOt)
                {
                    BW.ReportProgress(100, "正在執行固定加班計算");
                    JBModule.Message.TextLog.WriteLog("固定加班");

                    string delete_cmd = "delete ot where bdate between {0} and {1} and syscreat=1 and "
                                        + " exists(select * from basetts b join dept c on b.dept=c.d_no where b.nobr=ot.nobr "
                                        + " and ot.bdate between b.adate and b.ddate and b.nobr between {3} and {4}"
                                        + " and c.d_no_disp between {5} and {6})"
                                        + " and " + Sal.Function.GetFilterCmdByNobrOfWrite("ot.nobr");
                    object[] parms = new object[] { D1, D2, FixYymm, NOBR_B, NOBR_E, DEPT_B, DEPT_E };
                    db.ExecuteCommand(delete_cmd, parms);//不管如何先刪除，如果有改掉rote的固定加班時數，才會正確
                    var OtData = (from a in db.ATTEND
                                  join b in db.OT on new { a.NOBR, a.ADATE.Date } equals new { b.NOBR, b.BDATE.Date } into OTs
                                  from rOt in OTs.DefaultIfEmpty()
                                  join c in db.BASETTS on a.NOBR equals c.NOBR
                                  join ac in db.ATTCARD on new { a.NOBR, a.ADATE.Date } equals new { ac.NOBR, ac.ADATE.Date } into ATTCARDs
                                  from rAttcard in ATTCARDs
                                  join d in db.ROTE on a.ROTE equals d.ROTE1
                                  join f in db.BASETTS on a.NOBR equals f.NOBR
                                  join g in db.DEPT on f.DEPT equals g.D_NO
                                  where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                                  && g.D_NO_DISP.CompareTo(DEPT_B) >= 0 && g.D_NO_DISP.CompareTo(DEPT_E) <= 0
                                  && a.ADATE >= D1 && a.ADATE <= D2
                                  && d.MO_HRS > 0
                                  && a.ADATE >= f.ADATE && a.ADATE <= f.DDATE.Value
                                  orderby a.NOBR, a.ADATE
                                  select new { ATTEND = a, OTs = OTs.Where(p => !p.SYSCREAT), FixOTs = OTs.Where(p => p.SYSCREAT), ATTCARDs, BASETTS = f }
                                   );
                    i = 0;
                    var total = OtData.Count();
                    FixOTs = new List<JBModule.Data.Linq.OT>();
                    if (db.Connection.State != System.Data.ConnectionState.Open) db.Connection.Open();

                    string tmp_nobr = "";
                    foreach (var r in OtData)
                    {
                        i++;
                        //this.Report("正在產生" + r.ATTEND.NOBR + "於" + r.ATTEND.ADATE.ToShortDateString() + "之固定加班", Convert.ToInt32(Convert.ToDecimal(i) / Convert.ToDecimal(total) * 100));
                        FixOT(r.ATTEND, r.OTs, r.FixOTs.FirstOrDefault(), r.ATTCARDs, r.BASETTS.DEPTS, r.BASETTS.CALOT);
                    }
                    db.SubmitChanges();
                }
                BW.ReportProgress(100, "正在執行刪除離職出勤");
                JBModule.Message.TextLog.WriteLog("刪除離職出勤");
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

                }
                if (CheckCreateAbs)
                {
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
                }
                db = new JBModule.Data.Linq.HrDBDataContext();//清空cache
                var sql = from a in db.ATTEND
                          join b in db.ROTE on a.ROTE equals b.ROTE1
                          join d in db.BASETTS on a.NOBR equals d.NOBR
                          join e1 in db.BASE on a.NOBR equals e1.NOBR
                          join d1 in db.BASETTS on a.NOBR equals d1.NOBR
                          join f in db.STATION on d1.STATION equals f.Code into df
                          from st in df.DefaultIfEmpty()
                          join g in db.DEPT on d.DEPT equals g.D_NO
                          join h in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals h.NOBR
                          where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                          && D2 >= d.ADATE && D2 <= d.DDATE.Value
                          && g.D_NO_DISP.CompareTo(DEPT_B) >= 0 && g.D_NO_DISP.CompareTo(DEPT_E) <= 0
                          && a.ADATE >= D1 && a.ADATE <= D2
                          && a.ADATE >= d1.ADATE && a.ADATE <= d1.DDATE.Value
                          //&& !d.NOWAGE//如果不發薪，也不要記錄明細
                          //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value//判斷資料群組
                          select new
                          {
                              ATTEND = a,
                              ROTE = b,
                              COUNT_MA = e1.COUNT_MA,
                              d.DI,
                              d.SALTP,
                              StationAmt = st != null ? Convert.ToDecimal(st.AMT.Value) : 0M,
                              d.NOWAGE,
                          };
                var sqlOT = (from a in db.OT
                             join d in db.BASETTS on a.NOBR equals d.NOBR
                             join g in db.DEPT on d.DEPT equals g.D_NO
                             join h in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals h.NOBR
                             where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                             && D2 >= d.ADATE && D2 <= d.DDATE.Value
                             && g.D_NO_DISP.CompareTo(DEPT_B) >= 0 && g.D_NO_DISP.CompareTo(DEPT_E) <= 0
                             && a.BDATE >= D1 && a.BDATE <= D2
                             select new
                             {
                                 a.NOBR,
                                 a.BDATE,
                                 a.BTIME,
                                 a.ETIME,
                                 a.OT_ROTE,
                                 a.TOT_HOURS
                             }).ToList();
                var sqlABS = (from a in db.ABS
                              join d in db.BASETTS on a.NOBR equals d.NOBR
                              join g in db.DEPT on d.DEPT equals g.D_NO
                              join h in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals h.NOBR
                              where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                              && D2 >= d.ADATE && D2 <= d.DDATE.Value
                              && g.D_NO_DISP.CompareTo(DEPT_B) >= 0 && g.D_NO_DISP.CompareTo(DEPT_E) <= 0
                              && a.BDATE >= D1 && a.BDATE <= D2
                              select new
                              {
                                  a.NOBR,
                                  a.BDATE,
                                  a.BTIME,
                                  a.ETIME,
                              }).ToList();

                var sqlATTCARD = (from a in db.ATTCARD
                                  join d in db.BASETTS on a.NOBR equals d.NOBR
                                  join g in db.DEPT on d.DEPT equals g.D_NO
                                  join h in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals h.NOBR
                                  where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                                  && D2 >= d.ADATE && D2 <= d.DDATE.Value
                                  && g.D_NO_DISP.CompareTo(DEPT_B) >= 0 && g.D_NO_DISP.CompareTo(DEPT_E) <= 0
                                  && a.ADATE >= D1 && a.ADATE <= D2
                                  select new
                                  {
                                      a.NOBR,
                                      a.ADATE,
                                      a.T1,
                                      a.T2,
                                  }).ToList();
                RoteCalculation rc = new RoteCalculation();

                foreach (var itm in sql)
                {
                    decimal nigamt = 0;
                    decimal foodamt = 0;
                    decimal specamt = 0;
                    decimal stationamt = 0;
                    var absOfNobrDate = from a in sqlABS where a.NOBR == itm.ATTEND.NOBR && a.BDATE == itm.ATTEND.ADATE select a;
                    if (!absOfNobrDate.Any())//當天有請假就不給輪班津貼
                    {
                        var bonusCalc = rc.CreateRoteBonusCalc();
                        bonusCalc.ConditionList.Add(RoteBonusCalc.COUNT_MA, itm.COUNT_MA ? "1" : "0");
                        bonusCalc.ConditionList.Add(RoteBonusCalc.ATT_ROTE, itm.ROTE.ROTE1);
                        bonusCalc.ConditionList.Add(RoteBonusCalc.DI, itm.DI);
                        bonusCalc.ConditionList.Add(RoteBonusCalc.BTIME, itm.ROTE.ON_TIME);
                        bonusCalc.ConditionList.Add(RoteBonusCalc.ETIME, itm.ROTE.OFF_TIME);
                        string btime = "", etime = "", attRote;
                        var attcardOfNobrDate = from a in sqlATTCARD where a.NOBR == itm.ATTEND.NOBR && a.ADATE == itm.ATTEND.ADATE select a;
                        if (attcardOfNobrDate.Any())
                        {
                            btime = attcardOfNobrDate.First().T1;
                            etime = attcardOfNobrDate.First().T2;
                        }
                        attRote = itm.ROTE.ROTE1;
                        var OtOfNobrDate = from a in sqlOT where a.NOBR == itm.ATTEND.NOBR && a.BDATE == itm.ATTEND.ADATE select a;
                        decimal wk_hrs = itm.ROTE.WK_HRS;
                        foreach (var it in OtOfNobrDate)
                        {
                            if (btime.CompareTo(it.BTIME) > 0)
                                btime = it.BTIME;
                            if (etime.CompareTo(it.ETIME) < 0)
                                etime = it.ETIME;
                            if (attRote == "00")
                                attRote = it.OT_ROTE;
                            wk_hrs += it.TOT_HOURS;
                        }
                        nigamt = bonusCalc.Calc(wk_hrs, btime, etime, attRote);
                    }
                    //if (!itm.NOWAGE)
                    //{
                    //    nigamt = itm.ROTE.NIGHTAMT;//先全給，請假再扣回
                    //    if (itm.SALTP == "2")//只有時薪才會計算
                    //        specamt = itm.ROTE.SPECAMT;//先全給，請假再扣回
                    //    if (itm.ATTEND.ROTE != "00")
                    //        stationamt = itm.StationAmt;
                    //}

                    itm.ATTEND.NIGAMT = nigamt;
                    itm.ATTEND.FOODAMT = foodamt;
                    itm.ATTEND.SPECAMT = specamt;
                    itm.ATTEND.SPECSALCD = itm.ROTE.SPECSALCD;
                    itm.ATTEND.STATIONAMT = stationamt;

                }
                try
                {
                    db.SubmitChanges();
                }
                catch (System.Data.Linq.ChangeConflictException ex)
                {
                    foreach (System.Data.Linq.ObjectChangeConflict occ in db.ChangeConflicts)
                    {
                        // *********************************************
                        // 底下三個範例是 3 選 1 喔，不要三行都寫在一起！
                        // **********************************************

                        //// 採用資料庫的查詢出來的值，目前物件的值將會被資料庫最新查到的複寫
                        //occ.Resolve(System.Data.Linq.RefreshMode.OverwriteCurrentValues);

                        //// 採用目前物件中的值，並更新資料庫中的版本
                        //occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);

                        // 僅更新此物件中變更的欄位，僅將變更的欄位寫入資料庫（或稱為合併更新）
                        occ.Resolve(System.Data.Linq.RefreshMode.KeepChanges);
                    }

                    // 注意：解決完衝突之後要記得重新再 SubmitChanges() 一次，否則一樣不會更新資料庫
                    db.SubmitChanges();
                }
            }
            BW.ReportProgress(100, "完成");
            JBModule.Message.TextLog.WriteLog("完成");
            if (DbLog)
                JBModule.Message.DbLog.WriteLog("完成", USER_NAME, "BLL.CardTransAttend", 0);

            BW.ReportProgress(100, Resources.Sal.StatusFinish);
            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            e.Result = msg;

        }

        void tc_StatusChanged(object sender, JBModule.Message.StatusEventArgs e)
        {
            BW.ReportProgress(e.Percent, e.Result);
        }
        void FixOT(JBModule.Data.Linq.ATTEND att, IEnumerable<JBModule.Data.Linq.OT> OTs, JBModule.Data.Linq.OT FixOT, IEnumerable<JBModule.Data.Linq.ATTCARD> ATTCARDs, string ot_dept, string otrate_code)
        {
            //string delete_cmd = "delete ot where nobr={0} and bdate={1} and syscreat=1";
            //object[] parms = new object[] { att.NOBR, att.ADATE };

            //db.ExecuteCommand(delete_cmd, parms);//不管如何先刪除，如果有改掉rote的固定加班時數，才會正確
            if (FixOT != null)
                db.OT.DeleteOnSubmit(FixOT);
            var roteSQL = from a in roteList where a.ROTE1 == att.ROTE select a;
            var roteRow = roteSQL.FirstOrDefault();
            if (roteRow != null && roteSQL.First().MO_HRS > 0)
            {
                Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(att.ADATE);
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


                        if (FixOT != null && FixOT.YYMM.CompareTo(YYMM) < 0)//如果這一天的日期所關聯的計薪年月大於已存在固定加班的計薪年月，就忽略不動作，代表預先輸入
                            return;

                        if (fixot_hrs > 0 && !OTs.Where(p => p.BTIME == on_time).Any())//已有手動申請的加班
                        {
                            //bool isExist = false;
                            JBModule.Data.Linq.OT ot = new JBModule.Data.Linq.OT();
                            ot.BDATE = att.ADATE;
                            ot.BTIME = on_time;
                            //if (FixOT != null)
                            //{
                            //    ot = FixOT;
                            //    isExist = true;
                            //}
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
                            ot.KEY_MAN = USER_NAME;
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
                            ot.OTRATE_CODE = otrate_code;
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
                    ot.BDATE = att.ADATE;
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
                    ot.OT_HRS = roteRow.MO_HRS;
                    ot.OT_ROTE = att.ROTE;
                    ot.OTNO = "";
                    ot.OTRATE_CODE = otrate_code;
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
            toolStripProgressBar1.Value = e.ProgressPercentage;
            trpState.Text = e.UserState.ToString();
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result.ToString().Trim().Length > 0)
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
                         && db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
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
                        ot.OTRATE_CODE = otrate_code;
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
                       where p.DateE >= b.ADATE && p.DateE <= b.DDATE.Value
                      && a.NOBR.CompareTo(p.NOBRB) >= 0 && a.NOBR.CompareTo(p.NOBRE) <= 0
                      && c.D_NO_DISP.CompareTo(p.DEPTB) >= 0 && c.D_NO_DISP.CompareTo(p.DEPTE) <= 0
                      && a.ADATE >= p.DateB && a.ADATE <= p.DateE
                      && (a.LATE_MINS > 0 || a.E_MINS > 0 || a.ABS)//有異常的部分
                      && dbCreateAbs.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                       select a;
            int total = sql2.Count();
            int cc = 0;
            var hcodeList = dbCreateAbs.HCODE.ToList();
            var LateCode = AppConfig.GetConfig("LateCode").GetString();
            var LateMin = AppConfig.GetConfig("LateMin").GetInter();
            var LateCodeSet = hcodeList.Where(pp => pp.H_CODE == LateCode).FirstOrDefault();
            var EarilyCode = AppConfig.GetConfig("EarilyCode").GetString();
            var EarilyMin = AppConfig.GetConfig("EarilyMin").GetInter();
            var EarilyCodeSet = hcodeList.Where(pp => pp.H_CODE == EarilyCode).FirstOrDefault();
            var AbsenceCode = AppConfig.GetConfig("AbsenceCode").GetString();
            var AbsenceCodeSet = hcodeList.Where(pp => pp.H_CODE == AbsenceCode).FirstOrDefault();
            foreach (var it in sql2)
            {
                cc++;
                //this.Report(cc * 100 / total, "正在執行..產生" + gp.Key + "的請假資料");
                BW.ReportProgress(cc * 100 / total, "正在執行..產生" + it.NOBR + "的請假資料");
                //foreach (var it in gp)
                //{
                if (LateCodeSet != null && it.LATE_MINS >= LateMin && it.LATE_MINS > 0)//遲到
                {
                    string time_b = it.ROTE1.ON_TIME;
                    var tb = it.ADATE.AddTime(time_b);
                    var miniMinute = LateCodeSet.MIN_NUM * 60;
                    var minnteRate1 = decimal.Ceiling(it.LATE_MINS / miniMinute);
                    var te = tb.AddMinutes(Convert.ToInt32(minnteRate1 * miniMinute));
                    JBTools.Intersection its = new JBTools.Intersection();
                    its.Inert(tb, te);

                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                    abs.NOBR = it.NOBR;
                    abs.A_NAME = "";
                    abs.BDATE = it.ADATE;
                    abs.BTIME = time_b;
                    abs.EDATE = it.ADATE;
                    abs.ETIME = it.ADATE.Date < te.Date ? (te.Hour + 24).ToString() + te.Minute.ToString("00") : te.ToString("HHmm");
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
                    it.LATE_MINS = 0;//請假後清空
                }
                if (EarilyCodeSet != null && it.E_MINS >= EarilyMin && it.E_MINS > 0)//早退
                {
                    string time_e = it.ROTE1.OFF_TIME;
                    var te = it.ADATE.AddTime(time_e);
                    var miniMinute = EarilyCodeSet.MIN_NUM * 60;
                    var minnteRate1 = decimal.Ceiling(it.E_MINS / miniMinute);
                    var tb = te.AddMinutes(Convert.ToInt32(minnteRate1 * miniMinute) * -1);
                    JBTools.Intersection its = new JBTools.Intersection();
                    its.Inert(tb, te);
                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                    abs.NOBR = it.NOBR;
                    abs.A_NAME = "";
                    abs.BDATE = it.ADATE;
                    abs.BTIME = it.ADATE.Date < tb.Date ? (tb.Hour + 24).ToString() + tb.Minute.ToString("00") : tb.ToString("HHmm");
                    abs.EDATE = it.ADATE;
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
                    it.E_MINS = 0;//請假後清空
                }
                if (AbsenceCodeSet != null && it.ABS)//曠職
                {
                    string time_b = it.ROTE1.ON_TIME;
                    string time_e = it.ROTE1.OFF_TIME;
                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                    abs.NOBR = it.NOBR;
                    abs.A_NAME = "";
                    abs.BDATE = it.ADATE;
                    abs.BTIME = time_b;
                    abs.EDATE = it.ADATE;
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
                    abs.TOL_HOURS = it.ROTE1.WK_HRS;
                    abs.YYMM = new Sal.Core.SalaryDate(abs.BDATE).YYMM;
                    dbCreateAbs.ABS.InsertOnSubmit(abs);
                    it.ABS = false;//請假後清空
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
                + " AND dbo.GetFilterByNobr(SALABS.NOBR,{6},{7},{8})=1";
            DeleteSystemCreateCmd = Sal.Function.DeleteCommand("ABS", nobr_b, nobr_e, dept_b, dept_e) + " AND SYSCREATE1=1 AND ABS.BDATE BETWEEN {4} AND {5} ";
            BW.ReportProgress(100, "正在執行..刪除自動產生的請假資料");
            int i = db.ExecuteCommand(DeleteSystemCreateCmd, new object[] { nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN });

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
