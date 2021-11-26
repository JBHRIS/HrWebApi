using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using Repo;
using System.Collections;
using Telerik.Web.UI;
/// <summary>
/// JUser 的摘要描述
/// </summary>
public class JUser
{
    public static string CacheKey = "jbjob_User";

    public static void SetCacheUser(string Anobr)
    {
        JUser user = new JUser().GetUser(Anobr);
        if (user == null) throw new ApplicationException("can't find user:" + Anobr);

        //HttpContext.Current.Cache.Insert(CacheKey + Anobr , user , null , DateTime.Now.AddMinutes(10) , System.Web.Caching.Cache.NoSlidingExpiration);
        HttpContext.Current.Cache.Insert(CacheKey + Anobr, user, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(120), System.Web.Caching.CacheItemPriority.High, null);
    }

    public static void ClearCacheUser(string Anobr)
    {
        HttpContext.Current.Cache.Remove(CacheKey + Anobr);
    }

    // 從Cache中取得使用者資訊
    public static JUser GetCacheUser(string Anobr)
    {
        string key = CacheKey + Anobr;
        if (HttpContext.Current.Cache[key] != null)
        {
            JUser user = HttpContext.Current.Cache[key] as JUser;
            if (user != null) return user;
            else
            {
                SetCacheUser(Anobr);
                return GetCacheUser(Anobr);
            }
        }
        else
        {
            SetCacheUser(Anobr);
            return GetCacheUser(Anobr);
        }
    }

    public JUser GetUser(string Anobr)
    {
        BASE_Repo baseRepo = new BASE_Repo();
        BASE baseObj = baseRepo.GetEmpByNobrNow_DLO(Anobr);
        if (baseObj != null)
        {
            JUser user = new JUser();
            user.BirthDt = baseObj.BIRDT.Value;
            //user.Comp = baseObj.BASETTS[0].COMP1.COMP1;
            //user.CompName = baseObj.BASETTS[0].COMP1.COMPNAME;
            user.Dept = baseObj.BASETTS[0].DEPT;
            user.DeptM = baseObj.BASETTS[0].DEPTM;
            user.DeptName = baseObj.BASETTS[0].DEPT1.D_NAME;
            user.Depts = baseObj.BASETTS[0].DEPTS;
            user.Di = baseObj.BASETTS[0].DI;
            user.Email = baseObj.EMAIL;
            user.Indt = baseObj.BASETTS[0].INDT.Value;
            user.Job = baseObj.BASETTS[0].JOB;
            user.JobL = baseObj.BASETTS[0].JOBL;
            user.JobName = baseObj.BASETTS[0].JOB1.JOB_NAME;
            user.Mang = baseObj.BASETTS[0].MANG;
            user.Mang1 = baseObj.BASETTS[0].MANG1;
            user.NameC = baseObj.NAME_C;
            user.NameE = baseObj.NAME_E;
            user.Nobr = baseObj.NOBR;
            user.Password = baseObj.PASSWORD;
            user.Sex = baseObj.SEX;
            user.Ttscode = baseObj.BASETTS[0].TTSCODE;
            user.Comp = baseObj.BASETTS[0].COMP;

            user.ManageEmpList = new List<string>();
            user.ManageFullEmpList = new List<string>();
            user.ManageDeptRootNodeList = new List<RadTreeNode>();


            //確認使用者角色，如果是一般員工就新增一般角色，如果是主管，就新增主管到資料庫
            sysUserRole_Repo sysUserRoleRepo = new sysUserRole_Repo();
            sysUserRoleRepo.CheckUserRole(baseObj.NOBR);
            user.RoleList = sysUserRoleRepo.GetUserRoles(baseObj.NOBR);

            List<int> IntRoleList = new List<int>();
            foreach (var r in user.RoleList)
            {
                IntRoleList.Add(Convert.ToInt32(r));
            }
            user.IntRoleList = IntRoleList;

            user.RoleValue = sysUserRoleRepo.TransIntRole(user.RoleList);

            //如果是教育訓練管理者的話，就新增管理部門
            if (user.IsInRole("1"))
            {
                user.IsAdmin = true;
            }
            else
                user.IsAdmin = false;

            //有講師身分
            if (user.IsInRole("64"))
            {
                trTeacher_Repo teacherRepo = new trTeacher_Repo();
                trTeacher teacherObj = teacherRepo.GetByNobr(Anobr);
                if (teacherObj != null)
                {
                    user.TeacherCode = teacherObj.sCode;
                }
                else
                    user.TeacherCode = "";
            }

            //有主管身分
            if (user.IsInRole("32"))
            {
                DEPT_Repo deptRepo = new DEPT_Repo();

                List<DEPT> deptList = deptRepo.GetByNobr(user.Nobr);
                List<DEPT> manageDeptList = new List<DEPT>();

                foreach (var d in deptList)
                {
                    manageDeptList.AddRange(deptRepo.GetAllChildNode(d));
                }

                List<DeptDto> deptDtoList = (from c in manageDeptList
                                             select new
                                                 DeptDto
                                                 {
                                                     DeptCode = c.D_NO,
                                                     DeptName = c.D_NAME,
                                                     ParentDeptCode = c.DEPT_GROUP
                                                 }).ToList();

                var deptDtoListTemp = (from c in deptDtoList where deptList.Any(p => p.D_NO == c.DeptCode) select c).ToList();

                foreach (var d in deptDtoListTemp)
                {
                    d.ParentDeptCode = "";
                }


                user.ManageFullEmpList = new List<string>();

                SiteHelper sh = new SiteHelper();
                user.ManageDeptRootNodeList = sh.BuildManagerTv(deptDtoList);
            }

            return user;
        }
        else //抓取外部講師
        {
            trTeacher_Repo teacherRepo = new trTeacher_Repo();
            trTeacher teacherObj = teacherRepo.GetByOuterTeacherId(Anobr);
            if (teacherObj != null)
            {
                JUser user = new JUser();
                user.Email = teacherObj.sEmail;
                user.NameC = teacherObj.sName;
                user.Nobr = teacherObj.sNobr;
                user.Password = teacherObj.sTeacherPWD;
                user.Sex = teacherObj.sSex;
                user.IsOuterTeacher = true;
                //確認使用者角色，如果是一般員工就新增一般角色，如果是主管，就新增主管到資料庫
                user.RoleList = new ArrayList { "64" };

                List<int> IntRoleList = new List<int>();
                foreach (var r in user.RoleList)
                {
                    IntRoleList.Add(Convert.ToInt32(r));
                }
                user.IntRoleList = IntRoleList;

                sysUserRole_Repo sysUserRoleRepo = new sysUserRole_Repo();
                user.RoleValue = sysUserRoleRepo.TransIntRole(user.RoleList);
                user.TeacherCode = teacherObj.sCode;

                return user;
            }
            else
            {
                throw new ApplicationException("查無此員工、或講師");
            }
        }
    }

    public JUser() { }

    public String Nobr { get; set; }
    public string NameC { get; set; }
    public string NameE { get; set; }
    public string Sex { get; set; }
    public DateTime BirthDt { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Ttscode { get; set; }
    public DateTime Indt { get; set; }
    //public string LoginComp { get; set; } //使用者當時登入的公司
    public string Comp { get; set; }
    //public string CompName { get; set; }
    public string Dept { get; set; }
    public string DeptM { get; set; }
    public string Depts { get; set; }
    public string DeptName { get; set; }
    public string Job { get; set; }
    public string JobName { get; set; }
    public string JobL { get; set; }
    public string Di { get; set; }
    public bool Mang { get; set; }
    public bool Mang1 { get; set; }
    public string TeacherCode { get; set; }

    // 角色的Array
    public ArrayList RoleList { get; set; }
    public List<int> IntRoleList { get; set; }

    // 角色加總的int值
    public int RoleValue { get; set; }

    // 是否為外部講師
    public bool IsOuterTeacher { get; set; }

    public bool IsAdmin { get; set; }
    public List<string> ManageSalaDrList { get; set; }
    public List<string> ManageEmpList { get; set; }
    public List<string> ManageFullEmpList { get; set; }
    public List<RadTreeNode> ManageDeptRootNodeList { get; set; }
    public List<DeptDto> ManageDeptList { get; set; }

    public bool IsInRole(string Arole)
    {
        return RoleList.Contains(Arole);
    }
}