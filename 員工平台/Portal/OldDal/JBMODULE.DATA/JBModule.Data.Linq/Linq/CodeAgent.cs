using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Linq
{
    public class CodeAgent
    {
        public HrDBDataContext dc { get; set; }
        public CodeAgent()
        {
            dc = new HrDBDataContext();
        }
        internal CodeAgent(HrDBDataContext _dc)
        {
            dc = _dc;
        }
        public IQueryable<HCODE> GetHCODE()
        {
            return (from c in dc.HCODE
                    select c);
        }
        public HCODE GetHCODEByCode(string Hcode)
        {
            return (from c in dc.HCODE
                    where c.H_CODE == Hcode
                    select c).FirstOrDefault();
        }

        public IQueryable<ROTE> GetROTE()
        {
            return (from c in dc.ROTE
                    select c);
        }
        public ROTE GetROTEByCode(string Rote)
        {
            return (from c in dc.ROTE
                    where c.ROTE1 == Rote
                    select c).FirstOrDefault();
        }
    }
}
