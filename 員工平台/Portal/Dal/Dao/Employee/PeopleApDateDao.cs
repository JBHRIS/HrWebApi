﻿using Bll.Employee.Vdb;
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

namespace Dal.Dao.Employee
{
    public class PeopleApDateDao : BaseWebAPI<PeopleApDateApiRow>
    {

        public PeopleApDateDao() : base()
        {
            this.restURL = "/Employee/GetPeopleApDate";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(PeopleApDateConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

            var mr = await this.SendAsync(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(PeopleApDateConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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
            dic.Add("BeginDate", Cond.BeginDate.ToString("yyyy/MM/dd"));
            dic.Add("EndDate", Cond.EndDate.ToString("yyyy/MM/dd"));
            #endregion

            var mr = this.Send(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(PeopleApDateConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = await PostAsync(Cond, cancellationToken);
            if (Vdb.Status)
            {
                if (Vdb.Payload != null)
                {
                    //實作DTO轉換

                }
            }
            return Vdb;
        }

        public APIResult GetData(PeopleApDateConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as PeopleApDateApiRow;
                        if (oSource.result != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;
                            var rsSource = oSource.result;
                            var rsTarget = new List<PeopleApDateRow>();
                            foreach (var rSource in rsSource)
                            {
                                var rTarget = new PeopleApDateRow();
                                rTarget.EmpId = rSource.empId;
                                rTarget.IndtDate = rSource.indtDate;
                                rTarget.ApDate = rSource.apDate;
                                rsTarget.Add(rTarget);

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