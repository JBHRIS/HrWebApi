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
using Dal.Dao.Flow;
using Bll.Flow.Vdb;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json;

namespace Portal
{
    public partial class FormEmployChk : WebPageBase
    {

        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private bool isView = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (UnobtrusiveSession.Session["RequestName"].ToString() == "View")
                isView = true;
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["LsSalaryData"] = null;
                UnobtrusiveSession.Session["EmployChangeLog"] = null;
                if (Request.QueryString["ProcessApParmAuto"] != null)
                {
                    int RequestValue = 0;
                    RequestValue = Convert.ToInt32(UnobtrusiveSession.Session["ProcessApParmAuto"].ToString());

                    var rsProcessFlowID = (from c in dcFlow.ProcessApParm
                                           where c.auto == RequestValue
                                           select c).FirstOrDefault();


                    if (rsProcessFlowID != null)
                        lblProcessID.Text = rsProcessFlowID.ProcessFlow_id.ToString();

                    _DataBind();
                    LoadData();
                }
                else if (Request.QueryString["ProcessApViewAuto"] != null)
                {
                    int RequestValue = 0;
                    RequestValue = Convert.ToInt32(UnobtrusiveSession.Session["ProcessApViewAuto"].ToString());

                    var rsProcessFlowID = (from c in dcFlow.ProcessApView
                                           where c.auto == RequestValue
                                           select c).FirstOrDefault();


                    if (rsProcessFlowID != null)
                        lblProcessID.Text = rsProcessFlowID.ProcessFlow_id.ToString();

                    _DataBind();
                    LoadData();
                }
            }
            if (isView)
            {
                btnCheck.Visible = false;
                txtEmployDate.Enabled = false;
                txtPerformance1.Enabled = false;
                txtPerformance2.Enabled = false;
                txtPerformance3.Enabled = false;
                lvSalary.Enabled = false;
                ddlResult.Enabled = false;
                ddlDept.Enabled = false;
                ddlDepta.Enabled = false;
                ddlJob.Enabled = false;
                ddlJobl.Enabled = false;
                plPerformance.Visible = false;
            }
        }

        

        public void LoadData()
        {
            var oFormAppEmployDao = new FormsAppEmployByProcessIdDao();
            var FormAppEmployCond = new FormsAppEmployByProcessIdConditions();

            FormAppEmployCond.AccessToken = _User.AccessToken;
            FormAppEmployCond.RefreshToken = _User.RefreshToken;
            FormAppEmployCond.CompanySetting = CompanySetting;
            FormAppEmployCond.ProcessFlowID = lblProcessID.Text;
            FormAppEmployCond.Sign = true;
            FormAppEmployCond.SignState = "";
            FormAppEmployCond.Status = UnobtrusiveSession.Session["RequestName"].ToString() == "View" ? "" : "1";

            var rsFormAppEmploy = oFormAppEmployDao.GetData(FormAppEmployCond);
            var rFormAppEmploy = new FormsAppEmployByProcessIdRow();
            if (rsFormAppEmploy.Status)
            {
                if (rsFormAppEmploy.Data != null)
                {
                    rFormAppEmploy = rsFormAppEmploy.Data as FormsAppEmployByProcessIdRow;
                    if (rFormAppEmploy != null)
                    {
                        lblName.Text = rFormAppEmploy.EmpName + "," + rFormAppEmploy.EmpID;
                        lblNameAppM.Text = rFormAppEmploy.EmpID;
                        lblSex.Text = rFormAppEmploy.Sex;
                        lblAge.Text = (DateTime.Now.Year - rFormAppEmploy.Birthday.Year).ToString();
                        lblBirth.Text = rFormAppEmploy.Birthday.ToString("yyyy/MM/dd");
                        lblEducation.Text = rFormAppEmploy.SchoolName;
                        lblExperienced.Text = rFormAppEmploy.WorkExperience;
                        lblTrialDateB.Text = rFormAppEmploy.DateA.ToString("yyyy/MM/dd");
                        lblTrialDateE.Text = rFormAppEmploy.DateD.ToString("yyyy/MM/dd");
                        lblTrialDept.Text = rFormAppEmploy.DeptName;
                        lblTrialDeptm.Text = rFormAppEmploy.DeptmName;
                        lblTrialJob.Text = rFormAppEmploy.JobName;
                        lblTrialJobl.Text = rFormAppEmploy.JoblName;
                        var AbsData = JsonConvert.DeserializeObject<List<TextValueRow>>(rFormAppEmploy.AttendContent);
                        lblPersonalLeave.Text = AbsData.Where(p => p.Text == "事假").Select(p => p.Value).FirstOrDefault();
                        lblSickLeave.Text = AbsData.Where(p => p.Text == "病假").Select(p => p.Value).FirstOrDefault();
                        lblAbsenteeism.Text = AbsData.Where(p => p.Text == "曠職").Select(p => p.Value).FirstOrDefault();
                        lblLate.Text = AbsData.Where(p => p.Text == "遲到").Select(p => p.Value).FirstOrDefault();
                        lblEarlyOut.Text = AbsData.Where(p => p.Text == "早退").Select(p => p.Value).FirstOrDefault();
                        var SalaryData = JsonConvert.DeserializeObject<List<TextValueRow>>(rFormAppEmploy.ChangeLogs.First().SalaryContent);
                        lblCode.Text = rFormAppEmploy.ChangeLogs.First().EmployCode;
                        foreach (var Salary in SalaryData)
                        {
                            Salary.Value = AccessData.DESDecrypt(Salary.Value, "JBSalary", lblCode.Text.Substring(0, 8));
                        }
                        lvSalary.DataSource = SalaryData;
                        lvSalary.DataBind();
                        var lsLog = rFormAppEmploy.ChangeLogs;
                        lsLog.Remove(lsLog.First());
                        lvEmployChangeLog.DataSource = lsLog;
                        lvEmployChangeLog.DataBind();
                        lvPerformanceLog.DataSource = lsLog;
                        lvPerformanceLog.DataBind();
                        if (ddlResult.FindItemByValue(rFormAppEmploy.ResultAreaCode) != null)
                        {
                            ddlResult.FindItemByValue(rFormAppEmploy.ResultAreaCode).Selected = true;
                            if (ddlResult.SelectedValue == "03")
                            {
                                plExtend.Visible = true;
                                ddlExtend.FindItemByValue(rFormAppEmploy.ExtendMonth.ToString()).Selected = true;
                            }
                        }
                        if (ddlDept.FindItemByValue(rFormAppEmploy.DeptCodeChange) != null)
                            ddlDept.FindItemByValue(rFormAppEmploy.DeptCodeChange).Selected = true;
                        else if(ddlDept.FindItemByValue(rFormAppEmploy.DeptCode) != null)
                            ddlDept.FindItemByValue(rFormAppEmploy.DeptCode).Selected = true;
                        if (ddlDepta.FindItemByValue(rFormAppEmploy.DeptmCodeChange) != null)
                            ddlDepta.FindItemByValue(rFormAppEmploy.DeptmCodeChange).Selected = true;
                        else if (ddlDepta.FindItemByValue(rFormAppEmploy.DeptmCode) != null)
                            ddlDepta.FindItemByValue(rFormAppEmploy.DeptmCode).Selected = true;
                        if (ddlJob.FindItemByValue(rFormAppEmploy.JobCodeChange) != null)
                            ddlJob.FindItemByValue(rFormAppEmploy.JobCodeChange).Selected = true;
                        else if (ddlJob.FindItemByValue(rFormAppEmploy.JobCode) != null)
                            ddlJob.FindItemByValue(rFormAppEmploy.JobCode).Selected = true;
                        if (ddlJobl.FindItemByValue(rFormAppEmploy.JoblCodeChange) != null)
                            ddlJobl.FindItemByValue(rFormAppEmploy.JoblCodeChange).Selected = true;
                        else if (ddlJobl.FindItemByValue(rFormAppEmploy.JoblCode) != null)
                            ddlJobl.FindItemByValue(rFormAppEmploy.JoblCode).Selected = true;
                        txtEmployDate.SelectedDate = rFormAppEmploy.DateAppoint;
                    }
                }
            }
        }
        public void _DataBind()
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
            var oAllPassType = new AllPassTypeDao();
            var AllPassTypeCond = new AllPassTypeConditions();
            AllPassTypeCond.AccessToken = _User.AccessToken;
            AllPassTypeCond.RefreshToken = _User.RefreshToken;
            AllPassTypeCond.CompanySetting = CompanySetting;
            var AllPassTypeResult = oAllPassType.GetData(AllPassTypeCond);
            if (AllPassTypeResult.Status && AllPassTypeResult.Data != null)
            {
                var rsAllPassType = AllPassTypeResult.Data as List<AllPassTypeRow>;
                if (rsAllPassType != null)
                {
                    ddlResult.DataSource = rsAllPassType;
                    ddlResult.DataTextField = "AllPassTypeName";
                    ddlResult.DataValueField = "AllPassTypeCode";
                    ddlResult.DataBind();
                }
            }
        }
        protected void lvSalary_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {

        }
        protected void ddlResult_TextChanged(object sender, EventArgs e)
        {

            if (ddlResult.SelectedValue == "03")
                plExtend.Visible = true;
            else
                plExtend.Visible = false;
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            var LsSalaryData = new List<TextValueRow>();
            
            if (ddlResult.SelectedItem.Text == "" || ddlResult.SelectedValue == "01")
            {
                lblError.Text = "請選擇結果";
                lblError.CssClass = "badge badge-danger animated shake";
                return;
            }
            if ((txtPerformance1.Text == "" || txtPerformance2.Text == "" || txtPerformance3.Text == "") && ddlResult.SelectedValue=="04")
            {
                lblError.Text = "不予任用時，請填寫主管評核";
                lblError.CssClass = "badge badge-danger animated shake";
                return;
            }
            if (!txtEmployDate.SelectedDate.HasValue || ddlDept.Text == "" || ddlDepta.Text == "" || ddlJob.Text == "" || ddlJobl.Text == "")
            {
                lblError.Text = "請確認資料是否輸入正確";
                lblError.CssClass = "badge badge-danger animated shake";
                return;
            }
            foreach (var r in lvSalary.Items)
            {
                var Salary = r.FindControl("Salary") as RadTextBox;
                var SalaryCode = r.FindControl("SalaryCode") as RadLabel;
                var Amount = r.FindControl("Amount") as RadLabel;
                var SalaryName = r.FindControl("SalaryName") as RadLabel;
                if (Salary.Text == "")
                {
                    lblError.Text = "請確認金額是否輸入正確";
                    lblError.CssClass = "badge badge-danger animated shake";
                    return;
                }
                var SalaryData = new TextValueRow();
                SalaryData.Text = SalaryName.Text;
                SalaryData.Value = AccessData.DESEncrypt(Salary.Text, "JBSalary", lblCode.Text.Substring(0, 8));
                SalaryData.Column1 = SalaryCode.Text;
                SalaryData.Column2 = Amount.Text;
                LsSalaryData.Add(SalaryData);
            }
            var oEmployChangeLog = new FormsAppEmployChangeLog();
            oEmployChangeLog.EmployCode = lblCode.Text;
            oEmployChangeLog.DateAppoint = txtEmployDate.SelectedDate.GetValueOrDefault();
            oEmployChangeLog.DeptCodeChange = ddlDept.SelectedValue;
            oEmployChangeLog.DeptNameChange = ddlDept.Text;
            oEmployChangeLog.DeptmCodeChange = ddlDepta.SelectedValue;
            oEmployChangeLog.DeptmNameChange = ddlDepta.Text;
            oEmployChangeLog.JobCodeChange = ddlJob.SelectedValue;
            oEmployChangeLog.JobNameChange = ddlJob.Text;
            oEmployChangeLog.JoblCodeChange = ddlJobl.SelectedValue;
            oEmployChangeLog.JoblNameChange = ddlJobl.Text;
            oEmployChangeLog.ResultAreaCode = ddlResult.SelectedValue;
            oEmployChangeLog.ResultAreaName = ddlResult.Text;
            oEmployChangeLog.ExtendMonth = ddlResult.SelectedValue == "03"? Convert.ToInt32(ddlExtend.SelectedValue) : 0;
            oEmployChangeLog.SalaryContent = JsonConvert.SerializeObject(LsSalaryData);
            oEmployChangeLog.Performance01 = txtPerformance1.Text;
            oEmployChangeLog.Performance02 = txtPerformance2.Text;
            oEmployChangeLog.Performance03 = txtPerformance3.Text;
            oEmployChangeLog.Performance04 = "";
            oEmployChangeLog.Performance05 = "";
            oEmployChangeLog.Note = "";
            oEmployChangeLog.Status = "1";
            oEmployChangeLog.InsertMan = _User.EmpName;
            oEmployChangeLog.InsertDate = DateTime.Now;
            oEmployChangeLog.UpdateMan = _User.EmpName;
            oEmployChangeLog.UpdateDate = DateTime.Now;
            UnobtrusiveSession.Session["EmployChangeLog"] = oEmployChangeLog;
            UnobtrusiveSession.Session["LsSalaryData"] = LsSalaryData;
            lblError.Text = "確認成功";
            lblError.CssClass = "badge badge-primary animated shake";
            
        }

        protected void lvSalary_DataBound(object sender, EventArgs e)
        {
            int Count = 0;
            int AmountSum = 0;
            int SalarySum = 0;
            var oFormAppEmployDao = new FormsAppEmployByProcessIdDao();
            var FormAppEmployCond = new FormsAppEmployByProcessIdConditions();

            FormAppEmployCond.AccessToken = _User.AccessToken;
            FormAppEmployCond.RefreshToken = _User.RefreshToken;
            FormAppEmployCond.CompanySetting = CompanySetting;
            FormAppEmployCond.ProcessFlowID = lblProcessID.Text;
            FormAppEmployCond.Sign = true;
            FormAppEmployCond.SignState = "";
            FormAppEmployCond.Status = UnobtrusiveSession.Session["RequestName"].ToString() == "View" ? "" : "1";

            var rsFormAppEmploy = oFormAppEmployDao.GetData(FormAppEmployCond);
            var rFormAppEmploy = new FormsAppEmployByProcessIdRow();
            if (rsFormAppEmploy.Status)
            {
                if (rsFormAppEmploy.Data != null)
                {
                    rFormAppEmploy = rsFormAppEmploy.Data as FormsAppEmployByProcessIdRow;
                    
                }
            }
            foreach (var r in lvSalary.Items)
            {

                var Salary = r.FindControl("Salary") as RadTextBox;
                var Amount = r.FindControl("Amount") as RadLabel;
                if (rFormAppEmploy != null)
                {
                    var SalaryData = JsonConvert.DeserializeObject<List<TextValueRow>>(rFormAppEmploy.ChangeLogs.Last().SalaryContent);
                    lblCode.Text = rFormAppEmploy.ChangeLogs.Last().EmployCode;
                    foreach (var SalaryD in SalaryData)
                    {
                        SalaryD.Value = AccessData.DESDecrypt(SalaryD.Value, "JBSalary", lblCode.Text.Substring(0, 8));
                    }
                    Salary.Text = SalaryData[Count].Value;
                }
                Count++;
                //Salary.Text = Amount.Text;
                SalarySum += Convert.ToInt32(Salary.Text);
                AmountSum += Convert.ToInt32(Amount.Text);
            }
            var lblSalarySum = lvSalary.FindControl("lblSalarySum") as RadLabel;
            var lblAmountSum = lvSalary.FindControl("lblAmountSum") as RadLabel;
            if (lblSalarySum != null)
                lblSalarySum.Text = SalarySum.ToString();
            if (lblAmountSum != null)
                lblAmountSum.Text = AmountSum.ToString();
        }

        protected void lvSalaryLog_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var lsSalaryLog = (from c in dcFlow.FormsAppEmploySalary
                               where c.EmployCode == lblCode.Text
                               select c).ToList();
            var gSalaryLog = lsSalaryLog.GroupBy(p => p.InsertMan).ToList();
            var rsSalaryLog = new List<SalaryLog>();
            var oFormAppEmployDao = new FormsAppEmployByProcessIdDao();
            var FormAppEmployCond = new FormsAppEmployByProcessIdConditions();

            FormAppEmployCond.AccessToken = _User.AccessToken;
            FormAppEmployCond.RefreshToken = _User.RefreshToken;
            FormAppEmployCond.CompanySetting = CompanySetting;
            FormAppEmployCond.ProcessFlowID = lblProcessID.Text;
            FormAppEmployCond.Sign = true;
            FormAppEmployCond.SignState = "";
            FormAppEmployCond.Status = UnobtrusiveSession.Session["RequestName"].ToString() == "View" ? "" : "1";

            var rsFormAppEmploy = oFormAppEmployDao.GetData(FormAppEmployCond);
            var rFormAppEmploy = new FormsAppEmployByProcessIdRow();
            if (rsFormAppEmploy.Status)
            {
                if (rsFormAppEmploy.Data != null)
                {
                    rFormAppEmploy = rsFormAppEmploy.Data as FormsAppEmployByProcessIdRow;
                    if (rFormAppEmploy != null)
                    {
                        var SalaryData = JsonConvert.DeserializeObject<List<TextValueRow>>(rFormAppEmploy.ChangeLogs.First().SalaryContent);
                        lblCode.Text = rFormAppEmploy.ChangeLogs.First().EmployCode;
                        var rSalaryLog = new SalaryLog();
                        rSalaryLog.InsertMan = rFormAppEmploy.ChangeLogs.First().InsertMan;
                        rSalaryLog.InsertDate = rFormAppEmploy.ChangeLogs.First().InsertDate;
                        foreach (var Data in SalaryData)
                        {
                            rSalaryLog.SalaryData += Data.Text + ":" + AccessData.DESDecrypt(Data.Value, "JBSalary", lblCode.Text.Substring(0, 8)) + ";";
                            
                        }
                        rsSalaryLog.Add(rSalaryLog);
                    }
                }
            }
            foreach (var r in gSalaryLog)
            {
                var rSalaryLog = new SalaryLog();
                rSalaryLog.InsertMan = r.Key;
                foreach (var Data in r)
                {
                    rSalaryLog.SalaryData += Data.SalaryName + ":" + AccessData.DESDecrypt(Data.Note, "JBSalary", lblCode.Text.Substring(0, 8)) + ";";
                    rSalaryLog.InsertDate = Data.InsertDate.GetValueOrDefault();
                }
                rsSalaryLog.Add(rSalaryLog);
            }
            lvSalaryLog.DataSource = rsSalaryLog;
        }
        protected void SalarySumChange()
        {
            int SalarySum = 0;
            foreach (var r in lvSalary.Items)
            {
                var Salary = r.FindControl("Salary") as RadTextBox;
                SalarySum += Convert.ToInt32(Salary.Text);
            }
            var lblSalarySum = lvSalary.FindControl("lblSalarySum") as RadLabel;
            lblSalarySum.Text = SalarySum.ToString();
        }

        protected void Salary_TextChanged(object sender, EventArgs e)
        {
            SalarySumChange();
        }
    }
}