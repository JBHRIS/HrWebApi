using JBHRIS.Api.Dal.JBHR.Employee;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Test

{
    [TestClass]
    public  class Employee_Normal_GetPeopleByLeaveDate_Test
    {
        [TestMethod]
        public void GetPeopleByLeaveDate_Test()
        {
            
               var jBHRContext = TestConfig.GetJBHRContext();
            Employee_Normal_GetPeopleByLeaveDate employee_Normal_GetPeopleByLeaveDate = new Employee_Normal_GetPeopleByLeaveDate(jBHRContext);

            var data = employee_Normal_GetPeopleByLeaveDate.GetPeopleByLeaveDate(new DateTime(2019, 12, 31), new DateTime(2020, 05, 31));
             Assert.AreEqual(24, data.Count, "取得筆數確認");
        }
    }
}
