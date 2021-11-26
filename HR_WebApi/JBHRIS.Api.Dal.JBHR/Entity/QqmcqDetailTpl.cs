using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class QqmcqDetailTpl
    {
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public int Sequence { get; set; }
        public string Text { get; set; }
        public string StringValue { get; set; }
        public int? IntValue { get; set; }
    }
}
