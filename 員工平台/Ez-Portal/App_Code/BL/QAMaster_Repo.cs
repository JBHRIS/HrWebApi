using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using JBHRModel;

namespace BL
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class QAMaster_Repo
    {
        public JBHRModelDataContext dc { get; set; }

        public QAMaster_Repo()
        {
            dc = new JBHRModelDataContext();
        }

        public QAMaster_Repo(JBHRModelDataContext d)
        {
            dc = d;
        }

        public void Add(QAMaster o)
        {
            dc.QAMaster.InsertOnSubmit(o);
        }

        public void Update(QAMaster o)
        {
            DcHelper.Detach(o);
            dc.QAMaster.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Delete(QAMaster o)
        {
            QADetail_Repo dRepo = new QADetail_Repo(dc);
            List<QADetail> dList = dRepo.GetByQAMasterId(o.Id);
            dRepo.Delete(dList);

            DcHelper.Detach(o);
            dc.QAMaster.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.QAMaster.DeleteOnSubmit(o);
        }

        public void Delete(List<QAMaster> list)
        {
            foreach (QAMaster o in list)
            {
                Delete(o);
            }
        }

        public List<QAMaster> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QAMaster
                        select c).ToList();
            }
        }

        public QAMaster GetByPk(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QAMaster
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public QAMaster GetByPk_Dlo(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QAMaster>(l => l.QADetail);
                dlo.LoadWith<QAMaster>(l => l.QA_Published);
                dlo.LoadWith<QAMaster>(l => l.BASE);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                dlo.LoadWith<BASETTS>(l => l.DEPT1);

                ldc.LoadOptions = dlo;

                return (from c in ldc.QAMaster
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public List<QAMaster> GetByPublishId_Dlo(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QAMaster>(l => l.QADetail);
                dlo.LoadWith<QAMaster>(l => l.QA_Published);
                dlo.LoadWith<QAMaster>(l => l.BASE);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime));
                dlo.LoadWith<BASETTS>(l => l.DEPT1);

                ldc.LoadOptions = dlo;

                return (from c in ldc.QAMaster
                        where c.QA_PublishedID == id
                        select c).ToList();
            }
        }

        public int CountByPublishId(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QAMaster
                        where c.QA_PublishedID == id
                        select c).Count();
            }
        }

        public int CountFilledByPublishId(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.QAMaster
                        where c.QA_PublishedID == id
                        && c.WriteDate != null
                        select c).Count();
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<QAMaster> GetByNeedFillIn(string nobr, DateTime datetime)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QAMaster>(l => l.QA_Published);
                dlo.LoadWith<QA_Published>(l => l.QTpl);
                //dlo.LoadWith<QAMaster>(l => l.BASE);
                //dlo.LoadWith<BASE>(l => l.BASETTS);
                //dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_REPO.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                //dlo.LoadWith<BASETTS>(l => l.DEPT1);
                //ldc.Log = new DebuggerWriter();
                ldc.LoadOptions = dlo;

                return (from c in ldc.QAMaster
                        where c.Nobr == nobr
                        && c.QA_Published.IsPublished
                        && c.FillFormDatetimeB <= datetime
                        && c.FillFormDatetimeE > datetime
                        && c.WriteDate == null
                        select c).ToList();
            }
        }

        public QAMaster GetByPublishedIDNobrFillerCat(int publishId, string nobr, string fillerCat)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                if (fillerCat.Equals("S"))
                    return (from c in ldc.QAMaster
                            where c.QA_PublishedID == publishId && c.Nobr == nobr && c.FillerCategory == "S"
                            select c).FirstOrDefault();
                else
                    return null;
                //else if (fillerCat.Equals("M"))
                //    return (from c in ldc.QAMaster
                //            where c.ClassAutoKey == classId && c.QTplCode == qTplCode && c.FillerCategory == "M"
                //            select c).FirstOrDefault();
                //else if (fillerCat.Equals("Supervisor"))
                //    return (from c in ldc.QAMaster
                //            where c.ClassAutoKey == classId
                //            && c.QTplCode == qTplCode
                //            && c.FillerCategory == "Supervisor"
                //            && c.Nobr == nobr
                //            select c).FirstOrDefault();
                //else
                //    return (from c in ldc.QAMaster
                //            where c.ClassAutoKey == classId && c.QTplCode == qTplCode && c.FillerCategory == "CU"
                //            select c).FirstOrDefault();
            }
        }

        //產生問卷
        public void CreateQA(QA_Published qapObj, BASE baseObj)
        {
            BASE_REPO baseRepo = new BASE_REPO();
            QTpl_Repo qTplRepo = new QTpl_Repo();
            QTpl qTplObj = qTplRepo.GetByPk_Dlo(qapObj.QTplCode);

            QAMaster_Repo mRepo = new QAMaster_Repo();

            if (qTplObj.FillerCategory.Equals("S"))
            {
                QAMaster mObj = new QAMaster();
                mObj.DeptCode = baseObj.BASETTS[0].DEPT;
                mObj.FillerCategory = qTplObj.FillerCategory;
                mObj.FillFormDatetimeB = qapObj.FillFormDatetimeB;
                mObj.FillFormDatetimeE = qapObj.FillFormDatetimeE;
                mObj.Nobr = baseObj.NOBR;
                qapObj.QAMaster.Add(mObj);
                CreateQA_Detail(mObj);

                //mRepo.Add(mObj);
            }
            //else if (qTplObj.FillerCategory.Equals("M"))
            //{
            //    mObj = new QAMaster();
            //    mObj.ClassAutoKey = classId;
            //    mObj.FillerCategory = qTplObj.FillerCategory;
            //    mObj.FillFormDatetimeB = classObj.dDateTimeD.Value;
            //    mObj.FillFormDatetimeE = classObj.dDateD.Value.AddDays(qTplObj.FillFormSpan + 1);
            //    mObj.QTplCode = qTplCode;
            //    mObj.sysRole = 1;
            //    CreateQA_Detail(mObj);
            //    mRepo.Add(mObj);
            //}
            //else if (qTplObj.FillerCategory.Equals("CU"))
            //{
            //    ClassQuestionnaireCU_Repo cuRepo = new ClassQuestionnaireCU_Repo();
            //    List<ClassQuestionnaireCU> cuList = cuRepo.GetByClassIdQTplcode(classId, qTplCode);
            //    foreach (ClassQuestionnaireCU cu in cuList)
            //    {
            //        mObj = new QAMaster();
            //        mObj.ClassAutoKey = classId;
            //        mObj.FillerCategory = qTplObj.FillerCategory;
            //        mObj.FillFormDatetimeB = classObj.dDateTimeD.Value;
            //        mObj.FillFormDatetimeE = classObj.dDateD.Value.AddDays(qTplObj.FillFormSpan + 1);
            //        mObj.QTplCode = qTplCode;
            //        mObj.Nobr = cu.Nobr;
            //        CreateQA_Detail(mObj);
            //        mRepo.Add(mObj);
            //    }
            //}

            mRepo.Save();
        }

        public void CreateQA_Detail(QAMaster obj)
        {
            QTpl_Repo tplRepo = new QTpl_Repo();
            QTpl tplObj = tplRepo.GetByPk_Dlo(obj.QA_Published.QTplCode);
            foreach (var c in tplObj.QTplCategory)
            {
                foreach (var i in c.QDetail)
                {
                    QADetail dObj = new QADetail();
                    dObj.QQItemId = i.QQItemId;
                    obj.QADetail.Add(dObj);
                }
            }
        }

        /// <summary>
        /// 抓取問卷是學員及自訂人員
        /// </summary>
        /// <param name="year"></param>
        /// <param name="nobr"></param>
        /// <returns></returns>
        public List<QAMaster> GetByYearNobr_Dlo(int year, string nobr)
        {
            List<QAMaster> list = new List<QAMaster>();

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                //dlo.LoadWith<QAMaster>(l => l.QADetail);
                ldc.LoadOptions = dlo;

                list.AddRange((from c in ldc.QAMaster
                               where c.FillerCategory.Equals("S")
                               && c.Nobr == nobr
                               select c).ToList());
            }

            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                //dlo.LoadWith<QAMaster>(l => l.QADetail);
                ldc.LoadOptions = dlo;

                list.AddRange((from c in ldc.QAMaster
                               where c.FillerCategory.Equals("CU")
                               && c.Nobr == nobr
                               select c).ToList());
            }

            return list;
        }

        //public List<ClassQuestionnaireView> GetByWriteDateNull_DLO(DateTime AdateB, DateTime AdateE, string AfillerCategory)
        //{
        //    DateTime datetime = DateTime.Now.Date;

        //    if (AfillerCategory.Equals("S"))
        //    {
        //        using (JBHRModelDataContext ldc = new JBHRModelDataContext())
        //        {
        //            DataLoadOptions dlo = new DataLoadOptions();
        //            dlo.LoadWith<QAMaster>(l => l.BASE);
        //            //dlo.LoadWith<BASE>(l => l.BASETTS);
        //            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
        //            dlo.LoadWith<BASETTS>(l => l.DEPT1);

        //            ldc.LoadOptions = dlo;
        //            var resultList = (from c in ldc.QAMaster
        //                              join tsm in ldc.trTrainingStudentM
        //                              on new { classId = c.ClassAutoKey, nobr = c.Nobr }
        //                              equals new { classId = tsm.iClassAutoKey, nobr = tsm.sNobr }
        //                              where c.trTrainingDetailM.bIsPublished
        //                              && c.trTrainingDetailM.dDateA >= AdateB
        //                              && c.trTrainingDetailM.dDateD <= AdateE
        //                              && c.FillerCategory == "S"
        //                              && c.WriteDate == null
        //                              && tsm.bPresence
        //                              && c.BASE.BASETTS.Any()
        //                              select c).ToList();

        //            return (from c in resultList
        //                    select new ClassQuestionnaireView
        //                    {
        //                        AutoKey = c.Id,
        //                        ClassId = c.trTrainingDetailM.iAutoKey,
        //                        CourseCate = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
        //                        CourseCode = c.trTrainingDetailM.trCourse.sCode,
        //                        CourseDateB = c.trTrainingDetailM.dDateA.Value,
        //                        CourseName = c.trTrainingDetailM.trCourse.sName,
        //                        DeptCode = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT : "",
        //                        DeptName = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT1.D_NAME : "",
        //                        Name = c.BASE.NAME_C,
        //                        Nobr = c.Nobr,
        //                        TeacherCode = ""
        //                    }).ToList();
        //        }
        //    }
        //    else//CU 自訂人員
        //    {
        //        using (JBHRModelDataContext ldc = new JBHRModelDataContext())
        //        {
        //            DataLoadOptions dlo = new DataLoadOptions();
        //            dlo.LoadWith<QAMaster>(l => l.BASE);
        //            dlo.LoadWith<BASE>(l => l.BASETTS);
        //            dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
        //            dlo.LoadWith<BASETTS>(l => l.DEPT1);

        //            ldc.LoadOptions = dlo;
        //            var resultList = (from c in ldc.QAMaster
        //                              && c.WriteDate == null
        //                              && c.BASE.BASETTS.Any()
        //                              && c.FillerCategory == "CU"
        //                              select c).ToList();

        //            return (from c in resultList
        //                    select new ClassQuestionnaireView
        //                    {
        //                        AutoKey = c.Id,
        //                        ClassId = c.trTrainingDetailM.iAutoKey,
        //                        CourseCate = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
        //                        CourseCode = c.trTrainingDetailM.trCourse.sCode,
        //                        CourseDateB = c.trTrainingDetailM.dDateA.Value,
        //                        CourseName = c.trTrainingDetailM.trCourse.sName,
        //                        DeptCode = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT : "",
        //                        DeptName = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT1.D_NAME : "",
        //                        Name = c.BASE.NAME_C,
        //                        Nobr = c.Nobr,
        //                        TeacherCode = ""
        //                    }).ToList();
        //        }
        //    }
        //}

        //public void SetFillFormDatetimeB_ByClassID(int classID , DateTime datetime)
        //{
        //    List<QAMaster> list = GetByClassID(classID);
        //    foreach ( var l in list )
        //    {
        //        l.FillFormDatetimeB = datetime;
        //        Update(l);
        //    }
        //}

        //public List<QAMaster> GetByClassID(int classID)
        //{
        //    using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
        //    {
        //        return (from c in ldc.QAMaster
        //                where c.ClassAutoKey == classID
        //                select c).ToList();
        //    }
        //}

        //public List<QAMaster> GetBySupervisorDateRange_Dlo(string supervisor,DateTime dateB,DateTime dateE)
        //{
        //    using (JBHRModelDataContext ldc = new JBHRModelDataContext())
        //    {
        //        DateTime dt = DateTime.Now.Date;
        //        DataLoadOptions dlo = new DataLoadOptions();
        //        dlo.LoadWith<QAMaster>(l => l);
        //        dlo.LoadWith<BASE>(l => l.BASETTS);
        //        dlo.LoadWith<BASETTS>(l => l.DEPT1);
        //        dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= dt && t.DDATE >= dt));
        //        ldc.LoadOptions = dlo;

        //        return (from c in ldc.QAMaster
        //                where  c.FillerCategory.Equals("Supervisor")
        //                       && c.SupervisorNobr==supervisor
        //                       //&& c.trTrainingStudentM.bPresence
        //                       select c).ToList();
        //    }
        //}
    }
}