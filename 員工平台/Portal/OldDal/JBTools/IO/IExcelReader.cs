using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBTools.IO
{
    public interface IExcelReader
    {
        bool IsOpened();
        int ColumnPosition { get; set; }
        LoadExcelColumnNameStyle ColumnNameStyle { get; set; }
        DataTable LoadExcelToDataTable(string SheetName);
        DataSet LoadExcelToDataSet();
        List<string> ColumnNameList { get; }
    }
    public enum LoadExcelColumnNameStyle
    {
        ExcelColumnName,
        DefinedColumn,
        Both
    }
}
