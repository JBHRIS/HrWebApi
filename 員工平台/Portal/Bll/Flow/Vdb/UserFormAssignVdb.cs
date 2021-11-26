using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class UserFormAssignVdb
    {
    }
    public class UserFormAssignConditions : DataConditions
    {
        public string SignEmpID { get; set; }
        public string SignRoleID { get; set; }
        public string RealSignEmpID { get; set; }
        public string RealSignRoleID { get; set; }
        public string FlowTreeID { get; set; }
        public string SignDate { get; set; }
    }
    public class UserFormAssignApiRow : StandardDataBaseApiRow
    {
        public class result
        {
            public int Count { get; set; }
            public bool BatchSign { get; set; }
            public List<FlowSignForm> FlowSignForm { get; set; }
            public Maninfo maninfo { get; set; }
        }
        public List<result> Result { get; set; }
    }
    public class SignCondition
    {
        public string FormCode { get; set; }
        public string AppEmpID { get; set; }
        public string CheckEmpID { get; set; }
        public string ChiefCode { get; set; }
        public int Tree { get; set; }
        public int ProcessFlowID { get; set; }
        public string Cond1 { get; set; }
        public string Cond2 { get; set; }
        public string Cond3 { get; set; }
        public string Cond4 { get; set; }
        public string Cond5 { get; set; }
        public string Cond6 { get; set; }
        public bool Sign { get; set; }
        public bool Reject { get; set; }
        public bool SignComplete { get; set; }
    }

    public class FlowSign
    {
        public int ProcessFlowID { get; set; }
        public string Info { get; set; }
        public string Cond1 { get; set; }
        public string Cond2 { get; set; }
        public string Cond3 { get; set; }
        public string Cond4 { get; set; }
        public string Cond5 { get; set; }
        public string Cond6 { get; set; }
        public int ProcessApParmAuto { get; set; }
        public int ProcessNodeAuto { get; set; }
        public int ProcessCheckAuto { get; set; }
        public string AppRoleID { get; set; }
        public string AppEmpID { get; set; }
        public string AppEmpName { get; set; }
        public string AppDeptID { get; set; }
        public string AppDeptName { get; set; }
        public string AppDeptPath { get; set; }
        public DateTime AppDate { get; set; }
        public DateTime? AppDateD { get; set; }
        public string FlowTreeID { get; set; }
        public string FormCode { get; set; }
        public string FormName { get; set; }
        public string FlowNodeID { get; set; }
        public string FlowNodeName { get; set; }
        public string CheckRoleID { get; set; }
        public string CheckEmpID { get; set; }
        public int PendingDay { get; set; }
        public bool Batch { get; set; }
        public SignCondition SignCondition { get; set; }
        public string ChiefCode { get; set; }
        public string RealAppEmpID { get; set; }
        public string Detail { get; set; }
    }

    public class FlowSignForm
    {
        public int AutoKey { get; set; }
        public string FormCode { get; set; }
        public string FormName { get; set; }
        public string FlowTreeID { get; set; }
        public string StdNote { get; set; }
        public string CheckNote { get; set; }
        public string ViewNote { get; set; }
        public string EtcNote { get; set; }
        public string DynamicNode { get; set; }
        public string CustomNode { get; set; }
        public string TableName { get; set; }
        public int Count { get; set; }
        public List<FlowSign> FlowSign { get; set; }
    }

    public class Maninfo
    {
        public string RoleEmp { get; set; }
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string DeptID { get; set; }
        public string DeptName { get; set; }
        public string DeptPath { get; set; }
        public string PosID { get; set; }
        public string PosName { get; set; }
        public bool Auth { get; set; }
        public string Email { get; set; }
        public bool MainMan { get; set; }
        public string ChiefCode { get; set; }
        public int Sort { get; set; }
    }
    public class UserFormAssignRow
    {
        public int Count { get; set; }
        public bool BatchSign { get; set; }
        public List<FlowSignForm> FlowSignForm { get; set; }
        public Maninfo maninfo { get; set; }

    }
}
