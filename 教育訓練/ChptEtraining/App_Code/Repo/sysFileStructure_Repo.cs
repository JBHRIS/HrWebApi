using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Collections;
namespace Repo
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class sysFileStructure_Repo
    {
        public dcTrainingDataContext dc { get; set; }
        private static readonly Object syncObj = new Object();
        public const string CacheName = "sysFileStructure_RepoCache";

        public sysFileStructure_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public sysFileStructure_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(sysFileStructure o)
        {
            dc.sysFileStructure.InsertOnSubmit(o);            
        }

        public void Update(sysFileStructure o)
        {
            DcHelper.Detach(o);
            dc.sysFileStructure.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(sysFileStructure o)
        {
            DcHelper.Detach(o);
            dc.sysFileStructure.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.sysFileStructure.DeleteOnSubmit(o);
        }

        public List<sysFileStructure> GetByAll()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.sysFileStructure
                        select c).ToList();
            }
        }

        public sysFileStructure GetByFileNameFromCache(string filePath, string appDomain)
        {
            List<sysFileStructure> list = GetInstance();
            return (from c in list
                    where appDomain + c.sPath + c.sFileName == filePath
                    select c).FirstOrDefault();
        }

        public sysFileStructure GetByKey(string Avalue)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.sysFileStructure
                        where c.sKey == Avalue
                        select c).SingleOrDefault();
            }
        }

        public static sysFileStructure GetPageTitle(string path)
        {
            List<sysFileStructure> list = GetInstance();
            var data = (from c in list
                        where (c.sPath + c.sFileName) == path
                        select c).FirstOrDefault();

            if (data != null)
                return data;
            else 
                return null;
        }

        public static bool CheckPagePermissions(List<int> intRoleList, string path)
        {
            List<sysFileStructure> list = GetInstance();
            //可能會有多個程式，不同連結
            var dataList = (from c in list where (c.sPath + c.sFileName) == path select c).ToList();

            if (dataList.Count == 0) return true;

            List<FileStructureRole> frList = FileStructureRole_Repo.GetInstance();

            var frObjList = (from c in frList
                             where dataList.Select(p => p.sKey).Contains(c.FileStructureKey)
                              && intRoleList.Contains(c.RoleKey)
                             select c).ToList();

            if (frObjList.Count == 0) return false;
            else return true;
        }

        public static void UpdateCache()
        {
            sysFileStructure_Repo sfsRepo = new sysFileStructure_Repo();
            List<sysFileStructure> list = sfsRepo.GetByAll();
            HttpContext.Current.Cache.Insert(CacheName , list);
        }

        public static List<sysFileStructure> GetInstance()
        {
            sysFileStructure_Repo sfsRepo = new sysFileStructure_Repo();

            List<sysFileStructure> list = HttpContext.Current.Cache[CacheName] as List<sysFileStructure>;
            if (list == null)
            {
                lock (syncObj)
                {
                    List<sysFileStructure> list2 = HttpContext.Current.Cache[CacheName] as List<sysFileStructure>;
                    if (list2 == null)
                    {
                        dcTrainingDataContext dcTraining = new dcTrainingDataContext();
                        HttpContext.Current.Cache[CacheName] = sfsRepo.GetByAll();
                    }
                }
            }

            return (List<sysFileStructure>)HttpContext.Current.Cache[CacheName];
        }

        public void Save()
        {
            dc.SubmitChanges();
        }
    }
}