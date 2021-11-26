using JBHR.BLL.Att;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using JBModule.Data.Linq;
using System.Data.Linq;
using System.Linq;
namespace TestProject1
{


    /// <summary>
    ///這是 HolidayTest 的測試類別，應該包含
    ///所有 HolidayTest 單元測試
    ///</summary>
    [TestClass()]
    public class HolidayTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///取得或設定提供目前測試回合的相關資訊與功能
        ///的測試內容。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 其他測試屬性
        // 
        //您可以在撰寫測試時，使用下列的其他屬性:
        //
        //在執行類別中的第一項測試之前，先使用 ClassInitialize 執行程式碼
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //在執行類別中的所有測試之後，使用 ClassCleanup 執行程式碼
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //在執行每一項測試之前，先使用 TestInitialize 執行程式碼
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //在執行每一項測試之後，使用 TestCleanup 執行程式碼
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///CreateYearHoliday 的測試
        ///</summary>
        [TestMethod()]
        public void CreateYearHolidayTest()
        {
            string nobr = string.Empty; // TODO: 初始化為適當值
            DateTime DDate = new DateTime(); // TODO: 初始化為適當值
            Holiday target = new Holiday(nobr, DDate); // TODO: 初始化為適當值
            DateTime In_date = new DateTime(); // TODO: 初始化為適當值
            BASETTS basetts = null; // TODO: 初始化為適當值
            int YEAR = 0; // TODO: 初始化為適當值
            Decimal TotalYears = new Decimal(); // TODO: 初始化為適當值
            Decimal yearrest_hrs = new Decimal(); // TODO: 初始化為適當值
            int stop_times = 0; // TODO: 初始化為適當值
            target.CalculationMode = CalcMode.Floor;
            Assert.AreEqual(4, target.CalcYearHoliday(1, new DateTime(2010, 1, 1)));
            Assert.AreEqual(4, target.CalcYearHoliday(1, new DateTime(2010, 2, 1)));
            Assert.AreEqual(4, target.CalcYearHoliday(1, new DateTime(2010, 3, 1)));
            Assert.AreEqual(3, target.CalcYearHoliday(1, new DateTime(2010, 4, 1)));
            Assert.AreEqual(3, target.CalcYearHoliday(1, new DateTime(2010, 5, 1)));
            Assert.AreEqual(3, target.CalcYearHoliday(1, new DateTime(2010, 6, 1)));
            Assert.AreEqual(2, target.CalcYearHoliday(1, new DateTime(2010, 7, 1)));
            Assert.AreEqual(2, target.CalcYearHoliday(1, new DateTime(2010, 8, 1)));
            Assert.AreEqual(2, target.CalcYearHoliday(1, new DateTime(2010, 9, 1)));
            Assert.AreEqual(1, target.CalcYearHoliday(1, new DateTime(2010, 10, 1)));
            Assert.AreEqual(1, target.CalcYearHoliday(1, new DateTime(2010, 11, 1)));
            Assert.AreEqual(1, target.CalcYearHoliday(1, new DateTime(2010, 12, 1)));

            Assert.AreEqual(10, target.CalcYearHoliday(2, new DateTime(2009, 1, 1)));
            Assert.AreEqual(10, target.CalcYearHoliday(2, new DateTime(2009, 2, 1)));
            Assert.AreEqual(10, target.CalcYearHoliday(2, new DateTime(2009, 3, 1)));
            Assert.AreEqual(8, target.CalcYearHoliday(2, new DateTime(2009, 4, 1)));
            Assert.AreEqual(8, target.CalcYearHoliday(2, new DateTime(2009, 5, 1)));
            Assert.AreEqual(8, target.CalcYearHoliday(2, new DateTime(2009, 6, 1)));
            Assert.AreEqual(6, target.CalcYearHoliday(2, new DateTime(2009, 7, 1)));
            Assert.AreEqual(6, target.CalcYearHoliday(2, new DateTime(2009, 8, 1)));
            Assert.AreEqual(6, target.CalcYearHoliday(2, new DateTime(2009, 9, 1)));
            Assert.AreEqual(4, target.CalcYearHoliday(2, new DateTime(2009, 10, 1)));
            Assert.AreEqual(4, target.CalcYearHoliday(2, new DateTime(2009, 11, 1)));
            Assert.AreEqual(4, target.CalcYearHoliday(2, new DateTime(2009, 12, 1)));

            Assert.AreEqual(10, target.CalcYearHoliday(3, new DateTime(2009, 12, 1)));

            Assert.AreEqual(10, target.CalcYearHoliday(4, new DateTime(2009, 12, 1)));

            Assert.AreEqual(10, target.CalcYearHoliday(5, new DateTime(2009, 12, 1)));

            Assert.AreEqual(15, target.CalcYearHoliday(6, new DateTime(2009, 12, 1)));

            Assert.AreEqual(15, target.CalcYearHoliday(7, new DateTime(2009, 12, 1)));

            Assert.AreEqual(15, target.CalcYearHoliday(8, new DateTime(2009, 12, 1)));

            Assert.AreEqual(15, target.CalcYearHoliday(9, new DateTime(2009, 12, 1)));

            Assert.AreEqual(15, target.CalcYearHoliday(10, new DateTime(2009, 12, 1)));

            Assert.AreEqual(20, target.CalcYearHoliday(11, new DateTime(2009, 12, 1)));

            Assert.AreEqual(20, target.CalcYearHoliday(12, new DateTime(2009, 12, 1)));

            Assert.AreEqual(20, target.CalcYearHoliday(13, new DateTime(2009, 12, 1)));

            Assert.AreEqual(20, target.CalcYearHoliday(14, new DateTime(2009, 12, 1)));

            Assert.AreEqual(20, target.CalcYearHoliday(15, new DateTime(2009, 12, 1)));

            Assert.AreEqual(20, target.CalcYearHoliday(16, new DateTime(2009, 12, 1)));

            Assert.AreEqual(21, target.CalcYearHoliday(17, new DateTime(2009, 12, 1)));

            Assert.AreEqual(22, target.CalcYearHoliday(18, new DateTime(2009, 12, 1)));

            Assert.AreEqual(23, target.CalcYearHoliday(19, new DateTime(2009, 12, 1)));

            Assert.AreEqual(24, target.CalcYearHoliday(20, new DateTime(2009, 12, 1)));

            Assert.AreEqual(25, target.CalcYearHoliday(21, new DateTime(2009, 12, 1)));

            Assert.AreEqual(26, target.CalcYearHoliday(22, new DateTime(2009, 12, 1)));

            Assert.AreEqual(27, target.CalcYearHoliday(23, new DateTime(2009, 12, 1)));

            Assert.AreEqual(28, target.CalcYearHoliday(24, new DateTime(2009, 12, 1)));

            Assert.AreEqual(29, target.CalcYearHoliday(25, new DateTime(2009, 12, 1)));

            Assert.AreEqual(30, target.CalcYearHoliday(26, new DateTime(2009, 12, 1)));

            Assert.AreEqual(30, target.CalcYearHoliday(27, new DateTime(2009, 12, 1)));

            //外勞
            HrDBDataContext db = new HrDBDataContext();
            target.parms = (from a in db.U_SYS8 where a.AUTO == 1 select a).First();

            Assert.AreEqual(0, target.CalcYearHoliday(0, new DateTime(2009, 12, 1)));
            Assert.AreEqual(0, target.CalcYearHoliday(0.5M, new DateTime(2009, 12, 1)));

            Assert.AreEqual(7, target.CalcYearHoliday(1, new DateTime(2009, 12, 1)));
            Assert.AreEqual(7, target.CalcYearHoliday(1.5M, new DateTime(2009, 12, 1)));

            Assert.AreEqual(7, target.CalcYearHoliday(2, new DateTime(2009, 12, 1)));
            Assert.AreEqual(7, target.CalcYearHoliday(2.5M, new DateTime(2009, 12, 1)));

            Assert.AreEqual(10, target.CalcYearHoliday(3, new DateTime(2009, 12, 1)));
            Assert.AreEqual(10, target.CalcYearHoliday(3.5M, new DateTime(2009, 12, 1)));

            Assert.AreEqual(10, target.CalcYearHoliday(4, new DateTime(2009, 12, 1)));
            Assert.AreEqual(10, target.CalcYearHoliday(4.5M, new DateTime(2009, 12, 1)));

            Assert.AreEqual(14, target.CalcYearHoliday(5, new DateTime(2009, 12, 1)));
            Assert.AreEqual(14, target.CalcYearHoliday(5.5M, new DateTime(2009, 12, 1)));

            Assert.AreEqual(14, target.CalcYearHoliday(6, new DateTime(2009, 12, 1)));
            Assert.AreEqual(14, target.CalcYearHoliday(6.5M, new DateTime(2009, 12, 1)));

            Assert.AreEqual(14, target.CalcYearHoliday(7, new DateTime(2009, 12, 1)));
            Assert.AreEqual(14, target.CalcYearHoliday(7.5M, new DateTime(2009, 12, 1)));

            Assert.AreEqual(14, target.CalcYearHoliday(8, new DateTime(2009, 12, 1)));

            Assert.AreEqual(14, target.CalcYearHoliday(9, new DateTime(2009, 12, 1)));

            Assert.AreEqual(15, target.CalcYearHoliday(10, new DateTime(2009, 12, 1)));

            Assert.AreEqual(16, target.CalcYearHoliday(11, new DateTime(2009, 12, 1)));

            Assert.AreEqual(17, target.CalcYearHoliday(12, new DateTime(2009, 12, 1)));

            Assert.AreEqual(18, target.CalcYearHoliday(13, new DateTime(2009, 12, 1)));

            Assert.AreEqual(19, target.CalcYearHoliday(14, new DateTime(2009, 12, 1)));

            Assert.AreEqual(20, target.CalcYearHoliday(15, new DateTime(2009, 12, 1)));

            Assert.AreEqual(21, target.CalcYearHoliday(16, new DateTime(2009, 12, 1)));

            Assert.AreEqual(22, target.CalcYearHoliday(17, new DateTime(2009, 12, 1)));

            Assert.AreEqual(23, target.CalcYearHoliday(18, new DateTime(2009, 12, 1)));

            Assert.AreEqual(24, target.CalcYearHoliday(19, new DateTime(2009, 12, 1)));

            Assert.AreEqual(25, target.CalcYearHoliday(20, new DateTime(2009, 12, 1)));

            Assert.AreEqual(26, target.CalcYearHoliday(21, new DateTime(2009, 12, 1)));

            Assert.AreEqual(27, target.CalcYearHoliday(22, new DateTime(2009, 12, 1)));

            Assert.AreEqual(28, target.CalcYearHoliday(23, new DateTime(2009, 12, 1)));

            Assert.AreEqual(29, target.CalcYearHoliday(24, new DateTime(2009, 12, 1)));

            Assert.AreEqual(30, target.CalcYearHoliday(25, new DateTime(2009, 12, 1)));

            Assert.AreEqual(30, target.CalcYearHoliday(26, new DateTime(2009, 12, 1)));

            Assert.AreEqual(30, target.CalcYearHoliday(27, new DateTime(2009, 12, 1)));
        }

        /// <summary>
        ///Holiday 建構函式 的測試
        ///</summary>
        [TestMethod()]
        public void HolidayConstructorTest()
        {
            string nobr = "F10091"; // TODO: 初始化為適當值
            DateTime DDate = new DateTime(2011,3,18); // TODO: 初始化為適當值
            Holiday target = new Holiday(nobr, DDate);
            decimal Actual = 0;
            decimal Expect = 56;
            Actual = target.SpecialLeaveTotalDays;
            Assert.AreEqual(Expect, Actual);
        }


        /// <summary>
        ///GetCurrentHours 的測試
        ///</summary>
        [TestMethod()]
        public void GetCurrentHoursTest()
        {
            string nobr = string.Empty; // TODO: 初始化為適當值
            DateTime DDate = new DateTime(); // TODO: 初始化為適當值
            Holiday target = new Holiday(nobr, DDate); // TODO: 初始化為適當值
            string sYearRest = string.Empty; // TODO: 初始化為適當值
            Decimal expected = new Decimal(); // TODO: 初始化為適當值
            Decimal actual;
            actual = target.GetCurrentHours(sYearRest);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("驗證這個測試方法的正確性。");
        }
    }
}
