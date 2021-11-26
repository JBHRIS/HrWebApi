using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Admin_Do_QuestionaryManage : JBWebPage
{
    private qBaseM_Repo qbmRepo = new qBaseM_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvS);
        RadWindow1.VisibleOnPageLoad = false;
    }
    protected void btnM_Click(object sender, EventArgs e)
    {
        


    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        pnlNobrList.Visible = false;
        pnlQList.Visible = true;
    }
    protected void gvQList_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void gvQList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            GridDataItem item = e.Item as GridDataItem;
            lblQcode.Text = item["sCode"].Text;
            lblClassID.Text = Request.QueryString["ID"].ToString();

            pnlNobrList.Visible = true;
            pnlQList.Visible = false;

            if (item["FillerCategory"].Text.Trim().Equals("S") || item["FillerCategory"].Text.Trim().Equals("C"))
            {
                gvS.Visible = true;
                gvM.Visible = false;
                gvT.Visible = false;
                gvS.Rebind();
                return;
            }

            if (item["FillerCategory"].Text.Trim().Equals("M"))
            {
                gvS.Visible = false;
                gvM.Visible = true;
                gvT.Visible = false;
                gvM.Rebind();
            }

            if(item["FillerCategory"].Text.Trim().Equals("T") )
            {
                gvS.Visible = false;
                gvM.Visible = false;
                gvT.Visible = true;
                gvT.Rebind();
            }
        }
    }
    //protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    //{
    //    if (e.Item is GridDataItem)
    //    {
    //        string url = @"~/eTraining/Questionary/qWrite.aspx";

    //        RadButton btnView = e.Item.FindControl("btnView") as RadButton;
    //        if (btnView != null)
    //        {
                
    //            string sAutoKey = btnView.CommandArgument.ToString();
    //            btnView.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", url + "?iAutoKey=" + sAutoKey, e.Item.ItemIndex);
    //        }
    //    }
    //}
    protected void gv_SelectedIndexChanged(object sender , EventArgs e)
    {
        RadWindow1.VisibleOnPageLoad = true;
        RadWindow1.NavigateUrl = @"~/eTraining/Questionary/qBaseMView.aspx?ID="+gvS.SelectedValue;
    }
    protected void gvM_SelectedIndexChanged(object sender , EventArgs e)
    {
        RadWindow1.VisibleOnPageLoad = true;
        RadWindow1.NavigateUrl = @"~/eTraining/Questionary/qBaseMView.aspx?ID=" + gvM.SelectedValue;
    }
    protected void gvT_SelectedIndexChanged(object sender , EventArgs e)
    {
        RadWindow1.VisibleOnPageLoad = true;
        RadWindow1.NavigateUrl = @"~/eTraining/Questionary/qBaseMView.aspx?ID=" + gvT.SelectedValue;
    }
    protected void gvS_UpdateCommand(object sender, GridCommandEventArgs e)
    {
        var editableItem = ((GridEditableItem)e.Item);
        var iAutoKey = (int)editableItem.GetDataKeyValue("iAutoKey");

        var obj = qbmRepo.GetById(iAutoKey);
        if (obj != null)
        {
            try
            {
                //update entity's state
                editableItem.UpdateValues(obj);
                qbmRepo.Update(obj);
                qbmRepo.Save();
            }
            catch (System.Exception)
            {
                RadAjaxPanel1.Alert("錯誤，請確認輸入格式正確");
                e.Canceled = true;
            }
        }
    }
    //protected void gvM_UpdateCommand(object sender, GridCommandEventArgs e)
    //{
    //    var editableItem = ((GridEditableItem)e.Item);
    //    var iAutoKey = (int)editableItem.GetDataKeyValue("iAutoKey");

    //    var obj = qbmRepo.GetById(iAutoKey);
    //    if (obj != null)
    //    {
    //        try
    //        {
    //            //update entity's state
    //            editableItem.UpdateValues(obj);
    //            qbmRepo.Update(obj);
    //            qbmRepo.Save();
    //        }
    //        catch (System.Exception)
    //        {
    //            RadAjaxPanel1.Alert("錯誤，請確認輸入格式正確");
    //            e.Canceled = true;
    //        }
    //    }
    //}
    //protected void gvT_UpdateCommand(object sender, GridCommandEventArgs e)
    //{
    //    var editableItem = ((GridEditableItem)e.Item);
    //    var iAutoKey = (int)editableItem.GetDataKeyValue("iAutoKey");

    //    var obj = qbmRepo.GetById(iAutoKey);
    //    if (obj != null)
    //    {
    //        try
    //        {
    //            //update entity's state
    //            editableItem.UpdateValues(obj);
    //            qbmRepo.Update(obj);
    //            qbmRepo.Save();
    //        }
    //        catch (System.Exception)
    //        {
    //            RadAjaxPanel1.Alert("錯誤，請確認輸入格式正確");
    //            e.Canceled = true;
    //        }
    //    }
    //}
}