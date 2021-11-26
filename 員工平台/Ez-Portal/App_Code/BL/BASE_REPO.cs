using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using JBHRModel;

namespace BL
{
    /// <summary>
    /// BASE_REPO 的摘要描述
    /// </summary>
    public class BASE_REPO
    {
        public JBHRModelDataContext dc { get; set; }

        public BASE_REPO(JBHRModel.JBHRModelDataContext o)
        {
            dc = o;
        }

        public BASE_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public void Update(BASE o)
        {
            DcHelper.Detach(o);
            dc.BASE.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<BASE> GetAll()
        {
            using (JBHRModelDataContext o = new JBHRModelDataContext())
            {
                return (from c in o.BASE select c).ToList();
            }
        }

        public List<BASE> GetAll_Dlo()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASE>(l => l.BankCode);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.DEPTS1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.JOBL1);
                dlo.LoadWith<BASETTS>(l => l.WORKCD1);
                dlo.LoadWith<BASETTS>(l => l.ROTET1);
                //dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                ldc.LoadOptions = dlo;
                ldc.Log = new DebuggerWriter();

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        select c).ToList();
            }
        }

        public List<BASE> GetHiredEmpByDept_Dlo(string deptCode)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASE>(l => l.BankCode);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.DEPTS1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.JOBL1);
                dlo.LoadWith<BASETTS>(l => l.WORKCD1);
                dlo.LoadWith<BASETTS>(l => l.ROTET1);
                dlo.LoadWith<BASETTS>(l => l.OutPost1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        && c.BASETTS.Any(p => p.DEPT == deptCode)
                        select c).ToList();
            }
        }

        public List<BASE> GetHiredEmpByDept_Dlo(List<string> deptCodeList)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASE>(l => l.BankCode);
                dlo.LoadWith<BASE>(l => l.SCHL);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.DEPTS1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.JOBL1);
                dlo.LoadWith<BASETTS>(l => l.JOBO1);
                dlo.LoadWith<BASETTS>(l => l.WORKCD1);
                dlo.LoadWith<BASETTS>(l => l.ROTET1);
                dlo.LoadWith<BASETTS>(l => l.OutPost1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        && c.BASETTS.Any(p => deptCodeList.Contains(p.DEPT))
                        select c).ToList();
            }
        }

        public List<BASE> GetHiredEmpByDept(string deptCode)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        && c.BASETTS.Any(p => p.DEPT == deptCode)
                        select c).ToList();
            }
        }

        public List<BASE> GetHiredEmpByDepta_Dlo(string deptaCode)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASE>(l => l.BankCode);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.DEPTS1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.JOBL1);
                dlo.LoadWith<BASETTS>(l => l.WORKCD1);
                dlo.LoadWith<BASETTS>(l => l.ROTET1);
                dlo.LoadWith<BASETTS>(l => l.OutPost1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        && c.BASETTS.Any(p => p.DEPTM == deptaCode)
                        select c).ToList();
            }
        }

        public List<BASE> GetHiredEmp_Dlo()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASE>(l => l.BankCode);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.DEPTS1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.JOBL1);
                dlo.LoadWith<BASETTS>(l => l.WORKCD1);
                dlo.LoadWith<BASETTS>(l => l.ROTET1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        select c).ToList();
            }
        }

        public List<BASE> GetHiredEmp_Dlo(DateTime Adatetime)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASE>(l => l.BankCode);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.DEPTS1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.JOBL1);
                dlo.LoadWith<BASETTS>(l => l.WORKCD1);
                dlo.LoadWith<BASETTS>(l => l.ROTET1);
                dlo.LoadWith<BASETTS>(l => l.OutPost1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= Adatetime && t.DDATE >= Adatetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        select c).ToList();
            }
        }

        public List<BASE> GetNotHiredEmp_Dlo()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASE>(l => l.BankCode);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.DEPTS1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.JOBL1);
                dlo.LoadWith<BASETTS>(l => l.WORKCD1);
                dlo.LoadWith<BASETTS>(l => l.ROTET1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && !BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        select c).ToList();
            }
        }

        public BASE GetByNobr(string nobr)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.BASE where c.NOBR == nobr select c).FirstOrDefault();
            }
        }

        public BASE GetByNobr_Dlo(string nobr)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                ldc.Log = new DebuggerWriter();
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASE>(l => l.BankCode);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.DEPTS1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.JOBL1);
                dlo.LoadWith<BASETTS>(l => l.WORKCD1);
                dlo.LoadWith<BASETTS>(l => l.ROTET1);
                //dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                ldc.LoadOptions = dlo;
                ldc.Log = new DebuggerWriter();

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        && c.NOBR == nobr
                        select c).FirstOrDefault();
            }
        }

        public BASE GetByNameAD(string Avaule)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;
                return (from c in ldc.BASE
                        where
                            c.BASETTS.Any()
                            && c.NAME_AD == Avaule
                        select c).FirstOrDefault();
            }
        }

        /// <summary>
        /// 查詢員工 By 生日的日期區間
        /// </summary>
        /// <param name="AdateB"></param>
        /// <param name="AdateE"></param>
        /// <returns></returns>
        public List<BASE> GetByBirthDayDateRange_DLO(DateTime AdateB, DateTime AdateE)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                string strB = AdateB.Month.ToString().PadLeft(2, '0') + AdateB.Day.ToString().PadLeft(2, '0');
                string strE = AdateE.Month.ToString().PadLeft(2, '0') + AdateE.Day.ToString().PadLeft(2, '0');

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        && c.BIRDT.HasValue
                        && (c.BIRDT.Value.Month.ToString().PadLeft(2, '0') + c.BIRDT.Value.Day.ToString().PadLeft(2, '0')).CompareTo(strB) >= 0
                        && (c.BIRDT.Value.Month.ToString().PadLeft(2, '0') + c.BIRDT.Value.Day.ToString().PadLeft(2, '0')).CompareTo(strE) <= 0
                        select c).ToList();
            }
        }

        public List<BASE> GetByBirthDayDateRange_DLO(DateTime AdateB, DateTime AdateE, string AcompId)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                string strB = AdateB.Month.ToString().PadLeft(2, '0') + AdateB.Day.ToString().PadLeft(2, '0');
                string strE = AdateE.Month.ToString().PadLeft(2, '0') + AdateE.Day.ToString().PadLeft(2, '0');

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        && c.BIRDT.HasValue
                        && c.BASETTS.Any(p => p.COMP == AcompId)
                        && (c.BIRDT.Value.Month.ToString().PadLeft(2, '0') + c.BIRDT.Value.Day.ToString().PadLeft(2, '0')).CompareTo(strB) >= 0
                        && (c.BIRDT.Value.Month.ToString().PadLeft(2, '0') + c.BIRDT.Value.Day.ToString().PadLeft(2, '0')).CompareTo(strE) <= 0
                        select c).ToList();
            }
        }

        /// <summary>
        /// 給 WCF用
        /// </summary>
        /// <returns></returns>
        public List<BASE> GetByHiredEmpUserDept_Dlo()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.DEPTA);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
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
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where (c.NOBR == Str || c.NAME_C.Contains(Str))
                        && c.BASETTS.Any()
                        select c).ToList();
            }
        }

        public List<BASE> GetHiredEmpBySeachKey_DLO(string Str, List<string> deptList)
        {
            if (Str.Length == 0)
                return new List<BASE>();
            //dc.Log = new DebuggerWriter();
            DateTime datetime = DateTime.Now.Date;
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where (c.NOBR.Contains(Str) || c.NAME_C.Contains(Str) || c.NAME_E.Contains(Str))
                        && c.BASETTS.Any()
                        && c.BASETTS.Any(p => deptList.Contains(p.DEPT))
                        select c).ToList();
            }
        }

        public List<BASE> GetHiredEmpBySeachKeyExt_DLO(string Str, List<string> deptList)
        {
            if (Str.Length == 0)
                return new List<BASE>();
            //dc.Log = new DebuggerWriter();
            DateTime datetime = DateTime.Now.Date;
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where (c.NOBR.Contains(Str) || c.NAME_C.Contains(Str) ||
                         c.NAME_E.Contains(Str) || c.BASETTS.Any(p => p.JOB1.JOB_NAME.Contains(Str))
                         || c.BASETTS.Any(p => p.DEPT1.D_NAME.Contains(Str)))
                        && c.BASETTS.Any()
                        && c.BASETTS.Any(p => deptList.Contains(p.DEPT))
                        select c).ToList();
            }
        }

        public List<BASE> GetHiredEmpBySeachKeyExt_DLO(string Str)
        {
            if (Str.Length == 0)
                return new List<BASE>();
            //dc.Log = new DebuggerWriter();
            DateTime datetime = DateTime.Now.Date;
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where (c.NOBR.Contains(Str) || c.NAME_C.Contains(Str) ||
                         c.NAME_E.Contains(Str) || c.BASETTS.Any(p => p.JOB1.JOB_NAME.Contains(Str))
                         || c.BASETTS.Any(p => p.DEPT1.D_NAME.Contains(Str)))
                        && c.BASETTS.Any()
                        select c).ToList();
            }
        }

        public List<BASE> GetHiredEmpBySalaDr_Dlo(List<string> salaDrList)
        {
            DateTime datetime = DateTime.Now.Date;
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                //dlo.LoadWith<BASETTS>(l => l.JOB1);
                //dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.BASETTS.Any(p => salaDrList.Contains(p.SALADR))
                        && c.BASETTS.Any()
                        select c).ToList();
            }
        }

        public List<BASE> GetBySalaDr_Dlo(List<string> salaDrList)
        {
            DateTime datetime = DateTime.Now.Date;
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                //dlo.LoadWith<BASETTS>(l => l.JOB1);
                //dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.BASETTS.Any(p => salaDrList.Contains(p.SALADR))
                        && c.BASETTS.Any()
                        select c).ToList();
            }
        }

        /// <summary>
        /// 抓取HR 管理的公司，先抓取他的資料群組再對應到公司
        /// </summary>
        /// <param name="Anobr">登入的帳號</param>
        /// <returns></returns>
        public List<COMP> GetHrManageCompByNobr(string Anobr)
        {
            DateTime datetime = DateTime.Now.Date;
            List<COMP> resultList = new List<COMP>();
            U_USER_REPO uUserRepo = new U_USER_REPO();
            U_USER uUserObj = uUserRepo.GetByNobr(Anobr);

            if (uUserObj == null)
                return resultList;

            if (uUserObj.ADMIN)
            {
                COMP_REPO compRepo = new COMP_REPO();
                resultList.AddRange(compRepo.GetAll());
            }
            else
            {
                U_DATAGROUP_REPO uDataGroupRepo = new U_DATAGROUP_REPO();
                List<U_DATAGROUP> udpList = uDataGroupRepo.GetByUserId_Dlo(uUserObj.USER_ID);
                resultList.AddRange(udpList.Select(p => p.COMP).Distinct().ToList());
            }
            return resultList;
        }

        /// <summary>
        /// Get By 身分證號
        /// </summary>
        /// <param name="idno"></param>
        /// <returns></returns>
        public BASE GetByIDNO(string idno)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.BASE
                        where c.IDNO == idno
                        select c).FirstOrDefault();
            }
        }

        /// <summary>
        /// 抓取目前員工資料
        /// </summary>
        /// <param name="nobr"></param>
        /// <returns></returns>
        public BASE GetEmpByNobrNow_DLO(string nobr)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                //dlo.LoadWith<BASETTS>(l => l.DEPTA);
                //dlo.LoadWith<BASETTS>(l => l.COMP1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;
                ldc.Log = new DebuggerWriter();
                return (from c in ldc.BASE
                        where c.NOBR == nobr
                        && c.BASETTS.Any()
                        select c).FirstOrDefault();
            }
        }

        public List<BASE> GetEmpByExtTelSearch_Dlo(string value)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;
                ldc.Log = new DebuggerWriter();
                return (from c in ldc.BASE
                        where (
                        c.NOBR.Contains(value)
                        || c.NAME_C.Contains(value)
                        || c.NAME_E.Contains(value)
                        || c.BASETTS.Any(p => p.JOB1.JOB_NAME.Contains(value))
                        )
                        && c.BASETTS.Any()
                        select c).ToList();
            }
        }

        public List<BASE> GetEmpByDept_Dlo(string value)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;
                ldc.Log = new DebuggerWriter();
                return (from c in ldc.BASE
                        where c.BASETTS.Any(p => p.DEPT == value)
                        && c.BASETTS.Any()
                        select c).ToList();
            }
        }

        public List<BASE> GetHiredEmpRole_Dlo()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASE>(l => l.sysUserRole);
                dlo.LoadWith<sysUserRole>(l => l.sysRole);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from c in ldc.BASE
                        where c.BASETTS.Any()
                        select c).ToList();
            }
        }
    }
}