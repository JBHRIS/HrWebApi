using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class JqTable
    {
        public int Id { get; set; }
        public int SettingId { get; set; }
        public string TableName { get; set; }
        public string DisplayName { get; set; }
        public string Memo { get; set; }
        public string CreateMan { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
