using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Module 的摘要描述
/// </summary>
public class AllModule
{
	public ezClientDSTableAdapters.FlowTreeTableAdapter adFlowTree = new ezClientDSTableAdapters.FlowTreeTableAdapter();
	public ezClientDSTableAdapters.RoleTableAdapter adRole = new ezClientDSTableAdapters.RoleTableAdapter();
	public ezClientDSTableAdapters.DeptTableAdapter adDept = new ezClientDSTableAdapters.DeptTableAdapter();
	public ezClientDSTableAdapters.FlowGroupTableAdapter adFlowGroup = new ezClientDSTableAdapters.FlowGroupTableAdapter();
	public ezClientDSTableAdapters.PosTableAdapter adPos = new ezClientDSTableAdapters.PosTableAdapter();
	public ezClientDSTableAdapters.WorkListTableAdapter adWorkList = new ezClientDSTableAdapters.WorkListTableAdapter();
	public ezClientDSTableAdapters.WorkAgentTableAdapter adWorkAgent = new ezClientDSTableAdapters.WorkAgentTableAdapter();
	public ezClientDSTableAdapters.WorkAgentPowerTableAdapter adWorkAgentPower = new ezClientDSTableAdapters.WorkAgentPowerTableAdapter();
	public ezClientDSTableAdapters.EmpTableAdapter adEmp = new ezClientDSTableAdapters.EmpTableAdapter();
	public ezClientDSTableAdapters.FlowNodeTableAdapter adFlowNode = new ezClientDSTableAdapters.FlowNodeTableAdapter();
	public ezClientDSTableAdapters.NodeFormTableAdapter adNodeForm = new ezClientDSTableAdapters.NodeFormTableAdapter();
	public ezClientDSTableAdapters.NodeStartTableAdapter adNodeStart = new ezClientDSTableAdapters.NodeStartTableAdapter();
	public ezClientDSTableAdapters.SysVarTableAdapter adSysVar = new ezClientDSTableAdapters.SysVarTableAdapter();
	public ezClientDSTableAdapters.ProcessApParmTableAdapter adProcessApParm = new ezClientDSTableAdapters.ProcessApParmTableAdapter();
	public ezClientDSTableAdapters.ProcessFlowTableAdapter adProcessFlow = new ezClientDSTableAdapters.ProcessFlowTableAdapter();
	public ezClientDSTableAdapters.ProcessNodeTableAdapter adProcessNode = new ezClientDSTableAdapters.ProcessNodeTableAdapter();
	public ezClientDSTableAdapters.NodeMangTableAdapter adNodeMang = new ezClientDSTableAdapters.NodeMangTableAdapter();
	public ezClientDSTableAdapters.NodeInitTableAdapter adNodeInit = new ezClientDSTableAdapters.NodeInitTableAdapter();
	public ezClientDSTableAdapters.NodeMultiInitTableAdapter adNodeMultiInit = new ezClientDSTableAdapters.NodeMultiInitTableAdapter();
	public ezClientDSTableAdapters.NodeCustomTableAdapter adNodeCustom = new ezClientDSTableAdapters.NodeCustomTableAdapter();
	public ezClientDSTableAdapters.NodeDynamicTableAdapter adNodeDynamic = new ezClientDSTableAdapters.NodeDynamicTableAdapter();
	public ezClientDSTableAdapters.NodeAgentInitTableAdapter adNodeAgentInit = new ezClientDSTableAdapters.NodeAgentInitTableAdapter();
	public ezClientDSTableAdapters.ProcessCheckTableAdapter adProcessCheck = new ezClientDSTableAdapters.ProcessCheckTableAdapter();
	public ezClientDSTableAdapters.ProcessApViewTableAdapter adProcessApView = new ezClientDSTableAdapters.ProcessApViewTableAdapter();
	public ezClientDSTableAdapters.HrPostTableAdapter adHrPost = new ezClientDSTableAdapters.HrPostTableAdapter();
	public ezClientDSTableAdapters.GoodPostTableAdapter adGoodPost = new ezClientDSTableAdapters.GoodPostTableAdapter();
	public ezClientDSTableAdapters.BoardListTableAdapter adBoardList = new ezClientDSTableAdapters.BoardListTableAdapter();
	public ezClientDSTableAdapters.PostMainTableAdapter adPostMain = new ezClientDSTableAdapters.PostMainTableAdapter();
	public ezClientDSTableAdapters.PostDetailTableAdapter adPostDetail = new ezClientDSTableAdapters.PostDetailTableAdapter();
	public ezClientDSTableAdapters.EmpInfoTableAdapter adEmpInfo = new ezClientDSTableAdapters.EmpInfoTableAdapter();
	public ezClientDSTableAdapters.PraiseRecordTableAdapter adPraiseRecord = new ezClientDSTableAdapters.PraiseRecordTableAdapter();
	public ezClientDSTableAdapters.BestViewTableAdapter adBestView = new ezClientDSTableAdapters.BestViewTableAdapter();
	public ezClientDSTableAdapters.GuestMsgTableAdapter adGuestMsg = new ezClientDSTableAdapters.GuestMsgTableAdapter();
	public ezClientDSTableAdapters.SysAdminTableAdapter adSysAdmin = new ezClientDSTableAdapters.SysAdminTableAdapter();
	public ezClientDSTableAdapters.BoardApplyTableAdapter adBoardApply = new ezClientDSTableAdapters.BoardApplyTableAdapter();
	public ezClientDSTableAdapters.CheckAgentAlwaysTableAdapter adCheckAgentAlways = new ezClientDSTableAdapters.CheckAgentAlwaysTableAdapter();
	public ezClientDSTableAdapters.CheckAgentDefaultTableAdapter adCheckAgentDefault = new ezClientDSTableAdapters.CheckAgentDefaultTableAdapter();
	public ezClientDSTableAdapters.CheckAgentPowerMTableAdapter adCheckAgentPowerM = new ezClientDSTableAdapters.CheckAgentPowerMTableAdapter();
	public ezClientDSTableAdapters.CheckAgentPowerDTableAdapter adCheckAgentPowerD = new ezClientDSTableAdapters.CheckAgentPowerDTableAdapter();
	public ezClientDSTableAdapters.BoardApplySignTableAdapter adBoardApplySign = new ezClientDSTableAdapters.BoardApplySignTableAdapter();
	public ezClientDSTableAdapters.CalendarTableAdapter adCalendar = new ezClientDSTableAdapters.CalendarTableAdapter();
	public ezClientDSTableAdapters.CalendarAllTableAdapter adCalendarAll = new ezClientDSTableAdapters.CalendarAllTableAdapter();
	public ezClientDSTableAdapters.DeviceCalendarTableAdapter adDeviceCalendar = new ezClientDSTableAdapters.DeviceCalendarTableAdapter();
	public ezClientDSTableAdapters.DeviceDateTableAdapter adDeviceDate = new ezClientDSTableAdapters.DeviceDateTableAdapter();
    public ezClientDSTableAdapters.wfFormTableAdapter adForm = new ezClientDSTableAdapters.wfFormTableAdapter();
    public ezClientDSTableAdapters.wfFormDataGroupTableAdapter adFormDataGroup = new ezClientDSTableAdapters.wfFormDataGroupTableAdapter();
}
