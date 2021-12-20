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
using Dal.Dao.Menu;
using Bll.Menu.Vdb;
using Dal.Dao.Absence;
using Bll.Absence.Vdb;

namespace Portal
{
    public partial class Index : WebPageBase
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
            var IndexFeatureResult = new List<IndexFeaturesRow>();
            var oIndexFeatures = new IndexFeaturesDao();
            var IndexFeaturesCond = new IndexFeaturesConditions();
            IndexFeaturesCond.AccessToken = _User.AccessToken;
            IndexFeaturesCond.RefreshToken = _User.RefreshToken;
            IndexFeaturesCond.CompanySetting = CompanySetting;
            IndexFeaturesCond.EmpId = _User.EmpId;
            var FeatureResult = oIndexFeatures.GetData(IndexFeaturesCond);
            if (FeatureResult.Status)
            {
                if (FeatureResult.Data != null)
                {
                    IndexFeatureResult = FeatureResult.Data as List<IndexFeaturesRow>;
                    if (IndexFeatureResult != null)
                    {
                        foreach (var IndexFeature in IndexFeatureResult)
                        {
                            switch (IndexFeature.FileName)
                            {
                                case "IndexNews":
                                    pnlNews.Visible = true;
                                    break;
                                case "IndexOt":
                                    pnlOt.Visible = true;
                                    break;
                                case "IndexAbn":
                                    pnlAbn.Visible = true;
                                    break;
                                case "IndexAbs":
                                    pnlAbs.Visible = true;
                                    break;
                                case "IndexCheck":
                                    pnlCheck.Visible = true;
                                    break;
                                case "IndexCard":
                                    pnlCard.Visible = true;
                                    break;
                            }
                        }
                    }
                }
            }

            var oIndex = new IndexRow();
            var ListLeaveCode = new List<string>();
            var ListEmpId = new List<string>();
            ListEmpId.Add(_User.EmpId);
            var DateB = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var DateE = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

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
                    rs = rs.OrderByDescending(p => p.NewsDate).ToList();
                    int count = rs.Count <= 5 ? rs.Count : 5;
                    for (int i = 0; i < count; i++)
                    {
                        if (rs[i] != null)
                        {
                            var rBillBoard = new IndexRow.BillBoard();
                            rBillBoard.idNO = rs[i].NewsKey;
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
            //var oHcodeTypesByHcode = new HcodeTypesByHcodeDao();
            //var HcodeTypesByHcodeCond = new HcodeTypesByHcodeConditions();
            //HcodeTypesByHcodeCond.AccessToken = _User.AccessToken;
            //HcodeTypesByHcodeCond.RefreshToken = _User.RefreshToken;
            //HcodeTypesByHcodeCond.CompanySetting = CompanySetting;
            //HcodeTypesByHcodeCond.htype = new List<string>();
            //HcodeTypesByHcodeCond.htype.Add("1");
            ////HcodeTypesByHcodeCond.htype.Add("2");
            //HcodeTypesByHcodeCond.flag = new List<string>();
            //HcodeTypesByHcodeCond.flag.Add("+");
            //var ResultHCode = oHcodeTypesByHcode.GetData(HcodeTypesByHcodeCond);
            //if (ResultHCode.Status)
            //{
            //    if (ResultHCode.Data != null)
            //    {
            //        var rs = ResultHCode.Data as List<HcodeTypesByHcodeRow>;
            //        foreach (var r in rs)
            //        {
            //            ListLeaveCode.Add(r.Hcode);
            //        }
            //    }
            //}

            //var oAbsBalanceView = new AbsBalanceDao();
            //var AbsBalanceCond = new AbsBalanceConditions();

            //AbsBalanceCond.AccessToken = _User.AccessToken;
            //AbsBalanceCond.RefreshToken = _User.RefreshToken;
            //AbsBalanceCond.CompanySetting = CompanySetting;
            //AbsBalanceCond.hcodeList = ListLeaveCode;
            //AbsBalanceCond.employeeList = ListEmpId;
            //AbsBalanceCond.effectDate = DateTime.Now;

            //var ResultAbsence = oAbsBalanceView.GetData(AbsBalanceCond);

            var oAnnualLeave = new AnnualLeaveDao();
            var AnnualLeaveCond = new AnnualLeaveConditions();
            AnnualLeaveCond.AccessToken = _User.AccessToken;
            AnnualLeaveCond.RefreshToken = _User.RefreshToken;
            AnnualLeaveCond.CompanySetting = CompanySetting;
            AnnualLeaveCond.dateTime = DateTime.Now;
            var ResultAnnual = oAnnualLeave.GetData(AnnualLeaveCond);
            if (ResultAnnual.Status)
            {
                if (ResultAnnual.Data != null)
                {
                    var rs = ResultAnnual.Data as AnnualLeaveRow;
                    oIndex.SpecialLeave.LeaveName = "特休";
                    if (rs != null)
                    {
                        oIndex.SpecialLeave.RemainHour = rs.Result.ToString("N2");
                    }
                }
            }
            var oCompensatoryLeave = new CompensatoryLeaveDao();
            var CompensatoryLeaveCond = new CompensatoryLeaveConditions();
            CompensatoryLeaveCond.AccessToken = _User.AccessToken;
            CompensatoryLeaveCond.RefreshToken = _User.RefreshToken;
            CompensatoryLeaveCond.CompanySetting = CompanySetting;
            CompensatoryLeaveCond.dateTime = DateTime.Now;
            var ResultCompensatory = oCompensatoryLeave.GetData(CompensatoryLeaveCond);
            if (ResultCompensatory.Status)
            {
                if (ResultCompensatory.Data != null)
                {
                    var rs = ResultCompensatory.Data as CompensatoryLeaveRow;
                    oIndex.CompensatoryLeave.LeaveName = "補休";
                    if (rs != null)
                    {
                        oIndex.CompensatoryLeave.RemainHour = rs.Result.ToString("N2");
                    }
                }
            }
            //if (ResultAbsence.Status)
            //{
            //    if (ResultAbsence.Data != null)
            //    {
            //        var rs = ResultAbsence.Data as List<AbsBalanceRow>;
            //        int TolBalance = 0;
            //        int TolUse = 0;
            //        int TolHour = 0;
            //        foreach (var r in rs)
            //        {
            //            TolBalance += Convert.ToInt32(r.Balance);
            //            TolUse += Convert.ToInt32(r.LeaveHours);
            //            TolHour += Convert.ToInt32(r.Tolhours);
            //            oIndex.SpecialLeave.ExpiryDate = r.Edate;
            //        }
            //        oIndex.SpecialLeave.LeaveName = "特休";
            //        oIndex.SpecialLeave.RemainHour = TolBalance.ToString("N2");
            //        oIndex.SpecialLeave.TotalHour = TolHour.ToString("N2");
            //        oIndex.SpecialLeave.UseHour = TolUse.ToString("N2");

            //    }
            //}
            //oHcodeTypesByHcode = new HcodeTypesByHcodeDao();
            //HcodeTypesByHcodeCond = new HcodeTypesByHcodeConditions();
            //HcodeTypesByHcodeCond.AccessToken = _User.AccessToken;
            //HcodeTypesByHcodeCond.RefreshToken = _User.RefreshToken;
            //HcodeTypesByHcodeCond.CompanySetting = CompanySetting;
            //HcodeTypesByHcodeCond.htype = new List<string>();
            //HcodeTypesByHcodeCond.htype.Add("2");
            //HcodeTypesByHcodeCond.flag = new List<string>();
            //HcodeTypesByHcodeCond.flag.Add("+");
            //ListLeaveCode = new List<string>();
            //ResultHCode = oHcodeTypesByHcode.GetData(HcodeTypesByHcodeCond);
            //if (ResultHCode.Status)
            //{
            //    if (ResultHCode.Data != null)
            //    {
            //        var rs = ResultHCode.Data as List<HcodeTypesByHcodeRow>;
            //        foreach (var r in rs)
            //        {
            //            ListLeaveCode.Add(r.Hcode);
            //        }
            //    }
            //}

            //oAbsBalanceView = new AbsBalanceDao();
            //AbsBalanceCond = new AbsBalanceConditions();

            //AbsBalanceCond.AccessToken = _User.AccessToken;
            //AbsBalanceCond.RefreshToken = _User.RefreshToken;
            //AbsBalanceCond.CompanySetting = CompanySetting;
            //AbsBalanceCond.hcodeList = ListLeaveCode;
            //AbsBalanceCond.employeeList = ListEmpId;
            //AbsBalanceCond.effectDate = DateTime.Now;

            //ResultAbsence = oAbsBalanceView.GetData(AbsBalanceCond);

            //if (ResultAbsence.Status)
            //{
            //    if (ResultAbsence.Data != null)
            //    {
            //        var rs = ResultAbsence.Data as List<AbsBalanceRow>;
            //        int TolBalance = 0;
            //        int TolUse = 0;
            //        int TolHour = 0;
            //        foreach (var r in rs)
            //        {
            //            TolBalance += Convert.ToInt32(r.Balance);
            //            TolUse += Convert.ToInt32(r.LeaveHours);
            //            TolHour += Convert.ToInt32(r.Tolhours);
            //            oIndex.CompensatoryLeave.ExpiryDate = r.Edate;
            //        }
            //        oIndex.CompensatoryLeave.LeaveName = "補休";
            //        oIndex.CompensatoryLeave.RemainHour = TolBalance.ToString("N2");
            //        oIndex.CompensatoryLeave.TotalHour = TolHour.ToString("N2");
            //        oIndex.CompensatoryLeave.UseHour = TolUse.ToString("N2");
            //    }
            //}
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

            #region 資料載入
            lvBillBoard.DataSource = oIndex.BillBoardList;
            lvBillBoard.DataBind();

            if (oIndex.SpecialLeave.LeaveName != "" && oIndex.SpecialLeave.LeaveName != null)
            {
                lblSpecialLeave.Text = oIndex.SpecialLeave.RemainHour;
                //lblSpecialLeaveDate.Text = oIndex.SpecialLeave.ExpiryDate.ToString("yyyy/MM/dd");
                //lblSpecialLeaveTotal.Text = oIndex.SpecialLeave.TotalHour;
                //var barWidth = Convert.ToDouble(lblSpecialLeave.Text) / Convert.ToDouble(lblSpecialLeaveTotal.Text);
                var barWidth = Convert.ToDouble(lblSpecialLeave.Text) / 100;
                barWidth *= 100;
                lblSpecialLeaveBar.Style.Add(HtmlTextWriterStyle.Width, barWidth.ToString() + "%");
            }
            else
            {
                lblSpecialLeave.Text = "0";
                //lblSpecialLeaveDate.Text = "";
                //lblSpecialLeaveTotal.Text = "0";
            }
            if (oIndex.CompensatoryLeave.LeaveName != "" && oIndex.CompensatoryLeave.LeaveName != null)
            {
                lblCompensatoryLeave.Text = oIndex.CompensatoryLeave.RemainHour;
                //lblCompensatoryLeaveDate.Text = oIndex.CompensatoryLeave.ExpiryDate.ToString("yyyy/MM/dd");
                //lblCompensatoryLeaveTotal.Text = oIndex.CompensatoryLeave.TotalHour;
                //var barWidth = Convert.ToDouble(lblCompensatoryLeave.Text) / Convert.ToDouble(lblCompensatoryLeaveTotal.Text);
                var barWidth = Convert.ToDouble(lblCompensatoryLeave.Text) / 100;
                barWidth *= 100;
                lblCompensatoryLeaveBar.Style.Add(HtmlTextWriterStyle.Width, barWidth.ToString() + "%");
            }
            else
            {
                lblCompensatoryLeave.Text = "0";
                //lblCompensatoryLeaveDate.Text = "";
                //lblCompensatoryLeaveTotal.Text = "0";
            }

            lblOtHour.CssClass = "text-warning";
            if (oIndex.OtHoursDateRangeList.OverTimeHours > 40)
                lblOtHour.CssClass = "text-danger";
            lblOtHour.Text = oIndex.OtHoursDateRangeList.OverTimeHours.ToString();

            lblAbnToday.Text = oIndex.TodayAbnormal.AbnormalCount.ToString();
            lblAbnYesterday.Text = oIndex.YesterdayAbnormal.AbnormalCount.ToString();

            if (oIndex.RoteName != null)
                lblRote.Text = oIndex.RoteName;
            else
                lblRote.Text = "無班別資料";
            if (oIndex.TodayWorkTime.OnTime != null)
                lblOnTime.Text = oIndex.TodayWorkTime.OnTime;
            else
                lblOnTime.Text = "--:--";
            if (oIndex.TodayWorkTime.OffTime != null)
                lblOffTime.Text = oIndex.TodayWorkTime.OffTime;
            else
                lblOffTime.Text = "--:--";
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
            if (rsRole.Status)
            {
                if (rsRole.Data != null)
                {
                    rRole = rsRole.Data as List<RoleRow>;
                    var oUserFormAssignDao = new UserFormAssignDao();
                    var UserFormAssignCond = new UserFormAssignConditions();
                    if (rRole.Count != 0)
                    {
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
                        if (rsUserFormAssign.Status)
                        {
                            if (rsUserFormAssign.Data != null)
                            {
                                rUserFormAssign = rsUserFormAssign.Data as List<UserFormAssignRow>;
                                foreach (var rsFlowSignForm in rUserFormAssign)
                                {
                                    foreach (var rFlowSignForm in rsFlowSignForm.FlowSignForm)
                                    {
                                        lblSignCount.Text = rFlowSignForm.Count.ToString();
                                        foreach (var rsFlowSign in rFlowSignForm.FlowSign)
                                        {
                                            var rFlowSignRow = new FlowSign();
                                            rFlowSignRow.AppDate = rsFlowSign.AppDate;
                                            rFlowSignRow.AppDateD = rsFlowSign.AppDateD;
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
                                            rFlowSignRow.FormName = rsFlowSign.FormName;
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
                            lvUserFormAssign.DataBind();
                        }
                    }
                }
            }
            #endregion
        }


        protected void lvUserFormAssign_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
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