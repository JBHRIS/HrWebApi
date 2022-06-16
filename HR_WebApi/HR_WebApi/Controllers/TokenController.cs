using HR_WebApi.Helpers;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System;
using JBHRIS.Api.Dto.Employee.Entry;
using JBHRIS.Api.Dto.Login;
using JBHRIS.Api.Service;
using JBHRIS.Api.Service.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApiAuthDemo.Controllers
{
    /**
     * https://blog.miniasp.com/post/2019/10/13/How-to-use-JWT-token-based-auth-in-aspnet-core-22
     **/

    /// <summary>
    /// 登入及授權
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _configuration;
        private UserValidateService _userValidateService;
        private UserInfoService _userInfoService;
        private IRefreshTokenService _refreshTokenService;
        private IClientTokenService _clientTokenService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="userValidateService"></param>
        /// <param name="userInfoService"></param>
        public TokenController(IConfiguration configuration,
            UserValidateService userValidateService,
            UserInfoService userInfoService,
            IRefreshTokenService refreshTokenService,
            IClientTokenService clientTokenService)
        {
            _configuration = configuration;
            _userValidateService = userValidateService;
            _userInfoService = userInfoService;
            _refreshTokenService = refreshTokenService;
            _clientTokenService = clientTokenService;
        }

        /// <summary>
        /// 取得DBToken
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/GetConnection")]
        public IActionResult GetConnection(string DbName)
        {
            var issuer = _configuration["JWT:issuer"].ToString(); //"JwtAuthDemo";
            var signKey = _configuration["JWT:signKey"].ToString(); // 請換成至少 16 字元以上的安全亂碼
            var expires = Convert.ToInt32(_configuration["JWT:expires"]); // 單位: 分鐘
            UserInfo user = new UserInfo() {
                Connection = DbName
            };
            var accessToken = JwtHelpers.GenerateToken(issuer, signKey, "", expires, new string[0], JsonConvert.SerializeObject(user));
            return Ok(accessToken);
        }


        /// <summary>
        /// 登入並取得Token
        /// </summary>
        /// <param name="UserId">使用者編號</param>
        /// <param name="Password">密碼</param>
        /// <returns></returns>
        [Route("Signin")]
        [HttpPost]
        public ApiResult<TokenResultDto> SignIn(string UserId, string Password)
        {
            ApiResult<string> ValidateUser = _userValidateService.ValidateUser(UserId, Password);
            return Login(ValidateUser);
        }

        /// <summary>
        /// AD登入並取得Token
        /// </summary>
        /// <returns></returns>
        [Route("AdSignin")]
        [HttpGet]
        [Authorize(Roles = "Token/AdSignin,Admin")]
        public ApiResult<TokenResultDto> AdSignin(string AdName)
        {
            ApiResult<string> ValidateUser = _userValidateService.ValidateAdUser(AdName);
            return Login(ValidateUser);
        }
        /// <summary>
        /// 共用Login方法
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)] //Swagger不會產生給人呼叫
        private ApiResult<TokenResultDto> Login(ApiResult<string> ValidateUser)
        {
            ApiResult<TokenResultDto> status = new ApiResult<TokenResultDto>();
            status.State = false;
            if (ValidateUser.State)
            {
                // 以下變數值應該透過 IConfiguration 取得
                var issuer = _configuration["JWT:issuer"].ToString(); //"JwtAuthDemo";
                var signKey = _configuration["JWT:signKey"].ToString(); // 請換成至少 16 字元以上的安全亂碼
                var expires = Convert.ToInt32(_configuration["JWT:expires"]); // 單位: 分鐘
                UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(User);
                TokenResultDto tokenResultDto;
                var UserId = ValidateUser.Result;
                _userInfoService.SetPresetRole(UserId);//設定預設角色:管理者、主管、HR、員工
                var refreshToken = Guid.NewGuid().ToString();
                _refreshTokenService.InsertRefreshToken(UserId, refreshToken);

                tokenResultDto = new TokenResultDto()
                {
                    accessToken = JwtHelpers.GenerateToken(issuer, signKey, UserId, expires, _userInfoService.GetApiRoles(UserId), JsonConvert.SerializeObject(_userInfoService.GetUserInfo(UserId, userInfo))),
                    refreshToken = refreshToken
                };

                status.State = true;
                status.Result = tokenResultDto;
            }
            else
            {
                status.Message = "驗證錯誤";
                if (ValidateUser.Result.Length > 0)
                    status.Message += $":{ValidateUser.Result}";
            }

            return status;
        }

        /// <summary>
        /// 取得登入錯誤次數上限與解鎖時間設定
        /// </summary>
        /// <returns></returns>
        [Route("GetLoginLimitConfig")]
        [HttpGet]
        [Authorize(Roles = "Token/GetLoginLimitConfig,Admin")]
        public ApiResult<LoginLimitConfigDto> GetLoginLimitConfig()
        {
            ApiResult<LoginLimitConfigDto> apiResult = new ApiResult<LoginLimitConfigDto>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _userValidateService.GetLoginLimitConfig();
                apiResult.State = true;
            }
            catch(Exception ex)
            {
                apiResult.Message = ex.Message.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 修改登入錯誤次數上限與解鎖時間設定
        /// </summary>
        /// <returns></returns>
        [Route("UpdateLoginLimitConfig")]
        [HttpPost]
        [Authorize(Roles = "Token/UpdateLoginLimitConfig,Admin")]
        public ApiResult<UpdateLoginLimitConfigDto> UpdateLoginLimitConfig(UpdateLoginLimitConfigDto loginLimitConfigDto)
        {
            return _userValidateService.UpdateLoginLimitConfig(loginLimitConfigDto);
        }

        /// <summary>
        /// 鎖定與解鎖帳戶設定
        /// </summary>
        /// <returns></returns>
        [Route("SetLockEnable")]
        [HttpPost]
        [Authorize(Roles = "Token/SetLockEnable,Admin")]
        public ApiResult<string> SetLockEnable(List<SetLockEnableDto> setLockEnableDtos)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = true;
            foreach (var data in setLockEnableDtos)
            {
                try
                {
                    _userValidateService.SetLockEnable(data.UserId, data.Lockstate, data.LockoutEnd);
                }catch(Exception ex)
                {
                    apiResult.State = false;
                    apiResult.Result += ex.ToString()+"\n"+ "UserId:" + data.UserId + "Lockstate:" + data.Lockstate + "LockoutEnd:" + data.LockoutEnd + "\n";
                }
            }
            return apiResult;
        }

        /// <summary>
        /// 重新取得Token
        /// </summary>
        /// <param name="refreshToken">refreshToken</param>
        /// <returns></returns>
        [Route("RefreshToken")]
        [HttpPost]
        public ApiResult<TokenResultDto> RefreshToken(string refreshToken)
        {

            TokenResultDto tokenResultDto;
            ApiResult<TokenResultDto> status = new ApiResult<TokenResultDto>();
            status.State = false;
            var refreshTokenState = _refreshTokenService.UpdateRefreshToken(refreshToken);
            UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(User);
            if (refreshTokenState.State)
            {
                // 以下變數值應該透過 IConfiguration 取得
                var issuer = _configuration["JWT:issuer"].ToString(); //"JwtAuthDemo";
                var signKey = _configuration["JWT:signKey"].ToString(); // 請換成至少 16 字元以上的安全亂碼
                var expires = Convert.ToInt32(_configuration["JWT:expires"]); // 單位: 分鐘
                string UserId = refreshTokenState.Result.Nobr.ToString();
                tokenResultDto = new TokenResultDto()
                {
                    accessToken = JwtHelpers.GenerateToken(issuer, signKey, UserId, expires, _userInfoService.GetApiRoles(UserId), JsonConvert.SerializeObject(_userInfoService.GetUserInfo(UserId, userInfo))),
                    refreshToken = refreshToken
                };

                status.State = true;
                status.Result = tokenResultDto;
            }

            return status;
        }

        private string client_id = "FtjPLFqi6MwZXQCaIC32sB";
        private string client_secret = "MgRyOG3NHbXRYu0tZetqWAdSzxS68yPtsnbcIfH0II6";
        private string redirect_uri = "http://192.168.1.46/HrWebApi/api/Token/InsertLineToken";
        /// <summary>
        /// 登入並取得LineUrl(與使用者連動line)
        /// </summary>
        [Route("GetLineUrl")]
        [HttpGet]
        public ApiResult<string> GetLineUrl()
        {
            UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(User);
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = true;
            apiResult.Result = "https://notify-bot.line.me/oauth/authorize" +
                "?response_type=code" +
                "&scope=notify" +
                "&response_mode=form_post" +
                $"&client_id={client_id}" +
                $"&redirect_uri={redirect_uri}?Nobr={userInfo.UserId}" +
                "&state=f194a459-1d16-42d6-a709-c2b61ec53d60";
            return apiResult;
        }

        private class Success
        {
            public int status { get; set; }
            public string message { get; set; }
            public string access_token { get; set; }
        }

        /// <summary>
        /// InsertLineToken
        /// </summary>
        [Route("InsertLineToken")]
        [HttpPost]
        public async Task<ApiResult<string>> InsertLineToken([FromForm] string code, [FromForm] string state, [FromQuery] string nobr)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;

            var url = "https://notify-bot.line.me/oauth/token";
            string result = string.Empty;
            Dictionary<string, string> formDataDictionary = new Dictionary<string, string>()
            {
                {"grant_type", "authorization_code" },
                {"redirect_uri", $"{redirect_uri}?Nobr={nobr}"},
                {"client_id", $"{client_id}" },
                {"client_secret", $"{client_secret}" },
                {"code", code }
            };
            using (HttpClient httpClient = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    foreach (var keyValuePair in formDataDictionary)
                    {
                        content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
                    }
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        //異步讀取json
                        result = response.Content.ReadAsStringAsync().Result;
                        var tt = JsonConvert.DeserializeObject<Success>(result);
                        var token = tt.access_token;
                        apiResult.State = true;
                        apiResult.Result = token;
                    }
                }
            }
            return await Task.FromResult(apiResult);
        }

        /// <summary>
        /// PostLineNotifyWithToken
        /// </summary>
        /// <returns></returns>
        [Route("PostLineNotifyWithToken")]
        [HttpPost]
        public async Task<ApiResult<string>> PostLineNotifyWithToken(List<string> Token,string message)
        {
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;

            var url = "https://notify-api.line.me/api/notify";
            string result = string.Empty;
            Dictionary<string, string> formDataDictionary = new Dictionary<string, string>()
            {
                {"message", $"{message}" }
            };

            Token.ForEach(async jwt =>
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);
                    using (var content = new MultipartFormDataContent())
                    {
                        foreach (var keyValuePair in formDataDictionary)
                        {
                            content.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
                        }
                        HttpResponseMessage response = await httpClient.PostAsync(url, content);
                        if (response.IsSuccessStatusCode)
                        {
                            //異步讀取json
                            result = response.Content.ReadAsStringAsync().Result;
                            var tt = JsonConvert.DeserializeObject<Success>(result);
                            var rmessage = tt.message;
                            apiResult.State = true;
                            apiResult.Result = rmessage.ToString();
                        }
                    }
                }
            });
            return await Task.FromResult(apiResult);
        }

        /// <summary>
        /// 客戶取得token
        /// </summary>
        /// <param name="ClientId">ClientId</param>
        /// <param name="DbName">DbName</param>
        /// <returns></returns>
        [Route("ClientGetToken")]
        [HttpPost]
        public ApiResult<TokenResultDto> ClientGetToken(string ClientId)
        {
            TokenResultDto tokenResultDto;
            ApiResult<TokenResultDto> status = new ApiResult<TokenResultDto>();
            status.State = false;
            // 以下變數值應該透過 IConfiguration 取得
            var issuer = _configuration["JWT:issuer"].ToString(); //"JwtAuthDemo";
            var signKey = _configuration["JWT:signKey"].ToString(); // 請換成至少 16 字元以上的安全亂碼
            var expires = Convert.ToInt32(_configuration["JWT:expires"]); // 單位: 分鐘
            var clientTokenState = _clientTokenService.GetClentRoleApi(ClientId);
            UserInfo userInfo = JBHRIS.Api.Bll.GetUserInfos.GetUserInfo(User);
            if (!(clientTokenState == null || clientTokenState.Length==0))
            {
                tokenResultDto = new TokenResultDto()
                {
                    accessToken = JwtHelpers.GenerateToken(issuer, signKey, ClientId, expires, clientTokenState, JsonConvert.SerializeObject(userInfo)),
                };

                status.State = true;
                status.Result = tokenResultDto;
            }

            return status;
        }

        /// <summary>
        /// 排程啟動服務
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/FirstGet")]
        public IActionResult FirstGet()
        {
            var UserId = "";
            var Password = "";
            _userValidateService.ValidateUser(UserId, Password);
            return Ok("FirstGet");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/claims")]
        public IActionResult GetClaims()
        {
            return Ok(User.Claims.Select(p => new { p.Type, p.Value }));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/userdata")]
        public IActionResult GetUserData()
        {
            return Ok(User.Claims.Where(p=>p.Type.Contains("userdata")).FirstOrDefault().Value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/username")]
        public IActionResult GetUserName()
        {
            return Ok(User.Identity.Name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("~/jwtid")]
        public IActionResult GetUniqueId()
        {
            var jti = User.Claims.FirstOrDefault(p => p.Type == "jti");
            return Ok(jti.Value);
        }
    }
 
}