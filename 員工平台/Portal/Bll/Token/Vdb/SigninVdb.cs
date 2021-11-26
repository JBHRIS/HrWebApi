using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Token.Vdb
{
    public class SigninVdb
    {
    }

    public class SigninConditions : DataConditions
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }

    public class RefreshTokenConditions : DataConditions
    {
        public string refreshToken { get; set; }

        public RefreshTokenConditions()
        { 
            
        }
    }


    public class SigninApiRow : StandardDataBaseApiRow
    {
        public ResultApiRow result { get; set; }
        public class ResultApiRow
        {
            public string accessToken { get; set; }
            public string refreshToken { get; set; }
        }
    }

    public class SigninRow : StandardDataRow
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
