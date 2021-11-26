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
    public partial class FormFlowImage : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idProcess"] != null)
                {
                    int RequestValue = 0;
                    RequestValue = Convert.ToInt32(UnobtrusiveSession.Session["idProcess"].ToString());

                    var oFlowImage = new FlowImageDao();
                    var FlowImageCond = new FlowImageConditions();
                    FlowImageCond.AccessToken = _User.AccessToken;
                    FlowImageCond.RefreshToken = _User.RefreshToken;
                    FlowImageCond.CompanySetting = CompanySetting;
                    FlowImageCond.idProcess = RequestValue;
                    var Result = oFlowImage.GetData(FlowImageCond);
                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            var result = Result.Data as FlowImageRow;
                            img.ImageUrl = result.result;
                        }
                    }
                }
                string RequestName = "";
                RequestName = UnobtrusiveSession.Session["RequestName"].ToString();
                if (RequestName == "View")
                {
                    btnReturn.Visible = true;
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            string ProcessID = UnobtrusiveSession.Session["ProcessID"] as string;
            string EmpID = UnobtrusiveSession.Session["EmpID"] as string;
            string Role = UnobtrusiveSession.Session["Role"] as string;
            string DateB = UnobtrusiveSession.Session["DateB"] as string;
            string DateE = UnobtrusiveSession.Session["DateE"] as string;
            string State = UnobtrusiveSession.Session["State"] as string;
            string FormsCode = UnobtrusiveSession.Session["FormsCode"] as string;
            string Dept = UnobtrusiveSession.Session["Dept"] as string;

            if (ProcessID != null && EmpID != null && Role != null && DateB != null && DateE != null && State != null && FormsCode != null && Dept != null)
            {
                string Parameter = "?ProcessID=" + ProcessID + "&EmpID=" + EmpID + "&Role=" + Role + "&DateB=" + DateB
                    + "&DateE=" + DateE + "&State=" + State + "&FormsCode=" + FormsCode + "&Dept=" + Dept;
                Response.Redirect("FormFlowView.aspx" + Parameter);

            }
            else
            {
                Response.Redirect("FormFlowView.aspx");
            }
        }
    }
}