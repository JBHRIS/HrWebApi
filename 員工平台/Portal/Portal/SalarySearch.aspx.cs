using Bll.Employee.Vdb;
using Bll.Salary.Vdb;
using Dal;
using Dal.Dao.Employee;
using Dal.Dao.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal
{
    public partial class SalarySearch : WebPageBase
    {
        protected static string YYMM = "";//計薪年月
        protected static string Seq = "";//期別
        protected static string Type = "";
        protected static bool SearchResult = true;//API呼叫結果，呼叫失敗則不顯示
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (!IsPostBack)
            {
               
                ddlPeriod_DataBind();

            }
            RadClientExportManager1.PdfSettings.Fonts.Add("Arial Unicode MS", "Fonts/Arial-Unicode-MS.ttf");
            RadClientExportManager1.PdfSettings.FileName = "薪資單.pdf";
        }

        protected void ddlPeriod_DataBind()
        {
            var oSalaryLock = new SalaryLockDao();
            var SalaryLockCond = new SalaryLockConditions();
            SalaryLockCond.AccessToken = _User.AccessToken;
            SalaryLockCond.RefreshToken = _User.RefreshToken;
            SalaryLockCond.CompanySetting = CompanySetting;
            var Result = oSalaryLock.GetData(SalaryLockCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    var result = Result.Data as List<SalaryLockRow>;
                    foreach (var DataRow in result)
                    {
                        DataRow.TotalValue = DataRow.Yymm + ";" + DataRow.Seq + ";" + DataRow.SalaryType;
                    }
                    ddlPeriod.DataSource = result;
                    ddlPeriod.DataTextField = "SalaryList";
                    ddlPeriod.DataValueField = "TotalValue";
                    ddlPeriod.DataBind();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchResult = true;
            plMain.Visible = false;
            if (YYMM == "")
            {
                lblMsg.Text = "請輸入日期區間";
                lblMsg.CssClass = "badge badge-danger shake animated";
                txtSalaryPassword.Text = "";
                return;
            }
            if (txtSalaryPassword.Text.Trim() == "")
            {
                lblMsg.Text = "請輸入薪資密碼";
                lblMsg.CssClass = "badge badge-danger shake animated";
                txtSalaryPassword.Text = "";
                return;
            }
            lvSalaryBlockEarnings.Rebind();
            lvSalaryBlockDeduction.Rebind();
            lvSalaryBlockAbs.Rebind();
            lvSalaryBlockSalary.Rebind();
            lvSalaryBlockOt.Rebind();
            lvSalaryBlockRetirement.Rebind();
           
            if (SearchResult)
            {
                lblMsg.Text = "";
                var oAnnualLeave = new AnnualLeaveDao();
                var AnnualLeaveCond = new AnnualLeaveConditions();
                AnnualLeaveCond.AccessToken = _User.AccessToken;
                AnnualLeaveCond.RefreshToken = _User.RefreshToken;
                AnnualLeaveCond.CompanySetting = CompanySetting;
                AnnualLeaveCond.YYMM = YYMM;
                AnnualLeaveCond.Seq = Seq;
                var ResultAnnual = oAnnualLeave.GetData(AnnualLeaveCond);
                if (ResultAnnual.Status)
                {
                    if (ResultAnnual.Data != null)
                    {
                        var resultAnnual = ResultAnnual.Data as AnnualLeaveRow;
                        lblSalaryAnnualHour.Text = resultAnnual.Hour.ToString();
                    }
                }
                var oCompensatoryLeave = new CompensatoryLeaveDao();
                var CompensatoryLeaveCond = new CompensatoryLeaveConditions();
                CompensatoryLeaveCond.AccessToken = _User.AccessToken;
                CompensatoryLeaveCond.RefreshToken = _User.RefreshToken;
                CompensatoryLeaveCond.CompanySetting = CompanySetting;
                CompensatoryLeaveCond.YYMM = YYMM;
                CompensatoryLeaveCond.Seq = Seq;
                var ResultCompensatory = oCompensatoryLeave.GetData(CompensatoryLeaveCond);
                if (ResultCompensatory.Status)
                {
                    if (ResultCompensatory.Data != null)
                    {
                        var resultCompensatory = ResultCompensatory.Data as CompensatoryLeaveRow;
                        lblSalaryCompensatoryHour.Text =  resultCompensatory.Hour.ToString();
                    }
                }
                var oPayslipTitle = new PayslipTitleDao();
                var PayslipCond = new PayslipTitleConditions();
                PayslipCond.AccessToken = _User.AccessToken;
                PayslipCond.RefreshToken = _User.RefreshToken;
                PayslipCond.CompanySetting = CompanySetting;
                PayslipCond.yymm = YYMM;
                PayslipCond.seq = Seq;
                PayslipCond.password = txtSalaryPassword.Text.Trim();
                var PayslipResult = oPayslipTitle.GetData(PayslipCond);
                if (PayslipResult.Status)
                {
                    if (PayslipResult.Data != null)
                    {
                        var Payslipresult = PayslipResult.Data as PayslipTitleRow;
                        lblSalaryAttendDateB.Text = Payslipresult.AttDateB.ToShortDateString();
                        lblSalaryAttendDateE.Text = Payslipresult.AttDateE.ToShortDateString();
                        lblSalaryNote.Text = "備註:" + Payslipresult.Note;
                        lblSalaryTransDate.Text = Payslipresult.ADate.ToShortDateString();

                        //調整
                        lblSalaryDept.Text = _User.EmpDeptName;
                        lblSalaryName.Text = _User.EmpId + " " + _User.EmpName;
                        lblSalaryPosition.Text = _User.EmpJobName;
                        var oCurrentJobStatus = new CurrentJobStatusDao();
                        var CurrentJobStatusCond = new CurrentJobStatusConditions();
                        CurrentJobStatusCond.AccessToken = _User.AccessToken;
                        CurrentJobStatusCond.RefreshToken = _User.RefreshToken;
                        CurrentJobStatusCond.CompanySetting = CompanySetting;
                        CurrentJobStatusCond.nobr = _User.EmpId;
                        CurrentJobStatusCond.Adate = Payslipresult.SalDateE;
                        var CurrentJobStatusResult = oCurrentJobStatus.GetData(CurrentJobStatusCond);
                        if (CurrentJobStatusResult.Status && CurrentJobStatusResult.Data != null)
                        {
                            var CurrentJobStatusresult = CurrentJobStatusResult.Data as CurrentJobStatusRow;
                            if (CurrentJobStatusresult != null)
                            {
                                var JobCode = CurrentJobStatusresult.Result.Job;
                                var DeptCode = CurrentJobStatusresult.Result.Dept;
                                var oJob = new JobDao();
                                var JobCond = new JobConditions();
                                JobCond.AccessToken = _User.AccessToken;
                                JobCond.RefreshToken = _User.RefreshToken;
                                JobCond.CompanySetting = CompanySetting;
                                var JobResult = oJob.GetData(JobCond);
                                if (JobResult.Status && JobResult.Data != null)
                                {
                                    var Jobresult = JobResult.Data as List<JobRow>;
                                    if (Jobresult != null)
                                    {
                                        lblSalaryPosition.Text = Jobresult.Where(p => p.JobCode == JobCode).Select(p => p.JobName).FirstOrDefault();
                                    }
                                }
                                var oDept = new DeptDao();
                                var DeptCond = new DeptConditions();
                                DeptCond.AccessToken = _User.AccessToken;
                                DeptCond.RefreshToken = _User.RefreshToken;
                                DeptCond.CompanySetting = CompanySetting;
                                var DeptResult = oDept.GetData(DeptCond);
                                if (DeptResult.Status && DeptResult.Data != null)
                                {
                                    var Deptresult = DeptResult.Data as List<DeptRow>;
                                    if (Deptresult != null)
                                    {
                                        lblSalaryDept.Text = Deptresult.Where(p => p.DeptCode == DeptCode).Select(p => p.DeptName).FirstOrDefault();
                                    }
                                }
                            }
                        }
                    }
                }
                plMain.Visible = true;
                btnExportPdf.Visible = true;
            }
            else
            {
                lblMsg.Text = "請確認薪資密碼是否輸入正確";
                lblMsg.CssClass = "badge badge-danger shake animated";
                plMain.Visible = false;
            }
            txtSalaryPassword.Text = "";

        }

        protected void lvSalaryBlockAbs_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var oAbsThisMonth = new AbsThisMonthDao();
            var AbsThisMonthCond = new AbsThisMonthConditions();
            AbsThisMonthCond.AccessToken = _User.AccessToken;
            AbsThisMonthCond.RefreshToken = _User.RefreshToken;
            AbsThisMonthCond.CompanySetting = CompanySetting;
            AbsThisMonthCond.yymm = YYMM;
            AbsThisMonthCond.password = txtSalaryPassword.Text.Trim();
            var Result = oAbsThisMonth.GetData(AbsThisMonthCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    var result = Result.Data as SalaryRow;
                    foreach (var SalaryData in result.Details)
                    {
                        SalaryData.Salary = SalaryData.Salary + "小時";
                    }
                    lblSalaryTitleAbs.Text = result.Title;
                    lvSalaryBlockAbs.DataSource = result.Details;
                }
                else
                    SearchResult = false;
            }
            else
                SearchResult = false;
        }

        protected void lvSalaryBlockEarnings_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var oEarningsThisMonth = new EarningsThisMonthDao();
            var EarningsThisMonthCond = new EarningsThisMonthConditions();
            EarningsThisMonthCond.AccessToken = _User.AccessToken;
            EarningsThisMonthCond.RefreshToken = _User.RefreshToken;
            EarningsThisMonthCond.CompanySetting = CompanySetting;
            EarningsThisMonthCond.yymm = YYMM;
            EarningsThisMonthCond.seq = Seq;
            EarningsThisMonthCond.password = txtSalaryPassword.Text.Trim();
            var Result = oEarningsThisMonth.GetData(EarningsThisMonthCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    var result = Result.Data as SalaryRow;
                    int i = 0;
                    foreach (var SalaryData in result.Details)
                    {
                        i += Convert.ToInt32(SalaryData.Salary);
                        SalaryData.Salary = Convert.ToDouble(SalaryData.Salary).ToString("N0");
                    }
                    result.Sum.Salary = i.ToString("N0");
                    lblSalarySumEarnings.Text = result.Sum.Salary;
                    lblSalaryTitleEarnings.Text = result.Title;
                    lvSalaryBlockEarnings.DataSource = result.Details;
                }
                else
                    SearchResult = false;
            }
            else
                SearchResult = false;
        }

        protected void lvSalaryBlockDeduction_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var oDeductionThisMonth = new DeductionThisMonthDao();
            var DeductionThisMonthCond = new DeductionThisMonthConditions();
            DeductionThisMonthCond.AccessToken = _User.AccessToken;
            DeductionThisMonthCond.RefreshToken = _User.RefreshToken;
            DeductionThisMonthCond.CompanySetting = CompanySetting;
            DeductionThisMonthCond.yymm = YYMM;
            DeductionThisMonthCond.seq = Seq;
            DeductionThisMonthCond.password = txtSalaryPassword.Text.Trim();
            var Result = oDeductionThisMonth.GetData(DeductionThisMonthCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    var result = Result.Data as SalaryRow;
                    int i = 0;
                    foreach (var SalaryData in result.Details)
                    {
                        i += Convert.ToInt32(SalaryData.Salary);
                        SalaryData.Salary = Convert.ToDouble(SalaryData.Salary).ToString("N0");
                    }
                    result.Sum.Salary = i.ToString("N0");
                    lblSalarySumDeduction.Text = result.Sum.Salary;
                    lblSalaryTitleDeduction.Text = result.Title;
                    lvSalaryBlockDeduction.DataSource = result.Details;
                }
                else
                    SearchResult = false;
            }
            else
                SearchResult = false;
        }

        protected void lvSalaryBlockSalary_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var oSalaryThisMonth = new SalaryThisMonthDao();
            var SalaryThisMonthCond = new SalaryThisMonthConditions();
            SalaryThisMonthCond.AccessToken = _User.AccessToken;
            SalaryThisMonthCond.RefreshToken = _User.RefreshToken;
            SalaryThisMonthCond.CompanySetting = CompanySetting;
            SalaryThisMonthCond.yymm = YYMM;
            SalaryThisMonthCond.seq = Seq;
            SalaryThisMonthCond.password = txtSalaryPassword.Text.Trim();
            var Result = oSalaryThisMonth.GetData(SalaryThisMonthCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    var result = Result.Data as SalaryRow;
                    foreach (var SalaryData in result.Details)
                    {
                        SalaryData.Salary = Convert.ToDouble(SalaryData.Salary).ToString("N0");
                    }
                    lblSalaryTitleSalary.Text = result.Title;
                    lvSalaryBlockSalary.DataSource = result.Details;
                }
                else
                    SearchResult = false;
            }
            else
                SearchResult = false;
        }

        protected void lvSalaryBlockOt_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var oOtThisMonth = new OtThisMonthDao();
            var OtThisMonthCond = new OtThisMonthConditions();
            OtThisMonthCond.AccessToken = _User.AccessToken;
            OtThisMonthCond.RefreshToken = _User.RefreshToken;
            OtThisMonthCond.CompanySetting = CompanySetting;
            OtThisMonthCond.yymm = YYMM;
            OtThisMonthCond.password = txtSalaryPassword.Text.Trim();
            var Result = oOtThisMonth.GetData(OtThisMonthCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    var result = Result.Data as SalaryRow;
                    foreach(var detail in result.Details)
                    {
                        detail.Item = detail.Item + " 倍";
                        detail.Salary = detail.Salary + " 小時";
                    }    
                    lblSalaryTitleOt.Text = result.Title;
                    lvSalaryBlockOt.DataSource = result.Details;
                }
                else
                    SearchResult = false;
            }
            else
                SearchResult = false;
        }
        protected void lvSalaryBlockRetirement_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            plSalaryRetirement.Visible = true;
            var SalaryRetirementSeqConfig = (from c in dcFlow.FormsExtend
                                             where c.FormsCode == "Salary" && c.Code == "SalaryRetirementSeqConfig" && c.Active
                                             select c).FirstOrDefault();
            var lsSalarySeq = new List<string>();
            if(SalaryRetirementSeqConfig != null)
                lsSalarySeq = SalaryRetirementSeqConfig.Column1.Split(';').ToList();
            if (!lsSalarySeq.Contains(Seq))
            {
                var oRetirementThisMonth = new RetirementThisMonthDao();
                var RetirementThisMonthCond = new RetirementThisMonthConditions();
                RetirementThisMonthCond.AccessToken = _User.AccessToken;
                RetirementThisMonthCond.RefreshToken = _User.RefreshToken;
                RetirementThisMonthCond.CompanySetting = CompanySetting;
                RetirementThisMonthCond.yymm = YYMM;
                RetirementThisMonthCond.password = txtSalaryPassword.Text.Trim();
                var Result = oRetirementThisMonth.GetData(RetirementThisMonthCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        var result = Result.Data as SalaryRow;
                        foreach (var SalaryData in result.Details)
                        {
                            SalaryData.Salary = Convert.ToDouble(SalaryData.Salary).ToString("N0");
                        }
                        lblSalaryTitleRetirement.Text = result.Title;
                        lvSalaryBlockRetirement.DataSource = result.Details;
                    }
                    else
                        SearchResult = false;
                }
                else
                    SearchResult = false;
            }
            else
            {
                plSalaryRetirement.Visible = false;
            }
        }

        protected void btnSubmitSalaryPassword_Click(object sender, EventArgs e)
        {
            if(txtNewSalaryPassword.Text.Trim() != txtCheckSalaryPassword.Text.Trim() || txtNewSalaryPassword.Text.Trim() == "")
            {
                lblModMsg.Text = "請確認輸入是否正確";
                lblModMsg.CssClass = "badge badge-danger animated shake";
                return;
            }
            var oSetSalaryPassword = new SetSalaryPassWordDao();
            var SetSalaryPasswordCond = new SetSalaryPassWordConditions();
            SetSalaryPasswordCond.AccessToken = _User.AccessToken;
            SetSalaryPasswordCond.RefreshToken = _User.RefreshToken;
            SetSalaryPasswordCond.CompanySetting = CompanySetting;
            SetSalaryPasswordCond.password = txtNewSalaryPassword.Text.Trim();
            var Result = oSetSalaryPassword.GetData(SetSalaryPasswordCond);
            if (Result.Status)
            {
                lblModMsg.Text = "設定成功";
                lblModMsg.CssClass = "badge badge-primary animated shake";
            }
            else
            {
                if (Result.Message != null)
                {
                    var result = Result.Message as string;
                    lblModMsg.Text = result;
                    lblModMsg.CssClass = "badge badge-danger animated shake";
                }
                else
                {
                    lblModMsg.Text = "設定失敗";
                    lblModMsg.CssClass = "badge badge-danger animated shake";
                }
            }
        }


        protected void ddlPeriod_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var Value = ddlPeriod.SelectedValue;
            var Data = Value.Split(';');
            YYMM = Data[0];
            Seq = Data[1];
            Type = Data[2];
        }
    }
}