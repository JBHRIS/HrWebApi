using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Bll.CardView.Vdb;
using Dal.Dao.CardView;
using System.Text;
using Bll;
using Bll.Employee.Vdb;
using Dal.Dao.Employee;
using Dal.Dao.Salary;
using Bll.Salary.Vdb;
using Dal;
using Dal.Dao.Attendance;
using Bll.Attendance.Vdb;
using Dal.Dao.Token;
using Bll.Token.Vdb;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json;

namespace Portal
{
    public partial class FormEmployStd : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();

        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private DateTime InDate;
        private DateTime ApDate;
        private string _FormCode = "Employ";
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
                LoadData(_User.UserCode);
                _DataBind();
                ddlEmp_DataBind();
                SetDefault();
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
        public void LoadData(string Key = "")
        {

        }
        public void _DataBind()
        {

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
        }
        public void ddlEmp_DataBind()
        {
            var oPeopleApDate = new PeopleApDateDao();
            var PeopleApDateCond = new PeopleApDateConditions();
            PeopleApDateCond.AccessToken = _User.AccessToken;
            PeopleApDateCond.RefreshToken = _User.RefreshToken;
            PeopleApDateCond.CompanySetting = CompanySetting;
            PeopleApDateCond.BeginDate = DateTime.Now.AddMonths(-3).Date;
            PeopleApDateCond.EndDate = new DateTime(9999, 12, 31).Date;

            var rs = oPeopleApDate.GetData(PeopleApDateCond);

            if (rs != null && rs.Data != null)
            {
                var rsPeopleApDate = rs.Data as List<PeopleApDateRow>;
                var ListEmpId = rsPeopleApDate.Select(p => p.EmpId).ToList();
                var oEmployeeView = new EmployeeViewDao();
                var EmployeeViewCond = new EmployeeViewConditions();
                EmployeeViewCond.AccessToken = _User.AccessToken;
                EmployeeViewCond.RefreshToken = _User.RefreshToken;
                EmployeeViewCond.CompanySetting = CompanySetting;
                EmployeeViewCond.ListEmpId = ListEmpId;
                var Result = oEmployeeView.GetData(EmployeeViewCond);
                if (Result.Status && Result.Data != null)
                {
                    var rsEmployeeView = Result.Data as List<EmployeeViewRow>;
                    foreach (var r in rsEmployeeView)
                    {
                        r.EmpName += "," + r.EmpId;
                        foreach (var rPeopleApDate in rsPeopleApDate)
                        {
                            if (r.EmpId == rPeopleApDate.EmpId)
                            {
                                rPeopleApDate.EmpName = r.EmpName;
                                rPeopleApDate.EmpId += ";" + rPeopleApDate.IndtDate.ToString("yyyy/MM/dd") + ";" + rPeopleApDate.ApDate.ToString("yyyy/MM/dd");
                            }
                        }
                    }
                    ddlEmp.DataSource = rsPeopleApDate;
                    ddlEmp.DataTextField = "EmpName";
                    ddlEmp.DataValueField = "EmpId";
                    ddlEmp.DataBind();
                }
            }

            //ddlEmp.Value = new List<string>() { _User.EmpId };
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["FormCode"] = _FormCode;
            Session["sProcessID"] = lblProcessID.Text;
            Session["FlowTreeID"] = lblFlowTreeID.Text;
            lblExperienced.Text = "";
            var rs = new List<EmployeeInfoViewRow>();
            #region 人事基本資料
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
                lblAge.Text = (DateTime.Now.Year - Res.EmpBirthday.Year).ToString();
                lblName.Text = Res.EmpName + "," + Res.EmpId;
                lblSex.Text = Res.EmpSex;
                lblBirth.Text = Res.EmpBirthday.ToString("yyyy/MM/dd");
                lblEducation.Text = Res.EducationList.Where(p => p.IsEducationLevelTop).Select(p => p.SchoolName + p.Education).FirstOrDefault();
                lblTrialDept.Text = Res.DeptName;
                lblDeptCodeAppM.Text = Res.DeptCode;
                lblTrialDeptm.Text = Res.DeptaName;
                lblDeptaCodeAppM.Text = Res.DeptaCode;
                lblTrialJob.Text = Res.JobName;
                lblJobCodeAppM.Text = Res.JobCode;
                lblTrialJobl.Text = Res.JoblName;
                lblJoblCodeAppM.Text = Res.JoblCode;
                lblTrialDateB.Text = InDate.ToString("yyyy/MM/dd");
                lblTrialDateE.Text = ApDate.ToString("yyyy/MM/dd");
                foreach (var r in Res.WorksInfoList)
                {
                    lblExperienced.Text += r.Company + r.Title;
                    lblExperienced.Text += "\r\n";
                }
            }

            #endregion
            lvSalary.Rebind();
            #region 假別資料
            var oAttendDetail = new AttendDetailDao();
            var AttendDetailCond = new AttendDetailConditions();
            AttendDetailCond.AccessToken = _User.AccessToken;
            AttendDetailCond.RefreshToken = _User.RefreshToken;
            AttendDetailCond.CompanySetting = CompanySetting;
            AttendDetailCond.employeeList = ListEmpid;
            AttendDetailCond.attendTypeList = new List<string>();
            AttendDetailCond.dateBegin = Convert.ToDateTime(lblTrialDateB.Text);
            AttendDetailCond.dateEnd = Convert.ToDateTime(lblTrialDateE.Text);

            var AttendResult = oAttendDetail.GetData(AttendDetailCond);
            if (AttendResult.Status && AttendResult.Data != null)
            {
                var AttRes = AttendResult.Data as List<AttendDetailRow>;
                if (AttRes != null)
                {
                    double PersonalAbsHour = 0;
                    double SickAbsHour = 0;
                    double AbsenteeismHour = 0;
                    double LateTimes = 0;
                    double EarlyOutTimes = 0;
                    foreach (var rAttRes in AttRes)
                    {
                        if (rAttRes.EarlyMins != 0)
                            EarlyOutTimes++;
                        if (rAttRes.LateMins != 0)
                            LateTimes++;
                        foreach (var rAttAbs in rAttRes.ListAbs)
                        {
                            if (rAttAbs.HcodeName == "事假")
                                PersonalAbsHour += Convert.ToDouble(rAttAbs.Use);
                            if (rAttAbs.HcodeName == "病假")
                                SickAbsHour += Convert.ToDouble(rAttAbs.Use);
                            if (rAttAbs.HcodeName == "曠職")
                                AbsenteeismHour += Convert.ToDouble(rAttAbs.Use);
                        }
                    }
                    var LsAbsData = new List<TextValueRow>();
                    var AbsData = new TextValueRow();
                    AbsData.Text = "事假";
                    AbsData.Value = PersonalAbsHour.ToString();
                    LsAbsData.Add(AbsData);

                    AbsData = new TextValueRow();
                    AbsData.Text = "病假";
                    AbsData.Value = SickAbsHour.ToString();
                    LsAbsData.Add(AbsData);

                    AbsData = new TextValueRow();
                    AbsData.Text = "曠職";
                    AbsData.Value = AbsenteeismHour.ToString();
                    LsAbsData.Add(AbsData);

                    AbsData = new TextValueRow();
                    AbsData.Text = "遲到";
                    AbsData.Value = LateTimes.ToString();
                    LsAbsData.Add(AbsData);

                    AbsData = new TextValueRow();
                    AbsData.Text = "早退";
                    AbsData.Value = EarlyOutTimes.ToString();
                    LsAbsData.Add(AbsData);

                    UnobtrusiveSession.Session["EmployAbsData"] = JsonConvert.SerializeObject(LsAbsData);

                    lblPersonalLeave.Text = PersonalAbsHour.ToString();
                    lblSickLeave.Text = SickAbsHour.ToString();
                    lblAbsenteeism.Text = AbsenteeismHour.ToString();
                    //lblOt.Text = OtHour.ToString();
                    lblLate.Text = LateTimes.ToString();
                    lblEarlyOut.Text = EarlyOutTimes.ToString();
                }
            }
            #endregion
        }

        protected void lvSalary_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            #region 薪資異動資料
            if (Page.IsPostBack)
            {
                var oSalaryChange = new SalaryChangeDao();
                var SalaryChangeCond = new SalaryChangeConditions();
                SalaryChangeCond.AccessToken = _User.AccessToken;
                SalaryChangeCond.RefreshToken = _User.RefreshToken;
                SalaryChangeCond.CompanySetting = CompanySetting;
                SalaryChangeCond.nobr = lblNobrAppM.Text;
                SalaryChangeCond.CheckDate = DateTime.Now;
                var SalrayData = oSalaryChange.GetData(SalaryChangeCond);
                List<TextValueRow> resSalary = new List<TextValueRow>();
                if (SalrayData.Status && SalrayData.Data != null)
                {
                    var res = SalrayData.Data as List<SalaryChangeRow>;
                    if (res != null)
                    {
                        lvSalary.DataSource = res;
                        foreach (var r in res)
                        {
                            r.DESData = AccessData.DESEncrypt(r.Amount.ToString(), "JBSalary", lblProcessID.Text.Substring(0,8));
                            var rTextValue = new TextValueRow();
                            rTextValue.Text = r.SalName;
                            rTextValue.Value = r.DESData;
                            rTextValue.Column1 = r.SalCode;
                            resSalary.Add(rTextValue);
                        }
                        UnobtrusiveSession.Session["SalaryData"] = JsonConvert.SerializeObject(resSalary);
                    }
                }
            }
            #endregion

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {

            //if (txtPerformance1.Text == "" || txtPerformance2.Text == "" || txtPerformance3.Text == "")
            //{
            //    lblError.Text = "請填寫主管評核";
            //    return;
            //}
            //if (ddlResult.SelectedItem.Text == "")
            //{
            //    lblError.Text = "請選擇結果";
            //    return;
            //}
            //if (!txtEmployDate.SelectedDate.HasValue || txtDept.Text == "")
            //{
            //    lblError.Text = "請確認資料是否輸入正確";
            //    return;
            //}
            //foreach (var r in lvSalary.Items)
            //{
            //    var Salary = r.FindControl("Salary") as RadTextBox;
            //    if (Salary.Text == "")
            //    {
            //        lblError.Text = "請確認金額是否輸入正確";
            //        return;
            //    }
            //}
            var oFormEmploy = (from c in dcFlow.FormsAppEmploy
                               where c.ProcessId == lblProcessID.Text
                               select c).FirstOrDefault();
            if (oFormEmploy == null)
            {
                var oEmploy = new FormsAppEmploy();
                oEmploy.Code = lblProcessID.Text;
                oEmploy.ProcessId = lblProcessID.Text;
                oEmploy.idProcess = 0;
                oEmploy.EmpName = lblNameAppM.Text;
                oEmploy.EmpId = lblNobrAppM.Text;
                oEmploy.DeptCode = lblDeptCodeAppM.Text;
                oEmploy.DeptName = lblTrialDept.Text;
                oEmploy.DeptmCode = lblDeptaCodeAppM.Text;
                oEmploy.DeptmName = lblTrialDeptm.Text;
                oEmploy.JobCode = lblJobCodeAppM.Text;
                oEmploy.JobName = lblTrialJob.Text;
                oEmploy.JoblCode = lblJoblCodeAppM.Text;
                oEmploy.JoblName = lblTrialJobl.Text;
                oEmploy.Birthday = Convert.ToDateTime(lblBirth.Text);
                oEmploy.Sex = lblSex.Text;
                oEmploy.DateIn = Convert.ToDateTime(lblTrialDateB.Text);
                oEmploy.DateA = Convert.ToDateTime(lblTrialDateB.Text);
                oEmploy.DateD = Convert.ToDateTime(lblTrialDateE.Text);
                oEmploy.WorkExperience = lblExperienced.Text;
                oEmploy.RoleId = lblRoleAppM.Text;
                oEmploy.SchoolCode = lblEducation.Text;
                oEmploy.SchoolName = lblEducation.Text;
                oEmploy.AttendContent = UnobtrusiveSession.Session["EmployAbsData"].ToString();
                oEmploy.DeptCodeChange = "";
                oEmploy.DeptNameChange = "";
                oEmploy.DeptmCodeChange = "";
                oEmploy.DeptmNameChange = "";
                oEmploy.JobCodeChange = "";
                oEmploy.JobNameChange = "";
                oEmploy.JoblCodeChange = "";
                oEmploy.JoblNameChange = "";
                oEmploy.ResultAreaCode = "";
                oEmploy.ResultAreaName = "";
                oEmploy.ExtendMonth = 0;
                oEmploy.DateAppoint = DateTime.Now.Date;
                oEmploy.AllowSalary = false;
                oEmploy.AllowSign = false;
                oEmploy.Note = "";
                oEmploy.Sign = true;
                oEmploy.SignState = "0";
                oEmploy.Status = "1";
                oEmploy.InsertDate = DateTime.Now;
                oEmploy.InsertMan = _User.EmpId;
                oEmploy.UpdateDate = DateTime.Now;
                oEmploy.UpdateMan = _User.EmpId;
                dcFlow.FormsAppEmploy.InsertOnSubmit(oEmploy);
                var rsFormsAppInfo = new FormsAppInfo()
                {
                    Code = lblProcessID.Text,
                    EmpId = lblNobrAppM.Text,
                    EmpName = lblNameAppM.Text,
                    idProcess = 0,
                    ProcessId = lblProcessID.Text,
                    KeyDate = DateTime.Now,
                    SignState = "1",
                    InfoSign = oEmploy.EmpName + "," + oEmploy.DateA.ToShortDateString() + "~" + oEmploy.DateD.ToShortDateString() + ",之試用期已到",
                    InfoMail = MessageSendMail.EmployBody(oEmploy.EmpId, oEmploy.EmpName, oEmploy.DeptName, oEmploy.DateA, oEmploy.DateD, oEmploy.Note)
                };
                dcFlow.FormsAppInfo.InsertOnSubmit(rsFormsAppInfo);
            }
            else
            {
                oFormEmploy.EmpName = lblNameAppM.Text;
                oFormEmploy.EmpId = lblNobrAppM.Text;
                oFormEmploy.DeptCode = lblDeptCodeAppM.Text;
                oFormEmploy.DeptName = lblTrialDept.Text;
                oFormEmploy.DeptmCode = lblDeptaCodeAppM.Text;
                oFormEmploy.DeptmName = lblTrialDeptm.Text;
                oFormEmploy.JobCode = lblJobCodeAppM.Text;
                oFormEmploy.JobName = lblTrialJob.Text;
                oFormEmploy.JoblCode = lblJoblCodeAppM.Text;
                oFormEmploy.JoblName = lblTrialJobl.Text;
                oFormEmploy.Birthday = Convert.ToDateTime(lblBirth.Text);
                oFormEmploy.Sex = lblSex.Text;
                oFormEmploy.DateIn = Convert.ToDateTime(lblTrialDateB.Text);
                oFormEmploy.DateA = Convert.ToDateTime(lblTrialDateB.Text);
                oFormEmploy.DateD = Convert.ToDateTime(lblTrialDateE.Text);
                oFormEmploy.WorkExperience = lblExperienced.Text;
                oFormEmploy.RoleId = lblRoleAppM.Text;
                oFormEmploy.SchoolCode = lblEducation.Text;
                oFormEmploy.SchoolName = lblEducation.Text;
                oFormEmploy.AttendContent = UnobtrusiveSession.Session["EmployAbsData"].ToString();
            }
            
            //foreach (var r in lvSalary.Items)
            //{
            //    var Salary = r.FindControl("Salary") as RadTextBox;
            //    var SalaryName = r.FindControl("SalaryName") as RadLabel;
            //    var Amount = r.FindControl("Amount") as RadLabel;

            //    var oEmploySalary = new FormsAppEmploySalary();
            //    oEmploySalary.EmployCode = Code;
            //    oEmploySalary.SalaryCode = SalaryName.Text;
            //    oEmploySalary.SalaryName = Amount.Text;
            //    oEmploySalary.MoneyValue = Convert.ToDecimal(Salary.Text);
            //    oEmploySalary.EncodeMoneyValue = 0;
            //    oEmploySalary.Note = "";
            //    oEmploySalary.Status = "1";
            //    oEmploySalary.InsertDate = DateTime.Now;
            //    oEmploySalary.InsertMan = _User.EmpId;
            //    oEmploySalary.UpdateDate = DateTime.Now;
            //    oEmploySalary.UpdateMan = _User.EmpId;
            //    dcFlow.FormsAppEmploySalary.InsertOnSubmit(oEmploySalary);
            //}

            //var oEmployLog = new FormsAppEmployChangeLog();
            //oEmployLog.EmployCode = Code;
            //oEmployLog.DeptCodeChange = lblDeptCodeAppM.Text;
            //oEmployLog.DeptNameChange = lblDeptNameAppM.Text;
            //oEmployLog.DeptmCodeChange = lblDeptm.Text;
            //oEmployLog.DeptmNameChange = lblDeptm.Text;
            //oEmployLog.JobCodeChange = lblJob.Text;
            //oEmployLog.JobNameChange = lblJob.Text;
            //oEmployLog.JoblCodeChange = lblJobName.Text;
            //oEmployLog.JoblNameChange = lblJobName.Text;
            ////oEmployLog.ResultAreaCode = ddlResult.SelectedValue;
            ////oEmployLog.ResultAreaName = ddlResult.SelectedItem.Text;
            //oEmployLog.ResultAreaCode = "";
            //oEmployLog.ResultAreaName = "";
            //oEmployLog.ExtendMonth = txtExtend.Text == "" ? 0 : Convert.ToInt32(txtExtend.Text);
            //oEmployLog.DateAppoint = txtEmployDate.SelectedDate.GetValueOrDefault();
            //oEmployLog.Performance01 = txtPerformance1.Text;
            //oEmployLog.Performance02 = txtPerformance2.Text;
            //oEmployLog.Performance03 = txtPerformance3.Text;
            //oEmployLog.Performance04 = "";
            //oEmployLog.Performance05 = "";
            //oEmployLog.SalaryContent = "";//////////////////////////////////////////未實作
            //oEmployLog.Note = "";
            //oEmployLog.Status = "1";
            //oEmployLog.InsertDate = DateTime.Now;
            //oEmployLog.InsertMan = _User.EmpId;
            //oEmployLog.UpdateDate = DateTime.Now;
            //oEmployLog.UpdateMan = _User.EmpId;
            //dcFlow.FormsAppEmployChangeLog.InsertOnSubmit(oEmployLog);

            dcFlow.SubmitChanges();
            lblCheckMsg.Text = "確認完成";
            lblCheckMsg.CssClass = "badge badge-primary animated shake";
        }

        protected void ddlEmp_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var Value = ddlEmp.SelectedValue;
            var Data = Value.Split(';');
            lblNobrAppM.Text = Data[0];
            InDate = Convert.ToDateTime(Data[1]);
            ApDate = Convert.ToDateTime(Data[2]);
            SetInfoAppM();
        }
    }
}