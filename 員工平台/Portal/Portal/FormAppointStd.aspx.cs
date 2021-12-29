using Bll.Employee.Vdb;
using Dal;
using Dal.Dao.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class FormAppointStd : WebPageBase
    {

        private dcHrDataContext dcHR = new dcHrDataContext();

        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private string _FormCode = "Appoint";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcHR.Connection.ConnectionString = CompanySetting.ConnHr;
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (!this.IsPostBack)
            {
                lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
                lblNobrAppM.Text = _User.EmpId;
                //ddlEmp_DataBind();
                txtName_DataBind();
                ddlChangeItem_DataBind();
                _DataBind();
                SetDefault();
                Performance_DataBind();
                SetInfoAppM();
            }
        }
        private void SetDefault()
        {

            var rForm = (from c in dcFlow.Forms
                         where c.Code == _FormCode
                         select c).FirstOrDefault();

            if (rForm != null)
            {
                lblFlowTreeID.Text = rForm.FlowTreeId;
                //lblNote.Text = rForm.sStdNote;
                Title = rForm.Name;
            }
        }
        private void txtName_DataBind()
        {

            var rsPeople = AccessData.GetPeopleList(_User, CompanySetting);

            txtNameAppS.DataSource = rsPeople;
            txtNameAppS.DataTextField = "Text";
            txtNameAppS.DataValueField = "Value";
            txtNameAppS.DataBind();
        }
        private void ddlChangeItem_DataBind()
        {
            RadComboBoxItem it = new RadComboBoxItem();

            it.Text = "晉升";
            it.Value = "01";

            ddlChangeItem.Items.Add(it);

            it = new RadComboBoxItem();

            it.Text = "調職";
            it.Value = "02";

            ddlChangeItem.Items.Add(it);

            it = new RadComboBoxItem();

            it.Text = "調薪";
            it.Value = "03";

            ddlChangeItem.Items.Add(it);


        }
        private void _DataBind()
        {
            var oDept = new DeptDao();
            var DeptCond = new DeptConditions();
            DeptCond.AccessToken = _User.AccessToken;
            DeptCond.RefreshToken = _User.RefreshToken;
            DeptCond.CompanySetting = CompanySetting;
            var DeptResult = oDept.GetData(DeptCond);
            if (DeptResult.Status && DeptResult.Data != null)
            {
                var rsDept = DeptResult.Data as List<DeptRow>;
                if (rsDept != null)
                {
                    ddlDept.DataSource = rsDept;
                    ddlDept.DataTextField = "DeptName";
                    ddlDept.DataValueField = "DeptCode";
                    ddlDept.DataBind();
                }
            }
            var oDepta = new DeptaDao();
            var DeptaCond = new DeptaConditions();
            DeptaCond.AccessToken = _User.AccessToken;
            DeptaCond.RefreshToken = _User.RefreshToken;
            DeptaCond.CompanySetting = CompanySetting;
            var DeptaResult = oDepta.GetData(DeptaCond);
            if (DeptaResult.Status && DeptaResult.Data != null)
            {
                var rsDepta = DeptaResult.Data as List<DeptaRow>;
                if (rsDepta != null)
                {
                    ddlDepta.DataSource = rsDepta;
                    ddlDepta.DataTextField = "DeptaName";
                    ddlDepta.DataValueField = "DeptaCode";
                    ddlDepta.DataBind();
                }
            }
            var oJob = new JobDao();
            var JobCond = new JobConditions();
            JobCond.AccessToken = _User.AccessToken;
            JobCond.RefreshToken = _User.RefreshToken;
            JobCond.CompanySetting = CompanySetting;
            var JobResult = oJob.GetData(JobCond);
            if (JobResult.Status && JobResult.Data != null)
            {
                var rsJob = JobResult.Data as List<JobRow>;
                if (rsJob != null)
                {
                    ddlJob.DataSource = rsJob;
                    ddlJob.DataTextField = "JobName";
                    ddlJob.DataValueField = "JobCode";
                    ddlJob.DataBind();
                }
            }
            var oJobl = new JoblDao();
            var JoblCond = new JoblConditions();
            JoblCond.AccessToken = _User.AccessToken;
            JoblCond.RefreshToken = _User.RefreshToken;
            JoblCond.CompanySetting = CompanySetting;
            var JoblResult = oJobl.GetData(JoblCond);
            if (JoblResult.Status && JoblResult.Data != null)
            {
                var rsJobl = JoblResult.Data as List<JoblRow>;
                if (rsJobl != null)
                {
                    ddlJobl.DataSource = rsJobl;
                    ddlJobl.DataTextField = "JoblName";
                    ddlJobl.DataValueField = "JoblCode";
                    ddlJobl.DataBind();
                }
            }

        }
        private void SetInfoAppM()
        {
            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrAppM.Text
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
                lblRoleAppM.Text = rEmpM.RoleId;
                lblNobrAppM.Text = rEmpM.EmpNobr;
                lblNameAppM.Text = rEmpM.EmpName;
            }
            //if (rEmpM == null)
            //{
            //    RadWindowManager1.RadAlert("人事資料有誤，請通知人事", 300, 100, "警告訊息", "", "");
            //    return;
            //}
            //Dal.Dao.Bas.BasDao oBasDao = new Dal.Dao.Bas.BasDao(dcHR.Connection);
            //var rsPortalRole = oBasDao.GetPortalRoleByNobr(lblNobrAppM.Text);
            //var PortalRole = rsPortalRole.Where(p => p.RoleCode == "Coordinator").FirstOrDefault();
            //if (PortalRole != null)
            //{
            //    txtChiNameAppS.Enabled = true;
            //    txtChiNameAppS.Visible = true;
            //    lblChiName.Visible = true;
            //    lblChiNamePS.Visible = true;
            //}
            #region 人事基本資料
            var rs = new List<EmployeeInfoViewRow>();
            var ListEmpid = new List<string>();
            ListEmpid.Add(lblNobrAppM.Text);
            var oEmployeeInfoView = new EmployeeInfoViewDao();
            var EmployeeInfoViewCond = new EmployeeInfoViewConditions();
            EmployeeInfoViewCond.AccessToken = _User.AccessToken;
            EmployeeInfoViewCond.RefreshToken = _User.RefreshToken;
            EmployeeInfoViewCond.CompanySetting = CompanySetting;
            EmployeeInfoViewCond.ListEmpId = ListEmpid;
            var Result = oEmployeeInfoView.GetData(EmployeeInfoViewCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<EmployeeInfoViewRow>;
                }
            }
            if (rs != null && rs.Count > 0)
            {
                var Res = rs[0];
                lblName.Text = Res.EmpName + "," + Res.EmpId;
                lblBirthday.Text = Res.EmpBirthday.ToString("yyyy/MM/dd");
                lblEducation.Text = Res.EducationList.Where(p => p.IsEducationLevelTop).Select(p => p.SchoolName + p.Education).FirstOrDefault();
                lblDept.Text = Res.DeptName;
                lblDeptCodeAppM.Text = Res.DeptCode;
                lblDepta.Text = Res.DeptaName;
                lblDeptaCodeAppM.Text = Res.DeptaCode;
                lblJob.Text = Res.JobName;
                lblJobCodeAppM.Text = Res.JobCode;
                lblJobl.Text = Res.JoblName;
                lblJoblCodeAppM.Text = Res.JoblCode;
                lblDateA.Text = Convert.ToDateTime(Res.WorkStateList.Last().ADate).ToString("yyyy/MM/dd");
                if (ddlDept.FindItemByValue(Res.DeptCode) != null)
                    ddlDept.FindItemByValue(Res.DeptCode).Selected = true;
                if (ddlDepta.FindItemByValue(Res.DeptaCode) != null)
                    ddlDepta.FindItemByValue(Res.DeptaCode).Selected = true;
                if (ddlJob.FindItemByValue(Res.JobCode) != null)
                    ddlJob.FindItemByValue(Res.JobCode).Selected = true;
                if (ddlJobl.FindItemByValue(Res.JoblCode) != null)
                    ddlJobl.FindItemByValue(Res.JoblCode).Selected = true;
            }
            //取得到職日

            var oEmployeeStartWorkDay = new EmployeeStartWorkDateDao();
            var EmployeeStartWorkDayCond = new EmployeeStartWorkDateConditions();
            EmployeeStartWorkDayCond.AccessToken = _User.AccessToken;
            EmployeeStartWorkDayCond.RefreshToken = _User.RefreshToken;
            EmployeeStartWorkDayCond.CompanySetting = CompanySetting;
            EmployeeStartWorkDayCond.EmployeeID = lblNobrAppM.Text;
            var rsEmpWorkStartDay = oEmployeeStartWorkDay.GetData(EmployeeStartWorkDayCond);

            if (rsEmpWorkStartDay.Status && rsEmpWorkStartDay.Data != null)
            {
                var EmpWorkStartDay = rsEmpWorkStartDay.Data as EmployeeStartWorkDateRow;
                if (EmpWorkStartDay != null)
                {
                    lblDateIn.Text = EmpWorkStartDay.WorkDate.ToString("yyyy/MM/dd");
                }
            }

            #endregion

        }
        private void Performance_DataBind()
        {
            lblyear3.Text = DateTime.Now.AddYears(-2).Year.ToString();
            lblyear2.Text = DateTime.Now.AddYears(-1).Year.ToString();
            lblyear1.Text = DateTime.Now.Year.ToString();
            var oEffEmployView = new EffEmployeeViewDao();
            var EffEmployViewCond = new EffEmployeeViewConditions();
            EffEmployViewCond.AccessToken = _User.AccessToken;
            EffEmployViewCond.RefreshToken = _User.RefreshToken;
            EffEmployViewCond.CompanySetting = CompanySetting;
            EffEmployViewCond.empID = lblNobrAppM.Text;
            EffEmployViewCond.yymm = new List<string>();
            EffEmployViewCond.yymm.Add(DateTime.Now.AddYears(-2).ToString("yyyy"));
            EffEmployViewCond.yymm.Add(DateTime.Now.AddYears(-1).ToString("yyyy"));
            EffEmployViewCond.yymm.Add(DateTime.Now.ToString("yyyy"));
            var rsEffEmployView = oEffEmployView.GetData(EffEmployViewCond);
            if (rsEffEmployView != null && rsEffEmployView.Data != null)
            {
                var rs = rsEffEmployView.Data as List<EffEmployeeViewRow>;
                if (rs != null)
                {
                    if (rs.Count > 0)
                        lblPerformance3.Text = rs[0].EffName.ToString();
                    else
                        lblPerformance3.Text = "無資料";
                    if (rs.Count > 1)
                        lblPerformance2.Text = rs[1].EffName.ToString();
                    else
                        lblPerformance2.Text = "無資料";
                    if (rs.Count > 2)
                        lblPerformance1.Text = rs[2].EffName.ToString();
                    else
                        lblPerformance1.Text = "無資料";

                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ddlDept.Text == "" || ddlDepta.Text == "" || ddlJob.Text == "" || ddlJobl.Text == "" || !txtDateAppoint.SelectedDate.HasValue || txtReasonChange.Text == ""
                || (ddlChangeItem.SelectedValue == "01" && (txtPerformance1.Text == "" || txtPerformance2.Text == "")))
            {
                lblCheckMsg.Text = "請確認資料是否輸入正確";
                lblCheckMsg.CssClass = "badge badge-danger animated shake";
                return;
            }
            var oFormAppoint = (from c in dcFlow.FormsAppAppoint
                                where c.ProcessId == lblProcessID.Text
                                select c).FirstOrDefault();
            if (oFormAppoint == null)
            {
                var oAppoint = new FormsAppAppoint();
                oAppoint.Code = lblProcessID.Text;
                oAppoint.ProcessId = lblProcessID.Text;
                oAppoint.idProcess = 0;
                oAppoint.EmpName = lblNameAppM.Text;
                oAppoint.EmpId = lblNobrAppM.Text;
                oAppoint.DeptCode = lblDeptCodeAppM.Text;
                oAppoint.DeptName = lblDept.Text;
                oAppoint.DeptmCode = lblDeptaCodeAppM.Text;
                oAppoint.DeptmName = lblDepta.Text;
                oAppoint.JobCode = lblJobCodeAppM.Text;
                oAppoint.JobName = lblJob.Text;
                oAppoint.JoblCode = lblJoblCodeAppM.Text;
                oAppoint.JoblName = lblJobl.Text;
                oAppoint.DateIn = Convert.ToDateTime(lblDateIn.Text);
                oAppoint.DateA = Convert.ToDateTime(lblDateA.Text);
                oAppoint.Birthday = Convert.ToDateTime(lblBirthday.Text);
                oAppoint.RoleId = lblRoleAppM.Text;
                oAppoint.SchoolCode = lblEducation.Text;
                oAppoint.SchoolName = lblEducation.Text;
                oAppoint.DeptCodeChange = ddlDept.SelectedValue;
                oAppoint.DeptNameChange = ddlDept.Text;
                oAppoint.DeptmCodeChange = ddlDepta.SelectedValue;
                oAppoint.DeptmNameChange = ddlDepta.Text;
                oAppoint.JobCodeChange = ddlJob.SelectedValue;
                oAppoint.JobNameChange = ddlJob.Text;
                oAppoint.JoblCodeChange = ddlJobl.SelectedValue;
                oAppoint.JoblNameChange = ddlJobl.Text;
                oAppoint.ChangeItemCode = ddlChangeItem.SelectedValue;
                oAppoint.ChangeItemName = ddlChangeItem.Text;
                oAppoint.DateAppoint = DateTime.Now.Date;
                oAppoint.Performance1 = lblPerformance1.Text;
                oAppoint.Performance2 = lblPerformance2.Text;
                oAppoint.Performance3 = lblPerformance3.Text;
                oAppoint.ReasonChange = txtReasonChange.Text;
                oAppoint.Qualified = "";
                oAppoint.Evaluation = "";
                oAppoint.AllowSalary = false;
                oAppoint.AllowSign = false;
                oAppoint.Note = "";
                oAppoint.Sign = true;
                oAppoint.SignState = "0";
                oAppoint.Status = "1";
                oAppoint.InsertDate = DateTime.Now;
                oAppoint.InsertMan = _User.EmpId;
                oAppoint.UpdateDate = DateTime.Now;
                oAppoint.UpdateMan = _User.EmpId;
                dcFlow.FormsAppAppoint.InsertOnSubmit(oAppoint);
                var rsFormsAppInfo = new FormsAppInfo()
                {
                    Code = lblProcessID.Text,
                    EmpId = lblNobrAppM.Text,
                    EmpName = lblNameAppM.Text,
                    idProcess = 0,
                    ProcessId = lblProcessID.Text,
                    KeyDate = DateTime.Now,
                    SignState = "1",
                    InfoSign = oAppoint.EmpName + "," + oAppoint.EmpId + ",之晉升單",
                    InfoMail = MessageSendMail.AppointBody(oAppoint.EmpId, oAppoint.EmpName, oAppoint.DeptName, oAppoint.DateAppoint, oAppoint.Note)
                };
                dcFlow.FormsAppInfo.InsertOnSubmit(rsFormsAppInfo);
            }
            else
            {
                oFormAppoint.EmpName = lblNameAppM.Text;
                oFormAppoint.EmpId = lblNobrAppM.Text;
                oFormAppoint.DeptCode = lblDeptCodeAppM.Text;
                oFormAppoint.DeptName = lblDept.Text;
                oFormAppoint.DeptmCode = lblDeptaCodeAppM.Text;
                oFormAppoint.DeptmName = lblDepta.Text;
                oFormAppoint.JobCode = lblJobCodeAppM.Text;
                oFormAppoint.JobName = lblJob.Text;
                oFormAppoint.JoblCode = lblJoblCodeAppM.Text;
                oFormAppoint.JoblName = lblJobl.Text;
                oFormAppoint.DateIn = Convert.ToDateTime(lblDateIn.Text);
                oFormAppoint.DateA = Convert.ToDateTime(lblDateA.Text);
                oFormAppoint.RoleId = lblRoleAppM.Text;
                oFormAppoint.SchoolCode = lblEducation.Text;
                oFormAppoint.SchoolName = lblEducation.Text;
                oFormAppoint.DeptCodeChange = ddlDept.SelectedValue;
                oFormAppoint.DeptNameChange = ddlDept.Text;
                oFormAppoint.DeptmCodeChange = ddlDepta.SelectedValue;
                oFormAppoint.DeptmNameChange = ddlDepta.Text;
                oFormAppoint.JobCodeChange = ddlJob.SelectedValue;
                oFormAppoint.JobNameChange = ddlJob.Text;
                oFormAppoint.JoblCodeChange = ddlJobl.SelectedValue;
                oFormAppoint.JoblNameChange = ddlJobl.Text;
                oFormAppoint.ChangeItemCode = ddlChangeItem.SelectedValue;
                oFormAppoint.ChangeItemName = ddlChangeItem.Text;
                oFormAppoint.DateAppoint = txtDateAppoint.SelectedDate.GetValueOrDefault();
                oFormAppoint.Performance1 = lblPerformance1.Text;
                oFormAppoint.Performance2 = lblPerformance2.Text;
                oFormAppoint.Performance3 = lblPerformance3.Text;
                oFormAppoint.ReasonChange = txtReasonChange.Text;
            }
            Session["FormCode"] = _FormCode;
            Session["sProcessID"] = lblProcessID.Text;
            Session["FlowTreeID"] = lblFlowTreeID.Text;
            UnobtrusiveSession.Session["Performance1"] = txtPerformance1.Text;
            UnobtrusiveSession.Session["Performance2"] = txtPerformance2.Text;
            dcFlow.SubmitChanges();
            lblCheckMsg.Text = "確認完成";
            lblCheckMsg.CssClass = "badge badge-primary animated shake";
        }


        protected void txtNameAppS_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            lblNobrAppM.Text = txtNameAppS.SelectedValue;
            SetInfoAppM();
            Performance_DataBind();
        }

        protected void txtNameAppS_DataBound(object sender, EventArgs e)
        {

        }

        protected void ddlChangeItem_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (ddlChangeItem.SelectedValue == "01")
                plPromotion.Visible = true;
            else
                plPromotion.Visible = false;
        }
    }
}