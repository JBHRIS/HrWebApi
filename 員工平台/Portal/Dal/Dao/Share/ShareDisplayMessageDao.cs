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
    public class ShareDisplayMessageDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public ShareDisplayMessageDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public ShareDisplayMessageDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public ShareDisplayMessageDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public ShareDisplayMessageDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得顯示訊息
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List ShareDisplayMessageRow</returns>
        public List<ShareDisplayMessageRow> GetShareDisplayMessage(ShareDisplayMessageConditions Cond)
        {
            //資料狀態
            var ListStatus = Cond.ListStatus;
            //搜尋條件
            //自動編號
            var AutoKey = Cond.AutoKey;
            //代碼
            var Code = Cond.Code;
            //群組代碼
            var DisplayTypeCode = Cond.DisplayTypeCode;

            var VdbSql = (from c in dcShare.ShareDisplayMessage
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((c.SystemCode == "Share" || c.SystemCode == _SystemCode))
                          && ((DisplayTypeCode.Length == 0) || (c.DisplayTypeCode == DisplayTypeCode))
                          orderby c.Sort
                          select new ShareDisplayMessageRow
                          {
                              AutoKey = c.AutoKey,
                              SystemCode = c.SystemCode,
                              Code = c.Code,
                              DisplayTypeCode = c.DisplayTypeCode,
                              DisplayTypeName = "",
                              TitleContents = c.TitleContents,
                              Contents = c.Contents,
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
            var rsDisplayType = ShareCodeNameCode("DisplayType");
            foreach (var rVdb in Vdb)
            {
                rVdb.DisplayTypeName = rsDisplayType.FirstOrDefault(p => p.Code == rVdb.DisplayTypeCode)?.Name ?? rVdb.DisplayTypeName;
            }

            return Vdb;
        }

        /// <summary>
        /// 取得顯示訊息內容(多筆)
        /// </summary>
        /// <param name="ListCode">訊息代碼</param>
        /// <returns>List ShareDisplayMessageContentsRow</returns>
        public List<ShareDisplayMessageContentsRow> GetShareDisplayMessageContents(List<string> ListCode)
        {
            var Vdb = (from c in dcShare.ShareDisplayMessage
                       where ListCode.Contains(c.Code)
                       select new ShareDisplayMessageContentsRow
                       {
                           TitleContents = c.TitleContents,
                           Contents = c.Contents,
                       }).ToList();

            return Vdb;
        }

        /// <summary>
        /// 取得顯示訊息內容(單筆)
        /// </summary>
        /// <param name="Code">訊息代碼</param>
        /// <returns>ShareDisplayMessageContentsRow</returns>
        public ShareDisplayMessageContentsRow GetShareDisplayMessageContents(string Code)
        {
            var Vdb = (from c in dcShare.ShareDisplayMessage
                       where c.Code == Code
                       select new ShareDisplayMessageContentsRow
                       {
                           TitleContents = c.TitleContents,
                           Contents = c.Contents,
                       }).FirstOrDefault();

            if (Vdb == null)
                Vdb = new ShareDisplayMessageContentsRow();

            return Vdb;
        }

        /// <summary>
        /// 儲存顯示訊息檢查
        /// </summary>
        /// <param name="ShareDisplayMessageSave"></param>
        /// <returns>List ShareDisplayMessageSaveResult</returns>
        public List<ShareDisplayMessageSaveResult> ShareDisplayMessageSaveCheck(ShareDisplayMessageSaveRow ShareDisplayMessageSave)
        {
            var ListData = DataTrans.ToDataTable(ShareDisplayMessageSave.ListShareDisplayMessage);

            //主鍵
            var ListAutoKey = ShareDisplayMessageSave.ListShareDisplayMessage.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDisplayMessageSave.ListShareDisplayMessage.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDisplayMessageSave.ListShareDisplayMessage.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDisplayMessage = (from c in dcShare.ShareDisplayMessage
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareDisplayMessage);

            var ListDataCheck = DataCheck("ShareDisplayMessage", ListData, TableData, false, "04");

            var Vdb = new List<ShareDisplayMessageSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareDisplayMessageSaveResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存顯示訊息
        /// </summary>
        /// <param name="ShareDisplayMessageSave"></param>
        /// <returns>ShareDisplayMessageSaveResult</returns>
        public List<ShareDisplayMessageSaveResult> ShareDisplayMessageSave(ShareDisplayMessageSaveRow ShareDisplayMessageSave)
        {
            var SubmitChanges = ShareDisplayMessageSave.SubmitChanges;
            var DataCheck = ShareDisplayMessageSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareDisplayMessageSaveResult>();
            ShareDisplayMessageSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareDisplayMessageSaveCheck(ShareDisplayMessageSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareDisplayMessageSave.ListShareDisplayMessage.Select(p => p.AutoKey).ToList();
            var ListCode = ShareDisplayMessageSave.ListShareDisplayMessage.Select(p => p.Code).ToList();
            var ListKey = ShareDisplayMessageSave.ListShareDisplayMessage.Select(p => p.Code).ToList();

            var rsShareDisplayMessage = (from c in dcShare.ShareDisplayMessage
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemShareDisplayMessage in ShareDisplayMessageSave.ListShareDisplayMessage)
            {
                var AutoKey = ItemShareDisplayMessage.AutoKey;
                var Code = ItemShareDisplayMessage.Code;
                var Key = ItemShareDisplayMessage.Code;

                var rShareDisplayMessage = (from c in rsShareDisplayMessage
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rShareDisplayMessage == null)
                {
                    rShareDisplayMessage = new ShareDisplayMessage();
                    rShareDisplayMessage.Code = ItemShareDisplayMessage.Code;
                    rShareDisplayMessage.Status = ItemShareDisplayMessage.Status;
                    rShareDisplayMessage.InsertMan = ShareDisplayMessageSave.UpdateMan;
                    rShareDisplayMessage.InsertDate = _NowDate;
                    dcShare.ShareDisplayMessage.InsertOnSubmit(rShareDisplayMessage);
                }

                rShareDisplayMessage.DisplayTypeCode = ItemShareDisplayMessage.DisplayTypeCode;
                rShareDisplayMessage.TitleContents = ItemShareDisplayMessage.TitleContents;
                rShareDisplayMessage.Contents = ItemShareDisplayMessage.Contents;
                rShareDisplayMessage.Note = ItemShareDisplayMessage.Note;
                rShareDisplayMessage.Sort = ItemShareDisplayMessage.Sort;
                rShareDisplayMessage.UpdateMan = ShareDisplayMessageSave.UpdateMan;
                rShareDisplayMessage.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new ShareDisplayMessageSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareDisplayMessageSave), ShareDisplayMessageSave.AppName, ShareDisplayMessageSave.IpAddress, ShareDisplayMessageSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareDisplayMessageSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareDisplayMessageSave.AppName, ShareDisplayMessageSave.IpAddress, ShareDisplayMessageSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增顯示訊息檢查
        /// </summary>
        /// <param name="ShareDisplayMessageInsert"></param>
        /// <returns>List ShareDisplayMessageInsertResult</returns>
        public List<ShareDisplayMessageInsertResult> ShareDisplayMessageInsertCheck(ShareDisplayMessageInsertRow ShareDisplayMessageInsert)
        {
            var ListData = DataTrans.ToDataTable(ShareDisplayMessageInsert.ListShareDisplayMessage);

            //主鍵
            var ListAutoKey = ShareDisplayMessageInsert.ListShareDisplayMessage.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDisplayMessageInsert.ListShareDisplayMessage.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDisplayMessageInsert.ListShareDisplayMessage.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDisplayMessage = (from c in dcShare.ShareDisplayMessage
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareDisplayMessage);

            var ListDataCheck = DataCheck("ShareDisplayMessage", ListData, TableData, true, "01");

            var Vdb = new List<ShareDisplayMessageInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareDisplayMessageInsertResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增顯示訊息
        /// </summary>
        /// <param name="ShareDisplayMessageInsert"></param>
        /// <returns>ShareDisplayMessageInsertResult</returns>
        public List<ShareDisplayMessageInsertResult> ShareDisplayMessageInsert(ShareDisplayMessageInsertRow ShareDisplayMessageInsert)
        {
            var SubmitChanges = ShareDisplayMessageInsert.SubmitChanges;
            var DataCheck = ShareDisplayMessageInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareDisplayMessageInsertResult>();
            ShareDisplayMessageInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareDisplayMessageInsertCheck(ShareDisplayMessageInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemShareDisplayMessage in ShareDisplayMessageInsert.ListShareDisplayMessage)
            {
                var rShareDisplayMessage = new ShareDisplayMessage();
                rShareDisplayMessage.Code = ItemShareDisplayMessage.Code;
                rShareDisplayMessage.DisplayTypeCode = ItemShareDisplayMessage.DisplayTypeCode;
                rShareDisplayMessage.TitleContents = ItemShareDisplayMessage.TitleContents;
                rShareDisplayMessage.Contents = ItemShareDisplayMessage.Contents;
                rShareDisplayMessage.Note = ItemShareDisplayMessage.Note;
                rShareDisplayMessage.Sort = ItemShareDisplayMessage.Sort;
                rShareDisplayMessage.Status = ItemShareDisplayMessage.Status;
                rShareDisplayMessage.InsertMan = ShareDisplayMessageInsert.InsertMan;
                rShareDisplayMessage.InsertDate = _NowDate;
                rShareDisplayMessage.UpdateMan = ShareDisplayMessageInsert.InsertMan;
                rShareDisplayMessage.UpdateDate = _NowDate;
                dcShare.ShareDisplayMessage.InsertOnSubmit(rShareDisplayMessage);
            }

            try
            {
                rVdb = new ShareDisplayMessageInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareDisplayMessageInsert), ShareDisplayMessageInsert.AppName, ShareDisplayMessageInsert.IpAddress, ShareDisplayMessageInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareDisplayMessageInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareDisplayMessageInsert.AppName, ShareDisplayMessageInsert.IpAddress, ShareDisplayMessageInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改顯示訊息檢查
        /// </summary>
        /// <param name="ShareDisplayMessageUpdate"></param>
        /// <returns>List ShareDisplayMessageUpdateResult</returns>
        public List<ShareDisplayMessageUpdateResult> ShareDisplayMessageUpdateCheck(ShareDisplayMessageUpdateRow ShareDisplayMessageUpdate)
        {
            var ListData = DataTrans.ToDataTable(ShareDisplayMessageUpdate.ListShareDisplayMessage);

            //主鍵
            var ListAutoKey = ShareDisplayMessageUpdate.ListShareDisplayMessage.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDisplayMessageUpdate.ListShareDisplayMessage.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDisplayMessageUpdate.ListShareDisplayMessage.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDisplayMessage = (from c in dcShare.ShareDisplayMessage
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareDisplayMessage);

            var ListDataCheck = DataCheck("ShareDisplayMessage", ListData, TableData, true, "02");

            var Vdb = new List<ShareDisplayMessageUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareDisplayMessageUpdateResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改顯示訊息
        /// </summary>
        /// <param name="ShareDisplayMessageUpdate"></param>
        /// <returns>ShareDisplayMessageUpdateResult</returns>
        public List<ShareDisplayMessageUpdateResult> ShareDisplayMessageUpdate(ShareDisplayMessageUpdateRow ShareDisplayMessageUpdate)
        {
            var SubmitChanges = ShareDisplayMessageUpdate.SubmitChanges;
            var DataCheck = ShareDisplayMessageUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareDisplayMessageUpdateResult>();
            ShareDisplayMessageUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareDisplayMessageUpdateCheck(ShareDisplayMessageUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareDisplayMessageUpdate.ListShareDisplayMessage.Select(p => p.AutoKey).ToList();
            var ListCode = ShareDisplayMessageUpdate.ListShareDisplayMessage.Select(p => p.Code).ToList();
            var ListKey = ShareDisplayMessageUpdate.ListShareDisplayMessage.Select(p => p.Code).ToList();

            var rsShareDisplayMessage = (from c in dcShare.ShareDisplayMessage
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemShareDisplayMessage in ShareDisplayMessageUpdate.ListShareDisplayMessage)
            {
                var AutoKey = ItemShareDisplayMessage.AutoKey;
                var Code = ItemShareDisplayMessage.Code;
                var Key = ItemShareDisplayMessage.Code;

                var rShareDisplayMessage = (from c in rsShareDisplayMessage
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rShareDisplayMessage != null)
                {
                    rShareDisplayMessage.DisplayTypeCode = ItemShareDisplayMessage.DisplayTypeCode;
                    rShareDisplayMessage.TitleContents = ItemShareDisplayMessage.TitleContents;
                    rShareDisplayMessage.Contents = ItemShareDisplayMessage.Contents;
                    rShareDisplayMessage.Note = ItemShareDisplayMessage.Note;
                    rShareDisplayMessage.Sort = ItemShareDisplayMessage.Sort;
                    rShareDisplayMessage.UpdateMan = ShareDisplayMessageUpdate.UpdateMan;
                    rShareDisplayMessage.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareDisplayMessageUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareDisplayMessageUpdate), ShareDisplayMessageUpdate.AppName, ShareDisplayMessageUpdate.IpAddress, ShareDisplayMessageUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareDisplayMessageUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareDisplayMessageUpdate), ShareDisplayMessageUpdate.AppName, ShareDisplayMessageUpdate.IpAddress, ShareDisplayMessageUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareDisplayMessageUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareDisplayMessageUpdate.AppName, ShareDisplayMessageUpdate.IpAddress, ShareDisplayMessageUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除顯示訊息檢查
        /// </summary>
        /// <param name="ShareDisplayMessageDelete"></param>
        /// <returns>List ShareDisplayMessageDeleteResult</returns>
        public List<ShareDisplayMessageDeleteResult> ShareDisplayMessageDeleteCheck(ShareDisplayMessageDeleteRow ShareDisplayMessageDelete)
        {
            var ListData = DataTrans.ToDataTable(ShareDisplayMessageDelete.ListShareDisplayMessage);

            //主鍵
            var ListAutoKey = ShareDisplayMessageDelete.ListShareDisplayMessage.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDisplayMessageDelete.ListShareDisplayMessage.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDisplayMessageDelete.ListShareDisplayMessage.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDisplayMessage = (from c in dcShare.ShareDisplayMessage
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareDisplayMessage);

            var ListDataCheck = DataCheck("ShareDisplayMessage", ListData, TableData, true, "03");

            var Vdb = new List<ShareDisplayMessageDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareDisplayMessageDeleteResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除顯示訊息
        /// </summary>
        /// <param name="ShareDisplayMessageDelete"></param>
        /// <returns>ShareDisplayMessageDeleteResult</returns>
        public List<ShareDisplayMessageDeleteResult> ShareDisplayMessageDelete(ShareDisplayMessageDeleteRow ShareDisplayMessageDelete)
        {
            var SubmitChanges = ShareDisplayMessageDelete.SubmitChanges;
            var DataCheck = ShareDisplayMessageDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareDisplayMessageDeleteResult>();
            ShareDisplayMessageDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareDisplayMessageDeleteCheck(ShareDisplayMessageDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareDisplayMessageDelete.ListShareDisplayMessage.Select(p => p.AutoKey).ToList();
            var ListCode = ShareDisplayMessageDelete.ListShareDisplayMessage.Select(p => p.Code).ToList();
            var ListKey = ShareDisplayMessageDelete.ListShareDisplayMessage.Select(p => p.Code).ToList();

            var rsShareDisplayMessage = (from c in dcShare.ShareDisplayMessage
                                   where 1 == 1
                                   && ListAutoKey.Contains(c.AutoKey)
                                   && ListCode.Contains(c.Code)
                                   && ListKey.Contains(c.Code)
                                   select c).ToList();

            foreach (var ItemShareDisplayMessage in ShareDisplayMessageDelete.ListShareDisplayMessage)
            {
                var AutoKey = ItemShareDisplayMessage.AutoKey;
                var Code = ItemShareDisplayMessage.Code;
                var Key = ItemShareDisplayMessage.Code;

                var rShareDisplayMessage = (from c in rsShareDisplayMessage
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rShareDisplayMessage != null)
                {
                    rShareDisplayMessage.Status = "2";
                    rShareDisplayMessage.UpdateMan = ShareDisplayMessageDelete.UpdateMan;
                    rShareDisplayMessage.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareDisplayMessageDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareDisplayMessageDelete), ShareDisplayMessageDelete.AppName, ShareDisplayMessageDelete.IpAddress, ShareDisplayMessageDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareDisplayMessageDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareDisplayMessageDelete), ShareDisplayMessageDelete.AppName, ShareDisplayMessageDelete.IpAddress, ShareDisplayMessageDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareDisplayMessageDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareDisplayMessageDelete.AppName, ShareDisplayMessageDelete.IpAddress, ShareDisplayMessageDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}