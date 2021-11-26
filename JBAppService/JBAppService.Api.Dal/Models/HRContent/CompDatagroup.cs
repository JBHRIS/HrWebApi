using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class CompDatagroup
    {
        public CompDatagroup()
        {
            UDatagroup = new HashSet<UDatagroup>();
        }

        public string Comp { get; set; }
        public string Datagroup { get; set; }
        public string Note { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }

        public virtual Comp CompNavigation { get; set; }
        public virtual Datagroup DatagroupNavigation { get; set; }
        public virtual ICollection<UDatagroup> UDatagroup { get; set; }
    }
}
