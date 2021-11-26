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
    public class NewsTarget_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public NewsTarget_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public NewsTarget_REPO()
        {
            dc = new JBHRModelDataContext();
        }
        public void Add(NewsTarget o)
        {
            dc.NewsTarget.InsertOnSubmit(o);
        }

        public void Delete(NewsTarget o)
        {
            DcHelper.Detach(o);
            dc.NewsTarget.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.NewsTarget.DeleteOnSubmit(o);
        }

        public void Update(NewsTarget o)
        {
            DcHelper.Detach(o);
            dc.NewsTarget.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public NewsTarget GetById(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.NewsTarget
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }


        public List<NewsTarget> GetByNewsId(string id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.NewsTarget
                        where c.news_id == id
                        select c).ToList();
            }
        }

        public List<NewsTarget> GetByNewsId_Dlo(string id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<NewsTarget>(l => l.BASE);
                dlo.LoadWith<NewsTarget>(l => l.DEPT);
                ldc.LoadOptions = dlo;
                return (from c in ldc.NewsTarget
                        where c.news_id == id
                        select c).ToList();
            }
        }
    }
    

}