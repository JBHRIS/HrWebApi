using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
using Telerik.Web.UI;
using System.IO;

public partial class eTraining_Questionary_QTpl : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    //private string FileName;
    const string tplEditUrl = @"~/eTraining/Questionary/QTplEdit.aspx";
    const string cateEditUrl = @"~/eTraining/Questionary/QCategory.aspx";
    const string qqEditUrl = @"~/eTraining/Questionary/QQEdit.aspx";
    const string tplCateRelEditUrl = @"~/eTraining/Questionary/QTplCategoryRel.aspx?Id=";
    const string setQEditUrl = @"~/eTraining/Questionary/Qset.aspx?Code=";
    const string viewTplUrl = @"~/eTraining/Questionary/QViewTpl.aspx?Code=";
    private QTpl_Repo qtplRepo = new QTpl_Repo();
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
                    item["Fillercategory"].Text = "學員";
                if (item["Fillercategory"].Text.Equals("T"))
                    item["Fillercategory"].Text = "講師";
                if (item["Fillercategory"].Text.Equals("CU"))
                    item["Fillercategory"].Text = "自訂人員";
            }
            
        }
    }


    protected void gv_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        string sCode = (e.Item as GridDataItem).GetDataKeyValue("sCode").ToString();

        //刪除中分類的關聯
        var check = from s in dcTraining.qQuestionaryS
                    where s.sCode == sCode
                    select s;

        dcTraining.qQuestionaryS.DeleteAllOnSubmit(check);

        var r = dcTraining.qQuestionaryM.Where(p => p.sCode == sCode).FirstOrDefault();
        dcTraining.qQuestionaryM.DeleteOnSubmit(r);
        dcTraining.SubmitChanges();
    }

    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        gv.DataSource = qtplRepo.GetAll();
    }
    protected void btnEditCate_Click(object sender, EventArgs e)
    {
        win.NavigateUrl = cateEditUrl ;
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
                win.NavigateUrl = tplEditUrl +@"?Id="+ item.OwnerTableView.DataKeyValues[item.ItemIndex]["Code"].ToString();
                win.Height = 600;
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
                QTpl qtplObj= qtplRepo.GetByPk(item.OwnerTableView.DataKeyValues[item.ItemIndex]["Code"].ToString());
                if (qtplObj.BeenUsed)
                {
                    Show("此問卷已使用，無法再增減題目");
                    return;
                }

                win.NavigateUrl = setQEditUrl + item.OwnerTableView.DataKeyValues[item.ItemIndex]["Code"].ToString();
                win.Height = 600;
                win.Width = 800;
                win.VisibleOnPageLoad = true;
            }

            if ( e.CommandName.Equals("ViewTpl") )
            {
                win.NavigateUrl = viewTplUrl + item.OwnerTableView.DataKeyValues[item.ItemIndex]["Code"].ToString();
                win.Height = 600;
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