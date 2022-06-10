using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace HR_TOOL.DataUpdate
{
    public partial class DataUpdateForm : Telerik.WinControls.UI.RadForm
    {
        public DataUpdateForm()
        {
            InitializeComponent();
        }
        DataSet ds;
        HrDBDataContext db = new HrDBDataContext();

        private void DataUpdateForm_Load(object sender, EventArgs e)
        {
            SetState();
            GetTable();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                radTextBox1.Text = ofd.FileName;
                ds = JBModule.Data.CNPOI.ReadExcelToDataSet(ofd.FileName);
                SetState();
            }
        }
        void SetState()
        {
            cbxSheet.Enabled = ds != null;
            cbxSheet.Items.Clear();
            if (ds != null)
            {
                foreach (DataTable it in ds.Tables)
                {
                    cbxSheet.Items.Add(it.TableName);
                }
            }
        }
        void SetColumn()
        {
            ExcelColumns.Clear();
            var table = ds.Tables[cbxSheet.Text];
            foreach (DataColumn col in table.Columns)
            {
                ExcelColumns.Add(col.ColumnName);
            }
        }
        List<string> ExcelColumns = new List<string>();
        void GetTable()
        {
            //cbxTargetTable
            try
            {
                var conn = new SqlConnection(db.Connection.ConnectionString);
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME", conn);
                    if (conn.State != ConnectionState.Open) conn.Open();
                    var dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    foreach (DataRow r in dt.Rows)
                    {
                        cbxTargetTable.Items.Add(r["Table_Name"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        DataTable TargetTableProperties = new DataTable();
        void GetColumns()
        {
            TargetTableProperties = new DataTable();
            try
            {
                var conn = new SqlConnection(db.Connection.ConnectionString);
                using (conn)
                {
                    DataTable dtExcelColumn = new DataTable();
                    dtExcelColumn.Columns.Add("Value");
                    foreach (var it in ExcelColumns)
                    {
                        var r = dtExcelColumn.NewRow();
                        r[0] = it;
                        dtExcelColumn.Rows.Add(r);
                    }

                    SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM INFORMATION_SCHEMA.columns WHERE TABLE_NAME = '{0}' ", cbxTargetTable.Text), conn);
                    if (conn.State != ConnectionState.Open) conn.Open();
                    var dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    TargetTableProperties.Load(dr);
                    gvWhereColumn.Rows.Clear();
                    gvWhereColumn.Columns.Clear();
                    gvWhereColumn.MasterTemplate.AutoGenerateColumns = false;
                    Telerik.WinControls.UI.GridViewTextBoxColumn col1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
                    col1.HeaderText = "目的";
                    col1.FieldName = "Target";
                    col1.Width = 120;
                    gvWhereColumn.Columns.Add(col1);

                    Telerik.WinControls.UI.GridViewComboBoxColumn col2 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
                    col2.HeaderText = "來源";
                    col2.FieldName = "Source";
                    col2.Width = 120;
                    col2.DataSource = dtExcelColumn;
                    col2.DisplayMember = "Value";
                    col2.ValueMember = "Value";
                    gvWhereColumn.Columns.Add(col2);

                    gvSetColumn.MasterTemplate.AutoGenerateColumns = false;
                    gvSetColumn.Rows.Clear();
                    gvSetColumn.Columns.Clear();
                    Telerik.WinControls.UI.GridViewTextBoxColumn col3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
                    col3.HeaderText = "目的";
                    col3.FieldName = "Target";
                    col3.Width = 120;
                    gvSetColumn.Columns.Add(col3);

                    Telerik.WinControls.UI.GridViewComboBoxColumn col4 = new Telerik.WinControls.UI.GridViewComboBoxColumn();
                    col4.HeaderText = "來源";
                    col4.FieldName = "Source";
                    col4.Width = 120;
                    col4.DataSource = dtExcelColumn;
                    col4.DisplayMember = "Value";
                    col4.ValueMember = "Value";
                    gvSetColumn.Columns.Add(col4);

                    foreach (DataRow r in TargetTableProperties.Rows)
                    {
                        var row2 = gvWhereColumn.Rows.AddNew();
                        row2.Cells["Target"].Value = r["COLUMN_NAME"].ToString();

                        var row3 = gvSetColumn.Rows.AddNew();
                        row3.Cells["Target"].Value = r["COLUMN_NAME"].ToString();
                    }
                    gvWhereColumn.Rows[0].IsSelected = true;
                    gvSetColumn.Rows[0].IsSelected = true;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void cbxSheet_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            radGridView1.DataSource = ds.Tables[cbxSheet.Text];
            SetColumn();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            var dt = ds.Tables[cbxSheet.Text];
            int success = 0;

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    var conn = new SqlConnection(db.Connection.ConnectionString);
                    using (conn)
                    {
                        string cmd = "UPDATE ";
                        cmd += cbxTargetTable.Text;
                        cmd += " SET ";
                        int sc = 0;
                        List<SqlParameter> parameterList = new List<SqlParameter>();
                        foreach (var it in gvSetColumn.Rows)
                        {
                            if (it.Cells["Source"].Value == null) continue;
                            string TargetColumnName = it.Cells["Target"].Value.ToString();

                            SqlParameter parm = new SqlParameter();
                            parm.ParameterName = "Set_" + TargetColumnName;
                            parm.Value = row[it.Cells["Source"].Value.ToString()];
                            var rows = TargetTableProperties.Select(string.Format("COLUMN_NAME='{0}'", TargetColumnName));
                            if (rows.Rank > 0)
                            {
                                var rr = rows[0];
                                string ColumnType = rr["DATA_TYPE"].ToString();
                                switch (ColumnType)
                                {
                                    case "datetime":
                                        parm.SqlDbType = SqlDbType.DateTime;
                                        parm.DbType = DbType.DateTime;
                                        //parm.TypeName = typeof(DateTime).ToString();
                                        parm.Value = Convert.ToDateTime(row[it.Cells["Source"].Value.ToString()]);
                                        break;
                                    case "nvarchar":
                                        parm.SqlDbType = SqlDbType.NVarChar;
                                        parm.DbType = DbType.String;
                                        //parm.TypeName =  typeof(string).ToString();
                                        parm.Value = row[it.Cells["Source"].Value.ToString()].ToString();
                                        break;
                                    case "decimal":
                                        parm.SqlDbType = SqlDbType.Decimal;
                                        parm.DbType = DbType.Decimal;
                                        //parm.TypeName = typeof(decimal).ToString();
                                        parm.Value = Convert.ToDecimal(row[it.Cells["Source"].Value.ToString()]);
                                        break;
                                }
                            }

                            if (sc > 0) cmd += ",";
                            cmd += TargetColumnName + "=@" + parm.ParameterName;
                            parameterList.Add(parm);
                            sc++;
                        }
                        cmd += " WHERE ";
                        int wc = 0;
                        foreach (var it in gvWhereColumn.Rows)
                        {
                            if (it.Cells["Source"].Value == null) continue;
                            string WhereColumnName = it.Cells["Target"].Value.ToString();
                            SqlParameter parm = new SqlParameter();
                            parm.ParameterName = "Where_" + WhereColumnName;
                            parm.Value = row[it.Cells["Source"].Value.ToString()];
                            if (wc > 0) cmd += " AND ";
                            cmd += WhereColumnName + "=@" + parm.ParameterName;
                            parameterList.Add(parm);
                            wc++;
                        }
                        if (txtWhereCommand.Text.Trim().Length > 0)
                        {
                            if (cmd.ToUpper().IndexOf("WHERE") != -1)
                                cmd += " AND " + txtWhereCommand.Text;
                            else cmd += " WHERE " + txtWhereCommand.Text;
                        }

                        SqlCommand sqlcmd = new SqlCommand(string.Format(cmd, cbxTargetTable.Text), conn);
                        sqlcmd.Parameters.AddRange(parameterList.ToArray());
                        if (conn.State != ConnectionState.Open) conn.Open();
                        var result = sqlcmd.ExecuteNonQuery();
                        if (result > 0) success++;
                    }
                }
                catch(Exception ex)
                {
                    
                }

            }
            MessageBox.Show("完成，共處理" + success.ToString() + "筆資料");
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            GetColumns();
        }
    }
}
