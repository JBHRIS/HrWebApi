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
    public class qBaseM_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public qBaseM_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public qBaseM_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(qBaseM o)
        {
            dc.qBaseM.InsertOnSubmit(o);            
        }

        public void Delete(qBaseM o)
        {
            DcHelper.Detach(o); 
            dc.qBaseM.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.qBaseM.DeleteOnSubmit(o);
        }


        public void DeleteList(List<qBaseM> list)
        {
            foreach (var o in list)
            {
                DcHelper.Detach(o);
                dc.qBaseM.Attach(o);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
                dc.qBaseM.DeleteOnSubmit(o);
            }
        }

        public void DeleteByPK(int id)
        {
            var obj = (from c in dc.qBaseM
                       where c.iAutokey == id
                       select c).FirstOrDefault();
            dc.qBaseM.DeleteOnSubmit(obj);
        }

        public void Update(qBaseM o)
        {
            DcHelper.Detach(o); 
            dc.qBaseM.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        /// <summary>
        /// 抓資料by工號，課程代碼
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<qBaseM> GetByNobrClassID(string nobr,int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.qBaseM
                        where c.sNobr == nobr
                        && c.iClassAutoKey == classID
                        select c).ToList();
            }
        }


        public List<qBaseM> GetByClassID(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.qBaseM
                        where c.iClassAutoKey == classID
                        select c).ToList();
            }
        }


        public List<qBaseM> GetByClassID_DLO(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<qBaseM>(l => l.qQuestionaryM);
                ldc.LoadOptions = dlo;
                return (from c in ldc.qBaseM
                        where c.iClassAutoKey == classID
                        select c).ToList();
            }
        }

        /// <summary>
        /// Get By 開課編號，問卷代碼
        /// </summary>
        /// <param name="classID"></param>
        /// <param name="courseCode"></param>
        /// <returns></returns>
        public List<qBaseM> GetByClassIdCourseCode(int classID,string questionaryCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.qBaseM
                        where c.iClassAutoKey == classID 
                        && c.qQuestionary_sCode == questionaryCode
                        select c).ToList();
            }
        }


        public qBaseM GetById(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.qBaseM
                        where c.iAutokey == id
                        select c).SingleOrDefault();
            }
        }

        public void SetFillFormDatetimeB_ByClassID(int classID, DateTime datetime)
        {
            List<qBaseM> list = GetByClassID(classID);
            foreach (var l in list)
            {
                l.dFillFormDatetimeB = datetime;
                Update(l);
            }
        }


        public qBaseM GetByAutoKey_DLO(int AautoKey)
        {
            DateTime datetime = DateTime.Now.Date;

            qBaseM obj = GetById(AautoKey);

            if ( obj.FillerCategory.Equals("S") )
            {
                using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
                {
                    DataLoadOptions dlo = new DataLoadOptions();
                    dlo.LoadWith<qBaseM>(l => l.BASE);
                    dlo.LoadWith<qBaseM>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                    dlo.LoadWith<BASE>(l => l.BASETTS);
                    dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                    dlo.LoadWith<BASETTS>(l => l.DEPT1);

                    ldc.LoadOptions = dlo;
                    return (from c in ldc.qBaseM
                            where c.iAutokey == AautoKey
                                      select c).FirstOrDefault();
                }
            }
            else if ( obj.FillerCategory.Equals("T") )
            {
                using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
                {
                    DataLoadOptions dlo = new DataLoadOptions();
                    dlo.LoadWith<qBaseM>(l => l.trTeacher);
                    dlo.LoadWith<qBaseM>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);

                    ldc.LoadOptions = dlo;
                    return (from c in ldc.qBaseM
                            where c.iAutokey == AautoKey
                                      select c).FirstOrDefault();
                }
            }
            else if ( obj.FillerCategory.Equals("M") )
            {
                using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
                {
                    DataLoadOptions dlo = new DataLoadOptions();
                    dlo.LoadWith<qBaseM>(l => l.trTeacher);
                    dlo.LoadWith<qBaseM>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);

                    ldc.LoadOptions = dlo;
                    return (from c in ldc.qBaseM
                                      where c.iAutokey == AautoKey
                                      select c).FirstOrDefault();
                }
            }
            else//CU 自訂人員
            {
                using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
                {
                    DataLoadOptions dlo = new DataLoadOptions();
                    dlo.LoadWith<qBaseM>(l => l.BASE);
                    dlo.LoadWith<qBaseM>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                    dlo.LoadWith<BASE>(l => l.BASETTS);
                    dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                    dlo.LoadWith<BASETTS>(l => l.DEPT1);

                    ldc.LoadOptions = dlo;
                    return (from c in ldc.qBaseM
                                      where c.iAutokey == AautoKey
                                      select c).FirstOrDefault();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="AdateB">開課日期起</param>
        /// <param name="AdateE">開課日期迄</param>
        /// <param name="AfillerCategory"></param>
        /// <returns></returns>
        public List<ClassQuestionnaireView> GetByWriteDateNull_DLO(DateTime AdateB, DateTime AdateE, string AfillerCategory)
        {
            DateTime datetime = DateTime.Now.Date;

            if (AfillerCategory.Equals("S"))
            {
                using (dcTrainingDataContext ldc = new dcTrainingDataContext())
                {
                    DataLoadOptions dlo = new DataLoadOptions();
                    dlo.LoadWith<qBaseM>(l => l.BASE);
                    dlo.LoadWith<qBaseM>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                    //dlo.LoadWith<BASE>(l => l.BASETTS);
                    dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));                   
                    dlo.LoadWith<BASETTS>(l => l.DEPT1);                    

                    ldc.LoadOptions = dlo;
                    var resultList= (from c in ldc.qBaseM
                        join tsm in ldc.trTrainingStudentM
                        on new { classId = c.iClassAutoKey.Value, nobr = c.sNobr }
                        equals new { classId = tsm.iClassAutoKey, nobr = tsm.sNobr }
                        where c.trTrainingDetailM.bIsPublished
                        && c.trTrainingDetailM.dDateA >= AdateB
                        && c.trTrainingDetailM.dDateD <= AdateE
                        && c.FillerCategory == "S"
                        && c.dWriteDate == null
                        && tsm.bPresence
                        && c.BASE.BASETTS.Any()
                        select c).ToList();

                    return (from c in resultList
                        select new ClassQuestionnaireView
                        {
                            AutoKey = c.iAutokey ,
                            ClassId = c.trTrainingDetailM.iAutoKey,
                            CourseCate = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
                            CourseCode = c.trTrainingDetailM.trCourse.sCode,
                            CourseDateB = c.trTrainingDetailM.dDateA.Value,
                            CourseName = c.trTrainingDetailM.trCourse.sName,
                            DeptCode = c.BASE.BASETTS.Count>0 ? c.BASE.BASETTS[0].DEPT:"",
                            DeptName = c.BASE.BASETTS.Count>0 ? c.BASE.BASETTS[0].DEPT1.D_NAME:"",
                            Name = c.BASE.NAME_C,
                            Nobr = c.sNobr,
                            TeacherCode = ""                       
                        }).ToList();                    
                }
            }
            else if (AfillerCategory.Equals("T"))
            {
                using (dcTrainingDataContext ldc = new dcTrainingDataContext())
                {
                    DataLoadOptions dlo = new DataLoadOptions();
                    dlo.LoadWith<qBaseM>(l => l.trTeacher);
                    dlo.LoadWith<qBaseM>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);                                        

                    ldc.LoadOptions = dlo;
                    var resultList = (from c in ldc.qBaseM                                                                                                                  
                                      where c.trTrainingDetailM.bIsPublished
                                      && c.trTrainingDetailM.dDateA >= AdateB
                                      && c.trTrainingDetailM.dDateD <= AdateE
                                      && c.dWriteDate == null
                                      && c.FillerCategory == "T"                                      
                                      select c).ToList();

                    return (from c in resultList
                            select new ClassQuestionnaireView
                            {
                                AutoKey = c.iAutokey,
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
                    dlo.LoadWith<qBaseM>(l => l.trTeacher);
                    dlo.LoadWith<qBaseM>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);

                    ldc.LoadOptions = dlo;
                    var resultList = (from c in ldc.qBaseM
                                      where c.trTrainingDetailM.bIsPublished
                                      && c.trTrainingDetailM.dDateA >= AdateB
                                      && c.trTrainingDetailM.dDateD <= AdateE
                                      && c.dWriteDate == null
                                      && c.FillerCategory == "M"
                                      select c).ToList();

                    return (from c in resultList
                            select new ClassQuestionnaireView
                            {
                                AutoKey = c.iAutokey ,
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
                    dlo.LoadWith<qBaseM>(l => l.BASE);
                    dlo.LoadWith<qBaseM>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                    dlo.LoadWith<BASE>(l => l.BASETTS);
                    dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                    dlo.LoadWith<BASETTS>(l => l.DEPT1);

                    ldc.LoadOptions = dlo;
                    var resultList = (from c in ldc.qBaseM
                                      where c.trTrainingDetailM.bIsPublished
                                      && c.trTrainingDetailM.dDateA >= AdateB
                                      && c.trTrainingDetailM.dDateD <= AdateE
                                      && c.dWriteDate == null
                                      && c.BASE.BASETTS.Any()
                                      && c.FillerCategory == "CU"
                                      select c).ToList();

                    return (from c in resultList
                            select new ClassQuestionnaireView
                            {
                                AutoKey = c.iAutokey ,
                                ClassId = c.trTrainingDetailM.iAutoKey,
                                CourseCate = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
                                CourseCode = c.trTrainingDetailM.trCourse.sCode,
                                CourseDateB = c.trTrainingDetailM.dDateA.Value,
                                CourseName = c.trTrainingDetailM.trCourse.sName,
                                DeptCode = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT : "",
                                DeptName = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT1.D_NAME : "",
                                Name = c.BASE.NAME_C,
                                Nobr = c.sNobr,
                                TeacherCode = ""
                            }).ToList();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Adatetime">帶入日期，此日期區間未填寫的</param>
        /// <param name="AfillerCategory"></param>
        /// <returns></returns>
        public List<ClassQuestionnaireView> GetByWriteDateNull_DLO(DateTime Adatetime, string AfillerCategory)
        {
            DateTime datetime = DateTime.Now.Date;

            if (AfillerCategory.Equals("S"))
            {
                using (dcTrainingDataContext ldc = new dcTrainingDataContext())
                {
                    DataLoadOptions dlo = new DataLoadOptions();
                    dlo.LoadWith<qBaseM>(l => l.BASE);
                    dlo.LoadWith<qBaseM>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                    //dlo.LoadWith<BASE>(l => l.BASETTS);
                    dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                    dlo.LoadWith<BASETTS>(l => l.DEPT1);

                    ldc.LoadOptions = dlo;
                    var resultList = (from c in ldc.qBaseM
                                      join tsm in ldc.trTrainingStudentM
                                      on new { classId = c.iClassAutoKey.Value, nobr = c.sNobr }
                                      equals new { classId = tsm.iClassAutoKey, nobr = tsm.sNobr }
                                      where c.trTrainingDetailM.bIsPublished
                                      && c.dFillFormDatetimeB <= Adatetime
                                      && c.dFillFormDatetimeE >= Adatetime
                                      && c.FillerCategory == "S"
                                      && c.dWriteDate == null
                                      && tsm.bPresence
                                      && c.BASE.BASETTS.Any()
                                      select c).ToList();

                    return (from c in resultList
                            select new ClassQuestionnaireView
                            {
                                AutoKey = c.iAutokey,
                                ClassId = c.trTrainingDetailM.iAutoKey,
                                CourseCate = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
                                CourseCode = c.trTrainingDetailM.trCourse.sCode,
                                CourseDateB = c.trTrainingDetailM.dDateA.Value,
                                CourseName = c.trTrainingDetailM.trCourse.sName,
                                DeptCode = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT : "",
                                DeptName = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT1.D_NAME : "",
                                Name = c.BASE.NAME_C,
                                Nobr = c.sNobr,
                                TeacherCode = ""
                            }).ToList();
                }
            }
            else if (AfillerCategory.Equals("T"))
            {
                using (dcTrainingDataContext ldc = new dcTrainingDataContext())
                {
                    DataLoadOptions dlo = new DataLoadOptions();
                    dlo.LoadWith<qBaseM>(l => l.trTeacher);
                    dlo.LoadWith<qBaseM>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);

                    ldc.LoadOptions = dlo;
                    var resultList = (from c in ldc.qBaseM
                                      where c.trTrainingDetailM.bIsPublished
                                      && c.dFillFormDatetimeB <= Adatetime
                                      && c.dFillFormDatetimeE >= Adatetime
                                      && c.dWriteDate == null
                                      && c.FillerCategory == "T"
                                      select c).ToList();

                    return (from c in resultList
                            select new ClassQuestionnaireView
                            {
                                AutoKey = c.iAutokey,
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
                    dlo.LoadWith<qBaseM>(l => l.trTeacher);
                    dlo.LoadWith<qBaseM>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);

                    ldc.LoadOptions = dlo;
                    var resultList = (from c in ldc.qBaseM
                                      where c.trTrainingDetailM.bIsPublished
                                      && c.dFillFormDatetimeB <= Adatetime
                                      && c.dFillFormDatetimeE >= Adatetime
                                      && c.dWriteDate == null
                                      && c.FillerCategory == "M"
                                      select c).ToList();

                    return (from c in resultList
                            select new ClassQuestionnaireView
                            {
                                AutoKey = c.iAutokey,
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
                    dlo.LoadWith<qBaseM>(l => l.BASE);
                    dlo.LoadWith<qBaseM>(l => l.trTrainingDetailM);
                    dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                    dlo.LoadWith<trCourse>(l => l.trCategoryCourse);
                    dlo.LoadWith<trCategoryCourse>(l => l.trCategory);
                    dlo.LoadWith<BASE>(l => l.BASETTS);
                    dlo.AssociateWith<BASE>(a => a.BASETTS.Where(t => t.ADATE <= datetime && t.DDATE >= datetime && BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(t.TTSCODE)));
                    dlo.LoadWith<BASETTS>(l => l.DEPT1);

                    ldc.LoadOptions = dlo;
                    var resultList = (from c in ldc.qBaseM
                                      where c.trTrainingDetailM.bIsPublished
                                      && c.dFillFormDatetimeB <= Adatetime
                                      && c.dFillFormDatetimeE >= Adatetime
                                      && c.dWriteDate == null
                                      && c.BASE.BASETTS.Any()
                                      && c.FillerCategory == "CU"
                                      select c).ToList();

                    return (from c in resultList
                            select new ClassQuestionnaireView
                            {
                                AutoKey = c.iAutokey,
                                ClassId = c.trTrainingDetailM.iAutoKey,
                                CourseCate = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
                                CourseCode = c.trTrainingDetailM.trCourse.sCode,
                                CourseDateB = c.trTrainingDetailM.dDateA.Value,
                                CourseName = c.trTrainingDetailM.trCourse.sName,
                                DeptCode = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT : "",
                                DeptName = c.BASE.BASETTS.Count > 0 ? c.BASE.BASETTS[0].DEPT1.D_NAME : "",
                                Name = c.BASE.NAME_C,
                                Nobr = c.sNobr,
                                TeacherCode = ""
                            }).ToList();
                }
            }
        }


        public void NotifyQANeedToFillOut(DateTime datetime)
        {            
            BASE_Repo baseRepo = new BASE_Repo();            

            //處理學員問卷
            List<ClassQuestionnaireView> cList1= GetByWriteDateNull_DLO(datetime, "S");
            foreach (ClassQuestionnaireView v in cList1)
            {
                NotifyMsgFacade nf1 = new NotifyMsgFacade();
                string str1 = "課程" + v.CourseName + "的問卷尚未填寫";
                nf1.Message = str1;
                nf1.Title = str1;
                nf1.SourceSystem = "eTraining";
                nf1.SourceProgram = "問卷通知";
                nf1.NotifyAdate = datetime;
                nf1.AddNotifyMsgTargetType(v.Nobr, NotifyTargetTypeEnum.Emp, NotifyTypeEnum.Board);
                nf1.SaveAndProcess();

                //通知主管
                List<BASE> managerList = baseRepo.GetManagersByDept(v.DeptCode);
                if (managerList.Count > 0)
                {
                    NotifyMsgFacade nf2 = new NotifyMsgFacade();
                    string str2 = "員工" + v.Name + "於課程" + v.CourseName + "的問卷尚未填寫";
                    nf2.Message = str2;
                    nf2.Title = str2;
                    nf2.SourceSystem = "eTraining";
                    nf2.SourceProgram = "問卷通知";
                    nf2.NotifyAdate = datetime;
                    foreach (var b in managerList)
                    {
                        nf2.AddNotifyMsgTargetType(b.NOBR, NotifyTargetTypeEnum.Emp, NotifyTypeEnum.Board);
                    }
                    nf2.SaveAndProcess();
                }
            }


            //處理講師問卷
            List<ClassQuestionnaireView> cList2 = GetByWriteDateNull_DLO(datetime, "T");
            foreach (ClassQuestionnaireView v in cList1)
            {
                NotifyMsgFacade nf1 = new NotifyMsgFacade();
                string str1 = "課程" + v.CourseName + "的問卷尚未填寫";
                nf1.Message = str1;
                nf1.Title = str1;
                nf1.SourceSystem = "eTraining";
                nf1.SourceProgram = "問卷通知";
                nf1.NotifyAdate = datetime;
                nf1.AddNotifyMsgTargetType(v.TeacherCode, NotifyTargetTypeEnum.Teacher, NotifyTypeEnum.Board);
                nf1.SaveAndProcess();
            }

            //處理自訂使用者問卷
            List<ClassQuestionnaireView> cList3 = GetByWriteDateNull_DLO(datetime, "CU");
            foreach (ClassQuestionnaireView v in cList3)
            {
                NotifyMsgFacade nf1 = new NotifyMsgFacade();
                string str1 = "課程" + v.CourseName + "的問卷尚未填寫";
                nf1.Message = str1;
                nf1.Title = str1;
                nf1.SourceSystem = "eTraining";
                nf1.SourceProgram = "問卷通知";
                nf1.NotifyAdate = datetime;
                nf1.AddNotifyMsgTargetType(v.Nobr, NotifyTargetTypeEnum.Emp, NotifyTypeEnum.Board);
                nf1.SaveAndProcess();
            }
        }
    }
}