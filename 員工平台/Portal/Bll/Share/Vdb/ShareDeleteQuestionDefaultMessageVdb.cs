using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Share.Vdb
{
  public  class ShareDeleteQuestionDefaultMessageVdb
    {
    }
    public class ShareDeleteQuestionDefaultMessageConditions : DataConditions
    {
        public string Code { get; set; }



    }

    public class ShareDeleteQuestionDefaultMessageApiRow : StandardDataBaseApiRow
    {

       public bool result { get; set; }

    }
    public class ShareDeleteQuestionDefaultMessageRow
    {

       public bool result { get; set; }
    }
}
