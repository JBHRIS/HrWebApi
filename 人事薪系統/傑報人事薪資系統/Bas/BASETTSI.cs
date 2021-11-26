using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JBHR.Bas
{
    public partial class BASETTSI : JBControls.JBForm
    {
        public BASETTSI()
        {
            InitializeComponent();
        }
        public DataSet DataSource;
        public DataTable TtsData;
        private void btnBrower_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                try
                {
                    DataSource = JBModule.Data.CNPOI.ReadExcelToDataSet(path);
                    comboBoxSheet.Items.Clear();
                    foreach (DataTable itm in DataSource.Tables)
                    {
                        comboBoxSheet.Items.Add(itm.TableName);
                    }
                    txtFilePath.Text = path;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.Sal.ExcelIOError + Environment.NewLine + ex.Message, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TtsData != null)
            {
                Sal.PreviewForm vw = new Sal.PreviewForm();
                vw.Text = "資料預覽";
                vw.DataTable = TtsData;
                vw.Width = 800;
                vw.ShowDialog();
            }
        }

        private void comboBoxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            TtsData = DataSource.Tables[comboBoxSheet.SelectedItem.ToString().Trim()];

            cbxNobr.Items.Clear();
            cbxCindt.Items.Clear();
            cbxDepts.Items.Clear();
            cbxDeptm.Items.Clear();
            cbxCard.Items.Clear();
            cbxDI.Items.Clear();
            cbxJob.Items.Clear();
            cbxEmpcd.Items.Clear();
            cbxMemo.Items.Clear();
            cbxTtscd.Items.Clear();
            comboBoxJobo.Items.Clear();
            //cbxSupport.Items.Clear();
            cbxName.Items.Clear();
            foreach (DataColumn col in TtsData.Columns)
            {
                cbxNobr.Items.Add(col.ColumnName);
                cbxCindt.Items.Add(col.ColumnName);
                cbxDept.Items.Add(col.ColumnName);
                cbxDepts.Items.Add(col.ColumnName);
                cbxDeptm.Items.Add(col.ColumnName);
                cbxJob.Items.Add(col.ColumnName);
                cbxJobl.Items.Add(col.ColumnName);
                cbxJobs.Items.Add(col.ColumnName);
                cbxCard.Items.Add(col.ColumnName);
                cbxDI.Items.Add(col.ColumnName);
                cbxEmpcd.Items.Add(col.ColumnName);
                cbxMemo.Items.Add(col.ColumnName);
                cbxTtscd.Items.Add(col.ColumnName);
                //cbxSupport.Items.Add(col.ColumnName);
                comboBoxJobo.Items.Add(col.ColumnName);
                cbxName.Items.Add(col.ColumnName);
            }
            CombBoxSettingDefault();
            //txtYymm.Focus();
        }
        void CombBoxSettingDefault()
        {
            if (cbxNobr.Items.Contains(lblNobr.Text)) cbxNobr.Text = lblNobr.Text;

            if (cbxName.Items.Contains(lblName.Text)) cbxName.Text = lblName.Text;

            //if (cbxCindt.Items.Contains(lblCindt.Text)) cbxCindt.Text = lblCindt.Text;

            if (cbxDept.Items.Contains(lblDept.Text)) cbxDept.Text = lblDept.Text;

            if (cbxDepts.Items.Contains(lblDepts.Text)) cbxDepts.Text = lblDepts.Text;

            if (cbxDeptm.Items.Contains(lblDepta.Text)) cbxDeptm.Text = lblDepta.Text;

            if (cbxCard.Items.Contains(lblCard.Text)) cbxCard.Text = lblCard.Text;

            if (cbxDI.Items.Contains(lblDI.Text)) cbxDI.Text = lblDI.Text;

            if (cbxJob.Items.Contains(lblJob.Text)) cbxJob.Text = lblJob.Text;

            if (cbxJobs.Items.Contains(lblJobs.Text)) cbxJobs.Text = lblJobs.Text;

            if (cbxJobl.Items.Contains(lblJobl.Text)) cbxJobl.Text = lblJobl.Text;

            if (cbxEmpcd.Items.Contains(lblEmpcd.Text)) cbxEmpcd.Text = lblEmpcd.Text;

            if (cbxMemo.Items.Contains(lblMemo.Text)) cbxMemo.Text = lblMemo.Text;

            if (cbxTtscd.Items.Contains(lblTtscd.Text)) cbxTtscd.Text = lblTtscd.Text;

            if (comboBoxJobo.Items.Contains(lblJobo.Text)) comboBoxJobo.Text = lblJobo.Text;
            //if (cbxSupport.Items.Contains(lblSupport.Text)) cbxSupport.Text = lblSupport.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Run(true);
            ResetBasetts(Convert.ToDateTime(txtAdate.Text));
            ResetBasetts1(Convert.ToDateTime(txtAdate.Text));
        }
        void Run(bool isOK)
        {
            Sal.SalaryDS.BASETTSDataTable dtBASETTS = new Sal.SalaryDS.BASETTSDataTable();
            Sal.SalaryDSTableAdapters.BASETTSTableAdapter adBASETTS = new Sal.SalaryDSTableAdapters.BASETTSTableAdapter();
            int error = 0, mapping = 0;
            Sal.SalaryDS.BASETTSDataTable newBasetts = new Sal.SalaryDS.BASETTSDataTable();
            string nobr, name, ttscode, dept, depts, deptm, job, jobs, jobl, jobo, wordcd, di, empcd, ttscd, memo, card, support;
            int rowCount = 0;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var dtDept = (from a in db.DEPT
                          where
                              db.GetCodeFilter("DEPT", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          select a).ToList();
            var dtDepts = (from a in db.DEPTS
                           where
                               db.GetCodeFilter("DEPTS", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                           select a).ToList();
            var dtDeptm = (from a in db.DEPTA
                           where
                               db.GetCodeFilter("DEPTA", a.D_NO, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                           select a).ToList();
            var dtJob = (from a in db.JOB
                         where
                             db.GetCodeFilter("JOB", a.JOB1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                         select a).ToList();
            var dtJobs = (from a in db.JOBS
                          where
                              db.GetCodeFilter("JOBS", a.JOBS1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          select a).ToList();
            var dtJobl = (from a in db.JOBL
                          where
                              db.GetCodeFilter("JOBL", a.JOBL1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          select a).ToList();
            var dtJobo = (from a in db.JOBO
                          select a).ToList();
            var dtTtscd = (from a in db.TTSCD
                           where
                               db.GetCodeFilter("TTSCD", a.TTSCD1, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                           select a).ToList();
            var dtEmpcd = (from a in db.EMPCD select a).ToList();
            var dtYN = new List<string>();
            dtYN.Add("Y");
            dtYN.Add("N");
            var dtDI = new List<string>();
            dtDI.Add("D");
            dtDI.Add("I");
            Dictionary<int, JBModule.Data.CNPOI.ExcelRowState> stateList = new Dictionary<int, JBModule.Data.CNPOI.ExcelRowState>();

            System.Data.SqlClient.SqlTransaction trans = null;
            if (adBASETTS.Connection.State != ConnectionState.Open) adBASETTS.Connection.Open();
            trans = adBASETTS.Connection.BeginTransaction();
            adBASETTS.Transaction = trans;

            if (!isOK || MessageBox.Show("確定要執行批次異動?", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
            {
                DateTime adate, cindt;
                adate = Convert.ToDateTime(txtAdate.Text);
                if (TtsData != null)
                    foreach (DataRow row in TtsData.Rows)
                    {
                        rowCount++;
                        if (TtsData.Columns.Contains(cbxNobr.Text)) nobr = row[cbxNobr.Text].ToString().Trim();
                        else nobr = cbxNobr.Text;

                        if (TtsData.Columns.Contains(cbxName.Text)) name = row[cbxName.Text].ToString().Trim();
                        else name = cbxName.Text;
                        adBASETTS.FillByNobrDate(dtBASETTS, nobr, adate);
                        var baseSQL = from a in db.BASE where a.NOBR == nobr select new { a.NOBR, a.NAME_C };
                        if (dtBASETTS.Rows.Count > 0)
                        {
                            var data = dtBASETTS[0];
                            if (Convert.ToDateTime(data["adate"]) == adate)
                            {
                                error++;//異動時間不可以相同
                                if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.Error;
                                else
                                    stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.Error);
                                continue;
                            }
                            if (Convert.ToDateTime(data["ddate"]) != new DateTime(9999,12,31))
                            {
                                error++;//必須是最新一筆
                                if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.Error;
                                else
                                    stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.Error);
                                continue;
                            }
                            if (cbxName.Text.Trim().Length > 0)
                                if (baseSQL.Any())//姓名欄位有設定才會檢察
                                {
                                    var name_c = baseSQL.First().NAME_C;
                                    if (name.Trim().ToUpper() != name_c.Trim().ToUpper())//名字對應不對
                                    {
                                        mapping++;//異動時間不可以相同
                                        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                        else
                                            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                        continue;
                                    }
                                }
                                else
                                {
                                    error++;//異動時間不可以相同
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.Error;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.Error);
                                    continue;
                                }
                            data.SetAdded();
                            ttscode = cbxTtscode.SelectedValue.ToString().Trim();

                            if (ttscode == "1" && "2,3,5".IndexOf(data["ttscode"].ToString().Trim()) == -1)
                            {
                                error++;
                                if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.Error;
                                else
                                    stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.Error);
                                continue;
                            }
                            else if (ttscode == "2" && "1,4,6".IndexOf(data["ttscode"].ToString().Trim()) == -1)
                            {
                                error++;
                                if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.Error;
                                else
                                    stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.Error);
                                continue;
                            }
                            else if (ttscode == "3" && "1,4,6".IndexOf(data["ttscode"].ToString().Trim()) == -1)
                            {
                                error++;
                                if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.Error;
                                else
                                    stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.Error);
                                continue;
                            }
                            else if (ttscode == "4" && "3".IndexOf(data["ttscode"].ToString().Trim()) == -1)
                            {
                                error++;
                                if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.Error;
                                else
                                    stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.Error);
                                continue;
                            }
                            else if (ttscode == "5" && "4".IndexOf(data["ttscode"].ToString().Trim()) == -1)
                            {
                                error++;
                                if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.Error;
                                else
                                    stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.Error);
                                continue;
                            }
                            else if (ttscode == "6" && "1,4,6".IndexOf(data["ttscode"].ToString().Trim()) == -1)
                            {
                                error++;
                                if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.Error;
                                else
                                    stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.Error);
                                continue;
                            }
                            data["ttscode"] = ttscode;
                            data["adate"] = adate;
                            if (cbxCindt.Text.Trim().Length > 0)
                                if (TtsData.Columns.Contains(cbxCindt.Text)) data["cindt"] = Convert.ToDateTime(row[cbxCindt.Text].ToString().Trim());

                            if (cbxDept.Text.Trim().Length > 0)
                            {
                                if (TtsData.Columns.Contains(cbxDept.Text))
                                {
                                    data["dept"] = row[cbxDept.Text].ToString().Trim();
                                    if (!dtDept.Where(p => p.D_NO_DISP.Trim() == data["dept"].ToString().Trim()).Any())
                                    {
                                        error++;
                                        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                        else
                                            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                        continue;
                                    }
                                    else data["dept"] = dtDept.Where(p => p.D_NO_DISP.Trim() == data["dept"].ToString().Trim()).First().D_NO;
                                }
                                else
                                {
                                    mapping++;
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                    continue;
                                }
                            }
                            //else dept = cbxDept.Text;

                            if (cbxDepts.Text.Trim().Length > 0)
                            {
                                if (TtsData.Columns.Contains(cbxDepts.Text))
                                {
                                    data["depts"] = row[cbxDepts.Text].ToString().Trim();
                                    if (!dtDepts.Where(p => p.D_NO_DISP.Trim() == data["depts"].ToString().Trim()).Any())//
                                    {
                                        error++;
                                        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                        else
                                            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                        continue;
                                    }
                                    else data["depts"] = dtDepts.Where(p => p.D_NO_DISP.Trim() == data["depts"].ToString().Trim()).First().D_NO;
                                }
                                else
                                {
                                    mapping++;
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                    continue;
                                }
                            }
                            //else depts = cbxDepts.Text;

                            if (cbxDeptm.Text.Trim().Length > 0)
                            {
                                if (TtsData.Columns.Contains(cbxDeptm.Text))
                                {
                                    data["deptm"] = row[cbxDeptm.Text].ToString().Trim();
                                    if (!dtDeptm.Where(p => p.D_NO_DISP.Trim() == data["deptm"].ToString().Trim()).Any())//
                                    {
                                        error++;
                                        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                        else
                                            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                        continue;
                                    }
                                    else data["deptm"] = dtDeptm.Where(p => p.D_NO_DISP.Trim() == data["deptm"].ToString().Trim()).First().D_NO;
                                }
                                else
                                {
                                    mapping++;
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                    continue;
                                }
                            }
                            //else depta = cbxDepta.Text;

                            if (cbxJob.Text.Trim().Length > 0)
                            {
                                if (TtsData.Columns.Contains(cbxJob.Text))
                                {
                                    data["job"] = row[cbxJob.Text].ToString().Trim();
                                    if (!dtJob.Where(p => p.JOB_DISP.Trim() == data["job"].ToString().Trim()).Any())//
                                    {
                                        error++;
                                        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                        else
                                            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                        continue;
                                    }
                                    else data["job"] = dtJob.Where(p => p.JOB_DISP.Trim() == data["job"].ToString().Trim()).First().JOB1;
                                }
                                else
                                {
                                    mapping++;
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                    continue;
                                }
                            }
                            if (cbxJobs.Text.Trim().Length > 0)
                            {
                                if (TtsData.Columns.Contains(cbxJobs.Text))
                                {
                                    data["jobs"] = row[cbxJobs.Text].ToString().Trim();
                                    if (!dtJobs.Where(p => p.JOBS_DISP.Trim() == data["jobs"].ToString().Trim()).Any())//
                                    {
                                        error++;
                                        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                        else
                                            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                        continue;
                                    }
                                    else data["jobs"] = dtJobs.Where(p => p.JOBS_DISP.Trim() == data["jobs"].ToString().Trim()).First().JOBS1;
                                }
                                else
                                {
                                    mapping++;
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                    continue;
                                }
                            }

                            if (cbxJobl.Text.Trim().Length > 0)
                            {
                                if (TtsData.Columns.Contains(cbxJobl.Text))
                                {
                                    data["jobl"] = row[cbxJobl.Text].ToString().Trim();
                                    if (!dtJobl.Where(p => p.JOBL_DISP.Trim() == data["jobl"].ToString().Trim()).Any())//
                                    {
                                        error++;
                                        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                        else
                                            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                        continue;
                                    }
                                    else data["jobl"] = dtJobl.Where(p => p.JOBL_DISP.Trim() == data["jobl"].ToString().Trim()).First().JOBL1;
                                }
                                else
                                {
                                    mapping++;
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                    continue;
                                }
                            }

                            if (comboBoxJobo.Text.Trim().Length > 0)
                            {
                                if (TtsData.Columns.Contains(comboBoxJobo.Text))
                                {
                                    data["jobo"] = row[comboBoxJobo.Text].ToString().Trim();
                                    if (!dtJobo.Where(p => p.JOBO1.Trim() == data["jobo"].ToString().Trim()).Any())//
                                    {
                                        error++;
                                        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                        else
                                            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                        continue;
                                    }
                                    else data["jobo"] = dtJobo.Where(p => p.JOBO1.Trim() == data["jobo"].ToString().Trim()).First().JOBO1;
                                }
                                else
                                {
                                    mapping++;
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                    continue;
                                }
                            }

                            if (cbxMemo.Text.Trim().Length > 0)
                                if (TtsData.Columns.Contains(cbxMemo.Text)) data["meno"] = row[cbxMemo.Text].ToString().Trim();
                                else
                                {
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                }


                            //else memo = cbxMemo.Text;

                            if (cbxTtscd.Text.Trim().Length > 0)
                            {
                                if (TtsData.Columns.Contains(cbxTtscd.Text))
                                {
                                    data["ttscd"] = row[cbxTtscd.Text].ToString().Trim();
                                    if (!dtTtscd.Where(p => p.TTSCD_DISP.Trim() == data["ttscd"].ToString().Trim()).Any())//
                                    {
                                        error++;
                                        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                        else
                                            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                        continue;
                                    }
                                    else data["ttscd"] = dtTtscd.Where(p => p.TTSCD_DISP.Trim() == data["ttscd"].ToString().Trim()).First().TTSCD1;
                                }
                                else
                                {
                                    mapping++;
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                    continue;
                                }
                            }

                            if (cbxDI.Text.Trim().Length > 0)
                            {
                                if (TtsData.Columns.Contains(cbxDI.Text))
                                {
                                    data["di"] = row[cbxDI.Text].ToString().Trim();
                                    if (!dtDI.Contains(data["di"].ToString().Trim()))
                                    {
                                        error++;
                                        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                        else
                                            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                        continue;
                                    }
                                }
                                else
                                {
                                    mapping++;
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                    continue;
                                }
                            }

                            if (cbxEmpcd.Text.Trim().Length > 0)
                            {
                                if (TtsData.Columns.Contains(cbxEmpcd.Text))
                                {
                                    data["empcd"] = row[cbxEmpcd.Text].ToString().Trim();
                                    if (!dtEmpcd.Where(p => p.EMPCD1.Trim() == data["empcd"].ToString().Trim()).Any())//
                                    {
                                        error++;
                                        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                        else
                                            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                        continue;
                                    }
                                }
                                else
                                {
                                    mapping++;
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                    continue;
                                }
                            }

                            if (cbxCard.Text.Trim().Length > 0)
                            {
                                if (TtsData.Columns.Contains(cbxCard.Text))
                                {
                                    data["card"] = row[cbxCard.Text].ToString().Trim();
                                    if (!dtYN.Contains(data["card"].ToString().Trim()))
                                    {
                                        error++;
                                        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                        else
                                            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                        continue;
                                    }
                                }
                                else
                                {
                                    mapping++;
                                    if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                                    else
                                        stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                                    continue;
                                }
                            }

                            //if (cbxSupport.Text.Trim().Length > 0)
                            //{
                            //    if (TtsData.Columns.Contains(cbxCard.Text))
                            //    {
                            //        data["note"] = row[cbxCard.Text].ToString().Trim();
                            //        if (!dtYN.Contains(data["note"].ToString().Trim()))
                            //        {
                            //            error++;
                            //            if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                            //            else
                            //                stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                            //            continue;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        mapping++;
                            //        if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.DataCheck;
                            //        else
                            //            stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.DataCheck);
                            //        continue;
                            //    }
                            //}
                            //else support = cbxSupport.Text;
                            data["key_date"] = DateTime.Now;
                            data["key_man"] = MainForm.USER_NAME;
                            newBasetts.ImportRow(data);
                        }
                        else
                        {
                            error++;
                            if (stateList.ContainsKey(rowCount)) stateList[rowCount] = JBModule.Data.CNPOI.ExcelRowState.Error;
                            else
                                stateList.Add(rowCount, JBModule.Data.CNPOI.ExcelRowState.Error);
                            continue;
                        }
                    }
            }
            if (!isOK)
            {
                Bas.BasDS.BASETTSDataTable myBasetts = new BasDS.BASETTSDataTable();
                foreach (DataColumn dc in myBasetts.Columns)
                {
                    if (newBasetts.Columns.Contains(dc.ColumnName)) newBasetts.Columns[dc.ColumnName].ColumnName = dc.Caption;
                }
                Sal.PreviewForm frm = new Sal.PreviewForm();
                frm.Width = 800;
                frm.Height = 600;
                frm.DataTable = newBasetts;
                frm.ShowDialog();
            }
            else
            {
                if (error + mapping == 0)
                {
                    try
                    {
                        adBASETTS.Update(newBasetts);
                        trans.Commit();
                        MessageBox.Show("匯入完成");
                    }
                    catch (Exception ex)
                    {
                        JBModule.Message.TextLog.WriteLog(ex);
                        trans.Rollback();
                        MessageBox.Show("匯入時發生異常" + Environment.NewLine + ex.Message, "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("匯入時發生錯誤");
                }
            }
            if (error + mapping > 0)
            {
                MessageBox.Show("資料錯誤，請檢查匯入的Excel");
            }
            JBModule.Data.CNPOI.SetExcelRowState(txtFilePath.Text, comboBoxSheet.Text, stateList);
        }

        private void BASETTSI_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'basDS.TTSCODE' 資料表。您可以視需要進行移動或移除。
            this.tTSCODETableAdapter.Fill(this.basDS.TTSCODE);
            txtAdate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            //if (cbxTtscode.Items.Contains("6")) 
            cbxTtscode.SelectedValue = "6";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Run(false);
        }
        void ResetBasetts(DateTime date)
        {
            Sal.SalaryMDDataContext db = new Sal.SalaryMDDataContext();
            var sql = from a in db.BASETTS
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      where (a.ADATE != b.ADATE || a.DDATE != b.DDATE || a.TTSCODE != b.TTSCODE)
                      && a.ADATE <= b.DDATE.Value && a.DDATE >= b.ADATE
                      && date >= a.ADATE && date <= a.DDATE
                      && date >= b.ADATE && date <= b.DDATE
                      //orderby new { a.NOBR,a.ADATE} descending
                      group a by a.NOBR into gp
                      where gp.Count() > 1
                      select gp;

            foreach (var itm in sql)
            {
                DateTime ddate = new DateTime(9999, 12, 31);
                foreach (var r in itm.OrderByDescending(p => p.ADATE))
                {
                    r.DDATE = ddate;
                    ddate = r.ADATE.AddDays(-1);
                }
            }
            db.SubmitChanges();
        }
        void ResetBasetts1(DateTime date)
        {
            Sal.SalaryMDDataContext db = new Sal.SalaryMDDataContext();
            var sql = from a in db.BASETTS
                      where !(from b in db.BASETTS where b.DDATE == new DateTime(9999, 12, 31) && b.NOBR == a.NOBR select b).Any()
                      group a by a.NOBR;
            foreach (var itm in sql)
            {
                DateTime ddate = new DateTime(9999, 12, 31);
                foreach (var r in itm.OrderByDescending(p => p.ADATE))
                {
                    r.DDATE = ddate;
                    ddate = r.ADATE.AddDays(-1);
                }
            }
            db.SubmitChanges();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ResetBasetts1(Convert.ToDateTime(txtAdate.Text));
        }
    }
}
