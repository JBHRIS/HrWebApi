using JBHRIS.Api.Dto.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezEngineServices
{
    public interface ICData_Dal
    {



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
        public List<FlowTreeDataRow> GetFlowTreeData(string sNobr, string sDeptm);


        /// <summary>
        /// 取得目前待審核的表單
        /// </summary>
        /// <param name="sNobr">審核者工號</param>
        /// <param name="sAppNobr">申請者工號</param>
        /// <returns>List</returns>
        public List<FlowSignRow> GetFlowSign(string sNobr , string sAppNobr);

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
        /// 取得目前正在進行中的流程
        /// </summary>
        /// <param name="sNobr">查詢者工號</param>
        /// <returns>List</returns>
        public List<FlowSearchIngRow> GetFlowSearchIng(string sNobr);


        /// <summary>
        /// 取得目前完成的流程
        /// </summary>
        /// <param name="sNobr">查詢者工號</param>
        /// <param name="dAppB">查詢開始日期</param>
        /// <param name="dAppE">查詢結束日期</param>
        /// <returns>List</returns>
        public List<FlowSearchCompleteRow> GetFlowSearchComplete(string sNobr, DateTime dAppB, DateTime dAppE);




        /// <summary>
        /// 取得流程目錄位置
        /// </summary>
        /// <param name="lsFlowTreeId">lsFlowTreeId</param>
        /// <returns>List FlowTreePathRow</returns>
        public List<FlowTreePathRow> GetFlowTreePath(List<string> lsFlowTreeId = null);


        /// <summary>
        /// 取得程式檔案名稱
        /// </summary>
        /// <param name="lsFlowNodeId">lsFlowNodeId</param>
        /// <returns>List FlowNodeApNameRow</returns>
        public List<FlowNodeApNameRow> GetFlowNodeAppName(List<string> lsFlowNodeId);




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




    }
}
