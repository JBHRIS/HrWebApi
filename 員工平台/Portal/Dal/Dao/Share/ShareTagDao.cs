using Bll.Share.Vdb;
using Bll.System.Vdb;
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
    public class ShareTagDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public ShareTagDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public ShareTagDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public ShareTagDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public ShareTagDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得顯示標籤
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List ShareTagRow</returns>
        public List<ShareTagRow> GetShareTag(ShareTagConditions Cond)
        {
            //資料狀態
            var ListStatus = Cond.ListStatus;
            //搜尋條件
            //忽略驗証日期
            var IgnoreValidDate = Cond.IgnoreValidDate;
            //自動編號
            var AutoKey = Cond.AutoKey;
            //代碼
            var Code = Cond.Code;
            var ListCode = Cond.ListCode;
            if (Cond.Code.Length > 0)
                ListCode.Add(Code);
            //主鍵
            var Key = Cond.Key;
            //標籤類別代碼
            var TagCategoryCode = Cond.TagCategoryCode;

            var VdbSql = (from c in dcShare.ShareTag
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                          && ((Key.Length == 0) || (c.Code == Key))
                          && ((TagCategoryCode.Length == 0) || (c.TagCategoryCode == TagCategoryCode))
                          && (IgnoreValidDate || (c.DateA <= _NowDate && _NowDate <= c.DateD))
                          select new ShareTagRow
                          {
                              AutoNumber = 0,
                              Key = c.Code,
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              Name = c.Name,
                              TagCategoryCode = c.TagCategoryCode,
                              DateA = c.DateA,
                              DateD = c.DateD,
                              Note = c.Note,
                              Status = c.Status,
                              InsertMan = c.InsertMan,
                              InsertDate = c.InsertDate.GetValueOrDefault(_DefDate),
                              UpdateMan = c.UpdateMan,
                              UpdateDate = c.UpdateDate.GetValueOrDefault(_DefDate),
                          });

            var Vdb = VdbSql.ToList();

            //處理代碼資料
            int i = 1;
            foreach (var rVdb in Vdb)
            {
                rVdb.AutoNumber = i;
                i++;
            }

            //處理關聯資料

            return Vdb;
        }

        /// <summary>
        /// 儲存標籤檢查
        /// </summary>
        /// <param name="ShareTagSave"></param>
        /// <returns>List ShareTagSaveResult</returns>
        public List<ShareTagSaveResult> ShareTagSaveCheck(ShareTagSaveRow ShareTagSave)
        {
            var ListData = DataTrans.ToDataTable(ShareTagSave.ListShareTag);

            //主鍵
            var ListAutoKey = ShareTagSave.ListShareTag.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareTagSave.ListShareTag.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareTagSave.ListShareTag.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareTag = (from c in dcShare.ShareTag
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareTag);

            var ListDataCheck = DataCheck("ShareTag", ListData, TableData, false, "04");

            var Vdb = new List<ShareTagSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareTagSaveResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存標籤
        /// </summary>
        /// <param name="ShareTagSave"></param>
        /// <returns>ShareTagSaveResult</returns>
        public List<ShareTagSaveResult> ShareTagSave(ShareTagSaveRow ShareTagSave)
        {
            var SubmitChanges = ShareTagSave.SubmitChanges;
            var DataCheck = ShareTagSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareTagSaveResult>();
            ShareTagSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareTagSaveCheck(ShareTagSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareTagSave.ListShareTag.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareTagSave.ListShareTag.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareTagSave.ListShareTag.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareTag = (from c in dcShare.ShareTag
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemShareTag in ShareTagSave.ListShareTag)
            {
                var AutoKey = ItemShareTag.AutoKey;
                var Code = ItemShareTag.Code;
                var Key = ItemShareTag.Code;

                var rShareTag = (from c in rsShareTag
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rShareTag == null)
                {
                    rShareTag = new ShareTag();
                    rShareTag.Code = ItemShareTag.Code;
                    rShareTag.Status = ItemShareTag.Status;
                    rShareTag.InsertMan = ShareTagSave.UpdateMan;
                    rShareTag.InsertDate = _NowDate;
                    dcShare.ShareTag.InsertOnSubmit(rShareTag);
                }

                rShareTag.Name = ItemShareTag.Name;
                rShareTag.TagCategoryCode = ItemShareTag.TagCategoryCode;
                rShareTag.DateA = ItemShareTag.DateA;
                rShareTag.DateD = ItemShareTag.DateD;
                rShareTag.Note = ItemShareTag.Note;
                rShareTag.UpdateMan = ShareTagSave.UpdateMan;
                rShareTag.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new ShareTagSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareTagSave), ShareTagSave.AppName, ShareTagSave.IpAddress, ShareTagSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareTagSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareTagSave.AppName, ShareTagSave.IpAddress, ShareTagSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增標籤檢查
        /// </summary>
        /// <param name="ShareTagInsert"></param>
        /// <returns>List ShareTagInsertResult</returns>
        public List<ShareTagInsertResult> ShareTagInsertCheck(ShareTagInsertRow ShareTagInsert)
        {
            var ListData = DataTrans.ToDataTable(ShareTagInsert.ListShareTag);

            //主鍵
            var ListAutoKey = ShareTagInsert.ListShareTag.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareTagInsert.ListShareTag.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareTagInsert.ListShareTag.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareTag = (from c in dcShare.ShareTag
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareTag);

            var ListDataCheck = DataCheck("ShareTag", ListData, TableData, true, "01");

            var Vdb = new List<ShareTagInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareTagInsertResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增標籤
        /// </summary>
        /// <param name="ShareTagInsert"></param>
        /// <returns>ShareTagInsertResult</returns>
        public List<ShareTagInsertResult> ShareTagInsert(ShareTagInsertRow ShareTagInsert)
        {
            var SubmitChanges = ShareTagInsert.SubmitChanges;
            var DataCheck = ShareTagInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareTagInsertResult>();
            ShareTagInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareTagInsertCheck(ShareTagInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemShareTag in ShareTagInsert.ListShareTag)
            {
                var rShareTag = new ShareTag();
                rShareTag.Code = ItemShareTag.Code;
                rShareTag.Name = ItemShareTag.Name;
                rShareTag.TagCategoryCode = ItemShareTag.TagCategoryCode;
                rShareTag.DateA = ItemShareTag.DateA;
                rShareTag.DateD = ItemShareTag.DateD;
                rShareTag.Note = ItemShareTag.Note;
                rShareTag.Status = ItemShareTag.Status;
                rShareTag.InsertMan = ShareTagInsert.InsertMan;
                rShareTag.InsertDate = _NowDate;
                rShareTag.UpdateMan = ShareTagInsert.InsertMan;
                rShareTag.UpdateDate = _NowDate;
                dcShare.ShareTag.InsertOnSubmit(rShareTag);
            }

            try
            {
                rVdb = new ShareTagInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareTagInsert), ShareTagInsert.AppName, ShareTagInsert.IpAddress, ShareTagInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareTagInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareTagInsert.AppName, ShareTagInsert.IpAddress, ShareTagInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改標籤檢查
        /// </summary>
        /// <param name="ShareTagUpdate"></param>
        /// <returns>List ShareTagUpdateResult</returns>
        public List<ShareTagUpdateResult> ShareTagUpdateCheck(ShareTagUpdateRow ShareTagUpdate)
        {
            var ListData = DataTrans.ToDataTable(ShareTagUpdate.ListShareTag);

            //主鍵
            var ListAutoKey = ShareTagUpdate.ListShareTag.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareTagUpdate.ListShareTag.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareTagUpdate.ListShareTag.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareTag = (from c in dcShare.ShareTag
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareTag);

            var ListDataCheck = DataCheck("ShareTag", ListData, TableData, true, "02");

            var Vdb = new List<ShareTagUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareTagUpdateResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改標籤
        /// </summary>
        /// <param name="ShareTagUpdate"></param>
        /// <returns>ShareTagUpdateResult</returns>
        public List<ShareTagUpdateResult> ShareTagUpdate(ShareTagUpdateRow ShareTagUpdate)
        {
            var SubmitChanges = ShareTagUpdate.SubmitChanges;
            var DataCheck = ShareTagUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareTagUpdateResult>();
            ShareTagUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareTagUpdateCheck(ShareTagUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareTagUpdate.ListShareTag.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareTagUpdate.ListShareTag.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareTagUpdate.ListShareTag.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareTag = (from c in dcShare.ShareTag
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemShareTag in ShareTagUpdate.ListShareTag)
            {
                var AutoKey = ItemShareTag.AutoKey;
                var Code = ItemShareTag.Code;
                var Key = ItemShareTag.Code;

                var rShareTag = (from c in rsShareTag
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rShareTag != null)
                {
                    rShareTag.Name = ItemShareTag.Name;
                    rShareTag.TagCategoryCode = ItemShareTag.TagCategoryCode;
                    rShareTag.DateA = ItemShareTag.DateA;
                    rShareTag.DateD = ItemShareTag.DateD;
                    rShareTag.Note = ItemShareTag.Note;
                    rShareTag.UpdateMan = ShareTagUpdate.UpdateMan;
                    rShareTag.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareTagUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareTagUpdate), ShareTagUpdate.AppName, ShareTagUpdate.IpAddress, ShareTagUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareTagUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareTagUpdate), ShareTagUpdate.AppName, ShareTagUpdate.IpAddress, ShareTagUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareTagUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareTagUpdate.AppName, ShareTagUpdate.IpAddress, ShareTagUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除標籤檢查
        /// </summary>
        /// <param name="ShareTagDelete"></param>
        /// <returns>List ShareTagDeleteResult</returns>
        public List<ShareTagDeleteResult> ShareTagDeleteCheck(ShareTagDeleteRow ShareTagDelete)
        {
            var ListData = DataTrans.ToDataTable(ShareTagDelete.ListShareTag);

            //主鍵
            var ListAutoKey = ShareTagDelete.ListShareTag.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareTagDelete.ListShareTag.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareTagDelete.ListShareTag.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareTag = (from c in dcShare.ShareTag
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareTag);

            var ListDataCheck = DataCheck("ShareTag", ListData, TableData, true, "03");

            var Vdb = new List<ShareTagDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareTagDeleteResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除標籤
        /// </summary>
        /// <param name="ShareTagDelete"></param>
        /// <returns>ShareTagDeleteResult</returns>
        public List<ShareTagDeleteResult> ShareTagDelete(ShareTagDeleteRow ShareTagDelete)
        {
            var SubmitChanges = ShareTagDelete.SubmitChanges;
            var DataCheck = ShareTagDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareTagDeleteResult>();
            ShareTagDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareTagDeleteCheck(ShareTagDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareTagDelete.ListShareTag.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareTagDelete.ListShareTag.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareTagDelete.ListShareTag.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareTag = (from c in dcShare.ShareTag
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemShareTag in ShareTagDelete.ListShareTag)
            {
                var AutoKey = ItemShareTag.AutoKey;
                var Code = ItemShareTag.Code;
                var Key = ItemShareTag.Code;

                var rShareTag = (from c in rsShareTag
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rShareTag != null)
                {
                    rShareTag.Status = "2";
                    rShareTag.UpdateMan = ShareTagDelete.UpdateMan;
                    rShareTag.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareTagDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareTagDelete), ShareTagDelete.AppName, ShareTagDelete.IpAddress, ShareTagDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareTagDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareTagDelete), ShareTagDelete.AppName, ShareTagDelete.IpAddress, ShareTagDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareTagDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareTagDelete.AppName, ShareTagDelete.IpAddress, ShareTagDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}