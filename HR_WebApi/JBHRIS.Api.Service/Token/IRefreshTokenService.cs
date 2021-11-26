using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Token
{
    public interface IRefreshTokenService
    {
        ApiResult<RefreshTokenDto> InsertRefreshToken(string UserId, string refreshToken);
        ApiResult<RefreshTokenDto> UpdateRefreshToken(string refreshToken);
    }
}
