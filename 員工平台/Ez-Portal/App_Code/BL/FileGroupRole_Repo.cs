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
    public class FileGroupRole_Repo
    {
        public JBHRModelDataContext dc { get; set; }     

        public FileGroupRole_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public FileGroupRole_Repo(JBHRModelDataContext d)
        {
            dc = d;            
        }

        public void Add(FileGroupRole o)
        {
            dc.FileGroupRole.InsertOnSubmit(o);           
        }

        public void Delete(FileGroupRole o)
        {
            DcHelper.Detach(o);
            dc.FileGroupRole.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.FileGroupRole.DeleteOnSubmit(o);
        }

        public void Delete(List<FileGroupRole> list)
        {
            foreach ( var o in list )
                Delete(o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<FileGroupRole> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.FileGroupRole
                        select c).ToList();
            }
        }

        public List<FileGroupRole> GetByGroupId(int id)
        {
            using ( JBHRModelDataContext ldc = new JBHRModelDataContext() )
            {
                return (from c in ldc.FileGroupRole
                        where c.FileGroupId==id
                        select c).ToList();
            }
        }

        public List<FileGroupRole> GetByRoleList_Dlo(List<string> rList)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<FileGroupRole>(l => l.FileGroup);
                dlo.LoadWith<FileGroup>(l => l.FileStructureGroup);
                dlo.LoadWith<FileStructureGroup>(l => l.FileStructure);
                dlo.LoadWith<FileStructure>(l => l.FileStructureRole);
                ldc.LoadOptions = dlo;
                return (from c in ldc.FileGroupRole
                        where rList.Contains(c.Role) 
                        select c).ToList();
            }
        }
    }
}