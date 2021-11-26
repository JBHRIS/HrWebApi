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
 
using System.IO;
using System.Collections.Generic;
using JBHR.BLL.Att;
using BL;
using JBHRModel;
using System.Linq;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
public partial class Attendance_ImportRote : JBWebPage
{
    private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    private const int ExcelNobrCol = 1;
    private List<int> Data_paList = new List<int>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            Wizard1.ActiveStepIndex = 0;
            ddl_year.SelectedValue = DateTime.Now.Year.ToString();
            ddl_month.SelectedValue = DateTime.Now.Month.ToString().PadLeft(2, '0');
        }

    }


    void setValue1(string filename, string sheet)
    {
   //     System.Data.OleDb.OleDbDataAdapter daExcel = new System.Data.OleDb.OleDbDataAdapter("Select * From [" + sheet + "]", ExcelConn);
        try
        {
            System.Data.DataTable tbExcel = CNPOI.RenderDataTableFromExcel(filename, 0, 0);
          //  daExcel.Fill(tbExcel);

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
        catch (Exception ex)
        {
            JB.WebModules.Message.Show("上傳班表EXCEL檔案格式錯誤！系統只接受97-2003 EXCEL版本檔案！");
            showMsg.Text = ex.Message;
        }

    }
    void setValue(string ExcelConn, string sheet)
    {
         System.Data.OleDb.OleDbDataAdapter daExcel = new System.Data.OleDb.OleDbDataAdapter("Select * From [" + sheet + "]", ExcelConn);
        try
        {
            System.Data.DataTable tbExcel = new DataTable(); // CNPOI.RenderDataTableFromExcel(filename, 0, 0);
                daExcel.Fill(tbExcel);

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
        catch (Exception ex)
        {
            JB.WebModules.Message.Show("上傳班表EXCEL檔案格式錯誤！系統只接受97-2003 EXCEL版本檔案！");
            showMsg.Text = ex.Message;
        }

    }

    //上傳資料後，檢查excel是否有key錯班別
    private bool isExcelDTError(out String msg)
    {        
        List<string> skipSymbol = new List<string>();
        skipSymbol.Add("");
        skipSymbol.Add("0");
        msg = "";

        System.Data.DataTable ExcelDT = (System.Data.DataTable)Session["ExcelDT"];
        
        AttendDsTableAdapters.ROTETableAdapter rote_adapter = new AttendDsTableAdapters.ROTETableAdapter();
        AttendDs.ROTEDataTable roteDT= rote_adapter.GetData();

        for (int i = 0; i < ExcelDT.Rows.Count; i++)
        {
            if (ExcelDT.Rows[i][1].ToString().Trim().Length == 0)
                continue;

            if (i == 0)
                continue;

            //每月天數(欄位)扣掉前面三行
            int colCount = ExcelDT.Columns.Count - 3;

            for (int j = 1; j <= colCount; j++)
            {
                
                    if (skipSymbol.Contains(ExcelDT.Rows[i][j + 2].ToString().ToUpper().Trim()))  
                        continue;

                    AttendDs.ROTERow roteRow= roteDT.FindByROTE(ExcelDT.Rows[i][j + 2].ToString().ToUpper().Trim());
                    if (roteRow == null)
                    {
                        msg = "工號:" + ExcelDT.Rows[i][1].ToString() + "無此"+ExcelDT.Rows[i][j + 2].ToString().ToUpper().Trim()+"班表";
                        return true;
                    }                
            }
        }

        return false;
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

            //  
            conn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
               "Data Source=" + @"c:\temp\" + filename + ";" +
                //			"Data Source=" + Request.PhysicalApplicationPath + @"Upload\" + filename + ";" +
                //						@"Data Source=C:\Inetpub\wwwroot\ezpms\Upload\8C857B938617212.xls;" +
                //E:\webhr_Data\ezpms\Upload\8C857B938617212.xls
                               "Extended Properties='Excel 12.0;HDR=NO;IMEX=1'";
            Session.Add("ExcelConn", conn);
        }
        catch (System.Exception ex)
        {
            showMsg.ForeColor = Color.Red;
            showMsg.Text = "上傳失敗！  原因：" + ex.ToString();
            return;
        }


        System.Data.OleDb.OleDbConnection ExcelConn = new System.Data.OleDb.OleDbConnection(conn);
        try
        {
            ArrayList al = new ArrayList();
            if (ExcelConn.State == ConnectionState.Closed)
                ExcelConn.Open();

            Menu1.Items.Clear();
            System.Data.DataTable schemaDt = ExcelConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            for (int i = 0; i < schemaDt.Rows.Count; i++)
            {
                al.Add(schemaDt.Rows[i].ItemArray[2].ToString());
                Menu1.Items.Add(new System.Web.UI.WebControls.MenuItem(schemaDt.Rows[i].ItemArray[2].ToString(), schemaDt.Rows[i].ItemArray[2].ToString()));
            }
           // setValue1(@"c:\temp\" + filename, "");

             setValue(conn, Menu1.Items[0].Text);

             string errMsg;
             if (isExcelDTError(out errMsg))
             {
                 showMsg.ForeColor = Color.Red;
                 showMsg.Text = errMsg;
                 setControlDefault();
                 return;
             }


            Menu1.Items[0].Selected = true;

            if (ExcelConn.State == ConnectionState.Open)
                ExcelConn.Close();



        }
        catch (Exception ex)
        {
            showMsg.ForeColor = Color.Red;
            showMsg.Text = ExcelConn.ConnectionString + "     " + ex.ToString();
            return;
        }
        finally
        {
            if (ExcelConn.State == ConnectionState.Open)
                ExcelConn.Close();
        }
        
    }

    private void setControlDefault()
    {
        Session["ExcelDT"] = null;
        Session["dt"] = null;
        GridView1.DataSource = null;
        GridView1.DataBind();
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {

    }

    void setAttend(int year, int month, int day, string nobr, string rote)
    {
        
        //增加日期判斷，非正確日期會出現例外就略過。 20110201 kukoc
        DateTime datetime;

        try
        {
            datetime  = new DateTime(year, month, day);
        }
        catch 
        {
            return;
        }


        eHRDSTableAdapters.ROTECHGTableAdapter ad = new eHRDSTableAdapters.ROTECHGTableAdapter();       
        AttendDsTableAdapters.ATTEND1TableAdapter attad = new AttendDsTableAdapters.ATTEND1TableAdapter();
        AttendDs.ATTEND1DataTable attdt = new AttendDs.ATTEND1DataTable();
        AttendDs.ATTEND1Row attrow = attdt.NewATTEND1Row();

        attrow.NOBR = nobr;
        attrow.ROTE = rote;        
        //attrow.ADATE = new DateTime(year, month, day);
        attrow.ADATE = datetime;
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

        eHRDS.ROTECHGDataTable dt = ad.GetData(nobr, attrow.ADATE);
        if (dt.Rows.Count > 0) {
            attrow.ROTE = dt[0].ROTE;
        }


        attdt.AddATTEND1Row(attrow);
        attad.Update(attdt);
    }

    private void logImportRote(System.Data.DataTable ExcelDT,string yymm)
    {
        for (int i = 0; i < ExcelDT.Rows.Count; i++)
        {
            if (ExcelDT.Rows[i][1].ToString().Trim().Length == 0)
                continue;

            if (i == 0)
                continue;

            string logStr = "";

            int colCount = ExcelDT.Columns.Count - 1;

            for (int j = 1; j <= colCount; j++)
            {
                logStr = logStr + ExcelDT.Rows[i][j].ToString()+",";
            }

            logStr = logStr + JbUser.NOBR + "(" + JbUser.NAME_C + ") ("+yymm+")";
            logger.Info(logStr);
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["ExcelDT"] == null)
        {
            JB.WebModules.Message.Show("請先上傳班表EXCEL檔案");
            return;
        }


 
        //查詢當月是否已經薪資鎖檔，如果當月已鎖，就不給轉入

        DateTime adate = new DateTime(Convert.ToInt32(ddl_year.SelectedValue), Convert.ToInt32(ddl_month.SelectedValue), 1);
        DateTime ddate = new DateTime(adate.Year, adate.Month, DateTime.DaysInMonth(adate.Year, adate.Month));

        Attend attend = new Attend();
        AttendDs.DATA_PADataTable pataDT = attend.GetData_PA(adate, ddate);
        //存取當月份的lock出勤日
        Data_paList.Clear();

        foreach (AttendDs.DATA_PARow row in pataDT.Rows)
        {
            Data_paList.Add(row.DATA_PASS.Day);
        }


        string yymm = "";
        yymm = ddl_year.SelectedValue + ddl_month.SelectedValue;

        System.Data.DataTable ExcelDT = (System.Data.DataTable)Session["ExcelDT"];

        AttendDsTableAdapters.TMTABLETableAdapter tmad = new AttendDsTableAdapters.TMTABLETableAdapter();
        AttendDsTableAdapters.TMTABLE_IMPORTTableAdapter tminad = new AttendDsTableAdapters.TMTABLE_IMPORTTableAdapter();

        
        
        //try
        //{
        // //   tb_year.Text = ExcelDT.Columns[0].ColumnName.ToString().Substring(0, 4);
        //   // tb_month.Text = ExcelDT.Columns[0].ColumnName.ToString().Substring(5);
        //   //tb_month.Text = tb_month.Text.Trim().Substring(0, tb_month.Text.Trim().Length - 1);

            
        //}
        //catch
        //{
        //    JB.WebModules.Message.Show("上傳年月格式錯誤，例：2010/6月");
        //    return;
        //}



        /*
        if (DateTime.Now.Year == int.Parse(ddl_year.SelectedValue) &&
            DateTime.Now.Month == int.Parse(ddl_month.SelectedValue))
        {
        }
        else 
        {
            JB.WebModules.Message.Show("只能上本年度上當月報表！！");
            return;      
        }
        */
                
        logImportRote(ExcelDT,yymm);


        for (int i = 0; i < ExcelDT.Rows.Count; i++)
        {
            //如果此行工號無資料，略過
            if (ExcelDT.Rows[i][1].ToString().Trim().Length == 0)
                continue;

            //如果是第一行欄位，略過
            if (i == 0)
                continue;

            string defRote = ExcelDT.Rows[i][0].ToString().ToUpper().Trim();

            AttendDs.TMTABLEDataTable tmdt = tmad.GetData(ExcelDT.Rows[i][1].ToString().Trim(), yymm);
            AttendDs.TMTABLE_IMPORTDataTable tmindt = tminad.GetData(ExcelDT.Rows[i][1].ToString().Trim(), yymm);

            //AttendDsTableAdapters.QueriesTableAdapter qt = new AttendDsTableAdapters.QueriesTableAdapter();
            //qt.DeleteAttendQuery(decimal.Parse(ddl_year.SelectedValue), decimal.Parse(ddl_month.SelectedValue), ExcelDT.Rows[i][1].ToString().Trim());

            //tmtimport已有資料，用更新的方式
            if (tmindt.Rows.Count > 0)
            {
                for (int j = 1; j <= 31; j++)
                {
                    if (Data_paList.Contains(j))
                    {
                        logger.Info(User.Identity.Name +"企圖更新已關閉出勤日" + j.ToString());
                        continue;
                    }

                    try
                    {
                        string rote = "";
                        if (ExcelDT.Rows[i][j + 2].ToString().ToUpper().Trim().Length == 0)
                        {
                            //給預設，目前沒用到，空白就跳過，不更新                            
                            if (defRote.Length > 0)
                                rote = defRote;
                            else
                                continue;
                        }
                        else if (ExcelDT.Rows[i][j + 2].ToString().ToUpper().Equals("O") || ExcelDT.Rows[i][j + 2].ToString().ToUpper().Equals("0"))
                        {

                            rote = "00";
                        }
                        else
                        {

                            rote = ExcelDT.Rows[i][j + 2].ToString().ToUpper();
                        }

                        tmindt.Rows[0]["D" + j.ToString()] = rote;
                    }
                    catch
                    {
                        tmindt.Rows[0]["D" + j.ToString()] = "";
                    }
                }
            }
            else //tmtimport無資料，新增
            {
                AttendDs.TMTABLE_IMPORTRow tminrow = tmindt.NewTMTABLE_IMPORTRow();
                tminrow.NOBR = ExcelDT.Rows[i][1].ToString().Trim();
                tminrow.YYMM = yymm;
                tminrow.KEY_MAN = JbUser.NOBR;
                tminrow.KEY_DATE = DateTime.Now;
                tminrow.NO = 0;
                tminrow.HOLIS = 0;
                tminrow.FREQ_NO = 0;

                for (int j = 1; j <= 31; j++)
                {
                    if (Data_paList.Contains(j))
                    {
                        logger.Info(User.Identity.Name + "企圖更新已關閉出勤日" + j.ToString());
                        continue;
                    }

                    try
                    {
                        string rote = "";
                        if (ExcelDT.Rows[i][j + 2].ToString().ToUpper().Trim().Length == 0)
                        {
                            if (defRote.Length > 0)
                                rote = defRote;
                            else
                                rote = "";
                        }
                        else if (ExcelDT.Rows[i][j + 2].ToString().ToUpper().Equals("O") || ExcelDT.Rows[i][j + 2].ToString().ToUpper().Equals("0"))
                        {

                            rote = "00";
                        }
                        else
                        {

                            rote = ExcelDT.Rows[i][j + 2].ToString().ToUpper();
                        }
                      
                        tminrow["D" + j.ToString()] = rote;
                    }
                    catch
                    {
                        tminrow["D" + j.ToString()] = "";
                    }                  
                }

                tmindt.AddTMTABLE_IMPORTRow(tminrow);
            }

            tminad.Update(tmindt);

            if (tmdt.Rows.Count > 0)
            {

                for (int j = 1; j <= 31; j++)
                {
                    if (Data_paList.Contains(j))
                    {
                        logger.Info(User.Identity.Name + "企圖更新已關閉出勤日" + j.ToString());
                        continue;
                    }

                    try
                    {

                        string rote = "";
                        if (ExcelDT.Rows[i][j + 2].ToString().ToUpper().Trim().Length == 0)
                        {
                            //給預設，目前沒用到，空白就跳過，不更新                            
                            if (defRote.Length > 0)
                                rote = defRote;
                            else
                                continue;                            
                        }
                        else if (ExcelDT.Rows[i][j + 2].ToString().ToUpper().Equals("O") || ExcelDT.Rows[i][j + 2].ToString().ToUpper().Equals("0"))
                        {

                            rote = "00";
                        }
                        else
                        {
                            rote = ExcelDT.Rows[i][j + 2].ToString().ToUpper();
                        }

                        tmdt.Rows[0]["D" + j.ToString()] = rote;
                    }
                    catch
                    {
                        tmdt.Rows[0]["D" + j.ToString()] = "";
                    }       
                    /* 這部分改用 JBHR.BLL.DLL 去產生出勤
                    if (tmdt.Rows[0]["D" + j.ToString()].ToString().Trim().Length > 0)
                    {
                        setAttend(int.Parse(ddl_year.SelectedValue), int.Parse(ddl_month.SelectedValue), j, tmdt[0].NOBR, tmdt.Rows[0]["D" + j.ToString()].ToString().Trim());
                    }
                     */ 
                }
            }
            else
            {

                AttendDs.TMTABLERow tmrow = tmdt.NewTMTABLERow();
                tmrow.NOBR = ExcelDT.Rows[i][1].ToString().Trim();
                tmrow.YYMM = yymm;
                tmrow.KEY_MAN = JbUser.NOBR;                
                tmrow.KEY_DATE = DateTime.Now;
                tmrow.NO = 0;
                tmrow.HOLIS = 0;
                tmrow.FREQ_NO = 0;

                for (int j = 1; j <= 31; j++)
                {
                    if (Data_paList.Contains(j))
                    {
                        logger.Info(User.Identity.Name + "企圖更新已關閉出勤日" + j.ToString());
                        continue;
                    }

                    try
                    {
                        string rote = "";
                        if (ExcelDT.Rows[i][j + 2].ToString().ToUpper().Trim().Length == 0)
                        {
                            //給預設，目前沒用到，空白就跳過，不更新                            
                            if (defRote.Length > 0)
                                rote = defRote;
                            else
                                rote = "";
                        }
                        else if (ExcelDT.Rows[i][j + 2].ToString().ToUpper().Equals("O") || ExcelDT.Rows[i][j + 2].ToString().ToUpper().Equals("0"))
                        {
                            rote = "00";
                        }
                        else
                        {
                            rote = ExcelDT.Rows[i][j + 2].ToString().ToUpper();
                        }

                        tmrow["D" + j.ToString()] = rote;
                    }
                    catch
                    {
                        tmrow["D" + j.ToString()] = "";
                    }
                   
                   /* 這部分改用 JBHR.BLL.DLL 去產生出勤
                    if (tmrow["D" + j.ToString()].ToString().Trim().Length > 0)
                    {
                        setAttend(int.Parse(ddl_year.SelectedValue), int.Parse(ddl_month.SelectedValue), j, tmrow.NOBR, tmrow["D" + j.ToString()].ToString().Trim());
                    }
                    */ 
                }

                tmdt.AddTMTABLERow(tmrow);
            }

            tmad.Update(tmdt);

            AttendDs.TMTABLERow tmtrow = tmdt.FindByYYMMNOBR(yymm, ExcelDT.Rows[i][1].ToString().Trim());

            try
            {
                int  intAdate = getTmtableAdate(yymm,tmtrow);
                int intDdate = getTmtableDdate(yymm,tmtrow);

                if (intAdate == 0 || intDdate == 0)
                {
                    logger.Warn(User.Identity.Name + "企圖匯入已鎖定月份班表");
                    JB.WebModules.Message.Show("班表已鎖定，無法匯入！");
                    return;
                }

                DoCreateRote(ExcelDT.Rows[i][1].ToString().Trim(), JbUser.NAME_C, yymm,intAdate ,intDdate);
            }
            catch (Exception ex)
            {
                JB.WebModules.Message.Show("匯入班表有誤，請洽資訊人員！");
                return;
            }
        }          

        JB.WebModules.Message.Show("匯入" + ExcelDT.Rows[0][0].ToString() + "班表完成！");
        showMsg.Text = "匯入" + ExcelDT.Rows[0][0].ToString() + "班表完成！";
    }

    private int getTmtableAdate(String yymm,AttendDs.TMTABLERow row)
    {
        int result = 0;
        int y = Convert.ToInt16(yymm.Substring(0, 4));
        int m = Convert.ToInt16(yymm.Substring(4, 2));

        for (int j = 1; j <= 31; j++)
        {
            if (Data_paList.Contains(j))
                continue;

            if (row["D" + j.ToString()].ToString().Trim().Length >0)
            {
                DateTime dt;

                if (DateTime.TryParse(y.ToString() + "/" + m.ToString() + "/" + j, out dt))
                    return j;                              
                else
                    continue;                
            }
        }

        return result;
    }

    private int getTmtableDdate(String yymm,AttendDs.TMTABLERow row)
    {
        int result = 0;

        int y = Convert.ToInt16(yymm.Substring(0, 4));
        int m = Convert.ToInt16(yymm.Substring(4, 2));

        for (int j = 31; j >= 1; j--)
        {
            if (Data_paList.Contains(j))
                continue;

            if (row["D" + j.ToString()].ToString().Trim().Length > 0)
            {
                DateTime dt;
                if(DateTime.TryParse(y.ToString()+"/"+m.ToString()+"/"+j,out dt))                
                    return j;
                else
                {                    
                    logger.Error("發生匯入錯誤日期" + y.ToString() + "/" + m.ToString() + "/" + j);
                    continue;
                }
            }
        }

        return result;
    }


    private void DoCreateRote(string nobr,string name_c,string YYMM,int transBeginDay,int transEndDay)
    {
        int y = Convert.ToInt16(YYMM.Substring(0,4));
        int m = Convert.ToInt16(YYMM.Substring(4,2));
        DateTime adate = new DateTime(y,m,transBeginDay);
        DateTime ddate = new DateTime(y,m,transEndDay);

        JBHR.BLL.Att.CardTransAttend cardTransAttend = new CardTransAttend(nobr,nobr,"01","ZZ",adate,ddate,name_c,"A",true);
     //   cardTransAttend.Run(true,false,false,false,false);
        cardTransAttend.Run(true, false, false, false, false);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        string dept = JbUser.DepartmentCode;

        if (Request.QueryString["hr"] != null)
        {
            //dept = "zz";
            dept = SiteHelper.GetDeptRoot();
        }
        else
        {
            //lb_dept.Text = dept;
        }
        DEPT_REPO deptRepo = new DEPT_REPO();
        DEPT deptObj = deptRepo.GetByID(dept);

        DropDownList1.Items.Add(new ListItem(deptObj.D_NAME, deptObj.D_NO));
        setDept(deptObj);

        if (DropDownList1.Items.Count > 0)
        {
            lb_dept.Text = DropDownList1.Items[0].Value;
        }

        GridView2.DataBind();
    }

    void setDept(DEPT dept)
    {
        DEPT_REPO deptRepo = new DEPT_REPO();
        List<DEPT> depts = deptRepo.GetChildByID(dept.D_NO);
        for (int i = 0; i < depts.Count; i++)
        {
            DropDownList1.Items.Add(new ListItem(depts[i].D_NAME, depts[i].D_NO));
            setDept(depts[i]);
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lb_dept.Text = DropDownList1.SelectedValue;
        GridView2.DataBind();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        int yy = DateTime.Now.Year;
        int mm = DateTime.Now.Month;
        try
        {
            MemoryStream ms = CNPOI.RenderDataTableToExcel(setTable()) as MemoryStream;
            //MemoryStream ms1 = SetHolidayColor(ms, yy, mm);
            // 設定強制下載標頭。
            string fileName = yy.ToString() + mm.ToString().PadLeft(2, '0') + DropDownList1.SelectedItem.Text + ".xls";
            //string fileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DropDownList1.SelectedItem.Text + ".xls";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));         
            // 輸出檔案。
            Response.BinaryWrite(ms.ToArray());
            //Response.BinaryWrite(ms1.ToArray());

            ms.Close();
            ms.Dispose();
        //    ms1.Close();
          //  ms1.Dispose();
        }
        catch {
            JB.WebModules.Message.Show("年月格式有問題！請確認！");
        }
    }


    DataTable setTable()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("預設排班班別");
        dt.Columns.Add("員工工號");
        dt.Columns.Add("員工姓名");
        int days = 31;
        for (int i = 1; i <= days; i++)
        {
            dt.Columns.Add(i.ToString()+"日");
        }


        DataView dv;
        DataSourceSelectArguments args = new DataSourceSelectArguments();
        dv = HR_Portal_EmpInfoSqlDataSource.Select(args) as DataView;
        DataTable sdt = dv.Table;

        for (int i = 0; i < sdt.Rows.Count; i++)
        {
            DataRow row = dt.NewRow();

            row["員工工號"] = sdt.Rows[i]["NOBR"].ToString();
            row["員工姓名"] = sdt.Rows[i]["NAME_C"].ToString() + " "+sdt.Rows[i]["NAME_E"].ToString(); 

            dt.Rows.Add(row);
        }


        return dt;

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        //DataSet1TableAdapters.ROTETableAdapter ad = new DataSet1TableAdapters.ROTETableAdapter();
        //DataSet1.ROTEDataTable dt = ad.GetData();

        ROTE_REPO roteRepo = new ROTE_REPO();
        List<ROTE> list = roteRepo.GetAll();
        var l = (from c in list
                 select new
                 {
                     班別代碼 = c.ROTE1,
                     班別名稱 = c.ROTENAME,
                     上班時間 = c.ON_TIME,
                     下班時間 = c.OFF_TIME
                 }).ToList();
        DataTable dt = EntityToDataTable.Entity2DataTable(l);

        try
        {
            MemoryStream ms = CNPOI.RenderDataTableToExcel(dt) as MemoryStream;
            // 設定強制下載標頭。
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=Shift.xls"));
            // 輸出檔案。
            Response.BinaryWrite(ms.ToArray());

            ms.Close();
            ms.Dispose();
        }
        catch
        {
            JB.WebModules.Message.Show("年月格式有問題！請確認！");
        }

    }
    protected void Wizard1_ActiveStepChanged(object sender, EventArgs e)
    {
        //Button2.OnClientClick = @"confirm('TestDeviceFilter','test')";
        
        if (Wizard1.ActiveStepIndex == 2) //最後一個步驟
        {
            lblNotifyMsg.Text = "匯入 " + ddl_year.SelectedValue + "年" + ddl_month.SelectedValue + "月班表!!";
        }

        Button2.OnClientClick = JB.WebModules.Confirm.GetConfirmScript("確認" + lblNotifyMsg.Text);

    }

    //設定excel檔，日期為假日時，字體為紅色
    private MemoryStream SetHolidayColor(MemoryStream ms, int yy, int mm)
    {
        HOLI_REPO holiRepo = new HOLI_REPO();

        MemoryStream msValue = new MemoryStream();
        IWorkbook workbook = new HSSFWorkbook(ms);
        IFont font = workbook.CreateFont();

        font.Color =0xa;
        ICellStyle style = workbook.CreateCellStyle();
        style.SetFont(font);

        ISheet sheet = workbook.GetSheetAt(0);

        IRow row = sheet.GetRow(0);

        if (row == null)
            return null;

        DateTime adate = new DateTime(yy, mm, 1);
        DateTime ddate = new DateTime(yy, mm, DateTime.DaysInMonth(yy, mm));

        var holiList = holiRepo.GetByDateRange(adate, ddate);

        //AttendDs.HOLIDataTable holiDT = holiAdap.GetDataByADdate(adate, ddate);
        //AttendDs.HOLIRow[] holiRows;
        int cellStart = 2;

        for (int d = 1; d < 32; d++)
        {
            if (adate.Month != mm)
                break;

            var holi = holiList.Where(c => c.H_DATE.ToShortDateString().Equals(adate.ToShortDateString())).FirstOrDefault();
            //holiRows = (AttendDs.HOLIRow[])holiDT.Select("H_DATE = '" + adate.ToShortDateString() + "'");
            //if (holiRows.Length > 0)
            if(holi!=null)
            {
                ICell cell = row.GetCell(d + cellStart);
                cell.CellStyle = style;
            }
            adate = adate.AddDays(1);
        }

        workbook.Write(msValue);
        return msValue;
    }
}
