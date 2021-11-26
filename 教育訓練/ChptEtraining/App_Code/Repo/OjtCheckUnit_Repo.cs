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
    public class OjtCheckUnit_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public OjtCheckUnit_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public OjtCheckUnit_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(OjtCheckUnit o)
        {
            dc.OjtCheckUnit.InsertOnSubmit(o);            
        }

        public void Delete(OjtCheckUnit o)
        {
            dc.OjtCheckUnit.DeleteOnSubmit(o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        /// <summary>
        /// get by checkUnit , ojtUnit
        /// </summary>
        /// <param name="checkUnit"></param>
        /// <param name="ojtUnit"></param>
        /// <returns></returns>
        public OjtCheckUnit GetByCheckUnitOjtUnit(string checkUnit, string ojtUnit)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in dc.OjtCheckUnit
                        where c.OjtUnit == ojtUnit
                        && c.CheckUnit == checkUnit
                        select c).FirstOrDefault();
            }
        }

        public List<OjtCheckUnit> GetByCheckUnit_DLO(string deptCode)
        {
            DataLoadOptions dlo = new DataLoadOptions();
            dlo.LoadWith<OjtCheckUnit>(l => l.CheckDEPT);
            dlo.LoadWith<OjtCheckUnit>(l => l.OjtDEPT);
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                ldc.LoadOptions = dlo;
                return (from c in dc.OjtCheckUnit
                         where c.CheckUnit == deptCode
                         select c).ToList();
            }
        }
    }
}