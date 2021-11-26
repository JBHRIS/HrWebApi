using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using BL;
using Telerik.Web.UI;

public partial class System_FileStructure : JBWebPage
{
    protected override void OnInit(EventArgs e)
    {
        if (!IsPostBack)
        {
        }

        CanCopy = true;
        base.OnInit(e);
    }

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
        Session[SessionName] = tv.GetAllNodes().ToList();
    }

    private void restoreTvNodes()
    {
        if (Session[SessionName] != null)
        {
            List<RadTreeNode> snapNodeList = Session[SessionName] as List<RadTreeNode>;
            List<RadTreeNode> nodeList = tv.GetAllNodes().ToList();

            foreach (RadTreeNode n in nodeList)
            {
                RadTreeNode node = (from c in snapNodeList where c.Value == n.Value select c).FirstOrDefault();
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
        cblRole.DataTextField = "Name";
        cblRole.DataValueField = "Code";
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
        FileStructure_Repo sfsRepo = new FileStructure_Repo();

        if (sourceNode.Equals(destNode) || sourceNode.IsAncestorOf(destNode))
        {
            return;
        }
        //sourceNode.Owner.Nodes.Remove(sourceNode);

        FileStructure destObj = sfsRepo.GetByKey(destNode.Value);
        FileStructure sourceObj = sfsRepo.GetByKey(sourceNode.Value);

        switch (dropPosition)
        {
            case RadTreeViewDropPosition.Over:
                // child
                if (!sourceNode.IsAncestorOf(destNode))
                {
                    sourceObj.sParentKey = destObj.Code;
                    sfsRepo.Update(sourceObj);
                    sfsRepo.Save();
                    updateCache();
                    //FileStructure_Repo.UpdateCache();
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
                //FileStructure_Repo.UpdateCache();
                break;

            case RadTreeViewDropPosition.Below:
                // sibling - below
                //destNode.InsertAfter(sourceNode);
                sourceObj.sParentKey = destObj.sParentKey;
                sourceObj.iOrder = destObj.iOrder + 1;
                sfsRepo.Update(sourceObj);
                sfsRepo.Save();
                updateCache();
                //FileStructure_Repo.UpdateCache();
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
        //changeMode(FormMode.View);
        changeMode(FormMode.Update);
    }

    private void loadCblRole(string Avalue)
    {
        FileStructureRole_Repo fsRoleRepo = new FileStructureRole_Repo();
        List<FileStructureRole> fsRoleList = fsRoleRepo.GetByFKey(Avalue);

        foreach (ListItem i in cblRole.Items)
        {
            if (fsRoleList.Any(p => p.RoleCode == i.Value))
                i.Selected = true;
            else
                i.Selected = false;
        }
    }

    private void loadData(string Avalue)
    {
        FileStructure_Repo fsRepo = new FileStructure_Repo();
        FileStructure obj = fsRepo.GetByKey(Avalue);
        if (obj != null)
        {
            tbKey.Text = obj.Code;
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
                FileStructure_Repo fsRepo = new FileStructure_Repo();
                FileStructure obj = fsRepo.GetByKey(tv.SelectedNode.Value);
                if (obj != null)
                {
                    obj.Code = tbKey.Text;
                    obj.sPath = tbPath.Text;
                    obj.sFileName = tbFileName.Text;
                    obj.sFileTitle = tbTitle.Text;
                    obj.sDescription = tbDesc.Text;
                    obj.sParentKey = tbParentKey.Text;
                    obj.iOrder = Convert.ToInt32(ntbOrder.Value);
                    obj.sIconPath = tbIconPath.Text;
                    obj.sIconName = tbIconName.Text;

                    if (obj.Code.Equals(obj.sParentKey))
                    {
                        Show("Key不能等於父項目");
                        return;
                    }

                    fsRepo.Update(obj);

                    FileStructureRole_Repo fsRoleRepo = new FileStructureRole_Repo(fsRepo.dc);

                    //該項目的所有子項目
                    List<FileStructure> fsList = fsRepo.GetAllChildByParent(obj.Code);

                    foreach (ListItem item in cblRole.Items)
                    {
                        FileStructureRole fsrObj = fsRoleRepo.GetByFKeyRoleKey(tbKey.Text, item.Value);
                        if (item.Selected)
                        {
                            if (fsrObj == null)
                            {
                                fsrObj = new FileStructureRole();
                                fsrObj.FileStructureKey = tbKey.Text;
                                fsrObj.RoleCode = item.Value;
                                fsRoleRepo.Add(fsrObj);

                                //順便新增子項目
                                foreach (var f in fsList)
                                {
                                    FileStructureRole fsr2Obj = fsRoleRepo.GetByFKeyRoleKey(f.Code, item.Value);
                                    if (fsr2Obj == null)
                                    {
                                        fsr2Obj = new FileStructureRole();
                                        fsr2Obj.FileStructureKey = f.Code;
                                        fsr2Obj.RoleCode = item.Value;
                                        fsRoleRepo.Add(fsr2Obj);
                                    }
                                }
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

                                //順便刪除子項目
                                foreach (var f in fsList)
                                {
                                    FileStructureRole fsr2Obj = fsRoleRepo.GetByFKeyRoleKey(f.Code, item.Value);
                                    if (fsr2Obj != null)
                                    {
                                        fsRoleRepo.Delete(fsr2Obj);
                                    }
                                }
                            }
                        }
                    }

                    fsRepo.Save();
                    Show("Saved");
                }
            }
        }
        else if (fm == FormMode.Insert)
        {
            FileStructure_Repo fsRepo = new FileStructure_Repo();
            FileStructure obj = new FileStructure();
            if (obj != null)
            {
                obj.Code = tbKey.Text;
                obj.sPath = tbPath.Text;
                obj.sFileName = tbFileName.Text;
                obj.sFileTitle = tbTitle.Text;
                obj.sDescription = tbDesc.Text;
                obj.sParentKey = tbParentKey.Text;
                obj.iOrder = Convert.ToInt32(ntbOrder.Value);
                obj.sIconPath = tbIconPath.Text;
                obj.sIconName = tbIconName.Text;
                obj.dKeyDate = DateTime.Now;

                if (obj.Code.Equals(obj.sParentKey))
                {
                    Show("Key不能等於父項目");
                    return;
                }

                fsRepo.Add(obj);

                FileStructureRole_Repo fsRoleRepo = new FileStructureRole_Repo(fsRepo.dc);

                foreach (ListItem item in cblRole.Items)
                {
                    if (item.Selected)
                    {
                        FileStructureRole fsrObj = new FileStructureRole();
                        fsrObj.FileStructureKey = tbKey.Text;
                        fsrObj.RoleCode = item.Value;
                        fsRoleRepo.Add(fsrObj);
                    }
                }

                fsRepo.Save();
                Show("Saved");
            }
        }

        updateCache();
        bindTv();
    }

    private void updateCache()
    {
        FileStructure_Repo.UpdateCache();
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
            tbKey.Enabled = true;
            if (tv.SelectedNode != null)
            {
                FileStructure_Repo fsRepo = new FileStructure_Repo();
                FileStructure obj = fsRepo.GetByKey(tv.SelectedNode.Value);
                if (obj != null)
                {
                    clearData();
                    tbParentKey.Text = obj.Code;
                }
            }
        }
        else if (FormMode.Update == Avalue)
        {
            if (tv.SelectedNode != null)
            {
                tbKey.Enabled = false;
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