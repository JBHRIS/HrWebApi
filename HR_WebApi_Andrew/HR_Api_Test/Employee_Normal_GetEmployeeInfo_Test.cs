using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dal.JBHR.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HR_Api_Test
{
    [TestClass]
    public class Employee_Normal_GetEmployeeInfo_Test
    {
        [TestMethod]
        public void GetEmployeeInfo_Test()
        {

            //jBHRContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var jBHRContext = TestConfig.GetJBHRContext();
            Employee_Normal_GetEmployeeInfo employee_Normal_GetEmployeeInfo = new Employee_Normal_GetEmployeeInfo(jBHRContext);
            var data = employee_Normal_GetEmployeeInfo.GetEmployeeInfo(new System.Collections.Generic.List<string> {
                "00021501"
                ,"1235"
                ,"A0003"
                ,"A0017"
                ,"A0025"
                ,"A0032" });
            Assert.AreEqual(4, data.Count, "取得筆數確認");
        }
    }
}
