using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.Token.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Token
{
    public interface IClientTokenService
    {
        string[] GetClentRoleApi(string ClientID);
    }
}
