using Bll.Flow.Vdb;
using Bll.Token.Vdb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Flow
{
    public class FormAppAbsDao : BaseWebAPI<FormAppAbsApiRow>
    {

        public FormAppAbsDao() : base()
        {
            this.restURL = "/api/FormsAppAbs/GetFormsAppAbsByProcessId";
            this.ApiSetting = "Flow";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(FormAppAbsConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult Post(FormAppAbsConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public async Task<APIResult> GetDataAsync(FormAppAbsConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(FormAppAbsConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        var oSource = Vdb.Data as FormAppAbsApiRow;

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
                                    var rsTarget = new FormAppAbsRow();
                                    rsTarget.Cond1 = rsSource.Cond1;
                                    rsTarget.Cond2 = rsSource.Cond2;
                                    rsTarget.Cond3 = rsSource.Cond3;
                                    rsTarget.Cond4 = rsSource.Cond4;
                                    rsTarget.Cond5 = rsSource.Cond5;
                                    rsTarget.Cond6 = rsSource.Cond6;
                                    rsTarget.Day = rsSource.Day;
                                    rsTarget.EmpCode = rsSource.EmpCode;
                                    rsTarget.EmpID = rsSource.EmpID;
                                    rsTarget.EmpNameC = rsSource.EmpNameC;
                                    rsTarget.HoliDayID = rsSource.HoliDayID;
                                    rsTarget.State = rsSource.State;
                                    rsTarget.FlowApps = new List<FlowAppAbs>();

                                    //把api的Data轉成我們的Data
                                    foreach (var rsFlowApps in rsSource.FlowApps)
                                    {
                                        var rFlowApps = new FlowAppAbs();
                                        rFlowApps.AgentEmpName = rsFlowApps.AgentEmpName;
                                        rFlowApps.AgentEmpId = rsFlowApps.AgentEmpId;
                                        rFlowApps.AgentNote = rsFlowApps.AgentNote;
                                        rFlowApps.AppEmpCode = rsFlowApps.AppEmpCode;
                                        rFlowApps.Appointment = rsFlowApps.Appointment;
                                        rFlowApps.AutoKey = rsFlowApps.AutoKey;
                                        rFlowApps.Balance = rsFlowApps.Balance;
                                        rFlowApps.BaseHours = rsFlowApps.BaseHours;
                                        rFlowApps.IsCirculate = rsFlowApps.IsCirculate;
                                        rFlowApps.DateB = rsFlowApps.DateB;
                                        rFlowApps.DateE = rsFlowApps.DateE;
                                        rFlowApps.DateTimeB = rsFlowApps.DateTimeB;
                                        rFlowApps.DateTimeE = rsFlowApps.DateTimeE;
                                        rFlowApps.Day = rsFlowApps.Day;
                                        rFlowApps.DeptCode = rsFlowApps.DeptCode;
                                        rFlowApps.DeptName = rsFlowApps.DeptName;
                                        rFlowApps.EmpCode = rsFlowApps.EmpCode;
                                        rFlowApps.EmpID = rsFlowApps.EmpID;
                                        rFlowApps.EmpName = rsFlowApps.EmpName;
                                        rFlowApps.EventDate = rsFlowApps.EventDate;
                                        rFlowApps.HolidayCode = rsFlowApps.HolidayCode;
                                        rFlowApps.HoliDayIsNotRefRote = rsFlowApps.HoliDayIsNotRefRote;
                                        rFlowApps.HolidayName = rsFlowApps.HolidayName;
                                        rFlowApps.UnitCode = rsFlowApps.UnitCode;
                                        rFlowApps.Info = rsFlowApps.Info;
                                        rFlowApps.JobName = rsFlowApps.JobName;
                                        rFlowApps.Key = rsFlowApps.Key;
                                        rFlowApps.KeyName = rsFlowApps.KeyName;
                                        rFlowApps.MailBody = rsFlowApps.MailBody;
                                        rFlowApps.Note = rsFlowApps.Note;
                                        rFlowApps.ProcessID = rsFlowApps.ProcessID;
                                        rFlowApps.RoteID = rsFlowApps.RoteID;
                                        rFlowApps.Serno = rsFlowApps.Serno;
                                        rFlowApps.sGuid = rsFlowApps.sGuid;
                                        rFlowApps.Sign = rsFlowApps.Sign;
                                        rFlowApps.SignState = rsFlowApps.SignState;
                                        rFlowApps.Status = rsFlowApps.Status;
                                        rFlowApps.TimeB = rsFlowApps.TimeB;
                                        rFlowApps.TimeE = rsFlowApps.TimeE;
                                        rFlowApps.Today = rsFlowApps.Today;
                                        rFlowApps.Use = rsFlowApps.Use;
                                        rFlowApps.Code = rsFlowApps.Code;

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
