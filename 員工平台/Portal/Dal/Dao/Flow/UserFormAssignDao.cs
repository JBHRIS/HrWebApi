using Bll.Flow.Vdb;
using Bll.Token.Vdb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Flow
{
    public class UserFormAssignDao : BaseWebAPI<UserFormAssignApiRow>
    {

        public UserFormAssignDao() : base()
        {
            this.restURL = "/api/FlowMainIntegrationHandle/GetFlowSignRoleFullDataByNow";
            this.ApiSetting = "Flow";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(UserFormAssignConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult Post(UserFormAssignConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public async Task<APIResult> GetDataAsync(UserFormAssignConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(UserFormAssignConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        var oSource = Vdb.Data as UserFormAssignApiRow;

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
                                    var rsTarget = new List<UserFormAssignRow>();

                                    //把api的Data轉成我們的Data
                                    foreach (var rSource in rsSource)
                                    {
                                        var rUserFormAssignRow = new UserFormAssignRow();

                                        rUserFormAssignRow.Count = rSource.Count;
                                        rUserFormAssignRow.BatchSign = rSource.BatchSign;
                                        rUserFormAssignRow.maninfo = rSource.maninfo;
                                        rUserFormAssignRow.FlowSignForm = new List<FlowSignForm>();
                                        foreach (var rsFlowSignForm in rSource.FlowSignForm)
                                        {
                                            var rFlowSignForm = new FlowSignForm();
                                            rFlowSignForm.AutoKey = rsFlowSignForm.AutoKey;
                                            rFlowSignForm.CheckNote = rsFlowSignForm.CheckNote;
                                            rFlowSignForm.Count = rsFlowSignForm.Count;
                                            rFlowSignForm.CustomNode = rsFlowSignForm.CustomNode;
                                            rFlowSignForm.DynamicNode = rsFlowSignForm.DynamicNode;
                                            rFlowSignForm.EtcNote = rsFlowSignForm.EtcNote;
                                            rFlowSignForm.FlowTreeID = rsFlowSignForm.FlowTreeID;
                                            rFlowSignForm.FormCode = rsFlowSignForm.FormCode;
                                            rFlowSignForm.FormName = rsFlowSignForm.FormName;
                                            rFlowSignForm.StdNote = rsFlowSignForm.StdNote;
                                            rFlowSignForm.TableName = rsFlowSignForm.TableName;
                                            rFlowSignForm.ViewNote = rsFlowSignForm.ViewNote;
                                            rFlowSignForm.FlowSign = new List<FlowSign>();
                                            foreach (var rsFlowSign in rsFlowSignForm.FlowSign)
                                            {
                                                var rFlowSign = new FlowSign();
                                                rFlowSign.AppDate = rsFlowSign.AppDate;
                                                rFlowSign.AppDeptID = rsFlowSign.AppDeptID;
                                                rFlowSign.AppDeptName = rsFlowSign.AppDeptName;
                                                rFlowSign.AppDeptPath = rsFlowSign.AppDeptPath;
                                                rFlowSign.AppEmpID = rsFlowSign.AppEmpID;
                                                rFlowSign.AppEmpName = rsFlowSign.AppEmpName;
                                                rFlowSign.AppRoleID = rsFlowSign.AppRoleID;
                                                rFlowSign.Batch = rsFlowSign.Batch;
                                                rFlowSign.CheckEmpID = rsFlowSign.CheckEmpID;
                                                rFlowSign.CheckRoleID = rsFlowSign.CheckRoleID;
                                                rFlowSign.ChiefCode = rsFlowSign.ChiefCode;
                                                rFlowSign.Cond1 = rsFlowSign.Cond1;
                                                rFlowSign.Cond2 = rsFlowSign.Cond2;
                                                rFlowSign.Cond3 = rsFlowSign.Cond3;
                                                rFlowSign.Cond4 = rsFlowSign.Cond4;
                                                rFlowSign.Cond5 = rsFlowSign.Cond5;
                                                rFlowSign.Cond6 = rsFlowSign.Cond6;
                                                rFlowSign.FlowNodeID = rsFlowSign.FlowNodeID;
                                                rFlowSign.FlowNodeName = rsFlowSign.FlowNodeName;
                                                rFlowSign.FlowTreeID = rsFlowSign.FlowTreeID;
                                                rFlowSign.FormCode = rsFlowSign.FormCode;
                                                rFlowSign.FormName = rsFlowSign.FormName;
                                                rFlowSign.Info = rsFlowSign.Info;
                                                rFlowSign.PendingDay = rsFlowSign.PendingDay;
                                                rFlowSign.ProcessApParmAuto = rsFlowSign.ProcessApParmAuto;
                                                rFlowSign.ProcessCheckAuto = rsFlowSign.ProcessCheckAuto;
                                                rFlowSign.ProcessFlowID = rsFlowSign.ProcessFlowID;
                                                rFlowSign.ProcessNodeAuto = rsFlowSign.ProcessNodeAuto;
                                                rFlowSign.RealAppEmpID = rsFlowSign.RealAppEmpID;
                                                rFlowSign.SignCondition = rsFlowSign.SignCondition;

                                                rFlowSignForm.FlowSign.Add(rFlowSign);
                                            }
                                            rUserFormAssignRow.FlowSignForm.Add(rFlowSignForm);
                                        }
                                        rsTarget.Add(rUserFormAssignRow);
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
