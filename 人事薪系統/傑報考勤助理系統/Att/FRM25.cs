using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace JBHR.Att
{

    public partial class FRM25 : JBControls.JBForm
    {
        public FRM25()
        {
            InitializeComponent();
        }

        object[] PARMS = null;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

        private void FRM25_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'dsAtt.ATTCARD' 資料表。您可以視需要進行移動或移除。
            //this.aTTCARDTableAdapter.Fill(this.dsAtt.ATTCARD);
            this.taCARD.FillByInit(this.dsAtt.CARD);
            this.taCARDLOSD.Fill(this.dsAtt.CARDLOSD);
            this.aTTCARDTableAdapter.FillByInit(this.dsAtt.ATTCARD);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }
            fdc.WhereCmd = " los=1 ";

            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            fdc.WhereCmd += " and " + Sal.Function.GetFilterCmd("FRM24");

            fdc.DataAdapter = taCARD;
            fdc.Init_Ctrls();
            
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
               
                Dal.Dao.Att.TransCardDao tc = new Dal.Dao.Att.TransCardDao(db.Connection);
                tc.TransCard(PARMS[0].ToString().Trim(), PARMS[1].ToString().Trim(), PARMS[2].ToString().Trim(), PARMS[3].ToString().Trim(), DateTime.Parse(PARMS[4].ToString()), DateTime.Parse(PARMS[5].ToString()), MainForm.USER_NAME, true, true, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            }
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (Sal.Function.IsAttendLocked(Convert.ToDateTime(txtAdate.Text), ptxNobr.Text))
            {
                if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)
                {//鎖定時新增，移至下個月
                    //e.Values["YYMM"] = GetUnLockYYMM(Convert.ToDateTime(txtDateB.Text));

                    //if (MessageBox.Show(Resources.Att.AttendDateLocked + "," + Resources.Att.YymmMoveToNextMonth, Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
                    MessageBox.Show(Resources.Att.AttendDateLocked, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    e.Cancel = true;
                    return;
                }
                else if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Modify)
                {//鎖定時修改，不可以修改
                    MessageBox.Show(Resources.Att.AttendDateLocked, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    e.Cancel = true;
                    return;
                }
            }
            if (!Sal.Function.ValidateTimeStringFormat(textBox2.Text))//判斷時間格式
            {
                e.Cancel = true;
                return;
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
                e.Values["LOS"] = true;
            }

        }

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
                
                var DeptSQL = from a in db.BASETTS
                              join b in db.DEPT on a.DEPT equals b.D_NO
                              where DateTime.Parse(e.Values["adate"].ToString()) <= a.DDATE && DateTime.Parse(e.Values["adate"].ToString()) >= a.ADATE
                              && a.NOBR == e.Values["nobr"].ToString().Trim()
                              select new { a.NOBR, b.D_NO_DISP };

                string dept_b = DeptSQL.First().D_NO_DISP;

                Dal.Dao.Att.TransCardDao tc = new Dal.Dao.Att.TransCardDao(db.Connection);
                //tc.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(tc_StatusChanged);
                tc.TransCard(e.Values["nobr"].ToString().Trim(), e.Values["nobr"].ToString().Trim(), dept_b, dept_b, DateTime.Parse(e.Values["adate"].ToString()), DateTime.Parse(e.Values["adate"].ToString()), MainForm.USER_NAME, true, true, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
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
            //if (e.HasData) txtAdate.Focus();
        }

        private void fdc_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (Sal.Function.IsAttendLocked(Convert.ToDateTime(txtAdate.Text), ptxNobr.Text))
            {
                //鎖定時修改，不可以修改
                MessageBox.Show(Resources.Att.AttendDateLocked, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
                return;
            }
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            
            var DeptSQL = from a in db.BASETTS
                          join b in db.DEPT on a.DEPT equals b.D_NO
                          where DateTime.Parse(e.Values["adate"].ToString()) <= a.DDATE && DateTime.Parse(e.Values["adate"].ToString()) >= a.ADATE
                          && a.NOBR == e.Values["nobr"].ToString().Trim()
                          select new { a.NOBR, b.D_NO_DISP };

            string dept_b = DeptSQL.First().D_NO_DISP;

            PARMS = new object[] { e.Values["nobr"].ToString().Trim(), e.Values["nobr"].ToString().Trim(), dept_b, dept_b, DateTime.Parse(e.Values["adate"].ToString()), DateTime.Parse(e.Values["adate"].ToString()), MainForm.USER_NAME, true, true, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Enabled = false;
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!Sal.Function.ValidateTimeStringFormat(textBox2.Text))
            {
                errorProvider.SetError((Control)sender, Resources.Att.InputFormatNotCorrect );
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0 && dgv.CurrentRow != null)
            {
                string nobr = dgv.CurrentRow.Cells[0].Value.ToString();
                this.dsAtt.ATTCARD.Clear();
                if (nobr.Trim().Length > 0)
                {
                    ShowAttend(ptxNobr.Text, Convert.ToDateTime(txtAdate.Text));
                }
            }
        }

        private void txtAdate_Validated(object sender, EventArgs e)
        {
            string nobr = dgv.CurrentRow.Cells[0].Value.ToString();
            if (nobr.Trim().Length > 0)
            {
                ShowAttend(ptxNobr.Text, Convert.ToDateTime(txtAdate.Text));
            }
         }

        void ShowAttend(string nobr, DateTime adate)
        {
            try
            {
                Att.dcViewDataContext dv = new JBHR.Att.dcViewDataContext();
                var sql = from ac in dv.V_FRM26 where ac.NOBR == nobr && ac.ADATE == adate select ac;
                this.dsAtt.ATTCARD.Clear();
                this.dsAtt.ATTCARD.FillData(dv.GetCommand(sql));
            }
            catch { }
        }
    }
}