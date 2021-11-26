using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using JBHRModel;

namespace BL
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class QA_Published_Repo
    {
        public JBHRModelDataContext dc { get; set; }

        public QA_Published_Repo()
        {
            dc = new JBHRModelDataContext();
        }

        public QA_Published_Repo(JBHRModelDataContext d)
        {
            dc = d;
        }

        public void Add(QA_Published o)
        {
            dc.QA_Published.InsertOnSubmit(o);
        }

        public void Update(QA_Published o)
        {
            DcHelper.Detach(o);
            dc.QA_Published.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Delete(QA_Published o)
        {
            DcHelper.Detach(o);
            dc.QA_Published.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QA_Published.DeleteOnSubmit(o);
        }

        public void Delete(List<QA_Published> list)
        {
            foreach (QA_Published o in list)
            {
                Delete(o);
            }
        }

        public List<QA_Published> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QA_Published
                        select c).ToList();
            }
        }

        public List<QA_Published> GetAll_Dlo()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QA_Published>(l => l.QTpl);
                ldc.LoadOptions = dlo;
                return (from c in ldc.QA_Published
                        select c).ToList();
            }
        }

        public List<QA_Published> GetByDateRange_Dlo(DateTime dateB, DateTime dateE)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QA_Published>(l => l.QTpl);
                ldc.LoadOptions = dlo;
                return (from c in ldc.QA_Published
                        where c.PublishDatetime.Date >= dateB && c.PublishDatetime.Date <= dateE
                        && c.Cancel==false
                        select c).ToList();
            }
        }

        public List<QA_Published> GetByDateRangePublished_Dlo(DateTime dateB, DateTime dateE)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QA_Published>(l => l.QTpl);
                ldc.LoadOptions = dlo;
                return (from c in ldc.QA_Published
                        where c.PublishDatetime.Date >= dateB && c.PublishDatetime.Date <= dateE
                        && c.IsPublished
                        && c.Cancel == false
                        select c).ToList();
            }
        }

        public QA_Published GetByPk(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QA_Published
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public QA_Published GetByPk_Dlo(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QAMaster>(l => l.QADetail);
                dlo.LoadWith<QA_Published>(l => l.QAMaster);
                dlo.LoadWith<QA_Published>(l => l.QTpl);
                ldc.LoadOptions = dlo;
                return (from c in ldc.QA_Published
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public bool CheckRightToViewSummary(DateTime dateB, DateTime dateE, bool ViewSummaryClosed, bool ViewSummaryOpening)
        {
            if (DateTime.Now > dateE)
            {
                if (ViewSummaryClosed)
                    return true;
            }
            else if (DateTime.Now <= dateE && DateTime.Now >= dateB)
            {
                if (ViewSummaryOpening)
                    return true;
            }
            else
            {
                return false;
            }

            return false;
        }
    }
}