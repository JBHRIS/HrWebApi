using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Menu.Vdb
{
    public  class DeleteMenuVdb
    {
    }

    public class DeleteMenuConditions : DataConditions
    { 
    }
    
    public class DeleteMenuApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }

    public class DeleteMenuRow : StandardDataRow
    {
        public bool Result { get; set; }
    }
}
