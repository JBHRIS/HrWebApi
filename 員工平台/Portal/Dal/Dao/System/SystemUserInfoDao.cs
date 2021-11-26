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
    public class SystemUserInfoDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public SystemUserInfoDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public SystemUserInfoDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public SystemUserInfoDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public SystemUserInfoDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得顯示帳號管理資訊
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List SystemUserInfoRow</returns>
        public List<SystemUserInfoRow> GetSystemUserInfo(SystemUserInfoConditions Cond)
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
            //使用者代碼
            var ListUserCode = Cond.ListUserCode;
            //使用者代碼
            var UserCode = Cond.UserCode;

            var VdbSql = (from c in dcShare.SystemUserInfo
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          //&& (ListUserCode.Count > 0 || UserCode.Length > 0)
                          && ((ListUserCode.Count == 0) || (ListUserCode.Contains(c.UserCode)))
                          && ((UserCode.Length == 0) || (c.UserCode == UserCode))
                          select new SystemUserInfoRow
                          {
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              UserCode = c.UserCode,
                              UserName = c.UserName,
                              AnonymousName = c.AnonymousName,
                              Birthday = c.Birthday,
                              CardId = c.CardId,
                              Address = c.Address,
                              Tel = c.Tel,
                              TelA = c.TelA,
                              TelD = c.TelD,
                              Email = c.Email,
                              EmailA = c.EmailA,
                              EmailD = c.EmailD,
                              Sex = c.Sex,
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

            //處理關聯資料

            return Vdb;
        }

        /// <summary>
        /// 儲存帳號管理資訊檢查
        /// </summary>
        /// <param name="SystemUserInfoSave"></param>
        /// <returns>List SystemUserInfoSaveResult</returns>
        public List<SystemUserInfoSaveResult> SystemUserInfoSaveCheck(SystemUserInfoSaveRow SystemUserInfoSave)
        {
            var ListData = DataTrans.ToDataTable(SystemUserInfoSave.ListSystemUserInfo);

            //主鍵
            var ListAutoKey = SystemUserInfoSave.ListSystemUserInfo.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserInfoSave.ListSystemUserInfo.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserInfoSave.ListSystemUserInfo.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserInfo = (from c in dcShare.SystemUserInfo
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserInfo);

            var ListDataCheck = DataCheck("SystemUserInfo", ListData, TableData, false, "04");

            var Vdb = new List<SystemUserInfoSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserInfoSaveResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存帳號管理資訊
        /// </summary>
        /// <param name="SystemUserInfoSave"></param>
        /// <returns>SystemUserInfoSaveResult</returns>
        public List<SystemUserInfoSaveResult> SystemUserInfoSave(SystemUserInfoSaveRow SystemUserInfoSave)
        {
            var SubmitChanges = SystemUserInfoSave.SubmitChanges;
            var DataCheck = SystemUserInfoSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserInfoSaveResult>();
            SystemUserInfoSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserInfoSaveCheck(SystemUserInfoSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserInfoSave.ListSystemUserInfo.Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserInfoSave.ListSystemUserInfo.Select(p => p.Code).ToList();
            var ListKey = SystemUserInfoSave.ListSystemUserInfo.Select(p => p.Code).ToList();

            var rsSystemUserInfo = (from c in dcShare.SystemUserInfo
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUserInfo in SystemUserInfoSave.ListSystemUserInfo)
            {
                var AutoKey = ItemSystemUserInfo.AutoKey;
                var Code = ItemSystemUserInfo.Code;
                var Key = ItemSystemUserInfo.Code;

                var rSystemUserInfo = (from c in rsSystemUserInfo
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUserInfo == null)
                {
                    rSystemUserInfo = new SystemUserInfo();
                    rSystemUserInfo.Code = ItemSystemUserInfo.Code;
                    rSystemUserInfo.Status = ItemSystemUserInfo.Status;
                    rSystemUserInfo.InsertMan = SystemUserInfoSave.UpdateMan;
                    rSystemUserInfo.InsertDate = _NowDate;
                    dcShare.SystemUserInfo.InsertOnSubmit(rSystemUserInfo);
                }

                rSystemUserInfo.UserCode = ItemSystemUserInfo.UserCode;
                rSystemUserInfo.UserName = ItemSystemUserInfo.UserName;
                rSystemUserInfo.AnonymousName = ItemSystemUserInfo.AnonymousName;
                rSystemUserInfo.Birthday = ItemSystemUserInfo.Birthday;
                rSystemUserInfo.CardId = ItemSystemUserInfo.CardId;
                rSystemUserInfo.Address = ItemSystemUserInfo.Address;
                rSystemUserInfo.Tel = ItemSystemUserInfo.Tel;
                rSystemUserInfo.TelA = ItemSystemUserInfo.TelA;
                rSystemUserInfo.TelD = ItemSystemUserInfo.TelD;
                rSystemUserInfo.Email = ItemSystemUserInfo.Email;
                rSystemUserInfo.EmailA = ItemSystemUserInfo.EmailA;
                rSystemUserInfo.EmailD = ItemSystemUserInfo.EmailD;
                rSystemUserInfo.Sex = ItemSystemUserInfo.Sex;
                rSystemUserInfo.Note = ItemSystemUserInfo.Note;
                rSystemUserInfo.UpdateMan = SystemUserInfoSave.UpdateMan;
                rSystemUserInfo.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new SystemUserInfoSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserInfoSave), SystemUserInfoSave.AppName, SystemUserInfoSave.IpAddress, SystemUserInfoSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserInfoSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserInfoSave.AppName, SystemUserInfoSave.IpAddress, SystemUserInfoSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增帳號管理資訊檢查
        /// </summary>
        /// <param name="SystemUserInfoInsert"></param>
        /// <returns>List SystemUserInfoInsertResult</returns>
        public List<SystemUserInfoInsertResult> SystemUserInfoInsertCheck(SystemUserInfoInsertRow SystemUserInfoInsert)
        {
            var ListData = DataTrans.ToDataTable(SystemUserInfoInsert.ListSystemUserInfo);

            //主鍵
            var ListAutoKey = SystemUserInfoInsert.ListSystemUserInfo.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserInfoInsert.ListSystemUserInfo.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserInfoInsert.ListSystemUserInfo.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserInfo = (from c in dcShare.SystemUserInfo
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserInfo);

            var ListDataCheck = DataCheck("SystemUserInfo", ListData, TableData, true, "01");

            var Vdb = new List<SystemUserInfoInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserInfoInsertResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增帳號管理資訊
        /// </summary>
        /// <param name="SystemUserInfoInsert"></param>
        /// <returns>SystemUserInfoInsertResult</returns>
        public List<SystemUserInfoInsertResult> SystemUserInfoInsert(SystemUserInfoInsertRow SystemUserInfoInsert)
        {
            var SubmitChanges = SystemUserInfoInsert.SubmitChanges;
            var DataCheck = SystemUserInfoInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserInfoInsertResult>();
            SystemUserInfoInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserInfoInsertCheck(SystemUserInfoInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemSystemUserInfo in SystemUserInfoInsert.ListSystemUserInfo)
            {
                var rSystemUserInfo = new SystemUserInfo();
                rSystemUserInfo.Code = ItemSystemUserInfo.Code;
                rSystemUserInfo.UserCode = ItemSystemUserInfo.UserCode;
                rSystemUserInfo.UserName = ItemSystemUserInfo.UserName;
                rSystemUserInfo.AnonymousName = ItemSystemUserInfo.AnonymousName;
                rSystemUserInfo.Birthday = ItemSystemUserInfo.Birthday;
                rSystemUserInfo.CardId = ItemSystemUserInfo.CardId;
                rSystemUserInfo.Address = ItemSystemUserInfo.Address;
                rSystemUserInfo.Tel = ItemSystemUserInfo.Tel;
                rSystemUserInfo.TelA = ItemSystemUserInfo.TelA;
                rSystemUserInfo.TelD = ItemSystemUserInfo.TelD;
                rSystemUserInfo.Email = ItemSystemUserInfo.Email;
                rSystemUserInfo.EmailA = ItemSystemUserInfo.EmailA;
                rSystemUserInfo.EmailD = ItemSystemUserInfo.EmailD;
                rSystemUserInfo.Sex = ItemSystemUserInfo.Sex;
                rSystemUserInfo.Note = ItemSystemUserInfo.Note;
                rSystemUserInfo.Status = ItemSystemUserInfo.Status;
                rSystemUserInfo.InsertMan = SystemUserInfoInsert.InsertMan;
                rSystemUserInfo.InsertDate = _NowDate;
                rSystemUserInfo.UpdateMan = SystemUserInfoInsert.InsertMan;
                rSystemUserInfo.UpdateDate = _NowDate;
                dcShare.SystemUserInfo.InsertOnSubmit(rSystemUserInfo);
            }

            try
            {
                rVdb = new SystemUserInfoInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserInfoInsert), SystemUserInfoInsert.AppName, SystemUserInfoInsert.IpAddress, SystemUserInfoInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserInfoInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserInfoInsert.AppName, SystemUserInfoInsert.IpAddress, SystemUserInfoInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改帳號管理資訊檢查
        /// </summary>
        /// <param name="SystemUserInfoUpdate"></param>
        /// <returns>List SystemUserInfoUpdateResult</returns>
        public List<SystemUserInfoUpdateResult> SystemUserInfoUpdateCheck(SystemUserInfoUpdateRow SystemUserInfoUpdate)
        {
            var ListData = DataTrans.ToDataTable(SystemUserInfoUpdate.ListSystemUserInfo);

            //主鍵
            var ListAutoKey = SystemUserInfoUpdate.ListSystemUserInfo.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserInfoUpdate.ListSystemUserInfo.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserInfoUpdate.ListSystemUserInfo.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserInfo = (from c in dcShare.SystemUserInfo
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserInfo);

            var ListDataCheck = DataCheck("SystemUserInfo", ListData, TableData, true, "02");

            var Vdb = new List<SystemUserInfoUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserInfoUpdateResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改帳號管理資訊
        /// </summary>
        /// <param name="SystemUserInfoUpdate"></param>
        /// <returns>SystemUserInfoUpdateResult</returns>
        public List<SystemUserInfoUpdateResult> SystemUserInfoUpdate(SystemUserInfoUpdateRow SystemUserInfoUpdate)
        {
            var SubmitChanges = SystemUserInfoUpdate.SubmitChanges;
            var DataCheck = SystemUserInfoUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserInfoUpdateResult>();
            SystemUserInfoUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserInfoUpdateCheck(SystemUserInfoUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserInfoUpdate.ListSystemUserInfo.Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserInfoUpdate.ListSystemUserInfo.Select(p => p.Code).ToList();
            var ListKey = SystemUserInfoUpdate.ListSystemUserInfo.Select(p => p.Code).ToList();

            var rsSystemUserInfo = (from c in dcShare.SystemUserInfo
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUserInfo in SystemUserInfoUpdate.ListSystemUserInfo)
            {
                var AutoKey = ItemSystemUserInfo.AutoKey;
                var Code = ItemSystemUserInfo.Code;
                var Key = ItemSystemUserInfo.Code;

                var rSystemUserInfo = (from c in rsSystemUserInfo
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUserInfo != null)
                {
                    rSystemUserInfo.UserCode = ItemSystemUserInfo.UserCode;
                    rSystemUserInfo.UserName = ItemSystemUserInfo.UserName;
                    rSystemUserInfo.AnonymousName = ItemSystemUserInfo.AnonymousName;
                    rSystemUserInfo.Birthday = ItemSystemUserInfo.Birthday;
                    rSystemUserInfo.CardId = ItemSystemUserInfo.CardId;
                    rSystemUserInfo.Address = ItemSystemUserInfo.Address;
                    rSystemUserInfo.Tel = ItemSystemUserInfo.Tel;
                    rSystemUserInfo.TelA = ItemSystemUserInfo.TelA;
                    rSystemUserInfo.TelD = ItemSystemUserInfo.TelD;
                    rSystemUserInfo.Email = ItemSystemUserInfo.Email;
                    rSystemUserInfo.EmailA = ItemSystemUserInfo.EmailA;
                    rSystemUserInfo.EmailD = ItemSystemUserInfo.EmailD;
                    rSystemUserInfo.Sex = ItemSystemUserInfo.Sex;
                    rSystemUserInfo.Note = ItemSystemUserInfo.Note;
                    rSystemUserInfo.UpdateMan = SystemUserInfoUpdate.UpdateMan;
                    rSystemUserInfo.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new SystemUserInfoUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(SystemUserInfoUpdate), SystemUserInfoUpdate.AppName, SystemUserInfoUpdate.IpAddress, SystemUserInfoUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new SystemUserInfoUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserInfoUpdate), SystemUserInfoUpdate.AppName, SystemUserInfoUpdate.IpAddress, SystemUserInfoUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserInfoUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserInfoUpdate.AppName, SystemUserInfoUpdate.IpAddress, SystemUserInfoUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除帳號管理資訊檢查
        /// </summary>
        /// <param name="SystemUserInfoDelete"></param>
        /// <returns>List SystemUserInfoDeleteResult</returns>
        public List<SystemUserInfoDeleteResult> SystemUserInfoDeleteCheck(SystemUserInfoDeleteRow SystemUserInfoDelete)
        {
            var ListData = DataTrans.ToDataTable(SystemUserInfoDelete.ListSystemUserInfo);

            //主鍵
            var ListAutoKey = SystemUserInfoDelete.ListSystemUserInfo.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserInfoDelete.ListSystemUserInfo.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserInfoDelete.ListSystemUserInfo.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUserInfo = (from c in dcShare.SystemUserInfo
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUserInfo);

            var ListDataCheck = DataCheck("SystemUserInfo", ListData, TableData, true, "03");

            var Vdb = new List<SystemUserInfoDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserInfoDeleteResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除帳號管理資訊
        /// </summary>
        /// <param name="SystemUserInfoDelete"></param>
        /// <returns>SystemUserInfoDeleteResult</returns>
        public List<SystemUserInfoDeleteResult> SystemUserInfoDelete(SystemUserInfoDeleteRow SystemUserInfoDelete)
        {
            var SubmitChanges = SystemUserInfoDelete.SubmitChanges;
            var DataCheck = SystemUserInfoDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserInfoDeleteResult>();
            SystemUserInfoDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserInfoDeleteCheck(SystemUserInfoDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserInfoDelete.ListSystemUserInfo.Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserInfoDelete.ListSystemUserInfo.Select(p => p.Code).ToList();
            var ListKey = SystemUserInfoDelete.ListSystemUserInfo.Select(p => p.Code).ToList();

            var rsSystemUserInfo = (from c in dcShare.SystemUserInfo
                                   where 1 == 1
                                   && ListAutoKey.Contains(c.AutoKey)
                                   && ListCode.Contains(c.Code)
                                   && ListKey.Contains(c.Code)
                                   select c).ToList();

            foreach (var ItemSystemUserInfo in SystemUserInfoDelete.ListSystemUserInfo)
            {
                var AutoKey = ItemSystemUserInfo.AutoKey;
                var Code = ItemSystemUserInfo.Code;
                var Key = ItemSystemUserInfo.Code;

                var rSystemUserInfo = (from c in rsSystemUserInfo
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUserInfo != null)
                {
                    rSystemUserInfo.Status = "2";
                    rSystemUserInfo.UpdateMan = SystemUserInfoDelete.UpdateMan;
                    rSystemUserInfo.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new SystemUserInfoDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(SystemUserInfoDelete), SystemUserInfoDelete.AppName, SystemUserInfoDelete.IpAddress, SystemUserInfoDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new SystemUserInfoDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserInfoDelete), SystemUserInfoDelete.AppName, SystemUserInfoDelete.IpAddress, SystemUserInfoDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserInfoDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserInfoDelete.AppName, SystemUserInfoDelete.IpAddress, SystemUserInfoDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}
