using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using JBModule.Data.Linq;

namespace JBHR.ImportC.SQL_Repo
{
    class Base_REPO
    {
        public List<JBModule.Data.Linq.BASE> getAll()
        {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (from c in HDDC.BASE select c).ToList();
            }
        }


        public List<JBModule.Data.Linq.BASE> getAllDto()
        {
            DateTime dt = DateTime.Now;
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                HDDC.LoadOptions = dlo;
                return (
                    from c in HDDC.BASE 
                    where 
                    c.BASETTS.Any()
                    select c
                    ).ToList();
            }
        }



        public BASE getByIdno(string idno) {
            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                //dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => dt >= t.ADATE && dt <= t.DDATE && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                HDDC.LoadOptions = dlo;
                return (
                    from c in HDDC.BASE
                    where
                    c.IDNO.Equals(idno)
                    &&
                    c.BASETTS.Any()
                    select c
                    ).FirstOrDefault();
            }
        }




        public List<string> getAllNobrList() {

            using (JBModule.Data.Linq.HrDBDataContext HDDC = new JBModule.Data.Linq.HrDBDataContext())
            {
                return (from c in HDDC.BASE select c.NOBR).ToList();
            }
        
        }
    }
}
