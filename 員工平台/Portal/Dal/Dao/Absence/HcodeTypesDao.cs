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
using Bll.Absence.Vdb;

namespace Dal.Dao.Absence
{
    public class HcodeTypesDao : BaseWebAPI<HcodeTypesApiRow>
    {

        public HcodeTypesDao() : base()
        {
            this.restURL = "/api/Absence/GetHcodeTypes";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> GetAsync(HcodeTypesConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Get,RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Get(HcodeTypesConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            this.CompanySetting = Cond.CompanySetting;

            #endregion

            var mr = this.Send(dic, HttpMethod.Get,RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(HcodeTypesConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {

            var Vdb = await GetAsync(Cond, cancellationToken);
            if (Vdb.Status)
            {
                if (Vdb.Payload != null)
                {
                    //實作DTO轉換

                }
            }
            return Vdb;
        }

        public APIResult GetData(HcodeTypesConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Get(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as HcodeTypesApiRow;
                        if (oSource != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;

                            if (oSource.state)
                            {
                                var rsSource = oSource.result;
                                var rsTarget = new List<HcodeTypesRow>();
                                foreach (var rSource in rsSource)
                                {
                                    var rTarget = new HcodeTypesRow();
                                    rTarget.Htype = rSource.htype;
                                    rTarget.TypeName = rSource.typeName;
                                    rsTarget.Add(rTarget);
                                }
                                Vdb.Data = rsTarget;
                            }
                        }
                    }
                }
            }

            return Vdb;
        }
    }
}