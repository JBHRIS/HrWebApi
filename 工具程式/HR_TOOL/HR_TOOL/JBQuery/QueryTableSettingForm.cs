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
    public partial class QueryTableSettingForm : Form
    {
        public QueryTableSettingForm()
        {
            InitializeComponent();
        }
        HrDBDataContext db = new HrDBDataContext();
        public int SettingID = 0;
        List<jqTable> jqTableList = new List<jqTable>();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        void GetTable()
        {
            //cbxTargetTable
            try
            {
                var dc = dataGridView1.Columns["tableNameDataGridViewTextBoxColumn"] as DataGridViewComboBoxColumn;

                var conn = new SqlConnection(db.Connection.ConnectionString);
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES  ORDER BY TABLE_NAME", conn);
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
        private void QueryTableSettingForm_Load(object sender, EventArgs e)
        {
            GetTable();
            GetData();
        }
        void GetData()
        {
            db = new HrDBDataContext();
            var sql = from a in db.jqTable where a.SettingID == SettingID select a;
            jqTableList = sql.ToList();
            //dataGridView1.DataSource = jqTableList;
            jqTableBindingSource.DataSource = jqTableList;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var jqSetting = (from a in db.jqSetting where a.ID == SettingID select a).FirstOrDefault();
            var jqColumnList = (from a in db.jqColumn where a.SettingID == SettingID select a).ToList();
            var lst = db.jqTable.GetNewBindingList();
            foreach (var it in jqTableList)
            {
                var OrignalState = db.jqTable.GetOriginalEntityState(it);
                if (OrignalState == null)//Add
                {
                    it.SettingID = SettingID;
                    it.CreateMan = Main.USER_NAME;
                    it.CreateDate = DateTime.Now;
                    if (it.Memo == null) it.Memo = string.Empty;//Default Value
                    db.jqTable.InsertOnSubmit(it);//Inser
                }
                var ModifyCotent = db.jqTable.GetModifiedMembers(it);
                if (ModifyCotent.Count() > 0)
                {
                    it.CreateMan = Main.USER_NAME;
                    it.CreateDate = DateTime.Now;
                }
                var dtColumns = GetColumns(it.TableName);
                int i = 0;
                foreach (DataRow r in dtColumns.Rows)
                {
                    i++;
                    jqColumn jqColumn = new jqColumn();

                    jqColumn.TableName = dtColumns.TableName;
                    jqColumn.ColumnName = r["COLUMN_NAME"].ToString();
                    if (!jqColumnList.Where(p => p.TableName == jqColumn.TableName && p.ColumnName == jqColumn.ColumnName).Any())
                    {
                        jqColumn.CreateDate = DateTime.Now;
                        jqColumn.CreateMan = Main.USER_NAME;
                        jqColumn.DataType = r["DATA_TYPE"].ToString();
                        jqColumn.Display = false;//後加的欄位預設不顯示
                        jqColumn.DisplayName = r["COLUMN_NAME"].ToString();
                        jqColumn.Format = "";
                        jqColumn.Memo = "";
                        jqColumn.PrimaryKey = false;
                        jqColumn.SettingID = jqSetting.ID;
                        jqColumn.Sort = 0;//後加的欄位預設不顯示
                        if (jqSetting.ConnectString != jqColumn.ColumnName)
                            jqColumn.Sort = 0;
                        db.jqColumn.InsertOnSubmit(jqColumn);
                    }
                }
            }
            db.SubmitChanges();
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
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


        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            var it = e.Row.DataBoundItem as jqTable;
            if (it != null)
            {
                db.jqTable.DeleteOnSubmit(it);
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            var it = e.Row.DataBoundItem as jqTable;
            if (it != null)
            {

            }

        }

        private void jqTableBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }



    }
}
