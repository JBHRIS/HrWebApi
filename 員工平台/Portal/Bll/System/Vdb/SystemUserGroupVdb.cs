using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.System.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemUserGroupVdb
    {
    }

    /// <summary>
    /// 顯示角色權限條件
    /// </summary>
    public class SystemUserGroupConditions : DataConditions
    {
        /// <summary>
        /// 權限代碼(二進位)
        /// </summary>
        public List<int> ListRoleKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SystemUserGroupConditions()
        {
            ListRoleKey = new List<int>();
        }
    }

    /// <summary>
    /// 顯示角色權限
    /// </summary>
    public class SystemUserGroupRow : StandardDataRow
    {
        /// <summary>
        /// 權限代碼(二進位)
        /// </summary>
        public int RoleKey { get; set; }     
    }

    /// <summary>
    /// 儲存角色權限
    /// </summary>
    public class SystemUserGroupSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存角色權限資料
    /// </summary>
    public class SystemUserGroupSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserGroupRow> ListSystemUserGroup { get; set; }
    }

    /// <summary>
    /// 新增角色權限
    /// </summary>
    public class SystemUserGroupInsertResult : Message
    {

    }

    /// <summary>
    /// 新增角色權限資料
    /// </summary>
    public class SystemUserGroupInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserGroupRow> ListSystemUserGroup { get; set; }
    }

    /// <summary>
    /// 修改角色權限
    /// </summary>
    public class SystemUserGroupUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改角色權限資料
    /// </summary>
    public class SystemUserGroupUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserGroupRow> ListSystemUserGroup { get; set; }
    }

    /// <summary>
    /// 刪除角色權限
    /// </summary>
    public class SystemUserGroupDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除角色權限資料
    /// </summary>
    public class SystemUserGroupDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserGroupRow> ListSystemUserGroup { get; set; }
    }
}
