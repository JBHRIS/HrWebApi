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
    public class DeptaSupervisor_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }
        private static readonly Object syncObj = new Object();
        public const string CacheName = "DeptaSupervisor_REPO";

        public DeptaSupervisor_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public DeptaSupervisor_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public void Save()
        {
            dc.SubmitChanges();
            UpdateCache();
        }

        public void Add(DeptaSupervisor o)
        {
            dc.DeptaSupervisor.InsertOnSubmit(o);
        }

        public void Delete(DeptaSupervisor o)
        {
            DcHelper.Detach(o);
            dc.DeptaSupervisor.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.DeptaSupervisor.DeleteOnSubmit(o);            
        }

        public DeptaSupervisor GetByPk(int Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.DeptaSupervisor
                        where c.AutoKey == Avalue
                        select c).FirstOrDefault();
            }
        }


        public List<DeptaSupervisor> GetAll_Dlo()
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<DeptaSupervisor>(l => l.DEPTA);
                dlo.LoadWith<DeptaSupervisor>(l => l.BASE);
                ldc.LoadOptions = dlo;
                return (from c in ldc.DeptaSupervisor
                        select c).ToList();
            }
        }


        public List<DeptaSupervisor> GetBySupervisorNobr(String Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.DeptaSupervisor
                        where c.SupervisorNobr==Avalue
                        select c).ToList();
            }
        }

        public List<DeptaSupervisor> GetBySupervisorNobr_DLO(String Avalue)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<DeptaSupervisor>(l => l.DEPTA);
            dlo.LoadWith<DeptaSupervisor>(l => l.BASE);
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.DeptaSupervisor
                        where c.SupervisorNobr == Avalue
                        select c).ToList();
            }
        }



        public List<DeptaSupervisor> GetByDept_DLO(String Avalue)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<DeptaSupervisor>(l => l.DEPTA);
            dlo.LoadWith<DeptaSupervisor>(l => l.BASE);
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.DeptaSupervisor
                        where c.D_No==Avalue
                        select c).ToList();
            }
        }


        public  List<DeptaSupervisor> GetAllFromCache_Dlo()
        {
            List<DeptaSupervisor> list = HttpContext.Current.Cache[CacheName] as List<DeptaSupervisor>;
            if ( list == null )
            {
                lock ( syncObj )
                {
                    list = HttpContext.Current.Cache[CacheName] as List<DeptaSupervisor>;
                    if ( list == null )
                    {
                        DeptaSupervisor_REPO deptaSupervisorRepo = new DeptaSupervisor_REPO();
                        list =deptaSupervisorRepo.GetAll_Dlo();
                        HttpContext.Current.Cache[CacheName] = list;
                    }
                }
            }

            return list;
        }


        public List<DeptaSupervisor> GetBySupervisorNobrFromCache_Dlo(string Avalue)
        {
            List<DeptaSupervisor> list = GetAllFromCache_Dlo();

            return (from c in list
                    where c.SupervisorNobr == Avalue
                    select c).ToList();
        }


        public List<DeptaSupervisor> GetBySupervisorNobrFromCache_Dlo(string Avalue,bool AaddorDel)
        {
            List<DeptaSupervisor> list = GetAllFromCache_Dlo();

            return (from c in list
                    where c.SupervisorNobr == Avalue
                    && c.AddOrDel== AaddorDel
                    select c).ToList();
        }


        public void UpdateCache()
        {
            HttpContext.Current.Cache.Remove(CacheName);
            HttpContext.Current.Cache[CacheName] = GetAll_Dlo();
        }
    }    
}