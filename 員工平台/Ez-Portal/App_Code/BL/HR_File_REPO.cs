using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JBHRModel;
using System.Data.Linq;


namespace BL
{
    /// <summary>
    /// DEPTA 的摘要描述
    /// </summary>
    public class HR_File_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public HR_File_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public HR_File_REPO()
        {
            dc = new JBHRModelDataContext();
        }
        public void Add(HR_File o)
        {
            dc.HR_File.InsertOnSubmit(o);
        }
        public void Delete(HR_File o)
        {
            DcHelper.Detach(o);
            dc.HR_File.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.HR_File.DeleteOnSubmit(o);
        }

        public void Update(HR_File o)
        {
            DcHelper.Detach(o);
            dc.HR_File.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

 
        public HR_File GetByPk(string id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.HR_File
                        where c.ID ==id
                        select c).FirstOrDefault();
            }
        }

        public List<HR_File> GetByGroupID(string id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.HR_File
                        where c.GroupID == id
                        select c).ToList();
            }
        }
    }
    

}