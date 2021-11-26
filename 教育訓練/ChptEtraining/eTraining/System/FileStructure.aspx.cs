using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
using Telerik.Web.UI;
using System.Data.Linq;

public partial class eTraining_System_FileStructure : JBWebPage
{
    const string TREE_NODE_SNAP ="eTraining_System_FileStructure";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindTv();
            InitCblRole();
            changeMode(FormMode.View);
        }
    }

    private void snapTvNodes()
    {
        Session[TREE_NODE_SNAP]= tv.GetAllNodes().ToList();
    }

    private void restoreTvNodes()
    {
        if (Session[TREE_NODE_SNAP] != null)
        {
            List<RadTreeNode> snapNodeList = Session[TREE_NODE_SNAP] as List<RadTreeNode>;
            List<RadTreeNode> nodeList = tv.GetAllNodes().ToList();

            foreach (RadTreeNode n in nodeList)
            {
                RadTreeNode node = (from c in snapNodeList where c.Value==n.Value select c).FirstOrDefault();
                if (node != null)
                {
                    n.Expanded = node.Expanded;
                }
            }
        }
    }

    private void bindTv()
    {
        SiteHelper siteHelper = new SiteHelper();
        siteHelper.BuildAdminMainTv(tv);
        restoreTvNodes();
    }

    private void InitCblRole()
    {
        sysRole_Repo roleRepo = new sysRole_Repo();
        List<sysRole> roleList = roleRepo.GetAll();
        cblRole.DataSource = roleList;
        cblRole.DataTextField = "sName";
        cblRole.DataValueField = "iKey";
        cblRole.DataBind();
    }


    protected void btnUpdateFileStructureCache_Click(object sender, EventArgs e)
    {
        updateCache();
    }
    protected void tv_NodeDrop(object sender, RadTreeNodeDragDropEventArgs e)
    {
        RadTreeNode sourceNode = e.SourceDragNode;
        RadTreeNode destNode = e.DestDragNode;
        RadTreeViewDropPosition dropPosition = e.DropPosition;

        if (destNode != null) //drag&drop is performed between trees
        {
            if (sourceNode.TreeView.SelectedNodes.Count <= 1)
            {
                PerformDragAndDrop(dropPosition, sourceNode, destNode);
            }
        }
    }


    private void PerformDragAndDrop(RadTreeViewDropPosition dropPosition, RadTreeNode sourceNode, RadTreeNode destNode)
    {
        sysFileStructure_Repo sfsRepo = new sysFileStructure_Repo();

        if (sourceNode.Equals(destNode) || sourceNode.IsAncestorOf(destNode))
        {
            return;
        }
        //sourceNode.Owner.Nodes.Remove(sourceNode);

        sysFileStructure destObj = sfsRepo.GetByKey(destNode.Value);
        sysFileStructure sourceObj = sfsRepo.GetByKey(sourceNode.Value);

        switch (dropPosition)
        {
            case RadTreeViewDropPosition.Over:
                // child
                if (!sourceNode.IsAncestorOf(destNode))
                {
                    sourceObj.sParentKey = destObj.sKey;
                    sfsRepo.Update(sourceObj);
                    sfsRepo.Save();
                    updateCache();
                    //sysFileStructure_Repo.UpdateCache();
                    //destNode.Nodes.Add(sourceNode);
                }
                break;

            case RadTreeViewDropPosition.Above:
                // sibling - above                         
                //destNode.InsertBefore(sourceNode);
                sourceObj.sParentKey = destObj.sParentKey;
                sourceObj.iOrder = destObj.iOrder - 1;
                sfsRepo.Update(sourceObj);
                sfsRepo.Save();
                updateCache();
                //sysFileStructure_Repo.UpdateCache();
                break;

            case RadTreeViewDropPosition.Below:
                // sibling - below
                //destNode.InsertAfter(sourceNode);
                sourceObj.sParentKey = destObj.sParentKey;
                sourceObj.iOrder = destObj.iOrder + 1;
                sfsRepo.Update(sourceObj);
                sfsRepo.Save();
                updateCache();
                //sysFileStructure_Repo.UpdateCache();
                break;
        }

        bindTv();
    }
    protected void tv_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        if (tv.SelectedNode != null)
        {
            loadData(tv.SelectedNode.Value);
            loadCblRole(tv.SelectedNode.Value);
        }
        changeMode(FormMode.View);
    }

    private void loadCblRole(string Avalue)
    {
        FileStructureRole_Repo fsRoleRepo = new FileStructureRole_Repo();
        List<FileStructureRole> fsRoleList = fsRoleRepo.GetByFKey(Avalue);

        foreach (ListItem i in cblRole.Items)
        {
            if (fsRoleList.Any(p => p.RoleKey == Convert.ToInt32(i.Value)))
                i.Selected = true;
            else
                i.Selected = false;
        }
    }

    private void loadData(string Avalue)
    {
        sysFileStructure_Repo fsRepo = new sysFileStructure_Repo();
        sysFileStructure obj = fsRepo.GetByKey(Avalue);
        if (obj != null)
        {
            tbKey.Text = obj.sKey;
            tbCategory.Text = obj.sCat;
            tbPath.Text = obj.sPath;
            tbFileName.Text = obj.sFileName;
            tbTitle.Text = obj.sFileTitle;
            tbDesc.Text = obj.sDescription;
            tbParentKey.Text = obj.sParentKey;
            ntbOrder.Value = obj.iOrder;
            tbIconPath.Text = obj.sIconPath;
            tbIconName.Text = obj.sIconName;
        }
    }


    private void clearData()
    {
        tbKey.Text = "";
        tbCategory.Text = "";
        tbPath.Text = "";
        tbFileName.Text = "";
        tbTitle.Text = "";
        tbDesc.Text = "";
        tbParentKey.Text = "";
        ntbOrder.Value = 0;
        tbIconPath.Text = "";
        tbIconName.Text = "";

        foreach (ListItem i in cblRole.Items)
        {
            i.Selected = false;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        changeMode(FormMode.Insert);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        changeMode(FormMode.Update);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        changeMode(FormMode.Cancel);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        FormMode fm = (FormMode)Enum.Parse(typeof(FormMode), lblMode.Text);
        if (fm == FormMode.Update)
        {
            if (tv.SelectedNode != null)
            {
                sysFileStructure_Repo fsRepo = new sysFileStructure_Repo();
                sysFileStructure obj = fsRepo.GetByKey(tv.SelectedNode.Value);
                if (obj != null)
                {
                    obj.sKey = tbKey.Text;
                    obj.sCat = tbCategory.Text;
                    obj.sPath = tbPath.Text;
                    obj.sFileName = tbFileName.Text;
                    obj.sFileTitle = tbTitle.Text;
                    obj.sDescription = tbDesc.Text;
                    obj.sParentKey = tbParentKey.Text;
                    obj.iOrder = Convert.ToInt32(ntbOrder.Value);
                    obj.sIconPath = tbIconPath.Text;
                    obj.sIconName = tbIconName.Text;

                    fsRepo.Update(obj);

                    FileStructureRole_Repo fsRoleRepo = new FileStructureRole_Repo(fsRepo.dc);

                    foreach (ListItem item in cblRole.Items)
                    {
                        FileStructureRole fsrObj = fsRoleRepo.GetByFKeyRoleKey(tv.SelectedNode.Value, Convert.ToInt32(item.Value));
                        if (item.Selected)
                        {
                            if (fsrObj == null)
                            {
                                fsrObj = new FileStructureRole();
                                fsrObj.FileStructureKey = tv.SelectedNode.Value;
                                fsrObj.RoleKey = Convert.ToInt32(item.Value);
                                fsRoleRepo.Add(fsrObj);
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (fsrObj == null)
                            {
                            }
                            else
                            {
                                fsRoleRepo.Delete(fsrObj);
                            }
                        }
                    }

                    fsRepo.Save();
                    
                }
            }


        }
        else if (fm == FormMode.Insert)
        {
            sysFileStructure_Repo fsRepo = new sysFileStructure_Repo();
            sysFileStructure obj = new sysFileStructure();
            if (obj != null)
            {
                obj.sKey = tbKey.Text;
                obj.sCat = tbCategory.Text;
                obj.sPath = tbPath.Text;
                obj.sFileName = tbFileName.Text;
                obj.sFileTitle = tbTitle.Text;
                obj.sDescription = tbDesc.Text;
                obj.sParentKey = tbParentKey.Text;
                obj.iOrder = Convert.ToInt32(ntbOrder.Value);
                obj.sIconPath = tbIconPath.Text;
                obj.sIconName = tbIconName.Text;
                obj.dDateA = DateTime.Now.Date;
                obj.dDateD = DateTime.MaxValue;
                obj.dKeyDate = DateTime.Now;

                fsRepo.Add(obj);

                FileStructureRole_Repo fsRoleRepo = new FileStructureRole_Repo(fsRepo.dc);

                foreach (ListItem item in cblRole.Items)
                {
                    if (item.Selected)
                    {
                        FileStructureRole fsrObj = new FileStructureRole();
                        fsrObj.FileStructureKey = tv.SelectedNode.Value;
                        fsrObj.RoleKey = Convert.ToInt32(item.Value);
                        fsRoleRepo.Add(fsrObj);
                    }
                }

                fsRepo.Save();
            }
        }

        updateCache();
        bindTv();
    }

    private void updateCache()
    {
        sysFileStructure_Repo.UpdateCache();
        FileStructureRole_Repo.UpdateCache();
        snapTvNodes();
    }


    private void changeMode(FormMode Avalue)
    {
        lblMode.Text = Avalue.ToString();
        if (FormMode.Insert == Avalue)
        {
            pnlAddUpdate.Visible = false;
            pnlSave.Visible = true;

            if (tv.SelectedNode != null)
            {
                sysFileStructure_Repo fsRepo = new sysFileStructure_Repo();
                sysFileStructure obj = fsRepo.GetByKey(tv.SelectedNode.Value);
                if (obj != null)
                {
                    clearData();
                    tbParentKey.Text = obj.sKey;
                }
            }
        }
        else if (FormMode.Update == Avalue)
        {
            if (tv.SelectedNode != null)
            {
                loadData(tv.SelectedValue);
                loadCblRole(tv.SelectedValue);
                lblMode.Text = FormMode.Update.ToString();
                pnlAddUpdate.Visible = false;
                pnlSave.Visible = true;
            }
        }
        else if (FormMode.Cancel == Avalue)
        {
            pnlAddUpdate.Visible = true;
            pnlSave.Visible = false;

            tv.UnselectAllNodes();
            clearData();
        }
        else if (FormMode.View == Avalue)
        {
            pnlAddUpdate.Visible = true;
            pnlSave.Visible = false;
        }
    }
}