using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.IO;
using System.Collections;

public partial class eTraining_Admin_Do_TrainingTemplate : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = "OJT訓練卡設定";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvCourse);
        var OJT = new trOJTTemplate();
        string sCode = Guid.NewGuid().ToString();
        lblMsg.Text = "";
        try
        {
            OJT.sCode = sCode;
            OJT.sName = txtName.Text;
            OJT.sKeyMan = User.Identity.Name;
            OJT.dKeyDate = DateTime.Now;
            dcTrain.trOJTTemplate.InsertOnSubmit(OJT);
            dcTrain.SubmitChanges();

            txtName.Text = string.Empty;

            gvOJTtp.Rebind();
            gvAddCourse.Rebind();
            cbxOJTcode.DataBind();
            
            
        }
        catch
        {
            lblMsg.Text = "範本名稱不可重覆";
        }

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {


    }
    protected void gvOJTtp_DataBound(object sender, EventArgs e)
    {
        //int iAutoKey = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("iAutoKey"));
        //var tpEdit = (from c in dcTrain.trOJTTemplate
        //              where c.iAutoKey==
        //              select c).FirstOrDefault();
        //foreach (GridItem e in gvOJTtp)
        //{
        //    int autokey = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"];
        //}

        //if (e.Item is GridDataItem)
        //{

        //}
    }
    protected void gvOJTtp_ItemDataBound(object sender, GridItemEventArgs e)
    {
        //if (e.Item is GridDataItem)
        //{
        //    RadButton btnEdit = e.Item.FindControl("btnEdit") as RadButton;
        //    int iAutokey = Convert.ToInt32(btnEdit.CommandArgument);

        //    var tpEdit = (from c in dcTrain.trOJTTemplate
        //                  where c.iAutoKey == iAutokey
        //                  select c).FirstOrDefault();

        //    txtCode.Text = tpEdit.sCode;
        //    txtName.Text = tpEdit.sName;

        //}
    }

    protected void btnCourseIn_Click(object sender, EventArgs e)
    {
        if (IsRefresh)
        {
            return;
        }
        foreach ( GridDataItem item in gvCourse.Items )
        {

            //取消此資料
            if ( item["ojtKey"].Text.Trim().Length > 0 && item.Selected == false)
            {
                var ojb = (from c in dcTrain.trOJTTemplateDetail
                           where c.iAutoKey == Convert.ToInt32(item["ojtKey"].Text)
                           select c).FirstOrDefault();

                dcTrain.trOJTTemplateDetail.DeleteOnSubmit(ojb);
            }
            if ( item["ojtKey"].Text.Trim().Length == 0 && item.Selected == true )
            {               
                var OJTDetail = new trOJTTemplateDetail();
                OJTDetail.OJT_sCode = gvAddCourse.SelectedValue.ToString();               
                OJTDetail.trCourse_sCode = item["sCode"].Text.ToString();
                OJTDetail.sKeyMan = User.Identity.Name;
                OJTDetail.dKeyDate = DateTime.Now;
                dcTrain.trOJTTemplateDetail.InsertOnSubmit(OJTDetail);
            }
                
        }

        dcTrain.SubmitChanges();
        cbxOJTcode.DataBind();
        gvView.Rebind();
        gvCourse.Rebind();
        
        AlertMsg("修改完成");
  //        pnlTpChoose.Visible = true;
  //      pnlCourseAdd.Visible = false;

    }
    protected void gvAddCourse_ItemCommand(object sender, GridCommandEventArgs e)
    {

    }
    protected void gvAddCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlTpChoose.Visible = false;
        pnlCourseAdd.Visible = true;

        foreach (GridItem i in gvCourse.Items)
        {
            string OJTcode = i.OwnerTableView.Items[i.ItemIndex].Cells[0].Text;
        }

    }
    protected void cbxOJTcode_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gvView.Rebind();
    }
    protected void btnCnl_Click(object sender, EventArgs e)
    {
        pnlTpChoose.Visible = true;
        pnlCourseAdd.Visible = false;
        //因為可能有被選擇到，rebind為了reset        
        gvCourse.CurrentPageIndex = 0;
        gvCourse.Rebind();
    }
    protected void gvCourse_ItemDataBound(object sender , GridItemEventArgs e)
    {
        if ( e.Item is GridDataItem )
        {
            GridDataItem item = e.Item as GridDataItem;

            if ( item["ojtKey"].Text.Trim().Length > 0 )
            {
                item.Selected = true;
            }
            else
                item.Selected = false;          

        }
    }
    protected void gvView_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridFooterItem)
        {
            GridFooterItem f_item = (GridFooterItem)e.Item;
            GridDataItemCollection items = gvView.Items;


            int scoreAmt = 0;

            foreach (GridDataItem i in items)
            {
                int temp_i = 0;
                if (Int32.TryParse(i["iJobScore"].Text, out temp_i))
                {
                    scoreAmt = scoreAmt + temp_i;
                }
            }

            f_item["iJobScore"].Text = "積分合計：" + scoreAmt.ToString();
        }

    }
    protected void sdsGvOJTtp_Updating(object sender, SqlDataSourceCommandEventArgs e)
    {
        
    }
    protected void gvOJTtp_ItemUpdated(object sender, GridUpdatedEventArgs e)
    {

    }
    protected void gvOJTtp_EditCommand(object sender, GridCommandEventArgs e)
    {
        
    }
    protected void gvOJTtp_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        //if (e.Item is GridEditFormItem)
        //{
        //    GridEditableItem item = (GridEditableItem)e.Item;
        //    //Hashtable newValues = new Hashtable(); 
        //    //item.ExtractValues(newValues);

        //    CheckBox cb = item["IsValid"].Controls[0] as CheckBox;
        //    if (cb.Checked == true)
        //    {
        //        item["ExpirationDate"].Text = "";
        //    }
        //    else
        //    {
        //        item["ExpirationDate"].Text = DateTime.Now.ToString();
        //    }
        //}
    }
}