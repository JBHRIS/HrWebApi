using System;
using System.Collections.Generic;
using System.Text;

namespace HRWebService.Dto.Vdb
{
    public class PayslipVdb
    {
    }

    public class PayslipConfig
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public List<string> SalCodeList { get; set; }
    }

}
