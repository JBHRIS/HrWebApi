using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dal.JBHR.Repository;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class ShiftChange_Normal_CheckDayShiftChange : IShiftChange_Normal_CheckDayShiftChange
    {
        private IUnitOfWork _unitOfWork;
        public ShiftChange_Normal_CheckDayShiftChange(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// 檢查調班資料是否重複
        /// </summary>
        /// <param name="dayShiftChangeApplyDto"></param>
        /// <returns></returns>
        public ApiResult<string> CheckDayShiftChange(DayShiftChangeApplyDto dayShiftChangeApplyDto)
        {
            var CheckDayShiftChanges = from a in _unitOfWork.Repository<Basetts>().Reads()
                                   join b in _unitOfWork.Repository<Rote>().Reads() on a.Rotet equals b.Rote1
                                   where dayShiftChangeApplyDto.EmployeeId == a.Nobr && dayShiftChangeApplyDto.ShiftDate == a.Adate
                                   select new DayShiftChangeApplyDto
                                   {
                                       EmployeeId = a.Nobr,
                                       ShiftDate = a.Adate,
                                       AfterShiftCode = a.Rotet
                                   };

            ApiResult<string> CheckDayShiftChangeResult = new ApiResult<string>();

            //判斷是否有值
            if (CheckDayShiftChanges.Count() > 0)
            {
                //若有則回傳 False
                CheckDayShiftChangeResult.State = false;
            }
            else
            {
                //若無則回傳 True 走 Create
                CheckDayShiftChangeResult.State = true;
            }

            return CheckDayShiftChangeResult;
        }
    }
}
