using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Salary.View
{
    public class GetSalaryWageLockDto
    {
        public string EmployeeID { get; set; }
        public string Saladr { get; set; }
        public string YYMM { get; set; }
        public string Seq { get; set; }
        public string Meno { get; set; }
    }
}
