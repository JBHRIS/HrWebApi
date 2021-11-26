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
    public class Card_Normal_CheckForgetCard : ICard_Normal_CheckForgetCard
    {
        private IUnitOfWork _unitOfWork;
        public Card_Normal_CheckForgetCard(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 檢查簽核資料是否重複
        /// </summary>
        /// <param name="forgetCardApplyDto"></param>
        /// <returns></returns>
        public ApiResult<string> CheckForgetCard(ForgetCardApplyDto forgetCardApplyDto)
        {
            var CheckForgetCards = from a in _unitOfWork.Repository<Card>().Reads()
                                   join b in _unitOfWork.Repository<Cardlosd>().Reads() on a.Reason equals b.Code
                                   where forgetCardApplyDto.EmployeeId == a.Nobr && forgetCardApplyDto.CardDate == a.Adate
                                   select new ForgetCardApplyDto
                                   {
                                       EmployeeId = a.Nobr,
                                       CardDate = a.Adate,
                                       CardTime = a.Ontime,
                                       Reason = b.Descr
                                   };

            ApiResult<string> CheckForgetCardResult = new ApiResult<string>();

            //判斷是否有值
            if (CheckForgetCards.Count() > 0)
            {
                //若有則回傳 False
                CheckForgetCardResult.State = false;
            }
            else
            {
                //若無則回傳 True 走 Create
                CheckForgetCardResult.State = true;
            }

            return CheckForgetCardResult;
        }

    }
}
