using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using JBHRIS.Api.Tools;
namespace JBHRIS.Api.Tools.Test
{
    [TestClass]
    public class DataProcess_UnitTest
    {
        [TestMethod]
        public void Split_CheckSum_10000000_Test()
        {
            List<int> testData = new List<int>();
            for (int i = 0; i < 10000000; i++)
            {
                testData.Add(i);
            }
            var result = testData.Split(1000);
            Assert.AreEqual(10000, result.Count);
        }
        [TestMethod]
        public void Split_CheckSum_500_Test()
        {
            List<int> testData = new List<int>();
            for (int i = 0; i < 500; i++)
            {
                testData.Add(i);
            }
            var result = testData.Split(1000);
            Assert.AreEqual(1, result.Count);
        }
        [TestMethod]
        public void Split_CheckSum_2100_Test()
        {
            List<int> testData = new List<int>();
            for (int i = 0; i < 2100; i++)
            {
                testData.Add(i);
            }
            var result = testData.Split(1000);
            Assert.AreEqual(3, result.Count);
        }
        [TestMethod]
        public void Split_CheckSum_2100_Step1500_Test()
        {
            List<int> testData = new List<int>();
            for (int i = 0; i < 2100; i++)
            {
                testData.Add(i);
            }
            var result = testData.Split(1500);
            Assert.AreEqual(2, result.Count);
        }
    }
}
