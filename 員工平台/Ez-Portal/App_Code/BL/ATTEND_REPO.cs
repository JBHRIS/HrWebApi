using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JBHRModel;
using System.Web.Caching;
using System.Data.Linq;
using System.Text;

namespace BL
{
    /// <summary>
    /// DEPTA 的摘要描述
    /// </summary>
    public class ATTEND_REPO
    {
        private static readonly Object syncObj = new Object();
        public JBHRModelDataContext dc { get; set; }
        public ATTEND_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public ATTEND_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<ATTEND> GetAll()
        {
            List<ATTEND> list = new List<ATTEND>();
            return (from c in dc.ATTEND           
                    select c).ToList();            
        }


        public List<ATTEND> GetByDateRange_DLO(DateTime bDateTime, DateTime eDatetime)
        {
            using (JBHRModelDataContext loc = new JBHRModelDataContext())
            {
                // var a = o.ATTEND.Include("BASE").Include(
                DateTime datetime = DateTime.Now.Date;

                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ATTEND>(l => l.BASE);
                dlo.LoadWith<ATTEND>(l => l.ATTCARD);
                dlo.LoadWith<ATTEND>(l => l.ROTE1);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);                
                dlo.LoadWith<BASETTS>(l => l.HOLICD);

                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t=>t.ADATE <= datetime && t.DDATE >= datetime));
                loc.LoadOptions = dlo;

                return (from c in loc.ATTEND where c.ADATE >= bDateTime && c.ADATE <= eDatetime
                   //     && c.BASETTS.ADATE <= eDatetime && c.BASETTS.DDATE >=eDatetime
                            select c).ToList();
            }
        }


        public List<ATTEND> GetByDateRangeDept_DLO(string deptCode,DateTime bDateTime, DateTime eDatetime)
        {
            using (JBHRModelDataContext loc = new JBHRModelDataContext())
            {
                loc.Log = new DebuggerWriter();
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ATTEND>(l => l.BASE);
                dlo.LoadWith<ATTEND>(l => l.ATTCARD);
                dlo.LoadWith<ATTEND>(l => l.ROTE1);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.HOLICD);

                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                loc.LoadOptions = dlo;

                return (from c in loc.ATTEND
                        where c.ADATE >= bDateTime && c.ADATE <= eDatetime
                        &&
                        ( 
                        c.BASE.BASETTS.Where(t=>t.DEPT == deptCode).Any()
                        && c.BASE.BASETTS.Where(t=>t.ADATE <= datetime && t.DDATE >=datetime).Any()
                        )
                        select c).ToList();               
            }
        }

        public List<ATTEND> GetByDateRangeNobr_DLO(string Anobr, DateTime bDateTime, DateTime eDatetime)
        {
            using (JBHRModelDataContext loc = new JBHRModelDataContext())
            {
                loc.Log = new DebuggerWriter();
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ATTEND>(l => l.BASE);
                dlo.LoadWith<ATTEND>(l => l.ATTCARD);
                dlo.LoadWith<ATTEND>(l => l.ROTE1);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.HOLICD);

                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                loc.LoadOptions = dlo;

                return (from c in loc.ATTEND
                        where c.ADATE >= bDateTime && c.ADATE <= eDatetime
                        &&
                        (
                        c.BASE.BASETTS.Where(t => t.NOBR==Anobr).Any()
                        && c.BASE.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime).Any()
                        )
                        select c).ToList();
            }
        }

        public List<ATTEND> GetByNobrDateRangeOtMoreThen_Dlo(string nobr, DateTime bDate, DateTime eDate, int moreThenMins)
        {
            using (JBHRModelDataContext loc = new JBHRModelDataContext())
            {
                loc.Log = new DebuggerWriter();
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ATTEND>(l => l.BASE);
                //dlo.LoadWith<ATTEND>(l => l.ATTCARD);
                //dlo.LoadWith<ATTEND>(l => l.ROTE1);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                //dlo.LoadWith<BASETTS>(l => l.HOLICD);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                loc.LoadOptions = dlo;

                return (from c in loc.ATTEND
                        where c.ADATE >= bDate && c.ADATE <= eDate
                        && c.BASE.BASETTS.Any()
                        && c.NOBR ==nobr
                        && (
                        (c.EARLY_MINS.HasValue && c.EARLY_MINS.Value >= moreThenMins)
                        || (c.DELAY_MINS.HasValue && c.DELAY_MINS.Value >= moreThenMins)
                        )
                        select c).ToList();
            }
        }


        public List<ATTEND> GetByDeptDateRangeOtMoreThen_Dlo(string deptCode, DateTime bDate, DateTime eDate, int moreThenMins)
        {
            using (JBHRModelDataContext loc = new JBHRModelDataContext())
            {
                loc.Log = new DebuggerWriter();
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ATTEND>(l => l.BASE);
                //dlo.LoadWith<ATTEND>(l => l.ATTCARD);
                //dlo.LoadWith<ATTEND>(l => l.ROTE1);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                //dlo.LoadWith<BASETTS>(l => l.HOLICD);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                loc.LoadOptions = dlo;

                return (from c in loc.ATTEND
                        where c.ADATE >= bDate && c.ADATE <= eDate
                        &&  c.BASE.BASETTS.Any()
                        &&  c.BASE.BASETTS.Where(p => p.DEPT == deptCode).Any()
                        && (
                        (c.EARLY_MINS.HasValue && c.EARLY_MINS.Value >=moreThenMins)
                        || (c.DELAY_MINS.HasValue && c.DELAY_MINS.Value >= moreThenMins)
                        )
                        select c).ToList();
            }
        }


        public List<ATTEND> GetByDateRange(DateTime bDateTime, DateTime eDatetime)
        {
            using (JBHRModelDataContext o = new JBHRModelDataContext())
            {
                // var a = o.ATTEND.Include("BASE").Include(
                return o.ATTEND.Where(a => a.ADATE >= bDateTime && a.ADATE <= eDatetime).ToList();
            }
        }


        public List<EmpAttendList> GetAttendListByDateRange(DateTime bDateTime, DateTime eDatetime)
        {
            List<ATTEND> attendList = GetByDateRange_DLO(bDateTime, eDatetime);
            List<EmpAttendList> list = new List<EmpAttendList>();

            ABS_REPO absRepo = new ABS_REPO();
            ABS1_REPO abs1Repo = new ABS1_REPO();
            List<ABS> absList = absRepo.GetByDateRange_Dlo(bDateTime, eDatetime,new string[]{"0","2","4","6"});
            List<ABS1> abs1List = abs1Repo.GetByDateRange_Dlo(bDateTime, eDatetime, new string[] { "0", "2", "4", "6" });

            StringBuilder sb = new StringBuilder();

            foreach (var a in attendList)
            {
                sb.Clear();
                EmpAttendList empAttend = new EmpAttendList();
                empAttend.AttendDate = a.ADATE;
                //empAttend.Calendar = a.BASETTS.HOLICD.HOLI_NAME;
                empAttend.Calendar = a.BASE.BASETTS[0].HOLICD.HOLI_NAME ?? "";                                   
                empAttend.DayOfWeek = a.ADATE.DayOfWeek.ToString();
                empAttend.DeptName = a.BASE.BASETTS[0].DEPT1.D_NAME;                
                empAttend.Nobr = a.NOBR;
                empAttend.NameC = a.BASE.BASETTS[0].BASE.NAME_C;
                empAttend.Shift = a.ROTE;
                empAttend.StartWorkingTime = a.ATTCARD == null ? "" : a.ATTCARD.T1;
                empAttend.EndWorkingTime = a.ATTCARD == null ? "" : a.ATTCARD.T2;
                empAttend.IsAbsent = a.ABS;
                empAttend.IsLate = a.LATE_MINS > 0 ? true : false;
                empAttend.LateMins = Convert.ToInt32(a.LATE_MINS);
                empAttend.IsLeaveEarly = a.E_MINS > 0 ? true : false;
                empAttend.LeaveEarlyMins = Convert.ToInt32(a.E_MINS);
                empAttend.RealWorkHours = CalcRealWorkHrs(empAttend.StartWorkingTime , empAttend.EndWorkingTime , a.ROTE1.RES_B_TIME , a.ROTE1.RES_E_TIME);

                List<ABS> aList = absList.FindAll(p => p.NOBR == a.NOBR && p.BDATE == a.ADATE);
                foreach (var i in aList)
                {
                    sb.Append(i.BTIME);
                    sb.Append("-");
                    sb.Append(i.ETIME);
                    sb.Append(i.HCODE.H_NAME);
                    sb.Append("、");
                }

                List<ABS1> a1List = abs1List.FindAll(p => p.NOBR == a.NOBR && p.BDATE == a.ADATE);
                foreach (var i in a1List)
                {
                    sb.Append(i.BTIME);
                    sb.Append("-");
                    sb.Append(i.ETIME);
                    sb.Append(i.HCODE.H_NAME);
                    sb.Append("、");
                }

                empAttend.TakeLeaveNote = sb.ToString();

                if (a.ATTCARD != null)
                {
                    if (a.ATTCARD.LOST1 || a.ATTCARD.LOST2)
                    {
                        empAttend.IsLostCard = true;
                        if (a.ATTCARD.LOST1 && a.ATTCARD.LOST2)
                            empAttend.LostCardTimes = 2;
                        else if (!(a.ATTCARD.LOST1 || a.ATTCARD.LOST2))
                        {
                            empAttend.LostCardTimes = 0;
                        }
                        else
                            empAttend.LostCardTimes = 1;
                    }
                }

                list.Add(empAttend);
            }

            return list;
        }


        public List<EmpAttendList> GetAttendListByDateRangeDept(string deptCode,DateTime bDateTime, DateTime eDatetime)
        {
            List<ATTEND> attendList = GetByDateRangeDept_DLO(deptCode,bDateTime, eDatetime);
            List<EmpAttendList> list = new List<EmpAttendList>();

            ABS_REPO absRepo = new ABS_REPO();
            ABS1_REPO abs1Repo = new ABS1_REPO();
            List<ABS> absList = absRepo.GetByDeptDateRange_Dlo(deptCode,bDateTime, eDatetime, new string[] { "0", "2", "4", "6" });
            List<ABS1> abs1List = abs1Repo.GetByDeptDateRange_Dlo(deptCode, bDateTime, eDatetime, new string[] { "0", "2", "4", "6" });

            StringBuilder sb = new StringBuilder();

            foreach (var a in attendList)
            {
                sb.Clear();
                EmpAttendList empAttend = new EmpAttendList();
                empAttend.AttendDate = a.ADATE;
                //empAttend.Calendar = a.BASETTS.HOLICD.HOLI_NAME;
                empAttend.Calendar = a.BASE.BASETTS[0].HOLICD.HOLI_NAME ?? "";
                //empAttend.DayOfWeek = a.ADATE.DayOfWeek.ToString();
                empAttend.DayOfWeek = SiteHelper.ConvertDayOfWeek2Chinese(a.ADATE.DayOfWeek);
                empAttend.DeptName = a.BASE.BASETTS[0].DEPT1.D_NAME;
                empAttend.Nobr = a.NOBR;
                empAttend.NameC = a.BASE.BASETTS[0].BASE.NAME_C;
                empAttend.Shift = a.ROTE;
                empAttend.ShiftName = a.ROTE1.ROTENAME;
                empAttend.StartWorkingTime = a.ATTCARD == null ? "" : a.ATTCARD.T1;
                empAttend.EndWorkingTime = a.ATTCARD == null ? "" : a.ATTCARD.T2;
                empAttend.IsLate = a.LATE_MINS > 0 ? true : false;
                empAttend.IsAbsent = a.ABS;
                empAttend.LateMins = Convert.ToInt32(a.LATE_MINS);
                empAttend.IsLeaveEarly = a.E_MINS > 0 ? true : false;
                empAttend.LeaveEarlyMins = Convert.ToInt32(a.E_MINS);

                empAttend.RealWorkHours = CalcRealWorkHrs(empAttend.StartWorkingTime, empAttend.EndWorkingTime, a.ROTE1.RES_B_TIME, a.ROTE1.RES_E_TIME);

                List<ABS> aList = absList.FindAll(p => p.NOBR == a.NOBR && p.BDATE == a.ADATE);
                foreach (var i in aList)
                {
                    sb.Append(i.BTIME);
                    sb.Append("-");
                    sb.Append(i.ETIME);
                    sb.Append(i.HCODE.H_NAME);
                    sb.Append("、");
                }

                List<ABS1> a1List = abs1List.FindAll(p => p.NOBR == a.NOBR && p.BDATE == a.ADATE);
                foreach (var i in a1List)
                {
                    sb.Append(i.BTIME);
                    sb.Append("-");
                    sb.Append(i.ETIME);
                    sb.Append(i.HCODE.H_NAME);
                    sb.Append("、");
                }

                empAttend.TakeLeaveNote = sb.ToString();

                if (a.ATTCARD != null)
                {
                    if (a.ATTCARD.LOST1 || a.ATTCARD.LOST2)
                    {
                        empAttend.IsLostCard = true;
                        if (a.ATTCARD.LOST1 && a.ATTCARD.LOST2)
                            empAttend.LostCardTimes = 2;
                        else if (!(a.ATTCARD.LOST1 || a.ATTCARD.LOST2))
                        {
                            empAttend.LostCardTimes = 0;
                        }
                        else
                            empAttend.LostCardTimes = 1;
                    }
                }

                list.Add(empAttend);
            }

            return list;
        }

        public List<EmpAttendList> GetAttendListByDateRangeNobr(string Anobr, DateTime bDateTime, DateTime eDatetime)
        {
            List<ATTEND> attendList = GetByDateRangeNobr_DLO(Anobr, bDateTime, eDatetime);
            List<EmpAttendList> list = new List<EmpAttendList>();

            ABS_REPO absRepo = new ABS_REPO();
            ABS1_REPO abs1Repo = new ABS1_REPO();
            List<ABS> absList = absRepo.GetByNobrDateRange_Dlo(Anobr, bDateTime, eDatetime, new string[] { "0", "2", "4", "6" });
            List<ABS1> abs1List = abs1Repo.GetByNobrDateRange_Dlo(Anobr, bDateTime, eDatetime, new string[] { "0", "2", "4", "6" });

            StringBuilder sb = new StringBuilder();

            foreach (var a in attendList)
            {
                sb.Clear();
                EmpAttendList empAttend = new EmpAttendList();
                empAttend.AttendDate = a.ADATE;
                empAttend.Calendar = a.BASE.BASETTS[0].HOLICD.HOLI_NAME ?? "";
                empAttend.DayOfWeek = SiteHelper.ConvertDayOfWeek2Chinese(a.ADATE.DayOfWeek);
                empAttend.DeptName = a.BASE.BASETTS[0].DEPT1.D_NAME;
                empAttend.Nobr = a.NOBR;
                empAttend.NameC = a.BASE.BASETTS[0].BASE.NAME_C;
                empAttend.Shift = a.ROTE;
                empAttend.ShiftName = a.ROTE1.ROTENAME;
                empAttend.StartWorkingTime = a.ATTCARD == null ? "" : a.ATTCARD.T1;
                empAttend.EndWorkingTime = a.ATTCARD == null ? "" : a.ATTCARD.T2;
                empAttend.IsLate = a.LATE_MINS > 0 ? true : false;
                empAttend.IsAbsent = a.ABS;
                empAttend.LateMins = Convert.ToInt32(a.LATE_MINS);
                empAttend.IsLeaveEarly = a.E_MINS > 0 ? true : false;
                empAttend.LeaveEarlyMins = Convert.ToInt32(a.E_MINS);
                empAttend.RealWorkHours = CalcRealWorkHrs(empAttend.StartWorkingTime, empAttend.EndWorkingTime, a.ROTE1.RES_B_TIME, a.ROTE1.RES_E_TIME);

                //請假
                List<ABS> aList = absList.FindAll(p => p.NOBR == a.NOBR && p.BDATE == a.ADATE);
                foreach (var i in aList)
                {
                    sb.Append(i.BTIME);
                    sb.Append("-");
                    sb.Append(i.ETIME);
                    sb.Append(i.HCODE.H_NAME);
                    sb.Append("、");
                }

                List<ABS1> a1List = abs1List.FindAll(p => p.NOBR == a.NOBR && p.BDATE == a.ADATE);
                foreach (var i in a1List)
                {
                    sb.Append(i.BTIME);
                    sb.Append("-");
                    sb.Append(i.ETIME);
                    sb.Append(i.HCODE.H_NAME);
                    sb.Append("、");
                }

                empAttend.TakeLeaveNote = sb.ToString();

                //忘刷卡
                if (a.ATTCARD != null)
                {
                    if (a.ATTCARD.LOST1 || a.ATTCARD.LOST2)
                    {
                        empAttend.IsLostCard = true;
                        if (a.ATTCARD.LOST1 && a.ATTCARD.LOST2)
                            empAttend.LostCardTimes = 2;
                        else if (!(a.ATTCARD.LOST1 || a.ATTCARD.LOST2))
                        {
                            empAttend.LostCardTimes = 0;
                        }
                        else
                            empAttend.LostCardTimes = 1;
                    }
                }

                list.Add(empAttend);
            }

            return list;
        }


        public double CalcRealWorkHrs(string T1, string T2, string resT1, string resT2)
        {
            int mins = SiteHelper.ConvertStrTimeToMins(T2) - SiteHelper.ConvertStrTimeToMins(T1);
            TimeSpan ts = new TimeSpan(0, mins, 0);            

            if (resT1.Trim() == "" || resT2.Trim() == "")
            {
                return getTimeSpanHours(ts);
            }
            else
            {
                string tempT1 = T1;
                string tempT2 = T2;

                //正常流程 
                if (T1.CompareTo(resT1) < 0 && T2.CompareTo(resT2) > 0)
                {
                    int tempMins = SiteHelper.ConvertStrTimeToMins(resT2) - SiteHelper.ConvertStrTimeToMins(resT1);
                    ts = new TimeSpan(0, mins - tempMins, 0);
                    return getTimeSpanHours(ts);
                }
                else
                {
                    //如果 T1、T2 在 resT1與resT2中間，計算起點就算再resT2
                    if (T1.CompareTo(resT1) >= 0 && T1.CompareTo(resT2) <= 0)
                    {
                        tempT1 = resT2;
                    }

                    if (T2.CompareTo(resT1) >= 0 && T2.CompareTo(resT2) <= 0)
                    {
                        tempT2 = resT1;
                    }


                    int tempMins = SiteHelper.ConvertStrTimeToMins(tempT2) - SiteHelper.ConvertStrTimeToMins(tempT1);
                    ts = new TimeSpan(0, mins - tempMins, 0);

                    return getTimeSpanHours(ts);
                }
            }            
        }

        /// <summary>
        /// 取得時間差距，以最小為0.5小時為單位
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        private double getTimeSpanHours(TimeSpan ts)
        {
            double result=0;
            result = ts.Hours;
            if ( ts.Minutes >= 30 )
                result = result + 0.5;

            return result;
        }

        public decimal ConvertTimeSpan2Hours(TimeSpan ts)
        {
            decimal result = 0;
            result = ts.Hours;
            if (ts.Minutes >= 30)
                result = result + 0.5m;

            return result;
        }

        public ATTEND GetByNobrDate(string nobr, DateTime date)
        {
            using (JBHRModelDataContext o = new JBHRModelDataContext())
            {
                return (from c in o.ATTEND where c.ADATE == date && c.NOBR == nobr select c).FirstOrDefault();
            }
        }


        public AttendDs.AttendUnusualDataTable GetAttendUnusualDT(DateTime adate,DateTime ddate,int mins)
        {            
            AttendDs.AttendUnusualDataTable dt = null;

                        AttendDsTableAdapters.AttendUnusualTableAdapter attU_adapter = new AttendDsTableAdapters.AttendUnusualTableAdapter();
                        dt = attU_adapter.GetByDateRangeMins(adate, ddate, mins);
                        return dt;
        }

        public AttendDs.AttendUnusualDataTable ExcludeNobr(AttendDs.AttendUnusualDataTable dt)
        {
            string preStr="";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                preStr=dt[i].NOBR.Substring(0,1).ToUpper();
                //臨時的員工，不顯示出勤異常
                if (preStr.Equals("T") || preStr.Equals("A"))
                {
                    dt.Rows.RemoveAt(i);
                    i--;
                }
            }
            return dt;
        }

        public List<ATTEND> GetAttendLateByEmpDateRange_Dlo(string nobr, DateTime bDate, DateTime eDate)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                //loc.Log = new DebuggerWriter();
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ATTEND>(l => l.BASE);
                //dlo.LoadWith<ATTEND>(l => l.ATTCARD);
                //dlo.LoadWith<ATTEND>(l => l.ROTE1);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                //dlo.LoadWith<BASETTS>(l => l.HOLICD);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                ldc.LoadOptions = dlo;

                return (from c in ldc.ATTEND
                        where c.ADATE >= bDate && c.ADATE <= eDate
                        && c.BASE.BASETTS.Any()
                        && c.BASE.NOBR ==nobr
                        && c.LATE_MINS > 0
                        select c).ToList();
            }
        }


        public List<ATTEND> GetAttendLateByDeptDateRange_Dlo(string deptCode, DateTime bDate, DateTime eDate)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                //loc.Log = new DebuggerWriter();
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ATTEND>(l => l.BASE);
                //dlo.LoadWith<ATTEND>(l => l.ATTCARD);
                //dlo.LoadWith<ATTEND>(l => l.ROTE1);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                //dlo.LoadWith<BASETTS>(l => l.HOLICD);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                ldc.LoadOptions = dlo;

                return (from c in ldc.ATTEND
                        where c.ADATE >= bDate && c.ADATE <= eDate
                        && c.BASE.BASETTS.Any()
                        && c.BASE.BASETTS.Where(p => p.DEPT == deptCode).Any()
                        && c.LATE_MINS > 0
                        select c).ToList();
            }
        }

        public List<EmpAttendLateSumDto> SummaryEmpAttnedLate(List<EmpAttendLateDto> list)
        {
            List<EmpAttendLateSumDto> resultList = new List<EmpAttendLateSumDto>();

            List<string> nobrList = (from c in list select c.Nobr).Distinct().ToList();

            foreach (string nobr in nobrList)
            {
                EmpAttendLateDto attendObj = (from c in list where c.Nobr == nobr select c).First();

                EmpAttendLateSumDto attendSumObj = new EmpAttendLateSumDto();
                attendSumObj.DeptCode = attendObj.DeptCode;
                attendSumObj.DeptName = attendObj.DeptName;
                attendSumObj.JobCode = attendObj.JobCode;
                attendSumObj.JobName = attendObj.JobName;
                attendSumObj.Name_C = attendObj.Name_C;
                attendSumObj.Name_E = attendObj.Name_E;
                attendSumObj.Nobr = attendObj.Nobr;
                attendSumObj.MinsAmt = (from c in list where c.Nobr == nobr select c.Qty).Sum();
                attendSumObj.MinsNum = (from c in list where c.Nobr == nobr select c.Qty).Count();
                resultList.Add(attendSumObj);
            }

            resultList = resultList.OrderByDescending(p => p.MinsAmt).ToList();

            int counter = 1;
            foreach (var i in resultList)
                i.Place = counter++;

            return resultList;
        }
    }    
}