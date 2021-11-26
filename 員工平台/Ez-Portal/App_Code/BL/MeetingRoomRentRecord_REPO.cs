using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JBHRModel;
using System.Data.Linq;


namespace BL
{
    /// <summary>
    /// MeetingRoomRentRecord 的摘要描述
    /// </summary>
    public class MeetingRoomRentRecord_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public MeetingRoomRentRecord_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public MeetingRoomRentRecord_REPO()
        {
            dc = new JBHRModelDataContext();
        }


        public void Add(MeetingRoomRentRecord o)
        {
            dc.MeetingRoomRentRecord.InsertOnSubmit(o);
        }

        public void Update(MeetingRoomRentRecord o)
        {
            DcHelper.Detach(o);
            dc.MeetingRoomRentRecord.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public MeetingRoomRentRecord GetByPk(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.MeetingRoomRentRecord
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public List<MeetingRoomRentRecord> GetCycleItemsByDateMoreThan(MeetingRoomRentRecord obj)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.MeetingRoomRentRecord
                        where c.GroupCode == obj.GroupCode && c.EndDateTime >= obj.EndDateTime
                        select c).ToList();
            }
        }


        public MeetingRoomRentRecord GetByPk_Dlo(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<MeetingRoomRentRecord>(l => l.BASE);
                dlo.LoadWith<MeetingRoomRentRecord>(l => l.MeetingRoom);
                dlo.LoadWith<MeetingRoomRentRecord>(l => l.MeetingRoomRentAttendee);
                dlo.LoadWith<MeetingRoomRentAttendee>(l => l.BASE);
                ldc.LoadOptions = dlo;

                return (from c in ldc.MeetingRoomRentRecord
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public List<MeetingRoomRentRecord> GetByDate(DateTime d)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.MeetingRoomRentRecord
                        where c.StartDateTime >= d && c.StartDateTime < d.AddDays(1)
                        select c).ToList();
            }
        }

        public List<MeetingRoomRentRecord> GetByDate(DateTime d, int roomId, bool isCancel)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.MeetingRoomRentRecord
                        where c.StartDateTime >= d && c.StartDateTime < d.AddDays(1)
                        && c.MeetingRoomId == roomId && c.Cancel == isCancel
                        select c).ToList();
            }
        }

        public List<MeetingRoomRentRecord> GetByDate(DateTime bDate, DateTime eDate, int roomId, bool isCancel)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.MeetingRoomRentRecord
                        where c.StartDateTime >= bDate && c.StartDateTime < eDate.AddDays(1)
                        && c.MeetingRoomId == roomId && c.Cancel == isCancel
                        select c).ToList();
            }
        }


        public List<MeetingRoomRentRecord> GetByDate_Dlo(DateTime bDate, DateTime eDate, int roomId, bool isCancel)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<MeetingRoomRentRecord>(l => l.BASE);
                dlo.LoadWith<MeetingRoomRentRecord>(l => l.MeetingRoom);
                ldc.LoadOptions = dlo;

                return (from c in ldc.MeetingRoomRentRecord
                        where c.StartDateTime >= bDate && c.StartDateTime < eDate.AddDays(1)
                        && c.MeetingRoomId == roomId && c.Cancel == isCancel
                        select c).ToList();
            }
        }

        public List<MeetingRoomRentRecord> GetByDate_Dlo(DateTime bDate, DateTime eDate, bool isCancel)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<MeetingRoomRentRecord>(l => l.BASE);
                dlo.LoadWith<MeetingRoomRentRecord>(l => l.MeetingRoom);
                ldc.LoadOptions = dlo;

                return (from c in ldc.MeetingRoomRentRecord
                        where c.StartDateTime >= bDate && c.StartDateTime < eDate.AddDays(1)
                        && c.Cancel == isCancel
                        select c).ToList();
            }
        }

        public bool IsUsed(DateTime bDate, DateTime eDate, int roomId)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                var result = (from c in ldc.MeetingRoomRentRecord
                              where c.StartDateTime < eDate && c.EndDateTime > bDate
                              && c.MeetingRoomId == roomId
                              && c.Cancel == false
                              select c).FirstOrDefault();

                if (result == null)
                    return false;
                else
                    return true;
            }
        }

        public bool IsUsedExceptSelf(DateTime bDate, DateTime eDate, int roomId,int recordId )
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                var result = (from c in ldc.MeetingRoomRentRecord
                              where c.StartDateTime < eDate && c.EndDateTime > bDate
                              && c.MeetingRoomId == roomId
                              && c.Cancel == false
                              && c.Id != recordId 
                              select c).FirstOrDefault();

                if (result == null)
                    return false;
                else
                    return true;
            }
        }
    }


}