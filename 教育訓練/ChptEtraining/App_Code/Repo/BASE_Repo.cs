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
    public class BASE_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public BASE_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public BASE_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }
        

        public BASE GetByNobr(string nobr)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from b in ldc.BASE
                        where b.NOBR == nobr
                        select b).FirstOrDefault();
            }
        }

        public BASE GetByKey(string nobr)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from b in ldc.BASE
                        where b.NOBR == nobr
                        select b).FirstOrDefault();
            }
        }

        public BASE GetByNobrOrAdName_Dlo(string Avalue)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo; 
                return (from b in ldc.BASE
                        where (b.NOBR == Avalue || b.NAME_AD == Avalue)
                        && b.BASETTS.Any()
                        select b).FirstOrDefault();
            }
        }

        /// <summary>
        /// 抓取在職員工 By Date
        /// </summary>
        /// <param name="Adate"></param>
        /// <returns></returns>
        public List<BASE> GetEmpHiredByDate_Dlo(DateTime Adate)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASE>(l => l.sysUserRole);
                dlo.LoadWith<sysUserRole>(l => l.sysRole);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= Adate && t.DDATE >= Adate && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;               
                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        select c).ToList();
            }
        }

        /// <summary>
        /// 抓取在職員工 By Dept,Date
        /// </summary>
        /// <param name="Adate"></param>
        /// <returns></returns>
        public List<BASE> GetEmpHiredByDeptDate_Dlo(string deptCode,DateTime Adate)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= Adate && t.DDATE >= Adate && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;
                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        && c.BASETTS.Any(p=>p.DEPT==deptCode)
                        select c).ToList();
            }
        }

/// <summary>
/// 抓取區間中在職的員工
/// </summary>
/// <param name="AbDate"></param>
/// <param name="AeDate"></param>
/// <param name="AdeptCode">部門代碼</param>
/// <returns></returns>
        public List<BASE> GetEmpHiredByDateRange_Dlo(DateTime AbDate,DateTime AeDate,string AdeptCode)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= AeDate && t.DDATE >= AbDate && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;
                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        && c.BASETTS.Any(p=>p.DEPT==AdeptCode)
                        select c).ToList();
            }
        }



        public List<BASE> GetAll()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                ldc.LoadOptions = dlo;
                return (from c in ldc.BASE
                        select c).ToList();
            }
        }

        /// <summary>
        /// 抓取目前在職員工 By Name_C 、工號
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public List<BASE> GetHiredEmpBySeachKey_DLO(string Str)
        {
            if (Str.Length == 0)
                return new List<BASE>();
            //dc.Log = new DebuggerWriter();
            DateTime datetime = DateTime.Now.Date;
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where (c.NOBR == Str || c.NAME_C.Contains(Str))
                        && c.BASETTS.Any()
                        select c).ToList();
            }
        }

        /// <summary>
        /// 抓取目前員工資料
        /// </summary>
        /// <param name="nobr"></param>
        /// <returns></returns>
        public BASE GetEmpByNobrNow_DLO(string nobr)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                //dlo.LoadWith<BASETTS>(l => l.DEPTA);
                //dlo.LoadWith<BASETTS>(l => l.COMP1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.NOBR == nobr
                        && c.BASETTS.Any()
                        select c).FirstOrDefault();
            }
        }


        public List<BASE> GetManagersByDept(string deptCode)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                //dlo.LoadWith<BASETTS>(l => l.DEPT1);
                //dlo.LoadWith<BASETTS>(l => l.JOB1);
                //dlo.LoadWith<BASETTS>(l => l.DEPTA);
                //dlo.LoadWith<BASETTS>(l => l.COMP1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.BASETTS.Any()                        
                        && c.BASETTS.Any(p=>p.MANG && p.DEPT==deptCode)
                        select c).ToList();
            }
        }
    }
}