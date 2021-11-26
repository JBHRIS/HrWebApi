using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;
using static JBHRIS.Api.Dto.FlowMainInte.Vdb.MultiEnum;

namespace JBHRIS.Api.Dal.Interface
{
    public interface IFlowMainIntegrationHandler_Interface
    {

        /// <summary>
        /// 取得目前待審核的表單
        /// </summary>
        /// <param name="SignEmpID">審核者工號</param>
        /// <param name="SignRoleID">審核者角色</param>
        /// <param name="RealSignEmpID">代理審核者工號</param>
        /// <param name="RealSignRoleID">代理審核者角色</param>
        /// <param name="FlowTreeID">表單ID</param>
        /// <param name="SignDate">審核日期</param>
        /// <returns>List FlowSignRoleRow</returns>

        List<FlowSignRoleRow> GetFlowSignRole(string SignEmpID, string SignRoleID = "",
                string RealSignEmpID = "", string RealSignRoleID = "", string FlowTreeID = "", string SignDate = "");

        /// <summary>
        /// 取得目前待審核的表單-請假
        /// </summary>
        /// <param name="RealSignEmpID">代理審核者工號</param>
        /// <param name="RealSignRoleID">代理審核者角色</param>
        /// <param name="SignDate">審核日期</param>
        /// <returns>List FlowSignAbsRow</returns>

        List<FlowSignAbsRow> GetFlowSignAbs(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "");

        /// <summary>
        /// 取得目前待審核的表單-銷假
        /// </summary>
        /// <param name="RealSignEmpID">代理審核者工號</param>
        /// <param name="RealSignRoleID">代理審核者角色</param>
        /// <param name="SignDate">審核日期</param>
        /// <returns>List FlowSignAbscRow</returns>

        List<FlowSignAbscRow> GetFlowSignAbsc(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "");
        List<FlowSignAbsRow> GetFlowSignAbs1(string signEmpID, string signRoleID, string realSignEmpID, string realSignRoleID, string signDate);

        /// <summary>
        /// 取得目前待審核的表單-忘刷
        /// </summary>
        /// <param name="RealSignEmpID">代理審核者工號</param>
        /// <param name="RealSignRoleID">代理審核者角色</param>
        /// <param name="SignDate">審核日期</param>
        /// <returns>List FlowSignCardRow</returns>

        List<FlowSignCardRow> GetFlowSignCard(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "");

        /// <summary>
        /// 取得目前待審核的表單-補卡
        /// </summary>
        /// <param name="RealSignEmpID">代理審核者工號</param>
        /// <param name="RealSignRoleID">代理審核者角色</param>
        /// <param name="SignDate">審核日期</param>
        /// <returns>List FlowSignCardRow</returns>

        List<FlowSignCardRow> GetFlowSignCardPatch(string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "");

        /// <summary>
        /// 取得目前待審核的表單-補卡
        /// </summary>
        /// <param name="RealSignEmpID">代理審核者工號</param>
        /// <param name="RealSignRoleID">代理審核者角色</param>
        /// <param name="SignDate">審核日期</param>
        /// <returns>List FlowSignCardRow</returns>

        List<FlowSignAttendUnusualRow> GetFlowSignAttendUnusual(string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "");

        /// <summary>
        /// 取得目前待審核的表單-調班
        /// </summary>
        /// <param name="RealSignEmpID">代理審核者工號</param>
        /// <param name="RealSignRoleID">代理審核者角色</param>
        /// <param name="SignDate">審核日期</param>
        /// <returns>List FlowSignShiftRoteRow</returns>

        List<FlowSignShiftRoteRow> GetFlowSignShiftRote(string SignEmpID, string SignRoleID, string RealSignEmpID = "", string RealSignRoleID = "", string SignDate = "");

        /// <summary>
        /// 流程檢視
        /// </summary>
        /// <param name="ListEmpID">管理者或被查詢者工號</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <returns>List FlowViewRow</returns>

        List<FlowViewRow> GetFlowView(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0");

        /// <summary>
        /// 流程檢視(請假)
        /// </summary>
        /// <param name="ListEmpID">管理者或被查詢者工號</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewRow</returns>

        List<FlowViewAbsRow> GetFlowViewAbs(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false);

        /// <summary>
        /// 流程檢視(請假)-部門
        /// </summary>
        /// <param name="DeptaID">部門代碼</param>
        /// <param name="ChildDept">是否向下</param>
        /// <param name="PageCurrent">頁面</param>
        /// <param name="PageRows">筆數</param>
        /// <param name="EffectDate">生效日</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewAbsRow</returns>

        List<FlowViewAbsRow> GetFlowViewAbsByDept(int DeptaID = 0, bool ChildDept = false
            , int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false);

        /// <summary>
        /// 流程檢視(銷假)
        /// </summary>
        /// <param name="ListEmpID">管理者或被查詢者工號</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewRow</returns>

        List<FlowViewAbscRow> GetFlowViewAbsc(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false);

        /// <summary>
        /// 流程檢視(銷假)-部門
        /// </summary>
        /// <param name="DeptaID">部門代碼</param>
        /// <param name="ChildDept">是否向下</param>
        /// <param name="PageCurrent">頁面</param>
        /// <param name="PageRows">筆數</param>
        /// <param name="EffectDate">生效日</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewAbscRow</returns>

        List<FlowViewAbscRow> GetFlowViewAbscByDept(int DeptaID = 0, bool ChildDept = false
            , int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false);


        /// <summary>
        /// 流程檢視(忘刷)
        /// </summary>
        /// <param name="ListEmpID">管理者或被查詢者工號</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewRow</returns>

        List<FlowViewCardRow> GetFlowViewCard(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false);

        /// <summary>
        /// 流程檢視(補卡)
        /// </summary>
        /// <param name="ListEmpID">管理者或被查詢者工號</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewRow</returns>

        List<FlowViewCardRow> GetFlowViewCardPatch(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false);

        /// <summary>
        /// 流程檢視(忘刷)-部門
        /// </summary>
        /// <param name="DeptaID">部門代碼</param>
        /// <param name="ChildDept">是否向下</param>
        /// <param name="PageCurrent">頁面</param>
        /// <param name="PageRows">筆數</param>
        /// <param name="EffectDate">生效日</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewAbscRow</returns>

        List<FlowViewCardRow> GetFlowViewCardByDept(string DeptaID = "", bool ChildDept = false
            , int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false);

        /// <summary>
        /// 流程檢視(補卡)-部門
        /// </summary>
        /// <param name="DeptaID">部門代碼</param>
        /// <param name="ChildDept">是否向下</param>
        /// <param name="PageCurrent">頁面</param>
        /// <param name="PageRows">筆數</param>
        /// <param name="EffectDate">生效日</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewAbscRow</returns>

        List<FlowViewCardRow> GetFlowViewCardPatchByDept(int DeptaID = 0, bool ChildDept = false
            , int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false);

        /// <summary>
        /// 流程檢視(補卡)
        /// </summary>
        /// <param name="ListEmpID">管理者或被查詢者工號</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewRow</returns>

        List<FlowViewAttendUnusualRow> GetFlowViewAttendUnusual(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false);
        /// <summary>
        /// 流程檢視(補卡)-部門
        /// </summary>
        /// <param name="DeptaID">部門代碼</param>
        /// <param name="ChildDept">是否向下</param>
        /// <param name="PageCurrent">頁面</param>
        /// <param name="PageRows">筆數</param>
        /// <param name="EffectDate">生效日</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewAbscRow</returns>

        List<FlowViewAttendUnusualRow> GetFlowViewAttendUnusualByDept(int DeptaID = 0, bool ChildDept = false
            , int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false);
        /// <summary>
        /// 流程檢視(調班)
        /// </summary>
        /// <param name="ListEmpID">管理者或被查詢者工號</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewRow</returns>

        List<FlowViewShiftRoteRow> GetFlowViewShiftRote(List<string> ListEmpID, string DateB, string DateE, string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false);

        /// <summary>
        /// 流程檢視(調班)-部門
        /// </summary>
        /// <param name="DeptaID">部門代碼</param>
        /// <param name="ChildDept">是否向下</param>
        /// <param name="PageCurrent">頁面</param>
        /// <param name="PageRows">筆數</param>
        /// <param name="EffectDate">生效日</param>
        /// <param name="DateB">簽核開始日期</param>
        /// <param name="DateE">簽核結束日期</param>
        /// <param name="FormCode">查詢表單代碼</param>
        /// <param name="State">狀態</param>
        /// <param name="ProcessFlowID">流程序號</param>
        /// <param name="Cond1">條件1</param>
        /// <param name="Cond2">條件2</param>
        /// <param name="Cond3">絛件3</param>
        /// <param name="Handle">經手</param>
        /// <returns>List FlowViewShiftRoteRow</returns>

        List<FlowViewShiftRoteRow> GetFlowViewShiftRoteByDept(int DeptaID = 0, bool ChildDept = false
            , int PageCurrent = 1, int PageRows = 100, string EffectDate = "", string DateB = "", string DateE = "", string FormCode = "0",
            string State = "0", int ProcessFlowID = 0, string Cond1 = "0", string Cond2 = "0", string Cond3 = "0", bool Handle = false);

        /// <summary>
        /// 節點審核
        /// </summary>
        /// <param name="idProcess">NodeFinish</param>
        /// <param name="State"></param>
        /// <param name="DynamicEmpID"></param>
        /// <param name="DynamicRoleID"></param>
        /// <param name="SignEmpID"></param>
        /// <param name="SignRoleID"></param>
        /// <returns>bool</returns>

        bool FlowNodeFinishByFlowID(int idProcess, string State = "", string DynamicEmpID = "", string DynamicRoleID = "",
            string SignEmpID = "", string SignRoleID = "");

        /// <summary>
        /// 流程狀態設定
        /// </summary>
        /// <param name="ListProcessFlowID"></param>
        /// <param name="enumState">狀態(Approve,Reject,Cancel,Delete,Take)</param>
        /// <param name="EmpID">動作人工號</param>
        /// <param name="SignEmpID">轉呈人工號</param>
        /// <returns>FlowStateRow</returns>

        FlowStateRow SetFlowState(List<int> ListProcessFlowID, FlowState enumState, string EmpID = "", string SignEmpID = "");

        /// <summary>
        /// 存入資料
        /// </summary>
        /// <param name="processFlowID">idProcess</param>

        void SaveDataByProcessID(int processFlowID);

        /// <summary>
        /// 最後一關呼叫服務
        /// </summary>
        /// <param name="ProcessFlowID">ProcessFlowID</param>
        /// <returns>bool</returns>

        bool RunServiceByProcessID(int ProcessFlowID);

        /// <summary>
        /// 節點審核
        /// </summary>
        /// <param name="NodeFinish">NodeFinish</param>
        /// <returns>FlowNodeFinishRow</returns>

        ActionResultRow FlowNodeFinish(NodeFinishRow NodeFinish);

        /// <summary>
        /// 批次節點審核
        /// </summary>
        /// <param name="ListNodeFinish">ListNodeFinish</param>
        /// <returns>int</returns>

        int ListFlowNodeFinish(List<NodeFinishRow> ListNodeFinish);


        /// <summary>
        /// 取得目前待審核的表單-加班單
        /// </summary>
        /// <param name="RealSignEmpID"></param>
        /// <param name="RealSignRoleID"></param>
        /// <param name="SignDate"></param>
        /// <param name="PageCurrent"></param>
        /// <param name="PageRows"></param>
        /// <returns></returns>
        FlowSignOTDetail GetFlowSignOT(string SignEmpID, string SignRoleID, string RealSignEmpID, string RealSignRoleID, string SignDate, int PageCurrent, int PageRows);

        /// <summary>
        /// 取得目前待審核的表單-預估加班單
        /// </summary>
        /// <param name="SignEmpID"></param>
        /// <param name="SignRoleID"></param>
        /// <param name="RealSignEmpID"></param>
        /// <param name="RealSignRoleID"></param>
        /// <param name="SignDate"></param>
        /// <param name="PageCurrent"></param>
        /// <param name="PageRows"></param>
        /// <returns></returns>
        FlowSignOTDetail GetFlowSignOT1(string SignEmpID, string SignRoleID, string RealSignEmpID, string RealSignRoleID, string SignDate, int PageCurrent, int PageRows);



        /// <summary>
        /// 
        /// </summary>
        /// <param name="SignEmpID"></param>
        /// <param name="FlowTreeID"></param>
        /// <param name="SignRoleID"></param>
        /// <param name="RealSignEmpID"></param>
        /// <param name="RealSignRoleID"></param>
        /// <param name="SignDate"></param>
        /// <returns></returns>
        List<FlowSignRoleRow> GetFlowSignRoleFullDataByNow(string SignEmpID, List<string> FlowTreeID, string SignRoleID, string RealSignEmpID, string RealSignRoleID, string SignDate);
    }
}
