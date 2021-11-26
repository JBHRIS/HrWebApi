using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.HSSF.Util;
using NPOI.SS.Util;

namespace JBTools.IO
{
   
    public class CustomizExcelWriter : IExcelWriter
    {
        DataSet _source; DataTable HeaderDT;
        public CustomizExcelWriter(DataSet Source, DataTable Headerdt)
        {
            _source = Source;
            PrintGridLine = false;
            HeaderDT = Headerdt;
        }
        #region IExcelWriter 成員

        public void CustomizSave(string FileName)
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


                //產生表頭及合併儲存格
                int HeaderColumnsCount = 0;
                if (PrintHeader)
                {
                    HeaderColumnsCount = HeaderDT.Columns.Count;
                    ICellStyle HeaderStyle = workbook.CreateCellStyle();
                    HSSFCellStyle cs = (HSSFCellStyle)workbook.CreateCellStyle();
                    //HeaderStyle.VerticalAlignment = VerticalAlignment.CENTER;
                    
                    for (int j = 0; j < HeaderDT.Columns.Count; j++)
                    {
                        IRow row = sheet.CreateRow(j);
                        HSSFCell Headercell = row.CreateCell(j) as HSSFCell;
                        row.CreateCell(0).SetCellValue(HeaderDT.Rows[0][j].ToString());
                        sheet.AddMergedRegion(new CellRangeAddress(j, j, 0, dt.Columns.Count - 1));
                       
                        //row.Sheet.VerticallyCenter = true;
                        Headercell.CellStyle.Alignment = HorizontalAlignment.CENTER;
                        //row.Sheet.HorizontallyCenter = true;                        
                    }
                }
                
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
                HSSFRow firstRow = sheet.CreateRow(HeaderColumnsCount) as HSSFRow;
                for (int colIndex = 0; colIndex < dt.Columns.Count; colIndex++)
                {
                    string name = dt.Columns[colIndex].ColumnName;
                    HSSFCell cell = firstRow.CreateCell(colIndex) as HSSFCell;
                    cell.SetCellValue(name);
                    cell.CellStyle = spanStyle;
                    columns.Add(name);
                }

                string[] _columnsname = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J","K","L","M","N","O","P","Q","R","S","T", "U", "V", "W", "X", "Y","Z" };
                //建立資料列
                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    DataRow dr = dt.Rows[row];
                    HSSFRow newRow = sheet.CreateRow(row + 1 + HeaderColumnsCount) as HSSFRow;
                    for (int col = 0; col < columns.Count; col++)
                    {
                        string data = dr[columns[col]].ToString();
                        string data1 = dr[columns[col]].ToString();
                        HSSFCell cell = newRow.CreateCell(col) as HSSFCell;
                        cell.SetCellValue(data);

                        //寬度自動調整
                        newRow.Sheet.AutoSizeColumn(col);                        

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
                            if (PrintFooter && (row + 1) == dt.Rows.Count)
                            {
                                string columnsname = string.Empty;
                                if (col > 25)
                                {
                                    decimal _Remainder = col % 26;                                   
                                    decimal _Truncate = decimal.Floor(Convert.ToDecimal(col) / Convert.ToDecimal("26")) - 1;
                                    columnsname = _columnsname[Convert.ToInt32(_Truncate)].ToString() + _columnsname[Convert.ToInt32(_Remainder)].ToString();
                                }
                                else
                                {
                                    columnsname = _columnsname[col].ToString();
                                }
                                cell.CellFormula = "SUM(" + columnsname + (HeaderColumnsCount + 2) + ":" + columnsname + (HeaderColumnsCount + dt.Rows.Count) + ")";
                               
                            }
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

        public bool PrintGridLine
        {
            get;
            set;
        }

        public bool PrintFooter
        {
            get;
            set;
        }

        public bool PrintHeader
        {
            get;
            set;
        }

        #endregion

        #region IExcelWriter 成員

        public void Save(string FileName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
