using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using JBModule.Data.Linq;

namespace JBHR.ImportC.SQL_Repo
{
    class OT_REPO
    {
        public List<OT> getAll()
        {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (from c in HDDC.OT select c).ToList();
            }
        }

        public List<OT> getByDateTimeRange(DateTime dateMax, DateTime dateMin) {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                var otList =(from c in HDDC.OT
                              where
                              c.BDATE.CompareTo(dateMax) <= 0
                              &&
                              c.BDATE.CompareTo(dateMin) >= 0
                              select
                              c).ToList();
                return otList;
            }
        }

        public bool InsertByOTList(List<OT> OTList) {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                bool flag = true;
                try
                {
                    HDDC.OT.InsertAllOnSubmit(OTList);
                    HDDC.SubmitChanges();
                }
                catch (Exception)
                {
                    flag = false;
                }
                return flag;
            }
        }



    }
}
