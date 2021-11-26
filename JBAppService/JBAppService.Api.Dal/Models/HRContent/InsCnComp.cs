using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class InsCnComp
    {
        public InsCnComp()
        {
            InslabCn = new HashSet<InslabCn>();
        }

        public string CompCode { get; set; }
        public string CompId { get; set; }
        public string CompName { get; set; }
        public string IdNo { get; set; }
        public string Tel { get; set; }
        public string ChairMan { get; set; }
        public string Address { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }

        public virtual ICollection<InslabCn> InslabCn { get; set; }
    }
}
