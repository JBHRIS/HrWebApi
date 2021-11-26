using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class FRM45C : Form
    {
        public FRM45C()
        {
            InitializeComponent();
        }
        public string nobr, yymm;
        private void FRM45C_Load(object sender, EventArgs e)
        {
            List<string> yearrestList = new List<string>();
            yearrestList.Add("0");
            yearrestList.Add("2");
            yearrestList.Add("4");
            yearrestList.Add("6");

            SalaryMDDataContext db = new SalaryMDDataContext();
            JBModule.Data.Linq.HrDBDataContext hrDB = new JBModule.Data.Linq.HrDBDataContext();
            var salabsList = (from a in hrDB.SALABS
                              join b in hrDB.ATTEND on new { a.NOBR, a.ADATE.Date } equals new { b.NOBR, b.ADATE.Date }
                              join c in
                              ((from abs in hrDB.ABS
                                select new { 屬性 = "請假", abs.NOBR, abs.YYMM, abs.H_CODE, abs.BDATE, abs.BTIME, abs.ETIME, abs.TOL_HOURS })
                              .Union(from absc in hrDB.ABSC select new { 屬性 = "銷假", absc.NOBR, absc.YYMM, absc.H_CODE, absc.BDATE, absc.BTIME, absc.ETIME, absc.TOL_HOURS }))
                              on new { a.NOBR, a.ADATE.Date, a.H_CODE, a.BTIME } equals new { c.NOBR, c.BDATE.Date, c.H_CODE, c.BTIME }
                              join d in hrDB.HCODE on c.H_CODE equals d.H_CODE
                              //join f in db.SALBASD on new { a.NOBR, a.SAL_CODE } equals new { f.NOBR, f.SAL_CODE }
                              join g in hrDB.SALCODE on a.SAL_CODE equals g.SAL_CODE
                              //join h in db.HCODES on new { a.H_CODE, a.SAL_CODE } equals new { h.H_CODE, h.SAL_CODE }
                              join i in hrDB.SALCODE on a.MLSSALCODE equals i.SAL_CODE
                              join j in hrDB.ROTE on b.ROTE equals j.ROTE1
                              where
                              //a.ADATE >= f.ADATE && a.ADATE <= f.DDATE                              && 
                              a.NOBR == nobr && c.YYMM == yymm
                              orderby a.ADATE
                              select new
                              {
                                  屬性 = d.FLAG == "X" ? "借假沖銷" : c.屬性,
                                  請假日期 = a.ADATE,
                                  假別 = d.H_NAME,
                                  班別 = d.FLAG == "X" ? string.Empty : j.ROTENAME,
                                  請假起 = c.BTIME,
                                  請假迄 = c.ETIME,
                                  請假時數 = c.TOL_HOURS,
                                  單位 = d.UNIT,
                                  扣款金額 = JBModule.Data.CDecryp.Number(a.AMT),
                                  扣薪科目 = g.SAL_NAME,
                                  扣款科目 = i.SAL_NAME
                                  //,                                  科目金額 = JBModule.Data.CDecryp.Number(f.AMT)
                              }).Distinct().ToList();
            
            dataGridView1.DataSource = salabsList.CopyToDataTable();
            this.Text = salabsList.Count().ToString();

            var absSQL = from a in db.ABS
                         join b in db.HCODE on a.H_CODE equals b.H_CODE
                         where a.NOBR == nobr && a.YYMM == yymm
                         && yearrestList.Contains(b.YEAR_REST)
                         select new { ABS = a, HCODE = b };
            label2.Text = "請假共： " + absSQL.Count().ToString() + " 筆";
            var absGP = from a in absSQL
                        group a by new{a.HCODE.H_NAME,a.HCODE.UNIT} into gp
                        select gp;
            label1.Text = "";
            foreach (var itm in absGP)
            {
                if (label1.Text.Trim().Length > 0)
                    label1.Text += "\n";
                label1.Text += itm.Key.H_NAME + "： " + itm.Sum(p => p.ABS.TOL_HOURS) + " " + itm.Key.UNIT;
            }

            label3.Text = "扣款合計： " + salabsList.Sum(p => p.扣款金額).ToString() + " 元";
        }
    }
}
