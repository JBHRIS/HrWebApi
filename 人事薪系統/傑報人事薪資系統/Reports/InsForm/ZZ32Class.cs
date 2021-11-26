using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using System.Collections;
using System.Drawing;

namespace JBHR.Reports.InsForm
{
    class ZZ32Class
    {
        private const string T_FONT = "textfont";

        public static void Get_ZZ32(DataTable DT_ZZ32, string _rptpath, DateTime _datee)
        {
            string _Folder = JBControls.ControlConfig.GetExportPath();
            string pdfTemplate = _rptpath + "ZZ321.pdf";            
            PdfReader pdfReader = new PdfReader(pdfTemplate);
            StringBuilder sb = new StringBuilder();
            var aa = pdfReader.AcroFields.Fields;

            
            foreach (KeyValuePair<string,AcroFields.Item> de in pdfReader.AcroFields.Fields)
            {
                sb.Append(de.Key.ToString() + Environment.NewLine);
            }
            pdfTemplate = _rptpath + "ZZ321.pdf";

            string WriterFile = _Folder + "ZZ321.pdf";
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(WriterFile, FileMode.Create));
            document.Open();
            ArrayList alFiles = new ArrayList();            
            
            
            int _count1 = 10;
            int value_count = DT_ZZ32.Rows.Count % 10;
            double dd = DT_ZZ32.Rows.Count/ 10;
            int page_count =int.Parse( Math.Truncate(dd).ToString());
            if (value_count > 0)
                page_count += 1;
          
            for (int i = 0; i < page_count; i++)
            {
                int _count = 1;
                string newFile = _Folder + "ZZ321" + i.ToString() + ".pdf";
                alFiles.Add(newFile);
                pdfReader = new PdfReader(pdfTemplate);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
                AcroFields pdfFormFields = pdfStamper.AcroFields;

                string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\..\Fonts\kaiu.ttf";
                BaseFont bfChinese = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, //橫式中文
                    BaseFont.NOT_EMBEDDED);

                //只有顯示中文才要加這一段程式
                pdfFormFields.SetFieldProperty("T04", T_FONT, bfChinese, null);                
                pdfFormFields.SetFieldProperty("AMT1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FAID1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NA1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NA2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NA3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NA4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NA5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NA6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NA7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NA8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NA9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NA10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FABA1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FABA2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FABA3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FABA4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FABA5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FABA6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FABA7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FABA8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FABA9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FABA10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("P1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("PA", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NOTE1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NOTE2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NOTE3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NOTE4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NOTE5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NOTE6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NOTE7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NOTE8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NOTE9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("NOTE10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("INDATE1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("INDATE2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("INDATE3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("INDATE4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("INDATE5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("INDATE6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("INDATE7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("INDATE8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("INDATE9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("INDATE10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("COMP", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("ADDR", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("TEL", T_FONT, bfChinese, null);                

                pdfFormFields.SetField("T01", DT_ZZ32.Rows[0]["insno"].ToString());
                pdfFormFields.SetField("T02", DT_ZZ32.Rows[0]["inspo"].ToString());
                pdfFormFields.SetField("T03", DT_ZZ32.Rows[0]["insidno"].ToString());
                pdfFormFields.SetField("T04", DT_ZZ32.Rows[0]["inssub"].ToString());
                pdfFormFields.SetField("T05", Convert.ToString(_datee.Year - 1911));
                pdfFormFields.SetField("T06", Convert.ToString(_datee.Month).PadLeft(2, '0'));
                pdfFormFields.SetField("T07", Convert.ToString(_datee.Day).PadLeft(2, '0'));
                pdfFormFields.SetField("COMP", DT_ZZ32.Rows[0]["company"].ToString());
                pdfFormFields.SetField("ADDR", DT_ZZ32.Rows[0]["addr"].ToString());
                pdfFormFields.SetField("TEL", DT_ZZ32.Rows[0]["tel"].ToString());

                if (_count1 > DT_ZZ32.Rows.Count)
                    _count1 = DT_ZZ32.Rows.Count;

                for (int j = i * (10); j < _count1; j++)
                {
                    string _adf=DT_ZZ32.Rows[j]["h_amt"].ToString().ToString();
                    string str1 = ""; string str2 = ""; string str3 = "";
                    DateTime _birdt = DateTime.Parse(DT_ZZ32.Rows[j]["birdt"].ToString());
                    DateTime _indate = DateTime.Parse(DT_ZZ32.Rows[j]["in_date"].ToString());
                    str1 = Convert.ToString(_birdt.Year - 1911) + "年 " + Convert.ToString(_birdt.Month).PadLeft(2, '0') + "月 " + Convert.ToString(_birdt.Day).PadLeft(2, '0') + "日";
                    str3 = Convert.ToString(_indate.Year - 1911) + "/" + Convert.ToString(_indate.Month).PadLeft(2, '0') + "/" + Convert.ToString(_indate.Day).PadLeft(2, '0');
                    if (!DT_ZZ32.Rows[j].IsNull("fa_birdt"))
                    {
                        DateTime _fabirdt = DateTime.Parse(DT_ZZ32.Rows[j]["fa_birdt"].ToString());
                        str2 = Convert.ToString(_fabirdt.Year - 1911) + "年 " + Convert.ToString(_fabirdt.Month).PadLeft(2, '0') + "月 " + Convert.ToString(_fabirdt.Day).PadLeft(2, '0') + "日";
                    }

                    if (DT_ZZ32.Rows[j]["fa_idno"].ToString().Trim() == "")
                        pdfFormFields.SetField("P" + _count.ToString(), "Yes");
                    if (DT_ZZ32.Rows[j]["fa_idno"].ToString().Trim() != "")
                        pdfFormFields.SetField("PA" + _count.ToString(), "Yes");
                    pdfFormFields.SetField("N" + _count.ToString(), DT_ZZ32.Rows[j]["name_c"].ToString());
                    pdfFormFields.SetField("ID" + _count.ToString(), DT_ZZ32.Rows[j]["idno"].ToString());
                    pdfFormFields.SetField("AMT" + _count.ToString(), int.Parse(DT_ZZ32.Rows[j]["h_amt"].ToString()).ToString());
                    pdfFormFields.SetField("NA" + _count.ToString(), DT_ZZ32.Rows[j]["fa_name"].ToString());
                    pdfFormFields.SetField("FAID" + _count.ToString(), DT_ZZ32.Rows[j]["fa_idno"].ToString());
                    pdfFormFields.SetField("BA" + _count.ToString(), str1);
                    pdfFormFields.SetField("FABA" + _count.ToString(), str2);
                    pdfFormFields.SetField("RA" + _count.ToString(), DT_ZZ32.Rows[j]["rel_code"].ToString());
                    pdfFormFields.SetField("INDATE" + _count.ToString(), str3);
                    pdfFormFields.SetField("NOTE" + _count.ToString(), DT_ZZ32.Rows[j]["insname"].ToString());
                    _count++;
                }
                _count1 = _count1 + 10;
                pdfStamper.FormFlattening = true;
                pdfStamper.Close();
                pdfStamper.Dispose();
                MergePDF.setMergePDF(document, writer, newFile);
            }
            document.Close();
            writer.Close();
            document.Dispose();
            writer.Dispose();
            //for (int i = 0; i < alFiles.Count; i++)
            //{
            //    File.Delete(alFiles[i].ToString());

            //}

            System.Diagnostics.Process.Start(WriterFile);
        }


        public static void Get_ZZ321(DataTable DT_ZZ32, string _rptpath,DateTime _datee)
        {
            string _Folder = JBControls.ControlConfig.GetExportPath(); 
            string pdfTemplate = _rptpath + "ZZ322.pdf";
            PdfReader pdfReader = new PdfReader(pdfTemplate);
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, AcroFields.Item> de in pdfReader.AcroFields.Fields)
            {
                sb.Append(de.Key.ToString() + Environment.NewLine);
            }
            pdfTemplate = _rptpath + "ZZ322.pdf";
            string WriterFile = _Folder + "ZZ322A.pdf";
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(WriterFile, FileMode.Create));
            document.Open();
            ArrayList alFiles = new ArrayList();


            int _count1 = 10;
            int value_count = DT_ZZ32.Rows.Count % 10;
            double dd = DT_ZZ32.Rows.Count / 10;
            int page_count = int.Parse(Math.Truncate(dd).ToString());
            if (value_count > 0)
                page_count += 1;

            for (int i = 0; i < page_count; i++)
            {
                string newFile =  _Folder + "ZZ322A" + i.ToString() + ".pdf";
                alFiles.Add(newFile);
                pdfReader = new PdfReader(pdfTemplate);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
                AcroFields pdfFormFields = pdfStamper.AcroFields;

                string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\..\Fonts\kaiu.ttf";
                BaseFont bfChinese = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, //橫式中文
                    BaseFont.NOT_EMBEDDED);


                //只有顯示中文才要加這一段程式
                pdfFormFields.SetFieldProperty("T04", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("BA10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FA1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FA2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FA3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FA4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FA5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FA6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FA7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FA8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FA9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("FA10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("RE1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("RE2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("RE3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("RE4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("RE5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("RE6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("RE7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("RE8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("RE9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("RE10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("OUTDATE1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("OUTDATE2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("OUTDATE3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("OUTDATE4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("OUTDATE5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("OUTDATE6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("OUTDATE7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("OUTDATE8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("OUTDATE9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("OUTDATE10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("COMP", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("ADDR", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("TEL", T_FONT, bfChinese, null);

                pdfFormFields.SetField("T01", DT_ZZ32.Rows[0]["insno"].ToString());
                pdfFormFields.SetField("T02", DT_ZZ32.Rows[0]["inspo"].ToString());
                pdfFormFields.SetField("T03", DT_ZZ32.Rows[0]["insidno"].ToString());
                pdfFormFields.SetField("T04", DT_ZZ32.Rows[0]["inssub"].ToString());
                pdfFormFields.SetField("T05", Convert.ToString(_datee.Year - 1911));
                pdfFormFields.SetField("T06", Convert.ToString(_datee.Month).PadLeft(2, '0'));
                pdfFormFields.SetField("T07", Convert.ToString(_datee.Day).PadLeft(2, '0'));
                pdfFormFields.SetField("COMP", DT_ZZ32.Rows[0]["company"].ToString());
                pdfFormFields.SetField("ADDR", DT_ZZ32.Rows[0]["addr"].ToString());
                pdfFormFields.SetField("TEL", DT_ZZ32.Rows[0]["tel"].ToString());
                int _count = 1;
                if (_count1 > DT_ZZ32.Rows.Count)
                    _count1 = DT_ZZ32.Rows.Count;

                for (int j = i * (10); j < _count1; j++)
                {                    
                    string str1 = ""; string str3 = "";
                    DateTime _birdt = DateTime.Parse(DT_ZZ32.Rows[j]["birdt"].ToString());
                    DateTime _outdate = DateTime.Parse(DT_ZZ32.Rows[j]["out_date"].ToString());
                    str1 = Convert.ToString(_birdt.Year - 1911) + "年 " + Convert.ToString(_birdt.Month).PadLeft(2, '0') + "月 " + Convert.ToString(_birdt.Day).PadLeft(2, '0') + "日";
                    str3 = Convert.ToString(_outdate.Year - 1911) + "/" + Convert.ToString(_outdate.Month).PadLeft(2, '0') + "/" + Convert.ToString(_outdate.Day).PadLeft(2, '0');
                    
                    if (DT_ZZ32.Rows[j]["fa_idno"].ToString().Trim() == "")
                        pdfFormFields.SetField("P" + _count.ToString(), "Yes");
                    if (DT_ZZ32.Rows[j]["fa_idno"].ToString().Trim() != "")
                        pdfFormFields.SetField("PA" + _count.ToString(), "Yes");
                    pdfFormFields.SetField("N" + _count.ToString(), DT_ZZ32.Rows[j]["name_c"].ToString());
                    pdfFormFields.SetField("ID" + _count.ToString(), DT_ZZ32.Rows[j]["idno"].ToString());
                    pdfFormFields.SetField("BA" + _count.ToString(), str1);
                    pdfFormFields.SetField("FA" + _count.ToString(), DT_ZZ32.Rows[j]["fa_name"].ToString());
                    pdfFormFields.SetField("FAID" + _count.ToString(), DT_ZZ32.Rows[j]["fa_idno"].ToString());
                    pdfFormFields.SetField("RE" + _count.ToString(), DT_ZZ32.Rows[j]["insname"].ToString());
                    pdfFormFields.SetField("OUT" + _count.ToString(), "Yes");
                    pdfFormFields.SetField("OUTDATE" + _count.ToString(), str3);
                    _count++;
                }
                _count1 = _count1 + 10;
                pdfStamper.FormFlattening = true;
                pdfStamper.Close();
                pdfStamper.Dispose();
                MergePDF.setMergePDF(document, writer, newFile);
            }
            document.Close();
            writer.Close();
            document.Dispose();
            writer.Dispose();

            //for (int i = 0; i < alFiles.Count; i++)
            //{
            //    File.Delete(alFiles[i].ToString());

            //}

            System.Diagnostics.Process.Start(WriterFile);

        }

        public static void Get_ZZ322(DataTable DT_ZZ32, string _rptpath, DateTime _datee)
        {
            string _Folder = JBControls.ControlConfig.GetExportPath();
            string pdfTemplate = _rptpath + "ZZ323.pdf";           
            PdfReader pdfReader = new PdfReader(pdfTemplate);
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, AcroFields.Item> de in pdfReader.AcroFields.Fields)
            {
                sb.Append(de.Key.ToString() + Environment.NewLine);
            }

            pdfTemplate = _rptpath + "ZZ323.pdf";
            string WriterFile = _Folder + "ZZ323A.pdf";
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(WriterFile, FileMode.Create));
            document.Open();
            ArrayList alFiles = new ArrayList();

            int _count1 = 6;
            int value_count = DT_ZZ32.Rows.Count % 6;
            double dd = DT_ZZ32.Rows.Count / 6;
            int page_count = int.Parse(Math.Truncate(dd).ToString());
            if (value_count > 0)
                page_count += 1;
            for (int i = 0; i < page_count; i++)
            {
                string newFile = _Folder + "ZZ323A" + i.ToString() + ".pdf";
                alFiles.Add(newFile);
                pdfReader = new PdfReader(pdfTemplate);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
                AcroFields pdfFormFields = pdfStamper.AcroFields;

                string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\..\Fonts\kaiu.ttf";
                BaseFont bfChinese = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, //橫式中文
                    BaseFont.NOT_EMBEDDED);

                //只有顯示中文才要加這一段程式
                pdfFormFields.SetFieldProperty("T04", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N1", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N2", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N3", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N4", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N5", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N6", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N7", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N8", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N9", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("N10", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("COMP", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("ADDR", T_FONT, bfChinese, null);
                pdfFormFields.SetFieldProperty("TEL", T_FONT, bfChinese, null);

                pdfFormFields.SetField("T01", DT_ZZ32.Rows[0]["insno"].ToString());
                pdfFormFields.SetField("T02", DT_ZZ32.Rows[0]["inspo"].ToString());
                pdfFormFields.SetField("T03", DT_ZZ32.Rows[0]["insidno"].ToString());
                pdfFormFields.SetField("T04", DT_ZZ32.Rows[0]["inssub"].ToString());
                pdfFormFields.SetField("T05", Convert.ToString(_datee.Year - 1911));
                pdfFormFields.SetField("T06", Convert.ToString(_datee.Month).PadLeft(2, '0'));
                pdfFormFields.SetField("T07", Convert.ToString(_datee.Day).PadLeft(2, '0'));
                pdfFormFields.SetField("COMP", DT_ZZ32.Rows[0]["company"].ToString());
                pdfFormFields.SetField("ADDR", DT_ZZ32.Rows[0]["addr"].ToString());
                pdfFormFields.SetField("TEL", DT_ZZ32.Rows[0]["tel"].ToString());
                int _count = 1;
                if (_count1 > DT_ZZ32.Rows.Count)
                    _count1 = DT_ZZ32.Rows.Count;

                for (int j = i * (6); j < _count1; j++)
                {
                    string str1 = ""; string str3 = "";
                    DateTime _birdt = DateTime.Parse(DT_ZZ32.Rows[j]["birdt"].ToString());
                    DateTime _outdate = DateTime.Parse(DT_ZZ32.Rows[j]["out_date"].ToString());
                    str1 = Convert.ToString(_birdt.Year - 1911) + "年 " + Convert.ToString(_birdt.Month).PadLeft(2, '0') + "月 " + Convert.ToString(_birdt.Day).PadLeft(2, '0') + "日";
                    str3 = Convert.ToString(_outdate.Year - 1911) + "/" + Convert.ToString(_outdate.Month).PadLeft(2, '0') + "/" + Convert.ToString(_outdate.Day).PadLeft(2, '0');
                    
                    pdfFormFields.SetField("N" + _count.ToString(), DT_ZZ32.Rows[j]["name_c"].ToString());
                    pdfFormFields.SetField("ID" + _count.ToString(), DT_ZZ32.Rows[j]["idno"].ToString());
                    pdfFormFields.SetField("Y" + _count.ToString(), Convert.ToString(_birdt.Year - 1911));
                    pdfFormFields.SetField("M" + _count.ToString(), Convert.ToString(_birdt.Month).PadLeft(2, '0'));
                    pdfFormFields.SetField("D" + _count.ToString(), Convert.ToString(_birdt.Day).PadLeft(2, '0'));
                    pdfFormFields.SetField("LA" + _count.ToString(), int.Parse(DT_ZZ32.Rows[j]["l_amt1"].ToString()).ToString());
                    pdfFormFields.SetField("HA" + _count.ToString(), int.Parse(DT_ZZ32.Rows[j]["h_amt1"].ToString()).ToString());
                    pdfFormFields.SetField("LB" + _count.ToString(), int.Parse(DT_ZZ32.Rows[j]["l_amt"].ToString()).ToString());
                    pdfFormFields.SetField("HB" + _count.ToString(), int.Parse(DT_ZZ32.Rows[j]["h_amt"].ToString()).ToString());
                    _count++;
                }
                _count1 = _count1 + 6;
                pdfStamper.FormFlattening = true;
                pdfStamper.Close();
                pdfStamper.Dispose();
                MergePDF.setMergePDF(document, writer, newFile);

            }
            document.Close();
            writer.Close();
            document.Dispose();
            writer.Dispose();

            //for (int i = 0; i < alFiles.Count; i++)
            //{
            //    File.Delete(alFiles[i].ToString());

            //}
            System.Diagnostics.Process.Start(WriterFile);
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
    }
}
