using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBHR.Reports.SalForm
{
    class ZZ4A1Class
    {
        public static void GetWageds1(DataTable DT_wageds1, DataTable DT_waged)
        {           
            DT_wageds1.PrimaryKey = new DataColumn[] { DT_wageds1.Columns["nobr"], DT_wageds1.Columns["depts"] };
            DataRow[] Srow = DT_waged.Select("salattr<='F'");
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["depts"].ToString();
                DataRow row = DT_wageds1.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wageds1.Rows.Add(aRow);
                }
            }
        }

        public static void GetWageds2(DataTable DT_wageds2, DataTable DT_waged, string retsalcode)
        {           
            DT_wageds2.PrimaryKey = new DataColumn[] { DT_wageds2.Columns["nobr"], DT_wageds2.Columns["depts"] };
            DataRow[] Srow = DT_waged.Select("salattr<='L' and sal_code<> '" + retsalcode + "'");
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["depts"].ToString();
                DataRow row = DT_wageds2.Rows.Find(_value);               
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wageds2.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wageds2.Rows.Add(aRow);
                }
            }
        }

        public static void GetWagedsz(DataTable DT_wagedsz, DataTable DT_waged)
        {            
            DT_wagedsz.PrimaryKey = new DataColumn[] { DT_wagedsz.Columns["nobr"], DT_wagedsz.Columns["depts"] };
            foreach (DataRow Row in DT_waged.Rows)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["depts"].ToString();
                DataRow row = DT_wagedsz.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wagedsz.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wagedsz.Rows.Add(aRow);
                }
            }
        }

        public static void GetZz4a1t(DataTable DT_zz4a1t, DataTable DT_waged, DataTable DT_zz4a1ta)
        {
            DataTable rq_zz4a1t1 = new DataTable();
            rq_zz4a1t1 = DT_zz4a1t.Clone();
            //rq_zz4a1t1.PrimaryKey = new DataColumn[] { rq_zz4a1t1.Columns["sal_code"] };
            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_salcode = Row["salattr"].ToString() + Row["sal_code"].ToString();
                DataRow row = rq_zz4a1t1.Rows.Find(str_salcode);
                if (row == null)
                {
                    DataRow aRow = rq_zz4a1t1.NewRow();
                    aRow["sal_code"] = str_salcode;
                    aRow["sal_name"] = Row["sal_name"].ToString();
                    rq_zz4a1t1.Rows.Add(aRow);
                }
            }

            DataRow aRow1 = rq_zz4a1t1.NewRow();
            aRow1["sal_code"] = "F";
            aRow1["sal_name"] = "應稅薪資";
            rq_zz4a1t1.Rows.Add(aRow1);

            DataRow aRow2 = rq_zz4a1t1.NewRow();
            aRow2["sal_code"] = "L";
            aRow2["sal_name"] = "應發薪資";
            rq_zz4a1t1.Rows.Add(aRow2);

            DataRow aRow3 = rq_zz4a1t1.NewRow();
            aRow3["sal_code"] = "O";
            aRow3["sal_name"] = "實發薪資";
            rq_zz4a1t1.Rows.Add(aRow3);

            DataRow aRow4 = DT_zz4a1ta.NewRow();
            DataRow[] Srow = rq_zz4a1t1.Select("sal_code<>''", "sal_code asc");
            for (int i = 0; i < Srow.Length; i++)
            {
                aRow4["Fld" + (i + 1)] = Srow[i]["sal_name"].ToString();
                DataRow aRow = DT_zz4a1t.NewRow();
                aRow["sal_code"] = Srow[i]["sal_code"].ToString();
                aRow["sal_name"] = Srow[i]["sal_name"].ToString();
                DT_zz4a1t.Rows.Add(aRow);
            }
            DT_zz4a1ta.Rows.Add(aRow4);
            rq_zz4a1t1 = null;

        }

        public static void GeWagedb(DataTable DT_cost, DataTable DT_waged, DataTable DT_wagedb)
        {           
            int _rowcnt = 0; string str_nobr1 = "";
            foreach (DataRow Row in DT_cost.Rows)
            {
                if (Row["nobr"].ToString() == str_nobr1)
                    _rowcnt = 1;
                else
                    _rowcnt = 0;
                DataRow[] row = DT_waged.Select("nobr='" + Row["nobr"].ToString() + "'");
                for (int i = 0; i < row.Length; i++)
                {
                    DataRow aRow = DT_wagedb.NewRow();
                    aRow["nobr"] = row[i]["nobr"].ToString();
                    aRow["sal_code"] = row[i]["sal_code"].ToString();                    
                    aRow["name_c"] = row[i]["name_c"].ToString();                  
                    aRow["di"] = row[i]["di"].ToString();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["ds_name"] = Row["d_name"].ToString();                  
                    aRow["sal_name"] = row[i]["sal_name"].ToString();
                    aRow["flag"] = row[i]["flag"].ToString();
                    aRow["salattr"] = row[i]["salattr"].ToString();
                    aRow["amt"] = Math.Round(decimal.Parse(row[i]["amt"].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero);                    
                    aRow["rate"] = decimal.Parse(Row["rate"].ToString());
                    aRow["rowcnt"] = _rowcnt;
                    DT_wagedb.Rows.Add(aRow);
                }
                str_nobr1 = Row["nobr"].ToString();
            }            
        }

        public static void GeWagedc(DataTable DT_wageb, DataTable DT_wagedc)
        {
            DT_wagedc.Columns.Add("nobr", typeof(string));
            DT_wagedc.Columns.Add("sal_code", typeof(string));
            DT_wagedc.Columns.Add("amt", typeof(int));
            DT_wagedc.PrimaryKey = new DataColumn[] { DT_wagedc.Columns["nobr"], DT_wagedc.Columns["sal_code"] };

            foreach (DataRow Row in DT_wageb.Rows)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["sal_code"].ToString();
                DataRow row = DT_wagedc.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wagedc.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["sal_code"] = Row["sal_code"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wagedc.Rows.Add(aRow);
                }
            }
           
        }
         

        public static void GetWaged1(DataTable DT_waged, DataTable DT_wageb, DataTable DT_wagedc)
        {
            DataTable rq_diff = new DataTable();
            rq_diff.Columns.Add("nobr", typeof(string));
            rq_diff.Columns.Add("sal_code", typeof(string));
            rq_diff.Columns.Add("diffamt", typeof(int));
            rq_diff.PrimaryKey = new DataColumn[] { rq_diff.Columns["nobr"], rq_diff.Columns["sal_code"] };
            foreach (DataRow Row in DT_wagedc.Rows)
            {
                int _damt = 0; int _salamt = 0;
                DataRow[] row = DT_waged.Select("nobr='" + Row["nobr"].ToString() + "' and sal_code='" + Row["sal_code"].ToString() + "'");
                DataRow[] row1 = DT_wageb.Select("nobr='" + Row["nobr"].ToString() + "' and sal_code='" + Row["sal_code"].ToString() + "'");
                if (row.Length > 0 && row1.Length > 0)
                {
                    _damt = int.Parse(row[0]["amt"].ToString()) - int.Parse(row1[0]["amt"].ToString());
                    Row["amt"] = int.Parse(Row["amt"].ToString()) + _damt;
                    for (int i = 0; i < row1.Length; i++)
                    {
                        _salamt = _salamt + int.Parse(row1[i]["amt"].ToString());
                    }
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = Row["sal_code"].ToString();
                    DataRow row2 = rq_diff.Rows.Find(_value);
                    if (row2 == null)
                    {
                        DataRow aRow = rq_diff.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["sal_code"] = Row["sal_code"].ToString();
                        aRow["diffamt"] = int.Parse(row[0]["amt"].ToString()) - _salamt;
                        rq_diff.Rows.Add(aRow);
                    }

                }
            }
            foreach (DataRow Row1 in DT_waged.Rows)
            {
                object[] _value = new object[2];
                _value[0] = Row1["nobr"].ToString();
                _value[1] = Row1["sal_code"].ToString();
                DataRow row = DT_wagedc.Rows.Find(_value);
                if (row != null)
                    Row1.Delete();
            }
            DT_waged.AcceptChanges();
            foreach (DataRow Row2 in DT_wageb.Rows)
            {
                object[] _value = new object[2];
                _value[0] = Row2["nobr"].ToString();
                _value[1] = Row2["sal_code"].ToString();
                DataRow row2 = rq_diff.Rows.Find(_value);
                if (row2 != null && int.Parse(Row2["rowcnt"].ToString()) == 0)
                    Row2["amt"] = int.Parse(Row2["amt"].ToString()) + int.Parse(row2["diffamt"].ToString());
                DT_waged.ImportRow(Row2);
            }
            rq_diff = null;
        }

        public static void GetWaged2(DataTable DT_waged, DataTable DT_wageb, DataTable DT_wagedc)
        {
            foreach (DataRow Row in DT_wagedc.Rows)
            {
                int _damt = 0;
                DataRow[] row = DT_waged.Select("nobr='" + Row["nobr"].ToString() + "' and sal_code='" + Row["sal_code"].ToString() + "'");
                DataRow[] row1 = DT_wageb.Select("nobr='" + Row["nobr"].ToString() + "' and sal_code='" + Row["sal_code"].ToString() + "'");
                if (row.Length > 0 && row1.Length > 0)
                {
                    _damt = int.Parse(row[0]["amt"].ToString()) - int.Parse(row1[0]["amt"].ToString());
                    Row["amt"] = int.Parse(Row["amt"].ToString()) + _damt;
                }
            }
            DT_waged.Clear();
            foreach (DataRow Row2 in DT_wageb.Rows)
            {
                DT_waged.ImportRow(Row2);
            }
        }

        public static void Get_ZZ4a1td(DataTable DT_zztatd, DataTable DT_waged, DataTable DT_wageds1, DataTable DT_wageds2, DataTable DT_wagedsz, DataTable DT_zz4at)
        {
            DataColumn[] _key = new DataColumn[3];           
            _key[0] = DT_zztatd.Columns["depts"];
            _key[1] = DT_zztatd.Columns["di"];
            _key[2] = DT_zztatd.Columns["nobr"];
            DT_zztatd.PrimaryKey = _key;
            DataRow[] Srow = DT_waged.Select("", "depts,nobr asc");           
            foreach (DataRow Row in Srow)
            {                
                if (Row["di"].ToString() == "D")
                    Row["di"] = "直";
                else if (Row["di"].ToString() == "I")
                    Row["di"] = "間";
                //string str_salattr = Row["acc_tr"].ToString() + Row["acccd"].ToString().Trim();               
                object[] _value = new object[3];               
                _value[0] = Row["depts"].ToString();
                _value[1] = Row["di"].ToString();
                _value[2] = Row["nobr"].ToString();
                DataRow row = DT_zztatd.Rows.Find(_value);

                if (row != null)
                {
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        if (Row["sal_name"].ToString().Trim() == DT_zz4at.Rows[i]["sal_name"].ToString().Trim())
                        {
                            row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row["amt"].ToString());
                            break;
                        }
                    }
                }
                else
                {
                    object[] _value1 = new object[2];
                    _value1[0] = Row["nobr"].ToString();
                    _value1[1] = Row["depts"].ToString();
                    DataRow row1 = DT_wageds1.Rows.Find(_value1);
                    DataRow row2 = DT_wageds2.Rows.Find(_value1);                    
                    DataRow row5 = DT_wagedsz.Rows.Find(_value1);

                    DataRow aRow = DT_zztatd.NewRow();                   
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["ds_name"] = Row["ds_name"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();                   
                    aRow["di"] = Row["di"].ToString();                                      
                    aRow["pno"] = (Row.IsNull("rate")) ? 1 : decimal.Parse(Row["rate"].ToString());
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        aRow["Fld" + (i + 1)] = 0;
                        if (Row["sal_name"].ToString().Trim() == DT_zz4at.Rows[i]["sal_name"].ToString().Trim())
                            aRow["Fld" + (i + 1)] = int.Parse(Row["amt"].ToString());
                        else if (DT_zz4at.Rows[i]["sal_name"].ToString().Trim() == "應稅薪資")
                        {
                            if (row1 != null) aRow["Fld" + (i + 1)] = int.Parse(row1["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["sal_name"].ToString().Trim() == "應發薪資")
                        {
                            if (row2 != null) aRow["Fld" + (i + 1)] = int.Parse(row2["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["sal_name"].ToString().Trim() == "實發薪資")
                        {
                            if (row5 != null) aRow["Fld" + (i + 1)] = int.Parse(row5["amt"].ToString());
                        }
                    }
                    DT_zztatd.Rows.Add(aRow);
                }
            }
            
        }

        public static void Get_ZZ4a1td4(DataTable DT_zztatd, DataTable DT_zz4at)
        {
            DataTable rq_zztatd = new DataTable();
            rq_zztatd.Merge(DT_zztatd);
            DT_zztatd.Clear();           
            DataColumn[] _key;
            _key = new DataColumn[2];
            _key[0] = DT_zztatd.Columns["depts"];
            _key[1] = DT_zztatd.Columns["di"];
            DT_zztatd.PrimaryKey = _key;
            DataRow[] RSow = rq_zztatd.Select("", "depts asc");
            foreach (DataRow Row in RSow)
            {
               
                object[] _value;
                DataRow row = null;
                _value = new object[2];
                _value[0] = Row["depts"].ToString();
                _value[1] = Row["di"].ToString();
                row = DT_zztatd.Rows.Find(_value);
                if (row != null)
                {
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row["Fld" + (i + 1)].ToString());
                    }
                    row["pno"] = decimal.Parse(row["pno"].ToString()) + decimal.Parse(Row["pno"].ToString());
                }
                else
                {
                    DataRow aRow = DT_zztatd.NewRow();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["ds_name"] = Row["ds_name"].ToString();
                    aRow["pno"] = decimal.Parse(Row["pno"].ToString());
                    aRow["nobr"] = "";
                    aRow["name_c"] = "";
                    aRow["di"] = Row["di"].ToString();               
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        aRow["Fld" + (i + 1)] = int.Parse(Row["Fld" + (i + 1)].ToString());
                    }
                    DT_zztatd.Rows.Add(aRow);
                }
            }
        }

        public static void ExPort(DataTable DT_4a1td, DataTable DT_4a1ta, string FileName, string reporttype)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            if (reporttype == "1")
            {
                ExporDt.Columns.Add("直間接", typeof(string));
                ExporDt.Columns.Add("人數", typeof(decimal));
            }
            else
            {
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("直間接", typeof(string));
            }
            for (int i = 0; i < DT_4a1ta.Columns.Count; i++)
            {
                if (DT_4a1ta.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_4a1ta.Rows[0][i].ToString().Trim(), typeof(int));
                }
                else
                    break;
            }
            foreach (DataRow Row01 in DT_4a1td.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["deptS"].ToString();
                aRow["部門名稱"] = Row01["dS_name"].ToString();
                if (reporttype == "1")
                {
                    aRow["直間接"] = Row01["di"].ToString();
                    aRow["人數"] = decimal.Parse(Row01["pno"].ToString());
                }
                else
                {
                    aRow["員工編號"] = Row01["nobr"].ToString();
                    aRow["員工姓名"] = Row01["name_c"].ToString();
                    aRow["直間接"] = Row01["di"].ToString();
                }
                for (int i = 0; i < DT_4a1ta.Columns.Count; i++)
                {
                    if (DT_4a1ta.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_4a1ta.Rows[0][i].ToString().Trim()] = int.Parse(Row01["Fld" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }
    }
}
