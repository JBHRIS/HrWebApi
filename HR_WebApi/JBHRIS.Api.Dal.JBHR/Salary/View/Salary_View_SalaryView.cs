using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dal.Salary.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Salary.Entry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.Salary.View;
using Microsoft.Extensions.Configuration;

namespace JBHRIS.Api.Dal.JBHR.Salary.View
{
    public class Salary_View_SalaryView : ISalary_View_SalaryView
    {
        private IConfiguration _configuration;
        private IUnitOfWork _unitOfWork;
        private int iYear = 0;
        private int iMonth = 0;

        public Salary_View_SalaryView(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        private Salary_View_SalaryView(DateTime date, int AttEndDay)
        {
            if (date.Day > AttEndDay) date = date.AddMonths(1);
            iYear = date.Year;
            iMonth = date.Month;
        }

        private Salary_View_SalaryView(string yymm)
        {
            //MEMO: 2010/04/30 修改成公元年
            string sYear = yymm.Substring(0, 4);//2010/04/30 yymm.Substring(0, 3)改成抓公元年
            string sMonth = yymm.Substring(4, 2);//yymm.Substring(3, 2)
            iYear = int.Parse(sYear);//int.Parse(sYear) + 1911;
            iMonth = int.Parse(sMonth);
        }


        public string GetUnLockYYMM(DateTime date, string Saladr, int AttEndDay)
        {
            var db = _unitOfWork.Repository<DataPa>().Reads();
            var sql = from a in db where a.DataPass >= date && a.Saladr == Saladr select a;
            var rr = sql.ToList();
            var gg = from a in sql.ToList() orderby a.DataPass select new Salary_View_SalaryView(a.DataPass, AttEndDay).YYMM;
            var orderList = gg.Distinct();
            Salary_View_SalaryView sd = new Salary_View_SalaryView(date, AttEndDay);
            //sd = sd.GetNextSalaryDate();
            while (orderList.Contains(sd.YYMM))//如果列表中有这笔计薪年月，就在往下个月
                sd = sd.GetNextSalaryDate();
            return sd.YYMM;
        }

        public bool IsLockedYYMM(DateTime date, string Saladr, int AttEndDay)
        {
            var db = _unitOfWork.Repository<DataPa>().Reads();
            var sql = from a in db where a.DataPass >= date && a.Saladr == Saladr select a;
            var gg = from a in sql.ToList() orderby a.DataPass select new Salary_View_SalaryView(a.DataPass, AttEndDay).YYMM;
            var orderList = gg.Distinct();
            Salary_View_SalaryView sd = new Salary_View_SalaryView(date, AttEndDay);
            //sd = sd.GetNextSalaryDate();
            while (orderList.Contains(sd.YYMM))//如果列表中有这笔计薪年月，就在往下个月
                return true;
            return false;
        }

        public bool CheckAttendLock(DateTime date, string Saladr)
        {
            var db = _unitOfWork.Repository<DataPa>().Reads();
            var sql = from a in db where a.DataPass == date && a.Saladr == Saladr select a;
            return sql.Any();
        }

        private Salary_View_SalaryView GetNextSalaryDate()
        {
            DateTime date = this.FirstDayOfMonth;
            date = date.AddMonths(1);
            Salary_View_SalaryView pd = new Salary_View_SalaryView(date.ToString("yyyyMM"));
            return pd;
        }

        public List<GetSalaryWageLockDto> GetSalaryWageLock(string Nobr)
        {
            var sql = from w in _unitOfWork.Repository<Wage>().Reads()
                      join lk in _unitOfWork.Repository<LockWage>().Reads() on new { w.Yymm, w.Seq, w.Saladr } equals new { lk.Yymm, lk.Seq, lk.Saladr }
                      where DateTime.Now.Date >= w.Adate && DateTime.Now.AddYears(-1).Date <= w.Adate
                      && w.Nobr == Nobr
                      select new GetSalaryWageLockDto
                      {
                          EmployeeID = w.Nobr,
                          YYMM = lk.Yymm,
                          Seq = lk.Seq,
                          Saladr = lk.Saladr,
                          Meno = lk.Meno
                      };
            return sql.ToList();
        }
        public List<GetSalaryWageLockDto> GetSalaryWageLockByEmpList(List<string> EmpList)
        {
            var sql = from w in _unitOfWork.Repository<Wage>().Reads()
                      join lk in _unitOfWork.Repository<LockWage>().Reads() on new { w.Yymm, w.Seq, w.Saladr } equals new { lk.Yymm, lk.Seq, lk.Saladr }
                      where  EmpList.Contains(w.Nobr)
                      select new GetSalaryWageLockDto
                      {
                          EmployeeID = w.Nobr,
                          YYMM = lk.Yymm,
                          Seq = lk.Seq,
                          Saladr = lk.Saladr,
                          Meno = lk.Meno
                      };
            return sql.ToList();
        }


        public ApiResult<string> CheckSalaryPassWord(string Nobr, string Password)
        {
            ApiResult<string> apiResult = new ApiResult<string>();

            apiResult.State = false;
            try
            {
                var data = (from c in _unitOfWork.Repository<Salpw>().Reads()
                            where c.Nobr == Nobr && c.Pw == Password
                            select c).FirstOrDefault();
                if (data != null)
                {
                    apiResult.State = true;
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        public ApiResult<string> SetSalaryPassWord(string Nobr, string Password)
        {
            ApiResult<string> apiResult = new ApiResult<string>();

            var data = (from c in _unitOfWork.Repository<Salpw>().Reads()
                        where c.Nobr == Nobr
                        select c).FirstOrDefault();
            apiResult.State = false;
            try
            {
                if (data != null)
                {
                    apiResult.Message = "薪資密碼已存在";
                }
                else
                {
                    var Repo = _unitOfWork.Repository<Salpw>();
                    data = new Salpw()
                    {
                        Nobr = Nobr,
                        Pw = Password,
                        KeyDate = DateTime.Now
                    };
                    Repo.Create(data);
                    Repo.SaveChanges();
                    apiResult.State = true;
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;

        }

        public ApiResult<string> DeleteSalaryPassWord(string Nobr)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;

            var data = (from c in _unitOfWork.Repository<Salpw>().Reads()
                        where c.Nobr == Nobr
                        select c).FirstOrDefault();

            if (data == null)
            {
                apiResult.Message = "薪资密码未设定";
            }
            else
            {
                var Repo = _unitOfWork.Repository<Salpw>();
                var SalpwData = _unitOfWork.Repository<Salpw>().Reads().SingleOrDefault(x => x.Nobr == Nobr);
                if (SalpwData != null)
                {
                    Repo.Delete(SalpwData);
                    Repo.SaveChanges();
                    apiResult.State = true;
                }
            }
            return apiResult;
        }

        public IQueryable<GetPayslipTitleDto> GetPayslipTitle(string Nobr, string YYMM, string Seq)
        {
            var sql = from w in _unitOfWork.Repository<Wage>().Reads()
                      where w.Nobr == Nobr && w.Yymm == YYMM && w.Seq == Seq
                      select new GetPayslipTitleDto
                      {
                          Adate = w.Adate,
                          DateB = w.DateB,
                          DateE = w.DateE,
                          AttDateB = w.AttDateb,
                          AttDateE = w.AttDatee,
                          SalDateB = w.DateB,
                          SalDateE = w.DateE,
                          Note = w.Note
                      };
            return sql;
        }

        public IQueryable<GetSalaryDto> GetSalary(string Nobr, string YYMM, string Seq)
        {
            var sql = from w in _unitOfWork.Repository<Wage>().Reads()
                      join wd in _unitOfWork.Repository<Waged>().Reads() on new { w.Yymm, w.Nobr, w.Seq } equals new { wd.Yymm, wd.Nobr, wd.Seq }
                      join sc in _unitOfWork.Repository<Salcode>().Reads() on wd.SalCode equals sc.SalCode1
                      join st in _unitOfWork.Repository<Salattr>().Reads() on sc.SalAttr equals st.Salattr1
                      join lk in _unitOfWork.Repository<LockWage>().Reads() on new { w.Yymm, w.Seq, w.Saladr } equals new { lk.Yymm, lk.Seq, lk.Saladr }
                      where w.Nobr == Nobr && w.Yymm == YYMM && wd.Seq == Seq
                      orderby sc.SalCodeDisp ascending
                      select new GetSalaryDto
                      {
                          Nobr = wd.Nobr,
                          Yymm = wd.Yymm,
                          Seq = wd.Seq,
                          Amt = wd.Amt,
                          SalCode = wd.SalCode,
                          SalName = sc.SalName,
                          SalAttr = st.Salattr1,
                          AttrName = st.AttrName,
                          Sort = sc.Sort,
                          Flag = st.Flag,
                          Type = st.Type,
                          Tax = st.Tax,
                          Adate = w.Adate,
                          AttDateB = w.AttDateb,
                          AttDateE = w.AttDatee,
                          SalDateB = w.DateB,
                          SalDateE = w.DateE,
                          Note = w.Note
                      };
            return sql;
        }

        public IQueryable<GetRetirementDto> GetRetirement(string Nobr, string YYMM)
        {
            var sql = from exp in _unitOfWork.Repository<Explab>().Reads()
                      where exp.Nobr == Nobr && exp.InsurType == "4" && exp.Yymm == YYMM
                      select new GetRetirementDto
                      {
                          Comp = exp.Comp,
                          Exp = exp.Exp
                      };
            return sql;
        }

        public IQueryable<GetAbsDto> GetAbs(string Nobr, string YYMM)
        {
            var sql = from a in _unitOfWork.Repository<Abs>().Reads()
                      join h in _unitOfWork.Repository<Hcode>().Reads() on a.HCode equals h.HCode1
                      join htype in _unitOfWork.Repository<HcodeType>().Reads() on h.Htype equals htype.Htype
                      where a.Nobr == Nobr && a.Yymm == YYMM
                      select new GetAbsDto
                      {
                          HCode = h.HCode1,
                          HName = h.HName,
                          HCodeUnit = h.Unit,
                          TolHours = (decimal)a.TolHours,
                          Balance = (decimal)a.Balance,
                          Htype = htype.Htype,
                          HtypeUnit = htype.Unit,
                          Mang = h.Mang,
                          Flag = h.Flag
                      };
            return sql;
        }

        public IQueryable<GetOtDto> GetOt(string Nobr, string YYMM)
        {
            var sql = from o in _unitOfWork.Repository<Ot>().Reads()
                      where o.Nobr == Nobr && o.Yymm == YYMM
                      select new GetOtDto
                      {
                          Nobr = o.Nobr,
                          BDate = o.Bdate,
                          BTime = o.Btime,
                          ETime = o.Etime,
                          YYMM = o.Yymm,
                          Rest_HRS = o.RestHrs,
                          Ot_HOURS = o.OtHrs,
                          TOT_HOURS = o.TotHours,
                          NOT_H_133 = o.NotH133,
                          TOT_W_133 = o.TotW133,
                          NOP_H_133 = o.NopH133,
                          NOT_H_167 = o.NotH167,
                          TOT_W_167 = o.TotW167,
                          NOP_H_167 = o.NopH167,
                          NOT_H_200 = o.NotH200,
                          TOT_W_200 = o.TotW200,
                          NOP_H_200 = o.NopH200,
                          NOT_W_133 = o.NotW133,
                          NOP_W_133 = o.NopW133,
                          NOT_W_167 = o.NotW167,
                          NOP_W_167 = o.NopW167,
                          NOT_W_200 = o.NotW200,
                          NOP_W_200 = o.NopW200
                      };
            return sql;
        }

        public decimal GetAnnualLeave(string Nobr, DateTime dateTime)
        {
            //SELECT Value FROM AppConfig WHERE Category = 'FRM4O' AND code = 'AnnualLeaveTypeCode' AND COMP = 'A'--公司別
            string Comp = (from btts in _unitOfWork.Repository<Basetts>().Reads()
                           where btts.Nobr == Nobr &&
                           (btts.Ddate >= DateTime.Now && btts.Adate <= DateTime.Now) &&
                           new string[] { "1", "4", "6" }.Contains(btts.Ttscode)
                           select btts).FirstOrDefault().Comp;

            string Htype = (from ac in _unitOfWork.Repository<AppConfig>().Reads()
                            where ac.Category == "FRM4O" && ac.Code == "AnnualLeaveTypeCode" && ac.Comp == Comp
                            select ac).FirstOrDefault().Value;

            var sql = from a in _unitOfWork.Repository<Abs>().Reads()
                      join btts in _unitOfWork.Repository<Basetts>().Reads() on a.Nobr equals btts.Nobr
                      join h in _unitOfWork.Repository<Hcode>().Reads() on a.HCode equals h.HCode1
                      where a.Nobr == Nobr &&
                      (a.Edate >= dateTime.Date && dateTime.Date >= a.Bdate) &&
                      h.Htype == Htype &&
                      h.Flag == "+" &&
                      (btts.Ddate >= DateTime.Now && btts.Adate <= DateTime.Now) &&
                      new string[] { "1", "4", "6" }.Contains(btts.Ttscode)
                      select new { Balance = a.Balance, Unit = h.Unit };

            decimal sunHourBalance = 0;
            foreach (var a in sql.ToList())
            {
                if (_configuration.Get<ConfigurationDto>().HcodeUnitString.Day.Contains(a.Unit))
                {
                    sunHourBalance += (decimal)a.Balance * 8;
                }
                else if (_configuration.Get<ConfigurationDto>().HcodeUnitString.Hour.Contains(a.Unit))
                {
                    sunHourBalance += (decimal)a.Balance;
                }
                else if (_configuration.Get<ConfigurationDto>().HcodeUnitString.Minute.Contains(a.Unit))
                {
                    sunHourBalance += (decimal)a.Balance / 60;
                }
            }

            return sunHourBalance;
        }

        public decimal GetCompensatoryLeave(string Nobr, DateTime dateTime)
        {
            //SELECT Value FROM AppConfig WHERE Category = 'FRM4P' AND code = 'LeaveTypeCode' AND COMP = 'A'--公司別
            string Comp = (from btts in _unitOfWork.Repository<Basetts>().Reads()
                           where btts.Nobr == Nobr &&
                           (btts.Ddate >= DateTime.Now && btts.Adate <= DateTime.Now) &&
                           new string[] { "1", "4", "6" }.Contains(btts.Ttscode)
                           select btts).FirstOrDefault().Comp;

            string Htype = (from ac in _unitOfWork.Repository<AppConfig>().Reads()
                            where ac.Category == "FRM4P" && ac.Code == "LeaveTypeCode" && ac.Comp == Comp
                            select ac).FirstOrDefault().Value;

            var sql = from a in _unitOfWork.Repository<Abs>().Reads()
                      join btts in _unitOfWork.Repository<Basetts>().Reads() on a.Nobr equals btts.Nobr
                      join h in _unitOfWork.Repository<Hcode>().Reads() on a.HCode equals h.HCode1
                      where a.Nobr == Nobr &&
                      (a.Edate >= dateTime.Date && dateTime.Date >= a.Bdate) &&
                      h.Htype == Htype &&
                      h.Flag == "+" &&
                      (btts.Ddate >= DateTime.Now && btts.Adate <= DateTime.Now) &&
                      new string[] { "1", "4", "6" }.Contains(btts.Ttscode)
                      select new { Balance = a.Balance, Unit = h.Unit };

            decimal sunHourBalance = 0;
            foreach (var a in sql.ToList())
            {
                if (_configuration.Get<ConfigurationDto>().HcodeUnitString.Day.Contains(a.Unit))
                {
                    sunHourBalance += (decimal)a.Balance * 8;
                }
                else if (_configuration.Get<ConfigurationDto>().HcodeUnitString.Hour.Contains(a.Unit))
                {
                    sunHourBalance += (decimal)a.Balance;
                }
                else if (_configuration.Get<ConfigurationDto>().HcodeUnitString.Minute.Contains(a.Unit))
                {
                    sunHourBalance += (decimal)a.Balance / 60;
                }
            }

            return sunHourBalance;
        }

        public List<DateTime> GetDataPassList(string Nobr, DateTime beginDate, DateTime endDate)
        {
            List<DateTime> dList = (from btts in _unitOfWork.Repository<Basetts>().Reads()
                                    join dpa in _unitOfWork.Repository<DataPa>().Reads() on btts.Saladr equals dpa.Saladr
                                    where btts.Nobr == Nobr &&
                                    (btts.Ddate >= DateTime.Now && btts.Adate <= DateTime.Now) &&
                                    (dpa.DataPass >= beginDate && dpa.DataPass <= endDate)
                                    select dpa).Select(p => p.DataPass).ToList();
            
            return dList;
        }

        public List<GetSalaryCodeDto> GetSalaryCode()
        {
            var dList = from sc in _unitOfWork.Repository<Salcode>().Reads()
                        select new GetSalaryCodeDto
                        {
                            SalCode1 = sc.SalCode1,
                            SalCodeDisp = sc.SalCodeDisp,
                            SalName = sc.SalName,
                            SalAttr = sc.SalAttr,
                            Sort = (int)sc.Sort
                        };

            return dList.ToList();
        }

        private DateTime FirstDayOfMonth
        {
            get
            {
                return new DateTime(iYear, iMonth, 1);
            }
        }

        private string YYMM
        {
            get { return (iYear).ToString("0000") + iMonth.ToString("00"); }//MEMO: 2010/04/30 修改成公元年
        }
    }
}
