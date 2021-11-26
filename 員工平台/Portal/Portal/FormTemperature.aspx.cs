using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal.Dao.WorkFromHome;
using Bll.WorkFromHome.Vdb;

namespace Portal
{
    public partial class FormTemperature : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private bool HaveTemperatureData = false;
        private int AutoKey = 0;
        private Guid Guid = Guid.NewGuid();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcHR.Connection.ConnectionString = CompanySetting.ConnHr;
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (!IsPostBack)
            {
                CardTime_DataBind();
            }
            //lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            //var Ip = WebPage.GetClientIP(Context);
            //lblCardIP.Text = Ip;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CardTime_DataBind();

            if (!HaveTemperatureData) // 如果沒有溫度資料則新增，否則更新
            {
                var oInsertTemperoturyReport = new InsertTemperoturyReportDao();
                var InsertTemperoturyReportCond = new InsertTemperoturyReportConditions();
                InsertTemperoturyReportCond.AccessToken = _User.AccessToken;
                InsertTemperoturyReportCond.RefreshToken = _User.RefreshToken;
                InsertTemperoturyReportCond.CompanySetting = CompanySetting;
                InsertTemperoturyReportCond.AttendDate = DateTime.Now.Date;
                InsertTemperoturyReportCond.EmployeeId = _User.EmpId;
                InsertTemperoturyReportCond.EmployeeName = _User.EmpName;
                InsertTemperoturyReportCond.KeyMan = _User.EmpName;
                InsertTemperoturyReportCond.ReportType = btnRadioNormal.Checked ? "1" : "2";
                InsertTemperoturyReportCond.Temperotury = 0;
                var Result = oInsertTemperoturyReport.GetData(InsertTemperoturyReportCond);
                if (Result.Status)
                {
                    lblMsg.CssClass = "badge badge-primary animated shake";
                    lblMsg.Text = "確認成功";
                }
                else
                {
                    lblMsg.CssClass = "badge badge-danger animated shake";
                    lblMsg.Text = "確認失敗";
                }
            }

            else
            {
                var oUpdateTemperoturyReport = new UpdateTemperoturyReportDao();
                var UpdateTemperoturyReportCond = new UpdateTemperoturyReportConditions();
                UpdateTemperoturyReportCond.AccessToken = _User.AccessToken;
                UpdateTemperoturyReportCond.RefreshToken = _User.RefreshToken;
                UpdateTemperoturyReportCond.CompanySetting = CompanySetting;
                UpdateTemperoturyReportCond.AttendDate = DateTime.Now.Date;
                UpdateTemperoturyReportCond.EmployeeId = _User.EmpId;
                UpdateTemperoturyReportCond.EmployeeName = _User.EmpName;
                UpdateTemperoturyReportCond.KeyMan = _User.EmpName;
                UpdateTemperoturyReportCond.ReportType = btnRadioNormal.Checked ? "1" : "2";
                UpdateTemperoturyReportCond.Temperotury = 0;
                UpdateTemperoturyReportCond.AutoKey = AutoKey;
                UpdateTemperoturyReportCond.Guid = Guid;
                var Result = oUpdateTemperoturyReport.GetData(UpdateTemperoturyReportCond);
                if (Result.Status)
                {
                    lblMsg.CssClass = "badge badge-primary animated shake";
                    lblMsg.Text = "確認成功";
                }
                else
                {
                    lblMsg.CssClass = "badge badge-danger animated shake";
                    lblMsg.Text = "確認失敗";
                }
            }

            CardTime_DataBind();
        }

        protected void CardTime_DataBind()
        {
            var EmpList = new List<string>();
            EmpList.Add(_User.EmpId);
            var oTemperoturyReport = new TemperoturyReportDao();
            var TemperoturyReportCond = new TemperoturyReportConditions();
            TemperoturyReportCond.AccessToken = _User.AccessToken;
            TemperoturyReportCond.RefreshToken = _User.RefreshToken;
            TemperoturyReportCond.CompanySetting = CompanySetting;
            TemperoturyReportCond.employeeList = EmpList;
            TemperoturyReportCond.dateBegin = DateTime.Now.Date;
            TemperoturyReportCond.dateEnd = DateTime.Now.AddDays(1).AddSeconds(-1).Date;
            var Result = oTemperoturyReport.GetData(TemperoturyReportCond);
            if (Result.Status && Result.Data != null)
            {
                var result = Result.Data as List<TemperoturyReportRow>;
                if (result.Count > 0)
                {
                    HaveTemperatureData = true;
                    lblCardTime.Text = result[result.Count - 1].Date.ToString("yyyy/MM/dd");
                    AutoKey = result[result.Count - 1].AutoKey;
                    Guid = result[result.Count - 1].Guid;
                    if (result[result.Count - 1].Type == "正常")
                        lblTemp.Text = "<div class=\"text_green_s\"> 體溫正常</div>";
                    else
                        lblTemp.Text = "<div class=\"text_red_s\"> 體溫不正常</div>";
                }
            }
        }

    }
}