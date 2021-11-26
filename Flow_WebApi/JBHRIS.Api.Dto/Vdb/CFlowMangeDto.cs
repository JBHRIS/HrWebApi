using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Vdb
{
    public class CFlowResubmitConditionDto
    {
        public List<int> lsProcessID { get; set; }
        public string idEmp_Agent { get; set; }
        public bool bPreviousStep { get; set; }

        public CFlowResubmitConditionDto()
        {
            bPreviousStep = false;
        }
    }
    public class CFlowSignSetConditionDto
    {
        public List<int> lsProcessID { get; set; }
        public CMan Man_Default { get; set; }
        public CMan Man_Agent { get; set; }
        public CFlowSignSetConditionDto()
        {
            Man_Default = null;
            Man_Agent = null;
        }
    }

    public class CFlowSignWorkFinishDto
    { 
        public List<int> lsProcessID { get; set; }
        public string EmpId { get; set; }
        public string Note { get; set; }
        public bool Sign { get; set; }
        public bool EmpSameUp { get; set; }
    }

    public class CFlowSignDto
    {
        public List<int> lsProcessID { get; set; }
        public string EmpId { get; set; }
    }
    public class FlowStateSet
    { 
        public List<int> lsProcessID { get; set; }
        public FlowState State { get; set; }
        public string idEmp { get; set; }
    }
}
