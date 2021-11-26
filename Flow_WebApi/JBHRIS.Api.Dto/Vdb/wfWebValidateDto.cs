using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Vdb
{
    public class wfWebValidateDto
    {
        public int iAutoKey { get; set; }
        public string sValidateKey { get; set; }
        public DateTime dDateWriter { get; set; }
        public DateTime? dDateOpen { get; set; }
        public string sParm { get; set; }
    }
}
