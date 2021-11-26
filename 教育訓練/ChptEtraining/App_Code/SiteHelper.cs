using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Telerik.Web.UI;
using System.Text;
using System.IO;
using System.Web.SessionState;
using System.Web.Util;
using Repo;
using Telerik.Web.UI;
using System.Data.SqlTypes;
/// <summary>
/// SiteHelper 的摘要描述
/// </summary>
public class SiteHelper
{
    const string TREE_CATEGORY_ITEM = "CATEGORY";
    const string TREE_COURSE_ITEM = "COURSE";
    public const string UPLOAD_PATH = @"~\UPLOAD\";
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    public SiteHelper()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    
    /// <summary>
    /// 檔案移除，放置在資料夾Deleted裡面
    /// </summary>
    /// <param name="oldObj"></param>
    public void DeleteFile(UPLOAD oldObj)
    {       
        var obj = (from c in dcTraining.UPLOAD
                   where c.iAutoKey == oldObj.iAutoKey
                   select c).FirstOrDefault();

        if(obj ==null)
            return;

        obj.FileStoredPath = @"~\UPLOAD\" + "Deleted" + @"\";

        obj.FileDeletedDate = DateTime.Now;

        obj.FileDeletedMan = HttpContext.Current.User.Identity.Name;

        if ( !Directory.Exists(HttpContext.Current.Server.MapPath(obj.FileStoredPath)) )
        {
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(obj.FileStoredPath));
        }
        try
        {
            File.Move(HttpContext.Current.Server.MapPath(oldObj.FileStoredPath) + oldObj.FileStoredName , HttpContext.Current.Server.MapPath(obj.FileStoredPath) + obj.FileStoredName);

            obj.FileDeleted = true;
            if ( File.Exists(HttpContext.Current.Server.MapPath(obj.FileStoredPath) + obj.FileStoredName) )
            {
                dcTraining.SubmitChanges();
            }
        }
        catch
        {
            throw new ApplicationException("檔案刪除有誤，請洽資訊人員");
        }
    }


    /// <summary>
    /// 把位元的 role 轉角色  192 -> 轉成兩個角色 key值
    /// </summary>
    /// <param name="roles"></param>
    /// <returns></returns>
    public ArrayList TransRoles(string roles)
    {
        ArrayList list = new ArrayList();
        int roleNum = Convert.ToInt32(roles);

        var roles_list = (from c in dcTraining.sysRole orderby c.iKey descending select c).ToList();

        for (int i = 0; i < roles_list.Count(); i++)
        {
            if (roleNum >= roles_list[i].iKey)
            {
                list.Add(roles_list[i].iKey.ToString());
                roleNum = roleNum - roles_list[i].iKey;
            }
        }

        return list;
    }


    public List<DEPT> GetDeptList()
    {
        List<DEPT> deptList = new List<DEPT>();
        var list = dcTraining.DEPT.Where(a => a.DEPT_GROUP == "").ToList();
        foreach (var r in list)
        {
            deptList.Add(r);
            GetDeptNode(r.D_NO, deptList);
        }

        return deptList;
    }


    public void GetDeptNode(string deptCode, List<DEPT> deptList)
    {

        var list = dcTraining.DEPT.Where(a => a.DEPT_GROUP == deptCode).ToList();

        foreach (var r in list)
        {
            deptList.Add(r);
            GetDeptNode(r.D_NO, deptList);
        }

    }

    public void SetTvCourseCheckable(RadTreeView tv)
    {
        IList<RadTreeNode> NodeList = tv.GetAllNodes();
        tv.CheckBoxes = true;

        foreach (RadTreeNode node in NodeList)
        {
            if (node.Category == "COURSE")
            {
                node.Checkable = true;
            }
            else
            {
                node.Checkable = false;
            }
        }
    }

    /// <summary>
    /// 設定 treeview selected node
    /// </summary>
    /// <param name="tv"></param>
    /// <param name="value"></param>
    public void SetTvSelectedNode(RadTreeView tv, string value)
    {
        RadTreeNode node = tv.FindNodeByValue(value);
        if (node != null)
        {
            node.Selected = true;
            node.Expanded = true;
            node.ExpandParentNodes();
        }
    }

    //清除treenode 的checked
    public void ClearTvChecked(RadTreeView tv)
    {
        if (tv.CheckBoxes == true)
        {
            IList<RadTreeNode> NodeList = tv.GetAllNodes();

            foreach (RadTreeNode node in NodeList)
            {
                node.Checked = false;
            }
        }
    }
    //展開AND摺疊
    public void SetExpand(RadTreeView tv, RadButton btn)
    {
        if (btn.GroupName == "expand")
        {
            tv.ExpandAllNodes();
            btn.Text = "摺疊";
            btn.GroupName = "collapse";
        }
        else
        {
            tv.CollapseAllNodes();
            btn.Text = "展開";
            btn.GroupName = "expand";
        }
    }

    //設定課程節點顏色
    public void SetCourseNodeColorImg(RadTreeNode node)
    {
        var course = (from c in dcTraining.trCourse where c.sCode == node.Value select c).FirstOrDefault();
        if (course.bIsSerialCourse)
        {
            SetNodeColorImg(node, "", "#FF0000");
        }
        else
        {
            SetNodeColorImg(node, "", "");
        }
    }

    //設定節點顏色
    public void SetNodeColorImg(RadTreeNode node,string imgUrl,string color)
    {
        if(color.Length ==0)
            node.ForeColor = System.Drawing.Color.FromName("#00A002");
        else
            node.ForeColor = System.Drawing.Color.FromName(color);

        if (imgUrl.Length == 0)
            node.ImageUrl = "~/App_Themes/Formosa/Images/eTraining/blackboard_sum1.png";
        else
            node.ImageUrl = imgUrl;    
    }

    //設定tree中的課程
    public void SetTvCourse(RadTreeView tv)
    {
        IList<RadTreeNode> NodeList = tv.GetAllNodes();

        DateTime datetime = DateTime.Now.Date;

        var catCourseAllList = (from c in dcTraining.trCategoryCourse
                                join d in dcTraining.trCourse
                                on c.sCourseCode equals d.sCode
                                where datetime >= d.dDateA && datetime <= d.dDateD
                                select new { c, d }).ToList();

        foreach (RadTreeNode node in NodeList)
        {
            var catCourseList = from a in catCourseAllList
                                where a.c.sCateCode == node.Value
                                select a;            

            foreach (var catCourse in catCourseList)
            {
                RadTreeNode newNode = new RadTreeNode();
                newNode.Category = "COURSE";
                try
                {
                    newNode.Text = catCourse.d.sName;
                    newNode.Value = catCourse.d.sCode;
                }
                catch (Exception ex)
                {
                    continue;
                }

                if (catCourse.d.bIsSerialCourse == false)
                {
                    SetNodeColorImg(newNode, "", "");
                }
                else
                {
                    SetNodeColorImg(newNode, "","#FF0000");
                }
                node.Nodes.Add(newNode);
            }
        }
    }

    /// <summary>
    /// 設定非序列課程
    /// </summary>
    /// <param name="tv"></param>
    public void SetTvNonSerialCourse(RadTreeView tv)
    {
        IList<RadTreeNode> NodeList = tv.GetAllNodes();

        foreach (RadTreeNode node in NodeList)
        {
            var catCourseList = from c in dcTraining.trCategoryCourse
                                where c.sCateCode == node.Value && c.trCourse.bIsSerialCourse == false
                                select c;

            foreach (var catCourse in catCourseList)
            {
                RadTreeNode newNode = new RadTreeNode();
                newNode.Category = "COURSE";
                newNode.Text = catCourse.trCourse.sName;
                newNode.Value = catCourse.sCourseCode;
                //newNode.ForeColor = System.Drawing.Color.Red;
                SetNodeColorImg(newNode, "", "");
                node.Nodes.Add(newNode);
            }
        }
    }

    public void SetDeptTvByDeptID(RadTreeView tv,string deptID)
    {
        var dept = (from c in dcTraining.DEPT
                    where c.D_NO == deptID
                    select c).FirstOrDefault();

        if (dept != null)
        {
            Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
            node.Text = dept.D_NAME;
            node.Value = dept.D_NO;
            GetTvNode(node);
            tv.Nodes.Add(node);
        }
    }


    public void setDeptTv(RadTreeView tv)
    {
        var deptList = dcTraining.DEPT.Where(a => a.DEPT_GROUP == "").ToList();

        foreach (var r in deptList)
        {
            Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
            node.Text = r.D_NAME;
            node.Value = r.D_NO;
            GetTvNode(node);
            tv.Nodes.Add(node);
        }
    }

    public RadTreeNode GetTvNode(RadTreeNode pNode)
    {
        var list = dcTraining.DEPT.Where(a => a.DEPT_GROUP == pNode.Value).ToList();

        foreach (var r in list)
        {
            Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
            node.Text = r.D_NAME;
            node.Value = r.D_NO;
            GetTvNode(node);
            pNode.Nodes.Add(node);
        }

        return pNode;
    }

    //課程類別的treeview，設定課程的類別
    public void SetTvCourseCat(RadTreeView tv)
    {
        Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
        node.Value = "ROOT";
        node.Text = "ROOT";
        node.Category = TREE_CATEGORY_ITEM;
        tv.Nodes.Clear();
        Telerik.Web.UI.RadTreeNode tmp_node = GetCourseCatTVNode(node);

        //add node之後，集合的node會自己消失，所以才...
        while (tmp_node.Nodes.Count > 0)
        {
            tv.Nodes.Add(tmp_node.Nodes[0]);
        }

        //tv.ExpandAllNodes();
    }

    public void SaveTreeViewNodesColor(IList<RadTreeNode> nodeList, string sessionName)
    {        
        List<RadTreeNode> savedNodeList = new List<RadTreeNode>();

        foreach (RadTreeNode node in nodeList)
        {
            savedNodeList.Add(node.Clone());                                    
        }

        System.Web.HttpContext.Current.Session[sessionName] = savedNodeList;
    }

    public void LoadTreeViewNodesColor(IList<RadTreeNode> nodeList,string sessionName)
    {
        List<RadTreeNode> savedNodeList = (List<RadTreeNode>)System.Web.HttpContext.Current.Session[sessionName];                        
        
        foreach (RadTreeNode node in nodeList)
        {

            if (node.Category == "COURSE")
            {
                var n = (from c in savedNodeList where node.Value == c.Value && c.Category == "COURSE" select c).FirstOrDefault();

                if (n != null)
                {
                    node.ForeColor = n.ForeColor;
                }
            }
        }
    }



    public static bool lbHasValue(RadListBox lb, string value)
    {
        bool result = false;

        for (int j = 0; j < lb.Items.Count; j++)
        {
            if (value.Equals(lb.Items[j].Value))
            {
                result = true;
            }
        }

        return result;
    }

    private Telerik.Web.UI.RadTreeNode GetCourseCatTVNode(Telerik.Web.UI.RadTreeNode node)
    {
        var list = from c in dcTraining.trCategory
                   where c.sParentCode == node.Value
                   orderby c.iOrder
                   select c;

        foreach (var iterator in list)
        {
            Telerik.Web.UI.RadTreeNode tmp_node = new Telerik.Web.UI.RadTreeNode();
            tmp_node.Value = iterator.sCode;
            tmp_node.Text = iterator.sName;
            tmp_node.Category = TREE_CATEGORY_ITEM;
            node.Nodes.Add(GetCourseCatTVNode(tmp_node));
        }

        return node;
    }



    public static bool IsNumeric(char ch)
    {
        //If the given character is in between 0 and 9 then
        //return true, otherwise false
        if (ch >= '0' && ch <= '9')
            return true;
        else
            return false;
    }


    //Porting Common VB functions to C#: Asc()

    public static int Asc(string S)
    {
        int N = Convert.ToInt32(S[0]);
        return N;
    }

    public static int Asc(char C)
    {
        int N = Convert.ToInt32(C);
        return N;
    }

    //Porting Common VB functions to C#: Chr()

    public static Char Chr(int i)
    {
        //Return the character of the given character value
        return Convert.ToChar(i);
    }

    public static Dictionary<string, string> TransReqParam(string param)
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        string str = EverEncode.TurnUncode(param);

        string[] strs = str.Split('&');

        foreach (string s in strs)
        {
            string[] strs1 = s.Split('=');

            if (strs1.Count() == 2)
            {
                dic.Add(strs1[0], strs1[1]);
            }
            else
            {
                dic.Add(s, "");
            }
        }

        return dic;
    }


    public void SetCbxSameValue(RadComboBox source ,RadComboBox dest)
    {
        foreach (RadComboBoxItem item in dest.Items)
        {
            if (item.Value == source.SelectedValue)
            {
                item.Selected = true;
            }
        }


    }

    public static String GetHour(int min)
    {
        double hour = min / 60;
        return Math.Round(hour, 1, MidpointRounding.AwayFromZero).ToString();
    }

    public static void ResponseExcel(MemoryStream ms, string fileName)
    {
        HttpResponse response = HttpContext.Current.Response;
        //HttpUtility.UrlEncode(_upfilenameLabel.Text, System.Text.Encoding.UTF8))
        response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8) + ".xls"));
        response.BinaryWrite(ms.ToArray());
        response.End();
    }

    public static System.Data.DataTable LinqToDataTable<T>(IEnumerable<T> data)
    {
        var dt = new System.Data.DataTable();
        var ps = typeof(T).GetProperties().ToList();
        ps.ForEach(p => dt.Columns.Add(p.Name, p.PropertyType));

        foreach (T t in data)
        {
            var dr = dt.NewRow();
            var vs = from p in ps select p.GetValue(t, null);
            var ls = vs.ToList();
            int i = 0;
            ls.ForEach(c => dr[i++] = c);
            dt.Rows.Add(dr);
        }
        return dt;
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

    /// <summary>
    /// 傳入RadComboBox，如果有設定CheckBoxes，則全選
    /// </summary>
    /// <param name="cbx"></param>
    public static void CbxSelectAll(RadComboBox cbx)
    {
        if (cbx.CheckBoxes)
        {            
            foreach (RadComboBoxItem item in cbx.Items)
                item.Checked = true;
        }
    }


    //功能向下展開(起點) For Admin展樹狀
    public void BuildAdminMainTv(RadTreeView TvMain)
    {
        TvMain.Nodes.Clear();
        List<sysFileStructure> sysList = sysFileStructure_Repo.GetInstance();

        var ls = (from c in sysList
                  where c.sParentKey == "Root"
                  orderby c.iOrder
                  select c).ToList();

        foreach (var r in ls)
        {
            Telerik.Web.UI.RadTreeNode node = new RadTreeNode();
            node.Text = r.sFileTitle;
            node.Value = r.sKey;
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
        List<sysFileStructure> sysList = sysFileStructure_Repo.GetInstance();
        var ls = (from c in sysList
                  where c.sParentKey == nodeP.Value
                  orderby c.iOrder
                  select c).ToList();

        foreach (var r in ls)
        {
            Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
            node.Text = r.sFileTitle;
            node.Value = r.sKey;
            //node.ForeColor = System.Drawing.Color.Black;

            if (r.sIconName != null && r.sIconName.Trim().Length > 0)
            {
                node.ImageUrl = "~" + r.sIconPath + r.sIconName;
            }

            BuildAdminMainTvNode(node);
            nodeP.Nodes.Add(node);
        }
    }



    //功能向下展開(起點)
    public void SetMainTvRootValues(string Root, RadTreeView TvMain,JUser juser)
    {
        List<sysFileStructure> sysList = sysFileStructure_Repo.GetInstance();
        List<FileStructureRole> fsRoleAllList = FileStructureRole_Repo.GetInstance();

        var ls = (from c in sysList
                  where c.sParentKey == Root
                  orderby c.iOrder
                  select c).ToList();

        foreach (var r in ls)
        {
            List<FileStructureRole> fsRoleList = fsRoleAllList.Where(p => p.FileStructureKey.Equals(r.sKey)).ToList();

            if (!fsRoleList.Any(p => juser.IntRoleList.Contains(p.RoleKey)))
            {
                continue;
            }

            Telerik.Web.UI.RadTreeNode node = new RadTreeNode();
            node.Text = r.sFileTitle;
            node.Value = r.sKey;
            node.ForeColor = System.Drawing.Color.Black;
            if (r.sFileName != null && r.sFileName.Trim().Length > 0 && r.sPath != null && r.sPath.Trim().Length > 0)
            {
                //增加此項目會影響到 node_click的postback，所以網址存在category中，click之後再導過去
                node.Category = "~" + r.sPath + r.sFileName;
                // node.NavigateUrl ="~/"+ r.sPath + r.sFileName;                
            }

            if (r.sIconName != null && r.sIconName.Trim().Length > 0)
            {
                node.ImageUrl = "~" + r.sIconPath + r.sIconName;
            }

            node.Target = "_self";

            SetMainTvNodeValues(node,juser);
            //node.ExpandChildNodes();    
            TvMain.Nodes.Add(node);

        }
    }


    //功能向下展開
    public void SetMainTvNodeValues(Telerik.Web.UI.RadTreeNode nodeP, JUser juser)
    {
        List<sysFileStructure> sysList = sysFileStructure_Repo.GetInstance();
        var ls = (from c in sysList
                  where c.sParentKey == nodeP.Value
                  orderby c.iOrder
                  select c).ToList();

        List<FileStructureRole> fsRoleAllList = FileStructureRole_Repo.GetInstance();

        foreach (var r in ls)
        {
            List<FileStructureRole> fsRoleList = fsRoleAllList.Where(p => p.FileStructureKey.Equals(r.sKey)).ToList();

            if (!fsRoleList.Any(p => juser.IntRoleList.Contains(p.RoleKey)))
            {
                continue;
            }

            Telerik.Web.UI.RadTreeNode node = new Telerik.Web.UI.RadTreeNode();
            node.Text = r.sFileTitle;
            node.Value = r.sKey;
            node.ForeColor = System.Drawing.Color.Black;
            //node.ExpandMode = TreeNodeExpandMode.ServerSide;

            if (r.sFileName != null && r.sFileName.Trim().Length > 0 && r.sPath != null && r.sPath.Trim().Length > 0)
            {
                //增加此項目會影響到 node_click的postback，所以網址存在category中，click之後再導過去
                ////node.Category = "~/" + r.sPath + r.sFileName;
                // node.NavigateUrl = "~/" + r.sPath + r.sFileName;
                node.NavigateUrl = "~"+ r.sPath + r.sFileName;
            }

            if (r.sIconName != null && r.sIconName.Trim().Length > 0)
            {
                node.ImageUrl = "~" + r.sIconPath + r.sIconName;
            }

            SetMainTvNodeValues(node,juser);
            nodeP.Nodes.Add(node);
        }
    }

    public void setTvNodeDefault(RadTreeView tv)
    {
        foreach (RadTreeNode node in tv.Nodes)
        {
            setNodeDefault(node);
        }

    }

    private void setNodeDefault(RadTreeNode node)
    {
        node.ForeColor = System.Drawing.Color.Black;
        node.Font.Bold = false;
        foreach (RadTreeNode n in node.Nodes)
        {
            setNodeDefault(n);
        }
    }


    public void InitManagerDeptTreeView(RadTreeView tv, List<RadTreeNode> list)
    {
        tv.Nodes.Clear();
        foreach (RadTreeNode n in list)
        {
            tv.Nodes.Add(n);
        }
    }

    public List<RadTreeNode> BuildManagerTv(List<DeptDto> list)
    {
        var rootList = (from c in list where c.ParentDeptCode.Equals("") select c).ToList();
        List<RadTreeNode> resultList = new List<Telerik.Web.UI.RadTreeNode>();

        foreach (var n in rootList)
        {
            RadTreeNode newNode = new Telerik.Web.UI.RadTreeNode();
            newNode.Value = n.DeptCode;
            newNode.Text = n.DeptName;
            resultList.Add(newNode);
            BuildManagerTvChildNode(newNode, list);
        }

        return resultList;
    }

    public void BuildManagerTvChildNode(RadTreeNode node, List<DeptDto> list)
    {
        var nodeList = (from c in list where c.ParentDeptCode.Equals(node.Value) select c).ToList();
        foreach (var n in nodeList)
        {
            RadTreeNode newNode = new Telerik.Web.UI.RadTreeNode();
            newNode.Value = n.DeptCode;
            newNode.Text = n.DeptName;
            node.Nodes.Add(newNode);
            BuildManagerTvChildNode(newNode, list);
        }
    }

    //功能向下展開(起點)
    public void SetMainTvRootValues(string Root, RadMenu menu, JUser juser)
    {
        List<sysFileStructure> sysList = sysFileStructure_Repo.GetInstance();
        List<FileStructureRole> fsRoleAllList = FileStructureRole_Repo.GetInstance();

        var ls = (from c in sysList
                  where c.sParentKey == Root
                  orderby c.iOrder
                  select c).ToList();

        foreach (var r in ls)
        {
            List<FileStructureRole> fsRoleList = fsRoleAllList.Where(p => p.FileStructureKey.Equals(r.sKey)).ToList();

            if (!fsRoleList.Any(p => juser.IntRoleList.Contains(p.RoleKey)))
            {
                continue;
            }
            
            RadMenuItem node = new Telerik.Web.UI.RadMenuItem();
            node.Text = r.sFileTitle;
            node.Value = r.sKey;
            if (r.sFileName != null && r.sFileName.Trim().Length > 0 && r.sPath != null && r.sPath.Trim().Length > 0)
            {
                node.NavigateUrl = "~/" + r.sPath + r.sFileName;                
            }

            //if (r.sIconName != null && r.sIconName.Trim().Length > 0)
            //{
            //    node.ImageUrl = "~" + r.sIconPath + r.sIconName;
            //}

            node.Target = "_self";

            SetMainTvNodeValues(node, juser);
            menu.Items.Add(node);
        }
    }

    //功能向下展開
    public void SetMainTvNodeValues(RadMenuItem nodeP, JUser juser)
    {
        List<sysFileStructure> sysList = sysFileStructure_Repo.GetInstance();
        var ls = (from c in sysList
                  where c.sParentKey == nodeP.Value
                  orderby c.iOrder
                  select c).ToList();

        List<FileStructureRole> fsRoleAllList = FileStructureRole_Repo.GetInstance();

        foreach (var r in ls)
        {
            List<FileStructureRole> fsRoleList = fsRoleAllList.Where(p => p.FileStructureKey.Equals(r.sKey)).ToList();

            if (!fsRoleList.Any(p => juser.IntRoleList.Contains(p.RoleKey)))
            {
                continue;
            }

            RadMenuItem node = new RadMenuItem();
            node.Text = r.sFileTitle;
            node.Value = r.sKey;

            if (r.sFileName != null && r.sFileName.Trim().Length > 0 && r.sPath != null && r.sPath.Trim().Length > 0)
            {
                node.NavigateUrl = "~" + r.sPath + r.sFileName;
            }

            //if (r.sIconName != null && r.sIconName.Trim().Length > 0)
            //{
            //    node.ImageUrl = "~" + r.sIconPath + r.sIconName;
            //}

            SetMainTvNodeValues(node, juser);
            nodeP.Items.Add(node);
        }
    }

}