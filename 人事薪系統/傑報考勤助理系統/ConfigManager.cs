﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace JBHR
{
    public partial class ConfigManager : JBControls.JBForm
    {
        public ConfigManager()
        {
            InitializeComponent();
        }
        JBModule.Data.Linq.HrDBDataContext db = null;
        IEnumerable<JBModule.Data.Linq.AppConfig> configs = null;
        public string Category = "";
        private void ConfigManager_Load(object sender, EventArgs e)
        {
            db = new JBModule.Data.Linq.HrDBDataContext();
            configs = from a in db.AppConfig where a.Category == Category && (a.Comp == MainForm.COMPANY || a.Comp.Trim().Length == 0) select a;
            dataGridView1.DataSource = configs;
            foreach (DataGridViewRow itm in dataGridView1.Rows)
            {
                var confs = from a in configs where a.Code == itm.Cells[1].Value.ToString() select a;
                if (confs.Any())
                {

                    var conf = confs.First();
                    if (conf.ControlType == "ComboBox")
                    {
                        var cmd = db.Connection.CreateCommand();
                        cmd.CommandText = conf.DataSource;
                        System.Data.SqlClient.SqlParameter sp = new System.Data.SqlClient.SqlParameter();
                        sp.ParameterName = "userid";
                        sp.Value = MainForm.USER_ID;
                        cmd.Parameters.Add(sp);
                        sp = new System.Data.SqlClient.SqlParameter();
                        sp.ParameterName = "comp";
                        sp.Value = MainForm.COMPANY;
                        cmd.Parameters.Add(sp);
                        sp = new System.Data.SqlClient.SqlParameter();
                        sp.ParameterName = "admin";
                        sp.Value = MainForm.ADMIN;
                        cmd.Parameters.Add(sp);
                        if (db.Connection.State != ConnectionState.Open) db.Connection.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        db.Connection.Close();
                        var cbx = new DataGridViewComboBoxCell();
                        cbx.DataSource = dt;
                        cbx.ValueMember = dt.Columns[0].ColumnName;
                        cbx.DisplayMember = dt.Columns[1].ColumnName;
                        //foreach (DataRow r in dt.Rows)
                        //{
                        //    cbx.Items.Add(new KeyValuePair<string, string>(r[0].ToString(), r[1].ToString()));
                        //}
                        itm.Cells[2] = cbx;
                    }

                }



            }
            dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
        }

        void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確認是否要存檔?", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
            {
                db.SubmitChanges();
                MessageBox.Show("存檔完成");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
