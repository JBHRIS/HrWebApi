using AutoMapper;
using JBHRIS.Api.Bll.Attendance.Action;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Action;
using JBHRIS.Api.Service._System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Service.Attendance.Action
{
    public class AttendanceGenerateService : IAttendanceGenerateService
    {
        private IAttendanceGenerateBll _attendanceGenerateBll;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private CurrentUser _currentUser;

        public AttendanceGenerateService(IAttendanceGenerateBll attendanceGenerateBll, IUnitOfWork unitOfWork, IMapper mapper, CurrentUser currentUser)
        {
            _attendanceGenerateBll = attendanceGenerateBll;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
        }
        public ApiResult<List<AttendDto>> Generate(List<string> employeeList, DateTime DateBegin, DateTime DateEnd)
        {
            ApiResult<List<AttendDto>> results = new ApiResult<List<AttendDto>>();
            results.Result = new List<AttendDto>();
            results.State = false;

            var tmtableRepo = _unitOfWork.Repository<Tmtable>();
            var rotechgRepo = _unitOfWork.Repository<Rotechg>();
            var attendRepo = _unitOfWork.Repository<Attend>();
            var attendListExists = attendRepo.Reads().Where(p => employeeList.Contains(p.Nobr) && p.Adate >= DateBegin && p.Adate <= DateEnd).ToList();

            List<string> yymmList = new List<string>();
            for (DateTime date = DateBegin; date < DateEnd; date = date.AddMonths(1))
            {
                yymmList.Add(date.ToString("yyyyMM"));
            }
            foreach (var yymm in yymmList)
            {
                int Year = Convert.ToInt32(yymm.Substring(0, 4));
                int Month = Convert.ToInt32(yymm.Substring(4, 2));
                DateTime beginDate, endDate;
                beginDate = new DateTime(Year, Month, 1);
                endDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
                var tmtableList = _mapper.Map<List<TmtableDto>>(tmtableRepo.Reads().Where(p => employeeList.Contains(p.Nobr) && p.Yymm == yymm).ToList());
                var rotechgList = _mapper.Map<List<RotechgDto>>(rotechgRepo.Reads().Where(p => employeeList.Contains(p.Nobr) && p.Adate >= beginDate && p.Adate <= endDate).ToList());

                //沒有班表就無法計算
                var attendList = _attendanceGenerateBll.Generate(DateBegin, DateEnd, tmtableList, rotechgList);
                results.Result.AddRange(attendList);
                foreach (var att in attendList)
                {
                    var entity = attendRepo.Read(p => p.Nobr == att.Nobr && p.Adate == att.Adate);
                    if (entity != null)
                    {
                        entity.Rote = att.Rote;
                        entity.RoteH = att.RoteH;
                    }
                    else
                    {
                        entity = _mapper.Map<Attend>(att);
                        attendRepo.Create(entity);
                    }
                    entity.KeyMan = _currentUser.UserInfo.UserName;
                    entity.KeyDate = DateTime.Now;
                }
            }

            _unitOfWork.Save();

            results.State = true;
            return results;
        }
    }
}
