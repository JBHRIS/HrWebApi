using JBHRIS.Api.Dal.JBHR.Employee.View;
using JBHRIS.Api.Dto.Employee.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JBHRIS.Api.Dal.JBHR.Test
{
    [TestClass]
    public class Employee_View_GetJobs_Test
    {
        [TestMethod]
        public void GetJobs_Test()
        {
            var jBHRContext = TestConfig.GetJBHRContext();
            Employee_View_GetJobs employee_View_GetJobs = new Employee_View_GetJobs(jBHRContext);
            List<JobDto> JoboList = employee_View_GetJobs.GetJob();
            int count = jBHRContext.Jobs.Count();
            Assert.AreEqual(count, JoboList.Count, "取得筆數確認");
        }
    }
}
