using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

namespace Repo
{
    /// <summary>
    /// trTrainingStudentM 的摘要描述
    /// </summary>
    public class trTrainingDetailM_Repo
    {
        private trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
        public dcTrainingDataContext dc { get; set; }
        public trTrainingDetailM_Repo()
        {
            dc = new dcTrainingDataContext();
        }

        public trTrainingDetailM_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Add(trTrainingDetailM o)
        {
            dc.trTrainingDetailM.InsertOnSubmit(o);
        }

        public void Delete(trTrainingDetailM o)
        {
            DcHelper.Detach(o);
            dc.trTrainingDetailM.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trTrainingDetailM.DeleteOnSubmit(o);
        }

        public void DeleteByPK(int id)
        {
            var obj = (from c in dc.trTrainingDetailM
                       where c.iAutoKey == id
                       select c).FirstOrDefault();
            dc.trTrainingDetailM.DeleteOnSubmit(obj);
        }

        public void Update(trTrainingDetailM o)
        {
            DcHelper.Detach(o);
            dc.trTrainingDetailM.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public trTrainingDetailM GetByPK(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from dm in ldc.trTrainingDetailM
                        where dm.iAutoKey == classID
                        select dm).FirstOrDefault();
            }
        }

        public List<trTrainingDetailM> GetByCourseCode(string courseCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trTrainingDetailM
                        where c.trCourse_sCode == courseCode
                        select c).ToList();
            }
        }

        public trTrainingDetailM GetByKey_DLO(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trAttendClassTeacher);
                dlo.LoadWith<trTrainingDetailM>(l => l.trTrainingStudentM);
                dlo.LoadWith<trTrainingDetailM>(l => l.trAttendClassDate);
                dlo.LoadWith<trTrainingDetailM>(l => l.ClassTeacher);
                dlo.LoadWith<ClassTeacher>(l => l.trTeacher);
                ldc.LoadOptions = dlo;
                return (from dm in ldc.trTrainingDetailM
                        where dm.iAutoKey == classID
                        select dm).SingleOrDefault();
            }
        }

        /// <summary>
        /// 抓取 by 年度，開課日期區間
        /// </summary>
        /// <param name="year"></param>
        /// <param name="adate"></param>
        /// <param name="ddate"></param>
        /// <returns></returns>
        public List<trTrainingDetailM> GetByYearDateRange_DLO(int year, DateTime adate, DateTime ddate)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trAttendClassTeacher);
                dlo.LoadWith<trTrainingDetailM>(l => l.trTrainingStudentM);
                ldc.LoadOptions = dlo;
                return (from dm in ldc.trTrainingDetailM
                        where dm.iYear == year
                        && dm.dDateA >= adate
                        && dm.dDateA <= ddate
                        orderby dm.dDateA
                        select dm).ToList();
            }
        }


        /// <summary>
        /// 抓取 by 年度
        /// </summary>
        /// <param name="year"></param>
        /// <param name="adate"></param>
        /// <param name="ddate"></param>
        /// <returns></returns>
        public List<trTrainingDetailM> GetByYear_Dlo(int year)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trAttendClassTeacher);
                dlo.LoadWith<trTrainingDetailM>(l => l.trTrainingStudentM);
                ldc.LoadOptions = dlo;
                return (from dm in ldc.trTrainingDetailM
                        where dm.iYear == year
                        orderby dm.iAutoKey descending
                        select dm).ToList();
            }
        }

        public List<trTrainingDetailM> GetByDateRange_Dlo(DateTime AdateB, DateTime AdateE, string AteacherCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trAttendClassTeacher);
                ldc.LoadOptions = dlo;
                return (from dm in ldc.trTrainingDetailM
                        where dm.dDateA.Value >= AdateB && dm.dDateA.Value <= AdateE
                        && dm.trAttendClassTeacher.Any(t=>t.sTeacherCode.Equals(AteacherCode))
                        select dm).ToList();
            }

        }


        public List<trTrainingDetailM> GetByAll()
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from dm in ldc.trTrainingDetailM
                        select dm).ToList();
            }
        }

        /// <summary>
        /// 抓取 by 開課日期區間，已發佈課程
        /// </summary>
        /// <param name="adate"></param>
        /// <param name="ddate"></param>
        /// <returns></returns>
        public List<trTrainingDetailM> GetByDateRangePublished_DLO(DateTime adate, DateTime ddate)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trAttendClassTeacher);
                dlo.LoadWith<trTrainingDetailM>(l => l.trAttendClassDate);
                dlo.LoadWith<trTrainingDetailM>(l => l.trTrainingMethod);
                dlo.LoadWith<trAttendClassDate>(l => l.trAttendClassPlace);
                dlo.LoadWith<trAttendClassPlace>(l => l.trClassroom);
                dlo.LoadWith<trTrainingDetailM>(l => l.ClassTeacher);
                dlo.LoadWith<ClassTeacher>(l => l.trTeacher);
                dlo.LoadWith<trTrainingDetailM>(l => l.trTrainingStudentM);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                ldc.LoadOptions = dlo;
                return (from dm in ldc.trTrainingDetailM
                        where dm.dDateA >= adate
                        && dm.dDateA <= ddate
                        && dm.bIsPublished == true
                        orderby dm.dDateA
                        select dm).ToList();
            }
        }

        /// <summary>
        /// 抓取以現在時間可網路報名的課程By 年度
        /// </summary>
        /// <param name="year">年度</param>
        /// <returns></returns>
        public List<trTrainingDetailM> GetByYear_WebRegisterable_DLO(int year)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;
                return (from dm in ldc.trTrainingDetailM
                        where dm.iYear == year
                        && dm.bWebJoin == true
                        && dm.bIsPublished == true
                        && dm.dWebJoinDateE >= DateTime.Now
                        select dm).ToList();
            }
        }


        public List<trTrainingDetailM> GetByManagerScoreClassReport_Dlo(DateTime bDatetime, DateTime eDatetime)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;
                var list= (from dm in ldc.trTrainingDetailM
                        where dm.bIsPublished == true
                        && dm.dDateA >=bDatetime
                        && dm.dDateD <= eDatetime
                        && DateTime.Now >= dm.dDateTimeD
                        && dm.IsManagerScoreStudentClassReport  
                        && dm.bIsNeedClassRpt
                        orderby dm.dDateA
                        select dm).ToList();
                return list;
            }

        }


        /// <summary>
        /// 抓取以現在時間可網路報名的課程
        /// </summary>
        /// <returns></returns>
        public List<trTrainingDetailM> GetByNow_WebRegisterable_DLO()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;
                return (from dm in ldc.trTrainingDetailM
                        where dm.bIsPublished == true
                        && dm.bWebJoin == true
                        && dm.dWebJoinDateE >= DateTime.Now
                        select dm).ToList();
            }
        }

        /// <summary>
        /// 抓取課程 By 課程編號、梯次、是否發布
        /// </summary>
        /// <param name="AcourseCode"></param>
        /// <param name="Asession"></param>
        /// <param name="AisPublished"></param>
        /// <returns></returns>
        public List<trTrainingDetailM> GetByCourseCodeYearSessionIsPublished(string AcourseCode,int Ayear, int Asession, bool AisPublished)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from dm in ldc.trTrainingDetailM
                        where dm.bIsPublished == AisPublished
                        && dm.trCourse_sCode==AcourseCode
                        && dm.iYear ==Ayear
                        && (dm.iSession.HasValue && dm.iSession.Value==Asession)
                        select dm).ToList();
            }
        }


        /// <summary>
        /// 抓取最新的學員人數 By 課程代碼
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public int GetLatestStudentNum(int classID)
        {
            return tsmRepo.CountByClassID(classID);
        }

        /// <summary>
        /// 確認該課程，講師是否已全部完成學員評分動作。
        /// </summary>
        /// <param name="classID"></param>
        public void CheckIsTeacherFinishClassScore(int classID)
        {
            trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
            var sList = tsmRepo.GetByClassID_WithPresence_DLO(classID);
            var s = (from c in sList where c.dTeacherKeyDate == null select c).FirstOrDefault();

            trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
            trTrainingDetailM tdm= tdmRepo.GetByPK(classID);

            if (s == null)
            {
                tdm.IsTeacherFinishClassScore = true;
            }
            else
            {
                tdm.IsTeacherFinishClassScore = false;
            }

            tdmRepo.Update(tdm);
            tdmRepo.Save();
        }


        /// <summary>
        /// 抓取已發布，未執行的課程
        /// </summary>
        /// <param name="AcourseCode"></param>
        /// <param name="Asession"></param>
        /// <param name="AisPublished"></param>
        /// <returns></returns>
        public List<trTrainingDetailM> GetByCourseNonExecution_Dlo()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                DateTime datetime = DateTime.Now;
                return (from dm in ldc.trTrainingDetailM
                        where dm.bIsPublished
                        && dm.dDateTimeA.Value >= datetime
                        select dm).ToList();
            }
        }



        /// <summary>
        /// 抓取 by 開課日期區間，已發佈課程
        /// </summary>
        /// <param name="adate"></param>
        /// <param name="ddate"></param>
        /// <returns></returns>
        public List<trTrainingDetailM> GetByDateRange_PublishedQA_DLO(DateTime adate , DateTime ddate)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trAttendClassTeacher);
                dlo.LoadWith<trTrainingDetailM>(l => l.trTrainingStudentM);
                dlo.LoadWith<trTrainingDetailM>(l => l.ClassQuestionnaire);
                dlo.LoadWith<ClassQuestionnaire>(l => l.QTpl);
                ldc.LoadOptions = dlo;
                return (from dm in ldc.trTrainingDetailM
                        where dm.dDateA >= adate
                        && dm.dDateA <= ddate
                        && dm.bIsPublished == true
                        orderby dm.dDateA
                        select dm).ToList();
            }
        }
    }
}