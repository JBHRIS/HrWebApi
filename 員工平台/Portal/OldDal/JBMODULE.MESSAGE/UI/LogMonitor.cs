using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBModule.Message.UI
{
    public partial class LogMonitor : Form
    {
        public LogMonitor()
        {
            InitializeComponent();
        }
        IQueryable<SYSLOG> sql = null;
        public int PID = -1;
        public string KEY_MAN = "JB";
        private void LogMonitor_Load(object sender, EventArgs e)
        {
            if (!JBModule.Message.UI.DbContext.IsTableExists("SYSLOG"))
            {
                if (MessageBox.Show("記錄檔資料表不存在，請問是否要現在產生?", "資料表不存在", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    JBModule.Message.UI.DbContext.CreateSysLogTable();
                }
            }
            dateTimePicker1.Value = DateTime.Now.Date.AddDays(-1);
            dateTimePicker2.Value = DateTime.Now.Date.AddDays(1);
            DBDataContext db = new DBDataContext();
            var query = from a in db.SYSLOG select a.SOURCE;
            var sources = query.Distinct();
            comboBox1.Items.AddRange(sources.ToArray());
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            if (PID >= 0)
            {
                sql = from a in db.SYSLOG where a.SID == PID select a;
                DataBind();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBDataContext db = new DBDataContext();
            sql = from a in db.SYSLOG where a.KEY_DATE >= dateTimePicker1.Value && a.KEY_DATE <= dateTimePicker2.Value select a;

            if (radioButton2.Checked)
            {
                sql = from a in sql where a.TYPE == "msg" select a;
            }
            else if (radioButton3.Checked)
            {
                sql = from a in sql where a.TYPE == "err" select a;
            }
            if (comboBox1.SelectedIndex > 0)
            {
                sql = from a in sql where a.SOURCE == comboBox1.SelectedItem.ToString() select a;
            }
            DataBind();
        }

        void DataBind()
        {
            var data = from a in sql select new { 編號 = a.ID, 類型 = a.TYPE, 來源 = a.SOURCE,標題=a.TITLE, 訊息 = a.NOTE, 登錄者 = a.KEY_MAN, 登錄日期 = a.KEY_DATE };
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                textBox1.Text = row.Cells["訊息"].Value.ToString();
            }
        }
    }
}
