using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using JBControls;

namespace HR_TOOL.JBQuery
{
    public partial class QuerySettingForm : Form
    {
        public string USER_NAME = "";
        public QuerySettingForm()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dtColumns = new DataTable();
        HrDBDataContext db = new HrDBDataContext();
        List<string> ExcelColumns = new List<string>();
        public int SettingID = -1;
        public jqSetting Setting = null;
        void GetTable()
        {
            //cbxTargetTable
            try
            {
                var conn = new SqlConnection(db.Connection.ConnectionString);
                using (conn)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES ORDER BY TABLE_NAME", conn);
                    if (conn.State != ConnectionState.Open) conn.Open();
                    var dr = cmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(dr);
                    foreach (DataRow r in dt.Rows)
                    {
                        comboBoxSourceTable.Items.Add(r["Table_Name"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void QuerySettingForm_Load(object sender, EventArgs e)
        {
            GetTable();
            Init();
        }
        void Init()
        {
            var sql = from a in db.jqSetting where a.ID == SettingID select a;
            if (sql.Any())
            {
                Setting = sql.First();
                textBoxSetting.Text = Setting.QuerySetting;
                textBoxSettingName.Text = Setting.QueryName;
                comboBoxSourceTable.Text = Setting.ConnectString;
                textBoxMemo.Text = Setting.Memo;
                textBoxCustomWhere.Text = Setting.CustomerWhere;
            }
        }
        void GetColumns()
        {
            ds = new DataSet();
            //foreach (var item in listBoxTables.Items)
            //{
            string item = comboBoxSourceTable.Text;
            dtColumns = new DataTable();
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
            //}
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            GetColumns();
            if (SettingID == -1)
                Setting = new jqSetting();
            else
            {
                var sql = from a in db.jqSetting where a.ID == SettingID select a;
                if (sql.Any())
                    Setting = sql.First();
            }
            Setting.Memo = textBoxMemo.Text;
            Setting.QueryName = textBoxSettingName.Text;
            Setting.QuerySetting = textBoxSetting.Text;
            Setting.SourceType = "SQL";
            Setting.ConnectString = comboBoxSourceTable.Text;
            Setting.CreateDate = DateTime.Now;
            Setting.CreateMan = USER_NAME;
            Setting.Sort = 1;
            Setting.PageSize = 1000;
            Setting.CustomerWhere = textBoxCustomWhere.Text;
            if (SettingID == -1)
                db.jqSetting.InsertOnSubmit(Setting);
            db.SubmitChanges();
                foreach (DataTable dtColumns in ds.Tables)
                {
                    if (SettingID == -1)
                    {
                        jqTable jqTable = new jqTable();
                        jqTable.CreateDate = DateTime.Now;
                        jqTable.CreateMan = USER_NAME;
                        jqTable.DisplayName = dtColumns.TableName;
                        jqTable.Memo = "";
                        jqTable.SettingID = Setting.ID;
                        jqTable.TableName = dtColumns.TableName;
                        db.jqTable.InsertOnSubmit(jqTable);
                    }
                    var ColumnCheckList = db.jqColumn.Where(p => p.SettingID == SettingID && p.TableName == dtColumns.TableName).ToList();
                    int i = 0;
                    foreach (DataRow r in dtColumns.Rows)
                    {
                        i++;
                       
                        jqColumn jqColumn = new jqColumn();
                        jqColumn.TableName = dtColumns.TableName;
                        jqColumn.ColumnName = r["COLUMN_NAME"].ToString();
                        if (ColumnCheckList.Where(p => p.ColumnName == jqColumn.ColumnName).Any()) continue;
                        jqColumn.CreateDate = DateTime.Now;
                        jqColumn.CreateMan = USER_NAME;
                        jqColumn.DataType = r["DATA_TYPE"].ToString();
                        jqColumn.Display = Setting.ConnectString == jqColumn.TableName;
                        jqColumn.DisplayName = r["COLUMN_NAME"].ToString();
                        jqColumn.Format = "";
                        jqColumn.Memo = "";
                        jqColumn.PrimaryKey = false;
                        jqColumn.SettingID = Setting.ID;
                        jqColumn.Sort = i;
                        if (Setting.ConnectString != jqColumn.TableName)
                            jqColumn.Sort = 0;
                        db.jqColumn.InsertOnSubmit(jqColumn);
                    }
                }
            db.SubmitChanges();
            this.Close();
        }

    }
}
