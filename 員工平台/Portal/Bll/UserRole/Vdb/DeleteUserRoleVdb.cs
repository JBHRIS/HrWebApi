namespace Bll.UserRole.Vdb
{
    public  class DeleteUserRoleVdb
    {
    }

    public class DeleteUserRoleConditions : DataConditions
    {
        public string nobr { get; set; }
        public string roleCode { get; set; }
    }
    
    public class DeleteUserRoleApiRow : StandardDataBaseApiRow
    {
        
        public string result { get; set; }
    }

    public class DeleteUserRoleRow : StandardDataRow
    {
        public bool Result { get; set; }
    }
}
