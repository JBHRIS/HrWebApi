using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

public partial class Home : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblBrowser.Text = Request.Browser.Browser;
            if (Request.QueryString["ID"] != null)
            {
                string qID = Encrypt.DecryptInformation(Request.QueryString["ID"].ToString());
                string[] arr = Regex.Split(qID, "(-jb-)");
                if (arr.Length > 0)
                {
                    Response.Cookies["ezFlow"]["Emp_id"] = arr[0];
                    Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
                    Session["Emp_id"] = arr[0];
                }
            }
            else
            {
                Response.Cookies["ezFlow"]["Emp_id"] = Request.Cookies["ezFlow"]["Emp_id"];
                Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
                Session["Emp_id"] = Request.Cookies["ezFlow"]["Emp_id"];
            }

            ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByEmp(Response.Cookies["ezFlow"]["Emp_id"]);
            if (dtRole.Count == 0)
            {
                Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("default.aspx");
            }

            object ret = Module.adWorkList.CountQuery(Request.Cookies["ezFlow"]["Emp_id"]);
            if (ret == null) ret = "0";

            lbMsg.Text = "<img border='0' src='App_Themes/jb_ezflow_style_a/images/icon_att.gif'>&nbsp;&nbsp;" + "待辦事項共 " + ret.ToString() + " 個項目" + "&nbsp;&nbsp;<img border='0' src='App_Themes/jb_ezflow_style_a/images/icon_att.gif'>";

            ezClientDS.EmpDataTable dtEmp;

            //dtEmp = Module.adEmp.GetDataById(Request.Cookies["ezFlow"]["Emp_id"].ToString());
            dtEmp = Module.adEmp.GetDataById(Session["Emp_id"].ToString());
            if (dtEmp.Count > 0) lbName.Text = dtEmp[0].name;
        }
    }

    protected void dlNews_ItemCommand(object source, DataListCommandEventArgs e) {
        if (e.CommandName == "HrPost" || e.CommandName == "HrNotice") {
            string link = "MyFrame.aspx?url=" + e.CommandName + ".aspx?auto=" + e.CommandArgument.ToString();
            string script = "var sFeatures = 'dialogWidth:760px;dialogHeight:500px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
                "window.showModalDialog('" + link + "', '', sFeatures);";
            if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "HrPost"))
                Page.ClientScript.RegisterStartupScript(typeof(string), "HrPost", script, true);
        }
        if (e.CommandName == "NewHrPost" || e.CommandName == "NewHrNotice") {
            string link = "MyFrame.aspx?url=" + e.CommandName + ".aspx";
            string script = "var sFeatures = 'dialogWidth:760px;dialogHeight:500px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
                "window.showModalDialog('" + link + "', '', sFeatures);" +
                "self.location = 'Home.aspx';";
            if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "HrPost"))
                Page.ClientScript.RegisterStartupScript(typeof(string), "HrPost", script, true);
        }
    }

    protected void dlNews_ItemDataBound(object sender, DataListItemEventArgs e) {
        if (e.Item.ItemType == ListItemType.Header) {
            Button btn = (Button)e.Item.FindControl("bnAdmin");
            if (btn != null) {
                ezClientDS.SysAdminDataTable dtSysAdmin = Module.adSysAdmin.GetDataByEmp(Request.Cookies["ezFlow"]["Emp_id"].ToString());
                btn.Visible = dtSysAdmin.Count > 0;
            }
        }
    }

    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e) {
        if (e.CommandName == "Check") {
            if (e.CommandArgument.ToString() != "0") {
                ezClientDS.SysVarDataTable dtSysVar = Module.adSysVar.GetData();
                if (dtSysVar.Count > 0) {
                    string urlRoot = dtSysVar[0].urlRoot;
                    int ApParmID = Convert.ToInt32(e.CommandArgument);
                    ezClientDS.ProcessApParmDataTable dtProcessApParm = Module.adProcessApParm.GetDataByAuto(ApParmID);
                    if (dtProcessApParm.Count > 0) {
                        ezClientDS.ProcessFlowDataTable dtProcessFlow = Module.adProcessFlow.GetDataById(dtProcessApParm[0].ProcessFlow_id);
                        ezClientDS.ProcessNodeDataTable dtProcessNode = Module.adProcessNode.GetDataByAuto(dtProcessApParm[0].ProcessNode_auto);
                        ezClientDS.FlowNodeDataTable dtFlowNode_Start = Module.adFlowNode.GetDataOfNodeStart(dtProcessFlow[0].FlowTree_id);
                        if (dtFlowNode_Start.Count > 0) {
                            ezClientDS.NodeStartDataTable dtNodeStart = Module.adNodeStart.GetDataByFlowNode(dtFlowNode_Start[0].id);
                            if (dtNodeStart.Count > 0) {
                                string virtualPath = dtNodeStart[0].virtualPath;
                                ezClientDS.FlowNodeDataTable dtFlowNode_Check = Module.adFlowNode.GetDataById(dtProcessNode[0].FlowNode_id);
                                string apName = "";
                                switch (dtFlowNode_Check[0].nodeType) {
                                    case "3": //主管審核
                                        ezClientDS.NodeMangDataTable dtNodeMang = Module.adNodeMang.GetDataByFlowNode(dtFlowNode_Check[0].id);
                                        if (dtNodeMang.Count > 0) apName = dtNodeMang[0].apName;
                                        break;
                                    case "4": //流程起始者
                                        ezClientDS.NodeInitDataTable dtNodeInit = Module.adNodeInit.GetDataByFlowNode(dtFlowNode_Check[0].id);
                                        if (dtNodeInit.Count > 0) apName = dtNodeInit[0].apName;
                                        break;
                                    case "5": //會簽起始者
                                        ezClientDS.NodeMultiInitDataTable dtNodeMultiInit = Module.adNodeMultiInit.GetDataByFlowNode(dtFlowNode_Check[0].id);
                                        if (dtNodeMultiInit.Count > 0) apName = dtNodeMultiInit[0].apName;
                                        break;
                                    case "6": //自定簽核者
                                        ezClientDS.NodeCustomDataTable dtNodeCustom = Module.adNodeCustom.GetDataByFlowNode(dtFlowNode_Check[0].id);
                                        if (dtNodeCustom.Count > 0) apName = dtNodeCustom[0].apName;
                                        break;
                                    case "7": //動態簽核者
                                        ezClientDS.NodeDynamicDataTable dtNodeDynamic = Module.adNodeDynamic.GetDataByFlowNode(dtFlowNode_Check[0].id);
                                        if (dtNodeDynamic.Count > 0) apName = dtNodeDynamic[0].apName;
                                        break;
                                    case "8": //流程代理者
                                        ezClientDS.NodeAgentInitDataTable dtNodeAgentInit = Module.adNodeAgentInit.GetDataByFlowNode(dtFlowNode_Check[0].id);
                                        if (dtNodeAgentInit.Count > 0) apName = dtNodeAgentInit[0].apName;
                                        break;
                                }

                                if (apName.Trim().Length > 0) {
                                    ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByEmp(Request.Cookies["ezFlow"]["Emp_id"].ToString());
                                    ezClientDS.ProcessCheckDataTable dtProcessCheck = Module.adProcessCheck.GetDataByAuto(dtProcessApParm[0].ProcessCheck_auto);
                                    string Role_id = "";
                                    foreach (DataRow drRole in dtRole.Rows) {
                                        ezClientDS.RoleRow rowRole = (ezClientDS.RoleRow)drRole;
                                        if (rowRole.id == dtProcessCheck[0].Role_idDefault || rowRole.id == dtProcessCheck[0].Role_idAgent) {
                                            Role_id = rowRole.id;
                                            break;
                                        }
                                    }
                                    if (Role_id.Trim().Length > 0) {
                                        dtProcessApParm[0].Role_id = Role_id;
                                        dtProcessApParm[0].Emp_id = Request.Cookies["ezFlow"]["Emp_id"].ToString();
                                        Module.adProcessApParm.Update(dtProcessApParm);
                                        string link = urlRoot + "/Forms/" + virtualPath + "/" + apName + "?ApParm=" + e.CommandArgument.ToString();
                                        link = "MyFrame.aspx?url=" + link;
                                        string script = "var sFeatures = 'dialogWidth:800px;dialogHeight:600px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
                                            "window.showModalDialog('" + link + "', '', sFeatures);" +
                                            "self.location = 'Home.aspx';";
                                        if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "OpenWork"))
                                            Page.ClientScript.RegisterStartupScript(typeof(string), "OpenWork", script, true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    protected void grdMain_RowDataBound(object sender, GridViewRowEventArgs e) {
        if (e.Row.DataItem != null) {
            ezClientDS.WorkListRow rowWorkList = (ezClientDS.WorkListRow)((DataRowView)e.Row.DataItem).Row;
            Control ctrl = null;
            ctrl = e.Row.FindControl("bnCheck");
            if (ctrl != null) {
                Button bnCheck = (Button)ctrl;

                ezClientDS.ProcessApParmDataTable dtProcessApParm = Module.adProcessApParm.GetDataByProcess(
                    rowWorkList.ProcessFlow_id, rowWorkList.ProcessNode_auto, rowWorkList.ProcessCheck_auto);
                if (dtProcessApParm.Count > 0) bnCheck.CommandArgument = dtProcessApParm[0].auto.ToString();
                else bnCheck.CommandArgument = "0";
            }

            ctrl = e.Row.FindControl("lbStatus");
            if (ctrl != null) {
                ((Label)ctrl).Text = "";
                if (rowWorkList.Role_idAgent.Trim().Length > 0) {
                    ezClientDS.RoleDataTable dtRole = Module.adRole.GetDataByEmp(Request.Cookies["ezFlow"]["Emp_id"].ToString());
                    foreach (DataRow drRole in dtRole.Rows) {
                        ezClientDS.RoleRow rowRole = (ezClientDS.RoleRow)drRole;
                        if (rowRole.id == rowWorkList.Role_idAgent) {
                            ((Label)ctrl).Text = "代為處理";
                            break;
                        }
                    }
                }
            }
        }
    }
    protected void grdMain_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("HomeM.aspx");
    }
}
