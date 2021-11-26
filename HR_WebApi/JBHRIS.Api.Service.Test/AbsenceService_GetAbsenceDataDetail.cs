using HR_Api_Test;
using JBHRIS.Api.Bll.Salary.Payroll;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dal.Employee;
using JBHRIS.Api.Dal.Employee.View;
using JBHRIS.Api.Dal.JBHR.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Attendance.View;
using JBHRIS.Api.Dal.JBHR.Employee;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dal.JBHR.Salary.View;
using JBHRIS.Api.Dal.Salary.View;
using JBHRIS.Api.Dto.Absence.Entry;
using JBHRIS.Api.Service.Attendance.Normal;
using JBHRIS.Api.Service.Salary.View;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace JBHRIS.Api.Service.Test
{
    [TestClass]
    public class AbsenceService_GetAbsenceDataDetail
    {

        [TestMethod]
        public void GetAbsenceDataDetail()
        {
            IConfiguration _configuration = TestConfig.InitConfiguration();
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(TestConfig.GetJBHRContext(), LogManager.GetCurrentClassLogger());
            IAbsenceTakenRepository _absenceTakenRepository = new AbsenceTakenRepository(unitOfWork);
            IAbsenceCancelRepository _absenceCancelRepository = new AbsenceCancelRepository(unitOfWork);
            ILogger _logger = LogManager.GetCurrentClassLogger();
            IAbsence_Normal_GetAbsBalance _absence_Normal_GetAbsBalance = new Absence_Normal_GetAbsBalance(unitOfWork);
            IAbsence_Normal_GetHcodeTypes _absence_Normal_GetHcodeTypes = new Absence_Normal_GetHcodeTypes(unitOfWork);
            IAbsence_Normal_GetHcodeTypesByHcode _absence_Normal_GetHcodeTypesByHcode = new Absence_Normal_GetHcodeTypesByHcode(unitOfWork);
            IAttend_View_GetAttendRote _attend_View_GetAttendRote = new Attend_View_GetAttendRote(unitOfWork);
            IAbsence_Normal_GetHcode _absence_Normal_GetHcode = new Absence_Normal_GetHcode(unitOfWork);
            IEmployee_Normal_GetEmployeeInfo _employee_Normal_GetEmployeeInfo = new Employee_Normal_GetEmployeeInfo(unitOfWork);
            IAttend_View_GetAbsenceTakenView _attend_View_GetAbsenceTakenView = new Attend_View_GetAbsenceTakenView(unitOfWork);

            ISalary_View_SalaryView _salary_View_SalaryView = new Salary_View_SalaryView(unitOfWork, _configuration);
            IEmployee_View_GetEmployee _employee_View_GetEmployee = new Employee_View_GetEmployee(unitOfWork);
            ISalaryCalculateModule _salaryCalculateModule = new SalaryCalculateModule();
            ISalaryEncrypt _salaryEncrypt = new SalaryEncrypt();
            ISalary_View_SalaryChangeView salary_View_SalaryChangeView = new Salary_View_SalaryChangeView(unitOfWork);
            ISalaryViewService _salaryViewService = new SalaryViewService(_salary_View_SalaryView,
                                                                          _employee_View_GetEmployee,
                                                                          _salaryCalculateModule,
                                                                          _salaryEncrypt, salary_View_SalaryChangeView);

            IAbsenceService absenceService = new AbsenceService(_absenceTakenRepository,
            _absenceCancelRepository,
            _logger,
            _absence_Normal_GetHcodeTypes,
            _absence_Normal_GetHcodeTypesByHcode,
            _absence_Normal_GetAbsBalance,
            _attend_View_GetAttendRote,
            _absence_Normal_GetHcode,
            _configuration,
            _employee_Normal_GetEmployeeInfo,
            _attend_View_GetAbsenceTakenView,
            _salaryViewService);

            GetAbsenceDataDetailEntry absEntry = new GetAbsenceDataDetailEntry() {
                Nobr = "A0098",
                StartDateTime = DateTime.Parse("2020/12/25 08:30:00"),
                EndDateTime = DateTime.Parse("2020/12/28 16:30:00"),
                HCode = "A"
            };
            var claims = new List<Claim>();
            var userdata = new
            {
                UserId = "S0044",
                UserName = "林武智",
                Company = "S",
                Department = "S",
                DepartmentExtra = new List<string>(),
                DepartmentName = "聚天生醫股份有限公司",
                DeptA = "S-S00000",
                DeptAName = "生醫部",
                Job = "B",
                JobName = "副總經理",
                DataGroups = "",
                Role = new List<string>() { "Emp", "Manager" },
                Saladr = ""
            };
            claims.Add(new Claim("userdata", JsonConvert.SerializeObject(userdata)));
            var identity = new ClaimsIdentity(claims, "MyClaimsLogin");
            ClaimsPrincipal user = new ClaimsPrincipal(identity);
            //var d = absenceService.GetAbsenceDataDetail(absEntry);
            //var d1 = absenceService.CheckAbsenceDataDetail(user, d.Result);
            //var d2 = absenceService.AbsenceDataSave(user, d.Result);

            GetAbsenceDataDetailEntry absEntry2 = new GetAbsenceDataDetailEntry()
            {
                Nobr = "A0223",
                StartDateTime = DateTime.Parse("2020/12/21 09:00:00"),
                EndDateTime = DateTime.Parse("2020/12/22 17:00:00"),
                HCode = "W"
            };

            //var c = absenceService.GetAbsenceDataDetail(absEntry2);
            //var c1 = absenceService.CheckAbsenceDataDetail(user, c.Result);
            //var c2 = absenceService.AbsenceDataSave(user, c.Result);
            //Assert.AreEqual(4, data.Result.Count, "取得筆數確認");
        }
    }
}
