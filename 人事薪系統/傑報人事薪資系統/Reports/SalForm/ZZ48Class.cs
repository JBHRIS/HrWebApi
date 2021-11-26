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
    class ZZ48Class
    {
        public static DataTable Get_Attenda(string nobr_b, string nobr_e, string attdateb,string attdatee)
        {
            JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string CmdAttend = "select a.nobr,a.abs,a.e_mins,a.late_mins,b.wk_hrs";
            CmdAttend += " from attend a,rote b where a.rote=b.rote";
            CmdAttend += string.Format(@" and nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            CmdAttend += string.Format(@" and adate between '{0}' and '{1}'", attdateb, attdatee);
            CmdAttend += " and (abs=1 or e_mins>0 or late_mins>0)";
            return SqlConn.GetDataTable(CmdAttend);
        }

        public static void Get_Attend(DataTable DT_Attend, DataTable DT_Attenda,DataTable DT_absa)
        {
            DT_Attend.PrimaryKey = new DataColumn[] { DT_Attend.Columns["nobr"] };
            foreach (DataRow Row in DT_Attenda.Rows)
            {
                DataRow row = DT_Attend.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    if (bool.Parse(Row["abs"].ToString()))
                    {
                        row["abs"] = int.Parse(row["abs"].ToString()) + 1;
                        //row["abshrs"] = decimal.Parse(row["abshrs"].ToString()) + decimal.Parse(Row["wk_hrs"].ToString());
                    }
                    if (decimal.Parse(Row["late_mins"].ToString()) > 0) row["late_mins"] = int.Parse(row["late_mins"].ToString()) + 1;
                    row["e_mins"] = decimal.Round(decimal.Parse(row["e_mins"].ToString()), 0) + decimal.Round(decimal.Parse(Row["e_mins"].ToString()), 0);
                }
                else
                {
                    DataRow row1 = DT_absa.Rows.Find(Row["nobr"].ToString());
                    DataRow aRow = DT_Attend.NewRow();                    
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["abs"]=0;
                    aRow["abshrs"] = (row1 != null) ? decimal.Parse(row1["abs_hrs"].ToString()) : 0;
                    //if (bool.Parse(Row["abs"].ToString()))
                    //{
                    //    aRow["abs"] = 1;
                    //    aRow["abshrs"] = decimal.Parse(Row["wk_hrs"].ToString());
                    //}
                    aRow["late_mins"] = (decimal.Parse(Row["late_mins"].ToString()) > 0) ? 1 : 0;
                    aRow["e_mins"] = decimal.Round(decimal.Parse(Row["e_mins"].ToString()), 0);
                    DT_Attend.Rows.Add(aRow);
                }
            }
        }


        public static DataTable Get_Ota(string nobr_b, string nobr_e,string yymm)
        {
            JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string CmdOt = "select a.nobr, sum(a.not_w_133+a.tot_w_133+a.not_h_133) as ot_133,";
            CmdOt += "sum(a.not_w_100+a.tot_w_100) as ot_100,00000.00 as ot_150,";
            CmdOt += "sum(a.not_w_167+a.tot_w_167+a.not_h_167) as ot_167,";
            CmdOt += "sum(a.not_w_200+a.tot_w_200) as ot_200,";
            CmdOt += "sum(a.not_h_200+a.tot_h_200) as ot_200_h,a.nop_w_133,a.nop_w_167,a.nop_w_200,a.nop_h_133,a.nop_h_200";
            CmdOt += string.Format(@" from ot a where a.nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            CmdOt += string.Format(@" and a.yymm='{0}' and a.fix_amt=0", yymm);
            CmdOt += "  group by a.nobr,a.nop_w_133,a.nop_w_167,a.nop_w_200,a.nop_h_133,a.nop_h_200";
            return SqlConn.GetDataTable(CmdOt);
        }

        public static void Get_Ot(DataTable DT_Ot, DataTable DT_Ota, DataTable rq_wage)
        {
            foreach (DataRow Row in DT_Ota.Rows)
            {
                DataRow row1 = rq_wage.Rows.Find(Row["nobr"].ToString());
                if (row1 != null)
                {
                    DataRow row = DT_Ot.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        row["ot_100"] = decimal.Parse(row["ot_100"].ToString()) + decimal.Parse(Row["ot_100"].ToString());
                        row["ot_133"] = decimal.Parse(row["ot_133"].ToString()) + decimal.Parse(Row["ot_133"].ToString());
                        row["ot_167"] = decimal.Parse(row["ot_167"].ToString()) + decimal.Parse(Row["ot_167"].ToString());
                        row["ot_200"] = decimal.Parse(row["ot_200"].ToString()) + decimal.Parse(Row["ot_200"].ToString());
                        row["ot_200_h"] = decimal.Parse(row["ot_200_h"].ToString()) + decimal.Parse(Row["ot_200_h"].ToString());
                        row["total"] = decimal.Parse(row["ot_100"].ToString()) + decimal.Parse(row["ot_133"].ToString()) + decimal.Parse(row["ot_167"].ToString());
                        row["total"] = decimal.Parse(row["total"].ToString()) + decimal.Parse(row["ot_200"].ToString()) + decimal.Parse(row["ot_200_h"].ToString());
                    }
                    else
                    {
                        DataRow aRow = DT_Ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["ot_100"] = decimal.Parse(Row["ot_100"].ToString());
                        aRow["ot_133"] = decimal.Parse(Row["ot_133"].ToString());
                        aRow["ot_167"] = decimal.Parse(Row["ot_167"].ToString());
                        aRow["ot_200"] = decimal.Parse(Row["ot_200"].ToString());
                        aRow["ot_200_h"] = decimal.Parse(Row["ot_200_h"].ToString());
                        aRow["total"] = decimal.Parse(Row["ot_100"].ToString()) + decimal.Parse(Row["ot_133"].ToString()) + decimal.Parse(Row["ot_167"].ToString()) + decimal.Parse(Row["ot_200"].ToString()) + decimal.Parse(Row["ot_200_h"].ToString());
                        DT_Ot.Rows.Add(aRow);
                    }
                }
            }     
        }

        public static DataTable Get_Otb(string nobr_b, string nobr_e, string yymm)
        {
            JBModule.Data.CSQL SqlConn = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");
            string CmdOta = "select nobr,sum(rest_hrs) as rest_hrs from ot";
            CmdOta += string.Format(@" where nobr between '{0}' and '{1}'", nobr_b, nobr_e);
            CmdOta += string.Format(@" and yymm= '{0}'", yymm);
            CmdOta += " group by nobr";
            return SqlConn.GetDataTable(CmdOta);
        }
        public static void Get_wageds1(DataTable DT_wageds1, DataTable DT_waged, DataTable DT_base)
        {
            DataRow[] row1 = DT_waged.Select("salattr<='F'", "nobr asc");
            for (int i = 0; i < row1.Length; i++)
            {
                DataRow row3 = DT_wageds1.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot1"] = decimal.Parse(row1[i]["amt"].ToString()) + decimal.Parse(row3["tot1"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["tot1"] = decimal.Parse(row1[i]["amt"].ToString());
                    DT_wageds1.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wageds1.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["tot1"] = 0;
                    DT_wageds1.Rows.Add(aRow);
                }
            }
        }        

        public static void Get_wageds2(DataTable DT_wageds2, DataTable DT_waged, DataTable DT_base, string retirerate)
        {
            DataRow[] row1 = DT_waged.Select("salattr <='L' and sal_code <>'" + retirerate + "'", "nobr asc");
            for (int i = 0; i < row1.Length; i++)
            {
                DataRow row3 = DT_wageds2.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot2"] = decimal.Parse(row1[i]["amt"].ToString()) + decimal.Parse(row3["tot2"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wageds2.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["tot2"] = decimal.Parse(row1[i]["amt"].ToString());
                    DT_wageds2.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wageds2.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wageds2.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["tot2"] = 0;
                    DT_wageds2.Rows.Add(aRow);
                }
            }
        }

        public static void Get_wagedsz(DataTable DT_wageds1, DataTable DT_waged, DataTable DT_base)
        {
            DataRow[] row1 = DT_waged.Select("", "nobr asc");
            for (int i = 0; i < row1.Length; i++)
            {
                DataRow row3 = DT_wageds1.Rows.Find(row1[i]["nobr"].ToString());
                if (row3 != null)
                {
                    row3["totz"] = decimal.Parse(row1[i]["amt"].ToString()) + decimal.Parse(row3["totz"].ToString());
                }
                else
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = row1[i]["nobr"].ToString();
                    aRow["totz"] = decimal.Parse(row1[i]["amt"].ToString());
                    DT_wageds1.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row in DT_base.Rows)
            {
                DataRow row = DT_wageds1.Rows.Find(Row["nobr"].ToString());
                if (row == null)
                {
                    DataRow aRow = DT_wageds1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["totz"] = 0;
                    DT_wageds1.Rows.Add(aRow);
                }
            }
        }

        public static void Get_zz48td(DataTable DT_zz48td,DataTable DT_zz48ta, DataTable rq_waged, DataTable DT_wageds1, DataTable DT_wageds2, DataTable DT_wagedsz,DataTable DT_attend,DataTable DT_abs,DataTable DT_abs1,DataTable DT_ot,DataTable DT_ot1,int _abacnt)
        {
            DataRow[] SRow1 = rq_waged.Select("", "dept,nobr asc");
            foreach (DataRow Row in SRow1)
            {
                DataRow row1 = DT_wageds1.Rows.Find(Row["nobr"].ToString());
                DataRow row2 = DT_wageds2.Rows.Find(Row["nobr"].ToString());
                DataRow row3 = DT_wagedsz.Rows.Find(Row["nobr"].ToString());
                DataRow row4 = DT_attend.Rows.Find(Row["nobr"].ToString());
                DataRow row5 = DT_ot.Rows.Find(Row["nobr"].ToString());
                DataRow row6 = DT_ot1.Rows.Find(Row["nobr"].ToString());
                DataRow row7 = DT_abs1.Rows.Find(Row["nobr"].ToString());
                //DataRow row5 = DT_abs.Rows.Find(Row["nobr"].ToString());
               
                if (row1 != null && row2 != null && row3 != null)
                {
                    DataRow row = DT_zz48td.Rows.Find(Row["nobr"].ToString());
                    if (row != null)
                    {
                        for (int i = _abacnt; i < DT_zz48ta.Columns.Count; i++)
                        {
                            if (DT_zz48ta.Rows[0][i].ToString().Trim() != "")
                            {
                                if (Row["sal_name"].ToString().Trim() == DT_zz48ta.Rows[0][i].ToString().Trim())
                                    row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row["amt"].ToString());
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        DataRow aRow = DT_zz48td.NewRow();
                        aRow["dept"] = Row["dept"].ToString();
                        aRow["d_name"] = Row["d_name"].ToString();
                        aRow["job"] = Row["job"].ToString();
                        aRow["job_name"] = Row["job_name"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();
                        aRow["abs"] = 0;
                        aRow["abshrs"] = 0;
                        aRow["latetimes"] = 0;
                        aRow["e_mins"] = 0;
                        aRow["getleave"] = 0;
                        if (row4 != null)
                        {
                            aRow["abs"] = int.Parse(row4["abs"].ToString());
                            aRow["abshrs"] = decimal.Parse(row4["abshrs"].ToString());
                            aRow["latetimes"] = int.Parse(row4["late_mins"].ToString());
                            aRow["e_mins"] = int.Parse(row4["e_mins"].ToString());
                        }
                        if (row7 != null)
                            aRow["getleave"] = decimal.Parse(row7["abs_hrs"].ToString());
                        for (int i = 0; i < DT_zz48ta.Columns.Count; i++)
                        {
                            if (DT_zz48ta.Rows[0][i].ToString().Trim() != "")
                            {
                                aRow["Fld" + (i + 1)] = 0;
                                if (Row["sal_name"].ToString().Trim() == DT_zz48ta.Rows[0][i].ToString().Trim())
                                    aRow["Fld" + (i + 1)] = decimal.Parse(Row["amt"].ToString());
                                else if (DT_zz48ta.Rows[0][i].ToString().Trim() == "應稅薪資")
                                    aRow["Fld" + (i + 1)] = decimal.Parse(row1["tot1"].ToString());
                                else if (DT_zz48ta.Rows[0][i].ToString().Trim() == "應發薪資")
                                    aRow["Fld" + (i + 1)] = decimal.Parse(row2["tot2"].ToString());                               
                                else if (DT_zz48ta.Rows[0][i].ToString().Trim() == "實發薪資")
                                    aRow["Fld" + (i + 1)] = decimal.Parse(row3["totz"].ToString());                                
                                if (row5 != null)
                                {
                                    if (DT_zz48ta.Rows[0][i].ToString().Trim() == "加班1倍")
                                        aRow["Fld" + (i + 1)] = decimal.Parse(row5["ot_100"].ToString());
                                    else if (DT_zz48ta.Rows[0][i].ToString().Trim() == "加班1.33倍")
                                        aRow["Fld" + (i + 1)] = decimal.Parse(row5["ot_133"].ToString());
                                    else if (DT_zz48ta.Rows[0][i].ToString().Trim() == "加班1.67倍")
                                        aRow["Fld" + (i + 1)] = decimal.Parse(row5["ot_167"].ToString());
                                    else if (DT_zz48ta.Rows[0][i].ToString().Trim() == "加班2倍")
                                        aRow["Fld" + (i + 1)] = decimal.Parse(row5["ot_200"].ToString());
                                    else if (DT_zz48ta.Rows[0][i].ToString().Trim() == "假日加班")
                                        aRow["Fld" + (i + 1)] = decimal.Parse(row5["ot_200_h"].ToString());     
                                     if (DT_zz48ta.Rows[0][i].ToString().Trim() == "加班總時數")
                                         aRow["Fld" + (i + 1)] = decimal.Parse(row5["total"].ToString());
                                }
                                if (row6 != null)
                                { 
                                   
                                    if (DT_zz48ta.Rows[0][i].ToString().Trim() == "總計補休")
                                        aRow["Fld" + (i + 1)] = decimal.Parse(row6["rest_hrs"].ToString());
                                }
                            }

                            else
                                break;
                        }
                        DT_zz48td.Rows.Add(aRow);
                    }
                }
            }

            foreach (DataRow Row in DT_abs.Rows)
            {
                DataRow row = DT_zz48td.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    for (int i = 0; i < _abacnt; i++)
                    {
                        if (Row["h_code"].ToString().Trim()+Row["h_name"].ToString().Trim() == DT_zz48ta.Rows[0][i].ToString().Trim())
                            row["Fld" + (i + 1)] = decimal.Parse(row["Fld" + (i + 1)].ToString()) + decimal.Parse(Row["abs_hrs"].ToString());
                    }
                }
            }
        }

        public static void ExPort(DataTable DT_48td, DataTable DT_48ta, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("職稱", typeof(string));
            ExporDt.Columns.Add("曠職", typeof(decimal));
            ExporDt.Columns.Add("遲到(次)", typeof(int));
            ExporDt.Columns.Add("早退", typeof(int));
            ExporDt.Columns.Add("特休假", typeof(decimal));
            for (int i = 0; i < DT_48ta.Columns.Count; i++)
            {
                if (DT_48ta.Rows[0]["Fld" + (i + 1)].ToString().Trim() != "")
                {
                    ExporDt.Columns.Add(DT_48ta.Rows[0][i].ToString().Trim(), typeof(decimal));
                }
                else
                    break;
            }

            foreach (DataRow Row01 in DT_48td.Rows)
            {
                string AAD = Row01["nobr"].ToString();
                DataRow aRow = ExporDt.NewRow();
                aRow["部門代碼"] = Row01["dept"].ToString();
                aRow["部門名稱"] = Row01["d_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["職稱"] = Row01["job_name"].ToString();
                aRow["曠職"] = decimal.Parse(Row01["abshrs"].ToString());
                aRow["遲到(次)"] = int.Parse(Row01["latetimes"].ToString());
                aRow["早退"] = int.Parse(Row01["e_mins"].ToString());
                aRow["特休假"] = decimal.Parse(Row01["getleave"].ToString());
                for (int i = 0; i < DT_48ta.Columns.Count; i++)
                {
                    if (DT_48ta.Rows[0]["Fld" + (i + 1)].ToString() != "")
                    {
                        aRow[DT_48ta.Rows[0][i].ToString().Trim()] = (!Row01.IsNull("Fld" + (i + 1))) ? decimal.Parse(Row01["Fld" + (i + 1)].ToString()) : 0;
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
