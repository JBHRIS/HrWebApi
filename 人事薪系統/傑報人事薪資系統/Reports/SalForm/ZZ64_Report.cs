using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using System.Collections;


namespace JBHR.Reports.SalForm
{
 
    public partial class ZZ64_Report : JBControls.JBForm
    {
        SalDataSet ds = new SalDataSet();
        string nobr_b, nobr_e, dept_b, dept_e, yymm, date_b, username, year, month, workadr, CompId;

        public ZZ64_Report(string nobrb, string nobre, string deptb, string depte, string yy, string mm, string dateb, string _username, string _workadr, string _CompId)
        {
            nobr_b = nobrb; nobr_e = nobre; dept_b = deptb; dept_e = depte; yymm = yy + mm;
            date_b = dateb; username = _username; year = yy; month = mm; workadr = _workadr;
            CompId = _CompId;
            InitializeComponent();
        }

        private void ZZ64_Report_Load(object sender, EventArgs e)
        {
            try
            {
                JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
                string sqlCmd = "select b.nobr,a.name_c,a.name_e,a.idno,a.sex,a.count_ma,a.country,a.addr1,b.tax_date,b.tax_edate,";
                sqlCmd += "b.adate,b.rotet,b.comp,i.compname,i.chairman,i.compid,i.addr,a.matno,a.taxno";
                sqlCmd += " from base a,dept c,basetts b";              
                sqlCmd += " left outer join comp i on b.comp=i.comp";
                sqlCmd += " where a.nobr=b.nobr and b.dept=c.d_no";
                sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
                sqlCmd += string.Format(@" and b.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                sqlCmd += string.Format(@" and b.dept between '{0}' and '{1}'", dept_b, dept_e);
                sqlCmd += workadr;
                sqlCmd += " and a.count_ma=1";
                DataTable rq_base = SqlConn.GetDataTable(sqlCmd);
                rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };

                //薪資相關代碼
                string CmdSalcode = "select a.sal_code,a.sal_name,b.salattr,b.flag";
                CmdSalcode += " from salcode a,salattr b,acccd c where a.sal_attr=b.salattr and a.acccd=c.acccd";
                DataTable rq_salcode = SqlConn.GetDataTable(CmdSalcode);
                rq_salcode.PrimaryKey = new DataColumn[] { rq_salcode.Columns["sal_code"] };


                //薪資主檔
                string CmdWage = "select nobr,yymm,seq,adate,taxrate ";
                CmdWage += string.Format(@" from wage where yymm='{0}'", yymm);
                CmdWage += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                DataTable rq_wage = SqlConn.GetDataTable(CmdWage);
                DataColumn[] _key = new DataColumn[3];
                _key[0] = rq_wage.Columns["nobr"];
                _key[1] = rq_wage.Columns["yymm"];
                _key[2] = rq_wage.Columns["seq"];
                rq_wage.PrimaryKey = _key;

                //薪資明細資料
                string CmdWaged = "select nobr,yymm,seq,sal_code,amt from waged where ";
                CmdWaged += string.Format(@" yymm ='{0}' ", yymm);
                CmdWaged += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
                CmdWaged += " and sal_code <> '' and amt <> 10 order by nobr";
                DataTable rq_waged = SqlConn.GetDataTable(CmdWaged);
                rq_waged.Columns.Add("salattr", typeof(string));
                rq_waged.Columns.Add("flag", typeof(string));
                rq_waged.Columns.Add("name_c",typeof(string));
                rq_waged.Columns.Add("name_e",typeof(string));
                rq_waged.Columns.Add("matno",typeof(string));
                rq_waged.Columns.Add("taxno", typeof(string));
                rq_waged.Columns.Add("country",typeof(string));
                rq_waged.Columns.Add("compname",typeof(string));
                rq_waged.Columns.Add("chairman",typeof(string));
                rq_waged.Columns.Add("compid",typeof(string));
                rq_waged.Columns.Add("addr",typeof(string));
                rq_waged.Columns.Add("addr1",typeof(string));
                rq_waged.Columns.Add("taxrate", typeof(decimal));
                rq_waged.Columns.Add("stay183", typeof(bool));
                rq_waged.Columns.Add("adate", typeof(DateTime));

                DataTable rq_tax = new DataTable();
                rq_tax.Columns.Add("nobr", typeof(string));
                rq_tax.Columns.Add("amt", typeof(int));
                rq_tax.PrimaryKey = new DataColumn[] { rq_tax.Columns["nobr"] };

                string taxsalcode = "";
                DataTable rq_usys9 = SqlConn.GetDataTable("select * from u_sys9 where comp='" + CompId + "'");
                if (rq_usys9 != null) taxsalcode = rq_usys9.Rows[0]["taxsalcode"].ToString().Trim();               

                foreach (DataRow Row in rq_waged.Rows)
                {
                    object[] _value = new object[3];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["yymm"].ToString();
                    _value[2] = Row["seq"].ToString();
                    DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_wage.Rows.Find(_value);
                    if (row != null && row1 != null)
                    {
                        DataRow row2 = rq_salcode.Rows.Find(Row["sal_code"].ToString());
                        if (row2 != null)
                        {
                            Row["flag"] = row2["flag"].ToString();
                            Row["salattr"] = row2["salattr"].ToString();
                            if (Row["flag"].ToString().Trim() == "-")
                                Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString())) * (-1);
                            else
                                Row["amt"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["amt"].ToString()));
                        }
                        Row["name_c"] = row["name_c"].ToString();
                        Row["name_e"] = row["name_e"].ToString();
                        Row["matno"] = row["matno"].ToString();
                        Row["taxno"] = row["taxno"].ToString();
                        Row["country"] = row["country"].ToString();
                        Row["compname"] = row["compname"].ToString();
                        Row["chairman"] = row["chairman"].ToString();
                        Row["compid"] = row["compid"].ToString();
                        Row["addr"] = row["addr"].ToString();
                        Row["addr1"] = row["addr1"].ToString();
                        Row["taxrate"] = decimal.Parse(row1["taxrate"].ToString());
                        Row["adate"] = DateTime.Parse(row1["adate"].ToString());
                        int _adate = Convert.ToInt32(Convert.ToString(DateTime.Parse(row["tax_date"].ToString()).Year) + "0702");
                        if (DateTime.Parse(row["tax_date"].ToString()).Year == DateTime.Parse(row["adate"].ToString()).Year)
                        {
                            int _taxdate = Convert.ToInt32(DateTime.Parse(row["tax_date"].ToString()).ToString("yyyyMMdd"));
                            if (_taxdate > _adate)
                                Row["stay183"] =bool.Parse("false");
                            else
                                Row["stay183"] = bool.Parse("true");
                        }
                        else if (DateTime.Parse(row["tax_edate"].ToString()).Year == DateTime.Parse(row["adate"].ToString()).Year)
                        {
                            int _taxedate = Convert.ToInt32(DateTime.Parse(row["tax_edate"].ToString()).ToString("yyyyMMdd"));
                            if (_taxedate < _adate)
                                Row["stay183"] = bool.Parse("false");
                            else
                                Row["stay183"] = bool.Parse("true");
                        }
                        else
                            Row["stay183"] = bool.Parse("true");

                        DataRow row3 = rq_tax.Rows.Find(Row["nobr"].ToString());
                        if (Row["sal_code"].ToString() == taxsalcode)
                        {
                            if (row3 != null)
                                row3["amt"] = int.Parse(row3["amt"].ToString()) + (int.Parse(Row["amt"].ToString()) * (-1));
                            else
                            {
                                DataRow aRow = rq_tax.NewRow();
                                aRow["nobr"] = Row["nobr"].ToString();
                                aRow["amt"] = int.Parse(Row["amt"].ToString()) * (-1);
                                rq_tax.Rows.Add(aRow);
                            }
                        }
                    }
                    else
                        Row.Delete();

                }
                rq_waged.AcceptChanges();

                DataTable rq_wageda = new DataTable();
                rq_wageda.Columns.Add("nobr", typeof(string));
                rq_wageda.Columns.Add("name_c",typeof(string));
                rq_wageda.Columns.Add("name_e",typeof(string));
                rq_wageda.Columns.Add("matno",typeof(string));
                rq_wageda.Columns.Add("taxno", typeof(string));
                rq_wageda.Columns.Add("country",typeof(string));
                rq_wageda.Columns.Add("compname",typeof(string));
                rq_wageda.Columns.Add("chairman",typeof(string));
                rq_wageda.Columns.Add("compid",typeof(string));
                rq_wageda.Columns.Add("addr",typeof(string));
                rq_wageda.Columns.Add("addr1",typeof(string));
                rq_wageda.Columns.Add("yy", typeof(string));
                rq_wageda.Columns.Add("mm", typeof(string));
                rq_wageda.Columns.Add("taxrate", typeof(decimal));
                rq_wageda.Columns.Add("adate", typeof(DateTime));
                rq_wageda.Columns.Add("amt", typeof(int));
                rq_wageda.Columns.Add("taxamt", typeof(int));
                rq_wageda.Columns.Add("stay183", typeof(bool));
                rq_wageda.PrimaryKey = new DataColumn[] { rq_wageda.Columns["nobr"] };

                DataRow[] SRow = rq_waged.Select("salattr<='F'", "nobr asc");
                foreach (DataRow Row in SRow)
                {
                    DataRow row = rq_wageda.Rows.Find(Row["nobr"].ToString());
                    DataRow row1 = rq_tax.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                        row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    else
                    {
                        DataRow aRow = rq_wageda.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["name_e"] = Row["name_e"].ToString();
                        aRow["matno"] = Row["matno"].ToString();
                        aRow["taxno"] = Row["taxno"].ToString();
                        aRow["country"] = Row["country"].ToString();
                        aRow["compname"] = Row["compname"].ToString();
                        aRow["chairman"] = Row["chairman"].ToString();
                        aRow["compid"] = Row["compid"].ToString();
                        aRow["addr"] = Row["addr"].ToString();
                        aRow["addr1"] = Row["addr1"].ToString();
                        aRow["yy"] = Convert.ToString(Convert.ToUInt32(year) - 1911).PadLeft(3, '0');
                        aRow["mm"] = month.PadLeft(2,'0');
                        aRow["taxrate"] = decimal.Parse(Row["taxrate"].ToString());
                        aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        aRow["stay183"] = bool.Parse(Row["stay183"].ToString());
                        aRow["taxamt"] = (row1 != null) ? int.Parse(row1["amt"].ToString()) : 0;                          
                        rq_wageda.Rows.Add(aRow);
                    }
                }
                string _rptpath = JBModule.Pluging.CDisk.FindDirectory(Application.StartupPath, "PDF", "*.pdf");
                string pdfTemplate = _rptpath + "ZZ512.pdf";
                PdfReader pdfReader = new PdfReader(pdfTemplate);
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, AcroFields.Item> de in pdfReader.AcroFields.Fields)
                {
                    sb.Append(de.Key.ToString() + Environment.NewLine);
                }
                pdfTemplate = _rptpath + "ZZ512.pdf";

                string WriterFile = @"c:\Temp\ZZ512.pdf";
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(WriterFile, FileMode.Create));
                document.Open();
                ArrayList alFiles = new ArrayList();

                int _i = 1;
                foreach (DataRow Row in rq_wageda.Rows)
                {
                    string newFile = @"c:\Temp\ZZ512"+ _i.ToString() + ".pdf";
                    alFiles.Add(newFile);
                    pdfReader = new PdfReader(pdfTemplate);
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
                    AcroFields pdfFormFields = pdfStamper.AcroFields;

                    string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\..\Fonts\kaiu.ttf";
                    BaseFont bfChinese = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, //橫式中文
                        BaseFont.NOT_EMBEDDED);

                    //只有顯示中文才要加這一段程式
                    pdfFormFields.SetFieldProperty("Taxno1", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Taxno2", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Taxno3", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Taxno4", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Taxno5", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Taxno6", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Taxno7", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Taxno8", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Company", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Addr", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Chairman", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Format", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Name_c", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Name_e", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Addr1", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Country1", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Country2", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Passport", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Id1", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Id2", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Id3", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Id4", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Id5", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Id6", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Id7", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Id8", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Id9", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Id10", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("183D1", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("183D2", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Incomy_b", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Incomm_b", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Incomy_e", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Incomm_e", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Totamt", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Taxrate", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Taxamt", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Relamt", T_FONT, bfChinese, null);
                    pdfFormFields.SetFieldProperty("Adate", T_FONT, bfChinese, null);
                    if (Row["compid"].ToString() != "")
                    {
                        pdfFormFields.SetField("Taxno1", Row["compid"].ToString().Substring(0, 1));
                        pdfFormFields.SetField("Taxno2", Row["compid"].ToString().Substring(1, 1));
                        pdfFormFields.SetField("Taxno3", Row["compid"].ToString().Substring(2, 1));
                        pdfFormFields.SetField("Taxno4", Row["compid"].ToString().Substring(3, 1));
                        pdfFormFields.SetField("Taxno5", Row["compid"].ToString().Substring(4, 1));
                        pdfFormFields.SetField("Taxno6", Row["compid"].ToString().Substring(5, 1));
                        pdfFormFields.SetField("Taxno7", Row["compid"].ToString().Substring(6, 1));
                        pdfFormFields.SetField("Taxno8", Row["compid"].ToString().Substring(7, 1));
                    }
                    pdfFormFields.SetField("Company", Row["compname"].ToString());
                    pdfFormFields.SetField("Addr", Row["addr"].ToString());
                    pdfFormFields.SetField("Chairman", Row["chairman"].ToString());
                    pdfFormFields.SetField("Name_c", Row["name_c"].ToString());
                    pdfFormFields.SetField("Name_e", Row["name_e"].ToString());
                    pdfFormFields.SetField("Addr1", Row["addr1"].ToString());
                    if (Row["country"].ToString() != "")
                    {
                        pdfFormFields.SetField("Country1", Row["country"].ToString().Substring(0,1));
                        pdfFormFields.SetField("Country2", Row["country"].ToString().Substring(1,1));
                    }
                    pdfFormFields.SetField("Passport", Row["taxno"].ToString());
                    pdfFormFields.SetField("Format", "Yes");
                    if (Row["matno"].ToString() != "")
                    {
                        pdfFormFields.SetField("Id1", Row["matno"].ToString().Substring(0, 1));
                        pdfFormFields.SetField("Id2", Row["matno"].ToString().Substring(1, 1));
                        pdfFormFields.SetField("Id3", Row["matno"].ToString().Substring(2, 1));
                        pdfFormFields.SetField("Id4", Row["matno"].ToString().Substring(3, 1));
                        pdfFormFields.SetField("Id5", Row["matno"].ToString().Substring(4, 1));
                        pdfFormFields.SetField("Id6", Row["matno"].ToString().Substring(5, 1));
                        pdfFormFields.SetField("Id7", Row["matno"].ToString().Substring(6, 1));
                        pdfFormFields.SetField("Id8", Row["matno"].ToString().Substring(7, 1));
                        pdfFormFields.SetField("Id9", Row["matno"].ToString().Substring(8, 1));
                        pdfFormFields.SetField("Id10", Row["matno"].ToString().Substring(9, 1));
                    }
                    if (bool.Parse(Row["stay183"].ToString())) pdfFormFields.SetField("183D1", "Yes");
                    if (!bool.Parse(Row["stay183"].ToString())) pdfFormFields.SetField("183D2", "Yes");
                    pdfFormFields.SetField("Incomy_b", Row["yy"].ToString());
                    pdfFormFields.SetField("Incomm_b", Row["mm"].ToString());
                    pdfFormFields.SetField("Incomy_e", Row["yy"].ToString());
                    pdfFormFields.SetField("Incomm_e", Row["mm"].ToString());
                    pdfFormFields.SetField("Totamt", Row["amt"].ToString());
                    string _taxrote = Convert.ToString(decimal.Round(decimal.Parse(Row["taxrate"].ToString()) * 100, 0)) + "%";
                    pdfFormFields.SetField("Taxrate", _taxrote);
                    pdfFormFields.SetField("Taxamt", Row["taxamt"].ToString());
                    int _relamt = int.Parse(Row["amt"].ToString()) - int.Parse(Row["taxamt"].ToString());
                    pdfFormFields.SetField("Relamt", Convert.ToString(_relamt));

                    string str3 = "";
                    DateTime _adate = DateTime.Parse(Row["adate"].ToString());
                    str3 = Convert.ToString(_adate.Year - 1911).PadLeft(3, '0') + Convert.ToString(_adate.Month).PadLeft(2, '0') + Convert.ToString(_adate.Day).PadLeft(2, '0');
                    pdfFormFields.SetField("Adate", str3);
                    
                    pdfStamper.FormFlattening = true;
                    pdfStamper.Close();
                    pdfStamper.Dispose();
                    MergePDF.setMergePDF(document, writer, newFile);
                    _i++;
                }
                rq_base = null; rq_salcode = null; rq_usys9 = null; rq_wage = null; rq_waged = null;
                rq_wageda = null; rq_tax = null;
                document.Close();
                writer.Close();
                document.Dispose();
                writer.Dispose();
                //for (int i = 0; i < alFiles.Count; i++)
                //{
                //    File.Delete(alFiles[i].ToString());

                //}
                System.Diagnostics.Process.Start(WriterFile);
                this.Close();
            }
            catch (Exception Ex)
            {
                JBModule.Message.TextLog.WriteLog(Ex);
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + Ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }


        private const string T_FONT = "textfont";
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
