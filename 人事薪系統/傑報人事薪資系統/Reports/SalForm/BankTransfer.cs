
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace JBHR.Reports.SalForm
{
    class BankTransfer
    {
        public static void Bank004(DataRow[] TransData, string date_t, string compaccount, string CompID, string Num, string totalamt, string totalcnt, string Folder, string FileName)
        {
            //套用台灣銀行轉帳格式
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var HList = new List<Dictionary<string, string>>();
            Dictionary<string, string> bodydt1 = new Dictionary<string, string>()
                {
                    {Sal.SettingNameHeader.CompAccount,compaccount},
                    {Sal.SettingNameHeader.TaxID,CompID},
                    {Sal.SettingNameHeader.ComID1,Num},
                    {Sal.SettingNameHeader.CompAmt,totalamt},
                    {Sal.SettingNameHeader.TotalRecord,totalcnt},
                    {Sal.SettingNameHeader.Date,date_t}
                };
            HList.Add(bodydt1);
            OUPT.AddData("004", "Header", HList);

            var TList = new List<Dictionary<string, string>>();
            int _rowcnt = 1;
            foreach (DataRow Row5 in TransData)
            {
                //if (Row5["account_no"].ToString().Trim().Length < 13 || Row5["account_no"].ToString().Trim().Length > 14) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + " 台新銀行帳號不足或多14碼");
                //if (Row5["idno"].ToString().Trim().Length != 10) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  身份證號或統一證號,不足或多10碼");
                Dictionary<string, string> bodydt = new Dictionary<string, string>()
                {
                    {Sal.SettingNameBody.TransMemo1,_rowcnt.ToString()},
                    {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                    {Sal.SettingNameBody.IDNO,Row5["idno"].ToString()},
                    {Sal.SettingNameBody.Date,date_t},
                    {Sal.SettingNameBody.Amt,Row5["tt"].ToString()}
                };
                TList.Add(bodydt);
                _rowcnt += 1;
            }
            OUPT.AddData("004", "Body", TList);
            OUPT.ExportTxt(Folder, FileName);

        }
        public static void Bank047(DataRow[] TransData, string date_t, string BranchCode, string CompID, string Folder, string FileName)
        {
            //套用玉山銀行轉帳格式
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var TList = new List<Dictionary<string, string>>();

            foreach (DataRow Row5 in TransData)
            {
                if (Row5["idno"].ToString().Trim().Length != 10) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  身份證號或統一證號,不足或多10碼");
                if (Row5["account_no"].ToString().Trim().Length != 13) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  玉山銀行帳號不足或多13碼");
                Dictionary<string, string> bodydt = new Dictionary<string, string>()
                {
                     {Sal.SettingNameBody.Date,date_t},
                     {Sal.SettingNameBody.BranchCode,BranchCode},
                     {Sal.SettingNameBody.ComID1,CompID},
                     {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                     {Sal.SettingNameBody.IDNO, Row5["idno"].ToString().Trim()},
                     {Sal.SettingNameBody.Amt,Row5["tt"].ToString()},
                };
                TList.Add(bodydt);
            }
            OUPT.AddData("047", "Body", TList);
            OUPT.ExportTxt(Folder, FileName);
            string dd = string.Empty;
        }

        public static void Bank054(DataRow[] TransData, string date_t, string BranchCode, string CompID, string Num, string totalamt, string totalcnt, string Folder, string FileName)
        {
            //套用台灣銀行轉帳格式
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var HList = new List<Dictionary<string, string>>();

            Dictionary<string, string> bodydt1 = new Dictionary<string, string>()
                {
                    {Sal.SettingNameHeader.ExportDate,DateTime.Now.ToString("yyyy/MM/dd")},
                     {Sal.SettingNameHeader.Date,date_t},
                     {Sal.SettingNameHeader.BranchCode,BranchCode},
                     {Sal.SettingNameHeader.TaxID,CompID},
                     {Sal.SettingNameHeader.ComID1,Num},
                     {Sal.SettingNameHeader.CompAmt,totalamt},
                     {Sal.SettingNameHeader.TotalRecord,totalcnt}
                };
            HList.Add(bodydt1);
            OUPT.AddData("054", "Header", HList);

            var TList = new List<Dictionary<string, string>>();
            foreach (DataRow Row5 in TransData)
            {
                if (Row5["account_no"].ToString().Trim().Length != 12) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  帳號不足或多於12碼");
                if (Row5["idno"].ToString().Trim().Length != 10) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  身份證號或統一證號,不足或多10碼");
                Dictionary<string, string> bodydt = new Dictionary<string, string>()
                {
                     {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                     {Sal.SettingNameBody.IDNO, Row5["idno"].ToString().Trim()},
                     {Sal.SettingNameBody.Amt,Row5["tt"].ToString()},
                };
                TList.Add(bodydt);
            }
            OUPT.AddData("054", "Body", TList);
            OUPT.ExportTxt(Folder, FileName);
            string dd = string.Empty;
        }

        public static void Bank005(DataRow[] TransData, string date_t, string BranchCode, string CompID, string Num, string totalamt, string totalcnt, string Folder, string FileName)
        {
            //套用土地銀行轉帳格式
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var HList = new List<Dictionary<string, string>>();

            Dictionary<string, string> bodydt1 = new Dictionary<string, string>()
                {
                    {Sal.SettingNameHeader.ComID1,Num},
                    {Sal.SettingNameHeader.BranchCode,BranchCode},
                    {Sal.SettingNameHeader.Date,date_t}
                     
                     
                     //{Sal.SettingNameHeader.ComID1,Num},
                     //{Sal.SettingNameHeader.CompAmt,totalamt},
                     //{Sal.SettingNameHeader.TotalRecord,totalcnt}
                };
            HList.Add(bodydt1);
            OUPT.AddData("005", "Header", HList);

            var TList = new List<Dictionary<string, string>>();
            foreach (DataRow Row5 in TransData)
            {
                Dictionary<string, string> bodydt = new Dictionary<string, string>()
                {
                    {Sal.SettingNameBody.ComID1,Num},
                    {Sal.SettingNameBody.BranchCode,BranchCode},
                    {Sal.SettingNameBody.Date,date_t},
                    {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                    {Sal.SettingNameBody.Amt,Row5["tt"].ToString()},
                    {Sal.SettingNameBody.TaxID,CompID}
                };
                TList.Add(bodydt);
            }
            OUPT.AddData("005", "Body", TList);

            var FList = new List<Dictionary<string, string>>();
            Dictionary<string, string> footerdt1 = new Dictionary<string, string>()
            {
                {Sal.SettingNameFooter.ComID1,Num},
                {Sal.SettingNameFooter.BranchCode,BranchCode},
                {Sal.SettingNameFooter.Date,date_t},
                {Sal.SettingNameFooter.CompAmt,totalamt},
                {Sal.SettingNameFooter.TotalRecord,totalcnt}

            };
            FList.Add(footerdt1);
            OUPT.AddData("005", "Footer", FList);
            OUPT.ExportTxt(Folder, FileName);

        }

        public static void Bank006(DataRow[] TransData, string date_t, string BranchCode, string compaccount, string compname, string Folder, string FileName)
        {
            //套用合作金庫轉帳格式
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var TList = new List<Dictionary<string, string>>();

            foreach (DataRow Row5 in TransData)
            {
                if (Row5["account_no"].ToString().Trim().Length != 13) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  合庫帳號不足或多14碼");
                if (Row5["idno"].ToString().Trim().Length != 10) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  身份證號或統一證號,不足或多10碼");
                Dictionary<string, string> bodydt = new Dictionary<string, string>()
                {
                     {Sal.SettingNameBody.Date,date_t},
                     {Sal.SettingNameBody.BranchCode,BranchCode},
                     {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                     {Sal.SettingNameBody.IDNO, Row5["idno"].ToString().Trim()},
                     {Sal.SettingNameBody.Amt,Row5["tt"].ToString()},
                     {Sal.SettingNameBody.CompName,compname},
                     {Sal.SettingNameBody.CompAccount,compaccount}

                };
                TList.Add(bodydt);
            }
            OUPT.AddData("006", "Body", TList);
            OUPT.ExportTxt(Folder, FileName);
            string dd = string.Empty;
        }

        public static void Bank008(DataRow[] TransData, string date_t, string BranchCode, string compaccount, string compname, string CompID, string Folder, string FileName)
        {
            //套用華南銀行格式
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var TList = new List<Dictionary<string, string>>();

            foreach (DataRow Row5 in TransData)
            {
                Dictionary<string, string> bodydt = new Dictionary<string, string>()
                {
                    {Sal.SettingNameBody.Date,date_t},
                    {Sal.SettingNameBody.BranchCode,BranchCode},
                    {Sal.SettingNameBody.CompAccount,compaccount},
                    {Sal.SettingNameBody.TaxID,CompID},
                    {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                    {Sal.SettingNameBody.IDNO, Row5["idno"].ToString().Trim()},
                    {Sal.SettingNameBody.Amt,Row5["tt"].ToString()}
                };
                TList.Add(bodydt);
            }
            OUPT.AddData("008", "Body", TList);
            OUPT.ExportTxt(Folder, FileName);
            string dd = string.Empty;
        }

        public static void Bank009(DataRow[] TransData, string date_t, string CompAccount, string BranchCode, string CompID, string totalamt, string totalcnt, string meno, string Folder, string FileName)
        {
            //套用彰化銀行轉帳格式
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var HList = new List<Dictionary<string, string>>();
            //{Sal.SettingNameHeader.ComID1,Num},
            Dictionary<string, string> bodydt1 = new Dictionary<string, string>()
                {

                    {Sal.SettingNameHeader.TaxID,CompID},
                    {Sal.SettingNameHeader.CompAccount,CompAccount},
                    {Sal.SettingNameHeader.Memo,meno},
                    {Sal.SettingNameHeader.BranchCode,BranchCode},
                    {Sal.SettingNameHeader.Date,date_t}
                };
            HList.Add(bodydt1);
            OUPT.AddData("009", "Header", HList);

            string transmeno = "";
            var TList = new List<Dictionary<string, string>>();

            foreach (DataRow Row5 in TransData)
            {
                Dictionary<string, string> bodydt = new Dictionary<string, string>()
                {
                     {Sal.SettingNameBody.Date,date_t},
                     {Sal.SettingNameBody.BranchCode,BranchCode},
                     {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                     {Sal.SettingNameBody.IDNO, Row5["idno"].ToString().Trim()},
                     {Sal.SettingNameBody.Memo,meno},
                     {Sal.SettingNameBody.TransMemo1,transmeno},
                     {Sal.SettingNameBody.DataUse,Row5["name_c"].ToString()},
                     {Sal.SettingNameBody.Amt,Row5["tt"].ToString()}

                };
                TList.Add(bodydt);
            }
            OUPT.AddData("009", "Body", TList);

            var FList = new List<Dictionary<string, string>>();
            Dictionary<string, string> footerdt1 = new Dictionary<string, string>()
            {
                {Sal.SettingNameFooter.BranchCode,BranchCode},
                {Sal.SettingNameFooter.Memo,meno},
                {Sal.SettingNameFooter.Date,date_t},
                {Sal.SettingNameFooter.CompAmt,totalamt},
                {Sal.SettingNameFooter.TotalRecord,totalcnt}

            };
            FList.Add(footerdt1);
            OUPT.AddData("009", "Footer", FList);
            OUPT.ExportTxt(Folder, FileName);
            string dd = string.Empty;
        }

        public static void Bank017(DataRow[] TransData, string date_t, string BranchCode, string CompID, string Num, string totalamt, string totalcnt, string Folder, string FileName)
        {
            //套用 兆豐商銀 轉帳格式
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var HList = new List<Dictionary<string, string>>();

            Dictionary<string, string> bodydt1 = new Dictionary<string, string>()
                {
                    {Sal.SettingNameHeader.BranchCode,BranchCode},
                    {Sal.SettingNameHeader.Date,date_t}
                };
            HList.Add(bodydt1);
            OUPT.AddData("017", "Header", HList);

            var TList = new List<Dictionary<string, string>>();
            foreach (DataRow Row5 in TransData)
            {
                if (Row5["account_no"].ToString().Trim().Length < 11 || Row5["account_no"].ToString().Trim().Length > 14) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  兆豐商銀帳號不足或多11碼");
                Dictionary<string, string> bodydt = new Dictionary<string, string>()
                {
                    {Sal.SettingNameBody.BranchCode,BranchCode},
                    {Sal.SettingNameBody.Date,date_t},
                    {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                    {Sal.SettingNameBody.Amt,Row5["tt"].ToString()},
                    {Sal.SettingNameBody.IDNO,Row5["idno"].ToString()},
                    {Sal.SettingNameBody.TaxID,CompID}
                };
                TList.Add(bodydt);
            }
            OUPT.AddData("017", "Body", TList);

            var FList = new List<Dictionary<string, string>>();
            Dictionary<string, string> footerdt1 = new Dictionary<string, string>()
            {
                {Sal.SettingNameFooter.BranchCode,BranchCode},
                {Sal.SettingNameFooter.Date,date_t},
                {Sal.SettingNameFooter.CompAmt,totalamt},
                {Sal.SettingNameFooter.TotalRecord,totalcnt}

            };
            FList.Add(footerdt1);
            OUPT.AddData("017", "Footer", FList);
            OUPT.ExportTxt(Folder, FileName);

        }

        public static void Bank700(DataRow[] TransData, string date_t, string BranchCode, string compaccount, string compname, string Folder, string FileName)
        {
            //套用郵局轉帳格式
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var TList = new List<Dictionary<string, string>>();

            foreach (DataRow Row5 in TransData)
            {
                if (Row5["account_no"].ToString().Trim().Length < 13 || Row5["account_no"].ToString().Trim().Length > 14) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + " 渣打國際帳號不足或多14碼");
                if (Row5["idno"].ToString().Trim().Length != 10) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  身份證號或統一證號,不足或多10碼");
                Dictionary<string, string> bodydt = new Dictionary<string, string>()
                {
                     {Sal.SettingNameBody.Date,date_t},
                     {Sal.SettingNameBody.BranchCode,BranchCode},
                     {Sal.SettingNameBody.CompAccount,compaccount},
                     {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                     {Sal.SettingNameBody.IDNO, Row5["idno"].ToString().Trim()},
                     {Sal.SettingNameBody.Amt,Row5["tt"].ToString()}

                };
                TList.Add(bodydt);
            }
            OUPT.AddData("700", "Body", TList);
            OUPT.ExportTxt(Folder, FileName);
            string dd = string.Empty;
        }

        public static void Bank083(DataRow[] TransData, string date_t, string BranchCode, string compaccount, string CompID, string totalamt, string totalcnt, string Folder, string FileName)
        {
            //套用渣打國際轉帳格式
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var HList = new List<Dictionary<string, string>>();

            Dictionary<string, string> bodydt1 = new Dictionary<string, string>()
                {
                    {Sal.SettingNameHeader.CompAccount,compaccount},
                    {Sal.SettingNameHeader.CompAmt,totalamt},
                    {Sal.SettingNameHeader.TaxID,CompID},
                    {Sal.SettingNameHeader.Date,date_t}
                };
            HList.Add(bodydt1);
            OUPT.AddData("083", "Header", HList);

            var TList = new List<Dictionary<string, string>>();
            int cnt = 1;
            foreach (DataRow Row5 in TransData)
            {
                //if (Row5["account_no"].ToString().Trim().Length < 13 || Row5["account_no"].ToString().Trim().Length > 14) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + " 郵局帳號不足或多14碼");
                if (Row5["idno"].ToString().Trim().Length != 10) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  身份證號或統一證號,不足或多10碼");
                int _lenacc = Row5["account_no"].ToString().Length - 5;
                cnt += 1;
                Dictionary<string, string> bodydt = new Dictionary<string, string>()
                {
                    {Sal.SettingNameBody.DataUse,cnt.ToString()},
                     {Sal.SettingNameBody.Date,date_t},
                     {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                     {Sal.SettingNameBody.IDNO, Row5["idno"].ToString().Trim()},
                     {Sal.SettingNameBody.Amt,Row5["tt"].ToString()}

                };
                TList.Add(bodydt);
            }
            OUPT.AddData("083", "Body", TList);

            var FList = new List<Dictionary<string, string>>();
            Dictionary<string, string> footerdt1 = new Dictionary<string, string>()
            {

                {Sal.SettingNameFooter.Date,date_t},
                {Sal.SettingNameFooter.Memo,"1"},
                {Sal.SettingNameFooter.FunctionCode,"DR"},
                {Sal.SettingNameFooter.TotalRecord,totalamt}

            };
            FList.Add(footerdt1);
            Dictionary<string, string> footerdt2 = new Dictionary<string, string>()
            {

                {Sal.SettingNameFooter.Date,date_t},
                {Sal.SettingNameFooter.Memo,totalcnt},
                {Sal.SettingNameFooter.FunctionCode,"CR"},
                {Sal.SettingNameFooter.TotalRecord,totalamt}

            };
            FList.Add(footerdt2);
            OUPT.AddData("083", "Footer", FList);

            OUPT.ExportTxt(Folder, FileName);
            string dd = string.Empty;
        }

        public static void Bank812(DataRow[] TransData, string date_t, string compaccount, string CompID, string Num, string totalamt, string totalcnt, string Folder, string FileName)
        {

            //套用台新銀行轉帳格式
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var HList = new List<Dictionary<string, string>>();

            totalamt = (long.Parse(totalamt) * 100).ToString();


            Dictionary<string, string> bodydt1 = new Dictionary<string, string>()
                {
                    {Sal.SettingNameHeader.ComID1,Num},
                    {Sal.SettingNameHeader.CompAccount,compaccount},
                    {Sal.SettingNameHeader.ExportDate,date_t},
                    {Sal.SettingNameHeader.Kind,"900"},
                    {Sal.SettingNameHeader.TaxID,CompID},
                    {Sal.SettingNameHeader.CompAmt,totalamt},
                    {Sal.SettingNameHeader.TotalRecord,totalcnt}
                };
            HList.Add(bodydt1);
            OUPT.AddData("812", "Header", HList);

            var TList = new List<Dictionary<string, string>>();
            foreach (DataRow Row5 in TransData)
            {
                if (Row5["account_no"].ToString().Trim().Length < 13 || Row5["account_no"].ToString().Trim().Length > 14) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + " 台新銀行帳號不足或多14碼");
                if (Row5["idno"].ToString().Trim().Length != 10) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  身份證號或統一證號,不足或多10碼");
                Dictionary<string, string> bodydt = new Dictionary<string, string>()
                {
                    {Sal.SettingNameBody.ComID1,Num},
                    {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                    {Sal.SettingNameBody.IDNO,Row5["idno"].ToString()},
                    {Sal.SettingNameBody.Amt,(long.Parse(Row5["tt"].ToString()) * 100).ToString()},
                    {Sal.SettingNameBody.FunctionCode,"900"}
                };
                TList.Add(bodydt);
            }
            OUPT.AddData("812", "Body", TList);
            OUPT.ExportTxt(Folder, FileName);

        }
        public static void Bank822(DataRow[] TransData, string date_t, string compaccount, string Folder, string FileName)
        {
            //套用中國信託銀行轉帳格式
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var HList = new List<Dictionary<string, string>>();

            Dictionary<string, string> bodydt1 = new Dictionary<string, string>()
                {
                    {Sal.SettingNameHeader.CompAccount,compaccount},
                    {Sal.SettingNameHeader.Date,date_t}
                };
            HList.Add(bodydt1);
            OUPT.AddData("822", "Header", HList);

            var TList = new List<Dictionary<string, string>>();
            foreach (DataRow Row5 in TransData)
            {
                if (Row5["idno"].ToString().Trim().Length != 10) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  身份證號或統一證號,不足或多10碼");
                Dictionary<string, string> bodydt = new Dictionary<string, string>()
                {
                    {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                    {Sal.SettingNameBody.IDNO,Row5["idno"].ToString()},
                    {Sal.SettingNameBody.Amt,Row5["tt"].ToString()}
                };
                TList.Add(bodydt);
            }
            OUPT.AddData("822", "Body", TList);
            OUPT.ExportTxt(Folder, FileName);

        }
        //public static void Bank812(DataRow[] TransData, string date_t, string compaccount, string Folder, string FileName)
        //{
        //    //套用中國信託銀行轉帳格式
        //    Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
        //    var HList = new List<Dictionary<string, string>>();

        //    Dictionary<string, string> bodydt1 = new Dictionary<string, string>()
        //        {
        //            {Sal.SettingNameHeader.CompAccount,compaccount},
        //            {Sal.SettingNameHeader.Date,date_t}
        //        };
        //    HList.Add(bodydt1);
        //    OUPT.AddData("812", "Header", HList);

        //    var TList = new List<Dictionary<string, string>>();
        //    foreach (DataRow Row5 in TransData)
        //    {
        //        if (Row5["idno"].ToString().Trim().Length != 10) throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + "  身份證號或統一證號,不足或多10碼");
        //        Dictionary<string, string> bodydt = new Dictionary<string, string>()
        //        {
        //            {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
        //            {Sal.SettingNameBody.IDNO,Row5["idno"].ToString()},
        //            {Sal.SettingNameBody.Amt,Row5["tt"].ToString()}
        //        };
        //        TList.Add(bodydt);
        //    }
        //    OUPT.AddData("812", "Body", TList);
        //    OUPT.ExportTxt(Folder, FileName);

        //}


        public static void Get_Bank(string bankno, DataRow[] TransData, string date_t, string compaccount, string compname, string CompID, string Folder, string FileName, DataTable Sal_Transfer_Bank, string totalamt, string totalcnt)
        {
            Sal.FormatStringOutput OUPT = new Sal.FormatStringOutput();
            var TList = new List<Dictionary<string, string>>();

            object[] value = new object[2];
            value[0] = CompID;
            value[1] = bankno;

            DataRow sal_transfer_row = Sal_Transfer_Bank.Rows.Find(value);

            if (sal_transfer_row != null)
            {
                string date_str = date_t;

                // yymmdd
                if(sal_transfer_row["COMP_DATE_TYPE"].ToString().Trim() == "1")
                {
                    date_str = Convert.ToString(DateTime.Parse(date_t).Year - 1911) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
                }
                // yyyymmdd
                else if (sal_transfer_row["COMP_DATE_TYPE"].ToString().Trim() == "2")
                {
                    date_str = Convert.ToString(DateTime.Parse(date_t).Year) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
                }
                // 民國
                else if (sal_transfer_row["COMP_DATE_TYPE"].ToString().Trim() == "3")
                {
                    date_str = Convert.ToString(DateTime.Parse(date_t).Year - 1911).Substring(Convert.ToString(DateTime.Parse(date_t).Year - 1911).Length - 2, 2) + Convert.ToString(DateTime.Parse(date_t).Month).PadLeft(2, '0') + Convert.ToString(DateTime.Parse(date_t).Day).PadLeft(2, '0');
                }
                // 原本
                else
                {
                    date_str = date_t;
                }


                //是否有 Header 部分
                if (bool.Parse(sal_transfer_row["COMP_HAS_HEADER"].ToString()))
                {
                    var HList = new List<Dictionary<string, string>>();
                    //{Sal.SettingNameHeader.ComID1,Num},
                    Dictionary<string, string> headerdt = new Dictionary<string, string>()
                    {
                        //企業編號
                        {Sal.SettingNameHeader.ComID1, CompID},
                        //分行代碼
                        {Sal.SettingNameHeader.BranchCode, sal_transfer_row["COMPANY_BRANCH_CODE"].ToString().Trim()},
                        //日期
                        {Sal.SettingNameHeader.Date, date_str},
                        //存提代號
                        {Sal.SettingNameHeader.FunctionCode, ""},
                        //摘要
                        {Sal.SettingNameHeader.Memo, ""},
                        //磁片來源
                        {Sal.SettingNameHeader.Source, ""},
                        //性質別
                        {Sal.SettingNameHeader.Kind, ""},
                        //企業統一編號
                        {Sal.SettingNameHeader.TaxID, CompID},
                        //企業銀行帳號
                        {Sal.SettingNameHeader.CompAccount, compaccount},
                        //匯出日期
                        {Sal.SettingNameHeader.ExportDate, DateTime.Now.ToString("yyyy/MM/dd")},
                        //總金額
                        {Sal.SettingNameHeader.CompAmt, totalamt},
                        //總筆數
                        {Sal.SettingNameHeader.TotalRecord, totalcnt}
                    };
                    HList.Add(headerdt);
                    OUPT.AddData(bankno, "Header", HList);
                }

                foreach (DataRow Row5 in TransData)
                {
                    if (Row5["account_no"].ToString().Trim().Length != int.Parse(sal_transfer_row["COMPANY_BANK_LENGTH"].ToString().Trim())) 
                        throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + " " + sal_transfer_row["COMPANY_BANK_NAME"].ToString().Trim() + "帳號不足或多於"+ sal_transfer_row["COMPANY_BANK_LENGTH"].ToString().Trim() + "碼");
                    if (Row5["idno"].ToString().Trim().Length != 10) 
                        throw new Exception("工號:" + Row5["nobr"].ToString() + " " + Row5["name_c"].ToString() + " 身份證號或統一證號,不足或多10碼");
                    
                    Dictionary<string, string> bodydt = new Dictionary<string, string>()
                    {
                        //企業編號
                        {Sal.SettingNameBody.ComID1,CompID},
                        //分行代碼
                        {Sal.SettingNameBody.BranchCode, sal_transfer_row["COMPANY_BRANCH_CODE"].ToString().Trim()},
                        //日期
                        {Sal.SettingNameBody.Date,date_str},
                        //存提代號
                        {Sal.SettingNameBody.FunctionCode,""},
                        //摘要
                        {Sal.SettingNameBody.Memo,""},
                        //員工銀行帳號
                        {Sal.SettingNameBody.Account,Row5["account_no"].ToString()},
                        //企業銀行帳號
                        {Sal.SettingNameBody.CompAccount,compaccount},
                        //總金額
                        {Sal.SettingNameBody.CompAmt, totalamt},
                        //金額
                        {Sal.SettingNameBody.Amt,Row5["tt"].ToString()},
                        //狀況代號
                        {Sal.SettingNameBody.Addition,""},
                        //身份證字號
                        {Sal.SettingNameBody.IDNO, Row5["idno"].ToString().Trim()},
                        //專用資料區
                        {Sal.SettingNameBody.DataUse,""},
                        //幣別
                        {Sal.SettingNameBody.MoneyType,""},
                        //交易註記（1）
                        {Sal.SettingNameBody.TransMemo1,""},
                        //交易註記（2）
                        {Sal.SettingNameBody.TransMemo2,""},
                        //身份證檢核記號
                        {Sal.SettingNameBody.IDNOCheck,""},
                        //企業統一編號
                        {Sal.SettingNameBody.TaxID,CompID},
                        //公司名稱
                        {Sal.SettingNameBody.CompName,""},
                        //員工分行代號
                        {Sal.SettingNameBody.BranchCode1,""}
                    };
                    TList.Add(bodydt);
                }
                OUPT.AddData(bankno, "Body", TList);

                //是否有 Footer 部分
                if (bool.Parse(sal_transfer_row["COMP_HAS_FOOTER"].ToString()))
                {
                    var FList = new List<Dictionary<string, string>>();
                    Dictionary<string, string> footerdt = new Dictionary<string, string>()
                    {
                        //企業編號
                        {Sal.SettingNameFooter.ComID1, CompID},
                        //分行代碼
                        {Sal.SettingNameFooter.BranchCode, sal_transfer_row["COMPANY_BRANCH_CODE"].ToString().Trim()},
                        //日期
                        {Sal.SettingNameFooter.Date, date_str},
                        //存提代號
                        {Sal.SettingNameFooter.FunctionCode, ""},
                        //摘要
                        {Sal.SettingNameFooter.Memo, ""},
                        //總金額
                        {Sal.SettingNameFooter.CompAmt, totalamt},
                        //總筆數
                        {Sal.SettingNameFooter.TotalRecord, totalcnt},
                        //未成交總金額
                        {Sal.SettingNameFooter.NotDealTotalAmt, ""},
                        //未成交總筆數
                        {Sal.SettingNameFooter.NotDealTotalRecord, ""}

                    };
                    FList.Add(footerdt);
                    OUPT.AddData(bankno, "Footer", FList);
                }

                //匯出
                OUPT.ExportTxt(Folder, FileName);
            }

            string dd = string.Empty;
        }

    }
}
