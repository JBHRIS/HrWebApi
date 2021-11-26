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
    public partial class FRM1Q : JBControls.JBForm
    {
        CheckControl cc;
        public FRM1Q()
        {
            InitializeComponent();
        }
        JBModule.Data.ApplicationConfigSettings acg = new JBModule.Data.ApplicationConfigSettings("Contract", MainForm.COMPANY);
        List<ContractType> ContractTypeList = new List<ContractType>();
        private void FRM11M_Load(object sender, EventArgs e)
        {
            // TODO:  這行程式碼會將資料載入 'basDS.EmployeeRule' 資料表。您可以視需要進行移動或移除。
            this.employeeRuleTableAdapter.FillByInit(this.basDS.EmployeeRule);
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbRuleType);      //合同種類
            //cc.AddControl(cbWORKCD);      //派駐區
            #endregion

            //acg.CheckParameterAndSetDefault("AlertDay", "提前通知天數", "15", "設定契約到期提前通知的天數", "TextBox", "", "String");
            //this.contractTypeTableAdapter.Fill(this.basDS.ContractType);
            SystemFunction.SetComboBoxItems(cbRuleType, CodeFunction.GetRuleType(), true); //合同種類
            Sal.Function.SetAvaliableVBase(this.mainDS.V_BASE);

            fullDataCtrl1.DataAdapter = employeeRuleTableAdapter;

            BasDataClassesDataContext db = new BasDataClassesDataContext();

            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("FRM1Q");
            fullDataCtrl1.Init_Ctrls();
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
                if (Convert.ToDateTime(e.Values["BeginDate"]) > Convert.ToDateTime(e.Values["EndDate"]))
                {
                    e.Cancel = true;
                    MessageBox.Show("結束日期不能小於起始日期", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (CheckRepeat(Convert.ToInt32(e.Values["Auto"]), e.Values["nobr"].ToString(), e.Values["RuleType"].ToString(), Convert.ToDateTime(e.Values["BeginDate"]), Convert.ToDateTime(e.Values["EndDate"])))
                {
                    e.Cancel = true;
                    MessageBox.Show("有效期間重複，請檢查輸入的資料是否正確", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
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

            acg = new JBModule.Data.ApplicationConfigSettings("EmployeeRule", MainForm.COMPANY);
            //var cfg = acg.GetConfig("AlertDay");
            //txtAlertDay.Text = cfg.GetString();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            //if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
            //    CheckAlertDate();
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
            //CheckAlertDate();
        }
        private void txtDDate_Validated(object sender, EventArgs e)
        {
            //if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
            //    CheckAlertDate();
        }
        private void txtAlertDay_TextChanged(object sender, EventArgs e)
        {
            //if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
            //    CheckAlertDate();
        }
        private void txtDDate_TextChanged(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
                CheckTimeSpan();
        }
        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData)
            //{
            //    var dd = Convert.ToDateTime(txtAdate.Text);
            //    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //    var sql = from a in db.BASETTS where a.NOBR == e.code && a.ADATE <= dd && a.DDATE >= dd select a;
            //    if (sql.Any())
            //    {
            //        cbRuleType.Focus();
            //    }
            //}
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
            //try
            //{
            //    DateTime ADATE = Convert.ToDateTime(txtAdate.Text);
            //    DateTime DDATE = Convert.ToDateTime(txtDDate.Text);
            //    var ts = DDATE.AddDays(1) - ADATE;//相減要加一天
            //    string value = ts.SpanTimeString("y年M月");
            //    label8.Text = value;
            //}
            //catch
            //{
            //    label8.Text = "";
            //}
        }
        void CheckContractDefaultMonthSpan()
        {
            try
            {
                string contractType = cbRuleType.SelectedValue.ToString();
                var sql = from a in ContractTypeList where a.Code == contractType select a;
                if (sql.Any())
                {
                    var row = sql.First();
                    int ms = row.MonthSpan;
                    DateTime d1, d2;
                    d1 = Convert.ToDateTime(txtAdate.Text);
                    d2 = d1.AddMonths(ms).AddDays(-1);
                    txtDDate.Text = d2.ToString("yyyy/MM/dd");
                }
            }
            catch
            {

            }
        }
        bool CheckRepeat(int AutoKey, string Nobr, string sType, DateTime Adate, DateTime Ddate)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.EmployeeRule where a.Auto != AutoKey && a.NOBR == Nobr && a.RuleType == sType && a.BeginDate <= Ddate && a.EndDate >= Adate select a;
            return sql.Any();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.FieldForm = new FRM1Q_IMPORT();
            frm.DataTransfer = new EmployeeRuleImportTransfer();
            frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var dept = (from a in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN)
                        join b in db.BASE on a.NOBR equals b.NOBR
                        select new JBControls.CheckImportData
                        {
                            RealCode = a.NOBR,
                            DisplayCode = a.NOBR,
                            DisplayName = b.NAME_C
                        }).ToList();
            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.CheckData.Add("員工編號", dept);
            frm.DataTransfer.CheckData.Add("規則種類", db.RuleCode.Select(p => new JBControls.CheckImportData { RealCode = p.RuleCode1, DisplayCode = p.RuleCode1, DisplayName = p.RuleName }).ToList());
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("規則種類", typeof(string));
            frm.DataTransfer.ColumnList.Add("規則種類名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("開始日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("結束日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("設定值", typeof(string));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("错误注记", typeof(string));
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

    }
}