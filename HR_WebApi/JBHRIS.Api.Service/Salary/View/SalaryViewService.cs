using JBHRIS.Api.Bll.Salary.Payroll;
using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dal.Salary.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Salary.Entry;
using JBHRIS.Api.Dto.Salary.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Tools;

namespace JBHRIS.Api.Service.Salary.View
{
    public class SalaryViewService : ISalaryViewService
    {
        ISalary_View_SalaryView _salary_View_SalaryView;
        IEmployee_View_GetEmployee _employee_View_GetEmployee;
        ISalaryCalculateModule _salaryCalculateModule;
        ISalaryEncrypt _salaryEncrypt;
        ISalary_View_SalaryChangeView _salary_View_SalaryChangeView;
        IEmployee_View_EmployeeJobStatus _employee_View_EmployeeJobStatus;

        public SalaryViewService(ISalary_View_SalaryView salary_View_SalaryView,
            IEmployee_View_GetEmployee employee_View_GetEmployee,
            ISalaryCalculateModule salaryCalculateModule,
            ISalaryEncrypt salaryEncrypt,
            ISalary_View_SalaryChangeView salary_View_SalaryChangeView,
            IEmployee_View_EmployeeJobStatus employee_View_EmployeeJobStatus)
        {
            _salary_View_SalaryView = salary_View_SalaryView;
            _employee_View_GetEmployee = employee_View_GetEmployee;
            _salaryCalculateModule = salaryCalculateModule;
            _salaryEncrypt = salaryEncrypt;
            _salary_View_SalaryChangeView = salary_View_SalaryChangeView;
            _employee_View_EmployeeJobStatus = employee_View_EmployeeJobStatus;
        }

        public string GetSalaryYymm(DateTime date, string Nobr)
        {
            GetEmployeSalAttEndDayDto employeSalAttEndDayDto = _employee_View_GetEmployee.GetEmployeSalAttEndDay(Nobr, date);
            return _salary_View_SalaryView.GetUnLockYYMM(date, employeSalAttEndDayDto.Saladr, employeSalAttEndDayDto.AttEndDay);
        }

        public bool IsAttendLock(DateTime date, string Nobr)
        {
            GetEmployeSalAttEndDayDto employeSalAttEndDayDto = _employee_View_GetEmployee.GetEmployeSalAttEndDay(Nobr, date);
            return _salary_View_SalaryView.IsLockedYYMM(date, employeSalAttEndDayDto.Saladr, employeSalAttEndDayDto.AttEndDay);
        }

        public GetSalDateCycleDto GetSalDateCycle(DateTime date, string Nobr)
        {
            GetEmployeSalAttEndDayDto employeSalAttEndDayDto = _employee_View_GetEmployee.GetEmployeSalAttEndDay(Nobr, date);
            CalcDateCycleDto calcDateCycleDto = CalcDateCycle(date, employeSalAttEndDayDto.SalEndDay);
            GetSalDateCycleDto getSalDateCycle = new GetSalDateCycleDto
            {
                SalDateB = calcDateCycleDto.DateB,
                SalDateE = calcDateCycleDto.DateE
            };
            return getSalDateCycle;
        }

        public GetAttDateCycleDto GetAttDateCycle(DateTime date, string Nobr)
        {
            GetEmployeSalAttEndDayDto employeSalAttEndDayDto = _employee_View_GetEmployee.GetEmployeSalAttEndDay(Nobr, date);
            CalcDateCycleDto calcDateCycleDto = CalcDateCycle(date, employeSalAttEndDayDto.AttEndDay);
            GetAttDateCycleDto getAttDateCycle = new GetAttDateCycleDto
            {
                AttDateB = calcDateCycleDto.DateB,
                AttDateE = calcDateCycleDto.DateE
            };
            return getAttDateCycle;
        }

        private CalcDateCycleDto CalcDateCycle(DateTime date,int EndDay)
        {
            var Year = date.Year;
            var Month = date.Month;
            int monthDays = DateTime.DaysInMonth(Year, Month);
            DateTime DateB;
            DateTime DateE;
            if (EndDay > monthDays)
            {
                EndDay = monthDays;
                DateE = new DateTime(Year, Month, EndDay);
                DateB = new DateTime(DateE.Year, DateE.Month, 1);
            }
            else if (date.Date > new DateTime(Year, Month, EndDay).Date)
            {
                DateTime nextDateTime = date.AddMonths(1);
                Year = nextDateTime.Year;
                Month = nextDateTime.Month;
                DateE = new DateTime(Year, Month, EndDay);
                DateB = DateE.AddMonths(-1).AddDays(1);
            }
            else
            {
                DateE = new DateTime(Year, Month, EndDay);
                DateB = DateE.AddMonths(-1).AddDays(1);
            }
            CalcDateCycleDto getAttDateCycle = new CalcDateCycleDto
            {
                DateB = DateB,
                DateE = DateE
            };
            return getAttDateCycle;
        }

        public decimal GetAnnualLeave(string Nobr, string YYMM, string Seq)
        {
            DateTime dateTime = _salary_View_SalaryView.GetPayslipTitle(Nobr,YYMM,Seq).FirstOrDefault().DateE;
            return _salary_View_SalaryView.GetAnnualLeave(Nobr, dateTime);
        }

        public decimal GetCompensatoryLeave(string Nobr, string YYMM, string Seq)
        {
            DateTime dateTime = _salary_View_SalaryView.GetPayslipTitle(Nobr, YYMM, Seq).FirstOrDefault().DateE;
            return _salary_View_SalaryView.GetCompensatoryLeave(Nobr, dateTime);
        }

        public List<GetSalaryWageLockDto> GetSalaryWageLock(string Nobr)
        {
            return _salary_View_SalaryView.GetSalaryWageLock(Nobr);
        }

        public ApiResult<string> CheckSalaryPassWord(string Nobr, string Password)
        {
            Password = _salaryCalculateModule.Base64Encode(Password);
            return _salary_View_SalaryView.CheckSalaryPassWord(Nobr, Password);
        }

        public ApiResult<string> SetSalaryPassWord(string Nobr, string Password)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            var Emp = _employee_View_GetEmployee.GetEmployeeView(new List<string>() { Nobr });
            if(Emp == null || Emp.Count == 0)
            {
                apiResult.Message = "工號錯誤";
            }
            else if (Password.Length > 12)
            {
                apiResult.Message = "密碼長度不能超過12位數";
            }
            else
            {
                Password = _salaryCalculateModule.Base64Encode(Password);
                apiResult = _salary_View_SalaryView.SetSalaryPassWord(Nobr, Password);
            }
            return apiResult;
        }

        public ApiResult<string> DeleteSalaryPassWord(string Nobr)
        {
            return _salary_View_SalaryView.DeleteSalaryPassWord(Nobr);
        }

        public GetPayslipTitleDto GetPayslipTitle(string Nobr, string YYMM, string Seq)
        {
            return _salary_View_SalaryView.GetPayslipTitle(Nobr, YYMM, Seq).FirstOrDefault();
        }

        public List<BlockDetailDto> GetAbsThisMonth(string Nobr, string YYMM)
        {
            Dictionary<string, decimal> Dictionary = new Dictionary<string, decimal>();
            var abs = _salary_View_SalaryView.GetAbs(Nobr, YYMM)
                .Where(a => a.Flag == "-" && a.Mang == false).ToList();
            abs.ForEach(p =>
            {
                Dictionary.AddAbsDictionary(p.Htype, p.TolHours);
            });
            List<BlockDetailDto> blockDetailDtos = new List<BlockDetailDto>();

            foreach (var o in Dictionary)
            {
                var keyName = abs.Where(a => o.Key == a.Htype).FirstOrDefault();
                blockDetailDtos.Add(new BlockDetailDto
                {
                    Title = keyName != null ? keyName.HName: "",
                    Number = o.Value.ToString(),
                    Init = abs.Find(p=>p.Htype == o.Key).HtypeUnit,
                    Memo = ""
                });
            }
            return blockDetailDtos;
        }

        public List<BlockDetailDto> GetOtThisMonth(string Nobr, string YYMM)
        {
            Dictionary<decimal, decimal> Dictionary = new Dictionary<decimal, decimal>();
            _salary_View_SalaryView.GetOt(Nobr, YYMM).ToList().ForEach(p =>
            {
                Dictionary.AddOtDictionary(p.NOP_H_133, p.NOT_H_133);
                Dictionary.AddOtDictionary(p.NOP_H_167, p.NOT_H_167);
                Dictionary.AddOtDictionary(p.NOP_H_200, p.NOT_H_200);
                Dictionary.AddOtDictionary(p.NOP_W_133, p.NOT_W_133);
                Dictionary.AddOtDictionary(p.NOP_W_167, p.NOT_W_167);
                Dictionary.AddOtDictionary(p.NOP_W_200, p.NOT_W_200);
                Dictionary.AddOtDictionary(p.NOP_W_133, p.TOT_W_133);
                Dictionary.AddOtDictionary(p.NOP_W_167, p.TOT_W_167);
                Dictionary.AddOtDictionary(p.NOP_W_200, p.TOT_W_200);
            });
            List<BlockDetailDto> blockDetailDtos = new List<BlockDetailDto>();
            
            foreach (var o in Dictionary)
            {
                blockDetailDtos.Add(new BlockDetailDto
                {
                    Title = o.Key.ToString(),
                    Number = o.Value.ToString(),
                    Init = "小時",
                    Memo = ""
                });
            }
            return blockDetailDtos;
        }


        public List<BlockDetailDto> GetEarningsThisMonth(string Nobr, string YYMM, string Seq)
        {
            var salary = _salary_View_SalaryView.GetSalary(Nobr, YYMM, Seq);
            var earningsThisMonth = salary.Where(s => s.Type == "1")
                                          .Select(p => new BlockDetailDto {
                                            Title = p.SalName,
                                            Number = _salaryEncrypt.Decode(p.Amt).ToString(),
                                          }).ToList();
            return earningsThisMonth;
        }

        public List<BlockDetailDto> GetDeductionThisMonth(string Nobr, string YYMM, string Seq)
        {
            var salary = _salary_View_SalaryView.GetSalary(Nobr, YYMM, Seq);
            var deductionThisMonth = salary.Where(s => s.Type == "2" || s.Type == "3")
                                          .Select(p => new BlockDetailDto
                                          {
                                              Title = p.SalName,
                                              Number = _salaryEncrypt.Decode(p.Amt).ToString(),
                                          }).ToList();
            return deductionThisMonth;
        }

        public List<BlockDetailDto> GetSalaryThisMonth(string Nobr, string YYMM, string Seq)
        {
            var salary = _salary_View_SalaryView.GetSalary(Nobr, YYMM, Seq);
            var PayTaxe = salary.Where(s => new string[] { "1", "2" }.Contains(s.Type) && s.Tax == true)
                          .Select(p => new { DecodeAmt = p.Flag == "-" ? _salaryEncrypt.Decode(p.Amt) * -1 : _salaryEncrypt.Decode(p.Amt) })
                          .ToList();
            var sumPayTaxe =  PayTaxe.Sum(p=>p.DecodeAmt);

            string empSaladr = _employee_View_EmployeeJobStatus.GetCurrentJobStatus(Nobr, DateTime.Now.Date).Saladr;
            string retSalCode = _salary_View_SalaryView.GetRetSalaryCode(empSaladr).FirstOrDefault().SalCode1;

            var Pay = salary.Where(s => new string[] { "1", "2" }.Contains(s.Type) && s.SalCode != retSalCode)
                          .Select(p => new { DecodeAmt = p.Flag == "-"  ? _salaryEncrypt.Decode(p.Amt) * -1 : _salaryEncrypt.Decode(p.Amt) })
                          .ToList();
            var sumPay = Pay.Sum(p => p.DecodeAmt);

            var TotSal = salary.Select(p => new { DecodeAmt = p.Flag == "-" ? _salaryEncrypt.Decode(p.Amt) * -1 : _salaryEncrypt.Decode(p.Amt) })
                          .ToList();
            var sumTotSal = TotSal.Sum(p => p.DecodeAmt);

            BlockDetailDto BlockPayTaxe = new BlockDetailDto()
            {
                Title = "應稅薪資",
                Number = sumPayTaxe.ToString()
            };
            BlockDetailDto BlockPay = new BlockDetailDto()
            {
                Title = "應發薪資",
                Number = sumPay.ToString()
            };
            BlockDetailDto BlockTotSal = new BlockDetailDto()
            {
                Title = "實發薪資",
                Number = sumTotSal.ToString()
            };

            List<BlockDetailDto> detailDtos = new List<BlockDetailDto>();
            detailDtos.Add(BlockPayTaxe);
            detailDtos.Add(BlockPay);
            detailDtos.Add(BlockTotSal);

            return detailDtos;
        }

        public List<BlockDetailDto> GetRetirementThisMonth(string Nobr, string YYMM)
        {
            var exp = _salary_View_SalaryView.GetRetirement(Nobr, YYMM).FirstOrDefault();
            string CompNumber = null;
            string ExpNumber = null;
            if (exp != null)
            {
                CompNumber = _salaryEncrypt.Decode(exp.Comp).ToString();
                ExpNumber = _salaryEncrypt.Decode(exp.Exp).ToString();
            }
            BlockDetailDto BlockPayTaxe = new BlockDetailDto()
            {
                Title = "公司提撥",
                Number = CompNumber
            };
            BlockDetailDto BlockPay = new BlockDetailDto()
            {
                Title = "員工自提",
                Number = ExpNumber
            };
            List<BlockDetailDto> detailDtos = new List<BlockDetailDto>();
            detailDtos.Add(BlockPayTaxe);
            detailDtos.Add(BlockPay);
            return detailDtos;
        }

        public ApiResult<string> AddSalaryChange(SalaryChangeInfoDto salaryInfo)
        {
            var data = GetSalaryChange(salaryInfo.EmployeeId,salaryInfo.ChageDate).Result.Where(p=>p.SalCode == salaryInfo.SalaryCode && p.Amt == salaryInfo.Amount).ToList();
            if (data.Any())
            {
                //調整薪資數字一樣就不做異動
                ApiResult<string> apiResult= new ApiResult<string>();
                apiResult.State = true;
                return apiResult;
            }
            else
            {
                salaryInfo.Amount = _salaryEncrypt.Encode(salaryInfo.Amount);
                return _salary_View_SalaryChangeView.AddSalaryChange(salaryInfo);
            }
        }

        public ApiResult<List<GetSalaryChangeDto>> GetSalaryChange(string Nobr, DateTime CheckDate)
        {
            ApiResult<List<GetSalaryChangeDto>> apiResult = _salary_View_SalaryChangeView.GetSalaryChange(Nobr, CheckDate);
            if (apiResult.State)
            {
                apiResult.Result.ForEach(r =>
                {
                    r.Amt = _salaryEncrypt.Decode(r.Amt);
                });
            }
            return apiResult;
        }

        public List<GetSalaryWageLockDto> GetSalaryWageLockByEmpList(List<string> EmpList)
        {
            return _salary_View_SalaryView.GetSalaryWageLockByEmpList(EmpList);
        }

        public List<GetSalaryCodeDto> GetSalaryCode()
        {
            return _salary_View_SalaryView.GetSalaryCode();
        }

        private class CalcDateCycleDto
        {
            public DateTime DateB { get; set; }
            public DateTime DateE { get; set; }
        }
    }
}
