using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Comp
    {
        public Comp()
        {
            CompDatagroup = new HashSet<CompDatagroup>();
            UDatagroup = new HashSet<UDatagroup>();
            UUsercomp = new HashSet<UUsercomp>();
        }

        public string Comp1 { get; set; }
        public string Compname { get; set; }
        public string Chairman { get; set; }
        public string Compid { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Addr { get; set; }
        public string Houseid { get; set; }
        public string KeyMan { get; set; }
        public DateTime KeyDate { get; set; }
        public string F0103 { get; set; }
        public string F0407 { get; set; }
        public string Workcd { get; set; }
        public string Taxid { get; set; }
        public string Account { get; set; }
        public string Accr { get; set; }
        public bool Defa { get; set; }
        public string Inscomp { get; set; }
        public string Compename { get; set; }
        public int Sort { get; set; }
        public bool Dblcnt { get; set; }
        public Guid? Menugroupid { get; set; }
        public Guid? Userdefinegroupid { get; set; }

        public virtual ICollection<CompDatagroup> CompDatagroup { get; set; }
        public virtual ICollection<UDatagroup> UDatagroup { get; set; }
        public virtual ICollection<UUsercomp> UUsercomp { get; set; }
    }
}
