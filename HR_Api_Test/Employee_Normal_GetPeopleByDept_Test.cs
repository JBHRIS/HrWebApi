using JBHRIS.Api.Dal.JBHR.Employee;
using JBHRIS.Api.Dal.JBHR.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Api_Test
{
    [TestClass]
    public class Employee_Normal_GetPeopleByDept_Test
    {
        [TestMethod]
        public void GetPeopleByDept_Test()
        {
            IUnitOfWork unitOfWork = new JbhrUnitOfWork(TestConfig.GetJBHRContext());
            Employee_Normal_GetPeopleByDept employee_Normal_GetPeopleByDept = new Employee_Normal_GetPeopleByDept(unitOfWork);
            var data = employee_Normal_GetPeopleByDept.GetPeopleByDept(new List<string> { "A0003", "A0017" },new System.Collections.Generic.List<string> { "A","A240", "1235" }, new DateTime(2019, 12, 31));
            Assert.AreEqual(2, data.Count, "取得筆數確認");
        }
    }
}
