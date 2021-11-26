using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class AbsEntitleDto
    {
        public string EmployeeID;
        public string Hcode;
        public string YYMM;
        public DateTime BeginDate;
        public DateTime EndDate;
        public string SubKey = "";
        public decimal? Taken;
        public string Remark;
        public string Serno;
        public string CreateMan;
    }
}
