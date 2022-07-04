using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;

namespace JBHRIS.Api.Dal.JBHR.Test.Attendance.Normal
{
    [TestClass]
    public class Card_Test
    {
        private JBHRContext _context
        {
            get
            {
                DbContextOptions<JBHRContext> options = new DbContextOptionsBuilder<JBHRContext>()
                    .UseInMemoryDatabase("HR")
                    .Options;
                JBHRContext context = new JBHRContext(options);
                if (!context.Card.Any())
                {
                    context.Card.AddRange(createCardData());
                }
                if (!context.Cardlosd.Any())
                {
                    context.Cardlosd.AddRange(createCardlosdData());
                }
                context.SaveChanges();
                return context;
            }
        }
        #region TestData
        private IEnumerable<Card> createCardData()
        {
            yield return new Card
            {
                Nobr = "1",
                Adate = new DateTime(2020, 9, 1),
                Ontime = "0800",
                Code = "食堂",
                Los = true,
                Reason = "1",
                Meno =""
            };
            yield return new Card
            {
                Nobr = "2",
                Adate = new DateTime(2020, 10, 1),
                Ontime = "0900",
                Code = "大門",
                Los = true,
                Reason = "2",
                Meno = "Test"
            };
            yield return new Card
            {
                Nobr = "3",
                Adate = new DateTime(2020, 9, 4),
                Ontime = "1700",
                Code = "大門",
                Los = true,
                Reason = "3",
                Meno = "忘"
            };
            yield return new Card
            {
                Nobr = "4",
                Adate = new DateTime(2020, 12, 21),
                Ontime = "1900",
                Code = "食堂",
                Los = true,
                Reason = "1",
                Meno = "刷"
            };
            yield return new Card
            {
                Nobr = "1",
                Adate = new DateTime(2020, 9, 11),
                Ontime = "2400",
                Code = "大門",
                Los = true,
                Reason = "1",
                Meno = "卡"
            };
            yield return new Card
            {
                Nobr = "2",
                Adate = new DateTime(2020, 7, 23),
                Ontime = "2800",
                Code = "食堂",
                Los = true,
                Reason = "4",
                Meno = "片"
            };
        }
        private IEnumerable<Cardlosd> createCardlosdData()
        {
            yield return new Cardlosd
            {
                Code = "1",
                Descr = "未帶卡片",
                Att = true,
                Sort = 1,
                KeyMan = "User1",
                KeyDate = new DateTime(2010, 1, 12)
            };
            yield return new Cardlosd
            {
                Code = "2",
                Descr = "卡片毀損",
                Att = true,
                Sort = 2,
                KeyMan = "User1",
                KeyDate = new DateTime(2010, 1, 22)
            };
            yield return new Cardlosd
            {
                Code = "3",
                Descr = "卡片遺失",
                Att = true,
                Sort = 3,
                KeyMan = "User1",
                KeyDate = new DateTime(2010, 2, 12)
            };
            yield return new Cardlosd
            {
                Code = "4",
                Descr = "忘記刷卡",
                Att = false,
                Sort = 4,
                KeyMan = "User1",
                KeyDate = new DateTime(2022, 1, 12)
            };
        }
        private IEnumerable<CardDto> createCardDtoData()
        {
            yield return new CardDto
            {
                EmployeeID = "1",
                PuchInDate = new DateTime(2020, 9, 1),
                PuchInTime = "0800",
                Source = "食堂",
                Forget = true,
                ForgetReason = "1",
                Remarks = ""
            };
            yield return new CardDto
            {
                EmployeeID = "2",
                PuchInDate = new DateTime(2020, 10, 1),
                PuchInTime = "0900",
                Source = "大門",
                Forget = true,
                ForgetReason = "2",
                Remarks = "Test"
            };
            yield return new CardDto
            {
                EmployeeID = "3",
                PuchInDate = new DateTime(2020, 9, 4),
                PuchInTime = "1700",
                Source = "大門",
                Forget = true,
                ForgetReason = "3",
                Remarks = "忘"
            };
            yield return new CardDto
            {
                EmployeeID = "4",
                PuchInDate = new DateTime(2020, 12, 21),
                PuchInTime = "1900",
                Source = "食堂",
                Forget = true,
                ForgetReason = "1",
                Remarks = "刷"
            };
            yield return new CardDto
            {
                EmployeeID = "1",
                PuchInDate = new DateTime(2020, 9, 11),
                PuchInTime = "2400",
                Source = "大門",
                Forget = true,
                ForgetReason = "1",
                Remarks = "卡"
            };
            yield return new CardDto
            {
                EmployeeID = "2",
                PuchInDate = new DateTime(2020, 7, 23),
                PuchInTime = "2800",
                Source = "食堂",
                Forget = true,
                ForgetReason = "4",
                Remarks = "片"
            };
        }
        #endregion

        [TestMethod]
        public void GetCardData()
        {
            JBHRContext context = _context;// new JBHRContext(_options);// _context;
            Range range = ..6;
            IEnumerable<Card> sourceA = createCardData().ToArray()[range];
            range = ..4;
            IEnumerable<Cardlosd> sourceB = createCardlosdData().ToArray()[range];
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            ICardRepository dal = new CardRepository(unitOfWork);
            #region 2020/09/01 - 2020/09/31
            {
                List<string> targetEmployees = sourceA.Select(o => o.Nobr).ToList();
                DateTime DateBegin = new DateTime(2020, 9, 1);
                DateTime DateEnd = new DateTime(2020, 9, 30);

                AttendanceEntry attendanceEntry = new AttendanceEntry();
                attendanceEntry.EmployeeList = targetEmployees;
                attendanceEntry.DateBegin = DateBegin;
                attendanceEntry.DateEnd = DateEnd;
                List<CardDto> result = dal.GetCard(attendanceEntry);
                Assert.IsTrue(result.Count == 3, "預期數量不符合");
                List<CardDto> answerList = createCardDtoData().Where(p => p.PuchInDate >= DateBegin && p.PuchInDate <= DateEnd).ToList();
                Assert.IsTrue(result.Where(c => !answerList.Contains(c)).Count() > 0, "員工清單不相符");
                Assert.IsTrue(answerList.Where(c => !result.Contains(c)).Count() > 0, "員工清單不相符");
            }
            #endregion
            #region EmployeeID = 1
            {
                List<string> targetEmployees = sourceA.Where(p => p.Nobr == "1").Select(o => o.Nobr).ToList();
                DateTime DateBegin = DateTime.MinValue;
                DateTime DateEnd = DateTime.MaxValue;

                AttendanceEntry attendanceEntry = new AttendanceEntry();
                attendanceEntry.EmployeeList = targetEmployees;
                attendanceEntry.DateBegin = DateBegin;
                attendanceEntry.DateEnd = DateEnd;
                List<CardDto> result = dal.GetCard(attendanceEntry);
                Assert.IsTrue(result.Count == 2, "預期數量不符合");
                List<CardDto> answerList = createCardDtoData().Where(p => p.EmployeeID == "1").ToList();
                Assert.IsTrue(result.Where(c => !answerList.Contains(c)).Count() > 0, "員工清單不相符");
                Assert.IsTrue(answerList.Where(c => !result.Contains(c)).Count() > 0, "員工清單不相符");
            }
            #endregion
        }
    }
}
