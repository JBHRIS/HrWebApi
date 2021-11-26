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
    public class AbsenceSaveDao : BaseWebAPI<AbsenceDataDetailApiRow>
    {

        public AbsenceSaveDao() : base()
        {
            this.restURL = "/api/Absence/GetAbsenceDataDetail";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> GetAsync(AbsenceDataDetailConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

            var mr = await this.SendAsync(dic, HttpMethod.Post,RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Get(AbsenceDataDetailConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            this.CompanySetting = Cond.CompanySetting;

            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            #endregion

            var mr = this.Send(dic, HttpMethod.Post,RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(AbsenceDataDetailConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(AbsenceDataDetailConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Get(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as AbsenceDataDetailApiRow;
                        if (oSource != null)
                        {
                            //呼叫檢查API
                            var oCheckAbsenceData = new CheckAbsenceDataDetailDao();
                            var CheckAbsenceDataCond = new CheckAbsenceDataDetailConditions();
                            CheckAbsenceDataCond.AccessToken = Cond.AccessToken;
                            CheckAbsenceDataCond.root = oSource.result;
                            var CheckData = oCheckAbsenceData.GetData(CheckAbsenceDataCond);
                            if (CheckData != null && CheckData.Data != null)
                            {
                                if (CheckData.Status)
                                {
                                    //呼叫寫入API
                                    var AbsenceDataSaveCond = new AbsenceDataSaveConditions();
                                    AbsenceDataSaveCond.AccessToken = Cond.AccessToken;
                                    AbsenceDataSaveCond.root = oSource.result;
                                    var oAbsenceDataSave = new AbsenceDataSaveDao();
                                    var SaveData = oAbsenceDataSave.GetData(AbsenceDataSaveCond);
                                    if (SaveData != null && SaveData.Data != null)
                                    {
                                        Vdb.Data = SaveData.Status.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Vdb;
        }
    }
}