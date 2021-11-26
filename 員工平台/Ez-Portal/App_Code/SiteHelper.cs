using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using JBHRModel;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Collections;
using JB.WebModules.Authentication;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.IO;
using Telerik.Web.UI;
using System.Web.Services.Description;
using System.Net;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Text;
/// <summary>
/// SiteHelper 的摘要描述
/// </summary>
public class SiteHelper
{
    public SiteHelper()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    /// <summary>
    /// 設定 部門Tree，以nobr抓取Basetts中主管職，及depta中主管職
    /// </summary>
    /// <param name="tv"></param>
    /// <param name="nobr"></param>
    /// <param name="deptaCode"></param>
    public static void SetDeptTreeByDepta(TreeView tv, string nobr, string deptaCode)
    {
        BASETTS_REPO basetts_repo = new BASETTS_REPO();
        DEPTA_REPO depta_repo = new DEPTA_REPO();
        BASETTS basetts = basetts_repo.GetLatestRecordByNobr(nobr);

        if (basetts == null)
            return;

        TreeNode treenode = new TreeNode();

        DEPTA depta = null;
        //Sara要能看全公司的部門
        if (nobr.Equals("C11023"))
        {
            var deptaList = depta_repo.GetRoot();
            if (deptaList.Count > 0)
                depta = deptaList[0];
        }
        else
            depta = depta_repo.GetByID(deptaCode);


        if (depta == null)
            return;

        //先抓自己部門及仔部門
        treenode.Text = depta.D_NAME;
        treenode.Value = depta.D_NO;

        tv.Nodes.Add(depta_repo.GetDeptaTreeNode(treenode));

        //抓depta有設定此工號的部門
        List<DEPTA> depta_list = depta_repo.GetByNobr(nobr);

        foreach (var d in depta_list)
        {
            TreeNode node = new TreeNode();
            node.Text = d.D_NAME;
            node.Value = d.D_NO;
            tv.Nodes.Add(depta_repo.GetDeptaTreeNode(node));
        }
    }


    /// <summary>
    /// 設定 部門Tree，以nobr抓取Basetts中主管職，及dept中主管職
    /// </summary>
    /// <param name="tv"></param>
    /// <param name="nobr"></param>
    /// <param name="deptaCode"></param>
    public static void SetDeptTreeByDept(TreeView tv, string nobr, string deptCode)
    {
        BASETTS_REPO basetts_repo = new BASETTS_REPO();
        DEPT_REPO deptRepo = new DEPT_REPO();
        BASETTS basetts = basetts_repo.GetLatestRecordByNobr(nobr);
        List<string> addedDeptList = new List<string>();

        if (basetts == null)
            return;

        TreeNode treenode = new TreeNode();

        DEPT dept = deptRepo.GetByID(deptCode);

        if (dept == null)
            return;

        //先抓自己部門及仔部門
        treenode.Text = dept.D_NAME;
        treenode.Value = dept.D_NO;

        tv.Nodes.Add(deptRepo.GetDeptTreeNode(treenode, addedDeptList));
        //tv.Nodes.Add(dept_repo.GetDeptTreeNode(treenode));

        //抓depta有設定此工號的部門
        List<DEPT> dept_list = deptRepo.GetByNobr(nobr);

        foreach (var d in dept_list)
        {
            TreeNode node = new TreeNode();
            node.Text = d.D_NAME;
            node.Value = d.D_NO;
            if (!addedDeptList.Contains(d.D_NO))
                tv.Nodes.Add(deptRepo.GetDeptTreeNode(node, addedDeptList));
            //tv.Nodes.Add(dept_repo.GetDeptTreeNode(node));
        }
    }


    /// <summary>
    /// 設定 部門Tree，以nobr抓取Basetts中主管職，及dept中主管職，但是不包含員工目前自己所屬部門
    /// </summary>
    /// <param name="tv"></param>
    /// <param name="nobr"></param>
    /// <param name="deptaCode"></param>
    public static void SetDeptTreeByDept(TreeView tv, string nobr)
    {
        BASETTS_REPO basetts_repo = new BASETTS_REPO();
        DEPT_REPO dept_repo = new DEPT_REPO();
        BASETTS basetts = basetts_repo.GetLatestRecordByNobr(nobr);
        List<string> addedDeptList = new List<string>();

        if (basetts == null)
            return;

        TreeNode treenode = new TreeNode();

        //抓dept有設定此工號的部門
        List<DEPT> dept_list = dept_repo.GetByNobr(nobr);

        foreach (var d in dept_list)
        {
            TreeNode node = new TreeNode();
            node.Text = d.D_NAME;
            node.Value = d.D_NO;
            if (!addedDeptList.Contains(d.D_NO))
                tv.Nodes.Add(dept_repo.GetDeptTreeNode(node, addedDeptList));
            //tv.Nodes.Add(dept_repo.GetDeptTreeNode(node));
        }
    }


    /// <summary>
    /// 設定 部門Tree，以nobr抓取Basetts中主管職
    /// </summary>
    /// <param name="tv"></param>
    /// <param name="nobr"></param>    
    public static void SetDeptTreeByDeptDeptSupervisor(TreeView tv, string nobr)
    {
        tv.Nodes.Clear();
        BASETTS_REPO basetts_repo = new BASETTS_REPO();
        DEPT_REPO dept_repo = new DEPT_REPO();
        //BASETTS basetts = basetts_repo.GetLatestRecordByNobr(nobr);

        //if (basetts == null)
        //    return;

        TreeNode treenode = new TreeNode();

        //DEPT dept = null;
        //dept = dept_repo.GetByID(basetts.DEPT);
        //if (dept == null)
        //    return;

        //先抓自己部門及仔部門
        DeptSupervisor_REPO deptSupervisorRepo = new DeptSupervisor_REPO();
        List<string> denyDeptList = (from c in deptSupervisorRepo.GetBySupervisorNobrFromCache_Dlo(nobr, false)
                                     select c.D_No).ToList();

        //如果排除掉自己本身部門的話
        //if (!denyDeptList.Contains(dept.D_NO))
        //{
        //    treenode.Text = dept.D_NAME;
        //    treenode.Value = dept.D_NO;
        //    tv.Nodes.Add(dept_repo.GetDeptTreeNode(treenode, denyDeptList));
        //}

        //抓dept有設定此工號的部門
        List<DEPT> dept_list = dept_repo.GetByNobr(nobr).OrderBy(p => p.D_NO_DISP).ToList();

        foreach (var d in dept_list)
        {
            if (denyDeptList.Contains(d.D_NO))
                continue;

            TreeNode node = new TreeNode();
            node.Text = d.D_NAME;
            node.Value = d.D_NO;
            tv.Nodes.Add(dept_repo.GetDeptTreeNode(node, denyDeptList));
        }

        //抓取DeptSupervisor有設定部門主管的
        List<DeptSupervisor> managedDeptList = deptSupervisorRepo.GetBySupervisorNobrFromCache_Dlo(nobr, true);
        foreach (var d in managedDeptList)
        {
            TreeNode node = new TreeNode();
            node.Text = d.DEPT.D_NAME;
            node.Value = d.DEPT.D_NO;

            tv.Nodes.Add(dept_repo.GetDeptTreeNode(node, denyDeptList));
        }

        MergeDeptTv(tv);
    }

    public static void SetDeptTreeByDeptList(TreeView tv, List<DEPT> deptList)
    {
        
   

    }

    public void InitManagerDeptTreeView(TreeView tv, List<TreeNode> list)
    {
        tv.Nodes.Clear();
        foreach (TreeNode n in list)
        {
            tv.Nodes.Add(n);
        }
    }

    public void InitManagerDeptTreeView(RadTreeView tv , List<RadTreeNode> list)
    {
        tv.Nodes.Clear();
        foreach ( RadTreeNode n in list )
        {
            tv.Nodes.Add(n);
        }
    }

    public void InitManagerDeptMenu(RadMenu m, List<RadMenuItem> list)
    {
        m.Items.Clear();
        foreach (RadMenuItem i in list)
        {
            m.Items.Add(i);
        }
    }


    /// <summary>
    /// 設定 部門Tree，以nobr抓取Basetts中主管職
    /// </summary>
    /// <param name="tv"></param>
    /// <param name="nobr"></param>    
    public static void SetDeptaTreeByDeptaDeptaSupervisor(TreeView tv, string nobr)
    {
        tv.Nodes.Clear();

        BASETTS_REPO basetts_repo = new BASETTS_REPO();
        DEPTA_REPO depta_repo = new DEPTA_REPO();
        BASETTS basetts = basetts_repo.GetLatestRecordByNobr(nobr);

        if (basetts == null)
            return;

        TreeNode treenode = new TreeNode();

        //先抓自己部門及仔部門
        DeptaSupervisor_REPO deptaSupervisorRepo = new DeptaSupervisor_REPO();
        List<string> denyDeptaList = (from c in deptaSupervisorRepo.GetBySupervisorNobrFromCache_Dlo(nobr, false)
                                      select c.D_No).ToList();

        //抓dept有設定此工號的部門
        List<DEPTA> depta_list = depta_repo.GetByNobr(nobr);

        foreach (var d in depta_list)
        {
            if (denyDeptaList.Contains(d.D_NO))
                continue;

            TreeNode node = new TreeNode();
            node.Text = d.D_NAME;
            node.Value = d.D_NO;
            tv.Nodes.Add(depta_repo.GetDeptaTreeNode(node, denyDeptaList));
        }

        //抓取DeptSupervisor有設定部門主管的
        List<DeptaSupervisor> managedDeptaList = deptaSupervisorRepo.GetBySupervisorNobrFromCache_Dlo(nobr, true);
        foreach (var d in managedDeptaList)
        {
            TreeNode node = new TreeNode();
            node.Text = d.DEPTA.D_NAME;
            node.Value = d.DEPTA.D_NO;
            tv.Nodes.Add(depta_repo.GetDeptaTreeNode(node, denyDeptaList));
        }
    }

    public static void MergeDeptTv(TreeView tv)
    {
        List<DEPT> deptList = DEPT_REPO.GetInstance();

        SiteHelper sHelper = new SiteHelper();

        for (int i = 0; i < tv.Nodes.Count; i++)
        {
            DEPT dObj = (from c in deptList where c.D_NO == tv.Nodes[i].Value select c).FirstOrDefault();
            if (dObj != null)
            {
                TreeNode node = sHelper.FindNodeByValue(tv, dObj.DEPT_GROUP);
                if (node != null)
                {
                    node.ChildNodes.Add(tv.Nodes[i]);
                    i--;
                }
            }
        }
    }


    public TreeNode FindNodeByValue(TreeView tv, string value)
    {
        foreach (TreeNode n in tv.Nodes)
        {
            TreeNode resultN = FindNodebyValue(n, value);
            if (resultN != null)
                return resultN;
        }

        return null;
    }

    public TreeNode FindNodebyValue(TreeNode n, string value)
    {
        if (n.Value == value)
            return n;

        foreach (TreeNode item in n.ChildNodes)
        {
            TreeNode i = FindNodebyValue(item, value);
            if (i != null)
                return i;
        }

        return null;
    }


    /// <summary>
    /// 設定全部部門的DeptTree
    /// </summary>
    /// <param name="tv"></param>
    public static void SetAllDeptTree(TreeView tv)
    {
        DEPT_REPO dept_repo = new DEPT_REPO();

        var deptList = dept_repo.GetRoot();

        //先抓自己部門及仔部門
        foreach (var d in deptList)
        {
            TreeNode treenode = new TreeNode();
            treenode.Text = d.D_NAME;
            treenode.Value = d.D_NO;

            tv.Nodes.Add(dept_repo.GetDeptTreeNode(treenode));
        }
    }


    public static void SetAllDeptTree(RadTreeView tv)
    {
        DEPT_REPO dept_repo = new DEPT_REPO();

        var deptList = dept_repo.GetRoot();

        //先抓自己部門及仔部門
        foreach (var d in deptList)
        {
            RadTreeNode treenode = new RadTreeNode();
            treenode.Text = d.D_NAME;
            treenode.Value = d.D_NO;

            tv.Nodes.Add(dept_repo.GetDeptTreeNode(treenode));
        }
    }


    public static void SetAllDeptMenu(RadMenu menu)
    {
        DEPT_REPO dept_repo = new DEPT_REPO();

        var deptList = dept_repo.GetRoot();

        //先抓自己部門及仔部門
        foreach (var d in deptList)
        {
            RadMenuItem item = new RadMenuItem();
            item.Text = d.D_NAME;
            item.Value=d.D_NO;

            menu.Items.Add(dept_repo.GetDeptItem(item));
        }
    }


    /// <summary>
    /// 設定全部部門的DeptTree By Company
    /// </summary>
    /// <param name="tv"></param>
    public static void SetAllDeptTree(TreeView tv, string compCode)
    {
        DEPT_REPO dept_repo = new DEPT_REPO();

        var deptList = dept_repo.GetRoot();

        List<string> compDeptCodeList = dept_repo.GetDeptListByCompany(compCode).Select(p => p.D_NO).ToList();

        //先抓自己部門及仔部門
        foreach (var d in deptList)
        {
            if (compDeptCodeList.Contains(d.D_NO))
            {
                TreeNode treenode = new TreeNode();
                treenode.Text = d.D_NAME;
                treenode.Value = d.D_NO;

                tv.Nodes.Add(dept_repo.GetDeptTreeNode(treenode));
            }
        }
    }


    /// <summary>
    /// 設定全部部門的DeptTree
    /// </summary>
    /// <param name="tv"></param>
    public static void SetAllDeptaTree(TreeView tv)
    {
        DEPTA_REPO depta_repo = new DEPTA_REPO();

        var deptaList = depta_repo.GetRoot();

        //先抓自己部門及仔部門
        foreach (var d in deptaList)
        {
            TreeNode treenode = new TreeNode();
            treenode.Text = d.D_NAME;
            treenode.Value = d.D_NO;

            tv.Nodes.Add(depta_repo.GetDeptaTreeNode(treenode));
        }
    }

    /// <summary>
    /// 往這個部門節點抓以下的所有部門節點
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static TreeNode GetDeptTreeNode(TreeNode node)
    {
        DEPT_REPO deptRepo = new DEPT_REPO();
        List<DEPT> depts = deptRepo.GetChildByID(node.Value);

        foreach (DEPT d in depts)
        {
            TreeNode newNode = new TreeNode();
            newNode.Text = d.D_NAME;
            newNode.Value = d.D_NO;
            node.ChildNodes.Add(newNode);
            GetDeptTreeNode(newNode);
        }

        return node;
    }

    /// <summary>
    /// 抓取Treeview所有的節點為list
    /// </summary>
    /// <param name="tv"></param>
    /// <returns></returns>
    public static List<TreeNode> GetTreeViewAllNodes(TreeView tv)
    {
        List<TreeNode> nodeList = new List<TreeNode>();
        foreach (TreeNode node in tv.Nodes)
        {
            GetChildNodes(node, nodeList);
        }

        return nodeList;
    }

    /// <summary>
    /// 抓取此節點之下的所有子節點
    /// </summary>
    /// <param name="node"></param>
    /// <param name="nodeList"></param>
    public static void GetChildNodes(TreeNode node, List<TreeNode> nodeList)
    {
        nodeList.Add(node);
        foreach (TreeNode n in node.ChildNodes)
        {
            GetChildNodes(n, nodeList);
        }
    }

    public static List<TreeNode> GetChildNodes(TreeNode node)
    {
        List<TreeNode> nodeList = new List<TreeNode>();
        nodeList.Add(node);
        foreach (TreeNode n in node.ChildNodes)
            GetChildNodes(n, nodeList);

        return nodeList;
    }


    public static void GetChildNodes(RadMenuItem node, List<string> deptCodeList)
    {
        deptCodeList.Add(node.Value);
        foreach (RadMenuItem n in node.Items)
        {
            GetChildNodes(n, deptCodeList);
        }
    }


    /// <summary>
    /// 抓取部門根節點
    /// </summary>
    /// <returns></returns>
    public static string GetDeptRoot()
    {
        DEPT_REPO deptRepo = new DEPT_REPO();
        var deptDT = deptRepo.GetRoot();
        if (deptDT.Count > 0)
            return deptDT[0].D_NO;
        else
            throw new ApplicationException("無法取得部門Root資料");
    }




    public static string ConvertStrTimeTo24(string mmss)
    {
        string result = mmss;
        if (mmss.Trim().Length != 4)
        {
            return result;
        }

        try
        {
            int mm = int.Parse(mmss.Substring(0, 2));

            if (mm >= 24)
                mm = mm - 24;

            return mm.ToString().PadLeft(2, '0') + mmss.Substring(2, 2);
        }
        catch
        {
            return result;
        }
    }


    public static int ConvertStrTimeToMins(string mmss)
    {
        int result = 0;
        if (mmss.Trim().Length != 4)
        {
            return result;
        }

        try
        {
            int mm = int.Parse(mmss.Substring(0, 2));
            int ss = int.Parse(mmss.Substring(2, 2));
            result = mm * 60 + ss;
            return result;
        }
        catch
        {
            return result;
        }
    }


    public static String ConvertDayOfWeek2Chinese(DayOfWeek Avalue)
    {
        if (Avalue.Equals(DayOfWeek.Monday))
            return "一";
        else if (Avalue.Equals(DayOfWeek.Tuesday))
            return "二";
        else if (Avalue.Equals(DayOfWeek.Wednesday))
            return "三";
        else if (Avalue.Equals(DayOfWeek.Thursday))
            return "四";
        else if (Avalue.Equals(DayOfWeek.Friday))
            return "五";
        else if (Avalue.Equals(DayOfWeek.Saturday))
            return "六";
        else
            return "日";
    }


    public bool IsRoleHR(string Avalue)
    {
        //HttpApplication app = HttpContext.Current.ApplicationInstance;
        //String confPath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/roles.config");
        //XDocument xml = XDocument.Load(confPath);
        //var roles = xml.Element("roles");

        //var a = (from c in roles.Elements()
        //         where c.Value == Avalue
        //             && c.Attribute("role").Value == "HR"
        //             && c.Attribute("type").Value == "工號"
        //         select c).FirstOrDefault();

        try
        {
            JBPrincipal newUser = new JBPrincipal(Avalue);
            return newUser.Roles.Contains("HR");
        }
        catch
        {
            return false;

        }
    }

    /// <summary>
    /// 設定工廠計薪日期 26-25
    /// </summary>
    /// <param name="startDatetime"></param>
    /// <param name="endDatetime"></param>
    //public void SetDateRange2625(out DateTime startDatetime , out DateTime endDatetime)
    //{
    //    //以27號看，如果日期小於27號，就從上個月的26到日期減一            
    //    DateTime tmpDatetime = new DateTime(DateTime.Now.Year , DateTime.Now.Month , 26 + 1);
    //    if ( DateTime.Now.Date.CompareTo(tmpDatetime) < 0 )
    //    {
    //        tmpDatetime = tmpDatetime.AddMonths(-1);
    //        startDatetime = new DateTime(tmpDatetime.Year , tmpDatetime.Month , 26);
    //        endDatetime = DateTime.Now.Date.AddDays(-1);
    //    }
    //    else
    //    {
    //        startDatetime = new DateTime(DateTime.Now.Year , DateTime.Now.Month , 26);
    //        endDatetime = DateTime.Now.Date.AddDays(-1);
    //    }
    //}

    public void SetDateRange(out DateTime startDatetime, out DateTime endDatetime, DateTime selectedDatetime, int endDay)
    {
        DateTime tmpDatetime = new DateTime(selectedDatetime.Year, selectedDatetime.Month, DateTime.DaysInMonth(selectedDatetime.Year, selectedDatetime.Month));

        if (tmpDatetime.Day <= endDay)
        {
            endDay = tmpDatetime.Day;
        }

        if (selectedDatetime.Day <= endDay)
        {
            endDatetime = selectedDatetime.AddDays(-1);
            startDatetime = new DateTime(selectedDatetime.Year, selectedDatetime.Month, endDay).AddMonths(-1).AddDays(1);
        }
        else
        {
            endDatetime = selectedDatetime.AddDays(-1);
            startDatetime = new DateTime(selectedDatetime.Year, selectedDatetime.Month, endDay + 1);
        }

    }


    public void SetDateRange(out DateTime startDatetime, out DateTime endDatetime, DateTime selectedDatetime, string saladrCode)
    {
        U_SYS2_REPO usys2Repo = new U_SYS2_REPO();
        U_SYS2 usys2Obj = usys2Repo.GetAttendDateRangeBySalaDr(saladrCode);

        if (usys2Obj.ATTMONTH.HasValue)
            SetDateRange(out startDatetime, out endDatetime, selectedDatetime, usys2Obj.ATTMONTH.Value);
        else
            SetDateRange(out startDatetime, out endDatetime, selectedDatetime, 25);
    }

    /// <summary>
    /// 設定日期區間為年頭到年尾的
    /// </summary>
    /// <param name="startDatetime"></param>
    /// <param name="endDatetime"></param>
    /// <param name="selectedDatetime"></param>
    public void SetDateRangeForThisYear(out DateTime startDatetime, out DateTime endDatetime)
    {
        startDatetime = new DateTime(DateTime.Now.Year, 1, 1);
        endDatetime = new DateTime(DateTime.Now.Year, 12, 31);
    }

    /// <summary>
    /// 設定日期區間為月頭到月尾的
    /// </summary>
    /// <param name="startDatetime"></param>
    /// <param name="endDatetime"></param>
    /// <param name="selectedDatetime"></param>
    public void SetDateRangeForThisMonth(out DateTime startDatetime, out DateTime endDatetime)
    {
        startDatetime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        endDatetime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
    }

    //從今天起算一年內
    public void SetDateRangeForLatestYear(out DateTime startDatetime, out DateTime endDatetime)
    {
        endDatetime = DateTime.Now.Date;
        startDatetime = endDatetime.AddYears(-1);
    }

    public void SetDateRangeForLatestYear<T>(T objB, T objE)
    {
        DateTime dateE = DateTime.Now.Date;
        DateTime dateB = dateE.AddYears(-1);

        var p1 =objB.GetType().GetProperty("SelectedDate");
        if(p1!=null)
            p1.SetValue(objB,dateB,null);
 
        var p2 =objE.GetType().GetProperty("SelectedDate");
        if (p2 != null)
            p2.SetValue(objE,dateE,null);
    }

    public List<PortalRole> GetRoleList()
    {
        List<PortalRole> list = new List<PortalRole>();
        list.Add(new PortalRole { Role = "manage", Desc = "主管" });
        list.Add(new PortalRole { Role = "HR", Desc = "HR" });
        DATAGROUP_REPO dpRepo = new DATAGROUP_REPO();
        List<DATAGROUP> dpList = dpRepo.GetAll();
        foreach (var d in dpList)
        {
            list.Add(new PortalRole { Role = d.DATAGROUP1, Desc = d.GROUPNAME });
        }

        list.AddRange(GetAllRolesFromConfig());

        var q = (from c in list
                 group c by c.Role into g
                 select g).ToList();

        List<PortalRole> resultList = new List<PortalRole>();

        foreach (var p in q)
        {
            foreach (var p1 in p)
            {
                PortalRole obj = new PortalRole { Role = p1.Role, Desc = p1.Desc };
                resultList.Add(obj);
                break;
            }
        }

        return resultList;
    }

    public List<PortalRole> GetAllRolesFromConfig()
    {
        HttpApplication app = HttpContext.Current.ApplicationInstance;
        String confPath = app.Server.MapPath(@"~/roles.config");

        XDocument xml = XDocument.Load(confPath);
        var roles = xml.Element("roles");

        List<PortalRole> list = new List<PortalRole>();
        var roleList = (from c in roles.Elements() select c.Attribute("role").Value).Distinct();

        foreach (var r in roleList)
        {
            list.Add(new PortalRole { Role = r, Desc = "" });
        }
        return list;
    }


    public DataTable GetSelectedEmpData(DataTable dt, string colName, List<string> strList)
    {
        var list = (from c in dt.AsEnumerable()
                    where strList.Contains(c.Field<string>(colName))
                    select c).ToList();

        DataTable resultDt = dt.Clone();
        foreach (var i in list)
        {
            resultDt.ImportRow(i);
        }

        return resultDt;
    }

    public DataTable RemoveSelectedEmpData(DataTable dt, string colName, List<string> strList)
    {
        var list = (from c in dt.AsEnumerable()
                    where !strList.Contains(c.Field<string>(colName))
                    select c).ToList();

        DataTable resultDt = dt.Clone();
        foreach (var i in list)
        {
            resultDt.ImportRow(i);
        }

        return resultDt;
    }


    public string GetEmpPhotoPath(string nobr)
    {
        string photoDirPath = @"~/photos/";
        //string photoDirPath = @"~/File/";
        string serverPhotoDirPath = System.Web.Hosting.HostingEnvironment.MapPath(photoDirPath);

        Regex searchPattern = new Regex("^" + nobr + ".", RegexOptions.IgnoreCase);

        var di = new DirectoryInfo(serverPhotoDirPath);
        var fileList = (from c in di.GetFiles()
                        where searchPattern.IsMatch(c.Name)
                        select c).ToList();

        if (fileList.Count() > 0)
        {
            return photoDirPath + fileList[0].Name;
        }

        else return "~/Images/stick_on_picture.gif";
    }


    public byte[] StreamToBytes(Stream stream)
    {
        byte[] bytes = new byte[stream.Length];
        stream.Read(bytes, 0, bytes.Length);
        stream.Seek(0, SeekOrigin.Begin);
        return bytes;
    }

    /// 
    /// byte[] to  Stream 
    /// 
    public Stream BytesToStream(byte[] bytes)
    {
        Stream stream = new MemoryStream(bytes);
        return stream;
    }



    //功能向下展開(起點) For Admin展樹狀
    public void BuildAdminMainTv(RadTreeView TvMain)
    {
        TvMain.Nodes.Clear();
        List<FileStructure> sysList = FileStructure_Repo.GetInstance();

        var ls = (from c in sysList
                  where c.sParentKey == "Root"
                  orderby c.iOrder
                  select c).ToList();

        foreach (var r in ls)
        {
            Telerik.Web.UI.RadTreeNode node = new RadTreeNode();
            node.Text = r.sFileTitle;
            node.Value = r.Code;
            //node.ForeColor = System.Drawing.Color.Black;

            if (r.sIconName != null && r.sIconName.Trim().Length > 0)
            {
                node.ImageUrl = "~" + r.sIconPath + r.sIconName;
            }

            BuildAdminMainTvNode(node);
            TvMain.Nodes.Add(node);
        }
    }


    //功能向下展開 For Admin展節點
    public void BuildAdminMainTvNode(Telerik.Web.UI.RadTreeNode nodeP)
    {
        List<FileStructure> sysList = FileStructure_Repo.GetInstance();
        var ls = (from c in sysList
                  where c.sParentKey == nodeP.Value
                  orderby c.iOrder
                  select c).ToList();

        foreach (var r in ls)
        {
            Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
            node.Text = r.sFileTitle;
            node.Value = r.Code;
            //node.ForeColor = System.Drawing.Color.Black;

            if (r.sIconName != null && r.sIconName.Trim().Length > 0)
            {
                node.ImageUrl = "~" + r.sIconPath + r.sIconName;
            }

            BuildAdminMainTvNode(node);
            nodeP.Nodes.Add(node);
        }
    }


    /// <summary>
    /// 展個人程式樹狀組織，功能向下展開(起點)
    /// </summary>
    /// <param name="Root"></param>
    /// <param name="TvMain"></param>
    /// <param name="juser"></param>
    public void SetMainTvRootValues(string Root, TreeView TvMain, JUser juser)
    {
        List<FileStructure> sysList = FileStructure_Repo.GetInstance();
        List<FileStructureRole> fsRoleAllList = FileStructureRole_Repo.GetInstance();

        var ls = (from c in sysList
                  where c.sParentKey == Root
                  orderby c.iOrder
                  select c).ToList();

        foreach (var r in ls)
        {
            List<FileStructureRole> fsRoleList = fsRoleAllList.Where(p => p.FileStructureKey.Equals(r.Code)).ToList();

            if (!fsRoleList.Any(p => juser.RoleList.Contains(p.RoleCode)))
            {
                continue;
            }

            TreeNode node = new TreeNode();
            node.Text = r.sFileTitle;
            node.Value = r.Code;



            if (r.sFileName != null && r.sFileName.Trim().Length > 0 && r.sPath != null && r.sPath.Trim().Length > 0)
            {
                node.NavigateUrl = "~" + r.sPath + r.sFileName;
            }

            if (r.sPath.Contains(@"http://") || r.sPath.Contains(@"https://"))
            {
                node.NavigateUrl = r.sPath;                
            }

            if (r.OpenNewWin)
            {
                node.Target = @"_blank";
            }

            //            node.ForeColor = System.Drawing.Color.Black;

            if (r.sIconName != null && r.sIconName.Trim().Length > 0)
            {
                node.ImageUrl = "~" + r.sIconPath + r.sIconName;
            }

            node.Target = "_self";

            SetMainTvNodeValues(node, juser);
            //node.ExpandChildNodes();    
            TvMain.Nodes.Add(node);

        }
    }


    /// <summary>
    /// 展個人程式樹狀組織子項目，功能向下展開(起點)
    /// </summary>
    /// <param name="nodeP"></param>
    /// <param name="juser"></param>
    public void SetMainTvNodeValues(TreeNode nodeP, JUser juser)
    {
        List<FileStructure> sysList = FileStructure_Repo.GetInstance();
        var ls = (from c in sysList
                  where c.sParentKey == nodeP.Value
                  orderby c.iOrder
                  select c).ToList();

        List<FileStructureRole> fsRoleAllList = FileStructureRole_Repo.GetInstance();

        foreach (var r in ls)
        {
            List<FileStructureRole> fsRoleList = fsRoleAllList.Where(p => p.FileStructureKey.Equals(r.Code)).ToList();

            if (!fsRoleList.Any(p => juser.RoleList.Contains(p.RoleCode)))
            {
                continue;
            }

            TreeNode node = new TreeNode();
            node.Text = r.sFileTitle;
            node.Value = r.Code;
            //node.ForeColor = System.Drawing.Color.Black;
            //node.ExpandMode = TreeNodeExpandMode.ServerSide;

            if (r.sFileName != null && r.sFileName.Trim().Length > 0 && r.sPath != null && r.sPath.Trim().Length > 0)
            {
                //增加此項目會影響到 node_click的postback，所以網址存在category中，click之後再導過去
                node.NavigateUrl = "~" + r.sPath + r.sFileName;
            }

            if (r.sIconName != null && r.sIconName.Trim().Length > 0)
            {
                node.ImageUrl = "~" + r.sIconPath + r.sIconName;
            }

            if (r.sPath.Contains(@"http://") || r.sPath.Contains(@"https://"))
            {
                node.NavigateUrl = r.sPath;
            }

            if (r.OpenNewWin)
            {
                node.Target = @"_blank";
            }

            SetMainTvNodeValues(node, juser);
            nodeP.ChildNodes.Add(node);
        }
    }

    //
    public void ConvertDeptDtoList2TreeView(TreeView tv , List<SDeptDto> DeptDtoList)
    {
        List<SDeptDto> rootList = (from c in DeptDtoList
                                   where !DeptDtoList.Select(p => p.DeptId).Contains(c.ParentDeptId)
                                   select c).ToList();


        foreach ( var r in rootList )
        {
            TreeNode rn = new TreeNode();
            rn.Text = r.DeptName;
            rn.Value = r.DeptId;
            tv.Nodes.Add(rn);
        }
    }

    public void GetChildsFromDeptDtoList(TreeNode pNode , List<SDeptDto> DeptDtoList)
    {
        var list= (from c in DeptDtoList where c.ParentDeptId==pNode.Value select c).ToList();
        foreach ( var rn in list )
        {
            TreeNode n = new TreeNode();
            n.Text = rn.DeptName;
            n.Value = rn.DeptId;
            GetChildsFromDeptDtoList(n , DeptDtoList);
            pNode.ChildNodes.Add(n);
        }
    }

    //把 tv 轉成RadMenu
    public RadMenu ConvertTv2RadMenu(TreeView tv, RadMenu menu)
    {
        foreach (TreeNode rn in tv.Nodes)
        {
            RadMenuItem item = new RadMenuItem();
            item.Value = rn.Value;
            item.Text = rn.Text;
            item.NavigateUrl = rn.NavigateUrl;
            item.Target = rn.Target;
            ConvertTreeNode2RadMenuItem(rn, item);
            menu.Items.Add(item);
        }

        return menu;
    }


    public RadTreeNode ConvertTreeNode2RadTreeNode(TreeNode node , RadTreeNode rnode)
    {
        foreach ( TreeNode n in node.ChildNodes )
        {
            RadTreeNode rn = new RadTreeNode();
            rn.Value = n.Value;
            rn.Text = n.Text;
            rn.NavigateUrl = n.NavigateUrl;
            ConvertTreeNode2RadTreeNode(n , rn);
            rnode.Nodes.Add(rn);
        }

        return rnode;
    }

    public void ConvertTv2RadTv(TreeView tv , RadTreeView rtv)
    {
        foreach ( TreeNode n in tv.Nodes)
        {
            RadTreeNode rnode = new RadTreeNode();
            rnode.Value = n.Value;
            rnode.Text = n.Text;
            rnode.NavigateUrl = n.NavigateUrl;
            ConvertTreeNode2RadTreeNode(n , rnode);
            rtv.Nodes.Add(rnode);
        }
    }

    public void ConvertTreeNode2RadMenuItem(TreeNode node, RadMenuItem item)
    {
        foreach (TreeNode n in node.ChildNodes)
        {
            RadMenuItem cItem = new RadMenuItem();
            cItem.Value = n.Value;
            cItem.Text = n.Text;
            cItem.NavigateUrl = n.NavigateUrl;
            cItem.Target = n.Target;
            ConvertTreeNode2RadMenuItem(n, cItem);
            item.Items.Add(cItem);
        }
    }


    public static void ConverToChinese(RadGrid grid)
    {
        GridFilterMenu menu = grid.FilterMenu;

        foreach (RadMenuItem item in menu.Items)
        {
            //change the text for the menu item with text StartsWith
            if (item.Text == "NoFilter")
            {
                item.Text = "清空查詢條件";
            }
            if (item.Text == "Contains")
            {
                item.Text = "包含";
            }
            if (item.Text == "DoesNotContain")
            {
                item.Text = "不包含";
            }
            if (item.Text == "StartsWith")
            {
                item.Text = "第一個字";
            }
            if (item.Text == "EndsWith")
            {
                item.Text = "最後一個字";
            }
            if (item.Text == "EqualTo")
            {
                item.Text = "等於";
            }
            if (item.Text == "NotEqualTo")
            {
                item.Text = "不等於";
            }
            if (item.Text == "GreaterThan")
            {
                item.Text = "大於";
            }
            if (item.Text == "LessThan")
            {
                item.Text = "小於";
            }
            if (item.Text == "GreaterThanOrEqualTo")
            {
                item.Text = "大於等於";
            }
            if (item.Text == "LessThanOrEqualTo")
            {
                item.Text = "小於等於";
            }
            if (item.Text == "Between")
            {
                item.Text = "在A與B之間";
            }
            if (item.Text == "NotBetween")
            {
                item.Text = "不在A與B之間";
            }
            if (item.Text == "IsEmpty")
            {
                item.Text = "空白";
            }
            if (item.Text == "NotIsEmpty")
            {
                item.Text = "非空白";
            }
            if (item.Text == "IsNull")
            {
                item.Text = "空值";
            }
            if (item.Text == "NotIsNull")
            {
                item.Text = "非空值";
            }

        }

    }

    public static string ToRgb(int argb)
    {
        var r = ((argb >> 16) & 0xff);
        var g = ((argb >> 8) & 0xff);
        var b = (argb & 0xff);

        return string.Format("{0:X2}{1:X2}{2:X2}", r, g, b);
    }

    /// <summary>
    /// 驗證是否為正確的身分證字號
    /// </summary>
    /// <param name="arg_Identify"></param>
    /// <returns></returns>
    public static bool IsIdentificationId(string arg_Identify)
    {
        var d = false;
        if (arg_Identify.Length == 10)
        {
            arg_Identify = arg_Identify.ToUpper();
            if (arg_Identify[0] >= 0x41 && arg_Identify[0] <= 0x5A)
            {
                var a = new[] { 10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33 };
                var b = new int[11];
                b[1] = a[(arg_Identify[0]) - 65] % 10;
                var c = b[0] = a[(arg_Identify[0]) - 65] / 10;
                for (var i = 1; i <= 9; i++)
                {
                    b[i + 1] = arg_Identify[i] - 48;
                    c += b[i] * (10 - i);
                }
                if (((c % 10) + b[10]) % 10 == 0)
                {
                    d = true;
                }
            }
        }
        return d;
    }


    /// <summary> 
    /// 動態呼叫Web Service
    /// </summary> 
    /// <param name="pUrl">WebService的http形式的位址，EX:http://www.yahoo.com/Service/Service.asmx </param> 
    /// <param name="pNamespace">欲呼叫的WebService的namespace</param> 
    /// <param name="pClassname">欲呼叫的WebService的class name</param> 
    /// <param name="pMethodname">欲呼叫的WebService的method name</param> 
    /// <param name="pArgs">參數列表，請將每個參數分別放入object[]中</param> 
    /// <returns>WebService的執行結果</returns> 
    /// <remarks> 
    /// 如果呼叫失敗，將會拋出Exception。請呼叫的時候，適當截獲異常。 
    /// 目前知道有兩個地方可能會發生異常： 
    /// 1、動態構造WebService的時候，CompileAssembly失敗。 
    /// 2、WebService本身執行失敗。 
    /// </remarks> 
    public object InvokeWebservice(string pUrl, string @pNamespace, string pClassname, string pMethodname, object[] pArgs)
    {
        WebClient tWebClient = new WebClient();
        //讀取WSDL檔，確認Web Service描述內容
        Stream tStream = tWebClient.OpenRead(pUrl + "?WSDL");
        ServiceDescription tServiceDesp = ServiceDescription.Read(tStream);
        //將讀取到的WSDL檔描述import近來
        ServiceDescriptionImporter tServiceDespImport = new ServiceDescriptionImporter();
        tServiceDespImport.AddServiceDescription(tServiceDesp, "", "");
        CodeNamespace tCodeNamespace = new CodeNamespace(@pNamespace);
        //指定要編譯程式
        CodeCompileUnit tCodeComUnit = new CodeCompileUnit();
        tCodeComUnit.Namespaces.Add(tCodeNamespace);
        tServiceDespImport.Import(tCodeNamespace, tCodeComUnit);

        //以C#的Compiler來進行編譯
        CSharpCodeProvider tCSProvider = new CSharpCodeProvider();
        ICodeCompiler tCodeCom = tCSProvider.CreateCompiler();

        //設定編譯參數
        System.CodeDom.Compiler.CompilerParameters tComPara = new System.CodeDom.Compiler.CompilerParameters();
        tComPara.GenerateExecutable = false;
        tComPara.GenerateInMemory = true;

        //取得編譯結果
        System.CodeDom.Compiler.CompilerResults tComResult = tCodeCom.CompileAssemblyFromDom(tComPara, tCodeComUnit);

        //如果編譯有錯誤的話，將錯誤訊息丟出
        if (true == tComResult.Errors.HasErrors)
        {
            System.Text.StringBuilder tStr = new System.Text.StringBuilder();
            foreach (System.CodeDom.Compiler.CompilerError tComError in tComResult.Errors)
            {
                tStr.Append(tComError.ToString());
                tStr.Append(System.Environment.NewLine);
            }
            throw new Exception(tStr.ToString());
        }

        //取得編譯後產出的Assembly
        System.Reflection.Assembly tAssembly = tComResult.CompiledAssembly;
        Type tType = tAssembly.GetType(@pNamespace + "." + pClassname, true, true);
        object tTypeInstance = Activator.CreateInstance(tType);
        //若WS有overload的話，需明確指定參數內容
        Type[] tArgsType = null;
        if (pArgs == null)
        {
            tArgsType = new Type[0];
        }
        else
        {
            int tArgsLength = pArgs.Length;
            tArgsType = new Type[tArgsLength];
            for (int i = 0; i < tArgsLength; i++)
            {
                tArgsType[i] = pArgs[i].GetType();
            }
        }

        //若沒有overload的話，第二個參數便不需要，這邊要注意的是WsiProfiles.BasicProfile1_1本身不支援Web Service overload，因此需要改成不遵守WsiProfiles.BasicProfile1_1協議
        System.Reflection.MethodInfo tInvokeMethod = tType.GetMethod(pMethodname, tArgsType);
        //實際invoke該method
        return tInvokeMethod.Invoke(tTypeInstance, pArgs);
    }

    // IsNumeric Function
    // 資料來源：http://support.microsoft.com/kb/329488/zh-tw
    public static bool IsNumeric(object Expression)
    {
        // Variable to collect the Return value of the TryParse method.
        bool isNum;

        // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
        double retNum;

        // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
        // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
        isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
        return isNum;
    }

    public string ListStr2Str(List<string> list)
    {
        StringBuilder sb = new StringBuilder();
        foreach ( var l in list )
        {
            sb.Append(l);
            sb.Append("、");
        }

        return sb.ToString();
    }


    public List<string> Str2ListStr(string str)
    {
        List<string> list = new List<string>();

        return str.Split('、').ToList();
    }

    #region "判斷字串是否為正確的電子郵件地址"
    /// <summary>
    /// 判斷字串是否為正確的電子郵件地址
    /// </summary>
    /// <param name="mailAddress">電子郵件地址</param>
    /// <returns>傳回布林值</returns>
    public static bool IsMailAddress(string mailAddress)
    {
        bool bln;
        try
        {
            System.Net.Mail.MailAddress mail = new System.Net.Mail.MailAddress(mailAddress);
            bln = true;
        }
        catch
        {
            bln = false;
        }

        return bln;
    }
    #endregion 


    public static string GetClientIP(HttpRequest request)
    {
        //判所client端是否有設定代理伺服器
        if (request.ServerVariables["HTTP_VIA"] == null)
            return request.ServerVariables["REMOTE_ADDR"].ToString();
        else
            return request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
    }
}
