using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HR_TOOL
{
    public partial class FixBasetts : Form
    {
        public FixBasetts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HrDBDataContext db = new HrDBDataContext();
            var sql = from a in db.BASETTS group a by a.NOBR;
            int count = 0;
            foreach (var it in sql)
            {
                DateTime ddate = new DateTime(9999, 12, 31);
                foreach (var r in it.OrderByDescending(p=>p.ADATE))
                {
                    r.DDATE = ddate;
                    ddate = r.ADATE.AddMilliseconds(-1);
                }
                count++;
            }
            db.SubmitChanges();
            MessageBox.Show("完成" + count.ToString() + "筆修正");
        }
    }
    public class SimpleBasetts
    {
        public string NOBR;
        public DateTime ADATE;
        public DateTime DDATE;
    }
}
