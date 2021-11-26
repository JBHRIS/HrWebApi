using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
namespace Repo
{
    public class NotifyMsgDetailRepo
    {        
        public dcTrainingDataContext dc { get; set; }
        public NotifyMsgDetailRepo()
        {
            dc = new dcTrainingDataContext();
        }

        public NotifyMsgDetailRepo(dcTrainingDataContext o)
        {
            dc = o;
        }

        public void Add(NotifyMsgDetail o)
        {
            dc.NotifyMsgDetail.InsertOnSubmit(o);
        }

        public void Delete(NotifyMsgDetail o)
        {
            DcHelper.Detach(o);
            dc.NotifyMsgDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.NotifyMsgDetail.DeleteOnSubmit(o);
        }

        public void Update(NotifyMsgDetail o)
        {
            DcHelper.Detach(o);
            dc.NotifyMsgDetail.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }      

        public void Save()
        {
            dc.SubmitChanges();
        }

        public NotifyMsgDetail GetByPK(string pk)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.NotifyMsgDetail
                        where c.Guid==pk
                        select c).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get by 對象、對象類型、Between DateB and DateE
        /// </summary>
        /// <param name="Atarget"></param>
        /// <param name="AtargetType"></param>
        /// <param name="AdateB"></param>
        /// <param name="AdateE"></param>
        /// <returns></returns>
        public List<NotifyMsgDetail> GetByTargetDateRange(string Atarget ,NotifyTargetTypeEnum AtargetType ,DateTime AbDatetime , DateTime AeDdatetime)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                ldc.Log = new DebuggerWriter();
                var list= (from c in ldc.NotifyMsgDetail
                        where c.NotifyTarget == Atarget &&
                        c.NotifyTargetType == Enum.GetName(typeof(NotifyTargetTypeEnum) , AtargetType) &&
                        (
                        (c.NotifyAdate >= AbDatetime && c.NotifyAdate <= AeDdatetime && c.NotifyDdate==null) || 
                          (c.NotifyAdate <= AeDdatetime && c.NotifyDdate >= AbDatetime)
                        )
                        && !c.IsBbsChecked
                        && c.NotifyMsg != null
                        select c).ToList();
                return list;
            }
        }


/// <summary>
        /// Get by 對象、對象類型、通知Type、Between DateB and DateE
/// </summary>
/// <param name="Atarget"></param>
/// <param name="AtargetType"></param>
/// <param name="Atype"></param>
/// <param name="AbDatetime"></param>
/// <param name="AeDdatetime"></param>
/// <returns></returns>
        public List<NotifyMsgDetail> GetByTargetDateRange(string Atarget, NotifyTargetTypeEnum AtargetType,NotifyTypeEnum Atype, DateTime AbDatetime, DateTime AeDdatetime)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                ldc.Log = new DebuggerWriter();
                var list = (from c in ldc.NotifyMsgDetail
                            where c.NotifyTarget == Atarget &&
                            c.NotifyTargetType == Enum.GetName(typeof(NotifyTargetTypeEnum), AtargetType) &&
                            (
                            (c.NotifyAdate >= AbDatetime && c.NotifyAdate <= AeDdatetime && c.NotifyDdate == null) ||
                              (c.NotifyAdate <= AeDdatetime && c.NotifyDdate >= AbDatetime)
                            )
                            && c.NotifyTypeCode == Enum.GetName(typeof(NotifyTypeEnum), Atype)
                            && c.NotifyMsg !=null
                            && !c.IsBbsChecked
                            select c).ToList();
                return list;
            }
        }

        public List<NotifyMsgDetail> GetByEmailUnSent(string Atarget, NotifyTargetTypeEnum AtargetType, DateTime AdateB, DateTime AdateE)
        {
                    
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.NotifyMsgDetail
                        where c.NotifyTarget == Atarget &&
                        c.NotifyTargetType == Enum.GetName(typeof(NotifyTargetTypeEnum), AtargetType) &&
                        c.NotifyAdate >= AdateB &&
                        c.NotifyAdate <= AdateE
                        select c).ToList();
            }

        }
    }
}
