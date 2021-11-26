using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class HcodeOvertimeHoursLabourCheckRule : ILabourCheckRule
    {

        #region ILabourCheckRule 成員

        public List<Linq.OT_B> ValidateOT(List<Linq.OT_B> Source)
        {
            if (Source.Count == 0) return Source;
            decimal MonthlyOvertimeMaxHours = Convert.ToDecimal(Parameters["MonthlyOvertimeMaxHours"]);

            List<string> empList = Source.GroupBy(p => p.NOBR).Select(p => p.Key).ToList();
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            foreach (var emp in empList)
            {
                var removeData = GetHoliOt(Source, emp, true, db);//只挪0Z班
                foreach (var item in removeData)
                {//先搬例假日加班(0Z)
                    Source.Remove(item);
                }
            }
            return Source;
        }
        private List<JBModule.Data.Linq.OT_B> GetHoliOt(List<Linq.OT_B> checkOtList, string nobr, bool isHoliDayOt, Linq.HrDBDataContext db)
        {
            var holiList = new string[] { "0Z" };
            var sql = from a in checkOtList
                      join b in db.ATTEND on a.NOBR equals b.NOBR
                      where a.BDATE == b.ADATE && a.NOBR == nobr
                      select new { OT = a, b.ROTE };
            if (isHoliDayOt)
                return sql.Where(p => holiList.Contains(p.ROTE)).Select(q => q.OT).ToList();
            else
                return sql.Where(p => !holiList.Contains(p.ROTE)).Select(q => q.OT).ToList();
        }
        
        #endregion

        #region ILabourCheckRule 成員


        public Dictionary<string, object> Parameters { get; set; }

        #endregion
    }
}
