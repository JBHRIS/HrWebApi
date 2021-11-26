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
    public class qQuestionaryM_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public qQuestionaryM_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public qQuestionaryM_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public qQuestionaryM GetByPk(string code)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from c in ldc.qQuestionaryM
                        where c.sCode == code
                        select c).FirstOrDefault();
            }
        }

        public void Add(qQuestionaryM o)
        {
            dc.qQuestionaryM.InsertOnSubmit(o);            
        }

        public void Delete(qQuestionaryM o)
        {
            dc.qQuestionaryM.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.qQuestionaryM.DeleteOnSubmit(o);
        }

        public void DeleteByPK(int id)
        {
            var obj = (from c in dc.qQuestionaryM
                       where c.iAutokey == id
                       select c).FirstOrDefault();
            dc.qQuestionaryM.DeleteOnSubmit(obj);
        }

        public void Update(qQuestionaryM o)
        {
            dc.qQuestionaryM.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

    }
}