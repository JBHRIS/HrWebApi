using JBHRIS.Api.Dal.JBHR.Employee.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Api_Test
{
    [TestClass]
    public class Employee_View_GetDepts_Test
    {
        [TestMethod]
        public void GetDepts_Test()
        {

            var jBHRContext = TestConfig.GetJBHRContext();
            Employee_View_GetDepts employee_View_GetDepts = new Employee_View_GetDepts(jBHRContext);

            var data = employee_View_GetDepts.GetDeptView();
            Assert.AreEqual(14, data.Count, "取得筆數確認");
        }
    }
}
