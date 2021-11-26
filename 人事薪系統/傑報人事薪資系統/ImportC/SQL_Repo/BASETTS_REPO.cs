using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBModule.Data.Linq;

namespace JBHR.ImportC.SQL_Repo
{
    class BASETTS_REPO
    {
        public static readonly string[] EMP_HIRED_TTSCODE = new string[] { "1" , "4" , "6" };

        public List<BASETTS> getAll()
        {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (from c in HDDC.BASETTS select c).ToList();
            }
        }
    }
}
