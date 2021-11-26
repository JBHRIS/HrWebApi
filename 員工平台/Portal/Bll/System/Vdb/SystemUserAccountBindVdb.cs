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
    public class SystemUserAccountBindVdb
    {
    }

    /// <summary>
    /// 顯示第三方連結條件
    /// </summary>
    public class SystemUserAccountBindConditions : DataConditions
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 第三方帳號
        /// </summary>
        public string ThirdPartyAccountId { get; set; }
        /// <summary>
        /// 第三方類別
        /// </summary>
        public string ThirdPartyTypeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SystemUserAccountBindConditions()
        {
            UserCode = "";
            ThirdPartyAccountId = "";
            ThirdPartyTypeCode = "";
        }
    }

    /// <summary>
    /// 顯示第三方連結
    /// </summary>
    public class SystemUserAccountBindRow : StandardDataRow
    {
        /// <summary>
        /// 帳號
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// 第三方帳號
        /// </summary>
        public string ThirdPartyAccountId { get; set; }
        /// <summary>
        /// 第三方類別
        /// </summary>
        public string ThirdPartyTypeCode { get; set; }
    }

    /// <summary>
    /// 儲存第三方連結
    /// </summary>
    public class SystemUserAccountBindSaveResult : Message
    {

    }

    /// <summary>
    /// 儲存第三方連結資料
    /// </summary>
    public class SystemUserAccountBindSaveRow : SaveRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserAccountBindRow> ListSystemUserAccountBind { get; set; }
    }

    /// <summary>
    /// 新增第三方連結
    /// </summary>
    public class SystemUserAccountBindInsertResult : Message
    {

    }

    /// <summary>
    /// 新增第三方連結資料
    /// </summary>
    public class SystemUserAccountBindInsertRow : InsertRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserAccountBindRow> ListSystemUserAccountBind { get; set; }
    }

    /// <summary>
    /// 修改第三方連結
    /// </summary>
    public class SystemUserAccountBindUpdateResult : Message
    {

    }

    /// <summary>
    /// 修改第三方連結資料
    /// </summary>
    public class SystemUserAccountBindUpdateRow : UpdateRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserAccountBindRow> ListSystemUserAccountBind { get; set; }
    }

    /// <summary>
    /// 刪除第三方連結
    /// </summary>
    public class SystemUserAccountBindDeleteResult : Message
    {

    }

    /// <summary>
    /// 刪除第三方連結資料
    /// </summary>
    public class SystemUserAccountBindDeleteRow : DeleteRow
    {
        /// <summary>
        /// 類別
        /// </summary>
        public List<SystemUserAccountBindRow> ListSystemUserAccountBind { get; set; }
    }
}
