using JBHRIS.Api.Dal.JBHR.Employee;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dal.JBHR.Salary.View;
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
    public class SalaryView_Test
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
                if (!context.DataPa.Any())
                {
                    context.DataPa.AddRange(createDataPaData());
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
                Comp = "JB"
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
                Attmonth = 31,
                Salmonth = 31
            };
        }

        private IEnumerable<DataPa> createDataPaData()
        {
            yield return new DataPa
            {
                DataPass = new DateTime(2021,02,25),
                Saladr = "A"
            };
            yield return new DataPa
            {
                DataPass = new DateTime(2021, 02, 20),
                Saladr = "B"
            };
            yield return new DataPa
            {
                DataPass = new DateTime(2021, 03, 02),
                Saladr = "C"
            };
        }
        
        #endregion

        [TestMethod]
        public void GetEmployeSalAttEndDay()
        {
            JBHRContext context = _context;
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            Salary_View_SalaryView salary_View_SalaryView = new Salary_View_SalaryView(unitOfWork, _configuration);
            var data = salary_View_SalaryView.GetUnLockYYMM(new DateTime(2021, 02, 20), "A", 25);
            Assert.IsTrue(data == "202103", "算錯計薪年月");
            var data2 = salary_View_SalaryView.GetUnLockYYMM(new DateTime(2021, 02, 21), "B", 25);
            Assert.IsTrue(data2 == "202102", "算錯計薪年月");
            var data3 = salary_View_SalaryView.GetUnLockYYMM(new DateTime(2021, 03, 01), "C", 25);
            Assert.IsTrue(data3 == "202104", "算錯計薪年月");
        }

        [TestMethod]
        public void IsLockedYYMM()
        {
            JBHRContext context = _context;
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(context);
            Salary_View_SalaryView salary_View_SalaryView = new Salary_View_SalaryView(unitOfWork, _configuration);
            var data = salary_View_SalaryView.IsLockedYYMM(new DateTime(2021, 02, 20), "A", 25);
            Assert.IsTrue(data == true, "算錯計薪年月");
            var data2 = salary_View_SalaryView.IsLockedYYMM(new DateTime(2021, 02, 21), "B", 25);
            Assert.IsTrue(data2 == false, "算錯計薪年月");
            var data3 = salary_View_SalaryView.IsLockedYYMM(new DateTime(2021, 03, 01), "C", 25);
            Assert.IsTrue(data3 == true, "算錯計薪年月");
        }
    }
}
