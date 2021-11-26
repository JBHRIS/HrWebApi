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
    public class OverTime_Test
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
                if (!context.Rote.Any())
                {
                    context.Rote.AddRange(createRoteData());
                }
                if (!context.Otrcd.Any())
                {
                    context.Otrcd.AddRange(createOtrcdData());
                }
                if (!context.Ot.Any())
                {
                    context.Ot.AddRange(createOtData());
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
        private IEnumerable<Rote> createRoteData()
        {
            yield return new Rote
            {
                Rote1 = "AHA",
                RoteDisp = "HA",
                Rotename = "早班",
                OnTime = "0800",
                OffTime = "1700",
            };
            yield return new Rote
            {
                Rote1 = "AHB",
                RoteDisp = "HB",
                Rotename = "中班",
                OnTime = "1200",
                OffTime = "2100",
            };
            yield return new Rote
            {
                Rote1 = "AHC",
                RoteDisp = "HC",
                Rotename = "晚班",
                OnTime = "1600",
                OffTime = "2500",
            };
            yield return new Rote
            {
                Rote1 = "AHD",
                RoteDisp = "HD",
                Rotename = "夜班",
                OnTime = "2000",
                OffTime = "2900",
            };
        }
        private IEnumerable<Otrcd> createOtrcdData()
        {
            yield return new Otrcd
            {
                Otrcd1 = "A01",
                OtrcdDisp = "01", 
                Otrname = "配合生產",
            };
            yield return new Otrcd
            {
                Otrcd1 = "A02",
                OtrcdDisp = "02",
                Otrname = "稽核到店",
            };
            yield return new Otrcd
            {
                Otrcd1 = "A03",
                OtrcdDisp = "03",
                Otrname = "盤點",
            };
            yield return new Otrcd
            {
                Otrcd1 = "A04",
                OtrcdDisp = "04",
                Otrname = "人手不足",
            };
        }
        private IEnumerable<Ot> createOtData()
        {
            yield return new Ot
            {
                Nobr = "00001",
                Bdate = new DateTime(2020, 10, 1),
                Btime = "1200",
                Etime = "1700",
                OtRote = "AHB",
                Otrcd = "A03",
                OtHrs = 5,
                RestHrs = 0,
                Serno = "10001",
            };
            yield return new Ot
            {
                Nobr = "00002",
                Bdate = new DateTime(2020, 10, 7),
                Btime = "1200",
                Etime = "2100",
                OtRote = "AHB",
                Otrcd = "A02",
                OtHrs = 3,
                RestHrs = 5,
                Serno = "10002",
            };
            yield return new Ot
            {
                Nobr = "00002",
                Bdate = new DateTime(2020, 10, 11),
                Btime = "0800",
                Etime = "1700",
                OtRote = "AHA",
                Otrcd = "A01",
                OtHrs = 0,
                RestHrs = 8,
                Serno = "10011",
            };
            yield return new Ot
            {
                Nobr = "00001",
                Bdate = new DateTime(2020, 10, 11),
                Btime = "1600",
                Etime = "1700",
                OtRote = "AHC",
                Otrcd = "A01",
                OtHrs = 1,
                RestHrs = 0,
                Serno = "10021",
            };
            yield return new Ot
            {
                Nobr = "00003",
                Bdate = new DateTime(2020, 10, 24),
                Btime = "1400",
                Etime = "1700",
                OtRote = "AHA",
                Otrcd = "A02",
                OtHrs = 3,
                RestHrs = 0,
                Serno = "10022",
            };
            yield return new Ot
            {
                Nobr = "00001",
                Bdate = new DateTime(2020, 10, 31),
                Btime = "1300",
                Etime = "1700",
                OtRote = "AHB",
                Otrcd = "A03",
                OtHrs = 2,
                RestHrs = 2,
                Serno = "10031",
            };
            yield return new Ot
            {
                Nobr = "00002",
                Bdate = new DateTime(2020, 10, 31),
                Btime = "2000",
                Etime = "2900",
                OtRote = "AHD",
                Otrcd = "A03",
                OtHrs = 8,
                RestHrs = 0,
                Serno = "10044",
            };
        }
        private IEnumerable<OvertimeDto> createOverTimeData()
        {
            yield return new OvertimeDto
            {
                EmployeeID = "00001",
                EmployeeName = "王小明",
                OverTimeDate = new DateTime(2020, 10, 1),
                BeginTime = "1200",
                EndTime = "1700",
                OverTimeRote = "HB",
                OverTimeRoteName = "中班",
                OverTimeReason = "盤點",
                OverTimeHours = 5,
                RestTimeHours = 0,
                SerialNumber = "10001",
            };
            yield return new OvertimeDto
            {
                EmployeeID = "00002",
                EmployeeName = "林大惠",
                OverTimeDate = new DateTime(2020, 10, 7),
                BeginTime = "1200",
                EndTime = "2100",
                OverTimeRote = "HB",
                OverTimeRoteName= "中班",
                OverTimeReason = "稽核到店",
                OverTimeHours = 3,
                RestTimeHours = 5,
                SerialNumber = "10002",
            };
            yield return new OvertimeDto
            {
                EmployeeID = "00002",
                EmployeeName = "林大惠",
                OverTimeDate = new DateTime(2020, 10, 11),
                BeginTime = "0800",
                EndTime = "1700",
                OverTimeRote = "HA",
                OverTimeRoteName = "早班",
                OverTimeReason = "配合生產",
                OverTimeHours = 0,
                RestTimeHours = 8,
                SerialNumber = "10011",
            };
            yield return new OvertimeDto
            {
                EmployeeID = "00001",
                EmployeeName = "王小明",
                OverTimeDate = new DateTime(2020, 10, 11),
                BeginTime = "1600",
                EndTime = "1700",
                OverTimeRote = "HC",
                OverTimeRoteName = "晚班",
                OverTimeReason = "配合生產",
                OverTimeHours = 1,
                RestTimeHours = 0,
                SerialNumber = "10021",
            };
            yield return new OvertimeDto
            {
                EmployeeID = "00003",
                EmployeeName = "黃一二",
                OverTimeDate = new DateTime(2020, 10, 24),
                BeginTime = "1400",
                EndTime = "1700",
                OverTimeRote = "HA",
                OverTimeRoteName = "早班",
                OverTimeReason = "稽核到店",
                OverTimeHours = 3,
                RestTimeHours = 0,
                SerialNumber = "10022",
            };
            yield return new OvertimeDto
            {
                EmployeeID = "00001",
                EmployeeName = "王小明",
                OverTimeDate = new DateTime(2020, 10, 31),
                BeginTime = "1300",
                EndTime = "1700",
                OverTimeRote = "HB",
                OverTimeRoteName = "中班",
                OverTimeReason = "盤點",
                OverTimeHours = 2,
                RestTimeHours = 2,
                SerialNumber = "10031",
            };
            yield return new OvertimeDto
            {
                EmployeeID = "00002",
                EmployeeName = "林大惠",
                OverTimeDate = new DateTime(2020, 10, 31),
                BeginTime = "2000",
                EndTime = "2900",
                OverTimeRote = "HD",
                OverTimeRoteName = "夜班",
                OverTimeReason = "盤點",
                OverTimeHours = 8,
                RestTimeHours = 0,
                SerialNumber = "10044",
            };
        }
        #endregion
        [TestMethod]
        public void GeOverTimeData()
        {
            JBHRContext context = _context;
            Range range = ..3;
            IEnumerable<Base> sourceBase = createBaseData().ToArray()[range];
            range = ..4;
            IEnumerable<Rote> sourceRote = createRoteData().ToArray()[range];
            range = ..4;
            IEnumerable<Otrcd> sourceOtrcd = createOtrcdData().ToArray()[range];
            range = ..7;
            IEnumerable<Ot> sourceOt = createOtData().ToArray()[range];
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            IOverTimeRepository dal = new OverTimeRepository(unitOfWork);
            #region GetAll
            {
                List<string> targetEmployees = sourceBase.Select(o => o.Nobr).ToList();
                DateTime BeginTime = DateTime.MinValue;
                DateTime EndTime = DateTime.MaxValue;
                AttendanceEntry attendanceEntry = new AttendanceEntry();
                attendanceEntry.EmployeeList = targetEmployees;
                attendanceEntry.DateBegin = BeginTime;
                attendanceEntry.DateEnd = EndTime;
                List<OvertimeDto> result = dal.GetOvertime(attendanceEntry);
                Assert.IsTrue(result.Count == 7, "預期數量不符合");
                List<OvertimeDto> answerList = createOverTimeData().ToList();
                Assert.IsTrue(result.Where(c => !answerList.Contains(c)).Count() > 0, "員工清單不相符");
                Assert.IsTrue(answerList.Where(c => !result.Contains(c)).Count() > 0, "員工清單不相符");
            }
            #endregion
            #region EmployeeID = 00001
            {
                List<string> targetEmployees = sourceBase.Where(p => p.Nobr == "00001").Select(o => o.Nobr).ToList();
                DateTime BeginTime = DateTime.MinValue;
                DateTime EndTime = DateTime.MaxValue;
                AttendanceEntry attendanceEntry = new AttendanceEntry();
                attendanceEntry.EmployeeList = targetEmployees;
                attendanceEntry.DateBegin = BeginTime;
                attendanceEntry.DateEnd = EndTime;
                List<OvertimeDto> result = dal.GetOvertime(attendanceEntry);
                Assert.IsTrue(result.Count == 3, "預期數量不符合");
                List<OvertimeDto> answerList = createOverTimeData().Where(p => p.EmployeeID == "00001").ToList();
                Assert.IsTrue(result.Where(c => !answerList.Contains(c)).Count() > 0, "員工清單不相符");
                Assert.IsTrue(answerList.Where(c => !result.Contains(c)).Count() > 0, "員工清單不相符");
            }
            #endregion
            #region 2020/10/01 ~ 2020/10/15
            {
                List<string> targetEmployees = sourceBase.Select(o => o.Nobr).ToList();
                DateTime BeginTime = new DateTime(2020, 10, 1);
                DateTime EndTime = new DateTime(2020, 10, 15);
                AttendanceEntry attendanceEntry = new AttendanceEntry();
                attendanceEntry.EmployeeList = targetEmployees;
                attendanceEntry.DateBegin = BeginTime;
                attendanceEntry.DateEnd = EndTime;
                List<OvertimeDto> result = dal.GetOvertime(attendanceEntry);
                Assert.IsTrue(result.Count == 4, "預期數量不符合");
                List<OvertimeDto> answerList = createOverTimeData().Where(p => p.OverTimeDate >= BeginTime && p.OverTimeDate <= EndTime).ToList();
                Assert.IsTrue(result.Where(c => !answerList.Contains(c)).Count() > 0, "員工清單不相符");
                Assert.IsTrue(answerList.Where(c => !result.Contains(c)).Count() > 0, "員工清單不相符");
            }
            #endregion
        }
    }
}
