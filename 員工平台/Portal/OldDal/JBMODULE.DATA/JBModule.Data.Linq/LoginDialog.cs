using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace JBModule.Data
{
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
        }
        string host;
        string db;
        string id;
        string password;
        bool integration;
        public string ConnectionString;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.Enabled = radioButton2.Checked;
            textBox4.Enabled = radioButton2.Checked;
        }

        private void btnCheckList_Click(object sender, EventArgs e)
        {
            SetConfig();
            db = "master";//如果要查詢資料庫名稱的話就拿master當預設的資料庫

            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = host;
            sb.InitialCatalog = db;
            sb.IntegratedSecurity = integration;
            if (!integration)
            {
                sb.UserID = id;
                sb.Password = password;
            }
            SqlConnection conn = new SqlConnection(sb.ConnectionString);
            SqlHelper cs = new SqlHelper(conn);
            string cmd = "sp_databases";
            var tbl = cs.GetDataTable(cmd);
            comboBox1.Items.Clear();
            foreach (DataRow r in tbl.Rows)
            {
                comboBox1.Items.Add(r[0].ToString());
            }
        }

        void SetConfig()
        {
            host = textBox1.Text;
            db = "master";
            if (comboBox1.Items.Count > 0)
            {
                if (comboBox1.SelectedValue == null)
                    db = "master";
                else db = comboBox1.SelectedValue.ToString();

            }
            id = textBox3.Text;
            password = textBox4.Text;
            integration = radioButton1.Checked;
        }

        private void LoginDialog_Load(object sender, EventArgs e)
        {
            SetConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetConfig();
           
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = host;
            sb.InitialCatalog = db;
            sb.IntegratedSecurity = integration;
            if (!integration)
            {
                sb.UserID = id;
                sb.Password = password;
            }
            SqlConnection conn = new SqlConnection(sb.ConnectionString);
            SqlHelper cs = new SqlHelper(conn);
            string cmd = "sp_databases";
            var tbl = cs.GetDataTable(cmd);
            comboBox1.Items.Clear();
            foreach (DataRow r in tbl.Rows)
            {
                comboBox1.Items.Add(r[0].ToString());
            }
        }

    }
}
