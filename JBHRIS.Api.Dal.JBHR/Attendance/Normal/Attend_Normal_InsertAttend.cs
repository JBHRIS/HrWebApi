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
    public class Attend_Normal_InsertAttend : IAttend_Normal_InsertAttend
    {
        private IUnitOfWork _unitOfWork;

        public Attend_Normal_InsertAttend(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> InsertAttend(List<AttendDto> attendanceDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<Attend>();

                foreach (var attendanceDto in attendanceDtos)
                {
                    Attend attend = new Attend()
                    {
                        Nobr = attendanceDto.Nobr,
                        Adate = attendanceDto.Adate,
                        Rote = attendanceDto.Rote,
                        KeyMan = attendanceDto.KeyMan,
                        KeyDate = DateTime.Now,
                        LateMins = attendanceDto.LateMins,
                        EMins = attendanceDto.EMins,
                        Abs = attendanceDto.Abs,
                        AdjCode = attendanceDto.AdjCode,
                        CantAdj = attendanceDto.CantAdj,
                        Ser = attendanceDto.Ser,
                        NightHrs = attendanceDto.NightHrs,
                        Foodamt = attendanceDto.Foodamt,
                        Foodsalcd = attendanceDto.Foodsalcd,
                        Forget = attendanceDto.Forget,
                        AttHrs = attendanceDto.AttHrs,
                        Nigamt = attendanceDto.Nigamt,
                        Specamt = attendanceDto.Specamt,
                        Specsalcd = attendanceDto.Specsalcd,
                        Stationamt = attendanceDto.Stationamt,
                        EarlyMins = attendanceDto.EarlyMins,
                        DelayMins = attendanceDto.DelayMins,
                        RelHrs = attendanceDto.RelHrs,
                        RoteH = attendanceDto.RoteH
                    };
                    Repo.Create(attend);
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
