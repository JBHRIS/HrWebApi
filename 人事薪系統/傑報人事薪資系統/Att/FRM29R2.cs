using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal.Core;
using System.Data.Linq.SqlClient;
using System.Threading;
namespace JBHR.Att
{
    public partial class FRM29R2 : JBControls.JBForm
    {
        public FRM29R2()
        {
            InitializeComponent();
        }
        List<string> holi_codeList = new List<string>() { "00", "0X", "0Y", "0Z" };
        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog mdRote = new JBControls.MultiSelectionDialog();
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        private void FRM29R2_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            AppConfig = new JBModule.Data.ApplicationConfigSettings(this.Name, MainForm.COMPANY);
            //AppConfig.CheckParameterAndSetDefault("OtAcceptTime", "加班成立分鐘數", "30"
            //, "指定加班成立的時間應大於等於多少分鐘數", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("HoliMaxHour", "假日加班最大時數", "12"
            , "指定假日加班最大時數", "TextBox", "", "string");
            //AppConfig.CheckParameterAndSetDefault("HoliRestMaxHour", "假日休息最大時數", "99"
            //, "指定假日休息最大時數", "TextBox", "", "string");
            //AppConfig.CheckParameterAndSetDefault("SameTimeOtAcceptTime", "彈性刷卡最大分鐘數", "10"
            //, "當下班時間和開始加班時間相同時，給定的彈性刷卡時間，時間內刷卡皆算加班開始時間為刷卡時間", "TextBox", "", "string");
            //AppConfig.CheckParameterAndSetDefault("CanOtRote", "可加班班別", "00,0X,0Y"
            //, "指定可加班的班別代碼", "TextBox", "", "string");
            mdEmp.SetControl(buttonEmp, Repo.EmpRepo.GetEmpAllWithDept(), "員工編號");
            mdRote.SetControl(buttonRote, Repo.AttRepo.GetRote(), "_ROTE");
            SystemFunction.SetComboBoxItems(cbOTRCD, CodeFunction.GetOtrcd(), true, false, true);
            //this.oTRCDTableAdapter.Fill(this.dsAtt.OTRCD);
            //this.hCODETableAdapter.Fill(this.dsAtt.HCODE);
            //this.rOTETableAdapter.Fill(this.dsAtt.ROTE);
            this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);

            //this.ptxNobrB.Text = Sal.BaseValue.MinNobr;
            //this.ptxNobrE.Text = Sal.BaseValue.MaxNobr;
            //this.ptxDeptB.Text = Sal.BaseValue.MinDept;
            //this.ptxDeptE.Text = Sal.BaseValue.MaxDept;
            //this.ptxRoteB.Text = dsAtt.ROTE.First().ROTE;
            //this.ptxRoteE.Text = dsAtt.ROTE.Last().ROTE;
            int yy, MM, dd;
            yy = DateTime.Now.Year;
            MM = DateTime.Now.Month;
            dd = DateTime.Now.Day;
            DateTime d1, d2;
            d1 = new DateTime(yy, MM, 1);
            d2 = new DateTime(yy, MM, DateTime.DaysInMonth(yy, MM));
            txtBdate.Text = Sal.Core.SalaryDate.DateString(d1);
            txtEdate.Text = Sal.Core.SalaryDate.DateString(d2);
            ckxHoliCheckRest.Checked = true;
            ckxROTE_OT_END.Checked = true;
            txtYYMM.Focus();
            //statusStrip1.Visible = false;

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            AppConfig = new JBModule.Data.ApplicationConfigSettings(this.Name, MainForm.COMPANY);
            //var OtAcceptTime = AppConfig.GetConfig("OtAcceptTime").Value.Trim();
            var HoliMaxHour = AppConfig.GetConfig("HoliMaxHour").Value.Trim();
            //var HoliRestMaxHour = AppConfig.GetConfig("HoliRestMaxHour").Value.Trim();
            //var SameTimeOtAcceptTime = AppConfig.GetConfig("SameTimeOtAcceptTime").Value.Trim();
            //var CanOtRote = AppConfig.GetConfig("CanOtRote").Value.Trim();
            //if (string.IsNullOrWhiteSpace(CanOtRote))
            //{
            //    MessageBox.Show("請設定可加班班別", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (string.IsNullOrWhiteSpace(HoliRestMaxHour))
            //{
            //    MessageBox.Show("請設定假日休息最大時數", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //} 
            //if (string.IsNullOrWhiteSpace(OtAcceptTime))
            //{
            //    MessageBox.Show("請設定加班成立分鐘數", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //} 
            if (string.IsNullOrWhiteSpace(HoliMaxHour))
            {
                MessageBox.Show("請設定假日加班最大時數", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (string.IsNullOrWhiteSpace(SameTimeOtAcceptTime))
            //{
            //    MessageBox.Show("請設定彈性刷卡最大分鐘數", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (string.IsNullOrWhiteSpace(txtYYMM.Text))
            {
                MessageBox.Show("請指定計薪年月", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYYMM.Focus();
                return;
            }
            double iHoliMaxHour = Convert.ToDouble(HoliMaxHour);
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            List<string> CanOtRoteList = mdRote.SelectedValues; ;
            DateTime t1, t2;
            t1 = DateTime.Now;
            statusStrip_init(1);
            //string nobr_b, nobr_e, dept_b, dept_e, rote_b, rote_e;
            //nobr_b = ptxNobrB.Text;
            //nobr_e = ptxNobrE.Text;
            //dept_b = ptxDeptB.Text;
            //dept_e = ptxDeptE.Text;
            //rote_b = ptxRoteB.Text;
            //rote_e = ptxRoteE.Text;
            List<OT_Error_Dto> ErrorList = new List<OT_Error_Dto>();
            JBModule.Data.Linq.ROTE roteHoli = null;
            DateTime d1, d2;
            d1 = Convert.ToDateTime(txtBdate.Text);
            d2 = Convert.ToDateTime(txtEdate.Text);
            bool isHoli;
            int success = 0;
            int error = 0;
            DeleteOTPre();//先刪除範圍內的所有資料
            string[] ttscodes = new string[] { "1", "4", "6" };
            var attSQL = (from a in db.ATTEND
                          join b in db.ATTCARD on new { NOBR = a.NOBR, BDATE = a.ADATE } equals new { NOBR = b.NOBR, BDATE = b.ADATE } into ab
                          from attcard in ab.DefaultIfEmpty()
                          join d in db.BASE on a.NOBR equals d.NOBR
                          join r in db.ROTE on a.ROTE equals r.ROTE1
                          join t in db.BASETTS on a.NOBR equals t.NOBR
                          join h in db.HOLICD on t.HOLI_CODE equals h.HOLI_CODE
                          where mdEmp.SelectedValues.Contains(a.NOBR) //已篩選權限
                          && a.ADATE >= d1 && a.ADATE <= d2
                          && a.ADATE <= t.DDATE && a.ADATE >= t.ADATE
                          && !t.NOOT //「不產生加班」無勾選
                          && ttscodes.Contains(t.TTSCODE)
                          //&& h.SALES //  海悅客製「行事曆代碼」中的「業務性質」才要產生加班
                          //&& a.T1 != ""
                          //&& a.T2 != "" //&& (Convert.ToInt32(a.T2) - Convert.ToInt32(r.OT_BEGIN) >= int.Parse(OtAcceptTime))
                          //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          //&& db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          && CanOtRoteList.Contains(r.ROTE1)
                          && ((attcard != null && attcard.T1.Trim().Length > 0 && attcard.T2.Trim().Length > 0) || (checkBox1.Checked && t.CARD == "N"))
                          select new
                          {
                              NOBR = a.NOBR,
                              ATTCARD = attcard,
                              ROTE = new { r.ON_TIME, r.OT_BEGIN, r.ROTE1, r.ROTENAME, r.OFF_TIME, r.OFFTIME2 },
                              BASETTS = new { t.NOBR, t.DEPTS, t.CALOT, t.CARD },
                              ATTEND = new { a.ADATE, a.NOBR, a.ROTE, r, a.ROTE_H },
                              BASE = new { d.NAME_C },
                          }).ToList();
            var cardList = (from a in db.CARD
                            where a.ADATE >= d1 && a.ADATE <= d2.AddDays(1)
                            && mdEmp.SelectedValues.Contains(a.NOBR)
                            select a).ToList();
            var attNotHoliList = (from a in db.ATTEND
                                  join b in db.ROTE on a.ROTE equals b.ROTE1
                                  where a.ADATE >= d1.AddDays(-1)
                                  && !holi_codeList.Contains(a.ROTE)
                                   && mdEmp.SelectedValues.Contains(a.NOBR)
                                  orderby a.ADATE
                                  select new { ATTEND = new { a.NOBR, a.ADATE, a.ROTE }, ROTE = b }).ToList();
            int counts = attSQL.Distinct().Count();
            success = 0;
            error = 0;
            statusStrip_init(counts);
            statusStrip1.Visible = true;
            string BeginTime = "", EndTime = "";

            foreach (var itm in attSQL.Distinct())
            {
                OT_Error_Dto err_mag = new OT_Error_Dto();
                err_mag.Nobr = itm.NOBR;
                err_mag.Name = itm.BASE.NAME_C;
                err_mag.BDate = itm.ATTEND.ADATE.ToShortDateString();

                try
                {
                    toolStripProgressBar1.Value++;
                    //var cardByNobr = GetFilterOtCardByDay(cardList, itm.NOBR, itm.ATTCARD.ADATE, itm.ROTE.OFFTIME2, itm.ROTE.OFF_TIME);
                    //if (!holi_codeList.Contains(itm.ATTEND.ROTE) && cardByNobr.Count() < 2) continue;//正常下班+加班上下班最少 3筆
                    string rote = "";
                    string OTrote = "";

                    #region 檢查班表
                    if (string.IsNullOrWhiteSpace(itm.ATTEND.ROTE))
                    {
                        err_mag.Error = "無出勤班表";
                        ErrorList.Add(err_mag);
                        error++;
                        continue;
                    }
                    rote = itm.ATTEND.ROTE;
                    OTrote = itm.ATTEND.ROTE;

                    #region 班別轉非假日班 -- 已拿掉
                    if (holi_codeList.Contains(OTrote))
                    {
                        //var att = from a in db.ATTEND
                        //          join b in db.ROTE on a.ROTE equals b.ROTE1
                        //          where a.NOBR == itm.BASETTS.NOBR
                        //          && a.ADATE >= itm.ATTEND.ADATE.AddDays(-1)
                        //          && a.ROTE != holi_code
                        //          orderby a.ADATE
                        //          select new { ATTEND = a, ROTE = b };
                        if (holi_codeList.Contains(itm.ATTEND.ROTE_H))
                        {
                            var att = from a in attNotHoliList where a.ATTEND.NOBR == itm.ATTEND.NOBR && a.ATTEND.ADATE >= itm.ATTEND.ADATE.AddDays(-1) select a;
                            if (att.Any())
                            {
                                OTrote = att.First().ATTEND.ROTE;//前一個非假日班班別
                                roteHoli = att.First().ROTE;
                            }
                        }
                        else
                        {
                            OTrote = itm.ATTEND.ROTE_H;
                            roteHoli = db.ROTE.Where(p=>p.ROTE1 == itm.ATTEND.ROTE_H).FirstOrDefault();
                        }
                    }
                    else
                    {
                        roteHoli = attNotHoliList.Where(p => p.ATTEND.NOBR == itm.ATTEND.NOBR && p.ATTEND.ADATE == itm.ATTEND.ADATE).FirstOrDefault().ROTE;
                    }
                    #endregion

                    isHoli = holi_codeList.Contains(rote) ? true : false;

                    #endregion

                    if (!isHoli && string.IsNullOrWhiteSpace(itm.ROTE.OT_BEGIN))
                    {
                        err_mag.Error = string.Format("無({0}-{1})班別的加班起始時間", itm.ROTE.ROTE1, itm.ROTE.ROTENAME);
                        ErrorList.Add(err_mag);
                        error++;
                        continue;
                    }
                    if (itm.BASETTS.CARD == "N")
                    {
                        BeginTime = isHoli ? roteHoli.ON_TIME : roteHoli.OT_BEGIN;
                        EndTime = itm.ATTEND.ADATE.AddTime(BeginTime).AddHours(iHoliMaxHour).TimeStringBy48HR(itm.ATTEND.ADATE);
                    }
                    else if (itm.ATTCARD != null)
                    {
                        BeginTime = isHoli ? itm.ATTCARD.T1 : itm.ROTE.OT_BEGIN;
                        EndTime = itm.ATTCARD.T2;
                    }
                    #region 撈取假日上下班時間
                    if (checkBoxHoliROTE.Checked)
                    {
                        if (isHoli && roteHoli != null && itm.ATTCARD != null)
                        {
                            var iT1 = Convert.ToInt32(itm.ATTCARD.T1);
                            var iT2 = Convert.ToInt32(itm.ATTCARD.T2);
                            if (!string.IsNullOrWhiteSpace(roteHoli.ON_TIME) && iT1 < Convert.ToInt32(roteHoli.ON_TIME))
                            {
                                BeginTime = roteHoli.ON_TIME;
                            }
                            if (!string.IsNullOrWhiteSpace(roteHoli.OFF_TIME) && iT2 > Convert.ToInt32(roteHoli.OFF_TIME))
                            {
                                EndTime = roteHoli.OFF_TIME;
                            }
                        }
                    }
                    #endregion
                    #region 判斷加班開始時間 -- 已註解
                    //判斷加班開始時間
                    //if (!isHoli && !string.IsNullOrWhiteSpace(itm.ROTE.OFF_TIME) && !string.IsNullOrWhiteSpace(itm.ROTE.OT_BEGIN))
                    //{
                    //    string cardBTime1 = cardByNobr.Take(1).First().ONTIME;
                    //    DateTime cardDate1 = cardByNobr.Take(1).First().ADATE;
                    //    DateTime dtCardBTime1 = cardDate1.AddHours(Convert.ToInt32(cardBTime1.Substring(0, 2))).AddMinutes(Convert.ToInt32(cardBTime1.Substring(2)));
                    //    string cardBTime2 = cardByNobr.Skip(1).Take(1).First().ONTIME;
                    //    DateTime cardDate2 = cardByNobr.Skip(1).Take(1).First().ADATE;
                    //    DateTime dtCardBTime2 = cardDate2.AddHours(Convert.ToInt32(cardBTime2.Substring(0, 2))).AddMinutes(Convert.ToInt32(cardBTime2.Substring(2)));
                    //    DateTime otBTime = itm.ATTCARD.ADATE.AddHours(Convert.ToInt32(itm.ROTE.OT_BEGIN.Substring(0, 2))).AddMinutes(Convert.ToInt32(itm.ROTE.OT_BEGIN.Substring(2)));
                    //    DateTime dtCardOnTime = cardByNobr.Count > 2 ? dtCardBTime2 : dtCardBTime1;//若只有兩張卡，以第一張卡當作加班起始時間
                    //    if (itm.ROTE.OFF_TIME == itm.ROTE.OT_BEGIN)//下班時間與加班開始時間「相同」
                    //    {
                    //        DateTime acceptTime = dtCardBTime1.AddMinutes(Convert.ToInt32(SameTimeOtAcceptTime));//加入彈性分鐘數
                    //        if (dtCardOnTime > acceptTime)//超過彈性時間，以刷卡時間為加班開始時間
                    //            BeginTime = transTo48times(cardBTime2, itm.ATTCARD.ADATE, cardDate2);

                    //    }
                    //    else//下班時間與加班開始時間「不同」
                    //    {
                    //        if (dtCardOnTime > otBTime)//刷卡時間筆加班時間晚，以刷卡時間為加班開始時間
                    //            BeginTime = transTo48times(cardBTime2, itm.ATTCARD.ADATE, cardDate2);
                    //    }
                    //}


                    //if (ckxROTE_OT_END.Checked)//是否有勾選「判斷加班結束時間」
                    //{
                    //    if(!string.IsNullOrWhiteSpace(itm.ROTE.OT_END) && Convert.ToInt32(itm.ROTE.OT_END) < Convert.ToInt32(itm.ATTCARD.T2))
                    //        EndTime = itm.ROTE.OT_END;
                    //}
                    #endregion

                    if (Convert.ToInt32(BeginTime) >= Convert.ToInt32(EndTime))
                        continue;

                    err_mag.BTime = BeginTime;
                    err_mag.ETime = EndTime;



                    //檢查有無重疊加班時段
                    //不算成功也不算失敗
                    //JBModule.Data.Linq.HrDBDataContext trans_db = new JBModule.Data.Linq.HrDBDataContext();
                    //using (JBModule.Data.Linq.HrDBDataContext trans_db = new JBModule.Data.Linq.HrDBDataContext())
                    //{
                    //    if (trans_db.Connection.State != ConnectionState.Open) trans_db.Connection.Open();
                    //    var trans = trans_db.Connection.BeginTransaction();
                    //    trans_db.Transaction = trans;
                    //    try
                    //    {
                    #region 檢查有無交集時段 --已拿掉
                    //var otData = JBHR.BLL.Att.OverTime.GetExistsOT(itm.ATTCARD.NOBR, itm.ATTCARD.ADATE, itm.ATTCARD.ADATE, BeginTime, itm.ATTCARD.T2);
                    //if (otData.Any())
                    //{
                    //    if (!checkBox1.Checked) continue;
                    //    foreach (var it in otData)
                    //    {
                    //        var sql = from a in trans_db.OTPRE
                    //                  where a.NOBR == it.Nobr
                    //                      && a.ADATE == it.DateB && a.BTIME == it.Btime && a.ETIME == it.Etime
                    //                  select a;
                    //        if (sql.Any())
                    //        {
                    //            toolStripStatusLabel1.Text = string.Format("刪除 {0}({1}) {2}的加班中...", itm.BASE.NAME_C, itm.BASE.NOBR, itm.ATTCARD.ADATE.ToShortDateString());
                    //            this.Refresh();
                    //            trans_db.OT.DeleteAllOnSubmit(sql);
                    //        }
                    //    }
                    //    trans_db.SubmitChanges();
                    //}
                    #endregion
                    Dal.Dao.Att.OtDao oOtDao = new Dal.Dao.Att.OtDao(db.Connection);
                    DateTime ADate = itm.ATTEND.ADATE;
                    string saladr = Sal.Core.SalaryDate.GetSaladr(itm.NOBR, ADate);
                    //string yymm = Sal.Core.SalaryDate.CheckAttendLock(ADate, saladr) ?
                    //    Sal.Core.SalaryDate.GetUnLockYYMM(ADate, saladr) : new Sal.Core.SalaryDate(ADate).YYMM;
                    //SalaryDate sd = new SalaryDate(yymm);
                    //yymm = sd.GetNextSalaryDate().YYMM;
                    //string yymm = Sal.Core.SalaryDate.GetUnLockYYMM(ADate, saladr, true);
                    string yymm = txtYYMM.Text;
                    decimal otHour = 0;
                    bool isEat = ckxHoliCheckRest.Checked && isHoli;
                    //true 扣除休息時間
                    var ot_calc = oOtDao.GetCalculate(itm.BASETTS.NOBR, "1", itm.ATTEND.ADATE, itm.ATTEND.ADATE, (BeginTime), (EndTime), "", 0, OTrote, isEat, true);
                    otHour = ot_calc;
                    //if (ot_calc > Convert.ToDecimal(HoliRestMaxHour) && !isEat && isHoli)
                    //    otHour = ot_calc - Convert.ToDecimal(HoliRestMaxHour);

                    if (otHour > Convert.ToDecimal(HoliMaxHour) && isHoli) otHour = Convert.ToDecimal(HoliMaxHour);
                    if (otHour <= 0) continue;
                    toolStripStatusLabel1.Text = string.Format("產生 {0}({1}) {2}的加班中...", itm.BASE.NAME_C, itm.NOBR, itm.ATTEND.ADATE.ToShortDateString());
                    this.Refresh();
                    //Thread.Sleep(1000);

                    //休息日加班時間區間計算
                    decimal original_OtHrs = otHour;
                    if (itm.ATTEND.ROTE == "0X")
                    {
                        JBModule.Data.Repo.OtratecdRepo otratecdRepo = new JBModule.Data.Repo.OtratecdRepo(db.Connection);
                        otHour = otratecdRepo.GetOtHrsBySal(itm.BASETTS.CALOT, otHour);
                    }
                    //else if (isHoli)//假日破壞性原則，需最少給一日(8小時)薪資
                    //{
                    //    if (otHour < 8) otHour = 8;
                    //}
                    #region insert to OT --已拿掉
                    //JBModule.Data.Linq.OT ot = new JBModule.Data.Linq.OT();
                    //ot.BDATE = itm.ATTCARD.ADATE;
                    //ot.BTIME = BeginTime;
                    //ot.CANT_ADJ = true;
                    //ot.DIFF = 0;
                    //ot.EAT = false;
                    //ot.ETIME = itm.ATTCARD.T2;
                    //ot.FIX_AMT = false;
                    //ot.FOOD_CNT = 0;
                    //ot.FOOD_PRI = 0;
                    //ot.FST_HOURS = 0;
                    //ot.HOT_133 = 0;
                    //ot.HOT_166 = 0;
                    //ot.HOT_200 = 0;
                    //ot.KEY_DATE = DateTime.Now;
                    //ot.KEY_MAN = MainForm.USER_NAME;
                    //ot.NOBR = itm.ATTCARD.NOBR;
                    //ot.NOFOOD = false;
                    //ot.NOFOOD1 = false;
                    //ot.NOP_H_100 = 0;
                    //ot.NOP_H_133 = 0;
                    //ot.NOP_H_167 = 0;
                    //ot.NOP_H_200 = 0;
                    //ot.NOP_W_100 = 0;
                    //ot.NOP_W_133 = 0;
                    //ot.NOP_W_167 = 0;
                    //ot.NOP_W_200 = 0;
                    //ot.NOT_EXP = 0;
                    //ot.NOT_H_133 = 0;
                    //ot.NOT_H_167 = 0;
                    //ot.NOT_H_200 = 0;
                    //ot.NOT_W_100 = 0;
                    //ot.NOT_W_133 = 0;
                    //ot.NOT_W_167 = 0;
                    //ot.NOT_W_200 = 0;
                    //ot.NOTE = "系統自動產生";
                    //ot.NOTMODI = false;
                    //ot.OT_CAR = 0;//
                    //ot.OT_DEPT = itm.BASETTS.DEPT;
                    //ot.OT_EDATE = itm.ATTCARD.ADATE.AddMonths(3).AddDays(-1);
                    //ot.OT_FOOD = 0;//
                    //ot.OT_FOOD1 = 0;//
                    //ot.OT_FOODH = 0;
                    //ot.OT_FOODH1 = 0;
                    //ot.OT_ROTE = rote;
                    //ot.OT_HRS = JBHR.Dll.Att.OtCal.CalculationOt(itm.ATTCARD.NOBR, rote, itm.ATTCARD.ADATE, BeginTime, itm.ATTCARD.T2).iHour;
                    //ot.OTNO = "";
                    //ot.OTRATE_CODE = "";//
                    //ot.OTRCD = "";
                    //ot.REC = 0;
                    //ot.RES = false;
                    //ot.REST_EXP = 0;//
                    //ot.REST_HRS = 0;
                    //ot.SALARY = 0;
                    //ot.SER = "";
                    //ot.SERNO = "";
                    //ot.SUM = false;//
                    //ot.SYS_OT = false;
                    //ot.SYSCREAT = false;//
                    //ot.SYSCREAT1 = false;//
                    //ot.TOP_H_200 = 0;
                    //ot.TOP_W_100 = 0;
                    //ot.TOP_W_133 = 0;
                    //ot.TOP_W_167 = 0;
                    //ot.TOP_W_200 = 0;
                    //ot.TOT_EXP = 0;
                    //ot.TOT_H_200 = 0;
                    //ot.TOT_HOURS = ot.OT_HRS + ot.REST_HRS;
                    //ot.TOT_W_100 = 0;
                    //ot.TOT_W_133 = 0;
                    //ot.TOT_W_167 = 0;
                    //ot.TOT_W_200 = 0;
                    //ot.WOT_133 = 0;
                    //ot.WOT_166 = 0;
                    //ot.WOT_200 = 0;
                    //ot.YYMM = yymm;
                    //trans_db.OT.InsertOnSubmit(ot);

                    //申請補修
                    //JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM211", MainForm.COMPANY);
                    //var CompseCode = AppConfig.GetConfig("ComposeLeaveGetCode").GetString();
                    //if (CompseCode.Trim().Length > 0)
                    //{
                    //    if (ot.REST_HRS > 0)
                    //    {
                    //        JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                    //        abs.A_NAME = "";
                    //        abs.BDATE = ot.BDATE;
                    //        abs.BTIME = ot.BTIME;
                    //        abs.EDATE = ot.BDATE.AddMonths(6);
                    //        abs.ETIME = ot.ETIME;
                    //        abs.H_CODE = CompseCode;
                    //        abs.KEY_DATE = DateTime.Now;
                    //        abs.KEY_MAN = MainForm.USER_NAME;
                    //        abs.NOBR = ot.NOBR;
                    //        abs.nocalc = false;
                    //        abs.NOTE = ot.NOTE;
                    //        abs.NOTEDIT = false;
                    //        abs.SERNO = ot.SERNO;
                    //        abs.SYSCREATE = false;
                    //        abs.TOL_DAY = 0;
                    //        abs.TOL_HOURS = ot.REST_HRS;
                    //        abs.YYMM = ot.YYMM;
                    //        var sql = from a in trans_db.ABS
                    //                  where a.NOBR == abs.NOBR
                    //                  && a.BDATE == abs.BDATE && a.BTIME == abs.BTIME
                    //                  && a.H_CODE == abs.H_CODE
                    //                  select a;
                    //        if (!sql.Any())//不存在才新增
                    //        {
                    //            trans_db.ABS.InsertOnSubmit(abs);
                    //        }
                    //    }
                    //}
                    #endregion

                    JBModule.Data.Linq.OTPRE ae = new JBModule.Data.Linq.OTPRE();
                    ae.OT_DEPT = itm.BASETTS.DEPTS;
                    ae.ADATE = itm.ATTEND.ADATE;
                    ae.BTIME = BeginTime;
                    ae.ETIME = EndTime;
                    //var ot_calc = Dll.Att.OtCal.CalculationOt(itm.BASETTS.NOBR, rote, ae.ADATE, ae.BTIME, ae.ETIME);
                    ae.OT_ROTE = OTrote;
                    ae.KEY_DATE = DateTime.Now;
                    ae.KEY_MAN = MainForm.USER_NAME;
                    ae.NOBR = itm.BASETTS.NOBR;
                    ae.YYMM = yymm;
                    ae.OT_HRS = otHour;
                    ae.SUG_HRS = otHour;
                    ae.REST_HRS = 0;
                    ae.OT1_HRS = original_OtHrs;
                    ae.OT2_HRS = 0;
                    ae.SYS_OT = isHoli;
                    ae.TRANP = true;
                    ae.TRANS = false;
                    ae.OTRCD = cbOTRCD.SelectedValue.ToString();
                    ae.NOTE = txtNote.Text;

                    db.OTPRE.InsertOnSubmit(ae);
                    db.SubmitChanges();
                    //trans.Commit();
                    success++;
                    //}
                    //catch(Exception ex)
                    //{
                    //    trans.Rollback();
                    //    err_mag.Error = ex.Message;
                    //    ErrorList.Add(err_mag);
                    //    error++;
                    //    continue;
                    //}
                    //}
                }
                catch (Exception ex)
                {
                    err_mag.Error = ex.Message;
                    ErrorList.Add(err_mag);
                    error++;
                    continue;
                }
            }

            toolStripStatusLabel1.Text = "處理完畢";
            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


            if (ErrorList.Count == 0)
            {
                MessageBox.Show("導入成功");
            }
            else
            {
                DataTable dt = errorListToDateTable(ErrorList);
                String errorDataPath = "C:\\temp\\" + this.Text + "(" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ").xls";
                JBModule.Data.CNPOI.ExportToExcel(dt, errorDataPath, "");
                MessageBox.Show("成功: " + success + "筆，失敗: " + error + "筆。\n\n" + "錯誤資料匯出 : " + errorDataPath, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            //statusStrip1.Visible = false;
        }
        /// <summary>
        /// 以半小時無條件進位
        /// </summary>
        /// <param name="bTime"></param>
        /// <returns></returns>
        public string transBtime(string bTime)
        {
            int iTimeB = Bll.Tools.TimeTrans.ConvertHhMmToMinutes(bTime);
            int iTemp = (30 - (iTimeB % 30));
            iTimeB = iTemp == 30 ? iTimeB : iTimeB + iTemp;
            string TimeB = Bll.Tools.TimeTrans.ConvertMinutesToHhMm(iTimeB);
            return TimeB;
        }
        /// <summary>
        /// 以半小時無條件捨去
        /// </summary>
        /// <param name="eTime"></param>
        /// <returns></returns>
        public string transEtime(string eTime)
        {
            int iTimeE = Bll.Tools.TimeTrans.ConvertHhMmToMinutes(eTime);
            int iTemp = iTimeE % 30;
            iTimeE -= iTemp;
            string TimeE = Bll.Tools.TimeTrans.ConvertMinutesToHhMm(iTimeE);
            return TimeE;
        }

        public string transTo48times(string time, DateTime attDate, DateTime CardDate)
        {
            int hh = Convert.ToInt32(time.Substring(0, 2));
            int mm = Convert.ToInt32(time.Substring(2));
            if (CardDate > attDate)
                hh += 24;
            return hh.ToString().PadLeft(2, '0') + mm.ToString().PadLeft(2, '0');
        }
        List<JBModule.Data.Linq.CARD> GetFilterOtCardByDay(List<JBModule.Data.Linq.CARD> cardList, string nobr, DateTime aDate, string offTime2, string offTime)
        {
            if (string.IsNullOrWhiteSpace(offTime2)) offTime2 = "0000";
            int time2 = Convert.ToInt32(offTime2);
            var dayCardList = (from a in cardList
                               where a.NOBR == nobr
                               && ((a.ADATE == aDate && Convert.ToInt32(a.ONTIME) > time2)
                               || (a.ADATE == aDate.AddDays(1) && Convert.ToInt32(a.ONTIME) <= time2))
                               select a).ToList();
            if (string.IsNullOrWhiteSpace(offTime)) offTime = "0000";
            var time = aDate.AddHours(Convert.ToInt32(offTime.Substring(0, 2))).AddMinutes(Convert.ToInt32(offTime.Substring(2)));
            var result = (from a in dayCardList
                          let aDateTime = a.ADATE.AddHours(Convert.ToInt32(a.ONTIME.Substring(0, 2))).AddMinutes(Convert.ToInt32(a.ONTIME.Substring(2)))
                          where aDateTime >= time
                          orderby a.ONTIME
                          select a).ToList();

            return result;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void statusStrip_init(int max)
        {
            statusStrip1.Visible = true;
            toolStripProgressBar1.Enabled = true;
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = max;
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel1.Text = "資料載入中";
            this.Refresh();
        }

        private void txtBdate_Validated(object sender, EventArgs e)
        {
            var date = Convert.ToDateTime(txtBdate.Text);
            var EDATE = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            txtEdate.Text = EDATE.ToShortDateString();
        }

        DataTable errorListToDateTable(List<OT_Error_Dto> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("員工編號");
            dt.Columns.Add("姓名");
            dt.Columns.Add("加班日期");
            dt.Columns.Add("加起時間");
            dt.Columns.Add("加迄時間");
            dt.Columns.Add("錯誤訊息");

            foreach (var it in list)
            {
                dt.Rows.Add(it.Nobr, it.Name, it.BDate, it.BTime, it.ETime, it.Error);
            }
            return dt;
        }
        void DeleteOTPre()
        {
            string otrcd;
            DateTime date_b, date_e;
            date_b = Convert.ToDateTime(txtBdate.Text);
            date_e = Convert.ToDateTime(txtEdate.Text);
            otrcd = cbOTRCD.SelectedValue.ToString();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = (from a in db.OTPRE
                       join at in db.ATTEND on new { a.NOBR, a.ADATE } equals new { at.NOBR, at.ADATE }
                       //join x in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals x.NOBR
                       where mdEmp.SelectedValues.Contains(a.NOBR)
                       && mdRote.SelectedValues.Contains(at.ROTE)
                           && a.ADATE >= date_b && a.ADATE <= date_e
                       select a).ToList();
            db.OTPRE.DeleteAllOnSubmit(sql);
            db.SubmitChanges();
            //string cmd = "DELETE OTPRE"
            //    + " WHERE EXISTS (SELECT 1 FROM BASETTS WHERE OTPRE.NOBR = BASETTS.NOBR AND"
            //    + " OTPRE.ADATE BETWEEN BASETTS.ADATE AND BASETTS.DDATE"
            //    + " AND BASETTS.DEPT BETWEEN {2} AND {3})"
            //    + " AND OTPRE.NOBR BETWEEN {0} AND {1}"
            //    + " AND OTPRE.ADATE BETWEEN {6} AND {7}"
            //    + " AND dbo.GetFilterByNobr(OTPRE.NOBR,{9},{10},{11})=1";
            //object[] PARA = new object[] { nobr_b, nobr_e, dept_b, dept_e, rote_b, rote_e, date_b.ToShortDateString(), date_e.ToShortDateString(), otrcd, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            //db.ExecuteCommand(cmd, PARA);
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteOTPre();
            }
            catch (Exception ex)
            {
                MessageBox.Show("刪除失敗，失敗原因如下：\n" + ex.Message);
                return;
            }
            MessageBox.Show("刪除完畢");
        }

        private void txtYYMM_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtYYMM.Text)) return;
            try
            {
                int yy = Convert.ToInt16(txtYYMM.Text.Substring(0, 4));
                int mm = Convert.ToInt16(txtYYMM.Text.Substring(4, 2));
                var i = DateTime.DaysInMonth(yy, mm);
            }
            catch
            {
                MessageBox.Show("格式錯誤\n請輸入六碼: yyyyMM");
                txtYYMM.Focus();
            }
        }
    }
    public class OT_Error_Dto
    {
        [DisplayName("員工編號")]
        public string Nobr { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("加班日期")]
        public string BDate { get; set; }

        [DisplayName("加起時間")]
        public string BTime { get; set; }

        [DisplayName("加迄時間")]
        public string ETime { get; set; }

        [DisplayName("錯誤訊息")]
        public string Error { get; set; }

    }
}
