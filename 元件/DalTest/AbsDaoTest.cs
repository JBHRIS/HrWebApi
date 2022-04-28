using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DalTest
{
    [TestClass]
    public class AbsDaoTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            DateTime d1 = new DateTime(2020, 2, 29).Date;
            DateTime d2 = d1.AddMonths(1);

            d1 = new DateTime(2020, 1, 31).Date;
            d2 = d1.AddMonths(1);



            string Conn = "Data Source=192.168.1.12;Initial Catalog=AZOTEKHR;Persist Security Info=True;User ID=jb;Password=^Hsx9bu5t@";
            var oAbsDao = new Dal.Dao.Att.AbsDao(Conn);

            //var r = oAbsDao.GetCalculate("A014", "0001", new DateTime(2016, 12, 20), new DateTime(2016, 12, 28), "0730", "1630", true, true, 0, false, "", true);
            var r = oAbsDao.AbsSave("532", "0002", new DateTime(2017, 1, 5), new DateTime(2017, 1, 5), "1300", "1730");
            Assert.IsTrue(r != null);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string Conn = "Data Source=192.168.1.12;Initial Catalog=AZOTEKHR;Persist Security Info=True;User ID=jb;Password=JB8421";
            var o = new Dal.Dao.Att.TransCardDao(Conn);

            string Nobr = "221";
            DateTime DateB = new DateTime(2017, 1, 15).Date;
            DateTime DateE = new DateTime(2017,2, 16).Date;

            var r = o.TransCard(Nobr, Nobr, "0", "z", DateB, DateE, "ming", true, true, true, "", "A", true);

            Assert.IsTrue(r != null);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string Conn = "Data Source=192.168.1.12;Initial Catalog=AZOTEKHR;Persist Security Info=True;User ID=jb;Password=JB8421";
            var oAbsDao = new Dal.Dao.Att.AbsDao(Conn);

            var r = oAbsDao.GetCalculate("601", "0009", new DateTime(2016, 6, 20).Date, new DateTime(2016, 8, 14).Date, "0730", "1630", true, true, 0, false, "", true);
            Assert.IsTrue(r != null);
        }

        [TestMethod]
        public void TestMethod4()
        {
            string Conn = "Data Source=192.168.1.12;Initial Catalog=AZOTEKHR;Persist Security Info=True;User ID=jb;Password=JB8421";
            var oOtDao = new Dal.Dao.Att.OtDao(Conn);

            var r = oOtDao.GetCalculate("00464", "1", new DateTime(2019, 10, 15).Date, new DateTime(2019, 10, 15).Date, "1630", "1930","" , 0 , "" , true , true);
            //oOtDao.OtSave("102", "1", new DateTime(2017, 5, 28).Date, new DateTime(2017, 5, 29).Date, "1930", "0600", 12, 12, "", "", "", "", "", "", "", true);
            Assert.IsTrue(r != null);
        }
    }
}
