using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using JBHR.Sal.Core;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
namespace JBHR.Att
{

    public partial class FRM23 : JBControls.JBForm
    {
        public FRM23()
        {
            InitializeComponent();
        }
        dcAttDataContext db = new dcAttDataContext();
        private void FRM23_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'extDS.ROTE' 資料表。您可以視需要進行移動或移除。
            this.roteTableAdapter1.Fill(this.extDS.ROTE);
            this.tMTABLETableAdapter.FillByInit(this.dsAtt.TMTABLE);
            SystemFunction.SetComboBoxItems(cbxChgRote, CodeFunction.GetRote(), true);
            //this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);

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
            fdc.WhereCmd = Sal.Function.GetFilterCmd(this.Name);

            CreateRoteTable();
            fdc.WhereCmd = Sal.Function.GetFilterCmdByNobr("frm23.nobr");
            fdc.DataAdapter = tMTABLETableAdapter;
            fdc.Init_Ctrls();
        }
        /// <summary>
        /// 建立班表表格
        /// </summary>
        void CreateRoteTable()
        {
            var db1 = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from r in db1.ROTE
                      where db1.GetCodeFilter("ROTE", r.ROTE1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      orderby r.ROTE_DISP
                      select new { rotename = r.ROTENAME, rote_disp = r.ROTE_DISP, rote = r.ROTE1 };

            for (int i = 0; i < tableLayoutPanel2.RowCount * tableLayoutPanel2.ColumnCount; i++)
            {
                var lst = sql.ToList();
                var value = new { rotename = "", rote_disp = "", rote = "" };
                lst.Insert(0, value);
                FlowLayoutPanel pnl = new FlowLayoutPanel();
                Label lbl = new Label();
                lbl.Text = "";
                lbl.Width = 40;
                lbl.Font = new Font(lbl.Font, FontStyle.Bold);
                lbl.ForeColor = Color.Gray;
                pnl.Controls.Add(lbl);

                ComboBox cbx = new ComboBox();
                cbx.DataSource = lst;
                cbx.DisplayMember = "rote_disp";
                cbx.ValueMember = "rote";
                cbx.SelectedValue = "";
                //SystemFunction.SetComboBoxItems(cbx, CodeFunction.GetRote(), true);
                cbx.Width = 40;
                cbx.SelectedValueChanged += new EventHandler(cbx_SelectedValueChanged);
                cbx.Enabled = false;

                pnl.Controls.Add(cbx);
                pnl.Dock = DockStyle.Fill;
                pnl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                Label lblName = new Label();
                lblName.DataBindings.Add(new System.Windows.Forms.Binding("Text", cbx.DataSource, "rotename"));
                lblName.Tag = "rote";
                lblName.Font = new Font(lblName.Font, FontStyle.Bold);
                pnl.Controls.Add(lblName);

                tableLayoutPanel2.Controls.Add(pnl);

            }
        }
        /// <summary>
        /// 表格中combobox的SelectedValueChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cbx_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cbx = (ComboBox)sender;
            string rote = cbx.SelectedValue != null ? cbx.SelectedValue.ToString() : "";
            FlowLayoutPanel pnl = (FlowLayoutPanel)cbx.Parent;
            foreach (var ctrl in pnl.Controls)
            {
                Label lbl = ctrl as Label;
                if (lbl != null && lbl.Tag != null)
                    if (lbl.Tag.ToString() == "rote" && CodeFunction.GetHolidayRoteList().Contains(rote))
                        lbl.ForeColor = Color.FromName("Red");
                    else lbl.ForeColor = Color.FromName("Black");
            }
        }
        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
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

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
            }
        }

        private void fdc_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void txtYymm_Validated(object sender, EventArgs e)
        {
            DataBind(true);
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData)
            //{
            //    SendKeys.Send("{Tab}");
            //}
        }

        void DataBind(bool modi)
        {
            SalaryDate sd = new SalaryDate(txtYymm.Text.Trim());
            int DayOfWeek = 0;
            int MonthDays = 0;
            if (sd.Month >= 1 && sd.Month <= 12)
            {
                DateTime date = new DateTime(sd.Year, sd.Month, 1);
                DayOfWeek = Convert.ToInt32(date.DayOfWeek);
                MonthDays = DateTime.DaysInMonth(sd.Year, sd.Month);
            }
            int day = 0;
            for (int i = 0; i < tableLayoutPanel2.RowCount * tableLayoutPanel2.ColumnCount; i++)
            {
                Label lbl = null, lblName = null;
                ComboBox cbx = null;

                FlowLayoutPanel pnl = (FlowLayoutPanel)tableLayoutPanel2.Controls[i];
                foreach (var ctrl in pnl.Controls)
                {
                    Label lb = ctrl as Label;
                    if (lb != null)
                    {
                        if (lb.Tag == null) lbl = lb;
                        else lblName = lb;
                    }
                    else
                    {
                        cbx = ctrl as ComboBox;
                    }
                }

                lbl.Text = "";//預設
                cbx.Enabled = false;//預設
                cbx.SelectedValue = "";
                cbx.DataBindings.Clear();//清空繫結項目
                if (DayOfWeek > 0)//將開始點設定在本月第一天的WeekDay
                {
                    DayOfWeek--;
                    continue;
                }
                day++;
                if (day > 31) continue;//全部都要Binding
                if (day <= MonthDays)
                {
                    lbl.Text = day.ToString();
                    cbx.Enabled = modi;
                }
                cbx.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", tMTABLEBindingSource, "D" + day.ToString()));
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.CurrentRow != null && txtYymm.Text.Trim().Length > 0)
            {
                DataBind(false);
            }
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataBind(true);
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void btnNoneRotet_Click(object sender, EventArgs e)
        {
            if (txtCheckYM.Text.Length != 6)
            {
                MessageBox.Show("「查詢年月」輸入錯誤或未填寫");
                txtCheckYM.Focus();
                return;
            }
            List<string> ttscode = new List<string>();
            ttscode.Add("1");
            ttscode.Add("4");
            ttscode.Add("6");

            SalaryDate sd = new SalaryDate(txtCheckYM.Text);
            DateTime d1, d2;
            d1 = sd.FirstDayOfMonth;
            d2 = sd.LastDayOfMonth;
            var sql = from r in db.TMTABLE where r.YYMM == txtCheckYM.Text.Trim() select r.NOBR;//該年月存在的班表資料
            var data = from bs in db.ATT_BASE
                       join bt in db.ATT_BASETTS on bs.NOBR equals bt.NOBR
                       where d1 >= bt.ADATE && d1 <= bt.DDATE
                       && !(from r in sql where r == bt.NOBR select r).Any()
                       && db.GetFilterByNobr(bs.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                       && ttscode.Contains(bt.TTSCODE)
                       select new { 工號 = bs.NOBR, 姓名 = bs.NAME_C };
            var dt = data.CopyToDataTable();
            Sal.PreviewForm vw = new JBHR.Sal.PreviewForm();
            vw.DataTable = dt;
            vw.Text = "未有班表者";
            vw.ShowDialog();
        }

        private void txtYymm_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                SalaryDate sd = new SalaryDate(txtYymm.Text.Trim());
                if (sd.Month < 1 || sd.Month > 12) throw new FormatException();
            }
            catch
            {
                e.Cancel = true;
                errorProvider.SetError(txtYymm, Resources.Att.YymmFormatException);
            }
        }

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtYymm.Focus();
            txtYymm.Text = "201013";
            DataBind(false);
            txtYymm.Text = "";
        }

        private void fdc_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnTran_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (!int.TryParse(txtChgDay.Text, out i))
            {
                MessageBox.Show(Resources.Att.InputFormatNotCorrect, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (!(i > 0 && i <= 31))
            {
                MessageBox.Show(Resources.Att.DataOutOfRange, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            foreach (var itm in dsAtt.TMTABLE)
            {
                if (Sal.Function.CanModify(itm.NOBR))
                {
                    itm["D" + i.ToString()] = cbxChgRote.SelectedValue;
                    itm.KEY_DATE = DateTime.Now;
                    itm.KEY_MAN = MainForm.USER_NAME;
                }
            }
            dsAttTableAdapters.TMTABLETableAdapter ad = new JBHR.Att.dsAttTableAdapters.TMTABLETableAdapter();
            ad.Update(dsAtt.TMTABLE);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateExcelModel();
        }
        private void CreateExcelModel()
        {
            //建立Excel 2003檔案
            IWorkbook wb = new HSSFWorkbook();
            ISheet ws = wb.CreateSheet("Class");

            ////建立Excel 2007檔案
            //IWorkbook wb = new XSSFWorkbook();
            //ISheet ws = wb.CreateSheet("Class");

            ws.CreateRow(0);//第一行為功能變數名稱
            ws.GetRow(0).CreateCell(0).SetCellValue("計薪年月");
            ws.GetRow(0).CreateCell(1).SetCellValue("工號");
            ws.GetRow(0).CreateCell(2).SetCellValue("員工姓名");
            for (int i = 1; i <= 31; i++)
            {
                ws.GetRow(0).CreateCell(i + 2).SetCellValue("D" + i.ToString());
            }

            //var file = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "sample.xls", FileMode.Create);

            //wb.Write(file);
            //file.Close();
            string path = @"C:\temp\員工班表_樣板.xls";
            FileStream file = new FileStream(path, FileMode.Create);//產生檔案
            wb.Write(file);
            file.Close();
            MessageBox.Show("檔案儲存位址： " + path, "訊息");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.ColumnStyle = JBTools.IO.LoadExcelColumnNameStyle.DefinedColumn;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            frm.Text = "員工班表批次匯入";
            //frm.Allow_Repeat_Delete = true;
            //frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.Allow_MatchField = false;

            frm.AutoMatchMode = true;

            frm.FieldForm = new JBControls.U_FIELD();
            frm.DataTransfer = new TimeTableImport();


            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();

            //frm.DataTransfer.CheckData.Add("工號", this.dsBas.BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            var roteData = db.ROTE.Select(p => new JBControls.CheckImportData { DisplayCode = p.ROTE_DISP, RealCode = p.ROTE1, DisplayName = p.ROTENAME, CheckValue1 = p.ROTE_SNAME.Trim().Length > 0 ? p.ROTE_SNAME : p.ROTENAME ,CheckValue2 = p.ROTENAME}).ToList();
            roteData.Add(new JBControls.CheckImportData { DisplayName = "無", DisplayCode = "", RealCode = "" });
            frm.DataTransfer.CheckData.Add("D1", roteData);
            frm.DataTransfer.CheckData.Add("D2", roteData);
            frm.DataTransfer.CheckData.Add("D3", roteData);
            frm.DataTransfer.CheckData.Add("D4", roteData);
            frm.DataTransfer.CheckData.Add("D5", roteData);
            frm.DataTransfer.CheckData.Add("D6", roteData);
            frm.DataTransfer.CheckData.Add("D7", roteData);
            frm.DataTransfer.CheckData.Add("D8", roteData);
            frm.DataTransfer.CheckData.Add("D9", roteData);
            frm.DataTransfer.CheckData.Add("D10", roteData);
            frm.DataTransfer.CheckData.Add("D11", roteData);
            frm.DataTransfer.CheckData.Add("D12", roteData);
            frm.DataTransfer.CheckData.Add("D13", roteData);
            frm.DataTransfer.CheckData.Add("D14", roteData);
            frm.DataTransfer.CheckData.Add("D15", roteData);
            frm.DataTransfer.CheckData.Add("D16", roteData);
            frm.DataTransfer.CheckData.Add("D17", roteData);
            frm.DataTransfer.CheckData.Add("D18", roteData);
            frm.DataTransfer.CheckData.Add("D19", roteData);
            frm.DataTransfer.CheckData.Add("D20", roteData);
            frm.DataTransfer.CheckData.Add("D21", roteData);
            frm.DataTransfer.CheckData.Add("D22", roteData);
            frm.DataTransfer.CheckData.Add("D23", roteData);
            frm.DataTransfer.CheckData.Add("D24", roteData);
            frm.DataTransfer.CheckData.Add("D25", roteData);
            frm.DataTransfer.CheckData.Add("D26", roteData);
            frm.DataTransfer.CheckData.Add("D27", roteData);
            frm.DataTransfer.CheckData.Add("D28", roteData);
            frm.DataTransfer.CheckData.Add("D29", roteData);
            frm.DataTransfer.CheckData.Add("D30", roteData);
            frm.DataTransfer.CheckData.Add("D31", roteData);

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("計薪年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("工號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("D1", typeof(string));
            frm.DataTransfer.ColumnList.Add("D2", typeof(string));
            frm.DataTransfer.ColumnList.Add("D3", typeof(string));
            frm.DataTransfer.ColumnList.Add("D4", typeof(string));
            frm.DataTransfer.ColumnList.Add("D5", typeof(string));
            frm.DataTransfer.ColumnList.Add("D6", typeof(string));
            frm.DataTransfer.ColumnList.Add("D7", typeof(string));
            frm.DataTransfer.ColumnList.Add("D8", typeof(string));
            frm.DataTransfer.ColumnList.Add("D9", typeof(string));
            frm.DataTransfer.ColumnList.Add("D10", typeof(string));
            frm.DataTransfer.ColumnList.Add("D11", typeof(string));
            frm.DataTransfer.ColumnList.Add("D12", typeof(string));
            frm.DataTransfer.ColumnList.Add("D13", typeof(string));
            frm.DataTransfer.ColumnList.Add("D14", typeof(string));
            frm.DataTransfer.ColumnList.Add("D15", typeof(string));
            frm.DataTransfer.ColumnList.Add("D16", typeof(string));
            frm.DataTransfer.ColumnList.Add("D17", typeof(string));
            frm.DataTransfer.ColumnList.Add("D18", typeof(string));
            frm.DataTransfer.ColumnList.Add("D19", typeof(string));
            frm.DataTransfer.ColumnList.Add("D20", typeof(string));
            frm.DataTransfer.ColumnList.Add("D21", typeof(string));
            frm.DataTransfer.ColumnList.Add("D22", typeof(string));
            frm.DataTransfer.ColumnList.Add("D23", typeof(string));
            frm.DataTransfer.ColumnList.Add("D24", typeof(string));
            frm.DataTransfer.ColumnList.Add("D25", typeof(string));
            frm.DataTransfer.ColumnList.Add("D26", typeof(string));
            frm.DataTransfer.ColumnList.Add("D27", typeof(string));
            frm.DataTransfer.ColumnList.Add("D28", typeof(string));
            frm.DataTransfer.ColumnList.Add("D29", typeof(string));
            frm.DataTransfer.ColumnList.Add("D30", typeof(string));
            frm.DataTransfer.ColumnList.Add("D31", typeof(string));

            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.ShowDialog();
        }
    }
}
