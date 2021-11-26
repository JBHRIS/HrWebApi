using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Sal
{
    public class OtType
    {
        string _nobr, _yymm;
        /// <summary>
        /// 假日加班費-1
        /// </summary>
        public decimal HoliAmt1 = 0;
        /// <summary>
        /// 假日加班費-2
        /// </summary>
        public decimal HoliAmt2 = 0;
        /// <summary>
        /// 平日加班費-1
        /// </summary>
        public decimal NormalAmt1 = 0;
        /// <summary>
        /// 平日加班費-2
        /// </summary>
        public decimal NormalAmt2 = 0;
        /// <summary>
        /// 春節加班1.5
        /// </summary>
        public decimal SpringAmt15 = 0;
        /// <summary>
        /// 春節加班2.5
        /// </summary>
        public decimal SpringAmt25 = 0;
        /// <summary>
        /// 國定假日加班費
        /// </summary>
        public decimal CountryHoliAmt = 0;

        /// <summary>
        /// 假日加班總時數(1.5)
        /// </summary>
        public decimal HoliHrs = 0;
        /// <summary>
        /// 國定假日加班總時數(1.5)
        /// </summary>
        public decimal SpecHoliHrs = 0;
        /// <summary>
        /// 春節假日加班總時數(1.5)
        /// </summary>
        public decimal SpringHoliHrs15 = 0;
        /// <summary>
        /// 春節假日加班總時數(2.5)
        /// </summary>
        public decimal SpringHoliHrs25 = 0;
        /// <summary>
        /// 平日加班總時數(1.33)
        /// </summary>
        public decimal OT133Hrs = 0;
        /// <summary>
        /// 平日加班總時數(1.66)
        /// </summary>
        public decimal OT167Hrs = 0;

        /// <summary>
        /// 病假總時數
        /// </summary>
        public decimal SickHrs = 0;
        /// <summary>
        /// 病假總時數
        /// </summary>
        public decimal PersonHrs = 0;
        /// <summary>
        /// 未休假總時數
        /// </summary>
        public decimal YearLeftHrs = 0;
        public OtType(string nobr, string yymm)
        {
            _nobr = nobr;
            _yymm = yymm;
            SalaryMDDataContext db = new SalaryMDDataContext();
            var sqlTmp = from a in db.OT
                         join b in db.ATTEND on new { a.NOBR, a.BDATE.Date } equals new { b.NOBR, b.ADATE.Date }
                         where a.NOBR == _nobr && a.YYMM == _yymm
                         select new
                         {
                             a.OTRCD,
                             isHoli =CodeFunction.GetHolidayRoteList().Contains( b.ROTE),
                             OT_133 = a.NOT_W_133 + a.TOT_W_133,
                             RATE_133 = a.NOP_W_133,
                             OT_167 = a.NOT_W_167 + a.TOT_W_167,
                             RATE_167 = a.NOP_W_167,
                             OT_200 = a.NOT_H_200,
                             RATE_200 = a.NOP_H_200,
                             SALARY = a.SALARY
                         };
            var sql = from a in sqlTmp.ToList() select new { a.isHoli, a.OT_133, a.OT_167, a.OT_200, a.OTRCD, a.RATE_133, a.RATE_167, a.RATE_200, SALARY = JBModule.Data.CDecryp.Number(a.SALARY) / 240 };
            List<string> otrcdListSpecial = new List<string>();
            List<string> otrcdListSpring = new List<string>();
            otrcdListSpecial.Add("18");
            otrcdListSpecial.Add("19");
            otrcdListSpring.Add("20");
            otrcdListSpring.Add("21");
            var sqlNormal = sql.Where(p => !otrcdListSpecial.Contains(p.OTRCD) && !otrcdListSpring.Contains(p.OTRCD));
            var sqlSpecial = sql.Where(p => otrcdListSpecial.Contains(p.OTRCD) || otrcdListSpring.Contains(p.OTRCD));
            HoliAmt1 = sqlNormal.Sum(p => Math.Round(p.OT_200 * p.RATE_200 * p.SALARY));
            NormalAmt1 = sqlNormal.Sum(p => Math.Round(p.OT_133 * p.RATE_133 * p.SALARY));
            NormalAmt2 = sqlNormal.Sum(p => Math.Round(p.OT_167 * p.RATE_167 * p.SALARY));
            CountryHoliAmt = sqlSpecial.Where(p => otrcdListSpecial.Contains(p.OTRCD)).Sum(p => Math.Round(p.OT_200 * p.RATE_200 * p.SALARY));
            SpringAmt15 = sqlSpecial.Where(p => p.OTRCD == "20").Sum(p => Math.Round(p.OT_200 * p.RATE_200 * p.SALARY));
            SpringAmt25 = sqlSpecial.Where(p => p.OTRCD == "21").Sum(p => Math.Round(p.OT_200 * p.RATE_200 * p.SALARY));

            HoliHrs = sqlNormal.Sum(p => p.OT_200);
            SpecHoliHrs = sqlSpecial.Where(p => otrcdListSpecial.Contains(p.OTRCD)).Sum(p => p.OT_200);
            SpringHoliHrs15 = sqlSpecial.Where(p => p.OTRCD == "20").Sum(p => p.OT_200);
            SpringHoliHrs25 = sqlSpecial.Where(p => p.OTRCD == "21").Sum(p => p.OT_200);
            OT133Hrs = sqlNormal.Sum(p => p.OT_133);
            OT167Hrs = sqlNormal.Sum(p => p.OT_167);
            Sal.Core.SalaryDate sd = new Core.SalaryDate(_yymm);
            var absinfo = Dll.Att.AbsCal.AbsInfo(_nobr, sd.LastDayOfAttend);
            var absinfoOfSick = from a in absinfo where a.sHoliCode == "C" select a;
            var absinfoOfPerson = from a in absinfo where a.sHoliCode == "B" select a;
            var absinfoOfYear = from a in absinfo where a.sHoliCode == "2" select a;
            SickHrs = absinfoOfSick.Any() ? absinfoOfSick.First().iUse : 0;
            PersonHrs = absinfoOfPerson.Any() ? absinfoOfPerson.First().iUse : 0;
            YearLeftHrs = absinfoOfYear.Any() ? absinfoOfYear.First().iBalance : 0;
        }
    }
}
