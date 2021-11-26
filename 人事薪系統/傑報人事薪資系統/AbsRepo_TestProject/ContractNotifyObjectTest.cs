using JBHR.BLL.Sys;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AbsRepo_TestProject
{
    
    
    /// <summary>
    ///這是 ContractNotifyObjectTest 的測試類別，應該包含
    ///所有 ContractNotifyObjectTest 單元測試
    ///</summary>
    [TestClass()]
    public class ContractNotifyObjectTest
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
        ///GetNotifyEvent 的測試
        ///</summary>
        [TestMethod()]
        public void GetNotifyEventTest()
        {
            ContractNotifyObject target = new ContractNotifyObject(); // TODO: 初始化為適當值
            List<string> SourceRoleList = new List<string>(); // TODO: 初始化為適當值
            DateTime DateBegin = new DateTime(2013,01,01); // TODO: 初始化為適當值
            DateTime DateEnd = new DateTime(2013,05,31); // TODO: 初始化為適當值
            List<INotifyEvent> expected = null; // TODO: 初始化為適當值
            List<INotifyEvent> actual;
            actual = target.GetNotifyEvent(SourceRoleList, DateBegin, DateEnd,"AA01LT");
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("驗證這個測試方法的正確性。");
        }
    }
}
