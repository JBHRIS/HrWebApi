using System;
using System.Collections.Generic;

namespace JBHRIS.Api.Dal.JBHR
{
    public partial class NotifyClass
    {
        public string Code { get; set; }
        public string Comp { get; set; }
        public string DisplayName { get; set; }
        public string AssemblyName { get; set; }
        public string ClassName { get; set; }
        public string Memo { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public int Sort { get; set; }
        public DateTime KeyDate { get; set; }
        public string KeyMan { get; set; }
        public int Notifyday { get; set; }
        public string Relationapp { get; set; }
    }
}
