using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Datagroup
    {
        public Datagroup()
        {
            CompDatagroup = new HashSet<CompDatagroup>();
            UDatagroup = new HashSet<UDatagroup>();
        }

        public string Datagroup1 { get; set; }
        public string Groupname { get; set; }
        public string Note { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public string Comp { get; set; }

        public virtual ICollection<CompDatagroup> CompDatagroup { get; set; }
        public virtual ICollection<UDatagroup> UDatagroup { get; set; }
    }
}
