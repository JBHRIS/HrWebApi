using Bll.Flow.Vdb;
using Bll.Token.Vdb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Flow
{
    public class FormsAppAbscDao : BaseWebAPI<FormsAppAbscApiRow>
    {

        public FormsAppAbscDao() : base()
        {
            this.restURL = "/api/FormsAppAbsc/GetFormAppAbsc";
            this.ApiSetting = "Flow";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(FormsAppAbscConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

            var mr = await this.SendAsync(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(FormsAppAbscConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            dic.Add("Nobr", Cond.Nobr);
            dic.Add("BDate", Cond.BDate.ToShortDateString());
            dic.Add("EDate", Cond.EDate.ToShortDateString());
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            this.CompanySetting = Cond.CompanySetting;
            #endregion

            var mr = this.Send(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(FormsAppAbscConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(FormsAppAbscConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        var oSource = Vdb.Data as FormsAppAbscApiRow;

                        if (oSource != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;

                            if (oSource.state)
                            {
                                if (oSource.result != null)
                                {
                                    var rsSource = oSource.result;
                                    var rsTarget = new List<FormsAppAbscRow>();

                                    //把api的Data轉成我們的Data
                                    foreach (var rSource in rsSource)
                                    {
                                        var rTarget = new FormsAppAbscRow()
                                        {
                                            AbscDateB = rSource.beginDate,
                                            AbscDateE = rSource.endDate,
                                            AbscTimeB = rSource.beginTime,
                                            AbscTimeE = rSource.endTime,
                                            AbscTotalTime = rSource.absenceAmount,
                                            ProcessId = rSource.idProcess,
                                            Unit = rSource.absenceUnit,
                                            HolidayName = rSource.holidayName,
                                            HolidayCode = rSource.holidayCode,
                                        };
                                        rsTarget.Add(rTarget);
                                    }
                                    Vdb.Data = rsTarget;
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
