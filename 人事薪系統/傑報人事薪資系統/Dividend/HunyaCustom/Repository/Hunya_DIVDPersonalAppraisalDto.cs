using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Dividend.HunyaCustom.Repository
{
    public class Hunya_DIVDPersonalAppraisalDto
    {
        public string EmployeeID { get; set; }
        public int YYYY { get; set; }
        public string DIVDAppraisalCode { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public Guid GID { get; set; }
    }
}
