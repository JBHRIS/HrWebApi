using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Text;
namespace Repo
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class trRequirementTemplate_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public trRequirementTemplate_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trRequirementTemplate_Repo(dcTrainingDataContext d)
        {
            dc = d;
        }


        public void Add(trRequirementTemplate o)
        {
            dc.trRequirementTemplate.InsertOnSubmit(o);
        }

        public void Update(trRequirementTemplate o)
        {
            DcHelper.Detach(o);
            dc.trRequirementTemplate.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }


        public void Delete(trRequirementTemplate o)
        {
            DcHelper.Detach(o);
            dc.trRequirementTemplate.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trRequirementTemplate.DeleteOnSubmit(o);
        }


        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<trRequirementTemplate> GetAll()
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from c in ldc.trRequirementTemplate
                        select c).ToList();
            }
        }

        public trRequirementTemplate GetByPk(int id)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.trRequirementTemplate
                        where c.iAutoKey == id
                        select c).FirstOrDefault();
            }
        }
    }
}