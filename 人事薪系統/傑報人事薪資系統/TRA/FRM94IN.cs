using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JBHR.TRA
{
    public partial class FRM94IN : JBControls.U_FIELD
    {
        public FRM94IN()
        {
            InitializeComponent();
            BindingControls.Add(cbxCOURSE);
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxTR_ASDATE);
            BindingControls.Add(cbxAT_HRS);
            BindingControls.Add(cbxCLOSE_);
            BindingControls.Add(cbxST_HRS);
            BindingControls.Add(cbxAVL);
            BindingControls.Add(cbxAPPLYNO);
            BindingControls.Add(cbxTR_REPO);
            BindingControls.Add(cbxTR_MEMO);
        }
        private void FRM94IN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxCOURSE);
            cc.AddControl(cbxNOBR);
        }
        CheckControl cc;//必填欄位
        private void btnImport_Click(object sender, EventArgs e)
        {
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
            foreach (var it in BindingControls)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = it.Tag.ToString();
                CombinationData.Columns.Add(dc);
            }

            //var adate = Convert.ToDateTime(txtAdate.Text);
            foreach (DataRow r in Source.Rows)
            {
                DataRow ri = CombinationData.NewRow();
                SetBindingData(ri, r);
                CombinationData.Rows.Add(ri);
            }
            this.Close();
        }





    }
    public class ImportTransferToTRCOSP : JBControls.ImportTransfer
    {
        #region IImportTransfer 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                string NOBR = TransferRow["員工編號"].ToString();
                string COURSE = TransferRow["課程代碼"].ToString();
                string TR_ASDATE = TransferRow["完成評核日"].ToString();
                string AT_HRS = TransferRow["缺課時數"].ToString();
                string ST_HRS = TransferRow["已訓時數"].ToString();
                string APPLYNO = TransferRow["申請編號"].ToString();
                string CLOSE_ = TransferRow["是否結訓"].ToString();
                string TR_REPO = TransferRow["是否完成評核"].ToString();
                string KAVL = TransferRow["是否合格"].ToString();
                string TR_MEMO = TransferRow["備註"].ToString();


                JBModule.Data.Linq.TRCOSP TRCOSP = new JBModule.Data.Linq.TRCOSP();

                TRCOSP.NOBR = NOBR;
                TRCOSP.COURSE = GetRealCode("課程代碼", COURSE);
                TRCOSP.TR_ASDATE = string.IsNullOrWhiteSpace(TR_ASDATE) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(TR_ASDATE);
                TRCOSP.AT_HRS = string.IsNullOrWhiteSpace(AT_HRS) ? 0 : Convert.ToDecimal(AT_HRS);
                TRCOSP.ST_HRS = string.IsNullOrWhiteSpace(ST_HRS) ? 0 : Convert.ToDecimal(ST_HRS);
                TRCOSP.APPLYNO = APPLYNO;
                TRCOSP.CLOSE_ = string.IsNullOrWhiteSpace(CLOSE_) ? false : Convert.ToBoolean(CLOSE_);
                TRCOSP.TR_REPO = string.IsNullOrWhiteSpace(TR_REPO) ? false : Convert.ToBoolean(TR_REPO);
                TRCOSP.KAVL = KAVL;
                TRCOSP.TR_MEMO = TR_MEMO;
                TRCOSP.KEY_DATE = DateTime.Now;
                TRCOSP.KEY_MAN = MainForm.USER_NAME;
                TRCOSP.PROVE = "";
                TRCOSP.RECEIVER = "";


                //找出重複的資料
                var sql = db.TRCOSP.Where(p => p.NOBR == NOBR && p.COURSE == TRCOSP.COURSE);
                if (sql.Any())
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        DeleteTRCOSP(TRCOSP, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        UpdateTRCOSP(TRCOSP, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同課程代碼的資料";
                        return false;
                    }
                }
                else
                {
                    InsertTRCOSP(TRCOSP, out ErrMsg);
                }

                

            }
            catch (Exception ex)
            {
                ErrMsg += ex.Message + ";";
                return false;
            }
            return true;
        }

        public string GetRealCode (string key, string dispCode)
        {
            return CheckData[key].Where(p => p.DisplayCode == dispCode || p.DisplayName == dispCode).First().RealCode;
        }

        bool DeleteTRCOSP(JBModule.Data.Linq.TRCOSP TRCOSP, out string Msg)
        {
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = db.TRCOSP.Where(p=>p.NOBR == TRCOSP.NOBR && p.COURSE == TRCOSP.COURSE);
                if (sql.Any())//有資料
                {
                    db.TRCOSP.DeleteAllOnSubmit(sql);
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
        bool InsertTRCOSP(JBModule.Data.Linq.TRCOSP TRCOSP, out string Msg)
        {
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = db.TRCOSP.Where(p => p.NOBR == TRCOSP.NOBR && p.COURSE == TRCOSP.COURSE);
                if (sql.Any())
                {
                    Msg += "与已存在合同的生失效日期有所重叠;";
                    return false;
                }
                db.TRCOSP.InsertOnSubmit(TRCOSP);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }

            return true;
        }
        bool UpdateTRCOSP(JBModule.Data.Linq.TRCOSP TRCOSP, out string Msg)
        {
            //var instanceRow = Instance.Clone();
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = db.TRCOSP.Where(p => p.NOBR == TRCOSP.NOBR && p.COURSE == TRCOSP.COURSE);
                if (sql.Any())
                {
                    var rCurrent = sql.First();

                    rCurrent.APPLYNO = TRCOSP.APPLYNO;
                    rCurrent.AT_HRS = TRCOSP.AT_HRS;
                    rCurrent.CLOSE_ = TRCOSP.CLOSE_;
                    rCurrent.COURSE = TRCOSP.COURSE;
                    rCurrent.KAVL = TRCOSP.KAVL;
                    rCurrent.KEY_DATE = TRCOSP.KEY_DATE;
                    rCurrent.KEY_MAN = TRCOSP.KEY_MAN;
                    rCurrent.PROVE = TRCOSP.PROVE;
                    rCurrent.RECEIVER = TRCOSP.RECEIVER;
                    rCurrent.ST_HRS = TRCOSP.ST_HRS;
                    rCurrent.TR_ASDATE = TRCOSP.TR_ASDATE;
                    rCurrent.TR_MEMO = TRCOSP.TR_MEMO;
                    rCurrent.TR_REPO = TRCOSP.TR_REPO;

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
        
        #endregion

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string NOBR = SourceRow["員工編號"].ToString();
            string COURSE = SourceRow["課程代碼"].ToString();
            string TR_ASDATE = SourceRow["完成評核日"].ToString();
            string AT_HRS = SourceRow["缺課時數"].ToString();
            string ST_HRS = SourceRow["已訓時數"].ToString();
            string APPLYNO = SourceRow["申請編號"].ToString();
            string CLOSE_ = SourceRow["是否結訓"].ToString();
            string TR_REPO = SourceRow["是否完成評核"].ToString();
            string KAVL = SourceRow["是否合格"].ToString();
            string TR_MEMO = SourceRow["備註"].ToString();
            DateTime date = DateTime.MaxValue;
            decimal dec = 0;
            bool bo = false;
            string Msg = "";

            #region 檢查"是否結訓"
            if (!string.IsNullOrWhiteSpace(KAVL))
            {
                if (!bool.TryParse(CLOSE_, out bo))
                {
                    TargetRow["錯誤註記"] += errorMsg("是否結訓");
                }
            }
            #endregion

            #region 檢查"是否完成評核"
            if (!string.IsNullOrWhiteSpace(KAVL))
            {
                if (!bool.TryParse(TR_REPO, out bo))
                {
                    TargetRow["錯誤註記"] += errorMsg("是否完成評核");
                }
            }
            #endregion

            #region 檢查"是否合格"
            if (!string.IsNullOrWhiteSpace(KAVL))
            {
                if (!bool.TryParse(KAVL, out bo))
                {
                    TargetRow["錯誤註記"] += errorMsg("是否合格");
                }
            }
            #endregion

            #region 檢查"已訓時數"
            if (!string.IsNullOrWhiteSpace(ST_HRS))
            {
                if (!decimal.TryParse(ST_HRS, out dec))
                {
                    TargetRow["錯誤註記"] += errorMsg("已訓時數");
                }
            }
            #endregion

            #region 檢查"缺課時數"
            if (!string.IsNullOrWhiteSpace(AT_HRS))
            {
                if (!decimal.TryParse(AT_HRS, out dec))
                {
                    TargetRow["錯誤註記"] += errorMsg("缺課時數");
                }
            }
            #endregion

            #region 檢查"完成評核日"
            if (!string.IsNullOrWhiteSpace(TR_ASDATE))
            {
                if (!DateTime.TryParse(TR_ASDATE, out date))
                {
                    TargetRow["錯誤註記"] += errorMsg("完成評核日");
                }
            }
            #endregion

            #region 檢查"課程代碼"
            if (ColumnValidate(TargetRow, "課程代碼", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["課程名稱"] = Msg;
            }
            else
            {
                TargetRow["錯誤註記"] += Msg + ";";
            }
            #endregion

            #region 檢查"員工編號"
            if (ColumnValidate(TargetRow, "員工編號", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["員工姓名"] = Msg;
            }
            else
            {
                TargetRow["錯誤註記"] += errorMsg("員工編號");
            }
            #endregion

            #region 檢查"訓練人員有無重複"
            if (!string.IsNullOrWhiteSpace(NOBR) && !string.IsNullOrWhiteSpace(COURSE))
            {
                var sql = db.TRCOSP.Where(p => p.NOBR == NOBR && p.COURSE == GetRealCode("課程代碼", COURSE));
                if (sql.Any())
                    TargetRow["警告"] = "重複資料";
            }
            #endregion

            return true;
        }
        string errorMsg(string name)
        {
            string msg = "無效的資料["+name+"];";
            return msg;
        }
    }

}