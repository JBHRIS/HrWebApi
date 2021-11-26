using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using BL;
using System.Collections;
using System.Web.UI.WebControls;
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
        if (user == null)
            throw new ApplicationException("can't find user:" + Anobr);

        //HttpContext.Current.Cache.Insert(CacheKey + Anobr , user , null , DateTime.Now.AddMinutes(10) , System.Web.Caching.Cache.NoSlidingExpiration);
        HttpContext.Current.Cache.Insert(CacheKey + Anobr , user , null , System.Web.Caching.Cache.NoAbsoluteExpiration , TimeSpan.FromMinutes(120) ,System.Web.Caching.CacheItemPriority.High , null);
    }

    public static void ClearCacheUser(string Anobr)
    {
        HttpContext.Current.Cache.Remove(CacheKey + Anobr);
    }


    /// <summary>
    /// 從Cache中取得使用者資訊
    /// </summary>
    /// <param name="Anobr"></param>
    /// <returns></returns>
    public static JUser GetCacheUser(string Anobr)
    {
        string key = CacheKey + Anobr;
        if (HttpContext.Current.Cache[key] != null)
        {
            JUser user = HttpContext.Current.Cache[key] as JUser;
            if (user != null)
                return user;
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
        BASE_REPO baseRepo = new BASE_REPO();
        BASE baseObj = baseRepo.GetEmpByNobrNow_DLO(Anobr);
        SiteHelper sh = new SiteHelper();

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
            user.HoliCode = baseObj.BASETTS[0].HOLI_CODE;
            user.RoleList = new List<string>();

            sysUserRole_Repo urRepo = new sysUserRole_Repo();
            List<sysUserRole> urList = urRepo.GetByNobr(user.Nobr);
            foreach (var ur in urList)
            {
                user.RoleList.Add(ur.RoleCode);
            }


            //user.RoleList = roles;

            //如果是HR管理者的話，就新增管理部門
            user.ManageDeptRootNodeList = new List<TreeNode>();
            user.ManageDeptRootMenuItemList = new List<RadMenuItem>();
            user.ManageDeptRootRadNodeList = new List<RadTreeNode>();
            user.ManageComp = "";
            user.ManagerExeptEmpList = new List<string>();            
            user.CoordinatorDeptList = new List<SDeptDto>();
            user.CoordinatorDeptRootNodeList = new List<TreeNode>();
            user.CoordinatorDeptRootMenuItemList = new List<RadMenuItem>();
            user.CoordinatorDeptRootRadNodeList = new List<RadTreeNode>();


            if (user.IsInRole("HR"))
            {
                List<COMP> compList = baseRepo.GetHrManageCompByNobr(user.Nobr);
                if (compList.Count > 0)
                    user.ManageComp = compList[0].COMP1;
            }

            //主管、組長腳色
            if (user.RoleList.Contains("Manager") || user.RoleList.Contains("TeamLeader"))
            {
                //只針對副主管去增加
                DeptSupervisor_REPO dsvRepo = new DeptSupervisor_REPO();
                DEPT_REPO deptRepo = new DEPT_REPO();
                List<DeptSupervisor> dsvList= dsvRepo.GetBySupervisorNobrFromCache_Dlo(user.Nobr);

                foreach (var s in dsvList)
                {
                    DEPT deptObj= deptRepo.GetByID(s.D_No);
                    if (deptObj.NOBR != null)
                        user.ManagerExeptEmpList.Add(deptObj.NOBR);
                }

                TreeView tv = new TreeView();
                SiteHelper.SetDeptTreeByDeptDeptSupervisor(tv, user.Nobr);

                user.ManageNodeList = new List<TreeNode>();
                user.ManageNodeList.AddRange(SiteHelper.GetTreeViewAllNodes(tv));

                foreach (TreeNode n in tv.Nodes) 
                { 
                    user.ManageDeptRootNodeList.Add(n);
                }

                
                RadTreeView rtv = new RadTreeView();
                sh.ConvertTv2RadTv(tv, rtv);

                foreach(RadTreeNode rn in rtv.Nodes)
                {
                    user.ManageDeptRootRadNodeList.Add(rn);
                }

                //新增主管助理權限的部分

                List<RadTreeNode> radNodeList= rtv.GetAllNodes().ToList() ;

                var dDtoList = (from c in radNodeList
                                select new SDeptDto
                                {
                                    DeptId = c.Value,
                                    DeptName = c.Text,
                                    ParentDeptId = c.ParentNode == null ? "" : c.ParentNode.Value
                                }
                                    ).ToList();
                user.CoordinatorDeptList.AddRange(dDtoList);

            }

            if (user.RoleList.Contains("Coordinator"))
            {
                U_DATAID_REPO uddRepo = new U_DATAID_REPO();
                List<U_DATAID> uddList= uddRepo.GetByUserIdSystem_Dlo(user.Nobr, "PORTAL");
                var dDtoList = (from c in uddList
                                select new SDeptDto
                                {
                                    DeptId = c.DEPT ,
                                    DeptName = c.DEPT1.D_NAME ,
                                    ParentDeptId = c.DEPT1.DEPT_GROUP
                                }).ToList();

                user.CoordinatorDeptList.AddRange(dDtoList);
                TreeView tv = new TreeView();
                sh.ConvertDeptDtoList2TreeView(tv,user.CoordinatorDeptList);

                foreach (TreeNode n in tv.Nodes)
                    user.CoordinatorDeptRootNodeList.Add(n);

                RadTreeView rtv = new RadTreeView();
                sh.ConvertTv2RadTv(tv, rtv);

                foreach(RadTreeNode rn in rtv.Nodes)
                    user.CoordinatorDeptRootRadNodeList.Add(rn);
            }

            return user;
        }
        else
        {
            throw new ApplicationException("查無此人，資料有誤!!");
        }
    }

    public JUser()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

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
    private string _ManageComp;
    public string ManageComp
    {
        get
        {
            return _ManageComp;
        }
        set
        {
            _ManageComp = value;

            //更換管理的資料群組
            ManageSalaDrList = new List<string>();
            
            COMP_DATAGROUP_REPO compDpRepo = new COMP_DATAGROUP_REPO();
            List<string> compSalaDrStrList = compDpRepo.GetByComp(value).Select(p => p.DATAGROUP).ToList();

            U_USER_REPO uUserRepo = new U_USER_REPO();
            U_USER uUserObj = uUserRepo.GetByNobr(this.Nobr);

            if (uUserObj == null || uUserObj.NOBR == null)
                ManageSalaDrList = compSalaDrStrList;
            else
            {
                //如果是管理者
                if ( uUserObj.ADMIN )
                {
                    ManageSalaDrList = compSalaDrStrList;
                }
                else
                {
                    U_DATAGROUP_REPO uDpRepo = new U_DATAGROUP_REPO();
                    List<string> userSalaDrStrList = uDpRepo.GetByUserId_Dlo(uUserObj.USER_ID).Select(p => p.DATAGROUP).ToList();

                    ManageSalaDrList = (from c in compSalaDrStrList
                                        where userSalaDrStrList.Contains(c)
                                        select c).ToList();
                }
            }

            //更換HR可看到的員工工號
            BASE_REPO baseRepo = new BASE_REPO();
            SalaDrNobrList = baseRepo.GetBySalaDr_Dlo(ManageSalaDrList).Select(p => p.NOBR).ToList();
        }
    }
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
    //行事曆代碼
    public string HoliCode { get; set; }
    /// <summary>
    /// 角色的Array
    /// </summary>
    public List<string> RoleList { get; set; }
    
    public List<string> ManageSalaDrList{get;set;}
    public List<string> ManagerExeptEmpList { get; set; }
    public List<TreeNode> ManageDeptRootNodeList { get; set; }
    public List<TreeNode> ManageNodeList { get; set; }
    public List<RadTreeNode> ManageDeptRootRadNodeList
    {
        get;
        set;
    }
    public List<RadMenuItem> ManageDeptRootMenuItemList
    {
        get;
        set;
    }

    //助理管理的部門
    public List<SDeptDto> CoordinatorDeptList { get; set; }
    public List<RadTreeNode> CoordinatorDeptRootRadNodeList { get; set; }
    public List<TreeNode> CoordinatorDeptRootNodeList
    {
        get;
        set;
    }
    public List<RadMenuItem> CoordinatorDeptRootMenuItemList
    {
        get;
        set;
    }



    public List<string> SalaDrNobrList { get; set; }

    public bool IsInRole(string Arole)
    {
        return RoleList.Contains(Arole);
    }
}