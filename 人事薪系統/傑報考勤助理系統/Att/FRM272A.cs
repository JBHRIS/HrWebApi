using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace JBHR.Att
{
    public partial class FRM272A : JBControls.JBForm
    {
        public FRM272A()
        {
            InitializeComponent();
        }
        DateTime adate = DateTime.Now.Date;
        public bool isChange = false;
        private void FRM272A_Load(object sender, EventArgs e)
        {

        }
        public DateTime Adate
        {
            get { return this.adate; }
            set
            {
                this.adate = value;
                dcViewDataContext db = new dcViewDataContext();
                var sql = from r in db.V_FRM271 where adate >= r.BDATE && adate <= r.EDATE select r;
                var cmd = db.GetCommand(sql);
                this.dsAtt.BASEBAK.FillData(cmd);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow r = dataGridView1.Rows[e.RowIndex];
                string nobr = r.Cells[1].Value.ToString();
                AddData(nobr);
            }
        }
        void AddData(string nobr)
        {
            dcAttDataContext db = new dcAttDataContext();
            var sql1 = from r in db.BASEBAK where r.NOBR == nobr && adate >= r.BDATE && adate <= r.EDATE select r;
            if (sql1.Any())
            {
                var sql2 = from r in db.ATTBAK where r.NOBR == nobr && adate == r.ADATE select r;
                if (!sql2.Any())
                {
                    ATTBAK atb = new ATTBAK();
                    atb.ADATE = adate;
                    atb.KEY_DATE = DateTime.Now;
                    atb.KEY_MAN = MainForm.USER_NAME;
                    atb.NOBR = nobr;
                    db.ATTBAK.InsertOnSubmit(atb);
                    db.SubmitChanges();
                    isChange = true;
                    this.Close();
                }
                else ptxNobr.Text = "";
            }
            else ptxNobr.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dcViewDataContext db = new dcViewDataContext();
            string nobr = ptxNobr.Text;
            AddData(nobr);

        }
    }
}
