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
    public class DiversionGroup_Normal_GetDiversionGroup : IDiversionGroup_Normal_GetDiversionGroup
    {
        private IUnitOfWork _unitOfWork;
        public DiversionGroup_Normal_GetDiversionGroup(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ApiResult<List<DiversionGroupDto>> GetDiversionGroup(GetDiversionGroupEntry getDiversionGroupEntry)
        {
            ApiResult<List<DiversionGroupDto>> apiResult = new ApiResult<List<DiversionGroupDto>>();
            apiResult.State = false;
            try
            {
                var sql = from d in _unitOfWork.Repository<DiversionGroup>().Reads()
                          join b in _unitOfWork.Repository<Base>().Reads() on d.EmployeeId equals b.Nobr
                          where getDiversionGroupEntry.EmployeeList.Contains(d.EmployeeId)
                          && getDiversionGroupEntry.DateEnd >= d.BeginDate && getDiversionGroupEntry.DateBegin <= d.EndDate
                          select new DiversionGroupDto
                          {
                              EmployeeId = d.EmployeeId,
                              EmployeeName = b.NameC,
                              BeginDate = d.BeginDate,
                              EndDate = d.EndDate,
                              DiversionGroupType = d.DiversionGroupType,
                              WorkLocation = d.WorkLocation
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
