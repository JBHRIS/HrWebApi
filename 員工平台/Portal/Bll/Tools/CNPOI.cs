using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS;
using NPOI.Util;
using NPOI.SS.UserModel;

public static class CNPOI
{
    public static Stream RenderDataTableToExcel(DataTable SourceTable)
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        var sheet = workbook.CreateSheet();
        var headerRow = sheet.CreateRow(0);

        var intCellStyle = workbook.CreateCellStyle();
        intCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

        var doubleCellStyle = workbook.CreateCellStyle();
        doubleCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");

        var dateCellStyle = workbook.CreateCellStyle();
        dateCellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("yyyy/mm/dd");

        // handling header.
        foreach (DataColumn column in SourceTable.Columns)
            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

        // handling value.
        int rowIndex = 1;

        foreach (DataRow row in SourceTable.Rows)
        {
            var dataRow = sheet.CreateRow(rowIndex);

            foreach (DataColumn column in SourceTable.Columns)
            {
                Type t = column.DataType;
                var cell = dataRow.CreateCell(column.Ordinal);
                if (t == typeof(bool))
                {
                    cell.CellStyle = intCellStyle;
                    if (row.IsNull(column.ColumnName)) cell.SetCellValue(0);
                    else
                    {
                        if (Convert.ToBoolean(row[column.ColumnName])) cell.SetCellValue(1);
                        else cell.SetCellValue(0);
                    }
                }
                else if (t == typeof(int))
                {
                    cell.CellStyle = intCellStyle;
                    if (row.IsNull(column.ColumnName)) cell.SetCellValue(0);
                    else cell.SetCellValue(Convert.ToInt32(row[column.ColumnName]));
                }
                else if (t == typeof(decimal) || t == typeof(double) || t == typeof(float))
                {
                    cell.CellStyle = intCellStyle;// doubleCellStyle;
                    if (row.IsNull(column.ColumnName)) cell.SetCellValue(0.00);
                    else cell.SetCellValue(Convert.ToDouble(row[column.ColumnName]));
                }
                else if (t == typeof(DateTime))
                {
                    cell.CellStyle = dateCellStyle;
                    if (row.IsNull(column.ColumnName)) cell.SetCellValue("");
                    else cell.SetCellValue(Convert.ToDateTime(row[column.ColumnName]).Date);
                }
                else
                {
                    if (row.IsNull(column.ColumnName)) cell.SetCellValue("");
                    else cell.SetCellValue(Convert.ToString(row[column.ColumnName]).Trim());
                }
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

    public static Stream RenderDataViewToExcel(DataView SourceView)
    {
        HSSFWorkbook workbook = new HSSFWorkbook();
        MemoryStream ms = new MemoryStream();
        var sheet = workbook.CreateSheet();
        var headerRow = sheet.CreateRow(0);

        var intCellStyle = workbook.CreateCellStyle();
        intCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

        var doubleCellStyle = workbook.CreateCellStyle();
        doubleCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");

        var dateCellStyle = workbook.CreateCellStyle();
        dateCellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("yyyy/mm/dd");

        // handling header.
        foreach (DataColumn column in SourceView.Table.Columns)
        {
            if (column.Caption.Trim().Length == 0)
            {
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            }
            else headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);
        }

        // handling value.
        int rowIndex = 1;

        foreach (DataRowView dvrow in SourceView)
        {
            DataRow row = dvrow.Row;
            var dataRow = sheet.CreateRow(rowIndex);

            foreach (DataColumn column in SourceView.Table.Columns)
            {
                Type t = column.DataType;
                var cell = dataRow.CreateCell(column.Ordinal);
                if (t == typeof(bool))
                {
                    cell.CellStyle = intCellStyle;
                    if (row.IsNull(column.ColumnName)) cell.SetCellValue(0);
                    else
                    {
                        if (Convert.ToBoolean(row[column.ColumnName])) cell.SetCellValue(1);
                        else cell.SetCellValue(0);
                    }
                }
                else if (t == typeof(int))
                {
                    cell.CellStyle = intCellStyle;
                    if (row.IsNull(column.ColumnName)) cell.SetCellValue(0);
                    else cell.SetCellValue(Convert.ToInt32(row[column.ColumnName]));
                }
                else if (t == typeof(decimal) || t == typeof(double) || t == typeof(float))
                {
                    cell.CellStyle = doubleCellStyle;
                    if (row.IsNull(column.ColumnName)) cell.SetCellValue(0.00);
                    else cell.SetCellValue(Convert.ToDouble(row[column.ColumnName]));
                }
                else if (t == typeof(DateTime))
                {
                    cell.CellStyle = dateCellStyle;
                    if (row.IsNull(column.ColumnName)) cell.SetCellValue("");
                    else cell.SetCellValue(Convert.ToDateTime(row[column.ColumnName]).Date);
                }
                else
                {
                    if (row.IsNull(column.ColumnName)) cell.SetCellValue("");
                    else cell.SetCellValue(Convert.ToString(row[column.ColumnName]).Trim());
                }
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

    public static void RenderDataTableToExcel(DataTable SourceTable, string FileName)
    {
        MemoryStream ms = RenderDataTableToExcel(SourceTable) as MemoryStream;
        FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
        byte[] data = ms.ToArray();

        fs.Write(data, 0, data.Length);
        fs.Flush();
        fs.Close();

        data = null;
        ms = null;
        fs = null;
    }

    public static void RenderDataViewToExcel(DataView SourceView, string FileName)
    {
        MemoryStream ms = RenderDataViewToExcel(SourceView) as MemoryStream;
        FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
        byte[] data = ms.ToArray();

        fs.Write(data, 0, data.Length);
        fs.Flush();
        fs.Close();

        data = null;
        ms = null;
        fs = null;
    }

    public static DataTable RenderDataTableFromExcel(string FileName, string SheetName, int HeaderRowIndex, bool HaveHeader)
    {
        HSSFWorkbook workbook = new HSSFWorkbook(new FileStream(FileName, FileMode.Open));
        var sheet = workbook.GetSheet(SheetName);
        DataTable table = new DataTable();

        var headerRow = sheet.GetRow(HeaderRowIndex);
        int cellCount = headerRow.LastCellNum;

        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
        {
            DataColumn column = HaveHeader ? new DataColumn(headerRow.GetCell(i).StringCellValue) : new DataColumn("C" + i.ToString());
            table.Columns.Add(column);
        }

        for (int i = (sheet.FirstRowNum + (HaveHeader ? 1 : 0)); i <= sheet.LastRowNum - (HaveHeader ? 0 : 1); i++)
        {
            var row = sheet.GetRow(i);

            if (row != null)
            {
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {
                        try
                        {
                            dataRow[j] = Convert.ToDateTime(row.GetCell(j).ToString()).ToString("yyyy/M/d");
                        }
                        catch
                        {
                            dataRow[j] = row.GetCell(j).ToString();
                        }
                    }
                }

                table.Rows.Add(dataRow);
            }
        }

        workbook = null;
        sheet = null;
        return table;
    }

    public static DataTable RenderDataTableFromExcel(string FileName, string SheetName, int HeaderRowIndex)
    {
        HSSFWorkbook workbook = new HSSFWorkbook(new FileStream(FileName, FileMode.Open));
        var sheet = workbook.GetSheet(SheetName);

        //需要尋找最長的欄位長度
        int z = HeaderRowIndex;
        int y = 0;
        if (HeaderRowIndex == -1)
        {
            for (int i = (sheet.FirstRowNum); i <= sheet.LastRowNum; i++)
            {
                var row = sheet.GetRow(i);
                if (row != null && row.LastCellNum > y)
                {
                    y = row.LastCellNum;
                    z = i;
                }
            }
        }

        DataTable table = new DataTable();

        var headerRow = sheet.GetRow(z);
        int cellCount = headerRow.LastCellNum;

        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
        {
            DataColumn column = (HeaderRowIndex >= 0) ? new DataColumn(headerRow.GetCell(i).StringCellValue) : new DataColumn("C" + i.ToString());
            table.Columns.Add(column);
        }

        for (int i = (sheet.FirstRowNum + ((HeaderRowIndex >= 0) ? 1 : 0)); i <= sheet.LastRowNum - ((HeaderRowIndex >= 0) ? 0 : 1); i++)
        {
            var row = sheet.GetRow(i);

            if (row != null)
            {
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {
                        try
                        {
                            dataRow[j] = Convert.ToDateTime(row.GetCell(j).ToString()).ToString("yyyy/M/d");
                        }
                        catch
                        {
                            dataRow[j] = row.GetCell(j).ToString();
                        }
                    }
                }

                table.Rows.Add(dataRow);
            }
        }

        workbook = null;
        sheet = null;
        return table;
    }

    public static DataTable RenderDataTableFromExcel(string FileName, int SheetIndex, int HeaderRowIndex)
    {
        HSSFWorkbook workbook = new HSSFWorkbook(new FileStream(FileName, FileMode.Open));
        var sheet = workbook.GetSheetAt(SheetIndex);

        DataTable table = new DataTable();

        var headerRow = sheet.GetRow(HeaderRowIndex);
        int cellCount = headerRow.LastCellNum;

        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
        {
            DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
            table.Columns.Add(column);
        }

        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
        {
            var row = sheet.GetRow(i);
            DataRow dataRow = table.NewRow();

            for (int j = row.FirstCellNum; j < cellCount; j++)
            {
                if (row.GetCell(j) != null)
                {
                    try
                    {
                        dataRow[j] = Convert.ToDateTime(row.GetCell(j).ToString()).ToString("yyyy/M/d");
                    }
                    catch
                    {
                        try
                        {
                            dataRow[j] = row.GetCell(j).ToString();
                        }
                        catch
                        {
                            dataRow[j] = row.GetCell(j).NumericCellValue.ToString();
                        }
                    }
                }
            }

            table.Rows.Add(dataRow);
        }

        workbook = null;
        sheet = null;
        return table;
    }

    public static DataTable RenderDataTableFromExcel(HSSFSheet sheet, int HeaderRowIndex)
    {
        DataTable table = new DataTable();

        var headerRow = sheet.GetRow(HeaderRowIndex);
        int cellCount = headerRow.LastCellNum;

        for (int i = headerRow.FirstCellNum; i < cellCount; i++)
        {
            DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
            table.Columns.Add(column);
        }

        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
        {
            var row = sheet.GetRow(i);
            DataRow dataRow = table.NewRow();

            for (int j = row.FirstCellNum; j < cellCount; j++)
            {
                if (row.GetCell(j) != null)
                {

                    try
                    {
                        if (sheet.GetRow(i).GetCell(j) == null)
                            dataRow[table.Columns[j]] = "";
                        else if (sheet.GetRow(i).GetCell(j).CellType == CellType.String)
                            dataRow[table.Columns[j]] = sheet.GetRow(i).GetCell(j).StringCellValue;
                        else if (sheet.GetRow(i).GetCell(j).CellType == CellType.Numeric)
                            dataRow[table.Columns[j]] = sheet.GetRow(i).GetCell(j).NumericCellValue;
                        else if (sheet.GetRow(i).GetCell(j).CellType == CellType.Boolean)
                            dataRow[table.Columns[j]] = sheet.GetRow(i).GetCell(j).BooleanCellValue;
                        else if (sheet.GetRow(i).GetCell(j).CellType == CellType.Formula)
                            dataRow[table.Columns[j]] = sheet.GetRow(i).GetCell(j).DateCellValue;
                        else dataRow[table.Columns[j]] = sheet.GetRow(i).GetCell(j).ToString();

                        //dataRow[j] = Convert.ToDateTime(row.GetCell(j).ToString()).ToString("yyyy/M/d");
                    }
                    catch
                    {
                        try
                        {
                            dataRow[j] = row.GetCell(j).ToString();
                        }
                        catch
                        {
                            dataRow[j] = row.GetCell(j).NumericCellValue.ToString();
                        }
                    }
                }
            }

            table.Rows.Add(dataRow);
        }

        sheet = null;
        return table;
    }

    public static void FillDataByExcel(this DataTable dt, string FileName, string SheetName, int HeaderRowIndex)
    {
        HSSFWorkbook workbook = new HSSFWorkbook(new FileStream(FileName, FileMode.Open));
        var sheet = workbook.GetSheet(SheetName);
        var headerRow = sheet.GetRow(HeaderRowIndex);
        int cellCount = headerRow.LastCellNum;

        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
        {
            var row = sheet.GetRow(i);
            DataRow dataRow = dt.NewRow();

            for (int j = row.FirstCellNum; j < cellCount; j++)
            {
                string ColumnName = headerRow.GetCell(j).ToString();
                if (dt.Columns.Contains(ColumnName))
                {
                    if (row.GetCell(j) != null)
                    {
                        try
                        {
                            dataRow[ColumnName] = Convert.ToDateTime(row.GetCell(j).ToString()).ToString("yyyy/M/d");
                        }
                        catch
                        {
                            dataRow[ColumnName] = row.GetCell(j).ToString();
                        }
                    }
                }
            }

            dt.Rows.Add(dataRow);
        }

        workbook = null;
        sheet = null;
    }

    public static void FillDataByExcel(this DataTable dt, HSSFSheet sheet, int HeaderRowIndex)
    {
        var headerRow = sheet.GetRow(HeaderRowIndex);
        int cellCount = headerRow.LastCellNum;

        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
        {
            var row = sheet.GetRow(i);
            DataRow dataRow = dt.NewRow();

            for (int j = row.FirstCellNum; j < cellCount; j++)
            {
                string ColumnName = headerRow.GetCell(j).ToString();
                if (dt.Columns.Contains(ColumnName))
                {
                    if (row.GetCell(j) != null)
                    {
                        try
                        {
                            dataRow[ColumnName] = Convert.ToDateTime(row.GetCell(j).ToString()).ToString("yyyy/M/d");
                        }
                        catch
                        {
                            dataRow[ColumnName] = row.GetCell(j).ToString();
                        }
                    }
                }
            }

            dt.Rows.Add(dataRow);
        }

        sheet = null;
    }
}
