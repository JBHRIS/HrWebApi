using JBAppService.Api.Dal.Interface;
using JBAppService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Service.Implement
{
    public class QRCodeInterface : IQRCodeInterface
    {

        private IQRCodeHandler _IQRCodeHandler;
        public QRCodeInterface(IQRCodeHandler qRCode)
        {
            this._IQRCodeHandler = qRCode;
        }

        public bool Base64Decrypt(string input, int EffectiveSeconds , string Company)
        {
            return this._IQRCodeHandler.Base64Decrypt(input , EffectiveSeconds, Company);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="QRCode"></param>
        /// <returns></returns>
        public bool CheckQRCode(string QRCode)
        {
            return this._IQRCodeHandler.CheckQRCode(QRCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="KeyContainerName"></param>
        /// <returns></returns>
        public bool Decrypt(string ciphertext, string KeyContainerName)
        {
            bool result = false;

            return result;
        }

       
    }
}
