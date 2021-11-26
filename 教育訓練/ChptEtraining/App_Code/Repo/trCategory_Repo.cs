using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
namespace Repo
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class trCategory_Repo
    {
        public static int Categroy_Level = 2; //從1開始算一層
        private static readonly Object syncObj = new Object();
        public const string CacheName = "trCategory_RepoCache";
        public const string CatLevelDicCacheName = "trCategoryRepoDictionaryCache";
        public dcTrainingDataContext dc { get; set; }

        public trCategory_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trCategory_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Add(trCategory o)
        {
            dc.trCategory.InsertOnSubmit(o);
        }

        public void Update(trCategory o)
        {
            DcHelper.Detach(o);
            dc.trCategory.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<trCategory> GetAll()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from dm in ldc.trCategory
                        select dm).ToList();
            }
        }

        public int GetCategoryLevel(string catCode)
        {
            int level = -1;
            string tempCatCode = catCode;

            while (!tempCatCode.Equals("ROOT"))
            {
                level++;
                trCategory obj = GetCategory(tempCatCode);
                tempCatCode = obj.sParentCode;
            }

            return level;
        }

        /// <summary>
        /// 是否為課程類別的最後一個類別Level (才能在此連結課程)
        /// </summary>
        /// <param name="catCode"></param>
        /// <returns></returns>
        public bool IsLastCategoryLevel(string catCode)
        {
            int level = GetCategoryLevel(catCode);
            if (level == (Categroy_Level - 1))
                return true;
            else
                return false;
        }

        public trCategory GetCategory(string catCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trCategory
                        where c.sCode == catCode
                        select c).FirstOrDefault();
            }
        }

        public trCategory GetByCourseCode(string courseCode, int level)
        {
            trCourse_Repo cRepo = new trCourse_Repo();
            trCourse courseObj = cRepo.GetByCode_Dlo(courseCode);

            if (courseObj.trCategoryCourse.Count == 0)
                return null;

            //需要擷取的層級比擁有的還大
            if (level > Categroy_Level)
                return null;

            //需要擷取的層級剛好是最大的層級
            if (level == Categroy_Level)
                return courseObj.trCategoryCourse[0].trCategory;

            int catLevel = Categroy_Level;

            trCategory catObj = courseObj.trCategoryCourse[0].trCategory;

            while (level != catLevel)
            {
                catObj = (from c in trCategory_Repo.GetInstance() where catObj.sParentCode == c.sCode select c).FirstOrDefault();
                if (catObj == null)
                    return null;

                catLevel--;
            }

            return catObj;
        }

        public trCategory GetByCourseCodeFromCache(string courseCode, int level)
        {
            Dictionary<string, trCategory> dic = trCategory_Repo.GetCatLevelDic();
            string key = courseCode + "-" + level.ToString();
            if (dic.ContainsKey(key))
                return dic[key];
            else
            {
                dic.Add(key, GetByCourseCode(courseCode, level));
                return dic[key];
            }
        }

        public static List<trCategory> GetInstance()
        {
            trCategory_Repo catRepo = new trCategory_Repo();

            List<trCategory> list = HttpContext.Current.Cache[CacheName] as List<trCategory>;
            if (list == null)
            {
                lock (syncObj)
                {
                    list = HttpContext.Current.Cache[CacheName] as List<trCategory>;
                    if (list == null)
                    {
                        list = catRepo.GetAll();
                        HttpContext.Current.Cache[CacheName] = list;
                    }
                }
            }

            return list;
        }

        public static Dictionary<string, trCategory> GetCatLevelDic()
        {
            Dictionary<string, trCategory> catDic = HttpContext.Current.Cache[CatLevelDicCacheName] as Dictionary<string, trCategory>;
            if (catDic == null)
            {
                lock (syncObj)
                {
                    HttpContext.Current.Cache[CatLevelDicCacheName] = new Dictionary<string, trCategory>();
                }
            }

            return (Dictionary<string, trCategory>)HttpContext.Current.Cache[CatLevelDicCacheName];
        }
    }
}