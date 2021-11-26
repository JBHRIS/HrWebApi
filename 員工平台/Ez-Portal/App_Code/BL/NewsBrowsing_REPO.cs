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
    public class NewsBrowsing_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public NewsBrowsing_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public NewsBrowsing_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public void Add(NewsBrowsing o)
        {
            dc.NewsBrowsing.InsertOnSubmit(o);
        }

        public void Delete(NewsBrowsing o)
        {
            DcHelper.Detach(o);
            dc.NewsBrowsing.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.NewsBrowsing.DeleteOnSubmit(o);
        }

        public void Update(NewsBrowsing o)
        {
            DcHelper.Detach(o);
            dc.NewsBrowsing.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public NewsBrowsing GetById(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.NewsBrowsing
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }


        public List<NewsBrowsing> GetByNewsId(string id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.NewsBrowsing
                        where c.news_id == id
                        select c).ToList();
            }
        }

        public int CountByNewsIdNobr(string newsId,string nobr)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.NewsBrowsing
                        where c.news_id == newsId && c.Nobr==nobr
                        select c).Count();
            }
        }
    }
}