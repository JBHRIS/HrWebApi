using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace JBHR.Att
{
    public partial class FRM231 : Form
    {
        public FRM231()
        {
            InitializeComponent();
        }
        dcAttDataContext att_db = new dcAttDataContext();
        dcBasDataContext Bas_db = new dcBasDataContext();
        List<ROTE> roteList = new List<ROTE>();
        List<tts> ttsList = new List<tts>();
        List<add_nobr> keyList = new List<add_nobr>();
        List<add_nobr> err_keyList = new List<add_nobr>();
        IWorkbook workbook;
        ISheet sheet;
        DataTable dt;
        private void FRM232_Load(object sender, EventArgs e)
        {
            this.tMTABLE_IMPORTTableAdapter.Fill(this.dsAtt.TMTABLE_IMPORT);
            bnQuery.Enabled = false;
            cbxSheet.Enabled = false;
            bn_ImportOK.Enabled = false;
            bn_ImportCancel.Enabled = false;

            List<string> ttsCode = new List<string>();
            ttsCode.Add("1");
            ttsCode.Add("4");
            ttsCode.Add("6");

            roteList = (from a in att_db.ROTE
                        select a).ToList();
            var ttssql = (from a in Bas_db.BASETTS
                          where ttsCode.Contains(a.TTSCODE)
                          select new { NOBR = a.NOBR, INDT = a.INDT, ADATE = a.ADATE, DDATE = a.DDATE }).ToList();
            foreach (var it in ttssql)
            {
                tts t = new tts();
                t.NOBR = it.NOBR;
                t.INDT = Convert.ToDateTime(it.INDT);
                t.ADATE = it.ADATE;
                t.DDATE = Convert.ToDateTime(it.DDATE);
                ttsList.Add(t);
            }
        }

        private void bnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel(xls;xlsx)|*.xls;*.xlsx";//|全部檔案|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                try
                {
                    using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                    {
                        string ExtensionName = Path.GetExtension(path);//撈取檔案的副檔名
                        if (ExtensionName.Trim().ToUpper() == ".XLS")
                            workbook = new HSSFWorkbook(file);
                        else if (ExtensionName.Trim().ToUpper() == ".XLSX")
                            workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(file);
                        else throw new Exception("不支持的檔案格式" + ExtensionName);

                        //sheet = workbook.GetSheetAt(0);
                        cbxSheet.Items.Clear();
                        txtPath.Text = path;
                        //txtYymm.Focus();
                        var enm = workbook.GetEnumerator();//撈取當前的工作表
                        while (enm.MoveNext())
                        {
                            ISheet sht = enm.Current as ISheet;
                            cbxSheet.Items.Add(sht.SheetName);
                        }
                        cbxSheet.SelectedIndex = 0;
                        bnQuery.Enabled = true;
                        cbxSheet.Enabled = true; ;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void bnQuery_Click(object sender, EventArgs e)
        {
            keyList = new List<add_nobr>();
            err_keyList = new List<add_nobr>();
            bn_ImportOK.Enabled = false;
            bn_ImportCancel.Enabled = false;
            dataGridView1.DataSource = null;
            sheet = workbook.GetSheet(cbxSheet.Text);
            dt = new DataTable();
            IRow row = sheet.GetRow(0);
            if (row != null)
            {
                for (int i = 0; i <= sheet.LastRowNum; i++)
                {
                    row = sheet.GetRow(i);
                    //檢查第一行
                    if (row.GetCell(0) == null || row.GetCell(0).ToString().Trim().Length == 0)
                    {
                        if (row.PhysicalNumberOfCells > 0)//檢查Row中是否有資料
                        {
                            //MessageBox.Show("偵測到\"A" + (row.RowNum + 1) + "\"欄位無內容，請確認所有內容皆填寫完畢再執行操作一次。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            //return;
                        }



                        else break;//沒有資料則結束LOOP


                    }
                    if (i == 0 && i == sheet.LastRowNum)
                    {
                        MessageBox.Show("檔案無內容。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (checkExcelOK(row))
                    {
                        if (i > 0)
                        {
                            DataRow dr = dt.NewRow();
                            for (int j = 0; j < 33; j++)
                            {
                                dr[j] = row.GetCell(j) == null ? "" : row.GetCell(j).ToString();
                            }

                            add_nobr newKey = new add_nobr();
                            newKey.YYMM = dr["出勤年月"].ToString();
                            newKey.NOBR = dr["工號"].ToString();
                            if (keyList.Where(p => p.NOBR == newKey.NOBR && p.YYMM == newKey.YYMM).Any())
                            {
                                if (!err_keyList.Where(p => p.NOBR == newKey.NOBR && p.YYMM == newKey.YYMM).Any())
                                    err_keyList.Add(newKey);
                            }
                            else
                            {
                                keyList.Add(newKey);
                                dt.Rows.Add(dr);
                            }

                        }

                    }
                    else return;

                }
                dataGridView1.DataSource = dt;
                string Msg = "已略過的重複資料如下：\n<出勤年月, 工號>\n";
                int NO = 1;
                foreach (var it in err_keyList)
                {
                    Msg += NO+++". "+it.YYMM + ", " + it.NOBR + "\n";
                }
                if (err_keyList.Count > 0)
                    MessageBox.Show(Msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bn_ImportOK.Enabled = true;
                bn_ImportCancel.Enabled = true;
                bnOpenFile.Enabled = false;
            }
            else
            {
                MessageBox.Show("檔案無內容。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


        }
        void DeleteTMTABLE_IMPORT(string yymm, string nobr)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var deleteSql = from a in db.TMTABLE_IMPORT
                            where a.YYMM == yymm && a.NOBR == nobr
                            select a;

            if (deleteSql.Any())
            {
                db.TMTABLE_IMPORT.DeleteOnSubmit(deleteSql.First());
                db.SubmitChanges();
            }
            
        }
        private void bn_ImportOK_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = dt.Rows.Count;
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            att_db = new dcAttDataContext();
            DataTable errDt = new DataTable();
            errDt.Columns.Add("出勤年月");
            errDt.Columns.Add("工號");
            errDt.Columns.Add("錯誤註記");
            int errorNO = 0;
            int successNO = 0;
            string errorYYMM = "";
            //新增Row
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                progressBar1.Value++;
                //progressBar1.PerformStep();
                TMTABLE_IMPORT ti = new TMTABLE_IMPORT();
                DataRow dr = dt.Rows[i];
                string msg = "";
                if (checkRote(dr, out msg))
                {
                    ti.YYMM = dr["出勤年月"].ToString();
                    ti.NOBR = dr["工號"].ToString();
                    ti.D1 = roteChange(dr["D1"].ToString().Trim());
                    ti.D2 = roteChange(dr["D2"].ToString().Trim());
                    ti.D3 = roteChange(dr["D3"].ToString().Trim());
                    ti.D4 = roteChange(dr["D4"].ToString().Trim());
                    ti.D5 = roteChange(dr["D5"].ToString().Trim());
                    ti.D6 = roteChange(dr["D6"].ToString().Trim());
                    ti.D7 = roteChange(dr["D7"].ToString().Trim());
                    ti.D8 = roteChange(dr["D8"].ToString().Trim());
                    ti.D9 = roteChange(dr["D9"].ToString().Trim());
                    ti.D10 = roteChange(dr["D10"].ToString().Trim());
                    ti.D11 = roteChange(dr["D11"].ToString().Trim());
                    ti.D12 = roteChange(dr["D12"].ToString().Trim());
                    ti.D13 = roteChange(dr["D13"].ToString().Trim());
                    ti.D14 = roteChange(dr["D14"].ToString().Trim());
                    ti.D15 = roteChange(dr["D15"].ToString().Trim());
                    ti.D16 = roteChange(dr["D16"].ToString().Trim());
                    ti.D17 = roteChange(dr["D17"].ToString().Trim());
                    ti.D18 = roteChange(dr["D18"].ToString().Trim());
                    ti.D19 = roteChange(dr["D19"].ToString().Trim());
                    ti.D20 = roteChange(dr["D20"].ToString().Trim());
                    ti.D21 = roteChange(dr["D21"].ToString().Trim());
                    ti.D22 = roteChange(dr["D22"].ToString().Trim());
                    ti.D23 = roteChange(dr["D23"].ToString().Trim());
                    ti.D24 = roteChange(dr["D24"].ToString().Trim());
                    ti.D25 = roteChange(dr["D25"].ToString().Trim());
                    ti.D26 = roteChange(dr["D26"].ToString().Trim());
                    ti.D27 = roteChange(dr["D27"].ToString().Trim());
                    ti.D28 = roteChange(dr["D28"].ToString().Trim());
                    ti.D29 = roteChange(dr["D29"].ToString().Trim());
                    ti.D30 = roteChange(dr["D30"].ToString().Trim());
                    ti.D31 = roteChange(dr["D31"].ToString().Trim());

                    ti.KEY_MAN = MainForm.USER_NAME;
                    ti.KEY_DATE = DateTime.Now;
                    ti.NO = 0;
                    ti.HOLIS = 0;
                    ti.FREQ_NO = 0;
                    DeleteTMTABLE_IMPORT(ti.YYMM, ti.NOBR);
                    att_db.TMTABLE_IMPORT.InsertOnSubmit(ti);
                    successNO++;
                }
                else
                {
                    errorNO++;
                    DataRow errDr = errDt.NewRow();
                    errDr["出勤年月"] = dr["出勤年月"].ToString().Trim();
                    errDr["工號"] = dr["工號"].ToString().Trim();
                    errDr["錯誤註記"] = msg;
                    errDt.Rows.Add(errDr);

                }
            }
            att_db.SubmitChanges();//確定新增

            string Path = JBControls.ControlConfig.GetExportPath() + "員工班表(" + DateTime.Now.ToString("yyyy_MM_dd mm-ss") + ").xls";
            MessageBox.Show("成功：" + successNO + "筆" + "   " + "失敗：" + errorNO + "筆" + (errorNO > 0 ? "\n\n錯誤訊息已儲存於: " + Path + " 目錄下。" : ""), "匯入訊息", MessageBoxButtons.OK);

            if (errorNO > 0)
            {

                JBModule.Data.CNPOI.ExportToExcel(errDt, Path, "");
                System.Diagnostics.Process.Start(Path);
            }

            init();


            //Close();
        }
        /// <summary>
        /// 檢查每天是否都有填寫ROTE,
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        bool checkRote(DataRow dr, out string msg)
        {
            msg = "";
            string YYMM = dr["出勤年月"].ToString();
            string NOBR = dr["工號"].ToString();
            int yy = int.Parse(YYMM.Substring(0, 4).ToString());
            int MM = int.Parse(YYMM.Substring(4).ToString());
            int monthDays = DateTime.DaysInMonth(yy, MM);
            int beginDay = 1;
            int endDay = monthDays;
            DateTime firstDay = new DateTime(yy, MM, 1);
            DateTime lastDay = new DateTime(yy, MM, monthDays);

            var nobrBytts = ttsList.Where(p => p.NOBR == NOBR && p.ADATE <= lastDay && p.DDATE >= firstDay);
            if (nobrBytts.Any())
            {

                DateTime INDT = nobrBytts.First().INDT;
                if (INDT.Year == yy && INDT.Month == MM)
                    beginDay = INDT.Day;
                DateTime DDATE = nobrBytts.Max(p => p.DDATE);
                if (DDATE.Year == yy && DDATE.Month == MM)
                    endDay = DDATE.Day;

            }
            else
            {
                msg = "此員工已離職或不存在";
                return false;
            }
            for (int i = beginDay; i <= endDay; i++)
            {
                string it = "D" + i;
                if (dr[it] == null || dr[it].ToString().Trim().Length == 0)
                {
                    msg = "D" + beginDay.ToString() + "至 D" + endDay + "的欄位不得空白";
                    return false;
                }
            }
            return true;

        }

        private void bn_ImportCancel_Click(object sender, EventArgs e)
        {
            init();
        }


        /// <summary>
        /// 檢查Excel的內容
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        bool checkExcelOK(IRow row)
        {
            if (row != null)
            {
                if (row.RowNum == 0)//檢查表頭
                {
                    int i = 0;
                    string headerName = "";
                    for (i = 0; i < 33; i++)
                    {
                        if (i == 0) headerName = "出勤年月";
                        else if (i == 1) headerName = "工號";
                        else headerName = "D" + (i - 1).ToString();
                        if (row.GetCell(i) == null) break;
                        else
                        {
                            if (row.GetCell(i).ToString() != headerName) break;
                        }
                        if (i == 32)//全部都檢查過
                        {
                            //dt.Columns.Add("YYMM");
                            //dt.Columns.Add("NOBR");
                            for (int j = 0; j < 33; j++)
                            {
                                dt.Columns.Add(row.GetCell(j).ToString());
                            }
                            return true;
                        }
                    }
                    MessageBox.Show("偵測到\"" + ColumnNum(i + 1) + (row.RowNum + 1) + "\"欄位元名稱錯誤，請將名稱改成\"" + headerName + "\"後再操作做一次。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else//檢查內容
                {
                    //檢查YYMM欄位格式
                    int rowCount = 0;
                    try
                    {

                        int year = Convert.ToInt16(row.GetCell(0).ToString().Substring(0, 4));
                        int month = Convert.ToInt16(row.GetCell(0).ToString().Substring(4));
                        rowCount = 2 + DateTime.DaysInMonth(year, month);
                    }
                    catch
                    {
                        MessageBox.Show("偵測到\"A" + (row.RowNum + 1) + "\"欄位格式有誤，請確認格式為「西元年+月份」\n例如: " + DateTime.Now.ToString("yyyy") + "02", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    for (int i = 1; i < rowCount; i++)
                    {
                        if (row.GetCell(i) == null || row.GetCell(i).ToString().Trim().Length == 0)
                        {
                            if (i == 1)
                            {
                                MessageBox.Show("偵測到\"" + ColumnNum(i + 1) + (row.RowNum + 1) + "\"欄位無內容，請確認所有內容皆填寫完畢後再執行操作一次。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            if (i > 1)
                            {
                                //檢查rote
                                if (row.GetCell(i) == null || row.GetCell(i).ToString().Trim().Length == 0)
                                {

                                }
                                if (roteChange(row.GetCell(i).ToString()) == "")
                                {
                                    string str = "";
                                    for (int j = 0; j < roteList.Count; j++)
                                    {
                                        str += roteList[j].ROTE_DISP;
                                        if (j < roteList.Count - 1) str += "、";
                                        //else if (j == roteArr.GetLength(0) - 2) str += "或";
                                    }
                                    MessageBox.Show("偵測到\"" + ColumnNum(i + 1) + (row.RowNum + 1) + "\"欄位內容填寫錯誤。\n可填寫內容如下：\n" + str + "。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }

                            }
                        }
                    }
                    return true;
                }
            }
            else
            {
                MessageBox.Show("檔案無內容。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        /// <summary>
        /// 將數位轉換成Excel的行碼
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        string ColumnNum(int i)
        {
            string Eng = "";
            if (i > 26) Eng = Convert.ToChar(65 + (i / 26) - 1).ToString();
            string num = Eng + Convert.ToChar(65 + (i % 26) - 1).ToString();
            return num;
        }

        /// <summary>
        /// 透過rote轉換成亂碼
        /// </summary>
        /// <param name="roteArr"></param>
        /// <param name="drStr"></param>
        /// <returns></returns>
        string roteChange(string drStr)
        {

            for (int i = 0; i < roteList.Count; i++)
            {
                if (drStr == roteList[i].ROTE_DISP) return roteList[i].ROTE1;
            }
            return "";

        }

        void init()
        {
            bnOpenFile.Enabled = true;
            cbxSheet.Enabled = false; ;
            bnQuery.Enabled = false;
            bn_ImportOK.Enabled = false;
            bn_ImportCancel.Enabled = false;
            txtPath.Text = "";
            cbxSheet.Items.Clear();
            dataGridView1.DataSource = null;
            progressBar1.Visible = false;
        }
    }

}

public class tts
{
    public string NOBR;
    public DateTime INDT;
    public DateTime ADATE;
    public DateTime DDATE;
}

public class add_nobr
{
    public string NOBR  {set; get;}
    public string YYMM { set; get; }

}

