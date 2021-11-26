using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Att
{
    public class AttendanceStateController
    {
        /*
         * 設定對象及日期
         * 取得或是更新該天出勤狀態的狀態
         * 
         * 
         * */
        public static Repo.AttendanceInfoRepo AttendanceInfoRepo;
        public static Att.TransformCard TransformCard = new TransformCard();
        public static Att.CheckAttendanceError CheckAttendanceError = new CheckAttendanceError();
        public static Repo.AttendCardRepo AttendCardRepo;
        public static Repo.AttendRepo AttendRepo;
        public static string CreateMan = "";
        public List<Dto.AttendanceInfoDto> GetAttendanceInfoDtoList(Dto.AttendanceInfoCondition condition)
        {
            var data = AttendanceInfoRepo.GetDataByCondition(condition);
            if (condition.RefreshStatus)//需要更新,才要去判斷
            {
                foreach (var it in data)
                {
                    TransformCard.TransCard(it);
                    CheckAttendanceError.CheckError(it);
                    string msg = "";
                    if (it.NeedUpdate)
                        UpdateAttendanceInfo(it, out msg);
                }
            }
            return data;
        }
        public bool UpdateAttendanceInfo(Dto.AttendanceInfoDto Attend, out string ErrorMsg)
        {
            try
            {
                ErrorMsg = "";
                var att = AttendRepo.GetInstanceByEmployeeDate(Attend.EmployeeID, Attend.AttendanceDate);
                //更新異常狀態
                att.LateMinutes = Attend.LateMinutes;
                att.EarilyMinutes = Attend.EarilyMinutes;
                att.Absenteeism = Attend.Absenteeism;
                att.CreateMan = CreateMan;
                if (!AttendRepo.Update(att, out ErrorMsg))
                    return false;
                var ac = AttendCardRepo.GetInstanceByEmployeeDate(Attend.EmployeeID, Attend.AttendanceDate);
                foreach (var it in ac)
                {
                    if (!it.CantModify)
                        if (!AttendCardRepo.Delete(it, out ErrorMsg))
                            return false;
                }
                foreach (var it in Attend.CardTimes)
                {
                    //Dto.AttcardDto acDto = new Dto.AttcardDto();
                    //acDto.AttendanceDate = Attend.AttendanceDate;
                    //acDto.BeginTime = it.BeginTime;
                    //acDto.CantModify = false;
                    //acDto.EmployeeID = Attend.EmployeeID;
                    //acDto.EndTime = it.EndTime;
                    it.CreateMan = CreateMan;
                    AttendCardRepo.Insert(it, out ErrorMsg);
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
                return false;
            }
        }
    }
}
