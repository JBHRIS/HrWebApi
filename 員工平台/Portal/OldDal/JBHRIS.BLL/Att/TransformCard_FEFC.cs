using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Att
{
    public class TransformCard_FEFC
    {
        /// <summary>
        /// 判斷刷卡
        /// </summary>
        /// <param name="attendance"></param>
        /// <returns></returns>
        public virtual List<Tuple<DateTime?, DateTime?>> TransCard(Dto.AttendanceInfoDto attendance)
        {
            List<Tuple<DateTime?, DateTime?>> results = new List<Tuple<DateTime?, DateTime?>>();
            DateTime? T1, T2;
            T1 = null;
            T2 = null;
            foreach (var it in attendance.CardList)
            {
                if (it.Remark.Trim().ToUpper() == "IN")
                {
                    if (T1 == null)//未使用
                        T1 = it.Key;
                    else continue;//重複刷上班卡,略過
                }
                else if (it.Remark.Trim().ToUpper() == "OUT")
                {
                    if (T2 == null)//未使用
                        T2 = it.Key;
                    else continue;//重複刷上班卡,複寫
                    results.Add(new Tuple<DateTime?, DateTime?>(T1, T2));//寫入紀錄
                    T1 = null;
                    T2 = null;//清空重來
                }
            }
            if (T1 != null || T2 != null)//未進行完整判讀,補寫入
            {
                results.Add(new Tuple<DateTime?, DateTime?>(T1, T2));//寫入紀錄
                T1 = null;
                T2 = null;//清空重來
            }
            attendance.CardTimes = results;
            return results;
        }
    }
}
