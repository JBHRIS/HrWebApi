using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.FormView.Vdb
{
  public  class FormViewVdb
    {
    }

    public class FormViewConditions : DataConditions
    { 
    }
    
    public class FormViewApiRow : StandardDataBaseApiRow
    {
    }

    public class FormViewRow
    {
        public string ProcessId { get; set; }
        public string ApViewAuto { get; set; }
        public string ApParmAuto { get; set; }
        public string FlowCode { get; set; }
        public string FlowName { get; set; }
        public string Application { get; set; }
        public string EmpId { get; set; }
        public DateTime? ADate { get; set; }
        public DateTime? DateB { get; set; }
        public string TimeB { get; set;}
        public DateTime? DateE { get; set; }
        public string TimeE { get; set; }
        public string Use { get; set; }
        public string Unit { get; set; }
        public string Agent { get; set; }
        public string FormState { get; set; }
        public string FlowId { get; set; }
        public string SignEmpId { get; set; }
    }
}
