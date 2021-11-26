using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

namespace Repo
{
    /// <summary>
    /// ClassQuestionnaireCU 的摘要描述
    /// </summary>
    public class ClassQuestionnaireCU_Repo
    {
        public dcTrainingDataContext dc{get;set;}
        private qBaseM_Repo qBaseRepo = new qBaseM_Repo();
        public ClassQuestionnaireCU_Repo()
        {
            dc = new dcTrainingDataContext();
        }

        public ClassQuestionnaireCU_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Update(ClassQuestionnaireCU o)
        {
            DcHelper.Detach(o);
            dc.ClassQuestionnaireCU.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Delete(ClassQuestionnaireCU o)
        {
            DcHelper.Detach(o);
            dc.ClassQuestionnaireCU.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.ClassQuestionnaireCU.DeleteOnSubmit(o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public ClassQuestionnaireCU GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.ClassQuestionnaireCU
                        where sm.iAutoKey ==id
                        select sm).FirstOrDefault();
            }
        }


        /// <summary>
        /// By ClassID
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<ClassQuestionnaireCU> GetByClassID(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.ClassQuestionnaireCU
                        where sm.iClassAutoKey == classID
                        select sm).ToList();
            }
        }


        public List<ClassQuestionnaireCU> GetByClassIdQTplcode(int classID, string qTplCode)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.ClassQuestionnaireCU
                        where sm.iClassAutoKey == classID
                        && sm.qQuestionaryM == qTplCode
                        select sm).ToList();
            }
        }
    }
}