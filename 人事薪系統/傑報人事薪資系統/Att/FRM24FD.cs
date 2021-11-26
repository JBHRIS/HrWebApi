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
    public partial class FRM24FD : JBControls.JBForm
    {
        DataTable dt = new DataTable();
        JBHR.Att.FOOD_CARD FOOD_CARDC; 
//        JBHR.ImportC.ImportGen cardC;
        public FRM24FD()
        {
            FOOD_CARDC = new FOOD_CARD(); //   new JBHR.ImportC.CARDC();
            InitializeComponent();
        }
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            String newPath = FOOD_CARDC.openFile(this.cbxSheet, txtPath.Text);
             if (!newPath.Equals(txtPath.Text))
            {
                lbTotal.Text = "0";
                lbRepeat.Text = "0";
                ibImport.Text = "0";
                txtPath.Text = newPath;

                cbxNobr.SelectedIndex = -1;
                cboADate.SelectedIndex = -1;
                cbxATime.SelectedIndex = -1;
                comboBoxCardcd.SelectedIndex = -1;

                cbxNobr.Items.Clear();
                cboADate.Items.Clear();
                cbxATime.Items.Clear();
                comboBoxCardcd.Items.Clear();

            }
        }
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> dic = new Dictionary<string, string>();
            List<int> repeatList = new List<int>();
            String isKey= "";

            if (cbxNobr.SelectedItem != null && cboADate.SelectedItem != null && cbxATime.SelectedItem != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    isKey = dt.Rows[i][cbxNobr.SelectedItem.ToString().Trim()].ToString() + dt.Rows[i][cboADate.SelectedItem.ToString().Trim()].ToString() + dt.Rows[i][cbxATime.SelectedItem.ToString().Trim()].ToString();
                    if (dic.ContainsKey(isKey))
                    {
                        repeatList.Add(i);
                    }
                    else
                    {
                        dic.Add(isKey, "");
                    }
                }
            }
            else {
                MessageBox.Show("請選擇欄位，以顯示重複資料。", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            lbRepeat.Text = repeatList.Count.ToString();
            FOOD_CARDC.openPreviewForm("刷卡資料", repeatList);
        }
        private void cbxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt = FOOD_CARDC.setExcelTable(cbxSheet.SelectedItem.ToString());
                List<ComboBox> list = new List<ComboBox>();
                list.Add(cbxNobr);
                list.Add(cboADate);
                list.Add(cbxATime);
                list.Add(comboBoxCardcd);
                FOOD_CARDC.setCBXItem(list);
            }
            catch (NullReferenceException nre) { 
            }
            
        }
        private void tbnCreateCard_Click(object sender, EventArgs e)
        {
            lbTotal.Text = "0";
            lbRepeat.Text = "0";
            ibImport.Text = "0";
            Dictionary<String, String> dic = new Dictionary<string, string>();
            if (cbxNobr.SelectedItem != null && cboADate.SelectedItem != null && cbxATime.SelectedItem != null)
            {
                dic.Add("Nobr", cbxNobr.SelectedItem.ToString());
                dic.Add("ADate", cboADate.SelectedItem.ToString());
                dic.Add("ATime", cbxATime.SelectedItem.ToString());
                dic.Add("Cardcd", comboBoxCardcd.SelectedItem.ToString());

                progressBar.Visible = true;

                dgvCardView.DataSource = FOOD_CARDC.ceateRoteChgTable(dic, this.progressBar);

                progressBar.Visible = false;

                lbTotal.Text = (dgvCardView.Rows.Count - 1).ToString();
            }
            else {
                MessageBox.Show("請選擇欄位。", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {

            progressBar.Visible = true;
            ibImport.Text = FOOD_CARDC.insertRoteChg(this.dgvCardView, this.progressBar).ToString();
            progressBar.Visible = false;
            
            MessageBox.Show("匯入筆數 : " + ibImport.Text, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    class FOOD_CARD : JBHR.ImportC.ImportGen
    {

        JBHR.Att.dsAtt.FOOD_CARDDataTable  Food_CardDatatable;

        public override System.Data.DataTable ceateRoteChgTable(Dictionary<string, string> dic, ProgressBar PB)
        {
            Att.dsAtt.FOOD_CARDDataTable fOOD_CARD = new dsAtt.FOOD_CARDDataTable();
            if (excelDT != null)
            {

                //DataTable DTCard = ds.Tables[cbxSheet.SelectedItem.ToString()];


                DataTable DTCard = excelDT;
                PB.Value = 0;
                PB.Maximum = DTCard.Rows.Count;
                String errorMsg = "";
                bool nobrError = false;
                bool dateError = false;
                bool ontimeError = false;
                bool dataRepeat = false;
                bool CardcdErr = false;
                int count = DTCard.Rows.Count;
                //linq
                var empName = from name in HDDC.BASE select new { emp_name = name.NAME_C, empNo = name.NOBR };

                var cardappC = from cardappi in HDDC.FOOD_CARD 
                               join empi in HDDC.BASE on cardappi.NOBR equals empi.NOBR
                               select new { cardapp_No = cardappi.CARDNO, cardapp_Nobr = cardappi.NOBR, emp_No = empi.NOBR, emp_Name = empi.NAME_C };

                //linq
                foreach (DataRow item in DTCard.Rows)
                {
                    PB.Value += 1;
                    String nobrTemp = "";
                    String nameTemp = "";



                    var cardRow = fOOD_CARD.NewFOOD_CARDRow();
                    cardRow.CODE = "";
                    if (item[dic["Nobr"]] != null && item[dic["ADate"]] != null && item[dic["ATime"]] != null)
                    {
                        if (item[dic["Nobr"]].ToString().Length != 0 || item[dic["ADate"]].ToString().Length != 0 || item[dic["ATime"]].ToString().Length != 0)
                        {
                            var C_Name = (from name in empName where name.empNo.Equals(item[dic["Nobr"]].ToString()) select new { Emp_name = name.emp_name, Emp_Nobr = name.empNo }).FirstOrDefault();

                            if (C_Name != null)
                            {
                                nobrTemp = C_Name.Emp_Nobr;
                                nameTemp = C_Name.Emp_name;
                            }
                            else
                            {
                                var cardapp_Temp = (from cardappi in cardappC where cardappi.cardapp_No.Equals(item[dic["Nobr"]].ToString()) select cardappi).FirstOrDefault();
                                if (cardapp_Temp != null)
                                {
                                    nobrTemp = cardapp_Temp.emp_No;
                                    nameTemp = cardapp_Temp.emp_Name;
                                }
                                else
                                {
                                    nobrTemp = "";
                                    nameTemp = "";
                                }
                            }
                            try
                            {
                                cardRow.NOBR = nobrTemp;
                            }
                            catch (Exception ex)
                            {
                                nobrError = true;
                            }
                            try
                            {
                                //cardRow.ADATE = DateTime.FromOADate(Convert.ToDouble(item[cboADate.SelectedItem.ToString()]));
                                cardRow.ADATE = Convert.ToDateTime(item[dic["ADate"]]).Date;
                            }
                            catch (FormatException fe)
                            {
                                dateError = true;
                            }

                            try
                            {
                                //cardRow.ADATE = DateTime.FromOADate(Convert.ToDouble(item[cboADate.SelectedItem.ToString()]));
                                cardRow.CODE  = item[dic["Cardcd"]].ToString();
                            }
                            catch (FormatException fe)
                            {
                                CardcdErr = true;
                            }

                            try
                            {
                                DateTime dt = DateTime.MaxValue;
                                cardRow.ONTIME = DateTime.TryParse(item[dic["ATime"]].ToString(), out dt) ? dt.ToString("HHmm") : item[dic["ATime"]].ToString();
                            }
                            catch (Exception ex)
                            {
                                ontimeError = true;
                            }
                            DateTime ErrDate = DateTime.Now;
                            cardRow.CARDNO = "";
                            cardRow.KEY_DATE = DateTime.Now.Date;
                            cardRow.KEY_MAN = MainForm.USER_NAME;
                            cardRow.NOT_TRAN = false;
                            cardRow.DAYS = 0m;
                            cardRow.REASON = "";
                            cardRow.LOS = false;
                            cardRow.IPADD = "";
                            cardRow.MENO = "";
                            cardRow.SERNO = item[dic["Nobr"]].ToString();
                            cardRow.FULLTIME = DateTime.Now;
                            //DateTime.TConvert.ToDateTime(cardRow.ADATE.ToString() + " " + cardRow.ONTIME.Substring(0, 2) + ":" + cardRow.ONTIME.Substring(2, 2)),out ErrDate); 
                            cardRow.NAME_C = nameTemp;
                            cardRow.D_NAME = string.Empty;
                            cardRow.D_NO_DISP = string.Empty;
                            cardRow.temperature = string.Empty;
                            try
                            {
                                fOOD_CARD.AddFOOD_CARDRow (cardRow);
                            }
                            catch (ConstraintException ce)
                            {
                                dataRepeat = true;
                            }
                        }
                    }
                }
                if (dateError)
                    errorMsg += "請修改刷卡時間" + Environment.NewLine;
                if (nobrError)
                    errorMsg += "請修改員工編號" + Environment.NewLine;
                if (ontimeError)
                    errorMsg += "請修改刷卡時間" + Environment.NewLine;
                if (CardcdErr )
                    errorMsg += "資料來源不正確" + Environment.NewLine;
                if (dataRepeat)
                    errorMsg += "Excel數據重複" + Environment.NewLine;

                if (errorMsg.Length != 0)
                {
                    //MessageBox.Show(errorMsg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                foreach (DataColumn item in fOOD_CARD.Columns)
                {
                    item.ColumnName = item.Caption;
                }
                //dgvCardView.DataSource = fOOD_CARD;
                //setDataGridViewUI();
                //lbTotal.Text = (dgvCardView.Rows.Count - 1).ToString();
            }
            else
            {
                MessageBox.Show("請選擇資料表", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            return fOOD_CARD;
        }
        public override int insertRoteChg(System.Windows.Forms.DataGridView DGW, ProgressBar PB)
        {
            Food_CardDatatable = new JBHR.Att.dsAtt.FOOD_CARDDataTable();

            var cardTemp = from cardTempi in HDDC.FOOD_CARD  select new { emp_no = cardTempi.NOBR, emp_adate = cardTempi.ADATE, emp_ontime = cardTempi.ONTIME };

            var emp = from empi in HDDC.BASE select new { emp_id = empi.NOBR };

            var cardapp = from cardappi in HDDC.FOOD_CARD select new { card_No = cardappi.CARDNO };

            JBModule.Data.Linq.FOOD_CARD  card;

            List<JBModule.Data.Linq.FOOD_CARD > cardList = new List<JBModule.Data.Linq.FOOD_CARD >();
            PB.Value = 0;
            PB.Maximum = DGW.RowCount;
            foreach (DataGridViewRow item in DGW.Rows)
            {
                PB.Value += 1;
                if ((item.Cells["刷卡日期"].Value != null) && (item.Cells["員工編號"].Value != null) && (item.Cells["刷卡時間"].Value != null))
                {
                    //确定数据正确性
                    var hasCard = from cardi in cardTemp
                                  where cardi.emp_adate.Date.CompareTo(Convert.ToDateTime(item.Cells["刷卡日期"].Value.ToString()).Date) == 0
                                  && cardi.emp_no == item.Cells["員工編號"].Value.ToString()
                                  && cardi.emp_ontime == item.Cells["刷卡時間"].Value.ToString()
                                  select cardi;

                    var hasEmp = from hasEmpi in emp
                                 where hasEmpi.emp_id.Equals(item.Cells["員工編號"].Value)
                                 select hasEmpi;

                    var hasCardapp = from hasCardappi in cardapp
                                     where hasCardappi.card_No.Equals(item.Cells["員工編號"].Value)
                                     select hasCardappi;

                    bool isATime = checkATime(item.Cells["刷卡時間"].Value.ToString());

                    if (!hasCard.Any() && (hasEmp.Any() || hasCardapp.Any()) && isATime)
                    {
                        card = new JBModule.Data.Linq.FOOD_CARD();
                        card.CODE = item.Cells["來源"].Value.ToString();
                        card.NOBR = item.Cells["員工編號"].Value.ToString();
                        card.ADATE = Convert.ToDateTime(item.Cells["刷卡日期"].Value.ToString());
                        card.ONTIME = item.Cells["刷卡時間"].Value.ToString();
                        card.CARDNO = item.Cells["刷卡卡號"].Value.ToString();
                        card.KEY_DATE = Convert.ToDateTime(item.Cells["建檔日期"].Value.ToString());
                        card.KEY_MAN = item.Cells["建檔人員"].Value.ToString();
                        card.NOT_TRAN = Convert.ToBoolean(item.Cells["不轉換"].Value.ToString());
                        card.DAYS = Convert.ToDecimal(item.Cells["前日刷卡"].Value.ToString());
                        card.REASON = item.Cells["原因"].Value.ToString();
                        card.LOS = Convert.ToBoolean(item.Cells["忘刷"].Value.ToString());
                        card.IPADD = item.Cells["電子刷卡IP"].Value.ToString();
                        card.MENO = item.Cells["備註"].Value.ToString();
                        card.SERNO = item.Cells["窗體編號"].Value.ToString();
                        card.FULLTIME = DateTime.Now;
                        cardList.Add(card);
                    }
                    else
                    {
                        var errorRow = Food_CardDatatable.NewFOOD_CARDRow();
                        errorRow.CODE = item.Cells["來源"].Value.ToString();
                        errorRow.NOBR = item.Cells["員工編號"].Value.ToString();
                        errorRow.ADATE = Convert.ToDateTime(item.Cells["刷卡日期"].Value.ToString());
                        errorRow.ONTIME = item.Cells["刷卡時間"].Value.ToString();
                        errorRow.CARDNO = item.Cells["刷卡卡號"].Value.ToString();
                        errorRow.KEY_DATE = Convert.ToDateTime(item.Cells["建檔日期"].Value.ToString());
                        errorRow.KEY_MAN = item.Cells["建檔人員"].Value.ToString();
                        errorRow.NOT_TRAN = Convert.ToBoolean(item.Cells["不轉換"].Value.ToString());
                        errorRow.DAYS = Convert.ToDecimal(item.Cells["前日刷卡"].Value.ToString());
                        errorRow.REASON = item.Cells["原因"].Value.ToString();
                        errorRow.LOS = Convert.ToBoolean(item.Cells["忘刷"].Value.ToString());
                        errorRow.IPADD = item.Cells["電子刷卡IP"].Value.ToString();
                        errorRow.MENO = item.Cells["備註"].Value.ToString();
                        errorRow.SERNO = item.Cells["窗體編號"].Value.ToString();
                        errorRow.MENO = "資料重複請確認。";
                        errorRow.FULLTIME = DateTime.Now;
                        errorRow.NAME_C = item.Cells["NAME_C"].Value.ToString();
                        errorRow.D_NAME = string.Empty;
                        errorRow.D_NO_DISP = string.Empty;
                        errorRow.temperature = string.Empty;
                        Food_CardDatatable.AddFOOD_CARDRow (errorRow);
                    }
                }
            }
            HDDC.FOOD_CARD.InsertAllOnSubmit(cardList);
            HDDC.SubmitChanges();
            if (Food_CardDatatable.Rows.Count > 0)
            {
                foreach (DataColumn item in Food_CardDatatable.Columns)
                {
                    item.ColumnName = item.Caption;
                }
                String errorDataPath = "C:\\TEMP\\刷卡資料(" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + " " + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ").xls";
                JBModule.Data.CNPOI.ExportToExcel(Food_CardDatatable, errorDataPath, "");
                MessageBox.Show("錯誤資料導出 : " + errorDataPath, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            //MessageBox.Show("数据汇入 : " + cardList.Count.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return cardList.Count();
        }
        private bool checkATime(String ATime)
        {
            int intTemp;
            if (ATime.Length < 4)
            {
                return false;
            }
            try
            {
                intTemp = Convert.ToInt32(ATime);
            }
            catch (FormatException fe)
            {
                return false;
            }
            if (intTemp < 0 || intTemp > 4800)
            {
                return false;
            }
            return true;
        }
    }





}
