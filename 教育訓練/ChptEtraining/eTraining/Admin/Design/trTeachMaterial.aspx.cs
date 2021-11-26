using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
public partial class eTraining_Admin_Design_trTeachMaterial : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (gv.Items.Count == 0)
        //{
        //    gv.Visible = false;
        //}
        //else
        //{
        //    gv.Visible = true;
        //}
        if (!IsPostBack)
        {



            if (Request.QueryString["ID"] == null)
            {
                changeMode("i");
                //cbxTeachingMethod.SelectedIndex = 4;
                //cbxTeachingResource.SelectedIndex = 1;

            }
            else
            {
                lblTeachMaterialID.Text = Request.QueryString["ID"].ToString();
                loadMaterial(Convert.ToInt32(lblTeachMaterialID.Text));
                changeMode("v");
            }

        }
    }

    protected void btnAddItem_Click(object sender, EventArgs e)
    {
        RadWindow1.VisibleOnPageLoad = true;        
    }
    protected void cbxBCate_ItemDataBound(object sender, Telerik.Web.UI.RadComboBoxItemEventArgs e)
    {

    }
    protected void cbxBCate_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }
    protected void cbxDCate_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
    {
        //RadComboBox cbx = fvTeachingMaterial.FindControl("cbxCourse") as RadComboBox;
        //cbx.Visible = false;
    }
    protected void cbxDCate_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }

    protected void fvTeachingMaterial_DataBound(object sender, EventArgs e)
    {
        if (!Juser.IsInRole("1"))
        {
            bSavedCheckBox.Enabled = false;
        }
    }
    protected void fvTeachingMaterial_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {

    }

    protected void btnTeachMaterialSave_Click(object sender, EventArgs e)
    {
        if (cbxCourse.SelectedItem == null)
        {
            RadAjaxPanel1.Alert("需選擇課程");
            return;
        }

        var data = (from c in dcTraining.trTeachingMaterial
                    where c.sVersion == tbVersion.Text
                    && c.trCourse_sCode == cbxCourse.SelectedValue
                    select c).FirstOrDefault();
        if (data != null && lblMMode.Text == "i")
        {
            RadAjaxPanel1.Alert("此課程已有重複的版本，請輸入另外版本");
            return;
        }


        if (lblMMode.Text == "i")
        {
            trTeachingMaterial obj = new trTeachingMaterial();
            obj.bSaved = bSavedCheckBox.Checked;
            obj.dKeyDate = DateTime.Now;
            if (ntbTeachingTime.Value.HasValue)
            {
                obj.dTeachingTime = Convert.ToInt32(ntbTeachingTime.Value.Value);
            }
            else
            {
                RadAjaxPanel1.Alert("時間需輸入");
                return;
            }

            obj.sContent = tbContent.Text;
            obj.sCourseExpect = tbsCourseExpect.Text;
            obj.sCoursePolicy = tbCoursePolicy.Text;
            obj.sKeyMan = User.Identity.Name;
            obj.sVersion = tbVersion.Text;
            obj.trCourse_sCode = cbxCourse.SelectedValue;

            dcTraining.trTeachingMaterial.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();

            loadMaterial(obj.iAutoKey);
            changeMode("v");
        }

        if (lblMMode.Text == "e")
        {
            var obj = (from c in dcTraining.trTeachingMaterial
                       where c.iAutoKey == Convert.ToInt32(lblTeachMaterialID.Text)
                       select c).FirstOrDefault();

            obj.bSaved = bSavedCheckBox.Checked;
            obj.dKeyDate = DateTime.Now;
            if (ntbTeachingTime.Value.HasValue)
            {
                obj.dTeachingTime = Convert.ToInt32(ntbTeachingTime.Value.Value);
            }
            else
            {
                RadAjaxPanel1.Alert("時間需輸入");
                return;
            }
            obj.sContent = tbContent.Text;
            obj.sCourseExpect = tbsCourseExpect.Text;
            obj.sCoursePolicy = tbCoursePolicy.Text;
            obj.sKeyMan = User.Identity.Name;
            obj.sVersion = tbVersion.Text;
            if (cbxCourse.SelectedItem == null)
            {
                RadAjaxPanel1.Alert("需選擇課程");
                return;
            }
            else
                obj.trCourse_sCode = cbxCourse.SelectedValue; 

            dcTraining.SubmitChanges();

            loadMaterial(obj.iAutoKey);
            changeMode("v");
        }

    }

    void loadMaterial(int id)
    {
        lblTeachMaterialID.Text = id.ToString();
        var data = (from c in dcTraining.trTeachingMaterial
                    where c.iAutoKey == id
                    select c).FirstOrDefault();

        bSavedCheckBox.Checked = data.bSaved;

        if (!Juser.IsInRole("1"))
        {
            bSavedCheckBox.Enabled = false;
        }
        else
        {
            bSavedCheckBox.Enabled = true;
        }

        if (data.dTeachingTime.HasValue)
            ntbTeachingTime.Text = data.dTeachingTime.ToString();

        tbContent.Text = data.sContent;
        tbCoursePolicy.Text = data.sCoursePolicy;
        tbsCourseExpect.Text = data.sCourseExpect;
        tbVersion.Text = data.sVersion;

        //如果 bSavedCheckBox.checked為true，代表已存成副本，則不准編輯
        if (bSavedCheckBox.Checked == true)
        {
            //管理員可使用編輯
            if (!Juser.IsInRole("1"))
                btnTeachMaterialEdit.Enabled = false;
            else
                btnTeachMaterialEdit.Enabled = true;

            //disable所有可編輯的項目            
            gv.Enabled = false;
            btnAddItem.Enabled = false;
        }
        else
        {
            btnTeachMaterialEdit.Enabled = true;
            gv.Enabled = true;
            btnAddItem.Enabled = true;
        }

    }

    private void changeMode(string mode)
    {
        RadWindow1.VisibleOnPageLoad = false;

        if (!Juser.IsInRole("1"))
        {
            bSavedCheckBox.Enabled = false;
        }
        else
        {
            bSavedCheckBox.Enabled = true;
        }

        if (mode == "v")
        {
            pnlMaterialHead.Enabled = false;
            btnTeachMaterialAdd.Visible = false;
            btnTeachMaterialSave.Visible = false;
            btnTeachMaterialEdit.Visible = true;
            btnCancel.Visible = false;
            lblMMode.Text = "v";
            btnAddItem.Visible = true;
        }
        if (mode == "i") //新增
        {
            btnTeachMaterialAdd.Visible = false;
            btnTeachMaterialSave.Visible = true;
            btnTeachMaterialEdit.Visible = false;
            btnCancel.Visible = true;
            lblMMode.Text = "i";
            lblTeachMaterialID.Text = "";
            btnAddItem.Visible = false;
        }
        if (mode == "e")
        {
            if (lblTeachMaterialID.Text.Trim().Length == 0)
            {
                RadAjaxPanel1.Alert("無資料可編輯，請先新增資料");
                return;
            }
            btnTeachMaterialEdit.Visible = false;
            btnTeachMaterialSave.Visible = true;
            btnCancel.Visible = true;
            pnlMaterialHead.Enabled = true;
            lblMMode.Text = "e";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (lblTeachMaterialID.Text.Trim().Length > 0)
        {
            int id = Convert.ToInt32(lblTeachMaterialID.Text);
            loadMaterial(id);
            changeMode("v");
        }
        else
            changeMode("i");
    }
    protected void btnTeachMaterialAdd_Click(object sender, EventArgs e)
    {
        changeMode("i");
    }
    protected void btnTeachMaterialEdit_Click(object sender, EventArgs e)
    {
        changeMode("e");
    }
    protected void btnCancelItem_Click(object sender, EventArgs e)
    {
        RadWindow1.VisibleOnPageLoad = false;
        lblItemID.Text = "";
        clearItemValue();
    }
    protected void btnSaveItem_Click(object sender, EventArgs e)
    {
        if (lblItemID.Text.Trim().Length == 0)
            doAddItem();
        else
        {
            doUpdateItem();
        }

        RadWindow1.VisibleOnPageLoad = false;
        lblItemID.Text = "";
        clearItemValue();
    }

    private void doUpdateItem()
    {
        int itemID = Convert.ToInt32(lblItemID.Text);

        var obj = (from c in dcTraining.trTeachingMaterialDetail
                   where c.iAutoKey == itemID
                   select c).FirstOrDefault();
        if (obj == null)
            throw new ApplicationException("未選取到正確的item autokey");

        obj.dKeyDate = DateTime.Now;
        obj.sKeyMan = User.Identity.Name;
        obj.sNote = tbNote.Text;
        obj.sOutline = tbOutline.Text;
        if (lblTeachMaterialID.Text.Trim().Length == 0)
        {
            throw new ApplicationException("未選定正確教案");
        }
        else
        {
            obj.MaterialAutoKey = Convert.ToInt32(lblTeachMaterialID.Text);
        }

        if (ntbOrder.Value.HasValue)
            obj.iOrder = Convert.ToInt32(ntbOrder.Value.Value);
        else
        {
            obj.iOrder = 1;
        }

        if (ntbTimeMin.Value.HasValue)
        {
            obj.iTimeMin = Convert.ToInt32(ntbTimeMin.Value.Value);
        }
        else
        {
            RadAjaxPanel1.Alert("時數必須填寫");
            RadWindow1.VisibleOnPageLoad = true;
        }

        var teachingMethod = (from c in dcTraining.trTeachingMaterialDetail_TeachingMethod
                              where c.MaterialDetailAutoKey == itemID
                              select c).ToList();

        dcTraining.trTeachingMaterialDetail_TeachingMethod.DeleteAllOnSubmit(teachingMethod);

        var teachingResource = (from c in dcTraining.trTeachingMaterialDetail_TeachingResource
                                where c.MaterialDetailAutoKey == itemID
                                select c).ToList();

        dcTraining.trTeachingMaterialDetail_TeachingResource.DeleteAllOnSubmit(teachingResource);
        //        dcTraining.SubmitChanges();

        foreach (RadComboBoxItem item in cbxTeachingMethod.CheckedItems)
        {
            trTeachingMaterialDetail_TeachingMethod m = new trTeachingMaterialDetail_TeachingMethod();
            m.MaterialDetailAutoKey = obj.iAutoKey;
            m.trTeachingMethod_sCode = item.Value;
            dcTraining.trTeachingMaterialDetail_TeachingMethod.InsertOnSubmit(m);
        }

        foreach (RadComboBoxItem item in cbxTeachingResource.CheckedItems)
        {
            trTeachingMaterialDetail_TeachingResource r = new trTeachingMaterialDetail_TeachingResource();
            r.MaterialDetailAutoKey = obj.iAutoKey;
            r.trTeachingResourceCode = item.Value;
            dcTraining.trTeachingMaterialDetail_TeachingResource.InsertOnSubmit(r);
        }

        dcTraining.SubmitChanges();

        RadWindow1.VisibleOnPageLoad = false;
        gv.Rebind();
        clearItemValue();

    }

    private void doAddItem()
    {
        trTeachingMaterialDetail obj = new trTeachingMaterialDetail();
        obj.dKeyDate = DateTime.Now;
        obj.sKeyMan = User.Identity.Name;
        obj.sNote = tbNote.Text;
        obj.sOutline = tbOutline.Text;
        if (lblTeachMaterialID.Text.Trim().Length == 0)
        {
            throw new ApplicationException("未選定正確教案");
        }
        else
        {
            obj.MaterialAutoKey = Convert.ToInt32(lblTeachMaterialID.Text);
        }

        if (ntbOrder.Value.HasValue)
            obj.iOrder = Convert.ToInt32(ntbOrder.Value.Value);
        else
        {
            obj.iOrder = 1;
        }

        if (ntbTimeMin.Value.HasValue)
        {
            obj.iTimeMin = Convert.ToInt32(ntbTimeMin.Value.Value);
        }
        else
        {
            RadAjaxPanel1.Alert("時數必須填寫");
            RadWindow1.VisibleOnPageLoad = true;
        }

        dcTraining.trTeachingMaterialDetail.InsertOnSubmit(obj);
        dcTraining.SubmitChanges();

        foreach (RadComboBoxItem item in cbxTeachingMethod.CheckedItems)
        {
            trTeachingMaterialDetail_TeachingMethod m = new trTeachingMaterialDetail_TeachingMethod();
            m.MaterialDetailAutoKey = obj.iAutoKey;
            m.trTeachingMethod_sCode = item.Value;
            dcTraining.trTeachingMaterialDetail_TeachingMethod.InsertOnSubmit(m);
        }

        foreach (RadComboBoxItem item in cbxTeachingResource.CheckedItems)
        {
            trTeachingMaterialDetail_TeachingResource r = new trTeachingMaterialDetail_TeachingResource();
            r.MaterialDetailAutoKey = obj.iAutoKey;
            r.trTeachingResourceCode = item.Value;
            dcTraining.trTeachingMaterialDetail_TeachingResource.InsertOnSubmit(r);
        }

        dcTraining.SubmitChanges();

        RadWindow1.VisibleOnPageLoad = false;
        gv.Rebind();
        clearItemValue();
    }

    private void doDeleteItem(int itemID)
    {
        var obj = (from c in dcTraining.trTeachingMaterialDetail
                   where c.iAutoKey == itemID
                   select c).FirstOrDefault();
        if (obj == null)
            throw new ApplicationException("未選取到正確的item autokey");

        dcTraining.trTeachingMaterialDetail.DeleteOnSubmit(obj);

        var teachingMethod = (from c in dcTraining.trTeachingMaterialDetail_TeachingMethod
                              where c.MaterialDetailAutoKey == itemID
                              select c).ToList();

        dcTraining.trTeachingMaterialDetail_TeachingMethod.DeleteAllOnSubmit(teachingMethod);

        var teachingResource = (from c in dcTraining.trTeachingMaterialDetail_TeachingResource
                                where c.MaterialDetailAutoKey == itemID
                                select c).ToList();

        dcTraining.trTeachingMaterialDetail_TeachingResource.DeleteAllOnSubmit(teachingResource);


        dcTraining.SubmitChanges();

        RadWindow1.VisibleOnPageLoad = false;
        gv.Rebind();
        clearItemValue();
    }

    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        GridDataItem item;
        if (e.Item is GridDataItem)
        {
            item = e.Item as GridDataItem;
            if (item != null)
            {
                item["sOutline"].Text = item["sOutline"].Text.Replace(System.Environment.NewLine, "<br>");
                item["sNote"].Text = item["sNote"].Text.Replace(System.Environment.NewLine, "<br>");

                item["TeachingMethod"].Text = getTeachingMethodStr(Convert.ToInt32(item["iAutoKey"].Text));
                item["TeachingResource"].Text = getTeachingResourceStr(Convert.ToInt32(item["iAutoKey"].Text));
            }
        }
    }

    private String getTeachingMethodStr(int id)
    {
        var dataList = (from tm in dcTraining.trTeachingMaterialDetail_TeachingMethod
                        join m in dcTraining.trTeachingMethod
                        on tm.trTeachingMethod_sCode equals m.sCode
                        where tm.MaterialDetailAutoKey == id
                        select m.sName).ToList();

        string result = "";
        for (int i = 0; i < dataList.Count; i++)
        {
            if (i == dataList.Count - 1)
            {
                result = result + dataList[i];
            }
            else
                result = result + dataList[i] + "、";
        }
        return result;
    }

    private String getTeachingResourceStr(int id)
    {
        var dataList = (from tr in dcTraining.trTeachingMaterialDetail_TeachingResource
                        join r in dcTraining.trTeachingResource
                        on tr.trTeachingResourceCode equals r.ResourceCode
                        where tr.MaterialDetailAutoKey == id
                        select r.ResourceName).ToList();

        string result = "";
        for (int i = 0; i < dataList.Count; i++)
        {
            if (i == dataList.Count - 1)
            {
                result = result + dataList[i];
            }
            else
                result = result + dataList[i] + "、";
        }
        return result;
    }


    private void clearItemValue()
    {
        tbOutline.Text = "";
        ntbTimeMin.Text = "0";
        tbNote.Text = "";
        ntbOrder.Text = "";
        clearItemCbx();
    }

    private void clearItemCbx()
    {
        foreach (RadComboBoxItem item in cbxTeachingMethod.Items)
        {
            item.Checked = false;
        }

        foreach (RadComboBoxItem item in cbxTeachingResource.Items)
        {
            item.Checked = false;
        }
    }
    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "EditItem")
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                lblItemID.Text = item["iAutoKey"].Text;
                loadItemData(Convert.ToInt32(lblItemID.Text));
                RadWindow1.VisibleOnPageLoad = true;

            }

        }
        if (e.CommandName == "DeleteItem")
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                doDeleteItem(Convert.ToInt32(item["iAutoKey"].Text));
                RadWindow1.VisibleOnPageLoad = false;
            }
        }
    }

    private void loadItemData(int id)
    {
        var data = (from c in dcTraining.trTeachingMaterialDetail
                    where c.iAutoKey == id
                    select c).FirstOrDefault();

        tbOutline.Text = data.sOutline;
        ntbTimeMin.Text = data.iTimeMin.ToString();
        tbNote.Text = data.sNote;
        ntbOrder.Text = data.iOrder.ToString();

        var teachingMethod = (from c in dcTraining.trTeachingMaterialDetail_TeachingMethod
                              where c.MaterialDetailAutoKey == id
                              select c).ToList();

        var teachingResource = (from c in dcTraining.trTeachingMaterialDetail_TeachingResource
                                where c.MaterialDetailAutoKey == id
                                select c).ToList();

        foreach (var m in teachingMethod)
        {
            foreach (RadComboBoxItem item in cbxTeachingMethod.Items)
            {
                if (m.trTeachingMethod_sCode == item.Value)
                    item.Checked = true;
            }
        }

        foreach (var r in teachingResource)
        {
            foreach (RadComboBoxItem item in cbxTeachingResource.Items)
            {
                if (r.trTeachingResourceCode == item.Value)
                    item.Checked = true;
            }
        }
    }
}