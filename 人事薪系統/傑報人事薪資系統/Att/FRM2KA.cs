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

            string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", datasource);

            OleDbConnection conn = new OleDbConnection(connectionString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                Dictionary<string, string> itms = new Dictionary<string, string>();
                string[] restrictions = new string[4];
                restrictions[3] = "Table";
                // Get list of user tables
                var userTables = conn.GetSchema("Tables", restrictions);
                //var cmd = conn.CreateCommand();
                //cmd.CommandText = "SELECT MSysObjects.Name AS table_name FROM MSysObjects WHERE (((Left([Name],1))<>\"~\")  AND ((Left([Name],4))<>\"MSys\") AND ((MSysObjects.Type) In (1,4,6))) order by MSysObjects.Name";
                ////JBModule.Data.CSQL sql = new JBModule.Data.CSQL(conn);
                //var dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                ////cbxDataTable.ValueMember = "id";
                //var tables = sql.GetDataTable("sp_tables");
                //var tb = from r in dt.Columns select r;
                foreach (DataRow it in userTables.Rows) itms.Add(it["Table_name"].ToString(), it["Table_name"].ToString());
                SystemFunction.SetComboBoxItems(cbxDataTable, itms);
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

        private void cbxDataTable_SelectedIndexChange(object sender, EventArgs e)
        {
            string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};", datasource);

            OleDbConnection conn = new OleDbConnection(connectionString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                Dictionary<string, string> itms = new Dictionary<string, string>();
                var cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM {0} where 1=0", cbxDataTable.SelectedValue.ToString());
                var dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                //var tb = from r in tables.AsEnumerable() where r["TABLE_TYPE"].ToString().ToLower() == "table" select r;
                foreach (DataColumn itm in dt.Columns) itms.Add(itm.ColumnName, itm.ColumnName);
                SystemFunction.SetComboBoxItems(cbxNobr, itms,true);
                SystemFunction.SetComboBoxItems(cbxDate, itms, true);
                SystemFunction.SetComboBoxItems(cbxNobr, itms, true);
                SystemFunction.SetComboBoxItems(cbxTime, itms, true);
                SystemFunction.SetComboBoxItems(cbxCheckTime, itms, true);
                SystemFunction.SetComboBoxItems(cbxSource, itms, true);
                SystemFunction.SetComboBoxItems(cbxIpAddr, itms, true);
                SystemFunction.SetComboBoxItems(cbxCardNo, itms, true);
                SystemFunction.SetComboBoxItems(cbxTemperature,itms, true);
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
