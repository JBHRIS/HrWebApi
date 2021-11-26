using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.UserPassword.Vdb
{
  public  class UpdatePasswordVdb
    {
    }

    public class UpdatePasswordConditions : DataConditions
    { 
        public string oldPw { get; set; }
        public string newPw { get; set; }
    }
    
    public class UpdatePasswordApiRow : StandardDataBaseApiRow
    {
        
        public string result { get; set; }
    }

    public class UpdatePasswordRow : StandardDataRow
    {
        public string Result { get; set; }
    }
}
