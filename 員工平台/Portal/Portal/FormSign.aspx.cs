using Bll.Flow.Vdb;
using Bll.Share.Vdb;
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
    public partial class FormSign : WebPageBase
    {
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["CompanySetting"] != null)
            {
                var CompanySstting = UnobtrusiveSession.Session["CompanySetting"] as CompanySettingRow;
                this.CompanySetting = CompanySstting;
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (!IsPostBack)
            {
                _DataBind();
            }
        }
        public void _DataBind()
        {
            var rsForm = (from c in dcFlow.Forms
                          where c.Sort != 0
                          orderby c.Sort
                          select new
                          {
                              Code = c.FlowTreeId,
                              Name = c.Name,
                          }).ToList();

            ddlForm.DataSource = rsForm;
            ddlForm.DataTextField = "Name";
            ddlForm.DataValueField = "Code";
            ddlForm.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lvFlowSignMain.Rebind();
        }

        protected void cbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCheckAll.Checked != null)
            {
                foreach (var rItem in lvFlowSignMain.Items)
                {
                    var cb = rItem.FindControl("cbForm") as RadCheckBox;
                    cb.Checked = cbCheckAll.Checked;
                }
            }
        }

        protected void lvFlowSignMain_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            var cn = e.CommandName;
            var ca = e.CommandArgument;
            if (cn == "ViewImage")
            {
                UnobtrusiveSession.Session["idProcess"] = ca;
                //var s = "window.open('FormFlowImage.aspx?idProcess=" + ca + "','_blank')";
                //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "lvMain", s, true);
                Response.Redirect("FormFlowImage.aspx?idProcess=" + ca);
                return;
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            int Success = 0;
            int Fail = 0;
            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);
            foreach (var rItem in lvFlowSignMain.Items)
            {
                var cb = rItem.FindControl("cbForm") as RadCheckBox;
                var lblApKey = rItem.FindControl("lblAp") as RadLabel;
                var lblProcessID = rItem.FindControl("lblProcessId") as RadLabel;
                var FormCode = rItem.FindControl("lblFormCode") as RadLabel;
                var ApKey = Convert.ToInt32(lblApKey.Text);
                string DeprTree = "0";
                var rProcessCheck = (from pn in dcFlow.ProcessNode
                                         join pc in dcFlow.ProcessCheck on pn.auto equals pc.ProcessNode_auto
                                         where pn.ProcessFlow_id == Convert.ToInt32(lblProcessID.Text)
                                         && !pn.isFinish.GetValueOrDefault(true)
                                         orderby pn.adate descending
                                         select pc).FirstOrDefault();

                    if (rProcessCheck != null)
                    {

                        if (_User.EmpId == rProcessCheck.Emp_idDefault || _User.EmpId == rProcessCheck.Emp_idAgent)
                        {
                            var rRole = (from r in dcFlow.Role
                                         join d in dcFlow.Dept on r.Dept_id equals d.id
                                         where r.id == rProcessCheck.Role_idDefault
                                         && r.Emp_id == rProcessCheck.Emp_idDefault
                                         select new
                                         {
                                             RoleId = r.id,
                                             EmpNobr = r.Emp_id,
                                             DeptTree = d.DeptLevel_id,
                                         }).FirstOrDefault();

                            if (rRole != null)
                            {
                                if (ApKey != 0)
                                {
                                    //寫回ApParm
                                    var rProcessApParm = (from c in dcFlow.ProcessApParm
                                                          where c.auto == ApKey
                                                          && c.ProcessFlow_id == Convert.ToInt32(lblProcessID.Text)
                                                          && c.ProcessCheck_auto == rProcessCheck.auto
                                                          && c.ProcessNode_auto == rProcessCheck.ProcessNode_auto
                                                          select c).FirstOrDefault();

                                    if (rProcessApParm != null)
                                    {
                                        rProcessApParm.Role_id = rProcessCheck.Role_idDefault;
                                        rProcessApParm.Emp_id = rProcessCheck.Emp_idDefault;

                                        dcFlow.SubmitChanges();
                                    }
                                }

                            DeprTree = Convert.ToInt32(rRole.DeptTree).ToString();
                            }
                        }
                    }
                var rAppM = (from c in dcFlow.FormsApp
                             where c.ProcessID == lblProcessID.Text
                             select c).FirstOrDefault();
                rAppM.Sign = true;
                rAppM.Cond01 = DeprTree;
                rAppM.SignState = !rAppM.Sign ? "2" : rAppM.SignState;
                rAppM.DateTimeD = DateTime.Now;
                if (cb.Checked != null && cb.Checked == true && lblApKey != null && lblApKey.Text != "" && lblProcessID != null && lblProcessID.Text != "")
                {
                    var rEmpM = (from role in dcFlow.Role
                                 join emp in dcFlow.Emp on role.Emp_id equals emp.id
                                 join dept in dcFlow.Dept on role.Dept_id equals dept.id
                                 join pos in dcFlow.Pos on role.Pos_id equals pos.id
                                 where role.Emp_id == _User.EmpId
                                 select new
                                 {
                                     RoleId = role.id,
                                     EmpNobr = emp.id,
                                     EmpName = emp.name,
                                     DeptCode = dept.id,
                                     DeptName = dept.name,
                                     JobCode = pos.id,
                                     JobName = pos.name,
                                     Auth = role.deptMg.Value,
                                 }).FirstOrDefault();

                    if (rEmpM != null)
                    {
                        var rSignM = (from c in dcFlow.FormsSign
                                      where c.ProcessId == lblProcessID.Text
                                      && c.Key1 == lblApKey.Text
                                      && c.EmpId == rEmpM.EmpNobr
                                      select c).FirstOrDefault();

                        if (rSignM == null)
                        {
                            rSignM = new FormsSign();
                            dcFlow.FormsSign.InsertOnSubmit(rSignM);
                        }

                        rSignM.FormsCode = FormCode.Text;
                        rSignM.ProcessId = lblProcessID.Text;
                        rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                        rSignM.Key1 = lblApKey.Text;
                        rSignM.Key2 = lblApKey.Text;
                        rSignM.EmpId = rEmpM.EmpNobr;
                        rSignM.EmpName = rEmpM.EmpName;
                        rSignM.DeptCode = rEmpM.DeptCode;
                        rSignM.DeptName = rEmpM.DeptName;
                        rSignM.JobCode = rEmpM.JobCode;
                        rSignM.JobName = rEmpM.JobName;
                        rSignM.RoleId = rEmpM.RoleId;
                        rSignM.Sign = true;
                        rSignM.SignNote = "";
                        rSignM.Sort = 1;
                        rSignM.Note = "";
                        rSignM.Status = "1";
                        rSignM.InsertDate = DateTime.Now;
                        rSignM.InsertMan = rSignM.EmpId;
                    }
                    dcFlow.SubmitChanges();
                    try
                    {
                        if (!oService.WorkFinish(Convert.ToInt32(lblApKey.Text)))
                        {
                            lblMessage.Text = "流程發生問題，您核准的動作可能無法完成。(1)";
                            Fail += 1;
                        }
                        else
                        {
                            //闖關直接通知流程起始者
                            //if (rAppM.sConditions6 != null && rAppM.sConditions6 == "1" && rAppM.bSign)
                            //{
                            //    var oCApParm = oService.GetApParm(Convert.ToInt32(Request["ApParm"]));

                            //    var rProcessApParm = (from c in dcFlow.ProcessApParm
                            //                          where c.ProcessFlow_id == oCApParm.ProcessFlow_id
                            //                          orderby c.auto descending
                            //                          select c).FirstOrDefault();

                            //    if (rProcessApParm != null)
                            //    {
                            //        rAppM.sConditions1 = "00";
                            //        rAppM.sConditions6 = "0";  //代理人簽過了

                            //        rProcessApParm.Emp_id = rsAppS.First().sNobr;
                            //        rProcessApParm.Role_id = rsAppS.First().sRole;

                            //        dcFlow.SubmitChanges();
                            //        dcForm.SubmitChanges();

                            //        if (!oService.WorkFinish(rProcessApParm.auto))
                            //            RadWindowManager1.RadAlert("流程發生問題，您核准的動作可能無法完成。(3)", 300, 100, "警告訊息", "", "");
                            //    }
                            //}
                            UnobtrusiveSession.Session["idProcess"] = lblProcessID.Text;
                            //RadScriptManager.RegisterStartupScript(this.Page, typeof(UpdatePanel), "key", "self.location='../../FlowImage/Output.aspx?idProcess=" + lblProcessID.Text + "';", true);
                            //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "GetRadWindow().close();", true);
                            Success += 1;
                        }
                    }
                    catch (Exception)
                    {
                        lblMessage.Text = "流程發生問題，您核准的動作可能無法完成。(2)";
                        Fail += 1;
                    }
                }

            }
            if (Success != 0 || Fail != 0)
            {
                lblMessage.Text = "核准";
                lblMessage.Text += (Success != 0) ? "成功:" + Success + "筆" : "";
                lblMessage.Text += (Fail != 0) ? "失敗:" + Fail + "筆" : "";
                lblMessage.CssClass = "badge badge-primary animated Shake";
                lvFlowSignMain.Rebind();
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);
            var lsProcessID = new List<int>();
            int Count = 0;
            foreach (var rItem in lvFlowSignMain.Items)
            {
                var cb = rItem.FindControl("cbForm") as RadCheckBox;
                var lblProcessID = rItem.FindControl("lblProcessId") as RadLabel;
                var lblApKey = rItem.FindControl("lblAp") as RadLabel;
                var FormCode = rItem.FindControl("lblFormCode") as RadLabel;
                if (cb.Checked != null && cb.Checked == true && lblProcessID != null && lblProcessID.Text != "")
                {
                    var rEmpM = (from role in dcFlow.Role
                                 join emp in dcFlow.Emp on role.Emp_id equals emp.id
                                 join dept in dcFlow.Dept on role.Dept_id equals dept.id
                                 join pos in dcFlow.Pos on role.Pos_id equals pos.id
                                 where role.Emp_id == _User.EmpId
                                 select new
                                 {
                                     RoleId = role.id,
                                     EmpNobr = emp.id,
                                     EmpName = emp.name,
                                     DeptCode = dept.id,
                                     DeptName = dept.name,
                                     JobCode = pos.id,
                                     JobName = pos.name,
                                     Auth = role.deptMg.Value,
                                 }).FirstOrDefault();

                    if (rEmpM != null)
                    {
                        var rSignM = (from c in dcFlow.FormsSign
                                      where c.ProcessId == lblProcessID.Text
                                      && c.Key1 == lblApKey.Text
                                      && c.EmpId == rEmpM.EmpNobr
                                      select c).FirstOrDefault();

                        if (rSignM == null)
                        {
                            rSignM = new FormsSign();
                            dcFlow.FormsSign.InsertOnSubmit(rSignM);
                        }

                        rSignM.FormsCode = FormCode.Text;
                        rSignM.ProcessId = lblProcessID.Text;
                        rSignM.idProcess = Convert.ToInt32(rSignM.ProcessId);
                        rSignM.Key1 = lblApKey.Text;
                        rSignM.Key2 = lblApKey.Text;
                        rSignM.EmpId = rEmpM.EmpNobr;
                        rSignM.EmpName = rEmpM.EmpName;
                        rSignM.DeptCode = rEmpM.DeptCode;
                        rSignM.DeptName = rEmpM.DeptName;
                        rSignM.JobCode = rEmpM.JobCode;
                        rSignM.JobName = rEmpM.JobName;
                        rSignM.RoleId = rEmpM.RoleId;
                        rSignM.Sign = true;
                        rSignM.SignNote = "";
                        rSignM.Sort = 1;
                        rSignM.Note = "";
                        rSignM.Status = "1";
                        rSignM.InsertDate = DateTime.Now;
                        rSignM.InsertMan = rSignM.EmpId;
                    }
                    dcFlow.SubmitChanges();
                    lsProcessID.Add(Convert.ToInt32(lblProcessID.Text));
                    Count++;
                }
            }
            var rsProcessID = oService.FlowStateSetByRWD(lsProcessID, ezEngineServices.FlowState.Reject, _User.EmpId);
            lblMessage.Text = "";
            lblMessage.Text += "已成功駁回" + rsProcessID.Count() + "筆";
            lblMessage.Text += (rsProcessID.Count() == Count) ? "" : "失敗" + (Count - rsProcessID.Count).ToString() + "筆";
            lblMessage.CssClass = "badge badge-danger animated Shake";
        }

        protected void lvFlowSignMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var oSysVarDao = new SysVarDao();
            var SysVarCond = new SysVarConditions();

            SysVarCond.AccessToken = _User.AccessToken;
            SysVarCond.RefreshToken = _User.RefreshToken;
            SysVarCond.CompanySetting = CompanySetting;
            var rsSysVar = oSysVarDao.GetData(SysVarCond);
            var rSysVar = new SysVarRow();
            if (rsSysVar.Status)
            {
                if (rsSysVar.Data != null)
                {
                    rSysVar = rsSysVar.Data as SysVarRow;
                    if (rSysVar.SysClose)
                    {
                        lblMsg.Text = "系統維護中，請稍後再查詢表單";
                        return;
                    }
                }
            }

            var oUserFormAssignDao = new UserFormAssignDao();
            var UserFormAssignCond = new UserFormAssignConditions();
            UserFormAssignCond.AccessToken = _User.AccessToken;
            UserFormAssignCond.RefreshToken = _User.RefreshToken;
            UserFormAssignCond.CompanySetting = CompanySetting;
            UserFormAssignCond.SignEmpID = _User.EmpId;
            UserFormAssignCond.SignRoleID = "";
            UserFormAssignCond.RealSignEmpID = "";
            UserFormAssignCond.RealSignRoleID = "";
            UserFormAssignCond.FlowTreeID = ddlForm.SelectedValue == "0" ? "" : ddlForm.SelectedValue;
            UserFormAssignCond.SignDate = DateTime.Now.Date.ToString();

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
                foreach (var FlowS in rFlowSign)
                {
                    FlowS.Detail = "";
                    switch (FlowS.FormCode)
                    {
                        case "Abs":
                        case "Abs1":
                            var lsAbsData = (from c in dcFlow.FormsAppAbs
                                             where c.idProcess == FlowS.ProcessFlowID
                                             select c).ToList();
                            foreach (var AbsData in lsAbsData)
                            {
                                FlowS.Detail += String.Format("姓名 : {0},{1} | 開始日期 : {2} | 結束日期 : {3} | 假別 : {8} | 時數:{5} | 代理人 : {6},{7}", AbsData.EmpId, AbsData.EmpName
                                                                , AbsData.DateTimeB, AbsData.DateTimeE, AbsData.HolidayCode, AbsData.Use, AbsData.AgentEmpName, AbsData.AgentEmpId, AbsData.HolidayName);
                                if (AbsData != lsAbsData.LastOrDefault())
                                    FlowS.Detail += "<hr/>";
                            }
                            break;
                        case "Ot":
                        case "Ot1":
                        case "Ovt":
                        case "OvtB":
                            var lsOtData = (from c in dcFlow.FormsAppOt
                                            where c.idProcess == FlowS.ProcessFlowID
                                            select c).ToList();
                            foreach (var OtData in lsOtData)
                            {
                                FlowS.Detail += String.Format("姓名 : {0},{1} | 開始日期 : {2} | 結束日期 : {3} 時數:{4} ", OtData.EmpId, OtData.EmpName
                                                                , OtData.DateTimeB, OtData.DateTimeE, OtData.Use);
                                if (OtData != lsOtData.LastOrDefault())
                                    FlowS.Detail += "<hr/>";
                            }
                            break;
                        case "Absc":
                            var lsAbscData = (from c in dcFlow.FormsAppAbsc
                                              where c.idProcess == FlowS.ProcessFlowID
                                              select c).ToList();
                            foreach (var AbscData in lsAbscData)
                            {
                                FlowS.Detail += String.Format("姓名 : {0},{1} | 開始日期 : {2} | 結束日期 : {3} | 假別 : {6} | 時數:{5} ", AbscData.EmpId, AbscData.EmpName
                                                                , AbscData.DateTimeB, AbscData.DateTimeE, AbscData.HolidayCode, AbscData.Use, AbscData.HolidayName);
                                if (AbscData != lsAbscData.LastOrDefault())
                                    FlowS.Detail += "<hr/>";
                            }
                            break;
                        case "Card":
                            var lsCardData = (from c in dcFlow.FormsAppCard
                                              where c.idProcess == FlowS.ProcessFlowID
                                              select c).ToList();
                            foreach (var CardData in lsCardData)
                            {
                                FlowS.Detail += String.Format("姓名 : {0},{1} | 忘刷日期：{2} | 忘刷時間:{3} | 忘刷原因:{4}", CardData.EmpId, CardData.EmpName, CardData.DateB, CardData.TimeB, CardData.CardLostName);
                                if (CardData != lsCardData.LastOrDefault())
                                    FlowS.Detail += "<hr/>";
                            }
                            break;
                        case "Abn":
                            var lsAbnData = (from c in dcFlow.FormsAppAbn
                                             where c.idProcess == FlowS.ProcessFlowID
                                             select c).ToList();
                            foreach (var AbnData in lsAbnData)
                            {
                                if (AbnData.IsEarlyWork)
                                    FlowS.Detail += String.Format("姓名 : {0},{1} | 日期：{2} | 註記類別：早來 | 時間：{3} 分鐘", AbnData.EmpId, AbnData.EmpName, AbnData.DateB, AbnData.EarlyWorkMin);
                                if (AbnData.IsLateOut)
                                {
                                    FlowS.Detail += AbnData.IsEarlyWork ? " < hr /> " : "";
                                    FlowS.Detail += String.Format("姓名 : {0},{1} | 日期：{2} | 註記類別：晚走 | 時間：{3} 分鐘", AbnData.EmpId, AbnData.EmpName, AbnData.DateB, AbnData.LateOutMin);
                                }
                                if (AbnData != lsAbnData.LastOrDefault())
                                    FlowS.Detail += "<hr/>";
                            }
                            break;
                        case "ShiftShort":
                            var lsShiftShortData = (from c in dcFlow.FormsAppShiftShort
                                                    where c.idProcess == FlowS.ProcessFlowID
                                                    select c).ToList();
                            foreach (var ShiftShortData in lsShiftShortData)
                            {
                                FlowS.Detail += String.Format("姓名 : {0},{1} | 原班別日期：{2} | 目前班別:{3} | 換班日期 :{4} | 換班班別 :{5}", ShiftShortData.EmpId, ShiftShortData.EmpName
                                                                , ShiftShortData.DateB, ShiftShortData.RoteNameB, ShiftShortData.DateE, ShiftShortData.RoteNameE);
                                if (ShiftShortData != lsShiftShortData.LastOrDefault())
                                    FlowS.Detail += "<hr/>";
                            }
                            break;
                        case "ShiftLong":
                            var lsShiftLongData = (from c in dcFlow.FormsAppShiftLong
                                                   where c.idProcess == FlowS.ProcessFlowID
                                                   select c).ToList();
                            foreach (var ShiftLongData in lsShiftLongData)
                            {
                                FlowS.Detail += String.Format("姓名 : {0},{1} | 原班別日期：{2} | 調班班別:{3}", ShiftLongData.EmpId, ShiftLongData.EmpName, ShiftLongData.Date, ShiftLongData.RotetName);
                                if (ShiftLongData != lsShiftLongData.LastOrDefault())
                                    FlowS.Detail += "<hr/>";
                            }
                            break;
                        default:
                            break;
                    }

                }
                foreach (var FlowData in rFlowSign.ToArray())
                {
                    if (txtCond.Text != "")
                    {
                        if (!FlowData.Detail.Contains(txtCond.Text))
                            rFlowSign.Remove(FlowData);
                    }
                }
                lvFlowSignMain.DataSource = rFlowSign;
                var Script = "$(document).ready(function() {$('.footable').footable();});";
                ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
            }
        }
    }
}