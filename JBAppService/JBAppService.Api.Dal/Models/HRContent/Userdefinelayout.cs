using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Userdefinelayout
    {
        public int Ak { get; set; }
        public Guid Userdefinegroupid { get; set; }
        public Guid Controlid { get; set; }
        public string Type { get; set; }
        public int Layoutcolumn { get; set; }
        public int Layoutrow { get; set; }
        public int Columnspan { get; set; }
        public int Rowspan { get; set; }
        public string Anchor { get; set; }
        public string Dock { get; set; }
        public string Tag { get; set; }
        public bool Visible { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
    }
}
