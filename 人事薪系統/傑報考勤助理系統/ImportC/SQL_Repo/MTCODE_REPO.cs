using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using JBModule.Data.Linq;

namespace JBHR.ImportC.SQL_Repo
{
    class MTCODE_REPO
    {
        public List<JBModule.Data.Linq.MTCODE> getAll()
        {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (from c in HDDC.MTCODE select c).ToList();
            }
        }

        public List<JBModule.Data.Linq.MTCODE> getByCATEGORY(string CATEGORY_Type)
        {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (
                    from c in HDDC.MTCODE
                        where
                        c.CATEGORY.Equals(CATEGORY_Type)
                        select c
                        ).ToList();
            }
        }


    }
}
