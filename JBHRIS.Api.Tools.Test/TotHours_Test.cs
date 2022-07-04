using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Tools.Test
{
    [TestClass]
    public class TotHours_Test
    {
        [TestMethod]
        public void IntervalTotHours()
        {
            var TotHours = JBHRIS.Api.Tools.TotHours.IntervalTotHours(1M, 2M, 6.5M);
            Assert.AreEqual(7, TotHours, "計算錯誤");
        }
    }
}
