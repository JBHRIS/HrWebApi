using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class AbsenceCancel_Normal_GetCancelableLeave : IAbsenceCancel_Normal_GetCancelableLeave
    {
        private IUnitOfWork _unitOfWork;
        public AbsenceCancel_Normal_GetCancelableLeave(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<List<CancelLeaveApplyDto>> GetCancelableLeave(DateBetweenQueryDto dateBetweenQueryDto)
        {
            ApiResult<List<CancelLeaveApplyDto>> apiResult = new ApiResult<List<CancelLeaveApplyDto>>();
            apiResult.State = false;
            try
            {
                var sql = from a in _unitOfWork.Repository<Abs>().Reads()
                          join h in _unitOfWork.Repository<Hcode>().Reads() on a.HCode equals h.HCode1
                          where dateBetweenQueryDto.EmpList.Contains(a.Nobr)
                          && dateBetweenQueryDto.DateEnd >= a.Bdate && dateBetweenQueryDto.DateBegin <= a.Edate
                          && h.Mang == false
                          select new CancelLeaveApplyDto
                          {
                              EmployeeId = a.Nobr,
                              LeaveDate = a.Bdate,
                              BeginTime = a.Btime,
                              EndTime = a.Etime,
                              Guid = a.Guid,
                              Taken = a.TolHours,
                              YYMM = a.Yymm
                          };
                apiResult.Result = sql.ToList();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
    }
}
