using JBHRIS.Api.Bll.Attendance;
using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.Attendance.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance.Entry;
using JBHRIS.Api.Service.Attendance.Normal;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.View;

namespace JBHRIS.Api.Service.Attendance
{
    public class TransCardService : ITransCardService
    {
        private IAttend_View_GetAttendRote _attend_View_GetAttend;
        //private IAttend_Normal_GetAttend _attend_Normal_GetAttend;
        //private IAttend_View_GetAttendRote _attend_View_GetAttendRote;
        private IAttendCardBll _attendCardBll;
        private ICardService _cardService;
        private IAttCardService _attCardService;
        private IAttendanceService _attendanceService;

        public TransCardService(IAttend_View_GetAttendRote attend_View_GetAttend,
            //IAttend_Normal_GetAttend attend_Normal_GetAttend,
            //IAttend_View_GetAttendRote attend_View_GetAttendRote,
            IAttendCardBll attendCardBll,
            ICardService cardService,
            IAttCardService attCardService,
            IAttendanceService attendanceService)
        {
            _attend_View_GetAttend = attend_View_GetAttend;
            //_attend_Normal_GetAttend = attend_Normal_GetAttend;
            //_attend_View_GetAttendRote = attend_View_GetAttendRote;
            _attendCardBll = attendCardBll;
            _cardService = cardService;
            _attCardService = attCardService;
            _attendanceService = attendanceService;
        }

        /// <summary>
        /// 刷卡轉出勤
        /// </summary>
        /// <param name="transCardEntry"></param>
        /// <param name="KeyMan"></param>
        /// <returns></returns>
        public ApiResult<string> TransCard(TransCardEntry transCardEntry, string KeyMan)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                //取得每日收卡範圍內的卡片資料
                List<AttendRangeCardDto> attendRangeCardDtos = GetAttendRangeCard(transCardEntry);

                //重跑刷卡轉出勤時，工號、歸屬日沒重複就新增出勤刷卡資料，重複就更新出勤刷卡資料
                AttendanceEntry attendanceEntry = new AttendanceEntry() { EmployeeList = transCardEntry.EmployeeList, DateBegin = transCardEntry.StartDate.AddDays(-1), DateEnd = transCardEntry.EndDate.AddDays(1) };
                List<AttendCardDto> getAttendCards = _attCardService.GetAttendCard(attendanceEntry);
                CalRepeatAttcardDto calRepeatAttcard = GetCalRepeatAttcard(attendRangeCardDtos, getAttendCards, KeyMan);
                ApiResult<string> apiResultSaveAttendCard = _attCardService.SaveAttendCard(calRepeatAttcard.NoRepeatAttcard);
                ApiResult<string> apiResultUpdateAttCard = _attCardService.UpdateAttCard(calRepeatAttcard.RepeatAttcard);

                //根據出勤資料判斷異常，更新異常資料欄位(遲到、早退、曠職)
                var empAttendRotes = _attend_View_GetAttend.GetAttRote(transCardEntry.EmployeeList, transCardEntry.StartDate, transCardEntry.EndDate);
                var getAttCardAbnormal = GetAttCardAbnormal(attendRangeCardDtos, empAttendRotes, KeyMan);
                ApiResult<string> apiResultUpdateAttend = _attendanceService.UpdateAttend(getAttCardAbnormal);

                if (!apiResultUpdateAttCard.State)
                {
                    apiResult.State = false;
                    apiResult.Message += apiResultUpdateAttCard.Message;
                }
                else if (!apiResultSaveAttendCard.State)
                {
                    apiResult.State = false;
                    apiResult.Message += apiResultSaveAttendCard.Message;
                }
                else if (!apiResultUpdateAttend.State)
                {
                    apiResult.State = false;
                    apiResult.Message += apiResultUpdateAttend.Message;
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得每日收卡範圍卡片資料
        /// </summary>
        /// <param name="transCardEntry"></param>
        /// <returns></returns>
        public List<AttendRangeCardDto> GetAttendRangeCard(TransCardEntry transCardEntry)
        {
            List<AttendRangeCardDto> attendRangeCardDtos = new List<AttendRangeCardDto>();

            var empAttendRoteHs = _attend_View_GetAttend.GetAttRoteH(transCardEntry.EmployeeList, transCardEntry.StartDate, transCardEntry.EndDate);
            List<AttendRangeEntryDto> attenndRangeEntryDtos = new List<AttendRangeEntryDto>();
            AttendanceEntry attendanceEntry = new AttendanceEntry() { EmployeeList = transCardEntry.EmployeeList, DateBegin = transCardEntry.StartDate.AddDays(-1), DateEnd = transCardEntry.EndDate.AddDays(1) };
            List<CardDto> cardDtos = _cardService.GetCard(attendanceEntry);
            foreach (var e in empAttendRoteHs)
            {
                attenndRangeEntryDtos.Add(new AttendRangeEntryDto { AttendDate = e.AttendDate, EmployeeID = e.EmployeeID, OffTime2 = e.RoteOffTime2 });
            }

            List<AttendRangeDto> attendRangeDtos = _attendCardBll.GetAttendCardRange(attenndRangeEntryDtos);
            attendRangeCardDtos.AddRange(_attendCardBll.GetAttCard(attendRangeDtos, cardDtos));

            return attendRangeCardDtos;
        }

        /// <summary>
        /// 判斷並取得重複和不重複的資料
        /// </summary>
        /// <param name="attendRangeCardDtos"></param>
        /// <param name="getAttendCards"></param>
        /// <param name="KeyMan"></param>
        /// <returns></returns>
        private CalRepeatAttcardDto GetCalRepeatAttcard(List<AttendRangeCardDto> attendRangeCardDtos, List<AttendCardDto> getAttendCards, string KeyMan)
        {
            List<AttCardDto> attCardDtosInsert = new List<AttCardDto>();
            List<AttCardDto> attCardDtosUpdate = new List<AttCardDto>();
            foreach (var attCardDto in attendRangeCardDtos)
            {
                var repeatAttCard = getAttendCards.Find(g => (g.EmployeeID == attCardDto.EmployeeID) && (g.PuchInDate == attCardDto.AttendDate));
                if (repeatAttCard == null)
                {
                    AttCardDto item = new AttCardDto()
                    {
                        Nobr = attCardDto.EmployeeID,
                        Adate = attCardDto.AttendDate,
                        T1 = attCardDto.AttendCardOnTime,
                        T2 = attCardDto.AttendCardOffTime,
                        Code = "",
                        Ser = 1,
                        KeyMan = KeyMan,
                        KeyDate = DateTime.Now,
                        Dd1 = "",
                        Dd2 = "",
                        Lost1 = false,
                        Lost2 = false,
                        Tt1 = "",
                        Tt2 = "",
                        Nomody = false
                    };
                    attCardDtosInsert.Add(item);
                }
                else
                {
                    AttCardDto item = new AttCardDto()
                    {
                        Nobr = repeatAttCard.EmployeeID,
                        Adate = repeatAttCard.PuchInDate,
                        T1 = attCardDto.AttendCardOnTime,
                        T2 = attCardDto.AttendCardOffTime,
                        Code = repeatAttCard.Code,
                        Ser = repeatAttCard.Ser,
                        KeyMan = KeyMan,
                        KeyDate = DateTime.Now,
                        Dd1 = repeatAttCard.Dd1,
                        Dd2 = repeatAttCard.Dd2,
                        Lost1 = repeatAttCard.Lost1,
                        Lost2 = repeatAttCard.Lost2,
                        Tt1 = repeatAttCard.Tt1,
                        Tt2 = repeatAttCard.Tt2,
                        Nomody = repeatAttCard.Nomody,
                    };
                    attCardDtosUpdate.Add(item);
                }
            }
            return new CalRepeatAttcardDto() { RepeatAttcard = attCardDtosUpdate, NoRepeatAttcard = attCardDtosInsert };
        }


        /// <summary>
        /// 根據出勤資料，取得判斷異常後的資料(遲到、早退、曠職)
        /// </summary>
        /// <param name="attendRangeCardDtos"></param>
        /// <param name="empAttendRoteHs"></param>
        /// <param name="empAttendRotes">既有出勤資料</param>
        /// <param name="KeyMan"></param>
        /// <returns></returns>
        private List<AttendDto> GetAttCardAbnormal(List<AttendRangeCardDto> attendRangeCardDtos,  List<AttRoteViewDto> empAttendRotes, string KeyMan)
        {
            List<AttendDto> attendanceDtos = new List<AttendDto>();

            foreach (var attCardDto in attendRangeCardDtos)
            {
                var repeatAttend = empAttendRotes.Find(g => (g.EmployeeID == attCardDto.EmployeeID) && (g.AttendDate == attCardDto.AttendDate));
                DateTime? AttendCardOnTime = null;
                DateTime? AttendCardOffTime = null;
                decimal LateMins = 0;
                decimal EMins = 0;
                bool Abs = false;
                if (repeatAttend.Rote.OnTime == null && repeatAttend.Rote.OffTime == null && repeatAttend.Rote.OnTime.Trim().Length > 0 && repeatAttend.Rote.OffTime.Trim().Length > 0)
                {
                    //ATTEND.ROTE.ONTIME & OFFTIME如果是空白，不判斷異常，ex:例假日或休假日
                }
                else if (repeatAttend.Basetts.Card == "Y")
                {
                    //BASETTS.CARD=="Y"才要判異常
                    Abs = _attendCardBll.IsAbsenteeism(AttendCardOnTime, AttendCardOffTime);
                    if (repeatAttend.Basetts.Noter)
                    {
                        //BASETTS.NOTER == True 不判斷遲到早退，但是會顯示曠職
                    }
                    else
                    {
                        if (attCardDto.AttendCardOnTime != null)
                        {
                            AttendCardOnTime = attCardDto.AttendDate.AddTime(attCardDto.AttendCardOnTime);
                        }
                        else if (attCardDto.AttendCardOffTime != null)
                        {
                            AttendCardOnTime = attCardDto.AttendDate.AddTime(attCardDto.AttendCardOffTime);
                        }

                        if (attCardDto.AttendCardOffTime != null)
                        {
                            AttendCardOffTime = attCardDto.AttendDate.AddTime(attCardDto.AttendCardOffTime);
                        }
                        else if (attCardDto.AttendCardOnTime != null)
                        {
                            AttendCardOffTime = attCardDto.AttendDate.AddTime(attCardDto.AttendCardOnTime);
                        }

                        LateMins = _attendCardBll.CalLateMin(repeatAttend.RoteOnTime, repeatAttend.RoteOffTime, repeatAttend.RoteRestTime, AttendCardOnTime);
                        EMins = _attendCardBll.CalEarMin(repeatAttend.RoteOnTime, repeatAttend.RoteOffTime, repeatAttend.RoteRestTime, AttendCardOffTime);
                    }
                }

                if (repeatAttend == null)
                {

                }
                else
                {
                    AttendDto attendDto = new AttendDto()
                    {
                        Nobr = repeatAttend.Attend.Nobr,
                        Adate = repeatAttend.Attend.Adate,
                        Rote = repeatAttend.Attend.Rote,
                        KeyMan = KeyMan,
                        KeyDate = DateTime.Now,
                        LateMins = LateMins,
                        EMins = EMins,
                        Abs = Abs,
                        AdjCode = repeatAttend.Attend.AdjCode,
                        CantAdj = repeatAttend.Attend.CantAdj,
                        Ser = repeatAttend.Attend.Ser,
                        NightHrs = repeatAttend.Attend.NightHrs,
                        Foodamt = repeatAttend.Attend.Foodamt,
                        Foodsalcd = repeatAttend.Attend.Foodsalcd,
                        Forget = repeatAttend.Attend.Forget,
                        AttHrs = repeatAttend.Attend.AttHrs,
                        Nigamt = repeatAttend.Attend.Nigamt,
                        Specamt = repeatAttend.Attend.Specamt,
                        Specsalcd = repeatAttend.Attend.Specsalcd,
                        Stationamt = repeatAttend.Attend.Stationamt,
                        EarlyMins = repeatAttend.Attend.EarlyMins,
                        DelayMins = repeatAttend.Attend.DelayMins,
                        RelHrs = repeatAttend.Attend.RelHrs,
                        RoteH = repeatAttend.Attend.RoteH
                    };
                    attendanceDtos.Add(attendDto);
                }
            }
            return attendanceDtos;
        }

    }
}
