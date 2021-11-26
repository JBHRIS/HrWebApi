using HR_WebApi.Dto.Attendance;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Normal
{

    public class DiversionGroupService : IDiversionGroupService
    {
        private IDiversionGroup_Normal_GetDiversionGroup _diversionGroup_Normal_GetDiversionGroup;
        public DiversionGroupService(IDiversionGroup_Normal_GetDiversionGroup diversionGroup_Normal_GetDiversionGroup)
        {
            _diversionGroup_Normal_GetDiversionGroup = diversionGroup_Normal_GetDiversionGroup;
        }
        public ApiResult<string> DeleteDiversionGroup(DiversionGroupDto diversionGroupDto)
        {
            throw new NotImplementedException();
        }

        public ApiResult<List<DiversionGroupDto>> GetDiversionGroup(GetDiversionGroupEntry getDiversionGroupEntry)
        {
            return _diversionGroup_Normal_GetDiversionGroup.GetDiversionGroup(getDiversionGroupEntry);
        }

        public ApiResult<string> InsertDiversionGroup(DiversionGroupDto diversionGroupDto)
        {
            throw new NotImplementedException();
        }

        public ApiResult<string> UpdateDiversionGroup(DiversionGroupDto diversionGroupDto)
        {
            throw new NotImplementedException();
        }
    }
}
