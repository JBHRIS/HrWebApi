using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;

namespace JBModule.Data
{
    public class CNPOI
    {
        //public static Stream RenderDataTableToExcel(DataTable SourceTable)
        //{
        //    HSSFWorkbook workbook = new HSSFWorkbook();
        //    MemoryStream ms = new MemoryStream();
        //    HSSFSheet sheet = workbook.CreateSheet() as HSSFSheet;
        //    HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;

        //    HSSFCellStyle intCellStyle = workbook.CreateCellStyle() as HSSFCellStyle;
        //    intCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

        //    HSSFCellStyle doubleCellStyle = workbook.CreateCellStyle() as HSSFCellStyle;
        //    doubleCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");

        //    HSSFCellStyle dateCellStyle = workbook.CreateCellStyle() as HSSFCellStyle;
        //    dateCellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("yyyy/mm/dd");

        //    // handling header.
        //    foreach (DataColumn column in SourceTable.Columns)
        //    {
        //        if (column.Caption.Trim().Length == 0)
        //        {
        //            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
        //        }
        //        else headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);
        //    }

        //    // handling value.
        //    int rowIndex = 1;

        //    foreach (DataRow row in SourceTable.Rows)
        //    {
        //        HSSFRow dataRow = sheet.CreateRow(rowIndex) as HSSFRow;

        //        foreach (DataColumn column in SourceTable.Columns)
        //        {
        //            Type t = column.DataType;
        //            HSSFCell cell = dataRow.CreateCell(column.Ordinal) as HSSFCell;
        //            if (t == typeof(bool))
        //            {
        //                cell.CellStyle = intCellStyle;
        //                if (row.IsNull(column.ColumnName)) cell.SetCellValue(0);
        //                else
        //                {
        //                    if (Convert.ToBoolean(row[column.ColumnName])) cell.SetCellValue(1);
        //                    else cell.SetCellValue(0);
        //                }
        //            }
        //            else if (t == typeof(int))
        //            {
        //                cell.CellStyle = intCellStyle;
        //                if (row.IsNull(column.ColumnName)) cell.SetCellValue(0);
        //                else cell.SetCellValue(Convert.ToInt32(row[column.ColumnName]));
        //            }
        //            else if (t == typeof(decimal) || t == typeof(double) || t == typeof(float))
        //            {
        //                cell.CellStyle = doubleCellStyle;
        //                if (row.IsNull(column.ColumnName)) cell.SetCellValue(0.00);
        //                else cell.SetCellValue(Convert.ToDouble(row[column.ColumnName]));
        //            }
        //            else if (t == typeof(DateTime))
        //            {
        //                cell.CellStyle = dateCellStyle;
        //                if (row.IsNull(column.ColumnName)) cell.SetCellValue("");
        //                else cell.SetCellValue(Convert.ToDateTime(row[column.ColumnName]).Date);
        //            }
        //            else
        //            {
        //                if (row.IsNull(column.ColumnName)) cell.SetCellValue("");
        //                else cell.SetCellValue(Convert.ToString(row[column.ColumnName]).Trim());
        //            }
        //        }

        //        rowIndex++;
        //    }

        //    workbook.Write(ms);
        //    ms.Flush();
        //    ms.Position = 0;

        //    sheet = null;
        //    headerRow = null;
        //    workbook = null;

        //    return ms;
        //}

        //public static Stream RenderDataViewToExcel(DataView SourceView)
        //{
        //    HSSFWorkbook workbook = new HSSFWorkbook();
        //    MemoryStream ms = new MemoryStream();
        //    HSSFSheet sheet = workbook.CreateSheet() as HSSFSheet;
        //    HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;

        //    HSSFCellStyle intCellStyle = workbook.CreateCellStyle() as HSSFCellStyle;
        //    intCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");

        //    HSSFCellStyle doubleCellStyle = workbook.CreateCellStyle() as HSSFCellStyle;
        //    doubleCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");

        //    HSSFCellStyle dateCellStyle = workbook.CreateCellStyle() as HSSFCellStyle;
        //    dateCellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("yyyy/mm/dd");

        //    // handling header.
        //    foreach (DataColumn column in SourceView.Table.Columns)
        //    {
        //        if (column.Caption.Trim().Length == 0)
        //        {
        //            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
        //        }
        //        else headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);
        //    }

        //    // handling value.
        //    int rowIndex = 1;

        //    foreach (DataRowView dvrow in SourceView)
        //    {
        //        DataRow row = dvrow.Row;
        //        HSSFRow dataRow = sheet.CreateRow(rowIndex) as HSSFRow;

        //        foreach (DataColumn column in SourceView.Table.Columns)
        //        {
        //            Type t = column.DataType;
        //            HSSFCell cell = dataRow.CreateCell(column.Ordinal) as HSSFCell;
        //            if (t == typeof(bool))
        //            {
        //                cell.CellStyle = intCellStyle;
        //                if (row.IsNull(column.ColumnName)) cell.SetCellValue(0);
        //                else
        //                {
        //                    if (Convert.ToBoolean(row[column.ColumnName])) cell.SetCellValue(1);
        //                    else cell.SetCellValue(0);
        //                }
        //            }
        //            else if (t == typeof(int))
        //            {
        //                cell.CellStyle = intCellStyle;
        //                if (row.IsNull(column.ColumnName)) cell.SetCellValue(0);
        //                else cell.SetCellValue(Convert.ToInt32(row[column.ColumnName]));
        //            }
        //            else if (t == typeof(decimal) || t == typeof(double) || t == typeof(float))
        //            {
        //                cell.CellStyle = doubleCellStyle;
        //                if (row.IsNull(column.ColumnName)) cell.SetCellValue(0.00);
        //                else cell.SetCellValue(Convert.ToDouble(row[column.ColumnName]));
        //            }
        //            else if (t == typeof(DateTime))
        //            {
        //                cell.CellStyle = dateCellStyle;
        //                if (row.IsNull(column.ColumnName)) cell.SetCellValue("");
        //                else cell.SetCellValue(Convert.ToDateTime(row[column.ColumnName]).Date);
        //            }
        //            else
        //            {
        //                if (row.IsNull(column.ColumnName)) cell.SetCellValue("");
        //                else cell.SetCellValue(Convert.ToString(row[column.ColumnName]).Trim());
        //            }
        //        }

        //        rowIndex++;
        //    }

        //    workbook.Write(ms);
        //    ms.Flush();
        //    ms.Position = 0;

        //    sheet = null;
        //    headerRow = null;
        //    workbook = null;

        //    return ms;
        //}

        public static void RenderDataTableToExcel(DataTable SourceTable, string FileName)
        {
            //MemoryStream ms = RenderDataTableToExcel(SourceTable) as MemoryStream;
            //FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            //byte[] data = ms.ToArray();

            //fs.Write(data, 0, data.Length);
            //fs.Flush();
            //fs.Close();

            //data = null;
            //ms = null;
            //fs = null;
            DataSet ds = new DataSet();
            ds.Tables.Add(SourceTable);
            SaveDataSetToExcel(ds, FileName);
            ds.Tables.Remove(SourceTable);
        }

        public static void RenderDataViewToExcel(DataView SourceView, string FileName)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(SourceView.Table.Copy());
            SaveDataSetToExcel(ds, FileName);
        }

        public static DataTable RenderDataTableFromExcel(string FileName, string SheetName, int HeaderRowIndex)
        {
            JBTools.IO.NpoiExcelReader reader = new JBTools.IO.NpoiExcelReader(FileName);
            if (reader.IsOpened()) throw new Exception("檔案已被開啟中");
            var table = reader.LoadExcelToDataTable(SheetName);

            //HSSFWorkbook workbook = new HSSFWorkbook(new FileStream(FileName, FileMode.Open));
            //HSSFSheet sheet = workbook.GetSheet(SheetName) as HSSFSheet;

            //DataTable table = new DataTable();

            //HSSFRow headerRow = sheet.GetRow(HeaderRowIndex) as HSSFRow;
            //int cellCount = headerRow.LastCellNum;

            //for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            //{
            //    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
            //    table.Columns.Add(column);
            //}

            //int rowCount = sheet.LastRowNum;

            //for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            //{
            //    HSSFRow row = sheet.GetRow(i) as HSSFRow;
            //    DataRow dataRow = table.NewRow();

            //    for (int j = row.FirstCellNum; j < cellCount; j++)
            //    {
            //        if (row.GetCell(j) != null)
            //        {
            //            try
            //            {
            //                dataRow[j] = Convert.ToDateTime(row.GetCell(j).ToString()).ToString("yyyy/M/d");
            //            }
            //            catch
            //            {
            //                dataRow[j] = row.GetCell(j).ToString();
            //            }
            //        }
            //    }

            //    table.Rows.Add(dataRow);
            //}

            //workbook = null;
            //sheet = null;
            return table;
        }

        public static DataTable RenderDataTableFromExcel(string FileName, int SheetIndex, int HeaderRowIndex)
        {
            JBTools.IO.NpoiExcelReader reader = new JBTools.IO.NpoiExcelReader(FileName);
            if (reader.IsOpened()) throw new Exception("檔案已被開啟中");
            var ds = reader.LoadExcelToDataSet();
            var table = ds.Tables[SheetIndex];
            //HSSFWorkbook workbook = new HSSFWorkbook(new FileStream(FileName, FileMode.Open));
            //HSSFSheet sheet = workbook.GetSheetAt(SheetIndex) as HSSFSheet;

            //DataTable table = new DataTable();

            //HSSFRow headerRow = sheet.GetRow(HeaderRowIndex) as HSSFRow;
            //int cellCount = headerRow.LastCellNum;
            //int columnCount = 0;
            //for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            //{
            //    DataColumn column = null;
            //    if (headerRow.GetCell(i) != null)
            //        column = new DataColumn(headerRow.GetCell(i).StringCellValue);
            //    else column = new DataColumn("Empty" + (columnCount++).ToString());
            //    table.Columns.Add(column);
            //}

            //int rowCount = sheet.LastRowNum;

            //for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            //{
            //    HSSFRow row = sheet.GetRow(i) as HSSFRow;
            //    DataRow dataRow = table.NewRow();
            //    if (row.FirstCellNum >= 0)
            //        for (int j = row.FirstCellNum; j < cellCount; j++)
            //        {
            //            if (sheet.GetRow(i).GetCell(j) == null)
            //                dataRow[table.Columns[j]] = "";
            //            else if (sheet.GetRow(i).GetCell(j).CellType == CellType.STRING)
            //                dataRow[table.Columns[j]] = sheet.GetRow(i).GetCell(j).StringCellValue;
            //            else if (sheet.GetRow(i).GetCell(j).CellType == CellType.NUMERIC)
            //                dataRow[table.Columns[j]] = sheet.GetRow(i).GetCell(j).NumericCellValue;
            //            else if (sheet.GetRow(i).GetCell(j).CellType == CellType.BOOLEAN)
            //                dataRow[table.Columns[j]] = sheet.GetRow(i).GetCell(j).BooleanCellValue;
            //            else if (sheet.GetRow(i).GetCell(j).CellType == CellType.FORMULA)
            //            {
            //                CellType format = sheet.GetRow(i).GetCell(j).CachedFormulaResultType;
            //                if (format == CellType.NUMERIC)
            //                    dataRow[table.Columns[j]] = sheet.GetRow(i).GetCell(j).NumericCellValue;
            //                else if (format == CellType.FORMULA)
            //                    dataRow[table.Columns[j]] = sheet.GetRow(i).GetCell(j).DateCellValue;
            //                else dataRow[table.Columns[j]] = sheet.GetRow(i).GetCell(j).StringCellValue;
            //            }
            //            else dataRow[table.Columns[j]] = sheet.GetRow(i).GetCell(j).ToString();
            //            //if (row.GetCell(j) != null)
            //            //{
            //            //    try
            //            //    {
            //            //        dataRow[j] = Convert.ToDateTime(row.GetCell(j).ToString()).ToString("yyyy/M/d");
            //            //    }
            //            //    catch
            //            //    {
            //            //        dataRow[j] = row.GetCell(j).ToString();
            //            //    }
            //            //}
            //        }

            //    table.Rows.Add(dataRow);
            //}

            //workbook = null;
            //sheet = null;
            return table;
        }

        /// <summary>
        /// Excel的工作表轉換成DataTable
        /// </summary>
        /// <param name="sPath">檔案名稱包含路徑</param>
        /// <param name="sColumnText">欄位名稱(預設為t)</param>
        /// <param name="sColumnValue">欄位值(預設為v)</param>
        /// <returns>DataTable</returns>
        public static DataTable RenderExcelSheetToDataTable(string sPath, string sColumnText = "t", string sColumnValue = "v")
        {
            FileStream fs = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            HSSFWorkbook workbook = new HSSFWorkbook(fs);
            fs.Close();
            fs.Dispose();

            DataTable dt = new DataTable();
            dt.Columns.Add(sColumnText, typeof(string)).DefaultValue = 0;
            dt.Columns.Add(sColumnValue, typeof(int)).DefaultValue = 0;
            DataRow r;
            r = dt.NewRow();
            r[sColumnText] = "請選擇工作表...";
            r[sColumnValue] = -1;
            dt.Rows.Add(r);
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                r = dt.NewRow();
                r[sColumnText] = workbook.GetSheetName(i);
                r[sColumnValue] = i;
                dt.Rows.Add(r);
            }

            return dt;
        }
        public static void CreateCSVFile(DataTable dt, string strFilePath) // strFilePath 為輸出檔案路徑 (含檔名)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false, System.Text.Encoding.Unicode);
            //sw. = System.Text.Encoding.Unicode;// System.Text.UTF8Encoding;
            int intColCount = dt.Columns.Count;

            if (dt.Columns.Count > 0)
                sw.Write(dt.Columns[0]);
            for (int i = 1; i < dt.Columns.Count; i++)
                sw.Write("," + dt.Columns[i]);

            sw.Write(sw.NewLine);
            foreach (DataRow dr in dt.Rows)
            {
                if (dt.Columns.Count > 0 && !Convert.IsDBNull(dr[0]))
                    sw.Write(Encode(Convert.ToString(dr[0])));
                for (int i = 1; i < intColCount; i++)
                    sw.Write("," + Encode(Convert.ToString(dr[i])));
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
        public static string Encode(string strEnc)
        {
            //return System.Web.HttpUtility.UrlEncode(strEnc);

            return strEnc;
        }
        public static System.Data.DataSet ReadExcelToDataSet(string filePath, JBTools.IO.LoadExcelColumnNameStyle style, int StartRowIndex = 0)
        {

            JBTools.IO.NpoiExcelReader reader = new JBTools.IO.NpoiExcelReader(filePath);
            reader.ColumnPosition = StartRowIndex;
            reader.ColumnNameStyle = style;
            return reader.LoadExcelToDataSet();
        }
        public static System.Data.DataSet ReadExcelToDataSet(string filePath)//, CallBackEvent.UpdateProgressCallBack callBack)
        {
            JBTools.IO.NpoiExcelReader reader = new JBTools.IO.NpoiExcelReader(filePath);
            //reader.ColumnNameStyle = JBTools.IO.LoadExcelColumnNameStyle.ExcelColumnName;
            return reader.LoadExcelToDataSet();
            ////開啟要讀取的Excel檔案
            //FileStream file = new FileStream(filePath, FileMode.Open);
            ////讀入Excel檔
            //HSSFWorkbook workbook = new HSSFWorkbook(file);
            //file.Close();

            //DataSet dsSource = new DataSet();
            ////為每個WorkSeeh建立出一個table
            //for (int sheetIndex = 0; sheetIndex < workbook.NumberOfSheets; sheetIndex++)
            //{
            //    HSSFSheet sheet = workbook.GetSheetAt(sheetIndex) as HSSFSheet;
            //    //建立一個新的table
            //    DataTable dtNew = dsSource.Tables.Add(workbook.GetSheetName(sheetIndex));
            //    try
            //    {
            //        HSSFRow row = sheet.GetRow(0) as HSSFRow;
            //        //讀取第0列當作column name
            //        if (row == null) continue;//第一列無資料，視為無效工作表
            //        for (int columnIndex = 0; columnIndex < row.LastCellNum; columnIndex++)
            //        {
            //            var col = row.GetCell(columnIndex);
            //            if (col != null)
            //            {
            //                DataColumn dc = new DataColumn(col.ToString());
            //                dtNew.Columns.Add(dc);
            //            }
            //            else break;
            //        }

            //        int rowId = 1;
            //        //第一列以後為資料，一直讀到最後一行
            //        while (rowId <= sheet.LastRowNum)
            //        {
            //            DataRow newRow = dtNew.NewRow();
            //            //讀取所有column
            //            for (int colIndex = 0; colIndex < dtNew.Columns.Count; colIndex++)
            //            {
            //                if (sheet.GetRow(rowId).GetCell(colIndex) == null)
            //                    newRow[dtNew.Columns[colIndex]] = "";
            //                else if (sheet.GetRow(rowId).GetCell(colIndex).CellType == CellType.STRING)
            //                    newRow[dtNew.Columns[colIndex]] = sheet.GetRow(rowId).GetCell(colIndex).StringCellValue;
            //                else if (sheet.GetRow(rowId).GetCell(colIndex).CellType == CellType.NUMERIC)
            //                    newRow[dtNew.Columns[colIndex]] = sheet.GetRow(rowId).GetCell(colIndex).NumericCellValue;
            //                else if (sheet.GetRow(rowId).GetCell(colIndex).CellType == CellType.BOOLEAN)
            //                    newRow[dtNew.Columns[colIndex]] = sheet.GetRow(rowId).GetCell(colIndex).BooleanCellValue;
            //                else if (sheet.GetRow(rowId).GetCell(colIndex).CellType == CellType.FORMULA)
            //                    newRow[dtNew.Columns[colIndex]] = sheet.GetRow(rowId).GetCell(colIndex).DateCellValue;
            //                else newRow[dtNew.Columns[colIndex]] = sheet.GetRow(rowId).GetCell(colIndex).ToString();
            //            }

            //            dtNew.Rows.Add(newRow);

            //            rowId++;


            //        }
            //    }
            //    catch (Exception ex)
            //    {

            //    }

            //    //dsSource.Tables.Add(dtNew);
            //}
            //return dsSource;
        }
        //public static DataTable ConvertWorksheetToDatatable(HSSFSheet sheet)
        //{
        //    DataTable dtNew = new DataTable(sheet.SheetName);
        //    try
        //    {
        //        HSSFRow row = sheet.GetRow(0) as HSSFRow;
        //        //讀取第0列當作column name
        //        if (row != null) //第一列無資料，視為無效工作表
        //        {
        //            for (int columnIndex = 0; columnIndex < row.LastCellNum; columnIndex++)
        //            {
        //                var col = row.GetCell(columnIndex);
        //                if (col != null)
        //                {
        //                    DataColumn dc = new DataColumn(col.ToString());
        //                    dtNew.Columns.Add(dc);
        //                }
        //                else break;
        //            }

        //            int rowId = 1;
        //            //第一列以後為資料，一直讀到最後一行
        //            while (rowId <= sheet.LastRowNum)
        //            {
        //                DataRow newRow = dtNew.NewRow();
        //                //讀取所有column
        //                for (int colIndex = 0; colIndex < dtNew.Columns.Count; colIndex++)
        //                {
        //                    if (sheet.GetRow(rowId).GetCell(colIndex) == null)
        //                        newRow[dtNew.Columns[colIndex]] = "";
        //                    else if (sheet.GetRow(rowId).GetCell(colIndex).CellType == CellType.STRING)
        //                        newRow[dtNew.Columns[colIndex]] = sheet.GetRow(rowId).GetCell(colIndex).StringCellValue;
        //                    else if (sheet.GetRow(rowId).GetCell(colIndex).CellType == CellType.NUMERIC)
        //                        newRow[dtNew.Columns[colIndex]] = sheet.GetRow(rowId).GetCell(colIndex).NumericCellValue;
        //                    else if (sheet.GetRow(rowId).GetCell(colIndex).CellType == CellType.BOOLEAN)
        //                        newRow[dtNew.Columns[colIndex]] = sheet.GetRow(rowId).GetCell(colIndex).BooleanCellValue;
        //                    else if (sheet.GetRow(rowId).GetCell(colIndex).CellType == CellType.FORMULA)
        //                        newRow[dtNew.Columns[colIndex]] = sheet.GetRow(rowId).GetCell(colIndex).DateCellValue;
        //                    else newRow[dtNew.Columns[colIndex]] = sheet.GetRow(rowId).GetCell(colIndex).ToString();
        //                }

        //                dtNew.Rows.Add(newRow);

        //                rowId++;


        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return dtNew;
        //}


        public static void SaveDataSetToExcel(System.Data.DataSet dsSource, string filePath)//, CallBackEvent.UpdateProgressCallBack callBack)
        {
            SaveDataSetToExcel(dsSource, filePath, false);
        }
        public static void SaveDataSetToExcel(System.Data.DataSet dsSource, string filePath, bool PrintGridLine)//, CallBackEvent.UpdateProgressCallBack 
        {
            JBTools.IO.NpoiExcelWriter writer = new JBTools.IO.NpoiExcelWriter(dsSource);
            writer.PrintGridLine = PrintGridLine;
            writer.Save(filePath);
            ////建立一個工作簿
            //HSSFWorkbook workbook = new HSSFWorkbook();

            ////為每table建立一個活頁簿WorkSheet
            //for (int i = 0; i < dsSource.Tables.Count; i++)
            //{
            //    //callback部份用來判斷目前讀到的table百分比，供顯示進度表之用
            //    //if (callBack != null)
            //    //    callBack((int)(((float)i / (float)dsSource.Tables.Count) * (float)100));

            //    System.Data.DataTable dt = dsSource.Tables[i];

            //    //建立活頁簿
            //    HSSFSheet sheet = workbook.CreateSheet(dt.TableName) as HSSFSheet;

            //    //為避免日期格式被Excel自動換掉，所以設定 format 為 『@』 表示一率當成text來看
            //    HSSFCellStyle spanStyle = workbook.CreateCellStyle() as HSSFCellStyle;
            //    HSSFCellStyle bodyStyle = workbook.CreateCellStyle() as HSSFCellStyle;
            //    if (PrintGridLine)
            //    {
            //        spanStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
            //        //設定表頭背景顏色
            //        //spanStyle.FillForegroundColor = HSSFColor.BROWN.index;
            //        //spanStyle.FillPattern = FillPatternType.SOLID_FOREGROUND;
            //        //設定表頭儲存格框線
            //        spanStyle.BorderBottom = CellBorderType.THIN;
            //        spanStyle.BorderLeft = CellBorderType.THIN;

            //        spanStyle.BorderRight = CellBorderType.THIN;

            //        spanStyle.BorderTop = CellBorderType.THIN;
            //        spanStyle.BottomBorderColor = HSSFColor.BLACK.index;
            //        spanStyle.LeftBorderColor = HSSFColor.BLACK.index;
            //        spanStyle.RightBorderColor = HSSFColor.BLACK.index;
            //        spanStyle.TopBorderColor = HSSFColor.BLACK.index;

            //        //設定表身儲存格框線
            //        bodyStyle.BorderBottom = CellBorderType.THIN;
            //        bodyStyle.BorderLeft = CellBorderType.THIN;

            //        bodyStyle.BorderRight = CellBorderType.THIN;

            //        bodyStyle.BorderTop = CellBorderType.THIN;
            //        bodyStyle.BottomBorderColor = HSSFColor.BLACK.index;
            //        bodyStyle.LeftBorderColor = HSSFColor.BLACK.index;
            //        bodyStyle.RightBorderColor = HSSFColor.BLACK.index;
            //        bodyStyle.TopBorderColor = HSSFColor.BLACK.index;
            //    }
            //    //用column name 當成標題列
            //    List<String> columns = new List<string>();
            //    HSSFRow firstRow = sheet.CreateRow(0) as HSSFRow;
            //    for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
            //    {
            //        string name = dt.Columns[colIndex].ColumnName;
            //        HSSFCell cell = firstRow.CreateCell(colIndex) as HSSFCell;
            //        cell.SetCellValue(name);
            //        cell.CellStyle = spanStyle;
            //        columns.Add(name);
            //    }

            //    //建立資料列
            //    for (int row = 0; row < dt.Rows.Count; row++)
            //    {
            //        DataRow dr = dt.Rows[row];
            //        HSSFRow newRow = sheet.CreateRow(row + 1) as HSSFRow;
            //        for (int col = 0; col < columns.Count; col++)
            //        {
            //            string data = dr[columns[col]].ToString();
            //            string data1 = dr[columns[col]].ToString();
            //            HSSFCell cell = newRow.CreateCell(col) as HSSFCell;

            //            cell.SetCellValue(data);

            //            if (dr[columns[col]].GetType() == typeof(DateTime))
            //            {
            //                data = Convert.ToDateTime(dr[columns[col]]).ToString("yyyy/MM/dd");
            //                data1 = Convert.ToDateTime(dr[columns[col]]).ToString("yyyy/MM/dd HH:mm:ss");
            //                if (Convert.ToDateTime(data1) > Convert.ToDateTime(data))
            //                    cell.SetCellValue(data1);
            //                else cell.SetCellValue(data);

            //            }
            //            else if (dr[columns[col]].GetType() == typeof(decimal))
            //            {
            //                double odata = Convert.ToDouble(dr[columns[col]]);
            //                cell.SetCellValue(odata);
            //            }
            //            else if (dr[columns[col]].GetType() == typeof(Int32))
            //            {
            //                double odata = Convert.ToDouble(dr[columns[col]]);
            //                cell.SetCellValue(odata);
            //            }


            //            cell.CellStyle = bodyStyle;
            //        }
            //    }
            //}
            ////if (callBack != null) callBack(100);

            ////寫入檔案
            //FileInfo fileInfo = new FileInfo(filePath);
            //JBTools.IO.FileSystem.CheckPath(fileInfo.Directory.FullName);

            //FileStream file = new FileStream(filePath, FileMode.OpenOrCreate);
            //workbook.Write(file);
            //file.Close();
            //file.Dispose();
        }
        public static void SetExcelCellStyle(string sPath, string sSheetName, int iRowNumber, int iCellNumber)
        {

        }
        public static void SetExcelRowState(string FilePath, string SheetName, int RowIndex, ExcelRowState state)
        {
            if (FilePath.Trim().Length > 0 && File.Exists(FilePath))
            {
                FileStream file = new FileStream(FilePath, FileMode.Open);
                //讀入Excel檔
                HSSFWorkbook workbook = new HSSFWorkbook(file);
                file.Close();
                var sheet = workbook.GetSheetAt(0);
                var row = sheet.GetRow(RowIndex);

                NPOI.SS.UserModel.IFont font1 = workbook.CreateFont();
                font1.Color = (short)state;
                NPOI.SS.UserModel.ICellStyle rowStyle = workbook.CreateCellStyle();
                rowStyle.SetFont(font1);
                for (int i = 0; i < 30; i++)
                {
                    var cell = row.GetCell(i);
                    if (cell == null)
                        break;
                    cell.CellStyle = rowStyle;
                }

                file = new FileStream(FilePath, FileMode.Open);
                workbook.Write(file);
                file.Flush();
                file.Close();
            }
        }
        public static void CreateExcelSheetFromTemplate(DataTable Source, string TemplatePath, string FilePath)
        {
            if (FilePath.Trim().Length > 0 && File.Exists(TemplatePath))
            {
                FileStream file = new FileStream(TemplatePath, FileMode.Open);
                //讀入Excel檔
                HSSFWorkbook workbook = new HSSFWorkbook(file);
                file.Close();
                ISheet sheet = workbook.GetSheet(Source.TableName);
                int idx = workbook.GetSheetIndex(Source.TableName);
                if (idx != -1)
                    workbook.RemoveSheetAt(idx);
                var newSheet = ConvertDatatableToSheet(Source, workbook);
                file = new FileStream(FilePath, FileMode.Open);
                workbook.Write(file);
                file.Flush();
                file.Close();
            }
        }
        public static void ExportToExcel(DataTable Source, string FilePath, string TemplatePath)
        {
            if (FilePath.Trim().Length > 0)
            {
                string FileName = FilePath.Substring(FilePath.LastIndexOf(@"\") + 1);
                string TemplateFullPath = Path.Combine(TemplatePath, FileName);
                if (File.Exists(TemplateFullPath))
                {
                    CreateExcelSheetFromTemplate(Source, TemplateFullPath, FilePath);
                }
                else
                {
                    var ds = new DataSet();
                    if (Source.DataSet != null)
                    {
                        var cloneDt = Source.Clone();
                        foreach (DataRow r in Source.Rows)
                            cloneDt.ImportRow(r);
                        ds.Tables.Add(cloneDt);
                    }
                    else
                        ds.Tables.Add(Source);
                    SaveDataSetToExcel(ds, FilePath);
                }
            }
        }
        public static ISheet ConvertDatatableToSheet(DataTable dsSource, HSSFWorkbook workbook)
        {
            System.Data.DataTable dt = dsSource;

            //建立活頁簿
            HSSFSheet sheet = workbook.CreateSheet(dt.TableName) as HSSFSheet;

            //為避免日期格式被Excel自動換掉，所以設定 format 為 『@』 表示一率當成text來看
            HSSFCellStyle spanStyle = workbook.CreateCellStyle() as HSSFCellStyle;
            HSSFCellStyle bodyStyle = workbook.CreateCellStyle() as HSSFCellStyle;

            //用column name 當成標題列
            List<String> columns = new List<string>();
            HSSFRow firstRow = sheet.CreateRow(0) as HSSFRow;
            for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
            {
                string name = dt.Columns[colIndex].ColumnName;
                HSSFCell cell = firstRow.CreateCell(colIndex) as HSSFCell;
                cell.SetCellValue(name);
                cell.CellStyle = spanStyle;
                columns.Add(name);
            }

            //建立資料列
            for (int row = 0; row < dt.Rows.Count; row++)
            {
                DataRow dr = dt.Rows[row];
                HSSFRow newRow = sheet.CreateRow(row + 1) as HSSFRow;
                for (int col = 0; col < columns.Count; col++)
                {
                    string data = dr[columns[col]].ToString();
                    string data1 = dr[columns[col]].ToString();
                    HSSFCell cell = newRow.CreateCell(col) as HSSFCell;

                    cell.SetCellValue(data);

                    if (dr[columns[col]].GetType() == typeof(DateTime))
                    {
                        data = Convert.ToDateTime(dr[columns[col]]).ToString("yyyy/MM/dd");
                        data1 = Convert.ToDateTime(dr[columns[col]]).ToString("yyyy/MM/dd HH:mm:ss");
                        if (Convert.ToDateTime(data1) > Convert.ToDateTime(data))
                            cell.SetCellValue(data1);
                        else cell.SetCellValue(data);

                    }
                    else if (dr[columns[col]].GetType() == typeof(decimal))
                    {
                        double odata = Convert.ToDouble(dr[columns[col]]);
                        cell.SetCellValue(odata);
                    }
                    else if (dr[columns[col]].GetType() == typeof(Int32))
                    {
                        double odata = Convert.ToDouble(dr[columns[col]]);
                        cell.SetCellValue(odata);
                    }

                    cell.CellStyle = bodyStyle;
                }
            }
            return sheet;
        }
        public static void SetExcelRowState(string FilePath, string SheetName, Dictionary<int, ExcelRowState> stateList)
        {
            if (FilePath.Trim().Length > 0 && File.Exists(FilePath))
            {
                FileStream file = new FileStream(FilePath, FileMode.Open);
                //讀入Excel檔

                IWorkbook workbook = null;
                string ExtensionName = Path.GetExtension(FilePath);
                if (ExtensionName.Trim().ToUpper() == ".XLS")
                    workbook = new HSSFWorkbook(file);
                else if (ExtensionName.Trim().ToUpper() == ".XLSX")
                    //workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(file);
                    return;//xlsx會有問題
                else throw new Exception("不支援的檔案格式" + ExtensionName);
                //file.Close();
                var sheet = workbook.GetSheet(SheetName);


                NPOI.SS.UserModel.IFont font1 = workbook.CreateFont();

                for (int j = 0; j <= sheet.LastRowNum; j++)
                {
                    NPOI.SS.UserModel.ICellStyle rowStyle = workbook.CreateCellStyle();
                    var row = sheet.GetRow(j);
                    if (row == null) continue;
                    font1.Color = (short)ExcelRowState.Normal;

                    rowStyle.SetFont(font1);
                    for (int i = 0; i < 50; i++)
                    {
                        var cell = row.GetCell(i);
                        if (cell == null)
                            break;
                        cell.CellStyle = rowStyle;
                    }
                }


                foreach (var itm in stateList)
                {
                    NPOI.SS.UserModel.IFont font2 = workbook.CreateFont();
                    NPOI.SS.UserModel.ICellStyle rowStyle1 = workbook.CreateCellStyle();
                    var row = sheet.GetRow(itm.Key);
                    font2.Color = (short)itm.Value;

                    rowStyle1.SetFont(font2);
                    for (int i = 0; i < 50; i++)
                    {
                        var cell = row.GetCell(i);
                        if (cell == null)
                            break;
                        cell.CellStyle = rowStyle1;
                    }
                }
                file = new FileStream(FilePath, FileMode.Open);
                workbook.Write(file);
                file.Flush();
                file.Close();
            }
        }
        public enum ExcelRowState
        {
            Normal = 8,
            Error = 10,
            Repeat = 11,
            DataCheck = 12
        }
    }
}
