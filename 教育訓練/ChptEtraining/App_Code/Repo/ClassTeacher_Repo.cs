using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Data.Linq;

namespace Repo
{    
    /// <summary>
    /// DEPT_Repo 的摘要描述
    /// </summary>
    /// 
    public class ClassTeacher_Repo
    {
        public  dcTrainingDataContext dc{get;set;}     

        public ClassTeacher_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public ClassTeacher_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Add(ClassTeacher o)
        {
            dc.ClassTeacher.InsertOnSubmit(o);
        }

        public void Delete(ClassTeacher o)
        {
            DcHelper.Detach(o); 
            dc.ClassTeacher.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
            dc.ClassTeacher.DeleteOnSubmit(o);
        }

        public void Update(ClassTeacher o)
        {
            DcHelper.Detach(o); 
            dc.ClassTeacher.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
        }

        public void Update(List<ClassTeacher> list)
        {
            foreach (var o in list)
            {
                DcHelper.Detach(o);
                dc.ClassTeacher.Attach(o);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<ClassTeacher> GetByTeacherCode(string code)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.ClassTeacher
                        where c.sTeacherCode == code
                        select c).ToList();
            }
        }


        public ClassTeacher GetByPk(int pk)
        {
            using (dcTrainingDataContext tdc = new dcTrainingDataContext())
            {
                return (from c in tdc.ClassTeacher
                        where c.iAutoKey==pk
                        select c).FirstOrDefault();
            }
        }

        public ClassTeacher GetByPkFromList(int pk,List<ClassTeacher> list)
        {
                return (from c in list
                        where c.iAutoKey == pk
                        select c).FirstOrDefault();
        }

        public List<ClassTeacher> GetByClassKey(int classId)
        {
            using (dcTrainingDataContext tdc = new dcTrainingDataContext())
            {
                return (from c in tdc.ClassTeacher
                        where c.iClassAutoKey == classId
                        select c).ToList();
           }
        }

        public List<ClassTeacher> GetByClassKeyWithEntTeacher(int classId)
        {
            using ( dcTrainingDataContext tdc = new dcTrainingDataContext() )
            {
                return (from c in tdc.ClassTeacher
                        where c.iClassAutoKey == classId && c.trTeacher.bEntTeacherType                        
                        select c).ToList();
            }
        }


        public List<ClassTeacher> GetByClassKey_DLO(int classId)
        {
            using (dcTrainingDataContext tdc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ClassTeacher>(l => l.trTeacher);
                tdc.LoadOptions = dlo;
                return (from c in tdc.ClassTeacher
                        where c.iClassAutoKey == classId
                        select c).ToList();
            }
        }


        public string GetAllTeacherName(List<ClassTeacher> list)
        {
            string str = "";
            for ( int i = 0 ; i < list.Count ; i++ )
            {
                if ( i == 0 )
                    str = str + list[i].trTeacher.sName;
                else
                    str = str + "、" + list[i].trTeacher.sName;
            }
            return str;
        }
    }
}