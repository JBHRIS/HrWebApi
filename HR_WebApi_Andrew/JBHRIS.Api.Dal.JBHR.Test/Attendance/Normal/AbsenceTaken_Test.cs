using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Test.Attendance.Normal
{
    [TestClass]
    public class AbsenceTaken_Test
    {
        private JBHRContext _context
        {
            get
            {
                DbContextOptions<JBHRContext> options = new DbContextOptionsBuilder<JBHRContext>()
                    .UseInMemoryDatabase("HR")
                    .Options;
                JBHRContext context = new JBHRContext(options);
                if (!context.Base.Any())
                {
                    context.Base.AddRange(createBaseData());
                }
                if (!context.Hcode.Any())
                {
                    context.Hcode.AddRange(createHcodeData());
                }
                if (!context.Abs.Any())
                {
                    context.Abs.AddRange(createAbsData());
                }
                context.SaveChanges();
                return context;
            }
        }
        #region TestData
        private IEnumerable<Base> createBaseData()
        {
            yield return new Base
            {
                Nobr = "00001",
                NameC = "王小明"
            };
            yield return new Base
            {
                Nobr = "00002",
                NameC = "林大惠"
            };
            yield return new Base
            {
                Nobr = "00003",
                NameC = "黃一二"
            };
        }
        private IEnumerable<Hcode> createHcodeData()
        {
            yield return new Hcode
            {
                HCode1 = "AHA",
                HCodeDisp = "HA",
                HName = "特休假",
                Unit = "天",
                Flag = "-"
            };
            yield return new Hcode
            {
                HCode1 = "AHA1",
                HCodeDisp = "HA1",
                HName = "特休假(得)",
                Unit = "天",
                Flag = "+"
            };
            yield return new Hcode
            {
                HCode1 = "AHB",
                HCodeDisp = "HB",
                HName = "病假",
                Unit = "小時",
                Flag = "-"
            };
            yield return new Hcode
            {
                HCode1 = "AHB1",
                HCodeDisp = "HB1",
                HName = "病假(得)",
                Unit = "小時",
                Flag = "+"
            };
            yield return new Hcode
            {
                HCode1 = "AHC",
                HCodeDisp = "HC",
                HName = "事假",
                Unit = "小時",
                Flag = "-"
            };
            yield return new Hcode
            {
                HCode1 = "AHC1",
                HCodeDisp = "HC1",
                HName = "事假(得)",
                Unit = "小時",
                Flag = "+"
            };
        }
        private IEnumerable<Abs> createAbsData()
        {
            yield return new Abs
            {
                Nobr = "00001",
                Bdate = new DateTime(2020, 9, 1),
                Edate = new DateTime(2020, 9, 1),
                Btime = "0800",
                Etime = "1700",
                HCode = "AHB",
                TolHours = 8,
            };
            yield return new Abs
            {
                Nobr = "00001",
                Bdate = new DateTime(2020, 1, 1),
                Edate = new DateTime(2020, 12, 31),
                Btime = "",
                Etime = "",
                HCode = "AHB1",
                TolHours = 208,
            };
            yield return new Abs
            {
                Nobr = "00001",
                Bdate = new DateTime(2020, 9, 6),
                Edate = new DateTime(2020, 9, 6),
                Btime = "1300",
                Etime = "1800",
                HCode = "AHC",
                TolHours = 5,
            };
            yield return new Abs
            {
                Nobr = "00002",
                Bdate = new DateTime(2020, 9, 15),
                Edate = new DateTime(2020, 9, 15),
                Btime = "0800",
                Etime = "2100",
                HCode = "AHC",
                TolHours = 8,
            };
            yield return new Abs
            {
                Nobr = "00001",
                Bdate = new DateTime(2020, 9, 15),
                Edate = new DateTime(2020, 9, 15),
                Btime = "0800",
                Etime = "2100",
                HCode = "AHB",
                TolHours = 8,
            };
            yield return new Abs
            {
                Nobr = "00003",
                Bdate = new DateTime(2020, 9, 23),
                Edate = new DateTime(2021, 9, 22),
                Btime = "",
                Etime = "",
                HCode = "AHB1",
                TolHours = 112,
            };
            yield return new Abs
            {
                Nobr = "00002",
                Bdate = new DateTime(2020, 9, 30),
                Edate = new DateTime(2020, 9, 30),
                Btime = "0800",
                Etime = "2100",
                HCode = "AHC",
                TolHours = 8,
            };
        }
        private IEnumerable<AbsenceTakenDto> createAbsenceTakenData()
        {
            yield return new AbsenceTakenDto
            {
                EmployeeID = "00001",
                EmployeeName = "王小明",
                HolidayCode = "HB",
                HolidayName = "病假",
                BeginDate = new DateTime(2020, 9, 1),
                EndDate = new DateTime(2020, 9, 1),
                BeginTime = "0800",
                EndTime = "1700",
                AbsenceAmount = 8,
                AbsenceUnit = "小時"
            };
            //yield return new AbsenceTakenDto
            //{
            //    EmployeeID = "00001",
            //    EmployeeName = "王小明",
            //    HolidayCode = "HB1",
            //    HolidayName = "病假(得)",
            //    BeginDate = new DateTime(2020, 1, 1),
            //    EndDate = new DateTime(2020, 12, 31),
            //    BeginTime = "",
            //    EndTime = "",
            //    AbsenceAmount = 208,
            //    AbsenceUnit = "小時"
            //};
            yield return new AbsenceTakenDto
            {
                EmployeeID = "00001",
                EmployeeName = "王小明",
                HolidayCode = "HC",
                HolidayName = "事假",
                BeginDate = new DateTime(2020, 9, 6),
                EndDate = new DateTime(2020, 9, 6),
                BeginTime = "1300",
                EndTime = "1800",
                AbsenceAmount = 5,
                AbsenceUnit = "小時"
            };
            yield return new AbsenceTakenDto
            {
                EmployeeID = "00002",
                EmployeeName = "林大惠",
                HolidayCode = "HC",
                HolidayName = "事假",
                BeginDate = new DateTime(2020, 9, 15),
                EndDate = new DateTime(2020, 9, 15),
                BeginTime = "0800",
                EndTime = "2100",
                AbsenceAmount = 8,
                AbsenceUnit = "小時"
            };
            yield return new AbsenceTakenDto
            {
                EmployeeID = "00001",
                EmployeeName = "王小明",
                HolidayCode = "HB",
                HolidayName = "病假",
                BeginDate = new DateTime(2020, 9, 15),
                EndDate = new DateTime(2020, 9, 15),
                BeginTime = "0800",
                EndTime = "2100",
                AbsenceAmount = 8,
                AbsenceUnit = "小時"
            };
            //yield return new AbsenceTakenDto
            //{
            //    EmployeeID = "00003",
            //    EmployeeName = "黃一二",
            //    HolidayCode = "HB1",
            //    HolidayName = "病假(得)",
            //    BeginDate = new DateTime(2020, 9, 23),
            //    EndDate = new DateTime(2021, 9, 22),
            //    BeginTime = "",
            //    EndTime = "",
            //    AbsenceAmount = 112,
            //    AbsenceUnit = "小時"
            //};
            yield return new AbsenceTakenDto
            {
                EmployeeID = "00002",
                EmployeeName = "林大惠",
                HolidayCode = "HC",
                HolidayName = "事假",
                BeginDate = new DateTime(2020, 9, 30),
                EndDate = new DateTime(2020, 9, 30),
                BeginTime = "0800",
                EndTime = "2100",
                AbsenceAmount = 8,
                AbsenceUnit = "小時"
            };
        }
        #endregion

        [TestMethod]
        public void GetAbsenceTakenData()
        {
            JBHRContext context = _context;
            Range range = ..3;
            IEnumerable<Base> sourceBase = createBaseData().ToArray()[range];
            range = ..6;
            IEnumerable<Hcode> sourceHCode = createHcodeData().ToArray()[range];
            range = ..7;
            IEnumerable<Abs> sourceAbs = createAbsData().ToArray()[range];
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            IAbsenceTakenRepository dal = new AbsenceTakenRepository(unitOfWork);
            #region GetAll
            {
                List<string> targetEmployees = sourceBase.Select(o => o.Nobr).ToList();
                List<string> targetHcodeList = sourceHCode.Select(o => o.HCodeDisp).ToList();
                DateTime BeginTime = DateTime.MinValue;
                DateTime EndTime = DateTime.MaxValue;
                AbsenceEntry absenceEntry = new AbsenceEntry();
                absenceEntry.EmployeeList = targetEmployees;
                absenceEntry.HcodeList = targetHcodeList;
                absenceEntry.DateBegin = BeginTime;
                absenceEntry.DateEnd = EndTime;
                List<AbsenceTakenDto> result = dal.GetAbsenceTaken(absenceEntry);
                Assert.IsTrue(result.Count == 5, "預期數量不符合");
                List<AbsenceTakenDto> answerList = createAbsenceTakenData().ToList();
                Assert.IsTrue(result.Where(c => !answerList.Contains(c)).Count() > 0, "員工清單不相符");
                Assert.IsTrue(answerList.Where(c => !result.Contains(c)).Count() > 0, "員工清單不相符");
            }
            #endregion
            #region EmployeeID = 00001
            {
                List<string> targetEmployees = sourceBase.Where(p => p.Nobr == "00001").Select(o => o.Nobr).ToList();
                List<string> targetHcodeList = sourceHCode.Select(o => o.HCodeDisp).ToList();
                DateTime BeginTime = DateTime.MinValue;
                DateTime EndTime = DateTime.MaxValue;
                AbsenceEntry absenceEntry = new AbsenceEntry();
                absenceEntry.EmployeeList = targetEmployees;
                absenceEntry.HcodeList = targetHcodeList;
                absenceEntry.DateBegin = BeginTime;
                absenceEntry.DateEnd = EndTime;
                List<AbsenceTakenDto> result = dal.GetAbsenceTaken(absenceEntry);
                Assert.IsTrue(result.Count == 3, "預期數量不符合");
                List<AbsenceTakenDto> answerList = createAbsenceTakenData().Where(p => p.EmployeeID == "00001").ToList();
                Assert.IsTrue(result.Where(c => !answerList.Contains(c)).Count() > 0, "員工清單不相符");
                Assert.IsTrue(answerList.Where(c => !result.Contains(c)).Count() > 0, "員工清單不相符");
            }
            #endregion
            #region 2020/09/01 ~ 2020/09/15
            {
                List<string> targetEmployees = sourceBase.Select(o => o.Nobr).ToList();
                List<string> targetHcodeList = sourceHCode.Select(o => o.HCodeDisp).ToList();
                DateTime BeginTime = new DateTime(2020, 9, 1);
                DateTime EndTime = new DateTime(2020, 9, 15);
                AbsenceEntry absenceEntry = new AbsenceEntry();
                absenceEntry.EmployeeList = targetEmployees;
                absenceEntry.HcodeList = targetHcodeList;
                absenceEntry.DateBegin = BeginTime;
                absenceEntry.DateEnd = EndTime;
                List<AbsenceTakenDto> result = dal.GetAbsenceTaken(absenceEntry);
                Assert.IsTrue(result.Count == 4, "預期數量不符合");
                List<AbsenceTakenDto> answerList = createAbsenceTakenData().Where(p => p.BeginDate >= BeginTime && p.EndDate <= EndTime).ToList();
                Assert.IsTrue(result.Where(c => !answerList.Contains(c)).Count() > 0, "員工清單不相符");
                Assert.IsTrue(answerList.Where(c => !result.Contains(c)).Count() > 0, "員工清單不相符");
            }
            #endregion
            #region HCode = { HA, HB }
            {
                List<string> targetEmployees = sourceBase.Select(o => o.Nobr).ToList();
                List<string> targetHcodeList = new List<string>() { "HA", "HB" };
                DateTime BeginTime = DateTime.MinValue;
                DateTime EndTime = DateTime.MaxValue;
                AbsenceEntry absenceEntry = new AbsenceEntry();
                absenceEntry.EmployeeList = targetEmployees;
                absenceEntry.HcodeList = targetHcodeList;
                absenceEntry.DateBegin = BeginTime;
                absenceEntry.DateEnd = EndTime;
                List<AbsenceTakenDto> result = dal.GetAbsenceTaken(absenceEntry);
                Assert.IsTrue(result.Count == 2, "預期數量不符合");
                List<AbsenceTakenDto> answerList = createAbsenceTakenData().Where(p => targetHcodeList.Contains(p.HolidayCode)).ToList();
                Assert.IsTrue(result.Where(c => !answerList.Contains(c)).Count() > 0, "員工清單不相符");
                Assert.IsTrue(answerList.Where(c => !result.Contains(c)).Count() > 0, "員工清單不相符");
            }
            #endregion
        }
    }
}
