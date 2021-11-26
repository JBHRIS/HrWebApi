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
    public class MeetingRoom_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public MeetingRoom_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public MeetingRoom_REPO()
        {
            dc = new JBHRModelDataContext();
        }
        public void Add(MeetingRoom o)
        {
            dc.MeetingRoom.InsertOnSubmit(o);
        }

        public void Update(MeetingRoom o)
        {
            DcHelper.Detach(o);
            dc.MeetingRoom.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<MeetingRoom> GetAll()
        {
            List<MeetingRoom> list = new List<MeetingRoom>();
            return (from c in dc.MeetingRoom           
                    select c).ToList();            
        }

        public List<MeetingRoom> GetByCanRent(bool canRent)
        {
            List<MeetingRoom> list = new List<MeetingRoom>();
            return (from c in dc.MeetingRoom
                    where c.CanRent == canRent
                    select c).ToList();
        }

        public MeetingRoom GetByPk(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.MeetingRoom
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
    }
    

}