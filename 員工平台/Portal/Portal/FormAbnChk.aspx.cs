using Bll.Flow.Vdb;
using Dal;
using Dal.Dao.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class FormAbnChk : WebPageBase
    {
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private bool isView = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (UnobtrusiveSession.Session["RequestName"].ToString() == "View")
                isView = true;
            if (!IsPostBack)
            {
                if (Request.QueryString["ProcessApParmAuto"] != null)
                {
                    int RequestValue = 0;
                    RequestValue = Convert.ToInt32(UnobtrusiveSession.Session["ProcessApParmAuto"].ToString());

                    var rsProcessFlowID = (from c in dcFlow.ProcessApParm
                                           where c.auto == RequestValue
                                           select c).FirstOrDefault();


                    if (rsProcessFlowID != null)
                        lblProcessID.Text = rsProcessFlowID.ProcessFlow_id.ToString();
                }
                else if (Request.QueryString["ProcessApViewAuto"] != null)
                {
                    int RequestValue = 0;
                    RequestValue = Convert.ToInt32(UnobtrusiveSession.Session["ProcessApViewAuto"].ToString());

                    var rsProcessFlowID = (from c in dcFlow.ProcessApView
                                           where c.auto == RequestValue
                                           select c).FirstOrDefault();


                    if (rsProcessFlowID != null)
                        lblProcessID.Text = rsProcessFlowID.ProcessFlow_id.ToString();
                }
                gvAppS.Rebind();
            }
        }
        protected void gvAppS_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var oFormAppAbnDao = new FormsAppAbnByProcessIdDao();
            var FormAppAbnCond = new FormsAppAbnByProcessIdConditions();

            FormAppAbnCond.AccessToken = _User.AccessToken;
            FormAppAbnCond.RefreshToken = _User.RefreshToken;
            FormAppAbnCond.CompanySetting = CompanySetting;
            FormAppAbnCond.ProcessFlowID = lblProcessID.Text;
            FormAppAbnCond.Sign = true;
            FormAppAbnCond.SignState = "";
            FormAppAbnCond.Status = UnobtrusiveSession.Session["RequestName"].ToString() == "View" ? "" : "1";

            var rsFormAppAbn = oFormAppAbnDao.GetData(FormAppAbnCond);
            var rFormAppAbn = new FormsAppAbnByProcessIdRow();
            if (rsFormAppAbn.Status)
            {
                if (rsFormAppAbn.Data != null)
                {
                    rFormAppAbn = rsFormAppAbn.Data as FormsAppAbnByProcessIdRow;
                    if (rFormAppAbn.FlowApps.Count() != 0)
                    {
                        
                        gvAppS.DataSource = rFormAppAbn.FlowApps;
                        Session["ProcessID"] = lblProcessID.Text;
                    }
                }
            }
        }

        protected void btnCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadButtonList rsButtonList = sender as RadButtonList;
            var ca = rsButtonList.FeatureGroupID;

            var rs = (from c in dcFlow.FormsAppAbn
                      where c.AutoKey.ToString() == ca
                      select c).FirstOrDefault();

            var btnCheck = sender as RadRadioButtonList;

            if (rs != null)
            {
                if (btnCheck.SelectedValue == "2")
                {
                    rs.SignState = "2";
                    rs.Sign = false;
                }
                if (btnCheck.SelectedValue == "1")
                {
                    rs.SignState = "1";
                    rs.Sign = true;
                }

                dcFlow.SubmitChanges();
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var cn = ((RadButton)sender).CommandName;
            var ca = ((RadButton)sender).CommandArgument;
            UnobtrusiveSession.Session["FileTicket"] = (from c in dcFlow.FormsAppAbn
                                                        where c.AutoKey.ToString() == ca
                                                        select c.Code).FirstOrDefault();

            ucFileView._lblKey.Text = ca;
            ucFileView._lvMain.Rebind();
        }

        protected void gvAppS_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
            RadRadioButtonList rdblSign = e.Item.FindControl("btnCheck") as RadRadioButtonList;
            if (isView)
            {
                rdblSign.Visible = false;
                return;
            }
            if (rdblSign != null)
            {
                foreach (ButtonListItem list in rdblSign.Items)
                {
                    if (rdblSign.ToolTip == "1")
                    {
                        if (list.Value == "1")
                            list.Selected = true;
                    }
                    if (rdblSign.ToolTip == "2")
                    {
                        if (list.Value == "2")
                            list.Selected = true;
                    }
                }
            }
        }
    }
}