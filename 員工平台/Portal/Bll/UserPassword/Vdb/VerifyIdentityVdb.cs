using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.UserPassword.Vdb
{
  public  class VerifyIdentityVdb
    {
    }

    public class VerifyIdentityConditions : DataConditions
    { 
        public string nobr { get; set; }
        public string idNo { get; set; }
        public string email { get; set; }
        public string redirectUrl { get; set; }
        public string redirectQueryString { get; set; }
    }
    
    public class VerifyIdentityApiRow : StandardDataBaseApiRow
    {
        
        public string result { get; set; }
    }

    public class VerifyIdentityRow : StandardDataRow
    {
        public string Result { get; set; }
    }
}
