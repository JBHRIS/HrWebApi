using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_Admin_Do_TrainingCardGoal : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper planHelper = new PlanHelper();
            planHelper.setCbYear(cbxYear);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
                var cg = (from c in dcTrain.trTrainingCardGoal
                   where
                       c.iYear == Convert.ToInt32(cbxYear.SelectedValue) && c.iOJTTemplateCode == cbxOjt.SelectedValue
                   select c).FirstOrDefault();

                if (cg != null)
                {
                    if (ntbG1.Value.HasValue)                    
                        cg.iMonth1 = Convert.ToInt32(ntbG1.Value);                    
                    else                    
                        cg.iMonth1 = 0;

                    if ( ntbG2.Value.HasValue )
                        cg.iMonth2 = Convert.ToInt32(ntbG2.Value);
                    else
                        cg.iMonth2 = 0;

                    if ( ntbG3.Value.HasValue )
                        cg.iMonth3 = Convert.ToInt32(ntbG3.Value);
                    else
                        cg.iMonth3 = 0;

                    if ( ntbG4.Value.HasValue )
                        cg.iMonth4 = Convert.ToInt32(ntbG4.Value);
                    else
                        cg.iMonth4 = 0;

                    if ( ntbG5.Value.HasValue )
                        cg.iMonth5 = Convert.ToInt32(ntbG5.Value);
                    else
                        cg.iMonth5 = 0;

                    if ( ntbG6.Value.HasValue )
                        cg.iMonth6 = Convert.ToInt32(ntbG6.Value);
                    else
                        cg.iMonth6 = 0;

                    if ( ntbG7.Value.HasValue )
                        cg.iMonth7 = Convert.ToInt32(ntbG7.Value);
                    else
                        cg.iMonth7 = 0;

                    if ( ntbG8.Value.HasValue )
                        cg.iMonth8 = Convert.ToInt32(ntbG8.Value);
                    else
                        cg.iMonth8 = 0;

                    if ( ntbG9.Value.HasValue )
                        cg.iMonth9 = Convert.ToInt32(ntbG9.Value);
                    else
                        cg.iMonth9 = 0;

                    if ( ntbG10.Value.HasValue )
                        cg.iMonth10 = Convert.ToInt32(ntbG10.Value);
                    else
                        cg.iMonth10 = 0;

                    if ( ntbG11.Value.HasValue )
                        cg.iMonth11 = Convert.ToInt32(ntbG11.Value);
                    else
                        cg.iMonth11 = 0;    

                    if ( ntbG12.Value.HasValue )
                        cg.iMonth12 = Convert.ToInt32(ntbG12.Value);
                    else
                        cg.iMonth12 = 0;

                    cg.iAvg = (cg.iMonth1 + cg.iMonth2 + cg.iMonth3 + cg.iMonth4 + cg.iMonth5 + cg.iMonth6
                        + cg.iMonth7 + cg.iMonth8 + cg.iMonth9 + cg.iMonth10 + cg.iMonth11 + cg.iMonth12) / 12;

                    dcTrain.SubmitChanges();
                }
    }

    private void loadData()
    {
        if ( cbxYear.SelectedItem == null || cbxOjt.SelectedItem == null )
            return;

        trTrainingCardGoal objCardG;

        var cg = (from c in dcTrain.trTrainingCardGoal
                  where
                      c.iYear == Convert.ToInt32(cbxYear.SelectedValue) && c.iOJTTemplateCode == cbxOjt.SelectedValue
                  select c).FirstOrDefault();

        if ( cg == null )
        {
            int year = Convert.ToInt32(cbxYear.SelectedValue);
            string ojbTpl = cbxOjt.SelectedValue;
            trTrainingCardGoal obj = new trTrainingCardGoal();
            obj.iOJTTemplateCode = ojbTpl;
            obj.iYear = year;
            obj.iMonth1 = 0;
            obj.iMonth2 = 0;
            obj.iMonth3 = 0;
            obj.iMonth4 = 0;
            obj.iMonth5 = 0;
            obj.iMonth6 = 0;
            obj.iMonth7 = 0;
            obj.iMonth8 = 0;
            obj.iMonth9 = 0;
            obj.iMonth10 = 0;
            obj.iMonth11 = 0;
            obj.iMonth12 = 0;
            obj.iAvg = 0;
            obj.dKeyDate = DateTime.Now;
            obj.sKeyMan = User.Identity.Name;
            dcTrain.trTrainingCardGoal.InsertOnSubmit(obj);
            dcTrain.SubmitChanges();

            objCardG = obj;
        }
        else
        {
            objCardG = cg;
        }

        ntbG1.Text = objCardG.iMonth1.Value.ToString();
        ntbG2.Text = objCardG.iMonth2.Value.ToString();
        ntbG3.Text = objCardG.iMonth3.Value.ToString();
        ntbG4.Text = objCardG.iMonth4.Value.ToString();
        ntbG5.Text = objCardG.iMonth5.Value.ToString();
        ntbG6.Text = objCardG.iMonth6.Value.ToString();
        ntbG7.Text = objCardG.iMonth7.Value.ToString();
        ntbG8.Text = objCardG.iMonth8.Value.ToString();
        ntbG9.Text = objCardG.iMonth9.Value.ToString();
        ntbG10.Text = objCardG.iMonth10.Value.ToString();
        ntbG11.Text = objCardG.iMonth11.Value.ToString();
        ntbG12.Text = objCardG.iMonth12.Value.ToString();

    }

    protected void sdsGV_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void sdsGV_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
    }
    protected void btnCancel_Click(object sender , EventArgs e)
    {
        loadData();   
    }
    protected void cbxYear_DataBound(object sender , EventArgs e)
    {
        loadData();
    }
    protected void cbxOjt_SelectedIndexChanged(object sender , Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        loadData();
    }
    protected void cbxYear_SelectedIndexChanged(object sender , Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        loadData();
    }
    protected void cbxOjt_DataBound(object sender , EventArgs e)
    {
        loadData();
    }
}