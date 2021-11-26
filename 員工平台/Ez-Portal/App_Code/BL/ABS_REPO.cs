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
    public class ABS_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public ABS_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public ABS_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        /// <summary>
        /// 查詢 by 工號、日期區間
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="dateB"></param>
        /// <param name="dateE"></param>
        /// <returns></returns>
        public List<ABS> GetByNobrDateRange_Dlo(string nobr, DateTime dateB, DateTime dateE)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<ABS>(l => l.BASE);
            dlo.LoadWith<ABS>(l => l.HCODE);
            dlo.LoadWith<BASE>(l => l.BASETTS);
            dlo.LoadWith<BASETTS>(l => l.JOB1);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);
            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.ABS
                        where c.BDATE >= dateB && c.BDATE <= dateE && c.NOBR == nobr
                        select c).ToList();
            }
        }

        public List<ABS> GetByNobrDateRangeHcodeFlag_Dlo(string nobr, DateTime dateB, DateTime dateE,string flag)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<ABS>(l => l.BASE);
            dlo.LoadWith<ABS>(l => l.HCODE);
            dlo.LoadWith<BASE>(l => l.BASETTS);
            dlo.LoadWith<BASETTS>(l => l.JOB1);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);
            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.ABS
                        where c.BDATE >= dateB && c.BDATE <= dateE && c.NOBR == nobr 
                        && c.HCODE.FLAG.Equals(flag)
                        select c).ToList();
            }
        }





        /// <summary>
        /// 查詢 by 工號、日期區間
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="dateB"></param>
        /// <param name="dateE"></param>
        /// <returns></returns>
        public List<ABS> GetByNobrDateRange_Dlo(string nobr, DateTime dateB, DateTime dateE, string[] AyearRestArr)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<ABS>(l => l.BASE);
            dlo.LoadWith<BASE>(l => l.BASETTS);
            dlo.LoadWith<BASETTS>(l => l.JOB1);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);
            dlo.LoadWith<ABS>(l => l.HCODE);
            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.ABS
                        where c.BDATE >= dateB && c.BDATE <= dateE && c.NOBR == nobr
                                               && AyearRestArr.Contains(c.HCODE.YEAR_REST)
                        select c).ToList();
            }
        }


        /// <summary>
        /// 查詢 by 部門、日期區間
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="dateB"></param>
        /// <param name="dateE"></param>
        /// <returns></returns>
        public List<ABS> GetByDeptDateRange(string dept, DateTime dateB, DateTime dateE)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<ABS>(l => l.BASE);
            dlo.LoadWith<BASE>(l => l.BASETTS);
            dlo.LoadWith<BASETTS>(l => l.JOB1);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);
            dlo.LoadWith<ABS>(l => l.HCODE);
            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.ABS
                        where c.BDATE >= dateB && c.BDATE <= dateE && c.BASE.BASETTS.Any(b => b.DEPT == dept)
                        select c).ToList();
            }
        }



        /// <summary>
        /// 查詢 by 部門、日期區間
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="dateB"></param>
        /// <param name="dateE"></param>
        /// <returns></returns>
        public List<ABS> GetByDeptDateRange(string dept, DateTime dateB, DateTime dateE, string[] AyearRestArr)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<ABS>(l => l.BASE);
            dlo.LoadWith<BASE>(l => l.BASETTS);
            dlo.LoadWith<BASETTS>(l => l.JOB1);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);
            dlo.LoadWith<ABS>(l => l.HCODE);
            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.ABS
                        where c.BDATE >= dateB && c.BDATE <= dateE && c.BASE.BASETTS.Any(b => b.DEPT == dept)
                        && AyearRestArr.Contains(c.HCODE.YEAR_REST)
                        select c).ToList();
            }
        }



        /// <summary>
        /// 查詢 by 日期區間
        /// </summary>        
        /// <param name="dateB"></param>
        /// <param name="dateE"></param>
        /// <returns></returns>
        public List<ABS> GetByDateRange_Dlo(DateTime dateB, DateTime dateE, string[] AyearRestArr)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<ABS>(l => l.BASE);
            dlo.LoadWith<BASE>(l => l.BASETTS);
            dlo.LoadWith<BASETTS>(l => l.JOB1);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);
            dlo.LoadWith<ABS>(l => l.HCODE);
            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.ABS
                        where c.BDATE >= dateB && c.BDATE <= dateE
                        && AyearRestArr.Contains(c.HCODE.YEAR_REST)
                        select c).ToList();
            }
        }



        /// <summary>
        /// 查詢 by 部門、日期區間
        /// </summary>        
        /// <param name="Dept"></param>
        /// <param name="dateB"></param>
        /// <param name="dateE"></param>
        /// <returns></returns>
        public List<ABS> GetByDeptDateRange_Dlo(string dept,DateTime dateB, DateTime dateE, string[] AyearRestArr)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<ABS>(l => l.BASE);
            dlo.LoadWith<BASE>(l => l.BASETTS);
            dlo.LoadWith<BASETTS>(l => l.JOB1);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);
            dlo.LoadWith<ABS>(l => l.HCODE);
            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.ABS
                        where c.BDATE >= dateB && c.BDATE <= dateE && c.BASE.BASETTS.Any(b => b.DEPT == dept)
                        && AyearRestArr.Contains(c.HCODE.YEAR_REST)
                        select c).ToList();
            }
        }
    }
}