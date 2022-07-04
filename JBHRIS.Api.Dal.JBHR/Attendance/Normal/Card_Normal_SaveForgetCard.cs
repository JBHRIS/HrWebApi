using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Dto.Attendance.Entry;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto.Files;
using JBHRIS.Api.Dal.JBHR;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Card_Normal_SaveForgetCard : ICard_Normal_SaveForgetCard
    {
        private IUnitOfWork _unitOfWork;
        public Card_Normal_SaveForgetCard(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> SaveForgetCard(ForgetCardApplyDto forgetCardApplyDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<Card>();
                var cardlosdRepo = _unitOfWork.Repository<Cardlosd>();
                Card forgetCardImport = new Card
                {
                    Code = forgetCardApplyDto.Position.Trim(),//card machine name
                    Nobr = forgetCardApplyDto.EmployeeId.Trim(),
                    Adate = DateTime.Parse(forgetCardApplyDto.CardDate.ToString().Trim()),
                    Ontime = forgetCardApplyDto.CardTime.Trim(),
                    Cardno = forgetCardApplyDto.Cardno,
                    KeyDate = DateTime.Now,
                    KeyMan = forgetCardApplyDto.KeyMan,
                    NotTran = forgetCardApplyDto.NotTran,
                    Days = 0,
                    Reason = forgetCardApplyDto.Reason,//relate to cardlos
                    Los = false,
                    Ipadd = forgetCardApplyDto.IpAddress,
                    Meno = forgetCardApplyDto.Remark,
                    Serno = forgetCardApplyDto.Serno,
                };

                var reason = cardlosdRepo.Read(p => p.Code == forgetCardImport.Reason);
                if (reason != null && reason.Att)
                    forgetCardImport.Los = true;

                Repo.Create(forgetCardImport);

                Repo.SaveChanges();

                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.Message;
                apiResult.StackTrace = ex.StackTrace;
            }
            //apiResult.Result
            return apiResult;
        }

    }
}