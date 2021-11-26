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
    public class Employee_View_GetJobo_Test
    {
        [TestMethod]
        public void GetJobo_Test()
        {
            var jBHRContext = TestConfig.GetJBHRContext();
            Employee_View_GetJobo employee_View_GetJobo = new Employee_View_GetJobo(jBHRContext);
            List<JobDto> JoboList = employee_View_GetJobo.GetJob();
            int count = jBHRContext.Jobo.Count();
            Assert.AreEqual(count, JoboList.Count, "取得筆數確認");
        }
    }
}
