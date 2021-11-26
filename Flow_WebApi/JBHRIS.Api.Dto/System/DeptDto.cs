using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.System
{
    public class DeptDto
    {
        public string DeptID { get; set; }

        public string ParentDeptID { get; set; }

        public string DeptName { get; set; }

        public string Path { get; set; }

        public string DeptLevel_ID { get; set; }
    }
}
