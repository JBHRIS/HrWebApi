using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Share.Vdb
{
    public class ShareUpdateQuestionMainVdb
    {
    }
    public class ShareUpdateQuestionMainConditions : DataConditions
    {
        
         
        public string TargetCode { get; set; }
        
        public int AutoKey { get; set; }
        public string CompanyId { get; set; }
        public string Code { get; set; }
        public string SystemCategoryCode { get; set; }
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
        public string Name { get; set; }
        public string TitleContent { get; set; }
        public string Content { get; set; }
        public string QuestionCategoryCode { get; set; }
        public string IpAddress { get; set; }
        public DateTime DateE { get; set; }
        public bool Complete { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }


        public ShareUpdateQuestionMainRow Data { get; set; }





    }

    public class ShareUpdateQuestionMainApiRow : StandardDataBaseApiRow
    {

        public bool result { get; set; }

    }
    public class ShareUpdateQuestionMainRow
    {
        public string TargetCode { get; set; }
        public int AutoKey { get; set; }
        public string CompanyId { get; set; }
        public string Code { get; set; }
        public string SystemCategoryCode { get; set; }
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
        public string Name { get; set; }
        public string TitleContent { get; set; }
        public string Content { get; set; }
        public string QuestionCategoryCode { get; set; }
        public string IpAddress { get; set; }
        public DateTime DateE { get; set; }
        public bool Complete { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string UpdateMan { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string InsertMan { get; set; }
        public DateTime? InsertDate { get; set; }



        public bool result { get; set; }
    }
}
