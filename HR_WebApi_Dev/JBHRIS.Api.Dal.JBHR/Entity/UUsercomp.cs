using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class UUsercomp
    {
        public UUsercomp()
        {
            UDatagroup = new HashSet<UDatagroup>();
        }

        public string UserId { get; set; }
        public string Company { get; set; }
        public string Note { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }

        public virtual Comp CompanyNavigation { get; set; }
        public virtual ICollection<UDatagroup> UDatagroup { get; set; }
    }
}
