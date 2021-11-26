using Bll.Employee.Vdb;
using Bll.Token.Vdb;
using Bll.Tools;
using Dto.Token;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dto.Employee
{
    public class PeopleByDeptDto : BaseWebAPI<PeopleByDeptApiRow>
    {

        public PeopleByDeptDto() : base()
        {
            this.restURL = "/Employee/GetPeopleByDept";
            this.host = Constants.HostAPI;
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(PeopleByDeptConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Post, RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(PeopleByDeptConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            #endregion

            var mr = this.Send(dic, HttpMethod.Post, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(PeopleByDeptConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(PeopleByDeptConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as PeopleByDeptApiRow;
                        if (oSource.result != null)
                        {
                            var rsSource = oSource.result;
                            var rsTarget = new List<PeopleByDeptRow>();

                            foreach (var rSource in rsSource)
                            {
                                var rTarget = new PeopleByDeptRow();
                                rTarget.EmpId = rSource;
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