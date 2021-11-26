using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class eTraining_Admin_Plan_trCategory : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private trCategory_Repo catRepo = new trCategory_Repo(); 
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            SiteHelper util = new SiteHelper();
            util.SetTvCourseCat(tvCate);
            tvCate.CollapseAllNodes();
            if (tvCate.Nodes.Count > 0)
            {
                tvCate.Nodes[0].Selected = true;
                tvCate_NodeClick(this, new Telerik.Web.UI.RadTreeNodeEventArgs(tvCate.Nodes[0]));
            }

            btnAddRootNode.Attributes["onclick"] = String.Format("return ShowInsertFormByParam('{0}');", "ROOT");

        }

        //if (txtExpand.GroupName == "expand")
        //{
        //    tvCate.ExpandAllNodes();
        //    txtExpand.Text = "摺疊";
        //    txtExpand.GroupName = "collapse";
        //}
        //else
        //{
        //    tvCate.CollapseAllNodes();
        //    txtExpand.Text = "展開";
        //    txtExpand.GroupName = "expand";
        //}      


    }
    protected void tvCate_NodeClick(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
    {
        lblCategory.Text = e.Node.Value;

        //如果為最後一層，就不能增加課程類別階層
        if (e.Node.Level == trCategory_Repo.Categroy_Level-1)        
            btnAddNode.Visible = false;        
        else
            btnAddNode.Visible = true;
  
        btnAddNode.Attributes["onclick"] = String.Format("return ShowInsertFormByParam('{0}');", lblCategory.Text);
        btnEditNode.Attributes["onclick"] = String.Format("return ShowEditFormByParam('{0}');", lblCategory.Text);
    }
    protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {
        if (e.Argument == "RebindTV")
        {
            tvCate.Nodes.Clear();
            SiteHelper util = new SiteHelper();
            util.SetTvCourseCat(tvCate);
            btnExpand.GroupName = "expand";
            util.SetExpand(tvCate, btnExpand);
            tvCate.ExpandAllNodes();
        }
    }
    protected void btnDelNode_Click(object sender, EventArgs e)
    {
        //判斷是否有子類別
        var cats = (from c in dcTraining.trCategory
                    where c.sParentCode == lblCategory.Text
                    select c).ToList();

        if (cats.Count > 0)
        {
            AlertMsg("此類別還有子類別，無法刪除");
            return;
        }



        var list = from c in dcTraining.trCategory
                   where c.sCode == lblCategory.Text
                   select c;

        var data = list.FirstOrDefault();

        if (data != null)
        {
            var cateRef = from c in dcTraining.trCategoryCourse
                          where c.sCateCode == data.sCode
                          select c;

            dcTraining.trCategoryCourse.DeleteAllOnSubmit(cateRef);

            dcTraining.trCategory.DeleteOnSubmit(data);
            dcTraining.SubmitChanges();
        }

        SiteHelper util = new SiteHelper();
        util.SetTvCourseCat(tvCate);
        tvCate.ExpandAllNodes();
        tvCate.Nodes[0].Selected = true;
        tvCate_NodeClick(this, new Telerik.Web.UI.RadTreeNodeEventArgs(tvCate.Nodes[0]));
    }

    protected void RadButton1_Click(object sender, EventArgs e)
    {
        SiteHelper util = new SiteHelper();
        util.SetExpand(tvCate, btnExpand);

    }

    protected void btnMustTraining_Click(object sender, EventArgs e)
    {
        if (tvCate.SelectedNode != null)
            Response.Redirect("MustTraining.aspx?Category=Category&code=" + tvCate.SelectedValue);
    }

}