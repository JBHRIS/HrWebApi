/* ======================================================================================================
 * 功能名稱：各期薪資表
 * 功能代號：ZZ46
 * 功能路徑：報表列印 > 薪資 > 各期薪資表
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ46Class.cs
 * 功能用途：
 *  用於產出勞健團保費用分攤資料
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/03/18    Daniel Chih    Ver 1.0.01     1. 修改僱主負擔金額的條件：只塞在第二期資料
 * 2021/07/26    Daniel Chih    Ver 1.0.02     1. 增加部門月份匯總表的excel格式
 * 2021/08/05    Daniel Chih    Ver 1.0.03     1. 修正中位數篩選條件不能正確判斷的錯誤
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/08/05
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBHR.Reports.SalForm
{
    class ZZ46Class
    {
        public static void GetWageds1(DataTable DT_wageds1, DataTable DT_waged)
        {
            DataColumn [] _key = new DataColumn[3];
            _key[0] = DT_wageds1.Columns["nobr"];
            _key[1] = DT_wageds1.Columns["yymm"];
            _key[2] = DT_wageds1.Columns["seq"];
            DT_wageds1.PrimaryKey = _key;
            DataRow[] Srow = DT_waged.Select("salattr<='F'");
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[3];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["yymm"].ToString();
                _value[2] = Row["seq"].ToString();
                DataRow row = DT_wageds1.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["yymm"] = Row["yymm"].ToString();
                    aRow["seq"] = Row["seq"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wageds1.Rows.Add(aRow);
                }
            }
        }

        public static void GetWageds2(DataTable DT_wageds2, DataTable DT_waged, string retsalcode)
        {
            DataColumn [] _key = new DataColumn[3];
            _key[0] = DT_wageds2.Columns["nobr"];
            _key[1] = DT_wageds2.Columns["yymm"];
            _key[2] = DT_wageds2.Columns["seq"];
            DT_wageds2.PrimaryKey = _key;
            DataRow[] Srow = DT_waged.Select("salattr<='L' and sal_code<> '"+retsalcode+"'");
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[3];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["yymm"].ToString();
                _value[2] = Row["seq"].ToString();
                DataRow row = DT_wageds2.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wageds2.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["yymm"] = Row["yymm"].ToString();
                    aRow["seq"] = Row["seq"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wageds2.Rows.Add(aRow);
                }
            }
        }

        public static void GetWagedsz(DataTable DT_wagedsz, DataTable DT_waged)
        {
            DataColumn [] _key = new DataColumn[3];
            _key[0] = DT_wagedsz.Columns["nobr"];
            _key[1] = DT_wagedsz.Columns["yymm"];
            _key[2] = DT_wagedsz.Columns["seq"];
            DT_wagedsz.PrimaryKey = _key;           
            foreach (DataRow Row in DT_waged.Rows)
            {
                object[] _value = new object[3];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["yymm"].ToString();
                _value[2] = Row["seq"].ToString();
                DataRow row = DT_wagedsz.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wagedsz.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["yymm"] = Row["yymm"].ToString();
                    aRow["seq"] = Row["seq"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wagedsz.Rows.Add(aRow);
                }
            }
        }

        public static void GetZz46t(DataTable DT_zz46t, DataTable DT_waged,DataTable DT_zz46ta)
        {            
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_salcode = Row["salattr"].ToString() + Row["sal_code"].ToString();
                DataRow row = DT_zz46t.Rows.Find(str_salcode);
                if (row == null)                  
                {
                    DataRow aRow = DT_zz46t.NewRow();
                    aRow["sal_code"] = str_salcode;
                    aRow["sal_name"] = Row["sal_name"].ToString();                  
                    DT_zz46t.Rows.Add(aRow);
                }
            }

            DataRow aRow1 = DT_zz46t.NewRow();
            aRow1["sal_code"] = "F";
            aRow1["sal_name"] = "應稅薪資";
            DT_zz46t.Rows.Add(aRow1);

            DataRow aRow2 = DT_zz46t.NewRow();
            aRow2["sal_code"] = "L";
            aRow2["sal_name"] = "應發薪資";
            DT_zz46t.Rows.Add(aRow2);

            DataRow aRow3 = DT_zz46t.NewRow();
            aRow3["sal_code"] = "O";
            aRow3["sal_name"] = "實發薪資";
            DT_zz46t.Rows.Add(aRow3);

            DataRow aRow4 = DT_zz46ta.NewRow();
            DataRow[] Srow = DT_zz46t.Select("sal_code<>''", "sal_code asc");
            for (int i = 0; i < Srow.Length; i++)
            {
                aRow4["Fld" + (i + 1)] = Srow[i]["sal_name"].ToString();
            }
            DT_zz46ta.Rows.Add(aRow4);
        }

        public static void GetZz46td(DataTable DT_zz46td, DataTable DT_zz46ta, DataTable DT_waged, DataTable DT_wageds1, DataTable DT_wageds2, DataTable DT_wagedsz, DataTable DT_explab)
        {
            DataColumn [] _key = new DataColumn[3];
            _key[0] = DT_zz46td.Columns["nobr"];
            _key[1] = DT_zz46td.Columns["yymm"];
            _key[2] = DT_zz46td.Columns["seq"];
            DT_zz46td.PrimaryKey = _key;

            DataRow[] Srow = DT_waged.Select("", "dept,yymm,seq,nobr,sal_code asc");
            foreach (DataRow Row in Srow)
            {
                //if (Row["flag"].ToString().Trim() == "-")
                //    Row["amt"] = int.Parse(Row["amt"].ToString()) * (-1);
                object[] _value = new object[3];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["yymm"].ToString();
                _value[2] = Row["seq"].ToString();
                DataRow row = DT_zz46td.Rows.Find(_value);

                DataRow row1 = DT_wageds1.Rows.Find(_value);
                DataRow row2 = DT_wageds2.Rows.Find(_value);
                DataRow row3 = DT_wagedsz.Rows.Find(_value);

                object[] _value1 = new object[2];
                _value1[0] = Row["nobr"].ToString();
                _value1[1] = Row["yymm"].ToString();
                DataRow row4 = DT_explab.Rows.Find(_value1);
                //if (row1 != null && row2 != null && row3 != null)
                //{
                    
                //}

                //若已有資料則迴圈增加FLD內容補充增加
                if (row != null)
                {
                    for (int i = 0; i < DT_zz46ta.Columns.Count; i++)
                    {
                        string adfd = DT_zz46ta.Rows[0][i].ToString();
                        if (DT_zz46ta.Rows[0][i].ToString().Trim() != "")
                        {
                            if (DT_zz46ta.Rows[0][i].ToString().Trim() == Row["sal_name"].ToString().Trim())
                                row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row["amt"].ToString());
                            //else if (DT_zz46ta.Rows[0][i].ToString().Trim() == "應稅薪資")
                            //    row["Fld" + (i + 1)] = int.Parse(row1["amt"].ToString());
                            //else if (DT_zz46ta.Rows[0][i].ToString().Trim() == "應發薪資")
                            //    row["Fld" + (i + 1)] = int.Parse(row2["amt"].ToString());
                            //else if (DT_zz46ta.Rows[0][i].ToString().Trim() == "實發薪資")
                            //    row["Fld" + (i + 1)] = int.Parse(row3["amt"].ToString());
                        }
                    }

                }
                //若無資料則新增資料
                else
                {
                    DataRow aRow = DT_zz46td.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["yymm"] = Row["yymm"].ToString();
                    aRow["seq"] = Row["seq"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["d_ename"] = Row["d_ename"].ToString();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["note"] = Row["note"].ToString();
                    aRow["format"] = Row["format"].ToString();
                    aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                    if (!Row.IsNull("tax_date")) aRow["tax_date"] = DateTime.Parse(Row["tax_date"].ToString());
                    if (!Row.IsNull("tax_edate")) aRow["tax_edate"] = DateTime.Parse(Row["tax_edate"].ToString());
                    aRow["l_amt"] = 0;
                    aRow["h_amt"] = 0;
                    aRow["r_amt"] = 0;

                    //增加判斷：只在期別2的時候塞入僱主負擔的資料
                    if (row4 != null && aRow["seq"].ToString().Trim() == "2")
                    {
                            aRow["l_amt"] = int.Parse(row4["l_amt"].ToString());
                            aRow["r_amt"] = int.Parse(row4["r_amt"].ToString());
                            aRow["h_amt"] = int.Parse(row4["h_amt"].ToString());
                    }

                    for (int i = 0; i < DT_zz46ta.Columns.Count; i++)
                    {
                        if (DT_zz46ta.Rows[0][i].ToString().Trim() != "")
                            aRow["Fld" + (i + 1)] = 0;


                        else
                            break;
                    }

                    //塞入值
                    for (int i = 0; i < DT_zz46ta.Columns.Count; i++)
                    {
                        if (DT_zz46ta.Rows[0][i].ToString().Trim() != "")
                        {
                            if (DT_zz46ta.Rows[0][i].ToString().Trim() == Row["sal_name"].ToString().Trim())
                                if (DT_zz46ta.Rows[0][i].ToString().Trim() == "勞保費")
                                    aRow["Fld" + (i + 1)] = int.Parse(Row["amt"].ToString());
                            else
                            aRow["Fld" + (i + 1)] = int.Parse(Row["amt"].ToString());
                            else if (DT_zz46ta.Rows[0][i].ToString().Trim() == "應稅薪資")
                                aRow["Fld" + (i + 1)] = (row1 == null) ? 0 : int.Parse(row1["amt"].ToString());
                            else if (DT_zz46ta.Rows[0][i].ToString().Trim() == "應發薪資")
                                aRow["Fld" + (i + 1)] = (row2 == null) ? 0 : int.Parse(row2["amt"].ToString());
                            else if (DT_zz46ta.Rows[0][i].ToString().Trim() == "實發薪資")
                                aRow["Fld" + (i + 1)] = int.Parse(row3["amt"].ToString());
                        }
                        else
                            break;
                    }


                    DT_zz46td.Rows.Add(aRow);
                }
            }
        }

        public static void GetZz46td1(DataTable DT_zz46td, DataTable DT_zz46ta, DataTable DT_waged, DataTable DT_wageds1, DataTable DT_wageds2, DataTable DT_wagedsz, DataTable DT_explab)
        {
            int _cnt = 0;
            int _wageds1 = 0; int _wageds2 = 0; int _wagedsz = 0; int l_amt = 0; int h_amt = 0; int r_amt = 0;
            foreach (DataRow Row in DT_wageds1.Rows)
            {
                _wageds1 = _wageds1 + int.Parse(Row["amt"].ToString());
            }
            foreach (DataRow Row in DT_wageds2.Rows)
            {
                _wageds2 = _wageds2 + int.Parse(Row["amt"].ToString());
            }
            foreach (DataRow Row in DT_wagedsz.Rows)
            {
                _wagedsz = _wagedsz + int.Parse(Row["amt"].ToString());
            }
            foreach (DataRow Row in DT_explab.Rows)
            {
                l_amt += int.Parse(Row["l_amt"].ToString());
                h_amt += int.Parse(Row["h_amt"].ToString());
                r_amt += int.Parse(Row["r_amt"].ToString());
            }
            foreach (DataRow Row in DT_waged.Rows)
            {
                if (_cnt ==1)
                {
                    for (int i = 0; i < DT_zz46ta.Columns.Count; i++)
                    {
                        string adfd = DT_zz46ta.Rows[0][i].ToString();
                        if (DT_zz46ta.Rows[0][i].ToString().Trim() != "")
                        {
                            if (DT_zz46ta.Rows[0][i].ToString().Trim() == Row["sal_name"].ToString().Trim())
                                DT_zz46td.Rows[0]["Fld" + (i + 1)] = int.Parse(DT_zz46td.Rows[0]["Fld" + (i + 1)].ToString()) + int.Parse(Row["amt"].ToString());                           
                        }
                        else
                            break;
                    }
                }
                else
                {
                    DataRow aRow = DT_zz46td.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["yymm"] = Row["yymm"].ToString();
                    aRow["seq"] = Row["seq"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["d_ename"] = Row["d_ename"].ToString();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["note"] = Row["note"].ToString();
                    aRow["l_amt"] = l_amt;
                    aRow["r_amt"] = r_amt;
                    aRow["h_amt"] = h_amt;
                    for (int i = 0; i < DT_zz46ta.Columns.Count; i++)
                    {
                        if (DT_zz46ta.Rows[0][i].ToString().Trim() != "")
                            aRow["Fld" + (i + 1)] = 0;
                        else
                            break;
                    }                    
                    for (int i = 0; i < DT_zz46ta.Columns.Count; i++)
                    {
                        if (DT_zz46ta.Rows[0][i].ToString().Trim() != "")
                        {
                            if (DT_zz46ta.Rows[0][i].ToString().Trim() == Row["sal_name"].ToString().Trim())
                                aRow["Fld" + (i + 1)] = int.Parse(Row["amt"].ToString());
                            else if (DT_zz46ta.Rows[0][i].ToString().Trim() == "應稅薪資")
                                aRow["Fld" + (i + 1)] = _wageds1;
                            else if (DT_zz46ta.Rows[0][i].ToString().Trim() == "應發薪資")
                                aRow["Fld" + (i + 1)] = _wageds2;
                            else if (DT_zz46ta.Rows[0][i].ToString().Trim() == "實發薪資")
                                aRow["Fld" + (i + 1)] = _wagedsz;
                        }
                        else
                            break;
                    }
                    DT_zz46td.Rows.Add(aRow);
                    _cnt++;
                }
            }
        }


        public static void GetZz463(DataTable DT_zz463, DataTable DT_waged, DataTable DT_base, string retsalcode, string taxsalcode)
        {
            DataColumn[] _key = new DataColumn[2];
            _key[0] = DT_zz463.Columns["nobr"];
            _key[1] = DT_zz463.Columns["comp"];            
            DT_zz463.PrimaryKey = _key;

            //string retsalcode = (DT_sys4.Rows.Count > 0) ? DT_sys4.Rows[0]["retsalcode"].ToString().Trim() : "";
            //string taxsalcode = (DT_sys9.Rows.Count > 0) ? DT_sys9.Rows[0]["taxsalcode"].ToString().Trim() : "";
            DataRow[] Srow = DT_waged.Select("", "dept,nobr,comp asc");
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["comp"].ToString();               
                DataRow row = DT_zz463.Rows.Find(_value);
                string _yy = Row["yymm"].ToString().Trim().Substring(4, 2);                
                if (row != null)
                { 
                    for(int i=1;i<13;i++)
                    {                        
                         string str_i = Convert.ToString(i.ToString()).PadLeft(3, '0').Substring(1, 2);
                        if (bool.Parse(Row["tax"].ToString()))
                        {
                            if (_yy == str_i)
                            {
                                row["C_" + _yy] = int.Parse(row["C_" + str_i].ToString()) + int.Parse(Row["amt"].ToString());
                                row["Csum"] = int.Parse(row["Csum"].ToString()) + int.Parse(Row["amt"].ToString());
                            }                           
                        }
                        if (taxsalcode==Row["sal_code"].ToString().Trim())
                            if (_yy == str_i)
                            {
                                row["T_" + _yy] = int.Parse(row["T_" + str_i].ToString()) + int.Parse(Row["amt"].ToString());
                                row["Tsum"] = int.Parse(row["Tsum"].ToString()) + int.Parse(Row["amt"].ToString());
                            }
                        if (retsalcode == Row["sal_code"].ToString().Trim())
                            if (_yy == str_i)
                            {
                                row["R_" + _yy] = int.Parse(row["R_" + str_i].ToString()) + int.Parse(Row["amt"].ToString());
                                row["Rsum"] = int.Parse(row["Rsum"].ToString()) + int.Parse(Row["amt"].ToString());
                            }
                    }
                }
                else
                {
                    DataRow aRow = DT_zz463.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["d_ename"] = Row["d_ename"].ToString();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["Csum"] = 0;
                    aRow["Tsum"] = 0;
                    aRow["Rsum"] = 0;
                    for (int i = 1; i < 13;i++ )
                    {
                        string str_i = Convert.ToString(i.ToString()).PadLeft(3, '0').Substring(1, 2);
                        aRow["C_" + str_i] = 0;
                        aRow["T_" + str_i] = 0;
                        aRow["R_" + str_i] = 0;                       
                        if (bool.Parse(Row["tax"].ToString()))
                        {
                            if (_yy == str_i)
                            {
                                aRow["C_" + _yy] = int.Parse(Row["amt"].ToString());
                                aRow["Csum"] = int.Parse(Row["amt"].ToString());
                            }
                        }
                        if (taxsalcode == Row["sal_code"].ToString().Trim())
                            if (_yy == str_i)
                            {
                                aRow["T_" + _yy] = int.Parse(Row["amt"].ToString());
                                aRow["Tsum"] = int.Parse(Row["amt"].ToString());
                            }
                        if (retsalcode == Row["sal_code"].ToString().Trim())
                            if (_yy == str_i)
                            {
                                aRow["R_" + _yy] = int.Parse(Row["amt"].ToString());
                                aRow["Rsum"] = int.Parse(Row["amt"].ToString());
                            }
                    }
                    DataRow row2 = DT_base.Rows.Find(Row["nobr"].ToString());
                    if (row2 != null)
                    {
                        aRow["indt"] = DateTime.Parse(row2["indt"].ToString());
                        if (!row2.IsNull("oudt")) aRow["oudt"] =   DateTime.Parse(row2["oudt"].ToString());
                        aRow["idno"] = row2["idno"].ToString();
                        aRow["addr2"] = row2["addr2"].ToString();
                    }
                    DT_zz463.Rows.Add(aRow);
                }
            }
        }

        public static void GetZz464(DataTable DT_zz464, DataTable DT_waged, string taxsalcode, DataTable DT_lock, DataTable DT_comp)
        {
            DataColumn[] _key = new DataColumn[3];
            _key[0] = DT_zz464.Columns["comp"];
            _key[1] = DT_zz464.Columns["yymm"];
            _key[2] = DT_zz464.Columns["seq"];
            DT_zz464.PrimaryKey = _key;

            DataColumn[] _key1 = new DataColumn[2];
            _key1[0] = DT_lock.Columns["yymm"];
            _key1[1] = DT_lock.Columns["seq"];           
            DT_lock.PrimaryKey = _key1;
            //string taxsalcode = (DT_sys91.Rows.Count > 0) ? DT_sys91.Rows[0]["taxsalcode"].ToString().Trim() : "";
            DataRow[] Srow = DT_waged.Select("", "comp,yymm,seq asc");
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[3];
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["yymm"].ToString();
                _value[2] = Row["seq"].ToString();
                DataRow row = DT_zz464.Rows.Find(_value);
                
                if (row != null)
                {
                    if (bool.Parse(Row["tax"].ToString()))
                        row["tolamt"] = int.Parse(row["tolamt"].ToString()) + int.Parse(Row["amt"].ToString());
                    if (taxsalcode == Row["sal_code"].ToString().Trim())
                        row["taxamt"] = int.Parse(row["taxamt"].ToString()) + (int.Parse(Row["amt"].ToString()) * (-1));
                }
                else
                {
                    object[] _value1 = new object[2];
                    _value1[0] = Row["yymm"].ToString();
                    _value1[1] = Row["seq"].ToString();
                    DataRow row2 = DT_comp.Rows.Find(Row["comp"].ToString());
                    DataRow row3 = DT_lock.Rows.Find(_value1);
                    DataRow aRow = DT_zz464.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    if (row2 != null)
                        aRow["compname"] = row2["compname"].ToString();
                    aRow["yymm"] = Row["yymm"].ToString();
                    aRow["seq"] = Row["seq"].ToString();
                    aRow["tolamt"] = 0;
                    aRow["taxamt"] = 0;
                    if (row3!=null)
                        aRow["meno"] = row3["meno"].ToString();                    
                    if (bool.Parse(Row["tax"].ToString()))
                        aRow["tolamt"] = int.Parse(Row["amt"].ToString());
                    if (taxsalcode == Row["sal_code"].ToString().Trim())
                        aRow["taxamt"] = int.Parse(Row["amt"].ToString()) * (-1);   
                    
                    DT_zz464.Rows.Add(aRow);
                }
            }
        }

         public static void GetZz464a(DataTable DT_zz464a,DataTable DT_zz464)
         {
             DT_zz464a.PrimaryKey = new DataColumn[] { DT_zz464a.Columns["comp"] };
             foreach (DataRow Row in DT_zz464.Rows)
             {
                 DataRow row = DT_zz464a.Rows.Find(Row["comp"].ToString());
                 if (row != null)
                 {
                     row["tolamt"] = int.Parse(row["tolamt"].ToString()) + int.Parse(Row["tolamt"].ToString());
                     row["taxamt"] = int.Parse(row["taxamt"].ToString()) + int.Parse(Row["taxamt"].ToString());
                 }
                 else
                 {
                     DataRow aRow = DT_zz464a.NewRow();
                     aRow["comp"] = Row["comp"].ToString();
                     aRow["compname"] = Row["compname"].ToString();
                     aRow["tolamt"] = int.Parse(Row["tolamt"].ToString());
                     aRow["taxamt"] = int.Parse(Row["taxamt"].ToString());
                     DT_zz464a.Rows.Add(aRow);
                 }
             }
         }

         public static void GetZz464b(DataTable DT_zz464b, DataTable DT_zz464)
         {
             DT_zz464b.PrimaryKey = new DataColumn[] { DT_zz464b.Columns["yymm"],DT_zz464b.Columns["seq"] };
             foreach (DataRow Row in DT_zz464.Rows)
             {
                 object[] _value = new object[2];
                 _value[0] = Row["yymm"].ToString();
                 _value[1] = Row["seq"].ToString();
                 DataRow row = DT_zz464b.Rows.Find(_value);
                 if (row != null)
                 {
                     row["tolamt"] = int.Parse(row["tolamt"].ToString()) + int.Parse(Row["tolamt"].ToString());
                     row["taxamt"] = int.Parse(row["taxamt"].ToString()) + int.Parse(Row["taxamt"].ToString());
                 }
                 else
                 {
                     DataRow aRow = DT_zz464b.NewRow();
                     aRow["yymm"] = Row["yymm"].ToString();
                     aRow["seq"] = Row["seq"].ToString();
                     aRow["meno"] = Row["meno"].ToString();
                     aRow["tolamt"] = int.Parse(Row["tolamt"].ToString());
                     aRow["taxamt"] = int.Parse(Row["taxamt"].ToString());
                     DT_zz464b.Rows.Add(aRow);
                 }
             }
         }


         public static void Get_Eplab(DataTable DT_explab, DataTable DT_explab1)
         {
             foreach (DataRow Row in DT_explab1.Rows)
             {
                 Row["comp"] = JBModule.Data.CDecryp.Number(decimal.Parse(Row["comp"].ToString()));
                 object[] _value = new object[2];
                 _value[0] = Row["nobr"].ToString();
                 _value[1] = Row["sal_yymm"].ToString();
                 DataRow row1 = DT_explab.Rows.Find(_value);
                 if (row1 != null)
                 {
                     if (Row["insur_type"].ToString().Trim() == "1")
                         row1["l_amt"] = int.Parse(Row["comp"].ToString());
                     else if (Row["insur_type"].ToString().Trim() == "2")
                         row1["h_amt"] = int.Parse(Row["comp"].ToString());
                     else if (Row["insur_type"].ToString().Trim() == "4")
                         row1["r_amt"] = int.Parse(Row["comp"].ToString());
                 }
                 else
                 {
                     DataRow aRow = DT_explab.NewRow();
                     aRow["nobr"] = Row["nobr"].ToString();
                     aRow["yymm"] = Row["sal_yymm"].ToString();
                     aRow["h_amt"] = 0;
                     aRow["l_amt"] = 0;
                     aRow["r_amt"] = 0;
                     if (Row["insur_type"].ToString().Trim() == "1")
                         aRow["l_amt"] = int.Parse(Row["comp"].ToString());
                     else if (Row["insur_type"].ToString().Trim() == "2")
                         aRow["h_amt"] = int.Parse(Row["comp"].ToString());
                     else if (Row["insur_type"].ToString().Trim() == "4")
                         aRow["r_amt"] = int.Parse(Row["comp"].ToString());
                     DT_explab.Rows.Add(aRow);
                 }

             }
         }

         public static void GetZz466(DataTable DT_zz465, DataTable DT_waged, string MedianMon)
         {
             DataTable rq_zz465 = new DataTable();
             rq_zz465 = DT_zz465.Clone();

             rq_zz465.PrimaryKey = new DataColumn[] { rq_zz465.Columns["nobr"] };
             DataRow[] Srow = DT_waged.Select("mang=0 and salattr<='L' and sal_mang=0", "nobr,yymm,seq asc");
             string nobryymm1 = "";
             foreach (DataRow Row in Srow)
             {
                 DataRow row = rq_zz465.Rows.Find(Row["nobr"].ToString());
                 string _yy = Row["yymm"].ToString().Trim().Substring(4, 2);
                 bool _notfreq = bool.Parse(Row["notfreq"].ToString());
                 string nobryymm = Row["nobr"].ToString() + Row["yymm"].ToString();
                 if (row != null)
                 {
                     if (nobryymm != nobryymm1) row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                     for (int i = 1; i < 13; i++)
                     {
                         string str_i = Convert.ToString(i.ToString()).PadLeft(3, '0').Substring(1, 2);
                         if (_yy == str_i)
                         {
                             row["C_" + _yy] = int.Parse(row["C_" + str_i].ToString()) + int.Parse(Row["amt"].ToString());
                             row["Csum"] = int.Parse(row["Csum"].ToString()) + int.Parse(Row["amt"].ToString());
                             if (_notfreq)
                             {
                                 row["IrregularEarning"] = int.Parse(row["IrregularEarning"].ToString()) + int.Parse(Row["amt"].ToString());

                             }
                             else
                             {
                                 row["RegularEarnings"] = int.Parse(row["RegularEarnings"].ToString()) + int.Parse(Row["amt"].ToString());
                             }
                         }
                     }
                 }
                 else
                 {
                     DataRow aRow = rq_zz465.NewRow();
                     aRow["comp"] = Row["comp"].ToString();
                     aRow["nobr"] = Row["nobr"].ToString();
                     aRow["name_c"] = Row["name_c"].ToString();
                     aRow["dept"] = Row["dept"].ToString();
                     aRow["d_name"] = Row["d_name"].ToString();
                     aRow["job"] = Row["job"].ToString();
                     aRow["job_name"] = Row["job_name"].ToString();
                     aRow["indt"] = DateTime.Parse(Row["indt"].ToString());
                     if (!Row.IsNull("oudt")) aRow["oudt"] = Row["oudt"].ToString();
                     aRow["RegularEarnings"] = 0;
                     aRow["IrregularEarning"] = 0;
                     aRow["Csum"] = 0;
                     aRow["cnt"] = 1;
                     for (int i = 1; i < 13; i++)
                     {
                         string str_i = Convert.ToString(i.ToString()).PadLeft(3, '0').Substring(1, 2);
                         aRow["C_" + str_i] = 0;
                         if (_yy == str_i)
                         {
                             aRow["C_" + _yy] = int.Parse(Row["amt"].ToString());
                             aRow["Csum"] = int.Parse(Row["amt"].ToString());
                             if (_notfreq)
                             {
                                 aRow["IrregularEarning"] = int.Parse(Row["amt"].ToString());
                             }
                             else
                             {
                                 aRow["RegularEarnings"] = int.Parse(Row["amt"].ToString());
                             }
                         }
                     }

                     rq_zz465.Rows.Add(aRow);
                 }
                 nobryymm1 = Row["nobr"].ToString() + Row["yymm"].ToString();
             }
             DataRow[] SRow1 = rq_zz465.Select("", "dept,nobr asc");

             if (MedianMon == "1")
                SRow1 = rq_zz465.Select("cnt>=6", "dept,nobr asc");
             else if (MedianMon == "2")
                SRow1 = rq_zz465.Select("cnt<6", "dept,nobr asc");
            
             foreach (DataRow Row in SRow1)    //Select("cnt>=6", "dept,nobr asc")MedianMon
             {
                 Row["YMedian"] = Math.Round((decimal.Parse(Row["RegularEarnings"].ToString()) / decimal.Parse(Row["cnt"].ToString())) * 12M, MidpointRounding.AwayFromZero);
                 Row["Yamt"] = int.Parse(Row["IrregularEarning"].ToString()) + int.Parse(Row["YMedian"].ToString());
                 DT_zz465.ImportRow(Row);
             }
             rq_zz465 = null;
         }
        public static void ExPort1(DataTable DT_42td, DataTable DT_42ta, string FileName,string reporttype)
        {
            DataTable ExporDt = new DataTable();
            if (reporttype == "1")
            {
                ExporDt.Columns.Add("部門代碼", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));
                ExporDt.Columns.Add("英文部門名稱", typeof(string));
            }
            if (reporttype != "2")
            {
                ExporDt.Columns.Add("公司別", typeof(string));
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("英文姓名", typeof(string));
                ExporDt.Columns.Add("計薪年月", typeof(string));
                ExporDt.Columns.Add("期別", typeof(string));
                ExporDt.Columns.Add("媒體格式", typeof(string));
                ExporDt.Columns.Add("轉帳日期", typeof(DateTime));
                ExporDt.Columns.Add("居留證起始日", typeof(DateTime));
                ExporDt.Columns.Add("居留證到期日", typeof(DateTime));
            }
            ExporDt.Columns.Add("雇主勞保負擔", typeof(int));
            ExporDt.Columns.Add("雇主健保負擔", typeof(int));
            ExporDt.Columns.Add("雇主勞退負擔", typeof(int));
            for (int i = 0; i < DT_42ta.Columns.Count; i++)
            {
                if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_42ta.Rows[0][i].ToString().Trim(), typeof(int));
                }
                else
                    break;
            }
            foreach (DataRow Row01 in DT_42td.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                if (reporttype == "1")
                {
                    aRow["部門代碼"] = Row01["dept"].ToString();
                    aRow["部門名稱"] = Row01["d_name"].ToString();
                    aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                }
                if (reporttype != "2")
                {
                    aRow["公司別"] = Row01["comp"].ToString();
                    aRow["員工編號"] = Row01["nobr"].ToString();
                    aRow["員工姓名"] = Row01["name_c"].ToString();
                    aRow["英文姓名"] = Row01["name_e"].ToString();
                    aRow["計薪年月"] = Row01["yymm"].ToString();
                    aRow["期別"] = Row01["seq"].ToString();
                    aRow["媒體格式"] = Row01["format"].ToString();
                    aRow["轉帳日期"] = DateTime.Parse(Row01["adate"].ToString());
                    if (!Row01.IsNull("tax_date")) aRow["居留證起始日"] = DateTime.Parse(Row01["tax_date"].ToString());
                    if (!Row01.IsNull("tax_edate")) aRow["居留證到期日"] = DateTime.Parse(Row01["tax_edate"].ToString());

                }
                aRow["雇主勞保負擔"] = int.Parse(Row01["l_amt"].ToString());
                aRow["雇主健保負擔"] = int.Parse(Row01["h_amt"].ToString());
                aRow["雇主勞退負擔"] = int.Parse(Row01["r_amt"].ToString());
                for (int i = 0; i < DT_42ta.Columns.Count; i++)
                {
                    if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_42ta.Rows[0][i].ToString().Trim()] = int.Parse(Row01["Fld" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort2(DataTable DT_42td, DataTable DT_42ta, string FileName, string reporttype)
        {
            DataTable DT_Result = new DataTable();
            DT_Result.Columns.Add("dept", typeof(string));
            DT_Result.Columns.Add("d_name", typeof(string));
            DT_Result.Columns.Add("d_ename", typeof(string));
            //DT_Result.Columns.Add("l_amt", typeof(int));
            //DT_Result.Columns.Add("h_amt", typeof(int));
            //DT_Result.Columns.Add("r_amt", typeof(int));
            DT_Result.Columns.Add("yymm", typeof(string));
            DT_Result.Columns.Add("seq", typeof(string));
            for (int i = 1; i <= 80; i++)
            {
                DT_Result.Columns.Add("Fld" + i.ToString(), typeof(int));
            }
            DT_Result.PrimaryKey = new DataColumn[] { DT_Result.Columns["dept"] };

            foreach (DataRow DT_row in DT_42td.Rows)
            {
                DataRow row = DT_Result.Rows.Find(DT_row["dept"]);
                if(row != null)
                {
                    //row["l_amt"] = int.Parse(row["l_amt"].ToString()) + int.Parse(DT_row["l_amt"].ToString());
                    //row["h_amt"] = int.Parse(row["h_amt"].ToString()) + int.Parse(DT_row["h_amt"].ToString());
                    //row["r_amt"] = int.Parse(row["r_amt"].ToString()) + int.Parse(DT_row["r_amt"].ToString());

                    for (int i = 1; i <= 80; i++)
                    {
                        if (DT_row["Fld" + i.ToString()].ToString() != "")
                        {
                            row["Fld" + i.ToString()] = int.Parse(row["Fld" + i.ToString()].ToString()) + int.Parse(DT_row["Fld" + i.ToString()].ToString());
                        }
                    }
                }
                else
                {
                    DataRow aRow = DT_Result.NewRow();
                    aRow["dept"] = DT_row["dept"].ToString();
                    aRow["d_name"] = DT_row["d_name"].ToString();
                    aRow["d_ename"] = DT_row["d_ename"].ToString();
                    //aRow["l_amt"] = int.Parse(DT_row["l_amt"].ToString());
                    //aRow["h_amt"] = int.Parse(DT_row["h_amt"].ToString());
                    //aRow["r_amt"] = int.Parse(DT_row["r_amt"].ToString());
                    aRow["yymm"] = DT_row["yymm"].ToString();
                    aRow["seq"] = DT_row["seq"].ToString();

                    for (int i = 1; i <= 80; i++)
                    {
                        if (DT_row["Fld" + i.ToString()].ToString() != "")
                        {
                            aRow["Fld" + i.ToString()] = int.Parse(DT_row["Fld" + i.ToString()].ToString());
                        }
                    }
                    DT_Result.Rows.Add(aRow);
                }
            }


            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            //ExporDt.Columns.Add("雇主勞保負擔", typeof(int));
            //ExporDt.Columns.Add("雇主健保負擔", typeof(int));
            //ExporDt.Columns.Add("雇主勞退負擔", typeof(int));
            ExporDt.Columns.Add("年月", typeof(string));
            ExporDt.Columns.Add("期別", typeof(string));
            for (int i = 0; i < DT_42ta.Columns.Count; i++)
            {
                if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_42ta.Rows[0][i].ToString().Trim(), typeof(int));
                }
                else
                    break;
            }
            foreach (DataRow Row01 in DT_Result.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                //aRow["雇主勞保負擔"] = int.Parse(Row01["l_amt"].ToString());
                //aRow["雇主健保負擔"] = int.Parse(Row01["h_amt"].ToString());
                //aRow["雇主勞退負擔"] = int.Parse(Row01["r_amt"].ToString());
                aRow["年月"] = Row01["yymm"].ToString();
                aRow["期別"] = Row01["seq"].ToString();
                for (int i = 0; i < DT_42ta.Columns.Count; i++)
                {
                    if (DT_42ta.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_42ta.Rows[0][i].ToString().Trim()] = int.Parse(Row01["Fld" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);

            //DataTable ExporDt = new DataTable();
            //ExporDt.Columns.Add("公司代碼", typeof(string));
            //ExporDt.Columns.Add("公司名稱", typeof(string));
            //ExporDt.Columns.Add("薪資年月", typeof(string));
            //ExporDt.Columns.Add("期別", typeof(string));
            //ExporDt.Columns.Add("備註", typeof(string));
            //ExporDt.Columns.Add("應稅薪資", typeof(int));
            //ExporDt.Columns.Add("代扣稅額", typeof(int));           
            //DataRow[] Srow = DT_464.Select("", "comp asc");
            //foreach (DataRow Row01 in Srow)
            //{
            //    DataRow aRow = ExporDt.NewRow();
            //    aRow["公司代碼"] = Row01["comp"].ToString();
            //    aRow["公司名稱"] = Row01["compname"].ToString();
            //    aRow["薪資年月"] = Row01["yymm"].ToString();
            //    aRow["期別"] = Row01["seq"].ToString();
            //    aRow["備註"] = Row01["meno"].ToString();
            //    aRow["應稅薪資"] = int.Parse(Row01["tolamt"].ToString());
            //    aRow["代扣稅額"] = int.Parse(Row01["taxamt"].ToString());                              
            //    ExporDt.Rows.Add(aRow);
            //}
            //JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort4(DataTable DT_463, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("身份證號", typeof(string));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("離職日期", typeof(DateTime));
            ExporDt.Columns.Add("戶籍地址", typeof(string));
            for (int i = 1; i < 13;i++ )
            {
                ExporDt.Columns.Add(i.ToString().PadLeft(2, '0') + "薪資", typeof(int));
                ExporDt.Columns.Add(i.ToString().PadLeft(2, '0') + "稅額", typeof(int));
                ExporDt.Columns.Add(i.ToString().PadLeft(2, '0') + "自提", typeof(int));
            }
            ExporDt.Columns.Add("薪資合計", typeof(int));
            ExporDt.Columns.Add("稅額合計", typeof(int));
            ExporDt.Columns.Add("自提合計", typeof(int));
            DataRow[] Srow = DT_463.Select("", "dept asc");
            foreach (DataRow Row01 in Srow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["英文姓名"] = Row01["name_e"].ToString();
                aRow["身份證號"] = Row01["idno"].ToString();
                aRow["到職日期"] = DateTime.Parse(Row01["indt"].ToString());
                if (!Row01.IsNull("oudt")) aRow["離職日期"] =  DateTime.Parse(Row01["oudt"].ToString());
                aRow["戶籍地址"] = Row01["addr2"].ToString();
                aRow["薪資合計"] = int.Parse(Row01["Csum"].ToString());
                aRow["稅額合計"] = int.Parse(Row01["Tsum"].ToString());
                aRow["自提合計"] = int.Parse(Row01["Rsum"].ToString());
                for (int i = 1; i < 13; i++)
                {
                    aRow[i.ToString().PadLeft(2, '0') + "薪資"] = int.Parse(Row01["C_" + i.ToString().PadLeft(2, '0')].ToString());
                    aRow[i.ToString().PadLeft(2, '0') + "稅額"] = int.Parse(Row01["T_" + i.ToString().PadLeft(2, '0')].ToString());
                    aRow[i.ToString().PadLeft(2, '0') + "自提"] = int.Parse(Row01["R_" + i.ToString().PadLeft(2, '0')].ToString());
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort5(DataTable DT_464, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("公司代碼", typeof(string));
            ExporDt.Columns.Add("公司名稱", typeof(string));
            ExporDt.Columns.Add("薪資年月", typeof(string));
            ExporDt.Columns.Add("期別", typeof(string));
            ExporDt.Columns.Add("備註", typeof(string));
            ExporDt.Columns.Add("應稅薪資", typeof(int));
            ExporDt.Columns.Add("代扣稅額", typeof(int));           
            DataRow[] Srow = DT_464.Select("", "comp asc");
            foreach (DataRow Row01 in Srow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["公司代碼"] = Row01["comp"].ToString();
                aRow["公司名稱"] = Row01["compname"].ToString();
                aRow["薪資年月"] = Row01["yymm"].ToString();
                aRow["期別"] = Row01["seq"].ToString();
                aRow["備註"] = Row01["meno"].ToString();
                aRow["應稅薪資"] = int.Parse(Row01["tolamt"].ToString());
                aRow["代扣稅額"] = int.Parse(Row01["taxamt"].ToString());                              
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort6(DataTable DT_464a, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("公司代碼", typeof(string));
            ExporDt.Columns.Add("公司名稱", typeof(string));           
            ExporDt.Columns.Add("應稅薪資", typeof(int));
            ExporDt.Columns.Add("代扣稅額", typeof(int));
            
            foreach (DataRow Row01 in DT_464a.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["公司代碼"] = Row01["comp"].ToString();
                aRow["公司名稱"] = Row01["compname"].ToString();               
                aRow["應稅薪資"] = int.Parse(Row01["tolamt"].ToString());
                aRow["代扣稅額"] = int.Parse(Row01["taxamt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort7(DataTable DT_464, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("薪資年月", typeof(string));
            ExporDt.Columns.Add("期別", typeof(string));
            ExporDt.Columns.Add("公司代碼", typeof(string));
            ExporDt.Columns.Add("公司名稱", typeof(string));
            ExporDt.Columns.Add("應稅薪資", typeof(int));
            ExporDt.Columns.Add("代扣稅額", typeof(int));
            DataRow[] Srow = DT_464.Select("", "yymm,seq asc");
            foreach (DataRow Row01 in Srow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["薪資年月"] = Row01["yymm"].ToString();
                aRow["期別"] = Row01["seq"].ToString();
                aRow["公司代碼"] = Row01["comp"].ToString();
                aRow["公司名稱"] = Row01["compname"].ToString(); 
                aRow["應稅薪資"] = int.Parse(Row01["tolamt"].ToString());
                aRow["代扣稅額"] = int.Parse(Row01["taxamt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort8(DataTable DT_464b, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("薪資年月", typeof(string));
            ExporDt.Columns.Add("期別", typeof(string));
            ExporDt.Columns.Add("備註", typeof(string));
            ExporDt.Columns.Add("應稅薪資", typeof(int));
            ExporDt.Columns.Add("代扣稅額", typeof(int));
            DataRow[] Srow = DT_464b.Select("", "yymm,seq asc");
            foreach (DataRow Row01 in Srow)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["薪資年月"] = Row01["yymm"].ToString();
                aRow["期別"] = Row01["seq"].ToString();
                aRow["備註"] = Row01["meno"].ToString();
                aRow["應稅薪資"] = int.Parse(Row01["tolamt"].ToString());
                aRow["代扣稅額"] = int.Parse(Row01["taxamt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort9(DataTable DT_465, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("到職日期", typeof(DateTime));
            ExporDt.Columns.Add("離職日期", typeof(DateTime));
            for (int i = 1; i < 13; i++)
            {
                ExporDt.Columns.Add(i.ToString() + "月", typeof(int));
            }
            ExporDt.Columns.Add("原始年薪金額", typeof(int));
            ExporDt.Columns.Add("在職給薪月數", typeof(int));
            ExporDt.Columns.Add("非經常性薪資", typeof(int));
            ExporDt.Columns.Add("經常性薪資", typeof(int));
            ExporDt.Columns.Add("經常性薪資(年化)", typeof(int));
            ExporDt.Columns.Add("總薪資(年化)", typeof(int));
            foreach (DataRow Row01 in DT_465.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["職稱"] = Row01["job_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["到職日期"] = DateTime.Parse(Row01["indt"].ToString());
                if (!Row01.IsNull("oudt")) aRow["離職日期"] = DateTime.Parse(Row01["oudt"].ToString());
                for (int i = 1; i < 13; i++)
                {
                    aRow[i.ToString() + "月"] = int.Parse(Row01["C_" + i.ToString().PadLeft(2, '0')].ToString());
                }
                aRow["原始年薪金額"] = int.Parse(Row01["Csum"].ToString());
                aRow["在職給薪月數"] = int.Parse(Row01["cnt"].ToString());
                aRow["非經常性薪資"] = int.Parse(Row01["IrregularEarning"].ToString());
                aRow["經常性薪資"] = int.Parse(Row01["RegularEarnings"].ToString());
                aRow["經常性薪資(年化)"] = int.Parse(Row01["YMedian"].ToString());
                aRow["總薪資(年化)"] = int.Parse(Row01["Yamt"].ToString());
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }
    }
}
