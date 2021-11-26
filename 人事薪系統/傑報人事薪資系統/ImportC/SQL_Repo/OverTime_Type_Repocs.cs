using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.ImportC.SQL_Repo
{
    class OverTime_Type_Repocs
    {
        JBModule.Data.Linq.HrDBDataContext HDDC;
        public OverTime_Type_Repocs() {
            
        }
        public List<JBModule.Data.Linq.OVERTIME_TYPE> getAllOverTime_TypeList() {
            using (HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (from OvetTime_Typei in HDDC.OVERTIME_TYPE select OvetTime_Typei).ToList();
            }
        }




    }
}
