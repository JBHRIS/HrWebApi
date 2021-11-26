using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Attendance.View
{
    public class Attend_Abs_Absd_CompositeDal : IAttend_Abs_Absd_CompositeDal
    {
        private IUnitOfWork _unitOfWork;

        public Attend_Abs_Absd_CompositeDal(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> Delete(List<CancelLeaveApplyDto> cancelLeaveApplyDtos)
        {
            //insert absc
            //update abs leavehours balancehours tothours
            //delete abs
            //delete absd
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            var Repo = _unitOfWork.Repository<Abs>();
            var absdRepo = _unitOfWork.Repository<Absd>();
            try
            {
                foreach (var c in cancelLeaveApplyDtos)
                {
                    var absdDataList = (from a in absdRepo.Reads()
                                        where a.Abssubtract == c.Guid
                                        select a).ToList();

                    foreach (var absd in absdDataList)
                    {
                        var addData = Repo.Read(p => p.Guid == absd.Absadd);
                        if (addData != null)
                        {
                            addData.Balance = addData.Balance + absd.Usehour;
                            addData.LeaveHours = addData.LeaveHours - absd.Usehour;
                        }

                        var subtractData = Repo.Read(p => p.Guid == absd.Abssubtract);
                        if (subtractData != null)
                        {
                            Repo.Delete(subtractData);
                            Absc absc = new Absc()
                            {
                                Nobr = subtractData.Nobr,
                                Bdate = subtractData.Bdate,
                                Edate = subtractData.Edate,
                                Btime = subtractData.Btime,
                                Etime = subtractData.Etime,
                                HCode = subtractData.HCode,
                                TolHours = subtractData.TolHours,
                                KeyMan = subtractData.KeyMan,
                                KeyDate = subtractData.KeyDate,
                                Yymm = subtractData.Yymm,
                                Note = subtractData.Note,
                                AName = subtractData.AName,
                                Serno = subtractData.Serno,
                                Guid = subtractData.Guid
                            };
                            _unitOfWork.Repository<Absc>().Create(absc);
                        }

                        var subtractabsdRepoData = absdRepo.Read(p => p.Abssubtract == absd.Abssubtract);
                        if (subtractabsdRepoData != null)
                        {
                            absdRepo.Delete(subtractabsdRepoData);
                        }
                    }
                }
                _unitOfWork.Save();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.State = false;
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }

        public ApiResult<string> Insert(AbsBalanceOffsetViewDto absBalanceOffsetViewDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.Message = "";
            apiResult.State = true;
            var Repo = _unitOfWork.Repository<Abs>();
            var absdRepo = _unitOfWork.Repository<Absd>();
            try
            {
                var Data = Repo.Read(p => p.Guid == absBalanceOffsetViewDto.absdDto.Absadd);

                if (Data != null)
                {
                    Data.Balance = Data.Balance - absBalanceOffsetViewDto.absdDto.Usehour;
                    Data.LeaveHours = Data.LeaveHours + absBalanceOffsetViewDto.absdDto.Usehour;
                    //Repo.Update(Data);
                    //Repo.SaveChanges();
                }

                Abs abs = new Abs()
                {
                    Nobr = absBalanceOffsetViewDto.absDto.Nobr,
                    Bdate = absBalanceOffsetViewDto.absDto.Bdate,
                    Edate = absBalanceOffsetViewDto.absDto.Edate,
                    Btime = absBalanceOffsetViewDto.absDto.Btime,
                    Etime = absBalanceOffsetViewDto.absDto.Etime,
                    HCode = absBalanceOffsetViewDto.absDto.HCode,
                    TolHours = absBalanceOffsetViewDto.absDto.TolHours,
                    KeyMan = absBalanceOffsetViewDto.absDto.KeyMan,
                    KeyDate = absBalanceOffsetViewDto.absDto.KeyDate,
                    Yymm = absBalanceOffsetViewDto.absDto.Yymm,
                    Notedit = false,
                    Note = absBalanceOffsetViewDto.absDto.Note != null ? absBalanceOffsetViewDto.absDto.Note : "",
                    Syscreate = absBalanceOffsetViewDto.absDto.Syscreate,
                    TolDay = 0,
                    AName = absBalanceOffsetViewDto.absDto.AName != null ? absBalanceOffsetViewDto.absDto.AName : "",
                    Serno = absBalanceOffsetViewDto.absDto.Serno != null ? absBalanceOffsetViewDto.absDto.Serno : "",
                    Nocalc = false,
                    Syscreate1 = false,
                    Balance = 0,
                    LeaveHours = 0,
                    Guid = absBalanceOffsetViewDto.absDto.Guid
                };
                Repo.Create(abs);

                Absd absd = new Absd()
                {
                    Absadd = absBalanceOffsetViewDto.absdDto.Absadd,
                    Abssubtract = absBalanceOffsetViewDto.absdDto.Abssubtract,
                    Usehour = absBalanceOffsetViewDto.absdDto.Usehour,
                    KeyMan = absBalanceOffsetViewDto.absdDto.KeyMan,
                    KeyDate = absBalanceOffsetViewDto.absdDto.KeyDate
                };
                absdRepo.Create(absd);

                _unitOfWork.Save();
                apiResult.State = true;

            }
            catch (Exception ex)
            {
                apiResult.State = false;
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            return apiResult;
        }
    }
}
