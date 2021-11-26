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
using JBHR.Att.Attendance.Dto;
using JBHR.Att.Attendance;

namespace JBHR.Att
{

    public partial class FRM233 : JBControls.JBForm
    {
        public FRM233()
        {
            InitializeComponent();
        }
        dcAttDataContext db = new dcAttDataContext();
        WorkScheduleCheckGenerator WSCG;
        private void FRM233_Load(object sender, EventArgs e)
        {
            // TODO:  這行程式碼會將資料載入 'dsAtt.TMTABLE_IMPORT' 資料表。您可以視需要進行移動或移除。
            this.tMTABLE_IMPORTTableAdapter.FillByInit(this.dsAtt.TMTABLE_IMPORT);
            // TODO: 這行程式碼會將資料載入 'extDS.ROTE' 資料表。您可以視需要進行移動或移除。
            this.roteTableAdapter1.Fill(this.extDS.ROTE);
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
            fdc.WhereCmd = Sal.Function.GetFilterCmd("TMTABLE_IMPORT");

            CreateRoteTable();
            fdc.DataAdapter = tMTABLE_IMPORTTableAdapter;
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
                lbl.Width = 50;
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
                else if (lbl != null)
                {
                    #region 排班檢核高亮日期
                    lbl.Click -= Lbl_Click;
                    int day = 0;
                    string[] split = lbl.Text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    if (split.Length > 0 && int.TryParse(split[0], out day))
                    {
                        WSCG.WSCE.workScheduleCheck.BeginCheckDate = WSCG.WSCE.workScheduleCheck.StartDate.AddDays(7 + day - 1);
                        WSCG.WSCE.workScheduleCheck.EndCheckDate = WSCG.WSCE.workScheduleCheck.BeginCheckDate;
                        if (WSCG.WSCE.workScheduleCheck.WorkSchedules.Where(p => p.AttendanceDate == WSCG.WSCE.workScheduleCheck.BeginCheckDate).FirstOrDefault() != null)
                        {
                            WSCG.WSCE.workScheduleCheck.WorkSchedules.Where(p => p.AttendanceDate == WSCG.WSCE.workScheduleCheck.BeginCheckDate).FirstOrDefault().ScheduleType = rote;
                            WorkScheduleCheckResult result = WSCG.Check();

                            if (result.workScheduleIssues.Count > 0)
                            {
                                lbl.Text = string.Format("{0}.警告", lbl.Text);
                                lbl.Click += Lbl_Click;
                                lbl.ForeColor = Color.FromName("Red");
                            }
                            else
                            {
                                lbl.Text = split[0];
                                lbl.ForeColor = Color.FromName("Black");
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        private void Lbl_Click(object sender, EventArgs e)
        {
            #region 警告訊息
            Label lbl = sender as Label;
            string[] split = lbl.Text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            int day = 0;
            if (split.Length > 0 && int.TryParse(split[0], out day))
            {
                WSCG.WSCE.workScheduleCheck.BeginCheckDate = WSCG.WSCE.workScheduleCheck.StartDate.AddDays(7 + day - 1);
                WSCG.WSCE.workScheduleCheck.EndCheckDate = WSCG.WSCE.workScheduleCheck.BeginCheckDate;
                WorkScheduleCheckResult result = WSCG.Check();
                string ErrorMsg = string.Empty;
                foreach (var item in result.workScheduleIssues)
                {
                    ErrorMsg += item.ErrorMessage;
                }
                if (ErrorMsg.Trim().Length > 0)
                    MessageBox.Show(ErrorMsg, "排班檢核", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            #endregion
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

                #region 檢核資料初始化
                JBModule.Data.Linq.HrDBDataContext HRdb = new JBModule.Data.Linq.HrDBDataContext();

                WSCG = new WorkScheduleCheckGenerator(ptxNobr.Text, date.AddDays(-7), date, date.AddMonths(1).AddDays(-1));
               
                var NowTMTABLE = HRdb.TMTABLE_IMPORT.Where(p => p.NOBR == ptxNobr.Text && p.YYMM == txtYymm.Text);
                if (NowTMTABLE.Any())
                {
                    DataRow TargetRow = NowTMTABLE.CopyToDataTable().Rows[0];
                    foreach (DataColumn dc in TargetRow.Table.Columns)
                        if (dc.ColumnName.CompareTo("D1") >= 0 && dc.ColumnName.CompareTo("D99") <= 0)//&& TargetRow[dc.ColumnName].ToString().Trim().Length > 0)
                        {
                            DateTime DT = date.AddDays(int.Parse(dc.ColumnName.Remove(0, 1)) - 1);
                            if (WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == DT).Any())
                                WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == DT).First().ScheduleType = TargetRow[dc.ColumnName].ToString();
                            else
                                WSCG.WSCD.WorkSchedules.Add(WorkScheduleCheckGenerator.NewWSD(DT, TargetRow[dc.ColumnName].ToString()));
                        }
                }
                WSCG.WSCE.CheckTypes.Add("CIT");
                WSCG.WSCE.CheckTypes.Add("CW7");
                #endregion
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
                cbx.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", tMTABLEIMPORTBindingSource, "D" + day.ToString()));
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
            SalaryDate sd = new SalaryDate(DateTime.Today);
            txtYymm.Text = sd.YYMM;//SalaryYYMM;
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
            foreach (var itm in dsAtt.TMTABLE_IMPORT)
            {
                if (Sal.Function.CanModify(itm.NOBR))
                {
                    itm["D" + i.ToString()] = cbxChgRote.SelectedValue;
                    itm.KEY_DATE = DateTime.Now;
                    itm.KEY_MAN = MainForm.USER_NAME;
                }
            }
            dsAttTableAdapters.TMTABLE_IMPORTTableAdapter ad = new JBHR.Att.dsAttTableAdapters.TMTABLE_IMPORTTableAdapter();
            ad.Update(dsAtt.TMTABLE_IMPORT);
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
            ws.GetRow(0).CreateCell(0).SetCellValue("出勤年月");
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
            var roteData = db.ROTE.Select(p => new JBControls.CheckImportData { DisplayCode = p.ROTE_DISP, RealCode = p.ROTE1, DisplayName = p.ROTENAME, CheckValue1 = p.ROTE_SNAME.Trim().Length > 0 ? p.ROTE_SNAME : p.ROTENAME, CheckValue2 = p.ROTENAME }).ToList();
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
            frm.DataTransfer.ColumnList.Add("出勤年月", typeof(string));
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
