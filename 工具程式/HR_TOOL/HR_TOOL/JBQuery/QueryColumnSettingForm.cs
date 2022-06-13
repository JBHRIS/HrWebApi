using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HR_TOOL.JBQuery
{
    public partial class QueryColumnSettingForm : Form
    {
        public QueryColumnSettingForm()
        {
            InitializeComponent();
        }
        HrDBDataContext db = new HrDBDataContext();
        public int SettingID = 0;
        List<jqColumn> jqColumnList = new List<jqColumn>();
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            foreach (var it in jqColumnList)
            {
                it.CreateMan = Main.USER_NAME;
                it.CreateDate = DateTime.Now;
            }
            db.SubmitChanges();
            this.Close();
        }

        private void QueryColumnSettingForm_Load(object sender, EventArgs e)
        {
            GetData();
        }
        void GetData()
        {
            db = new HrDBDataContext();
            var sql = from a in db.jqColumn where a.SettingID == SettingID && a.Sort > 0 orderby a.Sort select a;
            jqColumnList = sql.ToList();
            dataGridView1.DataSource = jqColumnList;
        }
        private void buttonAddField_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                HrDBDataContext db1 = new HrDBDataContext();
                var row = dataGridView1.SelectedRows[0];
                var it = row.DataBoundItem as jqColumn;
                if (it != null)
                {
                    jqSqlQueryField field = new jqSqlQueryField();
                    field.TableName = it.TableName;
                    field.ColumnName = it.ColumnName;
                    field.CreateDate = DateTime.Now;
                    field.CreateMan = Main.USER_NAME;
                    field.CustomQuery = "";
                    field.Display = true;
                    field.DisplayName = it.DisplayName;
                    field.Memo = "";
                    field.QueryType = "";
                    field.SettingID = SettingID;
                    field.Sort = 1;
                    db1.jqSqlQueryField.InsertOnSubmit(field);
                    db1.SubmitChanges();
                    MessageBox.Show("欄位已加入");
                }
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            QueryColumnOrderByForm frm = new QueryColumnOrderByForm();
            frm.SettingID = this.SettingID;
            frm.ShowDialog();
            GetData();
        }
    }
}
