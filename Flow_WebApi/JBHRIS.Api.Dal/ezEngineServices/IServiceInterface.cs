using JBHRIS.Api.Dto.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezEngineServices
{
    public interface IServiceInterface
    {




        #region 記得要丟到3-1.Dto

        //public class CApParm
        //{
        //    public int ProcessFlow_id;
        //    public int ProcessNode_auto;
        //    public int ProcessCheck_auto;
        //    public string Role_id;
        //    public string Emp_id;

        //    public CApParm()
        //    {
        //        ProcessFlow_id = 0;
        //        ProcessNode_auto = 0;
        //        ProcessCheck_auto = 0;
        //        Role_id = "";
        //        Emp_id = "";
        //    }
        //}

        //public class CApView
        //{
        //    public int ProcessFlow_id = 0;
        //    public string Role_id = "";
        //    public string Emp_id = "";
        //    public string tag1 = "";
        //    public string tag2 = "";
        //    public string tag3 = "";

        //    public CApView()
        //    {
        //        ProcessFlow_id = 0;
        //        Role_id = "";
        //        Emp_id = "";
        //        tag1 = "";
        //        tag2 = "";
        //        tag3 = "";
        //    }
        //}
        #endregion





        /// <summary>
        /// 
        /// </summary>
        /// <param name="idApParm">idApParm</param>
        /// <returns>CApParm</returns>
        public CApParmDto GetApParm(int idApParm);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idApParm">idApParm</param>
        /// <returns>CApParm</returns>
        public CApParmDto GetProcessApParm(int idApParm);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idApView">idApView</param>
        /// <returns>CApView</returns>
        public CApViewDto GetApView(int idApView);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idApView">idApView</param>
        /// <returns>CApView</returns>
        public CApViewDto GetProcessApView(int idApView);

        /// <summary>
        /// 取得新流程ID
        /// </summary>
        /// <returns>int</returns>
        public int GetProcessID();

        /// <summary>
        /// 儲存動態角色
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <param name="idFlowNode">idFlowNode</param>
        /// <param name="idEmp">工號</param>
        /// <param name="idRole">角色 可不填</param>
        /// <returns>bool</returns>
        public bool SaveDynamic(int idProcess, string idFlowNode, string idEmp, string idRole);

        /// <summary>
        /// 刪除動態角色
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <param name="idFlowNode">idFlowNode</param>
        /// <returns>bool</returns>
        public bool DeleteDynamic(int idProcess, string idFlowNode);

        /// <summary>
        /// 取得動態角色
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <param name="idFlowNode">idFlowNode</param>
        /// <returns>bool</returns>
        public List<wfDynamicDto> GetDynamic(int idProcess, string idFlowNode = "0");

        /// <summary>
        /// 流程開始傳送
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <param name="idFlowTree">idFlowTree</param>
        /// <param name="idRole_Start">啟始角色</param>
        /// <param name="idEmp_Start">啟始工號</param>
        /// <param name="idRole_Agent">代理啟單人角色</param>
        /// <param name="idEmp_Agent">代理啟單人工號</param>
        /// <param name="EmpSameUp">遇到本點與上點審核者同一人時 是否要繼續向上</param>
        /// <param name="Man_Default">強迫填入審核者</param>
        /// <param name="Man_Agent">強迫填入代理審核者</param>
        /// <returns>bool</returns>
        public bool FlowStart(int idProcess, string idFlowTree, string idRole_Start, string idEmp_Start, string idRole_Agent, string idEmp_Agent, bool EmpSameUp = true, CMan Man_Default = null, CMan Man_Agent = null);

        /// <summary>
        /// 將流程分享給別人看
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idRole_Share"></param>
        /// <param name="idEmp_Share"></param>
        public void FlowShare(int idProcess, string idRole_Share, string idEmp_Share);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="tag1"></param>
        /// <param name="tag2"></param>
        /// <param name="tag3"></param>
        public void SetApView(int idProcess, string tag1, string tag2, string tag3);

        /// <summary>
        /// 設定更新流程審核表
        /// </summary>
        /// <param name="sNobr">審核者工號</param>
        /// <param name="iApParmID">檢查表序號</param>
        /// <returns>bool</returns>
        public bool SetProcessApParm(int iApParmID);

        /// <summary>
        /// 設定代理人
        /// </summary>
        /// <param name="Role_idSource">來源角色</param>
        /// <param name="Emp_idSource">來源工號</param>
        /// <param name="Role_idTarget">設定角色</param>
        /// <param name="Emp_idTarget">設定工號</param>
        /// <param name="Sort">順位</param>
        /// <param name="KeyMan">登錄者</param>
        /// <returns>bool</returns>
        public bool SetCheckAgent(string Role_idSource, string Emp_idSource, string Role_idTarget, string Emp_idTarget, int Sort = 1, string KeyMan = "Sys");

        /// <summary>
        /// 刪除代理人
        /// </summary>
        /// <param name="sGuid">key</param>
        /// <returns>bool</returns>
        public bool DelCheckAgent(string sGuid);

        /// <summary>
        /// 設定代理日期
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <param name="dDateTimeA">開始日期</param>
        /// <param name="dDateTimeD">結束日期</param>
        /// <param name="KeyMan">登錄者</param>
        /// <returns>bool</returns>
        public bool SetEmpAgentDate(string sNobr, DateTime dDateTimeA, DateTime dDateTimeD, string KeyMan = "Sys");

        /// <summary>
        /// 刪除代理日期
        /// </summary>
        /// <param name="AutoKey">AutoKey</param>
        /// <returns>bool</returns>
        public bool DelEmpAgentDate(int AutoKey);

        /// <summary>
        /// 設定可代理表單
        /// </summary>
        /// <param name="CheckAgent_Guid">CheckAgent_Guid</param>
        /// <param name="FlowTreeId">FlowTreeId</param>
        /// <param name="KeyMan">登錄者</param>
        /// <returns>bool</returns>
        public bool SetCheckAgentFlowTree(string CheckAgent_Guid, string FlowTreeId, string KeyMan = "Sys");

        /// <summary>
        /// 刪除可代理表單
        /// </summary>
        /// <param name="AutoKey">AutoKey</param>
        /// <returns>bool</returns>
        public bool DelCheckAgentFlowTree(int AutoKey);

        /// <summary>
        /// 取得簽核代理人資訊
        /// </summary>
        /// <param name="EmpId">被代理人工號</param>
        /// <returns>List CheckAgentDataRow </returns>
        public List<CheckAgentDataRow> GetCheckAgentData(string EmpId);

        /// <summary>
        /// 取得可代理表單
        /// </summary>
        /// <param name="CheckAgent_Guid">CheckAgent_Guid</param>
        /// <returns>List CheckAgentFlowTreeDataRow</returns>
        public List<CheckAgentFlowTreeDataRow> GetCheckAgentFlowTreeData(string CheckAgent_Guid);

        /// <summary>
        /// 代理日期
        /// </summary>
        /// <param name="EmpId">工號</param>
        /// <returns>List EmpAgentDateDataRow</returns>
        public List<EmpAgentDateDataRow> GetEmpAgentDateData(string EmpId);

        /// <summary>
        /// 審核到下一關
        /// </summary>
        /// <param name="idApParm">idApParm</param>
        /// <param name="EmpSameUp">遇到本點與上點審核者同一人時 是否要繼續向上</param>
        /// <param name="Man_Default">強迫填入審核者</param>
        /// <param name="Man_Agent">強迫填入代理審核者</param>
        /// <param name="FlowStart">第一次進入</param>
        /// <returns>bool</returns>
        public bool WorkFinish(int idApParm, bool EmpSameUp = true, CMan Man_Default = null, CMan Man_Agent = null, bool FlowStart = false);

        /// <summary>
        /// 審核到下一關
        /// </summary>
        /// <param name="idApParm">idApParm</param>
        /// <param name="EmpSameUp">遇到本點與上點審核者同一人時 是否要繼續向上</param>
        /// <param name="Man_Default">強迫填入審核者</param>
        /// <param name="Man_Agent">強迫填入代理審核者</param>
        /// <param name="FlowStart">第一次進入</param>
        /// <returns>bool null = 本關卡完成 , True = 流程全部結束 , False = 本關卡失敗</returns>
        public bool? WorkFinishAndFlowFinish(int idApParm, bool EmpSameUp = true, CMan Man_Default = null, CMan Man_Agent = null, bool FlowStart = false);

        /// <summary>
        /// 增加會簽流程
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idSubFlowTree"></param>
        /// <param name="idSubInitRole"></param>
        /// <param name="idSubInitEmp"></param>
        /// <param name="idSubDynamicRole"></param>
        /// <param name="idSubDynamicEmp"></param>
        public void AddMultiFlow(int idProcess, string idSubFlowTree, string idSubInitRole, string idSubInitEmp, string idSubDynamicRole, string idSubDynamicEmp);

        /// <summary>
        /// 取得主流程ID
        /// </summary>
        /// <param name="idSubProcess">子流程ID</param>
        /// <returns>int</returns>
        public int GetMainProcess(int idSubProcess);

        /// <summary>
        /// 取得員工編號
        /// </summary>
        /// <param name="sEmpId">員工工號</param>
        /// <returns>List Emp</returns>
        public List<EmpRow> GetEmp(string sEmpId);

        /// <summary>
        /// 取得角色資料
        /// </summary>
        /// <param name="idEmp">工號</param>
        /// <param name="idRole">角色</param>
        /// <returns>List RoleRow</returns>
        public List<RoleRow> GetRoleData(string idEmp , string idRole);

        /// <summary>
        /// 流程重送(含上點重送)
        /// </summary>
        /// <param name="lsProcessID">流程編號</param>
        /// <param name="idEmp_Agent">代理啟單人工號</param>
        /// <param name="bPreviousStep">是否上點送重</param>
        /// <returns>List int</returns>
        public List<int> FlowResubmit(List<int> lsProcessID, string idEmp_Agent, bool bPreviousStep = false);

        /// <summary>
        /// 流程狀態設定
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="State">狀態</param>
        /// <param name="idEmp">動作人工號</param>
        /// <returns>List int</returns>
        public List<int> FlowStateSet(List<int> lsProcessID, FlowState State, string idEmp);

        /// <summary>
        /// 指定簽核人員
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="Man_Default">簽核者 物件內容可只填工號</param>
        /// <param name="Man_Agent">代理簽核者 物件內容可只填工號</param>
        /// <returns>List int</returns>
        public List<int> FlowSignSet(List<int> lsProcessID, CMan Man_Default = null, CMan Man_Agent = null);

        /// <summary>
        /// 簽核
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="idEmp">簽核者工號</param>
        /// <returns>List int</returns>
        public void FlowSign(List<int> lsProcessID, string idEmp);

        /// <summary>
        /// 簽核
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="idEmp">簽核者工號</param>
        /// <param name="sNote">意見</param>
        /// <param name="bSign">是否核准</param>
        /// <param name="EmpSameUp"></param>
        /// <returns>List int</returns>
        public List<int> FlowSignWorkFinish(List<int> lsProcessID, string idEmp, string sNote, bool bSign = true, bool EmpSameUp = true);

        /// <summary>
        /// 取得流程相關資訊
        /// </summary>
        /// <param name="lsProcessID">lsProcessID</param>
        /// <returns> List ProcessDataRow</returns>
        public List<ProcessDataRow> GetProcessData(List<int> lsProcessID);

        /// <summary>
        /// 取得可申請表單
        /// </summary>
        /// <param name="sNobr">申請人工號</param>
        /// <param name="sDeptm">部門</param>
        /// <returns>List FlowTreeData</returns>
        public List<FlowTreeDataRow> GetFlowTreeData(string sNobr, string sDeptm );

        /// <summary>
        /// 取得目前待審核的表單
        /// </summary>
        /// <param name="sNobr">審核者工號</param>
        /// <param name="sAppNobr">申請者工號</param>
        /// <returns>List</returns>
        public List<FlowSignRow> GetFlowSign(string sNobr, string sAppNobr);

        /// <summary>
        /// 流程檢視
        /// </summary>
        /// <param name="bManage">是否主管</param>
        /// <param name="sNobr">管理者或被查詢者工號</param>
        /// <param name="dDateSignB">簽核開始日期</param>
        /// <param name="dDateSignE">簽核結束日期</param>
        /// <param name="dDateAppB">申請開始日期</param>
        /// <param name="dDateAppE">申請結束日期</param>
        /// <param name="sState">狀態</param>
        /// <param name="sFormCode">查詢表單代碼</param>
        /// <param name="iProcessID">流程序號</param>
        /// <param name="sApp">查詢角色</param>
        /// <returns>List FlowViewRow</returns>
        public List<FlowViewRow> GetFlowView(bool bManage = false, string sNobr = ""
            , DateTime? dDateSignB = null, DateTime? dDateSignE = null
            , DateTime? dDateAppB = null, DateTime? dDateAppE = null
            , string sState = "1", string sFormCode = "0"
            , int iProcessID = 0, string sApp = "1");

        /// <summary>
        /// 取得檢視網址
        /// </summary>
        /// <param name="idProcess">流程序號</param>
        /// <param name="bOnlyUrl">只顯有網址</param>
        /// <returns>string</returns>
        public string GetFlowViewUrl(int idProcess, bool bOnlyUrl = false);

        /// <summary>
        /// 取得流程的內容網址
        /// </summary>
        /// <param name="iApParmID">檢查表序號</param>
        /// <param name="bOnlyUrl">只顯有網址</param>
        /// <returns>string</returns>
        public string GetFlowParmUrl(int iApParmID, bool bOnlyUrl = false);

        /// <summary>
        /// 判斷第一關是否已簽核過
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <returns>bool</returns>
        public bool IsFirstNodeSing(int idProcess);

        /// <summary>
        /// 設定驗証網頁相關資料
        /// </summary>
        /// <param name="sValidateKey">驗証碼</param>
        /// <param name="sParm">參數內容(有加過密)</param>
        /// <returns>bool</returns>
        public bool SetWebValidate(string sValidateKey, string sParm);

        /// <summary>
        /// 取得驗証網頁相關資料 並填入打開日期
        /// </summary>
        /// <param name="sValidateKey">驗証碼</param>
        /// <returns>wfWebValidate</returns>
        public wfWebValidateDto GetWebValidate(string sValidateKey);

        /// <summary>
        /// 是否是管理者
        /// </summary>
        /// <param name="sNobr">工號</param>
        /// <returns>bool</returns>
        public bool GetAdmin(string sNobr);

        /// <summary>
        /// 取得所有表單代碼及內容
        /// </summary>
        /// <param name="sCode">表單代碼</param>
        /// <returns>List wfForm</returns>
        public List<wfFormDto> GetForm(string sCode );

        /// <summary>
        /// 公告新聞
        /// </summary>
        /// <param name="dDate">預設帶入今天所有生效的資料</param>
        /// <returns>List NoticeRow</returns>
        public List<NoticeRow> GetNoticeData(DateTime? dDate = null);

        /// <summary>
        /// 公告新聞
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns>List NoticeRow</returns>
        public List<NoticeRow> GetNoticeRow(string Guid);

        /// <summary>
        /// 存入公告
        /// </summary>
        /// <param name="Row">NoticeRow資料列</param>
        /// <returns>bool</returns>
        public bool SaveNotice(NoticeRow Row);

        /// <summary>
        /// 刪除公告
        /// </summary>
        /// <param name="Guid">Guid</param>
        /// <returns>bool</returns>
        public bool DeleteNotice(string Guid);

        /// <summary>
        /// 取得流程圖
        /// 未完成
        /// </summary>
        /// <param name="idProcess"></param>
        /// <returns>byte[]</returns>
        public byte[] FlowImage(int idProcess);

        /// <summary>
        /// 取得流程圖
        /// 未完成
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="x">水平起始位置</param>
        /// <param name="y">垂直起始位置</param>
        /// <param name="iWidth">圖片寬度</param>
        /// <param name="iHeight">圖片高度</param>
        /// <param name="bHeader">是否要表頭</param>
        /// <returns>byte[]</returns>
        public byte[] FlowImage(int idProcess, int x = 0, int y = 0, int iWidth = 600, int iHeight = 0, bool bHeader = true);

        /// <summary>
        /// 取得目前錯誤的流程id
        /// </summary>
        /// <returns>List int</returns>
        public List<int> FlowError();

        /// <summary>
        /// 取得流程簽核清單
        /// </summary>
        /// <param name="idProcess">idProcess</param>
        /// <returns>List FlowSignRow</returns>
        public List<FlowSignRow> GetProcessNodeList(int idProcess);

        /// <summary>
        /// 以ProcessNodeAuto向下刪除節點(本節點不刪除)
        /// </summary>
        /// <param name="ProcessNodeAuto">ProcessNodeAuto</param>
        /// <returns>bool</returns>
        public bool DeleteProcessNode(int ProcessNodeAuto);

        /// <summary>
        /// 刪除整個流程
        /// </summary>
        /// <param name="ProcessFlowId">ProcessFlowId</param>
        /// <returns>bool</returns>
        public bool DeleteProcessFlow(int ProcessFlowId);

        /// <summary>
        /// 表單寄信稽催
        /// </summary>
        /// <param name="lsProcessID"></param>
        /// <param name="idEmp">動作人工號</param>
        /// <returns>bool</returns>
        public List<int> ProcessFlowSendMail(List<int> lsProcessID, string idEmp);
    }
}
