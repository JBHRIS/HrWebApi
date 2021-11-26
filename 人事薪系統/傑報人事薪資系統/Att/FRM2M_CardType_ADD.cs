using JBTools.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM2M_CardType_ADD : JBControls.JBForm
    {
        public FRM2M_CardType_ADD()
        {
            InitializeComponent();
        }
        JBControls.MultiSelectionDialog mdEmp = new JBControls.MultiSelectionDialog();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.Linq.MealCardType instance = new JBModule.Data.Linq.MealCardType();
        Dictionary<string, string> MealTypeList = new Dictionary<string, string>();
        string topic = "";
        public int Autokey = -1;//-1 = ADD , other = EDIT
        List<string> nobrs = new List<string>();
        DateTime BDate, Edate;
        string MealGroup, MealType, BTIME, BTIME_Source;
        bool boolLos, boolNoTrans, boolHoliNot, RpSW = true;
        CheckTimeFormatControl CTFC = new CheckTimeFormatControl();
        private void FRM2M_CardType_ADD_Load(object sender, EventArgs e)
        {
            topic = this.Text;
            CTFC.AddControl(txtBTIME, true, true);
            CTFC.AddControl(txtBTIME_Source, false, false);
            EmpInitial();
        }

        private void EmpInitial()
        {
            SystemFunction.SetComboBoxItems(cbxMealGroup, CodeFunction.GetMealGroup(), true, true, true, true);
            if (Autokey == -1)
            {
                dtpBDate.Value = DateTime.Today;
                dtpEDate.Value = DateTime.Today;
                cbxMealGroup.Focus();
            }
            else
            {
                instance = db.MealCardType.SingleOrDefault(p => p.AutoKey == Autokey);
                var emp = (from a in db.BASE
                           join b in db.BASETTS on a.NOBR equals b.NOBR
                           join j in db.JOBL on b.JOBL equals j.JOBL1
                           where b.NOBR == instance.NOBR
                           orderby b.ADATE descending
                           select new { 員工編號 = a.NOBR, 姓名 = a.NAME_C, 職等 = j.JOB_NAME, 編制部門 = b.DEPT1.D_NAME }).First();
                topic = emp.編制部門 + '-' + btnEmp.Text;
                this.Text = topic;
                btnEmp.Text = emp.員工編號 + "-" + emp.姓名;
                dtpBDate.Value = instance.ADATE;
                dtpEDate.Value = instance.ADATE;
                txtBTIME.Text = instance.BTIME;
                txtBTIME_Source.Text = instance.BTIME_Source;
                //txtNOTE.Text = instance.NOTE;
                txtSeroNo.Text = instance.SeroNo;
                chkLos.Checked = instance.Lost;
                chkNot_Trans.Checked = instance.NoTrans;
                cbxMealGroup.SelectedValue = instance.MealGroup;
                MealGroup = cbxMealGroup.SelectedValue.ToString();
                MealTypeList = CodeFunction.GetMealType(cbxMealGroup.SelectedValue.ToString());
                SystemFunction.SetComboBoxItems(cbxMealType, MealTypeList, true, true);
                cbxMealType.SelectedValue = instance.MealType == null ? string.Empty : instance.MealType;
                dtpBDate.Enabled = false;
                dtpEDate.Enabled = false;
                chkHoliNot.Enabled = false;
                cbxMealGroup.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var control = CTFC.CheckRequiredFields();
            if (control != null)
            {
                MessageBox.Show("此欄位為必填欄位.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                control.Focus();
                return;
            }
            nobrs = mdEmp.SelectedValues;
            BDate = dtpBDate.Value;
            Edate = dtpEDate.Value;
            //Note = txtNOTE.Text;
            MealGroup = cbxMealGroup.SelectedValue.ToString();
            BTIME = txtBTIME.Text;
            BTIME_Source = txtBTIME_Source.Text;
            MealType = cbxMealType.SelectedValue.ToString();
            boolLos = chkLos.Checked;
            boolNoTrans = chkNot_Trans.Checked;
            boolHoliNot = chkHoliNot.Checked;
            List<JBModule.Data.Linq.MealCardType> instanceRp = new List<JBModule.Data.Linq.MealCardType>();
            foreach (var item in nobrs.Split(1))
                instanceRp.AddRange(db.MealCardType.Where(p => item.Contains(p.NOBR) && p.ADATE >= BDate && p.ADATE <= Edate && p.BTIME == BTIME));
            //var instanceRp = db.MealCardType.Where(p => nobrs.Contains(p.NOBR) && p.ADATE >= BDate && p.ADATE <= Edate && p.BTIME == BTIME);
            if (instanceRp.Any())
            {
                if (MessageBox.Show("已存在相同資料，Yes = 覆蓋, No = 略過.", Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    JBModule.Message.DbLog.WriteLog("OverLapDel", instanceRp, this.Name, -1);
                    db.MealCardType.DeleteAllOnSubmit(instanceRp);
                    db.SubmitChanges();
                }
                else
                {
                    RpSW = false;
                }
            }
            BW.RunWorkerAsync();
            this.tableLayoutPanel1.Enabled = false;
        }


        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            string msg = "";
            try
            {
                if (Autokey == -1)
                {
                    db = new JBModule.Data.Linq.HrDBDataContext();//init
                    List<string> holi_codeList = CodeFunction.GetHolidayRoteList();
                    int total = nobrs.Count;
                    int count = 0;

                    List<JBModule.Data.Linq.BASETTS> basetts = new List<JBModule.Data.Linq.BASETTS>();
                    foreach (var nobrList in nobrs.Split(1000))
                    {
                        var sql = db.BASETTS.Where(p => nobrList.Contains(p.NOBR)).ToList();
                        basetts.AddRange(sql);
                    }

                    foreach (var nobr in nobrs)
                    {
                        BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(count) / Convert.ToDecimal(total) * 100), "正在產生" + nobr + "刷卡餐別資料");
                        for (DateTime dd = BDate; dd <= Edate; dd = dd.AddDays(1))
                        {
                            if (!basetts.Where(p => p.ADATE <= dd && p.DDATE >= dd && new string[] { "1", "4", "6" }.Contains(p.TTSCODE)).Any())
                                continue;

                            if (boolHoliNot)
                            {//假日就跳過
                                var roteSql = (from a in db.ATTEND where a.NOBR == nobr && a.ADATE == dd select a.ROTE).FirstOrDefault();
                                if (roteSql != null && holi_codeList.Contains(roteSql)) continue;
                            }

                            instance = new JBModule.Data.Linq.MealCardType();
                            JBModule.Data.Linq.MealCardType instanceRp = new JBModule.Data.Linq.MealCardType();
                            instanceRp = db.MealCardType.Where(p => p.NOBR == nobr && p.ADATE == dd && p.BTIME == BTIME).FirstOrDefault();
                            if (instanceRp != null)
                            {
                                if (RpSW)
                                {
                                    instanceRp.BTIME_Source = BTIME_Source;
                                    instanceRp.MealType = MealType;
                                    instanceRp.NoTrans = boolNoTrans;
                                    instanceRp.Lost = boolLos;
                                    instanceRp.KEY_DATE = DateTime.Now;
                                    instanceRp.KEY_MAN = MainForm.USER_NAME;
                                    JBModule.Message.DbLog.WriteLog("Update", instance, this.Name, instance.AutoKey); 
                                }
                            }
                            else
                            {
                                instance.NOBR = nobr;
                                instance.ADATE = dd;
                                instance.BTIME = BTIME;
                                instance.BTIME_Source = BTIME_Source;
                                instance.MealGroup = MealGroup;
                                instance.MealType = MealType;
                                instance.NoTrans = boolNoTrans;
                                instance.Lost = boolLos;
                                instance.SeroNo = Guid.NewGuid().ToString();
                                instance.KEY_DATE = DateTime.Now;
                                instance.KEY_MAN = MainForm.USER_NAME;
                                JBModule.Message.DbLog.WriteLog("Insert", instance, this.Name, instance.AutoKey);
                                db.MealCardType.InsertOnSubmit(instance);
                            }
                        }
                        count++;
                        db.SubmitChanges();
                    }
                }
                else
                {
                    if (RpSW)
                    {
                        instance.BTIME = BTIME;
                        instance.BTIME_Source = BTIME_Source;
                        instance.MealType = MealType;
                        instance.NoTrans = boolNoTrans;
                        instance.Lost = boolLos;
                        instance.KEY_DATE = DateTime.Now;
                        instance.KEY_MAN = MainForm.USER_NAME;
                        JBModule.Message.DbLog.WriteLog("Update", instance, this.Name, instance.AutoKey);
                        db.SubmitChanges(); 
                    }
                }
                BW.ReportProgress(100, Resources.Sal.StatusFinish);
                msg = "完成.";
                e.Result = msg;
            }
            catch (Exception ex)
            {
                BW.ReportProgress(100, "錯誤.");
                msg = ex.Message;
                e.Result = msg;
                JBModule.Message.DbLog.WriteLog(msg, instance, this.Name, instance.AutoKey);
            }
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
            tSSLabelProcess.Text = e.UserState.ToString();
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result.ToString().Trim().Length > 0)
                MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.tableLayoutPanel1.Enabled = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEmp_Enter(object sender, EventArgs e)
        {
            SetEmpList();
        }

        void SetEmpList()
        {
            if (Autokey == -1)
            {
                string MealGroup = cbxMealGroup.SelectedValue.ToString();
                //DateTime ndate = DateTime.Today;//Convert.ToDateTime(dtpADATE.Text);
                DateTime bdate = dtpBDate.Value;
                DateTime edate = dtpEDate.Value;
                var sql = from a in db.BASE
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          join j in db.JOBL on b.JOBL equals j.JOBL1
                          join mt in db.MTCODE on b.TTSCODE equals mt.CODE
                          join ad in (db.ATTEND.Where(p => p.ADATE >= bdate && p.ADATE <= edate).GroupBy(p => p.NOBR)) on a.NOBR equals ad.Key
                          join ud in (from udv in db.UserDefineValue
                                      join uds in db.UserDefineSource on udv.SourceID equals uds.SourceID
                                      join md in db.MealGroup on udv.Value equals md.MealGroup_Code
                                      where uds.SourceName == "MealGroup" && udv.Value == MealGroup
                                      select new { udv.Code, md.MealGroup_Code, md.MealGroup_DISP, md.MealGroup_Name }) on a.NOBR equals ud.Code
                          //join c in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals c.NOBR
                          where edate >= b.ADATE && edate <= b.DDATE.Value
                          //&& new string[] { "1", "4", "6" }.Contains(b.TTSCODE)
                          && mt.CATEGORY == "TTSCODE"
                          //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          select new
                          {
                              員工編號 = a.NOBR,
                              姓名 = a.NAME_C,
                              用餐群组 = ud.MealGroup_DISP + "-" + ud.MealGroup_Name,
                              異動狀態 = new string[] { "1", "4", "6" }.Contains(mt.CODE) ? "在职" : mt.NAME,
                              異動日期 = new string[] { "1", "4", "6" }.Contains(mt.CODE) ? null : b.OUDT != null ? b.OUDT : b.STDT != null ? b.STDT : null,
                              職等 = j.JOB_NAME,
                              編制部門 = b.DEPT1.D_NAME,
                              _index = ud.MealGroup_Code
                          };
                mdEmp.SetControl(btnEmp, sql.CopyToDataTable(), "員工編號");
                mdEmp.SelectedValues.Clear();
                btnEmp.Text = "請選擇需產生刷卡餐別的人員";
            }
        }

        private void dtpBDate_CloseUp(object sender, EventArgs e)
        {
            if (dtpBDate.Value > dtpEDate.Value)
                dtpEDate.Value = dtpBDate.Value;
            SetEmpList();
        }

        private void dtpEDate_CloseUp(object sender, EventArgs e)
        {
            if (dtpBDate.Value > dtpEDate.Value)
                dtpBDate.Value = dtpEDate.Value;
            SetEmpList();
        }

        private void cbxMealGroup_DropDownClosed(object sender, EventArgs e)
        {
            MealGroup = cbxMealGroup.SelectedValue.ToString();
            mdEmp.Source = new DataTable();
            btnEmp.Tag = null;
            MealTypeList.Clear();
            MealTypeList = CodeFunction.GetMealType(cbxMealGroup.SelectedValue.ToString());
            SystemFunction.SetComboBoxItems(cbxMealType, MealTypeList, true, true);
            SetEmpList();
        }

        private void txtBTIME_Validated(object sender, EventArgs e)
        {
            var MealTypes = db.MealType.Where(p => p.MealGroup == MealGroup).ToList();
            foreach (var MT in MealTypes)
            {
                int intBT = Convert.ToInt32(MT.BTime);
                int intET = Convert.ToInt32(MT.ETime);
                int intPreTime = Convert.ToInt32(txtBTIME.Text);
                int intTime = intPreTime >= 2400 ? intPreTime - 2400 : intPreTime;
                txtBTIME_Source.Text = intTime.ToString("0000");
                if (intTime >= intBT && intTime <= intET)
                {
                    cbxMealType.SelectedValue = MT.MealType_Code;
                    break;
                }
                else if (intBT >= 2400 && intPreTime >= intBT && intPreTime <= intET)
                {
                    cbxMealType.SelectedValue = MT.MealType_Code;
                    break;
                }
                else if (intET >= 2400)
                {
                    if (intTime >= intBT || intPreTime <= intET)
                    {
                        cbxMealType.SelectedValue = MT.MealType_Code;
                        break;
                    }
                }
            }
        }
    }
}
