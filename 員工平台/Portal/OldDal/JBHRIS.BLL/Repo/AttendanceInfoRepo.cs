using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Repo
{
    public class AttendanceInfoRepo : IRepository<JBHRIS.BLL.Dto.AttendanceInfoDto, JBHRIS.BLL.Dto.AttendanceInfoCondition>
    {
        public static Repo.EmpAttRepo EmpAttRepo;
        public static Repo.AttendRepo AttendRepo;
        public static Repo.RoteRepo RoteRepo;
        public static Repo.CardRepo CardRepo;
        public static Repo.AttendCardRepo AttendCardRepo;
        public static Repo.OtRepo OtRepo;
        public static Repo.AbsRepo AbsRepo;
        public static Att.TransformCard TransformCard = new Att.TransformCard();
        public static Att.CheckAttendanceError CheckAttendanceError = new Att.CheckAttendanceError();
        #region IRepository<AttendanceInfoDto,AttendanceInfoCondition> 成員

        public bool Insert(Dto.AttendanceInfoDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public bool Update(Dto.AttendanceInfoDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Dto.AttendanceInfoDto instance, out string Msg)
        {
            throw new NotImplementedException();
        }

        public Dto.AttendanceInfoDto GetInstanceByID(object id)
        {
            throw new NotImplementedException();
        }

        public List<Dto.AttendanceInfoDto> GetDataByCondition(Dto.AttendanceInfoCondition condition)
        {
            Dto.EmpAttCondition empCond = new Dto.EmpAttCondition();
            empCond.EmployeeList = condition.EmployeeList;
            empCond.CheckDate = condition.DateEnd;
            var empList = EmpAttRepo.GetDataByCondition(empCond);

            Dto.AttendCondition attCond = new Dto.AttendCondition();
            attCond.EmployeeList = condition.EmployeeList;
            attCond.DateBegin = condition.DateBegin;
            attCond.DateEnd = condition.DateEnd;
            var attList = AttendRepo.GetDataByCondition(attCond);

            Dto.RoteCondition roteCond = new Dto.RoteCondition();
            var roteList = RoteRepo.GetDataByCondition(roteCond);

            Dto.AttcardCondition attcardCond = new Dto.AttcardCondition();
            attcardCond.EmployeeList = condition.EmployeeList;
            attcardCond.DateBegin = condition.DateBegin;
            attcardCond.DateEnd = condition.DateEnd;
            var attcardList = AttendCardRepo.GetDataByCondition(attcardCond);

            Dto.CardCondition cardCond = new Dto.CardCondition();
            cardCond.EmployeeList = condition.EmployeeList;
            cardCond.DateBegin = condition.DateBegin;
            cardCond.DateEnd = condition.DateEnd;
            var cardList = CardRepo.GetDataByCondition(cardCond);

            Dto.OtCondition otCond = new Dto.OtCondition();
            otCond.EmployeeList = condition.EmployeeList;
            otCond.DateBegin = condition.DateBegin;
            otCond.DateEnd = condition.DateEnd;
            var otList = OtRepo.GetDataByCondition(otCond);

            Dto.AbsCondition absCond = new Dto.AbsCondition();
            absCond.EmployeeList = condition.EmployeeList;
            absCond.DateBegin = condition.DateBegin;
            absCond.DateEnd = condition.DateEnd;
            var absList = AbsRepo.GetDataByCondition(absCond);
            List<Dto.AttendanceInfoDto> results = new List<Dto.AttendanceInfoDto>();
            foreach (var gp in attList.GroupBy(pp => pp.EmployeeID))
            {
                DateTime chkTime = new DateTime(1900, 1, 1);
                foreach (var it in gp)
                {
                    var r = new Dto.AttendanceInfoDto
                    {
                        EmployeeID = it.EmployeeID,
                        AttendanceDate = it.AttendanceDate,
                        RestTimes = it.RestTimes,
                        RoteCode = it.RoteCode,
                        OtRestTimes = it.OtRestTimes,
                        WorkTimes = it.WorkTimes,
                        EmployeeName = "",
                        Absenteeism = it.Absenteeism,
                        AbsTimes = new List<Tuple<DateTime, DateTime>>(),
                        CardList = new List<Dto.CardDto>(),
                        CardTimes = new List<Dto.AttcardDto>(),
                        EarilyMinutes = it.EarilyMinutes,
                        LateMinutes = it.LateMinutes,
                        OverTimes = new List<Tuple<DateTime, DateTime>>(),
                        Rote = new Dto.RoteDto(),
                        LastCardTime = it.AttendanceDate.AddDays(1).AddMilliseconds(-1),
                        RoteName = "",
                        Remark = "",
                        FlexibleMins = it.FlexibleMins,
                        NeedUpdate = true,//Set For Fast Mode
                        CheckError = it.CheckError,
                    };
                    var emp = empList.SingleOrDefault(p => p.EmployeeID == it.EmployeeID);
                    if (emp != null)
                    {
                        r.EmployeeName = emp.EmployeeName;
                    }
                    var rote = roteList.SingleOrDefault(p => p.Rote == it.RoteCode);
                    if (rote != null)
                    {
                        r.Rote = rote;
                        var chk = r.AttendanceDate.AddDays(1);
                        r.LastCardTime = new DateTime(chk.Year, chk.Month, chk.Day, chk.Hour, chk.Minute, chk.Second);
                    }
                    var cards = cardList.Where(p => p.EmployeeID == it.EmployeeID && p.CardTime >= it.FirstCardTime && p.CardTime <= it.LastCardTime);
                    if (cards.Any())
                    {
                        r.CardList = cards.ToList();
                    }
                    var attcard = attcardList.Where(p => p.EmployeeID == it.EmployeeID && p.AttendanceDate == r.AttendanceDate);
                    if (attcard.Any())
                    {
                        r.CardTimes = attcard.ToList();
                    }
                    var abs = absList.Where(p => p.EmployeeID == it.EmployeeID && p.AttendanceDate == r.AttendanceDate);
                    if (abs.Any())
                    {
                        r.AbsTimes = abs.Select(p => new Tuple<DateTime, DateTime>(p.BeginTime, p.EndTime)).ToList();
                    }
                    var ot = otList.Where(p => p.EmployeeID == it.EmployeeID && p.AttendanceDate == r.AttendanceDate);
                    if (abs.Any())
                    {
                        r.OverTimes = ot.Select(p => new Tuple<DateTime, DateTime>(p.BeginTime, p.EndTime)).ToList();
                    }
                    if (condition.RefreshStatus)
                    {
                        //TransformCard.TransCard(r);
                        //CheckAttendanceError.CheckError(r);
                    }
                    results.Add(r);
                }
                //results.Add(rr);
            }
            return results;
            //return null;
        }

        #endregion
    }
}
