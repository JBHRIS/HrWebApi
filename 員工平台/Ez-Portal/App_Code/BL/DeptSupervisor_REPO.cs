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
    public class DeptSupervisor_REPO
    {
        public JBHRModelDataContext dc
        {
            get;
            set;
        }
        private static readonly Object syncObj = new Object();
        public const string CacheName = "DeptSupervisor_REPO";

        public DeptSupervisor_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public DeptSupervisor_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public void Save()
        {
            dc.SubmitChanges();
            UpdateCache();
        }

        public void Add(DeptSupervisor o)
        {
            dc.DeptSupervisor.InsertOnSubmit(o);
        }

        public void Delete(DeptSupervisor o)
        {
            DcHelper.Detach(o);
            dc.DeptSupervisor.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.DeptSupervisor.DeleteOnSubmit(o);            
        }

        public DeptSupervisor GetByPk(int Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.DeptSupervisor
                        where c.AutoKey == Avalue
                        select c).FirstOrDefault();
            }
        }


        public List<DeptSupervisor> GetAll_Dlo()
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<DeptSupervisor>(l => l.DEPT);
                dlo.LoadWith<DeptSupervisor>(l => l.BASE);
                ldc.LoadOptions = dlo;
                return (from c in ldc.DeptSupervisor
                        select c).ToList();
            }
        }


        public List<DeptSupervisor> GetBySupervisorNobr(String Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.DeptSupervisor
                        where c.SupervisorNobr==Avalue
                        select c).ToList();
            }
        }

        public List<DeptSupervisor> GetBySupervisorNobr_DLO(String Avalue)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<DeptSupervisor>(l => l.DEPT);
            dlo.LoadWith<DeptSupervisor>(l => l.BASE);
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.DeptSupervisor
                        where c.SupervisorNobr == Avalue
                        select c).ToList();
            }
        }



        public List<DeptSupervisor> GetByDept_DLO(String Avalue)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<DeptSupervisor>(l => l.DEPT);
            dlo.LoadWith<DeptSupervisor>(l => l.BASE);
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.DeptSupervisor
                        where c.D_No==Avalue
                        select c).ToList();
            }
        }


        public  List<DeptSupervisor> GetAllFromCache_Dlo()
        {
            List<DeptSupervisor> list = HttpContext.Current.Cache[CacheName] as List<DeptSupervisor>;
            if ( list == null )
            {
                lock ( syncObj )
                {
                    list = HttpContext.Current.Cache[CacheName] as List<DeptSupervisor>;
                    if ( list == null )
                    {
                        DeptSupervisor_REPO deptSupervisorRepo = new DeptSupervisor_REPO();
                        list = deptSupervisorRepo.GetAll_Dlo();
                        HttpContext.Current.Cache[CacheName] = list;
                    }
                }
            }

            return list;
        }


        public List<DeptSupervisor> GetBySupervisorNobrFromCache_Dlo(string Avalue)
        {
            List<DeptSupervisor> list = GetAllFromCache_Dlo();

            return (from c in list
                    where c.SupervisorNobr == Avalue
                    select c).ToList();
        }


        public List<DeptSupervisor> GetBySupervisorNobrFromCache_Dlo(string Avalue,bool AaddorDel)
        {
            List<DeptSupervisor> list = GetAllFromCache_Dlo();

            return (from c in list
                    where c.SupervisorNobr == Avalue
                    && c.AddOrDel== AaddorDel
                    select c).ToList();
        }


        public List<DeptSupervisor> GetBySupervisorDeptFromCache_Dlo(string Avalue)
        {
            List<DeptSupervisor> list = GetAllFromCache_Dlo();

            return (from c in list
                    where c.D_No==Avalue
                    select c).ToList();
        }

        public List<DeptSupervisor> GetBySupervisorDeptFromCache_Dlo(string Avalue, bool AaddorDel)
        {
            List<DeptSupervisor> list = GetAllFromCache_Dlo();

            return (from c in list
                    where c.D_No == Avalue
                    && c.AddOrDel == AaddorDel
                    select c).ToList();
        }


        public void UpdateCache()
        {
            HttpContext.Current.Cache.Remove(CacheName);
            HttpContext.Current.Cache[CacheName] = GetAll_Dlo();
        }
    }    
}