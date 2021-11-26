using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using System.Data;

namespace JBTools.IO
{
    public class NpoiExcelReader : IExcelReader
    {
        string _fileName;
        public NpoiExcelReader(string FileName)
        {
            ColumnNameStyle = LoadExcelColumnNameStyle.Both;
            ColumnPosition = 0;
            _fileName = FileName;
            if (!IsOpened())
            {
                InitializeWorkbook(_fileName);
            }
        }

        #region IExcelReader 成員

        public bool IsOpened()
        {
            return JBTools.IO.FileSystem.IsOpenedFile(_fileName);
        }

        public int ColumnPosition
        {
            get;
            set;
        }

        public LoadExcelColumnNameStyle ColumnNameStyle
        {
            get;
            set;
        }
        List<string> _columnNameList;
        public List<string> ColumnNameList
        {
            get
            {
                if (_columnNameList == null)
                {
                    _columnNameList = new List<string>();
                    var sheets = Workbook.GetEnumerator();
                    while (sheets.MoveNext())
                    {
                        var sheet = sheets.Current as ISheet;
                        _columnNameList.Add(sheet.SheetName);
                    }

                }
                return _columnNameList;
            }
        }
        public static DataTable ConvertSheetToDataTable(ISheet sheet, string SheetName = "ExcelExport")
        {
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            //Settings
            int ColumnPosition = 0;
            LoadExcelColumnNameStyle ColumnNameStyle = LoadExcelColumnNameStyle.Both;

            DataTable dt = new DataTable();
            dt.TableName = SheetName;
            bool isInit = true; ;
            int RowIndex = 0;
            while (rows.MoveNext())
            {
                if (RowIndex < ColumnPosition)
                {
                    RowIndex++;
                    continue;//起始位置
                }
                IRow row = (IRow)rows.Current;
                if (isInit)
                {
                    for (int j = 0; j < row.LastCellNum; j++)
                    {
                        if (ColumnNameStyle == LoadExcelColumnNameStyle.ExcelColumnName)
                            dt.Columns.Add(j / 26 >= 1 ? Convert.ToChar(((int)'A') + (j / 26) - 1).ToString() + Convert.ToChar(((int)'A') + j % 26).ToString() : Convert.ToChar(((int)'A') + j).ToString());
                        else if (ColumnNameStyle == LoadExcelColumnNameStyle.DefinedColumn)
                        {
                            //if (j >= dt.Columns.Count) continue;
                            ICell cell = row.GetCell(j);
                            if (cell == null || cell.ToString().Trim().Length == 0)
                            {
                                dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                            }
                            else
                            {
                                if (!dt.Columns.Contains(cell.ToString()))
                                    dt.Columns.Add(cell.ToString());
                                else
                                {
                                    int i=1;
                                    while(dt.Columns.Contains(cell.ToString()+i.ToString()))
                                    {
                                        i++;
                                    }
                                    dt.Columns.Add(cell.ToString() + i.ToString());
                                }
                            }
                        }
                        else if (ColumnNameStyle == LoadExcelColumnNameStyle.Both)
                        {
                            //if (j >= dt.Columns.Count) continue;
                            ICell cell = row.GetCell(j);
                            if (cell == null || cell.ToString().Trim().Length == 0)
                            {
                                dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                            }
                            else
                            {
                                dt.Columns.Add((j / 26 >= 1 ? Convert.ToChar(((int)'A') + (j / 26) - 1).ToString() + Convert.ToChar(((int)'A') + j % 26).ToString() : Convert.ToChar(((int)'A') + j).ToString()) + "-" + cell.ToString());
                            }
                        }
                    }
                    isInit = false;
                    if (ColumnNameStyle != LoadExcelColumnNameStyle.ExcelColumnName) continue;//第一行已經被拿來使用當欄位了                   
                }

                DataRow dr = dt.NewRow();
                bool isRowAvailable = false;
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    if (i >= dt.Columns.Count) continue;
                    ICell cell = row.GetCell(i);


                    if (cell == null || cell.ToString().Trim().Length == 0)
                    {
                        dr[i] = null;
                        if (cell != null && cell.ToString().Trim().Length == 0)
                            dr[i] = cell.ToString();
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                        if (cell.CellType == CellType.NUMERIC)
                        {
                            decimal value = 0;
                            if (!decimal.TryParse(cell.ToString(), out value))
                                if (cell.DateCellValue > cell.DateCellValue.Date)//含時間
                                    dr[i] = cell.DateCellValue.ToString();
                                else dr[i] = cell.DateCellValue.ToString("yyyy/MM/dd");
                        }
                        else if (cell.CellType == CellType.FORMULA)
                        {
                            if (cell.CachedFormulaResultType == CellType.NUMERIC)//因為無法辨識數值及時間，所以暫時公式數值都當數值(日期較少拿來作公式)
                            {
                                //decimal value = 0;
                                //if (!decimal.TryParse(cell.ToString(), out value))
                                //    if (cell.DateCellValue > cell.DateCellValue.Date)//含時間
                                //        dr[i] = cell.DateCellValue.ToString();
                                //    else dr[i] = cell.DateCellValue.ToString("yyyy/MM/dd");
                                //else 
                                dr[i] = cell.NumericCellValue.ToString();
                            }
                        }
                        isRowAvailable = true;
                    }
                }
                if (isRowAvailable)
                    dt.Rows.Add(dr);
                RowIndex++;
            }
            dt.TableName = SheetName;
            return dt;
        }
        public System.Data.DataTable LoadExcelToDataTable(string SheetName)
        {
            ISheet sheet = Workbook.GetSheet(SheetName);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            DataTable dt = new DataTable();
            dt.TableName = SheetName;
            bool isInit = true; ;
            int RowIndex = 0;
            while (rows.MoveNext())
            {
                if (RowIndex < ColumnPosition)
                {
                    RowIndex++;
                    continue;//起始位置
                }
                IRow row = (IRow)rows.Current;
                if (isInit)
                {
                    for (int j = 0; j < row.LastCellNum; j++)
                    {
                        if (ColumnNameStyle == LoadExcelColumnNameStyle.ExcelColumnName)
                            dt.Columns.Add(j / 26 >= 1 ? Convert.ToChar(((int)'A') + (j / 26) - 1).ToString() + Convert.ToChar(((int)'A') + j % 26).ToString() : Convert.ToChar(((int)'A') + j).ToString());
                        else if (ColumnNameStyle == LoadExcelColumnNameStyle.DefinedColumn)
                        {
                            //if (j >= dt.Columns.Count) continue;
                            ICell cell = row.GetCell(j);
                            if (cell == null || cell.ToString().Trim().Length == 0)
                            {
                                dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                            }
                            else
                            {
                                if (!dt.Columns.Contains(cell.ToString()))
                                    dt.Columns.Add(cell.ToString());
                                else
                                {
                                    int i = 1;
                                    while (dt.Columns.Contains(cell.ToString() + i.ToString()))
                                    {
                                        i++;
                                    }
                                    dt.Columns.Add(cell.ToString() + i.ToString());
                                }
                            }
                        }
                        else if (ColumnNameStyle == LoadExcelColumnNameStyle.Both)
                        {
                            //if (j >= dt.Columns.Count) continue;
                            ICell cell = row.GetCell(j);
                            if (cell == null || cell.ToString().Trim().Length == 0)
                            {
                                dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                            }
                            else
                            {
                                dt.Columns.Add((j / 26 >= 1 ? Convert.ToChar(((int)'A') + (j / 26) - 1).ToString() + Convert.ToChar(((int)'A') + j % 26).ToString() : Convert.ToChar(((int)'A') + j).ToString()) + "-" + cell.ToString());
                            }
                        }
                    }
                    isInit = false;
                    if (ColumnNameStyle != LoadExcelColumnNameStyle.ExcelColumnName) continue;//第一行已經被拿來使用當欄位了                   
                }

                DataRow dr = dt.NewRow();
                bool isRowAvailable = false;
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    if (i >= dt.Columns.Count) continue;
                    ICell cell = row.GetCell(i);


                    if (cell == null || cell.ToString().Trim().Length == 0)
                    {
                        dr[i] = null;
                        if (cell != null && cell.ToString().Trim().Length == 0)
                            dr[i] = cell.ToString();
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                        if (cell.CellType == CellType.NUMERIC)
                        {
                            decimal value = 0;
                            if (!decimal.TryParse(cell.ToString(), out value))
                            {
                                try
                                {
                                    if (cell.DateCellValue > cell.DateCellValue.Date)//含時間
                                        dr[i] = cell.DateCellValue.ToString();
                                    else dr[i] = cell.DateCellValue.ToString("yyyy/MM/dd");
                                }
                                catch
                                {
                                    dr[i] = cell.NumericCellValue;
                                }
                            }
                        }
                        else if (cell.CellType == CellType.FORMULA)
                        {
                            if (cell.CachedFormulaResultType == CellType.NUMERIC)//因為無法辨識數值及時間，所以暫時公式數值都當數值(日期較少拿來作公式)
                            {
                                //decimal value = 0;
                                //if (!decimal.TryParse(cell.ToString(), out value))
                                //    if (cell.DateCellValue > cell.DateCellValue.Date)//含時間
                                //        dr[i] = cell.DateCellValue.ToString();
                                //    else dr[i] = cell.DateCellValue.ToString("yyyy/MM/dd");
                                //else 
                                dr[i] = cell.NumericCellValue.ToString();
                            }
                        }
                        isRowAvailable = true;
                    }
                }
                if (isRowAvailable)
                    dt.Rows.Add(dr);
                RowIndex++;
            }
            dt.TableName = SheetName;
            return dt;
        }

        public System.Data.DataSet LoadExcelToDataSet()
        {
            var ds = new DataSet();
            var sheets = Workbook.GetEnumerator();
            while (sheets.MoveNext())
            {
                ISheet sheet = sheets.Current as ISheet;
                var dt = LoadExcelToDataTable(sheet.SheetName);
                ds.Tables.Add(dt);
            }
            return ds;
        }

        #endregion

        public IWorkbook Workbook;
        //NPOI.XSSF.UserModel.XSSFWorkbook 
        DataSet ds;
        void InitializeWorkbook(string path)
        {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //book1.xls is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                string ExtensionName = Path.GetExtension(path);
                if (ExtensionName.Trim().ToUpper() == ".XLS")
                    Workbook = new HSSFWorkbook(file);
                else if (ExtensionName.Trim().ToUpper() == ".XLSX")
                    Workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(file);
                else throw new Exception("不支援的檔案格式" + ExtensionName);
            }
        }

        void ConvertToDataTable()
        {
            ds = new DataSet();
            ISheet sheet = Workbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            DataTable dt = new DataTable();
            for (int j = 0; j < 5; j++)
            {
                dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
            }

            while (rows.MoveNext())
            {
                IRow row = (IRow)rows.Current;
                DataRow dr = dt.NewRow();

                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);


                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
        }
    }
}
