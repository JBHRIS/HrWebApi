using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
namespace JBHRIS.BLL.Att
{
    public class AbsenceRequestController
    {
        public static string UnitOfHours = "小時";
        public static string UnitOfDays = "天";
        public static string CreateMan = "";
        //public static Repo.AttendanceInfoRepo AttendanceInfoRepo = new Repo.AttendanceInfoRepo();
        public static Repo.AttendRepo AttendRepo = new Repo.AttendRepo();
        public static Repo.RoteRepo RoteRepo = new Repo.RoteRepo();
        public static Repo.LeaveCodeRepo LeaveCodeRepo;
        public static Repo.AbsRepo AbsRepo;
        public static Repo.AbsEntitleRepo AbsEntitleRepo;
        public static Repo.AttendanceLockRepo AttendanceLockRepo;
        public AbsenceRequestController()
        {
            AttendRepo = IOC.Container.Resolve<JBHRIS.BLL.Repo.AttendRepo>();
            RoteRepo = IOC.Container.Resolve<JBHRIS.BLL.Repo.RoteRepo>();
            LeaveCodeRepo = IOC.Container.Resolve<JBHRIS.BLL.Repo.LeaveCodeRepo>();
            AbsRepo = IOC.Container.Resolve<JBHRIS.BLL.Repo.AbsRepo>();
            AbsEntitleRepo = IOC.Container.Resolve<JBHRIS.BLL.Repo.AbsEntitleRepo>();
            AttendanceLockRepo = IOC.Container.Resolve<JBHRIS.BLL.Repo.AttendanceLockRepo>();

        }
        public List<Dto.AttendDto> GetAttendanceInfoList(Dto.AbsenceRequestCondition Condition)
        {
            Dto.AttendCondition cond = new Dto.AttendCondition();
            cond.EmployeeList.Add(Condition.EmployeeID);
            cond.DateBegin = Condition.DateBegin.Date;
            cond.DateEnd = Condition.DateEnd.Date;
            var results = AttendRepo.GetDataByCondition(cond);
            return results;
        }
        public List<Dto.AbsDto> GetAbsTakenDtoList(Dto.AbsenceRequestCondition Condition)
        {
            List<Dto.AbsDto> results = new List<Dto.AbsDto>();
            var attInfo = GetAttendanceInfoList(Condition);
            var leavecode = LeaveCodeRepo.GetInstanceByID(Condition.LeaveCode);
            //var empRepo = IOC.Container.Resolve<JBHRIS.BLL.Repo.EmpAttRepo>();
            if (leavecode != null)
            {
                //var emp = empRepo.GetInstanceByID(Condition.EmployeeID);
                foreach (var ai in attInfo)
                {
                    if (ai.WorkTimes.Any())
                    {
                        JBTools.Intersection its = new JBTools.Intersection();
                        its.Inert(ai.WorkTimes.First().Item1, ai.WorkTimes.Last().Item2);
                        its.Inert(Condition.DateBegin, Condition.DateEnd);
                        DateTime t1, t2;
                        t1 = its.TimeBegin;
                        t2 = its.TimeEnd;
                        List<Tuple<DateTime, DateTime>> checkTimes = new List<Tuple<DateTime, DateTime>>();

                        foreach (var it in ai.WorkTimes)//整理出請假時段
                        {
                            JBTools.Intersection chkIts = new JBTools.Intersection();
                            chkIts.Inert(it.Item1, it.Item2);
                            chkIts.Inert(Condition.DateBegin, Condition.DateEnd);
                            checkTimes.Add(new Tuple<DateTime, DateTime>(chkIts.TimeBegin, chkIts.TimeEnd));
                        }
                        var lst = JBTools.DataTransform.GetAbsenteeismList(checkTimes, ai.RestTimes);
                        decimal hrs = 0;
                        foreach (var it in lst)
                        {
                            JBTools.Intersection chkIts = new JBTools.Intersection();
                            chkIts.Inert(it.Item1, it.Item2);
                            hrs += chkIts.GetHours();
                        }
                        string guid = Guid.NewGuid().ToString();
                        Dto.AbsDto abs = new Dto.AbsDto
                        {
                            AttendanceDate = ai.AttendanceDate,
                            CreateTime = DateTime.Now,
                            //EmployeeName = emp != null ? emp.EmployeeName : "",
                            BeginTime = t1,
                            EndTime = t2,
                            EmployeeID = Condition.EmployeeID,
                            CreateMan = CreateMan,
                            //Guid = guid,
                            HolidayCode = Condition.LeaveCode,
                            //PrimaryKey = guid,
                            Remark = Condition.Remark,
                            //Serno = "",
                            Taken = hrs,
                            YYMM = AttendanceLockRepo.GetYYMM(Condition.EmployeeID, ai.AttendanceDate),
                            HolidayName = "",
                            ID = Guid.NewGuid().ToString(),
                            SerialNumber = Condition.SerialNumber,
                        };
                        if (abs.BeginTime < abs.EndTime)
                            results.Add(abs);
                    }
                }
            }
            else
            {
                throw new Exception("無效的假別代碼" + Condition.LeaveCode);
            }
            return results;
        }
        public bool InsertAbsence(Dto.AbsenceRequestCondition Condition, out string ErrorMessage)
        {
            var absList = GetAbsTakenDtoList(Condition);
            if (!absList.Any())
            {
                ErrorMessage = "無效的請假時段";
                return false;
            }
            foreach (var it in absList)
                it.CreateMan = CreateMan;
            if (absList.Count == 1)
                absList.First().Taken = Condition.CustomizeTaken;
            if (!AbsRepo.Insert(absList, out ErrorMessage))
                return false;
            return true;
        }
        public bool UpdateAbsence(Dto.AbsenceRequestCondition Condition, Dto.AbsDto Instance, out string ErrorMessage)
        {
            var absList = GetAbsTakenDtoList(Condition);
            if (absList.Count() > 1)
            {
                ErrorMessage = "修改請假資料不可跨出勤日";
                return false;
            }
            if (!absList.Any())
            {
                ErrorMessage = "請假時間未落在上班時間內";
                return false;
            }
            Instance.CreateMan = CreateMan;
            var abs = absList.First();
            Instance.AttendanceDate = abs.AttendanceDate;
            Instance.BeginTime = abs.BeginTime;
            Instance.EndTime = abs.EndTime;
            Instance.HolidayCode = abs.HolidayCode;
            Instance.Remark = abs.Remark;
            Instance.SerialNumber = abs.SerialNumber;
            Instance.Taken = abs.Taken;
            Instance.YYMM = abs.YYMM;
            Instance.Taken = Condition.CustomizeTaken;
            Instance.CreateTime = DateTime.Now;
            if (!AbsRepo.Update(Instance, out ErrorMessage))
                return false;
            return true;
        }
        public virtual bool CheckConflict(List<Dto.AbsDto> AbsList, out string ErrorMessage)
        {
            ErrorMessage = "";
            if (CheckBalanceConflick(AbsList, out  ErrorMessage))
                return true;
            if (CheckTimeConflick(AbsList, out  ErrorMessage))
                return true;
            return false;
        }
        protected virtual bool CheckTimeConflick(List<Dto.AbsDto> AbsList, out string ErrorMessage)
        {
            ErrorMessage = "";
            var hcodeAll = LeaveCodeRepo.GetDataByAll();
            foreach (var it in AbsList)
            {
                Dto.AbsCondition cond = new Dto.AbsCondition();
                cond.EmployeeList = new List<string>();
                cond.EmployeeList.Add(it.EmployeeID);
                cond.DateBegin = it.BeginTime;
                cond.DateEnd = it.EndTime;
                cond.HolidayCodeList = hcodeAll.Select(p => p.LeaveCode).ToList();
                var conflcts = AbsRepo.GetDataByCondition(cond).Where(p => p.ID != it.ID);
                if (conflcts.Any())
                {
                    foreach (var r in conflcts)
                        ErrorMessage += "時段衝突" + it.EmployeeID + "," + it.HolidayName + "，" + it.BeginTime.ToString("yyyy/MM/dd HH:mm") + "~" + it.EndTime.ToString("yyyy/MM/dd HH:mm") + Environment.NewLine;
                }
            }
            if (ErrorMessage.Trim().Length > 0)
                return true;
            return false;
        }
        protected virtual bool CheckBalanceConflick(List<Dto.AbsDto> AbsList, out string ErrorMessage)
        {
            ErrorMessage = "";
            if (AbsList.Any())
            {
                var hcode = LeaveCodeRepo.GetInstanceByID(AbsList.First().HolidayCode);
                if (hcode.CheckBalance)
                {
                    var abs = AbsList[0];
                    var EmployeeList = new List<string>();
                    EmployeeList.Add(abs.EmployeeID);
                    var HolidayType = new List<string>();
                    HolidayType.Add(hcode.LeaveType);
                    decimal totalTaken = AbsList.Sum(p => p.Taken);
                    var cond = new Dto.AbsEntitleCondition { EmployeeList = EmployeeList, DateBegin = abs.AttendanceDate, DateEnd = abs.AttendanceDate, HolidayCodeList = HolidayType };
                    var entitles = AbsEntitleRepo.GetDataByCondition(cond);
                    decimal totalBalance = entitles.Sum(p => p.Balance);
                    if (totalBalance < totalTaken)
                    {
                        ErrorMessage = string.Format("剩餘時數不足({0},{1})", totalBalance, totalTaken);
                        return true;
                    }
                }
            }
            return false;
        }


    }
}
