/* ======================================================================================================
 * 功能名稱：薪資傳票
 * 功能代號：ZZ4P
 * 功能路徑：報表列印 > 薪資 > 薪資傳票
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\SalForm\ZZ4PClass.cs
 * 功能用途：
 *  
 * 
 * 版本記錄：
 * ======================================================================================================
 *    日期           人員           版本           說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/04/19    Daniel Chih    Ver 1.0.01     1. 增加成本別的欄位內容
 * 2021/05/13    Daniel Chih    Ver 1.0.02     1. 清展：儲蓄金（外籍）不算入合計
 * 2021/11/04    Daniel Chih    Ver 1.0.03     1. 移除 Currency 欄位
 * 
 * 
 * ======================================================================================================
 * 
 * 最後修改：Daniel Chih (0492) - 2021/11/04
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;


namespace JBHR.Reports.SalForm
{
    class ZZ4PClass
    {
        public static void Get_Waged(DataTable DT_waged, DataTable DT_wage, DataTable DT_base, DataTable DT_salcode, DataTable DT_accsal, string comp_name)
        {
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
                    //string _di = row.IsNull("di") ? "" : row["di"].ToString().Trim();
                    //string _di = row.IsNull("subs") ? "" : row["subs"].ToString().Trim();
                    //string dicode = (string.IsNullOrEmpty(_di)) ? "" : row[_di + "_code"].ToString();
                    string dicode = row.IsNull("subs") ? "" : row["subs"].ToString().Trim();
                    Row["subs"] = dicode;
                    Row["di_code"] = dicode;
                    Row["comp"] = row1["comp"].ToString();
                    Row["compname"] = row1["compname"].ToString();
                    //Row["comp"] = row1["saladr"].ToString();
                    //Row["compname"] = row1["groupname"].ToString();
                    Row["account"] = row1["account"].ToString();
                    Row["deptscost"] = row["deptscost"].ToString();
                    Row["dept"] = row["dept"].ToString();
                    Row["d_name"] = row["d_name"].ToString();
                    Row["name_c"] = row["name_c"].ToString();
                    Row["name_e"] = row["name_e"].ToString();
                    Row["di"] = row["di"].ToString();
                    Row["cash"] = bool.Parse(row1["cash"].ToString());
                    Row["flag"] = row2["flag"].ToString();
                    Row["acc_tr"] = row2["acc_tr"].ToString();
                    Row["type"] = row2["type"].ToString();
                    Row["sal_attr"] = row2["sal_attr"].ToString();
                    Row["sal_name"] = row2["sal_name"].ToString();
                    Row["acccd_disp"] = row2["acccd_disp"].ToString();
                    Row["acccd"] = row2["acccd"].ToString();
                    Row["accname"] = row2["accname"].ToString();
                    Row["accname_o"] = row2["accname"].ToString();
                    Row["sal_code_disp"] = row2["sal_code_disp"].ToString();
                    Row["accode"] = (string.IsNullOrEmpty(row2["accdr"].ToString())) ? row2["acccr"].ToString() : row2["accdr"].ToString();
                    Row["accode_c"] = row2["acccr"].ToString(); //貸方
                    Row["accode_d"] = row2["accdr"].ToString(); //借方
                    Row["disp_costname"] = (row1["saladr"].ToString().Substring(0, 1) == "C") ? bool.Parse("false") : bool.Parse("true");
                    Row["saladr"] = row1["saladr"].ToString();
                    object[] _value1 = new object[2];
                    _value1[0] = Row["di_code"].ToString();
                    _value1[1] = Row["acccd"].ToString();
                    DataRow row3 = DT_accsal.Rows.Find(_value1);
                    if (row3 != null)
                    {
                        if (row3.IsNull("code_c")) row3["code_c"] = "";
                        if (row3.IsNull("code_d")) row3["code_d"] = "";
                        //if (row3.IsNull("merge_accname")) row3["merge_accname"] = "";
                        string _costtypename = (bool.Parse(Row["disp_costname"].ToString())) ? row3["costtypename"].ToString().Trim() + "-" : "";
                        //Row["disp_costname"] = (row3.IsNull("disp_costname")) ? bool.Parse("false") : bool.Parse(row3["disp_costname"].ToString());
                        //Row["accname"] = (string.IsNullOrEmpty(row3["merge_accname"].ToString())) ? row3["costtypename"].ToString().Trim() + "-" + Row["accname_o"].ToString().Trim() : row3["costtypename"].ToString().Trim() + "-" + row3["merge_accname"].ToString().Trim();                        
                        Row["accname"] = (string.IsNullOrEmpty(row3["merge_accname"].ToString())) ? _costtypename + Row["accname_o"].ToString().Trim() : _costtypename + row3["merge_accname"].ToString().Trim();
                        //Row["accode"] = row3["code_d"].ToString().Trim() + Row["accode"].ToString();
                        //Row["accode_c"] = row3["code_d"].ToString().Trim() + row2["acccr"].ToString(); //貸方
                        //Row["accode_d"] = row3["code_d"].ToString().Trim() + row2["accdr"].ToString(); //借方
                        Row["dbcr"] = (string.IsNullOrEmpty(row3["code_c"].ToString())) ? "1" : "2";
                        Row["accode"] = (string.IsNullOrEmpty(row3["code_c"].ToString())) ? row3["code_d"].ToString().Trim() : row3["code_c"].ToString().Trim();

                        //Row["accode_c"] = row2["acccr"].ToString(); //貸方
                        //Row["accode_d"] = row2["accdr"].ToString(); //借方
                        if (Row["dbcr"].ToString() == "1")
                        {
                            Row["accode_c"] = row3["acccr"].ToString().Trim();  //accode_c
                            Row["accode_d"] = row3["code_d"].ToString().Trim();
                        }
                        else
                        {
                            Row["accode_c"] = row3["code_c"].ToString().Trim();  //accode_c
                            Row["accode_d"] = row3["accdr"].ToString().Trim();
                        }
                    }
                    Row["account_no"] = row1["account_no"].ToString();
                    //Row["entity1"] = row1["entity1"].ToString();
                    //Row["entity2"] = row1["entity2"].ToString();
                    //Row["LegalPerson"] = row1["LegalPerson"].ToString();
                    //Row["Currency"] = row1["Currency"].ToString();
                    Row["o_amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));

                    if (comp_name == "清展科技有限公司")
                    {
                        if (Row["flag"].ToString().Trim() == "-")
                        {
                            if (Row["sal_code"].ToString().Trim() != "B06")
                            {
                                Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                            }
                            else
                            {
                                Row["amt"] = 0;
                            }
                        }

                        else
                        {
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                        }
                    }
                    else
                    {
                        if (Row["flag"].ToString().Trim() == "-")
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString())) * (-1);
                        else
                            Row["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(Row["amt"].ToString()));
                    }
                }
                else
                    Row.Delete();
            }
            DT_waged.AcceptChanges();
        }

        public static void Get_CostAmt(DataTable DT_costamt, DataTable DT_waged, DataTable DT_cost, DataTable DT_costtype, DataTable DT_accsal, DataTable DT_depts, DataTable DT_base, string seq)
        {
            foreach (DataRow Row in DT_waged.Rows)
            {
                DataRow rowb = DT_base.Rows.Find(Row["nobr"].ToString());
                DataRow[] SRow1 = DT_cost.Select("nobr='" + Row["nobr"].ToString() + "'");

                DataRow row_depts = DT_depts.Rows.Find(Row["deptscost"].ToString());

                string _saladr = Row["saladr"].ToString().Substring(0, 1);
                string _di = Row["di"].ToString();
                decimal _diff = decimal.Parse(Row["o_amt"].ToString());
                if (SRow1.Length > 0)
                {
                    for (int i = 0; i < SRow1.Length; i++)
                    {
                        DataRow aRow = DT_costamt.NewRow();
                        aRow["comp"] = Row["comp"].ToString();
                        aRow["compname"] = Row["compname"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = Row["name_c"].ToString();

                        if(Row["di"].ToString().Trim() == "D" && row_depts != null)
                        {
                            aRow["di"] = row_depts["d_name"].ToString().Trim();
                        }
                        else if (Row["di"].ToString().Trim() == "I" && row_depts != null)
                        {
                            aRow["di"] = row_depts["i_name"].ToString().Trim();
                        }
                        else
                        {
                            aRow["di"] = "".ToString().Trim();
                        }

                        aRow["depts"] = SRow1[i]["depts"].ToString();
                        aRow["ds_name"] = SRow1[i]["d_name"].ToString();
                        aRow["sal_code"] = Row["sal_code"].ToString();
                        aRow["sal_code_disp"] = Row["sal_code_disp"].ToString();
                        aRow["sal_name"] = Row["sal_name"].ToString();
                        aRow["accname"] = Row["accname_o"].ToString();
                        aRow["accode"] = "";
                        aRow["accode_c"] = "";
                        aRow["accode_d"] = "";
                        aRow["disp_costname"] = bool.Parse(Row["disp_costname"].ToString());
                        //DataRow row1 = DT_depts.Rows.Find(SRow1[i]["d_no"].ToString());
                        aRow["costtype"] = (SRow1[i].IsNull("subs")) ? "" : SRow1[i]["subs"].ToString();
                        aRow["meno"] = Row["meno"].ToString();
                        aRow["empcd"] = rowb["empcd"].ToString();
                        object[] _value1 = new object[2];
                        _value1[0] = aRow["costtype"].ToString();
                        _value1[1] = Row["acccd"].ToString();
                        DataRow row3 = DT_accsal.Rows.Find(_value1);
                        if (row3 != null)
                        {
                            if (row3.IsNull("code_c")) row3["code_c"] = "";
                            if (row3.IsNull("code_d")) row3["code_d"] = "";
                            if (row3.IsNull("merge_accname")) row3["merge_accname"] = "";
                            string _costtypename = (bool.Parse(Row["disp_costname"].ToString())) ? row3["costtypename"].ToString().Trim() + "-" : "";
                            //aRow["accname"] = (bool.Parse(Row["disp_costname"].ToString())) ? Row["accname_o"].ToString().Trim() : row3["costtypename"].ToString().Trim() + "-" + Row["accname_o"].ToString().Trim();
                            //aRow["accname"] = (string.IsNullOrEmpty(row3["merge_accname"].ToString())) ? row3["costtypename"].ToString().Trim() + "-" + Row["accname_o"].ToString().Trim() : row3["costtypename"].ToString().Trim() + "-" + row3["merge_accname"].ToString().Trim();
                            aRow["accname"] = (string.IsNullOrEmpty(row3["merge_accname"].ToString())) ? _costtypename + Row["accname_o"].ToString().Trim() : _costtypename + row3["merge_accname"].ToString().Trim();
                            aRow["dbcr"] = (string.IsNullOrEmpty(row3["code_c"].ToString())) ? "1" : "2";
                            aRow["accode"] = (string.IsNullOrEmpty(row3["code_c"].ToString())) ? row3["code_d"].ToString().Trim() : row3["code_c"].ToString().Trim();
                            aRow["accode_c"] = row3["code_c"].ToString().Trim();  //accode_c
                            aRow["accode_d"] = row3["code_d"].ToString().Trim();

                        }
                        aRow["costname"] = "";
                        aRow["rate"] = decimal.Parse(SRow1[i]["rate"].ToString());

                        aRow["amt"] = Math.Round(decimal.Parse(Row["amt"].ToString()) * decimal.Parse(SRow1[i]["rate"].ToString()), MidpointRounding.AwayFromZero);
                        aRow["o_amt"] = Math.Round(decimal.Parse(Row["o_amt"].ToString()) * decimal.Parse(SRow1[i]["rate"].ToString()), MidpointRounding.AwayFromZero);

                        ////外幣（人民幣）匯率
                        //if (Row["Currency"].ToString() == "RMB")
                        //{
                        //    aRow["amt"] = Math.Round(decimal.Parse(Row["amt"].ToString()) * decimal.Parse(SRow1[i]["rate"].ToString()), 2, MidpointRounding.AwayFromZero);
                        //    aRow["o_amt"] = Math.Round(decimal.Parse(Row["o_amt"].ToString()) * decimal.Parse(SRow1[i]["rate"].ToString()), 2, MidpointRounding.AwayFromZero);
                        //}

                        _diff -= decimal.Parse(aRow["o_amt"].ToString());
                        if (i == SRow1.Length - 1)
                        {
                            aRow["o_amt"] = decimal.Parse(aRow["o_amt"].ToString()) + _diff;
                            aRow["amt"] = (Row["flag"].ToString().Trim() == "-") ? decimal.Parse(aRow["o_amt"].ToString()) * (-1) : decimal.Parse(aRow["amt"].ToString()) + _diff;
                        }
                        aRow["flag"] = Row["flag"].ToString();
                        //aRow["entity1"] = Row["entity1"].ToString();
                        //aRow["entity2"] = Row["entity2"].ToString();
                        //aRow["LegalPerson"] = Row["LegalPerson"].ToString();
                        //aRow["Currency"] = Row["Currency"].ToString();
                        DT_costamt.Rows.Add(aRow);
                    }
                }
                else
                {
                    DataRow aRow = DT_costamt.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();

                    if (Row["di"].ToString().Trim() == "D" && row_depts != null)
                    {
                        aRow["di"] = row_depts["d_name"].ToString().Trim();
                    }
                    else if (Row["di"].ToString().Trim() == "I" && row_depts != null)
                    {
                        aRow["di"] = row_depts["i_name"].ToString().Trim();
                    }
                    else
                    {
                        aRow["di"] = "".ToString().Trim();
                    }

                    aRow["depts"] = Row["dept"].ToString();
                    aRow["ds_name"] = Row["d_name"].ToString();
                    aRow["sal_code"] = Row["sal_code"].ToString();
                    aRow["sal_code_disp"] = Row["sal_code_disp"].ToString();
                    aRow["sal_name"] = Row["sal_name"].ToString();
                    aRow["costtype"] = Row["di_code"].ToString();
                    aRow["accname"] = Row["accname"].ToString().Trim();
                    aRow["accode"] = Row["acccd_disp"].ToString().Trim();
                    aRow["accode_c"] = Row["accode_c"].ToString().Trim();  //accode_c
                    aRow["accode_d"] = Row["accode_d"].ToString().Trim();
                    aRow["costname"] = "";
                    aRow["disp_costname"] = (_saladr == "C") ? bool.Parse("false") : bool.Parse("true");
                    aRow["rate"] = 1M;
                    aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    aRow["o_amt"] = decimal.Parse(Row["o_amt"].ToString());
                    //aRow["entity1"] = Row["entity1"].ToString();
                    //aRow["entity2"] = Row["entity2"].ToString();
                    //aRow["LegalPerson"] = Row["LegalPerson"].ToString();
                    //aRow["Currency"] = Row["Currency"].ToString();
                    aRow["dbcr"] = Row["dbcr"].ToString();
                    aRow["flag"] = Row["flag"].ToString();
                    aRow["meno"] = Row["meno"].ToString();
                    aRow["empcd"] = rowb["empcd"].ToString();
                    DT_costamt.Rows.Add(aRow);
                }              

            }

            foreach (DataRow Row in DT_costamt.Rows)
            {
                DataRow row = DT_costtype.Rows.Find(Row["costtype"].ToString());
                if (row != null && bool.Parse(Row["disp_costname"].ToString()))
                {
                    Row["costname"] = row["costtypename"].ToString();
                }
                //Row["depts"] = Row["LegalPerson"].ToString() + Row["depts"].ToString();
            }



            DataView resortDT = DT_costamt.DefaultView;
            resortDT.Sort = "depts, accode";
            DataTable Final_ExportDt = resortDT.ToTable();

            DT_costamt.Clear();
            DT_costamt.Merge(Final_ExportDt);
            DT_costamt.AcceptChanges();
        }

        public static void ExcelCostAmt(DataTable DT_costamt, DataTable DT_base)
        {
            //rq_costamt.Columns.Add("comp", typeof(string));
            //rq_costamt.Columns.Add("compname", typeof(string));
            //rq_costamt.Columns.Add("nobr", typeof(string));
            //rq_costamt.Columns.Add("name_c", typeof(string));
            //rq_costamt.Columns.Add("depts", typeof(string));
            //rq_costamt.Columns.Add("ds_name", typeof(string));
            ////rq_costamt.Columns.Add("acccd", typeof(string));
            //rq_costamt.Columns.Add("accode", typeof(string));
            //rq_costamt.Columns.Add("accname", typeof(string));
            //rq_costamt.Columns.Add("dbcr", typeof(string)); //1借方,2貸方
            //rq_costamt.Columns.Add("accode_d", typeof(string)); //借方
            //rq_costamt.Columns.Add("accode_c", typeof(string)); //貸方
            //rq_costamt.Columns.Add("sal_code", typeof(string));
            //rq_costamt.Columns.Add("sal_name", typeof(string));
            //rq_costamt.Columns.Add("costtype", typeof(string));
            //rq_costamt.Columns.Add("costname", typeof(string));
            //rq_costamt.Columns.Add("rate", typeof(decimal));
            //rq_costamt.Columns.Add("amt", typeof(decimal));
            //rq_costamt.Columns.Add("o_amt", typeof(decimal));
            //rq_costamt.Columns.Add("Currency", typeof(string));
            //rq_costamt.Columns.Add("flag", typeof(string));
            //rq_costamt.Columns.Add("subs", typeof(string));
            DataTable DT = new DataTable();
            DT.Columns.Add("公司代碼", typeof(string));
            DT.Columns.Add("公司名稱", typeof(string));
            DT.Columns.Add("員工編號", typeof(string));
            DT.Columns.Add("員工姓名", typeof(string));
            DT.Columns.Add("原部門代碼", typeof(string));
            DT.Columns.Add("原部門名稱", typeof(string));
            DT.Columns.Add("成本部門", typeof(string));
            DT.Columns.Add("成本名稱", typeof(string));
            DT.Columns.Add("會科", typeof(string));
            DT.Columns.Add("會科摘要", typeof(string));
            DT.Columns.Add("借貸", typeof(string)); //1借方,2貸方            
            DT.Columns.Add("薪資代碼", typeof(string));
            DT.Columns.Add("薪資名稱", typeof(string));
            DT.Columns.Add("成本別代碼", typeof(string));
            DT.Columns.Add("成本別名稱", typeof(string));
            DT.Columns.Add("分攤率比率", typeof(decimal));
            DT.Columns.Add("分攤金額", typeof(decimal));
            //DT.Columns.Add("CFT小組", typeof(string));

            foreach (DataRow Row in DT_costamt.Rows)
            {
                DataRow aRow = DT.NewRow();
                aRow["公司代碼"] = Row["comp"].ToString();
                aRow["公司名稱"] = Row["compname"].ToString();
                aRow["員工編號"] = Row["nobr"].ToString();
                aRow["員工姓名"] = Row["name_c"].ToString();
                DataRow row = DT_base.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    aRow["原部門代碼"] = row["dept"].ToString();
                    aRow["原部門名稱"] = row["d_name"].ToString();
                }
                aRow["成本部門"] = Row["depts"].ToString();
                aRow["成本名稱"] = Row["ds_name"].ToString();
                aRow["會科"] = Row["accode"].ToString();
                aRow["會科摘要"] = (string.IsNullOrEmpty(Row["meno"].ToString())) ? Row["accname"].ToString() : Row["meno"].ToString();
                aRow["借貸"] = Row["dbcr"].ToString();
                aRow["薪資代碼"] = Row["sal_code"].ToString();
                aRow["薪資名稱"] = Row["sal_name"].ToString();
                aRow["成本別代碼"] = Row["costtype"].ToString();
                aRow["成本別名稱"] = Row["costname"].ToString();
                aRow["分攤率比率"] = decimal.Parse(Row["rate"].ToString());
                aRow["分攤金額"] = decimal.Parse(Row["amt"].ToString());
                //aRow["CFT小組"] = Row["subs"].ToString();
                DT.Rows.Add(aRow);
            }
            JBHR.Reports.ReportClass.Export(DT, "傳票分攤明細資料");
        }

        public static void Get_Dbcr(DataTable DT_dbcr, DataTable DT_sumamt, DataTable DT_costamt, DataTable DT_compacc, DataTable DT_explab, string yy, string mm, string seq)
        {
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ4P", MainForm.COMPANY);           
            DataTable rq_comp = new DataTable();
            rq_comp.Columns.Add("comp", typeof(string));
            //rq_comp.Columns.Add("Currency", typeof(string));
            rq_comp.PrimaryKey = new DataColumn[] { rq_comp.Columns["comp"] };


            DataColumn[] _key = new DataColumn[4];
            //_key[0] = DT_dbcr.Columns["comp"];
            _key[0] = DT_dbcr.Columns["depts"];
            _key[1] = DT_dbcr.Columns["accode"];
            _key[2] = DT_dbcr.Columns["accname"];
            _key[3] = DT_dbcr.Columns["di"];
            DT_dbcr.PrimaryKey = _key;
            string _accname1 = ""; string sumname = "";
            DataTable rq_sumamt = new DataTable();
            rq_sumamt = DT_sumamt.Clone();
            rq_sumamt.PrimaryKey = new DataColumn[] { rq_sumamt.Columns["accode"], rq_sumamt.Columns["accname"], rq_sumamt.Columns["type"] };
            foreach (DataRow Row in DT_costamt.Rows)
            {
                string[] _accname = Row["accname"].ToString().Split('-');
                object[] _value = new object[4];
                //_value[0] = Row["comp"].ToString();
                string salcode = Row["sal_code"].ToString().Trim();
                _value[0] = Row["depts"].ToString();
                _value[1] = Row["accode"].ToString();
                _value[2] = Row["accname"].ToString();
                _value[3] = Row["di"].ToString();

                DataRow row = DT_dbcr.Rows.Find(_value);
                if (row != null)
                {
                    row["amt"] = (Row["dbcr"].ToString().Trim() == "1") ? decimal.Parse(row["amt"].ToString()) + decimal.Parse(Row["amt"].ToString()) : decimal.Parse(row["amt"].ToString()) + (decimal.Parse(Row["amt"].ToString()) * (-1));
                }
                else
                {
                    DataRow aRow = DT_dbcr.NewRow();
                    aRow["type"] = "1";
                    aRow["comp"] = "";
                    aRow["compname"] = "";
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["ds_name"] = Row["ds_name"].ToString();
                    aRow["di"] = Row["di"].ToString().Trim();
                    aRow["accode"] = Row["accode"].ToString();
                    aRow["accname"] = Row["accname"].ToString();
                    aRow["meno"] = (string.IsNullOrEmpty(Row["meno"].ToString())) ? yy + "年" + mm + "月" + Row["accname"].ToString() : yy + "年" + mm + "月" + Row["meno"].ToString();
                    aRow["dbcr"] = Row["dbcr"].ToString();
                    aRow["amt"] = (Row["dbcr"].ToString().Trim() == "1") ? decimal.Parse(Row["amt"].ToString()) : decimal.Parse(Row["amt"].ToString()) * (-1);
                    //aRow["supplier"] = (salcode == "N04") ? "" : AppConfig.GetConfig(salcode).Value;
                    //aRow["entity1"] = Row["entity1"].ToString();
                    //aRow["entity2"] = Row["entity2"].ToString();
                    //aRow["LegalPerson"] = Row["LegalPerson"].ToString();
                    //aRow["Currency"] = Row["Currency"].ToString();
                    DT_dbcr.Rows.Add(aRow);
                }

                string sumaccode = string.Empty;
                string _sumaccname = string.Empty;
                string _sumsupplier = string.Empty;
                sumaccode = AppConfig.GetConfig("Payable").Value;  //應付薪資"21910000"
                _sumaccname = "應付薪資";

                object[] _value1 = new object[3];
                _value1[0] = sumaccode;
                _value1[1] = _sumaccname;
                _value1[2] = "1";
                DataRow row1 = rq_sumamt.Rows.Find(_value1);
                if (row1 != null)
                {
                    row1["amt"] = decimal.Parse(row1["amt"].ToString()) + decimal.Parse(Row["amt"].ToString());
                }
                else
                {
                    DataRow aRow = rq_sumamt.NewRow();
                    aRow["type"] = "1";
                    aRow["comp"] = "";
                    aRow["compname"] = "";
                    aRow["depts"] = "";
                    aRow["ds_name"] = "";
                    aRow["accode"] = sumaccode;                   
                    aRow["accname"] = _sumaccname;
                    aRow["meno"] = "支" + yy + "年" + mm + "月" + _sumaccname;
                    aRow["dbcr"] = "2";
                    aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    //aRow["supplier"] = _sumsupplier;
                    //aRow["entity1"] = Row["entity1"].ToString();
                    //aRow["entity2"] = Row["entity2"].ToString();
                    //aRow["LegalPerson"] = Row["LegalPerson"].ToString();
                    //aRow["Currency"] = Row["Currency"].ToString();
                    rq_sumamt.Rows.Add(aRow);
                    _accname1 = (_accname.Length > 1) ? _accname[1].ToString() : "";
                }

                DataRow row2 = rq_comp.Rows.Find(Row["comp"].ToString());
                if (row2 == null)
                {
                    DataRow aRow1 = rq_comp.NewRow();
                    aRow1["comp"] = Row["comp"].ToString();
                    rq_comp.Rows.Add(aRow1);
                }
            }

            //公司負擔
            foreach (DataRow Row in DT_explab.Rows)
            {
                string[] _accname = Row["accname"].ToString().Split('-');
                object[] _value = new object[4];
                //_value[0] = Row["comp"].ToString();
                string salcode = Row["sal_code"].ToString().Trim();
                _value[0] = Row["depts"].ToString();
                _value[1] = Row["accode"].ToString();
                _value[2] = Row["accname"].ToString();
                _value[3] = Row["di"].ToString();

                DataRow row = DT_dbcr.Rows.Find(_value);
                if (row != null)
                {
                    row["amt"] = decimal.Parse(row["amt"].ToString()) + decimal.Parse(Row["amt"].ToString());
                }
                else
                {
                    DataRow aRow = DT_dbcr.NewRow();
                    aRow["type"] = "2";
                    aRow["comp"] = "";
                    aRow["compname"] = "";
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["ds_name"] = Row["ds_name"].ToString();
                    aRow["accode"] = Row["accode"].ToString();
                    aRow["accname"] = Row["accname"].ToString();
                    //aRow["meno"] = yy + "年" + mm + "月" + Row["accname"].ToString();
                    aRow["meno"] = (string.IsNullOrEmpty(Row["meno"].ToString())) ? yy + "年" + mm + "月" + Row["accname"].ToString() : yy + "年" + mm + "月" + Row["meno"].ToString();
                    aRow["dbcr"] = "1";
                    aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    //aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    aRow["supplier"] = "";
                    aRow["entity1"] = Row["entity1"].ToString();
                    aRow["entity2"] = Row["entity2"].ToString();
                    aRow["LegalPerson"] = Row["LegalPerson"].ToString();
                    aRow["Currency"] = Row["Currency"].ToString();
                    DT_dbcr.Rows.Add(aRow);
                }

                string sumaccode = AppConfig.GetConfig("BearLab").Value;    //勞健保負擔"61200000"
                string _flag = Row["flag"].ToString().Trim();
                if (_flag == "4")
                    sumaccode = AppConfig.GetConfig("BearRet").Value;   //勞退負擔"61110312"
                string salname = Row["sal_name"].ToString();
                object[] _value1 = new object[3];
                _value1[0] = sumaccode;
                _value1[1] = salname;  //"健保局"
                _value1[2] = "2";
                DataRow row1 = rq_sumamt.Rows.Find(_value1);
                if (row1 != null)
                {
                    row1["amt"] = decimal.Parse(row1["amt"].ToString()) + decimal.Parse(Row["amt"].ToString());
                }
                else
                {
                    DataRow aRow = rq_sumamt.NewRow();
                    aRow["type"] = "2";
                    aRow["comp"] = "";
                    aRow["compname"] = "";
                    aRow["depts"] = "";
                    aRow["ds_name"] = "";
                    aRow["accode"] = sumaccode;
                    //aRow["accname"] = "支" + "年" + mm + "月份薪資";
                    //aRow["accname"] = _accname[1].ToString();
                    //aRow["accname"] = _accname[1].ToString();                   
                    aRow["accname"] = salname;
                    aRow["meno"] = yy + "年" + mm + "月" + salname + "公司負擔";
                    aRow["dbcr"] = "2";
                    aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    aRow["supplier"] = AppConfig.GetConfig("CompIns").Value; ;
                    aRow["entity1"] = Row["entity1"].ToString();
                    aRow["entity2"] = Row["entity2"].ToString();
                    aRow["LegalPerson"] = Row["LegalPerson"].ToString();
                    aRow["Currency"] = Row["Currency"].ToString();
                    rq_sumamt.Rows.Add(aRow);
                    _accname1 = (_accname.Length > 1) ? _accname[1].ToString() : "";
                }
            }

            foreach (DataRow Row in rq_sumamt.Rows)
            {
                DT_sumamt.ImportRow(Row);
            }

            rq_comp = null; rq_sumamt = null;


        }

        public static void Get_Dbcr1(DataTable DT_dbcr, DataTable DT_sumamt, DataTable DT_comp, DataTable DT_costamt, DataTable DT_compacc, DataTable DT_explab, string yy, string mm, string seq)
        {
            JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("ZZ4P", MainForm.COMPANY);            

            DataColumn[] _key = new DataColumn[4];
            _key[0] = DT_dbcr.Columns["comp"];
            _key[1] = DT_dbcr.Columns["depts"];
            _key[2] = DT_dbcr.Columns["accode"];
            _key[3] = DT_dbcr.Columns["accname"];
            DT_dbcr.PrimaryKey = _key;
            string _accname1 = "";
            DataTable rq_sumamt = new DataTable();
            rq_sumamt = DT_sumamt.Clone();
            rq_sumamt.PrimaryKey = new DataColumn[] { rq_sumamt.Columns["comp"], rq_sumamt.Columns["accode"], rq_sumamt.Columns["accname"], rq_sumamt.Columns["type"] };

            DataTable rq_explabcn = new DataTable();
            //rq_explabcn.Columns.Add("insur_type", typeof(string));
            rq_explabcn.Columns.Add("comp", typeof(string));
            rq_explabcn.Columns.Add("compname", typeof(string));
            rq_explabcn.Columns.Add("acccd", typeof(string));
            rq_explabcn.Columns.Add("accname", typeof(string));
            rq_explabcn.Columns.Add("amt", typeof(decimal));
            rq_explabcn.Columns.Add("meno", typeof(string));
            rq_explabcn.Columns.Add("Currency", typeof(string));
            rq_explabcn.PrimaryKey = new DataColumn[] { rq_explabcn.Columns["acccd"], rq_explabcn.Columns["comp"] };
            DataTable rq_explabcn1 = new DataTable();
            rq_explabcn1 = rq_explabcn.Clone();

            string sumaccode = string.Empty;
            string _sumaccname = string.Empty;
            string _sumsupplier = string.Empty;
            sumaccode = AppConfig.GetConfig("Payable").Value;  //應付薪資"21910000"

            foreach (DataRow Row in DT_costamt.Rows)
            {
                //Row["comp"] = Row["LegalPerson"].ToString();
                string salcode = Row["sal_code_disp"].ToString().Trim();
                string[] _accname = Row["accname"].ToString().Split('-');
                object[] _value = new object[4];
                string sumname = "";
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["depts"].ToString();
                _value[2] = Row["accode"].ToString();
                _value[3] = Row["accname"].ToString();
                DataRow row = DT_dbcr.Rows.Find(_value);
                if (row != null)
                {
                    row["amt"] = (Row["dbcr"].ToString().Trim() == "1") ? decimal.Parse(row["amt"].ToString()) + decimal.Parse(Row["amt"].ToString()) : decimal.Parse(row["amt"].ToString()) + (decimal.Parse(Row["amt"].ToString()) * (-1));
                    //row["amt"] = decimal.Parse(row["amt"].ToString()) + decimal.Parse(Row["amt"].ToString());
                }
                else
                {
                    DataRow aRow = DT_dbcr.NewRow();
                    aRow["type"] = "1";
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["ds_name"] = Row["ds_name"].ToString();
                    aRow["di"] = Row["di"].ToString().Trim();
                    aRow["accode"] = Row["accode"].ToString();
                    aRow["accname"] = Row["accname"].ToString();
                    //aRow["meno"] = yy + "年" + mm + "月" + Row["accname"].ToString();
                    aRow["meno"] = (string.IsNullOrEmpty(Row["meno"].ToString())) ? yy + "年" + mm + "月" + Row["accname"].ToString() : yy + "年" + mm + "月" + Row["meno"].ToString();
                    aRow["dbcr"] = Row["dbcr"].ToString();
                    aRow["amt"] = (Row["dbcr"].ToString().Trim() == "1") ? decimal.Parse(Row["amt"].ToString()) : decimal.Parse(Row["amt"].ToString()) * (-1);
                    //aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    //aRow["supplier"] = (salcode == "N04") ? AppConfig.GetConfig(salcode).Value : "";
                    //aRow["entity1"] = Row["entity1"].ToString();
                    //aRow["entity2"] = Row["entity2"].ToString();
                    //aRow["LegalPerson"] = Row["LegalPerson"].ToString();
                    //aRow["Currency"] = Row["Currency"].ToString();
                    DT_dbcr.Rows.Add(aRow);
                }


                
                _sumaccname = "應付薪資";
                
                object[] _value1 = new object[4];
                _value1[0] = Row["comp"].ToString();
                _value1[1] = sumaccode;
                _value1[2] = _sumaccname;
                _value1[3] = "1";
                DataRow row1 = rq_sumamt.Rows.Find(_value1);
                if (row1 != null)
                {
                    row1["amt"] = decimal.Parse(row1["amt"].ToString()) + decimal.Parse(Row["amt"].ToString());
                }
                else
                {
                    DataRow aRow = rq_sumamt.NewRow();
                    aRow["type"] = "1";
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["depts"] = "";
                    aRow["ds_name"] = "";
                    aRow["accode"] = sumaccode;
                    //aRow["accname"] = "支" + "年" + mm + "月份薪資";
                    //aRow["accname"] = _accname[1].ToString();                   
                    aRow["accname"] = _sumaccname;
                    aRow["meno"] = yy + "年" + mm + "月" + _sumaccname;
                    aRow["dbcr"] = "2";
                    aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    //aRow["supplier"] = _sumsupplier;
                    //aRow["entity1"] = Row["entity1"].ToString();
                    //aRow["entity2"] = Row["entity2"].ToString();
                    //aRow["LegalPerson"] = Row["LegalPerson"].ToString();
                    //aRow["Currency"] = Row["Currency"].ToString();
                    rq_sumamt.Rows.Add(aRow);
                    _accname1 = (_accname.Length > 1) ? _accname[1].ToString() : "";
                }


                DataRow row2 = DT_comp.Rows.Find(Row["comp"].ToString());
                if (row2 == null)
                {
                    DataRow aRow = DT_comp.NewRow();
                    aRow["comp"] = Row["comp"].ToString();
                    DT_comp.Rows.Add(aRow);
                    ////DataRow[] SRow1 = DT_compacc.Select("comp='" + Row["comp"].ToString() + "' and accname='" + _accname1 + "'");
                    ////if (DT_sumamt.Rows.Count > 0)
                    ////{
                    ////    DT_sumamt.Rows[0]["accode"] = (SRow1.Length > 0) ? SRow1[0]["accode_c"].ToString() : "";
                    ////}


                }
            }

            //公司負擔
            string sumaccode1 = AppConfig.GetConfig("BearLab").Value;   //勞健保負擔"61200000"
            foreach (DataRow Row in DT_explab.Rows)
            {
                Row["comp"] = Row["LegalPerson"].ToString();
               
                string _flag = Row["flag"].ToString().Trim();
                if (_flag == "4")
                    sumaccode1 = AppConfig.GetConfig("BearRet").Value;   //勞退負擔61110312
                string salname = Row["sal_name"].ToString();

                string[] _accname = Row["accname"].ToString().Split('-');
                object[] _value = new object[4];
                //_value[0] = Row["comp"].ToString();
                string salcode = Row["sal_code"].ToString().Trim();
                _value[0] = Row["comp"].ToString();
                _value[1] = Row["depts"].ToString();
                _value[2] = sumaccode1;   // _value[2] = Row["accode"].ToString();
                _value[3] = Row["accname"].ToString();

                DataRow row = DT_dbcr.Rows.Find(_value);
                if (row != null)
                {
                    row["amt"] = decimal.Parse(row["amt"].ToString()) + decimal.Parse(Row["amt"].ToString());
                }
                else
                {
                    DataRow aRow = DT_dbcr.NewRow();
                    aRow["type"] = "2";
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["ds_name"] = Row["ds_name"].ToString();
                    aRow["accode"] = sumaccode1;  // Row["accode"].ToString()
                    aRow["accname"] = Row["accname"].ToString();
                    //aRow["meno"] = yy + "年" + mm + "月" + Row["accname"].ToString();
                    aRow["meno"] = (string.IsNullOrEmpty(Row["meno"].ToString())) ? yy + "年" + mm + "月" + Row["accname"].ToString() : yy + "年" + mm + "月" + Row["meno"].ToString();
                    aRow["dbcr"] = "1";
                    aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    //aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    aRow["supplier"] = "";
                    aRow["entity1"] = Row["entity1"].ToString();
                    aRow["entity2"] = Row["entity2"].ToString();
                    aRow["LegalPerson"] = Row["LegalPerson"].ToString();
                    aRow["Currency"] = Row["Currency"].ToString();
                    DT_dbcr.Rows.Add(aRow);
                }

                object[] _value1 = new object[4];
                _value1[0] = Row["comp"].ToString();
                _value1[1] = sumaccode1;
                _value1[2] = salname;
                _value1[3] = "2";
                DataRow row1 = rq_sumamt.Rows.Find(_value1);
                if (row1 != null)
                {
                    row1["amt"] = decimal.Parse(row1["amt"].ToString()) + decimal.Parse(Row["amt"].ToString());
                }
                else
                {
                    DataRow aRow = rq_sumamt.NewRow();
                    aRow["type"] = "2";
                    aRow["comp"] = Row["comp"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["depts"] = "";
                    aRow["ds_name"] = "";
                    aRow["accode"] = sumaccode1;
                    //aRow["accname"] = "支" + "年" + mm + "月份薪資";
                    //aRow["accname"] = _accname[1].ToString();
                    //aRow["accname"] = _accname[1].ToString();                   
                    aRow["accname"] = salname;//"健保局"
                    aRow["meno"] = yy + "年" + mm + "月" + salname + "公司負擔";
                    aRow["dbcr"] = "2";
                    aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    aRow["supplier"] = AppConfig.GetConfig(salcode).Value;
                    aRow["entity1"] = Row["entity1"].ToString();
                    aRow["entity2"] = Row["entity2"].ToString();
                    aRow["LegalPerson"] = Row["LegalPerson"].ToString();
                    aRow["Currency"] = Row["Currency"].ToString();
                    rq_sumamt.Rows.Add(aRow);
                    _accname1 = (_accname.Length > 1) ? _accname[1].ToString() : "";
                }
            }

            

            foreach (DataRow Row in rq_sumamt.Rows)
            {
                DT_sumamt.ImportRow(Row);
            }

            rq_sumamt = null;
        }

        public static void Get_ZZ4p(DataTable DT_zz4p, DataTable DT_dbc, DataTable DT_sumamt)
        {
            string test = "";

            DataView resort_DT_dbc = DT_dbc.DefaultView;

            resort_DT_dbc.Sort = "depts, accode, accname desc";

            DataTable sorted_DT_dbc = resort_DT_dbc.ToTable();

            foreach (DataRow Row in sorted_DT_dbc.Rows)
            {
                decimal _amt = decimal.Parse(Row["amt"].ToString());
                string _dbcr = Row["dbcr"].ToString();
                DataRow aRow = DT_zz4p.NewRow();
                aRow["type"] = Row["type"].ToString();
                aRow["comp"] = Row["comp"].ToString();
                aRow["compname"] = Row["compname"].ToString();
                aRow["dept"] = Row["depts"].ToString();
                aRow["d_name"] = Row["ds_name"].ToString();
                aRow["di"] = Row["di"].ToString();
                aRow["acccd"] = Row["accode"].ToString();
                aRow["accname"] = Row["accname"].ToString();
                aRow["meno"] = Row["meno"].ToString();
                aRow["dbcr"] = Row["dbcr"].ToString();
                aRow["amt"] = 0;
                aRow["camt"] = 0;
                //aRow["LegalPerson"] = Row["supplier"].ToString();   //Row["supplier"].ToString()
                if (_amt < 0)
                {
                    if (_dbcr == "1")
                    {
                        aRow["camt"] = decimal.Parse(Row["amt"].ToString()) * (-1);
                        aRow["dbcr"] = "2";
                    }
                    else
                    {
                        aRow["amt"] = decimal.Parse(Row["amt"].ToString()) * (-1);
                        aRow["dbcr"] = "1";
                    }
                }
                else
                {
                    if (_dbcr == "1")
                    {
                        aRow["amt"] = decimal.Parse(Row["amt"].ToString());
                    }
                    else
                    {
                        aRow["camt"] = decimal.Parse(Row["amt"].ToString());
                    }
                    aRow["dbcr"] = _dbcr;
                }
                //aRow["Currency"] = Row["Currency"].ToString();

               
                DT_zz4p.Rows.Add(aRow);
            }
            //DataTable rq_test = new DataTable();
            //rq_test.Merge(DT_zz4p);
            //JBHR.Reports.ReportClass.Export(rq_test, "DT_zz4p");
            foreach (DataRow Row in DT_sumamt.Rows)
            {
                decimal _amt = decimal.Parse(Row["amt"].ToString());
                DataRow aRow = DT_zz4p.NewRow();
                aRow["type"] = Row["type"].ToString();
                aRow["comp"] = Row["comp"].ToString();
                aRow["compname"] = Row["compname"].ToString();
                aRow["dept"] = Row["depts"].ToString();
                aRow["d_name"] = Row["ds_name"].ToString();
                aRow["acccd"] = Row["accode"].ToString();
                aRow["accname"] = Row["accname"].ToString();
                aRow["meno"] = Row["meno"].ToString();
                aRow["amt"] = 0;
                aRow["camt"] = 0;
                //aRow["LegalPerson"] = Row["supplier"].ToString();
                //if (_amt<0)
                //{
                //    aRow["dbcr"] ="1";
                //    aRow["amt"] = decimal.Parse(Row["amt"].ToString()) * (-1);
                //}
                //else
                //{
                //    aRow["dbcr"] = Row["dbcr"].ToString();
                //    aRow["camt"] = decimal.Parse(Row["amt"].ToString());
                //}   
                aRow["dbcr"] = Row["dbcr"].ToString();               
                aRow["camt"] = decimal.Parse(Row["amt"].ToString());
                //aRow["Currency"] = Row["Currency"].ToString();
                DT_zz4p.Rows.Add(aRow);
            }


        }

        public static void ExPort(DataTable DT, string FileName,string reporttype)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("科目", typeof(string));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("成本別", typeof(string));
            ExporDt.Columns.Add("摘要", typeof(string));
            ExporDt.Columns.Add("借方金額", typeof(int));
            ExporDt.Columns.Add("貸方金額", typeof(int));
            if (reporttype == "2")
            {
                DataRow [] SRow = DT.Select("", "comp asc");
                foreach (DataRow Row01 in DT.Rows)
                {
                    DataRow aRow = ExporDt.NewRow();
                    aRow["科目"] = Row01["accname"].ToString();
                    aRow["部門代碼"] = Row01["dept"].ToString();
                    aRow["部門名稱"] = Row01["d_name"].ToString();
                    aRow["成本別"] = Row01["di"].ToString();
                    aRow["摘要"] = Row01["meno"].ToString();
                    aRow["借方金額"] = int.Parse(Row01["amt"].ToString());
                    aRow["貸方金額"] = int.Parse(Row01["camt"].ToString());
                    ExporDt.Rows.Add(aRow);
                }
            }
            else
            {                
                foreach (DataRow Row02 in DT.Rows)
                {
                    DataRow aRow1 = ExporDt.NewRow();
                    aRow1["科目"] = Row02["accname"].ToString();
                    aRow1["部門代碼"] = Row02["dept"].ToString();
                    aRow1["部門名稱"] = Row02["d_name"].ToString();
                    aRow1["成本別"] = Row02["di"].ToString();
                    aRow1["摘要"] = Row02["meno"].ToString();
                    aRow1["借方金額"] = int.Parse(Row02["amt"].ToString());
                    aRow1["貸方金額"] = int.Parse(Row02["camt"].ToString());
                    ExporDt.Rows.Add(aRow1);
                }
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }
    }
}

