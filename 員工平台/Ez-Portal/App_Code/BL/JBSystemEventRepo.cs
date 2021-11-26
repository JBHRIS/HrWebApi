using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using JBHRModel;
namespace BL
{
    public class JBSystemEventRepo
    {        
        public JBHRModelDataContext dc { get; set; }
        private JBSystemEventTriggerMsgRepo etmRepo = new JBSystemEventTriggerMsgRepo();
        public JBSystemEventRepo()
        {
            dc = new JBHRModelDataContext();
        }

        public JBSystemEventRepo(JBHRModelDataContext o)
        {
            dc = o;
        }

        public void Add(JBSystemEvent o)
        {
            dc.JBSystemEvent.InsertOnSubmit(o);
        }

        public void Delete(JBSystemEvent o)
        {
            DcHelper.Detach(o);
            dc.JBSystemEvent.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.JBSystemEvent.DeleteOnSubmit(o);
        }

        public void Update(JBSystemEvent o)
        {
            DcHelper.Detach(o);
            dc.JBSystemEvent.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }      

        public void Save()
        {
            dc.SubmitChanges();
        }

        /// <summary>
        /// 取得 By SystemEvent Code
        /// </summary>
        /// <param name="Acode"></param>
        /// <returns></returns>
        public JBSystemEvent GetByCode(string Acode)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.JBSystemEvent
                        where c.Code == Acode
                        select c).FirstOrDefault();
            }
        }

        /// <summary>
        /// 觸發通知訊息
        /// </summary>
        /// <param name="Aobj">哪個事件物件</param>
        /// <param name="Atitle">傳入訊息Title，使用範本預設請代null</param>
        /// <param name="Amessage">傳入訊息Message，使用範本預設請代null</param>
        /// <param name="AprogramName">觸發程式名稱</param>
        /// <param name="AfilePathList">附件路徑List，如無復建請代null</param>
        /// <returns>回傳觸發幾個通知訊息</returns>
        public int Trigger(NotifyMsgTriggerDto Avalue)
        {
            int result = 0;
            JBSystemEventRepo seRepo = new JBSystemEventRepo();
            var seObj = seRepo.GetByCode(Avalue.JbSystemEventCode);
            if (seObj == null)
                return result;
            
            List<JBSystemEventTriggerMsg> list = etmRepo.GetBySystemEventGuidEnable(seObj.Guid);

            foreach (var t in list)
            {
                NotifyMsgFacade msgFacadeObj = new NotifyMsgFacade();
                if (msgFacadeObj.LoadById(t.NotifyMsgTplGuid))
                {
                    NotifyMsgFacade msgObj = new NotifyMsgFacade();
                    msgObj.NotifyAdate = DateTime.Now;
                    //if (msgFacadeObj.NotifyDdateTimeSpan.HasValue)
                    //    msgObj.NotifyDdate = DateTime.Now.AddDays(msgFacadeObj.NotifyDdateTimeSpan.Value);
                    
                    msgObj.NeedCheckBbs = msgFacadeObj.NeedCheckBbs;
                    msgObj.SourceProgram = Avalue.ProgramName;
                    msgObj.SourceSystem = seObj.SystemCode;

                    if (Avalue.Title == null)
                        msgObj.Title = msgFacadeObj.Title;
                    else
                        msgObj.Title = Avalue.Title;

                    if (Avalue.Message == null)
                        msgObj.Message = msgFacadeObj.Message;
                    else
                        msgObj.Message = Avalue.Message;


                    foreach (var c in msgFacadeObj.NotifyMsgTargetTypeList)
                    {
                        NotifyMsgTargetTypeFacade ttf = new NotifyMsgTargetTypeFacade();
                        ttf.NotifyTarget = c.NotifyTarget;
                        ttf.NotifyTargetType = c.NotifyTargetType.Value;
                        ttf.NotifyTypeList = c.NotifyTypeList;
                        msgObj.NotifyMsgTargetTypeList.Add(ttf);
                    }

                    if (Avalue.FilePathList != null)
                    {
                        foreach (var f in Avalue.FilePathList)
                            msgObj.AddAttachmentFile(f);
                    }

                    msgObj.Save();
                    msgObj.Process();
                }
                result++;
            }
            return result;
        }


        /// <summary>
        /// 是否有值
        /// </summary>
        /// <param name="Acode"></param>
        /// <returns></returns>
        public bool IsHaveValue(string Acode)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.JBSystemEvent
                        where c.Code == Acode
                        select c).Any();
            }
        }
    }
}
