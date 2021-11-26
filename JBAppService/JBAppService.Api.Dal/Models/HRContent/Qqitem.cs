using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class Qqitem
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string TypeCode { get; set; }
        public int? McqId { get; set; }
        public bool? McqDisplayHorizontal { get; set; }
        public bool? IsRequired { get; set; }
        public int? MinCharCount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
