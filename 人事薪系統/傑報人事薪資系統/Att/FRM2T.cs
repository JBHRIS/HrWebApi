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
    public partial class FRM2T : JBControls.JBForm
    {
        public FRM2T()
        {
            InitializeComponent();
        }

        CheckControl cc;//必要欄位檢查
        List<JBModule.Data.Linq.HCODE> HcodeList = new List<JBModule.Data.Linq.HCODE>();
        private void FRM2T_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(ptxHcode);//必要欄位檢查
            var db1 = new JBModule.Data.Linq.HrDBDataContext();
            HcodeList = db1.HCODE.ToList();
            this.hCODETableAdapter.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            SystemFunction.SetComboBoxItems(ptxHcode, CodeFunction.GetHcode(true), true, false, true);
            ptxHcode.Enabled = false;
            this.aBSTTableAdapter.FillByInit(this.dsAtt.ABST);

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
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("ABS") + " AND EXISTS(SELECT 1 FROM HCODE X1 WHERE X1.H_CODE=ABS.H_CODE AND X1.FLAG='+')";

            fullDataCtrl1.DataAdapter = aBSTTableAdapter;
            fullDataCtrl1.Init_Ctrls();
            txtAddDay.Enabled = false;
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            txtAddDay.Enabled = true;
            textBoxSerno.Text = Guid.NewGuid().ToString();
            textBoxGuid.Text = Guid.NewGuid().ToString();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData) ptxHcode.Focus();
        }

        private void ptxHcode_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData) txtBdate.Focus();
        }

        private void txtAddDay_Validated(object sender, EventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(Convert.ToDecimal(txtAddDay.Text));
                DateTime d1 = Convert.ToDateTime(txtBdate.Text);
                DateTime d2 = d1.AddDays(i);
                txtEdate.Text = Sal.Function.GetDate(d2);
            }
            catch { }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                txtAddDay.Enabled = false;
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
            var ctrl = cc.CheckRequiredFields();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
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
                Calc();
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
                e.Values["BTIME"] = "0000" + DateTime.Now.ToOADate().ToString();
                e.Values["ETIME"] = "0000" + DateTime.Now.ToOADate().ToString();
                e.Values["Serno"] = textBoxSerno.Text;
                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
                    e.Values["Guid"] = Guid.NewGuid().ToString();
                e.Values["Balance"] = Convert.ToDecimal(textBoxBalance.Text);
            }
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtAddDay.Enabled = true;
            ptxNobr.Enabled = false;
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtAddDay.Enabled = false;
        }

        private void ptxHcode_SelectedValueChanged(object sender, EventArgs e)
        {
        }
        void Calc()
        {
            var entitle = Convert.ToDecimal(txtTotalHours.Text);
            var taken = Convert.ToDecimal(textBoxLeaveHours.Text);
            var balance = entitle - taken;
            textBoxBalance.Text = balance.ToString();
        }

        private void txtTotalHours_Validated(object sender, EventArgs e)
        {
            Calc();
        }

        private void textBoxLeaveHours_Validated(object sender, EventArgs e)
        {
            Calc();
        }

        private void buttonABSD_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (ptxHcode.SelectedValue != null && ptxNobr.Text.Trim().Length > 0)
                {
                    string hcode = ptxHcode.SelectedValue.ToString().Trim();
                    var sql = from a in HcodeList where a.H_CODE.Trim() == hcode select a;
                    if (sql.Any())
                    {
                        JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4ADV", MainForm.COMPANY);
                        var ADVHtype = AppConfig.GetConfig("AdvanceLeaveHcodeType").GetString(string.Empty);
                        var myDB = new JBModule.Data.Linq.HrDBDataContext();
                        var guid = textBoxGuid.Text;
                        var abssql = from a in myDB.ABS
                                     join h in myDB.HCODE on a.H_CODE equals h.H_CODE
                                     join ht in myDB.HcodeType on h.HTYPE equals ht.HTYPE
                                     select new { ABS = a, Flag = h.FLAG, Htype = h.HTYPE , HtypeName = ht.TYPE_NAME };

                        var qq = from a in myDB.ABSD
                                 join add in abssql on a.ABSADD equals add.ABS.Guid into add1
                                 from add in add1.DefaultIfEmpty()
                                 join sub in abssql on a.ABSSUBTRACT equals sub.ABS.Guid into sub1
                                 from sub in sub1.DefaultIfEmpty()
                                 where a.ABSADD == guid
                                 select new
                                 {
                                     屬性 = sub != null ? ((sub.Flag == "X" || (add.Htype == ADVHtype && add.Htype != sub.Htype)) ? "借假沖銷" : "請假") : "請假",
                                     申請日期 = sub != null ? sub.ABS.BDATE : new DateTime(1900, 1, 1),
                                     起始時間 = sub != null ? sub.ABS.BTIME : "",
                                     結束時間 = sub != null ? sub.ABS.ETIME : "",
                                     時數 = sub != null ? ((sub.Flag == "X" || (add.Htype == ADVHtype && add.Htype != sub.Htype)) ? 0 - a.USEHOUR : a.USEHOUR) : a.USEHOUR,
                                     備註 = sub.ABS.NOTE
                                 };
                        Sal.PreviewForm frm = new Sal.PreviewForm();
                        frm.DataTable = qq.CopyToDataTable();
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Width = 800;
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void buttonCheckABSD_Click(object sender, EventArgs e)
        {
            FRM2TA frm = new FRM2TA();
            frm.Show();
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            FRM2TGN frm = new FRM2TGN();
            frm.ShowDialog();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行更新時數?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel) return;
            var myDB = new JBModule.Data.Linq.HrDBDataContext();
            foreach (var it in dsAtt.ABST)
            {
                if (!it.IsGuidNull())
                {
                    var sql = from a in myDB.ABSD where a.ABSADD == it.Guid select a;
                    decimal LeaveHours = 0;
                    if (sql.Any())
                        LeaveHours = sql.Sum(p => p.USEHOUR);
                    it.LeaveHours = LeaveHours;
                    it.Balance = it.TOL_HOURS - LeaveHours;
                    this.aBSTTableAdapter.Update(it);
                }
                else
                {
                    it.Guid = Guid.NewGuid().ToString();
                    it.LeaveHours = 0;
                    it.Balance = it.TOL_HOURS;
                    this.aBSTTableAdapter.Update(it);
                }
            }
            MessageBox.Show("時數更新完成");
        }

        private void btnIMPORT_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = false;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = false;
            frm.TemplateButtonVisible = true;

            frm.FieldForm = new FRM2TIN();

            frm.DataTransfer = new ImportTransferToABST();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("假別代碼", db.HCODE.Select(p => new JBControls.CheckImportData { DisplayCode = p.H_CODE_DISP, RealCode = p.H_CODE, DisplayName = p.H_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("員工編號", this.dsBas.BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("生效日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("失效日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("得假時數/天數", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("假別代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("假別名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("警告", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));
            frm.ShowDialog();
        }
    }
}
