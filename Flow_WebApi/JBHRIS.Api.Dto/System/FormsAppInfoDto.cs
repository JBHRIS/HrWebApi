using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.System
{
    public class FormsAppInfoDto
    {
        public int AutoKey { get; set; }
        public string ProcessID { get; set; }
        public int idProcess { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string SignState { get; set; }
        public string InfoSign { get; set; }
        public string InfoMail { get; set; }
        public string Code { get; set; }
        public DateTime KeyDate { get; set; }
    }
}
