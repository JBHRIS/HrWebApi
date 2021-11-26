using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using JBModule.Data.Linq;
using JBTools.Extend;

namespace JBModule.Data
{
    public class MealCardGenerator
    {
        public string KeyMan = "JB";
        List<string> _EmployeeList;
        DateTime _DateBegin, _DateEnd;
        string _YYMM = string.Empty;
        List<string> holi_codeList = new List<string>() { "00", "0X", "0Z" };
        public MealCardGenerator(List<string> EmployeeList, DateTime DateBegin, DateTime DateEnd, string YYMM)
        {
            _EmployeeList = EmployeeList;
            _DateBegin = DateBegin;
            _DateEnd = DateEnd;
            _YYMM = YYMM;
        }
        public MealCardGenerator(string EmployeeID, DateTime DateBegin, DateTime DateEnd, string YYMM)
        {
            _EmployeeList = new List<string>();
            _EmployeeList.Add(EmployeeID);
            _DateBegin = DateBegin;
            _DateEnd = DateEnd;
            _YYMM = YYMM;
        }


        public void Generate()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                var MealTypes = db.MealType.ToList();
                var MealCaseSettings = db.MealCaseSetting.ToList();
                var attdayList = db.U_SYS2.ToList();

                var basettsList = (from a in db.BASETTS
                                   where a.ADATE.Date.CompareTo(_DateEnd) <= 0 && a.DDATE.Value.CompareTo(_DateBegin) >= 0
                                   && _EmployeeList.Contains(a.NOBR)
                                   select a).ToList();

                var FoodCardSql = (from fc in db.FOOD_CARD
                                   where fc.ADATE.Date.CompareTo(_DateBegin) >= 0 && fc.ADATE.Date.CompareTo(_DateEnd.AddDays(1)) <= 0
                                   && _EmployeeList.Contains(fc.NOBR)
                                   orderby fc.NOBR, fc.ADATE, fc.ONTIME
                                   select new { 員工編號 = fc.NOBR, 刷卡日期 = fc.ADATE, 刷卡時間 = fc.ONTIME, 不轉換 = fc.NOT_TRAN }).ToList();
                var groupSQL = (from row in FoodCardSql group row by row.員工編號 into g1 select g1).ToList();

                var applySQL = (from ma in db.MEALAPPLYRECORD
                                where ma.ADATE.Date.CompareTo(_DateBegin) >= 0 && ma.ADATE.Date.CompareTo(_DateEnd) <= 0
                                && _EmployeeList.Contains(ma.NOBR)
                                orderby ma.NOBR, ma.ADATE
                                select new { 員工編號 = ma.NOBR, 申請日期 = ma.ADATE, 用餐群組 = ma.MealGroup, 申請餐別 = ma.MealType }).ToList();
                var attendSQL = (from ac in db.ATTCARD
                                 join a in db.ATTEND on new { ac.NOBR, ac.ADATE } equals new { a.NOBR, a.ADATE }
                                 join r in db.ROTE on a.ROTE equals r.ROTE1
                                 where ac.ADATE.CompareTo(_DateBegin) >= 0 && ac.ADATE.CompareTo(_DateEnd) <= 0
                                 && _EmployeeList.Contains(ac.NOBR)
                                 select new { 員工編號 = ac.NOBR, 刷卡日期 = ac.ADATE, 刷起時間 = ac.T1, 刷迄時間 = ac.T2, 上班時間 = r.ON_TIME, 下班時間 = r.OFF_TIME }).ToList();
                var otSQL = (from o in db.OT
                             where o.BDATE.Date.CompareTo(_DateBegin) >= 0 && o.BDATE.Date.CompareTo(_DateEnd) <= 0
                             && _EmployeeList.Contains(o.NOBR)
                             orderby o.NOBR, o.BDATE
                             select new { 員工編號 = o.NOBR, 加班日期 = o.BDATE, 加起時間 = o.BTIME, 加迄時間 = o.ETIME }).ToList();

                var mealcardtypeSQL = (from mct in db.MealCardType
                                       where mct.ADATE.CompareTo(_DateBegin) >= 0 && mct.ADATE.CompareTo(_DateEnd) <= 0
                                       && _EmployeeList.Contains(mct.NOBR)
                                       select mct).ToList();

                var MealGroupList = db.GetUserDefineValueList("MealGroup").ToList();

                //BW.ReportProgress(0, "正在刪除資料...");
                var deleteSql = (from mct in db.MealCardType
                                 where mct.ADATE.Date.CompareTo(_DateBegin) >= 0 && mct.ADATE.Date.CompareTo(_DateEnd) <= 0
                                 && _EmployeeList.Contains(mct.NOBR)
                                 && !mct.NoTrans
                                 select mct).ToList();
                db.MealCardType.DeleteAllOnSubmit(deleteSql);
                //db.SubmitChanges();
                var DelMealDeductions = (from dmd in db.MealDeduction
                                         where dmd.ADATE.Date.CompareTo(_DateBegin) >= 0 && dmd.ADATE.Date.CompareTo(_DateEnd) <= 0
                                         && _EmployeeList.Contains(dmd.NOBR)
                                         select dmd).ToList();
                db.MealDeduction.DeleteAllOnSubmit(DelMealDeductions);
                db.SubmitChanges();

                int total = groupSQL.Count();
                int count = 0;
                foreach (var Nobr in groupSQL)
                {
                    string nobr = Nobr.Key;
                    var mealgroup = MealGroupList.Where(p => p.Code == Nobr.Key).FirstOrDefault();
                    string nobrmealgroup = mealgroup != null ? mealgroup.Value : string.Empty;
                    var FoodCardbyNobr = FoodCardSql.Where(p => p.員工編號 == nobr);
                    var NobrMealTypes = db.MealType.Where(p => p.MealGroup == nobrmealgroup).ToList();
                    //BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 100), "正在转换" + nobr + "刷卡餐别");
                    foreach (var FC in FoodCardbyNobr)
                    {
                        if (!FC.不轉換)
                        {
                            MealCardType mealCardType = new MealCardType();
                            mealCardType.NOBR = FC.員工編號;
                            mealCardType.ADATE = FC.刷卡日期;
                            mealCardType.BTIME_Source = FC.刷卡時間;
                            mealCardType.NoTrans = false;
                            mealCardType.Lost = false;
                            mealCardType.SeroNo = Guid.NewGuid().ToString();
                            mealCardType.KEY_MAN = KeyMan;
                            mealCardType.KEY_DATE = DateTime.Now;
                            mealCardType.BTIME = string.Empty;
                            mealCardType.MealType = string.Empty;

                            if (!string.IsNullOrWhiteSpace(nobrmealgroup))
                            {
                                mealCardType.MealGroup = nobrmealgroup;
                                foreach (var MT in NobrMealTypes)
                                {
                                    int intBT = Convert.ToInt32(MT.BTime);
                                    int intET = Convert.ToInt32(MT.ETime);
                                    int intTime = Convert.ToInt32(FC.刷卡時間);
                                    int intPreTime = intTime + 2400;
                                    if (intTime >= intBT && intTime <= intET)
                                    {
                                        mealCardType.ADATE = FC.刷卡日期;
                                        mealCardType.BTIME = intTime.ToString("0000");
                                        mealCardType.MealType = MT.MealType_Code;
                                        break;
                                    }
                                    else if (intBT >= 2400 && intPreTime >= intBT && intPreTime <= intET)
                                    {
                                        mealCardType.ADATE = FC.刷卡日期.AddDays(-1);
                                        mealCardType.BTIME = intPreTime.ToString("0000");
                                        mealCardType.MealType = MT.MealType_Code;
                                        break;
                                    }
                                    else if (intET >= 2400)
                                    {
                                        if (intTime >= intBT)
                                        {
                                            mealCardType.ADATE = FC.刷卡日期;
                                            mealCardType.BTIME = intTime.ToString("0000");
                                            mealCardType.MealType = MT.MealType_Code;
                                            break;
                                        }
                                        else if (intPreTime <= intET)
                                        {
                                            mealCardType.ADATE = FC.刷卡日期.AddDays(-1);
                                            mealCardType.BTIME = intPreTime.ToString("0000");
                                            mealCardType.MealType = MT.MealType_Code;
                                            break;
                                        }
                                    }
                                }
                            }
                            //if (mealCardType.ADATE >= _DateBegin && mealCardType.ADATE <= _DateEnd)
                            //{
                            //    MealCardType mealCardTypeOld = mealcardtypeSQL.Where(p => p.NOBR == FC.員工編號
                            //                                     && p.ADATE == FC.刷卡日期 && p.BTIME == FC.刷卡時間).FirstOrDefault();
                            //    if (mealCardTypeOld != null)
                            //        mealCardTypeOld = mealCardType;
                            //    else
                            db.MealCardType.InsertOnSubmit(mealCardType);
                            //db.SubmitChanges();
                            //}
                        }
                    }
                    db.SubmitChanges();

                    var eatSQL = (from mct in db.MealCardType
                                  where mct.ADATE.Date.CompareTo(_DateBegin) >= 0 && mct.ADATE.Date.CompareTo(_DateEnd) <= 0
                                  && _EmployeeList.Contains(mct.NOBR)
                                  orderby mct.NOBR, mct.ADATE
                                  select new { 員工編號 = mct.NOBR, 用餐日期 = mct.ADATE, 用餐時間 = mct.BTIME, 用餐群組 = mct.MealGroup, 用餐餐別 = mct.MealType }).ToList();

                    var applyRecords = applySQL.Where(p => p.員工編號 == nobr);
                    var eatRecords = db.MealCardType.Where(p => p.NOBR == nobr && p.ADATE.Date.CompareTo(_DateBegin) >= 0 && p.ADATE.Date.CompareTo(_DateEnd) <= 0)
                                        .Select(p => new { 員工編號 = p.NOBR, 用餐日期 = p.ADATE, 用餐時間 = p.BTIME, 用餐群組 = p.MealGroup, 用餐餐別 = p.MealType }).ToList();
                    var attendRecords = attendSQL.Where(p => p.員工編號 == nobr)
                        .Select(p => new { p.刷卡日期, 起時 = p.刷起時間.CompareTo(p.上班時間) < 0 ? p.上班時間 : p.刷起時間, 迄時 = p.刷迄時間.CompareTo(p.下班時間) > 0 ? p.下班時間 : p.刷迄時間 });
                    var otRecords = otSQL.Where(p => p.員工編號 == nobr);
                    for (DateTime dd = _DateBegin; dd <= _DateEnd; dd = dd.AddDays(1))
                    {
                        if (applyRecords.Where(p => p.申請日期 == dd).Any() || eatRecords.Where(p => p.用餐日期 == dd).Any())
                        {
                            var AttEndDaySQL = (from a in attdayList
                                                join b in basettsList on a.Comp equals b.COMP
                                                where b.NOBR == nobr && b.ADATE <= dd && b.DDATE >= dd
                                                select a).FirstOrDefault();
                            int AttEndDay = AttEndDaySQL != null ? AttEndDaySQL.ATTMONTH.Value : 31;
                            string yymm = string.Format("{0}{1}", dd.Year.ToString("0000"), dd.Month.ToString("00"));
                            if (dd.Day > AttEndDay)
                                yymm = string.Format("{0}{1}", dd.AddMonths(1).Year.ToString("0000"), dd.AddMonths(1).Month.ToString("00"));
                            if (_YYMM != string.Empty) yymm = _YYMM;
                            List<MealDeduction> mealDeductionList = new List<MealDeduction>();
                            foreach (var apply in applyRecords.Where(p => p.申請日期 == dd))
                            {
                                MealDeduction mealDeduction = new MealDeduction();
                                mealDeduction.NOBR = nobr;
                                mealDeduction.ADATE = dd;
                                mealDeduction.MealGroup = nobrmealgroup;
                                mealDeduction.MealType = apply.申請餐別;
                                mealDeduction.Apply = true;
                                mealDeduction.Attend = false;
                                mealDeduction.OT = false;
                                mealDeduction.Eat = false;
                                mealDeduction.YYMM = yymm;
                                mealDeduction.AMT = 0;
                                mealDeduction.SERO = Guid.NewGuid().ToString();
                                mealDeduction.KEY_MAN = KeyMan;
                                mealDeduction.KEY_DATE = DateTime.Now;
                                mealDeductionList.Add(mealDeduction);
                            }
                            foreach (var eat in eatRecords.Where(p => p.用餐日期 == dd))
                            {
                                MealDeduction mealDeductionOld = mealDeductionList.Where(p => p.MealType == eat.用餐餐別).FirstOrDefault();
                                if (mealDeductionOld != null)
                                    mealDeductionOld.Eat = true;
                                else
                                {
                                    MealDeduction mealDeduction = new MealDeduction();
                                    mealDeduction.NOBR = nobr;
                                    mealDeduction.ADATE = dd;
                                    mealDeduction.MealGroup = nobrmealgroup;
                                    mealDeduction.MealType = eat.用餐餐別;
                                    mealDeduction.Apply = false;
                                    mealDeduction.Attend = false;
                                    mealDeduction.OT = false;
                                    mealDeduction.Eat = true;
                                    mealDeduction.YYMM = yymm;
                                    mealDeduction.AMT = 0;
                                    mealDeduction.SERO = Guid.NewGuid().ToString();
                                    mealDeduction.KEY_MAN = KeyMan;
                                    mealDeduction.KEY_DATE = DateTime.Now;
                                    mealDeductionList.Add(mealDeduction);
                                }
                            }
                            foreach (var mealDeduction in mealDeductionList)
                            {
                                var MealType = MealTypes.Where(p => p.MealGroup == mealDeduction.MealGroup && p.MealType_Code == mealDeduction.MealType).FirstOrDefault();
                                if (MealType != null)
                                {
                                    string BTime = string.IsNullOrEmpty(MealType.CBTIME) ? MealType.BTime : MealType.CBTIME;
                                    string ETime = string.IsNullOrEmpty(MealType.CETIME) ? MealType.ETime : MealType.CETIME;
                                    mealDeduction.Attend = attendRecords.Where(p => p.刷卡日期 == dd && p.起時.CompareTo(ETime) <= 0 && p.迄時.CompareTo(BTime) >= 0).Any();
                                    mealDeduction.OT = otRecords.Where(p => p.加班日期 == dd && p.加起時間.CompareTo(ETime) <= 0 && p.加迄時間.CompareTo(BTime) >= 0).Any();
                                    var MealCaseSetting = MealCaseSettings.Where(p => p.MealGroup == mealDeduction.MealGroup && p.MealType == mealDeduction.MealType
                                                            && p.Attend == mealDeduction.Attend && p.Apply == mealDeduction.Apply && p.OT == mealDeduction.OT && p.Eat == mealDeduction.Eat).FirstOrDefault();
                                    mealDeduction.AMT = MealCaseSetting != null ? MealCaseSetting.AMT : 0;
                                }
                                db.MealDeduction.InsertOnSubmit(mealDeduction);
                            }
                        }
                    }
                    db.SubmitChanges();
                    count++;
                }
            }
            catch (Exception ex)
            {
                //BW.ReportProgress(100, "错误.");
                JBModule.Message.DbLog.WriteLog(ex.Message, _EmployeeList, KeyMan, -1);
            }
        }
    }
}

