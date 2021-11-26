using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Telerik.Web.UI;
using System.Data.Linq;

public partial class HR_Mang_SiteMapConfig : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            initRoleGv();

            //查詢節點主鍵順序、先url、resourceKey、title
            String confPath = Server.MapPath(@"~/Web.sitemap");
            XDocument xml = XDocument.Load(confPath);

            var rootNode = (from c in xml.Descendants()
                            where c.Name == @"{http://schemas.microsoft.com/AspNet/SiteMap-File-1.0}siteMapNode"
                            select c).FirstOrDefault();

            RadTreeNode tnode = new RadTreeNode();

            if (rootNode.Attribute("url") != null)
            {
                tnode.Value = rootNode.Attribute("url").Value;
                //tnode.Text = rootNode.Attribute("url").Value;
                tnode.Text = GetResourceValue(rootNode, rootNode.Attribute("url").Value);
                getTreeNode(rootNode, tnode);
                tv.Nodes.Add(tnode);
                return;

            }
            else if (rootNode.Attribute("resourceKey") != null)
            {
                tnode.Value = rootNode.Attribute("resourceKey").Value;
                //tnode.Text = rootNode.Attribute("resourceKey").Value;
                tnode.Text = GetResourceValue(rootNode, rootNode.Attribute("resourceKey").Value);
                getTreeNode(rootNode, tnode);
                tv.Nodes.Add(tnode);
                return;
            }
            else if (rootNode.Attribute("title") != null)
            {
                tnode.Value = rootNode.Attribute("title").Value;
                tnode.Text = GetResourceValue(rootNode, rootNode.Attribute("title").Value);
                //tnode.Text = rootNode.Attribute("title").Value;
                getTreeNode(rootNode, tnode);
                tv.Nodes.Add(tnode);
                return;
            }
            else
            {
                tnode.Text = "";
                tnode.Value = "";
                getTreeNode(rootNode, tnode);
                tv.Nodes.Add(tnode);
                return;
            }

        }
    }

    private void initRoleGv()
    {
        SiteHelper siteHelper = new SiteHelper();
        List<PortalRole> roleList = siteHelper.GetRoleList();

        gv.DataSource = roleList;
        gv.DataBind();
    }

    private String GetResourceValue(XElement node,string defaultValue)
    {
        if (node.Attribute("resourceKey") != null)
        {
            if (GetGlobalResourceObject("Web.sitemap", node.Attribute("resourceKey").Value + ".title") != null)
                return GetGlobalResourceObject("Web.sitemap", node.Attribute("resourceKey").Value+".title").ToString();
            else
                return defaultValue;
        }
        else
        {
            return defaultValue;
        }
    }


    public void getTreeNode(XElement node, RadTreeNode treeNode)
    {
        foreach (var n in node.Elements())
        {
            RadTreeNode tnode = new RadTreeNode();

            bool isSet = false;

            if (n.Attribute("url") != null)
            {
                tnode.Value = n.Attribute("url").Value;
                tnode.Text = GetResourceValue(n, n.Attribute("url").Value);
                //tnode.Text = n.Attribute("url").Value;
                isSet = true;
            }
            else if (n.Attribute("resourceKey") != null && isSet ==false)
            {
                tnode.Value = n.Attribute("resourceKey").Value;
                //tnode.Text = n.Attribute("resourceKey").Value;
                tnode.Text = GetResourceValue(n, n.Attribute("resourceKey").Value);
                isSet = true;
            }
            else if (n.Attribute("title") != null && isSet == false)
            {
                tnode.Value = n.Attribute("title").Value;
                //tnode.Text = n.Attribute("title").Value;
                tnode.Text = GetResourceValue(n, n.Attribute("title").Value);
                isSet = true;
            }
            else if (isSet == false)
            {
                tnode.Text = "";
                tnode.Value = "";
                isSet = true;
            }

            treeNode.Nodes.Add(tnode);

            if (n.HasElements)
            {
                getTreeNode(n, tnode);
            }
        }
    }


    private void clearData()
    {
        tbRole.Text = "";
        foreach (GridItem c in gv.SelectedItems)
        {
            c.Selected = false;
        }
        //gv.Rebind();
    }


    protected void gv_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }


    protected void gv_DeleteCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem itm = (GridDataItem)e.Item;

            string role = itm["Role"].Text;
            string type = itm["Type"].Text;
            string value = itm["Value"].Text;

            String confPath = Server.MapPath(@"~/roles.config");
            XDocument xml = XDocument.Load(confPath);
            var roles = xml.Element("roles");

            var a = (from c in roles.Elements()
                     where c.Value == value
                         && c.Attribute("role").Value == role
                         && c.Attribute("type").Value == type
                     select c).FirstOrDefault();

            a.Remove();
            xml.Save((confPath));
            //gv.Rebind();
        }
    }
    protected void tv_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        clearData();


        String confPath = Server.MapPath(@"~/Web.sitemap");
        XDocument xml = XDocument.Load(confPath);

        var node = (from c in xml.Descendants()
                    where c.Name == @"{http://schemas.microsoft.com/AspNet/SiteMap-File-1.0}siteMapNode"
                    &&
                    (
                    (c.Parent.Attribute("url") != null && c.Parent != null && e.Node.ParentNode != null && c.Parent.Attribute("url").Value == e.Node.ParentNode.Value)
                    ||
                    (c.Parent.Attribute("resourceKey") != null && c.Parent != null && e.Node.ParentNode != null && c.Parent.Attribute("resourceKey").Value == e.Node.ParentNode.Value)
                    ||
                    (c.Parent.Attribute("title") != null && c.Parent != null && e.Node.ParentNode != null && c.Parent.Attribute("title").Value == e.Node.ParentNode.Value)
                    )
                    &&
                    (
                    (c.Attribute("url") != null && c.Attribute("url").Value == e.Node.Value)
                    ||
                    (c.Attribute("resourceKey") != null && c.Attribute("resourceKey").Value == e.Node.Value)
                    ||
                    (c.Attribute("title") != null && c.Attribute("title").Value == e.Node.Value)
                    )
                    select c).FirstOrDefault();


        if (node != null)
        {
            if (node.Attribute("roles") != null)
            {
                tbRole.Text = node.Attribute("roles").Value;
                loadGvData(tbRole.Text);
            }
        }
    }

    private void loadGvData(string Avalue)
    {
        List<string> strArr = Avalue.Split(',').Select(p => p.Trim()).ToList() ;

        foreach (GridDataItem i in gv.Items)
        {
            if (strArr.Contains(i["Role"].Text))
                i.Selected = true;
        }
    }


    protected void RadButton1_Click(object sender, EventArgs e)
    {
        if (tv.SelectedNode == null)
        {
            lblMsg.Text = "尚未選擇節點";
            return;
        }
        else
            lblMsg.Text = "";

        String confPath = Server.MapPath(@"~/Web.sitemap");
        XDocument xml = XDocument.Load(confPath);

        //var node = (from c in xml.Descendants()
        //            where c.Name == @"{http://schemas.microsoft.com/AspNet/SiteMap-File-1.0}siteMapNode"
        //            && c.Attribute("url") != null
        //            && c.Attribute("url").Value == tv.SelectedNode.Value
        //            select c).FirstOrDefault();


        var node = (from c in xml.Descendants()
                    where c.Name == @"{http://schemas.microsoft.com/AspNet/SiteMap-File-1.0}siteMapNode"
                    &&
                    (
                    (c.Parent.Attribute("url") != null && c.Parent != null && tv.SelectedNode.ParentNode != null && c.Parent.Attribute("url").Value == tv.SelectedNode.ParentNode.Value)
                    ||
                    (c.Parent.Attribute("resourceKey") != null && c.Parent != null && tv.SelectedNode.ParentNode != null && c.Parent.Attribute("resourceKey").Value == tv.SelectedNode.ParentNode.Value)
                    ||
                    (c.Parent.Attribute("title") != null && c.Parent != null && tv.SelectedNode.ParentNode != null && c.Parent.Attribute("title").Value == tv.SelectedNode.ParentNode.Value)
                    )
                    &&
                    (
                    (c.Attribute("url") != null && c.Attribute("url").Value == tv.SelectedNode.Value)
                    ||
                    (c.Attribute("resourceKey") != null && c.Attribute("resourceKey").Value == tv.SelectedNode.Value)
                    ||
                    (c.Attribute("title") != null && c.Attribute("title").Value == tv.SelectedNode.Value)
                    )
                    select c).FirstOrDefault();

        if (node != null)
        {
            string saveValue = "";
            for (int i = 0; i < gv.SelectedItems.Count; i++)
            {
                GridDataItem item = gv.SelectedItems[i] as GridDataItem;

                if (i == 0)
                    saveValue = item["Role"].Text;
                else
                    saveValue = saveValue + "," + item["Role"].Text;
            }
            //node.SetAttributeValue("roles", tbRole.Text);
            node.SetAttributeValue("roles", saveValue);
            xml.Save((confPath));
        }

    }
}