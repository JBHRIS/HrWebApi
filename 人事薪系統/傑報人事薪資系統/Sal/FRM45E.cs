using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBModule.Data;

namespace JBHR.Sal
{
    public partial class FRM45E : Form
    {
        public FRM45E()
        {
            InitializeComponent();
        }
        public string nobr;
        public DateTime d1, d2;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow dgvr = dataGridView1.Rows[e.RowIndex];

                SalaryDSTableAdapters.SALBASDTableAdapter ad = new JBHR.Sal.SalaryDSTableAdapters.SALBASDTableAdapter();
                //SalaryDS.SALBASDDataTable dt = ad.GetDataByNobrCode(dgvr.Cells[2].Value.ToString(), dgvr.Cells[3].Value.ToString());

                string salcode = dgvr.Cells[3].Value.ToString();
                SalaryDS.SALBASDDataTable dt = new SalaryDS.SALBASDDataTable();
                SalaryMDDataContext smd = new SalaryMDDataContext();
                var sql = from s in smd.V_FRM46 where s.NOBR == nobr && s.SAL_CODE == salcode select s;
                dt.FillData(smd.GetCommand(sql));

                if (dt.Rows.Count > 0)
                {
                    var itms = from dd in dt let d = CDecryp.Number(dd.AMT) let da = Sal.Core.SalaryDate.DateString(dd.ADATE) select new { da, d };
                    DataTable tb = itms.CopyToDataTable();
                    tb.Columns[0].ColumnName = Resources.Sal.colAdate;
                    tb.Columns[1].ColumnName = Resources.Sal.colAmt;

                    Function.ShowView(Resources.Sal.colSalaryAdjust, tb);
                }

            }
        }
        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                decimal amt = this.salaryDS.SALBASD.Sum(aa => aa.AMT);
            }
        }

        private void FRM45E_Load(object sender, EventArgs e)
        {

            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.sALBASDTableAdapter.FillByNobrDateBetween(this.salaryDS.SALBASD, nobr);
            this.bASETTSTableAdapter.FillByNobrDate(this.salaryDS.BASETTS,nobr,d2);
            SalaryMDDataContext db = new SalaryMDDataContext();

            var baseSQL=from a in db.BASE where a.NOBR==nobr select a;
            this.basDS.BASE.FillData(db.GetCommand( baseSQL));

            var sql = from a in db.BASETTS where a.NOBR == nobr select a;
            var sql1 = from a in sql where d2 >= a.ADATE && d2 <= a.DDATE.Value select a;
            salaryDS.BASETTS.FillData(db.GetCommand(sql1));

            DataBind();
        }

        void DataBind()
        {
            foreach (var itm in this.salaryDS.SALBASD)//解密
            {
                itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
            }
        }
    }
}
