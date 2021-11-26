using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM2E : JBControls.JBForm
    {
        public FRM2E()
        {
            InitializeComponent();
        }
        dcAttDataContext db = new dcAttDataContext();
        DateTime Adate = DateTime.Now.Date;
        DateTime Vdate = DateTime.Now.Date;
        string topic = "";

        private void FRM2E_Load(object sender, EventArgs e)
        {
            this.hOLICDTableAdapter.Fill(this.dsAtt.HOLICD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.oTHCODETableAdapter.Fill(this.dsAtt.OTHCODE);
            topic = this.Text;

            CreateRoteTable();
            if (cbxHoliCode.Items.Count == 0)
            {
                foreach (var ctrl in this.Controls) ((Control)ctrl).Enabled = false;
                return;
            }

            DataBind(DateTime.Now.Date);
            txtGotoDate.Text = Sal.Core.SalaryDate.DateString();
        }
        void CreateRoteTable()
        {
            var sql = from r in db.ROTE select new { rotename = r.ROTENAME, rote = r.ROTE1 };

            for (int i = 0; i < tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount; i++)
            {

                Button btn = new Button();
                btn.Dock = DockStyle.Fill;
                btn.Click += new EventHandler(btn_Click);
                tableLayoutPanel1.Controls.Add(btn);
            }
        }
        void DataBind(DateTime date)
        {
            Adate = date;
            Vdate = date;
            int TotalDays = DateTime.DaysInMonth(date.Year, date.Month);
            DateTime FirstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            DateTime LastDayOfMonth = new DateTime(date.Year, date.Month, TotalDays);
            int WeekDayOfFirstDay = Convert.ToInt32(FirstDayOfMonth.DayOfWeek);
            DateTime d1 = FirstDayOfMonth;
            var sql = from holi in db.HOLI join othcode in db.OTHCODE on holi.OTHCODE equals othcode.OTHCODE1 where holi.H_DATE >= FirstDayOfMonth && holi.H_DATE <= LastDayOfMonth && holi.HOLI_CODE == cbxHoliCode.SelectedValue.ToString() select new { holi, othcode };
            //if(sql.Any())
            var list = sql.ToList();
            foreach (var ctrl in tableLayoutPanel1.Controls)
            {
                WeekDayOfFirstDay--;
                Button btn = (Button)ctrl;
                btn.Text = "";
                btn.Tag = "";
                btn.Enabled = false;

                if (WeekDayOfFirstDay >= 0) continue;

                if (d1 <= LastDayOfMonth)
                {
                    btn.Enabled = true;
                    btn.Tag = Sal.Core.SalaryDate.DateString(d1);
                    btn.Text = d1.Day.ToString();
                    btn.ForeColor = Color.Black;
                    var data = from d in list where d.holi.H_DATE == d1 select d;
                    if (data.Any())//如果當天有設定的假日
                    {
                        var record = data.First();
                        btn.Text += "\n" + record.othcode.OTHNAME;
                        btn.ForeColor = Color.FromArgb(Convert.ToInt32(record.othcode.OTHCOLOR));
                    }
                    d1 = d1.AddDays(1);
                }
            }
            this.Text = topic + Vdate.ToString(Resources.Att.YearMonthStringFormat);
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DateTime date = Convert.ToDateTime(btn.Tag);
            var sql = from holi in db.HOLI
                      join othcode in db.OTHCODE on holi.OTHCODE equals othcode.OTHCODE1
                      where holi.H_DATE == date && holi.HOLI_CODE == cbxHoliCode.SelectedValue.ToString()
                      select new { holi, othcode };
            if (sql.Any()) db.HOLI.DeleteOnSubmit(sql.First().holi);
            else
            {
                HOLI holi = new HOLI();
                holi.ATT_CODE = "";
                holi.H_DATE = date;
                holi.HOLI_CODE = cbxHoliCode.SelectedValue.ToString();
                holi.HOLI1 = false;
                holi.KEY_DATE = DateTime.Now;
                holi.KEY_MAN = MainForm.USER_NAME;
                holi.OTHCODE = cbxOtHcode.SelectedValue.ToString();
                db.HOLI.InsertOnSubmit(holi);
            }
            db.SubmitChanges();
            DataBind(date);
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            DataBind(Adate.AddMonths(-1));
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            DataBind(Adate.AddMonths(1));
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(txtGotoDate.Text);
            DataBind(date);
        }

        private void cbxHolicd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxHoliCode.SelectedValue != null)//為了略過錯誤
                DataBind(Adate);
        }
    }
}
