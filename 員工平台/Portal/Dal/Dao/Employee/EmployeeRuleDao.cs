using Bll.Flow.Vdb;
using Bll.Token.Vdb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Flow
{
    public class EmployeeRuleDao : BaseWebAPI<EmployeeRuleApiRow>
    {

        public EmployeeRuleDao() : base()
        {
            this.restURL = "/Employee/GetEmployeeRule";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(EmployeeRuleConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult Post(EmployeeRuleConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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
            this.CompanySetting = Cond.CompanySetting;
            #endregion

            var mr = this.Send(dic, HttpMethod.Post, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(EmployeeRuleConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(EmployeeRuleConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        var oSource = Vdb.Data as EmployeeRuleApiRow;

                        if (oSource.state)
                        {
                            if (oSource.result != null)
                            {
                                var rsSource = oSource.result;
                                var rsTarget = new List<EmployeeRuleRow>();

                                //把api的Data轉成我們的Data
                                foreach (var rSource in rsSource)
                                {
                                    var rTarget = new EmployeeRuleRow()
                                    {
                                        auto = rSource.auto,
                                        nobr = rSource.nobr,
                                        ruleType = rSource.ruleType,
                                        beginDate = rSource.beginDate,
                                        endDate = rSource.endDate,
                                        value = rSource.value,
                                        remark = rSource.remark,
                                        keyDate = rSource.keyDate,
                                        keyMan = rSource.keyMan
                                    };
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
