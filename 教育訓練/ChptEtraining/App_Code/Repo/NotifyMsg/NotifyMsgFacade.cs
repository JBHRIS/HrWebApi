using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace Repo
{
    public class NotifyMsgFacade
    {
        public string Guid { get; set; }
        public string SourceSystem { get; set; }
        public string SourceProgram { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime? NotifyAdate { get; set; }
        public DateTime? NotifyDdate { get; set; }
        public bool NeedCheckBbs { get; set; }
        public bool IsProcessed { get; set; }
        public List<NotifyMsgTargetTypeFacade> NotifyMsgTargetTypeList { get; set; }
        //public List<byte[]> NotifyMsgAttachment { get; set; }
        public List<NotifyMsgAttachmentFacade> NotifyMsgAttachmentList { get; set; }

        //需要處理的訊息發送類別
        //public const string[] NeedProcessTypeArr = new string[] { Enum.GetName(typeof(NotifyTypeEnum), NotifyTypeEnum.Email) };

        public NotifyMsgFacade()
        {
            NotifyMsgTargetTypeList = new List<NotifyMsgTargetTypeFacade>();
            NotifyMsgAttachmentList = new List<NotifyMsgAttachmentFacade>();
            Guid = System.Guid.NewGuid().ToString();
            IsProcessed = false;
        }

        /// <summary>
        /// 從範本中載入
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool LoadFromTemplateByCode(string code)
        {
            //To Do

            return false;
        }


        public bool LoadById(string Aid)
        {
            dcTrainingDataContext dc = new dcTrainingDataContext();
            //處理發送訊息對象、方式
            NotifyMsgRepo notifyMsgRepo = new NotifyMsgRepo(dc);
            NotifyMsg notifyMsgObj = notifyMsgRepo.GetByPk_DLO(Aid);

            if (notifyMsgObj == null)
                return false;
            else
            {
                NotifyMsgTargetTypeList.Clear();
                NotifyMsgAttachmentList.Clear();

                //load 附件
                foreach (var a in notifyMsgObj.NotifyMsgAttachment)
                {
                    NotifyMsgAttachmentFacade o = new NotifyMsgAttachmentFacade();
                    o.FileName = a.FileName;
                    o.FileStream = a.FileStream.ToArray();
                    o.Guid = a.Guid;
                    NotifyMsgAttachmentList.Add(o);
                }

                //load通知對象、及通知方式                
                foreach (var tar in notifyMsgObj.NotifyMsgTarget)
                {
                    NotifyMsgTargetTypeFacade o = new NotifyMsgTargetTypeFacade();
                    o.NotifyTarget = tar.NotifyTarget;
                    o.NotifyTargetType = (NotifyTargetTypeEnum)Enum.Parse(typeof(NotifyTargetTypeEnum), tar.NotifyTargetTypeCode);
                    o.Guid = tar.Guid;

                    foreach (var tt in tar.NotifyMsgTargetType)
                    {
                        o.NotifyTypeList.Add((NotifyTypeEnum)Enum.Parse(typeof(NotifyTypeEnum), tt.NotifyTypeCode));
                    }

                    NotifyMsgTargetTypeList.Add(o);
                }

                //表單主體
                Guid = notifyMsgObj.Guid;
                SourceSystem = notifyMsgObj.SourceSystem;
                SourceProgram = notifyMsgObj.SourceProgram;
                Title = notifyMsgObj.Title;
                Message = notifyMsgObj.Message;
                NotifyAdate = notifyMsgObj.NotifyAdate;
                NotifyDdate = notifyMsgObj.NotifyDdate;
                NeedCheckBbs = notifyMsgObj.NeedCheckBbs;
                IsProcessed = notifyMsgObj.IsProcessed;

                string msg="";
                if (IsValidData(out msg))
                    return true;
                else
                    return false;
            }
        }




        //儲存此單
        public void Save()
        {
            dcTrainingDataContext dc = new dcTrainingDataContext();
            NotifyMsgRepo notifyMsgRepo = new NotifyMsgRepo(dc);

            NotifyMsg notifyMsgObj = new NotifyMsg();
            notifyMsgObj.Guid = Guid;
            notifyMsgObj.IsProcessed = false;
            notifyMsgObj.Message = Message;
            notifyMsgObj.NeedCheckBbs = NeedCheckBbs;
            notifyMsgObj.NotifyAdate = NotifyAdate.Value;

            if (NotifyDdate.HasValue)
                notifyMsgObj.NotifyDdate = NotifyDdate.Value;
            else
                notifyMsgObj.NotifyDdate = null;

            notifyMsgObj.SourceProgram = SourceProgram;
            notifyMsgObj.SourceSystem = SourceSystem;
            notifyMsgObj.Title = Title;
            notifyMsgObj.CreatedDate = DateTime.Now;
            notifyMsgRepo.Add(notifyMsgObj);

            //處理發送訊息對象、方式
            NotifyMsgTargetRepo notifyMsgTargetRepo = new NotifyMsgTargetRepo(dc);
            NotifyMsgTargetTypeRepo notifyMsgTargetTypeRepo = new NotifyMsgTargetTypeRepo(dc);
            foreach (var item in NotifyMsgTargetTypeList)
            {
                NotifyMsgTarget notifyMsgTargetObj = new NotifyMsgTarget();
                notifyMsgTargetObj.Guid = item.Guid;
                notifyMsgTargetObj.NotifyMsgGuid = Guid;
                notifyMsgTargetObj.NotifyTarget = item.NotifyTarget;
                notifyMsgTargetObj.NotifyTargetTypeCode = Enum.GetName(typeof(NotifyTargetTypeEnum), item.NotifyTargetType);
                notifyMsgTargetRepo.Add(notifyMsgTargetObj);

                foreach (var t in item.NotifyTypeList)
                {
                    NotifyMsgTargetType notifyMsgTargetTypeObj = new NotifyMsgTargetType();
                    notifyMsgTargetTypeObj.NotifyMsgTargetGuid = item.Guid;
                    notifyMsgTargetTypeObj.NotifyTypeCode = Enum.GetName(typeof(NotifyTypeEnum), t);
                    notifyMsgTargetTypeRepo.Add(notifyMsgTargetTypeObj);
                }
            }

            //處理附件
            NotifyMsgAttachmentRepo notifyMsgAttachmentRepo = new NotifyMsgAttachmentRepo(dc);
            foreach (var f in NotifyMsgAttachmentList)
            {
                NotifyMsgAttachment notifyMsgAttentmentObj = new NotifyMsgAttachment();
                notifyMsgAttentmentObj.Guid = f.Guid;
                notifyMsgAttentmentObj.NotifyMsgGuid = Guid;
                notifyMsgAttentmentObj.FileName = f.FileName;
                notifyMsgAttentmentObj.FileStream = f.FileStream;
                notifyMsgAttachmentRepo.Add(notifyMsgAttentmentObj);
            }

            notifyMsgRepo.Save();
        }

        /// <summary>
        /// 刪除，如果未處理狀態就刪掉，已處理就不刪
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            dcTrainingDataContext dc = new dcTrainingDataContext();
            NotifyMsgRepo notifyMsgRepo = new NotifyMsgRepo(dc);
            NotifyMsg notifyMsgObj = notifyMsgRepo.GetByPkFromDc(Guid);

            if (notifyMsgObj.IsProcessed == true)
                return false;
            else
            {
                NotifyMsg obj = notifyMsgRepo.GetByPkFromDc(Guid);
                dc.NotifyMsgAttachment.DeleteAllOnSubmit(obj.NotifyMsgAttachment);

                foreach (var tar in obj.NotifyMsgTarget)
                {
                    foreach (var tt in tar.NotifyMsgTargetType)
                    {
                        dc.NotifyMsgTargetType.DeleteOnSubmit(tt);
                    }
                    dc.NotifyMsgTarget.DeleteOnSubmit(tar);
                }

                dc.NotifyMsg.DeleteOnSubmit(obj);
                dc.SubmitChanges();
                return true;
            }
        }


        /// <summary>
        /// 加入訊息對象，對象類型、通知方式
        /// </summary>
        /// <param name="Atarget"></param>
        /// <param name="AtargetType"></param>
        /// <param name="AnotifyTypeArr"></param>
        public void AddNotifyMsgTargetType(string Atarget, NotifyTargetTypeEnum AtargetType,
           params NotifyTypeEnum[] AnotifyTypeArr)
        {
            NotifyMsgTargetTypeFacade o = new NotifyMsgTargetTypeFacade();
            o.NotifyTarget = Atarget;
            o.NotifyTargetType = AtargetType;
            o.NotifyTypeList.AddRange(AnotifyTypeArr);
            NotifyMsgTargetTypeList.Add(o);
        }


        /// <summary>
        /// 加入附件
        /// </summary>
        /// <param name="AfileName"></param>
        /// <param name="AfilePath"></param>
        public void AddAttachmentFile(string AfileName, string AfilePath)
        {
            NotifyMsgAttachmentList.Add(new NotifyMsgAttachmentFacade(AfileName, AfilePath));
        }

        /// <summary>
        /// 加入附件，自動幫你擷取檔名
        /// </summary>
        /// <param name="AfileName"></param>
        /// <param name="AfilePath"></param>
        public void AddAttachmentFile(string AfilePath)
        {
            FileInfo fi = new FileInfo(AfilePath);
            NotifyMsgAttachmentList.Add(new NotifyMsgAttachmentFacade(fi.Name, AfilePath));
        }


        /// <summary>
        /// 判斷資料是否正確
        /// </summary>
        /// <param name="Amsg"></param>
        /// <returns></returns>
        public bool IsValidData(out string Amsg)
        {
            Amsg = "";
            if (NotifyAdate == null)
            {
                Amsg = "NotifyAdate必須指定值";
                return false;
            }

            if (SourceProgram == null || SourceSystem == null)
            {
                Amsg = "SourceProgram或SourceSystem必須指定值";
                return false;
            }

            if (NotifyMsgTargetTypeList.Count == 0)
            {
                Amsg = "發送對象必須指定";
                return false;
            }

            foreach (var p in NotifyMsgTargetTypeList)
            {
                if (p.NotifyTarget == null || p.NotifyTargetType == null)
                {
                    Amsg = "發送對象、或發送對象類型必須指定";
                    return false;
                }

                if (p.NotifyTypeList.Count == 0)
                {
                    Amsg = "發送方式必須指定";
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 處理所有需處理的單子
        /// </summary>
        public void ProcessAll()
        {
            NotifyMsgRepo nmRepo = new NotifyMsgRepo();
            List<NotifyMsg> list = nmRepo.GetNeedProcessdNow_DLO();

            foreach (var p in list)
            {
                NotifyMsgFacade nmfObj = new NotifyMsgFacade();
                nmfObj.LoadById(p.Guid);
                nmfObj.Process();
            }
        }

        /// <summary>
        /// 取得訊息通知資料By日期區間，通知對象，通知對象類別
        /// </summary>
        /// <param name="AbDateTime"></param>
        /// <param name="AeDatetime"></param>
        /// <param name="AnotifyTarget"></param>
        /// <param name="AtargetType"></param>
        /// <returns></returns>
        public List<NotifyBoardMsg> GetMsg(DateTime AbDateTime, DateTime AeDatetime, string AnotifyTarget,NotifyTargetTypeEnum AtargetType)
        {
            NotifyMsgDetailRepo msgDtlRepo = new NotifyMsgDetailRepo();
            List<NotifyMsgDetail> list = msgDtlRepo.GetByTargetDateRange(AnotifyTarget, AtargetType, AbDateTime, AeDatetime);

            return (from c in list
                    select new NotifyBoardMsg
                    {
                        Guid = c.Guid,
                        Message = c.Message,
                        NotifyMsgGuid = c.NotifyMsgGuid,
                        NotifyTarget = c.NotifyTarget,
                        NotifytargetType = c.NotifyTargetType,
                        NotifyAdate = c.NotifyAdate,
                        NotifyDdate = c.NotifyDdate,
                        Title = c.Title
                    }).ToList();
        }



        //立即處理此單
        public void Process()
        {
            if (!IsProcessed)
            {
                dispatch();

                if(NotifyAdate.Value <= DateTime.Now)
                    processMail();
            }
        }

        /// <summary>
        /// 處理email單據
        /// </summary>
        private void processMail()
        {
            NotifyMsgRepo notifyMsgRepo = new NotifyMsgRepo();
            NotifyMsg notifyMsgObj = notifyMsgRepo.GetByPkNotifyType_DLO(Guid, Enum.GetName(typeof(NotifyTypeEnum), NotifyTypeEnum.Email));

            dcTrainingDataContext dc = new dcTrainingDataContext();
            NotifyMsgDetailRepo notifyMsgDetailRepo = new NotifyMsgDetailRepo(dc);

            foreach (var d in notifyMsgObj.NotifyMsgDetail)
            {
                if (!d.IsMailSent && d.ErrorMsg == null)
                {
                    try
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.jbjob.com.tw";
                        CredentialCache myCache = new CredentialCache();
                        myCache.Add("smtp.jbjob.com.tw", 25, "login", new NetworkCredential("kukoc@jbjob.com.tw", "680203"));
                        smtp.Credentials = myCache;
                        MailMessage message = new MailMessage();
                        message.Subject = d.Title;
                        message.Body = d.Message;
                        message.To.Add(new MailAddress(d.MailTo));
                        message.From = new MailAddress("kukoc@jbjob.com.tw");

                        foreach (var a in d.NotifyMsg.NotifyMsgAttachment)
                        {
                            MemoryStream ms = new MemoryStream(a.FileStream.ToArray());
                            message.Attachments.Add(new Attachment(ms, a.FileName));
                        }



                        smtp.Send(message);
                        d.IsMailSent = true;
                    }
                    catch (Exception ex)
                    {
                        d.ErrorMsg = ex.Message;
                    }

                    notifyMsgDetailRepo.Update(d);
                    notifyMsgDetailRepo.Save();
                }
            }
        }



        private void dispatch()
        {
            dcTrainingDataContext dc = new dcTrainingDataContext();
            //處理發送訊息對象、方式
            NotifyMsgDetailRepo notifyMsgDetailRepo = new NotifyMsgDetailRepo(dc);
            BASE_Repo baseRepo = new BASE_Repo();

            foreach (var item in NotifyMsgTargetTypeList)
            {
                //固定的init Detail資料
                NotifyMsgDetail notifyMsgDetailObj = new NotifyMsgDetail();
                notifyMsgDetailObj.CreatedDate = DateTime.Now;
                notifyMsgDetailObj.Guid = System.Guid.NewGuid().ToString();
                notifyMsgDetailObj.NotifyAdate = NotifyAdate.Value;
                notifyMsgDetailObj.NotifyMsgGuid = Guid;
                notifyMsgDetailObj.NotifyTargetType = Enum.GetName(typeof(NotifyTargetTypeEnum), item.NotifyTargetType.Value);
                notifyMsgDetailObj.NotifyTarget = item.NotifyTarget;
                notifyMsgDetailObj.Title = Title;
                notifyMsgDetailObj.Message = Message;

                if (NotifyDdate.HasValue)
                    notifyMsgDetailObj.NotifyDdate = NotifyDdate.Value;
                else
                    notifyMsgDetailObj.NotifyDdate = null;

                //如果選擇單一員工
                //if (item.NotifyTargetType == NotifyTargetTypeEnum.Emp)
                //{
                    foreach (var t in item.NotifyTypeList)
                    {
                        //紀錄發送方式
                        notifyMsgDetailObj.NotifyTypeCode = Enum.GetName(typeof(NotifyTypeEnum), t);

                        if (t == NotifyTypeEnum.Board)
                        {
                        }
                        else if (t == NotifyTypeEnum.Email)
                        {
                            BASE baseObj = baseRepo.GetByNobr(item.NotifyTarget);
                            if (baseObj == null)
                            {
                                notifyMsgDetailObj.ErrorMsg = "無此員工";
                            }
                            else
                            {
                                if (!Util.Util.IsValidEmail(baseObj.EMAIL))
                                {
                                    
                                    notifyMsgDetailObj.ErrorMsg = "此員工Email不正確";
                                }
                                else
                                {
                                    notifyMsgDetailObj.MailTo = baseObj.EMAIL;
                                }
                            }
                        }

                        notifyMsgDetailRepo.Add(notifyMsgDetailObj);
                    }
                //}
            }

            NotifyMsgRepo notifyMsgRepo = new NotifyMsgRepo(dc);
            NotifyMsg notifyMsgObj = notifyMsgRepo.GetByPk(Guid);

            notifyMsgObj.IsProcessed = true;
            notifyMsgRepo.Update(notifyMsgObj);
            notifyMsgDetailRepo.Save();

        }


        //儲存並立即處理此單
        public void SaveAndProcess()
        {
            Save();
            Process();
        }
    }
}
