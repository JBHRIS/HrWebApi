using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.Attendance.Entry;

namespace JBHRIS.Api.Bll.Attendance
{
    public class AttendCardBll : IAttendCardBll
    {
        /// <summary>
        /// 取得當日收卡時間範圍
        /// </summary>
        /// <param name="attenndRangeEntryDtos"></param>
        /// <returns></returns>
        public List<AttendRangeDto> GetAttendCardRange(List<AttendRangeEntryDto> attenndRangeEntryDtos)
        {
            List<AttendRangeDto> attenndRangeDtos = new List<AttendRangeDto>();
            foreach (var a in attenndRangeEntryDtos)
            {

                DateTime? GetCardOnTime = null;
                DateTime? GetCardOffTime = null;

                if (a.OffTime2 != null)
                {
                    GetCardOnTime = a.AttendDate.AddTime(a.OffTime2);
                    GetCardOffTime = a.AttendDate.AddDays(1).AddTime(a.OffTime2);
                }

                AttendRangeDto attenndRangeDto = new AttendRangeDto()
                {
                    EmployeeID = a.EmployeeID,
                    AttendDate = a.AttendDate,
                    GetCardOnTime = GetCardOnTime,
                    GetCardOffTime = GetCardOffTime
                };

                attenndRangeDtos.Add(attenndRangeDto);
            }

            return attenndRangeDtos;
        }

        /// <summary>
        /// 取得當日刷卡資料
        /// </summary>
        /// <param name="attenndRangeDtos"></param>
        /// <param name="cardDtos"></param>
        /// <returns></returns>
        public List<AttendRangeCardDto> GetAttCard(List<AttendRangeDto> attenndRangeDtos, List<CardDto> cardDtos)
        {
            List<AttendRangeCardDto> attendRangeCardDtos = new List<AttendRangeCardDto>();

            foreach (var a in attenndRangeDtos)
            {
                List<CardDto> cards = cardDtos.Where(c => a.EmployeeID == c.EmployeeID &&
                                                          a.GetCardOffTime >= c.PuchInDate.AddTime(c.PuchInTime) &&
                                                          a.GetCardOnTime <= c.PuchInDate.AddTime(c.PuchInTime)
                                                    ).OrderBy(p => p.PuchInDate.AddTime(p.PuchInTime)
                                                    ).ToList();
                string AttendCardOnTime = null;
                string AttendCardOffTime = null;
                if (cards.Count > 0)
                {
                    var firstCard = cards[0];
                    var atlastCard = cards[cards.Count() - 1];
                    AttendCardOnTime = (firstCard.PuchInDate.AddTime(firstCard.PuchInTime)).TimeStringBy48HR(a.AttendDate);
                    AttendCardOffTime = (atlastCard.PuchInDate.AddTime(atlastCard.PuchInTime)).TimeStringBy48HR(a.AttendDate);
                }

                AttendRangeCardDto attendRangeCardDto = new AttendRangeCardDto()
                {
                    EmployeeID = a.EmployeeID,
                    AttendDate = a.AttendDate,
                    GetCardOnTime = a.GetCardOnTime,
                    GetCardOffTime = a.GetCardOffTime,
                    AttendCardOnTime = AttendCardOnTime,
                    AttendCardOffTime = AttendCardOffTime,
                    Cards = cards
                };
                attendRangeCardDtos.Add(attendRangeCardDto);
            }


            return attendRangeCardDtos;
        }

        /// <summary>
        /// 計算遲到分鐘數
        /// </summary>
        /// <param name="roteOnTime"></param>
        /// <param name="roteOffTime"></param>
        /// <param name="roteRestList"></param>
        /// <param name="cardOnTime"></param>
        /// <returns></returns>
        public decimal CalLateMin(DateTime roteOnTime, DateTime roteOffTime, List<Tuple<DateTime, DateTime>> roteRestList, DateTime? cardOnTime)
        {
            decimal LateMin = 0;
            if (cardOnTime != null && cardOnTime > roteOnTime)
            {
                List<Tuple<DateTime, DateTime>> _workTimeList = new List<Tuple<DateTime, DateTime>>();
                _workTimeList.Add(new Tuple<DateTime, DateTime>(roteOnTime, roteOffTime));
                var getRealWorkTimes = JBHRIS.Api.Tools.DataTransform.GetAbsenteeismList(_workTimeList, roteRestList);//扣除休息時段

                Tuple<DateTime, DateTime> cardStartRange = new Tuple<DateTime, DateTime>(roteOnTime, (DateTime)cardOnTime);

                List<Tuple<DateTime, DateTime>> repeatTimeList = new List<Tuple<DateTime, DateTime>>();
                foreach (var relWork in getRealWorkTimes)
                {
                    var repeatTime = JBHRIS.Api.Tools.DataTransform.RepeatTimePeriod(relWork, cardStartRange);
                    if (repeatTime != null)
                    {
                        repeatTimeList.Add(repeatTime);
                    }
                }

                foreach (var rep in repeatTimeList)
                {
                    LateMin += Convert.ToDecimal((rep.Item2 - rep.Item1).TotalMinutes);
                }
            }

            return LateMin;
        }

        /// <summary>
        /// 計算早退分鐘數
        /// </summary>
        /// <param name="roteOnTime"></param>
        /// <param name="roteOffTime"></param>
        /// <param name="roteRestList"></param>
        /// <param name="cardOffTime"></param>
        /// <returns></returns>
        public decimal CalEarMin(DateTime roteOnTime, DateTime roteOffTime, List<Tuple<DateTime, DateTime>> roteRestList, DateTime? cardOffTime)
        {
            decimal EarMin = 0;
            if (cardOffTime != null && roteOffTime > cardOffTime)
            {
                List<Tuple<DateTime, DateTime>> _workTimeList = new List<Tuple<DateTime, DateTime>>();
                _workTimeList.Add(new Tuple<DateTime, DateTime>(roteOnTime, roteOffTime));
                var getRealWorkTimes = JBHRIS.Api.Tools.DataTransform.GetAbsenteeismList(_workTimeList, roteRestList);//扣除休息時段

                Tuple<DateTime, DateTime> cardEndRange = new Tuple<DateTime, DateTime>((DateTime)cardOffTime, roteOffTime);

                List<Tuple<DateTime, DateTime>> repeatTimeList = new List<Tuple<DateTime, DateTime>>();
                foreach (var relWork in getRealWorkTimes)
                {
                    var repeatTime = JBHRIS.Api.Tools.DataTransform.RepeatTimePeriod(relWork, cardEndRange);
                    if (repeatTime != null)
                    {
                        repeatTimeList.Add(repeatTime);
                    }
                }

                foreach (var rep in repeatTimeList)
                {
                    EarMin += Convert.ToDecimal((rep.Item2 - rep.Item1).TotalMinutes);
                }
            }

            return EarMin;
        }

        /// <summary>
        /// 判斷曠職
        /// </summary>
        public bool IsAbsenteeism(DateTime? cardOnTime, DateTime? cardOffTime)
        {
            if (cardOnTime == null && cardOffTime == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
