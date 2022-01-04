using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using JBModule.Data.Linq;
using System.Data.SqlClient;
using Dapper;
using Newtonsoft.Json;
using JBHR.Sal;

namespace JBHR.Bas
{
    public partial class FRM12 : JBControls.JBForm
    {
        enum FormMode { Add, Edit, View }
        bool IsIdCheck = true;
        FormMode formMode = FormMode.View;
        bool BASETTS_SAVE_ERROR = false;
        CheckControl cc;//必要欄位檢察
        QueryForm queryFrm;
        private JBControls.FullDataCtrl.EEditType EditType;
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        int SizeOffset = 6;
        int UDLayoutCnt = 0;
        bool IDNOCheck = true;
        List<Control> controlList = new List<Control>();
        public FRM12()
        {
            InitializeComponent();
            ScanTabControls(); //使用者自定義
        }

        private void FRM12_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM12", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("MonthOfAp_date", "試用期滿日月份", "3"
               , "指定試用期滿日於幾個月後", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("DayOfAp_date", "試用期滿日天數", "0"
               , "如需以天數為主請將月份設為0，否則以月份為主", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("AutoIns", "新進人員自動加保詢問", "true"
               , "新進人員資料儲存後跳出詢問視窗", "CheckBox", "", "Boolean");
            AppConfig.CheckParameterAndSetDefault("IDNOCheck", "身分證檢核", "True", "外籍人士是否要提醒身分證需填寫至居留證欄位", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
            AppConfig.CheckParameterAndSetDefault("FULATT_visible", "顯示不計算全勤獎金", "False", "是否顯示不計算全勤獎金的控制項", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
            AppConfig.CheckParameterAndSetDefault("DefaultPasswordMode", "密碼預設行為", "No", "密碼預設帶入身分證位數的模式", "ComboBox", "select 'No' value , '不啟用' display union select 'All', '全部' union select 'Left', '前' union select 'Right', '後'", "String");
            AppConfig.CheckParameterAndSetDefault("DefaultPasswordBegin", "預設身分證第幾碼為開始", "1", "範例:身分證3-8碼=>前 起始3 結束8", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("DefaultPasswordEnd", "預設身分證第幾碼為結束", "4", "範例:身分證後4碼=>後 起始1 結束4", "TextBox", "", "String");
            AppConfig.CheckParameterAndSetDefault("AlertDaysOfApdate", "試用期前幾天跳出提示", "0", "0：關閉，例：前15天=>15", "TextBox", "", "String");
            IDNOCheck = AppConfig.GetConfig("IDNOCheck").GetBoolean(true);
            int AlertDaysOfApdate = AppConfig.GetConfig("AlertDaysOfApdate").GetInter(0);
            if (AlertDaysOfApdate > 0)
            {
                DataTable dt = JBHR.Repo.EmpRepo.GetEmpAllWithDeptByApDate(AlertDaysOfApdate, true);
                if (dt.Rows.Count > 0)
                {
                    PreviewForm frm = new PreviewForm();
                    frm.Size = new Size(640, 480);
                    frm.DataTable = dt;
                    frm.Form_Title = "試用期將滿之員工";
                    frm.ShowDialog(); 
                }
            }

            checkBoxFULATT.Visible = AppConfig.GetConfig("FULATT_visible").GetBoolean(false);
            // TODO: 這行程式碼會將資料載入 'basDS.UserDefine' 資料表。您可以視需要進行移動或移除。
            // TODO:  這行程式碼會將資料載入 'basDS.DOC_ITEM_View' 資料表。您可以視需要進行移動或移除。
            this.dOC_ITEM_ViewTableAdapter.Fill(this.basDS.DOC_ITEM_View);
            Sal.Function.SetAvaliableVBase(this.mainDS.V_BASE);
            #region 必要欄位檢察
            cc = new CheckControl();
            //cc.AddControl(cbMARRY);       //婚姻            
            cc.AddControl(cbSex);       //性別
            cc.AddControl(cbTTSCODE);   //異動狀態
            cc.AddControl(cbWORKCD);    //工作地
            cc.AddControl(cbHOLICD);    //行事曆
            cc.AddControl(cbROTET);     //輪班別
            cc.AddControl(cbEMPCD);     //員別
            cc.AddControl(cbDI);        //直間接
            cc.AddControl(cbJOBL);      //職等
            cc.AddControl(cbJOBS);      //職類
            cc.AddControl(cbJOB);       //職稱
            cc.AddControl(cbDEPTA);     //簽核部門
            cc.AddControl(cbDEPTS);     //成本部門
            cc.AddControl(cbDEPT);      //編制部門
            cc.AddControl(cbCOMP);      //公司別
            cc.AddControl(cbTTSCD);     //異動原因
            cc.AddControl(comboBoxRETCHOO);      //勞退制度
            //cc.AddControl(comboBoxBonusGroup);      //隸屬獎金
            cc.AddControl(cbxCard);
            #endregion
            this.userDefineTableAdapter.Fill(this.basDS.UserDefine);
            this.dOC_ITEMTableAdapter.Fill(this.basDS.DOC_ITEM);
            this.mTCODETableAdapter.FillByCategory(this.mainDS.MTCODE, "DayOrNight");
            this.sUBCODETableAdapter.Fill(this.basDS.SUBCODE);
            SystemFunction.SetComboBoxItems(comboBoxERP, CodeFunction.GetERPCODE(), true, false, true);//ERP
            SystemFunction.SetComboBoxItems(comboBoxBonusGroup, CodeFunction.GetBonusGroup(), true, false, true);//隸屬獎金
            SystemFunction.SetComboBoxItems(comboBoxCostType, CodeFunction.GetCostType(), true, false, true);//成本別
            SystemFunction.SetComboBoxItems(comboBoxDisabilityRank, CodeFunction.GetDisabilityRank(), true, false, true);//殘障身分
            SystemFunction.SetComboBoxItems(comboBoxDisabilityType, CodeFunction.GetDisabilityType(), true, false, true);//殘障類別
            SystemFunction.SetComboBoxItems(comboBoxGroup, CodeFunction.GetGroupType(), true, false, true);//組別
            SystemFunction.SetComboBoxItems(comboBoxJobo, CodeFunction.GetJobo(), true, false, true);//職級
            SystemFunction.SetComboBoxItems(comboBoxLesson, CodeFunction.GetLessonType(), true, false, true);//職級
            SystemFunction.SetComboBoxItems(comboBoxResponsibility, CodeFunction.GetResponsibilityType(), true, false, true);//責任區別
            SystemFunction.SetComboBoxItems(cbCANDIDATES_WAYS, CodeFunction.GetCandidates_ways(), true, false, true);//錄取管道
            SystemFunction.SetComboBoxItems(cbxBanCode, CodeFunction.GetBankCode(), true, false, true);              //銀行代碼
            SystemFunction.SetComboBoxItems(cbxBanCode_MA, CodeFunction.GetBankCode(), true, false, true);              //銀行代碼
            SystemFunction.SetComboBoxItems(comboBoxSALTP, CodeFunction.GetSaltycd(), true, false, true);            //薪別代碼
            SystemFunction.SetComboBoxItems(comboBoxCALOT, CodeFunction.GetOtRatecd(), true, false, true);           //加班比率
            SystemFunction.SetComboBoxItems(comboBoxSALADR, CodeFunction.GetDatagroup(), true, false, true);         //資料群組
            SystemFunction.SetComboBoxItems(cbDoorGuard, CodeFunction.GetDoorGuard(), true, false, true);         //門禁
            SystemFunction.SetComboBoxItems(cbOutPost, CodeFunction.GetOutPost(), true, false, true);         //外派
            SystemFunction.SetComboBoxItems(comboBoxRETCHOO, CodeFunction.GetMtCode("RETCHOO"), true, false, true);  //退休金制度
            SystemFunction.SetComboBoxItems(comboBoxPassType, CodeFunction.GetMtCode("PASS_TYPE"), true, false, true);  //退休金制度

            this.SuspendLayout();
            this.vw_Comp_DatagroupTableAdapter.FillByComp(this.sysDS.vw_Comp_Datagroup, MainForm.COMPANY);
            SystemFunction.SetComboBoxItems(cbBASECD, CodeFunction.GetBasecd(), true, false, true);       //身份別
            Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);
            this.rELCODETableAdapter.Fill(this.basDS.RELCODE);
            this.rELISHCDTableAdapter.Fill(this.basDS.RELISHCD);
            SystemFunction.SetComboBoxItems(cbCOUNTCD, CodeFunction.GetCountcd(), true, false, true);    //國別
            SystemFunction.SetComboBoxItems(cbARMY, CodeFunction.GetMtCode("ARMY"), true, false, true);  //兵役
            SystemFunction.SetComboBoxItems(cbPROVCD, CodeFunction.GetProvcd(), true, false, true);      //戶籍地
            this.eDUCODETableAdapter.Fill(this.basDS.EDUCODE);
            //this.RETCHOOTableAdapter.Fill(this.basDS.RETCHOO);
            //this.OTRATECDTableAdapter.Fill(this.basDS.OTRATECD);
            //this.SALTYCDTableAdapter.Fill(this.basDS.SALTYCD);
            SystemFunction.SetComboBoxItems(cbTTSCODE, CodeFunction.GetMtCode("TTSCODE"), true, false, true);//異動狀態
            SystemFunction.SetComboBoxItems(cbTTSCD, CodeFunction.GetTtscd(), true, false, true);        //異動原因
            SystemFunction.SetComboBoxItems(cbWORKCD, CodeFunction.GetWorkcd(), true, false, true);      //工作地
            SystemFunction.SetComboBoxItems(cbHOLICD, CodeFunction.GetHolicd(), true, false, true);      //行事曆
            SystemFunction.SetComboBoxItems(cbROTET, CodeFunction.GetRotet(), true, false, true);        //輪班別
            SystemFunction.SetComboBoxItems(cbEMPCD, CodeFunction.GetEmpcd(), true, false, true);        //員別
            SystemFunction.SetComboBoxItems(cbDI, CodeFunction.GetMtCode("DI"), true, false, true);      //直間接
            SystemFunction.SetComboBoxItems(cbJOBL, CodeFunction.GetJobl(), true, false, true);          //職等
            SystemFunction.SetComboBoxItems(cbJOBS, CodeFunction.GetJobs(), true, false, true);          //職類
            SystemFunction.SetComboBoxItems(cbJOB, CodeFunction.GetJob(), true, false, true);            //職稱
            SystemFunction.SetComboBoxItems(cbDEPTA, CodeFunction.GetDepta(), true, false, true);        //簽核部門            
            SystemFunction.SetComboBoxItems(cbDEPTS, CodeFunction.GetDepts(), true, false, true);        //成本部門 
            SystemFunction.SetComboBoxItems(comboBoxCONT_REL1, CodeFunction.GetRelcode(), true, false, true);//連絡人1 關係 
            SystemFunction.SetComboBoxItems(comboBoxCONT_REL2, CodeFunction.GetRelcode(), true, false, true);//連絡人2 關係 

            SystemFunction.SetComboBoxItems(cbDEPT, CodeFunction.GetDept(), true, false, true);          //編制部門            
            SystemFunction.SetComboBoxItems(cbCOMP, CodeFunction.GetComp(), true, false, true);          //公司別
            SystemFunction.SetComboBoxItems(cbMARRY, CodeFunction.GetMtCode("MARRY"), true, false, true);//婚姻
            SystemFunction.SetComboBoxItems(cbBLOOD, CodeFunction.GetMtCode("BLOOD"), true, false, true);//血型
            SystemFunction.SetComboBoxItems(cbSex, CodeFunction.GetMtCode("SEX"), true, false, true);    //性別

            this.TTSCDTableAdapter.Fill(this.basDS.TTSCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.WORKCDTableAdapter.Fill(this.basDS.WORKCD);
            this.JOBTableAdapter.Fill(this.basDS.JOB, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.DEPTTableAdapter.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTSTableAdapter.FillBy(this.basDS.DEPTS, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            SystemFunction.SetComboBoxItems(cbDEPTS, CodeFunction.GetDepts_effe(), true, false, true); //成本部門-過濾失效

            var CardList = new Dictionary<string, string>();
            CardList.Add("Y", "Y");
            CardList.Add("N", "N");
            SystemFunction.SetComboBoxItems(cbxCard, CardList, true, false, true);

            this.ResumeLayout();

            fullDataCtrl1.DataAdapter = BASETableAdapter;
            fullDataCtrl2.DataAdapter = BASETTSTableAdapter;

            InitCtrls();
            SetControls(false);

            //TabRule.CheckRule("FRM12", tabControl1);
            SetCauseValid(false);
            CheckRule();
        }

        void ScanTabControls()
        {
            TabPage tabPage = (TabPage)this.tabPage15;
            foreach (Control ctl in tabPage.Controls)
            {
                if (ctl.GetType().Name.ToUpper() == "TABLELAYOUTPANEL")
                    foreach (Control cont in ctl.Controls)
                        TransCaption(cont);
                else TransCaption(ctl);
            }
            tabPage.Refresh();

            #region 繪製自定義欄位
            TabPage tpUDL = (TabPage)this.tpUserDefineLayout;
            controlList = SystemFunction.UserDefineLayoutSetFrmLayout(this, MainForm.COMPANY);
            tpUDL.Refresh();
            if (UserDefineLayout.Controls.Count == 0)
                tabControl1.TabPages.Remove(tpUDL);
            #endregion
        }
        private void TransCaption(Control ctl)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            if (ctl.GetType().Name.ToString().ToUpper() == "LABEL")
            {
                string caption = ctl.Name.ToUpper();
                var ss = from a in db.TableAtt where a.FIELDNAME == caption select a;
                if (ss.Any())
                {
                    ctl.Text = ss.FirstOrDefault().CAPTION;
                    ctl.Visible = ss.FirstOrDefault().DISPLAY;
                }
            }
            else if (ctl.GetType().Name.ToString().ToUpper() == "TEXTBOX")
            {
                JBControls.TextBox _txt = (JBControls.TextBox)ctl;
                string caption = _txt.CaptionLabel.Name;
                var ss = from a in db.TableAtt where a.FIELDNAME == caption select a;
                if (ss.Any())
                {
                    ctl.Text = ss.FirstOrDefault().CAPTION;
                    ctl.Visible = ss.FirstOrDefault().DISPLAY;
                }
                //if (_txt.ValidType == JBControls.TextBox.EValidType.Date)
                //    _txt.ShowCalendarButton = true;
                ctl = _txt;
            }
        }
    

        void InitCtrls()
        {
            if (formMode == FormMode.View)
            {
                bnAdd.Enabled = true;
                bnEdit.Enabled = false;
                bnDel.Enabled = false;
                bnSave.Enabled = false;
                bnCancel.Enabled = false;
                bnQuery.Enabled = true;

                if (basDS.BASE.Count > 0)
                {
                    bnEdit.Enabled = true;
                    bnDel.Enabled = true;
                }

                dataGridViewSCHL.AllowUserToAddRows = false;
                dataGridViewSCHL.AllowUserToDeleteRows = false;
                dataGridViewSCHL.Enabled = false;

                dataGridViewWork.AllowUserToAddRows = false;
                dataGridViewWork.AllowUserToDeleteRows = false;
                dataGridViewWork.Enabled = false;

                dataGridViewMaster.AllowUserToAddRows = false;
                dataGridViewMaster.AllowUserToDeleteRows = false;
                dataGridViewMaster.Enabled = false;

                dataGridViewFamily.AllowUserToAddRows = false;
                dataGridViewFamily.AllowUserToDeleteRows = false;
                dataGridViewFamily.Enabled = false;

                dataGridViewCost.AllowUserToAddRows = false;
                dataGridViewCost.AllowUserToDeleteRows = false;
                dataGridViewCost.Enabled = false;

                dataGridViewLican.AllowUserToAddRows = false;
                dataGridViewLican.AllowUserToDeleteRows = false;
                dataGridViewLican.Enabled = false;
            }
            else
            {
                bnAdd.Enabled = false;
                bnEdit.Enabled = false;
                bnDel.Enabled = false;
                bnSave.Enabled = true;
                bnCancel.Enabled = true;
                bnQuery.Enabled = false;

                dataGridViewSCHL.AllowUserToAddRows = true;
                dataGridViewSCHL.AllowUserToDeleteRows = true;
                dataGridViewSCHL.Enabled = true;

                dataGridViewWork.AllowUserToAddRows = true;
                dataGridViewWork.AllowUserToDeleteRows = true;
                dataGridViewWork.Enabled = true;

                dataGridViewMaster.AllowUserToAddRows = true;
                dataGridViewMaster.AllowUserToDeleteRows = true;
                dataGridViewMaster.Enabled = true;

                dataGridViewFamily.AllowUserToAddRows = true;
                dataGridViewFamily.AllowUserToDeleteRows = true;
                dataGridViewFamily.Enabled = true;

                dataGridViewCost.AllowUserToAddRows = true;
                dataGridViewCost.AllowUserToDeleteRows = true;
                dataGridViewCost.Enabled = true;

                dataGridViewLican.AllowUserToAddRows = true;
                dataGridViewLican.AllowUserToDeleteRows = true;
                dataGridViewLican.Enabled = true;
            }
        }

        private void showQueryData()
        {
            if (BASEbindingSource.Current != null)
            {
                BasDS.BASERow BASERow = (BasDS.BASERow)((DataRowView)BASEbindingSource.Current).Row;
                textBoxNOBR.Text = BASERow.NOBR;
                textBoxNAME_C.Text = BASERow.NAME_C;
                textBoxNAME_E.Text = BASERow.NAME_E;
                textBoxNAME_P.Text = BASERow.NAME_P;
                textBoxIDNO.Text = BASERow.IDNO;
                textBoxBIRDT.Text = (BASERow.IsBIRDTNull()) ? null : BASERow.BIRDT.ToString("yyyyMMdd");
                //textBoxBORN_ADDR.Text = BASERow.BORN_ADDR;
                textBoxPASSWORD.Text = BASERow.PASSWORD;
                cbSex.SelectedValue = BASERow.SEX;
                cbBLOOD.SelectedValue = BASERow.BLOOD;
                cbMARRY.SelectedValue = BASERow.MARRY;
                cbPROVCD.SelectedValue = BASERow.PROVINCE;
                cbARMY.SelectedValue = BASERow.ARMY;
                cbBASECD.SelectedValue = BASERow.BASECD;
                textBoxNAME_AD.Text = BASERow.NAME_AD;
                //textBoxARMY_TYPE.Text = BASERow.ARMY_TYPE;
                cbCOUNTCD.SelectedValue = BASERow.COUNTRY;
                textBoxTAXNO.Text = BASERow.TAXNO;
                textBoxMATNO.Text = BASERow.MATNO;
                checkBoxCOUNT_MA.Checked = BASERow.COUNT_MA;
                textBoxSUBTEL.Text = BASERow.SUBTEL;
                textBoxGSM.Text = BASERow.GSM;
                textBoxEMAIL.Text = BASERow.EMAIL;
                textBoxTEL1.Text = BASERow.TEL1;
                textBoxPOSTCODE1.Text = BASERow.POSTCODE1;
                textBoxADDR1.Text = BASERow.ADDR1;
                textBoxTEL2.Text = BASERow.TEL2;
                textBoxPOSTCODE2.Text = BASERow.POSTCODE2;
                textBoxADDR2.Text = BASERow.ADDR2;
                textBoxPRO_MAN1.Text = BASERow.PRO_MAN1;
                textBoxPRO_ID1.Text = BASERow.PRO_ID1;
                textBoxPRO_TEL1.Text = BASERow.PRO_TEL1;
                textBoxPRO_ADDR1.Text = BASERow.PRO_ADDR1;
                textBoxPRO_MAN2.Text = BASERow.PRO_MAN2;
                textBoxPRO_ID2.Text = BASERow.PRO_ID2;
                textBoxPRO_TEL2.Text = BASERow.PRO_TEL2;
                textBoxPRO_ADDR2.Text = BASERow.PRO_ADDR2;
                textBoxCONT_MAN.Text = BASERow.CONT_MAN;
                comboBoxCONT_REL1.SelectedValue = BASERow.CONT_REL1;
                textBoxCONT_TEL.Text = BASERow.CONT_TEL;
                textBoxCONT_GSM.Text = BASERow.CONT_GSM;
                textBoxCONT_MAN2.Text = BASERow.CONT_MAN2;
                comboBoxCONT_REL2.SelectedValue = BASERow.CONT_REL2;
                textBoxCONT_TEL2.Text = BASERow.CONT_TEL2;
                textBoxCONT_GSM2.Text = BASERow.CONT_GSM2;
                comboBoxDisabilityType.SelectedValue = BASERow.N_NOBR;
                comboBoxDisabilityRank.SelectedValue = BASERow.NOBR_B;

                #region 禾申堂新增
                cbCANDIDATES_WAYS.SelectedValue = BASERow.IsCandidateWaysNull() ? "" : BASERow.CandidateWays;
                //cbGiftVoucher.SelectedValue = BASERow.IsGiftNull() ? "" : BASERow.Gift;
                //txtAdmitDate.Text = BASERow.IsAdmitDateNull() ? "" : Sal.Function.GetDate(BASERow.AdmitDate);
                //txtAdditionDate.Text = BASERow.IsAdditionDateNull() ? "" : Sal.Function.GetDate(BASERow.AdditionDate);
                txtAdditionNO.Text = BASERow.IsAdditionNONull() ? "" : BASERow.AdditionNO;
                ptxIntroductor.Text = BASERow.IsIntroductorNull() ? "" : BASERow.Introductor;
                //chkIntroductionBonus.Checked = BASERow.IsIntroductionBonusNull() ? false : BASERow.IntroductionBonus;
                //chkAboriginal.Checked = BASERow.IsAboriginalNull() ? false : BASERow.Aboriginal;
                //chkDisability.Checked = BASERow.IsDisabilityNull() ? false : BASERow.Disability;
                #endregion

                cbxBanCode.SelectedValue = BASERow.BANKNO;
                cbxBanCode_MA.SelectedValue = BASERow.BANK_CODE;
                textBoxACCOUNT_NO.Text = BASERow.ACCOUNT_NO;
                //textBoxACCOUNT_NA.Text = BASERow.ACCOUNT_NA;
                textBoxACCOUNT_MA.Text = BASERow.ACCOUNT_MA;
                textBoxTAXCNT.Text = BASERow.TAXCNT.ToString();
                textBoxPRETAX.Text = BASERow.PRETAX.ToString();

                textBoxUpName1.Text = BASERow.up1_name;
                textBoxUpName2.Text = BASERow.up2_name;
                textBoxUpName3.Text = BASERow.up3_name;
                textBoxUpName4.Text = BASERow.up4_name;
                textBoxUpName5.Text = BASERow.up5_name;
            }

            if (BASETTSbindingSource.Current != null)
            {
                BasDS.BASETTSRow BASETTSRow = (BasDS.BASETTSRow)((DataRowView)BASETTSbindingSource.Current).Row;
                //SystemFunction.SetComboBoxItems(cbDEPTS, CodeFunction.GetDepts(), true);      //成本部門 

                cbTTSCODE.SelectedValue = BASETTSRow.TTSCODE;
                textBoxADATE.Text = BASETTSRow.ADATE.ToString("yyyyMMdd");
                textBoxINDT.Text = (BASETTSRow.IsINDTNull()) ? "" : BASETTSRow.INDT.ToString("yyyyMMdd");
                textBoxOUDT.Text = (BASETTSRow.IsOUDTNull()) ? "" : BASETTSRow.OUDT.ToString("yyyyMMdd");
                textBoxSTDT.Text = (BASETTSRow.IsSTDTNull()) ? "" : BASETTSRow.STDT.ToString("yyyyMMdd");
                txtReinstateDate.Text = (BASETTSRow.IsReinstateDateNull()) ? "" : BASETTSRow.ReinstateDate.ToString("yyyyMMdd");
                textBoxSTOUDT.Text = (BASETTSRow.IsSTOUDTNull()) ? "" : BASETTSRow.STOUDT.ToString("yyyyMMdd");
                textBoxSTINDT.Text = (BASETTSRow.IsSTINDTNull()) ? "" : BASETTSRow.STINDT.ToString("yyyyMMdd");
                textBoxCINDT.Text = (BASETTSRow.IsCINDTNull()) ? "" : BASETTSRow.CINDT.ToString("yyyyMMdd");
                textBoxAP_DATE.Text = (BASETTSRow.IsAP_DATENull()) ? "" : BASETTSRow.AP_DATE.ToString("yyyyMMdd");
                textBoxAuditDate.Text = (BASETTSRow.IsAuditDateNull()) ? "" : BASETTSRow.AuditDate.ToString("yyyyMMdd");
                comboBoxPassType.SelectedValue = (BASETTSRow.IsPASS_TYPENull()) ? "" : BASETTSRow.PASS_TYPE;
                cbCOMP.SelectedValue = BASETTSRow.COMP;
                cbDEPT.SelectedValue = BASETTSRow.DEPT;
                cbDEPTS.SelectedValue = BASETTSRow.DEPTS;
                cbDEPTA.SelectedValue = BASETTSRow.DEPTM;
                cbJOB.SelectedValue = BASETTSRow.JOB;
                cbJOBS.SelectedValue = BASETTSRow.JOBS;
                cbJOBL.SelectedValue = BASETTSRow.JOBL;
                cbDI.SelectedValue = BASETTSRow.DI;
                cbEMPCD.SelectedValue = BASETTSRow.EMPCD;
                cbxCard.SelectedValue = BASETTSRow.CARD;
                cbROTET.SelectedValue = BASETTSRow.ROTET;
                cbHOLICD.SelectedValue = BASETTSRow.HOLI_CODE;
                cbWORKCD.SelectedValue = BASETTSRow.WORKCD;
                cbTTSCD.SelectedValue = BASETTSRow.TTSCD;
                textBoxWK_YRS.Text = BASETTSRow.WK_YRS.ToString();
                textBoxTAX_DATE.Text = (BASETTSRow.IsTAX_DATENull()) ? "" : BASETTSRow.TAX_DATE.ToString("yyyyMMdd");
                textBoxTAX_EDATE.Text = (BASETTSRow.IsTAX_EDATENull()) ? "" : BASETTSRow.TAX_EDATE.ToString("yyyyMMdd");
                comboBoxSALTP.SelectedValue = BASETTSRow.SALTP;
                comboBoxCALOT.SelectedValue = BASETTSRow.CALOT;
                comboBoxSALADR.SelectedValue = BASETTSRow.SALADR;
                //textBoxGRP_AMT.Text = BASETTSRow.GRP_AMT.ToString();
                //textBoxPASS_DATE.Text = (BASETTSRow.IsPASS_DATENull()) ? "" : BASETTSRow.PASS_DATE.ToString("yyyyMMdd");
                comboBoxRETCHOO.SelectedValue = BASETTSRow.RETCHOO;
                textBoxRETDATE.Text = (BASETTSRow.IsRETDATENull()) ? "" : BASETTSRow.RETDATE.ToString("yyyyMMdd");
                textBoxRETDATE1.Text = (BASETTSRow.IsRETDATE1Null()) ? "" : BASETTSRow.RETDATE1.ToString("yyyyMMdd");
                textBoxRETRATE.Text = BASETTSRow.RETRATE.ToString();
                textBoxMENO.Text = BASETTSRow.MENO;
                //comboBoxINSG_TYPE.SelectedValue = BASETTSRow.INSG_TYPE;
                comboBoxCostType.SelectedValue = BASETTSRow.IsOilSubsidyNull() ? "" : BASETTSRow.OilSubsidy;
                comboBoxBonusGroup.SelectedValue = BASETTSRow.INSG_TYPE;
                comboBoxERP.SelectedValue = (BASETTSRow.IsOldSaladrNull()) ? "" : BASETTSRow.OldSaladr;

                comboBoxGroup.SelectedValue = BASETTSRow.APGRPCD;
                comboBoxJobo.SelectedValue = BASETTSRow.JOBO;
                comboBoxResponsibility.SelectedValue = BASETTSRow.CARCD;
                comboBoxLesson.SelectedValue = BASETTSRow.IsSTATIONNull() ? "" : BASETTSRow.STATION;
                checkBoxNOTLATE.Checked = BASETTSRow.NOTLATE;
                #region 禾申堂新增
                txtCardJobName.Text = BASETTSRow.IsCardJobNameNull() ? "" : BASETTSRow.CardJobName;
                txtCardJobEnName.Text = BASETTSRow.IsCardJobEnNameNull() ? "" : BASETTSRow.CardJobEnName;
                //cbOilSubsidyType.SelectedValue = BASETTSRow.IsOilSubsidyNull() ? "" : BASETTSRow.OilSubsidy;
                txtCardID.Text = BASETTSRow.IsCardIDNull() ? "" : BASETTSRow.CardID;
                cbDoorGuard.SelectedValue = BASETTSRow.IsDoorGuardNull() ? "" : BASETTSRow.DoorGuard;
                cbOutPost.SelectedValue = BASETTSRow.IsOutPostNull() ? "" : BASETTSRow.OutPost;
                //cbSTATION.SelectedValue = BASETTSRow.IsSTATIONNull() ? "" : BASETTSRow.STATION;
                #endregion

                checkBoxCOUNT_PASS.Checked = BASETTSRow.COUNT_PASS;
                checkBoxFIXRATE.Checked = BASETTSRow.FIXRATE;
                checkBoxMANG1.Checked = BASETTSRow.MANG1;
                checkBoxONLYONTIME.Checked = BASETTSRow.ONLYONTIME;
                checkBoxNOEAT.Checked = BASETTSRow.NOEAT;
                checkBoxMANG.Checked = BASETTSRow.MANG;
                checkBoxMANGE.Checked = BASETTSRow.MANGE;
                checkBoxNOWAGE.Checked = BASETTSRow.NOWAGE;
                checkBoxNOOT.Checked = BASETTSRow.NOOT;
                checkBoxNOTER.Checked = BASETTSRow.NOTER;
                checkBoxFULATT.Checked = BASETTSRow.FULATT;
                checkBoxCALABS.Checked = BASETTSRow.CALABS;
                checkBoxNOWEL.Checked = BASETTSRow.NOWEL;
                checkBoxNORET.Checked = BASETTSRow.NORET;
                checkBoxNOOLDRET.Checked = BASETTSRow.NOOLDRET;
                checkBoxNOCARD.Checked = BASETTSRow.NOCARD;
                checkBoxNOSPEC.Checked = BASETTSRow.NOSPEC;
                checkBoxNOSPAMT.Checked = BASETTSRow.NOSPAMT;
                dataGridViewEx7_load(textBoxNOBR.Text.ToString());
            }
        }

        void dataGridViewEx7_load(string Nobr)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = (from bt in db.BASETTS
                       join b in db.BASE on bt.NOBR equals b.NOBR
                       join cp in db.COMP on bt.COMP equals cp.COMP1
                       join mt in db.MTCODE on bt.TTSCODE equals mt.CODE
                       join tc in db.TTSCD on bt.TTSCD equals tc.TTSCD1
                       join dt in db.DEPT on bt.DEPT equals dt.D_NO
                       join dta in db.DEPTA on bt.DEPTM equals dta.D_NO
                       join dts in db.DEPTS on bt.DEPTS equals dts.D_NO
                       join jb in db.JOB on bt.JOB equals jb.JOB1
                       join jbs in db.JOBS on bt.JOBS equals jbs.JOBS1
                       join jbl in db.JOBL on bt.JOBL equals jbl.JOBL1
                       join jbo in db.JOBO on bt.JOBO equals jbo.JOBO1
                       join wk in db.WORKCD on bt.WORKCD equals wk.WORK_CODE
                       where b.NOBR == Nobr
                       && mt.CATEGORY == "TTSCODE"
                       select new
                       {
                           異動代碼 = mt.NAME,
                           異動日期 = bt.ADATE,
                           異動原因 = tc.TTSNAME,
                           公司別 = cp.COMPNAME,
                           編制部門 = string.Format("{0} - {1}", dt.D_NO_DISP, dt.D_NAME),
                           成本部門 = string.Format("{0} - {1}", dta.D_NO_DISP, dta.D_NAME),
                           簽核部門 = string.Format("{0} - {1}", dts.D_NO_DISP, dts.D_NAME),
                           職稱 = string.Format("{0} - {1}", jb.JOB_DISP, jb.JOB_NAME),
                           職類 = string.Format("{0} - {1}", jbs.JOBS_DISP, jbs.JOB_NAME),
                           職等 = string.Format("{0} - {1}", jbl.JOBL_DISP, jbl.JOB_NAME),
                           職級 = string.Format("{0} - {1}", jbo.JOBO1, jbo.JOB_NAME),
                           工作地 = string.Format("{0} - {1}", wk.WORK_CODE, wk.WORK_ADDR),
                           備註 = bt.MENO,
                       });
            dataGridViewEx7.DataSource = sql.CopyToDataTable();
        }

        private void clearShownData()
        {
            pictureBox1.Image = null;

            textBoxNOBR.Text = "";
            textBoxNAME_C.Text = "";
            textBoxNAME_E.Text = "";
            cbxBanCode.SelectedValue = "";
            cbxBanCode_MA.SelectedValue = "";
            textBoxNAME_P.Text = "";
            textBoxIDNO.Text = "";
            textBoxBIRDT.Text = "";
            //textBoxBORN_ADDR.Text = "";
            cbSex.SelectedValue = "";
            cbBLOOD.SelectedValue = "";
            cbMARRY.SelectedValue = "";
            cbPROVCD.SelectedValue = "";
            cbARMY.SelectedValue = "";
            cbBASECD.SelectedValue = "";
            textBoxNAME_AD.Text = "";
            //textBoxARMY_TYPE.Text = "";
            cbCOUNTCD.SelectedValue = "";
            textBoxTAXNO.Text = "";
            textBoxMATNO.Text = "";
            checkBoxCOUNT_MA.Checked = false;
            textBoxSUBTEL.Text = "";
            textBoxPASSWORD.Text = "";
            textBoxGSM.Text = "";
            textBoxEMAIL.Text = "";
            textBoxTEL1.Text = "";
            textBoxPOSTCODE1.Text = "";
            textBoxADDR1.Text = "";
            textBoxTEL2.Text = "";
            textBoxPOSTCODE2.Text = "";
            textBoxADDR2.Text = "";
            textBoxPRO_MAN1.Text = "";
            textBoxPRO_ID1.Text = "";
            textBoxPRO_TEL1.Text = "";
            textBoxPRO_ADDR1.Text = "";
            textBoxPRO_MAN2.Text = "";
            textBoxPRO_ID2.Text = "";
            textBoxPRO_TEL2.Text = "";
            textBoxPRO_ADDR2.Text = "";
            textBoxCONT_MAN.Text = "";
            comboBoxCONT_REL1.SelectedValue = "";
            textBoxCONT_TEL.Text = "";
            textBoxCONT_GSM.Text = "";
            textBoxCONT_MAN2.Text = "";
            comboBoxCONT_REL2.SelectedValue = "";
            textBoxCONT_TEL2.Text = "";
            textBoxCONT_GSM2.Text = "";

            cbxBanCode.SelectedValue = "";
            cbxBanCode_MA.SelectedValue = "";
            textBoxACCOUNT_NO.Text = "";
            //textBoxACCOUNT_NA.Text = "";
            textBoxACCOUNT_MA.Text = "";
            textBoxTAXCNT.Text = "";
            textBoxPRETAX.Text = "";
            comboBoxDisabilityType.SelectedValue = "";
            comboBoxDisabilityRank.SelectedValue = "";
            #region 禾申堂新增
            cbCANDIDATES_WAYS.SelectedValue = "";
            //cbGiftVoucher.SelectedValue = "";
            //txtAdmitDate.Text = "";
            //txtAdditionDate.Text = "";
            txtAdditionNO.Text = "";
            ptxIntroductor.Text = "";
            //chkIntroductionBonus.Checked = false;
            //chkAboriginal.Checked = false;
            //chkDisability.Checked = false;

            txtCardJobName.Text = "";
            txtCardJobEnName.Text = "";
            //cbOilSubsidyType.SelectedValue = "";
            txtCardID.Text = "";
            cbDoorGuard.SelectedValue = "";
            cbOutPost.SelectedValue = "";
            //cbSTATION.SelectedValue = "";
            #endregion

            cbTTSCODE.SelectedValue = "";
            textBoxADATE.Text = "";
            textBoxINDT.Text = "";
            textBoxOUDT.Text = "";
            textBoxSTDT.Text = "";
            textBoxSTINDT.Text = "";
            txtReinstateDate.Text = "";
            textBoxSTOUDT.Text = "";
            textBoxCINDT.Text = "";
            textBoxAP_DATE.Text = "";
            textBoxAuditDate.Text = "";
            comboBoxPassType.SelectedValue = "";
            cbCOMP.SelectedValue = "";
            cbDEPT.SelectedValue = "";
            cbDEPTS.SelectedValue = "";
            cbDEPTA.SelectedValue = "";
            cbJOB.SelectedValue = "";
            cbJOBS.SelectedValue = "";
            cbJOBL.SelectedValue = "";
            cbDI.SelectedValue = "";
            cbEMPCD.SelectedValue = "";
            cbxCard.SelectedValue = "";
            cbROTET.SelectedValue = "";
            cbHOLICD.SelectedValue = "";
            cbWORKCD.SelectedValue = "";
            cbTTSCD.SelectedValue = "";
            //comboBoxINSG_TYPE.SelectedValue = "";
            textBoxWK_YRS.Text = "";
            textBoxTAX_DATE.Text = "";
            textBoxTAX_EDATE.Text = "";
            comboBoxSALTP.SelectedValue = "";
            comboBoxCALOT.SelectedValue = "";
            comboBoxSALADR.SelectedValue = "";
            //textBoxGRP_AMT.Text = "";
            //textBoxPASS_DATE.Text = "";
            comboBoxRETCHOO.SelectedValue = "";
            textBoxRETDATE.Text = "";
            textBoxRETDATE1.Text = "";
            textBoxRETRATE.Text = "";
            textBoxMENO.Text = "";

            textBoxUpName1.Text = "";
            textBoxUpName2.Text = "";
            textBoxUpName3.Text = "";
            textBoxUpName4.Text = "";
            textBoxUpName5.Text = "";

            comboBoxCostType.SelectedValue = "";
            comboBoxBonusGroup.SelectedValue = "";
            comboBoxERP.SelectedValue = "";
            comboBoxGroup.SelectedValue = "";
            comboBoxJobo.SelectedValue = "";
            comboBoxResponsibility.SelectedValue = "";
            comboBoxLesson.SelectedValue = "";
            checkBoxCOUNT_PASS.Checked = false;
            checkBoxFIXRATE.Checked = false;
            checkBoxMANG1.Checked = false;
            checkBoxONLYONTIME.Checked = false;
            checkBoxNOEAT.Checked = false;
            checkBoxMANG.Checked = false;
            checkBoxMANGE.Checked = false;
            checkBoxNOWAGE.Checked = false;
            checkBoxNOOT.Checked = false;
            checkBoxNOTER.Checked = false;
            checkBoxFULATT.Checked = false;
            checkBoxCALABS.Checked = false;
            checkBoxNOWEL.Checked = false;
            checkBoxNORET.Checked = false;
            checkBoxNOOLDRET.Checked = false;
            checkBoxNOCARD.Checked = false;
            checkBoxNOSPEC.Checked = false;
            checkBoxNOSPAMT.Checked = false;
            checkBoxNOTLATE.Checked = false;
            this.basDS.BASE.Clear();
            this.basDS.SCHL.Clear();
            this.basDS.WORKS.Clear();
            this.basDS.MASTER.Clear();
            this.basDS.FAMILY.Clear();
            this.basDS.COST.Clear();
            this.basDS.LICAN.Clear();
            this.basDS.BASETTS.Clear();
            this.basDS1.BASETTS.Clear();
            this.basDS.UserDefine.Clear();
            dataGridViewEx7.DataSource = null;

            TabPage tabPage = (TabPage)this.tabPage15;
            foreach (Control ctl in tabPage.Controls)
            {
                if (ctl.GetType().Name.ToUpper() == "TABLELAYOUTPANEL")
                    foreach (Control cont in ctl.Controls)
                        if (cont.GetType().Name.ToString().ToUpper() == "TEXTBOX")
                            cont.Text = "";
            }

            #region 設置自定欄位預設值
            if (UDLayoutCnt > 0)
            {
                TabPage UDL = (TabPage)this.tpUserDefineLayout;
                foreach (Control ctl in UDL.Controls)
                {
                    if (ctl.GetType().Name.ToUpper() == "TABLELAYOUTPANEL")
                    {
                        HrDBDataContext db = new HrDBDataContext();
                        foreach (var item in ctl.Controls)
                        {
                            Dictionary<string, string> TagList = new Dictionary<string, string>();
                            switch (item)
                            {
                                case TextBox _control:
                                    var DBTB = db.UserDefineLayout.Where(p => p.ControlID.Equals(Guid.Parse(_control.Name))).FirstOrDefault();
                                    TagList = JsonConvert.DeserializeObject<Dictionary<string, string>>(DBTB.Tag);//反序列化
                                    if (DBTB != null)
                                        _control.Text = TagList["Text"];// DBTB.DefaultValue;
                                    else
                                        _control.Text = "";
                                    break;
                                case CheckBox _control:
                                    var DBCB = db.UserDefineLayout.Where(p => p.ControlID.Equals(Guid.Parse(_control.Name))).FirstOrDefault();
                                    TagList = JsonConvert.DeserializeObject<Dictionary<string, string>>(DBCB.Tag);//反序列化
                                    if (DBCB != null)
                                        _control.Checked = Convert.ToBoolean(TagList["Checked"]);// Convert.ToBoolean(DBCB.DefaultValue);
                                    else
                                        _control.Checked = false;
                                    break;
                                case DateTimePicker _control:
                                    var DBDTP = db.UserDefineLayout.Where(p => p.ControlID.Equals(Guid.Parse(_control.Name))).FirstOrDefault();
                                    //if (DBDTP != null && DBDTP.DefaultValue != null && DBDTP.DefaultValue.Trim().Length > 0)
                                    //    _control.Value = Convert.ToDateTime(DBDTP.DefaultValue);
                                    if (DBDTP != null)
                                    {
                                        TagList = JsonConvert.DeserializeObject<Dictionary<string, string>>(DBDTP.Tag);//反序列化
                                        if (TagList.ContainsKey("DateTimeValue"))
                                        {
                                            DateTime dateTime;
                                            if (DateTime.TryParse(TagList["DateTimeValue"], out dateTime))
                                            {
                                                _control.Value = Convert.ToDateTime(TagList["DateTimeValue"]);
                                                _control.CustomFormat = "yyyy/MM/dd";
                                            }
                                            else
                                            {
                                                _control.Value = DateTime.Today;
                                                _control.CustomFormat = " ";
                                                _control.Checked = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        _control.Value = DateTime.Today;
                                        _control.Checked = false;
                                    }
                                    break;
                                case ComboBox _control:
                                    if (_control.Items.Count > 0)
                                        _control.SelectedIndex = 0;
                                    break;
                                case NumericUpDown _control:
                                    var DBNUD = db.UserDefineLayout.Where(p => p.ControlID.Equals(Guid.Parse(_control.Name))).FirstOrDefault();
                                    TagList = JsonConvert.DeserializeObject<Dictionary<string, string>>(DBNUD.Tag);//反序列化
                                    if (DBNUD != null)
                                        _control.Value = Convert.ToDecimal(TagList["NumericValue"]);//Convert.ToDecimal(DBNUD.DefaultValue);
                                    else
                                        _control.Value = 0;
                                    break;
                            }
                        }
                    }
                }
            }
            #endregion
        }
        private void SetControls(bool is_enable)
        {
            textBoxNOBR.Enabled = is_enable;
            textBoxNAME_C.Enabled = is_enable;
            textBoxNAME_E.Enabled = is_enable;
            cbxBanCode.Enabled = is_enable;
            cbxBanCode_MA.Enabled = is_enable;
            textBoxNAME_P.Enabled = is_enable;
            textBoxIDNO.Enabled = is_enable;
            textBoxBIRDT.Enabled = is_enable;
            //textBoxBORN_ADDR.Enabled = is_enable;
            cbSex.Enabled = is_enable;
            cbBLOOD.Enabled = is_enable;
            cbMARRY.Enabled = is_enable;
            cbPROVCD.Enabled = is_enable;
            cbARMY.Enabled = is_enable;
            cbBASECD.Enabled = is_enable;
            textBoxNAME_AD.Enabled = is_enable;
            //textBoxARMY_TYPE.Enabled = is_enable;
            cbCOUNTCD.Enabled = is_enable;
            textBoxTAXNO.Enabled = is_enable;
            textBoxMATNO.Enabled = is_enable;
            checkBoxCOUNT_MA.Enabled = is_enable;
            textBoxSUBTEL.Enabled = is_enable;
            textBoxPASSWORD.Enabled = is_enable;
            textBoxGSM.Enabled = is_enable;
            textBoxEMAIL.Enabled = is_enable;
            textBoxTEL1.Enabled = is_enable;
            textBoxPOSTCODE1.Enabled = is_enable;
            textBoxADDR1.Enabled = is_enable;
            textBoxTEL2.Enabled = is_enable;
            textBoxPOSTCODE2.Enabled = is_enable;
            textBoxADDR2.Enabled = is_enable;
            textBoxPRO_MAN1.Enabled = is_enable;
            textBoxPRO_ID1.Enabled = is_enable;
            textBoxPRO_TEL1.Enabled = is_enable;
            textBoxPRO_ADDR1.Enabled = is_enable;
            textBoxPRO_MAN2.Enabled = is_enable;
            textBoxPRO_ID2.Enabled = is_enable;
            textBoxPRO_TEL2.Enabled = is_enable;
            textBoxPRO_ADDR2.Enabled = is_enable;
            textBoxCONT_MAN.Enabled = is_enable;
            comboBoxCONT_REL1.Enabled = is_enable;
            textBoxCONT_TEL.Enabled = is_enable;
            textBoxCONT_GSM.Enabled = is_enable;
            textBoxCONT_MAN2.Enabled = is_enable;
            comboBoxCONT_REL2.Enabled = is_enable;
            textBoxCONT_TEL2.Enabled = is_enable;
            textBoxCONT_GSM2.Enabled = is_enable;

            cbxBanCode.Enabled = is_enable;
            cbxBanCode_MA.Enabled = is_enable;
            textBoxACCOUNT_NO.Enabled = is_enable;
            //textBoxACCOUNT_NA.Enabled = is_enable;
            textBoxACCOUNT_MA.Enabled = is_enable;
            textBoxTAXCNT.Enabled = is_enable;
            textBoxPRETAX.Enabled = is_enable;
            comboBoxDisabilityType.Enabled = is_enable;
            comboBoxDisabilityRank.Enabled = is_enable;


            cbTTSCODE.Enabled = false;//is_enable;
            textBoxADATE.Enabled = is_enable;
            textBoxINDT.Enabled = false;
            textBoxOUDT.Enabled = false;
            textBoxSTDT.Enabled = false;
            textBoxSTINDT.Enabled = false;
            txtReinstateDate.Enabled = is_enable;
            textBoxSTOUDT.Enabled = false;
            textBoxCINDT.Enabled = is_enable;
            textBoxAP_DATE.Enabled = is_enable;
            textBoxAuditDate.Enabled = is_enable;
            comboBoxPassType.Enabled = is_enable;
            cbCOMP.Enabled = is_enable;//多公司版都是FALSE
            cbDEPT.Enabled = is_enable;
            cbDEPTS.Enabled = is_enable;
            cbDEPTA.Enabled = is_enable;
            cbJOB.Enabled = is_enable;
            cbJOBS.Enabled = is_enable;
            cbJOBL.Enabled = is_enable;
            cbDI.Enabled = is_enable;
            cbEMPCD.Enabled = is_enable;
            cbxCard.Enabled = is_enable;
            cbROTET.Enabled = is_enable;
            cbHOLICD.Enabled = is_enable;
            cbWORKCD.Enabled = is_enable;
            cbTTSCD.Enabled = is_enable;
            textBoxWK_YRS.Enabled = is_enable;
            textBoxTAX_DATE.Enabled = is_enable;
            textBoxTAX_EDATE.Enabled = is_enable;
            comboBoxSALTP.Enabled = is_enable;
            comboBoxCALOT.Enabled = is_enable;
            comboBoxSALADR.Enabled = is_enable;
            //textBoxGRP_AMT.Enabled = is_enable;
            //textBoxPASS_DATE.Enabled = is_enable;
            comboBoxRETCHOO.Enabled = is_enable;
            textBoxRETDATE.Enabled = is_enable;
            textBoxRETDATE1.Enabled = is_enable;
            textBoxRETRATE.Enabled = is_enable;
            textBoxMENO.Enabled = is_enable;
            //comboBoxINSG_TYPE.Enabled = is_enable;

            checkBoxCOUNT_PASS.Enabled = is_enable;
            checkBoxFIXRATE.Enabled = is_enable;
            checkBoxMANG1.Enabled = is_enable;
            checkBoxONLYONTIME.Enabled = is_enable;
            checkBoxNOEAT.Enabled = is_enable;
            checkBoxMANG.Enabled = is_enable;
            checkBoxMANGE.Enabled = is_enable;
            checkBoxNOWAGE.Enabled = is_enable;
            checkBoxNOOT.Enabled = is_enable;
            checkBoxNOTER.Enabled = is_enable;
            checkBoxFULATT.Enabled = is_enable;
            checkBoxCALABS.Enabled = is_enable;
            checkBoxNOWEL.Enabled = is_enable;
            checkBoxNORET.Enabled = is_enable;
            checkBoxNOOLDRET.Enabled = is_enable;
            checkBoxNOCARD.Enabled = is_enable;
            checkBoxNOSPEC.Enabled = is_enable;
            checkBoxNOSPAMT.Enabled = is_enable;
            checkBoxNOTLATE.Checked = is_enable;

            bnPic.Enabled = is_enable;
            bnClearPic.Enabled = is_enable;
            bnUp1.Enabled = is_enable;
            bnCr1.Enabled = is_enable;
            bnOp1.Enabled = is_enable;
            bnUp2.Enabled = is_enable;
            bnCr2.Enabled = is_enable;
            bnOp2.Enabled = is_enable;
            bnUp3.Enabled = is_enable;
            bnCr3.Enabled = is_enable;
            bnOp3.Enabled = is_enable;
            bnUp4.Enabled = is_enable;
            bnCr4.Enabled = is_enable;
            bnOp4.Enabled = is_enable;
            bnUp5.Enabled = is_enable;
            bnCr5.Enabled = is_enable;
            bnOp5.Enabled = is_enable;
            //使用者自定義
            //
            TabPage tabPage = (TabPage)this.tabPage15;
            foreach (Control ctl in tabPage.Controls)
            {
                if (ctl.GetType().Name.ToUpper() == "TABLELAYOUTPANEL")
                    foreach (Control cont in ctl.Controls)
                        if (cont.GetType().Name.ToString().ToUpper() == "TEXTBOX")
                            cont.Enabled = is_enable;
            }

            #region 啟用/停用自定義欄位
            //啟用/停用自定義欄位
            SystemFunction.SetUserDefineEnable(controlList, is_enable);
            #endregion

            #region 禾申堂新增
            cbCANDIDATES_WAYS.Enabled = is_enable;
            //cbGiftVoucher.Enabled = is_enable;
            //txtAdmitDate.Enabled = is_enable;
            //txtAdditionDate.Enabled = is_enable;
            txtAdditionNO.Enabled = is_enable;
            ptxIntroductor.Enabled = is_enable;
            //chkIntroductionBonus.Enabled = is_enable;
            //chkAboriginal.Enabled = is_enable;
            //chkDisability.Enabled = is_enable;
            comboBoxLesson.Enabled = is_enable;
            txtCardJobName.Enabled = is_enable;
            txtCardJobEnName.Enabled = is_enable;
            //cbOilSubsidyType.Enabled = is_enable;
            comboBoxBonusGroup.Enabled = is_enable;
            comboBoxERP.Enabled = is_enable;
            comboBoxCostType.Enabled = is_enable;
            comboBoxGroup.Enabled = is_enable;
            comboBoxJobo.Enabled = is_enable;
            comboBoxResponsibility.Enabled = is_enable;
            txtCardID.Enabled = is_enable;
            cbDoorGuard.Enabled = is_enable;
            cbOutPost.Enabled = is_enable;
            //cbSTATION.Enabled = is_enable;
            #endregion
        }

        private void SetCauseValid(bool is_enable)
        {
            textBoxNOBR.CausesValidation = is_enable;
            textBoxNAME_C.CausesValidation = is_enable;
            textBoxNAME_E.CausesValidation = is_enable;
            textBoxBIRDT.CausesValidation = is_enable;
            cbSex.CausesValidation = is_enable;
            cbMARRY.CausesValidation = is_enable;
            textBoxPASSWORD.CausesValidation = is_enable;
            cbTTSCODE.CausesValidation = is_enable;
            textBoxADATE.CausesValidation = is_enable;
            textBoxCINDT.CausesValidation = is_enable;
            cbCOMP.CausesValidation = is_enable;
            cbDEPT.CausesValidation = is_enable;
            cbDEPTS.CausesValidation = is_enable;
            cbDEPTA.CausesValidation = is_enable;
            cbJOB.CausesValidation = is_enable;
            cbJOBS.CausesValidation = is_enable;
            cbJOBL.CausesValidation = is_enable;
            cbDI.CausesValidation = is_enable;
            cbEMPCD.CausesValidation = is_enable;
            cbROTET.CausesValidation = is_enable;
            cbHOLICD.CausesValidation = is_enable;
            cbWORKCD.CausesValidation = is_enable;
            cbTTSCD.CausesValidation = is_enable;
            comboBoxSALTP.CausesValidation = is_enable;
            comboBoxCALOT.CausesValidation = is_enable;
            comboBoxSALADR.CausesValidation = is_enable;
            comboBoxRETCHOO.CausesValidation = is_enable;
            //使用者自定義
            //
            TabPage tabPage = (TabPage)this.tabPage15;
            foreach (Control ctl in tabPage.Controls)
            {
                if (ctl.GetType().Name.ToUpper() == "TABLELAYOUTPANEL")
                    foreach (Control cont in ctl.Controls)
                        if (cont.GetType().Name.ToString().ToUpper() == "TEXTBOX")
                            cont.Enabled = is_enable;
            }
        }

        private void popupTextBox1_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            FRM12DataClassesDataContext FRM12Context = new FRM12DataClassesDataContext();
           if (formMode == FormMode.Add)
            {
                var checkExists = FRM12Context.BASE.Where(p => p.NOBR == e.code);
                if (checkExists.Any())
                {
                    MessageBox.Show(Resources.Bas.NOBRREPETITION, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNOBR.Text = "";
                }
            }

            if (formMode == FormMode.Edit || formMode == FormMode.View)
            {
                basDS.BASE.Clear();
                basDS.BASETTS.Clear();
                if (e == null || e.HasData)
                {
                    if (formMode == FormMode.Edit) bnSave.Enabled = true;
                    else bnSave.Enabled = false;
                    if (!Sal.Function.CanView(textBoxNOBR.Text))
                    {
                        MessageBox.Show("你沒有查詢該員工資料的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    IQueryable<BASE> BASEQuery;
                    BASEQuery = from c in FRM12Context.BASE
                                where c.NOBR.Trim() == textBoxNOBR.Text
                                select c;
                    //int bqCount = BASEQuery.Count();
                    var SCHLQuery = from c in FRM12Context.SCHL
                                    join b in FRM12Context.BASETTS on c.NOBR equals b.NOBR
                                    where c.NOBR == textBoxNOBR.Text
                                    && DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                                    select new { c, b.DEPT, b.JOB, b.TTSCODE };
                    IQueryable<EntitySet<WORKS>> WORKSQuery = from c in BASEQuery where c.WORKS.Any() select c.WORKS;
                    IQueryable<EntitySet<MASTER>> MASTERQuery = from c in BASEQuery where c.MASTER.Any() select c.MASTER;
                    IQueryable<EntitySet<FAMILY>> FAMILYQuery = from c in BASEQuery where c.FAMILY.Any() select c.FAMILY;
                    //IQueryable<EntitySet<COST>> COSTQuery = from c in BASEQuery where c.COST.Any() select c.COST;
                    IQueryable<EntitySet<LICAN>> LICANQuery = from c in BASEQuery where c.LICAN.Any() select c.LICAN;
                    IQueryable<EntitySet<BASETTS>> BASETTSQuery1 = from c in BASEQuery where c.BASETTS.Any() select c.BASETTS;
                    IQueryable<EntitySet<UserDefine>> UserdefineQuery = from c in BASEQuery where c.UserDefine.Any() select c.UserDefine;

                    BasDSTableAdapters.PAY_DOCTableAdapter paydocAD = new BasDSTableAdapters.PAY_DOCTableAdapter();
                    try
                    {
                        if (FRM12Context.Connection.State == ConnectionState.Closed) FRM12Context.Connection.Open();

                        var drBASE = FRM12Context.GetCommand(BASEQuery).ExecuteReader();
                        if (drBASE.HasRows) basDS.BASE.Load(drBASE);
                        drBASE.Close();


                        if (basDS.BASE.Count > 0)
                        {
                            var drSCHL = FRM12Context.GetCommand(SCHLQuery).ExecuteReader();
                            //int drSCHLcount = drSCHL.FieldCount;
                            basDS.SCHL.Load(drSCHL);
                            drSCHL.Close();

                            var drWORKS = FRM12Context.GetCommand(WORKSQuery).ExecuteReader();
                            //int drWORKScount = drWORKS.FieldCount;
                            basDS.WORKS.Clear();
                            basDS.WORKS.Load(drWORKS);
                            drWORKS.Close();

                            var drMASTER = FRM12Context.GetCommand(MASTERQuery).ExecuteReader();
                            basDS.MASTER.Load(drMASTER);
                            drMASTER.Close();

                            var drFAMILY = FRM12Context.GetCommand(FAMILYQuery).ExecuteReader();
                            basDS.FAMILY.Load(drFAMILY);
                            drFAMILY.Close();

                            //var drCOST = FRM12Context.GetCommand(COSTQuery).ExecuteReader();
                            //basDS.COST.Load(drCOST);
                            //drCOST.Close();

                            this.COSTTableAdapter.FillBy(this.basDS.COST, textBoxNOBR.Text);

                            var drLICAN = FRM12Context.GetCommand(LICANQuery).ExecuteReader();
                            basDS.LICAN.Load(drLICAN);
                            drLICAN.Close();

                            var drBASETTS1 = FRM12Context.GetCommand(BASETTSQuery1).ExecuteReader();
                            basDS1.BASETTS.Load(drBASETTS1);
                            drBASETTS1.Close();

                            var drUserDefine = FRM12Context.GetCommand(UserdefineQuery).ExecuteReader();
                            basDS.UserDefine.Load(drUserDefine);
                            drUserDefine.Close();

                            paydocAD.FillByNobr(basDS.PAY_DOC, textBoxNOBR.Text, "PayDoc");

                            var drBASETTS_Curr = (from c in basDS1.BASETTS where basDS1.BASETTS.Max(BASETTS => BASETTS.ADATE) == c.ADATE select c).First();

                            if (!basDS.BASETTS.Any(row => row.ADATE.Date == drBASETTS_Curr.ADATE.Date))
                            {
                                basDS.BASETTS.ImportRow(drBASETTS_Curr);
                            }

                            #region 讀取員工自定欄位的設定值
                            SystemFunction.UserDefineLayoutGetValue(controlList, textBoxNOBR.Text);
                            #endregion
                        }
                    }
                    finally
                    {
                        FRM12Context.Connection.Close();
                    }

                    showQueryData();

                    //合同
                    var ContractData = from a in BASEQuery.First().Contract
                                       //join b in FRM12Context.ContractType on a.ContractType equals b.Code
                                       //join c in FRM12Context.WORKCD on a.WorkAdr equals c.WORK_CODE
                                       select new
                                       {
                                           合同種類 = a.ContractType1.DisplayName,
                                           起始日期 = a.Adate,
                                           到期日期 = a.Ddate,
                                           隸屬地 = a.WORKCD.WORK_ADDR
                                       };
                    dgvContract.DataSource = ContractData.CopyToDataTable();
                    BasDS.BASERow baseRow = (BASEbindingSource.Current as DataRowView).Row as BasDS.BASERow;
                    if (baseRow.IsPHOTONull() || baseRow.PHOTO.Length == 0) pictureBox1.Image = null;
                    else
                    {
                        var phtotoBinary = BASEQuery.First().PHOTO;
                        pictureBox1.Image = Image.FromStream(new MemoryStream(phtotoBinary.ToArray()));
                    }
                    //DateTime d1 = DateTime.Now;
                    //DateTime d2 = DateTime.Now;
                    //DateTime d3 = d1;
                    //DateTime d4 = d2;
                    //     double totalDays = basDS1.BASETTS.Sum(
                    //     ROW =>
                    //     {
                    //         if (new string[] { "1", "4", "6" }.Contains(ROW.TTSCODE)) //需求修改(Lanayeh)人事模組-集團到職日與在職年資 by 建華 2012/11/16
                    //         {
                    //             //需求修改(Lanayeh)人事模組-公司到職日與在職年資 by serlina 2012/12/6
                    //             if (ROW.DDATE < ROW.INDT)
                    //             {
                    //                 return 0;
                    //             }
                    //             else if (ROW.TTSCODE == "1")
                    //             {
                    //                 //d1 = ROW.CINDT;
                    //                 //d2 = ROW.DDATE;
                    //                 if (ROW.DDATE < ROW.INDT)
                    //                 {
                    //                     return 0;
                    //                 }
                    //                 else
                    //                 {
                    //                     if (ROW.ADATE > DateTime.Now)
                    //                     {
                    //                         return 0;
                    //                     }
                    //                     else if (ROW.DDATE >= DateTime.Now && ROW.ADATE < DateTime.Now)
                    //                     {
                    //                         return (DateTime.Now.Date - ROW.INDT).TotalDays + 1;
                    //                     }
                    //                     else
                    //                     {
                    //                         return (ROW.DDATE - ROW.INDT).TotalDays + 1;
                    //                     }
                    //                 }
                    //             }
                    //             else if (ROW.ADATE <= ROW.INDT && ROW.DDATE >= ROW.INDT)
                    //             {
                    //                 //d3 = ROW.CINDT;
                    //                 //d4 = ROW.DDATE;
                    //                 if (ROW.ADATE > DateTime.Now)
                    //                 {
                    //                     return 0;
                    //                 }
                    //                 else if (ROW.DDATE >= DateTime.Now && ROW.INDT <= DateTime.Now)
                    //                 {
                    //                     //d4 = DateTime.Now.Date;
                    //                     return (DateTime.Now.Date - ROW.INDT).TotalDays + 1;
                    //                 }
                    //                 else
                    //                 {
                    //                     return (ROW.DDATE - ROW.INDT).TotalDays + 1;
                    //                 }
                    //             }
                    //             else
                    //             {
                    //                 //    d3 = ROW.CINDT;
                    //                 //    d4 = ROW.DDATE;
                    //                 if (ROW.DDATE >= DateTime.Now && ROW.ADATE <= DateTime.Now)
                    //                 {
                    //                     //d3 = ROW.ADATE;
                    //                     //d4 = DateTime.Now.Date;
                    //                     return (DateTime.Now.Date - ROW.ADATE).TotalDays + 1;
                    //                 }
                    //                 else if (ROW.ADATE > DateTime.Now)
                    //                 {
                    //                     return 0;
                    //                 }
                    //                 else
                    //                 {
                    //                     //d3 = ROW.ADATE;
                    //                     //d4 = ROW.DDATE;
                    //                     return (ROW.DDATE - ROW.ADATE).TotalDays + 1;
                    //                 }
                    //             }
                    //         }
                    //         else return 0;
                    //     }
                    //);

                    //double ds1 = (d2 - d1).TotalDays;
                    //double ds2 = (d4 - d3).TotalDays;
                    //textBoxINYEAR.Text = Convert.ToDecimal(Math.Round(totalDays / 365.25, 2)).ToYearMonthString();
                    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                    textBoxINYEAR.Text = (from a in basDS1.BASETTS select db.GetTotalYearsWithoutExternal(a.NOBR, DateTime.Today).Value.ToYearMonthString()).FirstOrDefault();

                    double total_reday = basDS1.BASETTS.Sum(
                        ROW =>
                        {
                            if (new string[] { "2", "3", "5" }.Contains(ROW.TTSCODE))
                            {
                                if (ROW.DDATE > DateTime.Now)
                                {
                                    return (DateTime.Now.Date - ROW.ADATE).TotalDays + 1;
                                }
                                else return (ROW.DDATE - ROW.ADATE).TotalDays + 1;
                            }
                            else return 0;
                        }
                    );

                    textBoxRE_DAY.Text = Math.Round(total_reday, 0).ToString();
                    textBoxRE_INDT.Text = basDS.BASETTS[0].CINDT.AddDays(Math.Round(total_reday, 0)).ToString();
                    txtReinstateDate.Text = basDS.BASETTS[0].IsReinstateDateNull() ? "" : Sal.Function.GetDate(basDS.BASETTS[0].ReinstateDate);

                    InitCtrls();
                    SetControls(false);

                    if (textBoxUpName1.Text.Trim().Length > 0) bnOp1.Enabled = true;
                    else bnOp1.Enabled = false;
                    if (textBoxUpName2.Text.Trim().Length > 0) bnOp2.Enabled = true;
                    else bnOp2.Enabled = false;
                    if (textBoxUpName3.Text.Trim().Length > 0) bnOp3.Enabled = true;
                    else bnOp3.Enabled = false;
                    if (textBoxUpName4.Text.Trim().Length > 0) bnOp4.Enabled = true;
                    else bnOp4.Enabled = false;
                    if (textBoxUpName5.Text.Trim().Length > 0) bnOp5.Enabled = true;
                    else bnOp5.Enabled = false;

                    textBoxNOBR.Enabled = false;
                    cbTTSCODE.Enabled = false;
                    textBoxADATE.Enabled = false;
                }
            }
            CheckRule();
        }

        private void bnAdd_Click(object sender, EventArgs e)
        {
            SetCauseValid(true);
            textBoxNOBR.DataSource = null;
            formMode = FormMode.Add;
            InitCtrls();
            clearShownData();
            SetControls(true);

            fullDataCtrl1.bnAdd_Click(sender, e);
            fullDataCtrl2.bnAdd_Click(sender, e);

            cbTTSCODE.Enabled = false;
            textBoxNOBR.Enabled = true;//提供自行修改

            SetNewDefault();
            cbTTSCODE.SelectedValue = "1";
            textBoxADATE.Text = DateTime.Now.ToString("yyyyMMdd");
            //textBoxCINDT.Text = DateTime.Now.ToString("yyyyMMdd");
            //textBoxINDT.Text = DateTime.Now.ToString("yyyyMMdd");
            SetAp_date();
            textBoxRETDATE.Text = DateTime.Now.ToString("yyyyMMdd");
            textBoxRETDATE1.Text = DateTime.Now.ToString("yyyyMMdd");
            //cbTTSCD.SelectedValue = "01";
            comboBoxSALADR.SelectedValue = MainForm.WORKADR;
            comboBoxRETCHOO.SelectedValue = "2";
            //cbTTSCD.SelectedValue = "01";
            if (MainForm.ReadRules.Any())
                comboBoxSALADR.SelectedValue = MainForm.ReadRules.First().DATAGROUP;
            cbCOMP.SelectedValue = MainForm.COMPANY;

            bnOp1.Enabled = false;
            bnOp2.Enabled = false;
            bnOp3.Enabled = false;
            bnOp4.Enabled = false;
            bnOp5.Enabled = false;

            bnCr1.Enabled = false;
            bnCr2.Enabled = false;
            bnCr3.Enabled = false;
            bnCr4.Enabled = false;
            bnCr5.Enabled = false;

            textBoxNOBR.Focus();
            SetCode(JBControls.FullDataCtrl.EEditType.Add);
        }

        private void bnEdit_Click(object sender, EventArgs e)
        {
            SetCauseValid(true);
            BasDS.BASETTSRow BASETTSRow = (BasDS.BASETTSRow)((DataRowView)BASETTSbindingSource.Current).Row;
            SetCode(JBControls.FullDataCtrl.EEditType.Modify);
            cbDEPTS.SelectedValue = BASETTSRow.DEPTS;


            formMode = FormMode.Edit;
            InitCtrls();

            fullDataCtrl1.bnEdit_Click(null, null);
            fullDataCtrl2.bnEdit_Click(null, null);
            SetControls(true);
            if (cbTTSCODE.SelectedValue.ToString() != "1") textBoxADATE.Enabled = false;

            if (textBoxUpName1.Text.Trim().Length > 0)
            {
                bnCr1.Enabled = true;
                bnOp1.Enabled = true;
            }
            else
            {
                bnCr1.Enabled = false;
                bnOp1.Enabled = false;
            }
            if (textBoxUpName2.Text.Trim().Length > 0)
            {
                bnCr2.Enabled = true;
                bnOp2.Enabled = true;
            }
            else
            {
                bnCr2.Enabled = false;
                bnOp2.Enabled = false;
            }
            if (textBoxUpName3.Text.Trim().Length > 0)
            {
                bnCr3.Enabled = true;
                bnOp3.Enabled = true;
            }
            else
            {
                bnCr3.Enabled = false;
                bnOp3.Enabled = false;
            }
            if (textBoxUpName4.Text.Trim().Length > 0)
            {
                bnCr4.Enabled = true;
                bnOp4.Enabled = true;
            }
            else
            {
                bnCr4.Enabled = false;
                bnOp4.Enabled = false;
            }
            if (textBoxUpName5.Text.Trim().Length > 0)
            {
                bnCr5.Enabled = true;
                bnOp5.Enabled = true;
            }
            else
            {
                bnCr5.Enabled = false;
                bnOp5.Enabled = false;
            }

            bnAdd.Enabled = false;
            bnEdit.Enabled = false;
            bnDel.Enabled = false;
            bnSave.Enabled = true;
            bnCancel.Enabled = true;
            bnQuery.Enabled = false;

            textBoxNOBR.Enabled = false;

            textBoxNAME_C.Focus();
        }

        private void bnDel_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show(Resources.All.DeleteConfirm, Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Sal.Function.CanModify(textBoxNOBR.Text))
                {
                    fullDataCtrl1.bnDel_Click(sender, e);
                    clearShownData();
                }
                else
                {
                    MessageBox.Show("你沒有刪除該員工資料的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            SetCauseValid(false);
            if (formMode == FormMode.Add)
            {
                fullDataCtrl1.bnCancel_Click(sender, e);
                fullDataCtrl2.bnCancel_Click(sender, e);

                basDS.SCHL.RejectChanges();
                basDS.WORKS.RejectChanges();
                basDS.MASTER.RejectChanges();
                basDS.FAMILY.RejectChanges();
                basDS.COST.RejectChanges();
                basDS.LICAN.RejectChanges();
                basDS.PAY_DOC.RejectChanges();
                basDS.UserDefine.RejectChanges();

                foreach (DataRow row in basDS.SCHL.GetErrors()) row.ClearErrors();
                foreach (DataRow row in basDS.WORKS.GetErrors()) row.ClearErrors();
                foreach (DataRow row in basDS.MASTER.GetErrors()) row.ClearErrors();
                foreach (DataRow row in basDS.FAMILY.GetErrors()) row.ClearErrors();
                foreach (DataRow row in basDS.COST.GetErrors()) row.ClearErrors();
                foreach (DataRow row in basDS.LICAN.GetErrors()) row.ClearErrors();
                foreach (DataRow row in basDS.PAY_DOC.GetErrors()) row.ClearErrors();
                foreach (DataRow row in basDS.UserDefine.GetErrors()) row.ClearErrors();
            }

            formMode = FormMode.View;
            InitCtrls();
            textBoxNOBR.Enabled = false;

            SetControls(false);
            if (MainForm.NobrListOfRead.Contains(textBoxNOBR.Text))
                showQueryData();

            if (textBoxUpName1.Text.Trim().Length > 0) bnOp1.Enabled = true;
            else bnOp1.Enabled = false;
            if (textBoxUpName2.Text.Trim().Length > 0) bnOp2.Enabled = true;
            else bnOp2.Enabled = false;
            if (textBoxUpName3.Text.Trim().Length > 0) bnOp3.Enabled = true;
            else bnOp3.Enabled = false;
            if (textBoxUpName4.Text.Trim().Length > 0) bnOp4.Enabled = true;
            else bnOp4.Enabled = false;
            if (textBoxUpName5.Text.Trim().Length > 0) bnOp5.Enabled = true;
            else bnOp5.Enabled = false;

            if (textBoxNOBR.Text.Trim().Length == 0) clearShownData();
            CheckRule();
            errorProvider1.Clear();
        }

        private void dataGridViewEx_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //不要懷疑，這個事件真的有用，移除的話必當！
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            JBControls.DataGridView dgv = sender as JBControls.DataGridView;
            BindingSource dgv_bindingSource = dgv.DataSource as BindingSource;

            (dgv_bindingSource.Current as DataRowView)["NOBR"] = textBoxNOBR.Text;
            if ((dgv_bindingSource.Current as DataRowView).DataView.Table.Columns.Contains("KEY_DATE"))
                (dgv_bindingSource.Current as DataRowView)["KEY_DATE"] = DateTime.Now;
            if ((dgv_bindingSource.Current as DataRowView).DataView.Table.Columns.Contains("KEY_MAN"))
                (dgv_bindingSource.Current as DataRowView)["KEY_MAN"] = MainForm.USER_NAME;
            if ((dgv_bindingSource.Current as DataRowView).DataView.Table.Columns.Contains("KEYDATE"))
                (dgv_bindingSource.Current as DataRowView)["KEYDATE"] = DateTime.Now;
            if ((dgv_bindingSource.Current as DataRowView).DataView.Table.Columns.Contains("KEYMAN"))
                (dgv_bindingSource.Current as DataRowView)["KEYMAN"] = MainForm.USER_NAME;
            if ((dgv_bindingSource.Current as DataRowView).DataView.Table.Columns.Contains("CDDATE"))
                (dgv_bindingSource.Current as DataRowView)["CDDATE"] = new DateTime(9999, 12, 31);

            DataRow curr_row = (dgv_bindingSource.Current as DataRowView).Row;
            foreach (DataColumn dc in curr_row.Table.Columns)
            {
                if ((dgv_bindingSource.Current as DataRowView)[dc.ColumnName] == DBNull.Value)
                {
                    Type t = dc.DataType;
                    if (t == typeof(string)) (dgv_bindingSource.Current as DataRowView)[dc.ColumnName] = "";
                    if (t == typeof(bool)) (dgv_bindingSource.Current as DataRowView)[dc.ColumnName] = false;
                    if (t == typeof(int)) (dgv_bindingSource.Current as DataRowView)[dc.ColumnName] = 0;
                    if (t == typeof(decimal) || t == typeof(double)) (dgv_bindingSource.Current as DataRowView)[dc.ColumnName] = 0.00;
                    if (t == typeof(DateTime) && !dc.AllowDBNull) (dgv_bindingSource.Current as DataRowView)[dc.ColumnName] = DateTime.Now.Date;
                }
                else if (dc.DataType == typeof(DateTime))
                {
                    DateTime keyDate = Convert.ToDateTime((dgv_bindingSource.Current as DataRowView)[dc.ColumnName].ToString());
                    if (keyDate <= new DateTime(1753, 1, 1))
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(dgv.Columns[e.ColumnIndex].DataPropertyName, "日期範圍只接受1753/01/01至9999/12/31.");
                }
            }

            dgv.EndEdit();

            if (dgv.CurrentCell == null) return;

            //教育程度
            if (dgv.Name == "dataGridViewSCHL")
            {
                string DataPropertyName = dgv.Columns[e.ColumnIndex].DataPropertyName;
                if (DataPropertyName.Trim() == "EDUCCODE")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.EducCodeReqErr);
                    }
                }
                if (DataPropertyName.Trim() == "SCHL1")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.SCHLReqErr);
                    }
                }
            }

            //經歷
            if (dgv.Name == "dataGridViewWork")
            {
                string DataPropertyName = dgv.Columns[e.ColumnIndex].DataPropertyName;
                if (DataPropertyName.Trim() == "COMPANY")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.COMPANYReqErr);
                    }
                }
                if (DataPropertyName.Trim() == "TITLE")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.TITLEReqErr);
                    }
                }
            }

            //專長與興趣
            if (dgv.Name == "dataGridViewMaster")
            {
                string DataPropertyName = dgv.Columns[e.ColumnIndex].DataPropertyName;
                if (DataPropertyName.Trim() == "MASTER1")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.MasterReqErr);
                    }
                }
            }

            //眷屬資料
            if (dgv.Name == "dataGridViewFamily")
            {
                string DataPropertyName = dgv.Columns[e.ColumnIndex].DataPropertyName;
                if (DataPropertyName.Trim() == "FA_IDNO")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value == null)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.IDNORequiredErr);
                    }
                    else
                    {


                        if (!(IDChk(cell_value) || JBTools.FormatValidate.CheckRPNumber(cell_value)))
                        {
                            (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.IDNOErr);
                        }
                        else
                        {
                            if ((dgv_bindingSource.Current as DataRowView).IsNew)
                            {
                                FRM12DataClassesDataContext db = new FRM12DataClassesDataContext();
                                var chkfamily = from c in db.FAMILY
                                                where c.FA_IDNO == cell_value && c.NOBR == textBoxNOBR.Text
                                                select c;
                                if (chkfamily != null && chkfamily.Count() > 0)
                                {
                                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.FA_IDNO_RPT_Err);
                                }
                            }
                        }
                        //if (cell_value.Length >= 2)
                        //{
                        //    string c1 = cell_value[0].ToString().ToUpper();
                        //    string c2 = cell_value[1].ToString().ToUpper();

                        //    if (c1.CompareTo("A") >= 0 && c1.CompareTo("Z") <= 0)
                        //    {
                        //        if (c2.CompareTo("1") >= 0 && c2.CompareTo("2") <= 0)
                        //        {
                        //            if (!IDChk(cell_value))
                        //            {
                        //                (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.IDNOErr);
                        //            }
                        //            else
                        //            {
                        //                if ((dgv_bindingSource.Current as DataRowView).IsNew)
                        //                {
                        //                    FRM12DataClassesDataContext db = new FRM12DataClassesDataContext();
                        //                    var chkfamily = from c in db.FAMILY
                        //                                    where c.FA_IDNO == cell_value && c.NOBR == textBoxNOBR.Text
                        //                                    select c;
                        //                    if (chkfamily != null && chkfamily.Count() > 0)
                        //                    {
                        //                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.FA_IDNO_RPT_Err);
                        //                    }
                        //                }
                        //            }
                        //        }
                        //        else if (c2.CompareTo("3") >= 0 && c2.CompareTo("9") <= 0)
                        //        {
                        //            (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.IDNOErr);
                        //        }
                        //        else if (!(c2.CompareTo("A") >= 0 && c2.CompareTo("Z") <= 0))
                        //        {
                        //            (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.IDNOErr);
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.IDNOErr);
                        //}
                    }
                }
                if (DataPropertyName.Trim() == "FA_NAME")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.FA_NameReqErr);
                    }
                }
                if (DataPropertyName.Trim() == "REL_CODE")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.REL_CODEReqErr);
                    }
                }
                if (DataPropertyName.Trim() == "FA_BIRDT")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.FA_BIRDTReqErr);
                    }
                }
            }

            //費用分攤
            if (dgv.Name == "dataGridViewCost")
            {
                string DataPropertyName = dgv.Columns[e.ColumnIndex].DataPropertyName;
                if (DataPropertyName.Trim() == "DEPTS")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.DEPTSReqErr);
                    }
                }
                if (DataPropertyName.Trim() == "RATE")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.RATEReqErr);
                    }
                    else
                    {
                        if (Convert.ToDecimal(cell_value) > 100)
                        {
                            (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.CostRateMaxLimitErr);
                        }
                    }
                }
                if (DataPropertyName.Trim() == "CADATE")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.CADATEReqErr);
                    }
                }
                if (DataPropertyName.Trim() == "CDDATE")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.CDDATEReqErr);
                    }
                }
            }

            //證照
            if (dgv.Name == "dataGridViewLican")
            {
                string DataPropertyName = dgv.Columns[e.ColumnIndex].DataPropertyName;
                if (DataPropertyName.Trim() == "COMP")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.COMPReqErr);
                    }
                }
                if (DataPropertyName.Trim() == "DESCS")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.DESCSReqErr);
                    }
                }
                if (DataPropertyName.Trim() == "MDATE")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.MDATEReqErr);
                    }
                }
                if (DataPropertyName.Trim() == "EDATE")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.EDATEReqErr);
                    }
                }
                if (DataPropertyName.Trim() == "LIC_NO")
                {
                    (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

                    string cell_value = Convert.ToString(dgv.CurrentCell.Value);
                    if (cell_value.Trim().Length == 0)
                    {
                        (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.LIC_NOReqErr);
                    }
                }
            }
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            BindingSource bindingSource = (sender as JBControls.DataGridView).DataSource as BindingSource;

            (bindingSource.Current as DataRowView)["NOBR"] = textBoxNOBR.Text;
            (bindingSource.Current as DataRowView)["KEY_DATE"] = DateTime.Now;
            (bindingSource.Current as DataRowView)["KEY_MAN"] = MainForm.USER_NAME;

            DataRow curr_row = (bindingSource.Current as DataRowView).Row;
            foreach (DataColumn dc in curr_row.Table.Columns)
            {
                if (curr_row.IsNull(dc))
                {
                    Type t = dc.DataType;
                    if (t == typeof(string)) (bindingSource.Current as DataRowView)[dc.ColumnName] = "";
                    if (t == typeof(bool)) (bindingSource.Current as DataRowView)[dc.ColumnName] = false;
                    if (t == typeof(int)) (bindingSource.Current as DataRowView)[dc.ColumnName] = 0;
                    if (t == typeof(decimal) || t == typeof(double)) (bindingSource.Current as DataRowView)[dc.ColumnName] = 0.00;
                    if (t == typeof(DateTime) && !dc.AllowDBNull) (bindingSource.Current as DataRowView)[dc.ColumnName] = DateTime.Now.Date;
                }
            }

            bindingSource.EndEdit();
        }
        private void dataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            JBControls.DataGridView dgv = sender as JBControls.DataGridView;
            BindingSource dgv_bindingSource = dgv.DataSource as BindingSource;
            foreach (DataColumn dc in (dgv_bindingSource.Current as DataRowView).Row.Table.Columns)
                (dgv_bindingSource.Current as DataRowView).Row.SetColumnError(dc.ColumnName, "");
        }
        private void bnSave_Click(object sender, EventArgs e)
        {
            EditType = fullDataCtrl1.EditType;
            if (!MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(comboBoxSALADR.SelectedValue))
            {
                MessageBox.Show("你沒有修改該員工資料的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Modify && !Sal.Function.CanModify(textBoxNOBR.Text))
            //{
            //    MessageBox.Show("你沒有修改該員工資料的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (BASEbindingSource.Current != null && !checkBoxCOUNT_MA.Checked)//本國人才要判斷
            {
                (BASEbindingSource.Current as DataRowView).Row.SetColumnError("IDNO", "");
                if (textBoxIDNO.Text.Trim().Length > 0)
                {
                    if (IsIdCheck && !(IDChk(textBoxIDNO.Text.Trim()) || JBTools.FormatValidate.CheckRPNumber(textBoxIDNO.Text.Trim())))
                    {
                        if (MessageBox.Show(Resources.Bas.IDNOErr, Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                        {
                            textBoxIDNO.Focus();
                            (BASEbindingSource.Current as DataRowView).Row.SetColumnError("IDNO", Resources.Bas.IDNOErr);
                            return;
                        }
                        else IsIdCheck = false;
                    }
                }
            }
            if (this.basDS.SCHL.GetErrors().Length > 0)
            {
                tabControl1.SelectedTab = tabPage2;
                MessageBox.Show(Resources.Bas.SCHLErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.basDS.WORKS.GetErrors().Length > 0)
            {
                tabControl1.SelectedTab = tabPage3;
                MessageBox.Show(Resources.Bas.WORKSErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.basDS.MASTER.GetErrors().Length > 0)
            {
                tabControl1.SelectedTab = tabPage4;
                MessageBox.Show(Resources.Bas.MASTERErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.basDS.FAMILY.GetErrors().Length > 0)
            {
                tabControl1.SelectedTab = tabPage5;
                MessageBox.Show(Resources.Bas.FamilyErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.basDS.COST.GetErrors().Length > 0)
            {
                tabControl1.SelectedTab = tabPage8;
                MessageBox.Show(Resources.Bas.COSTErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.basDS.LICAN.GetErrors().Length > 0)
            {
                tabControl1.SelectedTab = tabPage9;
                MessageBox.Show(Resources.Bas.LICANErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #region 儲存員工自定欄位值
            SystemFunction.UserDefineLayoutSaveValue(controlList, textBoxNOBR.Text);
            #endregion

            fullDataCtrl1.bnSave_Click(sender, e);

            if (textBoxUpName1.Text.Trim().Length > 0) bnOp1.Enabled = true;
            else bnOp1.Enabled = false;
            if (textBoxUpName2.Text.Trim().Length > 0) bnOp2.Enabled = true;
            else bnOp2.Enabled = false;
            if (textBoxUpName3.Text.Trim().Length > 0) bnOp3.Enabled = true;
            else bnOp3.Enabled = false;
            if (textBoxUpName4.Text.Trim().Length > 0) bnOp4.Enabled = true;
            else bnOp4.Enabled = false;
            if (textBoxUpName5.Text.Trim().Length > 0) bnOp5.Enabled = true;
            else bnOp5.Enabled = false;

            CheckRule();
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
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
            if (textBoxNOBR.Text.Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.RequiredField, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNOBR.Focus();
                e.Cancel = true;
                return;
            }
            if (textBoxNAME_C.Text.Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.RequiredField, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNAME_C.Focus();
                e.Cancel = true;
                return;
            }
            //if (textBoxNAME_E.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(Resources.All.RequiredField, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    textBoxNAME_E.Focus();
            //    e.Cancel = true;
            //    return;
            //}
            if (!textBoxBIRDT.HasTextInput())
            {
                MessageBox.Show(Resources.All.RequiredField, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxBIRDT.Focus();
                e.Cancel = true;
                return;
            } 
            else
            {
                DateTime BirDTMin = new DateTime(1900, 1, 1);
                DateTime BirDTMax = new DateTime(2079, 6, 6);
                DateTime BirDT = Convert.ToDateTime(textBoxBIRDT.Text);
                if (BirDT < BirDTMin || BirDT >BirDTMax)
                {
                    MessageBox.Show("生日可輸入範圍為1900-01-01至2079-06-06", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxBIRDT.Focus();
                    e.Cancel = true;
                    return;
                }
            }
            if (cbSex.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbSex.Focus();
                e.Cancel = true;
                return;
            }
            //if (cbMARRY.SelectedValue.ToString().Trim().Length == 0)
            //{
            //    MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cbMARRY.Focus();
            //    e.Cancel = true;
            //    return;
            //}
            if (textBoxPASSWORD.Text.Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.RequiredField, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxPASSWORD.Focus();
                e.Cancel = true;
                return;
            }
            if (!textBoxADATE.HasTextInput())
            {
                MessageBox.Show(Resources.All.RequiredField, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                textBoxADATE.Focus();
                e.Cancel = true;
                return;
            }
            if (cbCOMP.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbCOMP.Focus();
                e.Cancel = true;
                return;
            }
            if (cbDEPT.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbDEPT.Focus();
                e.Cancel = true;
                return;
            }
            if (cbDEPTS.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbDEPTS.Focus();
                e.Cancel = true;
                return;
            }
            if (cbDEPTA.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbDEPTA.Focus();
                e.Cancel = true;
                return;
            }
            if (cbJOB.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbJOB.Focus();
                e.Cancel = true;
                return;
            }
            if (cbJOBS.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbJOBS.Focus();
                e.Cancel = true;
                return;
            }
            if (cbJOBL.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbJOBL.Focus();
                e.Cancel = true;
                return;
            }
            if (cbDI.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbDI.Focus();
                e.Cancel = true;
                return;
            }
            if (cbEMPCD.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbEMPCD.Focus();
                e.Cancel = true;
                return;
            }
            if (cbROTET.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbROTET.Focus();
                e.Cancel = true;
                return;
            }
            if (cbHOLICD.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbHOLICD.Focus();
                e.Cancel = true;
                return;
            }
            if (cbWORKCD.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbWORKCD.Focus();
                e.Cancel = true;
                return;
            }
            if (cbTTSCD.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage1;
                cbTTSCD.Focus();
                e.Cancel = true;
                return;
            }
            if (comboBoxSALTP.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage10;
                comboBoxSALTP.Focus();
                e.Cancel = true;
                return;
            }
            if (comboBoxCALOT.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage10;
                comboBoxCALOT.Focus();
                e.Cancel = true;

                return;
            }
            if (comboBoxSALADR.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage10;
                comboBoxSALADR.Focus();
                e.Cancel = true;
                return;
            }
            if (comboBoxRETCHOO.SelectedValue.ToString().Trim().Length == 0)
            {
                MessageBox.Show(Resources.All.NoSelected, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedTab = tabPage10;
                comboBoxRETCHOO.Focus();
                e.Cancel = true;
                return;
            }

            if (!e.Cancel)
            {
                bnSave.Enabled = false;
                bnCancel.Enabled = false;

                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
                {
                    FRM12DataClassesDataContext FRM12Context = new FRM12DataClassesDataContext();
                    //if (checkBoxCOUNT_MA.Checked)
                    //{
                    //    string maxNobr1 = (from c in FRM12Context.BASE
                    //                       where c.NOBR.Contains("F")
                    //                       select c).Max(r => r.NOBR.Substring(2, 4));
                    //    textBoxNOBR.Text = "F" + DateTime.Now.Year.ToString().Substring(3, 1) + Convert.ToString(Convert.ToInt32(maxNobr1) + 1).PadLeft(4, '0');
                    //}
                    //else
                    //{
                    //    string maxNobr1 = (from c in FRM12Context.BASE
                    //                       where !c.NOBR.Contains("F")
                    //                       select c).Max(r => r.NOBR.Substring(1, 4));
                    //    string maxNobr2 = (from c in FRM12Context.BASE
                    //                       where c.NOBR.Contains(maxNobr1)
                    //                       select c).FirstOrDefault().NOBR.Substring(5, 1);

                    //    string serial = "0135792468";
                    //    string endNo = "";
                    //    if (maxNobr2 == "8") endNo = "0";
                    //    else endNo = serial.Substring(serial.IndexOf(maxNobr2) + 1, 1);

                    //    textBoxNOBR.Text = DateTime.Now.Year.ToString().Substring(3, 1) + Convert.ToString(Convert.ToInt32(maxNobr1) + 1).PadLeft(4, '0') + endNo;
                    //textBoxNOBR.Text = FRM12Context.GetNewNobr(checkBoxCOUNT_MA.Checked);
                }
            }

            e.Values["NOBR"] = textBoxNOBR.Text;
            e.Values["NAME_C"] = textBoxNAME_C.Text;
            e.Values["NAME_E"] = textBoxNAME_E.Text;
            e.Values["NAME_P"] = textBoxNAME_P.Text;
            e.Values["IDNO"] = textBoxIDNO.Text;
            if (textBoxBIRDT.HasTextInput()) e.Values["BIRDT"] = Convert.ToDateTime(textBoxBIRDT.Text);
            //e.Values["BORN_ADDR"] = textBoxBORN_ADDR.Text;
            e.Values["SEX"] = cbSex.SelectedValue;
            e.Values["BLOOD"] = cbBLOOD.SelectedValue;
            e.Values["MARRY"] = cbMARRY.SelectedValue;
            e.Values["PROVINCE"] = cbPROVCD.SelectedValue;
            e.Values["ARMY"] = cbARMY.SelectedValue;
            //e.Values["ARMY_TYPE"] = textBoxARMY_TYPE.Text;
            e.Values["COUNTRY"] = cbCOUNTCD.SelectedValue;
            e.Values["TAXNO"] = textBoxTAXNO.Text;
            e.Values["MATNO"] = textBoxMATNO.Text;
            e.Values["COUNT_MA"] = checkBoxCOUNT_MA.Checked;
            e.Values["SUBTEL"] = textBoxSUBTEL.Text;
            e.Values["GSM"] = textBoxGSM.Text;
            e.Values["EMAIL"] = textBoxEMAIL.Text;
            e.Values["TEL1"] = textBoxTEL1.Text;
            e.Values["POSTCODE1"] = textBoxPOSTCODE1.Text;
            e.Values["ADDR1"] = textBoxADDR1.Text;
            e.Values["TEL2"] = textBoxTEL2.Text;
            e.Values["POSTCODE2"] = textBoxPOSTCODE2.Text;
            e.Values["ADDR2"] = textBoxADDR2.Text;
            e.Values["PRO_MAN1"] = textBoxPRO_MAN1.Text;
            e.Values["PRO_ID1"] = textBoxPRO_ID1.Text;
            e.Values["PRO_TEL1"] = textBoxPRO_TEL1.Text;
            e.Values["PRO_ADDR1"] = textBoxPRO_ADDR1.Text;
            e.Values["PRO_MAN2"] = textBoxPRO_MAN2.Text;
            e.Values["PRO_ID2"] = textBoxPRO_ID2.Text;
            e.Values["PRO_TEL2"] = textBoxPRO_TEL2.Text;
            e.Values["PRO_ADDR2"] = textBoxPRO_ADDR2.Text;
            e.Values["CONT_MAN"] = textBoxCONT_MAN.Text;
            e.Values["CONT_REL1"] = comboBoxCONT_REL1.SelectedValue;
            e.Values["CONT_TEL"] = textBoxCONT_TEL.Text;
            e.Values["CONT_GSM"] = textBoxCONT_GSM.Text;
            e.Values["CONT_MAN2"] = textBoxCONT_MAN2.Text;
            e.Values["CONT_REL2"] = comboBoxCONT_REL2.SelectedValue;
            e.Values["CONT_TEL2"] = textBoxCONT_TEL2.Text;
            e.Values["CONT_GSM2"] = textBoxCONT_GSM2.Text;
            e.Values["BANKNO"] = cbxBanCode.SelectedValue;
            e.Values["ACCOUNT_NO"] = textBoxACCOUNT_NO.Text;
            e.Values["BANK_CODE"] = cbxBanCode_MA.SelectedValue;
            //e.Values["ACCOUNT_NA"] = textBoxACCOUNT_NA.Text;
            e.Values["ACCOUNT_MA"] = textBoxACCOUNT_MA.Text;
            e.Values["NAME_AD"] = textBoxNAME_AD.Text;
            e.Values["BASECD"] = cbBASECD.SelectedValue;
            if (textBoxTAXCNT.Text.Trim().Length > 0) e.Values["TAXCNT"] = Convert.ToDecimal(textBoxTAXCNT.Text);
            if (textBoxPRETAX.Text.Trim().Length > 0) e.Values["PRETAX"] = Convert.ToDecimal(textBoxPRETAX.Text);

            e.Values["PASSWORD"] = textBoxPASSWORD.Text;
            e.Values["KEY_DATE"] = DateTime.Now;
            e.Values["KEY_MAN"] = MainForm.USER_NAME;

            #region 禾申堂新增
            e.Values["CandidateWays"] = cbCANDIDATES_WAYS.SelectedValue;
            //e.Values["Gift"] = cbGiftVoucher.SelectedValue;
            //if (txtAdmitDate.HasTextInput()) e.Values["AdmitDate"] = Convert.ToDateTime(txtAdmitDate.Text);
            //if (txtAdditionDate.HasTextInput()) e.Values["AdditionDate"] = Convert.ToDateTime(txtAdditionDate.Text);
            e.Values["AdditionNO"] = txtAdditionNO.Text;
            e.Values["Introductor"] = ptxIntroductor.Text;
            e.Values["N_NOBR"] = comboBoxDisabilityType.SelectedValue;
            e.Values["NOBR_B"] = comboBoxDisabilityRank.SelectedValue;
            //e.Values["IntroductionBonus"] = chkIntroductionBonus.Checked;
            //e.Values["Aboriginal"] = chkAboriginal.Checked;
            //e.Values["Disability"] = chkDisability.Checked;
            #endregion

            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            Dictionary<string, string> row = new Dictionary<string, string>();
            foreach (DataColumn col in basDS.BASE.Columns)
                row.Add(col.ColumnName, e.Values[col.ColumnName].ToString());
            JBModule.Message.DbLog.WriteToDB("SaveBASE", JsonConvert.SerializeObject(row), "info", "FRM12", -1, MainForm.USER_ID, Guid.NewGuid().ToString());

            fullDataCtrl2.bnSave_Click(null, null);
            if (BASETTS_SAVE_ERROR)
            {
                e.Cancel = true;
                bnSave.Enabled = true;
                bnCancel.Enabled = true;
            }
        }


        private void fullDataCtrl2_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
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
                e.Values["NOBR"] = textBoxNOBR.Text;
                e.Values["TTSCODE"] = cbTTSCODE.SelectedValue;
                if (textBoxADATE.HasTextInput()) e.Values["ADATE"] = Convert.ToDateTime(textBoxADATE.Text);
                if (cbTTSCODE.SelectedValue.ToString() == "1") e.Values["INDT"] = e.Values["ADATE"];
                e.Values["CINDT"] = (textBoxCINDT.HasTextInput()) ? Convert.ToDateTime(textBoxCINDT.Text) : e.Values["INDT"];
                if (textBoxOUDT.HasTextInput()) e.Values["OUDT"] = Convert.ToDateTime(textBoxOUDT.Text);
                if (textBoxSTDT.HasTextInput()) e.Values["STDT"] = Convert.ToDateTime(textBoxSTDT.Text);
                if (textBoxSTINDT.HasTextInput()) e.Values["STINDT"] = Convert.ToDateTime(textBoxSTINDT.Text);
                if (textBoxSTOUDT.HasTextInput()) e.Values["STOUDT"] = Convert.ToDateTime(textBoxSTOUDT.Text);
                if (textBoxAP_DATE.HasTextInput()) 
                    e.Values["AP_DATE"] = Convert.ToDateTime(textBoxAP_DATE.Text);
                else
                    e.Values["AP_DATE"] = DBNull.Value;
                if (textBoxAuditDate.HasTextInput()) e.Values["AuditDate"] = Convert.ToDateTime(textBoxAuditDate.Text);
                e.Values["PASS_TYPE"] = comboBoxPassType.SelectedValue;
                if (txtReinstateDate.HasTextInput()) 
                    e.Values["ReinstateDate"] = Convert.ToDateTime(txtReinstateDate.Text);
                else
                    e.Values["ReinstateDate"] = DBNull.Value;
                e.Values["DDATE"] = Convert.ToDateTime("9999/12/31");
                e.Values["COMP"] = cbCOMP.SelectedValue;
                e.Values["DEPT"] = cbDEPT.SelectedValue;
                e.Values["DEPTS"] = cbDEPTS.SelectedValue;
                e.Values["DEPTM"] = cbDEPTA.SelectedValue;
                e.Values["JOB"] = cbJOB.SelectedValue;
                e.Values["JOBS"] = cbJOBS.SelectedValue;
                e.Values["JOBL"] = cbJOBL.SelectedValue;
                e.Values["JOBO"] = comboBoxJobo.SelectedValue;
                e.Values["DI"] = cbDI.SelectedValue;
                e.Values["EMPCD"] = cbEMPCD.SelectedValue;
                e.Values["CARD"] = cbxCard.SelectedValue;
                e.Values["ROTET"] = cbROTET.SelectedValue;
                e.Values["HOLI_CODE"] = cbHOLICD.SelectedValue;
                e.Values["WORKCD"] = cbWORKCD.SelectedValue;
                e.Values["TTSCD"] = cbTTSCD.SelectedValue;
                if (textBoxWK_YRS.Text.Trim().Length > 0) e.Values["WK_YRS"] = Convert.ToDecimal(textBoxWK_YRS.Text);
                if (textBoxTAX_DATE.HasTextInput()) 
                    e.Values["TAX_DATE"] = Convert.ToDateTime(textBoxTAX_DATE.Text);
                else
                    e.Values["TAX_DATE"] = DBNull.Value;
                if (textBoxTAX_EDATE.HasTextInput()) 
                    e.Values["TAX_EDATE"] = textBoxTAX_EDATE.Text;
                else
                    e.Values["TAX_EDATE"] = DBNull.Value;
                e.Values["SALTP"] = comboBoxSALTP.SelectedValue;
                e.Values["CALOT"] = comboBoxCALOT.SelectedValue;
                e.Values["SALADR"] = comboBoxSALADR.SelectedValue;
                //if (textBoxGRP_AMT.Text.Trim().Length > 0) e.Values["GRP_AMT"] = Convert.ToDecimal(textBoxGRP_AMT.Text);
                //if (textBoxPASS_DATE.HasTextInput()) e.Values["PASS_DATE"] = Convert.ToDateTime(textBoxPASS_DATE.Text);
                e.Values["RETCHOO"] = comboBoxRETCHOO.SelectedValue;
                if (textBoxRETDATE.HasTextInput())
                    e.Values["RETDATE"] = Convert.ToDateTime(textBoxRETDATE.Text);
                else
                    e.Values["RETDATE"] = DBNull.Value;
                if (textBoxRETDATE1.HasTextInput()) 
                    e.Values["RETDATE1"] = Convert.ToDateTime(textBoxRETDATE1.Text);
                else
                    e.Values["RETDATE1"] = DBNull.Value;
                if (textBoxRETRATE.Text.Trim().Length > 0) e.Values["RETRATE"] = Convert.ToDecimal(textBoxRETRATE.Text);
                e.Values["MENO"] = textBoxMENO.Text;
                //e.Values["INSG_TYPE"] = comboBoxINSG_TYPE.SelectedValue;

                e.Values["COUNT_PASS"] = checkBoxCOUNT_PASS.Checked;
                e.Values["FIXRATE"] = checkBoxFIXRATE.Checked;
                e.Values["MANG1"] = checkBoxMANG1.Checked;
                e.Values["ONLYONTIME"] = checkBoxONLYONTIME.Checked;
                e.Values["NOEAT"] = checkBoxNOEAT.Checked;
                e.Values["NOTLATE"] = checkBoxNOTLATE.Checked;
                e.Values["MANG"] = checkBoxMANG.Checked;
                e.Values["MANGE"] = checkBoxMANGE.Checked;
                e.Values["NOWAGE"] = checkBoxNOWAGE.Checked;
                e.Values["NOOT"] = checkBoxNOOT.Checked;
                e.Values["NOTER"] = checkBoxNOTER.Checked;
                e.Values["FULATT"] = checkBoxFULATT.Checked;
                e.Values["CALABS"] = checkBoxCALABS.Checked;
                e.Values["NOWEL"] = checkBoxNOWEL.Checked;
                e.Values["NORET"] = checkBoxNORET.Checked;
                e.Values["NOOLDRET"] = checkBoxNOOLDRET.Checked;
                e.Values["NOCARD"] = checkBoxNOCARD.Checked;
                e.Values["NOSPEC"] = checkBoxNOSPEC.Checked;
                e.Values["NOSPAMT"] = checkBoxNOSPAMT.Checked;

                e.Values["KEY_DATE"] = DateTime.Now;
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["IS_SELFOUT"] = false;

                #region 禾申堂新增
                e.Values["CardJobName"] = txtCardJobName.Text;
                e.Values["CardJobEnName"] = txtCardJobEnName.Text;
                e.Values["OilSubsidy"] = comboBoxCostType.SelectedValue;
                e.Values["INSG_TYPE"] = comboBoxBonusGroup.SelectedValue;
                e.Values["OldSaladr"] = comboBoxERP.SelectedValue;
                e.Values["CardID"] = txtCardID.Text;
                e.Values["DoorGuard"] = cbDoorGuard.SelectedValue;
                e.Values["OutPost"] = cbOutPost.SelectedValue;
                e.Values["Station"] = comboBoxLesson.SelectedValue;
                e.Values["APGRPCD"] = comboBoxGroup.SelectedValue;
                e.Values["CARCD"] = comboBoxResponsibility.SelectedValue == null? "":comboBoxResponsibility.SelectedValue;
                #endregion

                Dictionary<string, string> row = new Dictionary<string, string>();
                foreach (DataColumn col in basDS.BASETTS.Columns)
                    row.Add(col.ColumnName, e.Values[col.ColumnName].ToString());
                JBModule.Message.DbLog.WriteToDB("SaveBASETTS", JsonConvert.SerializeObject(row), "info", "FRM12", -1, MainForm.USER_ID, Guid.NewGuid().ToString());
            }
        }

        private void fullDataCtrl2_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (e.Error)
            {
                BASETTS_SAVE_ERROR = true;
            }
            else
            {
                BASETTS_SAVE_ERROR = false;

                FRM12DataClassesDataContext db = new FRM12DataClassesDataContext();
                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
                {
                    var schlData = from c in db.SCHL where c.NOBR.Trim().ToLower() == e.Values["nobr"].ToString().Trim().ToLower() select c;
                    foreach (var schlRow in schlData) db.SCHL.DeleteOnSubmit(schlRow);

                    var worksData = from c in db.WORKS where c.NOBR.Trim().ToLower() == e.Values["nobr"].ToString().Trim().ToLower() select c;
                    foreach (var worksRow in worksData) db.WORKS.DeleteOnSubmit(worksRow);

                    var masterData = from c in db.MASTER where c.NOBR.Trim().ToLower() == e.Values["nobr"].ToString().Trim().ToLower() select c;
                    foreach (var masterRow in masterData) db.MASTER.DeleteOnSubmit(masterRow);

                    var familyData = from c in db.FAMILY where c.NOBR.Trim().ToLower() == e.Values["nobr"].ToString().Trim().ToLower() select c;
                    foreach (var familyRow in familyData) db.FAMILY.DeleteOnSubmit(familyRow);

                    var costData = from c in db.COST where c.NOBR.Trim().ToLower() == e.Values["nobr"].ToString().Trim().ToLower() select c;
                    foreach (var costRow in costData) db.COST.DeleteOnSubmit(costRow);

                    var licanData = from c in db.LICAN where c.NOBR.Trim().ToLower() == e.Values["nobr"].ToString().Trim().ToLower() select c;
                    foreach (var licanRow in licanData) db.LICAN.DeleteOnSubmit(licanRow);

                    db.SubmitChanges();
                    BasDSTableAdapters.PAY_DOCTableAdapter paydocAD = new BasDSTableAdapters.PAY_DOCTableAdapter();
                    paydocAD.Update(basDS.PAY_DOC);
                }
                var UserDefine = (from c in db.UserDefine where c.NOBR.Trim().ToLower() == e.Values["nobr"].ToString().Trim().ToLower() select c).FirstOrDefault(); //取
                //  foreach (var userData in UserDefine)
                if (UserDefine != null)
                {
                    db.UserDefine.DeleteOnSubmit(UserDefine);
                    db.SubmitChanges();
                }
                JBModule.Data.Linq.UserDefine _udefine = new JBModule.Data.Linq.UserDefine();
                JBModule.Data.Linq.HrDBDataContext db1 = new JBModule.Data.Linq.HrDBDataContext();
                var Textresult = UDLayout.Controls.OfType<JBControls.TextBox>().ToList();//Tabpage底下包tablelayoutpanel會抓不到tablealayoutpanel的子控制項
                Type type = _udefine.GetType();
                CodeFunction.SetDefaultValue(_udefine);  //預設值
                if (UserDefine != null)
                {
                    PropertyInfo[] _propertyinfo = UserDefine.GetType().GetProperties();
                    foreach (PropertyInfo Property in _propertyinfo)
                    {
                        var value = UserDefine.GetType().GetProperty(Property.Name).GetValue(UserDefine, null);
                        if (_udefine.GetType().GetProperty(Property.Name) != null)
                            _udefine.GetType().GetProperty(Property.Name).SetValue(_udefine, value, null);
                    }
                }
                foreach (JBControls.TextBox _txt in Textresult)
                {
                    PropertyInfo propertyInfo = type.GetProperty(_txt.CaptionLabel.Name.ToUpper());
                    if (_txt.Visible && !string.IsNullOrWhiteSpace(_txt.Text))
                    {
                        if (_txt.ValidType == JBControls.TextBox.EValidType.Date)
                            propertyInfo.SetValue(_udefine, Convert.ToDateTime(_txt.Text), null);
                        if (_txt.ValidType == JBControls.TextBox.EValidType.Decimal)
                            propertyInfo.SetValue(_udefine, Convert.ToDecimal(_txt.Text), null);
                        if (_txt.ValidType == JBControls.TextBox.EValidType.String)
                            propertyInfo.SetValue(_udefine, _txt.Text, null);

                    }
                }
                _udefine.NOBR = textBoxNOBR.Text;
                _udefine.KEY_DATE = DateTime.Now;
                _udefine.KEY_MAN = MainForm.USER_NAME;
                db1.UserDefine.InsertOnSubmit(_udefine);
                db1.SubmitChanges();
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                foreach (DataRow row in basDS.SCHL)
                {
                    if (row.RowState == DataRowState.Added) row["nobr"] = e.Values["nobr"];
                }
                foreach (DataRow row in basDS.WORKS)
                {
                    if (row.RowState == DataRowState.Added) row["nobr"] = e.Values["nobr"];
                }
                foreach (DataRow row in basDS.MASTER)
                {
                    if (row.RowState == DataRowState.Added) row["nobr"] = e.Values["nobr"];
                }
                foreach (DataRow row in basDS.FAMILY)
                {
                    if (row.RowState == DataRowState.Added) row["nobr"] = e.Values["nobr"];
                }
                foreach (DataRow row in basDS.COST)
                {
                    if (row.RowState == DataRowState.Added) row["nobr"] = e.Values["nobr"];
                }
                foreach (DataRow row in basDS.LICAN)
                {
                    if (row.RowState == DataRowState.Added) row["nobr"] = e.Values["nobr"];
                }


                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl2.BackupDataTable);
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, basDS.SCHL);
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, basDS.WORKS);
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, basDS.MASTER);
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, basDS.FAMILY);
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, basDS.COST);
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, basDS.LICAN);
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, basDS.UserDefine);

                try
                {
                    SCHLTableAdapter.Update(basDS.SCHL);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    WORKSTableAdapter.Update(basDS.WORKS);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    MASTERTableAdapter.Update(basDS.MASTER);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    FAMILYTableAdapter.Update(basDS.FAMILY);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    COSTTableAdapter.Update(basDS.COST);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                try
                {
                    LICANTableAdapter.Update(basDS.LICAN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                try
                {
                    userDefineTableAdapter.Update(basDS.UserDefine);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                BasDSTableAdapters.PAY_DOCTableAdapter paydocAD = new BasDSTableAdapters.PAY_DOCTableAdapter();
                paydocAD.Update(basDS.PAY_DOC);
                //BASETTSTableAdapter.FillByNOBR(basDS1.BASETTS, textBoxNOBR.Text);

                formMode = FormMode.View;
                InitCtrls();

                SetControls(false);
                SetCauseValid(false);

                Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);//更新工號清單

                double totalDays = basDS1.BASETTS.Sum(
                       ROW =>
                       {
                           //需求修改(Lanayeh)人事模組-集團到職日與在職年資 by 建華 2012/11/16
                           //需求修改(Lanayeh)人事模組-在職年資修改為以公司到職日為計算基準 edit by serlina 2012/11/30
                           if (new string[] { "1", "4", "6" }.Contains(ROW.TTSCODE))
                           {
                               if (ROW.DDATE < ROW.INDT)
                               {
                                   return 0;
                               }
                               else if (ROW.TTSCODE == "1")
                               {
                                   if (ROW.DDATE < ROW.INDT)
                                   {
                                       return 0;
                                   }
                                   else
                                   {
                                       if (ROW.ADATE > DateTime.Now)
                                       {
                                           return 0;
                                       }
                                       else if (ROW.DDATE >= DateTime.Now && ROW.ADATE < DateTime.Now)
                                       {
                                           return (DateTime.Now.Date - ROW.INDT).TotalDays + 1;
                                       }
                                       else
                                       {
                                           return (ROW.DDATE - ROW.INDT).TotalDays + 1;
                                       }
                                   }
                               }
                               else if (ROW.ADATE <= ROW.INDT && ROW.DDATE >= ROW.INDT)
                               {
                                   if (ROW.ADATE > DateTime.Now)
                                   {
                                       return 0;
                                   }
                                   else if (ROW.DDATE >= DateTime.Now && ROW.INDT <= DateTime.Now)
                                   {
                                       return (DateTime.Now.Date - ROW.INDT).TotalDays + 1;
                                   }
                                   else
                                   {
                                       return (ROW.DDATE - ROW.INDT).TotalDays + 1;
                                   }
                               }
                               else
                               {
                                   if (ROW.DDATE >= DateTime.Now && ROW.ADATE <= DateTime.Now)
                                   {
                                       return (DateTime.Now.Date - ROW.ADATE).TotalDays + 1;
                                   }
                                   else if (ROW.ADATE > DateTime.Now)
                                   {
                                       return 0;
                                   }
                                   else
                                   {
                                       return (ROW.DDATE - ROW.ADATE).TotalDays + 1;
                                   }
                               }
                           }
                           else return 0;
                       }
               );

                textBoxINYEAR.Text = Convert.ToDecimal(Math.Round(totalDays / 365.25, 2)).ToYearMonthString();

                double total_reday = basDS1.BASETTS.Sum(
                    ROW =>
                    {
                        if (new string[] { "3" }.Contains(ROW.TTSCODE))
                        {
                            if (ROW.DDATE > DateTime.Now)
                            {
                                return (DateTime.Now.Date - ROW.ADATE).TotalDays + 1;
                            }
                            else return (ROW.DDATE - ROW.ADATE).TotalDays + 1;
                        }
                        else return 0;
                    }
                );

                textBoxRE_DAY.Text = Math.Round(total_reday, 0).ToString();
                textBoxRE_INDT.Text = basDS.BASETTS[0].CINDT.AddDays(Math.Round(total_reday, 0)).ToString();
            }
            else
            {
                bnSave.Enabled = true;
                bnCancel.Enabled = true;
            }
            #region 產生特休假彈休假
            if (EditType == JBControls.FullDataCtrl.EEditType.Add && (cbTTSCODE.SelectedValue.ToString() == "1"))//新增時自動加入彈休假
            {
                AutoABSPlus();
            }
            #endregion

            #region 自動加保提示
            if (EditType == JBControls.FullDataCtrl.EEditType.Add && (cbTTSCODE.SelectedValue.ToString() == "1"))//新增時自動加保提示
            {
                AutoInsAlert();
            }
            #endregion
            EditType = fullDataCtrl1.EditType;
            SetCode(JBControls.FullDataCtrl.EEditType.None);

        }

        private void AutoInsAlert()
        {
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM12", MainForm.COMPANY);
            bool AutoIns = Convert.ToBoolean(AppConfig.GetConfig("AutoIns").Value.Trim());
            if (AutoIns && MessageBox.Show("是否產生員工及眷屬的勞健保投保資料？", "訊息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Ins.FRM32 frm32 = new Ins.FRM32(textBoxNOBR.Text, "", Convert.ToDateTime(textBoxADATE.Text), true);
                frm32.ShowDialog();
            }
        }

        private void AutoABSPlus()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sqlHtype = from a in db.HcodeType
                           where a.AutoCreateHours
                           && db.GetCodeFilter("HcodeType", a.HTYPE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                           //&&  !HtypeList.Contains(a.HTYPE)
                           select a.HTYPE;//排除特休彈休(特殊算法)

            string nobr = textBoxNOBR.Text;
            DateTime indt = Convert.ToDateTime(textBoxADATE.Text);
            Att.FRM2TG.GenerateAbsEntitle(new List<string> { nobr }, indt, new DateTime(indt.Year, 12, 31), sqlHtype.ToList());
            //JBHR.Att.FRM2I.CreateNewHireYearHoloiday(nobr, indt.Year, new DateTime(indt.Year, 12, 31), indt.AddMonths(6), true);
            JBHR.Att.FRM2I.CreateNewHireYearHoloiday(nobr, indt.Year, indt, indt, true);
            //JBHR.Att.FRM2P pp = new Att.FRM2P();
            //pp.CreateOptionalHoloiday(nobr, indt.Year, new DateTime(indt.Year, 12, 31), indt, true);
            MessageBox.Show("得假資料已自動產生。");
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            //BASETTSTableAdapter.DeleteQueryByNOBR(textBoxNOBR.Text);

            //foreach (var row in basDS.SCHL) row.Delete();
            //SCHLTableAdapter.Update(basDS.SCHL);

            //foreach (var row in basDS.WORKS) row.Delete();
            //WORKSTableAdapter.Update(basDS.WORKS);

            //foreach (var row in basDS.MASTER) row.Delete();
            //MASTERTableAdapter.Update(basDS.MASTER);

            //foreach (var row in basDS.FAMILY) row.Delete();
            //FAMILYTableAdapter.Update(basDS.FAMILY);

            //foreach (var row in basDS.COST) row.Delete();
            //COSTTableAdapter.Update(basDS.COST);

            //foreach (var row in basDS.LICAN) row.Delete();
            //LICANTableAdapter.Update(basDS.LICAN);

            //BasDS.BASERow BASERow = this.basDS1.BASE.FindByNOBR(textBoxNOBR.Text);
            //if (BASERow != null) this.basDS1.BASE.AcceptChanges();

            //basDS.BASETTS.Clear();
            //basDS1.BASETTS.Clear();
        }

        private void fullDataCtrl2_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            e.Values["TTSCODE"] = "1";
            e.Values["DDATE"] = "9999/12/31";
        }

        private void bnPic_Click(object sender, EventArgs e)
        {
            JpegOpenFileDialog.Filter = "Jpeg (*.jpg)|*.jpg";

            if (JpegOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = JpegOpenFileDialog.FileName;
                FileStream fs = new FileStream(filename, FileMode.Open);
                byte[] buffer = new byte[fs.Length]; // 用來儲存檔案的 byte 陣列，檔案有多大，陣列就有多大 
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                //mainDS.BASE[0].PHOTO = buffer;
                (BASEbindingSource.Current as DataRowView)["PHOTO"] = buffer;

                pictureBox1.Load(filename);
            }
        }

        private void bnClearPic_Click(object sender, EventArgs e)
        {
            //mainDS.BASE[0].PHOTO = null;
            (BASEbindingSource.Current as DataRowView)["PHOTO"] = null;
            pictureBox1.Image = null;
        }

        private void bnUp_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Any File (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fullfilename = openFileDialog.FileName;
                FileStream fs = new FileStream(fullfilename, FileMode.Open);
                byte[] buffer = new byte[fs.Length]; // 用來儲存檔案的 byte 陣列，檔案有多大，陣列就有多大 
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();

                string[] fileName = fullfilename.Split(new char[] { '\\' });

                switch ((sender as Control).Name)
                {
                    case "bnUp1":
                        (BASEbindingSource.Current as DataRowView)["up1_name"] = fileName[fileName.Length - 1];
                        (BASEbindingSource.Current as DataRowView)["up1_file"] = buffer;
                        textBoxUpName1.Text = (BASEbindingSource.Current as DataRowView)["up1_name"].ToString();
                        break;
                    case "bnUp2":
                        (BASEbindingSource.Current as DataRowView)["up2_name"] = fileName[fileName.Length - 1];
                        (BASEbindingSource.Current as DataRowView)["up2_file"] = buffer;
                        textBoxUpName2.Text = (BASEbindingSource.Current as DataRowView)["up2_name"].ToString();
                        break;
                    case "bnUp3":
                        (BASEbindingSource.Current as DataRowView)["up3_name"] = fileName[fileName.Length - 1];
                        (BASEbindingSource.Current as DataRowView)["up3_file"] = buffer;
                        textBoxUpName3.Text = (BASEbindingSource.Current as DataRowView)["up3_name"].ToString();
                        break;
                    case "bnUp4":
                        (BASEbindingSource.Current as DataRowView)["up4_name"] = fileName[fileName.Length - 1];
                        (BASEbindingSource.Current as DataRowView)["up4_file"] = buffer;
                        textBoxUpName4.Text = (BASEbindingSource.Current as DataRowView)["up4_name"].ToString();
                        break;
                    case "bnUp5":
                        (BASEbindingSource.Current as DataRowView)["up5_name"] = fileName[fileName.Length - 1];
                        (BASEbindingSource.Current as DataRowView)["up5_file"] = buffer;
                        textBoxUpName5.Text = (BASEbindingSource.Current as DataRowView)["up5_name"].ToString();
                        break;
                }
            }
        }

        private void bnCr_Click(object sender, EventArgs e)
        {
            switch ((sender as Control).Name)
            {
                case "bnCr1":
                    (BASEbindingSource.Current as DataRowView)["up1_name"] = "";
                    (BASEbindingSource.Current as DataRowView)["up1_file"] = null;
                    textBoxUpName1.Text = "";
                    bnOp1.Enabled = false;
                    break;
                case "bnCr2":
                    (BASEbindingSource.Current as DataRowView)["up2_name"] = "";
                    (BASEbindingSource.Current as DataRowView)["up2_file"] = null;
                    textBoxUpName2.Text = "";
                    bnOp2.Enabled = false;
                    break;
                case "bnCr3":
                    (BASEbindingSource.Current as DataRowView)["up3_name"] = "";
                    (BASEbindingSource.Current as DataRowView)["up3_file"] = null;
                    textBoxUpName3.Text = "";
                    bnOp3.Enabled = false;
                    break;
                case "bnCr4":
                    (BASEbindingSource.Current as DataRowView)["up4_name"] = "";
                    (BASEbindingSource.Current as DataRowView)["up4_file"] = null;
                    textBoxUpName4.Text = "";
                    bnOp4.Enabled = false;
                    break;
                case "bnCr5":
                    (BASEbindingSource.Current as DataRowView)["up5_name"] = "";
                    (BASEbindingSource.Current as DataRowView)["up5_file"] = null;
                    textBoxUpName5.Text = "";
                    bnOp5.Enabled = false;
                    break;
            }
            (sender as Control).Enabled = false;
        }

        private void bnOp_Click(object sender, EventArgs e)
        {
            string fileName = "";

            switch ((sender as Control).Name)
            {
                case "bnOp1":
                    fileName = (BASEbindingSource.Current as DataRowView)["up1_name"].ToString();
                    using (BinaryWriter binWriter =
                    new BinaryWriter(File.Open("C:\\TEMP\\" + fileName, FileMode.Create)))
                    {
                        binWriter.Write((byte[])(BASEbindingSource.Current as DataRowView)["up1_file"]);
                    }
                    break;
                case "bnOp2":
                    fileName = (BASEbindingSource.Current as DataRowView)["up2_name"].ToString();
                    using (BinaryWriter binWriter =
                    new BinaryWriter(File.Open("C:\\TEMP\\" + fileName, FileMode.Create)))
                    {
                        binWriter.Write((byte[])(BASEbindingSource.Current as DataRowView)["up2_file"]);
                    }
                    break;
                case "bnOp3":
                    fileName = (BASEbindingSource.Current as DataRowView)["up3_name"].ToString();
                    using (BinaryWriter binWriter =
                    new BinaryWriter(File.Open("C:\\TEMP\\" + fileName, FileMode.Create)))
                    {
                        binWriter.Write((byte[])(BASEbindingSource.Current as DataRowView)["up3_file"]);
                    }
                    break;
                case "bnOp4":
                    fileName = (BASEbindingSource.Current as DataRowView)["up4_name"].ToString();
                    using (BinaryWriter binWriter =
                    new BinaryWriter(File.Open("C:\\TEMP\\" + fileName, FileMode.Create)))
                    {
                        binWriter.Write((byte[])(BASEbindingSource.Current as DataRowView)["up4_file"]);
                    }
                    break;
                case "bnOp5":
                    fileName = (BASEbindingSource.Current as DataRowView)["up5_name"].ToString();
                    using (BinaryWriter binWriter =
                    new BinaryWriter(File.Open("C:\\TEMP\\" + fileName, FileMode.Create)))
                    {
                        binWriter.Write((byte[])(BASEbindingSource.Current as DataRowView)["up5_file"]);
                    }
                    break;
            }

            System.Diagnostics.Process.Start("C:\\TEMP\\" + fileName);
        }

        private void dataGridViewEx_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            e.ContextMenuStrip = contextMenuStrip1;
        }

        private void 刪除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.All.DeleteConfirm, Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if ((contextMenuStrip1.SourceControl as JBControls.DataGridView).CurrentRow != null &&
                    (contextMenuStrip1.SourceControl as JBControls.DataGridView).CurrentRow.DataBoundItem != null)
                {
                    ((contextMenuStrip1.SourceControl as JBControls.DataGridView).CurrentRow.DataBoundItem as DataRowView).Delete();
                }
            }
        }

        private void dataGridViewEx_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                (sender as JBControls.DataGridView).Rows[e.RowIndex].Selected = true;
            }
        }

        private void bnQuery_Click(object sender, EventArgs e)
        {
            textBoxNOBR.DataSource = vBASEBindingSource;
            bnAdd.Enabled = false;
            bnEdit.Enabled = false;
            bnDel.Enabled = false;
            bnCancel.Enabled = true;
            bnQuery.Enabled = false;
            clearShownData();

            textBoxNOBR.Enabled = true;
            textBoxNOBR.Text = "";
            textBoxNOBR.Focus();

            bnOp1.Enabled = false;
            bnOp2.Enabled = false;
            bnOp3.Enabled = false;
            bnOp4.Enabled = false;
            bnOp5.Enabled = false;
        }

        public static  bool IDChk(string vid)
        {
            try
            {
                List<string> FirstEng = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "W", "Z", "I", "O" };
                string aa = vid.ToUpper();
                bool chackFirstEnd = false;
                if (aa.Trim().Length == 10)
                {
                    byte firstNo = Convert.ToByte(aa.Trim().Substring(1, 1));
                    if (firstNo > 2 || firstNo < 1)
                    {
                        return false;
                    }
                    else
                    {
                        int x;
                        for (x = 0; x < FirstEng.Count; x++)
                        {
                            if (aa.Substring(0, 1) == FirstEng[x])
                            {
                                aa = string.Format("{0}{1}", x + 10, aa.Substring(1, 9));
                                chackFirstEnd = true;
                                break;
                            }

                        }
                        if (!chackFirstEnd)
                            return false;

                        int i = 1;
                        int ss = int.Parse(aa.Substring(0, 1));
                        while (aa.Length > i)
                        {
                            ss = ss + (int.Parse(aa.Substring(i, 1)) * (10 - i));
                            i++;
                        }
                        aa = ss.ToString();
                        if (vid.Substring(9, 1) == "0")
                        {
                            if (aa.Substring(aa.Length - 1, 1) == "0")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (vid.Substring(9, 1) == (10 - int.Parse(aa.Substring(aa.Length - 1, 1))).ToString())
                            {

                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void textBoxIDNO_Leave(object sender, EventArgs e)
        {
            if (BASEbindingSource.Current != null)
            {
                (BASEbindingSource.Current as DataRowView).Row.SetColumnError("IDNO", "");
                if (textBoxIDNO.Text.Trim().Length > 0)
                {
                    if (IsIdCheck && !(IDChk(textBoxIDNO.Text.Trim()) || JBTools.FormatValidate.CheckRPNumber(textBoxIDNO.Text.Trim())))
                    {
                        if (checkBoxCOUNT_MA.Checked && textBoxIDNO.Text.Trim().Length > 0)
                        {
                            if (IDNOCheck)
                                MessageBox.Show(new Form() { TopMost = true, TopLevel = true }, "外籍人士不使用身分證號，請改輸入到" + label16.Text + "欄位", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            IsIdCheck = false;
                        }
                        else if(MessageBox.Show("身分證驗證錯誤，確定=接續作業，取消=重新輸入.", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                        {
                            textBoxIDNO.Focus();
                            (BASEbindingSource.Current as DataRowView).Row.SetColumnError("IDNO", Resources.Bas.IDNOErr);
                            return;
                        }
                        else IsIdCheck = false;
                    }
                    else
                    {
                        HrDBDataContext db = new HrDBDataContext();
                        var person = db.HRBlackList.Where(p => p.IDNO == textBoxIDNO.Text.Trim()).FirstOrDefault();
                        if (person != null)
                        {
                            MessageBox.Show("屬於黑名單資料,此人不可任職.", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBoxIDNO.Focus();
                            return;
                        }
                    }
                    setPassword(sender, e);
                }
            }
        }
        private void setPassword(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add && fullDataCtrl1.ModeType == JBControls.FullDataCtrl.EModeType.Edit)
            {
                if (textBoxPASSWORD.Text.Length == 0)
                {
                    JBControls.TextBox ctrl = sender as JBControls.TextBox;
                    string DefaultPasswordMode = AppConfig.GetConfig("DefaultPasswordMode").GetString("No");
                    int DefaultPasswordBegin = Convert.ToInt32(AppConfig.GetConfig("DefaultPasswordBegin").GetInter(1));
                    int DefaultPasswordEnd = Convert.ToInt32(AppConfig.GetConfig("DefaultPasswordEnd").GetInter(4));
                    int lengh = DefaultPasswordEnd - DefaultPasswordBegin + 1;
                    string password = string.Empty;
                    switch (DefaultPasswordMode)
                    {
                        case "All":
                            if (ctrl.Text.Length > 0)
                                password = ctrl.Text;
                            break;
                        case "Left":
                            if (ctrl.Text.Length >= DefaultPasswordEnd)
                                password = ctrl.Text.Substring(DefaultPasswordBegin > 0 ? DefaultPasswordBegin - 1 : 0, lengh);
                            else if (ctrl.Text.Length > 0)
                                password = ctrl.Text;
                            break;
                        case "Right":
                            if (ctrl.Text.Length >= DefaultPasswordEnd)
                            {
                                int rightoffset = DefaultPasswordBegin > 0 ? DefaultPasswordBegin - 1 : 0;
                                int index = ctrl.Text.Length - rightoffset - lengh;
                                password = ctrl.Text.Substring(index, lengh);
                            }
                            else if (ctrl.Text.Length > 0)
                                password = ctrl.Text;
                            break;
                        default:
                            break;
                    }
                    textBoxPASSWORD.Text = password;
                }
            }
        }
        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                string Nobr = textBoxNOBR.Text;
                BASETTSTableAdapter.DeleteQueryByNOBR(textBoxNOBR.Text);

                foreach (var row in basDS.SCHL) row.Delete();
                SCHLTableAdapter.Update(basDS.SCHL);

                foreach (var row in basDS.WORKS) row.Delete();
                WORKSTableAdapter.Update(basDS.WORKS);

                foreach (var row in basDS.MASTER) row.Delete();
                MASTERTableAdapter.Update(basDS.MASTER);

                foreach (var row in basDS.FAMILY) row.Delete();
                FAMILYTableAdapter.Update(basDS.FAMILY);

                foreach (var row in basDS.COST) row.Delete();
                COSTTableAdapter.Update(basDS.COST);

                foreach (var row in basDS.LICAN) row.Delete();
                LICANTableAdapter.Update(basDS.LICAN);

                BasDS.BASERow BASERow = this.basDS1.BASE.FindByNOBR(textBoxNOBR.Text);
                if (BASERow != null) this.basDS1.BASE.AcceptChanges();

                basDS.BASETTS.Clear();
                basDS1.BASETTS.Clear();

                Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);

                HrDBDataContext db = new HrDBDataContext();
                var sqlUserDefine = db.UserDefine.Where(p => p.NOBR == Nobr);
                db.UserDefine.DeleteAllOnSubmit(sqlUserDefine);
                var sqlUserDefineValue = db.UserDefineValue.Where(p => p.Code == Nobr);
                db.UserDefineValue.DeleteAllOnSubmit(sqlUserDefineValue);
                db.SubmitChanges();
            }
        }

        private void textBoxPRO_ID1_Leave(object sender, EventArgs e)
        {
            if (BASEbindingSource.Current != null)
            {
                (BASEbindingSource.Current as DataRowView).Row.SetColumnError("PRO_ID1", "");
                if (textBoxPRO_ID1.Text.Trim().Length > 0)
                {
                    if (!(IDChk(textBoxPRO_ID1.Text.Trim()) || JBTools.FormatValidate.CheckRPNumber(textBoxPRO_ID1.Text.Trim())))
                    {
                        MessageBox.Show(Resources.Bas.IDNOErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxPRO_ID1.Focus();
                        (BASEbindingSource.Current as DataRowView).Row.SetColumnError("PRO_ID1", Resources.Bas.IDNOErr);
                    }
                }
            }
        }

        private void textBoxPRO_ID2_Leave(object sender, EventArgs e)
        {
            if (BASEbindingSource.Current != null)
            {
                (BASEbindingSource.Current as DataRowView).Row.SetColumnError("PRO_ID2", "");
                if (textBoxPRO_ID2.Text.Trim().Length > 0)
                {
                    if (!(IDChk(textBoxPRO_ID2.Text.Trim()) || JBTools.FormatValidate.CheckRPNumber(textBoxPRO_ID2.Text.Trim())))
                    {
                        MessageBox.Show(Resources.Bas.IDNOErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxPRO_ID2.Focus();
                        (BASEbindingSource.Current as DataRowView).Row.SetColumnError("PRO_ID2", Resources.Bas.IDNOErr);
                    }
                }
            }
        }

        private void checkBoxCOUNT_MA_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCOUNT_MA.Checked && textBoxIDNO.Text.Trim().Length > 0)
            {
                if (IDNOCheck)
                {
                    MessageBox.Show("外籍人士不使用身分證號，請改輸入到" + label16.Text + "欄位", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add || fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Modify)
                    {
                        textBoxMATNO.Text = textBoxIDNO.Text;
                        textBoxIDNO.Text = "";
                        textBoxIDNO.Enabled = false;
                    }
                }
            }
            else if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add || fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Modify)
                textBoxIDNO.Enabled = true;
        }
        private void FRM12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                bool state = false;
                Control focusedControl = this.FocusedControl;
                if (focusedControl != null)
                {
                    var myCtrl = focusedControl as JBControls.ComboBox;
                    var myCtrl1 = focusedControl as JBControls.TextBox;
                    var myCtrl2 = focusedControl as JBControls.PopupTextBox;
                    if (myCtrl != null)
                    {
                        state = myCtrl.IsEmpty;
                        myCtrl.IsEmpty = true;
                    }
                    else if (myCtrl1 != null)
                    {
                        state = myCtrl1.IsEmpty;
                        myCtrl1.IsEmpty = true;
                    }
                    else if (myCtrl2 != null)
                    {
                        state = myCtrl2.IsEmpty;
                        myCtrl2.IsEmpty = true;
                    }
                }

                bnCancel_Click(null, null);

                if (focusedControl != null)
                {
                    var myCtrl = focusedControl as JBControls.ComboBox;
                    var myCtrl1 = focusedControl as JBControls.TextBox;
                    var myCtrl2 = focusedControl as JBControls.PopupTextBox;
                    if (myCtrl != null)
                        myCtrl.IsEmpty = state;
                    else if (myCtrl1 != null)
                        myCtrl1.IsEmpty = state;
                    else if (myCtrl2 != null)
                        myCtrl2.IsEmpty = state;
                }
            }
            else if (e.KeyCode == Keys.PageDown)
            {
                btnNext_Click(null, null);
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                btnPrev_Click(null, null);
            }
        }

        private void textBoxIDNO_TextChanged(object sender, EventArgs e)
        {
            IsIdCheck = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string value = textBoxNOBR.Text;
            var sql = from a in MainForm.NobrListOfRead where a.CompareTo(value) > 0 orderby a ascending select a;
            if (sql.Any())
            {
                Query(sql.First());
                btnNext.Focus();
            }
        }
        public void Query(string Nobr)
        {
            bnQuery_Click(null, null);
            textBoxNOBR.Text = Nobr;
            popupTextBox1_QueryCompleted(textBoxNOBR, null);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            string value = textBoxNOBR.Text;
            var sql = from a in MainForm.NobrListOfRead where a.CompareTo(value) < 0 orderby a descending select a;
            if (sql.Any())
            {
                Query(sql.First());
                btnNext.Focus();
            }
        }

        void SetNewDefault()
        {
            if (basDS.COMP.Any()) cbCOMP.SelectedValue = basDS.COMP.First().COMP;
            //if (basDS.DEPT.Any()) comboBoxDEPT.SelectedValue = basDS.DEPT.First().D_NO;
            //if (basDS.DEPTA.Any()) cbDEPTA.SelectedValue = basDS.DEPTA.First().D_NO;
            //if (basDS.DEPTS.Any()) cbDEPTS.SelectedValue = basDS.DEPTS.First().D_NO;

            if (basDS.TTSCD.Any()) cbTTSCD.SelectedValue = basDS.TTSCD.First().TTSCD;
            //if (basDS.JOB.Any()) cbJOB.SelectedValue = basDS.JOB.First().JOB;
            //if (basDS.JOBS.Any()) cbJOBS.SelectedValue = basDS.JOBS.First().JOBS;
            //if (basDS.JOBL.Any()) cbJOBL.SelectedValue = basDS.JOBL.First().JOBL;
            if (basDS.EMPCD.Any()) cbEMPCD.SelectedValue = basDS.EMPCD.First().EMPCD;
            if (basDS.HOLICD.Any()) cbHOLICD.SelectedValue = basDS.HOLICD.First().HOLI_CODE;
            if (basDS.WORKCD.Any()) cbWORKCD.SelectedValue = basDS.WORKCD.First().WORK_CODE;
            if (basDS.SALTYCD.Any()) comboBoxSALTP.SelectedValue = basDS.SALTYCD.First().SALTYCD;
            if (basDS.OTRATECD.Any()) comboBoxCALOT.SelectedValue = basDS.OTRATECD.First().OTRATE_CODE;
            if (basDS.SALADR.Any()) comboBoxSALADR.SelectedValue = basDS.SALADR.First().SALADR;
            if (basDS.RETCHOO.Any()) comboBoxRETCHOO.SelectedValue = basDS.RETCHOO.First().CODE;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //var gv = sender as DataGridView;
                //var src = gv.DataSource as DataTable;
                //src.Rows[e.RowIndex].Delete();
            }
        }
        void CheckRule()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.U_PRGID where a.USER_ID == MainForm.USER_ID && a.PROG == "FRM12" select a;
            if (sql.Any())
            {
                var rr = sql.First();
                bool HasData = BASEbindingSource.Current != null;
                bnAdd.Enabled = rr.ADD_;
                bnDel.Enabled = (rr.DELE && HasData);
                bnEdit.Enabled = (rr.EDIT && HasData);
                bnQuery.Enabled = true;
                btnNext.Enabled = true;
                btnPrev.Enabled = true;
            }
            else if (MainForm.SUPER)
            {
                bool HasData = BASEbindingSource.Current != null;
                bnAdd.Enabled = true;
                bnDel.Enabled = (true && HasData);
                bnEdit.Enabled = (true && HasData);
                bnQuery.Enabled = true;
                btnNext.Enabled = true;
                btnPrev.Enabled = true;
            }
        }

        private void textBoxCINDT_Validated(object sender, EventArgs e)
        {
            //double totalDays = basDS1.BASETTS.Sum(
            //  ROW =>
            //     {
            //         if (new string[] { "1", "4", "6" }.Contains(ROW.TTSCODE)) //需求修改(Lanayeh)人事模組-集團到職日與在職年資 by 建華 2012/11/16
            //         {
            //             if (ROW.DDATE < ROW.CINDT)
            //             {
            //                 return 0;
            //             }
            //             else if (ROW.TTSCODE == "1")
            //             {
            //                 if (ROW.DDATE < ROW.CINDT)
            //                 {
            //                     return 0;
            //                 }
            //                 else
            //                 {
            //                     if(ROW.ADATE > ROW.CINDT)
            //                     {
            //                         return 0;
            //                     }
            //                     else if(ROW.DDATE >= DateTime.Now)
            //                     {
            //                         return (DateTime.Now.Date - ROW.CINDT).TotalDays + 1;
            //                     }
            //                     else
            //                     {
            //                         return (ROW.DDATE - ROW.CINDT).TotalDays + 1;
            //                     }
            //                 }
            //             }
            //             else if (ROW.ADATE <= ROW.CINDT && ROW.DDATE >= ROW.CINDT)
            //             {
            //                 if (ROW.DDATE >= DateTime.Now)
            //                 {
            //                     return (DateTime.Now.Date - ROW.CINDT).TotalDays + 1;
            //                 }
            //                 else
            //                 {
            //                     return (ROW.DDATE - ROW.CINDT).TotalDays + 1;
            //                 }
            //             }
            //             else
            //             {
            //                 if (ROW.DDATE >= DateTime.Now && ROW.ADATE <= DateTime.Now)
            //                 {
            //                     return (DateTime.Now.Date - ROW.ADATE).TotalDays + 1;
            //                 }
            //                 else if (ROW.ADATE > DateTime.Now)
            //                 {
            //                     return 0;
            //                 }
            //                 else
            //                 {
            //                     return (ROW.DDATE - ROW.ADATE).TotalDays + 1;
            //                 }
            //             }
            //         }
            //         else return 0;
            //     }
            //);
            //textBoxINYEAR.Text = Math.Round(totalDays / 365.25, 2).ToString();
        }

        void SetCode(JBControls.FullDataCtrl.EEditType editType)
        {
            if (editType == JBControls.FullDataCtrl.EEditType.Add)
            {
                SystemFunction.SetComboBoxItems(cbDEPTA, CodeFunction.GetDepta_effe(Convert.ToDateTime(textBoxADATE.Text)), true, true, true);        //簽核部門            
                SystemFunction.SetComboBoxItems(cbDEPTS, CodeFunction.GetDepts_effe(Convert.ToDateTime(textBoxADATE.Text)), true, true, true);        //成本部門 
                SystemFunction.SetComboBoxItems(cbDEPT, CodeFunction.GetDept_effe(Convert.ToDateTime(textBoxADATE.Text)), true, true, true);        //編制部門 
            }
            else if (editType == JBControls.FullDataCtrl.EEditType.Modify)
            {
                if (cbxAvailableCode.Checked)
                {
                    SystemFunction.SetComboBoxItems(cbDEPTA, CodeFunction.GetDepta(), true, true, true);        //簽核部門            
                    SystemFunction.SetComboBoxItems(cbDEPTS, CodeFunction.GetDepts(), true, true, true);        //成本部門 
                    SystemFunction.SetComboBoxItems(cbDEPT, CodeFunction.GetDept(), true, true, true);        //編制部門 
                }
                else
                {
                    SystemFunction.SetComboBoxItems(cbDEPTA, CodeFunction.GetDepta_effe(Convert.ToDateTime(textBoxADATE.Text)), true, true, true);        //簽核部門            
                    SystemFunction.SetComboBoxItems(cbDEPTS, CodeFunction.GetDepts_effe(Convert.ToDateTime(textBoxADATE.Text)), true, true, true);        //成本部門 
                    SystemFunction.SetComboBoxItems(cbDEPT, CodeFunction.GetDept_effe(Convert.ToDateTime(textBoxADATE.Text)), true, true, true);        //編制部門 
                }
            }
            else if (editType == JBControls.FullDataCtrl.EEditType.None)
            {
                SystemFunction.SetComboBoxItems(cbDEPTA, CodeFunction.GetDepta(), true, false, true);        //簽核部門            
                SystemFunction.SetComboBoxItems(cbDEPTS, CodeFunction.GetDepts(), true, false, true);        //成本部門 
                SystemFunction.SetComboBoxItems(cbDEPT, CodeFunction.GetDept(), true, false, true);        //編制部門 
            }
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            SetCode(JBControls.FullDataCtrl.EEditType.None);
        }

        private void cbxAvailableCode_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbxAvailableCode.Checked)
            //    SetCode(JBControls.FullDataCtrl.EEditType.None);
            //else
            //    SetCode(JBControls.FullDataCtrl.EEditType.Add);
            SetCode(fullDataCtrl1.EditType);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (formMode == FormMode.View)
            {
                if (textBoxNOBR.Text.Trim().Length == 0)
                {
                    MessageBox.Show("請先查詢出想要複製的員工資料");
                    return;
                }
                FRM12C frm = new FRM12C();
                frm.Nobr = textBoxNOBR.Text;
                frm.ShowDialog();
                if (frm.NewNobr.Trim().Length > 0)
                {
                    this.v_BASETableAdapter.Fill(this.basDS.V_BASE);
                    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

                    bnQuery_Click(null, null);
                    textBoxNOBR.Text = frm.NewNobr;
                    popupTextBox1_QueryCompleted(textBoxNOBR, null);
                    AutoABSPlus(); 
                    AutoInsAlert();
                }
            }
        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            if (queryFrm == null)
            {
                queryFrm = new QueryForm();
                //queryFrm.TopLevelControl = this;
                //queryFrm.TopLevel = true;
                //queryFrm.TopMost = true;
                queryFrm.MdiParent = this.ParentForm as JBControls.JBForm;
                queryFrm.SelectChanged += new QueryForm.SelectChangedEvent(queryFrm_SelectChanged);
            }
            queryFrm.ShowDialog();
        }

        void queryFrm_SelectChanged(object sender, QueryForm.SelectChangedEventArgs e)
        {
            if (e.Result.Trim().Length > 0 && e.Result != textBoxNOBR.Text)
                Query(e.Result);
            //queryFrm.Hide();
            //queryFrm.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {

        }

        private void dgvPayDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv.ReadOnly == false)
            {
                if (e.ColumnIndex == 0 && e.RowIndex != -1)
                {
                    var dd = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;// as BasDS.PAY_DOCRow;
                    var row = dd.Row as BasDS.PAY_DOCRow;
                    row.Delete();
                }
                if (e.ColumnIndex == 2 && e.RowIndex != -1)
                {
                    if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType() == typeof(DataGridViewCheckBoxCell))
                    {
                        DataGridViewCheckBoxCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
                        if (cell != null && Convert.ToBoolean(cell.EditedFormattedValue) == true)
                            dgv.Rows[e.RowIndex].Cells[3].Value = Sal.Function.GetDate();
                        else
                            dgv.Rows[e.RowIndex].Cells[3].Value = DBNull.Value;

                    }
                }
            }
        }

        private void btnSelectAll_Click_1(object sender, EventArgs e)
        {
            if (formMode != FormMode.View)
                if (dgvPayDoc.ReadOnly == false)
                {
                    var query = from a in basDS.PAY_DOC where !a.PAYED select a;
                    foreach (var itm in query)
                    {
                        itm.PAYED = true;
                        itm.PAY_DATE = DateTime.Now.Date;
                    }
                }
        }

        private void btnCancelAll_Click_1(object sender, EventArgs e)
        {
            if (formMode != FormMode.View)
                if (dgvPayDoc.ReadOnly == false)
                {
                    var query = from a in basDS.PAY_DOC where a.PAYED select a;
                    foreach (var itm in query)
                    {
                        itm.PAYED = false;
                        itm.SetPAY_DATENull();
                    }
                }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            if (formMode != FormMode.View)
                if (dgvPayDoc.ReadOnly == false)
                    AddPayDoc("PayDoc");
        }

        void AddPayDoc(string Category)
        {
            FRM12DataClassesDataContext FRM12Context = new FRM12DataClassesDataContext();
            new BasDSTableAdapters.PAY_DOCTableAdapter().FillByNobr(basDS.PAY_DOC, textBoxNOBR.Text.Trim(), Category);
            var doc_itms = from a in FRM12Context.DOC_ITEM where a.IsNecessary 
                           orderby a.CateGory
                               //&& a.CateGory == Category 
                           select a;
            foreach (var itm in doc_itms)
            {
                var query = from a in basDS.PAY_DOC where a.NOBR == textBoxNOBR.Text && a.DOC_ITEM == itm.AUTO select a;
                if (!query.Any())
                {
                    BasDS.PAY_DOCRow r = basDS.PAY_DOC.NewPAY_DOCRow();
                    r.DOC_ITEM = itm.AUTO;
                    r.KEY_DATE = DateTime.Now;
                    r.KEY_MAN = MainForm.USER_NAME;
                    r.NOBR = textBoxNOBR.Text;
                    r.PAYED = false;
                    basDS.PAY_DOC.AddPAY_DOCRow(r);
                }
            }
        }

        void RemovePayDoc()
        {
            basDS.PAY_DOC.RejectChanges();
            foreach (var itm in basDS.PAY_DOC)
            {
                itm.Delete();
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            if (formMode != FormMode.View)
                if (dgvPayDoc.ReadOnly == false)
                    RemovePayDoc();
        }

        private void textBoxADATE_Validated(object sender, EventArgs e)
        {
            SetAp_date();
        }

        private void SetAp_date()
        {
            //if (formMode == FormMode.Add && cbTTSCODE.SelectedValue.ToString() == "1")
            if (cbTTSCODE.SelectedValue.ToString() == "1")
            {
                try
                {
                    AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM12", MainForm.COMPANY);
                    int month = Convert.ToInt16(AppConfig.GetConfig("MonthOfAp_date").Value.Trim());
                    int day = Convert.ToInt16(AppConfig.GetConfig("DayOfAp_date").Value.Trim());
                    if (month > 0)
                        textBoxAP_DATE.Text = Convert.ToDateTime(textBoxADATE.Text).AddMonths(month).AddDays(-1).ToShortDateString();
                    else if (day > 0)
                        textBoxAP_DATE.Text = Convert.ToDateTime(textBoxADATE.Text).AddDays(day - 1).ToShortDateString();
                    textBoxINDT.Text = textBoxADATE.Text;
                    textBoxCINDT.Text = textBoxADATE.Text;
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void TextBoxNOBR_Validating(object sender, CancelEventArgs e)
        {
            FRM12DataClassesDataContext FRM12Context = new FRM12DataClassesDataContext();
            if (formMode == FormMode.Add)
            {
                if (FRM12Context.BASE.Any(p => p.NOBR == textBoxNOBR.Text))
                {
                    MessageBox.Show(Resources.Bas.NOBRREPETITION, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxNOBR.Text = "";
                    textBoxNOBR.Focus();
                    e.Cancel = true;
                }
            }
        }

        private void cbxBanCode_DropDownClosed(object sender, EventArgs e)
        {
            if (checkBoxCOUNT_MA.Checked)
                cbxBanCode_MA.SelectedValue = cbxBanCode.SelectedValue;
        }
    }
}
