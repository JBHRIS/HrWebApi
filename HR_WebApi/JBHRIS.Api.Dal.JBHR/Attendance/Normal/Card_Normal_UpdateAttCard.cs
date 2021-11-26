using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Card_Normal_UpdateAttCard : ICard_Normal_UpdateAttCard
    {
        private IUnitOfWork _unitOfWork;

        public Card_Normal_UpdateAttCard(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ApiResult<string> UpdateAttCard(List<AttCardDto> attCardDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<Attcard>();

                foreach (var attCardDto in attCardDtos)
                {
                    var data = Repo.Reads().Where(x => x.Nobr == attCardDto.Nobr && x.Adate == attCardDto.Adate).FirstOrDefault();
                    Repo.Delete(data);
                    var newData = new Attcard();
                    newData.Nobr = attCardDto.Nobr;
                    newData.Adate = attCardDto.Adate;
                    newData.T1 = attCardDto.T1;
                    newData.T2 = attCardDto.T2;
                    newData.Code = attCardDto.Code;
                    newData.Ser = attCardDto.Ser;
                    newData.KeyMan = attCardDto.KeyMan;
                    newData.KeyDate = attCardDto.KeyDate;
                    newData.Dd1 = attCardDto.Dd1;
                    newData.Dd2 = attCardDto.Dd2;
                    newData.Lost1 = attCardDto.Lost1;
                    newData.Lost2 = attCardDto.Lost2;
                    newData.Tt1 = attCardDto.Tt1;
                    newData.Tt2 = attCardDto.Tt2;
                    newData.Nomody = attCardDto.Nomody;
                    Repo.Create(newData);
                }
                Repo.SaveChanges();
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }

            return apiResult;
        }

    }
}
