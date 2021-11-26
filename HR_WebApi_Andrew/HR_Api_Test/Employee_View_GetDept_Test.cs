using JBHRIS.Api.Dal.JBHR.Employee.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Api_Test
{
    [TestClass]
    public class Employee_View_GetDept_Test
    {
        [TestMethod]
        public void GetDept_Test()
        {

            var jBHRContext = TestConfig.GetJBHRContext();
            Employee_View_GetDept employee_View_GetDept = new Employee_View_GetDept(jBHRContext);

            var data = employee_View_GetDept.GetDeptView();
            Assert.AreEqual(40, data.Count, "取得筆數確認");
        }
    }
}
