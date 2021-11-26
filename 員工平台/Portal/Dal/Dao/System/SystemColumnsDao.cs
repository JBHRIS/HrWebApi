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
    public class SystemColumnsDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public SystemColumnsDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public SystemColumnsDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public SystemColumnsDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public SystemColumnsDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得顯示欄位設定
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List SystemColumnsRow</returns>
        public List<SystemColumnsRow> GetSystemColumns(SystemColumnsConditions Cond)
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
            //主鍵
            var Key = Cond.Key;
            //資料表代碼
            var ListTablesCode = Cond.ListTablesCode;
            //資料表代碼
            var TablesCode = Cond.TablesCode;

            var VdbSql = (from c in dcShare.SystemColumns
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          && ((ListTablesCode.Count == 0) || (ListTablesCode.Contains(c.TablesCode)))
                          && ((TablesCode.Length == 0) || (c.TablesCode == TablesCode))
                          orderby c.Sort
                          select new SystemColumnsRow
                          {
                              AutoNumber = 0,
                              Key = c.Code,
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              Name = c.Name,
                              TablesCode = c.TablesCode,
                              TablesName = "",
                              IsKey = c.IsKey,
                              IsSensitive = c.IsSensitive,
                              NeedMask = c.NeedMask,
                              DefaultValue = c.DefaultValue,
                              CheckCode = c.CheckCode,
                              Related = c.Related,
                              AllowUpdate = c.AllowUpdate,
                              AllowNull = c.AllowNull,
                              AllowEmpty = c.AllowEmpty,
                              AllowExport = c.AllowExport,
                              AllowSort = c.AllowSort,
                              ColumnTypeCode = c.ColumnTypeCode,
                              ColumnTypeName = "",
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
            var rsColumnType = ShareCodeNameCode("ColumnType");
            foreach (var rVdb in Vdb)
            {
                rVdb.AutoNumber = i;
                i++;

                rVdb.ColumnTypeName = rsColumnType.FirstOrDefault(p => p.Code == rVdb.ColumnTypeCode)?.Name ?? rVdb.ColumnTypeName;
            }

            //處理關聯資料

            return Vdb;
        }

        /// <summary>
        /// 儲存欄位設定檢查
        /// </summary>
        /// <param name="SystemColumnsSave"></param>
        /// <returns>List SystemColumnsSaveResult</returns>
        public List<SystemColumnsSaveResult> SystemColumnsSaveCheck(SystemColumnsSaveRow SystemColumnsSave)
        {
            var ListData = DataTrans.ToDataTable(SystemColumnsSave.ListSystemColumns);

            //主鍵
            var ListAutoKey = SystemColumnsSave.ListSystemColumns.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemColumnsSave.ListSystemColumns.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemColumnsSave.ListSystemColumns.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemColumns = (from c in dcShare.SystemColumns
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemColumns);

            var ListDataCheck = DataCheck("SystemColumns", ListData, TableData, false, "04");

            var Vdb = new List<SystemColumnsSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemColumnsSaveResult();
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
        /// <param name="SystemColumnsSave"></param>
        /// <returns>SystemColumnsSaveResult</returns>
        public List<SystemColumnsSaveResult> SystemColumnsSave(SystemColumnsSaveRow SystemColumnsSave)
        {
            var SubmitChanges = SystemColumnsSave.SubmitChanges;
            var DataCheck = SystemColumnsSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemColumnsSaveResult>();
            SystemColumnsSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemColumnsSaveCheck(SystemColumnsSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemColumnsSave.ListSystemColumns.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemColumnsSave.ListSystemColumns.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemColumnsSave.ListSystemColumns.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemColumns = (from c in dcShare.SystemColumns
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemColumns in SystemColumnsSave.ListSystemColumns)
            {
                var AutoKey = ItemSystemColumns.AutoKey;
                var Code = ItemSystemColumns.Code;
                var Key = ItemSystemColumns.Code;

                var rSystemColumns = (from c in rsSystemColumns
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemColumns == null)
                {
                    rSystemColumns = new SystemColumns();
                    rSystemColumns.Code = ItemSystemColumns.Code;
                    rSystemColumns.Status = ItemSystemColumns.Status;
                    rSystemColumns.InsertMan = SystemColumnsSave.UpdateMan;
                    rSystemColumns.InsertDate = _NowDate;
                    dcShare.SystemColumns.InsertOnSubmit(rSystemColumns);
                }

                rSystemColumns.Name = ItemSystemColumns.Name;
                rSystemColumns.IsKey = ItemSystemColumns.IsKey;
                rSystemColumns.IsSensitive = ItemSystemColumns.IsSensitive;
                rSystemColumns.NeedMask = ItemSystemColumns.NeedMask;
                rSystemColumns.DefaultValue = ItemSystemColumns.DefaultValue;
                rSystemColumns.CheckCode = ItemSystemColumns.CheckCode;
                rSystemColumns.Related = ItemSystemColumns.Related;
                rSystemColumns.AllowUpdate = ItemSystemColumns.AllowUpdate;
                rSystemColumns.AllowNull = ItemSystemColumns.AllowNull;
                rSystemColumns.AllowEmpty = ItemSystemColumns.AllowEmpty;
                rSystemColumns.AllowExport = ItemSystemColumns.AllowExport;
                rSystemColumns.AllowSort = ItemSystemColumns.AllowSort;
                rSystemColumns.ColumnTypeCode = ItemSystemColumns.ColumnTypeCode;
                rSystemColumns.Note = ItemSystemColumns.Note;
                rSystemColumns.Sort = ItemSystemColumns.Sort;
                rSystemColumns.UpdateMan = SystemColumnsSave.UpdateMan;
                rSystemColumns.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new SystemColumnsSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemColumnsSave), SystemColumnsSave.AppName, SystemColumnsSave.IpAddress, SystemColumnsSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemColumnsSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemColumnsSave.AppName, SystemColumnsSave.IpAddress, SystemColumnsSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增欄位設定檢查
        /// </summary>
        /// <param name="SystemColumnsInsert"></param>
        /// <returns>List SystemColumnsInsertResult</returns>
        public List<SystemColumnsInsertResult> SystemColumnsInsertCheck(SystemColumnsInsertRow SystemColumnsInsert)
        {
            var ListData = DataTrans.ToDataTable(SystemColumnsInsert.ListSystemColumns);

            //主鍵
            var ListAutoKey = SystemColumnsInsert.ListSystemColumns.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemColumnsInsert.ListSystemColumns.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemColumnsInsert.ListSystemColumns.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemColumns = (from c in dcShare.SystemColumns
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemColumns);

            var ListDataCheck = DataCheck("SystemColumns", ListData, TableData, true, "01");

            var Vdb = new List<SystemColumnsInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemColumnsInsertResult();
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
        /// <param name="SystemColumnsInsert"></param>
        /// <returns>SystemColumnsInsertResult</returns>
        public List<SystemColumnsInsertResult> SystemColumnsInsert(SystemColumnsInsertRow SystemColumnsInsert)
        {
            var SubmitChanges = SystemColumnsInsert.SubmitChanges;
            var DataCheck = SystemColumnsInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemColumnsInsertResult>();
            SystemColumnsInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemColumnsInsertCheck(SystemColumnsInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemSystemColumns in SystemColumnsInsert.ListSystemColumns)
            {
                var rSystemColumns = new SystemColumns();
                rSystemColumns.Code = ItemSystemColumns.Code;
                rSystemColumns.Name = ItemSystemColumns.Name;
                rSystemColumns.TablesCode = ItemSystemColumns.TablesCode;
                rSystemColumns.IsKey = ItemSystemColumns.IsKey;
                rSystemColumns.IsSensitive = ItemSystemColumns.IsSensitive;
                rSystemColumns.NeedMask = ItemSystemColumns.NeedMask;
                rSystemColumns.DefaultValue = ItemSystemColumns.DefaultValue;
                rSystemColumns.CheckCode = ItemSystemColumns.CheckCode;
                rSystemColumns.Related = ItemSystemColumns.Related;
                rSystemColumns.AllowUpdate = ItemSystemColumns.AllowUpdate;
                rSystemColumns.AllowNull = ItemSystemColumns.AllowNull;
                rSystemColumns.AllowEmpty = ItemSystemColumns.AllowEmpty;
                rSystemColumns.AllowExport = ItemSystemColumns.AllowExport;
                rSystemColumns.AllowSort = ItemSystemColumns.AllowSort;
                rSystemColumns.ColumnTypeCode = ItemSystemColumns.ColumnTypeCode;
                rSystemColumns.Note = ItemSystemColumns.Note;
                rSystemColumns.Sort = ItemSystemColumns.Sort;
                rSystemColumns.Status = ItemSystemColumns.Status;
                rSystemColumns.InsertMan = SystemColumnsInsert.InsertMan;
                rSystemColumns.InsertDate = _NowDate;
                rSystemColumns.UpdateMan = SystemColumnsInsert.InsertMan;
                rSystemColumns.UpdateDate = _NowDate;
                dcShare.SystemColumns.InsertOnSubmit(rSystemColumns);
            }

            try
            {
                rVdb = new SystemColumnsInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemColumnsInsert), SystemColumnsInsert.AppName, SystemColumnsInsert.IpAddress, SystemColumnsInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemColumnsInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemColumnsInsert.AppName, SystemColumnsInsert.IpAddress, SystemColumnsInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改欄位設定檢查
        /// </summary>
        /// <param name="SystemColumnsUpdate"></param>
        /// <returns>List SystemColumnsUpdateResult</returns>
        public List<SystemColumnsUpdateResult> SystemColumnsUpdateCheck(SystemColumnsUpdateRow SystemColumnsUpdate)
        {
            var ListData = DataTrans.ToDataTable(SystemColumnsUpdate.ListSystemColumns);

            //主鍵
            var ListAutoKey = SystemColumnsUpdate.ListSystemColumns.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemColumnsUpdate.ListSystemColumns.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemColumnsUpdate.ListSystemColumns.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemColumns = (from c in dcShare.SystemColumns
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemColumns);

            var ListDataCheck = DataCheck("SystemColumns", ListData, TableData, true, "02");

            var Vdb = new List<SystemColumnsUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemColumnsUpdateResult();
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
        /// <param name="SystemColumnsUpdate"></param>
        /// <returns>SystemColumnsUpdateResult</returns>
        public List<SystemColumnsUpdateResult> SystemColumnsUpdate(SystemColumnsUpdateRow SystemColumnsUpdate)
        {
            var SubmitChanges = SystemColumnsUpdate.SubmitChanges;
            var DataCheck = SystemColumnsUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemColumnsUpdateResult>();
            SystemColumnsUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemColumnsUpdateCheck(SystemColumnsUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemColumnsUpdate.ListSystemColumns.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemColumnsUpdate.ListSystemColumns.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemColumnsUpdate.ListSystemColumns.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemColumns = (from c in dcShare.SystemColumns
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemColumns in SystemColumnsUpdate.ListSystemColumns)
            {
                var AutoKey = ItemSystemColumns.AutoKey;
                var Code = ItemSystemColumns.Code;
                var Key = ItemSystemColumns.Code;

                var rSystemColumns = (from c in rsSystemColumns
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemColumns != null)
                {
                    rSystemColumns.IsKey = ItemSystemColumns.IsKey;
                    rSystemColumns.Name = ItemSystemColumns.Name;
                    rSystemColumns.IsSensitive = ItemSystemColumns.IsSensitive;
                    rSystemColumns.NeedMask = ItemSystemColumns.NeedMask;
                    rSystemColumns.DefaultValue = ItemSystemColumns.DefaultValue;
                    rSystemColumns.CheckCode = ItemSystemColumns.CheckCode;
                    rSystemColumns.Related = ItemSystemColumns.Related;
                    rSystemColumns.AllowUpdate = ItemSystemColumns.AllowUpdate;
                    rSystemColumns.AllowNull = ItemSystemColumns.AllowNull;
                    rSystemColumns.AllowEmpty = ItemSystemColumns.AllowEmpty;
                    rSystemColumns.AllowExport = ItemSystemColumns.AllowExport;
                    rSystemColumns.AllowSort = ItemSystemColumns.AllowSort;
                    rSystemColumns.ColumnTypeCode = ItemSystemColumns.ColumnTypeCode;
                    rSystemColumns.Note = ItemSystemColumns.Note;
                    rSystemColumns.Sort = ItemSystemColumns.Sort;
                    rSystemColumns.UpdateMan = SystemColumnsUpdate.UpdateMan;
                    rSystemColumns.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new SystemColumnsUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(SystemColumnsUpdate), SystemColumnsUpdate.AppName, SystemColumnsUpdate.IpAddress, SystemColumnsUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new SystemColumnsUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemColumnsUpdate), SystemColumnsUpdate.AppName, SystemColumnsUpdate.IpAddress, SystemColumnsUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemColumnsUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemColumnsUpdate.AppName, SystemColumnsUpdate.IpAddress, SystemColumnsUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除欄位設定檢查
        /// </summary>
        /// <param name="SystemColumnsDelete"></param>
        /// <returns>List SystemColumnsDeleteResult</returns>
        public List<SystemColumnsDeleteResult> SystemColumnsDeleteCheck(SystemColumnsDeleteRow SystemColumnsDelete)
        {
            var ListData = DataTrans.ToDataTable(SystemColumnsDelete.ListSystemColumns);

            //主鍵
            var ListAutoKey = SystemColumnsDelete.ListSystemColumns.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemColumnsDelete.ListSystemColumns.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemColumnsDelete.ListSystemColumns.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemColumns = (from c in dcShare.SystemColumns
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemColumns);

            var ListDataCheck = DataCheck("SystemColumns", ListData, TableData, true, "03");

            var Vdb = new List<SystemColumnsDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemColumnsDeleteResult();
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
        /// <param name="SystemColumnsDelete"></param>
        /// <returns>SystemColumnsDeleteResult</returns>
        public List<SystemColumnsDeleteResult> SystemColumnsDelete(SystemColumnsDeleteRow SystemColumnsDelete)
        {
            var SubmitChanges = SystemColumnsDelete.SubmitChanges;
            var DataCheck = SystemColumnsDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemColumnsDeleteResult>();
            SystemColumnsDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemColumnsDeleteCheck(SystemColumnsDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemColumnsDelete.ListSystemColumns.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemColumnsDelete.ListSystemColumns.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemColumnsDelete.ListSystemColumns.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemColumns = (from c in dcShare.SystemColumns
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemColumns in SystemColumnsDelete.ListSystemColumns)
            {
                var AutoKey = ItemSystemColumns.AutoKey;
                var Code = ItemSystemColumns.Code;
                var Key = ItemSystemColumns.Code;

                var rSystemColumns = (from c in rsSystemColumns
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemColumns != null)
                {
                    rSystemColumns.Status = "2";
                    rSystemColumns.UpdateMan = SystemColumnsDelete.UpdateMan;
                    rSystemColumns.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new SystemColumnsDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(SystemColumnsDelete), SystemColumnsDelete.AppName, SystemColumnsDelete.IpAddress, SystemColumnsDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new SystemColumnsDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemColumnsDelete), SystemColumnsDelete.AppName, SystemColumnsDelete.IpAddress, SystemColumnsDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemColumnsDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemColumnsDelete.AppName, SystemColumnsDelete.IpAddress, SystemColumnsDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}