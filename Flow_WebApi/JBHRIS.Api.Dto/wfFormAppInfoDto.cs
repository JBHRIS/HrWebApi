using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto
{
    public  class wfFormAppInfoDto
    {
        public wfFormAppInfoDto()
        {

        }

        public int iAutoKey { get; set; }

        public int sProcessID { get; set; }

        public int idProcess { get; set; }

        public string sNobr { get; set; }

        public string sName { get; set; }

        public bool sState { get; set; }

        public string sInfo { get; set; }

        public string sGuid { get; set; }

        public DateTime dKeyDate { get; set; }
    }
}
