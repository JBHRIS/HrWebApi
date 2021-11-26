using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Token.Vdb
{
    public class AdSigninVdb
    {
    }

    public class AdSigninConditions : DataConditions
    {
        public string AdName { get; set; }
    }

    public class AdSigninApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
        }
        public Result result { get; set; }
    }

    public class AdSigninRow : StandardDataRow
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
