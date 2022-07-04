using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dal.Attendance.View;

namespace JBHRIS.Api.Dal.JBHR.Attendance.View
{
    public class Attend_View_GetAbsenceTakenView: IAttend_View_GetAbsenceTakenView
    {
        private IUnitOfWork _unitOfWork;

        public Attend_View_GetAbsenceTakenView(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<List<AbsenceTakenViewDto>> GetAbsenceTakenView(AbsenceTakenViewEntry abseneceTakenViewEntry)
        {
            ApiResult<List<AbsenceTakenViewDto>> apiResult = new ApiResult<List<AbsenceTakenViewDto>>();
            apiResult.State = false;
            try
            {
                var result = new List<AbsenceTakenViewDto>();
                foreach (var item in abseneceTakenViewEntry.EmployeeList.Split(2100))
                {
                    DateTime today = DateTime.Today;
                    var AbsencesTakenByEntry = from abs in _unitOfWork.Repository<Abs>().Reads()
                                               join b in _unitOfWork.Repository<Base>().Reads() on abs.Nobr equals b.Nobr
                                               join h in _unitOfWork.Repository<Hcode>().Reads() on abs.HCode equals h.HCode1
                                               join btts in _unitOfWork.Repository<Basetts>().Reads() on b.Nobr equals btts.Nobr
                                               join d in _unitOfWork.Repository<Dept>().Reads() on btts.Dept equals d.DNo
                                               where item.Contains(abs.Nobr)
                                               && (abseneceTakenViewEntry.LeaveCodeList.Count > 0 ? abseneceTakenViewEntry.LeaveCodeList.Contains(h.HCode1) : true)
                                               && h.Flag == "-"
                                               && (abs.Edate >= abseneceTakenViewEntry.DateBegin && abs.Bdate <= abseneceTakenViewEntry.DateEnd)
                                               && (btts.Ddate >= today && btts.Adate <= today)
                                               && new string[] { "1", "4", "6" }.Contains(btts.Ttscode)
                                               select new AbsenceTakenViewDto
                                               {
                                                   EmployeeId = abs.Nobr,
                                                   EmployeeName = b.NameC,
                                                   LeaveCode = h.HCodeDisp,
                                                   LeaveName = h.HName,
                                                   BeginDate = abs.Bdate,
                                                   EndDate = abs.Edate,
                                                   BeginTime = abs.Btime,
                                                   EndTime = abs.Etime,
                                                   Taken = (decimal)abs.TolHours,
                                                   Unit = h.Unit,
                                                   Remark = abs.Note,
                                                   DepartmentCode = d.DNo,
                                                   DepartmentName = d.DName,
                                                   Comp = btts.Comp
                                               };
                    result.AddRange(AbsencesTakenByEntry);
                }
                apiResult.State = true;
                apiResult.Result = result.ToList();
            }
            catch (Exception ex)
            {
                apiResult.State = false;
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        public ApiResult<string> InsertAbsenceOffsetView(AbsdDto absdDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            var Repo = _unitOfWork.Repository<Absd>();
            try
            {
                Absd absd = new Absd()
                {
                    Absadd  = absdDto.Absadd,
                    Abssubtract = absdDto.Abssubtract,
                    Usehour = absdDto.Usehour,
                    KeyMan = absdDto.KeyMan,
                    KeyDate  = absdDto.KeyDate
                };
                Repo.Create(absd);
                Repo.SaveChanges();
                apiResult.State = true;

            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        public ApiResult<string> InsertAbsenceTakenView(AbsDto absDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            var Repo = _unitOfWork.Repository<Abs>();
            try
            {
                Abs abs = new Abs()
                {
                    Nobr = absDto.Nobr,
                    Bdate = absDto.Bdate,
                    Edate = absDto.Edate,
                    Btime = absDto.Btime,
                    Etime = absDto.Etime,
                    HCode = absDto.HCode,
                    TolHours = absDto.TolHours,
                    KeyMan = absDto.KeyMan,
                    KeyDate = absDto.KeyDate,
                    Yymm = absDto.Yymm,
                    Notedit = false,
                    Note = absDto.Note != null ? absDto.Note : "",
                    Syscreate = absDto.Syscreate,
                    TolDay = 0,
                    AName = absDto.AName != null ? absDto.AName : "",
                    Serno = absDto.Serno != null ? absDto.Serno : "",
                    Nocalc = false,
                    Syscreate1 = false,
                    Balance = 0,
                    LeaveHours = 0,
                    Guid = absDto.Guid
                };
                Repo.Create(abs);
                Repo.SaveChanges();
                apiResult.State = true;

            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        public ApiResult<string> UpdateAbsenceBalanceLeavehoursView(string guid, decimal useHours)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            var Repo = _unitOfWork.Repository<Abs>();
            var Data = Repo.Read(p => p.Guid == guid);
            try
            {
                if (Data != null)
                {
                    Data.Balance = Data.Balance - useHours;
                    Data.LeaveHours = Data.LeaveHours + useHours;
                    Repo.Update(Data);
                    Repo.SaveChanges();
                    apiResult.State = true;
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
    }
}
