using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

    public static class extDataRow
    {
        public static void SetRowDefaultValue(this DataRow row)
        {
            Type t;
            foreach (DataColumn dc in row.Table.Columns)
            {
                t = dc.DataType;
                if (t == typeof(string)) row[dc] = "";
                if (t == typeof(bool)) row[dc] = false;
                if (t == typeof(int)) row[dc] = 0;
                if (t == typeof(decimal)) row[dc] = 0.00;
                if (t == typeof(DateTime)) row[dc] = DateTime.Now;
            }
        }
        public static void SetRowDefaultValue(this DataRow row,List<string> SkipColumnName)
        {
            Type t;
            foreach (DataColumn dc in row.Table.Columns)
            {
                if (SkipColumnName.Contains(dc.ColumnName)) continue;
                t = dc.DataType;
                if (t == typeof(string)) row[dc] = "";
                if (t == typeof(bool)) row[dc] = false;
                if (t == typeof(int)) row[dc] = 0;
                if (t == typeof(decimal)) row[dc] = 0.00;
                if (t == typeof(DateTime)) row[dc] = DateTime.Now;
            }
        }
    }
