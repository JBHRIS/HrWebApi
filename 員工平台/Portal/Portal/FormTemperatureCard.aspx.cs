using Bll.WorkFromHome.Vdb;
using Dal;
using Dal.Dao.WorkFromHome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class FormTemperatureCard : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private bool HaveTemperatureData = false;

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
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            var Ip = WebPage.GetClientIP(Context);
            lblCardIP.Text = Ip;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OldDal.Dao.Att.CardDao oCardDao = new OldDal.Dao.Att.CardDao(dcHR.Connection);
            var DateB = DateTime.Now;
            var TimeB = DateB.ToString("HHmm");
            var Ip = WebPage.GetClientIP(Context);
            lblCardIP.Text = Ip;
            var result = oCardDao.SaveCard(_User.EmpId, DateB, TimeB, "", sKeyMan: "Portal", isLos: false, IP: lblCardIP.Text);

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
                if (Result.Status && result)
                {
                    //lblCardTime.Text = DateB.ToString();
                    lblMsg.CssClass = "badge badge-primary animated shake";
                    lblMsg.Text = "打卡成功";
                }
                else
                {
                    lblMsg.CssClass = "badge badge-danger animated shake";
                    lblMsg.Text = "打卡失敗，請勿在同一分鐘內連續打卡";
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
                var Result = oUpdateTemperoturyReport.GetData(UpdateTemperoturyReportCond);
                if (Result.Status && result)
                {
                    //lblCardTime.Text = DateB.ToString();
                    lblMsg.CssClass = "badge badge-primary animated shake";
                    lblMsg.Text = "打卡成功";
                }
                else
                {
                    lblMsg.CssClass = "badge badge-danger animated shake";
                    lblMsg.Text = "打卡失敗，請勿在同一分鐘內連續打卡";
                }
            }

            CardTime_DataBind();

        }
        public void CardTime_DataBind()
        {
            OldDal.Dao.Att.CardDao oCardDao = new OldDal.Dao.Att.CardDao(dcHR.Connection);
            var CardData = oCardDao.GetData(_User.EmpId, DateTime.Now);
            if (CardData.Count > 0)
            {
                lblCardTime.Text = CardData[CardData.Count - 1].keyDate.ToString();
            }
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

                    if (result[result.Count - 1].Type == "正常")
                        lblCardTime.Text += "<div class=\"text_green_s\"> 體溫正常</div>";
                    else
                        lblCardTime.Text += "<div class=\"text_red_s\"> 體溫不正常</div>";
                }
            }
        }
    }
}