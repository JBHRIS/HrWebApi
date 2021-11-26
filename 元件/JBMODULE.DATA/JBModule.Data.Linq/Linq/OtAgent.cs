using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Linq
{
    public class OtAgent
    {
        public HrDBDataContext dc { get; set; }
        public OtAgent()
        {
            dc = new HrDBDataContext();
        }
        internal OtAgent(HrDBDataContext _dc)
        {
            dc = _dc;
        }
        /// <summary>
        /// 抓取請假得假資料
        /// </summary>
        /// <returns></returns>
        public IQueryable<OT> GetData(DateTime DateBegin, DateTime DateEnd)
        {
            return (from c in dc.OT
                    where c.BDATE >= DateBegin && c.BDATE <= DateEnd
                    select c);
        }
    }
}
