using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class Admin_Design_trTeachingMaterial : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);
        if (!IsPostBack)
        {
            this.Title = "教案主檔";
        }
        btnAdd.Attributes["onclick"] = String.Format("return ShowInsertForm();");
    }

    protected void gv_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem || e.Item is GridHeaderItem)
        {
            RadButton btnEdit = e.Item.FindControl("btnEdit") as RadButton;
            if (btnEdit != null)
                btnEdit.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"], e.Item.ItemIndex);

            //RadButton btnAdd = e.Item.FindControl("btnAdd") as RadButton;
            //if (btnAdd != null)
            //    btnAdd.Attributes["onclick"] = String.Format("return ShowInsertForm();");

            RadButton btnDetail = e.Item.FindControl("btnDetail") as RadButton;
            if (btnDetail != null)
                btnDetail.Attributes["onclick"] = String.Format("return ShowDetailForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"], e.Item.ItemIndex);
        }
    }

    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            gv.MasterTableView.SortExpressions.Clear();
            gv.MasterTableView.GroupByExpressions.Clear();
            gv.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            gv.MasterTableView.SortExpressions.Clear();
            gv.MasterTableView.GroupByExpressions.Clear();
            gv.MasterTableView.CurrentPageIndex = gv.MasterTableView.PageCount - 1;
            gv.Rebind();
        }
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

                LinkButton lbtn = itm["attachment"].FindControl("lbtnDelAtt") as LinkButton;
                lbtn.OnClientClick = GetConfirmScript("是否刪除");

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

    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        pnlCopy.Visible = true;
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        pnlCopy.Visible = false;
        lblMsg.Text = "";
    }
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        var selectedObj = (from c in dcTraining.trTeachingMaterial
                           where c.iAutoKey == Convert.ToInt32(gv.SelectedValue)
                           select c).FirstOrDefault();

        if (selectedObj != null)
        {
            var obj = (from c in dcTraining.trTeachingMaterial
                       where c.trCourse_sCode == selectedObj.trCourse_sCode
                       && c.sVersion == tbCloneVision.Text
                       select c).FirstOrDefault();

            if (obj != null)
            {
                //Show("已有此版本，請確認");
                lblMsg.Text = "已有此版本，請確認";
                return;
            }
            else
            {
                trTeachingMaterial tm = new trTeachingMaterial();
                tm.dTeachingTime = selectedObj.dTeachingTime;
                tm.dKeyDate = DateTime.Now;
                tm.sContent = selectedObj.sContent;
                tm.sCourseExpect = selectedObj.sCourseExpect;
                tm.sCoursePolicy = selectedObj.sCoursePolicy;
                tm.sKeyMan = User.Identity.Name;
                tm.sVersion = tbCloneVision.Text;
                tm.trCourse_sCode = selectedObj.trCourse_sCode;

                dcTraining.trTeachingMaterial.InsertOnSubmit(tm);
                dcTraining.SubmitChanges();


                //copy detail

                var selectedObjDetail = (from c in dcTraining.trTeachingMaterialDetail
                                         where c.MaterialAutoKey == selectedObj.iAutoKey
                                         select c).ToList();

                var selectedObjDetailParents = (from c in selectedObjDetail
                                                where c.ParentiAutoKey == 0
                                                select c).ToList();

                foreach (var cloneD in selectedObjDetailParents)
                {
                    trTeachingMaterialDetail dtlObj = new trTeachingMaterialDetail();
                    dtlObj.ParentiAutoKey = 0;
                    dtlObj.MaterialAutoKey = tm.iAutoKey;
                    dtlObj.iOrder = cloneD.iOrder;
                    dtlObj.iTimeMin = cloneD.iTimeMin;
                    dtlObj.sKeyMan = User.Identity.Name;
                    dtlObj.sNote = cloneD.sNote;
                    dtlObj.sOutline = cloneD.sOutline;
                    dtlObj.dKeyDate = DateTime.Now;

                    dcTraining.trTeachingMaterialDetail.InsertOnSubmit(dtlObj);
                    dcTraining.SubmitChanges();

                    cloneTM(cloneD.iAutoKey, dtlObj.iAutoKey);
                    cloneTR(cloneD.iAutoKey, dtlObj.iAutoKey);

                    //新增他的子項目
                    var selectedObjDetailNodes = (from c in selectedObjDetail
                                                  where c.ParentiAutoKey == cloneD.iAutoKey
                                                  select c).ToList();

                    foreach (var cloneNode in selectedObjDetailNodes)
                    {
                        trTeachingMaterialDetail nodeObj = new trTeachingMaterialDetail();
                        nodeObj.ParentiAutoKey = dtlObj.iAutoKey;
                        nodeObj.MaterialAutoKey = tm.iAutoKey;
                        nodeObj.iOrder = cloneNode.iOrder;
                        nodeObj.iTimeMin = cloneNode.iTimeMin;
                        nodeObj.sKeyMan = User.Identity.Name;
                        nodeObj.sNote = cloneNode.sNote;
                        nodeObj.sOutline = cloneNode.sOutline;
                        nodeObj.dKeyDate = DateTime.Now;

                        dcTraining.trTeachingMaterialDetail.InsertOnSubmit(nodeObj);
                        dcTraining.SubmitChanges();

                        cloneTM(cloneNode.iAutoKey, nodeObj.iAutoKey);
                        cloneTR(cloneNode.iAutoKey, nodeObj.iAutoKey);
                    }
                }

                gv.Rebind();
                pnlCopy.Visible = false;
                lblMsg.Text = "";
            }
        }
    }


    private void cloneTM(int cloneKey, int objKey)
    {
        var cloneTeachingMethod = (from c in dcTraining.trTeachingMaterialDetail_TeachingMethod
                                   where c.MaterialDetailAutoKey == cloneKey
                                   select c).ToList();

        foreach (var cloneTM in cloneTeachingMethod)
        {
            trTeachingMaterialDetail_TeachingMethod dtm = new trTeachingMaterialDetail_TeachingMethod();
            dtm.MaterialDetailAutoKey = objKey;
            dtm.trTeachingMethod_sCode = cloneTM.trTeachingMethod_sCode;
            dcTraining.trTeachingMaterialDetail_TeachingMethod.InsertOnSubmit(dtm);
            dcTraining.SubmitChanges();
        }
    }

    private void cloneTR(int cloneKey, int objKey)
    {
        var cloneTeachingResource = (from c in dcTraining.trTeachingMaterialDetail_TeachingResource
                                     where c.MaterialDetailAutoKey == cloneKey
                                     select c).ToList();

        foreach (var cloneTR in cloneTeachingResource)
        {
            trTeachingMaterialDetail_TeachingResource dtr = new trTeachingMaterialDetail_TeachingResource();
            dtr.MaterialDetailAutoKey = objKey;
            dtr.trTeachingResourceCode = cloneTR.trTeachingResourceCode;
            dcTraining.trTeachingMaterialDetail_TeachingResource.InsertOnSubmit(dtr);
            dcTraining.SubmitChanges();
        }

    }
    protected void btnAddMaterial_Click(object sender, EventArgs e)
    {
        Response.Redirect("trTeachMaterial.aspx");
    }
}