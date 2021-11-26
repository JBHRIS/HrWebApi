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
    public class SystemUserNotifyDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public SystemUserNotifyDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public SystemUserNotifyDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public SystemUserNotifyDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public SystemUserNotifyDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得顯示帳號通知
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List SystemUserNotifyRow</returns>
        public List<SystemUserNotifyRow> GetSystemUserNotify(SystemUserNotifyConditions Cond)
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
            //被通知者
            var UserCode = Cond.UserCode;
            //通知者
            var UserCodeSend = Cond.UserCodeSend;
            //通知類別
            var ListNotifyTypeCode = Cond.ListNotifyTypeCode;
            //日期判斷
            var UseDate = Cond.UseDate;
            //日期
            var DateA = _NowDate.Date;
            //物件網址
            var PageName = "FrontMainUserNotify.aspx";

            var VdbSql = (from c in dcShare.SystemUserNotify
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          && ((UserCode.Length == 0) || (c.UserCode == UserCode))
                          && ((UserCodeSend.Length == 0) || (c.UserCodeSend == UserCodeSend))
                          && ((ListNotifyTypeCode.Count == 0) || (ListNotifyTypeCode.Contains(c.NotifyTypeCode)))
                          && (!UseDate || (c.DateA <= DateA && DateA <= c.DateD))
                          orderby c.Sort, c.InsertDate descending
                          select new SystemUserNotifyRow
                          {
                              Key = c.Code,
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              UserCode = c.UserCode,
                              UserCodeSend = c.UserCodeSend,
                              UserName = c.UserName,
                              NotifyTypeCode = c.NotifyTypeCode,
                              NotifyTypeName = "",
                              AppName = c.AppName,
                              AppCode = c.AppCode,
                              TitleContents = c.TitleContents,
                              Contents = c.Contents,
                              IsRead = c.IsRead,
                              IsReadHtmlTag = !c.IsRead ? "style=\"color: red;\"" : "",
                              DateA = c.DateA.Date,
                              DateD = c.DateD.Date,
                              Url = PageName + "?Code=" + c.Code,
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
            var rsColumnType = ShareCodeNameCode("NotifyTypeCode");
            foreach (var rVdb in Vdb)
            {
                rVdb.NotifyTypeName = rsColumnType.FirstOrDefault(p => p.Code == rVdb.NotifyTypeCode)?.Name ?? rVdb.NotifyTypeName;
            }

            //處理關聯資料

            return Vdb;
        }

        /// <summary>
        /// 儲存帳號通知檢查
        /// </summary>
        /// <param name="SystemUserNotifySave"></param>
        /// <returns>List SystemUserNotifySaveResult</returns>
        public List<SystemUserNotifySaveResult> SystemUserNotifySaveCheck(SystemUserNotifySaveRow SystemUserNotifySave)
        {
            var ListData = DataTrans.ToDataTable(SystemUserNotifySave.ListSystemUserNotify);

            //主鍵
            var ListAutoKey = SystemUserNotifySave.ListSystemUserNotify.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserNotifySave.ListSystemUserNotify.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserNotifySave.ListSystemUserNotify.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserNotify = (from c in dcShare.SystemUserNotify
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserNotify);

            var ListDataCheck = DataCheck("SystemUserNotify", ListData, TableData, false, "04");

            var Vdb = new List<SystemUserNotifySaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserNotifySaveResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存帳號通知
        /// </summary>
        /// <param name="SystemUserNotifySave"></param>
        /// <returns>SystemUserNotifySaveResult</returns>
        public List<SystemUserNotifySaveResult> SystemUserNotifySave(SystemUserNotifySaveRow SystemUserNotifySave)
        {
            var SubmitChanges = SystemUserNotifySave.SubmitChanges;
            var DataCheck = SystemUserNotifySave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserNotifySaveResult>();
            SystemUserNotifySaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserNotifySaveCheck(SystemUserNotifySave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserNotifySave.ListSystemUserNotify.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserNotifySave.ListSystemUserNotify.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserNotifySave.ListSystemUserNotify.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserNotify = (from c in dcShare.SystemUserNotify
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUserNotify in SystemUserNotifySave.ListSystemUserNotify)
            {
                var AutoKey = ItemSystemUserNotify.AutoKey;
                var Code = ItemSystemUserNotify.Code;
                var Key = ItemSystemUserNotify.Code;

                var rSystemUserNotify = (from c in rsSystemUserNotify
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUserNotify == null)
                {
                    rSystemUserNotify = new SystemUserNotify();
                    rSystemUserNotify.Code = ItemSystemUserNotify.Code;
                    rSystemUserNotify.Status = ItemSystemUserNotify.Status;
                    rSystemUserNotify.InsertMan = SystemUserNotifySave.UpdateMan;
                    rSystemUserNotify.InsertDate = _NowDate;
                    dcShare.SystemUserNotify.InsertOnSubmit(rSystemUserNotify);
                }

                rSystemUserNotify.UserCode = ItemSystemUserNotify.UserCode;
                rSystemUserNotify.UserCodeSend = ItemSystemUserNotify.UserCodeSend;
                rSystemUserNotify.UserName = ItemSystemUserNotify.UserName;
                rSystemUserNotify.NotifyTypeCode = ItemSystemUserNotify.NotifyTypeCode;
                rSystemUserNotify.AppName = ItemSystemUserNotify.AppName;
                rSystemUserNotify.AppCode = ItemSystemUserNotify.AppCode;
                rSystemUserNotify.TitleContents = ItemSystemUserNotify.TitleContents;
                rSystemUserNotify.Contents = ItemSystemUserNotify.Contents;
                rSystemUserNotify.IsRead = ItemSystemUserNotify.IsRead;
                rSystemUserNotify.DateA = ItemSystemUserNotify.DateA;
                rSystemUserNotify.DateD = ItemSystemUserNotify.DateD;
                rSystemUserNotify.Note = ItemSystemUserNotify.Note;
                rSystemUserNotify.Sort = ItemSystemUserNotify.Sort;
                rSystemUserNotify.UpdateMan = SystemUserNotifySave.UpdateMan;
                rSystemUserNotify.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new SystemUserNotifySaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserNotifySave), SystemUserNotifySave.AppName, SystemUserNotifySave.IpAddress, SystemUserNotifySave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserNotifySaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserNotifySave.AppName, SystemUserNotifySave.IpAddress, SystemUserNotifySave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增帳號通知檢查
        /// </summary>
        /// <param name="SystemUserNotifyInsert"></param>
        /// <returns>List SystemUserNotifyInsertResult</returns>
        public List<SystemUserNotifyInsertResult> SystemUserNotifyInsertCheck(SystemUserNotifyInsertRow SystemUserNotifyInsert)
        {
            var ListData = DataTrans.ToDataTable(SystemUserNotifyInsert.ListSystemUserNotify);

            //主鍵
            var ListAutoKey = SystemUserNotifyInsert.ListSystemUserNotify.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserNotifyInsert.ListSystemUserNotify.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserNotifyInsert.ListSystemUserNotify.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserNotify = (from c in dcShare.SystemUserNotify
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserNotify);

            var ListDataCheck = DataCheck("SystemUserNotify", ListData, TableData, true, "01");

            var Vdb = new List<SystemUserNotifyInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserNotifyInsertResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增帳號通知
        /// </summary>
        /// <param name="SystemUserNotifyInsert"></param>
        /// <returns>SystemUserNotifyInsertResult</returns>
        public List<SystemUserNotifyInsertResult> SystemUserNotifyInsert(SystemUserNotifyInsertRow SystemUserNotifyInsert)
        {
            var SubmitChanges = SystemUserNotifyInsert.SubmitChanges;
            var DataCheck = SystemUserNotifyInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserNotifyInsertResult>();
            SystemUserNotifyInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserNotifyInsertCheck(SystemUserNotifyInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemSystemUserNotify in SystemUserNotifyInsert.ListSystemUserNotify)
            {
                var rSystemUserNotify = new SystemUserNotify();
                rSystemUserNotify.Code = ItemSystemUserNotify.Code;
                rSystemUserNotify.UserCode = ItemSystemUserNotify.UserCode;
                rSystemUserNotify.UserCodeSend = ItemSystemUserNotify.UserCodeSend;
                rSystemUserNotify.UserName = ItemSystemUserNotify.UserName;
                rSystemUserNotify.NotifyTypeCode = ItemSystemUserNotify.NotifyTypeCode;
                rSystemUserNotify.AppName = ItemSystemUserNotify.AppName;
                rSystemUserNotify.AppCode = ItemSystemUserNotify.AppCode;
                rSystemUserNotify.TitleContents = ItemSystemUserNotify.TitleContents;
                rSystemUserNotify.Contents = ItemSystemUserNotify.Contents;
                rSystemUserNotify.IsRead = ItemSystemUserNotify.IsRead;
                rSystemUserNotify.DateA = ItemSystemUserNotify.DateA;
                rSystemUserNotify.DateD = ItemSystemUserNotify.DateD;
                rSystemUserNotify.Note = ItemSystemUserNotify.Note;
                rSystemUserNotify.Sort = ItemSystemUserNotify.Sort;
                rSystemUserNotify.Status = ItemSystemUserNotify.Status;
                rSystemUserNotify.InsertMan = SystemUserNotifyInsert.InsertMan;
                rSystemUserNotify.InsertDate = _NowDate;
                rSystemUserNotify.UpdateMan = SystemUserNotifyInsert.InsertMan;
                rSystemUserNotify.UpdateDate = _NowDate;
                dcShare.SystemUserNotify.InsertOnSubmit(rSystemUserNotify);
            }

            try
            {
                rVdb = new SystemUserNotifyInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserNotifyInsert), SystemUserNotifyInsert.AppName, SystemUserNotifyInsert.IpAddress, SystemUserNotifyInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserNotifyInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserNotifyInsert.AppName, SystemUserNotifyInsert.IpAddress, SystemUserNotifyInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改帳號通知檢查
        /// </summary>
        /// <param name="SystemUserNotifyUpdate"></param>
        /// <returns>List SystemUserNotifyUpdateResult</returns>
        public List<SystemUserNotifyUpdateResult> SystemUserNotifyUpdateCheck(SystemUserNotifyUpdateRow SystemUserNotifyUpdate)
        {
            var ListData = DataTrans.ToDataTable(SystemUserNotifyUpdate.ListSystemUserNotify);

            //主鍵
            var ListAutoKey = SystemUserNotifyUpdate.ListSystemUserNotify.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserNotifyUpdate.ListSystemUserNotify.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserNotifyUpdate.ListSystemUserNotify.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserNotify = (from c in dcShare.SystemUserNotify
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserNotify);

            var ListDataCheck = DataCheck("SystemUserNotify", ListData, TableData, true, "02");

            var Vdb = new List<SystemUserNotifyUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserNotifyUpdateResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改帳號通知
        /// </summary>
        /// <param name="SystemUserNotifyUpdate"></param>
        /// <returns>SystemUserNotifyUpdateResult</returns>
        public List<SystemUserNotifyUpdateResult> SystemUserNotifyUpdate(SystemUserNotifyUpdateRow SystemUserNotifyUpdate)
        {
            var SubmitChanges = SystemUserNotifyUpdate.SubmitChanges;
            var DataCheck = SystemUserNotifyUpdate.DataCheck;
            var UpdateCond = SystemUserNotifyUpdate.UpdateCond;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserNotifyUpdateResult>();
            SystemUserNotifyUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserNotifyUpdateCheck(SystemUserNotifyUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserNotifyUpdate.ListSystemUserNotify.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserNotifyUpdate.ListSystemUserNotify.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserNotifyUpdate.ListSystemUserNotify.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserNotify = (from c in dcShare.SystemUserNotify
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUserNotify in SystemUserNotifyUpdate.ListSystemUserNotify)
            {
                var AutoKey = ItemSystemUserNotify.AutoKey;
                var Code = ItemSystemUserNotify.Code;
                var Key = ItemSystemUserNotify.Code;

                var rSystemUserNotify = (from c in rsSystemUserNotify
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUserNotify != null)
                {
                    if (UpdateCond.Length == 0)
                    {
                        rSystemUserNotify.UserCode = ItemSystemUserNotify.UserCode;
                        rSystemUserNotify.UserCodeSend = ItemSystemUserNotify.UserCodeSend;
                        rSystemUserNotify.UserName = ItemSystemUserNotify.UserName;
                        rSystemUserNotify.NotifyTypeCode = ItemSystemUserNotify.NotifyTypeCode;
                        rSystemUserNotify.AppName = ItemSystemUserNotify.AppName;
                        rSystemUserNotify.AppCode = ItemSystemUserNotify.AppCode;
                        rSystemUserNotify.TitleContents = ItemSystemUserNotify.TitleContents;
                        rSystemUserNotify.Contents = ItemSystemUserNotify.Contents;
                        rSystemUserNotify.IsRead = ItemSystemUserNotify.IsRead;
                        rSystemUserNotify.DateA = ItemSystemUserNotify.DateA;
                        rSystemUserNotify.DateD = ItemSystemUserNotify.DateD;
                        rSystemUserNotify.Note = ItemSystemUserNotify.Note;
                        rSystemUserNotify.Sort = ItemSystemUserNotify.Sort;
                    }
                    else if (UpdateCond == "IsRead")
                    {
                        rSystemUserNotify.IsRead = ItemSystemUserNotify.IsRead;
                    }
                    else if (UpdateCond == "DateD")
                    {
                        rSystemUserNotify.DateD = ItemSystemUserNotify.DateD;
                    }

                    rSystemUserNotify.UpdateMan = SystemUserNotifyUpdate.UpdateMan;
                    rSystemUserNotify.UpdateDate = _NowDate;

                }
                else
                {
                    rVdb = new SystemUserNotifyUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(SystemUserNotifyUpdate), SystemUserNotifyUpdate.AppName, SystemUserNotifyUpdate.IpAddress, SystemUserNotifyUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new SystemUserNotifyUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserNotifyUpdate), SystemUserNotifyUpdate.AppName, SystemUserNotifyUpdate.IpAddress, SystemUserNotifyUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserNotifyUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserNotifyUpdate.AppName, SystemUserNotifyUpdate.IpAddress, SystemUserNotifyUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除帳號通知檢查
        /// </summary>
        /// <param name="SystemUserNotifyDelete"></param>
        /// <returns>List SystemUserNotifyDeleteResult</returns>
        public List<SystemUserNotifyDeleteResult> SystemUserNotifyDeleteCheck(SystemUserNotifyDeleteRow SystemUserNotifyDelete)
        {
            var ListData = DataTrans.ToDataTable(SystemUserNotifyDelete.ListSystemUserNotify);

            //主鍵
            var ListAutoKey = SystemUserNotifyDelete.ListSystemUserNotify.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserNotifyDelete.ListSystemUserNotify.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserNotifyDelete.ListSystemUserNotify.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserNotify = (from c in dcShare.SystemUserNotify
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserNotify);

            var ListDataCheck = DataCheck("SystemUserNotify", ListData, TableData, true, "03");

            var Vdb = new List<SystemUserNotifyDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserNotifyDeleteResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除帳號通知
        /// </summary>
        /// <param name="SystemUserNotifyDelete"></param>
        /// <returns>SystemUserNotifyDeleteResult</returns>
        public List<SystemUserNotifyDeleteResult> SystemUserNotifyDelete(SystemUserNotifyDeleteRow SystemUserNotifyDelete)
        {
            var SubmitChanges = SystemUserNotifyDelete.SubmitChanges;
            var DataCheck = SystemUserNotifyDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserNotifyDeleteResult>();
            SystemUserNotifyDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserNotifyDeleteCheck(SystemUserNotifyDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserNotifyDelete.ListSystemUserNotify.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserNotifyDelete.ListSystemUserNotify.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserNotifyDelete.ListSystemUserNotify.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserNotify = (from c in dcShare.SystemUserNotify
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUserNotify in SystemUserNotifyDelete.ListSystemUserNotify)
            {
                var AutoKey = ItemSystemUserNotify.AutoKey;
                var Code = ItemSystemUserNotify.Code;
                var Key = ItemSystemUserNotify.Code;

                var rSystemUserNotify = (from c in rsSystemUserNotify
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUserNotify != null)
                {
                    rSystemUserNotify.Status = "2";
                    rSystemUserNotify.UpdateMan = SystemUserNotifyDelete.UpdateMan;
                    rSystemUserNotify.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new SystemUserNotifyDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(SystemUserNotifyDelete), SystemUserNotifyDelete.AppName, SystemUserNotifyDelete.IpAddress, SystemUserNotifyDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new SystemUserNotifyDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserNotifyDelete), SystemUserNotifyDelete.AppName, SystemUserNotifyDelete.IpAddress, SystemUserNotifyDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserNotifyDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserNotifyDelete.AppName, SystemUserNotifyDelete.IpAddress, SystemUserNotifyDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}