using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBTools.Extend;
namespace JBHR.Sal
{
    public partial class FRM4OP : JBControls.U_CONDITION
    {
        JBControls.MultiSelectionDialog empOutSelection = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog empSelection = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog salcodeSelection = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog hcodeSelection = new JBControls.MultiSelectionDialog();
        List<AnnualLeaveCashDto> AnnualList = new List<AnnualLeaveCashDto>();
        List<AnnualLeaveCashDto> AnnualOutList = new List<AnnualLeaveCashDto>();

        public FRM4OP()
        {
            InitializeComponent();
        }


        private void FRM4O_Load(object sender, EventArgs e)
        {
            salcodeSelection.SetControl(button1, AnnualLeaveCashRepo.GetSalcode(), "_SALCODE");
            salcodeSelection.SelectedValues = AnnualLeaveCashRepo.GetAbsPayList();
            hcodeSelection.SetControl(button2, AnnualLeaveCashRepo.GetHcode(), "_HCODE");
            DateTime dd = DateTime.Today.AddMonths(-1);
            DateTime d1 = new DateTime(dd.Year, dd.Month, 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);
            txtBdate.Text = Sal.Function.GetDate(d1);
            txtEdate.Text = Sal.Function.GetDate(d2);
            textBoxOutBeginDate.Text = Sal.Function.GetDate(d1);
            textBoxOutEndDate.Text = Sal.Function.GetDate(d2);
            textBoxYYMM.Text = DateTime.Today.ToString("yyyyMM");
            textBoxSeq.Text = "2";
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            List<AnnualLeaveCashDto> Results = new List<AnnualLeaveCashDto>();
            List<string> RpData = new List<string>();
            //離職結算
            {
                var data = AnnualOutList.Where(p => empOutSelection.SelectedValues.Contains(p.EmployeeID)).ToList();
                RpData = data.Where(p => !string.IsNullOrEmpty(p.Guid)).Select(p => p.Guid).ToList();
                var rp = new AnnualLeaveCashRepo();
                var salaryData = rp.GetSalaryStructure(empOutSelection.SelectedValues, salcodeSelection.SelectedValues, Convert.ToDateTime(txtEdate.Text));
                foreach (var it in data)
                {
                    decimal amt = 0;
                    var salaryOfEmp = salaryData.Where(p => p.EmployeeID == it.EmployeeID);
                    if (salaryOfEmp.Any())
                    {
                        amt = salaryOfEmp.Sum(p => p.Amount);
                    }
                    it.Salary = amt;
                    if (it.Unit == "小時")
                        it.CashOut = Math.Round(amt * it.Balance / 240, MidpointRounding.AwayFromZero);
                    else it.CashOut = Math.Round(amt * it.Balance / 30, MidpointRounding.AwayFromZero);
                    it.YYMM = textBoxYYMM.Text;
                    it.SEQ = textBoxSeq.Text;
                }
                Results.AddRange(data);
            }
            {
                var data = AnnualList.Where(p => empSelection.SelectedValues.Contains(p.EmployeeID) && !RpData.Contains(p.Guid)).ToList();
                var rp = new AnnualLeaveCashRepo();
                var salaryData = rp.GetSalaryStructure(empSelection.SelectedValues, salcodeSelection.SelectedValues, Convert.ToDateTime(txtEdate.Text));
                foreach (var it in data)
                {
                    decimal amt = 0;
                    var salaryOfEmp = salaryData.Where(p => p.EmployeeID == it.EmployeeID);
                    if (salaryOfEmp.Any())
                    {
                        amt = salaryOfEmp.Sum(p => p.Amount);
                    }
                    it.Salary = amt;
                    if (it.Unit == "小時")
                        it.CashOut = Math.Round(amt * it.Balance / 240, MidpointRounding.AwayFromZero);
                    else it.CashOut = Math.Round(amt * it.Balance / 30, MidpointRounding.AwayFromZero);
                    it.YYMM = textBoxYYMM.Text;
                    it.SEQ = textBoxSeq.Text;
                }
                Results.AddRange(data);
            }
            CombinationData = Results.Where(p => hcodeSelection.SelectedValues.Contains(p.HoliCode)).CopyToDataTable();
        }

        private void txtBdate_Validated(object sender, EventArgs e)
        {
            DateTime dd = Convert.ToDateTime(txtBdate.Text);
            txtEdate.Text = Sal.Function.GetDate(dd.AddMonths(1).AddDays(-1));
        }
        void UpdateEmpList()
        {
            AnnualLeaveCashRepo rp = new AnnualLeaveCashRepo();
            DateTime OutD1, OutD2;
            OutD1 = Convert.ToDateTime(textBoxOutBeginDate.Text);
            OutD2 = Convert.ToDateTime(textBoxOutEndDate.Text);
            AnnualOutList = rp.GetAnnualLeaveOutCashList(OutD1, OutD2);
            AnnualList = rp.GetAnnualLeaveCashList(Convert.ToDateTime(txtBdate.Text), Convert.ToDateTime(txtEdate.Text));
            //var AnnualListExceptOut = AnnualList.Where(p => !AnnualOutList.Select(pp => pp.EmployeeID).Contains(p.EmployeeID)).ToList();
            //AnnualList = AnnualListExceptOut;
            empOutSelection.SetControl(buttonEmpOut, AnnualLeaveCashRepo.GetEmpOutAllWithDept(AnnualOutList.Select(p => p.EmployeeID).Distinct().ToList(), OutD1, OutD2), "員工編號");
            empSelection.SetControl(buttonEmp, AnnualLeaveCashRepo.GetEmpAllWithDept(AnnualList.Select(p => p.EmployeeID).Distinct().ToList()), "員工編號");
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            UpdateEmpList();
        }

        private void textBoxOutBeginDate_Validated(object sender, EventArgs e)
        {
            DateTime dd = Convert.ToDateTime(textBoxOutBeginDate.Text);
            textBoxOutEndDate.Text = Sal.Function.GetDate(dd.AddMonths(1).AddDays(-1));
        }
    }
    public class AnnualLeaveCashOutTransfer : JBControls.PatchTransfer
    {
        public JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4O", MainForm.COMPANY);
        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            throw new NotImplementedException();
        }

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            try
            {
                JBModule.Data.Repo.AbsRepo absRp = new JBModule.Data.Repo.AbsRepo();
                var absTaken = new JBHRIS.BLL.Dto.AbsTakenDto();
                string CashType = TransferRow["CashType"].ToString();
                if (CashType == "離職結算")
                {
                    if (TransferRow["DateOut"].ToString().Trim().Length > 0)
                        absTaken.AttendDate = Convert.ToDateTime(TransferRow["DateOut"]);
                    else
                        absTaken.AttendDate = Convert.ToDateTime(TransferRow["DateStop"]);
                }
                else 
                    absTaken.AttendDate = Convert.ToDateTime(TransferRow["DateEnd"]);
                absTaken.BeginTime = absTaken.AttendDate;
                absTaken.CreateMan = MainForm.USER_NAME;
                absTaken.EmployeeID = TransferRow["EmployeeID"].ToString();
                absTaken.EndTime = absTaken.AttendDate;
                absTaken.Guid = Guid.NewGuid().ToString();
                absTaken.Hcode = AppConfig.GetConfig("CashoutHoliCode").GetString();
                absTaken.Remark = "";
                absTaken.Serno = "";
                absTaken.Taken = Convert.ToDecimal(TransferRow["Balance"]);
                absTaken.YYMM = "";
                if (!absRp.InsertAbs(absTaken, out ErrorMsg))
                    return false;
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                JBModule.Data.Linq.ENRICH rEnrich = new JBModule.Data.Linq.ENRICH();
                decimal Amt = Convert.ToDecimal(TransferRow["CashOut"]);
                rEnrich.AMT = JBModule.Data.CEncrypt.Number(Amt);
                rEnrich.FA_IDNO = "";
                rEnrich.IMPORT = true;
                rEnrich.KEY_DATE = DateTime.Now;
                rEnrich.KEY_MAN = MainForm.USER_NAME;
                rEnrich.MEMO = "";
                rEnrich.NOBR = TransferRow["EmployeeID"].ToString();
                rEnrich.SAL_CODE = AppConfig.GetConfig("CashOutSalCode").GetString();
                rEnrich.YYMM = TransferRow["YYMM"].ToString();
                rEnrich.SEQ = TransferRow["SEQ"].ToString();
                db.ENRICH.InsertOnSubmit(rEnrich);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
        }
    }

    public class AnnualLeaveCashRepo
    {
        public static DataTable GetEmpAllWithDept(List<string> EmpList)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.DEPT on b.DEPT equals c.D_NO
                      //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                      join e in db.MTCODE on b.TTSCODE equals e.CODE
                      let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
                      where DateTime.Today.AddYears(1) >= b.ADATE && DateTime.Today.AddYears(1) <= b.DDATE.Value
                      && e.CATEGORY == "TTSCODE"
                      && EmpList.Contains(a.NOBR)
                      && !b.NOSPEC
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      orderby a.NOBR
                      orderby JobState
                      select new { 員工編號 = a.NOBR, 員工姓名 = a.NAME_C, 在離職 = JobState, 部門代碼 = c.D_NO_DISP, 部門名稱 = c.D_NAME };
            return sql.CopyToDataTable();

        }
        public static DataTable GetEmpOutAllWithDept(List<string> EmpList, DateTime OutBeginDate, DateTime OutEndDate)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            //var sql = from a in db.BASE
            //          join b in db.BASETTS on a.NOBR equals b.NOBR
            //          join c in db.DEPT on b.DEPT equals c.D_NO
            //          join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
            //          join e in db.MTCODE on b.TTSCODE equals e.CODE
            //          let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
            //          where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
            //          && e.CATEGORY == "TTSCODE"
            //          && EmpList.Contains(a.NOBR)
            //          && !b.NOSPEC
            //          && b.OUDT != null && b.OUDT.Value >= OutBeginDate && b.OUDT.Value <= OutEndDate
            //          orderby a.NOBR
            //          orderby JobState
            //          select new { 員工編號 = a.NOBR, 員工姓名 = a.NAME_C, 在離職 = JobState, 離職日期 = b.OUDT, 部門代碼 = c.D_NO_DISP, 部門名稱 = c.D_NAME };
            //return sql.CopyToDataTable();
            var sql2 = from a in db.BASE
                       join b in db.BASETTS on a.NOBR equals b.NOBR
                       join c in db.DEPT on b.DEPT equals c.D_NO
                       //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                       join e in db.MTCODE on b.TTSCODE equals e.CODE
                       let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
                       where DateTime.Today.AddYears(1) >= b.ADATE && DateTime.Today.AddYears(1) <= b.DDATE.Value
                       && e.CATEGORY == "TTSCODE"
                       && ((b.OUDT != null && b.OUDT >= OutBeginDate && b.OUDT <= OutEndDate) 
                       || (b.STDT != null && b.STDT >= OutBeginDate && b.STDT <= OutEndDate)
                       || (b.STOUDT != null && b.STOUDT >= OutBeginDate && b.STOUDT <= OutEndDate))
                       && EmpList.Contains(a.NOBR)
                       && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                       orderby a.NOBR
                       orderby JobState
                       select new
                       {
                           員工編號 = a.NOBR,
                           員工姓名 = a.NAME_C,
                           //在離職 = JobState,
                           部門代碼 = c.D_NO_DISP,
                           部門名稱 = c.D_NAME,
                           離職日期 = b.OUDT,
                           留職停薪日 = b.STDT,
                           停薪離職日 = b.STOUDT
                       };
            return sql2.CopyToDataTable();
        }
        public static DataTable GetHcode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            JBModule.Data.ApplicationConfigSettings appconfig = new JBModule.Data.ApplicationConfigSettings("FRM4O", MainForm.COMPANY);

            var sql = from a in db.HCODE
                      where a.HTYPE == appconfig.GetConfig("AnnualLeaveTypeCode").GetString("1") && a.FLAG == "+"
                      orderby a.H_CODE_DISP
                      //orderby a.SORT
                      select new { _HCODE = a.H_CODE.Trim(), 假別代碼 = a.H_CODE_DISP.Trim(), 假別名稱 = a.H_NAME.Trim() };
            return sql.CopyToDataTable();
        }
        public static DataTable GetSalcode()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SALCODE
                      join b in db.SALATTR on a.SAL_ATTR equals b.SALATTR1
                      where b.BASIC && b.FLAG != "-"
                      && db.GetCodeFilter("SALCODE", a.SAL_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby a.SAL_CODE_DISP
                      //orderby a.SORT
                      select new { _SALCODE = a.SAL_CODE, 薪資代碼 = a.SAL_CODE_DISP, 薪資名稱 = a.SAL_NAME };
            return sql.CopyToDataTable();
        }
        public static List<string> GetAbsPayList()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SALCODE
                      join b in db.SALATTR on a.SAL_ATTR equals b.SALATTR1
                      where b.BASIC && b.FLAG != "-"
                      && db.GetCodeFilter("SALCODE", a.SAL_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && a.ABSPAY
                      orderby a.SAL_CODE_DISP
                      //orderby a.SORT
                      select a.SAL_CODE;
            return sql.ToList();
        }
        public List<AnnualLeaveCashDto> GetAnnualLeaveCashList(DateTime DateBegin, DateTime DateEnd)
        {
            List<AnnualLeaveCashDto> results = new List<AnnualLeaveCashDto>();
            JBModule.Data.ApplicationConfigSettings appconfig = new JBModule.Data.ApplicationConfigSettings("FRM4O", MainForm.COMPANY);
            var db = new JBModule.Data.Linq.HrDBDataContext();
            //區間內失效
            var sql = from a in db.ABS
                      join b in db.HCODE on a.H_CODE equals b.H_CODE
                      join c in db.HcodeType on b.HTYPE equals c.HTYPE
                      join d in db.BASE on a.NOBR equals d.NOBR
                      join b1 in db.BASETTS on a.NOBR equals b1.NOBR
                      where c.HTYPE == appconfig.GetConfig("AnnualLeaveTypeCode").GetString("1") && b.FLAG == "+"
                      && a.EDATE >= DateBegin && a.EDATE <= DateEnd
                      && a.EDATE >= b1.ADATE && a.EDATE <= b1.DDATE.Value
                      && new string[] { "1", "4", "6" }.Contains(b1.TTSCODE)
                      select new AnnualLeaveCashDto
                      {
                          CashType = "年度終結",
                          EmployeeID = a.NOBR,
                          DateBegin = a.BDATE,
                          DateEnd = a.EDATE,
                          Entitle = a.TOL_HOURS,
                          Taken = a.LeaveHours.Value,
                          Balance = a.Balance.Value,
                          Guid = a.Guid,
                          EmployeeName = d.NAME_C,
                          Unit = b.UNIT,
                          HoliName = b.H_NAME,
                          HoliCode = b.H_CODE,
                      };
            foreach (var it in sql)
            {
                if (results.Where(p => p.Guid == it.Guid).Any())
                    continue;
                results.Add(it);
            }
            //var sql1 = from a in db.ABS
            //           join b in db.HCODE on a.H_CODE equals b.H_CODE
            //           join c in db.HcodeType on b.HTYPE equals c.HTYPE
            //           join f in db.BASETTS on a.NOBR equals f.NOBR
            //           join d in db.BASE on a.NOBR equals d.NOBR
            //           where c.HTYPE == "1" && b.FLAG == "+"
            //           && f.OUDT != null && f.OUDT.Value >= DateBegin && f.OUDT.Value <= DateEnd
            //           && f.OUDT.Value >= a.BDATE && f.OUDT.Value <= a.EDATE
            //           select new AnnualLeaveCashDto
            //           {
            //               CashType = "離職結算",
            //               EmployeeID = a.NOBR,
            //               DateBegin = a.BDATE,
            //               DateEnd = a.EDATE,
            //               Entitle = a.TOL_HOURS,
            //               Taken = a.LeaveHours.Value,
            //               Balance = a.Balance.Value,
            //               Guid = a.Guid,
            //               EmployeeName = d.NAME_C,
            //           };
            //foreach (var it in sql1)
            //{
            //    if (results.Where(p => p.Guid == it.Guid).Any())
            //        continue;
            //    results.Add(it);
            //}
            return results;
        }
        public List<AnnualLeaveCashDto> GetAnnualLeaveOutCashList(DateTime DateBegin, DateTime DateEnd)
        {
            List<AnnualLeaveCashDto> results = new List<AnnualLeaveCashDto>();
            var db = new JBModule.Data.Linq.HrDBDataContext();
            //區間內失效
            //var sql = from a in db.ABS
            //          join b in db.HCODE on a.H_CODE equals b.H_CODE
            //          join c in db.HcodeType on b.HTYPE equals c.HTYPE
            //          join d in db.BASE on a.NOBR equals d.NOBR
            //          where c.HTYPE == "1" && b.FLAG == "+"
            //          && a.EDATE >= DateBegin && a.EDATE <= DateEnd
            //          select new AnnualLeaveCashDto
            //          {
            //              CashType = "年度終結",
            //              EmployeeID = a.NOBR,
            //              DateBegin = a.BDATE,
            //              DateEnd = a.EDATE,
            //              Entitle = a.TOL_HOURS,
            //              Taken = a.LeaveHours.Value,
            //              Balance = a.Balance.Value,
            //              Guid = a.Guid,
            //              EmployeeName = d.NAME_C,
            //          };
            //foreach (var it in sql)
            //{
            //    if (results.Where(p => p.Guid == it.Guid).Any())
            //        continue;
            //    results.Add(it);
            //}
            JBModule.Data.ApplicationConfigSettings appconfig = new JBModule.Data.ApplicationConfigSettings("FRM4O", MainForm.COMPANY);
            var sql1 = from a in db.ABS
                       join b in db.HCODE on a.H_CODE equals b.H_CODE
                       join c in db.HcodeType on b.HTYPE equals c.HTYPE
                       join f in db.BASETTS on a.NOBR equals f.NOBR
                       join d in db.BASE on a.NOBR equals d.NOBR
                       where c.HTYPE == appconfig.GetConfig("AnnualLeaveTypeCode").GetString("1") && b.FLAG == "+"
                       && ((f.OUDT != null && f.OUDT.Value >= DateBegin && f.OUDT.Value <= DateEnd)
                       || (f.STDT != null && f.STDT.Value >= DateBegin && f.STDT.Value <= DateEnd)
                       || (f.STOUDT != null && f.STOUDT.Value >= DateBegin && f.STOUDT.Value <= DateEnd)
                        && DateEnd.AddYears(1) >= f.ADATE && DateEnd.AddYears(1) <= f.DDATE.Value)
                       && ((f.OUDT != null && f.OUDT.Value >= a.BDATE && f.OUDT.Value <= a.EDATE)
                       || (f.STDT != null && f.STDT.Value >= a.BDATE && f.STDT.Value <= a.EDATE)
                       || (f.STOUDT != null && f.STOUDT.Value >= a.BDATE && f.STOUDT.Value <= a.EDATE))
                       select new AnnualLeaveCashDto
                       {
                           CashType = "離職結算",
                           EmployeeID = a.NOBR,
                           DateBegin = a.BDATE,
                           DateEnd = a.EDATE,
                           Entitle = a.TOL_HOURS,
                           Taken = a.LeaveHours.Value,
                           Balance = a.Balance.Value,
                           DateOut = f.OUDT,
                           DateStop = f.STDT,
                           Guid = a.Guid,
                           EmployeeName = d.NAME_C,
                           Unit = b.UNIT,
                           HoliName = b.H_NAME,
                           HoliCode = b.H_CODE,
                       };
            foreach (var it in sql1)
            {
                if (results.Where(p => p.Guid == it.Guid).Any())
                    continue;
                results.Add(it);
            }
            return results;
        }
        public List<SalaryStructure> GetSalaryStructure(List<string> EmpList, List<string> SalaryList, DateTime CheckDate)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = (from a in db.SALBASD
                       where EmpList.Contains(a.NOBR) && SalaryList.Contains(a.SAL_CODE) && CheckDate >= a.ADATE && CheckDate <= a.DDATE
                       select new SalaryStructure
                       {
                           Amount = JBModule.Data.CDecryp.Number(a.AMT),
                           EmployeeID = a.NOBR,
                           SalaryCode = a.SAL_CODE,
                           PayType = PayType.Month,
                       }).ToList();

            return sql.ToList();
        }
    }
    public class AnnualLeaveCashDto
    {
        public string CashType { get; set; }
        public string YYMM { get; set; }
        public string SEQ { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string HoliCode { get; set; }
        public string HoliName { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime? DateOut { get; set; }
        public DateTime? DateStop { get; set; }
        public decimal Entitle { get; set; }
        public decimal Taken { get; set; }
        public decimal Balance { get; set; }
        public string Unit { get; set; }
        public decimal Salary { get; set; }
        public decimal CashOut { get; set; }
        public string Guid { get; set; }
        public string ErrorMsg { get; set; }
    }
    public class SalaryStructure
    {
        public string EmployeeID { get; set; }
        public string SalaryCode { get; set; }
        public PayType PayType { get; set; }
        public decimal Amount { get; set; }
    }
    public enum PayType
    {
        Month = 1,
        Day = 2,
        Hour = 3
    }
}
