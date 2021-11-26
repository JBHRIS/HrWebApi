using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM1Q_IMPORT : JBControls.U_FIELD
    {
        public FRM1Q_IMPORT()
        {
            InitializeComponent();
            BindingControls.Add(comboBox1);
            BindingControls.Add(comboBox2);
            BindingControls.Add(comboBox3);
            BindingControls.Add(comboBox4);
            BindingControls.Add(comboBoxValue);
            BindingControls.Add(comboBoxNote);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CombinationData = new DataTable();
            foreach (var it in BindingControls)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = it.Tag.ToString();
                CombinationData.Columns.Add(dc);
            }

            foreach (DataRow r in Source.Rows)
            {
                DataRow ri = CombinationData.NewRow();
                SetBindingData(ri, r);
                CombinationData.Rows.Add(ri);
            }
            this.Close();
        }

        private void FRM1P_IMPORT_Load(object sender, EventArgs e)
        {
            LoadColumnSettings();
        }
    }
    public class EmployeeRuleImportTransfer : JBControls.ImportTransfer
    {

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            string empid = SourceRow["員工編號"].ToString();
            string msg = "";
            if (ColumnValidate(SourceRow, "員工編號", TransferCheckDataField.DisplayName, out msg))
            {
                TargetRow["員工姓名"] = msg;
            }
            else
            {
                if (SourceRow.Table != null && SourceRow.Table.Columns.Contains("错误注记"))
                {
                    SourceRow["错误注记"] = msg;
                    return false;
                }
            }
            if (ColumnValidate(SourceRow, "規則種類", TransferCheckDataField.DisplayName, out msg))
            {
                TargetRow["規則種類名稱"] = msg;
            }
            else
            {
                if (SourceRow.Table != null && SourceRow.Table.Columns.Contains("错误注记"))
                {
                    SourceRow["错误注记"] = msg;
                    return false;
                }
            }
            return true;
        }

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            string empid = TransferRow["員工編號"].ToString();
            ErrorMsg = "";
            EmployeeRuleRepo rp = new EmployeeRuleRepo();
            JBModule.Data.Linq.EmployeeRule instance = new JBModule.Data.Linq.EmployeeRule();
            instance.NOBR = empid;
            instance.BeginDate = Convert.ToDateTime(TransferRow["開始日期"]);
            instance.EndDate = Convert.ToDateTime(TransferRow["結束日期"]);
            instance.KEY_DATE = DateTime.Now;
            instance.KEY_MAN = MainForm.USER_NAME;
            instance.Remark = "";
            instance.Value = TransferRow["設定值"].ToString();
            instance.Remark = TransferRow["備註"].ToString();
            instance.RuleType = TransferRow["規則種類"].ToString();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.EmployeeRule
                      where a.Auto != instance.Auto && a.NOBR == instance.NOBR
                      && a.RuleType == instance.RuleType
                          && a.BeginDate <= instance.EndDate && a.EndDate >= instance.BeginDate
                      select a;
            if (sql.Any())
            {
                if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                {
                    return rp.Update(instance, out ErrorMsg);
                }
                else
                {
                    ErrorMsg = "時段重複";
                    return false;
                }
            }
            else
                return rp.Insert(instance, out ErrorMsg);
        }
    }
    public class EmployeeRuleRepo
    {
        public bool Insert(JBModule.Data.Linq.EmployeeRule instance, out string Msg)
        {
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                //var sql = from a in db.EmployeeRule
                //          where a.Auto != instance.Auto && a.NOBR == instance.NOBR
                //              && a.BeginDate <= instance.EndDate && a.EndDate <= instance.BeginDate
                //          select a;
                //if(sql.Any())
                //{
                //    Msg = "時段重複";
                //    return false;
                //}
                db.EmployeeRule.InsertOnSubmit(instance);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }
        }
        public bool Update(JBModule.Data.Linq.EmployeeRule instance, out string Msg)
        {
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from a in db.EmployeeRule
                          where a.NOBR == instance.NOBR
                              && a.BeginDate == instance.BeginDate
                          select a;
                if (sql.Any())
                {
                    var rr = sql.First();
                    rr.EndDate = instance.EndDate;
                    rr.KEY_DATE = DateTime.Now;
                    rr.KEY_MAN = MainForm.USER_NAME;
                    rr.Remark = instance.Remark;
                    rr.Value = instance.Value;
                }
                else
                {
                    Msg = "找不到相同生效日期的資料";
                    return false;
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }
        }
    }
}
