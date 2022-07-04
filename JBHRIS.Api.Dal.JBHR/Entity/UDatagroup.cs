using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class UDatagroup
    {
        public string UserId { get; set; }
        public string Company { get; set; }
        public string Datagroup { get; set; }
        public bool Readrule { get; set; }
        public bool Writerule { get; set; }
        public string Note { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }

        public virtual CompDatagroup CompDatagroup { get; set; }
        public virtual Comp CompanyNavigation { get; set; }
        public virtual Datagroup DatagroupNavigation { get; set; }
        public virtual UUsercomp UUsercomp { get; set; }
    }
}
