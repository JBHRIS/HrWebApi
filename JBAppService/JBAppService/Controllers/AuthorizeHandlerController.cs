using JBAppService.Api.Dto;
using JBAppService.Api.Dto.Token;
using JBAppService.Api.Service.Interface;
using JBAppService.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JBAppService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeHandlerController : ControllerBase
    {
        private IBaseHandlerService _IBaseHandlerService;
        private IConfiguration _configuration;
        private IAuthorizeHandlerService _IAuthorizeHandlerService;
        private readonly JwtHelpers _jwt;
        private readonly ILogger<string> _logger;

        public AuthorizeHandlerController(
            IBaseHandlerService IBaseHandlerService
            , IConfiguration Configuration
            , IAuthorizeHandlerService IAuthorizeHandlerService
            , JwtHelpers JwtHelpers
            , ILogger<string> logger)
        {
            this._IBaseHandlerService = IBaseHandlerService;
            this._configuration = Configuration;
            this._jwt = JwtHelpers;
            this._logger = logger;
            _IAuthorizeHandlerService = IAuthorizeHandlerService;
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
            _logger.LogInformation(string.Format(@"UserId:{0},CsrfKey:{1},DeviceId:{2},PublieKey:{3},Domain:{4},ResponseType:{5},Scope:{6}", tokenDto.Token.UserId, tokenDto.Token.CsrfKey, tokenDto.Token.DeviceId, tokenDto.Token.PublieKey, tokenDto.Token.Domain, tokenDto.Token.ResponseType, tokenDto.Token.Scope));
            TokenStatus token = new TokenStatus();
            bool SalaryPassWord = _configuration.GetValue<bool>("SalaryPassWord");

            bool result = false;

            if (SalaryPassWord)
            {
                _logger.LogInformation(string.Format(@"LoginBySalaryPassWord: {0}", tokenDto.Token.UserPw));
                result = this._IBaseHandlerService.CheckAccountSalaryPassWord(tokenDto.Token.UserId, tokenDto.Token.UserPw);
            }
            else
            {
                result = this._IBaseHandlerService.CheckAccount(tokenDto.Token.UserId, tokenDto.Token.UserPw);
            }

            if (result)
            {
                token.Code = "1";
                token.Message = "success";
                token.TokenKey = _jwt.GenerateToken(tokenDto.Token.UserId, tokenDto.Token.Domain, 7 * 24 * 60);

                bool isBindRegisterKey = _configuration.GetValue<bool>("isBindRegisterKey");

                //如果有機碼綁定
                if (isBindRegisterKey)
                {
                    var IsRegistry = _IAuthorizeHandlerService.IsRegistry(tokenDto.Token.UserId, tokenDto.Token.DeviceId);

                    if (IsRegistry)
                    {
                        token.Code = "3";
                        token.Message = "此帳號或機碼已綁定";
                        token.TokenKey = "";
                    }
                    else
                    {
                        _IAuthorizeHandlerService.RegistryId(tokenDto.Token.UserId, tokenDto.Token.DeviceId);
                    }
                }
            }
            else
            {
                token.Code = "2";
                token.Message = "帳號密碼錯誤";
                token.TokenKey = "";
            }

            token.CsrfKey = "";
            token.Domain = tokenDto.Token.Domain;
            token.PublicKey = "";
            token.ResponseType = "1";
            token.Scope = "1";

            token.UserId = tokenDto.Token.UserId;
            token.UserPw = tokenDto.Token.UserPw;
            this._logger.LogInformation("登入打卡系統 : " + tokenDto.Token.UserId + " 安裝機碼 " + tokenDto.Token.DeviceId);
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
            bool isRedirect = this._configuration.GetValue<bool>("RedirectSettings:isRedirect");
            string TokenAPIURL = this._configuration.GetValue<string>("RedirectSettings:TokenAPIURL");
            string SigninAPIURL = this._configuration.GetValue<string>("RedirectSettings:SigninAPIURL");
            string RedirectURL = this._configuration.GetValue<string>("RedirectSettings:RedirectURL");
            string RedirectHomePage = this._configuration.GetValue<string>("RedirectSettings:RedirectHomePage");
            string ShareCompany = this._configuration.GetValue<string>("RedirectSettings:ShareCompany");

            string Company = this._configuration.GetValue<string>("RedirectSettings:Company");

            string Domain = User.Claims.FirstOrDefault(p => p.Type == "Domain").Value;
            string EmpID = User.Claims.FirstOrDefault(p => p.Type == "EmpID").Value;

            try
            {
                this._logger.LogInformation(string.Format("工號 : {0} 呼叫 GetAuth", EmpID));

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

                #endregion 判斷有沒有呼叫api

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