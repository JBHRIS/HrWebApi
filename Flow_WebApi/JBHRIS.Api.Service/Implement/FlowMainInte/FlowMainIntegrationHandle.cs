using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.FlowMainInte;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.FlowMainInte 
{
    public class FlowMainIntegrationHandle : IFlowMainIntegrationHandleInterface
    {


        private IFlowMainIntegrationHandler_Interface _IFlowMainIntegrationHandler_Interface;

        public FlowMainIntegrationHandle(IFlowMainIntegrationHandler_Interface flowMainIntegrationHandler_Interface)
        {
            this._IFlowMainIntegrationHandler_Interface = flowMainIntegrationHandler_Interface;
        }
        public ActionResultRow FlowNodeFinish(NodeFinishRow NodeFinish)
        {
            return this._IFlowMainIntegrationHandler_Interface.FlowNodeFinish(NodeFinish);
        }

        public bool FlowNodeFinishByFlowID(int idProcess, string State = "", string DynamicEmpID = "", string DynamicRoleID = "", string SignEmpID = "", string SignRoleID = "")
        {
            return this._IFlowMainIntegrationHandler_Interface.FlowNodeFinishByFlowID( idProcess, State ,  DynamicEmpID ,  DynamicRoleID , SignEmpID ,  SignRoleID );
        }

        public List<FlowSignAbsRow> GetFlowSignAbs(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowSignAbs( SignEmpID,  SignRoleID,  RealSignEmpID ,  RealSignRoleID , SignDate );
        }

        public List<FlowSignAbsRow> GetFlowSignAbs1(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowSignAbs1( SignEmpID,  SignRoleID,  RealSignEmpID ,  RealSignRoleID ,  SignDate );
        }

        public List<FlowSignAbscRow> GetFlowSignAbsc(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowSignAbsc( SignEmpID,  SignRoleID,  RealSignEmpID ,  RealSignRoleID ,  SignDate);
        }

        public List<FlowSignAttendUnusualRow> GetFlowSignAttendUnusual(string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowSignAttendUnusual( RealSignEmpID ,  RealSignRoleID ,  SignDate );
        }

        public List<FlowSignCardRow> GetFlowSignCard(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowSignCard( SignEmpID,  SignRoleID,  RealSignEmpID ,  RealSignRoleID ,  SignDate );
        }

        public List<FlowSignCardRow> GetFlowSignCardPatch(string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowSignCardPatch( RealSignEmpID ,  RealSignRoleID ,  SignDate );
        }

        public FlowSignOTDetail GetFlowSignOT(string SignEmpID, string SignRoleID, string RealSignEmpID, string RealSignRoleID, string SignDate, int PageCurrent, int PageRows)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowSignOT( SignEmpID,  SignRoleID,  RealSignEmpID, RealSignRoleID,  SignDate,  PageCurrent,  PageRows);
        }

        public FlowSignOTDetail GetFlowSignOT1(string SignEmpID, string SignRoleID, string RealSignEmpID, string RealSignRoleID, string SignDate, int PageCurrent, int PageRows)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowSignOT1( SignEmpID,  SignRoleID,  RealSignEmpID,  RealSignRoleID,  SignDate,  PageCurrent,  PageRows);
        }

        public List<FlowSignRoleRow> GetFlowSignRole(string SignEmpID, string SignRoleID = "", string RealSignEmpID = "", string RealSignRoleID = "", string FlowTreeID = "", string SignDate = "")
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowSignRole(SignEmpID,  SignRoleID ,  RealSignEmpID ,  RealSignRoleID ,  FlowTreeID ,  SignDate );
        }

        public List<FlowSignRoleRow> GetFlowSignRoleFullDataByNow(string SignEmpID, List<string> FlowTreeID, string SignRoleID, string RealSignEmpID, string RealSignRoleID, string SignDate)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowSignRoleFullDataByNow(SignEmpID, FlowTreeID, SignRoleID, RealSignEmpID, RealSignRoleID, SignDate);
        }

        public List<FlowSignShiftRoteRow> GetFlowSignShiftRote(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "")
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowSignShiftRote(SignEmpID,  SignRoleID,  RealSignEmpID ,  RealSignRoleID , SignDate );
        }

        public List<FlowViewRow> GetFlowView(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0")
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowView(ListEmpID, DateB, DateE,  FormCode ,  State ,  ProcessFlowID ,  Cond1 , Cond2 , Cond3 );
        }

        public List<FlowViewAbsRow> GetFlowViewAbs(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowViewAbs( ListEmpID,  DateB, DateE,  FormCode ,  State,  ProcessFlowID ,  Cond1 , Cond2 , Cond3 ,  Handle );
        }

        public List<FlowViewAbsRow> GetFlowViewAbsByDept(int DeptaID = 0, bool ChildDept = false, int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowViewAbsByDept( DeptaID , ChildDept ,  PageCurrent ,  PageRows ,  EffectDate ,  DateB ,  DateE ,  FormCode , State ,  ProcessFlowID , Cond1 , Cond2 ,  Cond3 ,  Handle );
        }

        public List<FlowViewAbscRow> GetFlowViewAbsc(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowViewAbsc(ListEmpID,  DateB,  DateE,  FormCode ,  State , ProcessFlowID ,  Cond1 , Cond2 , Cond3 , Handle );
        }

        public List<FlowViewAbscRow> GetFlowViewAbscByDept(int DeptaID = 0, bool ChildDept = false, int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowViewAbscByDept(DeptaID , ChildDept , PageCurrent ,  PageRows ,  EffectDate ,  DateB ,  DateE , FormCode ,  State , ProcessFlowID ,  Cond1 , Cond2 ,  Cond3 , Handle );
        }

        public List<FlowViewAttendUnusualRow> GetFlowViewAttendUnusual(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowViewAttendUnusual( ListEmpID,  DateB,  DateE,  FormCode ,  State ,  ProcessFlowID ,  Cond1,  Cond2 , Cond3 , Handle );
        }

        public List<FlowViewAttendUnusualRow> GetFlowViewAttendUnusualByDept(int DeptaID = 0, bool ChildDept = false, int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowViewAttendUnusualByDept( DeptaID,  ChildDept ,  PageCurrent , PageRows , EffectDate ,  DateB ,  DateE ,  FormCode ,  State ,  ProcessFlowID ,  Cond1 ,  Cond2 ,  Cond3 ,  Handle );
        }

        public List<FlowViewCardRow> GetFlowViewCard(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowViewCard( ListEmpID,  DateB,  DateE,  FormCode ,  State ,  ProcessFlowID ,  Cond1 , Cond2 ,  Cond3 , Handle );
        }

        public List<FlowViewCardRow> GetFlowViewCardByDept(int DeptaID = 0, bool ChildDept = false, int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowViewCardByDept( DeptaID.ToString() ,  ChildDept ,  PageCurrent,  PageRows ,  EffectDate ,  DateB ,  DateE ,  FormCode,  State ,  ProcessFlowID ,  Cond1 ,  Cond2 , Cond3 ,  Handle );
        }

        public List<FlowViewCardRow> GetFlowViewCardPatch(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowViewCardPatch( ListEmpID,  DateB,  DateE,  FormCode ,  State ,  ProcessFlowID ,  Cond1 ,  Cond2 ,  Cond3 ,  Handle );
        }

        public List<FlowViewCardRow> GetFlowViewCardPatchByDept(int DeptaID = 0, bool ChildDept = false, int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowViewCardPatchByDept( DeptaID ,  ChildDept  ,  PageCurrent ,  PageRows,  EffectDate ,  DateB ,  DateE ,  FormCode ,  State,  ProcessFlowID ,  Cond1 ,  Cond2 ,  Cond3 ,  Handle );
        }

        public List<FlowViewShiftRoteRow> GetFlowViewShiftRote(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowViewShiftRote( ListEmpID,  DateB,  DateE,  FormCode ,  State ,  ProcessFlowID ,  Cond1 ,  Cond2,  Cond3 ,  Handle );
        }

        public List<FlowViewShiftRoteRow> GetFlowViewShiftRoteByDept(int DeptaID = 0, bool ChildDept = false, int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0", string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false)
        {
            return this._IFlowMainIntegrationHandler_Interface.GetFlowViewShiftRoteByDept( DeptaID ,  ChildDept  ,  PageCurrent ,  PageRows ,  EffectDate ,  DateB ,  DateE ,  FormCode ,  State ,  ProcessFlowID ,  Cond1 ,  Cond2 ,  Cond3 ,  Handle );
        }

        public int ListFlowNodeFinish(List<NodeFinishRow> ListNodeFinish)
        {
            return this._IFlowMainIntegrationHandler_Interface.ListFlowNodeFinish( ListNodeFinish);
        }

        public bool RunServiceByProcessID(int ProcessFlowID)
        {
            return this._IFlowMainIntegrationHandler_Interface.RunServiceByProcessID( ProcessFlowID);
        }

        public void SaveDataByProcessID(int processFlowID)
        {
            this._IFlowMainIntegrationHandler_Interface.SaveDataByProcessID(processFlowID);
        }

        public FlowStateRow SetFlowState(List<int> ListProcessFlowID, MultiEnum.FlowState enumState, string EmpID = "", string SignEmpID = "")
        {
            return this._IFlowMainIntegrationHandler_Interface.SetFlowState(ListProcessFlowID, enumState, EmpID, SignEmpID);
        }
    }
}
