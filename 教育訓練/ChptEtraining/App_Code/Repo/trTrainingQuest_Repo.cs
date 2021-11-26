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
    public class trTrainingQuest_Repo
    {
        public dcTrainingDataContext dc { get; set; }     

        public trTrainingQuest_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public trTrainingQuest_Repo(dcTrainingDataContext d)
        {
            dc = d;            
        }


        public void Add(trTrainingQuest o)
        {
            dc.trTrainingQuest.InsertOnSubmit(o);            
        }

        public void Delete(trTrainingQuest o)
        {
            DcHelper.Detach(o); 
            dc.trTrainingQuest.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.trTrainingQuest.DeleteOnSubmit(o);
        }


        public void DeleteList(List<trTrainingQuest> list)
        {
            foreach (var o in list)
            {
                DcHelper.Detach(o);
                dc.trTrainingQuest.Attach(o);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
                dc.trTrainingQuest.DeleteOnSubmit(o);
            }
        }

        public void UpdateList(List<trTrainingQuest> list)
        {
            foreach ( var o in list )
            {
                DcHelper.Detach(o);
                dc.trTrainingQuest.Attach(o);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
            }
        }

        public void Update(trTrainingQuest o)
        {
            DcHelper.Detach(o); 
            dc.trTrainingQuest.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<trTrainingQuest> GetByYearNobrManager(int Ayear , string Anobr , string Amanager)
        {
            using ( dcTrainingDataContext ldc = new dcTrainingDataContext() )
            {
                return (from c in ldc.trTrainingQuest
                        where c.iYear==Ayear && c.sNobr==Anobr && c.sManage == Amanager                    
                        select c).ToList();
            }
        }

    }
}