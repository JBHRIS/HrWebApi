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
    public class ShareDictionaryDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public ShareDictionaryDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public ShareDictionaryDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public ShareDictionaryDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public ShareDictionaryDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得顯示訊息
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List ShareDictionaryRow</returns>
        public List<ShareDictionaryRow> GetShareDictionary(ShareDictionaryConditions Cond)
        {
            //資料狀態
            var ListStatus = Cond.ListStatus;
            //系統代碼
            var SystemCode = Cond.SystemCode;
            //搜尋條件
            //自動編號
            var AutoKey = Cond.AutoKey;
            //代碼
            var Code = Cond.Code;
            //主鍵
            var Key = Cond.Code;
            //類別
            var ListGroupCode = Cond.ListGroupCode;

            var VdbSql = (from c in dcShare.ShareDictionary
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          && ((c.SystemCode == "Share" || c.SystemCode == SystemCode))
                          && (ListGroupCode.Count == 0 || ListGroupCode.Contains(c.GroupCode))
                          orderby c.Sort
                          select new ShareDictionaryRow
                          {
                              Key = c.AutoKey.ToString(),
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              GroupCode = c.GroupCode,
                              Name1 = c.Name1,
                              Name2 = c.Name2,
                              Name3 = c.Name3,
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
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存訊息檢查
        /// </summary>
        /// <param name="ShareDictionarySave"></param>
        /// <returns>List ShareDictionarySaveResult</returns>
        public List<ShareDictionarySaveResult> ShareDictionarySaveCheck(ShareDictionarySaveRow ShareDictionarySave)
        {
            var ListData = DataTrans.ToDataTable(ShareDictionarySave.ListShareDictionary);

            //主鍵
            var ListAutoKey = ShareDictionarySave.ListShareDictionary.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDictionarySave.ListShareDictionary.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDictionarySave.ListShareDictionary.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDictionary = (from c in dcShare.ShareDictionary
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareDictionary);

            var ListDataCheck = DataCheck("ShareDictionary", ListData, TableData, false, "04");

            var Vdb = new List<ShareDictionarySaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareDictionarySaveResult();
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
        /// <param name="ShareDictionarySave"></param>
        /// <returns>ShareDictionarySaveResult</returns>
        public List<ShareDictionarySaveResult> ShareDictionarySave(ShareDictionarySaveRow ShareDictionarySave)
        {
            var SubmitChanges = ShareDictionarySave.SubmitChanges;
            var DataCheck = ShareDictionarySave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareDictionarySaveResult>();
            ShareDictionarySaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareDictionarySaveCheck(ShareDictionarySave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareDictionarySave.ListShareDictionary.Select(p => p.AutoKey).ToList();
            var ListCode = ShareDictionarySave.ListShareDictionary.Select(p => p.Code).ToList();
            var ListKey = ShareDictionarySave.ListShareDictionary.Select(p => p.Code).ToList();

            var rsShareDictionary = (from c in dcShare.ShareDictionary
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            foreach (var ItemShareDictionary in ShareDictionarySave.ListShareDictionary)
            {
                var AutoKey = ItemShareDictionary.AutoKey;
                var Code = ItemShareDictionary.Code;
                var Key = ItemShareDictionary.Code;

                var rShareDictionary = (from c in rsShareDictionary
                                     where 1 == 1
                                     && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                     && ((Code.Length == 0) || (c.Code == Code))
                                     && ((Key.Length == 0) || (c.Code == Key))
                                     select c).FirstOrDefault();

                if (rShareDictionary == null)
                {
                    rShareDictionary = new ShareDictionary();
                    rShareDictionary.SystemCode = _SystemCode;
                    rShareDictionary.Code = ItemShareDictionary.Code;
                    rShareDictionary.Status = ItemShareDictionary.Status;
                    rShareDictionary.InsertMan = ShareDictionarySave.UpdateMan;
                    rShareDictionary.InsertDate = _NowDate;
                    dcShare.ShareDictionary.InsertOnSubmit(rShareDictionary);
                }

                rShareDictionary.GroupCode = ItemShareDictionary.GroupCode;
                rShareDictionary.Name1 = ItemShareDictionary.Name1;
                rShareDictionary.Name2 = ItemShareDictionary.Name2;
                rShareDictionary.Name3 = ItemShareDictionary.Name3;
                rShareDictionary.Note = ItemShareDictionary.Note;
                rShareDictionary.Sort = ItemShareDictionary.Sort;
                rShareDictionary.UpdateMan = ShareDictionarySave.UpdateMan;
                rShareDictionary.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new ShareDictionarySaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareDictionarySave), ShareDictionarySave.AppName, ShareDictionarySave.IpAddress, ShareDictionarySave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareDictionarySaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareDictionarySave.AppName, ShareDictionarySave.IpAddress, ShareDictionarySave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增訊息檢查
        /// </summary>
        /// <param name="ShareDictionaryInsert"></param>
        /// <returns>List ShareDictionaryInsertResult</returns>
        public List<ShareDictionaryInsertResult> ShareDictionaryInsertCheck(ShareDictionaryInsertRow ShareDictionaryInsert)
        {
            var ListData = DataTrans.ToDataTable(ShareDictionaryInsert.ListShareDictionary);

            //主鍵
            var ListAutoKey = ShareDictionaryInsert.ListShareDictionary.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDictionaryInsert.ListShareDictionary.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDictionaryInsert.ListShareDictionary.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDictionary = (from c in dcShare.ShareDictionary
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareDictionary);

            var ListDataCheck = DataCheck("ShareDictionary", ListData, TableData, true, "01");

            var Vdb = new List<ShareDictionaryInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareDictionaryInsertResult();
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
        /// <param name="ShareDictionaryInsert"></param>
        /// <returns>ShareDictionaryInsertResult</returns>
        public List<ShareDictionaryInsertResult> ShareDictionaryInsert(ShareDictionaryInsertRow ShareDictionaryInsert)
        {
            var SubmitChanges = ShareDictionaryInsert.SubmitChanges;
            var DataCheck = ShareDictionaryInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareDictionaryInsertResult>();
            ShareDictionaryInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareDictionaryInsertCheck(ShareDictionaryInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemShareDictionary in ShareDictionaryInsert.ListShareDictionary)
            {
                var rShareDictionary = new ShareDictionary();
                rShareDictionary.SystemCode = _SystemCode;
                rShareDictionary.Code = ItemShareDictionary.Code;
                rShareDictionary.GroupCode = ItemShareDictionary.GroupCode;
                rShareDictionary.Name1 = ItemShareDictionary.Name1;
                rShareDictionary.Name2 = ItemShareDictionary.Name2;
                rShareDictionary.Name3 = ItemShareDictionary.Name3;
                rShareDictionary.Note = ItemShareDictionary.Note;
                rShareDictionary.Sort = ItemShareDictionary.Sort;
                rShareDictionary.Status = ItemShareDictionary.Status;
                rShareDictionary.InsertMan = ShareDictionaryInsert.InsertMan;
                rShareDictionary.InsertDate = _NowDate;
                rShareDictionary.UpdateMan = ShareDictionaryInsert.InsertMan;
                rShareDictionary.UpdateDate = _NowDate;
                dcShare.ShareDictionary.InsertOnSubmit(rShareDictionary);
            }

            try
            {
                rVdb = new ShareDictionaryInsertResult();
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
                rVdb = new ShareDictionaryInsertResult();
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
        /// <param name="ShareDictionaryUpdate"></param>
        /// <returns>List ShareDictionaryUpdateResult</returns>
        public List<ShareDictionaryUpdateResult> ShareDictionaryUpdateCheck(ShareDictionaryUpdateRow ShareDictionaryUpdate)
        {
            var ListData = DataTrans.ToDataTable(ShareDictionaryUpdate.ListShareDictionary);

            //主鍵
            var ListAutoKey = ShareDictionaryUpdate.ListShareDictionary.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDictionaryUpdate.ListShareDictionary.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDictionaryUpdate.ListShareDictionary.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDictionary = (from c in dcShare.ShareDictionary
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareDictionary);

            var ListDataCheck = DataCheck("ShareDictionary", ListData, TableData, true, "02");

            var Vdb = new List<ShareDictionaryUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareDictionaryUpdateResult();
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
        /// <param name="ShareDictionaryUpdate"></param>
        /// <returns>ShareDictionaryUpdateResult</returns>
        public List<ShareDictionaryUpdateResult> ShareDictionaryUpdate(ShareDictionaryUpdateRow ShareDictionaryUpdate)
        {
            var SubmitChanges = ShareDictionaryUpdate.SubmitChanges;
            var DataCheck = ShareDictionaryUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareDictionaryUpdateResult>();
            ShareDictionaryUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareDictionaryUpdateCheck(ShareDictionaryUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareDictionaryUpdate.ListShareDictionary.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDictionaryUpdate.ListShareDictionary.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDictionaryUpdate.ListShareDictionary.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDictionary = (from c in dcShare.ShareDictionary
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            foreach (var ItemShareDictionary in ShareDictionaryUpdate.ListShareDictionary)
            {
                var AutoKey = ItemShareDictionary.AutoKey;
                var Code = ItemShareDictionary.Code;
                var Key = ItemShareDictionary.Code;

                var rShareDictionary = (from c in rsShareDictionary
                                     where 1 == 1
                                     && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                     && ((Code.Length == 0) || (c.Code == Code))
                                     && ((Key.Length == 0) || (c.Code == Key))
                                     select c).FirstOrDefault();

                if (rShareDictionary != null)
                {
                    rShareDictionary.GroupCode = ItemShareDictionary.GroupCode;
                    rShareDictionary.Name1 = ItemShareDictionary.Name1;
                    rShareDictionary.Name2 = ItemShareDictionary.Name2;
                    rShareDictionary.Name3 = ItemShareDictionary.Name3;
                    rShareDictionary.Note = ItemShareDictionary.Note;
                    rShareDictionary.Sort = ItemShareDictionary.Sort;
                    rShareDictionary.UpdateMan = ShareDictionaryUpdate.UpdateMan;
                    rShareDictionary.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareDictionaryUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareDictionaryUpdate), ShareDictionaryUpdate.AppName, ShareDictionaryUpdate.IpAddress, ShareDictionaryUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareDictionaryUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareDictionaryUpdate), ShareDictionaryUpdate.AppName, ShareDictionaryUpdate.IpAddress, ShareDictionaryUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareDictionaryUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareDictionaryUpdate.AppName, ShareDictionaryUpdate.IpAddress, ShareDictionaryUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除訊息檢查
        /// </summary>
        /// <param name="ShareDictionaryDelete"></param>
        /// <returns>List ShareDictionaryDeleteResult</returns>
        public List<ShareDictionaryDeleteResult> ShareDictionaryDeleteCheck(ShareDictionaryDeleteRow ShareDictionaryDelete)
        {
            var ListData = DataTrans.ToDataTable(ShareDictionaryDelete.ListShareDictionary);

            //主鍵
            var ListAutoKey = ShareDictionaryDelete.ListShareDictionary.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDictionaryDelete.ListShareDictionary.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDictionaryDelete.ListShareDictionary.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDictionary = (from c in dcShare.ShareDictionary
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareDictionary);

            var ListDataCheck = DataCheck("ShareDictionary", ListData, TableData, true, "03");

            var Vdb = new List<ShareDictionaryDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareDictionaryDeleteResult();
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
        /// <param name="ShareDictionaryDelete"></param>
        /// <returns>ShareDictionaryDeleteResult</returns>
        public List<ShareDictionaryDeleteResult> ShareDictionaryDelete(ShareDictionaryDeleteRow ShareDictionaryDelete)
        {
            var SubmitChanges = ShareDictionaryDelete.SubmitChanges;
            var DataCheck = ShareDictionaryDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareDictionaryDeleteResult>();
            ShareDictionaryDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareDictionaryDeleteCheck(ShareDictionaryDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareDictionaryDelete.ListShareDictionary.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareDictionaryDelete.ListShareDictionary.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareDictionaryDelete.ListShareDictionary.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareDictionary = (from c in dcShare.ShareDictionary
                                  where 1 == 1
                                  && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                  && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                  && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                  select c).ToList();

            foreach (var ItemShareDictionary in ShareDictionaryDelete.ListShareDictionary)
            {
                var AutoKey = ItemShareDictionary.AutoKey;
                var Code = ItemShareDictionary.Code;
                var Key = ItemShareDictionary.Code;

                var rShareDictionary = (from c in rsShareDictionary
                                     where 1 == 1
                                     && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                     && ((Code.Length == 0) || (c.Code == Code))
                                     && ((Key.Length == 0) || (c.Code == Key))
                                     select c).FirstOrDefault();

                if (rShareDictionary != null)
                {
                    rShareDictionary.Status = "2";
                    rShareDictionary.UpdateMan = ShareDictionaryDelete.UpdateMan;
                    rShareDictionary.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareDictionaryDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareDictionaryDelete), ShareDictionaryDelete.AppName, ShareDictionaryDelete.IpAddress, ShareDictionaryDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareDictionaryDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareDictionaryDelete), ShareDictionaryDelete.AppName, ShareDictionaryDelete.IpAddress, ShareDictionaryDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareDictionaryDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareDictionaryDelete.AppName, ShareDictionaryDelete.IpAddress, ShareDictionaryDelete.UpdateMan);
            }

            return Vdb;
        }
        /// <summary>
        /// 取得翻譯文字
        /// </summary>
        /// <param name="PageCode">頁面名稱</param>
        /// <param name="Text">控制項ID，或文字</param>
        /// <param name="TransCode">翻譯代碼</param>
        /// <param name="LanguageCode">語言代碼</param>
        /// <returns></returns>
        public string TextTranslate(string PageCode, string Text, string TransCode,string LanguageCode)
        {
            switch (TransCode)
            {
                case "1":
                    string Translated = (from c in dcShare.ShareDictionary
                                         where c.GroupCode == PageCode && c.Code == Text
                                         select c.Name2).FirstOrDefault();
                    return Translated;
                default:
                    string Translate = (from c in dcShare.ShareDictionary
                                         where c.GroupCode == PageCode && c.Name1 == Text
                                         select c.Name2).FirstOrDefault();
                    return Translate;
            }
            
        }
    }
}