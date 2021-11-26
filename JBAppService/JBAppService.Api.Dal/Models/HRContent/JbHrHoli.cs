using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class JbHrHoli
    {
        public DateTime DDate { get; set; }
        public string SAttCode { get; set; }
        public bool BHoli { get; set; }
        public string SHoliCode { get; set; }
        public string SOtHcode { get; set; }
    }
}
