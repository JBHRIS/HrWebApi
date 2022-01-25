using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.Attendance.View;
using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Employee.View;

namespace JBHRIS.Api.Dal.JBHR.Attendance.View
{
    public class Attend_View_GetAttendRote : IAttend_View_GetAttendRote
    {
        private IUnitOfWork _unitOfWork;

        public Attend_View_GetAttendRote(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<AttentRoteViewDto> GetAttendRoteView(AttendanceEntry attendanceEntry)
        {
            var attendRotes = from att in _unitOfWork.Repository<Attend>().Reads()
                              join b in _unitOfWork.Repository<Base>().Reads() on att.Nobr equals b.Nobr
                              join r in _unitOfWork.Repository<Rote>().Reads() on att.Rote equals r.Rote1
                              where attendanceEntry.EmployeeList.Contains(att.Nobr)
                              && attendanceEntry.DateBegin <= att.Adate && att.Adate <= attendanceEntry.DateEnd
                              select new AttentRoteViewDto()
                              {
                                  EmployeeId = b.Nobr.ToString(),
                                  EmployeeName = b.NameC.ToString(),
                                  AttendDate = att.Adate,
                                  RoteCode = r.Rote1,
                                  RoteCodeDisp = r.RoteDisp,
                                  RoteName = r.Rotename,
                                  RoteDateB = att.Adate.ToShortDateString(),
                                  RoteDateE = att.Adate.ToShortDateString(),
                                  RoteTimeB = r.OnTime,
                                  RoteTimeE = r.OffTime,
                                  LateMin = att.LateMins,
                                  EarlyMin = att.EMins,
                                  Forget = att.Forget,
                                  IsAbs = att.Abs,
                                  WkHrs = r.WkHrs
                              };

            List<AttentRoteViewDto> attentRoteViewDtos = new List<AttentRoteViewDto>();
            attentRoteViewDtos = attendRotes.ToList();

            return attentRoteViewDtos;
        }

        public List<AttRoteViewDto> GetAttRote(List<string> EmpIds, DateTime StartDate, DateTime EndDate)
        {
            var attendRotes = (from att in _unitOfWork.Repository<Attend>().Reads()
                               join r in _unitOfWork.Repository<Rote>().Reads() on att.Rote equals r.Rote1
                               join bts in _unitOfWork.Repository<Basetts>().Reads() on att.Nobr equals bts.Nobr
                               where EmpIds.Contains(att.Nobr)
                               && att.Adate >= StartDate && att.Adate <= EndDate
                               && new List<string>() { "1", "4", "6" }.Contains(bts.Ttscode)
                               && DateTime.Now.Date >= bts.Adate && DateTime.Now.Date <= bts.Ddate
                               select new { ATTEND = att, ROTE = r, BASETTS = bts }).ToList();


            List<AttRoteViewDto> attentRoteViewDtos = new List<AttRoteViewDto>();
            foreach (var it in attendRotes)
            {
                List<Tuple<DateTime, DateTime>> roteRestTime = new List<Tuple<DateTime, DateTime>>();
                var att = it.ATTEND;
                var rote = it.ROTE;
                var bts = it.BASETTS;
                Dictionary<string, string> RestDic = new Dictionary<string, string>();
                if (it.ROTE.ResBTime.Trim().Length > 0 && it.ROTE.ResETime.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.ResBTime))
                    RestDic.Add(it.ROTE.ResBTime, it.ROTE.ResETime);
                if (it.ROTE.ResB1Time.Trim().Length > 0 && it.ROTE.ResE1Time.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.ResB1Time))
                    RestDic.Add(it.ROTE.ResB1Time, it.ROTE.ResE1Time);
                if (it.ROTE.ResB2Time.Trim().Length > 0 && it.ROTE.ResE2Time.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.ResB2Time))
                    RestDic.Add(it.ROTE.ResB2Time, it.ROTE.ResE2Time);
                if (it.ROTE.ResB3Time.Trim().Length > 0 && it.ROTE.ResE3Time.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.ResB3Time))
                    RestDic.Add(it.ROTE.ResB3Time, it.ROTE.ResE3Time);
                if (it.ROTE.ResB4Time.Trim().Length > 0 && it.ROTE.ResE4Time.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.ResB4Time))
                    RestDic.Add(it.ROTE.ResB4Time, it.ROTE.ResE4Time);

                foreach (var r in RestDic)
                {
                    roteRestTime.Add(new Tuple<DateTime, DateTime>(att.Adate.AddTime(r.Key), att.Adate.AddTime(r.Value)));
                }

                if (it.ROTE.OnTime.Trim().Length > 0 && it.ROTE.OffTime.Trim().Length > 0)
                {
                    RoteDto roteDto = new RoteDto()
                    {
                        RoteCode = rote.Rote1,
                        RoteDisp = rote.RoteDisp,
                        Rotename = rote.Rotename,
                        OnTime = rote.OnTime,
                        OffTime = rote.OffTime,
                        OffTime2 = rote.Offtime2,
                        AttEnd = rote.AttEnd,
                        OtBegin = rote.OtBegin,
                        Sort = rote.Sort
                    };
                    AttendDto attendDto = new AttendDto()
                    {
                        Nobr = att.Nobr,
                        Adate = att.Adate,
                        Rote = att.Rote,
                        KeyMan = att.KeyMan,
                        KeyDate = att.KeyDate,
                        LateMins = att.LateMins,
                        EMins = att.EMins,
                        Abs = att.Abs,
                        AdjCode = att.AdjCode,
                        CantAdj = att.CantAdj,
                        Ser = att.Ser,
                        NightHrs = att.NightHrs,
                        Foodamt = att.Foodamt,
                        Foodsalcd = att.Foodsalcd,
                        Forget = att.Forget,
                        AttHrs = att.AttHrs,
                        Nigamt = att.Nigamt,
                        Specamt = att.Specamt,
                        Specsalcd = att.Specsalcd,
                        Stationamt = att.Stationamt,
                        EarlyMins = att.EarlyMins,
                        DelayMins = att.DelayMins,
                        RelHrs = att.RelHrs,
                        RoteH = att.RoteH
                    };
                    BasettsDto basettsDto = new BasettsDto()
                    {
                        Nobr = bts.Nobr,
                        Adate = bts.Adate,
                        Ttscode = bts.Ttscode,
                        Ddate = bts.Ddate,
                        Indt = bts.Indt,
                        Cindt = bts.Cindt,
                        Oudt = bts.Oudt,
                        Stdt = bts.Stdt,
                        Stindt = bts.Stindt,
                        Stoudt = bts.Stoudt,
                        Comp = bts.Comp,
                        Dept = bts.Dept,
                        Depts = bts.Depts,
                        Job = bts.Job,
                        Jobl = bts.Jobl,
                        Card = bts.Card,
                        Rotet = bts.Rotet,
                        Di = bts.Di,
                        KeyMan = bts.KeyMan,
                        KeyDate = bts.KeyDate,
                        Mang = bts.Mang,
                        YrDays = bts.YrDays,
                        WkYrs = bts.WkYrs,
                        Saltp = bts.Saltp,
                        Jobs = bts.Jobs,
                        Workcd = bts.Workcd,
                        Carcd = bts.Carcd,
                        Empcd = bts.Empcd,
                        Outcd = bts.Outcd,
                        Calabs = bts.Calabs,
                        Calot = bts.Calot,
                        Fulatt = bts.Fulatt,
                        Noter = bts.Noter,
                        Nowel = bts.Nowel,
                        Noret = bts.Noret,
                        Notlate = bts.Notlate,
                        HoliCode = bts.HoliCode,
                        Noot = bts.Noot,
                        Nospec = bts.Nospec,
                        Nocard = bts.Nocard,
                        Noeat = bts.Noeat,
                        Apgrpcd = bts.Apgrpcd,
                        Deptm = bts.Deptm,
                        Ttscd = bts.Ttscd,
                        Meno = bts.Meno,
                        Saladr = bts.Saladr,
                        Nowage = bts.Nowage,
                        Mange = bts.Mange,
                        Retrate = bts.Retrate,
                        Retdate = bts.Retdate,
                        Retchoo = bts.Retchoo,
                        Retdate1 = bts.Retdate1,
                        Onlyontime = bts.Onlyontime,
                        Jobo = bts.Jobo,
                        CountPass = bts.CountPass,
                        PassDate = bts.PassDate,
                        Mang1 = bts.Mang1,
                        ApDate = bts.ApDate,
                        GrpAmt = bts.GrpAmt,
                        TaxDate = bts.TaxDate,
                        Nospamt = bts.Nospamt,
                        Fixrate = bts.Fixrate,
                        TaxEdate = bts.TaxEdate,
                        IsSelfout = bts.IsSelfout,
                        InsgType = bts.InsgType,
                        OldSaladr = bts.OldSaladr,
                        Station = bts.Station,
                        CardJobName = bts.CardJobName,
                        CardJobEnName = bts.CardJobEnName,
                        OilSubsidy = bts.OilSubsidy,
                        CardId = bts.CardId,
                        DoorGuard = bts.DoorGuard,
                        OutPost = bts.OutPost,
                        Nooldret = bts.Nooldret,
                        ReinstateDate = bts.ReinstateDate,
                        PassType = bts.PassType,
                        AuditDate = bts.AuditDate,
                        AssessManage1 = bts.AssessManage1,
                        AssessManage2 = bts.AssessManage2
                    };
                    attentRoteViewDtos.Add(new AttRoteViewDto()
                    {
                        EmployeeID = att.Nobr,
                        AttendDate = att.Adate,
                        RoteCode = it.ROTE.Rote1,
                        RoteName = it.ROTE.Rotename,
                        RoteOnTime = att.Adate.AddTime(it.ROTE.OnTime),
                        RoteOffTime = att.Adate.AddTime(it.ROTE.OffTime),
                        RoteRestTime = roteRestTime,
                        WorkHours = it.ROTE.WkHrs,
                        RoteOffTime2 = it.ROTE.Offtime2,
                        Attend = attendDto,
                        Basetts = basettsDto,
                        Rote = roteDto
                    });
                }
            }

            return attentRoteViewDtos;
        }

        public List<AttRoteViewDto> GetAttRoteH(List<string> EmpIds, DateTime StartDate, DateTime EndDate)
        {
            var attendRoteHs = (from att in _unitOfWork.Repository<Attend>().Reads()
                                join r in _unitOfWork.Repository<Rote>().Reads() on att.RoteH equals r.Rote1
                                join bts in _unitOfWork.Repository<Basetts>().Reads() on att.Nobr equals bts.Nobr
                                where EmpIds.Contains(att.Nobr)
                                && StartDate <= att.Adate && att.Adate <= EndDate
                                && new List<string>() { "1", "4", "6" }.Contains(bts.Ttscode)
                                && DateTime.Now.Date >= bts.Adate && DateTime.Now.Date <= bts.Ddate
                                select new { ATTEND = att, ROTE = r, BASETTS = bts }).ToList();

            List<AttRoteViewDto> attentRoteViewDtos = new List<AttRoteViewDto>();
            foreach (var it in attendRoteHs)
            {
                var att = it.ATTEND;
                var rote = it.ROTE;
                var bts = it.BASETTS;
                List<Tuple<DateTime, DateTime>> roteRestTime = new List<Tuple<DateTime, DateTime>>();
                Dictionary<string, string> RestDic = new Dictionary<string, string>();
                if (it.ROTE.ResBTime.Trim().Length > 0 && it.ROTE.ResETime.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.ResBTime))
                    RestDic.Add(it.ROTE.ResBTime, it.ROTE.ResETime);
                if (it.ROTE.ResB1Time.Trim().Length > 0 && it.ROTE.ResE1Time.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.ResB1Time))
                    RestDic.Add(it.ROTE.ResB1Time, it.ROTE.ResE1Time);
                if (it.ROTE.ResB2Time.Trim().Length > 0 && it.ROTE.ResE2Time.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.ResB2Time))
                    RestDic.Add(it.ROTE.ResB2Time, it.ROTE.ResE2Time);
                if (it.ROTE.ResB3Time.Trim().Length > 0 && it.ROTE.ResE3Time.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.ResB3Time))
                    RestDic.Add(it.ROTE.ResB3Time, it.ROTE.ResE3Time);
                if (it.ROTE.ResB4Time.Trim().Length > 0 && it.ROTE.ResE4Time.Trim().Length > 0 && !RestDic.ContainsKey(it.ROTE.ResB4Time))
                    RestDic.Add(it.ROTE.ResB4Time, it.ROTE.ResE4Time);

                foreach (var r in RestDic)
                {
                    roteRestTime.Add(new Tuple<DateTime, DateTime>(att.Adate.AddTime(r.Key), att.Adate.AddTime(r.Value)));
                }

                if (it.ROTE.OnTime.Trim().Length > 0 && it.ROTE.OffTime.Trim().Length > 0)
                {
                    RoteDto roteDto = new RoteDto()
                    {
                        RoteCode = rote.Rote1,
                        RoteDisp = rote.RoteDisp,
                        Rotename = rote.Rotename,
                        OnTime = rote.OnTime,
                        OffTime = rote.OffTime,
                        OffTime2 = rote.Offtime2,
                        AttEnd = rote.AttEnd,
                        OtBegin = rote.OtBegin,
                        Sort = rote.Sort
                    };
                    AttendDto attendDto = new AttendDto()
                    {
                        Nobr = att.Nobr,
                        Adate = att.Adate,
                        Rote = att.Rote,
                        KeyMan = att.KeyMan,
                        KeyDate = att.KeyDate,
                        LateMins = att.LateMins,
                        EMins = att.EMins,
                        Abs = att.Abs,
                        AdjCode = att.AdjCode,
                        CantAdj = att.CantAdj,
                        Ser = att.Ser,
                        NightHrs = att.NightHrs,
                        Foodamt = att.Foodamt,
                        Foodsalcd = att.Foodsalcd,
                        Forget = att.Forget,
                        AttHrs = att.AttHrs,
                        Nigamt = att.Nigamt,
                        Specamt = att.Specamt,
                        Specsalcd = att.Specsalcd,
                        Stationamt = att.Stationamt,
                        EarlyMins = att.EarlyMins,
                        DelayMins = att.DelayMins,
                        RelHrs = att.RelHrs,
                        RoteH = att.RoteH
                    };

                    BasettsDto basettsDto = new BasettsDto()
                    {
                        Nobr = bts.Nobr,
                        Adate = bts.Adate,
                        Ttscode = bts.Ttscode,
                        Ddate = bts.Ddate,
                        Indt = bts.Indt,
                        Cindt = bts.Cindt,
                        Oudt = bts.Oudt,
                        Stdt = bts.Stdt,
                        Stindt = bts.Stindt,
                        Stoudt = bts.Stoudt,
                        Comp = bts.Comp,
                        Dept = bts.Dept,
                        Depts = bts.Depts,
                        Job = bts.Job,
                        Jobl = bts.Jobl,
                        Card = bts.Card,
                        Rotet = bts.Rotet,
                        Di = bts.Di,
                        KeyMan = bts.KeyMan,
                        KeyDate = bts.KeyDate,
                        Mang = bts.Mang,
                        YrDays = bts.YrDays,
                        WkYrs = bts.WkYrs,
                        Saltp = bts.Saltp,
                        Jobs = bts.Jobs,
                        Workcd = bts.Workcd,
                        Carcd = bts.Carcd,
                        Empcd = bts.Empcd,
                        Outcd = bts.Outcd,
                        Calabs = bts.Calabs,
                        Calot = bts.Calot,
                        Fulatt = bts.Fulatt,
                        Noter = bts.Noter,
                        Nowel = bts.Nowel,
                        Noret = bts.Noret,
                        Notlate = bts.Notlate,
                        HoliCode = bts.HoliCode,
                        Noot = bts.Noot,
                        Nospec = bts.Nospec,
                        Nocard = bts.Nocard,
                        Noeat = bts.Noeat,
                        Apgrpcd = bts.Apgrpcd,
                        Deptm = bts.Deptm,
                        Ttscd = bts.Ttscd,
                        Meno = bts.Meno,
                        Saladr = bts.Saladr,
                        Nowage = bts.Nowage,
                        Mange = bts.Mange,
                        Retrate = bts.Retrate,
                        Retdate = bts.Retdate,
                        Retchoo = bts.Retchoo,
                        Retdate1 = bts.Retdate1,
                        Onlyontime = bts.Onlyontime,
                        Jobo = bts.Jobo,
                        CountPass = bts.CountPass,
                        PassDate = bts.PassDate,
                        Mang1 = bts.Mang1,
                        ApDate = bts.ApDate,
                        GrpAmt = bts.GrpAmt,
                        TaxDate = bts.TaxDate,
                        Nospamt = bts.Nospamt,
                        Fixrate = bts.Fixrate,
                        TaxEdate = bts.TaxEdate,
                        IsSelfout = bts.IsSelfout,
                        InsgType = bts.InsgType,
                        OldSaladr = bts.OldSaladr,
                        Station = bts.Station,
                        CardJobName = bts.CardJobName,
                        CardJobEnName = bts.CardJobEnName,
                        OilSubsidy = bts.OilSubsidy,
                        CardId = bts.CardId,
                        DoorGuard = bts.DoorGuard,
                        OutPost = bts.OutPost,
                        Nooldret = bts.Nooldret,
                        ReinstateDate = bts.ReinstateDate,
                        PassType = bts.PassType,
                        AuditDate = bts.AuditDate,
                        AssessManage1 = bts.AssessManage1,
                        AssessManage2 = bts.AssessManage2
                    };
                    attentRoteViewDtos.Add(new AttRoteViewDto()
                    {
                        EmployeeID = att.Nobr,
                        AttendDate = att.Adate,
                        RoteCode = it.ROTE.Rote1,
                        RoteName = it.ROTE.Rotename,
                        RoteOnTime = att.Adate.AddTime(it.ROTE.OnTime),
                        RoteOffTime = att.Adate.AddTime(it.ROTE.OffTime),
                        RoteRestTime = roteRestTime,
                        WorkHours = it.ROTE.WkHrs,
                        RoteOffTime2 = it.ROTE.Offtime2,
                        Attend = attendDto,
                        Basetts = basettsDto,
                        Rote = roteDto
                    });
                }
            }

            return attentRoteViewDtos;
        }

        public List<RoteDto> GetRote(string RoteCode)
        {
            var Repo = _unitOfWork.Repository<Rote>();
            var data = Repo.Reads().Where(x => x.Rote1 == RoteCode).Select(x => new RoteDto()
            {
                RoteCode = x.Rote1,
                RoteDisp = x.RoteDisp,
                Rotename = x.Rotename,
                OnTime = x.OnTime,
                OffTime = x.OffTime,
                OffTime2 = x.Offtime2,
                AttEnd = x.AttEnd,
                OtBegin = x.OtBegin,
                Sort = x.Sort,
            });
            return data.ToList();
        }

        public List<RoteDto> GetRotes()
        {
            var Repo = _unitOfWork.Repository<Rote>();
            var data = Repo.Reads().Select(x => new RoteDto()
            {
                RoteCode = x.Rote1,
                RoteDisp = x.RoteDisp,
                Rotename = x.Rotename,
                OnTime = x.OnTime,
                OffTime = x.OffTime,
                OffTime2 = x.Offtime2,
                AttEnd = x.AttEnd,
                OtBegin = x.OtBegin,
                Sort = x.Sort,
            });
            return data.ToList();
        }

        public ApiResult<string> UpdateAttendRote(UpdateAttendRoteEntry updateAttendRoteEntry, string keyman)
        {

            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<Attend>();
                var data = Repo.Reads().Where(x => x.Nobr == updateAttendRoteEntry.EmployeeId && x.Adate == updateAttendRoteEntry.AttendDate).FirstOrDefault();
                data.Rote = updateAttendRoteEntry.RoteCode;
                Repo.Update(data);
                Repo.SaveChanges();

                var Repo_Rotechg = _unitOfWork.Repository<Rotechg>();
                var data_Rotechg = Repo_Rotechg.Reads().Where(x => x.Nobr == updateAttendRoteEntry.EmployeeId && x.Adate == updateAttendRoteEntry.AttendDate).FirstOrDefault();

                if (data_Rotechg == null)
                {
                    Rotechg rotechg = new Rotechg()
                    {
                        Nobr = data.Nobr,
                        Adate = data.Adate,
                        Rote = data.Rote,
                        Code = "",
                        KeyDate = DateTime.Now,
                        KeyMan = keyman
                    };
                    Repo_Rotechg.Create(rotechg);
                }
                else
                {
                    data_Rotechg.Rote = updateAttendRoteEntry.RoteCode;
                    data_Rotechg.KeyDate = DateTime.Now;
                    data_Rotechg.KeyMan = keyman;
                    Repo_Rotechg.Update(data_Rotechg, x => x.Autokey);
                }
                Repo_Rotechg.SaveChanges();
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
