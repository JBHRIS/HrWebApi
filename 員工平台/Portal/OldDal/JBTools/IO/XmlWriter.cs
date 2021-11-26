using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
namespace JBTools.IO
{
    public class XmlWriter
    {
        string path = "";
        public XmlWriter(string FilePath)
        {
            path = FilePath;
        }
        public void SaveToXml(DataTable SourceTable)
        {
            var DS = new DataSet();
            FileInfo fi = new FileInfo(path);
            IO.FileSystem.CheckPath(fi.Directory.FullName);
            if (DS.Tables.Contains(SourceTable.TableName))
                DS.Tables.Remove(SourceTable.TableName);
            var dt1 = SourceTable;
            //dt1.Clear();
            //var row = dt1.NewRow();
            //for (int i = 0; i < dt1.Columns.Count; i++)
            //{
            //    row[i] = SourceTable.Rows[0][i];
            //    if (row[i] == DBNull.Value)
            //    {
            //        var fType = dt1.Columns[i].DataType;
            //        if (fType == typeof(Decimal))
            //        {
            //            row[i] = 0;
            //        }
            //        else if (fType == typeof(int))
            //        {
            //            row[i] = 0;
            //        }
            //        else if (fType == typeof(DateTime))
            //        {
            //            row[i] = new DateTime(1900, 1, 1);
            //        }
            //        else if (fType == typeof(bool))
            //        {
            //            row[i] = true;
            //        }
            //        else row[i] = "";
            //    }

            //}
            //dt1.Rows.Add(row);
            DS.Tables.Add(dt1);
            DS.WriteXml(path);
        }
    }
}
