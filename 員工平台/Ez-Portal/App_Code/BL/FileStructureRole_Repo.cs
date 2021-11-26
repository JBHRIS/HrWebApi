using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using JBHRModel;
namespace BL
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class FileStructureRole_Repo
    {
        public JBHRModelDataContext dc { get; set; }
        private static readonly Object syncObj = new Object();
        public const string CacheName = "FileStructureRole_RepoCache";

        public FileStructureRole_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public FileStructureRole_Repo(JBHRModelDataContext d)
        {
            dc = d;            
        }


        public void Add(FileStructureRole o)
        {
            dc.FileStructureRole.InsertOnSubmit(o);            
        }

        public void Update(FileStructureRole o)
        {
            DcHelper.Detach(o);
            dc.FileStructureRole.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(FileStructureRole o)
        {
            DcHelper.Detach(o);
            dc.FileStructureRole.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.FileStructureRole.DeleteOnSubmit(o);
        }

        public List<FileStructureRole> GetByAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.FileStructureRole
                        select c).ToList();
            }
        }


        public List<FileStructureRole> GetByFKey(string Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.FileStructureRole
                        where c.FileStructureKey.Equals(Avalue)
                        select c).ToList();
            }
        }

        public List<FileStructureRole> GetByRoleKey(int Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.FileStructureRole
                        where c.RoleCode.Equals(Avalue)
                        select c).ToList();
            }
        }

        public FileStructureRole GetByFKeyRoleKey(string Afkey,string AroleKey)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.FileStructureRole
                        where c.RoleCode.Equals(AroleKey) && c.FileStructureKey.Equals(Afkey)
                        select c).FirstOrDefault();
            }
        }

        public static void UpdateCache()
        {
            FileStructureRole_Repo sfsRepo = new FileStructureRole_Repo();
            List<FileStructureRole> list = sfsRepo.GetByAll();
            HttpContext.Current.Cache.Insert(CacheName , list);
        }

        public static List<FileStructureRole> GetInstance()
        {
            FileStructureRole_Repo sfsRepo = new FileStructureRole_Repo();

            List<FileStructureRole> list = HttpContext.Current.Cache[CacheName] as List<FileStructureRole>;
            if (list == null)
            {
                lock (syncObj)
                {
                    list = HttpContext.Current.Cache[CacheName] as List<FileStructureRole>;
                    if (list == null)
                    {
                        list = sfsRepo.GetByAll();
                        HttpContext.Current.Cache[CacheName] = list;
                    }
                }
            }

            return list;
        }

        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}