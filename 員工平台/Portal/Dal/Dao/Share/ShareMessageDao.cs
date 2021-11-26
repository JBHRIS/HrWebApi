using Bll.Share.Vdb;
using Bll.System.Vdb;
using Bll.Tools;
using Dal.Dao.System;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dao.Share
{
    /// <summary>
    /// 
    /// </summary>
    public class ShareMessageDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public ShareMessageDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public ShareMessageDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public ShareMessageDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public ShareMessageDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得顯示訊息
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List ShareMessageRow</returns>
        public List<ShareMessageRow> GetShareMessage(ShareMessageConditions Cond)
        {
            //資料狀態
            var ListStatus = Cond.ListStatus;
            //搜尋條件
            //自動編號
            var AutoKey = Cond.AutoKey;
            //代碼
            var Code = Cond.Code;
            //主鍵
            var Key = Cond.Code;
            //類別
            var ListMessageTypeCode = Cond.ListMessageTypeCode;
            //處理狀態
            var ListHandleStatusCode = Cond.ListHandleStatusCode;

            var VdbSql = (from c in dcShare.ShareMessage
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          && ((c.SystemCode == "Share" || c.SystemCode == _SystemCode))
                          && (ListMessageTypeCode.Contains(c.MessageTypeCode))
                          && (ListHandleStatusCode.Contains(c.HandleStatusCode))
                          orderby c.Sort
                          select new ShareMessageRow
                          {
                              Key = c.AutoKey.ToString(),
                              AutoKey = c.AutoKey,
                              SystemCode = c.SystemCode,
                              Code = c.Code,
                              MessageTypeCode = c.MessageTypeCode,
                              MessageTypeName = "",
                              Contents = c.Contents,
                              SystemContents = c.SystemContents,
                              AppName = c.AppName,
                              HandleStatusCode = c.HandleStatusCode,
                              HandleStatusName = "",
                              IpAddress = c.IpAddress,
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
            var rsMessageType = ShareCodeNameCode("MessageType");
            var rsHandleStatus = ShareCodeNameCode("HandleStatus");
            foreach (var rVdb in Vdb)
            {
                rVdb.MessageTypeName = rsMessageType.FirstOrDefault(p => p.Code == rVdb.MessageTypeCode)?.Name ?? rVdb.MessageTypeName;
                rVdb.HandleStatusName = rsHandleStatus.FirstOrDefault(p => p.Code == rVdb.HandleStatusCode)?.Name ?? rVdb.HandleStatusName;
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存訊息檢查
        /// </summary>
        /// <param name="ShareMessageSave"></param>
        /// <returns>List ShareMessageSaveResult</returns>
        public List<ShareMessageSaveResult> ShareMessageSaveCheck(ShareMessageSaveRow ShareMessageSave)
        {
            var ListData = DataTrans.ToDataTable(ShareMessageSave.ListShareMessage);

            //主鍵
            var ListAutoKey = ShareMessageSave.ListShareMessage.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareMessageSave.ListShareMessage.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareMessageSave.ListShareMessage.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareMessage = (from c in dcShare.ShareMessage
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareMessage);

            var ListDataCheck = DataCheck("ShareMessage", ListData, TableData, false, "04");

            var Vdb = new List<ShareMessageSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareMessageSaveResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存訊息
        /// </summary>
        /// <param name="ShareMessageSave"></param>
        /// <returns>ShareMessageSaveResult</returns>
        public List<ShareMessageSaveResult> ShareMessageSave(ShareMessageSaveRow ShareMessageSave)
        {
            var SubmitChanges = ShareMessageSave.SubmitChanges;
            var DataCheck = ShareMessageSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareMessageSaveResult>();
            ShareMessageSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareMessageSaveCheck(ShareMessageSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareMessageSave.ListShareMessage.Select(p => p.AutoKey).ToList();
            var ListCode = ShareMessageSave.ListShareMessage.Select(p => p.Code).ToList();
            var ListKey = ShareMessageSave.ListShareMessage.Select(p => p.Code).ToList();

            var rsShareMessage = (from c in dcShare.ShareMessage
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            foreach (var ItemShareMessage in ShareMessageSave.ListShareMessage)
            {
                var AutoKey = ItemShareMessage.AutoKey;
                var Code = ItemShareMessage.Code;
                var Key = ItemShareMessage.Code;

                var rShareMessage = (from c in rsShareMessage
                                     where 1 == 1
                                     && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                     && ((Code.Length == 0) || (c.Code == Code))
                                     && ((Key.Length == 0) || (c.Code == Key))
                                     select c).FirstOrDefault();

                if (rShareMessage == null)
                {
                    rShareMessage = new ShareMessage();
                    rShareMessage.SystemCode = _SystemCode;
                    rShareMessage.Code = ItemShareMessage.Code;
                    rShareMessage.Status = ItemShareMessage.Status;
                    rShareMessage.InsertMan = ShareMessageSave.UpdateMan;
                    rShareMessage.InsertDate = _NowDate;
                    dcShare.ShareMessage.InsertOnSubmit(rShareMessage);
                }

                rShareMessage.MessageTypeCode = ItemShareMessage.MessageTypeCode;
                rShareMessage.Contents = ItemShareMessage.Contents;
                rShareMessage.SystemContents = ItemShareMessage.SystemContents;
                rShareMessage.AppName = ItemShareMessage.AppName;
                rShareMessage.Note = ItemShareMessage.Note;
                rShareMessage.HandleStatusCode = ItemShareMessage.HandleStatusCode;
                rShareMessage.IpAddress = ItemShareMessage.IpAddress;
                rShareMessage.Sort = ItemShareMessage.Sort;
                rShareMessage.UpdateMan = ShareMessageSave.UpdateMan;
                rShareMessage.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new ShareMessageSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareMessageSave), ShareMessageSave.AppName, ShareMessageSave.IpAddress, ShareMessageSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareMessageSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareMessageSave.AppName, ShareMessageSave.IpAddress, ShareMessageSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增訊息檢查
        /// </summary>
        /// <param name="ShareMessageInsert"></param>
        /// <returns>List ShareMessageInsertResult</returns>
        public List<ShareMessageInsertResult> ShareMessageInsertCheck(ShareMessageInsertRow ShareMessageInsert)
        {
            var ListData = DataTrans.ToDataTable(ShareMessageInsert.ListShareMessage);

            //主鍵
            var ListAutoKey = ShareMessageInsert.ListShareMessage.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareMessageInsert.ListShareMessage.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareMessageInsert.ListShareMessage.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareMessage = (from c in dcShare.ShareMessage
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareMessage);

            var ListDataCheck = DataCheck("ShareMessage", ListData, TableData, true, "01");

            var Vdb = new List<ShareMessageInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareMessageInsertResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增訊息
        /// </summary>
        /// <param name="ShareMessageInsert"></param>
        /// <returns>ShareMessageInsertResult</returns>
        public List<ShareMessageInsertResult> ShareMessageInsert(ShareMessageInsertRow ShareMessageInsert)
        {
            var SubmitChanges = ShareMessageInsert.SubmitChanges;
            var DataCheck = ShareMessageInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareMessageInsertResult>();
            ShareMessageInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareMessageInsertCheck(ShareMessageInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemShareMessage in ShareMessageInsert.ListShareMessage)
            {
                var rShareMessage = new ShareMessage();
                rShareMessage.SystemCode = _SystemCode;
                rShareMessage.Code = ItemShareMessage.Code;
                rShareMessage.MessageTypeCode = ItemShareMessage.MessageTypeCode;
                rShareMessage.Contents = ItemShareMessage.Contents;
                rShareMessage.SystemContents = ItemShareMessage.SystemContents;
                rShareMessage.AppName = ShareMessageInsert.AppName;
                rShareMessage.Note = ItemShareMessage.Note;
                rShareMessage.HandleStatusCode = ItemShareMessage.HandleStatusCode;
                rShareMessage.IpAddress = ShareMessageInsert.IpAddress;
                rShareMessage.Sort = ItemShareMessage.Sort;
                rShareMessage.Status = ItemShareMessage.Status;
                rShareMessage.InsertMan = ShareMessageInsert.InsertMan;
                rShareMessage.InsertDate = _NowDate;
                rShareMessage.UpdateMan = ShareMessageInsert.InsertMan;
                rShareMessage.UpdateDate = _NowDate;
                dcShare.ShareMessage.InsertOnSubmit(rShareMessage);
            }

            try
            {
                rVdb = new ShareMessageInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                //無法寫log

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareMessageInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                //無法寫log
            }

            return Vdb;
        }

        /// <summary>
        /// 修改訊息檢查
        /// </summary>
        /// <param name="ShareMessageUpdate"></param>
        /// <returns>List ShareMessageUpdateResult</returns>
        public List<ShareMessageUpdateResult> ShareMessageUpdateCheck(ShareMessageUpdateRow ShareMessageUpdate)
        {
            var ListData = DataTrans.ToDataTable(ShareMessageUpdate.ListShareMessage);

            //主鍵
            var ListAutoKey = ShareMessageUpdate.ListShareMessage.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareMessageUpdate.ListShareMessage.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareMessageUpdate.ListShareMessage.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareMessage = (from c in dcShare.ShareMessage
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareMessage);

            var ListDataCheck = DataCheck("ShareMessage", ListData, TableData, true, "02");

            var Vdb = new List<ShareMessageUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareMessageUpdateResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改訊息
        /// </summary>
        /// <param name="ShareMessageUpdate"></param>
        /// <returns>ShareMessageUpdateResult</returns>
        public List<ShareMessageUpdateResult> ShareMessageUpdate(ShareMessageUpdateRow ShareMessageUpdate)
        {
            var SubmitChanges = ShareMessageUpdate.SubmitChanges;
            var DataCheck = ShareMessageUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareMessageUpdateResult>();
            ShareMessageUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareMessageUpdateCheck(ShareMessageUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareMessageUpdate.ListShareMessage.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareMessageUpdate.ListShareMessage.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareMessageUpdate.ListShareMessage.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareMessage = (from c in dcShare.ShareMessage
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            foreach (var ItemShareMessage in ShareMessageUpdate.ListShareMessage)
            {
                var AutoKey = ItemShareMessage.AutoKey;
                var Code = ItemShareMessage.Code;
                var Key = ItemShareMessage.Code;

                var rShareMessage = (from c in rsShareMessage
                                     where 1 == 1
                                     && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                     && ((Code.Length == 0) || (c.Code == Code))
                                     && ((Key.Length == 0) || (c.Code == Key))
                                     select c).FirstOrDefault();

                if (rShareMessage != null)
                {
                    rShareMessage.MessageTypeCode = ItemShareMessage.MessageTypeCode;
                    rShareMessage.Contents = ItemShareMessage.Contents;
                    rShareMessage.SystemContents = ItemShareMessage.SystemContents;
                    rShareMessage.AppName = ItemShareMessage.AppName;
                    rShareMessage.Note = ItemShareMessage.Note;
                    rShareMessage.HandleStatusCode = ItemShareMessage.HandleStatusCode;
                    rShareMessage.IpAddress = ItemShareMessage.IpAddress;
                    rShareMessage.Sort = ItemShareMessage.Sort;
                    rShareMessage.UpdateMan = ShareMessageUpdate.UpdateMan;
                    rShareMessage.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareMessageUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareMessageUpdate), ShareMessageUpdate.AppName, ShareMessageUpdate.IpAddress, ShareMessageUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareMessageUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareMessageUpdate), ShareMessageUpdate.AppName, ShareMessageUpdate.IpAddress, ShareMessageUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareMessageUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareMessageUpdate.AppName, ShareMessageUpdate.IpAddress, ShareMessageUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除訊息檢查
        /// </summary>
        /// <param name="ShareMessageDelete"></param>
        /// <returns>List ShareMessageDeleteResult</returns>
        public List<ShareMessageDeleteResult> ShareMessageDeleteCheck(ShareMessageDeleteRow ShareMessageDelete)
        {
            var ListData = DataTrans.ToDataTable(ShareMessageDelete.ListShareMessage);

            //主鍵
            var ListAutoKey = ShareMessageDelete.ListShareMessage.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareMessageDelete.ListShareMessage.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareMessageDelete.ListShareMessage.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareMessage = (from c in dcShare.ShareMessage
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareMessage);

            var ListDataCheck = DataCheck("ShareMessage", ListData, TableData, true, "03");

            var Vdb = new List<ShareMessageDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareMessageDeleteResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除訊息
        /// </summary>
        /// <param name="ShareMessageDelete"></param>
        /// <returns>ShareMessageDeleteResult</returns>
        public List<ShareMessageDeleteResult> ShareMessageDelete(ShareMessageDeleteRow ShareMessageDelete)
        {
            var SubmitChanges = ShareMessageDelete.SubmitChanges;
            var DataCheck = ShareMessageDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareMessageDeleteResult>();
            ShareMessageDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareMessageDeleteCheck(ShareMessageDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareMessageDelete.ListShareMessage.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareMessageDelete.ListShareMessage.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareMessageDelete.ListShareMessage.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareMessage = (from c in dcShare.ShareMessage
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            foreach (var ItemShareMessage in ShareMessageDelete.ListShareMessage)
            {
                var AutoKey = ItemShareMessage.AutoKey;
                var Code = ItemShareMessage.Code;
                var Key = ItemShareMessage.Code;

                var rShareMessage = (from c in rsShareMessage
                                     where 1 == 1
                                     && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                     && ((Code.Length == 0) || (c.Code == Code))
                                     && ((Key.Length == 0) || (c.Code == Key))
                                     select c).FirstOrDefault();

                if (rShareMessage != null)
                {
                    rShareMessage.Status = "2";
                    rShareMessage.UpdateMan = ShareMessageDelete.UpdateMan;
                    rShareMessage.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareMessageDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareMessageDelete), ShareMessageDelete.AppName, ShareMessageDelete.IpAddress, ShareMessageDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareMessageDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareMessageDelete), ShareMessageDelete.AppName, ShareMessageDelete.IpAddress, ShareMessageDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareMessageDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareMessageDelete.AppName, ShareMessageDelete.IpAddress, ShareMessageDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}