using JBHRIS.Api.Dal.JBHR.Employee;
using JBHRIS.Api.Dal.JBHR.Employee.Normal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Test
{
    [TestClass]
    public  class Employee_Normal_GetPeopleByOnBoardDate_Test
    {



        [TestMethod]
        public void Employee_Normal_Test()
        {
            var jBHRContext = TestConfig.GetJBHRContext();
            Employee_Normal_GetPeopleByOnBoardDate employee_Normal_GetPeopleByLeaveDate = new Employee_Normal_GetPeopleByOnBoardDate(jBHRContext);

            var data = employee_Normal_GetPeopleByLeaveDate.GetPeopleByOnBoardDate(new List<string> { "A0003", "A0017" }, new DateTime(2019, 12, 31), new DateTime(2020, 05, 31));
            Assert.AreEqual(26, data.Count, "取得筆數確認");
        }
    }
}
