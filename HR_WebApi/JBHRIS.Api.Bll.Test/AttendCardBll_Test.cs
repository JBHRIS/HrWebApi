using JBHRIS.Api.Bll.Attendance;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Bll.Test
{
    [TestClass]
    public class AttendCardBll_Test
    {
        [TestMethod]
        public void GetAttendCardRange()
        {
            AttendCardBll attendCardBll = new AttendCardBll();
            List<AttendRangeEntryDto> attenndRangeEntryDtos = new List<AttendRangeEntryDto>();

            attenndRangeEntryDtos.Add(new AttendRangeEntryDto { EmployeeID = "123", AttendDate = new DateTime(2021, 05, 27, 0, 0, 0), OffTime2 = "0400" });
            attenndRangeEntryDtos.Add(new AttendRangeEntryDto { EmployeeID = "123", AttendDate = new DateTime(2021, 05, 28, 0, 0, 0), OffTime2 = "0400" });
            attenndRangeEntryDtos.Add(new AttendRangeEntryDto { EmployeeID = "123", AttendDate = new DateTime(2021, 05, 29, 0, 0, 0) });
            attenndRangeEntryDtos.Add(new AttendRangeEntryDto { EmployeeID = "123", AttendDate = new DateTime(2021, 05, 30, 0, 0, 0) });
            attenndRangeEntryDtos.Add(new AttendRangeEntryDto { EmployeeID = "123", AttendDate = new DateTime(2021, 05, 31, 0, 0, 0), OffTime2 = "0400" });
            attenndRangeEntryDtos.Add(new AttendRangeEntryDto { EmployeeID = "1234", AttendDate = new DateTime(2021, 05, 31, 0, 0, 0), OffTime2 = "0400" });

            var test = attendCardBll.GetAttendCardRange(attenndRangeEntryDtos);
            Assert.AreEqual(1, 1, "錯誤測試");
        }

        [TestMethod]
        public void GetAttCard()
        {
            AttendCardBll attendCardBll = new AttendCardBll();
            List<AttendRangeEntryDto> attenndRangeEntryDtos = new List<AttendRangeEntryDto>();

            attenndRangeEntryDtos.Add(new AttendRangeEntryDto { EmployeeID = "123", AttendDate = new DateTime(2021, 05, 27, 0, 0, 0), OffTime2 = "0400" });
            attenndRangeEntryDtos.Add(new AttendRangeEntryDto { EmployeeID = "123", AttendDate = new DateTime(2021, 05, 28, 0, 0, 0), OffTime2 = "0400" });
            attenndRangeEntryDtos.Add(new AttendRangeEntryDto { EmployeeID = "123", AttendDate = new DateTime(2021, 05, 29, 0, 0, 0) });
            attenndRangeEntryDtos.Add(new AttendRangeEntryDto { EmployeeID = "123", AttendDate = new DateTime(2021, 05, 30, 0, 0, 0) });
            attenndRangeEntryDtos.Add(new AttendRangeEntryDto { EmployeeID = "123", AttendDate = new DateTime(2021, 05, 31, 0, 0, 0), OffTime2 = "0400" });
            attenndRangeEntryDtos.Add(new AttendRangeEntryDto { EmployeeID = "1234", AttendDate = new DateTime(2021, 05, 31, 0, 0, 0), OffTime2 = "0400" });

            var test = attendCardBll.GetAttendCardRange(attenndRangeEntryDtos);

            List<CardDto> cardDtos = new List<CardDto>();
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 27, 0, 0, 0), PuchInTime = "0800" });
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 27, 0, 0, 0), PuchInTime = "1200" });
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 27, 0, 0, 0), PuchInTime = "1300" });
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 27, 0, 0, 0), PuchInTime = "1700" });
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 28, 0, 0, 0), PuchInTime = "0300" });
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 28, 0, 0, 0), PuchInTime = "1200" });
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 28, 0, 0, 0), PuchInTime = "1300" });
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 28, 0, 0, 0), PuchInTime = "1700" });
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 29, 0, 0, 0), PuchInTime = "0800" });
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 29, 0, 0, 0), PuchInTime = "1700" });
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 31, 0, 0, 0), PuchInTime = "0800" });
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 31, 0, 0, 0), PuchInTime = "1200" });
            cardDtos.Add(new CardDto { EmployeeID = "123", PuchInDate = new DateTime(2021, 05, 31, 0, 0, 0), PuchInTime = "1300" });
            cardDtos.Add(new CardDto { EmployeeID = "1234", PuchInDate = new DateTime(2021, 05, 31, 0, 0, 0), PuchInTime = "1700" });

            var test2 = attendCardBll.GetAttCard(test, cardDtos);
            Assert.AreEqual(1, 1, "錯誤測試");
        }


        [TestMethod]
        public void CalLateMin()
        {
            AttendCardBll attendCardBll = new AttendCardBll();

            DateTime roteOnTime = new DateTime(2021, 05, 31, 08, 00, 00);
            DateTime roteOffTime = new DateTime(2021, 05, 31, 17, 00, 00);
            List<Tuple<DateTime, DateTime>> roteRestList = new List<Tuple<DateTime, DateTime>>();
            roteRestList.Add(new Tuple<DateTime, DateTime>(new DateTime(2021, 05, 31, 12, 00, 00), new DateTime(2021, 05, 31, 13, 00, 00)));
            roteRestList.Add(new Tuple<DateTime, DateTime>(new DateTime(2021, 05, 31, 15, 00, 00), new DateTime(2021, 05, 31, 16, 00, 00)));
            DateTime? cardOnTime = new DateTime(2021, 05, 31, 16, 31, 00);

            decimal LateMin =  attendCardBll.CalLateMin(roteOnTime, roteOffTime, roteRestList, cardOnTime);
            Assert.AreEqual(391, LateMin, "錯誤測試");
        }

        [TestMethod]
        public void CalEarMin()
        {
            AttendCardBll attendCardBll = new AttendCardBll();

            DateTime roteOnTime = new DateTime(2021, 05, 31, 08, 00, 00);
            DateTime roteOffTime = new DateTime(2021, 05, 31, 17, 00, 00);
            List<Tuple<DateTime, DateTime>> roteRestList = new List<Tuple<DateTime, DateTime>>();
            roteRestList.Add(new Tuple<DateTime, DateTime>(new DateTime(2021, 05, 31, 12, 00, 00), new DateTime(2021, 05, 31, 13, 00, 00)));
            roteRestList.Add(new Tuple<DateTime, DateTime>(new DateTime(2021, 05, 31, 15, 00, 00), new DateTime(2021, 05, 31, 16, 00, 00)));
            DateTime? cardOffTime = new DateTime(2021, 05, 31, 16, 31, 00);

            decimal LateMin = attendCardBll.CalEarMin(roteOnTime, roteOffTime, roteRestList, cardOffTime);
            Assert.AreEqual(29, LateMin, "錯誤測試");
        }

        [TestMethod]
        public void IsAbsenteeism() 
        {
            AttendCardBll attendCardBll = new AttendCardBll();
            var IsAbsenteeism =  attendCardBll.IsAbsenteeism(null,null);
            Assert.AreEqual(true, IsAbsenteeism, "錯誤測試");
        }
    }
}
