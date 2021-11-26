
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{
    public interface IAuthorizeHandler
    {
        bool Accountloggin(string Account, string Password);
    }
}
 