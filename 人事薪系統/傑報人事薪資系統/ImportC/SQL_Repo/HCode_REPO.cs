using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.ImportC.SQL_Repo
{
    class HCode_REPO
    {
        public List<JBModule.Data.Linq.HCODE> getAll()
        {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (from c in HDDC.HCODE select c).ToList();
            }
        }
        public List<string> getH_CodeListByYearRest(string year_rest) {

            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (from c in HDDC.HCODE where c.YEAR_REST.Equals(year_rest) select c.H_CODE).ToList();
            }
        }
    }
}
