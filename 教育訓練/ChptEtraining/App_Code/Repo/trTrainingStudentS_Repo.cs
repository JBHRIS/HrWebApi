using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

namespace Repo
{
    /// <summary>
    /// trTrainingDetailS 的摘要描述
    /// </summary>
    public class trTrainingDetailS_Repo
    {
        public dcTrainingDataContext dc{get;set;}
        private qBaseM_Repo qBaseRepo = new qBaseM_Repo();
        public trTrainingDetailS_Repo()
        {
            dc = new dcTrainingDataContext();
        }

        public trTrainingDetailS_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Update(trTrainingDetailS o)
        {
            DcHelper.Detach(o);
            dc.trTrainingDetailS.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Delete(trTrainingDetailS o)
        {
            DcHelper.Detach(o);
            dc.trTrainingDetailS.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trTrainingDetailS.DeleteOnSubmit(o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public trTrainingDetailS GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.trTrainingDetailS
                        where sm.iAutoKey ==id
                        select sm).FirstOrDefault();
            }
        }


        /// <summary>
        /// By ClassID
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<trTrainingDetailS> GetByClassID(int classID)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.trTrainingDetailS
                        where sm.iClassAutoKey == classID
                        select sm).ToList();
            }
        }
    }
}