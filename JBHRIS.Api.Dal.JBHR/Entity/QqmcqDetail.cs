using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
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
