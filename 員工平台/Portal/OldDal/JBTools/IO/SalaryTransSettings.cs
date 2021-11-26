using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBTools.IO
{
    public class SalaryTransSettings
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Location { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
        public string Side { get; set; }
        public string Filled { get; set; }
        public string YearType { get; set; }
        public string DateFormat { get; set; }
        public string FixedContent { get; set; }

        public SalaryTransSettings()
        {
            Code = "";
            Name = "";
            Location = 0;
            Length = 0;
            Type = "";
            Side = "";
            Filled = "";
            YearType = "";
            DateFormat = "";
            FixedContent = "";
        }
    }
}