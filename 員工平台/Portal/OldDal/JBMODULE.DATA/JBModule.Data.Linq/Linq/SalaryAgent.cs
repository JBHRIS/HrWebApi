using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Linq
{
    public class SalaryAgent
    {
        public HrDBDataContext dc { get; set; }
        public SalaryAgent()
        {
            dc = new HrDBDataContext();
        }
        internal SalaryAgent(HrDBDataContext _dc)
        {
            dc = _dc;
        }
        /// <summary>
        /// 抓取目前在職員工
        /// </summary>
        /// <returns></returns>
        public IQueryable<SALBASD> GetCurrentSalary(DateTime DateBegin, DateTime DateEnd)
        {
            return (from c in dc.SALBASD
                    where c.ADATE <= DateEnd && c.DDATE >= DateBegin
                    select c);
            //}
        }
    }
}
