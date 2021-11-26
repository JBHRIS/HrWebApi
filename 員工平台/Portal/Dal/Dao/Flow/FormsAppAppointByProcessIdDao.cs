using Bll.Flow.Vdb;
using Bll.Token.Vdb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Flow
{
    public class FormsAppAppointByProcessIdDao : BaseWebAPI<FormsAppAppointByProcessIdApiRow>
    {

        public FormsAppAppointByProcessIdDao() : base()
        {
            this.restURL = "/api/FormsAppAppoint/GetFormsAppAppointByProcessId";
            this.ApiSetting = "Flow";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(FormsAppAppointByProcessIdConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult Post(FormsAppAppointByProcessIdConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public async Task<APIResult> GetDataAsync(FormsAppAppointByProcessIdConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(FormsAppAppointByProcessIdConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        var oSource = Vdb.Data as FormsAppAppointByProcessIdApiRow;

                        if (oSource != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;

                            if (oSource.state)
                            {
                                if (oSource.Result != null)
                                {
                                    var rsSource = oSource.Result[0];
                                    var rsTarget = new FormsAppAppointByProcessIdRow();
                                    rsTarget.EmpID = rsSource.EmpId;
                                    rsTarget.Code = rsSource.Code;
                                    rsTarget.EmpName = rsSource.EmpName;
                                    rsTarget.DeptCode = rsSource.DeptCode;
                                    rsTarget.DeptName = rsSource.DeptName;
                                    rsTarget.DeptmCode = rsSource.DeptmCode;
                                    rsTarget.DeptmName = rsSource.DeptmName;
                                    rsTarget.JobCode = rsSource.JobCode;
                                    rsTarget.JobName = rsSource.JobName;
                                    rsTarget.JoblCode = rsSource.JoblCode;
                                    rsTarget.JoblName = rsSource.JoblName;
                                    rsTarget.RoleId = rsSource.RoleId;
                                    rsTarget.Birthday = rsSource.Birthday;
                                    rsTarget.Sex = rsSource.Sex;
                                    rsTarget.SchoolCode = rsSource.SchoolCode;
                                    rsTarget.SchoolName = rsSource.SchoolName;
                                    rsTarget.DateIn = rsSource.DateIn;
                                    rsTarget.DateA = rsSource.DateA;
                                    rsTarget.ChangeItemCode = rsSource.ChangeItemCode;
                                    rsTarget.ChangeItemName = rsSource.ChangeItemName;
                                    rsTarget.Performance1 = rsSource.Performance1;
                                    rsTarget.Performance2 = rsSource.Performance2;
                                    rsTarget.Performance3 = rsSource.Performance3;
                                    rsTarget.ReasonChange = rsSource.ReasonChange;
                                    rsTarget.Qualified = rsSource.Qualified;
                                    rsTarget.Evaluation = rsSource.Evaluation;
                                    rsTarget.DeptCodeChange = rsSource.DeptCodeChange;
                                    rsTarget.DeptNameChange = rsSource.DeptNameChange;
                                    rsTarget.DeptmCodeChange = rsSource.DeptmCodeChange;
                                    rsTarget.DeptmNameChange = rsSource.DeptmNameChange;
                                    rsTarget.JobCodeChange = rsSource.JobCodeChange;
                                    rsTarget.JobNameChange = rsSource.JobNameChange;
                                    rsTarget.JoblCodeChange = rsSource.JoblCodeChange;
                                    rsTarget.JoblNameChange = rsSource.JoblNameChange;
                                    rsTarget.AppointChangeLog = rsSource.AppointChangeLog;
                                    rsTarget.DateAppoint = rsSource.DateAppoint;
                                    rsTarget.AllowSign = rsSource.AllowSign;
                                    rsTarget.AllowSalary = rsSource.AllowSalary;
                                    rsTarget.InsertDate = rsSource.InsertDate;
                                    rsTarget.InsertMan = rsSource.InsertMan;
                                    rsTarget.UpdateDate = rsSource.UpdateDate;
                                    rsTarget.UpdateMan = rsSource.UpdateMan;
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
