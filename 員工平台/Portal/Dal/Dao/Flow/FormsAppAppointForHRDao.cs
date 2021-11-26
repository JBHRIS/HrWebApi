using Bll.Flow.Vdb;
using Bll.Token.Vdb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Flow
{
    public class FormsAppAppointForHRDao : BaseWebAPI<FormsAppAppointForHRApiRow>
    {

        public FormsAppAppointForHRDao() : base()
        {
            this.restURL = "/api/FormsAppAppoint/GetFormsAppAppointForHR";
            this.ApiSetting = "Flow";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(FormsAppAppointForHRConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult Post(FormsAppAppointForHRConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public async Task<APIResult> GetDataAsync(FormsAppAppointForHRConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(FormsAppAppointForHRConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        var oSource = Vdb.Data as FormsAppAppointForHRApiRow;

                        if (oSource != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;

                            if (oSource.state)
                            {
                                var rTarget = new List<FormsAppAppointForHRRow>();
                                if (oSource.Result != null)
                                {
                                    foreach (var rsSource in oSource.Result)
                                    {
                                        var rsTarget = new FormsAppAppointForHRRow();
                                        rsTarget.EmpID = rsSource.EmpId;
                                        rsTarget.Code = rsSource.Code;
                                        rsTarget.ProcessId = rsSource.ProcessId;
                                        rsTarget.EmpName = rsSource.EmpName;
                                        rsTarget.ProcessApParm = rsSource.ProcessApParm;
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
                                        rTarget.Add(rsTarget);
                                    }
                                }
                                Vdb.Data = rTarget;
                            }
                        }
                    }
                }
            }

            return Vdb;
        }
    }
}
