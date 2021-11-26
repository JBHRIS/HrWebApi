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
    public class SystemUserGroupDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public SystemUserGroupDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public SystemUserGroupDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public SystemUserGroupDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public SystemUserGroupDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得顯示欄位設定
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List SystemUserGroupRow</returns>
        public List<SystemUserGroupRow> GetSystemUserGroup(SystemUserGroupConditions Cond)
        {
            //資料狀態
            var ListStatus = Cond.ListStatus;
            //搜尋條件
            //自動編號
            var AutoKey = Cond.AutoKey;
            //代碼
            var Code = Cond.Code;
            //主鍵
            var Key = Cond.Key;
            //資料表代碼
            var ListRoleKey = Cond.ListRoleKey;

            var VdbSql = (from c in dcShare.SystemUserGroup
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          && ((ListRoleKey.Count == 0) || (ListRoleKey.Contains(c.RoleKey)))
                          orderby c.Sort
                          select new SystemUserGroupRow
                          {
                              AutoNumber = 0,
                              Key = c.Code,
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              Name = c.Name,
                              RoleKey = c.RoleKey,
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
        /// 儲存欄位設定檢查
        /// </summary>
        /// <param name="SystemUserGroupSave"></param>
        /// <returns>List SystemUserGroupSaveResult</returns>
        public List<SystemUserGroupSaveResult> SystemUserGroupSaveCheck(SystemUserGroupSaveRow SystemUserGroupSave)
        {
            var ListData = DataTrans.ToDataTable(SystemUserGroupSave.ListSystemUserGroup);

            //主鍵
            var ListAutoKey = SystemUserGroupSave.ListSystemUserGroup.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserGroupSave.ListSystemUserGroup.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserGroupSave.ListSystemUserGroup.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserGroup = (from c in dcShare.SystemUserGroup
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserGroup);

            var ListDataCheck = DataCheck("SystemUserGroup", ListData, TableData, false, "04");

            var Vdb = new List<SystemUserGroupSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserGroupSaveResult();
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
        /// <param name="SystemUserGroupSave"></param>
        /// <returns>SystemUserGroupSaveResult</returns>
        public List<SystemUserGroupSaveResult> SystemUserGroupSave(SystemUserGroupSaveRow SystemUserGroupSave)
        {
            var SubmitChanges = SystemUserGroupSave.SubmitChanges;
            var DataCheck = SystemUserGroupSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserGroupSaveResult>();
            SystemUserGroupSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserGroupSaveCheck(SystemUserGroupSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserGroupSave.ListSystemUserGroup.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserGroupSave.ListSystemUserGroup.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserGroupSave.ListSystemUserGroup.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserGroup = (from c in dcShare.SystemUserGroup
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUserGroup in SystemUserGroupSave.ListSystemUserGroup)
            {
                var AutoKey = ItemSystemUserGroup.AutoKey;
                var Code = ItemSystemUserGroup.Code;
                var Key = ItemSystemUserGroup.Code;

                var rSystemUserGroup = (from c in rsSystemUserGroup
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUserGroup == null)
                {
                    rSystemUserGroup = new SystemUserGroup();
                    rSystemUserGroup.Code = ItemSystemUserGroup.Code;
                    rSystemUserGroup.Status = ItemSystemUserGroup.Status;
                    rSystemUserGroup.InsertMan = SystemUserGroupSave.UpdateMan;
                    rSystemUserGroup.InsertDate = _NowDate;
                    dcShare.SystemUserGroup.InsertOnSubmit(rSystemUserGroup);
                }

                rSystemUserGroup.Name = ItemSystemUserGroup.Name;
                rSystemUserGroup.RoleKey = ItemSystemUserGroup.RoleKey;
                rSystemUserGroup.DateA = ItemSystemUserGroup.DateA;
                rSystemUserGroup.DateD = ItemSystemUserGroup.DateD;
                rSystemUserGroup.Note = ItemSystemUserGroup.Note;
                rSystemUserGroup.Sort = ItemSystemUserGroup.Sort;
                rSystemUserGroup.UpdateMan = SystemUserGroupSave.UpdateMan;
                rSystemUserGroup.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new SystemUserGroupSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserGroupSave), SystemUserGroupSave.AppName, SystemUserGroupSave.IpAddress, SystemUserGroupSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserGroupSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserGroupSave.AppName, SystemUserGroupSave.IpAddress, SystemUserGroupSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增欄位設定檢查
        /// </summary>
        /// <param name="SystemUserGroupInsert"></param>
        /// <returns>List SystemUserGroupInsertResult</returns>
        public List<SystemUserGroupInsertResult> SystemUserGroupInsertCheck(SystemUserGroupInsertRow SystemUserGroupInsert)
        {
            var ListData = DataTrans.ToDataTable(SystemUserGroupInsert.ListSystemUserGroup);

            //主鍵
            var ListAutoKey = SystemUserGroupInsert.ListSystemUserGroup.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserGroupInsert.ListSystemUserGroup.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserGroupInsert.ListSystemUserGroup.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserGroup = (from c in dcShare.SystemUserGroup
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserGroup);

            var ListDataCheck = DataCheck("SystemUserGroup", ListData, TableData, true, "01");

            var Vdb = new List<SystemUserGroupInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserGroupInsertResult();
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
        /// <param name="SystemUserGroupInsert"></param>
        /// <returns>SystemUserGroupInsertResult</returns>
        public List<SystemUserGroupInsertResult> SystemUserGroupInsert(SystemUserGroupInsertRow SystemUserGroupInsert)
        {
            var SubmitChanges = SystemUserGroupInsert.SubmitChanges;
            var DataCheck = SystemUserGroupInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserGroupInsertResult>();
            SystemUserGroupInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserGroupInsertCheck(SystemUserGroupInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemSystemUserGroup in SystemUserGroupInsert.ListSystemUserGroup)
            {
                var rSystemUserGroup = new SystemUserGroup();
                rSystemUserGroup.Code = ItemSystemUserGroup.Code;
                rSystemUserGroup.Name = ItemSystemUserGroup.Name;
                rSystemUserGroup.RoleKey = ItemSystemUserGroup.RoleKey;
                rSystemUserGroup.DateA = ItemSystemUserGroup.DateA;
                rSystemUserGroup.DateD = ItemSystemUserGroup.DateD;
                rSystemUserGroup.Note = ItemSystemUserGroup.Note;
                rSystemUserGroup.Sort = ItemSystemUserGroup.Sort;
                rSystemUserGroup.Status = ItemSystemUserGroup.Status;
                rSystemUserGroup.InsertMan = SystemUserGroupInsert.InsertMan;
                rSystemUserGroup.InsertDate = _NowDate;
                rSystemUserGroup.UpdateMan = SystemUserGroupInsert.InsertMan;
                rSystemUserGroup.UpdateDate = _NowDate;
                dcShare.SystemUserGroup.InsertOnSubmit(rSystemUserGroup);
            }

            try
            {
                rVdb = new SystemUserGroupInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserGroupInsert), SystemUserGroupInsert.AppName, SystemUserGroupInsert.IpAddress, SystemUserGroupInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserGroupInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserGroupInsert.AppName, SystemUserGroupInsert.IpAddress, SystemUserGroupInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改欄位設定檢查
        /// </summary>
        /// <param name="SystemUserGroupUpdate"></param>
        /// <returns>List SystemUserGroupUpdateResult</returns>
        public List<SystemUserGroupUpdateResult> SystemUserGroupUpdateCheck(SystemUserGroupUpdateRow SystemUserGroupUpdate)
        {
            var ListData = DataTrans.ToDataTable(SystemUserGroupUpdate.ListSystemUserGroup);

            //主鍵
            var ListAutoKey = SystemUserGroupUpdate.ListSystemUserGroup.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserGroupUpdate.ListSystemUserGroup.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserGroupUpdate.ListSystemUserGroup.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserGroup = (from c in dcShare.SystemUserGroup
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserGroup);

            var ListDataCheck = DataCheck("SystemUserGroup", ListData, TableData, true, "02");

            var Vdb = new List<SystemUserGroupUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserGroupUpdateResult();
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
        /// <param name="SystemUserGroupUpdate"></param>
        /// <returns>SystemUserGroupUpdateResult</returns>
        public List<SystemUserGroupUpdateResult> SystemUserGroupUpdate(SystemUserGroupUpdateRow SystemUserGroupUpdate)
        {
            var SubmitChanges = SystemUserGroupUpdate.SubmitChanges;
            var DataCheck = SystemUserGroupUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserGroupUpdateResult>();
            SystemUserGroupUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserGroupUpdateCheck(SystemUserGroupUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserGroupUpdate.ListSystemUserGroup.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserGroupUpdate.ListSystemUserGroup.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserGroupUpdate.ListSystemUserGroup.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserGroup = (from c in dcShare.SystemUserGroup
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUserGroup in SystemUserGroupUpdate.ListSystemUserGroup)
            {
                var AutoKey = ItemSystemUserGroup.AutoKey;
                var Code = ItemSystemUserGroup.Code;
                var Key = ItemSystemUserGroup.Code;

                var rSystemUserGroup = (from c in rsSystemUserGroup
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUserGroup != null)
                {
                    rSystemUserGroup.Name = ItemSystemUserGroup.Name;
                    rSystemUserGroup.RoleKey = ItemSystemUserGroup.RoleKey;
                    rSystemUserGroup.DateA = ItemSystemUserGroup.DateA;
                    rSystemUserGroup.DateD = ItemSystemUserGroup.DateD;
                    rSystemUserGroup.Note = ItemSystemUserGroup.Note;
                    rSystemUserGroup.Sort = ItemSystemUserGroup.Sort;
                    rSystemUserGroup.UpdateMan = SystemUserGroupUpdate.UpdateMan;
                    rSystemUserGroup.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new SystemUserGroupUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(SystemUserGroupUpdate), SystemUserGroupUpdate.AppName, SystemUserGroupUpdate.IpAddress, SystemUserGroupUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new SystemUserGroupUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserGroupUpdate), SystemUserGroupUpdate.AppName, SystemUserGroupUpdate.IpAddress, SystemUserGroupUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserGroupUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserGroupUpdate.AppName, SystemUserGroupUpdate.IpAddress, SystemUserGroupUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除欄位設定檢查
        /// </summary>
        /// <param name="SystemUserGroupDelete"></param>
        /// <returns>List SystemUserGroupDeleteResult</returns>
        public List<SystemUserGroupDeleteResult> SystemUserGroupDeleteCheck(SystemUserGroupDeleteRow SystemUserGroupDelete)
        {
            var ListData = DataTrans.ToDataTable(SystemUserGroupDelete.ListSystemUserGroup);

            //主鍵
            var ListAutoKey = SystemUserGroupDelete.ListSystemUserGroup.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserGroupDelete.ListSystemUserGroup.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserGroupDelete.ListSystemUserGroup.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserGroup = (from c in dcShare.SystemUserGroup
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserGroup);

            var ListDataCheck = DataCheck("SystemUserGroup", ListData, TableData, true, "03");

            var Vdb = new List<SystemUserGroupDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserGroupDeleteResult();
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
        /// <param name="SystemUserGroupDelete"></param>
        /// <returns>SystemUserGroupDeleteResult</returns>
        public List<SystemUserGroupDeleteResult> SystemUserGroupDelete(SystemUserGroupDeleteRow SystemUserGroupDelete)
        {
            var SubmitChanges = SystemUserGroupDelete.SubmitChanges;
            var DataCheck = SystemUserGroupDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserGroupDeleteResult>();
            SystemUserGroupDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserGroupDeleteCheck(SystemUserGroupDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserGroupDelete.ListSystemUserGroup.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserGroupDelete.ListSystemUserGroup.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserGroupDelete.ListSystemUserGroup.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserGroup = (from c in dcShare.SystemUserGroup
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUserGroup in SystemUserGroupDelete.ListSystemUserGroup)
            {
                var AutoKey = ItemSystemUserGroup.AutoKey;
                var Code = ItemSystemUserGroup.Code;
                var Key = ItemSystemUserGroup.Code;

                var rSystemUserGroup = (from c in rsSystemUserGroup
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUserGroup != null)
                {
                    rSystemUserGroup.Status = "2";
                    rSystemUserGroup.UpdateMan = SystemUserGroupDelete.UpdateMan;
                    rSystemUserGroup.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new SystemUserGroupDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(SystemUserGroupDelete), SystemUserGroupDelete.AppName, SystemUserGroupDelete.IpAddress, SystemUserGroupDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new SystemUserGroupDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserGroupDelete), SystemUserGroupDelete.AppName, SystemUserGroupDelete.IpAddress, SystemUserGroupDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserGroupDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserGroupDelete.AppName, SystemUserGroupDelete.IpAddress, SystemUserGroupDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}