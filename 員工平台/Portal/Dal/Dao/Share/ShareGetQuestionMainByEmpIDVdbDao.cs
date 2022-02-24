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
    public class ShareGetQuestionMainByEmpIDDao : BaseWebAPI<ShareGetQuestionMainByEmpIDApiRow>
    {

        public ShareGetQuestionMainByEmpIDDao() : base()
        {
            this.restURL = "/api/QuestionMain/GetQuestionMainByEmpID";
            this.ApiSetting = "Flow";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(ShareGetQuestionMainByEmpIDConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            dic.Add("CompanyID", Cond.CompanyID);
            dic.Add("sNobr", Cond.EmpId);
          
            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(ShareGetQuestionMainByEmpIDConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            if(Cond.CompanyID != "")
            dic.Add("CompanyID", Cond.CompanyID);
            dic.Add("sNobr", Cond.EmpId);
            this.CompanySetting = Cond.CompanySetting;

            #endregion

            var mr = this.Send(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(ShareGetQuestionMainByEmpIDConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(ShareGetQuestionMainByEmpIDConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as ShareGetQuestionMainByEmpIDApiRow;
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
                                    var rsTarget = new List<ShareGetQuestionMainByEmpIDRow>();

                                    //把api的Data轉成我們的Data
                                    foreach (var rSource in rsSource)
                                    {
                                        var rTarget = new ShareGetQuestionMainByEmpIDRow();
                                        rTarget.AutoKey = rSource.AutoKey;
                                        rTarget.Code = rSource.Code;
                                        rTarget.CompanyId = rSource.CompanyId;
                                        rTarget.Complete = rSource.Complete;
                                        if (rSource.Complete)
                                        {
                                            rTarget.CompleteStatus = "已結單";
                                        }
                                        else
                                        {
                                            rTarget.CompleteStatus = "尚未結單";
                                        }
                                        //else if (!rSource.Complete && rSource.DateE.AddDays(7).Date > DateTime.Now.Date)
                                        //{
                                        //    rTarget.CompleteStatus = "尚未結單";
                                        //}
                                        //else
                                        //{
                                        //    rTarget.CompleteStatus = "已失效";
                                        //}
                                        rTarget.Content = rSource.Content;
                                        rTarget.DateE = rSource.DateE;
                                        rTarget.InsertDate = rSource.InsertDate;
                                        rTarget.InsertMan = rSource.InsertMan;
                                        rTarget.IpAddress = rSource.IpAddress;
                                        rTarget.Key1 = rSource.Key1;
                                        rTarget.Key2 = rSource.Key2;
                                        rTarget.Key3 = rSource.Key3;
                                        rTarget.Name = rSource.Name;
                                        rTarget.Note = rSource.Note;
                                        rTarget.QuestionCategoryCode = rSource.QuestionCategoryCode;
                                        rTarget.QuestionCategoryName = rSource.QuestionCategoryName;
                                        rTarget.Status = rSource.Status;
                                        rTarget.SystemCategoryCode = rSource.SystemCategoryCode;
                                        rTarget.TitleContent = rSource.TitleContent;
                                        rTarget.UpdateDate = rSource.UpdateDate;
                                        rTarget.UpdateMan = rSource.UpdateMan;
                                        rsTarget.Add(rTarget);
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