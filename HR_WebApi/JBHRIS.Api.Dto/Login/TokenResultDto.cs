using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dto.Login
{
    public class TokenResultDto
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }
}
