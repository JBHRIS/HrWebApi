using Bll.Flow.Vdb;
using Bll.Token.Vdb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Flow
{
    public class FormsAppAbnByProcessIdDao : BaseWebAPI<FormsAppAbnByProcessIdApiRow>
    {

        public FormsAppAbnByProcessIdDao() : base()
        {
            this.restURL = "/api/FormsAppAbn/GetFormsAppAbnByProcessId";
            this.ApiSetting = "Flow";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(FormsAppAbnByProcessIdConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult Post(FormsAppAbnByProcessIdConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public async Task<APIResult> GetDataAsync(FormsAppAbnByProcessIdConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(FormsAppAbnByProcessIdConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        var oSource = Vdb.Data as FormsAppAbnByProcessIdApiRow;

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
                                    var rsTarget = new FormsAppAbnByProcessIdRow();
                                    rsTarget.EmpID = rsSource[0].EmpId;
                                    rsTarget.EmpCode = rsSource[0].Code;
                                    rsTarget.EmpNameC = rsSource[0].EmpName;
                                    //rsTarget.State = rsSource.State;
                                    //rsTarget.Cond1 = rsSource.Cond1;
                                    //rsTarget.Cond2 = rsSource.Cond2;
                                    //rsTarget.Cond3 = rsSource.Cond3;
                                    //rsTarget.Cond4 = rsSource.Cond4;
                                    //rsTarget.Cond5 = rsSource.Cond5;
                                    //rsTarget.Cond6 = rsSource.Cond6;
                                    //rsTarget.Day = rsSource.Day;
                                    //rsTarget.HoliDayID = rsSource.HoliDayID;
                                    rsTarget.FlowApps = new List<FlowAbnData>();
                                    rsTarget.FlowApps = rsSource;
                                    //把api的Data轉成我們的Data
                                    //foreach (var rsFlowApps in rsSource)
                                    //{
                                    //    var rFlowApps = new FlowAbnData();
                                    //    rFlowApps.AutoKey = rsFlowApps.AutoKey.ToString();
                                    //    rFlowApps.AbscDateB = rsFlowApps.DateB;
                                    //    rFlowApps.AbscDateE = rsFlowApps.DateE;
                                    //    rFlowApps.ProcessId = rsFlowApps.ProcessID.ToString();
                                    //    rFlowApps.EmpId = rsFlowApps.EmpID;
                                    //    rFlowApps.EmpName = rsFlowApps.EmpName;
                                    //    rFlowApps.DeptCode = rsFlowApps.DeptCode;
                                    //    rFlowApps.DeptName = rsFlowApps.DeptName;
                                    //    rFlowApps.JobCode = rsFlowApps.JobCode;
                                    //    rFlowApps.JobName = rsFlowApps.JobName;
                                    //    rFlowApps.RoteID = rsFlowApps.RoteID;
                                    //    rFlowApps.AbscTimeB = rsFlowApps.TimeB;
                                    //    rFlowApps.AbscTimeE = rsFlowApps.TimeE;
                                    //    rFlowApps.HolidayName = rsFlowApps.HolidayName;
                                    //    rFlowApps.Use = rsFlowApps.Use;
                                    //    rFlowApps.UnitCode = rsFlowApps.UnitCode;
                                    //    rFlowApps.IsExceptionUse = rsFlowApps.IsExceptionUse;
                                    //    rFlowApps.ExceptionUse = rsFlowApps.ExceptionUse;
                                    //    rFlowApps.Sign = rsFlowApps.Sign;
                                    //    rFlowApps.SignState = rsFlowApps.SignState;
                                    //    rFlowApps.Note = rsFlowApps.Note;
                                    //    rFlowApps.Status = rsFlowApps.Status;

                                    //    rsTarget.FlowApps.Add(rFlowApps);
                                    //}
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
