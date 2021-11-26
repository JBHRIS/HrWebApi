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
    /* 快速模式：產生班表ATTEND會參考BASETTS.ROTET,ROTECHG.ROTE,TMTABLE_IMPORT,TMTABLE
     * 所以會假設當ATTEND.KEY_DATE如果比上述參考資料的其中一種資料的時間還要舊
     * 代表該筆資料已過期，需重新判斷一次並更新時間
     * 反之，如果ATTEND比其他資料的時間都還新
     * 可以評估不重新拋轉
     */

    /// <summary>
    /// 
    /// </summary>
    public class TimetableGenerateService : ITimetableGenerateService
    {
        private IUnitOfWork _unitOfWork;
        private ITimetableGenerateBll _timetableGenerateBll;
        private IMapper _mapper;
        private CurrentUser _currentUser;
        private IAttendanceGenerateService _attendanceGenerateService;

        public TimetableGenerateService(IUnitOfWork unitOfWork, ITimetableGenerateBll timetableGenerateBll, IMapper mapper, CurrentUser currentUser,IAttendanceGenerateService attendanceGenerateService)
        {
            _unitOfWork = unitOfWork;
            _timetableGenerateBll = timetableGenerateBll;
            _mapper = mapper;
            _currentUser = currentUser;
            _attendanceGenerateService = attendanceGenerateService;
        }
        public ApiResult<List<TmtableDto>> Generate(TimetableGenerateEntry timetableGenerateEntry)
        {
            DateTime t1, t2;
                t1 = DateTime.Now;
            var results = new ApiResult<List<TmtableDto>>();
            results.Result = new List<TmtableDto>();
            int Year = Convert.ToInt32(timetableGenerateEntry.Yymm.Substring(0, 4));
            int Month = Convert.ToInt32(timetableGenerateEntry.Yymm.Substring(4, 2));
            DateTime beginDate, endDate;
            beginDate = new DateTime(Year, Month, 1);
            endDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));
            string prevYymm = beginDate.AddMonths(-1).ToString("yyyyMM");

            #region Repository
            //Repository
            var tmtableImportRepo = _unitOfWork.Repository<TmtableImport>();
            var tmtableRepo = _unitOfWork.Repository<Tmtable>();
            var basettsRepo = _unitOfWork.Repository<Basetts>();
            var rotetRepo = _unitOfWork.Repository<Rotet>();
            var HoliRepo = _unitOfWork.Repository<Holi>();
            var otHcodeRepo = _unitOfWork.Repository<Othcode>();
            #endregion

            #region 取得參考資料(轉Dto)

            var rotetList = _mapper.Map<List<RotetDto>>(rotetRepo.Reads().ToList());
            var otHcodeList = otHcodeRepo.Reads().ToList();
            var calendarList = _mapper.Map<List<Holi>, List<HoliDto>>(HoliRepo.Reads().Where(p => p.HDate >= beginDate && p.HDate <= endDate).ToList());
            foreach (var calendar in calendarList)
            {
                var othcode = otHcodeList.SingleOrDefault(p => p.Othcode1 == calendar.Othcode);
                if (othcode != null)
                    calendar.Othcode_Rote = othcode.Rote;
                else
                    calendar.Othcode_Rote = "";
            }
            var tmtableImportList = _mapper.Map<List<TmtableImport>, List<TmtableImportDto>>(tmtableImportRepo.Reads().Where(p => timetableGenerateEntry.employeeList.Contains(p.Nobr) && p.Yymm == timetableGenerateEntry.Yymm).ToList());
            var employeeInfos_HoliCode = basettsRepo.GetCurrentOnJob(timetableGenerateEntry.employeeList, beginDate, endDate)
                .Select(p => new EmployeeInfo_HoliCode { EmployeeId = p.Nobr, Adate = p.Adate, Ddate = p.Ddate.Value, Calendar = p.HoliCode, Rotet = p.Rotet, LastSequnce = -1 }).ToList();
            if(!employeeInfos_HoliCode.Any())
            {
                results.Message = "無法產生班表資料，" + String.Join(',', timetableGenerateEntry.employeeList);
                results.State = false;
                return results;
            }
            var tmtableListPreviosMonth = tmtableRepo.Reads().Where(p => p.Yymm == prevYymm && timetableGenerateEntry.employeeList.Contains(p.Nobr)).Select(p => new { p.Nobr, p.FreqNo }).ToList();
            foreach (var it in employeeInfos_HoliCode)
            {
                var tmtablePrevious = tmtableListPreviosMonth.FirstOrDefault(p => p.Nobr == it.EmployeeId);
                if (tmtablePrevious != null)
                    it.LastSequnce = Convert.ToInt32(tmtablePrevious.FreqNo);
            }

            #endregion

            #region 叫用Bll

            List<TmtableDto> tmtableList = _timetableGenerateBll.Generate(timetableGenerateEntry.Yymm, employeeInfos_HoliCode, rotetList, calendarList, tmtableImportList);

            #endregion
            var tmtableListExists = tmtableRepo.Reads().Where(p => p.Yymm == timetableGenerateEntry.Yymm && timetableGenerateEntry.employeeList.Contains(p.Nobr));
            foreach (var existTmtable in tmtableListExists)
                tmtableRepo.Delete(existTmtable);
            foreach (var newTmtable in tmtableList)
            {
                newTmtable.KeyMan = _currentUser.UserInfo.UserName;
                newTmtable.KeyDate = DateTime.Now;
                var entity = _mapper.Map<TmtableDto, Tmtable>(newTmtable);
                tmtableRepo.Create(entity);
            }
            _unitOfWork.Save();
            results.State = true;
            results.Result.AddRange(tmtableList);

            _attendanceGenerateService.Generate(timetableGenerateEntry.employeeList, beginDate, endDate);
            t2 = DateTime.Now;
            results.Message = (t2 - t1).TotalSeconds.ToString();
            return results;
        }
    }
}
