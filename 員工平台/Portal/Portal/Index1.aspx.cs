using System;
using Bll.Index.Vdb;
using Bll.BillBoard.Vdb;
using Dal.Dao.BillBoard;
using Bll.AbsenceView.Vdb;
using Dal.Dao.AbsenceView;
using Dal.Dao.Attendance;
using Bll.Attendance.Vdb;
using Bll.OverTimeView.Vdb;
using Dal.Dao.OverTimeView;
using Bll.AbnormalView.Vdb;
using Dal.Dao.AbnormalView;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal.Dao.Flow;
using Bll.Flow.Vdb;

namespace Portal
{
    public partial class Index1 : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                index_DataBind();
            }
        }
        public void index_DataBind()
        {
            var oIndex = new IndexRow();
            var ListLeaveCode = new List<string>();
            ListLeaveCode.Add("W");//取得特休資訊
            ListLeaveCode.Add("W4");//取得補休資訊
            var ListEmpId = new List<string>();
            ListEmpId.Add(_User.EmpId);
            var DateB = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var DateE = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            if (WebPage.DataCache && UnobtrusiveSession.Session["indexData"] != null)
            {
                oIndex = (IndexRow)UnobtrusiveSession.Session["indexData"];
            }
            else
            {
                #region 公佈欄
                var BillboardsCond = new BillboardsConditions();
                var oBillboards = new BillboardsDao();
                BillboardsCond.AccessToken = _User.AccessToken;
                BillboardsCond.RefreshToken = _User.RefreshToken;
                BillboardsCond.CompanySetting = CompanySetting;
                var ResultBillBoards = oBillboards.GetData(BillboardsCond);//公佈欄載入
                if (ResultBillBoards.Status)
                {
                    if (ResultBillBoards.Data != null)
                    {
                        var rs = ResultBillBoards.Data as List<BillboardsRow>;
                        int count = rs.Count <= 5 ? rs.Count : 5;
                        for (int i = 0; i < count; i++)
                        {
                            if (rs[i] != null)
                            {
                                var rBillBoard = new IndexRow.BillBoard();
                                rBillBoard.idNO = rs[i].AutoKey;
                                rBillBoard.Title = rs[i].NewsTitle;
                                rBillBoard.Content = rs[i].NewsContent;
                                rBillBoard.PublishTime = rs[i].NewsDate;
                                rBillBoard.KeyName = rs[i].InsertMan;
                                if (rBillBoard.Title.Length > 18)
                                {
                                    rBillBoard.Title = rBillBoard.Title.Substring(0, 18);
                                    rBillBoard.Title += "...";
                                }
                                oIndex.BillBoardList.Add(rBillBoard);
                            }
                        }
                    }
                }

                #endregion

                #region 餘假資料載入
                var oAbsenceEntitleView = new AbsenceEntitleViewDao();
                var AbsenceEntitleViewCond = new AbsenceEntitleViewConditions();

                AbsenceEntitleViewCond.AccessToken = _User.AccessToken;
                AbsenceEntitleViewCond.RefreshToken = _User.RefreshToken;
                AbsenceEntitleViewCond.CompanySetting = CompanySetting;
                AbsenceEntitleViewCond.leaveCodeList = ListLeaveCode;
                AbsenceEntitleViewCond.employeeList = ListEmpId;
                AbsenceEntitleViewCond.dateBegin = DateB;
                AbsenceEntitleViewCond.dateEnd = DateE;

                var ResultAbsence = oAbsenceEntitleView.GetData(AbsenceEntitleViewCond);

                if (ResultAbsence.Status)
                {
                    if (ResultAbsence.Data != null)
                    {
                        var rs = ResultAbsence.Data as List<AbsenceEntitleViewRow>;
                        foreach (var r in rs)
                        {
                            if (r.AbsName == "特休(得)")
                            {
                                oIndex.SpecialLeave.LeaveName = r.AbsName;
                                oIndex.SpecialLeave.RemainHour = r.Remaining;
                                oIndex.SpecialLeave.TotalHour = r.Entitle;
                                oIndex.SpecialLeave.UseHour = r.Leaved;
                                oIndex.SpecialLeave.ExpiryDate = r.ExpirationDate;
                            }
                            if (r.AbsName == "補休(得)")
                            {
                                oIndex.CompensatoryLeave.LeaveName = r.AbsName;
                                oIndex.CompensatoryLeave.RemainHour = r.Remaining;
                                oIndex.CompensatoryLeave.TotalHour = r.Entitle;
                                oIndex.CompensatoryLeave.UseHour = r.Leaved;
                                oIndex.CompensatoryLeave.ExpiryDate = r.ExpirationDate;
                            }
                        }
                    }
                }

                #endregion

                #region 加班時數
                var oOverTimeView = new OverTimeViewDao();
                var OverTimeViewCond = new OverTimeViewConditions();
                OverTimeViewCond.AccessToken = _User.AccessToken;
                OverTimeViewCond.RefreshToken = _User.RefreshToken;
                OverTimeViewCond.CompanySetting = CompanySetting;
                OverTimeViewCond.employeeList = ListEmpId;
                OverTimeViewCond.dateBegin = DateB;
                OverTimeViewCond.dateEnd = DateE;
                var ResultOt = oOverTimeView.GetData(OverTimeViewCond);
                if (ResultOt.Status)
                {
                    if (ResultOt.Data != null)
                    {
                        var rs = ResultOt.Data as List<OverTimeViewRow>;
                        foreach (var c in rs)
                        {
                            oIndex.OtHoursDateRangeList.OverTimeHours += Convert.ToDouble(c.TotalTime);
                        }
                    }
                }


                #endregion

                #region 異常資訊
                var DeptEmpList = AccessData.GetDeptListEmp(_User, CompanySetting);
                var DeptList = new List<string>();
                foreach (var d in DeptEmpList)
                {
                    DeptList.Add(d.Value);
                }
                CalendarDao oCalendarDto = new CalendarDao();
                CalendarConditions CalendarCond = new CalendarConditions();
                CalendarCond.AccessToken = _User.AccessToken;
                CalendarCond.RefreshToken = _User.RefreshToken;
                CalendarCond.CompanySetting = CompanySetting;
                CalendarCond.employeeList = DeptList;
                CalendarCond.dateBegin = DateTime.Now.AddDays(-1).Date;
                CalendarCond.dateEnd = DateTime.Now.AddDays(-1).Date;
                CalendarCond.attendTypeList = new List<string>();
                CalendarCond.attendTypeList.Add("AttendType_Abnormal");
                //var oAbnormalView = new AbnormalViewDao();
                //var AbnormalViewCond = new AbnormalViewConditions();
                //AbnormalViewCond.AccessToken = _User.AccessToken;
                //AbnormalViewCond.RefreshToken = _User.RefreshToken;
                //AbnormalViewCond.isCheck = false;
                //AbnormalViewCond.employeeList = DeptList;
                //AbnormalViewCond.dateBegin = DateTime.Now.AddDays(-1).Date;
                //AbnormalViewCond.dateEnd = DateTime.Now.AddDays(-1).Date;
                var ResultAbn = oCalendarDto.GetData(CalendarCond, _User.AccessToken);
                if (ResultAbn.Status)
                {
                    if (ResultAbn.Data != null)
                    {
                        var rs = ResultAbn.Data as List<CalendarRow>;
                        var rsAbn = rs.GroupBy(p => p.EmpId);
                        oIndex.YesterdayAbnormal.AbnormalCount = rsAbn.Count();
                        //lblAbnYesterday.Text = rsAbn.Count().ToString();

                    }

                }
                CalendarCond.AccessToken = _User.AccessToken;
                CalendarCond.RefreshToken = _User.RefreshToken;
                CalendarCond.dateBegin = DateTime.Now.Date;
                CalendarCond.dateEnd = DateTime.Now;
                ResultAbn = oCalendarDto.GetData(CalendarCond, _User.AccessToken);
                if (ResultAbn.Status)
                {
                    if (ResultAbn.Data != null)
                    {
                        var rs = ResultAbn.Data as List<CalendarRow>;
                        var rsAbn = rs.GroupBy(p => p.EmpId);
                        oIndex.TodayAbnormal.AbnormalCount = rsAbn.Count();
                        //lblAbnToday.Text = rsAbn.Count().ToString();
                    }

                }
                var oAttendDetail = new AttendDetailDao();
                var AttendDetailCond = new AttendDetailConditions();
                AttendDetailCond.AccessToken = _User.AccessToken;
                AttendDetailCond.RefreshToken = _User.RefreshToken;
                AttendDetailCond.CompanySetting = CompanySetting;
                AttendDetailCond.employeeList = ListEmpId;
                AttendDetailCond.attendTypeList = new List<string>();
                AttendDetailCond.dateBegin = DateTime.Now.Date;
                AttendDetailCond.dateEnd = DateTime.Now;

                var Result = oAttendDetail.GetData(AttendDetailCond);

                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        var rs = Result.Data as List<AttendDetailRow>;
                        foreach (var r in rs)
                        {
                            oIndex.TodayWorkTime.OnTime = r.RoteTimeB;
                            oIndex.TodayWorkTime.OffTime = r.RoteTimeE;
                            oIndex.RoteName = r.RoteName;
                        }
                    }
                }
                #endregion
                UnobtrusiveSession.Session["indexData"] = oIndex;
            }
            #region 資料載入
            lvBillBoard.DataSource = oIndex.BillBoardList;
            lvBillBoard.DataBind();

            if (oIndex.SpecialLeave.LeaveName != "" && oIndex.SpecialLeave.LeaveName != null)
            {
                lblSpecialLeave.Text = oIndex.SpecialLeave.RemainHour;
                lblSpecialLeaveDate.Text = oIndex.SpecialLeave.ExpiryDate.ToString("yyyy/MM/dd");
                lblSpecialLeaveTotal.Text = oIndex.SpecialLeave.TotalHour;
                var barWidth = Convert.ToDouble(lblSpecialLeave.Text) / Convert.ToDouble(lblSpecialLeaveTotal.Text);
                barWidth *= 100;
                lblSpecialLeaveBar.Style.Add(HtmlTextWriterStyle.Width, barWidth.ToString() + "%");
            }
            else
            {
                lblSpecialLeave.Text = "0";
                lblSpecialLeaveDate.Text = "";
                lblSpecialLeaveTotal.Text = "0";
            }
            if (oIndex.CompensatoryLeave.LeaveName != "" && oIndex.CompensatoryLeave.LeaveName != null)
            {
                lblCompensatoryLeave.Text = oIndex.CompensatoryLeave.RemainHour;
                lblCompensatoryLeaveDate.Text = oIndex.CompensatoryLeave.ExpiryDate.ToString("yyyy/MM/dd");
                lblCompensatoryLeaveTotal.Text = oIndex.CompensatoryLeave.TotalHour;
                var barWidth = Convert.ToDouble(lblCompensatoryLeave.Text) / Convert.ToDouble(lblCompensatoryLeaveTotal.Text);
                barWidth *= 100;
                lblCompensatoryLeaveBar.Style.Add(HtmlTextWriterStyle.Width, barWidth.ToString() + "%");
            }
            else
            {
                lblCompensatoryLeave.Text = "0";
                lblCompensatoryLeaveDate.Text = "";
                lblCompensatoryLeaveTotal.Text = "0";
            }

            lblOtHour.CssClass = "text-warning";
            if (oIndex.OtHoursDateRangeList.OverTimeHours > 40)
                lblOtHour.CssClass = "text-danger";
            lblOtHour.Text = oIndex.OtHoursDateRangeList.OverTimeHours.ToString();

            lblAbnToday.Text = oIndex.TodayAbnormal.AbnormalCount.ToString();
            lblAbnYesterday.Text = oIndex.YesterdayAbnormal.AbnormalCount.ToString();

            lblRote.Text = oIndex.RoteName;
            lblOnTime.Text = oIndex.TodayWorkTime.OnTime;
            lblOffTime.Text = oIndex.TodayWorkTime.OffTime;
            #endregion

            #region 待審核
            List<string> EmpId = new List<string>();
            EmpId.Add(_User.EmpId);

            var oRoleDao = new RoleDao();
            var RoleCond = new RoleConditions();

            RoleCond.AccessToken = _User.AccessToken;
            RoleCond.RefreshToken = _User.RefreshToken;
            RoleCond.CompanySetting = CompanySetting;
            RoleCond.EmpId = EmpId;

            var rsRole = oRoleDao.GetData(RoleCond);
            var rRole = new List<RoleRow>();

            if (rsRole.Data != null)
            {
                rRole = rsRole.Data as List<RoleRow>;
                var oUserFormAssignDao = new UserFormAssignDao();
                var UserFormAssignCond = new UserFormAssignConditions();

                UserFormAssignCond.AccessToken = _User.AccessToken;
                UserFormAssignCond.RefreshToken = _User.RefreshToken;
                UserFormAssignCond.CompanySetting = CompanySetting;
                UserFormAssignCond.SignEmpID = _User.EmpId;
                UserFormAssignCond.SignRoleID = "";
                UserFormAssignCond.RealSignEmpID = "";
                UserFormAssignCond.RealSignRoleID = "";
                UserFormAssignCond.FlowTreeID = "";
                UserFormAssignCond.SignDate = rRole[0].DateB.ToShortDateString();

                var rsUserFormAssign = oUserFormAssignDao.GetData(UserFormAssignCond);
                var rUserFormAssign = new List<UserFormAssignRow>();
                var rFlowSign = new List<FlowSign>();
                if (rsUserFormAssign.Data != null)
                {
                    rUserFormAssign = rsUserFormAssign.Data as List<UserFormAssignRow>;
                    foreach (var rsFlowSignForm in rUserFormAssign)
                    {
                        foreach (var rFlowSignForm in rsFlowSignForm.FlowSignForm)
                        {
                            foreach (var rsFlowSign in rFlowSignForm.FlowSign)
                            {
                                var rFlowSignRow = new FlowSign();
                                rFlowSignRow.AppDate = rsFlowSign.AppDate;
                                rFlowSignRow.AppDeptID = rsFlowSign.AppDeptID;
                                rFlowSignRow.AppDeptName = rsFlowSign.AppDeptName;
                                rFlowSignRow.AppDeptPath = rsFlowSign.AppDeptPath;
                                rFlowSignRow.AppEmpID = rsFlowSign.AppEmpID;
                                rFlowSignRow.AppEmpName = rsFlowSign.AppEmpName;
                                rFlowSignRow.AppRoleID = rsFlowSign.AppRoleID;
                                rFlowSignRow.Batch = rsFlowSign.Batch;
                                rFlowSignRow.CheckEmpID = rsFlowSign.CheckEmpID;
                                rFlowSignRow.CheckRoleID = rsFlowSign.CheckRoleID;
                                rFlowSignRow.ChiefCode = rsFlowSign.ChiefCode;
                                rFlowSignRow.Cond1 = rsFlowSign.Cond1;
                                rFlowSignRow.Cond2 = rsFlowSign.Cond2;
                                rFlowSignRow.Cond3 = rsFlowSign.Cond3;
                                rFlowSignRow.Cond4 = rsFlowSign.Cond4;
                                rFlowSignRow.Cond5 = rsFlowSign.Cond5;
                                rFlowSignRow.Cond6 = rsFlowSign.Cond6;
                                rFlowSignRow.FlowNodeID = rsFlowSign.FlowNodeID;
                                rFlowSignRow.FlowNodeName = rsFlowSign.FlowNodeName;
                                rFlowSignRow.FlowTreeID = rsFlowSign.FlowTreeID;
                                rFlowSignRow.FormCode = rsFlowSign.FormCode;
                                rFlowSignRow.Info = rsFlowSign.Info;
                                rFlowSignRow.PendingDay = rsFlowSign.PendingDay;
                                rFlowSignRow.ProcessApParmAuto = rsFlowSign.ProcessApParmAuto;
                                rFlowSignRow.ProcessCheckAuto = rsFlowSign.ProcessCheckAuto;
                                rFlowSignRow.ProcessFlowID = rsFlowSign.ProcessFlowID;
                                rFlowSignRow.ProcessNodeAuto = rsFlowSign.ProcessNodeAuto;
                                rFlowSignRow.RealAppEmpID = rsFlowSign.RealAppEmpID;
                                rFlowSignRow.SignCondition = rsFlowSign.SignCondition;

                                rFlowSign.Add(rFlowSignRow);
                            }
                        }
                    }
                }

                lvUserFormAssign.DataSource = rFlowSign;
                
            }
            #endregion


        }


        protected void lvUserFormAssign_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();

            UnobtrusiveSession.Session["ProcessApParmAuto"] = ca;
            UnobtrusiveSession.Session["RequestName"] = "ApParm";
            Response.Redirect("FormAbsChk.aspx?ProcessApParmAuto=X");
        }
    }
}