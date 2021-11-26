using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrHcode
    {
        public string SName { get; set; }
        public string SHcode { get; set; }
        public string SHname { get; set; }
        public string SUnit { get; set; }
        public decimal IMin { get; set; }
        public bool BInHoli { get; set; }
        public string SYearRest { get; set; }
        public decimal IMax { get; set; }
        public bool BCheck { get; set; }
        public string SDcode { get; set; }
        public string SSex { get; set; }
        public decimal IAbsUint { get; set; }
        public bool BDisplayForm { get; set; }
        public bool BCalOt { get; set; }
        public bool BMang { get; set; }
        public int ISort { get; set; }
        public bool BNotDel { get; set; }
        public string SHnameE { get; set; }
    }
}
