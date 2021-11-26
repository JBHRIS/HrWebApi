using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JBAppService.Api.Dto;
using JBAppService.Api.Dto.Token;
using JBAppService.Api.Service.Interface;
using JBAppService.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace JBAppService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthHandlerController : ControllerBase
    {

        private readonly JwtHelpers _jwt;
        private IBaseHandlerService _IBaseHandlerService;
        private IConfiguration _Configuration;

        private readonly ILogger<string>  _logger;

        public AuthHandlerController(JwtHelpers JwtHelpers  
            , IBaseHandlerService baseHandlerService 
            , IConfiguration configuration
            , ILogger<string> logger)
        {
            this._jwt = JwtHelpers;
            this._IBaseHandlerService = baseHandlerService;
            this._Configuration = configuration;
            this._logger = logger;
        }





        /// <summary>
        /// 取得app設置頁面 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [Route("SetTagIndex")]
        public int SetTagIndex()
        {
            int TagIndex = this._Configuration.GetValue<int>("TagIndex");
            return TagIndex;
        }





        /// <summary>
        /// 取得token
        /// </summary>
        /// <param name="tokenDto"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("GetToken")]
        public TokenStatus GetToken([FromBody] TokenDto tokenDto)
        {

            TokenStatus token = new TokenStatus();
            //頁面page    資料表 : SYS_PAGE
            bool result = this._IBaseHandlerService.CheckAccount(tokenDto.Token.UserId, tokenDto.Token.UserPw);
			//安裝機碼卡控
            
            if (result)
            {
                token.Code = "1";
                //token.Result = true;
                token.Message = "success";
                token.CsrfKey = "";
                token.Domain = tokenDto.Token.Domain;
                token.PublicKey = "";
                token.ResponseType = "1";
                token.Scope = "1";
                token.TokenKey = _jwt.GenerateToken(tokenDto.Token.UserId, tokenDto.Token.Domain, 7 * 24 * 60);
                token.UserId = tokenDto.Token.UserId;
                token.UserPw = tokenDto.Token.UserPw; 
            }
            else
            {
                token.Code = "2";
                //token.Result = false;
                token.Message = "error";
                token.CsrfKey = "";
                token.Domain = tokenDto.Token.Domain;
                token.PublicKey = "";
                token.ResponseType = "1";
                token.Scope = "1";
                token.TokenKey = "";
                token.UserId = tokenDto.Token.UserId;
                token.UserPw = tokenDto.Token.UserPw; 
            }

            this._logger.LogInformation("登入打卡系統 : " + tokenDto.Token.UserId  + " 安裝機碼 " +tokenDto.Token.DeviceId);
            this._logger.LogInformation("登入打卡系統 : " + result);
            return token;

        }



      

        /// <summary>
        /// 呼叫api 使用這個
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetAuth")]
        public AuthStatus GetAuth([FromBody] AuthDto dto)
        {



            this._logger.LogInformation(Request.Headers["Authorization"].ToString());

            AuthStatus authStatus = new AuthStatus();
            bool isRedirect = this._Configuration.GetValue<bool>("RedirectSettings:isRedirect");
            string TokenAPIURL = this._Configuration.GetValue<string>("RedirectSettings:TokenAPIURL");
            string SigninAPIURL = this._Configuration.GetValue<string>("RedirectSettings:SigninAPIURL");
            string RedirectURL = this._Configuration.GetValue<string>("RedirectSettings:RedirectURL");
            string RedirectHomePage = this._Configuration.GetValue<string>("RedirectSettings:RedirectHomePage");
            string ShareCompany = this._Configuration.GetValue<string>("RedirectSettings:ShareCompany");

            string Company = this._Configuration.GetValue<string>("RedirectSettings:Company");

            string Domain = User.Claims.FirstOrDefault(p => p.Type == "Domain").Value;
            string EmpID = User.Claims.FirstOrDefault(p => p.Type == "EmpID").Value;

            try
            {



                this._logger.LogInformation("工號 : " + EmpID + string.Format(" {0} 呼叫 GetAuth", EmpID));

                #region 判斷有沒有呼叫api 
                if (isRedirect)
                {

                    string token = "";
                    using (HttpClient client = new HttpClient())
                    {
                        var str = JsonConvert.SerializeObject(ShareCompany);
                        HttpContent content = new StringContent(str);

                        //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + "token");
                        Task<HttpResponseMessage> response = client.GetAsync(string.Format("{0}DbName={1}", TokenAPIURL, ShareCompany));

                        string responseBody = response.Result.Content.ReadAsStringAsync().Result;
                        token = responseBody;
                    }

                    using (HttpClient client = new HttpClient())
                    {
                        UserDto userDto = new UserDto();
                        userDto.UserId = EmpID;
                        userDto.Password = this._IBaseHandlerService.GetPassWord(EmpID);
                        var str = JsonConvert.SerializeObject(userDto);
                        HttpContent content = new StringContent(str);


                        this._logger.LogInformation(string.Format(" {0} 呼叫 {1}", EmpID, TokenAPIURL));

                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                        Task<HttpResponseMessage> response = client.PostAsync(string.Format("{0}UserId={1}&Password={2}", SigninAPIURL, userDto.UserId, userDto.Password), content);
                        //response.EnsureSuccessStatusCode();//用来抛异常的
                        string responseBody = response.Result.Content.ReadAsStringAsync().Result;
                        ApiResult<TokenResultDto> rd = JsonConvert.DeserializeObject<ApiResult<TokenResultDto>>(responseBody);


                        this._logger.LogInformation(string.Format(" {0} 呼叫 {1} ，完畢。", EmpID, TokenAPIURL));


                        this._logger.LogInformation(string.Format(" {0} 組url字串 {1}", EmpID, RedirectURL));

                        if (rd.Result != null)
                        {
                            authStatus.RedirectUrl = string.Format("{0}AccessToken={1}&RefreshToken={2}&Company={3}", RedirectURL, rd.Result.accessToken, rd.Result.refreshToken, Company);
                        }
                        else
                        {
                            authStatus.RedirectUrl = RedirectHomePage;
                        }
                    }



                }
                else
                {
                    authStatus.RedirectUrl = RedirectHomePage;
                }
                #endregion
                authStatus.Code = "1";
                authStatus.Message = "";
                authStatus.PrivateKey = dto.Auth.PrivateKey;
                authStatus.RedirectParameter = "";
                authStatus.TokenKey = dto.Auth.TokenKey;
                authStatus.NewTokenKey = _jwt.GenerateToken(EmpID, Domain, 7 * 24 * 60);
            }
            catch (Exception ex)
            {
                authStatus.Code = "0";
                authStatus.Message = "資料傳輸錯誤!";
                authStatus.PrivateKey = dto.Auth.PrivateKey;
                authStatus.RedirectParameter = "TokenKey" + dto.Auth.TokenKey;
                authStatus.RedirectUrl = RedirectHomePage;
                authStatus.TokenKey = dto.Auth.TokenKey;
            }


            this._logger.LogInformation("工號 : " + EmpID + string.Format(" 主頁面發新token : {0}", authStatus.NewTokenKey));
            this._logger.LogInformation("工號 : " + EmpID + string.Format(" 主頁面 {0} 結束。", RedirectURL));
            return authStatus;
            
        }
    }
}
