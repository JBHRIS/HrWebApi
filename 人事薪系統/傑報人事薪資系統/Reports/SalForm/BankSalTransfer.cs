
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Globalization;


namespace JBHR.Reports.SalForm
{
    class BankSalTransfer
    {
        public static void Get_Report7(DataTable DT_zz42ta, DataTable DT_zz42td, DataTable DT_base, DataTable DT_waged, string date_t, bool tran_count)
        {
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ42", MainForm.COMPANY);
            string _str1 = "";
            string str_t = ""; int _i = 1; int _len = 0;
            int toltalamt = 0;
            int toltalrow = 0;
            string yymmdd = Convert.ToString(DateTime.Parse(date_t).Year - 1911) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
            string yyyymmdd = Convert.ToString(DateTime.Parse(date_t).Year) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
            string _datet = Convert.ToString(DateTime.Parse(date_t).Year - 1911).Substring(1, 2) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
            string _Folder = JBControls.ControlConfig.GetExportPath();
            string CompId = string.Empty;
            string Compaccount = string.Empty;
            string CustId = string.Empty;
            string CustNet = string.Empty;
            string HREmail = string.Empty;
            string _FileName = string.Empty;
            for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
            {
                if (DT_zz42ta.Rows[0]["Fld" + (i + 1)].ToString() == "實發金額")
                {
                    str_t = "Fld" + (i + 1);
                    break;
                }
            }

            //轉帳帳號或身分證號錯誤名單
            DataTable rq_err = new DataTable();
            rq_err.Columns.Add("員工編號", typeof(string));
            rq_err.Columns.Add("員工姓名", typeof(string));
            rq_err.Columns.Add("錯誤原因", typeof(string));

            DataRow[] row = DT_zz42td.Select("cash=0 and account_no <> '' and adate='" + date_t + "'", "nobr asc");
            DataTable DT_zz4215 = new DataTable();
            DT_zz4215.Columns.Add("nobr", typeof(string));
            DT_zz4215.Columns.Add("name_c", typeof(string));
            DT_zz4215.Columns.Add("count_ma", typeof(bool));
            DT_zz4215.Columns.Add("idno", typeof(string));
            DT_zz4215.Columns.Add("account_no", typeof(string));
            DT_zz4215.Columns.Add("bankno", typeof(string));
            DT_zz4215.Columns.Add("bankno_o", typeof(string));
            DT_zz4215.Columns.Add("compid", typeof(string));
            DT_zz4215.Columns.Add("saladr", typeof(string));
            DT_zz4215.Columns.Add("compaccount", typeof(string));
            DT_zz4215.Columns.Add("tt", typeof(int));
            int totamt = 0;
            //
            if (tran_count)
            {
                DataRow[] row1 = DT_waged.Select("(sal_code='R01' or sal_code='R02') and cash=0 and adate='" + date_t + "'", "nobr asc");
                foreach (DataRow Row1 in row1)
                {
                    DataRow row2 = DT_base.Rows.Find(Row1["nobr"].ToString());
                    if (row2 != null)
                    {
                        if (row2["account_ma"].ToString().Trim() != "")
                        {
                            DataRow aRow1 = DT_zz4215.NewRow();
                            aRow1["nobr"] = Row1["nobr"].ToString();
                            aRow1["name_c"] = Row1["name_c"].ToString();
                            aRow1["tt"] = int.Parse(Row1["amt"].ToString());
                            aRow1["idno"] = row2["idno"].ToString();
                            aRow1["count_ma"] = bool.Parse(row2["count_ma"].ToString());
                            aRow1["account_no"] = row2["account_ma"].ToString();
                            aRow1["compaccount"] = row2["account"].ToString();
                            if (row2["bankno"].ToString().Trim().Length < 3)
                            {
                                DataRow aRow = rq_err.NewRow();
                                aRow["員工編號"] = Row1["nobr"].ToString();
                                aRow["員工姓名"] = Row1["name_c"].ToString();
                                aRow["錯誤原因"] = "銀行代碼不足3碼";
                                rq_err.Rows.Add(aRow);
                                aRow1["bankno"] = row2["bankno"].ToString().Trim();
                            }
                            else
                                aRow1["bankno"] = row2["bankno"].ToString().Trim().Substring(0, 3);
                            aRow1["bankno_o"] = row2["bankno"].ToString().Trim();
                            if (bool.Parse(row2["count_ma"].ToString()))
                            {
                                //aRow1["bankno"] = row2["bank_code"].ToString(); //外籍儲蓄款銀行
                                aRow1["idno"] = row2["matno"].ToString();
                                aRow1["account_no"] = row2["account_ma"].ToString();
                            }

                            aRow1["compid"] = row2["compid"].ToString();
                            aRow1["saladr"] = row2["saladr"].ToString();
                            DT_zz4215.Rows.Add(aRow1);
                            totamt += int.Parse(Row1["amt"].ToString());
                        }
                    }
                }
                ////外籍玉山銀行
                //DataRow[] rowa3 = DT_zz4215.Select("bankno='047' and count_ma=1", "nobr asc");
                //if (rowa3.Length > 0)
                //{
                //    File.Delete(_Folder + "玉山銀行外籍代存" + yyyymmdd + ".txt");
                //    ////第一筆                
                //    StreamWriter sw = new StreamWriter(_Folder + "玉山銀行外籍代存" + yyyymmdd + ".txt", true, Encoding.Default);
                //    string _space = "";
                //    foreach (DataRow Row5 in rowa3)
                //    {
                //        string aa = Row5["account_no"].ToString();
                //        if (Row5["account_no"].ToString().Trim().Length != 13) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  玉山銀行帳號不足或多13碼");
                //        if (Row5["idno"].ToString().Trim().Length != 10) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  外籍統一證號不足或多11碼");
                //        _str1 = _datet + "047327879121  " + Row5["account_no"].ToString().Trim().PadLeft(13, ' ') + Row5["idno"].ToString().Trim().PadLeft(10, ' ') + "101" + (Row5["tt"].ToString()).PadLeft(11, '0') + "00" + _space.PadLeft(20, ' ') + "2";
                //        sw.WriteLine("" + _str1 + "");
                //    }

                //    sw.Close();
                //    MessageBox.Show("產生磁片完畢 " + _Folder + "玉山銀行外籍代存" + yyyymmdd + ".txt");
                //}
                //DT_zz4215.Clear();
            }


            foreach (DataRow Row in row)
            {
                DataRow row2 = DT_base.Rows.Find(Row["nobr"].ToString());
                if (int.Parse(Row[str_t].ToString()) > 0)
                {
                    DataRow aRow = DT_zz4215.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["tt"] = int.Parse(Row[str_t].ToString());
                    aRow["account_no"] = Row["account_no"].ToString();
                    aRow["compaccount"] = Row["compaccount"].ToString();
                    aRow["idno"] = Row["idno"].ToString();
                    aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                    aRow["compid"] = Row["compid"].ToString();
                    aRow["saladr"] = Row["saladr"].ToString();
                    if (Row["bankno"].ToString().Trim().Length < 3)
                    {
                        DataRow aRow2 = rq_err.NewRow();
                        aRow2["員工編號"] = Row["nobr"].ToString();
                        aRow2["員工姓名"] = Row["name_c"].ToString();
                        aRow2["錯誤原因"] = "銀行代碼不足3碼";
                        rq_err.Rows.Add(aRow2);
                        aRow["bankno"] = Row["bankno"].ToString().Trim();
                    }
                    else
                        aRow["bankno"] = Row["bankno"].ToString().Trim().Substring(0, 3);
                    aRow["bankno_o"] = Row["bankno"].ToString().Trim();
                    if (bool.Parse(Row["count_ma"].ToString()))
                        aRow["idno"] = row2["matno"].ToString();
                    if (string.IsNullOrEmpty(CompId))
                    {
                        CompId = Row["compid"].ToString();
                    }
                    if (string.IsNullOrEmpty(Compaccount))
                    {
                        Compaccount = Row["compaccount"].ToString();
                    }
                    DT_zz4215.Rows.Add(aRow);
                    totamt += int.Parse(Row[str_t].ToString());
                }
            }

            //玉山銀行
            DataRow[] rowa1 = DT_zz4215.Select("bankno='047' ", "nobr asc");  //and count_ma=0

            if (rowa1.Length > 0)
            {
                int total = 0;
                int _count = 0;
                File.Delete(_Folder + "玉山銀行" + yyyymmdd + ".txt");
                ////第一筆                
                StreamWriter sw = new StreamWriter(_Folder + "玉山銀行" + yyyymmdd + ".txt", true, Encoding.Default);
                string _space = "";
                foreach (DataRow Row5 in rowa1)
                {
                    string aa = Row5["account_no"].ToString();
                    if (Row5["account_no"].ToString().Trim().Length != 13) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  玉山銀行帳號不足或多13碼");
                    if (Row5["idno"].ToString().Trim().Length != 10) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  身分證號不足或多11碼");
                    _str1 = _datet + "047327879121  " + Row5["account_no"].ToString().Trim().PadLeft(13, ' ') + Row5["idno"].ToString().Trim().PadLeft(10, ' ') + "101" + (Row5["tt"].ToString()).PadLeft(11, '0') + "00" + _space.PadLeft(20, ' ') + "2";
                    sw.WriteLine("" + _str1 + "");
                }

                sw.Close();
                MessageBox.Show("產生磁片完畢 " + _Folder + "玉山銀行" + yyyymmdd + ".txt");
            }

            //台灣銀行
            DataTable rq_bankexport = new DataTable();
            rq_bankexport.Columns.Add("Fld1", typeof(string));
            rq_bankexport.Columns.Add("Fld2", typeof(string));
            rq_bankexport.Columns.Add("Fld3", typeof(string));
            rq_bankexport.Columns.Add("Fld4", typeof(string));
            rq_bankexport.Columns.Add("Fld5", typeof(string));
            rq_bankexport.Columns.Add("Fld6", typeof(string));
            rq_bankexport.Columns.Add("Fld7", typeof(string));
            DataRow[] rowa2 = DT_zz4215.Select("bankno='054'", "nobr asc");
            object ttsum1 = DT_zz4215.Compute("Sum(tt)", "bankno='054'");
            string sss = ttsum1.ToString();
            if (rowa2.Length > 0)
            {
                string _space = "";
                string _dateta = Convert.ToString(DateTime.Parse(date_t).Year - 1911).Substring(1, 2) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
                string _nowdate = Convert.ToString(DateTime.Now.Year - 1911).Substring(1, 2) + Convert.ToString(DateTime.Now.Month).PadLeft(2, '0') + Convert.ToString(DateTime.Now.Day).PadLeft(2, '0');
                //File.Delete(_Folder + DateTime.Parse(date_t).ToString("yyyyMMdd") + "HNCBIN.DAT");
                File.Delete(_Folder + "台灣銀行" + yyyymmdd + ".TXT");
                StreamWriter sw = new StreamWriter(_Folder + "台灣銀行" + yyyymmdd + ".TXT", true, Encoding.Default);

                int _count = 0;
                int rowcnt = rowa2.Length;

                foreach (DataRow Row in rowa2)
                {
                    if (_count == 0)
                    {
                        _str1 = _nowdate + _dateta + "04127879121001" + _space.PadLeft(14, '0') + ttsum1.ToString().PadLeft(12, '0') + rowcnt.ToString().PadLeft(4, '0') + "   9";
                        sw.WriteLine("" + _str1 + "");
                        DataRow aRow = rq_bankexport.NewRow();
                        aRow["Fld1"] = _nowdate;
                        aRow["Fld2"] = _dateta;
                        aRow["Fld3"] = "04127879121001";
                        aRow["Fld4"] = _space.PadLeft(14, '0');
                        aRow["Fld5"] = ttsum1.ToString().PadLeft(12, '0');
                        aRow["Fld6"] = rowcnt.ToString().PadLeft(4, '0');
                        aRow["Fld7"] = "   9";
                        rq_bankexport.Rows.Add(aRow);
                    }
                    if (Row["account_no"].ToString().Trim().Length != 12) throw new Exception("工號:" + Row["nobr"].ToString() + " " + Row["name_c"].ToString() + "  帳號不足或多於12碼");

                    _str1 = "   " + Row["account_no"].ToString().Trim().PadLeft(14, '0') + (Row["tt"].ToString()).PadLeft(12, '0') + _space.PadLeft(30, ' ') + "9"; ;
                    sw.WriteLine("" + _str1 + "");
                    _count++;
                    DataRow aRow1 = rq_bankexport.NewRow();
                    aRow1["Fld1"] = "   ";
                    aRow1["Fld2"] = Row["account_no"].ToString().Trim().PadLeft(14, '0');
                    aRow1["Fld3"] = "04127879121001";
                    aRow1["Fld4"] = Row["tt"].ToString().PadLeft(12, '0');
                    aRow1["Fld5"] = _space.PadLeft(30, ' ');
                    aRow1["Fld6"] = "";
                    aRow1["Fld7"] = "9";
                    rq_bankexport.Rows.Add(aRow1);
                }
                sw.Close();
                MessageBox.Show("產生磁片完畢 " + _Folder + "台灣銀行" + yyyymmdd + ".TXT");
                JBHR.Reports.ReportClass.Export(rq_bankexport, "台灣銀行轉帳");
            }

            string hsbcyymm = DateTime.Now.ToString("yyyyMMddHHmm");
            //台灣億群匯豐銀行           
            CustId = AppConfig.GetConfig("Bank018").Value;
            CustNet = AppConfig.GetConfig("Bank018NET").Value;
            HREmail = AppConfig.GetConfig("BankEmail").Value;
            rowa1 = DT_zz4215.Select("bankno='081'", "nobr asc");
            if (rowa1.Length > 0)
            {
                File.Delete(_Folder + "HSBC" + hsbcyymm + ".txt");
                ////第一筆                   
                _str1 = "IFH,IFILE,CSV," + CustId + "," + CustNet + "," + hsbcyymm + "," + DateTime.Now.ToString("yyyy/MM/dd") + "," + DateTime.Now.ToString("HH:mm:ss") + ",F,1.0," + ((rowa1.Length * 3) + 2).ToString() + ",BG51"; //P逐筆授權,F檔案授權,U801適用無中文字
                StreamWriter sw = new StreamWriter(_Folder + "HSBC" + hsbcyymm + ".txt", true, Encoding.Default);
                sw.WriteLine("" + _str1 + "");
                //第二筆
                _str1 = "BATHDR,ACH-CR," + rowa1.Length.ToString() + ",,,,,,,@1ST@," + yyyymmdd + "," + Compaccount + ",TWD," + totamt.ToString() + ",,,TW,HBAP,TWD,,," + CompId + ",,,,00000,REF001,101";
                sw.WriteLine("" + _str1 + "");
                foreach (DataRow Row5 in rowa1)
                {
                    _str1 = "SECPTY," + Row5["account_no"].ToString() + ",," + Row5["idno"].ToString() + ",0810016,,," + Row5["tt"].ToString() + ",,Payroll,,,,,Y,N";//原,Payroll,,,,,N,N                    
                    sw.WriteLine("" + _str1 + "");
                    _str1 = "ADV,,,,,,,1,1," + Row5["nobr"].ToString() + ",,,,,,,F,Y,1," + HREmail + ",,TW,,,,,,,,,,,,,,,,,,,,"; //[F,Y,2]=>檔案format 1=>PDF,2=>CSV
                    sw.WriteLine("" + _str1 + "");
                    _str1 = "ADV-FREETXT,1,,,," + Row5["nobr"].ToString();
                    sw.WriteLine("" + _str1 + "");
                }

                sw.Close();
                MessageBox.Show("產生磁片完畢 " + _Folder + "HSBC" + hsbcyymm + ".txt");
            }

            //銀行代碼
            CustId = AppConfig.GetConfig("BankID").Value;
            CompId = string.Empty;
            Compaccount = string.Empty;
            //華南銀行
            _FileName = "HNCBRM.DAT";
            rowa1 = DT_zz4215.Select("bankno='008'", "nobr asc");
            if (rowa1.Length > 0)
            {
                foreach (DataRow Row in rowa1)
                {
                    if (Row["account_no"].ToString().Trim().Length != 12)
                    {

                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "轉帳帳帳號不足或多於12碼";
                        rq_err.Rows.Add(aRow);
                    }
                    if (Row["idno"].ToString().Trim().Length != 10)
                    {
                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "身分證號不足或多10碼";
                        rq_err.Rows.Add(aRow);
                    }
                    if (string.IsNullOrEmpty(CompId))
                    {
                        CompId = Row["compid"].ToString();
                    }
                    if (string.IsNullOrEmpty(Compaccount))
                    {
                        Compaccount = Row["compaccount"].ToString();
                    }                    
                }

                if (string.IsNullOrEmpty(Compaccount)) throw new Exception("公司轉帳帳號未建立");
                if (string.IsNullOrEmpty(CompId)) throw new Exception("公司統一編號未建立");
                if (rq_err.Rows.Count > 0)
                {
                    JBHR.Reports.ReportClass.Export(rq_err, "轉帳磁片失敗名單");
                    return;
                }
                JBHR.Reports.SalForm.BankTransfer.Bank008(rowa1, date_t, Compaccount.Substring(0, 4), Compaccount.Substring(0, 7), "", CompId, _Folder, _FileName);
               

                MessageBox.Show("產生轉帳磁片完畢 " + _FileName);
            }

            CompId = string.Empty;
            Compaccount = string.Empty;
            //台灣銀行            
            _FileName = "BS" + CustId + ".txt";
            rowa1 = DT_zz4215.Select("bankno='004'", "nobr asc");
            if (rowa1.Length > 0)
            {
                toltalamt = 0;
                toltalrow = 0;
                foreach (DataRow Row in rowa1)
                {
                    bool chk = bool.Parse("true");
                    if (Row["account_no"].ToString().Trim().Length != 12)
                    {
                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "轉帳帳帳號不足或多於12碼";
                        rq_err.Rows.Add(aRow);
                        chk = bool.Parse("false");
                    }
                    if (Row["idno"].ToString().Trim().Length != 10)
                    {
                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "身分證號不足或多10碼";
                        rq_err.Rows.Add(aRow);
                        chk = bool.Parse("false");
                    }
                    if (string.IsNullOrEmpty(CompId))
                    {
                        CompId = Row["compid"].ToString();
                    }
                    if (string.IsNullOrEmpty(Compaccount))
                    {
                        Compaccount = Row["compaccount"].ToString();
                    }
                    if (chk)
                    {
                        toltalamt += int.Parse(Row["tt"].ToString());
                        toltalrow += 1;
                    }
                }

                if (string.IsNullOrEmpty(Compaccount)) throw new Exception("公司轉帳帳號未建立");
                if (string.IsNullOrEmpty(CompId)) throw new Exception("公司統一編號未建立");
                if (rq_err.Rows.Count > 0)
                {
                    JBHR.Reports.ReportClass.Export(rq_err, "轉帳磁片失敗名單");
                    return;
                }
                JBHR.Reports.SalForm.BankTransfer.Bank004(rowa1, date_t, "", CompId,CustId, totamt.ToString(), toltalrow.ToString(), _Folder, _FileName); //Compaccount.Substring(0, 4), Compaccount.Substring(0, 7)
               

                MessageBox.Show("產生轉帳磁片完畢" + _FileName);
            }
            CompId = string.Empty;
            Compaccount = string.Empty;

            //中國信託
            rowa1 = DT_zz4215.Select("bankno='822' ", "nobr asc");
            _FileName = "中國信託" + yyyymmdd + ".txt";
            if (rowa1.Length > 0)
            {
                toltalamt = 0;
                toltalrow = 0;
                foreach (DataRow Row in rowa1)
                {
                    bool chk = bool.Parse("true");
                    if (Row["account_no"].ToString().Trim().Length != 12)
                    {
                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "轉帳帳帳號不足或多於12碼";
                        rq_err.Rows.Add(aRow);
                        chk = bool.Parse("false");
                    }
                    if (Row["idno"].ToString().Trim().Length != 10)
                    {
                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "身分證號不足或多10碼";
                        rq_err.Rows.Add(aRow);
                        chk = bool.Parse("false");
                    }
                    if (string.IsNullOrEmpty(CompId))
                    {
                        CompId = Row["compid"].ToString();
                    }
                    if (string.IsNullOrEmpty(Compaccount))
                    {
                        Compaccount = Row["compaccount"].ToString();
                    }
                    if (chk)
                    {
                        toltalamt += int.Parse(Row["tt"].ToString());
                        toltalrow += 1;
                    }
                }
                //int total = 0;
                //int _count = 0;
                //object postsum2 = DT_zz4215.Compute("Sum(tt)", "bankno='822'");
                if (string.IsNullOrEmpty(Compaccount)) throw new Exception("公司轉帳帳號未建立");
                if (string.IsNullOrEmpty(CompId)) throw new Exception("公司統一編號未建立");
                if (rq_err.Rows.Count > 0)
                {
                    JBHR.Reports.ReportClass.Export(rq_err, "轉帳磁片失敗名單");
                    return;
                }
                File.Delete(_Folder + "中國信託" + yyyymmdd + ".txt");
                JBHR.Reports.SalForm.BankTransfer.Bank822(rowa1, yymmdd, Compaccount, _Folder, _FileName);
                
                MessageBox.Show("產生轉帳磁片完畢" + _FileName);
                //MessageBox.Show("產生磁片完畢 " + _Folder + _FileName + " 總共" + Convert.ToString(rowa1.Length) + "筆 總金額" + Convert.ToString(postsum2) + "元");.
            }

            CompId = string.Empty;
            Compaccount = string.Empty;



            //台新
            rowa1 = DT_zz4215.Select("bankno='812' ", "nobr asc");
            CustId = AppConfig.GetConfig("BankID").Value;
            _FileName = "台新" + yyyymmdd + ".txt";
            if (rowa1.Length > 0)
            {
                toltalamt = 0;
                toltalrow = 0;
                foreach (DataRow Row in rowa1)
                {
                    bool chk = bool.Parse("true");
                    //if (Row["account_no"].ToString().Trim().Length != 12)
                    //{
                    //    DataRow aRow = rq_err.NewRow();
                    //    aRow["員工編號"] = Row["nobr"].ToString();
                    //    aRow["員工姓名"] = Row["name_c"].ToString();
                    //    aRow["錯誤原因"] = "轉帳帳帳號不足或多於12碼";
                    //    rq_err.Rows.Add(aRow);
                    //    chk = bool.Parse("false");
                    //}
                    if (Row["idno"].ToString().Trim().Length != 10)
                    {
                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "身分證號不足或多10碼";
                        rq_err.Rows.Add(aRow);
                        chk = bool.Parse("false");
                    }
                    if (string.IsNullOrEmpty(CompId))
                    {
                        CompId = Row["compid"].ToString();
                    }
                    if (string.IsNullOrEmpty(Compaccount))
                    {
                        Compaccount = Row["compaccount"].ToString();
                    }
                    if (chk)
                    {
                        toltalamt += int.Parse(Row["tt"].ToString());
                        toltalrow += 1;
                    }
                }

                //int total = 0;
                //int _count = 0;
                //object postsum2 = DT_zz4215.Compute("Sum(tt)", "bankno='822'");
                if (string.IsNullOrEmpty(Compaccount)) throw new Exception("公司轉帳帳號未建立");
                if (string.IsNullOrEmpty(CompId)) throw new Exception("公司統一編號未建立");
                if (rq_err.Rows.Count > 0)
                {
                    JBHR.Reports.ReportClass.Export(rq_err, "轉帳磁片失敗名單");
                    return;
                }
                File.Delete(_Folder + "台新" + yyyymmdd + ".txt");
                //(DataRow[] TransData, string date_t, string compaccount, string CompID, string Num, string totalamt, string totalcnt, string Folder, string FileName)
                JBHR.Reports.SalForm.BankTransfer.Bank812(rowa1, date_t, Compaccount, CompId, CustId, toltalamt.ToString(), toltalrow.ToString(), _Folder, _FileName);

                MessageBox.Show("產生轉帳磁片完畢" + _FileName);
                //MessageBox.Show("產生磁片完畢 " + _Folder + _FileName + " 總共" + Convert.ToString(rowa1.Length) + "筆 總金額" + Convert.ToString(postsum2) + "元");.
            }

            CompId = string.Empty;
            Compaccount = string.Empty;


            //合庫
            rowa1 = DT_zz4215.Select("bankno='006' ", "nobr asc");
            _FileName = "合庫" + yyyymmdd + ".txt";
            if (rowa1.Length > 0)
            {
                toltalamt = 0;
                toltalrow = 0;
                foreach (DataRow Row in rowa1)
                {
                    bool chk = bool.Parse("true");
                    if (Row["account_no"].ToString().Trim().Length != 13)
                    {
                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "轉帳帳帳號不足或多於13碼";
                        rq_err.Rows.Add(aRow);
                        chk = bool.Parse("false");
                    }
                    if (Row["idno"].ToString().Trim().Length != 10)
                    {
                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "身分證號不足或多10碼";
                        rq_err.Rows.Add(aRow);
                        chk = bool.Parse("false");
                    }
                    if (string.IsNullOrEmpty(CompId))
                    {
                        CompId = Row["compid"].ToString();
                    }
                    if (string.IsNullOrEmpty(Compaccount))
                    {
                        Compaccount = Row["compaccount"].ToString();
                    }
                    if (chk)
                    {
                        toltalamt += int.Parse(Row["tt"].ToString());
                        toltalrow += 1;
                    }
                }
                //int total = 0;
                //int _count = 0;
                //object postsum2 = DT_zz4215.Compute("Sum(tt)", "bankno='822'");
                //if (string.IsNullOrEmpty(Compaccount)) throw new Exception("公司轉帳帳號未建立");
                if (string.IsNullOrEmpty(CompId)) throw new Exception("公司統一編號未建立");
                if (rq_err.Rows.Count > 0)
                {
                    JBHR.Reports.ReportClass.Export(rq_err, "轉帳磁片失敗名單");
                    return;
                }
                File.Delete(_Folder + "合庫" + yyyymmdd + ".txt");
                JBHR.Reports.SalForm.BankTransfer.Bank006(rowa1, yyyymmdd, "", Compaccount, MainForm.COMPANY_NAME, _Folder, _FileName);

                MessageBox.Show("產生轉帳磁片完畢" + _FileName);
                //MessageBox.Show("產生磁片完畢 " + _Folder + _FileName + " 總共" + Convert.ToString(rowa1.Length) + "筆 總金額" + Convert.ToString(postsum2) + "元");.
            }

            CompId = string.Empty;
            Compaccount = string.Empty;

            //彰化銀行
            string CHBMemo = AppConfig.GetConfig("CHBMemo").Value;
            rowa1 = DT_zz4215.Select("bankno='009' ", "nobr asc");
            _FileName = "彰化銀行" + yyyymmdd + ".txt";
            if (rowa1.Length > 0)
            {
                toltalamt = 0;
                toltalrow = 0;
                foreach (DataRow Row in rowa1)
                {
                    bool chk = bool.Parse("true");
                    if (Row["account_no"].ToString().Trim().Length != 14)
                    {
                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "轉帳帳帳號不足或多於14碼";
                        rq_err.Rows.Add(aRow);
                        chk = bool.Parse("false");
                    }
                    if (Row["idno"].ToString().Trim().Length != 10)
                    {
                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "身分證號不足或多10碼";
                        rq_err.Rows.Add(aRow);
                        chk = bool.Parse("false");
                    }
                    if (string.IsNullOrEmpty(CompId))
                    {
                        CompId = Row["compid"].ToString();
                    }
                    if (string.IsNullOrEmpty(Compaccount))
                    {
                        Compaccount = Row["compaccount"].ToString();
                    }
                    if (chk)
                    {
                        toltalamt += int.Parse(Row["tt"].ToString());
                        toltalrow += 1;
                    }
                }
                //int total = 0;
                //int _count = 0;
                //object postsum2 = DT_zz4215.Compute("Sum(tt)", "bankno='822'");
                if (string.IsNullOrEmpty(Compaccount)) throw new Exception("公司轉帳帳號未建立");
                if (string.IsNullOrEmpty(CompId)) throw new Exception("公司統一編號未建立");
                if (rq_err.Rows.Count > 0)
                {
                    JBHR.Reports.ReportClass.Export(rq_err, "轉帳磁片失敗名單");
                    return;
                }
                File.Delete(_Folder + "彰化銀行" + yyyymmdd + ".txt");
                JBHR.Reports.SalForm.BankTransfer.Bank009(rowa1, date_t, Compaccount, Compaccount.Substring(0, 4), CompId, toltalamt.ToString(), toltalrow.ToString(), CHBMemo, _Folder, _FileName);

                MessageBox.Show("產生轉帳磁片完畢" + _FileName);
                //MessageBox.Show("產生磁片完畢 " + _Folder + _FileName + " 總共" + Convert.ToString(rowa1.Length) + "筆 總金額" + Convert.ToString(postsum2) + "元");.
            }

            CompId = string.Empty;
            Compaccount = string.Empty;

            //兆豐商銀
            rowa1 = DT_zz4215.Select("bankno='017' ", "nobr asc");
            _FileName = "兆豐商銀" + yyyymmdd + ".txt";
            if (rowa1.Length > 0)
            {
                toltalamt = 0;
                toltalrow = 0;
                foreach (DataRow Row in rowa1)
                {
                    bool chk = bool.Parse("true");
                    if (Row["account_no"].ToString().Trim().Length != 11) //|| Row["account_no"].ToString().Trim().Length > 14
                    {
                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "轉帳帳帳號不足或多於11碼";
                        rq_err.Rows.Add(aRow);
                        chk = bool.Parse("false");
                    }
                    if (Row["idno"].ToString().Trim().Length != 10)
                    {
                        DataRow aRow = rq_err.NewRow();
                        aRow["員工編號"] = Row["nobr"].ToString();
                        aRow["員工姓名"] = Row["name_c"].ToString();
                        aRow["錯誤原因"] = "身分證號不足或多10碼";
                        rq_err.Rows.Add(aRow);
                        chk = bool.Parse("false");
                    }
                    if (string.IsNullOrEmpty(CompId))
                    {
                        CompId = Row["compid"].ToString();
                    }
                    if (string.IsNullOrEmpty(Compaccount))
                    {
                        Compaccount = Row["compaccount"].ToString();
                    }
                    if (chk)
                    {
                        toltalamt += int.Parse(Row["tt"].ToString());
                        toltalrow += 1;
                    }
                }
                //int total = 0;
                //int _count = 0;
                //object postsum2 = DT_zz4215.Compute("Sum(tt)", "bankno='822'");
                //if (string.IsNullOrEmpty(Compaccount)) throw new Exception("公司轉帳帳號未建立");
                if (string.IsNullOrEmpty(CompId)) throw new Exception("公司統一編號未建立");
                Compaccount = AppConfig.GetConfig("Bank017Branch").Value;
                if (rq_err.Rows.Count > 0)
                {
                    JBHR.Reports.ReportClass.Export(rq_err, "轉帳磁片失敗名單");
                    return;
                }
                File.Delete(_Folder + "兆豐商銀" + yyyymmdd + ".txt");
                JBHR.Reports.SalForm.BankTransfer.Bank017(rowa1, date_t, Compaccount, CompId, "", toltalamt.ToString(), toltalrow.ToString(), _Folder, _FileName);

                MessageBox.Show("產生轉帳磁片完畢" + _FileName);
                //MessageBox.Show("產生磁片完畢 " + _Folder + _FileName + " 總共" + Convert.ToString(rowa1.Length) + "筆 總金額" + Convert.ToString(postsum2) + "元");.
            }
            CompId = string.Empty;
            Compaccount = string.Empty;

        }

        public static void Get_Salary_Transfer_Report(
            DataTable DT_zz42ta, 
            DataTable DT_zz42td, 
            DataTable DT_base, 
            DataTable DT_waged, 
            string date_t, 
            bool tran_count,
            DataTable DT_salary_transfer_bank
            )
        {
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ42", MainForm.COMPANY);
            string _str1 = "";
            string str_t = ""; int _i = 1; int _len = 0;
            int toltalamt = 0;
            int toltalrow = 0;
            string yymmdd = Convert.ToString(DateTime.Parse(date_t).Year - 1911) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
            string yyyymmdd = Convert.ToString(DateTime.Parse(date_t).Year) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
            string _datet = Convert.ToString(DateTime.Parse(date_t).Year - 1911).Substring(1, 2) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
            string _Folder = JBControls.ControlConfig.GetExportPath();
            string CompId = string.Empty;
            string Compaccount = string.Empty;
            string CustId = string.Empty;
            string CustNet = string.Empty;
            string HREmail = string.Empty;
            string _FileName = string.Empty;
            for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
            {
                if (DT_zz42ta.Rows[0]["Fld" + (i + 1)].ToString() == "實發金額")
                {
                    str_t = "Fld" + (i + 1);
                    break;
                }
            }

            //轉帳帳號或身分證號錯誤名單
            DataTable rq_err = new DataTable();
            rq_err.Columns.Add("員工編號", typeof(string));
            rq_err.Columns.Add("員工姓名", typeof(string));
            rq_err.Columns.Add("錯誤原因", typeof(string));


            DataRow[] row = DT_zz42td.Select("cash=0 and account_no <> '' and adate='" + date_t + "'", "nobr asc");
            DataTable DT_zz4215 = new DataTable();
            DT_zz4215.Columns.Add("nobr", typeof(string));
            DT_zz4215.Columns.Add("name_c", typeof(string));
            DT_zz4215.Columns.Add("count_ma", typeof(bool));
            DT_zz4215.Columns.Add("idno", typeof(string));
            DT_zz4215.Columns.Add("account_no", typeof(string));
            DT_zz4215.Columns.Add("bankno", typeof(string));
            DT_zz4215.Columns.Add("bankno_o", typeof(string));
            DT_zz4215.Columns.Add("compid", typeof(string));
            DT_zz4215.Columns.Add("saladr", typeof(string));
            DT_zz4215.Columns.Add("compaccount", typeof(string));
            DT_zz4215.Columns.Add("tt", typeof(int));
            int totamt = 0;
            //
            if (tran_count)
            {
                DataRow[] row1 = DT_waged.Select("(sal_code='R01' or sal_code='R02') and cash=0 and adate='" + date_t + "'", "nobr asc");
                foreach (DataRow Row1 in row1)
                {
                    DataRow row2 = DT_base.Rows.Find(Row1["nobr"].ToString());

                    if (row2 != null)
                    {
                        object[] value = new object[2];
                        value[0] = row2["compid"].ToString();
                        value[1] = row2["bankno"].ToString();

                        DataRow Row_Comp_Bank = DT_salary_transfer_bank.Rows.Find(value);

                        if (row2["account_ma"].ToString().Trim() != "")
                        {
                            DataRow aRow1 = DT_zz4215.NewRow();
                            aRow1["nobr"] = Row1["nobr"].ToString();
                            aRow1["name_c"] = Row1["name_c"].ToString();
                            aRow1["tt"] = int.Parse(Row1["amt"].ToString());
                            aRow1["idno"] = row2["idno"].ToString();
                            aRow1["count_ma"] = bool.Parse(row2["count_ma"].ToString());
                            aRow1["account_no"] = row2["account_ma"].ToString();
                            aRow1["compaccount"] = Row_Comp_Bank["COMPNAY_BANK_AC"].ToString();
                            if (row2["bankno"].ToString().Trim().Length < 3)
                            {
                                DataRow aRow = rq_err.NewRow();
                                aRow["員工編號"] = Row1["nobr"].ToString();
                                aRow["員工姓名"] = Row1["name_c"].ToString();
                                aRow["錯誤原因"] = "銀行代碼不足3碼";
                                rq_err.Rows.Add(aRow);
                                aRow1["bankno"] = row2["bankno"].ToString().Trim();
                            }
                            else
                                aRow1["bankno"] = row2["bankno"].ToString().Trim().Substring(0, 3);
                            aRow1["bankno_o"] = row2["bankno"].ToString().Trim();
                            if (bool.Parse(row2["count_ma"].ToString()))
                            {
                                //aRow1["bankno"] = row2["bank_code"].ToString(); //外籍儲蓄款銀行
                                aRow1["idno"] = row2["matno"].ToString();
                                aRow1["account_no"] = row2["account_ma"].ToString();
                            }

                            aRow1["compid"] = row2["compid"].ToString();
                            aRow1["saladr"] = row2["saladr"].ToString();
                            DT_zz4215.Rows.Add(aRow1);
                            totamt += int.Parse(Row1["amt"].ToString());
                        }
                    }
                }
            }


            foreach (DataRow Row in row)
            {
                DataRow row2 = DT_base.Rows.Find(Row["nobr"].ToString());
                if (int.Parse(Row[str_t].ToString()) > 0)
                {
                    object[] value = new object[2];
                    value[0] = Row["compid"].ToString();
                    value[1] = Row["bankno"].ToString();

                    DataRow Row_Comp_Bank = DT_salary_transfer_bank.Rows.Find(value);

                    DataRow aRow = DT_zz4215.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["tt"] = int.Parse(Row[str_t].ToString());
                    aRow["account_no"] = Row["account_no"].ToString();
                    aRow["compaccount"] = Row_Comp_Bank["COMPANY_BANK_AC"].ToString();
                    aRow["idno"] = Row["idno"].ToString();
                    aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                    aRow["compid"] = Row["compid"].ToString();
                    aRow["saladr"] = Row["saladr"].ToString();
                    if (Row["bankno"].ToString().Trim().Length < 3)
                    {
                        DataRow aRow2 = rq_err.NewRow();
                        aRow2["員工編號"] = Row["nobr"].ToString();
                        aRow2["員工姓名"] = Row["name_c"].ToString();
                        aRow2["錯誤原因"] = "銀行代碼不足3碼";
                        rq_err.Rows.Add(aRow2);
                        aRow["bankno"] = Row["bankno"].ToString().Trim();
                    }
                    else
                        aRow["bankno"] = Row["bankno"].ToString().Trim().Substring(0, 3);
                    aRow["bankno_o"] = Row["bankno"].ToString().Trim();
                    if (bool.Parse(Row["count_ma"].ToString()))
                        aRow["idno"] = row2["matno"].ToString();
                    if (string.IsNullOrEmpty(CompId))
                    {
                        CompId = Row["compid"].ToString();
                    }
                    if (string.IsNullOrEmpty(Compaccount))
                    {
                        Compaccount = Row["compaccount"].ToString();
                    }
                    if (string.IsNullOrEmpty(_FileName))
                    {
                        _FileName = Row_Comp_Bank["COMPANY_BANK_NAME"].ToString().Trim() + " - " + DateTime.Parse(date_t).ToString("yyyyMMdd") + ".txt";
                    }
                    DT_zz4215.Rows.Add(aRow);
                    totamt += int.Parse(Row[str_t].ToString());
                }
            }
            DataTable zz4215_bank = new DataTable();
            zz4215_bank.Columns.Add("bankno", typeof(string));
            zz4215_bank.Columns.Add("filename", typeof(string));
            zz4215_bank.PrimaryKey = new DataColumn[] { zz4215_bank.Columns["bankno"] };
            foreach (DataRow zz4215_row in DT_zz4215.Rows)
            {
                DataRow bank_row = zz4215_bank.Rows.Find(zz4215_row["bankno"].ToString());

                object[] value = new object[2];
                value[0] = zz4215_row["compid"].ToString();
                value[1] = zz4215_row["bankno"].ToString();
                DataRow Row_Comp_Bank = DT_salary_transfer_bank.Rows.Find(value);

                if (bank_row == null)
                {
                    DataRow new_bank_row = zz4215_bank.NewRow();
                    new_bank_row["bankno"] = zz4215_row["bankno"].ToString();
                    new_bank_row["filename"] = Row_Comp_Bank["COMPANY_BANK_NAME"].ToString().Trim() + " - " + DateTime.Parse(date_t).ToString("yyyyMMdd") + ".txt";

                    zz4215_bank.Rows.Add(new_bank_row);
                }
            }
            zz4215_bank.AcceptChanges();

            foreach (DataRow bank_row in zz4215_bank.Rows)
            {
                DataRow[] rowa1 = DT_zz4215.Select("bankno ='" + bank_row["bankno"].ToString() + "' ", "nobr asc");
                CompId = string.Empty;
                Compaccount = string.Empty;


                if (rowa1.Length > 0)
                {
                    toltalamt = 0;
                    toltalrow = 0;

                    foreach (DataRow Row in rowa1)
                    {
                        object[] value = new object[2];
                        value[0] = Row["compid"].ToString();
                        value[1] = bank_row["bankno"].ToString();
                        DataRow DT_Bank_Row = DT_salary_transfer_bank.Rows.Find(value);

                        if(DT_Bank_Row != null)
                        {
                            bool chk = bool.Parse("true");
                            int bankac_length = int.Parse(DT_Bank_Row["COMPANY_BANK_LENGTH"].ToString());
                            if (Row["account_no"].ToString().Trim().Length != bankac_length)
                            {
                                DataRow aRow = rq_err.NewRow();
                                aRow["員工編號"] = Row["nobr"].ToString();
                                aRow["員工姓名"] = Row["name_c"].ToString();
                                aRow["錯誤原因"] = "轉帳帳帳號不足或多於" + bankac_length.ToString() + "碼";
                                rq_err.Rows.Add(aRow);
                                chk = bool.Parse("false");
                            }
                            if (Row["idno"].ToString().Trim().Length != 10)
                            {
                                DataRow aRow = rq_err.NewRow();
                                aRow["員工編號"] = Row["nobr"].ToString();
                                aRow["員工姓名"] = Row["name_c"].ToString();
                                aRow["錯誤原因"] = "身分證號不足或多10碼";
                                rq_err.Rows.Add(aRow);
                                chk = bool.Parse("false");
                            }
                            if (string.IsNullOrEmpty(CompId))
                            {
                                CompId = Row["compid"].ToString();
                            }
                            if (string.IsNullOrEmpty(Compaccount))
                            {
                                Compaccount = Row["compaccount"].ToString();
                            }
                            if (chk)
                            {
                                toltalamt += int.Parse(Row["tt"].ToString());
                                toltalrow += 1;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(Compaccount)) throw new Exception("公司轉帳帳號未建立");
                    if (string.IsNullOrEmpty(CompId)) throw new Exception("公司統一編號未建立");
                    if (rq_err.Rows.Count > 0)
                    {
                        JBHR.Reports.ReportClass.Export(rq_err, "轉帳磁片失敗名單");
                        return;
                    }
                    

                    JBHR.Reports.SalForm.BankTransfer.Get_Bank(bank_row["bankno"].ToString(), rowa1, date_t, Compaccount, "", CompId, _Folder, bank_row["filename"].ToString(), DT_salary_transfer_bank, toltalamt.ToString(), toltalrow.ToString());

                    MessageBox.Show("產生轉帳磁片完畢 " + bank_row["filename"].ToString());
                    //_FileName = string.Empty;
                }

                CompId = string.Empty;
                Compaccount = string.Empty;
            }
        }
    }
}
