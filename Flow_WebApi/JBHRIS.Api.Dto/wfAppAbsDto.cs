using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto
{
    public class wfAppAbsDto
    {

        public wfAppAbsDto()
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

        public bool sRote { get; set; }


        public DateTime dDateTimeB { get; set; }

        public DateTime dDateTimeE { get; set; }

        public DateTime dDateB { get; set; }

        public DateTime dDateE { get; set; }

        public DateTime sTimeB { get; set; }

        public DateTime sTimeE { get; set; }



    }
}
