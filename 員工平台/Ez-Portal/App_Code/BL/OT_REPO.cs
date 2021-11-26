using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JBHRModel;


namespace BL
{
    /// <summary>
    /// DEPTA 的摘要描述
    /// </summary>
    public class OT_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        private ATTEND_REPO attendRepo = new ATTEND_REPO();
        private BASE_REPO baseRepo = new BASE_REPO();
        private BASETTS_REPO basettsRepo = new BASETTS_REPO();
        private HOLI_REPO holiRepo = new HOLI_REPO();

        private double holiHrsAmt = 0;
        public OT_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public OT_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<OT> GetByDateRange(DateTime adate, DateTime ddate)
        {
            using (JBHRModelDataContext o = new JBHRModelDataContext())
            {
                return (from c in o.OT where c.BDATE >= adate && c.BDATE <= ddate select c).ToList();
            }
        }

        public List<OT> GetByNobrDateRange(string nobr,DateTime adate, DateTime ddate)
        {
            using (JBHRModelDataContext o = new JBHRModelDataContext())
            {
                return (from c in o.OT where c.BDATE >= adate && c.BDATE <= ddate
                        && c.NOBR == nobr
                        select c).ToList();
            }
        }


        /// <summary>
        /// 個人區間的加班統計資料by Date Range、Dept
        /// </summary>
        /// <param name="adate"></param>
        /// <param name="ddate"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public List<OT46AMT> GetOt46ViewByDateRangeDept(DateTime adate, DateTime ddate, string deptCode)
        {
            DateTime datetime = ddate;

            List<HOLI> holiList = holiRepo.GetByDateRange(adate, ddate);
            var holiGroupList = from c in holiList
                                group c by c.HOLI_CODE into g
                                select new { Code = g.Key, Qty = g.Count() };


            JBHRModelDataContext o = new JBHRModelDataContext();
            var otList = (from ot in o.OT
                          join att in o.ATTEND on new
                          {
                              NOBR = ot.NOBR,
                              DATE = ot.BDATE
                          }
                          equals new
                          {
                              NOBR = att.NOBR,
                              DATE = att.ADATE
                          }
                          join b in o.BASE on ot.NOBR equals b.NOBR
                          join tts in o.BASETTS on b.NOBR equals tts.NOBR
                          join dept in o.DEPT on tts.DEPT equals dept.D_NO
                          join depts in o.DEPTS on tts.DEPTS equals depts.D_NO
                          join r in o.ROTE on att.ROTE equals r.ROTE1
                          where ot.BDATE >= adate && ot.BDATE <= ddate
                          && datetime >= tts.ADATE && datetime <= tts.DDATE
                          && tts.DEPT == deptCode
                          select new
                          {
                              ot,
                              att,
                              b,
                              tts,
                              dept,
                              depts,
                              r
                          }).ToList();

            List<OT46AMT> dt = new List<OT46AMT>();

            var empList = (from c in otList
                           select c.ot.NOBR).Distinct().ToList();

            foreach (var empStr in empList)
            {
                OT46AMT row = new OT46AMT();
                row.OT = 0;
                row.HolidayOT = 0;
                row.Nobr = empStr;
                var emp = (from c in otList where c.ot.NOBR == empStr select new { c.b, c.tts, c.dept,c.depts}).FirstOrDefault();
                row.Name_C = emp.b.NAME_C;
                row.Name_E = emp.b.NAME_E;
                row.DeptName = emp.dept.D_NAME;
                row.DeptsName = emp.depts.D_NAME;
                var holidayOT = (from c in otList where c.att.NOBR == empStr && c.r.ROTE_DISP.Equals("00") select c.ot.TOT_HOURS).Sum();
                var ot = (from c in otList where c.att.NOBR == empStr && !c.r.ROTE_DISP.Equals("00") select c.ot.TOT_HOURS).Sum();
                row.HolidayOT = holidayOT;
                row.OT = ot;
                row.OtPercent = Math.Round(row.OT / 46, 4, MidpointRounding.AwayFromZero);


                var holiHrsAmt = (from c in holiGroupList
                                  where c.Code == emp.tts.HOLI_CODE
                                  select c).FirstOrDefault();

                if (holiHrsAmt == null)
                    row.AllHoliHrsAmt = 0;
                else
                    row.AllHoliHrsAmt = holiHrsAmt.Qty * 8;

                if (row.AllHoliHrsAmt == 0)
                    row.HOtPercent = 0;
                else
                    row.HOtPercent = Math.Round((row.HolidayOT / row.AllHoliHrsAmt), 4, MidpointRounding.AwayFromZero);

                dt.Add(row);
            }

            //以下增加當時在職員工加班時數為0

            BASETTS_REPO basettsRepo = new BASETTS_REPO();
            List<BASETTS> empHiredList = basettsRepo.GetHiredByDateDept_Inc(ddate,deptCode);
            foreach (var emp in empHiredList)
            {
                if (dt.Where(p => p.Nobr == emp.NOBR).Count() == 0) 
                {
                    OT46AMT row = new OT46AMT();
                    row.OT = 0;
                    row.HolidayOT = 0;
                    row.Nobr = emp.NOBR;
                    row.Name_C = emp.BASE.NAME_C;
                    row.Name_E = emp.BASE.NAME_E;
                    row.DeptName = emp.DEPT1.D_NAME;
                    row.DeptsName = emp.DEPTS1.D_NAME;
                    //row.DeptsName = emp.DEPTS1.D_NAME;
                    row.HolidayOT = 0;
                    row.OT = 0;
                    row.OtPercent = 0;

                    var holiHrsAmt = (from c in holiGroupList
                                      where c.Code == emp.HOLI_CODE
                                      select c).FirstOrDefault();

                    if (holiHrsAmt == null)
                        row.AllHoliHrsAmt = 0;
                    else
                        row.AllHoliHrsAmt = holiHrsAmt.Qty * 8;

                    if (row.AllHoliHrsAmt == 0)
                        row.HOtPercent = 0;
                    else
                    {
                        row.HOtPercent = Math.Round((row.HolidayOT / row.AllHoliHrsAmt), 4, MidpointRounding.AwayFromZero);
                    }

                    dt.Add(row);
                }
            }

            return dt;
        }



        /// <summary>
        /// 個人區間的加班統計資料By Date Range
        /// </summary>
        /// <param name="adate"></param>
        /// <param name="ddate"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public List<OT46AMT> GetOt46ViewByDateRange(DateTime adate, DateTime ddate,double timeSpan)
        {
            DateTime datetime = ddate;
            List<HOLI> holiList = holiRepo.GetByDateRange(adate, ddate);
            var holiGroupList = from c in holiList group c by c.HOLI_CODE into g
                                 select new {Code=g.Key,Qty=g.Count()};
                                 
            //holiHrsAmt = holiList.Count() * 8;

            JBHRModelDataContext o = new JBHRModelDataContext();
            var otList = (from ot in o.OT
                           join att in o.ATTEND on new
                           {
                               NOBR = ot.NOBR ,
                               DATE = ot.BDATE
                           }
                           equals new
                           {
                               NOBR = att.NOBR ,
                               DATE = att.ADATE
                           }
                           join r in o.ROTE on att.ROTE equals r.ROTE1
                           join b in o.BASE on ot.NOBR equals b.NOBR
                           join tts in o.BASETTS on b.NOBR equals tts.NOBR  
                           join dept in o.DEPT on tts.DEPT equals dept.D_NO
                           join depts in o.DEPTS on tts.DEPTS equals depts.D_NO
                           where ot.BDATE >=adate && ot.BDATE <=ddate
                           && datetime >= tts.ADATE && datetime <= tts.DDATE
                           select new
                           {
                               ot ,
                               att,
                               b,
                               r,
                               tts, 
                               dept,                               
                               depts
                           }).ToList();


            List<OT46AMT> dt = new List<OT46AMT>();

            var empList = (from c in otList
                            select c.ot.NOBR).Distinct().ToList();

            foreach (var empStr in empList)
            {
                OT46AMT row =new OT46AMT();
                row.OT = 0;
                row.HolidayOT = 0;
                row.Nobr = empStr;
                var emp = (from c in otList where c.ot.NOBR == empStr select new { c.b, c.tts,c.dept,c.depts}).FirstOrDefault();
                row.Name_C = emp.b.NAME_C;
                row.Name_E = emp.b.NAME_E;
                row.DeptName = emp.dept.D_NAME;
                row.DeptsName = emp.depts.D_NAME; //emp.tts.DEPTS;//emp.depts.D_NAME;
                var holidayOT = (from c in otList where c.att.NOBR == empStr && c.r.ROTE_DISP.Equals("00") select c.ot.TOT_HOURS).Sum();
                var ot = (from c in otList where c.att.NOBR == empStr && !c.r.ROTE_DISP.Equals("00") select c.ot.TOT_HOURS).Sum();
                row.HolidayOT = holidayOT;
                row.OT = ot;
                //row.OtPercent = Math.Round(((row.OT / 46) * 100), 2, MidpointRounding.AwayFromZero).ToString() + "%";
                row.OtPercent = Math.Round((row.OT / 46), 4, MidpointRounding.AwayFromZero);
                
                //row.HOtPercent = Math.Round(((row.HolidayOT / holiHrsAmt) * 100), 2, MidpointRounding.AwayFromZero).ToString() + "%";                        
                var holiHrsAmt = (from c in holiGroupList
                                  where c.Code == emp.tts.HOLI_CODE
                                  select c).FirstOrDefault();

                if (holiHrsAmt == null)
                    row.AllHoliHrsAmt = 0;
                else
                    row.AllHoliHrsAmt = holiHrsAmt.Qty * 8;

                if (row.AllHoliHrsAmt == 0)
                    row.HOtPercent = 0;
                else
                    row.HOtPercent = Math.Round((row.HolidayOT / row.AllHoliHrsAmt ) , 4, MidpointRounding.AwayFromZero);
                //if(row.OT>=timeSpan || row.HolidayOT>=timeSpan)
                dt.Add(row);            
            }


            //以下增加當時在職員工加班時數為0

            BASETTS_REPO basettsRepo = new BASETTS_REPO();
            List<BASETTS> empHiredList= basettsRepo.GetHiredByDate_Inc(ddate);
            foreach (var emp in empHiredList)
            {
                if (dt.Where(p => p.Nobr == emp.NOBR).Count() == 0) 
                {
                    OT46AMT row = new OT46AMT();
                    row.OT = 0;
                    row.HolidayOT = 0;
                    row.Nobr = emp.NOBR;                   
                    row.Name_C = emp.BASE.NAME_C;
                    row.Name_E = emp.BASE.NAME_E;
                    row.DeptName = emp.DEPT1.D_NAME;
                    //row.DeptsName = emp.DEPTS1.D_NAME;
                    row.DeptsName = emp.DEPTS1.D_NAME;
                    row.HolidayOT = 0;
                    row.OT = 0;
                    row.OtPercent = 0;

                    var holiHrsAmt = (from c in holiGroupList
                                      where c.Code == emp.HOLI_CODE
                                      select c).FirstOrDefault();

                    if (holiHrsAmt == null)
                        row.AllHoliHrsAmt = 0;
                    else
                        row.AllHoliHrsAmt = holiHrsAmt.Qty * 8;

                    if (row.AllHoliHrsAmt == 0)
                        row.HOtPercent = 0;
                    else
                        row.HOtPercent = Math.Round((row.HolidayOT / row.AllHoliHrsAmt), 4, MidpointRounding.AwayFromZero);

                    dt.Add(row); 
                }
            }

            return dt;
        }


        /// <summary>
        /// 部門區間的加班統計資料，從個人的加班統計資料來
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>

        public List<OT46Summury> GetOt46ViewSummuryByDateRange(List<OT46AMT> dt)
        {
            List<OT46Summury> resultDT = new List<OT46Summury>();
            decimal AllEmpOtTimeAmt = 0;  //全部員工加班總時數
            int AllEmpOtAndHOtQty = 0;           //全部平日+假日加班員工
            decimal AllEmpHOtTimeAmt = 0; //全部員工假日加班總時數
            int AllEmpOtQty = 0;  //全部平日加班員工
            int AllEmpHOtQty = 0; //全部假日加班員工
            decimal AllEmpOtAndHOtTimeAmt = 0; //全部員工平日+假日加班時數

            AllEmpOtTimeAmt = (from c in dt select c.OT).Sum();
            AllEmpHOtTimeAmt = (from c in dt select c.HolidayOT).Sum();
            AllEmpOtAndHOtTimeAmt = AllEmpOtTimeAmt + AllEmpHOtTimeAmt;
            AllEmpOtAndHOtQty = (from c in dt select c.Nobr).Distinct().Count();
            AllEmpOtQty = (from c in dt where c.OT > 0 select c.Nobr).Distinct().Count();
            AllEmpHOtQty = (from c in dt where c.HolidayOT > 0 select c.Nobr).Distinct().Count();
            

            var deptName = (from c in dt select c.DeptName).Distinct();

            foreach (var d in deptName)
            {
                OT46Summury row = new OT46Summury();
                decimal deptOtTimeAmt = 0;
                decimal deptHOtTimeAmt = 0;
                decimal deptAllHoliHrsAmt = 0;
                //double deptOtAndHOtTimeAmt = 0;
                int deptEmpHOtQty = 0;
                int deptEmpOtQty = 0;
                int deptEmpOtAndHOtQty = 0; //假日+平日加班人員數
                int deptEmpQty = 0; //部門人員總數
                int deptEmpOtErrorQty = 0;//部門平日加班超過46小時人數(異常)
                int deptEmpHOtErrorQty = 0;//部門假日加班異常人數

                deptEmpHOtQty = (from c in dt where c.DeptName == d && c.HolidayOT>0 select c.Nobr).Distinct().Count();
                deptEmpOtQty = (from c in dt where c.DeptName == d && c.OT >0 select c.Nobr).Distinct().Count();                
                deptOtTimeAmt =(from c in dt where c.DeptName == d select c.OT).Sum();
                deptHOtTimeAmt = (from c in dt where c.DeptName == d select c.HolidayOT).Sum();
                deptEmpOtAndHOtQty = (from c in dt where c.DeptName == d && (c.OT > 0 ||c.HolidayOT>0)  select c.Nobr).Distinct().Count();
                deptEmpQty = (from c in dt where c.DeptName == d select c.Nobr).Distinct().Count();
                deptEmpOtErrorQty = (from c in dt where c.DeptName == d && c.OT > 46 select c.Nobr).Count();
                deptAllHoliHrsAmt = (from c in dt where c.DeptName == d select c.AllHoliHrsAmt).Sum();
                deptEmpHOtErrorQty = (from c in dt where c.DeptName == d && c.HOtPercent > 50 select c.Nobr).Count();

                row.DeptEmpQty = deptEmpQty;
                row.DeptName = d;
                //row.DeptOtTimeAmt = deptOtTimeAmt.ToString();
                //row.DeptHOtTimeAmt = deptHOtTimeAmt.ToString();
                //row.DeptEmpOtAndHOtQty = deptEmpOtAndHOtQty.ToString();
                //row.DeptEmpOtQty = deptEmpOtQty.ToString();
                //row.DeptEmpHOtQty = deptEmpHOtQty.ToString();
                row.DeptOtTimeAmt = deptOtTimeAmt;
                row.DeptHOtTimeAmt = deptHOtTimeAmt;
                row.DeptEmpOtAndHOtQty = deptEmpOtAndHOtQty;
                row.DeptEmpOtQty = deptEmpOtQty;
                row.DeptEmpHOtQty = deptEmpHOtQty;

                row.DeptEmpOtErrorQty = deptEmpOtErrorQty;
                row.DeptEmpHOtErrorQty = deptEmpHOtErrorQty;
                row.DeptAllHoliHrsAmt = deptAllHoliHrsAmt;

                if ( AllEmpOtTimeAmt != 0 )
                    //row.DeptOtPercent = Math.Round(((deptOtTimeAmt / (deptEmpQty * 46)) * 100), 2, MidpointRounding.AwayFromZero).ToString();                
                    row.DeptOtPercent = Math.Round((deptOtTimeAmt / (deptEmpQty * 46)), 4, MidpointRounding.AwayFromZero);                
                else
                    row.DeptOtPercent = 0;
                    //row.DeptOtPercent = "0";

                if (deptAllHoliHrsAmt != 0)
                    row.DeptHOtPercent = Math.Round(deptHOtTimeAmt/deptAllHoliHrsAmt, 4, MidpointRounding.AwayFromZero);                
                    //row.DeptHOtPercent = Math.Round(((deptHOtTimeAmt/deptAllHoliHrsAmt) * 100), 2, MidpointRounding.AwayFromZero).ToString();                
                else
                    row.DeptHOtPercent = 0;
                    //row.DeptHOtPercent = "0";


                //deptOtAndHOtTimeAmt = deptOtTimeAmt + deptHOtTimeAmt;
                //row.DeptOtAndHOtTimeAmt =deptOtAndHOtTimeAmt.ToString();
                row.DeptOtAndHOtTimeAmt = 0;
                row.DeptOtAndHOtPercent = 0;


                row.AllEmpHOtQty = AllEmpHOtQty;
                row.AllEmpOtQty = AllEmpOtQty;
                row.AllEmpHOtTimeAmt = AllEmpHOtTimeAmt;
                row.AllEmpOtTimeAmt = AllEmpOtTimeAmt;
                row.AllEmpOtAndHOtQty = AllEmpOtAndHOtQty;
                row.AllEmpOtAndHOtTimeAmt = AllEmpOtAndHOtTimeAmt;

                resultDT.Add(row);
            }

            return resultDT;
        }

        public List<OT> GetByNobrFromCache(string nobr, List<OT> cache)
        {
            return (from c in cache where c.NOBR ==nobr select c).ToList();
        }

        public List<EmpOtSummury> GetEmpOtSummuryByNobrDateRange(string nobr, DateTime bDate, DateTime eDate)
        {
            List<ATTEND> attendList = attendRepo.GetByNobrDateRangeOtMoreThen_Dlo(nobr, bDate, eDate, 31);
            List<BASE> empList = (from c in attendList orderby c.NOBR select c.BASE).Distinct().ToList();

            List<EmpOtSummury> empOtSummuryList = new List<EmpOtSummury>();

            foreach (ATTEND a in attendList)
            {
                EmpOtSummury obj = (from c in empOtSummuryList where c.Nobr == a.NOBR select c).FirstOrDefault();

                if (obj == null)
                {
                    obj = new EmpOtSummury();
                    obj.Nobr = a.NOBR;
                    obj.NameC = a.BASE.NAME_C;
                    obj.DeptDispCode = a.BASE.BASETTS[0].DEPT1.D_NO_DISP;
                    obj.DeptName = a.BASE.BASETTS[0].DEPT1.D_NAME;
                    obj.JobDispCode = a.BASE.BASETTS[0].JOB1.JOB_DISP;
                    obj.JobName = a.BASE.BASETTS[0].JOB1.JOB_NAME;
                    obj.OtAmt = 0;
                    obj.OtSubmittedAmt = 0;
                    obj.OtUnSubmittedAmt = 0;
                    empOtSummuryList.Add(obj);
                }

                if (a.EARLY_MINS.HasValue)
                {
                    DateTime datetime = DateTime.Now;
                    TimeSpan ts = datetime.AddMinutes(a.EARLY_MINS.Value) - datetime;
                    obj.OtAmt = obj.OtAmt + attendRepo.ConvertTimeSpan2Hours(ts);
                }

                if (a.DELAY_MINS.HasValue)
                {
                    DateTime datetime = DateTime.Now;
                    TimeSpan ts = datetime.AddMinutes(a.DELAY_MINS.Value) - datetime;
                    obj.OtAmt = obj.OtAmt + attendRepo.ConvertTimeSpan2Hours(ts);
                }
            }

            OT_REPO otRepo = new OT_REPO();
            foreach (EmpOtSummury emp in empOtSummuryList)
            {
                List<OT> otList = otRepo.GetByNobrDateRange(emp.Nobr, bDate, eDate);
                emp.OtSubmittedAmt = otList.Sum(p => p.TOT_HOURS);
                emp.OtUnSubmittedAmt = emp.OtAmt - emp.OtSubmittedAmt;
            }

            return empOtSummuryList;
        }

        public List<EmpOtSummury> GetEmpOtSummuryByDeptDateRange(string deptCode, DateTime bDate, DateTime eDate)
        {
            List<ATTEND> attendList = attendRepo.GetByDeptDateRangeOtMoreThen_Dlo(deptCode, bDate, eDate, 30);
            List<BASE> empList = (from c in attendList orderby c.NOBR select c.BASE).Distinct().ToList();

            List<EmpOtSummury> empOtSummuryList = new List<EmpOtSummury>();

            foreach (ATTEND a in attendList)
            {
                EmpOtSummury obj = (from c in empOtSummuryList where c.Nobr == a.NOBR select c).FirstOrDefault();

                if (obj == null)
                {
                    obj = new EmpOtSummury();
                    obj.Nobr = a.NOBR;
                    obj.NameC = a.BASE.NAME_C;
                    obj.DeptDispCode = a.BASE.BASETTS[0].DEPT1.D_NO_DISP;
                    obj.DeptName = a.BASE.BASETTS[0].DEPT1.D_NAME;
                    obj.JobDispCode = a.BASE.BASETTS[0].JOB1.JOB_DISP;
                    obj.JobName = a.BASE.BASETTS[0].JOB1.JOB_NAME;
                    obj.OtAmt =0;
                    obj.OtSubmittedAmt = 0;
                    obj.OtUnSubmittedAmt = 0;
                    empOtSummuryList.Add(obj);
                }
                
                if (a.EARLY_MINS.HasValue)
                {
                    DateTime datetime = DateTime.Now;
                    TimeSpan ts = datetime.AddMinutes(a.EARLY_MINS.Value) - datetime;
                    obj.OtAmt = obj.OtAmt + attendRepo.ConvertTimeSpan2Hours(ts);
                    }

                if (a.DELAY_MINS.HasValue)
                {
                    DateTime datetime = DateTime.Now;
                    TimeSpan ts = datetime.AddMinutes(a.DELAY_MINS.Value) - datetime;
                    obj.OtAmt = obj.OtAmt + attendRepo.ConvertTimeSpan2Hours(ts);
                }
            }

            OT_REPO otRepo = new OT_REPO();
            foreach (EmpOtSummury emp in empOtSummuryList)
            {
                List<OT> otList= otRepo.GetByNobrDateRange(emp.Nobr, bDate, eDate);
                emp.OtSubmittedAmt=otList.Sum(p => p.TOT_HOURS);
                emp.OtUnSubmittedAmt = emp.OtAmt - emp.OtSubmittedAmt;
            }

            return empOtSummuryList;
        }
    }    
}