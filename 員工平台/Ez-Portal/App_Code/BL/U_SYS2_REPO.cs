using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using JBHRModel;


namespace BL
{
    /// <summary>
    /// DEPTA 的摘要描述
    /// </summary>
    public class U_SYS2_REPO
    {
        public JBHRModelDataContext dc { get; set; }
        public U_SYS2_REPO(JBHRModelDataContext o)
        {
            dc = o;
        }

        public U_SYS2_REPO()
        {
            dc = new JBHRModelDataContext();
        }

        public List<U_SYS2> GetAll()
        {
            List<U_SYS2> list = new List<U_SYS2>();
            return (from c in dc.U_SYS2           
                    select c).ToList();            
        }

        public U_SYS2 GetByPk(string Avalue)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.U_SYS2
                        where c.Comp == Avalue
                        select c).FirstOrDefault();
            }
        }



        public U_SYS2 GetAttendDateRangeBySalaDr(string AsalaDr)
        {
                        DATAGROUP_REPO dpRepo = new DATAGROUP_REPO();
            DATAGROUP dpObj = dpRepo.GetByPk(AsalaDr);
            if (dpObj != null)
            {
                U_SYS2_REPO usys2Repo = new U_SYS2_REPO();
                return usys2Repo.GetByPk(dpObj.COMP);
            }
            else
                throw new ApplicationException("抓取不到對應的datagroup");

        }
    }
    

}