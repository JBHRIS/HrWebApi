using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using BL;
public partial class System_FileGroup:JBWebPage
{
    const string FileGroupEditUrl = @"~/System/FileGroupEdit.aspx?Id=";
    private FileGroup_Repo fgRepo = new FileGroup_Repo();
    protected void Page_Load(object sender , EventArgs e)
    {
        //SiteHelper.ConverToChinese(gvNobr);
        if ( !IsPostBack )
        {
            bind_cbRole();
        }
        win.VisibleOnPageLoad = false;
    }

    private void bind_cbRole()
    {
        sysRole_Repo rRepo = new sysRole_Repo();
        var list = rRepo.GetAll();
        foreach ( var l in list )
        {
            RadComboBoxItem item = new RadComboBoxItem();
            item.Value = l.Code;
            item.Text = l.Name;
            cbRole.Items.Add(item);
        }
    }



    protected void gv_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        gv.DataSource = fgRepo.GetAll();
    }

    private void loadData(int id)
    {
        FileGroup fgObj = fgRepo.GetById(Convert.ToInt32(lblId.Text));
        tbName.Text = fgObj.Name;
        ntbSequence.Value = fgObj.Sequence;

        cbRole.ClearCheckedItems();
        FileGroupRole_Repo fgrRepo = new FileGroupRole_Repo(fgRepo.dc);
        var fgrList = fgrRepo.GetByGroupId(fgObj.Id);
        foreach ( RadComboBoxItem item in cbRole.Items )
        {
            if ( fgrList.Any(p => p.Role == item.Value) )
            {
                item.Checked = true;
            }
        }


        foreach ( var p in cbRole.CheckedItems )
        {
            FileGroupRole fgrObj = new FileGroupRole();
            fgrObj.Role = p.Value;
            fgrRepo.Add(fgrObj);
        }
    }

    protected void gv_ItemCommand(object sender , GridCommandEventArgs e)
    {
        GridDataItem item = e.Item as GridDataItem;

        if ( e.CommandName.Equals("Del") )
        {
            fgRepo.DeleteById(Convert.ToInt32(item["Id"].Text));
            fgRepo.Save();
            gv.Rebind();
        }
        else if ( e.CommandName.Equals("EditContent") )
        {
            win.NavigateUrl = FileGroupEditUrl + item["Id"].Text;
            win.VisibleOnPageLoad = true;
        }
        else if ( e.CommandName.Equals("Edt") )
        {
            lblId.Text = item["Id"].Text;
            lblFormMode.Text = FormMode.Update.ToString();
            loadData(Convert.ToInt32(lblId.Text));
            pnlAddForm.Visible = true;
        }
    }
    protected void btnCancel_Click(object sender , EventArgs e)
    {
        pnlAddForm.Visible = false;
        tbName.Text = "";
        ntbSequence.Value = 0;
    }
    protected void btnSave_Click(object sender , EventArgs e)
    {
        FormMode fm = (FormMode) Enum.Parse(typeof(FormMode) , lblFormMode.Text);
        if ( fm == FormMode.Insert )
        {
            FileGroup fgObj = new FileGroup();
            fgObj.Name = tbName.Text;
            fgObj.Sequence = Convert.ToInt32(ntbSequence.Value);
            fgRepo.Add(fgObj);

            foreach ( var p in cbRole.CheckedItems )
            {
                FileGroupRole fgrObj = new FileGroupRole();
                fgrObj.Role = p.Value;
                fgObj.FileGroupRole.Add(fgrObj);
            }

            fgRepo.Save();
            gv.Rebind();
        }
        else if ( fm == FormMode.Update )
        {
            FileGroup fgObj= fgRepo.GetById(Convert.ToInt32(lblId.Text));
            fgObj.Name = tbName.Text;
            fgObj.Sequence = Convert.ToInt32(ntbSequence.Value);
            fgRepo.Update(fgObj);

            FileGroupRole_Repo fgrRepo = new FileGroupRole_Repo(fgRepo.dc);
            var fgrList= fgrRepo.GetByGroupId(fgObj.Id);
            fgrRepo.Delete(fgrList);

            foreach ( var p in cbRole.CheckedItems )
            {
                FileGroupRole fgrObj = new FileGroupRole();
                fgrObj.Role = p.Value;
                fgrObj.FileGroupId = fgObj.Id;
                fgrRepo.Add(fgrObj);
            }

            fgrRepo.Save();
            gv.Rebind();
        }

        pnlAddForm.Visible = false;
        tbName.Text = "";
        ntbSequence.Value = 0;
        cbRole.ClearCheckedItems();
    }
    protected void btnNew_Click(object sender , EventArgs e)
    {
        lblFormMode.Text = FormMode.Insert.ToString();
        pnlAddForm.Visible = true;
    }
    protected void RadAjaxPanel1_AjaxRequest(object sender , AjaxRequestEventArgs e)
    {
        if ( e.Argument == "Rebind" )
        {
            gv.Rebind();
        }
    }
}