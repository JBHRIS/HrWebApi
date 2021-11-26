using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JBHRModel;
using System.Data.Objects;
using System.Data.Linq;
using System.Runtime.Caching;
namespace BL
{
    /// <summary>
    /// BASETTS_REPO 的摘要描述
    /// </summary>
    public class BASETTS_REPO
    {
        public const string CacheKey = @"BASETTS_REPO.";
        static public readonly string[] EMP_HIRED_TTSCODE = new string[] { "1" , "4" , "6" };
        public JBHRModel.JBHRModelDataContext dc
        {
            get;
            set;
        }
        public BASETTS_REPO(JBHRModel.JBHRModelDataContext o)
        {
            dc = o;
        }

        public BASETTS_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public void Update(BASETTS obj)
        {
            //oc.AttachTo("BASETTS", obj);
            DcHelper.Detach(obj);
            dc.BASETTS.Attach(obj);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , obj);
            //oc.ObjectStateManager.GetObjectStateEntry(obj).SetModified();
            //oc.Refresh(RefreshMode.ClientWins, obj);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public BASETTS GetLatestRecordByNobr(string nobr)
        {
            return (from c in dc.BASETTS
                    where c.NOBR == nobr && c.ADATE <= DateTime.Now.Date && c.DDATE >= DateTime.Now.Date
                    select c).WhereIn(p => p.TTSCODE , new string[] { "1" , "4" , "6" }).FirstOrDefault();

        }

        /// <summary>
        /// 抓取資料 By DateTime
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public List<BASETTS> GetRecordByDateTime(DateTime datetime)
        {
            return (from c in dc.BASETTS
                    where c.ADATE <= datetime && c.DDATE >= datetime
                    select c).ToList();
        }

        /// <summary>
        /// 抓取目前在職的員工
        /// </summary>
        /// <returns></returns>
        public List<BASETTS> GetHired_Inc()
        {
            using ( JBHRModelDataContext loc = new JBHRModelDataContext() )
            {
                //return (from c in loc.BASETTS.Include("DEPT").Include("JOB").Include("BASE")
                //        where c.ADATE <= DateTime.Now.Date && c.DDATE >= DateTime.Now.Date
                //        select c).WhereIn(p => p.TTSCODE, new string[] { "1", "4", "6" }).ToList();


                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASETTS>(l => l.BASE);
                dlo.LoadWith<BASETTS>(l => l.DEPT);
                dlo.LoadWith<BASETTS>(l => l.JOB);
                loc.LoadOptions = dlo;

                return (from c in loc.BASETTS
                        where c.ADATE >= datetime && c.ADATE <= datetime
                        && (EMP_HIRED_TTSCODE.Contains(c.TTSCODE))
                        select c).ToList();
            }
        }

        /// <summary>
        /// 抓取當時在職的員工byDate
        /// </summary>
        /// <returns></returns>
        public List<BASETTS> GetHiredByDate_Inc(DateTime datetime)
        {
            using ( JBHRModelDataContext loc = new JBHRModelDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASETTS>(l => l.BASE);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.DEPTS1);
                dlo.LoadWith<BASETTS>(l => l.JOB);
                loc.LoadOptions = dlo;

                return (from c in loc.BASETTS
                        where c.ADATE >= datetime && c.ADATE <= datetime
                        && (EMP_HIRED_TTSCODE.Contains(c.TTSCODE))
                        select c).ToList();
                // return (from c in loc.BASETTS.Include("DEPT").Include("JOB").Include("BASE")
                //where c.ADATE <= datetime && c.DDATE >= datetime
                //select c).WhereIn(p => p.TTSCODE, new string[] { "1", "4", "6" }).ToList();
            }
        }


        /// <summary>
        /// 抓取當時在職的員工 By Dept
        /// </summary>
        /// <returns></returns>
        public List<BASETTS> GetHiredByDateDept_Inc(DateTime datetime , string deptCode)
        {
            using ( JBHRModelDataContext loc = new JBHRModelDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASETTS>(l => l.BASE);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.DEPTS1);
                dlo.LoadWith<BASETTS>(l => l.JOB);
                loc.LoadOptions = dlo;

                return (from c in loc.BASETTS
                        where c.ADATE >= datetime && c.ADATE <= datetime
                        && (EMP_HIRED_TTSCODE.Contains(c.TTSCODE))
                        && c.DEPT == deptCode
                        select c).ToList();

                //return (from c in loc.BASETTS.Include("DEPT").Include("JOB").Include("BASE")
                //        where c.ADATE <= datetime && c.DDATE >= datetime
                //        && c.DEPT.D_NO == deptCode
                //        select c).WhereIn(p => p.TTSCODE, new string[] { "1", "4", "6" }).ToList();
            }
        }


        /// <summary>
        /// 抓取目前在職員工By 部門
        /// </summary>
        /// <returns></returns>
        public List<BASETTS> GetHiredByDept_Inc(string deptCode)
        {
            using ( JBHRModelDataContext loc = new JBHRModelDataContext() )
            {
                DateTime datetime = DateTime.Now.Date;

                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASETTS>(l => l.BASE);
                dlo.LoadWith<BASETTS>(l => l.DEPT);
                dlo.LoadWith<BASETTS>(l => l.JOB);
                loc.LoadOptions = dlo;

                return (from c in loc.BASETTS
                        where c.ADATE >= datetime && c.ADATE <= datetime
                        && (EMP_HIRED_TTSCODE.Contains(c.TTSCODE))
                        && c.DEPT == deptCode
                        select c).ToList();

                //return (from c in loc.BASETTS.Include("DEPT").Include("JOB").Include("BASE")
                //        where c.ADATE <= DateTime.Now && c.DDATE >= DateTime.Now.Date
                //        && c.DEPT.D_NO == dept
                //        select c).WhereIn(p => p.TTSCODE , new string[] { "1" , "4" , "6" }).ToList();
            }
        }


        public BASETTS GetByNobrNow_DLO(string nobr)
        {
            using ( JBHRModelDataContext loc = new JBHRModelDataContext() )
            {
                DateTime datetime = DateTime.Now.Date;
                loc.Log = new DebuggerWriter();
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASETTS>(l => l.BASE);
                dlo.LoadWith<BASETTS>(l => l.DEPT);
                dlo.LoadWith<BASETTS>(l => l.JOB);
                loc.LoadOptions = dlo;

                return (from c in loc.BASETTS
                        where c.DDATE >= datetime && c.ADATE <= datetime
                        && c.NOBR == nobr
                        select c).FirstOrDefault();
            }
        }

        public BASETTS GetByNobrNow(string nobr)
        {
            using ( JBHRModelDataContext loc = new JBHRModelDataContext() )
            {
                DateTime datetime = DateTime.Now.Date;
                return (from c in loc.BASETTS
                        where c.DDATE >= datetime && c.ADATE <= datetime
                        && c.NOBR == nobr
                        select c).FirstOrDefault();
            }
        }

        public List<BASETTS> GetByDeptSearchValue_Inc(string value , string deptCode)
        {
            using ( JBHRModelDataContext loc = new JBHRModelDataContext() )
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASETTS>(l => l.BASE);
                dlo.LoadWith<BASETTS>(l => l.DEPT);
                dlo.LoadWith<BASETTS>(l => l.JOB);
                loc.LoadOptions = dlo;


                return (from c in loc.BASETTS
                        where c.DEPT == deptCode
                            &&
                            (
                            c.NOBR.Contains(value)
                            || c.BASE.NAME_E.Contains(value)
                            || c.BASE.NAME_AD.Contains(value)
                            || c.BASE.NAME_C.Contains(value)
                            )
                                    && datetime >= c.ADATE
                            && datetime <= c.DDATE
                        select c).ToList();
            }
        }

        public bool IsManager(string nobr)
        {
            BASETTS basetts = GetLatestRecordByNobr(nobr);
            if ( basetts.MANG )
                return true;


            DEPTA_REPO deptaRepo = new DEPTA_REPO();
            List<DEPTA> list = deptaRepo.GetByNobr(nobr);
            if ( list.Count > 0 )
                return true;

            return false;
        }


        public BASETTS GetByDeptIdFromCache(string Avalue)
        {
            string fnCacheKey = "Dept.";
            string fullCacheKey = CacheKey +fnCacheKey+ Avalue;
            ObjectCache cache = MemoryCache.Default;

            if ( cache.Contains(fullCacheKey) )
                return (BASETTS) cache.Get(fullCacheKey);
            else
            {
                using ( JBHRModelDataContext loc = new JBHRModelDataContext() )
                {
                    var result = (from c in loc.BASETTS
                                  where c.DEPT == Avalue
                                  select c).FirstOrDefault();

                    if ( result == null )
                        return null;
                    else
                    {
                        CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                        cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(3);
                        cache.Add(fullCacheKey , result , cacheItemPolicy);
                        return result;
                    }
                }
            }
        }

        public BASETTS GetByDeptaIdFromCache(string Avalue)
        {
            string fnCacheKey = "Depta.";
            string fullCacheKey = CacheKey + fnCacheKey + Avalue;
            ObjectCache cache = MemoryCache.Default;

            if ( cache.Contains(fullCacheKey) )
                return (BASETTS)cache.Get(fullCacheKey);
            else
            {
                using ( JBHRModelDataContext loc = new JBHRModelDataContext() )
                {
                    var result = (from c in loc.BASETTS
                                  where c.DEPTM == Avalue
                                  select c).FirstOrDefault();

                    if ( result == null )
                        return null;
                    else
                    {
                        CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                        cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(3);
                        cache.Add(fullCacheKey , result , cacheItemPolicy);
                        return result;
                    }
                }
            }
        }
    }
}