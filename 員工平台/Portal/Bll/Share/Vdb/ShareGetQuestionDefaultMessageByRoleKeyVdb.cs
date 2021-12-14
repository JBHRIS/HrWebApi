using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Share.Vdb
{
  public  class ShareGetQuestionDefaultMessageByRoleKeyVdb
    {
    }
    public class ShareGetQuestionDefaultMessageByRoleKeyConditions : DataConditions
    {
       public string RoleKey { get; set; }



    }

    public class ShareGetQuestionDefaultMessageByRoleKeyApiRow : StandardDataBaseApiRow
    {

        public int AutoKey { get; set; }

        public string CompanyId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
        public string Contents { get; set; }
        public int RoleKey { get; set; }
        public string Note { get; set; }

        public string Status { get; set; }

        public string InsertMan { get; set; }

        public DateTime InsertDate { get; set; }
        public string UpdateMan { get; set; }

        public DateTime UpdateDate { get; set; }

        public List<ShareGetQuestionDefaultMessageByRoleKeyApiRow> result { get; set; }

    }
    public class ShareGetQuestionDefaultMessageByRoleKeyRow
    {

        public int AutoKey { get; set; }

        public string CompanyId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
        public string Contents { get; set; }
        public int RoleKey { get; set; }
        public string Note { get; set; }

        public string Status { get; set; }

        public string InsertMan { get; set; }

        public DateTime InsertDate { get; set; }
        public string UpdateMan { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
