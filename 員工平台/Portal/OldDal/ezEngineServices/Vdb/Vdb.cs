using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data.Linq;

namespace ezEngineServices
{
    /// <summary>
    /// 訊息分類列舉
    /// </summary>
    public enum MsgType { Error, Cancel, Warning, Msg };

    /// <summary>
    /// 角色工號
    /// </summary>
    public class CMan
    {
        /// <summary>
        /// 角色
        /// </summary>
        public string idRole = "";
        /// <summary>
        /// 工號
        /// </summary>
        public string idEmp = "";
    }

    /// <summary>
    /// Role
    /// </summary>
    public class RoleRow
    {
        /// <summary>
        /// RoleId
        /// </summary>
        public string RoleId { set; get; }
        /// <summary>
        /// RoleName
        /// </summary>
        public string RoleName { set; get; }
        /// <summary>
        /// EmpId
        /// </summary>
        public string EmpId { set; get; }
        /// <summary>
        /// EmpName
        /// </summary>
        public string EmpName { set; get; }
        /// <summary>
        /// DeptId
        /// </summary>
        public string DeptId { set; get; }
        /// <summary>
        /// DeptName
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// PosId
        /// </summary>
        public string PosId { set; get; }
        /// <summary>
        /// PosName
        /// </summary>
        public string PosName { set; get; }
        /// <summary>
        /// 是否主管
        /// </summary>
        public bool Manage { set; get; }
    }

    /// <summary>
    /// 取得流程相關資訊結構
    /// </summary>
    public class ProcessDataRow
    {
        /// <summary>
        /// 流程序號
        /// </summary>
        public int idProcess { set; get; }
        /// <summary>
        /// 表單流程主鍵
        /// </summary>
        public string FlowTreeId { set; get; }
        /// <summary>
        /// 起單日期
        /// </summary>
        public DateTime ProcessDate { set; get; }
        /// <summary>
        /// 起單角色
        /// </summary>
        public string ProcessRoleId { set; get; }
        /// <summary>
        /// 起單工號
        /// </summary>
        public string ProcessEmpId { set; get; }
        /// <summary>
        /// 起單姓名
        /// </summary>
        public string ProcessEmpName { set; get; }
        /// <summary>
        /// 表單名稱
        /// </summary>
        public string FlowTreeName { set; get; }
        /// <summary>
        /// 表單名稱
        /// </summary>
        public string FlowAppName { set; get; }
        /// <summary>
        /// 目前ProcessNodeAuto
        /// </summary>
        public int ProcessNodeAuto { set; get; }
        /// <summary>
        /// 目前ProcessCheckAuto
        /// </summary>
        public int ProcessCheckAuto { set; get; }
        /// <summary>
        /// 目前ProcessApParmAuto
        /// </summary>
        public int ProcessApParmAuto { set; get; }
        /// <summary>
        /// 目前ProcessApViewAuto
        /// </summary>
        public int ProcessApViewAuto { set; get; }
        /// <summary>
        /// 目前預定簽核者
        /// </summary>
        public string Emp_idDefault { set; get; }
        /// <summary>
        /// 目前代理簽核者
        /// </summary>
        public string Emp_idAgent { set; get; }
        /// <summary>
        /// 目前實際簽核者
        /// </summary>
        public string Emp_idReal { set; get; }
        /// <summary>
        /// 目前預定簽核者姓名
        /// </summary>
        public string Emp_NameDefault { set; get; }
        /// <summary>
        /// 目前代理簽核者姓名
        /// </summary>
        public string Emp_NameAgent { set; get; }
        /// <summary>
        /// 目前實際簽核者
        /// </summary>
        public string Emp_NameReal { set; get; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime DateTimeA { set; get; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime DateTimeD { set; get; }
        /// <summary>
        /// 是否結束
        /// </summary>
        public bool ProcessFinish { set; get; }
        /// <summary>
        /// 停留日期
        /// </summary>
        public int PendingDay { set; get; }
        /// <summary>
        /// 開始節點名單
        /// </summary>
        public string ProcessNodeFormName { set; get; }
        /// <summary>
        /// 開始節點圖案
        /// </summary>
        public Bitmap ProcessNodeFormImg { set; get; }
        /// <summary>
        /// 結束節點名稱
        /// </summary>
        public string ProcessNodeFlowEndName { set; get; }
        /// <summary>
        /// 結束節點圖案
        /// </summary>
        public Bitmap ProcessNodeFlowEndImg { set; get; }
        /// <summary>
        /// 每一關簽核節點
        /// </summary>
        public List<ProcessSignRow> lsProcessSignRow { set; get; }
    }

    /// <summary>
    /// 每一關的簽核節點
    /// </summary>
    public class ProcessSignRow
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string ProcessNodeId { set; get; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string ProcessNodeName { set; get; }
        /// <summary>
        /// 類型 EX表單申請、主管審核
        /// </summary>
        public string ProcessNodeType { set; get; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime ProcessNodeDate { set; get; }
        /// <summary>
        /// 是否結束
        /// </summary>
        public bool ProcessNodeFinish { set; get; }
        /// <summary>
        /// 是否會簽
        /// </summary>
        public bool ProcessNodeMulti { set; get; }
        /// <summary>
        /// 圖案
        /// </summary>
        public Bitmap ProcessNodeImg { set; get; }
        /// <summary>
        /// 預設簽核者
        /// </summary>
        public string Emp_idDefault { set; get; }
        /// <summary>
        /// 代理簽核者
        /// </summary>
        public string Emp_idAgent { set; get; }
        /// <summary>
        /// 實際簽核者
        /// </summary>
        public string Emp_idReal { set; get; }
        /// <summary>
        /// 預設簽核者姓名
        /// </summary>
        public string Emp_NameDefault { set; get; }
        /// <summary>
        /// 代理簽核者姓名
        /// </summary>
        public string Emp_NameAgent { set; get; }
        /// <summary>
        /// 實際簽核者姓名
        /// </summary>
        public string Emp_NameReal { set; get; }
        /// <summary>
        /// 簽核日期
        /// </summary>
        public DateTime ProcessCheckDate { set; get; }
        /// <summary>
        /// 會簽流程
        /// </summary>
        public List<ProcessDataRow> lsProcessDataRow { set; get; }
    }

    /// <summary>
    /// 可申請流程構購
    /// </summary>
    public class FlowTreeDataRow
    {
        /// <summary>
        /// 表單編號
        /// </summary>
        public string FlowTreeId { set; get; }
        /// <summary>
        /// 表單名稱
        /// </summary>
        public string FlowTreeName { set; get; }
        /// <summary>
        /// 角色代碼
        /// </summary>
        public string RoleId { set; get; }
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptId { set; get; }
        /// <summary>
        /// 職稱代碼
        /// </summary>
        public string PosId { set; get; }
        /// <summary>
        /// 是否管理職
        /// </summary>
        public bool Manage { set; get; }
        /// <summary>
        /// 申請網址
        /// </summary>
        public string Url { set; get; }
        /// <summary>
        /// 帶入參數
        /// </summary>
        public string Parm { set; get; }
        /// <summary>
        /// 完整網址加參數
        /// </summary>
        public string ViewUrl { set; get; }
        /// <summary>
        /// 顯示圖案
        /// </summary>
        public byte[] ViewImage { set; get; }
        /// <summary>
        /// 順序
        /// </summary>
        public int Sort { set; get; }
    }

    /// <summary>
    /// 流程審核結構
    /// </summary>
    public class FlowSignRow
    {
        /// <summary>
        /// 內容網址
        /// </summary>
        public string ParmUrl { set; get; }
        /// <summary>
        /// 檢查表序號
        /// </summary>
        public int ApParmID { set; get; }
        /// <summary>
        /// 流程序
        /// </summary>
        public int ProcessID { set; get; }
        /// <summary>
        /// ProcessNodeAuto
        /// </summary>
        public int ProcessNodeAuto { set; get; }
        /// <summary>
        /// ProcessCheckAuto
        /// </summary>
        public int ProcessCheckAuto { set; get; }
        /// <summary>
        /// 申請人
        /// </summary>
        public string AppName { set; get; }
        /// <summary>
        /// 申請人部門
        /// </summary>
        public string AppDept { set; get; }
        /// <summary>
        /// 申請人部門路徑
        /// </summary>
        public string AppDeptPath { set; get; }
        /// <summary>
        /// 申請時間
        /// </summary>
        public DateTime AppDate { set; get; }
        /// <summary>
        /// 流程名稱
        /// </summary>
        public string FlowTreeName { set; get; }
        /// <summary>
        /// 處理方式
        /// </summary>
        public string FlowNodeName { set; get; }
        /// <summary>
        /// 審核者
        /// </summary>
        public string CheckName { set; get; }
        /// <summary>
        /// 代理人
        /// </summary>
        public string AgentName { set; get; }
        /// <summary>
        /// 審時時間
        /// </summary>
        public DateTime CheckDate { set; get; }
        /// <summary>
        /// 子流程
        /// </summary>
        public bool Multi { set; get; }
        /// <summary>
        /// 節點簽結
        /// </summary>
        public bool NodeFinish { set; get; }
        /// <summary>
        /// 停留天數
        /// </summary>
        public int PendingDay { get; set; }
        /// <summary>
        /// 表單資訊
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 請假假別或加班類別
        /// </summary>
        public string InfoType { get; set; }
        /// <summary>
        /// 開始日期時間
        /// </summary>
        public string InfoFrom { get; set; }
        /// <summary>
        /// 結束日期時間
        /// </summary>
        public string InfoTo { get; set; }
        /// <summary>
        /// 使用時數或天數
        /// </summary>
        public string InfoUse { get; set; }
        /// <summary>
        /// 關卡類別
        /// </summary>
        public string NodeType { get; set; }
        /// <summary>
        /// 節點代碼
        /// </summary>
        public string FlowNodeId { get; set; }
        /// <summary>
        /// FlowTreeId
        /// </summary>
        public string FlowTreeId { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        public string AppRoleId { get; set; }
        /// <summary>
        /// EmpId
        /// </summary>
        public string AppEmpId { get; set; }
        /// <summary>
        /// 允許批次簽核
        /// </summary>
        public bool Batch { get; set; }
        /// <summary>
        /// 子流程編號
        /// </summary>
        public string SubProcessIds { get; set; }

    }

    /// <summary>
    /// 流程查詢進行中結構
    /// </summary>
    public class FlowSearchIngRow
    {
        /// <summary>
        /// 內容網址
        /// </summary>
        public string ViewUrl { set; get; }
        /// <summary>
        /// 檢查表序號
        /// </summary>
        public int ApViewID { set; get; }
        /// <summary>
        /// 流程序
        /// </summary>
        public int ProcessID { set; get; }
        /// <summary>
        /// 流程名稱
        /// </summary>
        public string FormName { set; get; }
        /// <summary>
        /// 處理進度
        /// </summary>
        public string FlowNodeName { set; get; }
        /// <summary>
        /// 申請時間
        /// </summary>
        public DateTime AppDate { set; get; }
        /// <summary>
        /// 送審時間
        /// </summary>
        public DateTime SignDate { set; get; }
        /// <summary>
        /// 處理者姓名
        /// </summary>
        public string SignName { set; get; }
        /// <summary>
        /// 代處理者姓名
        /// </summary>
        public string AgentName { set; get; }
        /// <summary>
        /// FlowTreeId
        /// </summary>
        public string FlowTreeId { get; set; }
    }

    /// <summary>
    /// 流程查詢完成結構
    /// </summary>
    public class FlowSearchCompleteRow
    {
        /// <summary>
        /// 內容網址
        /// </summary>
        public string ViewUrl { set; get; }
        /// <summary>
        /// 檢查表序號
        /// </summary>
        public int ApViewID { set; get; }
        /// <summary>
        /// 流程序
        /// </summary>
        public int ProcessID { set; get; }
        /// <summary>
        /// 流程名稱
        /// </summary>
        public string FormName { set; get; }
        /// <summary>
        /// 申請時間
        /// </summary>
        public DateTime AppDate { set; get; }
        /// <summary>
        /// FlowTreeId
        /// </summary>
        public string FlowTreeId { get; set; }
    }

    /// <summary>
    /// 流程檢視
    /// </summary>
    public class FlowViewRow
    {
        /// <summary>
        /// ProcessID
        /// </summary>
        public int ProcessID { get; set; }
        /// <summary>
        /// 表單名稱
        /// </summary>
        public string FormName { get; set; }
        /// <summary>
        /// 申請人工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 申請人姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 簽核主管
        /// </summary>
        public string ManageName { get; set; }
        /// <summary>
        /// 代理簽核主管
        /// </summary>
        public string AgentManageName { get; set; }
        /// <summary>
        /// 實際簽核主管
        /// </summary>
        public string RealManageName { get; set; }
        /// <summary>
        /// 簽核日期
        /// </summary>
        public DateTime SignDate { get; set; }
        /// <summary>
        /// 停留天數
        /// </summary>
        public int PendingDay { get; set; }
        /// <summary>
        /// 資訊
        /// </summary>
        public string Info { get; set; }
        /// <summary>
        /// 內容網址
        /// </summary>
        public string ViewUrl { set; get; }
    }

    /// <summary>
    /// 起點重送與上點重送列舉
    /// </summary>
    public enum FlowResubmitType { Start, WorkFinish };

    /// <summary>
    /// 流程重送結構
    /// </summary>
    public class FlowResubmitRow
    {
        /// <summary>
        /// 流程編號
        /// </summary>
        public int idProcess { get; set; }
        /// <summary>
        /// 表單流程主鍵
        /// </summary>
        public string idFlowTree { get; set; }
        /// <summary>
        /// 起單角色
        /// </summary>
        public string idRole_Start { get; set; }
        /// <summary>
        /// 起單姓名
        /// </summary>
        public string idEmp_Start { get; set; }
        /// <summary>
        /// ApParmAuto
        /// </summary>
        public int ApParmAuto { get; set; }
        /// <summary>
        /// 重送方式
        /// </summary>
        public FlowResubmitType Type { get; set; }
    }

    /// <summary>
    /// 流程狀態列舉 ex核椎、駁回、作廢、刪除、抽單
    /// </summary>
    public enum FlowState { Approve, Reject, Cancel, Delete, Take };

    /// <summary>
    /// 服務類型
    /// </summary>
    public enum WebServiceType { asmx, svc };

    /// <summary>
    /// 服務內容結構
    /// </summary>
    public class WebServiceRow
    {
        /// <summary>
        /// 服務頁面asmx svc
        /// </summary>
        public WebServiceType Type { set; get; }
        /// <summary>
        /// 流程編號
        /// </summary>
        public int idProcess { set; get; }
        /// <summary>
        /// ProcessApViewAuto
        /// </summary>
        public int ProcessApViewAuto { set; get; }
        /// <summary>
        /// 服務網址
        /// </summary>
        public string ServiceUrl { set; get; }
        /// <summary>
        /// Namespace
        /// </summary>
        public string Namespace { set; get; }
        /// <summary>
        /// ClassName
        /// </summary>
        public string ClassName { set; get; }
        /// <summary>
        /// 方法名稱 run
        /// </summary>
        public string MethodName { set; get; }
    }

    /// <summary>
    /// 流程目前位置結構
    /// </summary>
    public class FlowTreePathRow
    {
        /// <summary>
        /// FlowTreeId
        /// </summary>
        public string FlowTreeId { set; get; }
        /// <summary>
        /// 目錄
        /// </summary>
        public string FlowTreePath { set; get; }
        /// <summary>
        /// 檢視檔案
        /// </summary>
        public string ViewApName { set; get; }
    }

    /// <summary>
    /// 應用程式檔案名稱
    /// </summary>
    public class FlowNodeApNameRow
    {
        /// <summary>
        /// FlowNodeId
        /// </summary>
        public string FlowNodeId { set; get; }
        /// <summary>
        /// 檔案
        /// </summary>
        public string ApName { set; get; }
    }

    /// <summary>
    /// 簽核代理人資訊
    /// </summary>
    public class CheckAgentDataRow
    {
        /// <summary>
        /// Guid
        /// </summary>
        public string Guid { set; get; }
        /// <summary>
        /// 被代理人部門
        /// </summary>
        public string Dept_nameSource { set; get; }
        /// <summary>
        /// 被代理人職稱
        /// </summary>
        public string Pos_nameSource { set; get; }
        /// <summary>
        /// 代理人工號
        /// </summary>
        public string Emp_idTarget { set; get; }
        /// <summary>
        /// 代理人姓名
        /// </summary>
        public string Emp_nameTarget { set; get; }
        /// <summary>
        /// 代理人部門
        /// </summary>
        public string Dept_nameTarget { set; get; }
        /// <summary>
        /// 代理人職稱
        /// </summary>
        public string Pos_nameTarget { set; get; }
        /// <summary>
        /// 代理表單
        /// </summary>
        public string Form { set; get; }
        /// <summary>
        /// 順位
        /// </summary>
        public int Sort { set; get; }
        /// <summary>
        /// 登錄者
        /// </summary>
        public string KeyMan { set; get; }
        /// <summary>
        /// 登錄日期
        /// </summary>
        public DateTime KeyDate { set; get; }
    }

    /// <summary>
    /// 可代理表單
    /// </summary>
    public class CheckAgentFlowTreeDataRow
    {
        /// <summary>
        /// auto
        /// </summary>
        public int auto { set; get; }
        /// <summary>
        /// FlowTree_id
        /// </summary>
        public string FlowTree_id { set; get; }
        /// <summary>
        /// 表單名稱
        /// </summary>
        public string FormName { set; get; }
        /// <summary>
        /// 登錄者
        /// </summary>
        public string KeyMan { set; get; }
        /// <summary>
        /// 登錄日期
        /// </summary>
        public DateTime KeyDate { set; get; }
    }

    /// <summary>
    /// 代理開始與結束時間
    /// </summary>
    public class EmpAgentDateDataRow
    {
        /// <summary>
        /// auto
        /// </summary>
        public int auto { set; get; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime dateB { set; get; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime dateE { set; get; }
        /// <summary>
        /// 登錄者
        /// </summary>
        public string KeyMan { set; get; }
        /// <summary>
        /// 登錄日期
        /// </summary>
        public DateTime KeyDate { set; get; }
    }

    public class NoticeRow
    {
        /// <summary>
        /// Guid
        /// </summary>
        public string Guid { set; get; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { set; get; }
        /// <summary>
        /// Content
        /// </summary>
        public string Content { set; get; }
        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime DateA { set; get; }
        /// <summary>
        /// 失效日
        /// </summary>
        public DateTime DateD { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { set; get; }
        /// <summary>
        /// 登錄者
        /// </summary>
        public string KeyMan { set; get; }
        /// <summary>
        /// 登錄日期
        /// </summary>
        public DateTime KeyDate { set; get; }
        /// <summary>
        /// 附檔
        /// </summary>
        public List<FileRow> Files { set; get; }
    }

    /// <summary>
    /// 檔案
    /// </summary>
    public class FileRow
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { set; get; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 大小
        /// </summary>
        public int Size { set; get; }
        /// <summary>
        /// 型態
        /// </summary>
        public string Type { set; get; }
        /// <summary>
        /// 說明
        /// </summary>
        public string Desc { set; get; }
        /// <summary>
        /// 實體檔案
        /// </summary>
        public Binary File { set; get; }
    }
}