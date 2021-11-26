﻿using Bll.Token.Vdb;
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
    public class CheckAbsenceDataDetailDao : BaseWebAPI<CheckAbsenceDataDetailApiRow>
    {

        public CheckAbsenceDataDetailDao() : base()
        {
            this.restURL = "/api/Absence/CheckAbsenceDataDetail";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> GetAsync(CheckAbsenceDataDetailConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult Get(CheckAbsenceDataDetailConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond.root));
            #endregion

            var mr = this.Send(dic, HttpMethod.Post,RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(CheckAbsenceDataDetailConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(CheckAbsenceDataDetailConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Get(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as CheckAbsenceDataDetailApiRow;
                        if (oSource != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;

                            if (oSource.state)
                            {
                                var rsTarget = new CheckAbsenceDataDetailRow();

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