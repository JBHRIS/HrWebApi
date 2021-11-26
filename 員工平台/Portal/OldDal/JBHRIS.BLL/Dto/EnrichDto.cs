using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class EnrichDto
    {
        public string EmployeeID;
        public string FamilyID;
        public string YYMM;
        public string Seq;
        public string SalaryCode;
        public decimal Amout;
        public string CreateMan;
        public bool IsImport;
        public string Remark;
        public int Auto = -1;
    }
}
