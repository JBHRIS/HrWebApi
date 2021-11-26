using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class EffsUpfile
    {
        public int AutoKey { get; set; }
        public int? Yy { get; set; }
        public int? Seq { get; set; }
        public string Nobr { get; set; }
        public string Upfilename { get; set; }
        public string Serverfilename { get; set; }
        public string Filetype { get; set; }
        public string Filesize { get; set; }
        public DateTime? Upfiledate { get; set; }
        public string Filedesc { get; set; }
    }
}
