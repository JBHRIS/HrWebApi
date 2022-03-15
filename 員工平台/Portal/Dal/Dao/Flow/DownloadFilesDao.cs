using Bll.Flow.Vdb;
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
    public class DownloadByAutoKeyDao : BaseWebAPI<DownloadByAutoKeyApiRow>
    {

        public DownloadByAutoKeyDao() : base()
        {
            this.restURL = "/api/ShareUpload/DownloadByAutoKey";
            this.ApiSetting = "Flow";
            IsCollectionType = true;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(DownloadByAutoKeyConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            dic.Add("AutoKey", Cond.AutoKey.ToString());
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Get,RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(DownloadByAutoKeyConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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
            dic.Add("AutoKey", Cond.AutoKey.ToString());
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            #endregion

            var mr = this.Send(dic, HttpMethod.Get,RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(DownloadByAutoKeyConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(DownloadByAutoKeyConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        //var oSource = Vdb.Data as FilesByFileTicketApiRow;
                        //if (oSource != null)
                        //{
                        //    Vdb.Status = oSource.state;
                        //    Vdb.Message = oSource.message;
                        //    Vdb.StackTrace = oSource.stackTrace;
                        //    var rsSource = oSource;
                        //    var rsTarget = new List<FilesByFileTicketRow>();

                        //    foreach (var rSource in rsSource.result)
                        //    {
                                
                        //        var rTarget = new FilesByFileTicketRow();
                        //        rTarget.FileId = rSource.fileId;
                        //        rTarget.FileName = rSource.fileName;
                        //        rTarget.FileGuid = rSource.fileGuid;
                        //        rTarget.ContentType = rSource.contentType;

                        //        rsTarget.Add(rTarget);
                                
                        //    }
                        //    Vdb.Data = rsTarget;
                        //}
                    }
                }
            }

            return Vdb;
        }
    }
}