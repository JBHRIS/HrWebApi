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
    public class UPFILE_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public UPFILE_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public UPFILE_REPO()
        {
            dc = new JBHRModelDataContext();
        }
        public void Add(UPFILE o)
        {
            dc.UPFILE.InsertOnSubmit(o);
        }
        public void Delete(UPFILE o)
        {
            DcHelper.Detach(o);
            dc.UPFILE.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.UPFILE.DeleteOnSubmit(o);
        }

        public void Update(UPFILE o)
        {
            DcHelper.Detach(o);
            dc.UPFILE.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

 
        public UPFILE GetByPk(int id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.UPFILE
                        where c.AUTOKEY == id
                        select c).FirstOrDefault();
            }
        }

        public List<UPFILE> GetByNewsFileId(string id)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.UPFILE
                        where c.NEWSFILEID == id
                        select c).ToList();
            }
        }
    }
    

}