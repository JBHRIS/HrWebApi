using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Employee.Entry
{
    public class UpdatePasswordEntry
    {
        public string oldPw { get; set; }
        public string newPw { get; set; }
    }
}
