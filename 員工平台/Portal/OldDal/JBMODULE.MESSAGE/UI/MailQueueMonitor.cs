using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBModule.Message;

namespace JBModule.Message.UI
{
    public partial class MailQueueMonitor : Form
    {
        public MailQueueMonitor()
        {
            InitializeComponent();
        }
        IQueryable<MAILQUEUE> sql = null;
        DBDataContext db = new DBDataContext();
        public string KEY_MAN = "JB";
        private void button1_Click(object sender, EventArgs e)
        {
            sql = from a in db.MAILQUEUE
                  where a.KEY_DATE >= dateTimePicker1.Value && a.KEY_DATE <= dateTimePicker2.Value
                  && a.TO_ADDR.Contains(textBoxReciever.Text)
                  && a.SUBJECT.Contains(textBoxSubject.Text)
                  && a.BODY.Contains(textBoxBody.Text)
                  select a;

            if (radioButton2.Checked)
            {
                sql = from a in sql where a.SUCCESS select a;
            }
            else if (radioButton3.Checked)
            {
                sql = from a in sql where !a.SUCCESS select a;
            }
            DataBind();

        }

        private void MailQueueMonitor_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date.AddDays(-1);
            dateTimePicker2.Value = DateTime.Now.Date.AddDays(1);
            if (!JBModule.Message.UI.DbContext.IsTableExists("MAILQUEUE"))
            {
                if (MessageBox.Show("信件資料表不存在，請問是否要現在產生?", "資料表不存在", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    JBModule.Message.UI.DbContext.CreateMailQueueTable();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var row = dataGridView1.SelectedRows[0];
                string value = row.Cells[0].Value.ToString();
                if (value.Trim().Length > 0)
                {
                    int i = Convert.ToInt32(value);
                    //DBDataContext db = new DBDataContext();
                    var sql1 = from a in sql where a.ID == i select a;
                    foreach (var itm in sql1)
                    {
                        itm.SUSPEND = true;
                    }
                    db.SubmitChanges();
                    DataBind();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var row = dataGridView1.SelectedRows[0];
                string value = row.Cells[0].Value.ToString();
                if (value.Trim().Length > 0)
                {
                    int i = Convert.ToInt32(value);
                    //DBDataContext db = new DBDataContext();
                    var sql1 = from a in sql where a.ID == i select a;
                    foreach (var itm in sql1)
                    {
                        itm.SUSPEND = false;
                    }
                    db.SubmitChanges();
                    DataBind();
                }
            }
        }
        void DataBind()
        {
            var data = sql.Select(p => new { 編號 = p.ID, 寄件者 = p.FROM_NAME + " " + p.FROM_ADDR, 收件者 = p.TO_NAME + " " + p.TO_ADDR, 標題 = p.SUBJECT, 內容 = p.BODY, 成功 = p.SUCCESS, 重試 = p.RETRY, 登錄日期 = p.KEY_DATE, 登錄者 = p.KEY_MAN, 停用 = p.SUSPEND, 冷卻時間 = p.FREEZE_TIME });
            dataGridView1.DataSource = data;
            lblCount.Text = data.Count().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count != 0)
                {
                    var row = dataGridView1.SelectedRows[0];
                    string value = row.Cells[0].Value.ToString();
                    if (value.Trim().Length > 0)
                    {
                        int i = Convert.ToInt32(value);
                        int err = JBModule.Message.Mail.CheckQueue(i);
                        DataBind();
                        if (err > 0)
                        {
                            MessageBox.Show("發送郵件時發生錯誤，請查詢錯誤記錄檔");
                        }
                        else MessageBox.Show("完成");
                    }
                }
            }
            catch (Exception ex)
            {
                JBModule.Message.TextLog.WriteLog(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var row = dataGridView1.SelectedRows[0];
                string value = row.Cells[0].Value.ToString();
                if (value.Trim().Length > 0)
                {
                    int i = Convert.ToInt32(value);
                    LogMonitor frm = new LogMonitor();
                    frm.PID = i;
                    frm.ShowDialog();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var row = dataGridView1.SelectedRows[0];
                string value = row.Cells[0].Value.ToString();
                if (value.Trim().Length > 0)
                {
                    var query = from a in db.MAILQUEUE where a.ID == Convert.ToInt32(value) select a;
                    if (query.Any())
                    {
                        HtmlViewer frm = new HtmlViewer();
                        frm.Content = query.First().BODY;
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void buttonAttachment_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var row = dataGridView1.SelectedRows[0];
                string value = row.Cells[0].Value.ToString();
                if (value.Trim().Length > 0)
                {
                    var query = from a in db.MAILQUEUE where a.ID == Convert.ToInt32(value) select a;
                    if (query.Any())
                    {
                        FileManager frm = new FileManager();
                        frm.FileTicket = query.First().NOTE1;
                        frm.ShowDialog();
                    }
                }
            }

        }

    }
}
