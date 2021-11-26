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
    public class ShareUploadDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public ShareUploadDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public ShareUploadDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public ShareUploadDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public ShareUploadDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得檔案管理設定
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List ShareUploadRow</returns>
        public List<ShareUploadRow> GetShareUpload(ShareUploadConditions Cond)
        {
            //資料狀態
            var ListStatus = Cond.ListStatus;
            //搜尋條件
            //自動編號
            var AutoKey = Cond.AutoKey;
            //代碼
            var Code = Cond.Code;
            //
            var UseBlob = Cond.UseBlob;
            //主鍵
            var ListCode = Cond.ListCode;
            var Key = Cond.Code;
            var Key1 = Cond.Key1;
            var ListKey1 = Cond.ListKey1;
            var Key2 = Cond.Key2;
            var Key3 = Cond.Key3;
            var Sort = Cond.Sort;

            var VdbSql = (from c in dcShare.ShareUpload
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && (ListCode.Count == 0 || ListCode.Contains(c.Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          && ((Key1.Length == 0) || (c.Key1 == Key1))
                          && (ListKey1.Count == 0 || ListKey1.Contains(c.Key1))
                          && ((Key2.Length == 0) || (c.Key2 == Key2))
                          && ((Key3.Length == 0) || (c.Key3 == Key3))
                          && (Sort == 0 || c.Sort == Sort)
                          orderby c.Sort
                          select new ShareUploadRow
                          {
                              AutoKey = c.AutoKey,
                              SystemCode = c.SystemCode,
                              Code = c.Code,
                              Key1 = c.Key1,
                              Key2 = c.Key2,
                              Key3 = c.Key3,
                              UploadName = c.UploadName,
                              ServerName = c.ServerName,
                              Blob = (UseBlob ? c.Blob : null),
                              ImageUrl = "",
                              Type = c.Type,
                              Size = c.Size,
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
            foreach (var rVdb in Vdb)
            {
                if (UseBlob)
                    rVdb.ImageUrl = @"data:" + rVdb.Type + ";base64," + Convert.ToBase64String(rVdb.Blob.ToArray());
            }

            //處理關聯資料

            return Vdb;
        }

        /// <summary>
        /// 儲存欄位設定檢查
        /// </summary>
        /// <param name="ShareUploadSave"></param>
        /// <returns>List ShareUploadSaveResult</returns>
        public List<ShareUploadSaveResult> ShareUploadSaveCheck(ShareUploadSaveRow ShareUploadSave)
        {
            var ListData = DataTrans.ToDataTable(ShareUploadSave.ListShareUpload);

            //主鍵
            var ListAutoKey = ShareUploadSave.ListShareUpload.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareUploadSave.ListShareUpload.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareUploadSave.ListShareUpload.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareUpload = (from c in dcShare.ShareUpload
                                 where 1 == 1
                                 && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                 && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                 && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                 select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareUpload);

            var ListDataCheck = DataCheck("ShareUpload", ListData, TableData, false, "04");

            var Vdb = new List<ShareUploadSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareUploadSaveResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存欄位設定
        /// </summary>
        /// <param name="ShareUploadSave"></param>
        /// <returns>ShareUploadSaveResult</returns>
        public List<ShareUploadSaveResult> ShareUploadSave(ShareUploadSaveRow ShareUploadSave)
        {
            var SubmitChanges = ShareUploadSave.SubmitChanges;
            var DataCheck = ShareUploadSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareUploadSaveResult>();
            ShareUploadSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareUploadSaveCheck(ShareUploadSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareUploadSave.ListShareUpload.Select(p => p.AutoKey).ToList();
            var ListCode = ShareUploadSave.ListShareUpload.Select(p => p.Code).ToList();
            var ListKey = ShareUploadSave.ListShareUpload.Select(p => p.Code).ToList();

            var rsShareUpload = (from c in dcShare.ShareUpload
                                 where 1 == 1
                                 && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                 && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                 && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                 select c).ToList();

            foreach (var ItemShareUpload in ShareUploadSave.ListShareUpload)
            {
                var AutoKey = ItemShareUpload.AutoKey;
                var Code = ItemShareUpload.Code;
                var Key = ItemShareUpload.Code;

                var rShareUpload = (from c in rsShareUpload
                                    where 1 == 1
                                    && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                    && ((Code.Length == 0) || (c.Code == Code))
                                    && ((Key.Length == 0) || (c.Code == Key))
                                    select c).FirstOrDefault();

                if (rShareUpload == null)
                {
                    rShareUpload = new ShareUpload();
                    rShareUpload.SystemCode = _SystemCode;
                    rShareUpload.Code = ItemShareUpload.Code;
                    rShareUpload.Status = ItemShareUpload.Status;
                    rShareUpload.InsertMan = ShareUploadSave.UpdateMan;
                    rShareUpload.InsertDate = _NowDate;
                    dcShare.ShareUpload.InsertOnSubmit(rShareUpload);
                }
                
                rShareUpload.UploadName = ItemShareUpload.UploadName;
                rShareUpload.ServerName = ItemShareUpload.ServerName;
                rShareUpload.Blob = ItemShareUpload.Blob;
                rShareUpload.Type = ItemShareUpload.Type;
                rShareUpload.Size = ItemShareUpload.Size;
                rShareUpload.SystemUse = ItemShareUpload.SystemUse;
                rShareUpload.Note = ItemShareUpload.Note;
                rShareUpload.Sort = ItemShareUpload.Sort;
                rShareUpload.UpdateMan = ShareUploadSave.UpdateMan;
                rShareUpload.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new ShareUploadSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareUploadSave), ShareUploadSave.AppName, ShareUploadSave.IpAddress, ShareUploadSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareUploadSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareUploadSave.AppName, ShareUploadSave.IpAddress, ShareUploadSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增欄位設定檢查
        /// </summary>
        /// <param name="ShareUploadInsert"></param>
        /// <returns>List ShareUploadInsertResult</returns>
        public List<ShareUploadInsertResult> ShareUploadInsertCheck(ShareUploadInsertRow ShareUploadInsert)
        {
            var ListData = DataTrans.ToDataTable(ShareUploadInsert.ListShareUpload);

            //主鍵
            var ListAutoKey = ShareUploadInsert.ListShareUpload.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareUploadInsert.ListShareUpload.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareUploadInsert.ListShareUpload.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareUpload = (from c in dcShare.ShareUpload
                                 where 1 == 1
                                 && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                 && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                 && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                 select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareUpload);

            var ListDataCheck = DataCheck("ShareUpload", ListData, TableData, true, "01");

            var Vdb = new List<ShareUploadInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareUploadInsertResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增欄位設定
        /// </summary>
        /// <param name="ShareUploadInsert"></param>
        /// <returns>ShareUploadInsertResult</returns>
        public List<ShareUploadInsertResult> ShareUploadInsert(ShareUploadInsertRow ShareUploadInsert)
        {
            var SubmitChanges = ShareUploadInsert.SubmitChanges;
            var DataCheck = ShareUploadInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareUploadInsertResult>();
            ShareUploadInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareUploadInsertCheck(ShareUploadInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemShareUpload in ShareUploadInsert.ListShareUpload)
            {
                var rShareUpload = new ShareUpload();
                rShareUpload.SystemCode = _SystemCode;
                rShareUpload.Code = ItemShareUpload.Code;
                rShareUpload.Key1 = ItemShareUpload.Key1;
                rShareUpload.Key2 = ItemShareUpload.Key2;
                rShareUpload.Key3 = ItemShareUpload.Key3;
                rShareUpload.UploadName = ItemShareUpload.UploadName;
                rShareUpload.ServerName = ItemShareUpload.ServerName;
                rShareUpload.Blob = ItemShareUpload.Blob;
                rShareUpload.Type = ItemShareUpload.Type;
                rShareUpload.Size = ItemShareUpload.Size;
                rShareUpload.SystemUse = ItemShareUpload.SystemUse;
                rShareUpload.Note = ItemShareUpload.Note;
                rShareUpload.Sort = ItemShareUpload.Sort;
                rShareUpload.Status = ItemShareUpload.Status;
                rShareUpload.InsertMan = ShareUploadInsert.InsertMan;
                rShareUpload.InsertDate = _NowDate;
                rShareUpload.UpdateMan = ShareUploadInsert.InsertMan;
                rShareUpload.UpdateDate = _NowDate;
                dcShare.ShareUpload.InsertOnSubmit(rShareUpload);
            }

            try
            {
                rVdb = new ShareUploadInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                //清空檔案內容-太大
                foreach (var ItemShareUpload in ShareUploadInsert.ListShareUpload)
                    ItemShareUpload.Blob = null;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareUploadInsert), ShareUploadInsert.AppName, ShareUploadInsert.IpAddress, ShareUploadInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareUploadInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareUploadInsert.AppName, ShareUploadInsert.IpAddress, ShareUploadInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改欄位設定檢查
        /// </summary>
        /// <param name="ShareUploadUpdate"></param>
        /// <returns>List ShareUploadUpdateResult</returns>
        public List<ShareUploadUpdateResult> ShareUploadUpdateCheck(ShareUploadUpdateRow ShareUploadUpdate)
        {
            var ListData = DataTrans.ToDataTable(ShareUploadUpdate.ListShareUpload);

            //主鍵
            var ListAutoKey = ShareUploadUpdate.ListShareUpload.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareUploadUpdate.ListShareUpload.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareUploadUpdate.ListShareUpload.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareUpload = (from c in dcShare.ShareUpload
                                 where 1 == 1
                                 && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                 && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                 && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                 select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareUpload);

            var ListDataCheck = DataCheck("ShareUpload", ListData, TableData, true, "02");

            var Vdb = new List<ShareUploadUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareUploadUpdateResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改欄位設定
        /// </summary>
        /// <param name="ShareUploadUpdate"></param>
        /// <returns>ShareUploadUpdateResult</returns>
        public List<ShareUploadUpdateResult> ShareUploadUpdate(ShareUploadUpdateRow ShareUploadUpdate)
        {
            var SubmitChanges = ShareUploadUpdate.SubmitChanges;
            var DataCheck = ShareUploadUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareUploadUpdateResult>();
            ShareUploadUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareUploadUpdateCheck(ShareUploadUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareUploadUpdate.ListShareUpload.Select(p => p.AutoKey).ToList();
            var ListCode = ShareUploadUpdate.ListShareUpload.Select(p => p.Code).ToList();
            var ListKey = ShareUploadUpdate.ListShareUpload.Select(p => p.Code).ToList();

            var rsShareUpload = (from c in dcShare.ShareUpload
                                 where 1 == 1
                                 && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                 && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                 && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                 select c).ToList();

            foreach (var ItemShareUpload in ShareUploadUpdate.ListShareUpload)
            {
                var AutoKey = ItemShareUpload.AutoKey;
                var Code = ItemShareUpload.Code;
                var Key = ItemShareUpload.Code;

                var rShareUpload = (from c in rsShareUpload
                                    where 1 == 1
                                    && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                    && ((Code.Length == 0) || (c.Code == Code))
                                    && ((Key.Length == 0) || (c.Code == Key))
                                    select c).FirstOrDefault();

                if (rShareUpload != null)
                {
                    rShareUpload.UploadName = ItemShareUpload.UploadName;
                    rShareUpload.ServerName = ItemShareUpload.ServerName;
                    rShareUpload.Blob = ItemShareUpload.Blob;
                    rShareUpload.Type = ItemShareUpload.Type;
                    rShareUpload.Size = ItemShareUpload.Size;
                    rShareUpload.SystemUse = ItemShareUpload.SystemUse;
                    rShareUpload.Note = ItemShareUpload.Note;
                    rShareUpload.Sort = ItemShareUpload.Sort;
                    rShareUpload.UpdateMan = ShareUploadUpdate.UpdateMan;
                    rShareUpload.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareUploadUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    //清空檔案內容-太大
                    ItemShareUpload.Blob = null;

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareUploadUpdate), ShareUploadUpdate.AppName, ShareUploadUpdate.IpAddress, ShareUploadUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareUploadUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                //清空檔案內容-太大
                foreach (var ItemShareUpload in ShareUploadUpdate.ListShareUpload)
                    ItemShareUpload.Blob = null;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareUploadUpdate), ShareUploadUpdate.AppName, ShareUploadUpdate.IpAddress, ShareUploadUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareUploadUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareUploadUpdate.AppName, ShareUploadUpdate.IpAddress, ShareUploadUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除欄位設定檢查
        /// </summary>
        /// <param name="ShareUploadDelete"></param>
        /// <returns>List ShareUploadDeleteResult</returns>
        public List<ShareUploadDeleteResult> ShareUploadDeleteCheck(ShareUploadDeleteRow ShareUploadDelete)
        {
            var ListData = DataTrans.ToDataTable(ShareUploadDelete.ListShareUpload);

            //主鍵
            var ListAutoKey = ShareUploadDelete.ListShareUpload.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareUploadDelete.ListShareUpload.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareUploadDelete.ListShareUpload.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareUpload = (from c in dcShare.ShareUpload
                                 where 1 == 1
                                 && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                 && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                 && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                 select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareUpload);

            var ListDataCheck = DataCheck("ShareUpload", ListData, TableData, true, "03");

            var Vdb = new List<ShareUploadDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareUploadDeleteResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除欄位設定
        /// </summary>
        /// <param name="ShareUploadDelete"></param>
        /// <returns>ShareUploadDeleteResult</returns>
        public List<ShareUploadDeleteResult> ShareUploadDelete(ShareUploadDeleteRow ShareUploadDelete)
        {
            var SubmitChanges = ShareUploadDelete.SubmitChanges;
            var DataCheck = ShareUploadDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareUploadDeleteResult>();
            ShareUploadDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareUploadDeleteCheck(ShareUploadDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareUploadDelete.ListShareUpload.Select(p => p.AutoKey).ToList();
            var ListCode = ShareUploadDelete.ListShareUpload.Select(p => p.Code).ToList();
            var ListKey = ShareUploadDelete.ListShareUpload.Select(p => p.Code).ToList();

            var rsShareUpload = (from c in dcShare.ShareUpload
                                 where 1 == 1
                                 && ListAutoKey.Contains(c.AutoKey)
                                 && ListCode.Contains(c.Code)
                                 && ListKey.Contains(c.Code)
                                 select c).ToList();

            foreach (var ItemShareUpload in ShareUploadDelete.ListShareUpload)
            {
                var AutoKey = ItemShareUpload.AutoKey;
                var Code = ItemShareUpload.Code;
                var Key = ItemShareUpload.Code;

                var rShareUpload = (from c in rsShareUpload
                                    where 1 == 1
                                    && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                    && ((Code.Length == 0) || (c.Code == Code))
                                    && ((Key.Length == 0) || (c.Code == Key))
                                    select c).FirstOrDefault();

                if (rShareUpload != null)
                {
                    rShareUpload.Status = "2";
                    rShareUpload.UpdateMan = ShareUploadDelete.UpdateMan;
                    rShareUpload.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareUploadDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    //清空檔案內容-太大
                    ItemShareUpload.Blob = null;

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareUploadDelete), ShareUploadDelete.AppName, ShareUploadDelete.IpAddress, ShareUploadDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareUploadDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                //清空檔案內容-太大
                foreach (var ItemShareUpload in ShareUploadDelete.ListShareUpload)
                    ItemShareUpload.Blob = null;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareUploadDelete), ShareUploadDelete.AppName, ShareUploadDelete.IpAddress, ShareUploadDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareUploadDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareUploadDelete.AppName, ShareUploadDelete.IpAddress, ShareUploadDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}