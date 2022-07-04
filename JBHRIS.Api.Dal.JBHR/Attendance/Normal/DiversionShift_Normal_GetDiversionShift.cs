using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class DiversionShift_Normal_GetDiversionShift : IDiversionShift_Normal_GetDiversionShift
    {
        private IUnitOfWork _unitOfWork;
        public DiversionShift_Normal_GetDiversionShift(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ApiResult<List<DiversionShiftDto>> GetDiversionShift(GetDiversionShiftEntry getDiversionShiftEntry)
        {
            ApiResult<List<DiversionShiftDto>> apiResult = new ApiResult<List<DiversionShiftDto>>();
            apiResult.State = false;
            try
            {
                var sql = from d in _unitOfWork.Repository<DiversionShift>().Reads()
                          join mt in _unitOfWork.Repository<Mtcode>().Reads() on d.DiversionGroup equals mt.Code
                          join da in _unitOfWork.Repository<DiversionAttendType>().Reads() on d.DiversionAttendType equals da.DiversionAttendType1
                          where getDiversionShiftEntry.DiversionGroupList.Contains(d.DiversionGroup)
                          && getDiversionShiftEntry.DateEnd >= d.AttendDate && getDiversionShiftEntry.DateBegin <= d.AttendDate
                          && mt.Category == "DiversionGroupType"
                          select new DiversionShiftDto
                          {
                              AttendDate = d.AttendDate,
                              DiversionGroup = d.DiversionGroup,
                              DiversionGroupName = mt.Name,
                              DiversionAttendType = d.DiversionAttendType,
                              DiversionAttendTypeName = da.DiversionAttendTypeName
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
