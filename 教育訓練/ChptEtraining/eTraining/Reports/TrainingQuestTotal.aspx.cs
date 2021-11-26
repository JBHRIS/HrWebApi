using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Telerik.Web.UI;
using System.Collections;
using System.Data;


public partial class eTraining_Reports_TrainingQuestTotal : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            PlanHelper PlanHelper = new PlanHelper();
            PlanHelper.setCbYear(cbxYear);
            SiteHelper util = new SiteHelper();
            util.setDeptTv(tvDept);
            ReportViewer1.Reset();
            setcbxJobl();
            int a = cbxJoblB.Items.Count;
            cbxJoblB.SelectedValue = cbxJoblB.Items[1].Value;
            cbxJoblE.SelectedValue = cbxJoblB.Items[cbxJoblB.Items.Count - 2].Value;
        }
    }
    private void setcbxJobl()
    {
        List<JOBL> list = (from c in dcTrain.JOBL
                           select c).ToList();
        cbxJoblB.Items.Clear();
        cbxJoblE.Items.Clear();

        
        foreach (var c in list)
        {
            RadComboBoxItem itm = new RadComboBoxItem(c.JOB_NAME, c.JOBL1);
            RadComboBoxItem itm2 = new RadComboBoxItem(c.JOB_NAME, c.JOBL1);
            
            cbxJoblB.Items.Add(itm);
            cbxJoblE.Items.Add(itm2);
        }
        if (cbxJoblB.Items.Count > 0)
        {
            cbxJoblB.Items[0].Selected = true;
        }
        if (cbxJoblE.Items.Count > 0)
        {
            cbxJoblE.Items[0].Selected = true;
        }
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {

        //ReportViewer1.Reset();
        //ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/TrainingQuestTotal.rdlc");
        //ReportViewer1.LocalReport.DataSources.Clear();
        
        var TrainingQuestTotal = from tq in dcTrain.trTrainingQuest
                                 join ca in dcTrain.trRequirementTemplateCat on tq.sKey equals ca.sCode
                                 join co in dcTrain.trCourse on tq.trCourse_sCode equals co.sCode
                                 where tq.iYear == Convert.ToInt32(cbxYear.SelectedValue)
                                 group new { ca, co, tq } by new { ca.sName, co.sCode, Nameco = co.sName } into gp
                                 let sumP = gp.Sum(p => p.tq.iDemandIntensityP)
                                 let sumM = gp.Sum(p => p.tq.iDemandIntensityM)
                                 select new
                                 {
                                     Cat = gp.Key.sName,
                                     CoCode = gp.Key.sCode,
                                     Co = gp.Key.Nameco,
                                     iDemandIntensityP = sumP,
                                     iDemandIntensityM = sumM
                                 };

        //var TrainingQuestTotal = from CaCo in dcTrain.trCategoryCourse
        //                         join co in dcTrain.trCourse on CaCo.sCourseCode equals co.sCode
        //                         join ca in dcTrain.trCategory on CaCo.sCateCode equals ca.sCode
        //                         //join tq in dcTrain.trTrainingQuest on new { CaCo.sCateCode, CaCo.sCourseCode } equals new { tq.sKey, tq.trCourse_sCode }
        //                         join tq in dcTrain.trTrainingQuest on CaCo.sCateCode equals tq.sKey
        //                         where CaCo.sCourseCode == tq.trCourse_sCode && tq.iYear == Convert.ToInt32(cbxYear.SelectedValue)
        //                         group new { ca, co, tq } by new { ca.sName, co.sCode, Nameco = co.sName } into gp
        //                         let sumP = gp.Sum(p => p.tq.iDemandIntensityP)
        //                         let sumM = gp.Sum(p => p.tq.iDemandIntensityM)
        //                         select new
        //                         {
        //                             Cat = gp.Key.sName,
        //                             CoCode = gp.Key.sCode,
        //                             Co = gp.Key.Nameco,
        //                             iDemandIntensityP = sumP,
        //                             iDemandIntensityM = sumM
        //                         };

        //group new { ca, co, tq } by new { ca.sName, co.sCode, Nameco = co.sName } into gp
        //                       let sumP = gp.Sum(p => p.tq.iDemandIntensityP)

        //其他課程       
        var other = from c in dcTrain.trTrainingQuestCustom
                    select c;


        Reports.TrainingQuestTotalDataTable TQT = new Reports.TrainingQuestTotalDataTable();
        Reports.TrainingQuestTotalDataTable TQTP = new Reports.TrainingQuestTotalDataTable(); //個人需求前5名
        Reports.TrainingQuestTotalDataTable TQTM = new Reports.TrainingQuestTotalDataTable(); //主管核定前5名
        Reports.TrainingQuestTotalDataTable Other = new Reports.TrainingQuestTotalDataTable(); //其他課程

        List<TrainingQuestTotal> lst = new List<TrainingQuestTotal>();

        try
        {
            foreach (var itm in TrainingQuestTotal)
            {
                Reports.TrainingQuestTotalRow row = TQT.NewTrainingQuestTotalRow();
                row.sKey = itm.Cat;
                row.trCourse_sCode = itm.CoCode;
                row.trCourse_sName = itm.Co;
                row.iDemandIntensityP = itm.iDemandIntensityP.ToString();
                row.iDemandIntensityM = itm.iDemandIntensityM.ToString();
                TQT.AddTrainingQuestTotalRow(row);
            }

            int i = 0;

            foreach (var itm in TrainingQuestTotal.OrderByDescending(p => p.iDemandIntensityP))
            {
                if (i > 4)
                    break;
                Reports.TrainingQuestTotalRow row = TQTP.NewTrainingQuestTotalRow();

                row.trCourse_sName = itm.Co;
                row.iDemandIntensityP = itm.iDemandIntensityP.ToString();
                TQTP.AddTrainingQuestTotalRow(row);
                i++;
            }
            i = 0;
            foreach (var itm in TrainingQuestTotal.OrderByDescending(p => p.iDemandIntensityM))
            {
                if (i > 4)
                    break;
                Reports.TrainingQuestTotalRow row = TQTM.NewTrainingQuestTotalRow();
                row.trCourse_sName = itm.Co;
                row.iDemandIntensityM = itm.iDemandIntensityM.ToString();
                TQTM.AddTrainingQuestTotalRow(row);
                i++;
            }
            //其他課程
            foreach (var itm in other)
            {
                Reports.TrainingQuestTotalRow row = Other.NewTrainingQuestTotalRow();
                row.trCourse_sName = itm.sCourseName;
                row.iDemandIntensityP = itm.iDemandIntensityP.ToString();
                row.iDemandIntensityM = itm.iDemandIntensityM.ToString();
                Other.AddTrainingQuestTotalRow(row);
            }

            //檢查TQT是否有資料
            if (TQT.Rows.Count != 0)
            {
                ReportViewer1.Reset();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/TrainingQuestTotal.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", TQT.CopyToDataTable()));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", TQTP.CopyToDataTable()));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", TQTM.CopyToDataTable()));
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet4", Other.CopyToDataTable()));
                //ReportViewer1.LocalReport.SetParameters(new ReportParameter("Year", (int.Parse(cbxYear.SelectedValue) - 1911).ToString()));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("Year", (Convert.ToInt32(cbxYear.SelectedValue) - 1911).ToString()));
                //取得cbxYear參數,轉型方式1)int.Parse 2)Convert.ToInt32
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                throw new Exception("無年度調查資料");
                
            }


            //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", TQT.CopyToDataTable()));
            //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", TQTP.CopyToDataTable()));
            //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet3", TQTM.CopyToDataTable()));
            //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet4", Other.CopyToDataTable()));
            ////ReportViewer1.LocalReport.SetParameters(new ReportParameter("Year", (int.Parse(cbxYear.SelectedValue) - 1911).ToString()));
            //ReportViewer1.LocalReport.SetParameters(new ReportParameter("Year", (Convert.ToInt32(cbxYear.SelectedValue) - 1911).ToString()));
            ////取得cbxYear參數,轉型方式1)int.Parse 2)Convert.ToInt32
            //ReportViewer1.DataBind();
            //ReportViewer1.LocalReport.Refresh();
            ////}
        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }
    }
}