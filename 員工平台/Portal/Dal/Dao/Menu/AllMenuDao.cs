using Bll.Menu.Vdb;
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

namespace Dal.Dao.Menu
{
    public class AllMenuDao : BaseWebAPI<AllMenuApiRow>
    {

        public AllMenuDao() : base()
        {
            this.restURL = "/api/Menu/GetAllMenu";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(AllMenuConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            dic.Add("code", Cond.code);
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Get,RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(AllMenuConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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
            dic.Add("code", Cond.code);
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond));
            #endregion

            var mr = this.Send(dic, HttpMethod.Get,RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(AllMenuConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
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

        public APIResult GetData(AllMenuConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as AllMenuApiRow;
                        if (oSource != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;
                            var rsSource = oSource;
                            var rsTarget = new List<AllMenuRow>();

                            foreach (var rSource in rsSource.result)
                            {
                                
                                var rTarget = new AllMenuRow();
                                rTarget.TypeCode = "";
                                rTarget.TypeName = rSource.iconName;
                                rTarget.Code = rSource.code;
                                rTarget.FilePath = "";
                                rTarget.FileName = rSource.sFileName;
                                rTarget.FileTitle = rSource.sFileTitle;
                                rTarget.RoleKey = 0;
                                rTarget.ParentCode = rSource.sParentKey;
                                rTarget.PathCode = rSource.sidePath;
                                rTarget.PathName = rSource.sPath;
                                rTarget.Order = rSource.iOrder;
                                rTarget.tag = rSource.tag;
                                rTarget.IsAuth = true;
                                rTarget.OpenNewWin = rSource.openNewWin;

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