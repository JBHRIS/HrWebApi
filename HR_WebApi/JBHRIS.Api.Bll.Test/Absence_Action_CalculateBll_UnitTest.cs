using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using Microsoft.Extensions.Configuration;
using JBHRIS.Api.Bll.Attendance.Action;
using System.Linq;
using JBHRIS.Api.Dto;

namespace JBHRIS.Api.Bll.Test
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class Absence_Action_CalculateBll_UnitTesttClass
    {
        static string TestEmployeeId = "123456";
        Dto.Attendance.View.AttRoteViewDto 出勤20210510_0830_1730 = new Dto.Attendance.View.AttRoteViewDto
        {
            AttendDate = new DateTime(2021, 5, 10)
                ,
            EmployeeID = TestEmployeeId,
            Rote = new Dto.Attendance.RoteDto { RoteCode = "01", OnTime = "0830", OffTime = "1730", AttEnd = "1730", RoteDisp = "01", Rotename = "常日班", Sort = 1 },
            RoteOnTime = new DateTime(2021, 5, 10, 8, 30, 0),
            RoteOffTime = new DateTime(2021, 5, 10, 17, 30, 0),
            WorkHours = 8,
            RoteRestTime = new List<Tuple<DateTime, DateTime>>{new Tuple<DateTime, DateTime>(
                        new DateTime(2021,5,10,12,0,0),
                        new DateTime(2021, 5, 10, 13, 00, 0)) }
        };
        Dto.Attendance.View.AttRoteViewDto 出勤20210511_0830_1730 = new Dto.Attendance.View.AttRoteViewDto
        {
            AttendDate = new DateTime(2021, 5, 11)
             ,
            EmployeeID = TestEmployeeId,
            Rote = new Dto.Attendance.RoteDto { RoteCode = "01", OnTime = "0830", OffTime = "1730", AttEnd = "1730", RoteDisp = "01", Rotename = "常日班", Sort = 1 },
            RoteOnTime = new DateTime(2021, 5, 11, 8, 30, 0),
            RoteOffTime = new DateTime(2021, 5, 11, 17, 30, 0),
            WorkHours = 8,
            RoteRestTime = new List<Tuple<DateTime, DateTime>>{new Tuple<DateTime, DateTime>(
                        new DateTime(2021,5,11,12,0,0),
                        new DateTime(2021, 5, 11, 13, 00, 0)) }
        };
        Dto.Attendance.View.AttRoteViewDto 出勤20210512_休息日 = new Dto.Attendance.View.AttRoteViewDto
        {
            AttendDate = new DateTime(2021, 5, 12)
            ,
            EmployeeID = TestEmployeeId,
            Rote = new Dto.Attendance.RoteDto { RoteCode = "0X", OnTime = "", OffTime = "", AttEnd = "", RoteDisp = "0X", Rotename = "休息日", Sort = 1 },
            //RoteOnTime = new DateTime(2021, 5, 11, 8, 30, 0),
            //RoteOffTime = new DateTime(2021, 5, 11, 17, 30, 0),
            WorkHours = 0,
            Attend = new Dto.Attendance.AttendDto { Adate = new DateTime(2021, 5, 12), Rote = "0X", RoteH = "01" },
            RoteRestTime = new List<Tuple<DateTime, DateTime>>(),
        }; 
        Dto.Attendance.View.AttRoteViewDto 出勤20210512_休息日_假日參考 = new Dto.Attendance.View.AttRoteViewDto
        {
            AttendDate = new DateTime(2021, 5, 12)
           ,
            EmployeeID = TestEmployeeId,
            Rote = new Dto.Attendance.RoteDto { RoteCode = "01", OnTime = "", OffTime = "", AttEnd = "", RoteDisp = "01", Rotename = "常日班", Sort = 1 },
            RoteOnTime = new DateTime(2021, 5, 12, 8, 30, 0),
            RoteOffTime = new DateTime(2021, 5, 12, 17, 30, 0),
            WorkHours = 0,
            Attend = new Dto.Attendance.AttendDto { Adate = new DateTime(2021, 5, 12), Rote = "0X", RoteH = "01" },
            RoteRestTime = new List<Tuple<DateTime, DateTime>>{new Tuple<DateTime, DateTime>(
                        new DateTime(2021,5,12,12,0,0),
                        new DateTime(2021, 5, 12, 13, 00, 0)) }
        };
        Dto.Attendance.View.AttRoteViewDto 出勤20210513_例假日 = new Dto.Attendance.View.AttRoteViewDto
        {
            AttendDate = new DateTime(2021, 5, 13)
         ,
            EmployeeID = TestEmployeeId,
            Rote = new Dto.Attendance.RoteDto { RoteCode = "0Z", OnTime = "", OffTime = "", AttEnd = "", RoteDisp = "0Z", Rotename = "例假日", Sort = 1 },
            //RoteOnTime = new DateTime(2021, 5, 11, 8, 30, 0),
            //RoteOffTime = new DateTime(2021, 5, 11, 17, 30, 0),
            WorkHours = 0,
            Attend = new Dto.Attendance.AttendDto { Adate = new DateTime(2021, 5, 12), Rote = "0Z", RoteH = "01" },
            RoteRestTime =  new List<Tuple<DateTime, DateTime>>(), 
        };
        Dto.Attendance.View.AttRoteViewDto 出勤20210513_例假日_假日參考 = new Dto.Attendance.View.AttRoteViewDto
        {
            AttendDate = new DateTime(2021, 5, 13)
       ,
            EmployeeID = TestEmployeeId,
            Rote = new Dto.Attendance.RoteDto { RoteCode = "01", OnTime = "", OffTime = "", AttEnd = "", RoteDisp = "01", Rotename = "常日班", Sort = 1 },
            RoteOnTime = new DateTime(2021, 5, 13, 8, 30, 0),
            RoteOffTime = new DateTime(2021, 5, 13, 17, 30, 0),
            WorkHours = 0,
            Attend = new Dto.Attendance.AttendDto { Adate = new DateTime(2021, 5, 13), Rote = "0Z", RoteH = "01" },
            RoteRestTime = new List<Tuple<DateTime, DateTime>>{new Tuple<DateTime, DateTime>(
                        new DateTime(2021,5,13,12,0,0),
                        new DateTime(2021, 5, 13, 13, 00, 0)) }
        };
        Dto.Attendance.View.AttRoteViewDto 出勤20210514_0830_1730 = new Dto.Attendance.View.AttRoteViewDto
        {
            AttendDate = new DateTime(2021, 5, 14)
        ,
            EmployeeID = TestEmployeeId,
            Rote = new Dto.Attendance.RoteDto { RoteCode = "01", OnTime = "0830", OffTime = "1730", AttEnd = "1730", RoteDisp = "01", Rotename = "常日班", Sort = 1 },
            RoteOnTime = new DateTime(2021, 5, 14, 8, 30, 0),
            RoteOffTime = new DateTime(2021, 5, 14, 17, 30, 0),
            WorkHours = 8,
            RoteRestTime = new List<Tuple<DateTime, DateTime>>{new Tuple<DateTime, DateTime>(
                        new DateTime(2021,5,14,12,0,0),
                        new DateTime(2021, 5, 14, 13, 00, 0)) }
        };
        [TestMethod]
        public void AbsCalculate_整天請假()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 10, 08, 30, 0),
                    EndDateTime = new DateTime(2021, 5, 10, 17, 30, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "小時",
                Htype = "1",
                InHoli = false,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(8M, totalHours);
        }
        [TestMethod]
        public void AbsCalculate_上半天請假()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 10, 08, 30, 0),
                    EndDateTime = new DateTime(2021, 5, 10, 12, 00, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "小時",
                Htype = "1",
                InHoli = false,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(3.5M, totalHours);
        }
        [TestMethod]
        public void AbsCalculate_上半天請假_單位天()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 10, 08, 30, 0),
                    EndDateTime = new DateTime(2021, 5, 10, 12, 00, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "天",
                Htype = "1",
                InHoli = false,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(0.5M, totalHours);
        }
        [TestMethod]
        public void AbsCalculate_下半天請假()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 10, 13, 0, 0),
                    EndDateTime = new DateTime(2021, 5, 10, 17, 30, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "小時",
                Htype = "1",
                InHoli = false,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(4.5M, totalHours);
        }
        [TestMethod]
        public void AbsCalculate_下半天請假_單位天()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 10, 13, 0, 0),
                    EndDateTime = new DateTime(2021, 5, 10, 17, 30, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "天",
                Htype = "1",
                InHoli = false,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(1M, totalHours);
        }
        [TestMethod]
        public void AbsCalculate_請假時段不吻合()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 10, 18, 0, 0),
                    EndDateTime = new DateTime(2021, 5, 10, 23, 30, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "小時",
                Htype = "1",
                InHoli = false,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(0, totalHours);
        }
        [TestMethod]
        public void AbsCalculate_請假跨天_整天()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 10, 8, 30, 0),
                    EndDateTime = new DateTime(2021, 5, 11, 17, 30, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "小時",
                Htype = "1",
                InHoli = false,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730, 出勤20210511_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(16, totalHours);
        }
        [TestMethod]
        public void AbsCalculate_請假跨假日_不含假日_整天()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 11, 8, 30, 0),
                    EndDateTime = new DateTime(2021, 5, 14, 17, 30, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "小時",
                Htype = "1",
                InHoli = false,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730, 出勤20210511_0830_1730, 出勤20210512_休息日, 出勤20210513_例假日, 出勤20210514_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(16, totalHours);
        }
        [TestMethod]
        public void AbsCalculate_請假跨假日_含假日_整天()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 11, 8, 30, 0),
                    EndDateTime = new DateTime(2021, 5, 14, 17, 30, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "小時",
                Htype = "1",
                InHoli = true,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730, 出勤20210511_0830_1730, 出勤20210512_休息日_假日參考, 出勤20210513_例假日_假日參考, 出勤20210514_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(32, totalHours);
        }
        [TestMethod]
        public void AbsCalculate_請假跨天_一天半()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 10, 12, 00, 0),
                    EndDateTime = new DateTime(2021, 5, 11, 17, 30, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "小時",
                Htype = "1",
                InHoli = false,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730, 出勤20210511_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(4.5M + 8M, totalHours);
        }
        [TestMethod]
        public void AbsCalculate_請假跨天_兩個半天()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 10, 12, 00, 0),
                    EndDateTime = new DateTime(2021, 5, 11, 12, 30, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "小時",
                Htype = "1",
                InHoli = false,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730, 出勤20210511_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(8M, totalHours);
        }
        [TestMethod]
        public void AbsCalculate_請假_未滿最小數()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 10, 8, 30, 0),
                    EndDateTime = new DateTime(2021, 5, 10, 8, 40, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "小時",
                Htype = "1",
                InHoli = false,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730, 出勤20210511_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(0.5M, totalHours);
        }
        [TestMethod]
        public void AbsCalculate_請假_未滿間隔數()
        {
            var inMemorySettings = new Dictionary<string, string> {
                                    {"HcodeUnitString:Day:0","天"  },
                                    {"HcodeUnitString:Hour:0","小時" },
                                    {"HcodeUnitString:Minute:0","分鐘"}
                                };
            IConfiguration _configuration = new ConfigurationBuilder()
           .AddInMemoryCollection(inMemorySettings)
           .Build();
            IAbsence_Action_CalculateBll absence_Action_CalculateBll = new Absence_Action_CalculateBll(_configuration);
            Dto.Absence.Entry.GetAbsenceDataDetailEntry getAbsenceDataDetailEntry
                = new Dto.Absence.Entry.GetAbsenceDataDetailEntry
                {
                    Nobr = TestEmployeeId,
                    HCode = "A",
                    StartDateTime = new DateTime(2021, 5, 10, 8, 30, 0),
                    EndDateTime = new DateTime(2021, 5, 10, 9, 40, 0)
                };
            Dto.Attendance.HcodeDto hcodeDto = new Dto.Attendance.HcodeDto
            {
                HCode = "A",
                AbsUnit = 0.5M,
                Che = true,
                Flag = "-",
                HCodeDisp = "A",
                HCodeName = "特休假",
                HCodeUnit = "小時",
                Htype = "1",
                InHoli = false,
                Minnum = 0.5M,
                Sex = ""
            };
            List<Dto.Attendance.View.AttRoteViewDto> attRoteViewDtos
                = new List<Dto.Attendance.View.AttRoteViewDto> { 出勤20210510_0830_1730, 出勤20210511_0830_1730 };
            var result = absence_Action_CalculateBll.AbsCalculate(getAbsenceDataDetailEntry, hcodeDto, attRoteViewDtos);
            var totalHours = result.Sum(p => p.TotHours);
            Assert.AreEqual(1.5M, totalHours);
        }
    }
}
