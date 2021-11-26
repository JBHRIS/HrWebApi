using JBHR.Sal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///這是 OtTypeTest 的測試類別，應該包含
    ///所有 OtTypeTest 單元測試
    ///</summary>
    [TestClass()]
    public class OtTypeTest
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
        ///OtType 建構函式 的測試
        ///</summary>
        [TestMethod()]
        public void OtTypeConstructorTest()
        {
            string nobr = "802511"; // TODO: 初始化為適當值
            string yymm = "201010"; // TODO: 初始化為適當值
            JBModule.Data.CDecryp.USER_ID = "TONY";
            OtType target = new OtType(nobr, yymm);
            Assert.IsTrue(true);
        }
    }
}
