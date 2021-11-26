using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
//using Telerik

public partial class eTraining_Reports_Design_TeachingMaterial : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                int key=0;

                if(Int32.TryParse(Request.QueryString["ID"],out key))
                {
                    loadRpt(key);
                }
            }
        }
    }

         private void loadRpt(int key){
                        
            //ReportViewer1.Reset();
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/Design/TeachingMaterial.rdlc");
            //ReportViewer1.LocalReport.DataSources.Clear();

            //教案課程目標＆具體目標
            var TeachingMaterial = from t in dcTrain.trTeachingMaterial
                                   join co in dcTrain.trCourse on t.trCourse_sCode equals co.sCode
                                   where t.iAutoKey == key
                                   select new
                                   {
                                       CourseName = co.sName,
                                       CoursePolicy = t.sCoursePolicy,
                                       CourseContent = t.sCourseExpect
                                   };

            //教案大綱、重點內容
            DesignHelper hp = new DesignHelper();         
            DataTable dt = hp.getTeachingMaterialDetail(key);

            

            //new課程目標＆具體目標datatable
            Reports.TeachingMaterialDataTable TML = new Reports.TeachingMaterialDataTable();
            //new教案大綱、重點內容datatable
            Reports.TeachingMaterialDetailDataTable TMDL = new Reports.TeachingMaterialDetailDataTable();

            try
            {
                //將課程目標＆具體目標資料填入
                foreach (var itm in TeachingMaterial)
                {
                    Reports.TeachingMaterialRow row = TML.NewTeachingMaterialRow();
                    
                    row.CourseName = itm.CourseName;
                    row.CoursePolicy = itm.CoursePolicy;
                    row.Content = itm.CourseContent;
                    TML.AddTeachingMaterialRow(row);
                }

                //將教案大綱、重點內容資料填入
                foreach (DataRow row in dt.Rows)
                {
                    Reports.TeachingMaterialDetailRow row1 = TMDL.NewTeachingMaterialDetailRow();
                    row1.A1 = row["A1"].ToString();
                    row1.A2 = row["A2"].ToString();
                    row1.A3 = row["A3"].ToString();
                    row1.A4 = row["A4"].ToString();
                    row1.A5 = row["A5"].ToString();
                    row1.A6 = row["A6"].ToString();
                    TMDL.AddTeachingMaterialDetailRow(row1);
                }

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("尚未建立教案資料");
                }

                if (TML.Rows.Count != 0)
                {
                    //增加資料來源

                    ReportViewer1.Reset();
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"~/eTraining/Reports/Design/TeachingMaterial.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear(); 
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("TeachingMaterial", TML.Copy()));
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("TeachingMaterialDetail", TMDL.CopyToDataTable()));
                    ReportViewer1.DataBind();
                    ReportViewer1.LocalReport.Refresh();

                }
                else
                {
                    throw new Exception("無教案資料");
                }
            }
            catch (Exception ex)
            {
                AlertMsg(ex.Message);

            }


        
        }
         //protected void gv_SelectedIndexChanged(object sender, EventArgs e)
         //{
         //    int key = Convert.ToInt32(gv.SelectedValue);
         //    loadRpt(key);

         //}
         protected void btnGoBack_Click(object sender, EventArgs e)
         {
             if (ViewState["URL"] != null)
             {
                 Response.Redirect(ViewState["URL"].ToString());
             }
         }
}