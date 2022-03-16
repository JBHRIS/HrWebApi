using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class BASETTSD : JBControls.JBForm
    {
        public string nobr = "";
        private bool basettsCheckOK = false;
        private bool basettsSaveOK = false;
        string state = "";
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        public BASETTSD()
        {
            InitializeComponent();
        }
        CheckControl cc;//必要欄位檢察
        private void BASETTSD_Load(object sender, EventArgs e)
        {
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbTTSCODE);   //異動狀態
            cc.AddControl(cbCOMP);      //公司別
            cc.AddControl(cbDept);      //編制部門
            cc.AddControl(cbDepts);     //成本部門
            cc.AddControl(cbDepta);     //簽核部門
            cc.AddControl(cbJob);       //職稱
            cc.AddControl(cbJobs);      //職類
            cc.AddControl(cbJobl);      //職等
            cc.AddControl(comboBoxJobo);   //職級
            cc.AddControl(cbDI);        //直間接
            cc.AddControl(cbEmpcd);     //員別
            cc.AddControl(cbRotet);     //班別
            cc.AddControl(cbHOLICD);    //行事曆
            cc.AddControl(cbWorkcd);    //工作地
            cc.AddControl(cbDatagroup); //資料群組
            cc.AddControl(cbOTRATECD);  //加班別(加班比率)
            cc.AddControl(cbSALTYCD);   //薪別
            //cc.AddControl(cbDoorGuard); //門禁群組
            //cc.AddControl(comboBoxLesson);//編制課別
            //cc.AddControl(comboBoxCostType);//成本別
            //cc.AddControl(comboBoxResponsibility);//責任區別
            cc.AddControl(cbRETCHOO);//退休金制度
            cc.AddControl(cbTTSCD);     //異動原因
            #endregion
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM12", MainForm.COMPANY);
            checkBoxFULATT.Visible = AppConfig.GetConfig("FULATT_visible").GetBoolean(false);
            SystemFunction.SetComboBoxItems(comboBoxERP, CodeFunction.GetERPCODE(), true, true, true);      //ERP
            SystemFunction.SetComboBoxItems(comboBoxPassType, CodeFunction.GetMtCode("PASS_TYPE"), true, true, true);      //ERP
            SystemFunction.SetComboBoxItems(comboBoxBonusGroup, CodeFunction.GetBonusGroup(), true, true, true);      //門禁群組
            SystemFunction.SetComboBoxItems(cbDoorGuard, CodeFunction.GetDoorGuard(), true, true, true);      //門禁群組
            SystemFunction.SetComboBoxItems(comboBoxGroup, CodeFunction.GetGroupType(), true, true, true);//組別
            SystemFunction.SetComboBoxItems(comboBoxJobo, CodeFunction.GetJobo(), true, true, true);//職級
            SystemFunction.SetComboBoxItems(comboBoxLesson, CodeFunction.GetLessonType(), true, true, true);//編制課別
            SystemFunction.SetComboBoxItems(comboBoxCostType, CodeFunction.GetCostType(), true, true, true);//成本別
            SystemFunction.SetComboBoxItems(comboBoxResponsibility, CodeFunction.GetResponsibilityType(), true, true, true);//責任區別
            SystemFunction.SetComboBoxItems(cbDatagroup, CodeFunction.GetDatagroup(), true, true, true);      //資料群組          
            SystemFunction.SetComboBoxItems(cbOutcd, CodeFunction.GetOutcd(), true, true);              //離職原因
            SystemFunction.SetComboBoxItems(cbxBanCode, CodeFunction.GetBankCode(), true, true, true);              //銀行代碼
            this.rELCODETableAdapter.Fill(this.basDS.RELCODE);
            this.rELISHCDTableAdapter.Fill(this.basDS.RELISHCD);
            this.cOUNTCDTableAdapter.Fill(this.basDS.COUNTCD);
            this.aRMYTableAdapter.Fill(this.basDS.ARMY);
            this.pROVCDTableAdapter.Fill(this.basDS.PROVCD);
            this.eDUCODETableAdapter.Fill(this.basDS.EDUCODE);
            SystemFunction.SetComboBoxItems(cbRETCHOO, CodeFunction.GetMtCode("RETCHOO"), true, true, true);  //退休金制度
            this.SALADRTableAdapter.Fill(this.basDS.SALADR);
            SystemFunction.SetComboBoxItems(cbOTRATECD, CodeFunction.GetOtRatecd(), true, true, true);        //加班別(加班比率)
            SystemFunction.SetComboBoxItems(cbSALTYCD, CodeFunction.GetSaltycd(), true, true, true);          //薪別
            SystemFunction.SetComboBoxItems(cbTTSCODE, CodeFunction.GetMtCode("TTSCODE"), true, true, true);  //異動狀態
            SystemFunction.SetComboBoxItems(cbTTSCD, CodeFunction.GetTtscd(), true, true, true);              //異動原因
            SystemFunction.SetComboBoxItems(cbWorkcd, CodeFunction.GetWorkcd(), true, true, true);            //工作地            
            SystemFunction.SetComboBoxItems(cbHOLICD, CodeFunction.GetHolicd(), true, true, true);            //行事曆
            SystemFunction.SetComboBoxItems(cbRotet, CodeFunction.GetRotet(), true, true, true);              //班別
            SystemFunction.SetComboBoxItems(cbEmpcd, CodeFunction.GetEmpcd(), true, true, true);              //員別
            SystemFunction.SetComboBoxItems(cbDI, CodeFunction.GetMtCode("DI"), true, true, true);            //直間接
            SystemFunction.SetComboBoxItems(cbJobl, CodeFunction.GetJobl(), true, true, true);                //職等            
            SystemFunction.SetComboBoxItems(cbJobs, CodeFunction.GetJobs(), true, true, true);                //職類            
            SystemFunction.SetComboBoxItems(cbJob, CodeFunction.GetJob(), true, true, true);                  //職稱
            SystemFunction.SetComboBoxItems(cbDepta, CodeFunction.GetDepta_effe(), true, true, true);              //簽核部門
            SystemFunction.SetComboBoxItems(cbDepts, CodeFunction.GetDepts(), true, true, true);              //成本部門
            SystemFunction.SetComboBoxItems(cbDept, CodeFunction.GetDept(), true, true, true);                //編制部門
            SystemFunction.SetComboBoxItems(cbCOMP, CodeFunction.GetComp(), true, true, true);                //公司別

            // TODO: 這行程式碼會將資料載入 'basDS.DoorGuard' 資料表。您可以視需要進行移動或移除。
            //this.doorGuardTableAdapter.Fill(this.basDS.DoorGuard);
            // TODO: 這行程式碼會將資料載入 'basDS.OilSubsidyType' 資料表。您可以視需要進行移動或移除。
            //this.oilSubsidyTypeTableAdapter.Fill(this.basDS.OilSubsidyType);
            //this.vw_Comp_DatagroupTableAdapter.FillByComp(this.sysDS.vw_Comp_Datagroup, MainForm.COMPANY);
            //this.oUTCDTableAdapter.Fill(this.basDS.OUTCD);
            //this.RETCHOOTableAdapter.Fill(this.basDS.RETCHOO);
            //this.OTRATECDTableAdapter.Fill(this.basDS.OTRATECD);
            //this.SALTYCDTableAdapter.Fill(this.basDS.SALTYCD);
            //this.TTSCDTableAdapter.Fill(this.basDS.TTSCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.WORKCDTableAdapter.Fill(this.basDS.WORKCD);
            //this.HOLICDTableAdapter.Fill(this.basDS.HOLICD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.EMPCDTableAdapter.Fill(this.basDS.EMPCD);
            //this.DITableAdapter.Fill(this.basDS.DI);
            //this.JOBLTableAdapter.Fill(this.basDS.JOBL, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.JOBSTableAdapter.Fill(this.basDS.JOBS,MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.JOBTableAdapter.Fill(this.basDS.JOB, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.DEPTATableAdapter.Fill(this.basDS.DEPTA, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.DEPTSTableAdapter.Fill(this.basDS.DEPTS, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.DEPTTableAdapter.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.COMPTableAdapter.Fill(this.basDS.COMP);

            this.MARRYTableAdapter.Fill(this.basDS.MARRY);
            this.BLOODTableAdapter.Fill(this.basDS.BLOOD);
            this.SEXTableAdapter.Fill(this.basDS.SEX);
            this.BASETableAdapter.FillByNOBR(this.basDS.BASE, nobr);
            //this.sTATIONTableAdapter.Fill(this.basDS.STATION, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //SystemFunction.SetComboBoxItems(cbStation, CodeFunction.GetStation(), true, true);      //環境津貼
            //this.oilSubsidyTypeTableAdapter.Fill(this.basDS.OilSubsidyType);
            //this.doorGuardTableAdapter.Fill(this.basDS.DoorGuard);
            //this.outPostTableAdapter.Fill(this.basDS.OutPost, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            SystemFunction.SetComboBoxItems(cbOutPost, CodeFunction.GetOutPost(), true, true, true);      //外派

            DataTable list = new DataTable();
            list.Columns.Add(new DataColumn("Display", typeof(string)));
            list.Columns.Add(new DataColumn("Id", typeof(string)));
            list.Rows.Add(list.NewRow());
            list.Rows.Add(list.NewRow());
            list.Rows.Add(list.NewRow());


            list.Rows[0][0] = "(無)";
            list.Rows[0][1] = "";
            list.Rows[1][0] = "Y";
            list.Rows[1][1] = "Y";
            list.Rows[2][0] = "N";
            list.Rows[2][1] = "N";
            cbCard.DataSource = list;
            cbCard.DisplayMember = "Display";
            cbCard.ValueMember = "Id";

            if (this.basDS.BASE.Count > 0)
            {
                this.Text = "(" + nobr + ")" + this.basDS.BASE[0].NAME_C.Trim();
            }
            state = "edit";
            if (basettsFDC.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                state = "add";
                BasDS.BASETTSRow dataRow = basDS1.BASETTS[0];
                var ttsData = CodeFunction.GetMtCode("TTSCODE");
                switch (dataRow.TTSCODE)
                {
                    case "1":
                        //TTSCODEBindingSource.Filter = "code in (2,3,6)";
                        ttsData.Remove("1");
                        //ttsData.Remove("2");
                        //ttsData.Remove("3");
                        ttsData.Remove("4");
                        ttsData.Remove("5");
                        //ttsData.Remove("6");
                        SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true, true);
                        break;
                    case "2":
                        //TTSCODEBindingSource.Filter = "code in (4)";
                        ttsData.Remove("1");
                        ttsData.Remove("2");
                        ttsData.Remove("3");
                        //ttsData.Remove("4");
                        ttsData.Remove("5");
                        ttsData.Remove("6");
                        SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true, true);
                        break;
                    case "3":
                        //TTSCODEBindingSource.Filter = "code in (4,5)";
                        ttsData.Remove("1");
                        ttsData.Remove("2");
                        ttsData.Remove("3");
                        //ttsData.Remove("4");
                        //ttsData.Remove("5");
                        ttsData.Remove("6");
                        SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true, true);
                        break;
                    case "4":
                        //TTSCODEBindingSource.Filter = "code in (2,3,6)";
                        ttsData.Remove("1");
                        //ttsData.Remove("2");
                        //ttsData.Remove("3");
                        ttsData.Remove("4");
                        ttsData.Remove("5");
                        //ttsData.Remove("6");
                        SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true, true);
                        break;
                    case "5":
                        //TTSCODEBindingSource.Filter = "code in (4)";
                        ttsData.Remove("1");
                        ttsData.Remove("2");
                        ttsData.Remove("3");
                        //ttsData.Remove("4");
                        ttsData.Remove("5");
                        ttsData.Remove("6");
                        SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true, true);
                        break;
                    case "6":
                        //TTSCODEBindingSource.Filter = "code in (2,3,6)";
                        ttsData.Remove("1");
                        //ttsData.Remove("2");
                        //ttsData.Remove("3");
                        ttsData.Remove("4");
                        ttsData.Remove("5");
                        //ttsData.Remove("6");
                        SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true, true);
                        break;
                }

                cbTTSCODE.Enabled = true;
                txtAdate.Enabled = true;
            }
            else
            {
                TTSCODEBindingSource.Filter = "";
                cbTTSCODE.Enabled = false;
                txtAdate.Enabled = true;
            }


            basDS.BASETTS.ImportRow(basDS1.BASETTS[0]);//必須後面再import，否則前面combobox Load資料時，會改變Current Binding Value

            baseFDC.DataAdapter = BASETableAdapter;
            basettsFDC.DataAdapter = BASETTSTableAdapter;
            if (basettsFDC.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                SystemFunction.SetComboBoxItems(cbDepta, CodeFunction.GetDepta_effe(Convert.ToDateTime(txtAdate.Text)), true, true, true);              //簽核部門
                SystemFunction.SetComboBoxItems(cbDepts, CodeFunction.GetDepts_effe(Convert.ToDateTime(txtAdate.Text)), true, true, true);              //成本部門
                SystemFunction.SetComboBoxItems(cbDept, CodeFunction.GetDept_effe(Convert.ToDateTime(txtAdate.Text)), true, true, true);                //編制部門
            }
            else
            {
                SystemFunction.SetComboBoxItems(cbDepta, CodeFunction.GetDepta(), true, true, true);              //簽核部門
                SystemFunction.SetComboBoxItems(cbDepts, CodeFunction.GetDepts(), true, true, true);              //成本部門
                SystemFunction.SetComboBoxItems(cbDept, CodeFunction.GetDept(), true, true, true);
            }
            if (basettsFDC.EditType == JBControls.FullDataCtrl.EEditType.Add) txtAdate.Enabled = true;
            else txtAdate.Enabled = false;
            txtAdate_Validated(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baseFDC.bnSave_Click(null, null);
        }

        private void baseFDC_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            #region 必要欄位檢察
            errorProvider1.Clear();
            var ctrl = cc.CheckRequiredFields();//必要欄位檢察
            if (ctrl != null)//必要欄位檢察
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                errorProvider1.SetError(ctrl, "必要欄位未輸入");
                e.Cancel = true;
                return;
            }
            #endregion

            if (!Sal.Function.CanModify(nobr))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!MainForm.WriteRules.Where(p => p.DATAGROUP == cbDatagroup.SelectedValue.ToString()).Any())
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            basettsFDC.bnSave_Click(null, null);
            if (basettsCheckOK && basettsSaveOK)
            {
                e.Values["nobr"] = this.nobr;
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
            }
            else e.Cancel = true;
        }

        private void basettsFDC_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {

            e.Values["nobr"] = this.nobr;
            e.Values["key_man"] = MainForm.USER_NAME;
            e.Values["key_date"] = DateTime.Now;

            state = "edit";
            BasDS.BASETTSRow dataRow = basDS.BASETTS[0];
            if (basettsFDC.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {

                state = "add";
                //if (dataRow.TTSCODE == "2" || dataRow.TTSCODE == "5")
                //{
                //    if (MessageBox.Show("原本離職的異動資料將修改為留停?按確定繼續，取消略過", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                //        e.Cancel = true;
                //}

                if (e.Values["ttscode"].ToString() == "1")
                {
                    e.Values["indt"] = e.Values["adate"];
                }
                if (e.Values["ttscode"].ToString() == "2")
                {
                    e.Values["oudt"] = Convert.ToDateTime(e.Values["adate"]).AddDays(-1);
                }
                if (e.Values["ttscode"].ToString() == "3")
                {
                    e.Values["stdt"] = Convert.ToDateTime(e.Values["adate"]).AddDays(-1);
                }
                if (e.Values["ttscode"].ToString() == "4")
                {
                    if (dataRow.TTSCODE == "2" || dataRow.TTSCODE == "5")
                        e.Values["stdt"] = dataRow.ADATE;
                    e.Values["stindt"] = e.Values["adate"];
                }
                if (e.Values["ttscode"].ToString() == "5")
                {
                    e.Values["stoudt"] = Convert.ToDateTime(e.Values["adate"]).AddDays(-1);
                    e.Values["oudt"] = e.Values["stdt"];
                }
            }
            FRM12DataClassesDataContext db = new FRM12DataClassesDataContext();
            if (basettsFDC.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                IEnumerable<BASETTS> basetts1 = from c in db.BASETTS
                                                where c.NOBR.Trim().ToLower() == nobr.Trim().ToLower() && c.ADATE == Convert.ToDateTime(e.Values["adate"])
                                                select c;
                if (basetts1.Count() > 0)
                {
                    MessageBox.Show(Resources.Bas.TTSDateErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }

                if (Convert.ToDateTime(e.Values["adate"]) <= basDS.BASETTS[0].ADATE)
                {
                    MessageBox.Show(Resources.Bas.TTSAdateErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }

            if (e.Cancel) basettsCheckOK = false;
            else basettsCheckOK = true;
        }

        private void basettsFDC_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            BasDS.BASETTSRow dataRow = basDS1.BASETTS[0];

            foreach (DataColumn dc in basDS.BASETTS.Columns)
            {
                if (dc.ColumnName.Trim().ToLower() != "ttscode")
                {
                    e.Values[dc.ColumnName] = dataRow[dc.ColumnName];
                }
            }

            e.Values["adate"] = DateTime.Today;//basDS.BASETTS[0].ADATE.AddDays(1);
            e.Values["ddate"] = DateTime.MaxValue.Date;

            txtIndt.Enabled = false;
            txtOudt.Enabled = false;
            txtStdt.Enabled = false;
            txtStindt.Enabled = false;
            txtStoudt.Enabled = false;
        }

        private void basettsFDC_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                JBHRIS.BLL.Bas.BasettsFixDdateDao basettsDao = new JBHRIS.BLL.Bas.BasettsFixDdateDao(db.Connection);
                basettsDao.FixData(nobr);

                this.DialogResult = DialogResult.OK;
                if (cbTTSCODE.SelectedValue.ToString() == "2" || cbTTSCODE.SelectedValue.ToString() == "3" || cbTTSCODE.SelectedValue.ToString() == "5")
                    ShowDeptMangList();
                Close();

                if (state == "add" && cbTTSCODE.SelectedValue.ToString() == "2" || cbTTSCODE.SelectedValue.ToString() == "3" || cbTTSCODE.SelectedValue.ToString() == "5")
                {
                    if (MessageBox.Show("是否要做退保的動作？", "訊息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        DateTime Adate = Convert.ToDateTime(txtAdate.Text).AddDays(-1);
                        FRM12P frm1p = new FRM12P(nobr, Adate);
                        frm1p.ShowDialog();
                    }
                }
                Close();
                basettsSaveOK = true;
            }
            else basettsSaveOK = false;

            state = "";//初始化
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void baseFDC_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtIndt.Enabled = false;
            txtOudt.Enabled = false;
            txtStdt.Enabled = false;
            txtStindt.Enabled = false;
            txtStoudt.Enabled = false;
        }

        private void baseFDC_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtIndt.Enabled = false;
            txtOudt.Enabled = false;
            txtStdt.Enabled = false;
            txtStindt.Enabled = false;
            txtStoudt.Enabled = false;
        }

        private void basettsFDC_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtIndt.Enabled = false;
            txtOudt.Enabled = false;
            txtStdt.Enabled = false;
            txtStindt.Enabled = false;
            txtStoudt.Enabled = false;
        }

        private void cbDepts_MouseClick(object sender, MouseEventArgs e)
        {
            //BasDS.BASETTSRow BASETTSRow = (BasDS.BASETTSRow)((DataRowView)BASETTSbindingSource.Current).Row;
            //SystemFunction.SetComboBoxItems(cbDepts, CodeFunction.GetDepts_effe(), true); //成本部門-過濾失效
            //cbDepts.SelectedValue = BASETTSRow.DEPTS;
        }

        private void txtAdate_Validated(object sender, EventArgs e)
        {
            if (cbxAvailableCode.Checked)
            {
                SystemFunction.SetComboBoxItems(cbDepta, CodeFunction.GetDepta(), true, true);              //簽核部門
                SystemFunction.SetComboBoxItems(cbDepts, CodeFunction.GetDepts(), true, true);              //成本部門
                SystemFunction.SetComboBoxItems(cbDept, CodeFunction.GetDept(), true, true);
            }
            else
            {
                SystemFunction.SetComboBoxItems(cbDepta, CodeFunction.GetDepta_effe(Convert.ToDateTime(txtAdate.Text)), true, true);              //簽核部門
                SystemFunction.SetComboBoxItems(cbDepts, CodeFunction.GetDepts_effe(Convert.ToDateTime(txtAdate.Text)), true, true);              //成本部門
                SystemFunction.SetComboBoxItems(cbDept, CodeFunction.GetDept_effe(Convert.ToDateTime(txtAdate.Text)), true, true);
            }
        }

        private void cbxAvailableCode_CheckedChanged(object sender, EventArgs e)
        {
            txtAdate_Validated(null, null);
        }
        public List<DeptLeaveManager> GetDeptManager(string Nobr, DateTime DDate)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPT
                      join b in db.BASE on a.NOBR equals b.NOBR
                      where a.NOBR == Nobr
                          && db.GetCodeFilter("DEPT", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && a.ADATE != null && DDate >= a.ADATE.Value
                          && a.DDATE != null && DDate <= a.DDATE.Value
                      select new DeptLeaveManager { Dept = a.D_NO_DISP, DeptName = a.D_NAME, NameC = b.NAME_C, Nobr = a.NOBR };
            return sql.ToList();
        }
        public List<DeptLeaveManager> GetDeptaManager(string Nobr, DateTime DDate)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.DEPTA
                      join b in db.BASE on a.NOBR equals b.NOBR
                      where a.NOBR == Nobr
                          && db.GetCodeFilter("DEPTA", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && a.ADATE != null && DDate >= a.ADATE.Value
                          && a.DDATE != null && DDate <= a.DDATE.Value
                      select new DeptLeaveManager { Dept = a.D_NO_DISP, DeptName = a.D_NAME, NameC = b.NAME_C, Nobr = a.NOBR };
            return sql.ToList();
        }
        public void ShowDeptMangList()
        {
            var data1 = GetDeptManager(nobr, Convert.ToDateTime(txtAdate.Text)).Select(p => new { Type = "編制部門", p.Dept, p.DeptName });
            var data2 = GetDeptaManager(nobr, Convert.ToDateTime(txtAdate.Text)).Select(p => new { Type = "簽核部門", p.Dept, p.DeptName });
            var data = data1.Union(data2);
            var view = from a in data select new { 類別 = a.Type, 部門代碼 = a.Dept, 部門名稱 = a.DeptName };
            if (view.Any())
            {
                Sal.PreviewForm frm = new Sal.PreviewForm();
                frm.Form_Title = "部門主管";
                frm.DataTable = view.CopyToDataTable();
                frm.ShowDialog();
            }
        }
    }
}