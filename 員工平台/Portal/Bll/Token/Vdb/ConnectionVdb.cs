using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Token.Vdb
{
    public class ConnectionVdb
    {
    }

    public class ConnectionConditions : DataConditions
    {
        public string DbName { get; set; }
    }

    public class ConnectionApiRow : StandardDataBaseApiRow
    {
        
    }

    public class ConnectionRow : StandardDataRow
    {

    }
}
