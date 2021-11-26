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
    public class BASETTS_Repo
    {
        public dcTrainingDataContext dc { get; set; }
        static public readonly string[] EMP_HIRED_TTSCODE = new string[] { "1", "4", "6" };

        public BASETTS_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public BASETTS_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }




        /// <summary>
        /// 此工號是否在職
        /// </summary>
        /// <param name="nobr">工號</param>
        /// <returns></returns>
        public bool IsHired(string nobr)
        {
            DateTime datetime = DateTime.Now.Date;
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.BASETTS
                        where c.NOBR == nobr
                        && (EMP_HIRED_TTSCODE.Contains(c.TTSCODE))
                        && c.ADATE <= datetime && c.DDATE >= datetime
                        select c).Any();
            }
        }

        /// <summary>
        /// 往上抓取第幾層的部門主管
        /// </summary>
        /// <param name="nobr">工號</param>
        /// <param name="deptLevel">第幾層</param>
        /// <returns></returns>
        public List<BASETTS> GetDeptManagerByNobrDeptLevel(string nobr, int deptLevel)
        {
            DEPT_Repo deptRepo = new DEPT_Repo();

            string deptCode = "";

            BASETTS tts = GetEmpByNobrNow(nobr);
            if (tts != null)
            {
                deptCode = tts.DEPT;
            }

            if (deptLevel > 0)
            {
                while (deptLevel > 0)
                {
                    DEPT dept = deptRepo.GetParentDeptByID(deptCode);
                    if (dept != null)
                        deptCode = dept.D_NO;

                    deptLevel--;
                }
            }

            return GetDeptManagerByDept_DLO(deptCode);
        }

        /// <summary>
        /// 抓取部門主管
        /// </summary>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public List<BASETTS> GetDeptManagerByDept_DLO(string deptCode)
        {            
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<BASETTS>(l => l.BASE);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                ldc.LoadOptions = dlo;
                DateTime datetime = DateTime.Now.Date;
                return (from t in ldc.BASETTS
                        where (t.DEPT == deptCode)
                        && t.MANG == true
                        && (EMP_HIRED_TTSCODE.Contains(t.TTSCODE))
                        && t.ADATE <= datetime && t.DDATE >= datetime
                        select t).ToList();
            }
        }

        /// <summary>
        /// 抓取目前員工資料
        /// </summary>
        /// <param name="nobr"></param>
        /// <returns></returns>
        public BASETTS GetEmpByNobrNow_DLO(string nobr)
        {
            DateTime datetime = DateTime.Now.Date;
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<BASETTS>(l => l.BASE);
            dlo.LoadWith<BASETTS>(l => l.DEPT1);

            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.BASETTS
                        where c.NOBR == nobr
                        && (EMP_HIRED_TTSCODE.Contains(c.TTSCODE))
                        && c.ADATE <= datetime && c.DDATE >= datetime
                        select c).FirstOrDefault();
            }
        }

        public BASETTS GetEmpByNobrNow(string nobr)
        {
            DateTime datetime = DateTime.Now.Date;
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.BASETTS
                        where c.NOBR == nobr
                        && c.ADATE <= datetime && c.DDATE >= datetime
                        && EMP_HIRED_TTSCODE.Contains(c.TTSCODE)
                        select c).FirstOrDefault();
            }
        }
    }
}