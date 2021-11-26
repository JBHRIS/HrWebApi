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
    public class OjtUnitCard_Repo
    {
        private dcTrainingDataContext dc;

        public OjtUnitCard_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public OjtUnitCard_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(OjtUnitCard o)
        {
            dc.OjtUnitCard.InsertOnSubmit(o);            
        }

        public void Delete(OjtUnitCard o)
        {
            dc.OjtUnitCard.DeleteOnSubmit(o);
        }

        public void Delete(int id)
        {
            var obj = (from c in dc.OjtUnitCard
                       where c.iAutoKey == id
                       select c).FirstOrDefault();
            dc.OjtUnitCard.DeleteOnSubmit(obj);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        /// <summary>
        /// Get All by有效的績效卡
        /// </summary>
        /// <returns></returns>
        public List<OjtUnitCard> GetAllByOjtCardValid_DLO()
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<OjtUnitCard>(l => l.trOJTTemplate);
            dlo.LoadWith<OjtUnitCard>(l => l.DEPT);
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in ldc.OjtUnitCard 
                        where c.trOJTTemplate.IsValid == true
                         select c).ToList();
            }
        }


        /// <summary>
        /// Get By Dept && OjtCard is Valid
        /// </summary>
        /// <param name="dept"></param>
        /// <returns></returns>
        public List<OjtUnitCard> GetByDeptByOjtCardValid(string dept)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.OjtUnitCard
                        where c.OjtUnit == dept &&
                        c.trOJTTemplate.IsValid == true
                        select c).ToList();
            }
        }

    }
}