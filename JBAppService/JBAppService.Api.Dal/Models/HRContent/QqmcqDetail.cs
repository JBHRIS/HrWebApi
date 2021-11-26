using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.HRContent
{
    public partial class QqmcqDetail
    {
        public int Id { get; set; }
        public int QqmcqId { get; set; }
        public int Sequence { get; set; }
        public string Text { get; set; }
        public string StringValue { get; set; }
        public int? IntValue { get; set; }
    }
}
