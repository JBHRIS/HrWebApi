using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Repo;
using System.Data.Linq;

public partial class eTraining_Manager_ManagerWrite:JBWebPage
{
    const string popWinUrl = @"~/eTraining/Teacher/ScoreStudentReport2.aspx?ID=";
    protected void Page_Load(object sender , EventArgs e)
    {
        win.VisibleOnPageLoad = false;
        if ( !IsPostBack )
        {
            DoHelper doHelper = new DoHelper();
            doHelper.setCbYear(cbxYear);
        }
    }


    protected void gv_ItemCommand(object sender , Telerik.Web.UI.GridCommandEventArgs e)
    {
        GridDataItem item = null;
        if ( e.Item is GridDataItem )
        {
            item = e.Item as GridDataItem;
        }

        if ( e.CommandName == "Score" )
        {
            win.NavigateUrl = popWinUrl + item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString();
            win.VisibleOnPageLoad = true;
         //   Response.Redirect("~/eTraining/Teacher/TrainingStudentScore2.aspx" + @"?ID=" + item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString());
        }
        if ( e.CommandName == "ScoreForReport" )
        {
            win.NavigateUrl = popWinUrl + item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString();
            win.VisibleOnPageLoad = true;
            //Response.Redirect("~/eTraining/Teacher/ScoreStudentReport2.aspx" + @"?ID=" + item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString());
        }
    }

    protected void gv_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
        int year = Convert.ToInt32(cbxYear.SelectedValue);
        DateTime bDatetime = new DateTime(year , 1 , 1);
        DateTime eDatetime = new DateTime(year , 12 , 31);

        gv.DataSource = (from c in tsmRepo.GetClassRptLostNeedManagerFillDateRange_Dlo(bDatetime , eDatetime).FindAll(p=>Juser.ManageEmpList.Contains(p.BASE.NOBR))
        //gv.DataSource = (from c in tsmRepo.GetClassRptLostNeedManagerFillDateRange_Dlo(bDatetime , eDatetime)
                         select new
                         {
                             iAutoKey = c.iAutoKey ,
                             categoryName = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName ,
                             courseName = c.trTrainingDetailM.trCourse.sName ,
                             dDateA = c.trTrainingDetailM.dDateA,
                             NameC=c.BASE.NAME_C,
                             Nobr=c.sNobr,
                             DeptName=c.BASE.BASETTS[0].DEPT1.D_NAME
                         }).ToList();
    }
    protected void cbxYear_SelectedIndexChanged(object sender , RadComboBoxSelectedIndexChangedEventArgs e)
    {

    }


    protected void RadAjaxPanel1_AjaxRequest(object sender , AjaxRequestEventArgs e)
    {
        if ( e.Argument == "Rebind" )
        {
            gv.Rebind();
        }
        else if ( e.Argument == "RebindAndNavigate" )
        {
            gv.Rebind();
        }
    }
}