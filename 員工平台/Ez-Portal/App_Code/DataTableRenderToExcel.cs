using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS;
using NPOI.Util;
using System.Data;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
/// <summary>
/// DataTableRenderToExcel 的摘要描述
/// </summary>
public class DataTableRenderToExcel
{
	public DataTableRenderToExcel()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    public static Stream RenderDataTableToExcelMs(DataTable SourceTable)
    {
        IWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        ISheet sheet = workbook.CreateSheet();
        IRow headerRow = sheet.CreateRow(0);
        //NPOI.SS.UserModel.Sheet sheet = workbook.CreateSheet();
        //NPOI.SS.UserModel.Row headerRow = sheet.CreateRow(0);


        // handling header.
        foreach ( DataColumn column in SourceTable.Columns )
            headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);
        //headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

        // handling value.
        int rowIndex = 1;

        foreach ( DataRow row in SourceTable.Rows )
        {
            IRow dataRow = sheet.CreateRow(rowIndex);

            foreach ( DataColumn column in SourceTable.Columns )
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
            }

            rowIndex++;
        }

        workbook.Write(ms);
        ms.Flush();
        ms.Position = 0;

        sheet = null;
        headerRow = null;
        workbook = null;

        return ms;
    }

    public static IWorkbook RenderDataTableToExcel(DataTable SourceTable)
    {
        IWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        ISheet sheet = workbook.CreateSheet();
        IRow headerRow = sheet.CreateRow(0);

        // handling header.
        foreach ( DataColumn column in SourceTable.Columns )
            headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);
        //headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

        // handling value.
        int rowIndex = 1;

        foreach ( DataRow row in SourceTable.Rows )
        {
            IRow dataRow = sheet.CreateRow(rowIndex);

            foreach ( DataColumn column in SourceTable.Columns )
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
            }

            rowIndex++;
        }

        return workbook;
        //workbook.Write(ms);
        //ms.Flush();
        //ms.Position = 0;

        //sheet = null;
        //headerRow = null;
        //workbook = null;

        //return ms;
    }

    public static void RenderDataTableToExcel(DataTable SourceTable, string FileName)
    {
        MemoryStream ms = RenderDataTableToExcelMs(SourceTable) as MemoryStream;
        FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
        byte[] data = ms.ToArray();
 
        fs.Write(data, 0, data.Length);
        fs.Flush();
        fs.Close();
 
        data = null;
        ms = null;
        fs = null;
    }
 
    public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex)
    {
        IWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
        ISheet sheet = workbook.GetSheet(SheetName);
 
        DataTable table = new DataTable();

        IRow headerRow = sheet.GetRow(HeaderRowIndex);
        int cellCount = headerRow.LastCellNum;
 
        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
        {
            DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
            table.Columns.Add(column);
        }
 
        int rowCount = sheet.LastRowNum;
 
        for (int i = (sheet.FirstRowNum + 1); i < sheet.LastRowNum; i++)
        {
            IRow row = sheet.GetRow(i);
            DataRow dataRow = table.NewRow();
 
            for (int j = row.FirstCellNum; j < cellCount; j++)
                dataRow[j] = row.GetCell(j).ToString();
        }
 
        ExcelFileStream.Close();
        workbook = null;
        sheet = null;
        return table;
    }

    public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream , int SheetIndex , int HeaderRowIndex)
    {
        HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
        ISheet sheet = workbook.GetSheetAt(SheetIndex);

        DataTable table = new DataTable();

        IRow headerRow = sheet.GetRow(HeaderRowIndex);
        int cellCount = headerRow.LastCellNum;

        for ( int i = headerRow.FirstCellNum ; i < cellCount ; i++ )
        {
            DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
            table.Columns.Add(column);
        }

        int rowCount = sheet.LastRowNum;

        for (int i = (sheet.FirstRowNum + 1);; i++)
        {
            IRow row = sheet.GetRow(i);
            if (row ==null)
                break;

            DataRow dataRow = table.NewRow();

            for (int j = row.FirstCellNum; j < cellCount; j++)
            {
                if (row.GetCell(j) != null)
                    dataRow[j] = row.GetCell(j).ToString();
            }

            table.Rows.Add(dataRow);
        }
        //for ( int i = (sheet.FirstRowNum + 1) ; i < sheet.LastRowNum ; i++ )
        //{
        //    NPOI.SS.UserModel.Row row = sheet.GetRow(i);
        //    DataRow dataRow = table.NewRow();

        //    for ( int j = row.FirstCellNum ; j < cellCount ; j++ )
        //    {
        //        if ( row.GetCell(j) != null )
        //            dataRow[j] = row.GetCell(j).ToString();
        //    }

        //    table.Rows.Add(dataRow);
        //}

        ExcelFileStream.Close();
        workbook = null;
        sheet = null;
        return table;
    }

    public static MemoryStream MergeDuplicationColCell(MemoryStream ms, int colIndex)
    {
        MemoryStream msValue = new MemoryStream();
        HSSFWorkbook workbook = new HSSFWorkbook(ms);

        ISheet sheet = workbook.GetSheetAt(0);

        IRow tempRow = null;

        for(int rowPos =0;rowPos < sheet.LastRowNum;rowPos++)
        {
            IRow row = sheet.GetRow(rowPos);

            if (tempRow != null)
            {
                if (row.GetCell(colIndex).ToString().Equals(tempRow.GetCell(colIndex).ToString()))
                {
                    CellRangeAddress region = new CellRangeAddress(tempRow.RowNum, row.RowNum, colIndex, colIndex);
                    sheet.AddMergedRegion(region);
                }
                else
                {
                    tempRow = row;
                }
            }
            else
            {
                tempRow = row;
            }
        }

        workbook.Write(msValue);
        return msValue;
    }

    public static MemoryStream MergeDuplicationRowCellMs(MemoryStream ms, int rowIndex)
    {
        MemoryStream msValue = new MemoryStream();
        IWorkbook workbook = new HSSFWorkbook(ms);

        ISheet sheet = workbook.GetSheetAt(0);

        ICell tempCell = null;

        IRow row = sheet.GetRow(rowIndex);

        for (int colPos = 0; colPos < row.LastCellNum; colPos++)
        {
            ICell cell = row.GetCell(colPos);

            if (tempCell != null)
            {
                if (cell.ToString().Equals(tempCell.ToString()))
                {
                    CellRangeAddress region = new CellRangeAddress(row.RowNum, row.RowNum, tempCell.ColumnIndex, cell.ColumnIndex);
                    sheet.AddMergedRegion(region);
                }
                else
                {
                    tempCell = cell;
                }
            }
            else
            {
                tempCell = cell;
            }
        }

        workbook.Write(msValue);
        return msValue;
    }

    public static void MergeDuplicationRowCell(HSSFWorkbook workbook , int rowIndex)
    {
        //MemoryStream msValue = new MemoryStream();
        //HSSFWorkbook workbook = new HSSFWorkbook(ms);

        ISheet sheet = workbook.GetSheetAt(0);

        ICell tempCell = null;

        IRow row = sheet.GetRow(rowIndex);

        for ( int colPos = 0 ; colPos < row.LastCellNum ; colPos++ )
        {
            ICell cell = row.GetCell(colPos);

            if ( tempCell != null )
            {
                if ( cell.ToString().Equals(tempCell.ToString()) )
                {
                    CellRangeAddress region = new CellRangeAddress(row.RowNum , row.RowNum , tempCell.ColumnIndex , cell.ColumnIndex);
                    sheet.AddMergedRegion(region);
                }
                else
                {
                    tempCell = cell;
                }
            }
            else
            {
                tempCell = cell;
            }
        }

        //workbook.Write(msValue);
        //return msValue;
    }

    public static MemoryStream AddHeaderMs(MemoryStream ms, int rowIndex,string str)
    {
        MemoryStream msValue = new MemoryStream();
        IWorkbook workbook = new HSSFWorkbook(ms);

        ISheet sheet = workbook.GetSheetAt(0);

        ICell tempCell = null;

        IRow row = sheet.GetRow(0);
        int rowNum = 0;
        if (row != null)
        {
            rowNum = row.LastCellNum;
        }

        sheet.ShiftRows(rowIndex, sheet.LastRowNum, 1);
        IRow newRow = sheet.CreateRow(rowIndex);

        for (int colPos = 0; colPos < rowNum; colPos++)
        {
            ICell cell = newRow.CreateCell(colPos);
            cell.SetCellValue(str);
        }

        workbook.Write(msValue);
        return msValue;
    }

    public static void AddHeader(HSSFWorkbook workbook , int rowIndex , string str)
    {
        //MemoryStream msValue = new MemoryStream();
        //HSSFWorkbook workbook = new HSSFWorkbook(ms);

        ISheet sheet = workbook.GetSheetAt(0);

        ICell tempCell = null;

        IRow row = sheet.GetRow(0);
        int rowNum = 0;
        if ( row != null )
        {
            rowNum = row.LastCellNum;
        }

        sheet.ShiftRows(rowIndex , sheet.LastRowNum , 1);
        IRow newRow = sheet.CreateRow(rowIndex);

        for ( int colPos = 0 ; colPos < rowNum ; colPos++ )
        {
            ICell cell = newRow.CreateCell(colPos);
            cell.SetCellValue(str);
        }

        //workbook.Write(msValue);
        //return msValue;
    }

}