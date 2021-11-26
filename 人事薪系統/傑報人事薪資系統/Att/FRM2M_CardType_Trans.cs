using JBModule.Data.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JBTools.Extend;
using JBModule.Data;

namespace JBHR.Att
{
    public partial class FRM2M_CardType_Trans : JBControls.JBForm
    {
        public FRM2M_CardType_Trans()
        {
            InitializeComponent();
            EmpInitial();
        }

        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        //List<string> nobrs = new List<string>();
        //bool isTrans = false;
        //DateTime d1, d2;
        CheckYYMMFormatControl CYYMMFC = new CheckYYMMFormatControl();
        private void FRM2M_CardType_Trans_Load(object sender, EventArgs e)
        {
            CYYMMFC.AddControl(txtYYMM, true);
            EmpInitial();
        }
        private void EmpInitial()
        {
            Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(DateTime.Now.Date);
            dtpBDate.Value = sd.FirstDayOfSalary;
            dtpEDate.Value = sd.LastDayOfSalary;
            txtYYMM.Text = sd.YYMM;
            SetEmpList();
        }

        void SetEmpList()
        {
            //DateTime ndate = DateTime.Today;//Convert.ToDateTime(dtpADATE.Text);
            DateTime bdate = dtpBDate.Value;
            DateTime edate = dtpEDate.Value;
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join j in db.JOBL on b.JOBL equals j.JOBL1
                      join mt in db.MTCODE on b.TTSCODE equals mt.CODE
                      join ad in (db.ATTEND.Where(p => p.ADATE >= bdate && p.ADATE <= edate).GroupBy(p => p.NOBR)) on a.NOBR equals ad.Key
                      join ud in (from udv in db.UserDefineValue
                                  join uds in db.UserDefineSource on udv.SourceID equals uds.SourceID
                                  join md in db.MealGroup on udv.Value equals md.MealGroup_Code
                                  select new { udv.Code, md.MealGroup_Code, md.MealGroup_DISP, md.MealGroup_Name }) on a.NOBR equals ud.Code
                      //join c in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals c.NOBR
                      where edate >= b.ADATE && edate <= b.DDATE.Value
                      //&& new string[] { "1", "4", "6" }.Contains(b.TTSCODE)
                      && mt.CATEGORY == "TTSCODE"
                      //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      orderby a.NOBR
                      select new
                      {
                          員工編號 = a.NOBR,
                          姓名 = a.NAME_C,
                          用餐群组 = ud.MealGroup_DISP + "-" + ud.MealGroup_Name,
                          異動狀態 = new string[] { "1", "4", "6" }.Contains(mt.CODE) ? "在職" : mt.NAME,
                          異動日期 = new string[] { "1", "4", "6" }.Contains(mt.CODE) ? null : b.OUDT != null ? b.OUDT : b.STDT != null ? b.STDT : null,
                          職等 = j.JOB_NAME,
                          編制部門 = b.DEPT1.D_NAME
                      };
            mdEmp.SetControl(btnEmp, sql.CopyToDataTable(), "員工編號");
            //mdEmp.SelectedValues.Clear();
            //btnEmp.Text = "请选择需轉換的人员";
        }
        private void btnGen_Click(object sender, EventArgs e)
        {
            var control = CYYMMFC.CheckRequiredFields();
            if (control != null)
            {
                MessageBox.Show("此欄位為必填欄位.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                control.Focus();
                return;
            }

            var nobrs = mdEmp.SelectedValues;
            var d1 = dtpBDate.Value;
            var d2 = dtpEDate.Value;
            var yymm = txtYYMM.Text;
            object[] parameters = new object[] { nobrs, d1, d2, yymm };

            BW.RunWorkerAsync(parameters);
            this.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            string msg = "";
            try
            {
                HrDBDataContext db = new HrDBDataContext();
                //BW.ReportProgress(0, string.Format("正在删除刷卡餐别资料..."));
                var MealTypes = db.MealType.ToList();
                var MealCaseSettings = db.MealCaseSetting.ToList();

                object[] parameters = e.Argument as object[];
                List<string> nobrs = parameters[0] as List<string>;
                DateTime d1 = (parameters[1] as DateTime?).GetValueOrDefault(DateTime.Today);
                DateTime d2 = (parameters[2] as DateTime?).GetValueOrDefault(DateTime.Today);
                string yymm = parameters[3] as string;

                JBTools.Stopwatch sw = new JBTools.Stopwatch();
                sw.Start();
                var totalcount = Math.Ceiling((decimal)nobrs.Count() / (decimal)100);
                int nowcount = 0;
                foreach (var item in nobrs.Split(100))
                {
                    BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(nowcount) / Convert.ToDecimal(totalcount) * 100), "正在轉換刷卡餐別");
                    MealCardGenerator generator = new MealCardGenerator(item, d1, d2, yymm);
                    generator.KeyMan = MainForm.USER_NAME;
                    generator.Generate();
                    nowcount++;
                }
                
                //foreach (var item in nobrs.Split(1000))
                //{
                //    BW.ReportProgress(0, "正在刪除資料...");
                //    var deleteSql = from mct in db.MealCardType
                //                    where mct.ADATE.Date.CompareTo(d1) >= 0 && mct.ADATE.Date.CompareTo(d2) <= 0
                //                    && item.Contains(mct.NOBR)
                //                    && !mct.NoTrans
                //                    select mct;
                //    db.MealCardType.DeleteAllOnSubmit(deleteSql);
                //    db.SubmitChanges();
                //    var FoodCardSql = (from fc in db.FOOD_CARD
                //                       where fc.ADATE.Date.CompareTo(d1) >= 0 && fc.ADATE.Date.CompareTo(d2.AddDays(1)) <= 0
                //                       && item.Contains(fc.NOBR)
                //                       orderby fc.NOBR, fc.ADATE, fc.ONTIME
                //                       select new { 員工編號 = fc.NOBR, 刷卡日期 = fc.ADATE, 刷卡時間 = fc.ONTIME, 不轉換 = fc.NOT_TRAN }).ToList();
                //    var groupSQL = (from row in FoodCardSql group row by row.員工編號 into g1 select g1).ToList();

                //    var applySQL = (from ma in db.MEALAPPLYRECORD
                //                    where ma.ADATE.Date.CompareTo(d1) >= 0 && ma.ADATE.Date.CompareTo(d2) <= 0
                //                    && item.Contains(ma.NOBR)
                //                    orderby ma.NOBR, ma.ADATE
                //                    select new { 員工編號 = ma.NOBR, 申請日期 = ma.ADATE, 用餐群組 = ma.MealGroup, 申請餐別 = ma.MealType }).ToList();
                //    var attendSQL = (from ac in db.ATTCARD
                //                     join a in db.ATTEND on new { ac.NOBR, ac.ADATE } equals new { a.NOBR, a.ADATE }
                //                     join r in db.ROTE on a.ROTE equals r.ROTE1
                //                     where item.Contains(ac.NOBR) && ac.ADATE.CompareTo(d1) >= 0 && ac.ADATE.CompareTo(d2) <= 0
                //                     select new { 員工編號 = ac.NOBR, 刷卡日期 = ac.ADATE, 刷起時間 = ac.T1, 刷迄時間 = ac.T2, 上班時間 = r.ON_TIME, 下班時間 = r.OFF_TIME }).ToList();
                //    var otSQL = (from o in db.OT
                //                 where o.BDATE.Date.CompareTo(d1) >= 0 && o.BDATE.Date.CompareTo(d2) <= 0
                //                 && item.Contains(o.NOBR)
                //                 orderby o.NOBR, o.BDATE
                //                 select new { 員工編號 = o.NOBR, 加班日期 = o.BDATE, 加起時間 = o.BTIME, 加迄時間 = o.ETIME }).ToList();

                //    var mealcardtypeSQL = (from mct in db.MealCardType
                //                           where item.Contains(mct.NOBR) && mct.ADATE.CompareTo(d1) >= 0 && mct.ADATE.CompareTo(d2) <= 0
                //                           select mct).ToList();
                //    //var eatSQL = (from mct in db.MealCardType
                //    //                  where mct.ADATE.Date.CompareTo(d1) >= 0 && mct.ADATE.Date.CompareTo(d2) <= 0
                //    //                 && item.Contains(mct.NOBR)
                //    //                  orderby mct.NOBR, mct.ADATE
                //    //                  select new { 員工編號 = mct.NOBR, 用餐日期 = mct.ADATE, 用餐時間 = mct.BTIME, 用餐群組 = mct.MealGroup, 用餐餐別 = mct.MealType }).ToList();
                //    int total = groupSQL.Count();
                //    int count = 0;
                //    foreach (var Nobr in groupSQL)
                //    {
                //        string nobr = Nobr.Key;
                //        string nobrmealgroup = CodeFunction.GetUserDefineValue(db, nobr, "MealGroup", string.Empty);
                //        var FoodCardbyNobr = FoodCardSql.Where(p => p.員工編號 == nobr);
                //        var NobrMealTypes = db.MealType.Where(p => p.MealGroup == nobrmealgroup).ToList();
                //        BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 100), "正在转换" + nobr + "刷卡餐别");
                //        foreach (var FC in FoodCardbyNobr)
                //        {
                //            if (!FC.不轉換)
                //            {
                //                MealCardType mealCardType = new MealCardType();
                //                mealCardType.NOBR = FC.員工編號;
                //                mealCardType.ADATE = FC.刷卡日期;
                //                mealCardType.BTIME_Source = FC.刷卡時間;
                //                mealCardType.NoTrans = false;
                //                mealCardType.Lost = false;
                //                mealCardType.SeroNo = Guid.NewGuid().ToString();
                //                mealCardType.KEY_MAN = MainForm.USER_NAME;
                //                mealCardType.KEY_DATE = DateTime.Now;
                //                mealCardType.BTIME = string.Empty;
                //                mealCardType.MealType = string.Empty;

                //                if (!string.IsNullOrWhiteSpace(nobrmealgroup))
                //                {
                //                    mealCardType.MealGroup = nobrmealgroup;
                //                    foreach (var MT in NobrMealTypes)
                //                    {
                //                        int intBT = Convert.ToInt32(MT.BTime);
                //                        int intET = Convert.ToInt32(MT.ETime);
                //                        int intTime = Convert.ToInt32(FC.刷卡時間);
                //                        int intPreTime = intTime + 2400;
                //                        if (intTime >= intBT && intTime <= intET)
                //                        {
                //                            mealCardType.ADATE = FC.刷卡日期;
                //                            mealCardType.BTIME = intTime.ToString("0000");
                //                            mealCardType.MealType = MT.MealType_Code;
                //                            break;
                //                        }
                //                        else if (intBT >= 2400 && intPreTime >= intBT && intPreTime <= intET)
                //                        {
                //                            mealCardType.ADATE = FC.刷卡日期.AddDays(-1);
                //                            mealCardType.BTIME = intPreTime.ToString("0000");
                //                            mealCardType.MealType = MT.MealType_Code;
                //                            break;
                //                        }
                //                        else if (intET >= 2400)
                //                        {
                //                            if (intTime >= intBT)
                //                            {
                //                                mealCardType.ADATE = FC.刷卡日期;
                //                                mealCardType.BTIME = intTime.ToString("0000");
                //                                mealCardType.MealType = MT.MealType_Code;
                //                                break;
                //                            }
                //                            else if (intPreTime <= intET)
                //                            {
                //                                mealCardType.ADATE = FC.刷卡日期.AddDays(-1);
                //                                mealCardType.BTIME = intPreTime.ToString("0000");
                //                                mealCardType.MealType = MT.MealType_Code;
                //                                break;
                //                            }
                //                        }
                //                    }
                //                }
                //                if (mealCardType.ADATE >= d1 && mealCardType.ADATE <= d2)
                //                {
                //                    MealCardType mealCardTypeOld = mealcardtypeSQL.Where(p => p.NOBR == FC.員工編號
                //                                                     && p.ADATE == FC.刷卡日期 && p.BTIME == FC.刷卡時間).FirstOrDefault();
                //                    if (mealCardTypeOld != null)
                //                    {
                //                        JBModule.Message.DbLog.WriteLog("Update", mealCardType, this.Name, mealCardType.AutoKey);
                //                        mealCardTypeOld = mealCardType;
                //                    }
                //                    else
                //                    {
                //                        JBModule.Message.DbLog.WriteLog("Insert", mealCardType, this.Name, mealCardType.AutoKey);
                //                        db.MealCardType.InsertOnSubmit(mealCardType);
                //                    }
                //                    //db.SubmitChanges();
                //                }
                //            }
                //        }
                //        db.SubmitChanges();

                //        var DelMealDeductions = db.MealDeduction.Where(p => p.NOBR == nobr && p.ADATE >= d1 && p.ADATE <= d2);
                //        db.MealDeduction.DeleteAllOnSubmit(DelMealDeductions);
                //        db.SubmitChanges();

                //        var eatSQL = (from mct in db.MealCardType
                //                      where mct.ADATE.Date.CompareTo(d1) >= 0 && mct.ADATE.Date.CompareTo(d2) <= 0
                //                     && item.Contains(mct.NOBR)
                //                      orderby mct.NOBR, mct.ADATE
                //                      select new { 員工編號 = mct.NOBR, 用餐日期 = mct.ADATE, 用餐時間 = mct.BTIME, 用餐群組 = mct.MealGroup, 用餐餐別 = mct.MealType }).ToList();

                //        var applyRecords = applySQL.Where(p => p.員工編號 == nobr);
                //        var eatRecords = db.MealCardType.Where(p => p.NOBR == nobr && p.ADATE.Date.CompareTo(d1) >= 0 && p.ADATE.Date.CompareTo(d2) <= 0)
                //                            .Select(p=> new { 員工編號 = p.NOBR, 用餐日期 = p.ADATE, 用餐時間 = p.BTIME, 用餐群組 = p.MealGroup, 用餐餐別 = p.MealType }).ToList();
                //        var attendRecords = attendSQL.Where(p => p.員工編號 == nobr)
                //            .Select(p => new { p.刷卡日期, 起時 = p.刷起時間.CompareTo(p.上班時間) < 0 ? p.上班時間 : p.刷起時間, 迄時 = p.刷迄時間.CompareTo(p.下班時間) > 0 ? p.下班時間 : p.刷迄時間 });
                //        var otRecords = otSQL.Where(p => p.員工編號 == nobr);
                //        for (DateTime dd = d1; dd <= d2; dd = dd.AddDays(1))
                //        {
                //            if (applyRecords.Where(p => p.申請日期 == dd).Any() || eatRecords.Where(p => p.用餐日期 == dd).Any())
                //            {
                //                List<MealDeduction> mealDeductionList = new List<MealDeduction>();
                //                foreach (var apply in applyRecords.Where(p => p.申請日期 == dd))
                //                {
                //                    MealDeduction mealDeduction = new MealDeduction();
                //                    mealDeduction.NOBR = nobr;
                //                    mealDeduction.ADATE = dd;
                //                    mealDeduction.MealGroup = nobrmealgroup;
                //                    mealDeduction.MealType = apply.申請餐別;
                //                    mealDeduction.Apply = true;
                //                    mealDeduction.Attend = false;
                //                    mealDeduction.OT = false;
                //                    mealDeduction.Eat = false;
                //                    mealDeduction.YYMM = yymm;
                //                    mealDeduction.AMT = 0;
                //                    mealDeduction.SERO = Guid.NewGuid().ToString();
                //                    mealDeduction.KEY_MAN = MainForm.USER_NAME;
                //                    mealDeduction.KEY_DATE = DateTime.Now;
                //                    mealDeductionList.Add(mealDeduction);
                //                }
                //                foreach (var eat in eatRecords.Where(p => p.用餐日期 == dd))
                //                {
                //                    MealDeduction mealDeductionOld = mealDeductionList.Where(p => p.MealType == eat.用餐餐別).FirstOrDefault();
                //                    if (mealDeductionOld != null)
                //                        mealDeductionOld.Eat = true;
                //                    else
                //                    {
                //                        MealDeduction mealDeduction = new MealDeduction();
                //                        mealDeduction.NOBR = nobr;
                //                        mealDeduction.ADATE = dd;
                //                        mealDeduction.MealGroup = nobrmealgroup;
                //                        mealDeduction.MealType = eat.用餐餐別;
                //                        mealDeduction.Apply = false;
                //                        mealDeduction.Attend = false;
                //                        mealDeduction.OT = false;
                //                        mealDeduction.Eat = true;
                //                        mealDeduction.YYMM = yymm;
                //                        mealDeduction.AMT = 0;
                //                        mealDeduction.SERO = Guid.NewGuid().ToString();
                //                        mealDeduction.KEY_MAN = MainForm.USER_NAME;
                //                        mealDeduction.KEY_DATE = DateTime.Now;
                //                        mealDeductionList.Add(mealDeduction);
                //                    }
                //                }
                //                foreach (var mealDeduction in mealDeductionList)
                //                {
                //                    var MealType = MealTypes.Where(p => p.MealGroup == mealDeduction.MealGroup && p.MealType_Code == mealDeduction.MealType).FirstOrDefault();
                //                    if (MealType != null)
                //                    {
                //                        string BTime = string.IsNullOrEmpty(MealType.CBTIME) ? MealType.BTime : MealType.CBTIME;
                //                        string ETime = string.IsNullOrEmpty(MealType.CETIME) ? MealType.ETime : MealType.CETIME;
                //                        mealDeduction.Attend = attendRecords.Where(p => p.刷卡日期 == dd && p.起時.CompareTo(ETime) <= 0 && p.迄時.CompareTo(BTime) >= 0).Any();
                //                        mealDeduction.OT = otRecords.Where(p => p.加班日期 == dd && p.加起時間.CompareTo(ETime) <= 0 && p.加迄時間.CompareTo(BTime) >= 0).Any();
                //                        var MealCaseSetting = MealCaseSettings.Where(p => p.MealGroup == mealDeduction.MealGroup && p.MealType == mealDeduction.MealType
                //                                                && p.Attend == mealDeduction.Attend && p.Apply == mealDeduction.Apply && p.OT == mealDeduction.OT && p.Eat == mealDeduction.Eat).FirstOrDefault();
                //                        mealDeduction.AMT = MealCaseSetting != null ? MealCaseSetting.AMT : 0; 
                //                    }
                //                    db.MealDeduction.InsertOnSubmit(mealDeduction);
                //                }
                //            }
                //        }
                //        db.SubmitChanges();
                //        count++;
                //    } 
                //}
                sw.Stop();
                BW.ReportProgress(100, Resources.Sal.StatusFinish);
                msg = string.Format("{0}.", sw.Message);
                e.Result = msg;
            }
            catch (Exception ex)
            {
                BW.ReportProgress(100, "錯誤.");
                msg = ex.Message;
                e.Result = msg;
            }
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result.ToString().Trim().Length > 0)
                MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Enabled = true;
            //this.DialogResult = DialogResult.OK;
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
            tSSLabelProcess.Text = e.UserState.ToString();
        }

        private void dtpBDate_CloseUp(object sender, EventArgs e)
        {
            dtpEDate.Value = dtpBDate.Value.AddMonths(1).AddDays(-1);
            Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(dtpEDate.Value);
            txtYYMM.Text = sd.YYMM;
            SetEmpList();
        }

        private void dtpEDate_CloseUp(object sender, EventArgs e)
        {
            if (dtpBDate.Value > dtpEDate.Value)
                dtpBDate.Value = dtpEDate.Value;
            SetEmpList();
        }
    }
}
