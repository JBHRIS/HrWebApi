using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
    public partial class U_SETGRP : JBControls.JBForm
    {
        public U_SETGRP()
        {
            InitializeComponent();
        }

        private void U_SETGRP_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'sysDS.U_GROUP1' 資料表。您可以視需要進行移動或移除。
            this.u_GROUP1TableAdapter.Fill(this.sysDS.U_GROUP1);
            // TODO: 這行程式碼會將資料載入 'sysDS.U_GROUP' 資料表。您可以視需要進行移動或移除。
            this.u_GROUPTableAdapter.Fill(this.sysDS.U_GROUP);
            // TODO: 這行程式碼會將資料載入 'sysDS.U_PRG' 資料表。您可以視需要進行移動或移除。
            this.u_PRGTableAdapter.Fill(this.sysDS.U_PRG);

            fullDataCtrl1.DataAdapter = u_GROUPTableAdapter;
            fullDataCtrl1.Init_Ctrls();
            fullDataCtrl1.BindingControls_Init();
            comboBox1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {                
                this.u_GROUP1TableAdapter.Fill(this.sysDS.U_GROUP1);
                comboBox1.ReBind();
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            SysDS.U_PRGRow U_PRGRow = null;

            if (uPRGBindingSource.Current == null) e.Cancel = true;
            else
            {
                U_PRGRow = (uPRGBindingSource.Current as DataRowView).Row as SysDS.U_PRGRow;
            }

            string group_id = "";
            string group_name = "";
            if (comboBox1.SelectedValue.ToString() == "" && (textBox1.Text.Trim().Length == 0 || textBox2.Text.Trim().Length == 0)) e.Cancel = true;
            else
            {
                if (comboBox1.SelectedValue != "")
                {
                    group_id = comboBox1.SelectedValue;
                    group_name = comboBox1.SelectedText;
                }
                else
                {
                    group_id = textBox1.Text;
                    group_name = textBox2.Text;

                    SysDS.U_GROUPDataTable U_GROUPDataTable = u_GROUPTableAdapter.GetDataByGROUP_ID(group_id);
                    if (U_GROUPDataTable.Count > 0)
                    {
                        e.Cancel = true;
                        MessageBox.Show(Resources.Sys.U_GroupID_RptErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            if (!e.Cancel)
            {
                e.Values["group_id"] = group_id;
                e.Values["group_name"] = group_name;
                if(fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add) e.Values["prog"] = U_PRGRow.PROG;
                e.Values["system"] = U_PRGRow.SYSTEM;                
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                this.u_GROUP1TableAdapter.Fill(this.sysDS.U_GROUP1);
                comboBox1.ReBind();
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
                comboBox1.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void uGROUPBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (sysDS.U_GROUP.Count > 0 && uGROUPBindingSource.Current != null)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedValue = ((uGROUPBindingSource.Current as DataRowView).Row as SysDS.U_GROUPRow).GROUP_ID;
            }
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

            comboBox1.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;

            e.Values["group_id"] = "";
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            comboBox1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            comboBox1.Enabled = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }
    }
}