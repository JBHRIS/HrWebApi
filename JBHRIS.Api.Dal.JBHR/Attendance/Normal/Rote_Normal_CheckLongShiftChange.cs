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
    public class Rote_Normal_CheckLongShiftChange : IRote_Normal_CheckLongShiftChange
    {
        private IUnitOfWork _unitOfWork;
        public Rote_Normal_CheckLongShiftChange(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 檢查調班資料是否重複
        /// </summary>
        /// <param name="longShiftChangeApplyDto"></param>
        /// <returns></returns>
        public ApiResult<string> CheckLongShiftChange(LongShiftChangeApplyDto longShiftChangeApplyDto)
        {
            var CheckLongShiftChanges = from a in _unitOfWork.Repository<Basetts>().Reads()
                                   join b in _unitOfWork.Repository<Rote>().Reads() on a.Rotet equals b.Rote1
                                   where longShiftChangeApplyDto.EmployeeId == a.Nobr && longShiftChangeApplyDto.ChangeDate <= a.Adate
                                   select new LongShiftChangeApplyDto
                                   {
                                       EmployeeId = a.Nobr,
                                       ChangeDate = a.Adate,
                                       AfterShiftGroupCode = a.Rotet
                                   };



            ApiResult<string> CheckLongShiftChangeResult = new ApiResult<string>();

            //判斷是否有值
            if (CheckLongShiftChanges.Count() > 0)
            {
                //若有則回傳 False
                CheckLongShiftChangeResult.State = false;
            }
            else
            {
                //若無則回傳 True 走 Create
                CheckLongShiftChangeResult.State = true;
            }

            return CheckLongShiftChangeResult;
        }
    }
}
