namespace Bll.UserRole.Vdb
{
    public  class InsertUserRoleVdb
    {
    }

    public class InsertUserRoleConditions : DataConditions
    { 
        public string nobr { get; set; }
        public string roleCode { get; set; }
    }
    
    public class InsertUserRoleApiRow : StandardDataBaseApiRow
    {
        
        public string result { get; set; }
    }

    public class InsertUserRoleRow : StandardDataRow
    {
        public bool Result { get; set; }
    }
}
