using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Token.Vdb
{
    public class ClientGetTokenVdb
    {
    }

    public class ClientGetTokenConditions : DataConditions
    {
        public string ClientId { get; set; }
    }



    public class ClientGetTokenApiRow : StandardDataBaseApiRow
    {
        public ResultApiRow result { get; set; }
        public class ResultApiRow
        {
            public string accessToken { get; set; }
            public string refreshToken { get; set; }
        }
    }

    public class ClientGetTokenRow : StandardDataRow
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
