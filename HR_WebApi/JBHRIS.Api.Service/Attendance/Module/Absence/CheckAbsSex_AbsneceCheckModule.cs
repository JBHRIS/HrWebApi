using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Module.Absence
{
    public class CheckAbsSex_AbsneceCheckModule : IAbsenceCheckModule
    {
        private IAbsence_Normal_GetHcode _absence_Normal_GetHcode;
        private IEmployee_Normal_GetEmployeeInfo _employee_Normal_GetEmployeeInfo;
        private string ErrorMessage_CheckAbsSex = "假別性別";

        public CheckAbsSex_AbsneceCheckModule(IAbsence_Normal_GetHcode absence_Normal_GetHcode, IEmployee_Normal_GetEmployeeInfo employee_Normal_GetEmployeeInfo)
        {
            _absence_Normal_GetHcode = absence_Normal_GetHcode;
            _employee_Normal_GetEmployeeInfo = employee_Normal_GetEmployeeInfo;
        }
        public ApiResult<List<string>> Check(List<CalAbsHoursDto> calAbsHoursDtos, HcodeDto hcodeDto)
        {
            ApiResult<List<string>> apiResult = new ApiResult<List<string>>();
            apiResult.Result = new List<string>();
            apiResult.State = true;
            foreach (var c in calAbsHoursDtos)
            {
                var getHcode = _absence_Normal_GetHcode.GetHcodeById(c.HCode);
                var Emp = _employee_Normal_GetEmployeeInfo.GetEmployeeInfo(new List<string>() { c.Nobr }).FirstOrDefault();
                if (getHcode.Sex == null || getHcode.Sex.Trim().Length == 0)
                {
                    continue;
                }
                else if (Emp.Sex != getHcode.Sex.Trim())
                {
                    apiResult.State = false;
                    apiResult.Message = ErrorMessage_CheckAbsSex;
                    apiResult.Result.Add(getHcode.HCodeName + "只有" + (getHcode.Sex == "M" ? "男生" : getHcode.Sex == "F" ? "女生" : "") + "可以申請");
                    break;
                }
            }
            return apiResult;
        }
    }
}
