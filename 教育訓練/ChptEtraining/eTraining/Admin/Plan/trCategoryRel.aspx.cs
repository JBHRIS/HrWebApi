using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
public partial class eTraining_Admin_Plan_trCategoryRel : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);
        if (!IsPostBack)
        {
            SiteHelper util = new SiteHelper();
            util.SetTvCourseCat(tvCatCou);            
            //tvCatCou.CollapseAllNodes();
           // setTvCourse(tvCatCou);
        }
    }

    //private void setTvCourse(RadTreeView tv)
    //{
    //    IList<RadTreeNode> NodeList = tv.GetAllNodes();

    //    foreach (RadTreeNode node in NodeList)
    //    {
    //        var catCourseList = from c in dcTraining.trCategoryCourse
    //                         where c.sCateCode == node.Value
    //                         select c;

    //        foreach (var catCourse in catCourseList)
    //        {
    //            RadTreeNode newNode = new RadTreeNode();
    //            newNode.Category = "COURSE";                
    //            newNode.Text = catCourse.trCourse.sName;                
    //            newNode.Value = catCourse.sCourseCode;
    //            newNode.ForeColor = System.Drawing.Color.Red;
    //            newNode.ImageUrl = "~/App_Themes/Formosa/Images/eTraining/blackboard_sum1.png";
    //            node.Nodes.Add(newNode);
    //        }

    //    }

    //}

    protected void btnAddCourse_Click(object sender, EventArgs e)
    {

        string sCate = tvCatCou.SelectedValue;

//        foreach (System.Collections.DictionaryEntry i in gv.SelectedValues)
        foreach (GridItem i in gv.SelectedItems)
        {
            string key = i.OwnerTableView.DataKeyValues[i.ItemIndex]["sCode"].ToString();

            if (key.Trim() == "ROOT")
            {
                continue;
            }

            var cat = (from c in dcTraining.trCategory
                       where c.sCode == key && c.sParentCode.Trim().Length == 0
                       select c).FirstOrDefault();

            if (cat != null)
            {
                cat.sParentCode = sCate;                
                dcTraining.SubmitChanges();
            }
        }

        pageRefresh();

    }

    private void pageRefresh()
    {
        tvCatCou.Nodes.Clear();
        SiteHelper util = new SiteHelper();
        util.SetTvCourseCat(tvCatCou);
        //tvCatCou.ExpandAllNodes();
        //setTvCourse(tvCatCou);
        gv.Rebind();
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        RadTreeNode node = tvCatCou.SelectedNode;

        if (node.Category == "CATEGORY")
        {
            var cats = (from c in dcTraining.trCategory
                        where c.sParentCode == node.Value
                        select c).ToList();

            if (cats.Count > 0)
            {
                AlertMsg("此類別還有子類別，無法刪除");
                return;
            }


            var obj = (from c in dcTraining.trCategory
                      where c.sCode == node.Value
                      select c).FirstOrDefault();

            if (obj != null)
            {
                obj.sParentCode = "";                             
                dcTraining.SubmitChanges();
                pageRefresh();
            }
        }
    }
    protected void btnAddCatRoot_Click(object sender, EventArgs e)
    {
        string sCate = "ROOT";

        //        foreach (System.Collections.DictionaryEntry i in gv.SelectedValues)
        foreach (GridItem i in gv.SelectedItems)
        {
            string key = i.OwnerTableView.DataKeyValues[i.ItemIndex]["sCode"].ToString();

            if (key.Trim() == "ROOT")
            {
                continue;
            }

            var cat = (from c in dcTraining.trCategory
                       where c.sCode == key && c.sParentCode.Trim().Length == 0
                       select c).FirstOrDefault();

            if (cat != null)
            {
                cat.sParentCode = sCate;
                dcTraining.SubmitChanges();
            }
        }

        pageRefresh();
    }
    protected void btnExpand_Click(object sender, EventArgs e)
    {
        if (btnExpand.GroupName == "expand")
        {
            tvCatCou.ExpandAllNodes();
            btnExpand.Text = "摺疊";
            btnExpand.GroupName = "collapse";
        }
        else
        {            
            tvCatCou.CollapseAllNodes();
            btnExpand.Text = "展開";
            btnExpand.GroupName = "expand";
        }
    }
}