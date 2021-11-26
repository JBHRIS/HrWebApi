using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dal.Token;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Dto.Token.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.Api.Service.Token
{
    public class ClientTokenService : IClientTokenService
    {
        IClientToken_View _clientToken_View;
        public ClientTokenService(IClientToken_View clientToken_View) 
        {
            _clientToken_View = clientToken_View;
        }

        public string[] GetClentRoleApi(string ClientID)
        {
            List<string> Roles = new List<string>();
            List<ApiClientRolesDto> apiClientRolesDtos = _clientToken_View.GetClentRoleApi(ClientID);
            var isAdminRole = apiClientRolesDtos.Where(p => p.IsAdminRole == true).FirstOrDefault();
            if (isAdminRole != null)
            {
                Roles.Add("Admin");
            }
            else
            {
                 apiClientRolesDtos.ForEach(p =>
                {
                    if (!string.IsNullOrEmpty(p.ApiVoidCode) && p.ClientId == ClientID)
                    {
                        Roles.Add(p.ApiVoidCode);
                    }
                });
            }
            return Roles.ToArray();
        }
    }
}
