using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.Entry
{
    public class SetLockEnableDto
    {
        public string UserId { get; set; }
        public bool Lockstate { get; set; }
        public DateTime? LockoutEnd { get; set; }
    }
}
