using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Share.Vdb
{
  public  class ShareUpdateQuestionReplySendVdb
    {
    }
    public class ShareUpdateQuestionReplySendConditions : DataConditions
    {

        public string Code { get; set; }                 
           
        public bool SetSend { get; set; }
        
     
    }

    public class ShareUpdateQuestionReplySendApiRow : StandardDataBaseApiRow
    {

      public bool result { get; set; }

    }
    public class ShareUpdateQuestionReplySendRow
    {
        public bool result { get; set; }
    }
}
