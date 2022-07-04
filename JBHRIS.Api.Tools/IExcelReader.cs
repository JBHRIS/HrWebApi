using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace JBHRIS.Api.Tools
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
