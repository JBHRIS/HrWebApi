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
    public class SalaryPassWord_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public SalaryPassWord_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public SalaryPassWord_REPO()
        {
            dc = new JBHRModelDataContext();
        }
        public void Add(SalaryPassWord o)
        {
            dc.SalaryPassWord.InsertOnSubmit(o);
        }

        public void Delete(SalaryPassWord o)
        {
            dc.SalaryPassWord.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.SalaryPassWord.DeleteOnSubmit(o);
        }

        public void Update(SalaryPassWord o)
        {
            DcHelper.Detach(o);
            dc.SalaryPassWord.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        //public List<SalaryPassWord> GetAll()
        //{
        //    List<SalaryPassWord> list = new List<SalaryPassWord>();
        //    return (from c in dc.SalaryPassWord
        //            select c).ToList();
        //}


        public SalaryPassWord GetByNobr(string nobr)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.SalaryPassWord
                        where c.sNobr ==nobr
                        select c).FirstOrDefault();
            }
        }
    }


}