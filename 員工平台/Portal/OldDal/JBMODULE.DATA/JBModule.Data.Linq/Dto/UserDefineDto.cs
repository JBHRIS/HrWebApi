using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Dto
{
    public class UserDefineDto
    {
        public string NOBR { get; set; }
        public Guid ControlID { get; set; }
        public Guid? SourceID { get; set; }
        public string ValueTYPE { get; set; }
        public string Value { get; set; }
        public string Key_Man { get; set; }
        public DateTime Key_Date { get; set; }
    }
}
