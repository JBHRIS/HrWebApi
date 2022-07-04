using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.Entry
{
    public class ChangePasswordEntry
    {
        public string resetkey { get; set; }
        public string newPw { get; set; }
    }
}
