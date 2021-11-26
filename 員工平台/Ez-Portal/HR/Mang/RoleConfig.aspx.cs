using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Telerik.Web.UI;
using BL;

public partial class HR_Mang_RoleConfig : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindCbDataGroup();
        }
    }

    private void bindCbDataGroup()
    {
        DATAGROUP_REPO dpRepo = new DATAGROUP_REPO();
        cbDataGroup.DataSource= dpRepo.GetAll();
        cbDataGroup.DataBind();
    }

    private void clearData()
    {
        tbRole.Text = "";
        tbValue.Text = "";
    }

    public class RoleConfig
    {
        public string Value { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }
    }
    protected void gv_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        String confPath = Server.MapPath(@"~/roles.config");

        XDocument xml = XDocument.Load(confPath);
        var roles = xml.Element("roles");

        List<RoleConfig> testList = new List<RoleConfig>();
        foreach (var r in roles.Elements())
        {
            RoleConfig t = new RoleConfig();
            t.Value = r.Value;
            t.Role = r.Attribute("role").Value;
            t.Type = r.Attribute("type").Value;
            testList.Add(t);
        }
        gv.DataSource = testList;
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        String confPath = Server.MapPath(@"~/roles.config");
        XDocument xml = XDocument.Load(confPath);
        var roles = xml.Element("roles");

        var lastNode = roles.Elements().LastOrDefault();
        XElement element = new XElement("add");

        if (cbType.SelectedValue.Equals("資料群組"))
            element.Value = cbDataGroup.SelectedValue;
        else
            element.Value = tbValue.Text;

        element.SetAttributeValue("role", tbRole.Text);
        element.SetAttributeValue("type", cbType.SelectedValue);
        lastNode.AddAfterSelf(element);
        xml.Save((confPath));
        gv.Rebind();
        clearData();
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
            gv.Rebind();
        }
    }
    protected void cbType_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (e.Value.Equals("資料群組"))
        {
            tbValue.Visible = false;
            cbDataGroup.Visible = true;
        }
        else
        {
            tbValue.Visible = true;
            cbDataGroup.Visible = false;
        }
    }
}