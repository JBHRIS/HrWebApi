using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Flow.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class MainVdb
    {
        /// <summary>
        /// 表單申請樹資料
        /// </summary>
        public List<FormTreeTable> FormTreeData { set; get; }
        /// <summary>
        /// 流程審核資料
        /// </summary>
        public List<FlowSignTable> FlowSignData { set; get; }
        /// <summary>
        /// 流程查詢進行中資料
        /// </summary>
        public List<FlowSearchIngTable> FlowSearchIngData { set; get; }
        /// <summary>
        /// 流程查詢完成資料
        /// </summary>
        public List<FlowSearchCompleteTable> FlowSearchCompleteData { set; get; }
    }

    /// <summary>
    /// 表單申請樹
    /// </summary>
    public class FormTreeTable
    {
        /// <summary>
        /// 節點ID
        /// </summary>
        public string NodeID { set; get; }
        /// <summary>
        /// 上層節點ID
        /// </summary>
        public string ParentNodeID { set; get; }
        /// <summary>
        /// 顯示文字
        /// </summary>
        public string Text { set; get; }
        /// <summary>
        /// 值
        /// </summary>
        public string Value { set; get; }
        /// <summary>
        /// 網址
        /// </summary>
        public string NavigateUrl { set; get; }
        /// <summary>
        /// 結構路徑
        /// </summary>
        public string Path { set; get; }
    }

    /// <summary>
    /// 流程審核結構
    /// </summary>
    public class FlowSignTable
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
        /// 流程名稱
        /// </summary>
        public string FormName { set; get; }
        /// <summary>
        /// 處理方式
        /// </summary>
        public string FlowProgress { set; get; }
        /// <summary>
        /// 審核者
        /// </summary>
        public string CheckName { set; get; }
        /// <summary>
        /// 代理人
        /// </summary>
        public string AgentName { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string AgentState { set; get; }
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
        /// 允許批次簽核
        /// </summary>
        public bool Batch { get; set; }
    }

    /// <summary>
    /// 流程審核結構曾經審核過的
    /// </summary>
    public class FlowSignCompleteTable
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
        /// 申請時間
        /// </summary>
        public DateTime AppDate { set; get; }
        /// <summary>
        /// 流程名稱
        /// </summary>
        public string FormName { set; get; }
        /// <summary>
        /// 處理方式
        /// </summary>
        public string FlowProgress { set; get; }
        /// <summary>
        /// 代理人
        /// </summary>
        public string AgentName { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string AgentState { set; get; }
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
    }

    /// <summary>
    /// 表單資訊結構
    /// </summary>
    public class FormInfo
    {
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
        /// 使用時數或天數加單位
        /// </summary>
        public string InfoUse { get; set; }
    }

    /// <summary>
    /// 流程查詢進行中結構
    /// </summary>
    public class FlowSearchIngTable
    {
        /// <summary>
        /// 內容網址
        /// </summary>
        public string ViewUrl { set; get; }
        /// <summary>
        /// 流程圖網址
        /// </summary>
        public string HistoryUrl { set; get; }
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
        public string FlowProgress { set; get; }
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
    }

    /// <summary>
    /// 流程查詢完成結構
    /// </summary>
    public class FlowSearchCompleteTable
    {
        /// <summary>
        /// 內容網址
        /// </summary>
        public string ViewUrl { set; get; }
        /// <summary>
        /// 流程圖網址
        /// </summary>
        public string HistoryUrl { set; get; }
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
    }

    /// <summary>
    /// 員工角色
    /// </summary>
    public class RolesTable
    {
        /// <summary>
        /// 角色代碼
        /// </summary>
        public string RoleID { set; get; }
        /// <summary>
        /// 角色名稱
        /// </summary>
        public string RoleName { set; get; }
        /// <summary>
        /// 部門代碼
        /// </summary>
        public string DeptID { set; get; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// 職稱代碼
        /// </summary>
        public string PosID { set; get; }
        /// <summary>
        /// 職稱名稱
        /// </summary>
        public string PosName { set; get; }
        /// <summary>
        /// 是否主管
        /// </summary>
        public bool Manage { set; get; }
    }

    /// <summary>
    /// 代理人資料表
    /// </summary>
    public class CheckAgentDefaultTable
    {
        /// <summary>
        /// 來源工號
        /// </summary>
        public string SourceNobr { set; get; }
        /// <summary>
        /// 來源姓名
        /// </summary>
        public string SourceName { set; get; }
        /// <summary>
        /// 來源角色
        /// </summary>
        public string SourceRole { set; get; }
        /// <summary>
        /// 代理開始日期
        /// </summary>
        public DateTime DateA { set; get; }
        /// <summary>
        /// 代理結束日期
        /// </summary>
        public DateTime DateD { set; get; }
        /// <summary>
        /// 代理人1工號
        /// </summary>
        public string TargetNobr1 { set; get; }
        /// <summary>
        /// 代理人1姓名
        /// </summary>
        public string TargetName1 { set; get; }
        /// <summary>
        /// 代理人1角色
        /// </summary>
        public string TargetRole1 { set; get; }
        /// <summary>
        /// 代理人2工號
        /// </summary>
        public string TargetNobr2 { set; get; }
        /// <summary>
        /// 代理人2姓名
        /// </summary>
        public string TargetName2 { set; get; }
        /// <summary>
        /// 代理人2角色
        /// </summary>
        public string TargetRole2 { set; get; }
        /// <summary>
        /// 代理人3工號
        /// </summary>
        public string TargetNobr3 { set; get; }
        /// <summary>
        /// 代理人3姓名
        /// </summary>
        public string TargetName3 { set; get; }
        /// <summary>
        /// 代理人3角色
        /// </summary>
        public string TargetRole3 { set; get; }
    }
}