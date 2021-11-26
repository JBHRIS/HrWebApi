using JBHRIS.Api.Dal.JBHR.Employee.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Test
{
    [TestClass]
    public class Employee_View_GetJob_Test
    {
        [TestMethod]
        public void GetJob()
        {
            var jbHRContext = TestConfig.GetJBHRContext();
            Employee_View_GetJob employee_View_GetJob = new Employee_View_GetJob(jbHRContext);
            var data = employee_View_GetJob.GetJob();
            Assert.AreEqual(45, data.Count, "取得筆數確認");
        }
        
    }
}
