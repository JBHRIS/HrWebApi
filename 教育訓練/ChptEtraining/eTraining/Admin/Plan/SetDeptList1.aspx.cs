using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Admin_Plan_SetDeptList1:JBWebPage
{
    private dcTrainingDataContext trainingDC = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);
        if (!IsPostBack)
        {
            PlanHelper trainingPlan = new PlanHelper();
            trainingPlan.setCbYear(cbYear);

            bindWindow();
            RadButton3.Attributes["onclick"] = String.Format("return ShowInsertForm();");
        }
        this.Title = "調查人員清單";
    }


    private void bindWindow()
    {
        RadWindowManager1.Windows[0].Title = cbYear.SelectedValue + " 年度";
    }


    protected void cbYear_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gv.DataBind();
        bindWindow();
    }

    protected void RadAjaxManager1_AjaxRequest1(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
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
        if (e.CommandName.Equals("Del"))
        {
            GridDataItem item = e.Item as GridDataItem;
            QuestDept_Repo qdRepo = new QuestDept_Repo();
            QuestDept qdObj= qdRepo.GetByPk(Convert.ToInt32(item["Id"].Text));
            qdRepo.Delete(qdObj);

            QuestDeptDetail3_Repo qdd3Repo = new QuestDeptDetail3_Repo(qdRepo.dc);
            List<QuestDeptDetail3> qdd3List= qdd3Repo.GetByQuestDeptId(qdObj.Id);
            foreach (var q in qdd3List)
            {
                qdd3Repo.Delete(q);
            }

            qdRepo.Save();
            gv.Rebind();
        }
    }
}