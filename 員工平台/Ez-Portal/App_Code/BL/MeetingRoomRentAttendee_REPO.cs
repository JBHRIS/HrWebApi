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
    /// DEPTA 的摘要描述
    /// </summary>
    public class MeetingRoomRentAttendee_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public MeetingRoomRentAttendee_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public MeetingRoomRentAttendee_REPO()
        {
            dc = new JBHRModelDataContext();
        }
        public void Add(MeetingRoomRentAttendee o)
        {
            dc.MeetingRoomRentAttendee.InsertOnSubmit(o);
        }

        public void Update(MeetingRoomRentAttendee o)
        {
            DcHelper.Detach(o);
            dc.MeetingRoomRentAttendee.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Delete(MeetingRoomRentAttendee o)
        {
            DcHelper.Detach(o);
            dc.MeetingRoomRentAttendee.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.MeetingRoomRentAttendee.DeleteOnSubmit(o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public MeetingRoomRentAttendee GetByPk(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.MeetingRoomRentAttendee
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public List<MeetingRoomRentAttendee> GetByMrrId(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.MeetingRoomRentAttendee
                        where c.MeetingRoomRentRecordId == id
                        select c).ToList();
            }
        }
    }
    

}