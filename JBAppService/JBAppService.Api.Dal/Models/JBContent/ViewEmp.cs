using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class ViewEmp
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DeptCode { get; set; }
        public string JobCode { get; set; }
        public string JoblCode { get; set; }
        public string Password { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public string Ttscode { get; set; }
        public string CompCode { get; set; }
    }
}
