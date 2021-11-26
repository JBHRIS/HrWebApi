using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

namespace Repo
{
    /// <summary>
    /// trTrainingStudentS 的摘要描述
    /// </summary>
    public class trTrainingStudentS_Repo
    {
        public dcTrainingDataContext dc{get;set;}
        private qBaseM_Repo qBaseRepo = new qBaseM_Repo();
        public trTrainingStudentS_Repo()
        {
            dc = new dcTrainingDataContext();
        }

        public trTrainingStudentS_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Update(trTrainingStudentS o)
        {
            DcHelper.Detach(o);
            dc.trTrainingStudentS.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Delete(trTrainingStudentS o)
        {
            DcHelper.Detach(o);
            dc.trTrainingStudentS.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trTrainingStudentS.DeleteOnSubmit(o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public trTrainingStudentS GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.trTrainingStudentS
                        where sm.iAutoKey ==id
                        select sm).FirstOrDefault();
            }
        }


        /// <summary>
        /// By ClassID
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<trTrainingStudentS> GetByClassID(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.trTrainingStudentS
                        where sm.iClassAutoKey == classID
                        select sm).ToList();
            }
        }
    }
}