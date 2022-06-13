using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using JBModule.Data.Linq;

namespace JBHR.ImportC.SQL_Repo
{
    class ATTEND_REPO
    {
        public List<ATTEND> getAll()
        {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (from c in HDDC.ATTEND select c).ToList();
            }
        }

        //public List<ATTEND> getByDateRangeDlo(DateTime dtMAX, DateTime dtMIN) {
        //    using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext()) {
        //        DataLoadOptions dlo = new DataLoadOptions();
        //        dlo.LoadWith<ATTEND>(l => l.ROTE1);
        //        HDDC.LoadOptions = dlo;

        //        var attendList = (from c in HDDC.ATTEND
        //                         where
        //                         c.ADATE.CompareTo(dtMAX) <= 0
        //                         &&
        //                         c.ADATE.CompareTo(dtMIN) >= 0
        //                         select c).ToList();
        //        return attendList;
        //    }
        //}
    }
}
