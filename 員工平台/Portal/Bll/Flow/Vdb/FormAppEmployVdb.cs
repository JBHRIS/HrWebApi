using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class FormAppEmployVdb
    {
    }
    public class FormAppEmployConditions : DataConditions
    {
    }
    public class FormAppEmployApiRow : StandardDataBaseApiRow
    {
    }
    public class FormAppEmployRow
    {

        public DateTime ADate { get; set; }
        public string EarlyTime { get; set; }
        public string LateTime { get; set; }
        public bool isEarlyInProcess { get; set; }
        public bool isLateInProcess { get; set; }
        public string Code { get; set; }
        public FormAppEmployRow()
        {
            Code = Guid.NewGuid().ToString();
        }

    }
    
}
