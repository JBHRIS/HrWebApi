using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.ezEngineServices
{
    public interface ICProcessInterface
    {
        //CApParm GetApParm(int idApParm);

        //CApParm GetProcessApParm(int idApParm);

        //CApView GetApView(int idApView);

        //CApView GetProcessApView(int idApView);


        //    int GetProcessID();

        //bool SaveDynamic(int idProcess, string idFlowNode, string idEmp, string idRole = "");

        ///// <summary>
        ///// 刪除動態角色
        ///// </summary>
        ///// <param name="idProcess">idProcess</param>
        ///// <param name="idFlowNode">idFlowNode</param>
        ///// <returns>bool</returns>
        //bool DeleteDynamic(int idProcess, string idFlowNode);

        ///// <summary>
        ///// 流程開始傳送
        ///// </summary>
        ///// <param name="idProcess">idProcess</param>
        ///// <param name="idFlowTree">idFlowTree</param>
        ///// <param name="idRole_Start">啟始角色</param>
        ///// <param name="idEmp_Start">啟始工號</param>
        ///// <param name="idRole_Agent">代理啟單人角色</param>
        ///// <param name="idEmp_Agent">代理啟單人工號</param>
        ///// <param name="EmpSameUp">遇到本點與上點審核者同一人時 是否要繼續向上</param>
        ///// <param name="Man_Default">強迫填入審核者</param>
        ///// <param name="Man_Agent">強迫填入代理審核者</param>
        ///// <returns>bool</returns>
        ///// <param name="idFlowTree"></param>
        ///// <param name="idRole_Start"></param>
        ///// <param name="idEmp_Start"></param>
        ///// <param name="idRole_Agent"></param>
        ///// <param name="idEmp_Agent"></param>
        ///// <param name="EmpSameUp"></param>
        ///// <param name="Man_Default"></param>
        ///// <param name="Man_Agent"></param>
        ///// <returns></returns>
        //bool FlowStart(int idProcess, string idFlowTree, string idRole_Start, string idEmp_Start, string idRole_Agent = "", string idEmp_Agent = "", bool EmpSameUp = true, CMan Man_Default = null, CMan Man_Agent = null);


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="idProcess"></param>
        ///// <param name="idRole_Share"></param>
        ///// <param name="idEmp_Share"></param>
        //void FlowShare(int idProcess, string idRole_Share, string idEmp_Share);



        //void SetApView(int idProcess, string tag1, string tag2, string tag3);




        ///// <summary>
        ///// 設定更新流程審核表
        ///// </summary>
        ///// <param name="sNobr">審核者工號</param>
        ///// <param name="iApParmID">檢查表序號</param>
        ///// <returns>bool</returns>
        //bool SetProcessApParm(int iApParmID);


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sGuid"></param>
        ///// <returns></returns>
        //bool DelCheckAgent(string sGuid);


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="AutoKey"></param>
        ///// <returns></returns>
        //bool DelCheckAgentFlowTree(int AutoKey);






        //List<CheckAgentFlowTreeDataRow> GetCheckAgentFlowTreeData(string CheckAgent_Guid);



        //List<CheckAgentFlowTreeDataRow> GetCheckAgentFlowTreeData(string CheckAgent_Guid);




        //List<EmpAgentDateDataRow> GetEmpAgentDateData(string EmpId);




        //bool WorkFinish(int idApParm, bool EmpSameUp = true, CMan Man_Default = null, CMan Man_Agent = null, bool FlowStart = false);





        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="idApParm"></param>
        ///// <param name="EmpSameUp"></param>
        ///// <param name="Man_Default"></param>
        ///// <param name="Man_Agent"></param>
        ///// <param name="FlowStart"></param>
        ///// <returns></returns>
        //public bool? WorkFinishAndFlowFinish(int idApParm, bool EmpSameUp = true, CMan Man_Default = null, CMan Man_Agent = null, bool FlowStart = false);



        //bool WorkFinishAndFlowFinish(int idApParm, bool EmpSameUp = true, CMan Man_Default = null, CMan Man_Agent = null, bool FlowStart = false);




        ///// <summary>
        ///// 取得主流程ID
        ///// </summary>
        ///// <param name="idSubProcess">子流程ID</param>
        ///// <returns>int</returns>
        //int GetMainProcess(int idSubProcess);



        ///// <summary>
        ///// 取得員工編號
        ///// </summary>
        ///// <param name="sEmpId">員工工號</param>
        ///// <returns>List Emp</returns>
        //List<EmpRow> GetEmp(string sEmpId = "");



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="lsProcessID"></param>
        ///// <param name="bPreviousStep"></param>
        ///// <param name="idEmp_Agent"></param>
        ///// <returns></returns>
        //List<int> FlowResubmit(List<int> lsProcessID, bool bPreviousStep = false, string idEmp_Agent = "");



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="lsProcessID"></param>
        ///// <param name="State"></param>
        ///// <param name="idEmp"></param>
        ///// <returns></returns>
        //List<int> FlowStateSet(List<int> lsProcessID, FlowState State, string idEmp = "");





        ///// <summary>
        ///// 指定簽核人員
        ///// </summary>
        ///// <param name="lsProcessID"></param>
        ///// <param name="Man_Default">簽核者 物件內容可只填工號</param>
        ///// <param name="Man_Agent">代理簽核者 物件內容可只填工號</param>
        ///// <returns>List int</returns>
        //List<int> FlowSignSet(List<int> lsProcessID, CMan Man_Default = null, CMan Man_Agent = null);



        ///// <summary>
        ///// 簽核
        ///// </summary>
        ///// <param name="lsProcessID"></param>
        ///// <param name="idEmp">簽核者工號</param>
        ///// <returns>List int</returns>
        //void FlowSign(List<int> lsProcessID, string idEmp = "");



        ///// <summary>
        ///// 簽核
        ///// </summary>
        ///// <param name="lsProcessID"></param>
        ///// <param name="idEmp">簽核者工號</param>
        ///// <param name="bSign">是否核准</param>
        ///// <param name="sNote">意見</param>
        ///// <returns>List int</returns>
        //List<int> FlowSignWorkFinish(List<int> lsProcessID, string idEmp = "", bool bSign = true, string sNote = "", bool EmpSameUp = true);


        ///// <summary>
        ///// 取得流程相關資訊
        ///// </summary>
        ///// <param name="lsProcessID">lsProcessID</param>
        ///// <returns> List ProcessDataRow</returns>
        //List<ProcessDataRow> GetProcessData(List<int> lsProcessID);



        ///// <summary>
        ///// 取得可申請表單
        ///// </summary>
        ///// <param name="sNobr">申請人工號</param>
        ///// <param name="sDeptm">部門</param>
        ///// <returns>List FlowTreeData</returns>
        //List<FlowTreeDataRow> GetFlowTreeData(string sNobr, string sDeptm = "");

        ///// <summary>
        ///// 取得目前待審核的表單
        ///// </summary>
        ///// <param name="sNobr">審核者工號</param>
        ///// <param name="sAppNobr">申請者工號</param>
        ///// <returns>List</returns>
        //List<FlowSignRow> GetFlowSign(string sNobr = "", string sAppNobr = "");



        ///// <summary>
        ///// 流程檢視
        ///// </summary>
        ///// <param name="bManage">是否主管</param>
        ///// <param name="sNobr">管理者或被查詢者工號</param>
        ///// <param name="dDateSignB">簽核開始日期</param>
        ///// <param name="dDateSignE">簽核結束日期</param>
        ///// <param name="dDateAppB">申請開始日期</param>
        ///// <param name="dDateAppE">申請結束日期</param>
        ///// <param name="sState">狀態</param>
        ///// <param name="sFormCode">查詢表單代碼</param>
        ///// <param name="iProcessID">流程序號</param>
        ///// <param name="sApp">查詢角色</param>
        ///// <returns>List FlowViewRow</returns>
        //List<FlowViewRow> GetFlowView(bool bManage = false, string sNobr = ""
        //    , DateTime? dDateSignB = null, DateTime? dDateSignE = null
        //    , DateTime? dDateAppB = null, DateTime? dDateAppE = null
        //    , string sState = "1", string sFormCode = "0"
        //    , int iProcessID = 0, string sApp = "1");


        ///// <summary>
        ///// 取得檢視網址
        ///// </summary>
        ///// <param name="idProcess">流程序號</param>
        ///// <param name="bOnlyUrl">只顯有網址</param>
        ///// <returns>string</returns>
        //string GetFlowViewUrl(int idProcess, bool bOnlyUrl = false);




        ///// <summary>
        ///// 判斷第一關是否已簽核過
        ///// </summary>
        ///// <param name="idProcess">idProcess</param>
        ///// <returns>bool</returns>
        //bool IsFirstNodeSing(int idProcess);




        ///// <summary>
        ///// 設定驗証網頁相關資料
        ///// </summary>
        ///// <param name="sValidateKey">驗証碼</param>
        ///// <param name="sParm">參數內容(有加過密)</param>
        ///// <returns>bool</returns>
        //bool SetWebValidate(string sValidateKey, string sParm);





        ///// <summary>
        ///// 取得驗証網頁相關資料 並填入打開日期
        ///// </summary>
        ///// <param name="sValidateKey">驗証碼</param>
        ///// <returns>wfWebValidate</returns>
        //wfWebValidate GetWebValidate(string sValidateKey);





        ///// <summary>
        ///// 是否是管理者
        ///// </summary>
        ///// <param name="sNobr">工號</param>
        ///// <returns>bool</returns>
        //bool GetAdmin(string sNobr);




        ///// <summary>
        ///// 取得所有表單代碼及內容
        ///// </summary>
        ///// <param name="sCode">表單代碼</param>
        ///// <returns>List wfForm</returns>
        //List<wfForm> GetForm(string sCode = "");





        ///// <summary>
        ///// 公告新聞
        ///// </summary>
        ///// <param name="dDate">預設帶入今天所有生效的資料</param>
        ///// <returns>List NoticeRow</returns>
        //List<NoticeRow> GetNoticeData(DateTime? dDate = null);


        ///// <summary>
        ///// 公告新聞
        ///// </summary>
        ///// <param name="Guid">Guid</param>
        ///// <returns>List NoticeRow</returns>
        //List<NoticeRow> GetNoticeRow(string Guid);




        ///// <summary>
        ///// 存入公告
        ///// </summary>
        ///// <param name="Row">NoticeRow資料列</param>
        ///// <returns>bool</returns>
        //bool SaveNotice(NoticeRow Row);





        ///// <summary>
        ///// 刪除公告
        ///// </summary>
        ///// <param name="Guid">Guid</param>
        ///// <returns>bool</returns>
        //bool DeleteNotice(string Guid);





    }
}
