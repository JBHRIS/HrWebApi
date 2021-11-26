using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using JBHR.BLL.NotifyMsgLib;
namespace JBHR.Bas
{
    public partial class FRM1O : JBControls.JBForm
    {
        CheckControl cc;
        public FRM1O()
        {
            InitializeComponent();
        }
        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("Contract",MainForm.COMPANY);
        List<ContractType> ContractTypeList = new List<ContractType>();
        private void FRM11M_Load(object sender, EventArgs e)
        {
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbContractType);      //合同種類
            cc.AddControl(cbWORKCD);      //派駐區
            #endregion

            acg.CheckParameterAndSetDefault("AlertDay", "提前通知天數", "15", "設定契約到期提前通知的天數", "TextBox", "", "String");
            this.contractTypeTableAdapter.Fill(this.basDS.ContractType);
            SystemFunction.SetComboBoxItems(cbContractType, CodeFunction.GetContractType(), true, false ,true); //合同種類
            SystemFunction.CheckAppConfigRule(button1);
            this.wORKCDTableAdapter.Fill(this.basDS.WORKCD);
            SystemFunction.SetComboBoxItems(cbWORKCD, CodeFunction.GetWorkcd(), true, false, true); //派駐區
            this.contractTableAdapter.FillByInit(this.basDS.Contract);
            Sal.Function.SetAvaliableVBase(this.mainDS.V_BASE);

            fullDataCtrl1.DataAdapter = contractTableAdapter;

            FRM12DataClassesDataContext dbBas = new FRM12DataClassesDataContext();
            ContractTypeList = dbBas.ContractType.ToList();

            BasDataClassesDataContext db = new BasDataClassesDataContext();

            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("Contract");
            fullDataCtrl1.Init_Ctrls();
            label8.Text = "";
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
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

            if (!e.Cancel)
            {
                if (!Sal.Function.CanModify(e.Values["nobr"].ToString()))
                {
                    e.Cancel = true;
                    MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (Convert.ToDateTime(e.Values["adate"]) > Convert.ToDateTime(e.Values["ddate"]))
                {
                    e.Cancel = true;
                    MessageBox.Show("合同到期日期不能小於起始日期", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (Convert.ToDateTime(txtAlertDate.Text) < Convert.ToDateTime(e.Values["adate"]))
                {
                    e.Cancel = true;
                    MessageBox.Show("合同提醒日期不能小於起始日期", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (CheckRepeat(Convert.ToInt32(e.Values["AutoKey"]), e.Values["nobr"].ToString(), e.Values["contractType"].ToString(), Convert.ToDateTime(e.Values["adate"]), Convert.ToDateTime(e.Values["ddate"])))
                {
                    e.Cancel = true;
                    MessageBox.Show("合同的有效期間重複，請檢查輸入的資料是否正確", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (Sal.Function.CheckLeaveForbid(e.Values["nobr"].ToString(), Convert.ToDateTime(e.Values["adate"])))
                {
                    e.Cancel = true;
                    MessageBox.Show("離職人員不可新增合同", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                e.Values["AlertDay"] = txtAlertDay.Text;
                e.Values["keyman"] = MainForm.USER_NAME;
                e.Values["keydate"] = DateTime.Now;
                //NotifyMsgFacade obj = new NotifyMsgFacade();
                //try
                //{
                //    obj.NotifyAdate = Convert.ToDateTime(e.Values["ddate"]).AddDays(Convert.ToInt32(e.Values["alertDay"]) * -1);
                //    obj.SourceProgram = "FRM1O";
                //    obj.SourceSystem = "JBHR";
                //    obj.Title = "合同到期通知";
                //    obj.Message = "員工:" + e.Values["nobr"].ToString() + "的合同將於" + Convert.ToDateTime(e.Values["ddate"]).ToString("yyyy/MM/dd") + "到期";
                //    //obj.AddAttachmentFile(@"C:\Download\新舊職能積分比較表.xlsx");
                //    obj.AddNotifyMsgTargetType(e.Values["nobr"].ToString(), NotifyTargetTypeEnum.Emp, NotifyTypeEnum.Board, NotifyTypeEnum.Email);
                //    obj.Save();
                //    obj.Process();
                //    e.Values["NotifyMessageGuid"] = obj.Guid;
                //}
                //catch (Exception ex)
                //{
                //    JBModule.Message.TextLog.WriteLog(ex);
                //    //e.Cancel = true;
                //}
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            txtAdate.Text = Sal.Function.GetDate();
            txtDDate.Text = DateTime.MaxValue.ToString("yyyy/MM/dd");

            acg = new JBModule.Data.ApplicationConfigSettings("Contract",MainForm.COMPANY);
            var cfg = acg.GetConfig("AlertDay");
            txtAlertDay.Text = cfg.GetString();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
                CheckAlertDate();
        }
        private void cbContractType_SelectedIndexChange(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
                CheckContractDefaultMonthSpan();
        }
        private void txtAdate_Validated(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
                CheckContractDefaultMonthSpan();
        }
        private void dataGridViewEx1_SelectionChanged(object sender, EventArgs e)
        {
            CheckTimeSpan();
            CheckAlertDate();
        }
        private void txtDDate_Validated(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
                CheckAlertDate();
        }
        private void txtAlertDay_TextChanged(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
                CheckAlertDate();
        }
        private void txtDDate_TextChanged(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
                CheckTimeSpan();
        }
        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                var dd = Convert.ToDateTime(txtAdate.Text);
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from a in db.BASETTS where a.NOBR == e.code && a.ADATE <= dd && a.DDATE >= dd select a;
                if (sql.Any())
                {
                    cbWORKCD.SelectedValue = sql.First().WORKCD;
                    cbWORKCD.Focus();
                    cbContractType.Focus();
                }
            }
        }
        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
        }

        void CheckTimeSpan()
        {
            try
            {
                DateTime ADATE = Convert.ToDateTime(txtAdate.Text);
                DateTime DDATE = Convert.ToDateTime(txtDDate.Text);
                var ts = DDATE.AddDays(1) - ADATE;//相減要加一天
                string value = ts.SpanTimeString("y年M月");
                label8.Text = value;
            }
            catch
            {
                label8.Text = "";
            }
        }
        void CheckContractDefaultMonthSpan()
        {
            try
            {
                string contractType = cbContractType.SelectedValue.ToString();
                var sql = from a in ContractTypeList where a.Code == contractType select a;
                if (sql.Any())
                {
                    var row = sql.First();
                    int ms = row.MonthSpan;
                    DateTime d1, d2;
                    d1 = Convert.ToDateTime(txtAdate.Text);
                    d2 = d1.AddMonths(ms).AddDays(-1);
                    txtDDate.Text = d2.ToString("yyyy/MM/dd");
                    CheckAlertDate();
                }
            }
            catch
            {

            }
        }
        void CheckAlertDate()
        {
            try
            {
                DateTime DDATE = Convert.ToDateTime(txtDDate.Text);
                int alertDay = Convert.ToInt32(txtAlertDay.Text);
                DateTime AlertDate = DDATE.AddDays(-1 * alertDay);
                txtAlertDate.Text = AlertDate.ToString("yyyy/MM/dd");
            }
            catch
            {
                txtAlertDate.Text = "";
            }
        }
        bool CheckRepeat(int AutoKey, string Nobr, string ContractType, DateTime Adate, DateTime Ddate)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.Contract where a.AutoKey != AutoKey && a.Nobr == Nobr && a.ContractType == ContractType && a.Adate <= Ddate && a.Ddate >= Adate select a;
            return sql.Any();
        }

        private void bnIMPORT_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;

            frm.FieldForm = new FRM1OIN();
            frm.DataTransfer = new ImportContractData();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.mainDS.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("合同種類", this.basDS.ContractType.Select(p => new JBControls.CheckImportData { DisplayCode = p.Code, RealCode = p.Code, DisplayName = p.DisplayName, CheckValue1 = p.DisplayName }).ToList());
            frm.DataTransfer.CheckData.Add("派駐區", this.basDS.WORKCD.Select(p => new JBControls.CheckImportData { DisplayCode = p.WORK_CODE, RealCode = p.WORK_CODE, DisplayName = p.WORK_ADDR, CheckValue1 = p.WORK_ADDR }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("合同種類", typeof(string));
            frm.DataTransfer.ColumnList.Add("派駐區", typeof(string));
            frm.DataTransfer.ColumnList.Add("起始日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("到期日期", typeof(DateTime));
            //frm.DataTransfer.ColumnList.Add("備註", typeof(string));

            frm.ShowDialog();
        }

        private void fullDataCtrl1_BeforeEdit(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            acg = new JBModule.Data.ApplicationConfigSettings("Contract", MainForm.COMPANY);
            var cfg = acg.GetConfig("AlertDay");
            txtAlertDay.Text = cfg.GetString();
        }
    }
}