using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
public partial class Flow_UserForm : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ( !IsPostBack )
        {
            bindTv();
        }
        win.VisibleOnPageLoad = false;
    }

    private void bindTv()
    {
        try
        {
            JbFlow.ServiceClient sc = new JbFlow.ServiceClient();            
            List<JbFlow.FormTreeTable> list = sc.GetFormTreeToList(Juser.Nobr).ToList();

            List<JbFlow.FormTreeTable> rootList = (from c in list where c.ParentNodeID.Trim().Equals("") select c).ToList();

            foreach (var i in rootList)
            {
                RadTreeNode node = new RadTreeNode();
                node.Value = i.Value;
                node.Category = i.NavigateUrl;
                node.Text = i.Text;
                getChildNodes(list, node);
                tv.Nodes.Add(node);
            }

            tv.ExpandAllNodes();
        }
        catch
        {
            Show("連線有誤");
        }
    }

    private void getChildNodes(List<JbFlow.FormTreeTable> list, RadTreeNode node)
    {
        List<JbFlow.FormTreeTable> cList = (from c in list where c.ParentNodeID.Equals(node.Value) select c).ToList();

        foreach (var i in cList)
        {
            RadTreeNode cnode = new RadTreeNode();
            cnode.Value = i.Value;
            cnode.Text = i.Text;
            cnode.Category = i.NavigateUrl;
            getChildNodes(list, cnode);
            node.Nodes.Add(cnode);
        }
    }
    protected void tv_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        //if (e.Node.Value.Equals("#"))
        //    return;
        if (!SiteHelper.IsNumeric(e.Node.Value))
            return;

        win.NavigateUrl = e.Node.Category + @"#" + DateTime.Now.ToFileTimeUtc().ToString();
        win.Left = 0;
        win.Top = 0;
        win.InitialBehaviors = WindowBehaviors.Maximize; 
        win.VisibleOnPageLoad = true;
    }
}