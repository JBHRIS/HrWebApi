using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto
{
    public class HrDataRoleDto
    {
        public string DataGroup { get; set; }
        public bool ReadRule { get; set; }
        public bool WriteRule { get; set; }
    }
}
