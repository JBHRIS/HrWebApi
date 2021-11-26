using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    public class FlowImageByidProcessVdb
    {
    }
    public class FlowImageByidProcessConditions : DataConditions
    {
        public int idProcess { get; set; }
    }
    public class FlowImageByidProcessApiRow : StandardDataBaseApiRow
    {
        public string result { get; set; }
    }
    public class FlowImageByidProcessRow
    {
        public string result { get; set; }
    }
   
}
