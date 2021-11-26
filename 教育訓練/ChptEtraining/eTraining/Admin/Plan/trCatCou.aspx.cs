using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
public partial class eTraining_Admin_Plan_trCatCou : System.Web.UI.Page
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    const string SESSION_NAME = "trCatCou";

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);
        if (!IsPostBack)
        {
            SiteHelper util = new SiteHelper();
            util.SetTvCourseCat(tvCatCou);
            util.SetTvCourse(tvCatCou);

            SiteHelper siteHelper = new SiteHelper();
            siteHelper.SaveTreeViewNodesColor(tvCatCou.GetAllNodes(), SESSION_NAME);
        }
        this.Title = "課程類別關聯設定";
    }


    protected void btnAddCourse_Click(object sender, EventArgs e)
    {
        if (tvCatCou.SelectedNode == null)
        {
            return;
        }

        string sCate = tvCatCou.SelectedValue;
        IList<RadTreeNode> NodeList = tvCatCou.GetAllNodes();

        //        foreach (System.Collections.DictionaryEntry i in gv.SelectedValues)
        SiteHelper siteHelper = new SiteHelper();
        siteHelper.LoadTreeViewNodesColor(tvCatCou.GetAllNodes(), SESSION_NAME);


        foreach (GridItem i in gv.SelectedItems)
        {
            string key = i.OwnerTableView.DataKeyValues[i.ItemIndex]["sCode"].ToString();

            var catCourseList = from c in dcTraining.trCategoryCourse
                                where c.sCourseCode == key && c.sCateCode == sCate
                                select c;

            try
            {
                var catCourse = catCourseList.FirstOrDefault();
                if (catCourse == null)
                {
                    trCategoryCourse obj = new trCategoryCourse();

                    obj.iOrder = 1;
                    obj.sCourseCode = key;
                    obj.sysRole_iKey = 0;
                    obj.sKeyMan = User.Identity.Name;
                    obj.dKeyDate = DateTime.Now;
                    obj.sCateCode = sCate;

                    if (obj.sCourseCode.Trim().Length == 0 || obj.sCateCode.Trim().Length == 0)
                    {
                        throw new Exception("課程類別或課程為空字串");
                    }
                    else
                    {
                        dcTraining.trCategoryCourse.InsertOnSubmit(obj);
                        dcTraining.SubmitChanges();

                        RadTreeNode node = new RadTreeNode();
                        node.Value = key;
                        node.Text = i.OwnerTableView.Items[i.ItemIndex].Cells[5].Text;
                        //node.ForeColor = System.Drawing.Color.Red;
                        node.Category = "COURSE";
                        siteHelper.SetCourseNodeColorImg(node);
                        //siteHelper.setNodeColorImg(node, "", "");

                        //node.ForeColor = System.Drawing.Color.FromName("#00A002");
                        //node.ImageUrl = "~/App_Themes/Formosa/Images/eTraining/blackboard_sum1.png";
                        insertNode(NodeList, node, sCate);
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        gv.Rebind();
        
        siteHelper.SaveTreeViewNodesColor(tvCatCou.GetAllNodes(), SESSION_NAME);
        //pageRefresh();

    }

    private void insertNode(IList<RadTreeNode> NodeList, RadTreeNode node, string cat)
    {
        var lNode = (from c in NodeList
                     where c.Category == "CATEGORY" && c.Value == cat
                     select c).FirstOrDefault();

        if (lNode != null)
        {
            lNode.Nodes.Add(node);
        }

    }

    //private void pageRefresh()
    //{
    //    tvCatCou.Nodes.Clear();
    //    SiteHelper util = new SiteHelper();
    //    util.setTvCourseCat(tvCatCou);
    //    util.setTvCourse(tvCatCou);
    //    //tvCatCou.CollapseAllNodes();

    //    gv.Rebind();
    //}

    protected void btnDel_Click(object sender, EventArgs e)
    {
        RadTreeNode node = tvCatCou.SelectedNode;

        if (node == null)
            return;

        if (node.Category == "COURSE")
        {
            var obj = (from c in dcTraining.trCategoryCourse
                       where c.sCourseCode == node.Value
                       select c).FirstOrDefault();

            if (obj != null)
            {
                dcTraining.trCategoryCourse.DeleteOnSubmit(obj);
                dcTraining.SubmitChanges();
                gv.Rebind();

                RadTreeNode pNode = node.ParentNode;
                pNode.Nodes.Remove(node);
                //pageRefresh();                                
            }
        }

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
    protected void tvCatCou_PreRender(object sender, EventArgs e)
    {
        SiteHelper siteHelper = new SiteHelper();
        siteHelper.LoadTreeViewNodesColor(tvCatCou.GetAllNodes(), SESSION_NAME);
    }
}