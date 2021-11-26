using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Salary.View
{
    public class GetRetirementDto
    {
        public decimal Exp { get; set; } //員工自提
        public decimal Comp { get; set; } //公司提撥
    }
}
