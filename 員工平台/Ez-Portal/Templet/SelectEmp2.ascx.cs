using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Telerik.Web.UI;
using System.Collections;

public partial class Templet_SelectEmp2:JUserControl , ISelectEmp
{
    public delegate void SelectEmpEventHandler(string nobr);
    public event SelectEmpEventHandler sHandler;
    private BASE_REPO baseRepo = new BASE_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);
        if (!IsPostBack)
            gv.Rebind();
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sHandler != null)
        {
            sHandler(gv.SelectedValue.ToString());
        }
    }

    protected void gv_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        if (Session[SessionName] == null)
        {
            BASE_REPO baseRepo = new BASE_REPO();
            Session[SessionName] = baseRepo.GetHiredEmp_Dlo();
        }

        List<BASE> list = Session[SessionName] as List<BASE>;
        if (list != null)
        {
            if (cbDisplaySelected.Checked)
            {
                //var selectedItems = Session[SessionName2] as List<string>;
                var selectedItems = (Dictionary<string, string>)Session[SessionName2];
                if (selectedItems != null)
                    list = list.FindAll(p => selectedItems.ContainsKey(p.NOBR));
                else
                    list = new List<BASE>();
            }
            gv.DataSource = (from c in list
                             select new
                             {
                                 Nobr = c.NOBR,
                                 Name = c.NAME_C,
                                 DeptName = c.BASETTS[0].DEPT1.D_NAME,
                                 JobName = c.BASETTS[0].JOB1.JOB_NAME,
                                 EmpName = c.NAME_C
                             }).ToList();
        }

    }
    protected void gv_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        Hashtable hash = new Hashtable();
        
        //List<string> selectedItems;
        Dictionary<string,string> selectedItems;
        if (Session[SessionName2] == null)
            selectedItems = new Dictionary<string, string>();
        //selectedItems = new List<string>();
        else
            selectedItems = (Dictionary<string, string>)Session[SessionName2];
            //selectedItems = (List<string>)Session[SessionName2];

        if (e.CommandName == RadGrid.SelectCommandName && e.Item is GridDataItem)
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            string nobr = dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["Nobr"].ToString();
            if (!selectedItems.ContainsKey(nobr))
            {
                selectedItems.Add(nobr,nobr);
                Session[SessionName2] = selectedItems;
            }
            dataItem.Selected = true;
        }
        if (e.CommandName == RadGrid.DeselectCommandName && e.Item is GridDataItem)
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            string nobr = dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["Nobr"].ToString();
            selectedItems.Remove(nobr);
            //selectedItems.RemoveAll(p => p == nobr);
            //selectedItems.Remove(nobr);
            Session[SessionName2] = selectedItems;
            dataItem.Selected = false;
        }

        if (e.CommandName.Equals("SelectAll"))
        {
            foreach (var i in gv.Items)
            {
                Telerik.Web.UI.GridCommandEventArgs e2 = new GridCommandEventArgs(i as GridItem, this, new CommandEventArgs(RadGrid.SelectCommandName, ""));
                gv_ItemCommand(this, e2);
            }
        }
        if (e.CommandName.Equals("DeselectAll"))
        {
            foreach (var i in gv.Items)
            {
                Telerik.Web.UI.GridCommandEventArgs e2 = new GridCommandEventArgs(i as GridItem, this, new CommandEventArgs(RadGrid.DeselectCommandName, ""));
                gv_ItemCommand(this, e2);
            }
        }

        gv.Rebind();
    }
    protected void gv_PreRender(object sender, EventArgs e)
    {
        if (Session[SessionName2] != null)
        {
             Dictionary<string, string> selectedItems =(Dictionary<string, string>)Session[SessionName2];
            var selectedItems2 = selectedItems.Keys.ToList();
            Int32 stackIndex;
            for (stackIndex = 0; stackIndex <= selectedItems2.Count - 1; stackIndex++)
            {
                string curItem = selectedItems2[stackIndex].ToString();
                foreach (GridItem item in gv.MasterTableView.Items)
                {
                    if (item is GridDataItem)
                    {
                        GridDataItem dataItem = (GridDataItem)item;
                        if (curItem.Equals(dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["Nobr"].ToString()))
                        {
                            dataItem.Selected = true;
                            break;
                        }
                    }
                }
            }
        }
    }
    protected void cbDisplaySelected_CheckedChanged(object sender, EventArgs e)
    {
        gv.Rebind();
    }

    #region ISelectEmp 成員

    List<string> ISelectEmp.GetSelectedEmps()
    {
        List<string> list = new List<string>();
        foreach ( GridDataItem item in gv.SelectedItems )
        {
            list.Add(item["Nobr"].Text);
        }
        return list;
    }

    void ISelectEmp.ClearSelected()
    {
        foreach (GridDataItem i in gv.SelectedItems)
            i.Selected = false;

        Session[SessionName2] = null;
    }

    void ISelectEmp.ClearAll()
    {
    }
    #endregion


    void ISelectEmp.SetSelectedData(List<RadListBoxItem> list)
    {
        throw new NotImplementedException();
    }

    void ISelectEmp.SetReadOnly(bool value)
    {
        throw new NotImplementedException();
    }
}
