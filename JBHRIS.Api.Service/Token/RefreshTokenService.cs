using JBHRIS.Api.Dal.Token;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Login;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Token
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private IRefreshToken_View _refreshToken_View;

        public RefreshTokenService(IRefreshToken_View refreshToken_View
            )
        {
            _refreshToken_View = refreshToken_View;
        }

        public ApiResult<RefreshTokenDto> InsertRefreshToken(string UserId, string refreshToken)
        {
            return _refreshToken_View.InsertRefreshToken(UserId, refreshToken);
        }

        public ApiResult<RefreshTokenDto> UpdateRefreshToken(string refreshToken)
        {
            return _refreshToken_View.UpdateRefreshToken(refreshToken);
        }
    }
}
