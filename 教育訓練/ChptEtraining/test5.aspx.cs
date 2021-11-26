using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
public partial class test5 : JBWebPage
{
    const string SESSION_MPHR_TVSTR = "SESSION_MPHR_TVSTR";
    dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private SiteHelper siteHelper = new SiteHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["test"] != null)
            {
                loadTv(TvMain);

            }
            else
            {
                siteHelper.SetMainTvRootValues("Root", TvMain, Juser);
                saveTv(TvMain);

                foreach (RadTreeNode node in TvMain.Nodes)
                {
                    node.Expanded = true;
                }
            }
        }
    }

    private void saveTv(RadTreeView tv)
    {
        List<Telerik.Web.UI.RadTreeNode> nodes = new List<RadTreeNode>();
        foreach (RadTreeNode a in tv.Nodes)
        {
            nodes.Add(a);
        }

        Session[SESSION_MPHR_TVSTR] = nodes;
    }

    private void loadTv(RadTreeView tv)
    {
        List<Telerik.Web.UI.RadTreeNode> nodes = (List<Telerik.Web.UI.RadTreeNode>)Session[SESSION_MPHR_TVSTR];
        tv.Nodes.Clear();

        foreach (RadTreeNode a in nodes)
        {
            tv.Nodes.Add(a);
        }


        RadTreeNode node = tv.FindNodeByUrl(Request.CurrentExecutionFilePath);
        if (node != null)
        {
            tv.UnselectAllNodes();
            node.Selected = true;
            node.ExpandParentNodes();
        }
    }

    protected void TvMain_PreRender(object sender, EventArgs e)
    {
        if (Session[SESSION_MPHR_TVSTR] != null)
        {
            loadTv(TvMain);
        }
    }

    protected void TvMain_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        siteHelper.setTvNodeDefault(TvMain);
        e.Node.Font.Bold = true;
        // e.Node.ForeColor = System.Drawing.Color.DarkBlue;

        //e.Node.Expanded = true;        
        ////if (e.Node.Category.Length == 0)
        ////    e.Node.Expanded = !e.Node.Expanded;

        saveTv(TvMain);

        ////if (e.Node.Category.Length > 0)
        ////    Response.Redirect(e.Node.Category);
    }
}