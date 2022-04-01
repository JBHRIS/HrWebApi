using Ionic.Zip;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JBHR.Reports.SalForm
{
    public partial class SendMailBW : JBControls.JBForm
    {
        public SendMailBW()
        {
            InitializeComponent();
        }
        private ManualResetEvent manualReset = new ManualResetEvent(true);
        Dictionary<string, Attachment> AttFileList = new Dictionary<string, Attachment>();
        Dictionary<string, string> TranFilelist = new Dictionary<string, string>();
        object parms;

        public SendMailBW(DataTable DT_4219, string yy, string mm, string _rptpath, string note, string date_t, string company, string reporttype, string note3, string note_en, DataTable rqparameter, bool salary_pa1, bool nodispot, bool displns)
        {
            InitializeComponent();
            parms = new object[] { DT_4219, yy, mm, _rptpath, note, date_t, company, reporttype, note3, note_en, rqparameter, salary_pa1, nodispot, displns };
            //BW.RunWorkerAsync(parms);
        }

        private void SendMailBW_Load(object sender, EventArgs e)
        {
            BW.RunWorkerAsync(parms);
        }

        private void BW_DoWork1(object sender, DoWorkEventArgs e)
        {
            DateTime t1;
            t1 = DateTime.Now;
            string msg = "";
            object[] parameters = e.Argument as object[];
            DataTable DT_4219 = parameters[0] as DataTable;
            DataTable rqparameter = parameters[10] as DataTable;
            string yy = parameters[1].ToString();
            string mm = parameters[2].ToString();
            string reporttype = parameters[7].ToString();
            string _rptpath = parameters[3].ToString();
            bool salary_pa1 = (parameters[11] as bool?).Value;
            string note = parameters[4].ToString();
            string company = parameters[6].ToString();
            string date_t = parameters[5].ToString();
            string note3 = parameters[8].ToString();
            string note_en = parameters[9].ToString();
            bool nodispot = (parameters[12] as bool?).Value;
            bool displns = (parameters[13] as bool?).Value;

            decimal total = DT_4219.Rows.Count;
            decimal i = 0;

            JBModule.Message.Mail Smail = new JBModule.Message.Mail();
            DataTable dt4219 = new DataTable();
            dt4219 = DT_4219.Clone();
            dt4219.TableName = "dt4219";
            string MailFrom = string.Empty;
            foreach (DataRow Row1 in rqparameter.Rows)
            {
                if (Row1["code"].ToString().Trim() == "JbMail.Sender")
                    MailFrom = Row1["value"].ToString();
            }
            if (!System.IO.Directory.Exists(JBControls.ControlConfig.GetExportPath() + yy + "年" + mm + "月" + "Salary"))//檢查目錄是否存在，不存在就建立新目錄
                System.IO.Directory.CreateDirectory(JBControls.ControlConfig.GetExportPath() + yy + "年" + mm + "月" + "Salary");


            string mailtitle = yy + "年" + mm + "月";
            if (reporttype == "9")
            {
                _rptpath += (salary_pa1) ? "Rpt_zz4219c.rdlc" : "Rpt_zz4219.rdlc";
                mailtitle += "薪資單";
            }
            else if (reporttype == "18")
            {
                _rptpath += (salary_pa1) ? "Rpt_zz4219ac.rdlc" : "Rpt_zz4219a.rdlc";
                mailtitle += note3;
            }

            AttFileList = new Dictionary<string, Attachment>();
            TranFilelist = new Dictionary<string, string>();
            foreach (DataRow Row in DT_4219.Rows)
            {
                if (this.BW.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                if (Row["email"].ToString().Trim() != "")
                {
                    BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(i) / Convert.ToDecimal(total) * 100), string.Format("正在產生{0}的檔案", Row["nobr"].ToString()));

                    dt4219.ImportRow(Row);
                    ReportViewer RptViewer = new ReportViewer();
                    RptViewer.ProcessingMode = ProcessingMode.Local;
                    RptViewer.LocalReport.ReportPath = _rptpath;
                    RptViewer.LocalReport.DataSources.Clear();
                    if ((reporttype == "9" && !salary_pa1) || (reporttype == "18" && !salary_pa1))
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note", note) });
                    if (reporttype == "9")
                    {
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("NoDispOt", nodispot.ToString()) });
                        if (!salary_pa1) RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("DispLns", displns.ToString()) });
                    }
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Company", company) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Datet", date_t) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("YY", yy) });
                    RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("MM", mm) });
                    if (reporttype == "18")
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("ReportName", note3) });
                    if (reporttype == "9" && salary_pa1)
                        RptViewer.LocalReport.SetParameters(new ReportParameter[] { new ReportParameter("Note_EN", note_en) });
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource("SalDataSet_zz4219", dt4219));
                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;
                    //成功加密發送檔案
                    //string TempFile = JBControls.ControlConfig.GetExportPath() + @"Salary\output.pdf";
                    string TranFile = JBControls.ControlConfig.GetExportPath() + yy + "年" + mm + "月" + @"Salary\out.pdf";
                    string TranFile1 = JBControls.ControlConfig.GetExportPath() + yy + "年" + mm + "月" + @"Salary\" + Row["nobr"].ToString().Trim() + ".pdf";
                    byte[] bytes = RptViewer.LocalReport.Render(
                       "PDF", null, out mimeType, out encoding, out extension,
                       out streamids, out warnings);
                    //using (FileStream fs = new FileStream(TranFile, FileMode.Create))
                    //{
                    //    fs.Write(bytes, 0, bytes.Length);
                    //}
                    ////RptViewer.Dispose();
                    //PdfReader reader = new PdfReader(TranFile);
                    ////iTextSharp.text.pdf加密程式
                    //Stream os = (Stream)(new FileStream(TranFile1, FileMode.Create));
                    //PdfEncryptor.Encrypt(reader, os, true, Row["password"].ToString().Trim(), Row["password"].ToString().Trim(), PdfWriter.AllowScreenReaders);
                    //reader.Close();
                    //reader.Dispose();

                    using (Stream input = new MemoryStream(bytes))
                    {
                        using (Stream output = new FileStream(TranFile1, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            PdfReader reader = new PdfReader(input);
                            PdfEncryptor.Encrypt(reader, output, true, Row["password"].ToString().Trim(), Row["password"].ToString().Trim(), PdfWriter.ALLOW_SCREENREADERS);
                        }
                    }

                    //string[] txtList = Directory.GetFiles(JBControls.ControlConfig.GetExportPath() + yy + "年" + mm + "月" + @"Salary", "out.pdf");
                    //foreach (string f in txtList)
                    //{
                    //    File.Delete(f);
                    //}

                    Attachment AttFild = new Attachment(TranFile1, System.Net.Mime.MediaTypeNames.Application.Octet);
                    AttFileList.Add( string.Format("{0},{1}", Row["nobr"].ToString().Trim(), Row["email"].ToString().Trim()), AttFild);
                    TranFilelist.Add(AttFild.Name, TranFile1);
                    //AttFild.Dispose();
                    File.Delete(TranFile);
                    //File.Delete(ZipFild);
                    dt4219.Clear();
                    RptViewer.LocalReport.ReleaseSandboxAppDomain();
                    i++;
                    if (manualReset != null)
                        manualReset.WaitOne();
                    RptViewer.Clear();
                    RptViewer.Dispose();
                }
            }
            //Directory.Delete(JBControls.ControlConfig.GetExportPath() + @"Salary", true);
            BW.ReportProgress(100, "產生檔案完成");
            total = AttFileList.Count;
            i = 0;
            foreach (var item in AttFileList)
            {
                if (this.BW.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                string[] splits = item.Key.Split(new char[] { ',' });
                BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(i) / Convert.ToDecimal(total) * 100), 
                    string.Format("正在寄送員工編號{0}->{1}的薪資單", splits[0], splits[1]));
                Smail.SendMailWithQueue(new MailAddress(MailFrom), new MailAddress(splits[1]), mailtitle, note, new List<Attachment> { item.Value });
                JBModule.Message.TextLog.WriteLog("薪資單發送至：" + splits[0] + "->" + splits[1]);
                item.Value.Dispose();
                File.Delete(TranFilelist[item.Value.Name]);
                i++;
                //Thread.Sleep(1000);
                if (manualReset != null)
                    manualReset.WaitOne();
            }
            BW.ReportProgress(100, "完成");
            TimeSpan ts = DateTime.Now - t1;
            msg = string.Format("共耗時: {0}時{1}分{2}秒", ts.Hours, ts.Minutes, ts.Seconds);
            e.Result = msg;
        }
        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!this.BW.CancellationPending)
            {
                toolStripProgressBar1.Value = e.ProgressPercentage;
                trpState.Text = e.UserState.ToString();
            }
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Result != null && e.Result.ToString().Trim().Length > 0)
                MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            foreach (var item in AttFileList)
            {
                item.Value.Dispose();
                File.Delete(TranFilelist[item.Value.Name]);
            }
            btnCancel.Text = "離開";
            btnPlayStop.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendMailBW_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BW.IsBusy)
                BW.CancelAsync();
            BW.Dispose();
        }

        private void btnPlayStop_Click(object sender, EventArgs e)
        {
            if (btnPlayStop.Text == "暫停")
            {
                manualReset.Reset();//暂停当前线程的工作，发信号给waitOne方法，阻塞
                btnPlayStop.Text = "繼續";
            }
            else
            {
                manualReset.Set();//继续某个线程的工作
                btnPlayStop.Text = "暫停";
            }
        }
    }
}
