using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BL;

public partial class Templet_EmpDeptQS:JUserControl , IEmpDeptQS
{
    public delegate void SelectedEventHandler(UC_QS_SelectedObj e);
    public event SelectedEventHandler sHandler;
    public bool SelectSingleDeptOnly
    {
        get;
        set;
    }

    protected void Page_Load(object sender , EventArgs e)
    {
        //if ( !IsPostBack )
        //    tbQuickSearch.Focus();
    }

    public void InitMenu(EnumUC_QS_InitType type)
    {
        if ( type == EnumUC_QS_InitType.HR )
        {
            SiteHelper.SetAllDeptTree(tvDept);
        }
        else if ( type == EnumUC_QS_InitType.Coordinator )
        {
            SiteHelper sh = new SiteHelper();
            sh.InitManagerDeptTreeView(tvDept , Juser.CoordinatorDeptRootRadNodeList);
            btnShowDeptTree.Checked = true;
            btnShowDeptTree_Click(this , null);
        }
        else
        {
            SiteHelper sh = new SiteHelper();
            sh.InitManagerDeptTreeView(tvDept , Juser.ManageDeptRootRadNodeList);
            btnShowDeptTree.Checked = true;
            btnShowDeptTree_Click(this , null);
        }

        if ( SelectSingleDeptOnly )
            tvDept.CheckBoxes = false;
    }

    /// <summary>
    /// 傳99是選全部，傳0是只能選員工，傳1是只能選部門
    /// </summary>
    /// <param name="value"></param>
    public void InitCat(int value , bool disableItem = false)
    {
        if ( value == 0 )
        {
            rblViewType.SelectedIndex = 0;

            if ( disableItem )
                rblViewType.Items[1].Enabled = false;
        }
        else if ( value == 1 )
        {
            rblViewType.SelectedIndex = 1;

            if ( disableItem )
                rblViewType.Items[0].Enabled = false;
        }

        rblViewType_SelectedIndexChanged(this , null);
    }

    protected void lvEmp_NeedDataSource(object sender , Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
    {
        if ( tvDept.SelectedNode == null )
            return;

        BASE_REPO baseRepo = new BASE_REPO();
        List<BASE> baseList = baseRepo.GetHiredEmpByDept(tvDept.SelectedValue);
        lvEmp.DataSource = baseList;
    }
    protected void lvEmp_ItemCommand(object sender , Telerik.Web.UI.RadListViewCommandEventArgs e)
    {
        if ( e.CommandName.Equals("Selected") )
        {
            Label lbObj = e.ListViewItem.FindControl("lbNobr") as Label;
            RadButton btnObj = e.ListViewItem.FindControl("btnNameC") as RadButton;
            setSelectedEmp(btnObj.Text , lbObj.Text);
        }
    }

    private void setSelectedEmp(string name , string nobr)
    {
        lbSelectedNobr.Text = nobr;
        lbSelectedEmpName.Text = name;
        tbQuickSearch.Text = name;
        TrigSelected();
    }

    private void TrigSelected()
    {
        if ( sHandler != null )
        {
            IEmpDeptQS iObj = this as IEmpDeptQS;
            if ( iObj != null )
            {
                sHandler(iObj.GetSelectedObj());
            }
        }
    }

    protected void btnSearch_Click(object sender , EventArgs e)
    {
        if ( rblViewType.Items[0].Enabled )
            rblViewType.SelectedIndex = 0;

        List<RadTreeNode> nodeList = tvDept.GetAllNodes().ToList();

        if ( tbQuickSearch.Text.Trim().Length >= 2 )
        {
            BASE_REPO baseRepo = new BASE_REPO();
            List<BASE> baseList = new List<BASE>();
            if ( cbIsQuickSearchAdvanced.Checked )
                baseList = baseRepo.GetHiredEmpBySeachKeyExt_DLO(tbQuickSearch.Text.Trim() , nodeList.Select(p => p.Value).ToList());
            else
                baseList = baseRepo.GetHiredEmpBySeachKey_DLO(tbQuickSearch.Text.Trim() , nodeList.Select(p => p.Value).ToList());
            gvQsEmp.DataSource = (from c in baseList
                                  select new
                                  {
                                      Nobr = c.NOBR ,
                                      Name = c.NAME_C ,
                                      DeptName = c.BASETTS[0].DEPT1.D_NAME ,
                                      JobName = c.BASETTS[0].JOB1.JOB_NAME ,
                                      EmpName = c.NAME_C
                                  }).ToList();
            gvQsEmp.DataBind();

            lvQS_Dept.Visible = false;
            gvQsEmp.Visible = true;

            if ( gvQsEmp.Items.Count > 0 )
            {
                gvQsEmp.Items[0].Selected = true;
                gvQsEmp_SelectedIndexChanged(this , null);
            }


        }
    }
    protected void lvQS_Dept_NeedDataSource(object sender , RadListViewNeedDataSourceEventArgs e)
    {
    }
    protected void lvQS_Dept_ItemCommand(object sender , RadListViewCommandEventArgs e)
    {
        if ( e.CommandName.Equals("Selected") )
        {
            Label lbObj = e.ListViewItem.FindControl("lbQS_DeptCode") as Label;
            RadButton btnObj = e.ListViewItem.FindControl("btnQS_Dept") as RadButton;
            lbSelectedDept.Text = btnObj.Text;
            lbSelectedDeptCode.Text = lbObj.Text;

            RadTreeNode node = tvDept.FindNodeByValue(lbSelectedDeptCode.Text);
            if ( node != null )
            {
                node.Checked = true;
            }

            TrigSelected();
        }
    }

    protected void lvQS_Emp_ItemCommand(object sender , RadListViewCommandEventArgs e)
    {
        if ( e.CommandName.Equals("Selected") )
        {
            Label lbObj = e.ListViewItem.FindControl("lbQS_Nobr") as Label;
            RadButton btnObj = e.ListViewItem.FindControl("btnQS_Emp") as RadButton;

            setSelectedEmp(btnObj.Text , lbObj.Text);
        }
    }
    protected void btnClear_Click(object sender , EventArgs e)
    {
        tbQuickSearch.Text = "";
        lvQS_Dept.Visible = false;
        //lvQS_Emp.Visible = false;
        gvQsEmp.Visible = false;
        tbQuickSearch.Focus();
        //clearQuickSearchData();
    }

    private void clearQuickSearchData()
    {
        //lvQS_Dept.DataSource = null;
        //lvQS_Dept.DataBind();
    }

    void IEmpDeptQS.InitUC_Dept(EnumUC_QS_InitType type)
    {
        InitMenu(type);
    }



    UC_QS_SelectedObj IEmpDeptQS.GetSelectedObj()
    {
        UC_QS_SelectedObj obj = null;
        //員工
        if ( rblViewType.SelectedValue.Equals("0") )
        {
            if ( lbSelectedNobr.Text.Trim().Length > 0 )
            {
                obj = new UC_QS_SelectedObj();
                obj.SelectedType = EnumUC_QS_SelectedType.Emp;
                obj.Key = lbSelectedNobr.Text;
                obj.IsSingleDept = false;
            }
        }
        //部門
        else if ( rblViewType.SelectedValue.Equals("1") )
        {
            List<RadTreeNode> nodeList = tvDept.CheckedNodes.ToList();

            if ( SelectSingleDeptOnly )
            {
                obj = new UC_QS_SelectedObj();
                obj.SelectedType = EnumUC_QS_SelectedType.Dept;
                obj.DeptList = new List<string>();
                obj.DeptList.Add(tvDept.SelectedValue);
                obj.IsSingleDept = true;
            }
            else
            {
                obj = new UC_QS_SelectedObj();
                obj.SelectedType = EnumUC_QS_SelectedType.Dept;
                obj.DeptList = (from c in nodeList
                                select c.Value).ToList();
                if ( tvDept.SelectedNode != null )
                {
                    if ( !obj.DeptList.Contains(tvDept.SelectedNode.Value) )
                        obj.DeptList.Add(tvDept.SelectedNode.Value);
                }
                obj.IsSingleDept = false;
            }
        }
        return obj;
    }
    protected void btnShowDeptTree_Click(object sender , EventArgs e)
    {
        if ( btnShowDeptTree.Checked )
        {
            tvDept.Visible = true;
        }
        else
            tvDept.Visible = false;
    }
    protected void rblViewType_SelectedIndexChanged(object sender , EventArgs e)
    {
        lvQS_Dept.Visible = false;
        gvQsEmp.Visible = false;

        if ( rblViewType.SelectedValue.Equals("0") )
        {
            tvDept.CheckBoxes = false;
            pnlSelectedEmp.Visible = true;
        }
        else
        {
            if ( !SelectSingleDeptOnly )
            {
                tvDept.CheckBoxes = true;
                tvDept.CheckChildNodes = true;
            }
            pnlSelectedEmp.Visible = false;
        }
    }
    protected void tvDept_NodeClick(object sender , RadTreeNodeEventArgs e)
    {
        lbSelectedDept.Text = e.Node.Text;
        lbSelectedDeptCode.Text = e.Node.Value;
        lvEmp.Rebind();

        if ( tvDept.CheckBoxes )
        {
            e.Node.Checked = true;
        }

        if ( rblViewType.SelectedValue.Equals("1") )
            TrigSelected();
    }

    #region IEmpDeptQS 成員


    void IEmpDeptQS.InitUC_Cat(int value)
    {
        InitCat(value);
    }

    #endregion
    protected void gvQsEmp_SelectedIndexChanged(object sender , EventArgs e)
    {
        if ( gvQsEmp.SelectedItems.Count > 0 )
        {
            GridDataItem item = gvQsEmp.SelectedItems[0] as GridDataItem;
            setSelectedEmp(item["EmpName"].Text , item["Nobr"].Text);
        }
        if ( gvQsEmp.Items.Count == 1 )
        {
            gvQsEmp.Visible = false;
        }

    }
    protected void gvQsEmp_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
    }
    protected void gvQsEmp_ItemCommand(object sender , GridCommandEventArgs e)
    {
        if ( e.CommandName.Equals("ExplicitSelect") )
        {
            GridDataItem item = e.Item as GridDataItem;
            setSelectedEmp(item["EmpName"].Text , item["Nobr"].Text);

            gvQsEmp.Visible = false;
        }
    }

    protected void tbQuickSearch_TextChanged(object sender , EventArgs e)
    {
        btnSearch_Click(this , null);
    }


    void IEmpDeptQS.InitUC_Cat(int value , bool disableItem)
    {
        InitCat(value , true);
    }

    protected void btnPush_Click(object sender , EventArgs e)
    {
        TrigSelected();
    }

    #region IEmpDeptQS 成員


    void IEmpDeptQS.SelectSingleDept(bool value)
    {
        SelectSingleDeptOnly = value;
    }

    void IEmpDeptQS.DisplayPushBtn(bool value)
    {
        btnPush.Visible = value;
    }

    void IEmpDeptQS.SetQuickSearchAdvanced(bool value)
    {
        cbIsQuickSearchAdvanced.Checked = value;
        if (cbIsQuickSearchAdvanced.Checked)
        {
            lblHeaderMsg.Visible = false;
            lblHeaderMsg2.Visible = true;
        }
        else
        {
            lblHeaderMsg.Visible = true;
            lblHeaderMsg2.Visible = false;
        }
    }

    #endregion
}