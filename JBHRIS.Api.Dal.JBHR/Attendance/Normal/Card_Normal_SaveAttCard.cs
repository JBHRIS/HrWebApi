using JBHRIS.Api.Dal.Attendance.Normal;
using JBHRIS.Api.Dal.JBHR.Repository;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Attendance;
using JBHRIS.Api.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Dal.JBHR.Attendance.Normal
{
    public class Card_Normal_SaveAttCard : ICard_Normal_SaveAttCard
    {
        private IUnitOfWork _unitOfWork;
        public Card_Normal_SaveAttCard(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ApiResult<string> SaveAttendCard(List<AttCardDto> attCardDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                var Repo = _unitOfWork.Repository<Attcard>();
                foreach (var item in attCardDtos.Split(2100))
                {
                    item.ForEach((AttCardDto attCardDto) =>
                    {
                        Attcard attcard = new Attcard()
                        {
                            Nobr = attCardDto.Nobr,
                            Adate = attCardDto.Adate,
                            T1 = attCardDto.T1,
                            T2 = attCardDto.T2,
                            Code = attCardDto.Code,
                            Ser = attCardDto.Ser,
                            KeyMan = attCardDto.KeyMan,
                            KeyDate = attCardDto.KeyDate,
                            Dd1 = attCardDto.Dd1,
                            Dd2 = attCardDto.Dd2,
                            Lost1 = attCardDto.Lost1,
                            Lost2 = attCardDto.Lost2,
                            Tt1 = attCardDto.Tt1,
                            Tt2 = attCardDto.Tt2,
                            Nomody = attCardDto.Nomody
                        };
                        Repo.Create(attcard);
                    });
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
