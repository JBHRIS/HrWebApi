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
    public partial class FRM24F : JBControls.JBForm
    {
        public FRM24F()
        {
            InitializeComponent();
        }

        private void FRM24F_Load(object sender, EventArgs e)
        {
            // TODO:  这行程序代码会将数据加载 'dsAtt.FOOD_CARD' 数据表。您可以视需要进行移动或移除。
            this.fOOD_CARDTableAdapter.FillByInit(this.dsAtt.FOOD_CARD);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }

            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            fdc.WhereCmd = Sal.Function.GetFilterCmd("FOOD_CARD");

            fdc.DataAdapter = fOOD_CARDTableAdapter;
            fdc.Init_Ctrls();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.ValidateTimeStringFormat(txtOntime.Text))//判断时间格式
            {
                e.Cancel = true;
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtTemperature.Text))//判斷時間格式
            {
                string result = txtTemperature.Text.Trim();
                decimal x = 0;
                if (!decimal.TryParse(result, out x))
                {
                    MessageBox.Show("體溫輸入非數值格式.", "格式轉換失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    txtTemperature.Focus();
                    return;
                }
            }

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

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
                if (!string.IsNullOrWhiteSpace(e.Values["temperature"].ToString()))
                {
                    int hours = int.Parse(e.Values["ONTIME"].ToString().Substring(0, 2));
                    int mins = int.Parse(e.Values["ONTIME"].ToString().Substring(2, 2));
                    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                    JBModule.Data.Linq.TemperoturyReport temperoturyReport = new JBModule.Data.Linq.TemperoturyReport()
                    {
                        EmployeeId = e.Values["NOBR"].ToString(),
                        AttendDate = DateTime.Parse(e.Values["ADATE"].ToString()).AddHours(hours).AddMinutes(mins),
                        Description = "FRM24F",
                        Guid = Guid.NewGuid(),
                        KeyMan = MainForm.USER_ID,
                        KeyDate = DateTime.Now,
                        ReportType = string.Empty,
                        Temperotury = decimal.Parse(e.Values["temperature"].ToString()),
                    };
                    db.TemperoturyReport.InsertOnSubmit(temperoturyReport);
                    db.SubmitChanges();
                }
            }
        }

        private void fdc_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData)
            //    txtAdate.Focus();
        }

        private void fdc_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }



        private void txtOntime_Validating(object sender, CancelEventArgs e)
        {
            if (!Sal.Function.ValidateTimeStringFormat(txtOntime.Text))
            {
                errorProvider.SetError((Control)sender, Resources.Att.InputFormatNotCorrect);
            }
        }

        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //int index = dgv.CurrentCell.RowIndex;
            //string nobr = dgv.Rows[index].Cells["nOBRDataGridViewTextBoxColumn"].Value.ToString();
            //MDIChildShow(nobr);

        }
        //void MDIChildShow(string NOBR)
        //{
        //    Bas.FRM12 frm12 = null;
        //    foreach (var it in this.MdiParent.MdiChildren)
        //    {
        //        if (it is Bas.FRM12)
        //        {
        //            frm12 = it as Bas.FRM12;
        //            //frm12.Hide();
        //        }
        //    }
        //    if (frm12 == null)
        //    {
        //        frm12 = new Bas.FRM12();
        //        frm12.Text = "FRM12-员工数据";
        //        frm12.MdiParent = this.MdiParent;
        //    }

        //    frm12.Show();
        //    frm12.bnQuery_Click(null, null);
        //    frm12.textBoxNOBR.Text = NOBR;
        //    frm12.popupTextBox1_QueryCompleted(NOBR, null);
        //}

        private void btnImportCard_Click(object sender, EventArgs e)
        {
            FRM24FD frm24fd  = new FRM24FD();
            frm24fd.Icon = this.Icon;
            frm24fd.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM24FA frm24fa = new FRM24FA();
            frm24fa.Icon = this.Icon;
            frm24fa.ShowDialog();
        }
    }
}

