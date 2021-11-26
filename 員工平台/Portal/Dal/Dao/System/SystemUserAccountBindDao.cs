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

namespace Dal.Dao.System
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemUserAccountBindDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public SystemUserAccountBindDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public SystemUserAccountBindDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public SystemUserAccountBindDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 取得顯示欄位設定
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List SystemUserAccountBindRow</returns>
        public List<SystemUserAccountBindRow> GetSystemUserAccountBind(SystemUserAccountBindConditions Cond)
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
            //帳號
            var UserCode = Cond.UserCode;
            //第三方帳號
            var ThirdPartyAccountId = Cond.ThirdPartyAccountId;
            //第三方類別
            var ThirdPartyTypeCode = Cond.ThirdPartyTypeCode;

            var VdbSql = (from c in dcShare.SystemUserAccountBind
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          && ((UserCode.Length == 0) || (c.UserCode == UserCode))
                          && ((ThirdPartyAccountId.Length == 0) || (c.ThirdPartyAccountId == ThirdPartyAccountId))
                          && ((ThirdPartyTypeCode.Length == 0) || (c.ThirdPartyTypeCode == ThirdPartyTypeCode))
                          select new SystemUserAccountBindRow
                          {
                              AutoNumber = 0,
                              Key = c.Code,
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              UserCode = c.UserCode,
                              ThirdPartyAccountId = c.ThirdPartyAccountId,
                              ThirdPartyTypeCode = c.ThirdPartyTypeCode,
                              DateA = c.DateA,
                              DateD = c.DateD,
                              Note = c.Note,
                              Status = c.Status,
                              InsertMan = c.InsertMan,
                              InsertDate = c.InsertDate??(_DefDate),
                              UpdateMan = c.UpdateMan,
                              UpdateDate = c.UpdateDate??(_DefDate),
                          });

            var Vdb = VdbSql.ToList();

            //處理代碼資料
            int i = 1;
            var rsColumnType = ShareCodeNameCode("ColumnType");
            foreach (var rVdb in Vdb)
            {
                rVdb.AutoNumber = i;
                i++;
            }

            //處理關聯資料

            return Vdb;
        }

        /// <summary>
        /// 儲存欄位設定檢查
        /// </summary>
        /// <param name="SystemUserAccountBindSave"></param>
        /// <returns>List SystemUserAccountBindSaveResult</returns>
        public List<SystemUserAccountBindSaveResult> SystemUserAccountBindSaveCheck(SystemUserAccountBindSaveRow SystemUserAccountBindSave)
        {
            var ListData = DataTrans.ToDataTable(SystemUserAccountBindSave.ListSystemUserAccountBind);

            //主鍵
            var ListAutoKey = SystemUserAccountBindSave.ListSystemUserAccountBind.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserAccountBindSave.ListSystemUserAccountBind.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserAccountBindSave.ListSystemUserAccountBind.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserAccountBind = (from c in dcShare.SystemUserAccountBind
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserAccountBind);

            var ListDataCheck = DataCheck("SystemUserAccountBind", ListData, TableData, false, "04");

            var Vdb = new List<SystemUserAccountBindSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserAccountBindSaveResult();
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
        /// <param name="SystemUserAccountBindSave"></param>
        /// <returns>SystemUserAccountBindSaveResult</returns>
        public List<SystemUserAccountBindSaveResult> SystemUserAccountBindSave(SystemUserAccountBindSaveRow SystemUserAccountBindSave)
        {
            var SubmitChanges = SystemUserAccountBindSave.SubmitChanges;
            var DataCheck = SystemUserAccountBindSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserAccountBindSaveResult>();
            SystemUserAccountBindSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserAccountBindSaveCheck(SystemUserAccountBindSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserAccountBindSave.ListSystemUserAccountBind.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserAccountBindSave.ListSystemUserAccountBind.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserAccountBindSave.ListSystemUserAccountBind.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserAccountBind = (from c in dcShare.SystemUserAccountBind
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUserAccountBind in SystemUserAccountBindSave.ListSystemUserAccountBind)
            {
                var AutoKey = ItemSystemUserAccountBind.AutoKey;
                var Code = ItemSystemUserAccountBind.Code;
                var Key = ItemSystemUserAccountBind.Code;

                var rSystemUserAccountBind = (from c in rsSystemUserAccountBind
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUserAccountBind == null)
                {
                    rSystemUserAccountBind = new SystemUserAccountBind();
                    rSystemUserAccountBind.Code = ItemSystemUserAccountBind.Code;
                    rSystemUserAccountBind.Status = ItemSystemUserAccountBind.Status;
                    rSystemUserAccountBind.InsertMan = SystemUserAccountBindSave.UpdateMan;
                    rSystemUserAccountBind.InsertDate = _NowDate;
                    dcShare.SystemUserAccountBind.InsertOnSubmit(rSystemUserAccountBind);
                }

                rSystemUserAccountBind.UserCode = ItemSystemUserAccountBind.UserCode;
                rSystemUserAccountBind.ThirdPartyAccountId = ItemSystemUserAccountBind.ThirdPartyAccountId;
                rSystemUserAccountBind.ThirdPartyTypeCode = ItemSystemUserAccountBind.ThirdPartyTypeCode;
                rSystemUserAccountBind.DateA = ItemSystemUserAccountBind.DateA;
                rSystemUserAccountBind.DateD = ItemSystemUserAccountBind.DateD;
                rSystemUserAccountBind.Note = ItemSystemUserAccountBind.Note;
                rSystemUserAccountBind.UpdateMan = SystemUserAccountBindSave.UpdateMan;
                rSystemUserAccountBind.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new SystemUserAccountBindSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserAccountBindSave), SystemUserAccountBindSave.AppName, SystemUserAccountBindSave.IpAddress, SystemUserAccountBindSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserAccountBindSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserAccountBindSave.AppName, SystemUserAccountBindSave.IpAddress, SystemUserAccountBindSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增欄位設定檢查
        /// </summary>
        /// <param name="SystemUserAccountBindInsert"></param>
        /// <returns>List SystemUserAccountBindInsertResult</returns>
        public List<SystemUserAccountBindInsertResult> SystemUserAccountBindInsertCheck(SystemUserAccountBindInsertRow SystemUserAccountBindInsert)
        {
            var ListData = DataTrans.ToDataTable(SystemUserAccountBindInsert.ListSystemUserAccountBind);

            //主鍵
            var ListAutoKey = SystemUserAccountBindInsert.ListSystemUserAccountBind.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserAccountBindInsert.ListSystemUserAccountBind.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserAccountBindInsert.ListSystemUserAccountBind.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserAccountBind = (from c in dcShare.SystemUserAccountBind
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserAccountBind);

            var ListDataCheck = DataCheck("SystemUserAccountBind", ListData, TableData, true, "01");

            var Vdb = new List<SystemUserAccountBindInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserAccountBindInsertResult();
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
        /// <param name="SystemUserAccountBindInsert"></param>
        /// <returns>SystemUserAccountBindInsertResult</returns>
        public List<SystemUserAccountBindInsertResult> SystemUserAccountBindInsert(SystemUserAccountBindInsertRow SystemUserAccountBindInsert)
        {
            var SubmitChanges = SystemUserAccountBindInsert.SubmitChanges;
            var DataCheck = SystemUserAccountBindInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserAccountBindInsertResult>();
            SystemUserAccountBindInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserAccountBindInsertCheck(SystemUserAccountBindInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemSystemUserAccountBind in SystemUserAccountBindInsert.ListSystemUserAccountBind)
            {
                var rSystemUserAccountBind = new SystemUserAccountBind();
                rSystemUserAccountBind.Code = ItemSystemUserAccountBind.Code;
                rSystemUserAccountBind.UserCode = ItemSystemUserAccountBind.UserCode;
                rSystemUserAccountBind.ThirdPartyAccountId = ItemSystemUserAccountBind.ThirdPartyAccountId;
                rSystemUserAccountBind.ThirdPartyTypeCode = ItemSystemUserAccountBind.ThirdPartyTypeCode;
                rSystemUserAccountBind.DateA = ItemSystemUserAccountBind.DateA;
                rSystemUserAccountBind.DateD = ItemSystemUserAccountBind.DateD;
                rSystemUserAccountBind.Note = ItemSystemUserAccountBind.Note;
                rSystemUserAccountBind.Status = ItemSystemUserAccountBind.Status;
                rSystemUserAccountBind.InsertMan = SystemUserAccountBindInsert.InsertMan;
                rSystemUserAccountBind.InsertDate = _NowDate;
                rSystemUserAccountBind.UpdateMan = SystemUserAccountBindInsert.InsertMan;
                rSystemUserAccountBind.UpdateDate = _NowDate;
                dcShare.SystemUserAccountBind.InsertOnSubmit(rSystemUserAccountBind);
            }

            try
            {
                rVdb = new SystemUserAccountBindInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserAccountBindInsert), SystemUserAccountBindInsert.AppName, SystemUserAccountBindInsert.IpAddress, SystemUserAccountBindInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserAccountBindInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserAccountBindInsert.AppName, SystemUserAccountBindInsert.IpAddress, SystemUserAccountBindInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改欄位設定檢查
        /// </summary>
        /// <param name="SystemUserAccountBindUpdate"></param>
        /// <returns>List SystemUserAccountBindUpdateResult</returns>
        public List<SystemUserAccountBindUpdateResult> SystemUserAccountBindUpdateCheck(SystemUserAccountBindUpdateRow SystemUserAccountBindUpdate)
        {
            var ListData = DataTrans.ToDataTable(SystemUserAccountBindUpdate.ListSystemUserAccountBind);

            //主鍵
            var ListAutoKey = SystemUserAccountBindUpdate.ListSystemUserAccountBind.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserAccountBindUpdate.ListSystemUserAccountBind.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserAccountBindUpdate.ListSystemUserAccountBind.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserAccountBind = (from c in dcShare.SystemUserAccountBind
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserAccountBind);

            var ListDataCheck = DataCheck("SystemUserAccountBind", ListData, TableData, true, "02");

            var Vdb = new List<SystemUserAccountBindUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserAccountBindUpdateResult();
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
        /// <param name="SystemUserAccountBindUpdate"></param>
        /// <returns>SystemUserAccountBindUpdateResult</returns>
        public List<SystemUserAccountBindUpdateResult> SystemUserAccountBindUpdate(SystemUserAccountBindUpdateRow SystemUserAccountBindUpdate)
        {
            var SubmitChanges = SystemUserAccountBindUpdate.SubmitChanges;
            var DataCheck = SystemUserAccountBindUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserAccountBindUpdateResult>();
            SystemUserAccountBindUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserAccountBindUpdateCheck(SystemUserAccountBindUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserAccountBindUpdate.ListSystemUserAccountBind.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserAccountBindUpdate.ListSystemUserAccountBind.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserAccountBindUpdate.ListSystemUserAccountBind.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserAccountBind = (from c in dcShare.SystemUserAccountBind
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUserAccountBind in SystemUserAccountBindUpdate.ListSystemUserAccountBind)
            {
                var AutoKey = ItemSystemUserAccountBind.AutoKey;
                var Code = ItemSystemUserAccountBind.Code;
                var Key = ItemSystemUserAccountBind.Code;

                var rSystemUserAccountBind = (from c in rsSystemUserAccountBind
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUserAccountBind != null)
                {
                    rSystemUserAccountBind.UserCode = ItemSystemUserAccountBind.UserCode;
                    rSystemUserAccountBind.ThirdPartyAccountId = ItemSystemUserAccountBind.ThirdPartyAccountId;
                    rSystemUserAccountBind.ThirdPartyTypeCode = ItemSystemUserAccountBind.ThirdPartyTypeCode;
                    rSystemUserAccountBind.DateA = ItemSystemUserAccountBind.DateA;
                    rSystemUserAccountBind.DateD = ItemSystemUserAccountBind.DateD;
                    rSystemUserAccountBind.Note = ItemSystemUserAccountBind.Note;
                    rSystemUserAccountBind.UpdateMan = SystemUserAccountBindUpdate.UpdateMan;
                    rSystemUserAccountBind.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new SystemUserAccountBindUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(SystemUserAccountBindUpdate), SystemUserAccountBindUpdate.AppName, SystemUserAccountBindUpdate.IpAddress, SystemUserAccountBindUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new SystemUserAccountBindUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserAccountBindUpdate), SystemUserAccountBindUpdate.AppName, SystemUserAccountBindUpdate.IpAddress, SystemUserAccountBindUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserAccountBindUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserAccountBindUpdate.AppName, SystemUserAccountBindUpdate.IpAddress, SystemUserAccountBindUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除欄位設定檢查
        /// </summary>
        /// <param name="SystemUserAccountBindDelete"></param>
        /// <returns>List SystemUserAccountBindDeleteResult</returns>
        public List<SystemUserAccountBindDeleteResult> SystemUserAccountBindDeleteCheck(SystemUserAccountBindDeleteRow SystemUserAccountBindDelete)
        {
            var ListData = DataTrans.ToDataTable(SystemUserAccountBindDelete.ListSystemUserAccountBind);

            //主鍵
            var ListAutoKey = SystemUserAccountBindDelete.ListSystemUserAccountBind.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserAccountBindDelete.ListSystemUserAccountBind.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserAccountBindDelete.ListSystemUserAccountBind.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserAccountBind = (from c in dcShare.SystemUserAccountBind
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserAccountBind);

            var ListDataCheck = DataCheck("SystemUserAccountBind", ListData, TableData, true, "03");

            var Vdb = new List<SystemUserAccountBindDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserAccountBindDeleteResult();
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
        /// <param name="SystemUserAccountBindDelete"></param>
        /// <returns>SystemUserAccountBindDeleteResult</returns>
        public List<SystemUserAccountBindDeleteResult> SystemUserAccountBindDelete(SystemUserAccountBindDeleteRow SystemUserAccountBindDelete)
        {
            var SubmitChanges = SystemUserAccountBindDelete.SubmitChanges;
            var DataCheck = SystemUserAccountBindDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserAccountBindDeleteResult>();
            SystemUserAccountBindDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserAccountBindDeleteCheck(SystemUserAccountBindDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserAccountBindDelete.ListSystemUserAccountBind.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserAccountBindDelete.ListSystemUserAccountBind.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserAccountBindDelete.ListSystemUserAccountBind.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserAccountBind = (from c in dcShare.SystemUserAccountBind
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUserAccountBind in SystemUserAccountBindDelete.ListSystemUserAccountBind)
            {
                var AutoKey = ItemSystemUserAccountBind.AutoKey;
                var Code = ItemSystemUserAccountBind.Code;
                var Key = ItemSystemUserAccountBind.Code;

                var rSystemUserAccountBind = (from c in rsSystemUserAccountBind
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUserAccountBind != null)
                {
                    rSystemUserAccountBind.Status = "2";
                    rSystemUserAccountBind.UpdateMan = SystemUserAccountBindDelete.UpdateMan;
                    rSystemUserAccountBind.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new SystemUserAccountBindDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(SystemUserAccountBindDelete), SystemUserAccountBindDelete.AppName, SystemUserAccountBindDelete.IpAddress, SystemUserAccountBindDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new SystemUserAccountBindDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserAccountBindDelete), SystemUserAccountBindDelete.AppName, SystemUserAccountBindDelete.IpAddress, SystemUserAccountBindDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserAccountBindDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserAccountBindDelete.AppName, SystemUserAccountBindDelete.IpAddress, SystemUserAccountBindDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}