using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Service.Salary.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class AbsenceCancelService : IAbsenceCancelService
    {
        private IAbsenceCancel_Normal_GetCancelableLeave _absenceCancel_Normal_GetCancelableLeave;
        private ISalaryViewService _salaryViewService;
        private IAttend_Abs_Absd_CompositeDal _attend_Abs_Absd_CompositeDal;

        public AbsenceCancelService(IAbsenceCancel_Normal_GetCancelableLeave absenceCancel_Normal_GetCancelableLeave,
            ISalaryViewService salaryViewService,
            IAttend_Abs_Absd_CompositeDal attend_Abs_Absd_CompositeDal)
        {
            _absenceCancel_Normal_GetCancelableLeave = absenceCancel_Normal_GetCancelableLeave;
            _salaryViewService = salaryViewService;
            _attend_Abs_Absd_CompositeDal = attend_Abs_Absd_CompositeDal;
        }

        public ApiResult<List<CancelLeaveApplyDto>> GetCancelableLeave(DateBetweenQueryDto dateBetweenQueryDto)
        {
            var begin = dateBetweenQueryDto.DateBegin.Date;
            var end = dateBetweenQueryDto.DateEnd.Date;
            DateBetweenQueryDto search = new DateBetweenQueryDto()
            {
                EmpList = dateBetweenQueryDto.EmpList,
                DateBegin = begin.AddDays(-1),
                DateEnd = end.AddDays(1)
            };
            var data = _absenceCancel_Normal_GetCancelableLeave.GetCancelableLeave(search);

            if (data.State)
            {
                List<CancelLeaveApplyDto> cancelLeaveApplyDtos = new List<CancelLeaveApplyDto>();
                foreach (var d in data.Result)
                {
                    var dateB = d.LeaveDate.AddTime(d.BeginTime);
                    var dateE = d.LeaveDate.AddTime(d.EndTime);
                    if (dateBetweenQueryDto.DateEnd >= dateB && dateBetweenQueryDto.DateBegin <= dateE)
                    {
                        cancelLeaveApplyDtos.Add(d);
                    }
                }
                data.Result = cancelLeaveApplyDtos;
                ApiResult<AttSalLockDataDto> apiResultAttSalLockDataDto = AttSalLockData(data.Result);
                if (apiResultAttSalLockDataDto.State)
                {
                    if (apiResultAttSalLockDataDto.Result.attLockList != null)
                    {
                        data.Result.RemoveAll(d => apiResultAttSalLockDataDto.Result.attLockList.Contains(d));
                    }
                    if (apiResultAttSalLockDataDto.Result.salLockList != null)
                    {
                        data.Result.RemoveAll(d => apiResultAttSalLockDataDto.Result.salLockList.Contains(d));
                    }
                }
            }
            return data;
        }

        public ApiResult<string> CheckCancelLeave(List<CancelLeaveApplyDto> cancelLeaveApplyDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            ApiResult<AttSalLockDataDto> apiResultAttSalLockData = AttSalLockData(cancelLeaveApplyDtos);
            if (apiResultAttSalLockData.State)
            {
                apiResult.State = false;
            }
            else
            {
                apiResult.State = true;
            }
            return apiResult;
        }

        public ApiResult<string> SaveCancelLeave(List<CancelLeaveApplyDto> cancelLeaveApplyDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            ApiResult<string> apiResultCheckCancelLeave = CheckCancelLeave(cancelLeaveApplyDtos);
            if (apiResultCheckCancelLeave.State)
            {
                apiResult = _attend_Abs_Absd_CompositeDal.Delete(cancelLeaveApplyDtos);
            }
            else
            {
                apiResult.Message = apiResultCheckCancelLeave.Message;
                apiResult.StackTrace = apiResultCheckCancelLeave.StackTrace;
            }
            return apiResult;
        }

        /// <summary>
        /// 判斷計薪鎖檔、出勤鎖檔
        /// </summary>
        /// <param name="cancelLeaveApplyDtos"></param>
        /// <returns>計鎖檔資料、出勤鎖檔資料</returns>
        private ApiResult<AttSalLockDataDto> AttSalLockData(List<CancelLeaveApplyDto> cancelLeaveApplyDtos)
        {
            ApiResult<AttSalLockDataDto> apiResult = new ApiResult<AttSalLockDataDto>();
            apiResult.State = false;
            var EmpList = cancelLeaveApplyDtos.Select(c => c.EmployeeId).Distinct().ToList();
            var attLockList = new List<CancelLeaveApplyDto>();
            var salLockList = new List<CancelLeaveApplyDto>();
            var sal = _salaryViewService.GetSalaryWageLockByEmpList(EmpList).FindAll(p => p.Seq == "2"); //計薪鎖檔
            foreach (var e in cancelLeaveApplyDtos)
            {
                var salLock = sal.Find(s => s.EmployeeID == e.EmployeeId && s.YYMM == e.YYMM);
                bool attLock = _salaryViewService.IsAttendLock(e.LeaveDate, e.EmployeeId); //出勤鎖檔
                if (attLock)
                {
                    attLockList.Add(e);
                }

                if (salLock != null)
                {
                    salLockList.Add(e);
                }
            }

            apiResult.Result = new AttSalLockDataDto();
            if (attLockList.Count > 0)
            {
                apiResult.State = true;
                apiResult.Result.attLockList = new List<CancelLeaveApplyDto>();
                apiResult.Result.attLockList.AddRange(attLockList);
            }

            if (salLockList.Count > 0)
            {
                apiResult.State = true;
                apiResult.Result.salLockList = new List<CancelLeaveApplyDto>();
                apiResult.Result.salLockList.AddRange(salLockList);
            }
            return apiResult;
        }
    }
}
