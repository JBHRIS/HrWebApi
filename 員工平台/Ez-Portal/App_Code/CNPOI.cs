using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

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
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();
            HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);

            ICellStyle intCellStyle = workbook.CreateCellStyle();
            intCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

            ICellStyle doubleCellStyle = workbook.CreateCellStyle();
            doubleCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");

            ICellStyle dateCellStyle = workbook.CreateCellStyle();
            dateCellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("yyyy/mm/dd");

            // handling header.
            foreach (DataColumn column in SourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                IRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in SourceTable.Columns)
                {
                    Type t = column.DataType;
                    ICell cell = dataRow.CreateCell(column.Ordinal);
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

        public static Stream RenderDataViewToExcel(DataView SourceView)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet();
            IRow headerRow = sheet.CreateRow(0);

            ICellStyle intCellStyle = workbook.CreateCellStyle();
            intCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

            ICellStyle doubleCellStyle = workbook.CreateCellStyle();
            doubleCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");

            ICellStyle dateCellStyle = workbook.CreateCellStyle();
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
                IRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in SourceView.Table.Columns)
                {
                    Type t = column.DataType;
                    ICell cell = dataRow.CreateCell(column.Ordinal);
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

        public static DataTable RenderDataTableFromExcel(string FileName, string SheetName, int HeaderRowIndex)
        {
            IWorkbook workbook = new HSSFWorkbook(new FileStream(FileName, FileMode.Open));
            ISheet sheet = workbook.GetSheet(SheetName);

            DataTable table = new DataTable();

            IRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
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

            workbook = null;
            sheet = null;
            return table;
        }

        public static DataTable RenderDataTableFromExcel(string FileName, int SheetIndex, int HeaderRowIndex)
        {
            try
            {
                IWorkbook workbook = new HSSFWorkbook(new FileStream(FileName, FileMode.Open));
                ISheet sheet = workbook.GetSheetAt(SheetIndex);

                DataTable table = new DataTable();

                IRow headerRow = sheet.GetRow(HeaderRowIndex);
                int cellCount = headerRow.LastCellNum;

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    try
                    {

                        DataColumn column = new DataColumn(headerRow.GetCell(i).ToString());
                        table.Columns.Add(column);
                    }
                    catch
                    {
                        DataColumn column = new DataColumn(i + "日");
                        table.Columns.Add(column);
                    }
                }

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
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
                                    dataRow[j] = "";
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
            catch (Exception e ){
                throw e;
            }
        }

        public static void FillDataByExcel( DataTable dt, string FileName, string SheetName, int HeaderRowIndex)
        {
            IWorkbook workbook = new HSSFWorkbook(new FileStream(FileName, FileMode.Open));
            ISheet sheet = workbook.GetSheet(SheetName);
            IRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
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
    }
