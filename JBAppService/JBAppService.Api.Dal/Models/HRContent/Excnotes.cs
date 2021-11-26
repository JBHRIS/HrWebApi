using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Excnotes
    {
        public int? Userid { get; set; }
        public DateTime? Attdate { get; set; }
        public string Notes { get; set; }
    }
}
