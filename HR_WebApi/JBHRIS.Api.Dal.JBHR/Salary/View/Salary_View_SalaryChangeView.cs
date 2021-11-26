using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dal.Salary.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Salary.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Salary.View
{
    public class Salary_View_SalaryChangeView : ISalary_View_SalaryChangeView
    {
        private IUnitOfWork _unitOfWork;

        public Salary_View_SalaryChangeView(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<List<GetSalaryChangeDto>> GetSalaryChange(string Nobr, DateTime CheckDate)
        {
            ApiResult<List<GetSalaryChangeDto>> apiResult = new ApiResult<List<GetSalaryChangeDto>>();
            apiResult.State = false;
            try
            {
                var db = from sb in _unitOfWork.Repository<Salbasd>().Reads()
                         join sc in _unitOfWork.Repository<Salcode>().Reads() on sb.SalCode equals sc.SalCode1
                         where sb.Nobr == Nobr &&
                         CheckDate.Date >= sb.Adate && CheckDate.Date <= sb.Ddate
                         select new GetSalaryChangeDto
                         {
                             Nobr = sb.Nobr,
                             SalCode =  sb.SalCode,
                             SalName = sc.SalName,
                             Amt = sb.Amt
                         };
                apiResult.Result = db.ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.State = false;
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }

        public ApiResult<string> AddSalaryChange(SalaryChangeInfoDto salaryInfo)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = true;
            try
            {
                var state = CheckSalaryChangeAvailable(salaryInfo);
                if (!state.State)
                    return state;
                var db = _unitOfWork.Repository<Salbasd>();
                var totalData = db.Reads().Where(p => p.Nobr == salaryInfo.EmployeeId && p.SalCode == salaryInfo.SalaryCode).ToList();
                var salbasd = new Salbasd
                {
                    Adate = salaryInfo.ChageDate.Date,
                    Amt = salaryInfo.Amount,
                    Amtb = 0,
                    Ddate = new DateTime(9999, 12, 31),
                    KeyDate = DateTime.Now,
                    KeyMan = salaryInfo.CreateMan,
                    Meno = salaryInfo.Remark,
                    Nobr = salaryInfo.EmployeeId,
                    SalCode = salaryInfo.SalaryCode,
                };
                db.Create(salbasd);
                totalData.Add(salbasd);
                var orderData = totalData.OrderByDescending(p => p.Adate);
                DateTime ddate = new DateTime(9999, 12, 31);
                foreach (var it in orderData)
                {
                    it.Ddate = ddate;
                    ddate = it.Adate.AddDays(-1);
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                apiResult.State = false;
                apiResult.Message = ex.Message.ToString();
                apiResult.StackTrace = ex.StackTrace.ToString();
            }

            return apiResult;
        }

        public ApiResult<string> CheckSalaryChangeAvailable(SalaryChangeInfoDto salaryInfo)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = true;
            var db = _unitOfWork.Repository<Salbasd>();
            var data = db.Reads().Where(p => p.Nobr == salaryInfo.EmployeeId && p.SalCode == salaryInfo.SalaryCode
            && salaryInfo.ChageDate >= p.Adate && salaryInfo.ChageDate <= p.Ddate);
            if (data.Any())
            {
                var checkData = data.First();
                if (checkData.Ddate < new DateTime(9999, 12, 31))
                {
                    apiResult.State = false;
                    apiResult.Message = "已存在較新的薪資異動";
                }
            }
            return apiResult;
        }
    }
}
