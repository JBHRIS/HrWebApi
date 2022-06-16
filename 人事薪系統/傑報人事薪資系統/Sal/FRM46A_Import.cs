using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace JBHR.Sal
{
    public partial class FRM46A_Import : JBControls.U_FIELD
    {
        public FRM46A_Import()
        {
            InitializeComponent();
            BindingControls.Add(cbADate);
            //cbAmt.Tag = "AMT";
            BindingControls.Add(cbAmt);
            //cbMemo.Tag = "MEMO";
            BindingControls.Add(cbMemo);
            //cbNobr.Tag = "NOBR";
            BindingControls.Add(cbNobr);
            //cbxSalcode.Tag = "SAL_CODE";
            BindingControls.Add(cbxSalcode);
        }
        CheckControl cc;//必填欄位

        private void FRM46A_Import_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbADate);
            cc.AddControl(cbNobr);
            cc.AddControl(cbxSalcode);
            cc.AddControl(cbAmt);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var ctrl = cc.CheckText();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告註記", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
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
    }
    public class ImportTransferToSalbastd : JBControls.ImportTransfer
    {
        #region IImportTransfer 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            try
            {
                string NOBR = TransferRow["員工編號"].ToString();
                DateTime ADATE = Convert.ToDateTime(TransferRow["異動日期"]);
                string SAL_CODE = TransferRow["薪資代碼"].ToString();
                decimal AMT = Convert.ToDecimal(TransferRow["異動後金額"]);
                string MEMO = TransferRow["備註"].ToString();
                JBModule.Data.Linq.SALBASTD r = new JBModule.Data.Linq.SALBASTD();
                r.NOBR = NOBR;
                r.ADATE = ADATE;
                r.SAL_CODE = CheckData["薪資代碼"].Where(p => p.DisplayCode == SAL_CODE).First().RealCode;
                r.DDATE = new DateTime(9999, 12, 31);
                r.KEY_DATE = DateTime.Now;
                r.AMT = AMT;
                r.KEY_MAN = MainForm.USER_NAME;
                r.MENO = MEMO;
                var sql = (from a in db.SALBASTD where a.NOBR == r.NOBR && r.ADATE >= a.ADATE && r.ADATE <= a.DDATE && a.SAL_CODE == r.SAL_CODE select a).ToList();
                if (sql.Any())
                {
                    if (sql.First().DDATE < new DateTime(9999, 12, 31))
                    {
                        ErrMsg += "已存在更新的薪資異動;";
                        return false;
                    }

                    if (sql.First().ADATE == r.ADATE)
                    {
                        //if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Ignore_String)
                        //{
                        //    ErrMsg += "已存在相同日期的薪資異動;";
                        //    return false;
                        //}
                        //else
                        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                        {
                            DeleteSalbastd(r, out ErrMsg);
                        }
                        else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                        {
                            UpdateSalbastd(r, out ErrMsg);
                        }
                        else
                        {
                            ErrMsg += "已存在相同日期的薪資異動;";
                            return false;
                        }
                    }
                    else
                        InsertSalbastd(r, out ErrMsg);
                }
                else
                {
                    InsertSalbastd(r, out ErrMsg);
                }

            }
            catch (Exception ex)
            {
                ErrMsg += ex.Message + ";";
                return false;
            }
            return true;
        }
        bool DeleteSalbastd(JBModule.Data.Linq.SALBASTD Instance, out string Msg)
        {
            Instance.AMT = JBModule.Data.CEncrypt.Number(Instance.AMT);
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = (from a in db.SALBASTD where a.NOBR == Instance.NOBR && Instance.ADATE == a.ADATE && Instance.ADATE <= a.DDATE && a.SAL_CODE == Instance.SAL_CODE && a.DDATE == new DateTime(9999, 12, 31) select a).ToList();
                if (sql.Any())//有資料
                {
                    sql = (from a in db.SALBASTD where a.NOBR == Instance.NOBR && Instance.ADATE >= a.ADATE && Instance.ADATE <= a.DDATE && a.SAL_CODE == Instance.SAL_CODE select a).ToList();//取得同科目所有資料
                    var other = (from a in db.SALBASTD where a.NOBR == Instance.NOBR && a.SAL_CODE == Instance.SAL_CODE && a.DDATE != new DateTime(9999, 12, 31) orderby a.DDATE descending select a).ToList();//取得同科目所有数据
                    if (other.Any())
                    {//修改前一筆資料的失效日期為9999/12/31
                        var last = other.First();
                        last.DDATE = new DateTime(9999, 12, 31);
                    }
                    db.SALBASTD.DeleteAllOnSubmit(sql);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }

            return true;
        }
        bool InsertSalbastd(JBModule.Data.Linq.SALBASTD Instance, out string Msg)
        {
            Instance.AMT = JBModule.Data.CEncrypt.Number(Instance.AMT);
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = (from a in db.SALBASTD where a.NOBR == Instance.NOBR && Instance.ADATE >= a.ADATE && Instance.ADATE <= a.DDATE && a.SAL_CODE == Instance.SAL_CODE select a).ToList();
                if (sql.Any())
                {
                    if (sql.First().DDATE < new DateTime(9999, 12, 31))
                    {
                        Msg += "已存在更新的薪資異動;";
                        return false;
                    }
                    if (sql.First().ADATE == Instance.ADATE)
                    {
                        Msg += "已存在相同日期的薪資異動;";
                        return false;
                    }
                }
                //if(sql.Where(pp=>pp.ADATE==r.ADATE))//是否是同一天
                sql.Add(Instance);
                db.SALBASTD.InsertOnSubmit(Instance);
                DateTime ddate = new DateTime(9999, 12, 31);
                foreach (var it in sql.OrderByDescending(pp => pp.ADATE))
                {
                    it.DDATE = ddate;
                    ddate = it.ADATE.AddDays(-1);
                }
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }

            return true;
        }
        bool UpdateSalbastd(JBModule.Data.Linq.SALBASTD Instance, out string Msg)
        {
            var instanceRow = Instance.Clone();
            instanceRow.AMT = JBModule.Data.CEncrypt.Number(Instance.AMT);
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = (from a in db.SALBASTD where a.NOBR == instanceRow.NOBR && instanceRow.ADATE == a.ADATE && a.SAL_CODE == instanceRow.SAL_CODE select a).ToList();
                if (sql.Any())
                {
                    if (sql.First().DDATE < new DateTime(9999, 12, 31))
                    {
                        Msg += "已存在更新的薪資異動;";
                        return false;
                    }
                    var rCurrent = sql.First();
                    rCurrent.AMT = instanceRow.AMT;
                    rCurrent.MENO = instanceRow.MENO;
                    //if (sql.First().ADATE == instanceRow.ADATE)
                    //{
                    //    Msg += "已存在相同日期的薪資異動;";
                    //    return false;
                    //}
                }
                //if(sql.Where(pp=>pp.ADATE==r.ADATE))//是否是同一天
                //sql.Add(instanceRow);
                //db.SALBASD.InsertOnSubmit(Instance);
                //DateTime ddate = new DateTime(9999, 12, 31);
                //foreach (var it in sql.OrderByDescending(pp => pp.ADATE))
                //{
                //    it.DDATE = ddate;
                //    ddate = it.ADATE.AddDays(-1);
                //}
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }

            return true;
        }
        JBModule.Data.Linq.SALBASTD GetSalbastd(string EmployeeId, DateTime Adate, string SalCodeDisp)
        {
            string msg = "";
            if (ColumnValidate(EmployeeId, "員工編號", TransferCheckDataField.DisplayName, out msg))
            {
                if (ColumnValidate(SalCodeDisp, "薪資代碼", TransferCheckDataField.RealCode, out msg))
                {
                    string salcode = msg;
                    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                    var sql = from a in db.SALBASTD where a.NOBR == EmployeeId && Adate >= a.ADATE && Adate <= a.DDATE && a.SAL_CODE == salcode select a;
                    if (sql.Any())
                    {
                        var r = sql.First().Clone();
                        r.AMT = JBModule.Data.CDecryp.Number(r.AMT);
                        return r;
                    }
                }
            }
            return null;
        }
        #endregion

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            string Msg = "";
            TargetRow["異動後金額"] = Math.Round(Convert.ToDecimal(SourceRow["金額"]), MidpointRounding.AwayFromZero);
            if (ColumnValidate(TargetRow, "員工編號", TransferCheckDataField.DisplayName, out Msg))
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
            if (ColumnValidate(TargetRow, "薪資代碼", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["薪資名稱"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }
            var salbastd = GetSalbastd(TargetRow["員工編號"].ToString(), Convert.ToDateTime(TargetRow["異動日期"]), TargetRow["薪資代碼"].ToString());
            if (salbastd != null)
            {
                TargetRow["異動前金額"] = salbastd.AMT;
                TargetRow["差異金額"] = Convert.ToDecimal(TargetRow["異動後金額"]) - salbastd.AMT;
                if (salbastd.DDATE != new DateTime(9999, 12, 31))
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] = "已存在更新的調薪資料";
                    }
                }
            }
            else
            {
                salbastd = GetSalbastd(TargetRow["員工編號"].ToString(), new DateTime(9999, 12, 31), TargetRow["薪資代碼"].ToString());
                if (salbastd != null)//在異動日期之後還有資料
                {
                    TargetRow["錯誤註記"] = "已存在更新的調薪資料";
                    TargetRow["異動前金額"] = salbastd.AMT;
                    TargetRow["差異金額"] = Convert.ToDecimal(TargetRow["異動後金額"]) - salbastd.AMT;
                }
            }

            return true;
        }
    }
}
