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
    public class trTeacher_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public trTeacher_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trTeacher_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(trTeacher o)
        {
            dc.trTeacher.InsertOnSubmit(o);
        }
        public void Delete(trTeacher o)
        {
            DcHelper.Detach(o);
            dc.trTeacher.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trTeacher.DeleteOnSubmit(o);
        }

        public void Update(trTeacher o)
        {
            DcHelper.Detach(o);
            dc.trTeacher.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public void Update(List<trTeacher> list)
        {
            foreach (var o in list)
            {
                DcHelper.Detach(o);
                dc.trTeacher.Attach(o);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            }
        }


        public trTeacher GetByAutoKey(int autoKey)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trTeacher
                        where c.iAutoKey == autoKey
                        select c).FirstOrDefault();
            }
        }



        /// <summary>
        /// For外部講師，抓取工號及密碼符合
        /// </summary>
        /// <returns></returns>
        public trTeacher GetOuterTeacherByNobrPwd(string Aid,string Apwd)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trTeacher
                        where c.sOuterTeacherId == Aid && c.sTeacherPWD == Apwd
                        select c).FirstOrDefault();
            }
        }


        /// <summary>
        /// 同步內部講師工作經歷、授課經驗
        /// </summary>
        public void SyncInnerTeacherData()
        {
            List<trTeacher> innerTeacherList = GetInnerTeacher_DLO();
            BASETTS_Repo basettsRepo = new BASETTS_Repo();
            List<string> tempList = new List<string>();
            int pos = -1;

            foreach (var t in innerTeacherList)
            {
                if (basettsRepo.IsHired(t.sNobr))
                {
                    //處理工作經驗
                    string str = "";                    
                    var tts = t.BASE.BASETTS.Where(s => s.TTSCODE == "1" || s.TTSCODE == "4" || s.TTSCODE == "6");
                    if (tts != null)
                    {
                        tempList.Clear();

                        for (int i = 0; i < tts.Count();i++ )
                        {                            
                            if (!tempList.Contains(tts.ElementAt(i).JOB1.JOB1))
                            {
                                tempList.Add(tts.ElementAt(i).JOB1.JOB1);
                                str = str + tts.ElementAt(i).JOB1.JOB_NAME +"、";
                            }
                        }

                       pos = str.LastIndexOf("、");
                       if (pos > 0)
                       {
                           str=str.Remove(pos);
                       }

                       t.sWorkExp = str;
                    }
                    
                    //處理授課經歷
                    var courses = t.trAttendClassTeacher.Where(c=> c.trTrainingDetailM !=null && c.trTrainingDetailM.dDateD.HasValue == true 
                        && c.trTrainingDetailM.trCourse !=null
                        && c.trTrainingDetailM.dDateD.Value <= DateTime.Now
                        && c.trTrainingDetailM.bIsPublished == true);

                    if (courses != null)
                    {
                        tempList.Clear();
                        str = "";
                        for (int i = 0; i < courses.Count(); i++)
                        {
                            if (!tempList.Contains(courses.ElementAt(i).trTrainingDetailM.trCourse.sCode))
                            {
                                tempList.Add(courses.ElementAt(i).trTrainingDetailM.trCourse.sCode);
                                str = str + courses.ElementAt(i).trTrainingDetailM.trCourse.sName + "、";
                            }
                        }

                        pos = str.LastIndexOf("、");
                        if (pos > 0)
                        {
                            str = str.Remove(pos);
                        }

                        t.sTeachExp = str;
                    }

                    dc.SubmitChanges();
                }
            }
        }

        /// <summary>
        /// 同步外部講師授課經驗
        /// </summary>
        public void SyncOuterTeacherData()
        {
            List<trTeacher> outerTeacherList = GetOuterTeacher_DLO();            
            List<string> tempList = new List<string>();
            int pos = -1;

            foreach (var t in outerTeacherList)
            {
                    string str = "";                    

                    //處理授課經歷
                    var courses = t.trAttendClassTeacher.Where(c => c.trTrainingDetailM != null && c.trTrainingDetailM.dDateD.HasValue == true
                        && c.trTrainingDetailM.trCourse != null
                        && c.trTrainingDetailM.dDateD.Value <= DateTime.Now
                        && c.trTrainingDetailM.bIsPublished == true);

                    if (courses != null)
                    {
                        tempList.Clear();
                        str = "";
                        for (int i = 0; i < courses.Count(); i++)
                        {
                            if (!tempList.Contains(courses.ElementAt(i).trTrainingDetailM.trCourse.sCode))
                            {
                                tempList.Add(courses.ElementAt(i).trTrainingDetailM.trCourse.sCode);
                                str = str + courses.ElementAt(i).trTrainingDetailM.trCourse.sName + "、";
                            }
                        }

                        pos = str.LastIndexOf("、");
                        if (pos > 0)
                        {
                            str = str.Remove(pos);
                        }

                        t.sTeachExp = str;
                    }

                    dc.SubmitChanges();
            }
        }


        /// <summary>
        /// 抓取內部講師
        /// </summary>
        /// <returns></returns>
        public List<trTeacher> GetInnerTeacher_DLO()
        {
          //  dc.Log = new DebuggerWriter();
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTeacher>(l => l.BASE);
                dlo.LoadWith<trTeacher>(l => l.trAttendClassTeacher);
                dlo.LoadWith<trAttendClassTeacher>(l => l.trTrainingDetailM);
                dlo.LoadWith<trTrainingDetailM>(l => l.trCourse);
                dlo.LoadWith<BASE>(l => l.BASETTS);
                dlo.LoadWith<BASETTS>(l => l.JOB1);
                ldc.LoadOptions = dlo;
                return (from c in ldc.trTeacher where c.bEntTeacherType == true select c).ToList();
            }
        }

        public trTeacher GetByNobr(string Avalue)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trTeacher where c.sNobr==Avalue select c).FirstOrDefault();
            }
        }

        public trTeacher GetByOuterTeacherId(string Avalue)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trTeacher where c.sOuterTeacherId == Avalue select c).FirstOrDefault();
            }
        }

        public List<trTeacher> GetOuterTeacher_DLO()
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<trTeacher>(l => l.trAttendClassTeacher);
                ldc.LoadOptions = dlo;
                return (from c in dc.trTeacher where c.bEntTeacherType == false select c).ToList();
            }
        }


        public trTeacher GetByCode(string code)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trTeacher
                        where c.sCode == code
                        select c).FirstOrDefault();
            }
        }
    }
}