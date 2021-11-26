using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ApiTest
{
    [TestClass]
    public class GenerateData
    {
        [TestMethod]
        public void Generate()
        {
            var ListEmpId = new List<string>();

            for (int i = 1; i <= 100; i++)
            {
                var EmpId = Bll.Tools.GenerateData.GenerateCreateVid();
                ListEmpId.Add(EmpId);
            }

            var ListName = new List<string>();

            for (int i = 1; i <= 100; i++)
            {
                var Name = Bll.Tools.GenerateData.GenerateChineseName(3);
                ListName.Add(Name);
            }

            var ListDate = new List<DateTime>();

            for (int i = 1; i <= 100; i++)
            {
                var Date = Bll.Tools.GenerateData.GenerateDate(60);
                ListDate.Add(Date);
            }
            var ss = JsonConvert.SerializeObject("1111aaas");

            Assert.AreEqual(null, null);
        }
    }
}
