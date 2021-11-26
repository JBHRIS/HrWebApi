using Bll.Share.Vdb;
using Bll.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Dal.Dao.Share
{
    /// <summary>
    /// 
    /// </summary>
    public class ShareValidateDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public ShareValidateDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public ShareValidateDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public ShareValidateDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public ShareValidateDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得驗証
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List ShareValidateRow</returns>
        public List<ShareValidateRow> GetShareValidate(ShareValidateConditions Cond)
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

            var VdbSql = (from c in dcShare.ShareValidate
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          select new ShareValidateRow
                          {
                              Key = c.AutoKey.ToString(),
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              Param = c.Param,
                              DateA = c.DateA,
                              DateD = c.DateD,
                              DateOpen = c.DateOpen.GetValueOrDefault(_DefDate),
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
        /// 儲存驗証檢查
        /// </summary>
        /// <param name="ShareValidateSave"></param>
        /// <returns>List ShareValidateSaveResult</returns>
        public List<ShareValidateSaveResult> ShareValidateSaveCheck(ShareValidateSaveRow ShareValidateSave)
        {
            var ListData = DataTrans.ToDataTable(ShareValidateSave.ListShareValidate);

            //主鍵
            var ListAutoKey = ShareValidateSave.ListShareValidate.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareValidateSave.ListShareValidate.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareValidateSave.ListShareValidate.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareValidate = (from c in dcShare.ShareValidate
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareValidate);

            var ListDataCheck = DataCheck("ShareValidate", ListData, TableData, false, "04");

            var Vdb = new List<ShareValidateSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareValidateSaveResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存驗証
        /// </summary>
        /// <param name="ShareValidateSave"></param>
        /// <returns>ShareValidateSaveResult</returns>
        public List<ShareValidateSaveResult> ShareValidateSave(ShareValidateSaveRow ShareValidateSave)
        {
            var SubmitChanges = ShareValidateSave.SubmitChanges;
            var DataCheck = ShareValidateSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareValidateSaveResult>();
            ShareValidateSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareValidateSaveCheck(ShareValidateSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareValidateSave.ListShareValidate.Select(p => p.AutoKey).ToList();
            var ListCode = ShareValidateSave.ListShareValidate.Select(p => p.Code).ToList();
            var ListKey = ShareValidateSave.ListShareValidate.Select(p => p.Code).ToList();

            var rsShareValidate = (from c in dcShare.ShareValidate
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemShareValidate in ShareValidateSave.ListShareValidate)
            {
                var AutoKey = ItemShareValidate.AutoKey;
                var Code = ItemShareValidate.Code;
                var Key = ItemShareValidate.Code;

                var rShareValidate = (from c in rsShareValidate
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rShareValidate == null)
                {
                    rShareValidate = new ShareValidate();
                    rShareValidate.Code = ItemShareValidate.Code;
                    rShareValidate.Status = ItemShareValidate.Status;
                    rShareValidate.InsertMan = ShareValidateSave.UpdateMan;
                    rShareValidate.InsertDate = _NowDate;
                    dcShare.ShareValidate.InsertOnSubmit(rShareValidate);
                }

                rShareValidate.Param = ItemShareValidate.Param;
                rShareValidate.DateA = ItemShareValidate.DateA;
                rShareValidate.DateD = ItemShareValidate.DateD;
                rShareValidate.DateOpen = ItemShareValidate.DateOpen;
                rShareValidate.UpdateMan = ShareValidateSave.UpdateMan;
                rShareValidate.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new ShareValidateSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareValidateSave), ShareValidateSave.AppName, ShareValidateSave.IpAddress, ShareValidateSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareValidateSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareValidateSave.AppName, ShareValidateSave.IpAddress, ShareValidateSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增驗証檢查
        /// </summary>
        /// <param name="ShareValidateInsert"></param>
        /// <returns>List ShareValidateInsertResult</returns>
        public List<ShareValidateInsertResult> ShareValidateInsertCheck(ShareValidateInsertRow ShareValidateInsert)
        {
            var ListData = DataTrans.ToDataTable(ShareValidateInsert.ListShareValidate);

            //主鍵
            var ListAutoKey = ShareValidateInsert.ListShareValidate.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareValidateInsert.ListShareValidate.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareValidateInsert.ListShareValidate.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareValidate = (from c in dcShare.ShareValidate
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareValidate);

            var ListDataCheck = DataCheck("ShareValidate", ListData, TableData, true, "01");

            var Vdb = new List<ShareValidateInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareValidateInsertResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增驗証
        /// </summary>
        /// <param name="ShareValidateInsert"></param>
        /// <returns>ShareValidateInsertResult</returns>
        public List<ShareValidateInsertResult> ShareValidateInsert(ShareValidateInsertRow ShareValidateInsert)
        {
            var SubmitChanges = ShareValidateInsert.SubmitChanges;
            var DataCheck = ShareValidateInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareValidateInsertResult>();
            ShareValidateInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareValidateInsertCheck(ShareValidateInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemShareValidate in ShareValidateInsert.ListShareValidate)
            {
                var rShareValidate = new ShareValidate();
                rShareValidate.Code = ItemShareValidate.Code;
                rShareValidate.Param = ItemShareValidate.Param;
                rShareValidate.DateA = ItemShareValidate.DateA;
                rShareValidate.DateD = ItemShareValidate.DateD;
                rShareValidate.DateOpen = ItemShareValidate.DateOpen;
                rShareValidate.Status = ItemShareValidate.Status;
                rShareValidate.InsertMan = ShareValidateInsert.InsertMan;
                rShareValidate.InsertDate = _NowDate;
                rShareValidate.UpdateMan = ShareValidateInsert.InsertMan;
                rShareValidate.UpdateDate = _NowDate;
                dcShare.ShareValidate.InsertOnSubmit(rShareValidate);
            }

            try
            {
                rVdb = new ShareValidateInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareValidateInsert), ShareValidateInsert.AppName, ShareValidateInsert.IpAddress, ShareValidateInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareValidateInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareValidateInsert.AppName, ShareValidateInsert.IpAddress, ShareValidateInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改驗証檢查
        /// </summary>
        /// <param name="ShareValidateUpdate"></param>
        /// <returns>List ShareValidateUpdateResult</returns>
        public List<ShareValidateUpdateResult> ShareValidateUpdateCheck(ShareValidateUpdateRow ShareValidateUpdate)
        {
            var ListData = DataTrans.ToDataTable(ShareValidateUpdate.ListShareValidate);

            //主鍵
            var ListAutoKey = ShareValidateUpdate.ListShareValidate.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareValidateUpdate.ListShareValidate.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareValidateUpdate.ListShareValidate.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareValidate = (from c in dcShare.ShareValidate
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareValidate);

            var ListDataCheck = DataCheck("ShareValidate", ListData, TableData, true, "02");

            var Vdb = new List<ShareValidateUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareValidateUpdateResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改驗証
        /// </summary>
        /// <param name="ShareValidateUpdate"></param>
        /// <returns>ShareValidateUpdateResult</returns>
        public List<ShareValidateUpdateResult> ShareValidateUpdate(ShareValidateUpdateRow ShareValidateUpdate)
        {
            var SubmitChanges = ShareValidateUpdate.SubmitChanges;
            var DataCheck = ShareValidateUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareValidateUpdateResult>();
            ShareValidateUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareValidateUpdateCheck(ShareValidateUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareValidateUpdate.ListShareValidate.Select(p => p.AutoKey).ToList();
            var ListCode = ShareValidateUpdate.ListShareValidate.Select(p => p.Code).ToList();
            var ListKey = ShareValidateUpdate.ListShareValidate.Select(p => p.Code).ToList();

            var rsShareValidate = (from c in dcShare.ShareValidate
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemShareValidate in ShareValidateUpdate.ListShareValidate)
            {
                var AutoKey = ItemShareValidate.AutoKey;
                var Code = ItemShareValidate.Code;
                var Key = ItemShareValidate.Code;

                var rShareValidate = (from c in rsShareValidate
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rShareValidate != null)
                {
                    rShareValidate.Param = ItemShareValidate.Param;
                    rShareValidate.DateA = ItemShareValidate.DateA;
                    rShareValidate.DateD = ItemShareValidate.DateD;
                    rShareValidate.DateOpen = ItemShareValidate.DateOpen;
                    rShareValidate.UpdateMan = ShareValidateUpdate.UpdateMan;
                    rShareValidate.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareValidateUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareValidateUpdate), ShareValidateUpdate.AppName, ShareValidateUpdate.IpAddress, ShareValidateUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareValidateUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareValidateUpdate), ShareValidateUpdate.AppName, ShareValidateUpdate.IpAddress, ShareValidateUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareValidateUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareValidateUpdate.AppName, ShareValidateUpdate.IpAddress, ShareValidateUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除驗証檢查
        /// </summary>
        /// <param name="ShareValidateDelete"></param>
        /// <returns>List ShareValidateDeleteResult</returns>
        public List<ShareValidateDeleteResult> ShareValidateDeleteCheck(ShareValidateDeleteRow ShareValidateDelete)
        {
            var ListData = DataTrans.ToDataTable(ShareValidateDelete.ListShareValidate);

            //主鍵
            var ListAutoKey = ShareValidateDelete.ListShareValidate.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareValidateDelete.ListShareValidate.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareValidateDelete.ListShareValidate.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareValidate = (from c in dcShare.ShareValidate
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareValidate);

            var ListDataCheck = DataCheck("ShareValidate", ListData, TableData, true, "03");

            var Vdb = new List<ShareValidateDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareValidateDeleteResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除驗証
        /// </summary>
        /// <param name="ShareValidateDelete"></param>
        /// <returns>ShareValidateDeleteResult</returns>
        public List<ShareValidateDeleteResult> ShareValidateDelete(ShareValidateDeleteRow ShareValidateDelete)
        {
            var SubmitChanges = ShareValidateDelete.SubmitChanges;
            var DataCheck = ShareValidateDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareValidateDeleteResult>();
            ShareValidateDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareValidateDeleteCheck(ShareValidateDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareValidateDelete.ListShareValidate.Select(p => p.AutoKey).ToList();
            var ListCode = ShareValidateDelete.ListShareValidate.Select(p => p.Code).ToList();
            var ListKey = ShareValidateDelete.ListShareValidate.Select(p => p.Code).ToList();

            var rsShareValidate = (from c in dcShare.ShareValidate
                                   where 1 == 1
                                   && ListAutoKey.Contains(c.AutoKey)
                                   && ListCode.Contains(c.Code)
                                   && ListKey.Contains(c.Code)
                                   select c).ToList();

            foreach (var ItemShareValidate in ShareValidateDelete.ListShareValidate)
            {
                var AutoKey = ItemShareValidate.AutoKey;
                var Code = ItemShareValidate.Code;
                var Key = ItemShareValidate.Code;

                var rShareValidate = (from c in rsShareValidate
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rShareValidate != null)
                {
                    rShareValidate.Status = "2";
                    rShareValidate.UpdateMan = ShareValidateDelete.UpdateMan;
                    rShareValidate.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareValidateDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareValidateDelete), ShareValidateDelete.AppName, ShareValidateDelete.IpAddress, ShareValidateDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareValidateDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareValidateDelete), ShareValidateDelete.AppName, ShareValidateDelete.IpAddress, ShareValidateDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareValidateDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareValidateDelete.AppName, ShareValidateDelete.IpAddress, ShareValidateDelete.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 設定驗証網頁相關資料
        /// </summary>
        /// <param name="ValidateKey">驗証碼</param>
        /// <param name="Param">參數內容(有加過密)</param>
        /// <param name="UserCode">UserCode</param>
        /// <param name="Minutes">效期延遲分鐘數</param>
        /// <returns>bool</returns>
        public bool SetValidate(string ValidateKey, string Param, string UserCode = "System", int Minutes = 1)
        {
            //取得系統設定的時間
            if (Minutes == 0)
            {
                var oShareDefault = new ShareDefaultDao(dcShare);
                var DefaultSystem = oShareDefault.DefaultSystem;
                Minutes = DefaultSystem.UrlValidMinutes;
            }   

            var r = new ShareValidate();
            r.Code = ValidateKey;
            r.Param = Param;
            r.DateA = _NowDate;
            r.DateD = _NowDate.AddMinutes(Minutes);
            r.Status = "1";
            r.InsertMan = UserCode;
            r.InsertDate = _NowDate;
            r.UpdateMan = UserCode;
            r.UpdateDate = _NowDate;
            dcShare.ShareValidate.InsertOnSubmit(r);
            dcShare.SubmitChanges();

            return true;
        }

        /// <summary>
        /// 是否有驗証通過並寫回開啟網頁日期
        /// </summary>
        /// <param name="ValidateKey">驗証碼</param>
        /// <returns>bool</returns>
        public bool IsValidate(string ValidateKey)
        {
            bool IsValidate = false;
            var r = (from c in dcShare.ShareValidate
                     where c.Code == ValidateKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                var DateA = r.DateA;
                var DateD = r.DateD;

                if (DateA <= _NowDate && _NowDate <= DateD)
                {
                    r.DateOpen = DateTime.Now;
                    dcShare.SubmitChanges();
                    IsValidate = true;
                }
            }

            return IsValidate;
        }
    }
}