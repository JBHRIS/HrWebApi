using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto
{
    public class wfAppAbscDto
    {

        public wfAppAbscDto()
        {

        }

        public int iAutoKey { get; set; }

        public string sFormCode { get; set; }

        public int sProcessID { get; set; }

        public int idProcess { get; set; }


        public string sNobr { get; set; }

        public string sName { get; set; }

        public string sDept { get; set; }

        public string sDeptName { get; set; }

        public string sJob { get; set; }

        public string sJobName { get; set; }

        public string sRole { get; set; }

        public DateTime dDateTime { get; set; }

        public DateTime dDate { get; set; }

        public string sTime { get; set; }
    }
}
