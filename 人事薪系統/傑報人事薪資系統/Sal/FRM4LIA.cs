using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JBHR.Sal
{
    public partial class FRM4LIA : JBControls.U_FIELD
    {
        public FRM4LIA()
        {
            InitializeComponent();
            //BindingControls.Add(cbAmt);
            //BindingControls.Add(cbMemo);
            BindingControls.Add(cbNobr);
            //BindingControls.Add(cbxSalcode);
            //BindingControls.Add(cbFA_IDNO);
            BindingControls.Add(cbYymm);
            BindingControls.Add(cbSeq);
        }

        private void FRM4LI_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbNobr);
            cc.AddControl(cbYymm);
            cc.AddControl(cbSeq);
            //cc.AddControl(cbxSalcode);
            //cc.AddControl(cbAmt);
        }
        CheckControl cc;//必填欄位
        private void btnImport_Click(object sender, EventArgs e)
        {
            var salcodeList = new JBModule.Data.Linq.HrDBDataContext().SALCODE.Select(p => new { SAL_CODE_DISP = p.SAL_CODE_DISP.Trim(), SAL_NAME = p.SAL_NAME.Trim() }).ToList();
            var ctrl = cc.CheckText();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            CombinationData = new DataTable();
            List<string> BindingColumn = new List<string>();
            foreach (var it in BindingControls)
            {
                BindingColumn.Add(it.Text);
                DataColumn dc = new DataColumn();
                dc.ColumnName = it.Tag.ToString();
                CombinationData.Columns.Add(dc);
            }
            DataColumn dcc = new DataColumn();
            dcc.ColumnName = "備註";
            CombinationData.Columns.Add(dcc);

            //this.AutoMappingData();
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "薪資代碼";
            CombinationData.Columns.Add(dc1);
            dc1 = new DataColumn();
            dc1.ColumnName = "金額";
            CombinationData.Columns.Add(dc1);
            //dc1 = new DataColumn();
            //dc1.ColumnName = "公司別";
            //CombinationData.Columns.Add(dc1);
            //var adate = Convert.ToDateTime(txtAdate.Text);
            foreach (DataColumn dc in Source.Columns)
            {
                if (cbNobr.Text != dc.ColumnName)//沒有設定繫結的都寫入
                    foreach (DataRow r in Source.Rows)
                    {
                        if (r[cbNobr.Text].ToString().Trim().Length > 0)
                        {
                            DataRow ri = CombinationData.NewRow();
                            if (!BindingColumn.Contains(dc.ColumnName))//沒有設定繫結的都寫入
                            {
                                SetBindingData(ri, r);
                                ri["備註"] = "";
                                //ri["計薪年月"] = cbYymm.Text;
                                //ri["期別"] = cbSeq.Text;

                                ri["薪資代碼"] = dc.ColumnName;
                                ri["金額"] = r[dc.ColumnName];
                                decimal amt = 0;
                                if (decimal.TryParse(r[dc.ColumnName].ToString(), out amt) && Convert.ToDecimal(r[dc.ColumnName]) == 0)
                                    continue;
                                if (r[dc.ColumnName].ToString().Trim().Length == 0)//排除空白，不然最後會變成0
                                    continue;
                                if (!BindingColumn.Contains(dc.ColumnName))
                                {
                                    var salcode = salcodeList.SingleOrDefault(p => p.SAL_NAME == dc.ColumnName);
                                    if (salcode != null)
                                    {
                                        if (salcode.SAL_CODE_DISP.ToUpper().IndexOf("ZZ") == 0)//ZZ開頭
                                        {
                                            ri["薪資代碼"] = salcode.SAL_NAME;
                                            ri["金額"] = 0;
                                            ri["備註"] = salcode.SAL_NAME + "：" + r[salcode.SAL_NAME];
                                        }
                                    }
                                }
                                CombinationData.Rows.Add(ri);
                            }
                        }
                    }
            }
            this.Close();
        }


    }
    public class ImportTransferToENRICH_Wage : JBControls.ImportTransfer
    {
        #region IImportTransfer 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            try
            {
                string YYMM = TransferRow["計薪年月"].ToString();
                string SEQ = TransferRow["期別"].ToString();
                string NOBR = TransferRow["員工編號"].ToString();
                string FA_IDNO = "";// TransferRow["眷屬身號"].ToString();
                string SAL_CODE = TransferRow["薪資代碼"].ToString();
                string MEMO = TransferRow["備註"].ToString();
                decimal AMT = Convert.ToDecimal(TransferRow["金額"]);
                JBModule.Data.Linq.ENRICH r = new JBModule.Data.Linq.ENRICH();
                r.NOBR = NOBR;
                r.SAL_CODE = CheckData["薪資代碼"].Where(p => p.DisplayCode == SAL_CODE).First().RealCode;
                r.YYMM = YYMM;
                r.SEQ = SEQ;
                r.AMT = AMT;
                r.IMPORT = true;
                r.FA_IDNO = FA_IDNO;
                r.KEY_DATE = DateTime.Now;
                r.KEY_MAN = MainForm.USER_NAME;
                r.MEMO = MEMO;
                if (RepeatSelectionString != JBControls.U_IMPORT.Allow_Repeat_Override_String)
                {
                    var sql = (from a in db.ENRICH where a.NOBR == r.NOBR && a.FA_IDNO == r.FA_IDNO && a.YYMM == r.YYMM && a.SEQ == r.SEQ && a.SAL_CODE == r.SAL_CODE select a).ToList();
                    if (sql.Any())
                    {
                        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                        {
                            DeleteEnrich(r, out ErrMsg);
                        }
                        else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                        {
                            InsertEnrich(r, out ErrMsg);
                        }
                        else
                        {
                            InsertEnrich(r, out ErrMsg);
                        }
                    }
                    else
                    {
                        InsertEnrich(r, out ErrMsg);
                    }
                }
                else
                {
                    InsertEnrich(r, out ErrMsg);
                }

                //    if (sql.First().DDATE < new DateTime(9999, 12, 31))
                //    {
                //        ErrMsg += "已存在更新的薪資異動;";
                //        return false;
                //    }

                //    if (sql.First().ADATE == r.ADATE)
                //    {
                //        //if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Ignore_String)
                //        //{
                //        //    ErrMsg += "已存在相同日期的薪資異動;";
                //        //    return false;
                //        //}
                //        //else
                //        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                //        {
                //            DeleteSalbasd(r, out ErrMsg);
                //        }
                //        else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                //        {
                //            UpdateSalbasd(r, out ErrMsg);
                //        }
                //        else
                //        {
                //            ErrMsg += "已存在相同日期的薪資異動;";
                //            return false;
                //        }
                //    }
                //}
                //else
                //{
                //    InsertSalbasd(r, out ErrMsg);
                //}

            }
            catch (Exception ex)
            {
                ErrMsg += ex.Message + ";";
                return false;
            }
            return true;
        }
        bool DeleteEnrich(JBModule.Data.Linq.ENRICH Instance, out string Msg)
        {
            Instance.AMT = JBModule.Data.CEncrypt.Number(Instance.AMT);
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = (from a in db.ENRICH where a.NOBR == Instance.NOBR && a.FA_IDNO == Instance.FA_IDNO && a.YYMM == Instance.YYMM && a.SEQ == Instance.SEQ && a.SAL_CODE == Instance.SAL_CODE select a).ToList();
                if (sql.Any())//有資料
                {
                    db.ENRICH.DeleteAllOnSubmit(sql);
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
        bool InsertEnrich(JBModule.Data.Linq.ENRICH Instance, out string Msg)
        {
            Instance.AMT = JBModule.Data.CEncrypt.Number(Instance.AMT);
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                //var sql = (from a in db.ENRICH where a.NOBR == Instance.NOBR && a.FA_IDNO == Instance.FA_IDNO && a.YYMM == Instance.YYMM && a.SEQ == Instance.SEQ && a.SAL_CODE == Instance.SAL_CODE select a).ToList();
                //if (sql.Any())
                //{
                //    Msg += "已存在更新的薪資異動;";
                //    return false;
                //}
                //sql.Add(Instance);
                db.ENRICH.InsertOnSubmit(Instance);
                //foreach (var it in sql.OrderByDescending(pp => pp.YYMM))
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
        bool UpdateEnrich(JBModule.Data.Linq.ENRICH Instance, out string Msg)
        {
            var instanceRow = Instance.Clone();
            instanceRow.AMT = JBModule.Data.CEncrypt.Number(Instance.AMT);
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = (from a in db.ENRICH where a.NOBR == instanceRow.NOBR && a.FA_IDNO == instanceRow.FA_IDNO && a.YYMM == instanceRow.YYMM && a.SEQ == instanceRow.SEQ && a.SAL_CODE == instanceRow.SAL_CODE select a).ToList();
                if (sql.Any())
                {

                    //if (sql.Any())
                    //{
                    //    Msg += "已存在更新的薪資異動;";
                    //    return false;
                    //}

                    var rCurrent = sql.First();
                    rCurrent.AMT = instanceRow.AMT;
                    rCurrent.MEMO = instanceRow.MEMO;
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
        JBModule.Data.Linq.ENRICH GetEnrich(string EmployeeId, string FA_IDNO, string YYMM, string SEQ, string SalCodeDisp)
        {
            string msg = "";
            if (ColumnValidate(SalCodeDisp, "薪資代碼", TransferCheckDataField.RealCode, out msg))
            {
                string salcode = msg;
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from a in db.ENRICH where a.NOBR == EmployeeId && a.FA_IDNO == FA_IDNO && a.YYMM == YYMM && a.SEQ == SEQ && a.SAL_CODE == salcode select a;
                if (sql.Any())
                {
                    var r = sql.First().Clone();
                    r.AMT = JBModule.Data.CDecryp.Number(r.AMT);
                    return r;
                }
            }

            return null;
        }
        #endregion

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            string Msg = "";
            decimal amt = 0;
            if (!decimal.TryParse(SourceRow["金額"].ToString(), out amt))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }
            TargetRow["金額"] = amt;
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
            //if (SourceRow["眷屬身號"].ToString().Length != 0)
            //{
            //    if (ColumnValidate(TargetRow, "眷屬身號", TransferCheckDataField.DisplayName, out Msg))
            //    {
            //        TargetRow["眷屬姓名"] = Msg;
            //    }
            //    else
            //    {
            //        if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
            //        {
            //            TargetRow["錯誤註記"] = Msg;
            //        }
            //    }
            //}
            if (SourceRow["計薪年月"].ToString().Length != 0)
            {
                string yymm = SourceRow["計薪年月"].ToString();
                try
                {
                    var yy = int.Parse(yymm.Substring(0, 4));
                    var mm = int.Parse(yymm.Substring(4));

                    var d = new DateTime(yy, mm, 1);

                }
                catch
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] = "無效的資料[計薪年月］";
                    }
                }
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = "無效的資料[計薪年月］";
                }
            }

            //var enrich = GetEnrich(TargetRow["員工編號"].ToString(), TargetRow["眷屬身號"].ToString(), TargetRow["計薪年月"].ToString(), TargetRow["期別"].ToString(), TargetRow["薪資代碼"].ToString());
            //if (enrich != null)
            //{
            //    TargetRow["異動前金額"] = enrich.AMT;
            //    TargetRow["差異金額"] = Convert.ToDecimal(TargetRow["異動後金額"]) - enrich.AMT;
            //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
            //    {
            //        TargetRow["警告"] = "重複資料";
            //    }
            //}

            //if (enrich != null)
            //{
            //    TargetRow["異動前金額"] = enrich.AMT;
            //    TargetRow["差異金額"] = Convert.ToDecimal(TargetRow["異動後金額"]) - enrich.AMT;
            //    //if (enrich.DDATE != new DateTime(9999, 12, 31))
            //    //{
            //    //    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
            //    //    {
            //    //        TargetRow["錯誤註記"] = "已存在更新的調薪資料";
            //    //    }
            //    //}
            //}
            //else
            //{
            //    enrich = GetEnrich(TargetRow["員工編號"].ToString(), new DateTime(9999,12,31), TargetRow["薪資代碼"].ToString());
            //    if (enrich != null)//在異動日期之後還有資料
            //    {
            //        TargetRow["錯誤註記"] = "已存在更新的調薪資料";
            //        TargetRow["異動前金額"] = enrich.AMT;
            //        TargetRow["差異金額"] = Convert.ToDecimal(TargetRow["異動後金額"]) - enrich.AMT;                  
            //    }
            //}

            return true;
        }
    }

}