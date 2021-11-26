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
    public partial class FRM95IN : JBControls.U_FIELD
    {
        public FRM95IN()
        {
            InitializeComponent();
            BindingControls.Add(cbxCODE);
            BindingControls.Add(cbxCOURSE);
            BindingControls.Add(cbxDATE_B);
            BindingControls.Add(cbxDATE_E);
            BindingControls.Add(cbxDEPT);
            BindingControls.Add(cbxTR_INOUT);
            BindingControls.Add(cbxTR_PERSON);
            BindingControls.Add(cbxTRASSCODE);
            BindingControls.Add(cbxTRCOMP);
            BindingControls.Add(cbxTRTYPE);
            BindingControls.Add(cbxTR_HRS);
            BindingControls.Add(cbxTR_TEACH);
            BindingControls.Add(cbxABORAD);
            BindingControls.Add(cbxCOS_FEE);
            BindingControls.Add(cbxCOUNTRY);
            BindingControls.Add(cbxHANDOUT);
            BindingControls.Add(cbxPLANIN);
            BindingControls.Add(cbxPLANTO);
            BindingControls.Add(cbxTR_ISO);
            BindingControls.Add(cbxTR_MENO);
        }
        private void FRM95IN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxCODE);
            cc.AddControl(cbxCOURSE);
            cc.AddControl(cbxDATE_B);
            cc.AddControl(cbxDATE_E);
            cc.AddControl(cbxDEPT);
            cc.AddControl(cbxTR_INOUT);
            cc.AddControl(cbxTR_PERSON);
            cc.AddControl(cbxTRASSCODE);
            cc.AddControl(cbxTRCOMP);
            cc.AddControl(cbxTRTYPE);
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
    public class ImportTransferToTRCOSC : JBControls.ImportTransfer
    {
        #region IImportTransfer 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                string CODE = TransferRow["課程代碼"].ToString();
                string COURSE = TransferRow["課程名稱"].ToString();
                string DATE_B = TransferRow["開訓日期"].ToString();
                string DATE_E = TransferRow["結訓日期"].ToString();
                string TR_PERSON = TransferRow["訓練對象"].ToString();
                string TRCOMP = TransferRow["承辦單位"].ToString();
                string DEPT = TransferRow["開課部門"].ToString();
                string TRTYPE = TransferRow["課程類別"].ToString();
                string TRASSCODE = TransferRow["評核方式"].ToString();
                string TR_INOUT = TransferRow["訓練型式"].ToString();
                string TR_HRS = TransferRow["總時數"].ToString();
                string TR_TEACH = TransferRow["講師"].ToString();
                string COS_FEE = TransferRow["上課費用"].ToString();
                string COUNTRY = TransferRow["國家"].ToString();
                string HANDOUT = TransferRow["講義"].ToString();
                string TR_ISO = TransferRow["ISO"].ToString();
                string ABORAD = TransferRow["是否國外"].ToString();
                string PLANIN = TransferRow["是否計畫內"].ToString();
                string PLANTO = TransferRow["是否有課後問卷"].ToString();
                string TR_MENO = TransferRow["備註"].ToString();



                JBModule.Data.Linq.TRCOSC TRCOSC = new JBModule.Data.Linq.TRCOSC();

                TRCOSC.GUID = Guid.NewGuid().ToString();
                TRCOSC.CODE = CODE;
                TRCOSC.COURSE = COURSE;
                TRCOSC.DATE_B = Convert.ToDateTime(DATE_B);
                TRCOSC.DATE_E = Convert.ToDateTime(DATE_E);
                TRCOSC.TR_PERSON = TR_PERSON;
                TRCOSC.TR_COMP = GetRealCode("承辦單位", TRCOMP);
                TRCOSC.TR_DEPT = GetRealCode("開課部門", DEPT);
                TRCOSC.TR_TYPE = GetRealCode("課程類別", TRTYPE);
                TRCOSC.TR_ASNO = GetRealCode("評核方式", TRASSCODE);
                TRCOSC.TR_INOUT = GetRealCode("訓練型式", TR_INOUT);
                TRCOSC.TR_HRS = string.IsNullOrWhiteSpace(TR_HRS) ? 0 : Convert.ToDecimal(TR_HRS);
                TRCOSC.TR_TEACH = TR_TEACH;
                TRCOSC.TR_MEMO = TR_MENO;
                TRCOSC.ABORAD = string.IsNullOrWhiteSpace(ABORAD) ? false : Convert.ToBoolean(ABORAD);
                TRCOSC.COS_FEE = string.IsNullOrWhiteSpace(COS_FEE) ? 0 : Convert.ToDecimal(COS_FEE);
                TRCOSC.COUNTRY = COUNTRY;
                TRCOSC.HANDOUT = HANDOUT;
                TRCOSC.KEY_DATE = DateTime.Now;
                TRCOSC.KEY_MAN = MainForm.USER_NAME;
                TRCOSC.PLANIN = string.IsNullOrWhiteSpace(PLANIN) ? false : Convert.ToBoolean(PLANIN);
                TRCOSC.PLANTO = string.IsNullOrWhiteSpace(PLANTO) ? false : Convert.ToBoolean(PLANTO);
                TRCOSC.TR_ISO = TR_ISO;


                //找出重複的資料
                var sql = db.TRCOSC.Where(p=>p.CODE == CODE);
                if (sql.Any())
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        DeleteTRCOSC(TRCOSC, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        UpdateTRCOSC(TRCOSC, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同課程代碼的資料";
                        return false;
                    }
                }
                else
                {
                    InsertTRCOSC(TRCOSC, out ErrMsg);
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

        bool DeleteTRCOSC(JBModule.Data.Linq.TRCOSC TRCOSC, out string Msg)
        {
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = db.TRCOSC.Where(p => p.CODE == TRCOSC.CODE);
                if (sql.Any())//有資料
                {
                    db.TRCOSC.DeleteAllOnSubmit(sql);
                    var sql2 = db.TRCOSP.Where(q => q.COURSE == sql.First().GUID);
                    if (sql2.Any())
                    {
                        db.TRCOSP.DeleteAllOnSubmit(sql2);
                    }
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
        bool InsertTRCOSC(JBModule.Data.Linq.TRCOSC TRCOSC, out string Msg)
        {
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = db.TRCOSC.Where(p=>p.CODE == TRCOSC.CODE);
                if (sql.Any())
                {
                    Msg += "与已存在合同的生失效日期有所重叠;";
                    return false;
                }
                db.TRCOSC.InsertOnSubmit(TRCOSC);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }

            return true;
        }
        bool UpdateTRCOSC(JBModule.Data.Linq.TRCOSC TRCOSC, out string Msg)
        {
            //var instanceRow = Instance.Clone();
            Msg = "";
            try
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = db.TRCOSC.Where(p => p.CODE == TRCOSC.CODE);
                if (sql.Any())
                {
                    var rCurrent = sql.First();

                    rCurrent.COURSE = TRCOSC.COURSE;
                    rCurrent.DATE_B = TRCOSC.DATE_B;
                    rCurrent.DATE_E = TRCOSC.DATE_E;
                    rCurrent.TR_PERSON = TRCOSC.TR_PERSON;
                    rCurrent.TR_COMP = TRCOSC.TR_COMP;
                    rCurrent.TR_DEPT = TRCOSC.TR_DEPT;
                    rCurrent.TR_TYPE = TRCOSC.TR_TYPE;
                    rCurrent.TR_ASNO = TRCOSC.TR_ASNO;
                    rCurrent.TR_INOUT = TRCOSC.TR_INOUT;
                    rCurrent.TR_HRS = TRCOSC.TR_HRS;
                    rCurrent.TR_TEACH = TRCOSC.TR_TEACH;
                    rCurrent.COS_FEE = TRCOSC.COS_FEE;
                    rCurrent.COUNTRY = TRCOSC.COUNTRY;
                    rCurrent.HANDOUT = TRCOSC.HANDOUT;
                    rCurrent.TR_ISO = TRCOSC.TR_ISO;
                    rCurrent.ABORAD = TRCOSC.ABORAD;
                    rCurrent.PLANIN = TRCOSC.PLANIN;
                    rCurrent.PLANTO = TRCOSC.PLANTO;
                    rCurrent.TR_MEMO = TRCOSC.TR_MEMO;
                    rCurrent.KEY_MAN = TRCOSC.KEY_MAN;
                    rCurrent.KEY_DATE = TRCOSC.KEY_DATE;

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
        //找出相同生效時段的數據
        bool GetContract(string Nobr, DateTime Adate, DateTime Ddate, string ContractType)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.Contract where a.Nobr == Nobr && a.Adate == Adate && a.Ddate == Ddate && a.ContractType == ContractType select a;
            if (sql.Any())
            {
                return true;
            }
            return false;
        }
        //找出重疊生效時段的數據
        bool GetOverLapContract(string Nobr, DateTime Adate, DateTime Ddate, string ContractType)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            var sql = from a in db.Contract where a.Nobr == Nobr && a.Ddate >= Adate && Ddate >= a.Adate && a.ContractType == ContractType && !(a.Adate == Adate && a.Ddate == Ddate) select a;
            if (sql.Any())
            {
                return true;
            }
            return false;
        }
        #endregion

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string CODE = TargetRow["課程代碼"].ToString();
            string COURSE = TargetRow["課程名稱"].ToString();
            string DATE_B = TargetRow["開訓日期"].ToString();
            string DATE_E = TargetRow["結訓日期"].ToString();
            string TR_PERSON = TargetRow["訓練對象"].ToString();
            string TRCOMP = TargetRow["承辦單位"].ToString();
            string DEPT = TargetRow["開課部門"].ToString();
            string TRTYPE = TargetRow["課程類別"].ToString();
            string TRASSCODE = TargetRow["評核方式"].ToString();
            string TR_INOUT = TargetRow["訓練型式"].ToString();
            string TR_HRS = TargetRow["總時數"].ToString();
            string TR_TEACH = TargetRow["講師"].ToString();
            string COS_FEE = TargetRow["上課費用"].ToString();
            string COUNTRY = TargetRow["國家"].ToString();
            string HANDOUT = TargetRow["講義"].ToString();
            string TR_ISO = TargetRow["ISO"].ToString();
            string ABORAD = TargetRow["是否國外"].ToString();
            string PLANIN = TargetRow["是否計畫內"].ToString();
            string PLANTO = TargetRow["是否有課後問卷"].ToString();
            string TR_MENO = TargetRow["備註"].ToString();
            DateTime date = DateTime.MaxValue;
            decimal dec = 0;
            bool bo = false;
            string Msg = "";

            #region 檢查"是否國外"
            if (!string.IsNullOrWhiteSpace(ABORAD))
            {
                if (!bool.TryParse(ABORAD, out bo))
                {
                    TargetRow["錯誤註記"] += errorMsg("是否國外");
                }
            }
            #endregion

            #region 檢查"是否計畫內"
            if (!string.IsNullOrWhiteSpace(PLANIN))
            {
                if (!bool.TryParse(ABORAD, out bo))
                {
                    TargetRow["錯誤註記"] += errorMsg("是否計畫內");
                }
            }
            #endregion

            #region 檢查"是否有課後問卷"
            if (!string.IsNullOrWhiteSpace(ABORAD))
            {
                if (!bool.TryParse(PLANTO, out bo))
                {
                    TargetRow["錯誤註記"] += errorMsg("是否有課後問卷");
                }
            }
            #endregion

            #region 檢查"總時數"
            if (!string.IsNullOrWhiteSpace(TR_HRS))
            {
                if (!decimal.TryParse(TR_HRS, out dec))
                {
                    TargetRow["錯誤註記"] += errorMsg("總時數");
                }
            }
            #endregion

            #region 檢查"上課費用"
            if (!string.IsNullOrWhiteSpace(TR_HRS))
            {
                if (!decimal.TryParse(TR_HRS, out dec))
                {
                    TargetRow["錯誤註記"] += errorMsg("上課費用");
                }
            }
            #endregion

            #region 檢查"訓練型式"
            if (ColumnValidate(TargetRow, "訓練型式", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["訓練型式名稱"] = Msg;
            }
            else
            {
                TargetRow["錯誤註記"] += Msg + ";";
            }
            #endregion

            #region 檢查"評核方式"
            if (ColumnValidate(TargetRow, "評核方式", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["評核方式名稱"] = Msg;
            }
            else
            {
                TargetRow["錯誤註記"] += Msg + ";";
            }
            #endregion

            #region 檢查"課程類別"
            if (ColumnValidate(TargetRow, "課程類別", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["課程類別名稱"] = Msg;
            }
            else
            {
                TargetRow["錯誤註記"] += Msg + ";";
            }
            #endregion

            #region 檢查"開課部門"
            if (ColumnValidate(TargetRow, "開課部門", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["開課部門名稱"] = Msg;
            }
            else
            {
                TargetRow["錯誤註記"] += Msg + ";";
            }
            #endregion

            #region 檢查"承辦單位"
            if (ColumnValidate(TargetRow, "承辦單位", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["承辦單位名稱"] = Msg;
            }
            else
            {
                TargetRow["錯誤註記"] += Msg + ";";
            }
            #endregion

            #region 檢查"訓練對象"
            if (string.IsNullOrWhiteSpace(TR_PERSON))
            {
                TargetRow["錯誤註記"] += errorMsg("訓練對象");
            }
            #endregion

            #region 檢查"開訓日期"
            if (!DateTime.TryParse(DATE_B,out date))
            {
                TargetRow["錯誤註記"] += errorMsg("開訓日期");
            }
            #endregion

            #region 檢查"結訓日期"
            if (!DateTime.TryParse(DATE_E, out date))
            {
                TargetRow["錯誤註記"] += errorMsg("結訓日期");
            }
            #endregion

            #region 檢查"課程名稱"
            if (string.IsNullOrWhiteSpace(COURSE))
            {
                TargetRow["錯誤註記"] += errorMsg("課程名稱");
            }
            #endregion

            #region 檢查"課程代碼有無重複"
            if (string.IsNullOrWhiteSpace(CODE))
            {
                TargetRow["錯誤註記"] += errorMsg("課程代碼");
            }
            else
            {
                var sql = db.TRCOSC.Where(p => p.CODE == CODE);
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