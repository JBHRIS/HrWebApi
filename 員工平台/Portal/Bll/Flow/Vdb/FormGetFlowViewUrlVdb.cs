using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Flow.Vdb
{
    class FormGetFlowViewUrlVdb
    {
    }
    public class FormGetFlowViewUrlConditions : DataConditions
    {
        public int idProcess { get; set; }
        public bool bOnlyUrl { get; set; }
    }
    public class FormGetFlowViewUrlApiRow : StandardDataBaseApiRow
    {
        public string Result { get; set; }
    }
    public class FormGetFlowViewUrlRow
    {
        public string Url { get; set; }
    }
}
