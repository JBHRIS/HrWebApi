using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq;
using System.IO;
namespace HR_TOOL.JBQuery
{
    public partial class JB_VIEW : JBControls.JBForm
    {
        public JB_VIEW()
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
            //jbQuery1.QueryBuilder.AddWhere("ABS.NOBR", CodeEngine.Framework.QueryBuilder.Enums.Comparison.In,new string[]{"110406","050801"});
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

        private void JB_VIEW_Load(object sender, EventArgs e)
        {
            var sql = from a in db.jqSetting where a.Sort > 0 orderby a.Sort select new { a.QuerySetting ,a.QueryName};
            var dic = sql.ToDictionary(p => p.QuerySetting, p => p.QueryName);
            SystemFunction.SetComboBoxItems(comboBoxSetting, dic);
            jbQuery1.Parameters.Add("UserID", "JBADMIN");
            jbQuery1.Parameters.Add("Company", "1");
            jbQuery1.Parameters.Add("Admin", "1");
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            jbQuery1.QuerySettingString = comboBoxSetting.SelectedValue.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var sql = from a in db.jqSetting where a.QuerySetting == comboBoxSetting.SelectedValue.ToString() select a;
            if (sql.Any())
            {
                var _jqSetting = sql.FirstOrDefault();
                //string strJqSetting = Newtonsoft.Json.JsonConvert.SerializeObject(_jqSetting);
                DataTransfer tf = new DataTransfer();
                tf.MySetting = _jqSetting;
                tf.MyColumns = db.jqColumn.Where(p => p.SettingID == _jqSetting.ID).ToList();
                tf.MyForeignKey = db.jqForeignKey.Where(p => p.SettingID == _jqSetting.ID).ToList();
                tf.MyPreCondition = db.jqPreCondition.Where(p => p.SettingID == _jqSetting.ID).ToList();
                tf.MyQueryField = db.jqSqlQueryField.Where(p => p.SettingID == _jqSetting.ID).ToList();
                tf.MyTable = db.jqTable.Where(p => p.SettingID == _jqSetting.ID).ToList();
                string strJqSetting = Newtonsoft.Json.JsonConvert.SerializeObject(tf);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "JbQuery Setting|*.jq";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var file_name = sfd.FileName;
                    StreamWriter sw = new StreamWriter(file_name);
                    sw.Write(strJqSetting);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd=new OpenFileDialog();
            ofd.Filter = "JbQuery Setting|*.jq";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file_name = ofd.FileName;
                StreamReader sr = new StreamReader(file_name);
                var str = sr.ReadToEnd();
                var setting = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTransfer>(str);
                db.jqSetting.InsertOnSubmit(setting.MySetting);
                db.SubmitChanges();
                foreach (var it in setting.MyColumns)
                    it.SettingID = setting.MySetting.ID;
                db.jqColumn.InsertAllOnSubmit(setting.MyColumns);

                foreach (var it in setting.MyForeignKey)
                    it.SettingID = setting.MySetting.ID;
                db.jqForeignKey.InsertAllOnSubmit(setting.MyForeignKey);

                foreach (var it in setting.MyPreCondition)
                    it.SettingID = setting.MySetting.ID;
                db.jqPreCondition.InsertAllOnSubmit(setting.MyPreCondition);

                foreach (var it in setting.MyQueryField)
                    it.SettingID = setting.MySetting.ID;
                db.jqSqlQueryField.InsertAllOnSubmit(setting.MyQueryField);

                foreach (var it in setting.MyTable)
                    it.SettingID = setting.MySetting.ID;
                db.jqTable.InsertAllOnSubmit(setting.MyTable);
                db.SubmitChanges();
                MessageBox.Show("匯入完成");
            }
        }
     
    }
    public class DataTransfer
    {
        public jqSetting MySetting;
        public List<jqColumn> MyColumns;
        public List<jqForeignKey> MyForeignKey;
        public List<jqPreCondition> MyPreCondition;
        public List<jqSqlQueryField> MyQueryField;
        public List<jqTable> MyTable;
    }
}
