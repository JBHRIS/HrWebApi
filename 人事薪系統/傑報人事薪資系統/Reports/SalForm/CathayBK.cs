using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace JBHR.Reports.SalForm
{
    class CathayBK
    {
        public static void Get_Report7ABLECOMHR(DataTable DT_zz42ta, DataTable DT_zz42td, DataTable DT_base, DataTable DT_waged,DataTable DT_LateCnt, string date_t, bool tran_count,string BankCustID,string seq)
        {
            string _str1 = "";
            string str_t = ""; int _i = 1; int _len = 0;
            string yymmdd = Convert.ToString(DateTime.Parse(date_t).Year - 1911) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
            string yyymm = Convert.ToString(DateTime.Parse(date_t).Year - 1911).PadLeft(3, '0') + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0');
            string yyyymmdd = Convert.ToString(DateTime.Parse(date_t).Year) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
            string _datet = Convert.ToString(DateTime.Parse(date_t).Year - 1911).Substring(1, 2) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
            string _Folder = JBControls.ControlConfig.GetExportPath();
            string _FileName = string.Empty;
            string _space = "";
            int bankcnt = 0;
            int payrow = 0; //應發金額在第幾欄
            for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
            {
                if (DT_zz42ta.Rows[0]["Fld" + (i + 1)].ToString() == "應發薪資")
                {
                    payrow = (i + 1);
                }
                if (DT_zz42ta.Rows[0]["Fld" + (i + 1)].ToString() == "實發金額")
                {
                    str_t = "Fld" + (i + 1);
                    break;
                }
                
            }

            //外籍轉帳磁片
            DataRow[] row = DT_zz42td.Select("cash=0 and adate='" + date_t + "' and count_ma=1", "nobr asc");  //and account_no <> ''
            DataTable DT_zz4215 = new DataTable();
            DT_zz4215.Columns.Add("nobr", typeof(string));
            DT_zz4215.Columns.Add("name_c", typeof(string));
            DT_zz4215.Columns.Add("count_ma", typeof(bool));
            DT_zz4215.Columns.Add("idno", typeof(string));
            DT_zz4215.Columns.Add("account_no", typeof(string));
            DT_zz4215.Columns.Add("bankno", typeof(string));
            DT_zz4215.Columns.Add("compid", typeof(string));
            DT_zz4215.Columns.Add("saladr", typeof(string));
            DT_zz4215.Columns.Add("compaccount", typeof(string));
            DT_zz4215.Columns.Add("tt", typeof(int));
            DT_zz4215.Columns.Add("err", typeof(bool));
            int totamt = 0;

            DataTable rq_err = new DataTable();
            rq_err.Columns.Add("員工編號", typeof(string));
            rq_err.Columns.Add("員工姓名", typeof(string));
            rq_err.Columns.Add("錯誤原因", typeof(string));
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
                    aRow["bankno"] = Row["bankno"].ToString().Trim();
                    if (bool.Parse(Row["count_ma"].ToString()))
                        aRow["idno"] = row2["matno"].ToString();
                    aRow["err"] = bool.Parse("false");
                    DT_zz4215.Rows.Add(aRow);
                    totamt += int.Parse(Row[str_t].ToString());
                }
            }
            
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
                            aRow1["bankno"] = row2["bankno"].ToString().Trim();
                            if (bool.Parse(row2["count_ma"].ToString()))
                            {
                                aRow1["idno"] = row2["matno"].ToString();
                                aRow1["account_no"] = row2["account_ma"].ToString();
                            }
                            aRow1["compid"] = row2["compid"].ToString();
                            aRow1["saladr"] = row2["saladr"].ToString();
                            aRow1["err"] = bool.Parse("false");
                            DT_zz4215.Rows.Add(aRow1);
                            totamt += int.Parse(Row1["amt"].ToString());
                        }
                    }
                }

                //國泰世華               
                DataRow[] rowa3 = DT_zz4215.Select("bankno='013' and count_ma=1 and tt>0 ", "nobr asc");                
                int rowcnt2 = rowa3.Length;
                
                if (rowa3.Length > 0)
                {
                    _FileName += "國泰世華外籍" + yyyymmdd + ".txt";
                    //if (string.IsNullOrEmpty(compaccount)) throw new Exception("公司轉帳帳號未建立");
                    foreach (DataRow Row5 in rowa3)
                    {
                        int lnameen = 48;
                        int nameclen = Row5["name_c"].ToString().Trim().Length;
                        if (nameclen == 4)
                            lnameen = 43;
                        else if (nameclen == 2)
                            lnameen = 47;
                        else
                            lnameen = 45;
                        bool _err = false;
                        string aa = Row5["account_no"].ToString();
                        if (Row5["account_no"].ToString().Trim().Length != 12)
                        {
                            //throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  土地銀行帳號不足或多11碼");
                            _err = true;
                            Row5["err"] = _err;
                            DataRow aRow = rq_err.NewRow();
                            aRow["員工編號"] = Row5["nobr"].ToString();
                            aRow["員工姓名"] = Row5["name_c"].ToString();
                            aRow["錯誤原因"] = "國泰世華帳號不足或多12碼";
                            rq_err.Rows.Add(aRow);
                        }
                        if (Row5["idno"].ToString().Trim().Length != 10)
                        {
                            //throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  身分證號不足或多11碼");
                            _err = true;
                            Row5["err"] = _err;
                            DataRow aRow = rq_err.NewRow();
                            aRow["員工編號"] = Row5["nobr"].ToString();
                            aRow["員工姓名"] = Row5["name_c"].ToString();
                            aRow["錯誤原因"] = "身分證號不足或多10碼";
                            rq_err.Rows.Add(aRow);
                        }
                        if (!_err)
                        {
                            totamt += int.Parse(Row5["tt"].ToString());
                            bankcnt += 1;
                        }
                    }
                    

                    File.Delete(_Folder +_FileName);
                    ////第一筆                
                    StreamWriter sw = new StreamWriter(_Folder + _FileName, true, Encoding.Default);
                    _str1 = "1" + "000" + BankCustID + "01300000" + yyyymmdd + "900" + "  " + "1" + "99" + _space.PadLeft(167, ' ');
                    sw.WriteLine("" + _str1 + "");
                    int _rowcnt = 1;
                    foreach (DataRow Row5 in DT_zz4215.Select("bankno='013' and count_ma=1 and err=0 and tt>0 ", "nobr asc"))
                    {
                        int _nobrlen = Row5["nobr"].ToString().Length + 2;
                        int _nameclen = Row5["name_c"].ToString().Length * 2;
                        string aa = Row5["account_no"].ToString();                        
                        //if (Row5["name_c"].ToString().Length == 4)
                        //    _str1 = "2" + "000" + BankCustID + "01300000" + yyyymmdd + "900" + "  " + "0" + "99" + _rowcnt.ToString().PadLeft(7, '0') + (Row5["tt"].ToString()).PadLeft(9, '0') + "00" + _space.PadLeft(8, ' ') + "01300000" + "0000" + Row5["account_no"].ToString().Trim().PadLeft(12, '0') + Row5["idno"].ToString().Trim().PadLeft(10, ' ') + _space.PadLeft(12, ' ') + "9999" + _space.PadLeft(12, ' ') + "0000" + _space.PadLeft(14, ' ') + Row5["name_c"].ToString().Trim() + "(" + Row5["nobr"].ToString() + ")" + _space.PadRight(48 - _nobrlen, ' ');
                        //else if (Row5["name_c"].ToString().Length == 2)
                        //    _str1 = "2" + "000" + BankCustID + "01300000" + yyyymmdd + "900" + "  " + "0" + "99" + _rowcnt.ToString().PadLeft(7, '0') + (Row5["tt"].ToString()).PadLeft(9, '0') + "00" + _space.PadLeft(8, ' ') + "01300000" + "0000" + Row5["account_no"].ToString().Trim().PadLeft(12, '0') + Row5["idno"].ToString().Trim().PadLeft(10, ' ') + _space.PadLeft(12, ' ') + "9999" + _space.PadLeft(12, ' ') + "0000" + _space.PadLeft(14, ' ') + Row5["name_c"].ToString().Trim() + "(" + Row5["nobr"].ToString() + ")" + _space.PadRight(52 - _nobrlen, ' ');
                        //else
                        //    _str1 = "2" + "000" + BankCustID + "01300000" + yyyymmdd + "900" + "  " + "0" + "99" + _rowcnt.ToString().PadLeft(7, '0') + (Row5["tt"].ToString()).PadLeft(9, '0') + "00" + _space.PadLeft(8, ' ') + "01300000" + "0000" + Row5["account_no"].ToString().Trim().PadLeft(12, '0') + Row5["idno"].ToString().Trim().PadLeft(10, ' ') + _space.PadLeft(12, ' ') + "9999" + _space.PadLeft(12, ' ') + "0000" + _space.PadLeft(14, ' ') + Row5["name_c"].ToString().Trim() + "(" + Row5["nobr"].ToString() + ")" + _space.PadRight(50 - _nobrlen, ' ');

                        _str1 = "2" + "000" + BankCustID + "01300000" + yyyymmdd + "900" + "2 " + "0" + "99" + _rowcnt.ToString().PadLeft(7, '0') + (Row5["tt"].ToString()).PadLeft(11, '0') + "00" + _space.PadLeft(8, ' ') + "0130000" + "0000" + Row5["account_no"].ToString().Trim().PadLeft(12, '0') + Row5["idno"].ToString().Trim().PadLeft(10, ' ') + _space.PadLeft(16, ' ') + "9999" + _space.PadLeft(12, ' ') + "0000" + _space.PadLeft(14, ' ') + Row5["name_c"].ToString().Trim() + "(" + Row5["nobr"].ToString() + ")" + _space.PadRight(56 - _nameclen - _nobrlen, ' ');

                        sw.WriteLine("" + _str1 + "");
                        _rowcnt += 1;
                    }
                    _str1 = "3" + "000" + BankCustID + "01300000" + yyyymmdd + "900" + "  " + "+" + totamt.ToString().PadLeft(13, '0') + "00" + _rowcnt.ToString().PadLeft(10, '0') + "+" + _space.PadLeft(25, '0') + "+" + _space.PadLeft(25, '0') + _space.PadLeft(92, ' ');
                    sw.WriteLine("" + _str1 + "");
                    sw.Close();

                    if (rq_err.Rows.Count > 0)
                    {
                        JBHR.Reports.ReportClass.Export(rq_err, "外籍轉帳磁片失敗名單");                        
                    }

                    MessageBox.Show("產生外籍磁片完畢 " + _FileName);

                    //object postsum1 = DT_zz4215.Compute("Sum(tt)", "bankno='013'");
                    //MessageBox.Show("產生外籍磁片完畢 " + _FileName + " 總共" + Convert.ToString(bankcnt) + "筆 總金額" + Convert.ToString(totamt) + "元");
                }                
                DT_zz4215.Clear();
                rq_err.Clear();
            }


            
            DataRow[] row6 = DT_zz42td.Select("adate='" + date_t + "' and count_ma=0 and cash=0", "nobr asc");    //cash=0 and account_no <> '' and
            totamt = 0;
            DT_zz42td.Columns.Add("err", typeof(bool));
            foreach (DataRow Row in row6)
            {
                //DataRow row2 = DT_base.Rows.Find(Row["nobr"].ToString());
                //if (int.Parse(Row[str_t].ToString()) > 0)
                //{
                //    DataRow aRow = DT_zz4215.NewRow();
                //    aRow["nobr"] = Row["nobr"].ToString();
                //    aRow["name_c"] = Row["name_c"].ToString();
                //    aRow["tt"] = int.Parse(Row[str_t].ToString());
                //    aRow["account_no"] = Row["account_no"].ToString();
                //    aRow["compaccount"] = Row["compaccount"].ToString();
                //    aRow["idno"] = Row["idno"].ToString();
                //    aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                //    aRow["compid"] = Row["compid"].ToString();
                //    aRow["saladr"] = Row["saladr"].ToString();
                //    aRow["bankno"] = Row["bankno"].ToString().Trim();
                //    //if (bool.Parse(Row["count_ma"].ToString()))
                //    //    aRow["idno"] = row2["matno"].ToString();
                //    aRow["err"] = bool.Parse("false");
                //    DT_zz4215.Rows.Add(aRow);
                //    totamt += int.Parse(Row[str_t].ToString());
                //}
                bool _err = false;
                Row["err"] = _err;
                if (Row["idno"].ToString().Trim().Length != 10)
                {
                    _err = true;
                    Row["err"] = _err;
                    DataRow aRow = rq_err.NewRow();
                    aRow["員工編號"] = Row["nobr"].ToString();
                    aRow["員工姓名"] = Row["name_c"].ToString();
                    aRow["錯誤原因"] = "身分證號不足或多10碼";
                    rq_err.Rows.Add(aRow);
                }
            }

            JBModule.Data.CSQL Sql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ42", MainForm.COMPANY);
            string[] BankBaseSal = AppConfig.GetConfig("BankBaseSal").Value.Split(',');
            string[] BankFoodSal = AppConfig.GetConfig("BankFoodSal").Value.Split(',');
            string[] BankOTSal = AppConfig.GetConfig("BankOTSal").Value.Split(',');
            string[] BankLaborSal = AppConfig.GetConfig("BankLaborSal").Value.Split(',');
            string[] BankHealthSal = AppConfig.GetConfig("BankHealthSal").Value.Split(',');
            string[] BankRetSal = AppConfig.GetConfig("BankRetSal").Value.Split(',');
            string[] BankTaxSal = AppConfig.GetConfig("BankTaxSal").Value.Split(',');

            //DataTable rq_sys4 = Sql.GetDataTable("select b.sal_code_disp as lsalcode,c.sal_code_disp as retsalcode from u_sys4 a left outer join salcode b on a.lsalcode=b.sal_code left outer join salcode c on a.retsalcode=c.sal_code where a.comp='" + MainForm.COMPANY + "'");
            //DataTable rq_sys5 = Sql.GetDataTable("select b.sal_code_disp as hsalcode from u_sys5 a left outer join salcode b on a.hsalcode=b.sal_code where a.comp='" + MainForm.COMPANY + "'");
            //DataTable rq_sys9 = Sql.GetDataTable("select b.sal_code_disp as taxsalcode from u_sys9 a left outer join salcode b on a.taxsalcode=b.sal_code where a.comp='" + MainForm.COMPANY + "'");
            //string lsalcode = (rq_sys4.Rows.Count > 0) ? rq_sys4.Rows[0]["lsalcode"].ToString() : "";
            //string retsalcode = (rq_sys4.Rows.Count > 0) ? rq_sys4.Rows[0]["retsalcode"].ToString() : "";
            //string hsalcode = (rq_sys5.Rows.Count > 0) ? rq_sys5.Rows[0]["hsalcode"].ToString() : "";
            //string taxsalcode = (rq_sys9.Rows.Count > 0) ? rq_sys9.Rows[0]["taxsalcode"].ToString() : "";

            DataTable rq_fixSal = new DataTable();
            rq_fixSal.Columns.Add("nobr", typeof(string));
            rq_fixSal.Columns.Add("BaseAmt", typeof(int));//本薪
            rq_fixSal.Columns.Add("FoodAmt", typeof(int));//伙食津貼
            rq_fixSal.Columns.Add("OTAmt", typeof(int));//加班費
            rq_fixSal.Columns.Add("LaborAmt", typeof(int));//勞保費
            rq_fixSal.Columns.Add("HealthAmt", typeof(int));//健保費
            rq_fixSal.Columns.Add("RetAmt", typeof(int));//勞退自提
            rq_fixSal.Columns.Add("TaxAmt", typeof(int));//所得稅
            rq_fixSal.PrimaryKey = new DataColumn[] { rq_fixSal.Columns["nobr"] };
            string NODisp = "應稅薪資,應發薪資,實發薪資,";
            foreach(DataRow Row in DT_waged.Rows)
            {
                DataRow row1 = rq_fixSal.Rows.Find(Row["nobr"].ToString());
                string  _salcode=Row["sal_code"].ToString();

                //本薪
                foreach (string BaseSal in BankBaseSal)
                {
                    if ( _salcode== BaseSal.Trim())
                    {
                        if (row1!=null)
                        {
                            row1["BaseAmt"] = int.Parse(row1["BaseAmt"].ToString()) + int.Parse(Row["amt"].ToString());
                        }
                        else
                        {
                            DataRow aRow = rq_fixSal.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["BaseAmt"] = int.Parse(Row["amt"].ToString());
                            aRow["FoodAmt"] =0;
                            aRow["OTAmt"] = 0;
                            aRow["LaborAmt"] = 0;
                            aRow["HealthAmt"] = 0;
                            aRow["RetAmt"] = 0;
                            aRow["TaxAmt"] = 0;
                            rq_fixSal.Rows.Add(aRow);
                        }
                        if (NODisp.IndexOf(Row["sal_name"].ToString()) < 0)
                            NODisp += Row["sal_name"].ToString() + ",";
                    }
                }

                //伙食津貼
                foreach (string FoodSal in BankFoodSal)
                {
                    if (_salcode == FoodSal.Trim())
                    {
                        if (row1 != null)
                        {
                            row1["FoodAmt"] = int.Parse(row1["FoodAmt"].ToString()) + int.Parse(Row["amt"].ToString());
                        }
                        else
                        {
                            DataRow aRow = rq_fixSal.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["BaseAmt"] = 0;
                            aRow["FoodAmt"] = int.Parse(Row["amt"].ToString());
                            aRow["OTAmt"] = 0;
                            aRow["LaborAmt"] = 0;
                            aRow["HealthAmt"] = 0;
                            aRow["RetAmt"] = 0;
                            aRow["TaxAmt"] = 0;
                            rq_fixSal.Rows.Add(aRow);
                        }
                        if (NODisp.IndexOf(Row["sal_name"].ToString()) < 0)
                            NODisp += Row["sal_name"].ToString() + ",";
                    }
                }

                //加班費
                foreach (string OTSal in BankOTSal)
                {
                    if (_salcode == OTSal.Trim())
                    {
                        if (row1 != null)
                        {
                            row1["OTAmt"] = int.Parse(row1["OTAmt"].ToString()) + int.Parse(Row["amt"].ToString());
                        }
                        else
                        {
                            DataRow aRow = rq_fixSal.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["BaseAmt"] = 0;
                            aRow["FoodAmt"] = 0;
                            aRow["OTAmt"] = int.Parse(Row["amt"].ToString());
                            aRow["LaborAmt"] = 0;
                            aRow["HealthAmt"] = 0;
                            aRow["RetAmt"] = 0;
                            aRow["TaxAmt"] = 0;
                            rq_fixSal.Rows.Add(aRow);
                        }
                        if (NODisp.IndexOf(Row["sal_name"].ToString()) < 0)
                            NODisp += Row["sal_name"].ToString() + ",";
                    }
                }

                //勞保費
                foreach (string OTSal in BankLaborSal)
                {
                    if (_salcode == OTSal.Trim())
                    {
                        if (row1 != null)
                        {
                            row1["LaborAmt"] = int.Parse(row1["LaborAmt"].ToString()) + int.Parse(Row["amt"].ToString());
                        }
                        else
                        {
                            DataRow aRow = rq_fixSal.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["BaseAmt"] = 0;
                            aRow["FoodAmt"] = 0;
                            aRow["OTAmt"] = 0;
                            aRow["LaborAmt"] = int.Parse(Row["amt"].ToString());
                            aRow["HealthAmt"] = 0;
                            aRow["RetAmt"] = 0;
                            aRow["TaxAmt"] = 0;
                            rq_fixSal.Rows.Add(aRow);
                        }
                        if (NODisp.IndexOf(Row["sal_name"].ToString()) < 0)
                            NODisp += Row["sal_name"].ToString() + ",";
                    }
                }

                //健保費
                foreach (string OTSal in BankHealthSal)
                {
                    if (_salcode == OTSal.Trim())
                    {
                        if (row1 != null)
                        {
                            row1["HealthAmt"] = int.Parse(row1["HealthAmt"].ToString()) + int.Parse(Row["amt"].ToString());
                        }
                        else
                        {
                            DataRow aRow = rq_fixSal.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["BaseAmt"] = 0;
                            aRow["FoodAmt"] = 0;
                            aRow["OTAmt"] = 0;
                            aRow["LaborAmt"] = 0;
                            aRow["HealthAmt"] = int.Parse(Row["amt"].ToString());
                            aRow["RetAmt"] = 0;
                            aRow["TaxAmt"] = 0;
                            rq_fixSal.Rows.Add(aRow);
                        }
                        if (NODisp.IndexOf(Row["sal_name"].ToString()) < 0)
                            NODisp += Row["sal_name"].ToString() + ",";
                    }
                }

                //勞退自提
                foreach (string OTSal in BankRetSal)
                {
                    if (_salcode == OTSal.Trim())
                    {
                        if (row1 != null)
                        {
                            row1["RetAmt"] = int.Parse(row1["RetAmt"].ToString()) + int.Parse(Row["amt"].ToString());
                        }
                        else
                        {
                            DataRow aRow = rq_fixSal.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["BaseAmt"] = 0;
                            aRow["FoodAmt"] = 0;
                            aRow["OTAmt"] = 0;
                            aRow["LaborAmt"] = 0;
                            aRow["HealthAmt"] = 0;
                            aRow["RetAmt"] = int.Parse(Row["amt"].ToString());
                            aRow["TaxAmt"] = 0;
                            rq_fixSal.Rows.Add(aRow);
                        }
                        if (NODisp.IndexOf(Row["sal_name"].ToString()) < 0)
                            NODisp += Row["sal_name"].ToString() + ",";
                    }
                }

                //所得稅
                foreach (string OTSal in BankTaxSal)
                {
                    if (_salcode == OTSal.Trim())
                    {
                        if (row1 != null)
                        {
                            row1["TaxAmt"] = int.Parse(row1["TaxAmt"].ToString()) + int.Parse(Row["amt"].ToString());
                        }
                        else
                        {
                            DataRow aRow = rq_fixSal.NewRow();
                            aRow["nobr"] = Row["nobr"].ToString();
                            aRow["BaseAmt"] = 0;
                            aRow["FoodAmt"] = 0;
                            aRow["OTAmt"] = 0;
                            aRow["LaborAmt"] = 0;
                            aRow["HealthAmt"] = 0;
                            aRow["RetAmt"] = 0;
                            aRow["TaxAmt"] = int.Parse(Row["amt"].ToString());
                            rq_fixSal.Rows.Add(aRow);
                        }
                        if (NODisp.IndexOf(Row["sal_name"].ToString()) < 0)
                            NODisp += Row["sal_name"].ToString() + ",";
                    }
                }
            }

            DataTable rq_merge = new DataTable();
            rq_merge.Columns.Add("nobr", typeof(string));
            rq_merge.Columns.Add("sal_code", typeof(string));
            rq_merge.Columns.Add("sal_name", typeof(string));
            rq_merge.Columns.Add("sal_ename", typeof(string));
            rq_merge.Columns.Add("flag", typeof(string));
            rq_merge.Columns.Add("amt", typeof(decimal));
            rq_merge.PrimaryKey = new DataColumn[] { rq_merge.Columns["nobr"], rq_merge.Columns["sal_name"] };
            DataRow[] Mrow = DT_waged.Select("", "nobr,salattr,sal_code asc");
            foreach (DataRow Row in Mrow)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["sal_name"].ToString();
                DataRow rowm = rq_merge.Rows.Find(_value);
                if (rowm != null)
                {
                    rowm["amt"] = decimal.Parse(rowm["amt"].ToString()) + decimal.Parse(Row["amt"].ToString());
                }
                else
                {
                    DataRow aRow = rq_merge.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["sal_code"] = Row["sal_code"].ToString();
                    aRow["sal_name"] = Row["sal_name"].ToString();
                    aRow["sal_ename"] = Row["sal_ename"].ToString();
                    aRow["flag"] = Row["flag"].ToString();
                    aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    rq_merge.Rows.Add(aRow);
                }
            }
            
            _FileName = "國泰世華電子薪資單" + yyyymmdd + ".txt";
            File.Delete(_Folder + _FileName);           
            totamt = 0;
            bankcnt = 0;
            DataRow[] SRow1 = DT_zz42td.Select("adate='" + date_t + "' and count_ma=0 and err=0", "nobr asc");
            if (SRow1.Length > 0)
            {
                ////第一筆
                StreamWriter sw1 = new StreamWriter(_Folder + _FileName, true, Encoding.Default);
                foreach (DataRow Row in SRow1)
                {
                    if (int.Parse(Row[str_t].ToString()) > 0)
                    {
                        totamt += int.Parse(Row[str_t].ToString());
                        bankcnt += 1;
                        int _nobrlen = Row["nobr"].ToString().Length + 2;
                        int _nameclen = Row["name_c"].ToString().Length * 2;
                        _str1 = Row["idno"].ToString() + Row["account_no"].ToString().Trim().PadRight(16, ' ') + Row["name_c"].ToString().Trim() + _space.PadRight(20 - GetFullLenStr(Row["name_c"].ToString()), ' ') + Convert.ToString(int.Parse(Row[str_t].ToString())).PadLeft(8, '0') + _space.PadLeft(60, ' ');

                        DataRow row1 = rq_fixSal.Rows.Find(Row["nobr"].ToString());
                        if (row1 != null)
                        {
                            _str1 += row1["BaseAmt"].ToString().PadLeft(8, '0');
                            _str1 += row1["FoodAmt"].ToString().PadLeft(8, '0');
                            _str1 += row1["OTAmt"].ToString().PadLeft(8, '0');
                        }
                        else
                            _str1 += _space.PadLeft(24, '0');
                        int addcnt = 1;
                        DataRow[] rowm = rq_merge.Select("nobr='" + Row["nobr"].ToString() + "' and flag=''", "sal_code asc");
                        for (int i = 0; i < rowm.Length; i++)
                        {
                            if (NODisp.IndexOf(rowm[i]["sal_name"].ToString()) < 0 && addcnt < 16)
                            {
                                _str1 += rowm[i]["sal_name"].ToString().Trim() + _space.PadLeft(16 - GetFullLenStr(rowm[i]["sal_name"].ToString().Trim()), ' ');
                                _str1 += rowm[i]["amt"].ToString().PadLeft(7, '0');
                                addcnt += 1;
                            }
                        }

                        if (addcnt < 15)
                        {
                            for (int j = addcnt; j < 16; j++)
                            {
                                _str1 += "空白項" + _space.PadRight(10, ' ') + _space.PadLeft(7, '0');
                            }
                        }
                        _str1 += "空白項" + _space.PadRight(24, ' ');

                        //勞保費、公保農保、健保費、所得稅、  勞退自提
                        if (row1 != null)
                        {
                            _str1 += row1["LaborAmt"].ToString().PadLeft(8, '0') + _space.PadLeft(16, '0');
                            _str1 += row1["HealthAmt"].ToString().PadLeft(8, '0');
                            _str1 += row1["TaxAmt"].ToString().PadLeft(8, '0');
                            _str1 += row1["RetAmt"].ToString().PadLeft(8, '0');
                        }
                        else
                            _str1 += _space.PadLeft(48, '0');

                        addcnt = 1;
                        DataRow[] rowm1 = rq_merge.Select("nobr='" + Row["nobr"].ToString() + "' and flag='-'", "sal_code asc");
                        for (int i = 0; i < rowm1.Length; i++)
                        {
                            if (NODisp.IndexOf(rowm1[i]["sal_name"].ToString()) < 0 && addcnt < 16)
                            {
                                _str1 += rowm1[i]["sal_name"].ToString().Trim() + _space.PadLeft(16 - GetFullLenStr(rowm1[i]["sal_name"].ToString().Trim()), ' ');
                                _str1 += rowm1[i]["amt"].ToString().PadLeft(7, '0');
                                addcnt += 1;
                            }
                        }

                        if (addcnt < 15)
                        {
                            for (int j = addcnt; j < 16; j++)
                            {
                                _str1 += "空白項" + _space.PadRight(10, ' ') + _space.PadLeft(7, '0');
                            }
                        }

                        DataRow row7 = DT_LateCnt.Rows.Find(Row["nobr"].ToString());
                        //int latecnt = (row7 != null) ? int.Parse(row7["cnt"].ToString()) : 0;
                        int latecnt = 0;
                        _str1 += "遲到" + latecnt.ToString().PadRight(2, ' ') + "次" + _space.PadLeft(22, ' ');
                        //if (bool.Parse(Row["cash"].ToString()))
                        //    _str1 += Convert.ToString(int.Parse(Row[str_t].ToString())).PadLeft(8, '0');
                        //else
                        //    _str1 += _space.PadLeft(8, '0');
                        _str1 += _space.PadLeft(8, '0');    //領現欄位
                        _str1 += yyymm;
                        if (GetFullLenStr(Row["note"].ToString().Trim()) > 30)
                        {                            
                            _str1 += GetNoteStr(Row["note"].ToString().Trim(), 30);
                        }
                        else
                        {
                            _str1 += Row["note"].ToString().Trim() + _space.PadLeft(30 - GetFullLenStr(Row["note"].ToString().Trim()), ' ');
                           
                        }
                        _str1 += _space.PadLeft(21, ' ');
                        sw1.WriteLine("" + _str1 + "");
                    }
                }
                sw1.Close();

                if (rq_err.Rows.Count > 0)
                {
                    JBHR.Reports.ReportClass.Export(rq_err, "電子薪資單失敗名單");
                }
                MessageBox.Show("產生電子薪資單完畢 " + _FileName);
                //MessageBox.Show("產生電子薪資單完畢 " + _FileName + " 總共" + Convert.ToString(bankcnt) + "筆 總金額" + Convert.ToString(totamt) + "元");
            }

            rq_err = null; rq_fixSal = null;
        }


        public static void Get_Report7_JTFLEXHR(DataTable DT_zz42ta, DataTable DT_zz42td, DataTable DT_base, DataTable DT_waged, DataTable DT_LateCnt, string date_t, bool tran_count, string BankCustID, string seq)
        {
            string str_t = ""; 

            for (int i = 0; i < DT_zz42ta.Columns.Count; i++)
            {
                if (DT_zz42ta.Rows[0]["Fld" + (i + 1)].ToString() == "實發金額")
                {
                    str_t = "Fld" + (i + 1);
                    break;
                }

            }
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("姓名", typeof(string));
            ExporDt.Columns.Add("戶名", typeof(string));
            ExporDt.Columns.Add("薪資帳號", typeof(string));
            ExporDt.Columns.Add("實發金額", typeof(string));
            ExporDt.Columns.Add("身分證字號", typeof(string));
            ExporDt.Columns.Add("銀行代號", typeof(string));



            foreach (DataRow Row01 in DT_zz42td.Select("adate='" + date_t + "' and count_ma=0 and cash=0", "nobr asc"))
            {
                string AAD = Row01["nobr"].ToString();
                DataRow aRow = ExporDt.NewRow();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["姓名"] = Row01["name_c"].ToString();
                aRow["戶名"] = Row01["name_c"].ToString();
                aRow["薪資帳號"] = Row01["account_no"].ToString();
                aRow["實發金額"] = int.Parse(Row01[str_t].ToString());
                aRow["身分證字號"] = Row01["idno"].ToString();
                aRow["銀行代號"] = Row01["bankno"].ToString();

                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export1(ExporDt, "日翔-渣打銀行薪轉EXCEL");
        }


            static int GetFullLenStr(string str)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(str.Trim());

            //string emptyStr = "".PadRight(len - bytes.Length, ' ');
            //string ss = str.Trim() + emptyStr;
            return bytes.Length;
        }

        static string GetNoteStr(string str, int len)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(str.Trim());
            int countlen = 0;
            string emptyStr = "";
            for(int i=0;i <str.Length;i++)
            {
                string str1 = str.Substring(i, 1);
                int bytes1 = GetFullLenStr(str1);
                countlen += bytes1;
                if(countlen<=len)
                {
                    emptyStr += str1;
                }
            }
            return emptyStr;
        }
    }

    
}

