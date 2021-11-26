using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Telerik.Web.UI;
using System.Data.Linq;
using BL;

public partial class HR_Mang_SiteMapSALADRConfig : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getSiteMapTree();
            bindDgCbx();
        }
    }

    private void bindDgCbx()
    {
        DATAGROUP_REPO dpRepo = new DATAGROUP_REPO();
        dgCbx.DataSource= dpRepo.GetAll();
        dgCbx.DataBind();
    }

    private void getSiteMapTree()
    {
        //查詢節點主鍵順序、先url、resourceKey、title
        String confPath = Server.MapPath(@"~/Web.sitemap");
        XDocument xml = XDocument.Load(confPath);

        var rootNode = (from c in xml.Descendants()
                        where c.Name == @"{http://schemas.microsoft.com/AspNet/SiteMap-File-1.0}siteMapNode"
                        select c).FirstOrDefault();

        RadTreeNode tnode = new RadTreeNode();

        if ( rootNode.Attribute("url") != null )
        {
            tnode.Value = rootNode.Attribute("url").Value;
            //tnode.Text = rootNode.Attribute("url").Value;
            tnode.Text = getResourceValue(rootNode , rootNode.Attribute("url").Value);
            getTreeNode(rootNode , tnode);
            tv.Nodes.Add(tnode);
            return;

        }
        else if ( rootNode.Attribute("resourceKey") != null )
        {
            tnode.Value = rootNode.Attribute("resourceKey").Value;
            //tnode.Text = rootNode.Attribute("resourceKey").Value;
            tnode.Text = getResourceValue(rootNode , rootNode.Attribute("resourceKey").Value);
            getTreeNode(rootNode , tnode);
            tv.Nodes.Add(tnode);
            return;
        }
        else if ( rootNode.Attribute("title") != null )
        {
            tnode.Value = rootNode.Attribute("title").Value;
            tnode.Text = getResourceValue(rootNode , rootNode.Attribute("title").Value);
            //tnode.Text = rootNode.Attribute("title").Value;
            getTreeNode(rootNode , tnode);
            tv.Nodes.Add(tnode);
            return;
        }
        else
        {
            tnode.Text = "";
            tnode.Value = "";
            getTreeNode(rootNode , tnode);
            tv.Nodes.Add(tnode);
            return;
        }
    }

    private String getResourceValue(XElement node,string defaultValue)
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
                tnode.Text = getResourceValue(n, n.Attribute("url").Value);
                //tnode.Text = n.Attribute("url").Value;
                isSet = true;
            }
            else if (n.Attribute("resourceKey") != null && isSet ==false)
            {
                tnode.Value = n.Attribute("resourceKey").Value;
                //tnode.Text = n.Attribute("resourceKey").Value;
                tnode.Text = getResourceValue(n, n.Attribute("resourceKey").Value);
                isSet = true;
            }
            else if (n.Attribute("title") != null && isSet == false)
            {
                tnode.Value = n.Attribute("title").Value;
                //tnode.Text = n.Attribute("title").Value;
                tnode.Text = getResourceValue(n, n.Attribute("title").Value);
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
        gv.Rebind();

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

        var node = (from c in xml.Descendants()
                    where c.Name == @"{http://schemas.microsoft.com/AspNet/SiteMap-File-1.0}siteMapNode"
                    && (c.Attribute("url") != null && c.Attribute("url").Value == tv.SelectedNode.Value)
                    select c).FirstOrDefault();

        if ( node != null )
        {
            SiteMapSalaDr_REPO siteMapSalaDrRepo = new SiteMapSalaDr_REPO();
            SiteMapSalaDr obj = new SiteMapSalaDr();
            string url = node.Attribute("url").Value.Replace("~" , "");
            obj.SiteMapUrl = url;
            obj.SALADR_Code = dgCbx.SelectedValue;
            siteMapSalaDrRepo.Add(obj);
            siteMapSalaDrRepo.Save();
            siteMapSalaDrRepo.UpdateCache();
            gv.Rebind();
        }
        else
        {
            RadAjaxPanel1.Alert("找不到節點，或該節點非網頁路徑");
        }
    }
    protected void gv_NeedDataSource1(object sender, GridNeedDataSourceEventArgs e)
    {
        SiteMapSalaDr_REPO sRepo = new SiteMapSalaDr_REPO();
        gv.DataSource = (from c in sRepo.GetByUrl_Dlo(tv.SelectedValue) select new { c.Pid, c.SALADR_Code, c.DATAGROUP.GROUPNAME }).ToList();
    }
    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Del"))
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                int pid = Convert.ToInt32(item.GetDataKeyValue("Pid"));
                SiteMapSalaDr_REPO sRepo = new SiteMapSalaDr_REPO();
                SiteMapSalaDr obj= sRepo.GetByPk(pid);
                if ( obj != null )
                {
                    sRepo.Delete(obj);
                    sRepo.Save();
                    sRepo.UpdateCache();
                }
                gv.Rebind();
            }
        }
    }
    protected void btnUpdateCache_Click(object sender, EventArgs e)
    {
        SiteMapSalaDr_REPO sRepo = new SiteMapSalaDr_REPO();
        sRepo.UpdateCache();
    }
}