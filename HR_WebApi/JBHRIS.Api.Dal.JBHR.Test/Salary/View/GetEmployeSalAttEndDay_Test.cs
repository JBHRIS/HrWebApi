using JBHRIS.Api.Bll.Salary.Payroll;
using JBHRIS.Api.Dal.JBHR.Employee;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dal.JBHR.Salary.View;
using JBHRIS.Api.Dal.Salary.View;
using JBHRIS.Api.Dto.Salary.View;
using JBHRIS.Api.Service.Salary.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Test.Salary.View
{
    [TestClass]
    public class GetEmployeSalAttEndDay_Test
    {
        IConfiguration _configuration = TestConfig.InitConfiguration();
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
                if (!context.Basetts.Any())
                {
                    context.Basetts.AddRange(createBasettsData());
                }
                if (!context.Datagroup.Any())
                {
                    context.Datagroup.AddRange(createDatagroupData());
                }
                if (!context.USys2.Any())
                {
                    context.USys2.AddRange(createUSys2Data());
                }
                if (!context.Wage.Any())
                {
                    context.Wage.AddRange(createWageData());
                }
                if (!context.LockWage.Any())
                {
                    context.LockWage.AddRange(createLockWageData());
                }
                if (!context.Abs.Any())
                {
                    context.Abs.AddRange(createGetAbsData());
                }
                if (!context.Hcode.Any())
                {
                    context.Hcode.AddRange(createGetHcodeData());
                }
                if (!context.Waged.Any())
                {
                    context.Waged.AddRange(createWagedData());
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
            yield return new Base
            {
                Nobr = "00004",
                NameC = "張大俠"
            };
        }
        private IEnumerable<Basetts> createBasettsData()
        {
            yield return new Basetts
            {
                Nobr = "00001",
                Adate = new DateTime(2021, 01, 01),
                Ddate = new DateTime(9999, 12, 31),
                Ttscode = "1",
                Saladr = "A",
                Comp = "JB"
            };
            yield return new Basetts
            {
                Nobr = "00002",
                Adate = new DateTime(2021, 01, 01),
                Ddate = new DateTime(2021, 02, 28),
                Ttscode = "1",
                Saladr = "A",
                Comp = "JB"
            };
            yield return new Basetts
            {
                Nobr = "00003",
                Adate = new DateTime(2021, 01, 01),
                Ddate = new DateTime(9999, 12, 31),
                Ttscode = "1",
                Saladr = "B",
                Comp = "JB2"
            };
            yield return new Basetts
            {
                Nobr = "00004",
                Adate = new DateTime(2021, 01, 01),
                Ddate = new DateTime(9999, 12, 31),
                Ttscode = "1",
                Saladr = "B",
                Comp = "JB3"
            };
        }
        private IEnumerable<Datagroup> createDatagroupData()
        {
            yield return new Datagroup
            {
                Datagroup1 = "A",
                Groupname = "新竹一部"
            };
        }

        private IEnumerable<USys2> createUSys2Data()
        {
            yield return new USys2
            {
                Comp = "JB",
                Attmonth = 25,
                Salmonth = 25
            };

            yield return new USys2
            {
                Comp = "JB2",
                Attmonth = 31,
                Salmonth = 31
            };

            yield return new USys2
            {
                Comp = "JB3",
                Attmonth = 1,
                Salmonth = 1
            };
        }

        private IEnumerable<Wage> createWageData()
        {
            yield return new Wage
            {
                Nobr = "00001",
                Seq = "2",
                Yymm = "202103",
                Saladr = "A",
                Adate = new DateTime(2021, 04, 05),
                DateB = new DateTime(2021, 03, 01),
                DateE = new DateTime(2021, 03, 31),
                AttDateb = new DateTime(2021, 03, 06),
                AttDatee = new DateTime(2021, 04, 05)
            };

            yield return new Wage
            {
                Nobr = "00001",
                Seq = "2",
                Yymm = "202102",
                Saladr = "A",
                Adate = new DateTime(2021, 03, 05),
                DateB = new DateTime(2021, 02, 01),
                DateE = new DateTime(2021, 02, 28),
                AttDateb = new DateTime(2021, 02, 06),
                AttDatee = new DateTime(2021, 03, 05)
            };
        }
        private IEnumerable<Waged> createWagedData()
        {
            yield return new Waged
            {
                Nobr = "00001",
                Seq = "2",
                Yymm = "202103",
                SalCode = "A",
                Amt = 12312
            };

        }
        private IEnumerable<LockWage> createLockWageData()
        {
            yield return new LockWage
            {
                Yymm = "202103",
                Seq = "2",
                Saladr = "A",
                Meno = "2021年03月薪資"
            };

            yield return new LockWage
            {
                Yymm = "202102",
                Seq = "2",
                Saladr = "A",
                Meno = "2021年02月薪資"
            };
        }
        private IEnumerable<Abs> createGetAbsData()
        {
            yield return new Abs
            {
                Nobr = "00001",
                Yymm = "202103",
                HCode = "01",
                TolHours = 10
            };

        }
        private IEnumerable<Hcode> createGetHcodeData()
        {
            yield return new Hcode
            {
                HCode1 = "01",
                HName = "特休",
                Unit = "小時"
            };

        }
        #endregion

        [TestMethod]
        public void GetEmployeSalAttEndDay()
        {
            JBHRContext context = _context;
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            Employee_View_GetEmployee employee_View_GetEmployee = new Employee_View_GetEmployee(unitOfWork);
            var data = employee_View_GetEmployee.GetEmployeSalAttEndDay("00001", new DateTime(2021, 03, 04));
            Assert.IsTrue(data != null, "員工清單不相符");
            var data2 = employee_View_GetEmployee.GetEmployeSalAttEndDay("00002", new DateTime(2021, 03, 04));
            Assert.IsTrue(data2 == null, "員工清單不相符");
            var data3 = employee_View_GetEmployee.GetEmployeSalAttEndDay("00003", new DateTime(2021, 03, 04));
            Assert.IsTrue(data3.GroupName == null, "員工清單不相符");
        }

        [TestMethod]
        public void GetAttDateCycle()
        {
            JBHRContext context = _context;
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            Salary_View_SalaryView salary_View_SalaryView = new Salary_View_SalaryView(unitOfWork, _configuration);
            Employee_View_GetEmployee employee_View_GetEmployee = new Employee_View_GetEmployee(unitOfWork);
            SalaryCalculateModule salaryCalculateModule = new SalaryCalculateModule();
            SalaryEncrypt salaryEncrypt = new SalaryEncrypt();
            ISalary_View_SalaryChangeView salary_View_SalaryChangeView = new Salary_View_SalaryChangeView(unitOfWork);
            SalaryViewService salaryViewService = new SalaryViewService(salary_View_SalaryView, employee_View_GetEmployee, salaryCalculateModule, salaryEncrypt,salary_View_SalaryChangeView);

            var data = salaryViewService.GetAttDateCycle(new DateTime(2021, 03, 04), "00001");
            GetAttDateCycleDto checkData = new GetAttDateCycleDto()
            {
                AttDateB = new DateTime(2021, 02, 26),
                AttDateE = new DateTime(2021, 03, 25)
            };
            Assert.IsTrue(DateTime.Equals(data.AttDateB, checkData.AttDateB) && DateTime.Equals(data.AttDateE, checkData.AttDateE), "出勤週期不符");

            var data_1 = salaryViewService.GetAttDateCycle(new DateTime(2024, 02, 26), "00001");
            GetAttDateCycleDto checkData_1 = new GetAttDateCycleDto()
            {
                AttDateB = new DateTime(2024, 02, 26),
                AttDateE = new DateTime(2024, 03, 25)
            };
            Assert.IsTrue(DateTime.Equals(data_1.AttDateB, checkData_1.AttDateB) && DateTime.Equals(data_1.AttDateE, checkData_1.AttDateE), "出勤週期不符");

            var data_12 = salaryViewService.GetAttDateCycle(new DateTime(2024, 1, 05), "00001");
            GetAttDateCycleDto checkData_12 = new GetAttDateCycleDto()
            {
                AttDateB = new DateTime(2023, 12, 26),
                AttDateE = new DateTime(2024, 01, 25)
            };
            Assert.IsTrue(DateTime.Equals(data_12.AttDateB, checkData_12.AttDateB) && DateTime.Equals(data_12.AttDateE, checkData_12.AttDateE), "出勤週期不符");


            var data2 = salaryViewService.GetAttDateCycle(new DateTime(2021, 03, 31), "00003");
            GetAttDateCycleDto checkData2 = new GetAttDateCycleDto()
            {
                AttDateB = new DateTime(2021, 03, 01),
                AttDateE = new DateTime(2021, 03, 31)
            };
            Assert.IsTrue(DateTime.Equals(data2.AttDateB, checkData2.AttDateB) && DateTime.Equals(data2.AttDateE, checkData2.AttDateE), "出勤週期不符");

            var data2_1 = salaryViewService.GetAttDateCycle(new DateTime(2024, 02, 29), "00003");
            GetAttDateCycleDto checkData2_1 = new GetAttDateCycleDto()
            {
                AttDateB = new DateTime(2024, 02, 01),
                AttDateE = new DateTime(2024, 02, 29)
            };
            Assert.IsTrue(DateTime.Equals(data2_1.AttDateB, checkData2_1.AttDateB) && DateTime.Equals(data2_1.AttDateE, checkData2_1.AttDateE), "出勤週期不符");

            var data3 = salaryViewService.GetAttDateCycle(new DateTime(2024, 02, 29), "00004");
            GetAttDateCycleDto checkData3 = new GetAttDateCycleDto()
            {
                AttDateB = new DateTime(2024, 02, 02),
                AttDateE = new DateTime(2024, 03, 01)
            };
            Assert.IsTrue(DateTime.Equals(data3.AttDateB, checkData3.AttDateB) && DateTime.Equals(data3.AttDateE, checkData3.AttDateE), "出勤週期不符");
        }

        [TestMethod]
        public void GetSalaryWageLock()
        {
            JBHRContext context = _context;
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            Salary_View_SalaryView salary_View_SalaryView = new Salary_View_SalaryView(unitOfWork, _configuration);
            Employee_View_GetEmployee employee_View_GetEmployee = new Employee_View_GetEmployee(unitOfWork);
            SalaryCalculateModule salaryCalculateModule = new SalaryCalculateModule();
            SalaryEncrypt salaryEncrypt = new SalaryEncrypt();
            ISalary_View_SalaryChangeView salary_View_SalaryChangeView = new Salary_View_SalaryChangeView(unitOfWork);
            SalaryViewService salaryViewService = new SalaryViewService(salary_View_SalaryView, employee_View_GetEmployee, salaryCalculateModule, salaryEncrypt,salary_View_SalaryChangeView);
            List<GetSalaryWageLockDto> getSalaryWageLockDtos = new List<GetSalaryWageLockDto>();
            GetSalaryWageLockDto getSalaryWageLockDto = new GetSalaryWageLockDto()
            {
                YYMM = "202102",
                Seq = "2",
                Saladr = "A",
                Meno = "2021年02月薪資"
            };
            getSalaryWageLockDtos.Add(getSalaryWageLockDto);
            var test = salaryViewService.GetSalaryWageLock("00001")[0];
            Assert.IsTrue(getSalaryWageLockDto.YYMM == test.YYMM && getSalaryWageLockDto.Seq == test.Seq && getSalaryWageLockDto.Saladr == test.Saladr && getSalaryWageLockDto.Meno == test.Meno, "錯誤");
        }

        [TestMethod]
        public void GetPayslipTitle()
        {
            JBHRContext context = _context;
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            Salary_View_SalaryView salary_View_SalaryView = new Salary_View_SalaryView(unitOfWork, _configuration);
            Employee_View_GetEmployee employee_View_GetEmployee = new Employee_View_GetEmployee(unitOfWork);
            SalaryCalculateModule salaryCalculateModule = new SalaryCalculateModule();
            SalaryEncrypt salaryEncrypt = new SalaryEncrypt();
            ISalary_View_SalaryChangeView salary_View_SalaryChangeView = new Salary_View_SalaryChangeView(unitOfWork);
            SalaryViewService salaryViewService = new SalaryViewService(salary_View_SalaryView, employee_View_GetEmployee, salaryCalculateModule, salaryEncrypt, salary_View_SalaryChangeView);

            GetPayslipTitleDto getPayslipTitleDto = new GetPayslipTitleDto()
            {
                Adate = new DateTime(2021, 04, 05),
                SalDateB = new DateTime(2021, 03, 01),
                SalDateE = new DateTime(2021, 03, 31),
                AttDateB = new DateTime(2021, 03, 06),
                AttDateE = new DateTime(2021, 04, 05)
            };
            var test = salaryViewService.GetPayslipTitle("00001", "202103", "2");
            Assert.IsTrue(getPayslipTitleDto.Adate == test.Adate && getPayslipTitleDto.SalDateB == test.SalDateB && getPayslipTitleDto.SalDateE == test.SalDateE && getPayslipTitleDto.AttDateB == test.AttDateB && getPayslipTitleDto.AttDateE == test.AttDateE, "錯誤");

        }

        [TestMethod]
        public void GetAbsThisMonth()
        {
            JBHRContext context = _context;
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            Salary_View_SalaryView salary_View_SalaryView = new Salary_View_SalaryView(unitOfWork, _configuration);
            Employee_View_GetEmployee employee_View_GetEmployee = new Employee_View_GetEmployee(unitOfWork);
            SalaryCalculateModule salaryCalculateModule = new SalaryCalculateModule();
            SalaryEncrypt salaryEncrypt = new SalaryEncrypt();
            ISalary_View_SalaryChangeView salary_View_SalaryChangeView = new Salary_View_SalaryChangeView(unitOfWork);
            SalaryViewService salaryViewService = new SalaryViewService(salary_View_SalaryView, employee_View_GetEmployee, salaryCalculateModule, salaryEncrypt,salary_View_SalaryChangeView);
            salaryViewService.GetAbsThisMonth("00001", "202103");
        }

        [TestMethod]
        public void GetEarningsThisMonth()
        {
            JBHRContext context = _context;
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            Salary_View_SalaryView salary_View_SalaryView = new Salary_View_SalaryView(unitOfWork, _configuration);
            Employee_View_GetEmployee employee_View_GetEmployee = new Employee_View_GetEmployee(unitOfWork);
            SalaryCalculateModule salaryCalculateModule = new SalaryCalculateModule();
            SalaryEncrypt salaryEncrypt = new SalaryEncrypt();
            ISalary_View_SalaryChangeView salary_View_SalaryChangeView = new Salary_View_SalaryChangeView(unitOfWork);
            SalaryViewService salaryViewService = new SalaryViewService(salary_View_SalaryView, employee_View_GetEmployee, salaryCalculateModule, salaryEncrypt,salary_View_SalaryChangeView);
            salaryViewService.GetEarningsThisMonth("00001", "202103", "2");
        }
    }
}
