using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class eTraining_Admin_trTeachingMaterialDetailEdit : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblMaterialAutoKey.Text= Request.QueryString["iAutoKey"].ToString();
            //SiteHelper util = new SiteHelper();
            //util.setTvCourseCat(tvCate);
            loadTv();
            tv.CollapseAllNodes();
            if (tv.Nodes.Count > 0)
            {
                tv.Nodes[0].Selected = true;
                cbxMethod.DataBind();
                cbxResources.DataBind();
                tv_NodeClick(this, new Telerik.Web.UI.RadTreeNodeEventArgs(tv.Nodes[0]));
            }            

        }

    }
    protected void tv_NodeClick(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
    {
        lblMsg.Text = "";
        lblPNode.Text = "";
        lblSelectedNode.Text = e.Node.Value;
        pnlNodes.Visible = true;
        loadEdit();
    }
    protected void RadAjaxManager1_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
    {
        if (e.Argument == "RebindTV")
        {
            tv.Nodes.Clear();
            SiteHelper util = new SiteHelper();
            util.SetTvCourseCat(tv);
            tv.ExpandAllNodes();
        }
    }

    private void setEditDefault()
    {
        tbOutline.Text = "";
        ntbMinsTime.Text = "0";
        ntbOrder.Text = "1";
        tbNote.Text = "";
        lblMsg.Text = "";
        lblPNode.Text = "";

        cbxMethod.DataBind();
        cbxResources.DataBind();
        cbxMethod.ClearSelection();
        cbxResources.ClearSelection();

    }

    private void loadEdit()
    {
        var data = (from c in dcTraining.trTeachingMaterialDetail
                    where c.iAutoKey == Convert.ToInt32(lblSelectedNode.Text)
                    select c).FirstOrDefault();

        if (data != null)
        {
            ntbOrder.Text = data.iOrder.ToString();
            ntbMinsTime.Text = data.iTimeMin.ToString();
            tbNote.Text = data.sNote;
            tbOutline.Text = data.sOutline;
            cbxMethod.DataBind();
            cbxResources.DataBind();

            //載入comboBox的內容
            var method = from c in dcTraining.trTeachingMaterialDetail_TeachingMethod
                         where c.MaterialDetailAutoKey == Convert.ToInt32(lblSelectedNode.Text)
                         select c;

            cbxMethod.ClearSelection();

            foreach (var m in method)
            {
                foreach (RadComboBoxItem item in cbxMethod.Items)
            {
                if (item.Value == m.trTeachingMethod_sCode)
                {                 
                    item.Checked = true;
                }                                   
            }
        }

        var resource = from c in dcTraining.trTeachingMaterialDetail_TeachingResource
                       where c.MaterialDetailAutoKey == Convert.ToInt32(lblSelectedNode.Text)
                       select c;

        cbxResources.ClearSelection();

        foreach (var r in resource)
        {
            foreach (RadComboBoxItem item in cbxResources.Items)
            {
                if (item.Value == r.trTeachingResourceCode)
                {         
                    item.Checked = true;
                }
            }
        }
       }
    }


    private void loadTv()
    {
        var rootNodes = (from c in dcTraining.trTeachingMaterialDetail
                         where
                             c.MaterialAutoKey == Convert.ToInt32(lblMaterialAutoKey.Text) &&
                             c.ParentiAutoKey == 0  orderby c.iOrder ascending
                             //c.ParentiAutoKey == 0 orderby c.iOrder descending
                         select c).ToList();

        tv.Nodes.Clear();

        foreach (var i in rootNodes)
        {
            RadTreeNode node = new RadTreeNode();
            if (i.sOutline.Length > 10)
            {
                node.Text = i.sOutline.Substring(0, 10)+"....";
            }
            else
            {
                node.Text = i.sOutline;
            }
            node.Text = node.Text.Replace(System.Environment.NewLine,"<br>");
            node.Value = i.iAutoKey.ToString();
            tv.Nodes.Add(getNode(node));
        }

        tv.ExpandAllNodes();
    }

    private Telerik.Web.UI.RadTreeNode getNode(Telerik.Web.UI.RadTreeNode node)
    {
        var list = from c in dcTraining.trTeachingMaterialDetail
                   where c.MaterialAutoKey == Convert.ToInt32(lblMaterialAutoKey.Text) &&
                   c.ParentiAutoKey == Convert.ToInt32(node.Value)
                   orderby c.iOrder ascending
                   select c;

        foreach (var iterator in list)
        {
            Telerik.Web.UI.RadTreeNode tmp_node = new Telerik.Web.UI.RadTreeNode();
            tmp_node.Value = iterator.iAutoKey.ToString();
            tmp_node.Text = iterator.sOutline;
            tmp_node.Text= tmp_node.Text.Replace(System.Environment.NewLine, "<br>");

            node.Nodes.Add(getNode(tmp_node));
        }

        return node;
    }


    protected void btnDelNode_Click(object sender, EventArgs e)
    {
        int selectedValue = Convert.ToInt32(lblSelectedNode.Text);

        var list = (from c in dcTraining.trTeachingMaterialDetail
                    where c.ParentiAutoKey == selectedValue
                    select c).FirstOrDefault();

        if (list != null)
        {
            lblMsg.Text = "還有子類，無法刪除";
            return;
        }
        else
        {
            var data = (from c in dcTraining.trTeachingMaterialDetail
                        where c.iAutoKey == selectedValue
                        select c).FirstOrDefault();

            if (data != null)
            {
                var method = from c in dcTraining.trTeachingMaterialDetail_TeachingMethod
                             where c.MaterialDetailAutoKey == selectedValue
                             select c;

                var resource = from c in dcTraining.trTeachingMaterialDetail_TeachingResource
                               where c.MaterialDetailAutoKey == selectedValue
                               select c;

                dcTraining.trTeachingMaterialDetail_TeachingMethod.DeleteAllOnSubmit(method);
                dcTraining.trTeachingMaterialDetail_TeachingResource.DeleteAllOnSubmit(resource);
                dcTraining.trTeachingMaterialDetail.DeleteOnSubmit(data);
                dcTraining.SubmitChanges();

                loadTv();
            }

        }


    //    //判斷是否有子類別
    //var cats = (from c in dcTraining.trCategory
    //                where c.sParentCode == lblCategory.Text
    //                select c).ToList();

    //    if (cats.Count > 0)
    //    {
    //        Show("此類別還有子類別，無法刪除");
    //        return;
    //    }



    //    var list = from c in dcTraining.trCategory
    //               where c.sCode == lblCategory.Text
    //               select c;

    //    var data = list.FirstOrDefault();

    //    if (data != null)
    //    {
    //        dcTraining.trCategory.DeleteOnSubmit(data);
    //        dcTraining.SubmitChanges();
    //    }

    //    SiteHelper util = new SiteHelper();
    //   util.setTvCourseCat(tvCate);
    //    tvCate.ExpandAllNodes();
    //    tvCate.Nodes[0].Selected = true;
    //    tvCate_NodeClick(this, new Telerik.Web.UI.RadTreeNodeEventArgs(tvCate.Nodes[0]));
    }

    protected void RadButton1_Click(object sender, EventArgs e)
    {
        SiteHelper util = new SiteHelper();
        util.SetExpand(tv,btnExpand);
        
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

    //private bool HasSelectedNode()
    //{
    //    if (tv.SelectedNode == null)
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        return true;
    //    }
    //}

    protected void btnAddRootNode_Click(object sender, EventArgs e)
    {
        //lblSelectedNode.Text = "0";

        setEditDefault();
        lblPNode.Text = "0";
        pnlNodes.Visible = true ;
    }

    protected void btnEditNode_Click(object sender, EventArgs e)
    {
        pnlNodes.Visible = true;
        loadEdit();

    }


    protected void btnAddNode_Click(object sender, EventArgs e)
    {
        if (tv.SelectedNode == null)
        {
            lblMsg.Text = "末選擇節點";
            return;
        }

        //只能增加兩層
        if (tv.SelectedNode.ParentNode != null)
        {
            lblMsg.Text = "只能增加兩層";
            return;
        }

        setEditDefault();
        lblPNode.Text = tv.SelectedValue;
        lblSelectedNode.Text = tv.SelectedValue;
        pnlNodes.Visible = true;        
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (lblPNode.Text.Trim().Length > 0)
        {
            addRecord();
        }
        else
        {
            updateRecord();
        }

        pnlNodes.Visible = false;
        setEditDefault();
        loadTv();
    }

    private void updateRecord()
    {
        var data = (from c in dcTraining.trTeachingMaterialDetail
                    where
                        c.iAutoKey == Convert.ToInt32(lblSelectedNode.Text)
                    select c).FirstOrDefault();

        if (data != null)
        {
            data.iOrder = Convert.ToInt32(ntbOrder.Text);

            data.iTimeMin = Convert.ToInt32(ntbMinsTime.Text);
            data.sOutline = tbOutline.Text;
            data.sNote = tbNote.Text;
            data.dKeyDate = DateTime.Now;
            data.sKeyMan = User.Identity.Name;

            var method = from c in dcTraining.trTeachingMaterialDetail_TeachingMethod
                         where c.MaterialDetailAutoKey == Convert.ToInt32(lblSelectedNode.Text)
                         select c;

            dcTraining.trTeachingMaterialDetail_TeachingMethod.DeleteAllOnSubmit(method);


            var resource = from c in dcTraining.trTeachingMaterialDetail_TeachingResource
                           where c.MaterialDetailAutoKey == Convert.ToInt32(lblSelectedNode.Text)
                           select c;

            dcTraining.trTeachingMaterialDetail_TeachingResource.DeleteAllOnSubmit(resource);

            dcTraining.SubmitChanges();


            foreach (RadComboBoxItem item in cbxMethod.CheckedItems)
            {
                trTeachingMaterialDetail_TeachingMethod objM = new trTeachingMaterialDetail_TeachingMethod();
                objM.MaterialDetailAutoKey = data.iAutoKey;
                objM.trTeachingMethod_sCode = item.Value;
                dcTraining.trTeachingMaterialDetail_TeachingMethod.InsertOnSubmit(objM);
            }

            foreach (RadComboBoxItem item in cbxResources.CheckedItems)
            {
                trTeachingMaterialDetail_TeachingResource objR = new trTeachingMaterialDetail_TeachingResource();
                objR.MaterialDetailAutoKey = data.iAutoKey;
                objR.trTeachingResourceCode = item.Value;
                dcTraining.trTeachingMaterialDetail_TeachingResource.InsertOnSubmit(objR);
            }

            dcTraining.SubmitChanges();
        }
    }


    private void addRecord()
    {
        trTeachingMaterialDetail obj = new trTeachingMaterialDetail();

        obj.MaterialAutoKey = Convert.ToInt32(lblMaterialAutoKey.Text);
        obj.ParentiAutoKey = Convert.ToInt32(lblPNode.Text);
        obj.iOrder = Convert.ToInt32(ntbOrder.Text);
        obj.iTimeMin = Convert.ToInt32(ntbMinsTime.Text);
        obj.sOutline = tbOutline.Text;
        obj.sNote = tbNote.Text;
        obj.dKeyDate = DateTime.Now;
        obj.sKeyMan = User.Identity.Name;

        dcTraining.trTeachingMaterialDetail.InsertOnSubmit(obj);
        dcTraining.SubmitChanges();

        foreach (RadComboBoxItem item in cbxMethod.CheckedItems)
        {
            trTeachingMaterialDetail_TeachingMethod objM = new trTeachingMaterialDetail_TeachingMethod();
            objM.MaterialDetailAutoKey = obj.iAutoKey;
            objM.trTeachingMethod_sCode = item.Value;
            dcTraining.trTeachingMaterialDetail_TeachingMethod.InsertOnSubmit(objM);
        }

        foreach (RadComboBoxItem item in cbxResources.CheckedItems)
        {
            trTeachingMaterialDetail_TeachingResource objR = new trTeachingMaterialDetail_TeachingResource();
            objR.MaterialDetailAutoKey = obj.iAutoKey;
            objR.trTeachingResourceCode = item.Value;
            dcTraining.trTeachingMaterialDetail_TeachingResource.InsertOnSubmit(objR);
        }

        dcTraining.SubmitChanges();

    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CancelEdit();", true);
    }
}