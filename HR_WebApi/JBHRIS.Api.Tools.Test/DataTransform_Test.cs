using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Tools.Test
{
    [TestClass]
    public class DataTransform_Test
    {
        [TestMethod]
        public void GetAbsenteeismLists()
        {
            List<Tuple<DateTime, DateTime>> RestList = new List<Tuple<DateTime, DateTime>>();
            string dateRestB = "2020-10-11 13:00:00";
            string dateRestE = "2020-10-11 15:00:00";
            var parsedRestDateB = DateTime.Parse(dateRestB);
            var parsedRestDateE = DateTime.Parse(dateRestE);
            RestList.Add(new Tuple<DateTime, DateTime>(parsedRestDateB, parsedRestDateE));
            dateRestB = "2020-10-11 14:00:00";
            dateRestE = "2020-10-11 14:30:00";
            parsedRestDateB = DateTime.Parse(dateRestB);
            parsedRestDateE = DateTime.Parse(dateRestE);
            RestList.Add(new Tuple<DateTime, DateTime>(parsedRestDateB, parsedRestDateE));
            dateRestB = "2020-10-11 15:00:00";
            dateRestE = "2020-10-11 16:00:00";
            parsedRestDateB = DateTime.Parse(dateRestB);
            parsedRestDateE = DateTime.Parse(dateRestE);
            RestList.Add(new Tuple<DateTime, DateTime>(parsedRestDateB, parsedRestDateE));
            var RestTimesFixed = JBHRIS.Api.Tools.DataTransform.ReBindAttend(RestList);


            List<Tuple<DateTime, DateTime>> AttendList = new List<Tuple<DateTime, DateTime>>();
            string dateB = "2020-10-11 08:00:00";
            string dateE = "2020-10-11 17:00:00";
            var parsedDateB = DateTime.Parse(dateB);
            var parsedDateE = DateTime.Parse(dateE);
            //AttendList.Add(new Tuple<DateTime, DateTime>(parsedDateB, parsedDateE));
            //dateB = "2020-10-11 02:00:00";
            //dateE = "2020-10-11 02:30:00";
            //parsedDateB = DateTime.Parse(dateB);
            //parsedDateE = DateTime.Parse(dateE);
            AttendList.Add(new Tuple<DateTime, DateTime>(parsedDateB, parsedDateE));
            var GetAbsenteeismList = JBHRIS.Api.Tools.DataTransform.GetAbsenteeismList(AttendList, RestList);
            Assert.AreEqual("", "");

        }

        [TestMethod]
        public void GetRealAbsTimePeriod(){

            List<Tuple<DateTime, DateTime>> _attendanceRote = new List<Tuple<DateTime, DateTime>>();
            _attendanceRote.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2020-03-01 20:00:00"), DateTime.Parse("2020-03-02 04:00:00")));
            _attendanceRote.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2020-03-02 20:00:00"), DateTime.Parse("2020-03-03 04:00:00")));
            _attendanceRote.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2020-03-03 20:00:00"), DateTime.Parse("2020-03-04 04:00:00")));

            List<Tuple<DateTime, DateTime>> _restList = new List<Tuple<DateTime, DateTime>>();
            //_restList.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2020-03-02 01:00:00"), DateTime.Parse("2020-03-02 02:00:00")));
            //_restList.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2020-03-02 21:00:00"), DateTime.Parse("2020-03-02 23:00:00")));
            //_restList.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2020-03-02 22:00:00"), DateTime.Parse("2020-03-02 23:00:00")));
            //_restList.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2020-03-03 01:00:00"), DateTime.Parse("2020-03-03 02:00:00")));
            //_restList.Add(new Tuple<DateTime, DateTime>(DateTime.Parse("2020-03-04 01:00:00"), DateTime.Parse("2020-03-04 02:00:00")));

            Tuple<DateTime, DateTime> _userWrite = null;
            _userWrite = new Tuple<DateTime, DateTime>(DateTime.Parse("2020-03-02 03:00:00"), DateTime.Parse("2020-03-04 03:00:00"));
            var test = DataTransform.GetRealAbsTimePeriod(_attendanceRote, _restList, _userWrite);
            Assert.AreEqual("", "");
        }
    }
}
