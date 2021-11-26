using JBModule.Data.Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using JBModule.Data.Dto;

namespace AbsRepo_TestProject
{
    
    
    /// <summary>
    ///這是 AbsRepoTest 的測試類別，應該包含
    ///所有 AbsRepoTest 單元測試
    ///</summary>
    [TestClass()]
    public class AbsRepoTest
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
        ///GetAbsenceDetailistByCompany 的測試
        ///</summary>
        [TestMethod()]
        public void GetAbsenceDetailistByCompanyTest()
        {
            //AbsRepo target = new AbsRepo(); // TODO: 初始化為適當值
            //List<string> NobrList = new List<string>(); // TODO: 初始化為適當值
            //List<AbsenceDetail> expected = null; // TODO: 初始化為適當值
            //List<AbsenceDetail> actual;
            //NobrList.Add("10200130");
            //NobrList.Add("10200553");
            //NobrList.Add("10201113");
            //NobrList.Add("10200911");
            //NobrList.Add("10201228");

            
            //actual = target.GetAbsenceDetailistByCompany(NobrList);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("驗證這個測試方法的正確性。");
        }
    }
}
