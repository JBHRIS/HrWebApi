using Bll.Share.Vdb;
using Bll.System.Vdb;
using Bll.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dao.Share
{
    /// <summary>
    /// 
    /// </summary>
    public class ShareSendQueueDao : DataAccessDao
    {
        /// <summary>
        /// 
        /// </summary>
        public ShareSendQueueDao() : base() { dcShare = new dcShareDataContext(); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        public ShareSendQueueDao(IDbConnection conn) : base(conn) { dcShare = new dcShareDataContext(conn); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public ShareSendQueueDao(string ConnectionString) : base(ConnectionString) { dcShare = new dcShareDataContext(ConnectionString); }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dcShare"></param>
        public ShareSendQueueDao(dcShareDataContext dcShare) : base(dcShare) { this.dcShare = dcShare; }

        /// <summary>
        /// 取得顯示欄位設定
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List ShareSendQueueRow</returns>
        public List<ShareSendQueueRow> GetShareSendQueue(ShareSendQueueConditions Cond)
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
            //寄送類別代碼
            var ListSendTypeCode = Cond.ListSendTypeCode;

            var VdbSql = (from c in dcShare.ShareSendQueue
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          && ((ListSendTypeCode.Count == 0) || (ListSendTypeCode.Contains(c.SendTypeCode)))
                          orderby c.Sort
                          select new ShareSendQueueRow
                          {
                              SystemCode = c.SystemCode,
                              AutoNumber = 0,
                              Key = c.Code,
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              SendTypeCode = c.SendTypeCode,
                              SendTypeName = "",
                              FromAddr = c.FromAddr,
                              FromName = c.FromName,
                              ToAddr = c.ToAddr,
                              ToName = c.ToName,
                              ToAddrCopy = c.ToAddrCopy,
                              ToNameCopy = c.ToNameCopy,
                              ToAddrConfidential = c.ToAddrConfidential,
                              ToNameConfidential = c.ToNameConfidential,
                              Subject = c.Subject,
                              Body = c.Body,
                              Retry = c.Retry,
                              Sucess = c.Sucess,
                              Suspend = c.Suspend,
                              DateSend = c.DateSend,
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
            var rsColumnType = ShareCodeNameCode("SendType");
            foreach (var rVdb in Vdb)
            {
                rVdb.AutoNumber = i;
                i++;

                rVdb.SendTypeName = rsColumnType.FirstOrDefault(p => p.Code == rVdb.SendTypeCode)?.Name ?? rVdb.SendTypeName;
            }

            //處理關聯資料

            return Vdb;
        }

        /// <summary>
        /// 取得顯示欄位設定
        /// </summary>
        /// <param name="Cond"></param>
        /// <returns>List ShareSendQueueRow</returns>
        public List<ShareSendQueueRow> GetShareSendQueueNotSend(ShareSendQueueConditions Cond)
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
            //寄送類別代碼
            var ListSendTypeCode = Cond.ListSendTypeCode;

            var oShareDefault = new ShareDefaultDao(dcShare);
            var rMail = oShareDefault.DefaultMail;

            var MaxRetry = rMail.MaxRetry;

            var VdbSql = (from c in dcShare.ShareSendQueue
                          where ListStatus.Contains(c.Status)
                          && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                          && ((Code.Length == 0) || (c.Code == Code))
                          && ((Key.Length == 0) || (c.Code == Key))
                          && ((ListSendTypeCode.Count == 0) || (ListSendTypeCode.Contains(c.SendTypeCode)))
                          && !c.Sucess 
                          && !c.Suspend
                          && c.Retry < MaxRetry
                          orderby c.Sort
                          select new ShareSendQueueRow
                          {
                              SystemCode = c.SystemCode,
                              AutoNumber = 0,
                              Key = c.Code,
                              AutoKey = c.AutoKey,
                              Code = c.Code,
                              SendTypeCode = c.SendTypeCode,
                              SendTypeName = "",
                              FromAddr = c.FromAddr,
                              FromName = c.FromName,
                              ToAddr = c.ToAddr,
                              ToName = c.ToName,
                              ToAddrCopy = c.ToAddrCopy,
                              ToNameCopy = c.ToNameCopy,
                              ToAddrConfidential = c.ToAddrConfidential,
                              ToNameConfidential = c.ToNameConfidential,
                              Subject = c.Subject,
                              Body = c.Body,
                              Retry = c.Retry,
                              Sucess = c.Sucess,
                              Suspend = c.Suspend,
                              DateSend = c.DateSend,
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
            var rsColumnType = ShareCodeNameCode("SendType");
            foreach (var rVdb in Vdb)
            {
                rVdb.AutoNumber = i;
                i++;

                rVdb.SendTypeName = rsColumnType.FirstOrDefault(p => p.Code == rVdb.SendTypeCode)?.Name ?? rVdb.SendTypeName;
            }

            //處理關聯資料

            return Vdb;
        }

        /// <summary>
        /// 傳送信件
        /// </summary>
        /// <param name="ToMail"></param>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <param name="Thread"></param>
        public bool SendMail(MailAddress ToMail, string Subject, string Body, bool Thread = false)
        {
            var Vdb = false;

            var oShareDefault = new ShareDefaultDao(dcShare);
            var rMail = oShareDefault.DefaultMail;

            string Host = rMail.Host;
            int Port = rMail.Port;
            string CredentialsType = rMail.CredentialsType;
            MailAddress Sender = new MailAddress(rMail.Sender, rMail.SenderName);
            bool IsNeedCredentials = rMail.IsNeedCredentials;
            bool IsNeedSsl = rMail.IsNeedSsl;
            int Priority = rMail.Priority;
            string UserId = rMail.UserId;
            string Password = rMail.Password;
            bool EnableTestMode = rMail.EnableTestMode;
            List<string> TestMail = rMail.TestMail;

            List<MailAddress> SendWho = new List<MailAddress>();

            //開啟測試模式時，只會寄到測試帳號，但是會顯示原收件帳號
            if (EnableTestMode)
            {
                foreach (var to in TestMail)
                    SendWho.Add(new MailAddress(to, ToMail.Address));

                Subject = Subject.Length > 0 ? Subject : rMail.Subject;
                Body = ((Body.Length > 0) ? Body : rMail.BodyContent);
            }
            else
                SendWho.Add(ToMail);

            Body = rMail.BodyHead + Body + rMail.BodyFoot;

            foreach (var to in SendWho)
                if (Thread)
                    Vdb = Send.Mail.SendThread(Host, Port, CredentialsType, Sender, IsNeedCredentials, IsNeedSsl, Priority,
                        UserId, Password, to, Subject, Body);
                else
                    Vdb = Send.Mail.Send(Host, Port, CredentialsType, Sender, IsNeedCredentials, IsNeedSsl, Priority,
                     UserId, Password, to, Subject, Body);

            return Vdb;
        }

        /// <summary>
        /// 儲存欄位設定檢查
        /// </summary>
        /// <param name="ShareSendQueueSave"></param>
        /// <returns>List ShareSendQueueSaveResult</returns>
        public List<ShareSendQueueSaveResult> ShareSendQueueSaveCheck(ShareSendQueueSaveRow ShareSendQueueSave)
        {
            var ListData = DataTrans.ToDataTable(ShareSendQueueSave.ListShareSendQueue);

            //主鍵
            var ListAutoKey = ShareSendQueueSave.ListShareSendQueue.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareSendQueueSave.ListShareSendQueue.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareSendQueueSave.ListShareSendQueue.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareSendQueue = (from c in dcShare.ShareSendQueue
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareSendQueue);

            var ListDataCheck = DataCheck("ShareSendQueue", ListData, TableData, false, "04");

            var Vdb = new List<ShareSendQueueSaveResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareSendQueueSaveResult();
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
        /// <param name="ShareSendQueueSave"></param>
        /// <returns>ShareSendQueueSaveResult</returns>
        public List<ShareSendQueueSaveResult> ShareSendQueueSave(ShareSendQueueSaveRow ShareSendQueueSave)
        {
            var SubmitChanges = ShareSendQueueSave.SubmitChanges;
            var DataCheck = ShareSendQueueSave.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0501000001");  //儲存成功
            ListShareDisplayMessageCode.Add("0502000001");  //儲存失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareSendQueueSaveResult>();
            ShareSendQueueSaveResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareSendQueueSaveCheck(ShareSendQueueSave);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareSendQueueSave.ListShareSendQueue.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareSendQueueSave.ListShareSendQueue.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareSendQueueSave.ListShareSendQueue.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareSendQueue = (from c in dcShare.ShareSendQueue
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemShareSendQueue in ShareSendQueueSave.ListShareSendQueue)
            {
                var AutoKey = ItemShareSendQueue.AutoKey;
                var Code = ItemShareSendQueue.Code;
                var Key = ItemShareSendQueue.Code;

                var rShareSendQueue = (from c in rsShareSendQueue
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rShareSendQueue == null)
                {
                    rShareSendQueue = new ShareSendQueue();
                    rShareSendQueue.Code = ItemShareSendQueue.Code;
                    rShareSendQueue.Status = ItemShareSendQueue.Status;
                    rShareSendQueue.InsertMan = ShareSendQueueSave.UpdateMan;
                    rShareSendQueue.InsertDate = _NowDate;
                    dcShare.ShareSendQueue.InsertOnSubmit(rShareSendQueue);
                }

                rShareSendQueue.SystemCode = ItemShareSendQueue.SystemCode;
                rShareSendQueue.SendTypeCode = ItemShareSendQueue.SendTypeCode;
                rShareSendQueue.FromAddr = ItemShareSendQueue.FromAddr;
                rShareSendQueue.FromName = ItemShareSendQueue.FromName;
                rShareSendQueue.ToAddr = ItemShareSendQueue.ToAddr;
                rShareSendQueue.ToName = ItemShareSendQueue.ToName;
                rShareSendQueue.ToAddrCopy = ItemShareSendQueue.ToAddrCopy;
                rShareSendQueue.ToNameCopy = ItemShareSendQueue.ToNameCopy;
                rShareSendQueue.ToAddrConfidential = ItemShareSendQueue.ToAddrConfidential;
                rShareSendQueue.ToNameConfidential = ItemShareSendQueue.ToNameConfidential;
                rShareSendQueue.Subject = ItemShareSendQueue.Subject;
                rShareSendQueue.Body = ItemShareSendQueue.Body;
                rShareSendQueue.Retry = ItemShareSendQueue.Retry;
                rShareSendQueue.Sucess = ItemShareSendQueue.Sucess;
                rShareSendQueue.Suspend = ItemShareSendQueue.Suspend;
                rShareSendQueue.DateSend = ItemShareSendQueue.DateSend;
                rShareSendQueue.Note = ItemShareSendQueue.Note;
                rShareSendQueue.Sort = ItemShareSendQueue.Sort;
                rShareSendQueue.UpdateMan = ShareSendQueueSave.UpdateMan;
                rShareSendQueue.UpdateDate = _NowDate;
            }

            try
            {
                rVdb = new ShareSendQueueSaveResult();
                rVdb.Code = "0501000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareSendQueueSave), ShareSendQueueSave.AppName, ShareSendQueueSave.IpAddress, ShareSendQueueSave.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareSendQueueSaveResult();
                rVdb.Code = "0502000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "儲存失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareSendQueueSave.AppName, ShareSendQueueSave.IpAddress, ShareSendQueueSave.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 新增欄位設定檢查
        /// </summary>
        /// <param name="ShareSendQueueInsert"></param>
        /// <returns>List ShareSendQueueInsertResult</returns>
        public List<ShareSendQueueInsertResult> ShareSendQueueInsertCheck(ShareSendQueueInsertRow ShareSendQueueInsert)
        {
            var ListData = DataTrans.ToDataTable(ShareSendQueueInsert.ListShareSendQueue);

            //主鍵
            var ListAutoKey = ShareSendQueueInsert.ListShareSendQueue.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareSendQueueInsert.ListShareSendQueue.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareSendQueueInsert.ListShareSendQueue.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareSendQueue = (from c in dcShare.ShareSendQueue
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareSendQueue);

            var ListDataCheck = DataCheck("ShareSendQueue", ListData, TableData, true, "01");

            var Vdb = new List<ShareSendQueueInsertResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareSendQueueInsertResult();
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
        /// <param name="ShareSendQueueInsert"></param>
        /// <returns>ShareSendQueueInsertResult</returns>
        public List<ShareSendQueueInsertResult> ShareSendQueueInsert(ShareSendQueueInsertRow ShareSendQueueInsert)
        {
            var SubmitChanges = ShareSendQueueInsert.SubmitChanges;
            var DataCheck = ShareSendQueueInsert.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0101000001");  //新增成功
            ListShareDisplayMessageCode.Add("0102000001");  //新增失敗

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareSendQueueInsertResult>();
            ShareSendQueueInsertResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareSendQueueInsertCheck(ShareSendQueueInsert);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            foreach (var ItemShareSendQueue in ShareSendQueueInsert.ListShareSendQueue)
            {
                var rShareSendQueue = new ShareSendQueue();
                rShareSendQueue.Code = ItemShareSendQueue.Code;
                rShareSendQueue.SystemCode = ItemShareSendQueue.SystemCode;
                rShareSendQueue.SendTypeCode = ItemShareSendQueue.SendTypeCode;
                rShareSendQueue.FromAddr = ItemShareSendQueue.FromAddr;
                rShareSendQueue.FromName = ItemShareSendQueue.FromName;
                rShareSendQueue.ToAddr = ItemShareSendQueue.ToAddr;
                rShareSendQueue.ToName = ItemShareSendQueue.ToName;
                rShareSendQueue.ToAddrCopy = ItemShareSendQueue.ToAddrCopy;
                rShareSendQueue.ToNameCopy = ItemShareSendQueue.ToNameCopy;
                rShareSendQueue.ToAddrConfidential = ItemShareSendQueue.ToAddrConfidential;
                rShareSendQueue.ToNameConfidential = ItemShareSendQueue.ToNameConfidential;
                rShareSendQueue.Subject = ItemShareSendQueue.Subject;
                rShareSendQueue.Body = ItemShareSendQueue.Body;
                rShareSendQueue.Retry = ItemShareSendQueue.Retry;
                rShareSendQueue.Sucess = ItemShareSendQueue.Sucess;
                rShareSendQueue.Suspend = ItemShareSendQueue.Suspend;
                rShareSendQueue.DateSend = ItemShareSendQueue.DateSend;
                rShareSendQueue.Note = ItemShareSendQueue.Note;
                rShareSendQueue.Sort = ItemShareSendQueue.Sort;
                rShareSendQueue.Status = ItemShareSendQueue.Status;
                rShareSendQueue.InsertMan = ShareSendQueueInsert.InsertMan;
                rShareSendQueue.InsertDate = _NowDate;
                rShareSendQueue.UpdateMan = ShareSendQueueInsert.InsertMan;
                rShareSendQueue.UpdateDate = _NowDate;
                dcShare.ShareSendQueue.InsertOnSubmit(rShareSendQueue);
            }

            try
            {
                rVdb = new ShareSendQueueInsertResult();
                rVdb.Code = "0101000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareSendQueueInsert), ShareSendQueueInsert.AppName, ShareSendQueueInsert.IpAddress, ShareSendQueueInsert.InsertMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareSendQueueInsertResult();
                rVdb.Code = "0102000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "新增失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareSendQueueInsert.AppName, ShareSendQueueInsert.IpAddress, ShareSendQueueInsert.InsertMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 修改欄位設定檢查
        /// </summary>
        /// <param name="ShareSendQueueUpdate"></param>
        /// <returns>List ShareSendQueueUpdateResult</returns>
        public List<ShareSendQueueUpdateResult> ShareSendQueueUpdateCheck(ShareSendQueueUpdateRow ShareSendQueueUpdate)
        {
            var ListData = DataTrans.ToDataTable(ShareSendQueueUpdate.ListShareSendQueue);

            //主鍵
            var ListAutoKey = ShareSendQueueUpdate.ListShareSendQueue.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareSendQueueUpdate.ListShareSendQueue.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareSendQueueUpdate.ListShareSendQueue.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareSendQueue = (from c in dcShare.ShareSendQueue
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareSendQueue);

            var ListDataCheck = DataCheck("ShareSendQueue", ListData, TableData, true, "02");

            var Vdb = new List<ShareSendQueueUpdateResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareSendQueueUpdateResult();
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
        /// <param name="ShareSendQueueUpdate"></param>
        /// <returns>ShareSendQueueUpdateResult</returns>
        public List<ShareSendQueueUpdateResult> ShareSendQueueUpdate(ShareSendQueueUpdateRow ShareSendQueueUpdate)
        {
            var SubmitChanges = ShareSendQueueUpdate.SubmitChanges;
            var DataCheck = ShareSendQueueUpdate.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0201000001");  //修改成功
            ListShareDisplayMessageCode.Add("0202000001");  //修改失敗
            ListShareDisplayMessageCode.Add("0202000002");  //修改失敗，找不到可修改的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareSendQueueUpdateResult>();
            ShareSendQueueUpdateResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareSendQueueUpdateCheck(ShareSendQueueUpdate);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareSendQueueUpdate.ListShareSendQueue.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareSendQueueUpdate.ListShareSendQueue.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareSendQueueUpdate.ListShareSendQueue.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareSendQueue = (from c in dcShare.ShareSendQueue
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemShareSendQueue in ShareSendQueueUpdate.ListShareSendQueue)
            {
                var AutoKey = ItemShareSendQueue.AutoKey;
                var Code = ItemShareSendQueue.Code;
                var Key = ItemShareSendQueue.Code;

                var rShareSendQueue = (from c in rsShareSendQueue
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rShareSendQueue != null)
                {
                    rShareSendQueue.SystemCode = ItemShareSendQueue.SystemCode;
                    rShareSendQueue.SendTypeCode = ItemShareSendQueue.SendTypeCode;
                    rShareSendQueue.FromAddr = ItemShareSendQueue.FromAddr;
                    rShareSendQueue.FromName = ItemShareSendQueue.FromName;
                    rShareSendQueue.ToAddr = ItemShareSendQueue.ToAddr;
                    rShareSendQueue.ToName = ItemShareSendQueue.ToName;
                    rShareSendQueue.ToAddrCopy = ItemShareSendQueue.ToAddrCopy;
                    rShareSendQueue.ToNameCopy = ItemShareSendQueue.ToNameCopy;
                    rShareSendQueue.ToAddrConfidential = ItemShareSendQueue.ToAddrConfidential;
                    rShareSendQueue.ToNameConfidential = ItemShareSendQueue.ToNameConfidential;
                    rShareSendQueue.Subject = ItemShareSendQueue.Subject;
                    rShareSendQueue.Body = ItemShareSendQueue.Body;
                    rShareSendQueue.Retry = ItemShareSendQueue.Retry;
                    rShareSendQueue.Sucess = ItemShareSendQueue.Sucess;
                    rShareSendQueue.Suspend = ItemShareSendQueue.Suspend;
                    rShareSendQueue.DateSend = ItemShareSendQueue.DateSend;
                    rShareSendQueue.Note = ItemShareSendQueue.Note;
                    rShareSendQueue.Sort = ItemShareSendQueue.Sort;
                    rShareSendQueue.UpdateMan = ShareSendQueueUpdate.UpdateMan;
                    rShareSendQueue.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareSendQueueUpdateResult();
                    rVdb.Code = "0202000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗，找不到可修改的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareSendQueueUpdate), ShareSendQueueUpdate.AppName, ShareSendQueueUpdate.IpAddress, ShareSendQueueUpdate.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareSendQueueUpdateResult();
                rVdb.Code = "0201000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareSendQueueUpdate), ShareSendQueueUpdate.AppName, ShareSendQueueUpdate.IpAddress, ShareSendQueueUpdate.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareSendQueueUpdateResult();
                rVdb.Code = "0202000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "修改失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareSendQueueUpdate.AppName, ShareSendQueueUpdate.IpAddress, ShareSendQueueUpdate.UpdateMan);
            }

            return Vdb;
        }

        /// <summary>
        /// 刪除欄位設定檢查
        /// </summary>
        /// <param name="ShareSendQueueDelete"></param>
        /// <returns>List ShareSendQueueDeleteResult</returns>
        public List<ShareSendQueueDeleteResult> ShareSendQueueDeleteCheck(ShareSendQueueDeleteRow ShareSendQueueDelete)
        {
            var ListData = DataTrans.ToDataTable(ShareSendQueueDelete.ListShareSendQueue);

            //主鍵
            var ListAutoKey = ShareSendQueueDelete.ListShareSendQueue.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareSendQueueDelete.ListShareSendQueue.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareSendQueueDelete.ListShareSendQueue.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareSendQueue = (from c in dcShare.ShareSendQueue
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            var TableData = DataTrans.ToDataTable(rsShareSendQueue);

            var ListDataCheck = DataCheck("ShareSendQueue", ListData, TableData, true, "03");

            var Vdb = new List<ShareSendQueueDeleteResult>();
            foreach (var ItemDataCheck in ListDataCheck)
            {
                var rVdb = new ShareSendQueueDeleteResult();
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
        /// <param name="ShareSendQueueDelete"></param>
        /// <returns>ShareSendQueueDeleteResult</returns>
        public List<ShareSendQueueDeleteResult> ShareSendQueueDelete(ShareSendQueueDeleteRow ShareSendQueueDelete)
        {
            var SubmitChanges = ShareSendQueueDelete.SubmitChanges;
            var DataCheck = ShareSendQueueDelete.DataCheck;

            var ListShareDisplayMessageCode = new List<string>();
            ListShareDisplayMessageCode.Add("0301000001");  //刪除成功
            ListShareDisplayMessageCode.Add("0302000001");  //刪除失敗
            ListShareDisplayMessageCode.Add("0302000002");  //刪除失敗，找不到可刪除的資料，可能主鍵不存在

            var rsShareDisplayMessageContents = MessageShow(ListShareDisplayMessageCode);
            ShareDisplayMessageContentsRow rShareDisplayMessageContents;

            var Vdb = new List<ShareSendQueueDeleteResult>();
            ShareSendQueueDeleteResult rVdb;

            //如果要檢查
            if (DataCheck)
            {
                Vdb = ShareSendQueueDeleteCheck(ShareSendQueueDelete);
                if (Vdb.Any(p => !p.Pass))
                    return Vdb;
            }

            //主鍵
            var ListAutoKey = ShareSendQueueDelete.ListShareSendQueue.Where(p => p.AutoKey > 0).Select(p => p.AutoKey).ToList();
            var ListCode = ShareSendQueueDelete.ListShareSendQueue.Where(p => p.Code.Length > 0).Select(p => p.Code).ToList();
            var ListKey = ShareSendQueueDelete.ListShareSendQueue.Where(p => p.Key.Length > 0).Select(p => p.Key).ToList();

            var rsShareSendQueue = (from c in dcShare.ShareSendQueue
                                   where 1 == 1
                                   && ((ListAutoKey.Count == 0) || (ListAutoKey.Contains(c.AutoKey)))
                                   && ((ListCode.Count == 0) || (ListCode.Contains(c.Code)))
                                   && ((ListKey.Count == 0) || (ListKey.Contains(c.AutoKey.ToString())))
                                   select c).ToList();

            foreach (var ItemShareSendQueue in ShareSendQueueDelete.ListShareSendQueue)
            {
                var AutoKey = ItemShareSendQueue.AutoKey;
                var Code = ItemShareSendQueue.Code;
                var Key = ItemShareSendQueue.Code;

                var rShareSendQueue = (from c in rsShareSendQueue
                                      where 1 == 1
                                      && ((AutoKey == 0) || (c.AutoKey == AutoKey))
                                      && ((Code.Length == 0) || (c.Code == Code))
                                      && ((Key.Length == 0) || (c.Code == Key))
                                      select c).FirstOrDefault();

                if (rShareSendQueue != null)
                {
                    rShareSendQueue.Status = "2";
                    rShareSendQueue.UpdateMan = ShareSendQueueDelete.UpdateMan;
                    rShareSendQueue.UpdateDate = _NowDate;
                }
                else
                {
                    rVdb = new ShareSendQueueDeleteResult();
                    rVdb.Code = "0302000002";
                    rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                    rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗，找不到可刪除的資料，可能主鍵不存在";
                    rVdb.Contents += "-" + Key;
                    rVdb.Pass = true;    //改成警告 針對找到的部份 做部份修改
                    Vdb.Add(rVdb);

                    var oMessageLog = MessageLog("2", rVdb.Contents, JsonConvert.SerializeObject(ShareSendQueueDelete), ShareSendQueueDelete.AppName, ShareSendQueueDelete.IpAddress, ShareSendQueueDelete.UpdateMan);
                }
            }

            try
            {
                rVdb = new ShareSendQueueDeleteResult();
                rVdb.Code = "0301000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除成功";
                rVdb.Pass = true;

                var oMessageLog = MessageLog("0", rVdb.Contents, JsonConvert.SerializeObject(ShareSendQueueDelete), ShareSendQueueDelete.AppName, ShareSendQueueDelete.IpAddress, ShareSendQueueDelete.UpdateMan);

                if (SubmitChanges)
                {
                    dcShare.SubmitChanges();
                    Vdb.Add(rVdb);
                }
            }
            catch (Exception ex)
            {
                rVdb = new ShareSendQueueDeleteResult();
                rVdb.Code = "0302000001";
                rShareDisplayMessageContents = rsShareDisplayMessageContents.FirstOrDefault(p => p.Code == rVdb.Code);
                rVdb.Contents = rShareDisplayMessageContents?.Contents ?? "刪除失敗";
                rVdb.SystemContents = ex;
                rVdb.Pass = false;
                Vdb.Add(rVdb);

                var oMessageLog = MessageLog("3", rVdb.Contents, ex.ToString(), ShareSendQueueDelete.AppName, ShareSendQueueDelete.IpAddress, ShareSendQueueDelete.UpdateMan);
            }

            return Vdb;
        }
    }
}