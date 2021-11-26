using Bll.Files.Vdb;
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
    public class ImportAttendExcelCoverDao : BaseWebAPI<ImportAttendExcelCoverApiRow>
    {

        public ImportAttendExcelCoverDao() : base()
        {
            this.restURL = "/api/Files/ImportAttendExcelCover";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.MULTIPART;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(ImportAttendExcelCoverConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            //FileData = Cond.file;
            //dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Post, RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(ImportAttendExcelCoverConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            dic.Add("SheetName",Cond.SheetName);
            this.CompanySetting = Cond.CompanySetting;
            #endregion
            this.ObjFile = Cond.file;
            this.FileName = "file";
            var mr = this.Send(dic, HttpMethod.Post, RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(ImportAttendExcelCoverConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(ImportAttendExcelCoverConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as ImportAttendExcelCoverApiRow;
                        if (oSource != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;
                            var rsSource = oSource;
                            var rsTarget = new ImportAttendExcelCoverRow();

                            var Data = rsSource.result.Where(p => p.WorkScheduleIssues.Count != 0).ToList();
                            rsTarget.Result = oSource.message;
                            foreach (var m in Data)
                            {
                                Vdb.Status = false;
                                rsTarget.Result += m.Message;
                                if (m.WorkScheduleIssues.Count > 0)
                                {
                                    rsTarget.Result += m.Nobr + "  ";
                                    var Issue = m.WorkScheduleIssues[0];
                                    rsTarget.Result += Issue.ErrorMessage + "   <br/>";
                                }
                                //foreach (var Issue in m.WorkScheduleIssues)
                                //{ 
                                //    rsTarget.Result += Issue.IssueDate.ToString("yyyyMMdd") + Issue.ErrorMessage;
                                //}
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