using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace JBHR.ImportC.SQL_Repo
{
    class ABS_REPO
    {
        public List<JBModule.Data.Linq.ABS> getAll()
        {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (from c in HDDC.ABS select c).ToList();
            }
        }

        public decimal getABSLeftHRSByNobrETC(string nobr, DateTime adate, DateTime ddate, List<string> year_Rest_Add, List<string> year_Rest_Dec)
        {
            decimal totalHRS = 0;
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                var absA = (from c in HDDC.ABS
                            where
                            c.NOBR.Equals(nobr)
                            &&
                            c.BDATE.CompareTo(adate) >= 0
                            &&
                            c.EDATE.CompareTo(ddate) <= 0
                            &&
                            year_Rest_Add.Contains(c.H_CODE)
                            select
                            c.TOL_HOURS).ToList();

                var addABS = absA.Sum();

                var absD = (from c in HDDC.ABS
                            where
                            c.NOBR.Equals(nobr)
                            &&
                            c.BDATE.CompareTo(adate) >= 0
                            &&
                            c.EDATE.CompareTo(ddate) <= 0
                            &&
                            year_Rest_Dec.Contains(c.H_CODE)
                            select
                            c.TOL_HOURS).ToList();

                var decABS = absD.Sum();

                totalHRS = addABS - decABS;
            }
            return totalHRS;
        }

        public List<JBModule.Data.Linq.ABS> getByDateRangeH_Code(DateTime bdate,DateTime edate,string hcode) {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (from c in HDDC.ABS 
                        where
                        c.BDATE.CompareTo(bdate) >= 0
                        &&
                        c.EDATE.CompareTo(edate) <= 0
                        &&
                        c.H_CODE.Equals(hcode)
                        select c
                    ).ToList();
            }
        }

    }
}
