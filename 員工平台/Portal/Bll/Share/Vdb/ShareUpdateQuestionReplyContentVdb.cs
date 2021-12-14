using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Share.Vdb
{
  public  class ShareUpdateQuestionReplyContentVdb
    {
    }
    public class ShareUpdateQuestionReplyContentConditions : DataConditions
    {

        public string Code { get; set; }                 
           
        public string Content { get; set; }
        
     
    }

    public class ShareUpdateQuestionReplyContentApiRow : StandardDataBaseApiRow
    {

      public bool result { get; set; }

    }
    public class ShareUpdateQuestionReplyContentRow
    {
        public bool result { get; set; }
    }
}
