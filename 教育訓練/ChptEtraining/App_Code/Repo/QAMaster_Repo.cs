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
    public class QAMaster_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public QAMaster_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public QAMaster_Repo(dcTrainingDataContext d)
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
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QAMaster
                        select c).ToList();
            }
        }

        public QAMaster GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QAMaster
                        where c.Id==id
                        select c).FirstOrDefault();
            }
        }



        public QAMaster GetByPk_Dlo(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QAMaster>(l => l.QADetail);
                dlo.LoadWith<QAMaster>(l => l.QTpl);
                dlo.LoadWith<QAMaster>(l => l.BASE);
                dlo.LoadWith<QAMaster>(l => l.trTeacher);
                dlo.LoadWith<QAMaster>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                dlo.LoadWith<BASETTS>(l => l.DEPT1);

                ldc.LoadOptions = dlo;

                return (from c in ldc.QAMaster
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }

        public List<QAMaster> GetByClassQTpl_Dlo(int id,string tplCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DateTime datetime = DateTime.Now.Date;
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QAMaster>(l => l.QADetail);

                ldc.LoadOptions = dlo;

                return (from c in ldc.QAMaster
                        where c.ClassAutoKey==id && c.QTplCode == tplCode
                        select c).ToList();
            }
        }


        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<QAMaster> GetByClassId(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QAMaster
                        where c.ClassAutoKey == id
                        select c).ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <param name="cat">cat 為抓取類型，0代表未填寫、1代表已填寫、2代表全部</param>
        /// <returns></returns>
        public int GetQtyByClassIdQuestionnaireCode(int id,string code,int cat)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                if(cat ==0)
                return (from c in ldc.QAMaster
                        where c.ClassAutoKey == id
                        && c.QTplCode ==code && c.WriteDate ==null
                        select c).Count();
                else if(cat ==1)
                    return (from c in ldc.QAMaster
                            where c.ClassAutoKey == id
                            && c.QTplCode == code && c.WriteDate != null
                            select c).Count();
                else
                    return (from c in ldc.QAMaster
                            where c.ClassAutoKey == id
                            && c.QTplCode == code
                            select c).Count();
            }
        }



        //刪除多餘問卷
        public void CleanRedundantQA_ByClassId(int classId)
        {
            ClassQuestionnaireRepo cqRepo = new ClassQuestionnaireRepo();
            List<ClassQuestionnaire> cqList= cqRepo.GetByClassId_Dlo(classId);
            QAMaster_Repo qaRepo = new QAMaster_Repo();
            List<QAMaster> qaList= qaRepo.GetByClassId(classId);

            foreach (ClassQuestionnaire c in cqList)
            {
                if (c.QTpl.FillerCategory.Equals("S"))
                {
                    trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
                    List<string> stuList =  tsmRepo.GetByClassId(classId).Select(p=>p.sNobr).ToList();
                    List<QAMaster> delList = (from d in  qaList where !stuList.Contains(d.Nobr) 
                                                  && d.QTplCode==c.qQuestionaryM select d).ToList();
                    qaRepo.Delete(delList);
                }
                else if (c.QTpl.FillerCategory.Equals("M"))
                {
                    List<QAMaster> delList = (from d in qaList
                                              where d.QTplCode == c.qQuestionaryM
                                              select d).ToList();
                    qaRepo.Delete(delList);
                }
                else if (c.QTpl.FillerCategory.Equals("T"))
                {
                    ClassTeacher_Repo ctRepo = new ClassTeacher_Repo();
                    List<string> teacherList= ctRepo.GetByClassKey(classId).Select(p=>p.sTeacherCode).ToList();

                    List<QAMaster> delList = (from d in qaList
                                              where !teacherList.Contains(d.TeacherCode) &&
                                              d.QTplCode == c.qQuestionaryM
                                              select d).ToList();
                    qaRepo.Delete(delList);
                }
                else if (c.QTpl.FillerCategory.Equals("CU"))
                {
                    ClassQuestionnaireCU_Repo cuRepo = new ClassQuestionnaireCU_Repo();
                    List<string> cuList = cuRepo.GetByClassID(classId).Select(p => p.Nobr).ToList();

                    List<QAMaster> delList = (from d in qaList
                                              where !cuList.Contains(d.Nobr) &&
                                              d.QTplCode == c.qQuestionaryM
                                              select d).ToList();
                    qaRepo.Delete(delList);
                }
            }

            qaRepo.Save();
        }


        public QAMaster GetByClassQTplNobrFillerCat(int classId, string qTplCode, string nobr, string fillerCat)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                if (fillerCat.Equals("S"))
                    return (from c in ldc.QAMaster
                            where c.ClassAutoKey == classId && c.QTplCode == qTplCode && c.Nobr == nobr && c.FillerCategory=="S"
                            select c).FirstOrDefault();
                else if (fillerCat.Equals("M"))
                    return (from c in ldc.QAMaster
                            where c.ClassAutoKey == classId && c.QTplCode == qTplCode && c.FillerCategory == "M"
                            select c).FirstOrDefault();
                else if (fillerCat.Equals("T"))
                    return (from c in ldc.QAMaster
                            where c.ClassAutoKey == classId && c.QTplCode == qTplCode && c.FillerCategory == "T"
                            select c).FirstOrDefault();
                else
                    return (from c in ldc.QAMaster
                            where c.ClassAutoKey == classId && c.QTplCode == qTplCode && c.FillerCategory == "CU"
                            select c).FirstOrDefault();
            }
        }


        public QAMaster GetByClassQTplTeacherCode(int classId, string qTplCode, string teacherCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                    return (from c in ldc.QAMaster
                            where c.ClassAutoKey == classId && c.QTplCode == qTplCode && c.FillerCategory == "T"
                            && c.TeacherCode==teacherCode
                            select c).FirstOrDefault();
            }
        }

        /// <summary>
        /// 抓資料by工號，課程代碼
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<QAMaster> GetByNobrClassId(string nobr, int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.QAMaster
                        where c.Nobr == nobr
                        && c.ClassAutoKey == classID
                        select c).ToList();
            }
        }


        //產生問卷
        public void CreateQA(int classId, string qTplCode, string nobr)
        {
            BASE_Repo baseRepo = new BASE_Repo();
            QTpl_Repo qTplRepo = new QTpl_Repo();
            QTpl qTplObj = qTplRepo.GetByPk_Dlo(qTplCode);

            QAMaster_Repo mRepo = new QAMaster_Repo();
            QAMaster mObj = mRepo.GetByClassQTplNobrFillerCat(classId, qTplCode, nobr,qTplObj.FillerCategory);
            if (mObj != null)
                return;

            trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
            var classObj = tdmRepo.GetByPK(classId);

            if (qTplObj.FillerCategory.Equals("S"))
            {
                BASE baseObj = baseRepo.GetEmpByNobrNow_DLO(nobr);
                mObj = new QAMaster();
                mObj.ClassAutoKey = classId;
                mObj.DeptCode = baseObj.BASETTS[0].DEPT;
                mObj.FillerCategory = qTplObj.FillerCategory;
                mObj.FillFormDatetimeB = classObj.dDateTimeD.Value;
                mObj.FillFormDatetimeE = classObj.dDateD.Value.AddDays(qTplObj.FillFormSpan + 1);
                mObj.QTplCode = qTplCode;
                mObj.Nobr = nobr;
                CreateQA_Detail(mObj);
                mRepo.Add(mObj);
            }
            else if (qTplObj.FillerCategory.Equals("M"))
            {
                mObj = new QAMaster();
                mObj.ClassAutoKey = classId;
                mObj.FillerCategory = qTplObj.FillerCategory;
                mObj.FillFormDatetimeB = classObj.dDateTimeD.Value;
                mObj.FillFormDatetimeE = classObj.dDateD.Value.AddDays(qTplObj.FillFormSpan + 1);
                mObj.QTplCode = qTplCode;
                mObj.sysRole = 1;
                CreateQA_Detail(mObj);
                mRepo.Add(mObj);
            }
            else if (qTplObj.FillerCategory.Equals("T"))
            {
                ClassTeacher_Repo ctRepo = new ClassTeacher_Repo();
                List<ClassTeacher> classTeacherList = ctRepo.GetByClassKey(classId);
                foreach (ClassTeacher ct in classTeacherList)
                {
                    mObj = new QAMaster();
                    mObj.ClassAutoKey = classId;
                    mObj.FillerCategory = qTplObj.FillerCategory;
                    mObj.FillFormDatetimeB = classObj.dDateTimeD.Value;
                    mObj.FillFormDatetimeE = classObj.dDateD.Value.AddDays(qTplObj.FillFormSpan + 1);
                    mObj.QTplCode = qTplCode;
                    mObj.TeacherCode = ct.sTeacherCode;
                    CreateQA_Detail(mObj);
                    mRepo.Add(mObj);
                }
            }
            else if (qTplObj.FillerCategory.Equals("CU"))
            {
                ClassQuestionnaireCU_Repo cuRepo = new ClassQuestionnaireCU_Repo();
                List<ClassQuestionnaireCU> cuList= cuRepo.GetByClassIdQTplcode(classId,qTplCode);
                foreach (ClassQuestionnaireCU cu in cuList)
                {
                    mObj = new QAMaster();
                    mObj.ClassAutoKey = classId;
                    mObj.FillerCategory = qTplObj.FillerCategory;
                    mObj.FillFormDatetimeB = classObj.dDateTimeD.Value;
                    mObj.FillFormDatetimeE = classObj.dDateD.Value.AddDays(qTplObj.FillFormSpan + 1);
                    mObj.QTplCode = qTplCode;
                    mObj.Nobr = cu.Nobr;
                    CreateQA_Detail(mObj);
                    mRepo.Add(mObj);
                }
            }

            mRepo.Save();
        }

        public void CreateQA_Detail(QAMaster obj)
        {
            QTpl_Repo tplRepo = new QTpl_Repo();
            QTpl tplObj= tplRepo.GetByPk_Dlo(obj.QTplCode);
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
        /// 產生問卷by課程問卷關聯檔
        /// </summary>
        /// <param name="cq"></param>
        public void CreatedQA_ByClassQuestionnaire(ClassQuestionnaire cq)
        {
            trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
            QTpl_Repo tplRepo = new QTpl_Repo();
            QTpl tplObj= tplRepo.GetByPk(cq.qQuestionaryM);

            if (tplObj.FillerCategory.Equals("S"))
            {
                List<trTrainingStudentM> tsmList = tsmRepo.GetByClassId(cq.iClassAutoKey);
                foreach (trTrainingStudentM tsm in tsmList)
                {
                    CreateQA(cq.iClassAutoKey, cq.qQuestionaryM, tsm.sNobr);
                }
            }
            else
            {
                CreateQA(cq.iClassAutoKey, cq.qQuestionaryM,null);
            }
        }

        /// <summary>
        /// 抓取問卷是學員及自訂人員
        /// </summary>
        /// <param name="year"></param>
        /// <param name="nobr"></param>
        /// <returns></returns>
        public List<QAMaster> GetByYearNobr_Dlo(int year,string nobr)
        {
            List<QAMaster> list = new List<QAMaster>();

            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                //dlo.LoadWith<QAMaster>(l => l.QADetail);
                dlo.LoadWith<QAMaster>(l => l.QTpl);
                dlo.LoadWith<QAMaster>(l => l.trTrainingStudentM);
                dlo.LoadWith<QAMaster>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);                
                ldc.LoadOptions = dlo;

                list.AddRange((from c in ldc.QAMaster
                        where c.trTrainingDetailM.iYear == year
                        && c.FillerCategory.Equals("S")
                        && c.Nobr == nobr
                        && c.trTrainingStudentM.bPresence
                        select c).ToList());
            }

            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                //dlo.LoadWith<QAMaster>(l => l.QADetail);
                dlo.LoadWith<QAMaster>(l => l.QTpl);
                dlo.LoadWith<QAMaster>(l => l.trTrainingStudentM);
                dlo.LoadWith<QAMaster>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                list.AddRange((from c in ldc.QAMaster
                               where c.trTrainingDetailM.iYear == year
                               && c.FillerCategory.Equals("CU")
                               && c.Nobr == nobr
                               select c).ToList());
            }

            return list;
        }



        /// <summary>
        /// 抓取問卷是講師
        /// </summary>
        /// <param name="year"></param>
        /// <param name="nobr"></param>
        /// <returns></returns>
        public List<QAMaster> GetByYearTeacherCode_Dlo(int year, string teacherCode)
        {
            List<QAMaster> list = new List<QAMaster>();

            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<QAMaster>(l => l.QTpl);
                dlo.LoadWith<QAMaster>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                ldc.LoadOptions = dlo;

                list.AddRange((from c in ldc.QAMaster
                               where c.trTrainingDetailM.iYear == year
                               && c.FillerCategory.Equals("T")
                               && c.TeacherCode == teacherCode
                               select c).ToList());
            }

            return list;
        }



        public List<ClassQuestionnaireView> GetByWriteDateNull_DLO(DateTime AdateB, DateTime AdateE, string AfillerCategory)
        {
            DateTime datetime = DateTime.Now.Date;

            if (AfillerCategory.Equals("S"))
            {
                using (dcTrainingDataContext ldc = new dcTrainingDataContext())
                {
                    DataLoadOptions dlo = new DataLoadOptions();
                    dlo.LoadWith<QAMaster>(l => l.BASE);
                    dlo.LoadWith<QAMaster>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                    //dlo.LoadWith<BASE>(l => l.BASETTS);
                    dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                    dlo.LoadWith<BASETTS>(l => l.DEPT1);

                    ldc.LoadOptions = dlo;
                    var resultList = (from c in ldc.QAMaster
                                      join tsm in ldc.trTrainingStudentM
                                      on new { classId = c.ClassAutoKey, nobr = c.Nobr }
                                      equals new { classId = tsm.iClassAutoKey, nobr = tsm.sNobr }
                                      where c.trTrainingDetailM.bIsPublished
                                      && c.trTrainingDetailM.dDateA >= AdateB
                                      && c.trTrainingDetailM.dDateD <= AdateE
                                      && c.FillerCategory == "S"
                                      && c.WriteDate == null
                                      && tsm.bPresence
                                      && c.BASE.BASETTS.Any()
                                      select c).ToList();

                    return (from c in resultList
                            select new ClassQuestionnaireView
                            {
                                AutoKey = c.Id,
                                ClassId = c.trTrainingDetailM.iAutoKey,
                                CourseCate = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
                                CourseCode = c.trTrainingDetailM.trCourse.sCode,
                                CourseDateB = c.trTrainingDetailM.dDateA.Value,
                                CourseName = c.trTrainingDetailM.trCourse.sName,
                                DeptCode = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT : "",
                                DeptName = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT1.D_NAME : "",
                                Name = c.BASE.NAME_C,
                                Nobr = c.Nobr,
                                TeacherCode = ""
                            }).ToList();
                }
            }
            else if (AfillerCategory.Equals("T"))
            {
                using (dcTrainingDataContext ldc = new dcTrainingDataContext())
                {
                    DataLoadOptions dlo = new DataLoadOptions();
                    dlo.LoadWith<QAMaster>(l => l.trTeacher);
                    dlo.LoadWith<QAMaster>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);

                    ldc.LoadOptions = dlo;
                    var resultList = (from c in ldc.QAMaster
                                      where c.trTrainingDetailM.bIsPublished
                                      && c.trTrainingDetailM.dDateA >= AdateB
                                      && c.trTrainingDetailM.dDateD <= AdateE
                                      && c.WriteDate == null
                                      && c.FillerCategory == "T"
                                      select c).ToList();

                    return (from c in resultList
                            select new ClassQuestionnaireView
                            {
                                AutoKey = c.Id,
                                ClassId = c.trTrainingDetailM.iAutoKey,
                                CourseCate = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
                                CourseCode = c.trTrainingDetailM.trCourse.sCode,
                                CourseDateB = c.trTrainingDetailM.dDateA.Value,
                                CourseName = c.trTrainingDetailM.trCourse.sName,
                                DeptCode = "",
                                DeptName = "",
                                Name = c.trTeacher.sName,
                                Nobr = "",
                                TeacherCode = c.trTeacher.sCode,
                            }).ToList();
                }
            }
            else if (AfillerCategory.Equals("M"))
            {
                using (dcTrainingDataContext ldc = new dcTrainingDataContext())
                {
                    DataLoadOptions dlo = new DataLoadOptions();
                    dlo.LoadWith<QAMaster>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);

                    ldc.LoadOptions = dlo;
                    var resultList = (from c in ldc.QAMaster
                                      where c.trTrainingDetailM.bIsPublished
                                      && c.trTrainingDetailM.dDateA >= AdateB
                                      && c.trTrainingDetailM.dDateD <= AdateE
                                      && c.WriteDate == null
                                      && c.FillerCategory == "M"
                                      select c).ToList();

                    return (from c in resultList
                            select new ClassQuestionnaireView
                            {
                                AutoKey = c.Id,
                                ClassId = c.trTrainingDetailM.iAutoKey,
                                CourseCate = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
                                CourseCode = c.trTrainingDetailM.trCourse.sCode,
                                CourseDateB = c.trTrainingDetailM.dDateA.Value,
                                CourseName = c.trTrainingDetailM.trCourse.sName,
                                DeptCode = "",
                                DeptName = "",
                                Name = "",
                                Nobr = "",
                                TeacherCode = ""
                            }).ToList();
                }
            }
            else//CU 自訂人員
            {
                using (dcTrainingDataContext ldc = new dcTrainingDataContext())
                {
                    DataLoadOptions dlo = new DataLoadOptions();
                    dlo.LoadWith<QAMaster>(l => l.BASE);
                    dlo.LoadWith<QAMaster>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                    dlo.LoadWith<BASE>(l => l.BASETTS);
                    dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                    dlo.LoadWith<BASETTS>(l => l.DEPT1);

                    ldc.LoadOptions = dlo;
                    var resultList = (from c in ldc.QAMaster
                                      where c.trTrainingDetailM.bIsPublished
                                      && c.trTrainingDetailM.dDateA >= AdateB
                                      && c.trTrainingDetailM.dDateD <= AdateE
                                      && c.WriteDate == null
                                      && c.BASE.BASETTS.Any()
                                      && c.FillerCategory == "CU"
                                      select c).ToList();

                    return (from c in resultList
                            select new ClassQuestionnaireView
                            {
                                AutoKey = c.Id,
                                ClassId = c.trTrainingDetailM.iAutoKey,
                                CourseCate = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
                                CourseCode = c.trTrainingDetailM.trCourse.sCode,
                                CourseDateB = c.trTrainingDetailM.dDateA.Value,
                                CourseName = c.trTrainingDetailM.trCourse.sName,
                                DeptCode = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT : "",
                                DeptName = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT1.D_NAME : "",
                                Name = c.BASE.NAME_C,
                                Nobr = c.Nobr,
                                TeacherCode = ""
                            }).ToList();
                }
            }
        }

        public void SetFillFormDatetimeB_ByClassID(int classID , DateTime datetime)
        {
            List<QAMaster> list = GetByClassID(classID);
            foreach ( var l in list )
            {
                l.FillFormDatetimeB = datetime;
                Update(l);
            }
        }

        public List<QAMaster> GetByClassID(int classID)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from c in ldc.QAMaster
                        where c.ClassAutoKey == classID
                        select c).ToList();
            }
        }
    }
}