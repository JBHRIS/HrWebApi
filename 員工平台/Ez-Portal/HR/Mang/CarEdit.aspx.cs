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
public partial class CarEdit : JBWebPage
{
    Car_REPO carRepo = new Car_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }


    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        
        gv.DataSource = carRepo.GetAll();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (lblMode.Text.Equals(FormMode.Insert.ToString()))
        {
            Car car = new Car();
            car.CanRent = cbCanRent.Checked;
            car.CarId = tbCarId.Text;
            car.LicensePlate = tbLicensePlate.Text;
            car.Name = tbName.Text;
            car.DispBackColor = cp.SelectedColor.ToArgb();
            carRepo.Add(car);
            carRepo.Save();
        }
        else
        {
            Car car= carRepo.GetByPk(Convert.ToInt32(lblId.Text));
            car.CanRent = cbCanRent.Checked;
            car.CarId = tbCarId.Text;
            car.LicensePlate = tbLicensePlate.Text;
            car.Name = tbName.Text;
            car.DispBackColor = cp.SelectedColor.ToArgb();
            carRepo.Update(car);
            carRepo.Save();
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

        var car= carRepo.GetByPk(id);
        editableItem.UpdateValues(car);
        carRepo.Update(car);
        carRepo.Save();
        gv.Rebind();
    }
    protected void btnAddForm_Click(object sender , EventArgs e)
    {
        pnlAddForm.Visible = true;
        lblId.Text = "";
        lblMode.Text = FormMode.Insert.ToString();
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
    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("cmdEdit"))
        {
            GridDataItem item = e.Item as GridDataItem;
            lblMode.Text = FormMode.Update.ToString();
            lblId.Text = item["Id"].Text;
            int id = Convert.ToInt32(lblId.Text);
            loadCarData(id);
            pnlAddForm.Visible = true;
        }
    }

    private void cleanData()
    {
        cbCanRent.Checked = false;
        tbCarId.Text = "";
        tbLicensePlate.Text = "";
        tbName.Text = "";
    }
    private void loadCarData(int id)
    {
        Car car= carRepo.GetByPk(id);

        cbCanRent.Checked = car.CanRent;
        tbCarId.Text = car.CarId;
        tbLicensePlate.Text = car.LicensePlate;
        tbName.Text = car.Name;

        if (car.DispBackColor.HasValue) 
        {
            int color = Convert.ToInt32(car.DispBackColor);
            cp.SelectedColor= System.Drawing.Color.FromArgb(color);
        }
    }
}
