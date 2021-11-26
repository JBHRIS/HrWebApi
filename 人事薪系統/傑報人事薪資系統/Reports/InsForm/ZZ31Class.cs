using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;



namespace JBHR.Reports.InsForm
{
    class ZZ31Class
    {
        public static void Get_ZZ31(DataTable DT_ZZ31, DataTable DT_inslab, DataTable DT_larcode,string reporttype)
        {
            DataRow[] SRow = (reporttype == "0") ? DT_inslab.Select("", "s_no,dept,nobr asc") : DT_inslab.Select("", "s_no,l_amt,dept,nobr asc");
            foreach (DataRow Row in SRow)
            {
                if (Row["fa_idno"].ToString().Trim() == "")
                {
                    DataRow row = DT_larcode.Rows.Find(Row["lrate_code"].ToString());
                    
                    DataRow aRow = DT_ZZ31.NewRow();
                    aRow["s_no"] =  Row["s_no"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["idno"] = Row["idno"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString().Trim();
                    aRow["name_e"] = Row["name_e"].ToString().Trim();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["d_ename"] = Row["d_ename"].ToString();
                    aRow["in_date"] = DateTime.Parse(Row["in_date"].ToString());
                    aRow["out_date"] = DateTime.Parse(Row["out_date"].ToString());
                    aRow["l_amt"] = decimal.Round(decimal.Parse(Row["l_amt"].ToString()), 0);
                    if (row != null)
                    {
                        aRow["lrate_name"] = row["rate_name"].ToString();
                        aRow["normalrate"] = decimal.Parse(row["normalrate"].ToString());
                        aRow["losjobrate"] = decimal.Parse(row["losjobrate"].ToString());
                        aRow["jobaccrate"] = (Row.IsNull("jobaccrate")) ? 0 : decimal.Parse(Row["jobaccrate"].ToString());
                        aRow["selfcharge"] = decimal.Parse(row["selfcharge"].ToString());
                        aRow["compcharge"] = decimal.Parse(row["compcharge"].ToString());
                        aRow["partial"] = decimal.Parse(row["partial"].ToString());
                    }
                    DT_ZZ31.Rows.Add(aRow);
                }
            }
        }

        public static void Get_ZZ312(DataTable DT_ZZ312, DataTable DT_inslab, DataTable DT_harcode,DataTable DT_family, string reporttype)
        {
            DataRow[] SRow = (reporttype == "2") ? DT_inslab.Select("", "s_no,dept,nobr asc") : DT_inslab.Select("", "s_no,h_amt asc");
            foreach (DataRow Row in SRow)
            {
                DataRow row = DT_harcode.Rows.Find(Row["hrate_code"].ToString());                
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["fa_idno"].ToString();
                DataRow row1 = DT_family.Rows.Find(_value);
                DataRow aRow = DT_ZZ312.NewRow();
                aRow["s_no"] =Row["s_no"].ToString();
                aRow["nobr"] = Row["nobr"].ToString();
                aRow["idno"] = Row["idno"].ToString();
                aRow["name_c"] = Row["name_c"].ToString().Trim();
                aRow["name_e"] = Row["name_e"].ToString().Trim();
                aRow["dept"] = Row["dept"].ToString();
                aRow["d_name"] = Row["d_name"].ToString();
                aRow["d_ename"] = Row["d_ename"].ToString();
                aRow["in_date"] = DateTime.Parse(Row["in_date"].ToString());
                aRow["out_date"] = DateTime.Parse(Row["out_date"].ToString());
                aRow["h_amt"] = decimal.Round(decimal.Parse(Row["h_amt"].ToString()), 0);
                if (row != null)
                {
                    aRow["hrate_name"] = row["rate_name"].ToString();
                    aRow["selfcharge"] = decimal.Parse(row["selfcharge"].ToString());
                    aRow["compcharge"] = decimal.Parse(row["compcharge"].ToString());
                    aRow["partial"] = decimal.Parse(row["partial"].ToString());
                    aRow["fix_amt"] = decimal.Parse(row["fix_amt"].ToString());
                }
                if (row1 != null)
                {
                    aRow["fa_name"] = row1["fa_name"].ToString().Trim();
                }
                DT_ZZ312.Rows.Add(aRow);
            }
        }

        public static void Get_ZZ313(DataTable DT_ZZ313, DataTable DT_inslab, DataTable DT_larcode)
        {
            DataRow[] SRow = DT_inslab.Select("", "s_no,dept,nobr") ;
            foreach (DataRow Row in SRow)
            {
                decimal str_normal = 0;
                decimal str_losjob = 0;
                decimal str_self = 0;
                decimal str_partial = 0;
                decimal str_compcharge = 0;
                decimal str_jobaccrate = 0;              
                decimal str_lamt = decimal.Parse(Row["l_amt"].ToString());
                decimal str_insday=decimal.Parse(Row["insday"].ToString());
                if (Row["fa_idno"].ToString().Trim() == "")
                {
                    DataRow row = DT_larcode.Rows.Find(Row["lrate_code"].ToString());                   
                    DataRow aRow = DT_ZZ313.NewRow();
                    aRow["s_no"] = Row["s_no"].ToString();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["idno"] = Row["idno"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString().Trim();
                    aRow["name_e"] = Row["name_e"].ToString().Trim();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["d_ename"] = Row["d_ename"].ToString();
                    aRow["in_date"] = DateTime.Parse(Row["in_date"].ToString());
                    aRow["out_date"] = DateTime.Parse(Row["out_date"].ToString());
                    aRow["l_amt"] = decimal.Round(decimal.Parse(Row["l_amt"].ToString()), 0);
                    aRow["insday"] = int.Parse(Row["insday"].ToString());
                    if (row != null)
                    {
                        str_normal = decimal.Parse(row["normalrate"].ToString());
                        str_losjob = decimal.Parse(row["losjobrate"].ToString());
                        str_self = decimal.Parse(row["selfcharge"].ToString());
                        str_partial = decimal.Parse(row["partial"].ToString());
                        str_compcharge = decimal.Parse(row["compcharge"].ToString());
                        str_jobaccrate = (Row.IsNull("jobaccrate")) ? 0 : decimal.Parse(Row["jobaccrate"].ToString());
                        //ROUND(L_AMT*RV_LARCODE.NORMALRATE*RV_LARCODE.SELFCHARGE*RV_LARCODE.PARTIAL*INSDAY/30,0)+
                        //ROUND(L_AMT*RV_LARCODE.LOSJOBRATE*RV_LARCODE.SELFCHARGE*RV_LARCODE.PARTIAL*INSDAY/30,0)
                        aRow["perexp"] = Math.Round(str_lamt * str_normal * str_self * str_insday / 30, MidpointRounding.AwayFromZero) + Math.Round(str_lamt * str_losjob * str_self * str_insday / 30, MidpointRounding.AwayFromZero);
                        aRow["perexp"] = int.Parse(aRow["perexp"].ToString()) - Math.Round(str_lamt * str_normal * str_self * (1 - str_partial) * str_insday / 30, MidpointRounding.AwayFromZero) - Math.Round(str_lamt * str_losjob * str_self * (1 - str_partial) * str_insday / 30, MidpointRounding.AwayFromZero);
                        //ROUND(L_AMT*INSDAY*RV_LARCODE.JOBACCRATE/30,0)
                        aRow["jobexp"] = Math.Round(str_lamt * str_insday * str_jobaccrate / 30, MidpointRounding.AwayFromZero);
                        //IIF(INSDAY>=28,ROUND(L_AMT*.00025,0),ROUND(ROUND(L_AMT*.00025,0)*INSDAY/30,0))
                        aRow["fundexp"] = (str_insday >= 28) ? Math.Round(str_lamt * Convert.ToDecimal(0.00025), MidpointRounding.AwayFromZero) : Math.Round(Math.Round(str_lamt * Convert.ToDecimal(0.00025), MidpointRounding.AwayFromZero) * str_insday / 30, MidpointRounding.AwayFromZero);
                        //ROUND(L_AMT*(RV_LARCODE.NORMALRATE+RV_LARCODE.LOSJOBRATE)*RV_LARCODE.COMPCHARGE*INSDAY/30,0)+
                        //ROUND(L_AMT*INSDAY*RV_LARCODE.JOBACCRATE/30,0)+ROUND(L_AMT*.00025,0)
                        aRow["compexp"] = Math.Round(str_lamt * (str_normal + str_losjob) * str_compcharge * str_insday / 30, MidpointRounding.AwayFromZero) + Math.Round(str_lamt * str_insday * str_jobaccrate / 30, MidpointRounding.AwayFromZero) + int.Parse(aRow["fundexp"].ToString());
                        aRow["allexp"] = int.Parse(aRow["compexp"].ToString()) + int.Parse(aRow["jobexp"].ToString()) + int.Parse(aRow["fundexp"].ToString());
                        aRow["lrate_name"] = row["rate_name"].ToString();                        
                    }
                    DT_ZZ313.Rows.Add(aRow);
                }
            }
        }

        public static void Get_ZZ314(DataTable DT_ZZ314, DataTable DT_inslab, DataTable DT_harcode, DataTable DT_family, decimal compersoncnt, decimal heacomprate, string date_b)
        {
            DataTable rq_zz314 = new DataTable();
            rq_zz314 = DT_ZZ314.Clone();
            rq_zz314.TableName = "rq_zz314";
            DataRow[] SRow = DT_inslab.Select("", "s_no,dept,nobr asc");
            foreach (DataRow Row in SRow)
            {
                decimal str_hcompcharge = 0;
                decimal str_hpartial = 0;
                decimal str_selfcharge = 0;
                decimal str_hamt = decimal.Parse(Row["h_amt"].ToString());
                decimal _nopaytop = 0;
                decimal str_effrate = decimal.Parse(Row["eff_rate"].ToString());
                string _ddt = Row["hrate_code"].ToString();
                string _dafdfads = Row["nobr"].ToString();
                DataRow row = DT_harcode.Rows.Find(Row["hrate_code"].ToString());
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["fa_idno"].ToString();
                DataRow row1 = DT_family.Rows.Find(_value);
                DataRow aRow = rq_zz314.NewRow();
                aRow["s_no"] = Row["s_no"].ToString();
                aRow["nobr"] = Row["nobr"].ToString();
                aRow["idno"] = Row["idno"].ToString();
                aRow["name_c"] = Row["name_c"].ToString();
                aRow["name_e"] = Row["name_e"].ToString();
                aRow["fa_idno"] = Row["fa_idno"].ToString();
                if (row1!=null)
                    aRow["fa_name"] = row1["fa_name"].ToString().Trim();
                if (Row["fa_idno"].ToString().Trim() == "")
                    aRow["retrate"] = decimal.Parse(Row["retrate"].ToString());
                aRow["dept"] = Row["dept"].ToString();
                aRow["d_name"] = Row["d_name"].ToString();
                aRow["d_ename"] = Row["d_ename"].ToString();
                aRow["in_date"] = DateTime.Parse(Row["in_date"].ToString());
                aRow["out_date"] = DateTime.Parse(Row["out_date"].ToString());
                aRow["h_amt"] = decimal.Round(decimal.Parse(Row["h_amt"].ToString()), 0);
                if (row != null)
                {
                    str_hcompcharge = decimal.Parse(row["compcharge"].ToString());
                    str_hpartial = decimal.Parse(row["partial"].ToString());
                    str_selfcharge = decimal.Parse(row["selfcharge"].ToString());                   
                    aRow["hrate_name"] = row["rate_name"].ToString();
                    aRow["fix_amt"] = decimal.Round(decimal.Parse(row["fix_amt"].ToString()), 0);
                    _nopaytop = decimal.Parse(row["nopaytop"].ToString());
                }
                //REPL H_EXP WITH INT(ROUND(H_AMT*RV_HARCODE.SELFCHARGE*OAPP.COMPRATE,0)*RV_HARCODE.PARTIAL) FOR EMPTY(RV_HARCODE.FIX_AMT)
                //aRow["h_exp"] = Convert.ToInt32(Math.Round(str_hamt * str_selfcharge * heacomprate, MidpointRounding.AwayFromZero) * str_hpartial);
                //99/4/1健保費率調漲
                aRow["h_exp"] = Convert.ToInt32(Math.Round(str_hamt * str_selfcharge * str_effrate, MidpointRounding.AwayFromZero) * str_hpartial);
                aRow["h_exp1"] = (Row["fa_idno"].ToString().Trim() == "") ? Math.Round(str_hamt * str_hcompcharge * compersoncnt * heacomprate, MidpointRounding.AwayFromZero) : 0;
                //&&有輔助上限且自負額小於輔助上限
                if (int.Parse(aRow["h_exp"].ToString()) < _nopaytop && _nopaytop != 0) aRow["h_exp"] = 0;
                //&&有輔助上限且自負額大於輔助上限
                if (int.Parse(aRow["h_exp"].ToString()) > _nopaytop && _nopaytop != 0) aRow["h_exp"] = int.Parse(aRow["h_exp"].ToString()) - _nopaytop;
                
                rq_zz314.Rows.Add(aRow);              
            }            

            DataTable rq_zz314a = new DataTable();
            rq_zz314a = DT_ZZ314.Clone();
            rq_zz314a.TableName = "rq_zz314a";

            string str_nobr1 = ""; int _i = 0;
            DataRow[] ORow = rq_zz314.Select("", "s_no,dept,nobr,h_exp,fa_idno asc");
            foreach (DataRow Row in ORow)
            {
                DateTime _dateb = DateTime.Parse(Convert.ToString(DateTime.Parse(date_b).Year) + "/" + Convert.ToString(DateTime.Parse(date_b).Month) + "/01");
                DateTime _datee = _dateb.AddMonths(1).AddDays(-1);
                Int32 _indate = Convert.ToInt32(DateTime.Parse(Row["in_date"].ToString()).ToString("yyyyMMdd"));
                Int32 _outdate = Convert.ToInt32(DateTime.Parse(Row["out_date"].ToString()).ToString("yyyyMMdd"));
                //IN_DATE< _BDATE  AND BETWEEN(OUT_DATE,_BDATE,_EDATE)
                if (_indate < Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && _outdate >= Convert.ToInt32(_dateb.ToString("yyyyMMdd")) && _outdate < Convert.ToInt32(_datee.ToString("yyyyMMdd")))
                {
                    Row["h_exp"] = 0;
                    Row["h_exp1"] = 0;
                }
                string str_nobr = Row["nobr"].ToString();                
                //if (Row["fa_idno"].ToString().Trim() != "")
                //{
                //    if (str_nobr == str_nobr1)
                //        _i++;
                //    else
                //        _i = 0;                    
                //}
                //else
                //    _i = 0;
                if (str_nobr == str_nobr1)
                    _i++;
                else
                    _i = 0;       
                if (_i > 3)
                    Row["h_exp"] = 0;
                str_nobr1 = Row["nobr"].ToString();

                rq_zz314a.ImportRow(Row);
            }
            DataRow[] ORow1 = rq_zz314.Select("", "s_no,dept,nobr,fa_idno asc");
            foreach (DataRow Row in rq_zz314a.Rows)
            {
                DT_ZZ314.ImportRow(Row);
            }
            rq_zz314a = null;
            rq_zz314 = null;
        }

        public static void Get_ZZ315(DataTable DT_ZZ315, DataTable DT_inslab, DataTable DT_larcode, DataTable DT_harcode)
        {
            DataRow[] SRow = DT_inslab.Select("", "s_no,dept,nobr");
            foreach (DataRow Row in SRow)
            {               
                if (Row["fa_idno"].ToString().Trim() == "")
                {
                    DataRow row = DT_larcode.Rows.Find(Row["lrate_code"].ToString());
                    DataRow row1 = DT_harcode.Rows.Find(Row["hrate_code"].ToString());
                    DataRow aRow = DT_ZZ315.NewRow();                    
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["idno"] = Row["idno"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString().Trim();
                    aRow["name_e"] = Row["name_e"].ToString().Trim();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["d_ename"] = Row["d_ename"].ToString();
                    aRow["in_date"] = DateTime.Parse(Row["in_date"].ToString());
                    aRow["out_date"] = DateTime.Parse(Row["out_date"].ToString());
                    aRow["l_amt"] = decimal.Round(decimal.Parse(Row["l_amt"].ToString()), 0);
                    aRow["h_amt"] = decimal.Round(decimal.Parse(Row["h_amt"].ToString()), 0);
                    aRow["r_amt"] = decimal.Round(decimal.Parse(Row["r_amt"].ToString()), 0);                   
                    if (row != null) aRow["lrate_name"] = row["rate_name"].ToString();
                    if (row1 != null) aRow["hrate_name"] = row1["rate_name"].ToString();
                    DT_ZZ315.Rows.Add(aRow);
                }
            }
        }

        public static void ExPort1(DataTable DT, string FileName, string reporttype)
        {
            DataTable ExporDt = new DataTable();
            if (reporttype == "1") ExporDt.Columns.Add("投保金額", typeof(int));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));            
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("加保日期", typeof(DateTime));
            ExporDt.Columns.Add("退保日期", typeof(DateTime));
            if (reporttype=="0") ExporDt.Columns.Add("投保金額", typeof(int));
            ExporDt.Columns.Add("負擔比率", typeof(string));
            ExporDt.Columns.Add("普通事故", typeof(decimal));
            ExporDt.Columns.Add("失業給付", typeof(decimal));
            ExporDt.Columns.Add("職業災害", typeof(decimal));
            ExporDt.Columns.Add("員工負擔", typeof(decimal));
            ExporDt.Columns.Add("公司負擔", typeof(decimal));
            ExporDt.Columns.Add("部份負擔", typeof(decimal));
            DataRow[] SRow = DT.Select("", "s_no asc");
            foreach (DataRow Row01 in SRow)
            {
                DataRow aRow1 = ExporDt.NewRow();
                if (reporttype == "1") aRow1["投保金額"] = int.Parse(Row01["l_amt"].ToString());
                aRow1["部門代碼"] = Row01["dept"].ToString();
                aRow1["部門名稱"] = Row01["d_name"].ToString();
                aRow1["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow1["員工編號"] = Row01["nobr"].ToString();
                aRow1["員工姓名"] = Row01["name_c"].ToString();
                aRow1["英文姓名"] = Row01["name_e"].ToString();
                aRow1["身分證號"] = Row01["idno"].ToString();
                aRow1["加保日期"] =  DateTime.Parse(Row01["in_date"].ToString());
                aRow1["退保日期"] = DateTime.Parse(Row01["out_date"].ToString());
                if (reporttype == "0") aRow1["投保金額"] = int.Parse(Row01["l_amt"].ToString());
                aRow1["負擔比率"] = Row01["lrate_name"].ToString();
                aRow1["普通事故"] = (Row01.IsNull("normalrate")) ? 0 : decimal.Parse(Row01["normalrate"].ToString());
                aRow1["失業給付"] = (Row01.IsNull("losjobrate")) ? 0 : decimal.Parse(Row01["losjobrate"].ToString());
                aRow1["職業災害"] = (Row01.IsNull("jobaccrate")) ? 0 : decimal.Parse(Row01["jobaccrate"].ToString());
                aRow1["員工負擔"] = (Row01.IsNull("selfcharge")) ? 0 : decimal.Parse(Row01["selfcharge"].ToString());
                aRow1["公司負擔"] = (Row01.IsNull("compcharge")) ? 0 : decimal.Parse(Row01["compcharge"].ToString());
                aRow1["部份負擔"] = (Row01.IsNull("partial")) ? 0 : decimal.Parse(Row01["partial"].ToString());
                ExporDt.Rows.Add(aRow1);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort2(DataTable DT, string FileName, string reporttype)
        {
            DataTable ExporDt = new DataTable();
            if (reporttype == "3") ExporDt.Columns.Add("投保金額", typeof(int));
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("眷屬姓名", typeof(string));
            ExporDt.Columns.Add("加保日期", typeof(DateTime));
            ExporDt.Columns.Add("退保日期", typeof(DateTime));
            if (reporttype == "2") ExporDt.Columns.Add("投保金額", typeof(int));
            ExporDt.Columns.Add("負擔比率", typeof(string));           
            ExporDt.Columns.Add("員工負擔", typeof(decimal));
            ExporDt.Columns.Add("公司負擔", typeof(decimal));
            ExporDt.Columns.Add("部份負擔", typeof(decimal));
            ExporDt.Columns.Add("地區人口", typeof(decimal));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow1 = ExporDt.NewRow();
                if (reporttype == "3") aRow1["投保金額"] = int.Parse(Row01["h_amt"].ToString());
                aRow1["部門代碼"] = Row01["dept"].ToString();
                aRow1["部門名稱"] = Row01["d_name"].ToString();
                aRow1["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow1["員工編號"] = Row01["nobr"].ToString();
                aRow1["員工姓名"] = Row01["name_c"].ToString();
                aRow1["英文姓名"] = Row01["name_e"].ToString();
                aRow1["身分證號"] = Row01["idno"].ToString();
                aRow1["眷屬姓名"] = Row01["fa_name"].ToString();
                aRow1["加保日期"] = DateTime.Parse(Row01["in_date"].ToString());
                aRow1["退保日期"] = DateTime.Parse(Row01["out_date"].ToString());
                if (reporttype == "2") aRow1["投保金額"] = int.Parse(Row01["h_amt"].ToString());
                aRow1["負擔比率"] = Row01["hrate_name"].ToString();               
                aRow1["員工負擔"] = (Row01.IsNull("selfcharge")) ? 0 : decimal.Parse(Row01["selfcharge"].ToString());
                aRow1["公司負擔"] = (Row01.IsNull("compcharge")) ? 0 : decimal.Parse(Row01["compcharge"].ToString());
                aRow1["部份負擔"] = (Row01.IsNull("partial")) ? 0 : decimal.Parse(Row01["partial"].ToString());
                aRow1["地區人口"] = (Row01.IsNull("fix_amt")) ? 0 : decimal.Parse(Row01["fix_amt"].ToString());
                ExporDt.Rows.Add(aRow1);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort3(DataTable DT, string FileName)
        {
            DataTable ExporDt = new DataTable();            
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("加保日期", typeof(DateTime));
            ExporDt.Columns.Add("退保日期", typeof(DateTime));
            ExporDt.Columns.Add("投保金額", typeof(int));
            ExporDt.Columns.Add("投保天數", typeof(int));
            ExporDt.Columns.Add("負擔比率", typeof(string));
            ExporDt.Columns.Add("個人負擔", typeof(int));
            ExporDt.Columns.Add("公司負擔", typeof(int));
            ExporDt.Columns.Add("職業災害", typeof(int));
            ExporDt.Columns.Add("墊償基金", typeof(int));
            //ExporDt.Columns.Add("公司總負擔", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow1 = ExporDt.NewRow();               
                aRow1["部門代碼"] = Row01["dept"].ToString();
                aRow1["部門名稱"] = Row01["d_name"].ToString();
                aRow1["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow1["員工編號"] = Row01["nobr"].ToString();
                aRow1["員工姓名"] = Row01["name_c"].ToString();
                aRow1["英文姓名"] = Row01["name_e"].ToString();
                aRow1["身分證號"] = Row01["idno"].ToString();
                aRow1["加保日期"] = DateTime.Parse(Row01["in_date"].ToString());
                aRow1["退保日期"] = DateTime.Parse(Row01["out_date"].ToString());
                aRow1["投保金額"] = int.Parse(Row01["l_amt"].ToString());
                aRow1["投保天數"] = int.Parse(Row01["insday"].ToString());
                aRow1["負擔比率"] = Row01["lrate_name"].ToString();
                aRow1["個人負擔"] = (Row01.IsNull("perexp")) ? 0 : int.Parse(Row01["perexp"].ToString());
                aRow1["公司負擔"] = (Row01.IsNull("compexp")) ? 0 : int.Parse(Row01["compexp"].ToString());
                aRow1["職業災害"] = (Row01.IsNull("jobexp")) ? 0 : int.Parse(Row01["jobexp"].ToString());
                aRow1["墊償基金"] = (Row01.IsNull("fundexp")) ? 0 : int.Parse(Row01["fundexp"].ToString());
                //aRow1["公司總負擔"] = (Row01.IsNull("allexp")) ? 0 : int.Parse(Row01["allexp"].ToString());
                ExporDt.Rows.Add(aRow1);
            }            
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort4(DataTable DT, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));　
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("眷屬姓名", typeof(string));
            ExporDt.Columns.Add("加保日期", typeof(DateTime));
            ExporDt.Columns.Add("退保日期", typeof(DateTime));
            ExporDt.Columns.Add("投保金額", typeof(int));
            ExporDt.Columns.Add("自提比率", typeof(decimal));
            ExporDt.Columns.Add("負擔比率", typeof(string));
            ExporDt.Columns.Add("個人負擔", typeof(int));
            ExporDt.Columns.Add("公司負擔", typeof(int));
            ExporDt.Columns.Add("地區人口", typeof(int));           
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow1 = ExporDt.NewRow();
                aRow1["部門代碼"] = Row01["dept"].ToString();
                aRow1["部門名稱"] = Row01["d_name"].ToString();
                aRow1["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow1["員工編號"] = Row01["nobr"].ToString();
                aRow1["員工姓名"] = Row01["name_c"].ToString();
                aRow1["英文姓名"] = Row01["name_e"].ToString();
                aRow1["身分證號"] = Row01["idno"].ToString();
                aRow1["眷屬姓名"] = Row01["fa_name"].ToString();
                aRow1["加保日期"] = DateTime.Parse(Row01["in_date"].ToString());
                aRow1["退保日期"] = DateTime.Parse(Row01["out_date"].ToString());
                aRow1["投保金額"] = int.Parse(Row01["h_amt"].ToString());
                aRow1["自提比率"] = (Row01.IsNull("retrate")) ? 0 : decimal.Parse(Row01["retrate"].ToString());
                aRow1["負擔比率"] = Row01["hrate_name"].ToString();
                aRow1["個人負擔"] = (Row01.IsNull("h_exp")) ? 0 : int.Parse(Row01["h_exp"].ToString());
                aRow1["公司負擔"] = (Row01.IsNull("h_exp1")) ? 0 : int.Parse(Row01["h_exp1"].ToString());
                aRow1["地區人口"] = (Row01.IsNull("fix_amt")) ? 0 : int.Parse(Row01["fix_amt"].ToString());
                ExporDt.Rows.Add(aRow1);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }

        public static void ExPort5(DataTable DT, string FileName)
        {
            DataTable ExporDt = new DataTable();
            ExporDt.Columns.Add("部門代碼", typeof(string));
            ExporDt.Columns.Add("部門名稱", typeof(string));
            ExporDt.Columns.Add("英文部門名稱", typeof(string));
            ExporDt.Columns.Add("員工編號", typeof(string));
            ExporDt.Columns.Add("員工姓名", typeof(string));
            ExporDt.Columns.Add("英文姓名", typeof(string));
            ExporDt.Columns.Add("身分證號", typeof(string));
            ExporDt.Columns.Add("加保日期", typeof(DateTime));
            ExporDt.Columns.Add("退保日期", typeof(DateTime));
            ExporDt.Columns.Add("勞保金額", typeof(int));
            ExporDt.Columns.Add("勞保負擔比率", typeof(string));
            ExporDt.Columns.Add("健保金額", typeof(int));
            ExporDt.Columns.Add("健保負擔比率", typeof(string));
            ExporDt.Columns.Add("勞退金額", typeof(int));
            foreach (DataRow Row01 in DT.Rows)
            {
                DataRow aRow1 = ExporDt.NewRow();
                aRow1["部門代碼"] = Row01["dept"].ToString();
                aRow1["部門名稱"] = Row01["d_name"].ToString();
                aRow1["英文部門名稱"] = Row01["d_ename"].ToString();
                aRow1["員工編號"] = Row01["nobr"].ToString();
                aRow1["員工姓名"] = Row01["name_c"].ToString();
                aRow1["英文姓名"] = Row01["name_e"].ToString();
                aRow1["身分證號"] = Row01["idno"].ToString();
                aRow1["加保日期"] = DateTime.Parse(Row01["in_date"].ToString());
                aRow1["退保日期"] = DateTime.Parse(Row01["out_date"].ToString());
                aRow1["勞保金額"] = int.Parse(Row01["l_amt"].ToString());
                aRow1["勞保負擔比率"] = Row01["lrate_name"].ToString();
                aRow1["健保金額"] = int.Parse(Row01["h_amt"].ToString());
                aRow1["健保負擔比率"] = Row01["hrate_name"].ToString();
                aRow1["勞退金額"] = int.Parse(Row01["r_amt"].ToString());
                ExporDt.Rows.Add(aRow1);
            }
            JBHR.Reports.ReportClass.Export(ExporDt, FileName);
        }
    }
}

