using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace JBHR.Sal
{
    public partial class FRM42B : JBControls.JBForm
    {
        public FRM42B()
        {
            InitializeComponent();
        }

        CheckControl cc;//必要欄位檢查
        public string Source;
        public string Code;

        private void FRM42B_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'salaryTransferDataSet1.BankCode' 資料表。您可以視需要進行移動或移除。
            this.bankCodeTableAdapter.Fill(this.salaryTransferDataSet1.BankCode);
            // TODO: 這行程式碼會將資料載入 'chpthrDataSet.BankCode' 資料表。您可以視需要進行移動或移除。
            this.bankCodeTableAdapter.Fill(this.salaryTransferDataSet.BankCode);

            ////銀行代碼選擇
            //Dictionary<string, string> BankCode = new Dictionary<string, string>();
            //var sql = this.bankCodeTableAdapter.GetData();
            //if (sql.Any())
            //{
            //    foreach (var item in sql)
            //    {
            //        BankCode.Add(item.CODE_DISP, item.CODE_DISP + "-" + item.BankName);
            //    }
            //}
            //comboBoxBC.DisplayMember = "Value";
            //comboBoxBC.ValueMember = "Key";
            //comboBoxBC.DataSource = BankCode.ToList();

            //文件內容分類明細
            //SystemFunction.SetComboBoxItems(comboBoxClass, CodeFunction.GetMtCode("SETTINGSCLASS"), false);

            Dictionary<string, string> ClassDic = new Dictionary<string, string>();
            var dc = new JBModule.Data.Linq.HrDBDataContext();

            var sql2 = from a in dc.MTCODE
                      where a.CATEGORY == "SETTINGSCLASS" && a.DISPLAY
                      orderby a.SORT
                      select new { Key = a.CODE, Value = a.NAME };



            if (sql2.Any())
            {
                foreach (var item in sql2)
                {
                    ClassDic.Add(item.Key, item.Value);
                }
            }

            comboBoxClass.DisplayMember = "Value";
            comboBoxClass.ValueMember = "Key";
            comboBoxClass.DataSource = ClassDic.ToList();

            //if (comboBoxBC.SelectedValue == null)
            //{
            //    return;
            //}


            this.salaryTransferTableAdapter.Fill(this.salaryTransferDataSet.SalaryTransfer, Code.ToString(), comboBoxClass.SelectedValue.ToString());
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(comboBoxName);
            cc.AddControl(numericUpDownLength);
            cc.AddControl(comboBox1);//必要欄位檢查
            cc.AddControl(comboBox2);//必要欄位檢查
            cc.AddControl(comboBox3);//必要欄位檢查
            cc.AddControl(comboBox4);//必要欄位檢查
            cc.AddControl(comboBox5);//必要欄位檢查


            Dictionary<string, string> NameDic = new Dictionary<string, string>();

            var sql3 = from a in dc.MTCODE
                       where a.CATEGORY == "SETTINGSNAME_HEADER" && a.DISPLAY
                       orderby a.SORT
                       select new { Key = a.CODE, Value = a.NAME };



            if (sql3.Any())
            {
                foreach (var item in sql3)
                {
                    NameDic.Add(item.Key, item.Value);
                }
            }

            comboBoxName.DisplayMember = "Value";
            comboBoxName.ValueMember = "Key";
            comboBoxName.DataSource = NameDic.ToList();

            //SystemFunction.SetComboBoxItems(comboBoxName, CodeFunction.GetMtCode("SETTINGSNAME"), false);
            //comboBoxName.Enabled = false;


            Dictionary<string, string> TypeDic = new Dictionary<string, string>();
            TypeDic.Add("String", "文字");
            TypeDic.Add("Amt", "金額，取小數X位");
            TypeDic.Add("Date", "日期");
            TypeDic.Add("Empty", "空白");
            TypeDic.Add("Fixed", "固定值X");
            SystemFunction.SetComboBoxItems(comboBox1, TypeDic, false);
            comboBox1.Enabled = false;

            Dictionary<string, string> SideDic = new Dictionary<string, string>();
            SideDic.Add("None", "(無)");
            SideDic.Add("LEFT", "左補");
            SideDic.Add("RIGHT", "右補");
            SystemFunction.SetComboBoxItems(comboBox2, SideDic, false);
            comboBox2.Enabled = false;

            Dictionary<string, string> FilledDic = new Dictionary<string, string>();
            FilledDic.Add("N", "N-(無)");
            FilledDic.Add("0", "0-零");
            FilledDic.Add("E", "E-空白");
            SystemFunction.SetComboBoxItems(comboBox3, FilledDic, false);
            comboBox3.Enabled = false;

            Dictionary<string, string> YearType = new Dictionary<string, string>();
            YearType.Add("None", "(無)");
            YearType.Add("西元年", "西元年");
            YearType.Add("民國年", "民國年");
            SystemFunction.SetComboBoxItems(comboBox4, YearType, false);
            comboBox4.Enabled = false;

            Dictionary<string, string> DateFormat = new Dictionary<string, string>();
            DateFormat.Add("None", "(無)");
            DateFormat.Add("yyyyMMdd", "年月日");
            DateFormat.Add("yyyy-MM-dd", "年-月-日");
            DateFormat.Add("yyyy/MM/dd", "年/月/日");
            SystemFunction.SetComboBoxItems(comboBox5, DateFormat, false);
            comboBox5.Enabled = false;


            this.sALTYCDTableAdapter.Fill(this.salaryDS.SALTYCD);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.DataAdapter = salaryTransferTableAdapter;
            //fullDataCtrl1.WhereCmd = string.Format("BANKCODE = '{0}'", Code);
            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_BeforeAdd(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            //if (comboBoxBC.SelectedValue == null)
            //{
            //    MessageBox.Show("沒有銀行資料!");
            //    e.Cancel = true;
            //    return;
            //}
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox1.Focus();
            comboBoxBC.Enabled = false;
            comboBoxClass.Enabled = false;
            bn_NOup.Enabled = false;
            bn_NOdown.Enabled = false;
            numericUpDownLength.Value = 1;
            comboBoxName.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;

            int lastLocation = 1;
            int lastLength = 0;
            int lastNO = 0;

            var sql = this.salaryTransferTableAdapter.GetData(Code.ToString(), comboBoxClass.SelectedValue.ToString());

            if (sql.Any())
            {
                lastLocation = Convert.ToInt32(sql.ToList().Last().LOCATION);
                lastLength = Convert.ToInt32(sql.ToList().Last().LENGTH);
                lastNO = Convert.ToInt32(sql.ToList().Last().NO);
            }

            e.Values["NO"] = lastNO + 1;
            e.Values["LOCATION"] = lastLocation + lastLength;
            e.Values["CLASSIFY"] = comboBoxClass.SelectedValue.ToString();
            e.Values["BANKCODE"] = Code.ToString();
            e.Values["kEy_MaN"] = MainForm.USER_NAME;
            e.Values["KeY_dAtE"] = DateTime.Now;
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            comboBoxBC.Enabled = false;
            comboBoxClass.Enabled = false;
            bn_NOup.Enabled = false;
            bn_NOdown.Enabled = false;

            Button btn_event = new Button();
            btn_event.Click += comboBox1_SelectedIndexChanged;
            btn_event.Click += comboBox2_SelectedIndexChanged;
            btn_event.PerformClick();

            e.Values["kEy_MaN"] = MainForm.USER_NAME;
            e.Values["KeY_dAtE"] = DateTime.Now;
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
            var sql = this.salaryTransferTableAdapter.GetData(Code.ToString(), comboBoxClass.SelectedValue.ToString());
            int lastLocation = 1;
            int lastLength = 0;
            int newLocation = lastLength + lastLocation;
            foreach (var item in sql)
            {
                if (item.NO > Convert.ToInt32(e.OldValues["NO"]))
                {
                    lastLocation = Convert.ToInt32(salaryTransferTableAdapter.GetLocation(Code.ToString(), comboBoxClass.SelectedValue.ToString(), item.NO - 2));
                    lastLength = Convert.ToInt32(salaryTransferTableAdapter.GetLength(Code.ToString(), comboBoxClass.SelectedValue.ToString(), item.NO - 2));
                    newLocation = lastLocation + lastLength;
                    if (newLocation < 1)
                        newLocation = 1;
                    this.salaryTransferTableAdapter.UpdateQuery(newLocation, item.NO - 1, item.NO, Code.ToString(), Code.ToString());
                }

            }
            this.salaryTransferTableAdapter.Fill(this.salaryTransferDataSet.SalaryTransfer, Code.ToString(), comboBoxClass.SelectedValue.ToString());
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            var ctrl = cc.CheckRequiredFields();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }
            if (comboBox1.SelectedValue.ToString() == "Date" && (comboBox4.SelectedValue.ToString() == "None" || comboBox5.SelectedValue.ToString() == "None"))
            {
                MessageBox.Show("當型態為日期時，請設定格式", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (comboBox1.SelectedValue.ToString() == "Fixed" && textBox1.Text == "")
            {
                MessageBox.Show("請輸入固定值", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (comboBox2.SelectedValue.ToString() != "None" && comboBox3.SelectedValue.ToString() == "N")
            {
                MessageBox.Show("設定補齊方向時，請填入補齊值", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }

            if (comboBox1.SelectedValue.ToString() == "Amt" && !Regex.IsMatch(textBox1.Text,@"^\d+$"))
            {
                MessageBox.Show("請輸入小數幾位", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            var sql = this.salaryTransferTableAdapter.GetData(Code.ToString(), comboBoxClass.SelectedValue.ToString());
            int lastLocation = 1;
            int lastLength = 0;
            int newLocation = lastLength + lastLocation;
            foreach (var item in sql)
            {
                if (item.NO > Convert.ToInt32(e.Values["NO"])) //修改時 調整位置
                {
                    lastLocation = Convert.ToInt32(salaryTransferTableAdapter.GetLocation(Code.ToString(), comboBoxClass.SelectedValue.ToString(), item.NO - 1));
                    lastLength = Convert.ToInt32(salaryTransferTableAdapter.GetLength(Code.ToString(), comboBoxClass.SelectedValue.ToString(), item.NO - 1));
                    newLocation = lastLocation + lastLength;
                    if (newLocation < 1) newLocation = 1;
                    this.salaryTransferTableAdapter.UpdateQuery(newLocation, item.NO, item.NO, comboBoxClass.SelectedValue.ToString(), Code.ToString());
                }
            }
            this.salaryTransferTableAdapter.Fill(this.salaryTransferDataSet.SalaryTransfer, Code.ToString(), comboBoxClass.SelectedValue.ToString());
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);

            comboBoxBC.Enabled = true;
            comboBoxClass.Enabled = true;
            bn_NOup.Enabled = true;
            bn_NOdown.Enabled = true;
        }

        private void fullDataCtrl1_BeforeCancel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            comboBoxBC.Enabled = true;
            comboBoxClass.Enabled = true;
            bn_NOup.Enabled = true;
            bn_NOdown.Enabled = true;
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string settingname = "";
                switch (comboBoxClass.SelectedValue.ToString())
                {
                    case "Header":
                        settingname = "SETTINGSNAME_HEADER";
                        break;  
                    case "Body":
                        settingname = "SETTINGSNAME_BODY";
                        break;
                    case "Footer":
                        settingname = "SETTINGSNAME_FOOTER";
                        break;
                    default:
                        break;
                }
                Dictionary<string, string> NameDic = new Dictionary<string, string>();
                var db2 = new JBModule.Data.Linq.HrDBDataContext();
                var sql2 = from a in db2.MTCODE
                           where a.CATEGORY == settingname && a.DISPLAY
                           orderby a.SORT
                           select new { Key = a.CODE, Value = a.NAME };



                if (sql2.Any())
                {
                    foreach (var item in sql2)
                    {
                        NameDic.Add(item.Key, item.Value);
                    }
                }

                comboBoxName.DisplayMember = "Value";
                comboBoxName.ValueMember = "Key";
                comboBoxName.DataSource = NameDic.ToList();

                this.salaryTransferTableAdapter.Fill(this.salaryTransferDataSet.SalaryTransfer, Code.ToString(), comboBoxClass.SelectedValue.ToString());
                fullDataCtrl1.Init_Ctrls();
            }
            catch
            {
                return;
            }
        }

        private void setSeq(string str) //調整順序
        {
            if (dataGridView1.RowCount > 0)
            {
                int no = getNO();
                int currentrow = dataGridView1.SelectedCells[0].RowIndex;

                var sql = this.salaryTransferTableAdapter.GetDataByNO(Code.ToString(), comboBoxClass.SelectedValue.ToString(), no);

                if (str == "UP")
                {
                    if (sql.First().NO > 1)
                    {
                        var sql2 = this.salaryTransferTableAdapter.GetDataByNO(Code.ToString(), comboBoxClass.SelectedValue.ToString(), no - 1);

                        int auto1 = sql.First().AUTO;
                        int auto2 = sql2.First().AUTO;
                        int no1 = sql.First().NO;
                        int no2 = sql2.First().NO;

                        int location1 = sql.First().LOCATION;
                        int location2 = sql2.First().LOCATION;
                        int length1 = sql.First().LENGTH;

                        this.salaryTransferTableAdapter.UpdateSeq(no2, location2, auto1);
                        this.salaryTransferTableAdapter.UpdateSeq(no1, location2 + length1, auto2);

                        currentrow -= 1;
                    }
                }

                if (str == "DOWN")
                {
                    if (sql.First().NO < dataGridView1.RowCount)
                    {
                        var sql2 = this.salaryTransferTableAdapter.GetDataByNO(Code.ToString(), comboBoxClass.SelectedValue.ToString(), getNO() + 1);

                        int auto1 = sql.First().AUTO;
                        int auto2 = sql2.First().AUTO;
                        int no1 = sql.First().NO;
                        int no2 = sql2.First().NO;

                        int location1 = sql.First().LOCATION;
                        int location2 = sql2.First().LOCATION;

                        int length2 = sql2.First().LENGTH;

                        this.salaryTransferTableAdapter.UpdateSeq(no2, location1 + length2, auto1);
                        this.salaryTransferTableAdapter.UpdateSeq(no1, location1, auto2);

                        currentrow += 1;
                    }
                }
                this.salaryTransferTableAdapter.Fill(this.salaryTransferDataSet.SalaryTransfer, Code.ToString(), comboBoxClass.SelectedValue.ToString());
                fullDataCtrl1.Init_Ctrls();
                dataGridView1.CurrentCell = dataGridView1.Rows[currentrow].Cells[0];
            }
        }

        private int getNO() // 取得當前點選項次
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            int no = Convert.ToInt32(selectedRow.Cells[0].Value);
            return no;
        }

        private void bn_NOup_Click(object sender, EventArgs e)
        {
            setSeq("UP");
        }

        private void bn_NOdown_Click(object sender, EventArgs e)
        {
            setSeq("DOWN");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (fullDataCtrl1.ModeType == JBControls.FullDataCtrl.EModeType.Edit)
                {
                    if (comboBox1.SelectedValue.ToString() == "Date")
                    {
                        textBox1.Text = "";
                        textBox1.Enabled = false;
                        comboBox4.SelectedIndex = 1;
                        comboBox5.SelectedIndex = 1;
                        comboBox4.Enabled = true;
                        comboBox5.Enabled = true;
                    }
                    else
                        if (comboBox1.SelectedValue.ToString() == "Fixed" || comboBox1.SelectedValue.ToString() == "Amt")
                        {
                            textBox1.Enabled = true;
                            comboBox4.SelectedIndex = 0;
                            comboBox5.SelectedIndex = 0;
                            comboBox4.Enabled = false;
                            comboBox5.Enabled = false;

                        }
                        else
                        {
                            textBox1.Text = "";
                            textBox1.Enabled = false;
                            comboBox4.SelectedIndex = 0;
                            comboBox5.SelectedIndex = 0;
                            comboBox4.Enabled = false;
                            comboBox5.Enabled = false;
                        }

                    if (comboBox1.SelectedValue.ToString() != "String" && comboBox1.SelectedValue.ToString() != "Fixed" && comboBox1.SelectedValue.ToString() != "Date")
                    {
                        comboBox2.SelectedIndex = 0;
                        comboBox2.Enabled = false;
                    }
                    else
                    {
                        comboBox2.Enabled = true;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (fullDataCtrl1.ModeType == JBControls.FullDataCtrl.EModeType.Edit)
                {
                    if (comboBox2.SelectedValue.ToString() != "None")
                    {
                        comboBox3.SelectedIndex = 1;
                        comboBox3.Enabled = true;
                    }
                    else
                    {
                        comboBox3.SelectedIndex = 0;
                        comboBox3.Enabled = false;
                    }
                }
            }
            catch
            {
                return;
            }
        }
    }
}
