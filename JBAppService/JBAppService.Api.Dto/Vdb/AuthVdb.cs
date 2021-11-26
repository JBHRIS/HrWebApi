
using System;
using System.Collections.Generic;

namespace HRWebService.Dto.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthVdb
    {
    }
    /// <summary>
    /// 前端頁面資訊
    /// </summary>
    public class PageRow
    {
        /// <summary>
        /// 頁面代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 頁面名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 頁面路徑
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 頁面標題
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 頁面描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 上層路徑
        /// </summary>
        public string ParentCode { get; set; }
        /// <summary>
        /// 順序
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// 子頁面
        /// </summary>
        public List<PageRow> site { get; set; }
    }

    /// <summary>
    /// 角色資訊
    /// </summary>
    public class RoleRow
    {
        /// <summary>
        /// 角色代碼
        /// </summary>
        public string RoleCode { get; set; }
        /// <summary>
        /// 角色名稱
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 是否是管理者
        /// </summary>
        public bool isAdmin { get; set; }
        /// <summary>
        /// 角色階層(0最大)
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 是否有助理權限
        /// </summary>
        public bool isAssistant { get; set; }
        /// <summary>
        /// 是否權限包含子部門
        /// </summary>
        public bool isIncludeChild { get; set; }
        /// <summary>
        /// 是否可以切換身分
        /// </summary>
        public bool isChangeEmp { get; set; }
    }

    /// <summary>
    /// TokenRow
    /// </summary>
    public class TokenRow : LoginPassRow
    {
        /// <summary>
        /// 原始的Code
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 新的Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 群組
        /// </summary>
        public List<string> Group { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpID { get; set; }
    }

    /// <summary>
    /// A successful response to this token request
    /// </summary>
    public class TokenResponse
    {
        /// <summary>
        /// OAuth 2.0 Access Token
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// OAuth 2.0 Token Type value
        /// </summary>
        public string token_type { get; set; }
        /// <summary>
        /// This field is only present if access_type=offline is included in the authentication request
        /// </summary>
        public string refresh_token { get; set; }
        /// <summary>
        /// Expiration time of the Access Token in seconds since the response was generated.
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// ID Token
        /// </summary>
        public string id_token { get; set; }
    }

    /// <summary>
    /// A JWT that contains identity information about the user
    /// </summary>
    public class IDToken
    {
        /// <summary>
        /// Issuer Identifier 
        /// </summary>
        public string iss { get; set; }
        /// <summary>
        /// Subject Identifier: ID
        /// </summary>
        public string sub { get; set; }
        /// <summary>
        /// Audience
        /// </summary>
        public string aud { get; set; }
        /// <summary>
        /// String value used to associate a Client session with an ID Token, and to mitigate replay attack
        /// </summary>
        public string nonce { get; set; }
        /// <summary>
        /// The time the ID token expires
        /// </summary>
        public string exp { get; set; }
        /// <summary>
        /// The time the ID token was issued
        /// </summary>
        public string iat { get; set; }
        /// <summary>
        /// Access token hash:　Provides validation that the access token is tied to the identity token.
        /// </summary>
        public string at_hash { get; set; }

        /// <summary>
        /// ID Group: e.g. CI、AE
        /// </summary>
        public string[] group { get; set; }
    }

    /// <summary>
    /// 執行動作回傳結果
    /// </summary>
    public class ActionResultRow
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool isOK { get; set; }
        /// <summary>
        /// 錯誤訊息清單
        /// </summary>
        public List<string> ErrorMsg { get; set; }
        /// <summary>
        /// 目前待審核人員
        /// </summary>
        public EmpInfo ToEmp { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class PayslipActionResultRow : ActionResultRow
    {
        /// <summary>
        /// 
        /// </summary>
        public PayslipDataList PayslipDataList { get; set; }
    }
    /// <summary>
    /// 登入資訊
    /// </summary>
    public class LoginLogRow
    {
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        public string ChangeEmpID { get; set; }
        /// <summary>
        /// 登入時間
        /// </summary>
        public DateTime LoginDateTime { get; set; }

    }

    /// <summary>
    /// 登入資訊
    /// </summary>
    public class LoginPassRow : MessageRow
    {
        /// <summary>
        /// 通過
        /// </summary>
        public bool Pass { get; set; }
    }


    /// <summary>
    /// 執行動作回傳結果
    /// </summary>
    public class OTActionResultRow
    {

        public int RowID { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool isOK { get; set; }
        /// <summary>
        /// 錯誤訊息清單
        /// </summary>
        public List<string> ErrorMsg { get; set; }

        public decimal OTAmount { get; set; }


    }

    public class PayslipDataList
    {


        public string Title { get; set; }

        public string DateIntervalTitle { get; set; }
        public string TransferTitle { get; set; }

        public string useTemplate { get; set; }//樣版主檔代碼-主檔需維護-套用每個人
        public string NoteBloc { get; set; } //提醒文件
                                             //        public <BlockClass> PayslipDetail  { get; set; }

        public List<BlockClass> BlockClass { get; set; }

    }



    public class BlockClass
    {
        public BlockClass()
        {

        }


        public string title { get; set; }

        public List<blockDetailClass> blockDetail { get; set; }

        public List<blockDetailClass> OtherblockDetail { get; set; }

        public string initDollar { get; set; } //單位

        public int order { get; set; }//順序



    }




    public class blockDetailClass
    {

        public blockDetailClass()
        {

        }

        public string title { get; set; }//明細標題
        public string number { get; set; }  //明細的值
        public string init { get; set; }//明細的單位

    }
}
