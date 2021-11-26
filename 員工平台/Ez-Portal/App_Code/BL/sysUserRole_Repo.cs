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
    public class sysUserRole_Repo
    {
        public JBHRModelDataContext dc { get; set; }

        public sysUserRole_Repo()
        {
            dc = new JBHRModelDataContext();
        }
        public sysUserRole_Repo(JBHRModelDataContext d)
        {
            dc = d;
        }

        public void Add(sysUserRole o)
        {
            dc.sysUserRole.InsertOnSubmit(o);
        }

        public void Delete(sysUserRole o)
        {
            DcHelper.Detach(o);
            dc.sysUserRole.Attach(o);
            dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
            dc.sysUserRole.DeleteOnSubmit(o);
        }

        public void Delete(List<sysUserRole> list)
        {
            foreach (var o in list)
            {
                DcHelper.Detach(o);
                dc.sysUserRole.Attach(o);
                dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
                dc.sysUserRole.DeleteOnSubmit(o);
            }
        }

        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<sysUserRole> GetByNobr(string Anobr)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.sysUserRole
                        where c.NOBR == Anobr
                        select c).ToList();
            }
        }

        public sysUserRole GetByNobrRoleCode(string Anobr, string AroleKey)
        {
            using (JBHRModelDataContext ldc = new JBHRModelDataContext())
            {
                return (from c in ldc.sysUserRole
                        where c.NOBR == Anobr
                        && c.RoleCode == AroleKey
                        select c).FirstOrDefault();
            }
        }

        /// <summary>
        /// 回傳User 的Role array
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ArrayList GetUserRoles(string userId)
        {
            ArrayList list = new ArrayList();

            var data = GetByNobr(userId);

            foreach (var c in data)
                list.Add(c.RoleCode);

            return list;
        }

        public void CheckUserRole(string nobr)
        {
            var obj=GetByNobrRoleCode(nobr, "Emp");
            if (obj == null)
            {
                obj = new sysUserRole();
                obj.NOBR = nobr;
                obj.RoleCode = "Emp";
                Add(obj);
                Save();
            }

            //DEPT_REPO deptRepo = new DEPT_REPO();
            //var deptList =deptRepo.GetByNobr(nobr);
            //if (deptList.Count > 0)
            //{
            //    var mangObj = GetByNobrRoleCode(nobr, "Manager");
            //    if (mangObj == null)
            //    {
            //        mangObj = new sysUserRole();
            //        mangObj.NOBR = nobr;
            //        mangObj.RoleCode = "Manager";
            //        Add(mangObj);
            //        Save();
            //    }
            //}
            //else
            //{
            //    var mangObj = GetByNobrRoleCode(nobr, "Manager");
            //    if (mangObj != null)
            //    {
            //        Delete(mangObj);
            //        Save();
            //    }
            //}

        }
    }
}