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
    public class SiteMapSalaDr_REPO
    {
        private static readonly Object syncObj = new Object();
        public const string CacheName = "SiteMapSalaDr_REPO";

        public JBHRModelDataContext dc{get;set;}
        public SiteMapSalaDr_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public SiteMapSalaDr GetByPk(int Avalue)
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                return (from c in ldc.SiteMapSalaDr
                        where c.Pid==Avalue
                        select c).FirstOrDefault();
            }
        }

        public SiteMapSalaDr_REPO()
        {
            dc = new JBHRModelDataContext();
        }
        public void Add(SiteMapSalaDr o)
        {
            dc.SiteMapSalaDr.InsertOnSubmit(o);
        }

        public void Delete(SiteMapSalaDr o)
        {
            DcHelper.Detach(o);
            dc.SiteMapSalaDr.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.SiteMapSalaDr.DeleteOnSubmit(o);
        }

        public void Update(SiteMapSalaDr o)
        {
            DcHelper.Detach(o);
            dc.SiteMapSalaDr.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<SiteMapSalaDr> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.SiteMapSalaDr
                        select c).ToList();
            }
        }


        public List<SiteMapSalaDr> GetAllFromCache()
        {
            List<SiteMapSalaDr> list = HttpContext.Current.Cache[CacheName] as List<SiteMapSalaDr>;
            if (list == null)
            {
                lock (syncObj)
                {
                    list = HttpContext.Current.Cache[CacheName] as List<SiteMapSalaDr>;
                    if (list == null)
                    {
                        list = GetAll();
                        HttpContext.Current.Cache[CacheName] = list;
                    }
                }
            }

            return list;
        }

        public List<SiteMapSalaDr> GetBySalaDrCodeFromCache(string Avalue)
        {
            List<SiteMapSalaDr> list = GetAllFromCache();
            return (from c in list where c.SALADR_Code == Avalue select c).ToList();
        }

        public List<SiteMapSalaDr> GetByUrl(string Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                string url = Avalue.Replace("~", "");
                return (from c in ldc.SiteMapSalaDr where c.SiteMapUrl == url select c).ToList();
            }
        }


        public List<SiteMapSalaDr> GetByUrl_Dlo(string Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<SiteMapSalaDr>(l => l.DATAGROUP);
                ldc.LoadOptions = dlo;
                string url = Avalue.Replace("~", "");
                return (from c in ldc.SiteMapSalaDr where c.SiteMapUrl == url select c).ToList();
            }
        }

        public void UpdateCache()
        {
            HttpContext.Current.Cache.Remove(CacheName);
            HttpContext.Current.Cache[CacheName] = GetAll();
        }
    }    
}