using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dal.JBHR.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Test
{
    [TestClass]
    public class Employee_Normal_GetPeopleByBirthday_Test
    {
        [TestMethod]
        public void GetPeopleByBirthday_Test()
        {
            //var jBHRContext = TestConfig.GetJBHRContext();
            JBHRContext jBHRContext = new JBHRContext();
            var builder = new DbContextOptionsBuilder<JBHRContext>();
            var contextOption = builder.UseSqlServer("Data Source=192.168.1.12;Initial Catalog=StandardFoodsHR;Persist Security Info=True;User ID=jb;Password=^Hsx9bu5t@;").Options;
            jBHRContext = new JBHRContext(contextOption);

            Employee_Normal_GetPeopleByBirthday employee_Normal_GetPeopleByBirthday = new Employee_Normal_GetPeopleByBirthday(jBHRContext);
            var OnJobEmployeeList = getEmployeeListByFile(@".\TestData\Birthday\在職人員名單.txt");
            for (int i = 1; i <= 12; i++)
            {
                var data = employee_Normal_GetPeopleByBirthday.GetPeopleByBirthday(OnJobEmployeeList, new int[] { i });
                var Stars = getEmployeeListByFile(string.Format(@".\TestData\Birthday\{0}月壽星名單.txt", i.ToString()));
                Assert.AreEqual(Stars.Count, data.Count, string.Format("{0}月壽星名單取得筆數不符", i.ToString()));
                foreach (var item in data)
                    Assert.IsTrue(Stars.Contains(item), string.Format("{0}取得員編不符", item));
            }
        }

        private List<string> getEmployeeListByFile(string path)
        {
            var Result = new List<string>();
            int counter = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                Result.Add(line);
                counter++;
            }
            file.Close();
            return Result;
        }
    }
}
