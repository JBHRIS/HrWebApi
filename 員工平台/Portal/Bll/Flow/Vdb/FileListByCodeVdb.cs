using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    public  class DeleteByAutoKeyVdb
    {
    }

    public class DeleteByAutoKeyConditions : DataConditions
    { 
    }
    
    public class DeleteByAutoKeyApiRow : StandardDataBaseApiRow
    {
    }

    public class DeleteByAutoKeyRow
    {
        public bool Result { get; set; }
    }
}
