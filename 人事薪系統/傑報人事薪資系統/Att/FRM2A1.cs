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
using JBHR.Att.Attendance.Dto;
using JBHR.Att.Attendance;

namespace JBHR.Att
{
    public partial class FRM2A1 : Form
    {
        public FRM2A1()
        {
            InitializeComponent();
        }
        dcAttDataContext att_db = new dcAttDataContext();
        List<ROTE> roteList = new List<ROTE>();
        IWorkbook workbook;
        ISheet sheet;
        DataTable dt;
        int ColumnsCount;
        
        private void FRM2A1_Load(object sender, EventArgs e)
        {
            this.tMTABLE_IMPORTTableAdapter.Fill(this.dsAtt.TMTABLE_IMPORT);
            bnQuery.Enabled = false;
            cbxSheet.Enabled = false;
            bn_ImportOK.Enabled = false;
            bn_ImportCancel.Enabled = false;
            roteList = (from a in att_db.ROTE
                        select a).ToList();
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            ColumnsCount = 3;//Excel的行數
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
                        else throw new Exception("不支援的檔案格式" + ExtensionName);

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
                            MessageBox.Show("偵測到\"A" + (row.RowNum + 1) + "\"欄位無內容，請確認所有內容皆填寫完畢再執行操作一次。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return;
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
                            bool CheckSW = true;
                            for (int j = 0; j < ColumnsCount; j++)
                            {
                                dr[j] = row.GetCell(j) == null ? "" : row.GetCell(j).ToString();
                            }
                            DateTime DT1 = DateTime.Now;
                            //DateTime temp;
                            CheckSW = CheckSW || DateTime.TryParse(dr[1].ToString(),out DT1);
                            if (CheckSW)
                            {
                                #region 轉換檢核排班規則
                                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                                //string Msg = "";

                                WorkScheduleCheckEntry WSCE = new WorkScheduleCheckEntry();
                                WSCE.CheckTypes.Add("CIT");
                                WSCE.CheckTypes.Add("CW7");

                                string Nobr = dr[0].ToString();
                                //DateTime DT1 = Convert.ToDateTime(dr[1].ToString());
                                DateTime DT2 = DT1;

                                string RT = dr[2].ToString();
                                WorkScheduleCheckGenerator WSCG = new WorkScheduleCheckGenerator(Nobr, DT1.AddDays(-7), DT1, DT2.AddDays(7));

                                var RoteCHG = db.ROTECHG.Where(p => p.NOBR == Nobr && (p.ADATE >= DT1.AddDays(-7) || p.ADATE <= DT2.AddDays(7))).ToList();
                                foreach (var item in RoteCHG)
                                {
                                    if (WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == item.ADATE).Any())
                                        WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == item.ADATE).First().ScheduleType = item.ROTE;
                                    else
                                        WSCG.WSCD.WorkSchedules.Add(WorkScheduleCheckGenerator.NewWSD(item.ADATE, RT));
                                }

                                for (DateTime dd = DT1; dd <= DT2; dd = dd.AddDays(1))
                                {
                                    if (WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == dd).Any())
                                        WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == dd).First().ScheduleType = RT;
                                    else
                                        WSCG.WSCD.WorkSchedules.Add(WorkScheduleCheckGenerator.NewWSD(dd, RT));
                                }
                                WSCG.WSCE.CheckTypes.Add("CIT");
                                WSCG.WSCE.CheckTypes.Add("CW7");
                                var result = WSCG.Check();
                                if (result.workScheduleIssues.Count > 0)
                                {
                                    JBControls.ShowList showList = new JBControls.ShowList(result.workScheduleIssues.Select(p => new { 異常日期 = p.IssueDate, 異常敘述 = p.ErrorMessage }).CopyToDataTable());
                                    showList.Text = "異常";
                                    showList.StartPosition = FormStartPosition.CenterScreen;
                                    showList.Show();
                                    return;
                                } 
                            }
                            #endregion
                            dt.Rows.Add(dr);
                        }
                    }
                    else return;
                }
                dataGridView1.DataSource = dt;
                //MessageBox.Show("成功", "Good Job", MessageBoxButtons.OK, MessageBoxIcon.None);
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

        private void bn_ImportOK_Click(object sender, EventArgs e)
        {
            //刪除Row
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                var deleteSql = from a in att_db.ROTECHG
                                where a.NOBR == dr["員工編號"] && a.ADATE == Convert.ToDateTime(dr["調班日期"])
                                select a;

                if (deleteSql.Any())
                {
                    att_db.ROTECHG.DeleteOnSubmit(deleteSql.First());
                }
            }
            att_db.SubmitChanges();//確定刪除


            //新增Row
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ROTECHG ti = new ROTECHG();
                DataRow dr = dt.Rows[i];

                ti.NOBR = dr["員工編號"].ToString();
                ti.ADATE = Convert.ToDateTime(dr["調班日期"]);
                ti.ROTE = roteChange(dr["班別"].ToString());
                ti.CODE = "";
                ti.KEY_MAN = MainForm.USER_NAME;
                ti.KEY_DATE = DateTime.Now;

                att_db.ROTECHG.InsertOnSubmit(ti);
            }
            att_db.SubmitChanges();//確定新增

            MessageBox.Show("匯入成功。", "訊息", MessageBoxButtons.OK);
            init();


            //Close();
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
                    for (i = 0; i < ColumnsCount; i++)
                    {
                        if (i == 0) headerName = "員工編號";
                        else if (i == 1) headerName = "調班日期";
                        else if (i == 2) headerName = "班別";

                        if (row.GetCell(i) == null) break;
                        else
                        {
                            if (row.GetCell(i).ToString() != headerName) break;
                        }
                        if (i == (ColumnsCount-1))//全部都檢查過後
                        {
                            //dt.Columns.Add("YYMM");
                            //dt.Columns.Add("NOBR");

                            //將每個欄位都加進去
                            for (int j = 0; j < ColumnsCount; j++)
                            {
                                dt.Columns.Add(row.GetCell(j).ToString());
                            }
                            return true;
                        }
                    }
                    MessageBox.Show("偵測到\"" + ColumnNum(i + 1) + (row.RowNum + 1) + "\"欄位名稱錯誤，請將名稱改成\"" + headerName + "\"後再操作做一次。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else//檢查內容
                {
                    for (int i = 0; i < ColumnsCount; i++)
                    {
                        if (row.GetCell(i) == null || row.GetCell(i).ToString().Trim().Length == 0)
                        {
                            MessageBox.Show("偵測到\"" + ColumnNum(i + 1) + (row.RowNum + 1) + "\"欄位無內容，請確認所有內容皆填寫完畢後再執行操作一次。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (i == 0)
                        {
                            //確認權限是否可編輯該員工
                            if (!Sal.Function.CanModify(row.GetCell(i).ToString().Trim()))
                            {
                                MessageBox.Show("偵測到\"" +ColumnNum(i + 1) + (row.RowNum + 1) + "\"欄位的員工編號("+row.GetCell(i).ToString().Trim()+")輸入錯誤或是"+Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                return false;
                            }
                                
                        }
                        else if (i == 1)
                        {
                            //檢測日期格式有無錯誤
                            try
                            {
                                DateTime dt = Convert.ToDateTime(row.GetCell(i).ToString().Trim());
                            }
                            catch
                            {
                                MessageBox.Show("偵測到\"A" + (row.RowNum + 1) + "\"欄位格式有誤，請確認格式為「西元年/月/日」\n例如: " + DateTime.Now.ToShortDateString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }

                        else if(i==2)
                        {
                            //檢查rote
                            if (roteChange(row.GetCell(i).ToString()) == "")
                            {
                                string str = "";
                                for (int j = 0; j < roteList.Count; j++)
                                {
                                    str += roteList[j].ROTE_DISP.Trim();
                                    if (j < roteList.Count - 1) str += "、";
                                    //else if (j == roteArr.GetLength(0) - 2) str += "或";
                                }
                                MessageBox.Show("偵測到\"" + ColumnNum(i + 1) + (row.RowNum + 1) + "\"欄位內容填寫錯誤。\n可填寫內容如下：\n" + str + "。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
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
        /// 將數字轉換成Excel的行碼
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
                if (drStr.Trim() == roteList[i].ROTE_DISP.Trim()) 
                    return roteList[i].ROTE1;
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
        }
    }
}
