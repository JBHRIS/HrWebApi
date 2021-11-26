using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dal.Mail.View;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Mail.View
{
    public class Mailqueue_View_GetMailqueue : IMailqueue_View_GetMailqueue
    {
        private IUnitOfWork _unitOfWork;
        public Mailqueue_View_GetMailqueue(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> InsertMailqueue(MailqueueDto mailqueueDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<Mailqueue>();
                Mailqueue mailqueue = new Mailqueue
                {
                     Guid = mailqueueDto.Guid,
                     FromAddr = mailqueueDto.FromAddr,
                     FromName = mailqueueDto.FromName,
                     ToAddr = mailqueueDto.ToAddr,
                     ToName = mailqueueDto.ToName,
                     Subject = mailqueueDto.Subject,
                     Body = mailqueueDto.Body,
                     Retry = mailqueueDto.Retry,
                     Success = mailqueueDto.Success,
                     Suspend = mailqueueDto.Suspend,
                     FreezeTime = mailqueueDto.FreezeTime,
                     KeyDate = mailqueueDto.KeyDate,
                     KeyMan = mailqueueDto.KeyMan,
                     Note = mailqueueDto.Note,
                     Note1 = mailqueueDto.Note1,
                     Note2 = mailqueueDto.Note2,
                     Note3 = mailqueueDto.Note3,
                     Note4 = mailqueueDto.Note4,
                     Note5 = mailqueueDto.Note5,
                };
                Repo.Create(mailqueue);
                Repo.SaveChanges();
                apiResult.State = true;
            }
            catch(Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        public ApiResult<string> UpdateMailqueue(MailqueueDto mailqueueDto)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<Mailqueue>();
                var Data = Repo.Read(p => p.Guid == mailqueueDto.Guid);
                if (Data != null)
                {
                    Data.FromAddr = mailqueueDto.FromAddr;
                    Data.FromName = mailqueueDto.FromName;
                    Data.ToAddr = mailqueueDto.ToAddr;
                    Data.ToName = mailqueueDto.ToName;
                    Data.Subject = mailqueueDto.Subject;
                    Data.Body = mailqueueDto.Body;
                    Data.Retry = mailqueueDto.Retry;
                    Data.Success = mailqueueDto.Success;
                    Data.Suspend = mailqueueDto.Suspend;
                    Data.FreezeTime = mailqueueDto.FreezeTime;
                    Data.KeyDate = mailqueueDto.KeyDate;
                    Data.KeyMan = mailqueueDto.KeyMan;
                    Data.Note = mailqueueDto.Note;
                    Data.Note1 = mailqueueDto.Note1;
                    Data.Note2 = mailqueueDto.Note2;
                    Data.Note3 = mailqueueDto.Note3;
                    Data.Note4 = mailqueueDto.Note4;
                    Data.Note5 = mailqueueDto.Note5;
                    Repo.Update(Data);
                    Repo.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }
    }
}
