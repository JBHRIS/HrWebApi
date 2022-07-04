using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.Normal
{
    public class EmployeeFamilyDto
    {
        public string FaIdno { get; set; }
        public string FaName { get; set; }
        public string RelCode { get; set; }
        public string RelCodeName { get; set; }
        public DateTime? FaBirdt { get; set; }
        public string Nobr { get; set; }
    }
}
