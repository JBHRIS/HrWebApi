using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Upfile
    {
        public int Autokey { get; set; }
        public string Newsfileid { get; set; }
        public string Upfilename { get; set; }
        public string Serverfilename { get; set; }
        public string Filetype { get; set; }
        public string Filesize { get; set; }
        public DateTime Upfiledate { get; set; }
        public string Filedesc { get; set; }
        public string Uptype { get; set; }
        public string Nobr { get; set; }
        public bool? Mangcheck { get; set; }
    }
}
