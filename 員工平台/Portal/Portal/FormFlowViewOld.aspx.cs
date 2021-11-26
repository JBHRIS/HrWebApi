using Dal;
using System;
using Bll.FormView.Vdb;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Dal.Dao.Flow;
using Bll.Flow.Vdb;
using System.Drawing;
using System.Text;
using Bll.Share.Vdb;

namespace Portal
{
    public partial class FormFlowViewOld : WebPageBase
    {

        private dcHrDataContext dcHR = new dcHrDataContext();

        private dcFlowDataContext dcFlow = new dcFlowDataContext();

        private string _FormCode = "FlowView";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["CompanySetting"] != null)
            {
                var CompanySstting = UnobtrusiveSession.Session["CompanySetting"] as CompanySettingRow;
                this.CompanySetting = CompanySstting;
                dcHR.Connection.ConnectionString = CompanySetting.ConnHr;
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (!IsPostBack)
            {
                DateTime dDate = DateTime.Now.Date;
                DateTime dDateB = dDate.AddMonths(-3).Date;
                DateTime dDateE = dDate.AddMonths(3).Date;
                txtDateB.SelectedDate = dDateB;
                txtDateE.SelectedDate = dDateE;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtDateB.SelectedDate > txtDateE.SelectedDate)
            {
                lblMsg.Text = "開始日期不可大於結束日期";
                lblMsg.CssClass = "badge-danger";
                return;
            }
            //var result = (from App in dcFlow.FormsApp
            //              join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
            //              join Form in dcFlow.Forms on App.FormsCode equals Form.Code
            //              join ApParm in dcFlow.ProcessApParm on App.ProcessID equals ApParm.ProcessFlow_id.ToString()
            //              where App.DateTimeA > txtDateB.SelectedDate && App.DateTimeA < txtDateE.SelectedDate && App.EmpId == _User.EmpId && ((bool)isFinish.Checked ? (bool)Process.isFinish : true)
            //              select new FormViewRow
            //              {
            //                  ProcessId = App.ProcessID,
            //                  ADate = App.DateTimeA,
            //                  Application = App.EmpId,
            //                  FlowCode = Form.Code,
            //                  FlowName = Form.Name,
            //                  FormState = (bool)Process.isFinish ? "已完成" : "進行中",
            //                  FlowId = ApParm.auto.ToString()
            //              }).Distinct().ToList();

            var result = (from App in dcFlow.FormsApp
                          join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
                          join Form in dcFlow.Forms on App.FormsCode equals Form.Code
                          where App.DateTimeA > txtDateB.SelectedDate && App.DateTimeA < txtDateE.SelectedDate && App.EmpId == _User.EmpId && ((bool)isFinish.Checked ? (bool)Process.isFinish : true)
                          select new FormViewRow
                          {
                              ProcessId = App.ProcessID,
                              ADate = App.DateTimeA,
                              Application = App.EmpId,
                              FlowCode = Form.Code,
                              FlowName = Form.Name,
                              FormState = (bool)Process.isFinish ? App.SignState == "3" ? "已完成" : "已駁回" : "進行中",
                          }).Distinct().ToList();
            foreach (var r in result)
            {
                r.FlowId = (from c in dcFlow.ProcessApParm
                            where c.ProcessFlow_id.ToString() == r.ProcessId
                            select c.auto.ToString()).FirstOrDefault();
                switch (r.FlowCode)
                {
                    case "Abs":
                        var AbsDate = (from c in dcFlow.FormsAppAbs
                                       where c.ProcessID == r.ProcessId
                                       select c).FirstOrDefault();
                        if (AbsDate != null)
                        {
                            r.DateB = AbsDate.DateTimeB;
                            r.DateE = AbsDate.DateTimeE;
                        }
                        break;
                    case "Abs1":
                        var Abs1Date = (from c in dcFlow.FormsAppAbs
                                       where c.ProcessID == r.ProcessId
                                       select c).FirstOrDefault();
                        if (Abs1Date != null)
                        {
                            r.DateB = Abs1Date.DateTimeB;
                            r.DateE = Abs1Date.DateTimeE;
                        }
                        break;
                    case "Absc":
                        var AbscDate = (from c in dcFlow.FormsAppAbsc
                                        where c.ProcessId == r.ProcessId
                                        select c).FirstOrDefault();
                        if (AbscDate != null)
                        {
                            r.DateB = AbscDate.DateTimeB;
                            r.DateE = AbscDate.DateTimeE;
                        }
                        break;
                    case "Card":
                        var CardDate = (from c in dcFlow.FormsAppCard
                                        where c.ProcessID == r.ProcessId
                                        select c).FirstOrDefault();
                        if (CardDate != null)
                        {
                            r.DateB = CardDate.DateTimeB;
                            r.DateE = CardDate.DateTimeE;
                        }
                        break;
                    case "Ot1":
                    case "OvtB":
                    case "Ot":
                        var OtDate = (from c in dcFlow.FormsAppOt
                                      where c.ProcessID == r.ProcessId
                                      select c).FirstOrDefault();
                        if (OtDate != null)
                        {
                            r.DateB = OtDate.DateTimeB;
                            r.DateE = OtDate.DateTimeE;
                        }
                        break;
                    case "Abn":
                        var AbnDate = (from c in dcFlow.FormsAppAbn
                                       where c.ProcessId == r.ProcessId
                                       select c).FirstOrDefault();
                        if (AbnDate != null)
                        {
                            r.DateB = AbnDate.DateB;
                            r.DateE = AbnDate.DateB;
                        }
                        break;
                    case "ShiftShort":
                        var ShiftShortDate = (from c in dcFlow.FormsAppShiftShort
                                             where c.ProcessId == r.ProcessId
                                             select c).FirstOrDefault();
                        if (ShiftShortDate != null)
                        {
                            r.DateB = ShiftShortDate.DateB;
                            r.DateE = ShiftShortDate.DateE;
                        }
                        break;
                    case "ShiftLong":
                        var ShiftLongDate = (from c in dcFlow.FormsAppShiftLong
                                       where c.ProcessID == r.ProcessId
                                       select c).FirstOrDefault();
                        if (ShiftLongDate != null)
                        {
                            r.DateB = ShiftLongDate.Date;
                            r.DateE = ShiftLongDate.Date;
                        }
                        break;
                    default:
                        r.DateB = null;
                        r.DateE = null;
                        break;
                }
            }

            lvMain.DataSource = result;
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        protected void lvMain_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            var ca = e.CommandArgument;
            var cn = e.CommandName;
            if (cn == "ViewImage")
            {
                UnobtrusiveSession.Session["idProcess"] = ca;
                //var s = "window.open('FormFlowImage.aspx?idProcess=" + ca + "','_blank')";
                //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "lvMain", s, true);
                Response.Redirect("FormFlowImage.aspx?idProcess=" + ca);
                return;
            }

            UnobtrusiveSession.Session["RequestName"] = "View";
            UnobtrusiveSession.Session["ProcessApParmAuto"] = ca;
            var oFormGetFlowParmUrlDao = new FormGetFlowParmUrlDao();
            var FormGetFlowParmUrlCond = new FormGetFlowParmUrlConditions();
            FormGetFlowParmUrlCond.AccessToken = _User.AccessToken;
            FormGetFlowParmUrlCond.RefreshToken = _User.RefreshToken;
            FormGetFlowParmUrlCond.CompanySetting = CompanySetting;
            FormGetFlowParmUrlCond.bOnlyUrl = true;
            FormGetFlowParmUrlCond.iApParmID = Convert.ToInt32(ca);
            string TurnUrl = "Form" + cn + "Chk.aspx?";
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
            
            string ParmUrl = TurnUrl + "ProcessApParmAuto=" + ca;
            //var Script = "window.open('" + ParmUrl + "','_blank')";
            //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "lvMain", Script, true);
            Response.Redirect(ParmUrl);
        }
    }
}