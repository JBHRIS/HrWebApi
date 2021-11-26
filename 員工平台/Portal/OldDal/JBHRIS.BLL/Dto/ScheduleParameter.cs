using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHRIS.BLL.Dto
{
    public class ScheduleParameter
    {
        public ScheduleParameter()
        {

        }
        public string ParameterID;
        public string ParameterName;
        public string DefaultValue;
        object _Value;
        public object Value
        {
            get
            {
                if (_Value == null) return DefaultValue;
                else return _Value;
            }
            set { _Value = value; }
        }
        public Type ParameterType;
    }
}
