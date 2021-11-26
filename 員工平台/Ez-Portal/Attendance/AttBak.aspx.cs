using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class Attendance_AttBak : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    void setValue(string filename, string sheet)
    {
        // System.Data.OleDb.OleDbDataAdapter daExcel = new System.Data.OleDb.OleDbDataAdapter("Select * From [" + sheet + "]", ExcelConn);
        try
        {
            System.Data.DataTable tbExcel = CNPOI.RenderDataTableFromExcel(filename, 0, 0);
            //    daExcel.Fill(tbExcel);

            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("text", typeof(string));
            dt.Columns.Add("values", typeof(string));

            for (int i = 0; i < tbExcel.Columns.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["values"] = tbExcel.Columns[i].ToString();
                row["text"] = tbExcel.Rows[0][i].ToString();
                dt.Rows.Add(row);
            }

            ddlJob.DataSource = dt;
            ddlJob.DataTextField = "text";
            ddlJob.DataValueField = "values";
            ddlJob.DataBind();
            ddeff.DataSource = dt;
            ddeff.DataTextField = "text";
            ddeff.DataValueField = "values";
            ddeff.DataBind();
            ddorder.DataSource = dt;
            ddorder.DataTextField = "text";
            ddorder.DataValueField = "values";
            ddorder.DataBind();


            //	btnSubmit.Enabled = true;
            Session.Add("ExcelDT", tbExcel);
            Session["dt"] = dt;
            GridView1.DataSource = tbExcel;
            GridView1.DataBind();
        }
        catch
        {
            JB.WebModules.Message.Show("上傳班表EXCEL檔案格式錯誤！系統只接受97-2003 EXCEL版本檔案！");
            showMsg.Text = "";
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string filename = "";
        string _filename = "";
        string conn = "";
        filename = DateTime.Now.Ticks.ToString("X") + JbUser.NOBR.Trim() + ".xls";

        if (!txtUpload.HasFile)
        {
            showMsg.Text = "未指定要上傳的檔案";
            return;
        }
        try
        {



            txtUpload.PostedFile.SaveAs(@"c:\temp\" + filename);
            _filename = txtUpload.FileName;
            showMsg.ForeColor = Color.Blue;
            showMsg.Text = "上傳成功！";

            //    Excel.Application ExcelObj = new Excel.Application();
            ////	ExcelObj.Visible = true;
            //    Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(
            //        @"E:\Upload\" + filename, 0, true, 5,
            //        "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false,
            //        0, true);
            //    filename = DateTime.Now.Ticks.ToString("X") + nobr + ".xls";
            //    theWorkbook.SaveAs(@"E:\Upload\" + filename, Excel.XlFileFormat.xlWorkbookNormal,
            //        null, null, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, null, null);



            //    theWorkbook = null;
            //vExcelObj = null;


            conn = "Provider=Microsoft.Jet.OLEDB.4.0;" +
               "Data Source=" + @"c:\temp\" + filename + ";" +
                //			"Data Source=" + Request.PhysicalApplicationPath + @"Upload\" + filename + ";" +
                //						@"Data Source=C:\Inetpub\wwwroot\ezpms\Upload\8C857B938617212.xls;" +
                //E:\webhr_Data\ezpms\Upload\8C857B938617212.xls
                               "Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
            Session.Add("ExcelConn", conn);
        }
        catch (System.Exception ex)
        {
            showMsg.ForeColor = Color.Red;
            showMsg.Text = "上傳失敗！  原因：" + ex.ToString();
            return;
        }
        //System.Data.OleDb.OleDbConnection ExcelConn = new System.Data.OleDb.OleDbConnection(conn);
        try
        {
        //    ArrayList al = new ArrayList();
        //    if (ExcelConn.State == ConnectionState.Closed)
        //        ExcelConn.Open();

        //    System.Data.DataTable schemaDt = ExcelConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
        //    for (int i = 0; i < schemaDt.Rows.Count; i++)
        //    {
        //        al.Add(schemaDt.Rows[i].ItemArray[2].ToString());
        //        Menu1.Items.Add(new System.Web.UI.WebControls.MenuItem(schemaDt.Rows[i].ItemArray[2].ToString(), schemaDt.Rows[i].ItemArray[2].ToString()));
        //    }
        //    setValue(ExcelConn, Menu1.Items[0].Value);

        //    Menu1.Items[0].Selected = true;

        //    if (ExcelConn.State == ConnectionState.Open)
        //        ExcelConn.Close();

        setValue(@"c:\temp\" + filename,"");

        }
        catch (Exception ex)
        {
            //showMsg.ForeColor = Color.Red;
          //  showMsg.Text = ExcelConn.ConnectionString + "     " + ex.ToString();
         //   return;
        }
        finally
        {
          //  ExcelConn.Close();
        }
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {

    }

    void setAttend(int year, int month, int day, string nobr, string rote)
    {
        AttendDsTableAdapters.ATTEND1TableAdapter attad = new AttendDsTableAdapters.ATTEND1TableAdapter();
        AttendDs.ATTEND1DataTable attdt = new AttendDs.ATTEND1DataTable();
        AttendDs.ATTEND1Row attrow = attdt.NewATTEND1Row();
        attrow.NOBR = nobr;
        attrow.ROTE = rote;
        attrow.ADATE = new DateTime(year, month, day);
        attrow.KEY_DATE = DateTime.Now;
        attrow.KEY_MAN = JbUser.NOBR;
        attrow.LATE_MINS = 0;
        attrow.E_MINS = 0;
        attrow.ADJ_CODE = "";
        attrow.CANT_ADJ = false;
        attrow.SER = 0;
        attrow.NIGHT_HRS = 0;
        attrow.FOODAMT = 0;
        attrow.FOODSALCD = "";
        attrow.FORGET = 0;
        attrow.ATT_HRS = 0;
        attrow.NIGAMT = 0;
        attrow.ABS = false;

        attdt.AddATTEND1Row(attrow);
        attad.Update(attdt);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["ExcelDT"] == null)
        {
            JB.WebModules.Message.Show("請先上傳班表EXCEL檔案");
            return;
        }


        System.Data.DataTable ExcelDT = (System.Data.DataTable)Session["ExcelDT"];

        AttendDsTableAdapters.ATTBAKTableAdapter tmad = new AttendDsTableAdapters.ATTBAKTableAdapter();

        string yymm = "";//
        try
        {
            tb_year.Text = ExcelDT.Columns[0].ColumnName.ToString().Substring(0, 4);
            tb_month.Text = ExcelDT.Columns[0].ColumnName.ToString().Substring(5);
            tb_month.Text = tb_month.Text.Trim().Substring(0, tb_month.Text.Trim().Length - 1);

            yymm = tb_year.Text.Trim() + tb_month.Text.Trim().PadLeft(2, '0');
        }
        catch
        {
            JB.WebModules.Message.Show("上傳年月格式錯誤，例：2010/6月");
            return;

        }


        AttendDsTableAdapters.QueriesTableAdapter qt = new AttendDsTableAdapters.QueriesTableAdapter();
       

        for (int i = 0; i < ExcelDT.Rows.Count; i++)
        {
            AttendDs.ATTBAKDataTable tmdt = new AttendDs.ATTBAKDataTable();
            qt.DeleteAttBakQuery(decimal.Parse(tb_year.Text), decimal.Parse(tb_month.Text), ExcelDT.Rows[i][0].ToString().Trim());



            for (int j = 1; j <= 31; j++)
            {
                try
                {
                    if (ExcelDT.Rows[i][j + 1].ToString().Trim().Length == 0)
                        continue;

                    if(!ExcelDT.Rows[i][j + 1].ToString().Trim().ToUpper().Equals("V"))
                        continue;

                    AttendDs.ATTBAKRow tmrow = tmdt.NewATTBAKRow();
                    tmrow.NOBR = ExcelDT.Rows[i][0].ToString().Trim();
                    tmrow.ADATE = DateTime.Parse(tb_year.Text + "/" + tb_month.Text + "/" + j);
                    tmrow.KEY_MAN = JbUser.NOBR;
                    tmrow.KEY_DATE = DateTime.Now;

                    tmdt.AddATTBAKRow(tmrow);
                }
                catch { }

            }




            tmad.Update(tmdt);
        }
        JB.WebModules.Message.Show("匯入" + ExcelDT.Rows[0][0].ToString() + "班表完成！");
        showMsg.Text = "匯入" + ExcelDT.Rows[0][0].ToString() + "班表完成！";
    }
}
