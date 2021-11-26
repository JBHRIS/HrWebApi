using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Att
{
    public class TransformCard
    {
        public string KeyMan = "";
        /// <summary>
        /// 判斷刷卡
        /// </summary>
        /// <param name="attendance"></param>
        /// <returns></returns>
        public virtual List<Dto.AttcardDto> TransCard(Dto.AttendanceInfoDto attendance)
        {
            List<Dto.AttcardDto> results = new List<Dto.AttcardDto>();
            foreach (var it in attendance.CardTimes)
            {
                if (it.CantModify)
                    results.Add(it);
            }
            DateTime? T1, T2;
            T1 = null;
            T2 = null;
            bool los1 = false, los2 = false;
            if (attendance.CardList.Count() > 0)
            {
                var card = attendance.CardList.OrderBy(p => p.CardTime).First();
                T1 = card.CardTime;
                if (card.ForgetCard)
                    los1 = true;
            }
            if (attendance.CardList.Count() > 1)
            {
                var card = attendance.CardList.OrderBy(p => p.CardTime).Last();
                T2 = card.CardTime;
                if (card.ForgetCard)
                    los2 = true;
            }
            if (T1 != null || T2 != null)
            {
                Dto.AttcardDto attcard = new Dto.AttcardDto();
                attcard.AttendanceDate = attendance.AttendanceDate;
                attcard.BeginTime = T1;
                attcard.EndTime = T2;
                attcard.OnTimeForget = los1;
                attcard.OffTimeForget = los2;
                attcard.EmployeeID = attendance.EmployeeID;
                attcard.CantModify = false;
                attcard.CreateMan = KeyMan;
                if (!results.Where(p => p.BeginTime.Value.Date == attcard.BeginTime.Value.Date).Any())//無重複
                    results.Add(attcard);
            }

            attendance.CardTimes = results;
            return results;
        }
    }
}
