using Bll.Flow.Vdb;
using Dal.Dao.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class FormAppointFlow : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lvAppointView_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var oFormsAppAppointForHRDao = new FormsAppAppointForHRDao();
            var FormsAppAppointForHRCond = new FormsAppAppointForHRConditions();
            FormsAppAppointForHRCond.AccessToken = _User.AccessToken;
            FormsAppAppointForHRCond.RefreshToken = _User.RefreshToken;
            FormsAppAppointForHRCond.CompanySetting = CompanySetting;
            var rsAppointView = oFormsAppAppointForHRDao.GetData(FormsAppAppointForHRCond);
            if (rsAppointView.Status && rsAppointView.Data != null)
            {
                var rs = rsAppointView.Data as List<FormsAppAppointForHRRow>;
                if (rs != null)
                {
                    lvAppointView.DataSource = rs;
                }
            }
        }

        protected void lvAppointView_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            string ca = e.CommandArgument.ToString();

            UnobtrusiveSession.Session["ProcessApParmAuto"] = ca;
            UnobtrusiveSession.Session["RequestName"] = "ApParm";
            string TurnUrl = "";
            //string TurnUrl = "Form" + cn + "Chk.aspx?";
            //string ParmUrl = TurnUrl + "ProcessApParmAuto=" + ca;
            //if (cn == "OvtB")
            //{
            //    TurnUrl = "Form" + cn + "Chk2.aspx?";
            //}

            var oFormGetFlowParmUrlDao = new FormGetFlowParmUrlDao();
            var FormGetFlowParmUrlCond = new FormGetFlowParmUrlConditions();
            FormGetFlowParmUrlCond.AccessToken = _User.AccessToken;
            FormGetFlowParmUrlCond.RefreshToken = _User.RefreshToken;
            FormGetFlowParmUrlCond.CompanySetting = CompanySetting;
            FormGetFlowParmUrlCond.bOnlyUrl = true;
            FormGetFlowParmUrlCond.iApParmID = Convert.ToInt32(ca);

            var rsFormGetFlowParmUrl = oFormGetFlowParmUrlDao.GetData(FormGetFlowParmUrlCond);
            var rFormGetFlowParmUrl = new FormGetFlowParmUrlRow();
            if (rsFormGetFlowParmUrl.Status)
            {
                if (rsFormGetFlowParmUrl.Data != null)
                {
                    rFormGetFlowParmUrl = rsFormGetFlowParmUrl.Data as FormGetFlowParmUrlRow;

                }
                TurnUrl = rFormGetFlowParmUrl.Url + "?";
            }

            //Response.Write("<script>window.open('" + ParmUrl + "','_blank')</script>");
            //var Script = "window.open('" + ParmUrl + "','_blank')";
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "title", Script, true);
            Response.Redirect(TurnUrl + "ProcessApParmAuto=" + ca);
        }
    }
}