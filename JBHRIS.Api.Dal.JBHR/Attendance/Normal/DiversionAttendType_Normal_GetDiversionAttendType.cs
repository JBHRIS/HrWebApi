using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.WorkFromHome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class DiversionAttendType_Normal_GetDiversionAttendType : IDiversionAttendType_Normal_GetDiversionAttendType
    {
        private IUnitOfWork _unitOfWork;
        public DiversionAttendType_Normal_GetDiversionAttendType(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ApiResult<List<DiversionAttendTypeDto>> GetDiversionAttendTypes(List<string> DiversionAttendTypes)
        {
            ApiResult<List<DiversionAttendTypeDto>> apiResult = new ApiResult<List<DiversionAttendTypeDto>>();
            apiResult.State = false;
            try
            {
                var sql = from d in _unitOfWork.Repository<DiversionAttendType>().Reads()
                          where DiversionAttendTypes.Contains(d.DiversionAttendType1)
                          select new DiversionAttendTypeDto
                          {
                              DiversionAttendType = d.DiversionAttendType1,
                              DiversionAttendTypeName = d.DiversionAttendTypeName,
                              CheckWfhAttend = d.CheckWfhAttend,
                              CheckWorkLog = d.CheckWorkLog,
                              CheckWebCard = d.CheckWebCard,
                              CheckTemperoturyReport = d.CheckTemperoturyReport,
                              KeyDate = d.KeyDate,
                              KeyMan = d.KeyMan,
                              AutoKey = d.AutoKey,
                              Guid = d.Guid
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
