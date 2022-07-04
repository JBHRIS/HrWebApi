using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class QBaseM
    {
        public int IAutoKey { get; set; }
        public string SCode { get; set; }
        public string STypeCode { get; set; }
        public string SNobr { get; set; }
        public string SPw { get; set; }
        public string SName { get; set; }
        public string SDeptCode { get; set; }
        public string SDeptName { get; set; }
        public DateTime DAmountDate { get; set; }
        public DateTime DWriteDate { get; set; }
        public DateTime DSchoolDateB { get; set; }
        public DateTime DSchoolDateE { get; set; }
        public string SYymm { get; set; }
        public string SSer { get; set; }
        public string SCourseCode { get; set; }
        public string SCourseName { get; set; }
        public string SNatureCode { get; set; }
        public string SNatureName { get; set; }
        public string SDocentCode { get; set; }
        public string SDocentName { get; set; }
        public int ITotalFraction { get; set; }
    }
}
