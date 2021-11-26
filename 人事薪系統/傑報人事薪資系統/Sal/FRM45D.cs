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
    public partial class FRM45D : Form
    {
        public FRM45D()
        {
            InitializeComponent();
        }
        public string nobr;
        public string yymm;
        public DateTime d1, d2;
        private void FRM45D_Load(object sender, EventArgs e)
        {
            Sal.Core.SalaryDate sd = new JBHR.Sal.Core.SalaryDate(yymm);
            d1 = sd.FirstDayOfMonth;
            d2 = sd.LastDayOfMonth;
            SalaryMDDataContext db = new SalaryMDDataContext();
            CodeMDDataContext db1 = new CodeMDDataContext();

            var inslabList = (from a in db.INSLAB
                              join b in db.BASE on a.NOBR equals b.NOBR
                              //join c in db.LARCODE on a.LRATE_CODE equals c.RATE_CODE
                              where a.NOBR == nobr && a.IN_DATE <= d2 && a.OUT_DATE >= d1
                              select new { INSLAB = a, BASE = b }).ToList();
            var harcodeList = (from a in db1.HARCODE select a).ToList();
            var larcodeList = (from a in db1.LARCODE select a).ToList();
            //select new { 姓名 = b.NAME_C, 工號 = a.NOBR, 加保日期 = a.IN_DATE, 退保日期 = a.OUT_DATE, 勞保投保金額 = JBModule.Data.CDecryp.Number(a.L_AMT),勞保身分別=, 健保投保金額 = JBModule.Data.CDecryp.Number(a.H_AMT), 勞退投保金額 = JBModule.Data.CDecryp.Number(a.R_AMT) };
            var joinList = from a in inslabList
                           join b in larcodeList on a.INSLAB.LRATE_CODE.Trim() equals b.RATE_CODE.Trim() into ab
                           from lab in ab.DefaultIfEmpty()
                           join c in harcodeList on a.INSLAB.HRATE_CODE.Trim() equals c.RATE_CODE.Trim() into ac
                           from hea in ac.DefaultIfEmpty()
                           select new
                           {
                               加保日期 = a.INSLAB.IN_DATE,
                               退保日期 = a.INSLAB.OUT_DATE,
                               勞保投保金額 = JBModule.Data.CDecryp.Number(a.INSLAB.L_AMT),
                               勞保身分別 = lab != null ? lab.RATE_NAME : "",
                               健保投保金額 = JBModule.Data.CDecryp.Number(a.INSLAB.H_AMT),
                               健保身分別 = hea != null ? hea.RATE_NAME : "",
                               勞退投保金額 = JBModule.Data.CDecryp.Number(a.INSLAB.R_AMT)
                           };
            dataGridView1.DataSource = joinList.CopyToDataTable();

            var explabList = (from a in db.EXPLAB
                              where a.NOBR == nobr && a.YYMM == yymm
                              select a).ToList();
            var insurType = (from a in db1.INSUR_TYPE select a).ToList();
            Dictionary<int, string> inscdList = new Dictionary<int, string>();
            inscdList.Add(0, "整月在保");
            inscdList.Add(1, "當月到離");
            inscdList.Add(2, "月中投保，月底退保");
            inscdList.Add(3, "當月到離");
            inscdList.Add(4, "整月在保");
            var expJoinList = from a in explabList
                              join b in insurType on a.INSUR_TYPE.Trim() equals b.CODE.Trim()
                              join c in inscdList on a.INSCD equals c.Key
                              orderby b.NAME
                              select new
                              {
                                  類型 = b.NAME,
                                  個人負擔 = JBModule.Data.CDecryp.Number(a.EXP),
                                  公司負擔 = JBModule.Data.CDecryp.Number(a.COMP),
                                  眷屬身號 = a.FA_IDNO,
                                  天數 = a.DAYS,
                                  投保狀況 = c.Value
                              };

            dataGridView2.DataSource = expJoinList.CopyToDataTable();
        }
    }
}
