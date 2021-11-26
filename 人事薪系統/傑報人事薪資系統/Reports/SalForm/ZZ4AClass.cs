using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBHR.Reports.SalForm
{
    class ZZ4AClass
    {
        public static void GetZz4at(DataTable DT_zz4ata,DataTable DT_zz4at, DataTable DT_waged)
        {
            DataTable rq_zz4ata = new DataTable();
            rq_zz4ata.Columns.Add("salattr", typeof(string));
            rq_zz4ata.Columns.Add("sal_name", typeof(string));
            rq_zz4ata.PrimaryKey = new DataColumn[] { rq_zz4ata.Columns["salattr"] };

            foreach (DataRow Row in DT_waged.Rows)
            {
                string str_salattr = Row["acc_tr"].ToString() + Row["acccd"].ToString().Trim();
                DataRow row = rq_zz4ata.Rows.Find(str_salattr);
                if (row == null)
                {
                    DataRow [] row1 = rq_zz4ata.Select("sal_name='" + Row["sal_name"].ToString().Trim() + "'");                    
                    DataRow aRow = rq_zz4ata.NewRow();
                    aRow["salattr"] = str_salattr;
                    aRow["sal_name"] = (row1.Length > 0) ? Row["sal_name"].ToString().Trim() + 1 : Row["sal_name"].ToString().Trim();
                    rq_zz4ata.Rows.Add(aRow);
                }
            }

            DataRow aRow1 = rq_zz4ata.NewRow();
            aRow1["salattr"] = "AZZZZ";
            aRow1["sal_name"] = "薪資總額";
            rq_zz4ata.Rows.Add(aRow1);

            DataRow aRow2 = rq_zz4ata.NewRow();
            aRow2["salattr"] = "BZZZZ";
            aRow2["sal_name"] = "代扣總額";
            rq_zz4ata.Rows.Add(aRow2);

            DataRow aRow3 = rq_zz4ata.NewRow();
            aRow3["salattr"] = "CZZZZ";
            aRow3["sal_name"] = "應發總額";
            rq_zz4ata.Rows.Add(aRow3);

            DataRow aRow4 = rq_zz4ata.NewRow();
            aRow4["salattr"] = "DZZZZ";
            aRow4["sal_name"] = "其他總計";
            rq_zz4ata.Rows.Add(aRow4);

            DataRow aRow5 = rq_zz4ata.NewRow();
            aRow5["salattr"] = "EZZZZ";
            aRow5["sal_name"] = "實發總額";
            rq_zz4ata.Rows.Add(aRow5);
            
            DataRow[] Orow = rq_zz4ata.Select("", "salattr asc");            
            foreach (DataRow Row1 in Orow)
            {
                DataRow aRow6 = DT_zz4at.NewRow();
                aRow6["salattr"] = Row1["salattr"].ToString();
                aRow6["sal_name"] = Row1["sal_name"].ToString().Trim();
                DT_zz4at.Rows.Add(aRow6);
            }

            DataRow aRow7 = DT_zz4ata.NewRow();
            for (int i = 0; i < DT_zz4at.Rows.Count; i++)
            {
                aRow7["Fld" + (i + 1)] = DT_zz4at.Rows[i]["sal_name"].ToString();
            }
            DT_zz4ata.Rows.Add(aRow7);
        }

        public static void GetWageds1(DataTable DT_wageds1, DataTable DT_waged)
        {
            DT_wageds1.PrimaryKey = new DataColumn[] { DT_wageds1.Columns["nobr"], DT_wageds1.Columns["dept"] };
           
            DataRow[] Srow = DT_waged.Select("acc_tr='A'");
            foreach (DataRow Row in Srow)
            {  
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["dept"].ToString();
                DataRow row = DT_wageds1.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wageds1.Rows.Add(aRow);
                }
            }
        }

        public static void GetWageds2(DataTable DT_wageds2, DataTable DT_waged)
        {
            DT_wageds2.PrimaryKey = new DataColumn[] { DT_wageds2.Columns["nobr"], DT_wageds2.Columns["dept"] };
            DataRow[] Srow = DT_waged.Select("acc_tr='B'");
            foreach (DataRow Row in Srow)
            {
                int _amt = int.Parse(Row["amt"].ToString());               
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["dept"].ToString();
                DataRow row = DT_wageds2.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + _amt;
                else
                {
                    DataRow aRow = DT_wageds2.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["amt"] = _amt;
                    DT_wageds2.Rows.Add(aRow);
                }
            }
        }

        public static void GetWageds3(DataTable DT_wageds3, DataTable DT_waged)
        {
            DT_wageds3.PrimaryKey = new DataColumn[] { DT_wageds3.Columns["nobr"], DT_wageds3.Columns["dept"] };
            DataRow[] Srow = DT_waged.Select("acc_tr<='B'");
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["dept"].ToString();
                DataRow row = DT_wageds3.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wageds3.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wageds3.Rows.Add(aRow);
                }
            }
        }

        public static void GetWageds4(DataTable DT_wageds4, DataTable DT_waged)
        {
            DT_wageds4.PrimaryKey = new DataColumn[] { DT_wageds4.Columns["nobr"], DT_wageds4.Columns["dept"] };
            DataRow[] Srow = DT_waged.Select("acc_tr='D'");
            foreach (DataRow Row in Srow)
            {
                int _amt = int.Parse(Row["amt"].ToString());               
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["dept"].ToString();
                DataRow row = DT_wageds4.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + _amt;
                else
                {
                    DataRow aRow = DT_wageds4.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["amt"] = _amt;
                    DT_wageds4.Rows.Add(aRow);
                }
            }
        }

        public static void GetWagedsz(DataTable DT_wagedsz, DataTable DT_waged)
        {
            DT_wagedsz.PrimaryKey = new DataColumn[] { DT_wagedsz.Columns["nobr"], DT_wagedsz.Columns["dept"] };
            foreach (DataRow Row in DT_waged.Rows)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["dept"].ToString();
                DataRow row = DT_wagedsz.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wagedsz.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wagedsz.Rows.Add(aRow);
                }
            }
        }

        public static void GetWagebt(DataTable DT_wagebt, DataTable DT_waged)
        {
            DT_wagebt.PrimaryKey = new DataColumn[] { DT_wagebt.Columns["comp"],DT_wagebt.Columns["nobr"] };
            DataRow[] Srow = DT_waged.Select("salattr <='F'");
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[2];
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["nobr"].ToString();
                DataRow row = DT_wagebt.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wagebt.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wagebt.Rows.Add(aRow);
                }
            }
        }

        public static void GetWagetax(DataTable DT_wagetax, DataTable DT_waged)
        {
            DT_wagetax.PrimaryKey = new DataColumn[] { DT_wagetax.Columns["comp"], DT_wagetax.Columns["nobr"] };
            DataRow[] Srow = DT_waged.Select("sal_code ='N04' and amt <> 0");
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[2];
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["nobr"].ToString();
                DataRow row = DT_wagetax.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wagetax.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wagetax.Rows.Add(aRow);
                }
            }
        }

        public static void GetWage7(DataTable DT_wage7, DataTable DT_wagetax, DataTable DT_wagebt)
        {            
            foreach (DataRow Row in DT_wagebt.Rows)
            {
                DataRow row = DT_wage7.Rows.Find(Row["comp"].ToString());
                object[] _value = new object[2];
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["nobr"].ToString();
                DataRow row1 = DT_wagetax.Rows.Find(_value);
                if (row1 != null)
                {
                    if (row != null)
                    {
                        row["amt1"] = int.Parse(row["amt1"].ToString()) + int.Parse(Row["amt"].ToString());
                        row["no1"] = int.Parse(row["no1"].ToString()) + 1;
                    }
                    else
                    {
                        DataRow aRow = DT_wage7.NewRow();
                        aRow["comp"] = Row["comp"].ToString();
                        aRow["amt1"] = int.Parse(Row["amt"].ToString());
                        aRow["no1"] = 1;
                        aRow["amt2"] = 0;
                        aRow["no2"] = 0;
                        aRow["tax"] = 0;
                        DT_wage7.Rows.Add(aRow);
                    }
                }
            }
        }

        public static void GeTax7(DataTable DT_wagetax, DataTable DT_wage7)
        {
            DataTable rq_tax7 = new DataTable();
            rq_tax7.Columns.Add("comp", typeof(string));
            rq_tax7.Columns.Add("tax", typeof(int));
            rq_tax7.PrimaryKey = new DataColumn[] { rq_tax7.Columns["comp"] };
            
            foreach (DataRow Row in DT_wagetax.Rows)
            {
                DataRow row = rq_tax7.Rows.Find(Row["comp"].ToString());
                if (row != null)
                    row["tax"] = int.Parse(row["tax"].ToString()) + (int.Parse(Row["amt"].ToString()) * (-1));
                else
                {
                    DataRow aRow = rq_tax7.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["tax"] = int.Parse(Row["amt"].ToString()) * (-1);
                    rq_tax7.Rows.Add(aRow);
                }
            }
            
            foreach (DataRow Row1 in DT_wage7.Rows)
            {
                DataRow row = rq_tax7.Rows.Find(Row1["comp"].ToString());
                if (row != null)
                    Row1["tax"] = int.Parse(row["tax"].ToString());
            }
            rq_tax7 = null;
        }

        public static void GeNoWage7(DataTable DT_wagebt, DataTable DT_wagetax, DataTable DT_wage7)
        {
            DataTable rq_nowage7 = new DataTable();
            rq_nowage7.Columns.Add("comp", typeof(string));
            rq_nowage7.Columns.Add("amt2", typeof(int));
            rq_nowage7.Columns.Add("no2", typeof(int));
            rq_nowage7.PrimaryKey = new DataColumn[] { rq_nowage7.Columns["comp"] };
            foreach (DataRow Row in DT_wagebt.Rows)
            {
                object[] _value = new object[2];
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["nobr"].ToString();
                DataRow row = DT_wagetax.Rows.Find(_value);
                if (row == null)
                {
                    DataRow row1 = rq_nowage7.Rows.Find(Row["comp"].ToString());
                    if (row1 != null)
                    {
                        row1["amt2"] = int.Parse(row1["amt2"].ToString()) + int.Parse(Row["amt"].ToString());
                        row1["no2"] = int.Parse(row1["no2"].ToString()) + 1;
                    }
                    else
                    {
                        DataRow aRow = rq_nowage7.NewRow();
                        aRow["comp"] = Row["comp"].ToString();
                        aRow["amt2"] = int.Parse(Row["amt"].ToString());
                        aRow["no2"] = 1;
                        rq_nowage7.Rows.Add(aRow);
                    }
                }
            }            

            foreach (DataRow Row1 in rq_nowage7.Rows)
            {
                DataRow row = DT_wage7.Rows.Find(Row1["comp"].ToString());
                if (row != null)
                {
                    row["amt2"] = int.Parse(row["amt2"].ToString()) + int.Parse(Row1["amt2"].ToString());
                    row["no2"] = int.Parse(row["no2"].ToString()) + int.Parse(Row1["no2"].ToString());
                }
                else
                {
                    DataRow aRow1 = DT_wage7.NewRow();
                    aRow1["comp"] = Row1["comp"].ToString();
                    aRow1["amt1"] = 0;
                    aRow1["no1"] = 0;
                    aRow1["tax"] = 0;
                    aRow1["amt2"] = int.Parse(Row1["amt2"].ToString());
                    aRow1["no2"] = int.Parse(Row1["no2"].ToString());
                    DT_wage7.Rows.Add(aRow1);
                }
            }
            rq_nowage7 = null;
        }


        public static void GeWage7p(DataTable DT_Wage7p, DataTable DT_wage7)
        {
            foreach (DataRow Row in DT_wage7.Rows)
            {
                if (DT_Wage7p.Rows.Count > 0)
                {
                    DT_Wage7p.Rows[0]["amt1"] = int.Parse(DT_Wage7p.Rows[0]["amt1"].ToString()) + int.Parse(Row["amt1"].ToString());
                    DT_Wage7p.Rows[0]["no1"] = int.Parse(DT_Wage7p.Rows[0]["no1"].ToString()) + int.Parse(Row["no1"].ToString());
                    DT_Wage7p.Rows[0]["tax"] = int.Parse(DT_Wage7p.Rows[0]["tax"].ToString()) + int.Parse(Row["tax"].ToString());
                    DT_Wage7p.Rows[0]["amt2"] = int.Parse(DT_Wage7p.Rows[0]["amt2"].ToString()) + int.Parse(Row["amt2"].ToString());
                    DT_Wage7p.Rows[0]["no2"] = int.Parse(DT_Wage7p.Rows[0]["no2"].ToString()) + int.Parse(Row["no2"].ToString());
                }
                else
                {
                    DataRow aRow = DT_Wage7p.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["amt1"] = int.Parse(Row["amt1"].ToString());
                    aRow["no1"] = int.Parse(Row["no1"].ToString());
                    aRow["tax"] = int.Parse(Row["tax"].ToString());
                    aRow["amt2"] = int.Parse(Row["amt2"].ToString());
                    aRow["no2"] = int.Parse(Row["no2"].ToString());
                    DT_Wage7p.Rows.Add(aRow);
                }
            }
        }

        public static void GeWage7p1(DataTable DT_Wage7p, DataTable DT_wage7)
        {            
            foreach (DataRow Row in DT_wage7.Rows)
            {
                DataRow row = DT_Wage7p.Rows.Find(Row["comp"].ToString());
                if (row!=null)
                {
                    row["amt1"] = int.Parse(row["amt1"].ToString()) + int.Parse(Row["amt1"].ToString());
                    row["no1"] = int.Parse(row["no1"].ToString()) + int.Parse(Row["no1"].ToString());
                    row["tax"] = int.Parse(row["tax"].ToString()) + int.Parse(Row["tax"].ToString());
                    row["amt2"] = int.Parse(row["amt2"].ToString()) + int.Parse(Row["amt2"].ToString());
                    row["no2"] = int.Parse(row["no2"].ToString()) + int.Parse(Row["no2"].ToString());
                }
                else
                {
                    DataRow aRow = DT_Wage7p.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["amt1"] = int.Parse(Row["amt1"].ToString());
                    aRow["no1"] = int.Parse(Row["no1"].ToString());
                    aRow["tax"] = int.Parse(Row["tax"].ToString());
                    aRow["amt2"] = int.Parse(Row["amt2"].ToString());
                    aRow["no2"] = int.Parse(Row["no2"].ToString());
                    DT_Wage7p.Rows.Add(aRow);
                }
            }
        }

        public static void Get_ZZ4atd(DataTable DT_zztatd, DataTable DT_waged, DataTable DT_wageds1, DataTable DT_wageds2, DataTable DT_wageds3, DataTable DT_wageds4, DataTable DT_wagedsz, DataTable DT_zz4at)
        {
            DataColumn[] _key = new DataColumn[4];
            _key[0] = DT_zztatd.Columns["comp"];
            _key[1] = DT_zztatd.Columns["dept"];
            _key[2] = DT_zztatd.Columns["di"];
            _key[3] = DT_zztatd.Columns["nobr"];
            DT_zztatd.PrimaryKey = _key;
            DataRow[] Srow = DT_waged.Select("", "comp,dept,nobr asc");
            int j = 0;           
            foreach (DataRow Row in Srow)
            {
                string str_salattr = Row["acc_tr"].ToString() + Row["acccd"].ToString().Trim();
                if (str_salattr == "AH01")
                    j++;
                object[] _value = new object[4];
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["dept"].ToString();
                _value[2] = Row["di"].ToString();
                _value[3] = Row["nobr"].ToString();
                DataRow row = DT_zztatd.Rows.Find(_value);
                                
                if (row != null)
                {
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    { 
                        if (str_salattr == DT_zz4at.Rows[i]["salattr"].ToString())
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
                    _value1[1] = Row["dept"].ToString();                     
                     DataRow row1 = DT_wageds1.Rows.Find(_value1);
                     DataRow row2 = DT_wageds2.Rows.Find(_value1);
                     DataRow row3 = DT_wageds3.Rows.Find(_value1);
                     DataRow row4 = DT_wageds4.Rows.Find(_value1);
                     DataRow row5 = DT_wagedsz.Rows.Find(_value1);                     
                    
                    DataRow aRow = DT_zztatd.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["di"] = Row["di"].ToString();
                    aRow["cash"] = bool.Parse(Row["cash"].ToString());
                    aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                    aRow["account"] = Row["account"].ToString();
                    aRow["pno"] = (Row.IsNull("pno")) ? 0 : decimal.Parse(Row["pno"].ToString());
                    aRow["rate"] = (Row.IsNull("rate")) ? 1 : decimal.Parse(Row["rate"].ToString());
                   
                    for (int i = 0; i < DT_zz4at.Rows.Count;i++ )
                    {
                        aRow["Fld" + (i + 1)] = 0;
                        if (str_salattr == DT_zz4at.Rows[i]["salattr"].ToString())
                            aRow["Fld"+(i + 1)] = int.Parse(Row["amt"].ToString());
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "AZZZZ")
                        {
                            if (row1 != null) aRow["Fld" + (i + 1)] = int.Parse(row1["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "BZZZZ")
                        {
                            if (row2 != null) aRow["Fld" + (i + 1)] = int.Parse(row2["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "CZZZZ")
                        {
                            if (row3 != null) aRow["Fld" + (i + 1)] = int.Parse(row3["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "DZZZZ")
                        {
                            if (row4 != null) aRow["Fld" + (i + 1)] = int.Parse(row4["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "EZZZZ")
                        {
                            if (row5 != null) aRow["Fld" + (i + 1)] = int.Parse(row5["amt"].ToString());
                        }
                    }
                    DT_zztatd.Rows.Add(aRow);
                }
            }
        }

        public static void Get_ZZ4atd5(DataTable DT_zztatd, DataTable DT_waged, DataTable DT_wageds1, DataTable DT_wageds2, DataTable DT_wageds3, DataTable DT_wageds4, DataTable DT_wagedsz, DataTable DT_zz4at, DataTable DT_explab,string reporttype)
        {
            DataColumn[] _key = new DataColumn[4];
            _key[0] = DT_zztatd.Columns["comp"];
            _key[1] = DT_zztatd.Columns["dept"];
            _key[2] = DT_zztatd.Columns["di"];
            _key[3] = DT_zztatd.Columns["nobr"];
            DT_zztatd.PrimaryKey = _key;
            DataRow[] Srow = DT_waged.Select("", "comp,dept,nobr asc");
            int j = 0;
            foreach (DataRow Row in Srow)
            {
                int _amt = int.Parse(Row["amt"].ToString());
                //if (reporttype == "0")
                //{
                //    if (Row["flag"].ToString().Trim() == "-")
                //        _amt = _amt * (-1);
                //}
                string str_salattr = Row["acc_tr"].ToString() + Row["acccd"].ToString().Trim();
                if (str_salattr == "AH01")
                    j++;
                object[] _value = new object[4];
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["dept"].ToString();
                _value[2] = Row["di"].ToString();
                _value[3] = Row["nobr"].ToString();
                DataRow row = DT_zztatd.Rows.Find(_value);

                if (row != null)
                {
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        if (str_salattr == DT_zz4at.Rows[i]["salattr"].ToString())
                        {
                            row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + _amt;
                            break;
                        }
                    }
                }
                else
                {
                    object[] _value1 = new object[2];
                    _value1[0] = Row["nobr"].ToString();
                    _value1[1] = Row["dept"].ToString();
                    DataRow row1 = DT_wageds1.Rows.Find(_value1);
                    DataRow row2 = DT_wageds2.Rows.Find(_value1);
                    DataRow row3 = DT_wageds3.Rows.Find(_value1);
                    DataRow row4 = DT_wageds4.Rows.Find(_value1);
                    DataRow row5 = DT_wagedsz.Rows.Find(_value1);
                    DataRow row6 = DT_explab.Rows.Find(Row["nobr"].ToString());

                    DataRow aRow = DT_zztatd.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["di"] = Row["di"].ToString();
                    aRow["cash"] = bool.Parse(Row["cash"].ToString());
                    aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                    aRow["account"] = Row["account"].ToString();
                    aRow["pno"] = (Row.IsNull("pno")) ? 0 : int.Parse(Row["pno"].ToString());
                    aRow["rate"] = (Row.IsNull("rate")) ? 1 : decimal.Parse(Row["rate"].ToString());
                    if (row6 != null)
                    {
                        aRow["comp_lamt"] = int.Parse(row6["l_amt"].ToString());
                        aRow["comp_hamt"] = int.Parse(row6["h_amt"].ToString());
                        aRow["comp_ramt"] = int.Parse(row6["r_amt"].ToString());
                    }
                    else
                    {
                        aRow["comp_lamt"] = 0;
                        aRow["comp_hamt"] = 0;
                        aRow["comp_ramt"] = 0;
                    }
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        aRow["Fld" + (i + 1)] = 0;
                        if (str_salattr == DT_zz4at.Rows[i]["salattr"].ToString())
                            aRow["Fld" + (i + 1)] = _amt;
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "AZZZZ")
                        {
                            if (row1 != null) aRow["Fld" + (i + 1)] = int.Parse(row1["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "BZZZZ")
                        {
                            if (row2 != null)
                            {
                                aRow["Fld" + (i + 1)] = int.Parse(row2["amt"].ToString());
                            }
                        }
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "CZZZZ")
                        {
                            if (row3 != null) aRow["Fld" + (i + 1)] = int.Parse(row3["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "DZZZZ")
                        {
                            if (row4 != null) aRow["Fld" + (i + 1)] = int.Parse(row4["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "EZZZZ")
                        {
                            if (row5 != null) aRow["Fld" + (i + 1)] = int.Parse(row5["amt"].ToString());
                        }
                    }
                    DT_zztatd.Rows.Add(aRow);
                }
            }
        }

        public static void Get_ZZ4atd4(DataTable DT_zztatd, DataTable DT_waged, DataTable DT_wageds1, DataTable DT_wageds2, DataTable DT_wageds3, DataTable DT_wageds4, DataTable DT_wagedsz, DataTable DT_zz4at,DataTable DT_cost)
        {
            DataColumn[] _key = new DataColumn[4];
            _key[0] = DT_zztatd.Columns["comp"];
            _key[1] = DT_zztatd.Columns["dept"];
            _key[2] = DT_zztatd.Columns["di"];
            _key[3] = DT_zztatd.Columns["nobr"];
            DT_zztatd.PrimaryKey = _key;
            DataRow[] Srow = DT_waged.Select("", "comp,dept,nobr asc");
            int j = 0;
            foreach (DataRow Row in Srow)
            {
                string str_salattr = Row["acc_tr"].ToString() + Row["acccd"].ToString().Trim();
                if (str_salattr == "AH01")
                    j++;
                object[] _value = new object[4];
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["dept"].ToString();
                _value[2] = Row["di"].ToString();
                _value[3] = Row["nobr"].ToString();
                DataRow row = DT_zztatd.Rows.Find(_value);

                if (row != null)
                {
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        if (str_salattr == DT_zz4at.Rows[i]["salattr"].ToString())
                        {
                            row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row["amt"].ToString());
                            break;
                        }
                    }
                }
                else
                {
                    DataRow row1 = DT_wageds1.Rows.Find(Row["nobr"].ToString());
                    DataRow row2 = DT_wageds2.Rows.Find(Row["nobr"].ToString());
                    DataRow row3 = DT_wageds3.Rows.Find(Row["nobr"].ToString());
                    DataRow row4 = DT_wageds4.Rows.Find(Row["nobr"].ToString());
                    DataRow row5 = DT_wagedsz.Rows.Find(Row["nobr"].ToString());

                    DataRow aRow = DT_zztatd.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["di"] = Row["di"].ToString();
                    aRow["cash"] = bool.Parse(Row["cash"].ToString());
                    aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                    aRow["account"] = Row["account"].ToString();
                    aRow["pno"] = (Row.IsNull("pno")) ? 0 : int.Parse(Row["pno"].ToString());
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        aRow["Fld" + (i + 1)] = 0;
                        if (str_salattr == DT_zz4at.Rows[i]["salattr"].ToString())
                            aRow["Fld" + (i + 1)] = int.Parse(Row["amt"].ToString());
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "AZZZZ")
                        {
                            if (row1 != null) aRow["Fld" + (i + 1)] = int.Parse(row1["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "BZZZZ")
                        {
                            if (row2 != null) aRow["Fld" + (i + 1)] = int.Parse(row2["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "CZZZZ")
                        {
                            if (row3 != null) aRow["Fld" + (i + 1)] = int.Parse(row3["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "DZZZZ")
                        {
                            if (row4 != null) aRow["Fld" + (i + 1)] = int.Parse(row4["amt"].ToString());
                        }
                        else if (DT_zz4at.Rows[i]["salattr"].ToString() == "EZZZZ")
                        {
                            if (row5 != null) aRow["Fld" + (i + 1)] = int.Parse(row5["amt"].ToString());
                        }
                    }
                    DT_zztatd.Rows.Add(aRow);
                }
            }
        }


        public static void Get_ZZ4atd1(DataTable DT_zztatd, DataTable DT_zztatd1, DataTable DT_zz4at, DataTable DT_wage7, string reporttype)
        {
            DataColumn[] _key;
            if (reporttype == "0")
            {
                _key = new DataColumn[2];
                _key[0] = DT_zztatd1.Columns["comp"];
                _key[1] = DT_zztatd1.Columns["dept"];
                DT_zztatd1.PrimaryKey = _key;
            }
            else if (reporttype == "5")
            {
                _key = new DataColumn[1];
                _key[0] = DT_zztatd1.Columns["comp"];                
                DT_zztatd1.PrimaryKey = _key;
            }
            string strcomp1 = "";
            DataRow[] Srow = DT_zztatd.Select("", "comp,dept asc");
            foreach (DataRow Row in Srow)
            {
                object[] _value = null;
                if (reporttype == "0")
                {
                    _value = new object[2];
                    _value[0] = Row["comp"].ToString();
                    _value[1] = Row["dept"].ToString();
                }
                else if (reporttype == "5")
                {
                    _value = new object[1];
                    _value[0] = Row["comp"].ToString();
                }
                DataRow row = DT_zztatd1.Rows.Find(_value);
                string strcomp = Row["comp"].ToString();
                if (row != null)
                {
                    row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                    row["comp_lamt"] = decimal.Parse(row["comp_lamt"].ToString()) + int.Parse(Row["comp_lamt"].ToString());
                    row["comp_hamt"] = decimal.Parse(row["comp_hamt"].ToString()) + int.Parse(Row["comp_hamt"].ToString());
                    row["comp_ramt"] = decimal.Parse(row["comp_ramt"].ToString()) + int.Parse(Row["comp_ramt"].ToString());
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row["Fld" + (i + 1)].ToString());
                    }
                }
                else
                {
                    DataRow row6 = DT_wage7.Rows.Find(Row["comp"].ToString());
                    DataRow aRow = DT_zztatd1.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["account"] = Row["account"].ToString();
                    aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["comp_lamt"] = int.Parse(Row["comp_lamt"].ToString());
                    aRow["comp_hamt"] = int.Parse(Row["comp_hamt"].ToString());
                    aRow["comp_ramt"] = int.Parse(Row["comp_ramt"].ToString());
                    if (reporttype == "0")
                    {
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                    }
                    else if (reporttype == "5")
                    {
                        aRow["dept"] = "";
                        aRow["d_name"] = "";
                    }
                    aRow["cnt"] = 1;
                    if (row6 != null && strcomp!=strcomp1)
                    {
                        aRow["amt1"] = int.Parse(row6["amt1"].ToString());
                        aRow["amt2"] = int.Parse(row6["amt2"].ToString());
                        aRow["no1"] = int.Parse(row6["no1"].ToString());
                        aRow["no2"] = int.Parse(row6["no2"].ToString());
                        aRow["tax"] = int.Parse(row6["tax"].ToString());
                    }
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        aRow["Fld" + (i + 1)] = decimal.Parse(Row["Fld" + (i + 1)].ToString());
                    }
                    DT_zztatd1.Rows.Add(aRow);
                    strcomp1 = Row["comp"].ToString();
                }
            }

            foreach (DataRow Row1 in DT_zztatd1.Rows)
            {
                for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                {
                    if (int.Parse(Row1["Fld" + (i + 1)].ToString()) < 0)
                        Row1["Fld" + (i + 1)] = int.Parse(Row1["Fld" + (i + 1)].ToString()) * (-1);
                }
            }

            //if (reporttype == "0")
            //{
            //    foreach (DataRow Row in DT_zztatd1.Rows)
            //    {
            //        for (int i = 0; i < DT_zz4at.Rows.Count; i++)
            //        {
            //            if (DT_zz4at.Rows[i]["salattr"].ToString() == "BZZZZ")
            //            {
            //                if (int.Parse(Row["Fld" + (i + 1)].ToString()) < 0)
            //                    Row["Fld" + (i + 1)] = int.Parse(Row["Fld" + (i + 1)].ToString()) * (-1);
            //            }
            //        }
            //    }
            //}

        }

        public static void Get_ZZ4atd2(DataTable DT_zztatd, DataTable DT_zztatd2, DataTable DT_zz4at,string reporttype)
        {
            DataColumn[] _key;
            if (reporttype == "1")
            {
                _key = new DataColumn[2];
                _key[0] = DT_zztatd2.Columns["dept"];
                _key[1] = DT_zztatd2.Columns["mark"];
                DT_zztatd2.PrimaryKey = _key;                 
            }
            else if (reporttype == "4")
            {
                _key = new DataColumn[1];
                _key[0] = DT_zztatd2.Columns["dept"];
                DT_zztatd2.PrimaryKey = _key; 
            }
            
            DataRow[] Srow = DT_zztatd.Select("", "comp,dept asc");
            
            foreach (DataRow Row in Srow)
            {
                string mark = "";
                object[] _value ;
                DataRow row = null;
                if (reporttype == "1")
                {
                    if (Row["di"].ToString().Trim() == "I" && !bool.Parse(Row["count_ma"].ToString()))
                        mark = "間接人員";
                    else if (Row["di"].ToString().Trim() == "D" && !bool.Parse(Row["count_ma"].ToString()))
                        mark = "直接人員";
                    else if (bool.Parse(Row["count_ma"].ToString()))
                        mark = "外籍勞工";
                    _value = new object[2];
                    _value[0] = Row["dept"].ToString();
                    _value[1] = mark;
                    row = DT_zztatd2.Rows.Find(_value);
                }
                else if (reporttype == "4")
                    row = DT_zztatd2.Rows.Find(Row["dept"].ToString());
                
                if (row != null)
                {
                    row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row["Fld" + (i + 1)].ToString());
                    }
                }
                else
                {                    
                    DataRow aRow = DT_zztatd2.NewRow();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["mark"] = mark;
                    aRow["cnt"] = 1;                    
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        aRow["Fld" + (i + 1)] = int.Parse(Row["Fld" + (i + 1)].ToString());
                    }
                    DT_zztatd2.Rows.Add(aRow);
                   
                }
            }
        }

        public static void Get_ZZ4atd3(DataTable DT_zztatd, DataTable DT_zztatd1,DataTable DT_zztatd3, DataTable DT_zz4at, DataTable DT_wage7)
        {
            DataColumn[] _key = new DataColumn[1];            
            _key[0] = DT_zztatd1.Columns["comp"];
            DT_zztatd1.PrimaryKey = _key;
            
            string strcomp1 = "";
            DataRow[] Srow = DT_zztatd.Select("", "comp,dept asc");            
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[1];
                _value[0] = Row["comp"].ToString();
                DataRow row = DT_zztatd1.Rows.Find(_value);
                string strcomp = Row["comp"].ToString();
                if (row != null)
                {
                    row["cnt"] = int.Parse(row["cnt"].ToString()) + 1;
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row["Fld" + (i + 1)].ToString());
                    }
                }
                else
                {
                    DataRow row6 = DT_wage7.Rows.Find(Row["comp"].ToString());
                    DataRow aRow = DT_zztatd1.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["account"] = Row["account"].ToString();
                    aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["dept"] = "";
                    aRow["d_name"] = "";                    
                    aRow["cnt"] = 1;
                    if (row6 != null && strcomp != strcomp1)
                    {
                        aRow["amt1"] = int.Parse(row6["amt1"].ToString());
                        aRow["amt2"] = int.Parse(row6["amt2"].ToString());
                        aRow["no1"] = int.Parse(row6["no1"].ToString());
                        aRow["no2"] = int.Parse(row6["no2"].ToString());
                        aRow["tax"] = int.Parse(row6["tax"].ToString());
                    }
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        aRow["Fld" + (i + 1)] = int.Parse(Row["Fld" + (i + 1)].ToString());
                    }
                    DT_zztatd1.Rows.Add(aRow);
                    strcomp1 = Row["comp"].ToString();
                }

                int _count = 13;
                if (DT_zz4at.Rows.Count < 13)
                    _count = DT_zz4at.Rows.Count;
                if (DT_zztatd3.Rows.Count > 0)
                {
                    if (bool.Parse(Row["cash"].ToString()))
                    {
                        for (int i = 1; i < _count; i++)
                        {
                            DT_zztatd3.Rows[0]["CFld" + i] = int.Parse(DT_zztatd3.Rows[0]["CFld" + i].ToString()) + int.Parse(Row["Fld" + i].ToString());
                        }
                    }
                    else
                    {
                        for (int i = 1; i < _count; i++)
                        {
                            DT_zztatd3.Rows[0]["TFld" + i] = int.Parse(DT_zztatd3.Rows[0]["TFld" + i].ToString()) + int.Parse(Row["Fld" + i].ToString());
                        }
                    }
                }
                else
                {
                    DataRow aRow1 = DT_zztatd3.NewRow();
                    if (bool.Parse(Row["cash"].ToString()))
                    {
                        for (int i = 1; i < _count; i++)
                        {
                            aRow1["TFld" + i] = 0;
                            aRow1["CFld" + i] = int.Parse(Row["Fld" + i].ToString());
                        }
                    }
                    else
                    {
                        for (int i = 1; i < _count; i++)
                        {
                            aRow1["TFld" + i] = int.Parse(Row["Fld" + i].ToString());
                            aRow1["CFld" + i] = 0;
                        }
                    }
                    DT_zztatd3.Rows.Add(aRow1);
                }
            }
        }

        public static void GeWagedb(DataTable DT_cost, DataTable DT_waged, DataTable DT_wagedb)
        {
            int _rowcnt = 0; string str_nobr1 = "";
            foreach (DataRow Row in DT_waged.Rows)
            {
                if (Row["nobr"].ToString() == str_nobr1)
                    _rowcnt = 1;
                else
                    _rowcnt = 0;
                DataRow[] row = DT_cost.Select("nobr='" + Row["nobr"].ToString() + "'");
                for (int i = 0; i < row.Length; i++)
                {
                    DataRow aRow = DT_wagedb.NewRow();
                    aRow["nobr"] = row[i]["nobr"].ToString();
                    aRow["sal_code"] = row[i]["sal_code"].ToString();
                    aRow["cash"] = bool.Parse(row[i]["cash"].ToString());
                    aRow["adate"] = DateTime.Parse(row[i]["adate"].ToString());
                    aRow["name_c"] = row[i]["name_c"].ToString();
                    aRow["name_e"] = row[i]["name_e"].ToString();
                    aRow["di"] = row[i]["di"].ToString();
                    aRow["dept"] = Row["depts"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["comp"] = row[i]["comp"].ToString();
                    aRow["compname"] = row[i]["compname"].ToString();
                    aRow["count_ma"] = bool.Parse(row[i]["count_ma"].ToString());
                    aRow["account"] = row[i]["account"].ToString();
                    aRow["sal_name"] = row[i]["sal_name"].ToString();
                    aRow["flag"] = row[i]["flag"].ToString();
                    aRow["acc_tr"] = row[i]["acc_tr"].ToString();
                    aRow["salattr"] = row[i]["salattr"].ToString();
                    aRow["acccd"] = row[i]["acccd"].ToString();
                    aRow["amt"] = Math.Round(decimal.Parse(row[i]["amt"].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero);
                    aRow["pno"] = decimal.Parse(row[i]["pno"].ToString());
                    aRow["rate"] = decimal.Parse(Row["rate"].ToString());
                                       
                    DT_wagedb.Rows.Add(aRow);
                }                
                str_nobr1 = Row["nobr"].ToString();
                
            }
        }

        public static void GeWagedN(DataTable DT_cost, DataTable DT_waged, DataTable DT_wagedb)
        {
            int _rowcnt = 0; string str_nobr1 = "";
            foreach (DataRow Row in DT_waged.Select("","nobr asc"))
            {
                decimal _amt = decimal.Parse(Row["amt"].ToString());
                if (Row["nobr"].ToString() == str_nobr1)
                    _rowcnt = 1;
                else
                    _rowcnt = 0;
                DataRow[] row = DT_cost.Select("nobr='" + Row["nobr"].ToString() + "'");
                if (row.Length > 0)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        DataRow aRow = DT_wagedb.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["sal_code"] = Row["sal_code"].ToString();
                        aRow["cash"] = bool.Parse(Row["cash"].ToString());
                        aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["name_e"] = Row["name_e"].ToString();
                        aRow["di"] = Row["di"].ToString();
                        aRow["dept"] = row[i]["depts"].ToString();
                        aRow["d_name"] = row[i]["d_name"].ToString();
                        aRow["comp"] = Row["comp"].ToString();
                        aRow["compname"] = Row["compname"].ToString();
                        aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                        aRow["account"] = Row["account"].ToString();
                        aRow["sal_name"] = Row["sal_name"].ToString();
                        aRow["flag"] = Row["flag"].ToString();
                        aRow["acc_tr"] = Row["acc_tr"].ToString();
                        aRow["salattr"] = Row["salattr"].ToString();
                        aRow["acccd"] = Row["acccd"].ToString();                        
                        aRow["rate"] = decimal.Parse(row[i]["rate"].ToString());
                        aRow["pno"] = (str_nobr1 == Row["nobr"].ToString()) ? 0 : decimal.Parse(row[i]["rate"].ToString());
                        if (i == row.Length - 1)
                            aRow["amt"] = _amt;
                        else
                        {
                            aRow["amt"] = Math.Round(decimal.Parse(Row["amt"].ToString()) * decimal.Parse(row[i]["rate"].ToString()), MidpointRounding.AwayFromZero);
                            _amt -= Math.Round(decimal.Parse(Row["amt"].ToString()) * decimal.Parse(row[i]["rate"].ToString()), MidpointRounding.AwayFromZero);
                        }
                        DT_wagedb.Rows.Add(aRow);
                    }
                }
                else
                {
                    DataRow aRow = DT_wagedb.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["sal_code"] = Row["sal_code"].ToString();
                    aRow["cash"] = bool.Parse(Row["cash"].ToString());
                    aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["di"] = Row["di"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["count_ma"] = bool.Parse(Row["count_ma"].ToString());
                    aRow["account"] = Row["account"].ToString();
                    aRow["sal_name"] = Row["sal_name"].ToString();
                    aRow["flag"] = Row["flag"].ToString();
                    aRow["acc_tr"] = Row["acc_tr"].ToString();
                    aRow["salattr"] = Row["salattr"].ToString();
                    aRow["acccd"] = Row["acccd"].ToString();
                    aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    aRow["rate"] = 1;
                    aRow["pno"] = 1;                    
                    DT_wagedb.Rows.Add(aRow);
                }
                str_nobr1 = Row["nobr"].ToString();

            }
        }

        public static void GeWagedc(DataTable DT_wageb, DataTable DT_wagedc)
        {
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
                if (row.Length > 0 && row1.Length >0)
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

        public static void GetWageds1a(DataTable DT_wageds1a, DataTable DT_waged)
        {
            DT_wageds1a.PrimaryKey = new DataColumn[] { DT_wageds1a.Columns["nobr"], DT_wageds1a.Columns["dept"] };
            DataRow[] Srow1 = DT_waged.Select("acc_tr='A'");
            foreach (DataRow Row1 in Srow1)
            {
                object[] _value = new object[2];
                _value[0] = Row1["nobr"].ToString();
                _value[1] = Row1["dept"].ToString();
                DataRow row = DT_wageds1a.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row1["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wageds1a.NewRow();
                    aRow["nobr"] = Row1["nobr"].ToString();
                    aRow["dept"] = Row1["dept"].ToString();
                    aRow["amt"] = int.Parse(Row1["amt"].ToString());
                    DT_wageds1a.Rows.Add(aRow);
                }
            }            
        }       

        public static void GetWageds2a(DataTable DT_wageds2a, DataTable DT_waged)
        {
            DT_wageds2a.PrimaryKey = new DataColumn[] { DT_wageds2a.Columns["nobr"], DT_wageds2a.Columns["dept"] };
            DataRow[] Srow = DT_waged.Select("acc_tr='B'");
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["dept"].ToString();
                DataRow row = DT_wageds2a.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wageds2a.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wageds2a.Rows.Add(aRow);
                }
            }
        }

        public static void GetWageds3a(DataTable DT_wageds3a, DataTable DT_waged)
        {
            DT_wageds3a.PrimaryKey = new DataColumn[] { DT_wageds3a.Columns["nobr"], DT_wageds3a.Columns["dept"] };
            DataRow[] Srow = DT_waged.Select("acc_tr<='B'");
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["dept"].ToString();
                DataRow row = DT_wageds3a.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wageds3a.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wageds3a.Rows.Add(aRow);
                }
            }
        }

        public static void GetWageds4a(DataTable DT_wageds4a, DataTable DT_waged)
        {
            DT_wageds4a.PrimaryKey = new DataColumn[] { DT_wageds4a.Columns["nobr"], DT_wageds4a.Columns["dept"] };
            DataRow[] Srow = DT_waged.Select("acc_tr='D'");
            foreach (DataRow Row in Srow)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["dept"].ToString();
                DataRow row = DT_wageds4a.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wageds4a.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wageds4a.Rows.Add(aRow);
                }
            }
        }

        public static void GetWagedsza(DataTable DT_wagedsza, DataTable DT_waged)
        {
            DT_wagedsza.PrimaryKey = new DataColumn[] { DT_wagedsza.Columns["nobr"], DT_wagedsza.Columns["dept"] };
            foreach (DataRow Row in DT_waged.Rows)
            {
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["dept"].ToString();
                DataRow row = DT_wagedsza.Rows.Find(_value);
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = DT_wagedsza.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    DT_wagedsza.Rows.Add(aRow);
                }
            }
        }

        public static void Get_ZZ4atd4(DataTable DT_zztatd, DataTable DT_zztatd4, DataTable DT_zz4at, string reporttype)
        {
            string str_di="";            
            DataColumn[] _key;
            _key = new DataColumn[2];
            _key[0] = DT_zztatd4.Columns["dept"];
            if (reporttype == "2")
            {
                _key[1] = DT_zztatd4.Columns["di"];               
            }
            else
            { 
                _key[1] = DT_zztatd4.Columns["nobr"];
            }
            DT_zztatd4.PrimaryKey = _key;
            foreach (DataRow Row in DT_zztatd.Rows)
            {
                if (Row["di"].ToString() == "D")
                    str_di = "直";
                else if (Row["di"].ToString() == "I")
                    str_di = "間";
                object[] _value;
                DataRow row = null;
                if (reporttype == "2")
                {
                    _value = new object[2];
                    _value[0] = Row["dept"].ToString();
                    _value[1] = str_di;
                    row = DT_zztatd4.Rows.Find(_value);
                }
                else
                {
                    _value = new object[2];
                    _value[0] = Row["dept"].ToString(); 
                    _value[1] = Row["nobr"].ToString();                   
                    row = DT_zztatd4.Rows.Find(_value);
                }
                if (row != null)
                {
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + int.Parse(Row["Fld" + (i + 1)].ToString());
                        //if (DT_zz4at.Rows[i]["salattr"].ToString() == "AZZZZ")
                        //    row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + Math.Round(decimal.Parse(Row["Fld" + (i + 1)].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero);
                        //else if (DT_zz4at.Rows[i]["salattr"].ToString() == "BZZZZ")
                        //    row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + Math.Round(decimal.Parse(Row["Fld" + (i + 1)].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero);
                        //else if (DT_zz4at.Rows[i]["salattr"].ToString() == "CZZZZ")
                        //    row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + Math.Round(decimal.Parse(Row["Fld" + (i + 1)].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero);
                        //else if (DT_zz4at.Rows[i]["salattr"].ToString() == "DZZZZ")
                        //    row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + Math.Round(decimal.Parse(Row["Fld" + (i + 1)].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero);
                        //else if (DT_zz4at.Rows[i]["salattr"].ToString() == "EZZZZ")
                        //    row["Fld" + (i + 1)] = int.Parse(row["Fld" + (i + 1)].ToString()) + Math.Round(decimal.Parse(Row["Fld" + (i + 1)].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero); 
                    }
                    row["pno"] = decimal.Parse(row["pno"].ToString()) + decimal.Parse(Row["pno"].ToString());
                }
                else
                {                    
                    DataRow aRow = DT_zztatd4.NewRow();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["pno"] = decimal.Parse(Row["pno"].ToString());
                    aRow["rate"] = decimal.Parse(Row["rate"].ToString());
                    if (reporttype == "2")
                    {
                        aRow["nobr"] = "";
                        aRow["name_c"] = "";
                        aRow["name_e"] = "";
                        aRow["di"] = str_di;                       
                    }
                    else
                    {
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["name_e"] = Row["name_e"].ToString();
                    }                    
                    for (int i = 0; i < DT_zz4at.Rows.Count; i++)
                    {
                        aRow["Fld" + (i + 1)] = int.Parse(Row["Fld" + (i + 1)].ToString());
                        //if (DT_zz4at.Rows[i]["salattr"].ToString()=="AZZZZ")
                        //    aRow["Fld" + (i + 1)] = Math.Round(decimal.Parse(Row["Fld" + (i + 1)].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero);
                        //else if (DT_zz4at.Rows[i]["salattr"].ToString() == "BZZZZ")
                        //    aRow["Fld" + (i + 1)] = Math.Round(decimal.Parse(Row["Fld" + (i + 1)].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero);
                        //else if (DT_zz4at.Rows[i]["salattr"].ToString() == "CZZZZ")
                        //    aRow["Fld" + (i + 1)] = Math.Round(decimal.Parse(Row["Fld" + (i + 1)].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero);
                        //else if (DT_zz4at.Rows[i]["salattr"].ToString() == "DZZZZ")
                        //    aRow["Fld" + (i + 1)] = Math.Round(decimal.Parse(Row["Fld" + (i + 1)].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero);
                        //else if (DT_zz4at.Rows[i]["salattr"].ToString() == "EZZZZ")
                        //    aRow["Fld" + (i + 1)] = Math.Round(decimal.Parse(Row["Fld" + (i + 1)].ToString()) * decimal.Parse(Row["rate"].ToString()), MidpointRounding.AwayFromZero); 
                    }
                    DT_zztatd4.Rows.Add(aRow);
                }
            }
        }

        public static void ExPort1(DataTable DT_4atd1, DataTable DT_4ata, string FileName,string reporttype)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("公司別", typeof(string));
            ExporDt.Columns.Add("公司名稱", typeof(string));
            if (reporttype == "0")
            {
                ExporDt.Columns.Add("部門代碼", typeof(string));
                ExporDt.Columns.Add("部門名稱", typeof(string));                
            }
            ExporDt.Columns.Add("人數", typeof(int));
            if (reporttype == "0")
            {
                ExporDt.Columns.Add("雇主勞保負擔", typeof(int));
                ExporDt.Columns.Add("雇主健保負擔", typeof(int));
                ExporDt.Columns.Add("雇主勞退負擔", typeof(int));
            }
            for (int i = 0; i < DT_4ata.Columns.Count; i++)
            {
                if (DT_4ata.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_4ata.Rows[0][i].ToString().Trim(), typeof(int));
                }
                else
                    break;
            }
            foreach (DataRow Row01 in DT_4atd1.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["公司別"] = Row01["comp"].ToString();
                aRow["公司名稱"] = Row01["compname"].ToString();
                if (reporttype == "0")
                {
                    aRow["部門代碼"] = Row01["dept"].ToString();
                    aRow["部門名稱"] = Row01["d_name"].ToString();
                }
                aRow["人數"] = int.Parse(Row01["cnt"].ToString());
                if (reporttype == "0")
                {
                    aRow["雇主勞保負擔"] = int.Parse(Row01["comp_lamt"].ToString());
                    aRow["雇主健保負擔"] = int.Parse(Row01["comp_hamt"].ToString());
                    aRow["雇主勞退負擔"] = int.Parse(Row01["comp_ramt"].ToString());
                }
                for (int i = 0; i < DT_4ata.Columns.Count; i++)
                {
                    if (DT_4ata.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_4ata.Rows[0][i].ToString().Trim()] = int.Parse(Row01["Fld" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort2(DataTable DT_4atd2, DataTable DT_4ata, string FileName,string reporttype)
        {
            DataTable ExporDt = new DataTable();            
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            if (reporttype=="1") ExporDt.Columns.Add("直間接", typeof(string));
            ExporDt.Columns.Add("人數", typeof(int));
            for (int i = 0; i < DT_4ata.Columns.Count; i++)
            {
                if (DT_4ata.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_4ata.Rows[0][i].ToString().Trim(), typeof(int));
                }
                else
                    break;
            }
            foreach (DataRow Row01 in DT_4atd2.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                if (reporttype == "1")  aRow["直間接"] = Row01["mark"].ToString();
                aRow["人數"] = int.Parse(Row01["cnt"].ToString());
                for (int i = 0; i < DT_4ata.Columns.Count; i++)
                {
                    if (DT_4ata.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_4ata.Rows[0][i].ToString().Trim()] = int.Parse(Row01["Fld" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }


        public static void ExPort3(DataTable DT_4atd2, DataTable DT_4ata, string FileName, string reporttype)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("公司別", typeof(string));
            ExporDt.Columns.Add("公司名稱", typeof(string));
            if (reporttype=="6") ExporDt.Columns.Add("人數", typeof(int));
            for (int i = 0; i < DT_4ata.Columns.Count; i++)
            {
                if (DT_4ata.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_4ata.Rows[0][i].ToString().Trim(), typeof(int));
                }
                else
                    break;
            }
            foreach (DataRow Row01 in DT_4atd2.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["公司別"] = Row01["comp"].ToString();
                aRow["公司名稱"] = Row01["compname"].ToString();
                if (reporttype == "6")  aRow["人數"] = int.Parse(Row01["cnt"].ToString());
                for (int i = 0; i < DT_4ata.Columns.Count; i++)
                {
                    if (DT_4ata.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_4ata.Rows[0][i].ToString().Trim()] = int.Parse(Row01["Fld" + (i + 1)].ToString());
                    }
                    else
                        break;
                }
                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }


        public static void ExPort4(DataTable DT_4atd4, DataTable DT_4ata, string FileName, string reporttype)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            if (reporttype == "2")
            {
                ExporDt.Columns.Add("直間接", typeof(string));
                ExporDt.Columns.Add("人數", typeof(int));
            }
            else
            {
                ExporDt.Columns.Add("員工編號", typeof(string));
                ExporDt.Columns.Add("員工姓名", typeof(string));
                ExporDt.Columns.Add("英文姓名", typeof(string));
            }
            for (int i = 0; i < DT_4ata.Columns.Count; i++)
            {
                if (DT_4ata.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_4ata.Rows[0][i].ToString().Trim(), typeof(int));
                }
                else
                    break;
            }
            foreach (DataRow Row01 in DT_4atd4.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                if (reporttype == "2")
                {
                    aRow["直間接"] = Row01["di"].ToString();
                    aRow["人數"] = int.Parse(Row01["pno"].ToString());
                }
                else
                {
                    aRow["員工編號"] = Row01["nobr"].ToString();
                    aRow["員工姓名"] = Row01["name_c"].ToString();
                    aRow["英文姓名"] = Row01["name_e"].ToString();
                }
                for (int i = 0; i < DT_4ata.Columns.Count; i++)
                {
                    if (DT_4ata.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_4ata.Rows[0][i].ToString().Trim()] = int.Parse(Row01["Fld" + (i + 1)].ToString());
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
