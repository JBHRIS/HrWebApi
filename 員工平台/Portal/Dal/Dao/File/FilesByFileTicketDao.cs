﻿using Bll.Files.Vdb;
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

namespace Dal.Dao.Files
{
    public class FilesByFileTicketDao : BaseWebAPI<FilesByFileTicketApiRow>
    {

        public FilesByFileTicketDao() : base()
        {
            this.restURL = "/api/Files/GetFilesByFileTicket";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(FilesByFileTicketConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            dic.Add("fileTicket", Cond.fileTicket);
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Post,RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(FilesByFileTicketConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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
            dic.Add("fileTicket", Cond.fileTicket);
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            #endregion

            var mr = this.Send(dic, HttpMethod.Post,RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(FilesByFileTicketConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(FilesByFileTicketConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as FilesByFileTicketApiRow;
                        if (oSource != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;
                            var rsSource = oSource;
                            var rsTarget = new List<FilesByFileTicketRow>();

                            foreach (var rSource in rsSource.result)
                            {
                                
                                var rTarget = new FilesByFileTicketRow();
                                rTarget.FileId = rSource.fileGuid;
                                rTarget.FileName = rSource.fileName;
                                rTarget.FileSize = rSource.fileSize.ToString();
                                rTarget.FileGuid = rSource.fileGuid;
                                rTarget.ContentType = rSource.contentType;

                                rsTarget.Add(rTarget);
                                
                            }
                            Vdb.Data = rsTarget;
                        }
                    }
                }
            }

            return Vdb;
        }
    }
}