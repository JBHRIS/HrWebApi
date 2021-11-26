using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.HSSF.Util;
namespace JBTools.IO
{
    public class NpoiExcelWriter : IExcelWriter
    {
        DataSet _source;
        public NpoiExcelWriter(DataSet Source)
        {
            _source = Source;
            PrintGridLine = false;
        }
        #region IExcelWriter 成員

        public void Save(string FileName)
        {
            //建立一個工作簿
            IWorkbook workbook = new HSSFWorkbook();

            //為每table建立一個活頁簿WorkSheet
            for (int i = 0; i < _source.Tables.Count; i++)
            {
                //callback部份用來判斷目前讀到的table百分比，供顯示進度表之用
                //if (callBack != null)
                //    callBack((int)(((float)i / (float)dsSource.Tables.Count) * (float)100));
                if (_source.Tables[i].Rows.Count > 65535)
                {
                    System.Windows.Forms.MessageBox.Show("超出 Excel 最大筆數限制 65535, 請重新選擇匯出資料！");
                    return;
                }
                System.Data.DataTable dt = _source.Tables[i];

                //建立活頁簿
                HSSFSheet sheet = workbook.CreateSheet(dt.TableName) as HSSFSheet;

                //為避免日期格式被Excel自動換掉，所以設定 format 為 『@』 表示一率當成text來看
                ICellStyle spanStyleTemp = workbook.CreateCellStyle();
                ICellStyle bodyStyleTemp = workbook.CreateCellStyle();
                ICellStyle datetimeCellStyleTemp = workbook.CreateCellStyle();
                if (PrintGridLine)
                {
                    spanStyleTemp.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
                    //設定表頭背景顏色
                    //spanStyle.FillForegroundColor = HSSFColor.BROWN.index;
                    //spanStyle.FillPattern = FillPatternType.SOLID_FOREGROUND;
                    //設定表頭儲存格框線
                    spanStyleTemp.BorderBottom = BorderStyle.THIN;
                    spanStyleTemp.BorderLeft = BorderStyle.THIN;

                    spanStyleTemp.BorderRight = BorderStyle.THIN;

                    spanStyleTemp.BorderTop = BorderStyle.THIN;
                    spanStyleTemp.BottomBorderColor = HSSFColor.BLACK.index;
                    spanStyleTemp.LeftBorderColor = HSSFColor.BLACK.index;
                    spanStyleTemp.RightBorderColor = HSSFColor.BLACK.index;
                    spanStyleTemp.TopBorderColor = HSSFColor.BLACK.index;

                    //設定表身儲存格框線
                    bodyStyleTemp.BorderBottom = BorderStyle.THIN;
                    bodyStyleTemp.BorderLeft = BorderStyle.THIN;

                    bodyStyleTemp.BorderRight = BorderStyle.THIN;

                    bodyStyleTemp.BorderTop = BorderStyle.THIN;
                    bodyStyleTemp.BottomBorderColor = HSSFColor.BLACK.index;
                    bodyStyleTemp.LeftBorderColor = HSSFColor.BLACK.index;
                    bodyStyleTemp.RightBorderColor = HSSFColor.BLACK.index;
                    bodyStyleTemp.TopBorderColor = HSSFColor.BLACK.index;
                }
                //用column name 當成標題列
                List<String> columns = new List<string>();
                HSSFRow firstRow = sheet.CreateRow(0) as HSSFRow;
                for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
                {
                    string name = dt.Columns[colIndex].ColumnName;
                    HSSFCell cell = firstRow.CreateCell(colIndex) as HSSFCell;
                    cell.SetCellValue(name);
                    cell.CellStyle = bodyStyleTemp;
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
                        ICellStyle bodyStyle = bodyStyleTemp;
                        cell.SetCellValue(data);
                        if (dr[columns[col]].GetType() == typeof(DateTime))
                        {
                            bodyStyle = datetimeCellStyleTemp;
                            bodyStyle.CloneStyleFrom(bodyStyleTemp);
                            data = Convert.ToDateTime(dr[columns[col]]).ToString("yyyy/MM/dd");
                            data1 = Convert.ToDateTime(dr[columns[col]]).ToString("yyyy/MM/dd HH:mm:ss");
                            if (Convert.ToDateTime(data1) > Convert.ToDateTime(data))
                            {
                                cell.SetCellValue(Convert.ToDateTime(dr[columns[col]]));
                                IDataFormat dataFormatCustom = workbook.CreateDataFormat();
                                bodyStyle.DataFormat = dataFormatCustom.GetFormat("yyyy/MM/dd HH:mm:ss");
                            }
                            else
                            {
                                cell.SetCellValue(Convert.ToDateTime(dr[columns[col]]));
                                IDataFormat dataFormatCustom = workbook.CreateDataFormat();
                                bodyStyle.DataFormat = dataFormatCustom.GetFormat("yyyy/MM/dd");
                            }
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
            }
            //if (callBack != null) callBack(100);

            //寫入檔案
            FileInfo fileInfo = new FileInfo(FileName);
            JBTools.IO.FileSystem.CheckPath(fileInfo.Directory.FullName);

            FileStream file = new FileStream(FileName, FileMode.OpenOrCreate);
            workbook.Write(file);

            file.Close();
            file.Dispose();
        }
        public IWorkbook GetWorkBook()
        {
            //建立一個工作簿
            HSSFWorkbook workbook = new HSSFWorkbook();

            //為每table建立一個活頁簿WorkSheet
            for (int i = 0; i < _source.Tables.Count; i++)
            {
                //callback部份用來判斷目前讀到的table百分比，供顯示進度表之用
                //if (callBack != null)
                //    callBack((int)(((float)i / (float)dsSource.Tables.Count) * (float)100));
                if (_source.Tables[i].Rows.Count > 65535)
                {
                    System.Windows.Forms.MessageBox.Show("超出 Excel 最大筆數限制 65535, 請重新選擇匯出資料！");
                    return workbook;
                }
                System.Data.DataTable dt = _source.Tables[i];

                //建立活頁簿
                HSSFSheet sheet = workbook.CreateSheet(dt.TableName) as HSSFSheet;

                //為避免日期格式被Excel自動換掉，所以設定 format 為 『@』 表示一率當成text來看
                ICellStyle spanStyleTemp = workbook.CreateCellStyle();
                ICellStyle bodyStyleTemp = workbook.CreateCellStyle();
                ICellStyle datetimeCellStyleTemp = workbook.CreateCellStyle();
                if (PrintGridLine)
                {
                    spanStyleTemp.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
                    //設定表頭背景顏色
                    //spanStyle.FillForegroundColor = HSSFColor.BROWN.index;
                    //spanStyle.FillPattern = FillPatternType.SOLID_FOREGROUND;
                    //設定表頭儲存格框線
                    spanStyleTemp.BorderBottom = BorderStyle.THIN;
                    spanStyleTemp.BorderLeft = BorderStyle.THIN;

                    spanStyleTemp.BorderRight = BorderStyle.THIN;

                    spanStyleTemp.BorderTop = BorderStyle.THIN;
                    spanStyleTemp.BottomBorderColor = HSSFColor.BLACK.index;
                    spanStyleTemp.LeftBorderColor = HSSFColor.BLACK.index;
                    spanStyleTemp.RightBorderColor = HSSFColor.BLACK.index;
                    spanStyleTemp.TopBorderColor = HSSFColor.BLACK.index;

                    //設定表身儲存格框線
                    bodyStyleTemp.BorderBottom = BorderStyle.THIN;
                    bodyStyleTemp.BorderLeft = BorderStyle.THIN;

                    bodyStyleTemp.BorderRight = BorderStyle.THIN;

                    bodyStyleTemp.BorderTop = BorderStyle.THIN;
                    bodyStyleTemp.BottomBorderColor = HSSFColor.BLACK.index;
                    bodyStyleTemp.LeftBorderColor = HSSFColor.BLACK.index;
                    bodyStyleTemp.RightBorderColor = HSSFColor.BLACK.index;
                    bodyStyleTemp.TopBorderColor = HSSFColor.BLACK.index;
                }
                //用column name 當成標題列
                List<String> columns = new List<string>();
                HSSFRow firstRow = sheet.CreateRow(0) as HSSFRow;
                for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
                {
                    string name = dt.Columns[colIndex].ColumnName;
                    HSSFCell cell = firstRow.CreateCell(colIndex) as HSSFCell;
                    cell.SetCellValue(name);
                    cell.CellStyle = bodyStyleTemp;
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
                        ICellStyle bodyStyle = bodyStyleTemp;
                        cell.SetCellValue(data);
                        if (dr[columns[col]].GetType() == typeof(DateTime))
                        {
                            bodyStyle = datetimeCellStyleTemp;
                            bodyStyle.CloneStyleFrom(bodyStyleTemp);
                            data = Convert.ToDateTime(dr[columns[col]]).ToString("yyyy/MM/dd");
                            data1 = Convert.ToDateTime(dr[columns[col]]).ToString("yyyy/MM/dd HH:mm:ss");
                            if (Convert.ToDateTime(data1) > Convert.ToDateTime(data))
                            {
                                cell.SetCellValue(Convert.ToDateTime(dr[columns[col]]));
                                IDataFormat dataFormatCustom = workbook.CreateDataFormat();
                                bodyStyle.DataFormat = dataFormatCustom.GetFormat("yyyy/MM/dd HH:mm:ss");
                            }
                            else
                            {
                                cell.SetCellValue(Convert.ToDateTime(dr[columns[col]]));
                                IDataFormat dataFormatCustom = workbook.CreateDataFormat();
                                bodyStyle.DataFormat = dataFormatCustom.GetFormat("yyyy/MM/dd");
                            }
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
            }
            //if (callBack != null) callBack(100);

            //寫入檔案
            //FileInfo fileInfo = new FileInfo(FileName);
            //JBTools.IO.FileSystem.CheckPath(fileInfo.Directory.FullName);

            //FileStream file = new FileStream(FileName, FileMode.OpenOrCreate);
            //workbook.Write(file);

            //file.Close();
            //file.Dispose();
            return workbook;
        }
        public void Save(string FileName, IWorkbook workbook)
        {
            //寫入檔案
            FileInfo fileInfo = new FileInfo(FileName);
            JBTools.IO.FileSystem.CheckPath(fileInfo.Directory.FullName);

            FileStream file = new FileStream(FileName, FileMode.OpenOrCreate);
            workbook.Write(file);

            file.Close();
            file.Dispose();
        }
        public Stream OutputFileStream()
        {
            //建立一個工作簿
            IWorkbook workbook = new HSSFWorkbook();

            //為每table建立一個活頁簿WorkSheet
            for (int i = 0; i < _source.Tables.Count; i++)
            {
                //callback部份用來判斷目前讀到的table百分比，供顯示進度表之用
                //if (callBack != null)
                //    callBack((int)(((float)i / (float)dsSource.Tables.Count) * (float)100));

                System.Data.DataTable dt = _source.Tables[i];

                //建立活頁簿
                HSSFSheet sheet = workbook.CreateSheet(dt.TableName) as HSSFSheet;

                //為避免日期格式被Excel自動換掉，所以設定 format 為 『@』 表示一率當成text來看
                ICellStyle spanStyle = workbook.CreateCellStyle();
                ICellStyle bodyStyle = workbook.CreateCellStyle();
                if (PrintGridLine)
                {
                    spanStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
                    //設定表頭背景顏色
                    //spanStyle.FillForegroundColor = HSSFColor.BROWN.index;
                    //spanStyle.FillPattern = FillPatternType.SOLID_FOREGROUND;
                    //設定表頭儲存格框線
                    spanStyle.BorderBottom = BorderStyle.THIN;
                    spanStyle.BorderLeft = BorderStyle.THIN;

                    spanStyle.BorderRight = BorderStyle.THIN;

                    spanStyle.BorderTop = BorderStyle.THIN;
                    spanStyle.BottomBorderColor = HSSFColor.BLACK.index;
                    spanStyle.LeftBorderColor = HSSFColor.BLACK.index;
                    spanStyle.RightBorderColor = HSSFColor.BLACK.index;
                    spanStyle.TopBorderColor = HSSFColor.BLACK.index;

                    //設定表身儲存格框線
                    bodyStyle.BorderBottom = BorderStyle.THIN;
                    bodyStyle.BorderLeft = BorderStyle.THIN;

                    bodyStyle.BorderRight = BorderStyle.THIN;

                    bodyStyle.BorderTop = BorderStyle.THIN;
                    bodyStyle.BottomBorderColor = HSSFColor.BLACK.index;
                    bodyStyle.LeftBorderColor = HSSFColor.BLACK.index;
                    bodyStyle.RightBorderColor = HSSFColor.BLACK.index;
                    bodyStyle.TopBorderColor = HSSFColor.BLACK.index;
                }
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
            }

            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            ms.Position = 0;
            return ms;
        }

        public bool PrintGridLine
        {
            get;
            set;
        }

        #endregion
    }
}
