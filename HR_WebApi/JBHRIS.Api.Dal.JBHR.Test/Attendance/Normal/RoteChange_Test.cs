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
    public class RoteChange_Test
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
                if (!context.Rotechg.Any())
                {
                    context.Rotechg.AddRange(createRotechgData());
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
                Rote1 = "A01",
                RoteDisp = "01",
                Rotename = "平日早班",
            };
            yield return new Rote
            {
                Rote1 = "A02",
                RoteDisp = "02",
                Rotename = "平日中班",
            };
            yield return new Rote
            {
                Rote1 = "A03",
                RoteDisp = "03",
                Rotename = "平日晚班",
            };
        }
        private IEnumerable<Rotechg> createRotechgData()
        {
            yield return new Rotechg
            {
                Nobr = "00001",
                Adate = new DateTime(2020, 9, 1),
                Rote = "A01",
                Autokey = 1,
            };
            yield return new Rotechg
            {
                Nobr = "00001",
                Adate = new DateTime(2020, 9, 2),
                Rote = "A02",
                Autokey = 2,
            };
            yield return new Rotechg
            {
                Nobr = "00001",
                Adate = new DateTime(2020, 9, 3),
                Rote = "A03",
                Autokey = 3,
            };
            yield return new Rotechg
            {
                Nobr = "00001",
                Adate = new DateTime(2020, 9, 5),
                Rote = "A02",
                Autokey = 4,
            };
            yield return new Rotechg
            {
                Nobr = "00002",
                Adate = new DateTime(2020, 9, 10),
                Rote = "A03",
                Autokey = 5,
            };
            yield return new Rotechg
            {
                Nobr = "00003",
                Adate = new DateTime(2020, 9, 23),
                Rote = "A03",
                Autokey = 6,
            };
            yield return new Rotechg
            {
                Nobr = "00002",
                Adate = new DateTime(2020, 9, 23),
                Rote = "A02",
                Autokey = 7,
            };
        }

        private IEnumerable<RoteChangeDto> createRoteChangeData()
        {
            yield return new RoteChangeDto
            {
                EmployeeID = "00001",
                EmployeeName = "王小明",
                RoteChangeDate = new DateTime(2020, 9, 1),
                Rote = "01",
                RoteName = "平日早班",
                AutoKey = 1,
            };
            yield return new RoteChangeDto
            {
                EmployeeID = "00001",
                EmployeeName = "王小明",
                RoteChangeDate = new DateTime(2020, 9, 2),
                Rote = "02",
                RoteName = "平日中班",
                AutoKey = 2,
            };
            yield return new RoteChangeDto
            {
                EmployeeID = "00001",
                EmployeeName = "王小明",
                RoteChangeDate = new DateTime(2020, 9, 3),
                Rote = "03",
                RoteName = "平日晚班",
                AutoKey = 3,
            };
            yield return new RoteChangeDto
            {
                EmployeeID = "00001",
                EmployeeName = "王小明",
                RoteChangeDate = new DateTime(2020, 9, 5),
                Rote = "02",
                RoteName = "平日中班",
                AutoKey = 4,
            };
            yield return new RoteChangeDto
            {
                EmployeeID = "00002",
                EmployeeName = "林大惠",
                RoteChangeDate = new DateTime(2020, 9, 10),
                Rote = "03",
                RoteName = "平日晚班",
                AutoKey = 5,
            };
            yield return new RoteChangeDto
            {
                EmployeeID = "00003",
                EmployeeName = "黃一二",
                RoteChangeDate = new DateTime(2020, 9, 23),
                Rote = "03",
                RoteName = "平日晚班",
                AutoKey = 6,
            };
            yield return new RoteChangeDto
            {
                EmployeeID = "00002",
                EmployeeName = "林大惠",
                RoteChangeDate = new DateTime(2020, 9, 23),
                Rote = "02",
                RoteName = "平日中班",
                AutoKey = 7,
            };
        }
        #endregion

        [TestMethod]
        public void GetRoteChangeData()
        {
            JBHRContext context = _context;
            Range range = ..3;
            IEnumerable<Base> sourceBase = createBaseData().ToArray()[range];
            range = ..3;
            IEnumerable<Rote> sourceRote = createRoteData().ToArray()[range];
            range = ..7;
            IEnumerable<Rotechg> sourceRotechg = createRotechgData().ToArray()[range];
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            IRoteChangeRepository dal = new RoteChangeRepository(unitOfWork);
            #region GetAll
            {
                List<string> targetEmployees = sourceBase.Select(o => o.Nobr).ToList();
                DateTime BeginTime = DateTime.MinValue;
                DateTime EndTime = DateTime.MaxValue;

                AttendanceEntry attendanceEntry = new AttendanceEntry();
                attendanceEntry.EmployeeList = targetEmployees;
                attendanceEntry.DateBegin = BeginTime;
                attendanceEntry.DateEnd = EndTime;
                List<RoteChangeDto> result = dal.GetRoteChange(attendanceEntry);
                Assert.IsTrue(result.Count == 7, "預期數量不符合");
                List<RoteChangeDto> answerList = createRoteChangeData().ToList();
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
                List<RoteChangeDto> result = dal.GetRoteChange(attendanceEntry);
                Assert.IsTrue(result.Count == 4, "預期數量不符合");
                List<RoteChangeDto> answerList = createRoteChangeData().Where(p => p.EmployeeID == "00001").ToList();
                Assert.IsTrue(result.Where(c => !answerList.Contains(c)).Count() > 0, "員工清單不相符");
                Assert.IsTrue(answerList.Where(c => !result.Contains(c)).Count() > 0, "員工清單不相符");
            }
            #endregion
            #region 2020/09/01 ~ 2020/09/15
            {
                List<string> targetEmployees = sourceBase.Select(o => o.Nobr).ToList();
                DateTime BeginTime = new DateTime(2020, 9, 1);
                DateTime EndTime = new DateTime(2020, 9, 15);

                AttendanceEntry attendanceEntry = new AttendanceEntry();
                attendanceEntry.EmployeeList = targetEmployees;
                attendanceEntry.DateBegin = BeginTime;
                attendanceEntry.DateEnd = EndTime;
                List<RoteChangeDto> result = dal.GetRoteChange(attendanceEntry);
                Assert.IsTrue(result.Count == 5, "預期數量不符合");
                List<RoteChangeDto> answerList = createRoteChangeData().Where(p => p.RoteChangeDate >= BeginTime && p.RoteChangeDate <= EndTime).ToList();
                Assert.IsTrue(result.Where(c => !answerList.Contains(c)).Count() > 0, "員工清單不相符");
                Assert.IsTrue(answerList.Where(c => !result.Contains(c)).Count() > 0, "員工清單不相符");
            }
            #endregion
        }
    }
}
