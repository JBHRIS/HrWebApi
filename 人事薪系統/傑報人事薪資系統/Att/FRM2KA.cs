using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace JBHR.Att
{
    public partial class FRM2KA : JBControls.JBForm
    {
        public FRM2KA()
        {
            InitializeComponent();
        }
        public string datatable, nobr, date, time, cardno, checktime,
            datasource, initialcatalog, userid, passwd, source, ipaddr, temperature;
        private void button1_Click(object sender, EventArgs e)
        {
            datatable = cbxDataTable.SelectedValue.ToString();
            nobr = cbxNobr.SelectedValue.ToString();
            date = cbxDate.SelectedValue.ToString();
            time = cbxTime.SelectedValue.ToString();
            cardno = cbxCardNo.SelectedValue.ToString();
            checktime = cbxCheckTime.SelectedValue.ToString();
            source = cbxSource.SelectedValue.ToString();
            ipaddr = cbxIpAddr.SelectedValue.ToString();
            temperature = cbxTemperature.SelectedValue.ToString();
        }

        private void FRM2KA_Load(object sender, EventArgs e)
        {
            button1.DialogResult = DialogResult.OK;

            string connectionString =
               string.Format(
               "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}"
               , datasource, initialcatalog, userid, passwd);

            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                Dictionary<string, string> itms = new Dictionary<string, string>();
                JBModule.Data.CSQL sql = new JBModule.Data.CSQL(conn);
                //cbxDataTable.ValueMember = "id";
                var tables = sql.GetDataTable("sp_tables");
                var tb = from r in tables.AsEnumerable() where r["TABLE_TYPE"].ToString().ToLower() == "table" select r;
                foreach (var itm in tb)
                    if (!itms.ContainsKey(itm["table_name"].ToString()))
                        itms.Add(itm["table_name"].ToString(), itm["table_name"].ToString());
                //cbxDataTable.AddItem(itms);
                SystemFunction.SetComboBoxItems(cbxDataTable, itms, false, true, true, true);
            }
            catch (Exception ex)
            {
                JBModule.Message.TextLog.WriteLog(ex);
                MessageBox.Show(Resources.All.DBConnectErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void cbxDataTable_SelectedIndexChange(object sender, EventArgs e)
        {
            string connectionString =
                string.Format(
                "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}"
                , datasource, initialcatalog, userid, passwd);

            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                Dictionary<string, string> itms = new Dictionary<string, string>();
                JBModule.Data.CSQL sql = new JBModule.Data.CSQL(conn);
                //cbxDataTable.ValueMember = "id";
                var tables = sql.GetDataTable("SP_COLUMNS '" + cbxDataTable.SelectedValue + "'");
                //var tb = from r in tables.AsEnumerable() where r["TABLE_TYPE"].ToString().ToLower() == "table" select r;
                foreach (DataRow itm in tables.Rows) itms.Add(itm["COLUMN_NAME"].ToString(), itm["COLUMN_NAME"].ToString());

                //cbxCardNo.ClearItems();
                //cbxDate.ClearItems();
                //cbxNobr.ClearItems();
                //cbxTime.ClearItems();
                //cbxCheckTime.ClearItems();
                //cbxSource.ClearItems();
                //cbxIpAddr.ClearItems();

                //cbxCardNo.ValueMember = "id";
                //cbxDate.ValueMember = "id";
                //cbxNobr.ValueMember = "id";
                //cbxTime.ValueMember = "id";
                //cbxCheckTime.ValueMember = "id";
                //cbxSource.ValueMember = "id";
                //cbxIpAddr.ValueMember = "id";

                //cbxCardNo.AddItem(itms);
                //cbxDate.AddItem(itms);
                //cbxNobr.AddItem(itms);
                //cbxTime.AddItem(itms);
                //cbxCheckTime.AddItem(itms);
                //cbxSource.AddItem(itms);
                //cbxIpAddr.AddItem(itms);

                SystemFunction.SetComboBoxItems(cbxDate, itms, false, true, true, true);
                SystemFunction.SetComboBoxItems(cbxNobr, itms, false, true, true, true);
                SystemFunction.SetComboBoxItems(cbxTime, itms, false, true, true, true);
                SystemFunction.SetComboBoxItems(cbxCardNo, itms, true, true, true, true);
                SystemFunction.SetComboBoxItems(cbxCheckTime, itms, true, true, true, true);
                SystemFunction.SetComboBoxItems(cbxSource, itms, true, true, true, true);
                SystemFunction.SetComboBoxItems(cbxIpAddr, itms, true, true, true, true);
                SystemFunction.SetComboBoxItems(cbxTemperature, itms, true, true, true, true);
            }
            catch
            {
                MessageBox.Show(Resources.All.DBConnectErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
