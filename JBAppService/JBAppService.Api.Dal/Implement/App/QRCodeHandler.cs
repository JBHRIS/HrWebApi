using JBAppService.Api.Dal.Models.AppDBContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBAppService.Api.Dal.Interface;

namespace JBAppService.Api.Dal.Implement.App
{
    public class QRCodeHandler : IQRCodeHandler
    {


        private AppDBContext _AppDBContext;
        public QRCodeHandler(AppDBContext context)
        {
            this._AppDBContext = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">  yyyy-MM-dd-hh-mm-ss-AddMinute-Company </param>
        /// <param name="Company"></param>
        /// <returns></returns>
        public bool Base64Decrypt(string input ,int EffectiveSeconds , string Company)
        {
            bool result = false;
            


            try
            {

                List<string> cipher = Base64Decrypt(input, new UTF8Encoding()).Split('-').ToList();
                if (cipher.Count == 8)
                {
                    int yyyy = int.Parse(cipher[0]);
                    int MM = int.Parse(cipher[1]);
                    int dd = int.Parse(cipher[2]);
                    int hh = int.Parse(cipher[3]);
                    int mm = int.Parse(cipher[4]);
                    int ss = int.Parse(cipher[5]);
                    int AddSeconds = int.Parse(cipher[6]);

                    DateTime dateTime = new DateTime(yyyy, MM, dd, hh, mm, ss).AddSeconds(AddSeconds);

                    if (cipher[7] == Company && AddSeconds == EffectiveSeconds && DateTime.Now  <=   dateTime &&   dateTime  <= DateTime.Now.AddSeconds(EffectiveSeconds))
                    {

                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
				/*ada*/
            }
            catch (Exception )
            {

                result = false;
            }
            



            return result; 
        }

		/// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encode"></param>		
        /// <returns></returns>
        private string Base64Decrypt(string input, Encoding encode)
        {
            string result = "";
            try
            {
                result = encode.GetString(Convert.FromBase64String(input));
            }
            catch (Exception)
            {

                result = "";
            }

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="QRCode"></param>
        /// <returns></returns>
        public bool CheckQRCode( string QRCode)
        {
            bool result = false;
            result = (from qr in this._AppDBContext.QRCode_Verification
                      where qr.Status ==true && qr.QRCode.Trim() == QRCode.Trim()
                      select qr
                       ).Any();
            return result;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <param name="KeyContainerName"></param>
        /// <returns></returns>
        public bool RSADecrypt(string ciphertext, string KeyContainerName )
        {


            bool result = false;
            System.Security.Cryptography.CspParameters param = new System.Security.Cryptography.CspParameters();
            param.KeyContainerName = KeyContainerName ?? "fuck"; //密匙容器的名稱，保持加密解密一致才能解密成功
            using (System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(param))
            {
                byte[] encryptdata = Convert.FromBase64String(ciphertext);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                //return System.Text.Encoding.Default.GetString(decryptdata);
            }

            return result;
        }

		///SHA-256
		//

		public void marginTradeFromDeposit()
		{
			//bZxContract 的takeOrderFromiToken( ) 
			//shouldLiquidate();
		}
    }
}
