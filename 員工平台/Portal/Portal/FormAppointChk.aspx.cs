using Bll;
using Bll.Employee.Vdb;
using Bll.Flow.Vdb;
using Bll.Salary.Vdb;
using Dal;
using Dal.Dao.Employee;
using Dal.Dao.Flow;
using Dal.Dao.Salary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class FormAppointChk : WebPageBase
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
            ContentPlaceHolder content = (ContentPlaceHolder)Master.Master.FindControl("ContentPlaceHolder1");
            var btnCheck = content.FindControl("btnCheck") as RadRadioButtonList;
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["SalaryData"] = null;
                UnobtrusiveSession.Session["Appoint"] = null;
                UnobtrusiveSession.Session["AppointChangeLog"] = null;
                UnobtrusiveSession.Session["LsSalaryData"] = null;
                if (Request.QueryString["ProcessApParmAuto"] != null)
                {
                    int RequestValue = 0;
                    RequestValue = Convert.ToInt32(UnobtrusiveSession.Session["ProcessApParmAuto"].ToString());

                    var rsProcessFlowID = (from c in dcFlow.ProcessApParm
                                           where c.auto == RequestValue
                                           select c).FirstOrDefault();
                    var CheckButtonVisible = (from c in dcFlow.FormsExtend
                                              where c.FormsCode == "Appoint" && c.Code == "CheckButtonVisible" && c.Active == true
                                              select c).FirstOrDefault();
                    if (CheckButtonVisible != null && btnCheck != null)
                    {
                        btnCheck.Visible = true;
                    }

                    if (rsProcessFlowID != null)
                        lblProcessID.Text = rsProcessFlowID.ProcessFlow_id.ToString();
                }
                else if (Request.QueryString["ProcessApViewAuto"] != null)
                {
                    int RequestValue = 0;
                    RequestValue = Convert.ToInt32(UnobtrusiveSession.Session["ProcessApViewAuto"].ToString());

                    var rsProcessFlowID = (from c in dcFlow.ProcessApView
                                           where c.auto == RequestValue
                                           select c).FirstOrDefault();

                    var CheckButtonVisible = (from c in dcFlow.FormsExtend
                                              where c.FormsCode == "Appoint" && c.Code == "CheckButtonVisible" && c.Active == true
                                              select c).FirstOrDefault();
                    if (CheckButtonVisible != null)
                    {
                        btnCheck.Visible = true;
                    }
                    
                    if (rsProcessFlowID != null)
                        lblProcessID.Text = rsProcessFlowID.ProcessFlow_id.ToString();
                }
                if (_User.Role.Contains("Hr"))
                {
                    plAudit.Visible = true;
                }
                _DataBind();
                LoadData();
            }
            if (isView)
            {
                ddlDept.Enabled = false;
                ddlDeptm.Enabled = false;
                ddlJob.Enabled = false;
                ddlJobl.Enabled = false;
                txtDateAppoint.Enabled = false;
                txtPerformance1.Enabled = false;
                txtPerformance2.Enabled = false;
                btnSalaryChange.Visible = false;
                btnConfirm.Visible = false;
                plSalary.Visible = false;
                plAudit.Visible = false;
                btnCheck.Visible = false;
            }
        }
        public void LoadData()
        {
            var oFormAppAppointDao = new FormsAppAppointByProcessIdDao();
            var FormAppAppointCond = new FormsAppAppointByProcessIdConditions();

            FormAppAppointCond.AccessToken = _User.AccessToken;
            FormAppAppointCond.RefreshToken = _User.RefreshToken;
            FormAppAppointCond.CompanySetting = CompanySetting;
            FormAppAppointCond.ProcessFlowID = lblProcessID.Text;
            FormAppAppointCond.Sign = true;
            FormAppAppointCond.SignState = "";
            FormAppAppointCond.Status = UnobtrusiveSession.Session["RequestName"].ToString() == "View" ? "" : "1";

            var rsFormAppAppoint = oFormAppAppointDao.GetData(FormAppAppointCond);
            var rFormAppAppoint = new FormsAppAppointByProcessIdRow();
            if (rsFormAppAppoint.Status)
            {
                if (rsFormAppAppoint.Data != null)
                {
                    rFormAppAppoint = rsFormAppAppoint.Data as FormsAppAppointByProcessIdRow;
                    if (rFormAppAppoint != null)
                    {
                        lblCode.Text = rFormAppAppoint.Code;
                        //cbAudit.Checked = rFormAppAppoint.AllowSign;
                        lblEmpName.Text = rFormAppAppoint.EmpName + "," + rFormAppAppoint.EmpID;
                        lblNobrAppM.Text = rFormAppAppoint.EmpID;
                        lblSchoolName.Text = rFormAppAppoint.SchoolName;
                        lblBirthday.Text = rFormAppAppoint.Birthday.ToString("yyyy/MM/dd");
                        lblDateIn.Text = rFormAppAppoint.DateIn.ToString("yyyy/MM/dd");
                        lblDeptName.Text = rFormAppAppoint.DeptName;
                        lblDeptm.Text = rFormAppAppoint.DeptmName;
                        lblJobName.Text = rFormAppAppoint.JobName;
                        lblJoblName.Text = rFormAppAppoint.JoblName;
                        lblChangeItem.Text = rFormAppAppoint.ChangeItemName;
                        txtReasonChange.Text = rFormAppAppoint.ReasonChange;
                        lblyear1.Text = rFormAppAppoint.InsertDate.ToString("yyyy");
                        lblyear2.Text = rFormAppAppoint.InsertDate.AddYears(-1).ToString("yyyy");
                        lblyear3.Text = rFormAppAppoint.InsertDate.AddYears(-2).ToString("yyyy");
                        lblPerformance1.Text = rFormAppAppoint.Performance1;
                        lblPerformance2.Text = rFormAppAppoint.Performance2;
                        lblPerformance3.Text = rFormAppAppoint.Performance3;
                        txtDateAppoint.SelectedDate = rFormAppAppoint.DateAppoint;
                        lblDateA.Text = rFormAppAppoint.DateA.ToString("yyyy/MM/dd");
                        if (rFormAppAppoint.ChangeItemCode == "01")
                        {
                            plPromotion.Visible = true;
                            plLog.Visible = true;
                        }
                        else
                        {
                            plPromotion.Visible = false;
                            plLog.Visible = false;
                        }
                        if (ddlDept.FindItemByValue(rFormAppAppoint.DeptCodeChange) != null)
                            ddlDept.FindItemByValue(rFormAppAppoint.DeptCodeChange).Selected = true;
                        else if (ddlDept.FindItemByValue(rFormAppAppoint.DeptCode) != null)
                            ddlDept.FindItemByValue(rFormAppAppoint.DeptCode).Selected = true;
                        if (ddlDeptm.FindItemByValue(rFormAppAppoint.DeptmCodeChange) != null)
                            ddlDeptm.FindItemByValue(rFormAppAppoint.DeptmCodeChange).Selected = true;
                        else if (ddlDeptm.FindItemByValue(rFormAppAppoint.DeptmCode) != null)
                            ddlDeptm.FindItemByValue(rFormAppAppoint.DeptmCode).Selected = true;
                        if (ddlJob.FindItemByValue(rFormAppAppoint.JobCodeChange) != null)
                            ddlJob.FindItemByValue(rFormAppAppoint.JobCodeChange).Selected = true;
                        else if (ddlJob.FindItemByValue(rFormAppAppoint.JobCode) != null)
                            ddlJob.FindItemByValue(rFormAppAppoint.JobCode).Selected = true;
                        if (ddlJobl.FindItemByValue(rFormAppAppoint.JoblCodeChange) != null)
                            ddlJobl.FindItemByValue(rFormAppAppoint.JoblCodeChange).Selected = true;
                        else if (ddlJobl.FindItemByValue(rFormAppAppoint.JoblCode) != null)
                            ddlJobl.FindItemByValue(rFormAppAppoint.JoblCode).Selected = true;
                        if (rFormAppAppoint.AllowSalary)
                            plSalary.Visible = true;
                        lvAppointChangeLog.DataSource = rFormAppAppoint.AppointChangeLog;
                        lvAppointChangeLog.DataBind();
                        lvPerformanceLog.DataSource = rFormAppAppoint.AppointChangeLog;
                        lvPerformanceLog.DataBind();
                        lvSalaryLog.Rebind();
                        var SalaryData = JsonConvert.DeserializeObject<List<TextValueRow>>(rFormAppAppoint.AppointChangeLog.Last().SalaryContent);
                        if (SalaryData != null)
                        {
                            foreach (var Salary in SalaryData)
                            {
                                Salary.Value = AccessData.DESDecrypt(Salary.Value, "JBSalary", lblCode.Text.Substring(0, 8));
                            }
                            lvSalary.DataSource = SalaryData;
                            lvSalary.DataBind();
                        }
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
                    ddlDeptm.DataSource = rsDepta;
                    ddlDeptm.DataTextField = "DeptaName";
                    ddlDeptm.DataValueField = "DeptaCode";
                    ddlDeptm.DataBind();
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

        protected void btnLoadinSalary_Click(object sender, EventArgs e)
        {
            plSalary.Visible = true;
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
                        foreach (var r in res)
                        {
                            r.DESData = AccessData.DESEncrypt(r.Amount.ToString(), "JBSalary", lblCode.Text.Substring(0, 8));
                            var rTextValue = new TextValueRow();
                            rTextValue.Text = r.SalName;
                            rTextValue.Value = r.DESData;
                            rTextValue.Column1 = r.SalCode;
                            resSalary.Add(rTextValue);
                        }
                        UnobtrusiveSession.Session["SalaryData"] = JsonConvert.SerializeObject(resSalary);
                    }
                }
                lvSalary.Rebind();
            }
            #endregion
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var LsSalaryData = new List<TextValueRow>();
            if (lblChangeItem.Text == "晉升" && (txtPerformance1.Text == "" || txtPerformance2.Text == ""))
            {
                lblError.Text = "請填寫主管評核";
                lblError.CssClass = "badge badge-danger animated shake";
                return;
            }

            if (!txtDateAppoint.SelectedDate.HasValue || ddlDept.Text == "" || ddlDeptm.Text == "" || ddlJob.Text == "" || ddlJobl.Text == "")
            {
                lblError.Text = "請確認資料是否輸入正確";
                lblError.CssClass = "badge badge-danger";
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
                    lblError.CssClass = "badge badge-danger";
                    return;
                }
                var SalaryData = new TextValueRow();
                SalaryData.Text = SalaryName.Text;
                SalaryData.Value = AccessData.DESEncrypt(Salary.Text, "JBSalary", lblCode.Text.Substring(0, 8));
                SalaryData.Column1 = SalaryCode.Text;
                SalaryData.Column2 = Amount.Text;
                LsSalaryData.Add(SalaryData);
            }
            var oAppointChangeLog = new FormsAppAppointChangeLog();
            oAppointChangeLog.AppointCode = lblCode.Text;
            oAppointChangeLog.DateAppoint = txtDateAppoint.SelectedDate.GetValueOrDefault();
            oAppointChangeLog.DeptCodeChange = ddlDept.SelectedValue;
            oAppointChangeLog.DeptNameChange = ddlDept.Text;
            oAppointChangeLog.DeptmCodeChange = ddlDeptm.SelectedValue;
            oAppointChangeLog.DeptmNameChange = ddlDeptm.Text;
            oAppointChangeLog.JobCodeChange = ddlJob.SelectedValue;
            oAppointChangeLog.JobNameChange = ddlJob.Text;
            oAppointChangeLog.JoblCodeChange = ddlJobl.SelectedValue;
            oAppointChangeLog.JoblNameChange = ddlJobl.Text;
            oAppointChangeLog.Performance1 = txtPerformance1.Text;
            oAppointChangeLog.Performance2 = txtPerformance2.Text;
            oAppointChangeLog.SalaryContent = JsonConvert.SerializeObject(LsSalaryData);
            oAppointChangeLog.Note = "";
            oAppointChangeLog.Status = "1";
            oAppointChangeLog.InsertMan = _User.EmpName;
            oAppointChangeLog.InsertDate = DateTime.Now.Date;
            oAppointChangeLog.UpdateMan = _User.EmpName;
            oAppointChangeLog.UpdateDate = DateTime.Now.Date;
            var oAppoint = new FormsAppAppoint();
            oAppoint.AllowSalary = lvSalary.Items.Count > 0;
            oAppoint.AllowSign = true;// (bool)cbAudit.Checked;
            oAppoint.Evaluation = txtPerformance1.Text;
            oAppoint.Qualified = txtPerformance2.Text;
            UnobtrusiveSession.Session["Appoint"] = oAppoint;
            UnobtrusiveSession.Session["AppointChangeLog"] = oAppointChangeLog;
            UnobtrusiveSession.Session["LsSalaryData"] = LsSalaryData;
            lblError.Text = "確認成功";
            lblError.CssClass = "badge badge-primary animated shake";

        }

        protected void lvSalary_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            if (UnobtrusiveSession.Session["SalaryData"] != null)
            {
                var SalaryData = JsonConvert.DeserializeObject<List<TextValueRow>>(UnobtrusiveSession.Session["SalaryData"].ToString());
                foreach (var Salary in SalaryData)
                {
                    Salary.Value = AccessData.DESDecrypt(Salary.Value, "JBSalary", lblCode.Text.Substring(0, 8));
                }
                lvSalary.DataSource = SalaryData;
            }
        }

        protected void lvSalary_DataBound(object sender, EventArgs e)
        {
            foreach (var r in lvSalary.Items)
            {
                var Salary = r.FindControl("Salary") as RadTextBox;
                var Amount = r.FindControl("Amount") as RadLabel;
                Salary.Text = Amount.Text;
            }
        }
        
        protected void lvSalaryLog_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var lsSalaryLog = (from c in dcFlow.FormsAppEmploySalary
                               where c.EmployCode == lblCode.Text
                               select c).ToList();
            var gSalaryLog = lsSalaryLog.GroupBy(p => p.InsertMan).ToList() ;
            var rsSalaryLog = new List<SalaryLog>();
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
    }
}