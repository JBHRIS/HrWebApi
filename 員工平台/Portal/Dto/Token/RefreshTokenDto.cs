using Bll.Token.Vdb;
using Bll.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dto.Token
{
    public class RefreshTokenDto : BaseWebAPI<SigninRow>
    {
        public RefreshTokenDto() : base()
        {
            this.restURL = "/api/Token/RefreshToken";
            this.host = Constants.HostAPI;
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = false;
        }

        public async Task<APIResult> PostAsync(RefreshTokenConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.refreshToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            dic.Add("refreshToken", Cond.refreshToken);
            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Post,Cond.RefreshToken, cancellationToken);

            return mr;
        }

        public  APIResult Post(RefreshTokenConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.refreshToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            dic.Add("refreshToken", Cond.refreshToken);
            #endregion

            var mr = this.Send(dic, HttpMethod.Post, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(RefreshTokenConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = await this.PostAsync(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Payload != null)
                {
                    var oSource = Vdb.Data as SigninApiRow;
                    if (oSource != null)
                    {
                        Vdb.Status = oSource.state;
                        Vdb.Message = oSource.message;
                        Vdb.StackTrace = oSource.stackTrace;

                        if (oSource.state)
                        {
                            var rSource = oSource.result;

                            var rTarget = new SigninRow();
                            rTarget.AccessToken = rSource.accessToken;
                            rTarget.RefreshToken = rSource.refreshToken;

                            //把api的dto(Data)轉成我們的dto(Data)
                            Vdb.Data = rTarget;
                        }
                    }
                }
            }

            return Vdb;
        }

        public APIResult GetData(RefreshTokenConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = this.Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Payload != null)
                {
                    var oSource = Vdb.Data as SigninApiRow;
                    if (oSource != null)
                    {
                        Vdb.Status = oSource.state;
                        Vdb.Message = oSource.message;
                        Vdb.StackTrace = oSource.stackTrace;

                        if (oSource.state)
                        {
                            var rSource = oSource.result;

                            var rTarget = new SigninRow();
                            rTarget.AccessToken = rSource.accessToken;
                            rTarget.RefreshToken = rSource.refreshToken;

                            //把api的dto(Data)轉成我們的dto(Data)
                            Vdb.Data = rTarget;
                        }
                    }
                }
            }

            return Vdb;
        }
    }
}