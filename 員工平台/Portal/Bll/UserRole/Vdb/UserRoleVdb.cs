using System.Collections.Generic;

namespace Bll.UserRole.Vdb
{
    public  class UserRoleVdb
    {
    }

    public class UserRoleConditions : DataConditions
    {
        public List<string> nobr { get; set; }

    }

    public class UserRoleApiRow : StandardDataBaseApiRow
    {
        public class Result
        {
            public int iAutoKey { get; set; }
            public string nobr { get; set; }
            public List<string> roleCode { get; set; }
        }
        public List<Result> result { get; set; }
    }

    public class UserRoleRow : StandardDataRow
    {
        public List<string> roleCode { get; set; }
    }
}
