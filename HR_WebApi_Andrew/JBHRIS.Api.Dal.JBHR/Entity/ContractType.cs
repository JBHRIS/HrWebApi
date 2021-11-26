using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class ContractType
    {
        public ContractType()
        {
            Contract = new HashSet<Contract>();
        }

        public string Code { get; set; }
        public string DisplayName { get; set; }
        public int MonthSpan { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public int AlertDefaultDays { get; set; }

        public virtual ICollection<Contract> Contract { get; set; }
    }
}
