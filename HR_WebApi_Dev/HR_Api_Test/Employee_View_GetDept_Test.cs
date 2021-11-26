using JBHRIS.Api.Dal.JBHR.Employee.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Test
{
    [TestClass]
    public class Employee_View_GetDept_Test
    {
        [TestMethod]
        public void GetDept_Test()
        {

            var jBHRContext = TestConfig.GetJBHRContext();
            var DeptFile = System.IO.File.ReadAllText(@"TestData\Entity\Dept.json");
            var DeptData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dept>>(DeptFile);
            jBHRContext.Dept.AddRange(DeptData);
            jBHRContext.SaveChanges();
            Employee_View_GetDept employee_View_GetDept = new Employee_View_GetDept(jBHRContext);

            var data = employee_View_GetDept.GetDeptView();
            Assert.AreEqual(40, data.Count, "取得筆數確認");
        }
    }
}
