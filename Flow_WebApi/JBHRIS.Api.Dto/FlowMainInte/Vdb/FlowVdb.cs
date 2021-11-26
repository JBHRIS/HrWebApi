using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.FlowMainInte.Vdb
{

    /// <summary>
    /// FlowVdb
    /// </summary>
    public class FlowVdb
    {
    }


    /// <summary>
    /// 代理人資訊主檔
    /// </summary>
    public class CheckAgentMainRow : ManInfoRow
    {
        /// <summary>
        /// 角色id
        /// </summary>
        public string RoleIdSource { get; set; }
        /// <summary>
        /// 角色名稱
        /// </summary>
        public string RoleNameSource { get; set; }
        /// <summary>
        /// 工號id
        /// </summary>
        public string EmpIdSource { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string EmpNameSource { get; set; }
        /// <summary>
        /// 代理人角色id
        /// </summary>
        public string RoleIdTarget { get; set; }
        /// <summary>
        /// 代理人角色名稱
        /// </summary>
        public string RoleNameTarget { get; set; }
        /// <summary>
        /// 代理人工號id
        /// </summary>
        public string EmpIdTarget { get; set; }
        /// <summary>
        /// 代理人姓名
        /// </summary>
        public string EmpNameTarget { get; set; }
        /// <summary>
        /// 代理人姓名
        /// </summary>
        public DateTime DateB { get; set; }
        /// <summary>
        /// 代理人姓名
        /// </summary>
        public DateTime DateE { get; set; }
        /// <summary>
        /// 是否生效
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        public string KeyMan { get; set; }
        /// <summary>
        /// 修改姓名
        /// </summary>
        public DateTime KeyDate { get; set; }
    }

    /// <summary>
    /// 簽核代人資訊
    /// </summary>
    public class CheckAgentRow : CheckAgentMainRow
    {
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { get; set; }
        /// <summary>
        /// 主鍵
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 可代理部門
        /// </summary>
        public List<CheckAgentDeptRow> CheckAgentDept { get; set; }
        /// <summary>
        /// 可代理表單
        /// </summary>
        public List<CheckAgentFlowTreeRow> CheckAgentFlowTree { get; set; }
        /// <summary>
        /// 代理區間
        /// </summary>
        public List<EmpAgentDateRow> EmpAgentDate { get; set; }
    }

    /// <summary>
    /// 代理日期
    /// </summary>
    public class EmpAgentDateRow
    {
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime DateB { set; get; }
        /// <summary>
        /// 失效日
        /// </summary>
        public DateTime DateE { set; get; }
        /// <summary>
        /// 修改者
        /// </summary>
        public string KeyMan { get; set; }
        /// <summary>
        /// 修改姓名
        /// </summary>
        public DateTime KeyDate { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get; set; }
    }

    /// <summary>
    /// 代理部門
    /// </summary>
    public class CheckAgentDeptRow
    {
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { get; set; }
        /// <summary>
        /// 主鍵
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 代理部門代碼
        /// </summary>
        public string DeptID { get; set; }
        /// <summary>
        /// 代理部門名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 子部門全部代理
        /// </summary>
        public bool IsAllSub { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        public string KeyMan { get; set; }
        /// <summary>
        /// 修改姓名
        /// </summary>
        public DateTime KeyDate { get; set; }
    }

    /// <summary>
    /// 代理流程
    /// </summary>
    public class CheckAgentFlowTreeRow
    {
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { get; set; }
        /// <summary>
        /// 主鍵
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 表單流程代碼
        /// </summary>
        public string FlowTreeID { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        public string KeyMan { get; set; }
        /// <summary>
        /// 修改姓名
        /// </summary>
        public DateTime KeyDate { get; set; }

    }

    /// <summary>
    /// 動態簽核者
    /// </summary>
    public class FlowDynamicRow
    {
        /// <summary>
        /// FlowNode
        /// </summary>
        public string FlowNode { set; get; }
        /// <summary>
        /// RoleID
        /// </summary>
        public string RoleID { set; get; }
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// DeptID
        /// </summary>
        public string DeptID { set; get; }
        /// <summary>
        /// PosID
        /// </summary>
        public string PosID { set; get; }
    }

    /// <summary>
    /// 表單主檔資訊
    /// </summary>
    public class FlowAppRow
    {
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpCode { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string EmpNameC { get; set; }
        /// <summary>
        /// 起單狀態(如果需要直接不經核准直接存入傳3)
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Cond1
        /// </summary>
        public string Cond1 { get; set; }
        /// <summary>
        /// Cond2
        /// </summary>
        public string Cond2 { get; set; }
        /// <summary>
        /// Cond3
        /// </summary>
        public string Cond3 { get; set; }
        /// <summary>
        /// Cond4
        /// </summary>
        public string Cond4 { get; set; }
        /// <summary>
        /// Cond5
        /// </summary>
        public string Cond5 { get; set; }
        /// <summary>
        /// Cond6
        /// </summary>
        public string Cond6 { get; set; }

    }

    /// <summary>
    /// 角色分類
    /// </summary>
    public class FlowSignRoleRow
    {
        /// <summary>
        /// 筆數
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 筆數
        /// </summary>
        public bool BatchSign { get; set; }
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public string PosName { get; set; }
        public string RoleID { get; set; }
        public int Sort { get; set; }
        public bool MainMan { get; set; }
        /// <summary>
        /// 表單分類
        /// </summary>
        public List<FlowSignFormRow> FlowSignForm { get; set; }
        public ManInfoRow maninfo { get; set; }
    }

    /// <summary>
    /// 表單分類
    /// </summary>
    public class FlowSignFormRow : FormInfoRow
    {
        /// <summary>
        /// 筆數
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 表單分類內容
        /// </summary>
        public List<FlowSignRow> FlowSign { get; set; }
    }

    /// <summary>
    /// 流程審核資料
    /// </summary>
    public class FlowSignRow : FormAppRow
    {
        /// <summary>
        /// 檢查表序號
        /// </summary>
        public int ProcessApParmAuto { set; get; }
        /// <summary>
        /// ProcessNodeAuto
        /// </summary>
        public int ProcessNodeAuto { set; get; }
        /// <summary>
        /// ProcessCheckAuto
        /// </summary>
        public int ProcessCheckAuto { set; get; }
        /// <summary>
        /// 申請人角色ID
        /// </summary>
        public string AppRoleID { set; get; }
        /// <summary>
        /// 申請人ID
        /// </summary>
        public string AppEmpID { set; get; }
        /// <summary>
        /// 申請人
        /// </summary>
        public string AppEmpName { set; get; }
        /// <summary>
        /// 申請人部門
        /// </summary>
        public string AppDeptID { set; get; }
        /// <summary>
        /// 申請人部門
        /// </summary>
        public string AppDeptName { set; get; }
        /// <summary>
        /// 申請人部門路徑
        /// </summary>
        public string AppDeptPath { set; get; }
        /// <summary>
        /// 申請時間
        /// </summary>
        public DateTime AppDate { set; get; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime? AppDateD { set; get; }
        /// <summary>
        /// 表單編號
        /// </summary>
        public string FlowTreeID { set; get; }
        /// <summary>
        /// 表單代碼
        /// </summary>
        public string FormCode { set; get; }

        /// <summary>
        /// 表單名稱
        /// </summary>
        public string FormName { set; get; }
        /// <summary>
        /// 節點代碼
        /// </summary>
        public string FlowNodeID { set; get; }
        /// <summary>
        /// 處理方式
        /// </summary>
        public string FlowNodeName { set; get; }
        /// <summary>
        /// 審核者角色ID
        /// </summary>
        public string CheckRoleID { set; get; }
        /// <summary>
        /// 審核者ID
        /// </summary>
        public string CheckEmpID { set; get; }
        /// <summary>
        /// 停留天數
        /// </summary>
        public int PendingDay { get; set; }
        /// <summary>
        /// 允許批次簽核
        /// </summary>
        public bool Batch { get; set; }
        /// <summary>
        /// 簽核條件內容
        /// </summary>
        public SignConditionRow SignCondition { get; set; }
        /// <summary>
        /// ChiefCode
        /// </summary>
        public string ChiefCode { set; get; }
        /// <summary>
        /// 實際申請人ID
        /// </summary>
        public string RealAppEmpID { set; get; }
    }

    /// <summary>
    /// 請假簽核資料(外框是總筆數)
    /// </summary>
    public class FlowSignAbsDataRow
    {
        /// <summary>
        /// 資料頁面顯示
        /// </summary>
        public PageCategory Page { set; get; }
        /// <summary>
        /// FlowSignAbs
        /// </summary>
        public List<FlowSignAbsRow> ListFlowSignAbs { set; get; }
    }
    /// <summary>
    /// 請假簽核資料
    /// </summary>
    public class FlowSignAbsRow
    {
        /// <summary>
        /// ProcessFlowID
        /// </summary>
        public int ProcessFlowID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string FlowTreeID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string FlowNodeID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int ProcessApParmAuto { set; get; }
        /// <summary>
        /// 被填寫人
        /// </summary>
        public string EmpCode { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string EmpNameC { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string EmpNameE { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> HolidayName { set; get; }
        /// <summary>
        /// 核准
        /// </summary>
        public bool isApproved { set; get; }
        /// <summary>
        /// 退回
        /// </summary>
        public bool isSendback { set; get; }
        /// <summary>
        /// 呈核
        /// </summary>
        public bool isPutForward { set; get; }
        /// <summary>
        /// 填單人工號
        /// </summary>
        public string WriteEmpCode { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string WriteEmpNameC { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateB { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateE { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public decimal day { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public decimal hour { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public decimal minute { set; get; }
        /// <summary>
        /// 表單有幾筆資料
        /// </summary>
        public int numberOfVaData { set; get; }
        /// <summary>
        /// 是否代填
        /// </summary>
        public bool checkProxy { set; get; }
        /// <summary>
        /// 是否預排
        /// </summary>
        public bool Appointment { set; get; }
    }

    /// <summary>
    /// 銷假單簽核資料(外框是總筆數)
    /// </summary>
    public class FlowSignAbscDataRow
    {
        /// <summary>
        /// 資料頁面顯示
        /// </summary>
        public PageCategory Page { set; get; }
        /// <summary>
        /// FlowSignAbs
        /// </summary>
        public List<FlowSignAbscRow> ListFlowSignAbsc { set; get; }
    }

    /// <summary>
    /// 銷假簽核資料
    /// </summary>
    public class FlowSignAbscRow
    {
        /// <summary>
        /// ProcessFlowID
        /// </summary>
        public int ProcessFlowID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string FlowTreeID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string FlowNodeID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int ProcessApParmAuto { set; get; }
        /// <summary>
        /// 被填寫人
        /// </summary>
        public string EmpCode { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string EmpNameC { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string EmpNameE { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> HolidayName { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 核准
        /// </summary>
        public bool isApproved { set; get; }
        /// <summary>
        /// 退回
        /// </summary>
        public bool isSendback { set; get; }
        /// <summary>
        /// 呈核
        /// </summary>
        public bool isPutForward { set; get; }
        /// <summary>
        /// 填單人工號
        /// </summary>
        public string WriteEmpCode { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string WriteEmpNameC { set; get; }
        /// <summary>
        /// 銷假日期
        /// </summary>
        public List<string> dateArray { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public decimal day { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public decimal hour { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public decimal minute { set; get; }
        /// <summary>
        /// 表單有幾筆資料
        /// </summary>
        public int numberOfVaData { set; get; }
        /// <summary>
        /// 是否代填
        /// </summary>
        public bool checkProxy { set; get; }
    }

    /// <summary>
    /// 忘刷簽核資料
    /// </summary>
    public class FlowSignCardRow
    {
        /// <summary>
        /// ProcessFlowID
        /// </summary>
        public int ProcessFlowID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string FlowTreeID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string FlowNodeID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int ProcessApParmAuto { set; get; }
        /// <summary>
        /// 被填寫人
        /// </summary>
        public string EmpCode { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string EmpNameC { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string EmpNameE { set; get; }
        /// <summary>
        /// 核准
        /// </summary>
        public bool isApproved { set; get; }
        /// <summary>
        /// 退回
        /// </summary>
        public bool isSendback { set; get; }
        /// <summary>
        /// 呈核
        /// </summary>
        public bool isPutForward { set; get; }
        /// <summary>
        /// 填單人工號
        /// </summary>
        public string WriteEmpCode { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string WriteEmpNameC { set; get; }
        /// <summary>
        /// 是否代填
        /// </summary>
        public bool checkProxy { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string ExceptionalName { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string RoteCode { set; get; }
    }

    /// <summary>
    /// 忘刷簽核資料
    /// </summary>
    public class FlowSignAttendUnusualRow
    {
        /// <summary>
        /// ProcessFlowID
        /// </summary>
        public int ProcessFlowID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string FlowTreeID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string FlowNodeID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int ProcessApParmAuto { set; get; }
        /// <summary>
        /// 被填寫人
        /// </summary>
        public string EmpCode { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string EmpNameC { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string EmpNameE { set; get; }
        /// <summary>
        /// 核准
        /// </summary>
        public bool isApproved { set; get; }
        /// <summary>
        /// 退回
        /// </summary>
        public bool isSendback { set; get; }
        /// <summary>
        /// 呈核
        /// </summary>
        public bool isPutForward { set; get; }
        /// <summary>
        /// 填單人工號
        /// </summary>
        public string WriteEmpCode { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string WriteEmpNameC { set; get; }
        /// <summary>
        /// 是否代填
        /// </summary>
        public bool checkProxy { set; get; }
        /// <summary>
        /// 異常代碼(用逗號分開)
        /// </summary>
        public string ExceptionalCode { set; get; }
        /// <summary>
        /// 異常名稱(用逗號分開)
        /// </summary>
        public string ExceptionalName { set; get; }
        /// <summary>
        /// 已被消除異常代碼(用逗號分開)
        /// </summary>
        public string ExceptionalCancelCode { set; get; }
        /// <summary>
        /// 已被消除異常名稱(用逗號分開)
        /// </summary>
        public string ExceptionalCancelName { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string RoteCode { set; get; }
        /// <summary>
        /// 遲到註記
        /// </summary>
        public bool EliminateLate { set; get; }
        /// <summary>
        /// 早退註記
        /// </summary>
        public bool EliminateEarly { set; get; }
        /// <summary>
        /// 早來註記
        /// </summary>
        public bool EliminateOnBefore { set; get; }
        /// <summary>
        /// 晚走註記
        /// </summary>
        public bool EliminateOffAfter { set; get; }
        /// <summary>
        /// 未刷卡註記
        /// </summary>
        public bool EliminateAbsent { set; get; }
    }

    /// <summary>
    /// 調班簽核資料
    /// </summary>
    public class FlowSignShiftRoteRow
    {
        /// <summary>
        /// ProcessFlowID
        /// </summary>
        public int ProcessFlowID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string FlowTreeID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string FlowNodeID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int ProcessApParmAuto { set; get; }
        /// <summary>
        /// 被填寫人
        /// </summary>
        public string EmpID1 { set; get; }
        /// <summary>
        /// 被填寫人
        /// </summary>
        public string EmpCode1 { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string EmpNameC1 { set; get; }
        /// <summary>
        /// 被填寫人
        /// </summary>
        public string EmpID2 { set; get; }
        /// <summary>
        /// 被填寫人
        /// </summary>
        public string EmpCode2 { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string EmpNameC2 { set; get; }
        /// <summary>
        /// 核准
        /// </summary>
        public bool isApproved { set; get; }
        /// <summary>
        /// 退回
        /// </summary>
        public bool isSendback { set; get; }
        /// <summary>
        /// 呈核
        /// </summary>
        public bool isPutForward { set; get; }
        /// <summary>
        /// 填單人工號
        /// </summary>
        public string WriteEmpCode { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string WriteEmpNameC { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public bool isDR { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public bool isRR { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public bool isRZ { set; get; }
        /// <summary>
        /// 銷假日期
        /// </summary>
        public List<string> dateArray { set; get; }
        /// <summary>
        /// 表單有幾筆資料
        /// </summary>
        public int numberOfVaData { set; get; }
        /// <summary>
        /// 是否代填
        /// </summary>
        public bool checkProxy { set; get; }
    }

    /// <summary>
    /// FlowNodeRow
    /// </summary>
    public class FlowNodeRow
    {
        /// <summary>
        /// FlowTreeID
        /// </summary>
        public string FlowTreeID { set; get; }
        /// <summary>
        /// FlowNodeID
        /// </summary>
        public string FlowNodeID { set; get; }
        /// <summary>
        /// FlowNodeName
        /// </summary>
        public string FlowNodeName { set; get; }
        /// <summary>
        /// 允許批次簽核
        /// </summary>
        public bool Batch { get; set; }
    }

    /// <summary>
    /// 流程檢視
    /// </summary>
    public class FlowViewRow
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// 流程序
        /// </summary>
        public int ProcessFlowID { set; get; }
        /// <summary>
        /// 表單名稱
        /// </summary>
        public string FormName { get; set; }
        /// <summary>
        /// 申請人ID
        /// </summary>
        public string AppEmpID { set; get; }
        /// <summary>
        /// 申請人
        /// </summary>
        public string AppEmpName { set; get; }
        /// <summary>
        /// 申請人部門
        /// </summary>
        public string AppDeptName { set; get; }
        /// <summary>
        /// 簽核主管
        /// </summary>
        public string ManageEmpName { get; set; }
        /// <summary>
        /// 實際簽核主管
        /// </summary>
        public string RealManageEmpName { get; set; }
        /// <summary>
        /// 簽核日期
        /// </summary>
        //public DateTime SignDate { get; set; }
        /// <summary>
        /// 停留天數
        /// </summary>
        //public int PendingDay { get; set; }
        /// <summary>
        /// 資訊
        /// </summary>
        //public string Info { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 處理中
        /// </summary>
        public bool Handle { get; set; }
        /// <summary>
        /// 抽單
        /// </summary>
        public bool Take { get; set; }
        /// <summary>
        /// 轉呈
        /// </summary>
        public bool TransSign { get; set; }
        ///// <summary>
        ///// AbsFlowApps
        ///// </summary>
        //public List<AbsFlowAppsExtendRow> AbsFlowApps { get; set; }
        ///// <summary>
        ///// AbscFlowApps
        ///// </summary>
        //public List<AbscFlowAppsExtendRow> AbscFlowApps { get; set; }
        ///// <summary>
        ///// CardFlowApps
        ///// </summary>
        //public List<CardFlowAppsExtendRow> CardFlowApps { get; set; }
        ///// <summary>
        ///// ShiftRoteFlowApps
        ///// </summary>
        //public List<ShiftRoteFlowAppsExtendRow> ShiftRoteFlowApps { get; set; }
    }

    /// <summary>
    /// 流程檢視(請假)
    /// </summary>
    public class FlowViewAbsRow : FlowViewRow
    {
        /// <summary>
        /// 被申請人ID
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 被申請人
        /// </summary>
        public string EmpName { set; get; }
        /// <summary>
        /// 被申請人部門
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// 申請日期
        /// </summary>
        public DateTime DateTimeB { set; get; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime DateTimeE { set; get; }
        /// <summary>
        /// 使用
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 拆分
        /// </summary>
        public DayHourMinuteRow UseDayHourMinute { set; get; }
        /// <summary>
        /// 基底時數
        /// </summary>
        public decimal BaseHour { set; get; }
        /// <summary>
        /// 當日請假
        /// </summary>
        public bool Today { set; get; }
        /// <summary>
        /// 幾筆請假
        /// </summary>
        public int AbsCount { set; get; }
        /// <summary>
        /// 舊系統的key
        /// </summary>
        public string OldKey { set; get; }
        /// <summary>
        /// 是否預排
        /// </summary>
        public bool Appointment { set; get; }
        /// <summary>
        /// 使用假別
        /// </summary>
        public List<string> ListHoliDayNameC { set; get; }
    }

    /// <summary>
    /// 流程檢視(銷假)
    /// </summary>
    public class FlowViewAbscRow : FlowViewRow
    {
        /// <summary>
        /// 被申請人ID
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 被申請人
        /// </summary>
        public string EmpName { set; get; }
        /// <summary>
        /// 被申請人部門
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// 申請日期
        /// </summary>
        public List<FlowViewAbscDateRow> FlowViewAbscDate { set; get; }
        /// <summary>
        /// 總使用
        /// </summary>
        public decimal Use { set; get; }
        /// <summary>
        /// 拆分
        /// </summary>
        public DayHourMinuteRow UseDayHourMinute { set; get; }
        /// <summary>
        /// 基底時數
        /// </summary>
        public decimal BaseHour { set; get; }
        /// <summary>
        /// 幾筆銷假
        /// </summary>
        public int AbscCount { set; get; }
    }

    /// <summary>
    /// 銷假申請日期時間及使用
    /// </summary>
    public class FlowViewAbscDateRow
    {
        /// <summary>
        /// 申請日期
        /// </summary>
        public DateTime DateTimeB { set; get; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime DateTimeE { set; get; }
        /// <summary>
        /// 使用
        /// </summary>
        public decimal Use { set; get; }
    }

    /// <summary>
    /// 流程檢視(忘刷)
    /// </summary>
    public class FlowViewCardRow : FlowViewRow
    {
        /// <summary>
        /// 被申請人ID
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 被申請人
        /// </summary>
        public string EmpName { set; get; }
        /// <summary>
        /// 被申請人部門
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// 歸屬日期
        /// </summary>
        public DateTime Date { set; get; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime? DateB { set; get; }
        /// <summary>
        /// 開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 開始日期時間
        /// </summary>
        public DateTime? DateTimeB { set; get; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime? DateE { set; get; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 結束日期時間
        /// </summary>
        public DateTime? DateTimeE { set; get; }
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string RoteNameC { set; get; }
        /// <summary>
        /// 異常狀態
        /// </summary>
        public string ErrorState { set; get; }
    }

    /// <summary>
    /// 流程檢視(考勤異常確認單)
    /// </summary>
    public class FlowViewAttendUnusualRow : FlowViewRow
    {
        /// <summary>
        /// 被申請人ID
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 被申請人
        /// </summary>
        public string EmpName { set; get; }
        /// <summary>
        /// 被申請人部門
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// 歸屬日期
        /// </summary>
        public DateTime Date { set; get; }
        /// <summary>
        /// 遲到註記
        /// </summary>
        public bool EliminateLate { set; get; }
        /// <summary>
        /// 早退註記
        /// </summary>
        public bool EliminateEarly { set; get; }
        /// <summary>
        /// 早來註記
        /// </summary>
        public bool EliminateOnBefore { set; get; }
        /// <summary>
        /// 晚走註記
        /// </summary>
        public bool EliminateOffAfter { set; get; }
        /// <summary>
        /// 未刷卡註記
        /// </summary>
        public bool EliminateAbsent { set; get; }
        /// <summary>
        /// 班別名稱
        /// </summary>
        public string RoteNameC { set; get; }
        /// <summary>
        /// 異常狀態
        /// </summary>
        public string ErrorState { set; get; }
    }

    /// <summary>
    /// 流程檢視(忘刷)
    /// </summary>
    public class FlowViewShiftRoteRow : FlowViewRow
    {
        /// <summary>
        /// 被申請人ID1
        /// </summary>
        public string EmpID1 { set; get; }
        /// <summary>
        /// 被申請人1
        /// </summary>
        public string EmpName1 { set; get; }
        /// <summary>
        /// 被申請人部門1
        /// </summary>
        public string DeptName1 { set; get; }
        /// <summary>
        /// 被申請人ID2
        /// </summary>
        public string EmpID2 { set; get; }
        /// <summary>
        /// 被申請人2
        /// </summary>
        public string EmpName2 { set; get; }
        /// <summary>
        /// 被申請人部門2
        /// </summary>
        public string DeptName2 { set; get; }
        /// <summary>
        /// 申請日期
        /// </summary>
        public List<FlowViewShiftRoteDateRow> FlowViewShiftRoteDate { set; get; }
        /// <summary>
        /// 調班類別
        /// </summary>
        public string ShiftRoteName { set; get; }
        /// <summary>
        /// 幾筆銷假
        /// </summary>
        public int ShiftRoteCount { set; get; }
    }

    /// <summary>
    /// 銷假申請日期時間及使用
    /// </summary>
    public class FlowViewShiftRoteDateRow
    {
        /// <summary>
        /// 申請日期
        /// </summary>
        public DateTime ShiftRoteDate { set; get; }
        /// <summary>
        /// 班別id1
        /// </summary>
        public int RoteID1 { set; get; }
        /// <summary>
        /// 班別代碼1
        /// </summary>
        public string RoteCode1 { set; get; }
        /// <summary>
        /// 班別名稱1
        /// </summary>
        public string RoteName1 { set; get; }
        /// <summary>
        /// 班別id2
        /// </summary>
        public int RoteID2 { set; get; }
        /// <summary>
        /// 班別代碼2
        /// </summary>
        public string RoteCode2 { set; get; }
        /// <summary>
        /// 班別名稱2
        /// </summary>
        public string RoteName2 { set; get; }
    }

    /// <summary>
    /// 表單申請資訊
    /// </summary>
    public class FormAppRow
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProcessFlowID { get; set; }
        /// <summary>
        /// 表單資訊
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 審核條件1
        /// </summary>
        public string Cond1 { get; set; }
        /// <summary>
        /// 審核條件2
        /// </summary>
        public string Cond2 { get; set; }
        /// <summary>
        /// 審核條件3
        /// </summary>
        public string Cond3 { get; set; }
        /// <summary>
        /// 審核條件4
        /// </summary>
        public string Cond4 { get; set; }
        /// <summary>
        /// 審核條件5
        /// </summary>
        public string Cond5 { get; set; }
        /// <summary>
        /// 審核條件6
        /// </summary>
        public string Cond6 { get; set; }
    }

    /// <summary>
    /// 表單申請資訊明細
    /// </summary>
    public class FormAppInfoRow
    {
        /// <summary>
        /// ProcessFlowID
        /// </summary>
        public int ProcessFlowID { get; set; }
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// EmpName
        /// </summary>
        public string EmpName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Info { get; set; }
    }

    /// <summary>
    /// 表單資訊
    /// </summary>
    public class FormInfoRow
    {
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { set; get; }
        /// <summary>
        /// 表單代碼
        /// </summary>
        public string FormCode { set; get; }
        /// <summary>
        /// 表單名稱
        /// </summary>
        public string FormName { set; get; }
        /// <summary>
        /// 表單代碼FlowTreeID
        /// </summary>
        public string FlowTreeID { set; get; }
        /// <summary>
        /// 申請內容
        /// </summary>
        public string StdNote { set; get; }
        /// <summary>
        /// 審核內容
        /// </summary>
        public string CheckNote { set; get; }
        /// <summary>
        /// 檢視內容
        /// </summary>
        public string ViewNote { set; get; }
        /// <summary>
        /// 其它內容
        /// </summary>
        public string EtcNote { set; get; }
        /// <summary>
        /// 動態審核節點
        /// </summary>
        public string DynamicNode { set; get; }
        /// <summary>
        /// 系統人員節點
        /// </summary>
        public string CustomNode { set; get; }
        /// <summary>
        /// 主要資料表
        /// </summary>
        public string TableName { set; get; }
    }

    /// <summary>
    /// 信件主檔(主要是內容資訊)
    /// </summary>
    public class FormMailRow
    {
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { set; get; }
        /// <summary>
        /// Key
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// 表單代碼
        /// </summary>
        public string FormCode { set; get; }
        /// <summary>
        /// 表單代碼
        /// </summary>
        public string FormName { set; get; }
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 主旨
        /// </summary>
        public string Subject { set; get; }
        /// <summary>
        /// 內文
        /// </summary>
        public string Body { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 修改者
        /// </summary>
        public string KeyMan { set; get; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime KeyDate { set; get; }
    }

    /// <summary>
    /// 寄信內容log
    /// </summary>
    public class SendMailLogRow
    {
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { set; get; }
        /// <summary>
        /// ProcessFlowID
        /// </summary>
        public int ProcessFlowID { get; set; }
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Key1
        /// </summary>
        public string Key1 { set; get; }
        /// <summary>
        /// Key2
        /// </summary>
        public string Key2 { set; get; }
        /// <summary>
        /// ToAddress
        /// </summary>
        public string ToAddress { set; get; }
        /// <summary>
        /// 主旨
        /// </summary>
        public string Subject { set; get; }
        /// <summary>
        /// 內文
        /// </summary>
        public string Body { set; get; }
        /// <summary>
        /// Success
        /// </summary>
        public bool Success { set; get; }
        /// <summary>
        /// 修改者
        /// </summary>
        public string KeyMan { set; get; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime KeyDate { set; get; }
    }

    /// <summary>
    /// 信件欄位
    /// </summary>
    public class FormColumnsRow
    {
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { set; get; }
        /// <summary>
        /// 表單代碼
        /// </summary>
        public string FormCode { set; get; }
        /// <summary>
        /// 欄位代碼
        /// </summary>
        public string Code { set; get; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { set; get; }
    }

    /// <summary>
    /// 角色資訊
    /// </summary>
    public class ManRow
    {
        /// <summary>
        /// 角色+工號
        /// </summary>
        public string RoleEmp { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string RoleID { get; set; }
        /// <summary>
        /// 角色名稱
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpID { get; set; }
    }

    /// <summary>
    /// 角色資訊
    /// </summary>
    public class ManInfoRow : ManRow
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string EmpName { get; set; }
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptID { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 部門路徑
        /// </summary>
        public string DeptPath { get; set; }
        /// <summary>
        /// 職稱代碼
        /// </summary>
        public string PosID { get; set; }
        /// <summary>
        /// 職稱名稱
        /// </summary>
        public string PosName { get; set; }
        /// <summary>
        /// 主管權限
        /// </summary>
        public bool Auth { get; set; }
        /// <summary>
        /// 信箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 正職
        /// </summary>
        public bool MainMan { get; set; }
        /// <summary>
        /// 主管代碼
        /// </summary>
        public string ChiefCode { get; set; }
        /// <summary>
        /// 簽核順序
        /// </summary>
        public int Sort { get; set; }
    }

    /// <summary>
    /// 審核資訊
    /// </summary>
    public class NodeFinishRow
    {
        /// <summary>
        /// ProcessFlowID
        /// </summary>
        public int ProcessFlowID { get; set; }
        /// <summary>
        /// ProcessApParmAuto
        /// </summary>
        public int ProcessApParmAuto { get; set; }
        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 表單代碼
        /// </summary>
        public string FlowTreeID { set; get; }
        /// <summary>
        /// 節點代碼
        /// </summary>
        public string FlowNodeID { set; get; }
        /// <summary>
        /// 簽核意見
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 節點名稱
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 實際審核者工號
        /// </summary>
        public string CheckEmpID { get; set; }
        /// <summary>
        /// ManInfo
        /// </summary>
        public ManInfoRow ManInfo { get; set; }
        /// <summary>
        /// FlowDynamic
        /// </summary>
        public FlowDynamicRow FlowDynamic { get; set; }
    }

    /// <summary>
    /// 簽核資訊
    /// </summary>
    public class FormSignRow
    {
        /// <summary>
        /// ProcessFlowID
        /// </summary>
        public int ProcessFlowID { get; set; }
        /// <summary>
        /// ProcessApParmAuto
        /// </summary>
        public string Key1 { get; set; }
        /// <summary>
        /// Guid
        /// </summary>
        public string Key2 { get; set; }
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpCode { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string EmpNameC { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptNameC { get; set; }
        /// <summary>
        /// 職稱名稱
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// EmpID
        /// </summary>
        public string ToEmpID { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        public string ToEmpCode { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string ToEmpNameC { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string ToDeptNameC { get; set; }
        /// <summary>
        /// 職稱名稱
        /// </summary>
        public string ToJobName { get; set; }
        /// <summary>
        /// 意見
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 節點名稱
        /// </summary>
        public string NodeName { get; set; }
        /// <summary>
        /// 簽核日期
        /// </summary>
        public DateTime SignDate { get; set; }
    }

    /// <summary>
    /// 主流程資料
    /// </summary>
    public class ProcessFlowRow
    {
        /// <summary>
        /// ProcessFlowID
        /// </summary>
        public int ProcessFlowID { get; set; }
        /// <summary>
        /// 節點id
        /// </summary>
        public string FlowTreeID { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public string RoleID { get; set; }
        /// <summary>
        /// 工號id
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 完成
        /// </summary>
        public bool IsFinish { get; set; }
        /// <summary>
        /// 錯誤
        /// </summary>
        public bool IsError { get; set; }
        /// <summary>
        /// 取消
        /// </summary>
        public bool IsCancel { get; set; }
    }

    /// <summary>
    /// 寄信內容(樣版)
    /// </summary>
    public class SendMailContentRow
    {
        /// <summary>
        /// 主旨
        /// </summary>
        public string SubjectTemp { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public string BodyTemp { get; set; }
        /// <summary>
        /// 主旨
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 寄件對象
        /// </summary>
        public List<SendMailTargetRow> SendMailTarget { get; set; }
    }

    /// <summary>
    /// 寄件對象
    /// </summary>
    public class SendMailTargetRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpID { get; set; }
    }

    /// <summary>
    /// 流程狀態
    /// </summary>
    public class FlowStateRow : MessageRow
    {
        /// <summary>
        /// 完成流程
        /// </summary>
        public List<int> ListProcessID { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool Finish { get; set; }
    }


    public class FlowSignRowDto
    {
        public string SignEmpID { get; set; }
        public string SignRoleID { get; set; }
        public string RealSignEmpID { get; set; }
        public string RealSignRoleID { get; set; }
        public string SignDate { get; set; }
        public int PageCurrent { get; set; }
        public int PageRows { get; set; }
    }

    public class FlowViewRowDto
    {
        public List<string> ListEmpID { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string FormCode { get; set; }
        public string State { get; set; }
        public int ProcessFlowID { get; set; }
        public string Cond1 { get; set; }
        public string Cond2 { get; set; }
        public string Cond3 { get; set; }
        public bool Handle { get; set; }
    }

    public class FlowSignOTRowDto
    {
        public string SignEmpID { get; set; }
        public string SignRoleID { get; set; }
        public string RealSignEmpID { get; set; }
        public string RealSignRoleID { get; set; }
        public string SignDate { get; set; }

        public int PageCurrent { get; set; }
        public int PageRows { get; set; }
    }


    public class FlowSignOTDetail
    {
        public PageCategory Page { get; set; }

        public List<FlowSignOTRow> FlowSignOTRow { get; set; }

    }

    public class FlowSignCardDataRow
    {
        /// <summary>
        /// 資料頁面顯示
        /// </summary>
        public PageCategory Page { set; get; }
        /// <summary>
        /// FlowSignAbs
        /// </summary>
        public List<FlowSignCardRow> ListFlowSignCard { set; get; }
    }



    /// <summary>
    /// 加班單-簽核資料
    /// </summary>
    public class FlowSignOTRow
    {
        /// <summary>
        /// ProcessFlowID
        /// </summary>
        public int ProcessFlowID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string FlowTreeID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string FlowNodeID { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int ProcessApParmAuto { set; get; }
        /// <summary>
        /// 被填寫人
        /// </summary>
        public string EmpCode { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string EmpNameC { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string EmpNameE { set; get; }
        /// <summary>
        /// 表單代碼
        /// </summary>
        public string FormCode { set; get; }
        /// <summary>
        /// 核准
        /// </summary>
        public bool isApproved { set; get; }
        /// <summary>
        /// 退回
        /// </summary>
        public bool isSendback { set; get; }
        /// <summary>
        /// 呈核
        /// </summary>
        public bool isPutForward { set; get; }
        /// <summary>
        /// 填單人工號
        /// </summary>
        public string WriteEmpCode { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string WriteEmpNameC { set; get; }
        /// <summary>
        /// 加班開始時間 yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime DateTimeB { set; get; }
        /// <summary>
        /// 加班結束時間 yyyy-MM-dd HH:mm:ss
        /// </summary>
        public DateTime DateTimeE { set; get; }
        /// <summary>
        /// 加班開始時間 HHmm
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 加班結束時間 HHmm
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 拆分
        /// </summary>
        public DayHourMinuteRow UseDayHourMinute { set; get; }

        /// <summary>
        /// 加班 換 1: 加班費 , 2:補休日
        /// </summary>
        public string OtcatCode { get; set; }

        /// <summary>
        /// 加班 換 1: 加班費 , 2:補休日
        /// </summary>
        public string OtcatName { get; set; }
    }




    /// <summary>
    ///  資料頁面顯示
    /// </summary>
    public class PageCategory
    {
        /// <summary>
        /// 資料頁總比數
        /// </summary>
        public int PageTotalCount { get; set; }
        /// <summary>
        /// 顯示的資料頁碼
        /// </summary>
        public int pageCurrent { get; set; }
        /// <summary>
        /// 顯示一頁資料的比數
        /// </summary>
        public int PageRows { get; set; }
    }
}
