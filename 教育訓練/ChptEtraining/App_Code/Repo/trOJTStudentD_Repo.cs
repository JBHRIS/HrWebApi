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
    public class trOJTStudentD_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public trOJTStudentD_Repo()
        {
            dc = new dcTrainingDataContext();
        }

        public trOJTStudentD_Repo(System.Data.Common.DbConnection conn)
        {
            dc = new dcTrainingDataContext(conn);
        }

        public trOJTStudentD_Repo(dcTrainingDataContext d)
        {            
            dc = d;            
        }


        public List<trOJTStudentD> GetByNobrOjtCode(string Anobr, string AojtCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trOJTStudentD
                        where c.sNobr == Anobr && c.OJT_sCode==AojtCode
                        select c).ToList();
            }
        }


        public trOJTStudentD GetByNobrCourse(string nobr, string courseCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trOJTStudentD
                        where c.sNobr == nobr && c.trCourse_sCode == courseCode
                        select c).FirstOrDefault();
            }
        }


        public trOJTStudentD GetByOjtCodeNobrCourse(string nobr,string ojtCode ,string courseCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trOJTStudentD
                        where c.sNobr == nobr && c.trCourse_sCode == courseCode && c.OJT_sCode==ojtCode
                        select c).FirstOrDefault();
            }
        }


        /// <summary>
        /// 抓取資料 by 工號、課程代碼、是否pass
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="courseCode"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public trOJTStudentD GetByNobrPassCourse(string nobr, string courseCode, bool pass)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trOJTStudentD
                        where c.sNobr == nobr && c.trCourse_sCode == courseCode && c.bPass ==pass
                        select c).FirstOrDefault();
            }
        }

        public trOJTStudentD GetByNobrPassCourse(string nobr, string courseCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trOJTStudentD
                        where c.sNobr == nobr && c.trCourse_sCode == courseCode
                        select c).FirstOrDefault();
            }
        }


        public void Update(trOJTStudentD o)
        {
            DcHelper.Detach(o);
            dc.trOJTStudentD.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Add(trOJTStudentD o)
        {
            dc.trOJTStudentD.InsertOnSubmit(o);            
        }

        public void Delete(trOJTStudentD o)
        {
            DcHelper.Detach(o);
            dc.trOJTStudentD.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trOJTStudentD.DeleteOnSubmit(o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<trOJTStudentD> GetByNobr(string Anobr)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trOJTStudentD
                        where c.sNobr==Anobr
                        select c).ToList();
            }
        }


        public List<trOJTStudentD> GetByNobrCourseList(string Anobr, List<string> AcourseList)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trOJTStudentD
                        where c.sNobr == Anobr
                        && AcourseList.Contains(c.trCourse_sCode)
                        select c).ToList();
            }
        }



        /// <summary>
        /// 抓取需OJT區主管最後簽核確認的人員 By部門
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        public List<trOJTStudentD> GetNeedFinalCheckByDept(string dept)
        {
            DateTime datetime = DateTime.Now.Date;
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                ldc.Log = new DebuggerWriter();
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trOJTStudentD>(l => l.BASETTS);
                dlo.LoadWith<trOJTStudentD>(l => l.trCourse);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<BASETTS>(l => l.BASE);
                dlo.LoadWith<trOJTStudentD>(l => l.trOJTStudentM);
                ldc.LoadOptions = dlo;
                return (from c in ldc.trOJTStudentD
                        where c.dCheckDate !=null 
                        && (c.bPass ==false ||c.bPass ==null)
                        && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(c.BASETTS.TTSCODE)
                        && c.BASETTS.ADATE <= datetime
                        && c.BASETTS.DDATE >= datetime
                        && c.BASETTS.DEPT == dept
                        && c.trOJTStudentM != null  //要有被給卡資料
                        select c).ToList();
            }

        }
    }
}