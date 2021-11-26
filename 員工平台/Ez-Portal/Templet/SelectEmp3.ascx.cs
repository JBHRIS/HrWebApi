using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Telerik.Web.UI;
using System.Collections;

public partial class Templet_SelectEmp3:JUserControl , ISelectEmp
{
    public delegate void SelectEmpEventHandler(List<string> nobrList);
    public event SelectEmpEventHandler sHandler;
    private BASE_REPO baseRepo = new BASE_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (sHandler != null)
        //{
        //    sHandler(gv.SelectedValue.ToString());
        //}
    }

    protected void gv_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }


    #region ISelectEmp 成員

    List<string> ISelectEmp.GetSelectedEmps()
    {
        return lb.Items.Select(p => p.Value).ToList();
    }

    void ISelectEmp.ClearSelected()
    {
        foreach (GridDataItem i in gv.SelectedItems)
            i.Selected = false;

        Session[SessionName2] = null;
    }

    void ISelectEmp.ClearAll()
    {
        tbQuickSearch.Text = "";
        lb.Items.Clear();
        gv.DataSource =  new string[] { };
        gv.DataBind();
    }

    void ISelectEmp.SetSelectedData(List<RadListBoxItem> list)
    {
        lb.Items.Clear();
        foreach (GridDataItem i in gv.SelectedItems)
            i.Selected = false;

        foreach (var l in list)
        {
            lb.Items.Add(l);
        }
    }

    void ISelectEmp.SetReadOnly(bool value)
    {
        lb.Enabled = !value;
        gv.Enabled = !value;
        tbQuickSearch.Enabled = !value;
        btnClear.Enabled = !value;
    }

    #endregion
    protected void tbQuickSearch_TextChanged(object sender, EventArgs e)
    {
        btnSearch_Click(this, null);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        tbQuickSearch.Focus();
        if (tbQuickSearch.Text.Trim().Length >= 2)
        {
            BASE_REPO baseRepo = new BASE_REPO();
            List<BASE> baseList = new List<BASE>();
            baseList = baseRepo.GetHiredEmpBySeachKeyExt_DLO(tbQuickSearch.Text.Trim());

            gv.DataSource = (from c in baseList
                                  select new
                                  {
                                      Nobr = c.NOBR,
                                      Name = c.NAME_C,
                                      DeptName = c.BASETTS[0].DEPT1.D_NAME,
                                      JobName = c.BASETTS[0].JOB1.JOB_NAME,
                                      EmpName = c.NAME_C,
                                      NameC = c.NAME_C
                                  }).ToList();
            gv.DataBind();

            gv.Visible = true;

            if (gv.Items.Count ==1)
            {
                gv_ItemCommand(this,new GridCommandEventArgs(gv.Items[0],this,new CommandEventArgs("ExplicitSelect","")));
                btnClear_Click(this, new EventArgs());
            }
        }

        
        
    }
    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {        
        if (e.CommandName.Equals("ExplicitSelect"))
        {
            GridDataItem item = e.Item as GridDataItem;
            if (item != null)
                lbAddItem(item["Nobr"].Text, item["NameC"].Text);
        }
        if (e.CommandName.Equals("SelectAll"))
        {
            foreach (var i in gv.Items)
            {
                Telerik.Web.UI.GridCommandEventArgs e2 = new GridCommandEventArgs(i as GridItem, this, new CommandEventArgs("ExplicitSelect", ""));
                gv_ItemCommand(this, e2);
            }

            btnClear_Click(this, new EventArgs());
        }
    }

    private void lbAddItem(string nobr, string name)
    {
        RadListBoxItem item = lb.FindItemByValue(nobr);
        if (item == null)
        {
            item = new RadListBoxItem();
            item.Value = nobr;
            item.Text = name;
            lb.Items.Add(item);
        }
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        tbQuickSearch.Text = "";
        gv.Visible = false;
        tbQuickSearch.Focus();
    }






}
