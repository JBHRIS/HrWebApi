using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Ins
{
    public partial class FRM32A : JBControls.JBForm
    {
        public string Nobr = "";
        public FRM32A()
        {
            InitializeComponent();
        }
        private void FRM32A_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today.AddMonths(-3);
            SetGrid(dateTimePicker1.Value);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string nobr = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Nobr = nobr;
            this.Close();
        }
        void SetGrid(DateTime ddate)
        {
            InsDataClassesDataContext db = new InsDataClassesDataContext();

            var EmpData = from a in db.BASE
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          where new DateTime(9999, 12, 31) >= b.ADATE && new DateTime(9999, 12, 31) <= b.DDATE //抓最後一筆
                          && (!(from i1 in db.INSLAB where i1.NOBR == a.NOBR && i1.FA_IDNO.Trim().Length == 0 
                                    && i1.OUT_DATE >= b.INDT.Value select 1).Any()
                          || (b.STINDT != null && !(from i1 in db.INSLAB where i1.NOBR == a.NOBR && i1.FA_IDNO.Trim().Length == 0 
                                                        && i1.OUT_DATE >= b.STINDT.Value select 1).Any()))
                          && (b.INDT >= ddate || (b.STINDT != null && b.STINDT >= ddate)
                          )
                          //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          select new
                          {
                              NOBR = b.NOBR.Trim(),
                              NAME_C = a.NAME_C.Trim(),
                              INDT = b.STINDT != null ? (b.STINDT.Value > b.INDT.Value ? b.STINDT.Value : b.INDT.Value) : b.INDT.Value
                          };

            dataGridView1.DataSource = EmpData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetGrid(dateTimePicker1.Value);
        }

    }
}
