using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

public static class ExtendDataGridView
{
    public static DataTable ExportGridToDataTable(this System.Windows.Forms.DataGridView dgv)
    {
        if (dgv != null)
        {
            DataTable tbl = new DataTable();
            List<string> comboboxList = new List<string>();
            foreach (DataGridViewColumn dc in dgv.Columns)
            {
                if (dc.Visible)
                {
                    int count = 0;
                    string col_name = dc.HeaderText;
                    while (tbl.Columns.Contains(col_name))
                    {
                        count++;
                        col_name = dc.HeaderText + "(" + count.ToString() + ")";
                    }
                    if (dc.ValueType != null)
                        if (dc.ValueType.Name.Contains("Nullable"))
                            tbl.Columns.Add(new DataColumn(col_name, typeof(string)));
                        else
                            tbl.Columns.Add(new DataColumn(col_name, dc.ValueType));
                }
            }
            DateTime t1, t2;
            t1 = DateTime.Now;
            foreach (DataGridViewRow dr in dgv.Rows)
            {

                DataRow row = tbl.NewRow();
                foreach (DataGridViewCell dcc in dr.Cells)
                {
                    string column_name = dgv.Columns[dcc.ColumnIndex].HeaderText;
                    if (!tbl.Columns.Contains(column_name)) continue;
                    DataGridViewComboBoxCell combobox = dcc as DataGridViewComboBoxCell;
                    if (combobox != null)
                    {
                        var data = combobox.DataSource as BindingSource;
                        var table = (data.DataSource as DataSet).Tables[data.DataMember] as DataTable;
                        if (table != null)
                        {
                            var rows = table.Select(combobox.ValueMember + "='" + dcc.Value + "'");
                            if (rows.Any())
                                row[column_name] = rows[0][combobox.DisplayMember];
                        }
                    }
                    else
                    {
                        string string_value = dcc.FormattedValue.ToString();
                        if (dcc.ValueType == typeof(decimal))
                        {
                            decimal value = 0;
                            if (!decimal.TryParse(string_value, out value))
                                row[column_name] = DBNull.Value;
                            else row[column_name] = value;
                        }
                        else if (dcc.ValueType == typeof(DateTime))
                        {
                            DateTime value = new DateTime();
                            if (!DateTime.TryParse(string_value, out value))
                            {
                                dcc.ValueType = typeof(string);
                                row[column_name] = string_value;
                            }
                            else row[column_name] = value;

                        }
                        else if (dcc.ValueType == typeof(int))
                        {
                            int value = 0;
                            if (!int.TryParse(string_value, out value))
                                row[column_name] = DBNull.Value;
                            else row[column_name] = value;
                        }
                        else if (dcc.ValueType == typeof(bool))
                        {
                            bool value = true;
                            if (!bool.TryParse(string_value, out value))
                                row[column_name] = DBNull.Value;
                            else row[column_name] = value;
                        }
                        else//其餘都當作是字串處理
                        {
                            row[column_name] = string_value;
                        }
                    }
                }
                tbl.Rows.Add(row);
            }
            t2 = DateTime.Now;
            var ts = t2 - t1;
            return tbl;
        }

        return null;
    }
    public static DataTable GetDataTableFromDGV(this DataGridView dgv)
    {
        var dt = ((DataTable)dgv.DataSource).Copy();
        foreach (DataGridViewColumn column in dgv.Columns)
        {
            if (!column.Visible)
            {
                dt.Columns.Remove(column.Name);
            }
            dt.Columns[column.Name].ColumnName = column.HeaderText;
        }
        return dt;
    }
    public static DataTable DataGridView2DataTable(this DataGridView dgv, String tblName, int minRow = 0)
    {

        DataTable dt = new DataTable(tblName);

        // Header columns
        foreach (DataGridViewColumn column in dgv.Columns)
        {
            DataColumn dc = new DataColumn(column.Name.ToString());
            dt.Columns.Add(dc);
        }

        // Data cells
        for (int i = 0; i < dgv.Rows.Count; i++)
        {
            DataGridViewRow row = dgv.Rows[i];
            DataRow dr = dt.NewRow();
            for (int j = 0; j < dgv.Columns.Count; j++)
            {
                dr[j] = (row.Cells[j].Value == null) ? "" : row.Cells[j].Value.ToString();
            }
            dt.Rows.Add(dr);
        }

        // Related to the bug arround min size when using ExcelLibrary for export
        for (int i = dgv.Rows.Count; i < minRow; i++)
        {
            DataRow dr = dt.NewRow();
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                dr[j] = "  ";
            }
            dt.Rows.Add(dr);
        }

        foreach (DataGridViewColumn column in dgv.Columns)
        {
            dt.Columns[column.Name].ColumnName = column.HeaderText;
        }
        return dt;
    }
}

