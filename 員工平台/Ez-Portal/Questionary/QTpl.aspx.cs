using System;
using BL;
using Telerik.Web.UI;

public partial class eTraining_Questionary_QTpl : JBWebPage
{
    //private string FileName;
    private const string tplEditUrl = @"~/Questionary/QTplEdit.aspx";

    private const string cateEditUrl = @"~/Questionary/QCategory.aspx";
    private const string qqEditUrl = @"~/Questionary/QQEdit.aspx";
    private const string tplCateRelEditUrl = @"~/Questionary/QTplCategoryRel.aspx?Id=";
    private const string setQEditUrl = @"~/Questionary/Qset.aspx?Code=";
    private const string viewTplUrl = @"~/Questionary/QViewTpl.aspx?Code=";
    private const string publishUrl = @"~/Questionary/QPublish.aspx?Code=";
    private QTpl_Repo qtplRepo = new QTpl_Repo();

    protected override void OnInit(EventArgs e)
    {
        CanCopy = true;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //btnAddTpl.Attributes["onclick"] = String.Format("return ShowInsertForm('{0}','{1}');", @"QTplEdit.aspx", "WinAdd");
        win.VisibleOnPageLoad = false;
    }

    protected void gv_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
    }

    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem || e.Item is GridHeaderItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            if (item != null)
            {
                if (item["Fillercategory"].Text.Equals("S"))
                    item["Fillercategory"].Text = "員工";
                if (item["Fillercategory"].Text.Equals("T"))
                    item["Fillercategory"].Text = "講師";
                if (item["Fillercategory"].Text.Equals("M")) //20131018增加組訓員
                    item["Fillercategory"].Text = "組訓員";
                if (item["Fillercategory"].Text.Equals("CU"))
                    item["Fillercategory"].Text = "自訂人員";
                if (item["Fillercategory"].Text.Equals("Supervisor"))
                    item["Fillercategory"].Text = "主管";
            }
        }
    }

    protected void gv_DeleteCommand(object sender, GridCommandEventArgs e)
    {
    }

    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        gv.DataSource = qtplRepo.GetAll();
    }

    protected void btnEditCate_Click(object sender, EventArgs e)
    {
        win.NavigateUrl = cateEditUrl;
        win.Height = 600;
        win.Width = 800;
        win.VisibleOnPageLoad = true;
    }

    protected void RadAjaxPanel1_AjaxRequest(object sender, AjaxRequestEventArgs e)
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

    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            if (item == null)
            {
                Show("轉型有誤!!請洽資訊人員");
            }
            //編輯樣板
            if (e.CommandName.Equals("TplEdit"))
            {
                win.NavigateUrl = tplEditUrl + @"?Id=" + item.OwnerTableView.DataKeyValues[item.ItemIndex]["Code"].ToString();
                win.Height = 700;
                win.Width = 800;
                win.VisibleOnPageLoad = true;
            }
            //關聯類別
            if (e.CommandName.Equals("RelCate"))
            {
                win.NavigateUrl = tplCateRelEditUrl + item.OwnerTableView.DataKeyValues[item.ItemIndex]["Code"].ToString();
                win.Height = 600;
                win.Width = 800;
                win.VisibleOnPageLoad = true;
            }

            if (e.CommandName.Equals("SetQ"))
            {
                QTpl qtplObj = qtplRepo.GetByPk(item.OwnerTableView.DataKeyValues[item.ItemIndex]["Code"].ToString());
                if (qtplObj.BeenUsed)
                {
                    Show("此問卷已使用，無法再增減題目");
                    return;
                }

                win.NavigateUrl = setQEditUrl + item.OwnerTableView.DataKeyValues[item.ItemIndex]["Code"].ToString();
                win.Height = 800;
                win.Width = 1000;
                win.VisibleOnPageLoad = true;
            }

            if (e.CommandName.Equals("ViewTpl"))
            {
                win.NavigateUrl = viewTplUrl + item.OwnerTableView.DataKeyValues[item.ItemIndex]["Code"].ToString();
                win.Height = 600;
                win.Width = 800;
                win.VisibleOnPageLoad = true;
            }

            if (e.CommandName.Equals("Publish"))
            {
                win.NavigateUrl = publishUrl + item.OwnerTableView.DataKeyValues[item.ItemIndex]["Code"].ToString();
                win.Height = 700;
                win.Width = 800;
                win.VisibleOnPageLoad = true;
            }
        }
    }

    protected void btnAddTpl_Click(object sender, EventArgs e)
    {
        win.NavigateUrl = tplEditUrl;
        win.Height = 600;
        win.Width = 800;
        win.VisibleOnPageLoad = true;
    }
}