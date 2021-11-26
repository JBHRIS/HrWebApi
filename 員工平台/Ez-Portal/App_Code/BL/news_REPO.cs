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
    public class news_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public news_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public news_REPO()
        {
            dc = new JBHRModelDataContext();
        }
        public void Add(news o)
        {
            dc.news.InsertOnSubmit(o);
        }

        public void Update(news o)
        {
            DcHelper.Detach(o);
            dc.news.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Delete(news o)
        {
            DcHelper.Detach(o);
            dc.news.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.news.DeleteOnSubmit(o);
        }
        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<NewsDto> GetNewsDtoAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<news>(l => l.UPFILE);

                ldc.LoadOptions = dlo;
                DateTime dt = DateTime.Now.Date;
                List<news> list = new List<news>();

                list.AddRange((from c in ldc.news
                               orderby c.sort descending
                               select c).ToList());

                //list.AddRange((from c in ldc.news
                //               where c.post_deadline >= dt
                //               orderby c.sort descending
                //               select c).ToList());

                //list.AddRange((from c in ldc.news
                //               where c.post_deadline < dt
                //               orderby c.sort descending
                //               select c).ToList());

                return (from c in list
                        select new NewsDto
                        {
                            AttachmentCount = c.AttachmentCount,//c.UPFILE.Count(),
                            is_on = c.is_on ,
                            news_body = c.news_body ,
                            news_head = c.news_head ,
                            news_id = c.news_id ,
                            newsfileid = c.newsfileid ,
                            post_date = c.post_date ,
                            post_deadline = c.post_deadline ,
                            sort = c.sort,
                            LatestSendMailDate= c.LatestSendMailDate
                        }).ToList();
            }
        }

        public news GetByPk_Dlo(string id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<news>(l => l.NewsTarget);
                dlo.LoadWith<news>(l => l.UPFILE);
                dlo.LoadWith<NewsTarget>(l => l.BASE);
                dlo.LoadWith<NewsTarget>(l => l.DEPT);
                ldc.LoadOptions = dlo;
                return (from c in ldc.news
                        where c.news_id == id
                        select c).FirstOrDefault();
            }
        }

        public news GetByPk(string id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.news
                        where c.news_id == id
                        select c).FirstOrDefault();
            }
        }

        public List<news> GetByNobrDept(string nobr,string dept,int pageIndex,int pageSize)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.news
                        where c.is_on
                        &&
                        (c.PublishAllEmp.Equals("1")
                        || 
                        (
                        c.PublishAllEmp.Equals("0")  
                        && 
                        (
                        c.NewsTarget.Any(p => p.EmpNo == nobr) || c.NewsTarget.Any(p => p.DetpCode == dept)
                        )))
                        orderby c.sort descending
                        select c).Skip((pageIndex)*pageSize).Take(pageSize).ToList();
            }

        }


        public List<news> GetByNobrDept(string nobr, string dept)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.news
                        where c.is_on
                        &&
                        (c.PublishAllEmp.Equals("1")
                        ||
                        (
                        c.PublishAllEmp.Equals("0")
                        &&
                        (
                        c.NewsTarget.Any(p => p.EmpNo == nobr) || c.NewsTarget.Any(p => p.DetpCode == dept)
                        )))
                        orderby c.sort descending
                        select c).ToList();
            }

        }

        public List<news> GetByNobrDept(string nobr, string dept,DateTime dateB,DateTime dateE)
        {
            dateE = dateE.AddDays(1);
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.news
                        where c.is_on
                        &&
                        (c.PublishAllEmp.Equals("1")
                        ||
                        (
                        c.PublishAllEmp.Equals("0")
                        &&
                        (
                        c.NewsTarget.Any(p => p.EmpNo == nobr) || c.NewsTarget.Any(p => p.DetpCode == dept)
                        )))
                        && c.post_date>= dateB && c.post_date <= dateE
                        && c.post_deadline >= DateTime.Now.Date
                        orderby c.sort descending
                        select c).ToList();
            }
        }


        public news GetByGreaterThenSort(long value,DateTime deadLine)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.news
                        where c.sort > value
                        orderby c.sort
                        select c).FirstOrDefault();
            }
        }

        public news GetByLessThenSort(long value, DateTime deadLine)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.news
                        where c.sort < value
                        orderby c.sort descending
                        select c).FirstOrDefault();
            }
        }

        public bool ReadNewsByIdNobr(string newsId, string nobr)
        {
            NewsBrowsing_REPO nbRepo = new NewsBrowsing_REPO();
            if (nbRepo.CountByNewsIdNobr(newsId, nobr) < 1)
            {
                news_REPO nRepo = new news_REPO(nbRepo.dc);
                var nObj = nRepo.GetByPk(newsId);
                if (nObj == null)
                    return false;

                NewsBrowsing nbObj = new NewsBrowsing();
                nbObj.news_id = newsId;
                nbObj.Nobr = nobr;
                nbObj.BrowsingTime = DateTime.Now;
                nbRepo.Add(nbObj);

                nObj.BrowsingNumber = nObj.BrowsingNumber + 1;
                nRepo.Update(nObj);
                nRepo.Save();

                return true;
            }

            return false;
        }
    }
}