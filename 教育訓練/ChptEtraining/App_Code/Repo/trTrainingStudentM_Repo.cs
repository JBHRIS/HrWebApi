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
    public class trTrainingStudentM_Repo
    {
        public dcTrainingDataContext dc { get; set; }
        QAMaster_Repo qaRepo = new QAMaster_Repo();
        public trTrainingStudentM_Repo()
        {
            dc = new dcTrainingDataContext();
        }

        public trTrainingStudentM_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Update(trTrainingStudentM o)
        {
            DcHelper.Detach(o);
            dc.trTrainingStudentM.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public trTrainingStudentM GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.trTrainingStudentM
                        where sm.iAutoKey == id
                        select sm).FirstOrDefault();
            }
        }


        public trTrainingStudentM GetByPk_DLO(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;
                return (from sm in ldc.trTrainingStudentM
                        where sm.iAutoKey == id
                        select sm).FirstOrDefault();
            }
        }



        public trTrainingStudentM GetByPkWithPresence_DLO(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.iAutoKey == id
                        && sm.bPresence == true
                        select sm).FirstOrDefault(); ;
            }
        }

        /// <summary>
        /// By ClassID
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<trTrainingStudentM> GetByClassID_DLO(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DateTime datetime = DateTime.Now;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.iClassAutoKey == classID                        
                        select sm).ToList();
            }
        }

        /// <summary>
        /// 傳回未填寫學員表現評分表的的學員，且有出席 By Date Range
        /// 20120822 加上離職人員判斷，離職人員不抓
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<trTrainingStudentM> GetNeedStudentScoreByDateRangeWithTeacherKeyDateNull_DLO(DateTime bDate, DateTime eDate)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                // ldc.Log = new DebuggerWriter();
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                //dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.ClassTeacher);
                dlo.LoadWith<ClassTeacher>(l => l.trTeacher);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.dTeacherKeyDate == null
                        && sm.bPresence == true
                        && sm.trTrainingDetailM.bIsPublished
                        && sm.trTrainingDetailM.dDateA.Value >= bDate
                        && sm.trTrainingDetailM.dDateA.Value <= eDate
                        && DateTime.Now >= sm.trTrainingDetailM.dDateTimeD.Value
                        && sm.trTrainingDetailM.bIsNeedStudentScore
                        && sm.BASE.BASETTS.Any()
                        select sm).ToList();
            }
        }



        /// <summary>
        /// 傳回未填寫學員心得的學員，且有出席 By Date Range
        /// 離職人員不抓
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<trTrainingStudentM> GetClassRptLostByStudentDateRange_DLO(DateTime bDate, DateTime eDate)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                //dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.ClassTeacher);
                dlo.LoadWith<ClassTeacher>(l => l.trTeacher);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.dNote2KeyDate == null
                        && sm.bPresence == true
                        && sm.trTrainingDetailM.bIsPublished
                        && sm.trTrainingDetailM.dDateA.Value >= bDate
                        && sm.trTrainingDetailM.dDateA.Value <= eDate
                        && DateTime.Now >= sm.trTrainingDetailM.dDateTimeD.Value
                        && sm.trTrainingDetailM.bIsNeedClassRpt
                        && sm.BASE.BASETTS.Any()
                        select sm).ToList();
            }
        }


        /// <summary>
        /// 傳回未填寫學員心得的學員，且有出席 By Date 日期以內的
        /// 離職人員不抓
        /// </summary>
        /// <param name="date">此日期以內的</param>
        /// <returns></returns>
        public List<trTrainingStudentM> GetClassRptLostByDate_Dlo(DateTime date)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.ClassTeacher);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.dNote2KeyDate == null
                        && sm.bPresence == true
                        && sm.trTrainingDetailM.bIsPublished
                        && sm.trTrainingDetailM.dClassRptDeadline >= date
                        && sm.trTrainingDetailM.dDateTimeD.Value <= date
                        && sm.trTrainingDetailM.bIsNeedClassRpt
                        && sm.BASE.BASETTS.Any()
                        select sm).ToList();
            }
        }



        /// <summary>
        /// 傳回未填寫學員心得分數的講師，且有出席 By Date Range
        /// 離職人員不抓
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<trTrainingStudentM> GetClassRptLostByTeacherDateRange_DLO(DateTime bDate, DateTime eDate)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                //dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.ClassTeacher);
                dlo.LoadWith<ClassTeacher>(l => l.trTeacher);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.dNote2KeyDate != null
                        && sm.dNote2ScoreKeyDate == null
                        && sm.bPresence == true
                        && sm.trTrainingDetailM.bIsPublished
                        && sm.trTrainingDetailM.dDateA.Value >= bDate
                        && sm.trTrainingDetailM.dDateA.Value <= eDate
                        && DateTime.Now >= sm.trTrainingDetailM.dDateTimeD.Value
                        && sm.trTrainingDetailM.bIsNeedClassRpt
                        && sm.BASE.BASETTS.Any()
                        select sm).ToList();
            }
        }



        /// <summary>
        /// 傳回未填寫學員心得分數的講師，且有出席 By Date Range
        /// 離職人員不抓
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<trTrainingStudentM> GetClassRptLostNeedManagerFillDateRange_Dlo(DateTime bDate , DateTime eDate)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<BASETTS>(l => l.DEPT1);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.ClassTeacher);
                //dlo.LoadWith<ClassTeacher>(l => l.trTeacher);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.dNote2KeyDate != null
                        && sm.dNote2ScoreKeyDate == null
                        && sm.bPresence == true
                        && sm.trTrainingDetailM.bIsPublished
                        && sm.trTrainingDetailM.dDateA.Value >= bDate
                        && sm.trTrainingDetailM.dDateA.Value <= eDate
                        && DateTime.Now >= sm.trTrainingDetailM.dDateTimeD.Value
                        && sm.trTrainingDetailM.bIsNeedClassRpt
                        && sm.trTrainingDetailM.IsManagerScoreStudentClassReport
                        && sm.BASE.BASETTS.Any()                        
                        select sm).ToList();
            }
        }



        /// <summary>
        /// 傳回有出席的學員By ClassID
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<trTrainingStudentM> GetByClassID_WithPresence_DLO(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.iClassAutoKey == classID
                        && sm.bPresence == true
                        select sm).ToList();
            }
        }


        /// <summary>
        /// 抓取一個trTrainingStudentM集合中，沒有輸入心得報告的
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<trTrainingStudentM> GetNeedToFillClassRpt(List<trTrainingStudentM> list)
        {
            return (from c in list
                    where c.trTrainingDetailM.bIsNeedClassRpt == true &&
                        c.dNote2KeyDate.HasValue == false
                    select c).ToList();
        }


        public List<trTrainingStudentM> GetNeedToFillQuestionary(List<trTrainingStudentM> list)
        {
            List<trTrainingStudentM> resultList = new List<trTrainingStudentM>();
            foreach (var l in list)
            {
                var a = qaRepo.GetByNobrClassId(l.sNobr, l.trTrainingDetailM.iAutoKey).Any(p => !p.WriteDate.HasValue);
                if (a)
                    resultList.Add(l);
            }

            return resultList;
        }


        public List<trTrainingStudentM> GetByNobrYearPresence_DLO(string nobr, int year)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.sNobr == nobr
                        && sm.trTrainingDetailM.iYear == year
                        && sm.bPresence == true
                        select sm).ToList();
            }
        }

        /// <summary>
        /// 傳回學員名單 by 工號、日期區間
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="timeB"></param>
        /// <param name="timeE"></param>
        /// <returns></returns>
        public List<trTrainingStudentM> GetByNobrDateRange_Dlo(string nobr, DateTime timeB, DateTime timeE)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trTrainingDetailM>(l => l.trTrainingMethod);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.sNobr == nobr
                        && sm.trTrainingDetailM.dDateTimeA.Value >= timeB
                        && sm.trTrainingDetailM.dDateTimeA.Value <= timeE
                        select sm).ToList();
            }
        }


        /// <summary>
        /// 傳回學員名單 by 工號、日期區間、是否通過
        /// </summary>
        /// <param name="Anobr"></param>
        /// <param name="AdatetimeB"></param>
        /// /// <param name="AdatetimeE"></param>
        /// /// /// <param name="Apass"></param>
        /// <returns></returns>
        public List<trTrainingStudentM> GetByNobrDateRangePass_DLO(string Anobr, DateTime AdatetimeB, DateTime AdatetimeE, bool Apass)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.sNobr == Anobr
                        && sm.bPass == Apass
                        && sm.trTrainingDetailM.dDateTimeA.Value >= AdatetimeB
                        && sm.trTrainingDetailM.dDateTimeA.Value <= AdatetimeE
                        select sm).ToList();
            }
        }


        public List<trTrainingStudentM> GetByAllDeptChildYear_DLO(string dept, int year)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.sDeptCode == dept
                        && sm.trTrainingDetailM.iYear == year
                        //select new { sm.sNobr, sm.BASE.NAME_C, sm.DEPT.D_NAME, sm.trTrainingDetailM.iSession }).ToList();
                        select sm).ToList();
            }
        }


        public trTrainingStudentM GetByNobrClassId_DLO(string Anobr, int AclassId)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.iClassAutoKey == AclassId
                        && sm.sNobr == Anobr
                        select sm).FirstOrDefault();
            }
        }


        public List<trTrainingStudentM> GetByDeptYear_DLO(string dept, int year)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.sDeptCode == dept
                        && sm.trTrainingDetailM.iYear == year
                        //select new { sm.sNobr, sm.BASE.NAME_C, sm.DEPT.D_NAME, sm.trTrainingDetailM.iSession }).ToList();
                        select sm).ToList();
            }
        }

        public List<trTrainingStudentM> GetByDeptListYearPresence_DLO(List<DEPT> deptList, int year)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where (from c in deptList select c.D_NO).Contains(sm.sDeptCode)
                        && sm.trTrainingDetailM.iYear == year
                        && sm.bPresence == true
                        select sm).ToList();
            }
        }

        /// <summary>
        /// 抓取部門已報名名單
        /// </summary>
        /// <param name="deptCode">部門代碼</param>
        /// <returns></returns>
        public List<trTrainingStudentM> GetRegisteredByDept_DLO(string deptCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTrainingStudentM>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingStudentM>(l => l.DEPT);
                dlo.LoadWith<trTrainingStudentM>(l => l.BASE);
                //dlo.LoadWith<trTrainingDetailM>(l => l.trCategory);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                return (from sm in ldc.trTrainingStudentM
                        where sm.sDeptCode == deptCode
                        && sm.trTrainingDetailM.bIsPublished == true
                        && sm.trTrainingDetailM.dDateTimeA > DateTime.Now
                        select sm).ToList();
            }
        }

        /// <summary>
        /// 計算課程學員人數
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>

        public int CountByClassID(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trTrainingStudentM
                        where c.iClassAutoKey == classID
                        select c).Count();
            }
        }


        //刪除訓練名單，刪除結訓條件，上課簽到
        //20120625增加刪除問卷
        public void DelStudent(int classKey, string nobr)
        {
            dcTrainingDataContext dcTraining = new dcTrainingDataContext();
            var student = (from c in dcTraining.trTrainingStudentM
                           where c.iClassAutoKey == classKey && c.sNobr == nobr
                           select c).FirstOrDefault();

            var classObj = (from c in dcTraining.trTrainingDetailM
                            where c.iAutoKey == classKey
                            select c).FirstOrDefault();

            if (student != null)
            {
                //訓練名單
                dcTraining.trTrainingStudentM.DeleteOnSubmit(student);

                //結訓
                var s1 = from c in dcTraining.trTrainingStudentS
                         where c.trTrainingStudentM_ID == student.iAutoKey
                         select c;

                dcTraining.trTrainingStudentS.DeleteAllOnSubmit(s1);

                //簽到
                var s2 = from c in dcTraining.trTrainingStudentPresence
                         where c.trTrainingStudentM_ID == student.iAutoKey
                         select c;

                dcTraining.trTrainingStudentPresence.DeleteAllOnSubmit(s2);

                //課程異常
                var s3 = from c in dcTraining.trClassStudentError
                         where c.TrainingStudentM_ID == student.iAutoKey
                         select c;
                dcTraining.trClassStudentError.DeleteAllOnSubmit(s3);

                //問卷
                var baseM = from c in dcTraining.qBaseM
                            where c.sNobr == student.sNobr &&
                            c.iClassAutoKey == classObj.iAutoKey
                            select c;

                dcTraining.qBaseM.DeleteAllOnSubmit(baseM);


                trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
                dcTraining.SubmitChanges();
                classObj.iStudentNum = tdmRepo.GetLatestStudentNum(classObj.iAutoKey);
                dcTraining.SubmitChanges();
            }
        }



        /// <summary>
        ///單一學員加入訓練名單
        /// 產生結訓條件，上課簽到 
        /// </summary>
        /// <param name="classKey">開課代碼</param>
        /// <param name="nobr">工號</param>
        public void AddStudent(int classKey, string nobr, string keyMan)
        {
            dcTrainingDataContext dcTraining = new dcTrainingDataContext();

            var student = (from c in dcTraining.trTrainingStudentM
                           where c.iClassAutoKey == classKey && c.sNobr == nobr
                           select c).FirstOrDefault();

            if (student != null)
            {
                throw new ApplicationException("訓練名單已有此人");
            }

            var classObj = (from c in dcTraining.trTrainingDetailM
                            where c.iAutoKey == classKey
                            select c).FirstOrDefault();

            int studentNum = (from c in dcTraining.trTrainingStudentM
                              where c.iClassAutoKey == classKey
                              select c).Count();

            if (classObj.iUpLimitP.HasValue)
            {
                //上限人數0，代表無上限
                if (classObj.iUpLimitP.Value <= studentNum && classObj.iUpLimitP.Value != 0)
                {
                    var course = (from c in dcTraining.trCourse
                                  where c.sCode == classObj.trCourse_sCode
                                  select c).FirstOrDefault();

                    if (course == null)
                    {
                        throw new ApplicationException("無此課程!!");
                    }

                    trErrorNotify obj = new trErrorNotify();
                    obj.ErrorMsg = "工號:" + nobr + "報名課程" + classObj.dDateA.Value.ToShortDateString() + course.sName + "失敗，報名額滿。";
                    obj.NotifyDate = DateTime.Now;
                    obj.TargetRole = 1;
                    obj.sKeyMan = keyMan;
                    dcTraining.trErrorNotify.InsertOnSubmit(obj);
                    dcTraining.SubmitChanges();
                    throw new ApplicationException("課程人數已額滿!!");
                }
            }

            var tts = (from c in dcTraining.BASETTS
                       where DateTime.Now.Date >= c.ADATE && DateTime.Now.Date <= c.DDATE &&
                       new string[] { "1", "4", "6" }.Contains(c.TTSCODE) &&
                       c.NOBR == nobr
                       select c).FirstOrDefault();

            trTrainingStudentM s = new trTrainingStudentM();
            s.bPass = false;
            s.iClassAutoKey = classKey;
            s.sDeptCode = tts.DEPT;
            s.sJobCode = tts.JOB;
            s.sJoblCode = tts.JOBL;
            s.sJobsCode = tts.JOBS;
            s.sNobr = nobr;
            s.trJoinType_sCode = "02";

            dcTraining.trTrainingStudentM.InsertOnSubmit(s);

            dcTraining.SubmitChanges();


            //trTrainingDetailS  課程結訓條件
            var knotTeaches = (from c in dcTraining.trTrainingDetailS
                               where c.iClassAutoKey == classKey
                               select c).ToList();

            //上課日期
            var classAttendDate = (from c in dcTraining.trAttendClassDate
                                   where c.iClassAutoKey == classKey
                                   select c).ToList();
            //問卷
            var ClassQuestionnaire = (from c in dcTraining.ClassQuestionnaire
                                      where c.iClassAutoKey == classKey
                                      select c).ToList();
            //增加名單必訓條件
            foreach (var k in knotTeaches)
            {
                trTrainingStudentS obj = new trTrainingStudentS();
                obj.trTrainingStudentM_ID = s.iAutoKey;
                obj.trKnotTeaches_sCode = k.trKnotTeaches_sCode;
                obj.iClassAutoKey = classKey;
                obj.bPass = false;
                dcTraining.trTrainingStudentS.InsertOnSubmit(obj);
            }
            //出勤名單
            foreach (var a in classAttendDate)
            {
                trTrainingStudentPresence obj = new trTrainingStudentPresence();
                obj.trTrainingStudentM_ID = s.iAutoKey;
                obj.bPresence = false;
                obj.iClassAutoKey = classKey;
                obj.AttendClassDateID = a.iAutoKey;
                dcTraining.trTrainingStudentPresence.InsertOnSubmit(obj);
            }
            //產生問卷
            ClassQuestionnaireRepo classQRepo = new ClassQuestionnaireRepo();
            var classQuestionnaireList = classQRepo.GetByClassId_Dlo(classKey);
            QAMaster_Repo qaRepo = new QAMaster_Repo();

            foreach (var c in classQuestionnaireList)
            {
                //學員的部份
                if (c.QTpl.FillerCategory.Equals("S"))
                {
                    qaRepo.CreateQA(classKey, c.qQuestionaryM, nobr);
                }
            }

            //學員名單 +1
            //classObj.iStudentNum = classObj.iStudentNum + 1;
            //更新課程學員數量
            trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
            classObj.iStudentNum = tdmRepo.GetLatestStudentNum(classObj.iAutoKey);
            dcTraining.SubmitChanges();
        }




        /// <summary>
        ///依照訓練名單產生結訓條件，上課簽到、問卷 
        /// </summary>
        /// <param name="classKey"></param>
        public void AddStudentByClass(int classKey, string keyMan)
        {
            dcTrainingDataContext dcTraining = new dcTrainingDataContext();
            //訓練名單
            var students = (from c in dcTraining.trTrainingStudentM
                            where c.iClassAutoKey == classKey
                            select c).ToList();

            var classObj = (from c in dcTraining.trTrainingDetailM
                            where c.iAutoKey == classKey
                            select c).FirstOrDefault();

            if (classObj == null)
                throw new ApplicationException("無法找到課程");

            //結訓
            trTrainingStudentS_Repo tssRepo = new trTrainingStudentS_Repo();
            List<trTrainingStudentS> tssList = tssRepo.GetByClassID(classKey);

            ////簽到
            trTrainingStudentPresence_Repo tspRepo = new trTrainingStudentPresence_Repo();
            List<trTrainingStudentPresence> tspList = tspRepo.GetByClassID(classKey);


            //trTrainingDetailS  課程結訓條件
            var knotTeaches = (from c in dcTraining.trTrainingDetailS
                               where c.iClassAutoKey == classKey
                               select c).ToList();

            //上課日期
            var classAttendDate = (from c in dcTraining.trAttendClassDate
                                   where c.iClassAutoKey == classKey
                                   select c).ToList();


            ClassQuestionnaireRepo cqRepo = new ClassQuestionnaireRepo();
            var classQuestionnaireList = cqRepo.GetByClassId_Dlo(classKey);

            //trTrainingStudentS(結訓-訓練名單)
            //trTrainingStudentPresence(簽到-訓練名單)
            foreach (var s in students)
            {
                #region 結訓條件
                //結訓條件
                foreach (var k in knotTeaches)
                {
                    //先查是否有資料了，有的話，就不新增
                    trTrainingStudentS tssObj = (from c in tssList
                                                 where c.trTrainingStudentM_ID == s.iAutoKey
                                                 && c.trKnotTeaches_sCode == k.trKnotTeaches_sCode
                                                 && c.iClassAutoKey == classKey
                                                 select c).FirstOrDefault();

                    if (tssObj == null)
                    {
                        trTrainingStudentS obj = new trTrainingStudentS();
                        obj.trTrainingStudentM_ID = s.iAutoKey;
                        obj.trKnotTeaches_sCode = k.trKnotTeaches_sCode;
                        obj.iClassAutoKey = classKey;
                        obj.bPass = false;
                        dcTraining.trTrainingStudentS.InsertOnSubmit(obj);
                    }
                    else
                    {
                        tssList.Remove(tssObj);
                    }
                }
                #endregion

                #region 出席

                //出席
                foreach (var a in classAttendDate)
                {
                    trTrainingStudentPresence tspObj = (from c in tspList
                                                        where c.trTrainingStudentM_ID == s.iAutoKey
                                                        && c.AttendClassDateID == a.iAutoKey
                                                        && c.iClassAutoKey == classKey
                                                        select c).FirstOrDefault();

                    if (tspObj == null)
                    {
                        trTrainingStudentPresence obj = new trTrainingStudentPresence();
                        obj.trTrainingStudentM_ID = s.iAutoKey;
                        obj.bPresence = false;
                        obj.iClassAutoKey = classKey;
                        obj.AttendClassDateID = a.iAutoKey;
                        dcTraining.trTrainingStudentPresence.InsertOnSubmit(obj);
                    }
                    else
                    {
                        tspList.Remove(tspObj);
                    }
                }
                #endregion

                dcTraining.SubmitChanges();

                //問卷
                QAMaster_Repo qaRepo = new QAMaster_Repo();
                var sList = classQuestionnaireList.FindAll(p => p.QTpl.FillerCategory.Equals("S"));
                foreach (ClassQuestionnaire c in sList)
                {
                    qaRepo.CreateQA(classKey, c.qQuestionaryM, s.sNobr);
                }
            }


            trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
            classObj.iStudentNum = tdmRepo.GetLatestStudentNum(classObj.iAutoKey);
            dcTraining.SubmitChanges();

            //刪除課程多餘資料、如果開過課，又取消發布，才會有多餘資料
            //    //結訓
            //    trTrainingStudentS_Repo tssRepo = new trTrainingStudentS_Repo();
            //    List<trTrainingStudentS> tssList = tssRepo.GetByClassID(classKey);
            foreach (var t in tssList)
            {
                tssRepo.Delete(t);
            }

            //    ////簽到
            //    trTrainingStudentPresence_Repo tspRepo = new trTrainingStudentPresence_Repo();
            //    List<trTrainingStudentPresence> tspList = tspRepo.GetByClassID(classKey);
            foreach (var t in tspList)
                tspRepo.Delete(t);

            tssRepo.Save();
            tspRepo.Save();

            //問卷塞入非學員的
            var tempList = classQuestionnaireList.FindAll(p => !p.QTpl.FillerCategory.Equals("S"));
            foreach (ClassQuestionnaire c in tempList)
            {
                qaRepo.CreateQA(classKey, c.qQuestionaryM, null);
            }

            //開課時，如果是重開課時，清除多餘的問卷
            qaRepo.CleanRedundantQA_ByClassId(classKey);

            //qBaseRepo.Save();
        }



        public void NotifyClassReportNeedToFillOut(DateTime datetime)
        {
            BASE_Repo baseRepo = new BASE_Repo();

            List<trTrainingStudentM> tsmList= GetClassRptLostByDate_Dlo(datetime);
            foreach (trTrainingStudentM s in tsmList)
            {
                NotifyMsgFacade nf1 = new NotifyMsgFacade();
                string str1 = "課程" + s.trTrainingDetailM.trCourse.sName + "的心得尚未填寫";
                nf1.Message = str1;
                nf1.Title = str1;
                nf1.SourceSystem = "eTraining";
                nf1.SourceProgram = "心得通知";
                nf1.NotifyAdate = datetime;
                nf1.AddNotifyMsgTargetType(s.sNobr, NotifyTargetTypeEnum.Emp, NotifyTypeEnum.Board);
                nf1.SaveAndProcess();

                //通知主管
                List<BASE> managerList = baseRepo.GetManagersByDept(s.BASE.BASETTS[0].DEPT);
                if (managerList.Count > 0)
                {
                    NotifyMsgFacade nf2 = new NotifyMsgFacade();
                    string str2 = "員工" + s.BASE.NAME_C + "於課程" + s.trTrainingDetailM.trCourse.sName + "的心得尚未填寫";
                    nf2.Message = str2;
                    nf2.Title = str2;
                    nf2.SourceSystem = "eTraining";
                    nf2.SourceProgram = "心得通知";
                    nf2.NotifyAdate = datetime;
                    foreach (var b in managerList)
                    {
                        nf2.AddNotifyMsgTargetType(b.NOBR, NotifyTargetTypeEnum.Emp, NotifyTypeEnum.Board);
                    }
                    nf2.SaveAndProcess();
                }
            }
        }

        public List<trTrainingStudentM> GetByClassId(int classId)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.trTrainingStudentM
                        where sm.iClassAutoKey == classId
                        select sm).ToList();
            }
        }
    }

}