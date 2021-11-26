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
    public class NotifyApplyUpdateBase_REPO
    {

        public JBHRModelDataContext dc { get; set; }
        public NotifyApplyUpdateBase_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public NotifyApplyUpdateBase GetByPk(int Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.NotifyApplyUpdateBase
                        where c.Id == Avalue
                        select c).FirstOrDefault();
            }
        }

        public NotifyApplyUpdateBase_REPO()
        {
            dc = new JBHRModelDataContext();
        }
        public void Add(NotifyApplyUpdateBase o)
        {
            dc.NotifyApplyUpdateBase.InsertOnSubmit(o);
        }

        public void Delete(NotifyApplyUpdateBase o)
        {
            DcHelper.Detach(o);
            dc.NotifyApplyUpdateBase.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.NotifyApplyUpdateBase.DeleteOnSubmit(o);
        }

        public void Update(NotifyApplyUpdateBase o)
        {
            DcHelper.Detach(o);
            dc.NotifyApplyUpdateBase.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<NotifyApplyUpdateBase> GetAll()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.NotifyApplyUpdateBase
                        select c).ToList();
            }
        }

        public List<NotifyApplyUpdateBase> GetAll_Dlo()
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<NotifyApplyUpdateBase>(l => l.BASE);
                dlo.LoadWith<NotifyApplyUpdateBase>(l => l.DATAGROUP1);
                ldc.LoadOptions = dlo;
                return (from c in ldc.NotifyApplyUpdateBase
                        select c).ToList();
            }
        }

        public List<NotifyApplyUpdateBase> GetByDataGroup_Dlo(string dpCode)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                DataLoadOptions dlo = new DataLoadOptions();
                dlo.LoadWith<NotifyApplyUpdateBase>(l => l.BASE);
                dlo.LoadWith<NotifyApplyUpdateBase>(l => l.DATAGROUP1);
                ldc.LoadOptions = dlo;
                return (from c in ldc.NotifyApplyUpdateBase
                        where c.DataGroup == dpCode
                        select c).ToList();
            }
        }
    }
}