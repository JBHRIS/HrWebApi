using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using JBHRModel;
namespace BL
{
    public class JBSystemRepo
    {        
        public JBHRModelDataContext dc { get; set; }       
        public JBSystemRepo()
        {
            dc = new JBHRModelDataContext();
        }

        public JBSystemRepo(JBHRModelDataContext o)
        {
            dc = o;
        }

        public void Add(JBSystem o)
        {
            dc.JBSystem.InsertOnSubmit(o);
        }

        public void Delete(JBSystem o)
        {
            DcHelper.Detach(o);
            dc.JBSystem.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.JBSystem.DeleteOnSubmit(o);
        }

        public void Update(JBSystem o)
        {
            DcHelper.Detach(o);
            dc.JBSystem.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        }      

        public void Save()
        {
            dc.SubmitChanges();
        }

        /// <summary>
        /// 取得 By SystemEvent Code
        /// </summary>
        /// <param name="Acode"></param>
        /// <returns></returns>
        public JBSystem GetByCode(string Acode)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.JBSystem
                        where c.SystemCode == Acode
                        select c).FirstOrDefault();
            }
        }


        /// <summary>
        /// 是否有值
        /// </summary>
        /// <param name="Acode"></param>
        /// <returns></returns>
        public bool IsHaveValue(string Acode)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.JBSystem
                        where c.SystemCode == Acode
                        select c).Any();
            }
        }
    }
}
