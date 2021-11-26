using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Performance
{
    public partial class ManageSystemInfo : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
            }

            lblMsg.Text = "";

            ttPassword.TargetControlID = txtPassword.ClientID;
        }

        protected void btnSystemDefault_Click(object sender, EventArgs e)
        {
            var Password = txtPassword.Text;
            if (Password != "確定刪除")
            {
                lblMsg.Text = "請輸入正確密碼";
                return;
            }

            //刪除所有資料表內容
            dcMain.PerformanceBase.DeleteAllOnSubmit(dcMain.PerformanceBase);
            dcMain.PerformanceBaseLog.DeleteAllOnSubmit(dcMain.PerformanceBaseLog);
            dcMain.PerformanceDept.DeleteAllOnSubmit(dcMain.PerformanceDept);
            dcMain.PerformanceDeptRating.DeleteAllOnSubmit(dcMain.PerformanceDeptRating);
            dcMain.PerformanceFlow.DeleteAllOnSubmit(dcMain.PerformanceFlow);
            dcMain.PerformanceFlowNode.DeleteAllOnSubmit(dcMain.PerformanceFlowNode);
            dcMain.PerformanceFlowSign.DeleteAllOnSubmit(dcMain.PerformanceFlowSign);
            dcMain.PerformanceJob.DeleteAllOnSubmit(dcMain.PerformanceJob);
            dcMain.PerformanceMain.DeleteAllOnSubmit(dcMain.PerformanceMain);
            dcMain.PerformanceReportContentDept.DeleteAllOnSubmit(dcMain.PerformanceReportContentDept);
            //dcMain.PerformanceReportTypeDept.DeleteAllOnSubmit(dcMain.PerformanceReportTypeDept);
            //dcMain.PerformanceReportTypeJob.DeleteAllOnSubmit(dcMain.PerformanceReportTypeJob);
            //dcMain.PerformanceScoreLimits.DeleteAllOnSubmit(dcMain.PerformanceScoreLimits);

            dcMain.SubmitChanges();

            lblMsg.Text = "還原成功";
        }
    }
}