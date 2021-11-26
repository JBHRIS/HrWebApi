using JBAppService.Api.Dto;
using JBAppService.Api.Dto.FencePoints;
using JBAppService.Api.Dto.ItemObject;
using JBAppService.Api.Dto.Token;
using JBAppService.Api.Service.Interface;
using JBAppService.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JBAppService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationController : ControllerBase
    {
        private readonly JwtHelpers _jwt;
        private readonly ICardHandlerService _ICardHandlerService;
        private readonly ICertificationService _ICertificationService;
        private readonly IConfiguration _configuration;
        private readonly IQRCodeInterface _qRCodeInterface;
        private readonly IBSSIDInterface _bSSIDInterface;
        private readonly IBaseHandlerService _baseHandlerService;
        private readonly ILogger<string> _logger;
        private IAuthorizeHandlerService _IAuthorizeHandlerService;


        public CertificationController(
            JwtHelpers JwtHelpers,
            ICardHandlerService cardHandlerService,
            ICertificationService certificationService,
            IConfiguration configuration,
            IQRCodeInterface qRCode,
            IBSSIDInterface bSSIDInterface,
            IBaseHandlerService baseHandlerService,
            ILogger<string> logger,
            IAuthorizeHandlerService IAuthorizeHandlerService
            )
        {
            this._ICardHandlerService = cardHandlerService;
            this._ICertificationService = certificationService;
            this._configuration = configuration;
            this._qRCodeInterface = qRCode;
            this._jwt = JwtHelpers;
            this._logger = logger;
            _bSSIDInterface = bSSIDInterface;
            _baseHandlerService = baseHandlerService;
            _IAuthorizeHandlerService = IAuthorizeHandlerService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmpConfigurationALL")]
        public List<GetEmpConfiguration> GetEmpConfigurationALL()
        {
            List<GetEmpConfiguration> resultList = new List<GetEmpConfiguration>();

            //檢查項目 之後有可能做成設定檔
            List<AppSettingConfigurationDto> rdSettinGList = new List<AppSettingConfigurationDto>();
            rdSettinGList = _ICertificationService.GetAppSettingConfiguration();

            List<AppSettingConfigurationDto> rdlsit = new List<AppSettingConfigurationDto>();

            string Message = "";
            string Nobr = "";
            try
            {
                Nobr = User.Claims.FirstOrDefault(p => p.Type == "EmpID").Value;
                rdlsit = _ICertificationService.GetEmpConfigurationAll_by_Nobr(Nobr);
                var exp = User.Claims.FirstOrDefault(p => p.Type == "exp").Value;

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                _logger.LogError(ex, "工號：" + Nobr + ex.Message);
            }

            foreach (AppSettingConfigurationDto item in rdSettinGList)
            {
                GetEmpConfiguration result = new GetEmpConfiguration();
                /* 2021/04/13
                 * 打卡 qrcode 按鈕一定要顯示
                 * 避免工號未設定
                 * 1,713.161.46
                 */
                if (item.SettingValue == "Scanning")//  item.SettingItem = "掃描打卡";
                {
                    result.isCheck = true;
                    result.SettingValue = "Scanning";
                    result.SettingItem = "掃描打卡";
                    result.Message = "";
                }
                else
                {
                    result.isCheck = rdlsit.Where(m => m.SettingValue == item.SettingValue).Any();
                    result.SettingItem = item.SettingItem;
                    result.SettingValue = item.SettingValue;
                    result.Message = item.Note;
                }
                resultList.Add(result);
            }
            return resultList;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAppSettingConfiguration")]
        public List<AppSettingConfigurationDto> GetAppSettingConfiguration()
        {
            return this._ICertificationService.GetAppSettingConfiguration();
        }

        /// <summary>
        /// 取得打卡類型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCardType")]
        public List<ItemObject> GetCardType()
        {
            List<ItemObject> result = new List<ItemObject>();
            try
            {
                result = _ICertificationService.GetPunchCardType();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return result;
        }

        /// <summary>
        ///
        /// polygon圍籬
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFencePoints")]
        public List<PointsGroupDto> GetFencePoints()
        {
            //1,298,705.6
            //string Nobr = User.Claims.FirstOrDefault(p => p.Type == "EmpID").Value;
            //

            return this._ICertificationService.GetFencePoints();

            //return new List<PointsGroupDto>();
        }

        /// <summary>
        ///
        /// Circle圍籬
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCircleFence")]
        public List<PointDto> GetCircleFence()
        {
            //string Nobr = User.Claims.FirstOrDefault(p => p.Type == "EmpID").Value;

            return this._ICertificationService.GetCircleFence();

            //return new List<PointsGroupDto>();
        }

        /// <summary>
        /// 取得token使用者基本資訊 工號，姓名
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserInfo")]
        public BaseInfoDto GetUserInfo()
        {
            string Nobr = User.Claims.FirstOrDefault(p => p.Type == "EmpID").Value;
            BaseInfoDto result = new BaseInfoDto();
            result = this._ICertificationService.GetUserInfo(Nobr);
            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("CheckAppSetting")]
        public List<GetEmpConfiguration> CheckAppSetting()
        {
            List<GetEmpConfiguration> resultList = new List<GetEmpConfiguration>();
            string message = "";
            try
            {
                string Nobr = User.Claims.FirstOrDefault(m => m.Type == "EmpID").Value;
                GetEmpConfiguration result = new GetEmpConfiguration();
                result.isCheck = true;
                result.SettingValue = "Scanning";
                result.SettingItem = "掃描打卡";
                result.Message = "";
                resultList.Add(result);
            }
            catch (Exception ex)
            {
            }

            return resultList;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="SignTypeDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveSignType")]
        public ApiResult SaveSignType([FromBody] SaveCardAppDetailsDto SignTypeDto)
        {
            bool Pass = true;
            string Message = "";
            int GUID = 0;
            string CardCode = "";
            this._logger.LogInformation("工號 : " + SignTypeDto.Nobr + "，打卡Token :" + Request.Headers["Authorization"].ToString());

            bool iswifi = this._configuration.GetValue<bool>("iswifi");
            bool isQRCode = this._configuration.GetValue<bool>("isQRCode");
            bool isInPolygon = this._configuration.GetValue<bool>("isInPolygon");

            //是否參考BASETTS設定
            bool isAppSetting = this._configuration.GetValue<bool>("isAppSetting");

            string Domain = User.Claims.FirstOrDefault(p => p.Type == "Domain").Value;
            string EmpID = User.Claims.FirstOrDefault(p => p.Type == "EmpID").Value;
            string NewTokenKey = _jwt.GenerateToken(EmpID, Domain, 7 * 24 * 60);

            var BaseInfo = new BaseInfoDto();

            ApiResult result = new ApiResult();

            bool tag = iswifi;

            string qrcode = SignTypeDto.QRCode?.Trim() ?? "";
            string bssid = SignTypeDto.BSSID?.Trim() ?? "";
            this._logger.LogInformation(string.Format(@"工號 : {0}，QRCODE : {1}，BSSID : {2}", SignTypeDto.Nobr, SignTypeDto.QRCode, SignTypeDto.BSSID));
            isQRCode = qrcode.Length > 0; // 用是否有傳入QRCODE來判斷是否用QRCODE

            if (isAppSetting)
            {
                CardCode = "9";
                BaseInfo =  _baseHandlerService.GetBaseInfoAppSetting(EmpID);

                if (!BaseInfo.OnLineApp)
                {
                    Pass = false;
                    Message = "您不允許線上打卡。";
                    GUID = 0;
                    result.Result = Pass;
                    result.Message = Message;
                    result.GUID = GUID;
                    result.NewTokenKey = NewTokenKey;
                    return result;
                }
            }

            if (isQRCode)
            {
                Pass = false;
                try
                {
                    string issuer = _configuration.GetValue<string>("JwtSettings:Issuer");
                    int EffectiveSeconds = _configuration.GetValue<int>("JwtSettings:EffectiveSeconds");
                    if (this._qRCodeInterface.Base64Decrypt(qrcode, EffectiveSeconds, issuer) || this._qRCodeInterface.CheckQRCode(qrcode))
                    {
                        this._logger.LogInformation("工號 :" + SignTypeDto.Nobr + ":" + " qrcode驗證成功!" + qrcode + " 時間 : " + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + " : " + issuer);
                        Pass = true;
                    }
                    else
                    {
                        Message = "QRCode 錯誤 ，請重新掃描";// string.Format("QRCode 錯誤 : {0}，請重新掃描!", SignTypeDto.QRCode.Trim());
                        GUID = 0;
                        this._logger.LogInformation("工號 : " + SignTypeDto.Nobr + ":" + "qrcode驗證失敗!" + qrcode + " 時間 : " + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + " : " + issuer);
                        result.Result = Pass;
                        result.Message = Message;
                        result.GUID = GUID;
                        result.NewTokenKey = NewTokenKey;
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    this._logger.LogInformation(ex.Message);
                }
            }
            else
            {
                try
                {
                    Pass = false;
                    int BssidSetRowCount = _bSSIDInterface.GetBssidCount();
                    int CircleSetCount = _ICertificationService.GetCircleFence().Count();

                    if (BssidSetRowCount == 0 && CircleSetCount == 0)
                    {
                        Pass = true;
                    }
                    else
                    {
                        if (BssidSetRowCount > 0)
                        {
                            Pass = _bSSIDInterface.CheckBSSID(bssid);

                            if (!Pass)
                            {
                                Message = string.Format("WIFI位置不正確");
                                this._logger.LogInformation("工號 :" + SignTypeDto.Nobr + ":" + " WIFI位置不正確!" + SignTypeDto.BSSID + " 時間 : " + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));
                                GUID = 0;
                                result.Result = Pass;
                                result.Message = Message;
                                result.GUID = GUID;
                                result.NewTokenKey = NewTokenKey;
                            }
                        }

                        //當BSSID沒驗證成功才去檢查GPS
                        if (!Pass)
                        {
                            if (CircleSetCount > 0)
                            {
                                Pass = this._ICertificationService.isInPolygon((double)SignTypeDto.Coordinate.Latitude, (double)SignTypeDto.Coordinate.Longitude);

                                if (isAppSetting)
                                {
                                    if (Pass)
                                    {
                                        CardCode = "9";
                                    }

                                    if (!Pass && BaseInfo.NoOnLineAtt) // GPS不通過 但是有設定允許範圍外
                                    {
                                        Pass = true;
                                        CardCode = "8";
                                    }
                                }

                                if (!Pass)
                                {
                                    //Message = string.Format("你所在位置不允許打卡，座標 : 緯度:{0} 經度:{1} 。", SignTypeDto.Coordinate.Latitude, SignTypeDto.Coordinate.Longitude);

                                    //打卡失敗，您所在位置不在打卡的允許範圍內。

                                    //宥軒打卡訊息
                                    Message = string.Format("您所在位置不在打卡的允許範圍內");
                                    GUID = 0;
                                    result.Result = Pass;
                                    result.Message = Message;
                                    result.GUID = GUID;
                                    result.NewTokenKey = NewTokenKey;
                                    return result;
                                }
                            }
                            else
                            {
                                return result;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this._logger.LogInformation(ex.Message);
                }
            }

            try
            {
                bool isBindRegisterKey = _configuration.GetValue<bool>("isBindRegisterKey");
                //如果有機碼綁定
                if (isBindRegisterKey)
                {
                    var IsRegistry = _IAuthorizeHandlerService.IsRegistry(SignTypeDto.Nobr, SignTypeDto.APP_RegistryKey);

                    if (IsRegistry)
                    {
                        _logger.LogInformation("工號 : " + SignTypeDto.Nobr + ":" + "此帳號或機碼已綁定，打卡失敗，機碼："+ SignTypeDto.APP_RegistryKey);
                        Pass = false;
                        Message = string.Format("此帳號或機碼已綁定，打卡失敗");
                        GUID = 0;
                        result.Result = Pass;
                        result.Message = Message;
                        result.GUID = GUID;
                        result.NewTokenKey = NewTokenKey;
                        return result;
                    }
                    else
                    {
                        _IAuthorizeHandlerService.RegistryId(SignTypeDto.Nobr, SignTypeDto.APP_RegistryKey);
                    }
                }

                bool NotTran = this._configuration.GetValue<bool>("NotTran");

                bool SaveCardMsg =  _ICardHandlerService.SaveCardMsg(SignTypeDto, NotTran, CardCode);

                if (SaveCardMsg)
                {
                    Pass = false;
                    Message = "打卡失敗，同一分鐘不可打卡兩次(含)以上";
                    _logger.LogInformation("工號 : " + SignTypeDto.Nobr + ":" + "同一分鐘打卡兩次");
                }
                else
                {
                    GUID = this._ICardHandlerService.SaveCardDetails(SignTypeDto, NotTran, CardCode);

                    Pass = true;
                    if (GUID <= 0)
                    {
                        Pass = false;
                        Message = "打卡失敗，儲存卡片不成功。";
                    }

                    var TimeDiff = (DateTime.Now - SignTypeDto.CardSend);
                    if (Math.Abs(TimeDiff.TotalSeconds) > 60)
                    {
                        Message = "您的裝置時間與伺服器時間相差過久。";
                    }

                    _logger.LogInformation("工號 : " + SignTypeDto.Nobr + ":" + "寫入打卡成功");
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                _logger.LogInformation(ex.Message);
            }

            this._logger.LogInformation("工號 : " + SignTypeDto.Nobr + ":" + "回傳打卡資訊");

            result.Result = Pass;
            result.Message = Message;
            result.GUID = GUID;
            result.NewTokenKey = NewTokenKey;
            return result;
        }

        /// <summary>
        /// 20210126新增盼端。新增，電子圍籬，bssid驗證
        /// </summary>
        /// <param name="latitudeCur">緯度</param>
        /// <param name="longitudeCur">經度</param>
        /// <returns></returns>
        [HttpGet]
        [Route("isInPolygon")]
        public bool isInPolygon(double latitudeCur, double longitudeCur)
        {
            try
            {
                return this._ICertificationService.isInPolygon(latitudeCur, longitudeCur);

                //return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// google api key
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetApiKey")]
        public string GetApiKey()
        {
            //1,004,326.29
            //Decentralized Applications
            return "AIzaSyC3wPyoJzCNJKosq6UtBIK_RBvgY6a6OT8";
        }

        /// <summary>
        /// 20210126新增盼端。新增，電子圍籬，bssid驗證
        /// 20210126 btc 290,552.26
        /// </summary>
        /// <param name="latitudeCur">緯度</param>
        /// <param name="longitudeCur">經度</param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("isInPolygon")]
        //public PolygonDto isInPolygon(double latitudeCur, double longitudeCur, string BSSID, string QRCode)
        //{
        //    string Nobr = User.Claims.FirstOrDefault(p => p.Type == "EmpID").Value;

        //    //bool
        //    ///return this._ICertificationService.isInPolygon(latitudeCur, longitudeCur);

        //    PolygonDto polygon = new PolygonDto();
        //    polygon.Result = true;
        //    //polygon.Code = "success";
        //    polygon.Message = "在考勤範圍內";

        //    return polygon;
        //}

        /// <summary>
        /// RAS加密資料
        /// </summary>
        /// <param name="express">要加密資料</param>
        /// <param name="KeyContainerName">密匙容器名稱</param>
        //public void RSAEncryption(string express, string KeyContainerName = null)
        //{
        //    System.Security.Cryptography.CspParameters param = new System.Security.Cryptography.CspParameters();
        //    param.KeyContainerName = KeyContainerName ?? "AddDmitrytocontributorsandaddRUtootherlangstranslations"; //密匙容器的名稱，保持加密解密一致才能解密成功
        //    using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(param))
        //    {
        //        byte[] plaindata = System.Text.Encoding.Default.GetBytes(express);//將要加密的字串轉換為位元組陣列
        //        byte[] encryptdata = rsa.Encrypt(plaindata, false);//將加密後的位元組資料轉換為新的加密位元組陣列
        //        // RSA DATA
        //        //return Convert.ToBase64String(encryptdata);//將加密後的位元組陣列轉換為字串
        //    }
        //}

        /// <summary>
        /// RAS解密資料
        /// </summary>
        /// <param name="ciphertext">要解密資料</param>
        /// <param name="KeyContainerName">密匙容器名稱</param>
        //public void RSADecrypt(string ciphertext, string KeyContainerName = null)
        //{
        //    //0x009e199267a6a2c8ae075bb8d4c40ee8d05c1b769085ee59ce98e50c2b2d8756
        //    System.Security.Cryptography.CspParameters param = new System.Security.Cryptography.CspParameters();
        //    param.KeyContainerName = KeyContainerName ?? "AddDmitrytocontributorsandaddRUtootherlangstranslations"; //密匙容器的名稱，保持加密解密一致才能解密成功
        //    using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(param))
        //    {
        //        byte[] encryptdata = Convert.FromBase64String(ciphertext);
        //        byte[] decryptdata = rsa.Decrypt(encryptdata, false);
        //        //return System.Text.Encoding.Default.GetString(decryptdata);
        //    }
        //}

        public class GetEmpConfiguration
        {
            public string SettingValue { get; set; }
            public string SettingItem { get; set; }
            public bool isCheck { get; set; }
            public string Message { get; set; }
        }
    }
}