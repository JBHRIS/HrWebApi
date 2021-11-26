using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Collections;
namespace Repo
{
    /// <summary>
    /// BASE_Repo 的摘要描述
    /// </summary>
    public class sysUserRole_Repo
    {
        public dcTrainingDataContext dc { get; set; }

        public sysUserRole_Repo()
        {
            dc = new dcTrainingDataContext();
        }
        public sysUserRole_Repo(dcTrainingDataContext d)
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

        //public void DeleteByPK(int id)
        //{
        //    var obj = (from c in dc.sysUserRole
        //               where c.iAutoKey == id
        //               select c).FirstOrDefault();
        //    dc.sysUserRole.DeleteOnSubmit(obj);
        //}

        //public void Update(sysUserRole o)
        //{
        //    dc.sysUserRole.Attach(o);
        //    dc.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, o);
        //}


        public void Save()
        {
            dc.SubmitChanges();
        }

        public List<sysUserRole> GetByNobr(string Anobr)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.sysUserRole
                        where c.NOBR == Anobr
                        select c).ToList();
            }
        }

        public sysUserRole GetByNobrRoleKey(string Anobr, int AroleKey)
        {
            using (dcTrainingDataContext ldc = new dcTrainingDataContext())
            {
                return (from c in ldc.sysUserRole
                        where c.NOBR == Anobr
                        && c.iRoleKey == AroleKey
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
                list.Add(c.iRoleKey.ToString());

            return list;
        }

        /// <summary>
        /// 腳色list轉int
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int TransIntRole(ArrayList list)
        {
            var roles_list = (from c in dc.sysRole orderby c.iKey descending select c).ToList();
            int result = 0;

            foreach (string str in list)
            {
                var data = from c in roles_list
                           where c.iKey.ToString() == str
                           select c;

                var d = data.FirstOrDefault();

                if (d != null)
                {
                    result = result + d.iKey;
                }
            }

            return result;
        }

        public void CheckUserRole(String nobr, bool isMang)
        {
            //16是一般使用者  32是主管、64講師
            var userRoles = GetByNobr(nobr);

            var user = (from c in userRoles where c.NOBR == nobr && c.iRoleKey == 16 select c).FirstOrDefault();

            if (user == null)
            {
                var role1 = (from c in dc.sysRole where c.iKey == 16 select c).FirstOrDefault();
                if (role1 != null)
                {
                    sysUserRole obj = new sysUserRole();
                    obj.iRoleAutoKey = role1.iAutoKey;
                    obj.iRoleKey = role1.iKey;
                    obj.NOBR = nobr;
                    dc.sysUserRole.InsertOnSubmit(obj);
                    dc.SubmitChanges();
                }
            }


            //JbhrService.JbhrServiceClient jbhrService = new JbhrService.JbhrServiceClient();
            var mang = (from c in userRoles where c.NOBR == nobr && c.iRoleKey == 32 select c).FirstOrDefault();
            //if (isMang || jbhrService.IsInRoleManage(nobr))
            if (isMang)
            {
                if (mang == null)
                {
                    var role2 = (from c in dc.sysRole where c.iKey == 32 select c).FirstOrDefault();
                    if (role2 != null)
                    {
                        sysUserRole obj = new sysUserRole();
                        obj.iRoleAutoKey = role2.iAutoKey;
                        obj.iRoleKey = role2.iKey;
                        obj.NOBR = nobr;
                        dc.sysUserRole.InsertOnSubmit(obj);
                        dc.SubmitChanges();
                    }
                }
            }
            else //如果Portal沒主管權限，但資料庫有設定，則刪除
            {
                if (mang != null)
                {
                    Delete(mang);
                    Save();
                }
            }


            //檢查是否具講師資格
            trTeacher_Repo teacherRepo = new trTeacher_Repo();
            var teacherRole = teacherRepo.GetByNobr(nobr); //GetByNobrRoleKey(nobr,64);

            if (teacherRole != null)
            {
                var t = (from c in userRoles where c.NOBR == nobr && c.iRoleKey == 64 select c).FirstOrDefault();
                if (t == null)
                {
                    var role3 = (from c in dc.sysRole where c.iKey == 64 select c).FirstOrDefault();
                    if (role3 != null)
                    {
                        sysUserRole obj = new sysUserRole();
                        obj.iRoleAutoKey = role3.iAutoKey;
                        obj.iRoleKey = role3.iKey;
                        obj.NOBR = nobr;
                        dc.sysUserRole.InsertOnSubmit(obj);
                        dc.SubmitChanges();
                    }
                }
            }
        }


        public void CheckUserRole(String nobr)
        {
            //16是一般使用者  32是主管、64講師
            var userRoles = GetByNobr(nobr);
            var user = (from c in userRoles where c.NOBR == nobr && c.iRoleKey == 16 select c).FirstOrDefault();

            if (user == null)
            {
                var role1 = (from c in dc.sysRole where c.iKey == 16 select c).FirstOrDefault();
                if (role1 != null)
                {
                    sysUserRole obj = new sysUserRole();
                    obj.iRoleAutoKey = role1.iAutoKey;
                    obj.iRoleKey = role1.iKey;
                    obj.NOBR = nobr;
                    dc.sysUserRole.InsertOnSubmit(obj);
                    dc.SubmitChanges();
                }
            }

            var mang = (from c in userRoles where c.NOBR == nobr && c.iRoleKey == 32 select c).FirstOrDefault();
            if (mang==null)
            {
                DEPT_Repo deptRepo = new DEPT_Repo();
                List<DEPT> deptList= deptRepo.GetByNobr(nobr);

                if (deptList.Count>0)
                {
                    var role2 = (from c in dc.sysRole where c.iKey == 32 select c).FirstOrDefault();
                    if (role2 != null)
                    {
                        sysUserRole obj = new sysUserRole();
                        obj.iRoleAutoKey = role2.iAutoKey;
                        obj.iRoleKey = role2.iKey;
                        obj.NOBR = nobr;
                        dc.sysUserRole.InsertOnSubmit(obj);
                        dc.SubmitChanges();
                    }
                }
            }
            //else //如果Portal沒主管權限，但資料庫有設定，則刪除
            //{
            //    if (mang != null)
            //    {
            //        Delete(mang);
            //        Save();
            //    }
            //}


            //檢查是否具講師資格
            trTeacher_Repo teacherRepo = new trTeacher_Repo();
            var teacherRole = teacherRepo.GetByNobr(nobr); //GetByNobrRoleKey(nobr,64);

            if (teacherRole != null)
            {
                var t = (from c in userRoles where c.NOBR == nobr && c.iRoleKey == 64 select c).FirstOrDefault();
                if (t == null)
                {
                    var role3 = (from c in dc.sysRole where c.iKey == 64 select c).FirstOrDefault();
                    if (role3 != null)
                    {
                        sysUserRole obj = new sysUserRole();
                        obj.iRoleAutoKey = role3.iAutoKey;
                        obj.iRoleKey = role3.iKey;
                        obj.NOBR = nobr;
                        dc.sysUserRole.InsertOnSubmit(obj);
                        dc.SubmitChanges();
                    }
                }
            }
        }
    }
}