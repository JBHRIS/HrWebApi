using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_TOOL.DataUpdate
{
    public partial class ForeignKeyUpdateForm : Form
    {
        public ForeignKeyUpdateForm()
        {
            InitializeComponent();
        }

        List<CheckForeignerKeyDto> results = new List<CheckForeignerKeyDto>();
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            List<CheckForeignerKeyEntry> checkList = new List<CheckForeignerKeyEntry>();
            results = new List<CheckForeignerKeyDto>();
            //checkList.Add(new CheckForeignerKeyEntry
            //{
            //    SourceTable = "BASE",
            //    SourceColumn = "NOBR",
            //    TargetTable = "CARD",
            //    TargetColumn = "NOBR",
            //});
            //checkList.Add(new CheckForeignerKeyEntry
            //{
            //    SourceTable = "ROTE",
            //    SourceColumn = "ROTE",
            //    TargetTable = "ATTEND",
            //    TargetColumn = "ROTE",
            //});
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.HrDBConnectionString);
            checkList = conn.Query<CheckForeignerKeyEntry>("Select * from CheckForeignerKeyEntry").ToList();
            foreach (var it in checkList)
            {
                string sql_comd = string.Format(@"select distinct '{0}' SourceTable,'{1}' SourceColumn, t1.{1} SourceValue,'{2}' TargetTable,'{3}' TargetColumn ,{2}.{3} TargetValue from {2} 
outer apply (select {0}.{1} from {0} where {0}.{1}={2}.{3}) t1
where exists(select 1 from {0} where {0}.{1}={2}.{3}) and not exists(select 1 from {0} where {0}.{1}={2}.{3} collate Chinese_PRC_CS_AI)", it.SourceTable, it.SourceColumn, it.TargetTable, it.TargetColumn);
                results.AddRange(conn.Query<CheckForeignerKeyDto>(sql_comd));
            }
            dataGridView1.DataSource = results;
            MessageBox.Show("OK");
        }

        private void buttonFix_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.HrDBConnectionString);
            foreach(var result in results.Distinct())
            {
                string update_cmd = string.Format("update {0} set {1}='{2}' where {1}='{3}'", result.TargetTable, result.TargetColumn, result.SourceValue, result.TargetValue);
                conn.Execute(update_cmd,null);
            }
            MessageBox.Show("OK");
        }
    }
    public class CheckForeignerKeyEntry
    {
        public string SourceTable { get; set; }
        public string SourceColumn { get; set; }
        public string TargetTable { get; set; }
        public string TargetColumn { get; set; }
    }
}
