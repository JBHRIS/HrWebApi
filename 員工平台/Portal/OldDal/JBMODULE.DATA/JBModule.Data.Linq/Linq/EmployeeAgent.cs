using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Linq
{
    public class EmployeeAgent
    {
        List<string> OnJobTtscode = new List<string>();
        List<string> OffJobTtscode = new List<string>();
        public HrDBDataContext dc { get; set; }
        public EmployeeAgent()
        {
            dc = new HrDBDataContext();
            OnJobTtscode.Add("1");
            OnJobTtscode.Add("4");
            OnJobTtscode.Add("6");

            OffJobTtscode.Add("2");
            OffJobTtscode.Add("3");
            OffJobTtscode.Add("5");
        }
        internal EmployeeAgent(HrDBDataContext _dc)
        {
            dc = _dc;
            OnJobTtscode.Add("1");
            OnJobTtscode.Add("4");
            OnJobTtscode.Add("6");

            OffJobTtscode.Add("2");
            OffJobTtscode.Add("3");
            OffJobTtscode.Add("5");
        }
        /// <summary>
        /// 抓取目前在職員工
        /// </summary>
        /// <returns></returns>
        public IQueryable<BASE> GetOnJobEmployee(DateTime DDATE)
        {
            return (from c in dc.BASE
                    where c.BASETTS.Where(p => DDATE.Date >= p.ADATE && DDATE <= p.DDATE.Value && OnJobTtscode.Contains(p.TTSCODE)).Any()
                    select c);
            //}
        }
        /// <summary>
        /// 抓取目前在職員工
        /// </summary>
        /// <returns></returns>
        public IQueryable<BASE> GetOnJobEmployee(string NobrB, string NobrE, string DeptB, string DeptE, DateTime DDATE)
        {
            return (from c in dc.BASE
                    where c.BASETTS.Where(p => DDATE.Date >= p.ADATE && DDATE <= p.DDATE.Value
                        && OnJobTtscode.Contains(p.TTSCODE)
                        && c.NOBR.CompareTo(NobrB) >= 0 && c.NOBR.CompareTo(NobrE) <= 0
                        && p.DEPT.CompareTo(DeptB) >= 0 && p.DEPT.CompareTo(DeptE) <= 0
                        ).Any()
                    select c);
            //}
        }
        /// <summary>
        /// 抓取目前在職員工
        /// </summary>
        /// <returns></returns>
        public IQueryable<BASE> GetCurrentEmployee(string NobrB, string NobrE, string DeptB, string DeptE, DateTime DDATE)
        {
            return (from c in dc.BASE
                    where c.BASETTS.Where(p => DDATE.Date >= p.ADATE && DDATE <= p.DDATE.Value
                        //&& OnJobTtscode.Contains(p.TTSCODE)
                        && c.NOBR.CompareTo(NobrB) >= 0 && c.NOBR.CompareTo(NobrE) <= 0
                        && p.DEPT.CompareTo(DeptB) >= 0 && p.DEPT.CompareTo(DeptE) <= 0
                        ).Any()
                    select c);
            //}
        }
    }
}
