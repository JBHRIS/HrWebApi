using Bll.Flow.Vdb;
using Bll.Token.Vdb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Flow
{
    public class FormAppOtDao : BaseWebAPI<FormAppOtApiRow>
    {

        public FormAppOtDao() : base()
        {
            this.restURL = "/api/FormsAppOT/GetFormsAppOTByProcessId";
            this.ApiSetting = "Flow";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(FormAppOtConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult Post(FormAppOtConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public async Task<APIResult> GetDataAsync(FormAppOtConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(FormAppOtConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        var oSource = Vdb.Data as FormAppOtApiRow;

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
                                    var rsTarget = new FormAppOtRow();
                                    rsTarget.EmpID = rsSource.EmpID;
                                    rsTarget.EmpCode = rsSource.EmpCode;
                                    rsTarget.EmpNameC = rsSource.EmpNameC;
                                    rsTarget.State = rsSource.State;
                                    rsTarget.Cond1 = rsSource.Cond1;
                                    rsTarget.Cond2 = rsSource.Cond2;
                                    rsTarget.Cond3 = rsSource.Cond3;
                                    rsTarget.Cond4 = rsSource.Cond4;
                                    rsTarget.Cond5 = rsSource.Cond5;
                                    rsTarget.Cond6 = rsSource.Cond6;
                                    rsTarget.Amount = rsSource.Amount;
                                    rsTarget.RoteID = rsSource.RoteID;
                                    rsTarget.FlowApps = new List<FlowAppOt>();
                                    //把api的Data轉成我們的Data
                                    foreach (var rsFlowApps in rsSource.FlowApps)
                                    {
                                        var rFlowApps = new FlowAppOt();
                                        rFlowApps.AutoKey = rsFlowApps.AutoKey;
                                        rFlowApps.Code = rsFlowApps.Code;
                                        rFlowApps.ProcessID = rsFlowApps.ProcessID;
                                        rFlowApps.EmpID = rsFlowApps.EmpID;
                                        rFlowApps.EmpName = rsFlowApps.EmpName;
                                        rFlowApps.DeptCode = rsFlowApps.DeptCode;
                                        rFlowApps.DeptName = rsFlowApps.DeptName;
                                        rFlowApps.JobCode = rsFlowApps.JobCode;
                                        rFlowApps.JobName = rsFlowApps.JobName;
                                        rFlowApps.RoteID = rsFlowApps.RoteID;
                                        rFlowApps.DateTimeB1 = rsFlowApps.DateTimeB1;
                                        rFlowApps.DateTimeE1 = rsFlowApps.DateTimeE1;
                                        rFlowApps.DateB1 = rsFlowApps.DateB1;
                                        rFlowApps.DateE1 = rsFlowApps.DateE1;
                                        rFlowApps.TimeB1 = rsFlowApps.TimeB1;
                                        rFlowApps.TimeE1 = rsFlowApps.TimeE1;
                                        rFlowApps.DateTimeB = rsFlowApps.DateTimeB;
                                        rFlowApps.DateTimeE = rsFlowApps.DateTimeE;
                                        rFlowApps.DateB = rsFlowApps.DateB;
                                        rFlowApps.DateE = rsFlowApps.DateE;
                                        rFlowApps.TimeB = rsFlowApps.TimeB;
                                        rFlowApps.TimeE = rsFlowApps.TimeE;
                                        rFlowApps.RoteCode = rsFlowApps.RoteCode;
                                        rFlowApps.RoteName = rsFlowApps.RoteName;
                                        rFlowApps.RotehCode = rsFlowApps.RotehCode;
                                        rFlowApps.RotehName = rsFlowApps.RotehName;
                                        rFlowApps.OtCateCode = rsFlowApps.OtCateCode;
                                        rFlowApps.OtCateName = rsFlowApps.OtCateName;
                                        rFlowApps.OtrcdCode = rsFlowApps.OtrcdCode;
                                        rFlowApps.OtrcdName = rsFlowApps.OtrcdName;
                                        rFlowApps.DeptsCode = rsFlowApps.DeptsCode;
                                        rFlowApps.DeptsName = rsFlowApps.DeptsName;
                                        rFlowApps.Use = rsFlowApps.Use;
                                        rFlowApps.UnitCode = rsFlowApps.UnitCode;
                                        rFlowApps.IsExceptionUse = rsFlowApps.IsExceptionUse;
                                        rFlowApps.ExceptionUse = rsFlowApps.ExceptionUse;
                                        rFlowApps.Sign = rsFlowApps.Sign;
                                        rFlowApps.SignState = rsFlowApps.SignState;
                                        rFlowApps.Note = rsFlowApps.Note;
                                        rFlowApps.Status = rsFlowApps.Status;
                                        rFlowApps.InsertMan = rsFlowApps.InsertMan;
                                        rFlowApps.InsertDate = rsFlowApps.InsertDate;
                                        rFlowApps.UpdateMan = rsFlowApps.UpdateMan;
                                        rFlowApps.UpdateDate = rsFlowApps.UpdateDate;

                                        rsTarget.FlowApps.Add(rFlowApps);
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
