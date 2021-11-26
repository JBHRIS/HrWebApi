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

public partial class FlowMonitor : JBWebPage
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["dateB"] = null;
            Session["dateE"] = null;
            lb_nobr.Text = JbUser.NOBR;

            //cbQueryYear.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
            //cbQueryYear.Items.Add(new ListItem(DateTime.Now.AddYears(1).Year.ToString(), DateTime.Now.AddYears(1).Year.ToString()));

            cbQueryYear.DataBind();

            if (cbQueryYear.Items.Count > 0)
            {
                cbQueryMonth.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;

                Session["dateB"] = cbQueryYear.SelectedItem.Value + "/" + cbQueryMonth.SelectedValue + "/1 00:00:00";
                Session["dateE"] = cbQueryYear.SelectedItem.Value + "/" + cbQueryMonth.SelectedValue + "/" +
                    DateTime.DaysInMonth(Convert.ToInt32(cbQueryYear.SelectedItem.Value), Convert.ToInt32(cbQueryMonth.SelectedValue)).ToString() + " 23:59:59";
            }
        }
        if (Session["ActiveViewIndex"] != null)
        {
            MultiView1.ActiveViewIndex = Convert.ToInt32(Session["ActiveViewIndex"]);
        }
    }

    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            if (e.CommandArgument.ToString() != "0")
            {
                ezClientDS.SysVarDataTable dtSysVar = Module.adSysVar.GetData();
                if (dtSysVar.Count > 0)
                {
                    string urlRoot = dtSysVar[0].urlRoot;
                    int ApViewID = Convert.ToInt32(e.CommandArgument);
                    ezClientDS.ProcessApViewDataTable dtProcessApView = Module.adProcessApView.GetDataByAuto(ApViewID);
                    if (dtProcessApView.Count > 0)
                    {
                        ezClientDS.ProcessFlowDataTable dtProcessFlow = Module.adProcessFlow.GetDataById(dtProcessApView[0].ProcessFlow_id);
                        ezClientDS.FlowNodeDataTable dtFlowNode_Start = Module.adFlowNode.GetDataOfNodeStart(dtProcessFlow[0].FlowTree_id);
                        if (dtFlowNode_Start.Count > 0)
                        {
                            ezClientDS.NodeStartDataTable dtNodeStart = Module.adNodeStart.GetDataByFlowNode(dtFlowNode_Start[0].id);
                            if (dtNodeStart.Count > 0)
                            {
                                string virtualPath = (dtNodeStart[0].IsvirtualPathNull()) ? "" : dtNodeStart[0].virtualPath;
                                string apName = (dtNodeStart[0].IsviewApNull()) ? "" : dtNodeStart[0].viewAp;
                                if (virtualPath.Trim().Length > 0 && apName.Trim().Length > 0)
                                {
                                    string link = urlRoot + "/Forms/" + virtualPath + "/" + apName + "?ApView=" + e.CommandArgument.ToString();
                                    link = "MyFrame.aspx?url=" + link;
                                    string script = "var sFeatures = 'dialogWidth:800px;dialogHeight:600px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
                                        "window.showModalDialog('" + link + "', '', sFeatures);" +
                                        "self.location = 'FlowMonitor.aspx';";
                                    if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "OpenWork"))
                                        Page.ClientScript.RegisterStartupScript(typeof(string), "OpenWork", script, true);
                                }
                            }
                        }
                    }
                }
            }
        }
        if (e.CommandName == "History")
        {
            if (e.CommandArgument.ToString() != "0")
            {
                ezClientDS.SysVarDataTable dtSysVar = Module.adSysVar.GetData();
                if (dtSysVar.Count > 0)
                {
                    string urlRoot = dtSysVar[0].urlRoot;
                    string link = urlRoot + "/Forms/FlowImage/Output.aspx?idProcess=" + e.CommandArgument.ToString();
                    link = "MyFrame.aspx?url=" + link;
                    string script = "var sFeatures = 'dialogWidth:800px;dialogHeight:600px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
                        "window.showModalDialog('" + link + "', '', sFeatures);" +
                        "self.location = 'FlowMonitor.aspx';";
                    if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "FlowView"))
                        Page.ClientScript.RegisterStartupScript(typeof(string), "FlowView", script, true);
                }
            }
        }
    }

    protected void grdMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            ezClientDS.StartListRow rowStartList = (ezClientDS.StartListRow)((DataRowView)e.Row.DataItem).Row;
            Control ctrl1 = e.Row.FindControl("bnView");
            if (ctrl1 != null)
            {
                Button bnView = (Button)ctrl1;
                ezClientDS.ProcessApViewDataTable dtProcessApView = Module.adProcessApView.GetDataByProcessFlow(rowStartList.ProcessFlow_id);
                if (dtProcessApView.Count > 0)
                {
                    bnView.CommandArgument = dtProcessApView[0].auto.ToString();
                }
                else
                {
                    bnView.CommandArgument = "0";
                }
            }
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = Convert.ToInt32(RadioButtonList1.SelectedValue);
        Session["ActiveViewIndex"] = MultiView1.ActiveViewIndex;
    }

    protected void bnQuery_Click(object sender, EventArgs e)
    {
        if (cbQueryYear.Items.Count > 0)
        {
            Session["Emp_id"] = JbUser.NOBR;
            Session["dateB"] = cbQueryYear.SelectedItem.Value + "/" + cbQueryMonth.SelectedValue + "/1 00:00:00";
            Session["dateE"] = cbQueryYear.SelectedItem.Value + "/" + cbQueryMonth.SelectedValue + "/" +
                DateTime.DaysInMonth(Convert.ToInt32(cbQueryYear.SelectedItem.Value), Convert.ToInt32(cbQueryMonth.SelectedValue)).ToString() + " 23:59:59";
            grdHistory.DataBind();
        }
    }

    protected void grdHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            Control ctrl = e.Row.FindControl("lbFlowName");
            if (ctrl != null)
            {
                ezClientDS.FlowHistoryRow rowFlowHistory = (ezClientDS.FlowHistoryRow)((DataRowView)e.Row.DataItem).Row;
                ezClientDSTableAdapters.FlowTreeTableAdapter adFlowTree = new ezClientDSTableAdapters.FlowTreeTableAdapter();
                ezClientDS.FlowTreeDataTable dtFlowTree = adFlowTree.GetDataById(rowFlowHistory.FlowTree_id);
                if (dtFlowTree.Count > 0)
                {
                    ((Label)ctrl).Text = dtFlowTree[0].name;
                }
            }
        }
    }

    protected void grdHistory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            if (e.CommandArgument.ToString() != "0")
            {
                ezClientDS.SysVarDataTable dtSysVar = Module.adSysVar.GetData();
                if (dtSysVar.Count > 0)
                {
                    string urlRoot = dtSysVar[0].urlRoot;
                    int ApViewID = Convert.ToInt32(e.CommandArgument);
                    ezClientDS.ProcessApViewDataTable dtProcessApView = Module.adProcessApView.GetDataByAuto(ApViewID);
                    if (dtProcessApView.Count > 0)
                    {
                        ezClientDS.ProcessFlowDataTable dtProcessFlow = Module.adProcessFlow.GetDataById(dtProcessApView[0].ProcessFlow_id);
                        ezClientDS.FlowNodeDataTable dtFlowNode_Start = Module.adFlowNode.GetDataOfNodeStart(dtProcessFlow[0].FlowTree_id);
                        if (dtFlowNode_Start.Count > 0)
                        {
                            ezClientDS.NodeStartDataTable dtNodeStart = Module.adNodeStart.GetDataByFlowNode(dtFlowNode_Start[0].id);
                            if (dtNodeStart.Count > 0)
                            {
                                string virtualPath = (dtNodeStart[0].IsvirtualPathNull()) ? "" : dtNodeStart[0].virtualPath;
                                string apName = (dtNodeStart[0].IsviewApNull()) ? "" : dtNodeStart[0].viewAp;
                                if (virtualPath.Trim().Length > 0 && apName.Trim().Length > 0)
                                {
                                    string link = urlRoot + "/Forms/" + virtualPath + "/" + apName + "?ApView=" + e.CommandArgument.ToString();
                                    link = "MyFrame.aspx?url=" + link;
                                    string script = "var sFeatures = 'dialogWidth:800px;dialogHeight:600px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
                                        "window.showModalDialog('" + link + "', '', sFeatures);";
                                        //"self.location = 'FlowMonitor.aspx';";
                                    if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "OpenWork"))
                                        Page.ClientScript.RegisterStartupScript(typeof(string), "OpenWork", script, true);
                                }
                            }
                        }
                    }
                }
            }
        }
        if (e.CommandName == "History")
        {
            if (e.CommandArgument.ToString() != "0")
            {
                ezClientDS.SysVarDataTable dtSysVar = Module.adSysVar.GetData();
                if (dtSysVar.Count > 0)
                {
                    string urlRoot = dtSysVar[0].urlRoot;
                    string link = urlRoot + "/Forms/FlowImage/Output.aspx?idProcess=" + e.CommandArgument.ToString();
                    link = "MyFrame.aspx?url=" + link;
                    string script = "var sFeatures = 'dialogWidth:800px;dialogHeight:600px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
                        "window.showModalDialog('" + link + "', '', sFeatures);";
                        //"self.location = 'FlowMonitor.aspx';";
                    if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "FlowView"))
                        Page.ClientScript.RegisterStartupScript(typeof(string), "FlowView", script, true);
                }
            }
        }
    }
}
