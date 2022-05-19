using JBHR.Att.Attendance;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM2A : JBControls.JBForm
    {
        public FRM2A()
        {
            InitializeComponent();
        }
        dcAttDataContext db = new dcAttDataContext();
        DateTime bDate, eDate;
        List<string> holi_codeList = CodeFunction.GetHolidayRoteList();
        private void FRM2A_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'extDS.ROTE' 資料表。您可以視需要進行移動或移除。
            this.rOTETableAdapter1.Fill(this.extDS.ROTE);
            SystemFunction.SetComboBoxItems(cbxRote, CodeFunction.GetRote(), true, false, true);
            cbxRote.Enabled = false;
            //this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.rOTECHGTableAdapter.FillByInit(this.dsAtt.ROTECHG);

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
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("rotechg");

            fullDataCtrl1.DataAdapter = rOTECHGTableAdapter; ;
            fullDataCtrl1.Init_Ctrls();

            chkNoTran.Enabled = false;
            txtEdate.Enabled = false;
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            chkNoTran.Enabled = true;
            txtEdate.Enabled = true;
            txtBdate.Text = Sal.Core.SalaryDate.DateString();
            txtEdate.Text = Sal.Core.SalaryDate.DateString();
            ptxNobr.Focus();
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
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
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                chkNoTran.Enabled = false;
                txtEdate.Enabled = false;
                string keyman = e.Values["KEY_MAN"].ToString();
                DateTime keydate = Convert.ToDateTime(e.Values["KEY_DATE"]);
                DateTime d1 = bDate;
                DateTime d2 = eDate;
                string Nobr= e.Values["nobr"].ToString();
                for (DateTime dd = d1.AddDays(1); dd <= d2; dd = dd.AddDays(1))
                {
                    if (chkNoTran.Checked)
                    {//假日就跳過
                        var rote = (from a in db.ATTEND where a.NOBR == Nobr && a.ADATE == dd select a.ROTE).FirstOrDefault();
                        if (rote != null && holi_codeList.Contains(rote)) continue;
                    } 
                    dsAtt.ROTECHGRow r = dsAtt.ROTECHG.NewROTECHGRow();
                    r.ADATE = dd;
                    r.CODE = "";
                    r.KEY_DATE = keydate;
                    r.KEY_MAN = keyman;
                    r.NOBR = Nobr;
                    r.ROTE = e.Values["rote"].ToString();
                    this.dsAtt.ROTECHG.AddROTECHGRow(r);
                }
                this.rOTECHGTableAdapter.Update(dsAtt.ROTECHG);

            }
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
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            bDate = Convert.ToDateTime(txtBdate.Text);
            eDate = Convert.ToDateTime(txtEdate.Text);
            if (eDate < bDate)
            {
                MessageBox.Show("調班迄日期不可小於調班起日期", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                var sql = from r in db.ROTECHG where r.NOBR == ptxNobr.Text && r.ADATE >= bDate && r.ADATE <= eDate select r;
                if (sql.Any())
                {
                    string msg = string.Format(Resources.Att.RotechgExists, sql.Count());
                    MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }

            if (!e.Cancel)
            {
                string Nobr = ptxNobr.Text;
                DateTime DT1 = Convert.ToDateTime(txtBdate.Text);
                DateTime DT2 = Convert.ToDateTime(txtEdate.Text);

                string RT = cbxRote.SelectedValue.ToString();
                WorkScheduleCheckGenerator WSCG = new WorkScheduleCheckGenerator(Nobr, DT1.AddDays(-7), DT1, DT2.AddDays(7));

                var RoteCHG = db.ROTECHG.Where(p=>p.NOBR == Nobr && (p.ADATE >= DT1.AddDays(-7) || p.ADATE <= DT2.AddDays(7))).ToList();
                foreach (var item in RoteCHG)
                {
                    if (WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == item.ADATE).Any())
                        WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == item.ADATE).First().ScheduleType = item.ROTE;
                    else
                        WSCG.WSCD.WorkSchedules.Add(WorkScheduleCheckGenerator.NewWSD(item.ADATE, RT));
                }

                for (DateTime dd = DT1; dd <= DT2; dd = dd.AddDays(1))
                {
                    if (chkNoTran.Checked)
                    {//假日就跳過
                        var rote = (from a in db.ATTEND where a.NOBR == Nobr && a.ADATE == dd select a.ROTE).FirstOrDefault();
                        if (rote != null && holi_codeList.Contains(rote)) continue;
                    }

                    if (WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == dd).Any())
                        WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == dd).First().ScheduleType = RT;
                    else
                        WSCG.WSCD.WorkSchedules.Add(WorkScheduleCheckGenerator.NewWSD(dd, RT));
                }
                WSCG.WSCE.CheckTypes.Add("CIT");
                WSCG.WSCE.CheckTypes.Add("CW7");
                var result = WSCG.Check();
                if (result.workScheduleIssues.Count > 0)
                {
                    JBControls.ShowList showList = new JBControls.ShowList(result.workScheduleIssues.Select(p => new { 異常日期 = p.IssueDate, 異常敘述 = p.ErrorMessage }).CopyToDataTable());
                    showList.Text = "異常";
                    showList.StartPosition = FormStartPosition.CenterScreen;
                    showList.Show();
                    e.Cancel = true;
                } 
            }

            if (!e.Cancel)
            {
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
            }
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData) chkNoTran.Focus();
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            chkNoTran.Enabled = false;
            txtEdate.Enabled = false;
        }

        private void txtBdate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                DateTime d1, d2;
                d1 = Convert.ToDateTime(txtBdate.Text);
                d2 = Convert.ToDateTime(txtEdate.Text);
                string Nobr = ptxNobr.Text;
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from bts in db.BASETTS
                          where bts.NOBR == Nobr
                          && bts.INDT.Value.CompareTo(d1) <= 0
                          select bts;
                if (!sql.Any())
                {
                    MessageBox.Show("調班起始日不可在入職日之前");
                    txtBdate.Text = Sal.Core.SalaryDate.DateString(db.BASETTS.Where(p => p.NOBR == Nobr).First().INDT.Value);
                }
                if (d2 < d1) 
                    txtEdate.Text = Sal.Core.SalaryDate.DateString(d1);
            }
            catch { }
        }

        private void txtBdate_Validated(object sender, EventArgs e)
        {
            //CheckExists();
        }
        void CheckExists()
        {
            var sql = from r in db.ROTECHG where r.NOBR == ptxNobr.Text && r.ADATE >= Convert.ToDateTime(txtBdate.Text) && r.ADATE <= Convert.ToDateTime(txtEdate.Text) select r;
            if (sql.Any())
            {
                string msg = string.Format(Resources.Att.RotechgExists, sql.Count());
                MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void txtEdate_Validated(object sender, EventArgs e)
        {
            //CheckExists();
        }
        void ReGenRote(string nobr,DateTime date)
        {
            var sql = from r in db.ROTECHG
                      where r.NOBR == ptxNobr.Text && r.ADATE >= Convert.ToDateTime(txtBdate.Text)
                      && r.ADATE <= Convert.ToDateTime(txtEdate.Text) select r;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtEdate.Text = txtBdate.Text;
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtBdate.Enabled = false;
        }

        private void bnCreateExcel_Click(object sender, EventArgs e)
        {
            //建立Excel 2003檔案
            IWorkbook wb = new HSSFWorkbook();
            ISheet ws = wb.CreateSheet("Class");

            ////建立Excel 2007檔案
            //IWorkbook wb = new XSSFWorkbook();
            //ISheet ws = wb.CreateSheet("Class");

            ws.CreateRow(0);//第一行為欄位名稱
            ws.GetRow(0).CreateCell(0).SetCellValue("員工編號");    //NOBR
            ws.GetRow(0).CreateCell(1).SetCellValue("調班日期");    //ADATE
            ws.GetRow(0).CreateCell(2).SetCellValue("班別");        //NORE


            string path = @"C:\temp\調班資料_樣板.xls";
            FileStream file = new FileStream(path, FileMode.Create);//產生檔案
            wb.Write(file);
            file.Close();
            MessageBox.Show("檔案儲存位址： " + path, "訊息");
        }

        private void bnImport_Click(object sender, EventArgs e)
        {
            FRM2A1 frm2a1 = new FRM2A1();
            frm2a1.ShowDialog();
        }
    }
}
