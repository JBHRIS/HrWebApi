using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Share.Vdb
{
    public class ShareGetQuestionCategoryVdb
    {
    }
    public class ShareGetQuestionCategoryConditions : DataConditions
    {
        
    }

    public class ShareGetQuestionCategoryApiRow : StandardDataBaseApiRow
    {


        
       public string Code { get; set; }
        public string Name { get; set; }



        public List<ShareGetQuestionCategoryApiRow> result { get; set; }

    }
    public class ShareGetQuestionCategoryRow
    {


        public string Code { get; set; }
        public string Name { get; set; }




    }
}
