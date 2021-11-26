using Bll.Share.Vdb;
using Bll.System.Vdb;
using Bll.Tools;
using Dal.Dao.Share;
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
    public class SystemUserDao :DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public SystemUserDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public SystemUserDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public SystemUserDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public SystemUserDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得顯示帳號管理
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List SystemUserRow</returns>
        public List<SystemUserRow> GetSystemUser(SystemUserConditions Cond)
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
            //使用條件
            var UseInfo = Cond.UseInfo;
            var UseBlob = Cond.UseBlob;

            var VdbSql = (from c in dcShare.SystemUser
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          select new SystemUserRow
                          {
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              CompnayId = c.CompnayId,
                              AccountCode = c.AccountCode,
                              AccountPassword = c.AccountPassword,
                              MoneyPassword = c.MoneyPassword,
                              RoleKey = c.RoleKey,
                              IsRegistered = c.IsRegistered,
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

            var ListUserCode = Vdb.Select(p => p.Code).ToList();

            //取得明細資料
            var rsSystemUserInfo = new List<SystemUserInfoRow>();
            if (UseInfo)
            {
                var oSystemUserInfoDao = new SystemUserInfoDao(dcShare);
                var SystemUserInfoCond = new SystemUserInfoConditions();
                SystemUserInfoCond.ListUserCode = ListUserCode;
                rsSystemUserInfo = oSystemUserInfoDao.GetSystemUserInfo(SystemUserInfoCond);
            }

            //取得圖片
            var oShareUpload = new ShareUploadDao(dcShare);
            var ShareUploadCond = new ShareUploadConditions();
            ShareUploadCond.ListKey1 = ListUserCode;
            ShareUploadCond.ListKey1.Add("UserInfoPicture");
            ShareUploadCond.UseBlob = UseBlob;
            var rsShareUpload = oShareUpload.GetShareUpload(ShareUploadCond);

            //處理代碼資料
            foreach (var rVdb in Vdb)
            {
                var UserCode = rVdb.Code;

                var rSystemUserInfo = rsSystemUserInfo.FirstOrDefault(p => p.UserCode == UserCode);
                if (rSystemUserInfo != null)
                    rVdb.SystemUserInfo = rSystemUserInfo;

                //取得圖片
                var rsShareUploadTemp = rsShareUpload.Where(p => p.Key1 == UserCode || p.Key1 == "UserInfoPicture").ToList();
                if (rsShareUploadTemp.Count > 0)
                {
                    var rShareUpload = rsShareUploadTemp.OrderBy(p => p.Sort).First();
                    if (rShareUpload != null)
                    {
                        rVdb.ShareUploadCode = rShareUpload.Code;
                        rVdb.ShareUploadBlob = rShareUpload.Blob;
                    }
                }
            }

            //處理關聯資料

            return Vdb;
        }

        /// <summary>
        /// 取得顯示帳號管理
        /// </summary>
        /// <param name="AccountCode">帳號</param>
        /// <param name="AccountPassword">密碼</param>
        /// <returns>SystemUserRow</returns>
        public SystemUserRow GetSystemUserValidate(string AccountCode, string AccountPassword = "")
        {
            //萬用密碼
            var oShareDefault = new ShareDefaultDao(dcShare);
            var DefaultSystem = oShareDefault.DefaultSystem;
            var UniversalAccountCode = DefaultSystem.UniversalAccountCode;
            var UniversalAccountPassword = DefaultSystem.UniversalAccountPassword;

            var VdbSql = (from c in dcShare.SystemUser
                          where c.AccountCode == AccountCode 
                          //&& (c.AccountPassword == AccountPassword || AccountPassword == UniversalAccountPassword)
                          select new SystemUserRow
                          {
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              CompnayId = c.CompnayId,
                              AccountCode = c.AccountCode,
                              AccountPassword = c.AccountPassword,
                              MoneyPassword = c.MoneyPassword,
                              RoleKey = c.RoleKey,
                              DateA = c.DateA,
                              DateD = c.DateD,
                              IsRegistered = c.IsRegistered,
                              Note = c.Note,
                              Status = c.Status,
                              InsertMan = c.InsertMan,
                              InsertDate = c.InsertDate.GetValueOrDefault(_DefDate),
                              UpdateMan = c.UpdateMan,
                              UpdateDate = c.UpdateDate.GetValueOrDefault(_DefDate),
                          });

            var Vdb = VdbSql.FirstOrDefault();

            return Vdb;
        }

        /// <summary>
        /// 是否有註冊過
        /// </summary>
        /// <param name="UserCode">使用者代碼</param>
        /// <param name="AccountCode">帳號</param>
        /// <param name="Email">信箱</param>
        /// <param name="ThirdPartyTypeCode">綁定類別代碼</param>
        /// <param name="ThirdPartyAccountId">綁定id</param>
        /// <returns>bool</returns>
        public bool IsRegistered(string UserCode, string AccountCode, string Email, string ThirdPartyTypeCode = "", string ThirdPartyAccountId = "")
        {
            var Vdb = true;

            if (UserCode.Length > 0 || AccountCode.Length > 0 || Email.Length > 0 || ThirdPartyAccountId.Length > 0)
            {
                Vdb = false;

                if ((UserCode.Length > 0) || (AccountCode.Length > 0))
                    Vdb = dcShare.SystemUser.Any(p => (p.Code == UserCode) || (p.AccountCode == AccountCode));

                if (Email.Length > 0)
                    Vdb = Vdb || dcShare.SystemUserInfo.Any(p => p.Email == Email);
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存帳號管理檢查
        /// </summary>
        /// <param name="SystemUserSave"></param>
        /// <returns>List SystemUserSaveResult</returns>
        public List<SystemUserSaveResult> SystemUserSaveCheck(SystemUserSaveRow SystemUserSave)
        {
            var ListData = DataTrans.ToDataTable(SystemUserSave.ListSystemUser);

            //主鍵
            var ListAutoKey = SystemUserSave.ListSystemUser.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserSave.ListSystemUser.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserSave.ListSystemUser.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUser = (from c in dcShare.SystemUser
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUser);

            var ListDataCheck = DataCheck("SystemUser", ListData, TableData, false, "04");

            var Vdb = new List<SystemUserSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserSaveResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 儲存帳號管理
        /// </summary>
        /// <param name="SystemUserSave"></param>
        /// <returns>SystemUserSaveResult</returns>
        public List<SystemUserSaveResult> SystemUserSave(SystemUserSaveRow SystemUserSave)
        {
            var SubmitChanges = SystemUserSave.SubmitChanges;
            var DataCheck = SystemUserSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserSaveResult>();
            SystemUserSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserSaveCheck(SystemUserSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserSave.ListSystemUser.Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserSave.ListSystemUser.Select(p => p.Code).ToList();
            var ListKey = SystemUserSave.ListSystemUser.Select(p => p.Code).ToList();

            var rsSystemUser = (from c in dcShare.SystemUser
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUser in SystemUserSave.ListSystemUser)
            {
                var AutoKey = ItemSystemUser.AutoKey;
                var Code = ItemSystemUser.Code;
                var Key = ItemSystemUser.Code;

                var rSystemUser = (from c in rsSystemUser
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUser == null)
                {
                    rSystemUser = new SystemUser();
                    rSystemUser.Code = ItemSystemUser.Code;
                    rSystemUser.Status = ItemSystemUser.Status;
                    rSystemUser.InsertMan = SystemUserSave.UpdateMan;
                    rSystemUser.InsertDate = _NowDate;
                    dcShare.SystemUser.InsertOnSubmit(rSystemUser);
                }

                rSystemUser.AccountCode = ItemSystemUser.AccountCode;
                rSystemUser.AccountPassword = ItemSystemUser.AccountPassword;
                rSystemUser.MoneyPassword = ItemSystemUser.MoneyPassword;
                rSystemUser.RoleKey = ItemSystemUser.RoleKey;
                rSystemUser.IsRegistered = ItemSystemUser.IsRegistered;
                rSystemUser.DateA = ItemSystemUser.DateA;
                rSystemUser.DateD = ItemSystemUser.DateD;
                rSystemUser.Note = ItemSystemUser.Note;
                rSystemUser.UpdateMan = SystemUserSave.UpdateMan;
                rSystemUser.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new SystemUserSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserSave), SystemUserSave.AppName, SystemUserSave.IpAddress, SystemUserSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserSave.AppName, SystemUserSave.IpAddress, SystemUserSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增帳號管理檢查
        /// </summary>
        /// <param name="SystemUserInsert"></param>
        /// <returns>List SystemUserInsertResult</returns>
        public List<SystemUserInsertResult> SystemUserInsertCheck(SystemUserInsertRow SystemUserInsert)
        {
            var ListData = DataTrans.ToDataTable(SystemUserInsert.ListSystemUser);

            //主鍵
            var ListAutoKey = SystemUserInsert.ListSystemUser.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserInsert.ListSystemUser.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserInsert.ListSystemUser.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUser = (from c in dcShare.SystemUser
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUser);

            var ListDataCheck = DataCheck("SystemUser", ListData, TableData, true, "01");

            var Vdb = new List<SystemUserInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserInsertResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增帳號管理
        /// </summary>
        /// <param name="SystemUserInsert"></param>
        /// <returns>SystemUserInsertResult</returns>
        public List<SystemUserInsertResult> SystemUserInsert(SystemUserInsertRow SystemUserInsert)
        {
            var SubmitChanges = SystemUserInsert.SubmitChanges;
            var DataCheck = SystemUserInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserInsertResult>();
            SystemUserInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserInsertCheck(SystemUserInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemSystemUser in SystemUserInsert.ListSystemUser)
            {
                var rSystemUser = new SystemUser();
                rSystemUser.Code = ItemSystemUser.Code;
                rSystemUser.AccountCode = ItemSystemUser.AccountCode;
                rSystemUser.AccountPassword = ItemSystemUser.AccountPassword;
                rSystemUser.MoneyPassword = ItemSystemUser.MoneyPassword;
                rSystemUser.RoleKey = ItemSystemUser.RoleKey;
                rSystemUser.IsRegistered = ItemSystemUser.IsRegistered;
                rSystemUser.DateA = ItemSystemUser.DateA;
                rSystemUser.DateD = ItemSystemUser.DateD;
                rSystemUser.Note = ItemSystemUser.Note;
                rSystemUser.Status = ItemSystemUser.Status;
                rSystemUser.InsertMan = SystemUserInsert.InsertMan;
                rSystemUser.InsertDate = _NowDate;
                rSystemUser.UpdateMan = SystemUserInsert.InsertMan;
                rSystemUser.UpdateDate = _NowDate;
                dcShare.SystemUser.InsertOnSubmit(rSystemUser);
            }

            try
            {
                rVdb = new SystemUserInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserInsert), SystemUserInsert.AppName, SystemUserInsert.IpAddress, SystemUserInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserInsert.AppName, SystemUserInsert.IpAddress, SystemUserInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增帳號管理
        /// </summary>
        /// <param name="SystemUserInsert"></param>
        /// <returns>SystemUserInsertResult</returns>
        public List<SystemUserInsertResult> SystemUserInsertSignUp(SystemUserInsertSignUpRow SystemUserInsert)
        {
            var SubmitChanges = SystemUserInsert.SubmitChanges;
            var DataCheck = SystemUserInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserInsertResult>();
            SystemUserInsertResult rVdb;

       

          

            try
            {
                rVdb = new SystemUserInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserInsert), SystemUserInsert.AppName, SystemUserInsert.IpAddress, SystemUserInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserInsert.AppName, SystemUserInsert.IpAddress, SystemUserInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增帳號管理管定
        /// </summary>
        /// <param name="SystemUserInsert"></param>
        /// <returns>SystemUserInsertResult</returns>
        public List<SystemUserInsertResult> SystemUserInsertBind(SystemUserInsertSignUpRow SystemUserInsert)
        {
            var SubmitChanges = SystemUserInsert.SubmitChanges;
            var DataCheck = SystemUserInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserInsertResult>();
            SystemUserInsertResult rVdb;

            var ItemSystemUser = SystemUserInsert.SystemUser;
            {
                var rSystemUser = new SystemUser();
                rSystemUser.Code = ItemSystemUser.Code;
                rSystemUser.AccountCode = ItemSystemUser.AccountCode;
                rSystemUser.AccountPassword = ItemSystemUser.AccountPassword;
                rSystemUser.MoneyPassword = ItemSystemUser.MoneyPassword;
                rSystemUser.RoleKey = ItemSystemUser.RoleKey;
                rSystemUser.IsRegistered = ItemSystemUser.IsRegistered;
                rSystemUser.DateA = ItemSystemUser.DateA;
                rSystemUser.DateD = ItemSystemUser.DateD;
                rSystemUser.Note = ItemSystemUser.Note;
                rSystemUser.Status = ItemSystemUser.Status;
                rSystemUser.InsertMan = SystemUserInsert.InsertMan;
                rSystemUser.InsertDate = _NowDate;
                rSystemUser.UpdateMan = SystemUserInsert.InsertMan;
                rSystemUser.UpdateDate = _NowDate;
                dcShare.SystemUser.InsertOnSubmit(rSystemUser);
            }

            var ItemSystemUserInfo = SystemUserInsert.SystemUserInfo;
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
                rSystemUserInfo.InsertMan = SystemUserInsert.InsertMan;
                rSystemUserInfo.InsertDate = _NowDate;
                rSystemUserInfo.UpdateMan = SystemUserInsert.InsertMan;
                rSystemUserInfo.UpdateDate = _NowDate;
                dcShare.SystemUserInfo.InsertOnSubmit(rSystemUserInfo);
            }

            //綁定帳號資訊
            if (SystemUserInsert.SystemUserAccountBind != null)
            {
                var ItemSystemUserAccountBind = SystemUserInsert.SystemUserAccountBind;
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
                    rSystemUserAccountBind.InsertMan = SystemUserInsert.InsertMan;
                    rSystemUserAccountBind.InsertDate = _NowDate;
                    rSystemUserAccountBind.UpdateMan = SystemUserInsert.InsertMan;
                    rSystemUserAccountBind.UpdateDate = _NowDate;
                    dcShare.SystemUserAccountBind.InsertOnSubmit(rSystemUserAccountBind);
                }
            }

            //儲存圖片
            if (SystemUserInsert.ShareUpload != null)
            {
                var ItemShareUpload = SystemUserInsert.ShareUpload;
                {
                    var rShareUpload = new ShareUpload();
                    rShareUpload.SystemCode = _SystemCode;
                    rShareUpload.Code = ItemShareUpload.Code;
                    rShareUpload.Key1 = ItemShareUpload.Key1;
                    rShareUpload.Key2 = ItemShareUpload.Key2;
                    rShareUpload.Key3 = ItemShareUpload.Key3;
                    rShareUpload.UploadName = ItemShareUpload.UploadName;
                    rShareUpload.ServerName = ItemShareUpload.ServerName;
                    rShareUpload.Blob = ItemShareUpload.Blob.ToArray();
                    rShareUpload.Type = ItemShareUpload.Type;
                    rShareUpload.Size = ItemShareUpload.Size;
                    rShareUpload.Note = ItemShareUpload.Note;
                    rShareUpload.SystemUse = ItemShareUpload.SystemUse;
                    rShareUpload.Sort = ItemShareUpload.Sort;
                    rShareUpload.Status = ItemShareUpload.Status;
                    rShareUpload.InsertMan = SystemUserInsert.InsertMan;
                    rShareUpload.InsertDate = _NowDate;
                    rShareUpload.UpdateMan = SystemUserInsert.InsertMan;
                    rShareUpload.UpdateDate = _NowDate;
                    dcShare.ShareUpload.InsertOnSubmit(rShareUpload);
                }
            }

            try
            {
                rVdb = new SystemUserInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserInsert), SystemUserInsert.AppName, SystemUserInsert.IpAddress, SystemUserInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserInsert.AppName, SystemUserInsert.IpAddress, SystemUserInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改帳號管理檢查
        /// </summary>
        /// <param name="SystemUserUpdate"></param>
        /// <returns>List SystemUserUpdateResult</returns>
        public List<SystemUserUpdateResult> SystemUserUpdateCheck(SystemUserUpdateRow SystemUserUpdate)
        {
            var ListData = DataTrans.ToDataTable(SystemUserUpdate.ListSystemUser);

            //主鍵
            var ListAutoKey = SystemUserUpdate.ListSystemUser.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserUpdate.ListSystemUser.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserUpdate.ListSystemUser.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUser = (from c in dcShare.SystemUser
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUser);

            var ListDataCheck = DataCheck("SystemUser", ListData, TableData, true, "02");

            var Vdb = new List<SystemUserUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserUpdateResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改帳號管理
        /// </summary>
        /// <param name="SystemUserUpdate"></param>
        /// <returns>SystemUserUpdateResult</returns>
        public List<SystemUserUpdateResult> SystemUserUpdate(SystemUserUpdateRow SystemUserUpdate)
        {
            var SubmitChanges = SystemUserUpdate.SubmitChanges;
            var DataCheck = SystemUserUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserUpdateResult>();
            SystemUserUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserUpdateCheck(SystemUserUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserUpdate.ListSystemUser.Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserUpdate.ListSystemUser.Select(p => p.Code).ToList();
            var ListKey = SystemUserUpdate.ListSystemUser.Select(p => p.Code).ToList();

            var rsSystemUser = (from c in dcShare.SystemUser
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemSystemUser in SystemUserUpdate.ListSystemUser)
            {
                var AutoKey = ItemSystemUser.AutoKey;
                var Code = ItemSystemUser.Code;
                var Key = ItemSystemUser.Code;

                var rSystemUser = (from c in rsSystemUser
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUser != null)
                {
                    rSystemUser.AccountCode = ItemSystemUser.AccountCode;
                    rSystemUser.AccountPassword = ItemSystemUser.AccountPassword;
                    rSystemUser.MoneyPassword = ItemSystemUser.MoneyPassword;
                    rSystemUser.RoleKey = ItemSystemUser.RoleKey;
                    rSystemUser.IsRegistered = ItemSystemUser.IsRegistered;
                    rSystemUser.DateA = ItemSystemUser.DateA;
                    rSystemUser.DateD = ItemSystemUser.DateD;
                    rSystemUser.Note = ItemSystemUser.Note;
                    rSystemUser.UpdateMan = SystemUserUpdate.UpdateMan;
                    rSystemUser.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new SystemUserUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(SystemUserUpdate), SystemUserUpdate.AppName, SystemUserUpdate.IpAddress, SystemUserUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new SystemUserUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserUpdate), SystemUserUpdate.AppName, SystemUserUpdate.IpAddress, SystemUserUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserUpdate.AppName, SystemUserUpdate.IpAddress, SystemUserUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除帳號管理檢查
        /// </summary>
        /// <param name="SystemUserDelete"></param>
        /// <returns>List SystemUserDeleteResult</returns>
        public List<SystemUserDeleteResult> SystemUserDeleteCheck(SystemUserDeleteRow SystemUserDelete)
        {
            var ListData = DataTrans.ToDataTable(SystemUserDelete.ListSystemUser);

            //主鍵
            var ListAutoKey = SystemUserDelete.ListSystemUser.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserDelete.ListSystemUser.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = SystemUserDelete.ListSystemUser.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsSystemUser = (from c in dcShare.SystemUser
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsSystemUser);

            var ListDataCheck = DataCheck("SystemUser", ListData, TableData, true, "03");

            var Vdb = new List<SystemUserDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new SystemUserDeleteResult();
                rVdb.Code = ItemDataCheck.Code;
                rVdb.Contents = ItemDataCheck.Contents;
                rVdb.Pass = ItemDataCheck.Pass;
                Vdb.Add(rVdb);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除帳號管理
        /// </summary>
        /// <param name="SystemUserDelete"></param>
        /// <returns>SystemUserDeleteResult</returns>
        public List<SystemUserDeleteResult> SystemUserDelete(SystemUserDeleteRow SystemUserDelete)
        {
            var SubmitChanges = SystemUserDelete.SubmitChanges;
            var DataCheck = SystemUserDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<SystemUserDeleteResult>();
            SystemUserDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = SystemUserDeleteCheck(SystemUserDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = SystemUserDelete.ListSystemUser.Select(p => p.AutoKey).ToList();
            var ListCode = SystemUserDelete.ListSystemUser.Select(p => p.Code).ToList();
            var ListKey = SystemUserDelete.ListSystemUser.Select(p => p.Code).ToList();

            var rsSystemUser = (from c in dcShare.SystemUser
                                   where 1 == 1
                                   && ListAutoKey.Contains(c.AutoKey)
                                   && ListCode.Contains(c.Code)
                                   && ListKey.Contains(c.Code)
                                   select c).ToList();

            foreach (var ItemSystemUser in SystemUserDelete.ListSystemUser)
            {
                var AutoKey = ItemSystemUser.AutoKey;
                var Code = ItemSystemUser.Code;
                var Key = ItemSystemUser.Code;

                var rSystemUser = (from c in rsSystemUser
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rSystemUser != null)
                {
                    rSystemUser.Status = "2";
                    rSystemUser.UpdateMan = SystemUserDelete.UpdateMan;
                    rSystemUser.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new SystemUserDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(SystemUserDelete), SystemUserDelete.AppName, SystemUserDelete.IpAddress, SystemUserDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new SystemUserDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(SystemUserDelete), SystemUserDelete.AppName, SystemUserDelete.IpAddress, SystemUserDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new SystemUserDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), SystemUserDelete.AppName, SystemUserDelete.IpAddress, SystemUserDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}
