using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

namespace Repo
{
    /// <summary>
    /// trTrainingStudentPresence 的摘要描述
    /// </summary>
    public class trTrainingStudentPresence_Repo
    {
        public dcTrainingDataContext dc{get;set;}
        private qBaseM_Repo qBaseRepo = new qBaseM_Repo();
        public trTrainingStudentPresence_Repo()
        {
            dc = new dcTrainingDataContext();
        }

        public trTrainingStudentPresence_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Delete(trTrainingStudentPresence o)
        {
            DcHelper.Detach(o);
            dc.trTrainingStudentPresence.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trTrainingStudentPresence.DeleteOnSubmit(o);
        }

        public void Update(trTrainingStudentPresence o)
        {
            DcHelper.Detach(o);
            dc.trTrainingStudentPresence.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public trTrainingStudentPresence GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.trTrainingStudentPresence
                        where sm.iAutoKey ==id
                        select sm).FirstOrDefault();
            }
        }


        /// <summary>
        /// By ClassID
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<trTrainingStudentPresence> GetByClassID(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.trTrainingStudentPresence
                        where sm.iClassAutoKey == classID
                        select sm).ToList();
            }
        }
    }
}