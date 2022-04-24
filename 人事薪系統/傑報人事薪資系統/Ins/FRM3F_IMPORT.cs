using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Ins
{
    public partial class FRM3F_IMPORT : JBControls.U_FIELD
    {
        public FRM3F_IMPORT()
        {
            InitializeComponent();
            //BindingControls.Add(txtYYMM);
            BindingControls.Add(comboBox1);
            BindingControls.Add(comboBox2);
            //BindingControls.Add(comboBox3);
            BindingControls.Add(comboBox4);
        }
        private void FRM3F_IMPORT_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(comboBoxInsType, CodeFunction.GetMtCode("INSUR_TYPE"));
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(DateTime.Today, true);
            sd = sd.GetPrevSalaryDate();
            txtYYMM.Text = sd.FirstDayOfMonth.ToString("yyyyMM");
            LoadColumnSettings();
        }
        private void buttonConfig_Click(object sender, EventArgs e)
        {
            CombinationData = new DataTable();
            foreach (var it in BindingControls)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = it.Tag.ToString();
                CombinationData.Columns.Add(dc);
            }
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = txtYYMM.Tag.ToString();
            CombinationData.Columns.Add(dc1);
            var yymm = txtYYMM.Text;

            dc1 = new DataColumn();
            dc1.ColumnName = comboBoxInsType.Tag.ToString();
            CombinationData.Columns.Add(dc1);
            string insType = comboBoxInsType.SelectedValue.ToString();

            foreach (DataRow r in Source.Rows)
            {
                DataRow ri = CombinationData.NewRow();
                SetBindingData(ri, r);

                ri[txtYYMM.Tag.ToString()] = yymm;
                ri[comboBoxInsType.Tag.ToString()] = insType;

                CombinationData.Rows.Add(ri);
            }
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(txtYYMM.Text);

            JBModule.Data.Linq.HrDBDataContext hrdb = new JBModule.Data.Linq.HrDBDataContext();
            var CheckListOfEmpData = (from a in hrdb.BASE
                                          //join b in hrdb.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals b.NOBR
                                      join c in hrdb.INSLAB on a.NOBR equals c.NOBR
                                      where c.IN_DATE <= sd.LastDayOfMonth && c.OUT_DATE >= sd.FirstDayOfMonth
                                      && c.FA_IDNO.Trim().Length == 0
                                      && (from bts in hrdb.BASETTS
                                          where bts.NOBR == a.NOBR
                                          && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                          && (from urdg in hrdb.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                          select 1).Any()
                                      select new JBControls.CheckImportData
                                      {
                                          RealCode = a.NOBR,
                                          DisplayCode = a.IDNO,
                                          DisplayName = a.NAME_C,
                                          CheckValue1 = a.MATNO,
                                          CheckValue2 = a.TAXNO,
                                      }
                                      ).ToList();
            var CheckListOfFamilyData = (from a in hrdb.FAMILY
                                             //join b in hrdb.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals b.NOBR
                                         join c in hrdb.INSLAB on new { a.NOBR, a.FA_IDNO } equals new { c.NOBR, c.FA_IDNO }
                                         where c.IN_DATE <= sd.LastDayOfMonth && c.OUT_DATE >= sd.FirstDayOfMonth
                                         && c.FA_IDNO.Trim().Length > 0
                                         && (from bts in hrdb.BASETTS
                                             where bts.NOBR == a.NOBR
                                             && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                             && (from urdg in hrdb.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                             select 1).Any()
                                         select new JBControls.CheckImportData
                                         {
                                             RealCode = a.NOBR,
                                             DisplayCode = a.FA_IDNO,
                                             DisplayName = a.FA_NAME,
                                             ReturnValue = a.FA_IDNO,
                                         }
                                   ).ToList();
            var CheckListOfEmpDataAll = (from a in hrdb.BASE
                                         where (from bts in hrdb.BASETTS
                                                where bts.NOBR == a.NOBR
                                                && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                                && (from urdg in hrdb.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                                select 1).Any()
                                         select new JBControls.CheckImportData
                                         {
                                             RealCode = a.NOBR,
                                             DisplayCode = a.IDNO,
                                             DisplayName = a.NAME_C,
                                             CheckValue1 = a.MATNO,
                                             CheckValue2 = a.TAXNO,
                                         }
                                    ).ToList();
            this.ImportTransfer.CheckData["身分證號"] = CheckListOfEmpData.Union(CheckListOfFamilyData).Union(CheckListOfEmpDataAll).ToList();
            this.Close();
        }
    }
    public class InsuranceCompareImport : JBControls.ImportTransfer
    {
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            string Msg = "";
            //TargetRow["個人負擔"] = Math.Round(Convert.ToDecimal(SourceRow["個人負擔"]), MidpointRounding.AwayFromZero);
            if (ColumnValidate(TargetRow, "身分證號", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["員工姓名"] = Msg;
            }
            else
            {
                if (ColumnValidate(TargetRow, "眷屬證號", TransferCheckDataField.DisplayName, out Msg))
                {
                    TargetRow["員工姓名"] = Msg;
                }
                else
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] = Msg;
                    }
                }
            }

            if (ColumnValidate(TargetRow, "身分證號", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["員工編號"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }
            if (ColumnValidate(TargetRow, "身分證號", TransferCheckDataField.ReturnValue, out Msg))
            {
                TargetRow["眷屬證號"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            return true;

        }

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            JBModule.Data.Linq.INPOLAB_TMP instance = new JBModule.Data.Linq.INPOLAB_TMP();
            instance.NOBR = TransferRow["員工編號"].ToString();
            instance.FA_IDNO = TransferRow["身分證號"].ToString();
            instance.YYMM = TransferRow["保險年月"].ToString();
            instance.INSUR_TYPE = TransferRow["費用種類"].ToString();
            if (TransferRow["個人負擔"] != DBNull.Value)
                instance.EXP = Convert.ToDecimal(TransferRow["個人負擔"]);
            if (TransferRow["公司負擔"] != DBNull.Value)
                instance.COMP = Convert.ToDecimal(TransferRow["公司負擔"]);
            instance.ADATE = new DateTime(1900, 1, 1);
            instance.DAYS = 0;
            instance.INSCD = 0;
            instance.RATE_CODE = "";
            var empData = CheckData["員工資料"].Where(p => p.RealCode == instance.NOBR);
            if (empData.Any())
                instance.SALADR = empData.First().ReturnValue;
            else instance.SALADR = MainForm.WriteRules.First().DATAGROUP;
            ErrorMsg = "";
            return Save(instance, out ErrorMsg);
        }
        public bool Save(JBModule.Data.Linq.INPOLAB_TMP instance, out string Msg)
        {
            try
            {
                Msg = "";
                var sql = from a in db.INPOLAB_TMP
                          where a.NOBR == instance.NOBR && a.FA_IDNO == instance.FA_IDNO
                          && a.YYMM == instance.YYMM && a.INSUR_TYPE == instance.INSUR_TYPE
                          select a;
                if (sql.Any())
                {
                    var r = sql.First();
                    if (instance.EXP != null)
                        r.EXP = instance.EXP;
                    if (instance.COMP != null)
                        r.COMP = instance.COMP;
                    r.KEY_DATE = DateTime.Now;
                    r.KEY_MAN = MainForm.USER_NAME;

                }
                else
                {
                    if (instance.EXP == null)
                        instance.EXP = 0;
                    if (instance.COMP == null)
                        instance.COMP = 0;
                    instance.KEY_DATE = DateTime.Now;
                    instance.KEY_MAN = MainForm.USER_NAME;
                    db.INPOLAB_TMP.InsertOnSubmit(instance);
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                JBModule.Message.TextLog.WriteLog(ex);
            }
            return false;
        }

    }
}
