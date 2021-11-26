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
    public class ShareCompanyDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public ShareCompanyDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public ShareCompanyDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public ShareCompanyDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public ShareCompanyDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得公司參數
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List ShareCompanyRow</returns>
        public List<ShareCompanyRow> GetShareCompany(ShareCompanyConditions Cond)
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

            var VdbSql = (from c in dcShare.ShareCompany
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((c.SystemCode == "Share" || c.SystemCode == _SystemCode))
                          && ((GroupCode.Length == 0) || (c.GroupCode == GroupCode))
                          orderby c.Sort
                          select new ShareCompanyRow
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
        /// 取得公司參數
        /// </summary>
        /// <param name="GroupCode"></param>
        /// <returns>List NameCodeRow</returns>
        public List<NameCodeRow> GetNameCode(string GroupCode = "")
        {
            var Vdb = (from c in dcShare.ShareCompany
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
        /// 取得公司參數
        /// </summary>
        /// <param name="GroupCode"></param>
        /// <returns>List KeyValueRow</returns>
        public List<KeyValueRow> GetKeyValue(string GroupCode = "")
        {
            var Vdb = (from c in dcShare.ShareCompany
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
        /// 取得公司參數
        /// </summary>
        /// <param name="GroupCode"></param>
        /// <returns>List TextValueRow</returns>
        public List<TextValueRow> GetTextValue(string GroupCode = "")
        {
            var Vdb = (from c in dcShare.ShareCompany
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
        /// 取得系統公司參數
        /// </summary>
        /// <param name="AccountCode">公司代碼</param>
        /// <returns>CompanyRow</returns>
        public CompanySettingRow GetCompanySetting(string AccountCode)
        {
            CompanySettingRow Vdb = null;

            var GroupCode = (from c in dcShare.ShareCompany
                             where c.FieldKey == "AccountCode"
                             && c.FieldValue == AccountCode
                             select c.GroupCode).FirstOrDefault();

            if (GroupCode != null && GroupCode.Length > 0)
            {
                Vdb = new CompanySettingRow();

                var dc = GetKeyValue(GroupCode).ToDictionary(p => p.Key, p => p.Value);

                Vdb.AccountCode = dc["AccountCode"];
                Vdb.Name = dc["Name"];
                Vdb.FileNameLoginPage = dc["FileNameLoginPage"];
                Vdb.FileNameMenuTop = dc["FileNameMenuTop"];
                Vdb.FileNameSiteIco = dc["FileNameSiteIco"];
                Vdb.ApiHr = dc["ApiHr"];
                Vdb.ApiFlow = dc["ApiFlow"];
                Vdb.ConnHr = dc["ConnHr"];
                Vdb.ConnFlow = dc["ConnFlow"];
                Vdb.HrApiConnection = dc["HrApiConnection"];
                //不是所有客戶都有APP?
                if (dc.ContainsKey("ConnApp"))
                {
                    Vdb.ConnApp = dc["ConnApp"];
                }
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存公司參數檢查
        /// </summary>
        /// <param name="ShareCompanySave"></param>
        /// <returns>List ShareCompanySaveResult</returns>
        public List<ShareCompanySaveResult> ShareCompanySaveCheck(ShareCompanySaveRow ShareCompanySave)
        {
            var ListData = DataTrans.ToDataTable(ShareCompanySave.ListShareCompany);

            //主鍵
            var ListAutoKey = ShareCompanySave.ListShareCompany.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareCompanySave.ListShareCompany.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareCompanySave.ListShareCompany.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareCompany = (from c in dcShare.ShareCompany
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareCompany);

            var ListDataCheck = DataCheck("ShareCompany", ListData, TableData, false, "04");

            var Vdb = new List<ShareCompanySaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareCompanySaveResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存公司參數
        /// </summary>
        /// <param name="ShareCompanySave"></param>
        /// <returns>ShareCompanySaveResult</returns>
        public List<ShareCompanySaveResult> ShareCompanySave(ShareCompanySaveRow ShareCompanySave)
        {
            var SubmitChanges = ShareCompanySave.SubmitChanges;
            var DataCheck = ShareCompanySave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareCompanySaveResult>();
            ShareCompanySaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareCompanySaveCheck(ShareCompanySave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareCompanySave.ListShareCompany.Select(p => p.AutoKey).ToList();
            var ListCode = ShareCompanySave.ListShareCompany.Select(p => p.Code).ToList();
            var ListKey = ShareCompanySave.ListShareCompany.Select(p => p.Code).ToList();

            var rsShareCompany = (from c in dcShare.ShareCompany
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            foreach (var ItemShareCompany in ShareCompanySave.ListShareCompany)
            {
                var AutoKey = ItemShareCompany.AutoKey;
                var Code = ItemShareCompany.Code;
                var Key = ItemShareCompany.Code;

                var rShareCompany = (from c in rsShareCompany
                                     where 1 == 1
                                     && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                     && ((Code.Length == 0) || (c.Code == Code))
                                     && ((Key.Length == 0) || (c.Code == Key))
                                     select c).FirstOrDefault();

                if (rShareCompany == null)
                {
                    rShareCompany = new ShareCompany();
                    rShareCompany.Code = ItemShareCompany.Code;
                    rShareCompany.Status = ItemShareCompany.Status;
                    rShareCompany.InsertMan = ShareCompanySave.UpdateMan;
                    rShareCompany.InsertDate = _NowDate;
                    dcShare.ShareCompany.InsertOnSubmit(rShareCompany);
                }

                rShareCompany.GroupCode = ItemShareCompany.GroupCode;
                rShareCompany.Name = ItemShareCompany.Name;
                rShareCompany.FieldKey = ItemShareCompany.FieldKey;
                rShareCompany.FieldValue = ItemShareCompany.FieldValue;
                rShareCompany.ColumnTypeCode = ItemShareCompany.ColumnTypeCode;
                rShareCompany.FormTypeCode = ItemShareCompany.FormTypeCode;
                //rShareCompany.SystemUse = ItemShareCompany.SystemUse;
                rShareCompany.Note = ItemShareCompany.Note;
                rShareCompany.Sort = ItemShareCompany.Sort;
                rShareCompany.UpdateMan = ShareCompanySave.UpdateMan;
                rShareCompany.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new ShareCompanySaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareCompanySave), ShareCompanySave.AppName, ShareCompanySave.IpAddress, ShareCompanySave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareCompanySaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareCompanySave.AppName, ShareCompanySave.IpAddress, ShareCompanySave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增公司參數檢查
        /// </summary>
        /// <param name="ShareCompanyInsert"></param>
        /// <returns>List ShareCompanyInsertResult</returns>
        public List<ShareCompanyInsertResult> ShareCompanyInsertCheck(ShareCompanyInsertRow ShareCompanyInsert)
        {
            var ListData = DataTrans.ToDataTable(ShareCompanyInsert.ListShareCompany);

            //主鍵
            var ListAutoKey = ShareCompanyInsert.ListShareCompany.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareCompanyInsert.ListShareCompany.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareCompanyInsert.ListShareCompany.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareCompany = (from c in dcShare.ShareCompany
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareCompany);

            var ListDataCheck = DataCheck("ShareCompany", ListData, TableData, true, "01");

            var Vdb = new List<ShareCompanyInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareCompanyInsertResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增公司參數
        /// </summary>
        /// <param name="ShareCompanyInsert"></param>
        /// <returns>ShareCompanyInsertResult</returns>
        public List<ShareCompanyInsertResult> ShareCompanyInsert(ShareCompanyInsertRow ShareCompanyInsert)
        {
            var SubmitChanges = ShareCompanyInsert.SubmitChanges;
            var DataCheck = ShareCompanyInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareCompanyInsertResult>();
            ShareCompanyInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareCompanyInsertCheck(ShareCompanyInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemShareCompany in ShareCompanyInsert.ListShareCompany)
            {
                var rShareCompany = new ShareCompany();
                rShareCompany.SystemCode = _SystemCode;
                rShareCompany.GroupCode = ItemShareCompany.GroupCode;
                rShareCompany.Code = ItemShareCompany.Code;
                rShareCompany.Name = ItemShareCompany.Name;
                rShareCompany.FieldKey = ItemShareCompany.FieldKey;
                rShareCompany.FieldValue = ItemShareCompany.FieldValue;
                rShareCompany.ColumnTypeCode = ItemShareCompany.ColumnTypeCode;
                rShareCompany.FormTypeCode = ItemShareCompany.FormTypeCode;
                rShareCompany.Note = ItemShareCompany.Note;
                rShareCompany.Sort = ItemShareCompany.Sort;
                rShareCompany.Status = ItemShareCompany.Status;
                rShareCompany.InsertMan = ShareCompanyInsert.InsertMan;
                rShareCompany.InsertDate = _NowDate;
                rShareCompany.UpdateMan = ShareCompanyInsert.InsertMan;
                rShareCompany.UpdateDate = _NowDate;
                dcShare.ShareCompany.InsertOnSubmit(rShareCompany);
            }

            try
            {
                rVdb = new ShareCompanyInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareCompanyInsert), ShareCompanyInsert.AppName, ShareCompanyInsert.IpAddress, ShareCompanyInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareCompanyInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareCompanyInsert.AppName, ShareCompanyInsert.IpAddress, ShareCompanyInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改公司參數檢查
        /// </summary>
        /// <param name="ShareCompanyUpdate"></param>
        /// <returns>List ShareCompanyUpdateResult</returns>
        public List<ShareCompanyUpdateResult> ShareCompanyUpdateCheck(ShareCompanyUpdateRow ShareCompanyUpdate)
        {
            var ListData = DataTrans.ToDataTable(ShareCompanyUpdate.ListShareCompany);

            //主鍵
            var ListAutoKey = ShareCompanyUpdate.ListShareCompany.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareCompanyUpdate.ListShareCompany.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareCompanyUpdate.ListShareCompany.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareCompany = (from c in dcShare.ShareCompany
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareCompany);

            var ListDataCheck = DataCheck("ShareCompany", ListData, TableData, true, "02");

            var Vdb = new List<ShareCompanyUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareCompanyUpdateResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改公司參數
        /// </summary>
        /// <param name="ShareCompanyUpdate"></param>
        /// <returns>ShareCompanyUpdateResult</returns>
        public List<ShareCompanyUpdateResult> ShareCompanyUpdate(ShareCompanyUpdateRow ShareCompanyUpdate)
        {
            var SubmitChanges = ShareCompanyUpdate.SubmitChanges;
            var DataCheck = ShareCompanyUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareCompanyUpdateResult>();
            ShareCompanyUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareCompanyUpdateCheck(ShareCompanyUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareCompanyUpdate.ListShareCompany.Select(p => p.AutoKey).ToList();
            var ListCode = ShareCompanyUpdate.ListShareCompany.Select(p => p.Code).ToList();
            var ListKey = ShareCompanyUpdate.ListShareCompany.Select(p => p.Code).ToList();

            var rsShareCompany = (from c in dcShare.ShareCompany
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            foreach (var ItemShareCompany in ShareCompanyUpdate.ListShareCompany)
            {
                var AutoKey = ItemShareCompany.AutoKey;
                var Code = ItemShareCompany.Code;
                var Key = ItemShareCompany.Code;

                var rShareCompany = (from c in rsShareCompany
                                     where 1 == 1
                                     && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                     && ((Code.Length == 0) || (c.Code == Code))
                                     && ((Key.Length == 0) || (c.Code == Key))
                                     select c).FirstOrDefault();

                if (rShareCompany != null)
                {
                    rShareCompany.GroupCode = ItemShareCompany.GroupCode;
                    rShareCompany.Name = ItemShareCompany.Name;
                    rShareCompany.FieldKey = ItemShareCompany.FieldKey;
                    rShareCompany.FieldValue = ItemShareCompany.FieldValue;
                    rShareCompany.ColumnTypeCode = ItemShareCompany.ColumnTypeCode;
                    rShareCompany.FormTypeCode = ItemShareCompany.FormTypeCode;
                    //rShareCompany.SystemUse = ItemShareCompany.SystemUse;
                    rShareCompany.Note = ItemShareCompany.Note;
                    rShareCompany.Sort = ItemShareCompany.Sort;
                    rShareCompany.UpdateMan = ShareCompanyUpdate.UpdateMan;
                    rShareCompany.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareCompanyUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareCompanyUpdate), ShareCompanyUpdate.AppName, ShareCompanyUpdate.IpAddress, ShareCompanyUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareCompanyUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareCompanyUpdate), ShareCompanyUpdate.AppName, ShareCompanyUpdate.IpAddress, ShareCompanyUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareCompanyUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareCompanyUpdate.AppName, ShareCompanyUpdate.IpAddress, ShareCompanyUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除公司參數檢查
        /// </summary>
        /// <param name="ShareCompanyDelete"></param>
        /// <returns>List ShareCompanyDeleteResult</returns>
        public List<ShareCompanyDeleteResult> ShareCompanyDeleteCheck(ShareCompanyDeleteRow ShareCompanyDelete)
        {
            var ListData = DataTrans.ToDataTable(ShareCompanyDelete.ListShareCompany);

            //主鍵
            var ListAutoKey = ShareCompanyDelete.ListShareCompany.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareCompanyDelete.ListShareCompany.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareCompanyDelete.ListShareCompany.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareCompany = (from c in dcShare.ShareCompany
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareCompany);

            var ListDataCheck = DataCheck("ShareCompany", ListData, TableData, true, "03");

            var Vdb = new List<ShareCompanyDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareCompanyDeleteResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0302000003");  //刪除失敗，系統參數不可刪除

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            foreach (var rShareCompany in rsShareCompany)
            {
                {
                    var Key = rShareCompany.Code;

                    var rVdb = new ShareCompanyDeleteResult();
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
        /// 刪除公司參數
        /// </summary>
        /// <param name="ShareCompanyDelete"></param>
        /// <returns>ShareCompanyDeleteResult</returns>
        public List<ShareCompanyDeleteResult> ShareCompanyDelete(ShareCompanyDeleteRow ShareCompanyDelete)
        {
            var SubmitChanges = ShareCompanyDelete.SubmitChanges;
            var DataCheck = ShareCompanyDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在
            ListShareDisplayMessageCode.Add("0302000003");  //刪除失敗，系統參數不可刪除

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareCompanyDeleteResult>();
            ShareCompanyDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareCompanyDeleteCheck(ShareCompanyDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareCompanyDelete.ListShareCompany.Select(p => p.AutoKey).ToList();
            var ListCode = ShareCompanyDelete.ListShareCompany.Select(p => p.Code).ToList();
            var ListKey = ShareCompanyDelete.ListShareCompany.Select(p => p.Code).ToList();

            var rsShareCompany = (from c in dcShare.ShareCompany
                                  where 1 == 1
                                  && ListAutoKey.Contains(c.AutoKey)
                                  && ListCode.Contains(c.Code)
                                  && ListKey.Contains(c.Code)
                                  select c).ToList();

            foreach (var ItemShareCompany in ShareCompanyDelete.ListShareCompany)
            {
                var AutoKey = ItemShareCompany.AutoKey;
                var Code = ItemShareCompany.Code;
                var Key = ItemShareCompany.Code;

                var rShareCompany = (from c in rsShareCompany
                                     where 1 == 1
                                     && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                     && ((Code.Length == 0) || (c.Code == Code))
                                     && ((Key.Length == 0) || (c.Code == Key))
                                     select c).FirstOrDefault();

                if (rShareCompany != null)
                {
                    if (false)
                    {
                        rVdb = new ShareCompanyDeleteResult();
                        rVdb.Code = "0302000003";
                        rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                        rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，系統參數不可刪除";
                        rVdb.Pass = false;
                        Vdb.Add(rVdb);
                    }
                    else
                    {
                        rShareCompany.Status = "2";
                        rShareCompany.UpdateMan = ShareCompanyDelete.UpdateMan;
                        rShareCompany.UpdateDate = _NowDate;
                    }
                }
                else
                {
                    rVdb = new ShareCompanyDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareCompanyDelete), ShareCompanyDelete.AppName, ShareCompanyDelete.IpAddress, ShareCompanyDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareCompanyDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareCompanyDelete), ShareCompanyDelete.AppName, ShareCompanyDelete.IpAddress, ShareCompanyDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareCompanyDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareCompanyDelete.AppName, ShareCompanyDelete.IpAddress, ShareCompanyDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}
