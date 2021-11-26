using Bll.Attendance.Vdb;
using Bll.Employee.Vdb;
using Bll.Token.Vdb;
using Dal.Dao.Attendance;
using Bll.WorkFromHome.Vdb;
using Dal.Dao.WorkFromHome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Calendar.View;

namespace Portal
{
    public partial class EmployeeAttendCalendar : WebPageBase
    {
        public DateTime Begin;
        public string Name;
        protected void Page_Load(object sender, EventArgs e)
        {
            Begin = DateTime.Now;
            if (!this.IsPostBack)
            {

                UnobtrusiveSession.Session["Calendar"] = null;
                Name = _User.UserCode;
                lblDate.Text = DateTime.Now.ToShortDateString();
                List<string> employeeList = new List<string>();
                employeeList.Add(Name);


                cldAttend.FocusedDate = Convert.ToDateTime(lblDate.Text);
                cldAttend.SelectedDate = Convert.ToDateTime(lblDate.Text);

                LoadData(_User.UserCode);
                ddl_DataBind();
                cblAttendType_DataBind();
            }

        }

        public void LoadData(string Key = "")
        {

        }

        public void ddl_DataBind()
        {
            var rs = AccessData.GetSearchListEmp(_User, CompanySetting);

            ddlEmp.DataSource = rs;
            ddlEmp.DataTextField = "Text";
            ddlEmp.DataValueField = "Value";
            ddlEmp.DataBind();

            if (ddlEmp.Items.FindItemByValue(_User.EmpId) != null)
                ddlEmp.Items.FindItemByValue(_User.EmpId).Selected = true;
        }

        public void cblAttendType_DataBind()
        {
            var rs = new List<AttendTypeRow>();

            AttendTypeDao oAttendType = new AttendTypeDao();
            AttendTypeConditions AttendTypeCond = new AttendTypeConditions();
            AttendTypeCond.AccessToken = _User.AccessToken;
            AttendTypeCond.RefreshToken = _User.RefreshToken;
            AttendTypeCond.CompanySetting = CompanySetting;
            var Result = oAttendType.GetData(AttendTypeCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<AttendTypeRow>;
                }
            }
            var AttendRow = new AttendTypeRow();
            AttendRow.Name = "分流班別";
            AttendRow.Code = "Diversion";
            rs.Add(AttendRow);

            cblAttendType.DataSource = rs;
            cblAttendType.DataBindings.DataTextField = "Name";
            cblAttendType.DataBindings.DataValueField = "Code";
            cblAttendType.DataBind();

            foreach (ButtonListItem r in cblAttendType.Items)
            {
                r.Selected = true;
            }
        }

        public List<CalendarRow> ListCalendar
        {
            get
            {
                var Value = new List<CalendarRow>();
                DateTime dateB = new DateTime(cldAttend.SelectedDate.Year, cldAttend.SelectedDate.Month, 1).AddDays(-11);
                DateTime dateE = new DateTime(cldAttend.SelectedDate.Year, cldAttend.SelectedDate.Month, DateTime.DaysInMonth(cldAttend.SelectedDate.Year, cldAttend.SelectedDate.Month)).AddDays(+11);
                if (WebPage.DataCache && UnobtrusiveSession.Session["Calendar"] != null)
                {
                    Value = (List<CalendarRow>)UnobtrusiveSession.Session["Calendar"];
                }
                else
                {
                    CalendarDao oCalendarDao = new CalendarDao();
                    CalendarConditions CalendarCond = new CalendarConditions();
                    CalendarCond.AccessToken = _User.AccessToken;
                    CalendarCond.RefreshToken = _User.RefreshToken;
                    CalendarCond.CompanySetting = CompanySetting;
                    CalendarCond.employeeList = new List<string>();
                    CalendarCond.employeeList.Add(ddlEmp.SelectedValue);
                    CalendarCond.attendTypeList = cblAttendType.Items.Cast<ButtonListItem>().Where(p => p.Selected).Select(p => p.Value).ToList();

                    CalendarCond.dateBegin = dateB;
                    CalendarCond.dateEnd = dateE;
                    //呼叫API
                    APIResult Result = oCalendarDao.GetData(CalendarCond, _User.AccessToken);
                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            Value = Result.Data as List<CalendarRow>;
                        }
                    }

                    Value = Value.OrderBy(p => p.Sort).ToList();

                    UnobtrusiveSession.Session["Calendar"] = Value;
                }
                var End = DateTime.Now;
                TotalTime.Text = (End - Begin).ToString();
                return Value;
            }
        }

        public List<DiversionShiftAttendReportRow> ListDiversion
        {
            get
            {
                var Value = new List<DiversionShiftAttendReportRow>();
                if (WebPage.DataCache && UnobtrusiveSession.Session["Diversion"] != null)
                {
                    Value = (List<DiversionShiftAttendReportRow>)UnobtrusiveSession.Session["Diversion"];
                }
                else
                {
                    DateTime dateB = new DateTime(cldAttend.SelectedDate.Year, cldAttend.SelectedDate.Month, 1).AddDays(-11);
                    DateTime dateE = new DateTime(cldAttend.SelectedDate.Year, cldAttend.SelectedDate.Month, DateTime.DaysInMonth(cldAttend.SelectedDate.Year, cldAttend.SelectedDate.Month)).AddDays(+11);

                    var oDiversionShiftAttendReportDao = new DiversionShiftAttendReportDao();
                    var DiversionShiftAttendReportCond = new DiversionShiftAttendReportConditions();
                    DiversionShiftAttendReportCond.AccessToken = _User.AccessToken;
                    DiversionShiftAttendReportCond.RefreshToken = _User.RefreshToken;
                    DiversionShiftAttendReportCond.CompanySetting = CompanySetting;
                    DiversionShiftAttendReportCond.employeeList = new List<string>();
                    DiversionShiftAttendReportCond.employeeList.Add(ddlEmp.SelectedValue);
                    DiversionShiftAttendReportCond.dateBegin = dateB;
                    DiversionShiftAttendReportCond.dateEnd = dateE;
                    var DiversionResult = oDiversionShiftAttendReportDao.GetData(DiversionShiftAttendReportCond);
                    if (DiversionResult.Status && DiversionResult.Data != null)
                    {
                        var rsDiversion = DiversionResult.Data as List<DiversionShiftAttendReportRow>;
                        if (rsDiversion != null)
                            Value = rsDiversion;
                    }
                }
                UnobtrusiveSession.Session["Diversion"] = Value;
                return Value;
            }
        }

        protected void cldAttend_DayRender(object sender, Telerik.Web.UI.Calendar.DayRenderEventArgs e)
        {
            var Day = e.Day.Date;
            var rs = ListCalendar.Where(p => p.AttendDate == Day).ToList();
            var DiversionData = ListDiversion.Where(p => p.Date == Day).ToList();

            var AttendData = cblAttendType.Items.Cast<ButtonListItem>().Where(p => p.Selected).Select(p => p.Value).ToList();
            var Html = "<div class=\"kdate\">";
            Html += "<p class=\"kdateNum\">" + e.Day.Date.Day.ToString() + "</p>";
            var Position = true;
            var IsWorkDay = false;   //是否工作日
            var IsAttend = false;    //是否在出勤下面
            foreach (var r in rs)
            {
                var Body = r.Name;

                
                switch (r.AttendTypeCode)
                {
                    case "Attend":
                        if (r.TimeB != "" || r.TimeE != "") 
                        {
                            //Body = "班別時間";
                            Body += r.TimeB + "-" + r.TimeE;
                            IsWorkDay = true;
                            IsAttend = true;
                        }
                        Body = "<p class=\"btn-info\">" + Body + "</p>";
                        break;
                    case "Card":
                        if (r.TimeB != "" || r.TimeE != "" || IsWorkDay)
                        {
                            Body = "";
                            Body += (r.TimeB != "" ? r.TimeB : "____") + "-" + (r.TimeE != "" ? r.TimeE : "____");
                            Body = "<p class=\"btn-success \">" + Body + "</p>";
                        }
                        else
                            continue;
                        break;
                    case "Abs":
                        if (r.TimeB != "" || r.TimeE != null)
                        {

                            Body += "(" + decimal.ToDouble(r.Use) + ")";
                            //Body += r.TimeB + "-" + r.TimeE;
                            Body = "<p class=\"green " + (Position ? "float-left" : "float-right") + "\"><abbr title=\"" + r.TimeB + "-" + r.TimeE + "\"/>" + Body + "</p>";
                            Position = !Position;
                        }
                        else
                            continue;
                        break;
                    case "Ot":
                        if (r.TimeB != "" || r.TimeE != null)
                        {
                            Body += "(" + decimal.ToDouble(r.Use) + ")";
                            //Body += r.TimeB + "-" + r.TimeE;
                            Body = "<p class=\"orange " + (Position ? "float-left" : "float-right") + "\"><abbr title=\"" + r.TimeB + "-" + r.TimeE + "\"/>" + Body + "</p>";
                            Position = !Position;
                        }
                        else
                            continue;
                        break;
                    //case "Abnormal":
                    default:
                        //if (r.TimeB != "" || r.Use > 0)
                        if (r.TimeB != "" || r.TimeE != null)
                        {
                            if (Body != "曠職" && Body != "忘刷")
                                Body += "(" + decimal.ToInt32(r.Use) + ")";
                            //Body += r.Use.ToString();
                            Body = "<p class=\"red " + (Position ? "float-left" : "float-right") + "\">" + Body + "</p>";
                            Position = !Position;
                        }
                        else
                            continue;
                        break;
                }

                Html += Body;
                if (IsWorkDay && IsAttend && ((rs.Count > 1 && rs[1].Name != "刷卡") || rs.Count <= 1) && AttendData.Contains("AttendType_Card"))//如果是工作日、在班別之下、是否有刷卡資料、是否有取得刷卡的條件、才會跑出資料
                {
                    IsAttend = false;
                    var Data = "";
                    Data += "____-____";
                    Data = "<p class=\"btn-success \">" + Data + "</p>";
                    Html += Data;
                }
            }
            if (DiversionData.Any() && AttendData.Contains("Diversion"))
            {
                if (DiversionData[0].DiversionGroupName != "" && DiversionData[0].DiversionGroupName != null && DiversionData[0].DiversionTypeName != "" && DiversionData[0].DiversionTypeName != null)
                    Html += "<p class=\"purple " + (Position ? "float-left" : "float-right") + "\">" + DiversionData[0].DiversionGroupName + " : " + DiversionData[0].DiversionTypeName + "</p>";
            }
            Html += "</div>";
            e.Cell.Text = Html;
        }

        protected void cldAttend_DefaultViewChanged(object sender, Telerik.Web.UI.Calendar.DefaultViewChangedEventArgs e)
        {
            lblDate.Text = ((MonthView)e.NewView).MonthStartDate.ToShortDateString();
            cldAttend.FocusedDate = Convert.ToDateTime(lblDate.Text);
            cldAttend.SelectedDate = Convert.ToDateTime(lblDate.Text);
            UnobtrusiveSession.Session["Calendar"] = null;
            UnobtrusiveSession.Session["Diversion"] = null;
        }

        protected void cldAttend_SelectionChanged(object sender, Telerik.Web.UI.Calendar.SelectedDatesEventArgs e)
        {
            cldAttend.FocusedDate = Convert.ToDateTime(lblDate.Text);
            cldAttend.SelectedDate = Convert.ToDateTime(lblDate.Text);
            UnobtrusiveSession.Session["Calendar"] = null;
            UnobtrusiveSession.Session["Diversion"] = null;

        }

        protected void cblAttendType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnobtrusiveSession.Session["Calendar"] = null;
            UnobtrusiveSession.Session["Diversion"] = null;

        }

        protected void ddlEmp_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            UnobtrusiveSession.Session["Calendar"] = null;
            UnobtrusiveSession.Session["Diversion"] = null;

        }
    }
}