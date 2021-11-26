using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Linq
{
    public class AttendanceAgent
    {
        public HrDBDataContext dc { get; set; }
        public AttendanceAgent()
        {
            dc = new HrDBDataContext();
        }
        internal AttendanceAgent(HrDBDataContext _dc)
        {
            dc = _dc;
        }
        public IQueryable<ATTEND> GetAttendance()
        {
            return (from c in dc.ATTEND
                    select c);
        }
        public IQueryable<ATTEND> GetAttendance(DateTime DateBegin, DateTime DateEnd)
        {
            return (from c in dc.ATTEND
                    where c.ADATE >= DateBegin.Date && c.ADATE <= DateEnd.Date
                    select c);
        }
    }
}
