using Bll.Token.Vdb;
using Bll.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Token
{
    public class ClientGetTokenDao : BaseWebAPI<ClientGetTokenApiRow>
    {

        public ClientGetTokenDao() : base()
        {
            this.restURL = "/api/Token/ClientGetToken"; 
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = false;
        }

        public async Task<APIResult> PostAsync(ClientGetTokenConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;
            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            dic.Add("ClientId", Cond.ClientId);
            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Post, RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(ClientGetTokenConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;
            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            dic.Add("ClientId", Cond.ClientId);

            this.CompanySetting = Cond.CompanySetting;
            #endregion

            var mr = this.Send(dic, HttpMethod.Post, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(ClientGetTokenConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = await this.PostAsync(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Payload != null)
                {
                    var oSource = Vdb.Data as ClientGetTokenApiRow;
                    if (oSource != null)
                    {
                        Vdb.Status = oSource.state;
                        Vdb.Message = oSource.message;
                        Vdb.StackTrace = oSource.stackTrace;

                        if (oSource.state)
                        {
                            var rSource = oSource.result;

                            var rTarget = new ClientGetTokenRow();
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

        public APIResult GetData(ClientGetTokenConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = this.Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Payload != null)
                {
                    var oSource = Vdb.Data as ClientGetTokenApiRow;
                    if (oSource != null)
                    {
                        Vdb.Status = oSource.state;
                        Vdb.Message = oSource.message;
                        Vdb.StackTrace = oSource.stackTrace;

                        if (oSource.state)
                        {
                            var rSource = oSource.result;

                            var rTarget = new ClientGetTokenRow();
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