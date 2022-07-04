using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Attendance.Normal;
using JBHRIS.Api.Service.Attendance.Normal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Test.Attendance.Normal
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class AbsenceService_UnitTest
    {
        [TestMethod]
        public void CalAbsHours_上班時段不符合()
        {
            DateTime today = DateTime.Today;
            var mockAbsenceTakenRepository = Substitute.For<IAbsenceTakenRepository>();
            var mockAbsCancelRepository = Substitute.For<IAbsenceCancelRepository>();
            mockAbsenceTakenRepository.GetAbsenceTaken(new Dto.Attendance.Entry.AbsenceEntry { EmployeeList = new List<string> { }, DateBegin = today, DateEnd = today, HcodeList = new List<string> { } });
            IAbsenceTakenRepository absence_Normal_GetAbsenceTaken = mockAbsenceTakenRepository;
            //IAbsenceService absenceService=new AbsenceService(mockAbsenceTakenRepository, mockAbsCancelRepository)
        }

    }
}
