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
    public partial class FRM45B : Form
    {
        public FRM45B()
        {
            InitializeComponent();
        }
        public string nobr, yymm;
        private void FRM45B_Load(object sender, EventArgs e)
        {
            SalaryMDDataContext db = new SalaryMDDataContext();
            var otList = (from a in db.OT
                          join b in db.ATTEND on new { a.NOBR, a.BDATE.Date } equals new { b.NOBR, b.ADATE.Date }
                          join c in db.tblROTE on b.ROTE equals c.ROTE1 into r1
                          from rote in r1.DefaultIfEmpty()
                          join d in db.tblROTE on a.OT_ROTE equals d.ROTE1 into r2
                          from ot_rote in r2.DefaultIfEmpty()
                          join f in db.OTRCD on a.OTRCD equals f.OTRCD1 into otr
                          from otrcd in otr.DefaultIfEmpty()
                          let isHoli =CodeFunction.GetHolidayRoteList().Contains( b.ROTE) || a.SYS_OT
                          where a.NOBR == nobr && a.YYMM == yymm
                          select new
                          {
                              加班日期 = a.BDATE,
                              加班起 = a.BTIME,
                              加班迄 = a.ETIME,
                              出勤班別 = rote != null ? rote.ROTENAME : "",
                              加班班別 = ot_rote != null ? ot_rote.ROTENAME : "",
                              加班時數 = a.OT_HRS,
                              補休時數 = a.REST_HRS,
                              加班原因 = otrcd != null ? otrcd.OTRNAME : "",
                              薪資 = JBModule.Data.CDecryp.Number(a.SALARY),
                              備註 = a.NOTE,
                              免稅加班費 = JBModule.Data.CDecryp.Number(a.NOT_EXP),
                              應稅加班費 = JBModule.Data.CDecryp.Number(a.TOT_EXP),
                              加班別 = isHoli ? "假日" : "平日",
                              輪班津貼 = JBModule.Data.CDecryp.Number(a.OT_FOOD),
                              誤餐費 = a.OT_FOOD1,
                              CallIn津貼 = JBModule.Data.CDecryp.Number(a.OT_CAR)
                          }).ToList();

            var ot = from a in otList
                     select new
                            {
                                a.加班日期,
                                a.加班起,
                                a.加班迄,
                                a.出勤班別,
                                a.加班班別,
                                加班時數 = a.加班時數 > 0 ? a.加班時數.ToString() : "",
                                補休時數 = a.補休時數 > 0 ? a.補休時數.ToString() : "",
                                a.加班原因,
                                a.薪資,
                                a.備註,
                                免稅加班費 = a.免稅加班費 > 0 ? a.免稅加班費.ToString() : "",
                                應稅加班費 = a.應稅加班費 > 0 ? a.應稅加班費.ToString() : "",
                                a.加班別,
                                a.輪班津貼,
                                a.誤餐費,
                                a.CallIn津貼
                            };
            dataGridView1.DataSource = ot.CopyToDataTable();
            this.Text = "加班共計 " + ot.Count().ToString() + " 筆";
            label1.Text = "加班共計 " + ot.Count().ToString() + " 筆";
            label2.Text = "免稅加班費合計： " + otList.Sum(p => p.免稅加班費).ToString() + " 元";
            label3.Text = "應稅加班費合計： " + otList.Sum(p => p.應稅加班費).ToString() + " 元";
            label4.Text = "平日加班費合計： " + otList.Where(p => p.加班別 != "假日").Sum(p => p.應稅加班費 + p.免稅加班費).ToString() + " 元";
            label5.Text = "假日加班費合計： " + otList.Where(p => p.加班別 == "假日").Sum(p => p.應稅加班費 + p.免稅加班費).ToString() + " 元";
            label6.Text = "輪班津貼合計： " + otList.Sum(p => p.輪班津貼).ToString() + " 元";
            label7.Text = "誤餐費合計： " + otList.Sum(p => p.誤餐費).ToString() + " 元";
            label8.Text = "CallIn津貼合計： " + otList.Sum(p => p.CallIn津貼).ToString() + " 元";
            label9.Text = "平日加班時數合計： " + otList.Where(p => p.加班別 != "假日").Sum(p => p.加班時數).ToString() + " 小時";
            label10.Text = "假日加班時數合計： " + otList.Where(p => p.加班別 == "假日").Sum(p => p.加班時數).ToString() + " 小時";
        }
    }
}
