using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Collections;
using JBHRModel;
namespace BL
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class FileStructureGroup_Repo
    {
        public JBHRModelDataContext dc { get; set; }     

        public FileStructureGroup_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public FileStructureGroup_Repo(JBHRModelDataContext d)
        {
            dc = d;            
        }

        public void Add(FileStructureGroup o)
        {
            dc.FileStructureGroup.InsertOnSubmit(o);           
        }

        public void Delete(FileStructureGroup o)
        {
            DcHelper.Detach(o);
            dc.FileStructureGroup.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.FileStructureGroup.DeleteOnSubmit(o);
        }

        //public void DeleteByPK(int id)
        //{
        //    var obj = (from c in dc.FileStructureGroup
        //               where c.iAutoKey == id
        //               select c).FirstOrDefault();
        //    dc.FileStructureGroup.DeleteOnSubmit(obj);
        //}


        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<FileStructureGroup> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.FileStructureGroup
                        select c).ToList();
            }
        }

        public List<FileStructureGroup> GetByGroupId_Dlo(int id)
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<FileStructureGroup>(l => l.FileStructure);
                ldc.LoadOptions = dlo;

                return (from c in ldc.FileStructureGroup
                        where c.GroupId==id
                        select c).ToList();
            }
        }
    }
}