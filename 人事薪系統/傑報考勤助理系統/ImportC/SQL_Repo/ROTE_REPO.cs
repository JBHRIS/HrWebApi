using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using JBModule.Data.Linq;

namespace JBHR.ImportC.SQL_Repo
{
    class ROTE_REPO
    {
        public List<ROTE> getAll()
        {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (from c in HDDC.ROTE select c).ToList();
            }
        }
    }
}
