using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class NotifyMsgTriggerDto
    {
        public string JbSystemEventCode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string ProgramName { get; set; }
        public List<string> FilePathList { get; set; }
    }
}
