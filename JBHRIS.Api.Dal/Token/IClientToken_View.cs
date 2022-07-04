using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Dto.Token.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Token
{
    public interface IClientToken_View
    {
        List<ApiClientRolesDto> GetClentRoleApi(string ClientID);
    }
}
