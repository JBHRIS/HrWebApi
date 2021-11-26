using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Data.Linq;
namespace Repo
{
    /// <summary>
    /// DEPT_Repo 的摘要描述
    /// </summary>
    public class DEPT_Repo
    {
        public const string CacheName = "DEPT";
        public dcTrainingDataContext dc
        {
            get;
            set;
        }
        public bool IsFromCache { get; set; }

        public DEPT_Repo()
        {
            dc = new dcTrainingDataContext();
         //   dc.Log = new DebuggerWriter();
        }
        public DEPT_Repo(dcTrainingDataContext d)
        {
            dc = d;
        //    dc.Log = new DebuggerWriter();
        }

        public List<DEPT> GetAllChildNode(DEPT dept)
        {
            List<DEPT> result = new List<DEPT>();
            result.Add(dept);

            var dataList = (from c in GetTableData()
                            where c.DEPT_GROUP == dept.D_NO
                            select c).ToList();

            foreach (var l in dataList)
            {
                 result.AddRange(GetAllChildNode(l));
            }

            return result;            
        }

        //抓取該部門的子部門
        public List<DEPT> GetChildByDeptCode(string deptCode)
        {
            return (from c in GetTableData()
                    where c.DEPT_GROUP == deptCode
                    select c).ToList();
        }

        //抓取上層父部門
        public DEPT GetParentDeptByID(string id)
        {
            return (from c in GetTableData()
                    where c.DEPT_GROUP == id
                    select c).FirstOrDefault();
        }

        public DEPT GetDeptByID(string id)
        {                  
            return (from c in GetTableData()
                    where c.D_NO == id
                    select c).FirstOrDefault();
        }

        public IEnumerable<DEPT> GetTableData()
        {
            if (IsFromCache)
            {
                //先轉型，才是對的，不然可能會遇到null，請參閱will
                IEnumerable<DEPT> deptList = HttpContext.Current.Cache[CacheName] as IEnumerable<DEPT>;
                if (deptList ==null)
                {
                    IEnumerable<DEPT> list = (from c in dc.DEPT select c).ToList();
                    //HttpContext.Current.Cache[CacheName] = list;
                    HttpContext.Current.Cache.Insert(CacheName, list, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10));
                }
                return (IEnumerable<DEPT>)HttpContext.Current.Cache[CacheName];
            }
            else
            {
                return (IEnumerable<DEPT>)dc.GetTable<DEPT>();
            }
        }

        public List<DEPT> GetByNobr(string id)
        {
            DateTime datetime = DateTime.Now.Date;
            return (from c in dc.DEPT
                    where c.NOBR!=null && c.NOBR == id && c.ADATE <= datetime && c.DDATE >= datetime
                    select c).ToList();
        }

        public DEPT GetById_BASE_Dlo(string id)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<DEPT>(l => l.BASE);
                ldc.LoadOptions = dlo;
                return (from c in ldc.DEPT
                        where c.D_NO ==id
                        select c).FirstOrDefault();
            }
        }

    }
}