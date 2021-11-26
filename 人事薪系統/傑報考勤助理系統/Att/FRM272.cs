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
    public partial class FRM272 : JBControls.JBForm
    {
        public FRM272()
        {
            InitializeComponent();
        }
        dcAttDataContext db = new dcAttDataContext();
        dcViewDataContext dv = new dcViewDataContext();
        System.Drawing.Color SelectedDateColor = Color.Aqua;
        /// <summary>
        /// 目前指定的日期
        /// </summary>
        DateTime Adate = DateTime.Now.Date;
        /// <summary>
        /// 目前檢視的年月
        /// </summary>
        DateTime Vdate = DateTime.Now.Date;
        string topic = "";
        private void FRM2E_Load(object sender, EventArgs e)
        {
            this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            this.aTTBAKTableAdapter.FillByInit(this.dsAtt.ATTBAK);
            CreateTable();
            if (cbxDept.Items.Count == 0)
            {
                foreach (var ctrl in this.Controls) ((Control)ctrl).Enabled = false;
                return;
            }
            topic = this.Text;
            GridBind(DateTime.Now.Date);
            DateBind(DateTime.Now.Date);
            txtGotoDate.Text = Sal.Core.SalaryDate.DateString();
        }
        void CreateTable()
        {
            for (int i = 0; i < tableLayoutPanel1.RowCount * tableLayoutPanel1.ColumnCount; i++)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Fill;
                btn.Click += new EventHandler(btn_Click);
                tableLayoutPanel1.Controls.Add(btn);
            }
        }
        /// <summary>
        /// 將畫面設定為指定的年月
        /// </summary>
        /// <param name="date">指定年月</param>
        void GridBind(DateTime date)
        {
            Vdate = date;
            int TotalDays = DateTime.DaysInMonth(Vdate.Year, Vdate.Month);
            DateTime FirstDayOfMonth = new DateTime(Vdate.Year, Vdate.Month, 1);
            DateTime LastDayOfMonth = new DateTime(Vdate.Year, Vdate.Month, TotalDays);
            int WeekDayOfFirstDay = Convert.ToInt32(FirstDayOfMonth.DayOfWeek);
            DateTime d1 = FirstDayOfMonth;
            var sql = from ab in dv.V_FRM272
                      where ab.ADATE >= FirstDayOfMonth && ab.ADATE <= LastDayOfMonth
                      select ab;
            if (!chkDept.Checked)
                sql = from ab in sql where ab.DEPT == cbxDept.SelectedValue.ToString() select ab;

            var list = sql.ToList();
            foreach (var ctrl in tableLayoutPanel1.Controls)
            {
                WeekDayOfFirstDay--;
                Button btn = (Button)ctrl;
                btn.Text = "";
                btn.Tag = "";
                btn.Enabled = false;
                btn.BackColor = btnAdd.BackColor;
                if (WeekDayOfFirstDay >= 0) continue;

                if (d1 <= LastDayOfMonth)
                {
                    btn.Enabled = true;
                    btn.Tag = Sal.Core.SalaryDate.DateString(d1);
                    btn.Text = d1.Day.ToString();
                    var data = from d in list where d.ADATE == d1 select d;
                    if (data.Any())//如果當天有備勤人員
                        btn.Text += "\n" + data.First().NAME_C;
                    d1 = d1.AddDays(1);
                }

            }
            this.Text = topic + Vdate.ToString(Resources.Att.YearMonthStringFormat);
        }
        void DateBind(DateTime date)
        {
            DateTime oldDate;//焦點離開前的日期
            oldDate = Adate;
            Adate = date;//變更焦點後的日期
            lblAdate.Text = Sal.Core.SalaryDate.DateString(Adate);

            var sql = from ab in dv.V_FRM272
                      where ab.ADATE == Adate
                      select ab;
            if (!chkDept.Checked)
                sql = from ab in sql where ab.DEPT == cbxDept.SelectedValue.ToString() select ab;

            var list = sql;

            DateTime FirstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            int WeekDayOfFirstDay = Convert.ToInt32(FirstDayOfMonth.DayOfWeek);
            Control oldCtrl = tableLayoutPanel1.Controls[WeekDayOfFirstDay + oldDate.Day - 1];
            ((Button)oldCtrl).BackColor = btnAdd.BackColor;
            //((Button)oldCtrl).Text = 
            Control ctrl = tableLayoutPanel1.Controls[WeekDayOfFirstDay + Adate.Day - 1];
            WeekDayOfFirstDay--;
            Button btn = (Button)ctrl;
            var data = from d in list where d.ADATE == Adate select d;

            this.dsAtt.ATTBAK.Clear();
            var cmd = dv.GetCommand(data);
            this.dsAtt.ATTBAK.FillData(cmd);
            btn.BackColor = SelectedDateColor;
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DateTime date = Convert.ToDateTime(btn.Tag);
            DateBind(date);
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            DateTime date = Vdate.AddMonths(-1);
            GridBind(date);
            if (Vdate.Year == Adate.Year && Vdate.Month == Adate.Month) DateBind(Adate);
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            DateTime date = Vdate.AddMonths(1);
            GridBind(date);
            if (Vdate.Year == Adate.Year && Vdate.Month == Adate.Month) DateBind(Adate);
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(txtGotoDate.Text);
            if (Vdate.Year != date.Year || Vdate.Month != date.Month) GridBind(date);
            DateBind(date);
        }

        private void cbxHolicd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDept.SelectedValue != null)//為了略過錯誤
            {
                GridBind(Adate);
                DateBind(Adate);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FRM272A frm = new FRM272A();
            frm.Adate = Adate;
            frm.ShowDialog();
            if (frm.isChange)
            {
                GridBind(Vdate);
                DateBind(Adate);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string nobr = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                var data = from r in dsAtt.ATTBAK where r.NOBR == nobr && r.ADATE == Adate select r;
                foreach (var r in data) r.Delete();
                this.aTTBAKTableAdapter.Update(dsAtt.ATTBAK);
            }
        }

        private void chkDept_CheckedChanged(object sender, EventArgs e)
        {
            cbxDept.Enabled = !chkDept.Checked;

            if (cbxDept.SelectedValue != null)//為了略過錯誤
            {
                GridBind(Adate);
                DateBind(Adate);
            }
        }
    }
}
