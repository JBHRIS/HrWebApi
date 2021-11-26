using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_RptYearPlan : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReportViewer1.Reset();
            PlanHelper PlanHelper = new PlanHelper();
            PlanHelper.setCbYear(cbxYear);
        }
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        ReportViewer1.Reset();
        ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/RptYearPlan.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();

        var YearPlan1 = from a in dcTrain.trTrainingPlanDetail
                        //join Caco in dcTrain.trCategoryCourse on new {a.sKey,a.trCourse_sCode } equals new {Caco.sCateCode,Caco.sCourseCode }
                        //join Caco in dcTrain.trCategoryCourse on a.sKey equals Caco.sCateCode
                        join b in dcTrain.trCategory on a.sKey equals b.sCode
                        join c in dcTrain.trCourse on a.trCourse_sCode equals c.sCode

                        //left join用法
                        join m in dcTrain.trTrainingPlanDetailManager on a.iAutoKey equals m.iPlanDetailAutoKey into mm
                        from m in mm.DefaultIfEmpty()

                        join bb in dcTrain.BASE on m.sPersonInCharge equals bb.NOBR into bb2
                        from bb in bb2.DefaultIfEmpty()

                        where a.iYear == Convert.ToInt32(cbxYear.SelectedValue)

                        select new { sKey = b.sName, trCourse_sCode = c.sName, iMonth = a.iMonth, iMins = a.iMins, iAmt = a.iAmt, iPeople = a.iNumOfPeople, sPersonInCharge = bb.NAME_C };

        var YearPlan = from a1 in dcTrain.trCategory
                       join a2 in dcTrain.trCategory on a1.sCode equals a2.sParentCode
                       join caco in dcTrain.trCategoryCourse on a2.sCode equals caco.sCateCode
                       join co in dcTrain.trCourse on caco.sCourseCode equals co.sCode
                       join p in dcTrain.trTrainingPlanDetail on co.sCode equals p.trCourse_sCode
                       where a1.sParentCode == "ROOT" && p.iYear == Convert.ToInt32(cbxYear.SelectedValue)
                       group new { a1, a2, p } by new { a1.sCode, a1.sName, sName1 = a2.sName, p.iMonth, p.iMins, p.iNumOfPeople, p.iAmt } into gp
                       select new
                       {
                           Code = gp.Key.sCode,
                           Root = gp.Key.sName,
                           Cate = gp.Key.sName1,
                           Month = gp.Key.iMonth,
                           Mins = gp.Key.iMins / 60,
                           Peoplo = gp.Key.iNumOfPeople,
                           Amt = gp.Key.iAmt

                       };


        Reports.YearPlan2DataTable aa = new Reports.YearPlan2DataTable();

        //foreach (var itm in YearPlan1)
        //{
        //    //找是否有同樣的課程
        //    var rep = aa.FindBysKeytrCourse_sCode(itm.sKey, itm.trCourse_sCode);

        //    if (rep != null)
        //    {
        //        //rep.iHours += itm.iHours;
        //        rep.iHours += itm.iMins;
        //        rep.iPeople += itm.iPeople;
        //        rep.iAmt += itm.iAmt;
        //        rep["M" + itm.iMonth.ToString()] = "O";

        //        if (itm.sPersonInCharge != null)
        //        {
        //            if (!rep.sPersonInCharge.Contains(itm.sPersonInCharge))
        //                rep.sPersonInCharge += itm.sPersonInCharge;
        //        }



        //    }
        //    else
        //    {
        //        Reports.YearPlan2Row row = aa.NewYearPlan2Row();
        //        row.sKey = itm.sKey;
        //        row.trCourse_sCode = itm.trCourse_sCode;
        //        //row.iHours = itm.iHours;
        //        row.iHours = itm.iMins;
        //        row.iPeople = itm.iPeople;
        //        row.iAmt = itm.iAmt;
        //        row["M" + itm.iMonth.ToString()] = "O";
        //        row.sPersonInCharge = "";

        //        if (itm.sPersonInCharge != null)
        //        {
        //            row.sPersonInCharge = itm.sPersonInCharge;
        //        }

        //        aa.AddYearPlan2Row(row);
        //    }
        //}
        try
        {

            foreach (var itm in YearPlan)
            {
                //找是否有同樣的課程
                var rep = aa.FindBysKeytrCourse_sCode(itm.Root, itm.Cate);

                if (rep != null)
                {
                    //rep.iHours += itm.iHours;
                    rep.iHours += itm.Mins;
                    rep.iPeople += itm.Peoplo;
                    rep.iAmt += itm.Amt;
                    rep["M" + itm.Month.ToString()] = "O";

                    //if (itm.sPersonInCharge != null)
                    //{
                    //    if (!rep.sPersonInCharge.Contains(itm.sPersonInCharge))
                    //        rep.sPersonInCharge += itm.sPersonInCharge;
                    //}
                }
                else
                {
                    Reports.YearPlan2Row row = aa.NewYearPlan2Row();
                    row.sKey = itm.Root;
                    row.trCourse_sCode = itm.Cate;
                    //row.iHours = itm.iHours;
                    row.iHours = itm.Mins;
                    row.iPeople = itm.Peoplo;
                    row.iAmt = itm.Amt;
                    row["M" + itm.Month.ToString()] = "O";
                    row.sPersonInCharge = "";


                    aa.AddYearPlan2Row(row);
                }
            }

            if (aa.Rows.Count != 0)
            {

                //ReportViewer1.ZoomMode = ZoomMode.Percent;
                //ReportViewer1.ZoomPercent = 100;
                //reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", aa.CopyToDataTable()));
                ReportViewer1.LocalReport.SetParameters(new ReportParameter("Year", cbxYear.SelectedValue));
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();

            }
            else
            {
                throw new Exception("無排定月份工作計畫");
            }
        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }

    }
}