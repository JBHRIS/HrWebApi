using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{
    public interface IQRCodeHandler
    {

        /// <summary>
        /// 檢查QRCODE 是否存在資料庫
        /// </summary>
        /// <param name="QRCode"></param>
        /// <returns></returns>
        bool CheckQRCode(string QRCode);



        /// <summary>
        /// RSA解密資料
        /// </summary>
        /// <param name="ciphertext">要解密資料</param>
        /// <param name="KeyContainerName">密匙容器的名稱</param>
        /// <returns></returns>
        bool RSADecrypt(string ciphertext, string KeyContainerName );


        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="input">  yyyy-MM-dd-hh-mm-ss-AddMinute-Company </param>
        /// <param name="Company"></param>
        /// <returns></returns>
        bool Base64Decrypt(string input,int EffectiveSeconds , string Company);
    }
}
