using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Api_Test
{
    [TestClass]
    public class Sample_Test
    {
        [TestMethod]
        public void GetError_Test()
        {
            Assert.AreEqual(1, 1, "錯誤測試");
        }
    }
}
