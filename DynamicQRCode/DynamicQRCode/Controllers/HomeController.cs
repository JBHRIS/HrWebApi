using DynamicQRCode.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QRCoder;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace DynamicQRCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHostingEnvironment _hostingEnvironment;

        private  IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger  , IConfiguration configuration , IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            this._configuration = configuration;
            this._hostingEnvironment = hostingEnvironment;
            
        }

        public IActionResult Index()
        {


            String hostName = Dns.GetHostName();
            string KeyContainerName = this._configuration.GetValue<string>("KeyContainerName");
            string ContainerName = this._configuration.GetValue<string>("ContainerName");


            string iv = this._configuration.GetValue<string>("iv");
            int EffectiveSeconds = this._configuration.GetValue<int>("EffectiveSeconds");







            DateTime DateNow = DateTime.Now;
            string datetime = DateNow.ToString("yyyy-MM-dd-HH-mm-ss");

            //string data = string.Format("{0}-{1}-{2}", datetime, EffectiveMinutes, KeyContainerName);
            //string data = RSAEncryption(string.Format("{0}-{1}", datetime, EffectiveMinutes), KeyContainerName);

            //string data = RSAEncryption(string.Format("{0}-{1}", datetime, EffectiveMinutes), KeyContainerName , iv);
            string data = Base64Encrypt(string.Format("{0}-{1}-{2}", datetime, EffectiveSeconds, KeyContainerName));


            
            QRCodeGenerator qrGenerator = new QRCodeGenerator();


            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);





            Bitmap qrCodeImage = qrCode.GetGraphic(35);


            string outputFileName = @"wwwroot\Images\Code.png";




            if (!Directory.Exists(@"wwwroot\Images"))
            {
                Directory.CreateDirectory(@"wwwroot\Images");
            }

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    qrCodeImage.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }


            ViewData["Message"] = DateNow.ToString("yyyy/MM/dd HH:mm:ss"); ;
            ViewData["Title"] = ContainerName;
            string ImageUrl = this._configuration.GetValue<string>("ImageUrl");

            ViewBag.ImageUrl =    Path.Combine(hostName, ImageUrl); 


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="express">加密資料</param>
        /// <param name="KeyContainerName">8位字元的金鑰字串</param>
        /// <param name="iv">8位字元的初始化向量字串</param>
        /// <returns></returns>
        private static string RSAEncryption(string express, string KeyContainerName  )
        {




            //byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KeyContainerName);
            //byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            //DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            //int i = cryptoProvider.KeySize;
            //MemoryStream ms = new MemoryStream();
            //CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            //StreamWriter sw = new StreamWriter(cst);
            //sw.Write(express);
            //sw.Flush();
            //cst.FlushFinalBlock();
            //sw.Flush();
            //return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

            ///RSAEncryption
            System.Security.Cryptography.CspParameters param = new System.Security.Cryptography.CspParameters();
            param.KeyContainerName = KeyContainerName; //密匙容器的名稱，保持加密解密一致才能解密成功
            using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(param))
            {
                byte[] plaindata = System.Text.Encoding.Default.GetBytes(express);//將要加密的字串轉換為位元組陣列
                byte[] encryptdata = rsa.Encrypt(plaindata, false);//將加密後的位元組資料轉換為新的加密位元組陣列
                return Convert.ToBase64String(encryptdata);//將加密後的位元組陣列轉換為字串
            }
        }


        #region Base64加密解密
        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="input">需要加密的字串</param>
        /// <returns></returns>
        public static string Base64Encrypt(string input)
        {
            return Base64Encrypt(input, new UTF8Encoding());
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="input">需要加密的字串</param>
        /// <param name="encode">字元編碼</param>
        /// <returns></returns>
        public static string Base64Encrypt(string input, Encoding encode)
        {
            return Convert.ToBase64String(encode.GetBytes(input));
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="input">需要解密的字串</param>
        /// <returns></returns>
        public static string Base64Decrypt(string input)
        {
            return Base64Decrypt(input, new UTF8Encoding());
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="input">需要解密的字串</param>
        /// <param name="encode">字元的編碼</param>
        /// <returns></returns>
        public static string Base64Decrypt(string input, Encoding encode)
        {
            return encode.GetString(Convert.FromBase64String(input));
        }
        #endregion
    }
}
