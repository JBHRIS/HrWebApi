using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto
{
    public class wfAppAbsDetailDto
    {

        public wfAppAbsDetailDto()
        {

        }


        public int iAutoKey { get; set; }

        public string sAbsKey { get; set; }

        public string sKey { get; set; }

        public DateTime dDateTimeB { get; set; }

        public DateTime dDateTimeE { get; set; }

        public DateTime dDateB { get; set; }

        public string sTimeB { get; set; }

        public string sTimeE { get; set; }

        public Decimal iUse { get; set; }

        public int iRoteID { get; set; }


    }
}
