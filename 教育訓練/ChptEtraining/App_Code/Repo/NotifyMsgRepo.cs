using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Common;
namespace Repo
{
    public class NotifyMsgRepo
    {        
        public dcTrainingDataContext dc { get; set; }
        public NotifyMsgRepo()
        {
            dc = new dcTrainingDataContext();
        }

        public NotifyMsgRepo(dcTrainingDataContext o)
        {
            dc = o;
        }

        public NotifyMsgRepo(DbConnection conn)
        {
            dc = new dcTrainingDataContext(conn);                     
        }

        public void Add(NotifyMsg o)
        {
            dc.NotifyMsg.InsertOnSubmit(o);
        }

        public void Delete(NotifyMsg o)
        {
            DcHelper.Detach(o);
            dc.NotifyMsg.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.NotifyMsg.DeleteOnSubmit(o);
        }

        public void Update(NotifyMsg o)
        {
            DcHelper.Detach(o);
            dc.NotifyMsg.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }      

        public void Save()
        {
            dc.SubmitChanges();
        }

        public NotifyMsg GetByPk(string Apk)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.NotifyMsg
                        where c.Guid==Apk
                        select c).FirstOrDefault();
            }
        }


        public NotifyMsg GetByPk_DLO(string Apk)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();                                               
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgAttachment);
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgDetail);
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgTarget);
                dlo.LoadWith<NotifyMsgTarget>(l => l.NotifyMsgTargetType);
                dlo.LoadWith<NotifyMsgTargetType>(l => l.NotifyType);
                ldc.LoadOptions = dlo;
                ldc.Log = new DebuggerWriter();
                var result =(from c in ldc.NotifyMsg
                        where c.Guid == Apk
                        select c).FirstOrDefault();

                return result;
            }
        }

        /// <summary>
        /// 取得未處理的單子
        /// </summary>
        /// <returns></returns>
        public List<NotifyMsg> GetByUnprocessd_DLO()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgAttachment);
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgDetail);
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgTarget);
                dlo.LoadWith<NotifyMsgTarget>(l => l.NotifyMsgTargetType);
                dlo.LoadWith<NotifyMsgTargetType>(l => l.NotifyType);
                ldc.LoadOptions = dlo;

                return (from c in ldc.NotifyMsg
                        where c.IsProcessed == false                        
                        select c).ToList();
            }
        }


        /// <summary>
        /// 取得需處理的單子
        /// </summary>
        /// <returns></returns>
        public List<NotifyMsg> GetNeedProcessdNow_DLO()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgAttachment);
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgDetail);
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgTarget);
                dlo.LoadWith<NotifyMsgTarget>(l => l.NotifyMsgTargetType);
                dlo.LoadWith<NotifyMsgTargetType>(l => l.NotifyType);
                ldc.LoadOptions = dlo;

                return (from c in ldc.NotifyMsg
                        where c.IsProcessed == false
                        && c.NotifyAdate <= DateTime.Now
                        select c).ToList();
            }
        }


        public List<NotifyMsg> GetMsg_Dlo(DateTime AbDateTime, DateTime AeDatetime, string AnotifyTarget, string AtargetType)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgAttachment);
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgDetail);
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgTarget);
                dlo.LoadWith<NotifyMsgTarget>(l => l.NotifyMsgTargetType);
                dlo.LoadWith<NotifyMsgTargetType>(l => l.NotifyType);
                ldc.LoadOptions = dlo;
                ldc.Log = new DebuggerWriter();
                var result= (from c in ldc.NotifyMsg
                        where c.NotifyAdate >= AbDateTime 
                        && c.NotifyAdate <= AeDatetime
                        && c.NotifyMsgTarget.Any(p=>p.NotifyTarget==AnotifyTarget && p.NotifyTargetType.NotifyTargetTypeCode==AtargetType)
                        select c).ToList();
                return result;
            }
        }



        /// <summary>
        /// 抓取單子，只抓取Detail固定的發送方式
        /// </summary>
        /// <param name="Apk"></param>
        /// <param name="notifyType"></param>
        /// <returns></returns>
        public NotifyMsg GetByPkNotifyType_DLO(string Apk,string notifyType)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgAttachment);
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgDetail);
                dlo.AssociateWith<NotifyMsg>(a => a.NotifyMsgDetail.Where(d => d.NotifyTypeCode == notifyType));
                dlo.LoadWith<NotifyMsg>(l => l.NotifyMsgTarget);
                dlo.LoadWith<NotifyMsgTarget>(l => l.NotifyMsgTargetType);
                dlo.LoadWith<NotifyMsgTargetType>(l => l.NotifyType);                
                //dlo.AssociateWith<NotifyMsg>(a=>a.NotifyMsgTarget.Where(t=>t.NotifyTargetTypeCode==notifyType));
                //dlo.AssociateWith<NotifyMsgTargetType>(a=>a.NotifyTypeCode.Equals(notifyType));
                ldc.LoadOptions = dlo;

                return (from c in ldc.NotifyMsg
                        where c.Guid == Apk                        
                        select c).FirstOrDefault();
            }
        }



        public NotifyMsg GetByPkFromDc(string Apk)
        {
                return (from c in dc.NotifyMsg
                        where c.Guid==Apk
                        select c).FirstOrDefault();
            
        }

    }
}
