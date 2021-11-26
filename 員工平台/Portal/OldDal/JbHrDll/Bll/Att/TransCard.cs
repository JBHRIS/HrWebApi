using System;
using System.Collections.Generic;
using System.Linq;
using OldBll.Att.Vdb;

namespace OldBll.Att
{
    /// <summary>
    /// 刷卡轉出勤商業規則
    /// </summary>
    public class TransCard
    {
        /// <summary>
        /// 實際出勤資料 單天
        /// </summary>
        /// <param name="rsCard">刷卡資料</param>
        /// <param name="Date">日期</param>
        /// <param name="bEzAttCard">簡單轉換True = 簡單(一天多筆的情況，才需要複雜的判斷)</param>
        /// <returns>AttCardTable</returns>
        public List<AttCardTable> AttCardByOneDay(List<CardTable> rsCard, DateTime Date, bool bEzAttCard = true)
        {
            List<AttCardTable> rsAttCard = new List<AttCardTable>();

            //var rsCard = obVdb.CardDataDay;

            //至少要有一筆資料
            if (rsCard.Any())
            {
                rsCard = rsCard.OrderBy(p => p.CardDateTime).ToList();

                //簡單判斷
                if (bEzAttCard)
                {
                    var rAttCard = new AttCardTable();

                    //正向排序取第一筆
                    var rCard = rsCard.First();
                    rAttCard.Nobr = rCard.Nobr;
                    rAttCard.Date = rCard.CardDate.Date;
                    rAttCard.OnCardTime24 = rCard.CardTime24;
                    rAttCard.OnCardTime48 = Date < rCard.CardDate ? Convert.ToString(Convert.ToInt32(rCard.CardTime24) + 2400) : rCard.CardTime24;
                    rCard.CardTime48 = rAttCard.OnCardTime48;
                    rAttCard.OnLos = rCard.Los;
                    rAttCard.DT1 = rCard.CardDateTime;

                    //兩筆以上的刷卡資料就取最後一筆
                    if (rsCard.Count() >= 2)
                    {
                        rCard = rsCard.Last();
                        rAttCard.OffCardTime24 = rCard.CardTime24;
                        rAttCard.OffCardTime48 = Date < rCard.CardDate ? Convert.ToString(Convert.ToInt32(rCard.CardTime24) + 2400) : rCard.CardTime24;
                        rCard.CardTime48 = rAttCard.OffCardTime48;
                        rAttCard.OffLos = rCard.Los;
                        rAttCard.DT2 = rCard.CardDateTime;
                    }
                    else
                    {
                        rAttCard.OffCardTime24 = "";
                        rAttCard.OffCardTime48 = "";
                        rAttCard.OffLos = false;
                    }

                    rsAttCard.Add(rAttCard);
                }
                else
                {
                    int x1, x2, j = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(rsCard.Count) / 2));    //先除以2 再無條件進位
                    for (int i = 0; i < j; i++)
                    {
                        x1 = (i == 0) ? 0 : (i * 2);    //T1
                        x2 = (x1 + 1);  //T2

                        var rAttCard = new AttCardTable();

                        var rCard = rsCard[x1];
                        rAttCard.Nobr = rCard.Nobr;
                        rAttCard.Date = rCard.CardDate.Date;
                        rAttCard.OnCardTime24 = rCard.CardTime24;
                        rAttCard.OnCardTime48 = Date < rCard.CardDate ? Convert.ToString(Convert.ToInt32(rCard.CardTime24) + 2400) : rCard.CardTime24;
                        rCard.CardTime48 = rAttCard.OnCardTime48;
                        rAttCard.OnLos = rCard.Los;
                        rAttCard.DT1 = rCard.CardDateTime;

                        if (rsCard.Count > x2 && rsCard.Count > 1)
                        {
                            rCard = rsCard[x2];
                            rAttCard.OffCardTime24 = rCard.CardTime24;
                            rAttCard.OffCardTime48 = Date < rCard.CardDate ? Convert.ToString(Convert.ToInt32(rCard.CardTime24) + 2400) : rCard.CardTime24;
                            rCard.CardTime48 = rAttCard.OffCardTime48;
                            rAttCard.OffLos = rCard.Los;
                            rAttCard.DT2 = rCard.CardDateTime;
                        }
                        else
                        {
                            rAttCard.OffCardTime24 = "";
                            rAttCard.OffCardTime48 = "";
                            rCard.CardTime48 = "";
                            rAttCard.OffLos = false;
                        }

                        rsAttCard.Add(rAttCard);
                    }
                }
            }

            return rsAttCard;
        }

        /// <summary>
        /// 實際出勤資料 單天
        /// </summary>
        /// <param name="rsCard">刷卡資料</param>
        /// <param name="Date">日期</param>
        /// <param name="bEzAttCard">簡單轉換True = 簡單(一天多筆的情況，才需要複雜的判斷)</param>
        /// <param name="OnTimeCode">上班代碼</param>
        /// <param name="OffTimeCode">下班代碼</param>
        /// <returns>AttCardTable</returns>
        public List<AttCardTable> AttCardByOneDay(List<CardTable> rsCard, DateTime Date, bool bEzAttCard = true, string OnTimeCode = "01", string OffTimeCode = "02")
        {
            List<AttCardTable> rsAttCard = new List<AttCardTable>();

            //var rsCard = obVdb.CardDataDay;

            //至少要有一筆資料
            if (rsCard.Any())
            {
                rsCard = rsCard.OrderBy(p => p.CardDateTime).ToList();

                //簡單判斷
                if (bEzAttCard)
                {
                    var rCard = rsCard.First();

                    var rAttCard = new AttCardTable();
                    rAttCard.Nobr = rCard.Nobr;
                    rAttCard.Date = rCard.CardDate.Date;

                    //正向排序取第一筆上班時間
                    rCard = rsCard.FirstOrDefault(p=>p.Code == OnTimeCode);
                    if (rCard != null)
                    {
                        rAttCard.OnCardTime24 = rCard.CardTime24;
                        rAttCard.OnCardTime48 = Date < rCard.CardDate ? Convert.ToString(Convert.ToInt32(rCard.CardTime24) + 2400) : rCard.CardTime24;
                        rCard.CardTime48 = rAttCard.OnCardTime48;
                        rAttCard.OnLos = rCard.Los;
                        rAttCard.DT1 = rCard.CardDateTime;
                    }
                    else
                    {
                        rAttCard.OnCardTime24 = "";
                        rAttCard.OnCardTime48 = "";
                        rAttCard.OnLos = false;
                    }

                    rCard = rsCard.LastOrDefault(p => p.Code == OffTimeCode);

                    //正向排序最後一筆下班時間
                    if (rCard != null)
                    {                        
                        rAttCard.OffCardTime24 = rCard.CardTime24;
                        rAttCard.OffCardTime48 = Date < rCard.CardDate ? Convert.ToString(Convert.ToInt32(rCard.CardTime24) + 2400) : rCard.CardTime24;
                        rCard.CardTime48 = rAttCard.OffCardTime48;
                        rAttCard.OffLos = rCard.Los;
                        rAttCard.DT2 = rCard.CardDateTime;
                    }
                    else
                    {
                        rAttCard.OffCardTime24 = "";
                        rAttCard.OffCardTime48 = "";
                        rAttCard.OffLos = false;
                    }

                    rsAttCard.Add(rAttCard);
                }
                else
                {

                    List<List<CardTable>> AllMultiCardList = new List<List<CardTable>>();
                    List<CardTable> MultiCardList = new List<CardTable>();

                    string flag1 = OnTimeCode;
                    bool flag2 = true;

                    foreach (var rCard in rsCard)
                    {
                        if (flag1 == OffTimeCode && flag1 != rCard.Code)
                            flag2 = true;

                        if (flag2)
                        {
                            MultiCardList = new List<CardTable>();
                            AllMultiCardList.Add(MultiCardList);
                        }

                        MultiCardList.Add(rCard);

                        flag2 = false;
                        flag1 = rCard.Code;
                    }

                    foreach (var rsAllMultiCardList in AllMultiCardList)
                    {
                        var rCard = rsAllMultiCardList.First();

                        var rAttCard = new AttCardTable();
                        rAttCard.Nobr = rCard.Nobr;
                        rAttCard.Date = rCard.CardDate.Date;

                        //正向排序取第一筆上班時間
                        rCard = rsAllMultiCardList.FirstOrDefault(p => p.Code == OnTimeCode);
                        if (rCard != null)
                        {
                            rAttCard.OnCardTime24 = rCard.CardTime24;
                            rAttCard.OnCardTime48 = Date < rCard.CardDate ? Convert.ToString(Convert.ToInt32(rCard.CardTime24) + 2400) : rCard.CardTime24;
                            rCard.CardTime48 = rAttCard.OnCardTime48;
                            rAttCard.OnLos = rCard.Los;
                            rAttCard.DT1 = rCard.CardDateTime;
                        }
                        else
                        {
                            rAttCard.OnCardTime24 = "";
                            rAttCard.OnCardTime48 = "";
                            rAttCard.OnLos = false;
                        }

                        rCard = rsAllMultiCardList.LastOrDefault(p => p.Code == OffTimeCode);

                        //正向排序最後一筆下班時間
                        if (rCard != null)
                        {
                            rAttCard.OffCardTime24 = rCard.CardTime24;
                            rAttCard.OffCardTime48 = Date < rCard.CardDate ? Convert.ToString(Convert.ToInt32(rCard.CardTime24) + 2400) : rCard.CardTime24;
                            rCard.CardTime48 = rAttCard.OffCardTime48;
                            rAttCard.OffLos = rCard.Los;
                            rAttCard.DT2 = rCard.CardDateTime;
                        }
                        else
                        {
                            rAttCard.OffCardTime24 = "";
                            rAttCard.OffCardTime48 = "";
                            rAttCard.OffLos = false;
                        }

                        rsAttCard.Add(rAttCard);
                    }
                }
            }

            return rsAttCard;
        }

        /// <summary>
        /// 實際出勤資料 單天 山立
        /// </summary>
        /// <param name="rsCard">刷卡資料</param>
        /// <param name="Date">日期</param>
        /// <param name="OnTimeCode">上班代碼</param>
        /// <param name="OffTimeCode">下班代碼</param>
        /// <returns>AttCardTable</returns>
        public List<AttCardTable> AttCardByOneDay(List<CardTable> rsCard, DateTime Date, string OnTimeCode = "A", string OffTimeCode = "B")
        {
            List<AttCardTable> rsAttCard = new List<AttCardTable>();

            //var rsCard = obVdb.CardDataDay;

            //至少要有一筆資料
            if (rsCard.Any())
            {
                OldBll.Att.Vdb.CardTable rCard = rsCard.First();

                var rAttCard = new AttCardTable();

                rAttCard.Nobr = rCard.Nobr;
                rAttCard.Date = Date;

                rCard = null;

                var rs = rsCard.Where(p => p.Code == OnTimeCode);
                if (rs.Any())
                {
                    rs = rs.OrderBy(p => p.CardDateTime).ToList();
                    rCard = rs.First();
                }
                else
                {
                    //嘗試尋找下班的CODE的最後一筆 並記下時間
                    rs = rsCard.Where(p => p.Code == OffTimeCode);
                    DateTime? CardDateTime = null;
                    if (rs.Any())
                    {
                        rs = rs.OrderBy(p => p.CardDateTime).ToList();
                        rCard = rs.Last();
                        CardDateTime = rCard.CardDateTime;
                    }

                    rCard = null;

                    //尋找不等於下班的CODE 且 小於下班時間(如果有的話)
                    rs = rsCard.Where(p => p.Code != OffTimeCode && (CardDateTime == null ? true : (p.CardDateTime < CardDateTime.Value)));
                    if (rs.Any())
                    {
                        rs = rs.OrderBy(p => p.CardDateTime).ToList();
                        rCard = rs.First();
                    }
                }

                if (rCard != null)
                {
                    rAttCard.OnCardTime24 = rCard.CardTime24;
                    rAttCard.OnCardTime48 = Date < rCard.CardDate ? Convert.ToString(Convert.ToInt32(rCard.CardTime24) + 2400) : rCard.CardTime24;
                    rCard.CardTime48 = rAttCard.OnCardTime48;
                    rAttCard.OnLos = rCard.Los;
                    rAttCard.DT1 = rCard.CardDateTime;
                }
                else
                {
                    rAttCard.OnCardTime24 = "";
                    rAttCard.OnCardTime48 = "";
                    rAttCard.OnLos = false;
                }

                //==========================================================

                rs = rsCard.Where(p => p.Code == OffTimeCode);
                if (rs.Any())
                {
                    rs = rs.OrderBy(p => p.CardDateTime).ToList();
                    rCard = rs.Last();
                }
                else
                {
                    //嘗試尋找上班的CODE的第一筆 並記下時間
                    rs = rsCard.Where(p => p.Code == OnTimeCode);
                    DateTime? CardDateTime = null;
                    if (rs.Any())
                    {
                        rs = rs.OrderBy(p => p.CardDateTime).ToList();
                        rCard = rs.First();
                        CardDateTime = rCard.CardDateTime;
                    }

                    rCard = null;

                    //尋找不等於上班的CODE 且 大於上班時間(如果有的話)
                    rs = rsCard.Where(p => p.Code != OnTimeCode && (CardDateTime == null ? true : (p.CardDateTime > CardDateTime.Value)));
                    if (rs.Any())
                    {
                        rs = rs.OrderBy(p => p.CardDateTime).ToList();
                        rCard = rs.Last();
                    }
                }

                if (rCard != null)
                {
                    rAttCard.OffCardTime24 = rCard.CardTime24;
                    rAttCard.OffCardTime48 = Date < rCard.CardDate ? Convert.ToString(Convert.ToInt32(rCard.CardTime24) + 2400) : rCard.CardTime24;
                    rCard.CardTime48 = rAttCard.OffCardTime48;
                    rAttCard.OffLos = rCard.Los;
                    rAttCard.DT2 = rCard.CardDateTime;
                }
                else
                {
                    rAttCard.OffCardTime24 = "";
                    rAttCard.OffCardTime48 = "";
                    rAttCard.OffLos = false;
                }

                rsAttCard.Add(rAttCard);

            }

            return rsAttCard;
        }

        /// <summary>
        /// 判斷異常
        /// </summary>
        /// <param name="rsAttCard">出勤資料</param>
        /// <param name="rRote">班別資料</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="dDate">判斷日期</param>
        /// <param name="bElasticity">判斷如果刷卡後時間超過彈性後時間則無彈性 預設False</param>
        /// <returns>AttEndTable</returns>
        public AttEndTable AttEndByOneDayByMultiRes(List<AttCardTable> rsAttCard, RoteTable rRote, List<AbsTable> rsAbs, DateTime dDate, bool bElasticity = false)
        {
            bool IsHoliDay = rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0;

            var rAttEnd = new AttEndTable();

            List<AttEndTempTable> rsAttEndTempTable = new List<AttEndTempTable>();

            //var rsAttCard = obVdb.AttCardDataDay;
            //var rRote = obVdb.RoteDataDay;
            //var rsAbs = obVdb.AbsDataDay;

            DateTime Date = dDate.Date;
            DateTime DateTimeA, DateTimeD;    //實際應出勤上下班日期時間
            DateTime DateTimeA1;   //加入可遲到分鐘數後
            DateTime DateTimeA2;   //加入彈性分鐘數後
            DateTime DateTimeX; //暫存

            DateTimeA = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));    //實際應出勤上班日期時間
            DateTimeD = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));   //實際應出勤下班日期時間

            DateTimeA1 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.LatesMin));    //先加入可遲到分鐘數
            DateTimeA2 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.ElasticityMin));   //再加入彈性分鐘數

            //忘刷次數小於等於1：比對請假資料
            //忘刷次數大於等於2：比對上下班時間
            //請假時間不正確再比對請假資料

            //計算忘刷次數
            rAttEnd.Card = rsAttCard.Where(p => p.OnLos).Count() + rsAttCard.Where(p => p.OffLos).Count();

            //Type = 1 = 出勤
            //Type = 2 = 休息
            //Type = 3 = 請假

            //計算提早來跟延後走的分鐘數
            rAttEnd.EarlyMin = 0;
            rAttEnd.DelayMin = 0;
            if (rsAttCard.Count == 1 && rRote != null && !IsHoliDay)
            {
                var rAttCard = rsAttCard[0];
                if (rAttCard.OnCardTime48.Trim().Length > 0 && rRote.OnTime.CompareTo(rAttCard.OnCardTime48) > 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48);

                    rAttEnd.EarlyMin = iRoteMin - iCardMin;
                }

                if (rAttCard.OffCardTime48.Trim().Length > 0 && rRote.OffTime.CompareTo(rAttCard.OffCardTime48) < 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48);

                    rAttEnd.DelayMin = iCardMin - iRoteMin;
                }
            }

            //出勤
            foreach (var rAttCard in rsAttCard)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48));
                if (rAttCard.OffCardTime48 != null && rAttCard.OffCardTime48.Trim().Length == 0)
                {
                    rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                    if (rAttEndTemp.DateTimeE < DateTimeA)
                        rAttEndTemp.DateTimeE = DateTimeA;
                }
                    
                rAttEndTemp.Type = AttEndType.Att;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            //休息
            foreach (var rRes in rRote.DayRes)
            {
                //一定要有在出勤時間裡才需要被加進來 可以放在外面 不要在這邊判斷
                if (rRote.OnTime.Trim().CompareTo(rRes.ResE) <= 0
                && rRote.OffTime.Trim().CompareTo(rRes.ResB) >= 0)
                {
                    var rAttEndTemp = new AttEndTempTable();
                    rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResB));
                    rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResE));
                    rAttEndTemp.Type = AttEndType.Res;
                    rsAttEndTempTable.Add(rAttEndTemp);
                }
            }

            //請假
            foreach (var rAbs in rsAbs)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = rAbs.DateTimeB;
                rAttEndTemp.DateTimeE = rAbs.DateTimeE;
                rAttEndTemp.Type = AttEndType.Abs;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            var tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();

            //如果沒有出勤也沒有請假資料就是曠職
            if (tlAttend.Where(p => p.Type == AttEndType.Att || p.Type == AttEndType.Abs).Count() == 0)
                rAttEnd.Abs = true;
            else
            {
                //第一筆如果不是出勤資料，則應該是上午請假
                //反之如下
                //取得實際出勤的上下班時間(應加入可遲到分鐘數及彈性分鐘數)目前僅可以選一種
                //if (tlAttend[0].Type == AttEndType.Att)
                {
                    //可遲到分鐘數
                    if (rRote.LatesMin > rRote.ElasticityMin)
                    {
                        if (rRote.LatesMin > 0)
                        {
                            var tlAtts = tlAttend.Where(p => p.Type == AttEndType.Att).ToList();

                            if (tlAtts.Count > 0)
                            {
                                var tlAtt = tlAtts.FirstOrDefault();

                                if (tlAtt != null)
                                {
                                    DateTimeA1 = (DateTimeA <= tlAtt.DateTimeB && tlAtt.DateTimeB <= DateTimeA1) ? tlAtt.DateTimeB : DateTimeA;
                                    DateTimeA = DateTimeA1;
                                }
                            }
                        }
                    }
                    else
                    {
                        //彈性分鐘數
                        if (rRote.ElasticityMin > 0)
                        {
                            //如果員工有請假，可能用請假開始時間為彈性上班開始時間
                            //請假時間跟刷卡時間先做比較
                            //所有時間放進一個時間陣列一起比較 最後再與表訂上班時間比較 不可比表訂上班時間之前
                            List<DateTime> lsDateTime = new List<DateTime>();

                            lsDateTime.Add(DateTimeA2);  //彈性時間

                            //刷卡時間
                            DateTime? DateTimeOnCardTime = null;
                            if (rsAttCard.Count > 0)
                            {
                                var rAttCard = rsAttCard.OrderBy(p => p.OnCardTime48).ToList().FirstOrDefault();

                                if (rAttCard != null)
                                {
                                    DateTimeOnCardTime = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                                    lsDateTime.Add(DateTimeOnCardTime.Value);
                                }
                            }

                            //請假時間
                            if (rsAbs.Count > 0)
                            {
                                var rAbs = rsAbs.OrderBy(p => p.DateTimeB).ToList().FirstOrDefault();

                                if (rAbs != null)
                                    lsDateTime.Add(rAbs.DateTimeB);
                            }

                            //判斷如果刷卡後時間超過彈性後時間則無彈性
                            bool GoIng = true;
                            if (bElasticity && DateTimeOnCardTime != null)
                                if (DateTimeA2 < DateTimeOnCardTime.Value)
                                    GoIng = false;

                            if (GoIng)
                            {
                                if (lsDateTime.Count > 0)
                                {
                                    DateTimeX = lsDateTime.Min();

                                    //判斷此時間是否有比表訂時間早，有的話就以表訂時間為準
                                    DateTimeA2 = DateTimeX < DateTimeA ? DateTimeA : DateTimeX;
                                }

                                //DateTimeA2 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA2) ? tlAttend[0].DateTimeB : DateTimeA;
                                DateTimeD = DateTimeD.AddMinutes((DateTimeA2 - DateTimeA).TotalMinutes);
                                DateTimeA = DateTimeA2;
                            }
                        }
                    }
                }

                DateTimeX = DateTimeA;

                TimeSpan ts;
                bool AttSW = false;
                for (int z = 0; z <= tlAttend.Count - 1; z++)
                {
                    var rAtt = tlAttend[z];

                    rAtt.DateTimeB = rAtt.DateTimeB >= DateTimeD ? DateTimeD : rAtt.DateTimeB;

                    if (DateTimeX < rAtt.DateTimeB)
                    {
                        ts = rAtt.DateTimeB - DateTimeX;
                        if (rAtt.Type != AttEndType.Abs)  //正常出勤，第一次進來一定算遲到
                        {
                            if (rAtt.Type == AttEndType.Res && !AttSW)
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到 
                            else if (rAtt.Type == AttEndType.Res)
                                rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);//早退
                            else
                            {
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到   
                                AttSW = true;
                            }
                        }   
                        else if (rAtt.Type == AttEndType.Abs)
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                    }
                    else if (rAtt.Type == AttEndType.Att)
                        AttSW = true;

                    DateTimeX = DateTimeX >= rAtt.DateTimeE ? DateTimeX : rAtt.DateTimeE;

                    //如果出勤資料的結束時間大於出勒應下班時間就直接結束
                    if (DateTimeD <= rAtt.DateTimeE || z == tlAttend.Count - 1)
                    {
                        //如果最後一次進來再比較一次算出早退分鐘數
                        if (DateTimeX < DateTimeD)
                        {
                            ts = DateTimeD - DateTimeX;
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);
                        }

                        break;
                    }
                }
            }

            return rAttEnd;
        }


        /// <summary>
        /// 判斷異常
        /// </summary>
        /// <param name="rsAttCard">出勤資料</param>
        /// <param name="rRote">班別資料</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="dDate">判斷日期</param>
        /// <param name="bElasticity">判斷如果刷卡後時間超過彈性後時間則無彈性 預設False</param>
        /// <returns>AttEndTable</returns>
        public AttEndTable AttEndByOneDay(List<AttCardTable> rsAttCard, RoteTable rRote, List<AbsTable> rsAbs, DateTime dDate ,bool bElasticity = false)
        {
            bool IsHoliDay = rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0;

            var rAttEnd = new AttEndTable();

            List<AttEndTempTable> rsAttEndTempTable = new List<AttEndTempTable>();

            //var rsAttCard = obVdb.AttCardDataDay;
            //var rRote = obVdb.RoteDataDay;
            //var rsAbs = obVdb.AbsDataDay;

            DateTime Date = dDate.Date;
            DateTime DateTimeA, DateTimeD;    //實際應出勤上下班日期時間
            DateTime DateTimeA1;   //加入可遲到分鐘數後
            DateTime DateTimeA2;   //加入彈性分鐘數後
            DateTime DateTimeX; //暫存

            DateTimeA = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));    //實際應出勤上班日期時間
            DateTimeD = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));   //實際應出勤下班日期時間

            DateTimeA1 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.LatesMin));    //先加入可遲到分鐘數
            DateTimeA2 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.ElasticityMin));   //再加入彈性分鐘數

            //忘刷次數小於等於1：比對請假資料
            //忘刷次數大於等於2：比對上下班時間
            //請假時間不正確再比對請假資料

            //計算忘刷次數
            rAttEnd.Card = rsAttCard.Where(p => p.OnLos).Count() + rsAttCard.Where(p => p.OffLos).Count();

            //Type = 1 = 出勤
            //Type = 2 = 休息
            //Type = 3 = 請假

            //計算提早來跟延後走的分鐘數
            rAttEnd.EarlyMin = 0;
            rAttEnd.DelayMin = 0;
            if (rsAttCard.Count == 1 && rRote != null && !IsHoliDay)
            {
                var rAttCard = rsAttCard[0];
                if (rAttCard.OnCardTime48.Trim().Length > 0 && rRote.OnTime.CompareTo(rAttCard.OnCardTime48) > 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48);

                    rAttEnd.EarlyMin = iRoteMin - iCardMin;
                }

                if (rAttCard.OffCardTime48.Trim().Length > 0 && rRote.OffTime.CompareTo(rAttCard.OffCardTime48) < 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48);

                    rAttEnd.DelayMin = iCardMin - iRoteMin;
                }
            }

            //出勤
            foreach (var rAttCard in rsAttCard)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                if (rAttCard.OffCardTime48.Length >0)
                rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48));
                rAttEndTemp.Type = AttEndType.Att;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            //休息
            foreach (var rRes in rRote.DayRes)
            {
                //一定要有在出勤時間裡才需要被加進來 可以放在外面 不要在這邊判斷
                if (rRote.OnTime.Trim().CompareTo(rRes.ResE) <= 0
                && rRote.OffTime.Trim().CompareTo(rRes.ResB) >= 0)
                {
                    var rAttEndTemp = new AttEndTempTable();
                    rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResB));
                    rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResE));
                    rAttEndTemp.Type = AttEndType.Res;
                    rsAttEndTempTable.Add(rAttEndTemp);
                }
            }

            //請假
            foreach (var rAbs in rsAbs)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = rAbs.DateTimeB;
                rAttEndTemp.DateTimeE = rAbs.DateTimeE;
                rAttEndTemp.Type = AttEndType.Abs;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            var tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();

            //如果沒有出勤也沒有請假資料就是曠職
            if (tlAttend.Where(p => p.Type == AttEndType.Att || p.Type == AttEndType.Abs).Count() == 0)
                rAttEnd.Abs = true;
            else
            {
                //第一筆如果不是出勤資料，則應該是上午請假
                //反之如下
                //取得實際出勤的上下班時間(應加入可遲到分鐘數及彈性分鐘數)目前僅可以選一種
                //if (tlAttend[0].Type == AttEndType.Att)
                {
                    //可遲到分鐘數
                    if (rRote.LatesMin > rRote.ElasticityMin)
                    {
                        if (rRote.LatesMin > 0)
                        {
                            var tlAtts = tlAttend.Where(p => p.Type == AttEndType.Att).ToList();

                            if (tlAtts.Count > 0)
                            {
                                var tlAtt = tlAtts.FirstOrDefault();

                                if (tlAtt != null)
                                {
                                    DateTimeA1 = (DateTimeA <= tlAtt.DateTimeB && tlAtt.DateTimeB <= DateTimeA1) ? tlAtt.DateTimeB : DateTimeA;
                                    DateTimeA = DateTimeA1;
                                }
                            }
                        }
                    }
                    else
                    {
                        //彈性分鐘數
                        if (rRote.ElasticityMin > 0)
                        {
                            //如果員工有請假，可能用請假開始時間為彈性上班開始時間
                            //請假時間跟刷卡時間先做比較
                            //所有時間放進一個時間陣列一起比較 最後再與表訂上班時間比較 不可比表訂上班時間之前
                            List<DateTime> lsDateTime = new List<DateTime>();

                            lsDateTime.Add(DateTimeA2);  //彈性時間

                            //刷卡時間
                            DateTime? DateTimeOnCardTime = null;
                            if (rsAttCard.Count > 0)
                            {
                                var rAttCard = rsAttCard.OrderBy(p => p.OnCardTime48).ToList().FirstOrDefault();

                                if (rAttCard != null)
                                {
                                    DateTimeOnCardTime = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                                    lsDateTime.Add(DateTimeOnCardTime.Value);
                                }
                            }

                            //請假時間
                            if (rsAbs.Count > 0)
                            {
                                var rAbs = rsAbs.OrderBy(p => p.DateTimeB).ToList().FirstOrDefault();

                                if (rAbs != null)
                                    lsDateTime.Add(rAbs.DateTimeB);
                            }

                            //判斷如果刷卡後時間超過彈性後時間則無彈性
                            bool GoIng = true;
                            if (bElasticity && DateTimeOnCardTime != null)
                                if (DateTimeA2 < DateTimeOnCardTime.Value)
                                    GoIng = false;

                            if (GoIng)
                            {
                                if (lsDateTime.Count > 0)
                                {
                                    DateTimeX = lsDateTime.Min();

                                    //判斷此時間是否有比表訂時間早，有的話就以表訂時間為準
                                    DateTimeA2 = DateTimeX < DateTimeA ? DateTimeA : DateTimeX;
                                }

                                //DateTimeA2 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA2) ? tlAttend[0].DateTimeB : DateTimeA;
                                DateTimeD = DateTimeD.AddMinutes((DateTimeA2 - DateTimeA).TotalMinutes);
                                DateTimeA = DateTimeA2;
                            }
                        }
                    }
                }

                DateTimeX = DateTimeA;

                TimeSpan ts;

                for (int z = 0; z <= tlAttend.Count - 1; z++)
                {
                    var rAtt = tlAttend[z];

                    rAtt.DateTimeB = rAtt.DateTimeB >= DateTimeD ? DateTimeD : rAtt.DateTimeB;

                    if (DateTimeX < rAtt.DateTimeB)
                    {
                        ts = rAtt.DateTimeB - DateTimeX;
                        if (rAtt.Type != AttEndType.Abs || z == 0)  //正常出勤，第一次進來一定算遲到
                            if (rAtt.Type == AttEndType.Res && z == 0)
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                            else if (rAtt.Type == AttEndType.Res)
                                rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                            else
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                        else if (rAtt.Type == AttEndType.Abs)
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                    }

                    DateTimeX = DateTimeX >= rAtt.DateTimeE ? DateTimeX : rAtt.DateTimeE;

                    //如果出勤資料的結束時間大於出勒應下班時間就直接結束
                    if (DateTimeD <= rAtt.DateTimeE || z == tlAttend.Count - 1)
                    {
                        //如果最後一次進來再比較一次算出早退分鐘數
                        if (DateTimeX < DateTimeD)
                        {
                            ts = DateTimeD - DateTimeX;
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);
                        }

                        break;
                    }
                }
            }

            return rAttEnd;
        }

        /// <summary>
        /// 判斷異常 益群
        /// </summary>
        /// <param name="rsAttCard">出勤資料</param>
        /// <param name="rRote">班別資料</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="dDate">判斷日期</param>
        /// <param name="bElasticity">判斷如果刷卡後時間超過彈性後時間則無彈性 預設False</param>
        /// <returns>AttEndTable</returns>
        public AttEndTable AttEndByOneDayByWenetgroup(List<AttCardTable> rsAttCard, RoteTable rRote, List<AbsTable> rsAbs, DateTime dDate, bool bElasticity = false)
        {
            bool IsHoliDay = rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0;

            var rAttEnd = new AttEndTable();

            List<AttEndTempTable> rsAttEndTempTable = new List<AttEndTempTable>();

            //var rsAttCard = obVdb.AttCardDataDay;
            //var rRote = obVdb.RoteDataDay;
            //var rsAbs = obVdb.AbsDataDay;

            DateTime Date = dDate.Date;
            DateTime DateTimeA, DateTimeD;    //實際應出勤上下班日期時間
            DateTime DateTimeA1;   //加入可遲到分鐘數後
            DateTime DateTimeA2;   //加入彈性分鐘數後
            DateTime DateTimeX; //暫存

            DateTimeA = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));    //實際應出勤上班日期時間
            DateTimeD = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));   //實際應出勤下班日期時間

            DateTimeA1 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.LatesMin));    //先加入可遲到分鐘數
            DateTimeA2 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.ElasticityMin));   //再加入彈性分鐘數
            //DateTimeA2 = DateTimeA;

            //if (rRote.ElasticityMin > 0)
            //    DateTimeA2 = DateTimeA.AddDays(1);

            //忘刷次數小於等於1：比對請假資料
            //忘刷次數大於等於2：比對上下班時間
            //請假時間不正確再比對請假資料

            //計算忘刷次數
            rAttEnd.Card = rsAttCard.Where(p => p.OnLos).Count() + rsAttCard.Where(p => p.OffLos).Count();

            //Type = 1 = 出勤
            //Type = 2 = 休息
            //Type = 3 = 請假

            //計算提早來跟延後走的分鐘數
            rAttEnd.EarlyMin = 0;
            rAttEnd.DelayMin = 0;
            if (rsAttCard.Count == 1 && rRote != null && !IsHoliDay)
            {
                var rAttCard = rsAttCard[0];
                if (rAttCard.OnCardTime48.Trim().Length > 0 && rRote.OnTime.CompareTo(rAttCard.OnCardTime48) > 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48);

                    rAttEnd.EarlyMin = iRoteMin - iCardMin;
                }

                if (rAttCard.OffCardTime48.Trim().Length > 0 && rRote.OffTime.CompareTo(rAttCard.OffCardTime48) < 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48);

                    rAttEnd.DelayMin = iCardMin - iRoteMin;
                }
            }

            //出勤
            foreach (var rAttCard in rsAttCard)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48));
                rAttEndTemp.Type = AttEndType.Att;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            //休息
            foreach (var rRes in rRote.DayRes)
            {
                //一定要有在出勤時間裡才需要被加進來 可以放在外面 不要在這邊判斷
                if (rRote.OnTime.Trim().CompareTo(rRes.ResE) <= 0
                && rRote.OffTime.Trim().CompareTo(rRes.ResB) >= 0)
                {
                    var rAttEndTemp = new AttEndTempTable();
                    rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResB));
                    rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResE));
                    rAttEndTemp.Type = AttEndType.Res;
                    rsAttEndTempTable.Add(rAttEndTemp);
                }
            }

            //請假
            foreach (var rAbs in rsAbs)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = rAbs.DateTimeB;
                rAttEndTemp.DateTimeE = rAbs.DateTimeE;
                rAttEndTemp.Type = AttEndType.Abs;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            var tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();

            //如果沒有出勤也沒有請假資料就是曠職
            if (tlAttend.Where(p => p.Type == AttEndType.Att || p.Type == AttEndType.Abs).Count() == 0)
                rAttEnd.Abs = true;
            else
            {
                //第一筆如果不是出勤資料，則應該是上午請假
                //反之如下
                //取得實際出勤的上下班時間(應加入可遲到分鐘數及彈性分鐘數)目前僅可以選一種
                //if (tlAttend[0].Type == AttEndType.Att)
                {
                    //可遲到分鐘數
                    if (rRote.LatesMin > rRote.ElasticityMin)
                    {
                        if (rRote.LatesMin > 0)
                        {
                            var tlAtts = tlAttend.Where(p => p.Type == AttEndType.Att).ToList();

                            if (tlAtts.Count > 0)
                            {
                                var tlAtt = tlAtts.FirstOrDefault();

                                if (tlAtt != null)
                                {
                                    DateTimeA1 = (DateTimeA <= tlAtt.DateTimeB && tlAtt.DateTimeB <= DateTimeA1) ? tlAtt.DateTimeB : DateTimeA;
                                    DateTimeA = DateTimeA1;
                                }
                            }
                        }
                    }
                    else
                    {
                        //彈性分鐘數
                        if (rRote.ElasticityMin > 0)
                        {
                            //如果員工有請假，可能用請假開始時間為彈性上班開始時間
                            //請假時間跟刷卡時間先做比較
                            //所有時間放進一個時間陣列一起比較 最後再與表訂上班時間比較 不可比表訂上班時間之前
                            List<DateTime> lsDateTime = new List<DateTime>();

                            lsDateTime.Add(DateTimeA2);  //彈性時間

                            //刷卡時間
                            DateTime? DateTimeOnCardTime = null;
                            if (rsAttCard.Count > 0)
                            {
                                var rAttCard = rsAttCard.OrderBy(p => p.OnCardTime48).ToList().FirstOrDefault();

                                if (rAttCard != null)
                                {
                                    DateTimeOnCardTime = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                                    lsDateTime.Add(DateTimeOnCardTime.Value);
                                }
                            }

                            //請假時間
                            if (rsAbs.Count > 0)
                            {
                                var rAbs = rsAbs.OrderBy(p => p.DateTimeB).ToList().FirstOrDefault();

                                if (rAbs != null)
                                    lsDateTime.Add(rAbs.DateTimeB);
                            }

                            //判斷如果刷卡後時間超過彈性後時間則無彈性
                            bool GoIng = true;
                            //if (bElasticity && DateTimeOnCardTime != null)
                            //    if (DateTimeA2 < DateTimeOnCardTime.Value)
                            //        GoIng = false;

                            if (GoIng)
                            {
                                if (lsDateTime.Count > 0)
                                {
                                    DateTimeX = lsDateTime.Min();

                                    //判斷此時間是否有比表訂時間早，有的話就以表訂時間為準
                                    DateTimeA2 = DateTimeX < DateTimeA ? DateTimeA : DateTimeX;
                                }

                                //DateTimeA2 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA2) ? tlAttend[0].DateTimeB : DateTimeA;
                                DateTimeD = DateTimeD.AddMinutes((DateTimeA2 - DateTimeA).TotalMinutes);
                                DateTimeA = DateTimeA2;
                            }
                        }
                    }
                }

                DateTimeX = DateTimeA;

                TimeSpan ts;

                for (int z = 0; z <= tlAttend.Count - 1; z++)
                {
                    var rAtt = tlAttend[z];

                    rAtt.DateTimeB = rAtt.DateTimeB >= DateTimeD ? DateTimeD : rAtt.DateTimeB;

                    if (DateTimeX < rAtt.DateTimeB)
                    {
                        ts = rAtt.DateTimeB - DateTimeX;
                        if (rAtt.Type != AttEndType.Abs || z == 0)  //正常出勤，第一次進來一定算遲到
                            if (rAtt.Type == AttEndType.Res && z == 0)
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                            else if (rAtt.Type == AttEndType.Res)
                                rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                            else
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                        else if (rAtt.Type == AttEndType.Abs)
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                    }

                    DateTimeX = DateTimeX >= rAtt.DateTimeE ? DateTimeX : rAtt.DateTimeE;

                    //如果出勤資料的結束時間大於出勒應下班時間就直接結束
                    if (DateTimeD <= rAtt.DateTimeE || z == tlAttend.Count - 1)
                    {
                        //如果最後一次進來再比較一次算出早退分鐘數
                        if (DateTimeX < DateTimeD)
                        {
                            ts = DateTimeD - DateTimeX;
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);
                        }

                        break;
                    }
                }
            }

            return rAttEnd;
        }

        /// <summary>
        /// 判斷異常 頻光
        /// </summary>
        /// <param name="rsAttCard">出勤資料</param>
        /// <param name="rRote">班別資料</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="dDate">判斷日期</param>
        /// <param name="bElasticity">判斷如果刷卡後時間超過彈性後時間則無彈性 預設False</param>
        /// <returns>AttEndTable</returns>
        public AttEndTable AttEndByOneDayByMost(List<AttCardTable> rsAttCard, RoteTable rRote, List<AbsTable> rsAbs, DateTime dDate, bool bElasticity = false)
        {
            bool IsHoliDay = rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0;

            var rAttEnd = new AttEndTable();

            List<AttEndTempTable> rsAttEndTempTable = new List<AttEndTempTable>();

            //var rsAttCard = obVdb.AttCardDataDay;
            //var rRote = obVdb.RoteDataDay;
            //var rsAbs = obVdb.AbsDataDay;

            DateTime Date = dDate.Date;
            DateTime DateTimeA, DateTimeD;    //實際應出勤上下班日期時間
            DateTime DateTimeA1;   //加入可遲到分鐘數後
            DateTime DateTimeA2;   //加入彈性分鐘數後
            DateTime DateTimeX; //暫存
            TimeSpan ts;

            DateTimeA = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));    //實際應出勤上班日期時間
            DateTimeD = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));   //實際應出勤下班日期時間

            DateTimeA1 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.LatesMin));    //先加入可遲到分鐘數
            DateTimeA2 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.ElasticityMin));   //再加入彈性分鐘數

            //忘刷次數小於等於1：比對請假資料
            //忘刷次數大於等於2：比對上下班時間
            //請假時間不正確再比對請假資料

            //計算忘刷次數
            rAttEnd.Card = rsAttCard.Where(p => p.OnLos).Count() + rsAttCard.Where(p => p.OffLos).Count();

            //Type = 1 = 出勤
            //Type = 2 = 休息
            //Type = 3 = 請假

            //計算提早來跟延後走的分鐘數
            rAttEnd.EarlyMin = 0;
            rAttEnd.DelayMin = 0;
            if (rsAttCard.Count == 1 && rRote != null && !IsHoliDay)
            {
                var rAttCard = rsAttCard[0];
                if (rAttCard.OnCardTime48.Trim().Length > 0 && rRote.OnTime.CompareTo(rAttCard.OnCardTime48) > 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48);

                    rAttEnd.EarlyMin = iRoteMin - iCardMin;
                }

                if (rAttCard.OffCardTime48.Trim().Length > 0 && rRote.OffTime.CompareTo(rAttCard.OffCardTime48) < 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48);

                    rAttEnd.DelayMin = iCardMin - iRoteMin;
                }
            }

            //出勤
            foreach (var rAttCard in rsAttCard)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48));
                rAttEndTemp.Type = AttEndType.Att;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            //休息
            foreach (var rRes in rRote.DayRes)
            {
                //一定要有在出勤時間裡才需要被加進來 可以放在外面 不要在這邊判斷
                if (rRote.OnTime.Trim().CompareTo(rRes.ResE) <= 0
                && rRote.OffTime.Trim().CompareTo(rRes.ResB) >= 0)
                {
                    var rAttEndTemp = new AttEndTempTable();
                    rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResB));
                    rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResE));
                    rAttEndTemp.Type = AttEndType.Res;
                    rsAttEndTempTable.Add(rAttEndTemp);
                }
            }

            //請假
            foreach (var rAbs in rsAbs)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = rAbs.DateTimeB;
                rAttEndTemp.DateTimeE = rAbs.DateTimeE;
                rAttEndTemp.Type = AttEndType.Abs;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            var tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();

            //如果沒有出勤也沒有請假資料就是曠職
            if (tlAttend.Where(p => p.Type == AttEndType.Att || p.Type == AttEndType.Abs).Count() == 0)
                rAttEnd.Abs = true;
            else
            {
                //第一筆如果不是出勤資料，則應該是上午請假
                //反之如下
                //取得實際出勤的上下班時間(應加入可遲到分鐘數及彈性分鐘數)目前僅可以選一種
                //if (tlAttend[0].Type == AttEndType.Att)
                {
                    //可遲到分鐘數
                    if (rRote.LatesMin > rRote.ElasticityMin)
                    {
                        if (rRote.LatesMin > 0)
                        {
                            var tlAtts = tlAttend.Where(p => p.Type == AttEndType.Att).ToList();

                            if (tlAtts.Count > 0)
                            {
                                var tlAtt = tlAtts.FirstOrDefault();

                                if (tlAtt != null)
                                {
                                    DateTimeA1 = (DateTimeA <= tlAtt.DateTimeB && tlAtt.DateTimeB <= DateTimeA1) ? tlAtt.DateTimeB : DateTimeA;
                                    DateTimeA = DateTimeA1;
                                }
                            }
                        }
                    }
                    else
                    {
                        //彈性分鐘數
                        if (rRote.ElasticityMin > 0)
                        {
                            //如果員工有請假，可能用請假開始時間為彈性上班開始時間
                            //請假時間跟刷卡時間先做比較
                            //所有時間放進一個時間陣列一起比較 最後再與表訂上班時間比較 不可比表訂上班時間之前
                            List<DateTime> lsDateTime = new List<DateTime>();

                            lsDateTime.Add(DateTimeA2);  //彈性時間

                            //刷卡時間
                            DateTime? DateTimeOnCardTime = null;
                            if (rsAttCard.Count > 0)
                            {
                                var rAttCard = rsAttCard.OrderBy(p => p.OnCardTime48).ToList().FirstOrDefault();

                                if (rAttCard != null)
                                {
                                    DateTimeOnCardTime = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));

                                    ts = DateTimeOnCardTime.Value - DateTimeOnCardTime.Value.Date;
                                    int iMinute = Convert.ToInt32(ts.TotalMinutes);
                                    int iModMinute = iMinute % rRote.ElasticityMinInterval;
                                    if (iModMinute > 0)
                                        iModMinute = rRote.ElasticityMinInterval - iModMinute;
                                    iMinute += iModMinute;

                                    DateTimeOnCardTime = DateTimeOnCardTime.Value.Date.AddMinutes(iMinute);

                                    lsDateTime.Add(DateTimeOnCardTime.Value);
                                }
                            }

                            //請假時間
                            if (rsAbs.Count > 0)
                            {
                                var rAbs = rsAbs.OrderBy(p => p.DateTimeB).ToList().FirstOrDefault();

                                if (rAbs != null)
                                    lsDateTime.Add(rAbs.DateTimeB);
                            }

                            //判斷如果刷卡後時間超過彈性後時間則無彈性
                            bool GoIng = true;
                            if (bElasticity && DateTimeOnCardTime != null)
                                if (DateTimeA2 < DateTimeOnCardTime.Value)
                                    GoIng = false;

                            if (GoIng)
                            {
                                if (lsDateTime.Count > 0)
                                {
                                    DateTimeX = lsDateTime.Min();

                                    //判斷此時間是否有比表訂時間早，有的話就以表訂時間為準
                                    DateTimeA2 = DateTimeX < DateTimeA ? DateTimeA : DateTimeX;
                                }

                                //DateTimeA2 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA2) ? tlAttend[0].DateTimeB : DateTimeA;
                                DateTimeD = DateTimeD.AddMinutes((DateTimeA2 - DateTimeA).TotalMinutes);
                                DateTimeA = DateTimeA2;
                            }
                        }
                    }
                }

                DateTimeX = DateTimeA;

                for (int z = 0; z <= tlAttend.Count - 1; z++)
                {
                    var rAtt = tlAttend[z];

                    rAtt.DateTimeB = rAtt.DateTimeB >= DateTimeD ? DateTimeD : rAtt.DateTimeB;

                    if (DateTimeX < rAtt.DateTimeB)
                    {
                        ts = rAtt.DateTimeB - DateTimeX;
                        if (rAtt.Type != AttEndType.Abs || z == 0)  //正常出勤，第一次進來一定算遲到
                            if (rAtt.Type == AttEndType.Res && z == 0)
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                            else if (rAtt.Type == AttEndType.Res)
                                rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                            else
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                        else if (rAtt.Type == AttEndType.Abs)
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                    }

                    DateTimeX = DateTimeX >= rAtt.DateTimeE ? DateTimeX : rAtt.DateTimeE;

                    //如果出勤資料的結束時間大於出勒應下班時間就直接結束
                    if (DateTimeD <= rAtt.DateTimeE || z == tlAttend.Count - 1)
                    {
                        //如果最後一次進來再比較一次算出早退分鐘數
                        if (DateTimeX < DateTimeD)
                        {
                            ts = DateTimeD - DateTimeX;
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);
                        }

                        break;
                    }
                }
            }

            return rAttEnd;
        }

        /// <summary>
        /// 判斷異常 九豪
        /// </summary>
        /// <param name="rsAttCard">出勤資料</param>
        /// <param name="rRote">班別資料</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="dDate">判斷日期</param>
        /// <param name="bElasticity">判斷如果刷卡後時間超過彈性後時間則無彈性 預設False</param>
        /// <returns>AttEndTable</returns>
        public AttEndTable AttEndByOneDayByAbs(List<AttCardTable> rsAttCard, RoteTable rRote, List<AbsTable> rsAbs, DateTime dDate, bool bElasticity = false)
        {
            bool IsHoliDay = rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0;

            var rAttEnd = new AttEndTable();

            List<AttEndTempTable> rsAttEndTempTable = new List<AttEndTempTable>();

            //var rsAttCard = obVdb.AttCardDataDay;
            //var rRote = obVdb.RoteDataDay;
            //var rsAbs = obVdb.AbsDataDay;

            DateTime Date = dDate.Date;
            DateTime DateTimeA, DateTimeD;    //實際應出勤上下班日期時間
            DateTime DateTimeA1;   //加入可遲到分鐘數後
            DateTime DateTimeA2;   //加入彈性分鐘數後
            DateTime DateTimeX; //暫存
            TimeSpan ts;    //時間計算

            DateTimeA = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));    //實際應出勤上班日期時間
            DateTimeD = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));   //實際應出勤下班日期時間

            DateTimeA1 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.LatesMin));    //先加入可遲到分鐘數
            DateTimeA2 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.ElasticityMin));   //再加入彈性分鐘數

            //忘刷次數小於等於1：比對請假資料
            //忘刷次數大於等於2：比對上下班時間
            //請假時間不正確再比對請假資料

            //計算忘刷次數
            rAttEnd.Card = rsAttCard.Where(p => p.OnLos).Count() + rsAttCard.Where(p => p.OffLos).Count();

            //Type = 1 = 出勤
            //Type = 2 = 休息
            //Type = 3 = 請假

            //計算提早來跟延後走的分鐘數
            rAttEnd.EarlyMin = 0;
            rAttEnd.DelayMin = 0;
            rAttEnd.ElasticityMin = 0;  //使用彈性分鐘數
            if (rsAttCard.Count == 1 && rRote != null && !IsHoliDay)
            {
                var rAttCard = rsAttCard[0];
                if (rAttCard.OnCardTime48.Trim().Length > 0 && rRote.OnTime.CompareTo(rAttCard.OnCardTime48) > 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48);

                    rAttEnd.EarlyMin = iRoteMin - iCardMin;
                }

                if (rAttCard.OffCardTime48.Trim().Length > 0 && rRote.OffTime.CompareTo(rAttCard.OffCardTime48) < 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48);

                    rAttEnd.DelayMin = iCardMin - iRoteMin;
                }
            }

            //出勤
            foreach (var rAttCard in rsAttCard)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48));
                rAttEndTemp.Type = AttEndType.Att;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            //休息
            foreach (var rRes in rRote.DayRes)
            {
                //一定要有在出勤時間裡才需要被加進來 可以放在外面 不要在這邊判斷
                if (rRote.OnTime.Trim().CompareTo(rRes.ResE) <= 0
                && rRote.OffTime.Trim().CompareTo(rRes.ResB) >= 0)
                {
                    var rAttEndTemp = new AttEndTempTable();
                    rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResB));
                    rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResE));
                    rAttEndTemp.Type = AttEndType.Res;
                    rsAttEndTempTable.Add(rAttEndTemp);
                }
            }

            //請假
            foreach (var rAbs in rsAbs)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = rAbs.DateTimeB;
                rAttEndTemp.DateTimeE = rAbs.DateTimeE;
                rAttEndTemp.Type = AttEndType.Abs;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            //組合請假
            var rsAbsTemp = rsAttEndTempTable.Where(p => p.Type == AttEndType.Abs ).ToList().OrderBy(p => p.DateTimeB).ToList();
            var rAbsTemp = rsAbsTemp.FirstOrDefault();
            DateTime? DateAbs = null;
            foreach (var rAbsTemp1 in rsAbsTemp)
            {
                if (DateAbs != null )
                {
                    //有組合到
                    if (DateAbs == rAbsTemp1.DateTimeB)
                    {
                        var rAttEndTempTable = rsAttEndTempTable.Where(p => p.DateTimeB == rAbsTemp.DateTimeB && p.Type == AttEndType.Abs).FirstOrDefault();
                        if (rAttEndTempTable != null)
                            rAttEndTempTable.DateTimeE = rAbsTemp1.DateTimeE;

                        rsAttEndTempTable.Remove(rAbsTemp1);
                    }
                    else
                        rAbsTemp = rAbsTemp1;
                }

                 DateAbs = rAbsTemp1.DateTimeE;
            }

            var tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();

            //如果沒有出勤也沒有請假資料就是曠職
            if (tlAttend.Where(p => p.Type == AttEndType.Att || p.Type == AttEndType.Abs).Count() == 0)
                rAttEnd.Abs = true;
            else
            {
                //第一筆如果不是出勤資料，則應該是上午請假
                //反之如下
                //取得實際出勤的上下班時間(應加入可遲到分鐘數及彈性分鐘數)目前僅可以選一種
                //if (tlAttend[0].Type == AttEndType.Att)
                {
                    //可遲到分鐘數
                    if (rRote.LatesMin > rRote.ElasticityMin)
                    {
                        if (rRote.LatesMin > 0)
                        {
                            DateTimeA1 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA1) ? tlAttend[0].DateTimeB : DateTimeA;
                            DateTimeA = DateTimeA1;
                        }
                    }
                    else
                    {
                        //彈性分鐘數
                        if (rRote.ElasticityMin > 0)
                        {
                            //所有時間放進一個時間陣列一起比較 最後再與表訂上班時間比較 不可比表訂上班時間之前
                            List<DateTime> lsDateTime = new List<DateTime>();

                            lsDateTime.Add(DateTimeA2);  //彈性時間

                            //刷卡時間
                            DateTime? DateTimeOnCardTime = null;
                            if (rsAttCard.Count > 0)
                            {
                                var rAttCard = rsAttCard.OrderBy(p => p.OnCardTime48).ToList().FirstOrDefault();

                                if (rAttCard != null)
                                {
                                    DateTimeOnCardTime = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                                    lsDateTime.Add(DateTimeOnCardTime.Value);
                                }
                            }

                            //請假時間
                            if (rsAbs.Count > 0)
                            {
                                var rAbs = rsAbs.OrderBy(p => p.DateTimeB).ToList().FirstOrDefault();

                                if (rAbs != null)
                                    lsDateTime.Add(rAbs.DateTimeB);
                            }

                            //判斷如果刷卡後時間超過彈性後時間則無彈性
                            bool GoIng = true;
                            if (bElasticity && DateTimeOnCardTime != null)
                                if (DateTimeA2 < DateTimeOnCardTime.Value)
                                    GoIng = false;

                            //如果有彈性...
                            if (GoIng)
                            {
                                if (lsDateTime.Count > 0)
                                {
                                    DateTimeX = lsDateTime.Min();

                                    //判斷此時間是否有比表訂時間早，有的話就以表訂時間為準
                                    DateTimeA2 = DateTimeX < DateTimeA ? DateTimeA : DateTimeX;
                                }

                                //如果有請假並非全天 且 請假結束時間等於應出勤結束時間 則 應採用此筆請假開始時間 為彈性延後結束時間
                                var rsAbsAndRes = tlAttend.Where(p => p.Type == AttEndType.Abs || p.Type == AttEndType.Res).ToList();

                                //反向排序結束時間
                                rsAbsAndRes = rsAbsAndRes.OrderByDescending(p => p.DateTimeE).ToList();

                                //利用反向排序來找出真正的下班時間
                                for (int z = 0; z <= rsAbsAndRes.Count - 1; z++)
                                {
                                    var rAtt = rsAbsAndRes[z];

                                    //如果請假或休息時間 等於應出勤結束時間
                                    if (rAtt.DateTimeE == DateTimeD)
                                    {
                                        //將應出勤結束時間變成開始時間
                                        DateTimeD = DateTimeD < rAtt.DateTimeB ? DateTimeD : rAtt.DateTimeB;

                                        //並於tlAttend移除該筆資料
                                        tlAttend.Remove(rAtt);
                                    }
                                }

                                ts = DateTimeA2 - DateTimeA;
                                rAttEnd.ElasticityMin = Convert.ToInt32(ts.TotalMinutes);

                                DateTimeD = DateTimeD.AddMinutes(rAttEnd.ElasticityMin);                                
                                DateTimeA = DateTimeA2;
                            }
                        }
                    }
                }

                DateTimeX = DateTimeA;

                for (int z = 0; z <= tlAttend.Count - 1; z++)
                {
                    var rAtt = tlAttend[z];

                    rAtt.DateTimeB = rAtt.DateTimeB >= DateTimeD ? DateTimeD : rAtt.DateTimeB;

                    //開始或上班時間 小於 出勤或請假時間或休息時間
                    if (DateTimeX < rAtt.DateTimeB)
                    {
                        ts = rAtt.DateTimeB - DateTimeX;
                        if (rAtt.Type != AttEndType.Abs || z == 0)  //正常出勤，第一次進來一定算遲到
                            if (rAtt.Type == AttEndType.Res && z == 0)
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                            else if (rAtt.Type == AttEndType.Res)
                                rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                            else
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                        else if (rAtt.Type == AttEndType.Abs)
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                    }

                    DateTimeX = DateTimeX >= rAtt.DateTimeE ? DateTimeX : rAtt.DateTimeE;

                    //如果出勤資料的結束時間大於出勤應下班時間就直接結束
                    if (DateTimeD <= rAtt.DateTimeE || z == tlAttend.Count - 1)
                    {
                        //如果最後一次進來再比較一次算出早退分鐘數
                        if (DateTimeX < DateTimeD)
                        {
                            ts = DateTimeD - DateTimeX;
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);
                        }

                        break;
                    }
                }
            }

            return rAttEnd;
        }

        /// <summary>
        /// 判斷異常 九豪
        /// </summary>
        /// <param name="rsAttCard">出勤資料</param>
        /// <param name="rRote">班別資料</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="dDate">判斷日期</param>
        /// <param name="bElasticity">判斷如果刷卡後時間超過彈性後時間則無彈性 預設False</param>
        /// <returns>AttEndTable</returns>
        public AttEndTable AttEndByOneDayByLigitek(List<AttCardTable> rsAttCard, RoteTable rRote, List<AbsTable> rsAbs, DateTime dDate, bool bElasticity = false)
        {
            bool IsHoliDay = rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0;

            var rAttEnd = new AttEndTable();

            List<AttEndTempTable> rsAttEndTempTable = new List<AttEndTempTable>();

            //var rsAttCard = obVdb.AttCardDataDay;
            //var rRote = obVdb.RoteDataDay;
            //var rsAbs = obVdb.AbsDataDay;

            DateTime Date = dDate.Date;
            DateTime DateTimeA, DateTimeD;    //實際應出勤上下班日期時間
            DateTime DateTimeA1;   //加入可遲到分鐘數後
            DateTime DateTimeA2;   //加入彈性分鐘數後
            DateTime DateTimeX; //暫存
            TimeSpan ts;    //時間計算

            DateTimeA = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));    //實際應出勤上班日期時間
            DateTimeD = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));   //實際應出勤下班日期時間

            DateTimeA1 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.LatesMin));    //先加入可遲到分鐘數
            DateTimeA2 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.ElasticityMin));   //再加入彈性分鐘數

            //忘刷次數小於等於1：比對請假資料
            //忘刷次數大於等於2：比對上下班時間
            //請假時間不正確再比對請假資料

            //計算忘刷次數
            rAttEnd.Card = rsAttCard.Where(p => p.OnLos).Count() + rsAttCard.Where(p => p.OffLos).Count();

            //Type = 1 = 出勤
            //Type = 2 = 休息
            //Type = 3 = 請假

            //計算提早來跟延後走的分鐘數
            rAttEnd.EarlyMin = 0;
            rAttEnd.DelayMin = 0;
            rAttEnd.ElasticityMin = 0;  //使用彈性分鐘數
            if (rsAttCard.Count == 1 && rRote != null && !IsHoliDay)
            {
                var rAttCard = rsAttCard[0];
                if (rAttCard.OnCardTime48.Trim().Length > 0 && rRote.OnTime.CompareTo(rAttCard.OnCardTime48) > 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48);

                    rAttEnd.EarlyMin = iRoteMin - iCardMin;
                }

                if (rAttCard.OffCardTime48.Trim().Length > 0 && rRote.OffTime.CompareTo(rAttCard.OffCardTime48) < 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48);

                    rAttEnd.DelayMin = iCardMin - iRoteMin;
                }
            }

            //出勤
            foreach (var rAttCard in rsAttCard)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48));
                rAttEndTemp.Type = AttEndType.Att;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            //休息
            foreach (var rRes in rRote.DayRes)
            {
                //一定要有在出勤時間裡才需要被加進來 可以放在外面 不要在這邊判斷
                if (rRote.OnTime.Trim().CompareTo(rRes.ResE) <= 0
                && rRote.OffTime.Trim().CompareTo(rRes.ResB) >= 0)
                {
                    //如果請假時間 包括休息時間 則 休息時間不要丟進來
                    if (!rsAbs.Any(p => p.TimeB.CompareTo(rRes.ResB) <= 0 && p.TimeE.CompareTo(rRes.ResE) >= 0))
                    {
                        var rAttEndTemp = new AttEndTempTable();
                        rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResB));
                        rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResE));
                        rAttEndTemp.Type = AttEndType.Res;
                        rsAttEndTempTable.Add(rAttEndTemp);
                    }
                }
            }

            //請假
            foreach (var rAbs in rsAbs)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = rAbs.DateTimeB;
                rAttEndTemp.DateTimeE = rAbs.DateTimeE;
                rAttEndTemp.Type = AttEndType.Abs;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            //組合請假
            var rsAbsTemp = rsAttEndTempTable.Where(p => p.Type == AttEndType.Abs).ToList().OrderBy(p => p.DateTimeB).ToList();
            var rAbsTemp = rsAbsTemp.FirstOrDefault();
            DateTime? DateAbs = null;
            foreach (var rAbsTemp1 in rsAbsTemp)
            {
                if (DateAbs != null)
                {
                    //有組合到
                    if (DateAbs == rAbsTemp1.DateTimeB)
                    {
                        var rAttEndTempTable = rsAttEndTempTable.Where(p => p.DateTimeB == rAbsTemp.DateTimeB && p.Type == AttEndType.Abs).FirstOrDefault();
                        if (rAttEndTempTable != null)
                            rAttEndTempTable.DateTimeE = rAbsTemp1.DateTimeE;

                        rsAttEndTempTable.Remove(rAbsTemp1);
                    }
                    else
                        rAbsTemp = rAbsTemp1;
                }

                DateAbs = rAbsTemp1.DateTimeE;
            }

            var tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();

            //如果沒有出勤也沒有請假資料就是曠職
            if (tlAttend.Where(p => p.Type == AttEndType.Att || p.Type == AttEndType.Abs).Count() == 0)
                rAttEnd.Abs = true;
            else
            {
                //第一筆如果不是出勤資料，則應該是上午請假
                //反之如下
                //取得實際出勤的上下班時間(應加入可遲到分鐘數及彈性分鐘數)目前僅可以選一種
                //if (tlAttend[0].Type == AttEndType.Att)
                {
                    //可遲到分鐘數
                    if (rRote.LatesMin > rRote.ElasticityMin)
                    {
                        if (rRote.LatesMin > 0)
                        {
                            DateTimeA1 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA1) ? tlAttend[0].DateTimeB : DateTimeA;
                            DateTimeA = DateTimeA1;
                        }
                    }
                    else
                    {
                        //彈性分鐘數
                        if (rRote.ElasticityMin > 0)
                        {
                            //所有時間放進一個時間陣列一起比較 最後再與表訂上班時間比較 不可比表訂上班時間之前
                            List<DateTime> lsDateTime = new List<DateTime>();

                            lsDateTime.Add(DateTimeA2);  //彈性時間

                            //刷卡時間
                            DateTime? DateTimeOnCardTime = null;
                            if (rsAttCard.Count > 0)
                            {
                                var rAttCard = rsAttCard.OrderBy(p => p.OnCardTime48).ToList().FirstOrDefault();

                                if (rAttCard != null)
                                {
                                    DateTimeOnCardTime = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                                    lsDateTime.Add(DateTimeOnCardTime.Value);
                                }
                            }

                            //請假時間
                            if (rsAbs.Count > 0)
                            {
                                var rAbs = rsAbs.OrderBy(p => p.DateTimeB).ToList().FirstOrDefault();

                                if (rAbs != null)
                                    lsDateTime.Add(rAbs.DateTimeB);
                            }

                            //判斷如果刷卡後時間超過彈性後時間則無彈性
                            bool GoIng = true;
                            if (bElasticity && DateTimeOnCardTime != null)
                                if (DateTimeA2 < DateTimeOnCardTime.Value)
                                    GoIng = false;

                            //如果有彈性...
                            if (GoIng)
                            {
                                if (lsDateTime.Count > 0)
                                {
                                    DateTimeX = lsDateTime.Min();

                                    //判斷此時間是否有比表訂時間早，有的話就以表訂時間為準
                                    DateTimeA2 = DateTimeX < DateTimeA ? DateTimeA : DateTimeX;
                                }

                                //如果有請假並非全天 且 請假結束時間等於應出勤結束時間 則 應採用此筆請假開始時間 為彈性延後結束時間
                                var rsAbsAndRes = tlAttend.Where(p => p.Type == AttEndType.Abs || p.Type == AttEndType.Res).ToList();

                                //反向排序結束時間
                                rsAbsAndRes = rsAbsAndRes.OrderByDescending(p => p.DateTimeE).ToList();

                                //利用反向排序來找出真正的下班時間
                                for (int z = 0; z <= rsAbsAndRes.Count - 1; z++)
                                {
                                    var rAtt = rsAbsAndRes[z];

                                    //如果請假或休息時間 等於應出勤結束時間
                                    if (rAtt.DateTimeE == DateTimeD)
                                    {
                                        //將應出勤結束時間變成開始時間
                                        DateTimeD = DateTimeD < rAtt.DateTimeB ? DateTimeD : rAtt.DateTimeB;

                                        //並於tlAttend移除該筆資料
                                        tlAttend.Remove(rAtt);
                                    }
                                }

                                ts = DateTimeA2 - DateTimeA;
                                rAttEnd.ElasticityMin = Convert.ToInt32(ts.TotalMinutes);

                                DateTimeD = DateTimeD.AddMinutes(rAttEnd.ElasticityMin);
                                DateTimeA = DateTimeA2;
                            }
                        }
                    }
                }

                DateTimeX = DateTimeA;

                for (int z = 0; z <= tlAttend.Count - 1; z++)
                {
                    var rAtt = tlAttend[z];

                    rAtt.DateTimeB = rAtt.DateTimeB >= DateTimeD ? DateTimeD : rAtt.DateTimeB;

                    //開始或上班時間 小於 出勤或請假時間或休息時間
                    if (DateTimeX < rAtt.DateTimeB)
                    {
                        ts = rAtt.DateTimeB - DateTimeX;
                        if (rAtt.Type != AttEndType.Abs || z == 0)  //正常出勤，第一次進來一定算遲到
                            if (rAtt.Type == AttEndType.Res && z == 0)
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                            else if (rAtt.Type == AttEndType.Res)
                                rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                            else
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                        else if (rAtt.Type == AttEndType.Abs)
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                    }

                    DateTimeX = DateTimeX >= rAtt.DateTimeE ? DateTimeX : rAtt.DateTimeE;

                    //如果出勤資料的結束時間大於出勤應下班時間就直接結束
                    if (DateTimeD <= rAtt.DateTimeE || z == tlAttend.Count - 1)
                    {
                        //如果最後一次進來再比較一次算出早退分鐘數
                        if (DateTimeX < DateTimeD)
                        {
                            ts = DateTimeD - DateTimeX;
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);
                        }

                        break;
                    }
                }
            }

            return rAttEnd;
        }

        /// <summary>
        /// 判斷異常
        /// </summary>
        /// <param name="rsAttCard">出勤資料</param>
        /// <param name="rRote">班別資料</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="dDate">判斷日期</param>
        /// <returns>AttEndTable</returns>
        public AttEndTable AttEndByOneDayNew(List<AttCardTable> rsAttCard, RoteTable rRote, List<AbsTable> rsAbs, DateTime dDate)
        {
            bool IsHoliDay = rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0;

            var rAttEnd = new AttEndTable();

            List<AttEndTempTable> rsAttEndTempTable = new List<AttEndTempTable>();

            //var rsAttCard = obVdb.AttCardDataDay;
            //var rRote = obVdb.RoteDataDay;
            //var rsAbs = obVdb.AbsDataDay;

            DateTime Date = dDate.Date;
            DateTime DateTimeA, DateTimeD;    //實際應出勤上下班日期時間
            DateTime DateTimeA1;   //加入可遲到分鐘數後
            DateTime DateTimeA2;   //加入彈性分鐘數後
            DateTime DateTimeX; //暫存

            DateTimeA = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));    //實際應出勤上班日期時間
            DateTimeD = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));   //實際應出勤下班日期時間

            DateTimeA1 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.LatesMin));    //先加入可遲到分鐘數
            DateTimeA2 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.ElasticityMin));   //再加入彈性分鐘數

            //忘刷次數小於等於1：比對請假資料
            //忘刷次數大於等於2：比對上下班時間
            //請假時間不正確再比對請假資料

            //計算忘刷次數
            rAttEnd.Card = rsAttCard.Where(p => p.OnLos).Count() + rsAttCard.Where(p => p.OffLos).Count();

            //Type = 1 = 出勤
            //Type = 2 = 休息
            //Type = 3 = 請假

            //計算提早來跟延後走的分鐘數
            rAttEnd.EarlyMin = 0;
            rAttEnd.DelayMin = 0;
            if (rsAttCard.Count == 1 && rRote != null && !IsHoliDay)
            {
                var rAttCard = rsAttCard[0];
                if (rAttCard.DT1 != null && rAttCard.OnCardTime48.Trim().Length > 0 && DateTimeA.CompareTo(rAttCard.DT1) > 0)
                {
                    TimeSpan ts = DateTimeA - rAttCard.DT1.Value;
                    rAttEnd.EarlyMin = Convert.ToInt32(ts.TotalMinutes);
                }

                if (rAttCard.DT2 != null && rAttCard.OffCardTime48.Trim().Length > 0 && DateTimeD.CompareTo(rAttCard.DT2) < 0)
                {
                    TimeSpan ts = rAttCard.DT2.Value - DateTimeD;
                    rAttEnd.DelayMin = Convert.ToInt32(ts.TotalMinutes);
                }
            }

            //出勤
            foreach (var rAttCard in rsAttCard)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48));
                //rAttEndTemp.DateTimeB = rAttCard.DT1.GetValueOrDefault(dDate);
                //rAttEndTemp.DateTimeE = rAttCard.DT2.GetValueOrDefault(dDate);
                rAttEndTemp.Type = AttEndType.Att;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            //休息
            foreach (var rRes in rRote.DayRes)
            {
                //一定要有在出勤時間裡才需要被加進來 可以放在外面 不要在這邊判斷
                if (rRote.OnTime.Trim().CompareTo(rRes.ResE) <= 0
                && rRote.OffTime.Trim().CompareTo(rRes.ResB) >= 0)
                {
                    var rAttEndTemp = new AttEndTempTable();
                    rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResB));
                    rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResE));
                    rAttEndTemp.Type = AttEndType.Res;
                    rsAttEndTempTable.Add(rAttEndTemp);
                }
            }

            //請假
            foreach (var rAbs in rsAbs)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = rAbs.DateTimeB;
                rAttEndTemp.DateTimeE = rAbs.DateTimeE;
                rAttEndTemp.Type = AttEndType.Abs;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            var tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();

            //如果沒有出勤也沒有請假資料就是曠職
            if (tlAttend.Where(p => p.Type == AttEndType.Att || p.Type == AttEndType.Abs).Count() == 0)
                rAttEnd.Abs = true;
            else
            {
                //第一筆如果不是出勤資料，則應該是上午請假
                //反之如下
                //取得實際出勤的上下班時間(應加入可遲到分鐘數及彈性分鐘數)目前僅可以選一種
                //if (tlAttend[0].Type == AttEndType.Att)
                {
                    //可遲到分鐘數
                    if (rRote.LatesMin > rRote.ElasticityMin)
                    {
                        if (rRote.LatesMin > 0)
                        {
                            DateTimeA1 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA1) ? tlAttend[0].DateTimeB : DateTimeA;
                            DateTimeA = DateTimeA1;
                        }
                    }
                    else
                    {
                        //彈性分鐘數
                        if (rRote.ElasticityMin > 0)
                        {
                            //如果員工有請假，可能用請假開始時間為彈性上班開始時間
                            //請假時間跟刷卡時間先做比較
                            //所有時間放進一個時間陣列一起比較 最後再與表訂上班時間比較 不可比表訂上班時間之前
                            List<DateTime> lsDateTime = new List<DateTime>();

                            lsDateTime.Add(DateTimeA2);  //彈性時間

                            //刷卡時間
                            if (rsAttCard.Count > 0)
                            {
                                var rAttCard = rsAttCard.OrderBy(p => p.OnCardTime48).ToList().FirstOrDefault();

                                if (rAttCard != null) 
                                lsDateTime.Add(Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48)));
                            }

                            //請假時間
                            if (rsAbs.Count > 0)
                            {
                                var rAbs = rsAbs.OrderBy(p => p.DateTimeB).ToList().FirstOrDefault();

                                if (rAbs != null)
                                lsDateTime.Add(rAbs.DateTimeB);
                            }

                            if (lsDateTime.Count > 0)
                            {
                                DateTimeX = lsDateTime.Min();

                                //判斷此時間是否有比表訂時間早，有的話就以表訂時間為準
                                DateTimeA2 = DateTimeX < DateTimeA ? DateTimeA : DateTimeX;
                            }

                            //DateTimeA2 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA2) ? tlAttend[0].DateTimeB : DateTimeA;
                            DateTimeD = DateTimeD.AddMinutes((DateTimeA2 - DateTimeA).TotalMinutes);
                            DateTimeA = DateTimeA2;
                        }
                    }
                }

                DateTimeX = DateTimeA;

                TimeSpan ts;

                for (int z = 0; z <= tlAttend.Count - 1; z++)
                {
                    var rAtt = tlAttend[z];

                    rAtt.DateTimeB = rAtt.DateTimeB >= DateTimeD ? DateTimeD : rAtt.DateTimeB;

                    if (DateTimeX < rAtt.DateTimeB)
                    {
                        ts = rAtt.DateTimeB - DateTimeX;
                        if (rAtt.Type != AttEndType.Abs || z == 0)  //正常出勤，第一次進來一定算遲到
                            if (rAtt.Type == AttEndType.Res && z == 0)
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                            else if (rAtt.Type == AttEndType.Res)
                                rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                            else
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                        else if (rAtt.Type == AttEndType.Abs)
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                    }

                    DateTimeX = DateTimeX >= rAtt.DateTimeE ? DateTimeX : rAtt.DateTimeE;

                    //如果出勤資料的結束時間大於出勒應下班時間就直接結束
                    if (DateTimeD <= rAtt.DateTimeE || z == tlAttend.Count - 1)
                    {
                        //如果最後一次進來再比較一次算出早退分鐘數
                        if (DateTimeX < DateTimeD)
                        {
                            ts = DateTimeD - DateTimeX;
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);
                        }

                        break;
                    }
                }
            }

            return rAttEnd;
        }

        /// <summary>
        /// 判斷異常-超勤
        /// </summary>
        /// <param name="rsAttCard">出勤資料</param>
        /// <param name="rRote">班別資料</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="dDate">判斷日期</param>
        /// <returns>AttEndTable</returns>
        public AttEndTable AttEndByOneDayBySupermill(List<AttCardTable> rsAttCard, RoteTable rRote, List<AbsTable> rsAbs, DateTime dDate)
        {
            bool IsHoliDay = rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0;

            var rAttEnd = new AttEndTable();

            List<AttEndTempTable> rsAttEndTempTable = new List<AttEndTempTable>();

            //var rsAttCard = obVdb.AttCardDataDay;
            //var rRote = obVdb.RoteDataDay;
            //var rsAbs = obVdb.AbsDataDay;

            DateTime Date = dDate.Date;
            DateTime DateTimeA, DateTimeD;    //實際應出勤上下班日期時間
            DateTime DateTimeA1;   //加入可遲到分鐘數後
            DateTime DateTimeA2;   //加入彈性分鐘數後
            DateTime DateTimeX; //暫存

            DateTimeA = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));    //實際應出勤上班日期時間
            DateTimeD = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));   //實際應出勤下班日期時間

            DateTimeA1 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.LatesMin));    //先加入可遲到分鐘數
            DateTimeA2 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.ElasticityMin));   //再加入彈性分鐘數

            //忘刷次數小於等於1：比對請假資料
            //忘刷次數大於等於2：比對上下班時間
            //請假時間不正確再比對請假資料

            //計算忘刷次數
            rAttEnd.Card = rsAttCard.Where(p => p.OnLos).Count() + rsAttCard.Where(p => p.OffLos).Count();

            //Type = 1 = 出勤
            //Type = 2 = 休息
            //Type = 3 = 請假

            //計算提早來跟延後走的分鐘數
            rAttEnd.EarlyMin = 0;
            rAttEnd.DelayMin = 0;
            if (rsAttCard.Count == 1 && rRote != null && !IsHoliDay)
            {
                var rAttCard = rsAttCard[0];
                if (rAttCard.DT1 != null && rAttCard.OnCardTime48.Trim().Length > 0 && DateTimeA.CompareTo(rAttCard.DT1) > 0)
                {
                    TimeSpan ts = DateTimeA - rAttCard.DT1.Value;
                    rAttEnd.EarlyMin = Convert.ToInt32(ts.TotalMinutes);
                }

                if (rAttCard.DT2 != null && rAttCard.OffCardTime48.Trim().Length > 0 && DateTimeD.CompareTo(rAttCard.DT2) < 0)
                {
                    TimeSpan ts = rAttCard.DT2.Value - DateTimeD;
                    rAttEnd.DelayMin = Convert.ToInt32(ts.TotalMinutes);
                }
            }

            //出勤
            foreach (var rAttCard in rsAttCard)
            {
                var rAttEndTemp = new AttEndTempTable();
                //rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                //rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48));
                rAttEndTemp.DateTimeB = rAttCard.DT1.GetValueOrDefault(dDate);
                rAttEndTemp.DateTimeE = rAttCard.DT2.GetValueOrDefault(dDate);
                rAttEndTemp.Type = AttEndType.Att;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            //休息
            foreach (var rRes in rRote.DayRes)
            {
                //一定要有在出勤時間裡才需要被加進來 可以放在外面 不要在這邊判斷
                if (rRote.OnTime.Trim().CompareTo(rRes.ResE) <= 0
                && rRote.OffTime.Trim().CompareTo(rRes.ResB) >= 0)
                {
                    var rAttEndTemp = new AttEndTempTable();
                    rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResB));
                    rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResE));
                    rAttEndTemp.Type = AttEndType.Res;
                    rsAttEndTempTable.Add(rAttEndTemp);
                }
            }

            //請假
            foreach (var rAbs in rsAbs)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = rAbs.DateTimeB;
                rAttEndTemp.DateTimeE = rAbs.DateTimeE;
                rAttEndTemp.Type = AttEndType.Abs;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            var tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();

            //如果沒有出勤也沒有請假資料就是曠職
            if (tlAttend.Where(p => p.Type == AttEndType.Att || p.Type == AttEndType.Abs).Count() == 0)
                rAttEnd.Abs = true;
            else
            {
                //第一筆如果不是出勤資料，則應該是上午請假
                //反之如下
                //取得實際出勤的上下班時間(應加入可遲到分鐘數及彈性分鐘數)目前僅可以選一種
                //if (tlAttend[0].Type == AttEndType.Att)
                {
                    //可遲到分鐘數
                    if (rRote.LatesMin > rRote.ElasticityMin)
                    {
                        if (rRote.LatesMin > 0)
                        {
                            DateTimeA1 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA1) ? tlAttend[0].DateTimeB : DateTimeA;
                            DateTimeA = DateTimeA1;
                        }
                    }
                    else
                    {
                        //彈性分鐘數
                        if (rRote.ElasticityMin > 0)
                        {
                            //如果員工有請假，可能用請假開始時間為彈性上班開始時間
                            //請假時間跟刷卡時間先做比較
                            //所有時間放進一個時間陣列一起比較 最後再與表訂上班時間比較 不可比表訂上班時間之前
                            List<DateTime> lsDateTime = new List<DateTime>();

                            lsDateTime.Add(DateTimeA2);  //彈性時間

                            //刷卡時間
                            if (rsAttCard.Count > 0)
                            {
                                var rAttCard = rsAttCard.OrderBy(p => p.OnCardTime48).ToList().FirstOrDefault();

                                if (rAttCard != null)
                                    lsDateTime.Add(Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48)));
                            }

                            //請假時間
                            if (rsAbs.Count > 0)
                            {
                                var rAbs = rsAbs.OrderBy(p => p.DateTimeB).ToList().FirstOrDefault();

                                if (rAbs != null)
                                    lsDateTime.Add(rAbs.DateTimeB);
                            }

                            if (lsDateTime.Count > 0)
                            {
                                DateTimeX = lsDateTime.Min();

                                //判斷此時間是否有比表訂時間早，有的話就以表訂時間為準
                                DateTimeA2 = DateTimeX < DateTimeA ? DateTimeA : DateTimeX;
                            }

                            //DateTimeA2 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA2) ? tlAttend[0].DateTimeB : DateTimeA;
                            DateTimeD = DateTimeD.AddMinutes((DateTimeA2 - DateTimeA).TotalMinutes);
                            DateTimeA = DateTimeA2;
                        }
                    }
                }

                DateTimeX = DateTimeA;

                TimeSpan ts;

                for (int z = 0; z <= tlAttend.Count - 1; z++)
                {
                    var rAtt = tlAttend[z];

                    rAtt.DateTimeB = rAtt.DateTimeB >= DateTimeD ? DateTimeD : rAtt.DateTimeB;

                    if (DateTimeX < rAtt.DateTimeB)
                    {
                        ts = rAtt.DateTimeB - DateTimeX;
                        if (rAtt.Type != AttEndType.Abs || z == 0)  //正常出勤，第一次進來一定算遲到
                            if (rAtt.Type == AttEndType.Res && z == 0)
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                            else if (rAtt.Type == AttEndType.Res)
                                rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                            else
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                        else if (rAtt.Type == AttEndType.Abs)
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                    }

                    DateTimeX = DateTimeX >= rAtt.DateTimeE ? DateTimeX : rAtt.DateTimeE;

                    //如果出勤資料的結束時間大於出勒應下班時間就直接結束
                    if (DateTimeD <= rAtt.DateTimeE || z == tlAttend.Count - 1)
                    {
                        //如果最後一次進來再比較一次算出早退分鐘數
                        if (DateTimeX < DateTimeD)
                        {
                            ts = DateTimeD - DateTimeX;
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);
                        }

                        break;
                    }
                }
            }

            return rAttEnd;
        }

        /// <summary>
        /// 判斷異常 旭寬
        /// </summary>
        /// <param name="rsAttCard">出勤資料</param>
        /// <param name="rRote">班別資料</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="dDate">判斷日期</param>
        /// <param name="bElasticity">判斷如果刷卡後時間超過彈性後時間則無彈性 預設False</param>
        /// <returns>AttEndTable</returns>
        public AttEndTable AttEndByOneDayByNewwide(List<AttCardTable> rsAttCard, RoteTable rRote, List<AbsTable> rsAbs, DateTime dDate, bool bElasticity = false)
        {
            bool IsHoliDay = rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0;

            var rAttEnd = new AttEndTable();

            List<AttEndTempTable> rsAttEndTempTable = new List<AttEndTempTable>();

            //var rsAttCard = obVdb.AttCardDataDay;
            //var rRote = obVdb.RoteDataDay;
            //var rsAbs = obVdb.AbsDataDay;

            DateTime Date = dDate.Date;
            DateTime DateTimeA, DateTimeD;    //實際應出勤上下班日期時間
            DateTime DateTimeA1;   //加入可遲到分鐘數後
            DateTime DateTimeA2;   //加入彈性分鐘數後
            DateTime DateTimeX; //暫存
            TimeSpan ts;    //時間計算

            DateTimeA = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));    //實際應出勤上班日期時間
            DateTimeD = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));   //實際應出勤下班日期時間

            DateTimeA1 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.LatesMin));    //先加入可遲到分鐘數
            DateTimeA2 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.ElasticityMin));   //再加入彈性分鐘數

            //忘刷次數小於等於1：比對請假資料
            //忘刷次數大於等於2：比對上下班時間
            //請假時間不正確再比對請假資料

            //計算忘刷次數
            rAttEnd.Card = rsAttCard.Where(p => p.OnLos).Count() + rsAttCard.Where(p => p.OffLos).Count();

            //Type = 1 = 出勤
            //Type = 2 = 休息
            //Type = 3 = 請假

            //計算提早來跟延後走的分鐘數
            rAttEnd.EarlyMin = 0;
            rAttEnd.DelayMin = 0;
            rAttEnd.ElasticityMin = 0;  //使用彈性分鐘數
            if (rsAttCard.Count == 1 && rRote != null && !IsHoliDay)
            {
                var rAttCard = rsAttCard[0];
                if (rAttCard.OnCardTime48.Trim().Length > 0 && rRote.OnTime.CompareTo(rAttCard.OnCardTime48) > 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48);

                    rAttEnd.EarlyMin = iRoteMin - iCardMin;
                }

                if (rAttCard.OffCardTime48.Trim().Length > 0 && rRote.OffTime.CompareTo(rAttCard.OffCardTime48) < 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48);

                    rAttEnd.DelayMin = iCardMin - iRoteMin;
                }
            }

            //出勤
            foreach (var rAttCard in rsAttCard)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48));
                rAttEndTemp.Type = AttEndType.Att;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            //休息
            foreach (var rRes in rRote.DayRes)
            {
                //一定要有在出勤時間裡才需要被加進來 可以放在外面 不要在這邊判斷
                if (rRote.OnTime.Trim().CompareTo(rRes.ResE) <= 0
                && rRote.OffTime.Trim().CompareTo(rRes.ResB) >= 0)
                {
                    var rAttEndTemp = new AttEndTempTable();
                    rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResB));
                    rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResE));
                    rAttEndTemp.Type = AttEndType.Res;
                    rsAttEndTempTable.Add(rAttEndTemp);
                }
            }

            //請假
            foreach (var rAbs in rsAbs)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = rAbs.DateTimeB;
                rAttEndTemp.DateTimeE = rAbs.DateTimeE;
                rAttEndTemp.Type = AttEndType.Abs;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            var tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();

            //如果沒有出勤也沒有請假資料就是曠職
            if (tlAttend.Where(p => p.Type == AttEndType.Att || p.Type == AttEndType.Abs).Count() == 0)
                rAttEnd.Abs = true;
            else
            {
                //第一筆如果不是出勤資料，則應該是上午請假
                //反之如下
                //取得實際出勤的上下班時間(應加入可遲到分鐘數及彈性分鐘數)目前僅可以選一種
                //if (tlAttend[0].Type == AttEndType.Att)
                {
                    //可遲到分鐘數
                    if (rRote.LatesMin > rRote.ElasticityMin)
                    {
                        if (rRote.LatesMin > 0)
                        {
                            DateTimeA1 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA1) ? tlAttend[0].DateTimeB : DateTimeA;
                            DateTimeA = DateTimeA1;
                        }
                    }
                    else
                    {
                        //彈性分鐘數
                        if (rRote.ElasticityMin > 0 || rRote.ElasticityBeforeMin > 0)
                        {
                            //所有時間放進一個時間陣列一起比較 最後再與表訂上班時間比較 不可比表訂上班時間之前
                            List<DateTime> lsDateTime = new List<DateTime>();

                            lsDateTime.Add(DateTimeA2);  //彈性時間

                            //刷卡時間
                            DateTime? DateTimeOnCardTime = null;
                            if (rsAttCard.Count > 0)
                            {
                                var rAttCard = rsAttCard.OrderBy(p => p.OnCardTime48).ToList().FirstOrDefault();

                                if (rAttCard != null)
                                {
                                    DateTimeOnCardTime = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                                    lsDateTime.Add(DateTimeOnCardTime.Value);
                                }
                            }

                            //請假時間
                            if (rsAbs.Count > 0)
                            {
                                var rAbs = rsAbs.OrderBy(p => p.DateTimeB).ToList().FirstOrDefault();

                                if (rAbs != null)
                                    lsDateTime.Add(rAbs.DateTimeB);
                            }

                            //判斷如果刷卡後時間超過彈性後時間則無彈性
                            bool GoIng = true;
                            if (bElasticity && DateTimeOnCardTime != null)
                                if (DateTimeA2 < DateTimeOnCardTime.Value)
                                    GoIng = false;

                            //如果有彈性...
                            if (GoIng)
                            {
                                //提前彈性
                                DateTime DateTimeY = DateTimeA.AddMinutes(-Convert.ToDouble(rRote.ElasticityBeforeMin));

                                if (lsDateTime.Count > 0)
                                {
                                    DateTimeX = lsDateTime.Min();

                                    //判斷此時間是否有比表訂時間早，有的話就以表訂時間為準
                                    //DateTimeA2 = DateTimeX < DateTimeA ? DateTimeA : DateTimeX;
                                    DateTimeA2 = DateTimeX < DateTimeY ? DateTimeY : DateTimeX;
                                }

                                //如果有請假並非全天 且 請假結束時間等於應出勤結束時間 則 應採用此筆請假開始時間 為彈性延後結束時間
                                var rsAbsAndRes = tlAttend.Where(p => p.Type == AttEndType.Abs || p.Type == AttEndType.Res).ToList();

                                //反向排序結束時間
                                rsAbsAndRes = rsAbsAndRes.OrderByDescending(p => p.DateTimeE).ToList();

                                //利用反向排序來找出真正的下班時間
                                for (int z = 0; z <= rsAbsAndRes.Count - 1; z++)
                                {
                                    var rAtt = rsAbsAndRes[z];

                                    //如果請假或休息時間 等於應出勤結束時間
                                    if (rAtt.DateTimeE == DateTimeD)
                                    {
                                        //將應出勤結束時間變成開始時間
                                        DateTimeD = DateTimeD < rAtt.DateTimeB ? DateTimeD : rAtt.DateTimeB;

                                        //並於tlAttend移除該筆資料
                                        tlAttend.Remove(rAtt);
                                    }
                                }

                                ts = DateTimeA2 - DateTimeA;
                                rAttEnd.ElasticityMin = Convert.ToInt32(ts.TotalMinutes);

                                DateTimeD = DateTimeD.AddMinutes(rAttEnd.ElasticityMin);
                                DateTimeA = DateTimeA2;
                            }
                        }
                    }
                }

                DateTimeX = DateTimeA;

                for (int z = 0; z <= tlAttend.Count - 1; z++)
                {
                    var rAtt = tlAttend[z];

                    rAtt.DateTimeB = rAtt.DateTimeB >= DateTimeD ? DateTimeD : rAtt.DateTimeB;

                    //開始或上班時間 小於 出勤或請假時間或休息時間
                    if (DateTimeX < rAtt.DateTimeB)
                    {
                        ts = rAtt.DateTimeB - DateTimeX;
                        if (rAtt.Type != AttEndType.Abs || z == 0)  //正常出勤，第一次進來一定算遲到
                            if (rAtt.Type == AttEndType.Res && z == 0)
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                            else if (rAtt.Type == AttEndType.Res)
                                rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                            else
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                        else if (rAtt.Type == AttEndType.Abs)
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                    }

                    DateTimeX = DateTimeX >= rAtt.DateTimeE ? DateTimeX : rAtt.DateTimeE;

                    //如果出勤資料的結束時間大於出勤應下班時間就直接結束
                    if (DateTimeD <= rAtt.DateTimeE || z == tlAttend.Count - 1)
                    {
                        //如果最後一次進來再比較一次算出早退分鐘數
                        if (DateTimeX < DateTimeD)
                        {
                            ts = DateTimeD - DateTimeX;
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);
                        }

                        break;
                    }
                }
            }

            return rAttEnd;
        }

        /// <summary>
        /// 判斷異常 酷碼 請假時間在彈性時間裡面，也可以使用彈性規則
        /// </summary>
        /// <param name="rsAttCard">出勤資料</param>
        /// <param name="rRote">班別資料</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="dDate">判斷日期</param>
        /// <param name="bElasticity">判斷如果刷卡後時間超過彈性後時間則無彈性 預設False</param>
        /// <returns>AttEndTable</returns>
        public AttEndTable AttEndByOneDayByCoolermaster(List<AttCardTable> rsAttCard, RoteTable rRote, List<AbsTable> rsAbs, DateTime dDate, bool bElasticity = false)
        {
            bool IsHoliDay = rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0;

            var rAttEnd = new AttEndTable();

            List<AttEndTempTable> rsAttEndTempTable = new List<AttEndTempTable>();

            //var rsAttCard = obVdb.AttCardDataDay;
            //var rRote = obVdb.RoteDataDay;
            //var rsAbs = obVdb.AbsDataDay;

            DateTime Date = dDate.Date;
            DateTime DateTimeA, DateTimeD;    //實際應出勤上下班日期時間
            DateTime DateTimeA1;   //加入可遲到分鐘數後
            DateTime DateTimeA2;   //加入彈性分鐘數後
            DateTime DateTimeX; //暫存
            TimeSpan ts;    //時間計算

            DateTimeA = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));    //實際應出勤上班日期時間
            DateTimeD = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));   //實際應出勤下班日期時間

            DateTimeA1 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.LatesMin));    //先加入可遲到分鐘數
            DateTimeA2 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.ElasticityMin));   //再加入彈性分鐘數

            //忘刷次數小於等於1：比對請假資料
            //忘刷次數大於等於2：比對上下班時間
            //請假時間不正確再比對請假資料

            //計算忘刷次數
            rAttEnd.Card = rsAttCard.Where(p => p.OnLos).Count() + rsAttCard.Where(p => p.OffLos).Count();

            //Type = 1 = 出勤
            //Type = 2 = 休息
            //Type = 3 = 請假

            //計算提早來跟延後走的分鐘數
            rAttEnd.EarlyMin = 0;
            rAttEnd.DelayMin = 0;
            rAttEnd.ElasticityMin = 0;  //使用彈性分鐘數
            if (rsAttCard.Count == 1 && rRote != null && !IsHoliDay)
            {
                var rAttCard = rsAttCard[0];
                if (rAttCard.OnCardTime48.Trim().Length > 0 && rRote.OnTime.CompareTo(rAttCard.OnCardTime48) > 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48);

                    rAttEnd.EarlyMin = iRoteMin - iCardMin;
                }

                if (rAttCard.OffCardTime48.Trim().Length > 0 && rRote.OffTime.CompareTo(rAttCard.OffCardTime48) < 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48);

                    rAttEnd.DelayMin = iCardMin - iRoteMin;
                }
            }

            int AttMin = 0;

            //出勤
            foreach (var rAttCard in rsAttCard)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48));
                rAttEndTemp.Type = AttEndType.Att;
                rsAttEndTempTable.Add(rAttEndTemp);

                ts = rAttEndTemp.DateTimeE - rAttEndTemp.DateTimeB;
                AttMin += Convert.ToInt32(ts.TotalMinutes);          
            }

            //休息
            foreach (var rRes in rRote.DayRes)
            {
                //一定要有在出勤時間裡才需要被加進來 可以放在外面 不要在這邊判斷
                if (rRote.OnTime.Trim().CompareTo(rRes.ResE) <= 0
                && rRote.OffTime.Trim().CompareTo(rRes.ResB) >= 0)
                {
                    var rAttEndTemp = new AttEndTempTable();
                    rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResB));
                    rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResE));
                    rAttEndTemp.Type = AttEndType.Res;
                    rsAttEndTempTable.Add(rAttEndTemp);
                }
            }

            //請假
            foreach (var rAbs in rsAbs)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = rAbs.DateTimeB;
                rAttEndTemp.DateTimeE = rAbs.DateTimeE;
                rAttEndTemp.Type = AttEndType.Abs;
                rsAttEndTempTable.Add(rAttEndTemp);

                ts = rAttEndTemp.DateTimeE - rAttEndTemp.DateTimeB;
                AttMin += Convert.ToInt32(ts.TotalMinutes);
            }

            var tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();

            //如果沒有出勤也沒有請假資料就是曠職
            if (tlAttend.Where(p => p.Type == AttEndType.Att || p.Type == AttEndType.Abs).Count() == 0)
                rAttEnd.Abs = true;
            else
            {
                //第一筆如果不是出勤資料，則應該是上午請假
                //反之如下
                //取得實際出勤的上下班時間(應加入可遲到分鐘數及彈性分鐘數)目前僅可以選一種
                //if (tlAttend[0].Type == AttEndType.Att)
                {
                    //可遲到分鐘數
                    if (rRote.LatesMin > rRote.ElasticityMin)
                    {
                        if (rRote.LatesMin > 0)
                        {
                            DateTimeA1 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA1) ? tlAttend[0].DateTimeB : DateTimeA;
                            DateTimeA = DateTimeA1;
                        }
                    }
                    else
                    {
                        //彈性分鐘數
                        if (rRote.ElasticityMin > 0 || rRote.ElasticityBeforeMin > 0)
                        {
                            //所有時間放進一個時間陣列一起比較 最後再與表訂上班時間比較 不可比表訂上班時間之前
                            List<DateTime> lsDateTime = new List<DateTime>();

                            lsDateTime.Add(DateTimeA2);  //彈性時間

                            //刷卡時間
                            DateTime? DateTimeOnCardTime = null;
                            if (rsAttCard.Count > 0)
                            {
                                var rAttCard = rsAttCard.OrderBy(p => p.OnCardTime48).ToList().FirstOrDefault();

                                if (rAttCard != null)
                                {
                                    DateTimeOnCardTime = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                                    lsDateTime.Add(DateTimeOnCardTime.Value);
                                }
                            }

                            //請假時間 只抓請假結束時間大於彈性時間的請假
                            var rsAbsTemp = rsAbs.Where(p=>p.DateTimeE > DateTimeA2).ToList();
                            if (rsAbsTemp.Count > 0)
                            {
                                var rAbs = rsAbsTemp.OrderBy(p => p.DateTimeB).ToList().FirstOrDefault();

                                if (rAbs != null)
                                    lsDateTime.Add(rAbs.DateTimeB);
                            }

                            //判斷如果刷卡後時間超過彈性後時間則無彈性
                            bool GoIng = true;
                            if (bElasticity && DateTimeOnCardTime != null)
                                if (DateTimeA2 < DateTimeOnCardTime.Value)
                                    GoIng = false;

                            //如果有彈性...
                            if (GoIng)
                            {
                                //提前彈性
                                DateTime DateTimeY = DateTimeA.AddMinutes(-Convert.ToDouble(rRote.ElasticityBeforeMin));

                                if (lsDateTime.Count > 0)
                                {
                                    DateTimeX = lsDateTime.Min();

                                    //判斷此時間是否有比表訂時間早，有的話就以表訂時間為準
                                    //DateTimeA2 = DateTimeX < DateTimeA ? DateTimeA : DateTimeX;
                                    DateTimeA2 = DateTimeX < DateTimeY ? DateTimeY : DateTimeX;
                                }

                                //如果有請假並非全天 且 請假結束時間等於應出勤結束時間 則 應採用此筆請假開始時間 為彈性延後結束時間
                                var rsAbsAndRes = tlAttend.Where(p => p.Type == AttEndType.Abs || p.Type == AttEndType.Res).ToList();

                                //反向排序結束時間
                                rsAbsAndRes = rsAbsAndRes.OrderByDescending(p => p.DateTimeE).ToList();

                                //利用反向排序來找出真正的下班時間
                                for (int z = 0; z <= rsAbsAndRes.Count - 1; z++)
                                {
                                    var rAtt = rsAbsAndRes[z];

                                    //如果請假或休息時間 等於應出勤結束時間
                                    if (rAtt.DateTimeE == DateTimeD)
                                    {
                                        //將應出勤結束時間變成開始時間
                                        DateTimeD = DateTimeD < rAtt.DateTimeB ? DateTimeD : rAtt.DateTimeB;

                                        //並於tlAttend移除該筆資料
                                        tlAttend.Remove(rAtt);
                                    }
                                }

                                //置換上班開始時間
                                rsAbsTemp = rsAbs.Where(p => p.DateTimeE <= DateTimeA2).ToList();
                                if (rsAbsTemp.Count > 0)
                                {
                                    var rAbs = rsAbsTemp.OrderByDescending(p => p.DateTimeE).ToList().FirstOrDefault();

                                    if (rAbs != null)
                                        DateTimeA = rAbs.DateTimeE;
                                }

                                ts = DateTimeA2 - DateTimeA;
                                rAttEnd.ElasticityMin = Convert.ToInt32(ts.TotalMinutes);

                                DateTimeD = DateTimeD.AddMinutes(rAttEnd.ElasticityMin);
                                DateTimeA = DateTimeA2;
                            }
                        }
                    }
                }

                DateTimeX = DateTimeA;

                for (int z = 0; z <= tlAttend.Count - 1; z++)
                {
                    var rAtt = tlAttend[z];

                    rAtt.DateTimeB = rAtt.DateTimeB >= DateTimeD ? DateTimeD : rAtt.DateTimeB;

                    //開始或上班時間 小於 出勤或請假時間或休息時間
                    if (DateTimeX < rAtt.DateTimeB)
                    {
                        ts = rAtt.DateTimeB - DateTimeX;
                        if (rAtt.Type != AttEndType.Abs || z == 0)  //正常出勤，第一次進來一定算遲到
                            if (rAtt.Type == AttEndType.Res && z == 0)
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                            else if (rAtt.Type == AttEndType.Res)
                                rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                            else
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                        else if (rAtt.Type == AttEndType.Abs)
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                    }

                    DateTimeX = DateTimeX >= rAtt.DateTimeE ? DateTimeX : rAtt.DateTimeE;

                    //如果出勤資料的結束時間大於出勤應下班時間就直接結束
                    if (DateTimeD <= rAtt.DateTimeE || z == tlAttend.Count - 1)
                    {
                        //如果最後一次進來再比較一次算出早退分鐘數
                        if (DateTimeX < DateTimeD)
                        {
                            ts = DateTimeD - DateTimeX;
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);
                        }

                        break;
                    }
                }
            }

            //如果出勤時數加工作時數超過工作時數 則無異常
            //decimal AttHrs = AttMin / 60M;
            //if ( AttHrs >= rRote.WorkHour)
            //{
            //    rAttEnd.Abs = false;
            //    rAttEnd.EarlierMin = 0;
            //    rAttEnd.LatesMin = 0;
            //}

            return rAttEnd;
        }

        /// <summary>
        /// 判斷異常 禾生技 請假時間在彈性時間裡面，也可以使用彈性規則
        /// 特殊規則 上班時間之前採用彈性 上班時間之後採用可遲到
        /// </summary>
        /// <param name="rsAttCard">出勤資料</param>
        /// <param name="rRote">班別資料</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="dDate">判斷日期</param>
        /// <param name="bElasticity">判斷如果刷卡後時間超過彈性後時間則無彈性 預設False</param>
        /// <returns>AttEndTable</returns>
        public AttEndTable AttEndByOneDayByHolyHealth(List<AttCardTable> rsAttCard, RoteTable rRote, List<AbsTable> rsAbs, DateTime dDate, bool bElasticity = false)
        {
            bool IsHoliDay = rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0;

            var rAttEnd = new AttEndTable();

            List<AttEndTempTable> rsAttEndTempTable = new List<AttEndTempTable>();

            //var rsAttCard = obVdb.AttCardDataDay;
            //var rRote = obVdb.RoteDataDay;
            //var rsAbs = obVdb.AbsDataDay;

            DateTime Date = dDate.Date;
            DateTime DateTimeA, DateTimeD;    //實際應出勤上下班日期時間
            DateTime DateTimeA1;   //加入可遲到分鐘數後
            DateTime DateTimeA2;   //加入彈性分鐘數後
            DateTime DateTimeX; //暫存
            TimeSpan ts;    //時間計算

            DateTimeA = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));    //實際應出勤上班日期時間
            DateTimeD = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));   //實際應出勤下班日期時間

            DateTimeA1 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.LatesMin));    //先加入可遲到分鐘數
            DateTimeA2 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.ElasticityMin));   //再加入彈性分鐘數

            //忘刷次數小於等於1：比對請假資料
            //忘刷次數大於等於2：比對上下班時間
            //請假時間不正確再比對請假資料

            //計算忘刷次數
            rAttEnd.Card = rsAttCard.Where(p => p.OnLos).Count() + rsAttCard.Where(p => p.OffLos).Count();

            //Type = 1 = 出勤
            //Type = 2 = 休息
            //Type = 3 = 請假

            //計算提早來跟延後走的分鐘數
            rAttEnd.EarlyMin = 0;
            rAttEnd.DelayMin = 0;
            rAttEnd.ElasticityMin = 0;  //使用彈性分鐘數
            if (rsAttCard.Count == 1 && rRote != null && !IsHoliDay)
            {
                var rAttCard = rsAttCard[0];
                if (rAttCard.OnCardTime48.Trim().Length > 0 && rRote.OnTime.CompareTo(rAttCard.OnCardTime48) > 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48);

                    rAttEnd.EarlyMin = iRoteMin - iCardMin;
                }

                if (rAttCard.OffCardTime48.Trim().Length > 0 && rRote.OffTime.CompareTo(rAttCard.OffCardTime48) < 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48);

                    rAttEnd.DelayMin = iCardMin - iRoteMin;
                }
            }

            int AttMin = 0;

            //出勤
            foreach (var rAttCard in rsAttCard)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48));
                rAttEndTemp.Type = AttEndType.Att;
                rsAttEndTempTable.Add(rAttEndTemp);

                ts = rAttEndTemp.DateTimeE - rAttEndTemp.DateTimeB;
                AttMin += Convert.ToInt32(ts.TotalMinutes);
            }

            //休息
            foreach (var rRes in rRote.DayRes)
            {
                //一定要有在出勤時間裡才需要被加進來 可以放在外面 不要在這邊判斷
                if (rRote.OnTime.Trim().CompareTo(rRes.ResE) <= 0
                && rRote.OffTime.Trim().CompareTo(rRes.ResB) >= 0)
                {
                    var rAttEndTemp = new AttEndTempTable();
                    rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResB));
                    rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResE));
                    rAttEndTemp.Type = AttEndType.Res;
                    rsAttEndTempTable.Add(rAttEndTemp);
                }
            }

            //請假
            foreach (var rAbs in rsAbs)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = rAbs.DateTimeB;
                rAttEndTemp.DateTimeE = rAbs.DateTimeE;
                rAttEndTemp.Type = AttEndType.Abs;
                rsAttEndTempTable.Add(rAttEndTemp);

                ts = rAttEndTemp.DateTimeE - rAttEndTemp.DateTimeB;
                AttMin += Convert.ToInt32(ts.TotalMinutes);
            }

            var tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();

            //如果沒有出勤也沒有請假資料就是曠職
            if (tlAttend.Where(p => p.Type == AttEndType.Att || p.Type == AttEndType.Abs).Count() == 0)
                rAttEnd.Abs = true;
            else
            {
                //第一筆如果不是出勤資料，則應該是上午請假
                //反之如下
                //取得實際出勤的上下班時間(應加入可遲到分鐘數及彈性分鐘數)目前僅可以選一種
                //if (tlAttend[0].Type == AttEndType.Att)
                {
                    //可遲到分鐘數
                    //if (rRote.LatesMin > rRote.ElasticityMin)
                    //實際出勤時間 大於 應出勤上班時間 可遲到
                    if (tlAttend[0].DateTimeB >= DateTimeA)
                    {
                        if (rRote.LatesMin > 0)
                        {
                            DateTimeA1 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA1) ? tlAttend[0].DateTimeB : DateTimeA;
                            DateTimeA = DateTimeA1;
                        }
                    }
                    else
                    {
                        //彈性分鐘數
                        if (rRote.ElasticityMin > 0 || rRote.ElasticityBeforeMin > 0)
                        {
                            //所有時間放進一個時間陣列一起比較 最後再與表訂上班時間比較 不可比表訂上班時間之前
                            List<DateTime> lsDateTime = new List<DateTime>();

                            lsDateTime.Add(DateTimeA2);  //彈性時間

                            //刷卡時間
                            DateTime? DateTimeOnCardTime = null;
                            if (rsAttCard.Count > 0)
                            {
                                var rAttCard = rsAttCard.OrderBy(p => p.OnCardTime48).ToList().FirstOrDefault();

                                if (rAttCard != null)
                                {
                                    DateTimeOnCardTime = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                                    lsDateTime.Add(DateTimeOnCardTime.Value);
                                }
                            }

                            //請假時間 只抓請假結束時間大於彈性時間的請假
                            var rsAbsTemp = rsAbs.Where(p => p.DateTimeE > DateTimeA2).ToList();
                            if (rsAbsTemp.Count > 0)
                            {
                                var rAbs = rsAbsTemp.OrderBy(p => p.DateTimeB).ToList().FirstOrDefault();

                                if (rAbs != null)
                                    lsDateTime.Add(rAbs.DateTimeB);
                            }

                            //判斷如果刷卡後時間超過彈性後時間則無彈性
                            bool GoIng = true;
                            if (bElasticity && DateTimeOnCardTime != null)
                                if (DateTimeA2 < DateTimeOnCardTime.Value)
                                    GoIng = false;

                            //如果有彈性...
                            if (GoIng)
                            {
                                //提前彈性
                                DateTime DateTimeY = DateTimeA.AddMinutes(-Convert.ToDouble(rRote.ElasticityBeforeMin));

                                if (lsDateTime.Count > 0)
                                {
                                    DateTimeX = lsDateTime.Min();

                                    //判斷此時間是否有比表訂時間早，有的話就以表訂時間為準
                                    //DateTimeA2 = DateTimeX < DateTimeA ? DateTimeA : DateTimeX;
                                    DateTimeA2 = DateTimeX < DateTimeY ? DateTimeY : DateTimeX;
                                }

                                //如果有請假並非全天 且 請假結束時間等於應出勤結束時間 則 應採用此筆請假開始時間 為彈性延後結束時間
                                var rsAbsAndRes = tlAttend.Where(p => p.Type == AttEndType.Abs || p.Type == AttEndType.Res).ToList();

                                //反向排序結束時間
                                rsAbsAndRes = rsAbsAndRes.OrderByDescending(p => p.DateTimeE).ToList();

                                //利用反向排序來找出真正的下班時間
                                for (int z = 0; z <= rsAbsAndRes.Count - 1; z++)
                                {
                                    var rAtt = rsAbsAndRes[z];

                                    //如果請假或休息時間 等於應出勤結束時間
                                    if (rAtt.DateTimeE == DateTimeD)
                                    {
                                        //將應出勤結束時間變成開始時間
                                        DateTimeD = DateTimeD < rAtt.DateTimeB ? DateTimeD : rAtt.DateTimeB;

                                        //並於tlAttend移除該筆資料
                                        tlAttend.Remove(rAtt);
                                    }
                                }

                                //置換上班開始時間
                                rsAbsTemp = rsAbs.Where(p => p.DateTimeE <= DateTimeA2).ToList();
                                if (rsAbsTemp.Count > 0)
                                {
                                    var rAbs = rsAbsTemp.OrderByDescending(p => p.DateTimeE).ToList().FirstOrDefault();

                                    if (rAbs != null)
                                        DateTimeA = rAbs.DateTimeE;
                                }

                                ts = DateTimeA2 - DateTimeA;
                                rAttEnd.ElasticityMin = Convert.ToInt32(ts.TotalMinutes);

                                DateTimeD = DateTimeD.AddMinutes(rAttEnd.ElasticityMin);
                                DateTimeA = DateTimeA2;
                            }
                        }
                    }
                }

                DateTimeX = DateTimeA;

                for (int z = 0; z <= tlAttend.Count - 1; z++)
                {
                    var rAtt = tlAttend[z];

                    rAtt.DateTimeB = rAtt.DateTimeB >= DateTimeD ? DateTimeD : rAtt.DateTimeB;

                    //開始或上班時間 小於 出勤或請假時間或休息時間
                    if (DateTimeX < rAtt.DateTimeB)
                    {
                        ts = rAtt.DateTimeB - DateTimeX;
                        if (rAtt.Type != AttEndType.Abs || z == 0)  //正常出勤，第一次進來一定算遲到
                            if (rAtt.Type == AttEndType.Res && z == 0)
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                            else if (rAtt.Type == AttEndType.Res)
                                rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                            else
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                        else if (rAtt.Type == AttEndType.Abs)
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                    }

                    DateTimeX = DateTimeX >= rAtt.DateTimeE ? DateTimeX : rAtt.DateTimeE;

                    //如果出勤資料的結束時間大於出勤應下班時間就直接結束
                    if (DateTimeD <= rAtt.DateTimeE || z == tlAttend.Count - 1)
                    {
                        //如果最後一次進來再比較一次算出早退分鐘數
                        if (DateTimeX < DateTimeD)
                        {
                            ts = DateTimeD - DateTimeX;
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);
                        }

                        break;
                    }
                }
            }

            //如果出勤時數加工作時數超過工作時數 則無異常
            //decimal AttHrs = AttMin / 60M;
            //if ( AttHrs >= rRote.WorkHour)
            //{
            //    rAttEnd.Abs = false;
            //    rAttEnd.EarlierMin = 0;
            //    rAttEnd.LatesMin = 0;
            //}

            return rAttEnd;
        }

        /// <summary>
        /// 判斷異常 彩盟
        /// </summary>
        /// <param name="rsAttCard">出勤資料</param>
        /// <param name="rRote">班別資料</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="dDate">判斷日期</param>
        /// <param name="bElasticity">判斷如果刷卡後時間超過彈性後時間則無彈性 預設False</param>
        /// <param name="bCardLatesMinSpecial">可遲到</param>
        /// <param name="bCardEarlierMinSpecial">可早退</param>
        /// <returns>AttEndTable</returns>
        public AttEndTable AttEndByOneDayByTasameng(List<AttCardTable> rsAttCard, RoteTable rRote, List<AbsTable> rsAbs, DateTime dDate, bool bElasticity = false ,bool bCardLatesMinSpecial = false, bool bCardEarlierMinSpecial = false)
        {
            bool IsHoliDay = rRote.OnTime.Length == 0 && rRote.OffTime.Length == 0 && rRote.WorkHour == 0;

            var rAttEnd = new AttEndTable();

            List<AttEndTempTable> rsAttEndTempTable = new List<AttEndTempTable>();

            //var rsAttCard = obVdb.AttCardDataDay;
            //var rRote = obVdb.RoteDataDay;
            //var rsAbs = obVdb.AbsDataDay;

            DateTime Date = dDate.Date;
            DateTime DateTimeA, DateTimeD;    //實際應出勤上下班日期時間
            DateTime DateTimeA1;   //加入可遲到分鐘數後
            DateTime DateTimeA2;   //加入彈性分鐘數後
            DateTime DateTimeD1;   //加入可早退分鐘數後
            DateTime DateTimeX; //暫存
            TimeSpan ts;    //時間計算

            DateTimeA = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime));    //實際應出勤上班日期時間
            DateTimeD = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime));   //實際應出勤下班日期時間

            int LatesMin = rRote.LatesMin;
            int EarlierMin = 0;

            if (bCardLatesMinSpecial)
                LatesMin = 60;

            if (bCardEarlierMinSpecial) 
                EarlierMin = 60; 

            DateTimeA1 = DateTimeA.AddMinutes(Convert.ToDouble(LatesMin));    //先加入可遲到分鐘數
            DateTimeA2 = DateTimeA.AddMinutes(Convert.ToDouble(rRote.ElasticityMin));   //再加入彈性分鐘數

            DateTimeD1 = DateTimeD.AddMinutes(-Convert.ToDouble(EarlierMin));    //先加入可早退分鐘數

            //忘刷次數小於等於1：比對請假資料
            //忘刷次數大於等於2：比對上下班時間
            //請假時間不正確再比對請假資料

            //計算忘刷次數
            rAttEnd.Card = rsAttCard.Where(p => p.OnLos).Count() + rsAttCard.Where(p => p.OffLos).Count();

            //Type = 1 = 出勤
            //Type = 2 = 休息
            //Type = 3 = 請假

            //計算提早來跟延後走的分鐘數
            rAttEnd.EarlyMin = 0;
            rAttEnd.DelayMin = 0;
            rAttEnd.ElasticityMin = 0;  //使用彈性分鐘數
            if (rsAttCard.Count == 1 && rRote != null && !IsHoliDay)
            {
                var rAttCard = rsAttCard[0];
                if (rAttCard.OnCardTime48.Trim().Length > 0 && rRote.OnTime.CompareTo(rAttCard.OnCardTime48) > 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OnTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48);

                    rAttEnd.EarlyMin = iRoteMin - iCardMin;
                }

                if (rAttCard.OffCardTime48.Trim().Length > 0 && rRote.OffTime.CompareTo(rAttCard.OffCardTime48) < 0)
                {
                    int iRoteMin = Tools.TimeTrans.ConvertHhMmToMinutes(rRote.OffTime);
                    int iCardMin = Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48);

                    rAttEnd.DelayMin = iCardMin - iRoteMin;
                }
            }

            //出勤
            foreach (var rAttCard in rsAttCard)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OffCardTime48));
                rAttEndTemp.Type = AttEndType.Att;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            //休息
            foreach (var rRes in rRote.DayRes)
            {
                //一定要有在出勤時間裡才需要被加進來 可以放在外面 不要在這邊判斷
                if (rRote.OnTime.Trim().CompareTo(rRes.ResE) <= 0
                && rRote.OffTime.Trim().CompareTo(rRes.ResB) >= 0)
                {
                    var rAttEndTemp = new AttEndTempTable();
                    rAttEndTemp.DateTimeB = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResB));
                    rAttEndTemp.DateTimeE = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rRes.ResE));
                    rAttEndTemp.Type = AttEndType.Res;
                    rsAttEndTempTable.Add(rAttEndTemp);
                }
            }

            //請假
            foreach (var rAbs in rsAbs)
            {
                var rAttEndTemp = new AttEndTempTable();
                rAttEndTemp.DateTimeB = rAbs.DateTimeB;
                rAttEndTemp.DateTimeE = rAbs.DateTimeE;
                rAttEndTemp.Type = AttEndType.Abs;
                rsAttEndTempTable.Add(rAttEndTemp);
            }

            var tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();

            //如果沒有出勤也沒有請假資料就是曠職
            if (tlAttend.Where(p => p.Type == AttEndType.Att || p.Type == AttEndType.Abs).Count() == 0)
                rAttEnd.Abs = true;
            else
            {
                //第一筆如果不是出勤資料，則應該是上午請假
                //反之如下
                //取得實際出勤的上下班時間(應加入可遲到分鐘數及彈性分鐘數)目前僅可以選一種
                //if (tlAttend[0].Type == AttEndType.Att)
                {
                    if (bCardLatesMinSpecial || bCardEarlierMinSpecial)
                    {
                        DateTimeA1 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA1) ? tlAttend[0].DateTimeB : DateTimeA2;
                        DateTimeA = DateTimeA1;

                        tlAttend = rsAttEndTempTable.OrderByDescending(p => p.DateTimeE).ThenBy(p => (int)p.Type).ToList();

                        DateTimeD1 = (DateTimeD1 <= tlAttend[0].DateTimeE && tlAttend[0].DateTimeE <= DateTimeD) ? tlAttend[0].DateTimeE : DateTimeD1;
                        DateTimeD = DateTimeD1;

                        tlAttend = rsAttEndTempTable.OrderBy(p => p.DateTimeB).ThenBy(p => (int)p.Type).ToList();
                    }
                    else if (LatesMin > rRote.ElasticityMin)  //可遲到分鐘數
                    {
                        if (LatesMin > 0)
                        {
                            DateTimeA1 = (DateTimeA <= tlAttend[0].DateTimeB && tlAttend[0].DateTimeB <= DateTimeA1) ? tlAttend[0].DateTimeB : DateTimeA;
                            DateTimeA = DateTimeA1;
                        }
                    }
                    else
                    {
                        //彈性分鐘數
                        if (rRote.ElasticityMin > 0 || rRote.ElasticityBeforeMin > 0)
                        {
                            //所有時間放進一個時間陣列一起比較 最後再與表訂上班時間比較 不可比表訂上班時間之前
                            List<DateTime> lsDateTime = new List<DateTime>();

                            lsDateTime.Add(DateTimeA2);  //彈性時間

                            //刷卡時間
                            DateTime? DateTimeOnCardTime = null;
                            if (rsAttCard.Count > 0)
                            {
                                var rAttCard = rsAttCard.OrderBy(p => p.OnCardTime48).ToList().FirstOrDefault();

                                if (rAttCard != null)
                                {
                                    DateTimeOnCardTime = Date.AddMinutes(Tools.TimeTrans.ConvertHhMmToMinutes(rAttCard.OnCardTime48));
                                    lsDateTime.Add(DateTimeOnCardTime.Value);
                                }
                            }

                            //請假時間
                            if (rsAbs.Count > 0)
                            {
                                var rAbs = rsAbs.OrderBy(p => p.DateTimeB).ToList().FirstOrDefault();

                                if (rAbs != null)
                                    lsDateTime.Add(rAbs.DateTimeB);
                            }

                            //判斷如果刷卡後時間超過彈性後時間則無彈性
                            bool GoIng = true;
                            if (bElasticity && DateTimeOnCardTime != null)
                                if (DateTimeA2 < DateTimeOnCardTime.Value)
                                    GoIng = false;

                            //如果有彈性...
                            if (GoIng)
                            {
                                //提前彈性
                                DateTime DateTimeY = DateTimeA.AddMinutes(-Convert.ToDouble(rRote.ElasticityBeforeMin));

                                if (lsDateTime.Count > 0)
                                {
                                    DateTimeX = lsDateTime.Min();

                                    //判斷此時間是否有比表訂時間早，有的話就以表訂時間為準
                                    //DateTimeA2 = DateTimeX < DateTimeA ? DateTimeA : DateTimeX;
                                    DateTimeA2 = DateTimeX < DateTimeY ? DateTimeY : DateTimeX;
                                }

                                //如果有請假並非全天 且 請假結束時間等於應出勤結束時間 則 應採用此筆請假開始時間 為彈性延後結束時間
                                var rsAbsAndRes = tlAttend.Where(p => p.Type == AttEndType.Abs || p.Type == AttEndType.Res).ToList();

                                //反向排序結束時間
                                rsAbsAndRes = rsAbsAndRes.OrderByDescending(p => p.DateTimeE).ToList();

                                //利用反向排序來找出真正的下班時間
                                for (int z = 0; z <= rsAbsAndRes.Count - 1; z++)
                                {
                                    var rAtt = rsAbsAndRes[z];

                                    //如果請假或休息時間 等於應出勤結束時間
                                    if (rAtt.DateTimeE == DateTimeD)
                                    {
                                        //將應出勤結束時間變成開始時間
                                        DateTimeD = DateTimeD < rAtt.DateTimeB ? DateTimeD : rAtt.DateTimeB;

                                        //並於tlAttend移除該筆資料
                                        tlAttend.Remove(rAtt);
                                    }
                                }

                                ts = DateTimeA2 - DateTimeA;
                                rAttEnd.ElasticityMin = Convert.ToInt32(ts.TotalMinutes);

                                DateTimeD = DateTimeD.AddMinutes(rAttEnd.ElasticityMin);
                                DateTimeA = DateTimeA2;
                            }
                        }
                    }
                }

                DateTimeX = DateTimeA;

                for (int z = 0; z <= tlAttend.Count - 1; z++)
                {
                    var rAtt = tlAttend[z];

                    rAtt.DateTimeB = rAtt.DateTimeB >= DateTimeD ? DateTimeD : rAtt.DateTimeB;

                    //開始或上班時間 小於 出勤或請假時間或休息時間
                    if (DateTimeX < rAtt.DateTimeB)
                    {
                        ts = rAtt.DateTimeB - DateTimeX;
                        if (rAtt.Type != AttEndType.Abs || z == 0)  //正常出勤，第一次進來一定算遲到
                            if (rAtt.Type == AttEndType.Res && z == 0)
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                            else if (rAtt.Type == AttEndType.Res)
                                rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                            else
                                rAttEnd.LatesMin += Convert.ToInt32(ts.TotalMinutes); //遲到       
                        else if (rAtt.Type == AttEndType.Abs)
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);    //早退
                    }

                    DateTimeX = DateTimeX >= rAtt.DateTimeE ? DateTimeX : rAtt.DateTimeE;

                    //如果出勤資料的結束時間大於出勤應下班時間就直接結束
                    if (DateTimeD <= rAtt.DateTimeE || z == tlAttend.Count - 1)
                    {
                        //如果最後一次進來再比較一次算出早退分鐘數
                        if (DateTimeX < DateTimeD)
                        {
                            List<DateTime> lsDateTime = new List<DateTime>();
                            foreach (var tl in tlAttend)
                            {
                                lsDateTime.Add(tl.DateTimeB);
                                lsDateTime.Add(tl.DateTimeE);            
                            }

                            DateTimeX = lsDateTime.Max();
                            ts = DateTimeD - DateTimeX;
                            rAttEnd.EarlierMin += Convert.ToInt32(ts.TotalMinutes);
                        }

                        break;
                    }
                }
            }

            return rAttEnd;
        }

        /// <summary>
        /// 計算出勤時數 20131007 by 志興
        /// </summary>
        /// <param name="iWorkHour">投入工時</param>
        /// <param name="rsAbs">請假資料</param>
        /// <param name="rsOt">加班資料</param>
        /// <returns>decimal</returns>
        public decimal CalAttHour(decimal iWorkHour, List<AbsTable> rsAbs, List<OtTable> rsOt)
        {
            decimal iHour = iWorkHour;

            decimal iAbs = 0;
            if (iWorkHour > 0)
                foreach (var rAbs in rsAbs)
                    iAbs += (rAbs.Unit == "小時" ? rAbs.Hour : (rAbs.Hour * iWorkHour));

            decimal iOt = 0;
            foreach (var rOt in rsOt)
                iOt += rOt.OtHour;

            iHour = iHour - iAbs + iOt;

            return iHour;
        }
    }
}