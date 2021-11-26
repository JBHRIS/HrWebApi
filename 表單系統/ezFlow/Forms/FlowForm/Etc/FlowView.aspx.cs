using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Transactions;

public partial class Etc_FlowView : System.Web.UI.Page
{
    dcFlowDataContext dcFlow = new dcFlowDataContext();
    dcFormDataContext dcForm = new dcFormDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request.QueryString["Parm"] != null)
            {
                string RequestQueryString = Bll.Tools.Decryption.Decrypt(Request.QueryString["Parm"]);
                var dc = Bll.Tools.DataTrans.QueryStringToDictionary(RequestQueryString);

                if (dc.ContainsKey("ValidateKey"))
                {
                    string sValidateKey = dc["ValidateKey"];

                    DateTime Date = DateTime.Now;

                    var r = (from c in dcFlow.wfWebValidate
                             where c.sValidateKey == sValidateKey
                             select c).FirstOrDefault();

                    if (r != null)
                    {
                        if (r.dDateWriter >= DateTime.Now.AddMinutes(-1))
                        {
                            lblFormCode.Text = dc["FormCode"];
                            lblNobr.Text = dc["NobrM"];
                            lblViewUrl.Text = dc["ViewUrl"];

                            r.dDateOpen = DateTime.Now;
                            dcFlow.SubmitChanges();
                        }
                    }
                }
            }

            ckbManage.Visible = false;
            plManage.Visible = false;

            lblNobr.Text = Request.QueryString["idEmp_Start"] != null ? Request.QueryString["idEmp_Start"].ToUpper() : lblNobr.Text;

            if (Request.Cookies["ezFlow"] != null && Request.Cookies["ezFlow"]["Emp_id"] != null)
                lblNobr.Text = Request.Cookies["ezFlow"]["Emp_id"];

            if (User.Identity.IsAuthenticated && User.Identity.Name.Trim().Length > 0)
                lblNobr.Text = User.Identity.Name;

            txtNobr.Text = lblNobr.Text;

            //判斷是否為管理者
            var rSysAdmin = (from c in dcFlow.SysAdmin
                             where c.Emp_id == lblNobr.Text
                             select c).FirstOrDefault();

            if (rSysAdmin != null)
            {
                ckbManage.Visible = true;
                plManage.Visible = true;

                if (lblFormCode.Text.Length == 0)
                {
                    ckbManage.Checked = true;
                    txtNobr.Text = "";
                }
            }

            SetFlowFromData();

            var rSysVar = (from c in dcFlow.SysVar
                           select c).FirstOrDefault();

            if (rSysVar != null && lblViewUrl.Text.Length == 0)
                lblViewUrl.Text = rSysVar.urlRoot + "/Forms/";

            if (txtFlowForm.Items.FindItemByValue(lblFormCode.Text) != null)
                txtFlowForm.Items.FindItemByValue(lblFormCode.Text).Selected = true;

            BindData();
        }
    }

    //顯示目前現有的流程表單
    private void SetFlowFromData()
    {
        var rsForm = (from c in dcFlow.wfForm
                      where c.s5 != "0"
                      orderby c.s5
                      select new
                      {
                          Code = c.sFormCode,
                          Name = c.sFormName,
                      }).ToList();

        txtFlowForm.DataSource = rsForm;
        txtFlowForm.DataTextField = "Name";
        txtFlowForm.DataValueField = "Code";
        txtFlowForm.DataBind();
    }

    public class FlowData
    {
        public int ProcessID { get; set; }
        public string FormName { get; set; }
        public string Info { get; set; }
        public string Nobr { get; set; }
    }

    private void BindData()
    {
        DateTime dDate = DateTime.Now.Date;
        DateTime dDateB = dDate.AddMonths(-3).Date;
        DateTime dDateE = dDate.AddMonths(3).Date;

        bool bManage = ckbManage.Checked;
        string sFormCode = txtFlowForm.SelectedValue;
        string sLoginNobr = lblNobr.Text;
        string sNobr = txtNobr.Text;
        int iProcessID = Convert.ToInt32(txtProcessID.Value.GetValueOrDefault(0));

        DateTime dDateAppB = txtDateAppB.SelectedDate.GetValueOrDefault(dDateB);
        DateTime dDateAppE = txtDateAppE.SelectedDate.GetValueOrDefault(dDateE);

        DateTime dDateSignB = txtDateSignB.SelectedDate.GetValueOrDefault(dDateB);
        DateTime dDateSignE = txtDateSignE.SelectedDate.GetValueOrDefault(dDateE);

        string sApp = muApp.SelectedItem.Value;
        string sState = muState.SelectedItem.Value;

        List<FlowData> lsFlowData = new List<FlowData>();

        List<string> lsFlowFormAll = new List<string>();
        foreach (RadComboBoxItem li in txtFlowForm.Items)
            lsFlowFormAll.Add(li.Value);

        //管理者可以看全部
        if (bManage)
        {
            //審核者
            var rsFormSignM = from w in dcFlow.wfFormSignM
                              where (sNobr == "" || w.sNobr == sNobr)
                              && dDateSignB <= w.dKeyDate.GetValueOrDefault(dDate)
                              && w.dKeyDate.GetValueOrDefault(dDate) <= dDateSignE
                              select w;

            //被申請人
            var rsFormAppInfo = from s in dcFlow.wfFormAppInfo
                                where (sNobr == "" || s.sNobr == sNobr)
                                && dDateAppB <= s.dKeyDate.GetValueOrDefault(dDate)
                                && s.dKeyDate.GetValueOrDefault(dDate) <= dDateAppE
                                && s.sState == sState
                                select s;

            //申請人
            var rsFlowData = from m in dcFlow.wfFormApp
                             where ((sFormCode == "0" && lsFlowFormAll.Contains(m.sFormCode)) || m.sFormCode == sFormCode)
                             && (iProcessID == 0 || m.idProcess == iProcessID)
                             && (sApp == "1"
                             ? ((sNobr == "" || m.sNobr == sNobr)
                             && dDateAppB <= m.dDateTimeA.GetValueOrDefault(dDate)
                             && m.dDateTimeA.GetValueOrDefault(dDate) <= dDateAppE
                             && m.sState == sState)
                             : (sApp == "2"
                             ? (from s in rsFormAppInfo where m.idProcess == s.idProcess select 1).Any()
                             : (from w in rsFormSignM where m.idProcess == w.idProcess select 1).Any()))
                             orderby m.idProcess
                             select new FlowData
                             {
                                 ProcessID = m.idProcess,
                                 FormName = m.sFormName,
                                 Info = m.sInfo,
                                 Nobr = m.sNobr,
                             };

            lsFlowData = rsFlowData.ToList();
        }
        else
        {
            //審核者
            var rsFormSignM = from w in dcFlow.wfFormSignM
                              where (w.sNobr == sLoginNobr)
                              && dDateSignB <= w.dKeyDate.GetValueOrDefault(dDate)
                              && w.dKeyDate.GetValueOrDefault(dDate) <= dDateSignE
                              select w;

            //被申請人
            var rsFormAppInfo = from s in dcFlow.wfFormAppInfo
                                where (s.sNobr == sLoginNobr)
                                && dDateAppB <= s.dKeyDate.GetValueOrDefault(dDate)
                                && s.dKeyDate.GetValueOrDefault(dDate) <= dDateAppE
                                && s.sState == sState
                                select s;

            //申請人
            var rsFlowData = from m in dcFlow.wfFormApp
                             where ((sFormCode == "0" && lsFlowFormAll.Contains(m.sFormCode)) || m.sFormCode == sFormCode)
                             && (iProcessID == 0 || m.idProcess == iProcessID)
                             && (sApp == "1"
                             ? ((m.sNobr == sLoginNobr)
                             && dDateAppB <= m.dDateTimeA.GetValueOrDefault(dDate)
                             && m.dDateTimeA.GetValueOrDefault(dDate) <= dDateAppE
                             && m.sState == sState)
                             : (sApp == "2"
                             ? (from s in rsFormAppInfo where m.idProcess == s.idProcess select 1).Any()
                             : (from w in rsFormSignM where m.idProcess == w.idProcess select 1).Any()))
                             orderby m.idProcess
                             select new FlowData
                             {
                                 ProcessID = m.idProcess,
                                 FormName = m.sFormName,
                                 Info = m.sInfo,
                                 Nobr = m.sNobr,
                             };

            lsFlowData = rsFlowData.ToList();
        }

        gvAppM.DataSource = lsFlowData;
        gvAppM.DataBind();
    }

    protected void gvAppM_ItemCommand(object sender, GridCommandEventArgs e)
    {
        string cn = e.CommandName;
        string ca = e.CommandArgument.ToString();

        if (cn == "View")
        {
            int id = Convert.ToInt32(ca);

            var rNodeStart = (from pf in dcFlow.ProcessFlow
                              join fn in dcFlow.FlowNode on pf.FlowTree_id equals fn.FlowTree_id
                              join ns in dcFlow.NodeStart on fn.id equals ns.FlowNode_id
                              where pf.id == id
                              && fn.nodeType == "1"
                              select new
                              {
                                  ViewUrl = ns.virtualPath + "/" + ns.viewAp,
                              }).FirstOrDefault();

            if (rNodeStart != null)
            {
                var rProcessApView = (from c in dcFlow.ProcessApView
                                      where c.ProcessFlow_id == id
                                      select c).FirstOrDefault();

                if (rProcessApView != null)
                {
                    string sViewUrl = lblViewUrl.Text + rNodeStart.ViewUrl + "?ApView=" + rProcessApView.auto;
                    RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "window.radopen('" + sViewUrl + "', 'rwMT');", true);
                }
            }
        }
        else if (cn == "Take")
        {
            int id = Convert.ToInt32(ca);

            var rFormApp = (from c in dcFlow.wfFormApp
                            where c.idProcess == id
                            select c).FirstOrDefault();

            var rsFormAppInfo = (from c in dcFlow.wfFormAppInfo
                                 where c.idProcess == id
                                 select c).ToList();

            if (rFormApp != null)
                rFormApp.sState = "7";

            foreach (var rFormAppInfo in rsFormAppInfo)
                rFormAppInfo.sState = "7";

            var rProcessFlow = (from c in dcFlow.ProcessFlow
                                where c.id == id
                                select c).FirstOrDefault();

            var rsProcessNode = (from c in dcFlow.ProcessNode
                                 where c.ProcessFlow_id == id
                                 select c).ToList();

            if (rsProcessNode.Count > 1)
            {
                RadWindowManager1.RadAlert("第一關主管已經審核 不允許抽單", 300, 100, "警告訊息", "", "");
                return;
            }

            if (rProcessFlow != null)
                rProcessFlow.isCancel = true;

            var rForm = (from c in dcFlow.wfForm
                         where c.sFormCode == lblFormCode.Text
                         select c).FirstOrDefault();

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (rForm != null)
                        dcFlow.ExecuteCommand("Update " + rForm.s4 + " Set sState = '7' Where idProcess = {0}", id);

                    dcFlow.SubmitChanges();

                    scope.Complete();
                }
                catch
                {
                    RadWindowManager1.RadAlert("抽單不成功 請稍後再試", 300, 100, "警告訊息", "", "");
                }
            }
        }

        BindData();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }
    protected void gvAppM_ItemDataBound(object sender, GridItemEventArgs e)
    {
        RadButton btnTake = e.Item.FindControl("btnTake") as RadButton;
        if (btnTake != null)
            btnTake.Visible = muState.SelectedItem.Value == "1" && (ckbManage.Visible || lblNobr.Text == btnTake.ToolTip);
    }
}