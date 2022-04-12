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
    public class HunyaAbsenceDataSaveDao : BaseWebAPI<List<HunyaAbsenceDataSaveApiRow>>
    {

        public HunyaAbsenceDataSaveDao() : base()
        {
            this.restURL = "/api/Absence/HunyaAbsenceDataSave";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> GetAsync(List<HunyaAbsenceDataSaveConditions> Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var AccessToken = "";
            var RefreshToken = "";
            if (Cond.Count > 0)
            {
                AuthenticationHeaderBearerTokenValue = Cond[0].AccessToken;

                //移除敏感資料
                AccessToken = Cond[0].AccessToken;
                RefreshToken = Cond[0].RefreshToken;
                Cond[0].AccessToken = "";
                Cond[0].RefreshToken = "";
            }

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Post,RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Get(List<HunyaAbsenceDataSaveConditions> Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var AccessToken = "";
            var RefreshToken = "";
            if (Cond.Count > 0)
            {
                AuthenticationHeaderBearerTokenValue = Cond[0].AccessToken;

                //移除敏感資料
                AccessToken = Cond[0].AccessToken;
                RefreshToken = Cond[0].RefreshToken;
                Cond[0].AccessToken = "";
                Cond[0].RefreshToken = "";
            }

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            this.CompanySetting = Cond[0].CompanySetting;

            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            #endregion

            var mr = this.Send(dic, HttpMethod.Post,RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(List<HunyaAbsenceDataSaveConditions> Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(List<HunyaAbsenceDataSaveConditions> Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Get(Cond, cancellationToken);
            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {

                        //實作DTO轉換
                        var oSource = Vdb.Data as List<HunyaAbsenceDataSaveApiRow>;
                        if (oSource != null && oSource.Count > 0)
                        {
                            Vdb.Status = oSource[0].state;
                            Vdb.Message = oSource[0].message;
                            Vdb.StackTrace = oSource[0].stackTrace;
                            var rsTarget = new HunyaAbsenceDataSaveRow();
                            rsTarget.pass = true;
                            foreach (var rsSource in oSource)
                            {
                                if (!rsSource.result.pass)
                                    rsTarget.pass = false;
                            }
                            Vdb.Data = rsTarget;

                        }
                    }
                }
            }

            return Vdb;
        }
    }
}