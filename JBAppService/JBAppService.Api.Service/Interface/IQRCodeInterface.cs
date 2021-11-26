using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Interface
{
    public interface IQRCodeInterface
    {

        /// <summary>
        /// 驗證 資料庫 既有QQCODE
        /// </summary>
        /// <param name="QRCode"></param>
        /// <returns></returns>
        bool CheckQRCode(string QRCode);


        /// <summary>
        /// 解密+驗證 QQCODE
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="KeyContainerName"></param>
        /// <returns></returns>
        bool Decrypt(string ciphertext, string KeyContainerName);


        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="input">  yyyy-MM-dd-hh-mm-ss-AddMinute-Company </param>
        /// <param name="Company"></param>
        /// <returns></returns>
        bool Base64Decrypt(string input, int EffectiveSeconds, string Company);
    }
}
