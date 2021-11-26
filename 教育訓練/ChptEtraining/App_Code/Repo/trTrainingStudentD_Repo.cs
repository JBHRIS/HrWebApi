using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

namespace Repo
{
    /// <summary>
    /// trTrainingStudentD 的摘要描述
    /// </summary>
    public class trTrainingStudentD_Repo
    {
        public dcTrainingDataContext dc{get;set;}
        private qBaseM_Repo qBaseRepo = new qBaseM_Repo();
        public trTrainingStudentD_Repo()
        {
            dc = new dcTrainingDataContext();
        }

        public trTrainingStudentD_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }

        public void Update(trTrainingStudentD o)
        {
            DcHelper.Detach(o);
            dc.trTrainingStudentD.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Delete(trTrainingStudentD o)
        {
            DcHelper.Detach(o);
            dc.trTrainingStudentD.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trTrainingStudentD.DeleteOnSubmit(o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public trTrainingStudentD GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from sm in ldc.trTrainingStudentD
                        where sm.iAutoKey ==id
                        select sm).FirstOrDefault();
            }
        }


        /// <summary>
        /// 取得資料By Year
        /// </summary>
        /// <param name="classID"></param>
        /// <returns></returns>
        public List<trTrainingStudentD> GetByYear(int Ayear)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trTrainingStudentD
                        where c.iYear == Ayear
                        select c).ToList();
            }
        }
    }
}