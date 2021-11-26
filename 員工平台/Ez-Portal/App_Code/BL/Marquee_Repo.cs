using System;
using System.Collections.Generic;
using System.Linq;
using JBHRModel;

namespace BL
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class Marquee_Repo
    {
        public JBHRModelDataContext dc { get; set; }

        public Marquee_Repo()
        {
            dc = new JBHRModelDataContext();
        }

        public Marquee_Repo(JBHRModelDataContext d)
        {
            dc = d;
        }

        public void Add(Marquee o)
        {
            dc.Marquee.InsertOnSubmit(o);
        }

        public void Update(Marquee o)
        {
            DcHelper.Detach(o);
            dc.Marquee.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Delete(Marquee o)
        {
            DcHelper.Detach(o);
            dc.Marquee.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.Marquee.DeleteOnSubmit(o);
        }

        public List<Marquee> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.Marquee
                        select c).ToList();
            }
        }

        public List<Marquee> GetAllByEnable()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.Marquee
                        where c.Enable && DateTime.Now.Date >= c.StartDate && DateTime.Now.Date <= c.EndDate
                        select c).ToList();
            }
        }

        public Marquee GetByPK(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.Marquee
                        where c.ID == id
                        select c).FirstOrDefault();
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}