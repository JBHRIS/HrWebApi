﻿using Bll.Flow.Vdb;
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
    public partial class FormShiftShortChk : WebPageBase
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
            }
        }
        protected void gvAppS_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var oFormAppShiftShortDao = new FormAppShiftShortDao();
            var FormAppShiftShortCond = new FormAppShiftShortConditions();

            FormAppShiftShortCond.AccessToken = _User.AccessToken;
            FormAppShiftShortCond.RefreshToken = _User.RefreshToken;
            FormAppShiftShortCond.CompanySetting = CompanySetting;
            FormAppShiftShortCond.ProcessFlowID = lblProcessID.Text;
            FormAppShiftShortCond.Sign = true;
            FormAppShiftShortCond.SignState = "";
            FormAppShiftShortCond.Status = UnobtrusiveSession.Session["RequestName"].ToString() == "View" ? "" : "1";

            var rsFormAppShiftShort = oFormAppShiftShortDao.GetData(FormAppShiftShortCond);
            var rFormAppShiftShort = new List<FormAppShiftShortRow>();
            if (rsFormAppShiftShort.Status)
            {
                if (rsFormAppShiftShort.Data != null)
                {
                    rFormAppShiftShort = rsFormAppShiftShort.Data as List<FormAppShiftShortRow>;
                    if (rFormAppShiftShort.Count() != 0)
                    {
                        gvAppS.DataSource = rFormAppShiftShort;
                        Session["ProcessID"] = lblProcessID.Text;
                    }
                }
            }
        }

        protected void btnCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadButtonList rsButtonList = sender as RadButtonList;
            var ca = rsButtonList.FeatureGroupID;

            var rs = (from c in dcFlow.FormsAppShiftShort
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
            UnobtrusiveSession.Session["FileTicket"] = (from c in dcFlow.FormsAppShiftShort
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
                txtNote.Enabled = false;
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
        protected void lvSignM_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rsSignM = (from c in dcFlow.FormsSign
                           where c.idProcess == Convert.ToInt32(lblProcessID.Text)
                           select c).ToList();

            lvSignM.DataSource = rsSignM;
        }
    }
}