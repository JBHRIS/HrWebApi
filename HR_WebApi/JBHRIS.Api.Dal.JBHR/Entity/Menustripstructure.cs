using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class Menustripstructure
    {
        public int Ak { get; set; }
        public Guid Menustripid { get; set; }
        public string Menustripname { get; set; }
        public string Menustriptext { get; set; }
        public Guid? Parentid { get; set; }
        public int Itemindex { get; set; }
        public bool Commonitem { get; set; }
        public string Shortcutkeys { get; set; }
        public bool Enable { get; set; }
        public string Assemblyname { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public Guid? Menugroupid { get; set; }
    }
}
