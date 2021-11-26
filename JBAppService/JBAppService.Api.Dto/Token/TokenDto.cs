using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto.Token
{
    public class TokenDto
    {
        public TokenDto()
        {

        }
        public Token Token { get; set; }
    }

    public class Token
    {
        /// <summary>
        /// 
        /// </summary>
        public string PublieKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ResponseType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// Cross-site Request Forgery key
        /// </summary>
        public string CsrfKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// 使用者工號
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 使用者密碼
        /// </summary>
        public string UserPw { get; set; }
        /// <summary>
        /// 安裝機碼
        /// </summary>
        public string DeviceId { get; set; }
    }

    public class TokenStatus
    {

        public TokenStatus() { }
        public string Code { get; set; }

        //public bool Result { get; set; }
        public string Message { get; set; }
        public string CsrfKey { get; set; }
        public string Domain { get; set; }
        public string PublicKey { get; set; }
        public string ResponseType { get; set; }
        public string Scope { get; set; }
        public string TokenKey { get; set; }
        public string UserId { get; set; }
        public string UserPw { get; set; }
    }



    public class AuthDto
    {
        public AuthDto()
        {

        }

        public AuthView Auth { get; set; }
    }

    public class AuthView
    {
        public AuthView()
        {

        }
        public string TokenKey { get; set; }
        public string PrivateKey { get; set; }

    }

    public class AuthStatus

    {

        public AuthStatus()
        {

        }
        public string Code { get; set; }
        public string Message { get; set; }
        public string PrivateKey { get; set; }
        public string RedirectParameter { get; set; }

        public string RedirectUrl { get; set; }
        public string TokenKey { get; set; }
        public string NewTokenKey { get; set; }
    }


    public class PrivatekeyDto
    {
        public string UserID { get; set; }
        public string Domain { get; set; }
        public string Privatekey { get; set; }
    }


    public class ApiResult
    {
      public bool Result { get; set; }
       public string Message { get; set; } 
       public int  GUID { get; set; } 
        public string  NewTokenKey { get; set; }

    }
}
