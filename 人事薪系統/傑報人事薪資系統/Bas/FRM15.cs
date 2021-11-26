using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JBHR.Bas
{
    public partial class FRM15 : JBControls.JBForm
    {
        CheckControl cc;
        public FRM15()
        {
            InitializeComponent();
        }

        private void FRM15_Load(object sender, EventArgs e)
        {
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbAWARD);      //部門群組
            #endregion

            this.aWARDTableAdapter.FillByInit(this.basDS.AWARD);//載入時顯示空白
            Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);
            this.aWARDCDTableAdapter.Fill(this.basDS.AWARDCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.aWARDTableAdapter.Fill(this.basDS.AWARD);
            SystemFunction.SetComboBoxItems(cbAWARD, CodeFunction.GetAwardcd(), true, false, true);      //部門群組
			fullDataCtrl1.DataAdapter = aWARDTableAdapter;

			BasDataClassesDataContext db = new BasDataClassesDataContext();
			var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
			if (u_prg != null)
			{
				fullDataCtrl1.bnAddEnable = u_prg.ADD_;
				fullDataCtrl1.bnEditEnable = u_prg.EDIT;
				fullDataCtrl1.bnDelEnable = u_prg.DELE;
				fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
			}
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByNobr("award.nobr");
            
			fullDataCtrl1.Init_Ctrls();
            SetUploadButtons();
        }

		private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
			if (!e.Error)
			{
				CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
                SetUploadButtons();
			}
		}

		private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
		{
            #region 必要欄位檢察
            var ctrl = cc.CheckRequiredFields();//必要欄位檢察
            if (ctrl != null)//必要欄位檢察
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }
            #endregion

			if (!checkSavePower(e.Values["nobr"].ToString()))
			{
				e.Cancel = true;
				MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			if (!e.Cancel)
			{
				e.Values["key_man"] = MainForm.USER_NAME;
				e.Values["key_date"] = DateTime.Now;
			}
		}

		private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
			if (!e.Error)
			{
				CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
                SetUploadButtons();
			}
		}

		private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
			DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
			dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

			JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
			System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
		}

		private void dataGridViewEx1_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

		}

		private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
            SetUploadButtons();
		}

		private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
            SetUploadButtons();
		}


		private bool checkSavePower(string nobr)
		{
            return Sal.Function.CanModify(nobr);
		}

        private void bnUp_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Any File (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullfilename = openFileDialog.FileName;
                FileStream fs = new FileStream(fullfilename, FileMode.Open);
                byte[] buffer = new byte[fs.Length]; // 用來儲存檔案的 byte 陣列，檔案有多大，陣列就有多大 
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();                

                string[] fileName = fullfilename.Split(new char[] { '\\' });

                switch ((sender as Control).Name)
                {
                    case "bnUp1":
                        (aWARDBindingSource.Current as DataRowView)["up1_name"] = fileName[fileName.Length - 1];
                        (aWARDBindingSource.Current as DataRowView)["up1_file"] = buffer;
                        textBoxUpName1.Text = (aWARDBindingSource.Current as DataRowView)["up1_name"].ToString();
                        break;
                    case "bnUp2":
                        (aWARDBindingSource.Current as DataRowView)["up2_name"] = fileName[fileName.Length - 1];
                        (aWARDBindingSource.Current as DataRowView)["up2_file"] = buffer;
                        textBoxUpName2.Text = (aWARDBindingSource.Current as DataRowView)["up2_name"].ToString();
                        break;
                    case "bnUp3":
                        (aWARDBindingSource.Current as DataRowView)["up3_name"] = fileName[fileName.Length - 1];
                        (aWARDBindingSource.Current as DataRowView)["up3_file"] = buffer;
                        textBoxUpName3.Text = (aWARDBindingSource.Current as DataRowView)["up3_name"].ToString();
                        break;
                    case "bnUp4":
                        (aWARDBindingSource.Current as DataRowView)["up4_name"] = fileName[fileName.Length - 1];
                        (aWARDBindingSource.Current as DataRowView)["up4_file"] = buffer;
                        textBoxUpName4.Text = (aWARDBindingSource.Current as DataRowView)["up4_name"].ToString();
                        break;
                    case "bnUp5":
                        (aWARDBindingSource.Current as DataRowView)["up5_name"] = fileName[fileName.Length - 1];
                        (aWARDBindingSource.Current as DataRowView)["up5_file"] = buffer;
                        textBoxUpName5.Text = (aWARDBindingSource.Current as DataRowView)["up5_name"].ToString();
                        break;
                }
            }
        }

        private void bnCr_Click(object sender, EventArgs e)
        {
            switch ((sender as Control).Name)
            {
                case "bnCr1":
                    (aWARDBindingSource.Current as DataRowView)["up1_name"] = "";
                    (aWARDBindingSource.Current as DataRowView)["up1_file"] = null;
                    textBoxUpName1.Text = "";
                    bnOp1.Enabled = false;
                    break;
                case "bnCr2":
                    (aWARDBindingSource.Current as DataRowView)["up2_name"] = "";
                    (aWARDBindingSource.Current as DataRowView)["up2_file"] = null;
                    textBoxUpName2.Text = "";
                    bnOp2.Enabled = false;
                    break;
                case "bnCr3":
                    (aWARDBindingSource.Current as DataRowView)["up3_name"] = "";
                    (aWARDBindingSource.Current as DataRowView)["up3_file"] = null;
                    textBoxUpName3.Text = "";
                    bnOp3.Enabled = false;
                    break;
                case "bnCr4":
                    (aWARDBindingSource.Current as DataRowView)["up4_name"] = "";
                    (aWARDBindingSource.Current as DataRowView)["up4_file"] = null;
                    textBoxUpName4.Text = "";
                    bnOp4.Enabled = false;
                    break;
                case "bnCr5":
                    (aWARDBindingSource.Current as DataRowView)["up5_name"] = "";
                    (aWARDBindingSource.Current as DataRowView)["up5_file"] = null;
                    textBoxUpName5.Text = "";
                    bnOp5.Enabled = false;
                    break;
            }
            (sender as Control).Enabled = false;
        }

        private void bnOp_Click(object sender, EventArgs e)
        {
            string fileName = "";
            BinaryWriter bw = null;

            switch ((sender as Control).Name)
            {
                case "bnOp1":
                    fileName = (aWARDBindingSource.Current as DataRowView)["up1_name"].ToString();
                    using (BinaryWriter binWriter =
                    new BinaryWriter(File.Open("C:\\TEMP\\" + fileName, FileMode.Create)))
                    {
                        binWriter.Write((byte[])(aWARDBindingSource.Current as DataRowView)["up1_file"]);
                    }
                    break;
                case "bnOp2":
                    fileName = (aWARDBindingSource.Current as DataRowView)["up2_name"].ToString();
                    using (BinaryWriter binWriter =
                    new BinaryWriter(File.Open("C:\\TEMP\\" + fileName, FileMode.Create)))
                    {
                        binWriter.Write((byte[])(aWARDBindingSource.Current as DataRowView)["up2_file"]);
                    }
                    break;
                case "bnOp3":
                    fileName = (aWARDBindingSource.Current as DataRowView)["up3_name"].ToString();
                    using (BinaryWriter binWriter =
                    new BinaryWriter(File.Open("C:\\TEMP\\" + fileName, FileMode.Create)))
                    {
                        binWriter.Write((byte[])(aWARDBindingSource.Current as DataRowView)["up3_file"]);
                    }
                    break;
                case "bnOp4":
                    fileName = (aWARDBindingSource.Current as DataRowView)["up4_name"].ToString();
                    using (BinaryWriter binWriter =
                    new BinaryWriter(File.Open("C:\\TEMP\\" + fileName, FileMode.Create)))
                    {
                        binWriter.Write((byte[])(aWARDBindingSource.Current as DataRowView)["up4_file"]);
                    }
                    break;
                case "bnOp5":
                    fileName = (aWARDBindingSource.Current as DataRowView)["up5_name"].ToString();
                    using (BinaryWriter binWriter =
                    new BinaryWriter(File.Open("C:\\TEMP\\" + fileName, FileMode.Create)))
                    {
                        binWriter.Write((byte[])(aWARDBindingSource.Current as DataRowView)["up5_file"]);
                    }
                    break;
            }

            System.Diagnostics.Process.Start("C:\\TEMP\\" + fileName);
        }

        private void SetUploadButtons()
        {
            bnUp1.Enabled = false;
            bnUp2.Enabled = false;
            bnUp3.Enabled = false;
            bnUp4.Enabled = false;
            bnUp5.Enabled = false;

            bnCr1.Enabled = false;
            bnCr2.Enabled = false;
            bnCr3.Enabled = false;
            bnCr4.Enabled = false;
            bnCr5.Enabled = false;

            bnOp1.Enabled = false;
            bnOp2.Enabled = false;
            bnOp3.Enabled = false;
            bnOp4.Enabled = false;
            bnOp5.Enabled = false;

            if (fullDataCtrl1.ModeType == JBControls.FullDataCtrl.EModeType.View)
            {
                if (aWARDBindingSource.Count > 0 && aWARDBindingSource.Current != null)
                {
                    if ((aWARDBindingSource.Current as DataRowView)["up1_name"].ToString().Trim().Length > 0) bnOp1.Enabled = true;
                    if ((aWARDBindingSource.Current as DataRowView)["up2_name"].ToString().Trim().Length > 0) bnOp2.Enabled = true;
                    if ((aWARDBindingSource.Current as DataRowView)["up3_name"].ToString().Trim().Length > 0) bnOp3.Enabled = true;
                    if ((aWARDBindingSource.Current as DataRowView)["up4_name"].ToString().Trim().Length > 0) bnOp4.Enabled = true;
                    if ((aWARDBindingSource.Current as DataRowView)["up5_name"].ToString().Trim().Length > 0) bnOp5.Enabled = true;
                }
            }
            else
            {
                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
                {
                    bnUp1.Enabled = true;
                    bnUp2.Enabled = true;
                    bnUp3.Enabled = true;
                    bnUp4.Enabled = true;
                    bnUp5.Enabled = true;
                }
                else
                {
                    bnUp1.Enabled = true;
                    bnUp2.Enabled = true;
                    bnUp3.Enabled = true;
                    bnUp4.Enabled = true;
                    bnUp5.Enabled = true;

                    if ((aWARDBindingSource.Current as DataRowView)["up1_name"].ToString().Trim().Length > 0)
                    {
                        bnCr1.Enabled = true;
                        bnOp1.Enabled = true;
                    }
                    if ((aWARDBindingSource.Current as DataRowView)["up2_name"].ToString().Trim().Length > 0)
                    {
                        bnCr2.Enabled = true;
                        bnOp2.Enabled = true;
                    }
                    if ((aWARDBindingSource.Current as DataRowView)["up3_name"].ToString().Trim().Length > 0)
                    {
                        bnCr3.Enabled = true;
                        bnOp3.Enabled = true;
                    }
                    if ((aWARDBindingSource.Current as DataRowView)["up4_name"].ToString().Trim().Length > 0)
                    {
                        bnCr4.Enabled = true;
                        bnOp4.Enabled = true;
                    }
                    if ((aWARDBindingSource.Current as DataRowView)["up5_name"].ToString().Trim().Length > 0)
                    {
                        bnCr5.Enabled = true;
                        bnOp5.Enabled = true;
                    }
                }
            }
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox9.Text = "0";
            textBox1.Text = DateTime.Now.ToShortDateString();
            SetUploadButtons();
            popupTextBox1.Focus();
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            SetUploadButtons();
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            SetUploadButtons();
        }

        private void aWARDBindingSource_PositionChanged(object sender, EventArgs e)
        {
            if (aWARDBindingSource.Position != -1) SetUploadButtons();
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(popupTextBox1.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (fullDataCtrl1.ModeType == JBControls.FullDataCtrl.EModeType.Edit)
            {
                Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(Convert.ToDateTime(textBox1.Text), true);
                textBox10.Text = sd.YYMM;
            }
        }

        private void textBox10_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox10.Text)) return;
            try
            {
                if (textBox10.Text.Length == 6)
                {
                    Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(textBox10.Text);
                    var dd = sd.LastDayOfMonth;
                    return;
                }
            }
            catch { }
            MessageBox.Show("計薪年月格式錯誤", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox10.Focus();
        }

        private void bnIMPORT_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;

            frm.FieldForm = new FRM15IN();
            frm.DataTransfer = new ImportAWARDData();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.basDS.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("獎懲原因", this.basDS.AWARDCD.Select(p => new JBControls.CheckImportData { DisplayCode = p.AWARD_CODE_DISP, RealCode = p.AWARD_CODE, DisplayName = p.DESCR ,CheckValue1 = p.AWARD_CODE}).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("獎懲日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("獎懲原因", typeof(string));
            frm.DataTransfer.ColumnList.Add("計薪年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("大功", typeof(Decimal));
            frm.DataTransfer.ColumnList.Add("小功", typeof(Decimal));
            frm.DataTransfer.ColumnList.Add("嘉獎", typeof(Decimal));
            frm.DataTransfer.ColumnList.Add("獎金罰金", typeof(Decimal));
            frm.DataTransfer.ColumnList.Add("大過", typeof(Decimal));
            frm.DataTransfer.ColumnList.Add("小過", typeof(Decimal));
            frm.DataTransfer.ColumnList.Add("申誡", typeof(Decimal));
            frm.DataTransfer.ColumnList.Add("警告", typeof(Decimal));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("計薪年月");
            frm.DataTransfer.UnMustColumnList.Add("備註");
            frm.DataTransfer.UnMustColumnList.Add("大功");
            frm.DataTransfer.UnMustColumnList.Add("小功");
            frm.DataTransfer.UnMustColumnList.Add("嘉獎");
            frm.DataTransfer.UnMustColumnList.Add("獎金罰金");
            frm.DataTransfer.UnMustColumnList.Add("大過");
            frm.DataTransfer.UnMustColumnList.Add("小過");
            frm.DataTransfer.UnMustColumnList.Add("申誡");
            frm.DataTransfer.UnMustColumnList.Add("警告");

            frm.ShowDialog();
        }
    }
}
