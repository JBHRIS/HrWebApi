using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.ImportC.VDB
{
    class OTDto
    {
        public string 工號 { get; set; }
        public DateTime 加班日期{ get; set; }
        public decimal 總時數{ get; set; }
        public decimal 加班時數{ get; set; }
        public decimal 補休時數{ get; set; }
        public string 加班起{ get; set; }
        public string 加班迄{ get; set; }
        public string 加班原因 { get;set; }
        public string 計薪年月{ get; set; }
        public DateTime 有效日期{ get; set; }
        public string 備註 { get; set; }

    }
}
