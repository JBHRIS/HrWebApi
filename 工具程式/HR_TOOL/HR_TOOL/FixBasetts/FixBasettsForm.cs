using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HR_TOOL.FixBasetts
{
    public partial class FixBasettsForm : Form
    {
        public FixBasettsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckErrorBasetts();
            MessageBox.Show(string.Format("發現有{0}筆異常", listBox1.Items.Count));
        }
        void CheckErrorBasetts()
        {
            listBox1.Items.Clear();
            HrDBDataContext db = new HrDBDataContext();
            var sql = (from a in db.BASETTS
                       join b in db.BASETTS on a.NOBR equals b.NOBR
                       where a.ADATE != b.ADATE
                       && a.ADATE <= b.DDATE.Value && a.DDATE.Value >= b.ADATE
                       select new { a.NOBR, a.ADATE }).ToList();
            var sql1 = (from a in db.BASETTS
                        where a.DDATE.Value >= new DateTime(9999, 12, 31)
                        select a.NOBR
                       ).ToList();
            var sql2 = (from a in db.BASETTS
                        //where a.DDATE.Value >= new DateTime(9999, 12, 31)
                        select a.NOBR
                     ).Distinct().ToList();
            var lst = sql2.Where(p => !sql1.Contains(p));
            listBox1.Items.AddRange(sql.Select(p => p.NOBR).Union(lst).Distinct().ToArray());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var nobr in listBox1.Items)
            {
                HrDBDataContext db = new HrDBDataContext();
                var sql = from a in db.BASETTS where a.NOBR == nobr.ToString() orderby a.ADATE descending select a;
                DateTime dd = new DateTime(9999, 12, 31);
                foreach (var it in sql)
                {
                    it.DDATE = dd;
                    dd = it.ADATE.AddDays(-1);
                }
                db.SubmitChanges();
                i++;
            }
            CheckErrorBasetts();
            MessageBox.Show(string.Format("已修正{0}筆異常", i));
        }
    }
}
