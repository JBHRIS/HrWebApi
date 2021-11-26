using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Vdb
{
     public class EmpVdbDto
    {
    }

    public class EmpRow
    {
        public string EmpId { set; get; }
        public string LoginId { set; get; }
        public string Name { set; get; }
        public string DisplayName { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public MultiEnum.SexEnum Sex { set; get; }
    }
}
