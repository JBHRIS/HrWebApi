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
using Bll.UserRole.Vdb;
using Dal.Dao.UserRole;
using Telerik.Web.UI;
using Bll.Employee.Vdb;
using Dal.Dao.Employee;
using Bll;
using System.Collections.Specialized;
using Bll.Token.Vdb;
using Dal.Dao.Token;

namespace Portal
{
    public partial class FormFlowView : WebPageBase
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
                DateTime dDateE = dDate.AddDays(1);

                string ProcessID = "";
                string EmpID = "";
                string Role = "";
                string DateB = "";
                string DateE = "";
                string State = "";
                string FormsCode = "";
                string Dept = "";

                ProcessID = Request.QueryString["ProcessID"];
                EmpID = Request.QueryString["EmpID"];
                Role = Request.QueryString["Role"];
                DateB = Request.QueryString["DateB"];
                DateE = Request.QueryString["DateE"];
                State = Request.QueryString["State"];
                FormsCode = Request.QueryString["FormsCode"];
                Dept = Request.QueryString["Dept"];

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rsBas = oBasDao.GetBaseByNobr(_User.EmpId, DateTime.Now).FirstOrDefault();

                var Nobr = new List<string>();
                Nobr.Add(_User.EmpId);

                var rs = new List<UserRoleRow>();
                var oUserRole = new UserRoleDao();
                var UserRoleCond = new UserRoleConditions();
                UserRoleCond.AccessToken = _User.AccessToken;
                UserRoleCond.RefreshToken = _User.RefreshToken;
                UserRoleCond.CompanySetting = CompanySetting;
                UserRoleCond.nobr = Nobr;
                var Result = oUserRole.GetData(UserRoleCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        rs = Result.Data as List<UserRoleRow>;
                        if (rs[0].roleCode.Contains("Admin") || rs[0].roleCode.Contains("Hr"))
                        {
                            plFlowViewEmp.Visible = false;
                            plFlowViewAdmin.Visible = true;
                            plFlowViewCoordinator.Visible = false;
                            plHrTools.Visible = true;
                            SetFormAdminData();
                            SetDeptAdmin();
                            SetNameAdmin_DataBind();
                            SetSignName();
                            //if (rsBas != null)
                            //{
                            //    if (ddlDeptAdmin.Items.FindItemByValue(rsBas.DeptmCode) != null)
                            //        ddlDeptAdmin.Items.FindItemByValue(rsBas.DeptmCode).Selected = true;

                            //    if (txtNameAdmin.Items.FindItemByValue(rsBas.Nobr) != null)
                            //        txtNameAdmin.Items.FindItemByValue(rsBas.Nobr).Selected = true;
                            //}
                            txtDateBAdmin.SelectedDate = dDateB;
                            txtDateEAdmin.SelectedDate = dDateE;

                            #region 返回上一頁時的帶入參數動作
                            NameValueCollection coll = Request.QueryString;
                            if (coll.Count != 0)
                            {
                                if (ProcessID != "")
                                    txtProcessIdAdmin.Text = ProcessID;
                                if (Dept != "")
                                {
                                    if (ddlDeptAdmin.Items.FindItemByValue(Dept) != null)
                                    {
                                        ddlDeptAdmin.Items.FindItemByValue(Dept).Selected = true;
                                        SetNameAdmin_DataBind(Dept);
                                    }
                                }
                                else
                                    SetNameAdmin_DataBind();

                                if (EmpID != "")
                                {
                                    if (txtNameAdmin.Items.FindItemByValue(EmpID) != null)
                                        txtNameAdmin.Items.FindItemByValue(EmpID).Selected = true;
                                }

                                if (Role != "")
                                {
                                    if (ddlRoleAdmin.Items.FindItemByValue(Role) != null)
                                        ddlRoleAdmin.Items.FindItemByValue(Role).Selected = true;
                                }
                                if (DateB != "")
                                    txtDateBAdmin.SelectedDate = Convert.ToDateTime(DateB);
                                if (DateE != "")
                                    txtDateEAdmin.SelectedDate = Convert.ToDateTime(DateE);
                                if (State != "")
                                {
                                    if (ddlStateAdmin.Items.FindItemByValue(State) != null)
                                        ddlStateAdmin.Items.FindItemByValue(State).Selected = true;
                                }
                                if (FormsCode != "")
                                {
                                    if (ddlFormAdmin.Items.FindItemByValue(FormsCode) != null)
                                        ddlFormAdmin.Items.FindItemByValue(FormsCode).Selected = true;
                                }
                                btnSearchAdmin_Click(null, null);
                            }
                            #endregion
                        }
                        else if (rs[0].roleCode.Contains("Coordinator"))
                        {
                            plFlowViewEmp.Visible = false;
                            plFlowViewAdmin.Visible = false;
                            plFlowViewCoordinator.Visible = true;
                            SetFormCoordinatorData();
                            SetDeptCoordinator();
                            SetNameCoordinator_DataBind();
                            //if (rsBas != null)
                            //{
                            //    if (ddlDeptCoordinator.Items.FindItemByValue(rsBas.DeptmCode) != null)
                            //        ddlDeptCoordinator.Items.FindItemByValue(rsBas.DeptmCode).Selected = true;

                            //    if (txtNameCoordinator.Items.FindItemByValue(rsBas.Nobr) != null)
                            //        txtNameCoordinator.Items.FindItemByValue(rsBas.Nobr).Selected = true;
                            //}
                            txtDateBCoordinator.SelectedDate = dDateB;
                            txtDateECoordinator.SelectedDate = dDateE;

                            #region 返回上一頁時的帶入參數動作
                            NameValueCollection coll = Request.QueryString;
                            if (coll.Count != 0)
                            {
                                if (ProcessID != "")
                                    txtProcessIdCoordinator.Text = ProcessID;
                                if (Dept != "")
                                {
                                    if (ddlDeptCoordinator.Items.FindItemByValue(Dept) != null)
                                    {
                                        ddlDeptCoordinator.Items.FindItemByValue(Dept).Selected = true;
                                        SetNameCoordinator_DataBind(Dept);
                                    }
                                }
                                else
                                    SetNameCoordinator_DataBind();

                                if (EmpID != "")
                                {
                                    if (txtNameCoordinator.Items.FindItemByValue(EmpID) != null)
                                        txtNameCoordinator.Items.FindItemByValue(EmpID).Selected = true;
                                }

                                if (Role != "")
                                {
                                    if (ddlRoleCoordinator.Items.FindItemByValue(Role) != null)
                                        ddlRoleCoordinator.Items.FindItemByValue(Role).Selected = true;
                                }
                                if (DateB != "")
                                    txtDateBCoordinator.SelectedDate = Convert.ToDateTime(DateB);
                                if (DateE != "")
                                    txtDateECoordinator.SelectedDate = Convert.ToDateTime(DateE);
                                if (State != "")
                                {
                                    if (ddlStateCoordinator.Items.FindItemByValue(State) != null)
                                        ddlStateCoordinator.Items.FindItemByValue(State).Selected = true;
                                }
                                if (FormsCode != "")
                                {
                                    if (ddlFormCoordinator.Items.FindItemByValue(FormsCode) != null)
                                        ddlFormCoordinator.Items.FindItemByValue(FormsCode).Selected = true;
                                }
                                btnSearchCoordinator_Click(null, null);
                            }
                            #endregion
                        }
                        else
                        {
                            plFlowViewEmp.Visible = true;
                            plFlowViewAdmin.Visible = false;
                            plFlowViewCoordinator.Visible = false;
                            SetFormEmpData();
                            txtDateBEmp.SelectedDate = dDateB;
                            txtDateEEmp.SelectedDate = dDateE;

                            #region 返回上一頁時的帶入參數動作
                            NameValueCollection coll = Request.QueryString;
                            if (coll.Count != 0)
                            {
                                if (ProcessID != "")
                                    txtProcessIdEmp.Text = ProcessID;

                                if (Role != "")
                                {
                                    if (ddlRoleEmp.Items.FindItemByValue(Role) != null)
                                        ddlRoleEmp.Items.FindItemByValue(Role).Selected = true;
                                }
                                if (DateB != "")
                                    txtDateBEmp.SelectedDate = Convert.ToDateTime(DateB);
                                if (DateE != "")
                                    txtDateEEmp.SelectedDate = Convert.ToDateTime(DateE);
                                if (FormsCode != "")
                                {
                                    if (ddlFormEmp.Items.FindItemByValue(FormsCode) != null)
                                        ddlFormEmp.Items.FindItemByValue(FormsCode).Selected = true;
                                }
                                btnSearchEmp_Click(null, null);
                            }
                            #endregion
                        }
                    }
                }
            }
        }

        #region 管理者

        private void SetFormAdminData()//顯示目前現有的流程表單
        {
            var rsForm = (from c in dcFlow.Forms
                          where c.Sort != 0
                          orderby c.Sort
                          select new
                          {
                              Code = c.Code,
                              Name = c.Name,
                          }).ToList();

            ddlFormAdmin.DataSource = rsForm;
            ddlFormAdmin.DataTextField = "Name";
            ddlFormAdmin.DataValueField = "Code";
            ddlFormAdmin.DataBind();
        }


        private void SetDeptAdmin()//部門名稱取得
        {
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);
            var rsDept = oDeptDao.GetDept();

            ddlDeptAdmin.DataSource = rsDept;
            ddlDeptAdmin.DataTextField = "Name";
            ddlDeptAdmin.DataValueField = "Code";
            ddlDeptAdmin.DataBind();
        }


        private void SetNameAdmin_DataBind(string Deptm = "")//員工姓名取得
        {
            List<string> Dept = new List<string> { };
            if (Deptm == "")
            {
                Dept = _User.EmpDeptCode;
            }
            else
            {
                Dept.Add(Deptm);
            }

            var rsPeopleByDept = new List<PeopleByDeptRow>();
            {
                var oPeopleByDept = new PeopleByDeptDao();
                var PeopleByDeptCond = new PeopleByDeptConditions();
                PeopleByDeptCond.AccessToken = _User.AccessToken;
                PeopleByDeptCond.RefreshToken = _User.RefreshToken;
                PeopleByDeptCond.CompanySetting = CompanySetting;
                PeopleByDeptCond.checkDate = DateTime.Now.Date;
                PeopleByDeptCond.deptList = Dept;
                var Result = oPeopleByDept.GetData(PeopleByDeptCond);

                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        rsPeopleByDept = Result.Data as List<PeopleByDeptRow>;

                    }
                }
            }
            //從部門代碼取得人員資訊
            var rsEmployeeView = new List<EmployeeViewRow>();
            {
                var ListEmpId = new List<string>();
                if (rsPeopleByDept != null)
                {
                    ListEmpId = rsPeopleByDept.Select(p => p.EmpId).ToList();
                }
                else
                {
                    ListEmpId.Add(_User.EmpId);
                }
                var oEmployeeView = new EmployeeViewDao();
                var EmployeeViewCond = new EmployeeViewConditions();
                EmployeeViewCond.AccessToken = _User.AccessToken;
                EmployeeViewCond.RefreshToken = _User.RefreshToken;
                EmployeeViewCond.CompanySetting = CompanySetting;
                EmployeeViewCond.ListEmpId = ListEmpId;
                var Result = oEmployeeView.GetData(EmployeeViewCond);

                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        rsEmployeeView = Result.Data as List<EmployeeViewRow>;
                    }
                }
            }

            var rs = new List<TextValueRow>();
            if (rsEmployeeView != null)
            {
                foreach (var rEmployeeView in rsEmployeeView)
                {
                    var r = new TextValueRow();
                    r.Text = rEmployeeView.EmpName + "," + rEmployeeView.EmpId;
                    r.Value = rEmployeeView.EmpId;
                    rs.Add(r);
                }
            }
            rs = rs.OrderBy(p => p.Value).ToList();
            txtNameAdmin.DataSource = rs;
            txtNameAdmin.DataTextField = "Text";
            txtNameAdmin.DataValueField = "Value";
            txtNameAdmin.DataBind();
        }


        private void SetSignName()//指向簽核名單取得
        {
            var rsData = new List<PeopleRow>();
            var oPeople = new PeopleDao();
            var PeopleCond = new PeopleConditions();
            PeopleCond.AccessToken = _User.AccessToken;
            PeopleCond.RefreshToken = _User.RefreshToken;
            PeopleCond.CompanySetting = CompanySetting;
            var Result = oPeople.GetData(PeopleCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                    rsData = Result.Data as List<PeopleRow>;

            }
            var rs = new List<TextValueRow>();
            if (rsData != null)
            {
                foreach (var rData in rsData)
                {
                    var r = new TextValueRow();
                    r.Text = r.Text = rData.EmpName + "," + rData.EmpId;
                    r.Value = rData.EmpId;
                    rs.Add(r);
                }
            }
            txtSignName.DataSource = rs;
            txtSignName.DataTextField = "Text";
            txtSignName.DataValueField = "Value";
            txtSignName.DataBind();
        }


        protected void btnSearchAdmin_Click(object sender, EventArgs e)//管理者查詢按鈕動作
        {

            DateTime DateB = txtDateBAdmin.SelectedDate.Value;
            DateTime DateE = txtDateEAdmin.SelectedDate.Value;

            if (DateB > DateE)
            {
                lblMsg.Text = "開始日期不可大於結束日期";
                lblMsg.CssClass = "badge-danger";
                return;
            }

            int SelectValue = Convert.ToInt32(ddlStateAdmin.SelectedItem.Value);
            string Nobr = "";
            Nobr = txtNameAdmin.SelectedValue;
            string ProcessId = "";
            ProcessId = txtProcessIdAdmin.Text;
            string FormsCode = "";
            if (ddlFormAdmin.SelectedValue != "0")
                FormsCode = ddlFormAdmin.SelectedValue;



            var result = new List<FormViewRow>();
            switch (ddlRoleAdmin.SelectedValue)
            {
                case "0"://申請者
                    result = (from App in dcFlow.FormsApp
                              join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
                              join Form in dcFlow.Forms on App.FormsCode equals Form.Code
                              join ApView in dcFlow.ProcessApView on App.idProcess equals ApView.ProcessFlow_id
                              where App.DateTimeA > DateB && App.DateTimeA < DateE
                              && App.SignState == SelectValue.ToString()
                              && (Nobr == "" || App.EmpId == Nobr)
                              && (ProcessId == "" || App.ProcessID == ProcessId)
                              && (FormsCode == "" || App.FormsCode == FormsCode)
                              select new FormViewRow
                              {
                                  ProcessId = App.ProcessID,
                                  ADate = App.DateTimeA,
                                  Application = App.EmpId + "," + App.EmpName,
                                  EmpId = App.EmpId,
                                  FlowCode = Form.Code,
                                  FlowName = Form.Name,
                                  DateB = App.DateTimeA,
                                  DateE = (!Process.isCancel.Value && !Process.isError.Value && !Process.isFinish.Value) ? null : App.DateTimeD,
                                  ApViewAuto = ApView.auto.ToString(),
                                  FormState = !(bool)Process.isError ? App.SignState != "1" ? App.SignState != "2" ? App.SignState != "3" ? App.SignState != "7" ? App.SignState == "4" ? "已作廢" : "" : "已抽單" : "已完成" : "已駁回" : "進行中" : "異常",
                              }).Distinct().ToList();

                    break;
                case "1"://被申請者
                    result = (from App in dcFlow.FormsApp
                              join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
                              join Form in dcFlow.Forms on App.FormsCode equals Form.Code
                              join AppInfo in dcFlow.FormsAppInfo on App.idProcess equals AppInfo.idProcess
                              join ApView in dcFlow.ProcessApView on App.idProcess equals ApView.ProcessFlow_id
                              where App.DateTimeA > DateB && App.DateTimeA < DateE
                               && (Nobr == "" || AppInfo.EmpId == Nobr)
                               && App.SignState == SelectValue.ToString()
                               && (ProcessId == "" || App.ProcessID == ProcessId)
                               && (FormsCode == "" || App.FormsCode == FormsCode)
                              select new FormViewRow
                              {
                                  ProcessId = App.ProcessID,
                                  ADate = App.DateTimeA,
                                  Application = App.EmpId + "," + App.EmpName,
                                  EmpId = AppInfo.EmpId,
                                  FlowCode = Form.Code,
                                  FlowName = Form.Name,
                                  DateB = App.DateTimeA,
                                  DateE = (!Process.isCancel.Value && !Process.isError.Value && !Process.isFinish.Value) ? null : App.DateTimeD,
                                  ApViewAuto = ApView.auto.ToString(),
                                  FormState = !(bool)Process.isError ? App.SignState != "1" ? App.SignState != "2" ? App.SignState != "3" ? App.SignState != "7" ? App.SignState == "4" ? "已作廢" : "" : "已抽單" : "已完成" : "已駁回" : "進行中" : "異常",
                              }).Distinct().ToList();

                    break;
                case "2"://審核者
                    result = (from App in dcFlow.FormsApp
                              join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
                              join Form in dcFlow.Forms on App.FormsCode equals Form.Code
                              join SignM in dcFlow.FormsSign on App.idProcess equals SignM.idProcess
                              join ApView in dcFlow.ProcessApView on App.idProcess equals ApView.ProcessFlow_id
                              where App.DateTimeA > DateB && App.DateTimeA < DateE
                              && (Nobr == "" || SignM.EmpId == Nobr)
                              && App.SignState == SelectValue.ToString()
                              && (ProcessId == "" || App.ProcessID == ProcessId)
                              && (FormsCode == "" || App.FormsCode == FormsCode)
                              select new FormViewRow
                              {
                                  ProcessId = App.ProcessID,
                                  ADate = App.DateTimeA,
                                  Application = App.EmpId + "," + App.EmpName,
                                  EmpId = SignM.EmpId,
                                  FlowCode = Form.Code,
                                  FlowName = Form.Name,
                                  DateB = App.DateTimeA,
                                  DateE = (!Process.isCancel.Value && !Process.isError.Value && !Process.isFinish.Value) ? null : App.DateTimeD,
                                  ApViewAuto = ApView.auto.ToString(),
                                  FormState = !(bool)Process.isError ? App.SignState != "1" ? App.SignState != "2" ? App.SignState != "3" ? App.SignState != "7" ? App.SignState == "4" ? "已作廢" : "" : "已抽單" : "已完成" : "已駁回" : "進行中" : "異常",
                              }).Distinct().ToList();

                    break;
                case "3"://正在審核
                    result = (from App in dcFlow.FormsApp
                              join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
                              join Form in dcFlow.Forms on App.FormsCode equals Form.Code
                              join ApView in dcFlow.ProcessApView on App.idProcess equals ApView.ProcessFlow_id
                              join Node in dcFlow.ProcessNode on App.idProcess equals Node.ProcessFlow_id
                              join Check in dcFlow.ProcessCheck on Node.auto equals Check.ProcessNode_auto
                              where App.DateTimeA > DateB && App.DateTimeA < DateE
                              && (Nobr == "" || Check.Emp_idDefault == Nobr)
                              && App.SignState == "1"
                              && (ProcessId == "" || App.ProcessID == ProcessId)
                              && (FormsCode == "" || App.FormsCode == FormsCode)
                              && Node.isFinish != true
                              orderby Check.adate descending
                              select new FormViewRow
                              {
                                  ProcessId = App.ProcessID,
                                  ADate = App.DateTimeA,
                                  Application = App.EmpId + "," + App.EmpName,
                                  EmpId = Check.Emp_idDefault,
                                  FlowCode = Form.Code,
                                  FlowName = Form.Name,
                                  DateB = App.DateTimeA,
                                  DateE = (!Process.isCancel.Value && !Process.isError.Value && !Process.isFinish.Value) ? null : App.DateTimeD,
                                  ApViewAuto = ApView.auto.ToString(),
                                  FormState = !(bool)Process.isError ? App.SignState != "1" ? App.SignState != "2" ? App.SignState != "3" ? App.SignState != "7" ? App.SignState == "4" ? "已作廢" : "" : "已抽單" : "已完成" : "已駁回" : "進行中" : "異常",
                              }).Distinct().ToList();


                    break;
            }

            List<string> EmpId = new List<string> { };

            var oDept = new DeptDao();
            var DeptCond = new DeptConditions();
            DeptCond.AccessToken = _User.AccessToken;
            DeptCond.RefreshToken = _User.RefreshToken;
            DeptCond.CompanySetting = CompanySetting;
            var DeptResult = oDept.GetData(DeptCond);
            if (DeptResult.Status && DeptResult.Data != null)
            {
                var rsDept = DeptResult.Data as List<DeptRow>;

                var rsPeopleByDept = new List<PeopleByDeptRow>();
                {
                    var oPeopleByDept = new PeopleByDeptDao();
                    var PeopleByDeptCond = new PeopleByDeptConditions();
                    PeopleByDeptCond.AccessToken = _User.AccessToken;
                    PeopleByDeptCond.RefreshToken = _User.RefreshToken;
                    PeopleByDeptCond.CompanySetting = CompanySetting;
                    PeopleByDeptCond.checkDate = DateTime.Now.Date;
                    PeopleByDeptCond.deptList = rsDept.Select(p => p.DeptCode).ToList();
                    var Result = oPeopleByDept.GetData(PeopleByDeptCond);

                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            rsPeopleByDept = Result.Data as List<PeopleByDeptRow>;
                            EmpId = rsPeopleByDept.Select(p => p.EmpId).ToList();
                        }
                    }
                }
            }


            foreach (var c in result.ToArray())
            {
                if (!EmpId.Contains(c.EmpId))
                {
                    result.Remove(c);
                }
            }

            foreach (var c in result)
            {
                string SignEmpId = "";
                var rsProcessNode = (from pn in dcFlow.ProcessNode
                                     join pc in dcFlow.ProcessCheck on pn.auto equals pc.ProcessNode_auto
                                     where pn.ProcessFlow_id.ToString() == c.ProcessId
                                     orderby pn.adate.Value descending
                                     select pc).FirstOrDefault();

                if (rsProcessNode != null)
                {
                    var rEmp = (from emp in dcFlow.Emp
                                where emp.id == rsProcessNode.Emp_idDefault
                                select emp).FirstOrDefault();

                    if (rEmp != null)
                        SignEmpId = rEmp.id + "," + rEmp.name;
                }

                c.SignEmpId = SignEmpId;//目前簽核主管
            }

            //foreach (var r in result)
            //{
            //    r.FlowId = rsApParm.Where(p => p.ProcessFlow_id.ToString() == r.ProcessId).OrderBy(p => p.auto).Select(p => p.auto).FirstOrDefault().ToString();
            //}

            lvMain.DataSource = result.OrderByDescending(p => p.ProcessId);
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }


        protected void btnActive_Click(object sender, EventArgs e)//管理者工具執行動作
        {
            int Effective = 0;
            string NobrSign = "";
            NobrSign = txtSignName.SelectedValue;

            List<int> lsProcessID = new List<int>();
            int SelectValue = Convert.ToInt32(txtActiveAdmin.SelectedItem.Value);

            foreach (var item in lvMain.Items)
            {
                var ckbSelecte = item.FindControl("ckbSelecte") as RadCheckBox;
                if (ckbSelecte.Checked == true)
                {
                    var lblProcessId = item.FindControl("lblProcessId") as RadLabel;
                    if (lblProcessId != null)
                        lsProcessID.Add(Convert.ToInt32(lblProcessId.Text));
                }
            }
            //FlowState flowState = 0;

            ezEngineServices.Service oService = new ezEngineServices.Service(dcFlow.Connection);

            List<int> rsProcessID = new List<int>();
            switch (SelectValue)
            {
                case 1: //重送流程
                    rsProcessID = oService.FlowResubmitByRWD(lsProcessID, false, _User.EmpId);
                    break;
                case 2: //上點重送
                    rsProcessID = oService.FlowResubmitByRWD(lsProcessID, true, _User.EmpId);
                    break;
                case 3: //核准
                    rsProcessID = oService.FlowStateSetByRWD(lsProcessID, ezEngineServices.FlowState.Approve, _User.EmpId);
                    break;
                case 4: //駁回
                    rsProcessID = oService.FlowStateSetByRWD(lsProcessID, ezEngineServices.FlowState.Reject, _User.EmpId);
                    break;
                case 5: //作廢
                    rsProcessID = oService.FlowStateSetByRWD(lsProcessID, ezEngineServices.FlowState.Cancel, _User.EmpId);
                    break;
                case 6: //刪除實體資料
                    rsProcessID = oService.FlowStateSetByRWD(lsProcessID, ezEngineServices.FlowState.Delete, _User.EmpId);
                    break;
                case 7: //指向正職簽核
                    if (NobrSign.Length > 0)
                    {
                        ezEngineServices.CMan oCMan = new ezEngineServices.CMan();
                        oCMan.idEmp = NobrSign;
                        rsProcessID = oService.FlowSignSet(lsProcessID, oCMan);
                    }
                    break;
                case 8: //指向代理簽核
                    if (NobrSign.Length > 0)
                    {
                        ezEngineServices.CMan oCMan = new ezEngineServices.CMan();
                        oCMan.idEmp = NobrSign;
                        rsProcessID = oService.FlowSignSet(lsProcessID, null, oCMan);
                    }
                    break;
                //case 9: //下點傳送
                //    rsProcessID = oService.FlowSignWorkFinish(lsProcessID, lblNobr.Text);
                //    break;
                case 10: //通知
                    rsProcessID = oService.ProcessFlowSendMail(lsProcessID, _User.EmpId);
                    break;
                default:
                    break;
            }

            //var oFlowStateSetDao = new FlowStateSetDao();
            //var FlowStateSetCond = new FlowStateSetConditions();

            //FlowStateSetCond.AccessToken = _User.AccessToken;
            //FlowStateSetCond.RefreshToken = _User.RefreshToken;
            //FlowStateSetCond.CompanySetting = CompanySetting;
            //FlowStateSetCond.State = flowState;
            //FlowStateSetCond.lsProcessID = lsProcessID;
            //FlowStateSetCond.idEmp = _User.EmpId;
            //var rsFlowStateSet = oFlowStateSetDao.GetData(FlowStateSetCond);
            //var rFlowStateSet = new FlowStateSetRow();
            //if (rsFlowStateSet.Status)
            //{
            //    if (rsFlowStateSet.Data != null)
            //    {
            //        rFlowStateSet = rsFlowStateSet.Data as FlowStateSetRow;
            //        Effective = rFlowStateSet.Result.Count;
            //    }
            //}


            btnSearchAdmin_Click(null, null);

            lblMsg.Text = "已完成：" + rsProcessID.Count.ToString() + "表單" + txtActiveAdmin.SelectedItem.Text;
            lblMsg.CssClass = "badge-danger";

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }


        protected void ckbAll_Click(object sender, EventArgs e)//全選
        {
            if (ckbAll.Checked == true)
            {
                foreach (var item in lvMain.Items)
                {
                    var ckbSelecte = item.FindControl("ckbSelecte") as RadCheckBox;


                    if (ckbSelecte != null)
                    {
                        ckbSelecte.Checked = true;
                    }
                }
            }
            else
            {
                foreach (var item in lvMain.Items)
                {
                    var ckbSelecte = item.FindControl("ckbSelecte") as RadCheckBox;


                    if (ckbSelecte != null)
                    {
                        ckbSelecte.Checked = false;
                    }
                }
            }


            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }


        protected void txtActive_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)//管理者工具選擇動作
        {
            txtSignName.Visible = false;
            if (e.Value == "7" || e.Value == "8")
                txtSignName.Visible = true;
        }

        protected void ddlDeptAdmin_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)//管理者部門名稱清單取得
        {
            List<string> DeptCode = new List<string>();
            DeptCode.Add(ddlDeptAdmin.SelectedValue);

            SetNameAdmin_DataBind(ddlDeptAdmin.SelectedValue);
            if (txtNameAdmin.Items.Count != 0)
                txtNameAdmin.Items.FirstOrDefault().Selected = true;
            else
                txtNameAdmin.Text = "";

        }
        #endregion

        #region 助理

        private void SetFormCoordinatorData()//顯示目前現有的流程表單
        {
            var rsForm = (from c in dcFlow.Forms
                          where c.Sort != 0
                          orderby c.Sort
                          select new
                          {
                              Code = c.Code,
                              Name = c.Name,
                          }).ToList();

            ddlFormCoordinator.DataSource = rsForm;
            ddlFormCoordinator.DataTextField = "Name";
            ddlFormCoordinator.DataValueField = "Code";
            ddlFormCoordinator.DataBind();
        }

        private void SetDeptCoordinator()//部門名稱取得
        {
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);
            var lsCode = new List<string>();
            lsCode.Add(_User.Dept);
            lsCode.AddRange(_User.EmpDeptCode);
            var rsDept = oDeptDao.GetDept(lsCode,new List<string>());

            ddlDeptCoordinator.DataSource = rsDept;
            ddlDeptCoordinator.DataTextField = "Name";
            ddlDeptCoordinator.DataValueField = "Code";
            ddlDeptCoordinator.DataBind();
        }

        private void SetNameCoordinator_DataBind(string Deptm = "")//助理員工姓名清單資料取得
        {
            if (Deptm == "")
            {
                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rsBas = oBasDao.GetBaseByNobr(_User.EmpId, DateTime.Now).FirstOrDefault();

                List<OldBll.Bas.Vdb.BaseTable> rsDeptPeople = new List<OldBll.Bas.Vdb.BaseTable>();
                if (rsBas != null)
                    rsDeptPeople = oBasDao.GetBaseByDept(rsBas.DeptmCode, "1", false, true);


                txtNameCoordinator.DataSource = rsDeptPeople;
                txtNameCoordinator.DataTextField = "Name";
                txtNameCoordinator.DataValueField = "Nobr";
                txtNameCoordinator.DataBind();
            }
            else
            {
                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rsBas = oBasDao.GetBaseByNobr(_User.EmpId, DateTime.Now).FirstOrDefault();

                List<OldBll.Bas.Vdb.BaseTable> rsDeptPeople = new List<OldBll.Bas.Vdb.BaseTable>();
                if (rsBas != null)
                    rsDeptPeople = oBasDao.GetBaseByDept(Deptm, "1", false, true);


                txtNameCoordinator.DataSource = rsDeptPeople;
                txtNameCoordinator.DataTextField = "Name";
                txtNameCoordinator.DataValueField = "Nobr";
                txtNameCoordinator.DataBind();
            }

        }

        protected void btnSearchCoordinator_Click(object sender, EventArgs e)//助理查詢
        {

            DateTime DateB = txtDateBCoordinator.SelectedDate.Value;
            DateTime DateE = txtDateECoordinator.SelectedDate.Value;

            if (DateB > DateE)
            {
                lblMsg.Text = "開始日期不可大於結束日期";
                lblMsg.CssClass = "badge-danger";
                return;
            }

            int SelectValue = Convert.ToInt32(ddlStateCoordinator.SelectedItem.Value);
            string Nobr = "";
            Nobr = txtNameCoordinator.SelectedValue;
            string ProcessId = "";
            ProcessId = txtProcessIdCoordinator.Text;
            string FormsCode = "";
            if (ddlFormCoordinator.SelectedValue != "0")
                FormsCode = ddlFormCoordinator.SelectedValue;

            var result = new List<FormViewRow>();
            switch (ddlRoleCoordinator.SelectedValue)
            {
                case "0"://申請者
                    result = (from App in dcFlow.FormsApp
                              join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
                              join Form in dcFlow.Forms on App.FormsCode equals Form.Code
                              join ApView in dcFlow.ProcessApView on App.idProcess equals ApView.ProcessFlow_id
                              where App.DateTimeA > DateB && App.DateTimeA < DateE
                              && App.SignState == SelectValue.ToString()
                              && (Nobr == "" || App.EmpId == Nobr)
                              && (ProcessId == "" || App.ProcessID == ProcessId)
                              && (FormsCode == "" || App.FormsCode == FormsCode)
                              select new FormViewRow
                              {
                                  ProcessId = App.ProcessID,
                                  ADate = App.DateTimeA,
                                  Application = App.EmpId + "," + App.EmpName,
                                  EmpId = App.EmpId,
                                  FlowCode = Form.Code,
                                  FlowName = Form.Name,
                                  DateB = App.DateTimeA,
                                  DateE = (!Process.isCancel.Value && !Process.isError.Value && !Process.isFinish.Value) ? null : App.DateTimeD,
                                  ApViewAuto = ApView.auto.ToString(),
                                  FormState = !(bool)Process.isError ? App.SignState != "1" ? App.SignState != "2" ? App.SignState != "3" ? App.SignState != "7" ? App.SignState == "4" ? "已作廢" : "" : "已抽單" : "已完成" : "已駁回" : "進行中" : "異常",
                              }).Distinct().ToList();
                    break;
                case "1"://被申請者
                    result = (from App in dcFlow.FormsApp
                              join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
                              join Form in dcFlow.Forms on App.FormsCode equals Form.Code
                              join AppInfo in dcFlow.FormsAppInfo on App.idProcess equals AppInfo.idProcess
                              join ApView in dcFlow.ProcessApView on App.idProcess equals ApView.ProcessFlow_id
                              where App.DateTimeA > DateB && App.DateTimeA < DateE
                               && AppInfo.EmpId == Nobr
                               && App.SignState == SelectValue.ToString()
                               && (ProcessId == "" || App.ProcessID == ProcessId)
                               && (Nobr == "" || AppInfo.EmpId == Nobr)
                               && (FormsCode == "" || App.FormsCode == FormsCode)
                              select new FormViewRow
                              {
                                  ProcessId = App.ProcessID,
                                  ADate = App.DateTimeA,
                                  Application = App.EmpId + "," + App.EmpName,
                                  EmpId = AppInfo.EmpId,
                                  FlowCode = Form.Code,
                                  FlowName = Form.Name,
                                  DateB = App.DateTimeA,
                                  DateE = (!Process.isCancel.Value && !Process.isError.Value && !Process.isFinish.Value) ? null : App.DateTimeD,
                                  ApViewAuto = ApView.auto.ToString(),
                                  FormState = !(bool)Process.isError ? App.SignState != "1" ? App.SignState != "2" ? App.SignState != "3" ? App.SignState != "7" ? App.SignState == "4" ? "已作廢" : "" : "已抽單" : "已完成" : "已駁回" : "進行中" : "異常",
                              }).Distinct().ToList();

                    break;
                case "2"://審核者
                    result = (from App in dcFlow.FormsApp
                              join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
                              join Form in dcFlow.Forms on App.FormsCode equals Form.Code
                              join SignM in dcFlow.FormsSign on App.idProcess equals SignM.idProcess
                              join ApView in dcFlow.ProcessApView on App.idProcess equals ApView.ProcessFlow_id
                              where App.DateTimeA > DateB && App.DateTimeA < DateE
                              && (Nobr == "" || SignM.EmpId == Nobr)
                              && App.SignState == SelectValue.ToString()
                              && (ProcessId == "" || App.ProcessID == ProcessId)
                              && (FormsCode == "" || App.FormsCode == FormsCode)
                              select new FormViewRow
                              {
                                  ProcessId = App.ProcessID,
                                  ADate = App.DateTimeA,
                                  Application = App.EmpId + "," + App.EmpName,
                                  EmpId = SignM.EmpId,
                                  FlowCode = Form.Code,
                                  FlowName = Form.Name,
                                  DateB = App.DateTimeA,
                                  DateE = (!Process.isCancel.Value && !Process.isError.Value && !Process.isFinish.Value) ? null : App.DateTimeD,
                                  ApViewAuto = ApView.auto.ToString(),
                                  FormState = !(bool)Process.isError ? App.SignState != "1" ? App.SignState != "2" ? App.SignState != "3" ? App.SignState != "7" ? App.SignState == "4" ? "已作廢" : "" : "已抽單" : "已完成" : "已駁回" : "進行中" : "異常",
                              }).Distinct().ToList();

                    break;
                case "3"://正在審核
                    result = (from App in dcFlow.FormsApp
                              join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
                              join Form in dcFlow.Forms on App.FormsCode equals Form.Code
                              join ApView in dcFlow.ProcessApView on App.idProcess equals ApView.ProcessFlow_id
                              join Node in dcFlow.ProcessNode on App.idProcess equals Node.ProcessFlow_id
                              join Check in dcFlow.ProcessCheck on Node.auto equals Check.ProcessNode_auto
                              where App.DateTimeA > DateB && App.DateTimeA < DateE
                              && (Nobr == "" || Check.Emp_idDefault == Nobr)
                              && App.SignState == "1"
                              && (ProcessId == "" || App.ProcessID == ProcessId)
                              && (FormsCode == "" || App.FormsCode == FormsCode)
                              && Node.isFinish != true
                              orderby Check.adate descending
                              select new FormViewRow
                              {
                                  ProcessId = App.ProcessID,
                                  ADate = App.DateTimeA,
                                  Application = App.EmpId + "," + App.EmpName,
                                  EmpId = Check.Emp_idDefault,
                                  FlowCode = Form.Code,
                                  FlowName = Form.Name,
                                  DateB = App.DateTimeA,
                                  DateE = (!Process.isCancel.Value && !Process.isError.Value && !Process.isFinish.Value) ? null : App.DateTimeD,
                                  ApViewAuto = ApView.auto.ToString(),
                                  FormState = !(bool)Process.isError ? App.SignState != "1" ? App.SignState != "2" ? App.SignState != "3" ? App.SignState != "7" ? App.SignState == "4" ? "已作廢" : "" : "已抽單" : "已完成" : "已駁回" : "進行中" : "異常",
                              }).Distinct().ToList();


                    break;
            }

            List<string> EmpId = new List<string> { };

            var oDept = new DeptDao();
            var DeptCond = new DeptConditions();
            DeptCond.AccessToken = _User.AccessToken;
            DeptCond.RefreshToken = _User.RefreshToken;
            DeptCond.CompanySetting = CompanySetting;
            var DeptResult = oDept.GetData(DeptCond);
            if (DeptResult.Status && DeptResult.Data != null)
            {
                var rsDept = DeptResult.Data as List<DeptRow>;

                var rsPeopleByDept = new List<PeopleByDeptRow>();
                {
                    var oPeopleByDept = new PeopleByDeptDao();
                    var PeopleByDeptCond = new PeopleByDeptConditions();
                    PeopleByDeptCond.AccessToken = _User.AccessToken;
                    PeopleByDeptCond.RefreshToken = _User.RefreshToken;
                    PeopleByDeptCond.CompanySetting = CompanySetting;
                    PeopleByDeptCond.checkDate = DateTime.Now.Date;
                    PeopleByDeptCond.deptList = rsDept.Select(p => p.DeptCode).ToList();
                    var Result = oPeopleByDept.GetData(PeopleByDeptCond);

                    if (Result.Status)
                    {
                        if (Result.Data != null)
                        {
                            rsPeopleByDept = Result.Data as List<PeopleByDeptRow>;
                            EmpId = rsPeopleByDept.Select(p => p.EmpId).ToList();
                        }
                    }
                }
            }


            foreach (var c in result.ToArray())
            {
                if (!EmpId.Contains(c.EmpId))
                {
                    result.Remove(c);
                }
            }

            foreach (var c in result)
            {
                string SignEmpId = "";
                var rsProcessNode = (from pn in dcFlow.ProcessNode
                                     join pc in dcFlow.ProcessCheck on pn.auto equals pc.ProcessNode_auto
                                     where pn.ProcessFlow_id.ToString() == c.ProcessId
                                     orderby pn.adate.Value descending
                                     select pc).FirstOrDefault();

                if (rsProcessNode != null)
                {
                    var rEmp = (from emp in dcFlow.Emp
                                where emp.id == rsProcessNode.Emp_idDefault
                                select emp).FirstOrDefault();

                    if (rEmp != null)
                        SignEmpId = rEmp.id + "," + rEmp.name;
                }

                c.SignEmpId = SignEmpId;//目前簽核主管
            }


            lvMain.DataSource = result.OrderByDescending(p => p.ProcessId);
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }


        protected void ddlDeptCoordinator_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)//助理部門名稱清單取得
        {
            List<string> DeptCode = new List<string>();
            DeptCode.Add(ddlDeptCoordinator.SelectedValue);

            SetNameCoordinator_DataBind(ddlDeptCoordinator.SelectedValue);
            if (txtNameCoordinator.Items.Count != 0)
                txtNameCoordinator.Items.FirstOrDefault().Selected = true;
            else
                txtNameCoordinator.Text = "";

        }

        #endregion

        #region 一般員工
        private void SetFormEmpData()//顯示目前現有的流程表單
        {
            var rsForm = (from c in dcFlow.Forms
                          where c.Sort != 0
                          orderby c.Sort
                          select new
                          {
                              Code = c.Code,
                              Name = c.Name,
                          }).ToList();

            ddlFormEmp.DataSource = rsForm;
            ddlFormEmp.DataTextField = "Name";
            ddlFormEmp.DataValueField = "Code";
            ddlFormEmp.DataBind();
        }

        protected void btnSearchEmp_Click(object sender, EventArgs e)//一般員工查詢
        {
            DateTime DateB = txtDateBEmp.SelectedDate.Value;
            DateTime DateE = txtDateEEmp.SelectedDate.Value;


            string FormsCode = "";
            if (ddlFormEmp.SelectedValue != "0")
                FormsCode = ddlFormEmp.SelectedValue;
            string ProcessId = "";
            ProcessId = txtProcessIdEmp.Text;

            if (DateB > DateE)
            {
                lblMsg.Text = "開始日期不可大於結束日期";
                lblMsg.CssClass = "badge-danger";
                return;
            }

            var result = new List<FormViewRow>();
            switch (ddlRoleEmp.SelectedValue)
            {
                case "0"://申請者
                    result = (from App in dcFlow.FormsApp
                              join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
                              join Form in dcFlow.Forms on App.FormsCode equals Form.Code
                              join ApView in dcFlow.ProcessApView on App.idProcess equals ApView.ProcessFlow_id
                              where App.DateTimeA >= DateB && App.DateTimeA <= DateE
                              && App.EmpId == _User.EmpId
                              && (ProcessId == "" || App.ProcessID == ProcessId)
                              && (FormsCode == "" || App.FormsCode == FormsCode)
                              && ((bool)isFinish.Checked ? ((bool)Process.isFinish || (bool)Process.isCancel || (bool)Process.isError)
                              : (!(bool)Process.isFinish && !(bool)Process.isCancel && !(bool)Process.isError))
                              select new FormViewRow
                              {
                                  ProcessId = App.ProcessID,
                                  ADate = App.DateTimeA,
                                  Application = App.EmpId + "," + App.EmpName,
                                  FlowCode = Form.Code,
                                  FlowName = Form.Name,
                                  DateB = App.DateTimeA,
                                  DateE = (!Process.isCancel.Value && !Process.isError.Value && !Process.isFinish.Value) ? null : App.DateTimeD,
                                  ApViewAuto = ApView.auto.ToString(),
                                  FormState = !(bool)Process.isError ? App.SignState != "1" ? App.SignState != "2" ? App.SignState != "3" ? App.SignState != "7" ? App.SignState == "4" ? "已作廢" : "" : "已抽單" : "已完成" : "已駁回" : "進行中" : "異常",
                              }).Distinct().ToList();
                    break;
                case "1"://被申請者
                    result = (from App in dcFlow.FormsApp
                              join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
                              join Form in dcFlow.Forms on App.FormsCode equals Form.Code
                              join AppInfo in dcFlow.FormsAppInfo on App.idProcess equals AppInfo.idProcess
                              join ApView in dcFlow.ProcessApView on App.idProcess equals ApView.ProcessFlow_id
                              where App.DateTimeA > DateB && App.DateTimeA < DateE
                               && AppInfo.EmpId == _User.EmpId
                               && (ProcessId == "" || App.ProcessID == ProcessId)
                               && (FormsCode == "" || App.FormsCode == FormsCode)
                               && ((bool)isFinish.Checked ? (bool)Process.isFinish || (bool)Process.isCancel || (bool)Process.isError
                              : !(bool)Process.isFinish && !(bool)Process.isCancel && !(bool)Process.isError)
                              select new FormViewRow
                              {
                                  ProcessId = App.ProcessID,
                                  ADate = App.DateTimeA,
                                  Application = App.EmpId + "," + App.EmpName,
                                  FlowCode = Form.Code,
                                  FlowName = Form.Name,
                                  DateB = App.DateTimeA,
                                  DateE = (!Process.isCancel.Value && !Process.isError.Value && !Process.isFinish.Value) ? null : App.DateTimeD,
                                  ApViewAuto = ApView.auto.ToString(),
                                  FormState = !(bool)Process.isError ? App.SignState != "1" ? App.SignState != "2" ? App.SignState != "3" ? App.SignState != "7" ? App.SignState == "4" ? "已作廢" : "" : "已抽單" : "已完成" : "已駁回" : "進行中" : "異常",
                              }).Distinct().ToList();

                    if (ckbNoShowMyProcessEmp.Checked == true)
                    {
                        result.RemoveAll(p => p.Application.Contains(_User.EmpId));
                    }

                    break;
                case "2"://審核者
                    result = (from App in dcFlow.FormsApp
                              join Process in dcFlow.ProcessFlow on App.idProcess equals Process.id
                              join Form in dcFlow.Forms on App.FormsCode equals Form.Code
                              join SignM in dcFlow.FormsSign on App.idProcess equals SignM.idProcess
                              join ApView in dcFlow.ProcessApView on App.idProcess equals ApView.ProcessFlow_id
                              where App.DateTimeA > DateB && App.DateTimeA < DateE
                              && SignM.EmpId == _User.EmpId
                              && (ProcessId == "" || App.ProcessID == ProcessId)
                              && (FormsCode == "" || App.FormsCode == FormsCode)
                              && ((bool)isFinish.Checked ? (bool)Process.isFinish || (bool)Process.isCancel || (bool)Process.isError
                              : !(bool)Process.isFinish && !(bool)Process.isCancel && !(bool)Process.isError)
                              select new FormViewRow
                              {
                                  ProcessId = App.ProcessID,
                                  ADate = App.DateTimeA,
                                  Application = App.EmpId + "," + App.EmpName,
                                  FlowCode = Form.Code,
                                  FlowName = Form.Name,
                                  DateB = App.DateTimeA,
                                  DateE = (!Process.isCancel.Value && !Process.isError.Value && !Process.isFinish.Value) ? null : App.DateTimeD,
                                  ApViewAuto = ApView.auto.ToString(),
                                  FormState = !(bool)Process.isError ? App.SignState != "1" ? App.SignState != "2" ? App.SignState != "3" ? App.SignState != "7" ? App.SignState == "4" ? "已作廢" : "" : "已抽單" : "已完成" : "已駁回" : "進行中" : "異常",
                              }).Distinct().ToList();

                    break;
            }

            foreach (var c in result)
            {
                string SignEmpId = "";
                var rsProcessNode = (from pn in dcFlow.ProcessNode
                                     join pc in dcFlow.ProcessCheck on pn.auto equals pc.ProcessNode_auto
                                     where pn.ProcessFlow_id.ToString() == c.ProcessId
                                     orderby pn.adate.Value descending
                                     select pc).FirstOrDefault();

                if (rsProcessNode != null)
                {
                    var rEmp = (from emp in dcFlow.Emp
                                where emp.id == rsProcessNode.Emp_idDefault
                                select emp).FirstOrDefault();

                    if (rEmp != null)
                        SignEmpId = rEmp.id + "," + rEmp.name;
                }

                c.SignEmpId = SignEmpId;//目前簽核主管
            }

            lvMain.DataSource = result.OrderByDescending(p => p.ProcessId);
            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        #endregion

        //private void SetRoleAdmin_DataBind()
        //{

        //    OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

        //    var rsBas = oBasDao.GetBaseByNobr(txtNameAdmin.SelectedValue, DateTime.Now).FirstOrDefault();
        //    if (rsBas != null)
        //    {
        //        var rsRole = (from role in dcFlow.Role
        //                      join emp in dcFlow.Emp on role.Emp_id equals emp.id
        //                      join dept in dcFlow.Dept on role.Dept_id equals dept.id
        //                      join pos in dcFlow.Pos on role.Pos_id equals pos.id
        //                      where role.Emp_id == txtNameAdmin.SelectedValue
        //                      select new
        //                      {
        //                          RoleId = role.id,
        //                          EmpNobr = emp.id,
        //                          EmpName = emp.name,
        //                          DeptCode = dept.id,
        //                          DeptName = dept.name,
        //                          JobCode = pos.id,
        //                          JobName = pos.name,
        //                          Auth = role.deptMg.Value,
        //                          Name = dept.name + "," + pos.name,
        //                      }).ToList();

        //        ddlRoleAdmin.DataSource = rsRole;
        //        ddlRoleAdmin.DataTextField = "Name";
        //        ddlRoleAdmin.DataValueField = "RoleId";
        //        ddlRoleAdmin.DataBind();
        //    }
        //    else
        //    {
        //        ddlRoleAdmin.Items.Clear();
        //    }
        //}
        protected void lvMain_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            //var btn = sender as RadButton;
            //btn.Target = "_blank";
            var ca = e.CommandArgument;
            var cn = e.CommandName;
            if (cn == "ViewImage")
            {
                UnobtrusiveSession.Session["RequestName"] = "View";
                UnobtrusiveSession.Session["idProcess"] = ca;
                //var s = "window.open('FormFlowImage.aspx?idProcess=" + ca + "','_blank')";
                //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "lvMain", s, true);
                string ProcessID = "";
                string EmpID = "";
                string Role = "";
                string DateB = "";
                string DateE = "";
                string State = "";
                string FormsCode = "";
                string Dept = "";


                if (_User.Role != null && (_User.Role.Contains("Admin") || _User.Role.Contains("Hr")))
                {
                    ProcessID = txtProcessIdAdmin.Text;
                    EmpID = txtNameAdmin.SelectedValue;
                    Role = ddlRoleAdmin.SelectedValue;
                    DateB = txtDateBAdmin.SelectedDate.Value.ToShortDateString();
                    DateE = txtDateEAdmin.SelectedDate.Value.ToShortDateString();
                    State = ddlStateAdmin.SelectedValue;
                    FormsCode = ddlFormAdmin.SelectedValue;
                    Dept = ddlDeptAdmin.SelectedValue;
                }
                else if (_User.Role != null && _User.Role.Contains("Coordinator"))
                {
                    ProcessID = txtProcessIdCoordinator.Text;
                    EmpID = txtNameCoordinator.SelectedValue;
                    Role = ddlRoleCoordinator.SelectedValue;
                    DateB = txtDateBCoordinator.SelectedDate.Value.ToShortDateString();
                    DateE = txtDateECoordinator.SelectedDate.Value.ToShortDateString();
                    State = ddlStateCoordinator.SelectedValue;
                    FormsCode = ddlFormCoordinator.SelectedValue;
                    Dept = ddlDeptCoordinator.SelectedValue;

                }
                else
                {
                    ProcessID = txtProcessIdEmp.Text;
                    Role = ddlRoleEmp.SelectedValue;
                    DateB = txtDateBEmp.SelectedDate.Value.ToShortDateString();
                    DateE = txtDateEEmp.SelectedDate.Value.ToShortDateString();
                    FormsCode = ddlFormEmp.SelectedValue;
                }

                UnobtrusiveSession.Session["ProcessID"] = ProcessID;
                UnobtrusiveSession.Session["EmpID"] = EmpID;
                UnobtrusiveSession.Session["Role"] = Role;
                UnobtrusiveSession.Session["DateB"] = DateB;
                UnobtrusiveSession.Session["DateE"] = DateE;
                UnobtrusiveSession.Session["State"] = State;
                UnobtrusiveSession.Session["FormsCode"] = FormsCode;
                UnobtrusiveSession.Session["Dept"] = Dept;
                Response.Redirect("FormFlowImage.aspx?idProcess=" + ca);
                return;
            }
            else
            {
                UnobtrusiveSession.Session["RequestName"] = "View";
                UnobtrusiveSession.Session["ProcessApViewAuto"] = cn;
                var oFormGetFlowViewUrlDao = new FormGetFlowViewUrlDao();
                var FormGetFlowViewUrlCond = new FormGetFlowViewUrlConditions();
                FormGetFlowViewUrlCond.AccessToken = _User.AccessToken;
                FormGetFlowViewUrlCond.RefreshToken = _User.RefreshToken;
                FormGetFlowViewUrlCond.CompanySetting = CompanySetting;
                FormGetFlowViewUrlCond.bOnlyUrl = true;
                FormGetFlowViewUrlCond.idProcess = Convert.ToInt32(ca);
                string TurnUrl = "";
                var rsFormGetFlowViewUrl = oFormGetFlowViewUrlDao.GetData(FormGetFlowViewUrlCond);
                var rFormGetFlowViewUrl = new FormGetFlowViewUrlRow();
                if (rsFormGetFlowViewUrl.Status)
                {
                    if (rsFormGetFlowViewUrl.Data != null)
                    {
                        rFormGetFlowViewUrl = rsFormGetFlowViewUrl.Data as FormGetFlowViewUrlRow;

                    }
                    TurnUrl = rFormGetFlowViewUrl.Url + "?";
                }
                string ViewUrl = TurnUrl + "ProcessApViewAuto=" + cn;
                //var Script = "window.open('" + ViewUrl + "','_blank')";
                //ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "lvMain", Script, true);
                string ProcessID = "";
                string EmpID = "";
                string Role = "";
                string DateB = "";
                string DateE = "";
                string State = "";
                string FormsCode = "";
                string Dept = "";


                if (_User.Role != null && (_User.Role.Contains("Admin") || _User.Role.Contains("Hr")))
                {
                    ProcessID = txtProcessIdAdmin.Text;
                    EmpID = txtNameAdmin.SelectedValue;
                    Role = ddlRoleAdmin.SelectedValue;
                    DateB = txtDateBAdmin.SelectedDate.Value.ToShortDateString();
                    DateE = txtDateEAdmin.SelectedDate.Value.ToShortDateString();
                    State = ddlStateAdmin.SelectedValue;
                    FormsCode = ddlFormAdmin.SelectedValue;
                    Dept = ddlDeptAdmin.SelectedValue;
                }
                else if (_User.Role != null && _User.Role.Contains("Coordinator"))
                {
                    ProcessID = txtProcessIdCoordinator.Text;
                    EmpID = txtNameCoordinator.SelectedValue;
                    Role = ddlRoleCoordinator.SelectedValue;
                    DateB = txtDateBCoordinator.SelectedDate.Value.ToShortDateString();
                    DateE = txtDateECoordinator.SelectedDate.Value.ToShortDateString();
                    State = ddlStateCoordinator.SelectedValue;
                    FormsCode = ddlFormCoordinator.SelectedValue;
                    Dept = ddlDeptCoordinator.SelectedValue;

                }
                else
                {
                    ProcessID = txtProcessIdEmp.Text;
                    Role = ddlRoleEmp.SelectedValue;
                    DateB = txtDateBEmp.SelectedDate.Value.ToShortDateString();
                    DateE = txtDateEEmp.SelectedDate.Value.ToShortDateString();
                    FormsCode = ddlFormEmp.SelectedValue;
                }

                UnobtrusiveSession.Session["ProcessID"] = ProcessID;
                UnobtrusiveSession.Session["EmpID"] = EmpID;
                UnobtrusiveSession.Session["Role"] = Role;
                UnobtrusiveSession.Session["DateB"] = DateB;
                UnobtrusiveSession.Session["DateE"] = DateE;
                UnobtrusiveSession.Session["State"] = State;
                UnobtrusiveSession.Session["FormsCode"] = FormsCode;
                UnobtrusiveSession.Session["Dept"] = Dept;

                Response.Redirect(ViewUrl);
            }

        }

        protected void ddlRoleEmp_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (e.Value == "1")
                ckbNoShowMyProcessEmp.Visible = true;
            else
                ckbNoShowMyProcessEmp.Visible = false;
        }

        protected void ddlRoleAdmin_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ddlStateAdmin.Enabled = true;
            if (e.Value == "3")
            {
                ddlStateAdmin.Items.FindItemByValue("1").Selected = true;
                ddlStateAdmin.Enabled = false;
            }
        }

        protected void ddlRoleCoordinator_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            ddlStateCoordinator.Enabled = true;
            if (e.Value == "3")
            {
                ddlStateCoordinator.Items.FindItemByValue("1").Selected = true;
                ddlStateCoordinator.Enabled = false;
            }
        }
    }
}