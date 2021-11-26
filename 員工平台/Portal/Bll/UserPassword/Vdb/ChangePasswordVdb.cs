using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.UserPassword.Vdb
{
  public  class ChangePasswordVdb
    {
    }

    public class ChangePasswordConditions : DataConditions
    { 
        
        public string resetkey { get; set; }
        public string newPw { get; set; }
    }
    
    public class ChangePasswordApiRow : StandardDataBaseApiRow
    {
        
        public string result { get; set; }
    }

    public class ChangePasswordRow : StandardDataRow
    {
        public string Result { get; set; }
    }
}
