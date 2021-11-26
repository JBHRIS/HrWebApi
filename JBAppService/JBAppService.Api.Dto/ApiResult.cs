using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto
{
    public class ApiResult<T>
    {
        public bool State { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public T Result { get; set; }
    }



    public class TokenResultDto
    {

        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }


    public class UserDto
    {
        public string UserId { get; set; }

        public string Password { get; set; }
    }
}
