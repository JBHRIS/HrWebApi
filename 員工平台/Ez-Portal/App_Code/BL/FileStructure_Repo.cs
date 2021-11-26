using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JBHRModel;

namespace BL
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class FileStructure_Repo
    {
        public JBHRModelDataContext dc { get; set; }

        private static readonly Object syncObj = new Object();
        public const string CacheName = "FileStructure_RepoCache";

        public FileStructure_Repo()
        {
            dc = new JBHRModelDataContext();
        }

        public FileStructure_Repo(JBHRModelDataContext d)
        {
            dc = d;
        }

        public void Add(FileStructure o)
        {
            dc.FileStructure.InsertOnSubmit(o);
        }

        public void Update(FileStructure o)
        {
            DcHelper.Detach(o);
            dc.FileStructure.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Delete(FileStructure o)
        {
            DcHelper.Detach(o);
            dc.FileStructure.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.FileStructure.DeleteOnSubmit(o);
        }

        public List<FileStructure> GetByAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.FileStructure
                        select c).ToList();
            }
        }

        public FileStructure GetByFileNameFromCache(string filePath, string appDomain)
        {
            List<FileStructure> list = GetInstance();
            return (from c in list
                    where appDomain + c.sPath + c.sFileName == filePath
                    select c).FirstOrDefault();
        }

        public List<FileStructure> GetByPathFromCache(string path)
        {
            List<FileStructure> list = GetInstance();
            return (from c in list
                            where (c.sPath + c.sFileName) == path
                            select c).ToList();
        }

        public FileStructure GetByKey(string Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.FileStructure
                        where c.Code == Avalue
                        select c).SingleOrDefault();
            }
        }

        public static FileStructure GetPageTitle(string path)
        {
            List<FileStructure> list = GetInstance();
            var data = (from c in list
                        where (c.sPath + c.sFileName) == path
                        select c).FirstOrDefault();

            if (data != null)
                return data;
            else
                return null;
        }

        public static bool CheckPagePermissions(List<string> roleList, string path)
        {
            List<FileStructure> list = GetInstance();
            var dataList = (from c in list
                        where (c.sPath + c.sFileName) == path
                        select c).ToList();

            //未建立此程式權限，預設可讀
            if (dataList.Count==0)
                return true;

            List<FileStructureRole> frList = FileStructureRole_Repo.GetInstance();

            var frObjList = (from c in frList
                         where dataList.Select(p=>p.Code).Contains(c.FileStructureKey) && roleList.Contains(c.RoleCode)
                         select c).ToList();

            if (frObjList.Count==0)
                return false;
            else
                return true;
        }

        public static bool CheckPagePermissions(List<string> roleList, List<FileStructure> fsList)
        {
            //未建立此程式權限，預設可讀
            if (fsList.Count == 0)
                return true;

            List<FileStructureRole> frList = FileStructureRole_Repo.GetInstance();

            var frObjList = (from c in frList
                             where fsList.Select(p => p.Code).Contains(c.FileStructureKey) && roleList.Contains(c.RoleCode)
                             select c).ToList();

            if (frObjList.Count == 0)
                return false;
            else
                return true;
        }

        public static void UpdateCache()
        {
            FileStructure_Repo sfsRepo = new FileStructure_Repo();
            List<FileStructure> list = sfsRepo.GetByAll();
            HttpContext.Current.Cache.Insert(CacheName, list);
        }

        public static List<FileStructure> GetInstance()
        {
            FileStructure_Repo sfsRepo = new FileStructure_Repo();

            List<FileStructure> list = HttpContext.Current.Cache[CacheName] as List<FileStructure>;
            if (list == null)
            {
                lock (syncObj)
                {
                    List<FileStructure> list2 = HttpContext.Current.Cache[CacheName] as List<FileStructure>;
                    if (list2 == null)
                    {
                        JBHRModelDataContext dcTraining = new JBHRModelDataContext();
                        HttpContext.Current.Cache[CacheName] = sfsRepo.GetByAll();
                    }
                }
            }

            return (List<FileStructure>)HttpContext.Current.Cache[CacheName];
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<FileStructure> GetAllChildByParent(string key)
        {
            List<FileStructure> list = new List<FileStructure>();

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                var resultList = (from c in ldc.FileStructure
                                  where c.sParentKey == key
                                  select c).ToList();

                list.AddRange(resultList);

                foreach (var l in resultList)
                {
                    list.AddRange(GetAllChildByParent(l.Code));
                }
            }

            return list;
        }
    }
}