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
    public partial class FRM2J : JBControls.JBForm
    {
        public FRM2J()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設定這個值來控制當資料重複時，要選擇複寫或是略過
        /// </summary>
        bool RepeatOverWrite = false;

        private void FRM2J_Load(object sender, EventArgs e)
        {
            //this.oTRCDTableAdapter.Fill(this.dsAtt.OTRCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetOtrcd(), true, false, true);
            comboBox1.Enabled = false;
            SystemFunction.SetComboBoxItems(cbxOtDept, CodeFunction.GetDepts(), true, false, true);
            cbxOtDept.Enabled = false;
            SystemFunction.SetComboBoxItems(ptxOtRote, CodeFunction.GetRote(), true, false, true);
            ptxOtRote.Enabled = false;
            this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.oTPRETableAdapter.FillByInit(this.dsAtt.OTPRE);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd(this.Name);

            fullDataCtrl1.DataAdapter = oTPRETableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            txtSugHrs.Enabled = false;
            txtBdate.Text = Sal.Function.GetDate();
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
            }
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                //txtBdate.Focus();
                TimeSet();
                TimeCalc();
            }
        }

        void TimeSet()
        {
            string nobr;
            DateTime d1;
            nobr = ptxNobr.Text;
            d1 = Convert.ToDateTime(txtBdate.Text);
            dcAttDataContext db = new dcAttDataContext();
            var sql = from a in db.ATTEND join r in db.ROTE on a.ROTE equals r.ROTE1 where a.NOBR == nobr && a.ADATE == d1 select r;
            if (sql.Any())
            {
                txtBtime.Text = sql.First().OFF_TIME;
                txtEtime.Text = sql.First().OFF_TIME;
            }
            else
            {
                txtBtime.Text = "0000";
                txtEtime.Text = "0000";
            }
        }
        void TimeCalc()
        {
            string nobr, btime, etime, rote;
            DateTime d1;
            nobr = ptxNobr.Text;
            d1 = Convert.ToDateTime(txtBdate.Text);
            dcAttDataContext db = new dcAttDataContext();
            btime = txtBtime.Text;
            etime = txtEtime.Text;
            rote = ptxOtRote.Text;
            var ot_calc = Dll.Att.OtCal.CalculationOt(nobr, rote, d1, btime, etime);
            txtSugHrs.Text = ot_calc.iTotalHour.ToString();
            txtOtHrs.Text = txtSugHrs.Text;
            txtResHrs.Text = "0";
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtSugHrs.Enabled = false;
        }

        private void txtBdate_Validated(object sender, EventArgs e)
        {
            TimeSet();
            TimeCalc();
        }

        private void txtBtime_Validated(object sender, EventArgs e)
        {
            TimeCalc();
        }

        private void txtEtime_Validated(object sender, EventArgs e)
        {
            TimeCalc();
        }

        private void ptxOtRote_Validated(object sender, EventArgs e)
        {
            TimeCalc();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            DataTable RepeatTable = new DataTable();
            RepeatTable.Columns.Add(new DataColumn("工號",Type.GetType("System.String")));
            RepeatTable.Columns.Add(new DataColumn("姓名", Type.GetType("System.String")));
            RepeatTable.Columns.Add(new DataColumn("加班日期", Type.GetType("System.DateTime")));
            RepeatTable.Columns.Add(new DataColumn("開始時間", Type.GetType("System.String")));
            RepeatTable.Columns.Add(new DataColumn("結束時間", Type.GetType("System.String")));
            DateTime t1, t2;
            t1 = DateTime.Now;
            int total = 0, success = 0, error = 0, repeat = 0, negative = 0;
            var data = from r in dsAtt.OTPRE where r.TRANS == false && r.TRANP == true select r;//只針對還沒轉，且需要轉的資料
            dcAttDataContext dbTran = new dcAttDataContext();
            dcAttDataContext dbDelete = new dcAttDataContext();
            foreach (var row in data)
            {
                total++;
                var otSQL = from r in dbDelete.OT
                            where r.NOBR == row.NOBR && r.BDATE == row.ADATE && r.BTIME == row.BTIME && r.OTRCD == row.OTRCD
                            select r;
                if (row.OT_HRS <= 0)
                {
                    if (row.OT_HRS < 0)
                        negative++;
                    if (row.OT_HRS <= 0 && row.REST_HRS <= 0)
                        continue;
                }

                var absData = JBHR.BLL.Att.OverTime.GetExistsOT(row.NOBR, row.ADATE, row.ADATE, row.BTIME , row.ETIME);

                if (absData.Any())//如果有重複資料
                {
                    DataTable dataTable = absData.Select(p => new { 工號 = p.Nobr, 姓名 = p.NameC, 加班日期 = p.DateB, 開始時間 = p.Btime, 結束時間 = p.Etime }).CopyToDataTable();
                    foreach (DataRow Rprow in dataTable.Rows)
                        RepeatTable.ImportRow(Rprow);

                    //if (RepeatOverWrite)//且設定重複要複寫，則刪除原紀錄
                    //    dbDelete.OT.DeleteAllOnSubmit(otSQL);
                    //else 
                    repeat++;
                    continue;//否則就略過此筆記錄，最後如果
                }
                OT ot = new OT();
                ot.BDATE = row.ADATE;
                ot.BTIME = row.BTIME;
                ot.CANT_ADJ = true;
                ot.DIFF = 0;
                ot.EAT = false;
                ot.ETIME = row.ETIME;
                ot.FIX_AMT = false;
                ot.FOOD_CNT = 0;
                ot.FOOD_PRI = 0;
                ot.FST_HOURS = 0;
                ot.HOT_133 = 0;
                ot.HOT_166 = 0;
                ot.HOT_200 = 0;
                ot.KEY_DATE = DateTime.Now;
                ot.KEY_MAN = MainForm.USER_NAME;
                ot.NOBR = row.NOBR;
                ot.NOFOOD = false;
                ot.NOFOOD1 = false;
                ot.NOP_H_100 = 0;
                ot.NOP_H_133 = 0;
                ot.NOP_H_167 = 0;
                ot.NOP_H_200 = 0;
                ot.NOP_W_100 = 0;
                ot.NOP_W_133 = 0;
                ot.NOP_W_167 = 0;
                ot.NOP_W_200 = 0;
                ot.NOT_EXP = 0;
                ot.NOT_H_133 = 0;
                ot.NOT_H_167 = 0;
                ot.NOT_H_200 = 0;
                ot.NOT_W_100 = 0;
                ot.NOT_W_133 = 0;
                ot.NOT_W_167 = 0;
                ot.NOT_W_200 = 0;
                ot.NOTE = row.NOTE;
                ot.NOTMODI = false;
                ot.OT_CAR = 0;//
                ot.OT_DEPT = row.OT_DEPT;
                ot.OT_EDATE = row.ADATE;
                ot.OT_FOOD = 0;//
                ot.OT_FOOD1 = 0;//
                ot.OT_FOODH = 0;
                ot.OT_FOODH1 = 0;
                ot.OT_HRS = row.OT_HRS;
                ot.OT_ROTE = row.OT_ROTE;
                ot.OTNO = "";
                ot.OTRATE_CODE = "";//
                ot.OTRCD = row.OTRCD;
                ot.REC = 0;
                ot.RES = false;
                ot.REST_EXP = 0;//
                ot.REST_HRS = row.REST_HRS;
                ot.SALARY = 0;
                ot.SER = "";
                ot.SERNO = "";
                ot.SUM = false;//
                ot.SYS_OT = row.SYS_OT;
                ot.SYSCREAT = false;//
                ot.SYSCREAT1 = false;//
                ot.TOP_H_200 = 0;
                ot.TOP_W_100 = 0;
                ot.TOP_W_133 = 0;
                ot.TOP_W_167 = 0;
                ot.TOP_W_200 = 0;
                ot.TOT_EXP = 0;
                ot.TOT_H_200 = 0;
                ot.TOT_HOURS = row.OT_HRS;
                ot.TOT_W_100 = 0;
                ot.TOT_W_133 = 0;
                ot.TOT_W_167 = 0;
                ot.TOT_W_200 = 0;
                ot.WOT_133 = 0;
                ot.WOT_166 = 0;
                ot.WOT_200 = 0;
                ot.YYMM = row.YYMM;
                dbTran.OT.InsertOnSubmit(ot);
                if (ot.REST_HRS > 0)
                {
                    ABS abs = new ABS();
                    abs.NOBR = row.NOBR;
                    abs.BDATE = ot.BDATE;
                    abs.EDATE = new DateTime(ot.BDATE.Year, 12, 31);
                    abs.BTIME = "";
                    abs.ETIME = "";
                    abs.A_NAME = "";
                    abs.H_CODE = "W4";//補休
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    abs.nocalc = false;
                    abs.NOTE = row.NOTE;
                    abs.NOTEDIT = false;
                    abs.SERNO = "";
                    abs.SYSCREATE = true;
                    abs.TOL_DAY = 1;
                    abs.TOL_HOURS = row.REST_HRS;
                    abs.YYMM = row.YYMM;
                    dbTran.ABS.InsertOnSubmit(abs);
                }


                try
                {
                    //先寫入
                    dbTran.SubmitChanges();
                    //在修改旗標
                    row.TRANS = true;
                    oTPRETableAdapter.Update(dsAtt.OTPRE);
                    success++;
                }
                catch//如果錯誤，最後旗標就會是false，代表沒轉或是沒轉成功
                {
                    error++;
                    continue;
                }
            }

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            //string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            if (negative > 0) MessageBox.Show("轉換資料中有" + negative.ToString() + "筆負數資料，請檢察出勤資料是否有誤!!", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            string msg = string.Format(Resources.Sal.TimeSpan + Environment.NewLine + "應轉換" + total.ToString() + "筆資料，實際轉換" + success.ToString() + "筆資料，" + error.ToString() + "筆失敗，" + repeat.ToString() + "筆重複", ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (repeat > 0)
            {
                bool viewchecked = false;
                if (MessageBox.Show("轉換的時段內已有存在的加班資料" + Environment.NewLine + "按確認顯示查詢影響的資料", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
                    viewchecked = true;
                if (viewchecked)
                {
                    Sal.PreviewForm frm = new Sal.PreviewForm();
                    frm.DataTable = RepeatTable;
                    frm.Width = 800;
                    frm.ShowDialog();
                }
            }
        }

        private void btnMultiOperation_Click(object sender, EventArgs e)
        {
            FRM2JBA frm = new FRM2JBA();
            frm.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FRM29R2 _FRM29R2 = new FRM29R2();
            _FRM29R2.ShowDialog();
        }

        //private void btnNoRest_Click(object sender, EventArgs e)
        //{
        //    FRM2JBB frm = new FRM2JBB();
        //    frm.ShowDialog();
        //}
    }
}
