using Bll;
using Bll.Share.Vdb;
using Bll.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dao.Share
{
    /// <summary>
    /// 
    /// </summary>
    public class ShareDefaultDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public ShareDefaultDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public ShareDefaultDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public ShareDefaultDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public ShareDefaultDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得共用參數
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List ShareDefaultRow</returns>
        public List<ShareDefaultRow> GetShareDefault(ShareDefaultConditions Cond)
        {
            //資料狀態
            var ListStatus = Cond.ListStatus;
            //搜尋條件
            //自動編號
            var AutoKey = Cond.AutoKey;
            //代碼
            var Code = Cond.Code;
            //群組代碼
            var GroupCode = Cond.GroupCode;

            var VdbSql = (from c in dcShare.ShareDefault
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((c.SystemCode == "Share" || c.SystemCode == _SystemCode))
                          && ((GroupCode.Length == 0) || (c.GroupCode == GroupCode))
                          orderby c.Sort
                          select new ShareDefaultRow
                          {
                              AutoKey = c.AutoKey,
                              SystemCode = c.SystemCode,
                              GroupCode = c.GroupCode,
                              Code = c.Code,
                              Name = c.Name,
                              FieldKey = c.FieldKey,
                              FieldValue = c.FieldValue,
                              ColumnTypeCode = c.ColumnTypeCode,
                              ColumnTypeName = "",
                              FormTypeCode = c.FormTypeCode,
                              FormTypeName = "",
                              SystemUse = c.SystemUse,
                              Sort = c.Sort,
                              Note = c.Note,
                              Status = c.Status,
                              InsertMan = c.InsertMan,
                              InsertDate = c.InsertDate.GetValueOrDefault(_DefDate),
                              UpdateMan = c.UpdateMan,
                              UpdateDate = c.UpdateDate.GetValueOrDefault(_DefDate),
                          });

            var Vdb = VdbSql.ToList();

            //處理代碼資料
            var rsColumnType = ShareCodeNameCode("DataType");
            var rsFormType = ShareCodeNameCode("FormType");
            foreach (var rVdb in Vdb)
            {
                rVdb.ColumnTypeName = rsColumnType.FirstOrDefault(p => p.Code == rVdb.ColumnTypeCode)?.Name ?? rVdb.ColumnTypeName;
                rVdb.FormTypeName = rsColumnType.FirstOrDefault(p => p.Code == rVdb.FormTypeCode)?.Name ?? rVdb.FormTypeName;
            }

            return Vdb;
        }

        /// <summary>
        /// 取得共用參數
        /// </summary>
        /// <param name="GroupCode"></param>
        /// <returns>List NameCodeRow</returns>
        public List<NameCodeRow> GetNameCode(string GroupCode = "")
        {
            var Vdb = (from c in dcShare.ShareDefault
                       where (c.SystemCode == "Share" || c.SystemCode == _SystemCode)
                       && c.GroupCode == GroupCode
                       select new NameCodeRow
                       {
                           Name = c.Name,
                           Code = c.Code,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得共用參數
        /// </summary>
        /// <param name="GroupCode"></param>
        /// <returns>List KeyValueRow</returns>
        public List<KeyValueRow> GetKeyValue(string GroupCode = "")
        {
            var Vdb = (from c in dcShare.ShareDefault
                       where (c.SystemCode == "Share" || c.SystemCode == _SystemCode)
                       && c.GroupCode == GroupCode
                       select new KeyValueRow
                       {
                           Key = c.FieldKey,
                           Value = c.FieldValue,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得共用參數
        /// </summary>
        /// <param name="GroupCode"></param>
        /// <returns>List TextValueRow</returns>
        public List<TextValueRow> GetTextValue(string GroupCode = "")
        {
            var Vdb = (from c in dcShare.ShareDefault
                       where (c.SystemCode == "Share" || c.SystemCode == _SystemCode)
                       && c.GroupCode == GroupCode
                       orderby c.Sort
                       select new TextValueRow
                       {
                           Text = c.Name,
                           Value = c.Code,
                           Sort = c.Sort,
                       }).ToList();

            return Vdb;
        }

          /// <summary>
        /// 取得系統共用參數
        /// </summary>
        public DefaultSystemRow DefaultSystem
        {
            get
            {
                var oShareDefault = new ShareDefaultDao(dcShare);
                var dc = oShareDefault.GetKeyValue("System").ToDictionary(p => p.Key, p => p.Value);

                var Vdb = new DefaultSystemRow();
                Vdb.Maintain = Convert.ToBoolean(dc["Maintain"]);
                Vdb.Test = Convert.ToBoolean(dc["Test"]);
                Vdb.DataMask = Convert.ToBoolean(dc["DataMask"]);
                Vdb.UniversalAccountCode = dc["UniversalAccountCode"];
                Vdb.UniversalAccountPassword = dc["UniversalAccountPassword"];
                Vdb.AdminMail = StringSplit.SplitStringToArray(dc["AdminMail"], ",").ToList();
                Vdb.TestMail = StringSplit.SplitStringToArray(dc["TestMail"], ",").ToList();
                Vdb.TestAccountCode = dc["TestAccountCode"];
                Vdb.LoginPage = dc["LoginPage"];
                Vdb.MainPage = dc["MainPage"];
                Vdb.RedirectUrl = dc["RedirectUrl"];
                Vdb.UrlValidMinutes = Convert.ToInt32(dc["UrlValidMinutes"]);
                Vdb.DataCache = Convert.ToBoolean(dc["DataCache"]);
                Vdb.CompanyId = dc["CompanyId"];

                return Vdb;
            }
        }

        /// <summary>
        /// 取得郵件參數
        /// </summary>
        public DefaultMailRow DefaultMail
        {
            get
            {
                var oShareDefault = new ShareDefaultDao(dcShare);
                var dc = oShareDefault.GetKeyValue("Mail").ToDictionary(p => p.Key, p => p.Value);

                var Vdb = new DefaultMailRow();
                Vdb.Host = dc["Host"];
                Vdb.Port = Convert.ToInt32(dc["Port"]);
                Vdb.UserId = dc["UserId"];
                Vdb.Password = dc["Password"];
                Vdb.IsNeedCredentials = Convert.ToBoolean(dc["IsNeedCredentials"]);
                Vdb.IsNeedSsl = Convert.ToBoolean(dc["IsNeedSsl"]);
                Vdb.Sender = dc["Sender"];
                Vdb.SenderName = dc["SenderName"];
                Vdb.EnableTestMode = Convert.ToBoolean(dc["EnableTestMode"]);
                Vdb.TestMail = StringSplit.SplitStringToArray(dc["TestMail"], ",").ToList();
                Vdb.DisableSend = Convert.ToBoolean(dc["DisableSend"]);
                Vdb.Priority = Convert.ToInt32(dc["Priority"]);
                Vdb.CredentialsType = dc["CredentialsType"];
                Vdb.MaxRetry = Convert.ToInt32(dc["MaxRetry"]);
                Vdb.Delay = Convert.ToInt32(dc["Delay"]);
                Vdb.Subject = dc["Subject"];
                Vdb.BodyHead = dc["BodyHead"];
                Vdb.BodyContent = dc["BodyContent"];
                Vdb.BodyFoot = dc["BodyFoot"];

                return Vdb;
            }
        }

        /// <summary>
        /// 取得OAuth2Facebook參數
        /// </summary>
        public DefaultOAuth2FacebookRow DefaultOAuth2Facebook
        {
            get
            {
                var oShareDefault = new ShareDefaultDao(dcShare);
                var dc = oShareDefault.GetKeyValue("OAuth2Facebook").ToDictionary(p => p.Key, p => p.Value);

                var Vdb = new DefaultOAuth2FacebookRow();
                Vdb.Scope =dc["Scope"];
                Vdb.RedirectUrl = dc["RedirectUrl"];
                Vdb.BindUrl = dc["BindUrl"];
                Vdb.ClientId = dc["ClientId"];
                Vdb.ClientSecret = dc["ClientSecret"];
                Vdb.TokenUrl = dc["TokenUrl"];
                Vdb.UserInfoUrl = dc["UserInfoUrl"];
                Vdb.AuthUrl = dc["AuthUrl"];

                return Vdb;
            }
        }

        /// <summary>
        /// 取得OAuth2Google參數
        /// </summary>
        public DefaultOAuth2GoogleRow DefaultOAuth2Google
        {
            get
            {
                var oShareDefault = new ShareDefaultDao(dcShare);
                var dc = oShareDefault.GetKeyValue("OAuth2Google").ToDictionary(p => p.Key, p => p.Value);

                var Vdb = new DefaultOAuth2GoogleRow();
                Vdb.Scope = dc["Scope"];
                Vdb.RedirectUrl = dc["RedirectUrl"];
                Vdb.BindUrl = dc["BindUrl"];
                Vdb.ClientId = dc["ClientId"];
                Vdb.ClientSecret = dc["ClientSecret"];
                Vdb.TokenUrl = dc["TokenUrl"];
                Vdb.UserInfoUrl = dc["UserInfoUrl"];
                Vdb.AuthUrl = dc["AuthUrl"];

                return Vdb;
            }
        }

        /// <summary>
        /// 取得OAuth2Line參數
        /// </summary>
        public DefaultOAuth2LineRow DefaultOAuth2Line
        {
            get
            {
                var oShareDefault = new ShareDefaultDao(dcShare);
                var dc = oShareDefault.GetKeyValue("OAuth2Line").ToDictionary(p => p.Key, p => p.Value);

                var Vdb = new DefaultOAuth2LineRow();
                Vdb.Scope = dc["Scope"];
                Vdb.RedirectUrl = dc["RedirectUrl"];
                Vdb.BindUrl = dc["BindUrl"];
                Vdb.ClientId = dc["ClientId"];
                Vdb.ClientSecret = dc["ClientSecret"];
                Vdb.TokenUrl = dc["TokenUrl"];
                Vdb.UserInfoUrl = dc["UserInfoUrl"];
                Vdb.AuthUrl = dc["AuthUrl"];

                return Vdb;
            }
        }

        /// <summary>
        /// 取得Article參數
        /// </summary>
        public DefaultArticleRow DefaultArticle
        {
            get
            {
                var oShareDefault = new ShareDefaultDao(dcShare);
                var dc = oShareDefault.GetKeyValue("Article").ToDictionary(p => p.Key, p => p.Value);

                var Vdb = new DefaultArticleRow();
                Vdb.ItemsAddCountMax = Convert.ToInt32(dc["ItemsAddCountMax"]);

                return Vdb;
            }
        }

        /// <summary>
        /// 儲存共用參數檢查
        /// </summary>
        /// <param name="ShareDefaultSave"></param>
        /// <returns>List ShareDefaultSaveResult</returns>
        public List<ShareDefaultSaveResult> ShareDefaultSaveCheck(ShareDefaultSaveRow ShareDefaultSave)
        {
            var ListData = DataTrans.ToDataTable(ShareDefaultSave.ListShareDefault);

            //主鍵
            var ListAutoKey = ShareDefaultSave.ListShareDefault.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDefaultSave.ListShareDefault.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDefaultSave.ListShareDefault.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDefault = (from c in dcShare.ShareDefault
                               where 1 == 1
                               && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                               && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                               && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                               select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareDefault);

            var ListDataCheck = DataCheck("ShareDefault", ListData, TableData, false, "04");

            var Vdb = new List<ShareDefaultSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareDefaultSaveResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存共用參數
        /// </summary>
        /// <param name="ShareDefaultSave"></param>
        /// <returns>ShareDefaultSaveResult</returns>
        public List<ShareDefaultSaveResult> ShareDefaultSave(ShareDefaultSaveRow ShareDefaultSave)
        {
            var SubmitChanges = ShareDefaultSave.SubmitChanges;
            var DataCheck = ShareDefaultSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareDefaultSaveResult>();
            ShareDefaultSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareDefaultSaveCheck(ShareDefaultSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareDefaultSave.ListShareDefault.Select(p => p.AutoKey).ToList();
            var ListCode = ShareDefaultSave.ListShareDefault.Select(p => p.Code).ToList();
            var ListKey = ShareDefaultSave.ListShareDefault.Select(p => p.Code).ToList();

            var rsShareDefault = (from c in dcShare.ShareDefault
                               where 1 == 1
                               && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                               && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                               && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                               select c).ToList();

            foreach (var ItemShareDefault in ShareDefaultSave.ListShareDefault)
            {
                var AutoKey = ItemShareDefault.AutoKey;
                var Code = ItemShareDefault.Code;
                var Key = ItemShareDefault.Code;

                var rShareDefault = (from c in rsShareDefault
                                  where 1 == 1
                                  && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                  && ((Code.Length == 0) || (c.Code == Code))
                                  && ((Key.Length == 0) || (c.Code == Key))
                                  select c).FirstOrDefault();

                if (rShareDefault == null)
                {
                    rShareDefault = new ShareDefault();
                    rShareDefault.Code = ItemShareDefault.Code;
                    rShareDefault.Status = ItemShareDefault.Status;
                    rShareDefault.InsertMan = ShareDefaultSave.UpdateMan;
                    rShareDefault.InsertDate = _NowDate;
                    dcShare.ShareDefault.InsertOnSubmit(rShareDefault);
                }

                rShareDefault.GroupCode = ItemShareDefault.GroupCode;
                rShareDefault.Name = ItemShareDefault.Name;
                rShareDefault.FieldKey = ItemShareDefault.FieldKey;
                rShareDefault.FieldValue = ItemShareDefault.FieldValue;
                rShareDefault.ColumnTypeCode = ItemShareDefault.ColumnTypeCode;
                rShareDefault.FormTypeCode = ItemShareDefault.FormTypeCode;
                //rShareDefault.SystemUse = ItemShareDefault.SystemUse;
                rShareDefault.Note = ItemShareDefault.Note;
                rShareDefault.Sort = ItemShareDefault.Sort;
                rShareDefault.UpdateMan = ShareDefaultSave.UpdateMan;
                rShareDefault.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new ShareDefaultSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareDefaultSave), ShareDefaultSave.AppName, ShareDefaultSave.IpAddress, ShareDefaultSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareDefaultSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareDefaultSave.AppName, ShareDefaultSave.IpAddress, ShareDefaultSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增共用參數檢查
        /// </summary>
        /// <param name="ShareDefaultInsert"></param>
        /// <returns>List ShareDefaultInsertResult</returns>
        public List<ShareDefaultInsertResult> ShareDefaultInsertCheck(ShareDefaultInsertRow ShareDefaultInsert)
        {
            var ListData = DataTrans.ToDataTable(ShareDefaultInsert.ListShareDefault);

            //主鍵
            var ListAutoKey = ShareDefaultInsert.ListShareDefault.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDefaultInsert.ListShareDefault.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDefaultInsert.ListShareDefault.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDefault = (from c in dcShare.ShareDefault
                               where 1 == 1
                               && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                               && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                               && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                               select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareDefault);

            var ListDataCheck = DataCheck("ShareDefault", ListData, TableData, true, "01");

            var Vdb = new List<ShareDefaultInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareDefaultInsertResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增共用參數
        /// </summary>
        /// <param name="ShareDefaultInsert"></param>
        /// <returns>ShareDefaultInsertResult</returns>
        public List<ShareDefaultInsertResult> ShareDefaultInsert(ShareDefaultInsertRow ShareDefaultInsert)
        {
            var SubmitChanges = ShareDefaultInsert.SubmitChanges;
            var DataCheck = ShareDefaultInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareDefaultInsertResult>();
            ShareDefaultInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareDefaultInsertCheck(ShareDefaultInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemShareDefault in ShareDefaultInsert.ListShareDefault)
            {
                var rShareDefault = new ShareDefault();
                rShareDefault.SystemCode = _SystemCode;
                rShareDefault.GroupCode = ItemShareDefault.GroupCode;
                rShareDefault.Code = ItemShareDefault.Code;
                rShareDefault.Name = ItemShareDefault.Name;
                rShareDefault.FieldKey = ItemShareDefault.FieldKey;
                rShareDefault.FieldValue = ItemShareDefault.FieldValue;
                rShareDefault.ColumnTypeCode = ItemShareDefault.ColumnTypeCode;
                rShareDefault.FormTypeCode = ItemShareDefault.FormTypeCode;
                rShareDefault.SystemUse = ItemShareDefault.SystemUse;
                rShareDefault.Note = ItemShareDefault.Note;
                rShareDefault.Sort = ItemShareDefault.Sort;
                rShareDefault.Status = ItemShareDefault.Status;
                rShareDefault.InsertMan = ShareDefaultInsert.InsertMan;
                rShareDefault.InsertDate = _NowDate;
                rShareDefault.UpdateMan = ShareDefaultInsert.InsertMan;
                rShareDefault.UpdateDate = _NowDate;
                dcShare.ShareDefault.InsertOnSubmit(rShareDefault);
            }

            try
            {
                rVdb = new ShareDefaultInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareDefaultInsert), ShareDefaultInsert.AppName, ShareDefaultInsert.IpAddress, ShareDefaultInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareDefaultInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareDefaultInsert.AppName, ShareDefaultInsert.IpAddress, ShareDefaultInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改共用參數檢查
        /// </summary>
        /// <param name="ShareDefaultUpdate"></param>
        /// <returns>List ShareDefaultUpdateResult</returns>
        public List<ShareDefaultUpdateResult> ShareDefaultUpdateCheck(ShareDefaultUpdateRow ShareDefaultUpdate)
        {
            var ListData = DataTrans.ToDataTable(ShareDefaultUpdate.ListShareDefault);

            //主鍵
            var ListAutoKey = ShareDefaultUpdate.ListShareDefault.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDefaultUpdate.ListShareDefault.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDefaultUpdate.ListShareDefault.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDefault = (from c in dcShare.ShareDefault
                               where 1 == 1
                               && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                               && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                               && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                               select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareDefault);

            var ListDataCheck = DataCheck("ShareDefault", ListData, TableData, true, "02");

            var Vdb = new List<ShareDefaultUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareDefaultUpdateResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改共用參數
        /// </summary>
        /// <param name="ShareDefaultUpdate"></param>
        /// <returns>ShareDefaultUpdateResult</returns>
        public List<ShareDefaultUpdateResult> ShareDefaultUpdate(ShareDefaultUpdateRow ShareDefaultUpdate)
        {
            var SubmitChanges = ShareDefaultUpdate.SubmitChanges;
            var DataCheck = ShareDefaultUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareDefaultUpdateResult>();
            ShareDefaultUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareDefaultUpdateCheck(ShareDefaultUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareDefaultUpdate.ListShareDefault.Select(p => p.AutoKey).ToList();
            var ListCode = ShareDefaultUpdate.ListShareDefault.Select(p => p.Code).ToList();
            var ListKey = ShareDefaultUpdate.ListShareDefault.Select(p => p.Code).ToList();

            var rsShareDefault = (from c in dcShare.ShareDefault
                               where 1 == 1
                               && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                               && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                               && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                               select c).ToList();

            foreach (var ItemShareDefault in ShareDefaultUpdate.ListShareDefault)
            {
                var AutoKey = ItemShareDefault.AutoKey;
                var Code = ItemShareDefault.Code;
                var Key = ItemShareDefault.Code;

                var rShareDefault = (from c in rsShareDefault
                                  where 1 == 1
                                  && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                  && ((Code.Length == 0) || (c.Code == Code))
                                  && ((Key.Length == 0) || (c.Code == Key))
                                  select c).FirstOrDefault();

                if (rShareDefault != null)
                {
                    rShareDefault.GroupCode = ItemShareDefault.GroupCode;
                    rShareDefault.Name = ItemShareDefault.Name;
                    rShareDefault.FieldKey = ItemShareDefault.FieldKey;
                    rShareDefault.FieldValue = ItemShareDefault.FieldValue;
                    rShareDefault.ColumnTypeCode = ItemShareDefault.ColumnTypeCode;
                    rShareDefault.FormTypeCode = ItemShareDefault.FormTypeCode;
                    //rShareDefault.SystemUse = ItemShareDefault.SystemUse;
                    rShareDefault.Note = ItemShareDefault.Note;
                    rShareDefault.Sort = ItemShareDefault.Sort;
                    rShareDefault.UpdateMan = ShareDefaultUpdate.UpdateMan;
                    rShareDefault.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareDefaultUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareDefaultUpdate), ShareDefaultUpdate.AppName, ShareDefaultUpdate.IpAddress, ShareDefaultUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareDefaultUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareDefaultUpdate), ShareDefaultUpdate.AppName, ShareDefaultUpdate.IpAddress, ShareDefaultUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareDefaultUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareDefaultUpdate.AppName, ShareDefaultUpdate.IpAddress, ShareDefaultUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除共用參數檢查
        /// </summary>
        /// <param name="ShareDefaultDelete"></param>
        /// <returns>List ShareDefaultDeleteResult</returns>
        public List<ShareDefaultDeleteResult> ShareDefaultDeleteCheck(ShareDefaultDeleteRow ShareDefaultDelete)
        {
            var ListData = DataTrans.ToDataTable(ShareDefaultDelete.ListShareDefault);

            //主鍵
            var ListAutoKey = ShareDefaultDelete.ListShareDefault.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDefaultDelete.ListShareDefault.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDefaultDelete.ListShareDefault.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDefault = (from c in dcShare.ShareDefault
                               where 1 == 1
                               && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                               && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                               && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                               select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareDefault);

            var ListDataCheck = DataCheck("ShareDefault", ListData, TableData, true, "03");

            var Vdb = new List<ShareDefaultDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareDefaultDeleteResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0302000003");  //刪除失敗，系統參數不可刪除

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            foreach (var rShareDefault in rsShareDefault)
            {
                if (rShareDefault.SystemUse)
                {
                    var Key = rShareDefault.Code;

                    var rVdb = new ShareDefaultDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，系統參數不可刪除";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = false;
                    Vdb.Add(rVdb);
                }
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除共用參數
        /// </summary>
        /// <param name="ShareDefaultDelete"></param>
        /// <returns>ShareDefaultDeleteResult</returns>
        public List<ShareDefaultDeleteResult> ShareDefaultDelete(ShareDefaultDeleteRow ShareDefaultDelete)
        {
            var SubmitChanges = ShareDefaultDelete.SubmitChanges;
            var DataCheck = ShareDefaultDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在
            ListShareDisplayMessageCode.Add("0302000003");  //刪除失敗，系統參數不可刪除

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareDefaultDeleteResult>();
            ShareDefaultDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareDefaultDeleteCheck(ShareDefaultDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareDefaultDelete.ListShareDefault.Select(p => p.AutoKey).ToList();
            var ListCode = ShareDefaultDelete.ListShareDefault.Select(p => p.Code).ToList();
            var ListKey = ShareDefaultDelete.ListShareDefault.Select(p => p.Code).ToList();

            var rsShareDefault = (from c in dcShare.ShareDefault
                               where 1 == 1
                               && ListAutoKey.Contains(c.AutoKey)
                               && ListCode.Contains(c.Code)
                               && ListKey.Contains(c.Code)
                               select c).ToList();

            foreach (var ItemShareDefault in ShareDefaultDelete.ListShareDefault)
            {
                var AutoKey = ItemShareDefault.AutoKey;
                var Code = ItemShareDefault.Code;
                var Key = ItemShareDefault.Code;

                var rShareDefault = (from c in rsShareDefault
                                  where 1 == 1
                                  && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                  && ((Code.Length == 0) || (c.Code == Code))
                                  && ((Key.Length == 0) || (c.Code == Key))
                                  select c).FirstOrDefault();

                if (rShareDefault != null)
                {
                    if (rShareDefault.SystemUse)
                    {
                        rVdb = new ShareDefaultDeleteResult();
                        rVdb.Code = "0302000003";
                        rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                        rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，系統參數不可刪除";
                        rVdb.Pass = false;
                        Vdb.Add(rVdb);
                    }
                    else
                    {
                        rShareDefault.Status = "2";
                        rShareDefault.UpdateMan = ShareDefaultDelete.UpdateMan;
                        rShareDefault.UpdateDate = _NowDate;
                    }
                }
                else
                {
                    rVdb = new ShareDefaultDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareDefaultDelete), ShareDefaultDelete.AppName, ShareDefaultDelete.IpAddress, ShareDefaultDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareDefaultDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareDefaultDelete), ShareDefaultDelete.AppName, ShareDefaultDelete.IpAddress, ShareDefaultDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareDefaultDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareDefaultDelete.AppName, ShareDefaultDelete.IpAddress, ShareDefaultDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}
