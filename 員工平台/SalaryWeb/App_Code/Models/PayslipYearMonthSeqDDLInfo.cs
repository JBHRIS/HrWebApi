using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalaryWeb.Models
{
    [Serializable]
    public class PayslipYearMonthSeqDDLInfo
    {
        public string Year { get; set; }

        public string Month { get; set; }

        public string Seq { get; set; }

        public string Note { get; set; }
    }
}