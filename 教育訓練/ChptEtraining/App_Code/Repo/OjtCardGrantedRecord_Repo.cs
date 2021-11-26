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
    public class OjtCardGrantedRecord_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public OjtCardGrantedRecord_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public OjtCardGrantedRecord_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(OjtCardGrantedRecord o)
        {
            dc.OjtCardGrantedRecord.InsertOnSubmit(o);            
        }

        public void Delete(OjtCardGrantedRecord o)
        {
            dc.OjtCardGrantedRecord.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.OjtCardGrantedRecord.DeleteOnSubmit(o);
        }


        public void DeleteByPK(int id)
        {
            var obj = (from c in dc.OjtCardGrantedRecord
                       where c.iAutoKey == id
                       select c).FirstOrDefault();
            dc.OjtCardGrantedRecord.DeleteOnSubmit(obj);
        }

        public void Update(OjtCardGrantedRecord o)
        {
            dc.OjtCardGrantedRecord.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }


        public List<OjtCardGrantedRecord> GetByNobr(string nobr)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.OjtCardGrantedRecord
                        where c.sNobr == nobr
                        select c).ToList();
            }
        }
    }
}