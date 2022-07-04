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
    public class Attend_Normal_UpdateAttend : IAttend_Normal_UpdateAttend
    {
        private IUnitOfWork _unitOfWork;

        public Attend_Normal_UpdateAttend(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> UpdateAttend(List<AttendDto> attendanceDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<Attend>();

                foreach (var attendanceDto in attendanceDtos)
                {
                    var data = Repo.Reads().Where(x => x.Nobr == attendanceDto.Nobr && x.Adate == attendanceDto.Adate).FirstOrDefault();
                    data.Nobr = attendanceDto.Nobr;
                    data.Adate = attendanceDto.Adate;
                    data.Rote = attendanceDto.Rote;
                    data.KeyMan = attendanceDto.KeyMan;
                    data.KeyDate = DateTime.Now;
                    data.LateMins = attendanceDto.LateMins;
                    data.EMins = attendanceDto.EMins;
                    data.Abs = attendanceDto.Abs;
                    data.AdjCode = attendanceDto.AdjCode;
                    data.CantAdj = attendanceDto.CantAdj;
                    data.Ser = attendanceDto.Ser;
                    data.NightHrs = attendanceDto.NightHrs;
                    data.Foodamt = attendanceDto.Foodamt;
                    data.Foodsalcd = attendanceDto.Foodsalcd;
                    data.Forget = attendanceDto.Forget;
                    data.AttHrs = attendanceDto.AttHrs;
                    data.Nigamt = attendanceDto.Nigamt;
                    data.Specamt = attendanceDto.Specamt;
                    data.Specsalcd = attendanceDto.Specsalcd;
                    data.Stationamt = attendanceDto.Stationamt;
                    data.EarlyMins = attendanceDto.EarlyMins;
                    data.DelayMins = attendanceDto.DelayMins;
                    data.RelHrs = attendanceDto.RelHrs;
                    data.RoteH = attendanceDto.RoteH;
                    Repo.Update(data);
                }
                Repo.SaveChanges();
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
