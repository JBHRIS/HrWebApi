using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Employee.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Service.Employee.View
{
    public class EmployeeJobStatusService : IEmployeeJobStatusService
    {
        private IEmployee_View_EmployeeJobStatus _employee_View_EmployeeJobStatus;

        public EmployeeJobStatusService(
            IEmployee_View_EmployeeJobStatus employee_View_EmployeeJobStatus
            )
        {
            _employee_View_EmployeeJobStatus = employee_View_EmployeeJobStatus;
        }

        public ApiResult<string> AddChange(BasettsDto basettsDto)
        {
            basettsDto.KeyDate = DateTime.Now;
            return _employee_View_EmployeeJobStatus.AddChange(basettsDto);
        }

        public ApiResult<string> CheckEmployeeJobStatusChange(BasettsDto basettsDto)
        {
            return _employee_View_EmployeeJobStatus.CheckChange(basettsDto);
        }

        public ApiResult<BasettsDto> GetCurrentJobStatus(string Nobr, DateTime Adate)
        {
            ApiResult<BasettsDto> apiResult = new ApiResult<BasettsDto>();
            try
            {
                apiResult.Result = _employee_View_EmployeeJobStatus.GetCurrentJobStatus(Nobr, Adate);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.State = false;
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        public ApiResult<DateTime?> GetEmployeeStartWorkDate(string EmployeeID)
        {
            ApiResult<DateTime?> apiResult = new ApiResult<DateTime?>();
            apiResult.State = false;

            try
            {
                var employeeJobStatus = _employee_View_EmployeeJobStatus.GetEmployeeJobStatus(EmployeeID);
                var onWork = employeeJobStatus.FindAll(e => e.Ttscode == "1");
                if (onWork != null)
                {
                    onWork = onWork.OrderByDescending(o => o.Cindt.Value).ToList();
                    DateTime? cindt = onWork[0].Cindt;
                    var unpaidLeaves = employeeJobStatus.FindAll(e => e.Ttscode == "3");
                    if (unpaidLeaves != null)
                    {
                        foreach (var u in unpaidLeaves)
                        {
                            TimeSpan e = (TimeSpan)(u.Ddate - u.Adate);
                            cindt = cindt.Value.AddDays(e.Days);
                        }
                    }
                    apiResult.State = true;
                    apiResult.Result = cindt;
                }
                else
                {
                    apiResult.Message = "無員工異動資料";
                }

            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }

            return apiResult;

        }

        public ApiResult<string> UpdateChange(BasettsDto basettsDto)
        {
            return _employee_View_EmployeeJobStatus.UpdateChange(basettsDto);
        }
    }
}
