/* ======================================================================================================
 * 功能名稱：寄送薪資單
 * 功能代號：MailSalary
 * 功能路徑：
 * 檔案路徑：~\customer\jbhr2\人事薪系統\傑報人事薪資系統\Reports\SalForm\MailSalary.cs
 * 功能用途：
 *  用於寄送薪資單
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/08/13    Daniel Chih    Ver 1.0.01     1. 修正寄送薪資單的Mail Body部分內文，增加 AttFild 的 Dispose
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/08/13
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Net.Mail;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using System.Collections;
using System.Drawing;
using Microsoft.Reporting.WinForms;
using Ionic.Zip;


namespace JBHR.Reports.SalForm
{
    
    class MailSalary
    {
        private const string T_FONT = "textfont";
        static SendMailBW sendMailBW = null;
        public static void Get_SendSalary1(DataTable DT_4219, string yy, string mm, string _rptpath, string note, string date_t, string company, string reporttype, string note3, string note_en, DataTable rqparameter, bool salary_pa1, bool nodispot,bool displns, DateTime SendDate)
        {
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ42", MainForm.COMPANY);
            string SendMailBWSW = AppConfig.GetConfig("SendMailBWSW").GetString("N");
            string SendMailType = AppConfig.GetConfig("SendMailType").GetString("1");
            if (SendMailBWSW == "Y")
            {
                if (sendMailBW == null)
                {
                    sendMailBW = new SendMailBW(DT_4219, yy, mm, _rptpath, note, date_t, company, reporttype, note3, note_en, rqparameter, salary_pa1, nodispot, displns);
                    sendMailBW.Show();
                    sendMailBW.Disposed += SendMailBW_Disposed;
                }
                else
                {
                    MessageBox.Show("已有寄信排程，請稍後在執行.");
                } 
            }
            else
            {
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
                foreach (DataRow Row in DT_4219.Rows)
                {
                    if (Row["email"].ToString().Trim() != "")
                    {
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
                        using (FileStream fs = new FileStream(TranFile, FileMode.Create))
                        {
                            fs.Write(bytes, 0, bytes.Length);
                        }
                        RptViewer.Dispose();
                        PdfReader reader = new PdfReader(TranFile);
                        //iTextSharp.text.pdf加密程式
                        Stream os = (Stream)(new FileStream(TranFile1, FileMode.Create));
                        PdfEncryptor.Encrypt(reader, os, true, Row["password"].ToString().Trim(), Row["password"].ToString().Trim(), PdfWriter.ALLOW_PRINTING);
                        reader.Dispose();
                        string[] txtList = Directory.GetFiles(JBControls.ControlConfig.GetExportPath() + yy + "年" + mm + "月" + @"Salary", "out.pdf");
                        foreach (string f in txtList)
                        {
                            File.Delete(f);
                        }

                        Attachment AttFild = new Attachment(TranFile1, System.Net.Mime.MediaTypeNames.Application.Octet);
                        List<Attachment> listFild = new List<Attachment>();
                        listFild.Add(AttFild);

                        if (SendMailType == "2")
                        {
                            //由排程發送
                            Smail.AddMailQueueWithFileService(Row["email"].ToString().Trim(), mailtitle, mailtitle, listFild, SendDate);
                        }
                        else if(SendMailType == "1")
                        {
                            //直接發送
                            //Email內容部分改成讀Note欄位的文字 - Modified By Daniel Chih - 2021/08/13
                            Smail.SendMailWithQueue(new MailAddress(MailFrom), new MailAddress(Row["email"].ToString().Trim()), mailtitle, note, listFild, SendDate);
                        }
                        else
                        {
                            //直接發送
                            //Email內容部分改成讀Note欄位的文字 - Modified By Daniel Chih - 2021/08/13
                            Smail.SendMailWithQueue(new MailAddress(MailFrom), new MailAddress(Row["email"].ToString().Trim()), mailtitle, note, listFild, SendDate);
                        }

                        JBModule.Message.TextLog.WriteLog("薪資單發送至員工編號：" + Row["nobr"].ToString() + "->" + Row["email"].ToString());
                        //os.Close();
                        //os.Dispose();
                        //=====================

                        File.Delete(TranFile);
                        dt4219.Clear();
                        listFild.Clear();
                        //釋放
                        AttFild.Dispose();
                    }

                }
                //Directory.Delete(JBControls.ControlConfig.GetExportPath() + @"Salary", true);
            }
        }

        private static void SendMailBW_Disposed(object sender, EventArgs e)
        {
            sendMailBW = null;
        }

        public static void Get_SendSalary(DataTable DT_4219, string yy, string mm, string _rptpath, string note, DataTable DT_sys10, string company)
        {
            string smtpserver = ""; string sendmail = ""; string smtpid = ""; string smtppw = "";
            if (DT_sys10.Rows.Count > 0)
            {
                smtpserver = DT_sys10.Rows[0]["smtpserver"].ToString();
                sendmail = DT_sys10.Rows[0]["sendmail"].ToString();
                smtpid = DT_sys10.Rows[0]["smtpid"].ToString();
                smtppw = DT_sys10.Rows[0]["smtppw"].ToString();
            }
            if (smtpserver.Trim() == "")
            {
                MessageBox.Show("請設定郵件主機！", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            if (sendmail.Trim() == "")
            {
                MessageBox.Show("請設定郵件信箱！", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
                return;
            }
            string pdfTemplate = _rptpath + "zz42a.pdf";
            PdfReader pdfReader = new PdfReader(pdfTemplate);
            StringBuilder sb = new StringBuilder();
            //foreach (DictionaryEntry de in pdfReader.AcroFields.Fields)
            foreach (KeyValuePair<string, AcroFields.Item> de in pdfReader.AcroFields.Fields)
            {
                sb.Append(de.Key.ToString() + Environment.NewLine);
            }
            //pdfTemplate = _rptpath + "zz42a.pdf";
            //string WriterFile = @"c:\Temp\ZZ42b.pdf";
            //Document document = new Document();
            //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(WriterFile, FileMode.Create));
            //document.Open();
            ArrayList alFiles = new ArrayList();

            string newFile_ex = @"c:\Temp\ZZ42_x.pdf";
            foreach (DataRow Row in DT_4219.Rows)
            {                
                string newFile = @"c:\Temp\ZZ42.pdf";
                alFiles.Add(newFile);
                pdfReader = new PdfReader(pdfTemplate);

                Stream os = (Stream)(new FileStream(newFile, FileMode.Create));

                PdfStamper pdfStamper = new PdfStamper(pdfReader,os);
                AcroFields pdfFormFields = pdfStamper.AcroFields;
                string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\..\Fonts\kaiu.ttf";
                BaseFont bfChinese = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, //橫式中文
                    BaseFont.NOT_EMBEDDED);

                //只有顯示中文才要加這一段程式
                pdfFormFields.SetFieldProperty("company", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("yy", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("mm", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("dept", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("nobr", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("account", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("date", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldat1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldat2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldat3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldat4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldat5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldau1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldau2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldau3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldau4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldau5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt11", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt12", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt13", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldbt14", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct11", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct12", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct13", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Fldct14", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FABA10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Flddt3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Flddt4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Flddt5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Flddt7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("Flddt8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("note", T_FONT, bfChinese, null);

                pdfFormFields.SetField("company", company);
                pdfFormFields.SetField("yy", yy);
                pdfFormFields.SetField("mm", mm);
                pdfFormFields.SetField("dept" , Row["dept"].ToString().Trim() + " " + Row["d_name"].ToString().Trim());
                pdfFormFields.SetField("nobr", Row["nobr"].ToString().Trim() + " " + Row["name_c"].ToString().Trim());
                pdfFormFields.SetField("account", Row["account_no"].ToString().Trim());
                pdfFormFields.SetField("date", DateTime.Parse(Row["adate"].ToString()).ToString("yyyy/MM/dd"));
                pdfFormFields.SetField("account", Row["account_no"].ToString().Trim());
                if (!Row.IsNull("Fldat1")) pdfFormFields.SetField("Fldat1", Row["Fldat1"].ToString().Trim());
                if (!Row.IsNull("Fldat2")) pdfFormFields.SetField("Fldat2", Row["Fldat2"].ToString().Trim());
                if (!Row.IsNull("Fldat3")) pdfFormFields.SetField("Fldat3", Row["Fldat3"].ToString().Trim());
                if (!Row.IsNull("Fldat4")) pdfFormFields.SetField("Fldat4", Row["Fldat4"].ToString().Trim());
                if (!Row.IsNull("Fldat5")) pdfFormFields.SetField("Fldat5", Row["Fldat5"].ToString().Trim());
                if (!Row.IsNull("Flda1")) pdfFormFields.SetField("Flda1",decimal.Parse(Row["Flda1"].ToString()).ToString());
                if (!Row.IsNull("Flda2")) pdfFormFields.SetField("Flda2", decimal.Parse(Row["Flda2"].ToString()).ToString());
                if (!Row.IsNull("Flda3")) pdfFormFields.SetField("Flda3", decimal.Parse(Row["Flda3"].ToString()).ToString());
                if (!Row.IsNull("Flda4")) pdfFormFields.SetField("Flda4", decimal.Parse(Row["Flda4"].ToString()).ToString());
                if (!Row.IsNull("Flda5")) pdfFormFields.SetField("Flda5", decimal.Parse(Row["Flda5"].ToString()).ToString());
                if (!Row.IsNull("Fldau1")) pdfFormFields.SetField("Fldau1", Row["Fldau1"].ToString().Trim());
                if (!Row.IsNull("Fldau2")) pdfFormFields.SetField("Fldau2", Row["Fldau2"].ToString().Trim());
                if (!Row.IsNull("Fldau3")) pdfFormFields.SetField("Fldau3", Row["Fldau3"].ToString().Trim());
                if (!Row.IsNull("Fldau4")) pdfFormFields.SetField("Fldau4", Row["Fldau4"].ToString().Trim());
                if (!Row.IsNull("Fldau5")) pdfFormFields.SetField("Fldau5", Row["Fldau5"].ToString().Trim());
                if (!(Row.IsNull("Fldbt1"))) pdfFormFields.SetField("Fldbt1", Row["Fldbt1"].ToString().Trim());
                if (!(Row.IsNull("Fldbt2"))) pdfFormFields.SetField("Fldbt2",  Row["Fldbt2"].ToString().Trim());
                if (!(Row.IsNull("Fldbt3"))) pdfFormFields.SetField("Fldbt3", Row["Fldbt3"].ToString().Trim());
                if (!(Row.IsNull("Fldbt4"))) pdfFormFields.SetField("Fldbt4", Row["Fldbt4"].ToString().Trim());
                if (!(Row.IsNull("Fldbt5"))) pdfFormFields.SetField("Fldbt5", Row["Fldbt5"].ToString().Trim());
                if (!(Row.IsNull("Fldbt6"))) pdfFormFields.SetField("Fldbt6", Row["Fldbt6"].ToString().Trim());
                if (!(Row.IsNull("Fldbt7"))) pdfFormFields.SetField("Fldbt7", Row["Fldbt7"].ToString().Trim());
                if (!(Row.IsNull("Fldbt8"))) pdfFormFields.SetField("Fldbt8", Row["Fldbt8"].ToString().Trim());
                if (!(Row.IsNull("Fldbt9"))) pdfFormFields.SetField("Fldbt9", Row["Fldbt9"].ToString().Trim());
                if (!(Row.IsNull("Fldbt10"))) pdfFormFields.SetField("Fldbt10", Row["Fldbt10"].ToString().Trim());
                if (!(Row.IsNull("Fldbt11"))) pdfFormFields.SetField("Fldbt11", Row["Fldbt11"].ToString().Trim());
                if (!(Row.IsNull("Fldbt12"))) pdfFormFields.SetField("Fldbt12", Row["Fldbt12"].ToString().Trim());
                if (!(Row.IsNull("Fldbt13"))) pdfFormFields.SetField("Fldbt13",  Row["Fldbt13"].ToString().Trim());
                if (!(Row.IsNull("Fldbt14"))) pdfFormFields.SetField("Fldbt14", Row["Fldbt14"].ToString().Trim());
                if (!Row.IsNull("Fldb1")) pdfFormFields.SetField("Fldb1", int.Parse(Row["Fldb1"].ToString()).ToString());
                if (!Row.IsNull("Fldb2")) pdfFormFields.SetField("Fldb2", int.Parse(Row["Fldb2"].ToString()).ToString());
                if (!Row.IsNull("Fldb3")) pdfFormFields.SetField("Fldb3", int.Parse(Row["Fldb3"].ToString()).ToString());
                if (!Row.IsNull("Fldb4")) pdfFormFields.SetField("Fldb4", int.Parse(Row["Fldb4"].ToString()).ToString());
                if (!Row.IsNull("Fldb5")) pdfFormFields.SetField("Fldb5", int.Parse(Row["Fldb5"].ToString()).ToString());
                if (!Row.IsNull("Fldb6")) pdfFormFields.SetField("Fldb6", int.Parse(Row["Fldb6"].ToString()).ToString());
                if (!Row.IsNull("Fldb7")) pdfFormFields.SetField("Fldb7", int.Parse(Row["Fldb7"].ToString()).ToString());
                if (!Row.IsNull("Fldb8")) pdfFormFields.SetField("Fldb8", int.Parse(Row["Fldb8"].ToString()).ToString());
                if (!Row.IsNull("Fldb9")) pdfFormFields.SetField("Fldb8", int.Parse(Row["Fldb9"].ToString()).ToString());
                if (!Row.IsNull("Fldb10")) pdfFormFields.SetField("Fldb10", int.Parse(Row["Fldb10"].ToString()).ToString());
                if (!Row.IsNull("Fldb11")) pdfFormFields.SetField("Fldb11", int.Parse(Row["Fldb11"].ToString()).ToString());
                if (!Row.IsNull("Fldb12")) pdfFormFields.SetField("Fldb12", int.Parse(Row["Fldb12"].ToString()).ToString());
                if (!Row.IsNull("Fldb13")) pdfFormFields.SetField("Fldb13", int.Parse(Row["Fldb13"].ToString()).ToString());
                if (!Row.IsNull("Fldb14")) pdfFormFields.SetField("Fldb14", int.Parse(Row["Fldb14"].ToString()).ToString());
                if (!Row.IsNull("Fldct1")) pdfFormFields.SetField("Fldct1", Row["Fldct1"].ToString().Trim());
                if (!Row.IsNull("Fldct2")) pdfFormFields.SetField("Fldct2", Row["Fldct2"].ToString().Trim());
                if (!Row.IsNull("Fldct3")) pdfFormFields.SetField("Fldct3", Row["Fldct3"].ToString().Trim());
                if (!Row.IsNull("Fldct4")) pdfFormFields.SetField("Fldct4", Row["Fldct4"].ToString().Trim());
                if (!Row.IsNull("Fldct5")) pdfFormFields.SetField("Fldct5", Row["Fldct5"].ToString().Trim());
                if (!Row.IsNull("Fldct6")) pdfFormFields.SetField("Fldct6", Row["Fldct6"].ToString().Trim());
                if (!Row.IsNull("Fldct7")) pdfFormFields.SetField("Fldct7", Row["Fldct7"].ToString().Trim());
                if (!Row.IsNull("Fldct8")) pdfFormFields.SetField("Fldct8", Row["Fldct8"].ToString().Trim());
                if (!Row.IsNull("Fldct9")) pdfFormFields.SetField("Fldct9", Row["Fldct9"].ToString().Trim());
                if (!Row.IsNull("Fldct10")) pdfFormFields.SetField("Fldct10", Row["Fldct10"].ToString().Trim());
                if (!Row.IsNull("Fldct11")) pdfFormFields.SetField("Fldct11", Row["Fldct11"].ToString().Trim());
                if (!Row.IsNull("Fldct12")) pdfFormFields.SetField("Fldct12", Row["Fldct12"].ToString().Trim());
                if (!Row.IsNull("Fldct13")) pdfFormFields.SetField("Fldct13", Row["Fldct13"].ToString().Trim());
                if (!Row.IsNull("Fldct14")) pdfFormFields.SetField("Fldct14", Row["Fldct14"].ToString().Trim());
                if (!Row.IsNull("Fldc1")) pdfFormFields.SetField("Fldc1", int.Parse(Row["Fldc1"].ToString()).ToString());
                if (!Row.IsNull("Fldc2")) pdfFormFields.SetField("Fldc2", int.Parse(Row["Fldc2"].ToString()).ToString());
                if (!Row.IsNull("Fldc3")) pdfFormFields.SetField("Fldc3", int.Parse(Row["Fldc3"].ToString()).ToString());
                if (!Row.IsNull("Fldc4")) pdfFormFields.SetField("Fldc4", int.Parse(Row["Fldc4"].ToString()).ToString());
                if (!Row.IsNull("Fldc5")) pdfFormFields.SetField("Fldc5", int.Parse(Row["Fldc5"].ToString()).ToString());
                if (!Row.IsNull("Fldc6")) pdfFormFields.SetField("Fldc6", int.Parse(Row["Fldc6"].ToString()).ToString());
                if (!Row.IsNull("Fldc7")) pdfFormFields.SetField("Fldc7", int.Parse(Row["Fldc7"].ToString()).ToString());
                if (!Row.IsNull("Fldc8")) pdfFormFields.SetField("Fldc8", int.Parse(Row["Fldc8"].ToString()).ToString());
                if (!Row.IsNull("Fldc9")) pdfFormFields.SetField("Fldc8", int.Parse(Row["Fldc9"].ToString()).ToString());
                if (!Row.IsNull("Fldc10")) pdfFormFields.SetField("Fldc10", int.Parse(Row["Fldc10"].ToString()).ToString());
                if (!Row.IsNull("Fldc11")) pdfFormFields.SetField("Fldc11", int.Parse(Row["Fldc11"].ToString()).ToString());
                if (!Row.IsNull("Fldc12")) pdfFormFields.SetField("Fldc12", int.Parse(Row["Fldc12"].ToString()).ToString());
                if (!Row.IsNull("Fldc13")) pdfFormFields.SetField("Fldc13", int.Parse(Row["Fldc13"].ToString()).ToString());
                if (!Row.IsNull("Fldc14")) pdfFormFields.SetField("Fldc14", int.Parse(Row["Fldc14"].ToString()).ToString());
                if (!Row.IsNull("Fldd1")) pdfFormFields.SetField("Fldd1", int.Parse(Row["Fldd1"].ToString()).ToString());
                if (!Row.IsNull("Fldd2")) pdfFormFields.SetField("Fldd2", int.Parse(Row["Fldd2"].ToString()).ToString());
                if (!Row.IsNull("Fldd3")) pdfFormFields.SetField("Fldd3", int.Parse(Row["Fldd3"].ToString()).ToString());
                if (!Row.IsNull("Fldd4")) pdfFormFields.SetField("Fldd4", int.Parse(Row["Fldd4"].ToString()).ToString());
                if (!Row.IsNull("Fldd6")) pdfFormFields.SetField("Fldd6", int.Parse(Row["Fldd6"].ToString()).ToString());
                if (!Row.IsNull("Fldd7")) pdfFormFields.SetField("Fldd7", int.Parse(Row["Fldd7"].ToString()).ToString());
                if (!Row.IsNull("Fldd8")) pdfFormFields.SetField("Fldd8", int.Parse(Row["Fldd8"].ToString()).ToString());
                if (!Row.IsNull("Fldd9")) pdfFormFields.SetField("Fldd9", int.Parse(Row["Fldd9"].ToString()).ToString());
                if (!Row.IsNull("Flddt3")) pdfFormFields.SetField("Flddt3", Row["Flddt3"].ToString().Trim());
                if (!Row.IsNull("Flddt4")) pdfFormFields.SetField("Flddt4",  Row["Flddt4"].ToString().Trim());
                if (!Row.IsNull("Flddt5")) pdfFormFields.SetField("Flddt5",  Row["Flddt5"].ToString().Trim());
                if (!Row.IsNull("Flddt7")) pdfFormFields.SetField("Flddt7",  Row["Flddt7"].ToString().Trim() + "%");
                if (!Row.IsNull("Flddt8")) pdfFormFields.SetField("Flddt8", Row["Flddt8"].ToString().Trim() + "%");
                if (!Row.IsNull("ot100")) pdfFormFields.SetField("ot100", decimal.Parse(Row["ot100"].ToString()).ToString());
                if (!Row.IsNull("ot133")) pdfFormFields.SetField("ot133", decimal.Parse(Row["ot133"].ToString()).ToString());
                if (!Row.IsNull("ot167")) pdfFormFields.SetField("ot167", decimal.Parse(Row["ot167"].ToString()).ToString());
                if (!Row.IsNull("ot200")) pdfFormFields.SetField("ot200", decimal.Parse(Row["ot200"].ToString()).ToString());
                pdfFormFields.SetField("note", note);
                pdfStamper.FormFlattening = true;
                pdfStamper.Close();
                pdfReader.Close();
                pdfReader = null;
                pdfStamper = null;
                os.Close();
                
                PdfReader pdfReader1 = new PdfReader(newFile);
                PdfEncryptor.Encrypt(pdfReader1, new FileStream(newFile_ex, FileMode.Create), true, Row["password"].ToString(), null, PdfWriter.AllowScreenReaders);
                //MergePDF.setMergePDF(document, writer, newFile);
                SendMail(Row["email"].ToString(), yy + "年 " + mm + "月 薪資袋", newFile_ex, smtpserver,sendmail,smtpid,smtppw);
                File.Delete(newFile);                
            }
            MessageBox.Show("傳送個人薪資單完畢！", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
            //File.Delete(newFile_ex);
        }

        class MergePDF
        {
            static public void setMergePDF(Document document, PdfWriter writer, string pdtPath)
            {
                PdfReader reader = new PdfReader(pdtPath);
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage newPage;
                int iPageNum = reader.NumberOfPages;
                for (int j = 1; j <= iPageNum; j++)
                {

                    document.NewPage();
                    newPage = writer.GetImportedPage(reader, j);
                    cb.AddTemplate(newPage, 0, 0);
                }
            }
        }

        public static void SendMail(string mailto, string subject, string _file, string _host, string sendmail, string smtpid, string smtppw)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress(sendmail);
            smtpClient.Host = _host;
            smtpClient.Port = 25;
            smtpClient.Credentials = new System.Net.NetworkCredential(smtpid, smtppw);
            message.From = fromAddress;

            message.To.Add(mailto);
            message.Subject = subject;
            //message.CC.Add("say@jbjob.com.tw");
            message.Attachments.Add(new Attachment(_file));
            message.IsBodyHtml = true;
            message.Body = "";
            smtpClient.Send(message);  
            

            smtpClient = null;
            message = null;
        }

        
    }

   
}
