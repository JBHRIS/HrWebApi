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
    public partial class Parameter : Form
    {
        public Parameter()
        {
            InitializeComponent();
        }
        public int GroupID = -1;
        public string ConnStr = "";
        private void Parameter_Load(object sender, EventArgs e)
        {
            DBDataContext db = new DBDataContext();
            if (ConnStr.Trim().Length > 0)
                db = new DBDataContext(ConnStr);
            if (!JBModule.Message.UI.DbContext.IsTableExists("PARAMETER"))
            {
                if (MessageBox.Show("參數設定資料表不存在，請問是否要現在產生?", "資料表不存在", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    if (!JBModule.Message.UI.DbContext.IsTableExists("PARAMETER_TREE"))
                    {
                        JBModule.Message.UI.DbContext.CreateParameterTreeTable();
                        GroupID = DbContext.InitialParameterTree();
                    }
                    else
                    {
                        var query = from a in db.PARAMETER_TREE where a.CODE == "MailSettings" select a;
                        if (query.Any())
                        {
                            GroupID = query.First().AUTO;
                        }
                        else
                        {
                            GroupID = DbContext.InitialParameterTree();
                        }
                    }
                    JBModule.Message.UI.DbContext.CreateParameterTable();
                    DbContext.InitialParameter(GroupID);
                }
                else
                {
                    var query = from a in db.PARAMETER_TREE where a.CODE == "MailSettings" select a;
                    if (query.Any())
                    {
                        GroupID = query.First().AUTO;
                    }
                }
            }
            else
            {
                var query = from a in db.PARAMETER_TREE where a.CODE == "MailSettings" select a;
                if (query.Any())
                {
                    GroupID = query.First().AUTO;
                }
            }
            this.pARAMETERTableAdapter.FillByGroup(this.mailDataSet.PARAMETER, GroupID);
            label1.Text = this.mailDataSet.PARAMETER.Rows.Count.ToString();

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.pARAMETERTableAdapter.Update(this.mailDataSet.PARAMETER);
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBDataContext db = new DBDataContext();
            var query = from a in db.PARAMETER where a.PARMGROUP_AUTO == GroupID select a;
            db.PARAMETER.DeleteAllOnSubmit(query);
            db.SubmitChanges();
            DbContext.InitialParameter(GroupID);
            this.Close();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex == 3)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.UseSystemPasswordChar = true;
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if ((e.RowIndex == 3) && e.Value != null)
                {
                    dataGridView1.Rows[e.RowIndex].Tag = e.Value;
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
        }
    }
}
