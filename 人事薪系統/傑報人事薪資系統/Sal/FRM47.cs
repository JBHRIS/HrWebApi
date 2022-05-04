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
    public partial class FRM47 : JBControls.JBForm
    {
        SalaryMDDataContext smd = new SalaryMDDataContext();
        public FRM47()
        {
            InitializeComponent();
        }

        private void FRM47_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetDepts(), true, false, true);
            comboBox1.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox2, CodeFunction.GetOtrcd(), true, false, true);
            comboBox2.Enabled = false;
            SystemFunction.SetComboBoxItems(cbxOtRateCD, CodeFunction.GetOtRatecd(), true, false, true);
            this.oTTableAdapter.FillByInit(this.salaryDS.FRM47);
            this.rOTETableAdapter.Fill(this.attendDS.ROTE);
            this.oTRCDTableAdapter.Fill(this.attendDS.OTRCD);
            //this.dEPTTableAdapter.Fill(this.baseDS.DEPT);
            this.dEPTTableAdapter1.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTSTableAdapter.Fill(this.basDS.DEPTS, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);


            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            Sal.Function.SetAvaliableBase(this.salaryDS.BASE);
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("FRM47");

            fullDataCtrl1.DataAdapter = this.oTTableAdapter;
            FullDataControlSet();
            fullDataCtrl1.Init_Ctrls();
        }
        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
        }
        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)//發生錯誤就略過
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);

        }
        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                e.Values["kEy_MaN"] = MainForm.USER_NAME;
                e.Values["KeY_dAtE"] = DateTime.Now;
                e.Values["not_exp"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["not_exp"]));
                e.Values["tot_exp"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["tot_exp"]));
                e.Values["salary"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["salary"]));
                e.Values["ot_food"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["ot_food"]));
                e.Values["ot_car"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["ot_car"]));
            }
        }
        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            e.Values["not_exp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["not_exp"]));
            e.Values["tot_exp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["tot_exp"]));
            e.Values["salary"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["salary"]));
            e.Values["ot_food"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["ot_food"]));
            e.Values["ot_car"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["ot_car"]));
            if (!e.Error)//發生錯誤就略過
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                this.salaryDS.OT.AcceptChanges();
            }
        }
        void fdc_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
            checkBox2.Enabled = false;
        }

        /// <summary>
        /// 匯出後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
        /// <summary>
        /// 查詢後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }

        void GridBind()
        {
            foreach (var itm in this.salaryDS.FRM47)
            {
                if (itm.TOT_EXP != 0)
                    itm.TOT_EXP = JBModule.Data.CDecryp.Number(itm.TOT_EXP);
                if (itm.NOT_EXP != 0)
                    itm.NOT_EXP = JBModule.Data.CDecryp.Number(itm.NOT_EXP);
                if (itm.SALARY != 0)
                    itm.SALARY = JBModule.Data.CDecryp.Number(itm.SALARY);
                if (itm.OT_FOOD != 0)
                    itm.OT_FOOD = JBModule.Data.CDecryp.Number(itm.OT_FOOD);
                //if (itm.OT_FOOD1 != 0)
                //    itm.OT_FOOD1 = JBModule.Data.CDecryp.Number(itm.OT_FOOD1);
                if (itm.OT_CAR != 0)
                    itm.OT_CAR = JBModule.Data.CDecryp.Number(itm.OT_CAR);

            }
            this.salaryDS.OT.AcceptChanges();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value.ToString().Length > 0)
            {
                ShowAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text));
                var ot = (dataGridView1.CurrentRow.DataBoundItem as System.Data.DataRowView).Row as SalaryDS.FRM47Row;
                if (ot != null)
                    ShowOtrateCD(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text), ot.OT_ROTE, ot.OTRATE_CODE);
            }
        }
        void FullDataControlSet()
        {
            fullDataCtrl1.bnAddEnable = false;
            fullDataCtrl1.bnDelEnable = false;
            fullDataCtrl1.Init_Ctrls();
        }
        void ShowOtrateCD(string nobr, DateTime adate, string OtRote, string otratecd)
        {
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from a in db.BASETTS where a.NOBR == nobr && adate >= a.ADATE && adate <= a.DDATE.Value select a;
                if (sql.Any())
                {
                    string OTRATE_CODE = sql.First().CALOT;
                    var sqlAtt = from a in db.ATTEND
                                 where a.NOBR == nobr && adate == a.ADATE
                                 select a;
                    if (sqlAtt.Any())
                    {
                        var sqlHol = from a in db.HOL_DAY where a.ROTE == OtRote && adate == a.ADATE && a.HOLI_CODE == sql.First().HOLI_CODE select a;
                        if (sqlHol.Any() && !sql.First().BASE.COUNT_MA)//如果有設定其他加班比率
                            OTRATE_CODE = sqlHol.First().OTRATECD.Trim();
                        if (otratecd.Trim().Length > 0)//如果加班資料上面有指定
                            OTRATE_CODE = otratecd.Trim();
                    }

                    cbxOtRateCD.SelectedValue = OTRATE_CODE;
                }
                //else
                //{
                //    cbxOtRateCD.SelectedValue = "";
                //}
            }
            catch { }
        }
        void ShowAttend(string nobr, DateTime adate)
        {
            try
            {
                Att.dcViewDataContext dv = new JBHR.Att.dcViewDataContext();
                var sql = from ac in dv.V_FRM26 where ac.NOBR == nobr && ac.ADATE == adate select ac;
                this.dsAtt.ATTCARD.Clear();
                this.dsAtt.ATTCARD.FillData(dv.GetCommand(sql));

                var sql1 = from ac in smd.V_FRM27 where ac.NOBR == nobr && ac.ADATE == adate select ac;
                if (sql1.Any()) ptxRote.Text = sql1.First().ROTE;
                else
                {
                    ptxRote.Text = "";
                    //MessageBox.Show(Resources.Att.AttendNoFound, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch { }
        }

        private void txtBdate_Validated(object sender, EventArgs e)
        {
            //ShowAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            label27.Text = Function.ColumnsSum(dataGridView1, e.ColumnIndex);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            var data = from a in salaryDS.FRM47
                       group a by a.DEPT_NAME into gp
                       select new
                       {
                           編制部門 = gp.Key,
                           平日加班時數 = gp.Where(p => p.isHoli != 1).Sum(p => p.OT_HRS),
                           假日加班時數 = gp.Where(p => p.isHoli == 1).Sum(p => p.OT_HRS),
                           平日轉補休時數 = gp.Where(p => p.isHoli != 1).Sum(p => p.REST_HRS),
                           假日轉補休時數 = gp.Where(p => p.isHoli == 1).Sum(p => p.REST_HRS),
                           平日加班費 = gp.Where(p => p.isHoli != 1).Sum(p => p.NOT_EXP + p.TOT_EXP),
                           假日加班費 = gp.Where(p => p.isHoli == 1).Sum(p => p.NOT_EXP + p.TOT_EXP)

                       };

            PreviewForm frm = new PreviewForm();
            frm.DataTable = data.CopyToDataTable();
            frm.Width = 700;
            frm.Height = 600;
            frm.ShowDialog();
        }

        private void btnReport1_Click(object sender, EventArgs e)
        {
            var data = from a in salaryDS.FRM47
                       group a by a.DEPTS_NAME into gp
                       select new
                       {
                           成本部門 = gp.Key,
                           平日加班時數 = gp.Where(p => p.isHoli != 1).Sum(p => p.OT_HRS),
                           假日加班時數 = gp.Where(p => p.isHoli == 1).Sum(p => p.OT_HRS),
                           平日轉補休時數 = gp.Where(p => p.isHoli != 1).Sum(p => p.REST_HRS),
                           假日轉補休時數 = gp.Where(p => p.isHoli == 1).Sum(p => p.REST_HRS),
                           平日加班費 = gp.Where(p => p.isHoli != 1).Sum(p => p.NOT_EXP + p.TOT_EXP),
                           假日加班費 = gp.Where(p => p.isHoli == 1).Sum(p => p.NOT_EXP + p.TOT_EXP)

                       };

            PreviewForm frm = new PreviewForm();
            frm.DataTable = data.CopyToDataTable();
            frm.Width = 700;
            frm.Height = 600;
            frm.ShowDialog();
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
        }
    }
}
