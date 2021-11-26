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
    public partial class FRM33 : JBControls.JBForm
    {
        public FRM33()
        {
            InitializeComponent();
        }
        CheckControl cc;//必要欄位檢察
        private void FRM39_Load(object sender, EventArgs e)//
        {
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbPAN);       //計畫                       
            cc.AddControl(cbGRP_TYPE);  //投保類別            
            #endregion

            this.iNSGRPTableAdapter.FillByInit(this.extDS.INSGRP);
            this.iNSGRLVTableAdapter.Fill(this.extDS.INSGRLV);

            this.v_BASETableAdapter.Fill(this.mainDS.V_BASE);
            //this.mTCODETableAdapter.FillByCategory(this.mainDS.MTCODE, "InsGType");
            //this.mTCODETableAdapter.FillByCategory(this.mainDS1.MTCODE, "InsGPlan");

            SystemFunction.SetComboBoxItems(cbPAN, CodeFunction.GetINSGRLV(), true, false, true);                //計畫
            SystemFunction.SetComboBoxItems(cbGRP_TYPE, CodeFunction.GetMtCode("InsGType"), true, false, true);  //投保類別

            fullDataCtrl1.DataAdapter = iNSGRPTableAdapter;
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("INSGRP");
            fullDataCtrl1.Init_Ctrls();
            Decrypt();
            txtDDate.Text = Sal.Function.GetDate();
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
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
            if (!Sal.Function.CanModify(e.Values["nobr"].ToString()))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!e.Cancel)
            {
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
                string amt1 = e.Values["amt1"].ToString();
                string amt2 = e.Values["amt2"].ToString();
                string amt3 = e.Values["amt3"].ToString();
                string amt4 = e.Values["amt4"].ToString();
                string amt5 = e.Values["amt5"].ToString();
                string amt6 = e.Values["amt6"].ToString();
                decimal a1 = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt1.Text));
                decimal a2 = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt2.Text));
                decimal a3 = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt3.Text));
                decimal a4 = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt4.Text));
                decimal a5 = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt5.Text));
                decimal a6 = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt_L.Text));
                txtAmt1.Text = a1.ToString();
                txtAmt2.Text = a2.ToString();
                txtAmt3.Text = a3.ToString();
                txtAmt4.Text = a4.ToString();
                txtAmt5.Text = a5.ToString();
                txtAmt_L.Text = a6.ToString();
                //e.Values["amt5"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt5.Text));
                //e.Values["amt6"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt_L.Text));
                //e.Values["amt1"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["amt1"]));
                //e.Values["amt2"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["amt2"]));
                //e.Values["amt3"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["amt3"]));
                //e.Values["amt4"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["amt4"]));
                //e.Values["amt5"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["amt5"]));
                //e.Values["amt6"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["amt6"]));
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
                string e1 = e.Values["amt1"].ToString();
                string e2 = e.Values["amt2"].ToString();
                string e3 = e.Values["amt3"].ToString();
                string e4 = e.Values["amt4"].ToString();
                e.Values["amt1"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt1"]));
                e.Values["amt2"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt2"]));
                e.Values["amt3"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt3"]));
                e.Values["amt4"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt4"]));
                e.Values["amt5"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt5"]));
                e.Values["amt6"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt6"]));
                this.extDS.INSGRP.AcceptChanges();
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            txtInDate.Text = Sal.Function.GetDate();
            txtOutDate.Text = Sal.Function.GetDate(DateTime.MaxValue.Date);
            SetDisabler();
        }
        void Decrypt()
        {
            foreach (var it in this.extDS.INSGRP)
            {
                it.AMT1 = JBModule.Data.CDecryp.Number(it.AMT1);
                it.AMT2 = JBModule.Data.CDecryp.Number(it.AMT2);
                it.AMT3 = JBModule.Data.CDecryp.Number(it.AMT3);
                it.AMT4 = JBModule.Data.CDecryp.Number(it.AMT4);
                it.AMT5 = JBModule.Data.CDecryp.Number(it.AMT5);
                it.AMT6 = JBModule.Data.CDecryp.Number(it.AMT6);
            }
            this.extDS.INSGRP.AcceptChanges();
        }

        void AutoExport()//自動產生資料
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var insgrlvData = from c in db.INSGRLV
                              select c;
            //txtInDate.Text = Sal.Function.GetDate();
            DateTime OutDate = DateTime.Parse(Sal.Function.GetDate(DateTime.MaxValue.Date)).Date;
            var sql = from a in db.SALBASD select new { a.AMT, a.NOBR, a.ADATE, a.DDATE };
            var sql2 = from a in db.INSLAB select a;
            DateTime inDate = Convert.ToDateTime(txtDDate.Text);
            //var inslabSQL = from a in db.INSLAB select a;
            foreach (var it in this.extDS.INSGRP)
            {

                if (inDate >= it.IN_DATE && inDate <= it.OUT_DATE)//20130527只針對在保人員
                {
                    var insgrlvSQL = from a in insgrlvData where a.PLAN_NO == it.PAN select a;
                    if (insgrlvSQL.Any())
                    {
                        var r = insgrlvSQL.First();
                        it.AMT1 = r.AMT;
                        it.AMT2 = r.ACCI_AMT;
                        it.AMT3 = r.EXP_AMT;
                        it.AMT4 = r.EXT_AMT;
                    }

                    #region 解密
                    Decimal aa1 = it.AMT1;
                    Decimal aa2 = it.AMT2;
                    Decimal aa3 = it.AMT3;
                    Decimal aa4 = it.AMT4;
                    Decimal aa5 = it.AMT5;
                    Decimal aa6 = it.AMT6;
                    #endregion
                    //it.OUT_DATE = OutDate;

                    #region SetExpExt 設定 定期壽險保額 意外保險保額 住院醫療 意外醫療 住院醫療員工負擔 住院醫療公司負擔 意外醫療員工負擔 意外醫療公司負擔
                    var insgrlv = from c in insgrlvData
                                  where c.PLAN_NO == it.PAN
                                  select c;
                    if (insgrlv.Any())
                    {
                        it.AMT1 = insgrlv.FirstOrDefault().AMT;     //定期壽險保額
                        it.AMT2 = insgrlv.FirstOrDefault().ACCI_AMT;//意外保險保額
                        it.AMT3 = insgrlv.FirstOrDefault().EXP_AMT; //住院醫療
                        it.AMT4 = insgrlv.FirstOrDefault().EXT_AMT; //意外醫療
                        if (cbGRP_TYPE.SelectedValue != null)
                        {

                            string grp_type = it.GRP_TYPE;
                            if (grp_type == "A")
                            {
                                it.EXP3 = insgrlv.FirstOrDefault().EXPA;     //住院醫療員工負擔
                                it.COP3 = insgrlv.FirstOrDefault().COM_EXPA; //住院醫療公司負擔
                                it.EXP4 = insgrlv.FirstOrDefault().EXTA;     //意外醫療員工負擔
                                it.COP4 = insgrlv.FirstOrDefault().COM_EXTA; //意外醫療公司負擔
                            }
                            else if (grp_type == "B")
                            {
                                it.EXP3 = insgrlv.FirstOrDefault().EXPB;     //住院醫療員工負擔
                                it.COP3 = insgrlv.FirstOrDefault().COM_EXPB; //住院醫療公司負擔
                                it.EXP4 = insgrlv.FirstOrDefault().EXTB;     //意外醫療員工負擔
                                it.COP4 = insgrlv.FirstOrDefault().COM_EXTB; //意外醫療公司負擔
                            }
                            else if (grp_type == "C")
                            {
                                it.EXP3 = insgrlv.FirstOrDefault().EXPC;     //住院醫療員工負擔
                                it.COP3 = insgrlv.FirstOrDefault().COM_EXPC; //住院醫療公司負擔
                                it.EXP4 = insgrlv.FirstOrDefault().EXTC;     //意外醫療員工負擔
                                it.COP4 = insgrlv.FirstOrDefault().COM_EXTC; //意外醫療公司負擔
                            }
                            else if (grp_type == "D")
                            {
                                it.EXP3 = insgrlv.FirstOrDefault().EXPD;     //住院醫療員工負擔
                                it.COP3 = insgrlv.FirstOrDefault().COM_EXPD; //住院醫療公司負擔
                                it.EXP4 = insgrlv.FirstOrDefault().EXTD;     //意外醫療員工負擔
                                it.COP4 = insgrlv.FirstOrDefault().COM_EXTD; //意外醫療公司負擔
                            }
                            else
                            {
                                //it.EXP3 = 0;
                                //it.COP3 = 0;
                                //it.EXP4 = 0;
                                //it.COP4 = 0;
                            }
                        }
                    }
                    else
                    {
                        //it.AMT1 = 0;
                        //it.AMT2 = 0;
                        //it.AMT3 = 0;
                        //it.AMT4 = 0;
                        //it.EXP3 = 0;
                        //it.COP3 = 0;
                        //it.EXP4 = 0;
                        //it.COP4 = 0;
                    }
                    #endregion

                    #region calc1 定期壽險公司負擔
                    //decimal amt1 = Convert.ToDecimal(txtAmt1.Text);
                    decimal val1 = Math.Round(it.AMT1 * MainForm.GroupInsConfig.GROUPEXP1.Value / 10000M, 4, MidpointRounding.AwayFromZero);
                    it.EXP1 = 0;
                    it.COP1 = val1;
                    #endregion

                    #region calc2 意外保險公司負擔

                    decimal val2 = Math.Round(it.AMT2 * MainForm.GroupInsConfig.GROUPEXP2.Value / 10000M, 4, MidpointRounding.AwayFromZero);

                    //txtComp2.Text = val.ToString();
                    it.EXP2 = 0;
                    it.COP2 = val2;
                    #endregion

                    #region calc4 職災 公司負擔

                    var salarySQL = from a in sql where a.NOBR == it.NOBR && inDate >= a.ADATE && inDate <= a.DDATE select a.AMT;
                    if (salarySQL.Any())
                    {
                        decimal salary = salarySQL.ToList().Sum(p => JBModule.Data.CDecryp.Number(p));
                        it.AMT5 = salary;
                    }
                    var inslabSQL = from a in sql2 where a.NOBR == it.NOBR && inDate >= a.IN_DATE && inDate <= a.OUT_DATE select a;
                    if (inslabSQL.Any())
                    {
                        it.AMT6 = JBModule.Data.CDecryp.Number(inslabSQL.First().L_AMT);
                    }
                    else
                    {
                        it.AMT6 = 0;
                    }

                    decimal exp1, exp2;
                    exp1 = it.AMT6 / 10000M * MainForm.GroupInsConfig.GROUPEXP51.Value;         //
                    it.COP6 = exp1;
                    if (it.AMT5 > it.AMT6)
                    {
                        exp2 = (it.AMT5 - it.AMT6) / 10000M * MainForm.GroupInsConfig.GROUPEXP52.Value;//若職災投保薪資超過勞保投保薪資 每一萬元負擔金額 
                        it.COP5 = exp2;
                    }
                    else
                    {
                        it.COP5 = 0;
                    }
                    #endregion
                    #region

                    decimal totExp = Math.Round((it.EXP1 + it.EXP2 + it.EXP3 + it.EXP4), MidpointRounding.AwayFromZero);
                    decimal totComp = Math.Round((it.COP1 + it.COP2 + it.COP3 + it.COP4 + it.COP5 + it.COP6), MidpointRounding.AwayFromZero);

                    it.TOTEXP = totExp;
                    it.COPEXP = totComp;
                    #endregion
                    #region
                    it.AMT1 = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(it.AMT1));
                    it.AMT2 = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(it.AMT2));
                    it.AMT3 = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(it.AMT3));
                    it.AMT4 = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(it.AMT4));
                    it.AMT5 = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(it.AMT5));
                    it.AMT6 = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(it.AMT6));
                    #endregion
                }
            }
            this.iNSGRPTableAdapter.Update(this.extDS.INSGRP);

        }
        void SetDisabler()
        {
            txtExp1.Enabled = false;
            txtExp2.Enabled = false;
            txtExp3.Enabled = false;
            txtExp4.Enabled = false;

            txtComp1.Enabled = false;
            txtComp2.Enabled = false;
            txtComp3.Enabled = false;
            txtComp4.Enabled = false;
            txtComp5.Enabled = false;
            txtComp6.Enabled = false;

            txtTotComp.Enabled = false;
            txtTotExp.Enabled = false;
        }
        private void btnFamily_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                FRM33T frm = new FRM33T();
                frm.Nobr = ptxNobr.Text;
                frm.Text = "FRM33T - 團保眷屬保險資料";
                frm.ShowDialog();
                SetGridView();
            }
        }
        void Calc()//求 員工負擔、工司負擔 總計
        {
            SetExpExt();////設定 定期壽險保額 意外保險保額 住院醫療 意外醫療 住院醫療員工負擔 住院醫療公司負擔 意外醫療員工負擔 意外醫療公司負擔

            calc1();//定期壽險公司負擔
            calc2();//意外保險公司負擔
            //calc3();
            calc4();
            //calc5();
            decimal exp1, exp2, exp3, exp4;
            decimal comp1, comp2, comp3, comp4, comp5, comp6;
            exp1 = Convert.ToDecimal(txtExp1.Text);
            exp2 = Convert.ToDecimal(txtExp2.Text);
            exp3 = Convert.ToDecimal(txtExp3.Text);
            exp4 = Convert.ToDecimal(txtExp4.Text);

            comp1 = Convert.ToDecimal(txtComp1.Text);
            comp2 = Convert.ToDecimal(txtComp2.Text);
            comp3 = Convert.ToDecimal(txtComp3.Text);
            comp4 = Convert.ToDecimal(txtComp4.Text);
            comp5 = Convert.ToDecimal(txtComp5.Text);
            comp6 = Convert.ToDecimal(txtComp6.Text);
            decimal totExp = Math.Round((exp1 + exp2 + exp3 + exp4), MidpointRounding.AwayFromZero);
            decimal totComp = Math.Round((comp1 + comp2 + comp3 + comp4 + comp5 + comp6), MidpointRounding.AwayFromZero);
            txtTotExp.Text = totExp.ToString();

            txtTotComp.Text = totComp.ToString();
        }
        void calc1()//定期壽險公司負擔
        {
            decimal amt1 = Convert.ToDecimal(txtAmt1.Text);
            decimal val = Math.Round(amt1 * MainForm.GroupInsConfig.GROUPEXP1.Value / 10000M, 4, MidpointRounding.AwayFromZero);
            txtExp1.Text = "0";
            txtComp1.Text = val.ToString();
        }
        void calc2()//意外保險公司負擔
        {
            decimal amt2 = Convert.ToDecimal(txtAmt2.Text);
            decimal val = Math.Round(amt2 * MainForm.GroupInsConfig.GROUPEXP2.Value / 10000M, 4, MidpointRounding.AwayFromZero);
            txtExp2.Text = "0";
            txtComp2.Text = val.ToString();
        }
        void calc3()
        {
            decimal amt = Convert.ToDecimal(txtAmt3.Text);
            decimal exp3 = 0, comp3 = 0;
            decimal exp4 = 0, comp4 = 0;
            decimal TotAmt = Convert.ToDecimal(txtTotExp.Text);
            decimal Amt_L = Convert.ToDecimal(txtAmt_L.Text);
            decimal Amt5 = Convert.ToDecimal(txtAmt5.Text);
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.INSGRLV where a.AMT == amt select a;
            if (sql.Any())
            {
                DateTime indt = Convert.ToDateTime(txtInDate.Text);
                //var insSQL = from a in db.INSLAB where a.NOBR == popupTextBox1.Text && indt >= a.IN_DATE && indt <= a.OUT_DATE select a;

                exp3 = 0;
                exp4 = 0;

                var r = sql.First();
                comp3 = r.EXPA;
                comp4 = r.EXTA;
                if (cbGRP_TYPE.SelectedValue.ToString() == "B")
                {
                    exp3 = r.EXPB - comp3;
                    exp4 = r.EXTB - comp4;
                }
                else if (cbGRP_TYPE.SelectedValue.ToString() == "C")
                {
                    exp3 = r.EXPC - comp3;
                    exp4 = r.EXTC - comp4;
                }
                else if (cbGRP_TYPE.SelectedValue.ToString() == "D")
                {
                    exp3 = r.EXPD - comp3;
                    exp4 = r.EXTD - comp4;
                }
                txtExp3.Text = exp3.ToString();
                txtExp4.Text = exp4.ToString();
                txtComp3.Text = comp3.ToString();
                txtComp4.Text = comp4.ToString();
            }
        }
        void calc4()//職災 公司負擔
        {
            decimal AmtL, Amt5;
            AmtL = Convert.ToDecimal(txtAmt_L.Text);//勞保薪資
            Amt5 = Convert.ToDecimal(txtAmt5.Text); //職災薪資
            decimal exp1, exp2;
            exp1 = AmtL / 10000M * MainForm.GroupInsConfig.GROUPEXP51.Value;         //
            exp2 = (Amt5 - AmtL) / 10000M * MainForm.GroupInsConfig.GROUPEXP52.Value;//若職災投保薪資超過勞保投保薪資 每一萬元負擔金額 
            //decimal exp = exp1 + exp2;
            //if (exp < 0) exp = 0;
            txtComp6.Text = exp1.ToString();
            if (Amt5 > AmtL)
            {
                txtComp5.Text = exp2.ToString();
            }
            else
            {
                txtComp5.Text = "0";
            }
        }
        void calc5()//勞保 公司負擔
        {
            decimal AmtL;
            AmtL = Convert.ToDecimal(txtAmt_L.Text);//勞保薪資
            decimal exp1;
            exp1 = AmtL / 10000M * MainForm.GroupInsConfig.GROUPEXP51.Value; //定期壽險
            txtComp6.Text = exp1.ToString();
        }
        private void txtAmt1_Validated(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
            {
                Calc();
            }
        }

        private void comboBox1_SelectedIndexChange(object sender, EventArgs e)
        {
            //Calc();
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            SetDisabler();
        }
        void SetAmt()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime inDate = Convert.ToDateTime(txtInDate.Text);
            var sql = from a in db.SALBASD where a.NOBR == ptxNobr.Text && inDate >= a.ADATE && inDate <= a.DDATE select a.AMT;
            if (sql.Any())
            {
                decimal salary = sql.ToList().Sum(p => JBModule.Data.CDecryp.Number(p));
                txtAmt5.Text = salary.ToString();
                //txtAmt_L.Text = salary.ToString();
                var insgrlvSQL = from a in db.INSGRLV where salary >= a.B_AMT && salary <= a.E_AMT select a;
                if (insgrlvSQL.Any())
                {
                    var r = insgrlvSQL.First();
                    txtAmt1.Text = r.AMT.ToString();
                    txtAmt2.Text = r.ACCI_AMT.ToString();
                    txtAmt3.Text = r.EXP_AMT.ToString();
                    txtAmt4.Text = r.EXT_AMT.ToString();
                }
            }
            var inslabSQL = from a in db.INSLAB where a.NOBR == ptxNobr.Text && inDate >= a.IN_DATE && inDate <= a.OUT_DATE select a;
            if (inslabSQL.Any())
            {
                txtAmt_L.Text = JBModule.Data.CDecryp.Number(inslabSQL.First().L_AMT).ToString();
            }
            else
            {
                txtAmt_L.Text = "0";
            }
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
                SetAmt();
        }
        void SetGridView()
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.INSGRF
                      join b in db.FAMILY on new { a.NOBR, a.FA_IDNO } equals new { b.NOBR, b.FA_IDNO } into ab
                      from insFa in ab.DefaultIfEmpty()
                      join c in db.RELCODE on insFa.REL_CODE equals c.REL_CODE into bc
                      from faRel in bc.DefaultIfEmpty()
                      where a.NOBR == ptxNobr.Text
                      select new { 眷屬姓名 = insFa != null ? insFa.FA_NAME : "", 關係 = faRel != null ? faRel.REL_NAME : "", 加保日期 = a.IN_DATE, 退保日期 = a.OUT_DATE };
            dataGridView2.DataSource = sql;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            SetGridView();
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            Decrypt();
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            Decrypt();
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(e.Values["nobr"].ToString()))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cbGRP_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetExpExt();
            if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
            {
                Calc();
            }
        }

        private void cbPAN_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetExpExt();////設定 定期壽險保額 意外保險保額 住院醫療 意外醫療 住院醫療員工負擔 住院醫療公司負擔 意外醫療員工負擔 意外醫療公司負擔
            if (fullDataCtrl1.EditType != JBControls.FullDataCtrl.EEditType.None)
            {
                Calc();
            }
        }

        private void txtAmt_L_Load(object sender, EventArgs e)
        {

        }

        private void SetExpExt() //設定 定期壽險保額 意外保險保額 住院醫療 意外醫療 住院醫療員工負擔 住院醫療公司負擔 意外醫療員工負擔 意外醫療公司負擔
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            if (cbPAN.SelectedValue == null)
            {
                return;
            }
            string plan = cbPAN.SelectedValue.ToString();
            var insgrlv = from c in db.INSGRLV
                          where c.PLAN_NO == plan
                          select c;
            if (insgrlv.Any())
            {
                txtAmt1.Text = insgrlv.FirstOrDefault().AMT.ToString();     //定期壽險保額
                txtAmt2.Text = insgrlv.FirstOrDefault().ACCI_AMT.ToString();//意外保險保額
                txtAmt3.Text = insgrlv.FirstOrDefault().EXP_AMT.ToString(); //住院醫療
                txtAmt4.Text = insgrlv.FirstOrDefault().EXT_AMT.ToString(); //意外醫療
                if (cbGRP_TYPE.SelectedValue != null)
                {

                    string grp_type = cbGRP_TYPE.SelectedValue.ToString();
                    if (grp_type == "A")
                    {
                        txtExp3.Text = insgrlv.FirstOrDefault().EXPA.ToString();     //住院醫療員工負擔
                        txtComp3.Text = insgrlv.FirstOrDefault().COM_EXPA.ToString(); //住院醫療公司負擔
                        txtExp4.Text = insgrlv.FirstOrDefault().EXTA.ToString();     //意外醫療員工負擔
                        txtComp4.Text = insgrlv.FirstOrDefault().COM_EXTA.ToString(); //意外醫療公司負擔
                    }
                    else if (grp_type == "B")
                    {
                        txtExp3.Text = insgrlv.FirstOrDefault().EXPB.ToString();     //住院醫療員工負擔
                        txtComp3.Text = insgrlv.FirstOrDefault().COM_EXPB.ToString(); //住院醫療公司負擔
                        txtExp4.Text = insgrlv.FirstOrDefault().EXTB.ToString();     //意外醫療員工負擔
                        txtComp4.Text = insgrlv.FirstOrDefault().COM_EXTB.ToString(); //意外醫療公司負擔
                    }
                    else if (grp_type == "C")
                    {
                        txtExp3.Text = insgrlv.FirstOrDefault().EXPC.ToString();     //住院醫療員工負擔
                        txtComp3.Text = insgrlv.FirstOrDefault().COM_EXPC.ToString(); //住院醫療公司負擔
                        txtExp4.Text = insgrlv.FirstOrDefault().EXTC.ToString();     //意外醫療員工負擔
                        txtComp4.Text = insgrlv.FirstOrDefault().COM_EXTC.ToString(); //意外醫療公司負擔
                    }
                    else if (grp_type == "D")
                    {
                        txtExp3.Text = insgrlv.FirstOrDefault().EXPD.ToString();     //住院醫療員工負擔
                        txtComp3.Text = insgrlv.FirstOrDefault().COM_EXPD.ToString(); //住院醫療公司負擔
                        txtExp4.Text = insgrlv.FirstOrDefault().EXTD.ToString();     //意外醫療員工負擔
                        txtComp4.Text = insgrlv.FirstOrDefault().COM_EXTD.ToString(); //意外醫療公司負擔
                    }
                    else
                    {
                        txtExp3.Text = "";
                        txtComp3.Text = "";
                        txtExp4.Text = "";
                        txtComp4.Text = "";
                    }
                }
            }
            else
            {
                txtAmt1.Text = "";
                txtAmt2.Text = "";
                txtAmt3.Text = "";
                txtAmt4.Text = "";
                txtExp3.Text = "";
                txtComp3.Text = "";
                txtExp4.Text = "";
                txtComp4.Text = "";
            }
        }

        private void btnAutoImport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要進行整批調整作業?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
            {
                AutoExport();
                Decrypt();
            }
        }

    }
}