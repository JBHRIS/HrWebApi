using Bll.Flow.Vdb;
using Bll.Token.Vdb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Flow
{
    public class FormsAppShiftLongDao : BaseWebAPI<FormsAppShiftLongApiRow>
    {

        public FormsAppShiftLongDao() : base()
        {
            this.restURL = "/api/FormsAppShiftLong/GetFormsAppShiftLongByProcessId";
            this.ApiSetting = "Flow";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(FormsAppShiftLongConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            dic.Add("ProcessFlowID", Cond.ProcessFlowID);
            dic.Add("Sign", Cond.Sign.ToString());
            dic.Add("SignState", Cond.SignState);
            dic.Add("Status", Cond.Status);
            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(FormsAppShiftLongConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            dic.Add("ProcessFlowID", Cond.ProcessFlowID);
            dic.Add("Sign", Cond.Sign.ToString().ToLower());
            dic.Add("SignState", Cond.SignState);
            dic.Add("Status", Cond.Status);
            this.CompanySetting = Cond.CompanySetting;
            #endregion

            var mr = this.Send(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(FormsAppShiftLongConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(FormsAppShiftLongConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        var oSource = Vdb.Data as FormsAppShiftLongApiRow;

                        if (oSource != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;

                            if (oSource.state)
                            {
                                if (oSource.Result != null)
                                {
                                    var rsSource = oSource.Result;
                                    var rsTarget = new List<FormsAppShiftLongRow>();
                                    //把api的Data轉成我們的Data
                                    foreach (var rsFlowApps in rsSource)
                                    {
                                        var rFlowApps = new FormsAppShiftLongRow();
                                        rFlowApps.AutoKey = rsFlowApps.AutoKey;
                                        rFlowApps.Code = rsFlowApps.Code;
                                        rFlowApps.ProcessId = rsFlowApps.ProcessId;
                                        rFlowApps.EmpId = rsFlowApps.EmpId;
                                        rFlowApps.EmpName = rsFlowApps.EmpName;
                                        rFlowApps.DeptCode = rsFlowApps.DeptCode;
                                        rFlowApps.DeptName = rsFlowApps.DeptName;
                                        rFlowApps.JobCode = rsFlowApps.JobCode;
                                        rFlowApps.JobName = rsFlowApps.JobName;
                                        rFlowApps.Date = rsFlowApps.Date;
                                        rFlowApps.RotetCode = rsFlowApps.RotetCode;
                                        rFlowApps.RotetName = rsFlowApps.RotetName;
                                        rFlowApps.RotetCodeOrigin = rsFlowApps.RotetCodeOrigin;
                                        rFlowApps.RotetNameOrigin = rsFlowApps.RotetNameOrigin;
                                        rFlowApps.Sign = rsFlowApps.Sign;
                                        rFlowApps.SignState = rsFlowApps.SignState;
                                        rFlowApps.Status = rsFlowApps.Status;
                                        rFlowApps.Note = rsFlowApps.Note;
                                        rFlowApps.InsertMan = rsFlowApps.InsertMan;
                                        rFlowApps.InsertDate = rsFlowApps.InsertDate;
                                        rFlowApps.UpdateMan = rsFlowApps.UpdateMan;
                                        rFlowApps.UpdateDate = rsFlowApps.UpdateDate;

                                        rsTarget.Add(rFlowApps);
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
