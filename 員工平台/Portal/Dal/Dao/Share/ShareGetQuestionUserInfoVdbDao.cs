using Bll.Share.Vdb;
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

namespace Dal.Dao.Share
{
    public class ShareGetQuestionUserInfoByCodeDao : BaseWebAPI<ShareGetQuestionUserInfoByCodeApiRow>
    {

        public ShareGetQuestionUserInfoByCodeDao() : base()
        {
            this.restURL = "/api/QuestionMain/GetQuestionUserInfoByCode";
            this.ApiSetting = "Flow";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(ShareGetQuestionUserInfoByCodeConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            dic.Add("Code", Cond.Code);
            
          
            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(ShareGetQuestionUserInfoByCodeConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            dic.Add("Code", Cond.Code);
           
            this.CompanySetting = Cond.CompanySetting;

            #endregion

            var mr = this.Send(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(ShareGetQuestionUserInfoByCodeConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(ShareGetQuestionUserInfoByCodeConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as ShareGetQuestionUserInfoByCodeApiRow;
                        if (oSource != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;

                            if (oSource.state)
                            {
                                if (oSource != null)
                                {
                                    var rsSource = oSource.result;
                                    var rsTarget = new List<ShareGetQuestionUserInfoByCodeRow>();

                                    //把api的Data轉成我們的Data
                                    foreach (var rSource in rsSource)
                                    {
                                        var rTarget = new ShareGetQuestionUserInfoByCodeRow();
                                        rSource.AutoKey = rTarget.AutoKey;
                                        rSource.CompanyId = rTarget.CompanyId;
                                        rSource.Code = rTarget.Code; 
                                        rSource.AccountCode = rTarget.AccountCode; 
                                        rSource.AccountPassword = rTarget.AccountPassword;
                                        rSource.UserId = rTarget.UserId;
                                        rSource.UserName = rTarget.UserName;
                                        rSource.RoleKey = rTarget.RoleKey;
                                        rSource.Email = rTarget.Email;
                                        rSource.Content = rTarget.Content;
                                        rSource.Key1 = rTarget.Key1;
                                        rSource.Key2 = rTarget.Key2;
                                        rSource.Key3 = rTarget.Key3;
                                        rSource.DateA = rTarget.DateA;
                                        rSource.DateD = rTarget.DateD;
                                        rSource.Note = rTarget.Note;
                                        rSource.Status = rTarget.Status;
                                        rSource.InsertMan = rTarget.InsertMan;
                                        rSource.InsertDate = rTarget.InsertDate;
                                        rSource.UpdateMan = rTarget.UpdateMan;
                                        rSource.UpdateDate = rTarget.UpdateDate;
                                       
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