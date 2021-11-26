using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class eTraining_Admin_Plan_SurveyTemplates2 : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RadTabStrip1.SelectedIndex = 0;
            RadMultiPage1.PageViews[RadTabStrip1.SelectedTab.PageView.Index].Selected = true;
        }
    }



    protected void btnTplAdd_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        string sCode = Guid.NewGuid().ToString();
        trRequirementTemplate obj = new trRequirementTemplate();
        obj.sCode = sCode;
        obj.sName = tbTplName.Text;
        obj.dKeyDate = DateTime.Now;
        obj.sKeyMan = User.Identity.Name;

        try
        {
            dcTraining.trRequirementTemplate.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();
        }
        catch
        {
            lblMsg.Text = "資料異常，或重複輸入!!";
        }


        gvTemplate.DataBind();
        tbTplName.Text = "";
        cbTplView.DataBind();
        gvTplCat.Rebind();
    }
    protected void btnTplCatAdd_Click(object sender, EventArgs e)
    {
        lblCatMsg.Text = "";
        trRequirementTemplateCat obj = new trRequirementTemplateCat();
        string sCode = Guid.NewGuid().ToString();

        obj.sCode = sCode;
        obj.sName = tbTplCatName.Text;
        obj.dKeyDate = DateTime.Now;
        obj.sKeyMan = User.Identity.Name;

            int num = 0;
            if (int.TryParse(ntbFillMaxNum.Text, out num))
            {
                obj.iFillMaxNum = num;
            }
            else
            {
                AlertMsg("請輸入項次");
                return;
            }                  

        try
        {
            dcTraining.trRequirementTemplateCat.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();
            ntbFillMaxNum.Text = "";
            gvCat.DataBind();
            tbTplCatName.Text = "";
        }
        catch
        {
            lblCatMsg.Text = "資料異常，或重複輸入!!";
        }
    }

    protected void gvTplCat_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            RadButton btn = (RadButton)e.Item.Cells[0].FindControl("btnAddTplCat");
            int iAutoKey = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("iAutoKey"));

            string sCode = e.Item.Cells[3].Text;

            btn.CommandArgument = sCode;

            //HyperLink hl = (HyperLink)e.Item.Cells[0].FindControl("hlAddTplCat");
            //if (hl != null)
            //{
            //    hl.NavigateUrl = hl.NavigateUrl + "?code=" + sCode;
            //    hl.Attributes["onclick"] = String.Format("return ShowInsertFormByParam('{0}');", Server.UrlEncode(sCode));
            //}
        }
    }
    protected void gvTplCatDetail_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            RadButton btn = (RadButton)e.Item.Cells[0].FindControl("btnTplCatItemAdd");
            string tplCatCode = e.Item.Cells[4].Text;
            btn.CommandArgument = tplCatCode;

            //e.Item.Cells[3].Text;
            //HyperLink hl = (HyperLink)e.Item.Cells[0].FindControl("hlTplCatItemAdd");
            // int iAutoKey = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("iAutoKey"));

            //string tplCode = e.Item.Cells[4].Text;

            //if (hl != null)
            //{
            //    hl.NavigateUrl = hl.NavigateUrl + "?code=" + tplCode;
            //    hl.Attributes["onclick"] = String.Format("return ShowInsertFormByParam2('{0}','{1}');", Server.UrlEncode(tplCode),Server.UrlEncode(tplCatCode));

            //}
        }
    }

    protected void gvTemplate_ItemDeleted(object sender, GridDeletedEventArgs e)
    {
        // string key=  e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString(); 
        cbTplView.DataBind();
        gvTplCat.Rebind();


    }
    protected void btnAddTplCat_Click(object sender, EventArgs e)
    {
        lbTplCatList.DataBind();
        RadButton btn = (RadButton)sender;
        lblTplCat.Text = btn.CommandArgument;

        var data = (from c in dcTraining.trRequirementTemplate where c.sCode == lblTplCat.Text select c).FirstOrDefault();
        lblTplName.Text = "目前設定樣版：" + data.sName;

        pnTplCatView.Visible = false;
        pnTplCatAdd.Visible = true;


    }
    protected void btnAddPageTplCat_Click(object sender, EventArgs e)
    {
        //string tplCode = Request.QueryString["code"];
        string tplCode = lblTplCat.Text;

        var tpl = from c in dcTraining.trRequirementTemplate where c.sCode == tplCode select c;

        var tplData = tpl.FirstOrDefault();
        if (tplData != null)
        {
            var list = from c in dcTraining.trRequirementTemplateDetail
                       where c.Rt_sCode == tplData.sCode
                       select c;

            dcTraining.trRequirementTemplateDetail.DeleteAllOnSubmit(list);

            int order = 1;
            foreach (RadListBoxItem item in lbTplCatSelected.Items)
            {
                trRequirementTemplateDetail obj = new trRequirementTemplateDetail();

                obj.Rt_sCode = tplData.sCode;
                obj.Rtc_sCode = item.Value;
                obj.sKeyMan = User.Identity.Name;
                obj.dKeyDate = DateTime.Now;
                obj.iOrder = order++;
                dcTraining.trRequirementTemplateDetail.InsertOnSubmit(obj);
            }

            dcTraining.SubmitChanges();
            lbTplCatList.DataBind();
            lbTplCatSelected.DataBind();



            setPageTplCatDefault();


            // ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
        }
    }
    protected void btnCancelPageTplCat_Click(object sender, EventArgs e)
    {
        setPageTplCatDefault();
    }

    private void setPageTplCatDefault()
    {
        pnTplCatView.Visible = true;
        pnTplCatAdd.Visible = false;

    }


    protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
    {
        if (e.Tab.Text == "加入調查樣版類別")
        {
            setPageTplCatDefault();
        }
    }

    protected void gvCat_ItemDeleted(object sender, GridDeletedEventArgs e)
    {
        RadGrid1.Rebind();
    }
}