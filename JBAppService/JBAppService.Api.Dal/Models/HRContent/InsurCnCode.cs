using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class InsurCnCode
    {
        public InsurCnCode()
        {
            InsCnCodeTts = new HashSet<InsCnCodeTts>();
            InslabCn = new HashSet<InslabCn>();
        }

        public string InsurCnCode1 { get; set; }
        public string InsurCnName { get; set; }
        public string SalCode { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public int BaseDate { get; set; }
        public bool RefBaseSalary { get; set; }
        public int Decimals { get; set; }
        public bool NoneCityFree { get; set; }
        public string WorkCd { get; set; }
        public string InsCnType { get; set; }

        public virtual ICollection<InsCnCodeTts> InsCnCodeTts { get; set; }
        public virtual ICollection<InslabCn> InslabCn { get; set; }
    }
}
