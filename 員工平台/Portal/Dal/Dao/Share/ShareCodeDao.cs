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
    public class ShareCodeDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public ShareCodeDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public ShareCodeDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public ShareCodeDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public ShareCodeDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得共用代碼
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List ShareCodeRow</returns>
        public List<ShareCodeRow> GetShareCode(ShareCodeConditions Cond)
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

            var VdbSql = (from c in dcShare.ShareCode
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((c.SystemCode == "Share" || c.SystemCode == _SystemCode))
                          && ((GroupCode.Length == 0) || (c.GroupCode == GroupCode))
                          orderby c.Sort
                          select new ShareCodeRow
                          {
                              AutoKey = c.AutoKey,
                              SystemCode = c.SystemCode,
                              GroupCode = c.GroupCode,
                              Key1 = c.Key1,
                              Key2 = c.Key2,
                              Key3 = c.Key3,
                              Code = c.Code,
                              Name = c.Name,
                              Column1 = c.Column1,
                              Column2 = c.Column2,
                              Column3 = c.Column3,
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

            return Vdb;
        }

        /// <summary>
        /// 取得共用代碼
        /// </summary>
        /// <param name="GroupCode"></param>
        /// <param name="Key1"></param>
        /// <param name="Key2"></param>
        /// <param name="Key3"></param>
        /// <returns>List NameCodeRow</returns>
        public List<NameCodeRow> GetNameCode(string GroupCode = "", string Key1 = "", string Key2 = "", string Key3 = "")
        {
            var Vdb = (from c in dcShare.ShareCode
                       where 1==1
                       && ((Key1.Length == 0) || (c.Key1 == Key1))
                       && ((Key2.Length == 0) || (c.Key2 == Key1))
                       && ((Key3.Length == 0) || (c.Key3 == Key1))
                       && c.GroupCode == GroupCode
                       select new NameCodeRow
                       {
                           Name = c.Name,
                           Code = c.Code,
                           Column1 = c.Column1,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得共用代碼
        /// </summary>
        /// <param name="GroupCode"></param>
        /// <param name="Key1"></param>
        /// <param name="Key2"></param>
        /// <param name="Key3"></param>
        /// <returns>List TextValueRow</returns>
        public List<TextValueRow> GetTextValue(string GroupCode = "", string Key1 = "", string Key2 = "", string Key3 = "")
        {
            var Vdb = (from c in dcShare.ShareCode
                       where (c.SystemCode == "Share" || c.SystemCode == _SystemCode)
                       && ((Key1.Length == 0) || (c.Key1 == Key1))
                       && ((Key2.Length == 0) || (c.Key2 == Key1))
                       && ((Key3.Length == 0) || (c.Key3 == Key1))
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
        /// 儲存共用代碼檢查
        /// </summary>
        /// <param name="ShareCodeSave"></param>
        /// <returns>List ShareCodeSaveResult</returns>
        public List<ShareCodeSaveResult> ShareCodeSaveCheck(ShareCodeSaveRow ShareCodeSave)
        {
            var ListData = DataTrans.ToDataTable(ShareCodeSave.ListShareCode);

            //主鍵
            var ListAutoKey = ShareCodeSave.ListShareCode.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareCodeSave.ListShareCode.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareCodeSave.ListShareCode.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareCode = (from c in dcShare.ShareCode
                               where 1 == 1
                               && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                               && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                               && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                               select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareCode);

            var ListDataCheck = DataCheck("ShareCode", ListData, TableData, false, "04");

            var Vdb = new List<ShareCodeSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareCodeSaveResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存共用代碼
        /// </summary>
        /// <param name="ShareCodeSave"></param>
        /// <returns>ShareCodeSaveResult</returns>
        public List<ShareCodeSaveResult> ShareCodeSave(ShareCodeSaveRow ShareCodeSave)
        {
            var SubmitChanges = ShareCodeSave.SubmitChanges;
            var DataCheck = ShareCodeSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareCodeSaveResult>();
            ShareCodeSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareCodeSaveCheck(ShareCodeSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareCodeSave.ListShareCode.Select(p => p.AutoKey).ToList();
            var ListCode = ShareCodeSave.ListShareCode.Select(p => p.Code).ToList();
            var ListKey = ShareCodeSave.ListShareCode.Select(p => p.Code).ToList();

            var rsShareCode = (from c in dcShare.ShareCode
                               where 1 == 1
                               && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                               && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                               && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                               select c).ToList();

            foreach (var ItemShareCode in ShareCodeSave.ListShareCode)
            {
                var AutoKey = ItemShareCode.AutoKey;
                var Code = ItemShareCode.Code;
                var Key = ItemShareCode.Code;

                var rShareCode = (from c in rsShareCode
                                  where 1 == 1
                                  && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                  && ((Code.Length == 0) || (c.Code == Code))
                                  && ((Key.Length == 0) || (c.Code == Key))
                                  select c).FirstOrDefault();

                if (rShareCode == null)
                {
                    rShareCode = new ShareCode();
                    rShareCode.Code = ItemShareCode.Code;
                    rShareCode.Status = ItemShareCode.Status;
                    rShareCode.InsertMan = ShareCodeSave.UpdateMan;
                    rShareCode.InsertDate = _NowDate;
                    dcShare.ShareCode.InsertOnSubmit(rShareCode);
                }

                rShareCode.GroupCode = ItemShareCode.GroupCode;
                rShareCode.Key1 = ItemShareCode.Key1;
                rShareCode.Key2 = ItemShareCode.Key2;
                rShareCode.Key3 = ItemShareCode.Key3;
                rShareCode.Name = ItemShareCode.Name;
                rShareCode.Column1 = ItemShareCode.Column1;
                rShareCode.Column2 = ItemShareCode.Column2;
                rShareCode.Column3 = ItemShareCode.Column3;
                //rShareCode.SystemUse = ItemShareCode.SystemUse;
                rShareCode.Note = ItemShareCode.Note;
                rShareCode.Sort = ItemShareCode.Sort;
                rShareCode.UpdateMan = ShareCodeSave.UpdateMan;
                rShareCode.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new ShareCodeSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareCodeSave), ShareCodeSave.AppName, ShareCodeSave.IpAddress, ShareCodeSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareCodeSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareCodeSave.AppName, ShareCodeSave.IpAddress, ShareCodeSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增共用代碼檢查
        /// </summary>
        /// <param name="ShareCodeInsert"></param>
        /// <returns>List ShareCodeInsertResult</returns>
        public List<ShareCodeInsertResult> ShareCodeInsertCheck(ShareCodeInsertRow ShareCodeInsert)
        {
            var ListData = DataTrans.ToDataTable(ShareCodeInsert.ListShareCode);

            //主鍵
            var ListAutoKey = ShareCodeInsert.ListShareCode.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareCodeInsert.ListShareCode.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareCodeInsert.ListShareCode.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareCode = (from c in dcShare.ShareCode
                               where 1 == 1
                               && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                               && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                               && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                               select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareCode);

            var ListDataCheck = DataCheck("ShareCode", ListData, TableData, true, "01");

            var Vdb = new List<ShareCodeInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareCodeInsertResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增共用代碼
        /// </summary>
        /// <param name="ShareCodeInsert"></param>
        /// <returns>ShareCodeInsertResult</returns>
        public List<ShareCodeInsertResult> ShareCodeInsert(ShareCodeInsertRow ShareCodeInsert)
        {
            var SubmitChanges = ShareCodeInsert.SubmitChanges;
            var DataCheck = ShareCodeInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareCodeInsertResult>();
            ShareCodeInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareCodeInsertCheck(ShareCodeInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemShareCode in ShareCodeInsert.ListShareCode)
            {
                var rShareCode = new ShareCode();
                rShareCode.SystemCode = _SystemCode;
                rShareCode.GroupCode = ItemShareCode.GroupCode;
                rShareCode.Key1 = ItemShareCode.Key1;
                rShareCode.Key2 = ItemShareCode.Key2;
                rShareCode.Key3 = ItemShareCode.Key3;
                rShareCode.Code = ItemShareCode.Code;
                rShareCode.Name = ItemShareCode.Name;
                rShareCode.Column1 = ItemShareCode.Column1;
                rShareCode.Column2 = ItemShareCode.Column2;
                rShareCode.Column3 = ItemShareCode.Column3;
                rShareCode.SystemUse = ItemShareCode.SystemUse;
                rShareCode.Note = ItemShareCode.Note;
                rShareCode.Sort = ItemShareCode.Sort;
                rShareCode.Status = ItemShareCode.Status;
                rShareCode.InsertMan = ShareCodeInsert.InsertMan;
                rShareCode.InsertDate = _NowDate;
                rShareCode.UpdateMan = ShareCodeInsert.InsertMan;
                rShareCode.UpdateDate = _NowDate;
                dcShare.ShareCode.InsertOnSubmit(rShareCode);
            }

            try
            {
                rVdb = new ShareCodeInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareCodeInsert), ShareCodeInsert.AppName, ShareCodeInsert.IpAddress, ShareCodeInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareCodeInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareCodeInsert.AppName, ShareCodeInsert.IpAddress, ShareCodeInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改共用代碼檢查
        /// </summary>
        /// <param name="ShareCodeUpdate"></param>
        /// <returns>List ShareCodeUpdateResult</returns>
        public List<ShareCodeUpdateResult> ShareCodeUpdateCheck(ShareCodeUpdateRow ShareCodeUpdate)
        {
            var ListData = DataTrans.ToDataTable(ShareCodeUpdate.ListShareCode);

            //主鍵
            var ListAutoKey = ShareCodeUpdate.ListShareCode.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareCodeUpdate.ListShareCode.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareCodeUpdate.ListShareCode.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareCode = (from c in dcShare.ShareCode
                               where 1 == 1
                               && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                               && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                               && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                               select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareCode);

            var ListDataCheck = DataCheck("ShareCode", ListData, TableData, true, "02");

            var Vdb = new List<ShareCodeUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareCodeUpdateResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改共用代碼
        /// </summary>
        /// <param name="ShareCodeUpdate"></param>
        /// <returns>ShareCodeUpdateResult</returns>
        public List<ShareCodeUpdateResult> ShareCodeUpdate(ShareCodeUpdateRow ShareCodeUpdate)
        {
            var SubmitChanges = ShareCodeUpdate.SubmitChanges;
            var DataCheck = ShareCodeUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareCodeUpdateResult>();
            ShareCodeUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareCodeUpdateCheck(ShareCodeUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareCodeUpdate.ListShareCode.Select(p => p.AutoKey).ToList();
            var ListCode = ShareCodeUpdate.ListShareCode.Select(p => p.Code).ToList();
            var ListKey = ShareCodeUpdate.ListShareCode.Select(p => p.Code).ToList();

            var rsShareCode = (from c in dcShare.ShareCode
                               where 1 == 1
                               && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                               && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                               && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                               select c).ToList();

            foreach (var ItemShareCode in ShareCodeUpdate.ListShareCode)
            {
                var AutoKey = ItemShareCode.AutoKey;
                var Code = ItemShareCode.Code;
                var Key = ItemShareCode.Code;

                var rShareCode = (from c in rsShareCode
                                  where 1 == 1
                                  && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                  && ((Code.Length == 0) || (c.Code == Code))
                                  && ((Key.Length == 0) || (c.Code == Key))
                                  select c).FirstOrDefault();

                if (rShareCode != null)
                {
                    rShareCode.GroupCode = ItemShareCode.GroupCode;
                    rShareCode.Key1 = ItemShareCode.Key1;
                    rShareCode.Key2 = ItemShareCode.Key2;
                    rShareCode.Key3 = ItemShareCode.Key3;
                    rShareCode.Name = ItemShareCode.Name;
                    rShareCode.Column1 = ItemShareCode.Column1;
                    rShareCode.Column2 = ItemShareCode.Column2;
                    rShareCode.Column3 = ItemShareCode.Column3;
                    //rShareCode.SystemUse = ItemShareCode.SystemUse;
                    rShareCode.Note = ItemShareCode.Note;
                    rShareCode.Sort = ItemShareCode.Sort;
                    rShareCode.UpdateMan = ShareCodeUpdate.UpdateMan;
                    rShareCode.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareCodeUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareCodeUpdate), ShareCodeUpdate.AppName, ShareCodeUpdate.IpAddress, ShareCodeUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareCodeUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareCodeUpdate), ShareCodeUpdate.AppName, ShareCodeUpdate.IpAddress, ShareCodeUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareCodeUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareCodeUpdate.AppName, ShareCodeUpdate.IpAddress, ShareCodeUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除共用代碼檢查
        /// </summary>
        /// <param name="ShareCodeDelete"></param>
        /// <returns>List ShareCodeDeleteResult</returns>
        public List<ShareCodeDeleteResult> ShareCodeDeleteCheck(ShareCodeDeleteRow ShareCodeDelete)
        {
            var ListData = DataTrans.ToDataTable(ShareCodeDelete.ListShareCode);

            //主鍵
            var ListAutoKey = ShareCodeDelete.ListShareCode.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareCodeDelete.ListShareCode.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareCodeDelete.ListShareCode.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareCode = (from c in dcShare.ShareCode
                               where 1 == 1
                               && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                               && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                               && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                               select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareCode);

            var ListDataCheck = DataCheck("ShareCode", ListData, TableData, true, "03");

            var Vdb = new List<ShareCodeDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareCodeDeleteResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0302000003");  //刪除失敗，系統參數不可刪除

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            foreach (var rShareCode in rsShareCode)
            {
                if (rShareCode.SystemUse)
                {
                    var Key = rShareCode.Code;

                    var rVdb = new ShareCodeDeleteResult();
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
        /// 刪除共用代碼
        /// </summary>
        /// <param name="ShareCodeDelete"></param>
        /// <returns>ShareCodeDeleteResult</returns>
        public List<ShareCodeDeleteResult> ShareCodeDelete(ShareCodeDeleteRow ShareCodeDelete)
        {
            var SubmitChanges = ShareCodeDelete.SubmitChanges;
            var DataCheck = ShareCodeDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在
            ListShareDisplayMessageCode.Add("0302000003");  //刪除失敗，系統參數不可刪除

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareCodeDeleteResult>();
            ShareCodeDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareCodeDeleteCheck(ShareCodeDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareCodeDelete.ListShareCode.Select(p => p.AutoKey).ToList();
            var ListCode = ShareCodeDelete.ListShareCode.Select(p => p.Code).ToList();
            var ListKey = ShareCodeDelete.ListShareCode.Select(p => p.Code).ToList();

            var rsShareCode = (from c in dcShare.ShareCode
                               where 1 == 1
                               && ListAutoKey.Contains(c.AutoKey)
                               && ListCode.Contains(c.Code)
                               && ListKey.Contains(c.Code)
                               select c).ToList();

            foreach (var ItemShareCode in ShareCodeDelete.ListShareCode)
            {
                var AutoKey = ItemShareCode.AutoKey;
                var Code = ItemShareCode.Code;
                var Key = ItemShareCode.Code;

                var rShareCode = (from c in rsShareCode
                                  where 1 == 1
                                  && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                  && ((Code.Length == 0) || (c.Code == Code))
                                  && ((Key.Length == 0) || (c.Code == Key))
                                  select c).FirstOrDefault();

                if (rShareCode != null)
                {
                    if (rShareCode.SystemUse)
                    {
                        rVdb = new ShareCodeDeleteResult();
                        rVdb.Code = "0302000003";
                        rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                        rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，系統參數不可刪除";
                        rVdb.Pass = false;
                        Vdb.Add(rVdb);
                    }
                    else
                    {
                        rShareCode.Status = "2";
                        rShareCode.UpdateMan = ShareCodeDelete.UpdateMan;
                        rShareCode.UpdateDate = _NowDate;
                    }
                }
                else
                {
                    rVdb = new ShareCodeDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareCodeDelete), ShareCodeDelete.AppName, ShareCodeDelete.IpAddress, ShareCodeDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareCodeDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareCodeDelete), ShareCodeDelete.AppName, ShareCodeDelete.IpAddress, ShareCodeDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareCodeDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareCodeDelete.AppName, ShareCodeDelete.IpAddress, ShareCodeDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}