using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Userdefinegroup
    {
        public int Ak { get; set; }
        public Guid Userdefinegroupid { get; set; }
        public string Userdefinegroupname { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public DateTime? KeyDate { get; set; }
        public int Columncnt { get; set; }
        public int Rowcnt { get; set; }
        public int Itemswidth { get; set; }
        public int Itemsheight { get; set; }
    }
}
