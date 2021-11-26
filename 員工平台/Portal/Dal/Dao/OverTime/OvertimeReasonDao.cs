using Bll.Employee.Vdb;
using Bll.OverTime;
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
    public class OvertimeReasonDao : BaseWebAPI<OverTimeReasonApiRow>
    {

        public OvertimeReasonDao() : base()
        {
            this.restURL = "/api/View/OverTimeView/GetOvertimeReason";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(OverTimeReasonConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult Post(OverTimeReasonConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

            var mr = this.Send(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(OverTimeReasonConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(OverTimeReasonConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as OverTimeReasonApiRow;
                        if (oSource != null)
                        {
                            if (oSource.Result.Count != 0)
                            {
                                Vdb.Status = oSource.state;
                                Vdb.Message = oSource.message;
                                Vdb.StackTrace = oSource.stackTrace;
                                var rsSource = oSource.Result;
                                var rsTarget = new List<OverTimeReasonRow>();

                                foreach (var rSource in rsSource)
                                {
                                    var rTarget = new OverTimeReasonRow();
                                    rTarget.callin = rSource.callin;
                                    rTarget.display = rSource.display;
                                    rTarget.nocalc = rSource.nocalc;
                                    rTarget.nofood = rSource.nofood;
                                    rTarget.otrcd1 = rSource.otrcd1;
                                    rTarget.otrcdDisp = rSource.otrcdDisp;
                                    rTarget.otrname = rSource.otrname;
                                    rTarget.sort = rSource.sort;
                                    rTarget.sysOt = rSource.sysOt;
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