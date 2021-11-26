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
    public partial class FRM45A : Form
    {
        public string nobr = "600529";
        public DateTime d1 = Convert.ToDateTime("2010-07-01"), d2 = Convert.ToDateTime("2010-07-18");
        public string yymm = "201009";
        public FRM45A()
        {
            InitializeComponent();
        }

        private void FRM45A_Load(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var attendList = (from a in db.ATTEND
                              where (a.NOBR == nobr && a.ADATE >= d1 && a.ADATE <= d2)
                              || (from b in db.ABS where b.NOBR == nobr && b.BDATE == a.ADATE && b.NOBR == a.NOBR && b.YYMM == yymm select b).Any()
                              select a).ToList();
            List<string> yearrestList = new List<string>();
            yearrestList.Add("0");
            yearrestList.Add("2");
            yearrestList.Add("4");
            yearrestList.Add("6");
            var absList = (from a in db.ABS
                           join b in db.HCODE on a.H_CODE equals b.H_CODE
                           where a.NOBR == nobr && a.YYMM == yymm
                           && yearrestList.Contains(b.YEAR_REST)
                           select new { a.NOBR, b.H_NAME, a.BDATE, a.BTIME, a.ETIME, a.TOL_HOURS, b.UNIT }).ToList();

            var salabsList1 = (from a in db.SALABS where a.NOBR == nobr && a.YYMM == yymm && a.MLSSALCODE == MainForm.OvertimeConfig.OTFOODSALCODE select a);
            var salabsList2 = (from a in db.SALABS where a.NOBR == nobr && a.YYMM == yymm && a.MLSSALCODE == MainForm.SalaryConfig.EMPSALCODE select a);
            var salabsList3 = (from a in db.SALABS where a.NOBR == nobr && a.YYMM == yymm && a.MLSSALCODE == MainForm.SalaryConfig.ONDUTYSALCODE select a);

            var sql = from a in attendList
                      join f in db.ROTE.ToList() on a.ROTE equals f.ROTE1
                      join g in salabsList1 on new { a.NOBR, a.ADATE.Date } equals new { g.NOBR, g.ADATE.Date } into ag
                      from nig_salabs in ag.DefaultIfEmpty()
                      join h in salabsList2 on new { a.NOBR, a.ADATE.Date } equals new { h.NOBR, h.ADATE.Date } into ah
                      from food_salabs in ah.DefaultIfEmpty()
                      join i in salabsList3 on new { a.NOBR, a.ADATE.Date } equals new { i.NOBR, i.ADATE.Date } into ai
                      from spec_salabs in ah.DefaultIfEmpty()
                      let abs = absList.Where(p => p.BDATE == a.ADATE)
                      let nig_amt = ag.Any() ? ag.Sum(p => JBModule.Data.CDecryp.Number(p.AMT)) : 0
                      let spec_amt = ag.Any() ? ai.Sum(p => JBModule.Data.CDecryp.Number(p.AMT)) : 0
                      let station_amt = ah.Any() ? ah.Sum(p => JBModule.Data.CDecryp.Number(p.AMT)) : 0
                      let nigamt = (a.ADATE >= d1 && a.ADATE <= d2) ? a.NIGAMT : 0//如果在這個出勤區間內才顯示金額
                      let foodamt = (a.ADATE >= d1 && a.ADATE <= d2) ? a.FOODAMT : 0
                      let specdamt = (a.ADATE >= d1 && a.ADATE <= d2) ? a.SPECAMT : 0
                      //where a.NOBR == nobr && a.ADATE >= d1 && a.ADATE <= d2
                      //&& ag.Any() && food_salabs.SAL_CODE == Sal.Core.SysVar.SalaryVar.EATSALCODE && nig_salabs.SAL_CODE == Sal.Core.SysVar.OtVar.OTFOODSALCODE
                      select new
                      {
                          //工號 = a.NOBR,//只會算一個人，所以不用看工號跟姓名
                          出勤日期 = a.ADATE,
                          班別 = a.ROTE,
                          班別名稱 = f.ROTENAME,
                          交通津貼 = (nigamt - nig_amt) == 0 ? "0" : (nigamt - nig_amt).ToString(),
                          //加班津貼 = specdamt > 0 && (specdamt - spec_amt) == 0 ? "" : (specdamt - spec_amt).ToString(),//避免與月薪人員影響
                          夜間津貼 = foodamt.ToString(),
                          請假 = abs.Count() > 1 ? abs.Count().ToString() + "筆請假" : abs.Any() ? abs.First().H_NAME : "",
                          請假時數 = abs.Count() > 0 ? abs.Sum(p => p.TOL_HOURS) : 0
                      };
            sql = sql.Distinct();

            var Sql = from sa in db.SALATT
                      join att in db.ATTEND on new { sa.NOBR, sa.ADATE } equals new { att.NOBR, att.ADATE }
                      join attc in db.ATTCARD on new { sa.NOBR, sa.ADATE } equals new { attc.NOBR, attc.ADATE }
                      into ac from attc in ac.DefaultIfEmpty()
                      join rt in db.ROTE on sa.ROTE equals rt.ROTE1
                      join sc in db.SALCODE on sa.SAL_CODE equals sc.SAL_CODE
                      where sa.ADATE >= d1 && sa.ADATE <= d2 && sa.AMT > 0 && sa.NOBR == nobr
                      orderby sa.SAL_CODE
                      select new
                      {
                          津貼代碼 = sc.SAL_CODE_DISP,
                          津貼名稱 = sc.SAL_NAME,
                          出勤日 = sa.ADATE,
                          班別 = rt.ROTE_DISP,
                          班別名稱 = rt.ROTENAME,
                          金額 = sa.AMT,
                          刷卡時間起 = attc.T1,
                          刷卡時間迄 = attc.T2,
                          出勤時間 = att.ATT_HRS
                      };
            var SqlDetal = Sql.GroupBy(p => new { p.津貼代碼, p.津貼名稱, p.出勤日, p.班別, p.班別名稱, p.刷卡時間起, p.刷卡時間迄, p.出勤時間 }).
                            Select(x => new { x.Key.津貼代碼, x.Key.津貼名稱, x.Key.出勤日, 金額 = x.Sum(y => y.金額), x.Key.班別, x.Key.班別名稱, x.Key.刷卡時間起, x.Key.刷卡時間迄, x.Key.出勤時間 }).ToList();
            var SCSumsql = SqlDetal.GroupBy(p => new { p.津貼代碼, p.津貼名稱 }).Select(x => new { x.Key.津貼名稱, 總金額 = x.Sum(y => y.金額) }).ToList();
            dataGridView1.DataSource = SqlDetal.CopyToDataTable();
            this.Text = "共有" + SqlDetal.Count().ToString() + "筆資料";
            TimeSpan ts = d2 - d1;
            label1.Text = "出勤區間： "
                + d1.ToString("yyyy/MM/dd") + " ~ " + d2.ToString("yyyy/MM/dd")
                + " 共計 " + Convert.ToInt32(ts.TotalDays + 1).ToString() + " 天";
            //label2.Text = "交通津貼總計： " + sql.Sum(p => Convert.ToDecimal(p.交通津貼.Trim().Length == 0 ? "0" : p.交通津貼)).ToString() + " 元";
            //label3.Text = "夜間津貼總計： " + sql.Sum(p => Convert.ToDecimal(p.夜間津貼.Trim().Length == 0 ? "0" : p.夜間津貼)).ToString() + " 元";
            label4.Text = "請假時數總計： " + sql.Sum(p => p.請假時數).ToString() + " 小時";
            label6.Text = "實際出勤天數： " + attendList.Count().ToString() + " 天";
            //lblAmtOfHrs.Text = "加班津貼總計：" + sql.Sum(p => Convert.ToDecimal(p.加班津貼.Trim().Length == 0 ? "0" : p.加班津貼)).ToString() + " 元";

            var absGP = from a in absList group a by new { a.H_NAME, a.UNIT } into gp select gp;
            //label5.Text = "";

            Label Ll;
            foreach (var itm in absGP)
            {
                //if (label5.Text.Trim().Length > 0) label5.Text += "\n";
                //label5.Text += itm.Key.H_NAME + ":" + itm.Sum(p => p.TOL_HOURS) + itm.Key.UNIT;
                Ll = new Label();
                Ll.Anchor = AnchorStyles.None;
                Ll.AutoSize = true;
                Ll.ForeColor = SystemColors.ControlText;
                Ll.Size = new Size(80, 18);
                Ll.Text = string.Format("{0}總計 : {1} {2}", itm.Key.H_NAME, itm.Sum(p => p.TOL_HOURS), itm.Key.UNIT);
                flowLayoutPanel1.Controls.Add(Ll);
                Ll.Dock = DockStyle.None;
            }
 
            foreach (var item in SCSumsql)
            {
                Ll = new Label();
                Ll.Anchor = AnchorStyles.None;
                Ll.AutoSize = true;
                Ll.ForeColor = SystemColors.ControlText;
                Ll.Size = new Size(80, 18);
                Ll.Text = string.Format("{0}總計 : {1} 元" ,item.津貼名稱,item.總金額);
                flowLayoutPanel1.Controls.Add(Ll);
                Ll.Dock = DockStyle.None;
            }

        }
    }
}
