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
    public class ABS1_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public ABS1_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public ABS1_REPO()
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
        public List<EmpAbs1List> GetByNobrDateRange_Dlo(string nobr, DateTime dateB, DateTime dateE)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<ABS1>(l => l.BASE);
            dlo.LoadWith<BASE>(l => l.BASETTS);
            dlo.LoadWith<BASETTS>(l => l.JOB1);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);
            dlo.LoadWith<ABS1>(l => l.HCODE);
            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));

            using (JBHRModelDataContext loc = new JBHRModelDataContext())
            {
                loc.LoadOptions = dlo;
                return (from c in loc.ABS1
                        where c.BDATE >= dateB && c.BDATE <= dateE && c.NOBR == nobr
                        select new EmpAbs1List
                        {
                            AbsBtime = c.BTIME,
                            AbsEtime = c.ETIME,
                            AbsDate = c.BDATE,
                            DeptName = c.BASE.BASETTS[0].DEPT1.D_NAME,
                            H_Code = c.H_CODE,
                            H_CodeName = c.HCODE.H_NAME,
                            H_CodeUnit = c.HCODE.UNIT,
                            JobName= c.BASE.BASETTS[0].JOB1.JOB_NAME,
                            NameC = c.BASE.NAME_C,
                            NameE = c.BASE.NAME_E,
                            Nobr = c.NOBR,
                            Reason = c.REASON,
                            NOTE=c.NOTE,
                            TOL_HOURS = c.TOL_HOURS,
                            YYMM = c.YYMM
                        }).ToList();
            }
        }


        /// <summary>
        /// 查詢 by 工號、日期區間
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="dateB"></param>
        /// <param name="dateE"></param>
        /// <returns></returns>
        public List<ABS1> GetByNobrDateRange_Dlo(string nobr, DateTime dateB, DateTime dateE, string[] AyearRestArr)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<ABS1>(l => l.BASE);
            dlo.LoadWith<BASE>(l => l.BASETTS);
            dlo.LoadWith<BASETTS>(l => l.JOB1);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);
            dlo.LoadWith<ABS1>(l => l.HCODE);
            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.ABS1
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
        public List<EmpAbs1List> GetByDeptDateRange_Dlo(string dept, DateTime dateB, DateTime dateE)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<ABS1>(l => l.BASE);
            dlo.LoadWith<BASE>(l => l.BASETTS);
            dlo.LoadWith<BASETTS>(l => l.JOB1);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);
            dlo.LoadWith<ABS1>(l => l.HCODE);
            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));

            using (JBHRModelDataContext loc = new JBHRModelDataContext())
            {
                loc.LoadOptions = dlo;
                return (from c in loc.ABS1
                        where c.BDATE >= dateB && c.BDATE <= dateE && c.BASE.BASETTS.Any(b=>b.DEPT==dept)
                        select new EmpAbs1List
                        {
                            AbsBtime = c.BTIME,
                            AbsEtime = c.ETIME,
                            AbsDate = c.BDATE,
                            DeptName = c.BASE.BASETTS[0].DEPT1.D_NAME,
                            H_Code = c.H_CODE,
                            H_CodeName = c.HCODE.H_NAME,
                            H_CodeUnit = c.HCODE.UNIT,
                            JobName = c.BASE.BASETTS[0].JOB1.JOB_NAME,
                            NameC = c.BASE.NAME_C,
                            NameE = c.BASE.NAME_E,
                            Nobr = c.NOBR,
                            Reason = c.REASON,
                            NOTE=c.NOTE,
                            TOL_HOURS = c.TOL_HOURS,
                            YYMM = c.YYMM
                        }).ToList();
            }
        }


        /// <summary>
        /// 查詢 by 日期區間
        /// </summary>        
        /// <param name="dateB"></param>
        /// <param name="dateE"></param>
        /// <returns></returns>
        public List<ABS1> GetByDateRange_Dlo(DateTime dateB, DateTime dateE, string[] AyearRestArr)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<ABS1>(l => l.BASE);
            dlo.LoadWith<BASE>(l => l.BASETTS);
            dlo.LoadWith<BASETTS>(l => l.JOB1);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);
            dlo.LoadWith<ABS1>(l => l.HCODE);
            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.ABS1
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
        public List<ABS1> GetByDeptDateRange_Dlo(string dept, DateTime dateB, DateTime dateE, string[] AyearRestArr)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<ABS1>(l => l.BASE);
            dlo.LoadWith<BASE>(l => l.BASETTS);
            dlo.LoadWith<BASETTS>(l => l.JOB1);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);
            dlo.LoadWith<ABS1>(l => l.HCODE);
            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.ABS1
                        where c.BDATE >= dateB && c.BDATE <= dateE && c.BASE.BASETTS.Any(b => b.DEPT == dept)
                        && AyearRestArr.Contains(c.HCODE.YEAR_REST)
                        select c).ToList();
            }
        }

    }    
}