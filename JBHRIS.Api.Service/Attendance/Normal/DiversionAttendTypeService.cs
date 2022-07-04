using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.WorkFromHome;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{
    public class DiversionAttendTypeService: IDiversionAttendTypeService
    {
        IDiversionAttendType_Normal_GetDiversionAttendType _diversionAttendType_Normal_GetDiversionAttend;
        public DiversionAttendTypeService(IDiversionAttendType_Normal_GetDiversionAttendType diversionAttendType_Normal_GetDiversionAttend)
        {
            _diversionAttendType_Normal_GetDiversionAttend = diversionAttendType_Normal_GetDiversionAttend;
        }

        public ApiResult<string> DeleteDiversionAttendType(DiversionAttendTypeDto DiversionAttendTypeDto)
        {
            throw new NotImplementedException();
        }

        public ApiResult<List<DiversionAttendTypeDto>> GetDiversionAttendTypes(List<string> DiversionAttendTypes)
        {
            return _diversionAttendType_Normal_GetDiversionAttend.GetDiversionAttendTypes(DiversionAttendTypes);
        }

        public ApiResult<string> InsertDiversionAttendType(DiversionAttendTypeDto DiversionAttendTypeDto)
        {
            throw new NotImplementedException();
        }

        public ApiResult<string> UpdateDiversionAttendType(DiversionAttendTypeDto DiversionAttendTypeDto)
        {
            throw new NotImplementedException();
        }
    }
}
