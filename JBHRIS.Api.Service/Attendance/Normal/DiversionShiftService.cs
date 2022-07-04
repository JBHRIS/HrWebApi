using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class DiversionShiftService : IDiversionShiftService
    {
        private IDiversionShift_Normal_GetDiversionShift _diversionShift_Normal_GetDiversionShift;
        public DiversionShiftService(IDiversionShift_Normal_GetDiversionShift diversionShift_Normal_GetDiversionShift)
        {
            _diversionShift_Normal_GetDiversionShift = diversionShift_Normal_GetDiversionShift;
        }
        public ApiResult<string> DeleteDiversionShift(DiversionShiftDto diversionShiftDto)
        {
            throw new NotImplementedException();
        }

        public ApiResult<List<DiversionShiftDto>> GetDiversionShift(GetDiversionShiftEntry getDiversionShiftEntry)
        {
            return _diversionShift_Normal_GetDiversionShift.GetDiversionShift(getDiversionShiftEntry);
        }

        public ApiResult<string> InsertDiversionShift(DiversionShiftDto diversionShiftDto)
        {
            throw new NotImplementedException();
        }

        public ApiResult<string> UpdateDiversionShift(DiversionShiftDto diversionShiftDto)
        {
            throw new NotImplementedException();
        }
    }
}
