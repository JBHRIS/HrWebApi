using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// CProcess 的摘要描述
/// </summary>
public class CProcess
{
    static ezOrgDSTableAdapters.EmpTableAdapter adEmp = new ezOrgDSTableAdapters.EmpTableAdapter();

	static ezFlowDSTableAdapters.FlowNodeTableAdapter adFlowNode = new ezFlowDSTableAdapters.FlowNodeTableAdapter();	
	static ezFlowDSTableAdapters.FlowLinkTableAdapter adFlowLink = new ezFlowDSTableAdapters.FlowLinkTableAdapter();

	static ezProcessDSTableAdapters.ProcessExceptionTableAdapter adProcessException = new ezProcessDSTableAdapters.ProcessExceptionTableAdapter();	
	static ezProcessDSTableAdapters.ProcessNodeTableAdapter adProcessNode = new ezProcessDSTableAdapters.ProcessNodeTableAdapter();
	static ezProcessDSTableAdapters.ProcessCheckTableAdapter adProcessCheck = new ezProcessDSTableAdapters.ProcessCheckTableAdapter();
	static ezProcessDSTableAdapters.SysVarTableAdapter adSysVar = new ezProcessDSTableAdapters.SysVarTableAdapter();
	static ezProcessDSTableAdapters.ProcessApParmTableAdapter adProcessApParm = new ezProcessDSTableAdapters.ProcessApParmTableAdapter();
	static ezProcessDSTableAdapters.ProcessFlowTableAdapter adProcessFlow = new ezProcessDSTableAdapters.ProcessFlowTableAdapter();
    static ezProcessDSTableAdapters.SendMailLogTableAdapter adSendMailLog = new ezProcessDSTableAdapters.SendMailLogTableAdapter();

	public static void WriteProcessException(int idProcess, int idProcessNode, int idProcessCheck, ErrorType errorType, string errorMsg) {
		ezProcessDS.ProcessExceptionDataTable dtProcessException = new ezProcessDS.ProcessExceptionDataTable();
		ezProcessDS.ProcessExceptionRow rowProcessException = dtProcessException.NewProcessExceptionRow();
		rowProcessException.ProcessFlow_id = idProcess;
		rowProcessException.ProcessNode_auto = idProcessNode;
		rowProcessException.ProcessCheck_auto = idProcessCheck;
		switch(errorType) {
			case ErrorType.Error:
				rowProcessException.errorType = "1";
				break;
			case ErrorType.Cancel:
				rowProcessException.errorType = "2";
				break;
			case ErrorType.Warning:
				break;
		}
		rowProcessException.errorMsg = errorMsg;
		rowProcessException.adate = DateTime.Now;
		rowProcessException.isOK = false;
		dtProcessException.AddProcessExceptionRow(rowProcessException);
		adProcessException.Update(dtProcessException);

		ezProcessDS.ProcessFlowDataTable dtProcessFlow = adProcessFlow.GetDataById(idProcess);
		if(dtProcessFlow.Count > 0) {
			if(errorType == ErrorType.Error) dtProcessFlow[0].isError = true;
			if(errorType == ErrorType.Cancel) dtProcessFlow[0].isCancel = true;
			adProcessFlow.Update(dtProcessFlow);
		}
	}

	public static int CreateProcessNode(int idProcessNode_Prior, int idProcess, string idFlowNode) {
		ezFlowDS.FlowNodeDataTable dtFlowNode = adFlowNode.GetDataById(idFlowNode);

		ezProcessDS.ProcessNodeDataTable dtProcessNode = adProcessNode.GetDataByOne(idProcess, idProcessNode_Prior, idFlowNode);
		ezProcessDS.ProcessNodeRow rowProcessNode = null;
		if (dtProcessNode.Count == 0) {
			rowProcessNode = dtProcessNode.NewProcessNodeRow();
			rowProcessNode.ProcessFlow_id = idProcess;
			rowProcessNode.ProcessNode_idPrior = idProcessNode_Prior;
			rowProcessNode.FlowNode_id = idFlowNode;
		}
		else rowProcessNode = dtProcessNode[0];
		rowProcessNode.adate = DateTime.Now;
		rowProcessNode.isFinish = false;
		if (dtProcessNode.Count == 0) dtProcessNode.AddProcessNodeRow(rowProcessNode);
		adProcessNode.Update(dtProcessNode);

		return dtProcessNode[0].auto;
	}

	public static void WriteProcessNodeAndCheck(int idProcessNode_Prior, int idProcess, string idFlowNode, CMan Man_Default, CMan Man_Agent) {
		int ProcessNode_auto = CreateProcessNode(idProcessNode_Prior, idProcess, idFlowNode);

		ezProcessDS.ProcessCheckDataTable dtProcessCheck = new ezProcessDS.ProcessCheckDataTable();
		ezProcessDS.ProcessCheckRow rowProcessCheck = dtProcessCheck.NewProcessCheckRow();
		rowProcessCheck.ProcessNode_auto = ProcessNode_auto;
		rowProcessCheck.Role_idDefault = Man_Default.idRole;
		rowProcessCheck.Emp_idDefault = Man_Default.idEmp;
		if(Man_Agent != null) {
			rowProcessCheck.Role_idAgent = Man_Agent.idRole;
			rowProcessCheck.Emp_idAgent = Man_Agent.idEmp;
		}
		else {
			rowProcessCheck.Role_idAgent = "";
			rowProcessCheck.Emp_idAgent = "";
		}
		rowProcessCheck.Role_idReal = "";
		rowProcessCheck.Emp_idReal = "";
		rowProcessCheck.adate = Convert.ToDateTime("1900/1/1");
		dtProcessCheck.AddProcessCheckRow(rowProcessCheck);
		adProcessCheck.Update(dtProcessCheck);

		ezProcessDS.ProcessApParmDataTable dtProcessApParm = adProcessApParm.GetDataByOne(
			idProcess, ProcessNode_auto, dtProcessCheck[0].auto);
		if(dtProcessApParm.Count == 0) {
			ezProcessDS.ProcessApParmRow rowProcessApParm = dtProcessApParm.NewProcessApParmRow();
			rowProcessApParm.ProcessFlow_id = idProcess;
			rowProcessApParm.ProcessNode_auto = ProcessNode_auto;
			rowProcessApParm.ProcessCheck_auto = dtProcessCheck[0].auto;
			rowProcessApParm.Role_id = "";
			rowProcessApParm.Emp_id = "";
			dtProcessApParm.AddProcessApParmRow(rowProcessApParm);
			adProcessApParm.Update(dtProcessApParm);

            try
            {
                string sEmpID = Man_Default.idEmp;
                if (Man_Agent != null)
                    sEmpID = Man_Agent.idEmp;

                ezOrgDS.EmpDataTable dtEmp = adEmp.GetDataById(sEmpID);
                if (dtEmp.Rows.Count > 0)
                {
                    ezProcessDS.SysVarDataTable dtSysVar = adSysVar.GetData();
                    if (dtSysVar.Rows.Count > 0)
                    {
                        string mailto = dtEmp[0].email;
                        if (adSendMailLog.GetDataByEmp(sEmpID).Rows.Count == 0)
                            adSendMailLog.Insert(sEmpID, 0, DateTime.Now);

                        string body = dtEmp[0].name + ",您好...<br><br>" +
                                  "這封信，是由 ezFlow System 所發出的。<br>" +
                                  "系統偵測到在流程中，有您的待辦事項需要完成，請您抽空前往處理。謝謝！<br><br>" +
                                  "<a href='" + dtSysVar[0].urlRoot + "/ezClient/Default.aspx'>待核簽事項</a>";

                        CFlow.SendMail(idProcess, ProcessNode_auto, dtProcessCheck[0].auto, "",sEmpID, mailto, "流程信差服務", body);
                    }
                }
            }
            catch (Exception ex) { }
		}
	}

	public static int GetProcessID() {
		ezProcessDS.SysVarDataTable dtSysVar = adSysVar.GetData();
		int idProcess = 0;
		if(dtSysVar.Count > 0) {
			if(adProcessFlow.MaxID() != null) {
				idProcess = (int)adProcessFlow.MaxID();
				if(dtSysVar[0].maxKey >= idProcess) dtSysVar[0].maxKey += 1;
				else dtSysVar[0].maxKey = idProcess + 1;
				adSysVar.Update(dtSysVar);
			}
			idProcess = dtSysVar[0].maxKey;
		}		

		return idProcess;
	}
}
