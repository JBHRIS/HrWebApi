using Bll.Flow.Vdb;
using Bll.Token.Vdb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Flow
{
    public class FormsAppEmployByProcessIdDao : BaseWebAPI<FormsAppEmployByProcessIdApiRow>
    {

        public FormsAppEmployByProcessIdDao() : base()
        {
            this.restURL = "/api/FormsAppEmploy/GetFormsAppEmployByProcessId";
            this.ApiSetting = "Flow";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(FormsAppEmployByProcessIdConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult Post(FormsAppEmployByProcessIdConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public async Task<APIResult> GetDataAsync(FormsAppEmployByProcessIdConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(FormsAppEmployByProcessIdConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        var oSource = Vdb.Data as FormsAppEmployByProcessIdApiRow;

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
                                    var rsTarget = new FormsAppEmployByProcessIdRow();
                                    rsTarget.EmpID = rsSource.EmpId;
                                    rsTarget.EmpCode = rsSource.Code;
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
                                    rsTarget.DateD = rsSource.DateD;
                                    rsTarget.WorkExperience = rsSource.WorkExperience;
                                    rsTarget.AttendContent = rsSource.AttendContent;
                                    rsTarget.DeptCodeChange = rsSource.DeptCodeChange;
                                    rsTarget.DeptNameChange = rsSource.DeptNameChange;
                                    rsTarget.DeptmCodeChange = rsSource.DeptmCodeChange;
                                    rsTarget.DeptmNameChange = rsSource.DeptmNameChange;
                                    rsTarget.JobCodeChange = rsSource.JobCodeChange;
                                    rsTarget.JobNameChange = rsSource.JobNameChange;
                                    rsTarget.JoblCodeChange = rsSource.JoblCodeChange;
                                    rsTarget.JoblNameChange = rsSource.JoblNameChange;
                                    rsTarget.ChangeLogs = rsSource.EmployChangeLog;
                                    rsTarget.ResultAreaCode = rsSource.ResultAreaCode;
                                    rsTarget.ResultAreaName = rsSource.ResultAreaName;
                                    rsTarget.ExtendMonth = rsSource.ExtendMonth;
                                    rsTarget.DateAppoint = rsSource.DateAppoint;
                                    rsTarget.AllowSign = rsSource.AllowSign;
                                    rsTarget.AllowSalary = rsSource.AllowSalary;
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
