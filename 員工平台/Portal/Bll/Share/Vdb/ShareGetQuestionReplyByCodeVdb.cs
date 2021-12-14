using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Share.Vdb
{
  public  class ShareGetQuestionReplyByCode
    {
    }
    public class ShareGetQuestionReplyByCodeConditions : DataConditions
    {
        
           public string Code { get; set; }
         
        
     
    }

    public class ShareGetQuestionReplyByCodeApiRow : StandardDataBaseApiRow
    {



        public int AutoKey { get; set; }
        public string Code { get; set; }
        public string QuestionMainCode { get; set; }


        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int RoleKey { get; set; }
        public string IpAddress { get; set; }
        public string ReplyToCode { get; set; }
        public string ParentCode { get; set; }
        public bool Send { get; set; }

        public string Note { get; set; }

        public string Status { get; set; }
        public string InsertMan { get; set; }

        public DateTime InsertDate { get; set; }
        public string UpdateMan { get; set; }

        public DateTime UpdateDate { get; set; }
        public List<ShareGetQuestionReplyByCodeApiRow> result { get; set; }

    }
    public class ShareGetQuestionReplyByCodeRow
    {

        public int AutoKey { get; set; }
        public string Code { get; set; }
        public string QuestionMainCode { get; set; }


        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int RoleKey { get; set; }
        public string IpAddress { get; set; }
        public string ReplyToCode { get; set; }
        public string ParentCode { get; set; }
        public bool Send { get; set; }

        public string Note { get; set; }

        public string Status { get; set; }
        public string InsertMan { get; set; }

        public DateTime InsertDate { get; set; }
        public string UpdateMan { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
