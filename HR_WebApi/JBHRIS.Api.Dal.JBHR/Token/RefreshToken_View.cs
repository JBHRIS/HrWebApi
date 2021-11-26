using JBHRIS.Api.Dal.Token;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace JBHRIS.Api.Dal.JBHR.Token
{
    public class RefreshToken_View : IRefreshToken_View
    {
        private JBHRContext _context;
        private IConfiguration _configuration;
        private ApiResult<RefreshTokenDto> statusResultDto = new ApiResult<RefreshTokenDto>()
        {
            State = false
        };

        public RefreshToken_View(JBHRContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public ApiResult<RefreshTokenDto> InsertRefreshToken(string UserId,string refreshToken)
        {
            _context.RefreshToken.Add(new RefreshToken()
            {
                RefreshToken1 = refreshToken,
                Nobr = UserId,
                DueDate = DateTime.Now.AddDays(1),
                Valid = "",
                Lock = 0,
                UpdateTime = DateTime.Now
            });
            _context.SaveChanges();
            statusResultDto.State = true;
            return statusResultDto;
        }

        public ApiResult<RefreshTokenDto> UpdateRefreshToken(string refreshToken)
        {
            var refdata = from r in _context.RefreshToken
                          where r.RefreshToken1 == refreshToken &&
                          DateTime.Now < r.DueDate &&
                          r.Lock == 0
                          select r;

            RefreshToken entity = refdata.FirstOrDefault(item => item.RefreshToken1 == refreshToken);
            statusResultDto.State = false;
            if (entity != null)
            {
                RefreshTokenDto refreshTokenDto = new RefreshTokenDto()
                {
                    DueDate = entity.DueDate,
                    Lock = entity.Lock,
                    Nobr = entity.Nobr,
                    RefreshToken1 = entity.RefreshToken1,
                    UpdateTime = entity.UpdateTime,
                    Valid = entity.Valid
                };
                entity.UpdateTime = DateTime.Now;
                if(entity.DueDate > DateTime.Now)
                {
                    var e = entity.DueDate.Subtract(DateTime.Now);
                    if(e.TotalMinutes <= Convert.ToInt32(_configuration["JWT:expires"]))
                    {
                        entity.DueDate = entity.DueDate.AddDays(1);
                    }
                }
                _context.SaveChanges();

                statusResultDto.State = true;
                statusResultDto.Result = refreshTokenDto;
            }

            return statusResultDto;
        }
    }
}
