using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class FormGetFlowParmUrlVdb
    {
    }
    public class FormGetFlowParmUrlConditions : DataConditions
    {
        public int iApParmID { get; set; }
        public bool bOnlyUrl { get; set; }
    }
    public class FormGetFlowParmUrlApiRow : StandardDataBaseApiRow
    {
        public string Result { get; set; }
    }
    public class FormGetFlowParmUrlRow
    {
        public string Url { get; set; }
    }
}
