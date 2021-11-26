/* ======================================================================================================
 * 功能名稱：勞健團保費用分攤
 * 功能代號：ZZ381
 * 功能路徑：報表列印 > 保險 > 勞健團保費用分攤
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\InsForm\ZZ381Class.cs
 * 功能用途：
 *  用於產出勞健團保費用分攤資料
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/02/18    Daniel Chih    Ver 1.0.01     1. 在【部門彙總】表格中增加【勞保公司總計】欄位
 * 2021/02/24    Daniel Chih    Ver 1.0.01     1. 增加函式 Waged_Update 用以調整明細分攤資料
 *                                             2. 修改費用計算方式從四捨五入改為小數點後無條件捨去
 *                                             3. 修正 部門彙總 的分攤計算方式
 * 2021/02/25    Daniel Chih    Ver 1.0.03     1. 修改SQL語法，修正無分攤比率的資料被篩掉的問題
 * 2021/02/26    Daniel Chih    Ver 1.0.04     1. 移除處理資料前對於 cost 資料表的 join
 * 2021/03/02    Daniel Chih    Ver 1.0.05     1. 修改判斷成本部門是否相符的內容
 * 2021/03/03    Daniel Chih    Ver 1.0.06     1. 增加判斷無發薪資料人員的保費分攤資料
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/03/03
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace JBHR.Reports.InsForm
{
    class ZZ381Class
    {
        public static void GetWaged(DataTable DT_waged, DataTable DT_waged1, DataTable DT_base, string lsalcode, string hsalcode, string retsalcode, string groupsalcd)
        {
            foreach (DataRow Row in DT_waged1.Rows)
            {
                object[] base_value = new object[2];
                base_value[0] = Row["nobr"].ToString();
                base_value[1] = Row["depts"].ToString();
                DataRow row_base = DT_base.Rows.Find(base_value);
                if (row_base != null)
                {
                    DataRow row1 = DT_waged.Rows.Find(Row["nobr"].ToString());
                    if (row1 != null)
                    {
                        if (Row["sal_code"].ToString() == lsalcode)
                            row1["l_exp"] = int.Parse(row1["l_exp"].ToString()) +
                                JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));// * Convert.ToDecimal(row_base["rate"].ToString());
                        else if (Row["sal_code"].ToString() == hsalcode)
                            //row1["h_exp"] = 0;// int.Parse(row1["h_exp"].ToString()) + JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                            row1["h_exp"] = int.Parse(row1["h_exp"].ToString()) +
                                JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        else if (Row["sal_code"].ToString() == retsalcode)
                            row1["r_exp"] = int.Parse(row1["r_exp"].ToString()) +
                                JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));// * Convert.ToDecimal(row_base["rate"].ToString());
                        else if (Row["sal_code"].ToString() == groupsalcd)
                            row1["g_exp"] = int.Parse(row1["g_exp"].ToString()) +
                                JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));// * Convert.ToDecimal(row_base["rate"].ToString());
                    }
                    else
                    {
                        string _di = "";
                        if (row_base["di"].ToString().Trim() == "D")
                            _di = "直接";
                        else if (row_base["di"].ToString().Trim() == "I")
                            _di = "間接";
                        DataRow aRow = DT_waged.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["depts"] = row_base["depts"].ToString();
                        aRow["ds_name"] = row_base["ds_name"].ToString();
                        aRow["di"] = _di;
                        aRow["name_c"] = row_base["name_c"].ToString();
                        aRow["name_e"] = row_base["name_e"].ToString();
                        aRow["indt"] = DateTime.Parse(row_base["indt"].ToString());
                        aRow["idno"] = row_base["idno"].ToString();
                        //aRow["rate"] = row_base["rate"].ToString();
                        aRow["l_exp1"] = 0;
                        aRow["l_exp"] = (Row["sal_code"].ToString() == lsalcode)
                            ? JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()))// * Convert.ToDecimal(row_base["rate"].ToString()) 
                            : 0;
                        aRow["h_exp1"] = 0;
                        //aRow["h_exp"] = 0;// (Row["sal_code"].ToString() == hsalcode) ? JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) : 0;
                        aRow["h_exp"] = (Row["sal_code"].ToString() == hsalcode)
                            ? JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()))
                            : 0;
                        aRow["r_exp1"] = 0;
                        aRow["r_exp"] = (Row["sal_code"].ToString() == retsalcode)
                            ? JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()))// * Convert.ToDecimal(row_base["rate"].ToString())
                            : 0;
                        aRow["g_exp1"] = 0;
                        aRow["g_exp"] = (Row["sal_code"].ToString() == groupsalcd)
                            ? JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()))// * Convert.ToDecimal(row_base["rate"].ToString())
                            : 0;
                        aRow["fundamt"] = 0;
                        aRow["jobamt"] = 0;
                        aRow["fano"] = 0;
                        aRow["nooldret"] = bool.Parse(row_base["nooldret"].ToString());
                        aRow["oldret"] = 0;
                        aRow["bonus"] = 0;
                        aRow["wkday"] = int.Parse(row_base["wkday"].ToString());
                        aRow["chk"] = "0";
                        DT_waged.Rows.Add(aRow);
                    }
                }
            }
        }

        /// <summary>
        /// 寫入薪資資料
        /// </summary>
        /// <param name="DT_salbasd">--</param>
        /// <param name="DT_salbasda">-</param>
        /// <param name="DT_waged">----薪資資料檔</param>
        /// <param name="DT_base">-----基本資料檔</param>
        /// <param name="retirerate1">-</param>
        /// <param name="retirerate">--</param>
        /// <param name="ljobper1">----</param>
        /// <param name="ljobper">-----</param>
        public static void GetSalbasd(DataTable DT_salbasd, DataTable DT_salbasda, DataTable DT_waged, DataTable DT_base, decimal retirerate1, decimal retirerate, decimal ljobper1, decimal ljobper)
        {
            foreach (DataRow Row in DT_salbasda.Rows)
            {
                DataRow row = DT_salbasd.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    if (bool.Parse(Row["retire"].ToString()))
                        row["totalret"] = int.Parse(row["totalret"].ToString()) + int.Parse(Row["amt"].ToString());
                    if (bool.Parse(Row["yearpay"].ToString()))
                        row["totalbonus"] = int.Parse(row["totalbonus"].ToString()) + int.Parse(Row["amt"].ToString());
                }
                else
                {
                    DataRow aRow = DT_salbasd.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["totalret"] = (bool.Parse(Row["retire"].ToString())) ? int.Parse(Row["amt"].ToString()) : 0;
                    aRow["totalbonus"] = (bool.Parse(Row["yearpay"].ToString())) ? int.Parse(Row["amt"].ToString()) : 0;
                    DT_salbasd.Rows.Add(aRow);

                    DataRow row1 = DT_waged.Rows.Find(Row["nobr"].ToString());


                    object[] base_value = new object[2];
                    base_value[0] = Row["nobr"].ToString();
                    base_value[1] = Row["depts"].ToString();
                    DataRow row2 = DT_base.Rows.Find(base_value);
                    if (row1 == null && row2 != null)
                    {
                        string _di = "";
                        if (row2["di"].ToString().Trim() == "D")
                            _di = "直接";
                        else if (row2["di"].ToString().Trim() == "I")
                            _di = "間接";
                        DataRow aRow1 = DT_waged.NewRow();
                        aRow1["nobr"] = Row["nobr"].ToString();
                        aRow1["depts"] = row2["depts"].ToString();
                        aRow1["ds_name"] = row2["ds_name"].ToString();
                        aRow1["di"] = _di;
                        aRow1["name_c"] = row2["name_c"].ToString();
                        aRow1["name_e"] = row2["name_e"].ToString();
                        aRow1["indt"] = DateTime.Parse(row2["indt"].ToString());
                        aRow1["idno"] = row2["idno"].ToString();
                        aRow1["nooldret"] = bool.Parse(row2["nooldret"].ToString());
                        aRow1["l_exp1"] = 0;
                        aRow1["l_exp"] = 0;
                        aRow1["h_exp1"] = 0;
                        aRow1["h_exp"] = 0;
                        aRow1["r_exp1"] = 0;
                        aRow1["r_exp"] = 0;
                        aRow1["g_exp1"] = 0;
                        aRow1["g_exp"] = 0;
                        aRow1["fundamt"] = 0;
                        aRow1["jobamt"] = 0;
                        aRow1["fano"] = 0;
                        aRow1["oldret"] = 0;
                        aRow1["bonus"] = 0;
                        aRow1["wkday"] = int.Parse(row2["wkday"].ToString());
                        DT_waged.Rows.Add(aRow1);
                    }
                }
            }

            //年節及新舊退金提撥
            foreach (DataRow Row in DT_waged.Rows)
            {
                DataRow row2 = DT_salbasd.Rows.Find(Row["nobr"].ToString());
                Row["totalret"] = (row2 != null) ? int.Parse(row2["totalret"].ToString()) : 0;
                Row["oldret"] = 0;
                decimal _wkday = decimal.Parse(Row["wkday"].ToString());
                if (Convert.ToInt32(DateTime.Parse(Row["indt"].ToString()).ToString("yyyyMMdd")) < 20050701 && !bool.Parse(Row["nooldret"].ToString()))
                {
                    //if (Row["di"].ToString().Trim() == "直接")
                    //    Row["oldret"] = Math.Round(decimal.Parse(Row["totalret"].ToString()) * retirerate1 * (_wkday / 30), MidpointRounding.AwayFromZero);
                    //else if (Row["di"].ToString().Trim() == "間接")
                    //    Row["oldret"] = Math.Round(decimal.Parse(Row["totalret"].ToString()) * retirerate * (_wkday / 30), MidpointRounding.AwayFromZero);
                    //else
                    //    Row["oldret"] = int.Parse(Row["totalret"].ToString());
                    if (Row["di"].ToString().Trim() == "直接")
                        Row["oldret"] = Math.Round(decimal.Parse(Row["totalret"].ToString()) * retirerate1, MidpointRounding.AwayFromZero);
                    else if (Row["di"].ToString().Trim() == "間接")
                        Row["oldret"] = Math.Round(decimal.Parse(Row["totalret"].ToString()) * retirerate, MidpointRounding.AwayFromZero);
                    else
                        Row["oldret"] = int.Parse(Row["totalret"].ToString());
                }

                Row["totalbonus"] = (row2 != null) ? int.Parse(row2["totalbonus"].ToString()) : 0;
                //if (Row["di"].ToString().Trim() == "直接")
                //    Row["bonus"] = Math.Round(decimal.Parse(Row["totalbonus"].ToString()) * ljobper1 * (_wkday / 30), MidpointRounding.AwayFromZero);
                //else if (Row["di"].ToString().Trim() == "間接")
                //    Row["bonus"] = Math.Round(decimal.Parse(Row["totalbonus"].ToString()) * ljobper * (_wkday / 30), MidpointRounding.AwayFromZero);
                //else
                //    Row["bonus"] = int.Parse(Row["totalbonus"].ToString());

                if (Row["di"].ToString().Trim() == "直接")
                    Row["bonus"] = Math.Round(decimal.Parse(Row["totalbonus"].ToString()) * ljobper1, MidpointRounding.AwayFromZero);
                else if (Row["di"].ToString().Trim() == "間接")
                    Row["bonus"] = Math.Round(decimal.Parse(Row["totalbonus"].ToString()) * ljobper, MidpointRounding.AwayFromZero);
                else
                    Row["bonus"] = int.Parse(Row["totalbonus"].ToString());

            }
        }

        public static void GetWaged1(DataTable DT_waged, DataTable DT_explab, DataTable DT_salbasd, DataTable DT_base)
        {
            string str_nobr1 = ""; int _pno = 0;
            DataRow[] SRow = DT_explab.Select("", "nobr,fa_idno asc");
            foreach (DataRow Row in SRow)
            {
                object[] base_value = new object[2];
                base_value[0] = Row["nobr"].ToString();
                base_value[1] = Row["depts"].ToString();
                DataRow row_base = DT_base.Rows.Find(base_value);
                if (row_base != null)
                {
                    Row["fundamt"] = (decimal.Parse(Row["fundamt"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["fundamt"].ToString()));
                    Row["jobamt"] = (decimal.Parse(Row["jobamt"].ToString()) == 0) ? 0 : JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["jobamt"].ToString()));
                    Row["exp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["exp"].ToString()));
                    Row["comp"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["comp"].ToString()));
                    DataRow row1 = DT_waged.Rows.Find(Row["nobr"].ToString());
                    if (row1 != null)
                    {
                        row1["fano"] = 0;
                        row1["chk"] = "1";
                        if (Row["insur_type"].ToString().Trim() == "1")
                        {
                            row1["l_exp1"] = int.Parse(row1["l_exp1"].ToString()) + int.Parse(Row["comp"].ToString());
                            row1["l_exp1"] = int.Parse(row1["l_exp1"].ToString()) - int.Parse(Row["fundamt"].ToString());
                            row1["l_exp1"] = int.Parse(row1["l_exp1"].ToString()) - int.Parse(Row["jobamt"].ToString());
                        }
                        else if (Row["insur_type"].ToString().Trim() == "2")
                        {
                            //if ( Row["fa_idno"].ToString().Trim() == "" )
                            //{
                            //row1["h_exp"] = int.Parse(row1["h_exp"].ToString()) + int.Parse(Row["exp"].ToString());
                            row1["h_exp1"] = int.Parse(row1["h_exp1"].ToString()) + int.Parse(Row["comp"].ToString());
                            if (Row["nobr"].ToString() == str_nobr1 && Row["fa_idno"].ToString().Trim() != "")
                                _pno = _pno + 1;
                            else
                                _pno = 0;
                            row1["fano"] = _pno;
                            //}
                        }
                        else if (Row["insur_type"].ToString().Trim() == "3")
                        {
                            row1["g_exp1"] = int.Parse(row1["g_exp1"].ToString()) + Math.Round(decimal.Parse(Row["comp"].ToString()), MidpointRounding.AwayFromZero);
                        }
                        else if (Row["insur_type"].ToString().Trim() == "4")
                        {
                            row1["r_exp1"] = int.Parse(row1["r_exp1"].ToString()) + int.Parse(Row["comp"].ToString());
                        }
                        row1["fundamt"] = int.Parse(row1["fundamt"].ToString()) + int.Parse(Row["fundamt"].ToString());
                        row1["jobamt"] = int.Parse(row1["jobamt"].ToString()) + int.Parse(Row["jobamt"].ToString());

                        if (row1["s_no"].ToString().Trim() != "")
                            row1["s_no"] = Row["s_no"].ToString();
                        str_nobr1 = Row["nobr"].ToString();

                        DT_waged.AcceptChanges();
                    }

                    else
                    {
                        DataRow New_Waged_Row = DT_waged.NewRow();

                        New_Waged_Row["depts"] = row_base["depts"].ToString().Trim();
                        New_Waged_Row["nobr"] = row_base["nobr"].ToString().Trim();
                        New_Waged_Row["ds_name"] = row_base["ds_name"].ToString().Trim();

                        if(row_base["di"].ToString().Trim() == "I")
                        {
                            New_Waged_Row["di"] = "間接";
                        }
                        else
                        {
                            New_Waged_Row["di"] = "直接";
                        }

                        New_Waged_Row["name_c"] = row_base["name_c"].ToString().Trim();
                        New_Waged_Row["indt"] = DateTime.Parse(row_base["indt"].ToString().Trim());
                        New_Waged_Row["idno"] = row_base["idno"].ToString().Trim();

                        New_Waged_Row["l_exp"] = 0;    //勞保
                        New_Waged_Row["h_exp"] = 0;    //健保
                        New_Waged_Row["g_exp"] = 0;    //團保
                        New_Waged_Row["r_exp"] = 0;    //勞退

                        New_Waged_Row["l_exp1"] = 0;    //勞保
                        New_Waged_Row["h_exp1"] = 0;    //健保
                        New_Waged_Row["g_exp1"] = 0;    //團保
                        New_Waged_Row["r_exp1"] = 0;    //勞退

                        New_Waged_Row["fundamt"] = 0;
                        New_Waged_Row["jobamt"] = 0;

                        New_Waged_Row["totalret"] = 0;
                        New_Waged_Row["nooldret"] = bool.Parse(row_base["nooldret"].ToString().Trim());
                        New_Waged_Row["oldret"] = 0;
                        New_Waged_Row["totalbonus"] = 0;
                        New_Waged_Row["bonus"] = 0;

                        New_Waged_Row["wkday"] = 0;

                        New_Waged_Row["chk"] = "1";
                        if (Row["insur_type"].ToString().Trim() == "1")
                        {
                            New_Waged_Row["l_exp1"] = int.Parse(New_Waged_Row["l_exp1"].ToString()) + int.Parse(Row["exp"].ToString());
                            New_Waged_Row["l_exp1"] = int.Parse(New_Waged_Row["l_exp1"].ToString()) + int.Parse(Row["comp"].ToString());
                            New_Waged_Row["l_exp1"] = int.Parse(New_Waged_Row["l_exp1"].ToString()) - int.Parse(Row["fundamt"].ToString());
                            New_Waged_Row["l_exp1"] = int.Parse(New_Waged_Row["l_exp1"].ToString()) - int.Parse(Row["jobamt"].ToString());
                        }
                        else if (Row["insur_type"].ToString().Trim() == "2")
                        {
                            //if ( Row["fa_idno"].ToString().Trim() == "" )
                            //{
                            //New_Waged_Row["h_exp"] = int.Parse(New_Waged_Row["h_exp"].ToString()) + int.Parse(Row["exp"].ToString());
                            New_Waged_Row["h_exp1"] = int.Parse(New_Waged_Row["h_exp1"].ToString()) + int.Parse(Row["comp"].ToString());
                            if (Row["nobr"].ToString() == str_nobr1 && Row["fa_idno"].ToString().Trim() != "")
                                _pno = _pno + 1;
                            else
                                _pno = 0;
                            New_Waged_Row["fano"] = _pno;
                            //}
                        }
                        else if (Row["insur_type"].ToString().Trim() == "3")
                        {
                            New_Waged_Row["g_exp1"] = int.Parse(New_Waged_Row["g_exp1"].ToString()) + Math.Round(decimal.Parse(Row["comp"].ToString()), MidpointRounding.AwayFromZero);
                        }
                        else if (Row["insur_type"].ToString().Trim() == "4")
                        {
                            New_Waged_Row["r_exp1"] = int.Parse(New_Waged_Row["r_exp1"].ToString()) + int.Parse(Row["comp"].ToString());
                        }
                        New_Waged_Row["fundamt"] = int.Parse(New_Waged_Row["fundamt"].ToString()) + int.Parse(Row["fundamt"].ToString());
                        New_Waged_Row["jobamt"] = int.Parse(New_Waged_Row["jobamt"].ToString()) + int.Parse(Row["jobamt"].ToString());

                        New_Waged_Row["s_no"] = Row["s_no"].ToString();

                        str_nobr1 = Row["nobr"].ToString();

                        DT_waged.Rows.Add(New_Waged_Row);
                    }

                }
                else
                    Row.Delete();
            }
            DT_explab.AcceptChanges();
        }

        #region 費用分攤（因共用 Waged_Update 函式，此部分註解掉不再使用，僅供參考過去語法）

        //public static void GetZZ383A(DataTable DT_cost, DataTable DT_waged, DataTable DT_zz383a)
        //{
        //    int _rowcnt = 0; string str_nobr1 = "";




        //    DataRow Row_Update = DT_zz383a.NewRow();

        //    decimal Update_Value_l_exp = 0;
        //    decimal Update_Value_l_exp1 = 0;
        //    decimal Update_Value_h_exp = 0;
        //    decimal Update_Value_h_exp1 = 0;
        //    decimal Update_Value_g_exp = 0;
        //    decimal Update_Value_g_exp1 = 0;
        //    decimal Update_Value_r_exp = 0;
        //    decimal Update_Value_r_exp1 = 0;
        //    decimal Update_Value_fundamt = 0;
        //    decimal Update_Value_jobamt = 0;
        //    decimal Update_Value_bonus = 0;
        //    decimal Update_Value_oldret = 0;

        //    foreach (DataRow Row in DT_cost.Rows)
        //    {
        //        if (Row["nobr"].ToString() == str_nobr1)
        //            _rowcnt = 1;
        //        else
        //            _rowcnt = 0;
        //        DataRow row = DT_waged.Rows.Find(Row["nobr"].ToString());

        //        if (row != null)
        //        {
        //            if (row["chk"].ToString() == "1")
        //            {
        //                DataRow aRow = DT_zz383a.NewRow();

        //                aRow["depts"] = Row["depts"].ToString();
        //                aRow["ds_name"] = Row["d_name"].ToString();
        //                aRow["di"] = row["di"].ToString();
        //                aRow["nobr"] = Row["nobr"].ToString();
        //                aRow["name_c"] = row["name_c"].ToString();
        //                aRow["name_e"] = row["name_e"].ToString();
        //                aRow["indt"] = DateTime.Parse(row["indt"].ToString());
        //                aRow["idno"] = row["idno"].ToString();
        //                aRow["s_no"] = row["s_no"].ToString();
        //                aRow["nooldret"] = bool.Parse(row["nooldret"].ToString());


        //                if (Math.Floor(decimal.Parse(row["l_exp"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))
        //                    - decimal.Parse(row["l_exp"].ToString())
        //                    + decimal.Parse(Update_Value_l_exp.ToString()) < 0

        //                    && decimal.Parse(row["l_exp"].ToString()) != 0
        //                    && decimal.Parse(Update_Value_l_exp.ToString()) != 0)
        //                {
        //                    aRow["l_exp"] = decimal.Parse(row["l_exp"].ToString()) - Math.Floor(decimal.Parse(row["l_exp"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())));
        //                }
        //                else
        //                {
        //                    aRow["l_exp"] = Math.Floor(decimal.Parse(row["l_exp"].ToString()) - Math.Floor(decimal.Parse(row["l_exp"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))); //, MidpointRounding.AwayFromZero);
        //                    Update_Value_l_exp = decimal.Parse(aRow["l_exp"].ToString());
        //                }


        //                if (Math.Floor(decimal.Parse(row["l_exp1"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString()))) 
        //                    - decimal.Parse(row["l_exp1"].ToString())
        //                    + decimal.Parse(Update_Value_l_exp1.ToString()) < 0

        //                    && decimal.Parse(row["l_exp1"].ToString()) != 0
        //                    && decimal.Parse(Update_Value_l_exp1.ToString()) != 0)
        //                {
        //                    aRow["l_exp1"] = decimal.Parse(row["l_exp1"].ToString()) - Math.Floor(decimal.Parse(row["l_exp1"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())));
        //                }
        //                else
        //                {
        //                    aRow["l_exp1"] = Math.Floor(decimal.Parse(row["l_exp1"].ToString()) - Math.Floor(decimal.Parse(row["l_exp1"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString()))));//, MidpointRounding.AwayFromZero);
        //                    Update_Value_l_exp1 = decimal.Parse(aRow["l_exp1"].ToString());
        //                }



        //                if (Math.Floor(decimal.Parse(row["h_exp"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))
        //                    - decimal.Parse(row["h_exp"].ToString())
        //                    + decimal.Parse(Update_Value_h_exp.ToString()) < 0

        //                    && decimal.Parse(row["h_exp"].ToString()) != 0
        //                    && decimal.Parse(Update_Value_h_exp.ToString()) != 0)
        //                {
        //                    aRow["h_exp"] = decimal.Parse(row["h_exp"].ToString()) - Math.Floor(decimal.Parse(row["h_exp"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())));
        //                }
        //                else
        //                {
        //                    aRow["h_exp"] = Math.Floor(decimal.Parse(row["h_exp"].ToString()) - Math.Floor(decimal.Parse(row["h_exp"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))); //, MidpointRounding.AwayFromZero);
        //                    Update_Value_h_exp = decimal.Parse(aRow["h_exp"].ToString());
        //                }


        //                if (Math.Floor(decimal.Parse(row["h_exp1"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))
        //                    - decimal.Parse(row["h_exp1"].ToString())
        //                    + decimal.Parse(Update_Value_h_exp1.ToString()) < 0

        //                    && decimal.Parse(row["h_exp1"].ToString()) != 0
        //                    && decimal.Parse(Update_Value_h_exp1.ToString()) != 0)
        //                {
        //                    aRow["h_exp1"] = decimal.Parse(row["h_exp1"].ToString()) - Math.Floor(decimal.Parse(row["h_exp1"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())));
        //                }
        //                else
        //                {
        //                    aRow["h_exp1"] = Math.Floor(decimal.Parse(row["h_exp1"].ToString()) - Math.Floor(decimal.Parse(row["h_exp1"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString()))));//, MidpointRounding.AwayFromZero);
        //                    Update_Value_h_exp1 = decimal.Parse(aRow["h_exp1"].ToString());
        //                }

        //                if (Math.Floor(decimal.Parse(row["g_exp"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))
        //                    - decimal.Parse(row["g_exp"].ToString())
        //                    + decimal.Parse(Update_Value_g_exp.ToString()) < 0

        //                    && decimal.Parse(row["g_exp"].ToString()) != 0
        //                    && decimal.Parse(Update_Value_g_exp.ToString()) != 0)
        //                {
        //                    aRow["g_exp"] = decimal.Parse(row["g_exp"].ToString()) - Math.Floor(decimal.Parse(row["g_exp"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())));
        //                }
        //                else
        //                {
        //                    aRow["g_exp"] = Math.Floor(decimal.Parse(row["g_exp"].ToString()) - Math.Floor(decimal.Parse(row["g_exp"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString()))));//, MidpointRounding.AwayFromZero);
        //                    Update_Value_g_exp = decimal.Parse(aRow["g_exp"].ToString());
        //                }

        //                if (Math.Floor(decimal.Parse(row["g_exp1"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))
        //                    - decimal.Parse(row["g_exp1"].ToString())
        //                    + decimal.Parse(Update_Value_g_exp1.ToString()) < 0

        //                    && decimal.Parse(row["g_exp1"].ToString()) != 0
        //                    && decimal.Parse(Update_Value_g_exp1.ToString()) != 0)
        //                {
        //                    aRow["g_exp1"] = decimal.Parse(row["g_exp1"].ToString()) - Math.Floor(decimal.Parse(row["g_exp1"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())));
        //                }
        //                else
        //                {
        //                    aRow["g_exp1"] = Math.Floor(decimal.Parse(row["g_exp1"].ToString()) - Math.Floor(decimal.Parse(row["g_exp1"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString()))));//, MidpointRounding.AwayFromZero);
        //                    Update_Value_g_exp1 = decimal.Parse(aRow["g_exp1"].ToString());
        //                }

        //                if (Math.Floor(decimal.Parse(row["r_exp"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))
        //                    - decimal.Parse(row["r_exp"].ToString())
        //                    + decimal.Parse(Update_Value_r_exp.ToString()) < 0

        //                    && decimal.Parse(row["r_exp"].ToString()) != 0
        //                    && decimal.Parse(Update_Value_r_exp.ToString()) != 0)
        //                {
        //                    aRow["r_exp"] = decimal.Parse(row["r_exp"].ToString()) - Math.Floor(decimal.Parse(row["r_exp"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())));
        //                }
        //                else
        //                {
        //                    aRow["r_exp"] = Math.Floor(decimal.Parse(row["r_exp"].ToString()) - Math.Floor(decimal.Parse(row["r_exp"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString()))));//, MidpointRounding.AwayFromZero);
        //                    Update_Value_r_exp = decimal.Parse(aRow["r_exp"].ToString());
        //                }

        //                if (Math.Floor(decimal.Parse(row["r_exp1"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))
        //                    - decimal.Parse(row["r_exp1"].ToString())
        //                    + decimal.Parse(Update_Value_r_exp1.ToString()) < 0

        //                    && decimal.Parse(row["r_exp1"].ToString()) != 0
        //                    && decimal.Parse(Update_Value_r_exp1.ToString()) != 0)
        //                {
        //                    aRow["r_exp1"] = decimal.Parse(row["r_exp1"].ToString()) - Math.Floor(decimal.Parse(row["r_exp1"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())));
        //                }
        //                else
        //                {
        //                    aRow["r_exp1"] = Math.Floor(decimal.Parse(row["r_exp1"].ToString()) - Math.Floor(decimal.Parse(row["r_exp1"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))); //, MidpointRounding.AwayFromZero);
        //                    Update_Value_r_exp1 = decimal.Parse(aRow["r_exp1"].ToString());
        //                }

        //                if (Math.Floor(decimal.Parse(row["fundamt"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))
        //                    - decimal.Parse(row["fundamt"].ToString())
        //                    + decimal.Parse(Update_Value_fundamt.ToString()) < 0

        //                    && decimal.Parse(row["fundamt"].ToString()) != 0
        //                    && decimal.Parse(Update_Value_fundamt.ToString()) != 0)
        //                {
        //                    aRow["fundamt"] = decimal.Parse(row["fundamt"].ToString()) - Math.Floor(decimal.Parse(row["fundamt"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())));
        //                }
        //                else
        //                {
        //                    aRow["fundamt"] = Math.Floor(decimal.Parse(row["fundamt"].ToString()) - Math.Floor(decimal.Parse(row["fundamt"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString()))));//, MidpointRounding.AwayFromZero);
        //                    Update_Value_fundamt = decimal.Parse(aRow["fundamt"].ToString());
        //                }

        //                if (Math.Floor(decimal.Parse(row["jobamt"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))
        //                    - decimal.Parse(row["jobamt"].ToString())
        //                    + decimal.Parse(Update_Value_jobamt.ToString()) < 0

        //                    && decimal.Parse(row["jobamt"].ToString()) != 0
        //                    && decimal.Parse(Update_Value_jobamt.ToString()) != 0)
        //                {
        //                    aRow["jobamt"] = decimal.Parse(row["jobamt"].ToString()) - Math.Floor(decimal.Parse(row["jobamt"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())));
        //                }
        //                else
        //                {
        //                    aRow["jobamt"] = Math.Floor(decimal.Parse(row["jobamt"].ToString()) - Math.Floor(decimal.Parse(row["jobamt"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))); //, MidpointRounding.AwayFromZero);
        //                    Update_Value_jobamt = decimal.Parse(aRow["jobamt"].ToString());
        //                }

        //                aRow["rowcnt"] = _rowcnt;
        //                aRow["pno"] = decimal.Parse(Row["rate"].ToString());
        //                if (Math.Floor(decimal.Parse(row["bonus"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))
        //                    - decimal.Parse(row["bonus"].ToString())
        //                    + decimal.Parse(Update_Value_bonus.ToString()) < 0

        //                    && decimal.Parse(row["bonus"].ToString()) != 0
        //                    && decimal.Parse(Update_Value_bonus.ToString()) != 0)
        //                {
        //                    aRow["bonus"] = decimal.Parse(row["bonus"].ToString()) - Math.Floor(decimal.Parse(row["bonus"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())));
        //                }
        //                else
        //                {
        //                    aRow["bonus"] = Math.Floor(decimal.Parse(row["bonus"].ToString()) - Math.Floor(decimal.Parse(row["bonus"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString()))));//, MidpointRounding.AwayFromZero);
        //                    Update_Value_bonus = decimal.Parse(aRow["bonus"].ToString());
        //                }

        //                if (Math.Floor(decimal.Parse(row["oldret"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))
        //                    - decimal.Parse(row["oldret"].ToString())
        //                    + decimal.Parse(Update_Value_oldret.ToString()) < 0

        //                    && decimal.Parse(row["oldret"].ToString()) != 0
        //                    && decimal.Parse(Update_Value_oldret.ToString()) != 0)
        //                {
        //                    aRow["oldret"] = decimal.Parse(row["oldret"].ToString()) - Math.Floor(decimal.Parse(row["oldret"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())));
        //                }
        //                else
        //                {
        //                    aRow["oldret"] = Math.Floor(decimal.Parse(row["oldret"].ToString()) - Math.Floor(decimal.Parse(row["oldret"].ToString()) * (1 - decimal.Parse(Row["rate"].ToString())))); //, MidpointRounding.AwayFromZero);
        //                    Update_Value_oldret = decimal.Parse(aRow["oldret"].ToString());
        //                }
        //                DT_zz383a.Rows.Add(aRow);
        //            }
        //        }
        //        str_nobr1 = Row["nobr"].ToString();
        //    }
        //}

        #endregion

        /// <summary>
        /// 產出【部門彙總】資料內容
        /// </summary>
        /// <param name="DT_zz383a"></param>
        /// <param name="DT_zz384">存取結果 Table 內容，用於產出報表</param>
        public static void Get_Dept_Total(DataTable DT_zz383a, DataTable DT_zz384) //DataTable DT_waged,
        {
            DT_zz384.PrimaryKey = new DataColumn[] { DT_zz384.Columns["depts"], DT_zz384.Columns["di"] };
            DataRow[] SRow1 = DT_zz383a.Select("", "");

            foreach (DataRow Row in SRow1)
            {
                object[] _value = new object[2];
                _value[0] = Row["depts"].ToString();
                _value[1] = Row["di"].ToString();
                DataRow row = DT_zz384.Rows.Find(_value);
                if (row != null)
                {
                    row["l_exp"] = int.Parse(row["l_exp"].ToString()) + int.Parse(Row["l_exp"].ToString());
                    row["l_exp1"] = int.Parse(row["l_exp1"].ToString()) + int.Parse(Row["l_exp1"].ToString());
                    row["h_exp"] = int.Parse(row["h_exp"].ToString()) + int.Parse(Row["h_exp"].ToString());
                    row["h_exp1"] = int.Parse(row["h_exp1"].ToString()) + int.Parse(Row["h_exp1"].ToString());
                    row["r_exp"] = int.Parse(row["r_exp"].ToString()) + int.Parse(Row["r_exp"].ToString());
                    row["r_exp1"] = int.Parse(row["r_exp1"].ToString()) + int.Parse(Row["r_exp1"].ToString());
                    row["g_exp"] = int.Parse(row["g_exp"].ToString()) + int.Parse(Row["g_exp"].ToString());
                    row["g_exp1"] = int.Parse(row["g_exp1"].ToString()) + int.Parse(Row["g_exp1"].ToString());
                    row["fundamt"] = int.Parse(row["fundamt"].ToString()) + int.Parse(Row["fundamt"].ToString());
                    row["jobamt"] = int.Parse(row["jobamt"].ToString()) + int.Parse(Row["jobamt"].ToString());
                    row["oldret"] = int.Parse(row["oldret"].ToString()) + int.Parse(Row["oldret"].ToString());
                    row["bonus"] = int.Parse(row["bonus"].ToString()) + int.Parse(Row["bonus"].ToString());
                    row["pno"] = decimal.Parse(row["pno"].ToString()) + decimal.Parse(Row["pno"].ToString());
                }
                else
                {
                    DT_zz384.ImportRow(Row);
                }
            }
        }


        /// <summary>
        /// 更新Waged資料，用於產出清單
        /// </summary>
        /// <param name="DT"></param>
        /// <param name="costList"></param>
        /// <param name="Result_Data_Table"></param>
        public static void Waged_Update(DataTable DT, List<JBModule.Data.Linq.COST> costList, DataTable Result_Data_Table)
        {

            var db = new JBModule.Data.Linq.HrDBDataContext();

            var deptsList = db.DEPTS.Select(p => new { p.D_NO, p.D_NO_DISP, p.D_NAME }).ToList();

            //成本部門編號
            Result_Data_Table.Columns.Add("depts", typeof(string));
            //部門名稱
            Result_Data_Table.Columns.Add("ds_name", typeof(string));
            //直間接
            Result_Data_Table.Columns.Add("di", typeof(string));
            //員工編號
            Result_Data_Table.Columns.Add("nobr", typeof(string));
            //員工中文名
            Result_Data_Table.Columns.Add("name_c", typeof(string));
            //員工英文名
            Result_Data_Table.Columns.Add("name_e", typeof(string));
            //到職日
            Result_Data_Table.Columns.Add("indt", typeof(DateTime));
            //身份證號
            Result_Data_Table.Columns.Add("idno", typeof(string));
            //
            Result_Data_Table.Columns.Add("s_no", typeof(string));

            //分攤比率
            Result_Data_Table.Columns.Add("rate", typeof(decimal));

            //健保費（個人）
            Result_Data_Table.Columns.Add("h_exp", typeof(int));
            //勞保費（個人）
            Result_Data_Table.Columns.Add("l_exp", typeof(int));
            //團保費（個人）
            Result_Data_Table.Columns.Add("g_exp", typeof(int));
            //勞退金（個人）
            Result_Data_Table.Columns.Add("r_exp", typeof(int));

            //健保費（公司）
            Result_Data_Table.Columns.Add("h_exp1", typeof(int));
            //勞保費（公司）
            Result_Data_Table.Columns.Add("l_exp1", typeof(int));
            //團保費（公司）
            Result_Data_Table.Columns.Add("g_exp1", typeof(int));
            //勞退金（公司）
            Result_Data_Table.Columns.Add("r_exp1", typeof(int));

            //墊償基金
            Result_Data_Table.Columns.Add("fundamt", typeof(int));
            //職業災害
            Result_Data_Table.Columns.Add("jobamt", typeof(int));
            //
            Result_Data_Table.Columns.Add("totalret", typeof(int));
            //
            Result_Data_Table.Columns.Add("nooldret", typeof(bool));
            //退休金舊制
            Result_Data_Table.Columns.Add("oldret", typeof(int));
            //
            Result_Data_Table.Columns.Add("totalbonus", typeof(int));
            //年節公司提撥
            Result_Data_Table.Columns.Add("bonus", typeof(int));
            //眷屬人數
            Result_Data_Table.Columns.Add("fano", typeof(int));

            Result_Data_Table.Columns.Add("rowcnt", typeof(int));
            Result_Data_Table.Columns.Add("pno", typeof(decimal));

            foreach (DataRow Row_zz383 in DT.Rows)
            {
                DataRow aRow = Result_Data_Table.NewRow();

                var l_exp = int.Parse(Row_zz383["l_exp"].ToString());
                var l_exp1 = int.Parse(Row_zz383["l_exp1"].ToString());

                var jobamt = int.Parse(Row_zz383["jobamt"].ToString());
                var fundamt = int.Parse(Row_zz383["fundamt"].ToString());

                var h_exp = int.Parse(Row_zz383["h_exp"].ToString());
                var h_exp1 = int.Parse(Row_zz383["h_exp1"].ToString());

                var r_exp = int.Parse(Row_zz383["r_exp"].ToString());
                var r_exp1 = int.Parse(Row_zz383["r_exp1"].ToString());

                var g_exp = int.Parse(Row_zz383["g_exp"].ToString());
                var g_exp1 = int.Parse(Row_zz383["g_exp1"].ToString());

                var totalret = int.Parse(Row_zz383["totalret"].ToString());
                //var nooldret = bool.Parse(Row_zz383["nooldret"].ToString());

                var oldret = int.Parse(Row_zz383["oldret"].ToString());
                var totalbonus = int.Parse(Row_zz383["totalbonus"].ToString());

                var bonus = int.Parse(Row_zz383["bonus"].ToString());
                var fano = int.Parse(Row_zz383["fano"].ToString());

                aRow["depts"] = Row_zz383["depts"].ToString();
                aRow["ds_name"] = Row_zz383["ds_name"].ToString();
                aRow["di"] = Row_zz383["di"].ToString();

                aRow["nobr"] = Row_zz383["nobr"].ToString();
                aRow["name_c"] = Row_zz383["name_c"].ToString();
                aRow["name_e"] = Row_zz383["name_e"].ToString();
                aRow["indt"] = Row_zz383["indt"].ToString();
                aRow["idno"] = Row_zz383["idno"].ToString();
                aRow["s_no"] = Row_zz383["s_no"].ToString();

                aRow["rate"] = 1;

                aRow["l_exp"] = int.Parse(Row_zz383["l_exp"].ToString());
                aRow["l_exp1"] = int.Parse(Row_zz383["l_exp1"].ToString());

                aRow["jobamt"] = int.Parse(Row_zz383["jobamt"].ToString());
                aRow["fundamt"] = int.Parse(Row_zz383["fundamt"].ToString());

                aRow["h_exp"] = int.Parse(Row_zz383["h_exp"].ToString());
                aRow["h_exp1"] = int.Parse(Row_zz383["h_exp1"].ToString());

                aRow["r_exp"] = int.Parse(Row_zz383["r_exp"].ToString());
                aRow["r_exp1"] = int.Parse(Row_zz383["r_exp1"].ToString());

                aRow["g_exp"] = int.Parse(Row_zz383["g_exp"].ToString());
                aRow["g_exp1"] = int.Parse(Row_zz383["g_exp1"].ToString());


                aRow["totalret"] = int.Parse(Row_zz383["totalret"].ToString());
                aRow["oldret"] = int.Parse(Row_zz383["oldret"].ToString());
                aRow["totalbonus"] = int.Parse(Row_zz383["totalbonus"].ToString());
                aRow["bonus"] = int.Parse(Row_zz383["bonus"].ToString());
                aRow["fano"] = int.Parse(Row_zz383["fano"].ToString());


                var costOfNobr = costList.Where(p => p.NOBR.Trim().ToUpper() == Row_zz383["nobr"].ToString().Trim().ToUpper());


                foreach (var it in costOfNobr)
                {
                    var depts = deptsList.FirstOrDefault(p => p.D_NO == it.DEPTS);
                    var depts_check = deptsList.FirstOrDefault(p => p.D_NO_DISP == aRow["depts"].ToString());

                    if (depts == depts_check) continue;

                    if (depts == null) continue;
                    DataRow aRowCost = Result_Data_Table.NewRow();
                    aRowCost["depts"] = depts.D_NO_DISP;
                    aRowCost["ds_name"] = depts.D_NAME;
                    aRowCost["di"] = Row_zz383["di"].ToString();
                    aRowCost["nobr"] = Row_zz383["nobr"].ToString();
                    aRowCost["name_c"] = Row_zz383["name_c"].ToString();
                    aRowCost["name_e"] = Row_zz383["name_e"].ToString();
                    aRowCost["indt"] = Row_zz383["indt"].ToString();
                    aRowCost["idno"] = Row_zz383["idno"].ToString();
                    aRowCost["s_no"] = Row_zz383["s_no"].ToString();

                    if (it.NOBR.ToString() == "")
                    {
                        aRowCost["rowcnt"] = 1;
                    }
                    else
                    {
                        aRowCost["rowcnt"] = 0;
                    }

                    aRowCost["rate"] = it.RATE;
                    aRow["rate"] = Convert.ToDecimal(aRow["rate"]) - it.RATE;

                    aRowCost["pno"] = Convert.ToDecimal(aRowCost["rate"].ToString());


                    aRowCost["l_exp"] = Math.Floor(int.Parse(aRow["l_exp"].ToString()) - int.Parse(Row_zz383["l_exp"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["l_exp"] = Convert.ToInt32(aRow["l_exp"]) - Convert.ToInt32(aRowCost["l_exp"]);
                    aRowCost["l_exp1"] = Math.Floor(int.Parse(aRow["l_exp1"].ToString()) - int.Parse(Row_zz383["l_exp1"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["l_exp1"] = Convert.ToInt32(aRow["l_exp1"]) - Convert.ToInt32(aRowCost["l_exp1"]);

                    ////aRowCost["勞保總計"] = Math.Round(int.Parse(Row01["l_exp"].ToString()) + int.Parse(Row01["l_exp1"].ToString()) + int.Parse(Row01["jobamt"].ToString()) + int.Parse(Row01["fundamt"].ToString()) * it.RATE, MidpointRounding.AwayFromZero);
                    //aRowCost["勞保總計"] = Convert.ToInt32(aRowCost["勞保費個人"]) + Convert.ToInt32(aRowCost["勞保費公司"]) + Convert.ToInt32(aRowCost["職業災害"]) + Convert.ToInt32(aRowCost["墊償基金"]);
                    //aRow["勞保總計"] = Convert.ToInt32(aRow["勞保總計"]) - Convert.ToInt32(aRowCost["勞保總計"]);

                    aRowCost["h_exp"] = Math.Floor(int.Parse(aRow["h_exp"].ToString()) - int.Parse(Row_zz383["h_exp"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["h_exp"] = Convert.ToInt32(aRow["h_exp"]) - Convert.ToInt32(aRowCost["h_exp"]);
                    aRowCost["h_exp1"] = Math.Floor(int.Parse(aRow["h_exp1"].ToString()) - int.Parse(Row_zz383["h_exp1"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["h_exp1"] = Convert.ToInt32(aRow["h_exp1"]) - Convert.ToInt32(aRowCost["h_exp1"]);

                    ////aRowCost["健保費總計"] = Math.Round(int.Parse(Row01["h_exp"].ToString()) + int.Parse(Row01["h_exp1"].ToString()) * it.RATE, MidpointRounding.AwayFromZero);
                    //aRowCost["健保費總計"] = Convert.ToInt32(aRowCost["健保費個人"]) + Convert.ToInt32(aRowCost["健保費公司"]);
                    //aRow["健保費總計"] = Convert.ToInt32(aRow["健保費總計"]) - Convert.ToInt32(aRowCost["健保費總計"]);

                    aRowCost["r_exp"] = Math.Floor(int.Parse(aRow["r_exp"].ToString()) - int.Parse(Row_zz383["r_exp"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["r_exp"] = Convert.ToInt32(aRow["r_exp"]) - Convert.ToInt32(aRowCost["r_exp"]);
                    aRowCost["r_exp1"] = Math.Floor(int.Parse(aRow["r_exp1"].ToString()) - int.Parse(Row_zz383["r_exp1"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["r_exp1"] = Convert.ToInt32(aRow["r_exp1"]) - Convert.ToInt32(aRowCost["r_exp1"]);

                    ////aRowCost["勞退金總計"] = Math.Round(int.Parse(Row01["r_exp"].ToString()) + int.Parse(Row01["r_exp1"].ToString()) * it.RATE, MidpointRounding.AwayFromZero);
                    //aRowCost["勞退金總計"] = Convert.ToInt32(aRowCost["勞退金個人"]) + Convert.ToInt32(aRowCost["勞退金公司"]);
                    //aRow["勞退金總計"] = Convert.ToInt32(aRow["勞退金總計"]) - Convert.ToInt32(aRowCost["勞退金總計"]);

                    aRowCost["g_exp"] = Math.Floor(int.Parse(aRow["g_exp"].ToString()) - int.Parse(Row_zz383["g_exp"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["g_exp"] = Convert.ToInt32(aRow["g_exp"]) - Convert.ToInt32(aRowCost["g_exp"]);
                    aRowCost["g_exp1"] = Math.Floor(int.Parse(aRow["g_exp1"].ToString()) - int.Parse(Row_zz383["g_exp"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["g_exp1"] = Convert.ToInt32(aRow["g_exp1"]) - Convert.ToInt32(aRowCost["g_exp1"]);

                    ////aRowCost["團保費總計"] = Math.Round(int.Parse(Row01["g_exp"].ToString()) + int.Parse(Row01["g_exp1"].ToString()) * it.RATE, MidpointRounding.AwayFromZero);
                    //aRowCost["團保費總計"] = Convert.ToInt32(aRowCost["團保費個人"]) + Convert.ToInt32(aRowCost["團保費公司"]);
                    //aRow["團保費總計"] = Convert.ToInt32(aRow["團保費總計"]) - Convert.ToInt32(aRowCost["團保費總計"]);

                    aRowCost["fundamt"] = Math.Floor(int.Parse(aRow["fundamt"].ToString()) - int.Parse(Row_zz383["fundamt"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["fundamt"] = Convert.ToInt32(aRow["fundamt"]) - Convert.ToInt32(aRowCost["fundamt"]);

                    aRowCost["jobamt"] = Math.Floor(int.Parse(aRow["jobamt"].ToString()) - int.Parse(Row_zz383["jobamt"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["jobamt"] = Convert.ToInt32(aRow["jobamt"]) - Convert.ToInt32(aRowCost["jobamt"]);

                    //眷屬人數
                    aRowCost["fano"] = Row_zz383["fano"].ToString();
                    //aRowCost["fano"] = Math.Floor(int.Parse(Row_zz383["fano"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                    //aRow["fano"] = Convert.ToInt32(aRow["fano"]) - Convert.ToInt32(aRowCost["fano"]);

                    aRowCost["totalret"] = Math.Floor(int.Parse(aRow["totalret"].ToString()) - int.Parse(Row_zz383["totalret"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["totalret"] = Convert.ToInt32(aRow["totalret"]) - Convert.ToInt32(aRowCost["totalret"]);

                    aRowCost["nooldret"] = Row_zz383["nooldret"].ToString();

                    aRowCost["oldret"] = Math.Floor(int.Parse(aRow["oldret"].ToString()) - int.Parse(Row_zz383["oldret"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["oldret"] = Convert.ToInt32(aRow["oldret"]) - Convert.ToInt32(aRowCost["oldret"]);

                    aRowCost["totalbonus"] = Math.Floor(int.Parse(aRow["totalbonus"].ToString()) - int.Parse(Row_zz383["totalbonus"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["totalbonus"] = Convert.ToInt32(aRow["totalbonus"]) - Convert.ToInt32(aRowCost["totalbonus"]);

                    aRowCost["bonus"] = Math.Floor(int.Parse(aRow["bonus"].ToString()) - int.Parse(Row_zz383["bonus"].ToString()) * Convert.ToDecimal(aRow["rate"])); //, MidpointRounding.AwayFromZero);
                    aRow["bonus"] = Convert.ToInt32(aRow["bonus"]) - Convert.ToInt32(aRowCost["bonus"]);

                    Result_Data_Table.Rows.Add(aRowCost);
                }
                if ((String.IsNullOrEmpty(aRow["rate"].ToString()) ? "0.00" : aRow["rate"].ToString()) != "0.00")
                {

                    aRow["pno"] = Convert.ToDecimal(aRow["rate"].ToString());

                    Result_Data_Table.Rows.Add(aRow);
                }
            }
        }


        #region Excel 表格部分

        public static void Export(DataTable DT, string FileName)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var deptsList = db.DEPTS.Select(p => new { p.D_NO, p.D_NO_DISP, p.D_NAME }).ToList();
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("直間接", typeof(string));
            ExporDt.Columns.Add("分攤比率", typeof(decimal));
            ExporDt.Columns.Add("勞保費個人", typeof(int));
            ExporDt.Columns.Add("勞保費公司", typeof(int));
            ExporDt.Columns.Add("職業災害", typeof(int));
            ExporDt.Columns.Add("墊償基金", typeof(int));
            ExporDt.Columns.Add("勞保總計", typeof(int));
            ExporDt.Columns.Add("健保費個人", typeof(int));
            ExporDt.Columns.Add("健保費公司", typeof(int));
            ExporDt.Columns.Add("健保費總計", typeof(int));
            ExporDt.Columns.Add("勞退金個人", typeof(int));
            ExporDt.Columns.Add("勞退金公司", typeof(int));
            ExporDt.Columns.Add("勞退金總計", typeof(int));
            ExporDt.Columns.Add("團保費個人", typeof(int));
            ExporDt.Columns.Add("團保費公司", typeof(int));
            ExporDt.Columns.Add("團保費總計", typeof(int));
            ExporDt.Columns.Add("退休金/舊制", typeof(int));
            ExporDt.Columns.Add("年節公司提撥", typeof(int));
            ExporDt.Columns.Add("健保眷屬人數", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();

                var l_exp = int.Parse(Row01["l_exp"].ToString());
                var l_exp1 = int.Parse(Row01["l_exp1"].ToString());
                var jobamt = int.Parse(Row01["jobamt"].ToString());
                var fundamt = int.Parse(Row01["fundamt"].ToString());
                var l_exp_total = int.Parse(Row01["l_exp"].ToString()) + int.Parse(Row01["l_exp1"].ToString()) + int.Parse(Row01["jobamt"].ToString()) + int.Parse(Row01["fundamt"].ToString());
                var h_exp = int.Parse(Row01["h_exp"].ToString());
                var h_exp1 = int.Parse(Row01["h_exp1"].ToString());
                var h_exp_total = int.Parse(Row01["h_exp"].ToString()) + int.Parse(Row01["h_exp1"].ToString());
                var r_exp = int.Parse(Row01["r_exp"].ToString());
                var r_exp1 = int.Parse(Row01["r_exp1"].ToString());
                var r_exp_total = int.Parse(Row01["r_exp"].ToString()) + int.Parse(Row01["r_exp1"].ToString());
                var g_exp = int.Parse(Row01["g_exp"].ToString());
                var g_exp1 = int.Parse(Row01["g_exp1"].ToString());
                var g_exp_total = int.Parse(Row01["g_exp"].ToString()) + int.Parse(Row01["g_exp1"].ToString());
                var oldret = int.Parse(Row01["oldret"].ToString());
                var bonus = int.Parse(Row01["bonus"].ToString());
                var fano = int.Parse(Row01["fano"].ToString());

                aRow["成本部門"] = Row01["depts"].ToString();
                aRow["部門名稱"] = Row01["ds_name"].ToString();
                aRow["員工編號"] = Row01["nobr"].ToString();
                aRow["員工姓名"] = Row01["name_c"].ToString();
                aRow["直間接"] = Row01["di"].ToString();
                aRow["分攤比率"] = Row01["rate"].ToString();
                aRow["勞保費個人"] = int.Parse(Row01["l_exp"].ToString());
                aRow["勞保費公司"] = int.Parse(Row01["l_exp1"].ToString());
                aRow["職業災害"] = int.Parse(Row01["jobamt"].ToString());
                aRow["墊償基金"] = int.Parse(Row01["fundamt"].ToString());
                aRow["勞保總計"] = int.Parse(Row01["l_exp"].ToString()) + int.Parse(Row01["l_exp1"].ToString()) + int.Parse(Row01["jobamt"].ToString()) + int.Parse(Row01["fundamt"].ToString());
                aRow["健保費個人"] = int.Parse(Row01["h_exp"].ToString());
                aRow["健保費公司"] = int.Parse(Row01["h_exp1"].ToString());
                aRow["健保費總計"] = int.Parse(Row01["h_exp"].ToString()) + int.Parse(Row01["h_exp1"].ToString());
                aRow["勞退金個人"] = int.Parse(Row01["r_exp"].ToString());
                aRow["勞退金公司"] = int.Parse(Row01["r_exp1"].ToString());
                aRow["勞退金總計"] = int.Parse(Row01["r_exp"].ToString()) + int.Parse(Row01["r_exp1"].ToString());
                aRow["團保費個人"] = int.Parse(Row01["g_exp"].ToString());
                aRow["團保費公司"] = int.Parse(Row01["g_exp1"].ToString());
                aRow["團保費總計"] = int.Parse(Row01["g_exp"].ToString()) + int.Parse(Row01["g_exp1"].ToString());
                aRow["退休金/舊制"] = int.Parse(Row01["oldret"].ToString());
                aRow["年節公司提撥"] = int.Parse(Row01["bonus"].ToString());
                aRow["健保眷屬人數"] = int.Parse(Row01["fano"].ToString());

                ExporDt.Rows.Add(aRow);

                //var costOfNobr = costList.Where(p => p.NOBR.Trim().ToUpper() == Row01["nobr"].ToString().Trim().ToUpper());
                //foreach (var it in costOfNobr)
                //{
                //    var depts = deptsList.FirstOrDefault(p => p.D_NO == it.DEPTS);
                //    if (depts == null) continue;
                //    DataRow aRowCost = ExporDt.NewRow();
                //    aRowCost["成本部門"] = depts.D_NO_DISP;
                //    aRowCost["部門名稱"] = depts.D_NAME;
                //    aRowCost["員工編號"] = Row01["nobr"].ToString();
                //    aRowCost["員工姓名"] = Row01["name_c"].ToString();
                //    aRowCost["直間接"] = Row01["di"].ToString();

                //    aRowCost["分攤比率"] = it.RATE;
                //    aRow["分攤比率"] = Convert.ToDecimal(aRow["分攤比率"]) - it.RATE;

                //    aRowCost["勞保費個人"] = Math.Floor(int.Parse(Row01["l_exp"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["勞保費個人"] = Convert.ToInt32(aRow["勞保費個人"]) - Convert.ToInt32(aRowCost["勞保費個人"]);
                //    aRowCost["勞保費公司"] = Math.Floor(int.Parse(Row01["l_exp1"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["勞保費公司"] = Convert.ToInt32(aRow["勞保費公司"]) - Convert.ToInt32(aRowCost["勞保費公司"]);
                //    aRowCost["職業災害"] = Math.Floor(int.Parse(Row01["jobamt"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["職業災害"] = Convert.ToInt32(aRow["職業災害"]) - Convert.ToInt32(aRowCost["職業災害"]);
                //    aRowCost["墊償基金"] = Math.Floor(int.Parse(Row01["fundamt"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["墊償基金"] = Convert.ToInt32(aRow["墊償基金"]) - Convert.ToInt32(aRowCost["墊償基金"]);
                //    //aRowCost["勞保總計"] = Math.Round(int.Parse(Row01["l_exp"].ToString()) + int.Parse(Row01["l_exp1"].ToString()) + int.Parse(Row01["jobamt"].ToString()) + int.Parse(Row01["fundamt"].ToString()) * it.RATE, MidpointRounding.AwayFromZero);
                //    aRowCost["勞保總計"] = Convert.ToInt32(aRowCost["勞保費個人"]) + Convert.ToInt32(aRowCost["勞保費公司"]) + Convert.ToInt32(aRowCost["職業災害"]) + Convert.ToInt32(aRowCost["墊償基金"]);
                //    aRow["勞保總計"] = Convert.ToInt32(aRow["勞保總計"]) - Convert.ToInt32(aRowCost["勞保總計"]);

                //    aRowCost["健保費個人"] = Math.Floor(int.Parse(Row01["h_exp"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["健保費個人"] = Convert.ToInt32(aRow["健保費個人"]) - Convert.ToInt32(aRowCost["健保費個人"]);
                //    aRowCost["健保費公司"] = Math.Floor(int.Parse(Row01["h_exp1"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["健保費公司"] = Convert.ToInt32(aRow["健保費公司"]) - Convert.ToInt32(aRowCost["健保費公司"]);

                //    //aRowCost["健保費總計"] = Math.Round(int.Parse(Row01["h_exp"].ToString()) + int.Parse(Row01["h_exp1"].ToString()) * it.RATE, MidpointRounding.AwayFromZero);
                //    aRowCost["健保費總計"] = Convert.ToInt32(aRowCost["健保費個人"]) + Convert.ToInt32(aRowCost["健保費公司"]);
                //    aRow["健保費總計"] = Convert.ToInt32(aRow["健保費總計"]) - Convert.ToInt32(aRowCost["健保費總計"]);

                //    aRowCost["勞退金個人"] = Math.Floor(int.Parse(Row01["r_exp"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["勞退金個人"] = Convert.ToInt32(aRow["勞退金個人"]) - Convert.ToInt32(aRowCost["勞退金個人"]);
                //    aRowCost["勞退金公司"] = Math.Floor(int.Parse(Row01["r_exp1"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["勞退金公司"] = Convert.ToInt32(aRow["勞退金公司"]) - Convert.ToInt32(aRowCost["勞退金公司"]);

                //    //aRowCost["勞退金總計"] = Math.Round(int.Parse(Row01["r_exp"].ToString()) + int.Parse(Row01["r_exp1"].ToString()) * it.RATE, MidpointRounding.AwayFromZero);
                //    aRowCost["勞退金總計"] = Convert.ToInt32(aRowCost["勞退金個人"]) + Convert.ToInt32(aRowCost["勞退金公司"]);
                //    aRow["勞退金總計"] = Convert.ToInt32(aRow["勞退金總計"]) - Convert.ToInt32(aRowCost["勞退金總計"]);

                //    aRowCost["團保費個人"] = Math.Floor(int.Parse(Row01["g_exp"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["團保費個人"] = Convert.ToInt32(aRow["團保費個人"]) - Convert.ToInt32(aRowCost["團保費個人"]);
                //    aRowCost["團保費公司"] = Math.Floor(int.Parse(Row01["g_exp1"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["團保費公司"] = Convert.ToInt32(aRow["團保費公司"]) - Convert.ToInt32(aRowCost["團保費公司"]);

                //    //aRowCost["團保費總計"] = Math.Round(int.Parse(Row01["g_exp"].ToString()) + int.Parse(Row01["g_exp1"].ToString()) * it.RATE, MidpointRounding.AwayFromZero);
                //    aRowCost["團保費總計"] = Convert.ToInt32(aRowCost["團保費個人"]) + Convert.ToInt32(aRowCost["團保費公司"]);
                //    aRow["團保費總計"] = Convert.ToInt32(aRow["團保費總計"]) - Convert.ToInt32(aRowCost["團保費總計"]);

                //    aRowCost["退休金/舊制"] = Math.Floor(int.Parse(Row01["oldret"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["退休金/舊制"] = Convert.ToInt32(aRow["退休金/舊制"]) - Convert.ToInt32(aRowCost["退休金/舊制"]);
                //    aRowCost["年節公司提撥"] = Math.Floor(int.Parse(Row01["bonus"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["年節公司提撥"] = Convert.ToInt32(aRow["年節公司提撥"]) - Convert.ToInt32(aRowCost["年節公司提撥"]);
                //    aRowCost["健保眷屬人數"] = Math.Floor(int.Parse(Row01["fano"].ToString()) * it.RATE); //, MidpointRounding.AwayFromZero);
                //    aRow["健保眷屬人數"] = Convert.ToInt32(aRow["健保眷屬人數"]) - Convert.ToInt32(aRowCost["健保眷屬人數"]);
                //    ExporDt.Rows.Add(aRowCost);
                //}
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void Export1(DataTable DT, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("成本部門", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("直間接", typeof(string));
            ExporDt.Columns.Add("人數", typeof(decimal));
            ExporDt.Columns.Add("勞保費個人", typeof(int));
            ExporDt.Columns.Add("勞保費公司", typeof(int));
            ExporDt.Columns.Add("職業災害", typeof(int));
            ExporDt.Columns.Add("墊償基金", typeof(int));
            ExporDt.Columns.Add("勞保總計", typeof(int));
            //增加【勞保公司總計】欄位 - Added By Daniel Chih - 2021/02/18
            ExporDt.Columns.Add("勞保公司總計", typeof(int));
            ExporDt.Columns.Add("健保費個人", typeof(int));
            ExporDt.Columns.Add("健保費公司", typeof(int));
            ExporDt.Columns.Add("健保費總計", typeof(int));
            ExporDt.Columns.Add("勞退金個人", typeof(int));
            ExporDt.Columns.Add("勞退金公司", typeof(int));
            ExporDt.Columns.Add("勞退金總計", typeof(int));
            ExporDt.Columns.Add("團保費個人", typeof(int));
            ExporDt.Columns.Add("團保費公司", typeof(int));
            ExporDt.Columns.Add("團保費總計", typeof(int));
            ExporDt.Columns.Add("退休金/舊制", typeof(int));
            ExporDt.Columns.Add("年節公司提撥", typeof(int));

            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow = ExporDt.NewRow();
                aRow["成本部門"] = Row01["depts"].ToString();
                aRow["部門名稱"] = Row01["ds_name"].ToString();
                aRow["直間接"] = Row01["di"].ToString();
                aRow["人數"] = decimal.Parse(Row01["pno"].ToString());
                aRow["勞保費個人"] = int.Parse(Row01["l_exp"].ToString());
                aRow["勞保費公司"] = int.Parse(Row01["l_exp1"].ToString());
                aRow["職業災害"] = int.Parse(Row01["jobamt"].ToString());
                aRow["墊償基金"] = int.Parse(Row01["fundamt"].ToString());
                aRow["勞保總計"] = int.Parse(Row01["l_exp"].ToString()) + int.Parse(Row01["l_exp1"].ToString()) + int.Parse(Row01["jobamt"].ToString()) + int.Parse(Row01["fundamt"].ToString());
                //增加【勞保公司總計】欄位 - Added By Daniel Chih - 2021/02/18
                aRow["勞保公司總計"] = int.Parse(Row01["l_exp1"].ToString()) + int.Parse(Row01["jobamt"].ToString()) + int.Parse(Row01["fundamt"].ToString());
                aRow["健保費個人"] = int.Parse(Row01["h_exp"].ToString());
                aRow["健保費公司"] = int.Parse(Row01["h_exp1"].ToString());
                aRow["健保費總計"] = int.Parse(Row01["h_exp"].ToString()) + int.Parse(Row01["h_exp1"].ToString());
                aRow["勞退金個人"] = int.Parse(Row01["r_exp"].ToString());
                aRow["勞退金公司"] = int.Parse(Row01["r_exp1"].ToString());
                aRow["勞退金總計"] = int.Parse(Row01["r_exp"].ToString()) + int.Parse(Row01["r_exp1"].ToString());
                aRow["團保費個人"] = int.Parse(Row01["g_exp"].ToString());
                aRow["團保費公司"] = int.Parse(Row01["g_exp1"].ToString());
                aRow["團保費總計"] = int.Parse(Row01["g_exp"].ToString()) + int.Parse(Row01["g_exp1"].ToString());
                aRow["退休金/舊制"] = int.Parse(Row01["oldret"].ToString());
                aRow["年節公司提撥"] = int.Parse(Row01["bonus"].ToString());

                ExporDt.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        #endregion

    }
}
