using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM12C : JBControls.JBForm
    {
        public FRM12C()
        {
            InitializeComponent();
        }
        public string Nobr = "";
        public string KeyMan = "";
        public string NewNobr = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            NewNobr = txtNewNobr.Text;
            if (NewNobr.Trim().Length == 0)
            {
                MessageBox.Show("請輸入工號");
                txtNewNobr.Focus();
                return;
            }
            JBModule.Data.Linq.SimpleDBDataContext db = new JBModule.Data.Linq.SimpleDBDataContext();
            var sqlBase = from a in db.BASE where a.NOBR == NewNobr select a;
            var sqlBasetts = from a in db.BASETTS where a.NOBR == NewNobr select a;
            if (sqlBase.Any() || sqlBasetts.Any())
            {
                MessageBox.Show("工號" + NewNobr + "已存在");
                return;
            }

            var sql = from a in db.BASE where a.NOBR == Nobr select a;
            if (sql.Any())
            {
                //人事資料
                var rBase = sql.First().Clone();
                //NewNobr = db.GetNewNobr(rBase.COUNT_MA);
                DateTime dIndt = Convert.ToDateTime(txtInDate.Text);
                rBase.NOBR = NewNobr;
                rBase.KEY_DATE = DateTime.Now;
                rBase.KEY_MAN = KeyMan;
                db.BASE.InsertOnSubmit(rBase);
                //異動資料
                var sql1 = from a in db.BASETTS where a.NOBR == Nobr && DateTime.Now.Date >= a.ADATE && DateTime.Now.Date <= a.DDATE select a;
                if (sql1.Any())
                {
                    var rBasetts = sql1.First().Clone();
                    rBasetts.NOBR = NewNobr;
                    rBasetts.KEY_DATE = DateTime.Now;
                    rBasetts.KEY_MAN = KeyMan;
                    rBasetts.TTSCODE = "1";//到職
                    rBasetts.TTSCD = "01";
                    rBasetts.DDATE = new DateTime(9999, 12, 31);
                    rBasetts.CINDT = dIndt;
                    rBasetts.INDT = dIndt;
                    rBasetts.ADATE = dIndt;
                    rBasetts.OUDT = null;
                    rBasetts.OUTCD = "";
                    rBasetts.STDT = null;
                    rBasetts.STINDT = null;
                    rBasetts.IS_SELFOUT = false;
                    db.BASETTS.InsertOnSubmit(rBasetts);
                }
                if (cbxDetail.Checked)
                {
                    //眷屬資料
                    var sqlFamily = from a in db.FAMILY where a.NOBR == Nobr select a;
                    foreach (var it in sqlFamily)
                    {
                        var faRow = it.Clone();
                        faRow.KEY_DATE = DateTime.Now;
                        faRow.KEY_MAN = MainForm.USER_NAME;
                        faRow.NOBR = NewNobr;
                        db.FAMILY.InsertOnSubmit(faRow);
                    }
                    //學歷
                    var sqlSchl = from a in db.SCHL where a.NOBR == Nobr select a;
                    foreach (var it in sqlSchl)
                    {
                        var cpRow = it.Clone();
                        cpRow.KEY_DATE = DateTime.Now;
                        cpRow.KEY_MAN = MainForm.USER_NAME;
                        cpRow.NOBR = NewNobr;
                        db.SCHL.InsertOnSubmit(cpRow);
                    }
                    //專長興趣
                    var sqlMaster = from a in db.MASTER where a.NOBR == Nobr select a;
                    foreach (var it in sqlMaster)
                    {
                        var cpRow = it.Clone();
                        cpRow.KEY_DATE = DateTime.Now;
                        cpRow.KEY_MAN = MainForm.USER_NAME;
                        cpRow.NOBR = NewNobr;
                        db.MASTER.InsertOnSubmit(cpRow);
                    }
                    //證照
                    var sqlLican = from a in db.LICAN where a.NOBR == Nobr select a;
                    foreach (var it in sqlLican)
                    {
                        var cpRow = it.Clone();
                        cpRow.KEY_DATE = DateTime.Now;
                        cpRow.KEY_MAN = MainForm.USER_NAME;
                        cpRow.NOBR = NewNobr;
                        db.LICAN.InsertOnSubmit(cpRow);
                    }
                    //費用分攤
                    var sqlCost = from a in db.COST where a.NOBR == Nobr select a;
                    foreach (var it in sqlCost)
                    {
                        var cpRow = it.Clone();
                        cpRow.KEY_DATE = DateTime.Now;
                        cpRow.KEY_MAN = MainForm.USER_NAME;
                        cpRow.NOBR = NewNobr;
                        db.COST.InsertOnSubmit(cpRow);
                    }
                    //工作經驗
                    var sqlWorks = from a in db.WORKS where a.NOBR == Nobr select a;
                    foreach (var it in sqlWorks)
                    {
                        var cpRow = it.Clone();
                        cpRow.KEY_DATE = DateTime.Now;
                        cpRow.KEY_MAN = MainForm.USER_NAME;
                        cpRow.NOBR = NewNobr;
                        db.WORKS.InsertOnSubmit(cpRow);
                    }
                    //使用者自定義
                    var sqlUserDefine = from a in db.UserDefine where a.NOBR == Nobr select a;
                    foreach (var it in sqlUserDefine)
                    {
                        var cpRow = it.Clone();
                        cpRow.KEY_DATE = DateTime.Now;
                        cpRow.KEY_MAN = MainForm.USER_NAME;
                        cpRow.NOBR = NewNobr;
                        db.UserDefine.InsertOnSubmit(cpRow);
                    }
                    //自定義欄位
                    var sqlUserDefineValue = from a in db.UserDefineValue where a.Code == Nobr select a;
                    foreach (var it in sqlUserDefineValue)
                    {
                        var cpRow = it.Clone();
                        cpRow.Key_Date = DateTime.Now;
                        cpRow.Key_Man = MainForm.USER_NAME;
                        cpRow.Code = NewNobr;
                        db.UserDefineValue.InsertOnSubmit(cpRow);
                    }
                }
                db.SubmitChanges();
                MessageBox.Show("複製完成!!" + Environment.NewLine + "到新的工號" + NewNobr);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRM12C_Load(object sender, EventArgs e)
        {
            txtInDate.Text = Sal.Function.GetDate();
        }

    }
    //public static class Extender
    //{
    //    public static T Clone<T>(this T source)
    //    {
    //        var dcs = new System.Runtime.Serialization
    //          .DataContractSerializer(typeof(T));
    //        using (var ms = new System.IO.MemoryStream())
    //        {
    //            dcs.WriteObject(ms, source);
    //            ms.Seek(0, System.IO.SeekOrigin.Begin);
    //            return (T)dcs.ReadObject(ms);
    //        }
    //    }
    //}
}
