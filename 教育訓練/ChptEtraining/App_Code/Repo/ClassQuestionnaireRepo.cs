using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

namespace Repo
{
    /// <summary>
    /// ClassQuestionnaire 的摘要描述
    /// </summary>
    public class ClassQuestionnaireRepo
    {
        public dcTrainingDataContext dc{get;set;}
        private qBaseM_Repo qBaseRepo = new qBaseM_Repo();
        public ClassQuestionnaireRepo()
        {
            dc = new dcTrainingDataContext();
        }

        public ClassQuestionnaireRepo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Update(ClassQuestionnaire o)
        {
            DcHelper.Detach(o);
            dc.ClassQuestionnaire.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Delete(ClassQuestionnaire o)
        {
            DcHelper.Detach(o);
            dc.ClassQuestionnaire.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.ClassQuestionnaire.DeleteOnSubmit(o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public ClassQuestionnaire GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.ClassQuestionnaire
                        where sm.iAutoKey ==id
                        select sm).FirstOrDefault();
            }
        }


        /// <summary>
        /// By ClassID
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<ClassQuestionnaire> GetByClassID(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.ClassQuestionnaire
                        where sm.iClassAutoKey == classID
                        select sm).ToList();
            }
        }

        public List<ClassQuestionnaire> GetByClassID_DLO(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ClassQuestionnaire>(l => l.qQuestionaryM);
                ldc.LoadOptions = dlo;
                return (from sm in ldc.ClassQuestionnaire
                        where sm.iClassAutoKey == classID
                        select sm).ToList();
            }
        }




        public List<ClassQuestionnaire> GetByClassId_Dlo(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<ClassQuestionnaire>(l => l.QTpl);
                ldc.LoadOptions = dlo;
                return (from sm in ldc.ClassQuestionnaire
                        where sm.iClassAutoKey == classID
                        select sm).ToList();
            }
        }
    }
}