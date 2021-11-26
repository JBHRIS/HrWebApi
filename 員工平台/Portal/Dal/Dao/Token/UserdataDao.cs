using Bll.Token.Vdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Token
{
    public class UserdataDao : BaseWebAPI<UserdataApiRow>
    {

        public UserdataDao() : base()
        {
            this.restURL = "/userdata";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = false;
        }

        public async Task<APIResult> GetAsync(UserdataConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            #endregion

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            var mr = await this.SendAsync(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Get(UserdataConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            #endregion

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";
            this.CompanySetting = Cond.CompanySetting;
            var mr = this.Send(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(UserdataConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = await this.GetAsync(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Payload != null)
                {
                    var rSource = Vdb.Data as UserdataApiRow;

                    var rTarget = new UserdataRow();
                    rTarget.EmpId = rSource.UserId;
                    rTarget.EmpName = rSource.UserName;
                    rTarget.CompanyCode = rSource.Company;
                    rTarget.JobName = rSource.JobName;
                    rTarget.DeptName = rSource.DepartmentName;
                    rTarget.DeptCode = new List<string>();
                    rTarget.DeptCode.Add(rSource.Department);
                    foreach (var DepartmentCode in rSource.DepartmentExtra)
                    {
                        rTarget.DeptCode.Add(DepartmentCode);
                    }
                    rTarget.ListDataGroupsCode = rSource.DataGroups;

                    //把api的dto(Data)轉成我們的dto(Data)
                    Vdb.Data = rTarget;
                }
            }

            return Vdb;
        }

        public APIResult GetData(UserdataConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = this.Get(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Payload != null)
                {
                    var rSource = Vdb.Data as UserdataApiRow;

                    var rTarget = new UserdataRow();
                    rTarget.EmpId = rSource.UserId;
                    rTarget.EmpName = rSource.UserName;
                    rTarget.CompanyCode = rSource.Company;
                    rTarget.DeptName = rSource.DepartmentName;
                    rTarget.JobName = rSource.JobName;
                    rTarget.Dept = rSource.Department;
                    rTarget.DeptCode = new List<string>();
                    rTarget.DeptCode.Add(rSource.Department);
                    foreach (var DepartmentCode in rSource.DepartmentExtra)
                    {
                        rTarget.DeptCode.Add(DepartmentCode);
                    }
                    rTarget.ListDataGroupsCode = rSource.DataGroups;
                    rTarget.Role = rSource.Role;
                    rTarget.Connection = rSource.Connection;

                    //把api的dto(Data)轉成我們的dto(Data)
                    Vdb.Data = rTarget;
                }
            }

            return Vdb;
        }
    }
}