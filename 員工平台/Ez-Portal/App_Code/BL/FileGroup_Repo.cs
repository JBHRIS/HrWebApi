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
    public class FileGroup_Repo
    {
        public JBHRModelDataContext dc { get; set; }     

        public FileGroup_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public FileGroup_Repo(JBHRModelDataContext d)
        {
            dc = d;            
        }

        public void Add(FileGroup o)
        {
            dc.FileGroup.InsertOnSubmit(o);  
        }

        public void Delete(FileGroup o)
        {
            dc.FileGroup.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.FileGroup.DeleteOnSubmit(o);
        }

        public void DeleteById(int id)
        {
            var obj = (from c in dc.FileGroup
                       where c.Id==id
                       select c).FirstOrDefault();
            dc.FileGroup.DeleteOnSubmit(obj);

            var fgrlist = (from c in dc.FileGroupRole
                        where c.FileGroupId == id
                        select c).ToList();
            dc.FileGroupRole.DeleteAllOnSubmit(fgrlist);

            var fsglist = (from c in dc.FileStructureGroup
                        where c.GroupId == id
                        select c).ToList();
            dc.FileStructureGroup.DeleteAllOnSubmit(fsglist);
        }

        public void Update(FileGroup o)
        {
            DcHelper.Detach(o);
            dc.FileGroup.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues , o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<FileGroup> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.FileGroup
                        select c).ToList();
            }
        }

        public FileGroup GetById(int id)
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                return (from c in ldc.FileGroup
                        where c.Id == id
                        select c).FirstOrDefault();
            }
        }
    }
}