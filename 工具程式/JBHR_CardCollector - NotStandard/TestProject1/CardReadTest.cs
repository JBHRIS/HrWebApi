using JBHR_CardTextCollector;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using JBModule.Data.Linq;
using System.Data.Linq;
namespace TestProject1
{


    /// <summary>
    ///這是 CardReadTest 的測試類別，應該包含
    ///所有 CardReadTest 單元測試
    ///</summary>
    [TestClass()]
    public class CardReadTest
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
        ///CardRead 建構函式 的測試
        ///</summary>
        [TestMethod()]
        public void CardReadConstructorTest()
        {
            JBModule.Data.Linq.HrDBDataContext db = new HrDBDataContext();
            var sql = from a in db.U_SYS7 select a;
            string record = "10260001,20130301,0717,16689254"; // TODO: 初始化為適當值
            U_SYS7 CardParms = sql.First(); // TODO: 初始化為適當值
            CardRead target = new CardRead(record, CardParms);
            Assert.Inconclusive("TODO: 實作程式碼以驗證目標");
        }

        /// <summary>
        ///Adate 的測試
        ///</summary>
        //[TestMethod()]
        public void AdateTest()
        {
            string record = string.Empty; // TODO: 初始化為適當值
            U_SYS7 CardParms = null; // TODO: 初始化為適當值
            CardRead target = new CardRead(record, CardParms); // TODO: 初始化為適當值
            DateTime actual;
            actual = target.Adate;
            Assert.Inconclusive("驗證這個測試方法的正確性。");
        }

        /// <summary>
        ///Atime 的測試
        ///</summary>
        //[TestMethod()]
        public void AtimeTest()
        {
            string record = string.Empty; // TODO: 初始化為適當值
            U_SYS7 CardParms = null; // TODO: 初始化為適當值
            CardRead target = new CardRead(record, CardParms); // TODO: 初始化為適當值
            string actual;
            actual = target.Atime;
            Assert.Inconclusive("驗證這個測試方法的正確性。");
        }

        /// <summary>
        ///Day 的測試
        ///</summary>
        //[TestMethod()]
        public void DayTest()
        {
            string record = string.Empty; // TODO: 初始化為適當值
            U_SYS7 CardParms = null; // TODO: 初始化為適當值
            CardRead target = new CardRead(record, CardParms); // TODO: 初始化為適當值
            int actual;
            actual = target.Day;
            Assert.Inconclusive("驗證這個測試方法的正確性。");
        }

        /// <summary>
        ///Month 的測試
        ///</summary>
        //[TestMethod()]
        public void MonthTest()
        {
            string record = string.Empty; // TODO: 初始化為適當值
            U_SYS7 CardParms = null; // TODO: 初始化為適當值
            CardRead target = new CardRead(record, CardParms); // TODO: 初始化為適當值
            int actual;
            actual = target.Month;
            Assert.Inconclusive("驗證這個測試方法的正確性。");
        }

        /// <summary>
        ///Year 的測試
        ///</summary>
        //[TestMethod()]
        public void YearTest()
        {
            string record = string.Empty; // TODO: 初始化為適當值
            U_SYS7 CardParms = null; // TODO: 初始化為適當值
            CardRead target = new CardRead(record, CardParms); // TODO: 初始化為適當值
            int actual;
            actual = target.Year;
            Assert.Inconclusive("驗證這個測試方法的正確性。");
        }
    }
}
