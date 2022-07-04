using JBHRIS.Api.Dal.JBHR.Employee.View;
using JBHRIS.Api.Dal.JBHR.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Api_Test
{
    [TestClass]
    public class Employee_View_GetJobl_Test
    {
        [TestMethod]
        public void GetJob1()
        {
            IUnitOfWork jbHRContext = new JbhrUnitOfWork(TestConfig.GetJBHRContext());
            Employee_View_GetJobl employee_View_GetJobl = new Employee_View_GetJobl(jbHRContext);
            var data = employee_View_GetJobl.GetJob();
            Assert.AreEqual(1, data.Count, "取得筆數確認");
        }
    }
}
