using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class eTraining_Teacher_SetTeachingMaterial : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper.ConverToChinese(gv);
            lblNobr.Text = User.Identity.Name;
        }
    }

    protected void RadButton1_Click(object sender, EventArgs e)
    {
        gv.Visible = true;
        btnSave.Visible = true;
        gvCourselist.Visible = false;
    }

    protected void sdsTeacherClass_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        //e.Command.Parameters["@teacher"].Value = User.Identity.Name;
    }
    protected void gvCourselist_ItemDataBound(object sender, GridItemEventArgs e)
    {

        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            if (item["iMaterialAutoKey"].Text.Length == 0 || item["iMaterialAutoKey"].Text == "0")
            {
                item["iMaterialAutoKey"].Text = "未指定";
            }
            else
                item["iMaterialAutoKey"].Text = "已指定";

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (gvCourselist.SelectedValue == null || gv.SelectedValue == null)
        {
            AlertMsg("請先選擇");
            return;
        }
        int classID = Convert.ToInt32(gvCourselist.SelectedValue);
        int MertID = Convert.ToInt32(gv.SelectedValue);

        var classObj = (from c in dcTraining.trTrainingDetailM
                        where c.iAutoKey == classID
                        select c).FirstOrDefault();

        if (classObj == null)
            throw new ApplicationException("無此課程");
        else
        {
            classObj.iMaterialAutoKey = MertID;
            classObj.sMaterialKeyMan = User.Identity.Name;
            dcTraining.SubmitChanges();
            gvCourselist.Rebind();
        }
        pnlSelect.Visible = false;
        gvCourselist.Visible = true;
        //gv.Visible = false;
        //btnSave.Visible = false;
        //gvCourselist.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlSelect.Visible = false;
        gvCourselist.Visible = true;
    }
    protected void gvCourselist_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlSelect.Visible = true;
    }


    protected void gv_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        int iAutoKey = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("iAutoKey"));

        trTeachingMaterial o_trTeachingMaterial = dcTraining.trTeachingMaterial.Where(p => p.iAutoKey == iAutoKey).FirstOrDefault();
        dcTraining.trTeachingMaterial.DeleteOnSubmit(o_trTeachingMaterial);
        dcTraining.SubmitChanges();
    }

    private void setItemView(GridDataItem item)
    {
        LinkButton lbtnDel = item["attachment"].FindControl("lbtnDelAtt") as LinkButton;
        lbtnDel.Visible = false;

        LinkButton lbtnUpdate = item["attachment"].FindControl("lbtnUpdate") as LinkButton;
        lbtnUpdate.Visible = false;

        if (!Juser.IsInRole("1"))
        {
            RadButton btnEdit = item["TemplateColumn"].FindControl("btnEdit") as RadButton;
            btnEdit.Attributes.Remove("onclick");
            btnEdit.Enabled = false;
        }

        RadButton btnDetail = item["Detail"].FindControl("btnDetail") as RadButton;
        btnDetail.Attributes.Remove("onclick");
        btnDetail.Enabled = false;

    }
    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem itm = e.Item as GridDataItem;
            if (itm == null)
                return;

            //如果此教案已存檔，則不能修改
            CheckBox ck = itm["bSaved"].Controls[0] as CheckBox;
            if (ck != null)
            {
                if (ck.Checked == true)
                {
                    setItemView(itm);
                }
            }

            //e.Item.Cells[7].Text = e.Item.Cells[7].Text.Replace(System.Environment.NewLine, "<br>");
            //e.Item.Cells[8].Text = e.Item.Cells[8].Text.Replace(System.Environment.NewLine, "<br>");
            //HyperLink hl= e.Item.Cells[10].FindControl("hl") as HyperLink;
            HyperLink hl = itm["attachment"].FindControl("hl") as HyperLink;
            if (hl != null)
            {
                //為了講師教案新增的
                LinkButton lbtn = itm["attachment"].FindControl("lbtnDelAtt") as LinkButton;
                //lbtn.OnClientClick = GetConfirmScript("是否刪除");
                lbtn.Visible = false;
                lbtn = itm["attachment"].FindControl("lbtnUpdate") as LinkButton;
                lbtn.Visible = false;


                if (itm["FileKey"].Text.Length == 0)
                {
                    hl.Visible = false;
                    lbtn.Visible = false;
                }
                else
                {
                    hl.NavigateUrl = "~/eTraining/Admin/download.ashx?ID=" + itm["FileStoredName"].Text;
                }
            }

            if (itm["sCoursePolicy"].Text.Length > 21)
            {
                itm["sCoursePolicy"].Text = itm["sCoursePolicy"].Text.Substring(0, 20) + "....";
            }

        }
    }
    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            string key = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString();
            GridDataItem itm = e.Item as GridDataItem;
            if (itm == null)
                return;

            if (e.CommandName == "View")
            {
                Response.Redirect("~/eTraining/Reports/Design/TeachingMaterial.aspx?ID=" + key);
            }
            if (e.CommandName == "Upload")
            {
                Response.Redirect("~/eTraining/Admin/Design/TeachingPlanUpload.aspx?ID=" + key);
            }
            if (e.CommandName == "DeleteAtt")
            {
                var file = (from c in dcTraining.UPLOAD
                            where c.iAutoKey == Convert.ToInt32(itm["FileKey"].Text)
                            select c).FirstOrDefault();

                if (file != null)
                {
                    SiteHelper siteHelper = new SiteHelper();
                    siteHelper.DeleteFile(file);
                }

                AlertMsg("已刪除");
                gv.Rebind();
            }
        }
    }
    protected void gvCourselist_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    }
}