using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;
using JBTools.Extend;
namespace HR_TOOL.JBQuery
{
    public partial class QueryRelationSettingForm : Form
    {
        public int SettingID = 0;
        public QueryRelationSettingForm()
        {
            InitializeComponent();
        }
        List<jqColumn> ColumnList = new List<jqColumn>();
        List<jqTable> TableList = new List<jqTable>();
        HrDBDataContext db = new HrDBDataContext();
        private void QueryRelationSettingForm_Load(object sender, EventArgs e)
        {
            TableList = (from a in db.jqTable where a.SettingID == SettingID select a).ToList();

            var dic1 = TableList.ToDictionary(p => p.TableName, p => p.DisplayName.Trim() != p.TableName.Trim() ? p.TableName + "-" + p.DisplayName : p.TableName);
            SystemFunction.SetComboBoxItems(comboBox1, dic1);
            SystemFunction.SetComboBoxItems(comboBox2, dic1);
            var sqlColumns = from a in db.jqColumn where a.SettingID == SettingID select a;
            ColumnList = sqlColumns.ToList();
            comboBox1_SelectedIndexChanged(null, null);
            comboBox2_SelectedIndexChanged(null, null);
            RefreshRelationTable();
        }
        void RefreshRelationTable()
        {
            var foreignList = (from a in db.jqForeignKey
                               where a.SettingID == SettingID
                               select a).ToList();
            var qq = from a in foreignList
                     join b in ColumnList on a.ParentID equals b.ID
                     join c in ColumnList on a.ChildID equals c.ID
                     select new { a.ID,a.ParentTable,a.ParentColumn,a.ChildTable,a.ChildColumn };
            dataGridView1.DataSource = qq.CopyToDataTable();
        }
        private void buttonAddRelation_Click(object sender, EventArgs e)
        {
            jqForeignKey fk = new jqForeignKey();
            fk.ChildColumn = comboBox4.SelectedValue.ToString();
            fk.ChildTable = comboBox2.SelectedValue.ToString();
            fk.ChildID = ColumnList.Where(p => p.TableName == fk.ChildTable && p.ColumnName == fk.ChildColumn).First().ID;
            fk.CreateDate = DateTime.Now;
            fk.CreateMan = Main.USER_NAME;
            fk.ParentColumn = comboBox3.SelectedValue.ToString();
            fk.ParentTable = comboBox1.SelectedValue.ToString();
            fk.ParentID = ColumnList.Where(p => p.TableName == fk.ParentTable && p.ColumnName == fk.ParentColumn).First().ID;
            fk.SettingID = SettingID;
            db.jqForeignKey.InsertOnSubmit(fk);
            db.SubmitChanges();
            RefreshRelationTable();
            //MessageBox.Show("新增完成");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox3.Items.Clear();
            var dic = ColumnList.Where(p=>p.TableName==comboBox1.SelectedValue.ToString()).ToDictionary(p => p.ColumnName, p => p.DisplayName.Trim() != p.ColumnName.Trim() ? p.ColumnName + "-" + p.DisplayName : p.ColumnName);
            SystemFunction.SetComboBoxItems(comboBox3, dic);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox4.Items.Clear();
            var dic = ColumnList.Where(p => p.TableName == comboBox2.SelectedValue.ToString()).ToDictionary(p => p.ColumnName, p => p.DisplayName.Trim() != p.ColumnName.Trim() ? p.ColumnName + "-" + p.DisplayName : p.ColumnName);
            SystemFunction.SetComboBoxItems(comboBox4, dic);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var colID = dataGridView1.Rows[e.RowIndex].Cells["colID"].Value;
                int id = Convert.ToInt32(colID);
                var sqlForeign = from a in db.jqForeignKey where a.SettingID == SettingID && a.ID==id select a;
                db.jqForeignKey.DeleteAllOnSubmit(sqlForeign);
                db.SubmitChanges();
                RefreshRelationTable();
            }
        }
    }
}
