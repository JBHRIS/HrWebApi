using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JBModule.Data.Linq;

namespace JBHR.Reports.AttForm.ACCS
{
    class ATTEND_REPO
    {



        public List<ATTEND> GetALL(){
            using (HrDBDataContext HDDC = new HrDBDataContext())
            {
                return (from c in HDDC.ATTEND
                        select
                        c).ToList();
            }
        
        }
        public List<ATTEND> GetByNOBRListDATERange(List<string> NOBRList,DateTime ADATE,DateTime DDATE) {
            using (HrDBDataContext HDDC = new HrDBDataContext()) {
                var ItemList = (from c in HDDC.ATTEND
                            where
                            NOBRList.Contains(c.NOBR)
                            &&
                            c.ADATE.CompareTo(ADATE) >= 0
                            &&
                            c.ADATE.CompareTo(DDATE) <= 0
                            select
                            c).ToList();
                return ItemList;
            }
        }
        


    }
}
