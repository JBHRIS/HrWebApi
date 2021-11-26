using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
    public partial class U_SYS : JBControls.JBForm
    {
        public U_SYS()
        {
            InitializeComponent();
        }

        private void U_SYS_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            var salData = CodeFunction.GetSalCode();
            SystemFunction.SetComboBoxItems(comboBoxATTAWARDSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxEATSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxEMPSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxFOODSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxGROUPSALCD, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxHEALTHOVERSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxHEALTHREPAIRSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxHSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxLABOVERSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxLABREPAIRSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxLSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxNOTAXSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxONDUTYSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxOTFOODSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxOTFOODSALCODE1, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxOTTRASALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxRETSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxTAXSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxTOTAXSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxWELSALCODE, salData, true);
            SystemFunction.SetComboBoxItems(comboBoxSUPPLEHINSLABSALCODE, salData, true);

            this.u_SYS10TableAdapter.FillByComp(this.sysDS.U_SYS10, MainForm.COMPANY);
            this.u_SYS9TableAdapter.FillByComp(this.sysDS.U_SYS9, MainForm.COMPANY);
            this.u_SYS8TableAdapter.FillByComp(this.sysDS.U_SYS8, MainForm.COMPANY);
            this.u_SYS6TableAdapter.FillByComp(this.sysDS.U_SYS6, MainForm.COMPANY);
            this.u_SYS5TableAdapter.FillByComp(this.sysDS.U_SYS5, MainForm.COMPANY);
            this.u_SYS4TableAdapter.FillByComp(this.sysDS.U_SYS4, MainForm.COMPANY);
            this.u_SYS3TableAdapter.FillByComp(this.sysDS.U_SYS3, MainForm.COMPANY);
            this.u_SYS2TableAdapter.FillByComp(this.sysDS.U_SYS2, MainForm.COMPANY);
            this.u_SYS1TableAdapter.FillByComp(this.sysDS.U_SYS1, MainForm.COMPANY);
            this.sALCODETableAdapter.Fill(this.sysDS.SALCODE);

            //U_SYS1 的 DataBind
            if (this.sysDS.U_SYS1.Count > 0)
            {
                textBoxCOMPANY.Text = this.sysDS.U_SYS1[0].COMPANY;
                textBoxCOMPADDR.Text = this.sysDS.U_SYS1[0].COMPADDR;
                textBoxCOMPTEL.Text = this.sysDS.U_SYS1[0].COMPTEL;
                textBoxCOMPFAX.Text = this.sysDS.U_SYS1[0].COMPFAX;
                textBoxCOMPLABID.Text = this.sysDS.U_SYS1[0].COMPLABID;
                textBoxCOMPHELID.Text = this.sysDS.U_SYS1[0].COMPHELID;
                textBoxCOMPID.Text = this.sysDS.U_SYS1[0].COMPID;
                textBoxCOMPMAN.Text = this.sysDS.U_SYS1[0].COMPMAN;
                textBoxHELORGNAME.Text = this.sysDS.U_SYS1[0].HELORGNAME;
                textBoxFF103.Text = this.sysDS.U_SYS1[0].FF103;
                textBoxFF0407.Text = this.sysDS.U_SYS1[0].FF0407;
                textBoxCOMPANYBANKAC.Text = this.sysDS.U_SYS1[0].COMPANYBANKAC;
                textBoxCOMPANYBANKNO.Text = this.sysDS.U_SYS1[0].COMPANYBANKNO;
                textBoxCOMPANY1.Text = this.sysDS.U_SYS1[0].COMPANY1;
                textBoxCOMPID1.Text = this.sysDS.U_SYS1[0].COMPID1;
                textBoxFF04071.Text = this.sysDS.U_SYS1[0].FF04071;
            }

            //U_SYS2 的 DataBind
            if (this.sysDS.U_SYS2.Count > 0)
            {
                comboBoxWELSALCODE.SelectedValue = this.sysDS.U_SYS2[0].WELSALCODE;
                if (!this.sysDS.U_SYS2[0].IsWELPAYNull()) textBoxWELPAY.Text = this.sysDS.U_SYS2[0].WELPAY.ToString();
                if (!this.sysDS.U_SYS2[0].IsATTMONTHNull()) textBoxATTMONTH.Text = this.sysDS.U_SYS2[0].ATTMONTH.ToString();
                if (!this.sysDS.U_SYS2[0].IsSALMONTHNull()) textBoxSALMONTH.Text = this.sysDS.U_SYS2[0].SALMONTH.ToString();
                comboBoxEATSALCODE.SelectedValue = this.sysDS.U_SYS2[0].EATSALCODE;
                comboBoxFOODSALCODE.SelectedValue = this.sysDS.U_SYS2[0].FOODSALCODE;
                comboBoxEMPSALCODE.SelectedValue = this.sysDS.U_SYS2[0].EMPSALCODE;
                if (!this.sysDS.U_SYS2[0].IsDecimalsNull()) textBoxDecimals.Text = this.sysDS.U_SYS2[0].Decimals.ToString();
                comboBoxONDUTYSALCODE.SelectedValue = this.sysDS.U_SYS2[0].ONDUTYSALCODE;
                if (!this.sysDS.U_SYS2[0].IsONDUTYAMTNull()) textBoxONDUTYAMT.Text = this.sysDS.U_SYS2[0].ONDUTYAMT.ToString();
                comboBoxATTAWARDSALCODE.SelectedValue = this.sysDS.U_SYS2[0].ATTAWARDSALCODE;
                if (!this.sysDS.U_SYS2[0].IsATTMONAMTNull()) textBoxATTMONAMT.Text = this.sysDS.U_SYS2[0].ATTMONAMT.ToString();
                if (!this.sysDS.U_SYS2[0].IsATTQTYNull()) textBoxATTQTY.Text = this.sysDS.U_SYS2[0].ATTQTY.ToString();
                if (!this.sysDS.U_SYS2[0].IsATTQTY1Null()) textBoxATTQTY1.Text = this.sysDS.U_SYS2[0].ATTQTY1.ToString();
                if (!this.sysDS.U_SYS2[0].IsATTAMTNull()) textBoxATTAMT.Text = this.sysDS.U_SYS2[0].ATTAMT.ToString();
                if (!this.sysDS.U_SYS2[0].IsATTAMT1Null()) textBoxATTAMT1.Text = this.sysDS.U_SYS2[0].ATTAMT1.ToString();
                if (!this.sysDS.U_SYS2[0].IsLATTQTYNull()) textBoxLATTQTY.Text = this.sysDS.U_SYS2[0].LATTQTY.ToString();
                if (!this.sysDS.U_SYS2[0].IsLATTQTY1Null()) textBoxLATTQTY1.Text = this.sysDS.U_SYS2[0].LATTQTY1.ToString();
                if (!this.sysDS.U_SYS2[0].IsLATTAMTNull()) textBoxLATTAMT.Text = this.sysDS.U_SYS2[0].LATTAMT.ToString();
                if (!this.sysDS.U_SYS2[0].IsLATTAMT1Null()) textBoxLATTAMT1.Text = this.sysDS.U_SYS2[0].LATTAMT1.ToString();
                if (!this.sysDS.U_SYS2[0].IsFATTQTYNull()) textBoxFATTQTY.Text = this.sysDS.U_SYS2[0].FATTQTY.ToString();
                if (!this.sysDS.U_SYS2[0].IsFATTQTY1Null()) textBoxFATTQTY1.Text = this.sysDS.U_SYS2[0].FATTQTY1.ToString();
                if (!this.sysDS.U_SYS2[0].IsFATTAMTNull()) textBoxFATTAMT.Text = this.sysDS.U_SYS2[0].FATTAMT.ToString();
                if (!this.sysDS.U_SYS2[0].IsFATTAMT1Null()) textBoxFATTAMT1.Text = this.sysDS.U_SYS2[0].FATTAMT1.ToString();
            }

            //U_SYS3 的 DataBind
            if (this.sysDS.U_SYS3.Count > 0)
            {
                comboBoxNOTAXSALCODE.SelectedValue = this.sysDS.U_SYS3[0].NOTAXSALCODE;
                comboBoxTOTAXSALCODE.SelectedValue = this.sysDS.U_SYS3[0].TOTAXSALCODE;
                comboBoxOTFOODSALCODE.SelectedValue = this.sysDS.U_SYS3[0].OTFOODSALCODE;
                comboBoxOTFOODSALCODE1.SelectedValue = this.sysDS.U_SYS3[0].OTFOODSALCODE1;
                comboBoxOTTRASALCODE.SelectedValue = this.sysDS.U_SYS3[0].OTTRASALCODE;
                if (!this.sysDS.U_SYS3[0].IsMALEMAXHRSNull()) textBoxMALEMAXHRS.Text = this.sysDS.U_SYS3[0].MALEMAXHRS.ToString();
                if (!this.sysDS.U_SYS3[0].IsFEMALEMAXHRSNull()) textBoxFEMALEMAXHRS.Text = this.sysDS.U_SYS3[0].FEMALEMAXHRS.ToString();
                if (!this.sysDS.U_SYS3[0].IsOTUNITNull()) textBoxOTUNIT.Text = this.sysDS.U_SYS3[0].OTUNIT.ToString();
            }

            //U_SYS4 的 DataBind
            if (this.sysDS.U_SYS4.Count > 0)
            {
                comboBoxLSALCODE.SelectedValue = this.sysDS.U_SYS4[0].LSALCODE;
                if (!this.sysDS.U_SYS4[0].IsLABOVERSALCODENull()) comboBoxLABOVERSALCODE.SelectedValue = this.sysDS.U_SYS4[0].LABOVERSALCODE;
                if (!this.sysDS.U_SYS4[0].IsLABREPAIRSALCODENull()) comboBoxLABREPAIRSALCODE.SelectedValue = this.sysDS.U_SYS4[0].LABREPAIRSALCODE;
                if (!this.sysDS.U_SYS4[0].IsLJOBPER1Null()) textBoxLJOBPER1.Text = this.sysDS.U_SYS4[0].LJOBPER1.ToString();
                if (!this.sysDS.U_SYS4[0].IsLJOBPERNull()) textBoxLJOBPER.Text = this.sysDS.U_SYS4[0].LJOBPER.ToString();
                if (!this.sysDS.U_SYS4[0].IsRETIRERATE1Null()) textBoxRETIRERATE1.Text = this.sysDS.U_SYS4[0].RETIRERATE1.ToString();
                if (!this.sysDS.U_SYS4[0].IsRETIRERATENull()) textBoxRETIRERATE.Text = this.sysDS.U_SYS4[0].RETIRERATE.ToString();
                if (!this.sysDS.U_SYS4[0].IsNRETIRERATE1Null()) textBoxNRETIRERATE1.Text = this.sysDS.U_SYS4[0].NRETIRERATE1.ToString();
                if (!this.sysDS.U_SYS4[0].IsNRETIRERATENull()) textBoxNRETIRERATE.Text = this.sysDS.U_SYS4[0].NRETIRERATE.ToString();
                if (!this.sysDS.U_SYS4[0].IsRETSALCODENull()) comboBoxRETSALCODE.SelectedValue = this.sysDS.U_SYS4[0].RETSALCODE;
            }

            //U_SYS5 的 DataBind
            if (this.sysDS.U_SYS5.Count > 0)
            {
                comboBoxHSALCODE.SelectedValue = this.sysDS.U_SYS5[0].HSALCODE;
                comboBoxHEALTHOVERSALCODE.SelectedValue = this.sysDS.U_SYS5[0].HEALTHOVERSALCODE;
                comboBoxHEALTHREPAIRSALCODE.SelectedValue = this.sysDS.U_SYS5[0].HEALTHREPAIRSALCODE;
                if (!this.sysDS.U_SYS5[0].IsEMPFAMILYCNTNull()) textBoxEMPFAMILYCNT.Text = this.sysDS.U_SYS5[0].EMPFAMILYCNT.ToString();
                if (!this.sysDS.U_SYS5[0].IsCOMPERSONCNTNull()) textBoxCOMPERSONCNT.Text = this.sysDS.U_SYS5[0].COMPERSONCNT.ToString();
                if (!this.sysDS.U_SYS5[0].IsHEACOMPRATENull()) textBoxHEACOMPRATE.Text = this.sysDS.U_SYS5[0].HEACOMPRATE.ToString();
                #region 二代健保補充保費
                if (!this.sysDS.U_SYS5[0].IsSUPPLEHINSLABSALCODENull()) comboBoxSUPPLEHINSLABSALCODE.SelectedValue = this.sysDS.U_SYS5[0].SUPPLEHINSLABSALCODE;//補充保費
                if (!this.sysDS.U_SYS5[0].IsSUPPLEINSLABRATENull()) textBoxSUPPLEINSLABRATE.Text = this.sysDS.U_SYS5[0].SUPPLEINSLABRATE.ToString();//補充保費
                if (!this.sysDS.U_SYS5[0].IsBONUSYEARRATEMAXNull()) textBoxBONUSYEARRATEMAX.Text = this.sysDS.U_SYS5[0].BONUSYEARRATEMAX.ToString();//補充保費 
                #endregion
            }

            //U_SYS6 的 DataBind
            if (this.sysDS.U_SYS6.Count > 0)
            {
                comboBoxGROUPSALCD.SelectedValue = this.sysDS.U_SYS6[0].GROUPSALCD;
                if (!this.sysDS.U_SYS6[0].IsGROUPEXP1Null()) textBoxGROUPEXP1.Text = this.sysDS.U_SYS6[0].GROUPEXP1.ToString();
                if (!this.sysDS.U_SYS6[0].IsGROUPEXP2Null()) textBoxGROUPEXP2.Text = this.sysDS.U_SYS6[0].GROUPEXP2.ToString();
                if (!this.sysDS.U_SYS6[0].IsGROUPEXP51Null()) textBoxGROUPEXP51.Text = this.sysDS.U_SYS6[0].GROUPEXP51.ToString();
                if (!this.sysDS.U_SYS6[0].IsGROUPEXP52Null()) textBoxGROUPEXP52.Text = this.sysDS.U_SYS6[0].GROUPEXP52.ToString();
            }

            if (this.sysDS.U_SYS8.Count > 0)
            {
                if (!this.sysDS.U_SYS8[0].IsYEAR11Null()) textBoxYEAR11.Text = this.sysDS.U_SYS8[0].YEAR11.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR12Null()) textBoxYEAR12.Text = this.sysDS.U_SYS8[0].YEAR12.ToString();
                if (!this.sysDS.U_SYS8[0].IsVACATIONDAYS01Null()) textBoxVACATIONDAYS01.Text = this.sysDS.U_SYS8[0].VACATIONDAYS01.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR21Null()) textBoxYEAR21.Text = this.sysDS.U_SYS8[0].YEAR21.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR22Null()) textBoxYEAR22.Text = this.sysDS.U_SYS8[0].YEAR22.ToString();
                if (!this.sysDS.U_SYS8[0].IsVACATIONDAYS02Null()) textBoxVACATIONDAYS02.Text = this.sysDS.U_SYS8[0].VACATIONDAYS02.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR31Null()) textBoxYEAR31.Text = this.sysDS.U_SYS8[0].YEAR31.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR32Null()) textBoxYEAR32.Text = this.sysDS.U_SYS8[0].YEAR32.ToString();
                if (!this.sysDS.U_SYS8[0].IsVACATIONDAYS03Null()) textBoxVACATIONDAYS03.Text = this.sysDS.U_SYS8[0].VACATIONDAYS03.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR41Null()) textBoxYEAR41.Text = this.sysDS.U_SYS8[0].YEAR41.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR42Null()) textBoxYEAR42.Text = this.sysDS.U_SYS8[0].YEAR42.ToString();
                if (!this.sysDS.U_SYS8[0].IsVACATIONDAYS04Null()) textBoxVACATIONDAYS04.Text = this.sysDS.U_SYS8[0].VACATIONDAYS04.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR51Null()) textBoxYEAR51.Text = this.sysDS.U_SYS8[0].YEAR51.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR52Null()) textBoxYEAR52.Text = this.sysDS.U_SYS8[0].YEAR52.ToString();
                if (!this.sysDS.U_SYS8[0].IsVACATIONDAYS05Null()) textBoxVACATIONDAYS05.Text = this.sysDS.U_SYS8[0].VACATIONDAYS05.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR61Null()) textBoxYEAR61.Text = this.sysDS.U_SYS8[0].YEAR61.ToString();
                if (!this.sysDS.U_SYS8[0].IsNEXTYEARDAYNull()) textBoxNEXTYEARDAY.Text = this.sysDS.U_SYS8[0].NEXTYEARDAY.ToString();
                if (!this.sysDS.U_SYS8[0].IsMAXDAYSNull()) textBoxMAXDAYS.Text = this.sysDS.U_SYS8[0].MAXDAYS.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEARBASENull()) textBoxYEARBASE.Text = this.sysDS.U_SYS8[0].YEARBASE.ToString();

                if (!this.sysDS.U_SYS8[0].IsYEAR01Null()) textBoxYEAR01.Text = this.sysDS.U_SYS8[0].YEAR01.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH01DAY1Null()) textBoxMONTH01DAY1.Text = this.sysDS.U_SYS8[0].MONTH01DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH02DAY1Null()) textBoxMONTH02DAY1.Text = this.sysDS.U_SYS8[0].MONTH02DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH03DAY1Null()) textBoxMONTH03DAY1.Text = this.sysDS.U_SYS8[0].MONTH03DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH04DAY1Null()) textBoxMONTH04DAY1.Text = this.sysDS.U_SYS8[0].MONTH04DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH05DAY1Null()) textBoxMONTH05DAY1.Text = this.sysDS.U_SYS8[0].MONTH05DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH06DAY1Null()) textBoxMONTH06DAY1.Text = this.sysDS.U_SYS8[0].MONTH06DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH07DAY1Null()) textBoxMONTH07DAY1.Text = this.sysDS.U_SYS8[0].MONTH07DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH08DAY1Null()) textBoxMONTH08DAY1.Text = this.sysDS.U_SYS8[0].MONTH08DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH09DAY1Null()) textBoxMONTH09DAY1.Text = this.sysDS.U_SYS8[0].MONTH09DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH10DAY1Null()) textBoxMONTH10DAY1.Text = this.sysDS.U_SYS8[0].MONTH10DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH11DAY1Null()) textBoxMONTH11DAY1.Text = this.sysDS.U_SYS8[0].MONTH11DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH12DAY1Null()) textBoxMONTH12DAY1.Text = this.sysDS.U_SYS8[0].MONTH12DAY1.ToString();

                if (!this.sysDS.U_SYS8[0].IsYEAR02Null()) textBoxYEAR02.Text = this.sysDS.U_SYS8[0].YEAR02.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH01DAY2Null()) textBoxMONTH01DAY2.Text = this.sysDS.U_SYS8[0].MONTH01DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH02DAY2Null()) textBoxMONTH02DAY2.Text = this.sysDS.U_SYS8[0].MONTH02DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH03DAY2Null()) textBoxMONTH03DAY2.Text = this.sysDS.U_SYS8[0].MONTH03DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH04DAY2Null()) textBoxMONTH04DAY2.Text = this.sysDS.U_SYS8[0].MONTH04DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH05DAY2Null()) textBoxMONTH05DAY2.Text = this.sysDS.U_SYS8[0].MONTH05DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH06DAY2Null()) textBoxMONTH06DAY2.Text = this.sysDS.U_SYS8[0].MONTH06DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH07DAY2Null()) textBoxMONTH07DAY2.Text = this.sysDS.U_SYS8[0].MONTH07DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH08DAY2Null()) textBoxMONTH08DAY2.Text = this.sysDS.U_SYS8[0].MONTH08DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH09DAY2Null()) textBoxMONTH09DAY2.Text = this.sysDS.U_SYS8[0].MONTH09DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH10DAY2Null()) textBoxMONTH10DAY2.Text = this.sysDS.U_SYS8[0].MONTH10DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH11DAY2Null()) textBoxMONTH11DAY2.Text = this.sysDS.U_SYS8[0].MONTH11DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH12DAY2Null()) textBoxMONTH12DAY2.Text = this.sysDS.U_SYS8[0].MONTH12DAY2.ToString();

                if (!this.sysDS.U_SYS8[0].IsYEAR03Null()) textBoxYEAR03.Text = this.sysDS.U_SYS8[0].YEAR03.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH01DAY3Null()) textBoxMONTH01DAY3.Text = this.sysDS.U_SYS8[0].MONTH01DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH02DAY3Null()) textBoxMONTH02DAY3.Text = this.sysDS.U_SYS8[0].MONTH02DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH03DAY3Null()) textBoxMONTH03DAY3.Text = this.sysDS.U_SYS8[0].MONTH03DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH04DAY3Null()) textBoxMONTH04DAY3.Text = this.sysDS.U_SYS8[0].MONTH04DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH05DAY3Null()) textBoxMONTH05DAY3.Text = this.sysDS.U_SYS8[0].MONTH05DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH06DAY3Null()) textBoxMONTH06DAY3.Text = this.sysDS.U_SYS8[0].MONTH06DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH07DAY3Null()) textBoxMONTH07DAY3.Text = this.sysDS.U_SYS8[0].MONTH07DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH08DAY3Null()) textBoxMONTH08DAY3.Text = this.sysDS.U_SYS8[0].MONTH08DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH09DAY3Null()) textBoxMONTH09DAY3.Text = this.sysDS.U_SYS8[0].MONTH09DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH10DAY3Null()) textBoxMONTH10DAY3.Text = this.sysDS.U_SYS8[0].MONTH10DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH11DAY3Null()) textBoxMONTH11DAY3.Text = this.sysDS.U_SYS8[0].MONTH11DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH12DAY3Null()) textBoxMONTH12DAY3.Text = this.sysDS.U_SYS8[0].MONTH12DAY3.ToString();

                if (!this.sysDS.U_SYS8[0].IsYEAR04Null()) textBoxYEAR04.Text = this.sysDS.U_SYS8[0].YEAR04.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH01DAY4Null()) textBoxMONTH01DAY4.Text = this.sysDS.U_SYS8[0].MONTH01DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH02DAY4Null()) textBoxMONTH02DAY4.Text = this.sysDS.U_SYS8[0].MONTH02DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH03DAY4Null()) textBoxMONTH03DAY4.Text = this.sysDS.U_SYS8[0].MONTH03DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH04DAY4Null()) textBoxMONTH04DAY4.Text = this.sysDS.U_SYS8[0].MONTH04DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH05DAY4Null()) textBoxMONTH05DAY4.Text = this.sysDS.U_SYS8[0].MONTH05DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH06DAY4Null()) textBoxMONTH06DAY4.Text = this.sysDS.U_SYS8[0].MONTH06DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH07DAY4Null()) textBoxMONTH07DAY4.Text = this.sysDS.U_SYS8[0].MONTH07DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH08DAY4Null()) textBoxMONTH08DAY4.Text = this.sysDS.U_SYS8[0].MONTH08DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH09DAY4Null()) textBoxMONTH09DAY4.Text = this.sysDS.U_SYS8[0].MONTH09DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH10DAY4Null()) textBoxMONTH10DAY4.Text = this.sysDS.U_SYS8[0].MONTH10DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH11DAY4Null()) textBoxMONTH11DAY4.Text = this.sysDS.U_SYS8[0].MONTH11DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH12DAY4Null()) textBoxMONTH12DAY4.Text = this.sysDS.U_SYS8[0].MONTH12DAY4.ToString();

                if (!this.sysDS.U_SYS8[0].IsYEAR05Null()) textBoxYEAR05.Text = this.sysDS.U_SYS8[0].YEAR05.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH01DAY5Null()) textBoxMONTH01DAY5.Text = this.sysDS.U_SYS8[0].MONTH01DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH02DAY5Null()) textBoxMONTH02DAY5.Text = this.sysDS.U_SYS8[0].MONTH02DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH03DAY5Null()) textBoxMONTH03DAY5.Text = this.sysDS.U_SYS8[0].MONTH03DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH04DAY5Null()) textBoxMONTH04DAY5.Text = this.sysDS.U_SYS8[0].MONTH04DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH05DAY5Null()) textBoxMONTH05DAY5.Text = this.sysDS.U_SYS8[0].MONTH05DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH06DAY5Null()) textBoxMONTH06DAY5.Text = this.sysDS.U_SYS8[0].MONTH06DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH07DAY5Null()) textBoxMONTH07DAY5.Text = this.sysDS.U_SYS8[0].MONTH07DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH08DAY5Null()) textBoxMONTH08DAY5.Text = this.sysDS.U_SYS8[0].MONTH08DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH09DAY5Null()) textBoxMONTH09DAY5.Text = this.sysDS.U_SYS8[0].MONTH09DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH10DAY5Null()) textBoxMONTH10DAY5.Text = this.sysDS.U_SYS8[0].MONTH10DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH11DAY5Null()) textBoxMONTH11DAY5.Text = this.sysDS.U_SYS8[0].MONTH11DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH12DAY5Null()) textBoxMONTH12DAY5.Text = this.sysDS.U_SYS8[0].MONTH12DAY5.ToString();

                if (!sysDS.U_SYS8[0].IsNull("SPECIALCALTYPE"))
                {
                    if (sysDS.U_SYS8[0].SPECIALCALTYPE == 1) rbnSPECIALCALTYPE1.Checked = true;
                    else rbnSPECIALCALTYPE2.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0TYPE1"))
                {
                    if (sysDS.U_SYS8[0].YEAR0TYPE1 == 1) rbnYEAR0TYPE11.Checked = true;
                    else rbnYEAR0TYPE12.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0TYPE2"))
                {
                    if (sysDS.U_SYS8[0].YEAR0TYPE2 == 1) rbnYEAR0TYPE21.Checked = true;
                    else rbnYEAR0TYPE22.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0TYPE3"))
                {
                    if (sysDS.U_SYS8[0].YEAR0TYPE3 == 1) rbnYEAR0TYPE31.Checked = true;
                    else rbnYEAR0TYPE32.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0TYPE4"))
                {
                    if (sysDS.U_SYS8[0].YEAR0TYPE4 == 1) rbnYEAR0TYPE41.Checked = true;
                    else rbnYEAR0TYPE42.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0TYPE5"))
                {
                    if (sysDS.U_SYS8[0].YEAR0TYPE5 == 1) rbnYEAR0TYPE51.Checked = true;
                    else rbnYEAR0TYPE52.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0EFFTYPE1"))
                {
                    if (sysDS.U_SYS8[0].YEAR0EFFTYPE1 == 1) rbnYEAR0EFFTYPE11.Checked = true;
                    else rbnYEAR0EFFTYPE12.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0EFFTYPE2"))
                {
                    if (sysDS.U_SYS8[0].YEAR0EFFTYPE2 == 1) rbnYEAR0EFFTYPE21.Checked = true;
                    else rbnYEAR0EFFTYPE22.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0EFFTYPE3"))
                {
                    if (sysDS.U_SYS8[0].YEAR0EFFTYPE3 == 1) rbnYEAR0EFFTYPE31.Checked = true;
                    else rbnYEAR0EFFTYPE32.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0EFFTYPE4"))
                {
                    if (sysDS.U_SYS8[0].YEAR0EFFTYPE4 == 1) rbnYEAR0EFFTYPE41.Checked = true;
                    else rbnYEAR0EFFTYPE42.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0EFFTYPE5"))
                {
                    if (sysDS.U_SYS8[0].YEAR0EFFTYPE5 == 1) rbnYEAR0EFFTYPE51.Checked = true;
                    else rbnYEAR0EFFTYPE52.Checked = true;
                }
            }

            if (sysDS.U_SYS9.Count > 0)
            {
                if (!sysDS.U_SYS9[0].IsSTDEDUETAMTNMARNull()) textBoxSTDEDUETAMTNMAR.Text = sysDS.U_SYS9[0].STDEDUETAMTNMAR.ToString();
                if (!sysDS.U_SYS9[0].IsSTDEDUETAMTMARNull()) textBoxSTDEDUETAMTMAR.Text = sysDS.U_SYS9[0].STDEDUETAMTMAR.ToString();
                if (!sysDS.U_SYS9[0].IsTAXFREE70DOWNNull()) textBoxTAXFREE70DOWN.Text = sysDS.U_SYS9[0].TAXFREE70DOWN.ToString();
                if (!sysDS.U_SYS9[0].IsTAXFREE70UPNull()) textBoxTAXFREE70UP.Text = sysDS.U_SYS9[0].TAXFREE70UP.ToString();
                if (!sysDS.U_SYS9[0].IsSALARYDEDUTAMTNull()) textBoxSALARYDEDUTAMT.Text = sysDS.U_SYS9[0].SALARYDEDUTAMT.ToString();
                comboBoxTAXSALCODE.SelectedValue = sysDS.U_SYS9[0].TAXSALCODE;
                if (!sysDS.U_SYS9[0].IsTAXAMTAMONTHNull()) textBoxTAXAMTAMONTH.Text = sysDS.U_SYS9[0].TAXAMTAMONTH.ToString();
                if (!sysDS.U_SYS9[0].IsFIXTAXRATENull()) textBoxFIXTAXRATE.Text = sysDS.U_SYS9[0].FIXTAXRATE.ToString();

                if (!sysDS.U_SYS9[0].IsNETTAXAMT01Null()) textBoxNETTAXAMT01.Text = sysDS.U_SYS9[0].NETTAXAMT01.ToString();
                if (!sysDS.U_SYS9[0].IsNETTAXAMT02Null()) textBoxNETTAXAMT02.Text = sysDS.U_SYS9[0].NETTAXAMT02.ToString();
                if (!sysDS.U_SYS9[0].IsNETTAXRATE01Null()) textBoxNETTAXRATE01.Text = sysDS.U_SYS9[0].NETTAXRATE01.ToString();
                if (!sysDS.U_SYS9[0].IsADDUPAMT01Null()) textBoxADDUPAMT01.Text = sysDS.U_SYS9[0].ADDUPAMT01.ToString();

                if (!sysDS.U_SYS9[0].IsNETTAXAMT03Null()) textBoxNETTAXAMT03.Text = sysDS.U_SYS9[0].NETTAXAMT03.ToString();
                if (!sysDS.U_SYS9[0].IsNETTAXAMT04Null()) textBoxNETTAXAMT04.Text = sysDS.U_SYS9[0].NETTAXAMT04.ToString();
                if (!sysDS.U_SYS9[0].IsNETTAXRATE02Null()) textBoxNETTAXRATE02.Text = sysDS.U_SYS9[0].NETTAXRATE02.ToString();
                if (!sysDS.U_SYS9[0].IsADDUPAMT02Null()) textBoxADDUPAMT02.Text = sysDS.U_SYS9[0].ADDUPAMT02.ToString();

                if (!sysDS.U_SYS9[0].IsNETTAXAMT05Null()) textBoxNETTAXAMT05.Text = sysDS.U_SYS9[0].NETTAXAMT05.ToString();
                if (!sysDS.U_SYS9[0].IsNETTAXAMT06Null()) textBoxNETTAXAMT06.Text = sysDS.U_SYS9[0].NETTAXAMT06.ToString();
                if (!sysDS.U_SYS9[0].IsNETTAXRATE03Null()) textBoxNETTAXRATE03.Text = sysDS.U_SYS9[0].NETTAXRATE03.ToString();
                if (!sysDS.U_SYS9[0].IsADDUPAMT03Null()) textBoxADDUPAMT03.Text = sysDS.U_SYS9[0].ADDUPAMT03.ToString();

                if (!sysDS.U_SYS9[0].IsNETTAXAMT07Null()) textBoxNETTAXAMT07.Text = sysDS.U_SYS9[0].NETTAXAMT07.ToString();
                if (!sysDS.U_SYS9[0].IsNETTAXAMT08Null()) textBoxNETTAXAMT08.Text = sysDS.U_SYS9[0].NETTAXAMT08.ToString();
                if (!sysDS.U_SYS9[0].IsNETTAXRATE04Null()) textBoxNETTAXRATE04.Text = sysDS.U_SYS9[0].NETTAXRATE04.ToString();
                if (!sysDS.U_SYS9[0].IsADDUPAMT04Null()) textBoxADDUPAMT04.Text = sysDS.U_SYS9[0].ADDUPAMT04.ToString();

                if (!sysDS.U_SYS9[0].IsNETTAXAMT09Null()) textBoxNETTAXAMT09.Text = sysDS.U_SYS9[0].NETTAXAMT09.ToString();
                if (!sysDS.U_SYS9[0].IsNETTAXAMT10Null()) textBoxNETTAXAMT10.Text = sysDS.U_SYS9[0].NETTAXAMT10.ToString();
                if (!sysDS.U_SYS9[0].IsNETTAXRATE05Null()) textBoxNETTAXRATE05.Text = sysDS.U_SYS9[0].NETTAXRATE05.ToString();
                if (!sysDS.U_SYS9[0].IsADDUPAMT05Null()) textBoxADDUPAMT05.Text = sysDS.U_SYS9[0].ADDUPAMT05.ToString();

                if (!sysDS.U_SYS9[0].IsFORSALBASDNull()) textBoxFORSALBASD.Text = sysDS.U_SYS9[0].FORSALBASD.ToString();
                if (!sysDS.U_SYS9[0].IsFORTAXRATE03Null()) textBoxFORTAXRATE03.Text = sysDS.U_SYS9[0].FORTAXRATE03.ToString();
                if (!sysDS.U_SYS9[0].IsENTRYDAYNull()) textBoxENTRYDAY.Text = sysDS.U_SYS9[0].ENTRYDAY.ToString();
                if (!sysDS.U_SYS9[0].IsFORTAXRATE01Null()) textBoxFORTAXRATE01.Text = sysDS.U_SYS9[0].FORTAXRATE01.ToString();
                if (!sysDS.U_SYS9[0].IsFORTAXRATE02Null()) textBoxFORTAXRATE02.Text = sysDS.U_SYS9[0].FORTAXRATE02.ToString();

                if (!sysDS.U_SYS9[0].IsNull("TAXTYPE"))
                {
                    if (sysDS.U_SYS9[0].TAXTYPE == 1) rbnTAXTYPE1.Checked = true;
                    else rbnTAXTYPE2.Checked = true;
                }
            }

            if (sysDS.U_SYS10.Count > 0)
            {
                textBoxSMTPSERVER.Text = sysDS.U_SYS10[0].SMTPSERVER;
                textBoxSENDMAIL.Text = sysDS.U_SYS10[0].SENDMAIL;
                textBoxSMTPID.Text = sysDS.U_SYS10[0].SMTPID;
                textBoxSMTPPW.Text = sysDS.U_SYS10[0].SMTPPW;
            }
            //TabRule.CheckRule(this.Name, tabControl1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (U_SYS1bindingSource.Count == 0) U_SYS1bindingSource.AddNew();
                (U_SYS1bindingSource.Current as DataRowView).BeginEdit();
                if (U_SYS2bindingSource.Count == 0) U_SYS2bindingSource.AddNew();
                (U_SYS2bindingSource.Current as DataRowView).BeginEdit();
                if (U_SYS3bindingSource.Count == 0) U_SYS3bindingSource.AddNew();
                (U_SYS3bindingSource.Current as DataRowView).BeginEdit();
                if (U_SYS4bindingSource.Count == 0) U_SYS4bindingSource.AddNew();
                (U_SYS4bindingSource.Current as DataRowView).BeginEdit();
                if (U_SYS5bindingSource.Count == 0) U_SYS5bindingSource.AddNew();
                (U_SYS5bindingSource.Current as DataRowView).BeginEdit();
                if (U_SYS6bindingSource.Count == 0) U_SYS6bindingSource.AddNew();
                (U_SYS6bindingSource.Current as DataRowView).BeginEdit();
                if (U_SYS8bindingSource.Count == 0) U_SYS8bindingSource.AddNew();
                (U_SYS8bindingSource.Current as DataRowView).BeginEdit();
                if (U_SYS9bindingSource.Count == 0) U_SYS9bindingSource.AddNew();
                (U_SYS9bindingSource.Current as DataRowView).BeginEdit();
                if (U_SYS10bindingSource.Count == 0) U_SYS10bindingSource.AddNew();
                (U_SYS10bindingSource.Current as DataRowView).BeginEdit();

                //U_SYS1 資料寫回
                (U_SYS1bindingSource.Current as DataRowView)["COMP"] = MainForm.COMPANY;
                (U_SYS1bindingSource.Current as DataRowView)["COMPANY"] = textBoxCOMPANY.Text;
                (U_SYS1bindingSource.Current as DataRowView)["COMPADDR"] = textBoxCOMPADDR.Text;
                (U_SYS1bindingSource.Current as DataRowView)["COMPTEL"] = textBoxCOMPTEL.Text;
                (U_SYS1bindingSource.Current as DataRowView)["COMPFAX"] = textBoxCOMPFAX.Text;
                (U_SYS1bindingSource.Current as DataRowView)["COMPLABID"] = textBoxCOMPLABID.Text;
                (U_SYS1bindingSource.Current as DataRowView)["COMPHELID"] = textBoxCOMPHELID.Text;
                (U_SYS1bindingSource.Current as DataRowView)["COMPID"] = textBoxCOMPID.Text;
                (U_SYS1bindingSource.Current as DataRowView)["COMPMAN"] = textBoxCOMPMAN.Text;
                (U_SYS1bindingSource.Current as DataRowView)["HELORGNAME"] = textBoxHELORGNAME.Text;
                (U_SYS1bindingSource.Current as DataRowView)["FF103"] = textBoxFF103.Text;
                (U_SYS1bindingSource.Current as DataRowView)["FF0407"] = textBoxFF0407.Text;
                (U_SYS1bindingSource.Current as DataRowView)["COMPANYBANKAC"] = textBoxCOMPANYBANKAC.Text;
                (U_SYS1bindingSource.Current as DataRowView)["COMPANYBANKNO"] = textBoxCOMPANYBANKNO.Text;
                (U_SYS1bindingSource.Current as DataRowView)["COMPANY1"] = textBoxCOMPANY1.Text;
                (U_SYS1bindingSource.Current as DataRowView)["COMPID1"] = textBoxCOMPID1.Text;
                (U_SYS1bindingSource.Current as DataRowView)["FF04071"] = textBoxFF04071.Text;

                //U_SYS2 資料寫回
                (U_SYS2bindingSource.Current as DataRowView)["COMP"] = MainForm.COMPANY;
                (U_SYS2bindingSource.Current as DataRowView)["WELSALCODE"] = comboBoxWELSALCODE.SelectedValue != null ? comboBoxWELSALCODE.SelectedValue.ToString() : "";
                (U_SYS2bindingSource.Current as DataRowView)["WELPAY"] = (textBoxWELPAY.Text.Trim().Length > 0) ? textBoxWELPAY.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["ATTMONTH"] = (textBoxATTMONTH.Text.Trim().Length > 0) ? textBoxATTMONTH.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["SALMONTH"] = (textBoxSALMONTH.Text.Trim().Length > 0) ? textBoxSALMONTH.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["EATSALCODE"] = comboBoxEATSALCODE.SelectedValue != null ? comboBoxEATSALCODE.SelectedValue.ToString() : "";
                (U_SYS2bindingSource.Current as DataRowView)["FOODSALCODE"] = comboBoxFOODSALCODE.SelectedValue != null ? comboBoxFOODSALCODE.SelectedValue.ToString() : "";
                (U_SYS2bindingSource.Current as DataRowView)["EMPSALCODE"] = comboBoxEMPSALCODE.SelectedValue != null ? comboBoxEMPSALCODE.SelectedValue.ToString() : "";
                (U_SYS2bindingSource.Current as DataRowView)["Decimals"] = (textBoxDecimals.Text.Trim().Length > 0) ? textBoxDecimals.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["ONDUTYSALCODE"] = comboBoxONDUTYSALCODE.SelectedValue != null ? comboBoxONDUTYSALCODE.SelectedValue.ToString() : "";
                (U_SYS2bindingSource.Current as DataRowView)["ONDUTYAMT"] = (textBoxONDUTYAMT.Text.Trim().Length > 0) ? textBoxONDUTYAMT.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["ATTAWARDSALCODE"] = comboBoxATTAWARDSALCODE.SelectedValue != null ? comboBoxATTAWARDSALCODE.SelectedValue.ToString() : "";
                (U_SYS2bindingSource.Current as DataRowView)["ATTMONAMT"] = (textBoxATTMONAMT.Text.Trim().Length > 0) ? textBoxATTMONAMT.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["ATTQTY"] = (textBoxATTQTY.Text.Trim().Length > 0) ? textBoxATTQTY.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["ATTQTY1"] = (textBoxATTQTY1.Text.Trim().Length > 0) ? textBoxATTQTY1.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["ATTAMT"] = (textBoxATTAMT.Text.Trim().Length > 0) ? textBoxATTAMT.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["ATTAMT1"] = (textBoxATTAMT1.Text.Trim().Length > 0) ? textBoxATTAMT1.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["LATTQTY"] = (textBoxLATTQTY.Text.Trim().Length > 0) ? textBoxLATTQTY.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["LATTQTY1"] = (textBoxLATTQTY1.Text.Trim().Length > 0) ? textBoxLATTQTY1.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["LATTAMT"] = (textBoxLATTAMT.Text.Trim().Length > 0) ? textBoxLATTAMT.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["LATTAMT1"] = (textBoxLATTAMT1.Text.Trim().Length > 0) ? textBoxLATTAMT1.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["FATTQTY"] = (textBoxFATTQTY.Text.Trim().Length > 0) ? textBoxFATTQTY.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["FATTQTY1"] = (textBoxFATTQTY1.Text.Trim().Length > 0) ? textBoxFATTQTY1.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["FATTAMT"] = (textBoxFATTAMT.Text.Trim().Length > 0) ? textBoxFATTAMT.Text : "0";
                (U_SYS2bindingSource.Current as DataRowView)["FATTAMT1"] = (textBoxFATTAMT1.Text.Trim().Length > 0) ? textBoxFATTAMT1.Text : "0";

                //U_SYS3 資料寫回
                (U_SYS3bindingSource.Current as DataRowView)["COMP"] = MainForm.COMPANY;
                (U_SYS3bindingSource.Current as DataRowView)["NOTAXSALCODE"] = comboBoxNOTAXSALCODE.SelectedValue != null ? comboBoxNOTAXSALCODE.SelectedValue.ToString() : "";
                (U_SYS3bindingSource.Current as DataRowView)["TOTAXSALCODE"] = comboBoxTOTAXSALCODE.SelectedValue != null ? comboBoxTOTAXSALCODE.SelectedValue.ToString() : "";
                (U_SYS3bindingSource.Current as DataRowView)["OTFOODSALCODE"] = comboBoxOTFOODSALCODE.SelectedValue != null ? comboBoxOTFOODSALCODE.SelectedValue.ToString() : "";
                (U_SYS3bindingSource.Current as DataRowView)["OTFOODSALCODE1"] = comboBoxOTFOODSALCODE1.SelectedValue != null ? comboBoxOTFOODSALCODE1.SelectedValue.ToString() : "";
                (U_SYS3bindingSource.Current as DataRowView)["OTTRASALCODE"] = comboBoxOTTRASALCODE.SelectedValue != null ? comboBoxOTTRASALCODE.SelectedValue.ToString() : "";
                (U_SYS3bindingSource.Current as DataRowView)["MALEMAXHRS"] = (textBoxMALEMAXHRS.Text.Trim().Length > 0) ? textBoxMALEMAXHRS.Text : "0";
                (U_SYS3bindingSource.Current as DataRowView)["FEMALEMAXHRS"] = (textBoxFEMALEMAXHRS.Text.Trim().Length > 0) ? textBoxFEMALEMAXHRS.Text : "0";
                (U_SYS3bindingSource.Current as DataRowView)["OTUNIT"] = (textBoxOTUNIT.Text.Trim().Length > 0) ? textBoxOTUNIT.Text : "0";

                //U_SYS4 資料寫回
                (U_SYS4bindingSource.Current as DataRowView)["COMP"] = MainForm.COMPANY;
                (U_SYS4bindingSource.Current as DataRowView)["LSALCODE"] = comboBoxLSALCODE.SelectedValue != null ? comboBoxLSALCODE.SelectedValue.ToString() : "";
                (U_SYS4bindingSource.Current as DataRowView)["LABOVERSALCODE"] = comboBoxLABOVERSALCODE.SelectedValue != null ? comboBoxLABOVERSALCODE.SelectedValue.ToString() : "";
                (U_SYS4bindingSource.Current as DataRowView)["LABREPAIRSALCODE"] = comboBoxLABREPAIRSALCODE.SelectedValue != null ? comboBoxLABREPAIRSALCODE.SelectedValue.ToString() : "";
                (U_SYS4bindingSource.Current as DataRowView)["LJOBPER1"] = (textBoxLJOBPER1.Text.Trim().Length > 0) ? textBoxLJOBPER1.Text : "0";
                (U_SYS4bindingSource.Current as DataRowView)["LJOBPER"] = (textBoxLJOBPER.Text.Trim().Length > 0) ? textBoxLJOBPER.Text : "0";
                (U_SYS4bindingSource.Current as DataRowView)["RETIRERATE1"] = (textBoxRETIRERATE1.Text.Trim().Length > 0) ? textBoxRETIRERATE1.Text : "0";
                (U_SYS4bindingSource.Current as DataRowView)["RETIRERATE"] = (textBoxRETIRERATE.Text.Trim().Length > 0) ? textBoxRETIRERATE.Text : "0";
                (U_SYS4bindingSource.Current as DataRowView)["NRETIRERATE1"] = (textBoxNRETIRERATE1.Text.Trim().Length > 0) ? textBoxNRETIRERATE1.Text : "0";
                (U_SYS4bindingSource.Current as DataRowView)["NRETIRERATE"] = (textBoxNRETIRERATE.Text.Trim().Length > 0) ? textBoxNRETIRERATE.Text : "0";
                (U_SYS4bindingSource.Current as DataRowView)["RETSALCODE"] = comboBoxRETSALCODE.SelectedValue != null ? comboBoxRETSALCODE.SelectedValue.ToString() : "";

                //U_SYS5 資料寫回
                (U_SYS5bindingSource.Current as DataRowView)["COMP"] = MainForm.COMPANY;
                (U_SYS5bindingSource.Current as DataRowView)["HSALCODE"] = comboBoxHSALCODE.SelectedValue != null ? comboBoxHSALCODE.SelectedValue.ToString() : "";
                (U_SYS5bindingSource.Current as DataRowView)["HEALTHOVERSALCODE"] = comboBoxHEALTHOVERSALCODE.SelectedValue != null ? comboBoxHEALTHOVERSALCODE.SelectedValue.ToString() : "";
                (U_SYS5bindingSource.Current as DataRowView)["HEALTHREPAIRSALCODE"] = comboBoxHEALTHREPAIRSALCODE.SelectedValue != null ? comboBoxHEALTHREPAIRSALCODE.SelectedValue.ToString() : "";
                (U_SYS5bindingSource.Current as DataRowView)["EMPFAMILYCNT"] = (textBoxEMPFAMILYCNT.Text.Trim().Length > 0) ? textBoxEMPFAMILYCNT.Text : "0";
                (U_SYS5bindingSource.Current as DataRowView)["COMPERSONCNT"] = (textBoxCOMPERSONCNT.Text.Trim().Length > 0) ? textBoxCOMPERSONCNT.Text : "0";
                (U_SYS5bindingSource.Current as DataRowView)["HEACOMPRATE"] = (textBoxHEACOMPRATE.Text.Trim().Length > 0) ? textBoxHEACOMPRATE.Text : "0";
                #region 二代健保補充保費
                (U_SYS5bindingSource.Current as DataRowView)["SUPPLEHINSLABSALCODE"] = comboBoxSUPPLEHINSLABSALCODE.SelectedValue.ToString();//補充保費
                (U_SYS5bindingSource.Current as DataRowView)["SUPPLEINSLABRATE"] = (textBoxSUPPLEINSLABRATE.Text.Trim().Length > 0) ? textBoxSUPPLEINSLABRATE.Text : "0";//補充保費
                (U_SYS5bindingSource.Current as DataRowView)["BONUSYEARRATEMAX"] = (textBoxBONUSYEARRATEMAX.Text.Trim().Length > 0) ? textBoxBONUSYEARRATEMAX.Text : "0";//補充保費 
                #endregion

                //U_SYS6 資料寫回
                (U_SYS6bindingSource.Current as DataRowView)["COMP"] = MainForm.COMPANY;
                (U_SYS6bindingSource.Current as DataRowView)["GROUPSALCD"] = comboBoxGROUPSALCD.SelectedValue != null ? comboBoxGROUPSALCD.SelectedValue.ToString() : "";
                (U_SYS6bindingSource.Current as DataRowView)["GROUPEXP1"] = (textBoxGROUPEXP1.Text.Trim().Length > 0) ? textBoxGROUPEXP1.Text : "0";
                (U_SYS6bindingSource.Current as DataRowView)["GROUPEXP2"] = (textBoxGROUPEXP2.Text.Trim().Length > 0) ? textBoxGROUPEXP2.Text : "0";
                (U_SYS6bindingSource.Current as DataRowView)["GROUPEXP51"] = (textBoxGROUPEXP51.Text.Trim().Length > 0) ? textBoxGROUPEXP51.Text : "0";
                (U_SYS6bindingSource.Current as DataRowView)["GROUPEXP52"] = (textBoxGROUPEXP52.Text.Trim().Length > 0) ? textBoxGROUPEXP52.Text : "0";

                //U_SYS8 資料寫回
                //志興增加第五組資料欄位我來做寫入的程式20100816 by Ming
                (U_SYS8bindingSource.Current as DataRowView)["COMP"] = MainForm.COMPANY;
                (U_SYS8bindingSource.Current as DataRowView)["YEAR11"] = (textBoxYEAR11.Text.Trim().Length > 0) ? textBoxYEAR11.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["YEAR12"] = (textBoxYEAR12.Text.Trim().Length > 0) ? textBoxYEAR12.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["VACATIONDAYS01"] = (textBoxVACATIONDAYS01.Text.Trim().Length > 0) ? textBoxVACATIONDAYS01.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["YEAR21"] = (textBoxYEAR21.Text.Trim().Length > 0) ? textBoxYEAR21.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["YEAR22"] = (textBoxYEAR22.Text.Trim().Length > 0) ? textBoxYEAR22.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["VACATIONDAYS02"] = (textBoxVACATIONDAYS02.Text.Trim().Length > 0) ? textBoxVACATIONDAYS02.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["YEAR31"] = (textBoxYEAR31.Text.Trim().Length > 0) ? textBoxYEAR31.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["YEAR32"] = (textBoxYEAR32.Text.Trim().Length > 0) ? textBoxYEAR32.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["VACATIONDAYS03"] = (textBoxVACATIONDAYS03.Text.Trim().Length > 0) ? textBoxVACATIONDAYS03.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["YEAR41"] = (textBoxYEAR41.Text.Trim().Length > 0) ? textBoxYEAR41.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["YEAR42"] = (textBoxYEAR42.Text.Trim().Length > 0) ? textBoxYEAR42.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["VACATIONDAYS04"] = (textBoxVACATIONDAYS04.Text.Trim().Length > 0) ? textBoxVACATIONDAYS04.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["YEAR51"] = (textBoxYEAR51.Text.Trim().Length > 0) ? textBoxYEAR51.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["YEAR52"] = (textBoxYEAR52.Text.Trim().Length > 0) ? textBoxYEAR52.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["VACATIONDAYS05"] = (textBoxVACATIONDAYS05.Text.Trim().Length > 0) ? textBoxVACATIONDAYS05.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["YEAR61"] = (textBoxYEAR61.Text.Trim().Length > 0) ? textBoxYEAR61.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["NEXTYEARDAY"] = (textBoxNEXTYEARDAY.Text.Trim().Length > 0) ? textBoxNEXTYEARDAY.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MAXDAYS"] = (textBoxMAXDAYS.Text.Trim().Length > 0) ? textBoxMAXDAYS.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["YEARBASE"] = (textBoxYEARBASE.Text.Trim().Length > 0) ? textBoxYEARBASE.Text : "0";

                (U_SYS8bindingSource.Current as DataRowView)["YEAR01"] = (textBoxYEAR01.Text.Trim().Length > 0) ? textBoxYEAR01.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH01DAY1"] = (textBoxMONTH01DAY1.Text.Trim().Length > 0) ? textBoxMONTH01DAY1.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH02DAY1"] = (textBoxMONTH02DAY1.Text.Trim().Length > 0) ? textBoxMONTH02DAY1.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH03DAY1"] = (textBoxMONTH03DAY1.Text.Trim().Length > 0) ? textBoxMONTH03DAY1.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH04DAY1"] = (textBoxMONTH04DAY1.Text.Trim().Length > 0) ? textBoxMONTH04DAY1.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH05DAY1"] = (textBoxMONTH05DAY1.Text.Trim().Length > 0) ? textBoxMONTH05DAY1.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH06DAY1"] = (textBoxMONTH06DAY1.Text.Trim().Length > 0) ? textBoxMONTH06DAY1.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH07DAY1"] = (textBoxMONTH07DAY1.Text.Trim().Length > 0) ? textBoxMONTH07DAY1.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH08DAY1"] = (textBoxMONTH08DAY1.Text.Trim().Length > 0) ? textBoxMONTH08DAY1.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH09DAY1"] = (textBoxMONTH09DAY1.Text.Trim().Length > 0) ? textBoxMONTH09DAY1.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH10DAY1"] = (textBoxMONTH10DAY1.Text.Trim().Length > 0) ? textBoxMONTH10DAY1.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH11DAY1"] = (textBoxMONTH11DAY1.Text.Trim().Length > 0) ? textBoxMONTH11DAY1.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH12DAY1"] = (textBoxMONTH12DAY1.Text.Trim().Length > 0) ? textBoxMONTH12DAY1.Text : "0";

                (U_SYS8bindingSource.Current as DataRowView)["YEAR02"] = (textBoxYEAR02.Text.Trim().Length > 0) ? textBoxYEAR02.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH01DAY2"] = (textBoxMONTH01DAY2.Text.Trim().Length > 0) ? textBoxMONTH01DAY2.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH02DAY2"] = (textBoxMONTH02DAY2.Text.Trim().Length > 0) ? textBoxMONTH02DAY2.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH03DAY2"] = (textBoxMONTH03DAY2.Text.Trim().Length > 0) ? textBoxMONTH03DAY2.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH04DAY2"] = (textBoxMONTH04DAY2.Text.Trim().Length > 0) ? textBoxMONTH04DAY2.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH05DAY2"] = (textBoxMONTH05DAY2.Text.Trim().Length > 0) ? textBoxMONTH05DAY2.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH06DAY2"] = (textBoxMONTH06DAY2.Text.Trim().Length > 0) ? textBoxMONTH06DAY2.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH07DAY2"] = (textBoxMONTH07DAY2.Text.Trim().Length > 0) ? textBoxMONTH07DAY2.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH08DAY2"] = (textBoxMONTH08DAY2.Text.Trim().Length > 0) ? textBoxMONTH08DAY2.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH09DAY2"] = (textBoxMONTH09DAY2.Text.Trim().Length > 0) ? textBoxMONTH09DAY2.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH10DAY2"] = (textBoxMONTH10DAY2.Text.Trim().Length > 0) ? textBoxMONTH10DAY2.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH11DAY2"] = (textBoxMONTH11DAY2.Text.Trim().Length > 0) ? textBoxMONTH11DAY2.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH12DAY2"] = (textBoxMONTH12DAY2.Text.Trim().Length > 0) ? textBoxMONTH12DAY2.Text : "0";

                (U_SYS8bindingSource.Current as DataRowView)["YEAR03"] = (textBoxYEAR03.Text.Trim().Length > 0) ? textBoxYEAR03.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH01DAY3"] = (textBoxMONTH01DAY3.Text.Trim().Length > 0) ? textBoxMONTH01DAY3.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH02DAY3"] = (textBoxMONTH02DAY3.Text.Trim().Length > 0) ? textBoxMONTH02DAY3.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH03DAY3"] = (textBoxMONTH03DAY3.Text.Trim().Length > 0) ? textBoxMONTH03DAY3.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH04DAY3"] = (textBoxMONTH04DAY3.Text.Trim().Length > 0) ? textBoxMONTH04DAY3.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH05DAY3"] = (textBoxMONTH05DAY3.Text.Trim().Length > 0) ? textBoxMONTH05DAY3.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH06DAY3"] = (textBoxMONTH06DAY3.Text.Trim().Length > 0) ? textBoxMONTH06DAY3.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH07DAY3"] = (textBoxMONTH07DAY3.Text.Trim().Length > 0) ? textBoxMONTH07DAY3.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH08DAY3"] = (textBoxMONTH08DAY3.Text.Trim().Length > 0) ? textBoxMONTH08DAY3.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH09DAY3"] = (textBoxMONTH09DAY3.Text.Trim().Length > 0) ? textBoxMONTH09DAY3.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH10DAY3"] = (textBoxMONTH10DAY3.Text.Trim().Length > 0) ? textBoxMONTH10DAY3.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH11DAY3"] = (textBoxMONTH11DAY3.Text.Trim().Length > 0) ? textBoxMONTH11DAY3.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH12DAY3"] = (textBoxMONTH12DAY3.Text.Trim().Length > 0) ? textBoxMONTH12DAY3.Text : "0";

                (U_SYS8bindingSource.Current as DataRowView)["YEAR04"] = (textBoxYEAR04.Text.Trim().Length > 0) ? textBoxYEAR04.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH01DAY4"] = (textBoxMONTH01DAY4.Text.Trim().Length > 0) ? textBoxMONTH01DAY4.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH02DAY4"] = (textBoxMONTH02DAY4.Text.Trim().Length > 0) ? textBoxMONTH02DAY4.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH03DAY4"] = (textBoxMONTH03DAY4.Text.Trim().Length > 0) ? textBoxMONTH03DAY4.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH04DAY4"] = (textBoxMONTH04DAY4.Text.Trim().Length > 0) ? textBoxMONTH04DAY4.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH05DAY4"] = (textBoxMONTH05DAY4.Text.Trim().Length > 0) ? textBoxMONTH05DAY4.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH06DAY4"] = (textBoxMONTH06DAY4.Text.Trim().Length > 0) ? textBoxMONTH06DAY4.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH07DAY4"] = (textBoxMONTH07DAY4.Text.Trim().Length > 0) ? textBoxMONTH07DAY4.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH08DAY4"] = (textBoxMONTH08DAY4.Text.Trim().Length > 0) ? textBoxMONTH08DAY4.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH09DAY4"] = (textBoxMONTH09DAY4.Text.Trim().Length > 0) ? textBoxMONTH09DAY4.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH10DAY4"] = (textBoxMONTH10DAY4.Text.Trim().Length > 0) ? textBoxMONTH10DAY4.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH11DAY4"] = (textBoxMONTH11DAY4.Text.Trim().Length > 0) ? textBoxMONTH11DAY4.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH12DAY4"] = (textBoxMONTH12DAY4.Text.Trim().Length > 0) ? textBoxMONTH12DAY4.Text : "0";

                (U_SYS8bindingSource.Current as DataRowView)["YEAR05"] = (textBoxYEAR05.Text.Trim().Length > 0) ? textBoxYEAR05.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH01DAY5"] = (textBoxMONTH01DAY5.Text.Trim().Length > 0) ? textBoxMONTH01DAY5.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH02DAY5"] = (textBoxMONTH02DAY5.Text.Trim().Length > 0) ? textBoxMONTH02DAY5.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH03DAY5"] = (textBoxMONTH03DAY5.Text.Trim().Length > 0) ? textBoxMONTH03DAY5.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH04DAY5"] = (textBoxMONTH04DAY5.Text.Trim().Length > 0) ? textBoxMONTH04DAY5.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH05DAY5"] = (textBoxMONTH05DAY5.Text.Trim().Length > 0) ? textBoxMONTH05DAY5.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH06DAY5"] = (textBoxMONTH06DAY5.Text.Trim().Length > 0) ? textBoxMONTH06DAY5.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH07DAY5"] = (textBoxMONTH07DAY5.Text.Trim().Length > 0) ? textBoxMONTH07DAY5.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH08DAY5"] = (textBoxMONTH08DAY5.Text.Trim().Length > 0) ? textBoxMONTH08DAY5.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH09DAY5"] = (textBoxMONTH09DAY5.Text.Trim().Length > 0) ? textBoxMONTH09DAY5.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH10DAY5"] = (textBoxMONTH10DAY5.Text.Trim().Length > 0) ? textBoxMONTH10DAY5.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH11DAY5"] = (textBoxMONTH11DAY5.Text.Trim().Length > 0) ? textBoxMONTH11DAY5.Text : "0";
                (U_SYS8bindingSource.Current as DataRowView)["MONTH12DAY5"] = (textBoxMONTH12DAY5.Text.Trim().Length > 0) ? textBoxMONTH12DAY5.Text : "0";

                if (rbnSPECIALCALTYPE1.Checked) (U_SYS8bindingSource.Current as DataRowView)["SPECIALCALTYPE"] = 1;
                else (U_SYS8bindingSource.Current as DataRowView)["SPECIALCALTYPE"] = 2;

                if (rbnYEAR0TYPE11.Checked) (U_SYS8bindingSource.Current as DataRowView)["YEAR0TYPE1"] = 1;
                else (U_SYS8bindingSource.Current as DataRowView)["YEAR0TYPE1"] = 2;

                if (rbnYEAR0TYPE21.Checked) (U_SYS8bindingSource.Current as DataRowView)["YEAR0TYPE2"] = 1;
                else (U_SYS8bindingSource.Current as DataRowView)["YEAR0TYPE2"] = 2;

                if (rbnYEAR0TYPE31.Checked) (U_SYS8bindingSource.Current as DataRowView)["YEAR0TYPE3"] = 1;
                else (U_SYS8bindingSource.Current as DataRowView)["YEAR0TYPE3"] = 2;

                if (rbnYEAR0TYPE41.Checked) (U_SYS8bindingSource.Current as DataRowView)["YEAR0TYPE4"] = 1;
                else (U_SYS8bindingSource.Current as DataRowView)["YEAR0TYPE4"] = 2;

                if (rbnYEAR0TYPE51.Checked) (U_SYS8bindingSource.Current as DataRowView)["YEAR0TYPE5"] = 1;
                else (U_SYS8bindingSource.Current as DataRowView)["YEAR0TYPE5"] = 2;

                if (rbnYEAR0EFFTYPE11.Checked) (U_SYS8bindingSource.Current as DataRowView)["YEAR0EFFTYPE1"] = 1;
                else (U_SYS8bindingSource.Current as DataRowView)["YEAR0EFFTYPE1"] = 2;

                if (rbnYEAR0EFFTYPE21.Checked) (U_SYS8bindingSource.Current as DataRowView)["YEAR0EFFTYPE2"] = 1;
                else (U_SYS8bindingSource.Current as DataRowView)["YEAR0EFFTYPE2"] = 2;

                if (rbnYEAR0EFFTYPE31.Checked) (U_SYS8bindingSource.Current as DataRowView)["YEAR0EFFTYPE3"] = 1;
                else (U_SYS8bindingSource.Current as DataRowView)["YEAR0EFFTYPE3"] = 2;

                if (rbnYEAR0EFFTYPE41.Checked) (U_SYS8bindingSource.Current as DataRowView)["YEAR0EFFTYPE4"] = 1;
                else (U_SYS8bindingSource.Current as DataRowView)["YEAR0EFFTYPE4"] = 2;

                if (rbnYEAR0EFFTYPE51.Checked) (U_SYS8bindingSource.Current as DataRowView)["YEAR0EFFTYPE5"] = 1;
                else (U_SYS8bindingSource.Current as DataRowView)["YEAR0EFFTYPE5"] = 2;

                //U_SYS9 資料寫回
                (U_SYS9bindingSource.Current as DataRowView)["COMP"] = MainForm.COMPANY;
                (U_SYS9bindingSource.Current as DataRowView)["STDEDUETAMTNMAR"] = (textBoxSTDEDUETAMTNMAR.Text.Trim().Length > 0) ? textBoxSTDEDUETAMTNMAR.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["STDEDUETAMTMAR"] = (textBoxSTDEDUETAMTMAR.Text.Trim().Length > 0) ? textBoxSTDEDUETAMTMAR.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["TAXFREE70DOWN"] = (textBoxTAXFREE70DOWN.Text.Trim().Length > 0) ? textBoxTAXFREE70DOWN.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["TAXFREE70UP"] = (textBoxTAXFREE70UP.Text.Trim().Length > 0) ? textBoxTAXFREE70UP.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["SALARYDEDUTAMT"] = (textBoxSALARYDEDUTAMT.Text.Trim().Length > 0) ? textBoxSALARYDEDUTAMT.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["TAXSALCODE"] = comboBoxTAXSALCODE.SelectedValue != null ? comboBoxTAXSALCODE.SelectedValue.ToString() : "";
                (U_SYS9bindingSource.Current as DataRowView)["TAXAMTAMONTH"] = (textBoxTAXAMTAMONTH.Text.Trim().Length > 0) ? textBoxTAXAMTAMONTH.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["FIXTAXRATE"] = (textBoxFIXTAXRATE.Text.Trim().Length > 0) ? textBoxFIXTAXRATE.Text : "0";

                (U_SYS9bindingSource.Current as DataRowView)["NETTAXAMT01"] = (textBoxNETTAXAMT01.Text.Trim().Length > 0) ? textBoxNETTAXAMT01.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["NETTAXAMT02"] = (textBoxNETTAXAMT02.Text.Trim().Length > 0) ? textBoxNETTAXAMT02.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["NETTAXRATE01"] = (textBoxNETTAXRATE01.Text.Trim().Length > 0) ? textBoxNETTAXRATE01.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["ADDUPAMT01"] = (textBoxADDUPAMT01.Text.Trim().Length > 0) ? textBoxADDUPAMT01.Text : "0";

                (U_SYS9bindingSource.Current as DataRowView)["NETTAXAMT03"] = (textBoxNETTAXAMT03.Text.Trim().Length > 0) ? textBoxNETTAXAMT03.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["NETTAXAMT04"] = (textBoxNETTAXAMT04.Text.Trim().Length > 0) ? textBoxNETTAXAMT04.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["NETTAXRATE02"] = (textBoxNETTAXRATE02.Text.Trim().Length > 0) ? textBoxNETTAXRATE02.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["ADDUPAMT02"] = (textBoxADDUPAMT02.Text.Trim().Length > 0) ? textBoxADDUPAMT02.Text : "0";

                (U_SYS9bindingSource.Current as DataRowView)["NETTAXAMT05"] = (textBoxNETTAXAMT05.Text.Trim().Length > 0) ? textBoxNETTAXAMT05.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["NETTAXAMT06"] = (textBoxNETTAXAMT06.Text.Trim().Length > 0) ? textBoxNETTAXAMT06.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["NETTAXRATE03"] = (textBoxNETTAXRATE03.Text.Trim().Length > 0) ? textBoxNETTAXRATE03.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["ADDUPAMT03"] = (textBoxADDUPAMT03.Text.Trim().Length > 0) ? textBoxADDUPAMT03.Text : "0";

                (U_SYS9bindingSource.Current as DataRowView)["NETTAXAMT07"] = (textBoxNETTAXAMT07.Text.Trim().Length > 0) ? textBoxNETTAXAMT07.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["NETTAXAMT08"] = (textBoxNETTAXAMT08.Text.Trim().Length > 0) ? textBoxNETTAXAMT08.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["NETTAXRATE04"] = (textBoxNETTAXRATE04.Text.Trim().Length > 0) ? textBoxNETTAXRATE04.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["ADDUPAMT04"] = (textBoxADDUPAMT04.Text.Trim().Length > 0) ? textBoxADDUPAMT04.Text : "0";

                (U_SYS9bindingSource.Current as DataRowView)["NETTAXAMT09"] = (textBoxNETTAXAMT09.Text.Trim().Length > 0) ? textBoxNETTAXAMT09.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["NETTAXAMT10"] = (textBoxNETTAXAMT10.Text.Trim().Length > 0) ? textBoxNETTAXAMT10.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["NETTAXRATE05"] = (textBoxNETTAXRATE05.Text.Trim().Length > 0) ? textBoxNETTAXRATE05.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["ADDUPAMT05"] = (textBoxADDUPAMT05.Text.Trim().Length > 0) ? textBoxADDUPAMT05.Text : "0";

                (U_SYS9bindingSource.Current as DataRowView)["FORSALBASD"] = (textBoxFORSALBASD.Text.Trim().Length > 0) ? textBoxFORSALBASD.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["FORTAXRATE03"] = (textBoxFORTAXRATE03.Text.Trim().Length > 0) ? textBoxFORTAXRATE03.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["ENTRYDAY"] = (textBoxENTRYDAY.Text.Trim().Length > 0) ? textBoxENTRYDAY.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["FORTAXRATE01"] = (textBoxFORTAXRATE01.Text.Trim().Length > 0) ? textBoxFORTAXRATE01.Text : "0";
                (U_SYS9bindingSource.Current as DataRowView)["FORTAXRATE02"] = (textBoxFORTAXRATE02.Text.Trim().Length > 0) ? textBoxFORTAXRATE02.Text : "0";

                if (rbnTAXTYPE1.Checked) (U_SYS9bindingSource.Current as DataRowView)["TAXTYPE"] = 1;
                else (U_SYS9bindingSource.Current as DataRowView)["TAXTYPE"] = 2;

                (U_SYS10bindingSource.Current as DataRowView)["COMP"] = MainForm.COMPANY;
                (U_SYS10bindingSource.Current as DataRowView)["SMTPSERVER"] = textBoxSMTPSERVER.Text;
                (U_SYS10bindingSource.Current as DataRowView)["SENDMAIL"] = textBoxSENDMAIL.Text;
                (U_SYS10bindingSource.Current as DataRowView)["SMTPID"] = textBoxSMTPID.Text;
                (U_SYS10bindingSource.Current as DataRowView)["SMTPPW"] = textBoxSMTPPW.Text;

                (U_SYS1bindingSource.Current as DataRowView).EndEdit();
                (U_SYS2bindingSource.Current as DataRowView).EndEdit();
                (U_SYS3bindingSource.Current as DataRowView).EndEdit();
                (U_SYS4bindingSource.Current as DataRowView).EndEdit();
                (U_SYS5bindingSource.Current as DataRowView).EndEdit();
                (U_SYS6bindingSource.Current as DataRowView).EndEdit();
                (U_SYS8bindingSource.Current as DataRowView).EndEdit();
                (U_SYS9bindingSource.Current as DataRowView).EndEdit();
                (U_SYS10bindingSource.Current as DataRowView).EndEdit();

                u_SYS1TableAdapter.Update(this.sysDS.U_SYS1);
                u_SYS2TableAdapter.Update(this.sysDS.U_SYS2);
                u_SYS3TableAdapter.Update(this.sysDS.U_SYS3);
                u_SYS4TableAdapter.Update(this.sysDS.U_SYS4);
                u_SYS5TableAdapter.Update(this.sysDS.U_SYS5);
                u_SYS6TableAdapter.Update(this.sysDS.U_SYS6);
                u_SYS8TableAdapter.Update(this.sysDS.U_SYS8);
                u_SYS9TableAdapter.Update(this.sysDS.U_SYS9);
                u_SYS10TableAdapter.Update(this.sysDS.U_SYS10);
                MainForm.SetSysConfig(MainForm.COMPANY);
                MessageBox.Show(Resources.All.SaveComplete, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rbnSPECIALCALTYPE1_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbnSPECIALCALTYPE1.Checked)
            //{
            //    this.u_SYS8TableAdapter.FillByAUTO(this.sysDS.U_SYS8, 1);
            //}
            //else if (rbnSPECIALCALTYPE2.Checked)
            //{
            //    this.u_SYS8TableAdapter.FillByAUTO(this.sysDS.U_SYS8, 2);
            //}
            //U_SYS8Binding();
        }
        void U_SYS8Binding()
        {
            if (this.sysDS.U_SYS8.Count > 0)
            {
                if (!this.sysDS.U_SYS8[0].IsYEAR11Null()) textBoxYEAR11.Text = this.sysDS.U_SYS8[0].YEAR11.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR12Null()) textBoxYEAR12.Text = this.sysDS.U_SYS8[0].YEAR12.ToString();
                if (!this.sysDS.U_SYS8[0].IsVACATIONDAYS01Null()) textBoxVACATIONDAYS01.Text = this.sysDS.U_SYS8[0].VACATIONDAYS01.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR21Null()) textBoxYEAR21.Text = this.sysDS.U_SYS8[0].YEAR21.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR22Null()) textBoxYEAR22.Text = this.sysDS.U_SYS8[0].YEAR22.ToString();
                if (!this.sysDS.U_SYS8[0].IsVACATIONDAYS02Null()) textBoxVACATIONDAYS02.Text = this.sysDS.U_SYS8[0].VACATIONDAYS02.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR31Null()) textBoxYEAR31.Text = this.sysDS.U_SYS8[0].YEAR31.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR32Null()) textBoxYEAR32.Text = this.sysDS.U_SYS8[0].YEAR32.ToString();
                if (!this.sysDS.U_SYS8[0].IsVACATIONDAYS03Null()) textBoxVACATIONDAYS03.Text = this.sysDS.U_SYS8[0].VACATIONDAYS03.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR41Null()) textBoxYEAR41.Text = this.sysDS.U_SYS8[0].YEAR41.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR42Null()) textBoxYEAR42.Text = this.sysDS.U_SYS8[0].YEAR42.ToString();
                if (!this.sysDS.U_SYS8[0].IsVACATIONDAYS04Null()) textBoxVACATIONDAYS04.Text = this.sysDS.U_SYS8[0].VACATIONDAYS04.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR51Null()) textBoxYEAR51.Text = this.sysDS.U_SYS8[0].YEAR51.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR52Null()) textBoxYEAR52.Text = this.sysDS.U_SYS8[0].YEAR52.ToString();
                if (!this.sysDS.U_SYS8[0].IsVACATIONDAYS05Null()) textBoxVACATIONDAYS05.Text = this.sysDS.U_SYS8[0].VACATIONDAYS05.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEAR61Null()) textBoxYEAR61.Text = this.sysDS.U_SYS8[0].YEAR61.ToString();
                if (!this.sysDS.U_SYS8[0].IsNEXTYEARDAYNull()) textBoxNEXTYEARDAY.Text = this.sysDS.U_SYS8[0].NEXTYEARDAY.ToString();
                if (!this.sysDS.U_SYS8[0].IsMAXDAYSNull()) textBoxMAXDAYS.Text = this.sysDS.U_SYS8[0].MAXDAYS.ToString();
                if (!this.sysDS.U_SYS8[0].IsYEARBASENull()) textBoxYEARBASE.Text = this.sysDS.U_SYS8[0].YEARBASE.ToString();

                if (!this.sysDS.U_SYS8[0].IsYEAR01Null()) textBoxYEAR01.Text = this.sysDS.U_SYS8[0].YEAR01.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH01DAY1Null()) textBoxMONTH01DAY1.Text = this.sysDS.U_SYS8[0].MONTH01DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH02DAY1Null()) textBoxMONTH02DAY1.Text = this.sysDS.U_SYS8[0].MONTH02DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH03DAY1Null()) textBoxMONTH03DAY1.Text = this.sysDS.U_SYS8[0].MONTH03DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH04DAY1Null()) textBoxMONTH04DAY1.Text = this.sysDS.U_SYS8[0].MONTH04DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH05DAY1Null()) textBoxMONTH05DAY1.Text = this.sysDS.U_SYS8[0].MONTH05DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH06DAY1Null()) textBoxMONTH06DAY1.Text = this.sysDS.U_SYS8[0].MONTH06DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH07DAY1Null()) textBoxMONTH07DAY1.Text = this.sysDS.U_SYS8[0].MONTH07DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH08DAY1Null()) textBoxMONTH08DAY1.Text = this.sysDS.U_SYS8[0].MONTH08DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH09DAY1Null()) textBoxMONTH09DAY1.Text = this.sysDS.U_SYS8[0].MONTH09DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH10DAY1Null()) textBoxMONTH10DAY1.Text = this.sysDS.U_SYS8[0].MONTH10DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH11DAY1Null()) textBoxMONTH11DAY1.Text = this.sysDS.U_SYS8[0].MONTH11DAY1.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH12DAY1Null()) textBoxMONTH12DAY1.Text = this.sysDS.U_SYS8[0].MONTH12DAY1.ToString();

                if (!this.sysDS.U_SYS8[0].IsYEAR02Null()) textBoxYEAR02.Text = this.sysDS.U_SYS8[0].YEAR02.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH01DAY2Null()) textBoxMONTH01DAY2.Text = this.sysDS.U_SYS8[0].MONTH01DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH02DAY2Null()) textBoxMONTH02DAY2.Text = this.sysDS.U_SYS8[0].MONTH02DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH03DAY2Null()) textBoxMONTH03DAY2.Text = this.sysDS.U_SYS8[0].MONTH03DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH04DAY2Null()) textBoxMONTH04DAY2.Text = this.sysDS.U_SYS8[0].MONTH04DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH05DAY2Null()) textBoxMONTH05DAY2.Text = this.sysDS.U_SYS8[0].MONTH05DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH06DAY2Null()) textBoxMONTH06DAY2.Text = this.sysDS.U_SYS8[0].MONTH06DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH07DAY2Null()) textBoxMONTH07DAY2.Text = this.sysDS.U_SYS8[0].MONTH07DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH08DAY2Null()) textBoxMONTH08DAY2.Text = this.sysDS.U_SYS8[0].MONTH08DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH09DAY2Null()) textBoxMONTH09DAY2.Text = this.sysDS.U_SYS8[0].MONTH09DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH10DAY2Null()) textBoxMONTH10DAY2.Text = this.sysDS.U_SYS8[0].MONTH10DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH11DAY2Null()) textBoxMONTH11DAY2.Text = this.sysDS.U_SYS8[0].MONTH11DAY2.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH12DAY2Null()) textBoxMONTH12DAY2.Text = this.sysDS.U_SYS8[0].MONTH12DAY2.ToString();

                if (!this.sysDS.U_SYS8[0].IsYEAR03Null()) textBoxYEAR03.Text = this.sysDS.U_SYS8[0].YEAR03.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH01DAY3Null()) textBoxMONTH01DAY3.Text = this.sysDS.U_SYS8[0].MONTH01DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH02DAY3Null()) textBoxMONTH02DAY3.Text = this.sysDS.U_SYS8[0].MONTH02DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH03DAY3Null()) textBoxMONTH03DAY3.Text = this.sysDS.U_SYS8[0].MONTH03DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH04DAY3Null()) textBoxMONTH04DAY3.Text = this.sysDS.U_SYS8[0].MONTH04DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH05DAY3Null()) textBoxMONTH05DAY3.Text = this.sysDS.U_SYS8[0].MONTH05DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH06DAY3Null()) textBoxMONTH06DAY3.Text = this.sysDS.U_SYS8[0].MONTH06DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH07DAY3Null()) textBoxMONTH07DAY3.Text = this.sysDS.U_SYS8[0].MONTH07DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH08DAY3Null()) textBoxMONTH08DAY3.Text = this.sysDS.U_SYS8[0].MONTH08DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH09DAY3Null()) textBoxMONTH09DAY3.Text = this.sysDS.U_SYS8[0].MONTH09DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH10DAY3Null()) textBoxMONTH10DAY3.Text = this.sysDS.U_SYS8[0].MONTH10DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH11DAY3Null()) textBoxMONTH11DAY3.Text = this.sysDS.U_SYS8[0].MONTH11DAY3.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH12DAY3Null()) textBoxMONTH12DAY3.Text = this.sysDS.U_SYS8[0].MONTH12DAY3.ToString();

                if (!this.sysDS.U_SYS8[0].IsYEAR04Null()) textBoxYEAR04.Text = this.sysDS.U_SYS8[0].YEAR04.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH01DAY4Null()) textBoxMONTH01DAY4.Text = this.sysDS.U_SYS8[0].MONTH01DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH02DAY4Null()) textBoxMONTH02DAY4.Text = this.sysDS.U_SYS8[0].MONTH02DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH03DAY4Null()) textBoxMONTH03DAY4.Text = this.sysDS.U_SYS8[0].MONTH03DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH04DAY4Null()) textBoxMONTH04DAY4.Text = this.sysDS.U_SYS8[0].MONTH04DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH05DAY4Null()) textBoxMONTH05DAY4.Text = this.sysDS.U_SYS8[0].MONTH05DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH06DAY4Null()) textBoxMONTH06DAY4.Text = this.sysDS.U_SYS8[0].MONTH06DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH07DAY4Null()) textBoxMONTH07DAY4.Text = this.sysDS.U_SYS8[0].MONTH07DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH08DAY4Null()) textBoxMONTH08DAY4.Text = this.sysDS.U_SYS8[0].MONTH08DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH09DAY4Null()) textBoxMONTH09DAY4.Text = this.sysDS.U_SYS8[0].MONTH09DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH10DAY4Null()) textBoxMONTH10DAY4.Text = this.sysDS.U_SYS8[0].MONTH10DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH11DAY4Null()) textBoxMONTH11DAY4.Text = this.sysDS.U_SYS8[0].MONTH11DAY4.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH12DAY4Null()) textBoxMONTH12DAY4.Text = this.sysDS.U_SYS8[0].MONTH12DAY4.ToString();

                if (!this.sysDS.U_SYS8[0].IsYEAR05Null()) textBoxYEAR05.Text = this.sysDS.U_SYS8[0].YEAR05.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH01DAY5Null()) textBoxMONTH01DAY5.Text = this.sysDS.U_SYS8[0].MONTH01DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH02DAY5Null()) textBoxMONTH02DAY5.Text = this.sysDS.U_SYS8[0].MONTH02DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH03DAY5Null()) textBoxMONTH03DAY5.Text = this.sysDS.U_SYS8[0].MONTH03DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH04DAY5Null()) textBoxMONTH04DAY5.Text = this.sysDS.U_SYS8[0].MONTH04DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH05DAY5Null()) textBoxMONTH05DAY5.Text = this.sysDS.U_SYS8[0].MONTH05DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH06DAY5Null()) textBoxMONTH06DAY5.Text = this.sysDS.U_SYS8[0].MONTH06DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH07DAY5Null()) textBoxMONTH07DAY5.Text = this.sysDS.U_SYS8[0].MONTH07DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH08DAY5Null()) textBoxMONTH08DAY5.Text = this.sysDS.U_SYS8[0].MONTH08DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH09DAY5Null()) textBoxMONTH09DAY5.Text = this.sysDS.U_SYS8[0].MONTH09DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH10DAY5Null()) textBoxMONTH10DAY5.Text = this.sysDS.U_SYS8[0].MONTH10DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH11DAY5Null()) textBoxMONTH11DAY5.Text = this.sysDS.U_SYS8[0].MONTH11DAY5.ToString();
                if (!this.sysDS.U_SYS8[0].IsMONTH12DAY5Null()) textBoxMONTH12DAY5.Text = this.sysDS.U_SYS8[0].MONTH12DAY5.ToString();

                //if (!sysDS.U_SYS8[0].IsNull("SPECIALCALTYPE"))
                //{
                //    if (sysDS.U_SYS8[0].SPECIALCALTYPE == 1) rbnSPECIALCALTYPE1.Checked = true;
                //    else rbnSPECIALCALTYPE2.Checked = true;
                //}

                if (!sysDS.U_SYS8[0].IsNull("YEAR0TYPE1"))
                {
                    if (sysDS.U_SYS8[0].YEAR0TYPE1 == 1) rbnYEAR0TYPE11.Checked = true;
                    else rbnYEAR0TYPE12.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0TYPE2"))
                {
                    if (sysDS.U_SYS8[0].YEAR0TYPE2 == 1) rbnYEAR0TYPE21.Checked = true;
                    else rbnYEAR0TYPE22.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0TYPE3"))
                {
                    if (sysDS.U_SYS8[0].YEAR0TYPE3 == 1) rbnYEAR0TYPE31.Checked = true;
                    else rbnYEAR0TYPE32.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0TYPE4"))
                {
                    if (sysDS.U_SYS8[0].YEAR0TYPE4 == 1) rbnYEAR0TYPE41.Checked = true;
                    else rbnYEAR0TYPE42.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0TYPE5"))
                {
                    if (sysDS.U_SYS8[0].YEAR0TYPE5 == 1) rbnYEAR0TYPE51.Checked = true;
                    else rbnYEAR0TYPE52.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0EFFTYPE1"))
                {
                    if (sysDS.U_SYS8[0].YEAR0EFFTYPE1 == 1) rbnYEAR0EFFTYPE11.Checked = true;
                    else rbnYEAR0EFFTYPE12.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0EFFTYPE2"))
                {
                    if (sysDS.U_SYS8[0].YEAR0EFFTYPE2 == 1) rbnYEAR0EFFTYPE21.Checked = true;
                    else rbnYEAR0EFFTYPE22.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0EFFTYPE3"))
                {
                    if (sysDS.U_SYS8[0].YEAR0EFFTYPE3 == 1) rbnYEAR0EFFTYPE31.Checked = true;
                    else rbnYEAR0EFFTYPE32.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0EFFTYPE4"))
                {
                    if (sysDS.U_SYS8[0].YEAR0EFFTYPE4 == 1) rbnYEAR0EFFTYPE41.Checked = true;
                    else rbnYEAR0EFFTYPE42.Checked = true;
                }

                if (!sysDS.U_SYS8[0].IsNull("YEAR0EFFTYPE5"))
                {
                    if (sysDS.U_SYS8[0].YEAR0EFFTYPE5 == 1) rbnYEAR0EFFTYPE51.Checked = true;
                    else rbnYEAR0EFFTYPE52.Checked = true;
                }
            }
        }
    }
}
