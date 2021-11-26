using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class QtplCategory
    {
        public int Id { get; set; }
        public string QtplCode { get; set; }
        public string QcategoryCode { get; set; }
        public int Sequence { get; set; }
    }
}
