using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.Attendance;

namespace JBHRIS.Api.Dal.JBHR.Attendance.View
{
    public class Attend_View_GetOvertimeSearch : IAttend_View_GetOvertimeSearch
    {
        private IUnitOfWork _unitOfWork;
        public Attend_View_GetOvertimeSearch(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<List<OverTimeSearchViewDto>> GetOverTimeSearchView(OverTimeSearchViewEntry overTimeSearchViewEntry)
        {
            ApiResult<List<OverTimeSearchViewDto>> apiResult = new ApiResult<List<OverTimeSearchViewDto>>();
            apiResult.State = false;
            try
            {
                var result = new List<OverTimeSearchViewDto>();
                foreach (var item in overTimeSearchViewEntry.EmployeeList.Split(2100))
                {
                    DateTime today = DateTime.Today;
                    var OverTimesByEntry = from ot in _unitOfWork.Repository<Ot>().Reads()
                                           join b in _unitOfWork.Repository<Base>().Reads() on ot.Nobr equals b.Nobr
                                           join btts in _unitOfWork.Repository<Basetts>().Reads() on b.Nobr equals btts.Nobr
                                           join d in _unitOfWork.Repository<Dept>().Reads() on btts.Dept equals d.DNo
                                           join r in _unitOfWork.Repository<Rote>().Reads() on ot.OtRote equals r.Rote1
                                           join otr in _unitOfWork.Repository<Otrcd>().Reads() on ot.Otrcd equals otr.Otrcd1
                                           into otrgrp
                                           from otrg in otrgrp.DefaultIfEmpty()
                                           where item.Contains(ot.Nobr)
                                           && overTimeSearchViewEntry.DateBegin <= ot.Bdate && ot.Bdate <= overTimeSearchViewEntry.DateEnd
                                           && (btts.Ddate >= today && btts.Adate <= today)
                                           && new string[] { "1", "4", "6" }.Contains(btts.Ttscode)
                                           select new OverTimeSearchViewDto
                                           {
                                               EmployeeID = ot.Nobr,
                                               EmployeeName = b.NameC,
                                               OverTimeDate = ot.Bdate,
                                               BeginTime = ot.Btime,
                                               EndTime = ot.Etime,
                                               OverTimeReason = otrg.Otrname,
                                               DeptCode = d.DNo,
                                               DeptName = d.DName,
                                               OverTimeTotalHours = ot.TotHours,
                                               OverTimeHours = ot.OtHrs,
                                               RestTimeHours = ot.RestHrs,
                                               Remarks = ot.Note,
                                               YYMM = ot.Yymm,
                                               OverTimeRote = r.RoteDisp,
                                               OverTimeRoteName = r.Rotename,
                                               SerialNumber = ot.Serno
                                           };
                    result.AddRange(OverTimesByEntry);
                }
                apiResult.State = true;
                apiResult.Result = result.ToList();

            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }

            return apiResult;
        }

        public List<OvertimeReasonDto> GetOvertimeReason()
        {
            var sql = from o in _unitOfWork.Repository<Otrcd>().Reads()
                      where o.Sort > 0
                      select new OvertimeReasonDto
                      {
                          Otrcd1 = o.Otrcd1,
                          Otrname = o.Otrname,
                          KeyDate = o.KeyDate,
                          KeyMan = o.KeyMan,
                          Callin = o.Callin,
                          Display = o.Display,
                          Nocalc = o.Nocalc,
                          Nofood = o.Nofood,
                          SysOt = o.SysOt,
                          Sort = o.Sort,
                          OtrcdDisp = o.OtrcdDisp
                      };
            return sql.ToList();
        }

        public ApiResult<string> CheckOverTimeNoRepeat(OvertimeDto overtimeDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var SearchB = overtimeDto.OvertimeDate.Date.AddDays(-1);
                var SearchE = overtimeDto.OvertimeDate.Date.AddDays(1);

                var BeginDateTime = overtimeDto.OvertimeDate.Date.AddTime(overtimeDto.BeginTime);
                var EndDateTime = overtimeDto.OvertimeDate.Date.AddTime(overtimeDto.EndTime);
                var sql = from o in _unitOfWork.Repository<Ot>().Reads()
                          where o.Nobr == overtimeDto.EmployeeId
                          && SearchE >= o.Bdate && SearchB <= o.Bdate
                          select new Tuple<DateTime, DateTime>
                          (
                             o.Bdate.AddTime(o.Btime),
                             o.Bdate.AddTime(o.Etime)
                          );
                var otRepeat = sql.ToList();
                
                if (otRepeat.Count() > 0)
                {
                    var repeatData = otRepeat.Where(s => EndDateTime >= s.Item1 && BeginDateTime <= s.Item2).FirstOrDefault();
                    if (repeatData == null)
                    {
                        apiResult.State = true;
                    }
                    else
                    {
                        apiResult.Message = "加班時段重複";
                    }
                }
                else
                {
                    apiResult.State = true;
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }

        public ApiResult<string> SaveOvertime(List<OvertimeDto> overtimeDtos, string KeyMan)
        {
            var Repo = _unitOfWork.Repository<Ot>();
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                foreach (var o in overtimeDtos)
                {
                    Ot ot = new Ot()
                    {
                        Nobr = o.EmployeeId,
                        Bdate = o.OvertimeDate,
                        Btime = o.BeginTime,
                        Etime = o.EndTime,
                        TotHours = o.OvertimeHours,
                        OtHrs = o.ExpenseHours,
                        RestHrs = o.RestHours,
                        Otrcd = o.OvertimeReason,
                        Note = o.Remark,
                        KeyDate = DateTime.Now,
                        KeyMan = KeyMan,
                        Serno = Guid.NewGuid().ToString()
                    };
                    Repo.Create(ot);
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
