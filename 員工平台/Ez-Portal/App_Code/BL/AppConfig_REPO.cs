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
    /// AppConfigA 的摘要描述
    /// </summary>
    public class AppConfig_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public AppConfig_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public AppConfig_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public void Add(AppConfig o)
        {
            dc.AppConfig.InsertOnSubmit(o);
        }

        public void Delete(AppConfig o)
        {
            DcHelper.Detach(o);
            dc.AppConfig.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.AppConfig.DeleteOnSubmit(o);
        }

        public void Update(AppConfig o)
        {
            DcHelper.Detach(o);
            dc.AppConfig.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        //public AppConfig GetByID(string id)
        //{
        //    using (JBHRModelDataContext ldc = new JBHRModelDataContext())
        //    {
        //        return (from c in ldc.AppConfig
        //                where c.D_NO == id
        //                select c).FirstOrDefault();
        //    }
        //}


    }
}