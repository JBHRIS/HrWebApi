using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq;
namespace HR_TOOL.JBQuery
{
    public partial class U_VIEW : JBControls.JBForm
    {
        public U_VIEW()
        {
            InitializeComponent();
        }
        HrDBDataContext db = new HrDBDataContext();

        private void jbQuery1_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            QuerySettingForm frm = new QuerySettingForm();
            frm.ShowDialog();
        }

        private void jbQuery1_DataQuerying(object sender, JBControls.JBQuery.DataQueryingEventArgs e)
        {
            jbQuery1.QueryBuilder.AddWhere("Sort", CodeEngine.Framework.QueryBuilder.Enums.Comparison.GreaterThan, 0);
        }

        private void buttonColimn_Click(object sender, EventArgs e)
        {
            if (jbQuery1.SelectedKey != null)
            {
                int id = Convert.ToInt32(jbQuery1.SelectedKey);
                QueryColumnSettingForm frm = new QueryColumnSettingForm();
                frm.SettingID = id;
                frm.ShowDialog();
            }
        }

        private void buttonRelation_Click(object sender, EventArgs e)
        {
            if (jbQuery1.SelectedKey != null)
            {
                int id = Convert.ToInt32(jbQuery1.SelectedKey);
                QueryRelationSettingForm frm = new QueryRelationSettingForm();
                frm.SettingID = id;
                frm.ShowDialog();
            }
        }

        private void buttonTable_Click(object sender, EventArgs e)
        {
            if (jbQuery1.SelectedKey != null)
            {
                int id = Convert.ToInt32(jbQuery1.SelectedKey);
                QueryTableSettingForm frm = new QueryTableSettingForm();
                frm.SettingID = id;
                frm.ShowDialog();
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            if (jbQuery1.SelectedKey != null)
            {
                int id = Convert.ToInt32(jbQuery1.SelectedKey);
                QueryFilterSetting frm = new QueryFilterSetting();
                frm.SettingID = id;
                frm.ShowDialog();
            }
        }

        private void jbQuery1_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            var sqlSetting = from a in db.jqSetting where a.ID == Convert.ToInt32(e.PrimaryKey) select a;
            var sqlColumn = from a in db.jqColumn where a.SettingID == Convert.ToInt32(e.PrimaryKey) select a;
            var sqljqForeignKey = from a in db.jqForeignKey where a.SettingID == Convert.ToInt32(e.PrimaryKey) select a;
            var sqljqPreCondition = from a in db.jqPreCondition where a.SettingID == Convert.ToInt32(e.PrimaryKey) select a;
            var sqljqSqlQueryField = from a in db.jqSqlQueryField where a.SettingID == Convert.ToInt32(e.PrimaryKey) select a;
            var sqljqTable = from a in db.jqTable where a.SettingID == Convert.ToInt32(e.PrimaryKey) select a;

            db.jqSetting.DeleteAllOnSubmit(sqlSetting);
            db.jqColumn.DeleteAllOnSubmit(sqlColumn);
            db.jqForeignKey.DeleteAllOnSubmit(sqljqForeignKey);
            db.jqPreCondition.DeleteAllOnSubmit(sqljqPreCondition);
            db.jqSqlQueryField.DeleteAllOnSubmit(sqljqSqlQueryField);
            db.jqTable.DeleteAllOnSubmit(sqljqTable);
            db.SubmitChanges();
        }

        private void jbQuery1_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            QuerySettingForm frm = new QuerySettingForm();
            frm.SettingID = Convert.ToInt32(e.PrimaryKey);
            frm.ShowDialog();
        }
     
    }
}
