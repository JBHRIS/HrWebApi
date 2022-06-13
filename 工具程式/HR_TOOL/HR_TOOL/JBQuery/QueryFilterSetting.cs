using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using JBTools.Extend;
namespace HR_TOOL.JBQuery
{
    public partial class QueryFilterSetting : Form
    {
        public QueryFilterSetting()
        {
            InitializeComponent();
        }
        HrDBDataContext db = new HrDBDataContext();
        public int SettingID = 0;
        List<jqPreCondition> jqPreConditionList = new List<jqPreCondition>();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        #region Event
        private void QueryFilterSetting_Load(object sender, EventArgs e)
        {
            GetTable();
            GetData();
            //var conds = JBControls.U_QUERY_JQ.Conditions.ToDictionary(p => p, p => p);
            var dc = dataGridView1.Columns["Comparison"] as DataGridViewComboBoxColumn;
            if (dc != null)
            {
                foreach (var it in JBControls.U_QUERY_JQ.Conditions)
                    dc.Items.Add(it);
            }
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                var it = r.DataBoundItem as jqPreCondition;
                if (it != null)
                {
                    var dcc = r.Cells["columnNameDataGridViewTextBoxColumn"] as DataGridViewComboBoxCell;
                    dcc.DisplayMember = "column_name";
                    dcc.ValueMember = "column_name";
                    dcc.DataSource = GetColumns(it.TableName);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            var jqSetting = (from a in db.jqSetting where a.ID == SettingID select a).FirstOrDefault();
            var jqColumnList = (from a in db.jqColumn where a.SettingID == SettingID select a).ToList();
            var lst = db.jqTable.GetNewBindingList();
            foreach (var it in jqPreConditionList)
            {
                var OrignalState = db.jqPreCondition.GetOriginalEntityState(it);
                if (OrignalState == null)//Add
                {
                    it.SettingID = SettingID;
                    it.CreateMan = Main.USER_NAME;
                    it.CreateDate = DateTime.Now;
                    it.QueryType = "";
                    it.CustomQuery = ""; 
                    it.Sort = 1;
                    if (it.Memo == null) it.Memo = string.Empty;//Default Value
                    db.jqPreCondition.InsertOnSubmit(it);//Inser
                }
                var ModifyCotent = db.jqPreCondition.GetModifiedMembers(it);
                if (ModifyCotent.Count() > 0)
                {
                    it.CreateMan = Main.USER_NAME;
                    it.CreateDate = DateTime.Now;
                }
              
            }
            db.SubmitChanges();
            this.Close();
        }
        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn dc = dataGridView1.Columns["tableNameDataGridViewTextBoxColumn"];
            DataGridViewColumn dcDisp = dataGridView1.Columns["displayNameDataGridViewTextBoxColumn"];
            if (dc != null)
            {
                if (e.ColumnIndex == dc.Index)
                {
                    int idx = dc.Index;
                    if (dcDisp != null)
                    {
                        int idxDisp = dcDisp.Index;
                        var valueSource = dataGridView1.Rows[e.RowIndex].Cells[idx].Value;
                        if (dataGridView1.Rows[e.RowIndex].Cells[idxDisp].Value == null || dataGridView1.Rows[e.RowIndex].Cells[idxDisp].Value.ToString().Trim().Length == 0)
                            dataGridView1.Rows[e.RowIndex].Cells[idxDisp].Value = valueSource;
                    }
                }
            }
        }
        #endregion
        #region Method
        void GetTable()
        {
            //cbxTargetTable
            try
            {
                var dc = dataGridView1.Columns["tableNameDataGridViewTextBoxColumn"] as DataGridViewComboBoxColumn;

                var conn = new SqlConnection(db.Connection.ConnectionString);
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME", conn);
                    if (conn.State != ConnectionState.Open) conn.Open();
                    var dr = cmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(dr);
                    Dictionary<string, string> dicSource = new Dictionary<string, string>();
                    foreach (DataRow r in dt.Rows)
                    {
                        dicSource.Add(r["Table_Name"].ToString().Trim(), r["Table_Name"].ToString().Trim());
                        //comboBox1.Items.Add(r["Table_Name"].ToString().Trim());
                    }

                    dc.DisplayMember = "value";
                    dc.ValueMember = "key";
                    dc.DataSource = dicSource.CopyToDataTable();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        void GetData()
        {
            db = new HrDBDataContext();
            var sql = from a in db.jqPreCondition where a.SettingID == SettingID select a;
            jqPreConditionList = sql.ToList();
            //dataGridView1.DataSource = jqTableList;
            jqPreConditionBindingSource.DataSource = jqPreConditionList;
        }
        DataTable GetColumns(string TableName)
        {
            string item = TableName;
            DataTable dtColumns = new DataTable();
            try
            {
                var conn = new SqlConnection(db.Connection.ConnectionString);
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM INFORMATION_SCHEMA.columns WHERE TABLE_NAME = '{0}' ", item.ToString()), conn);
                    if (conn.State != ConnectionState.Open) conn.Open();
                    var dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    dtColumns.Load(dr);
                    dtColumns.TableName = item.ToString();
                    ds.Tables.Add(dtColumns);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return dtColumns;
        }

        #endregion

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var dc = dataGridView1.Columns["tableNameDataGridViewTextBoxColumn"] as DataGridViewComboBoxColumn;
            if (dc != null && dataGridView1.Columns[e.ColumnIndex].Index == dc.Index)
            {
                string value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null ? dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() : dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                GetColumns(value);
                var dcc = dataGridView1.Rows[e.RowIndex].Cells["columnNameDataGridViewTextBoxColumn"] as DataGridViewComboBoxCell;
                if (dcc != null)
                {
                    dcc.DisplayMember = "column_name";
                    dcc.ValueMember = "column_name";
                    dcc.DataSource = GetColumns(value);
                }
            }

        }

        private void jqPreConditionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //var dv = jqPreConditionBindingSource.Current as jqPreCondition;
            //foreach (DataGridViewRow r in dataGridView1.Rows)
            //{
            //    if (r.DataBoundItem as jqPreCondition == dv)
            //    {
            //        var dc = r.Cells["columnNameDataGridViewTextBoxColumn"] as DataGridViewComboBoxCell;
            //        if (dc != null)
            //        {
            //            dc.DisplayMember = "column_name";
            //            dc.ValueMember = "column_name";
            //            dc.DataSource = GetColumns(dv.TableName);
            //        }
            //        return;
            //    }
            //}
        }

        private void jqPreConditionBindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {

        }
    }
}
