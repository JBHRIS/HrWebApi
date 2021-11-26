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
    public partial class FRM4PP : JBControls.U_CONDITION
    {
        JBControls.MultiSelectionDialog empOutSelection = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog empSelection = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog salcodeSelection = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog hcodeSelection = new JBControls.MultiSelectionDialog();
        List<CompensatoryLeaveCashDto> AnnualList = new List<CompensatoryLeaveCashDto>();
        List<CompensatoryLeaveCashDto> AnnualOutList = new List<CompensatoryLeaveCashDto>();
        public JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4P", MainForm.COMPANY);
        public FRM4PP()
        {
            InitializeComponent();
        }

        private void FRM4PP_Load(object sender, EventArgs e)
        {
            salcodeSelection.SetControl(button1, CompensatoryLeaveCashRepo.GetSalcode(), "_SALCODE");
            salcodeSelection.SelectedValues = CompensatoryLeaveCashRepo.GetAbsPayList();
            hcodeSelection.SetControl(button2, CompensatoryLeaveCashRepo.GetHcode(), "_HCODE");
            DateTime dd = DateTime.Today.AddMonths(-1);
            DateTime d1 = new DateTime(dd.Year, dd.Month, 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);
            txtBdate.Text = Sal.Function.GetDate(d1);
            txtEdate.Text = Sal.Function.GetDate(d2);
            textBoxOutBeginDate.Text = Sal.Function.GetDate(d1);
            textBoxOutEndDate.Text = Sal.Function.GetDate(d2);
            textBoxYYMM.Text = DateTime.Today.ToString("yyyyMM");
            textBoxSeq.Text = "2";
            textBoxRate.Text = "1";
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            bool AccumulationBase = AppConfig.GetConfig("AccumulationBase").GetString("True") == "True";
            List<CompensatoryLeaveCashDto> Results = new List<CompensatoryLeaveCashDto>();
            //離職結算
            {
                var data = AnnualOutList.Where(p => empOutSelection.SelectedValues.Contains(p.EmployeeID)).ToList();
                //if (!checkBoxFull.Checked)
                //    data = data.Where(p => p.Balance != 0).ToList();
                var rp = new CompensatoryLeaveCashRepo();
                string LastEmployeeID = string.Empty;
                DateTime LastDate = new DateTime();
                decimal LastTotalHours = 0;
                var db = new JBModule.Data.Linq.HrDBDataContext();
                var SqlOt = db.OT.Where(p => empOutSelection.SelectedValues.Contains(p.NOBR)).ToList();
                foreach (var it in data)
                {
                    decimal amt = 0;
                    it.Rate = 1;
                    var salaryData = rp.GetSalaryStructure(new List<string> { it.EmployeeID }, salcodeSelection.SelectedValues, it.DateBegin);
                    var salaryOfEmp = salaryData.Where(p => p.EmployeeID == it.EmployeeID);
                    if (salaryOfEmp.Any())
                    {
                        amt = salaryOfEmp.Sum(p => p.Amount);
                    }
                    Sal.Core.OvertTime.OverTime ov = new Core.OvertTime.OverTime(it.EmployeeID);
                    var att = rp.GetAttendDto(it.EmployeeID, it.DateBegin);
                    if (att != null)
                    {
                        it.Rote = att.Rote;
                        it.RoteName = att.RoteName;
                    }
                    decimal Rate = Convert.ToDecimal(textBoxRate.Text);

                    if (radioButton1.Checked)
                    {
                        if (LastEmployeeID == it.EmployeeID && LastDate != it.DateBegin)
                            LastTotalHours = 0;
                        else if (LastEmployeeID != it.EmployeeID)
                        {
                            LastTotalHours = 0;
                            LastEmployeeID = it.EmployeeID;
                        }

                        LastDate = it.DateBegin;

                        if (AccumulationBase)
                        {
                            decimal OTHrs = SqlOt.Where(p => p.NOBR == it.EmployeeID && p.BDATE == it.DateBegin && it.Etime.CompareTo(p.ETIME) >= 0).Sum(p => p.OT_HRS);
                            Rate = ov.GetOtRate(it.DateBegin, it.Rote, it.Balance, LastTotalHours + it.Taken + OTHrs);
                            LastTotalHours += it.Entitle;
                        }
                        else
                        {
                            Rate = ov.GetOtRate(it.DateBegin, it.Rote, it.Balance, LastTotalHours);
                            LastTotalHours += it.Balance;
                        }
                    }
                    else
                    {
                        Rate = it.Balance;
                    }

                    it.Rate = Rate;
                    it.Salary = amt;
                    if (it.Rate != 0)
                    {
                        if (it.Unit == "小時")
                            it.CashOut = Math.Round(amt * it.Rate / AppConfig.GetConfig("DivOfHour").GetDecimal(240M), MidpointRounding.AwayFromZero);
                        else it.CashOut = Math.Round(amt * it.Rate / AppConfig.GetConfig("DivOfDay").GetDecimal(30M), MidpointRounding.AwayFromZero);

                        it.Rate = it.Balance != 0 ? Math.Round(Rate / it.Balance, 2, MidpointRounding.AwayFromZero) : Math.Round(Rate, 2, MidpointRounding.AwayFromZero);
                    }

                    it.YYMM = textBoxYYMM.Text;
                    it.SEQ = textBoxSeq.Text;
                }
                Results.AddRange(data);
            }
            {
                string LastEmployeeID = string.Empty;
                DateTime LastDate = new DateTime();
                decimal LastTotalHours = 0;
                var data = AnnualList.Where(p => empSelection.SelectedValues.Contains(p.EmployeeID)).ToList();
                var rp = new CompensatoryLeaveCashRepo();
                var db = new JBModule.Data.Linq.HrDBDataContext();
                var SqlOt = db.OT.Where(p => empSelection.SelectedValues.Contains(p.NOBR)).ToList();
                //if (!checkBoxFull.Checked)
                //    data = data.Where(p => p.Balance != 0).ToList();
                foreach (var it in data)
                {
                    decimal amt = 0;
                    var salaryData = rp.GetSalaryStructure(new List<string> { it.EmployeeID }, salcodeSelection.SelectedValues, it.DateBegin);
                    var salaryOfEmp = salaryData.Where(p => p.EmployeeID == it.EmployeeID);
                    if (salaryOfEmp.Any())
                    {
                        amt = salaryOfEmp.Sum(p => p.Amount);
                    }
                    Sal.Core.OvertTime.OverTime ov = new Core.OvertTime.OverTime(it.EmployeeID);
                    var att = rp.GetAttendDto(it.EmployeeID, it.DateBegin);
                    if (att != null)
                    {
                        it.Rote = att.Rote;
                        it.RoteName = att.RoteName;
                    }
                    decimal Rate = Convert.ToDecimal(textBoxRate.Text);

                    if (radioButton1.Checked)
                    {
                        if (LastEmployeeID == it.EmployeeID && LastDate != it.DateBegin)
                            LastTotalHours = 0;
                        else if (LastEmployeeID != it.EmployeeID)
                        {
                            LastTotalHours = 0;
                            LastEmployeeID = it.EmployeeID;
                        }

                        LastDate = it.DateBegin;

                        if (AccumulationBase)
                        {
                            decimal OTHrs = SqlOt.Where(p => p.NOBR == it.EmployeeID && p.BDATE == it.DateBegin && it.Etime.CompareTo(p.ETIME) >= 0).Sum(p => p.OT_HRS);
                            Rate = ov.GetOtRate(it.DateBegin, it.Rote, it.Balance, LastTotalHours + it.Taken + OTHrs);
                            LastTotalHours += it.Entitle;
                        }
                        else
                        {
                            Rate = ov.GetOtRate(it.DateBegin, it.Rote, it.Balance, LastTotalHours);
                            LastTotalHours += it.Balance;
                        }
                    }
                    else
                    {
                        Rate = it.Balance;
                    }

                    it.Rate = Rate;
                    it.Salary = amt;
                    if (it.Rate != 0)
                    {
                        if (it.Unit == "小時")
                            it.CashOut = Math.Round(amt * it.Rate / AppConfig.GetConfig("DivOfHour").GetDecimal(240M), MidpointRounding.AwayFromZero);
                        else it.CashOut = Math.Round(amt * it.Rate / AppConfig.GetConfig("DivOfDay").GetDecimal(30M), MidpointRounding.AwayFromZero);

                        it.Rate = it.Balance != 0 ? Math.Round(Rate / it.Balance, 2, MidpointRounding.AwayFromZero) : Math.Round(Rate, 2, MidpointRounding.AwayFromZero);
                    }
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
            CompensatoryLeaveCashRepo rp = new CompensatoryLeaveCashRepo();
            DateTime OutD1, OutD2;
            OutD1 = Convert.ToDateTime(textBoxOutBeginDate.Text);
            OutD2 = Convert.ToDateTime(textBoxOutEndDate.Text);
            AnnualOutList = rp.GetAnnualLeaveOutCashList(OutD1, OutD2);
            AnnualList = rp.GetAnnualLeaveCashList(Convert.ToDateTime(txtBdate.Text), Convert.ToDateTime(txtEdate.Text));
            var AnnualListExceptOut = AnnualList.Where(p => !AnnualOutList.Select(pp => pp.EmployeeID).Contains(p.EmployeeID)).ToList();
            AnnualList = AnnualListExceptOut;
            empOutSelection.SetControl(buttonEmpOut, CompensatoryLeaveCashRepo.GetEmpOutAllWithDept(AnnualOutList.Select(p => p.EmployeeID).Distinct().ToList(), OutD1, OutD2), "員工編號");
            empSelection.SetControl(buttonEmp, CompensatoryLeaveCashRepo.GetEmpAllWithDept(AnnualListExceptOut.Select(p => p.EmployeeID).Distinct().ToList()), "員工編號");
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxRate.Enabled = radioButton2.Checked;
        }
    }
    public class CompensatoryLeaveCashOutTransfer : JBControls.PatchTransfer
    {
        public JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4P", MainForm.COMPANY);
        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            throw new NotImplementedException();
        }

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            try
            {
                ErrorMsg = "";
                JBModule.Data.Repo.AbsRepo absRp = new JBModule.Data.Repo.AbsRepo();
                var absTaken = new JBHRIS.BLL.Dto.AbsTakenDto();
                string CashType = TransferRow["CashType"].ToString();
                string BindingKey = TransferRow["BindingKey"].ToString();
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
                absTaken.Serno = TransferRow["Guid"].ToString();
                absTaken.Taken = Convert.ToDecimal(TransferRow["Balance"]);
                absTaken.YYMM = "";
                absTaken.Field01 = BindingKey;
                if (absTaken.Taken != 0 && !absRp.InsertAbs(absTaken, out ErrorMsg))//Skip 0
                    return false;
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                JBModule.Data.Linq.ENRICH rEnrich = new JBModule.Data.Linq.ENRICH();
                decimal Amt = Convert.ToDecimal(TransferRow["CashOut"]);
                if (Amt != 0)
                {
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
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
        }
    }

    public class CompensatoryLeaveCashRepo
    {
        public JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4P", MainForm.COMPANY);
        public static DataTable GetEmpAllWithDept(List<string> EmpList)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.DEPT on b.DEPT equals c.D_NO
                      //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
                      join e in db.MTCODE on b.TTSCODE equals e.CODE
                      let JobState = new string[] { "1", "4", "6" }.Contains(b.TTSCODE) ? "在職" : e.NAME
                      where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
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
                       && ((b.OUDT != null && b.OUDT >= OutBeginDate && b.OUDT <= OutEndDate) || (b.STDT != null && b.STDT >= OutBeginDate && b.STDT <= OutEndDate))
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
                           留職停薪日 = b.STDT
                       };
            return sql2.CopyToDataTable();
        }
        public static DataTable GetHcode()
        {
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4P", MainForm.COMPANY);
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HCODE
                      where a.HTYPE == AppConfig.GetConfig("LeaveTypeCode").GetString("2") && a.FLAG == "+"
                      orderby a.H_CODE_DISP
                      //orderby a.SORT
                      select new { _HCODE = a.H_CODE_DISP.Trim(), 假別代碼 = a.H_CODE_DISP.Trim(), 假別名稱 = a.H_NAME.Trim() };
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
        public List<CompensatoryLeaveCashDto> GetAnnualLeaveCashList(DateTime DateBegin, DateTime DateEnd)
        {
            List<CompensatoryLeaveCashDto> results = new List<CompensatoryLeaveCashDto>();
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var holDayList = db.HOL_DAY.ToList();
            var otRateList = db.OTRATECD.ToList();
            //區間內失效
            var sql = from a in db.ABS
                      join b in db.HCODE on a.H_CODE equals b.H_CODE
                      join c in db.HcodeType on b.HTYPE equals c.HTYPE
                      join d in db.BASE on a.NOBR equals d.NOBR
                      join f in db.BASETTS on a.NOBR equals f.NOBR
                      //join e in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals e.NOBR
                      where c.HTYPE == AppConfig.GetConfig("LeaveTypeCode").GetString("2") && b.FLAG == "+"
                      && a.EDATE >= DateBegin && a.EDATE <= DateEnd
                      && DateEnd.AddYears(1) >= f.ADATE && DateEnd.AddYears(1) <= f.DDATE.Value
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(f.SALADR)
                      select new CompensatoryLeaveCashDto
                      {
                          CashType = "年度終結",
                          EmployeeID = a.NOBR,
                          DateBegin = a.BDATE,
                          DateEnd = a.EDATE,
                          Btime = a.BTIME,
                          Etime = a.ETIME,
                          Entitle = a.TOL_HOURS,
                          Taken = a.LeaveHours.Value,
                          Balance = a.Balance.Value,
                          Guid = a.Guid,
                          EmployeeName = d.NAME_C,
                          Unit = b.UNIT,
                          HoliName = b.H_NAME,
                          HoliCode = b.H_CODE,
                          CalendarCode = f.HOLI_CODE,
                          BindingKey = a.Guid,
                      };
            foreach (var it in sql)
            {
                if (results.Where(p => p.Guid == it.Guid).Any())
                    continue;
                string Rote = it.RoteH;

                var holday = from a in holDayList where a.HOLI_CODE == it.CalendarCode && a.ROTE == Rote && a.ADATE == it.DateBegin select a;
                if (holday.Any())
                {
                    it.OtRateCode = holday.First().OTRATECD;
                }
                var otrate = otRateList.Where(p => p.OTRATE_CODE == it.OtRateCode);
                if (otrate.Any())
                {
                    //it.OtRateCode = otrate.First().OTRATE_CODE;
                    it.OtRateName = otrate.First().OTRATE_NAME;
                }
                var absExipre = from a in db.ABS
                                join b in db.ABSD on a.Guid equals b.ABSSUBTRACT
                                where b.ABSADD == it.Guid && a.H_CODE == AppConfig.GetConfig("CashoutHoliCode").GetString()
                                select a;
                if (absExipre.Any()) continue;
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
        public List<CompensatoryLeaveCashDto> GetAnnualLeaveOutCashList(DateTime DateBegin, DateTime DateEnd)
        {
            List<CompensatoryLeaveCashDto> results = new List<CompensatoryLeaveCashDto>();
            var db = new JBModule.Data.Linq.HrDBDataContext();

            var holDayList = db.HOL_DAY.ToList();
            var otRateList = db.OTRATECD.ToList();
            var sql1 = from a in db.ABS
                       join b in db.HCODE on a.H_CODE equals b.H_CODE
                       join c in db.HcodeType on b.HTYPE equals c.HTYPE
                       join f in db.BASETTS on a.NOBR equals f.NOBR
                       join d in db.BASE on a.NOBR equals d.NOBR
                       join g in db.ATTEND on new { a.NOBR, ADATE = a.BDATE } equals new { g.NOBR, g.ADATE }
                       join r in db.ROTE on g.ROTE equals r.ROTE1
                       //join e in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals e.NOBR
                       let CheckDate = (f.OUDT!= null?f.OUDT : new DateTime(1753,1,1)) > (f.STDT != null ? f.STDT : new DateTime(1753, 1, 1)) ? f.OUDT : f.STDT
                       where c.HTYPE == AppConfig.GetConfig("LeaveTypeCode").GetString("2") && b.FLAG == "+"
                       //&& ((f.OUDT != null && f.OUDT.Value >= DateBegin && f.OUDT.Value <= DateEnd)
                       //|| (f.STDT != null && f.STDT.Value >= DateBegin && f.STDT.Value <= DateEnd)
                       && DateEnd.AddYears(1) >= f.ADATE && DateEnd.AddYears(1) <= f.DDATE.Value//)
                                                                                                //&& ((f.OUDT != null && f.OUDT.Value >= a.BDATE && f.OUDT.Value <= a.EDATE)
                                                                                                //|| (f.STDT != null && f.STDT.Value >= a.BDATE && f.STDT.Value <= a.EDATE))
                       && CheckDate >= DateBegin && CheckDate <= DateEnd
                       && CheckDate >= a.BDATE && CheckDate <= a.EDATE
                       && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(f.SALADR)
                       select new CompensatoryLeaveCashDto
                       {
                           CashType = "離職結算",
                           EmployeeID = a.NOBR,
                           DateBegin = a.BDATE,
                           DateEnd = a.EDATE,
                           Btime = a.BTIME,
                           Etime = a.ETIME,
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
                           Rote = g.ROTE,
                           RoteName = r.ROTENAME,
                           OtRateCode = f.CALOT,
                           OtRateName = "",
                           CalendarCode = f.HOLI_CODE,
                           BindingKey = a.Guid,
                       };
            foreach (var it in sql1)
            {
                if (results.Where(p => p.Guid == it.Guid).Any())
                    continue;
                string Rote = it.RoteH;

                var holday = from a in holDayList where a.HOLI_CODE == it.CalendarCode && a.ROTE == Rote && a.ADATE == it.DateBegin select a;
                if (holday.Any())
                {
                    it.OtRateCode = holday.First().OTRATECD;
                }
                var otrate = otRateList.Where(p => p.OTRATE_CODE == it.OtRateCode);
                if (otrate.Any())
                {
                    //it.OtRateCode = otrate.First().OTRATE_CODE;
                    it.OtRateName = otrate.First().OTRATE_NAME;
                }
                results.Add(it);
            }
            return results;
        }
        public List<SalaryStructureOfCompensatory> GetSalaryStructure(List<string> EmpList, List<string> SalaryList, DateTime CheckDate)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = (from a in db.SALBASD
                       where EmpList.Contains(a.NOBR) && SalaryList.Contains(a.SAL_CODE) && CheckDate >= a.ADATE && CheckDate <= a.DDATE
                       select new SalaryStructureOfCompensatory
                       {
                           Amount = JBModule.Data.CDecryp.Number(a.AMT),
                           EmployeeID = a.NOBR,
                           SalaryCode = a.SAL_CODE,
                           PayType = PayType.Month,
                       });//.ToList();

            return sql.ToList();
        }
        public Dto.AttendDto GetAttendDto(string EmployeeID, DateTime Date)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = (from a in db.ATTEND
                       join b in db.ROTE on a.ROTE equals b.ROTE1
                       where a.NOBR == EmployeeID && a.ADATE == Date
                       select new Dto.AttendDto { EmployeeID = a.NOBR, AttendDate = a.ADATE, Rote = a.ROTE, RoteName = b.ROTENAME });
            return sql.FirstOrDefault();
        }
    }
    public class CompensatoryLeaveCashDto
    {
        public string CashType { get; set; }
        public string YYMM { get; set; }
        public string SEQ { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string HoliCode { get; set; }
        public string HoliName { get; set; }
        public string Rote { get; set; }
        public string RoteH { get; set; }
        public string RoteName { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime? DateOut { get; set; }
        public DateTime? DateStop { get; set; }
        public string Btime { get; set; }
        public string Etime { get; set; }
        public decimal Entitle { get; set; }
        public decimal Taken { get; set; }
        public decimal Balance { get; set; }
        public string Unit { get; set; }
        public decimal Rate { get; set; }
        public string OtRateCode { get; set; }
        public string OtRateName { get; set; }
        public string CalendarCode { get; set; }
        public decimal Salary { get; set; }
        public decimal CashOut { get; set; }
        public string Guid { get; set; }
        public string ErrorMsg { get; set; }
        public string BindingKey { get; set; }
    }
    public class SalaryStructureOfCompensatory
    {
        public string EmployeeID { get; set; }
        public string SalaryCode { get; set; }
        public PayType PayType { get; set; }
        public decimal Amount { get; set; }
    }
    //public enum PayType
    //{
    //    Month = 1,
    //    Day = 2,
    //    Hour = 3
    //}
}
