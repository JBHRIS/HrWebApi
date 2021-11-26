using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_Review_TrainingGoal : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper help = new PlanHelper();
            help.setCbYear(cbxYear);
        }
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        try
        {
            //目標培育人次
            var goal = from p in dcTrain.trTrainingPlanDetail
                       join ca in dcTrain.trCategory on p.sKey equals ca.sCode
                       where p.iYear == Convert.ToInt32(cbxYear.SelectedValue)
                       group new { p, ca } by new { p.sKey, ca.sName } into gp
                       let ePeople = gp.Sum(p => p.p.iNumOfPeople)
                       select new
                       {
                           Cate = gp.Key.sName,
                           ePeople = ePeople
                       };

            Reports.TrainingGoalDataTable TrainingGoal = new Reports.TrainingGoalDataTable();

            foreach (var itm in goal)
            {
                Reports.TrainingGoalRow row = TrainingGoal.NewTrainingGoalRow();

                //去年實際培育人次
                var last1 = (from m in dcTrain.trTrainingDetailM
                             join ca in dcTrain.trCategory on m.sKey equals ca.sCode
                             where m.iYear == Convert.ToInt32(DateTime.Today.Year) //- 1
                             && ca.sName == itm.Cate
                             group new { m, ca } by new { m.sKey, ca.sName } into gp
                             let aPeople = gp.Sum(p => p.m.iStudentNum)
                             select aPeople).FirstOrDefault();

                row.Cate = itm.Cate;
                row.Goal = itm.ePeople;

                if (last1 != null)
                    row.LastA = Convert.ToInt32(last1);
                else
                    row.LastA = 0;

                TrainingGoal.AddTrainingGoalRow(row); 

            }

            if (TrainingGoal.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", TrainingGoal.CopyToDataTable()));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("Year", cbxYear.SelectedValue));

                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                AlertMsg("無資料");
            }
        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }
    }
}