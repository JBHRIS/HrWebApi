using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace JBHR.Reports.SalForm
{
    class ZZ4JClass
    {
        public static void Get_ZZ4J(DataTable DT_ZZ4J, DataTable DT_waged, DataTable DT_wage, DataTable DT_salcode, DataTable DT_day, DataTable DT_base,string date_b)
        {
            DataTable rq_wageda = new DataTable();
            rq_wageda.Columns.Add("nobr", typeof(string));
            rq_wageda.Columns.Add("name_c", typeof(string));
            rq_wageda.Columns.Add("name_e", typeof(string));
            rq_wageda.Columns.Add("job", typeof(string));
            rq_wageda.Columns.Add("job_name", typeof(string));
            rq_wageda.Columns.Add("indt", typeof(DateTime));
            rq_wageda.Columns.Add("dept", typeof(string));
            rq_wageda.Columns.Add("d_name", typeof(string));
            rq_wageda.Columns.Add("d_ename", typeof(string));
            rq_wageda.Columns.Add("yymm", typeof(string));
            rq_wageda.Columns.Add("amt", typeof(int));
            rq_wageda.Columns.Add("i_year", typeof(decimal));
            //rq_wageda.Columns.Add("y_year", typeof(decimal));            
            //rq_wageda.Columns.Add("i_base", typeof(decimal));
            rq_wageda.PrimaryKey = new DataColumn[] { rq_wageda.Columns["nobr"], rq_wageda.Columns["yymm"] };
            foreach (DataRow Row in DT_waged.Rows)
            {
                DataRow row = DT_base.Rows.Find(Row["nobr"].ToString());
                object[] _value = new object[3];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["yymm"].ToString();
                _value[2] = Row["seq"].ToString();
                DataRow row1 = DT_wage.Rows.Find(_value);
                DataRow row2 = DT_salcode.Rows.Find(Row["sal_code"].ToString());
                if (row != null && row1 != null && row2 != null)
                {
                    string _indt = "";
                    DataRow row3 = DT_day.Rows.Find(Row["nobr"].ToString());
                    if (row2 != null)
                        Row["flag"] = row2["flag"].ToString();
                    if (row3 != null)
                        _indt = DateTime.Parse(row["indt"].ToString()).AddDays(int.Parse(row3["day"].ToString())).ToString("yyyy/MM/dd");
                    else
                        _indt = DateTime.Parse(row["indt"].ToString()).ToString("yyyy/MM/dd");

                    if (Row["flag"].ToString().Trim() == "-")
                        Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                    else
                        Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                    //decimal _inyear = decimal.Round((((TimeSpan)(DateTime.Parse(date_b) - DateTime.Parse(_indt))).Days) / Convert.ToDecimal(365.24), 2);
                    //if (_inyear >= inyear)
                    //{
                        
                    //}
                    object[] _value1 = new object[2];
                    _value1[0] = Row["nobr"].ToString();
                    _value1[1] = Row["yymm"].ToString();
                    DataRow row4 = rq_wageda.Rows.Find(_value1);
                    if (row4 != null)
                        row4["amt"] = int.Parse(row4["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    else
                    {
                        DataRow aRow = rq_wageda.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["job"] = row["job"].ToString();
                        aRow["job_name"] = row["job_name"].ToString();
                        aRow["indt"] = DateTime.Parse(row["indt"].ToString());
                        //decimal _yyear = ((TimeSpan)(DateTime.Parse(date_b) - DateTime.Parse(row["birdt"].ToString()))).Days;
                        decimal _iyear = ((TimeSpan)((DateTime.Parse(date_b) - DateTime.Parse(_indt)))).Days;
                        aRow["i_year"] = decimal.Round(_iyear / Convert.ToDecimal(365.24), 2);
                        //aRow["y_year"] = decimal.Round(_yyear / Convert.ToDecimal(365.24), 2);                           
                        //if (decimal.Parse(aRow["i_year"].ToString()) <= 15)
                        //    aRow["i_base"] = (decimal.Ceiling(decimal.Parse(aRow["i_year"].ToString()) / Convert.ToDecimal(0.5)) / 2) * 2;
                        //else
                        //    aRow["i_base"] = ((decimal.Ceiling((decimal.Parse(aRow["i_year"].ToString()) - 15) / Convert.ToDecimal(0.5)) / 2) * 1) + 30;
                        aRow["yymm"] = Row["yymm"].ToString();
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        rq_wageda.Rows.Add(aRow);
                    }
                }
            }

            DT_ZZ4J.PrimaryKey = new DataColumn[] { DT_ZZ4J.Columns["nobr"] };
            DataRow[] SRow = rq_wageda.Select("", "dept,nobr,yymm asc");
            foreach (DataRow Row in SRow)
            {
                DataRow row = DT_ZZ4J.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    for (int i = 2; i < 7; i++)
                    {
                        if (row["yymm" + i].ToString().Trim()=="")
                        {
                            row["yymm" + i] = Row["yymm"].ToString();
                            row["amt" + i] = int.Parse(Row["amt"].ToString());
                            row["sumamt"] = int.Parse(row["sumamt"].ToString()) + int.Parse(Row["amt"].ToString());
                            row["summon"] = int.Parse(row["summon"].ToString()) + 1;
                            //row["avgamt"] = Math.Round(decimal.Parse(row["sumamt"].ToString()) / decimal.Parse(row["summon"].ToString()), MidpointRounding.AwayFromZero);
                            row["avgamt"] = (Int32)(decimal.Parse(row["sumamt"].ToString()) / decimal.Parse(row["summon"].ToString()));
                            break;
                            //row["retamt"] = Math.Round(decimal.Parse(row["avgamt"].ToString()) * decimal.Parse(row["i_base"].ToString()), MidpointRounding.AwayFromZero);
                        }
                        
                    }

                }
                else
                {
                    DataRow aRow = DT_ZZ4J.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["d_ename"] = Row["d_ename"].ToString();
                    aRow["job"] = Row["job"].ToString();
                    aRow["job_name"] = Row["job_name"].ToString();
                    aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                    aRow["i_year"] = decimal.Parse(Row["i_year"].ToString());
                    //aRow["y_year"] = decimal.Parse(Row["y_year"].ToString());                    
                    //aRow["i_base"] = decimal.Parse(Row["i_base"].ToString());
                    aRow["yymm1"] = Row["yymm"].ToString();
                    aRow["amt1"] = int.Parse(Row["amt"].ToString());
                    aRow["summon"] = 1;
                    aRow["sumamt"] = int.Parse(Row["amt"].ToString());
                    aRow["avgamt"] = int.Parse(Row["amt"].ToString());
                    //aRow["retamt"] = Math.Round(decimal.Parse(aRow["avgamt"].ToString()) * decimal.Parse(aRow["i_base"].ToString()), MidpointRounding.AwayFromZero);
                    DT_ZZ4J.Rows.Add(aRow);
                }
            }
            rq_wageda = null;
        }

        public static void Get_ZZ4J1(DataTable DT_ZZ4J1, DataTable DT_waged, DataTable DT_wage, DataTable DT_salcode, DataTable DT_day, DataTable DT_base, string date_b)
        {
            DataTable rq_wageda = new DataTable();
            rq_wageda.Columns.Add("nobr", typeof(string));
            rq_wageda.Columns.Add("name_c", typeof(string));
            rq_wageda.Columns.Add("name_e", typeof(string));
            rq_wageda.Columns.Add("job", typeof(string));
            rq_wageda.Columns.Add("job_name", typeof(string));           
            rq_wageda.Columns.Add("yymm", typeof(string));
            rq_wageda.Columns.Add("amt", typeof(int));
            rq_wageda.Columns.Add("i_year", typeof(decimal));
            rq_wageda.Columns.Add("y_year", typeof(decimal));           
            rq_wageda.PrimaryKey = new DataColumn[] { rq_wageda.Columns["nobr"], rq_wageda.Columns["yymm"] };
            foreach (DataRow Row in DT_waged.Rows)
            {
                DataRow row = DT_base.Rows.Find(Row["nobr"].ToString());
                object[] _value = new object[3];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["yymm"].ToString();
                _value[2] = Row["seq"].ToString();
                DataRow row1 = DT_wage.Rows.Find(_value);
                DataRow row2 = DT_salcode.Rows.Find(Row["sal_code"].ToString());
                if (row != null && row1 != null && row2 != null)
                {
                    string _indt = "";
                    DataRow row3 = DT_day.Rows.Find(Row["nobr"].ToString());
                    if (row2 != null)
                        Row["flag"] = row2["flag"].ToString();
                    if (row3 != null)
                        _indt = DateTime.Parse(row["indt"].ToString()).AddDays(int.Parse(row3["day"].ToString())).ToString("yyyy/MM/dd");
                    else
                        _indt = DateTime.Parse(row["indt"].ToString()).ToString("yyyy/MM/dd");

                    if (Row["flag"].ToString().Trim() == "-")
                        Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                    else
                        Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                   
                    object[] _value1 = new object[2];
                    _value1[0] = Row["nobr"].ToString();
                    _value1[1] = Row["yymm"].ToString();
                    DataRow row4 = rq_wageda.Rows.Find(_value1);
                    if (row4 != null)
                        row4["amt"] = int.Parse(row4["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    else
                    {
                        DataRow aRow = rq_wageda.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["job"] = row["job"].ToString();
                        aRow["job_name"] = row["job_name"].ToString();                       
                        decimal _yyear = ((TimeSpan)(DateTime.Parse(date_b) - DateTime.Parse(row["birdt"].ToString()))).Days;
                        decimal _iyear = ((TimeSpan)((DateTime.Parse(date_b) - DateTime.Parse(_indt)))).Days;
                        //aRow["i_year"] = decimal.Round(_iyear / Convert.ToDecimal(365.24), 2);
                        //aRow["y_year"] = decimal.Round(_yyear / Convert.ToDecimal(365.24), 2); 
                        aRow["i_year"] = _iyear / Convert.ToDecimal(365.24);
                        aRow["y_year"] = _yyear / Convert.ToDecimal(365.24); 
                        aRow["yymm"] = Row["yymm"].ToString();
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        rq_wageda.Rows.Add(aRow);
                    }
                }
            }


            DataTable rq_wagedb = new DataTable();
            rq_wagedb.Columns.Add("nobr", typeof(string));
            rq_wagedb.Columns.Add("name_c", typeof(string));
            rq_wagedb.Columns.Add("name_e", typeof(string));
            rq_wagedb.Columns.Add("job", typeof(string));
            rq_wagedb.Columns.Add("job_name", typeof(string));            
            rq_wagedb.Columns.Add("sumamt", typeof(int));
            rq_wagedb.Columns.Add("avgamt", typeof(int));
            rq_wagedb.Columns.Add("mon", typeof(int));
            rq_wagedb.Columns.Add("i_year", typeof(decimal));
            rq_wagedb.Columns.Add("y_year", typeof(decimal));
            rq_wagedb.PrimaryKey = new DataColumn[] { rq_wagedb.Columns["nobr"]};
            DataRow[] ORow = rq_wageda.Select("", "nobr,yymm asc");
            foreach (DataRow Row in ORow)
            {
                DataRow row = rq_wagedb.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    if (int.Parse(row["mon"].ToString()) < 6)
                    {
                        row["mon"] = int.Parse(row["mon"].ToString()) + 1;
                        row["sumamt"] = int.Parse(row["sumamt"].ToString()) + int.Parse(Row["amt"].ToString());
                        row["avgamt"] = (Int32)(decimal.Parse(row["sumamt"].ToString()) / decimal.Parse(row["mon"].ToString()));
                    }
                }
                else
                {

                    DataRow aRow = rq_wagedb.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["job"] = Row["job"].ToString();
                    aRow["job_name"] = Row["job_name"].ToString();
                    aRow["sumamt"] = int.Parse(Row["amt"].ToString());
                    aRow["avgamt"] = int.Parse(Row["amt"].ToString());
                    aRow["mon"] = 1;
                    aRow["i_year"] = decimal.Parse(Row["i_year"].ToString());
                    aRow["y_year"] = decimal.Parse(Row["y_year"].ToString()); 
                    rq_wagedb.Rows.Add(aRow);
                }
            }
            //JBModule.Data.CExcel.GenerateHtml("C:\\TEMP\\RQ_WAGEDa.xls", rq_wageda, true);
            //System.Diagnostics.Process.Start("C:\\TEMP\\RQ_WAGEDa.xls");
            rq_wageda = null;
            
            DT_ZZ4J1.PrimaryKey = new DataColumn[] { DT_ZZ4J1.Columns["job"] };
            DataRow[] SRow = rq_wagedb.Select("", "job asc");
            foreach (DataRow Row in SRow)
            {
                DataRow row = DT_ZZ4J1.Rows.Find(Row["job"].ToString());
                if (row != null)
                {
                    if (int.Parse(Row["avgamt"].ToString()) > int.Parse(row["h_amt"].ToString()))
                        row["h_amt"] = int.Parse(Row["avgamt"].ToString());
                    if (int.Parse(Row["avgamt"].ToString()) < int.Parse(row["l_amt"].ToString()))
                        row["l_amt"] = int.Parse(Row["avgamt"].ToString());
                    row["sumamt"] = int.Parse(row["sumamt"].ToString()) + int.Parse(Row["avgamt"].ToString());
                    row["pno"] = int.Parse(row["pno"].ToString()) + 1;
                    row["i_year"] = decimal.Parse(row["i_year"].ToString()) + decimal.Parse(Row["i_year"].ToString());
                    row["y_year"] = decimal.Parse(row["y_year"].ToString()) + decimal.Parse(Row["y_year"].ToString());
                    row["avg_amt"] = (Int32)(decimal.Parse(row["sumamt"].ToString()) / decimal.Parse(row["pno"].ToString()));
                    row["avgiyear"] = decimal.Round(decimal.Parse(row["i_year"].ToString()) / decimal.Parse(row["pno"].ToString()), 2);
                    row["avgyyear"] = decimal.Round(decimal.Parse(row["y_year"].ToString()) / decimal.Parse(row["pno"].ToString()), 2);
                }
                else
                {
                    DataRow aRow = DT_ZZ4J1.NewRow();                    
                    aRow["job"] = Row["job"].ToString();
                    aRow["job_name"] = Row["job_name"].ToString();                   
                    aRow["i_year"] = decimal.Parse(Row["i_year"].ToString());
                    aRow["y_year"] = decimal.Parse(Row["y_year"].ToString()); 
                    aRow["sumamt"] = int.Parse(Row["avgamt"].ToString());
                    aRow["pno"] = 1;
                    aRow["avg_amt"] = int.Parse(Row["avgamt"].ToString());
                    aRow["h_amt"] = int.Parse(Row["avgamt"].ToString());
                    aRow["l_amt"] = int.Parse(Row["avgamt"].ToString());
                    aRow["avgiyear"] = decimal.Round(decimal.Parse(Row["i_year"].ToString()), 2);
                    aRow["avgyyear"] = decimal.Round(decimal.Parse(Row["y_year"].ToString()), 2); 
                    DT_ZZ4J1.Rows.Add(aRow);
                }
            }
            rq_wagedb = null;
        }

        public static void Get_ZZ4J2(DataTable DT_ZZ4J2, DataTable DT_waged, DataTable DT_wage, DataTable DT_salcode, DataTable DT_base, DataTable DT_salbasd)
        {
            DataTable rq_salbasda = new DataTable();
            rq_salbasda.Columns.Add("nobr", typeof(string));
            rq_salbasda.Columns.Add("amt", typeof(int));
            rq_salbasda.PrimaryKey = new DataColumn[] { rq_salbasda.Columns["nobr"] };

            foreach (DataRow Row in DT_salbasd.Rows)
            {
                DataRow row = DT_base.Rows.Find(Row["nobr"].ToString());
                DataRow row1 = DT_salcode.Rows.Find(Row["sal_code"].ToString());
                if (row != null && row1 != null)
                {
                    string _flag = "";
                    if (row1 != null)
                        _flag = row1["flag"].ToString();

                    if (_flag.Trim() == "-")
                        Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                    else
                        Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                    DataRow row2 = rq_salbasda.Rows.Find(Row["nobr"].ToString());
                    if (row2 != null)
                        row2["amt"] = int.Parse(row2["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                    else
                    {
                        DataRow aRow = rq_salbasda.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["amt"] = int.Parse(Row["amt"].ToString());
                        rq_salbasda.Rows.Add(aRow);
                    }

                }
            }

            DataTable rq_wageda = new DataTable();
            rq_wageda = DT_ZZ4J2.Clone();
            rq_wageda.TableName = "rq_wageda";
            rq_wageda.PrimaryKey = new DataColumn[] { rq_wageda.Columns["nobr"] };
            foreach (DataRow Row in DT_waged.Rows)
            {
                DataRow row = DT_base.Rows.Find(Row["nobr"].ToString());
                object[] _value = new object[3];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["yymm"].ToString();
                _value[2] = Row["seq"].ToString();
                DataRow row1 = DT_wage.Rows.Find(_value);
                DataRow row2 = DT_salcode.Rows.Find(Row["sal_code"].ToString());
                if (row != null && row1 != null && row2 != null)
                {                   
                    if (row2 != null)
                        Row["flag"] = row2["flag"].ToString();
                  
                    if (Row["flag"].ToString().Trim() == "-")
                        Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                    else
                        Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                    DataRow row3 = rq_wageda.Rows.Find(Row["nobr"].ToString());
                    if (row3 != null)
                    {
                        row3["yamt"] = int.Parse(row3["yamt"].ToString()) + int.Parse(Row["amt"].ToString());
                        if (Row["sal_code"].ToString().Trim() == "A01") row3["a01amt"] = int.Parse(Row["amt"].ToString());
                    }
                    else
                    {
                        DataRow aRow = rq_wageda.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["d_ename"] = row["d_ename"].ToString();
                        aRow["job"] = row["job"].ToString();
                        aRow["job_name"] = row["job_name"].ToString();
                        aRow["jobl"]=row["jobl"].ToString();
                        aRow["jobl_name"] = row["jobl_name"].ToString();
                        aRow["indt"] = DateTime.Parse(row["indt"].ToString());
                        aRow["birdt"] = DateTime.Parse(row["birdt"].ToString());
                        aRow["yamt"] = int.Parse(Row["amt"].ToString());
                        aRow["a01amt"] = (Row["sal_code"].ToString().Trim() == "A01") ? int.Parse(Row["amt"].ToString()) : 0;                        
                        DataRow row4 = rq_salbasda.Rows.Find(Row["nobr"].ToString());
                        aRow["mamt"] = (row4 != null) ? int.Parse(row4["amt"].ToString()) : 0;
                        rq_wageda.Rows.Add(aRow);
                    }
                    
                }
            }           

            DataRow[] SRow = rq_wageda.Select("", "dept,jobl desc");
            foreach (DataRow Row in SRow)
            {
                DT_ZZ4J2.ImportRow(Row);
            }
           
        }


        public static void ExPort1(DataTable DT, string FileName, int Count_Number, decimal Avg_Amt)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));            
            ExporDt.Columns.Add("年資", typeof(decimal));
            for (int i =1; i <7; i++)
            {
                ExporDt.Columns.Add("計算年月" + i, typeof(string));
                ExporDt.Columns.Add("薪資年月" + i, typeof(int));
            }
            ExporDt.Columns.Add("薪資總額", typeof(int));
            ExporDt.Columns.Add("平均薪資", typeof(int));            
            
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["職稱"] = Row01["job_name"].ToString();              
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["到職日期"] = DateTime.Parse(Row01["indt"].ToString());                
                aRow["年資"] = decimal.Parse(Row01["i_year"].ToString());
                for (int i = 1; i < 7; i++)
                {
                    if (Row01["yymm"+(i)].ToString().Trim() != "")
                    {
                        aRow["計算年月" + i] = (Row01.IsNull("yymm" + i)) ? "" : Row01["yymm" + i].ToString();
                        aRow["薪資年月" + i] = (Row01.IsNull("amt" + i)) ? 0 : int.Parse(Row01["amt" + i].ToString());                         
                    }                   
                       
                }
                aRow["薪資總額"] = int.Parse(Row01["sumamt"].ToString());
                aRow["平均薪資"] = int.Parse(Row01["avgamt"].ToString());                
                
                ExporDt.Rows.Add(aRow);
            }

            DataRow Row_Avg = ExporDt.NewRow();
            //aRow["部門代碼"] = "";
            //aRow["部門名稱"] = "";
            //aRow["英文部門名稱"] = "";
            //aRow["職稱"] = "";
            Row_Avg["員工編號"] = "總人數";
            Row_Avg["員工姓名"] = Count_Number;
            //aRow["英文姓名"] = "";
            //aRow["到職日期"] = DateTime.Parse(Row01["indt"].ToString());
            //aRow["年資"] = decimal.Parse(Row01["i_year"].ToString());

            //Row_Avg["薪資總額"] = "總平均薪資";
            Row_Avg["平均薪資"] = Avg_Amt;

            ExporDt.Rows.Add(Row_Avg);

            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort2(DataTable DT, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("職稱代碼", typeof(string));            
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("人數", typeof(int));
            ExporDt.Columns.Add("平均年資", typeof(decimal));
            ExporDt.Columns.Add("平均年齡", typeof(decimal));
            ExporDt.Columns.Add("平均薪資", typeof(decimal));
            ExporDt.Columns.Add("最小平均薪資", typeof(int));
            ExporDt.Columns.Add("最大平均薪資", typeof(int));           
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["職稱代碼"] = Row01["job"].ToString();
                aRow["職稱"] = Row01["job_name"].ToString();
                aRow["人數"] = int.Parse(Row01["pno"].ToString());
                aRow["平均年資"] = decimal.Parse(Row01["avgiyear"].ToString());
                aRow["平均年齡"] = decimal.Parse(Row01["avgyyear"].ToString());
                aRow["平均薪資"] = int.Parse(Row01["avg_amt"].ToString());
                aRow["最小平均薪資"] = int.Parse(Row01["l_amt"].ToString());
                aRow["最大平均薪資"] = int.Parse(Row01["h_amt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort3(DataTable DT, string FileName, int Count_Number, decimal Avg_Amt, decimal Avg_Amt_B)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("出生日期", typeof(DateTime));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("職等名稱", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("年薪", typeof(int));          
            ExporDt.Columns.Add("月薪", typeof(int));
            ExporDt.Columns.Add("月本俸", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["出生日期"] = DateTime.Parse(Row01["birdt"].ToString());
                aRow["到職日期"] = DateTime.Parse(Row01["indt"].ToString());
                aRow["職等名稱"] = Row01["jobl_name"].ToString();
                aRow["職稱"] = Row01["job_name"].ToString();
                aRow["年薪"] = int.Parse(Row01["yamt"].ToString());
                aRow["月薪"] = int.Parse(Row01["mamt"].ToString());
                aRow["月本俸"] = int.Parse(Row01["a01amt"].ToString());
                ExporDt.Rows.Add(aRow);
            }

            DataRow Row_Avg = ExporDt.NewRow();

            Row_Avg["員工編號"] = "總人數";
            Row_Avg["員工姓名"] = Count_Number;

            Row_Avg["職稱"] = "總平均";
            Row_Avg["月薪"] = Avg_Amt;
            Row_Avg["月本俸"] = Avg_Amt_B;
            ExporDt.Rows.Add(Row_Avg);

            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

    }
}
