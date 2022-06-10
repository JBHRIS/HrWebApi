using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.Linq;
using System.Linq;
namespace HR_TOOL.DbLoger
{
    public partial class DbLoggerForm : Telerik.WinControls.UI.RadForm
    {
        public DbLoggerForm()
        {
            InitializeComponent();
        }
        HrDBDataContext db = new HrDBDataContext();
        private void button1_Click(object sender, EventArgs e)
        {
            radGridView1.DataSource = db.DbLog.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var row = radGridView1.CurrentRow;
            var itm = row.DataBoundItem as DbLog;
            if (itm != null)
            {
                var s1 = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(itm.BeforeData);
                var s2 = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(itm.AfterData);
                DataCompare dc = new DataCompare();
                dc.Source1 = s1;
                dc.Source2 = s2;
                dc.Show();
            }
        }
    }
}
