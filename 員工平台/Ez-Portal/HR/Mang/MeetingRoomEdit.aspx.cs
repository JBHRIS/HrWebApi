using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BL;
using System.Linq;
using System.Collections.Generic;
using Telerik.Web.UI;
public partial class MeetingRoomEdit:JBWebPage
{
    MeetingRoom_REPO mrRepo = new MeetingRoom_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }


    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {        
        gv.DataSource = mrRepo.GetAll();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (lblMode.Text.Equals(FormMode.Insert.ToString()))
        {
            MeetingRoom MeetingRoom = new MeetingRoom();
            MeetingRoom.CanRent = cbCanRent.Checked;
            MeetingRoom.EnableSchedueRent = cbEnableSchedueRent.Checked;
            MeetingRoom.Name = tbName.Text;
            mrRepo.Add(MeetingRoom);
            mrRepo.Save();
        }
        else
        {
            MeetingRoom mr = mrRepo.GetByPk(Convert.ToInt32(lblId.Text));
            mr.CanRent = cbCanRent.Checked;
            mr.EnableSchedueRent = cbEnableSchedueRent.Checked;
            mr.Name = tbName.Text;
            mr.DispBackColor = cp.SelectedColor.ToArgb();
            mrRepo.Update(mr);
            mrRepo.Save();
        }

        gv.Rebind();
        pnlAddForm.Visible = false;
        cleanData();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlAddForm.Visible = false;
    }
    protected void gv_UpdateCommand(object sender , GridCommandEventArgs e)
    {
        var editableItem = ((GridEditableItem) e.Item);
        var id = (int) editableItem.GetDataKeyValue("Id");

        var MeetingRoom= mrRepo.GetByPk(id);
        editableItem.UpdateValues(MeetingRoom);
        mrRepo.Update(MeetingRoom);
        mrRepo.Save();
        gv.Rebind();
    }
    protected void btnAddForm_Click(object sender , EventArgs e)
    {
        pnlAddForm.Visible = true;
        lblId.Text = "";
        lblMode.Text = FormMode.Insert.ToString();
    }


    private void cleanData()
    {
        cbCanRent.Checked = false;
        cbEnableSchedueRent.Checked = false;
        tbName.Text = "";
    }
    private void loadData(int id)
    {
        MeetingRoom mr = mrRepo.GetByPk(id);

        cbCanRent.Checked = mr.CanRent;
        cbEnableSchedueRent.Checked = mr.EnableSchedueRent;
        tbName.Text = mr.Name;

        if (mr.DispBackColor.HasValue)
        {
            int color = Convert.ToInt32(mr.DispBackColor);
            cp.SelectedColor = System.Drawing.Color.FromArgb(color);
        }
    }
    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("cmdEdit"))
        {
            GridDataItem item = e.Item as GridDataItem;
            lblMode.Text = FormMode.Update.ToString();
            lblId.Text = item["Id"].Text;
            int id = Convert.ToInt32(lblId.Text);
            loadData(id);
            pnlAddForm.Visible = true;
        }
    }
    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        GridDataItem item = e.Item as GridDataItem;

        if (e.Item is GridDataItem)
        {
            if (item["DispBackColor"].Text.Length > 0)
            {
                int color = Convert.ToInt32(item["DispBackColor"].Text);

                item["Color"].BackColor = System.Drawing.Color.FromArgb(color);
            }
        }
    }
}
