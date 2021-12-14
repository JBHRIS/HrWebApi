﻿using Bll.Share.Vdb;
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
    public class ShareGetQuestionDefaultMessageByRoleKeyDao : BaseWebAPI<ShareGetQuestionDefaultMessageByRoleKeyApiRow>
    {

        public ShareGetQuestionDefaultMessageByRoleKeyDao() : base()
        {
            this.restURL = "/api/QuestionDefaultMessage/GetQuestionDefaultMessageByRoleKey";
            this.ApiSetting = "Flow";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(ShareGetQuestionDefaultMessageByRoleKeyConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            dic.Add("RoleKey", Cond.RoleKey);


            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(ShareGetQuestionDefaultMessageByRoleKeyConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            dic.Add("RoleKey", Cond.RoleKey);

            this.CompanySetting = Cond.CompanySetting;

            #endregion

            var mr = this.Send(dic, HttpMethod.Get, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(ShareGetQuestionDefaultMessageByRoleKeyConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(ShareGetQuestionDefaultMessageByRoleKeyConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as ShareGetQuestionDefaultMessageByRoleKeyApiRow;
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
                                    var rsTarget = new List<ShareGetQuestionDefaultMessageByRoleKeyRow>();

                                    //把api的Data轉成我們的Data
                                    foreach (var rSource in rsSource)
                                    {
                                        var rTarget = new ShareGetQuestionDefaultMessageByRoleKeyRow();
                                        rTarget.AutoKey = rSource.AutoKey;
                                        rTarget.CompanyId = rSource.CompanyId;
                                        rTarget.Code = rSource.Code;
                                        rTarget.Name = rSource.Name;
                                        rTarget.Contents = rSource.Contents;
                                        rTarget.RoleKey = rSource.RoleKey;
                                        rTarget.Note = rSource.Note;
                                        rTarget.Status = rSource.Status;
                                        rTarget.InsertMan = rSource.InsertMan;
                                        rTarget.InsertDate = rSource.InsertDate;
                                        rTarget.UpdateMan = rSource.UpdateMan;
                                        rTarget.UpdateDate = rSource.UpdateDate;
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