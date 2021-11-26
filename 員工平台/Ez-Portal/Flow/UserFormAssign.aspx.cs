using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI;

public partial class Flow_UserFormAssign : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        win.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            gv.Rebind();
        }
    }

    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == GridRebindReason.ExplicitRebind)
        {
            JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
            //List<JbFlow.FlowSignTable> list = sc.GetFlowProgressFlow(Juser.Nobr).ToList();
            var list = (from c in sc.GetFlowProgressFlow(Juser.Nobr)
                        select new FlowSignView
                        {
                            AgentName = c.AgentName,
                            AgentState = c.AgentState,
                            ApParmID = c.ApParmID,
                            AppDate = c.AppDate,
                            AppName = c.AppName.Trim(),
                            FlowProgress = c.FlowProgress,
                            FormName = c.FormName.Trim(),
                            ParmUrl = c.ParmUrl,
                            ProcessCheckAuto = c.ProcessCheckAuto,
                            ProcessNodeAuto = c.ProcessNodeAuto,
                            ProcessID = c.ProcessID,
                            Info = c.Info
                        }).ToList();

            Session[SessionName] = list;
        }

        if (Session[SessionName] != null)
        {
            gv.DataSource = Session[SessionName] as List<FlowSignView>;
        }
    }

    private class FlowSignView
    {
        public string AgentName { get; set; }

        public string AgentState { get; set; }

        public int ApParmID { get; set; }

        public DateTime AppDate { get; set; }

        public string AppName { get; set; }

        public string FlowProgress { get; set; }

        public string FormName { get; set; }

        public string ParmUrl { get; set; }

        public int ProcessCheckAuto { get; set; }

        public int ProcessNodeAuto { get; set; }

        public string Info { get; set; }

        public int ProcessID { get; set; }
    }

    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Confirm"))
        {
            GridDataItem item = e.Item as GridDataItem;
            JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
            sc.SetProcessApParm(Juser.Nobr, Convert.ToInt32(item["ApParmID"].Text), Convert.ToInt32(item["ProcessCheckAuto"].Text));
            win.NavigateUrl = item["ParmUrl"].Text + @"&ser=" + DateTime.Now.Ticks.ToString();
            win.ReloadOnShow = true;
            win.VisibleOnPageLoad = true;
        }
    }

    protected void btnSign_Click(object sender, EventArgs e)
    {
        List<int> workList = new List<int>();

        foreach (var item in gv.SelectedItems)
        {
            GridDataItem dItem = item as GridDataItem;
            if (dItem == null)
            {
                continue;
            }

            workList.Add(Convert.ToInt32(dItem["ApParmID"].Text));
        }

        if (workList.Count > 0)
        {
            JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
            int[] lsApParmIDPass = sc.WorkFinish(workList.ToArray(), Juser.Nobr, "", true);

            lblMsg.Text = "傳送完成！";
            gv.Rebind();

            var m = ((MasterPage_MasterPage)this.Page.Master) as IBindNeedAssignedNum;
            if (m != null)
                m.BindNeedAssignedNum();
        }
    }
}