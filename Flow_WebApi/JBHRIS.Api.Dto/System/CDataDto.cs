using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.System
{
    class CDataDto
    {
    }
    public class GetFlowViewUrlConditionDto
    { 
        public int idProcess { get; set; }
        public bool bOnlyUrl { get; set; }
    }
    public class GetFlowParmUrlConditionDto
    { 
        public int iApParmID { get; set; }
        public bool bOnlyUrl { get; set; }
    }
}
