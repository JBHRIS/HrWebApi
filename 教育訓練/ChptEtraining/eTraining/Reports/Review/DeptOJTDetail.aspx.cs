using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;
using NPOI.HSSF.UserModel;
using Telerik.Web.UI;
using Repo;

public partial class eTraining_Reports_Review_DeptOJTDetail:JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    int jobScoreAmt = 0;

    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            rmypMYP.SelectedDate = DateTime.Now;
        }
    }

    protected void btnExportExcel_Click(object sender , EventArgs e)
    {
        int year = rmypMYP.SelectedDate.Value.Year;
        int month = rmypMYP.SelectedDate.Value.Month;
        DateTime datetime = new DateTime(year , month , DateTime.DaysInMonth(year , month));

        DataTable dt = new DataTable();
        setPreBasicCol(dt);
        setDynamicCol(dt);
        setPostBasicCol(dt);
        setDataTableData(dt);


        HSSFWorkbook workbook = DataTableRenderToExcel.RenderDataTableToExcel(dt);
        //MemoryStream ms = (MemoryStream) DataTableRenderToExcel.RenderDataTableToExcelMs(dt);
        string header = rmypMYP.SelectedDate.Value.Year.ToString()  + "年"+ rmypMYP.SelectedDate.Value.Month.ToString() + " 月份職能盤點明細表";
        DataTableRenderToExcel.AddHeader(workbook , 0 , header);
        DataTableRenderToExcel.MergeDuplicationRowCell(workbook , 0);
        setHeaderStyle(workbook);
        setDataStyle(workbook , 1);

        setHeaderHeight(workbook);
        setTitleStyle(workbook , 1);
        setColAutoSize(workbook , dt.Columns.Count);

        HSSFSheet sheet = (HSSFSheet) workbook.GetSheetAt(0);
        //指定直式或橫式 true=橫式 false=直式
        sheet.PrintSetup.Landscape = true;
        //指定紙張大小 A3=8, A4=9, Letter=1        
        sheet.PrintSetup.PaperSize = 9;
        sheet.SetMargin(MarginType.TopMargin, 0);
        sheet.SetMargin(MarginType.BottomMargin, 0);
        sheet.SetMargin(MarginType.LeftMargin, 0);
        sheet.SetMargin(MarginType.RightMargin, 0);


        MemoryStream ms = new MemoryStream();
        workbook.Write(ms);        
        ms.Flush();
        ms.Position = 0;
        SiteHelper.ResponseExcel(ms , year.ToString() + "-" + month.ToString().PadLeft(2 , '0') + "-" + "職能明細表");
        ms.Dispose();
    }

    private void setColAutoSize(HSSFWorkbook workbook , int col)
    {
        ISheet sheet = workbook.GetSheetAt(0);
        //sheet.FitToPage = false;

        for ( int i = 0 ; i < col ; i++ )
        {
            sheet.AutoSizeColumn(i , true);
            //sheet.AutoSizeColumn(i);                    
        }
    }

    private void setTitleStyle(HSSFWorkbook workbook , int rowPos)
    {
        ISheet sheet = workbook.GetSheetAt(0);
        ICellStyle style = workbook.CreateCellStyle();
        style.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;

        //   style.BottomBorderColor = HSSFColor.BLACK.index;     
        style.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
        style.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
        style.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
        style.ShrinkToFit = true;
        style.Alignment = HorizontalAlignment.CENTER;
        style.VerticalAlignment = VerticalAlignment.TOP;
        //style.Rotation = (short)90;
        style.Rotation = 255;

        IRow row = sheet.GetRow(rowPos);
        for ( int i = 0 ; i < row.LastCellNum ; i++ )
        {
            ICell cell = row.GetCell(i);
            cell.CellStyle = style;
        }
    }

    private void setHeaderStyle(HSSFWorkbook workbook)
    {
        ISheet sheet = workbook.GetSheetAt(0);
        IFont IFont = workbook.CreateFont();

        //IFont.Color = HSSFColor.RED.index;
        //IFont.IsItalic = true;
        //IFont1.Underline = (byte)IFontUnderlineType.DOUBLE;
        IFont.FontHeightInPoints = 28;

        //bind IFont with style
        ICellStyle style = workbook.CreateCellStyle();
        //style.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
        //style.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
        //style.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
        //style.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
        style.Alignment = HorizontalAlignment.CENTER;
        style.VerticalAlignment = VerticalAlignment.CENTER;

        //style.ShrinkToFit = true;

        style.SetFont(IFont);
        IRow row = sheet.GetRow(0);
        ICell cell = row.GetCell(0);
        cell.CellStyle = style;
    }

    private void setHeaderHeight(HSSFWorkbook workbook)
    {
        ISheet sheet = workbook.GetSheetAt(0);
        IFont IFont = workbook.CreateFont();

        IRow row = sheet.GetRow(0);
        row.HeightInPoints = 36;
    }

    private void setDataTableData(DataTable dt)
    {
        //使用者資料

        //上月最後一天
        int year = rmypMYP.SelectedDate.Value.Year;
        int month = rmypMYP.SelectedDate.Value.Month;
        DateTime bDate = new DateTime(year , month , 1);
        DateTime eDate = new DateTime(year , month , DateTime.DaysInMonth(year , month));

        BASE_Repo baseRepo = new BASE_Repo();
        List<BASE> baseList = new List<BASE>();
        foreach ( RadComboBoxItem i in cbxOjtDept.CheckedItems )
            baseList.AddRange(baseRepo.GetEmpHiredByDateRange_Dlo(bDate , eDate , i.Value));

        //dcTraining.Log = new DebuggerWriter();
        foreach ( var user in baseList )
        {
            DataRow row = dt.NewRow();
            row["部門"] = user.BASETTS[user.BASETTS.Count - 1].DEPT;
            row["員工編號"] = user.NOBR;
            row["姓名"] = user.NAME_C;
            row["職稱"] = user.BASETTS[user.BASETTS.Count - 1].JOB1.JOB_NAME;

            var trOJTStudentDList = (from d in dcTraining.trOJTStudentD
                                     join c in dcTraining.trCourse on d.trCourse_sCode equals c.sCode
                                     where d.OJT_sCode == cbxOJTCard.SelectedValue
                                     && d.sNobr == user.NOBR
                                     select new
                                     {
                                         d ,
                                         c.iJobScore
                                     }).ToList();

            foreach ( var l in trOJTStudentDList )
            {
                if ( dt.Columns.Contains(l.d.trCourse_sCode) )
                {
                    if ( l.d.bPass == true )
                        row[l.d.trCourse_sCode] = l.iJobScore.ToString();
                    //row[l.d.trCourse_sCode] = l.iJobScore;
                    else
                        row[l.d.trCourse_sCode] = "";
                    //row[l.d.trCourse_sCode] = 0;
                }
            }

            row["合計"] = (from c in trOJTStudentDList
                         where c.d.bPass == true
                         select c.iJobScore).Sum();

            row["上月合計"] = (from c in trOJTStudentDList
                           where c.d.bPass == true
                           && c.d.dFinalCheckDate < bDate
                           select c.iJobScore).Sum();

            row["差異"] = Convert.ToInt32(row["合計"]) - Convert.ToInt32(row["上月合計"]);
            dt.Rows.Add(row);
        }

    }

    private void setDataStyle(HSSFWorkbook workbook , int startRow)
    {
        ISheet sheet = workbook.GetSheetAt(0);
        ICellStyle style = workbook.CreateCellStyle();
        style.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
        //   style.BottomBorderColor = HSSFColor.BLACK.index;     
        style.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
        style.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
        style.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
        style.ShrinkToFit = true;
        style.Alignment = HorizontalAlignment.CENTER;
        style.VerticalAlignment = VerticalAlignment.CENTER;

        for ( int rowPos = startRow ; rowPos <= sheet.LastRowNum ; rowPos++ )
        {
            IRow row = sheet.GetRow(rowPos);
            for ( int colPos = 0 ; colPos < row.LastCellNum ; colPos++ )
            {
                ICell cell = row.GetCell(colPos);
                cell.CellStyle = style;
            }
        }
    }

    private void setPreBasicCol(DataTable dt)
    {
        addDataTableCol(dt , "部門" , "部門" , typeof(string));
        addDataTableCol(dt , "員工編號" , "員工編號" , typeof(string));
        addDataTableCol(dt , "姓名" , "姓名" , typeof(string));
        addDataTableCol(dt , "職稱" , "職稱" , typeof(string));
    }

    private void addDataTableCol(DataTable dt , string colName , string colCaption , Type type)
    {
        DataColumn col = new DataColumn(colName , type);
        col.Caption = colCaption;
        dt.Columns.Add(col);
    }

    private void setPostBasicCol(DataTable dt)
    {
        addDataTableCol(dt , "合計" , "合計" + jobScoreAmt.ToString() , typeof(Int32));
        addDataTableCol(dt , "上月合計" , "上月合計" , typeof(Int32));
        addDataTableCol(dt , "差異" , "差異" , typeof(Int32));
        //dt.Columns.Add(new DataColumn("合計"+jobScoreAmt.ToString(), typeof(Int32)));
    }

    private void setDynamicCol(DataTable dt)
    {
        dcTraining.Log = new DebuggerWriter();

        var ojtDetail = (from c in dcTraining.trOJTTemplateDetail
                         join course in dcTraining.trCourse
                         on c.trCourse_sCode equals course.sCode
                         where c.OJT_sCode == cbxOJTCard.SelectedValue
                         select new
                         {
                             sCode = c.trCourse_sCode ,
                             sName = course.sName ,
                             iJobScore = course.iJobScore
                         }).ToList();

        foreach ( var item in ojtDetail )
        {
            jobScoreAmt = jobScoreAmt + item.iJobScore;
            addDataTableCol(dt , item.sCode , item.sName + item.iJobScore , typeof(String));
            //addDataTableCol(dt, item.sCode, item.sName+item.iJobScore,typeof(Int32));
        }
    }
    protected void btnSelectAllDept_Click(object sender , EventArgs e)
    {
        foreach ( RadComboBoxItem item in cbxOjtDept.Items )
        {
            item.Checked = true;
        }



    }
}