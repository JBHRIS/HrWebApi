using System;
using System.Collections.Generic;

namespace JBAppService.Api.Dal.Models.JBContent
{
    public partial class SYS_REFVAL
    {
        public string REFVAL_NO { get; set; }
        public string DESCRIPTION { get; set; }
        public string TABLE_NAME { get; set; }
        public string CAPTION { get; set; }
        public string DISPLAY_MEMBER { get; set; }
        public string SELECT_ALIAS { get; set; }
        public string SELECT_COMMAND { get; set; }
        public string VALUE_MEMBER { get; set; }
    }
}
