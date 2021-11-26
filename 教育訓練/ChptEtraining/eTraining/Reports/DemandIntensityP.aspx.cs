using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_DemandIntensityP : System.Web.UI.Page
{
    dcTrainingDataContext dc = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReportViewer1.Reset();
        }
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        if (RadComboBox1.SelectedIndex == 0)
        {
            ReportViewer1.Reset();
            ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/Report.rdlc");
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/testP.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();

            var DemandInensityP1 = from a in dc.trTrainingQuest
                                   join b in dc.trCategoryCourse on a.sKey equals b.sCateCode
                                   join c in dc.trCategory on b.sCateCode equals c.sCode
                                   join d in dc.BASETTS on a.sNobr equals d.NOBR
                                   join f in dc.BASE on d.NOBR equals f.NOBR
                                   where Convert.ToDateTime(DateTime.Today) >= d.ADATE && Convert.ToDateTime(DateTime.Today) <= d.DDATE
                                   && a.trCourse_sCode == b.sCourseCode
                                   select new
                                   {
                                       DEPT = d.DEPT,
                                       Name = f.NAME_C,
                                       skey = c.sCode,
                                       trCourse_sCode = b.sCourseCode,
                                       DemandIntensityp = a.iDemandIntensityP,
                                       nobr = a.sNobr
                                   };

            Reports.DemandIntensityPDataTable aa = new Reports.DemandIntensityPDataTable();
            //將aa宣告為DataTableClass,就不需再自行newClass

            foreach (var itm in DemandInensityP1)
            {
                var rep = aa.FindByDeptNobr(itm.DEPT, itm.nobr);
                //找到主鍵重複的資料列
                if (rep != null)
                {

                    if (itm.skey == "A")
                    {
                        rep["A" + itm.trCourse_sCode.Substring(2, 1)] = itm.DemandIntensityp;
                        //找到datatable欄為A1的值填入,若有需要做累加動作"+="
                    }
                    else if (itm.skey == "B")
                    {
                        rep["B" + itm.trCourse_sCode.Substring(2, 1)] = itm.DemandIntensityp;
                    }
                    else if (itm.skey == "C")
                    {
                        rep["C" + itm.trCourse_sCode.Substring(2, 1)] = itm.DemandIntensityp;
                    }
                    else if (itm.skey == "D")
                    {
                        rep["D" + itm.trCourse_sCode.Substring(2, 1)] = itm.DemandIntensityp;
                    }
                }
                else
                {
                    Reports.DemandIntensityPRow row = aa.NewDemandIntensityPRow();
                    //若沒有重複資料列則再new一個row,將下列值填入row裡
                    row.Nobr = itm.nobr;
                    row.Dept = itm.DEPT;
                    row.sKey = itm.Name;
                    row.trCourse_sCode = itm.trCourse_sCode;
                    row.Name = itm.Name;
                    if (itm.skey == "A")
                    {
                        row["A" + itm.trCourse_sCode.Substring(2, 1)] = itm.DemandIntensityp;
                    }
                    else if (itm.skey == "B")
                    {
                        row["B" + itm.trCourse_sCode.Substring(2, 1)] = itm.DemandIntensityp;
                    }
                    else if (itm.skey == "C")
                    {
                        row["C" + itm.trCourse_sCode.Substring(2, 1)] = itm.DemandIntensityp;
                    }
                    else if (itm.skey == "D")
                    {
                        row["D" + itm.trCourse_sCode.Substring(2, 1)] = itm.DemandIntensityp;
                    }
                    aa.AddDemandIntensityPRow(row);
                    //將row的值新增到aa
                }
                //row.iDemandIntensityP = itm.DemandIntensityp;                
            }
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", (DataTable)aa));
            //若aa不轉型程式無法判定型別，轉型方法:1)aa as DataTable 2)(DataTable)aa 3)aa.CopyToDataTable 
            ReportViewer1.DataBind();
            ReportViewer1.LocalReport.Refresh();
        }






    }
}